using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace GodLesZ.SiedlerOnline.TradeListener.Library {

	[XmlRoot("AvgStatistics")]
	public class AverageStorage {
		private Dictionary<string, AverageCounter> mStorage;

		[XmlIgnore]
		public Dictionary<string, AverageCounter> Storage {
			get { return mStorage; }
		}

		[XmlArray("Storage")]
		[XmlArrayItem("Entry", Type = typeof(AverageCounter))]
		public AverageCounter[] _Storage {
			get {
				AverageCounter[] stor = new AverageCounter[Storage.Count];
				int i = 0;
				foreach (var kvp in Storage) {
					stor[i++] = kvp.Value;
				}
				return stor;
			}
			set {
				Storage.Clear();
				if (value == null || value.Length == 0) {
					return;
				}

				foreach (var entry in value) {
					Storage.Add(AverageCounter.GetKey(entry.Resource, entry.ResourceDemanded), entry);
				}
			}
		}

		[XmlAttribute]
		public double HistoricalFactor {
			get;
			set;
		}

		[XmlAttribute]
		public double LowerBoundaryExclusive {
			get;
			set;
		}

		[XmlAttribute]
		public double UpperBoundaryExclusive {
			get;
			set;
		}

		public AverageStorage() {
			mStorage = new Dictionary<string, AverageCounter>();
			HistoricalFactor = 0.95;
			LowerBoundaryExclusive = 0.001 - double.Epsilon;
			UpperBoundaryExclusive = double.PositiveInfinity;
		}

		public double CountAverage(EResource res, EResource resDemanded, double Value) {
			string key = AverageCounter.GetKey(res, resDemanded);
			if (!Storage.ContainsKey(key)) {
				Storage.Add(key, new AverageCounter(res, resDemanded));
			}
			return Storage[key].Add(Value, UpperBoundaryExclusive, LowerBoundaryExclusive, HistoricalFactor);
		}

		public AverageCounter GetAverage(EResource res, EResource resDemanded) {
			string key = AverageCounter.GetKey(res, resDemanded);
			if (Storage.ContainsKey(key)) {
				return Storage[key];
			}
			return null;
		}

		public List<AverageCounter> GetSortedStorage(EResource res, bool asDemanded) {
			List<AverageCounter> list = new List<AverageCounter>();
			Array resourceValues = Enum.GetValues(typeof(EResource));
			foreach (var entry in resourceValues) {
				EResource resDemanded = (EResource)entry;
				AverageCounter avg = (asDemanded == false ? GetAverage(res, resDemanded) : GetAverage(resDemanded, res));
				if (avg != null) {
					list.Add(avg);
				}
			}

			list.Sort(delegate(AverageCounter a, AverageCounter b) {
				return a.Value.CompareTo(b.Value);
			});
			// Reverse sorting only if we need the demanded resources
			if (asDemanded == true) {
				list.Reverse();
			}
			return list;
		}


		public static EAverageStorageLoadResult Load(out AverageStorage storage) {
			storage = null;

			try {
				string filepath = Path.Combine(Environment.CurrentDirectory, "Statistics.xml");
				if (File.Exists(filepath) == false) {
					return EAverageStorageLoadResult.FailedNotFound;
				}

				XmlSerializer xml = new XmlSerializer(typeof(AverageStorage));
				using (FileStream fs = File.OpenRead(filepath)) {
					storage = (AverageStorage)xml.Deserialize(fs);
				}
			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine(ex);
				storage = null;

				return EAverageStorageLoadResult.FailedException;
			}

			return EAverageStorageLoadResult.Success;
		}

	}

}

