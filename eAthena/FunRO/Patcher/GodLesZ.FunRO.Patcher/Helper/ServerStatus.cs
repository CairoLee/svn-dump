using System.Xml;
using GodLesZ.Library.Network;

namespace GodLesZ.FunRO.Patcher {

	public class ServerStatus {
		public static string StatusUrl = "http://testcp.funro.nu/server/status-xml/";

		public bool LoginServer {
			get;
			set;
		}

		public bool CharServer {
			get;
			private set;
		}

		public bool MapServer {
			get;
			set;
		}

		public bool WoeActive {
			get;
			private set;
		}

		public int PlayerCount {
			get;
			private set;
		}


		public ServerStatus() {
		}


		public void DownloadStatus() {
			// Load info from CP xml export
			TimeoutWebClient web = new TimeoutWebClient();
			web.TimeOut = 5000;

			try {
				string statusData = web.DownloadString(StatusUrl);
				// Load xml data into our class
				XmlDocument doc = new XmlDocument();
				doc.LoadXml(statusData);
				// doc -> xml -> ServerStatus -> Group -> Server
				XmlNode node = doc.FirstChild.NextSibling.FirstChild.FirstChild;

				string loginServer = node.Attributes["loginServer"].Value.Trim();
				string charServer = node.Attributes["charServer"].Value.Trim();
				string mapServer = node.Attributes["mapServer"].Value.Trim();
				string woeActive = node.Attributes["woeActive"].Value.Trim();
				string playersOnline = node.Attributes["playersOnline"].Value.Trim();

				LoginServer = (loginServer == "1");
				CharServer = (charServer == "1");
				MapServer = (mapServer == "1");
				WoeActive = (woeActive == "1");
				PlayerCount = int.Parse(playersOnline);
			} catch {
				// Failed, assume servers are donw
				Reset();
			}
		}

		public void Reset() {
			LoginServer = false;
			CharServer = false;
			MapServer = false;
			WoeActive = false;
			PlayerCount = 0;

		}

	}

}
