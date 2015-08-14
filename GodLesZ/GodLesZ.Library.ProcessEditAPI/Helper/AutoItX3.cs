using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace GodLesZ.Library.ProcessEditAPI {

	public class AutoItX3 {

		#region | Public Methods |

		public static void Initialize() {
			AU3_Init();
		}


		public static int AutoitError() {
			return AU3_error();
		}

		/// <summary>
		/// Sends a mouse click command to a given control.
		/// </summary>
		/// <param name="vsTitle">The title of the window to access.</param>
		/// <param name="vsText">The text of the window to access.</param>
		/// <param name="vsControl">The control to interact with. See Controls.</param>
		/// <param name="vsButton">[optional] The button to click, "left", "right", "middle", "main", "menu", "primary", "secondary". Default is the left button.</param>
		/// <param name="viNumClicks">[optional] The number of times to click the mouse. Default is 1.</param>
		/// <param name="viX">[optional] The x position to click within the control. Default is center.</param>
		/// <param name="viY">[optional] The y position to click within the control. Default is center.</param>
		public static void ControlClick(string vsTitle, string vsText, string vsControl, string vsButton, int viNumClicks, int viX, int viY) {
			AU3_ControlClick(vsTitle, vsText, vsControl, vsButton, viNumClicks, viX, viY);
		}

		/// <summary>
		/// Sends a mouse click command to a given control.
		/// </summary>
		/// <param name="vsTitle">The title of the window to access.</param>
		/// <param name="vsControl">The control to interact with. See Controls.</param>
		public static void ControlClick(string vsTitle, string vsControl) {
			AU3_ControlClick(vsTitle, "", vsControl, "", 1, 0, 0);
		}

		/// <summary>
		/// Retrieves the internal handle of a control.
		/// </summary>
		/// <param name="vsTitle">The title of the window to access.</param>
		/// <param name="vsText">The text of the window to access.</param>
		/// <param name="vsControl">The control to interact with. See Controls.</param>
		public static string ControlGetHandle(string vsTitle, string vsText, string vsControl) {
			//----------------------------------------------------------------------
			// A number big enought to hold result, trailing bytes will be 0
			//----------------------------------------------------------------------
			byte[] RetText = new byte[50];

			AU3_ControlGetHandle(vsTitle, vsText, vsControl, RetText, RetText.Length);

			//----------------------------------------------------------------------
			// May need to convert back to a string or int
			//----------------------------------------------------------------------
			return Encoding.ASCII.GetString(RetText).TrimEnd('\0');
		}

		/// <summary>
		/// Sends a string of characters to a control
		/// </summary>
		/// <param name="vsTitle">The title of the window to access.</param>
		/// <param name="vsText">The text of the window to access.</param>
		/// <param name="vsControl">The control to interact with. See Controls.</param>
		/// <param name="vsSendText">String of characters to send to the control.</param>
		/// <param name="viMode">
		/// [optional] Changes how "keys" is processed:
		/// flag = 0 (default), Text contains special characters like + to indicate 
		///     SHIFT and {LEFT} to indicate left arrow.
		/// flag = 1, keys are sent raw.
		/// </param>
		/// <returns></returns>
		public static int ControlSend(string vsTitle, string vsText, string vsControl, string vsSendText, int viMode) {
			return AU3_ControlSend(vsTitle, vsText, vsControl, vsSendText, viMode);
		}

		/// <summary>
		/// Sets input focus to a given control on a window.
		/// </summary>
		/// <param name="vsTitle">The title of the window to access.</param>
		/// <param name="vsText">The text of the window to access.</param>
		/// <param name="vsControl">The control to interact with. See Controls.</param>
		public static void ControlFocus(string vsTitle, string vsText, string vsControl) {
			AU3_ControlFocus(vsTitle, vsText, vsControl);
		}

		/// <summary>
		/// Sets input focus to a given control on a window.
		/// </summary>
		/// <param name="vsTitle">The title of the window to access.</param>
		/// <param name="vsControl">The control to interact with. See Controls.</param>
		public static void ControlFocus(string vsTitle, string vsControl) {
			AU3_ControlFocus(vsTitle, "", vsControl);
		}

		/// <summary>
		/// Perform a mouse click operation.
		/// </summary>
		/// <param name="vsButton">The button to click: "left", "right", "middle", "main", "menu", "primary", "secondary".</param>
		/// <param name="viX">[optional] The x/y coordinates to move the mouse to. If no x and y coords are given, the current position is used (default).</param>
		/// <param name="viY">[optional] The x/y coordinates to move the mouse to. If no x and y coords are given, the current position is used (default).</param>
		public static void MouseClick(string vsButton, int viX, int viY) {
			MouseClick(vsButton, viX, viY, 1, 1);
		}

		/// <summary>
		/// Perform a mouse click operation.
		/// </summary>
		/// <param name="vsButton">The button to click: "left", "right", "middle", "main", "menu", "primary", "secondary".</param>
		public static void MouseClick(string vsButton) {
			int mousex = AU3_MouseGetPosX();
			int mousey = AU3_MouseGetPosY();
			MouseClick(vsButton, mousex, mousey);
		}

		/// <summary>
		/// Perform a mouse click operation.
		/// </summary>
		/// <param name="vsButton">The button to click: "left", "right", "middle", "main", "menu", "primary", "secondary".</param>
		/// <param name="viX">[optional] The x/y coordinates to move the mouse to. If no x and y coords are given, the current position is used (default).</param>
		/// <param name="viY">[optional] The x/y coordinates to move the mouse to. If no x and y coords are given, the current position is used (default).</param>
		/// <param name="viClicks">[optional] The number of times to click the mouse. Default is 1.</param>
		/// <param name="viSpeed">[optional] the speed to move the mouse in the range 1 (fastest) to 100 (slowest). A speed of 0 will move the mouse instantly. Default speed is 10.</param>
		public static void MouseClick(string vsButton, int viX, int viY, int viClicks, int viSpeed) {
			//----------------------------------------------------------------------
			// MouseClick wasn't working with out first MouseMove call
			//----------------------------------------------------------------------
			AU3_MouseMove(viX, viY, 10);
			AU3_MouseClick(vsButton, viX, viY, viClicks, viSpeed);
		}

		/// <summary>
		/// Perform a mouse down event at the current mouse position.
		/// </summary>
		/// <param name="vsButton">The button to click: "left", "right", "middle", "main", "menu", "primary", "secondary".</param>
		public static void MouseDown(string vsButton) {
			AU3_MouseDown(vsButton);
		}

		/// <summary>
		/// Retrieves the current position of the mouse cursor.
		/// </summary>
		/// <returns></returns>
		public static int[] MouseGetPos() {
			return new[] { AU3_MouseGetPosX(), AU3_MouseGetPosY() };
		}

		/// <summary>
		/// Retrieves the current X position of the mouse cursor.
		/// </summary>
		/// <returns></returns>
		public static int MouseGetPosX() {
			return AU3_MouseGetPosX();
		}

		/// <summary>
		/// Retrieves the current Y position of the mouse cursor.
		/// </summary>
		/// <returns></returns>
		public static int MouseGetPosY() {
			return AU3_MouseGetPosY();
		}

		/// <summary>
		/// Moves the mouse pointer.
		/// </summary>
		/// <param name="viX">The screen x coordinate to move the mouse to.</param>
		/// <param name="viY">The screen y coordinate to move the mouse to.</param>
		public static void MouseMove(int viX, int viY) {
			MouseMove(viX, viY, 1);
		}

		/// <summary>
		/// Moves the mouse pointer.
		/// </summary>
		/// <param name="viX">The screen x coordinate to move the mouse to.</param>
		/// <param name="viY">The screen y coordinate to move the mouse to.</param>
		/// <param name="viSpeed">[optional] the speed to move the mouse in the range 1 (fastest) to 100 (slowest). A speed of 0 will move the mouse instantly. Default speed is 10.</param>
		public static void MouseMove(int viX, int viY, int viSpeed) {
			AU3_MouseMove(viX, viY, viSpeed);
		}

		/// <summary>
		/// Perform a mouse up event at the current mouse position.
		/// </summary>
		/// <param name="vsButton">The button to click: "left", "right", "middle", "main", "menu", "primary", "secondary".</param>
		public static void MouseUp(string vsButton) {
			AU3_MouseUp(vsButton);
		}

		/// <summary>
		/// Generates a checksum for a region of pixels.
		/// </summary>
		/// <param name="left">left coordinate of rectangle.</param>
		/// <param name="top">top coordinate of rectangle.</param>
		/// <param name="right">right coordinate of rectangle.</param>
		/// <param name="bottom">bottom coordinate of rectangle.</param>
		/// <param name="step">[optional] Instead of checksumming each pixel use a value larger than 1 to skip pixels (for speed). E.g. A value of 2 will only check every other pixel. Default is 1. It is not recommended to use a step value greater than 1.</param>
		/// <returns>Returns the checksum value of the region.</returns>
		public static int PixelChecksum(int left, int top, int right, int bottom, int step) {
			//object sum = AU3_PixelChecksum(left, top, right, bottom, step);
			//return Convert.ToUInt32(sum);

			int sum = 0;
			for (int viX = left; viX <= right; viX += step) {
				for (int viY = top; viY <= bottom; viY += step) {
					sum += AU3_PixelGetColor(viX, viY);
				}
			}
			return sum;
		}

		/// <summary>
		/// Generates a checksum for a region of pixels.
		/// </summary>
		/// <param name="left">left coordinate of rectangle.</param>
		/// <param name="top">top coordinate of rectangle.</param>
		/// <param name="right">right coordinate of rectangle.</param>
		/// <param name="bottom">bottom coordinate of rectangle.</param>
		/// <returns>Returns the checksum value of the region.</returns>
		public static int PixelChecksum(int left, int top, int right, int bottom) {
			return PixelChecksum(left, top, right, bottom, 10);
		}

		/// <summary>
		/// Returns a pixel color according to x,y pixel coordinates.
		/// </summary>
		/// <param name="viX">x coordinate of pixel.</param>
		/// <param name="viY">y coordinate of pixel.</param>
		/// <returns></returns>
		public static int PixelGetColor(int viX, int viY) {
			return AU3_PixelGetColor(viX, viY);
		}

		/// <summary>
		/// Searches a rectangle of pixels for the pixel color provided. ( NOT IMPLIMENTED )
		/// </summary>
		/// <param name="left">left coordinate of rectangle.</param>
		/// <param name="top">top coordinate of rectangle.</param>
		/// <param name="right">right coordinate of rectangle.</param>
		/// <param name="bottom">bottom coordinate of rectangle.</param>
		/// <param name="color">Color value of pixel to find (in decimal or hex).</param>
		/// <param name="shade">[optional] A number between 0 and 255 to indicate the allowed number of shades of variation of the red, green, and blue components of the colour. Default is 0 (exact match).</param>
		/// <param name="step">[optional] Instead of searching each pixel use a value larger than 1 to skip pixels (for speed). E.g. A value of 2 will only check every other pixel. Default is 1.</param>
		/// <returns>
		/// an array [0]=x [1]=y if the pixel is found. returns null otherwise
		/// </returns>
		public static int[] PixelSearch(int left, int top, int right, int bottom, int color, int shade, int step) {
			//object coord = AU3_PixelSearch(left, top, right, bottom, color, shade, step);

			////Here we check to see if it found the pixel or not. It always returns a 1 in C# if it did not.
			//if (coord.ToString() != "1")
			//{
			//    //We have to turn "object coord" into a useable array since it contains the coordinates we need.
			//    object[] pixelCoord = (object[])coord;

			//    //Now we cast the object array to integers so that we can use the data inside.
			//    return new int[] { (int)pixelCoord[0], (int)pixelCoord[1] };
			//}
			return null;
		}

		/// <summary>
		/// Terminates a named process.
		/// </summary>
		/// <param name="process">The title or PID of the process to terminate.</param>
		public static void ProcessClose(string process) {
			AU3_ProcessClose(process);
		}

		/// <summary>
		/// Checks to see if a specified process exists.
		/// </summary>
		/// <param name="process">The name or PID of the process to check. </param>
		/// <returns>true if it exist, false otherwise</returns>
		public static bool ProcessExist(string process) {
			return AU3_ProcessExists(process) != 0;
		}

		/// <summary>
		/// Pauses script execution until a given process exists.
		/// </summary>
		/// <param name="process">The name of the process to check.</param>
		/// <param name="timeout">[optional] Specifies how long to wait (in seconds). Default is to wait indefinitely.</param>
		public static void ProcessWait(string process, int timeout) {
			AU3_ProcessWait(process, timeout);
		}

		/// <summary>
		/// Pauses script execution until a given process does not exist.
		/// </summary>
		/// <param name="process">The name or PID of the process to check.</param>
		/// <param name="timeout">[optional] Specifies how long to wait (in seconds). Default is to wait indefinitely.</param>
		public static void ProcessWaitClose(string process, int timeout) {
			AU3_ProcessWaitClose(process, timeout);
		}

		/// <summary>
		/// Runs an external program.
		/// </summary>
		/// <param name="process">The name of the executable (EXE, BAT, COM, or PIF) to run.</param>
		public static void Run(string process) {
			Run(process, "");
		}

		/// <summary>
		/// Runs an external program.
		/// </summary>
		/// <param name="process">The name of the executable (EXE, BAT, COM, or PIF) to run.</param>
		/// <param name="dir">[optional] The working directory.</param>
		public static void Run(string process, string dir) {
			Run(process, dir, SW_SHOWMAXIMIZED);
		}

		/// <summary>
		/// Runs an external program.
		/// </summary>
		/// <param name="process">The name of the executable (EXE, BAT, COM, or PIF) to run.</param>
		/// <param name="dir">[optional] The working directory.</param>
		/// <param name="showflag">
		///   [optional] The "show" flag of the executed program:
		///   @SW_HIDE = Hidden window (or Default keyword)
		///   @SW_MINIMIZE = Minimized window
		///   @SW_MAXIMIZE = Maximized window
		/// </param> 
		public static void Run(string process, string dir, int showflag) {
			AU3_Run(process, dir, showflag);
		}

		/// <summary>
		/// Sends simulated keystrokes to the active window.
		/// </summary>
		/// <param name="text">The sequence of keys to send.</param>
		public static void Send(string text) {
			Send(text, 5);
		}

		/// <summary>
		/// Sends simulated keystrokes to the active window.
		/// </summary>
		/// <param name="text">The sequence of keys to send.</param>
		/// <param name="viSpeed">
		/// Alters the the length of the brief pause in between sent keystrokes.
		///   Time in milliseconds to pause (default=5). Sometimes a value of 0 does 
		///   not work; use 1 instead.
		/// </param>
		public static void Send(string text, int viSpeed) {
			Send(text, viSpeed, 5);
		}

		/// <summary>
		/// Sends simulated keystrokes to the active window.
		/// </summary>
		/// <param name="text">The sequence of keys to send.</param>
		/// <param name="viSpeed">
		/// Alters the the length of the brief pause in between sent keystrokes.
		///   Time in milliseconds to pause (default=5). Sometimes a value of 0 does 
		///   not work; use 1 instead.
		/// </param>
		/// <param name="downLen">
		/// Alters the length of time a key is held down before being released during a keystroke. 
		///   For applications that take a while to register keypresses (and many games) you may need 
		///   to raise this value from the default.
		///   Time in milliseconds to pause (default=5).
		/// </param>
		public static void Send(string text, int viSpeed, int downLen) {
			SetOptions("AuXWrapper.SendKeyDelay", viSpeed);
			SetOptions("AuXWrapper.SendKeyDownDelay", downLen);
			Send(0, text);
		}

		/// <summary>
		/// Sends simulated keystrokes to the active window.
		/// </summary>
		/// <param name="viMode">[optional] Changes how "keys" is processed:
		///   flag = 0 (default), Text contains special characters like + and ! to indicate SHIFT and ALT key-presses.
		///   flag = 1, keys are sent raw. 
		/// </param>
		/// <param name="vsText">The sequence of keys to send.</param>
		public static void Send(int viMode, string vsText) {
			AU3_Send(vsText, viMode);
		}

		/// <summary>
		/// Sends simulated keystrokes to the active window.
		/// </summary>
		/// <param name="vsTitle">The s window title.</param>
		/// <param name="vsControl">The s control.</param>
		/// <param name="vsText">The s text.</param>
		public static void Send(string vsTitle, string vsControl, string vsText) {
			//----------------------------------------------------------------------
			// Set control focus and then send text to that control
			//----------------------------------------------------------------------
			ControlFocus(vsTitle, vsControl);
			Send(vsText);
		}

		/// <summary>
		/// Set recommended default AutoIt functions/parameters
		/// </summary>
		public static void SetOptions() {
			SetOptions(true, 250);
		}

		/// <summary>
		/// Changes the operation of various AutoIt functions/parameters.
		/// </summary>
		/// <param name="sOption">The option to change. See Remarks.</param>
		/// <param name="iValue">
		/// [optional] The value to assign to the option. The type and meaning 
		///   vary by option. The keyword Default can be used for the parameter 
		///   to reset the option to its default value.
		/// </param>
		public static void SetOptions(string sOption, int iValue) {
			AU3_AutoItSetOption(sOption, iValue);
		}

		/// <summary>
		/// Set recommended default AutoIt functions/parameters
		/// </summary>
		public static void SetOptions(bool vbWindowTitleExactMatch, int viSendKeyDelay) {
			//----------------------------------------------------------------------
			// WinTitleMatchMode 
			// Alters the method that is used to match window titles during search operations.
			// 1 = Match the title from the start (default)
			// 2 = Match any substring in the title
			// 3 = Exact title match
			// 4 = Advanced mode, see Window Titles & Text (Advanced)
			// -1 to -4 = force lower case match according to other type of match. 
			//----------------------------------------------------------------------
			if (vbWindowTitleExactMatch) {
				//----------------------------------------------------------------------
				// Match exact title when looking for windows
				//----------------------------------------------------------------------
				SetOptions("WinTitleMatchMode", 1);
			} else {
				//----------------------------------------------------------------------
				// Match any substring in the title when looking for windows
				//----------------------------------------------------------------------
				SetOptions("WinTitleMatchMode", 2);
			}

			//----------------------------------------------------------------------
			// SendKeyDelay 
			// Alters the the length of the brief pause in between sent keystrokes.
			// Time in milliseconds to pause (default=5). Sometimes a value of 0 
			//   does not work; use 1 instead. 
			//----------------------------------------------------------------------
			SetOptions("SendKeyDelay", viSendKeyDelay);

			//----------------------------------------------------------------------
			// WinWaitDelay
			// Alters how long a script should briefly pause after a successful 
			//   window-related operation. Time in milliseconds to pause (default=250).
			//----------------------------------------------------------------------
			SetOptions("WinWaitDelay", 250);

			//----------------------------------------------------------------------
			// WinDetectHiddenText 
			// Specifies if hidden window text can be "seen" by the window matching functions.
			// 0 = Do not detect hidden text (default)
			// 1 = Detect hidden text 
			//----------------------------------------------------------------------
			SetOptions("WinDetectHiddenText", 1);

			//----------------------------------------------------------------------
			// CaretCoordMode 
			// Sets the way coords are used in the caret functions, either absolute 
			//  coords or coords relative to the current active window:
			// 0 = relative coords to the active window
			// 1 = absolute screen coordinates (default)
			// 2 = relative coords to the client area of the active window 
			//----------------------------------------------------------------------
			SetOptions("CaretCoordMode", 2);

			//----------------------------------------------------------------------
			// PixelCoordMode 
			// Sets the way coords are used in the pixel functions, either absolute 
			// coords or coords relative to the window defined by hwnd (default active window):
			// 0 = relative coords to the defined window
			// 1 = absolute screen coordinates (default)
			// 2 = relative coords to the client area of the defined window 
			//----------------------------------------------------------------------
			SetOptions("PixelCoordMode", 2);

			//----------------------------------------------------------------------
			// MouseCoordMode 
			// Sets the way coords are used in the mouse functions, either absolute 
			//   coords or coords relative to the current active window:
			// 0 = relative coords to the active window
			// 1 = absolute screen coordinates (default)
			// 2 = relative coords to the client area of the active window 
			//----------------------------------------------------------------------
			SetOptions("MouseCoordMode", 2);
		}

		/// <summary>
		/// Pause script execution.
		/// </summary>
		/// <param name="iMilliseconds">Amount of time to pause (in milliseconds).</param>
		public static void Sleep(int iMilliseconds) {
			AU3_Sleep(iMilliseconds);
		}

		/// <summary>
		/// Creates a tooltip anywhere on the screen.
		/// </summary>
		/// <param name="sTip">The text of the tooltip. (An empty string clears a displaying tooltip)</param>
		/// <param name="viX">[optional] The x,y position of the tooltip.</param>
		/// <param name="viY">[optional] The x,y position of the tooltip.</param>
		public static void ToolTip(string sTip, int viX, int viY) {
			AU3_ToolTip(sTip, viX, viY);
		}

		/// <summary>
		/// Creates a padded tooltip in the top-left part of the screen.
		/// </summary>
		/// <param name="sMessage">The text of the tooltip. (An empty string clears a displaying tooltip)</param>
		public static void ToolTip(string sMessage) {
			//----------------------------------------------------------------------
			// Pad the message being displayed
			//----------------------------------------------------------------------
			if (!string.IsNullOrEmpty(sMessage)) {
				sMessage = string.Format("\r\n      {0}      \r\n  ", sMessage);
			}

			//----------------------------------------------------------------------
			// Set the tooltip to display the message
			//----------------------------------------------------------------------
			ToolTip(sMessage, 0, 0);
		}

		/// <summary>
		/// Activate a window
		/// </summary>
		/// <param name="vsTitle">the complete title of the window to activate, case sensitive</param>
		public static void WinActivate(string vsTitle) {
			AU3_WinActivate(vsTitle, "");
		}

		/// <summary>
		/// Activates (gives focus to) a window. ( incorporates WinWaitActive )
		/// </summary>
		/// <param name="vsTitle">The title of the window to activate.</param>
		/// <param name="waitactivetimeout">[optional] Timeout in seconds</param>
		public static void WinActivate(string vsTitle, int waitactivetimeout) {
			AU3_WinActivate(vsTitle, "");
			AU3_WinWaitActive(vsTitle, "", waitactivetimeout);
			System.Threading.Thread.Sleep(1000);
		}

		/// <summary>
		/// Activates (gives focus to) a window.
		/// </summary>
		/// <param name="vsTitle">The title of the window to activate.</param>
		/// <param name="vsText">[optional] The text of the window to activate.</param>
		public static void WinActivate(string vsTitle, string vsText) {
			AU3_WinActivate(vsTitle, vsText);
		}

		/// <summary>
		/// Checks to see if a specified window exists.
		/// </summary>
		/// <param name="vsTitle">The title of the window to check.</param>
		/// <returns>
		/// Success: Returns 1 if the window exists. 
		/// Failure: Returns 0 otherwise.
		/// </returns>
		public static int WinExists(string vsTitle) {
			return AU3_WinExists(vsTitle, "");
		}

		/// <summary>
		/// Checks to see if a specified window exists.
		/// </summary>
		/// <param name="vsTitle">The title of the window to check.</param>
		/// <param name="vsText">[optional] The text of the window to check.</param>
		/// <returns>
		/// Success: Returns 1 if the window exists. 
		/// Failure: Returns 0 otherwise.
		/// </returns>
		public static int WinExists(string vsTitle, string vsText) {
			return AU3_WinExists(vsTitle, vsText);
		}

		/// <summary>
		/// Retrieves the internal handle of a window.
		/// </summary>
		/// <param name="vsTitle">The title of the window to read.</param>
		/// <returns></returns>
		public static string WinGetHandle(string vsTitle) {
			//----------------------------------------------------------------------
			// A number big enought to hold result, trailing bytes will be 0
			//----------------------------------------------------------------------
			byte[] RetText = new byte[50];

			AU3_WinGetHandle(vsTitle, "", RetText, RetText.Length);

			//----------------------------------------------------------------------
			// May need to convert back to a string or int
			//----------------------------------------------------------------------
			return Encoding.ASCII.GetString(RetText).TrimEnd('\0');
		}

		/// <summary>
		/// Retrieves the text from a window.
		/// </summary>
		/// <param name="vsTitle">The title of the window to read.</param>
		/// <param name="vsText">[optional] The text of the window to read.</param>
		/// <returns></returns>
		public static string WinGetText(string vsTitle, string vsText) {
			//----------------------------------------------------------------------
			// A number big enought to hold result, trailing bytes will be 0
			//----------------------------------------------------------------------
			byte[] byteRetText = new byte[10000];

			AU3_WinGetText(vsTitle, vsText, byteRetText, byteRetText.Length);

			//----------------------------------------------------------------------
			// May need to convert back to a string or int
			//----------------------------------------------------------------------
			return Encoding.ASCII.GetString(byteRetText).TrimEnd('\0');
		}

		/// <summary>
		/// Retrieves the text from a window.
		/// </summary>
		/// <param name="vsTitle">The title of the window to read.</param>
		/// <returns></returns>
		public static string WinGetText(string vsTitle) {
			return WinGetText(vsTitle, "");
		}

		/// <summary>
		/// Moves and/or resizes a window.
		/// </summary>
		/// <param name="vsTitle">The title of the window to move/resize.</param>
		/// <param name="viX">X coordinate to move to.</param>
		/// <param name="viY">Y coordinate to move to.</param>
		public static void WinMove(string vsTitle, int viX, int viY) {
			int xLen = AU3_WinGetPosWidth(vsTitle, "");
			int yLen = AU3_WinGetPosHeight(vsTitle, "");
			WinMove(vsTitle, viX, viY, xLen, yLen);
		}

		/// <summary>
		/// Moves and/or resizes a window.
		/// </summary>
		/// <param name="vsTitle">The title of the window to move/resize.</param>
		/// <param name="viX">X coordinate to move to.</param>
		/// <param name="viY">Y coordinate to move to.</param>
		/// <param name="viWidth">[optional] New width of the window.</param>
		/// <param name="viHeight">[optional] New height of the window.</param>
		public static void WinMove(string vsTitle, int viX, int viY, int viWidth, int viHeight) {
			AU3_WinMove(vsTitle, "", viX, viY, viWidth, viHeight);
		}

		/// <summary>
		/// Pauses execution of the script until the requested window exists, 
		///   activates it and then waits again until it is active.
		/// </summary>
		/// <param name="vsTitle">The title of the window to check.</param>
		public static void WinWaitActiveWindow(string vsTitle) {
			//----------------------------------------------------------------------
			// Wait for the window
			//----------------------------------------------------------------------
			WinWait(vsTitle);

			//----------------------------------------------------------------------
			// Set the window as the active window
			//----------------------------------------------------------------------
			WinActivate(vsTitle);

			//----------------------------------------------------------------------
			// Wait until the window is active, then proceed
			//----------------------------------------------------------------------
			WinWaitActive(vsTitle);
		}

		/// <summary>
		/// Pauses execution of the script until the requested window exists.
		/// </summary>
		/// <param name="vsTitle">The title of the window to check.</param>
		/// <returns></returns>
		public static int WinWait(string vsTitle) {
			return AU3_WinWait(vsTitle, "", 3000);
		}

		/// <summary>
		/// Pauses execution of the script until the requested window is active.
		/// </summary>
		/// <param name="vsTitle">The title of the window to check.</param>
		/// <param name="vsText">[optional] The text of the window to check.</param>
		/// <param name="iTimeout">[optional] Timeout in seconds</param>
		/// <returns>
		/// Success: Returns 1. 
		/// Failure: Returns 0 if timeout occurred.
		/// </returns>
		public static int WinWaitActive(string vsTitle, string vsText, int iTimeout) {
			return AU3_WinWaitActive(vsTitle, vsText, iTimeout);
		}

		/// <summary>
		/// Pauses execution of the script until the requested window is active.
		/// </summary>
		/// <param name="vsTitle">The title of the window to check.</param>
		/// <param name="iTimeout">[optional] Timeout in seconds</param>
		/// <returns>
		/// Success: Returns 1. 
		/// Failure: Returns 0 if timeout occurred.
		/// </returns>
		public static int WinWaitActive(string vsTitle, int iTimeout) {
			return AU3_WinWaitActive(vsTitle, "", iTimeout);
		}

		/// <summary>
		/// Pauses execution of the script until the requested window is active.
		/// </summary>
		/// <param name="vsTitle">The title of the window to check.</param>
		/// <returns>
		/// Success: Returns 1. 
		/// Failure: Returns 0 if timeout occurred.
		/// </returns>
		public static int WinWaitActive(string vsTitle) {
			return AU3_WinWaitActive(vsTitle, "", 3000);
		}

		#endregion

		#region | Constants |

		public const int AU3_INTDEFAULT = -2147483647; // "Default" value for _some_ int parameters (largest negative number)
		public const int error = 1;
		public const int SW_HIDE = 2;
		public const int SW_MAXIMIZE = 3;
		public const int SW_MINIMIZE = 4;
		public const int SW_RESTORE = 5;
		public const int SW_SHOW = 6;
		public const int SW_SHOWDEFAULT = 7;
		public const int SW_SHOWMAXIMIZED = 8;
		public const int SW_SHOWMINIMIZED = 9;
		public const int SW_SHOWMINNOACTIVE = 10;
		public const int SW_SHOWNA = 11;
		public const int SW_SHOWNOACTIVATE = 12;
		public const int SW_SHOWNORMAL = 13;
		public const int version = 109;

		#endregion

		#region | AutoItX3.dll Exported Methods |

		//AU3_API void WINAPI AU3_Init(void);
		//Uncertain if this is needed
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_Init();

		//AU3_API long AU3_error(void);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_error();

		//AU3_API long WINAPI AU3_AutoItSetOption(const char *szOption, long nValue);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_AutoItSetOption([MarshalAs(UnmanagedType.LPStr)] string Option, int Value);

		//AU3_API void WINAPI AU3_BlockInput(long nFlag);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_BlockInput(int Flag);

		//AU3_API long WINAPI AU3_CDTray(const char *szDrive, const char *szAction);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_CDTray([MarshalAs(UnmanagedType.LPStr)] string Drive
		, [MarshalAs(UnmanagedType.LPStr)] string Action);

		//AU3_API void WINAPI AU3_ClipGet(char *szClip, int nBufSize);
		//Use like this:
		//byte[] returnclip = new byte[200]; //any sufficiently long lenght will do
		//AU3_ClipGet(returnclip, returnclip.Length);
		//clipdata = new ASCIIEncoding().GetString(returnclip);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_ClipGet(byte[] Clip, int BufSize);

		//AU3_API void WINAPI AU3_ClipPut(const char *szClip);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_ClipPut([MarshalAs(UnmanagedType.LPStr)] string Clip);

		//AU3_API long WINAPI AU3_ControlClick(const char *szTitle, const char *szText, const char *szControl
		//, const char *szButton, long nNumClicks, /*[in,defaultvalue(AU3_INTDEFAULT)]*/long nX
		//, /*[in,defaultvalue(AU3_INTDEFAULT)]*/long nY);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_ControlClick([MarshalAs(UnmanagedType.LPStr)] string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, [MarshalAs(UnmanagedType.LPStr)] string Control
		, [MarshalAs(UnmanagedType.LPStr)] string Button, int NumClicks, int X, int Y);

		//AU3_API void WINAPI AU3_ControlCommand(const char *szTitle, const char *szText, const char *szControl
		//, const char *szCommand, const char *szExtra, char *szResult, int nBufSize);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_ControlCommand([MarshalAs(UnmanagedType.LPStr)] string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, [MarshalAs(UnmanagedType.LPStr)] string Control
		, [MarshalAs(UnmanagedType.LPStr)] string Command, [MarshalAs(UnmanagedType.LPStr)] string Extra
		, [MarshalAs(UnmanagedType.LPStr)] byte[] Result, int BufSize);

		//AU3_API void WINAPI AU3_ControlListView(const char *szTitle, const char *szText, const char *szControl
		//, const char *szCommand, const char *szExtra1, const char *szExtra2, char *szResult, int nBufSize);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_ControlListView([MarshalAs(UnmanagedType.LPStr)] string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, [MarshalAs(UnmanagedType.LPStr)] string Control
		, [MarshalAs(UnmanagedType.LPStr)] string Command, [MarshalAs(UnmanagedType.LPStr)] string Extral1
		, [MarshalAs(UnmanagedType.LPStr)] string Extra2, byte[] Result, int BufSize);

		//AU3_API long WINAPI AU3_ControlDisable(const char *szTitle, const char *szText, const char *szControl);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_ControlDisable([MarshalAs(UnmanagedType.LPStr)] string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, [MarshalAs(UnmanagedType.LPStr)] string Control);

		//AU3_API long WINAPI AU3_ControlEnable(const char *szTitle, const char *szText, const char *szControl);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_ControlEnable([MarshalAs(UnmanagedType.LPStr)] string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, [MarshalAs(UnmanagedType.LPStr)] string Control);

		//AU3_API long WINAPI AU3_ControlFocus(const char *szTitle, const char *szText, const char *szControl);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_ControlFocus([MarshalAs(UnmanagedType.LPStr)] string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, [MarshalAs(UnmanagedType.LPStr)] string Control);

		//AU3_API void WINAPI AU3_ControlGetFocus(const char *szTitle, const char *szText, char *szControlWithFocus
		//, int nBufSize);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_ControlGetFocus([MarshalAs(UnmanagedType.LPStr)] string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, byte[] ControlWithFocus, int BufSize);

		//AU3_API void WINAPI AU3_ControlGetHandle(const char *szTitle, /*[in,defaultvalue("")]*/const char *szText
		//, const char *szControl, char *szRetText, int nBufSize);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_ControlGetHandle([MarshalAs(UnmanagedType.LPStr)] string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, [MarshalAs(UnmanagedType.LPStr)] string Control
		, byte[] RetText, int BufSize);

		//AU3_API long WINAPI AU3_ControlGetPosX(const char *szTitle, const char *szText, const char *szControl);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_ControlGetPosX([MarshalAs(UnmanagedType.LPStr)] string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, [MarshalAs(UnmanagedType.LPStr)] string Control);

		//AU3_API long WINAPI AU3_ControlGetPosY(const char *szTitle, const char *szText, const char *szControl);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_ControlGetPosY([MarshalAs(UnmanagedType.LPStr)] string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, [MarshalAs(UnmanagedType.LPStr)] string Control);

		//AU3_API long WINAPI AU3_ControlGetPosHeight(const char *szTitle, const char *szText, const char *szControl);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_ControlGetPosHeight([MarshalAs(UnmanagedType.LPStr)] string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, [MarshalAs(UnmanagedType.LPStr)] string Control);

		//AU3_API long WINAPI AU3_ControlGetPosWidth(const char *szTitle, const char *szText, const char *szControl);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_ControlGetPosWidth([MarshalAs(UnmanagedType.LPStr)] string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, [MarshalAs(UnmanagedType.LPStr)] string Control);

		//AU3_API void WINAPI AU3_ControlGetText(const char *szTitle, const char *szText, const char *szControl
		//, char *szControlText, int nBufSize);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_ControlGetText([MarshalAs(UnmanagedType.LPStr)] string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, [MarshalAs(UnmanagedType.LPStr)] string Control
		, byte[] ControlText, int BufSize);

		//AU3_API long WINAPI AU3_ControlHide(const char *szTitle, const char *szText, const char *szControl);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_ControlHide([MarshalAs(UnmanagedType.LPStr)] string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, [MarshalAs(UnmanagedType.LPStr)] string Control);

		//AU3_API long WINAPI AU3_ControlMove(const char *szTitle, const char *szText, const char *szControl
		//, long nX, long nY, /*[in,defaultvalue(-1)]*/long nWidth, /*[in,defaultvalue(-1)]*/long nHeight);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_ControlMove([MarshalAs(UnmanagedType.LPStr)] string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, [MarshalAs(UnmanagedType.LPStr)] string Control
		, int X, int Y, int Width, int Height);

		//AU3_API long WINAPI AU3_ControlSend(const char *szTitle, const char *szText, const char *szControl
		//, const char *szSendText, /*[in,defaultvalue(0)]*/long nMode);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_ControlSend([MarshalAs(UnmanagedType.LPStr)] string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, [MarshalAs(UnmanagedType.LPStr)] string Control
		, [MarshalAs(UnmanagedType.LPStr)] string SendText, int Mode);

		//AU3_API long WINAPI AU3_ControlSetText(const char *szTitle, const char *szText, const char *szControl
		//, const char *szControlText);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_ControlSetText([MarshalAs(UnmanagedType.LPStr)] string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, [MarshalAs(UnmanagedType.LPStr)] string Control
		, [MarshalAs(UnmanagedType.LPStr)] string ControlText);

		//AU3_API long WINAPI AU3_ControlShow(const char *szTitle, const char *szText, const char *szControl);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_ControlShow([MarshalAs(UnmanagedType.LPStr)] string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, [MarshalAs(UnmanagedType.LPStr)] string Control);

		//AU3_API void WINAPI AU3_ControlTreeView(const char *szTitle, const char *szText, const char *szControl
		//, const char *szCommand, const char *szExtra1, const char *szExtra2, char *szResult, int nBufSize);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_ControlTreeView([MarshalAs(UnmanagedType.LPStr)] string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, [MarshalAs(UnmanagedType.LPStr)] string Control
		, [MarshalAs(UnmanagedType.LPStr)] string Command, [MarshalAs(UnmanagedType.LPStr)] string Extra1
		, [MarshalAs(UnmanagedType.LPStr)] string Extra2, byte[] Result, int BufSize);

		//AU3_API void WINAPI AU3_DriveMapAdd(const char *szDevice, const char *szShare, long nFlags
		//, /*[in,defaultvalue("")]*/const char *szUser, /*[in,defaultvalue("")]*/const char *szPwd
		//, char *szResult, int nBufSize);

		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_DriveMapAdd([MarshalAs(UnmanagedType.LPStr)] string Device
		, [MarshalAs(UnmanagedType.LPStr)] string Share, int Flags, [MarshalAs(UnmanagedType.LPStr)] string User
		, [MarshalAs(UnmanagedType.LPStr)] string Pwd, byte[] Result, int BufSize);

		//AU3_API long WINAPI AU3_DriveMapDel(const char *szDevice);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_DriveMapDel([MarshalAs(UnmanagedType.LPStr)] string Device);

		//AU3_API void WINAPI AU3_DriveMapGet(const char *szDevice, char *szMapping, int nBufSize);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_DriveMapDel([MarshalAs(UnmanagedType.LPStr)] string Device
		, byte[] Mapping, int BufSize);

		//AU3_API long WINAPI AU3_IniDelete(const char *szFilename, const char *szSection, const char *szKey);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_IniDelete([MarshalAs(UnmanagedType.LPStr)] string Filename
		, [MarshalAs(UnmanagedType.LPStr)] string Section, [MarshalAs(UnmanagedType.LPStr)] string Key);

		//AU3_API void WINAPI AU3_IniRead(const char *szFilename, const char *szSection, const char *szKey
		//, const char *szDefault, char *szValue, int nBufSize);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_IniRead([MarshalAs(UnmanagedType.LPStr)] string Filename
		, [MarshalAs(UnmanagedType.LPStr)] string Section, [MarshalAs(UnmanagedType.LPStr)] string Key
		, [MarshalAs(UnmanagedType.LPStr)] string Default, byte[] Value, int BufSize);

		//AU3_API long WINAPI AU3_IniWrite(const char *szFilename, const char *szSection, const char *szKey
		//, const char *szValue);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_IniWrite([MarshalAs(UnmanagedType.LPStr)] string Filename
		, [MarshalAs(UnmanagedType.LPStr)] string Section, [MarshalAs(UnmanagedType.LPStr)] string Key
		, [MarshalAs(UnmanagedType.LPStr)] string Value);

		//AU3_API long WINAPI AU3_IsAdmin(void);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_IsAdmin();

		//AU3_API long WINAPI AU3_MouseClick(/*[in,defaultvalue("LEFT")]*/const char *szButton
		//, /*[in,defaultvalue(AU3_INTDEFAULT)]*/long nX, /*[in,defaultvalue(AU3_INTDEFAULT)]*/long nY
		//, /*[in,defaultvalue(1)]*/long nClicks, /*[in,defaultvalue(-1)]*/long nSpeed);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_MouseClick([MarshalAs(UnmanagedType.LPStr)] string Button, int x, int y
		, int clicks, int speed);

		//AU3_API long WINAPI AU3_MouseClickDrag(const char *szButton, long nX1, long nY1, long nX2, long nY2
		//, /*[in,defaultvalue(-1)]*/long nSpeed);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_MouseClickDrag([MarshalAs(UnmanagedType.LPStr)] string Button
		, int X1, int Y1, int X2, int Y2, int Speed);

		//AU3_API void WINAPI AU3_MouseDown(/*[in,defaultvalue("LEFT")]*/const char *szButton);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_MouseDown([MarshalAs(UnmanagedType.LPStr)] string Button);

		//AU3_API long WINAPI AU3_MouseGetCursor(void);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_MouseGetCursor();

		//AU3_API long WINAPI AU3_MouseGetPosX(void);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_MouseGetPosX();

		//AU3_API long WINAPI AU3_MouseGetPosY(void);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_MouseGetPosY();

		//AU3_API long WINAPI AU3_MouseMove(long nX, long nY, /*[in,defaultvalue(-1)]*/long nSpeed);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_MouseMove(int X, int Y, int Speed);

		//AU3_API void WINAPI AU3_MouseUp(/*[in,defaultvalue("LEFT")]*/const char *szButton);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_MouseUp([MarshalAs(UnmanagedType.LPStr)] string Button);

		//AU3_API void WINAPI AU3_MouseWheel(const char *szDirection, long nClicks);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_MouseWheel([MarshalAs(UnmanagedType.LPStr)] string Direction, int Clicks);

		//AU3_API long WINAPI AU3_Opt(const char *szOption, long nValue);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_Opt([MarshalAs(UnmanagedType.LPStr)] string Option, int Value);

		//AU3_API long WINAPI AU3_PixelChecksum(long nLeft, long nTop, long nRight, long nBottom
		//, /*[in,defaultvalue(1)]*/long nStep);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_PixelChecksum(int Left, int Top, int Right, int Bottom, int Step);

		//AU3_API long WINAPI AU3_PixelGetColor(long nX, long nY);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_PixelGetColor(int X, int Y);

		//AU3_API void WINAPI AU3_PixelSearch(long nLeft, long nTop, long nRight, long nBottom, long nCol
		//, /*default 0*/long nVar, /*default 1*/long nStep, LPPOINT pPointResult);
		//Use like this:
		//int[] result = {0,0};
		//try
		//{
		// AU3_PixelSearch(0, 0, 800, 000,0xFFFFFF, 0, 1, result);
		//}
		//catch { }
		//It will crash if the color is not found, have not be able to determin why
		//The AutoItX3Lib.AutoItX3Class version has similar problems and is the only function to return an object
		//so contortions are needed to get the data from it ie:
		//int[] result = {0,0};
		//object resultObj;
		//AutoItX3Lib.AutoItX3Class autoit = new AutoItX3Lib.AutoItX3Class();
		//resultObj = autoit.PixelSearch(0, 0, 800, 600, 0xFFFF00,0,1);
		//Type t = resultObj.GetType();
		//if(t == typeof(object[]))
		//{
		//object[] obj = (object[])resultObj;
		//result[0] = (int)obj[0];
		//result[1] = (int)obj[1];
		//}
		//When it fails it returns an object = 1 but when it succeeds it is object[X,Y]
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_PixelSearch(int Left, int Top, int Right, int Bottom, int Col, int Var
		, int Step, int[] PointResult);

		//AU3_API long WINAPI AU3_ProcessClose(const char *szProcess);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_ProcessClose([MarshalAs(UnmanagedType.LPStr)]string Process);

		//AU3_API long WINAPI AU3_ProcessExists(const char *szProcess);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_ProcessExists([MarshalAs(UnmanagedType.LPStr)]string Process);

		//AU3_API long WINAPI AU3_ProcessSetPriority(const char *szProcess, long nPriority);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_ProcessSetPriority([MarshalAs(UnmanagedType.LPStr)]string Process, int Priority);

		//AU3_API long WINAPI AU3_ProcessWait(const char *szProcess, /*[in,defaultvalue(0)]*/long nTimeout);
		//Not checked jde
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_ProcessWait([MarshalAs(UnmanagedType.LPStr)]string Process, int Timeout);

		//AU3_API long WINAPI AU3_ProcessWaitClose(const char *szProcess, /*[in,defaultvalue(0)]*/long nTimeout);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_ProcessWaitClose([MarshalAs(UnmanagedType.LPStr)]string Process, int Timeout);

		//AU3_API long WINAPI AU3_RegDeleteKey(const char *szKeyname);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_RegDeleteKey([MarshalAs(UnmanagedType.LPStr)]string Keyname);

		//AU3_API long WINAPI AU3_RegDeleteVal(const char *szKeyname, const char *szValuename);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_RegDeleteVal([MarshalAs(UnmanagedType.LPStr)]string Keyname
		, [MarshalAs(UnmanagedType.LPStr)]string ValueName);

		//AU3_API void WINAPI AU3_RegEnumKey(const char *szKeyname, long nInstance, char *szResult, int nBufSize);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_RegEnumKey([MarshalAs(UnmanagedType.LPStr)]string Keyname
		, int Instance, byte[] Result, int BusSize);

		//AU3_API void WINAPI AU3_RegEnumVal(const char *szKeyname, long nInstance, char *szResult, int nBufSize);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_RegEnumVal([MarshalAs(UnmanagedType.LPStr)]string Keyname
		, int Instance, byte[] Result, int BufSize);

		//AU3_API void WINAPI AU3_RegRead(const char *szKeyname, const char *szValuename, char *szRetText, int nBufSize);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_RegRead([MarshalAs(UnmanagedType.LPStr)]string Keyname
		, [MarshalAs(UnmanagedType.LPStr)]string Valuename, byte[] RetText, int BufSize);

		//AU3_API long WINAPI AU3_RegWrite(const char *szKeyname, const char *szValuename, const char *szType
		//, const char *szValue);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_RegWrite([MarshalAs(UnmanagedType.LPStr)]string Keyname
		, [MarshalAs(UnmanagedType.LPStr)]string Valuename, [MarshalAs(UnmanagedType.LPStr)]string Type
		, [MarshalAs(UnmanagedType.LPStr)]string Value);

		//AU3_API long WINAPI AU3_Run(const char *szRun, /*[in,defaultvalue("")]*/const char *szDir
		//, /*[in,defaultvalue(1)]*/long nShowFlags);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_Run([MarshalAs(UnmanagedType.LPStr)]string Run
		, [MarshalAs(UnmanagedType.LPStr)]string Dir, int ShowFlags);

		//AU3_API long WINAPI AU3_RunAsSet(const char *szUser, const char *szDomain, const char *szPassword, int nOptions);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_RunAsSet([MarshalAs(UnmanagedType.LPStr)]string User
		, [MarshalAs(UnmanagedType.LPStr)]string Domain, [MarshalAs(UnmanagedType.LPStr)]string Password
		, int Options);

		//AU3_API long WINAPI AU3_RunWait(const char *szRun, /*[in,defaultvalue("")]*/const char *szDir
		//, /*[in,defaultvalue(1)]*/long nShowFlags);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_RunWait([MarshalAs(UnmanagedType.LPStr)]string Run
		, [MarshalAs(UnmanagedType.LPStr)]string Dir, int ShowFlags);

		//AU3_API void WINAPI AU3_Send(const char *szSendText, /*[in,defaultvalue(0)]*/long nMode);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_Send([MarshalAs(UnmanagedType.LPStr)] string SendText, int Mode);

		//AU3_API long WINAPI AU3_Shutdown(long nFlags);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_Shutdown(int Flags);

		//AU3_API void WINAPI AU3_Sleep(long nMilliseconds);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_Sleep(int Milliseconds);

		//AU3_API void WINAPI AU3_StatusbarGetText(const char *szTitle, /*[in,defaultvalue("")]*/const char *szText
		//, /*[in,defaultvalue(1)]*/long nPart, char *szStatusText, int nBufSize);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_StatusbarGetText([MarshalAs(UnmanagedType.LPStr)]string Title
		, [MarshalAs(UnmanagedType.LPStr)]string Text, int Part, byte[] StatusText, int BufSize);

		//AU3_API void WINAPI AU3_ToolTip(const char *szTip, /*[in,defaultvalue(AU3_INTDEFAULT)]*/long nX
		//, /*[in,defaultvalue(AU3_INTDEFAULT)]*/long nY);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_ToolTip([MarshalAs(UnmanagedType.LPStr)]string Tip, int X, int Y);

		//AU3_API void WINAPI AU3_WinActivate(const char *szTitle, /*[in,defaultvalue("")]*/const char *szText);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_WinActivate([MarshalAs(UnmanagedType.LPStr)]string Title
		, [MarshalAs(UnmanagedType.LPStr)]string Text);

		//AU3_API long WINAPI AU3_WinActive(const char *szTitle, /*[in,defaultvalue("")]*/const char *szText);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_WinActive([MarshalAs(UnmanagedType.LPStr)]string Title
		, [MarshalAs(UnmanagedType.LPStr)]string Text);

		//AU3_API long WINAPI AU3_WinClose(const char *szTitle, /*[in,defaultvalue("")]*/const char *szText);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_WinClose([MarshalAs(UnmanagedType.LPStr)]string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text);

		//AU3_API long WINAPI AU3_WinExists(const char *szTitle, /*[in,defaultvalue("")]*/const char *szText);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_WinExists([MarshalAs(UnmanagedType.LPStr)]string Title
		, [MarshalAs(UnmanagedType.LPStr)]string Text);

		//AU3_API long WINAPI AU3_WinGetCaretPosX(void);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_WinGetCaretPosX();

		//AU3_API long WINAPI AU3_WinGetCaretPosY(void);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_WinGetCaretPosY();

		//AU3_API void WINAPI AU3_WinGetClassList(const char *szTitle, /*[in,defaultvalue("")]*/const char *szText
		//, char *szRetText, int nBufSize);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_WinGetClassList([MarshalAs(UnmanagedType.LPStr)]string Title
		, [MarshalAs(UnmanagedType.LPStr)]string Text, byte[] RetText, int BufSize);

		//AU3_API long WINAPI AU3_WinGetClientSizeHeight(const char *szTitle, /*[in,defaultvalue("")]*/const char *szText);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_WinGetClientSizeHeight([MarshalAs(UnmanagedType.LPStr)]string Title
		, [MarshalAs(UnmanagedType.LPStr)]string Text);

		//AU3_API long WINAPI AU3_WinGetClientSizeWidth(const char *szTitle, /*[in,defaultvalue("")]*/const char *szText);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_WinGetClientSizeWidth([MarshalAs(UnmanagedType.LPStr)]string Title
		, [MarshalAs(UnmanagedType.LPStr)]string Text);

		//AU3_API void WINAPI AU3_WinGetHandle(const char *szTitle, /*[in,defaultvalue("")]*/const char *szText
		//, char *szRetText, int nBufSize);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_WinGetHandle([MarshalAs(UnmanagedType.LPStr)]string Title
		, [MarshalAs(UnmanagedType.LPStr)]string Text, byte[] RetText, int BufSize);

		//AU3_API long WINAPI AU3_WinGetPosX(const char *szTitle, /*[in,defaultvalue("")]*/const char *szText);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_WinGetPosX([MarshalAs(UnmanagedType.LPStr)]string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text);

		//AU3_API long WINAPI AU3_WinGetPosY(const char *szTitle, /*[in,defaultvalue("")]*/const char *szText);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_WinGetPosY([MarshalAs(UnmanagedType.LPStr)]string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text);

		//AU3_API long WINAPI AU3_WinGetPosHeight(const char *szTitle, /*[in,defaultvalue("")]*/const char *szText);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_WinGetPosHeight([MarshalAs(UnmanagedType.LPStr)]string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text);

		//AU3_API long WINAPI AU3_WinGetPosWidth(const char *szTitle, /*[in,defaultvalue("")]*/const char *szText);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_WinGetPosWidth([MarshalAs(UnmanagedType.LPStr)]string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text);

		//AU3_API void WINAPI AU3_WinGetProcess(const char *szTitle, /*[in,defaultvalue("")]*/const char *szText
		//, char *szRetText, int nBufSize);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_WinGetProcess([MarshalAs(UnmanagedType.LPStr)]string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, byte[] RetText, int BufSize);

		//AU3_API long WINAPI AU3_WinGetState(const char *szTitle, /*[in,defaultvalue("")]*/const char *szText);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_WinGetState([MarshalAs(UnmanagedType.LPStr)]string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text);

		//AU3_API void WINAPI AU3_WinGetText(const char *szTitle, /*[in,defaultvalue("")]*/const char *szText
		//, char *szRetText, int nBufSize);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_WinGetText([MarshalAs(UnmanagedType.LPStr)]string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, byte[] RetText, int BufSize);

		//AU3_API void WINAPI AU3_WinGetTitle(const char *szTitle, /*[in,defaultvalue("")]*/const char *szText
		//, char *szRetText, int nBufSize);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_WinGetTitle([MarshalAs(UnmanagedType.LPStr)]string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, byte[] RetText, int BufSize);

		//AU3_API long WINAPI AU3_WinKill(const char *szTitle, /*[in,defaultvalue("")]*/const char *szText);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_WinKill([MarshalAs(UnmanagedType.LPStr)]string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text);

		//AU3_API long WINAPI AU3_WinMenuSelectItem(const char *szTitle, /*[in,defaultvalue("")]*/const char *szText
		//, const char *szItem1, const char *szItem2, const char *szItem3, const char *szItem4, const char *szItem5
		//, const char *szItem6, const char *szItem7, const char *szItem8);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_WinMenuSelectItem([MarshalAs(UnmanagedType.LPStr)]string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, [MarshalAs(UnmanagedType.LPStr)] string Item1
		, [MarshalAs(UnmanagedType.LPStr)] string Item2, [MarshalAs(UnmanagedType.LPStr)] string Item3
		, [MarshalAs(UnmanagedType.LPStr)] string Item4, [MarshalAs(UnmanagedType.LPStr)] string Item5
		, [MarshalAs(UnmanagedType.LPStr)] string Item6, [MarshalAs(UnmanagedType.LPStr)] string Item7
		, [MarshalAs(UnmanagedType.LPStr)] string Item8);

		//AU3_API void WINAPI AU3_WinMinimizeAll();
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_WinMinimizeAll();

		//AU3_API void WINAPI AU3_WinMinimizeAllUndo();
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern void AU3_WinMinimizeAllUndo();

		//AU3_API long WINAPI AU3_WinMove(const char *szTitle, /*[in,defaultvalue("")]*/const char *szText
		//, long nX, long nY, /*[in,defaultvalue(-1)]*/long nWidth, /*[in,defaultvalue(-1)]*/long nHeight);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_WinMove([MarshalAs(UnmanagedType.LPStr)]string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, int X, int Y, int Width, int Height);

		//AU3_API long WINAPI AU3_WinSetOnTop(const char *szTitle, /*[in,defaultvalue("")]*/const char *szText, long nFlag);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_WinMove([MarshalAs(UnmanagedType.LPStr)]string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, int Flags);

		//AU3_API long WINAPI AU3_WinSetState(const char *szTitle, /*[in,defaultvalue("")]*/const char *szText, long nFlags);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_WinSetState([MarshalAs(UnmanagedType.LPStr)]string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, int Flags);

		//AU3_API long WINAPI AU3_WinSetTitle(const char *szTitle,/*[in,defaultvalue("")]*/ const char *szText
		//, const char *szNewTitle);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_WinSetTitle([MarshalAs(UnmanagedType.LPStr)]string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, [MarshalAs(UnmanagedType.LPStr)] string NewTitle);

		//AU3_API long WINAPI AU3_WinSetTrans(const char *szTitle, /*[in,defaultvalue("")]*/const char *szText, long nTrans);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_WinSetTrans([MarshalAs(UnmanagedType.LPStr)]string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, int Trans);

		//AU3_API long WINAPI AU3_WinWait(const char *szTitle, /*[in,defaultvalue("")]*/const char *szText
		//, /*[in,defaultvalue(0)]*/long nTimeout);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_WinWait([MarshalAs(UnmanagedType.LPStr)]string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, int Timeout);

		//AU3_API long WINAPI AU3_WinWaitActive(const char *szTitle, /*[in,defaultvalue("")]*/const char *szText
		//, /*[in,defaultvalue(0)]*/long nTimeout);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_WinWaitActive([MarshalAs(UnmanagedType.LPStr)]string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, int Timeout);

		//AU3_API long WINAPI AU3_WinWaitClose(const char *szTitle, /*[in,defaultvalue("")]*/const char *szText
		//, /*[in,defaultvalue(0)]*/long nTimeout);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_WinWaitClose([MarshalAs(UnmanagedType.LPStr)]string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, int Timeout);

		//AU3_API long WINAPI AU3_WinWaitNotActive(const char *szTitle, /*[in,defaultvalue("")]*/const char *szText
		//, /*[in,defaultvalue(0)]*/long nTimeout);
		[DllImport("AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int AU3_WinWaitNotActive([MarshalAs(UnmanagedType.LPStr)]string Title
		, [MarshalAs(UnmanagedType.LPStr)] string Text, int Timeout);

		#endregion

	}

}
