using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

using ProcessEditAPI;
using ProcessEditAPI.Inject;

namespace MemoryBot {

	public class InjectTest {
		[UnmanagedFunctionPointer( CallingConvention.Winapi )]
		public delegate int EndSceneDelegate( IntPtr instance );


		private static readonly EndSceneDelegate EndSceneHandler = EndScene;
		private static ProcessInject mInject;

		private static int EndScene( IntPtr instance ) {
			return (int)mInject.Detours[ "EndScene" ].CallOriginal( instance );
		}

		public static void Inject() {
			int procId = ProcessHelper.GetProcessFromProcessName( "game" );
			ProcessEdit proc = new ProcessEdit( procId );
			if( proc.IsProcessOpen == false ) {
				Console.WriteLine( "failed to open Shaiya Process" );
				Console.Read();
				return;
			}

			byte[] pat1 = new byte[] { 0x8B, 0xCB, 0x8B, 0xD1, 0xC1, 0xE9, 0x02, 0x8D, 0x43, 0x02, 0x66, 0x89, 0x44, 0x24, 0x20 };
			byte[] pat2 = new byte[] { 0xB8, 0x8C, 0x60, 0x00, 0x00, 0xE8 };
			byte[] pat3 = new byte[] { 0x8B, 0x54, 0x24, 0x04, 0x0F, 0xB7, 0xC2, 0x3D };
			uint Address = proc.FindPattern( pat1, "xxxxxxxxxxxxxxx" ) - 0x38;
			uint ReturnAddress = Address + 6;
			uint Address2 = proc.FindPattern( pat2, "xxxxxx" );
			uint ReturnAddress2 = Address2 + 5;
			uint Address3 = proc.FindPattern( pat3, "xxxxxxxx" );

			Console.WriteLine( "Address: " + Address + " / " + Address.ToString( "X8" ) );
			Console.WriteLine( "ReturnAddress: " + ReturnAddress + " / " + ReturnAddress.ToString( "X8" ) );
			Console.WriteLine( "Address2: " + Address2 + " / " + Address2.ToString( "X8" ) );
			Console.WriteLine( "ReturnAddress2: " + ReturnAddress2 + " / " + ReturnAddress2.ToString( "X8" ) );
			Console.WriteLine( "Address3: " + Address3 + " / " + Address3.ToString( "X8" ) );

			proc.Dispose();

			mInject = new ProcessInject( Address, procId );
			//mInject.WriteBytes( Address2, new byte[] { 0xE9 } ); // *(BYTE *)(Address2) = 0xE9;

			IntPtr endSceneAddr = mInject.GetObjectVtableFunction( mInject.Read<IntPtr>( Address ), 0 );
			mInject.Detours.CreateAndApply( mInject.RegisterDelegate<EndSceneDelegate>( endSceneAddr ), EndSceneHandler, "EndScene" );


			Console.WriteLine( "alle done, moep o.o" );
			Console.ReadKey();
		}

	}

}
