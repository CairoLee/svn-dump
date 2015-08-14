using System;
using System.Collections.Generic;
using System.Text;

namespace GodLesZ.Library.MySql {

	public class ConnectionHolder : IComparable<ConnectionHolder> {
		public string Name {
			get;
			set;
		}
		public string Host {
			get;
			set;
		}
		public int Port {
			get;
			set;
		}
		public string Username {
			get;
			set;
		}
		public string Password {
			get;
			set;
		}
		public string Database {
			get;
			set;
		}


		public ConnectionHolder() {
		}

		public ConnectionHolder(string name, string host, int port, string username, string password, string database) {
			Name = name;
			Host = host;
			Port = port;
			Username = username;
			Password = password;
			Database = database;
		}

		public ConnectionHolder(string Host, int Port, string Username, string Password, string Database)
			: this(string.Format("{0} @ {1}", Username, Host), Host, Port, Username, Password, Database) {
		}


		public override string ToString() {
			return String.Format("{0};{1};{2};{3};{4}", Host, Port, Username, Password, Database);
		}

		public int CompareTo(ConnectionHolder Con) {
			if (Name != Con.Name) {
				return 0;
			} else if (Host != Con.Host) {
				return 0;
			} else if (Port != Con.Port) {
				return 0;
			} else if (Username != Con.Username) {
				return 0;
			} else if (Password != Con.Password) {
				return 0;
			} else if (Database != Con.Database) {
				return 0;
			}

			return 1;
		}


		int IComparable<ConnectionHolder>.CompareTo(ConnectionHolder other) {
			return this.CompareTo(other);
		}

	}

}
