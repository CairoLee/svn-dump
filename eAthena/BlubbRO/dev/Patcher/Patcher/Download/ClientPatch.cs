using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using GodLesZ.Library.AutoUpdater.Library;

namespace GodLesZ.BlubbRO.Patcher.Download {

	public delegate void OnDownloadProgressHandler( ClientPatch Patch, System.Net.DownloadProgressChangedEventArgs Args );
	public delegate void OnDownloadFinishHandler( ClientPatch Patch, bool Cancle );

	public class ClientPatch {
		[XmlAttribute]
		public int PatchID = 0;
		[XmlAttribute]
		public string PatchName = "";
		[XmlAttribute]
		public string PatchDisplayname = "";
		[XmlAttribute]
		public string Target = "";
		[XmlAttribute]
		public EPatchAction PatchAction = EPatchAction.None;
		[XmlIgnore]
		public string DownloadUrl = "";
		[XmlIgnore]
		public string FilePath = "";
		[XmlIgnore]
		public OnDownloadProgressHandler OnDownloadProgress;
		[XmlIgnore]
		public OnDownloadFinishHandler OnDownloadFinish;



		public ClientPatch() {
		}


		public void Delete() {
			if( PatchAction == EPatchAction.DataDelete || PatchAction == EPatchAction.GrfDelete )
				return;

			if( File.Exists( FilePath ) )
				File.Delete( FilePath );
		}

		public void Download( OnDownloadProgressHandler ProgressEvent, OnDownloadFinishHandler FinishEvent ) {
			OnDownloadProgress = ProgressEvent;
			OnDownloadFinish = FinishEvent;

			// just Delete a File
			if( this.PatchAction == EPatchAction.DataDelete || this.PatchAction == EPatchAction.GrfDelete ) {
				if( OnDownloadFinish != null )
					OnDownloadFinish( this, false );
				return;
			}

			FilePath = Path.GetTempFileName();
			if( File.Exists( FilePath ) )
				File.Delete( FilePath );


			TimeoutWebClient client = new TimeoutWebClient();
			client.BaseAddress = DownloadUrl;

			client.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler( client_DownloadFileCompleted );
			client.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler( client_DownloadProgressChanged );
			client.DownloadFileAsync( new Uri( DownloadUrl ), FilePath, client );
		}

		private void client_DownloadProgressChanged( object sender, System.Net.DownloadProgressChangedEventArgs e ) {
			if( OnDownloadProgress == null )
				return;
			OnDownloadProgress( this, e );
		}

		private void client_DownloadFileCompleted( object sender, System.ComponentModel.AsyncCompletedEventArgs e ) {
			if( OnDownloadFinish == null )
				return;
			OnDownloadFinish( this, ( e.Cancelled || e.Error != null ) );
		}

	}

}
