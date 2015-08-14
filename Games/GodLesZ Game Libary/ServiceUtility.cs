using System;
using System.Collections.Generic;
using System.Text;

namespace GLibary {
	public partial class Utility {

		public static void RemoveService<TInterface>() {
			game.Services.RemoveService( typeof( TInterface ) );
		}

		public static void AddService<TInterface>( object obj ) {
			game.Services.AddService( typeof( TInterface ), obj );
		}

		public static TInterface GetService<TInterface>() {
			return (TInterface)game.Services.GetService( typeof( TInterface ) );
		}

		public static TRet GetService<TInterface, TRet>() {
			return (TRet)game.Services.GetService( typeof( TInterface ) );
		}

	}
}
