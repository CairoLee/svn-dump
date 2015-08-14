using System;

namespace GodLesZ.Library.Csv {

	/// <summary>
	/// Defines the data reader validations.
	/// </summary>
	[Flags]
	public enum EDataReaderValidations {
		/// <summary>
		/// No validation.
		/// </summary>
		None = 0,

		/// <summary>
		/// Validate that the data reader is initialized.
		/// </summary>
		IsInitialized = 1,

		/// <summary>
		/// Validate that the data reader is not closed.
		/// </summary>
		IsNotClosed = 2
	}

}