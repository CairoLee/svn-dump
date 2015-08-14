using System;
using System.Text;
#if FASM_MANAGED
using FasmManaged;
#endif

namespace GodLesZ.Library.ProcessEditAPI {

	/// <summary>
	/// Includes static methods for injecting libraries into an external process.
	/// </summary>
	public static class InjectHelper {
		const uint RETURN_ERROR = 0;

		/// <summary>
		/// Injects a dll into a process by creating a remote thread on LoadLibrary.
		/// </summary>
		/// <param name="hProcess">Handle to the process into which dll will be injected.</param>
		/// <param name="szDllPath">Full path of the dll that will be injected.</param>
		/// <returns>Returns the base address of the injected dll on success, zero on failure.</returns>
		public static uint InjectDllCreateThread(IntPtr hProcess, string szDllPath) {
			if (hProcess == IntPtr.Zero)
				throw new ArgumentNullException("hProcess");

			if (szDllPath.Length == 0)
				throw new ArgumentNullException("szDllPath");

			if (!szDllPath.Contains("\\"))
				szDllPath = System.IO.Path.GetFullPath(szDllPath);

			if (!System.IO.File.Exists(szDllPath))
				throw new ArgumentException("DLL not found.", "szDllPath");

			uint dwBaseAddress = RETURN_ERROR;
			uint lpLoadLibrary;
			uint lpDll;
			IntPtr hThread;

			lpLoadLibrary = (uint)Imports.GetProcAddress(Imports.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
			if (lpLoadLibrary == 0)
				throw new Exception("Failed to get address of LoadLibraryA in kernel32.dll");

			lpDll = MemoryHelper.AllocateMemory(hProcess);
			if (lpDll == 0)
				throw new Exception("Failed to allocate Memory in the Process!");

			if (MemoryHelper.WriteASCIIString(hProcess, lpDll, szDllPath)) {
				hThread = ThreadHelper.CreateRemoteThread(hProcess, lpLoadLibrary, lpDll);

				if (ThreadHelper.WaitForSingleObject(hThread, 5000) == WaitValues.WAIT_OBJECT_0)
					dwBaseAddress = ThreadHelper.GetExitCodeThread(hThread);

				Imports.CloseHandle(hThread);
			}

			MemoryHelper.FreeMemory(hProcess, lpDll);

			return dwBaseAddress;
		}

#if FASM_MANAGED
		/// <summary>
		/// Injects a dll into a process by hijacking the given thread and redirecting it to LoadLibrary.
		/// </summary>
		/// <param name="hProcess">Handle to process into which dll will be injected.</param>
		/// <param name="hThread">Handle to thread that will be hijacked.</param>
		/// <param name="szDllPath">Full path to the dll to be injected.</param>
		/// <returns>Returns the base address of the injected dll on success, zero on failure.</returns>
		public static uint InjectDllRedirectThread(IntPtr hProcess, IntPtr hThread, string szDllPath) {
			const uint INITIAL_EXIT_CODE = 0xFFFFFFFF;

			if (hProcess == IntPtr.Zero)
				throw new ArgumentNullException("hProcess");

			if (hThread == IntPtr.Zero)
				throw new ArgumentNullException("hThread");

			if (szDllPath.Length == 0)
				throw new ArgumentNullException("szDllPath");

			if (!szDllPath.Contains("\\"))
				szDllPath = System.IO.Path.GetFullPath(szDllPath);

			if (!System.IO.File.Exists(szDllPath))
				throw new ArgumentException("DLL not found.", "szDllPath");

			uint dwBaseAddress = RETURN_ERROR;
			uint lpLoadLibrary, lpAsmStub;
			CONTEXT ctx;
			StringBuilder AssemblyStub = new StringBuilder();
			ManagedFasm fasm = new ManagedFasm(hProcess);

			lpLoadLibrary = (uint)Imports.GetProcAddress(Imports.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
			if (lpLoadLibrary == 0)
				throw new Exception("Failed to get address of LoadLibraryA in kernel32.dll");

			lpAsmStub = MemoryHelper.AllocateMemory(hProcess);
			if (lpAsmStub == 0)
				throw new Exception("Failed to allocate Memory in the Process!");

			if (ThreadHelper.SuspendThread(hThread) != uint.MaxValue) {
				ctx = ThreadHelper.GetThreadContext(hThread, CONTEXT_FLAGS.CONTEXT_CONTROL);
				if (ctx.Eip > 0) {
					try {
						//located at lpAsmStub+0, where we can monitor LoadLibrary's exit code.
						fasm.AddLine("lpExitCode dd 0x{0:X}", INITIAL_EXIT_CODE);

						//lpAsmStub+4, where the actual code part starts
						fasm.AddLine("push 0x{0:X}", ctx.Eip);
						fasm.AddLine("pushad");
						fasm.AddLine("push szDllPath");
						fasm.AddLine("call 0x{0:X}", lpLoadLibrary);
						fasm.AddLine("mov [lpExitCode], eax");
						fasm.AddLine("popad");
						fasm.AddLine("retn");

						//dll path
						fasm.AddLine("szDllPath db \'{0}\',0", szDllPath);

						fasm.Inject(lpAsmStub);
					} catch {
						MemoryHelper.FreeMemory(hProcess, lpAsmStub);
						ThreadHelper.ResumeThread(hThread);
						return RETURN_ERROR;
					}

					ctx.ContextFlags = CONTEXT_FLAGS.CONTEXT_CONTROL;
					ctx.Eip = lpAsmStub + 4; //skip over lpExitCode data

					if (ThreadHelper.SetThreadContext(hThread, ctx)) {
						if (ThreadHelper.ResumeThread(hThread) != uint.MaxValue) {
							for (int i = 0; i < 400; i++) {
								System.Threading.Thread.Sleep(5);
								if ((dwBaseAddress = MemoryHelper.ReadUInt(hProcess, lpAsmStub)) != INITIAL_EXIT_CODE)
									break;
							}
						}
					}
				}
			}

			if (fasm != null) {
				fasm.Dispose();
				fasm = null;
			}

			MemoryHelper.FreeMemory(hProcess, lpAsmStub);

			return dwBaseAddress;
		}

		/// <summary>
		/// Injects a dll into a process by hijacking the process' main thread and redirecting it to LoadLibrary.
		/// </summary>
		/// <param name="hProcess">Handle to the process into which dll will be injected.</param>
		/// <param name="dwProcessId">Id of the process into which dll will be injected.</param>
		/// <param name="szDllPath">Full path to the dll to be injected.</param>
		/// <returns>Returns the base address of the injected dll on success, zero on failure.</returns>
		public static uint InjectDllRedirectThread(IntPtr hProcess, int dwProcessId, string szDllPath) {
			IntPtr hThread;
			uint dwBaseAddress;

			hThread = ThreadHelper.OpenThread(ThreadHelper.GetMainThreadId(dwProcessId));
			if (hThread == IntPtr.Zero)
				throw new Exception("Failed to open the Mainthread from desired ProcessID!!");

			dwBaseAddress = InjectDllRedirectThread(hProcess, hThread, szDllPath);

			Imports.CloseHandle(hThread);

			return dwBaseAddress;
		}

		/// <summary>
		/// Assembles mnemonics and injects resulting bytecode into given process.
		/// </summary>
		/// <param name="hProcess">Handle to the process into which code will be injected.</param>
		/// <param name="dwAddress">Address at which code will be injected.</param>
		/// <param name="szAssembly">Assembly mnemonics to be assembled and injected.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public static bool InjectCode( IntPtr hProcess, uint dwAddress, string szAssembly ) {
			byte[] bBytecode;

			if( hProcess == IntPtr.Zero || szAssembly.Length == 0 || dwAddress == 0 )
				return false;

			try {
				bBytecode = ManagedFasm.Assemble( szAssembly );
#if DEBUG
			} catch( Exception ex ) {
				Console.WriteLine( ex.Message );
#else
			} catch {
#endif
				return false;
			}

			return MemoryHelper.WriteBytes( hProcess, dwAddress, bBytecode, bBytecode.Length );
		}

		/// <summary>
		/// Assembles mnemonics and injects resulting bytecode into given process.
		/// </summary>
		/// <param name="hProcess">Handle to the process into which code will be injected.</param>
		/// <param name="dwAddress">Address at which code will be injected.</param>
		/// <param name="szFormat">Format string containing assembly mnemonics.</param>
		/// <param name="args">Arguments to be inserted in the format string.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public static bool InjectCode(IntPtr hProcess, uint dwAddress, string szFormat, params object[] args) {
			return InjectCode(hProcess, dwAddress, String.Format(szFormat, args));
		}

		/// <summary>
		/// Assembles mnemonics and injects resulting bytecode into given process.
		/// </summary>
		/// <param name="hProcess">Handle to the process into which code will be injected.</param>
		/// <param name="szAssembly">Assembly mnemonics to be assembled and injected.</param>
		/// <returns>Returns zero on failure, otherwise a chunk of memory that has been allocated in the target process where code was injected.</returns>
		/// <remarks>Don't forget to free the memory allocated for the code when you are finished.</remarks>
		public static uint InjectCode(IntPtr hProcess, string szAssembly) {
			uint dwAddress = MemoryHelper.AllocateMemory(hProcess);
			return (InjectCode(hProcess, dwAddress, szAssembly)) ? dwAddress : RETURN_ERROR;
		}

		/// <summary>
		/// Assembles mnemonics and injects resulting bytecode into given process.
		/// </summary>
		/// <param name="hProcess">Handle to the process into which code will be injected.</param>
		/// <param name="szFormatString">Format string containing assembly mnemonics.</param>
		/// <param name="args">Arguments to be inserted in the format string.</param>
		/// <returns>Returns zero on failure, otherwise a chunk of memory that has been allocated in the target process where code was injected.</returns>
		/// <remarks>Don't forget to free the memory allocated for the code when you are finished.</remarks>
		public static uint InjectCode(IntPtr hProcess, string szFormatString, params object[] args) {
			return InjectCode(hProcess, String.Format(szFormatString, args));
		}
#endif
	}

}