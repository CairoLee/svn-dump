using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using GodLesZ.Library.Network;

namespace GodLesZ.FunRO.Patcher.Patches {

	public delegate void OnDownloadProgressHandler(ClientPatch patch, System.Net.DownloadProgressChangedEventArgs args);
	public delegate void OnDownloadFinishHandler(ClientPatch patch, bool cancel);

	public class ClientPatch {

		[XmlAttribute]
		public int ID = 0;
		[XmlAttribute]
		public string Name = "";
		[XmlAttribute]
		public string Displayname = "";
		[XmlAttribute]
		public string Target = "";
		[XmlAttribute]
		public EPatchAction Action = EPatchAction.None;

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
			if (Action == EPatchAction.DataDelete || Action == EPatchAction.GrfDelete) {
				return;
			}

			if (File.Exists(FilePath)) {
				File.Delete(FilePath);
			}
		}

		public void Download(OnDownloadProgressHandler ProgressEvent, OnDownloadFinishHandler FinishEvent) {
			OnDownloadProgress = ProgressEvent;
			OnDownloadFinish = FinishEvent;

			// Just delete a file
			if (this.Action == EPatchAction.DataDelete || this.Action == EPatchAction.GrfDelete) {
				if (OnDownloadFinish != null) {
					OnDownloadFinish(this, false);
				}
				return;
			}

			FilePath = Path.GetTempFileName();
			if (File.Exists(FilePath)) {
				File.Delete(FilePath);
			}


			TimeoutWebClient client = new TimeoutWebClient();
			client.BaseAddress = DownloadUrl;

			client.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(client_DownloadFileCompleted);
			client.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
			client.DownloadFileAsync(new Uri(DownloadUrl), FilePath, client);
		}

		private void client_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e) {
			if (OnDownloadProgress == null) {
				return;
			}
			OnDownloadProgress(this, e);
		}

		private void client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e) {
			if (OnDownloadFinish == null) {
				return;
			}
			OnDownloadFinish(this, (e.Cancelled || e.Error != null));
		}

	}

}
