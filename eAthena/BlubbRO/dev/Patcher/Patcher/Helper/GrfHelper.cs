using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GodLesZ.Library.Ragnarok.Grf;


namespace GodLesZ.BlubbRO.Patcher {

	public class GrfHelper {
		public static Dictionary<string, GrfFile> GrfList = new Dictionary<string, GrfFile>(); // static Cache


		public static GrfFile GrfFromCache(string GrfName, string GrfPath) {
			bool contains = GrfList.ContainsKey(GrfName);
			if (contains == false && File.Exists(GrfPath) == false) {
				throw new Exception("GRF not in Cache & GrfPath can not be found! Path: " + GrfPath);
			}
			if (contains == false) {
				GrfList.Add(GrfName, new GrfFile(GrfPath));
			}

			return GrfList[GrfName];
		}



		public static void DeleteFromGrf(string GrfName, string Filename) {
			GrfFile cachedGrf = GrfFromCache(GrfName, "");
			string[] searchParts = Filename.Split(':');
			int maxDeleteCount = cachedGrf.Files.Count;

			Filename = "data/" + searchParts[0].Trim();
			if (searchParts.Length > 1) {
				if (int.TryParse(searchParts[1], out maxDeleteCount) == false) {
					maxDeleteCount = cachedGrf.Files.Count;
				}
			}

			string fIndex = "";
			int deleted = 0;
			while ((fIndex = cachedGrf.ContainsFilepart(Filename)) != null) {
				cachedGrf.DeleteFile(fIndex);
				if (maxDeleteCount > 0 && ++deleted >= maxDeleteCount) {
					break;
				}
			}
		}

		public static void MergeGrf(string GrfName, string Filepath) {
			GrfFile cachedGrf = GrfFromCache(GrfName, "");
			GrfFile tmpGrf = new GrfFile(Filepath);
			for (int i = 0; i < tmpGrf.Files.Count; i++) {
				tmpGrf.CacheFileData(tmpGrf.GetFileByIndex(i)); // force to load File data
				cachedGrf.AddFile(tmpGrf.GetFileByIndex(i));
			}
			tmpGrf.Flush(); // close it!
		}


	}

}
