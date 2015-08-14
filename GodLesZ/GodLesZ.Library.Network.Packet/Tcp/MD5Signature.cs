using System;

namespace GodLesZ.Library.Network.Packet.Tcp {
	/// <summary>
	/// MD5 Signature
	///  Carries the MD5 Digest used by the BGP protocol to
	///   ensure security between two endpoints
	/// </summary>
	/// <remarks>
	/// References:
	///  http://datatracker.ietf.org/doc/rfc2385/
	/// </remarks>
	public class MD5Signature : Option {
		#region Constructors

		/// <summary>
		/// Creates a MD5 Signature Option
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
		public MD5Signature(byte[] bytes, int offset, int length) :
			base(bytes, offset, length) { }

		#endregion

		#region Properties

		/// <summary>
		/// The MD5 Digest
		/// </summary>
		public byte[] MD5Digest {
			get {
				byte[] data = new byte[Length - MD5DigestFieldOffset];
				Array.Copy(Bytes, MD5DigestFieldOffset, data, 0, data.Length);
				return data;
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
			return "[" + Kind.ToString() + ": MD5Digest=0x" + MD5Digest.ToString() + "]";
		}

		#endregion

		#region Members

		// the offset (in bytes) of the MD5 Digest field
		const int MD5DigestFieldOffset = 2;

		#endregion
	}
}