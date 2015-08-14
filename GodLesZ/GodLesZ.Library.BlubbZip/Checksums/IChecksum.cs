namespace GodLesZ.Library.BlubbZip.Checksums {

	public interface IChecksum {
		/// <summary>
		/// Returns the data checksum computed so far.
		/// </summary>
		long Value {
			get;
		}

		/// <summary>
		/// Resets the data checksum as if no update was ever called.
		/// </summary>
		void Reset();

		/// <summary>
		/// Adds one byte to the data checksum.
		/// </summary>
		/// <param name = "value">
		/// the data value to add. The high byte of the int is ignored.
		/// </param>
		void Update( int value );

		/// <summary>
		/// Updates the data checksum with the bytes taken from the array.
		/// </summary>
		/// <param name="buffer">
		/// buffer an array of bytes
		/// </param>
		void Update( byte[] buffer );

		/// <summary>
		/// Adds the byte array to the data checksum.
		/// </summary>
		/// <param name = "buffer">
		/// The buffer which contains the data
		/// </param>
		/// <param name = "offset">
		/// The offset in the buffer where the data starts
		/// </param>
		/// <param name = "count">
		/// the number of data bytes to add.
		/// </param>
		void Update( byte[] buffer, int offset, int count );
	}
}
