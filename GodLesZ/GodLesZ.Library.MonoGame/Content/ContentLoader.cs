using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GodLesZ.Library.MonoGame.Content.Extended;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GodLesZ.Library.MonoGame.Content {

	public class ContentLoader {
		protected readonly ExtendedContentManager mExtendedContentManager;

		public string RootDirectory {
			get { return mExtendedContentManager.RootDirectory; }
		}

		public ContentManager XnaContent {
			get;
			protected set;
		}


		public ContentLoader(string contentRoot, GraphicsDevice graphicsDevice, IServiceProvider provider) {
			mExtendedContentManager = new ExtendedContentManager(contentRoot, graphicsDevice);
			if (provider != null) {
				XnaContent = new ContentManager(provider, contentRoot);
			}
		}


		#region Load | LoadAsync
		/// <summary>
		/// Return the specified asset. Read it from disk if not available
		/// </summary>
		/// <param name="filename">Name of the asset to load</param>
		/// <param name="callback"></param>
		/// <returns>A reference to the loaded asset</returns>
		public object Load(string filename, AssetLoadedHandler callback) {
			return mExtendedContentManager.Load(filename, callback);
		}

		/// <summary>
		/// Asyncronously loads the specified asset
		/// </summary>
		/// <param name="filename"></param>
		/// <param name="itemLoadedMethod">Method to call once load is completed</param>
		/// <param name="callback"></param>
		/// <returns>AssetTracker of asset to be loaded. Allows users to poll the asset status if desired</returns>
		public AssetTracker LoadAsync(string filename, AssetLoaded itemLoadedMethod, AssetLoadedHandler callback) {
			return mExtendedContentManager.LoadAsync(filename, itemLoadedMethod, callback);
		}
		#endregion

		#region []Load | []LoadAsync
		/// <summary>
		/// Return the specified asset arrays. Read it from disk if not available
		/// </summary>
		/// <param name="filenames">Names of the assets to load</param>
		/// <param name="callback"></param>
		/// <returns>A reference array to the loaded assets</returns>
		public object[] Load(string[] filenames, AssetLoadedHandler callback) {
			return mExtendedContentManager.Load(filenames, callback);
		}

		/// <summary>
		/// Asyncronously loads the specified asset array
		/// </summary>
		/// <param name="filenames"></param>
		/// <param name="itemLoadedMethod">Method to call once load is completed</param>
		/// <param name="callback"></param>
		/// <returns>AssetTracker array of assets to be loaded. Allows to poll the asset status if desired</returns>
		public AssetTracker[] LoadAsync(string[] filenames, AssetLoaded itemLoadedMethod, AssetLoadedHandler callback) {
			return mExtendedContentManager.LoadAsync(filenames, itemLoadedMethod, callback);
		}
		#endregion

		#region List<> Load | List<AssetTracker> LoadAsync
		/// <summary>
		/// Return the specified asset List. Read it from disk if not available
		/// </summary>
		/// <param name="filenames"></param>
		/// <param name="callback"></param>
		/// <returns>A reference List to the loaded assets</returns>
		public List<object> Load(List<string> filenames, AssetLoadedHandler callback) {
			return mExtendedContentManager.Load(filenames, callback);
		}

		/// <summary>
		/// Asyncronously loads the specified asset List
		/// </summary>
		/// <param name="filenames"></param>
		/// <param name="itemLoadedMethod">Method to call once load is completed</param>
		/// <param name="callback"></param>
		/// <returns>AssetTracker List of assets to be loaded. Allows to poll the asset status if desired</returns>
		public List<AssetTracker> LoadAsync(List<string> filenames, AssetLoaded itemLoadedMethod, AssetLoadedHandler callback) {
			return mExtendedContentManager.LoadAsync(filenames, itemLoadedMethod, callback);
		}
		#endregion

		/// <summary>
		/// Clean up all assets
		/// </summary>
		public void Unload() {
			mExtendedContentManager.Unload();
		}

		/// <summary>
		/// Force an asset to be disposed. Releases also all child assets 
		/// </summary>
		/// <param name="assetName">Name of asset to unload</param>
		public void Unload(string assetName) {
			mExtendedContentManager.Unload(assetName, true);
		}


		public Texture2D GetTexture(string filename, string subDir) {
			try {
				filename = Path.Combine(subDir, filename);
				if (Path.GetExtension(filename) != ".png" && Path.GetExtension(filename) != ".jpg")
					filename += ".png";

				var texture = (Texture2D)Load(filename,
					delegate(AssetTracker tracker) {
						Texture2D tex;
						var buf = (byte[])tracker.Asset;
						using (var ms = new MemoryStream(buf)) {
							tex = Texture2D.FromStream(mExtendedContentManager.GraphicsDevice, ms);
						}
						return tex;
					}
				);

				return texture;
			} catch (Exception e) {
				System.Diagnostics.Debug.WriteLine(e);
				return null;
			}
		}

		#region Load<XNA>
		public T Load<T>(string filename) {
			return Load<T>(filename, "");
		}

		public T Load<T>(string filename, string basedir) {
			if (basedir.Length > 0 && basedir[basedir.Length - 1] != '/' && basedir[basedir.Length - 1] != '\\') {
				basedir += "\\";
			}
			return XnaContent.Load<T>(basedir + filename);
		}

		public List<T> Load<T>(List<string> filenames) {
			var files = new List<T>(filenames.Count);
			files.AddRange(filenames.Select(t => XnaContent.Load<T>(t)));
			return files;
		}

		public T[] Load<T>(string[] filenames) {
			var files = new T[filenames.Length];
			for (var i = 0; i < filenames.Length; i++)
				files[i] = XnaContent.Load<T>(filenames[i]);
			return files;
		}
		#endregion

	}

}
