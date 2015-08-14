using System;
using System.IO;
using System.Xml.Serialization;

namespace GodLesZ.Library.MonoGame.Content {

	public class FileListLoader : Singleton<FileListLoader> {

		private FileList mMaps = new FileList("bMaps", new[] { "bmap" });
		private FileList mCharacterList = new FileList("Characters", new[] { "png", "jpg" });
		private FileList mTilesetList = new FileList("Tilesets", new[] { "png", "jpg" });
		private FileList mAnimations = new FileList("bAnimations", new[] { "bani" });
		private FileList mAnimationTilesets = new FileList("AnimationTilesets", new[] { "png", "jpg" });
		private FileList mAutotiles = new FileList("Autotiles", new[] { "png", "jpg" });
		private FileList mFogs = new FileList("Fogs", new[] { "png", "jpg" });

		public FileList Maps {
			get {
				if (mMaps.Count == 0)
					LoadList(ref mMaps, false);
				return mMaps;
			}
			protected set { mMaps = value; }
		}

		public FileList Characters {
			get {
				if (mCharacterList.Count == 0)
					LoadList(ref mCharacterList, false);
				return mCharacterList;
			}
			protected set { mCharacterList = value; }
		}

		public FileList Tilesets {
			get {
				if (mTilesetList.Count == 0)
					LoadList(ref mTilesetList, false);
				return mTilesetList;
			}
			protected set { mTilesetList = value; }
		}

		public FileList Autotiles {
			get {
				if (mAutotiles.Count == 0)
					LoadList(ref mAutotiles, false);
				return mAutotiles;
			}
			protected set { mAutotiles = value; }
		}

		public FileList AnimationTilesets {
			get {
				if (mAnimationTilesets.Count == 0)
					LoadList(ref mAnimationTilesets, false);
				return mAnimationTilesets;
			}
			protected set { mAnimationTilesets = value; }
		}

		public FileList Animations {
			get {
				if (mAnimations.Count == 0)
					LoadList(ref mAnimations, false);
				return mAnimations;
			}
			protected set { mAnimations = value; }
		}

		public FileList Fogs {
			get {
				if (mFogs.Count == 0)
					LoadList(ref mFogs, false);
				return mFogs;
			}
			protected set { mFogs = value; }
		}


		public virtual void LoadLists(bool reload) {
			LoadList(ref mMaps, reload);
			LoadList(ref mCharacterList, reload);
			LoadList(ref mTilesetList, reload);
			LoadList(ref mAnimations, reload);
			LoadList(ref mAutotiles, reload);
			LoadList(ref mAnimationTilesets, reload);
			LoadList(ref mFogs, reload);
		}


		protected virtual void LoadList(ref FileList fileList, bool reload) {
			// No forced Reload, no need to reload the Content
			if (reload == false && fileList.Count > 0) {
				return; 
			}

			if (reload) {
				// TODO: how to get the content folder path relative to the execution path?
				// Search in "Content\<Type>\" 
				fileList.SearchFiles(@"Content\" + fileList.Filename);
				fileList.Save("Content");
				return;
			}

			var xml = new XmlSerializer(typeof(FileList));
			var filepath = AppDomain.CurrentDomain.BaseDirectory + @"Content\" + fileList.Filename + ".xml";

			// first call from Engine?
			if (File.Exists(filepath) == false) {
				return;
			}

			using (FileStream fs = File.OpenRead(filepath)) {
				var list = xml.Deserialize(fs) as FileList;

				if (list != null && list.Count > 0) {
					fileList.Clear();
					fileList.AddRange(list);
				}
			}
		}

	}

}
