using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeWorld.Engine.WindowLibrary {

	[Serializable]
	public class ControlCollection : ICollection {
		public ArrayList Controls = new ArrayList();
		public Control TopControl;
		
		public Control this[ string name ] {
			get { return GetElement( name ); }
		}
		public Control this[ int index ] {
			get { return Controls[ index ] as Control; }
			set { Controls[ index ] = value; }
		}

		public int Count {
			get { return Controls.Count; }
		}

		public bool IsSynchronized {
			get { return false; }
		}

		public object SyncRoot {
			get { return this; }
		}



		public ControlCollection() {
		}



		public void CopyTo( Array array, int index ) {
			Controls.CopyTo( array, index );
		}

		public IEnumerator GetEnumerator() {
			return Controls.GetEnumerator();
		}

		public void Add( Control element ) {
			if( this[ element.Name ] != null )
				Remove( element );
			Controls.Add( element );
		}

		public void Remove( Control element ) {
			Controls.Remove( element );
		}

		public void RemoveAt( int Key ) {
			Controls.RemoveAt( Key );
		}

		public void Clear() {
			Controls.Clear();
		}

		[XmlInclude( typeof( Button ) )]
		[XmlInclude( typeof( Checkbox ) )]
		[XmlInclude( typeof( ComboBox ) )]
		[XmlInclude( typeof( ImageBox ) )]
		[XmlInclude( typeof( Label ) )]
		[XmlInclude( typeof( Listbox ) )]
		[XmlInclude( typeof( Progressbar ) )]
		[XmlInclude( typeof( RadioButton ) )]
		[XmlInclude( typeof( Scrollbar ) )]
		[XmlInclude( typeof( Slider ) )]
		[XmlInclude( typeof( Textbox ) )]
		[XmlInclude( typeof( TextButton ) )]
		public Control GetElement( string name ) {
			foreach( Control c in Controls ) {
				if( c.Name == name )
					return c;
			}

			return null;
		}

		public void Update( GameTime gameTime, Vector2 formPosition, Vector2 formSize ) {
			foreach( Control thisControl in Controls )
				if( thisControl != null )
					thisControl.Update( gameTime, formPosition, formSize );
		}

		public void Draw( SpriteBatch windowBatch, float alpha ) {
			foreach( Control thisControl in Controls )
				if( thisControl != null && thisControl.Visible )
					if( TopControl == null || thisControl != TopControl )
						thisControl.Draw( windowBatch, alpha );

			if( TopControl != null )
				TopControl.Draw( windowBatch, alpha );
		}

	}
}
