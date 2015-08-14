using System.Web;


namespace GodLesZ.Library.Amf.Browser {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public interface IServiceBrowserRenderer {
		/// <summary>
		/// This method supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		/// <param name="httpRequest"></param>
		/// <returns></returns>
		bool CanRender(HttpRequest httpRequest);
		/// <summary>
		/// This method supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		/// <param name="httpApplication"></param>
		void Render(HttpApplication httpApplication);
	}
}
