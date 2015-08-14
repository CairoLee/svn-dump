using System;

namespace GodLesZ.Library.BlubbZip.Checksums {

	public sealed class Adler32 : IChecksum {
		private uint checksum;
		private const uint BASE = 65521;

		/// <summary>
		/// Returns the Adler32 data checksum computed so far.
		/// </summary>
		public long Value {
			get { return checksum; }
		}


		/// <summary>
		/// Creates a new instance of the Adler32 class.
		/// The checksum starts off with a value of 1.
		/// </summary>
		public Adler32() {
			Reset();
		}

		/// <summary>
		/// Resets the Adler32 checksum to the initial value.
		/// </summary>
		public void Reset() {
			checksum = 1;
		}

		/// <summary>
		/// Updates the checksum with a byte value.
		/// </summary>
		/// <param name="value">
		/// The data value to add. The high byte of the int is ignored.
		/// </param>
		public void Update( int value ) {
			// We could make a length 1 byte array and call update again, but I
			// would rather not have that overhead
			uint s1 = checksum & 0xFFFF;
			uint s2 = checksum >> 16;

			s1 = ( s1 + ( (uint)value & 0xFF ) ) % BASE;
			s2 = ( s1 + s2 ) % BASE;

			checksum = ( s2 << 16 ) + s1;
		}

		/// <summary>
		/// Updates the checksum with an array of bytes.
		/// </summary>
		/// <param name="buffer">
		/// The source of the data to update with.
		/// </param>
		public void Update( byte[] buffer ) {
			if( buffer == null ) {
				throw new ArgumentNullException( "buffer" );
			}

			Update( buffer, 0, buffer.Length );
		}

		/// <summary>
		/// Updates the checksum with the bytes taken from the array.
		/// </summary>
		/// <param name="buffer">
		/// an array of bytes
		/// </param>
		/// <param name="offset">
		/// the start of the data used for this update
		/// </param>
		/// <param name="count">
		/// the number of bytes to use for this update
		/// </param>
		public void Update( byte[] buffer, int offset, int count ) {
			if( buffer == null )
				throw new ArgumentNullException( "buffer" );
			if( offset < 0 )
				throw new ArgumentOutOfRangeException( "offset", "cannot be negative" );
			if( count < 0 )
				throw new ArgumentOutOfRangeException( "count", "cannot be negative" );
			if( offset >= buffer.Length )
				throw new ArgumentOutOfRangeException( "offset", "not a valid index into buffer" );
			if( ( offset + count ) > buffer.Length )
				throw new ArgumentOutOfRangeException( "count", "exceeds buffer size" );

			uint s1 = checksum & 0xFFFF;
			uint s2 = checksum >> 16;

			while( count > 0 ) {
				// s1 max grow 65521 -> 65521 + 255 * 3800
				// s2 max grow by 3800 * median( s1 ) = 2090079800 < 2 ^ 31
				int n = 3800;
				if( n > count )
					n = count;

				count -= n;
				while( --n >= 0 ) {
					s1 = s1 + (uint)( buffer[ offset++ ] & 0xff );
					s2 = s2 + s1;
				}
				s1 %= BASE;
				s2 %= BASE;
			}

			checksum = ( s2 << 16 ) | s1;
		}

	}
}
