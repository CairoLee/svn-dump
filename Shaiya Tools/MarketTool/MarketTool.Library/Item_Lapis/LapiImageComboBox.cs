using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MarketTool.Library {

	public class LapiImageComboBox : ImageComboBox {
		public static LapiCollection Lapis {
			get;
			private set;
		}



		public LapiImageComboBox()
			: base() {

			if( Lapis == null ) {
				Lapis = new LapiCollection();
				BuildLapiList();
			}

			// empty_slot
			Items.Add( new ImageComboItem( "", Font, System.Drawing.Color.Black, 0, EImageComboItemTextAlign.Right ) );
			// fill Combolist with Lapi Images
			foreach( Lapi lapi in Lapis ) {
				ImageComboItem i = new ImageComboItem( "", Font, System.Drawing.Color.Black, lapi.ToImageIndex() + 1, EImageComboItemTextAlign.Right );
				i.Tag = lapi;
				Items.Add( i );
			}
		}



		private static void BuildLapiList() {
			Lapis.Add( new Lapi( ELapi.STR, 1 ) );
			Lapis.Add( new Lapi( ELapi.INT, 1 ) );
			Lapis.Add( new Lapi( ELapi.WEI, 1 ) );
			Lapis.Add( new Lapi( ELapi.ABW, 1 ) );
			Lapis.Add( new Lapi( ELapi.GES, 1 ) );
			Lapis.Add( new Lapi( ELapi.GLÜ, 1 ) );

			Lapis.Add( new Lapi( ELapi.LP, 1 ) );
			Lapis.Add( new Lapi( ELapi.MP, 1 ) );
			Lapis.Add( new Lapi( ELapi.AP, 1 ) );

			Lapis.Add( new Lapi( ELapi.HALT, 1 ) );

			Lapis.Add( new Lapi( ELapi.GEIST, 1 ) );
			Lapis.Add( new Lapi( ELapi.VER, 1 ) );
			Lapis.Add( new Lapi( ELapi.ANG, 1 ) );
			Lapis.Add( new Lapi( ELapi.MaxANG, 1 ) );

			Lapis.Add( new Lapi( ELapi.BLITZ, 1 ) );

			Lapis.Add( new Lapi( ELapi.ELEMENTANG, 0 ) );
			Lapis.Add( new Lapi( ELapi.ELEMENTANG, 1 ) );
			Lapis.Add( new Lapi( ELapi.ELEMENTANG, 2 ) );
			Lapis.Add( new Lapi( ELapi.ELEMENTANG, 3 ) );

			Lapis.Add( new Lapi( ELapi.DEBUFF1, 0 ) );

			Lapis.Add( new Lapi( ELapi.DEBUFF2, 0 ) );

			Lapis.Add( new Lapi( ELapi.ANTIDEBUFF, 0 ) );
		}

	}

}
