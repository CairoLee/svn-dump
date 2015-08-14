using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using GodLesZ.Library.Amf.IO;
using GodLesZ.Library.Amf.Messaging.Api;
using GodLesZ.Library.Amf.Messaging.Api.Service;
using GodLesZ.Library.Amf.Messaging.Messages;
using GodLesZ.Library.Amf.Messaging.Rtmp.Event;
using GodLesZ.Library.Amf.Messaging.Rtmp.Service;

namespace GodLesZ.Library.Amf.Net {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class RemotingClient : INetConnectionClient {
		string _gatewayUrl;
		readonly NetConnection _netConnection;

		public RemotingClient(NetConnection netConnection) {
			_netConnection = netConnection;
		}

		#region INetConnectionClient Members

		public IConnection Connection {
			get { return null; }
		}

		public void Connect(string command, params object[] arguments) {
			_gatewayUrl = command;
		}

		public void Close() {
		}

		public bool Connected {
			get { return true; }
		}

		public void Call(string command, IPendingServiceCallback callback, params object[] arguments) {
			try {
				TypeHelper._Init();

				Uri uri = new Uri(_gatewayUrl);
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
				request.ContentType = ContentType.AMF;
				request.Method = "POST";
#if !(SILVERLIGHT)
				request.CookieContainer = _netConnection.CookieContainer;
#endif
				AMFMessage amfMessage = new AMFMessage((ushort)_netConnection.ObjectEncoding);
				AMFBody amfBody = new AMFBody(command, callback.GetHashCode().ToString(), arguments);
				amfMessage.AddBody(amfBody);
				foreach (KeyValuePair<string, AMFHeader> entry in _netConnection.Headers) {
					amfMessage.AddHeader(entry.Value);
				}
				PendingCall call = new PendingCall(command, arguments);
				AmfRequestData amfRequestData = new AmfRequestData(request, amfMessage, call, callback, null);
				request.BeginGetRequestStream(BeginRequestFlashCall, amfRequestData);
			} catch (Exception ex) {
				_netConnection.RaiseNetStatus(ex);
			}
		}

		public void Call<T>(string command, Responder<T> responder, params object[] arguments) {
			try {
				TypeHelper._Init();

				Uri uri = new Uri(_gatewayUrl);
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
				request.ContentType = ContentType.AMF;
				request.Method = "POST";
#if !(SILVERLIGHT)
				request.CookieContainer = _netConnection.CookieContainer;
#endif
				AMFMessage amfMessage = new AMFMessage((ushort)_netConnection.ObjectEncoding);
				AMFBody amfBody = new AMFBody(command, responder.GetHashCode().ToString(), arguments);
				amfMessage.AddBody(amfBody);
				foreach (KeyValuePair<string, AMFHeader> entry in _netConnection.Headers) {
					amfMessage.AddHeader(entry.Value);
				}
				AmfRequestData amfRequestData = new AmfRequestData(request, amfMessage, null, null, responder);
				request.BeginGetRequestStream(BeginRequestFlashCall, amfRequestData);
			} catch (Exception ex) {
				_netConnection.RaiseNetStatus(ex);
			}
		}

		private void BeginRequestFlashCall(IAsyncResult ar) {
			try {
				AmfRequestData amfRequestData = ar.AsyncState as AmfRequestData;
				if (amfRequestData != null) {
					Stream requestStream = amfRequestData.Request.EndGetRequestStream(ar);
					AMFSerializer amfSerializer = new AMFSerializer(requestStream);
					amfSerializer.WriteMessage(amfRequestData.AmfMessage);
					amfSerializer.Flush();
					amfSerializer.Close();

					amfRequestData.Request.BeginGetResponse(BeginResponseFlashCall, amfRequestData);
				}
			} catch (Exception ex) {
				_netConnection.RaiseNetStatus(ex);
			}
		}

		private void BeginResponseFlashCall(IAsyncResult ar) {
			try {
				AmfRequestData amfRequestData = ar.AsyncState as AmfRequestData;
				if (amfRequestData != null) {
					HttpWebResponse response = (HttpWebResponse)amfRequestData.Request.EndGetResponse(ar);
					if (response != null) {
						//Get response and deserialize
						Stream responseStream = response.GetResponseStream();
						if (responseStream != null) {
							AMFDeserializer amfDeserializer = new AMFDeserializer(responseStream);
							AMFMessage responseMessage = amfDeserializer.ReadAMFMessage();
							AMFBody responseBody = responseMessage.GetBodyAt(0);
							for (int i = 0; i < responseMessage.HeaderCount; i++) {
								AMFHeader header = responseMessage.GetHeaderAt(i);
								if (header.Name == AMFHeader.RequestPersistentHeader)
									_netConnection.AddHeader(header.Name, header.MustUnderstand, header.Content);
							}
							if (amfRequestData.Call != null) {
								PendingCall call = amfRequestData.Call;
								call.Result = responseBody.Content;
								call.Status = responseBody.Target.EndsWith(AMFBody.OnStatus) ? Messaging.Rtmp.Service.Call.STATUS_INVOCATION_EXCEPTION : Messaging.Rtmp.Service.Call.STATUS_SUCCESS_RESULT;
								amfRequestData.Callback.ResultReceived(call);
							}
							if (amfRequestData.Responder != null) {
								if (responseBody.Target.EndsWith(AMFBody.OnStatus)) {
									StatusFunction statusFunction = amfRequestData.Responder.GetType().GetProperty("Status").GetValue(amfRequestData.Responder, null) as StatusFunction;
									if (statusFunction != null)
										statusFunction(new Fault(responseBody.Content));
								} else {
									Delegate resultFunction = amfRequestData.Responder.GetType().GetProperty("Result").GetValue(amfRequestData.Responder, null) as Delegate;
									if (resultFunction != null) {
										ParameterInfo[] arguments = resultFunction.Method.GetParameters();
										object result = TypeHelper.ChangeType(responseBody.Content, arguments[0].ParameterType);
										resultFunction.DynamicInvoke(result);
									}
								}
							}
						} else
							_netConnection.RaiseNetStatus("Could not aquire ResponseStream");
					} else
						_netConnection.RaiseNetStatus("Could not aquire HttpWebResponse");
				}
			} catch (Exception ex) {
				_netConnection.RaiseNetStatus(ex);
			}
		}

		public void Call(string endpoint, string destination, string source, string operation, IPendingServiceCallback callback, params object[] arguments) {
			if (_netConnection.ObjectEncoding == ObjectEncoding.AMF0)
				throw new NotSupportedException("AMF0 not supported for Flex RPC");
			try {
				TypeHelper._Init();

				Uri uri = new Uri(_gatewayUrl);
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
				request.ContentType = ContentType.AMF;
				request.Method = "POST";
#if !(SILVERLIGHT)
				request.CookieContainer = _netConnection.CookieContainer;
#endif
				AMFMessage amfMessage = new AMFMessage((ushort)_netConnection.ObjectEncoding);

				RemotingMessage remotingMessage = new RemotingMessage();
				remotingMessage.clientId = Guid.NewGuid().ToString("D");
				remotingMessage.destination = destination;
				remotingMessage.messageId = Guid.NewGuid().ToString("D");
				remotingMessage.timestamp = 0;
				remotingMessage.timeToLive = 0;
				remotingMessage.SetHeader(MessageBase.EndpointHeader, endpoint);
				remotingMessage.SetHeader(MessageBase.FlexClientIdHeader, _netConnection.ClientId ?? "nil");
				//Service stuff
				remotingMessage.source = source;
				remotingMessage.operation = operation;
				remotingMessage.body = arguments;

				foreach (KeyValuePair<string, AMFHeader> entry in _netConnection.Headers) {
					amfMessage.AddHeader(entry.Value);
				}
				AMFBody amfBody = new AMFBody(null, null, new object[] { remotingMessage });
				amfMessage.AddBody(amfBody);

				PendingCall call = new PendingCall(source, operation, arguments);
				AmfRequestData amfRequestData = new AmfRequestData(request, amfMessage, call, callback, null);
				request.BeginGetRequestStream(BeginRequestFlexCall, amfRequestData);
			} catch (Exception ex) {
				_netConnection.RaiseNetStatus(ex);
			}
		}

		public void Call<T>(string endpoint, string destination, string source, string operation, Responder<T> responder, params object[] arguments) {
			if (_netConnection.ObjectEncoding == ObjectEncoding.AMF0)
				throw new NotSupportedException("AMF0 not supported for Flex RPC");
			try {
				TypeHelper._Init();

				Uri uri = new Uri(_gatewayUrl);
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
				request.ContentType = ContentType.AMF;
				request.Method = "POST";
#if !(SILVERLIGHT)
				request.CookieContainer = _netConnection.CookieContainer;
#endif
				AMFMessage amfMessage = new AMFMessage((ushort)_netConnection.ObjectEncoding);

				RemotingMessage remotingMessage = new RemotingMessage();
				remotingMessage.clientId = Guid.NewGuid().ToString("D");
				remotingMessage.destination = destination;
				remotingMessage.messageId = Guid.NewGuid().ToString("D");
				remotingMessage.timestamp = 0;
				remotingMessage.timeToLive = 0;
				remotingMessage.SetHeader(MessageBase.EndpointHeader, endpoint);
				remotingMessage.SetHeader(MessageBase.FlexClientIdHeader, _netConnection.ClientId ?? "nil");
				//Service stuff
				remotingMessage.source = source;
				remotingMessage.operation = operation;
				remotingMessage.body = arguments;

				foreach (KeyValuePair<string, AMFHeader> entry in _netConnection.Headers) {
					amfMessage.AddHeader(entry.Value);
				}
				AMFBody amfBody = new AMFBody(null, null, new object[] { remotingMessage });
				amfMessage.AddBody(amfBody);

				AmfRequestData amfRequestData = new AmfRequestData(request, amfMessage, null, null, responder);
				request.BeginGetRequestStream(BeginRequestFlexCall, amfRequestData);
			} catch (Exception ex) {
				_netConnection.RaiseNetStatus(ex);
			}
		}

		private void BeginRequestFlexCall(IAsyncResult ar) {
			try {
				AmfRequestData amfRequestData = ar.AsyncState as AmfRequestData;
				if (amfRequestData != null) {
					Stream requestStream = amfRequestData.Request.EndGetRequestStream(ar);
					AMFSerializer amfSerializer = new AMFSerializer(requestStream);
					amfSerializer.WriteMessage(amfRequestData.AmfMessage);
					amfSerializer.Flush();
					amfSerializer.Close();

					amfRequestData.Request.BeginGetResponse(BeginResponseFlexCall, amfRequestData);
				}
			} catch (Exception ex) {
				_netConnection.RaiseNetStatus(ex);
			}
		}

		private void BeginResponseFlexCall(IAsyncResult ar) {
			try {
				AmfRequestData amfRequestData = ar.AsyncState as AmfRequestData;
				if (amfRequestData != null) {
					HttpWebResponse response = (HttpWebResponse)amfRequestData.Request.EndGetResponse(ar);
					if (response != null) {
						//Get response and deserialize
						Stream responseStream = response.GetResponseStream();
						if (responseStream != null) {
							AMFDeserializer amfDeserializer = new AMFDeserializer(responseStream);
							AMFMessage responseMessage = amfDeserializer.ReadAMFMessage();
							AMFBody responseBody = responseMessage.GetBodyAt(0);
							for (int i = 0; i < responseMessage.HeaderCount; i++) {
								AMFHeader header = responseMessage.GetHeaderAt(i);
								if (header.Name == AMFHeader.RequestPersistentHeader)
									_netConnection.AddHeader(header.Name, header.MustUnderstand, header.Content);
							}
							object message = responseBody.Content;
							if (message is ErrorMessage) {
								/*
								ASObject status = new ASObject();
								status["level"] = "error";
								status["code"] = "NetConnection.Call.Failed";
								status["description"] = (result as ErrorMessage).faultString;
								status["details"] = result;
								_netConnection.RaiseNetStatus(status);
								*/
								if (amfRequestData.Call != null) {
									PendingCall call = amfRequestData.Call;
									call.Result = message;
									call.Status = Messaging.Rtmp.Service.Call.STATUS_INVOCATION_EXCEPTION;
									amfRequestData.Callback.ResultReceived(call);
								}
								if (amfRequestData.Responder != null) {
									StatusFunction statusFunction = amfRequestData.Responder.GetType().GetProperty("Status").GetValue(amfRequestData.Responder, null) as StatusFunction;
									if (statusFunction != null)
										statusFunction(new Fault(message as ErrorMessage));
								}
							} else if (message is AcknowledgeMessage) {
								AcknowledgeMessage ack = message as AcknowledgeMessage;
								if (_netConnection.ClientId == null && ack.HeaderExists(MessageBase.FlexClientIdHeader))
									_netConnection.SetClientId(ack.GetHeader(MessageBase.FlexClientIdHeader) as string);
								if (amfRequestData.Call != null) {
									PendingCall call = amfRequestData.Call;
									call.Result = ack.body;
									call.Status = Messaging.Rtmp.Service.Call.STATUS_SUCCESS_RESULT;
									amfRequestData.Callback.ResultReceived(call);
								}
								if (amfRequestData.Responder != null) {
									Delegate resultFunction = amfRequestData.Responder.GetType().GetProperty("Result").GetValue(amfRequestData.Responder, null) as Delegate;
									if (resultFunction != null) {
										ParameterInfo[] arguments = resultFunction.Method.GetParameters();
										object result = TypeHelper.ChangeType(ack.body, arguments[0].ParameterType);
										resultFunction.DynamicInvoke(result);
									}
								}
							}
						} else
							_netConnection.RaiseNetStatus("Could not aquire ResponseStream");
					} else
						_netConnection.RaiseNetStatus("Could not aquire HttpWebResponse");
				}
			} catch (Exception ex) {
				_netConnection.RaiseNetStatus(ex);
			}
		}

		public void Write(IRtmpEvent message) {
			throw new NotImplementedException();
		}

		#endregion
	}

	class AmfRequestData {
		readonly PendingCall _call;
		readonly HttpWebRequest _request;
		readonly AMFMessage _amfMessage;
		readonly IPendingServiceCallback _callback;
		readonly object _responder;

		internal PendingCall Call {
			get { return _call; }
		}

		public HttpWebRequest Request {
			get { return _request; }
		}

		public AMFMessage AmfMessage {
			get { return _amfMessage; }
		}

		public IPendingServiceCallback Callback {
			get { return _callback; }
		}

		public object Responder {
			get { return _responder; }
		}


		public AmfRequestData(HttpWebRequest request, AMFMessage amfMessage, PendingCall call, IPendingServiceCallback callback, object responder) {
			_call = call;
			_responder = responder;
			_request = request;
			_amfMessage = amfMessage;
			_callback = callback;
		}
	}
}
