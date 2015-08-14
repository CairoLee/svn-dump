using System;
using System.IO;
using System.Net;
using GodLesZ.Library;
using GodLesZ.Library.Amf.Net;
using GodLesZ.Library.Network.WebRequest;

namespace AuthTest {

	public class Program {

		public static void Main(string[] args) {
			// AMF Stream test
			//TestAmfStreamReading();
			//return;

			// Auth testing against DSO login server using web auth (SSL)
			CookieCollection cookies = null;

			PostRequest req = new PostRequest();
			req.AutoRedirect = false;
			req.Cookies = new System.Net.CookieCollection();
			req.IgnoreCookies = false;
			req.UrlReferer = "";
			req.Type = PostRequest.PostTypeEnum.Post;
			req.Url = "https://www.diesiedleronline.de/de//api/user/login/";
			req.PostItems.Add("password", "Kfbbb7bnb147wcs");
			req.PostItems.Add("name", "godlesz");

			PostResult result = req.Post();
			// Should be "{"status":"OKAY","data":true}"
			if (result.ResponseString != "{\"status\":\"OKAY\",\"data\":true}") {
				return;
			}
			cookies = result.Cookies;
			/*
			// Auth on Server
			req = new PostRequest("http://w09bb01.diesiedleronline.de/authenticate", "");
			//req.Cookies = cookies;
			req.Type = PostRequest.PostTypeEnum.Post;
			req.PostItems.Add("DSOAUTHTOKEN", cookies["DSOAUTHTOKEN"].Value);
			req.PostItems.Add("DSOAUTHUSER", cookies["DSOAUTHUSER"].Value);

			result = req.Post();
			// [auth token]|[nickname]|[dont know]
			// xHO0VGr4FN8sPgmi9oal2pkdGSi5N9pP|GodLesZ|2VZ5dSE0otnrYdvXuRxLzA==
			Regex re = new Regex("^([^|]+)|([^|]+)|(.+)$");
			Match m = re.Match(result.ResponseString);
			if (m.Success == false) {
				return;
			}

			// Take care of new cookie "dsoAuthToken"
			cookies = result.Cookies;
			*/

			/**
			 * TODO: This seems some sort of queue refresh
			 *       Its called every 120ms if I'm right
			 */

			// Auth succesfull, first login on zone
			// TODO: fetch zoneID somewhere dynamic
			req = new PostRequest("http://w09bb01.diesiedleronline.de/Z" + DateTime.Now.UnixTimestamp(), "");
			req.Cookies = cookies;
			req.Type = PostRequest.PostTypeEnum.Post;
			req.PostItems.Add("DSOAUTHTOKEN", cookies["DSOAUTHTOKEN"].Value);
			req.PostItems.Add("DSOAUTHUSER", cookies["DSOAUTHUSER"].Value);
			req.PostItems.Add("zoneID", "0");

			// Request goes to the "BigBrother Master Server 1.01 (I AM ROCKSER)" :D
			result = req.Post();
			// Should be "queuePos=<integer>&queueSize=<integer>"


			// Refresh cookies using ping (?)
			req = new PostRequest("http://www.diesiedleronline.de/ping.php", "");
			req.Cookies = cookies;

			// Request goes to the "BigBrother Master Server 1.01 (I AM ROCKSER)" :D
			result = req.Post();
			if (result.ResponseString != "OK") {
			}
			cookies = result.Cookies;


			// All auth things should be done
			// Now request "BigBrother" again to get URL of AMF stream
			req = new PostRequest("http://w09bb01.diesiedleronline.de/Z" + DateTime.Now.UnixTimestamp(), "");
			req.Cookies = cookies;
			req.Type = PostRequest.PostTypeEnum.Post;
			req.PostItems.Add("DSOAUTHTOKEN", cookies["DSOAUTHTOKEN"].Value);
			req.PostItems.Add("DSOAUTHUSER", cookies["DSOAUTHUSER"].Value);
			req.PostItems.Add("zoneID", "0");

			result = req.Post();

			string amfStreamUrl = result.ResponseString; // "http://w09g02.diesiedleronline.de:80/GameServer02/amf";

			string amfHeader = "";
			amfHeader += "Referer: http://static13.cdn.ubi.com/settlers_online/live/de/L4230DE/SWMMO/debug/SWMMO.swf\r\n";
			amfHeader += "Content-type: application/x-amf\r\n";
			amfHeader += "Content-length: "; // 244\r\n\r\n";
			string amfBody = "";
			amfBody += new string(new char[] { '\u0000', '\u0003', '\u0000', '\u0000', '\u0000', '\u0001', '\u0000', '\u0004' });
			amfBody += "null";
			amfBody += new string(new char[] { '\u0000', '\u0002' });
			amfBody += "/1";
			amfBody += new string(new char[] { '\u0000', '\u0000', '\u0000' });
			amfBody += 'à' + "\n";
			amfBody += new string(new char[] { '\u0000', '\u0000', '\u0000', '\u0001', '\u0011' });
			amfBody += "\n";
			amfBody += '\u0013';
			amfBody += "Mflex.messaging.messages.CommandMessage";
			amfBody += '\u0013';
			amfBody += "operation";
			amfBody += '\u001b' + "correlationId" + '\t' + "body";
			amfBody += '\u0013' + "messageId" + '\u0011';
			amfBody += "clientId" + '\u0015' + "timeToLive" + '\u000f' + "headers" + '\u0017' + "destination";
			amfBody += '\u0013' + "timestamp";
			amfBody += new string(new char[] { '\u0004', '\u0005', '\u0006', '\u0001' });
			amfBody += "\n";
			amfBody += '\u000b' + '\u0001' + '\u0001' + '\u0006';
			amfBody += "I8BA4CBAC-4903-65E8-BFD4-DAC61B28D122";
			amfBody += new string(new char[] { '\u0001', '\u0004', '\u0000' });
			amfBody += "\n";
			amfBody += '\u0005' + "%DSMessagingVersion" + '\u0004' + '\u0001' + '\t';
			amfBody += "DSId" + '\u0006' + '\u0007' + "nil" + '\u0001' + '\u0006' + '\u0001' + '\u0004' + '\u0000';

			amfHeader += (amfBody.Length) + "\r\n\r\n";
			string amfData = amfHeader + amfBody;

			req = new PostRequest(amfStreamUrl, "");
			req.Cookies = cookies;
			req.Type = PostRequest.PostTypeEnum.Post;

			result = req.PostData(amfData);
			// Load Amf reader
			DsoAmfReader amfReader = new DsoAmfReader(result.ResponseData);


			// Open AMF stream
			NetConnection con = new NetConnection();
			con.ObjectEncoding = GodLesZ.Library.Amf.ObjectEncoding.AMF3;
			con.NetStatus += new NetStatusHandler(con_NetStatus);
			con.OnConnect += new ConnectHandler(con_OnConnect);
			con.OnDisconnect += new DisconnectHandler(con_OnDisconnect);
			con.BeginConnect(amfStreamUrl, new AsyncCallback(con_Connect), con);

			Console.WriteLine("Connection started..");
			Console.ReadLine();
		}

		static void con_Connect(IAsyncResult result) {
			NetConnection con = (NetConnection)result.AsyncState;
			con.EndConnect(result);

			Console.WriteLine("> Connected: " + con.Connected);
			con.Call("flex.messaging.messages.CommandMessage", new Responder<object>(con_ConnectCallCallback));
		}

		static void con_OnConnect(object sender, EventArgs e) {
			Console.WriteLine("> OnConnect");
		}

		static void con_OnDisconnect(object sender, EventArgs e) {
			Console.WriteLine("> OnDisconnect");
		}

		static void con_NetStatus(object sender, NetStatusEventArgs e) {
			Console.WriteLine("> NetStatus: " + e.Info);
		}


		private static void con_ConnectCallCallback(object result) {
			Console.WriteLine(result);
		}

		private static void TestAmfStreamReading() {
			/*
			string amfBody = "";
			amfBody += new string(new char[] { '\u0000', '\u0003', '\u0000', '\u0000', '\u0000', '\u0001', '\u0000', '\u0004' });
			amfBody += "null";
			amfBody += new string(new char[] { '\u0000', '\u0002' });
			amfBody += "/1";
			amfBody += new string(new char[] { '\u0000', '\u0000', '\u0000' });
			amfBody += 'à' + "\n";
			amfBody += new string(new char[] { '\u0000', '\u0000', '\u0000', '\u0001', '\u0011' });
			amfBody += "\n";
			amfBody += '\u0013';
			amfBody += "Mflex.messaging.messages.CommandMessage";
			amfBody += '\u0013';
			amfBody += "operation";
			amfBody += '\u001b' + "correlationId" + '\t' + "body";
			amfBody += '\u0013' + "messageId" + '\u0011';
			amfBody += "clientId" + '\u0015' + "timeToLive" + '\u000f' + "headers" + '\u0017' + "destination";
			amfBody += '\u0013' + "timestamp";
			amfBody += new string(new char[] { '\u0004', '\u0005', '\u0006', '\u0001' });
			amfBody += "\n";
			amfBody += '\u000b' + '\u0001' + '\u0001' + '\u0006';
			amfBody += "I8BA4CBAC-4903-65E8-BFD4-DAC61B28D122";
			amfBody += new string(new char[] { '\u0001', '\u0004', '\u0000' });
			amfBody += "\n";
			amfBody += '\u0005' + "%DSMessagingVersion" + '\u0004' + '\u0001' + '\t';
			amfBody += "DSId" + '\u0006' + '\u0007' + "nil" + '\u0001' + '\u0006' + '\u0001' + '\u0004' + '\u0000';
			*/
			string amfData = "\u0000\u0003\u0000\u0000\u0000\u0001\u0000\u0004null\u0000\u0004/663\u0000\u0000\u0002\n\u0000\u0000\u0000\u0001\u0011\n\u0013Oflex.messaging.messages.RemotingMessage\u0013operation\rsource\tbody\u0013messageId\u0011clientId\u0015timeToLive\u000fheaders\u0017destination\u0013timestamp\u0006#ExecuteServerCall\u0006Mcom.bluebyte.game.servlet.EventHandler\t\u0003\u0001\nSQdefaultGame.Communication.VO.dServerCall\u0017dsoAuthUser\rzoneID\tdata\u0019dsoAuthToken\ttype\u0006\u000f1025970\u0004¾Ï2\n3UdefaultGame.Communication.VO.dTradeOfferVO\u000boffer\u000bcosts\u0019receipientId\n#QdefaultGame.Communication.VO.dResourceVO\u0017name_string\ramount\u0006\tWood\u0004|\n\r\u0006\u000bHorse\u0004\u0014\u0004½².\u0006AjVEtMOrNV5gGmFQJyXFyolquaSk6FEp8\u0004\u0006\u0006ID334D2D4-ADFF-EB81-9C4D-EF1A88FC2771\u0006I3B7237C3-212B-B628-B593-CEA617E02353\u0004\u0000\n\u000b\u0001\tDSId\u0006I3B723672-370B-8557-5EB1-8288C1934FE6\u0015DSEndpoint\u0006\u0019SMC-Endpoint\u0001\u0006\u0007SMC\u0004\u0000";
			using (StringReader sr = new StringReader(amfData)) {
				string buf = sr.ReadToEnd();
				DsoAmfReader amfReader = new DsoAmfReader(buf);
			}
		}


	}

}
