using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using Rovolution.Server.Network;
using System.IO;
using GodLesZ.Library;
using System.Text.RegularExpressions;


namespace Rovolution.Server.Network {

	public class SocketConnector {
		private SocketListener mListener;
		private Queue<NetState> mQueue;
		private Queue<NetState> mWorkingQueue;
		private Queue<NetState> mThrottled;
		private byte[] mPeek;

		private string mIP;
		private int mPort;

		public string IP {
			get { return mIP; }
		}
		public int Port {
			get { return mPort; }
		}
		public SocketListener Listener {
			get { return mListener; }
			set { mListener = value; }
		}


		public SocketConnector(string IP, int Port) {
			mIP = IP;
			mPort = Port;
			IPHostEntry iphe = null;
			try {
				iphe = Dns.GetHostEntry(mIP);
				if (iphe == null || iphe.AddressList.Length < 1)
					throw new Exception("Unable to fetch IP Address from: " + mIP + "::" + mPort);
			} catch (Exception e) {
				throw e;
			}

			//iphe.AddressList[0].ToString()
			IPEndPoint endPoint = null;
			Regex reIP = new Regex(@"^[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}$", RegexOptions.Compiled);
			foreach (IPAddress ip in iphe.AddressList) {
				string ipString = ip.ToString();
				if (ipString == "::1" || ipString.Length == 0 || reIP.IsMatch(ipString) == false) {
					continue;
				}

				endPoint = new IPEndPoint(ip, mPort);
				break;
			}
			if (endPoint == null) {
				throw new Exception("Failed to load SocketListener");
			}

			bool bSuccess = false;
			do {
				SocketListener Listener = new SocketListener(endPoint, this);
				if (bSuccess == false && Listener != null)
					bSuccess = true;
				mListener = Listener;

				if (bSuccess == false) {
					ServerConsole.ErrorLine("Unable to Connect - retrying in 10sec...");
					Thread.Sleep(10000);
				}
			} while (bSuccess == false);

			mQueue = new Queue<NetState>();
			mWorkingQueue = new Queue<NetState>();
			mThrottled = new Queue<NetState>();
			mPeek = new byte[4];
		}


		/// <summary>
		/// Checks for new connections
		/// </summary>
		private void CheckListener() {
			Socket[] accepted = mListener.Slice();

			for (int i = 0; i < accepted.Length; ++i) {
				NetState ns = new NetState(accepted[i], this);
				ns.Start();

				if (ns.Running) {
					ServerConsole.StatusLine("{0}: Connected. [{1} Online]", ns, NetState.Instances.Count);
				}
			}
		}


		public void OnReceive(NetState ns) {
			lock (this)
				mQueue.Enqueue(ns);

			Core.Set();
		}

		/// <summary>
		/// Checks for new connections and handles packet incomes for all instances
		/// </summary>
		public void Slice() {
			CheckListener();

			lock (this) {
				Queue<NetState> temp = mWorkingQueue;
				mWorkingQueue = mQueue;
				mQueue = temp;
			}

			while (mWorkingQueue.Count > 0) {
				NetState ns = mWorkingQueue.Dequeue();

				if (ns.Running)
					HandleReceive(ns);
			}

			lock (this) {
				while (mThrottled.Count > 0)
					mQueue.Enqueue(mThrottled.Dequeue());
			}
		}

		private const int mBufferSize = 4096;
		private BufferPool mBuffers = new BufferPool("Processor", 4, mBufferSize);

		public bool HandleReceive(NetState ns) {
			if (ns == null || ns.Running == false) {
				return false;
			}
			ByteQueue buffer = ns.Buffer;

			if (buffer == null || buffer.Length <= 0)
				return true;

			ServerConsole.DebugLine("{0}: Incoming data, {1} bytes", ns, buffer.Length);

			/*
			 * Packet Analyse/verify && Parsing
			 */

			lock (buffer) {
				int turns = 0;
				int length = buffer.Length;
				while (length > 0 && ns != null && ns.Running) {
					short packetID = buffer.GetPacketID();

#if DEBUG_PACKETS
					// debug log
					using (TextWriter writer = File.CreateText(AppDomain.CurrentDomain.BaseDirectory + @"\packet_" + DateTime.Now.UnixTimestamp() + ".log")) {
						using (MemoryStream ms = new MemoryStream(buffer.ByteBuffer))
							Tools.FormatBuffer(writer, ms, (int)ms.Length);
					}
#endif

					PacketHandler handler = PacketHandlers.GetHandler(packetID);
					if (handler == null) {
						byte[] data = new byte[length];
						length = buffer.Dequeue(data, 0, length);

						// Log unknown packets
						string unknownPacketPath = AppDomain.CurrentDomain.BaseDirectory + @"\packet_" + packetID.ToString("X4") + ".log";
						if (File.Exists(unknownPacketPath) == false) {
							using (TextWriter writer = File.CreateText(unknownPacketPath)) {
								writer.WriteLine("Unknown packet 0x" + packetID.ToString("X4") + ", length " + length);
								using (MemoryStream ms = new MemoryStream(data)) {
									Tools.FormatBuffer(writer, ms, (int)ms.Length);
								}
							}
						}

						ServerConsole.WarningLine("{0}: P {1:X4}, {2} bytes, no Handler found!", ns, packetID, length);
						break;
					}

					ServerConsole.StatusLine("{0}: [{1}] P {2:X4}, {3} bytes, handled {4}", ns, handler.Name, packetID, length, handler.Length);

					byte[] packetBuffer;
					// If we set the length to -1 (dynamic packet length), read the full buffer
					int bufferLength = (handler.Length > 0 ? handler.Length : length);
					if (bufferLength < mBufferSize)
						packetBuffer = mBuffers.AcquireBuffer();
					else
						packetBuffer = new byte[bufferLength];

					buffer.Dequeue(packetBuffer, 0, bufferLength);

					PacketReader r = new PacketReader(packetBuffer, bufferLength, 0, true);
					handler.OnReceive(ns, r);
					length -= bufferLength;

					if (bufferLength < mBufferSize) {
						mBuffers.ReleaseBuffer(packetBuffer);
					} else {
						packetBuffer = null;
					}

					turns++;
				} // end while()*/

			} // end Lock()

			// Clear internal byte buffer for receive data
			if (ns != null && ns.Buffer != null) {
				ns.Buffer.Clear();
			}

			return true;
		}
	}


}
