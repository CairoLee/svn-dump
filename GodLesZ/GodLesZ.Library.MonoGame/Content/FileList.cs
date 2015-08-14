using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace GodLesZ.Library.MonoGame.Content {

	/// <summary>List of XML files, containing ressources.</summary>
	[Serializable]
	[XmlRoot("FileList")]
	public class FileList : List<FileListEntry> {

		/// <summary>Gets or sets the filename of the file.</summary>
		///
		/// <value>The filename.</value>
		[XmlElement("Filename")]
		public string Filename {
			get;
			set;
		}

		/// <summary>Gets or sets the type of the file.</summary>
		///
		/// <value>The type of the file.</value>
		[XmlElement("FileType")]
		public EFileListType FileType {
			get;
			set;
		}

		/// <summary>Gets or sets the extensions each ressource file could have.</summary>
		///
		/// <value>The extensions.</value>
		[XmlElement("Extensions")]
		public IEnumerable<string> Extensions {
			get;
			set;
		}


		public FileList() {
			FileType = EFileListType.Other;
		}

		public FileList(string filename, IEnumerable<string> extensions)
			: this() {
			Filename = filename;
			Extensions = extensions;
		}


		/// <summary>
		/// Saves the current list in the current directory + "Content"
		/// </summary>
		public void Save() {
			const string basedir = @"Content\";
			Save(basedir);
		}

		/// <summary>
		/// Saves the current list in the given directory
		/// </summary>
		/// <param name="basedir"></param>
		public void Save(string basedir) {
			var filepath = Environment.CurrentDirectory;
			if (basedir.Length != 0) {
				filepath = Path.Combine(filepath, basedir);
			}
			filepath = Path.Combine(filepath, Filename + ".xml");
			if (File.Exists(filepath)) {
				File.Delete(filepath);
			}
			var xml = new XmlSerializer(typeof(FileList));
			using (FileStream fs = File.OpenWrite(filepath)) {
				xml.Serialize(fs, this);
			}
		}

		/// <summary>
		/// Searched the given sub directory for all extensions
		/// </summary>
		/// <param name="basedir"></param>
		public void SearchFiles(string basedir) {
			string filepath = Environment.CurrentDirectory;
			if (basedir.Length != 0) {
				filepath = Path.Combine(filepath, basedir);
			}

			SearchFiles(filepath, filepath);
		}


		private void SearchFiles(string baseFilepath, string basedir) {
			if (Directory.Exists(baseFilepath) == false) {
				return;
			}

			var files = new List<string>();
			foreach (string ext in Extensions) {
				files.AddRange(Directory.GetFiles(baseFilepath, "*." + ext));
			}

			foreach (string filepath in files) {
				// Remove basedir
				var tempName = filepath.Remove(0, basedir.Length);
				// Remove beginning slashes
				while (tempName.StartsWith("/") || tempName.StartsWith("\\")) {
					tempName = tempName.Remove(0, 1);
				}
				// Remove extensions
				var p = tempName.LastIndexOf('.');
				if (p != -1) {
					tempName = tempName.Substring(0, p);
				}
				Add(new FileListEntry(tempName, FileType));
			}

			// Subdir search
			string[] dirs = Directory.GetDirectories(baseFilepath);
			foreach (string subdir in dirs) {
				SearchFiles(subdir, basedir);
			}
		}

	}

}
