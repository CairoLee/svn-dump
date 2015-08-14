using System;
using System.Collections;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using GodLesZ.Library.Amf.IO;
using GodLesZ.Library.Amf.Security;
using log4net;

namespace GodLesZ.Library.Amf.Messaging.Endpoints.Filter {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AuthenticationFilter : AbstractFilter {
		private static readonly ILog log = LogManager.GetLogger(typeof(AuthenticationFilter));
		EndpointBase _endpoint;

		/// <summary>
		/// Initializes a new instance of the AuthenticationFilter class.
		/// </summary>
		/// <param name="endpoint"></param>
		public AuthenticationFilter(EndpointBase endpoint) {
			_endpoint = endpoint;
		}

		#region IFilter Members

		public override void Invoke(AMFContext context) {
			MessageBroker messageBroker = _endpoint.GetMessageBroker();
			try {
				AMFHeader amfHeader = context.AMFMessage.GetHeader(AMFHeader.CredentialsHeader);
				if (amfHeader != null && amfHeader.Content != null) {
					string userId = ((ASObject)amfHeader.Content)["userid"] as string;
					string password = ((ASObject)amfHeader.Content)["password"] as string;
					//Clear credentials header, further requests will not send the credentials
					ASObject asoObject = new ASObject();
					asoObject["name"] = AMFHeader.CredentialsHeader;
					asoObject["mustUnderstand"] = false;
					asoObject["data"] = null;//clear
					AMFHeader header = new AMFHeader(AMFHeader.RequestPersistentHeader, true, asoObject);
					context.MessageOutput.AddHeader(header);
					IPrincipal principal = _endpoint.GetMessageBroker().LoginManager.Login(userId, amfHeader.Content as IDictionary);
					string key = EncryptCredentials(_endpoint, principal, userId, password);
					ASObject asoObjectCredentialsId = new ASObject();
					asoObjectCredentialsId["name"] = AMFHeader.CredentialsIdHeader;
					asoObjectCredentialsId["mustUnderstand"] = false;
					asoObjectCredentialsId["data"] = key;//set
					AMFHeader headerCredentialsId = new AMFHeader(AMFHeader.RequestPersistentHeader, true, asoObjectCredentialsId);
					context.MessageOutput.AddHeader(headerCredentialsId);
				} else {
					amfHeader = context.AMFMessage.GetHeader(AMFHeader.CredentialsIdHeader);
					if (amfHeader != null) {
						string key = amfHeader.Content as string;
						if (key != null)
							_endpoint.GetMessageBroker().LoginManager.RestorePrincipal(key);
					} else {
						_endpoint.GetMessageBroker().LoginManager.RestorePrincipal();
					}
				}
			} catch (UnauthorizedAccessException exception) {
				for (int i = 0; i < context.AMFMessage.BodyCount; i++) {
					AMFBody amfBody = context.AMFMessage.GetBodyAt(i);
					ErrorResponseBody errorResponseBody = new ErrorResponseBody(amfBody, exception);
					context.MessageOutput.AddBody(errorResponseBody);
				}
			} catch (Exception exception) {
				if (log != null && log.IsErrorEnabled)
					log.Error(exception.Message, exception);
				for (int i = 0; i < context.AMFMessage.BodyCount; i++) {
					AMFBody amfBody = context.AMFMessage.GetBodyAt(i);
					ErrorResponseBody errorResponseBody = new ErrorResponseBody(amfBody, exception);
					context.MessageOutput.AddBody(errorResponseBody);
				}
			}
		}

		#endregion

		string EncryptCredentials(IEndpoint endpoint, IPrincipal principal, string userId, string password) {
			string uniqueKey = endpoint.Id;//HttpContext.Current.Session.SessionID;
			HttpCookie cookie = FormsAuthentication.GetAuthCookie("fluorine", false);
			FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);

			string cacheKey = string.Join("|", new string[] { GenericLoginCommand.FluorineTicket, uniqueKey, userId, password });
			// Store the Guid inside the Forms Ticket with all the attributes aligned with 
			// the config Forms section.
			FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, cacheKey, ticket.CookiePath);
			return FormsAuthentication.Encrypt(newTicket);
		}
	}
}
