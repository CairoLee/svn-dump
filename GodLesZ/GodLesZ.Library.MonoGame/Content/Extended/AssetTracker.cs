using System;
using System.Collections.Generic;

namespace GodLesZ.Library.MonoGame.Content.Extended {
	/// <summary>
	/// Method signature for the AssetChanged event
	/// </summary>
	public delegate void AssetChangedEvent(object sender, AssetChangedEventArgs args);

	public delegate object AssetLoadedHandler(AssetTracker asset);

	public class AssetTracker {
		/// <summary>
		/// Name of the asset.
		/// Used as the key to look up this AssetTracker
		/// </summary>
		public string AssetName;

		/// <summary>
		/// The actual asset
		/// </summary>
		public object Asset;

		/// <summary>
		/// Disposables owned by this asset
		/// </summary>
		public List<IDisposable> Disposables = new List<IDisposable>();

		/// <summary>
		/// Asset's reference count.
		/// Asset will be unloaded when this reaches zero
		/// </summary>
		public int RefCount;

		/// <summary>
		/// Asset's current load status.
		/// Can be used to check when threaded loading completes
		/// </summary>
		public EAssetStatus Status = EAssetStatus.Disposed;

		/// <summary>
		/// Assets that we reference (children)
		/// </summary>
		public List<string> RefersTo = new List<string>();

		/// <summary>
		/// Assets that reference us (parents)
		/// </summary>
		public List<string> ReferredToBy = new List<string>();

		public AssetLoadedHandler OnAssetLoaded;

		/// <summary>
		/// This method is an <see cref="Action"/>, allowing
		/// ReadAsset() to track the disposables for this asset 
		/// </summary>
		/// <param name="disposable">An IDisposable referenced by this asset</param>
		public void TrackDisposableAsset(IDisposable disposable) {
			Disposables.Add(disposable);
		}

		/// <summary>
		/// Event invoked when this asset is reloaded or unloaded
		/// </summary>
		public event AssetChangedEvent AssetChanged;

		/// <summary>
		/// Helper for invoking AssetChanged. 
		/// Marked as internal because it's invoked by ContentTracker. 
		/// </summary>
		protected internal void OnAssetChanged(AssetChangedEventArgs args) {
			if (AssetChanged != null)
				AssetChanged(this, args);
		}

	}

}
