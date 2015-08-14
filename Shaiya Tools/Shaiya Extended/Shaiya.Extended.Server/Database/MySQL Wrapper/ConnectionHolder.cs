using System;
using System.Collections.Generic;
using System.Text;

namespace Shaiya.Extended.Server.MySql {

	public class ConnectionHolder {
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

		public ConnectionHolder( string Name, string Host, int Port, string Username, string Password, string Database ) {
			this.Name = Name;
			this.Host = Host;
			this.Port = Port;
			this.Username = Username;
			this.Password = Password;
			this.Database = Database;
		}

		public ConnectionHolder( string Host, int Port, string Username, string Password, string Database ) {
			this.Name = string.Format( "{0} @ {1}", Username, Host );
			this.Host = Host;
			this.Port = Port;
			this.Username = Username;
			this.Password = Password;
			this.Database = Database;
		}

		public override string ToString() {
			return String.Format( "{0};{1};{2};{3};{4}", this.Host, this.Port, this.Username, this.Password, this.Database );
		}


		public bool CompareTo( ConnectionHolder Con ) {
			if( this.Name != Con.Name )
				return false;
			if( this.Host != Con.Host )
				return false;
			if( this.Port != Con.Port )
				return false;
			if( this.Username != Con.Username )
				return false;
			if( this.Password != Con.Password )
				return false;
			if( this.Database != Con.Database )
				return false;

			return true;
		}

	}

}
