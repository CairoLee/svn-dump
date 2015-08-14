using MiscUtil.Conversion;

namespace GodLesZ.Library.Network.Packet.Tcp {
	/// <summary>
	/// User Timeout Option
	/// The TCP user timeout controls how long transmitted data may remain
	///  unacknowledged before a connection is forcefully closed
	/// </summary>
	/// <remarks>
	/// References:
	///  http://datatracker.ietf.org/doc/rfc5482/
	/// </remarks>
	public class UserTimeout : Option {
		#region Constructors

		/// <summary>
		/// Creates a User Timeout Option
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
		public UserTimeout(byte[] bytes, int offset, int length) :
			base(bytes, offset, length) { }

		#endregion

		#region Properties

		/// <summary>
		/// The Granularity
		/// </summary>
		public bool Granularity {
			get {
				int granularity = ((int)Values >> 15);
				return (granularity != 0);
			}
		}

		/// <summary>
		/// The User Timeout
		/// </summary>
		public ushort Timeout {
			get { return (ushort)((int)Values & TimeoutMask); }
		}

		// a convenient property to grab the value fields for further processing
		private ushort Values {
			get { return EndianBitConverter.Big.ToUInt16(Bytes, ValuesFieldOffset); }
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
			return "[" + Kind.ToString() + ": Granularity=" + (Granularity ? "minutes" : "seconds") + " Timeout=" + Timeout + "]";
		}

		#endregion

		#region Members

		// the offset (in bytes) of the Value Fields
		const int ValuesFieldOffset = 2;

		// the mask used to strip the Granularity field from the
		//  Values filed to expose the UserTimeout field
		const int TimeoutMask = 0x7FFF;

		#endregion
	}
}