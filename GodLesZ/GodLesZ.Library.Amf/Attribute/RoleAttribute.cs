using System;

namespace GodLesZ.Library.Amf {
	/// <summary>
	/// Indicates a declarative security check on a service method.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class RoleAttribute : System.Attribute {
		string _roles;

		/// <summary>
		/// Initializes a new instance of the RoleAttribute class.
		/// </summary>
		/// <param name="roles">Comma-separated list of roles.</param>
		[Obsolete("It is recommended to define security constraints in the security section of the services configuration file.")]
		public RoleAttribute(string roles) {
			_roles = roles;
		}
		/// <summary>
		/// Gets the comma-separated list of roles.
		/// </summary>
		public string Roles {
			get { return _roles; }
		}
	}
}
