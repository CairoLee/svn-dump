using System.Collections.Generic;
using System.Threading;

namespace GodLesZ.Library.MonoGame.Content.Extended {

	/// <summary>
	/// Signature of a method to call when an 
	/// asset finishes loading asyncronously
	/// </summary>
	/// <param name="asset"></param>
	public delegate void AssetLoaded(object asset);

	/// <summary>
	/// Async section of ContentTracker
	/// </summary>
	public partial class ExtendedContentManager {

		/// <summary>
		/// The paramaters required to asyncronously load an asset
		/// </summary>
		public class LoadAsyncParams {
			/// <summary>
			/// The AssetTracker to pass to Load(). Also 
			/// stores the asset name to load
			/// </summary>
			internal AssetTracker Tracker;

			/// <summary>
			/// Method to invoke when the asset is loaded
			/// </summary>
			internal List<AssetLoaded> ItemLoadedMethods = new List<AssetLoaded>();

			/// <summary>
			/// Constructor for convenience
			/// </summary>
			internal LoadAsyncParams(string name, AssetLoaded loadedMethod) {
				ItemLoadedMethods.Add(loadedMethod);
				Tracker = new AssetTracker();
				Tracker.AssetName = name;
				Tracker.RefCount = 1;
				Tracker.Status = EAssetStatus.Loading;
			}
		}

		private Queue<LoadAsyncParams> mLoadItemsQueue;
		private Thread mLoadThread;
		private AutoResetEvent mLoadResetEvent;



		/// <summary>
		/// Asyncronously loads the specified asset array
		/// </summary>
		/// <param name="assetNames">Names of assets to laod</param>
		/// <param name="itemLoadedMethod">Method to call once load is completed</param>
		/// <returns>AssetTracker array of assets to be loaded. Allows to poll the asset status if desired</returns>
		public AssetTracker[] LoadAsync(string[] assetNames, AssetLoaded itemLoadedMethod, AssetLoadedHandler Callback) {
			AssetTracker[] assets = new AssetTracker[assetNames.Length];
			for (int i = 0; i < assets.Length; i++)
				assets[i] = LoadAsync(assetNames[i], itemLoadedMethod, Callback);
			return assets;
		}

		/// <summary>
		/// Asyncronously loads the specified asset List
		/// </summary>
		/// <param name="assetNames">Names of assets to laod</param>
		/// <param name="itemLoadedMethod">Method to call once load is completed</param>
		/// <returns>AssetTracker List of assets to be loaded. Allows to poll the asset status if desired</returns>
		public List<AssetTracker> LoadAsync(List<string> assetNames, AssetLoaded itemLoadedMethod, AssetLoadedHandler Callback) {
			return new List<AssetTracker>(LoadAsync(assetNames.ToArray(), itemLoadedMethod, Callback));
		}

		/// <summary>
		/// Asyncronously loads the specified asset
		/// </summary>
		/// <param name="assetName">Name of asset to laod</param>
		/// <param name="itemLoadedMethod">Method to call once load is completed</param>
		/// <returns>AssetTracker of asset to be loaded. Allows to poll the asset status if desired</returns>
		public AssetTracker LoadAsync(string assetName, AssetLoaded itemLoadedMethod, AssetLoadedHandler Callback) {
			AssetTracker tracker = null;

			// Check if asset is already loaded
			if (mCache.ContainsKey(assetName)) {
				tracker = mCache[assetName];

				// Increment reference count
				tracker.RefCount++;

				// Call the specified item loaded method
				if (itemLoadedMethod != null)
					itemLoadedMethod(tracker.Asset);
			} else {
				if (mLoadThread == null) {
					// First time LoadAsync has been called so 
					// initialise thread, reset event and queue
					mLoadThread = new Thread(new ThreadStart(LoadingThreadWorker));
					mLoadItemsQueue = new Queue<LoadAsyncParams>();
					mLoadResetEvent = new AutoResetEvent(false);

					// Start thread. It will wait once queue is empty
					mLoadThread.Start();
				}

				// Create the async argument structure and enqueue it for async load.
				lock (mLoadItemsQueue) {
					// first check if this item is already enqueued
					Queue<LoadAsyncParams>.Enumerator enumer = mLoadItemsQueue.GetEnumerator();
					while (enumer.MoveNext()) {
						if (enumer.Current.Tracker.AssetName == assetName) {
							// Register the itemLoaded method
							enumer.Current.ItemLoadedMethods.Add(itemLoadedMethod);
							tracker = enumer.Current.Tracker;
							tracker.RefCount++;
							break;
						}
					}

					// Item not already queued for loading
					if (tracker == null) {
						LoadAsyncParams args = new LoadAsyncParams(assetName, itemLoadedMethod);
						tracker = args.Tracker;
						mLoadItemsQueue.Enqueue(args);
					}
				}

				// Tell loading thread to stop waiting
				mLoadResetEvent.Set();
			}

			tracker.OnAssetLoaded = Callback;

			// Return tracker. Allows async caller to poll loaded status
			return tracker;
		}

		/// <summary>
		/// Consume the Queue of assets to be loaded then wait 
		/// </summary>
		private void LoadingThreadWorker() {
			LoadAsyncParams args;

			while (true) {
				while (mLoadItemsQueue.Count > 0 && !IsLoading) {
					// Get next item to process
					lock (mLoadItemsQueue) {
						args = mLoadItemsQueue.Peek();
					}

					// Process head queue entry
					this.Load(args.Tracker.AssetName, args.Tracker, args.Tracker.OnAssetLoaded);

					// Ensure Load<T> correctly added AssetTracker to the dictionary
					if (mCache.ContainsKey(args.Tracker.AssetName)) {
						// Call back the item loaded methods
						foreach (AssetLoaded method in args.ItemLoadedMethods) {
							if (method != null)
								method.Invoke(args.Tracker.Asset);
						}

						// The asset is now ready to use
						args.Tracker.Status = EAssetStatus.Active;
					}

					// Remove processed item. Can't be removed until
					// loading complete as new async requests may need
					// to add AssetLoaded methods to it's list
					lock (mLoadItemsQueue) {
						mLoadItemsQueue.Dequeue();
					}
				}

				// Wait until next load call
				mLoadResetEvent.WaitOne();
			}
		}

	}

}
