//#define REAL_FULLSCREEN

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using GodLesZ.Library;
using Rovolution.Server.Database;
using Rovolution.Server.Diagnostics;
using Rovolution.Server.Network;
using Rovolution.Server.Properties;
using Rovolution.Server.Scripting;

namespace Rovolution.Server {

	public delegate void Slice();

	public class Core {
		private delegate bool ConsoleEventHandler(ConsoleEventType type);
		[DllImport("kernel32.dll")]
		private static extern bool SetConsoleCtrlHandler(ConsoleEventHandler callback, bool add);
#if REAL_FULLSCREEN
		[DllImport("kernel32.dll")]
		private static extern IntPtr GetStdHandle(int handle);
		[DllImport("kernel32.dll")]
		private static extern bool SetConsoleDisplayMode(IntPtr hConsole, int mode);
#endif
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
		private static readonly AutoResetEvent mSignal = new AutoResetEvent(true);
		private static DateTime mProfileStart;
		private static TimeSpan mProfileTime;
		private static RovolutionDatabase mDatabase;

		private static uint mCycleIndex;
		private static float[] mCyclesPerSecond = new float[100];

		public static float CyclesPerSecond {
			get { return mCyclesPerSecond[((uint)(mCycleIndex - 1)) % mCyclesPerSecond.Length]; }
		}

		public static float AverageCps {
			get {
				float t = 0.0f;
				int c = 0;

				for (int i = 0; i < mCycleIndex && i < mCyclesPerSecond.Length; ++i) {
					t += mCyclesPerSecond[i];
					++c;
				}

				return (t / Math.Max(c, 1));
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
				if (BaseProfile.Profiling == value)
					return;

				BaseProfile.Profiling = value;

				if (mProfileStart > DateTime.MinValue)
					mProfileTime += DateTime.Now - mProfileStart;

				mProfileStart = (BaseProfile.Profiling ? DateTime.Now : DateTime.MinValue);
			}
		}
		public static TimeSpan ProfileTime {
			get {
				if (mProfileStart > DateTime.MinValue)
					return mProfileTime + (DateTime.Now - mProfileStart);

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
		public static RovolutionDatabase Database {
			get { return mDatabase; }
		}


		public static void Main(string[] args) {
			// If we set the exceptionhandler also in debug, VS wont throw them and i cant react in Debug-mode
			// They will be printed to the console interface 
#if !DEBUG
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler( CurrentDomain_UnhandledException );
#endif
			AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
#if !DEBUG
			try {
#endif

			// Cleanup before loading any other data
			GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);

			// Save some infos about our thread and assembly
			mThread = Thread.CurrentThread;
			mProcess = Process.GetCurrentProcess();
			mAssembly = Assembly.GetEntryAssembly();
			if (mThread != null) {
				// We set a name on our core thread
				mThread.Name = "Core Thread";
			}

			// Initialize our timer manager
			TimerThread ttObj = new TimerThread();
			mTimerThread = new Thread(new ThreadStart(ttObj.TimerMain));
			mTimerThread.Name = "Timer Thread";

			// Prepare console for a large output
			int width = Math.Min(100, Console.LargestWindowWidth - 2);
			Console.CursorVisible = false;
			Console.Clear();
			Console.WindowLeft = Console.WindowTop = 0;
			if (Console.WindowWidth < width) {
				Console.WindowWidth = width;
			}
		
			// Real fullscreen mode *_*
#if REAL_FULLSCREEN
			IntPtr hConsole = GetStdHandle(-11);
			SetConsoleDisplayMode(hConsole, 0);
#endif

			// Set colors for the logo printer
			LogoPrinter.PrefixColor = EConsoleColor.Blue;
			LogoPrinter.SufixColor = EConsoleColor.Blue;
			LogoPrinter.TextColor = EConsoleColor.Gray;
			LogoPrinter.CopyrightColor = EConsoleColor.Status;
			LogoPrinter.PrintLogo();

			// Output some infos about version and that
			Version ver = mAssembly.GetName().Version;
			ServerConsole.StatusLine("Rovolution Server - Version {0}.{1}.{2}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision);

			// Set error and exception handler (dll import)
			mConsoleEventHandler = new ConsoleEventHandler(OnConsoleEvent);
			SetConsoleCtrlHandler(mConsoleEventHandler, true);

			// Read server config
			mAppConf = new ApplicationSettings();
			mAppConf.ReadAll();

			// Mysql init
			Stopwatch watch = Stopwatch.StartNew();
			ServerConsole.Info("Connecting to SQL Server {0}...", mAppConf.Connection["DB Server"]);
			mDatabase = new RovolutionDatabase(Conf.Connection["DB Server"], int.Parse(Conf.Connection["DB Port"]), Conf.Connection["DB User"], Conf.Connection["DB Password"], Conf.Connection["DB Database"]);
			GodLesZ.Library.MySql.EMysqlConnectionError conRes = mDatabase.Prepare();
			if (conRes != GodLesZ.Library.MySql.EMysqlConnectionError.None) {
				ServerConsole.WriteLine(EConsoleColor.Error, " failed!");
				throw new Exception("Failed to open Database Connection! Type: " + conRes.ToString() + Environment.NewLine + (mDatabase.LastError != null ? ", Message: " + mDatabase.LastError.Message : ""));
			}
			watch.Stop();
			ServerConsole.WriteLine(EConsoleColor.Status, " done! Needed {0:F2} sec", watch.Elapsed.TotalSeconds);
			watch = null;

			// Load scripts (including events & that)
			ScriptDatabase.Initialize(@"Scripts\ScriptList.xml");

			ScriptCompiler.Compile(AppDomain.CurrentDomain.BaseDirectory + Path.Combine(Settings.Default.MainConfDir, Settings.Default.ScriptAssemblies), true, true);
			// Load assemblies for debug
			// TODO: we should load the assemblies for debugging
			//		 so VS could hijack them and we could debug them at runtime
			//		 also need the *.pdb files for this..

			// Packets handler
			PacketLoader.Initialize();

			// Initialize World events
			ScriptCompiler.Initialize("Rovolution.Server.Scripts");

			// Now we are able load our ressources
			World.Load();

			// Content init done, load Socket pool
			SocketPool.Create();
			mSocketConnector = new SocketConnector(mAppConf.Connection["Server IP"], mAppConf.Connection.GetInt("Server Port"));
			PacketHandlers.Initialize();

			// Start Timer Thread
			mTimerThread.Start();

			// Start timer for checking connections
			NetState.Initialize();


			// Initialize & load finished
			// Clean 
			GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);


			// Trigger ServerStarted event
			Events.InvokeServerStarted();


			DateTime now, last = DateTime.Now;
			const int sampleInterval = 100;
			const float ticksPerSecond = (float)(TimeSpan.TicksPerSecond * sampleInterval);
			int sample = 0;

			// The server loop
			// - looks for new sockets and process all packets
			while (mSignal.WaitOne()) {
				// Refresh timer
				Timer.Slice();

				// Kick out old connections
				NetState.FlushAll();
				NetState.ProcessDisposedQueue();
				// Catch new connections
				mSocketConnector.Slice();

				if (Slice != null)
					Slice();

				// just for Diagnostics
				if ((++sample % sampleInterval) == 0) {
					now = DateTime.Now;
					mCyclesPerSecond[mCycleIndex++ % mCyclesPerSecond.Length] = ticksPerSecond / (now.Ticks - last.Ticks);
					last = now;
				}
			}
#if !DEBUG
			} catch (Exception e) {
				CurrentDomain_UnhandledException(null, new UnhandledExceptionEventArgs(e, true));
			}
#endif
		}




		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
			var ex = e.ExceptionObject as Exception;
			ServerConsole.Write(EConsoleColor.Error, e.IsTerminating ? "Error: " : "Warning: ");
			ServerConsole.WriteLine(EConsoleColor.Error, Tools.CleanExcepionStacktrace(ex.Message));
			if (ex.StackTrace != string.Empty)
				ServerConsole.WriteLine(ex.StackTrace);

			if (e.IsTerminating == false) {
				return;
			}

			mCrashed = true;
			var close = false;
			try {
				var args = new CrashedEventArgs(e.ExceptionObject as Exception);
				Events.InvokeCrashed(args);
				close = args.Close;
			} catch (Exception) {
			}

			if (!close) {
				SocketPool.Destroy();

				ServerConsole.ErrorLine("This exception is fatal, press return to exit");
				ServerConsole.Read();
			}

			mClosing = true;
		}

		private static void CurrentDomain_ProcessExit(object sender, EventArgs e) {
			HandleClosed();
		}


		#region Kill Handler
		public static void Kill() {
			Kill(false);
		}

		public static void Kill(bool restart) {
			HandleClosed();

			if (restart)
				Process.Start(mAssembly.Location);

			mProcess.Kill();
		}

		private static void HandleClosed() {
			if (mClosing)
				return;

			if (!mCrashed)
				Events.InvokeShutdown(new ShutdownEventArgs());

			mClosing = true;
			ServerConsole.StatusLine("Exiting...");

			// do some kills
			SocketPool.Destroy();
			World.Destroy();

			ServerConsole.StatusLine("Exiting finished! Press any Key to close.");
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

		private static bool OnConsoleEvent(ConsoleEventType type) {
			if (type == ConsoleEventType.CTRL_LOGOFF_EVENT)
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
