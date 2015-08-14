
namespace GodLesZ.Library.Logging.Repository {
	/// <summary>
	/// Basic Configurator interface for repositories
	/// </summary>
	/// <remarks>
	/// <para>
	/// Interface used by basic configurator to configure a <see cref="ILoggerRepository"/>
	/// with a default <see cref="GodLesZ.Library.Logging.Appender.IAppender"/>.
	/// </para>
	/// <para>
	/// A <see cref="ILoggerRepository"/> should implement this interface to support
	/// configuration by the <see cref="GodLesZ.Library.Logging.Config.BasicConfigurator"/>.
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	/// <author>Gert Driesen</author>
	public interface IBasicRepositoryConfigurator {
		/// <summary>
		/// Initialize the repository using the specified appender
		/// </summary>
		/// <param name="appender">the appender to use to log all logging events</param>
		/// <remarks>
		/// <para>
		/// Configure the repository to route all logging events to the
		/// specified appender.
		/// </para>
		/// </remarks>
		void Configure(Appender.IAppender appender);

		/// <summary>
		/// Initialize the repository using the specified appenders
		/// </summary>
		/// <param name="appenders">the appenders to use to log all logging events</param>
		/// <remarks>
		/// <para>
		/// Configure the repository to route all logging events to the
		/// specified appenders.
		/// </para>
		/// </remarks>
		void Configure(params Appender.IAppender[] appenders);
	}
}
