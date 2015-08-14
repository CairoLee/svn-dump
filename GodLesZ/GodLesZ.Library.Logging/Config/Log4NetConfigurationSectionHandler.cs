// .NET Compact Framework 1.0 has no support for application .config files
#if !NETCF

using System.Configuration;
using System.Xml;

namespace GodLesZ.Library.Logging.Config {
	/// <summary>
	/// Class to register for the GodLesZ.Library.Logging section of the configuration file
	/// </summary>
	/// <remarks>
	/// The GodLesZ.Library.Logging section of the configuration file needs to have a section
	/// handler registered. This is the section handler used. It simply returns
	/// the XML element that is the root of the section.
	/// </remarks>
	/// <example>
	/// Example of registering the GodLesZ.Library.Logging section handler :
	/// <code lang="XML" escaped="true">
	/// <configuration>
	///		<configSections>
	///			<section name="GodLesZ.Library.Logging" type="GodLesZ.Library.Logging.Config.Log4NetConfigurationSectionHandler, GodLesZ.Library.Logging" />
	///		</configSections>
	///		<GodLesZ.Library.Logging>
	///			GodLesZ.Library.Logging configuration XML goes here
	///		</GodLesZ.Library.Logging>
	/// </configuration>
	/// </code>
	/// </example>
	/// <author>Nicko Cadell</author>
	/// <author>Gert Driesen</author>
	public class Log4NetConfigurationSectionHandler : IConfigurationSectionHandler {
		#region Public Instance Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="Log4NetConfigurationSectionHandler"/> class.
		/// </summary>
		/// <remarks>
		/// <para>
		/// Default constructor.
		/// </para>
		/// </remarks>
		public Log4NetConfigurationSectionHandler() {
		}

		#endregion Public Instance Constructors

		#region Implementation of IConfigurationSectionHandler

		/// <summary>
		/// Parses the configuration section.
		/// </summary>
		/// <param name="parent">The configuration settings in a corresponding parent configuration section.</param>
		/// <param name="configContext">The configuration context when called from the ASP.NET configuration system. Otherwise, this parameter is reserved and is a null reference.</param>
		/// <param name="section">The <see cref="XmlNode" /> for the GodLesZ.Library.Logging section.</param>
		/// <returns>The <see cref="XmlNode" /> for the GodLesZ.Library.Logging section.</returns>
		/// <remarks>
		/// <para>
		/// Returns the <see cref="XmlNode"/> containing the configuration data,
		/// </para>
		/// </remarks>
		public object Create(object parent, object configContext, XmlNode section) {
			return section;
		}

		#endregion Implementation of IConfigurationSectionHandler
	}
}

#endif // !NETCF