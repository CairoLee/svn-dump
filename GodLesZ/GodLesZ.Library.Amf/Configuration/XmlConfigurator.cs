
using System;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
// Import log4net classes.
using log4net;

namespace GodLesZ.Library.Amf.Configuration {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	sealed class XmlConfigurator : IConfigurationSectionHandler {
		public XmlConfigurator() {
		}

		#region IConfigurationSectionHandler Members

		public object Create(object parent, object configContext, XmlNode section) {
			ILog _log = null;
			try {
				_log = LogManager.GetLogger(typeof(XmlConfigurator));
			} catch { }

			object settings = null;
			if (section == null)
				return settings;

			XmlSerializer xmlSerializer = new XmlSerializer(typeof(FluorineSettings));
			XmlNodeReader reader = new XmlNodeReader(section);
			try {
				settings = xmlSerializer.Deserialize(reader);
			} catch (Exception ex) {
				if (_log != null && _log.IsErrorEnabled)
					_log.Error(ex.Message, ex);
			} finally {
				xmlSerializer = null;
			}
			return settings;
		}

		#endregion
	}
}
