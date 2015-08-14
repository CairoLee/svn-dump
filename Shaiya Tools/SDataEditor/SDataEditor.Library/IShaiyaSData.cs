using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SDataEditor.Library {

	public class IShaiyaSData {
		public static Encoding Encoding = Encoding.GetEncoding( "ISO-8859-1" );

		protected string mFilename;
		protected byte[] mBuffer;
		protected int mIndex;

		public string Filename {
			get { return mFilename; }
			set { mFilename = value; }
		}

		public byte[] Buffer {
			get { return mBuffer; }
		}

		

		public IShaiyaSData( string Filename, bool OpenData ) {
			mFilename = Filename;
			if( OpenData == true )
				Open();
		}

		public IShaiyaSData( string Filename )
			: this( Filename, true ) {
		}

		public IShaiyaSData()
			: this( "", false ) {
		}



		public virtual void Open() {
			if( File.Exists( Filename ) == false )
				throw new Exception( "File not found" );

			mBuffer = File.ReadAllBytes( mFilename );
			mIndex = 0;
		}


		public virtual void Fill( DataGridView Grid ) {
			AddColumns( Grid );
			FillData( Grid );
		}

		public virtual void FillData( DataGridView Grid ) {
		}

		public virtual void AddColumns( DataGridView Grid ) {
		}




		#region Read Helper
		protected byte ReadByte( bool Increment ) {
			byte value = mBuffer[ mIndex ];
			if( Increment == true )
				mIndex++;
			return value;
		}
		protected byte ReadByte() {
			return ReadByte( true );
		}

		protected short ReadInt16( bool Increment ) {
			short value = BitConverter.ToInt16( mBuffer, mIndex );
			if( Increment == true )
				mIndex += 2;
			return value;
		}
		protected short ReadInt16() {
			return ReadInt16( true );
		}

		protected int ReadInt32( bool Increment ) {
			int value = BitConverter.ToInt32( mBuffer, mIndex );
			if( Increment == true )
				mIndex += 4;
			return value;
		}
		protected int ReadInt32() {
			return ReadInt32( true );
		}

		protected string ReadString( bool Increment ) {
			string value = "";
			int i = 0;
			char c = '\0';
			while( ( c = (char)mBuffer[ mIndex + i++ ] ) != '\0' ) 
				value += c;

			if( Increment )
				mIndex += i;
			return value;
		}
		protected string ReadString() {
			return ReadString( true );
		}

		protected string ReadString( int Size, bool Increment ) {
			string value = "";
			int i = 0;
			char c = '\0';
			while( i < Size && ( c = (char)mBuffer[ mIndex + i++ ] ) != '\0' ) 
				value += c;

			if( Increment )
				mIndex += i;
			return value;
		}
		protected string ReadString( int Size ) {
			return ReadString( Size, true );
		} 
		#endregion


		public string GetHex( byte b ) {
			int shi = b / 0x10;
			int num2 = b - ( shi * 0x10 );
			return ( this.GetHexPart( shi ) + this.GetHexPart( num2 ) );
		}

		public string GetHexPart( int shi ) {
			if( shi < 10 )
				return shi.ToString();

			switch( shi ) {
				case 10:
					return "A";

				case 11:
					return "B";

				case 12:
					return "C";

				case 13:
					return "D";

				case 14:
					return "E";

				case 15:
					return "F";
			}
			return "";
		}


	}

}
