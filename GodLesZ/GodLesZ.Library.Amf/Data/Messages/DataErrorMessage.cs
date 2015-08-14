using System.Collections;

using GodLesZ.Library.Amf.Messaging.Messages;

namespace GodLesZ.Library.Amf.Data.Messages {
	/// <summary>
	/// ErrorMessage that will be sent when a data conflict occurs.
	/// </summary>
	class DataErrorMessage : ErrorMessage {
		public DataMessage cause;
		public object serverObject;
		public IList propertyNames;

		public DataErrorMessage() {
		}

		public DataErrorMessage(DataSyncException dataSyncException) {
			//cause = dataSyncException.ConflictCause;
			serverObject = dataSyncException.ServerObject;
			propertyNames = dataSyncException.PropertyNames;
		}

		/// <summary>
		/// Returns a string that represents the current DataErrorMessage object fields.
		/// </summary>
		/// <param name="indentLevel">The indentation level used for tracing the message members.</param>
		/// <returns>
		/// A string that represents the current DataErrorMessage object fields.
		/// </returns>
		protected override string ToStringFields(int indentLevel) {
			string sep = GetFieldSeparator(indentLevel);
			string value = base.ToStringFields(indentLevel);
			value += sep + "cause = " + (cause != null ? cause.ToString(indentLevel) : null);
			value += sep + "serverObject = " + serverObject;
			value += sep + "propertyNames = " + BodyToString(propertyNames, indentLevel);
			return value;
		}
	}
}
