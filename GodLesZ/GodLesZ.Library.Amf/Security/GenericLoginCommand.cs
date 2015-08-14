
using System.Collections;
using System.Security.Principal;

namespace GodLesZ.Library.Amf.Security {
	/// <summary>
	/// Custom login adapter base class.
	/// </summary>
	public class GenericLoginCommand : ILoginCommand {
		/// <summary>
		/// This member supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		public static string FluorineTicket = "fluorineauthticket";

		/// <summary>
		/// Initializes a new instance of the GenericLoginCommand class.
		/// </summary>
		public GenericLoginCommand() {
		}

		#region ILoginCommand Members

		/// <summary>
		/// Called to initialize a login command prior to authentication/authorization requests.
		/// </summary>
		public virtual void Start() {
			//NA
		}
		/// <summary>
		/// Called to free up resources used by the login command.
		/// </summary>
		public virtual void Stop() {
			//NA
		}
		/// <summary>
		/// Attempts to log a user out from their session.
		/// </summary>
		/// <param name="principal">The principal to logout.</param>
		/// <returns>A Boolean value indicating whether the principal has been logged out.</returns>
		public virtual bool Logout(IPrincipal principal) {
			//if (FluorineContext.Current != null)
			//    FluorineContext.Current.ClearPrincipal();
			return true;
		}
		/// <summary>
		/// The gateway calls this method to perform programmatic authorization.
		/// </summary>
		/// <param name="principal">The principal being checked for authorization.</param>
		/// <param name="roles">A List of role names to check, all members should be strings.</param>
		/// <returns>A Boolean value indicating whether the principal has been authorized.</returns>
		public virtual bool DoAuthorization(IPrincipal principal, IList roles) {
			if (roles.Count == 0) {
				//No roles were defined we should check only if the Principal is authenticated
				if (principal.Identity != null)
					return principal.Identity.IsAuthenticated;
			}
			foreach (string role in roles) {
				if (principal.IsInRole(role))
					return true;
			}
			return false;
		}
		/// <summary>
		/// The gateway calls this method to perform programmatic, custom authentication.
		/// </summary>
		/// <param name="username">The principal being authenticated.</param>
		/// <param name="credentials">The credentials are passed as a Hashtable to allow for extra properties to be passed in the future. For now, only a "password" property is sent.</param>
		/// <returns>A principal object represents the security context of the user.</returns>
		public virtual IPrincipal DoAuthentication(string username, IDictionary credentials) {
			GenericIdentity identity = new GenericIdentity(username);
			GenericPrincipal principal = new GenericPrincipal(identity, new string[] { });
			return principal;
		}

		#endregion
	}
}
