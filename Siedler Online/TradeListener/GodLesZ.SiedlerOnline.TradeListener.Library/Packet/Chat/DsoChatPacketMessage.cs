using System;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace GodLesZ.SiedlerOnline.TradeListener.Library {

	[XmlRoot("message")]
	public class DsoChatPacketMessage {
		public static Regex RegexGlobalChat = new Regex("^global-[0-9]*", RegexOptions.Compiled);
		public static Regex RegexHelpChat = new Regex("^help-[0-9]*", RegexOptions.Compiled);

		private EDsoMsgTypes mType = EDsoMsgTypes.Unknown;

		[XmlAttribute("type")]
		public string TypeRaw {
			get;
			set;
		}

		[XmlAttribute("id")]
		public string MessageID {
			get;
			set;
		}

		[XmlAttribute("from")]
		public string Sender {
			get;
			set;
		}

		[XmlAttribute("to")]
		public string Target {
			get;
			set;
		}

		[XmlElement("body")]
		public string MessageBody {
			get;
			set;
		}

		[XmlElement("bbmsg")]
		public DsoChatPacketMessageDetails MessageDetails {
			get;
			set;
		}



		[XmlIgnore]
		public EDsoMsgTypes Type {
			get {
				if (mType != EDsoMsgTypes.Unknown) {
					return mType;
				}

				// global-1, global-2, global-3, ..
				if (RegexGlobalChat.IsMatch(Sender)) {
					mType = EDsoMsgTypes.ChatGlobal;
				} else if (Sender.StartsWith("trade@")) {
					mType = EDsoMsgTypes.Trade;
				} else if (Sender.StartsWith("help@") || RegexHelpChat.IsMatch(Sender)) {
					mType = EDsoMsgTypes.ChatHelp;
				}

				if (Target.StartsWith("trade@")) {
					mType |= EDsoMsgTypes.MyTrade;
				} else if (RegexGlobalChat.IsMatch(Target)) {
					mType |= EDsoMsgTypes.MyChat;
				}

				// Check for trade cancellation
				if (string.IsNullOrEmpty(MessageBody) == false && MessageBody.ToLower() == "clear") {
					mType |= EDsoMsgTypes.Clear;
				}

				if (mType == EDsoMsgTypes.Unknown) {
					Console.WriteLine("Unable to detect trade type by target: " + Target);
				}
				return mType;
			}
		}

		[XmlIgnore]
		public string SenderName {
			get { return (MessageDetails != null && string.IsNullOrEmpty(MessageDetails.Player) == false ? MessageDetails.Player : "<empty name>"); }
		}

		[XmlIgnore]
		public string SenderNameFormatted {
			get { return (MessageDetails != null && string.IsNullOrEmpty(MessageDetails.PLayerTag) == false ? "[" + MessageDetails.PLayerTag + "] " + SenderName : SenderName); }
		}

		[XmlIgnore]
		public DateTime Timestamp {
			get;
			set;
		}

		public DsoChatPacketMessage() {
			Timestamp = DateTime.Now;
		}

	}

}
