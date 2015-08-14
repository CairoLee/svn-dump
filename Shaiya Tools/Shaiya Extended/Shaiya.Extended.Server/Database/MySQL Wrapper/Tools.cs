using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Shaiya.Extended.Server.MySql {

	public class Tools {

		public static string MysqlEscape( string Text ) {
			Text = Text.Replace( "\\", "\\\\" );
			Text = Text.Replace( "%", "\\%" );
			Text = Text.Replace( "\"", "\\\"" );

			return Text;
		}

	}

	public class HelperCrypt {
		private static string passPhrase = "Pas5pr@se";
		private static string saltValue = "s@1tValue";
		private static string hashAlgorithm = "SHA1";
		private static int passwordIterations = 2;
		private static string initVector = "@1B2c3D4e5F6g7H8";
		private static int keySize = 256;

		public static string Encrypt( string plainText ) {
			byte[] initVectorBytes = Encoding.ASCII.GetBytes( initVector );
			byte[] saltValueBytes = Encoding.ASCII.GetBytes( saltValue );
			byte[] plainTextBytes = Encoding.UTF8.GetBytes( plainText );

			PasswordDeriveBytes password = new PasswordDeriveBytes( passPhrase, saltValueBytes, hashAlgorithm, passwordIterations );

			byte[] keyBytes = password.GetBytes( keySize / 8 );

			RijndaelManaged symmetricKey = new RijndaelManaged();
			symmetricKey.Mode = CipherMode.CBC;
			ICryptoTransform encryptor = symmetricKey.CreateEncryptor( keyBytes, initVectorBytes );

			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream( memoryStream, encryptor, CryptoStreamMode.Write );

			cryptoStream.Write( plainTextBytes, 0, plainTextBytes.Length );
			cryptoStream.FlushFinalBlock();

			byte[] cipherTextBytes = memoryStream.ToArray();

			memoryStream.Close();
			cryptoStream.Close();

			return Convert.ToBase64String( cipherTextBytes );
		}

		public static string Decrypt( string cipherText ) {
			byte[] initVectorBytes = Encoding.ASCII.GetBytes( initVector );
			byte[] saltValueBytes = Encoding.ASCII.GetBytes( saltValue );
			byte[] cipherTextBytes = Convert.FromBase64String( cipherText );

			PasswordDeriveBytes password = new PasswordDeriveBytes( passPhrase, saltValueBytes, hashAlgorithm, passwordIterations );

			byte[] keyBytes = password.GetBytes( keySize / 8 );

			RijndaelManaged symmetricKey = new RijndaelManaged();
			symmetricKey.Mode = CipherMode.CBC;
			ICryptoTransform decryptor = symmetricKey.CreateDecryptor( keyBytes, initVectorBytes );

			MemoryStream memoryStream = new MemoryStream( cipherTextBytes );
			CryptoStream cryptoStream = new CryptoStream( memoryStream, decryptor, CryptoStreamMode.Read );

			byte[] plainTextBytes = new byte[ cipherTextBytes.Length ];
			int decryptedByteCount = cryptoStream.Read( plainTextBytes, 0, plainTextBytes.Length );

			memoryStream.Close();
			cryptoStream.Close();

			return Encoding.UTF8.GetString( plainTextBytes, 0, decryptedByteCount );
		}

		public static string SHA1( string Text ) {
			ASCIIEncoding ascii = new ASCIIEncoding();
			byte[] HashValue, MessageBytes = ascii.GetBytes( Text );
			SHA1Managed SHhash = new SHA1Managed();
			string strHex = "";

			HashValue = SHhash.ComputeHash( MessageBytes );
			foreach( byte b in HashValue ) {
				strHex += String.Format( "{0:x2}", b );
			}

			return strHex;
		}

	}

}
