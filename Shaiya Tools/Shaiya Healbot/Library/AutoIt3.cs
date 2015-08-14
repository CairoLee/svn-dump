using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Healbot.Library {

	public class AutoIt3 {
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
		public const int version = 110; //was 109 if previous non-unicode version

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto, EntryPoint = "AU3_Init" )]
		public static extern void Init();

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_error();

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_AutoItSetOption( [MarshalAs( UnmanagedType.LPWStr )] string Option, int Value );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_BlockInput( int Flag );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_CDTray( [MarshalAs( UnmanagedType.LPWStr )] string Drive, [MarshalAs( UnmanagedType.LPWStr )] string Action );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_ClipGet( [MarshalAs( UnmanagedType.LPWStr )]StringBuilder Clip, int BufSize );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_ClipPut( [MarshalAs( UnmanagedType.LPWStr )] string Clip );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_ControlClick( [MarshalAs( UnmanagedType.LPWStr )] string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, [MarshalAs( UnmanagedType.LPWStr )] string Control, [MarshalAs( UnmanagedType.LPWStr )] string Button, int NumClicks, int X, int Y );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_ControlCommand( [MarshalAs( UnmanagedType.LPWStr )] string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, [MarshalAs( UnmanagedType.LPWStr )] string Control, [MarshalAs( UnmanagedType.LPWStr )] string Command, [MarshalAs( UnmanagedType.LPWStr )] string Extra, [MarshalAs( UnmanagedType.LPWStr )] StringBuilder Result, int BufSize );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_ControlListView( [MarshalAs( UnmanagedType.LPWStr )] string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, [MarshalAs( UnmanagedType.LPWStr )] string Control, [MarshalAs( UnmanagedType.LPWStr )] string Command, [MarshalAs( UnmanagedType.LPWStr )] string Extral1, [MarshalAs( UnmanagedType.LPWStr )] string Extra2, [MarshalAs( UnmanagedType.LPWStr )] StringBuilder Result, int BufSize );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_ControlDisable( [MarshalAs( UnmanagedType.LPWStr )] string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, [MarshalAs( UnmanagedType.LPWStr )] string Control );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_ControlEnable( [MarshalAs( UnmanagedType.LPWStr )] string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, [MarshalAs( UnmanagedType.LPWStr )] string Control );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_ControlFocus( [MarshalAs( UnmanagedType.LPWStr )] string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, [MarshalAs( UnmanagedType.LPWStr )] string Control );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_ControlGetFocus( [MarshalAs( UnmanagedType.LPWStr )] string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, [MarshalAs( UnmanagedType.LPWStr )] StringBuilder ControlWithFocus, int BufSize );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_ControlGetHandle( [MarshalAs( UnmanagedType.LPWStr )] string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, [MarshalAs( UnmanagedType.LPWStr )] string Control, [MarshalAs( UnmanagedType.LPWStr )] StringBuilder RetText, int BufSize );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_ControlGetPosX( [MarshalAs( UnmanagedType.LPWStr )] string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, [MarshalAs( UnmanagedType.LPWStr )] string Control );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_ControlGetPosY( [MarshalAs( UnmanagedType.LPWStr )] string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, [MarshalAs( UnmanagedType.LPWStr )] string Control );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_ControlGetPosHeight( [MarshalAs( UnmanagedType.LPWStr )] string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, [MarshalAs( UnmanagedType.LPWStr )] string Control );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_ControlGetPosWidth( [MarshalAs( UnmanagedType.LPWStr )] string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, [MarshalAs( UnmanagedType.LPWStr )] string Control );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_ControlGetText( [MarshalAs( UnmanagedType.LPWStr )] string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, [MarshalAs( UnmanagedType.LPWStr )] string Control, [MarshalAs( UnmanagedType.LPWStr )]StringBuilder ControlText, int BufSize );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_ControlHide( [MarshalAs( UnmanagedType.LPWStr )] string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, [MarshalAs( UnmanagedType.LPWStr )] string Control );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_ControlMove( [MarshalAs( UnmanagedType.LPWStr )] string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, [MarshalAs( UnmanagedType.LPWStr )] string Control, int X, int Y, int Width, int Height );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_ControlSend( [MarshalAs( UnmanagedType.LPWStr )] string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, [MarshalAs( UnmanagedType.LPWStr )] string Control, [MarshalAs( UnmanagedType.LPWStr )] string SendText, int Mode );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_ControlSetText( [MarshalAs( UnmanagedType.LPWStr )] string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, [MarshalAs( UnmanagedType.LPWStr )] string Control, [MarshalAs( UnmanagedType.LPWStr )] string ControlText );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_ControlShow( [MarshalAs( UnmanagedType.LPWStr )] string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, [MarshalAs( UnmanagedType.LPWStr )] string Control );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_ControlTreeView( [MarshalAs( UnmanagedType.LPWStr )] string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, [MarshalAs( UnmanagedType.LPWStr )] string Control, [MarshalAs( UnmanagedType.LPWStr )] string Command, [MarshalAs( UnmanagedType.LPWStr )] string Extra1, [MarshalAs( UnmanagedType.LPWStr )] string Extra2, [MarshalAs( UnmanagedType.LPWStr )]StringBuilder Result, int BufSize );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_DriveMapAdd( [MarshalAs( UnmanagedType.LPWStr )] string Device, [MarshalAs( UnmanagedType.LPWStr )] string Share, int Flags, [MarshalAs( UnmanagedType.LPWStr )] string User, [MarshalAs( UnmanagedType.LPWStr )] string Pwd, [MarshalAs( UnmanagedType.LPWStr )]StringBuilder Result, int BufSize );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_DriveMapDel( [MarshalAs( UnmanagedType.LPWStr )] string Device );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_DriveMapGet( [MarshalAs( UnmanagedType.LPWStr )] string Device, [MarshalAs( UnmanagedType.LPWStr )]StringBuilder Mapping, int BufSize );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_IniDelete( [MarshalAs( UnmanagedType.LPWStr )] string Filename, [MarshalAs( UnmanagedType.LPWStr )] string Section, [MarshalAs( UnmanagedType.LPWStr )] string Key );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_IniRead( [MarshalAs( UnmanagedType.LPWStr )] string Filename, [MarshalAs( UnmanagedType.LPWStr )] string Section, [MarshalAs( UnmanagedType.LPWStr )] string Key, [MarshalAs( UnmanagedType.LPWStr )] string Default, [MarshalAs( UnmanagedType.LPWStr )]StringBuilder Value, int BufSize );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_IniWrite( [MarshalAs( UnmanagedType.LPWStr )] string Filename, [MarshalAs( UnmanagedType.LPWStr )] string Section, [MarshalAs( UnmanagedType.LPWStr )] string Key, [MarshalAs( UnmanagedType.LPWStr )] string Value );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_IsAdmin();

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_MouseClick( [MarshalAs( UnmanagedType.LPWStr )] string Button, int x, int y, int clicks, int speed );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_MouseClickDrag( [MarshalAs( UnmanagedType.LPWStr )] string Button, int X1, int Y1, int X2, int Y2, int Speed );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_MouseDown( [MarshalAs( UnmanagedType.LPWStr )] string Button );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_MouseGetCursor();

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_MouseGetPosX();

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_MouseGetPosY();

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_MouseMove( int X, int Y, int Speed );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_MouseUp( [MarshalAs( UnmanagedType.LPWStr )] string Button );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_MouseWheel( [MarshalAs( UnmanagedType.LPWStr )] string Direction, int Clicks );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_Opt( [MarshalAs( UnmanagedType.LPWStr )] string Option, int Value );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_PixelChecksum( int Left, int Top, int Right, int Bottom, int Step );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_PixelGetColor( int X, int Y );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_PixelSearch( int Left, int Top, int Right, int Bottom, int Col, int Var, int Step, int[] PointResult );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_ProcessClose( [MarshalAs( UnmanagedType.LPWStr )]string Process );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_ProcessExists( [MarshalAs( UnmanagedType.LPWStr )]string Process );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_ProcessSetPriority( [MarshalAs( UnmanagedType.LPWStr )]string Process, int Priority );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_ProcessWait( [MarshalAs( UnmanagedType.LPWStr )]string Process, int Timeout );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_ProcessWaitClose( [MarshalAs( UnmanagedType.LPWStr )]string Process, int Timeout );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_RegDeleteKey( [MarshalAs( UnmanagedType.LPWStr )]string Keyname );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_RegDeleteVal( [MarshalAs( UnmanagedType.LPWStr )]string Keyname, [MarshalAs( UnmanagedType.LPWStr )]string ValueName );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_RegEnumKey( [MarshalAs( UnmanagedType.LPWStr )]string Keyname, int Instance, [MarshalAs( UnmanagedType.LPWStr )]StringBuilder Result, int BusSize );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_RegEnumVal( [MarshalAs( UnmanagedType.LPWStr )]string Keyname, int Instance, [MarshalAs( UnmanagedType.LPWStr )]StringBuilder Result, int BufSize );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_RegRead( [MarshalAs( UnmanagedType.LPWStr )]string Keyname, [MarshalAs( UnmanagedType.LPWStr )]string Valuename, [MarshalAs( UnmanagedType.LPWStr )]StringBuilder RetText, int BufSize );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_RegWrite( [MarshalAs( UnmanagedType.LPWStr )]string Keyname, [MarshalAs( UnmanagedType.LPWStr )]string Valuename, [MarshalAs( UnmanagedType.LPWStr )]string Type, [MarshalAs( UnmanagedType.LPWStr )]string Value );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_Run( [MarshalAs( UnmanagedType.LPWStr )]string Run, [MarshalAs( UnmanagedType.LPWStr )]string Dir, int ShowFlags );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_RunAsSet( [MarshalAs( UnmanagedType.LPWStr )]string User, [MarshalAs( UnmanagedType.LPWStr )]string Domain, [MarshalAs( UnmanagedType.LPWStr )]string Password, int Options );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_RunWait( [MarshalAs( UnmanagedType.LPWStr )]string Run, [MarshalAs( UnmanagedType.LPWStr )]string Dir, int ShowFlags );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_Send( [MarshalAs( UnmanagedType.LPWStr )] string SendText, int Mode );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_SendA( [MarshalAs( UnmanagedType.LPStr )] string SendText, int Mode );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_Shutdown( int Flags );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_Sleep( int Milliseconds );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_StatusbarGetText( [MarshalAs( UnmanagedType.LPWStr )]string Title, [MarshalAs( UnmanagedType.LPWStr )]string Text, int Part, [MarshalAs( UnmanagedType.LPWStr )]StringBuilder StatusText, int BufSize );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_ToolTip( [MarshalAs( UnmanagedType.LPWStr )]string Tip, int X, int Y );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_WinActivate( [MarshalAs( UnmanagedType.LPWStr )]string Title, [MarshalAs( UnmanagedType.LPWStr )]string Text );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_WinActive( [MarshalAs( UnmanagedType.LPWStr )]string Title, [MarshalAs( UnmanagedType.LPWStr )]string Text );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_WinClose( [MarshalAs( UnmanagedType.LPWStr )]string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_WinExists( [MarshalAs( UnmanagedType.LPWStr )]string Title, [MarshalAs( UnmanagedType.LPWStr )]string Text );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_WinGetCaretPosX();

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_WinGetCaretPosY();

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_WinGetClassList( [MarshalAs( UnmanagedType.LPWStr )]string Title, [MarshalAs( UnmanagedType.LPWStr )]string Text, [MarshalAs( UnmanagedType.LPWStr )]StringBuilder RetText, int BufSize );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_WinGetClientSizeHeight( [MarshalAs( UnmanagedType.LPWStr )]string Title, [MarshalAs( UnmanagedType.LPWStr )]string Text );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_WinGetClientSizeWidth( [MarshalAs( UnmanagedType.LPWStr )]string Title, [MarshalAs( UnmanagedType.LPWStr )]string Text );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_WinGetHandle( [MarshalAs( UnmanagedType.LPWStr )]string Title, [MarshalAs( UnmanagedType.LPWStr )]string Text, [MarshalAs( UnmanagedType.LPWStr )]StringBuilder RetText, int BufSize );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_WinGetPosX( [MarshalAs( UnmanagedType.LPWStr )]string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_WinGetPosY( [MarshalAs( UnmanagedType.LPWStr )]string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_WinGetPosHeight( [MarshalAs( UnmanagedType.LPWStr )]string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_WinGetPosWidth( [MarshalAs( UnmanagedType.LPWStr )]string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_WinGetProcess( [MarshalAs( UnmanagedType.LPWStr )]string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, [MarshalAs( UnmanagedType.LPWStr )]StringBuilder RetText, int BufSize );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_WinGetState( [MarshalAs( UnmanagedType.LPWStr )]string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_WinGetText( [MarshalAs( UnmanagedType.LPWStr )]string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, [MarshalAs( UnmanagedType.LPWStr )]StringBuilder RetText, int BufSize );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_WinGetTitle( [MarshalAs( UnmanagedType.LPWStr )]string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, [MarshalAs( UnmanagedType.LPWStr )]StringBuilder RetText, int BufSize );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_WinKill( [MarshalAs( UnmanagedType.LPWStr )]string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_WinMenuSelectItem( [MarshalAs( UnmanagedType.LPWStr )]string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, [MarshalAs( UnmanagedType.LPWStr )] string Item1, [MarshalAs( UnmanagedType.LPWStr )] string Item2, [MarshalAs( UnmanagedType.LPWStr )] string Item3, [MarshalAs( UnmanagedType.LPWStr )] string Item4, [MarshalAs( UnmanagedType.LPWStr )] string Item5, [MarshalAs( UnmanagedType.LPWStr )] string Item6, [MarshalAs( UnmanagedType.LPWStr )] string Item7, [MarshalAs( UnmanagedType.LPWStr )] string Item8 );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_WinMinimizeAll();

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern void AU3_WinMinimizeAllUndo();

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_WinMove( [MarshalAs( UnmanagedType.LPWStr )]string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, int X, int Y, int Width, int Height );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_WinSetOnTop( [MarshalAs( UnmanagedType.LPWStr )]string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, int Flags );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_WinSetState( [MarshalAs( UnmanagedType.LPWStr )]string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, int Flags );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_WinSetTitle( [MarshalAs( UnmanagedType.LPWStr )]string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, [MarshalAs( UnmanagedType.LPWStr )] string NewTitle );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_WinSetTrans( [MarshalAs( UnmanagedType.LPWStr )]string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, int Trans );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_WinWait( [MarshalAs( UnmanagedType.LPWStr )]string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, int Timeout );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_WinWaitA( [MarshalAs( UnmanagedType.LPStr )]string Title, [MarshalAs( UnmanagedType.LPStr )] string Text, int Timeout );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_WinWaitActive( [MarshalAs( UnmanagedType.LPWStr )]string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, int Timeout );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_WinWaitActiveA( [MarshalAs( UnmanagedType.LPStr )]string Title, [MarshalAs( UnmanagedType.LPStr )] string Text, int Timeout );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_WinWaitClose( [MarshalAs( UnmanagedType.LPWStr )]string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, int Timeout );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_WinWaitCloseA( [MarshalAs( UnmanagedType.LPStr )]string Title, [MarshalAs( UnmanagedType.LPStr )] string Text, int Timeout );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_WinWaitNotActive( [MarshalAs( UnmanagedType.LPWStr )]string Title, [MarshalAs( UnmanagedType.LPWStr )] string Text, int Timeout );

		[DllImport( "AutoItX3.dll", SetLastError = true, CharSet = CharSet.Auto )]
		public static extern int AU3_WinWaitNotActiveA( [MarshalAs( UnmanagedType.LPStr )]string Title, [MarshalAs( UnmanagedType.LPStr )] string Text, int Timeout );

	}
}

