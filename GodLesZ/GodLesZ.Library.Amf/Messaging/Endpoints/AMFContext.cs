using System.IO;
using GodLesZ.Library.Amf.Context;
using GodLesZ.Library.Amf.IO;

namespace GodLesZ.Library.Amf.Messaging.Endpoints {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMFContext {
		/// <summary>
		/// This member supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		public const string FluorineAMFContextKey = "__@fluorineamfcontext";

		AMFMessage _amfMessage;
		MessageOutput _messageOutput;
		Stream _inputStream;
		Stream _outputStream;

		/// <summary>
		/// Initializes a new instance of the AMFContext class.
		/// </summary>
		public AMFContext(Stream inputStream, Stream outputStream) {
			_inputStream = inputStream;
			_outputStream = outputStream;
		}


		public AMFMessage AMFMessage {
			get { return _amfMessage; }
			set { _amfMessage = value; }
		}

		public MessageOutput MessageOutput {
			get { return _messageOutput; }
			set { _messageOutput = value; }
		}

		public Stream InputStream {
			get { return _inputStream; }
		}

		public Stream OutputStream {
			get { return _outputStream; }
		}

		/// <summary>
		/// Gets the FluorineContext object for the current HTTP request.
		/// </summary>
		static public AMFContext Current {
			get {
				AMFContext context = FluorineWebSafeCallContext.GetData(AMFContext.FluorineAMFContextKey) as AMFContext;
				return context;
			}
			set {
				FluorineWebSafeCallContext.SetData(AMFContext.FluorineAMFContextKey, value);
			}
		}
	}
}
