using System;

namespace GodLesZ.Library.Amf {
	/// <summary>
	/// Indicates whether a type is a transfer object (value object). This class cannot be inherited.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public sealed class TransferObjectAttribute : System.Attribute {
		/// <summary>
		/// Initializes a new instance of the TransferObjectAttribute class.
		/// </summary>
		public TransferObjectAttribute() {
		}
	}
}
