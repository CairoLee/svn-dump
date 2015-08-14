
using System.Text.RegularExpressions;
using GodLesZ.SiedlerOnline.TradeListener.Library;
using System.Text;
namespace XmlTest {

	public class Program {

		public static void Main(string[] args) {
			string xml = "<body xmlns='http://jabber.org/protocol/httpbind'><message xmlns=\"jabber:client\" type=\"groupchat\" from=\"trade@conference.94.236.31.135/monika5\" id=\"m_45\" to=\"godlesz@94.236.31.135/xiff-bosh\"><body>Plank|200|Coin|50</body><bbmsg xmlns=\"bbmsg\" playername=\"monika5\" playerid=\"1003212\" playertag=\"\"/></message><message xmlns=\"jabber:client\" type=\"groupchat\" to=\"godlesz@94.236.31.135/xiff-bosh\" from=\"global-1@conference.94.236.31.135/warkanoid\" id=\"m_295\"><body>GEILO!!</body></body><bbmsg xmlns=\"bbmsg\" playername=\"Warkanoid\" playertag=\"\" playerid=\"1096507\"/></message><presence xmlns=\"jabber:client\" to=\"godlesz@94.236.31.135/xiff-bosh\" from=\"trade@conference.94.236.31.135/thorhaus\" type=\"unavailable\"><priority>0</priority><x xmlns=\"http://jabber.org/protocol/muc#user\"><item affiliation=\"none\" role=\"none\"/></x></presence><message xmlns=\"jabber:client\" id=\"m_1740\" from=\"global-1@conference.94.236.31.135/maniac83\" to=\"godlesz@94.236.31.135/xiff-bosh\" type=\"groupchat\"><body>guter mann:)</body><bbmsg xmlns=\"bbmsg\" playertag=\"\" playerid=\"1046129\" playername=\"Maniac83\"/></message></body>";
			DsoChatPacket packet = DsoChatPacket.Parse(Encoding.UTF8.GetBytes(xml));
		}

	}

}
