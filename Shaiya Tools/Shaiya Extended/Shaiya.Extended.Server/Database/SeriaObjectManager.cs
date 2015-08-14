using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shaiya.Extended.Server {

	public class SerialObjectManager {

		private Dictionary<ESerialType, Dictionary<int, SerialObject>> mUnits;

		public Dictionary<int, SerialObject> this[ ESerialType Type ] {
			get { return GetDictionary( Type ); }
		}



		public SerialObjectManager() {
			mUnits = new Dictionary<ESerialType, Dictionary<int, SerialObject>>();
		}


		public SerialObject Get( Serial Key ) {
			SerialObject u;
			Dictionary<int, SerialObject> dic = GetDictionary( Key.Type );
			if( dic.TryGetValue( Key, out u ) == true )
				return u;

			return null;
		}

		public SerialObject Get( ESerialType Type, int Key ) {
			SerialObject u;
			Dictionary<int, SerialObject> dic = GetDictionary( Type );
			if( dic.TryGetValue( Key, out u ) == true )
				return u;

			return null;
		}

		public bool Add( SerialObject u ) {
			Dictionary<int, SerialObject> dic = GetDictionary( u.Serial.Type );
			if( dic.ContainsKey( u.Serial ) == false ) {
				dic.Add( u.Serial, u );
				return true;
			}

			return false;
		}

		public bool Remove( SerialObject u ) {
			Dictionary<int, SerialObject> dic = GetDictionary( u.Serial.Type );
			if( dic.ContainsKey( u.Serial ) == true ) {
				dic.Remove( u.Serial );
				return true;
			}

			return false;
		}

		public bool Replace( SerialObject oldObj, SerialObject newObj ) {
			if( oldObj != null && newObj != null ) {
				if( oldObj.Serial.Type != newObj.Serial.Type )
					return false;

				Dictionary<int, SerialObject> dic = GetDictionary( oldObj.Serial.Type );
				if( dic.ContainsKey( oldObj.Serial ) == true )
					dic[ oldObj.Serial ] = newObj;
				else
					dic.Add( newObj.Serial, newObj );

				return true;
			}

			if( oldObj != null ) {
				Dictionary<int, SerialObject> dic = GetDictionary( oldObj.Serial.Type );
				dic.Remove( oldObj.Serial );

				return true;
			}

			if( newObj != null ) {
				Dictionary<int, SerialObject> dic = GetDictionary( newObj.Serial.Type );
				dic.Add( newObj.Serial, newObj );

				return true;
			}

			return false;
		}

		public int Count( ESerialType Type ) {
			Dictionary<int, SerialObject> dic = GetDictionary( Type );
			return dic.Count;
		}




		public Dictionary<int, SerialObject> GetDictionary( ESerialType eSerialType ) {
			if( mUnits.ContainsKey( eSerialType ) == false )
				mUnits.Add( eSerialType, new Dictionary<int, SerialObject>() );

			return mUnits[ eSerialType ];
		}

	}

}
