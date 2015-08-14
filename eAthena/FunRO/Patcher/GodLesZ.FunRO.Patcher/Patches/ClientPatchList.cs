using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using GodLesZ.Library.Network;

namespace GodLesZ.FunRO.Patcher.Patches {

	public delegate void PatchProgressCompleteHandler();

	public class ClientPatchList : List<ClientPatch> {
		private TimeoutWebClient mClient = new TimeoutWebClient();
		private string mPatchListPath = "";
		private string mPatchListUrl = "";

		public event PatchProgressCompleteHandler OnPatchProgressComplete;


		public void Download(string Url) {
			mPatchListUrl = Url.Substring(0, Url.LastIndexOf('/') + 1);
			mPatchListPath = Path.GetTempFileName();

			mClient.BaseAddress = Url;
			mClient.TimeOut = 2000;
			mClient.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(CLient_DownloadFileCompleted);
			mClient.DownloadFileAsync(new Uri(Url), mPatchListPath);
		}


		private void CLient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e) {
			if (e.Error != null) {
				System.Diagnostics.Debug.WriteLine("failed to fetch Patchlist.... wtf? oO");
				Clear();

				OnPatchProgressComplete();
				return;
			}

			Read();
			OnPatchProgressComplete();
		}

		private void Read() {
			var list = new ClientPatchList();

			using (FileStream fs = File.OpenRead(mPatchListPath)) {
				XmlSerializer xml = new XmlSerializer(GetType());
				list = (ClientPatchList)xml.Deserialize(fs);
			}

			// Add ach patch in the list
			for (int i = 0; i < list.Count; i++) {
				// Build absolute url
				list[i].DownloadUrl = mPatchListUrl + list[i].Name;
				Add(list[i]);
			}

			list = null;
		}


	}

}
