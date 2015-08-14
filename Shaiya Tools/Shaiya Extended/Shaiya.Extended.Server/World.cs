using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Shaiya.Extended.Server.Objects;
using Shaiya.Extended.Server.MySql;
using Shaiya.Extended.Library.Utility;

namespace Shaiya.Extended.Server {

	public class World {

		private static SerialObjectManager mSerialObjects;
		private static Queue<SerialObject> mAddQueue, mDelQueue;

		private static bool mLoading;
		private static bool mLoaded;
		private static bool mSaving;

		public static bool Saving {
			get { return mSaving; }
		}
		public static bool Loaded {
			get { return mLoaded; }
		}
		public static bool Loading {
			get { return mLoading; }
		}

		public static SerialObjectManager Objects {
			get { return mSerialObjects; }
		}





		public static void Load() {
			if( mLoaded )
				return;

			mLoaded = true;

			CConsole.InfoLine( "Begin World loading..." );

			Stopwatch watch = Stopwatch.StartNew();

			mLoading = true;

			mAddQueue = new Queue<SerialObject>();
			mDelQueue = new Queue<SerialObject>();
			mSerialObjects = new SerialObjectManager();

			Events.InvokeWorldLoadStart();

			//------------- loading start -------------

			// Loading Maps

			// Loading Items
			CConsole.Info( "\t# loading Items..." );
			watch.Reset();
			ResultTable table = Core.Database.Query( "SELECT * FROM item_db" );
			table.TableName = "ItemDB Table";
			if( table.Rows == null ) {
				CConsole.ErrorLine( "failed to load Item Database!" );
				CConsole.WriteLine( Core.Database.LastError.ToString() );
			} else
				for( int i = 0; i < table.Rows.Count; i++ ) {
					BaseItem item = new BaseItem( table[ i ] );
					//#TODO# add validation Checks
					mSerialObjects.Add( item );
				}
			watch.Stop();
			CConsole.WriteLine( "done (" + mSerialObjects.Count( ESerialType.Item ) + " Items in " + watch.ElapsedMilliseconds + "ms)" );

			// Loading Mobs

			// Loading other shit
			// o.o

			//------------- loading end -------------

			Events.InvokeWorldLoadFinish();

			mLoading = false;

			ProcessSafetyQueues();

			CConsole.InfoLine( "Finished World loading! Needed {0:F2} sec", watch.Elapsed.TotalSeconds );

			watch.Stop();
			watch = null;
		}






		public static BaseItem GetItem( string Itemname ) {
			foreach( BaseItem item in mSerialObjects.GetDictionary( ESerialType.Item ).Values ) {
				if( item.Name == Itemname )
					return item;
			}
			return null;
		}


		/// <summary>
		/// Handles Object join/leave after load/save/ect
		/// </summary>
		private static void ProcessSafetyQueues() {
			while( mAddQueue.Count > 0 )
				mSerialObjects.Add( mAddQueue.Dequeue() );

			while( mDelQueue.Count > 0 )
				mDelQueue.Dequeue().Delete();
		}


		public static void CharacterLogin( Character mActiveChar ) {

		}

	}

}
