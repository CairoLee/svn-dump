using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GodLesZ.Library.ProcessEditAPI.Inject.Native;
using System.Runtime.InteropServices;

namespace GodLesZ.Library.ProcessEditAPI {

	public sealed partial class ProcessEdit {

		/// <summary>
		/// Sets the main window handle from the attached process to foreground
		/// </summary>
		/// <returns>0 if already focus, 1 if focus sucess and -1 if failed</returns>
		public int SetForegroundWindowInput() {
			return SetForegroundWindowInput(WindowHandle);
		}

		/// <summary>
		/// Sets the given window to foreground
		/// </summary>
		/// <param name="windowHandle"></param>
		/// <returns>0 if already focus, 1 if focus sucess and -1 if failed</returns>
		public int SetForegroundWindowInput(IntPtr windowHandle) {
			if (Win32.GetForegroundWindow() == windowHandle) {
				return 0;
			}

			IntPtr foregroundWindowHandle = Win32.GetForegroundWindow();
			uint threadId = Win32.GetCurrentThreadId();
			uint temp;
			uint foregroundThreadId = Win32.GetWindowThreadProcessId(foregroundWindowHandle, out temp);
			Win32.AttachThreadInput(threadId, foregroundThreadId, true);
			Win32.SetForegroundWindow(windowHandle);
			Win32.AttachThreadInput(threadId, foregroundThreadId, false);

			if (Win32.GetForegroundWindow() == windowHandle) {
				return 1;
			}
			return -1;
		}


		public void SetActiveWindow() {
			IntPtr i = Win32.SetActiveWindow(WindowHandle);
			int errNo = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
			if (errNo > 0) {
				throw new System.ComponentModel.Win32Exception(errNo);
			}
		}

		public void SetForegroundWindow() {
			IntPtr i = Win32.SetForegroundWindow(WindowHandle);
			int errNo = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
			if (errNo > 0) {
				throw new System.ComponentModel.Win32Exception(errNo);
			}
		}

	}

}
