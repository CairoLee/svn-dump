using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace GodLesZ.Library.ProcessEditAPI {

	/// <summary>
	/// Provides class instance methods for the manipulation of memory and general 'hacking' of another process.
	/// </summary>
	public sealed partial class ProcessEdit : IDisposable {
		private const uint RETURN_ERROR = 0;

		/// <summary>
		/// Gets or sets whether Debug privileges will be set when opening a process.
		/// </summary>
		public bool SetDebugPrivileges = true;

		private bool mProcessOpen = false;
		private bool mThreadOpen = false;
		private IntPtr mProcess = IntPtr.Zero;
		private int mProcessId = 0;
		private IntPtr mWnd = IntPtr.Zero;
		private int mThreadId = 0;
		private IntPtr mThread = IntPtr.Zero;
		private ProcessModule mMainModule;
		private ProcessModuleCollection mModules;

		/// <summary>
		/// Get whether a process is open for manipulation.
		/// </summary>
		public bool IsProcessOpen {
			get { return mProcessOpen; }
		}

		/// <summary>
		/// Gets whether a process is open for manipulation.
		/// </summary>
		public bool IsThreadOpen {
			get { return mThreadOpen; }
		}

		/// <summary>
		/// Gets the handle of the currently opened process.
		/// </summary>
		public IntPtr ProcessHandle {
			get { return mProcess; }
		}

		/// <summary>
		/// Gets the Id of the currently opened process.
		/// </summary>
		public int ProcessId {
			get { return mProcessId; }
		}

		/// <summary>
		/// Gets the handle of the main window of the currently opened process.
		/// </summary>
		public IntPtr WindowHandle {
			get { return mWnd; }
		}

		/// <summary>
		/// Gets the Id of the currently opened thread.
		/// </summary>
		public int ThreadId {
			get { return mThreadId; }
		}

		/// <summary>
		/// Gets the handle to the currently opened thread.
		/// </summary>
		public IntPtr ThreadHandle {
			get { return mThread; }
		}

		/// <summary>
		/// Gets the main module of the opened process.
		/// </summary>
		public ProcessModule MainModule {
			get { return mMainModule; }
		}

		/// <summary>
		/// Gets the collection of modules currently loaded in the target process.
		/// </summary>
		public ProcessModuleCollection Modules {
			get { return mModules; }
		}

#if FASM_MANAGED
		/// <summary>
		/// Assembles mnemonics into bytecode and allows for injection and execution.
		/// </summary>
		public FasmManaged.ManagedFasm Asm {
			get;
			set;
		}
#endif

		/// <summary>
		/// Allows interfacing with an external process (memory manipulation, thread manipulation, etc.)
		/// </summary>
		public ProcessEdit() {
			mData = new List<PatternDataEntry>();
#if FASM_MANAGED
			Asm = new FasmManaged.ManagedFasm();
			if (mProcessOpen && mProcess != IntPtr.Zero)
				Asm.SetProcessHandle(mProcess);
#endif
		}

		/// <summary>
		/// Allows interfacing with an external process (memory manipulation, thread manipulation, etc.)
		/// </summary>
		/// <param name="ProcessId">Process Id of process with which we wish to interact.</param>
		public ProcessEdit(int ProcessId)
			: this() {
			mProcessOpen = Open(ProcessId);
		}

		/// <summary>
		/// Allows interfacing with an external process (memory manipulation, thread manipulation, etc.)
		/// </summary>
		/// <param name="WindowHandle">Window handle of main window of process with which we wish to interact.</param>
		public ProcessEdit(IntPtr WindowHandle)
			: this(ProcessHelper.GetProcessFromWindow(WindowHandle)) { }


		/// <summary>
		/// Closes all handles.
		/// </summary>
		~ProcessEdit() {
			this.Dispose();
		}


		/// <summary>
		/// Closes all handles.
		/// </summary>
		public void Dispose() {
			this.Close();
		}


		/// <summary>
		/// Opens a process and its main thread for interaction.
		/// </summary>
		/// <param name="ProcessId">Process Id of process with which we wish to interact.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool Open(int ProcessId) {
			if (ProcessId == 0)
				return false;

			if (ProcessId == mProcessId)
				return true;

			if (mProcessOpen)
				this.CloseProcess();

			if (SetDebugPrivileges)
				System.Diagnostics.Process.EnterDebugMode();

			mProcessOpen = (mProcess = ProcessHelper.OpenProcess(ProcessId)) != IntPtr.Zero;
			if (mProcessOpen) {
				mProcessId = ProcessId;
				mWnd = WindowHelper.FindWindowByProcessId(ProcessId);

				mModules = Process.GetProcessById(mProcessId).Modules;
				mMainModule = mModules[0];
#if FASM_MANAGED
				if (Asm == null)
					Asm = new FasmManaged.ManagedFasm(mProcess);
				else
					Asm.SetProcessHandle(mProcess);
#endif
			}

			return mProcessOpen;
		}

		/// <summary>
		/// Opens a process for interaction.
		/// </summary>
		/// <param name="WindowHandle">Window handle of main window of process with which we wish to interact.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool Open(IntPtr WindowHandle) {
			if (WindowHandle == IntPtr.Zero)
				return false;

			return this.Open(ProcessHelper.GetProcessFromWindow(WindowHandle));
		}

		/// <summary>
		/// Opens the specified thread for manipulation.
		/// </summary>
		/// <param name="dwThreadId">ID of the thread to be opened.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool OpenThread(int dwThreadId) {
			if (dwThreadId == 0)
				return false;

			if (dwThreadId == mThreadId)
				return true;

			if (mThreadOpen)
				this.CloseThread();

			mThreadOpen = (mThread = ThreadHelper.OpenThread(dwThreadId)) != IntPtr.Zero;

			if (mThreadOpen)
				mThreadId = dwThreadId;

			return mThreadOpen;
		}

		/// <summary>
		/// Opens the main thread of the process already opened by this class object.
		/// </summary>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool OpenThread() {
			if (mProcessOpen)
				return this.OpenThread(ThreadHelper.GetMainThreadId(mProcessId));
			return false;
		}

		/// <summary>
		/// Opens a process and its main thread for manipulation.
		/// </summary>
		/// <param name="dwProcessId">Id of the target process.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool OpenProcessAndThread(int dwProcessId) {
			if (this.Open(dwProcessId) && this.OpenThread())
				return true;

			this.Close();
			return false;
		}

		/// <summary>
		/// Opens a process and its main thread for manipulation.
		/// </summary>
		/// <param name="WindowHandle">Handle to the main window of the target process.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool OpenProcessAndThread(IntPtr WindowHandle) {
			if (this.Open(WindowHandle) && this.OpenThread())
				return true;

			this.Close();
			return false;
		}

		/// <summary>
		/// Opens a process and its main thread for manipulation.
		/// </summary>
		/// <param name="ProcessName">Name of the executable to match.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool OpenProcessAndThread(string ProcessName) {
			int procId = ProcessHelper.GetProcessFromProcessName(ProcessName);
			if (this.Open(procId) && this.OpenThread())
				return true;

			this.Close();
			return false;
		}

		/// <summary>
		/// Closes process and thread handles of open process (or does nothing if neither is open).
		/// </summary>
		public void Close() {
#if FASM_MANAGED
			Asm.Dispose();
#endif

			this.CloseProcess();
			this.CloseThread();
		}

		/// <summary>
		/// Closes the handle to the open process (or does nothing if a process has not been opened).
		/// </summary>
		public void CloseProcess() {
			if (mProcess != IntPtr.Zero)
				Imports.CloseHandle(mProcess);

			mProcess = IntPtr.Zero;
			mWnd = IntPtr.Zero;
			mProcessId = 0;

			mMainModule = null;
			mModules = null;

			mProcessOpen = false;

#if FASM_MANAGED
			Asm.SetProcessHandle(IntPtr.Zero);
#endif
		}

		/// <summary>
		/// Closes the handle to the open thread (or does nothing if a thread has not been opened).
		/// </summary>
		public void CloseThread() {
			if (mThread != IntPtr.Zero)
				Imports.CloseHandle(mThread);

			mThread = IntPtr.Zero;
			mThreadId = 0;

			mThreadOpen = false;
		}



		/// <summary>
		/// Gets the full file path of the main module of the opened process.
		/// </summary>
		/// <returns>Returns a string representing the full file path of the main module of the opened process.</returns>
		public string GetModuleFilePath() {
			return mMainModule.FileName;
		}

		/// <summary>
		/// Gets the full file path of the specified module loaded by the opened process.
		/// </summary>
		/// <param name="index">Index of the module whose full file path is wanted.</param>
		/// <returns>Returns a string representing the full file path of the specified module loaded by the opened process.</returns>
		public string GetModuleFilePath(int index) {
			return mModules[index].FileName;
		}

		/// <summary>
		/// Gets the full file path of the specified module loaded by the opened process.
		/// </summary>
		/// <param name="sModuleName"></param>
		/// <returns></returns>
		public string GetModuleFilePath(string sModuleName) {
			foreach (ProcessModule pMod in mModules)
				if (pMod.ModuleName.ToLower().Equals(sModuleName.ToLower()))
					return pMod.FileName;

			return String.Empty;
		}

		/// <summary>
		/// Gets the module loaded by the opened process that matches the given string.
		/// </summary>
		/// <param name="sModuleName">String specifying which module to return.</param>
		/// <returns>Returns the module loaded by the opened process that matches the given string.</returns>
		public ProcessModule GetModule(string sModuleName) {
			foreach (ProcessModule pMod in mModules)
				if (pMod.ModuleName.ToLower().Equals(sModuleName.ToLower()))
					return pMod;

			return null;
		}

		/// <summary>
		/// Gets the module loaded by the opened process in which the given address resides.
		/// </summary>
		/// <param name="dwAddress">An address inside the process owned by the module that will be returned.</param>
		/// <returns>Returns null on failure, or the module that owns the given address on success.</returns>
		public ProcessModule GetModule(uint dwAddress) {
			foreach (ProcessModule pMod in mModules)
				if ((uint)pMod.BaseAddress <= dwAddress && ((uint)pMod.BaseAddress + pMod.ModuleMemorySize) >= dwAddress)
					return pMod;

			return null;
		}

	}

}
