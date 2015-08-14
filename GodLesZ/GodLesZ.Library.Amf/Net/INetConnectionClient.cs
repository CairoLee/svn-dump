using GodLesZ.Library.Amf.Messaging.Api;
using GodLesZ.Library.Amf.Messaging.Api.Service;
using GodLesZ.Library.Amf.Messaging.Rtmp.Event;

namespace GodLesZ.Library.Amf.Net {
	/// <summary>
	/// This interface supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	interface INetConnectionClient {
		void Connect(string command, params object[] arguments);
		void Close();
		bool Connected { get; }
		void Call(string command, IPendingServiceCallback callback, params object[] arguments);
		void Call<T>(string command, Responder<T> responder, params object[] arguments);
		void Call(string endpoint, string destination, string source, string operation, IPendingServiceCallback callback, params object[] arguments);
		void Call<T>(string endpoint, string destination, string source, string operation, Responder<T> responder, params object[] arguments);
		void Write(IRtmpEvent message);
		IConnection Connection { get; }
	}
}
