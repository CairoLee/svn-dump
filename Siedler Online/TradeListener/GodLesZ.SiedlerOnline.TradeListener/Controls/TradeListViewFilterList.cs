using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using GodLesZ.Library.Controls;

namespace GodLesZ.SiedlerOnline.TradeListener.Controls {

	public class TradeListViewFilterList : IList<TradeListViewFilter>, IModelFilter {
		private bool mIsChanged = false;

		public static string Extension {
			get { return "tfp"; }
		}

		public static string ProfileFolder {
			get { return Path.Combine(Environment.CurrentDirectory, "Profiles"); }
		}

		private List<TradeListViewFilter> mFilter;

		public bool IsChanged {
			get { return mIsChanged; }
			protected set { mIsChanged = value; }
		}

		public string Filepath {
			get;
			protected set;
		}


		public TradeListViewFilter this[int index] {
			get { return mFilter[index]; }
			set { mFilter[index] = value; }
		}

		public int Count {
			get { return mFilter.Count; }
		}

		public bool IsReadOnly {
			get { return false; }
		}


		public TradeListViewFilterList()
			: this(null) {
		}

		public TradeListViewFilterList(string filepath) {
			mFilter = new List<TradeListViewFilter>();
			IsChanged = false;

			if (string.IsNullOrEmpty(filepath) == false) {
				Filepath = filepath;
			}
		}


		public bool Filter(object modelObject) {
			DsoTrade trade = (modelObject as DsoTrade);
			if (trade == null) {
				return false;
			}

			foreach (TradeListViewFilter filter in this) {
				if (filter.Filter(trade) == false) {
					return false;
				}
			}

			// All filter passed
			return true;
		}


		public static string[] GetProfiles() {
			string basedir = ProfileFolder;
			if (Directory.Exists(basedir) == false) {
				try {
					Directory.CreateDirectory(basedir);
				} catch {
					MessageBox.Show("Failed to create profiles directory!\nPlease restart the application using admin rights.", "Profile load error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return null;
				}
			}

			string[] files = Directory.GetFiles(basedir, "*." + Extension);
			// Prevent to return "null"
			// Note: "null" means Error, not "nothing found"
			if (files == null) {
				return new string[0];
			}
			return files;
		}

		public static TradeListViewFilterList Read(string filepath) {
			TradeListViewFilterList list;
			try {
				XmlSerializer xml = new XmlSerializer(typeof(TradeListViewFilterList));
				using (FileStream fs = File.Open(filepath, FileMode.OpenOrCreate)) {
					list = (TradeListViewFilterList)xml.Deserialize(fs);
				}
				list.Filepath = filepath;
				list.IsChanged = false;
			} catch (Exception ex) {
				return null;
			}

			return list;
		}


		public bool Load(string filepath) {
			TradeListViewFilterList list = Read(filepath);
			if (list == null) {
				return false;
			}

			// Add each filter
			foreach (var entry in list) {
				Add(entry);
			}
			Filepath = list.Filepath;
			IsChanged = false;

			return true;
		}

		public void Save() {
			Save(false);
		}

		public void Save(bool forceNewName) {
			if (forceNewName || string.IsNullOrEmpty(Filepath)) {
				using (SaveFileDialog dlg = new SaveFileDialog()) {
					dlg.Filter = "Trade Filter Profile (*." + Extension + ")|*." + Extension;
					dlg.InitialDirectory = ProfileFolder;
					// Set old filename as default, if given
					if (string.IsNullOrEmpty(Filepath) == false) {
						string filename = Path.GetFileNameWithoutExtension(Filepath);
						dlg.FileName = filename;
					}
					if (dlg.ShowDialog() != DialogResult.OK) {
						return;
					}

					Filepath = dlg.FileName;
				}
			}

			if (File.Exists(Filepath)) {
				File.Delete(Filepath);
			}

			XmlSerializer xml = new XmlSerializer(GetType());
			using (FileStream fs = File.Open(Filepath, FileMode.OpenOrCreate)) {
				fs.SetLength(0);
				xml.Serialize(fs, this);
			}

			IsChanged = false;
		}


		public int IndexOf(TradeListViewFilter item) {
			return mFilter.IndexOf(item);
		}

		public void Insert(int index, TradeListViewFilter item) {
			IsChanged = true;
			mFilter.Insert(index, item);
		}

		public void RemoveAt(int index) {
			IsChanged = true;
			mFilter.RemoveAt(index);
		}

		public void Add(TradeListViewFilter item) {
			IsChanged = true;
			mFilter.Add(item);
		}

		public void Clear() {
			IsChanged = true;
			mFilter.Clear();
		}

		public bool Contains(TradeListViewFilter item) {
			return mFilter.Contains(item);
		}

		public void CopyTo(TradeListViewFilter[] array, int arrayIndex) {
			mFilter.CopyTo(array, arrayIndex);
		}

		public bool Remove(TradeListViewFilter item) {
			bool result = mFilter.Remove(item);
			if (result) {
				IsChanged = true;
			}
			return result;
		}

		public IEnumerator<TradeListViewFilter> GetEnumerator() {
			return mFilter.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
			return mFilter.GetEnumerator();
		}

	}

}