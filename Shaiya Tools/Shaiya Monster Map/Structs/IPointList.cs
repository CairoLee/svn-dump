using System;
using System.Collections.Generic;
using System.Text;

using ShaiyaMonsterMap.Enumerations;

namespace ShaiyaMonsterMap {

	public partial class IPointList : ICollection<IPoint> {
		private List<IPoint> mPoints = new List<IPoint>();

		public IPoint this[ int i ] {
			get { return mPoints[ i ]; }
			set { mPoints[ i ] = value; }
		}

		public EMap Map {
			get;
			set;
		}

		public List<IPoint> Points {
			get { return mPoints; }
			set { mPoints = value; }
		}



		public void Add( IPoint item ) {
			mPoints.Add( item );
		}

		public void Clear() {
			mPoints.Clear();
		}

		public bool Contains( IPoint item ) {
			return mPoints.Contains( item );
		}

		public void CopyTo( IPoint[] array, int arrayIndex ) {
			mPoints.CopyTo( array, arrayIndex );
		}

		public int Count {
			get { return mPoints.Count; }
		}

		public bool IsReadOnly {
			get { return false; }
		}

		public bool Remove( IPoint item ) {
			return mPoints.Remove( item );
		}

		public void RemoveAt( int i ) {
			mPoints.RemoveAt( i );
		}

		public IEnumerator<IPoint> GetEnumerator() {
			return mPoints.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

	}

}
