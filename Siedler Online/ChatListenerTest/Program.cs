using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;

namespace ChatListenerTest {

	public class Program {
		public const string SERVER_IP = "94.236.31.135";
		public const int SERVER_PORT = 80;

		private static StringDictionary mNetIfaceMapping;


		public static void Main(string[] args) {
			Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
			//SocketPair socketpair = new SocketPair(socket, buffer);
			//socket.Blocking = true;
			var ip = IPAddress.Parse("0.0.0.0");
			var endPoint = new IPEndPoint(ip, SERVER_PORT);
			socket.Bind(endPoint);
			socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);

			byte[] buffer = new byte[2048];
			int received = socket.Receive(buffer);


			mNetIfaceMapping = new StringDictionary();
			foreach (var net in NetworkInterface.GetAllNetworkInterfaces()) {
				mNetIfaceMapping.Add(net.Name, net.Id);
			}

			ProcessStartInfo psi = new ProcessStartInfo();
			//psi.CreateNoWindow = true;
			psi.UseShellExecute = false;
			psi.RedirectStandardError = true;
			psi.RedirectStandardInput = true;
			psi.RedirectStandardOutput = true;

			string tcpdumpSnaplen = "0";
			string sDropRoot = Environment.UserName != string.Empty ? "-Z " + Environment.UserName : "";
			psi.FileName = "windump";
			psi.Arguments =
				"-i \\Device\\NPF_" + mNetIfaceMapping["LAN-Verbindung"] + " -s " + tcpdumpSnaplen +
				" -A " + sDropRoot + " net " + SERVER_IP + " and port " + SERVER_PORT;

			Process p = new Process();
			p.StartInfo = psi;
			p.EnableRaisingEvents = true;
			p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
			p.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);
			p.Exited += new EventHandler(p_Exited);
			p.Start();

			Console.WriteLine("Listener started..");
			Console.ReadLine();

			Console.WriteLine("Try killing listener..");
			while (p.HasExited == false) {
				p.Kill();
				Thread.Sleep(100);
			}
			p = null;
			Console.WriteLine("Listener killed." + Environment.NewLine + "Press any key to exit.");
			Console.ReadLine();
		}


		private static void p_Exited(object sender, EventArgs e) {
			Console.WriteLine("> Listener exit..");
		}

		private static void p_ErrorDataReceived(object sender, DataReceivedEventArgs e) {
			Console.WriteLine("> ErrorDataReceived: " + e.Data);
		}

		private static void p_OutputDataReceived(object sender, DataReceivedEventArgs e) {
			Console.WriteLine("> OutputDataReceived: " + e.Data);
		}

	}

}
