using System;
using System.Text;
using System.IO;

using GodLesZ.Library.BlubbZip.Checksums;
using GodLesZ.Library.BlubbZip.Blubb.Compression;
using GodLesZ.Library.BlubbZip.Blubb.Compression.Streams;

using GodLesZ.Library.BlubbZip.Encryption;

namespace GodLesZ.Library.BlubbZip.Blubb {
	/// <summary>
	/// This is an InflaterInputStream that reads the files baseInputStream an blubb archive
	/// one after another.  It has a special method to get the blubb entry of
	/// the next file.  The blubb entry contains information about the file name
	/// size, compressed size, Crc, etc.
	/// It includes support for Stored and Deflated entries.
	/// </summary>
	public class BlubbZipInputStream : InflaterInputStream {
		#region Instance Fields

		/// <summary>
		/// Delegate for reading bytes from a stream. 
		/// </summary>
		delegate int ReadDataHandler( byte[] b, int offset, int length );

		/// <summary>
		/// The current reader this instance.
		/// </summary>
		ReadDataHandler internalReader;

		Crc32 crc = new Crc32();
		BlubbZipEntry entry;

		long size;
		int method;
		int flags;
		string password;
		#endregion

		#region Constructors
		/// <summary>
		/// Creates a new Blubb input stream, for reading a blubb archive.
		/// </summary>
		/// <param name="baseInputStream">The underlying <see cref="Stream"/> providing data.</param>
		public BlubbZipInputStream( Stream baseInputStream )
			: base( baseInputStream, new Inflater( true ) ) {
			internalReader = new ReadDataHandler( ReadingNotAvailable );
		}
		#endregion

		/// <summary>
		/// Optional password used for encryption when non-null
		/// </summary>
		/// <value>A password for all encrypted <see cref="BlubbEntry">entries </see> in this <see cref="BlubbInputStream"/></value>
		public string Password {
			get { return password; }
			set { password = value; }
		}


		/// <summary>
		/// Gets a value indicating if there is a current entry and it can be decompressed
		/// </summary>
		/// <remarks>
		/// The entry can only be decompressed if the library supports the blubb features required to extract it.
		/// See the <see cref="BlubbEntry.Version">BlubbEntry Version</see> property for more details.
		/// </remarks>
		public bool CanDecompressEntry {
			get { return ( entry != null ) && entry.CanDecompress; }
		}

		/// <summary>
		/// Advances to the next entry in the archive
		/// </summary>
		/// <returns>
		/// The next <see cref="BlubbEntry">entry</see> in the archive or null if there are no more entries.
		/// </returns>
		/// <remarks>
		/// If the previous entry is still open <see cref="CloseEntry">CloseEntry</see> is called.
		/// </remarks>
		/// <exception cref="InvalidOperationException">
		/// Input stream is closed
		/// </exception>
		/// <exception cref="BlubbException">
		/// Password is not set, password is invalid, compression method is invalid,
		/// version required to extract is not supported
		/// </exception>
		public BlubbZipEntry GetNextEntry() {
			if( crc == null ) {
				throw new InvalidOperationException( "Closed." );
			}

			if( entry != null ) {
				CloseEntry();
			}

			int header = inputBuffer.ReadLeInt();

			if( header == BlubbZipConstants.CentralHeaderSignature ||
				header == BlubbZipConstants.EndOfCentralDirectorySignature ||
				header == BlubbZipConstants.CentralHeaderDigitalSignature ||
				header == BlubbZipConstants.ArchiveExtraDataSignature ||
				header == BlubbZipConstants.Blubb64CentralFileHeaderSignature ) {
				// No more individual entries exist
				Close();
				return null;
			}

			// -jr- 07-Dec-2003 Ignore spanning temporary signatures if found
			// Spanning signature is same as descriptor signature and is untested as yet.
			if( ( header == BlubbZipConstants.SpanningTempSignature ) || ( header == BlubbZipConstants.SpanningSignature ) ) {
				header = inputBuffer.ReadLeInt();
			}

			if( header != BlubbZipConstants.LocalHeaderSignature ) {
				throw new BlubbZipException( "Wrong Local header signature: 0x" + String.Format( "{0:X}", header ) );
			}

			short versionRequiredToExtract = (short)inputBuffer.ReadLeShort();

			flags = inputBuffer.ReadLeShort();
			method = inputBuffer.ReadLeShort();
			uint dostime = (uint)inputBuffer.ReadLeInt();
			int crc2 = inputBuffer.ReadLeInt();
			csize = inputBuffer.ReadLeInt();
			size = inputBuffer.ReadLeInt();
			int nameLen = inputBuffer.ReadLeShort();
			int extraLen = inputBuffer.ReadLeShort();

			bool isCrypted = ( flags & 1 ) == 1;

			byte[] buffer = new byte[ nameLen ];
			inputBuffer.ReadRawBuffer( buffer );

			string name = BlubbZipConstants.ConvertToStringExt( flags, buffer );

			entry = new BlubbZipEntry( name, versionRequiredToExtract );
			entry.Flags = flags;

			entry.CompressionMethod = (CompressionMethod)method;

			if( ( flags & 8 ) == 0 ) {
				entry.Crc = crc2 & 0xFFFFFFFFL;
				entry.Size = size & 0xFFFFFFFFL;
				entry.CompressedSize = csize & 0xFFFFFFFFL;

				entry.CryptoCheckValue = (byte)( ( crc2 >> 24 ) & 0xff );

			} else {

				// This allows for GNU, WinBlubb and possibly other archives, the PKZIP spec
				// says these values are zero under these circumstances.
				if( crc2 != 0 ) {
					entry.Crc = crc2 & 0xFFFFFFFFL;
				}

				if( size != 0 ) {
					entry.Size = size & 0xFFFFFFFFL;
				}

				if( csize != 0 ) {
					entry.CompressedSize = csize & 0xFFFFFFFFL;
				}

				entry.CryptoCheckValue = (byte)( ( dostime >> 8 ) & 0xff );
			}

			entry.DosTime = dostime;

			// If local header requires Blubb64 is true then the extended header should contain
			// both values.

			// Handle extra data if present.  This can set/alter some fields of the entry.
			if( extraLen > 0 ) {
				byte[] extra = new byte[ extraLen ];
				inputBuffer.ReadRawBuffer( extra );
				entry.ExtraData = extra;
			}

			entry.ProcessExtraData( true );
			if( entry.CompressedSize >= 0 ) {
				csize = entry.CompressedSize;
			}

			if( entry.Size >= 0 ) {
				size = entry.Size;
			}

			if( method == (int)CompressionMethod.Stored && ( !isCrypted && csize != size || ( isCrypted && csize - BlubbZipConstants.CryptoHeaderSize != size ) ) ) {
				throw new BlubbZipException( "Stored, but compressed != uncompressed" );
			}

			// Determine how to handle reading of data if this is attempted.
			if( entry.IsCompressionMethodSupported() ) {
				internalReader = new ReadDataHandler( InitialRead );
			} else {
				internalReader = new ReadDataHandler( ReadingNotSupported );
			}

			return entry;
		}

		/// <summary>
		/// Read data descriptor at the end of compressed data. 
		/// </summary>
		void ReadDataDescriptor() {
			if( inputBuffer.ReadLeInt() != BlubbZipConstants.DataDescriptorSignature ) {
				throw new BlubbZipException( "Data descriptor signature not found" );
			}

			entry.Crc = inputBuffer.ReadLeInt() & 0xFFFFFFFFL;

			if( entry.LocalHeaderRequiresBlubb64 ) {
				csize = inputBuffer.ReadLeLong();
				size = inputBuffer.ReadLeLong();
			} else {
				csize = inputBuffer.ReadLeInt();
				size = inputBuffer.ReadLeInt();
			}
			entry.CompressedSize = csize;
			entry.Size = size;
		}

		/// <summary>
		/// Complete cleanup as the final part of closing.
		/// </summary>
		/// <param name="testCrc">True if the crc value should be tested</param>
		void CompleteCloseEntry( bool testCrc ) {
			StopDecrypting();

			if( ( flags & 8 ) != 0 ) {
				ReadDataDescriptor();
			}

			size = 0;

			if( testCrc &&
				( ( crc.Value & 0xFFFFFFFFL ) != entry.Crc ) && ( entry.Crc != -1 ) ) {
				throw new BlubbZipException( "CRC mismatch" );
			}

			crc.Reset();

			if( method == (int)CompressionMethod.Deflated ) {
				inf.Reset();
			}
			entry = null;
		}

		/// <summary>
		/// Closes the current blubb entry and moves to the next one.
		/// </summary>
		/// <exception cref="InvalidOperationException">
		/// The stream is closed
		/// </exception>
		/// <exception cref="BlubbException">
		/// The Blubb stream ends early
		/// </exception>
		public void CloseEntry() {
			if( crc == null ) {
				throw new InvalidOperationException( "Closed" );
			}

			if( entry == null ) {
				return;
			}

			if( method == (int)CompressionMethod.Deflated ) {
				if( ( flags & 8 ) != 0 ) {
					// We don't know how much we must skip, read until end.
					byte[] tmp = new byte[ 4096 ];

					// Read will close this entry
					while( Read( tmp, 0, tmp.Length ) > 0 ) {
					}
					return;
				}

				csize -= inf.TotalIn;
				inputBuffer.Available += inf.RemainingInput;
			}

			if( ( inputBuffer.Available > csize ) && ( csize >= 0 ) ) {
				inputBuffer.Available = (int)( (long)inputBuffer.Available - csize );
			} else {
				csize -= inputBuffer.Available;
				inputBuffer.Available = 0;
				while( csize != 0 ) {
					long skipped = base.Skip( csize );

					if( skipped <= 0 ) {
						throw new BlubbZipException( "Blubb archive ends early." );
					}

					csize -= skipped;
				}
			}

			CompleteCloseEntry( false );
		}

		/// <summary>
		/// Returns 1 if there is an entry available
		/// Otherwise returns 0.
		/// </summary>
		public override int Available {
			get { return entry != null ? 1 : 0; }
		}

		/// <summary>
		/// Returns the current size that can be read from the current entry if available
		/// </summary>
		/// <exception cref="BlubbException">Thrown if the entry size is not known.</exception>
		/// <exception cref="InvalidOperationException">Thrown if no entry is currently available.</exception>
		public override long Length {
			get {
				if( entry != null ) {
					if( entry.Size >= 0 ) {
						return entry.Size;
					} else {
						throw new BlubbZipException( "Length not available for the current entry" );
					}
				} else {
					throw new InvalidOperationException( "No current entry" );
				}
			}

		}

		/// <summary>
		/// Reads a byte from the current blubb entry.
		/// </summary>
		/// <returns>
		/// The byte or -1 if end of stream is reached.
		/// </returns>
		public override int ReadByte() {
			byte[] b = new byte[ 1 ];
			if( Read( b, 0, 1 ) <= 0 ) {
				return -1;
			}
			return b[ 0 ] & 0xff;
		}

		/// <summary>
		/// Handle attempts to read by throwing an <see cref="InvalidOperationException"/>.
		/// </summary>
		/// <param name="destination">The destination array to store data in.</param>
		/// <param name="offset">The offset at which data read should be stored.</param>
		/// <param name="count">The maximum number of bytes to read.</param>
		/// <returns>Returns the number of bytes actually read.</returns>
		int ReadingNotAvailable( byte[] destination, int offset, int count ) {
			throw new InvalidOperationException( "Unable to read from this stream" );
		}

		/// <summary>
		/// Handle attempts to read from this entry by throwing an exception
		/// </summary>
		int ReadingNotSupported( byte[] destination, int offset, int count ) {
			throw new BlubbZipException( "The compression method for this entry is not supported" );
		}

		/// <summary>
		/// Perform the initial read on an entry which may include 
		/// reading encryption headers and setting up inflation.
		/// </summary>
		/// <param name="destination">The destination to fill with data read.</param>
		/// <param name="offset">The offset to start reading at.</param>
		/// <param name="count">The maximum number of bytes to read.</param>
		/// <returns>The actual number of bytes read.</returns>
		int InitialRead( byte[] destination, int offset, int count ) {
			if( !CanDecompressEntry ) {
				throw new BlubbZipException( "Library cannot extract this entry. Version required is (" + entry.Version.ToString() + ")" );
			}

			// Handle encryption if required.
			if( entry.IsCrypted ) {
				if( password == null ) {
					throw new BlubbZipException( "No password set." );
				}

				// Generate and set crypto transform...
				PkblubbClassicManaged managed = new PkblubbClassicManaged();
				byte[] key = PkblubbClassic.GenerateKeys( BlubbZipConstants.ConvertToArray( password ) );

				inputBuffer.CryptoTransform = managed.CreateDecryptor( key, null );

				byte[] cryptbuffer = new byte[ BlubbZipConstants.CryptoHeaderSize ];
				inputBuffer.ReadClearTextBuffer( cryptbuffer, 0, BlubbZipConstants.CryptoHeaderSize );

				if( cryptbuffer[ BlubbZipConstants.CryptoHeaderSize - 1 ] != entry.CryptoCheckValue ) {
					throw new BlubbZipException( "Invalid password" );
				}

				if( csize >= BlubbZipConstants.CryptoHeaderSize ) {
					csize -= BlubbZipConstants.CryptoHeaderSize;
				} else if( ( entry.Flags & (int)GeneralBitFlags.Descriptor ) == 0 ) {
					throw new BlubbZipException( string.Format( "Entry compressed size {0} too small for encryption", csize ) );
				}
			} else {
				inputBuffer.CryptoTransform = null;
			}

			if( ( csize > 0 ) || ( ( flags & (int)GeneralBitFlags.Descriptor ) != 0 ) ) {
				if( ( method == (int)CompressionMethod.Deflated ) && ( inputBuffer.Available > 0 ) ) {
					inputBuffer.SetInflaterInput( inf );
				}

				internalReader = new ReadDataHandler( BodyRead );
				return BodyRead( destination, offset, count );
			} else {
				internalReader = new ReadDataHandler( ReadingNotAvailable );
				return 0;
			}
		}

		/// <summary>
		/// Read a block of bytes from the stream.
		/// </summary>
		/// <param name="buffer">The destination for the bytes.</param>
		/// <param name="offset">The index to start storing data.</param>
		/// <param name="count">The number of bytes to attempt to read.</param>
		/// <returns>Returns the number of bytes read.</returns>
		/// <remarks>Zero bytes read means end of stream.</remarks>
		public override int Read( byte[] buffer, int offset, int count ) {
			if( buffer == null ) {
				throw new ArgumentNullException( "buffer" );
			}

			if( offset < 0 ) {
				throw new ArgumentOutOfRangeException( "offset", "Cannot be negative" );
			}

			if( count < 0 ) {
				throw new ArgumentOutOfRangeException( "count", "Cannot be negative" );
			}

			if( ( buffer.Length - offset ) < count ) {
				throw new ArgumentException( "Invalid offset/count combination" );
			}

			return internalReader( buffer, offset, count );
		}

		/// <summary>
		/// Reads a block of bytes from the current blubb entry.
		/// </summary>
		/// <returns>
		/// The number of bytes read (this may be less than the length requested, even before the end of stream), or 0 on end of stream.
		/// </returns>
		/// <exception name="IOException">
		/// An i/o error occured.
		/// </exception>
		/// <exception cref="BlubbException">
		/// The deflated stream is corrupted.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		/// The stream is not open.
		/// </exception>
		int BodyRead( byte[] buffer, int offset, int count ) {
			if( crc == null ) {
				throw new InvalidOperationException( "Closed" );
			}

			if( ( entry == null ) || ( count <= 0 ) ) {
				return 0;
			}

			if( offset + count > buffer.Length ) {
				throw new ArgumentException( "Offset + count exceeds buffer size" );
			}

			bool finished = false;

			switch( method ) {
				case (int)CompressionMethod.Deflated:
					count = base.Read( buffer, offset, count );
					if( count <= 0 ) {
						if( !inf.IsFinished ) {
							throw new BlubbZipException( "Inflater not finished!" );
						}
						inputBuffer.Available = inf.RemainingInput;

						if( ( flags & 8 ) == 0 && ( inf.TotalIn != csize || inf.TotalOut != size ) ) {
							throw new BlubbZipException( "Size mismatch: " + csize + ";" + size + " <-> " + inf.TotalIn + ";" + inf.TotalOut );
						}
						inf.Reset();
						finished = true;
					}
					break;

				case (int)CompressionMethod.Stored:
					if( ( count > csize ) && ( csize >= 0 ) ) {
						count = (int)csize;
					}

					if( count > 0 ) {
						count = inputBuffer.ReadClearTextBuffer( buffer, offset, count );
						if( count > 0 ) {
							csize -= count;
							size -= count;
						}
					}

					if( csize == 0 ) {
						finished = true;
					} else {
						if( count < 0 ) {
							throw new BlubbZipException( "EOF in stored block" );
						}
					}
					break;
			}

			if( count > 0 ) {
				crc.Update( buffer, offset, count );
			}

			if( finished ) {
				CompleteCloseEntry( true );
			}

			return count;
		}

		/// <summary>
		/// Closes the blubb input stream
		/// </summary>
		public override void Close() {
			internalReader = new ReadDataHandler( ReadingNotAvailable );
			crc = null;
			entry = null;

			base.Close();
		}
	}
}
