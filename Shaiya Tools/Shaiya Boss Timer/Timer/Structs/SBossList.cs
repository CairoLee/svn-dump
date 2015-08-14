using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Sbt.Structs {

	[Serializable]
	[XmlRoot( ElementName = "BossList" )]
	public class SBossList : IList<SBoss> {
		private List<SBoss> mBossList = new List<SBoss>();



		public SBoss this[ int index ] {
			get { return mBossList[ index ]; }
			set { mBossList[ index ] = value; }
		}

		public int Count {
			get { return mBossList.Count; }
		}

		public bool IsReadOnly {
			get { return false; }
		}



		public SBossList() {
		}




		public int IndexOf( SBoss item ) {
			return mBossList.IndexOf( item );
		}

		public void Insert( int index, SBoss item ) {
			mBossList.Insert( index, item );
		}

		public void RemoveAt( int index ) {
			mBossList.RemoveAt( index );
		}



		public void Add( SBoss item ) {
			mBossList.Add( item );
		}

		public void Clear() {
			mBossList.Clear();
		}

		public bool Contains( SBoss item ) {
			return mBossList.Contains( item );
		}

		public void CopyTo( SBoss[] array, int arrayIndex ) {
			mBossList.CopyTo( array, arrayIndex );
		}

		public bool Remove( SBoss item ) {
			return mBossList.Remove( item );
		}

		public IEnumerator<SBoss> GetEnumerator() {
			return mBossList.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

	}

}
