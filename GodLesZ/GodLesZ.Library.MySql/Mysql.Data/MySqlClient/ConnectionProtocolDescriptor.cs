using System;
using System.ComponentModel;

namespace GodLesZ.Library.MySql.Data.MySqlClient {

	internal class ConnectionProtocolDescriptor : PropertyDescriptor {
		public ConnectionProtocolDescriptor(string name, Attribute[] attr)
			: base(name, attr) {
		}

		public override bool CanResetValue(object component) {
			return true;
		}

		public override object GetValue(object component) {
			MySqlConnectionStringBuilder builder = (MySqlConnectionStringBuilder)component;
			return builder.ConnectionProtocol;
		}

		public override void ResetValue(object component) {
			MySqlConnectionStringBuilder builder = (MySqlConnectionStringBuilder)component;
			builder.ConnectionProtocol = MySqlConnectionProtocol.Sockets;
		}

		public override void SetValue(object component, object value) {
			MySqlConnectionStringBuilder builder = (MySqlConnectionStringBuilder)component;
			builder.ConnectionProtocol = (MySqlConnectionProtocol)value;
		}

		public override bool ShouldSerializeValue(object component) {
			MySqlConnectionStringBuilder builder = (MySqlConnectionStringBuilder)component;
			return (builder.ConnectionProtocol != MySqlConnectionProtocol.Sockets);
		}

		public override Type ComponentType {
			get { return typeof(MySqlConnectionStringBuilder); }
		}

		public override bool IsReadOnly {
			get { return false; }
		}

		public override Type PropertyType {
			get { return typeof(MySqlConnectionProtocol); }
		}
	}
}

