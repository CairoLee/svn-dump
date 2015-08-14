using System;
using System.Collections.Generic;
using System.IO;
using GodLesZ.Library.Ragnarok.Grf;

namespace GodLesZ.FunRO.Patcher {

	public class GrfHelper {
		public static Dictionary<string, RoGrfFile> GrfList = new Dictionary<string, RoGrfFile>(); // static Cache


		public static RoGrfFile GrfFromCache(string GrfName, string GrfPath) {
			bool contains = GrfList.ContainsKey(GrfName);
			if (contains == false && File.Exists(GrfPath) == false)
				throw new Exception("GRF not in Cache & GrfPath can not be found! Path: " + GrfPath);

			if (contains == false)
				GrfList.Add(GrfName, new RoGrfFile(GrfPath));

			return GrfList[GrfName];
		}



		public static void DeleteFromGrf(string GrfName, string Filename) {
			RoGrfFile cachedGrf = GrfFromCache(GrfName, "");
			string[] searchParts = Filename.Split(':');
			int maxDeleteCount = cachedGrf.Files.Count;

			Filename = "data/" + searchParts[0].Trim();
			if (searchParts.Length > 1) {
				if (int.TryParse(searchParts[1], out maxDeleteCount) == false)
					maxDeleteCount = cachedGrf.Files.Count;
			}

			int deleted = 0;
			string fIndex = null;
			while ((fIndex = cachedGrf.ContainsFilepart(Filename)) != null) {
				cachedGrf.DeleteFile(fIndex);
				if (maxDeleteCount > 0 && ++deleted >= maxDeleteCount) {
					break;
				}
			}
		}

		public static void MergeGrf(string GrfName, string Filepath) {
			RoGrfFile cachedGrf = GrfFromCache(GrfName, "");
			RoGrfFile tmpGrf = new RoGrfFile(Filepath);
			foreach (var grfFile in tmpGrf.Files.Values) {
				tmpGrf.CacheFileData(grfFile);
				cachedGrf.AddFile(grfFile);
			}
			tmpGrf.Flush(); // close it!
		}


	}

}
