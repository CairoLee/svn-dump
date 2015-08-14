using System;

namespace GodLesZ.Library.ProcessEditAPI {

	public sealed partial class ProcessEdit {
#if FASM_MANAGED
		/// <summary>
		/// Injects a dll into a process by creating a remote thread on LoadLibrary.
		/// </summary>
		/// <param name="szDllPath">Full path of the dll that will be injected.</param>
		/// <returns>Returns the base address of the injected dll on success, zero on failure.</returns>
		public uint InjectDllCreateThread( string szDllPath ) {
			if( !mProcessOpen )
				return RETURN_ERROR;

			return InjectHelper.InjectDllCreateThread( mProcess, szDllPath );
		}

		/// <summary>
		/// Injects a dll into a process by hijacking the given thread and redirecting it to LoadLibrary.
		/// </summary>
		/// <param name="szDllPath">Full path of the dll that will be injected.</param>
		/// <returns>Returns the base address of the injected dll on success, zero on failure.</returns>
		public uint InjectDllRedirectThread( string szDllPath ) {
			if( !mProcessOpen )
				return RETURN_ERROR;

			if( mThreadOpen )
				return InjectHelper.InjectDllRedirectThread( mProcess, mThread, szDllPath );

			return InjectHelper.InjectDllRedirectThread( mProcess, mProcessId, szDllPath );
		}

		/// <summary>
		/// Injects a dll into a process by hijacking the given thread and redirecting it to LoadLibrary.
		/// </summary>
		/// <param name="hThread">Handle to the thread which will be hijacked.</param>
		/// <param name="szDllPath">Full path of the dll that will be injected.</param>
		/// <returns>Returns the base address of the injected dll on success, zero on failure.</returns>
		public uint InjectDllRedirectThread( IntPtr hThread, string szDllPath ) {
			if( !mProcessOpen )
				return RETURN_ERROR;

			return InjectHelper.InjectDllRedirectThread( mProcess, hThread, szDllPath );
		}
#endif
	}

}