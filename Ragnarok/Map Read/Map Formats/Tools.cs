using System;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Map_Formats {

	public class Tools {
		public static string ReadWord( BinaryReader bin, int max ) {
			StringBuilder sb = new StringBuilder();

			while( sb.Length < max && bin.BaseStream.CanRead == true && bin.PeekChar() != '\0' )
				sb.Append( bin.ReadChar() );

			bin.BaseStream.Position += ( max - sb.Length );
			return sb.ToString();
		}

		public static Vector2 ReadVector2( BinaryReader bin ) {
			if( ( bin.BaseStream.Length - bin.BaseStream.Position ) < 6 )
				return Vector2.Zero;

			Vector2 vec = new Vector2(
				bin.ReadSingle(),
				bin.ReadSingle()
			);

			return vec;
		}

		public static Vector3 ReadVector3( BinaryReader bin ) {
			if( ( bin.BaseStream.Length - bin.BaseStream.Position ) < 9 )
				return Vector3.Zero;

			Vector3 vec = new Vector3(
				bin.ReadSingle(),
				bin.ReadSingle(),
				bin.ReadSingle()
			);

			return vec;
		}

		public static Vector4 ReadVector4( BinaryReader bin ) {
			if( ( bin.BaseStream.Length - bin.BaseStream.Position ) < 12 )
				return Vector4.Zero;

			Vector4 vec = new Vector4(
				bin.ReadSingle(),
				bin.ReadSingle(),
				bin.ReadSingle(),
				bin.ReadSingle()
			);

			return vec;
		}
	}

	public class Convert {

		public static T Parse<T>( string input ) {
			try {
				return (T)Enum.Parse( typeof( T ), input );
			} catch {
				return default( T );
			}
		}

		public static Texture2D Image2Texture( System.Drawing.Bitmap Image, GraphicsDevice g ) {
			Texture2D Texture = null;
			try {
				using( System.IO.MemoryStream ms = new System.IO.MemoryStream() ) {
					Image.Save( ms, System.Drawing.Imaging.ImageFormat.Png );
					ms.Seek( 0, 0 );
					Texture = Texture2D.FromFile( g, ms ) as Texture2D;
				}
			} catch { }

			return Texture;
		}
	}
}
