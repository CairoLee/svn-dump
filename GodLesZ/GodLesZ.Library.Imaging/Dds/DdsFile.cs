using System;
using System.Drawing;
using System.IO;
using Gibbed.IO;
using Gibbed.Squish;

namespace GodLesZ.Library.Imaging.Dds {
	public class DdsFile {
		public Endian Endian = Endian.Little;
		public Gibbed.Squish.DDS.Header Header = new Gibbed.Squish.DDS.Header();
		private byte[] _PixelData = null;
		public byte[] PixelData {
			get { return this._PixelData; }
		}

		public int Width {
			get { return this.Header.Width; }
			set { this.Header.Width = value; }
		}

		public int Height {
			get { return this.Header.Height; }
			set { this.Header.Height = value; }
		}

		public DdsFile() {
		}

		public DdsFile(string filepath) {
			using (var stream = File.OpenRead(filepath)) {
				Deserialize(stream);
			}
		}

		public DdsFile(Stream fileStream) {
			Deserialize(fileStream);
		}


		public System.Drawing.Image Image() {
			return this.Image(true, true, true, false);
		}

		public System.Drawing.Image Image(bool red) {
			return this.Image(red, false, false, false);
		}

		public System.Drawing.Image Image(bool red, bool green) {
			return this.Image(red, green, false, false);
		}

		public System.Drawing.Image Image(bool red, bool green, bool blue) {
			return this.Image(red, green, blue, false);
		}

		public System.Drawing.Image Image(bool red, bool green, bool blue, bool alpha) {
			int width = this.Width;
			int height = this.Height;

			var bitmap = new Bitmap(width, height);

			var pixelData = this.PixelData;

			for (int y = 0; y < height; y++) {
				for (int x = 0; x < width; x++) {
					int offset = (y * width * 4) + (x * 4);

					int cred = 0;
					int cgreen = 0;
					int cblue = 0;
					int calpha = 0;

					if (red) { cred = pixelData[offset + 0]; }
					if (green) { cgreen = pixelData[offset + 1]; }
					if (blue) { cblue = pixelData[offset + 2]; }
					if (alpha) { calpha = pixelData[offset + 3]; }

					if (alpha) {
						bitmap.SetPixel(x, y, Color.FromArgb(calpha, cred, cgreen, cblue));
					} else {
						bitmap.SetPixel(x, y, Color.FromArgb(cred, cgreen, cblue));
					}
				}
			}

			return bitmap;
		}

		public System.Drawing.Image AsPng() {
			int width = this.Width;
			int height = this.Height;

			var bitmap = new Bitmap(width, height);
			var pixelData = this.PixelData;

			for (int y = 0; y < height; y++) {
				for (int x = 0; x < width; x++) {
					int offset = (y * width * 4) + (x * 4);

					var cred = pixelData[offset + 0];
					var cgreen = pixelData[offset + 1];
					var cblue = pixelData[offset + 2];
					var calpha = pixelData[offset + 3];
					bitmap.SetPixel(x, y, Color.FromArgb(calpha, cred, cgreen, cblue));
				}
			}

			return bitmap;
		}

		public void Deserialize(Stream input) {
			var magic = input.ReadValueU32();

			if (magic != 0x20534444 &&
				magic != 0x44445320) {
				throw new FormatException("not a DDS texture");
			}

			this.Endian = magic == 0x20534444 ? Endian.Little : Endian.Big;

			this.Header = new Gibbed.Squish.DDS.Header();
			this.Header.Deserialize(input, this.Endian);

			if ((this.Header.PixelFormat.Flags & Gibbed.Squish.DDS.PixelFormatFlags.FourCC) != 0) {
				var squishFlags = Native.Flags.None;

				switch (this.Header.PixelFormat.FourCC) {
					case 0x31545844: // "DXT1"
					{
							squishFlags |= Native.Flags.DXT1;
							break;
						}

					case 0x33545844: // "DXT3"
					{
						squishFlags |= Native.Flags.DXT3;
						break;
					}

					case 0x35545844: // "DXT5"
					{
						squishFlags |= Native.Flags.DXT5;
						break;
					}

					default: {
						throw new FormatException("unsupported DDS format");
					}
				}

				// Compute size of compressed block area
				int blockCount = ((this.Width + 3) / 4) * ((this.Height + 3) / 4);
				int blockSize = ((squishFlags & Native.Flags.DXT1) != 0) ? 8 : 16;

				// Allocate room for compressed blocks, and read data into it.
				var compressedBlocks = new byte[blockCount * blockSize];
				input.Read(compressedBlocks, 0, compressedBlocks.Length);

				// Now decompress..
				this._PixelData = Native.DecompressImage(
					compressedBlocks, this.Width, this.Height, squishFlags);
			} else {
				// We can only deal with the non-DXT formats we know about..
				// this is a bit of a mess..
				// Sorry..
				var fileFormat = Gibbed.Squish.DDS.FileFormat.INVALID;

				if (this.Header.PixelFormat.Flags == Gibbed.Squish.DDS.PixelFormatFlags.RGBA &&
					this.Header.PixelFormat.RGBBitCount == 32 &&
					this.Header.PixelFormat.RedBitMask == 0x00FF0000 &&
					this.Header.PixelFormat.GreenBitMask == 0x0000FF00 &&
					this.Header.PixelFormat.BlueBitMask == 0x000000FF &&
					this.Header.PixelFormat.AlphaBitMask == 0xFF000000) {
					fileFormat = Gibbed.Squish.DDS.FileFormat.A8R8G8B8;
				} else if (
					  this.Header.PixelFormat.Flags == Gibbed.Squish.DDS.PixelFormatFlags.RGB &&
					  this.Header.PixelFormat.RGBBitCount == 32 &&
					  this.Header.PixelFormat.RedBitMask == 0x00FF0000 &&
					  this.Header.PixelFormat.GreenBitMask == 0x0000FF00 &&
					  this.Header.PixelFormat.BlueBitMask == 0x000000FF &&
					  this.Header.PixelFormat.AlphaBitMask == 0x00000000) {
					fileFormat = Gibbed.Squish.DDS.FileFormat.X8R8G8B8;
				} else if (
					  this.Header.PixelFormat.Flags == Gibbed.Squish.DDS.PixelFormatFlags.RGBA &&
					  this.Header.PixelFormat.RGBBitCount == 32 &&
					  this.Header.PixelFormat.RedBitMask == 0x000000ff &&
					  this.Header.PixelFormat.GreenBitMask == 0x0000ff00 &&
					  this.Header.PixelFormat.BlueBitMask == 0x00ff0000 &&
					  this.Header.PixelFormat.AlphaBitMask == 0xff000000) {
					fileFormat = Gibbed.Squish.DDS.FileFormat.A8B8G8R8;
				} else if (
					  this.Header.PixelFormat.Flags == Gibbed.Squish.DDS.PixelFormatFlags.RGB &&
					  this.Header.PixelFormat.RGBBitCount == 32 &&
					  this.Header.PixelFormat.RedBitMask == 0x000000ff &&
					  this.Header.PixelFormat.GreenBitMask == 0x0000ff00 &&
					  this.Header.PixelFormat.BlueBitMask == 0x00ff0000 &&
					  this.Header.PixelFormat.AlphaBitMask == 0x00000000) {
					fileFormat = Gibbed.Squish.DDS.FileFormat.X8B8G8R8;
				} else if (
					  this.Header.PixelFormat.Flags == Gibbed.Squish.DDS.PixelFormatFlags.RGBA &&
					  this.Header.PixelFormat.RGBBitCount == 16 &&
					  this.Header.PixelFormat.RedBitMask == 0x00007c00 &&
					  this.Header.PixelFormat.GreenBitMask == 0x000003e0 &&
					  this.Header.PixelFormat.BlueBitMask == 0x0000001f &&
					  this.Header.PixelFormat.AlphaBitMask == 0x00008000) {
					fileFormat = Gibbed.Squish.DDS.FileFormat.A1R5G5B5;
				} else if (
					  this.Header.PixelFormat.Flags == Gibbed.Squish.DDS.PixelFormatFlags.RGBA &&
					  this.Header.PixelFormat.RGBBitCount == 16 &&
					  this.Header.PixelFormat.RedBitMask == 0x00000f00 &&
					  this.Header.PixelFormat.GreenBitMask == 0x000000f0 &&
					  this.Header.PixelFormat.BlueBitMask == 0x0000000f &&
					  this.Header.PixelFormat.AlphaBitMask == 0x0000f000) {
					fileFormat = Gibbed.Squish.DDS.FileFormat.A4R4G4B4;
				} else if (
					  this.Header.PixelFormat.Flags == Gibbed.Squish.DDS.PixelFormatFlags.RGB &&
					  this.Header.PixelFormat.RGBBitCount == 24 &&
					  this.Header.PixelFormat.RedBitMask == 0x00ff0000 &&
					  this.Header.PixelFormat.GreenBitMask == 0x0000ff00 &&
					  this.Header.PixelFormat.BlueBitMask == 0x000000ff &&
					  this.Header.PixelFormat.AlphaBitMask == 0x00000000) {
					fileFormat = Gibbed.Squish.DDS.FileFormat.R8G8B8;
				} else if (
					  this.Header.PixelFormat.Flags == Gibbed.Squish.DDS.PixelFormatFlags.RGB &&
					  this.Header.PixelFormat.RGBBitCount == 16 &&
					  this.Header.PixelFormat.RedBitMask == 0x0000f800 &&
					  this.Header.PixelFormat.GreenBitMask == 0x000007e0 &&
					  this.Header.PixelFormat.BlueBitMask == 0x0000001f &&
					  this.Header.PixelFormat.AlphaBitMask == 0x00000000) {
					fileFormat = Gibbed.Squish.DDS.FileFormat.R5G6B5;
				}

				if (fileFormat == Gibbed.Squish.DDS.FileFormat.INVALID) {
					throw new FormatException("unsupported DDS format");
				}

				int pixelSize = (int)(this.Header.PixelFormat.RGBBitCount / 8);
				int rowPitch = 0;

				if ((this.Header.Flags & Gibbed.Squish.DDS.HeaderFlags.Pitch) != 0) {
					rowPitch = (int)this.Header.PitchOrLinearSize;
				} else if ((this.Header.Flags & Gibbed.Squish.DDS.HeaderFlags.LinerSize) != 0) {
					/* Linear size specified, compute row pitch. Of course, this
					 * should never happen as linear size is *supposed* to be for
					 * compressed textures. But Microsoft doesn't always play by the
					 * rules when it comes to DDS output. */
					rowPitch =
						(int)this.Header.PitchOrLinearSize /
						this.Header.Height;
				} else {
					/* Another case of Microsoft not obeying their standard is the
					 * 'Convert to..' shell extension that ships in the DirectX SDK.
					 * Seems to always leave flags empty, so no indication of pitch
					 * or linear size.
					 * 
					 * And - to top it all off - they leave PitchOrLinearSize as
					 * *zero*. Zero??? If we get this bizarre set of inputs, we just
					 * go 'screw it' and compute row pitch ourselves,
					 * 
					 * Making sure we DWORD align it (if that code path is enabled). */
					rowPitch = this.Header.Width * pixelSize;

#if	APPLY_PITCH_ALIGNMENT
					rowPitch = (((int)rowPitch + 3) & (~3));
#endif
				}

				var pixelData = new byte[rowPitch * this.Header.Height];
				if (input.Read(pixelData, 0, pixelData.Length) != pixelData.Length) {
					throw new EndOfStreamException();
				}

				this._PixelData = new byte[this.Header.Width * this.Header.Height * 4];

				for (int y = 0; y < this.Header.Height; y++) {
					int src = y * rowPitch;
					int dst = y * 4 * this.Header.Width;

					for (int x = 0; x < this.Header.Width; x++, src += pixelSize, dst += 4) {
						// Read our pixel
						uint color = 0;

						byte R = 0;
						byte G = 0;
						byte B = 0;
						byte A = 0;

						// Build our pixel colour as a DWORD	
						for (int loop = 0, shift = 0; loop < pixelSize; loop++, shift += 8) {
							color |= (uint)pixelData[src + loop] << shift;
						}

						switch (fileFormat) {
							case Gibbed.Squish.DDS.FileFormat.A8R8G8B8: {
									A = (byte)((color >> 24) & 0xFF);
									R = (byte)((color >> 16) & 0xFF);
									G = (byte)((color >> 8) & 0xFF);
									B = (byte)((color >> 0) & 0xFF);
									break;
								}

							case Gibbed.Squish.DDS.FileFormat.X8R8G8B8: {
									A = 0xFF;
									R = (byte)((color >> 16) & 0xFF);
									G = (byte)((color >> 8) & 0xFF);
									B = (byte)((color >> 0) & 0xFF);
									break;
								}

							case Gibbed.Squish.DDS.FileFormat.A8B8G8R8: {
									A = (byte)((color >> 24) & 0xFF);
									R = (byte)((color >> 0) & 0xFF);
									G = (byte)((color >> 8) & 0xFF);
									B = (byte)((color >> 16) & 0xFF);
									break;
								}

							case Gibbed.Squish.DDS.FileFormat.X8B8G8R8: {
									A = 0xFF;
									R = (byte)((color >> 0) & 0xFF);
									G = (byte)((color >> 8) & 0xFF);
									B = (byte)((color >> 16) & 0xFF);
									break;
								}

							case Gibbed.Squish.DDS.FileFormat.A1R5G5B5: {
									A = (byte)((color >> 15) * 0xFF);
									R = (byte)((color >> 10) & 0x1F);
									G = (byte)((color >> 5) & 0x1F);
									B = (byte)((color >> 0) & 0x1F);

									R = (byte)((R << 3) | (R >> 2));
									G = (byte)((G << 3) | (G >> 2));
									B = (byte)((B << 3) | (B >> 2));
									break;
								}

							case Gibbed.Squish.DDS.FileFormat.A4R4G4B4: {
									A = (byte)((color >> 12) & 0xFF);
									R = (byte)((color >> 8) & 0x0F);
									G = (byte)((color >> 4) & 0x0F);
									B = (byte)((color >> 0) & 0x0F);

									A = (byte)((A << 4) | (A >> 0));
									R = (byte)((R << 4) | (R >> 0));
									G = (byte)((G << 4) | (G >> 0));
									B = (byte)((B << 4) | (B >> 0));
									break;
								}

							case Gibbed.Squish.DDS.FileFormat.R8G8B8: {
									A = 0xFF;
									R = (byte)((color >> 16) & 0xFF);
									G = (byte)((color >> 8) & 0xFF);
									B = (byte)((color >> 0) & 0xFF);
									break;
								}

							case Gibbed.Squish.DDS.FileFormat.R5G6B5: {
									A = 0xFF;
									R = (byte)((color >> 11) & 0x1F);
									G = (byte)((color >> 5) & 0x3F);
									B = (byte)((color >> 0) & 0x1F);

									R = (byte)((R << 3) | (R >> 2));
									G = (byte)((G << 2) | (G >> 4));
									B = (byte)((B << 3) | (B >> 2));
									break;
								}

							default: {
									throw new NotSupportedException();
								}
						}

						this._PixelData[dst + 0] = R;
						this._PixelData[dst + 1] = G;
						this._PixelData[dst + 2] = B;
						this._PixelData[dst + 3] = A;
					}
				}
			}
		}
	}
}
