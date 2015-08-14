using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using GodLesZ.Library.ProcessEditAPI.Inject.Native;

namespace GodLesZ.Library.ProcessEditAPI {

	public sealed partial class ProcessEdit {
		public const uint WM_KEYDOWN = 0x100;
		public const uint WM_KEYUP = 0x0101;

		public const int INPUT_MOUSE = 0;
		public const int INPUT_KEYBOARD = 1;
		public const int INPUT_HARDWARE = 2;
		public const uint KEYEVENTF_KEYDOWN = 0x0000;
		public const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
		public const uint KEYEVENTF_KEYUP = 0x0002;
		public const uint KEYEVENTF_UNICODE = 0x0004;
		public const uint KEYEVENTF_SCANCODE = 0x0008;
		public const uint XBUTTON1 = 0x0001;
		public const uint XBUTTON2 = 0x0002;
		public const uint MOUSEEVENTF_MOVE = 0x0001;
		public const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
		public const uint MOUSEEVENTF_LEFTUP = 0x0004;
		public const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
		public const uint MOUSEEVENTF_RIGHTUP = 0x0010;
		public const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
		public const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
		public const uint MOUSEEVENTF_XDOWN = 0x0080;
		public const uint MOUSEEVENTF_XUP = 0x0100;
		public const uint MOUSEEVENTF_WHEEL = 0x0800;
		public const uint MOUSEEVENTF_VIRTUALDESK = 0x4000;
		public const uint MOUSEEVENTF_ABSOLUTE = 0x8000;


		/// <summary>
		/// Sends WM_KEYDOWN | WM_KEYUP to WindowHandle using PostMessage
		/// </summary>
		/// <param name="key"></param>
		public void PostMessage(System.Windows.Forms.Keys key) {
			PostMessage(key, false);
		}

		/// <summary>
		/// Sends WM_KEYDOWN | WM_KEYUP to WindowHandle using PostMessage or keybd_event
		/// </summary>
		/// <param name="key"></param>
		public void PostMessage(System.Windows.Forms.Keys key, bool useKeybd) {
			int errNo = 0;
			if (!this.mProcessOpen || this.mProcess == IntPtr.Zero) {
				throw new Exception("Process is not open.");
			}

			uint KEYEVENTF_EXTENDEDKEY = 0x1;
			uint KEYEVENTF_KEYUP = 0x2;
			byte bScan = 0x45;

			if (useKeybd == false) {
				Win32.PostMessage(WindowHandle, WM_KEYDOWN | WM_KEYUP, (int)key, 0);
			} else {
				Win32.keybd_event((byte)key, (byte)bScan, (uint)KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
				Win32.keybd_event((byte)key, (byte)bScan, (uint)(KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP), (UIntPtr)0);
			}
			errNo = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
			if (errNo > 0) {
				throw new System.ComponentModel.Win32Exception(errNo);
			}

		}



		// Only for Foreground windows and maybe the only way for DX games...

		public void KeyPress(char ch, int waitDelay) {
			KeyDown(ch);
			System.Threading.Thread.Sleep(waitDelay);
			KeyUp(ch);
		}

		public void KeyPress(char ch) {
			KeyPress(ch, 100);
		}


		public void KeyDown(char ch) {
			short vk = Win32.VkKeyScan(ch);
			ushort scanCode = (ushort)Win32.MapVirtualKey((byte)vk, 0);

			INPUT[] inputs = new INPUT[1];
			inputs[0].type = INPUT_KEYBOARD;
			inputs[0].ki.wScan = scanCode;
			inputs[0].ki.dwFlags = KEYEVENTF_KEYDOWN;

			uint intReturn = Win32.SendInput(1, inputs, Marshal.SizeOf(inputs[0]));
			if (intReturn != 1) {
				throw new Exception("Could not send key: " + ch);
			}
		}

		public void KeyUp(char ch) {
			short vk = Win32.VkKeyScan(ch);
			ushort scanCode = (ushort)Win32.MapVirtualKey((byte)vk, 0);

			INPUT[] inputs = new INPUT[1];
			inputs[0].type = INPUT_KEYBOARD;
			inputs[0].ki.wScan = scanCode;
			inputs[0].ki.dwFlags = KEYEVENTF_KEYUP;
			uint intReturn = Win32.SendInput(1, inputs, Marshal.SizeOf(inputs[0]));
			if (intReturn != 1) {
				throw new Exception("Could not send key: " + ch);
			}
		}

	}

}
