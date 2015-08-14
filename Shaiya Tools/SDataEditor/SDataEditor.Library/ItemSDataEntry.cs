using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDataEditor.Library {

	public class ItemSDataEntry {
		public string Text1;
		public string Text2;

		public short MinLv;
		public byte Quality;
		public short Haltbarkeit;
		public short Eff1;
		public short Eff2;
		public short Eff3;
		public short Eff4;
		public short ConstHP;
		public short ConstSP;
		public short ConstMP;
		public short ConstSTR;
		public short ConstGES;
		public short ConstABW;
		public short ConstINT;
		public short ConstWEI;
		public short ConstGLU;
		public int Preis;

		public int[] IntValues;


		public object[] ToRow( int RowNum ) {
			List<object> obj = new List<object>();

			obj.Add( RowNum );
			obj.Add( Text1 );
			obj.Add( Text2 );

			obj.Add( MinLv );
			obj.Add( (EItemQuality)Quality );
			obj.Add( Haltbarkeit );
			obj.Add( Eff1 );
			obj.Add( Eff2 );
			obj.Add( Eff3 );
			obj.Add( Eff4 );
			obj.Add( ConstHP );
			obj.Add( ConstSP );
			obj.Add( ConstMP );
			obj.Add( ConstSTR );
			obj.Add( ConstGES );
			obj.Add( ConstABW );
			obj.Add( ConstINT );
			obj.Add( ConstWEI );
			obj.Add( ConstGLU );
			obj.Add( Preis );

			if( IntValues != null )
				for( int i = 0; i < IntValues.Length; i++ )
					obj.Add( IntValues[ i ] );

			return obj.ToArray();
		}

	}


	public enum EItemQuality {
		Normal = 0,

		Edel = 1,
		Anbeter = 2,
		Helden = 3,
		Schrecken = 4,
		Ahnen = 5,
		Göttinnen = 6
	}


}
