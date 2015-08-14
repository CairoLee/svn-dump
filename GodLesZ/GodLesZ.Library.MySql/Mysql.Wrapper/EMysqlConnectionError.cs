using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.Library.MySql {

		public enum EMysqlConnectionError {
		/// <summary>
		/// No Error, all went fine
		/// </summary>
		None = 0,

		/***************
		 * Open() 
		 ***************/

		/// <summary>
		/// <see cref="mConnection"/> was not Instanced
		/// </summary>
		OpenBeforeInit,
		/// <summary>
		/// catched Exception, Invalid Connection Info or something else
		/// </summary>
		CanNotConnectToDB,
		/// <summary>
		/// No Exception, but cant open SQL Connection
		/// </summary>
		FailedToOpen,
		/// <summary>
		/// catched Exception, unkown thing while trying <see cref="Open"/>() Method
		/// </summary>
		UnknownOpen,



		/***************
		 * Close() 
		 ***************/

		/// <summary>
		/// <see cref="mConnection"/> was not Instanced
		/// </summary>
		CloseBeforeInit,
		/// <summary>
		/// catched Exception, unkown thing while trying <see cref="Close"/>() Method
		/// </summary>
		CanNotDisconnectFromDB,
		/// <summary>
		/// No Exception, but cant close SQL Connection
		/// </summary>
		FailedToClose,
		/// <summary>
		/// catched Exception, unkown thing while trying <see cref="Close"/>() Method
		/// </summary>
		UnknownClose,
	}

}
