using System;
using System.Collections;
using System.Security;
using System.Security.Principal;
using System.Text;
using GodLesZ.Library.Amf.Messaging.Config;
using GodLesZ.Library.Amf.Messaging.Messages;
using log4net;

namespace GodLesZ.Library.Amf.Messaging.Services {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AuthenticationService : ServiceBase {
		private static readonly ILog log = LogManager.GetLogger(typeof(AuthenticationService));

		public const string ServiceId = "authentication-service";

		public AuthenticationService(MessageBroker broker, ServiceDefinition serviceDefinition)
			: base(broker, serviceDefinition) {
		}

		public override object ServiceMessage(IMessage message) {
			IMessage responseMessage = null;
			CommandMessage commandMessage = message as CommandMessage;
			if (commandMessage != null) {
				switch (commandMessage.operation) {
					case CommandMessage.LoginOperation:
						IPrincipal principal = null;
						try {
							principal = Authenticate(message);
						} catch (SecurityException) {
							throw;
						} catch (UnauthorizedAccessException) {
							throw;
						} catch (Exception exception) {
							string msg = __Res.GetString(__Res.Security_AuthenticationFailed);
							if (log.IsErrorEnabled)
								log.Error(msg, exception);
							throw new SecurityException(msg, exception);
						}
						if (principal == null) {
							string msg = __Res.GetString(__Res.Security_AuthenticationFailed);
							throw new SecurityException(msg);
						}
						responseMessage = new AcknowledgeMessage();
						responseMessage.body = "success";
						break;
					case CommandMessage.LogoutOperation:
						//TODO: Logs the user out of the destination. Logging out of a destination applies to everything connected using the same ChannelSet as specified in the server configuration.
						//For example, if you're connected over the my-rtmp channel and you log out using one of your RPC components, anything that was 
						//connected over the same ChannelSet is logged out.
						_messageBroker.LoginManager.Logout();
						responseMessage = new AcknowledgeMessage();
						responseMessage.body = "success";
						break;
				}
			}
			return responseMessage;
		}

		public override void CheckSecurity(IMessage message) {
			//Ignore for this service
		}


		private IPrincipal Authenticate(IMessage message) {
			IPrincipal principal = null;
			//if( message.headers != null && message.headers.ContainsKey(CommandMessage.RemoteCredentialsHeader) )
			if (message.body is string) {
				return Authenticate(message.body as string);
			}
			return principal;
		}

		internal IPrincipal Authenticate(string credentials) {
			string base64String = credentials;
			byte[] base64Data = System.Convert.FromBase64String(base64String);
			StringBuilder sb = new StringBuilder();
			sb.Append(UTF8Encoding.UTF8.GetChars(base64Data));
			string data = sb.ToString();
			string[] parts = data.Split(new char[] { ':' });
			string userId = parts[0];
			string password = parts[1];
			Hashtable credentialsDictionary = new Hashtable(1);
			credentialsDictionary["password"] = password;
			return _messageBroker.LoginManager.Login(userId, credentialsDictionary);
		}
	}
}
