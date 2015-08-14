using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;

namespace Updater.Library {

	public class UpdateHandler {
		public static string VersionFileName = "_appVersion.xml";
		public static string UpdaterFileName = "_update.exe";

		public static string VersionFilePath {
			get { return Path.Combine( AppDomain.CurrentDomain.BaseDirectory, VersionFileName ); }
		}
		public static string UpdaterFilePath {
			get { return Path.Combine( AppDomain.CurrentDomain.BaseDirectory, UpdaterFileName ); }
		}

		private SVersionFile mVersionFile;
		private string mUrl;


		public UpdateHandler() {
			CleanUp();
		}

		public bool CheckVersion( Assembly Asm, string Url ) {
			mUrl = Url;
			CleanUp();

			DownloadVersionfile();
			if( mVersionFile == null ) {
				CleanUp();
				return false;
			}

			if( VersionHelper.ToInt( new Version( mVersionFile.Version ) ) <= VersionHelper.ToInt( Asm.GetName().Version ) ) {
				CleanUp();
				return false;
			}

			return true;
		}

		public static void CleanUp() {
			if( File.Exists( VersionFileName ) )
				try { File.Delete( VersionFileName ); } catch { }
			if( File.Exists( UpdaterFileName ) )
				try { File.Delete( UpdaterFileName ); } catch { }
		}

		public bool StartUpdate() {
			if( DownloadUpdaterExe() == false ) {
				CleanUp();
				return false;
			}

			System.Diagnostics.Process.Start( UpdaterFilePath );
			return true;
		}



		private void DownloadVersionfile() {
			string fileUrl = Path.Combine( mUrl, VersionFileName );
			if( DownloadFile( fileUrl, VersionFilePath ) == true ) {
				XmlSerializer xml = new XmlSerializer( typeof( SVersionFile ) );
				using( FileStream fs = File.OpenRead( VersionFilePath ) )
					mVersionFile = xml.Deserialize( fs ) as SVersionFile;

				return;
			}

			mVersionFile = null;
		}
		private bool DownloadUpdaterExe() {
			string fileUrl = Path.Combine( mUrl, UpdaterFileName );
			return DownloadFile( fileUrl, UpdaterFilePath );
		}

		private bool DownloadFile( string Url, string SavePath ) {
			try {
				TimeoutWebClient client = new TimeoutWebClient();
				client.TimeOut = 5000;
				client.DownloadFile( Url, SavePath );

				return true;
			} catch( Exception e ) {
				System.Diagnostics.Debug.WriteLine( e );
				return false;
			}

		}

	}

	public static class VersionHelper {
		public static int ToInt( Version version ) {
			long longVesion = version.Major * 100000000L + version.Minor * 1000000L + version.Build * 100L + version.Revision;
			return (int)longVesion;
		}
	}


}
