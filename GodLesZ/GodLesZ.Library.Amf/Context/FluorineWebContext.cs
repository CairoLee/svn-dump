using System.Collections;
using System.Web;

namespace GodLesZ.Library.Amf.Context {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	sealed class FluorineWebContext : FluorineContext {
		private FluorineWebContext() {
		}

		internal static void Initialize() {
			HttpContext.Current.Items[FluorineContext.FluorineContextKey] = new FluorineWebContext();
		}
		/// <summary>
		/// Gets a key-value collection that can be used to organize and share data between an IHttpModule and an IHttpHandler during an HTTP request.
		/// </summary>
		public IDictionary Items {
			get { return HttpContext.Current.Items; }
		}
		/// <summary>
		/// Gets the physical drive path of the application directory for the application hosted in the current application domain.
		/// </summary>
		public override string RootPath {
			get {
				return HttpRuntime.AppDomainAppPath;
			}
		}

		/// <summary>
		/// Gets the virtual path of the current request.
		/// </summary>
		public override string RequestPath {
			get { return HttpContext.Current.Request.Path; }
		}
		/// <summary>
		/// Gets the ASP.NET application's virtual application root path on the server.
		/// </summary>
		public override string RequestApplicationPath {
			get { return HttpContext.Current.Request.ApplicationPath; }
		}

		public override string PhysicalApplicationPath {
			get {
				return HttpContext.Current.Request.PhysicalApplicationPath;
			}
		}

		public override string ApplicationPath {
			get {
				string applicationPath = "";
				//if (httpApplication.Request.Url != null)
				// Nick Farina: We need to cast to object first because the mono framework doesn't 
				// have the Uri.operator!=() method that the MS compiler adds. 
				if ((object)HttpContext.Current.Request.Url != null)
					applicationPath = HttpContext.Current.Request.Url.AbsoluteUri.Substring(
						0, HttpContext.Current.Request.Url.AbsoluteUri.ToLower().IndexOf(
						HttpContext.Current.Request.ApplicationPath.ToLower(),
						HttpContext.Current.Request.Url.AbsoluteUri.ToLower().IndexOf(
						HttpContext.Current.Request.Url.Authority.ToLower()) +
						HttpContext.Current.Request.Url.Authority.Length) +
						HttpContext.Current.Request.ApplicationPath.Length);
				return applicationPath;
			}
		}
		/// <summary>
		/// Gets the absolute URI from the URL of the current request.
		/// </summary>
		public override string AbsoluteUri {
			get { return HttpContext.Current.Request.Url.AbsoluteUri; }
		}

		public override string ActivationMode {
			get {
				//if( Environment.UserInteractive )
				//	return null;
				try {
					if (HttpContext.Current != null)
						return HttpContext.Current.Request.QueryString["activate"] as string;
				} catch (HttpException)//Request is not available in this context
				{
				}
				return null;
			}
		}

		/*
		public static string GetFormsAuthCookieName()
		{
			string formsCookieName = Environment.UserInteractive ? ".ASPXAUTH" : FormsAuthentication.FormsCookieName;
			return formsCookieName;
		}
		*/
	}
}
