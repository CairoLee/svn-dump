
namespace GodLesZ.Library.Network.Packet {
	/// <summary>
	/// Point to Point Protocol
	/// See http://tools.ietf.org/html/rfc2516
	/// </summary>
	public class PPPoEFields {
		/// <summary> Size in bytes of the version/type field </summary>
		public readonly static int VersionTypeLength = 1;

		/// <summary> Size in bytes of the code field </summary>
		public readonly static int CodeLength = 1;

		/// <summary> Size in bytes of the SessionId field </summary>
		public readonly static int SessionIdLength = 2;

		/// <summary> Size in bytes of the Length field </summary>
		public readonly static int LengthLength = 2;

		/// <summary> Offset from the start of the header to the version/type field </summary>
		public readonly static int VersionTypePosition = 0;

		/// <summary> Offset from the start of the header to the Code field </summary>
		public readonly static int CodePosition;

		/// <summary> Offset from the start of the header to the SessionId field </summary>
		public readonly static int SessionIdPosition;

		/// <summary> Offset from the start of the header to the Length field </summary>
		public readonly static int LengthPosition;

		/// <summary>
		/// Length of the overall PPPoe header
		/// </summary>
		public readonly static int HeaderLength;

		static PPPoEFields() {
			CodePosition = VersionTypePosition + VersionTypeLength;
			SessionIdPosition = CodePosition + CodeLength;
			LengthPosition = SessionIdPosition + SessionIdLength;

			HeaderLength = LengthPosition + LengthLength;
		}
	}
}

