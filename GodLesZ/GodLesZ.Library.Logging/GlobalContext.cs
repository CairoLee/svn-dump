using System;
using System.Collections;

using GodLesZ.Library.Logging.Util;

namespace GodLesZ.Library.Logging {
	/// <summary>
	/// The GodLesZ.Library.Logging Global Context.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>GlobalContext</c> provides a location for global debugging 
	/// information to be stored.
	/// </para>
	/// <para>
	/// The global context has a properties map and these properties can 
	/// be included in the output of log messages. The <see cref="GodLesZ.Library.Logging.Layout.PatternLayout"/>
	/// supports selecting and outputing these properties.
	/// </para>
	/// <para>
	/// By default the <c>GodLesZ.Library.Logging:HostName</c> property is set to the name of 
	/// the current machine.
	/// </para>
	/// </remarks>
	/// <example>
	/// <code lang="C#">
	/// GlobalContext.Properties["hostname"] = Environment.MachineName;
	/// </code>
	/// </example>
	/// <threadsafety static="true" instance="true" />
	/// <author>Nicko Cadell</author>
	public sealed class GlobalContext {
		#region Private Instance Constructors

		/// <summary>
		/// Private Constructor. 
		/// </summary>
		/// <remarks>
		/// Uses a private access modifier to prevent instantiation of this class.
		/// </remarks>
		private GlobalContext() {
		}

		#endregion Private Instance Constructors

		static GlobalContext() {
			Properties[GodLesZ.Library.Logging.Core.LoggingEvent.HostNameProperty] = SystemInfo.HostName;
		}

		#region Public Static Properties

		/// <summary>
		/// The global properties map.
		/// </summary>
		/// <value>
		/// The global properties map.
		/// </value>
		/// <remarks>
		/// <para>
		/// The global properties map.
		/// </para>
		/// </remarks>
		public static GlobalContextProperties Properties {
			get { return s_properties; }
		}

		#endregion Public Static Properties

		#region Private Static Fields

		/// <summary>
		/// The global context properties instance
		/// </summary>
		private readonly static GlobalContextProperties s_properties = new GlobalContextProperties();

		#endregion Private Static Fields
	}
}
