using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.IO;

using Shaiya.Extended.Server.Properties;
using Shaiya.Extended.Server.Scripting;
using Shaiya.Extended.Server.Network;
using Shaiya.Extended.Server.MySql;
using Shaiya.Extended.Library.Network;
using Shaiya.Extended.Library.Utility;

namespace Shaiya.Extended.Server {

	public delegate void Slice();

	public class Core {
		private delegate bool ConsoleEventHandler( ConsoleEventType type );
		[DllImport( "Kernel32" )]
		private static extern bool SetConsoleCtrlHandler( ConsoleEventHandler callback, bool add );

		public static Slice Slice;

		private static bool mClosing = false;
		private static bool mCrashed = false;

		private static ApplicationSettings mAppConf;
		private static SocketConnector mSocketConnector;
		private static Thread mThread;
		private static Thread mTimerThread;
		private static Process mProcess;
		private static Assembly mAssembly;
		private static ConsoleEventHandler mConsoleEventHandler;
		private static AutoResetEvent mSignal = new AutoResetEvent( true );
		private static DateTime mProfileStart;
		private static TimeSpan mProfileTime;
		private static MySqlWrapper mDatabase;

		private static uint mCycleIndex;
		private static float[] mCyclesPerSecond = new float[ 100 ];

		public static float CyclesPerSecond {
			get { return mCyclesPerSecond[ ( (uint)( mCycleIndex - 1 ) ) % mCyclesPerSecond.Length ]; }
		}

		public static float AverageCPS {
			get {
				float t = 0.0f;
				int c = 0;

				for( int i = 0; i < mCycleIndex && i < mCyclesPerSecond.Length; ++i ) {
					t += mCyclesPerSecond[ i ];
					++c;
				}

				return ( t / Math.Max( c, 1 ) );
			}
		}

		public static bool Closing {
			get { return Core.mClosing; }
		}
		public static bool Crashed {
			get { return Core.mCrashed; }
		}
		public static bool Profiling {
			get { return BaseProfile.Profiling; }
			set {
				if( BaseProfile.Profiling == value )
					return;

				BaseProfile.Profiling = value;

				if( mProfileStart > DateTime.MinValue )
					mProfileTime += DateTime.Now - mProfileStart;

				mProfileStart = ( BaseProfile.Profiling ? DateTime.Now : DateTime.MinValue );
			}
		}
		public static TimeSpan ProfileTime {
			get {
				if( mProfileStart > DateTime.MinValue )
					return mProfileTime + ( DateTime.Now - mProfileStart );

				return mProfileTime;
			}
		}
		public static Thread Thread {
			get { return Core.mThread; }
		}
		public static Process Process {
			get { return Core.mProcess; }
		}
		public static Assembly Assembly {
			get { return Core.mAssembly; }
		}
		public static SocketConnector Connector {
			get { return mSocketConnector; }
		}
		public static ApplicationSettings Conf {
			get { return mAppConf; }
		}
		public static MySqlWrapper Database {
			get { return mDatabase; }
		}


		public static void Main( string[] args ) {
#if !DEBUG
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler( CurrentDomain_UnhandledException );
#endif
			AppDomain.CurrentDomain.ProcessExit += new EventHandler( CurrentDomain_ProcessExit );

			try {

				mThread = Thread.CurrentThread;
				mProcess = Process.GetCurrentProcess();
				mAssembly = Assembly.GetEntryAssembly();
				if( mThread != null )
					mThread.Name = "Core Thread";

				Timer.TimerThread ttObj = new Timer.TimerThread();
				mTimerThread = new Thread( new ThreadStart( ttObj.TimerMain ) );
				mTimerThread.Name = "Timer Thread";

				int width = Math.Min( 100, Console.LargestWindowWidth - 2 );
				Console.CursorVisible = false;
				Console.Clear();
				Console.WindowLeft = Console.WindowTop = 0;
				if( Console.WindowWidth < width )
					Console.WindowWidth = width;

				LogoPrinter.PrefixColor = EConsoleColor.Blue;
				LogoPrinter.SufixColor = EConsoleColor.Blue;
				LogoPrinter.TextColor = EConsoleColor.Gray;
				LogoPrinter.PrintLogo();
	
				Version ver = mAssembly.GetName().Version;
				CConsole.StatusLine( "Shaiya.Extended Server - Version {0}.{1}, Build {2}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision );

				mConsoleEventHandler = new ConsoleEventHandler( OnConsoleEvent );
				SetConsoleCtrlHandler( mConsoleEventHandler, true );

				mAppConf = new ApplicationSettings();
				mAppConf.ReadAll();

				Stopwatch watch = Stopwatch.StartNew();
				CConsole.Info( "Connecting to SQL Server {0}...", mAppConf.Network[ "DB Server" ] );
				mDatabase = new MySqlWrapper( mAppConf.Network[ "DB Server" ], int.Parse( mAppConf.Network[ "DB Port" ] ), mAppConf.Network[ "DB User" ], mAppConf.Network[ "DB Password" ], mAppConf.Network[ "DB Database" ] );
				MysqlError conRes = mDatabase.Prepare();
				if( conRes != MysqlError.None ) {
					CConsole.WriteLine( EConsoleColor.Error, " failed!" );
					throw new Exception( "Failed to open Database Connection! Type: " + conRes.ToString() );
				}
				watch.Stop();
				CConsole.WriteLine( EConsoleColor.Status, " done! Needed {0:F2} sec", watch.Elapsed.TotalSeconds );
				watch = null;

				ScriptDatabase.Initialize( @"Scripts\ScriptList.xml" );
				ScriptCompiler.Compile( AppDomain.CurrentDomain.BaseDirectory + Path.Combine( Settings.Default.MainConfDir, Settings.Default.ScriptAssemblies ), true, true );

				World.Load();

				// testing CallMethod
				ScriptCompiler.CallMethod( "Initialize" );

				SocketPool.Create();
				mSocketConnector = new SocketConnector( mAppConf.Network[ "Server IP" ], mAppConf.Network.GetInt( "Server Port" ) );
				PacketHandlers.Initialize();

				// start Timer Thread
				mTimerThread.Start();

				NetState.Initialize();

				// finished Loading
				Events.InvokeServerStarted();


				DateTime now, last = DateTime.Now;
				const int sampleInterval = 100;
				const float ticksPerSecond = (float)( TimeSpan.TicksPerSecond * sampleInterval );
				int sample = 0;

				while( mSignal.WaitOne() ) {
					Timer.Slice();
					mSocketConnector.Slice();

					NetState.FlushAll();
					NetState.ProcessDisposedQueue();

					if( Slice != null )
						Slice();

					// just for Diagnostics
					if( ( ++sample % sampleInterval ) == 0 ) {
						now = DateTime.Now;
						mCyclesPerSecond[ mCycleIndex++ % mCyclesPerSecond.Length ] = ticksPerSecond / ( now.Ticks - last.Ticks );
						last = now;
					}
				}
			} catch( Exception e ) {
				CurrentDomain_UnhandledException( null, new UnhandledExceptionEventArgs( e, true ) );
			}

		}




		private static void CurrentDomain_UnhandledException( object sender, UnhandledExceptionEventArgs e ) {
			Exception ex = e.ExceptionObject as Exception;
			CConsole.Write( EConsoleColor.Error, e.IsTerminating ? "Error: " : "Warning: " );
			CConsole.WriteLine( EConsoleColor.Error, ex.Message );
			if( ex.StackTrace != string.Empty )
				CConsole.WriteLine( ex.StackTrace );

			if( e.IsTerminating ) {
				mCrashed = true;
				bool close = false;
				try {
					CrashedEventArgs args = new CrashedEventArgs( e.ExceptionObject as Exception );
					Events.InvokeCrashed( args );
					close = args.Close;
				} catch {
				}

				if( !close ) {
					SocketPool.Destroy();

					CConsole.ErrorLine( "This exception is fatal, press return to exit" );
					CConsole.Read();
				}

				mClosing = true;
			}
		}

		private static void CurrentDomain_ProcessExit( object sender, EventArgs e ) {
			HandleClosed();
		}


		#region Kill Handler
		public static void Kill() {
			Kill( false );
		}

		public static void Kill( bool restart ) {
			HandleClosed();

			if( restart )
				Process.Start( mAssembly.Location );

			mProcess.Kill();
		}

		private static void HandleClosed() {
			if( mClosing )
				return;

			if( !mCrashed )
				Events.InvokeShutdown( new ShutdownEventArgs() );

			mClosing = true;
			CConsole.StatusLine( "Exiting..." );

			// do some kills
			SocketPool.Destroy();

			CConsole.StatusLine( "Exiting finished! Press any Key to close." );
		}
		#endregion

		#region ConsoleEvent
		private enum ConsoleEventType {
			CTRL_C_EVENT,
			CTRL_BREAK_EVENT,
			CTRL_CLOSE_EVENT,
			CTRL_LOGOFF_EVENT = 5,
			CTRL_SHUTDOWN_EVENT
		}

		private static bool OnConsoleEvent( ConsoleEventType type ) {
			if( type == ConsoleEventType.CTRL_LOGOFF_EVENT )
				return true;

			Kill();

			return true;
		}
		#endregion


		public static void Set() {
			mSignal.Set();
		}

	}



}
