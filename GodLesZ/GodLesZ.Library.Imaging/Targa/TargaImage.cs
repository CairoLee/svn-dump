using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace GodLesZ.Library.Imaging.Targa {

	/// <summary>
	/// Reads and loads a Truevision TGA Format image file.
	/// </summary>
	public class TargaImage : IDisposable {
		private TargaHeader mObjTargaHeader = null;
		private TargaExtensionArea mObjTargaExtensionArea = null;
		private TargaFooter mObjTargaFooter = null;
		private Bitmap mBmpTargaImage = null;
		private Bitmap bmpImageThumbnail = null;
		private ETGAFormat mTGAFormat = ETGAFormat.UNKNOWN;
		private string mFileName = string.Empty;
		private int mStride = 0;
		private int mPadding = 0;
		private GCHandle mImageByteHandle;
		private GCHandle mThumbnailByteHandle;
		private List<System.Collections.Generic.List<byte>> rows = new List<List<byte>>();
		private List<byte> row = new List<byte>();

		// Track whether Dispose has been called.
		private bool mDisposed = false;

		/// <summary>
		/// Gets a TargaHeader object that holds the Targa Header information of the loaded file.
		/// </summary>
		public TargaHeader Header {
			get { return this.mObjTargaHeader; }
		}

		/// <summary>
		/// Gets a TargaExtensionArea object that holds the Targa Extension Area information of the loaded file.
		/// </summary>
		public TargaExtensionArea ExtensionArea {
			get { return this.mObjTargaExtensionArea; }
		}

		/// <summary>
		/// Gets a TargaExtensionArea object that holds the Targa Footer information of the loaded file.
		/// </summary>
		public TargaFooter Footer {
			get { return this.mObjTargaFooter; }
		}

		/// <summary>
		/// Gets the Targa format of the loaded file.
		/// </summary>
		public ETGAFormat Format {
			get { return this.mTGAFormat; }
		}

		/// <summary>
		/// Gets a Bitmap representation of the loaded file.
		/// </summary>
		public Bitmap Image {
			get { return this.mBmpTargaImage; }
		}

		/// <summary>
		/// Gets the thumbnail of the loaded file if there is one in the file.
		/// </summary>
		public Bitmap Thumbnail {
			get { return this.bmpImageThumbnail; }
		}

		/// <summary>
		/// Gets the full path and filename of the loaded file.
		/// </summary>
		public string FileName {
			get { return this.mFileName; }
		}

		/// <summary>
		/// Gets the byte offset between the beginning of one scan line and the next. Used when loading the image into the Image Bitmap.
		/// </summary>
		/// <remarks>
		/// The memory allocated for Microsoft Bitmaps must be aligned on a 32bit boundary.
		/// The stride refers to the number of bytes allocated for one scanline of the bitmap.
		/// </remarks>
		public int Stride {
			get { return this.mStride; }
		}

		/// <summary>
		/// Gets the number of bytes used to pad each scan line to meet the Stride value. Used when loading the image into the Image Bitmap.
		/// </summary>
		/// <remarks>
		/// The memory allocated for Microsoft Bitmaps must be aligned on a 32bit boundary.
		/// The stride refers to the number of bytes allocated for one scanline of the bitmap.
		/// In your loop, you copy the pixels one scanline at a time and take into 
		/// consideration the amount of padding that occurs due to memory alignment.
		/// </remarks>
		public int Padding {
			get { return this.mPadding; }
		}


		/// <summary>
		/// Creates a new instance of the TargaImage object.
		/// </summary>
		public TargaImage() {
			mObjTargaFooter = new TargaFooter();
			mObjTargaHeader = new TargaHeader();
			mObjTargaExtensionArea = new TargaExtensionArea();
			mBmpTargaImage = null;
			bmpImageThumbnail = null;
		}

		// This destructor will run only if the Dispose method 
		// does not get called.
		/// <summary>
		/// TargaImage deconstructor.
		/// </summary>
		~TargaImage() {
			// Do not re-create Dispose clean-up code here.
			// Calling Dispose(false) is optimal in terms of
			// readability and maintainability.
			Dispose(false);
		}


		/// <summary>
		/// Creates a new instance of the TargaImage object with strFileName as the image loaded.
		/// </summary>
		public TargaImage(string strFileName)
			: this() {
			// make sure we have a .tga file
			if (Path.GetExtension(strFileName).ToLower() == ".tga") {
				// make sure the file exists
				if (File.Exists(strFileName) == true) {
					this.mFileName = strFileName;
					MemoryStream filestream = null;
					BinaryReader binReader = null;
					byte[] filebytes = null;

					// load the file as an array of bytes
					filebytes = File.ReadAllBytes(this.mFileName);
					if (filebytes != null && filebytes.Length > 0) {
						// create a seekable memory stream of the file bytes
						using (filestream = new MemoryStream(filebytes)) {
							if (filestream != null && filestream.Length > 0 && filestream.CanSeek == true) {
								// create a BinaryReader used to read the Targa file
								using (binReader = new BinaryReader(filestream)) {
									this.LoadTGAFooterInfo(binReader);
									this.LoadTGAHeaderInfo(binReader);
									this.LoadTGAExtensionArea(binReader);
									this.LoadTGAImage(binReader);
								}
							} else {
								throw new Exception(@"Error loading file, could not read file from disk.");
							}
						}

					} else {
						throw new Exception(@"Error loading file, could not read file from disk.");
					}
				} else {
					throw new Exception(@"Error loading file, could not find file '" + strFileName + "' on disk.");
				}
			} else {
				throw new Exception(@"Error loading file, file '" + strFileName + "' must have an extension of '.tga'.");
			}

		}


		public TargaImage(Stream stream)
			: this() {
			mFileName = "FromStream" + DateTime.Now.Millisecond;

			using (BinaryReader binReader = new BinaryReader(stream)) {
				LoadTGAFooterInfo(binReader);
				LoadTGAHeaderInfo(binReader);
				LoadTGAExtensionArea(binReader);
				LoadTGAImage(binReader);
			}
		}


		/// <summary>
		/// Loads the Targa Footer information from the file.
		/// </summary>
		/// <param name="binReader">A BinaryReader that points the loaded file byte stream.</param>
		private void LoadTGAFooterInfo(BinaryReader binReader) {

			if (binReader != null && binReader.BaseStream != null && binReader.BaseStream.Length > 0 && binReader.BaseStream.CanSeek == true) {

				try {
					// set the cursor at the beginning of the signature string.
					binReader.BaseStream.Seek((TargaConstants.FooterSignatureOffsetFromEnd * -1), SeekOrigin.End);

					// read the signature bytes and convert to ascii string
					string Signature = System.Text.Encoding.ASCII.GetString(binReader.ReadBytes(TargaConstants.FooterSignatureByteLength)).TrimEnd('\0');

					// do we have a proper signature
					if (string.Compare(Signature, TargaConstants.TargaFooterASCIISignature) == 0) {
						// this is a NEW targa file.
						// create the footer
						this.mTGAFormat = ETGAFormat.NEW_TGA;

						// set cursor to beginning of footer info
						binReader.BaseStream.Seek((TargaConstants.FooterByteLength * -1), SeekOrigin.End);

						// read the Extension Area Offset value
						int ExtOffset = binReader.ReadInt32();

						// read the Developer Directory Offset value
						int DevDirOff = binReader.ReadInt32();

						// skip the signature we have already read it.
						binReader.ReadBytes(TargaConstants.FooterSignatureByteLength);

						// read the reserved character
						string ResChar = System.Text.Encoding.ASCII.GetString(binReader.ReadBytes(TargaConstants.FooterReservedCharByteLength)).TrimEnd('\0');

						// set all values to our TargaFooter class
						this.mObjTargaFooter.SetExtensionAreaOffset(ExtOffset);
						this.mObjTargaFooter.SetDeveloperDirectoryOffset(DevDirOff);
						this.mObjTargaFooter.SetSignature(Signature);
						this.mObjTargaFooter.SetReservedCharacter(ResChar);
					} else {
						// this is not an ORIGINAL targa file.
						this.mTGAFormat = ETGAFormat.ORIGINAL_TGA;
					}
				} catch (Exception ex) {
					// clear all 
					this.ClearAll();
					throw ex;
				}
			} else {
				this.ClearAll();
				throw new Exception(@"Error loading file, could not read file from disk.");
			}


		}


		/// <summary>
		/// Loads the Targa Header information from the file.
		/// </summary>
		/// <param name="binReader">A BinaryReader that points the loaded file byte stream.</param>
		private void LoadTGAHeaderInfo(BinaryReader binReader) {

			if (binReader != null && binReader.BaseStream != null && binReader.BaseStream.Length > 0 && binReader.BaseStream.CanSeek == true) {
				try {
					// set the cursor at the beginning of the file.
					binReader.BaseStream.Seek(0, SeekOrigin.Begin);

					// read the header properties from the file
					this.mObjTargaHeader.SetImageIDLength(binReader.ReadByte());
					this.mObjTargaHeader.SetColorMapType((ETargetColorMapType)binReader.ReadByte());
					this.mObjTargaHeader.SetImageType((ETargaImageType)binReader.ReadByte());

					this.mObjTargaHeader.SetColorMapFirstEntryIndex(binReader.ReadInt16());
					this.mObjTargaHeader.SetColorMapLength(binReader.ReadInt16());
					this.mObjTargaHeader.SetColorMapEntrySize(binReader.ReadByte());

					this.mObjTargaHeader.SetXOrigin(binReader.ReadInt16());
					this.mObjTargaHeader.SetYOrigin(binReader.ReadInt16());
					this.mObjTargaHeader.SetWidth(binReader.ReadInt16());
					this.mObjTargaHeader.SetHeight(binReader.ReadInt16());

					byte pixeldepth = binReader.ReadByte();
					switch (pixeldepth) {
						case 0: // assume 32
							this.mObjTargaHeader.SetPixelDepth(32);
							break;
						case 8:
						case 16:
						case 24:
						case 32:
							this.mObjTargaHeader.SetPixelDepth(pixeldepth);
							break;

						default:
							this.ClearAll();
							throw new Exception("Targa Image only supports 8, 16, 24, or 32 bit pixel depths, not " + pixeldepth + ".");
					}


					byte ImageDescriptor = binReader.ReadByte();
					this.mObjTargaHeader.SetAttributeBits((byte)TargaUtilities.GetBits(ImageDescriptor, 0, 4));

					this.mObjTargaHeader.SetVerticalTransferOrder((ETargaVerticalTransferOrder)TargaUtilities.GetBits(ImageDescriptor, 5, 1));
					this.mObjTargaHeader.SetHorizontalTransferOrder((ETargaHorizontalTransferOrder)TargaUtilities.GetBits(ImageDescriptor, 4, 1));

					// load ImageID value if any
					if (this.mObjTargaHeader.ImageIDLength > 0) {
						byte[] ImageIDValueBytes = binReader.ReadBytes(this.mObjTargaHeader.ImageIDLength);
						this.mObjTargaHeader.SetImageIDValue(System.Text.Encoding.ASCII.GetString(ImageIDValueBytes).TrimEnd('\0'));
					}
				} catch (Exception ex) {
					this.ClearAll();
					throw ex;
				}


				// load color map if it's included and/or needed
				// Only needed for UNCOMPRESSED_COLOR_MAPPED and RUN_LENGTH_ENCODED_COLOR_MAPPED
				// image types. If color map is included for other file types we can ignore it.
				if (this.mObjTargaHeader.ColorMapType == ETargetColorMapType.COLOR_MAP_INCLUDED) {
					if (this.mObjTargaHeader.ImageType == ETargaImageType.UNCOMPRESSED_COLOR_MAPPED ||
						this.mObjTargaHeader.ImageType == ETargaImageType.RUN_LENGTH_ENCODED_COLOR_MAPPED) {
						if (this.mObjTargaHeader.ColorMapLength > 0) {
							try {
								for (int i = 0; i < this.mObjTargaHeader.ColorMapLength; i++) {
									int a = 0;
									int r = 0;
									int g = 0;
									int b = 0;

									// load each color map entry based on the ColorMapEntrySize value
									switch (this.mObjTargaHeader.ColorMapEntrySize) {
										case 15:
											byte[] color15 = binReader.ReadBytes(2);
											// remember that the bytes are stored in reverse oreder
											this.mObjTargaHeader.ColorMap.Add(TargaUtilities.GetColorFrom2Bytes(color15[1], color15[0]));
											break;
										case 16:
											byte[] color16 = binReader.ReadBytes(2);
											// remember that the bytes are stored in reverse oreder
											this.mObjTargaHeader.ColorMap.Add(TargaUtilities.GetColorFrom2Bytes(color16[1], color16[0]));
											break;
										case 24:
											b = Convert.ToInt32(binReader.ReadByte());
											g = Convert.ToInt32(binReader.ReadByte());
											r = Convert.ToInt32(binReader.ReadByte());
											this.mObjTargaHeader.ColorMap.Add(System.Drawing.Color.FromArgb(r, g, b));
											break;
										case 32:
											a = Convert.ToInt32(binReader.ReadByte());
											b = Convert.ToInt32(binReader.ReadByte());
											g = Convert.ToInt32(binReader.ReadByte());
											r = Convert.ToInt32(binReader.ReadByte());
											this.mObjTargaHeader.ColorMap.Add(System.Drawing.Color.FromArgb(a, r, g, b));
											break;
										default:
											this.ClearAll();
											throw new Exception("TargaImage only supports ColorMap Entry Sizes of 15, 16, 24 or 32 bits.");

									}


								}
							} catch (Exception ex) {
								this.ClearAll();
								throw ex;
							}



						} else {
							this.ClearAll();
							throw new Exception("Image Type requires a Color Map and Color Map Length is zero.");
						}
					}


				} else {
					if (this.mObjTargaHeader.ImageType == ETargaImageType.UNCOMPRESSED_COLOR_MAPPED ||
						this.mObjTargaHeader.ImageType == ETargaImageType.RUN_LENGTH_ENCODED_COLOR_MAPPED) {
						this.ClearAll();
						throw new Exception("Image Type requires a Color Map and there was not a Color Map included in the file.");
					}
				}


			} else {
				this.ClearAll();
				throw new Exception(@"Error loading file, could not read file from disk.");
			}
		}


		/// <summary>
		/// Loads the Targa Extension Area from the file, if it exists.
		/// </summary>
		/// <param name="binReader">A BinaryReader that points the loaded file byte stream.</param>
		private void LoadTGAExtensionArea(BinaryReader binReader) {

			if (binReader != null && binReader.BaseStream != null && binReader.BaseStream.Length > 0 && binReader.BaseStream.CanSeek == true) {
				// is there an Extension Area in file
				if (this.mObjTargaFooter.ExtensionAreaOffset > 0) {
					try {
						// set the cursor at the beginning of the Extension Area using ExtensionAreaOffset.
						binReader.BaseStream.Seek(this.mObjTargaFooter.ExtensionAreaOffset, SeekOrigin.Begin);

						// load the extension area fields from the file

						this.mObjTargaExtensionArea.SetExtensionSize((int)(binReader.ReadInt16()));
						this.mObjTargaExtensionArea.SetAuthorName(System.Text.Encoding.ASCII.GetString(binReader.ReadBytes(TargaConstants.ExtensionAreaAuthorNameByteLength)).TrimEnd('\0'));
						this.mObjTargaExtensionArea.SetAuthorComments(System.Text.Encoding.ASCII.GetString(binReader.ReadBytes(TargaConstants.ExtensionAreaAuthorCommentsByteLength)).TrimEnd('\0'));


						// get the date/time stamp of the file
						Int16 iMonth = binReader.ReadInt16();
						Int16 iDay = binReader.ReadInt16();
						Int16 iYear = binReader.ReadInt16();
						Int16 iHour = binReader.ReadInt16();
						Int16 iMinute = binReader.ReadInt16();
						Int16 iSecond = binReader.ReadInt16();
						DateTime dtstamp;
						string strStamp = iMonth.ToString() + @"/" + iDay.ToString() + @"/" + iYear.ToString() + @" ";
						strStamp += iHour.ToString() + @":" + iMinute.ToString() + @":" + iSecond.ToString();
						if (DateTime.TryParse(strStamp, out dtstamp) == true)
							this.mObjTargaExtensionArea.SetDateTimeStamp(dtstamp);


						this.mObjTargaExtensionArea.SetJobName(System.Text.Encoding.ASCII.GetString(binReader.ReadBytes(TargaConstants.ExtensionAreaJobNameByteLength)).TrimEnd('\0'));


						// get the job time of the file
						iHour = binReader.ReadInt16();
						iMinute = binReader.ReadInt16();
						iSecond = binReader.ReadInt16();
						TimeSpan ts = new TimeSpan((int)iHour, (int)iMinute, (int)iSecond);
						this.mObjTargaExtensionArea.SetJobTime(ts);


						this.mObjTargaExtensionArea.SetSoftwareID(System.Text.Encoding.ASCII.GetString(binReader.ReadBytes(TargaConstants.ExtensionAreaSoftwareIDByteLength)).TrimEnd('\0'));


						// get the version number and letter from file
						float iVersionNumber = (float)binReader.ReadInt16() / 100.0F;
						string strVersionLetter = System.Text.Encoding.ASCII.GetString(binReader.ReadBytes(TargaConstants.ExtensionAreaSoftwareVersionLetterByteLength)).TrimEnd('\0');


						this.mObjTargaExtensionArea.SetSoftwareID(iVersionNumber.ToString(@"F2") + strVersionLetter);


						// get the color key of the file
						int a = (int)binReader.ReadByte();
						int r = (int)binReader.ReadByte();
						int b = (int)binReader.ReadByte();
						int g = (int)binReader.ReadByte();
						this.mObjTargaExtensionArea.SetKeyColor(Color.FromArgb(a, r, g, b));


						this.mObjTargaExtensionArea.SetPixelAspectRatioNumerator((int)binReader.ReadInt16());
						this.mObjTargaExtensionArea.SetPixelAspectRatioDenominator((int)binReader.ReadInt16());
						this.mObjTargaExtensionArea.SetGammaNumerator((int)binReader.ReadInt16());
						this.mObjTargaExtensionArea.SetGammaDenominator((int)binReader.ReadInt16());
						this.mObjTargaExtensionArea.SetColorCorrectionOffset(binReader.ReadInt32());
						this.mObjTargaExtensionArea.SetPostageStampOffset(binReader.ReadInt32());
						this.mObjTargaExtensionArea.SetScanLineOffset(binReader.ReadInt32());
						this.mObjTargaExtensionArea.SetAttributesType((int)binReader.ReadByte());


						// load Scan Line Table from file if any
						if (this.mObjTargaExtensionArea.ScanLineOffset > 0) {
							binReader.BaseStream.Seek(this.mObjTargaExtensionArea.ScanLineOffset, SeekOrigin.Begin);
							for (int i = 0; i < this.mObjTargaHeader.Height; i++) {
								this.mObjTargaExtensionArea.ScanLineTable.Add(binReader.ReadInt32());
							}
						}


						// load Color Correction Table from file if any
						if (this.mObjTargaExtensionArea.ColorCorrectionOffset > 0) {
							binReader.BaseStream.Seek(this.mObjTargaExtensionArea.ColorCorrectionOffset, SeekOrigin.Begin);
							for (int i = 0; i < TargaConstants.ExtensionAreaColorCorrectionTableValueLength; i++) {
								a = (int)binReader.ReadInt16();
								r = (int)binReader.ReadInt16();
								b = (int)binReader.ReadInt16();
								g = (int)binReader.ReadInt16();
								this.mObjTargaExtensionArea.ColorCorrectionTable.Add(Color.FromArgb(a, r, g, b));
							}
						}
					} catch (Exception ex) {
						this.ClearAll();
						throw ex;
					}
				}
			} else {
				this.ClearAll();
				throw new Exception(@"Error loading file, could not read file from disk.");
			}
		}

		/// <summary>
		/// Reads the image data bytes from the file. Handles Uncompressed and RLE Compressed image data. 
		/// Uses FirstPixelDestination to properly align the image.
		/// </summary>
		/// <param name="binReader">A BinaryReader that points the loaded file byte stream.</param>
		/// <returns>An array of bytes representing the image data in the proper alignment.</returns>
		private byte[] LoadImageBytes(BinaryReader binReader) {

			// read the image data into a byte array
			// take into account stride has to be a multiple of 4
			// use padding to make sure multiple of 4    

			byte[] data = null;
			if (binReader != null && binReader.BaseStream != null && binReader.BaseStream.Length > 0 && binReader.BaseStream.CanSeek == true) {
				if (this.mObjTargaHeader.ImageDataOffset > 0) {
					// padding bytes
					byte[] padding = new byte[this.mPadding];
					MemoryStream msData = null;

					// seek to the beginning of the image data using the ImageDataOffset value
					binReader.BaseStream.Seek(this.mObjTargaHeader.ImageDataOffset, SeekOrigin.Begin);


					// get the size in bytes of each row in the image
					int intImageRowByteSize = (int)this.mObjTargaHeader.Width * ((int)this.mObjTargaHeader.BytesPerPixel);

					// get the size in bytes of the whole image
					int intImageByteSize = intImageRowByteSize * (int)this.mObjTargaHeader.Height;

					// is this a RLE compressed image type
					if (this.mObjTargaHeader.ImageType == ETargaImageType.RUN_LENGTH_ENCODED_BLACK_AND_WHITE ||
					   this.mObjTargaHeader.ImageType == ETargaImageType.RUN_LENGTH_ENCODED_COLOR_MAPPED ||
					   this.mObjTargaHeader.ImageType == ETargaImageType.RUN_LENGTH_ENCODED_TRUE_COLOR) {

						#region COMPRESSED

						// RLE Packet info
						byte bRLEPacket = 0;
						int intRLEPacketType = -1;
						int intRLEPixelCount = 0;
						byte[] bRunLengthPixel = null;

						// used to keep track of bytes read
						int intImageBytesRead = 0;
						int intImageRowBytesRead = 0;

						// keep reading until we have the all image bytes
						while (intImageBytesRead < intImageByteSize) {
							// get the RLE packet
							bRLEPacket = binReader.ReadByte();
							intRLEPacketType = TargaUtilities.GetBits(bRLEPacket, 7, 1);
							intRLEPixelCount = TargaUtilities.GetBits(bRLEPacket, 0, 7) + 1;

							// check the RLE packet type
							if ((ETargaRLEPacketType)intRLEPacketType == ETargaRLEPacketType.RUN_LENGTH) {
								// get the pixel color data
								bRunLengthPixel = binReader.ReadBytes((int)this.mObjTargaHeader.BytesPerPixel);

								// add the number of pixels specified using the read pixel color
								for (int i = 0; i < intRLEPixelCount; i++) {
									foreach (byte b in bRunLengthPixel)
										row.Add(b);

									// increment the byte counts
									intImageRowBytesRead += bRunLengthPixel.Length;
									intImageBytesRead += bRunLengthPixel.Length;

									// if we have read a full image row
									// add the row to the row list and clear it
									// restart row byte count
									if (intImageRowBytesRead == intImageRowByteSize) {
										rows.Add(row);
										row = new System.Collections.Generic.List<byte>();
										intImageRowBytesRead = 0;

									}
								}

							} else if ((ETargaRLEPacketType)intRLEPacketType == ETargaRLEPacketType.RAW) {
								// get the number of bytes to read based on the read pixel count
								int intBytesToRead = intRLEPixelCount * (int)this.mObjTargaHeader.BytesPerPixel;

								// read each byte
								for (int i = 0; i < intBytesToRead; i++) {
									row.Add(binReader.ReadByte());

									// increment the byte counts
									intImageBytesRead++;
									intImageRowBytesRead++;

									// if we have read a full image row
									// add the row to the row list and clear it
									// restart row byte count
									if (intImageRowBytesRead == intImageRowByteSize) {
										rows.Add(row);
										row = new System.Collections.Generic.List<byte>();
										intImageRowBytesRead = 0;
									}

								}

							}
						}

						#endregion

					} else {
						#region NON-COMPRESSED

						// loop through each row in the image
						for (int i = 0; i < (int)this.mObjTargaHeader.Height; i++) {
							// loop through each byte in the row
							for (int j = 0; j < intImageRowByteSize; j++) {
								// add the byte to the row
								row.Add(binReader.ReadByte());
							}

							// add row to the list of rows
							rows.Add(row);

							// create a new row
							row = new System.Collections.Generic.List<byte>();
						}


						#endregion
					}

					// flag that states whether or not to reverse the location of all rows.
					bool blnRowsReverse = false;

					// flag that states whether or not to reverse the bytes in each row.
					bool blnEachRowReverse = false;

					// use FirstPixelDestination to determine the alignment of the 
					// image data byte
					switch (this.mObjTargaHeader.FirstPixelDestination) {
						case ETargaFirstPixelDestination.TOP_LEFT:
							blnRowsReverse = false;
							blnEachRowReverse = true;
							break;

						case ETargaFirstPixelDestination.TOP_RIGHT:
							blnRowsReverse = false;
							blnEachRowReverse = false;
							break;

						case ETargaFirstPixelDestination.BOTTOM_LEFT:
							blnRowsReverse = true;
							blnEachRowReverse = true;
							break;

						case ETargaFirstPixelDestination.BOTTOM_RIGHT:
						case ETargaFirstPixelDestination.UNKNOWN:
							blnRowsReverse = true;
							blnEachRowReverse = false;

							break;
					}

					// write the bytes from each row into a memory stream and get the 
					// resulting byte array
					using (msData = new MemoryStream()) {

						// do we reverse the rows in the row list.
						if (blnRowsReverse == true)
							rows.Reverse();

						// go through each row
						for (int i = 0; i < rows.Count; i++) {
							// do we reverse the bytes in the row
							if (blnEachRowReverse == true)
								rows[i].Reverse();

							// get the byte array for the row
							byte[] brow = rows[i].ToArray();

							// write the row bytes and padding bytes to the memory streem
							msData.Write(brow, 0, brow.Length);
							msData.Write(padding, 0, padding.Length);
						}
						// get the image byte array
						data = msData.ToArray();



					}

				} else {
					this.ClearAll();
					throw new Exception(@"Error loading file, No image data in file.");
				}
			} else {
				this.ClearAll();
				throw new Exception(@"Error loading file, could not read file from disk.");
			}

			// return the image byte array
			return data;

		}

		/// <summary>
		/// Reads the image data bytes from the file and loads them into the Image Bitmap object.
		/// Also loads the color map, if any, into the Image Bitmap.
		/// </summary>
		/// <param name="binReader">A BinaryReader that points the loaded file byte stream.</param>
		private void LoadTGAImage(BinaryReader binReader) {
			//**************  NOTE  *******************
			// The memory allocated for Microsoft Bitmaps must be aligned on a 32bit boundary.
			// The stride refers to the number of bytes allocated for one scanline of the bitmap.
			// In your loop, you copy the pixels one scanline at a time and take into
			// consideration the amount of padding that occurs due to memory alignment.
			// calculate the stride, in bytes, of the image (32bit aligned width of each image row)
			this.mStride = (((int)this.mObjTargaHeader.Width * (int)this.mObjTargaHeader.PixelDepth + 31) & ~31) >> 3; // width in bytes

			// calculate the padding, in bytes, of the image 
			// number of bytes to add to make each row a 32bit aligned row
			// padding in bytes
			this.mPadding = this.mStride - ((((int)this.mObjTargaHeader.Width * (int)this.mObjTargaHeader.PixelDepth) + 7) / 8);

			// get the image data bytes
			byte[] bimagedata = this.LoadImageBytes(binReader);

			// since the Bitmap constructor requires a poiter to an array of image bytes
			// we have to pin down the memory used by the byte array and use the pointer 
			// of this pinned memory to create the Bitmap.
			// This tells the Garbage Collector to leave the memory alone and DO NOT touch it.
			this.mImageByteHandle = GCHandle.Alloc(bimagedata, GCHandleType.Pinned);

			// make sure we don't have a phantom Bitmap
			if (this.mBmpTargaImage != null) {
				this.mBmpTargaImage.Dispose();
			}

			// make sure we don't have a phantom Thumbnail
			if (this.bmpImageThumbnail != null) {
				this.bmpImageThumbnail.Dispose();
			}


			// get the Pixel format to use with the Bitmap object
			PixelFormat pf = this.GetPixelFormat();


			// create a Bitmap object using the image Width, Height,
			// Stride, PixelFormat and the pointer to the pinned byte array.
			this.mBmpTargaImage = new Bitmap((int)this.mObjTargaHeader.Width,
											(int)this.mObjTargaHeader.Height,
											this.mStride,
											pf,
											this.mImageByteHandle.AddrOfPinnedObject());


			this.LoadThumbnail(binReader, pf);



			// load the color map into the Bitmap, if it exists
			if (this.mObjTargaHeader.ColorMap.Count > 0) {
				// get the Bitmap's current palette
				ColorPalette pal = this.mBmpTargaImage.Palette;

				// loop trough each color in the loaded file's color map
				for (int i = 0; i < this.mObjTargaHeader.ColorMap.Count; i++) {
					// is the AttributesType 0 or 1 bit
					if (this.mObjTargaExtensionArea.AttributesType == 0 ||
						this.mObjTargaExtensionArea.AttributesType == 1)
						// use 255 for alpha ( 255 = opaque/visible ) so we can see the image
						pal.Entries[i] = Color.FromArgb(255, this.mObjTargaHeader.ColorMap[i].R, this.mObjTargaHeader.ColorMap[i].G, this.mObjTargaHeader.ColorMap[i].B);

					else
						// use whatever value is there
						pal.Entries[i] = this.mObjTargaHeader.ColorMap[i];

				}

				// set the new palette back to the Bitmap object
				this.mBmpTargaImage.Palette = pal;

				// set the palette to the thumbnail also, if there is one
				if (this.bmpImageThumbnail != null) {
					this.bmpImageThumbnail.Palette = pal;
				}
			} else { // no color map


				// check to see if this is a Black and White (Greyscale)
				if (this.mObjTargaHeader.PixelDepth == 8 && (this.mObjTargaHeader.ImageType == ETargaImageType.UNCOMPRESSED_BLACK_AND_WHITE ||
					this.mObjTargaHeader.ImageType == ETargaImageType.RUN_LENGTH_ENCODED_BLACK_AND_WHITE)) {
					// get the current palette
					ColorPalette pal = this.mBmpTargaImage.Palette;

					// create the Greyscale palette
					for (int i = 0; i < 256; i++) {
						pal.Entries[i] = Color.FromArgb(i, i, i);
					}

					// set the new palette back to the Bitmap object
					this.mBmpTargaImage.Palette = pal;

					// set the palette to the thumbnail also, if there is one
					if (this.bmpImageThumbnail != null) {
						this.bmpImageThumbnail.Palette = pal;
					}
				}


			}

		}

		/// <summary>
		/// Gets the PixelFormat to be used by the Image based on the Targa file's attributes
		/// </summary>
		/// <returns></returns>
		private PixelFormat GetPixelFormat() {

			PixelFormat pfTargaPixelFormat = PixelFormat.Undefined;

			// first off what is our Pixel Depth (bits per pixel)
			switch (this.mObjTargaHeader.PixelDepth) {
				case 8:
					pfTargaPixelFormat = PixelFormat.Format8bppIndexed;
					break;

				case 16:
					//PixelFormat.Format16bppArgb1555
					//PixelFormat.Format16bppRgb555
					if (this.Format == ETGAFormat.NEW_TGA) {
						switch (this.mObjTargaExtensionArea.AttributesType) {
							case 0:
							case 1:
							case 2: // no alpha data
								pfTargaPixelFormat = PixelFormat.Format16bppRgb555;
								break;

							case 3: // useful alpha data
								pfTargaPixelFormat = PixelFormat.Format16bppArgb1555;
								break;
						}
					} else {
						pfTargaPixelFormat = PixelFormat.Format16bppRgb555;
					}

					break;

				case 24:
					pfTargaPixelFormat = PixelFormat.Format24bppRgb;
					break;

				case 32:
					//PixelFormat.Format32bppArgb
					//PixelFormat.Format32bppPArgb
					//PixelFormat.Format32bppRgb
					if (this.Format == ETGAFormat.NEW_TGA) {
						switch (this.mObjTargaExtensionArea.AttributesType) {

							case 1:
							case 2: // no alpha data
								pfTargaPixelFormat = PixelFormat.Format32bppRgb;
								break;

							case 0:
							case 3: // useful alpha data
								pfTargaPixelFormat = PixelFormat.Format32bppArgb;
								break;

							case 4: // premultiplied alpha data
								pfTargaPixelFormat = PixelFormat.Format32bppPArgb;
								break;

						}
					} else {
						pfTargaPixelFormat = PixelFormat.Format32bppRgb;
						break;
					}



					break;

			}


			return pfTargaPixelFormat;
		}


		/// <summary>
		/// Loads the thumbnail of the loaded image file, if any.
		/// </summary>
		/// <param name="binReader">A BinaryReader that points the loaded file byte stream.</param>
		/// <param name="pfPixelFormat">A PixelFormat value indicating what pixel format to use when loading the thumbnail.</param>
		private void LoadThumbnail(BinaryReader binReader, PixelFormat pfPixelFormat) {

			// read the Thumbnail image data into a byte array
			// take into account stride has to be a multiple of 4
			// use padding to make sure multiple of 4    

			byte[] data = null;
			if (binReader != null && binReader.BaseStream != null && binReader.BaseStream.Length > 0 && binReader.BaseStream.CanSeek == true) {
				if (this.ExtensionArea.PostageStampOffset > 0) {

					// seek to the beginning of the image data using the ImageDataOffset value
					binReader.BaseStream.Seek(this.ExtensionArea.PostageStampOffset, SeekOrigin.Begin);

					int iWidth = (int)binReader.ReadByte();
					int iHeight = (int)binReader.ReadByte();

					int iStride = ((iWidth * (int)this.mObjTargaHeader.PixelDepth + 31) & ~31) >> 3; // width in bytes
					int iPadding = iStride - (((iWidth * (int)this.mObjTargaHeader.PixelDepth) + 7) / 8);

					System.Collections.Generic.List<System.Collections.Generic.List<byte>> objRows = new System.Collections.Generic.List<System.Collections.Generic.List<byte>>();
					System.Collections.Generic.List<byte> objRow = new System.Collections.Generic.List<byte>();




					byte[] padding = new byte[iPadding];
					MemoryStream msData = null;
					bool blnEachRowReverse = false;
					bool blnRowsReverse = false;


					using (msData = new MemoryStream()) {
						// get the size in bytes of each row in the image
						int intImageRowByteSize = iWidth * ((int)this.mObjTargaHeader.PixelDepth / 8);

						// get the size in bytes of the whole image
						int intImageByteSize = intImageRowByteSize * iHeight;

						// thumbnails are never compressed
						for (int i = 0; i < iHeight; i++) {
							for (int j = 0; j < intImageRowByteSize; j++) {
								objRow.Add(binReader.ReadByte());
							}
							objRows.Add(objRow);
							objRow = new System.Collections.Generic.List<byte>();
						}

						switch (this.mObjTargaHeader.FirstPixelDestination) {
							case ETargaFirstPixelDestination.TOP_LEFT:
								break;

							case ETargaFirstPixelDestination.TOP_RIGHT:
								blnRowsReverse = false;
								blnEachRowReverse = false;
								break;

							case ETargaFirstPixelDestination.BOTTOM_LEFT:
								break;

							case ETargaFirstPixelDestination.BOTTOM_RIGHT:
							case ETargaFirstPixelDestination.UNKNOWN:
								blnRowsReverse = true;
								blnEachRowReverse = false;

								break;
						}

						if (blnRowsReverse == true)
							objRows.Reverse();

						for (int i = 0; i < objRows.Count; i++) {
							if (blnEachRowReverse == true)
								objRows[i].Reverse();

							byte[] brow = objRows[i].ToArray();
							msData.Write(brow, 0, brow.Length);
							msData.Write(padding, 0, padding.Length);
						}
						data = msData.ToArray();
					}

					if (data != null && data.Length > 0) {
						this.mThumbnailByteHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
						this.bmpImageThumbnail = new Bitmap(iWidth, iHeight, iStride, pfPixelFormat,
														this.mThumbnailByteHandle.AddrOfPinnedObject());

					}


				} else {
					if (this.bmpImageThumbnail != null) {
						this.bmpImageThumbnail.Dispose();
						this.bmpImageThumbnail = null;
					}
				}
			} else {
				if (this.bmpImageThumbnail != null) {
					this.bmpImageThumbnail.Dispose();
					this.bmpImageThumbnail = null;
				}
			}

		}

		/// <summary>
		/// Clears out all objects and resources.
		/// </summary>
		private void ClearAll() {
			if (this.mBmpTargaImage != null) {
				this.mBmpTargaImage.Dispose();
				this.mBmpTargaImage = null;
			}
			if (this.mImageByteHandle.IsAllocated)
				this.mImageByteHandle.Free();

			if (this.mThumbnailByteHandle.IsAllocated)
				this.mThumbnailByteHandle.Free();

			this.mObjTargaHeader = new TargaHeader();
			this.mObjTargaExtensionArea = new TargaExtensionArea();
			this.mObjTargaFooter = new TargaFooter();
			this.mTGAFormat = ETGAFormat.UNKNOWN;
			this.mStride = 0;
			this.mPadding = 0;
			this.rows.Clear();
			this.row.Clear();
			this.mFileName = string.Empty;

		}

		/// <summary>
		/// Loads a Targa image file into a Bitmap object.
		/// </summary>
		/// <param name="sFileName">The Targa image filename</param>
		/// <returns>A Bitmap object with the Targa image loaded into it.</returns>
		public static Bitmap LoadTargaImage(string sFileName) {
			Bitmap b = null;
			using (TargaImage ti = new TargaImage(sFileName)) {
				b = new Bitmap(ti.Image);
			}

			return b;
		}

		#region IDisposable Members

		/// <summary>
		/// Disposes all resources used by this instance of the TargaImage class.
		/// </summary>
		public void Dispose() {
			Dispose(true);
			// Take yourself off the Finalization queue 
			// to prevent finalization code for this object
			// from executing a second time.
			GC.SuppressFinalize(this);

		}


		/// <summary>
		/// Dispose(bool disposing) executes in two distinct scenarios.
		/// If disposing equals true, the method has been called directly
		/// or indirectly by a user's code. Managed and unmanaged resources
		/// can be disposed.
		/// If disposing equals false, the method has been called by the 
		/// runtime from inside the finalizer and you should not reference 
		/// other objects. Only unmanaged resources can be disposed.
		/// </summary>
		/// <param name="disposing">If true dispose all resources, else dispose only release unmanaged resources.</param>
		protected virtual void Dispose(bool disposing) {
			// Check to see if Dispose has already been called.
			if (!this.mDisposed) {
				// If disposing equals true, dispose all managed 
				// and unmanaged resources.
				if (disposing) {
					// Dispose managed resources.
					if (this.mBmpTargaImage != null) {
						this.mBmpTargaImage.Dispose();
					}

					if (this.bmpImageThumbnail != null) {
						this.bmpImageThumbnail.Dispose();
					}

					if (this.mImageByteHandle != null) {
						if (this.mImageByteHandle.IsAllocated) {
							this.mImageByteHandle.Free();
						}

					}

					if (this.mThumbnailByteHandle != null) {
						if (this.mThumbnailByteHandle.IsAllocated) {
							this.mThumbnailByteHandle.Free();
						}

					}
				}
				// Release unmanaged resources. If disposing is false, 
				// only the following code is executed.
				// ** release unmanged resources here **

				// Note that this is not thread safe.
				// Another thread could start disposing the object
				// after the managed resources are disposed,
				// but before the disposed flag is set to true.
				// If thread safety is necessary, it must be
				// implemented by the client.

			}
			mDisposed = true;
		}


		#endregion

	}

}
