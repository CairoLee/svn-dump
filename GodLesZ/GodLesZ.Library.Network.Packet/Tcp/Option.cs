using System;
using GodLesZ.Library.Network.Packet.Utils;

namespace GodLesZ.Library.Network.Packet.Tcp {
	/// <summary>
	/// A TCP Option
	/// </summary>
	public abstract class Option {
		#region Constructors

		/// <summary>
		/// Creates an Option from a byte[]
		/// </summary>
		/// <param name="bytes">
		/// A <see cref="System.Byte[]"/>
		/// </param>
		/// <param name="offset">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="length">
		/// A <see cref="System.Int32"/>
		/// </param>
		public Option(byte[] bytes, int offset, int length) {
			optionData = new ByteArraySegment(bytes, offset, length);
		}

		#endregion

		#region Properties

		/// <summary>
		/// The Length of the Option type
		/// </summary>
		public virtual byte Length {
			get { return Bytes[LengthFieldOffset]; }
		}

		/// <summary>
		/// The Kind of option
		/// </summary>
		public OptionTypes Kind {
			get { return (OptionTypes)Bytes[KindFieldOffset]; }
		}

		/// <summary>
		/// Returns a TLV that contains the Option
		/// </summary>
		public byte[] Bytes {
			get {
				byte[] bytes = new byte[optionData.Length];
				Array.Copy(optionData.Bytes, optionData.Offset, bytes, 0, optionData.Length);
				return bytes;
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Returns the Option info as a string
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/>
		/// </returns>
		public override string ToString() {
			return "[" + Kind.ToString() + "]";
		}

		#endregion

		#region Members

		// stores the data/length/offset of the option
		private ByteArraySegment optionData;

		/// <summary>The length (in bytes) of the Kind field</summary>
		internal const int KindFieldLength = 1;

		/// <summary>The length (in bytes) of the Length field</summary>
		internal const int LengthFieldLength = 1;

		/// <summary>The offset (in bytes) of the Kind Field</summary>
		internal const int KindFieldOffset = 0;

		/// <summary>The offset (in bytes) of the Length field</summary>
		internal const int LengthFieldOffset = 1;

		#endregion
	}
}