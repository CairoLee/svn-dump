using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FreeWorld.Engine;
using System.Diagnostics;
using FreeWorld.Engine.TileEngine;
using GodLesZ.Library.Xna.Content;

namespace FreeWorld.Editor.Map {

	public class Converter30 {
		private static Dictionary<string, string> mTextures = new Dictionary<string, string>();
		private static Dictionary<string, string> mTexturesAuto = new Dictionary<string, string>();

		public TileMap Convert(string filepath) {
			TileMap map;
			TileMap.Load(filepath, out map);
			if (map == null) {
				return null;
			}

			// Build texture-name cache, if needed
			BuildCache();
			// Update texture names
			foreach (var layer in map.Layers) {
				for (int x = 0; x < layer.Width; x++) {
					for (int y = 0; y < layer.Height; y++) {
						if (layer.LayoutMap[x][y].TextureSource.TextureIndex == "") {
							continue;
						}

						// Key of the dict is the first part of the name
						// "XXX-....png"
						// We search only for the key and replace them using the full name
						// If not found, the tileset may be correct
						string index = layer.LayoutMap[x][y].TextureSource.TextureIndex;
						string indexNew = "";
						if (layer.LayoutMap[x][y].IsAutoTexture) {
							if (mTexturesAuto.ContainsKey(index) == false) {
								continue;
							}
							indexNew = mTexturesAuto[index];
						} else {
							if (mTextures.ContainsKey(index) == false) {
								continue;
							}
							indexNew = mTextures[index];
						}
						layer.LayoutMap[x][y].TextureSource.TextureIndex = indexNew;
					}
				}
			}

			// Update version
			map.VersionMajor = TileMap.VersionMajorNow;
			map.VersionMinor = TileMap.VersionMinorNow;

			return map;
		}


		private static void BuildCache() {
			if (mTextures.Count != 0) {
				return;
			}

			// Load textures from the FileList, split name by "-" and add them
			foreach (FileListEntry entry in EngineCore.FileLists.Tilesets) {
				string[] parts = entry.Filename.Split('-');
				if (mTextures.ContainsKey(parts[0]) == false) {
					mTextures.Add(parts[0], entry.Filename);
				} else {
					Debug.WriteLine("Texture duplicate: " + entry.Filename);
				}
			}
			foreach (FileListEntry entry in FileListLoader.Instance.Autotiles) {
				string[] parts = entry.Filename.Split('-');
				if (mTexturesAuto.ContainsKey(parts[0]) == false) {
					mTexturesAuto.Add(parts[0], entry.Filename);
				} else {
					Debug.WriteLine("Texture duplicate: " + entry.Filename);
				}
			}
		}

	}

}
