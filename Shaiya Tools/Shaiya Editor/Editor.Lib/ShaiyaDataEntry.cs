using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Editor.Lib {
	
	public class ShaiyaDataEntry : IDisposable {
		private ShaiyaDataEntryList mEntrys = new ShaiyaDataEntryList();
		private string mFilename = "";
		private bool mIsDir = false;
		private long mOffset = 0;
		private long mOffsetOffset = 0;
		private int mHOffset = 0;
		private int mLength = 0;
		private byte[] mBuffer = null;
		private byte[] mUnkownValue = new byte[ 4 ];
		private string mGuid = "";
		private string mParentGuid = "";
		private int mListIndex = -1;


		/// <summary>
		/// unique internal ID
		/// </summary>
		public string ID {
			get { return mGuid; }
		}

		/// <summary>
		/// unique ID from the Parent Folder
		/// </summary>
		public string ParentID {
			get { return mParentGuid; }
			set { mParentGuid = value; }
		}

		/// <summary>
		/// Index of the List of Entrys
		/// </summary>
		public int ListIndex {
			get { return mListIndex; }
			set { mListIndex = value; }
		}


		public ShaiyaDataEntry this[ int Index ] {
			get { return mEntrys[ Index ]; }
			set { mEntrys[ Index ] = value; }
		}

		/// <summary>
		/// List of Sub-Entrys, only filled if this is a Folder
		/// </summary>
		public ShaiyaDataEntryList Entrys {
			get { return mEntrys; }
			set { mEntrys = value; }
		}

		/// <summary>
		/// The Filename relative to /data/
		/// </summary>
		public string Filename {
			get { return mFilename; }
			set { mFilename = value; }
		}

		/// <summary>
		/// Is this a Folder?
		/// </summary>
		public bool IsDir {
			get { return mIsDir; }
			set { mIsDir = value; }
		}

		/// <summary>
		/// The Offset for the .saf Filedata (already contains the StartOffset and IS absolute!)
		/// </summary>
		public long Offset {
			get { return mOffset; }
			set { mOffset = value; }
		}

		/// <summary>
		/// Offset for the .sah Fileinfo
		/// </summary>
		public long OffsetOffset {
			get { return mOffsetOffset; }
			set { mOffsetOffset = value; }
		}

		/// <summary>
		/// dont know
		/// </summary>
		public int HOffset {
			get { return mHOffset; }
			set { mHOffset = value; }
		}

		/// <summary>
		/// Filedata length
		/// </summary>
		public int Length {
			get { return mLength; }
			set { mLength = value; }
		}

		/// <summary>
		/// Filedata, only for newly added or updated Files
		/// </summary>
		public byte[] Buffer {
			get { return mBuffer; }
			set { mBuffer = value; }
		}

		/// <summary>
		/// Todo..
		/// </summary>
		public byte[] UnkownValue {
			get { return mUnkownValue; }
			set { mUnkownValue = value; }
		}



		public ShaiyaDataEntry() {
			mGuid = Guid.NewGuid().ToString();
		}

		public ShaiyaDataEntry( string Name, bool Dir, long Off, int HOff, int Len ) {
			mGuid = Guid.NewGuid().ToString();

			mFilename = Name;
			mIsDir = Dir;
			mOffset = Off;
			mHOffset = HOff;
			mLength = Len;
		}



		public void Dispose() {
			mBuffer = null;

			if( mEntrys == null )
				return;
			for( int i = 0; i < mEntrys.Count; i++ )
				mEntrys[ i ].Dispose();
		}


		public override string ToString() {
			return string.Format( "{0}, IsDir={1}, Offset={2}({3}), Length={4}", Filename, IsDir, Offset, HOffset, Length );
		}
	}

}
