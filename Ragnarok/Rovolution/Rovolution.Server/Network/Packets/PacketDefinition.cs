using System.Xml.Serialization;

namespace Rovolution.Server.Network {

	/// <summary>Represents one packet definition.</summary>
	[XmlRoot("Packet")]
	public class PacketDefinition {
		private string mStringID;

		/// <summary>
		///		This is a fake to allow import of hex numbers.
		///		The serializer will set this on import and we set the <see cref="ID"/>
		///		property.
		/// </summary>
		[XmlAttribute("ID")]
		public string StringID {
			get { return ID.ToString(); }
			set {
				mStringID = value;
				if (mStringID == null || mStringID.Length == 0) {
					ID = 0;
					return;
				}

				if (mStringID.StartsWith("0x") == true) {
					ID = short.Parse(mStringID.Substring(2), System.Globalization.NumberStyles.HexNumber);
				} else {
					ID = short.Parse(mStringID);
				}
			}
		}

		/// <summary>Gets or sets the packet identifier.</summary>
		[XmlIgnore]
		public short ID {
			get;
			protected set;
		}

		/// <summary>Gets or sets the packets length. -1 means length is dynamic.</summary>
		[XmlAttribute()]
		public int Length {
			get;
			set;
		}

		/// <summary>Gets or sets the packet description, used in debug output.</summary>
		[XmlAttribute()]
		public string Description {
			get;
			set;
		}

		/// <summary>Gets or sets the class to search the <see cref="HandlerName"/> method.</summary>
		public string HandlerType {
			get;
			set;
		}

		/// <summary>Gets or sets the method name to search in the <see cref="HandlerType"/> class.</summary>
		public string HandlerName {
			get;
			set;
		}


		public PacketDefinition() {
		}

	}

}
