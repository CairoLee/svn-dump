using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Globalization;

using System.Security.Cryptography;
using GodLesZ.Library.BlubbZip.Encryption;

using GodLesZ.Library.BlubbZip.Core;
using GodLesZ.Library.BlubbZip.Checksums;
using GodLesZ.Library.BlubbZip.Blubb.Compression.Streams;
using GodLesZ.Library.BlubbZip.Blubb.Compression;

namespace GodLesZ.Library.BlubbZip.Blubb {
	// Keys Required Event Args
	/// <summary>
	/// Arguments used with KeysRequiredEvent
	/// </summary>
	public class KeysRequiredEventArgs : EventArgs {
		// Constructors
		/// <summary>
		/// Initialise a new instance of <see cref="KeysRequiredEventArgs"></see>
		/// </summary>
		/// <param name="name">The name of the file for which keys are required.</param>
		public KeysRequiredEventArgs( string name ) {
			fileName = name;
		}

		/// <summary>
		/// Initialise a new instance of <see cref="KeysRequiredEventArgs"></see>
		/// </summary>
		/// <param name="name">The name of the file for which keys are required.</param>
		/// <param name="keyValue">The current key value.</param>
		public KeysRequiredEventArgs( string name, byte[] keyValue ) {
			fileName = name;
			key = keyValue;
		}


		// Properties
		/// <summary>
		/// Gets the name of the file for which keys are required.
		/// </summary>
		public string FileName {
			get { return fileName; }
		}

		/// <summary>
		/// Gets or sets the key value
		/// </summary>
		public byte[] Key {
			get { return key; }
			set { key = value; }
		}


		// Instance Fields
		string fileName;
		byte[] key;

	}


	// Test Definitions
	/// <summary>
	/// The strategy to apply to testing.
	/// </summary>
	public enum TestStrategy {
		/// <summary>
		/// Find the first error only.
		/// </summary>
		FindFirstError,
		/// <summary>
		/// Find all possible errors.
		/// </summary>
		FindAllErrors,
	}

	/// <summary>
	/// The operation in progress reported by a <see cref="BlubbTestResultHandler"/> during testing.
	/// </summary>
	/// <seealso cref="BlubbFile.TestArchive(bool)">TestArchive</seealso>
	public enum TestOperation {
		/// <summary>
		/// Setting up testing.
		/// </summary>
		Initialising,

		/// <summary>
		/// Testing an individual entries header
		/// </summary>
		EntryHeader,

		/// <summary>
		/// Testing an individual entries data
		/// </summary>
		EntryData,

		/// <summary>
		/// Testing an individual entry has completed.
		/// </summary>
		EntryComplete,

		/// <summary>
		/// Running miscellaneous tests
		/// </summary>
		MiscellaneousTests,

		/// <summary>
		/// Testing is complete
		/// </summary>
		Complete,
	}

	/// <summary>
	/// Status returned returned by <see cref="BlubbTestResultHandler"/> during testing.
	/// </summary>
	/// <seealso cref="BlubbFile.TestArchive(bool)">TestArchive</seealso>
	public class TestStatus {
		// Constructors
		/// <summary>
		/// Initialise a new instance of <see cref="TestStatus"/>
		/// </summary>
		/// <param name="file">The <see cref="BlubbFile"/> this status applies to.</param>
		public TestStatus( BlubbZipFile file ) {
			file_ = file;
		}


		// Properties

		/// <summary>
		/// Get the current <see cref="TestOperation"/> in progress.
		/// </summary>
		public TestOperation Operation {
			get { return operation_; }
		}

		/// <summary>
		/// Get the <see cref="BlubbFile"/> this status is applicable to.
		/// </summary>
		public BlubbZipFile File {
			get { return file_; }
		}

		/// <summary>
		/// Get the current/last entry tested.
		/// </summary>
		public BlubbZipEntry Entry {
			get { return entry_; }
		}

		/// <summary>
		/// Get the number of errors detected so far.
		/// </summary>
		public int ErrorCount {
			get { return errorCount_; }
		}

		/// <summary>
		/// Get the number of bytes tested so far for the current entry.
		/// </summary>
		public long BytesTested {
			get { return bytesTested_; }
		}

		/// <summary>
		/// Get a value indicating wether the last entry test was valid.
		/// </summary>
		public bool EntryValid {
			get { return entryValid_; }
		}


		// Internal API
		internal void AddError() {
			errorCount_++;
			entryValid_ = false;
		}

		internal void SetOperation( TestOperation operation ) {
			operation_ = operation;
		}

		internal void SetEntry( BlubbZipEntry entry ) {
			entry_ = entry;
			entryValid_ = true;
			bytesTested_ = 0;
		}

		internal void SetBytesTested( long value ) {
			bytesTested_ = value;
		}


		// Instance Fields
		BlubbZipFile file_;
		BlubbZipEntry entry_;
		bool entryValid_;
		int errorCount_;
		long bytesTested_;
		TestOperation operation_;

	}

	/// <summary>
	/// Delegate invoked during <see cref="BlubbFile.TestArchive(bool, TestStrategy, BlubbTestResultHandler)">testing</see> if supplied indicating current progress and status.
	/// </summary>
	/// <remarks>If the message is non-null an error has occured.  If the message is null
	/// the operation as found in <see cref="TestStatus">status</see> has started.</remarks>
	public delegate void BlubbTestResultHandler( TestStatus status, string message );


	// Update Definitions
	/// <summary>
	/// The possible ways of <see cref="BlubbFile.CommitUpdate()">applying updates</see> to an archive.
	/// </summary>
	public enum FileUpdateMode {
		/// <summary>
		/// Perform all updates on temporary files ensuring that the original file is saved.
		/// </summary>
		Safe,
		/// <summary>
		/// Update the archive directly, which is faster but less safe.
		/// </summary>
		Direct,
	}



	public class BlubbZipFile : IEnumerable, IDisposable {
		// KeyHandling

		/// <summary>
		/// Delegate for handling keys/password setting during compresion/decompression.
		/// </summary>
		public delegate void KeysRequiredEventHandler( object sender, KeysRequiredEventArgs e );

		/// <summary>
		/// Event handler for handling encryption keys.
		/// </summary>
		public KeysRequiredEventHandler KeysRequired;

		/// <summary>
		/// Handles getting of encryption keys when required.
		/// </summary>
		/// <param name="fileName">The file for which encryption keys are required.</param>
		void OnKeysRequired( string fileName ) {
			if( KeysRequired != null ) {
				KeysRequiredEventArgs krea = new KeysRequiredEventArgs( fileName, key );
				KeysRequired( this, krea );
				key = krea.Key;
			}
		}

		/// <summary>
		/// Get/set the encryption key value.
		/// </summary>
		byte[] Key {
			get { return key; }
			set { key = value; }
		}

		/// <summary>
		/// Password to be used for encrypting/decrypting files.
		/// </summary>
		/// <remarks>Set to null if no password is required.</remarks>
		public string Password {
			set {
				if( ( value == null ) || ( value.Length == 0 ) ) {
					key = null;
				} else {
					key = PkblubbClassic.GenerateKeys( BlubbZipConstants.ConvertToArray( value ) );
				}
			}
		}

		/// <summary>
		/// underlying Filestream
		/// </summary>
		public Stream BaseStream {
			get { return baseStream_; }
		}

		/// <summary>
		/// Get a value indicating wether encryption keys are currently available.
		/// </summary>
		bool HaveKeys {
			get { return key != null; }
		}


		// Constructors
		/// <summary>
		/// Opens a Blubb file with the given name for reading.
		/// </summary>
		/// <param name="name">The name of the file to open.</param>
		/// <exception cref="ArgumentNullException">The argument supplied is null.</exception>
		/// <exception cref="IOException">
		/// An i/o error occurs
		/// </exception>
		/// <exception cref="BlubbException">
		/// The file doesn't contain a valid blubb archive.
		/// </exception>
		public BlubbZipFile( string name ) {
			if( name == null ) {
				throw new ArgumentNullException( "name" );
			}

			name_ = name;

			baseStream_ = File.OpenRead( name );
			isStreamOwner = true;

			try {
				ReadEntries();
			} catch {
				DisposeInternal( true );
				throw;
			}
		}

		/// <summary>
		/// Opens a Blubb file reading the given <see cref="FileStream"/>.
		/// </summary>
		/// <param name="file">The <see cref="FileStream"/> to read archive data from.</param>
		/// <exception cref="ArgumentNullException">The supplied argument is null.</exception>
		/// <exception cref="IOException">
		/// An i/o error occurs.
		/// </exception>
		/// <exception cref="BlubbException">
		/// The file doesn't contain a valid blubb archive.
		/// </exception>
		public BlubbZipFile( FileStream file ) {
			if( file == null ) {
				throw new ArgumentNullException( "file" );
			}

			if( !file.CanSeek ) {
				throw new ArgumentException( "Stream is not seekable", "file" );
			}

			baseStream_ = file;
			name_ = file.Name;
			isStreamOwner = true;

			try {
				ReadEntries();
			} catch {
				DisposeInternal( true );
				throw;
			}
		}

		/// <summary>
		/// Opens a Blubb file reading the given <see cref="Stream"/>.
		/// </summary>
		/// <param name="stream">The <see cref="Stream"/> to read archive data from.</param>
		/// <exception cref="IOException">
		/// An i/o error occurs
		/// </exception>
		/// <exception cref="BlubbException">
		/// The stream doesn't contain a valid blubb archive.<br/>
		/// </exception>
		/// <exception cref="ArgumentException">
		/// The <see cref="Stream">stream</see> doesnt support seeking.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// The <see cref="Stream">stream</see> argument is null.
		/// </exception>
		public BlubbZipFile( Stream stream ) {
			if( stream == null ) {
				throw new ArgumentNullException( "stream" );
			}

			if( !stream.CanSeek ) {
				throw new ArgumentException( "Stream is not seekable", "stream" );
			}

			baseStream_ = stream;
			isStreamOwner = true;

			if( baseStream_.Length > 0 ) {
				try {
					ReadEntries();
				} catch {
					DisposeInternal( true );
					throw;
				}
			} else {
				entries_ = new BlubbZipEntry[ 0 ];
				isNewArchive_ = true;
			}
		}

		/// <summary>
		/// Initialises a default <see cref="BlubbFile"/> instance with no entries and no file storage.
		/// </summary>
		internal BlubbZipFile() {
			entries_ = new BlubbZipEntry[ 0 ];
			isNewArchive_ = true;
		}



		// Destructors and Closing
		/// <summary>
		/// Finalize this instance.
		/// </summary>
		~BlubbZipFile() {
			Dispose( false );
		}

		/// <summary>
		/// Closes the BlubbFile.  If the stream is <see cref="IsStreamOwner">owned</see> then this also closes the underlying input stream.
		/// Once closed, no further instance methods should be called.
		/// </summary>
		/// <exception cref="System.IO.IOException">
		/// An i/o error occurs.
		/// </exception>
		public void Close() {
			DisposeInternal( true );
			GC.SuppressFinalize( this );
		}



		// Creators
		/// <summary>
		/// Create a new <see cref="BlubbFile"/> whose data will be stored in a file.
		/// </summary>
		/// <param name="fileName">The name of the archive to create.</param>
		/// <returns>Returns the newly created <see cref="BlubbFile"/></returns>
		/// <exception cref="ArgumentNullException"><paramref name="fileName"></paramref> is null</exception>
		public static BlubbZipFile Create( string fileName ) {
			if( fileName == null ) {
				throw new ArgumentNullException( "fileName" );
			}

			FileStream fs = File.Create( fileName );

			BlubbZipFile result = new BlubbZipFile();
			result.name_ = fileName;
			result.baseStream_ = fs;
			result.isStreamOwner = true;
			return result;
		}

		/// <summary>
		/// Create a new <see cref="BlubbFile"/> whose data will be stored on a stream.
		/// </summary>
		/// <param name="outStream">The stream providing data storage.</param>
		/// <returns>Returns the newly created <see cref="BlubbFile"/></returns>
		/// <exception cref="ArgumentNullException"><paramref name="outStream"> is null</paramref></exception>
		/// <exception cref="ArgumentException"><paramref name="outStream"> doesnt support writing.</paramref></exception>
		public static BlubbZipFile Create( Stream outStream ) {
			if( outStream == null ) {
				throw new ArgumentNullException( "outStream" );
			}

			if( !outStream.CanWrite ) {
				throw new ArgumentException( "Stream is not writeable", "outStream" );
			}

			if( !outStream.CanSeek ) {
				throw new ArgumentException( "Stream is not seekable", "outStream" );
			}

			BlubbZipFile result = new BlubbZipFile();
			result.baseStream_ = outStream;
			return result;
		}



		// Properties
		/// <summary>
		/// Get/set a flag indicating if the underlying stream is owned by the BlubbFile instance.
		/// If the flag is true then the stream will be closed when <see cref="Close">Close</see> is called.
		/// </summary>
		/// <remarks>
		/// The default value is true in all cases.
		/// </remarks>
		public bool IsStreamOwner {
			get { return isStreamOwner; }
			set { isStreamOwner = value; }
		}

		/// <summary>
		/// Get a value indicating wether
		/// this archive is embedded in another file or not.
		/// </summary>
		public bool IsEmbeddedArchive {
			get { return offsetOfFirstEntry > 0; }
		}

		/// <summary>
		/// Get a value indicating that this archive is a new one.
		/// </summary>
		public bool IsNewArchive {
			get { return isNewArchive_; }
		}

		/// <summary>
		/// Gets the comment for the blubb file.
		/// </summary>
		public string BlubbFileComment {
			get { return comment_; }
		}

		/// <summary>
		/// Gets the name of this blubb file.
		/// </summary>
		public string Name {
			get { return name_; }
		}

		/// <summary>
		/// Get the number of entries contained in this <see cref="BlubbFile"/>.
		/// </summary>
		public long Count {
			get { return entries_.Length; }
		}

		/// <summary>
		/// Indexer property for BlubbEntries
		/// </summary>
		[System.Runtime.CompilerServices.IndexerNameAttribute( "EntryByIndex" )]
		public BlubbZipEntry this[ int index ] {
			get { return (BlubbZipEntry)entries_[ index ].Clone(); }
		}



		// Input Handling
		/// <summary>
		/// Gets an enumerator for the Blubb entries in this Blubb file.
		/// </summary>
		/// <returns>Returns an <see cref="IEnumerator"/> for this archive.</returns>
		/// <exception cref="ObjectDisposedException">
		/// The Blubb file has been closed.
		/// </exception>
		public IEnumerator GetEnumerator() {
			if( isDisposed_ ) {
				throw new ObjectDisposedException( "BlubbFile" );
			}

			return new BlubbEntryEnumerator( entries_ );
		}

		/// <summary>
		/// Return the index of the entry with a matching name
		/// </summary>
		/// <param name="name">Entry name to find</param>
		/// <param name="ignoreCase">If true the comparison is case insensitive</param>
		/// <returns>The index position of the matching entry or -1 if not found</returns>
		/// <exception cref="ObjectDisposedException">
		/// The Blubb file has been closed.
		/// </exception>
		public int FindEntry( string name, bool ignoreCase ) {
			if( isDisposed_ ) {
				throw new ObjectDisposedException( "BlubbFile" );
			}

			// TODO: This will be slow as the next ice age for huge archives!
			for( int i = 0; i < entries_.Length; i++ ) {
				if( string.Compare( name, entries_[ i ].Name, ignoreCase, CultureInfo.InvariantCulture ) == 0 ) {
					return i;
				}
			}
			return -1;
		}

		/// <summary>
		/// Searches for a blubb entry in this archive with the given name.
		/// String comparisons are case insensitive
		/// </summary>
		/// <param name="name">
		/// The name to find. May contain directory components separated by slashes ('/').
		/// </param>
		/// <returns>
		/// A clone of the blubb entry, or null if no entry with that name exists.
		/// </returns>
		/// <exception cref="ObjectDisposedException">
		/// The Blubb file has been closed.
		/// </exception>
		public BlubbZipEntry GetEntry( string name ) {
			if( isDisposed_ ) {
				throw new ObjectDisposedException( "BlubbFile" );
			}

			int index = FindEntry( name, true );
			return ( index >= 0 ) ? (BlubbZipEntry)entries_[ index ].Clone() : null;
		}

		/// <summary>
		/// Gets an input stream for reading the given blubb entry data in an uncompressed form.
		/// Normally the <see cref="BlubbEntry"/> should be an entry returned by GetEntry().
		/// </summary>
		/// <param name="entry">The <see cref="BlubbEntry"/> to obtain a data <see cref="Stream"/> for</param>
		/// <returns>An input <see cref="Stream"/> containing data for this <see cref="BlubbEntry"/></returns>
		/// <exception cref="ObjectDisposedException">
		/// The BlubbFile has already been closed
		/// </exception>
		/// <exception cref="GodLesZ.Library.BlubbZip.Blubb.BlubbException">
		/// The compression method for the entry is unknown
		/// </exception>
		/// <exception cref="IndexOutOfRangeException">
		/// The entry is not found in the BlubbFile
		/// </exception>
		public Stream GetInputStream( BlubbZipEntry entry ) {
			if( entry == null ) {
				throw new ArgumentNullException( "entry" );
			}

			if( isDisposed_ ) {
				throw new ObjectDisposedException( "BlubbFile" );
			}

			long index = entry.BlubbFileIndex;
			if( ( index < 0 ) || ( index >= entries_.Length ) || ( entries_[ index ].Name != entry.Name ) ) {
				index = FindEntry( entry.Name, true );
				if( index < 0 ) {
					throw new BlubbZipException( "Entry cannot be found" );
				}
			}
			return GetInputStream( index );
		}

		/// <summary>
		/// Creates an input stream reading a blubb entry
		/// </summary>
		/// <param name="entryIndex">The index of the entry to obtain an input stream for.</param>
		/// <returns>
		/// An input <see cref="Stream"/> containing data for this <paramref name="entryIndex"/>
		/// </returns>
		/// <exception cref="ObjectDisposedException">
		/// The BlubbFile has already been closed
		/// </exception>
		/// <exception cref="GodLesZ.Library.BlubbZip.Blubb.BlubbException">
		/// The compression method for the entry is unknown
		/// </exception>
		/// <exception cref="IndexOutOfRangeException">
		/// The entry is not found in the BlubbFile
		/// </exception>
		public Stream GetInputStream( long entryIndex ) {
			if( isDisposed_ ) {
				throw new ObjectDisposedException( "BlubbFile" );
			}

			long start = LocateEntry( entries_[ entryIndex ] );
			CompressionMethod method = entries_[ entryIndex ].CompressionMethod;
			Stream result = new PartialInputStream( this, start, entries_[ entryIndex ].CompressedSize );

			if( entries_[ entryIndex ].IsCrypted == true ) {
				result = CreateAndInitDecryptionStream( result, entries_[ entryIndex ] );
				if( result == null ) {
					throw new BlubbZipException( "Unable to decrypt this entry" );
				}
			}

			switch( method ) {
				case CompressionMethod.Stored:
					// read as is.
					break;

				case CompressionMethod.Deflated:
					// No need to worry about ownership and closing as underlying stream close does nothing.
					result = new InflaterInputStream( result, new Inflater( true ) );
					break;

				default:
					throw new BlubbZipException( "Unsupported compression method " + method );
			}

			return result;
		}



		// Archive Testing
		/// <summary>
		/// Test an archive for integrity/validity
		/// </summary>
		/// <param name="testData">Perform low level data Crc check</param>
		/// <returns>true if all tests pass, false otherwise</returns>
		/// <remarks>Testing will terminate on the first error found.</remarks>
		public bool TestArchive( bool testData ) {
			return TestArchive( testData, TestStrategy.FindFirstError, null );
		}

		/// <summary>
		/// Test an archive for integrity/validity
		/// </summary>
		/// <param name="testData">Perform low level data Crc check</param>
		/// <param name="strategy">The <see cref="TestStrategy"></see> to apply.</param>
		/// <param name="resultHandler">The <see cref="BlubbTestResultHandler"></see> handler to call during testing.</param>
		/// <returns>true if all tests pass, false otherwise</returns>
		/// <exception cref="ObjectDisposedException">The object has already been closed.</exception>
		public bool TestArchive( bool testData, TestStrategy strategy, BlubbTestResultHandler resultHandler ) {
			if( isDisposed_ ) {
				throw new ObjectDisposedException( "BlubbFile" );
			}

			TestStatus status = new TestStatus( this );

			if( resultHandler != null ) {
				resultHandler( status, null );
			}

			HeaderTest test = testData ? ( HeaderTest.Header | HeaderTest.Extract ) : HeaderTest.Header;

			bool testing = true;

			try {
				int entryIndex = 0;

				while( testing && ( entryIndex < Count ) ) {
					if( resultHandler != null ) {
						status.SetEntry( this[ entryIndex ] );
						status.SetOperation( TestOperation.EntryHeader );
						resultHandler( status, null );
					}

					try {
						TestLocalHeader( this[ entryIndex ], test );
					} catch( BlubbZipException ex ) {
						status.AddError();

						if( resultHandler != null ) {
							resultHandler( status,
								string.Format( "Exception during test - '{0}'", ex.Message ) );
						}

						if( strategy == TestStrategy.FindFirstError ) {
							testing = false;
						}
					}

					if( testing && testData && this[ entryIndex ].IsFile ) {
						if( resultHandler != null ) {
							status.SetOperation( TestOperation.EntryData );
							resultHandler( status, null );
						}

						Crc32 crc = new Crc32();

						using( Stream entryStream = this.GetInputStream( this[ entryIndex ] ) ) {

							byte[] buffer = new byte[ 4096 ];
							long totalBytes = 0;
							int bytesRead;
							while( ( bytesRead = entryStream.Read( buffer, 0, buffer.Length ) ) > 0 ) {
								crc.Update( buffer, 0, bytesRead );

								if( resultHandler != null ) {
									totalBytes += bytesRead;
									status.SetBytesTested( totalBytes );
									resultHandler( status, null );
								}
							}
						}

						if( this[ entryIndex ].Crc != crc.Value ) {
							status.AddError();

							if( resultHandler != null ) {
								resultHandler( status, "CRC mismatch" );
							}

							if( strategy == TestStrategy.FindFirstError ) {
								testing = false;
							}
						}

						if( ( this[ entryIndex ].Flags & (int)GeneralBitFlags.Descriptor ) != 0 ) {
							BlubbZipHelperStream helper = new BlubbZipHelperStream( baseStream_ );
							DescriptorData data = new DescriptorData();
							helper.ReadDataDescriptor( this[ entryIndex ].LocalHeaderRequiresBlubb64, data );
							if( this[ entryIndex ].Crc != data.Crc ) {
								status.AddError();
							}

							if( this[ entryIndex ].CompressedSize != data.CompressedSize ) {
								status.AddError();
							}

							if( this[ entryIndex ].Size != data.Size ) {
								status.AddError();
							}
						}
					}

					if( resultHandler != null ) {
						status.SetOperation( TestOperation.EntryComplete );
						resultHandler( status, null );
					}

					entryIndex += 1;
				}

				if( resultHandler != null ) {
					status.SetOperation( TestOperation.MiscellaneousTests );
					resultHandler( status, null );
				}

				// TODO: the 'Corrina Johns' test where local headers are missing from
				// the central directory.  They are therefore invisible to many archivers.
			} catch( Exception ex ) {
				status.AddError();

				if( resultHandler != null ) {
					resultHandler( status, string.Format( "Exception during test - '{0}'", ex.Message ) );
				}
			}

			if( resultHandler != null ) {
				status.SetOperation( TestOperation.Complete );
				status.SetEntry( null );
				resultHandler( status, null );
			}

			return ( status.ErrorCount == 0 );
		}

		[Flags]
		enum HeaderTest {
			Extract = 0x01,     // Check that this header represents an entry whose data can be extracted
			Header = 0x02,     // Check that this header contents are valid
		}

		/// <summary>
		/// Test a local header against that provided from the central directory
		/// </summary>
		/// <param name="entry">
		/// The entry to test against
		/// </param>
		/// <param name="tests">The type of <see cref="HeaderTest">tests</see> to carry out.</param>
		/// <returns>The offset of the entries data in the file</returns>
		long TestLocalHeader( BlubbZipEntry entry, HeaderTest tests ) {
			lock( baseStream_ ) {
				bool testHeader = ( tests & HeaderTest.Header ) != 0;
				bool testData = ( tests & HeaderTest.Extract ) != 0;

				baseStream_.Seek( offsetOfFirstEntry + entry.Offset, SeekOrigin.Begin );
				if( (int)ReadLEUint() != BlubbZipConstants.LocalHeaderSignature ) {
					throw new BlubbZipException( string.Format( "Wrong local header signature @{0:X}", offsetOfFirstEntry + entry.Offset ) );
				}

				short extractVersion = (short)ReadLEUshort();
				short localFlags = (short)ReadLEUshort();
				short compressionMethod = (short)ReadLEUshort();
				short fileTime = (short)ReadLEUshort();
				short fileDate = (short)ReadLEUshort();
				uint crcValue = ReadLEUint();
				long compressedSize = ReadLEUint();
				long size = ReadLEUint();
				int storedNameLength = ReadLEUshort();
				int extraDataLength = ReadLEUshort();

				byte[] nameData = new byte[ storedNameLength ];
				StreamUtils.ReadFully( baseStream_, nameData );

				byte[] extraData = new byte[ extraDataLength ];
				StreamUtils.ReadFully( baseStream_, extraData );

				BlubbZipExtraData localExtraData = new BlubbZipExtraData( extraData );

				// Extra data / blubb64 checks
				if( localExtraData.Find( 1 ) ) {
					// TODO Check for tag values being distinct..  Multiple blubb64 tags means what?

					// Blubb64 extra data but 'extract version' is too low
					if( extractVersion < BlubbZipConstants.VersionBlubb64 ) {
						throw new BlubbZipException(
							string.Format( "Extra data contains Blubb64 information but version {0}.{1} is not high enough",
							extractVersion / 10, extractVersion % 10 ) );
					}

					// Blubb64 extra data but size fields dont indicate its required.
					if( ( (uint)size != uint.MaxValue ) && ( (uint)compressedSize != uint.MaxValue ) ) {
						throw new BlubbZipException( "Entry sizes not correct for Blubb64" );
					}

					size = localExtraData.ReadLong();
					compressedSize = localExtraData.ReadLong();

					if( ( localFlags & (int)GeneralBitFlags.Descriptor ) != 0 ) {
						// These may be valid if patched later
						if( ( size != -1 ) && ( size != entry.Size ) ) {
							throw new BlubbZipException( "Size invalid for descriptor" );
						}

						if( ( compressedSize != -1 ) && ( compressedSize != entry.CompressedSize ) ) {
							throw new BlubbZipException( "Compressed size invalid for descriptor" );
						}
					}
				} else {
					// No blubb64 extra data but entry requires it.
					if( ( extractVersion >= BlubbZipConstants.VersionBlubb64 ) &&
						( ( (uint)size == uint.MaxValue ) || ( (uint)compressedSize == uint.MaxValue ) ) ) {
						throw new BlubbZipException( "Required Blubb64 extended information missing" );
					}
				}

				if( testData ) {
					if( entry.IsFile ) {
						if( !entry.IsCompressionMethodSupported() ) {
							throw new BlubbZipException( "Compression method not supported" );
						}

						if( ( extractVersion > BlubbZipConstants.VersionMadeBy )
							|| ( ( extractVersion > 20 ) && ( extractVersion < BlubbZipConstants.VersionBlubb64 ) ) ) {
							throw new BlubbZipException( string.Format( "Version required to extract this entry not supported ({0})", extractVersion ) );
						}

						if( ( localFlags & (int)( GeneralBitFlags.Patched | GeneralBitFlags.StrongEncryption | GeneralBitFlags.EnhancedCompress | GeneralBitFlags.HeaderMasked ) ) != 0 ) {
							throw new BlubbZipException( "The library does not support the blubb version required to extract this entry" );
						}
					}
				}

				if( testHeader ) {
					if( ( extractVersion <= 63 ) &&
						( extractVersion != 10 ) &&
						( extractVersion != 11 ) &&
						( extractVersion != 20 ) &&
						( extractVersion != 21 ) &&
						( extractVersion != 25 ) &&
						( extractVersion != 27 ) &&
						( extractVersion != 45 ) &&
						( extractVersion != 46 ) &&
						( extractVersion != 50 ) &&
						( extractVersion != 51 ) &&
						( extractVersion != 52 ) &&
						( extractVersion != 61 ) &&
						( extractVersion != 62 ) &&
						( extractVersion != 63 )
						) {
						throw new BlubbZipException( string.Format( "Version required to extract this entry is invalid ({0})", extractVersion ) );
					}

					// Local entry flags dont have reserved bit set on.
					if( ( localFlags & (int)( GeneralBitFlags.ReservedPKware4 | GeneralBitFlags.ReservedPkware14 | GeneralBitFlags.ReservedPkware15 ) ) != 0 ) {
						throw new BlubbZipException( "Reserved bit flags cannot be set." );
					}

					// Encryption requires extract version >= 20
					if( ( ( localFlags & (int)GeneralBitFlags.Encrypted ) != 0 ) && ( extractVersion < 20 ) ) {
						throw new BlubbZipException( string.Format( "Version required to extract this entry is too low for encryption ({0})", extractVersion ) );
					}

					// Strong encryption requires encryption flag to be set and extract version >= 50.
					if( ( localFlags & (int)GeneralBitFlags.StrongEncryption ) != 0 ) {
						if( ( localFlags & (int)GeneralBitFlags.Encrypted ) == 0 ) {
							throw new BlubbZipException( "Strong encryption flag set but encryption flag is not set" );
						}

						if( extractVersion < 50 ) {
							throw new BlubbZipException( string.Format( "Version required to extract this entry is too low for encryption ({0})", extractVersion ) );
						}
					}

					// Patched entries require extract version >= 27
					if( ( ( localFlags & (int)GeneralBitFlags.Patched ) != 0 ) && ( extractVersion < 27 ) ) {
						throw new BlubbZipException( string.Format( "Patched data requires higher version than ({0})", extractVersion ) );
					}

					// Central header flags match local entry flags.
					if( localFlags != entry.Flags ) {
						throw new BlubbZipException( "Central header/local header flags mismatch" );
					}

					// Central header compression method matches local entry
					if( entry.CompressionMethod != (CompressionMethod)compressionMethod ) {
						throw new BlubbZipException( "Central header/local header compression method mismatch" );
					}

					if( entry.Version != extractVersion ) {
						throw new BlubbZipException( "Extract version mismatch" );
					}

					// Strong encryption and extract version match
					if( ( localFlags & (int)GeneralBitFlags.StrongEncryption ) != 0 ) {
						if( extractVersion < 62 ) {
							throw new BlubbZipException( "Strong encryption flag set but version not high enough" );
						}
					}

					if( ( localFlags & (int)GeneralBitFlags.HeaderMasked ) != 0 ) {
						if( ( fileTime != 0 ) || ( fileDate != 0 ) ) {
							throw new BlubbZipException( "Header masked set but date/time values non-zero" );
						}
					}

					if( ( localFlags & (int)GeneralBitFlags.Descriptor ) == 0 ) {
						if( crcValue != (uint)entry.Crc ) {
							throw new BlubbZipException( "Central header/local header crc mismatch" );
						}
					}

					// Crc valid for empty entry.
					// This will also apply to streamed entries where size isnt known and the header cant be patched
					if( ( size == 0 ) && ( compressedSize == 0 ) ) {
						if( crcValue != 0 ) {
							throw new BlubbZipException( "Invalid CRC for empty entry" );
						}
					}

					// TODO: make test more correct...  can't compare lengths as was done originally as this can fail for MBCS strings
					// Assuming a code page at this point is not valid?  Best is to store the name length in the BlubbEntry probably
					if( entry.Name.Length > storedNameLength ) {
						throw new BlubbZipException( "File name length mismatch" );
					}

					// Name data has already been read convert it and compare.
					string localName = BlubbZipConstants.ConvertToStringExt( localFlags, nameData );

					// Central directory and local entry name match
					if( localName != entry.Name ) {
						throw new BlubbZipException( "Central header and local header file name mismatch" );
					}

					// Directories have zero actual size but can have compressed size
					if( entry.IsDirectory ) {
						if( size > 0 ) {
							throw new BlubbZipException( "Directory cannot have size" );
						}

						// There may be other cases where the compressed size can be greater than this?
						// If so until details are known we will be strict.
						if( entry.IsCrypted ) {
							if( compressedSize > BlubbZipConstants.CryptoHeaderSize + 2 ) {
								throw new BlubbZipException( "Directory compressed size invalid" );
							}
						} else if( compressedSize > 2 ) {
							// When not compressed the directory size can validly be 2 bytes
							// if the true size wasnt known when data was originally being written.
							// NOTE: Versions of the library 0.85.4 and earlier always added 2 bytes
							throw new BlubbZipException( "Directory compressed size invalid" );
						}
					}

					if( !BlubbZipNameTransform.IsValidName( localName, true ) ) {
						throw new BlubbZipException( "Name is invalid" );
					}
				}

				// Tests that apply to both data and header.

				// Size can be verified only if it is known in the local header.
				// it will always be known in the central header.
				if( ( ( localFlags & (int)GeneralBitFlags.Descriptor ) == 0 ) ||
					( ( size > 0 ) || ( compressedSize > 0 ) ) ) {

					if( size != entry.Size ) {
						throw new BlubbZipException(
							string.Format( "Size mismatch between central header({0}) and local header({1})",
								entry.Size, size ) );
					}

					if( compressedSize != entry.CompressedSize ) {
						throw new BlubbZipException(
							string.Format( "Compressed size mismatch between central header({0}) and local header({1})",
							entry.CompressedSize, compressedSize ) );
					}
				}

				int extraLength = storedNameLength + extraDataLength;
				return offsetOfFirstEntry + entry.Offset + BlubbZipConstants.LocalHeaderBaseSize + extraLength;
			}
		}



		// Updating

		const int DefaultBufferSize = 4096;

		/// <summary>
		/// The kind of update to apply.
		/// </summary>
		enum UpdateCommand {
			Copy,       // Copy original file contents.
			Modify,     // Change encryption, compression, attributes, name, time etc, of an existing file.
			Add,        // Add a new file to the archive.
		}

		// Properties
		/// <summary>
		/// Get / set the <see cref="INameTransform"/> to apply to names when updating.
		/// </summary>
		public INameTransform NameTransform {
			get {
				return updateEntryFactory_.NameTransform;
			}

			set {
				updateEntryFactory_.NameTransform = value;
			}
		}

		/// <summary>
		/// Get/set the <see cref="IEntryFactory"/> used to generate <see cref="BlubbEntry"/> values
		/// during updates.
		/// </summary>
		public IBlubbZipEntryFactory EntryFactory {
			get {
				return updateEntryFactory_;
			}

			set {
				if( value == null ) {
					updateEntryFactory_ = new BlubbZipEntryFactory();
				} else {
					updateEntryFactory_ = value;
				}
			}
		}

		/// <summary>
		/// Get /set the buffer size to be used when updating this blubb file.
		/// </summary>
		public int BufferSize {
			get {
				return bufferSize_;
			}
			set {
				if( value < 1024 ) {
					throw new ArgumentOutOfRangeException( "value", "cannot be below 1024" );
				}

				if( bufferSize_ != value ) {
					bufferSize_ = value;
					copyBuffer_ = null;
				}
			}
		}

		/// <summary>
		/// Get a value indicating an update has <see cref="BeginUpdate()">been started</see>.
		/// </summary>
		public bool IsUpdating {
			get {
				return updates_ != null;
			}
		}

		/// <summary>
		/// Get / set a value indicating how Blubb64 Extension usage is determined when adding entries.
		/// </summary>
		public UseBlubb64 UseBlubb64 {
			get {
				return useBlubb64_;
			}
			set {
				useBlubb64_ = value;
			}
		}



		// Immediate updating
		//		TBD: Direct form of updating
		// 
		//		public void Update(IEntryMatcher deleteMatcher)
		//		{
		//		}
		//
		//		public void Update(IScanner addScanner)
		//		{
		//		}


		// Deferred Updating
		/// <summary>
		/// Begin updating this <see cref="BlubbFile"/> archive.
		/// </summary>
		/// <param name="archiveStorage">The <see cref="IArchiveStorage">archive storage</see> for use during the update.</param>
		/// <param name="dataSource">The <see cref="IDynamicDataSource">data source</see> to utilise during updating.</param>
		/// <exception cref="ObjectDisposedException">BlubbFile has been closed.</exception>
		/// <exception cref="ArgumentNullException">One of the arguments provided is null</exception>
		/// <exception cref="ObjectDisposedException">BlubbFile has been closed.</exception>
		public void BeginUpdate( IArchiveStorage archiveStorage, IDynamicDataSource dataSource ) {
			if( archiveStorage == null ) {
				throw new ArgumentNullException( "archiveStorage" );
			}

			if( dataSource == null ) {
				throw new ArgumentNullException( "dataSource" );
			}

			if( isDisposed_ ) {
				throw new ObjectDisposedException( "BlubbFile" );
			}

			if( IsEmbeddedArchive ) {
				throw new BlubbZipException( "Cannot update embedded/SFX archives" );
			}

			archiveStorage_ = archiveStorage;
			updateDataSource_ = dataSource;

			// NOTE: the baseStream_ may not currently support writing or seeking.

			updateIndex_ = new Hashtable();

			updates_ = new ArrayList( entries_.Length );
			foreach( BlubbZipEntry entry in entries_ ) {
				int index = updates_.Add( new BlubbUpdate( entry ) );
				updateIndex_.Add( entry.Name, index );
			}

			updateCount_ = updates_.Count;

			contentsEdited_ = false;
			commentEdited_ = false;
			newComment_ = null;
		}

		/// <summary>
		/// Begin updating to this <see cref="BlubbFile"/> archive.
		/// </summary>
		/// <param name="archiveStorage">The storage to use during the update.</param>
		public void BeginUpdate( IArchiveStorage archiveStorage ) {
			BeginUpdate( archiveStorage, new DynamicDiskDataSource() );
		}

		/// <summary>
		/// Begin updating this <see cref="BlubbFile"/> archive.
		/// </summary>
		/// <seealso cref="BeginUpdate(IArchiveStorage)"/>
		/// <seealso cref="CommitUpdate"></seealso>
		/// <seealso cref="AbortUpdate"></seealso>
		public void BeginUpdate() {
			if( Name == null ) {
				BeginUpdate( new MemoryArchiveStorage(), new DynamicDiskDataSource() );
			} else {
				BeginUpdate( new DiskArchiveStorage( this ), new DynamicDiskDataSource() );
			}
		}

		/// <summary>
		/// Commit current updates, updating this archive.
		/// </summary>
		/// <seealso cref="BeginUpdate()"></seealso>
		/// <seealso cref="AbortUpdate"></seealso>
		/// <exception cref="ObjectDisposedException">BlubbFile has been closed.</exception>
		public void CommitUpdate() {
			if( isDisposed_ ) {
				throw new ObjectDisposedException( "BlubbFile" );
			}

			CheckUpdating();

			try {
				updateIndex_.Clear();
				updateIndex_ = null;

				if( contentsEdited_ ) {
					RunUpdates();
				} else if( commentEdited_ ) {
					UpdateCommentOnly();
				} else {
					// Create an empty archive if none existed originally.
					if( entries_.Length == 0 ) {
						byte[] theComment = ( newComment_ != null ) ? newComment_.RawComment : BlubbZipConstants.ConvertToArray( comment_ );
						using( BlubbZipHelperStream zhs = new BlubbZipHelperStream( baseStream_ ) ) {
							zhs.WriteEndOfCentralDirectory( 0, 0, 0, theComment );
						}
					}
				}

			} finally {
				PostUpdateCleanup();
			}
		}

		/// <summary>
		/// Abort updating leaving the archive unchanged.
		/// </summary>
		/// <seealso cref="BeginUpdate()"></seealso>
		/// <seealso cref="CommitUpdate"></seealso>
		public void AbortUpdate() {
			PostUpdateCleanup();
		}

		/// <summary>
		/// Set the file comment to be recorded when the current update is <see cref="CommitUpdate">commited</see>.
		/// </summary>
		/// <param name="comment">The comment to record.</param>
		/// <exception cref="ObjectDisposedException">BlubbFile has been closed.</exception>
		public void SetComment( string comment ) {
			if( isDisposed_ ) {
				throw new ObjectDisposedException( "BlubbFile" );
			}

			CheckUpdating();

			newComment_ = new BlubbString( comment );

			if( newComment_.RawLength > 0xffff ) {
				newComment_ = null;
				throw new BlubbZipException( "Comment length exceeds maximum - 65535" );
			}

			// We dont take account of the original and current comment appearing to be the same
			// as encoding may be different.
			commentEdited_ = true;
		}



		// Adding Entries

		void AddUpdate( BlubbUpdate update ) {
			contentsEdited_ = true;

			int index = FindExistingUpdate( update.Entry.Name );

			if( index >= 0 ) {
				if( updates_[ index ] == null ) {
					updateCount_ += 1;
				}

				// Direct replacement is faster than delete and add.
				updates_[ index ] = update;
			} else {
				index = updates_.Add( update );
				updateCount_ += 1;
				updateIndex_.Add( update.Entry.Name, index );
			}
		}

		/// <summary>
		/// Add a new entry to the archive.
		/// </summary>
		/// <param name="fileName">The name of the file to add.</param>
		/// <param name="compressionMethod">The compression method to use.</param>
		/// <param name="useUnicodeText">Ensure Unicode text is used for name and comment for this entry.</param>
		/// <exception cref="ArgumentNullException">Argument supplied is null.</exception>
		/// <exception cref="ObjectDisposedException">BlubbFile has been closed.</exception>
		/// <exception cref="ArgumentOutOfRangeException">Compression method is not supported.</exception>
		public void Add( string fileName, CompressionMethod compressionMethod, bool useUnicodeText ) {
			if( fileName == null ) {
				throw new ArgumentNullException( "fileName" );
			}

			if( isDisposed_ ) {
				throw new ObjectDisposedException( "BlubbFile" );
			}

			if( !BlubbZipEntry.IsCompressionMethodSupported( compressionMethod ) ) {
				throw new ArgumentOutOfRangeException( "compressionMethod" );
			}

			CheckUpdating();
			contentsEdited_ = true;

			BlubbZipEntry entry = EntryFactory.MakeFileEntry( fileName );
			entry.IsUnicodeText = useUnicodeText;
			entry.CompressionMethod = compressionMethod;

			AddUpdate( new BlubbUpdate( fileName, entry ) );
		}

		/// <summary>
		/// Add a new entry to the archive.
		/// </summary>
		/// <param name="fileName">The name of the file to add.</param>
		/// <param name="compressionMethod">The compression method to use.</param>
		/// <exception cref="ArgumentNullException">BlubbFile has been closed.</exception>
		/// <exception cref="ArgumentOutOfRangeException">The compression method is not supported.</exception>
		public void Add( string fileName, CompressionMethod compressionMethod ) {
			if( fileName == null ) {
				throw new ArgumentNullException( "fileName" );
			}

			if( !BlubbZipEntry.IsCompressionMethodSupported( compressionMethod ) ) {
				throw new ArgumentOutOfRangeException( "compressionMethod" );
			}

			CheckUpdating();
			contentsEdited_ = true;

			BlubbZipEntry entry = EntryFactory.MakeFileEntry( fileName );
			entry.CompressionMethod = compressionMethod;
			AddUpdate( new BlubbUpdate( fileName, entry ) );
		}

		/// <summary>
		/// Add a file to the archive.
		/// </summary>
		/// <param name="fileName">The name of the file to add.</param>
		/// <exception cref="ArgumentNullException">Argument supplied is null.</exception>
		public void Add( string fileName ) {
			if( fileName == null ) {
				throw new ArgumentNullException( "fileName" );
			}

			CheckUpdating();
			AddUpdate( new BlubbUpdate( fileName, EntryFactory.MakeFileEntry( fileName ) ) );
		}

		/// <summary>
		/// Add a file to the archive.
		/// </summary>
		/// <param name="fileName">The name of the file to add.</param>
		/// <param name="entryName">The name to use for the <see cref="BlubbEntry"/> on the Blubb file created.</param>
		/// <exception cref="ArgumentNullException">Argument supplied is null.</exception>
		public void Add( string fileName, string entryName ) {
			if( fileName == null ) {
				throw new ArgumentNullException( "fileName" );
			}

			if( entryName == null ) {
				throw new ArgumentNullException( "entryName" );
			}

			CheckUpdating();
			AddUpdate( new BlubbUpdate( fileName, EntryFactory.MakeFileEntry( entryName ) ) );
		}


		/// <summary>
		/// Add a file entry with data.
		/// </summary>
		/// <param name="dataSource">The source of the data for this entry.</param>
		/// <param name="entryName">The name to give to the entry.</param>
		public void Add( IStaticDataSource dataSource, string entryName ) {
			if( dataSource == null ) {
				throw new ArgumentNullException( "dataSource" );
			}

			if( entryName == null ) {
				throw new ArgumentNullException( "entryName" );
			}

			CheckUpdating();
			AddUpdate( new BlubbUpdate( dataSource, EntryFactory.MakeFileEntry( entryName, false ) ) );
		}

		/// <summary>
		/// Add a file entry with data.
		/// </summary>
		/// <param name="dataSource">The source of the data for this entry.</param>
		/// <param name="entryName">The name to give to the entry.</param>
		/// <param name="compressionMethod">The compression method to use.</param>
		public void Add( IStaticDataSource dataSource, string entryName, CompressionMethod compressionMethod ) {
			if( dataSource == null ) {
				throw new ArgumentNullException( "dataSource" );
			}

			if( entryName == null ) {
				throw new ArgumentNullException( "entryName" );
			}

			CheckUpdating();

			BlubbZipEntry entry = EntryFactory.MakeFileEntry( entryName, false );
			entry.CompressionMethod = compressionMethod;

			AddUpdate( new BlubbUpdate( dataSource, entry ) );
		}

		/// <summary>
		/// Add a file entry with data.
		/// </summary>
		/// <param name="dataSource">The source of the data for this entry.</param>
		/// <param name="entryName">The name to give to the entry.</param>
		/// <param name="compressionMethod">The compression method to use.</param>
		/// <param name="useUnicodeText">Ensure Unicode text is used for name and comments for this entry.</param>
		public void Add( IStaticDataSource dataSource, string entryName, CompressionMethod compressionMethod, bool useUnicodeText ) {
			if( dataSource == null ) {
				throw new ArgumentNullException( "dataSource" );
			}

			if( entryName == null ) {
				throw new ArgumentNullException( "entryName" );
			}

			CheckUpdating();

			BlubbZipEntry entry = EntryFactory.MakeFileEntry( entryName, false );
			entry.IsUnicodeText = useUnicodeText;
			entry.CompressionMethod = compressionMethod;

			AddUpdate( new BlubbUpdate( dataSource, entry ) );
		}

		/// <summary>
		/// Add a <see cref="BlubbEntry"/> that contains no data.
		/// </summary>
		/// <param name="entry">The entry to add.</param>
		/// <remarks>This can be used to add directories, volume labels, or empty file entries.</remarks>
		public void Add( BlubbZipEntry entry ) {
			if( entry == null ) {
				throw new ArgumentNullException( "entry" );
			}

			CheckUpdating();

			if( ( entry.Size != 0 ) || ( entry.CompressedSize != 0 ) ) {
				throw new BlubbZipException( "Entry cannot have any data" );
			}

			AddUpdate( new BlubbUpdate( UpdateCommand.Add, entry ) );
		}

		/// <summary>
		/// Add a directory entry to the archive.
		/// </summary>
		/// <param name="directoryName">The directory to add.</param>
		public void AddDirectory( string directoryName ) {
			if( directoryName == null ) {
				throw new ArgumentNullException( "directoryName" );
			}

			CheckUpdating();

			BlubbZipEntry dirEntry = EntryFactory.MakeDirectoryEntry( directoryName );
			AddUpdate( new BlubbUpdate( UpdateCommand.Add, dirEntry ) );
		}



		// Deleting Entries
		/// <summary>
		/// Delete an entry by name
		/// </summary>
		/// <param name="fileName">The filename to delete</param>
		/// <returns>True if the entry was found and deleted; false otherwise.</returns>
		public bool Delete( string fileName ) {
			if( fileName == null ) {
				throw new ArgumentNullException( "fileName" );
			}

			CheckUpdating();

			bool result = false;
			int index = FindExistingUpdate( fileName );
			if( ( index >= 0 ) && ( updates_[ index ] != null ) ) {
				result = true;
				contentsEdited_ = true;
				updates_[ index ] = null;
				updateCount_ -= 1;
			} else {
				throw new BlubbZipException( "Cannot find entry to delete" );
			}
			return result;
		}

		/// <summary>
		/// Delete a <see cref="BlubbEntry"/> from the archive.
		/// </summary>
		/// <param name="entry">The entry to delete.</param>
		public void Delete( BlubbZipEntry entry ) {
			if( entry == null ) {
				throw new ArgumentNullException( "entry" );
			}

			CheckUpdating();

			int index = FindExistingUpdate( entry );
			if( index >= 0 ) {
				contentsEdited_ = true;
				updates_[ index ] = null;
				updateCount_ -= 1;
			} else {
				throw new BlubbZipException( "Cannot find entry to delete" );
			}
		}



		// Update Support
		// Writing Values/Headers
		void WriteLEShort( int value ) {
			baseStream_.WriteByte( (byte)( value & 0xff ) );
			baseStream_.WriteByte( (byte)( ( value >> 8 ) & 0xff ) );
		}

		/// <summary>
		/// Write an unsigned short in little endian byte order.
		/// </summary>
		void WriteLEUshort( ushort value ) {
			baseStream_.WriteByte( (byte)( value & 0xff ) );
			baseStream_.WriteByte( (byte)( value >> 8 ) );
		}

		/// <summary>
		/// Write an int in little endian byte order.
		/// </summary>
		void WriteLEInt( int value ) {
			WriteLEShort( value & 0xffff );
			WriteLEShort( value >> 16 );
		}

		/// <summary>
		/// Write an unsigned int in little endian byte order.
		/// </summary>
		void WriteLEUint( uint value ) {
			WriteLEUshort( (ushort)( value & 0xffff ) );
			WriteLEUshort( (ushort)( value >> 16 ) );
		}

		/// <summary>
		/// Write a long in little endian byte order.
		/// </summary>
		void WriteLeLong( long value ) {
			WriteLEInt( (int)( value & 0xffffffff ) );
			WriteLEInt( (int)( value >> 32 ) );
		}

		void WriteLEUlong( ulong value ) {
			WriteLEUint( (uint)( value & 0xffffffff ) );
			WriteLEUint( (uint)( value >> 32 ) );
		}

		void WriteLocalEntryHeader( BlubbUpdate update ) {
			BlubbZipEntry entry = update.OutEntry;

			// TODO: Local offset will require adjusting for multi-disk blubb files.
			entry.Offset = baseStream_.Position;

			// TODO: Need to clear any entry flags that dont make sense or throw an exception here.
			if( update.Command != UpdateCommand.Copy ) {
				if( entry.CompressionMethod == CompressionMethod.Deflated ) {
					if( entry.Size == 0 ) {
						// No need to compress - no data.
						entry.CompressedSize = entry.Size;
						entry.Crc = 0;
						entry.CompressionMethod = CompressionMethod.Stored;
					}
				} else if( entry.CompressionMethod == CompressionMethod.Stored ) {
					entry.Flags &= ~(int)GeneralBitFlags.Descriptor;
				}

				if( HaveKeys ) {
					entry.IsCrypted = true;
					if( entry.Crc < 0 ) {
						entry.Flags |= (int)GeneralBitFlags.Descriptor;
					}
				} else {
					entry.IsCrypted = false;
				}

				switch( useBlubb64_ ) {
					case UseBlubb64.Dynamic:
						if( entry.Size < 0 ) {
							entry.ForceBlubb64();
						}
						break;

					case UseBlubb64.On:
						entry.ForceBlubb64();
						break;

					case UseBlubb64.Off:
						// Do nothing.  The entry itself may be using Blubb64 independantly.
						break;
				}
			}

			// Write the local file header
			WriteLEInt( BlubbZipConstants.LocalHeaderSignature );

			WriteLEShort( entry.Version );
			WriteLEShort( entry.Flags );

			WriteLEShort( (byte)entry.CompressionMethod );
			WriteLEInt( (int)entry.DosTime );

			if( !entry.HasCrc ) {
				// Note patch address for updating CRC later.
				update.CrcPatchOffset = baseStream_.Position;
				WriteLEInt( (int)0 );
			} else {
				WriteLEInt( unchecked( (int)entry.Crc ) );
			}

			if( entry.LocalHeaderRequiresBlubb64 ) {
				WriteLEInt( -1 );
				WriteLEInt( -1 );
			} else {
				if( ( entry.CompressedSize < 0 ) || ( entry.Size < 0 ) ) {
					update.SizePatchOffset = baseStream_.Position;
				}

				WriteLEInt( (int)entry.CompressedSize );
				WriteLEInt( (int)entry.Size );
			}

			byte[] name = BlubbZipConstants.ConvertToArray( entry.Flags, entry.Name );

			if( name.Length > 0xFFFF ) {
				throw new BlubbZipException( "Entry name too long." );
			}

			BlubbZipExtraData ed = new BlubbZipExtraData( entry.ExtraData );

			if( entry.LocalHeaderRequiresBlubb64 ) {
				ed.StartNewEntry();

				// Local entry header always includes size and compressed size.
				// NOTE the order of these fields is reversed when compared to the normal headers!
				ed.AddLeLong( entry.Size );
				ed.AddLeLong( entry.CompressedSize );
				ed.AddNewEntry( 1 );
			} else {
				ed.Delete( 1 );
			}

			entry.ExtraData = ed.GetEntryData();

			WriteLEShort( name.Length );
			WriteLEShort( entry.ExtraData.Length );

			if( name.Length > 0 ) {
				baseStream_.Write( name, 0, name.Length );
			}

			if( entry.LocalHeaderRequiresBlubb64 ) {
				if( !ed.Find( 1 ) ) {
					throw new BlubbZipException( "Internal error cannot find extra data" );
				}

				update.SizePatchOffset = baseStream_.Position + ed.CurrentReadIndex;
			}

			if( entry.ExtraData.Length > 0 ) {
				baseStream_.Write( entry.ExtraData, 0, entry.ExtraData.Length );
			}
		}

		int WriteCentralDirectoryHeader( BlubbZipEntry entry ) {
			if( entry.CompressedSize < 0 ) {
				throw new BlubbZipException( "Attempt to write central directory entry with unknown csize" );
			}

			if( entry.Size < 0 ) {
				throw new BlubbZipException( "Attempt to write central directory entry with unknown size" );
			}

			if( entry.Crc < 0 ) {
				throw new BlubbZipException( "Attempt to write central directory entry with unknown crc" );
			}

			// Write the central file header
			WriteLEInt( BlubbZipConstants.CentralHeaderSignature );

			// Version made by
			WriteLEShort( BlubbZipConstants.VersionMadeBy );

			// Version required to extract
			WriteLEShort( entry.Version );

			WriteLEShort( entry.Flags );

			unchecked {
				WriteLEShort( (byte)entry.CompressionMethod );
				WriteLEInt( (int)entry.DosTime );
				WriteLEInt( (int)entry.Crc );
			}

			if( ( entry.IsBlubb64Forced() ) || ( entry.CompressedSize >= 0xffffffff ) ) {
				WriteLEInt( -1 );
			} else {
				WriteLEInt( (int)( entry.CompressedSize & 0xffffffff ) );
			}

			if( ( entry.IsBlubb64Forced() ) || ( entry.Size >= 0xffffffff ) ) {
				WriteLEInt( -1 );
			} else {
				WriteLEInt( (int)entry.Size );
			}

			byte[] name = BlubbZipConstants.ConvertToArray( entry.Flags, entry.Name );

			if( name.Length > 0xFFFF ) {
				throw new BlubbZipException( "Entry name is too long." );
			}

			WriteLEShort( name.Length );

			// Central header extra data is different to local header version so regenerate.
			BlubbZipExtraData ed = new BlubbZipExtraData( entry.ExtraData );

			if( entry.CentralHeaderRequiresBlubb64 ) {
				ed.StartNewEntry();

				if( ( entry.Size >= 0xffffffff ) || ( useBlubb64_ == UseBlubb64.On ) ) {
					ed.AddLeLong( entry.Size );
				}

				if( ( entry.CompressedSize >= 0xffffffff ) || ( useBlubb64_ == UseBlubb64.On ) ) {
					ed.AddLeLong( entry.CompressedSize );
				}

				if( entry.Offset >= 0xffffffff ) {
					ed.AddLeLong( entry.Offset );
				}

				// Number of disk on which this file starts isnt supported and is never written here.
				ed.AddNewEntry( 1 );
			} else {
				// Should have already be done when local header was added.
				ed.Delete( 1 );
			}

			byte[] centralExtraData = ed.GetEntryData();

			WriteLEShort( centralExtraData.Length );
			WriteLEShort( entry.Comment != null ? entry.Comment.Length : 0 );

			WriteLEShort( 0 );	// disk number
			WriteLEShort( 0 );	// internal file attributes

			// External file attributes...
			if( entry.ExternalFileAttributes != -1 ) {
				WriteLEInt( entry.ExternalFileAttributes );
			} else {
				if( entry.IsDirectory ) {
					WriteLEUint( 16 );
				} else {
					WriteLEUint( 0 );
				}
			}

			if( entry.Offset >= 0xffffffff ) {
				WriteLEUint( 0xffffffff );
			} else {
				WriteLEUint( (uint)(int)entry.Offset );
			}

			if( name.Length > 0 ) {
				baseStream_.Write( name, 0, name.Length );
			}

			if( centralExtraData.Length > 0 ) {
				baseStream_.Write( centralExtraData, 0, centralExtraData.Length );
			}

			byte[] rawComment = ( entry.Comment != null ) ? Encoding.ASCII.GetBytes( entry.Comment ) : new byte[ 0 ];

			if( rawComment.Length > 0 ) {
				baseStream_.Write( rawComment, 0, rawComment.Length );
			}

			return BlubbZipConstants.CentralHeaderBaseSize + name.Length + centralExtraData.Length + rawComment.Length;
		}


		void PostUpdateCleanup() {
			if( archiveStorage_ != null ) {
				archiveStorage_.Dispose();
				archiveStorage_ = null;
			}

			updateDataSource_ = null;
			updates_ = null;
			updateIndex_ = null;
		}

		string GetTransformedFileName( string name ) {
			return ( NameTransform != null ) ?
				NameTransform.TransformFile( name ) :
				name;
		}

		string GetTransformedDirectoryName( string name ) {
			return ( NameTransform != null ) ?
				NameTransform.TransformDirectory( name ) :
				name;
		}

		/// <summary>
		/// Get a raw memory buffer.
		/// </summary>
		/// <returns>Returns a raw memory buffer.</returns>
		byte[] GetBuffer() {
			if( copyBuffer_ == null ) {
				copyBuffer_ = new byte[ bufferSize_ ];
			}
			return copyBuffer_;
		}

		void CopyDescriptorBytes( BlubbUpdate update, Stream dest, Stream source ) {
			int bytesToCopy = GetDescriptorSize( update );

			if( bytesToCopy > 0 ) {
				byte[] buffer = GetBuffer();

				while( bytesToCopy > 0 ) {
					int readSize = Math.Min( buffer.Length, bytesToCopy );

					int bytesRead = source.Read( buffer, 0, readSize );
					if( bytesRead > 0 ) {
						dest.Write( buffer, 0, bytesRead );
						bytesToCopy -= bytesRead;
					} else {
						throw new BlubbZipException( "Unxpected end of stream" );
					}
				}
			}
		}

		void CopyBytes( BlubbUpdate update, Stream destination, Stream source,
			long bytesToCopy, bool updateCrc ) {
			if( destination == source ) {
				throw new InvalidOperationException( "Destination and source are the same" );
			}

			// NOTE: Compressed size is updated elsewhere.
			Crc32 crc = new Crc32();
			byte[] buffer = GetBuffer();

			long targetBytes = bytesToCopy;
			long totalBytesRead = 0;

			int bytesRead;
			do {
				int readSize = buffer.Length;

				if( bytesToCopy < readSize ) {
					readSize = (int)bytesToCopy;
				}

				bytesRead = source.Read( buffer, 0, readSize );
				if( bytesRead > 0 ) {
					if( updateCrc ) {
						crc.Update( buffer, 0, bytesRead );
					}
					destination.Write( buffer, 0, bytesRead );
					bytesToCopy -= bytesRead;
					totalBytesRead += bytesRead;
				}
			}
			while( ( bytesRead > 0 ) && ( bytesToCopy > 0 ) );

			if( totalBytesRead != targetBytes ) {
				throw new BlubbZipException( string.Format( "Failed to copy bytes expected {0} read {1}", targetBytes, totalBytesRead ) );
			}

			if( updateCrc ) {
				update.OutEntry.Crc = crc.Value;
			}
		}

		/// <summary>
		/// Get the size of the source descriptor for a <see cref="BlubbUpdate"/>.
		/// </summary>
		/// <param name="update">The update to get the size for.</param>
		/// <returns>The descriptor size, zero if there isnt one.</returns>
		int GetDescriptorSize( BlubbUpdate update ) {
			int result = 0;
			if( ( update.Entry.Flags & (int)GeneralBitFlags.Descriptor ) != 0 ) {
				result = BlubbZipConstants.DataDescriptorSize - 4;
				if( update.Entry.LocalHeaderRequiresBlubb64 ) {
					result = BlubbZipConstants.Blubb64DataDescriptorSize - 4;
				}
			}
			return result;
		}

		void CopyDescriptorBytesDirect( BlubbUpdate update, Stream stream, ref long destinationPosition, long sourcePosition ) {
			int bytesToCopy = GetDescriptorSize( update );

			while( bytesToCopy > 0 ) {
				int readSize = (int)bytesToCopy;
				byte[] buffer = GetBuffer();

				stream.Position = sourcePosition;
				int bytesRead = stream.Read( buffer, 0, readSize );
				if( bytesRead > 0 ) {
					stream.Position = destinationPosition;
					stream.Write( buffer, 0, bytesRead );
					bytesToCopy -= bytesRead;
					destinationPosition += bytesRead;
					sourcePosition += bytesRead;
				} else {
					throw new BlubbZipException( "Unxpected end of stream" );
				}
			}
		}

		void CopyEntryDataDirect( BlubbUpdate update, Stream stream, bool updateCrc, ref long destinationPosition, ref long sourcePosition ) {
			long bytesToCopy = update.Entry.CompressedSize;

			// NOTE: Compressed size is updated elsewhere.
			Crc32 crc = new Crc32();
			byte[] buffer = GetBuffer();

			long targetBytes = bytesToCopy;
			long totalBytesRead = 0;

			int bytesRead;
			do {
				int readSize = buffer.Length;

				if( bytesToCopy < readSize ) {
					readSize = (int)bytesToCopy;
				}

				stream.Position = sourcePosition;
				bytesRead = stream.Read( buffer, 0, readSize );
				if( bytesRead > 0 ) {
					if( updateCrc ) {
						crc.Update( buffer, 0, bytesRead );
					}
					stream.Position = destinationPosition;
					stream.Write( buffer, 0, bytesRead );

					destinationPosition += bytesRead;
					sourcePosition += bytesRead;
					bytesToCopy -= bytesRead;
					totalBytesRead += bytesRead;
				}
			}
			while( ( bytesRead > 0 ) && ( bytesToCopy > 0 ) );

			if( totalBytesRead != targetBytes ) {
				throw new BlubbZipException( string.Format( "Failed to copy bytes expected {0} read {1}", targetBytes, totalBytesRead ) );
			}

			if( updateCrc ) {
				update.OutEntry.Crc = crc.Value;
			}
		}

		int FindExistingUpdate( BlubbZipEntry entry ) {
			int result = -1;
			string convertedName = GetTransformedFileName( entry.Name );

			if( updateIndex_.ContainsKey( convertedName ) ) {
				result = (int)updateIndex_[ convertedName ];
			}
			/*
						// This is slow like the coming of the next ice age but takes less storage and may be useful
						// for CF?
						for (int index = 0; index < updates_.Count; ++index)
						{
							BlubbUpdate zu = ( BlubbUpdate )updates_[index];
							if ( (zu.Entry.BlubbFileIndex == entry.BlubbFileIndex) &&
								(string.Compare(convertedName, zu.Entry.Name, true, CultureInfo.InvariantCulture) == 0) ) {
								result = index;
								break;
							}
						}
			 */
			return result;
		}

		int FindExistingUpdate( string fileName ) {
			int result = -1;

			string convertedName = GetTransformedFileName( fileName );

			if( updateIndex_.ContainsKey( convertedName ) ) {
				result = (int)updateIndex_[ convertedName ];
			}

			/*
						// This is slow like the coming of the next ice age but takes less storage and may be useful
						// for CF?
						for ( int index = 0; index < updates_.Count; ++index ) {
							if ( string.Compare(convertedName, (( BlubbUpdate )updates_[index]).Entry.Name,
								true, CultureInfo.InvariantCulture) == 0 ) {
								result = index;
								break;
							}
						}
			 */

			return result;
		}

		/// <summary>
		/// Get an output stream for the specified <see cref="BlubbEntry"/>
		/// </summary>
		/// <param name="entry">The entry to get an output stream for.</param>
		/// <returns>The output stream obtained for the entry.</returns>
		Stream GetOutputStream( BlubbZipEntry entry ) {
			Stream result = baseStream_;

			if( entry.IsCrypted == true ) {
				result = CreateAndInitEncryptionStream( result, entry );
			}

			switch( entry.CompressionMethod ) {
				case CompressionMethod.Stored:
					result = new UncompressedStream( result );
					break;

				case CompressionMethod.Deflated:
					DeflaterOutputStream dos = new DeflaterOutputStream( result, new Deflater( 9, true ) );
					dos.IsStreamOwner = false;
					result = dos;
					break;

				default:
					throw new BlubbZipException( "Unknown compression method " + entry.CompressionMethod );
			}
			return result;
		}

		void AddEntry( BlubbZipFile workFile, BlubbUpdate update ) {
			Stream source = null;

			if( update.Entry.IsFile ) {
				source = update.GetSource();

				if( source == null ) {
					source = updateDataSource_.GetSource( update.Entry, update.Filename );
				}
			}

			if( source != null ) {
				using( source ) {
					long sourceStreamLength = source.Length;
					if( update.OutEntry.Size < 0 ) {
						update.OutEntry.Size = sourceStreamLength;
					} else {
						// Check for errant entries.
						if( update.OutEntry.Size != sourceStreamLength ) {
							throw new BlubbZipException( "Entry size/stream size mismatch" );
						}
					}

					workFile.WriteLocalEntryHeader( update );

					long dataStart = workFile.baseStream_.Position;

					using( Stream output = workFile.GetOutputStream( update.OutEntry ) ) {
						CopyBytes( update, output, source, sourceStreamLength, true );
					}

					long dataEnd = workFile.baseStream_.Position;
					update.OutEntry.CompressedSize = dataEnd - dataStart;

					if( ( update.OutEntry.Flags & (int)GeneralBitFlags.Descriptor ) == (int)GeneralBitFlags.Descriptor ) {
						BlubbZipHelperStream helper = new BlubbZipHelperStream( workFile.baseStream_ );
						helper.WriteDataDescriptor( update.OutEntry );
					}
				}
			} else {
				workFile.WriteLocalEntryHeader( update );
				update.OutEntry.CompressedSize = 0;
			}

		}

		void ModifyEntry( BlubbZipFile workFile, BlubbUpdate update ) {
			workFile.WriteLocalEntryHeader( update );
			long dataStart = workFile.baseStream_.Position;

			// TODO: This is slow if the changes don't effect the data!!
			if( update.Entry.IsFile && ( update.Filename != null ) ) {
				using( Stream output = workFile.GetOutputStream( update.OutEntry ) ) {
					using( Stream source = this.GetInputStream( update.Entry ) ) {
						CopyBytes( update, output, source, source.Length, true );
					}
				}
			}

			long dataEnd = workFile.baseStream_.Position;
			update.Entry.CompressedSize = dataEnd - dataStart;
		}

		void CopyEntryDirect( BlubbZipFile workFile, BlubbUpdate update, ref long destinationPosition ) {
			bool skipOver = false;
			if( update.Entry.Offset == destinationPosition ) {
				skipOver = true;
			}

			if( !skipOver ) {
				baseStream_.Position = destinationPosition;
				workFile.WriteLocalEntryHeader( update );
				destinationPosition = baseStream_.Position;
			}

			long sourcePosition = 0;

			const int NameLengthOffset = 26;

			// TODO: Add base for SFX friendly handling
			long entryDataOffset = update.Entry.Offset + NameLengthOffset;

			baseStream_.Seek( entryDataOffset, SeekOrigin.Begin );

			// Clumsy way of handling retrieving the original name and extra data length for now.
			// TODO: Stop re-reading name and data length in CopyEntryDirect.
			uint nameLength = ReadLEUshort();
			uint extraLength = ReadLEUshort();

			sourcePosition = baseStream_.Position + nameLength + extraLength;

			if( skipOver ) {
				destinationPosition +=
					( sourcePosition - entryDataOffset ) + NameLengthOffset +	// Header size
					update.Entry.CompressedSize + GetDescriptorSize( update );
			} else {
				if( update.Entry.CompressedSize > 0 ) {
					CopyEntryDataDirect( update, baseStream_, false, ref destinationPosition, ref sourcePosition );
				}
				CopyDescriptorBytesDirect( update, baseStream_, ref destinationPosition, sourcePosition );
			}
		}

		void CopyEntry( BlubbZipFile workFile, BlubbUpdate update ) {
			workFile.WriteLocalEntryHeader( update );

			if( update.Entry.CompressedSize > 0 ) {
				const int NameLengthOffset = 26;

				long entryDataOffset = update.Entry.Offset + NameLengthOffset;

				// TODO: This wont work for SFX files!
				baseStream_.Seek( entryDataOffset, SeekOrigin.Begin );

				uint nameLength = ReadLEUshort();
				uint extraLength = ReadLEUshort();

				baseStream_.Seek( nameLength + extraLength, SeekOrigin.Current );

				CopyBytes( update, workFile.baseStream_, baseStream_, update.Entry.CompressedSize, false );
			}
			CopyDescriptorBytes( update, workFile.baseStream_, baseStream_ );
		}

		void Reopen( Stream source ) {
			if( source == null ) {
				throw new BlubbZipException( "Failed to reopen archive - no source" );
			}

			isNewArchive_ = false;
			baseStream_ = source;
			ReadEntries();
		}

		void Reopen() {
			if( Name == null ) {
				throw new InvalidOperationException( "Name is not known cannot Reopen" );
			}

			Reopen( File.OpenRead( Name ) );
		}

		void UpdateCommentOnly() {
			long baseLength = baseStream_.Length;

			BlubbZipHelperStream updateFile = null;

			if( archiveStorage_.UpdateMode == FileUpdateMode.Safe ) {
				Stream copyStream = archiveStorage_.MakeTemporaryCopy( baseStream_ );
				updateFile = new BlubbZipHelperStream( copyStream );
				updateFile.IsStreamOwner = true;

				baseStream_.Close();
				baseStream_ = null;
			} else {
				if( archiveStorage_.UpdateMode == FileUpdateMode.Direct ) {
					// TODO: archiveStorage wasnt originally intended for this use.
					// Need to revisit this to tidy up handling as archive storage currently doesnt 
					// handle the original stream well.
					// The problem is when using an existing blubb archive with an in memory archive storage.
					// The open stream wont support writing but the memory storage should open the same file not an in memory one.

					// Need to tidy up the archive storage interface and contract basically.
					baseStream_ = archiveStorage_.OpenForDirectUpdate( baseStream_ );
					updateFile = new BlubbZipHelperStream( baseStream_ );
				} else {
					baseStream_.Close();
					baseStream_ = null;
					updateFile = new BlubbZipHelperStream( Name );
				}
			}

			using( updateFile ) {
				long locatedCentralDirOffset =
					updateFile.LocateBlockWithSignature( BlubbZipConstants.EndOfCentralDirectorySignature,
														baseLength, BlubbZipConstants.EndOfCentralRecordBaseSize, 0xffff );
				if( locatedCentralDirOffset < 0 ) {
					throw new BlubbZipException( "Cannot find central directory" );
				}

				const int CentralHeaderCommentSizeOffset = 16;
				updateFile.Position += CentralHeaderCommentSizeOffset;

				byte[] rawComment = newComment_.RawComment;

				updateFile.WriteLEShort( rawComment.Length );
				updateFile.Write( rawComment, 0, rawComment.Length );
				updateFile.SetLength( updateFile.Position );
			}

			if( archiveStorage_.UpdateMode == FileUpdateMode.Safe ) {
				Reopen( archiveStorage_.ConvertTemporaryToFinal() );
			} else {
				ReadEntries();
			}
		}

		/// <summary>
		/// Class used to sort updates.
		/// </summary>
		class UpdateComparer : IComparer {
			/// <summary>
			/// Compares two objects and returns a value indicating whether one is 
			/// less than, equal to or greater than the other.
			/// </summary>
			/// <param name="x">First object to compare</param>
			/// <param name="y">Second object to compare.</param>
			/// <returns>Compare result.</returns>
			public int Compare(
				object x,
				object y ) {
				BlubbUpdate zx = x as BlubbUpdate;
				BlubbUpdate zy = y as BlubbUpdate;

				int result;

				if( zx == null ) {
					if( zy == null ) {
						result = 0;
					} else {
						result = -1;
					}
				} else if( zy == null ) {
					result = 1;
				} else {
					int xCmdValue = ( ( zx.Command == UpdateCommand.Copy ) || ( zx.Command == UpdateCommand.Modify ) ) ? 0 : 1;
					int yCmdValue = ( ( zy.Command == UpdateCommand.Copy ) || ( zy.Command == UpdateCommand.Modify ) ) ? 0 : 1;

					result = xCmdValue - yCmdValue;
					if( result == 0 ) {
						long offsetDiff = zx.Entry.Offset - zy.Entry.Offset;
						if( offsetDiff < 0 ) {
							result = -1;
						} else if( offsetDiff == 0 ) {
							result = 0;
						} else {
							result = 1;
						}
					}
				}
				return result;
			}
		}

		void RunUpdates() {
			long sizeEntries = 0;
			long endOfStream = 0;
			bool allOk = true;
			bool directUpdate = false;
			long destinationPosition = 0; // NOT SFX friendly

			BlubbZipFile workFile;

			if( IsNewArchive ) {
				workFile = this;
				workFile.baseStream_.Position = 0;
				directUpdate = true;
			} else if( archiveStorage_.UpdateMode == FileUpdateMode.Direct ) {
				workFile = this;
				workFile.baseStream_.Position = 0;
				directUpdate = true;

				// Sort the updates by offset within copies/modifies, then adds.
				// This ensures that data required by copies will not be overwritten.
				updates_.Sort( new UpdateComparer() );
			} else {
				workFile = BlubbZipFile.Create( archiveStorage_.GetTemporaryOutput() );
				workFile.UseBlubb64 = UseBlubb64;

				if( key != null ) {
					workFile.key = (byte[])key.Clone();
				}
			}

			try {
				foreach( BlubbUpdate update in updates_ ) {
					if( update != null ) {
						switch( update.Command ) {
							case UpdateCommand.Copy:
								if( directUpdate ) {
									CopyEntryDirect( workFile, update, ref destinationPosition );
								} else {
									CopyEntry( workFile, update );
								}
								break;

							case UpdateCommand.Modify:
								// TODO: Direct modifying of an entry will take some legwork.
								ModifyEntry( workFile, update );
								break;

							case UpdateCommand.Add:
								if( !IsNewArchive && directUpdate ) {
									workFile.baseStream_.Position = destinationPosition;
								}

								AddEntry( workFile, update );

								if( directUpdate ) {
									destinationPosition = workFile.baseStream_.Position;
								}
								break;
						}
					}
				}

				if( !IsNewArchive && directUpdate ) {
					workFile.baseStream_.Position = destinationPosition;
				}

				long centralDirOffset = workFile.baseStream_.Position;

				foreach( BlubbUpdate update in updates_ ) {
					if( update != null ) {
						sizeEntries += workFile.WriteCentralDirectoryHeader( update.OutEntry );
					}
				}

				byte[] theComment = ( newComment_ != null ) ? newComment_.RawComment : BlubbZipConstants.ConvertToArray( comment_ );
				using( BlubbZipHelperStream zhs = new BlubbZipHelperStream( workFile.baseStream_ ) ) {
					zhs.WriteEndOfCentralDirectory( updateCount_, sizeEntries, centralDirOffset, theComment );
				}

				endOfStream = workFile.baseStream_.Position;

				// And now patch entries...
				foreach( BlubbUpdate update in updates_ ) {
					if( update != null ) {

						// If the size of the entry is zero leave the crc as 0 as well.
						// The calculated crc will be all bits on...
						if( ( update.CrcPatchOffset > 0 ) && ( update.OutEntry.CompressedSize > 0 ) ) {
							workFile.baseStream_.Position = update.CrcPatchOffset;
							workFile.WriteLEInt( (int)update.OutEntry.Crc );
						}

						if( update.SizePatchOffset > 0 ) {
							workFile.baseStream_.Position = update.SizePatchOffset;
							if( update.OutEntry.LocalHeaderRequiresBlubb64 ) {
								workFile.WriteLeLong( update.OutEntry.Size );
								workFile.WriteLeLong( update.OutEntry.CompressedSize );
							} else {
								workFile.WriteLEInt( (int)update.OutEntry.CompressedSize );
								workFile.WriteLEInt( (int)update.OutEntry.Size );
							}
						}
					}
				}
			} catch( Exception ) {
				allOk = false;
			} finally {
				if( directUpdate ) {
					if( allOk ) {
						workFile.baseStream_.Flush();
						workFile.baseStream_.SetLength( endOfStream );
					}
				} else {
					workFile.Close();
				}
			}

			if( allOk ) {
				if( directUpdate ) {
					isNewArchive_ = false;
					workFile.baseStream_.Flush();
					ReadEntries();
				} else {
					baseStream_.Close();
					Reopen( archiveStorage_.ConvertTemporaryToFinal() );
				}
			} else {
				workFile.Close();
				if( !directUpdate && ( workFile.Name != null ) ) {
					File.Delete( workFile.Name );
				}
			}
		}

		void CheckUpdating() {
			if( updates_ == null ) {
				throw new InvalidOperationException( "BeginUpdate has not been called" );
			}
		}



		// BlubbUpdate class
		/// <summary>
		/// Represents a pending update to a Blubb file.
		/// </summary>
		class BlubbUpdate {
			// Constructors
			public BlubbUpdate( string fileName, BlubbZipEntry entry ) {
				command_ = UpdateCommand.Add;
				entry_ = entry;
				filename_ = fileName;
			}

			[Obsolete]
			public BlubbUpdate( string fileName, string entryName, CompressionMethod compressionMethod ) {
				command_ = UpdateCommand.Add;
				entry_ = new BlubbZipEntry( entryName );
				entry_.CompressionMethod = compressionMethod;
				filename_ = fileName;
			}

			[Obsolete]
			public BlubbUpdate( string fileName, string entryName )
				: this( fileName, entryName, CompressionMethod.Deflated ) {
				// Do nothing.
			}

			[Obsolete]
			public BlubbUpdate( IStaticDataSource dataSource, string entryName, CompressionMethod compressionMethod ) {
				command_ = UpdateCommand.Add;
				entry_ = new BlubbZipEntry( entryName );
				entry_.CompressionMethod = compressionMethod;
				dataSource_ = dataSource;
			}

			public BlubbUpdate( IStaticDataSource dataSource, BlubbZipEntry entry ) {
				command_ = UpdateCommand.Add;
				entry_ = entry;
				dataSource_ = dataSource;
			}

			public BlubbUpdate( BlubbZipEntry original, BlubbZipEntry updated ) {
				throw new BlubbZipException( "Modify not currently supported" );
				/*
					command_ = UpdateCommand.Modify;
					entry_ = ( BlubbEntry )original.Clone();
					outEntry_ = ( BlubbEntry )updated.Clone();
				*/
			}

			public BlubbUpdate( UpdateCommand command, BlubbZipEntry entry ) {
				command_ = command;
				entry_ = (BlubbZipEntry)entry.Clone();
			}


			/// <summary>
			/// Copy an existing entry.
			/// </summary>
			/// <param name="entry">The existing entry to copy.</param>
			public BlubbUpdate( BlubbZipEntry entry )
				: this( UpdateCommand.Copy, entry ) {
				// Do nothing.
			}


			/// <summary>
			/// Get the <see cref="BlubbEntry"/> for this update.
			/// </summary>
			/// <remarks>This is the source or original entry.</remarks>
			public BlubbZipEntry Entry {
				get {
					return entry_;
				}
			}

			/// <summary>
			/// Get the <see cref="BlubbEntry"/> that will be written to the updated/new file.
			/// </summary>
			public BlubbZipEntry OutEntry {
				get {
					if( outEntry_ == null ) {
						outEntry_ = (BlubbZipEntry)entry_.Clone();
					}

					return outEntry_;
				}
			}

			/// <summary>
			/// Get the command for this update.
			/// </summary>
			public UpdateCommand Command {
				get {
					return command_;
				}
			}

			/// <summary>
			/// Get the filename if any for this update.  Null if none exists.
			/// </summary>
			public string Filename {
				get {
					return filename_;
				}
			}

			/// <summary>
			/// Get/set the location of the size patch for this update.
			/// </summary>
			public long SizePatchOffset {
				get {
					return sizePatchOffset_;
				}
				set {
					sizePatchOffset_ = value;
				}
			}

			/// <summary>
			/// Get /set the location of the crc patch for this update.
			/// </summary>
			public long CrcPatchOffset {
				get {
					return crcPatchOffset_;
				}
				set {
					crcPatchOffset_ = value;
				}
			}

			public Stream GetSource() {
				Stream result = null;
				if( dataSource_ != null ) {
					result = dataSource_.GetSource();
				}

				return result;
			}

			// Instance Fields
			BlubbZipEntry entry_;
			BlubbZipEntry outEntry_;
			UpdateCommand command_;
			IStaticDataSource dataSource_;
			string filename_;
			long sizePatchOffset_ = -1;
			long crcPatchOffset_ = -1;

		}




		// Disposing

		// IDisposable Members
		void IDisposable.Dispose() {
			Close();
		}


		void DisposeInternal( bool disposing ) {
			if( !isDisposed_ ) {
				isDisposed_ = true;
				entries_ = new BlubbZipEntry[ 0 ];

				if( IsStreamOwner && ( baseStream_ != null ) ) {
					lock( baseStream_ ) {
						baseStream_.Close();
					}
				}

				PostUpdateCleanup();
			}
		}

		/// <summary>
		/// Releases the unmanaged resources used by the this instance and optionally releases the managed resources.
		/// </summary>
		/// <param name="disposing">true to release both managed and unmanaged resources;
		/// false to release only unmanaged resources.</param>
		protected virtual void Dispose( bool disposing ) {
			DisposeInternal( disposing );
		}



		// Internal routines
		// Reading
		/// <summary>
		/// Read an unsigned short in little endian byte order.
		/// </summary>
		/// <returns>Returns the value read.</returns>
		/// <exception cref="EndOfStreamException">
		/// The stream ends prematurely
		/// </exception>
		ushort ReadLEUshort() {
			int data1 = baseStream_.ReadByte();

			if( data1 < 0 ) {
				throw new EndOfStreamException( "End of stream" );
			}

			int data2 = baseStream_.ReadByte();

			if( data2 < 0 ) {
				throw new EndOfStreamException( "End of stream" );
			}


			return unchecked( (ushort)( (ushort)data1 | (ushort)( data2 << 8 ) ) );
		}

		/// <summary>
		/// Read a uint in little endian byte order.
		/// </summary>
		/// <returns>Returns the value read.</returns>
		/// <exception cref="IOException">
		/// An i/o error occurs.
		/// </exception>
		/// <exception cref="System.IO.EndOfStreamException">
		/// The file ends prematurely
		/// </exception>
		uint ReadLEUint() {
			return (uint)( ReadLEUshort() | ( ReadLEUshort() << 16 ) );
		}

		ulong ReadLEUlong() {
			return ReadLEUint() | ( (ulong)ReadLEUint() << 32 );
		}


		// NOTE this returns the offset of the first byte after the signature.
		long LocateBlockWithSignature( int signature, long endLocation, int minimumBlockSize, int maximumVariableData ) {
			using( BlubbZipHelperStream les = new BlubbZipHelperStream( baseStream_ ) ) {
				return les.LocateBlockWithSignature( signature, endLocation, minimumBlockSize, maximumVariableData );
			}
		}

		/// <summary>
		/// Search for and read the central directory of a blubb file filling the entries array.
		/// </summary>
		/// <exception cref="System.IO.IOException">
		/// An i/o error occurs.
		/// </exception>
		/// <exception cref="GodLesZ.Library.BlubbZip.Blubb.BlubbException">
		/// The central directory is malformed or cannot be found
		/// </exception>
		void ReadEntries() {
			// Search for the End Of Central Directory.  When a blubb comment is
			// present the directory will start earlier
			// 
			// The search is limited to 64K which is the maximum size of a trailing comment field to aid speed.
			// This should be compatible with both SFX and ZIP files but has only been tested for Blubb files
			// If a SFX file has the Blubb data attached as a resource and there are other resources occuring later then
			// this could be invalid.
			// Could also speed this up by reading memory in larger blocks.			

			if( baseStream_.CanSeek == false ) {
				throw new BlubbZipException( "BlubbFile stream must be seekable" );
			}

			long locatedEndOfCentralDir = LocateBlockWithSignature( BlubbZipConstants.EndOfCentralDirectorySignature, baseStream_.Length, BlubbZipConstants.EndOfCentralRecordBaseSize, 0xffff );

			if( locatedEndOfCentralDir < 0 )
				throw new BlubbZipException( "Cannot find central directory" );

			// Read end of central directory record
			ushort thisDiskNumber = ReadLEUshort();
			ushort startCentralDirDisk = ReadLEUshort();
			ulong entriesForThisDisk = ReadLEUshort();
			ulong entriesForWholeCentralDir = ReadLEUshort();
			ulong centralDirSize = ReadLEUint();
			long offsetOfCentralDir = ReadLEUint();
			uint commentSize = ReadLEUshort();

			if( commentSize > 0 ) {
				byte[] comment = new byte[ commentSize ];

				StreamUtils.ReadFully( baseStream_, comment );
				comment_ = BlubbZipConstants.ConvertToString( comment );
			} else {
				comment_ = string.Empty;
			}

			bool isBlubb64 = false;

			// Check if blubb64 header information is required.
			if( ( thisDiskNumber == 0xffff ) ||
				( startCentralDirDisk == 0xffff ) ||
				( entriesForThisDisk == 0xffff ) ||
				( entriesForWholeCentralDir == 0xffff ) ||
				( centralDirSize == 0xffffffff ) ||
				( offsetOfCentralDir == 0xffffffff ) ) {
				isBlubb64 = true;

				long offset = LocateBlockWithSignature( BlubbZipConstants.Blubb64CentralDirLocatorSignature, locatedEndOfCentralDir, 0, 0x1000 );
				if( offset < 0 ) {
					throw new BlubbZipException( "Cannot find Blubb64 locator" );
				}

				// number of the disk with the start of the blubb64 end of central directory 4 bytes 
				// relative offset of the blubb64 end of central directory record 8 bytes 
				// total number of disks 4 bytes 
				ReadLEUint(); // startDisk64 is not currently used
				ulong offset64 = ReadLEUlong();
				uint totalDisks = ReadLEUint();

				baseStream_.Position = (long)offset64;
				long sig64 = ReadLEUint();

				if( sig64 != BlubbZipConstants.Blubb64CentralFileHeaderSignature ) {
					throw new BlubbZipException( string.Format( "Invalid Blubb64 Central directory signature at {0:X}", offset64 ) );
				}

				// NOTE: Record size = SizeOfFixedFields + SizeOfVariableData - 12.
				ulong recordSize = (ulong)ReadLEUlong();
				int versionMadeBy = ReadLEUshort();
				int versionToExtract = ReadLEUshort();
				uint thisDisk = ReadLEUint();
				uint centralDirDisk = ReadLEUint();
				entriesForThisDisk = ReadLEUlong();
				entriesForWholeCentralDir = ReadLEUlong();
				centralDirSize = ReadLEUlong();
				offsetOfCentralDir = (long)ReadLEUlong();

				// NOTE: blubb64 extensible data sector (variable size) is ignored.
			}

			entries_ = new BlubbZipEntry[ entriesForThisDisk ];

			// SFX/embedded support, find the offset of the first entry vis the start of the stream
			// This applies to Blubb files that are appended to the end of an SFX stub.
			// Or are appended as a resource to an executable.
			// Blubb files created by some archivers have the offsets altered to reflect the true offsets
			// and so dont require any adjustment here...
			// TODO: Difficulty with Blubb64 and SFX offset handling needs resolution - maths?
			if( !isBlubb64 && ( offsetOfCentralDir < locatedEndOfCentralDir - ( 4 + (long)centralDirSize ) ) ) {
				offsetOfFirstEntry = locatedEndOfCentralDir - ( 4 + (long)centralDirSize + offsetOfCentralDir );
				if( offsetOfFirstEntry <= 0 ) {
					throw new BlubbZipException( "Invalid embedded blubb archive" );
				}
			}

			baseStream_.Seek( offsetOfFirstEntry + offsetOfCentralDir, SeekOrigin.Begin );

			for( ulong i = 0; i < entriesForThisDisk; i++ ) {
				if( ReadLEUint() != BlubbZipConstants.CentralHeaderSignature ) {
					throw new BlubbZipException( "Wrong Central Directory signature" );
				}

				int versionMadeBy = ReadLEUshort();
				int versionToExtract = ReadLEUshort();
				int bitFlags = ReadLEUshort();
				int method = ReadLEUshort();
				uint dostime = ReadLEUint();
				uint crc = ReadLEUint();
				long csize = (long)ReadLEUint();
				long size = (long)ReadLEUint();
				int nameLen = ReadLEUshort();
				int extraLen = ReadLEUshort();
				int commentLen = ReadLEUshort();

				int diskStartNo = ReadLEUshort();  // Not currently used
				int internalAttributes = ReadLEUshort();  // Not currently used

				uint externalAttributes = ReadLEUint();
				long offset = ReadLEUint();

				byte[] buffer = new byte[ Math.Max( nameLen, commentLen ) ];

				StreamUtils.ReadFully( baseStream_, buffer, 0, nameLen );
				string name = BlubbZipConstants.ConvertToStringExt( bitFlags, buffer, nameLen );

				BlubbZipEntry entry = new BlubbZipEntry( name, versionToExtract, versionMadeBy, (CompressionMethod)method );
				entry.Crc = crc & 0xffffffffL;
				entry.Size = size & 0xffffffffL;
				entry.CompressedSize = csize & 0xffffffffL;
				entry.Flags = bitFlags;
				entry.DosTime = (uint)dostime;
				entry.BlubbFileIndex = (long)i;
				entry.Offset = offset;
				entry.ExternalFileAttributes = (int)externalAttributes;

				if( ( bitFlags & 8 ) == 0 ) {
					entry.CryptoCheckValue = (byte)( crc >> 24 );
				} else {
					entry.CryptoCheckValue = (byte)( ( dostime >> 8 ) & 0xff );
				}

				if( extraLen > 0 ) {
					byte[] extra = new byte[ extraLen ];
					StreamUtils.ReadFully( baseStream_, extra );
					entry.ExtraData = extra;
				}

				entry.ProcessExtraData( false );

				if( commentLen > 0 ) {
					StreamUtils.ReadFully( baseStream_, buffer, 0, commentLen );
					entry.Comment = BlubbZipConstants.ConvertToStringExt( bitFlags, buffer, commentLen );
				}

				entries_[ i ] = entry;
			}
		}

		/// <summary>
		/// Locate the data for a given entry.
		/// </summary>
		/// <returns>
		/// The start offset of the data.
		/// </returns>
		/// <exception cref="System.IO.EndOfStreamException">
		/// The stream ends prematurely
		/// </exception>
		/// <exception cref="GodLesZ.Library.BlubbZip.Blubb.BlubbException">
		/// The local header signature is invalid, the entry and central header file name lengths are different
		/// or the local and entry compression methods dont match
		/// </exception>
		long LocateEntry( BlubbZipEntry entry ) {
			return TestLocalHeader( entry, HeaderTest.Extract );
		}

		Stream CreateAndInitDecryptionStream( Stream baseStream, BlubbZipEntry entry ) {
			CryptoStream result = null;

			if( ( entry.Version < BlubbZipConstants.VersionStrongEncryption )
				|| ( entry.Flags & (int)GeneralBitFlags.StrongEncryption ) == 0 ) {
				PkblubbClassicManaged classicManaged = new PkblubbClassicManaged();

				OnKeysRequired( entry.Name );
				if( HaveKeys == false ) {
					throw new BlubbZipException( "No password available for encrypted stream" );
				}

				result = new CryptoStream( baseStream, classicManaged.CreateDecryptor( key, null ), CryptoStreamMode.Read );
				CheckClassicPassword( result, entry );
			} else {
				throw new BlubbZipException( "Decryption method not supported" );
			}

			return result;
		}

		Stream CreateAndInitEncryptionStream( Stream baseStream, BlubbZipEntry entry ) {
			CryptoStream result = null;
			if( ( entry.Version < BlubbZipConstants.VersionStrongEncryption )
				|| ( entry.Flags & (int)GeneralBitFlags.StrongEncryption ) == 0 ) {
				PkblubbClassicManaged classicManaged = new PkblubbClassicManaged();

				OnKeysRequired( entry.Name );
				if( HaveKeys == false ) {
					throw new BlubbZipException( "No password available for encrypted stream" );
				}

				// Closing a CryptoStream will close the base stream as well so wrap it in an UncompressedStream
				// which doesnt do this.
				result = new CryptoStream( new UncompressedStream( baseStream ),
					classicManaged.CreateEncryptor( key, null ), CryptoStreamMode.Write );

				if( ( entry.Crc < 0 ) || ( entry.Flags & 8 ) != 0 ) {
					WriteEncryptionHeader( result, entry.DosTime << 16 );
				} else {
					WriteEncryptionHeader( result, entry.Crc );
				}
			}
			return result;
		}

		static void CheckClassicPassword( CryptoStream classicCryptoStream, BlubbZipEntry entry ) {
			byte[] cryptbuffer = new byte[ BlubbZipConstants.CryptoHeaderSize ];
			StreamUtils.ReadFully( classicCryptoStream, cryptbuffer );
			if( cryptbuffer[ BlubbZipConstants.CryptoHeaderSize - 1 ] != entry.CryptoCheckValue ) {
				throw new BlubbZipException( "Invalid password" );
			}
		}

		static void WriteEncryptionHeader( Stream stream, long crcValue ) {
			byte[] cryptBuffer = new byte[ BlubbZipConstants.CryptoHeaderSize ];
			Random rnd = new Random();
			rnd.NextBytes( cryptBuffer );
			cryptBuffer[ 11 ] = (byte)( crcValue >> 24 );
			stream.Write( cryptBuffer, 0, cryptBuffer.Length );
		}



		// Instance Fields
		bool isDisposed_;
		string name_;
		string comment_;
		Stream baseStream_;
		bool isStreamOwner;
		long offsetOfFirstEntry;
		BlubbZipEntry[] entries_;
		byte[] key;
		bool isNewArchive_;

		// Default is dynamic which is not backwards compatible and can cause problems
		// with XP's built in compression which cant read Blubb64 archives.
		// However it does avoid the situation were a large file is added and cannot be completed correctly.
		// Hint: Set always BlubbEntry size before they are added to an archive and this setting isnt needed.
		UseBlubb64 useBlubb64_ = UseBlubb64.Dynamic;

		// Blubb Update Instance Fields
		ArrayList updates_;
		long updateCount_; // Count is managed manually as updates_ can contain nulls!
		Hashtable updateIndex_;
		IArchiveStorage archiveStorage_;
		IDynamicDataSource updateDataSource_;
		bool contentsEdited_;
		int bufferSize_ = DefaultBufferSize;
		byte[] copyBuffer_;
		BlubbString newComment_;
		bool commentEdited_;
		IBlubbZipEntryFactory updateEntryFactory_ = new BlubbZipEntryFactory();



		// Support Classes
		/// <summary>
		/// Represents a string from a <see cref="BlubbFile"/> which is stored as an array of bytes.
		/// </summary>
		class BlubbString {
			// Constructors
			/// <summary>
			/// Initialise a <see cref="BlubbString"/> with a string.
			/// </summary>
			/// <param name="comment">The textual string form.</param>
			public BlubbString( string comment ) {
				comment_ = comment;
				isSourceString_ = true;
			}

			/// <summary>
			/// Initialise a <see cref="BlubbString"/> using a string in its binary 'raw' form.
			/// </summary>
			/// <param name="rawString"></param>
			public BlubbString( byte[] rawString ) {
				rawComment_ = rawString;
			}


			/// <summary>
			/// Get a value indicating the original source of data for this instance.
			/// True if the source was a string; false if the source was binary data.
			/// </summary>
			public bool IsSourceString {
				get {
					return isSourceString_;
				}
			}

			/// <summary>
			/// Get the length of the comment when represented as raw bytes.
			/// </summary>
			public int RawLength {
				get {
					MakeBytesAvailable();
					return rawComment_.Length;
				}
			}

			/// <summary>
			/// Get the comment in its 'raw' form as plain bytes.
			/// </summary>
			public byte[] RawComment {
				get {
					MakeBytesAvailable();
					return (byte[])rawComment_.Clone();
				}
			}

			/// <summary>
			/// Reset the comment to its initial state.
			/// </summary>
			public void Reset() {
				if( isSourceString_ ) {
					rawComment_ = null;
				} else {
					comment_ = null;
				}
			}

			void MakeTextAvailable() {
				if( comment_ == null ) {
					comment_ = BlubbZipConstants.ConvertToString( rawComment_ );
				}
			}

			void MakeBytesAvailable() {
				if( rawComment_ == null ) {
					rawComment_ = BlubbZipConstants.ConvertToArray( comment_ );
				}
			}

			/// <summary>
			/// Implicit conversion of comment to a string.
			/// </summary>
			/// <param name="blubbString">The <see cref="BlubbString"/> to convert to a string.</param>
			/// <returns>The textual equivalent for the input value.</returns>
			static public implicit operator string( BlubbString blubbString ) {
				blubbString.MakeTextAvailable();
				return blubbString.comment_;
			}

			// Instance Fields
			string comment_;
			byte[] rawComment_;
			bool isSourceString_;

		}

		/// <summary>
		/// An <see cref="IEnumerator">enumerator</see> for <see cref="BlubbEntry">Blubb entries</see>
		/// </summary>
		public class BlubbEntryEnumerator : IEnumerator, IDisposable {
			private BlubbZipEntry[] mEntrys;
			private int mIndex = -1;

			public object Current {
				get { return mEntrys[ mIndex ]; }
			}


			public BlubbEntryEnumerator( BlubbZipEntry[] entries ) {
				mEntrys = entries;
			}


			public void Reset() {
				mIndex = -1;
			}

			public bool MoveNext() {
				return ( ++mIndex < mEntrys.Length );
			}

			public void Dispose() {
				mEntrys = null;
			}
		}

		/// <summary>
		/// An <see cref="UncompressedStream"/> is a stream that you can write uncompressed data
		/// to and flush, but cannot read, seek or do anything else to.
		/// </summary>
		public class UncompressedStream : Stream {
			private Stream baseStream_;

			/// <summary>
			/// Gets a value indicating whether the current stream supports reading.
			/// </summary>
			public override bool CanRead {
				get { return false; }
			}

			/// <summary>
			/// Gets a value indicating whether the current stream supports writing.
			/// </summary>
			public override bool CanWrite {
				get { return baseStream_.CanWrite; }
			}

			/// <summary>
			/// Gets a value indicating whether the current stream supports seeking.
			/// </summary>
			public override bool CanSeek {
				get { return false; }
			}

			/// <summary>
			/// Get the length in bytes of the stream.
			/// </summary>
			public override long Length {
				get { return 0; }
			}

			/// <summary>
			/// Gets or sets the position within the current stream.
			/// </summary>
			public override long Position {
				get { return baseStream_.Position; }

				set { }
			}


			public UncompressedStream( Stream baseStream ) {
				baseStream_ = baseStream;
			}



			/// <summary>
			/// Close this stream instance.
			/// </summary>
			public override void Close() {
				// Do nothing
			}


			/// <summary>
			/// Write any buffered data to underlying storage.
			/// </summary>
			public override void Flush() {
				baseStream_.Flush();
			}


			/// <summary>
			/// Reads a sequence of bytes from the current stream and advances the position within the stream by the number of bytes read.
			/// </summary>
			/// <param name="buffer">An array of bytes. When this method returns, the buffer contains the specified byte array with the values between offset and (offset + count - 1) replaced by the bytes read from the current source.</param>
			/// <param name="offset">The zero-based byte offset in buffer at which to begin storing the data read from the current stream.</param>
			/// <param name="count">The maximum number of bytes to be read from the current stream.</param>
			/// <returns>
			/// The total number of bytes read into the buffer. This can be less than the number of bytes requested if that many bytes are not currently available, or zero (0) if the end of the stream has been reached.
			/// </returns>
			/// <exception cref="T:System.ArgumentException">The sum of offset and count is larger than the buffer length. </exception>
			/// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
			/// <exception cref="T:System.NotSupportedException">The stream does not support reading. </exception>
			/// <exception cref="T:System.ArgumentNullException">buffer is null. </exception>
			/// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
			/// <exception cref="T:System.ArgumentOutOfRangeException">offset or count is negative. </exception>
			public override int Read( byte[] buffer, int offset, int count ) {
				return 0;
			}

			/// <summary>
			/// Sets the position within the current stream.
			/// </summary>
			/// <param name="offset">A byte offset relative to the origin parameter.</param>
			/// <param name="origin">A value of type <see cref="T:System.IO.SeekOrigin"></see> indicating the reference point used to obtain the new position.</param>
			/// <returns>
			/// The new position within the current stream.
			/// </returns>
			/// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
			/// <exception cref="T:System.NotSupportedException">The stream does not support seeking, such as if the stream is constructed from a pipe or console output. </exception>
			/// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
			public override long Seek( long offset, SeekOrigin origin ) {
				return 0;
			}

			/// <summary>
			/// Sets the length of the current stream.
			/// </summary>
			/// <param name="value">The desired length of the current stream in bytes.</param>
			/// <exception cref="T:System.NotSupportedException">The stream does not support both writing and seeking, such as if the stream is constructed from a pipe or console output. </exception>
			/// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
			/// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
			public override void SetLength( long value ) {
			}

			/// <summary>
			/// Writes a sequence of bytes to the current stream and advances the current position within this stream by the number of bytes written.
			/// </summary>
			/// <param name="buffer">An array of bytes. This method copies count bytes from buffer to the current stream.</param>
			/// <param name="offset">The zero-based byte offset in buffer at which to begin copying bytes to the current stream.</param>
			/// <param name="count">The number of bytes to be written to the current stream.</param>
			/// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
			/// <exception cref="T:System.NotSupportedException">The stream does not support writing. </exception>
			/// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
			/// <exception cref="T:System.ArgumentNullException">buffer is null. </exception>
			/// <exception cref="T:System.ArgumentException">The sum of offset and count is greater than the buffer length. </exception>
			/// <exception cref="T:System.ArgumentOutOfRangeException">offset or count is negative. </exception>
			public override void Write( byte[] buffer, int offset, int count ) {
				baseStream_.Write( buffer, offset, count );
			}

		}

		/// <summary>
		/// A <see cref="PartialInputStream"/> is an <see cref="InflaterInputStream"/>
		/// whose data is only a part or subsection of a file.
		/// </summary>
		class PartialInputStream : Stream {
			// Constructors
			/// <summary>
			/// Initialise a new instance of the <see cref="PartialInputStream"/> class.
			/// </summary>
			/// <param name="blubbFile">The <see cref="BlubbFile"/> containing the underlying stream to use for IO.</param>
			/// <param name="start">The start of the partial data.</param>
			/// <param name="length">The length of the partial data.</param>
			public PartialInputStream( BlubbZipFile blubbFile, long start, long length ) {
				start_ = start;
				length_ = length;

				// Although this is the only time the blubbfile is used
				// keeping a reference here prevents premature closure of
				// this blubb file and thus the baseStream_.

				// Code like this will cause apparently random failures depending
				// on the size of the files and when garbage is collected.
				//
				// BlubbFile z = new BlubbFile (stream);
				// Stream reader = z.GetInputStream(0);
				// uses reader here....
				blubbFile_ = blubbFile;
				baseStream_ = blubbFile_.baseStream_;
				readPos_ = start;
				end_ = start + length;
			}


			/// <summary>
			/// Read a byte from this stream.
			/// </summary>
			/// <returns>Returns the byte read or -1 on end of stream.</returns>
			public override int ReadByte() {
				if( readPos_ >= end_ ) {
					// -1 is the correct value at end of stream.
					return -1;
				}

				lock( baseStream_ ) {
					baseStream_.Seek( readPos_++, SeekOrigin.Begin );
					return baseStream_.ReadByte();
				}
			}

			/// <summary>
			/// Close this <see cref="PartialInputStream">partial input stream</see>.
			/// </summary>
			/// <remarks>
			/// The underlying stream is not closed.  Close the parent BlubbFile class to do that.
			/// </remarks>
			public override void Close() {
				// Do nothing at all!
			}

			/// <summary>
			/// Reads a sequence of bytes from the current stream and advances the position within the stream by the number of bytes read.
			/// </summary>
			/// <param name="buffer">An array of bytes. When this method returns, the buffer contains the specified byte array with the values between offset and (offset + count - 1) replaced by the bytes read from the current source.</param>
			/// <param name="offset">The zero-based byte offset in buffer at which to begin storing the data read from the current stream.</param>
			/// <param name="count">The maximum number of bytes to be read from the current stream.</param>
			/// <returns>
			/// The total number of bytes read into the buffer. This can be less than the number of bytes requested if that many bytes are not currently available, or zero (0) if the end of the stream has been reached.
			/// </returns>
			/// <exception cref="T:System.ArgumentException">The sum of offset and count is larger than the buffer length. </exception>
			/// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
			/// <exception cref="T:System.NotSupportedException">The stream does not support reading. </exception>
			/// <exception cref="T:System.ArgumentNullException">buffer is null. </exception>
			/// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
			/// <exception cref="T:System.ArgumentOutOfRangeException">offset or count is negative. </exception>
			public override int Read( byte[] buffer, int offset, int count ) {
				lock( baseStream_ ) {
					if( count > end_ - readPos_ ) {
						count = (int)( end_ - readPos_ );
						if( count == 0 ) {
							return 0;
						}
					}

					baseStream_.Seek( readPos_, SeekOrigin.Begin );
					int readCount = baseStream_.Read( buffer, offset, count );
					if( readCount > 0 ) {
						readPos_ += readCount;
					}
					return readCount;
				}
			}

			/// <summary>
			/// Writes a sequence of bytes to the current stream and advances the current position within this stream by the number of bytes written.
			/// </summary>
			/// <param name="buffer">An array of bytes. This method copies count bytes from buffer to the current stream.</param>
			/// <param name="offset">The zero-based byte offset in buffer at which to begin copying bytes to the current stream.</param>
			/// <param name="count">The number of bytes to be written to the current stream.</param>
			/// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
			/// <exception cref="T:System.NotSupportedException">The stream does not support writing. </exception>
			/// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
			/// <exception cref="T:System.ArgumentNullException">buffer is null. </exception>
			/// <exception cref="T:System.ArgumentException">The sum of offset and count is greater than the buffer length. </exception>
			/// <exception cref="T:System.ArgumentOutOfRangeException">offset or count is negative. </exception>
			public override void Write( byte[] buffer, int offset, int count ) {
				throw new NotSupportedException();
			}

			/// <summary>
			/// When overridden in a derived class, sets the length of the current stream.
			/// </summary>
			/// <param name="value">The desired length of the current stream in bytes.</param>
			/// <exception cref="T:System.NotSupportedException">The stream does not support both writing and seeking, such as if the stream is constructed from a pipe or console output. </exception>
			/// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
			/// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
			public override void SetLength( long value ) {
				throw new NotSupportedException();
			}

			/// <summary>
			/// When overridden in a derived class, sets the position within the current stream.
			/// </summary>
			/// <param name="offset">A byte offset relative to the origin parameter.</param>
			/// <param name="origin">A value of type <see cref="T:System.IO.SeekOrigin"></see> indicating the reference point used to obtain the new position.</param>
			/// <returns>
			/// The new position within the current stream.
			/// </returns>
			/// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
			/// <exception cref="T:System.NotSupportedException">The stream does not support seeking, such as if the stream is constructed from a pipe or console output. </exception>
			/// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
			public override long Seek( long offset, SeekOrigin origin ) {
				long newPos = readPos_;

				switch( origin ) {
					case SeekOrigin.Begin:
						newPos = start_ + offset;
						break;

					case SeekOrigin.Current:
						newPos = readPos_ + offset;
						break;

					case SeekOrigin.End:
						newPos = end_ + offset;
						break;
				}

				if( newPos < start_ ) {
					throw new ArgumentException( "Negative position is invalid" );
				}

				if( newPos >= end_ ) {
					throw new IOException( "Cannot seek past end" );
				}
				readPos_ = newPos;
				return readPos_;
			}

			/// <summary>
			/// Clears all buffers for this stream and causes any buffered data to be written to the underlying device.
			/// </summary>
			/// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
			public override void Flush() {
				// Nothing to do.
			}

			/// <summary>
			/// Gets or sets the position within the current stream.
			/// </summary>
			/// <value></value>
			/// <returns>The current position within the stream.</returns>
			/// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
			/// <exception cref="T:System.NotSupportedException">The stream does not support seeking. </exception>
			/// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
			public override long Position {
				get {
					return readPos_ - start_;
				}
				set {
					long newPos = start_ + value;

					if( newPos < start_ ) {
						throw new ArgumentException( "Negative position is invalid" );
					}

					if( newPos >= end_ ) {
						throw new InvalidOperationException( "Cannot seek past end" );
					}
					readPos_ = newPos;
				}
			}

			/// <summary>
			/// Gets the length in bytes of the stream.
			/// </summary>
			/// <value></value>
			/// <returns>A long value representing the length of the stream in bytes.</returns>
			/// <exception cref="T:System.NotSupportedException">A class derived from Stream does not support seeking. </exception>
			/// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed. </exception>
			public override long Length {
				get {
					return length_;
				}
			}

			/// <summary>
			/// Gets a value indicating whether the current stream supports writing.
			/// </summary>
			/// <value>false</value>
			/// <returns>true if the stream supports writing; otherwise, false.</returns>
			public override bool CanWrite {
				get {
					return false;
				}
			}

			/// <summary>
			/// Gets a value indicating whether the current stream supports seeking.
			/// </summary>
			/// <value>true</value>
			/// <returns>true if the stream supports seeking; otherwise, false.</returns>
			public override bool CanSeek {
				get {
					return true;
				}
			}

			/// <summary>
			/// Gets a value indicating whether the current stream supports reading.
			/// </summary>
			/// <value>true.</value>
			/// <returns>true if the stream supports reading; otherwise, false.</returns>
			public override bool CanRead {
				get {
					return true;
				}
			}

			/// <summary>
			/// Gets a value that determines whether the current stream can time out.
			/// </summary>
			/// <value></value>
			/// <returns>A value that determines whether the current stream can time out.</returns>
			public override bool CanTimeout {
				get {
					return baseStream_.CanTimeout;
				}
			}
			// Instance Fields
			BlubbZipFile blubbFile_;
			Stream baseStream_;
			long start_;
			long length_;
			long readPos_;
			long end_;

		}

	}



	// DataSources
	/// <summary>
	/// Provides a static way to obtain a source of data for an entry.
	/// </summary>
	public interface IStaticDataSource {
		/// <summary>
		/// Get a source of data by creating a new stream.
		/// </summary>
		/// <returns>Returns a <see cref="Stream"/> to use for compression input.</returns>
		/// <remarks>Ideally a new stream is created and opened to achieve this, to avoid locking problems.</remarks>
		Stream GetSource();
	}

	/// <summary>
	/// Represents a source of data that can dynamically provide
	/// multiple <see cref="Stream">data sources</see> based on the parameters passed.
	/// </summary>
	public interface IDynamicDataSource {
		/// <summary>
		/// Get a data source.
		/// </summary>
		/// <param name="entry">The <see cref="BlubbEntry"/> to get a source for.</param>
		/// <param name="name">The name for data if known.</param>
		/// <returns>Returns a <see cref="Stream"/> to use for compression input.</returns>
		/// <remarks>Ideally a new stream is created and opened to achieve this, to avoid locking problems.</remarks>
		Stream GetSource( BlubbZipEntry entry, string name );
	}

	/// <summary>
	/// Default implementation of a <see cref="IStaticDataSource"/> for use with files stored on disk.
	/// </summary>
	public class StaticDiskDataSource : IStaticDataSource {
		/// <summary>
		/// Initialise a new instnace of <see cref="StaticDiskDataSource"/>
		/// </summary>
		/// <param name="fileName">The name of the file to obtain data from.</param>
		public StaticDiskDataSource( string fileName ) {
			fileName_ = fileName;
		}

		// IDataSource Members

		/// <summary>
		/// Get a <see cref="Stream"/> providing data.
		/// </summary>
		/// <returns>Returns a <see cref="Stream"/> provising data.</returns>
		public Stream GetSource() {
			return File.OpenRead( fileName_ );
		}


		// Instance Fields
		string fileName_;

	}


	/// <summary>
	/// Default implementation of <see cref="IDynamicDataSource"/> for files stored on disk.
	/// </summary>
	public class DynamicDiskDataSource : IDynamicDataSource {
		/// <summary>
		/// Initialise a default instance of <see cref="DynamicDiskDataSource"/>.
		/// </summary>
		public DynamicDiskDataSource() {
		}

		// IDataSource Members
		/// <summary>
		/// Get a <see cref="Stream"/> providing data for an entry.
		/// </summary>
		/// <param name="entry">The entry to provide data for.</param>
		/// <param name="name">The file name for data if known.</param>
		/// <returns>Returns a stream providing data; or null if not available</returns>
		public Stream GetSource( BlubbZipEntry entry, string name ) {
			Stream result = null;

			if( name != null ) {
				result = File.OpenRead( name );
			}

			return result;
		}


	}



	// Archive Storage
	/// <summary>
	/// Defines facilities for data storage when updating Blubb Archives.
	/// </summary>
	public interface IArchiveStorage {
		/// <summary>
		/// Get the <see cref="FileUpdateMode"/> to apply during updates.
		/// </summary>
		FileUpdateMode UpdateMode {
			get;
		}

		/// <summary>
		/// Get an empty <see cref="Stream"/> that can be used for temporary output.
		/// </summary>
		/// <returns>Returns a temporary output <see cref="Stream"/></returns>
		/// <seealso cref="ConvertTemporaryToFinal"></seealso>
		Stream GetTemporaryOutput();

		/// <summary>
		/// Convert a temporary output stream to a final stream.
		/// </summary>
		/// <returns>The resulting final <see cref="Stream"/></returns>
		/// <seealso cref="GetTemporaryOutput"/>
		Stream ConvertTemporaryToFinal();

		/// <summary>
		/// Make a temporary copy of the original stream.
		/// </summary>
		/// <param name="stream">The <see cref="Stream"/> to copy.</param>
		/// <returns>Returns a temporary output <see cref="Stream"/> that is a copy of the input.</returns>
		Stream MakeTemporaryCopy( Stream stream );

		/// <summary>
		/// Return a stream suitable for performing direct updates on the original source.
		/// </summary>
		/// <param name="stream">The current stream.</param>
		/// <returns>Returns a stream suitable for direct updating.</returns>
		/// <remarks>This may be the current stream passed.</remarks>
		Stream OpenForDirectUpdate( Stream stream );

		/// <summary>
		/// Dispose of this instance.
		/// </summary>
		void Dispose();
	}

	/// <summary>
	/// An abstract <see cref="IArchiveStorage"/> suitable for extension by inheritance.
	/// </summary>
	abstract public class BaseArchiveStorage : IArchiveStorage {
		// Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="BaseArchiveStorage"/> class.
		/// </summary>
		/// <param name="updateMode">The update mode.</param>
		protected BaseArchiveStorage( FileUpdateMode updateMode ) {
			updateMode_ = updateMode;
		}


		// IArchiveStorage Members

		/// <summary>
		/// Gets a temporary output <see cref="Stream"/>
		/// </summary>
		/// <returns>Returns the temporary output stream.</returns>
		/// <seealso cref="ConvertTemporaryToFinal"></seealso>
		public abstract Stream GetTemporaryOutput();

		/// <summary>
		/// Converts the temporary <see cref="Stream"/> to its final form.
		/// </summary>
		/// <returns>Returns a <see cref="Stream"/> that can be used to read
		/// the final storage for the archive.</returns>
		/// <seealso cref="GetTemporaryOutput"/>
		public abstract Stream ConvertTemporaryToFinal();

		/// <summary>
		/// Make a temporary copy of a <see cref="Stream"/>.
		/// </summary>
		/// <param name="stream">The <see cref="Stream"/> to make a copy of.</param>
		/// <returns>Returns a temporary output <see cref="Stream"/> that is a copy of the input.</returns>
		public abstract Stream MakeTemporaryCopy( Stream stream );

		/// <summary>
		/// Return a stream suitable for performing direct updates on the original source.
		/// </summary>
		/// <param name="stream">The <see cref="Stream"/> to open for direct update.</param>
		/// <returns>Returns a stream suitable for direct updating.</returns>
		public abstract Stream OpenForDirectUpdate( Stream stream );

		/// <summary>
		/// Disposes this instance.
		/// </summary>
		public abstract void Dispose();

		/// <summary>
		/// Gets the update mode applicable.
		/// </summary>
		/// <value>The update mode.</value>
		public FileUpdateMode UpdateMode {
			get {
				return updateMode_;
			}
		}



		// Instance Fields
		FileUpdateMode updateMode_;

	}

	/// <summary>
	/// An <see cref="IArchiveStorage"/> implementation suitable for hard disks.
	/// </summary>
	public class DiskArchiveStorage : BaseArchiveStorage {
		// Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="DiskArchiveStorage"/> class.
		/// </summary>
		/// <param name="file">The file.</param>
		/// <param name="updateMode">The update mode.</param>
		public DiskArchiveStorage( BlubbZipFile file, FileUpdateMode updateMode )
			: base( updateMode ) {
			if( file.Name == null ) {
				throw new BlubbZipException( "Cant handle non file archives" );
			}

			fileName_ = file.Name;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DiskArchiveStorage"/> class.
		/// </summary>
		/// <param name="file">The file.</param>
		public DiskArchiveStorage( BlubbZipFile file )
			: this( file, FileUpdateMode.Safe ) {
		}


		// IArchiveStorage Members

		/// <summary>
		/// Gets a temporary output <see cref="Stream"/> for performing updates on.
		/// </summary>
		/// <returns>Returns the temporary output stream.</returns>
		public override Stream GetTemporaryOutput() {
			if( temporaryName_ != null ) {
				temporaryName_ = GetTempFileName( temporaryName_, true );
				temporaryStream_ = File.OpenWrite( temporaryName_ );
			} else {
				// Determine where to place files based on internal strategy.
				// Currently this is always done in system temp directory.
				temporaryName_ = Path.GetTempFileName();
				temporaryStream_ = File.OpenWrite( temporaryName_ );
			}

			return temporaryStream_;
		}

		/// <summary>
		/// Converts a temporary <see cref="Stream"/> to its final form.
		/// </summary>
		/// <returns>Returns a <see cref="Stream"/> that can be used to read
		/// the final storage for the archive.</returns>
		public override Stream ConvertTemporaryToFinal() {
			if( temporaryStream_ == null ) {
				throw new BlubbZipException( "No temporary stream has been created" );
			}

			Stream result = null;

			string moveTempName = GetTempFileName( fileName_, false );
			bool newFileCreated = false;

			try {
				temporaryStream_.Close();
				File.Move( fileName_, moveTempName );
				File.Move( temporaryName_, fileName_ );
				newFileCreated = true;
				File.Delete( moveTempName );

				result = File.OpenRead( fileName_ );
			} catch( Exception ) {
				result = null;

				// Try to roll back changes...
				if( !newFileCreated ) {
					File.Move( moveTempName, fileName_ );
					File.Delete( temporaryName_ );
				}

				throw;
			}

			return result;
		}

		/// <summary>
		/// Make a temporary copy of a stream.
		/// </summary>
		/// <param name="stream">The <see cref="Stream"/> to copy.</param>
		/// <returns>Returns a temporary output <see cref="Stream"/> that is a copy of the input.</returns>
		public override Stream MakeTemporaryCopy( Stream stream ) {
			stream.Close();

			temporaryName_ = GetTempFileName( fileName_, true );
			File.Copy( fileName_, temporaryName_, true );

			temporaryStream_ = new FileStream( temporaryName_,
				FileMode.Open,
				FileAccess.ReadWrite );
			return temporaryStream_;
		}

		/// <summary>
		/// Return a stream suitable for performing direct updates on the original source.
		/// </summary>
		/// <param name="stream">The current stream.</param>
		/// <returns>Returns a stream suitable for direct updating.</returns>
		/// <remarks>If the <paramref name="current"/> stream is not null this is used as is.</remarks>
		public override Stream OpenForDirectUpdate( Stream stream ) {
			Stream result;
			if( ( stream == null ) || !stream.CanWrite ) {
				if( stream != null ) {
					stream.Close();
				}

				result = new FileStream( fileName_,
						FileMode.Open,
						FileAccess.ReadWrite );
			} else {
				result = stream;
			}

			return result;
		}

		/// <summary>
		/// Disposes this instance.
		/// </summary>
		public override void Dispose() {
			if( temporaryStream_ != null ) {
				temporaryStream_.Close();
			}
		}



		// Internal routines
		static string GetTempFileName( string original, bool makeTempFile ) {
			string result = null;

			if( original == null ) {
				result = Path.GetTempFileName();
			} else {
				int counter = 0;
				int suffixSeed = DateTime.Now.Second;

				while( result == null ) {
					counter += 1;
					string newName = string.Format( "{0}.{1}{2}.tmp", original, suffixSeed, counter );
					if( !File.Exists( newName ) ) {
						if( makeTempFile ) {
							try {
								// Try and create the file.
								using( FileStream stream = File.Create( newName ) ) {
								}
								result = newName;
							} catch {
								suffixSeed = DateTime.Now.Second;
							}
						} else {
							result = newName;
						}
					}
				}
			}
			return result;
		}


		// Instance Fields
		Stream temporaryStream_;
		string fileName_;
		string temporaryName_;

	}

	/// <summary>
	/// An <see cref="IArchiveStorage"/> implementation suitable for in memory streams.
	/// </summary>
	public class MemoryArchiveStorage : BaseArchiveStorage {
		// Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="MemoryArchiveStorage"/> class.
		/// </summary>
		public MemoryArchiveStorage()
			: base( FileUpdateMode.Direct ) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MemoryArchiveStorage"/> class.
		/// </summary>
		/// <param name="updateMode">The <see cref="FileUpdateMode"/> to use</param>
		/// <remarks>This constructor is for testing as memory streams dont really require safe mode.</remarks>
		public MemoryArchiveStorage( FileUpdateMode updateMode )
			: base( updateMode ) {
		}



		// Properties
		/// <summary>
		/// Get the stream returned by <see cref="ConvertTemporaryToFinal"/> if this was in fact called.
		/// </summary>
		public MemoryStream FinalStream {
			get {
				return finalStream_;
			}
		}



		// IArchiveStorage Members

		/// <summary>
		/// Gets the temporary output <see cref="Stream"/>
		/// </summary>
		/// <returns>Returns the temporary output stream.</returns>
		public override Stream GetTemporaryOutput() {
			temporaryStream_ = new MemoryStream();
			return temporaryStream_;
		}

		/// <summary>
		/// Converts the temporary <see cref="Stream"/> to its final form.
		/// </summary>
		/// <returns>Returns a <see cref="Stream"/> that can be used to read
		/// the final storage for the archive.</returns>
		public override Stream ConvertTemporaryToFinal() {
			if( temporaryStream_ == null ) {
				throw new BlubbZipException( "No temporary stream has been created" );
			}

			finalStream_ = new MemoryStream( temporaryStream_.ToArray() );
			return finalStream_;
		}

		/// <summary>
		/// Make a temporary copy of the original stream.
		/// </summary>
		/// <param name="stream">The <see cref="Stream"/> to copy.</param>
		/// <returns>Returns a temporary output <see cref="Stream"/> that is a copy of the input.</returns>
		public override Stream MakeTemporaryCopy( Stream stream ) {
			temporaryStream_ = new MemoryStream();
			stream.Position = 0;
			StreamUtils.Copy( stream, temporaryStream_, new byte[ 4096 ] );
			return temporaryStream_;
		}

		/// <summary>
		/// Return a stream suitable for performing direct updates on the original source.
		/// </summary>
		/// <param name="stream">The original source stream</param>
		/// <returns>Returns a stream suitable for direct updating.</returns>
		/// <remarks>If the <paramref name="stream"/> passed is not null this is used;
		/// otherwise a new <see cref="MemoryStream"/> is returned.</remarks>
		public override Stream OpenForDirectUpdate( Stream stream ) {
			Stream result;
			if( ( stream == null ) || !stream.CanWrite ) {

				result = new MemoryStream();

				if( stream != null ) {
					stream.Position = 0;
					StreamUtils.Copy( stream, result, new byte[ 4096 ] );

					stream.Close();
				}
			} else {
				result = stream;
			}

			return result;
		}

		/// <summary>
		/// Disposes this instance.
		/// </summary>
		public override void Dispose() {
			if( temporaryStream_ != null ) {
				temporaryStream_.Close();
			}
		}



		// Instance Fields
		MemoryStream temporaryStream_;
		MemoryStream finalStream_;

	}


}
