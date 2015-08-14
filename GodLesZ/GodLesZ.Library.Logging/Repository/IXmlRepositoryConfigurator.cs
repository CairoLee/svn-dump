using System;
using System.Collections;
using GodLesZ.Library.Logging.Util;

namespace GodLesZ.Library.Logging.Repository {
	/// <summary>
	/// Configure repository using XML
	/// </summary>
	/// <remarks>
	/// <para>
	/// Interface used by Xml configurator to configure a <see cref="ILoggerRepository"/>.
	/// </para>
	/// <para>
	/// A <see cref="ILoggerRepository"/> should implement this interface to support
	/// configuration by the <see cref="GodLesZ.Library.Logging.Config.XmlConfigurator"/>.
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	/// <author>Gert Driesen</author>
	public interface IXmlRepositoryConfigurator {
		/// <summary>
		/// Initialize the repository using the specified config
		/// </summary>
		/// <param name="element">the element containing the root of the config</param>
		/// <remarks>
		/// <para>
		/// The schema for the XML configuration data is defined by
		/// the implementation.
		/// </para>
		/// </remarks>
		void Configure(System.Xml.XmlElement element);
	}
}
