using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Shaiya_Hotkey_Emulator {

	public class HotKey : IMessageFilter {
		[DllImport( "user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true )]
		private static extern int RegisterHotKey( IntPtr Hwnd, int ID, int Modifiers, int Key );
		[DllImport( "user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true )]
		private static extern int UnregisterHotKey( IntPtr Hwnd, int ID );
		[DllImport( "kernel32", EntryPoint = "GlobalAddAtomA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true )]
		private static extern short GlobalAddAtom( string IDString );
		[DllImport( "kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true )]
		private static extern short GlobalDeleteAtom( short Atom );


		public class HotKeyObject {
			private Keys mHotKey;
			private MODKEY mModifier;
			private string mHotKeyID;
			private short mAtomID;

			public Keys HotKey {
				get { return mHotKey; }
				set { mHotKey = value; }
			}

			public MODKEY Modifier {
				get { return mModifier; }
				set { mModifier = value; }
			}

			public string HotKeyID {
				get { return mHotKeyID; }
				set { mHotKeyID = value; }
			}

			public short AtomID {
				get { return mAtomID; }
				set { mAtomID = value; }
			}

			public HotKeyObject( Keys NewHotKey, MODKEY NewModifier, string NewHotKeyID ) {
				mHotKey = NewHotKey;
				mModifier = NewModifier;
				mHotKeyID = NewHotKeyID;
			}
		}

		public Form OwnerForm {
			get { return mForm; }
			set { mForm = value; }
		}

		private Form mForm;
		private const int WM_HOTKEY = 786;
		private System.Collections.Generic.Dictionary<short, HotKeyObject> mHotKeyList = new System.Collections.Generic.Dictionary<short, HotKeyObject>();
		private System.Collections.Generic.Dictionary<string, short> mHotKeyIDList = new System.Collections.Generic.Dictionary<string, short>();

		/// <summary>
		/// Diesem Event wird immer die zugewiesene HotKeyID übergeben wenn eine HotKey Kombination gedrückt wurde.
		/// </summary>
		public event HotKeyPressedEventHandler HotKeyPressed;
		public delegate void HotKeyPressedEventHandler( string HotKeyID );

		public enum MODKEY : int {
			MOD_ALT = 1,
			MOD_CONTROL = 2,
			MOD_SHIFT = 4,
			MOD_WIN = 8
		}

		public HotKey() {
			Application.AddMessageFilter( this );
		}

		/// <summary>
		/// Diese Funktion fügt einen Hotkey hinzu und registriert ihn auch sofort
		/// </summary>
		/// <param name="KeyCode">Den KeyCode für die Taste</param>
		/// <param name="Modifiers">Die Zusatztasten wie z.B. Strg oder Alt, diese können auch mit OR kombiniert werden</param>
		/// <param name="HotKeyID">Die ID die der Hotkey bekommen soll um diesen zu identifizieren</param>
		public void AddHotKey( Keys KeyCode, MODKEY Modifiers, string HotKeyID ) {
			if( mHotKeyIDList.ContainsKey( HotKeyID ) == true )
				return; // TODO: might not be correct. Was : Exit Sub

			short ID = GlobalAddAtom( HotKeyID );
			mHotKeyIDList.Add( HotKeyID, ID );
			mHotKeyList.Add( ID, new HotKeyObject( KeyCode, Modifiers, HotKeyID ) );
			RegisterHotKey( mForm.Handle, (int)ID, (int)mHotKeyList[ ID ].Modifier, (int)mHotKeyList[ ID ].HotKey );
		}

		/// <summary>
		/// Diese Funktion entfernt einen Hotkey und deregistriert ihn auch sofort
		/// </summary>
		/// <param name="HotKeyID">Gibt die HotkeyID an welche entfernt werden soll</param>
		public void RemoveHotKey( string HotKeyID ) {
			if( mHotKeyIDList.ContainsKey( HotKeyID ) == false )
				return; // TODO: might not be correct. Was : Exit Sub

			short ID = mHotKeyIDList[ HotKeyID ];
			mHotKeyIDList.Remove( HotKeyID );
			mHotKeyList.Remove( ID );
			UnregisterHotKey( mForm.Handle, (int)ID );
			GlobalDeleteAtom( ID );
		}

		/// <summary>
		/// Diese Routine entfernt und Deregistriert alle Hotkeys
		/// </summary>
		public void RemoveAllHotKeys() {
			List<string> IDList = new List<string>();
			foreach( KeyValuePair<string, short> KVP in mHotKeyIDList ) {
				IDList.Add( KVP.Key );
			}

			for( int i = 0; i <= IDList.Count - 1; i++ ) 
				RemoveHotKey( IDList[ i ] );
		}

		public bool PreFilterMessage( ref Message m ) {
			if( m.Msg == WM_HOTKEY ) {
				if( HotKeyPressed != null ) {
					HotKeyPressed( mHotKeyList[ (short)m.WParam ].HotKeyID );
				}
			}
			return false;
		}

	}

}