using System;
using System.IO;
using System.Collections;
using System.Text;

using GodLesZ.Library.BlubbZip.Checksums;
using GodLesZ.Library.BlubbZip.Blubb.Compression;
using GodLesZ.Library.BlubbZip.Blubb.Compression.Streams;

namespace GodLesZ.Library.BlubbZip.Blubb {

	public class BlubbZipOutputStream : DeflaterOutputStream {
		/// <summary>
		/// The entries for the archive.
		/// </summary>
		ArrayList entries = new ArrayList();

		/// <summary>
		/// Used to track the crc of data added to entries.
		/// </summary>
		Crc32 crc = new Crc32();

		/// <summary>
		/// The current entry being added.
		/// </summary>
		BlubbZipEntry curEntry;

		int defaultCompressionLevel = Deflater.DEFAULT_COMPRESSION;

		CompressionMethod curMethod = CompressionMethod.Deflated;

		/// <summary>
		/// Used to track the size of data for an entry during writing.
		/// </summary>
		long size;

		/// <summary>
		/// Offset to be recorded for each entry in the central header.
		/// </summary>
		long offset;

		/// <summary>
		/// Comment for the entire archive recorded in central header.
		/// </summary>
		byte[] blubbComment = new byte[ 0 ];

		/// <summary>
		/// Flag indicating that header patching is required for the current entry.
		/// </summary>
		bool patchEntryHeader;

		/// <summary>
		/// Position to patch crc
		/// </summary>
		long crcPatchPos = -1;

		/// <summary>
		/// Position to patch size.
		/// </summary>
		long sizePatchPos = -1;

		// Default is dynamic which is not backwards compatible and can cause problems
		// with XP's built in compression which cant read Blubb64 archives.
		// However it does avoid the situation were a large file is added and cannot be completed correctly.
		// NOTE: Setting the size for entries before they are added is the best solution!
		UseBlubb64 useBlubb64_ = UseBlubb64.Dynamic;




		/// <summary>
		/// Creates a new Blubb output stream, writing a blubb archive.
		/// </summary>
		/// <param name="baseOutputStream">
		/// The output stream to which the archive contents are written.
		/// </param>
		public BlubbZipOutputStream( Stream baseOutputStream )
			: base( baseOutputStream, new Deflater( Deflater.DEFAULT_COMPRESSION, true ) ) {
		}

		/// <summary>
		/// Gets a flag value of true if the central header has been added for this archive; false if it has not been added.
		/// </summary>
		/// <remarks>No further entries can be added once this has been done.</remarks>
		public bool IsFinished {
			get { return entries == null; }
		}

		/// <summary>
		/// Set the blubb file comment.
		/// </summary>
		/// <param name="comment">
		/// The comment text for the entire archive.
		/// </param>
		/// <exception name ="ArgumentOutOfRangeException">
		/// The converted comment is longer than 0xffff bytes.
		/// </exception>
		public void SetComment( string comment ) {
			// TODO: Its not yet clear how to handle unicode comments here.
			byte[] commentBytes = BlubbZipConstants.ConvertToArray( comment );
			if( commentBytes.Length > 0xffff ) {
				throw new ArgumentOutOfRangeException( "comment" );
			}
			blubbComment = commentBytes;
		}

		/// <summary>
		/// Sets the compression level.  The new level will be activated
		/// immediately.
		/// </summary>
		/// <param name="level">The new compression level (1 to 9).</param>
		/// <exception cref="ArgumentOutOfRangeException">
		/// Level specified is not supported.
		/// </exception>
		/// <see cref="GodLesZ.Library.BlubbZip.Blubb.Compression.Deflater"/>
		public void SetLevel( int level ) {
			deflater_.SetLevel( level );
			defaultCompressionLevel = level;
		}

		/// <summary>
		/// Get the current deflater compression level
		/// </summary>
		/// <returns>The current compression level</returns>
		public int GetLevel() {
			return deflater_.GetLevel();
		}

		/// <summary>
		/// Get / set a value indicating how Blubb64 Extension usage is determined when adding entries.
		/// </summary>
		public UseBlubb64 UseBlubb64 {
			get { return useBlubb64_; }
			set { useBlubb64_ = value; }
		}

		/// <summary>
		/// Write an unsigned short in little endian byte order.
		/// </summary>
		private void WriteLeShort( int value ) {
			unchecked {
				baseOutputStream_.WriteByte( (byte)( value & 0xff ) );
				baseOutputStream_.WriteByte( (byte)( ( value >> 8 ) & 0xff ) );
			}
		}

		/// <summary>
		/// Write an int in little endian byte order.
		/// </summary>
		private void WriteLeInt( int value ) {
			unchecked {
				WriteLeShort( value );
				WriteLeShort( value >> 16 );
			}
		}

		/// <summary>
		/// Write an int in little endian byte order.
		/// </summary>
		private void WriteLeLong( long value ) {
			unchecked {
				WriteLeInt( (int)value );
				WriteLeInt( (int)( value >> 32 ) );
			}
		}

		/// <summary>
		/// Starts a new Blubb entry. It automatically closes the previous
		/// entry if present.
		/// All entry elements bar name are optional, but must be correct if present.
		/// If the compression method is stored and the output is not patchable
		/// the compression for that entry is automatically changed to deflate level 0
		/// </summary>
		/// <param name="entry">
		/// the entry.
		/// </param>
		/// <exception cref="System.ArgumentNullException">
		/// if entry passed is null.
		/// </exception>
		/// <exception cref="System.IO.IOException">
		/// if an I/O error occured.
		/// </exception>
		/// <exception cref="System.InvalidOperationException">
		/// if stream was finished
		/// </exception>
		/// <exception cref="BlubbException">
		/// Too many entries in the Blubb file<br/>
		/// Entry name is too long<br/>
		/// Finish has already been called<br/>
		/// </exception>
		public void PutNextEntry( BlubbZipEntry entry ) {
			if( entry == null ) 
				throw new ArgumentNullException( "entry" );

			if( entries == null ) 
				throw new InvalidOperationException( "BlubbOutputStream was finished" );

			if( curEntry != null ) 
				CloseEntry();

			if( entries.Count == int.MaxValue ) 
				throw new BlubbZipException( "Too many entries for Blubb file" );

			CompressionMethod method = entry.CompressionMethod;
			int compressionLevel = defaultCompressionLevel;

			// Clear flags that the library manages internally
			entry.Flags &= (int)GeneralBitFlags.UnicodeText;
			patchEntryHeader = false;

			bool headerInfoAvailable;

			// No need to compress - definitely no data.
			if( entry.Size == 0 ) {
				entry.CompressedSize = entry.Size;
				entry.Crc = 0;
				method = CompressionMethod.Stored;
				headerInfoAvailable = true;
			} else {
				headerInfoAvailable = ( entry.Size >= 0 ) && entry.HasCrc;

				// Switch to deflation if storing isnt possible.
				if( method == CompressionMethod.Stored ) {
					if( !headerInfoAvailable ) {
						if( !CanPatchEntries ) {
							// Can't patch entries so storing is not possible.
							method = CompressionMethod.Deflated;
							compressionLevel = 0;
						}
					} else {
						// entry.size must be > 0
						entry.CompressedSize = entry.Size;
						headerInfoAvailable = entry.HasCrc;
					}
				}
			}

			if( headerInfoAvailable == false ) {
				if( CanPatchEntries == false ) {
					// Only way to record size and compressed size is to append a data descriptor
					// after compressed data.

					// Stored entries of this form have already been converted to deflating.
					entry.Flags |= 8;
				} else {
					patchEntryHeader = true;
				}
			}

			if( Password != null ) {
				entry.IsCrypted = true;
				if( entry.Crc < 0 ) {
					// Need to append a data descriptor as the crc isnt available for use
					// with encryption, the date is used instead.  Setting the flag
					// indicates this to the decompressor.
					entry.Flags |= 8;
				}
			}

			entry.Offset = offset;
			entry.CompressionMethod = (CompressionMethod)method;

			curMethod = method;
			sizePatchPos = -1;

			if( useBlubb64_ == UseBlubb64.On || ( entry.Size < 0 && useBlubb64_ == UseBlubb64.Dynamic ) )
				entry.ForceBlubb64();

			// Write the local file header
			WriteLeInt( BlubbZipConstants.LocalHeaderSignature );

			WriteLeShort( entry.Version );
			WriteLeShort( entry.Flags );
			WriteLeShort( (byte)method );
			WriteLeInt( (int)entry.DosTime );

			// TODO: Refactor header writing.  Its done in several places.
			if( headerInfoAvailable == true ) {
				WriteLeInt( (int)entry.Crc );
				if( entry.LocalHeaderRequiresBlubb64 ) {
					WriteLeInt( -1 );
					WriteLeInt( -1 );
				} else {
					WriteLeInt( entry.IsCrypted ? (int)entry.CompressedSize + BlubbZipConstants.CryptoHeaderSize : (int)entry.CompressedSize );
					WriteLeInt( (int)entry.Size );
				}
			} else {
				if( patchEntryHeader == true ) {
					crcPatchPos = baseOutputStream_.Position;
				}
				WriteLeInt( 0 );	// Crc

				if( patchEntryHeader ) {
					sizePatchPos = baseOutputStream_.Position;
				}

				// For local header both sizes appear in Blubb64 Extended Information
				if( entry.LocalHeaderRequiresBlubb64 || patchEntryHeader ) {
					WriteLeInt( -1 );
					WriteLeInt( -1 );
				} else {
					WriteLeInt( 0 );	// Compressed size
					WriteLeInt( 0 );	// Uncompressed size
				}
			}

			byte[] name = BlubbZipConstants.ConvertToArray( entry.Flags, entry.Name );

			if( name.Length > 0xFFFF )
				throw new BlubbZipException( "Entry name too long." );

			BlubbZipExtraData ed = new BlubbZipExtraData( entry.ExtraData );

			if( entry.LocalHeaderRequiresBlubb64 ) {
				ed.StartNewEntry();
				if( headerInfoAvailable ) {
					ed.AddLeLong( entry.Size );
					ed.AddLeLong( entry.CompressedSize );
				} else {
					ed.AddLeLong( -1 );
					ed.AddLeLong( -1 );
				}
				ed.AddNewEntry( 1 );

				if( !ed.Find( 1 ) ) {
					throw new BlubbZipException( "Internal error cant find extra data" );
				}

				if( patchEntryHeader ) {
					sizePatchPos = ed.CurrentReadIndex;
				}
			} else {
				ed.Delete( 1 );
			}

			byte[] extra = ed.GetEntryData();

			WriteLeShort( name.Length );
			WriteLeShort( extra.Length );

			if( name.Length > 0 ) {
				baseOutputStream_.Write( name, 0, name.Length );
			}

			if( entry.LocalHeaderRequiresBlubb64 && patchEntryHeader ) {
				sizePatchPos += baseOutputStream_.Position;
			}

			if( extra.Length > 0 ) {
				baseOutputStream_.Write( extra, 0, extra.Length );
			}

			offset += BlubbZipConstants.LocalHeaderBaseSize + name.Length + extra.Length;

			// Activate the entry.
			curEntry = entry;
			crc.Reset();
			if( method == CompressionMethod.Deflated ) {
				deflater_.Reset();
				deflater_.SetLevel( compressionLevel );
			}
			size = 0;

			if( entry.IsCrypted == true ) {
				if( entry.Crc < 0 ) { // so testing Blubb will says its ok
					WriteEncryptionHeader( entry.DosTime << 16 );
				} else {
					WriteEncryptionHeader( entry.Crc );
				}
			}
		}

		/// <summary>
		/// Closes the current entry, updating header and footer information as required
		/// </summary>
		/// <exception cref="System.IO.IOException">
		/// An I/O error occurs.
		/// </exception>
		/// <exception cref="System.InvalidOperationException">
		/// No entry is active.
		/// </exception>
		public void CloseEntry() {
			if( curEntry == null ) {
				throw new InvalidOperationException( "No open entry" );
			}

			long csize = size;

			// First finish the deflater, if appropriate
			if( curMethod == CompressionMethod.Deflated ) {
				if( size > 0 ) {
					base.Finish();
					csize = deflater_.TotalOut;
				} else {
					deflater_.Reset();
				}
			}

			if( curEntry.Size < 0 ) {
				curEntry.Size = size;
			} else if( curEntry.Size != size ) {
				throw new BlubbZipException( "size was " + size + ", but I expected " + curEntry.Size );
			}

			if( curEntry.CompressedSize < 0 ) {
				curEntry.CompressedSize = csize;
			} else if( curEntry.CompressedSize != csize ) {
				throw new BlubbZipException( "compressed size was " + csize + ", but I expected " + curEntry.CompressedSize );
			}

			if( curEntry.Crc < 0 ) {
				curEntry.Crc = crc.Value;
			} else if( curEntry.Crc != crc.Value ) {
				throw new BlubbZipException( "crc was " + crc.Value + ", but I expected " + curEntry.Crc );
			}

			offset += csize;

			if( curEntry.IsCrypted == true ) {
				curEntry.CompressedSize += BlubbZipConstants.CryptoHeaderSize;
			}

			// Patch the header if possible
			if( patchEntryHeader == true ) {
				patchEntryHeader = false;

				long curPos = baseOutputStream_.Position;
				baseOutputStream_.Seek( crcPatchPos, SeekOrigin.Begin );
				WriteLeInt( (int)curEntry.Crc );

				if( curEntry.LocalHeaderRequiresBlubb64 ) {

					if( sizePatchPos == -1 ) {
						throw new BlubbZipException( "Entry requires blubb64 but this has been turned off" );
					}

					baseOutputStream_.Seek( sizePatchPos, SeekOrigin.Begin );
					WriteLeLong( curEntry.Size );
					WriteLeLong( curEntry.CompressedSize );
				} else {
					WriteLeInt( (int)curEntry.CompressedSize );
					WriteLeInt( (int)curEntry.Size );
				}
				baseOutputStream_.Seek( curPos, SeekOrigin.Begin );
			}

			// Add data descriptor if flagged as required
			if( ( curEntry.Flags & 8 ) != 0 ) {
				WriteLeInt( BlubbZipConstants.DataDescriptorSignature );
				WriteLeInt( unchecked( (int)curEntry.Crc ) );

				if( curEntry.LocalHeaderRequiresBlubb64 ) {
					WriteLeLong( curEntry.CompressedSize );
					WriteLeLong( curEntry.Size );
					offset += BlubbZipConstants.Blubb64DataDescriptorSize;
				} else {
					WriteLeInt( (int)curEntry.CompressedSize );
					WriteLeInt( (int)curEntry.Size );
					offset += BlubbZipConstants.DataDescriptorSize;
				}
			}

			entries.Add( curEntry );
			curEntry = null;
		}

		void WriteEncryptionHeader( long crcValue ) {
			offset += BlubbZipConstants.CryptoHeaderSize;

			InitializePassword( Password );

			byte[] cryptBuffer = new byte[ BlubbZipConstants.CryptoHeaderSize ];
			Random rnd = new Random();
			rnd.NextBytes( cryptBuffer );
			cryptBuffer[ 11 ] = (byte)( crcValue >> 24 );

			EncryptBlock( cryptBuffer, 0, cryptBuffer.Length );
			baseOutputStream_.Write( cryptBuffer, 0, cryptBuffer.Length );
		}

		/// <summary>
		/// Writes the given buffer to the current entry.
		/// </summary>
		/// <param name="buffer">The buffer containing data to write.</param>
		/// <param name="offset">The offset of the first byte to write.</param>
		/// <param name="count">The number of bytes to write.</param>
		/// <exception cref="BlubbException">Archive size is invalid</exception>
		/// <exception cref="System.InvalidOperationException">No entry is active.</exception>
		public override void Write( byte[] buffer, int offset, int count ) {
			if( curEntry == null )
				throw new InvalidOperationException( "No open entry." );

			if( buffer == null )
				throw new ArgumentNullException( "buffer" );

			if( offset < 0 )
				throw new ArgumentOutOfRangeException( "offset", "Cannot be negative" );

			if( count < 0 )
				throw new ArgumentOutOfRangeException( "count", "Cannot be negative" );

			if( ( buffer.Length - offset ) < count )
				throw new ArgumentException( "Invalid offset/count combination" );

			crc.Update( buffer, offset, count );
			size += count;

			switch( curMethod ) {
				case CompressionMethod.Deflated:
					base.Write( buffer, offset, count );
					break;

				case CompressionMethod.Stored:
					if( Password != null ) {
						CopyAndEncrypt( buffer, offset, count );
					} else {
						baseOutputStream_.Write( buffer, offset, count );
					}
					break;
			}
		}

		void CopyAndEncrypt( byte[] buffer, int offset, int count ) {
			const int CopyBufferSize = 4096;
			byte[] localBuffer = new byte[ CopyBufferSize ];
			while( count > 0 ) {
				int bufferCount = ( count < CopyBufferSize ) ? count : CopyBufferSize;

				Array.Copy( buffer, offset, localBuffer, 0, bufferCount );
				EncryptBlock( localBuffer, 0, bufferCount );
				baseOutputStream_.Write( localBuffer, 0, bufferCount );
				count -= bufferCount;
				offset += bufferCount;
			}
		}

		/// <summary>
		/// Finishes the stream.  This will write the central directory at the
		/// end of the blubb file and flush the stream.
		/// </summary>
		/// <remarks>
		/// This is automatically called when the stream is closed.
		/// </remarks>
		/// <exception cref="System.IO.IOException">
		/// An I/O error occurs.
		/// </exception>
		/// <exception cref="BlubbException">
		/// Comment exceeds the maximum length<br/>
		/// Entry name exceeds the maximum length
		/// </exception>
		public override void Finish() {
			if( entries == null ) {
				return;
			}

			if( curEntry != null ) {
				CloseEntry();
			}

			long numEntries = entries.Count;
			long sizeEntries = 0;

			foreach( BlubbZipEntry entry in entries ) {
				WriteLeInt( BlubbZipConstants.CentralHeaderSignature );
				WriteLeShort( BlubbZipConstants.VersionMadeBy );
				WriteLeShort( entry.Version );
				WriteLeShort( entry.Flags );
				WriteLeShort( (short)entry.CompressionMethod );
				WriteLeInt( (int)entry.DosTime );
				WriteLeInt( (int)entry.Crc );

				if( entry.IsBlubb64Forced() ||
					( entry.CompressedSize >= uint.MaxValue ) ) {
					WriteLeInt( -1 );
				} else {
					WriteLeInt( (int)entry.CompressedSize );
				}

				if( entry.IsBlubb64Forced() ||
					( entry.Size >= uint.MaxValue ) ) {
					WriteLeInt( -1 );
				} else {
					WriteLeInt( (int)entry.Size );
				}

				byte[] name = BlubbZipConstants.ConvertToArray( entry.Flags, entry.Name );

				if( name.Length > 0xffff ) {
					throw new BlubbZipException( "Name too long." );
				}

				BlubbZipExtraData ed = new BlubbZipExtraData( entry.ExtraData );

				if( entry.CentralHeaderRequiresBlubb64 ) {
					ed.StartNewEntry();
					if( entry.IsBlubb64Forced() ||
						( entry.Size >= 0xffffffff ) ) {
						ed.AddLeLong( entry.Size );
					}

					if( entry.IsBlubb64Forced() ||
						( entry.CompressedSize >= 0xffffffff ) ) {
						ed.AddLeLong( entry.CompressedSize );
					}

					if( entry.Offset >= 0xffffffff ) {
						ed.AddLeLong( entry.Offset );
					}

					ed.AddNewEntry( 1 );
				} else {
					ed.Delete( 1 );
				}

				byte[] extra = ed.GetEntryData();

				byte[] entryComment =
					( entry.Comment != null ) ?
					BlubbZipConstants.ConvertToArray( entry.Flags, entry.Comment ) :
					new byte[ 0 ];

				if( entryComment.Length > 0xffff ) {
					throw new BlubbZipException( "Comment too long." );
				}

				WriteLeShort( name.Length );
				WriteLeShort( extra.Length );
				WriteLeShort( entryComment.Length );
				WriteLeShort( 0 );	// disk number
				WriteLeShort( 0 );	// internal file attributes
				// external file attributes

				if( entry.ExternalFileAttributes != -1 ) {
					WriteLeInt( entry.ExternalFileAttributes );
				} else {
					if( entry.IsDirectory ) {
						WriteLeInt( 16 );
					} else {
						WriteLeInt( 0 );
					}
				}

				if( entry.Offset >= uint.MaxValue ) {
					WriteLeInt( -1 );
				} else {
					WriteLeInt( (int)entry.Offset );
				}

				if( name.Length > 0 ) {
					baseOutputStream_.Write( name, 0, name.Length );
				}

				if( extra.Length > 0 ) {
					baseOutputStream_.Write( extra, 0, extra.Length );
				}

				if( entryComment.Length > 0 ) {
					baseOutputStream_.Write( entryComment, 0, entryComment.Length );
				}

				sizeEntries += BlubbZipConstants.CentralHeaderBaseSize + name.Length + extra.Length + entryComment.Length;
			}

			using( BlubbZipHelperStream zhs = new BlubbZipHelperStream( baseOutputStream_ ) ) {
				zhs.WriteEndOfCentralDirectory( numEntries, sizeEntries, offset, blubbComment );
			}

			entries = null;
		}

	}
}
