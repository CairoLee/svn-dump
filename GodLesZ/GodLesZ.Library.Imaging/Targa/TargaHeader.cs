using System.Collections.Generic;

namespace GodLesZ.Library.Imaging.Targa {

	/// <summary>
	/// This class holds all of the header properties of a Targa image. 
	/// This includes the TGA File Header section the ImageID and the Color Map.
	/// </summary>
	public class TargaHeader {
		private byte bImageIDLength = 0;
		private ETargetColorMapType eColorMapType = ETargetColorMapType.NO_COLOR_MAP;
		private ETargaImageType eImageType = ETargaImageType.NO_IMAGE_DATA;
		private short sColorMapFirstEntryIndex = 0;
		private short sColorMapLength = 0;
		private byte bColorMapEntrySize = 0;
		private short sXOrigin = 0;
		private short sYOrigin = 0;
		private short sWidth = 0;
		private short sHeight = 0;
		private byte bPixelDepth = 0;
		private byte bImageDescriptor = 0;
		private ETargaVerticalTransferOrder eVerticalTransferOrder = ETargaVerticalTransferOrder.UNKNOWN;
		private ETargaHorizontalTransferOrder eHorizontalTransferOrder = ETargaHorizontalTransferOrder.UNKNOWN;
		private byte bAttributeBits = 0;
		private string strImageIDValue = string.Empty;
		private System.Collections.Generic.List<System.Drawing.Color> cColorMap = new List<System.Drawing.Color>();


		/// <summary>
		/// Gets the number of attribute bits per pixel.
		/// </summary>
		public byte AttributeBits {
			get { return this.bAttributeBits; }
		}

		/// <summary>
		/// Gets identifying information about the image. 
		/// A value of zero in ImageIDLength indicates that no ImageIDValue is included with the image.
		/// </summary>
		public string ImageIDValue {
			get { return this.strImageIDValue; }
		}
		/// <summary>
		/// Gets the Color Map of the image, if any. The Color Map is represented by a list of System.Drawing.Color objects.
		/// </summary>
		public System.Collections.Generic.List<System.Drawing.Color> ColorMap {
			get { return this.cColorMap; }
		}

		/// <summary>
		/// Gets the offset from the beginning of the file to the Image Data.
		/// </summary>
		public int ImageDataOffset {
			get {
				// calculate the image data offset

				// start off with the number of bytes holding the header info.
				int intImageDataOffset = TargaConstants.HeaderByteLength;

				// add the Image ID length (could be variable)
				intImageDataOffset += this.bImageIDLength;

				// determine the number of bytes for each Color Map entry
				int Bytes = 0;
				switch (this.bColorMapEntrySize) {
					case 15:
						Bytes = 2;
						break;
					case 16:
						Bytes = 2;
						break;
					case 24:
						Bytes = 3;
						break;
					case 32:
						Bytes = 4;
						break;
				}

				// add the length of the color map
				intImageDataOffset += ((int)this.sColorMapLength * (int)Bytes);

				// return result
				return intImageDataOffset;
			}
		}

		/// <summary>
		/// Gets the number of bytes per pixel.
		/// </summary>
		public int BytesPerPixel {
			get {
				return (int)this.bPixelDepth / 8;
			}
		}

		/// <summary>
		/// Gets the number of bytes contained the ImageIDValue property. The maximum
		/// number of characters is 255. A value of zero indicates that no ImageIDValue is included with the
		/// image.
		/// </summary>
		public byte ImageIDLength {
			get { return this.bImageIDLength; }
		}

		/// <summary>
		/// Sets the ImageIDLength property, available only to objects in the same assembly as TargaHeader.
		/// </summary>
		/// <param name="bImageIDLength">The Image ID Length value read from the file.</param>
		internal protected void SetImageIDLength(byte bImageIDLength) {
			this.bImageIDLength = bImageIDLength;
		}

		/// <summary>
		/// Gets the type of color map (if any) included with the image. There are currently 2
		/// defined values for this field:
		/// NO_COLOR_MAP - indicates that no color-map data is included with this image.
		/// COLOR_MAP_INCLUDED - indicates that a color-map is included with this image.
		/// </summary>
		public ETargetColorMapType ColorMapType {
			get { return this.eColorMapType; }
		}

		/// <summary>
		/// Sets the ColorMapType property, available only to objects in the same assembly as TargaHeader.
		/// </summary>
		/// <param name="eColorMapType">One of the ColorMapType enumeration values.</param>
		internal protected void SetColorMapType(ETargetColorMapType eColorMapType) {
			this.eColorMapType = eColorMapType;
		}

		/// <summary>
		/// Gets one of the ImageType enumeration values indicating the type of Targa image read from the file.
		/// </summary>
		public ETargaImageType ImageType {
			get { return this.eImageType; }
		}

		/// <summary>
		/// Sets the ImageType property, available only to objects in the same assembly as TargaHeader.
		/// </summary>
		/// <param name="eImageType">One of the ImageType enumeration values.</param>
		internal protected void SetImageType(ETargaImageType eImageType) {
			this.eImageType = eImageType;
		}

		/// <summary>
		/// Gets the index of the first color map entry. ColorMapFirstEntryIndex refers to the starting entry in loading the color map.
		/// </summary>
		public short ColorMapFirstEntryIndex {
			get { return this.sColorMapFirstEntryIndex; }
		}

		/// <summary>
		/// Sets the ColorMapFirstEntryIndex property, available only to objects in the same assembly as TargaHeader.
		/// </summary>
		/// <param name="sColorMapFirstEntryIndex">The First Entry Index value read from the file.</param>
		internal protected void SetColorMapFirstEntryIndex(short sColorMapFirstEntryIndex) {
			this.sColorMapFirstEntryIndex = sColorMapFirstEntryIndex;
		}

		/// <summary>
		/// Gets total number of color map entries included.
		/// </summary>
		public short ColorMapLength {
			get { return this.sColorMapLength; }
		}

		/// <summary>
		/// Sets the ColorMapLength property, available only to objects in the same assembly as TargaHeader.
		/// </summary>
		/// <param name="sColorMapLength">The Color Map Length value read from the file.</param>
		internal protected void SetColorMapLength(short sColorMapLength) {
			this.sColorMapLength = sColorMapLength;
		}

		/// <summary>
		/// Gets the number of bits per entry in the Color Map. Typically 15, 16, 24 or 32-bit values are used.
		/// </summary>
		public byte ColorMapEntrySize {
			get { return this.bColorMapEntrySize; }
		}

		/// <summary>
		/// Sets the ColorMapEntrySize property, available only to objects in the same assembly as TargaHeader.
		/// </summary>
		/// <param name="bColorMapEntrySize">The Color Map Entry Size value read from the file.</param>
		internal protected void SetColorMapEntrySize(byte bColorMapEntrySize) {
			this.bColorMapEntrySize = bColorMapEntrySize;
		}

		/// <summary>
		/// Gets the absolute horizontal coordinate for the lower
		/// left corner of the image as it is positioned on a display device having
		/// an origin at the lower left of the screen (e.g., the TARGA series).
		/// </summary>
		public short XOrigin {
			get { return this.sXOrigin; }
		}

		/// <summary>
		/// Sets the XOrigin property, available only to objects in the same assembly as TargaHeader.
		/// </summary>
		/// <param name="sXOrigin">The X Origin value read from the file.</param>
		internal protected void SetXOrigin(short sXOrigin) {
			this.sXOrigin = sXOrigin;
		}

		/// <summary>
		/// These bytes specify the absolute vertical coordinate for the lower left
		/// corner of the image as it is positioned on a display device having an
		/// origin at the lower left of the screen (e.g., the TARGA series).
		/// </summary>
		public short YOrigin {
			get { return this.sYOrigin; }
		}

		/// <summary>
		/// Sets the YOrigin property, available only to objects in the same assembly as TargaHeader.
		/// </summary>
		/// <param name="sYOrigin">The Y Origin value read from the file.</param>
		internal protected void SetYOrigin(short sYOrigin) {
			this.sYOrigin = sYOrigin;
		}

		/// <summary>
		/// Gets the width of the image in pixels.
		/// </summary>
		public short Width {
			get { return this.sWidth; }
		}

		/// <summary>
		/// Sets the Width property, available only to objects in the same assembly as TargaHeader.
		/// </summary>
		/// <param name="sWidth">The Width value read from the file.</param>
		internal protected void SetWidth(short sWidth) {
			this.sWidth = sWidth;
		}

		/// <summary>
		/// Gets the height of the image in pixels.
		/// </summary>
		public short Height {
			get { return this.sHeight; }
		}

		/// <summary>
		/// Sets the Height property, available only to objects in the same assembly as TargaHeader.
		/// </summary>
		/// <param name="sHeight">The Height value read from the file.</param>
		internal protected void SetHeight(short sHeight) {
			this.sHeight = sHeight;
		}

		/// <summary>
		/// Gets the number of bits per pixel. This number includes
		/// the Attribute or Alpha channel bits. Common values are 8, 16, 24 and 32.
		/// </summary>
		public byte PixelDepth {
			get { return this.bPixelDepth; }
		}

		/// <summary>
		/// Sets the PixelDepth property, available only to objects in the same assembly as TargaHeader.
		/// </summary>
		/// <param name="bPixelDepth">The Pixel Depth value read from the file.</param>
		internal protected void SetPixelDepth(byte bPixelDepth) {
			this.bPixelDepth = bPixelDepth;
		}

		/// <summary>
		/// Gets or Sets the ImageDescriptor property. The ImageDescriptor is the byte that holds the 
		/// Image Origin and Attribute Bits values.
		/// Available only to objects in the same assembly as TargaHeader.
		/// </summary>
		internal protected byte ImageDescriptor {
			get { return this.bImageDescriptor; }
			set { this.bImageDescriptor = value; }
		}

		/// <summary>
		/// Gets one of the FirstPixelDestination enumeration values specifying the screen destination of first pixel based on VerticalTransferOrder and HorizontalTransferOrder
		/// </summary>
		public ETargaFirstPixelDestination FirstPixelDestination {
			get {

				if (this.eVerticalTransferOrder == ETargaVerticalTransferOrder.UNKNOWN || this.eHorizontalTransferOrder == ETargaHorizontalTransferOrder.UNKNOWN)
					return ETargaFirstPixelDestination.UNKNOWN;
				else if (this.eVerticalTransferOrder == ETargaVerticalTransferOrder.BOTTOM && this.eHorizontalTransferOrder == ETargaHorizontalTransferOrder.LEFT)
					return ETargaFirstPixelDestination.BOTTOM_LEFT;
				else if (this.eVerticalTransferOrder == ETargaVerticalTransferOrder.BOTTOM && this.eHorizontalTransferOrder == ETargaHorizontalTransferOrder.RIGHT)
					return ETargaFirstPixelDestination.BOTTOM_RIGHT;
				else if (this.eVerticalTransferOrder == ETargaVerticalTransferOrder.TOP && this.eHorizontalTransferOrder == ETargaHorizontalTransferOrder.LEFT)
					return ETargaFirstPixelDestination.TOP_LEFT;
				else
					return ETargaFirstPixelDestination.TOP_RIGHT;

			}
		}


		/// <summary>
		/// Gets one of the VerticalTransferOrder enumeration values specifying the top-to-bottom ordering in which pixel data is transferred from the file to the screen.
		/// </summary>
		public ETargaVerticalTransferOrder VerticalTransferOrder {
			get { return this.eVerticalTransferOrder; }
		}

		/// <summary>
		/// Sets the VerticalTransferOrder property, available only to objects in the same assembly as TargaHeader.
		/// </summary>
		/// <param name="eVerticalTransferOrder">One of the VerticalTransferOrder enumeration values.</param>
		internal protected void SetVerticalTransferOrder(ETargaVerticalTransferOrder eVerticalTransferOrder) {
			this.eVerticalTransferOrder = eVerticalTransferOrder;
		}

		/// <summary>
		/// Gets one of the HorizontalTransferOrder enumeration values specifying the left-to-right ordering in which pixel data is transferred from the file to the screen.
		/// </summary>
		public ETargaHorizontalTransferOrder HorizontalTransferOrder {
			get { return this.eHorizontalTransferOrder; }
		}

		/// <summary>
		/// Sets the HorizontalTransferOrder property, available only to objects in the same assembly as TargaHeader.
		/// </summary>
		/// <param name="eHorizontalTransferOrder">One of the HorizontalTransferOrder enumeration values.</param>
		internal protected void SetHorizontalTransferOrder(ETargaHorizontalTransferOrder eHorizontalTransferOrder) {
			this.eHorizontalTransferOrder = eHorizontalTransferOrder;
		}

		/// <summary>
		/// Sets the AttributeBits property, available only to objects in the same assembly as TargaHeader.
		/// </summary>
		/// <param name="bAttributeBits">The Attribute Bits value read from the file.</param>
		internal protected void SetAttributeBits(byte bAttributeBits) {
			this.bAttributeBits = bAttributeBits;
		}

		/// <summary>
		/// Sets the ImageIDValue property, available only to objects in the same assembly as TargaHeader.
		/// </summary>
		/// <param name="strImageIDValue">The Image ID value read from the file.</param>
		internal protected void SetImageIDValue(string strImageIDValue) {
			this.strImageIDValue = strImageIDValue;
		}

	}

}
