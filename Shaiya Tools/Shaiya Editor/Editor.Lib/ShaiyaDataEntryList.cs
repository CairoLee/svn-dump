using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Editor.Lib {

	public class ShaiyaDataEntryList : List<ShaiyaDataEntry> {

		public ShaiyaDataEntry GetEntry( string ID ) {
			return SearchName( ID, this );
		}

		public bool UpdateEntry( string ID, ShaiyaDataEntry NewEntry ) {
			return _UpdateEntry( ID, NewEntry, this );
		}



		private bool _UpdateEntry( string ID, ShaiyaDataEntry NewEntry, ShaiyaDataEntryList List ) {
			bool returnResult = false;

			for( int i = 0; i < List.Count; i++ ) {
				if( List[ i ].ID == ID ) {
					List[ i ] = NewEntry;
					return true;
				}

				if( List[ i ].IsDir == false )
					continue;
				if( ( returnResult = _UpdateEntry( ID, NewEntry, List[ i ].Entrys ) ) == true ) 
					return true;
			}

			return false;
		}

		private ShaiyaDataEntry SearchName( string ID, ShaiyaDataEntryList List ) {
			ShaiyaDataEntry e = null;

			for( int i = 0; i < List.Count; i++ ) {
				if( List[ i ].ID == ID )
					return List[ i ];
				if( List[ i ].IsDir == false )
					continue;

				if( ( e = SearchName( ID, List[ i ].Entrys ) ) != null )
					return e;
			}

			return null;
		}


	}

}
