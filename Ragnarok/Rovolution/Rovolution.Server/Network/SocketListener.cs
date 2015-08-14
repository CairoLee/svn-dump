using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Collections;
using System.Net;
using GodLesZ.Library;

namespace Rovolution.Server.Network {
	public class SocketListener : IDisposable {
		private static Socket[] mEmptySockets = new Socket[0];
		private static IPEndPoint[] mEndPoints;

		private Socket mListener;
		private Queue<Socket> mAccepted;
		private object mAcceptedSyncRoot;
		private AsyncCallback mOnAccept;

		public static IPEndPoint[] EndPoints {
			get { return mEndPoints; }
			set { mEndPoints = value; }
		}

		public List<IPAddress> IPs {
			get;
			private set;
		}

		public List<int> Ports {
			get;
			private set;
		}


		public SocketListener(IPEndPoint ipep, SocketConnector Connector) {
			IPs = new List<IPAddress>();
			Ports = new List<int>();

			mAccepted = new Queue<Socket>();
			mAcceptedSyncRoot = ((ICollection)mAccepted).SyncRoot;
			mOnAccept = new AsyncCallback(OnAccept);
			mListener = Bind(ipep, Connector);
			if (mListener == null)
				throw new Exception("Could not bind IP to Socket! Please check your Network Configuration!");
		}


		private Socket Bind(IPEndPoint ipep, SocketConnector Connector) {
			Socket s = SocketPool.AcquireSocket();

			try {
				s.LingerState.Enabled = false;
				s.ExclusiveAddressUse = false;

				s.Bind(ipep);
				s.Listen(8);

				if (ipep.Address.Equals(IPAddress.Any)) {
					try {
						ServerConsole.StatusLine(String.Format("start listen on {0}:{1}", IPAddress.Loopback, ipep.Port));

						IPHostEntry iphe = Dns.GetHostEntry(Dns.GetHostName());
						IPAddress[] ip = iphe.AddressList;
						for (int i = 0; i < ip.Length; ++i) {
							ServerConsole.StatusLine(String.Format("# {0}:{1}", ip[i], ipep.Port));
							IPs.Add(ip[i]);
							Ports.Add(ipep.Port);
						}
					} catch {
					}
				} else {
					IPs.Add(ipep.Address);
					Ports.Add(ipep.Port);
					if (ipep.Address.ToString() != Connector.IP) {
						ServerConsole.StatusLine(String.Format("start listen on {0} -> {1}:{2}", Connector.IP, ipep.Address, ipep.Port));
					} else {
						ServerConsole.StatusLine(String.Format("start listen on {0}:{1}", ipep.Address, ipep.Port));
					}
				}

				IAsyncResult res = s.BeginAccept(SocketPool.AcquireSocket(), 0, mOnAccept, s);
				return s;
			} catch (Exception e) {
				/* TODO
				 * throws more Exceptions like this
				 */
				if (e is SocketException) {
					SocketException se = (SocketException)e;

					if (se.ErrorCode == 10048) { // WSAEADDRINUSE
						ServerConsole.ErrorLine(String.Format("Listener Failed: {0} -> {1}:{2} (In Use)", Connector.IP, ipep.Address, ipep.Port));
					} else if (se.ErrorCode == 10049) { // WSAEADDRNOTAVAIL
						ServerConsole.ErrorLine(String.Format("Listener Failed: {0} -> {1}:{2} (Unavailable)", Connector.IP, ipep.Address, ipep.Port));
					} else {
						ServerConsole.ErrorLine("Listener Exception:");
						ServerConsole.WriteLine(e);
					}
				}

				return null;
			}
		}

		private void OnAccept(IAsyncResult asyncResult) {
			Socket listener = (Socket)asyncResult.AsyncState;
			Socket accepted = null;

			try {
				accepted = listener.EndAccept(asyncResult);
			} catch (SocketException ex) {
				ExceptionHandler.Trace(ex);
			} catch (ObjectDisposedException) {
				return;
			}

			if (accepted != null) {
				if (VerifySocket(accepted)) {
					Enqueue(accepted);
				} else {
					Release(accepted);
				}
			}

			try {
				listener.BeginAccept(SocketPool.AcquireSocket(), 0, mOnAccept, listener);
			} catch (SocketException ex) {
				ExceptionHandler.Trace(ex);
			} catch (ObjectDisposedException) {
			}
		}

		private bool VerifySocket(Socket socket) {
			try {
				SocketConnectEventArgs args = new SocketConnectEventArgs(socket);

				Events.InvokeSocketConnect(args);

				return args.AllowConnection;
			} catch (Exception ex) {
				ExceptionHandler.Trace(ex);

				return false;
			}
		}

		private void Enqueue(Socket socket) {
			lock (mAcceptedSyncRoot) {
				mAccepted.Enqueue(socket);
			}

			Core.Set();
		}

		private void Release(Socket socket) {
			try {
				socket.Shutdown(SocketShutdown.Both);
			} catch (SocketException ex) {
				ExceptionHandler.Trace(ex);
			}

			try {
				socket.Close();

				SocketPool.ReleaseSocket(socket);
			} catch (SocketException ex) {
				ExceptionHandler.Trace(ex);
			}
		}

		public Socket[] Slice() {
			Socket[] array;

			lock (mAcceptedSyncRoot) {
				if (mAccepted.Count == 0)
					return mEmptySockets;

				array = mAccepted.ToArray();
				mAccepted.Clear();
			}

			return array;
		}

		public void Dispose() {
			Socket socket = Interlocked.Exchange<Socket>(ref mListener, null);

			if (socket != null) {
				socket.Close();
			}
		}

	}

}
