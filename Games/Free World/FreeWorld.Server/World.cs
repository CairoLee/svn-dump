using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using FreeWorld.Server.Shared;
using FreeWorld.Server.Zones;

namespace FreeWorld.Server {
	/// <summary>
	///     The heart of the server. Handles everybody connected.
	/// </summary>
	public class World {
		private const int MAX_CCU = 10000;

		/// <summary>
		///     How fast the world will try to update
		/// </summary>
		private const int WORLD_UPDATE_TARGET_MS = 50;

		/// <summary>
		///     The TCP port to listen for connections on
		/// </summary>
		private const int TCP_PORT = 25189;

		private readonly SocketAsyncPool mAsyncPool = new SocketAsyncPool(2048, MAX_CCU * 2);

		/// <summary>
		///     Dictionary of World ID -> Entity of everybody connected
		/// </summary>
		private readonly ConcurrentDictionary<int, ServerEntity> mEntities;

		/// <summary>
		///     Handles all random number generation
		/// </summary>
		private readonly Random mRng = new Random(Environment.TickCount);

		/// <summary>
		///     The TCP listener for the world
		/// </summary>
		private readonly TcpDispatcher mTcp;

		/// <summary>
		///     The time (tick count) when the last world update started
		/// </summary>
		private int mLastWorldUpdateTime;

		/// <summary>
		///     Flag to stop world updates
		/// </summary>
		private bool mUpdateWorld;

		/// <summary>
		///     The thread that world updates will run on
		/// </summary>
		private Thread mWorldUpdateThread;

		public int LastUpdateDelta {
			get;
			private set;
		}

		/// <summary>
		///     The amount of currently connected users
		/// </summary>
		public int CurrentConnectedUsers {
			get { return mEntities.Count; }
		}

		/// <summary>
		///     Manages all zones in the world
		/// </summary>
		public ZoneManager ZoneManager {
			get;
			private set;
		}


		/// <summary>
		///     A whole neww worlddddddd!
		/// </summary>
		public World() {
			mEntities = new ConcurrentDictionary<int, ServerEntity>();

			mTcp = new TcpDispatcher(IPAddress.Any, TCP_PORT);
			mTcp.SocketConnected += Tcp_SocketConnected;

			ZoneManager = new ZoneManager();
		}


		/// <summary>
		///     Event handler for TCP connections.
		/// </summary>
		private void Tcp_SocketConnected(Socket socket) {
			//Keep going until we find an ID for them
			while (true) {
				//Generate an ID
				var worldID = mRng.Next();

				//See if it's unique
				if (!mEntities.ContainsKey(worldID)) {
					//Add them in
					var entity = new ServerEntity(socket, worldID, this, mAsyncPool);
					if (mEntities.TryAdd(worldID, entity)) {
						//DONE!
						Console.WriteLine(worldID + " joined");
						break;
					}
				}
			}
		}

		/// <summary>
		///     Start the world running.
		/// </summary>
		public void Start() {
			//Start the tcp listener
			mTcp.Start();

			//Set up world updates
			mLastWorldUpdateTime = Environment.TickCount;
			mUpdateWorld = true;

			//Start world update thread
			mWorldUpdateThread = new Thread(WorldUpdate);
			//m_worldUpdateThread.Priority = ThreadPriority.AboveNormal;
			mWorldUpdateThread.Start();
		}

		/// <summary>
		///     Stop the world running
		/// </summary>
		public void Stop() {
			//Kill the update thread
			mUpdateWorld = false;
			mWorldUpdateThread.Join();

			//Stop listening for new connections
			mTcp.Stop();
		}

		/// <summary>
		///     World update logic
		/// </summary>
		private void WorldUpdate() {
			//Check if we're supposed to be running
			while (mUpdateWorld) {
				//Calculate update delta
				var dt = TimeSpan.FromTicks(Environment.TickCount - mLastWorldUpdateTime);

				var updateStartTime = DateTime.Now;

				//Time for some expensive O(n) badness...
				foreach (var entity in mEntities.Values) {
					//Handle disconnect
					if (!entity.IsConnected) {
						ServerEntity e;
						if (mEntities.TryRemove(entity.WorldID, out e)) {
							Console.WriteLine("Entity disconnected: " + e.WorldID);
							ZoneManager.RemoveEntity(e);
							e.Dispose();
						}

						continue;
					}

					if (entity.AuthState == EEntityAuthState.Authorised) {
						//Update nearby entities with each other
						ZoneManager.PushNearbyEntities(entity);
					}

					//Call update on this entity
					entity.Update(dt);
				}

				//Track update times
				mLastWorldUpdateTime = Environment.TickCount;

				//Calculate how long to sleep for, based on how long the world update took

				LastUpdateDelta = (int)(DateTime.Now - updateStartTime).TotalMilliseconds;
				var sleepTime = WORLD_UPDATE_TARGET_MS - LastUpdateDelta;

				Thread.Sleep(Math.Max(0, sleepTime));
			}
		}

		/// <summary>
		///     Resolve a world ID to a name
		/// </summary>
		/// <returns></returns>
		public string GetNameForWorldID(int worldID) {
			var name = string.Empty;

			ServerEntity entity;
			if (mEntities.TryGetValue(worldID, out entity)) {
				name = entity.Name;
			}

			return name;
		}

	}

}