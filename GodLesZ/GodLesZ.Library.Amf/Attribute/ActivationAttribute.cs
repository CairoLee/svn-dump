
using System;

namespace GodLesZ.Library.Amf {
	/// <summary>
	/// Indicates whether a type is an activator. This class cannot be inherited.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	[Obsolete("Activation mode is obsolete. Please use the factory mechanism instead.", true)]
	public sealed class ActivationAttribute : Attribute {
		string _activationMode;

		/// <summary>
		/// Initializes a new instance of the ActivationAttribute class.
		/// </summary>
		/// <param name="activationMode"></param>
		public ActivationAttribute(string activationMode) {
			_activationMode = activationMode;
		}
		/// <summary>
		/// Gets or sets the activation mode.
		/// </summary>
		public string ActivationMode {
			get { return _activationMode; }
		}

	}
}
