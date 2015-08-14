using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GodLesZ.Library.MonoGame.Content.Extended {


	public partial class ExtendedContentManager {

		private GraphicsDevice mGraphicsDevice;
		private string mRootDirectory;
		private Dictionary<string, AssetTracker> mCache = new Dictionary<string, AssetTracker>();
		private List<string> mCacheNames = new List<string>();
		private Stack<AssetTracker> mCacheLoadingStack = new Stack<AssetTracker>();

		

		public GraphicsDevice GraphicsDevice {
			get { return mGraphicsDevice; }
			set { mGraphicsDevice = value; }
		}

		public string RootDirectory {
			get { return mRootDirectory; }
			set { mRootDirectory = value; }
		}


		/// <summary>
		/// Returns true if the ContentTracker is currently loading.
		/// Returns false otherwise
		/// </summary>
		public bool IsLoading {
			get { return mCacheLoadingStack.Count > 0; }
		}

		/// <summary>
		/// Constructs a ContentTracker
		/// </summary>
		/// <param name="GraphicsDevice"></param>
		public ExtendedContentManager( GraphicsDevice GraphicsDevice ) {
			GraphicsDevice = mGraphicsDevice;
		}

		/// <summary>
		/// Constructs a ContentTracker
		/// </summary>
		/// <param name="rootDirectory">The root directory of the ContentTracker</param>
		/// <param name="GraphicsDevice"></param>
		public ExtendedContentManager( string rootDirectory, GraphicsDevice graphicsDevice ) {
			RootDirectory = rootDirectory;
			GraphicsDevice = graphicsDevice;
		}




		/// <summary>
		/// Return the specified asset. Read it from disk if not available
		/// </summary>
		/// <typeparam name="T">The Type of asset to load</typeparam>
		/// <param name="assetName">Name of the asset to load</param>
		/// <returns>A reference to the loaded asset</returns>
		public object Load( string assetName, AssetLoadedHandler Callback ) {
			return Load( assetName, null, Callback );
		}

		/// <summary>
		/// Return the specified asset arrays. Read it from disk if not available
		/// </summary>
		/// <typeparam name="T">The Type of asset to load</typeparam>
		/// <param name="assetNames">Names of the assets to load</param>
		/// <returns>A reference array to the loaded assets</returns>
		public object[] Load( string[] assetNames, AssetLoadedHandler Callback ) {
			object[] assets = new object[ assetNames.Length ];
			for( int i = 0; i < assets.Length; i++ )
				assets[ i ] = Load( assetNames[ i ], null, Callback );
			return assets;
		}

		/// <summary>
		/// Return the specified asset List. Read it from disk if not available
		/// </summary>
		/// <typeparam name="T">The Type of asset to load</typeparam>
		/// <param name="assetNames">Names of the assets to load</param>
		/// <returns>A reference List to the loaded assets</returns>
		public List<object> Load( List<string> assetNames, AssetLoadedHandler Callback ) {
			return new List<object>( this.Load( assetNames.ToArray(), Callback ) );
		}

		/// <summary>
		/// Clean up all assets
		/// </summary>
		public void Unload() {
			// Dispose all IDisposables now
			Dictionary<string, AssetTracker>.Enumerator enumer = mCache.GetEnumerator();
			while( enumer.MoveNext() ) {
				enumer.Current.Value.OnAssetChanged( new AssetChangedEventArgs( null ) );
				DisposeAssetTracker( enumer.Current.Value, false );
			}

			mCache.Clear();

			// Stop and cleanup the loading thread
			if( mLoadThread != null ) {
				try {
					mLoadThread.Abort();
					mLoadThread = null;
				} catch { }
			}
		}

		/// <summary>
		/// Force an asset to be disposed. Optionally releases child assets 
		/// </summary>
		/// <param name="assetName">Name of asset to unload</param>
		/// <param name="releaseChildren">Release child assets</param>
		public void Unload( string assetName, bool releaseChildren ) {
			if( mCache.ContainsKey( assetName ) ) {
				AssetTracker tracker = mCache[ assetName ];

				// Fire changed event
				tracker.OnAssetChanged( new AssetChangedEventArgs( null ) );

				// Destroy disposables
				DisposeAssetTracker( tracker, releaseChildren );

				// Remove from dictionary
				mCache.Remove( assetName );
				mCacheNames.Remove( assetName );
			}
		}

		/// <summary>
		/// Release asset. Decrements the reference count and
		/// removes child assets when the count is zero
		/// </summary>
		/// <param name="assetName">Asset to release</param>
		public void Release( string assetName ) {
			if( mCache.ContainsKey( assetName ) ) {
				AssetTracker tracker = mCache[ assetName ];
				tracker.RefCount--;

				if( tracker.RefCount == 0 ) {
					tracker.OnAssetChanged( new AssetChangedEventArgs( null ) );
					DisposeAssetTracker( tracker, true );

					// Remove from dictionary
					mCache.Remove( assetName );
					mCacheNames.Remove( assetName );
				}
			}
		}

		/// <summary>
		/// Reloads the specified asset.
		/// </summary>
		/// <param name="assetName">Name of the asset to load</param>
		/// <returns>The new reference to the reloaded asset</returns>
		public object Reload( string assetName, AssetLoadedHandler Callback ) {
			if( mCache.ContainsKey( assetName ) ) {
				AssetTracker oldAssetTracker = mCache[ assetName ];

				// Remove tracker so Load<T>() will create a new one
				mCache.Remove( assetName );
				mCacheNames.Remove( assetName );

				// Load it again
				object asset = Load( assetName, Callback );

				// Invoke AssetChanged event
				oldAssetTracker.OnAssetChanged( new AssetChangedEventArgs( asset ) );

				// Destroy previous tracker
				DisposeAssetTracker( oldAssetTracker, true );

				return asset;
			} else
				return Load( assetName, Callback );
		}


		/// <summary>
		/// Tests if the specified asset is loaded
		/// </summary>
		/// <param name="assetName">Name of asset to test</param>
		/// <returns>True if asset is loaded otherwise false</returns>
		public bool IsLoaded( string assetName ) {
			if( mCache.ContainsKey( assetName ) )
				return true;

			return false;
		}

		/// <summary>
		/// Returns the Asset Tracker
		/// </summary>
		/// <param name="assetName">Name of asset to get tracker for</param>
		/// <returns>The AssetTracker with specified name, or null if not existing</returns>
		public AssetTracker GetTracker( string assetName ) {
			if( !mCache.ContainsKey( assetName ) )
				return null;

			return mCache[ assetName ];
		}

		/// <summary>
		/// Gets an Asset's reference count
		/// </summary>
		/// <param name="assetName">Name of asset to get reference count for</param>
		/// <returns>Reference count of specified asset</returns>
		public int GetReferenceCount( string assetName ) {
			// Return zero if not currently loaded
			if( !mCache.ContainsKey( assetName ) )
				return 0;

			return mCache[ assetName ].RefCount;
		}

		/// <summary>
		/// Get the names of all assets that are currently loaded
		/// </summary>
		/// <returns>List of loaded asset names</returns>
		public List<string> GetLoadedAssetNames() {
			return mCacheNames;
		}

		/// <summary>
		/// Check if the specified object is a loaded asset
		/// </summary>
		/// <param name="asset">asset reference to search for</param>
		/// <param name="assetName">Name asset with specified reference if found</param>
		/// <returns>True if the specified asset was found and false otherwise</returns>
		public bool SearchForAsset( object asset, out string assetName ) {
			// Enumerate all loaded assets
			Dictionary<string, AssetTracker>.Enumerator enumer = mCache.GetEnumerator();
			while( enumer.MoveNext() ) {
				if( asset == enumer.Current.Value.Asset ) {
					// Found asset
					assetName = enumer.Current.Key;
					return true;
				}
			}
			assetName = "";
			return false;
		}






		private object Load( string assetName, AssetTracker tracker, AssetLoadedHandler Callback ) {
			// Return asset if currently loaded
			if( mCache.ContainsKey( assetName ) ) {
				// Get asset tracker
				AssetTracker trackerExisting = mCache[ assetName ];

				object asset = trackerExisting.Asset;

				// Increment tracker's reference count after the cast as the cast will  
				// throw an exception if the incorrect generic type parameter is given 
				trackerExisting.RefCount++;

				// Maintain the reference lists to show that this asset was loaded by
				// the asset on the top of the stack
				if( mCacheLoadingStack.Count > 0 ) {
					mCacheLoadingStack.Peek().RefersTo.Add( assetName );
					trackerExisting.ReferredToBy.Add( mCacheLoadingStack.Peek().AssetName );
				}

				return asset;
			}

			// Need to load the asset. Create an AssetTracker to track it
			// unless we have been passed an existing AssetTracker
			if( tracker == null ) {
				// Initialise tracker
				tracker = new AssetTracker();
				tracker.RefCount = 1;
				tracker.AssetName = assetName;
			}

			// Stack count will be zero if called by user. 
			// Otherwise, Load<T> was called internally by ReadAsset<T>
			if( mCacheLoadingStack.Count > 0 ) {
				// Maintain the reference lists

				// The asset on the top of the stack refers to this asset
				mCacheLoadingStack.Peek().RefersTo.Add( assetName );

				// This asset was loaded by the asset on the top of the stack
				tracker.ReferredToBy.Add( mCacheLoadingStack.Peek().AssetName );
			}

			// Put current asset tracker on top of the stack 
			// for next call to Load<T>
			mCacheLoadingStack.Push( tracker );

			try {
				tracker.Asset = ReadAsset( assetName, tracker.TrackDisposableAsset );
				tracker.Asset = Callback( tracker );

				// Ensure the list of disposables doesn't refer to the 
				// actual asset, or to any assets in the loadedAssets Dictionary.
				// Best to do this now to avoid multiple disposing later
				tracker.Disposables.RemoveAll( delegate( IDisposable d ) {
					string tmp = "";
					return tracker.Asset == d || SearchForAsset( d, out tmp );
				} );
			} catch( Exception ex ) {
				System.Diagnostics.Debug.WriteLine( "Asset.Load() Exception\n" + ex.ToString() );

			} finally {
				// Asset has been loaded so the top tracker is not needed on the stack
				mCacheLoadingStack.Pop();
			}

			// Store the asset and it's disposables list
			mCache.Add( assetName, tracker );
			mCacheNames.Add( assetName );

			// Mark tracker as ready to use
			tracker.Status = EAssetStatus.Active;

			// Return loaded asset
			return tracker.Asset;
		}


		/// <summary>
		/// Destroy IDisposables that were tracked by this asset but do not 
		/// exist as assets in their own right. This will also dispose the
		/// unmanaged internals like vertex and index buffers
		/// </summary>
		/// <param name="tracker">AssetTracker to dispose</param>
		/// <param name="releaseChildren">If true, child assets will be released</param>
		private void DisposeAssetTracker( AssetTracker tracker, bool releaseChildren ) {
			// Invoke asset changed event.
			tracker.OnAssetChanged( new AssetChangedEventArgs( null ) );

			// Mark tracker as disposed
			tracker.Status = EAssetStatus.Disposed;

			// Destroy tracked disposables
			foreach( IDisposable disposable in tracker.Disposables ) {
				disposable.Dispose();
			}

			// Dispose the actual asset, if possible
			if( tracker.Asset is IDisposable )
				( (IDisposable)tracker.Asset ).Dispose();

			// Handle child assets
			foreach( string childAsset in tracker.RefersTo ) {
				if( mCache.ContainsKey( childAsset ) ) {
					// Maintain child reference list
					mCache[ childAsset ].ReferredToBy.Remove( tracker.AssetName );

					// release child assets if requested
					if( releaseChildren )
						Release( childAsset );
				}
			}
		}

		#region ReadAsset
		protected object ReadAsset( string assetName, Action<IDisposable> recordDisposableObject ) {
			if( mCache == null )
				throw new ObjectDisposedException( this.ToString() );

			if( string.IsNullOrEmpty( assetName ) )
				throw new ArgumentNullException( "assetName" );

			try {
				using( Stream stream = this.OpenStream( assetName ) ) {
					return ReadStream( stream );
				}
			} catch( Exception e ) {
				System.Diagnostics.Debug.WriteLine( e );
				return new byte[ 0 ];
			}

		}

		protected virtual Stream OpenStream( string assetName ) {
			Stream stream;
			try {
				string filepath = GetCleanPath(AppDomain.CurrentDomain.BaseDirectory + Path.Combine(this.mRootDirectory, assetName));
				stream = new FileStream( filepath, FileMode.Open, FileAccess.Read, FileShare.Read );
			} catch( Exception exception ) {
				if( ( exception is FileNotFoundException ) || ( exception is DirectoryNotFoundException ) ) {
					throw new ContentLoadException( string.Format( "File \"{0}\" not found!", assetName ), exception );
				}
				if( ( ( exception is ArgumentException ) || ( exception is NotSupportedException ) ) || ( ( exception is IOException ) || ( exception is UnauthorizedAccessException ) ) ) {
					throw new ContentLoadException( string.Format( "File \"{0}\" is not a valid File!", assetName ), exception );
				}
				throw;
			}
			return stream;
		}

		internal static string GetCleanPath( string path ) {
			int lastIndexOf;
			path = path.Replace( Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar );
			for( int i = 1; i < path.Length; i = Math.Max( lastIndexOf - 1, 1 ) ) {
				i = path.IndexOf( @"\..\", i );
				if( i < 0 ) 
					return path;

				lastIndexOf = path.LastIndexOf( Path.DirectorySeparatorChar, i - 1 ) + 1;
				path = path.Remove( lastIndexOf, ( i - lastIndexOf ) + @"\..\".Length );
			}
			return path;
		}

		internal static byte[] ReadStream( Stream stream ) {
			byte[] streamData = new byte[ stream.Length ];
			
			stream.Read( streamData, 0, streamData.Length );

			return streamData;
		}


		#endregion

	}

}
