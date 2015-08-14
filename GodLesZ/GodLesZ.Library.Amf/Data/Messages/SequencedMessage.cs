
using System;

using GodLesZ.Library.Amf.Messaging.Messages;

namespace GodLesZ.Library.Amf.Data.Messages {
	/// <summary>
	/// Clients receive this message in response to DataService.fill() request. 
	/// The body of the message is an Array of items that were returned from 
	/// the remote destination based on the fill parameters.
	/// </summary>
	[CLSCompliant(false)]
	public class SequencedMessage : AcknowledgeMessage {
		int _sequenceId;
		int _sequenceSize;
		DataMessage _dataMessage;
		object[] _sequenceProxies;

		/// <summary>
		/// Initializes a new instance of the SequencedMessage class.
		/// </summary>
		public SequencedMessage() {
		}

		/// <summary>
		/// Provides access to the sequence id for this message. 
		/// The sequence id is a unique identifier for a sequence within a remote destination. 
		/// This value is only unique for the endpoint and destination contacted. 
		/// </summary>
		public int sequenceId {
			get { return _sequenceId; }
			set { _sequenceId = value; }
		}
		/// <summary>
		/// Provides access to the sequence size for this message.
		/// The sequence size indicates how many items reside in the remote sequence. 
		/// </summary>
		public int sequenceSize {
			get { return _sequenceSize; }
			set { _sequenceSize = value; }
		}
		/// <summary>
		/// This member supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		public DataMessage dataMessage {
			get { return _dataMessage; }
			set { _dataMessage = value; }
		}
		/// <summary>
		/// This member supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		public object[] sequenceProxies {
			get { return _sequenceProxies; }
			set { _sequenceProxies = value; }
		}

		/// <summary>
		/// Returns a string that represents the current SequencedMessage object fields.
		/// </summary>
		/// <param name="indentLevel">The indentation level used for tracing the message members.</param>
		/// <returns>
		/// A string that represents the current SequencedMessage object fields.
		/// </returns>
		protected override string ToStringFields(int indentLevel) {
			string sep = GetFieldSeparator(indentLevel);
			string value = sep + "sequenceId = " + sequenceId + sep + "sequenceSize = " + sequenceSize;
			if (sequenceProxies == null || sequenceProxies.Length == 0) {
				value += sep + "(no sequence proxies)";
			} else {
				string sep2 = GetFieldSeparator(indentLevel + 1);
				value += sep + sequenceProxies.Length + " sequenceProxies ";
				for (int i = 0; i < sequenceProxies.Length; i++)
					value += sep2 + "[" + i + "] = " + BodyToString(sequenceProxies[i], indentLevel + 1);
			}
			if (dataMessage != null)
				value += sep + "dataMessage = " + dataMessage.ToString(indentLevel + 1);
			value += base.ToStringFields(indentLevel);
			return value;
		}
	}
}
