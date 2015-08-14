using System;

namespace GodLesZ.Library.ProcessEditAPI {

	public sealed partial class ProcessEdit {

		#region WriteMemory
		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <param name="nSize">Number of bytes to be written.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteBytes( uint dwAddress, byte[] Value, int nSize ) {
			return MemoryHelper.WriteBytes( this.mProcess, dwAddress, Value, nSize );
		}

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteBytes( uint dwAddress, byte[] Value ) {
			return this.WriteBytes( dwAddress, Value, Value.Length );
		}

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteByte( uint dwAddress, byte Value ) {
			return MemoryHelper.WriteByte( this.mProcess, dwAddress, Value );
		}

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteSByte( uint dwAddress, sbyte Value ) {
			return MemoryHelper.WriteSByte( this.mProcess, dwAddress, Value );
		}

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteUShort( uint dwAddress, ushort Value ) {
			return MemoryHelper.WriteUShort( this.mProcess, dwAddress, Value );
		}

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteShort( uint dwAddress, short Value ) {
			return MemoryHelper.WriteShort( this.mProcess, dwAddress, Value );
		}

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteUInt( uint dwAddress, uint Value ) {
			return MemoryHelper.WriteUInt( this.mProcess, dwAddress, Value );
		}

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteInt( uint dwAddress, int Value ) {
			return MemoryHelper.WriteInt( this.mProcess, dwAddress, Value );
		}

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteUInt64( uint dwAddress, UInt64 Value ) {
			return MemoryHelper.WriteUInt64( this.mProcess, dwAddress, Value );
		}

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteInt64( uint dwAddress, Int64 Value ) {
			return MemoryHelper.WriteInt64( this.mProcess, dwAddress, Value );
		}

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteFloat( uint dwAddress, float Value ) {
			return MemoryHelper.WriteFloat( this.mProcess, dwAddress, Value );
		}

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteDouble( uint dwAddress, double Value ) {
			return MemoryHelper.WriteDouble( this.mProcess, dwAddress, Value );
		}

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <param name="objType">Type of object to be written (hint: use Object.GetType() or typeof(ObjectType)).</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteObject( uint dwAddress, object Value, Type objType ) {
			return MemoryHelper.WriteObject( this.mProcess, dwAddress, Value, objType );
		}

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteObject( uint dwAddress, object Value ) {
			return MemoryHelper.WriteObject( this.mProcess, dwAddress, Value, Value.GetType() );
		}

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteASCIIString( uint dwAddress, string Value ) {
			return MemoryHelper.WriteASCIIString( this.mProcess, dwAddress, Value );
		}

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteUnicodeString( uint dwAddress, string Value ) {
			return MemoryHelper.WriteUnicodeString( this.mProcess, dwAddress, Value );
		}
		#endregion

		#region ReadMemory
		/// <summary>
		/// Reads a value from memory
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <param name="nSize">Number of bytes to read from memory.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		public byte[] ReadBytes( uint dwAddress, int nSize ) {
			if( !this.mProcessOpen || this.mProcess == IntPtr.Zero )
				throw new Exception( "Process is not open for read/write." );

			return MemoryHelper.ReadBytes( this.mProcess, dwAddress, nSize );
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		public byte ReadByte( uint dwAddress ) {
			if( !this.mProcessOpen || this.mProcess == IntPtr.Zero )
				throw new Exception( "Process is not open for read/write." );

			return MemoryHelper.ReadByte( this.mProcess, dwAddress );
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		public sbyte ReadSByte( uint dwAddress ) {
			if( !this.mProcessOpen || this.mProcess == IntPtr.Zero )
				throw new Exception( "Process is not open for read/write." );

			return MemoryHelper.ReadSByte( this.mProcess, dwAddress );
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		public ushort ReadUShort( uint dwAddress ) {
			return this.ReadUShort( dwAddress, false );
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <param name="bReverse">Determines whether bytes read will be reversed or not (Little endian or big endian).  Usually 'false'.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		/// <remarks>Sometimes one needs to read a value where the most significant bytes is not first (i.e. when reading a network packet from memory).  In this case, one would specify 'true' for the bReverse parameter to get the value in a readable format.</remarks>
		public ushort ReadUShort( uint dwAddress, bool bReverse ) {
			if( !this.mProcessOpen || this.mProcess == IntPtr.Zero )
				throw new Exception( "Process is not open for read/write." );

			return MemoryHelper.ReadUShort( this.mProcess, dwAddress, bReverse );
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		public short ReadShort( uint dwAddress ) {
			return this.ReadShort( dwAddress, false );
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <param name="bReverse">Determines whether bytes read will be reversed or not (Little endian or big endian).  Usually 'false'.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		/// <remarks>Sometimes one needs to read a value where the most significant bytes is not first (i.e. when reading a network packet from memory).  In this case, one would specify 'true' for the bReverse parameter to get the value in a readable format.</remarks>
		public short ReadShort( uint dwAddress, bool bReverse ) {
			if( !this.mProcessOpen || this.mProcess == IntPtr.Zero )
				throw new Exception( "Process is not open for read/write." );

			return MemoryHelper.ReadShort( this.mProcess, dwAddress, bReverse );
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		public uint ReadUInt( uint dwAddress ) {
			return this.ReadUInt( dwAddress, false );
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <param name="bReverse">Determines whether bytes read will be reversed or not (Little endian or big endian).  Usually 'false'.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		/// <remarks>Sometimes one needs to read a value where the most significant bytes is not first (i.e. when reading a network packet from memory).  In this case, one would specify 'true' for the bReverse parameter to get the value in a readable format.</remarks>
		public uint ReadUInt( uint dwAddress, bool bReverse ) {
			if( !this.mProcessOpen || this.mProcess == IntPtr.Zero )
				throw new Exception( "Process is not open for read/write." );

			return MemoryHelper.ReadUInt( this.mProcess, dwAddress, bReverse );
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		public int ReadInt( uint dwAddress ) {
			return this.ReadInt( dwAddress, false );
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <param name="bReverse">Determines whether bytes read will be reversed or not (Little endian or big endian).  Usually 'false'.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		/// <remarks>Sometimes one needs to read a value where the most significant bytes is not first (i.e. when reading a network packet from memory).  In this case, one would specify 'true' for the bReverse parameter to get the value in a readable format.</remarks>
		public int ReadInt( uint dwAddress, bool bReverse ) {
			if( !this.mProcessOpen || this.mProcess == IntPtr.Zero )
				throw new Exception( "Process is not open for read/write." );

			return MemoryHelper.ReadInt( this.mProcess, dwAddress, bReverse );
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		public UInt64 ReadUInt64( uint dwAddress ) {
			return this.ReadUInt64( dwAddress, false );
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <param name="bReverse">Determines whether bytes read will be reversed or not (Little endian or big endian).  Usually 'false'.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		/// <remarks>Sometimes one needs to read a value where the most significant bytes is not first (i.e. when reading a network packet from memory).  In this case, one would specify 'true' for the bReverse parameter to get the value in a readable format.</remarks>
		public UInt64 ReadUInt64( uint dwAddress, bool bReverse ) {
			if( !this.mProcessOpen || this.mProcess == IntPtr.Zero )
				throw new Exception( "Process is not open for read/write." );

			return MemoryHelper.ReadUInt64( this.mProcess, dwAddress, bReverse );
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		public Int64 ReadInt64( uint dwAddress ) {
			return this.ReadInt64( dwAddress, false );
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <param name="bReverse">Determines whether bytes read will be reversed or not (Little endian or big endian).  Usually 'false'.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		/// <remarks>Sometimes one needs to read a value where the most significant bytes is not first (i.e. when reading a network packet from memory).  In this case, one would specify 'true' for the bReverse parameter to get the value in a readable format.</remarks>
		public Int64 ReadInt64( uint dwAddress, bool bReverse ) {
			if( !this.mProcessOpen || this.mProcess == IntPtr.Zero )
				throw new Exception( "Process is not open for read/write." );

			return MemoryHelper.ReadInt64( this.mProcess, dwAddress, bReverse );
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		public float ReadFloat( uint dwAddress ) {
			return this.ReadFloat( dwAddress, false );
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <param name="bReverse">Determines whether bytes read will be reversed or not (Little endian or big endian).  Usually 'false'.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		/// <remarks>Sometimes one needs to read a value where the most significant bytes is not first (i.e. when reading a network packet from memory).  In this case, one would specify 'true' for the bReverse parameter to get the value in a readable format.</remarks>
		public float ReadFloat( uint dwAddress, bool bReverse ) {
			if( !this.mProcessOpen || this.mProcess == IntPtr.Zero )
				throw new Exception( "Process is not open for read/write." );

			return MemoryHelper.ReadFloat( this.mProcess, dwAddress, bReverse );
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		public double ReadDouble( uint dwAddress ) {
			return this.ReadDouble( dwAddress, false );
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <param name="bReverse">Determines whether bytes read will be reversed or not (Little endian or big endian).  Usually 'false'.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		/// <remarks>Sometimes one needs to read a value where the most significant bytes is not first (i.e. when reading a network packet from memory).  In this case, one would specify 'true' for the bReverse parameter to get the value in a readable format.</remarks>
		public double ReadDouble( uint dwAddress, bool bReverse ) {
			if( !this.mProcessOpen || this.mProcess == IntPtr.Zero )
				throw new Exception( "Process is not open for read/write." );

			return MemoryHelper.ReadDouble( this.mProcess, dwAddress, bReverse );
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <param name="objType">Type of object to be read (hint: use Object.GetType() or typeof(ObjectType) macro).</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		public object ReadObject( uint dwAddress, Type objType ) {
			if( !this.mProcessOpen || this.mProcess == IntPtr.Zero )
				throw new Exception( "Process is not open for read/write." );

			return MemoryHelper.ReadObject( this.mProcess, dwAddress, objType );
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <param name="nLength">Maximum number of characters to be read.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		public string ReadASCIIString( uint dwAddress, int nLength ) {
			return MemoryHelper.ReadASCIIString( this.mProcess, dwAddress, nLength );
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <param name="nLength">Maximum number of characters to be read.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		public string ReadUnicodeString( uint dwAddress, int nLength ) {
			return MemoryHelper.ReadUnicodeString( this.mProcess, dwAddress, nLength );
		}
		#endregion

		#region AllocateFreeMemory
		/// <summary>
		/// Allocates memory inside the opened process.
		/// </summary>
		/// <param name="nSize">Number of bytes to allocate.</param>
		/// <param name="dwAllocationType">Type of memory allocation.  See <see cref="MemoryAllocType"/>.</param>
		/// <param name="dwProtect">Type of memory protection.  See <see cref="MemoryProtectType"/></param>
		/// <returns>Returns NULL on failure, or the base address of the allocated memory on success.</returns>
		public uint AllocateMemory( int nSize, uint dwAllocationType, uint dwProtect ) {
			return MemoryHelper.AllocateMemory( mProcess, nSize, dwAllocationType, dwProtect );
		}

		/// <summary>
		/// Allocates memory inside the opened process.
		/// </summary>
		/// <param name="nSize">Number of bytes to allocate.</param>
		/// <returns>Returns NULL on failure, or the base address of the allocated memory on success.</returns>
		/// <remarks>
		/// Allocates memory using <see cref="MemoryAllocType.MEM_COMMIT"/> and <see cref="MemoryProtectType.PAGE_EXECUTE_READWRITE"/>.
		/// </remarks>
		public uint AllocateMemory( int nSize ) {
			return AllocateMemory( nSize, MemoryAllocType.MEM_COMMIT, MemoryProtectType.PAGE_EXECUTE_READWRITE );
		}

		/// <summary>
		/// Allocates memory inside the opened process.
		/// </summary>
		/// <returns>Returns NULL on failure, or the base address of the allocated memory on success.</returns>
		/// <remarks>
		/// Allocates 0x1000 bytes of memory using <see cref="MemoryAllocType.MEM_COMMIT"/> and <see cref="MemoryProtectType.PAGE_EXECUTE_READWRITE"/>.
		/// </remarks>
		public uint AllocateMemory() {
			return AllocateMemory( MemoryHelper.DEFAULT_MEMORY_SIZE );
		}

		/// <summary>
		/// Frees an allocated block of memory in the opened process.
		/// </summary>
		/// <param name="dwAddress">Base address of the block of memory to be freed.</param>
		/// <param name="nSize">Number of bytes to be freed.  This must be zero (0) if using <see cref="MemoryFreeType.MEM_RELEASE"/>.</param>
		/// <param name="dwFreeType">Type of free operation to use.  See <see cref="MemoryFreeType"/>.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool FreeMemory( uint dwAddress, int nSize, uint dwFreeType ) {
			return MemoryHelper.FreeMemory( mProcess, dwAddress, nSize, dwFreeType );
		}

		/// <summary>
		/// Frees an allocated block of memory in the opened process.
		/// </summary>
		/// <param name="dwAddress">Base address of the block of memory to be freed.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		/// <remarks>
		/// Frees a block of memory using <see cref="MemoryFreeType.MEM_RELEASE"/>.
		/// </remarks>
		public bool FreeMemory( uint dwAddress ) {
			return FreeMemory( dwAddress, /*size must be 0 for MEM_RELEASE*/ 0, MemoryFreeType.MEM_RELEASE );
		}
		#endregion

	}
}