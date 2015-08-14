using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Shaiya.Reader.API.ProcessMemoryReaderLib;

namespace Shaiya.Reader.API {

	public class Worker {
		private static ProcessMemoryReader mMemReader = new ProcessMemoryReader();
		private static Dictionary<object, long> mCacheLong = new Dictionary<object, long>();
		private static Dictionary<object, float> mCacheFloat = new Dictionary<object, float>();

		public static ProcessMemoryReader MemReader {
			get { return Worker.mMemReader; }
		}

		public static int HP {
			get { return (int)mCacheLong[ Constants.EOffsets.Hp ]; }
		}
		public static int HPMax {
			get { return (int)mCacheLong[ Constants.EOffsets.HpMax ]; }
		}

		public static int MP {
			get { return (int)mCacheLong[ Constants.EOffsets.Mp ]; }
		}
		public static int MPMax {
			get { return (int)mCacheLong[ Constants.EOffsets.MpMax ]; }
		}

		public static int AP {
			get { return (int)mCacheLong[ Constants.EOffsets.Ap ]; }
		}
		public static int APMax {
			get { return (int)mCacheLong[ Constants.EOffsets.ApMax ]; }
		}


		public static int Exp {
			get { return (int)mCacheLong[ Constants.EAddress.Exp ]; }
		}
		public static int ExpMax {
			get { return (int)mCacheLong[ Constants.EAddress.ExpMax ]; }
		}

		public static int Level {
			get { return (int)mCacheLong[ Constants.EAddress.Level ]; }
		}

		public static int StatusInt {
			get { return (int)mCacheLong[ Constants.EAddress.StatusInt ]; }
		}
		public static int StatusStr {
			get { return (int)mCacheLong[ Constants.EAddress.StatusStr ]; }
		}
		public static int StatusGes {
			get { return (int)mCacheLong[ Constants.EAddress.StatusGes ]; }
		}
		public static int StatusWei {
			get { return (int)mCacheLong[ Constants.EAddress.StatusWei ]; }
		}
		public static int StatusAbw {
			get { return (int)mCacheLong[ Constants.EAddress.StatusAbw ]; }
		}
		public static int StatusGlu {
			get { return (int)mCacheLong[ Constants.EAddress.StatusGlu ]; }
		}

		public static string Name {
			get { return mMemReader.readMemoryString( Constants.EAddress.Name, 25 ); }
		}




		public static float PositionX {
			get { return (float)mCacheFloat[ Constants.EOffsets.PositionX ]; }
		}

		public static float PositionY {
			get { return (float)mCacheFloat[ Constants.EOffsets.PositionY ]; }
		}

		public static float PositionZ {
			get { return (float)mCacheFloat[ Constants.EOffsets.PositionZ ]; }
		}

		public static float PositionFutureX {
			get { return (float)mCacheFloat[ Constants.EOffsets.PositionFutureX ]; }
		}

		public static float PositionFutureY {
			get { return (float)mCacheFloat[ Constants.EOffsets.PositionFutureY ]; }
		}

		public static float PositionFutureZ {
			get { return (float)mCacheFloat[ Constants.EOffsets.PositionFutureZ ]; }
		}


		public static bool IsActive() {
			return !( HP <= -1 || HP >= 100000 || Level <= 0 );
		}

		public static void ReCache() {
			mCacheLong.Clear();
			mCacheFloat.Clear();

			mCacheLong.Add( Constants.EOffsets.Ap, mMemReader.readMemoryInt32( Constants.EOffsets.Ap ) );
			mCacheLong.Add( Constants.EOffsets.ApMax, mMemReader.readMemoryInt32( Constants.EOffsets.ApMax ) );
			mCacheLong.Add( Constants.EOffsets.Hp, mMemReader.readMemoryInt32( Constants.EOffsets.Hp ) );
			mCacheLong.Add( Constants.EOffsets.HpMax, mMemReader.readMemoryInt32( Constants.EOffsets.HpMax ) );
			mCacheLong.Add( Constants.EOffsets.Mp, mMemReader.readMemoryInt32( Constants.EOffsets.Mp ) );
			mCacheLong.Add( Constants.EOffsets.MpMax, mMemReader.readMemoryInt32( Constants.EOffsets.MpMax ) );

			mCacheLong.Add( Constants.EAddress.Exp, mMemReader.readMemoryInt32( Constants.EAddress.Exp ) );
			mCacheLong.Add( Constants.EAddress.ExpMax, mMemReader.readMemoryInt32( Constants.EAddress.ExpMax ) );
			mCacheLong.Add( Constants.EAddress.Level, mMemReader.readMemoryInt32( Constants.EAddress.Level ) );

			mCacheLong.Add( Constants.EAddress.StatusAbw, mMemReader.readMemoryInt16( Constants.EAddress.StatusAbw ) );
			mCacheLong.Add( Constants.EAddress.StatusGes, mMemReader.readMemoryInt16( Constants.EAddress.StatusGes ) );
			mCacheLong.Add( Constants.EAddress.StatusGlu, mMemReader.readMemoryInt16( Constants.EAddress.StatusGlu ) );
			mCacheLong.Add( Constants.EAddress.StatusInt, mMemReader.readMemoryInt16( Constants.EAddress.StatusInt ) );
			mCacheLong.Add( Constants.EAddress.StatusStr, mMemReader.readMemoryInt16( Constants.EAddress.StatusStr ) );
			mCacheLong.Add( Constants.EAddress.StatusWei, mMemReader.readMemoryInt16( Constants.EAddress.StatusWei ) );
		
			mCacheFloat.Add( Constants.EOffsets.PositionFutureX, mMemReader.readMemoryFloat( Constants.EOffsets.PositionFutureX ) );
			mCacheFloat.Add( Constants.EOffsets.PositionFutureY, mMemReader.readMemoryFloat( Constants.EOffsets.PositionFutureY ) );
			mCacheFloat.Add( Constants.EOffsets.PositionFutureZ, mMemReader.readMemoryFloat( Constants.EOffsets.PositionFutureZ ) );
			mCacheFloat.Add( Constants.EOffsets.PositionX, mMemReader.readMemoryFloat( Constants.EOffsets.PositionX ) );
			mCacheFloat.Add( Constants.EOffsets.PositionY, mMemReader.readMemoryFloat( Constants.EOffsets.PositionY ) );
			mCacheFloat.Add( Constants.EOffsets.PositionZ, mMemReader.readMemoryFloat( Constants.EOffsets.PositionZ ) );

		}







		public static bool AttachInstance( string ProcessName ) {
			// need the Keys in the Dictionary asap...
			ReCache();

			Process[] processesByName = Process.GetProcessesByName( ProcessName );
			if( processesByName.Length == 0 )
				return false;

			mMemReader.ReadProcess = processesByName[ 0 ] as Process;
			if( mMemReader.OpenProcess() == false )
				return false;
			mMemReader.loadPointer( Constants.CharPointer );
			
			return true;
		}

		public static long ReadValueLong( long Address ) {
			return mMemReader.readMemoryLong( Address );
		}

		public static Int32 ReadValueInt32( long Address ) {
			return mMemReader.readMemoryInt32( Address );
		}

		public static Int16 ReadValueInt16( long Address ) {
			return mMemReader.readMemoryInt16( Address );
		}






		public static void writeFutureX( float position ) {
			mMemReader.writeMemoryLong( Constants.CharPointer, (long)Constants.EOffsets.PositionFutureX, BitConverter.GetBytes( position ) );
		}

		public static void writeFutureY( float position ) {
			mMemReader.writeMemoryLong( Constants.CharPointer, (long)Constants.EOffsets.PositionFutureY, BitConverter.GetBytes( position ) );
		}

		public static void writeFutureZ( float position ) {
			mMemReader.writeMemoryLong( (long)Constants.EOffsets.PositionFutureZ, BitConverter.GetBytes( position ) );
		}

		public static void writeCharFloat( Constants.EOffsets Offset, float Value ) {
			mMemReader.writeMemoryLong( (long)Offset, BitConverter.GetBytes( Value ) );
		}


		public static void clickMouse() {
			AutoIt3.AU3_MouseClick( "left", AutoIt3.AU3_MouseGetPosX(), AutoIt3.AU3_MouseGetPosY(), 3, 5 );
		}

		public static void switchTarget( string key ) {
			pressKey( key, 0 );
		}

		public static void pressKey( string key ) {
			pressKey( key, 1 );
		}

		public static void pressKey( string key, int mode ) {
			AutoIt3.AU3_Send( key, mode );
		}

	}

}
