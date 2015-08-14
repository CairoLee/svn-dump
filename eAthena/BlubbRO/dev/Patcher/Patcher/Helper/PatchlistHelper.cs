using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using GodLesZ.Library.AutoUpdater.Library;

namespace GodLesZ.BlubbRO.Patcher.Download {

	public delegate void PatchProgressCompleteHandler();

	public class PatchlistHelper {
		public static List<ClientPatch> Patches = new List<ClientPatch>();
		public static PatchProgressCompleteHandler OnPatchProgressComplete;

		private static TimeoutWebClient mClient = new TimeoutWebClient();
		private static string PatchListPath = "";
		private static string PatchListUrl = "";


		public static void Download(string Url) {
			PatchListUrl = Url.Substring(0, Url.LastIndexOf('/') + 1);
			PatchListPath = Path.GetTempFileName();

			mClient.BaseAddress = Url;
			mClient.TimeOut = 2000;
			mClient.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(mCLient_DownloadFileCompleted);
			mClient.DownloadFileAsync(new Uri(Url), PatchListPath);
		}

		private static void mCLient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e) {
			if (e.Error != null) {
				System.Diagnostics.Debug.WriteLine("failed to fetch Patchlist.... and now? oO");
				Patches.Clear();

				OnPatchProgressComplete();
				return;
			}

			Read();
			OnPatchProgressComplete();
		}

		private static void Read() {
			using (FileStream fs = File.OpenRead(PatchListPath)) {
				XmlSerializer xml = new XmlSerializer(Patches.GetType());
				Patches = (List<ClientPatch>)xml.Deserialize(fs);
			}

			for (int i = 0; i < Patches.Count; i++)
				Patches[i].DownloadUrl = PatchListUrl + Patches[i].PatchName;
		}

	}





}
