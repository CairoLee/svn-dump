using System;
using System.Collections.Generic;
using System.Drawing;

namespace GodLesZ.Library.Imaging.Targa {

	/// <summary>
	/// This class holds all of the Extension Area properties of the Targa image. If an Extension Area exists in the file.
	/// </summary>
	public class TargaExtensionArea {
		int intExtensionSize = 0;
		string strAuthorName = string.Empty;
		string strAuthorComments = string.Empty;
		DateTime dtDateTimeStamp = DateTime.Now;
		string strJobName = string.Empty;
		TimeSpan dtJobTime = TimeSpan.Zero;
		string strSoftwareID = string.Empty;
		string strSoftwareVersion = string.Empty;
		Color cKeyColor = Color.Empty;
		int intPixelAspectRatioNumerator = 0;
		int intPixelAspectRatioDenominator = 0;
		int intGammaNumerator = 0;
		int intGammaDenominator = 0;
		int intColorCorrectionOffset = 0;
		int intPostageStampOffset = 0;
		int intScanLineOffset = 0;
		int intAttributesType = 0;
		private System.Collections.Generic.List<int> intScanLineTable = new List<int>();
		private System.Collections.Generic.List<System.Drawing.Color> cColorCorrectionTable = new List<System.Drawing.Color>();

		/// <summary>
		/// Gets the number of Bytes in the fixed-length portion of the ExtensionArea. 
		/// For Version 2.0 of the TGA File Format, this number should be set to 495
		/// </summary>
		public int ExtensionSize {
			get { return this.intExtensionSize; }
		}

		/// <summary>
		/// Sets the ExtensionSize property, available only to objects in the same assembly as TargaExtensionArea.
		/// </summary>
		/// <param name="intExtensionSize">The Extension Size value read from the file.</param>
		internal protected void SetExtensionSize(int intExtensionSize) {
			this.intExtensionSize = intExtensionSize;
		}

		/// <summary>
		/// Gets the name of the person who created the image.
		/// </summary>
		public string AuthorName {
			get { return this.strAuthorName; }
		}

		/// <summary>
		/// Sets the AuthorName property, available only to objects in the same assembly as TargaExtensionArea.
		/// </summary>
		/// <param name="strAuthorName">The Author Name value read from the file.</param>
		internal protected void SetAuthorName(string strAuthorName) {
			this.strAuthorName = strAuthorName;
		}

		/// <summary>
		/// Gets the comments from the author who created the image.
		/// </summary>
		public string AuthorComments {
			get { return this.strAuthorComments; }
		}

		/// <summary>
		/// Sets the AuthorComments property, available only to objects in the same assembly as TargaExtensionArea.
		/// </summary>
		/// <param name="strAuthorComments">The Author Comments value read from the file.</param>
		internal protected void SetAuthorComments(string strAuthorComments) {
			this.strAuthorComments = strAuthorComments;
		}

		/// <summary>
		/// Gets the date and time that the image was saved.
		/// </summary>
		public DateTime DateTimeStamp {
			get { return this.dtDateTimeStamp; }
		}

		/// <summary>
		/// Sets the DateTimeStamp property, available only to objects in the same assembly as TargaExtensionArea.
		/// </summary>
		/// <param name="dtDateTimeStamp">The Date Time Stamp value read from the file.</param>
		internal protected void SetDateTimeStamp(DateTime dtDateTimeStamp) {
			this.dtDateTimeStamp = dtDateTimeStamp;
		}

		/// <summary>
		/// Gets the name or id tag which refers to the job with which the image was associated.
		/// </summary>
		public string JobName {
			get { return this.strJobName; }
		}

		/// <summary>
		/// Sets the JobName property, available only to objects in the same assembly as TargaExtensionArea.
		/// </summary>
		/// <param name="strJobName">The Job Name value read from the file.</param>
		internal protected void SetJobName(string strJobName) {
			this.strJobName = strJobName;
		}

		/// <summary>
		/// Gets the job elapsed time when the image was saved.
		/// </summary>
		public TimeSpan JobTime {
			get { return this.dtJobTime; }
		}

		/// <summary>
		/// Sets the JobTime property, available only to objects in the same assembly as TargaExtensionArea.
		/// </summary>
		/// <param name="dtJobTime">The Job Time value read from the file.</param>
		internal protected void SetJobTime(TimeSpan dtJobTime) {
			this.dtJobTime = dtJobTime;
		}

		/// <summary>
		/// Gets the Software ID. Usually used to determine and record with what program a particular image was created.
		/// </summary>
		public string SoftwareID {
			get { return this.strSoftwareID; }
		}

		/// <summary>
		/// Sets the SoftwareID property, available only to objects in the same assembly as TargaExtensionArea.
		/// </summary>
		/// <param name="strSoftwareID">The Software ID value read from the file.</param>
		internal protected void SetSoftwareID(string strSoftwareID) {
			this.strSoftwareID = strSoftwareID;
		}

		/// <summary>
		/// Gets the version of software defined by the SoftwareID.
		/// </summary>
		public string SoftwareVersion {
			get { return this.strSoftwareVersion; }
		}

		/// <summary>
		/// Sets the SoftwareVersion property, available only to objects in the same assembly as TargaExtensionArea.
		/// </summary>
		/// <param name="strSoftwareVersion">The Software Version value read from the file.</param>
		internal protected void SetSoftwareVersion(string strSoftwareVersion) {
			this.strSoftwareVersion = strSoftwareVersion;
		}

		/// <summary>
		/// Gets the key color in effect at the time the image is saved.
		/// The Key Color can be thought of as the "background color" or "transparent color".
		/// </summary>
		public Color KeyColor {
			get { return this.cKeyColor; }
		}

		/// <summary>
		/// Sets the KeyColor property, available only to objects in the same assembly as TargaExtensionArea.
		/// </summary>
		/// <param name="cKeyColor">The Key Color value read from the file.</param>
		internal protected void SetKeyColor(Color cKeyColor) {
			this.cKeyColor = cKeyColor;
		}

		/// <summary>
		/// Gets the Pixel Ratio Numerator.
		/// </summary>
		public int PixelAspectRatioNumerator {
			get { return this.intPixelAspectRatioNumerator; }
		}

		/// <summary>
		/// Sets the PixelAspectRatioNumerator property, available only to objects in the same assembly as TargaExtensionArea.
		/// </summary>
		/// <param name="intPixelAspectRatioNumerator">The Pixel Aspect Ratio Numerator value read from the file.</param>
		internal protected void SetPixelAspectRatioNumerator(int intPixelAspectRatioNumerator) {
			this.intPixelAspectRatioNumerator = intPixelAspectRatioNumerator;
		}

		/// <summary>
		/// Gets the Pixel Ratio Denominator.
		/// </summary>
		public int PixelAspectRatioDenominator {
			get { return this.intPixelAspectRatioDenominator; }
		}

		/// <summary>
		/// Sets the PixelAspectRatioDenominator property, available only to objects in the same assembly as TargaExtensionArea.
		/// </summary>
		/// <param name="intPixelAspectRatioDenominator">The Pixel Aspect Ratio Denominator value read from the file.</param>
		internal protected void SetPixelAspectRatioDenominator(int intPixelAspectRatioDenominator) {
			this.intPixelAspectRatioDenominator = intPixelAspectRatioDenominator;
		}

		/// <summary>
		/// Gets the Pixel Aspect Ratio.
		/// </summary>
		public float PixelAspectRatio {
			get {
				if (this.intPixelAspectRatioDenominator > 0) {
					return (float)this.intPixelAspectRatioNumerator / (float)this.intPixelAspectRatioDenominator;
				} else
					return 0.0F;
			}
		}

		/// <summary>
		/// Gets the Gamma Numerator.
		/// </summary>
		public int GammaNumerator {
			get { return this.intGammaNumerator; }
		}

		/// <summary>
		/// Sets the GammaNumerator property, available only to objects in the same assembly as TargaExtensionArea.
		/// </summary>
		/// <param name="intGammaNumerator">The Gamma Numerator value read from the file.</param>
		internal protected void SetGammaNumerator(int intGammaNumerator) {
			this.intGammaNumerator = intGammaNumerator;
		}

		/// <summary>
		/// Gets the Gamma Denominator.
		/// </summary>
		public int GammaDenominator {
			get { return this.intGammaDenominator; }
		}

		/// <summary>
		/// Sets the GammaDenominator property, available only to objects in the same assembly as TargaExtensionArea.
		/// </summary>
		/// <param name="intGammaDenominator">The Gamma Denominator value read from the file.</param>
		internal protected void SetGammaDenominator(int intGammaDenominator) {
			this.intGammaDenominator = intGammaDenominator;
		}

		/// <summary>
		/// Gets the Gamma Ratio.
		/// </summary>
		public float GammaRatio {
			get {
				if (this.intGammaDenominator > 0) {
					float ratio = (float)this.intGammaNumerator / (float)this.intGammaDenominator;
					return (float)Math.Round(ratio, 1);
				} else
					return 1.0F;
			}
		}

		/// <summary>
		/// Gets the offset from the beginning of the file to the start of the Color Correction table.
		/// </summary>
		public int ColorCorrectionOffset {
			get { return this.intColorCorrectionOffset; }
		}

		/// <summary>
		/// Sets the ColorCorrectionOffset property, available only to objects in the same assembly as TargaExtensionArea.
		/// </summary>
		/// <param name="intColorCorrectionOffset">The Color Correction Offset value read from the file.</param>
		internal protected void SetColorCorrectionOffset(int intColorCorrectionOffset) {
			this.intColorCorrectionOffset = intColorCorrectionOffset;
		}

		/// <summary>
		/// Gets the offset from the beginning of the file to the start of the Postage Stamp image data.
		/// </summary>
		public int PostageStampOffset {
			get { return this.intPostageStampOffset; }
		}

		/// <summary>
		/// Sets the PostageStampOffset property, available only to objects in the same assembly as TargaExtensionArea.
		/// </summary>
		/// <param name="intPostageStampOffset">The Postage Stamp Offset value read from the file.</param>
		internal protected void SetPostageStampOffset(int intPostageStampOffset) {
			this.intPostageStampOffset = intPostageStampOffset;
		}

		/// <summary>
		/// Gets the offset from the beginning of the file to the start of the Scan Line table.
		/// </summary>
		public int ScanLineOffset {
			get { return this.intScanLineOffset; }
		}

		/// <summary>
		/// Sets the ScanLineOffset property, available only to objects in the same assembly as TargaExtensionArea.
		/// </summary>
		/// <param name="intScanLineOffset">The Scan Line Offset value read from the file.</param>
		internal protected void SetScanLineOffset(int intScanLineOffset) {
			this.intScanLineOffset = intScanLineOffset;
		}

		/// <summary>
		/// Gets the type of Alpha channel data contained in the file.
		/// 0: No Alpha data included.
		/// 1: Undefined data in the Alpha field, can be ignored
		/// 2: Undefined data in the Alpha field, but should be retained
		/// 3: Useful Alpha channel data is present
		/// 4: Pre-multiplied Alpha (see description below)
		/// 5-127: RESERVED
		/// 128-255: Un-assigned
		/// </summary>
		public int AttributesType {
			get { return this.intAttributesType; }
		}

		/// <summary>
		/// Sets the AttributesType property, available only to objects in the same assembly as TargaExtensionArea.
		/// </summary>
		/// <param name="intAttributesType">The Attributes Type value read from the file.</param>
		internal protected void SetAttributesType(int intAttributesType) {
			this.intAttributesType = intAttributesType;
		}

		/// <summary>
		/// Gets a list of offsets from the beginning of the file that point to the start of the next scan line, 
		/// in the order that the image was saved 
		/// </summary>
		public System.Collections.Generic.List<int> ScanLineTable {
			get { return this.intScanLineTable; }
		}

		/// <summary>
		/// Gets a list of Colors where each Color value is the desired Color correction for that entry.
		/// This allows the user to store a correction table for image remapping or LUT driving.
		/// </summary>
		public System.Collections.Generic.List<System.Drawing.Color> ColorCorrectionTable {
			get { return this.cColorCorrectionTable; }
		}

	}

}
