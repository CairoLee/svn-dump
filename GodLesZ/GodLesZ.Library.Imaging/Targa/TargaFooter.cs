
namespace GodLesZ.Library.Imaging.Targa {

	/// <summary>
	/// Holds Footer infomation read from the image file.
	/// </summary>
	public class TargaFooter {
		private int intExtensionAreaOffset = 0;
		private int intDeveloperDirectoryOffset = 0;
		private string strSignature = string.Empty;
		private string strReservedCharacter = string.Empty;

		/// <summary>
		/// Gets the offset from the beginning of the file to the start of the Extension Area. 
		/// If the ExtensionAreaOffset is zero, no Extension Area exists in the file.
		/// </summary>
		public int ExtensionAreaOffset {
			get { return this.intExtensionAreaOffset; }
		}

		/// <summary>
		/// Sets the ExtensionAreaOffset property, available only to objects in the same assembly as TargaFooter.
		/// </summary>
		/// <param name="intExtensionAreaOffset">The Extension Area Offset value read from the file.</param>
		internal protected void SetExtensionAreaOffset(int intExtensionAreaOffset) {
			this.intExtensionAreaOffset = intExtensionAreaOffset;
		}

		/// <summary>
		/// Gets the offset from the beginning of the file to the start of the Developer Area.
		/// If the DeveloperDirectoryOffset is zero, then the Developer Area does not exist
		/// </summary>
		public int DeveloperDirectoryOffset {
			get { return this.intDeveloperDirectoryOffset; }
		}

		/// <summary>
		/// Sets the DeveloperDirectoryOffset property, available only to objects in the same assembly as TargaFooter.
		/// </summary>
		/// <param name="intDeveloperDirectoryOffset">The Developer Directory Offset value read from the file.</param>
		internal protected void SetDeveloperDirectoryOffset(int intDeveloperDirectoryOffset) {
			this.intDeveloperDirectoryOffset = intDeveloperDirectoryOffset;
		}

		/// <summary>
		/// This string is formatted exactly as "TRUEVISION-XFILE" (no quotes). If the
		/// signature is detected, the file is assumed to be a New TGA format and MAY,
		/// therefore, contain the Developer Area and/or the Extension Areas. If the
		/// signature is not found, then the file is assumed to be an Original TGA format.
		/// </summary>
		public string Signature {
			get { return this.strSignature; }
		}

		/// <summary>
		/// Sets the Signature property, available only to objects in the same assembly as TargaFooter.
		/// </summary>
		/// <param name="strSignature">The Signature value read from the file.</param>
		internal protected void SetSignature(string strSignature) {
			this.strSignature = strSignature;
		}

		/// <summary>
		/// A New Targa format reserved character "." (period)
		/// </summary>
		public string ReservedCharacter {
			get { return this.strReservedCharacter; }
		}

		/// <summary>
		/// Sets the ReservedCharacter property, available only to objects in the same assembly as TargaFooter.
		/// </summary>
		/// <param name="strReservedCharacter">The ReservedCharacter value read from the file.</param>
		internal protected void SetReservedCharacter(string strReservedCharacter) {
			this.strReservedCharacter = strReservedCharacter;
		}

		/// <summary>
		/// Creates a new instance of the TargaFooter class.
		/// </summary>
		public TargaFooter() { }


	}

}
