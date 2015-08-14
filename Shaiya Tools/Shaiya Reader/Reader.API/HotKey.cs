using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Shaiya.Reader.API {


	public class HotKey : IDisposable {
		/// <summary>
		/// Event Args for the event that is fired after the hot key has been pressed.
		/// </summary>
		public class KeyPressedEventArgs : EventArgs {
			private ModifierKeys mModifier;
			private Keys mKey;

			public ModifierKeys Modifier {
				get { return mModifier; }
			}

			public Keys Key {
				get { return mKey; }
			}

			internal KeyPressedEventArgs( ModifierKeys modifier, Keys key ) {
				mModifier = modifier;
				mKey = key;
			}

		}

		[Flags]
		public enum ModifierKeys : uint {
			Alt = 1,
			Control = 2,
			Shift = 4,
			Win = 8
		}




		[DllImport( "user32.dll" )]
		private static extern bool RegisterHotKey( IntPtr hWnd, int id, uint fsModifiers, uint vk );
		[DllImport( "user32.dll" )]
		private static extern bool UnregisterHotKey( IntPtr hWnd, int id );

		/// <summary>
		/// Represents the window that is used internally to get the messages.
		/// </summary>
		private class Window : NativeWindow, IDisposable {
			private static int WM_HOTKEY = 0x0312;

			public Window() {
				this.CreateHandle( new CreateParams() );
			}

			/// <summary>
			/// Overridden to get the notifications.
			/// </summary>
			/// <param name="m"></param>
			protected override void WndProc( ref Message m ) {
				base.WndProc( ref m );

				if( m.Msg == WM_HOTKEY ) {
					Keys key = (Keys)( ( (int)m.LParam >> 16 ) & 0xFFFF );
					ModifierKeys modifier = (ModifierKeys)( (int)m.LParam & 0xFFFF );
					if( KeyPressed != null )
						KeyPressed( this, new KeyPressedEventArgs( modifier, key ) );
				}
			}

			public event EventHandler<KeyPressedEventArgs> KeyPressed;

			public void Dispose() {
				this.DestroyHandle();
			}
		}

		private Window mWindow = new Window();
		private int mCurrentId;

		public HotKey() {
			mWindow.KeyPressed += delegate( object sender, KeyPressedEventArgs args ) {
				if( KeyPressed != null )
					KeyPressed( this, args );
			};
		}

		/// <summary>
		/// Registers a hot key in the system.
		/// </summary>
		/// <param name="modifier">The modifiers that are associated with the hot key.</param>
		/// <param name="key">The key itself that is associated with the hot key.</param>
		public void RegisterHotKey( ModifierKeys modifier, Keys key ) {
			mCurrentId = mCurrentId + 1;
			if( !RegisterHotKey( mWindow.Handle, mCurrentId, (uint)modifier, (uint)key ) )
				throw new InvalidOperationException( "Couldn't register the hot key." );
		}

		/// <summary>
		/// A hot key has been pressed.
		/// </summary>
		public event EventHandler<KeyPressedEventArgs> KeyPressed;

		public void Dispose() {
			for( int i = mCurrentId; i > 0; i-- ) 
				UnregisterHotKey( mWindow.Handle, i );
			mWindow.Dispose();
		}
	}



}