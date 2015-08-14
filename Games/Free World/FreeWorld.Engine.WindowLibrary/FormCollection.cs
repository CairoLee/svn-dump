using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using FreeWorld.Engine;

namespace FreeWorld.Engine.WindowLibrary {

	[Serializable]
	[XmlInclude( typeof( Form ) )]
	public class FormCollection {
		private static string mBaseDir;
		private ArrayList mForms = new ArrayList();
		private Vector2 mScreenSize = Vector2.Zero;
		private bool mSaveOnExit = true;
		private string mName;
		private bool Saved = false;
		private static XmlSerializer mXml = new XmlSerializer( typeof( FormCollection ) );


		public Form this[ string title ] {
			get { return Find( title ); }
		}
		public Form this[ int index ] {
			get {
				if( index < 0 || index > Forms.Count - 1 )
					return null;
				return Forms[ index ] as Form;
			}
		}

		public ArrayList Forms {
			get { return mForms; }
			set { mForms = value; }
		}

		public int Count {
			get { return mForms.Count; }
		}

		[XmlElement( ElementName = "SaveOnExit" )]
		public bool SaveOnExit {
			get { return mSaveOnExit; }
			set { mSaveOnExit = value; }
		}

		[XmlElement( ElementName = "Name" )]
		public string Name {
			get { return mName; }
			set { mName = value; }
		}

		[XmlIgnore]
		public static string BaseDir {
			get { return mBaseDir; }
			set { mBaseDir = value; }
		}






		public FormCollection( string name ) {
			mScreenSize = new Vector2( Constants.GraphicsDevice.Viewport.Width, Constants.GraphicsDevice.Viewport.Height );
			mName = name;
		}

		public FormCollection()
			: this( "" ) {
			mName = "Collection " + mForms.Count;
		}



		public IEnumerator GetEnumerator() {
			return mForms.GetEnumerator();
		}

		public void CopyTo( Array array, int index ) {
			mForms.CopyTo( array, index );
		}

		public void Add( Form form ) {
			form.Owner = this;
			mForms.Add( form );
		}

		public Form Find( string name ) {
			foreach( Form thisForm in mForms )
				if( thisForm.FormTitle == name )
					return thisForm;

			return null;
		}

		public bool Exist( string name ) {
			return Find( name ) != null;
		}

		public void Remove() {
			if( SaveOnExit == true && Saved == false )
				Save();

			Form[] forms = new Form[ mForms.Count ];
			CopyTo( forms, 0 );
			foreach( Form form in forms )
				Remove( form );
		}

		public void Remove( Form form ) {
			if( Form.TopForm != null && Form.TopForm.FormTitle == form.FormTitle )
				Form.TopForm = null;
			mForms.Remove( form );
		}

		public void Remove( string name ) {
			for( int i = 0; i < Forms.Count; i++ ) {
				if( ( mForms[ i ] as Form ).FormTitle == name ) {
					if( Form.TopForm != null && Form.TopForm.FormTitle == ( mForms[ i ] as Form ).FormTitle )
						Form.TopForm = null;
					mForms.RemoveAt( i );
					return;
				}
			}
		}

		public void Update( GameTime gameTime ) {
			if( mForms != null && mForms.Count > 0 ) {
				for( int i = 0; i < mForms.Count; i++ )
					if( mForms[ i ] != null && ( mForms[ i ] as Form ).Visible )
						( mForms[ i ] as Form ).Update( gameTime );
			}
		}

		public void Draw() {
			if( mForms != null && mForms.Count > 0 )
				for( int i = 0; i < mForms.Count; i++ )
					if( mForms[ i ] != null && ( mForms[ i ] as Form ).Visible )
						( mForms[ i ] as Form ).Draw();
		}

		public void Cascade() {
			Vector2 maxSize = new Vector2( mScreenSize.X - mForms.Count * 20f - 40f, mScreenSize.Y - mForms.Count * 20f - 40f );

			for( int i = 0; i < mForms.Count; i++ ) {
				Form frm = mForms[ i ] as Form;
				frm.FormState = EFormState.Restored;
				frm.FormPos = new Vector2( 30f * i, 30f * i );
				frm.FormSize = maxSize;
				frm.Redraw();
			}

		}

		public void FocusNextForm() {
			( mForms[ ( mForms.IndexOf( Form.TopForm ) + 1 ) % mForms.Count ] as Form ).SetFocus();
		}

		public void ShowAll() {
			for( int i = 0; i < mForms.Count; i++ )
				( mForms[ i ] as Form ).Show();
		}







		public void Save() {
			Save( mName );
		}

		public void Save( string Filename ) {
			if( Saved == true )
				return;
			if( Directory.Exists( BaseDir ) == false )
				Directory.CreateDirectory( BaseDir );

			string FilePath = Path.Combine( BaseDir, Filename + ".xml" );
			try {
				if( File.Exists( FilePath ) )
					File.Delete( FilePath );
				using( FileStream s = File.OpenWrite( FilePath ) )
					mXml.Serialize( s, this );
			} catch( Exception e ) {
				Debug.WriteLine( e );
			}
			Saved = true;
		}

		public static FormCollection Load( string Filename ) {
			FormCollection Collection = null;
			string FilePath = Path.Combine( BaseDir, Filename + ".xml" );
			if( File.Exists( FilePath ) == false )
				return Collection;

			try {
				XmlSerializer xml = new XmlSerializer( typeof( FormCollection ) );
				using( FileStream s = File.OpenRead( FilePath ) ) {
					Collection = xml.Deserialize( s ) as FormCollection;
					foreach( Form form in Collection ) {
						form.Initialize( ( form.FormTextureName != null && form.FormTextureName.Length > 0 ) );
						foreach( Control control in form.Controls ) {
							if( control.ControlTextureName != null && control.ControlTextureName != string.Empty )
								control.InitTextures( control.ControlTextureName );
							else
								control.InitTextures();
							control.InitDefaults();
							control.InitEvents();
						}
					}
				}
			} catch( Exception e ) {
				Debug.WriteLine( e );
				Collection = null;
			}

			return Collection;
		}

	}

}
