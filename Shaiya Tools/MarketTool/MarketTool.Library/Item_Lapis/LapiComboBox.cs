using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MarketTool.Library {

	public class LapiComboBox : ImageComboBox {
		public static LapiCollection Lapis {
			get;
			private set;
		}

		private Label mLapiDesc = null;

		public Label LapiDesc {
			get { return mLapiDesc; }
			set {
				mLapiDesc = value;
				if( value != null && SelectedIndex < 0 )
					SelectedIndex = 0; // we have a label, set default Index
			}
		}


		public LapiComboBox()
			: base() {

			if( Lapis == null ) {
				Lapis = new LapiCollection();
				BuildLapiList();
			}

			//Items.Add( new ImageComboItem( "freier Sockel", Font, System.Drawing.Color.Black, 0, EImageComboItemTextAlign.Right ) );
			// fill Combolist with Lapis
			foreach( Lapi lapi in Lapis ) {
				ImageComboItem i = new ImageComboItem( lapi.ToName(), Font, System.Drawing.Color.Black, lapi.ToImageIndex() + 1, EImageComboItemTextAlign.Right );
				i.Tag = lapi;
				Items.Add( i );
			}

			SelectedIndexChanged += new EventHandler( LapiComboBox_SelectedIndexChanged );
		}


		private void LapiComboBox_SelectedIndexChanged( object sender, EventArgs e ) {
			if( mLapiDesc == null )
				return;
			if( SelectedIndex < 0 ) {
				mLapiDesc.Text = "";
				return;
			}
			if( SelectedIndex == 0 ) {
				mLapiDesc.Text = "<frei>";
				return;
			}

			mLapiDesc.Text = ( ( SelectedItem as ImageComboItem ).Tag as Lapi ).ToEffect();
		}


		private static void BuildLapiList() {
			Lapis.Add( new Lapi( ELapi.STR, 1 ) );
			Lapis.Add( new Lapi( ELapi.STR, 2 ) );
			Lapis.Add( new Lapi( ELapi.STR, 3 ) );
			Lapis.Add( new Lapi( ELapi.STR, 4 ) );
			Lapis.Add( new Lapi( ELapi.STR, 5 ) );
			Lapis.Add( new Lapi( ELapi.STR, 6 ) );
			Lapis.Add( new Lapi( ELapi.STR, 7 ) );
			Lapis.Add( new Lapi( ELapi.DUALSTR, 1 ) );
			Lapis.Add( new Lapi( ELapi.DUALSTR, 2 ) );
			Lapis.Add( new Lapi( ELapi.DUALSTR, 3 ) );
			Lapis.Add( new Lapi( ELapi.DUALSTR, 4 ) );
			Lapis.Add( new Lapi( ELapi.SCHMUCKSTR, 0 ) );
			Lapis.Add( new Lapi( ELapi.SCHMUCKSTR, 1 ) );

			Lapis.Add( new Lapi( ELapi.INT, 1 ) );
			Lapis.Add( new Lapi( ELapi.INT, 2 ) );
			Lapis.Add( new Lapi( ELapi.INT, 3 ) );
			Lapis.Add( new Lapi( ELapi.INT, 4 ) );
			Lapis.Add( new Lapi( ELapi.INT, 5 ) );
			Lapis.Add( new Lapi( ELapi.INT, 6 ) );
			Lapis.Add( new Lapi( ELapi.INT, 7 ) );
			Lapis.Add( new Lapi( ELapi.DUALINT, 1 ) );
			Lapis.Add( new Lapi( ELapi.DUALINT, 2 ) );
			Lapis.Add( new Lapi( ELapi.DUALINT, 3 ) );
			Lapis.Add( new Lapi( ELapi.DUALINT, 4 ) );
			Lapis.Add( new Lapi( ELapi.SCHMUCKINT, 0 ) );
			Lapis.Add( new Lapi( ELapi.SCHMUCKINT, 1 ) );

			Lapis.Add( new Lapi( ELapi.WEI, 1 ) );
			Lapis.Add( new Lapi( ELapi.WEI, 2 ) );
			Lapis.Add( new Lapi( ELapi.WEI, 3 ) );
			Lapis.Add( new Lapi( ELapi.WEI, 4 ) );
			Lapis.Add( new Lapi( ELapi.WEI, 5 ) );
			Lapis.Add( new Lapi( ELapi.WEI, 6 ) );
			Lapis.Add( new Lapi( ELapi.WEI, 7 ) );
			Lapis.Add( new Lapi( ELapi.DUALWEI, 1 ) );
			Lapis.Add( new Lapi( ELapi.DUALWEI, 2 ) );
			Lapis.Add( new Lapi( ELapi.DUALWEI, 3 ) );
			Lapis.Add( new Lapi( ELapi.DUALWEI, 4 ) );
			Lapis.Add( new Lapi( ELapi.SCHMUCKWEI, 0 ) );
			Lapis.Add( new Lapi( ELapi.SCHMUCKWEI, 1 ) );

			Lapis.Add( new Lapi( ELapi.ABW, 1 ) );
			Lapis.Add( new Lapi( ELapi.ABW, 2 ) );
			Lapis.Add( new Lapi( ELapi.ABW, 3 ) );
			Lapis.Add( new Lapi( ELapi.ABW, 4 ) );
			Lapis.Add( new Lapi( ELapi.ABW, 5 ) );
			Lapis.Add( new Lapi( ELapi.ABW, 6 ) );
			Lapis.Add( new Lapi( ELapi.ABW, 7 ) );
			Lapis.Add( new Lapi( ELapi.DUALABW, 1 ) );
			Lapis.Add( new Lapi( ELapi.DUALABW, 2 ) );
			Lapis.Add( new Lapi( ELapi.DUALABW, 3 ) );
			Lapis.Add( new Lapi( ELapi.DUALABW, 4 ) );
			Lapis.Add( new Lapi( ELapi.SCHMUCKABW, 0 ) );
			Lapis.Add( new Lapi( ELapi.SCHMUCKABW, 1 ) );

			Lapis.Add( new Lapi( ELapi.GES, 1 ) );
			Lapis.Add( new Lapi( ELapi.GES, 2 ) );
			Lapis.Add( new Lapi( ELapi.GES, 3 ) );
			Lapis.Add( new Lapi( ELapi.GES, 4 ) );
			Lapis.Add( new Lapi( ELapi.GES, 5 ) );
			Lapis.Add( new Lapi( ELapi.GES, 6 ) );
			Lapis.Add( new Lapi( ELapi.GES, 7 ) );
			Lapis.Add( new Lapi( ELapi.DUALGES, 1 ) );
			Lapis.Add( new Lapi( ELapi.DUALGES, 2 ) );
			Lapis.Add( new Lapi( ELapi.DUALGES, 3 ) );
			Lapis.Add( new Lapi( ELapi.DUALGES, 4 ) );
			Lapis.Add( new Lapi( ELapi.SCHMUCKGES, 0 ) );
			Lapis.Add( new Lapi( ELapi.SCHMUCKGES, 1 ) );

			Lapis.Add( new Lapi( ELapi.GLÜ, 1 ) );
			Lapis.Add( new Lapi( ELapi.GLÜ, 2 ) );
			Lapis.Add( new Lapi( ELapi.GLÜ, 3 ) );
			Lapis.Add( new Lapi( ELapi.GLÜ, 4 ) );
			Lapis.Add( new Lapi( ELapi.GLÜ, 5 ) );
			Lapis.Add( new Lapi( ELapi.GLÜ, 6 ) );
			Lapis.Add( new Lapi( ELapi.GLÜ, 7 ) );
			Lapis.Add( new Lapi( ELapi.DUALGLÜ, 1 ) );
			Lapis.Add( new Lapi( ELapi.DUALGLÜ, 2 ) );
			Lapis.Add( new Lapi( ELapi.DUALGLÜ, 3 ) );
			Lapis.Add( new Lapi( ELapi.DUALGLÜ, 4 ) );
			Lapis.Add( new Lapi( ELapi.SCHMUCKGLÜ, 0 ) );
			Lapis.Add( new Lapi( ELapi.SCHMUCKGLÜ, 1 ) );

			Lapis.Add( new Lapi( ELapi.LP, 1 ) );
			Lapis.Add( new Lapi( ELapi.LP, 2 ) );
			Lapis.Add( new Lapi( ELapi.LP, 3 ) );
			Lapis.Add( new Lapi( ELapi.LP, 4 ) );
			Lapis.Add( new Lapi( ELapi.LP, 5 ) );
			Lapis.Add( new Lapi( ELapi.LP, 6 ) );
			Lapis.Add( new Lapi( ELapi.LP, 7 ) );

			Lapis.Add( new Lapi( ELapi.MP, 1 ) );
			Lapis.Add( new Lapi( ELapi.MP, 2 ) );
			Lapis.Add( new Lapi( ELapi.MP, 3 ) );
			Lapis.Add( new Lapi( ELapi.MP, 4 ) );
			Lapis.Add( new Lapi( ELapi.MP, 5 ) );
			Lapis.Add( new Lapi( ELapi.MP, 6 ) );
			Lapis.Add( new Lapi( ELapi.MP, 7 ) );

			Lapis.Add( new Lapi( ELapi.AP, 1 ) );
			Lapis.Add( new Lapi( ELapi.AP, 2 ) );
			Lapis.Add( new Lapi( ELapi.AP, 3 ) );
			Lapis.Add( new Lapi( ELapi.AP, 4 ) );
			Lapis.Add( new Lapi( ELapi.AP, 5 ) );
			Lapis.Add( new Lapi( ELapi.AP, 6 ) );
			Lapis.Add( new Lapi( ELapi.AP, 7 ) );

			Lapis.Add( new Lapi( ELapi.VER, 1 ) );
			Lapis.Add( new Lapi( ELapi.VER, 2 ) );
			Lapis.Add( new Lapi( ELapi.VER, 3 ) );
			Lapis.Add( new Lapi( ELapi.VER, 4 ) );
			Lapis.Add( new Lapi( ELapi.VER, 5 ) );
			Lapis.Add( new Lapi( ELapi.VER, 6 ) );
			Lapis.Add( new Lapi( ELapi.VER, 7 ) );

			Lapis.Add( new Lapi( ELapi.ANG, 1 ) );
			Lapis.Add( new Lapi( ELapi.ANG, 2 ) );
			Lapis.Add( new Lapi( ELapi.ANG, 3 ) );
			Lapis.Add( new Lapi( ELapi.ANG, 4 ) );
			Lapis.Add( new Lapi( ELapi.ANG, 5 ) );
			Lapis.Add( new Lapi( ELapi.ANG, 6 ) );
			Lapis.Add( new Lapi( ELapi.ANG, 7 ) );

			Lapis.Add( new Lapi( ELapi.HALT, 1 ) );
			Lapis.Add( new Lapi( ELapi.HALT, 2 ) );
			Lapis.Add( new Lapi( ELapi.HALT, 3 ) );
			Lapis.Add( new Lapi( ELapi.HALT, 4 ) );
			Lapis.Add( new Lapi( ELapi.HALT, 5 ) );
			Lapis.Add( new Lapi( ELapi.HALT, 6 ) );
			Lapis.Add( new Lapi( ELapi.HALT, 7 ) );

			Lapis.Add( new Lapi( ELapi.GEIST, 1 ) );
			Lapis.Add( new Lapi( ELapi.GEIST, 2 ) );
			Lapis.Add( new Lapi( ELapi.GEIST, 3 ) );
			Lapis.Add( new Lapi( ELapi.GEIST, 4 ) );
			Lapis.Add( new Lapi( ELapi.GEIST, 5 ) );
			Lapis.Add( new Lapi( ELapi.GEIST, 6 ) );
			Lapis.Add( new Lapi( ELapi.GEIST, 7 ) );

			Lapis.Add( new Lapi( ELapi.VOLLENDUNG, 1 ) );
			Lapis.Add( new Lapi( ELapi.VOLLENDUNG, 3 ) );

			Lapis.Add( new Lapi( ELapi.BLITZ, 1 ) );
			Lapis.Add( new Lapi( ELapi.BLITZ, 2 ) );

			Lapis.Add( new Lapi( ELapi.FLINK, 1 ) );
			Lapis.Add( new Lapi( ELapi.FLINK, 2 ) );

			Lapis.Add( new Lapi( ELapi.ELEMENTANG, 0 ) );
			Lapis.Add( new Lapi( ELapi.ELEMENTANG, 1 ) );
			Lapis.Add( new Lapi( ELapi.ELEMENTANG, 2 ) );
			Lapis.Add( new Lapi( ELapi.ELEMENTANG, 3 ) );

			Lapis.Add( new Lapi( ELapi.ELEMENTDEF, 0 ) );
			Lapis.Add( new Lapi( ELapi.ELEMENTDEF, 1 ) );
			Lapis.Add( new Lapi( ELapi.ELEMENTDEF, 2 ) );
			Lapis.Add( new Lapi( ELapi.ELEMENTDEF, 3 ) );

			Lapis.Add( new Lapi( ELapi.DEBUFF1, 0 ) );
			Lapis.Add( new Lapi( ELapi.DEBUFF1, 1 ) );
			Lapis.Add( new Lapi( ELapi.DEBUFF1, 2 ) );
			Lapis.Add( new Lapi( ELapi.DEBUFF1, 3 ) );
			Lapis.Add( new Lapi( ELapi.DEBUFF1, 4 ) );
			Lapis.Add( new Lapi( ELapi.DEBUFF1, 5 ) );
			Lapis.Add( new Lapi( ELapi.DEBUFF1, 6 ) );
			Lapis.Add( new Lapi( ELapi.DEBUFF1, 7 ) );
			Lapis.Add( new Lapi( ELapi.DEBUFF1, 8 ) );
			Lapis.Add( new Lapi( ELapi.DEBUFF1, 9 ) );
			Lapis.Add( new Lapi( ELapi.DEBUFF1, 10 ) );
			Lapis.Add( new Lapi( ELapi.DEBUFF1, 11 ) );
			Lapis.Add( new Lapi( ELapi.DEBUFF1, 12 ) );

			Lapis.Add( new Lapi( ELapi.DEBUFF2, 0 ) );
			Lapis.Add( new Lapi( ELapi.DEBUFF2, 1 ) );
			Lapis.Add( new Lapi( ELapi.DEBUFF2, 2 ) );
			Lapis.Add( new Lapi( ELapi.DEBUFF2, 3 ) );
			Lapis.Add( new Lapi( ELapi.DEBUFF2, 4 ) );
			Lapis.Add( new Lapi( ELapi.DEBUFF2, 5 ) );
			Lapis.Add( new Lapi( ELapi.DEBUFF2, 6 ) );
			Lapis.Add( new Lapi( ELapi.DEBUFF2, 7 ) );
			Lapis.Add( new Lapi( ELapi.DEBUFF2, 8 ) );
			Lapis.Add( new Lapi( ELapi.DEBUFF2, 9 ) );
			Lapis.Add( new Lapi( ELapi.DEBUFF2, 10 ) );
			Lapis.Add( new Lapi( ELapi.DEBUFF2, 11 ) );
			Lapis.Add( new Lapi( ELapi.DEBUFF2, 12 ) );
			Lapis.Add( new Lapi( ELapi.DEBUFF2, 13 ) );
			Lapis.Add( new Lapi( ELapi.DEBUFF2, 14 ) );

			Lapis.Add( new Lapi( ELapi.ANTIDEBUFF, 0 ) );
			Lapis.Add( new Lapi( ELapi.ANTIDEBUFF, 1 ) );
			Lapis.Add( new Lapi( ELapi.ANTIDEBUFF, 2 ) );
			Lapis.Add( new Lapi( ELapi.ANTIDEBUFF, 3 ) );
			Lapis.Add( new Lapi( ELapi.ANTIDEBUFF, 4 ) );
			Lapis.Add( new Lapi( ELapi.ANTIDEBUFF, 5 ) );
			Lapis.Add( new Lapi( ELapi.ANTIDEBUFF, 6 ) );
			Lapis.Add( new Lapi( ELapi.ANTIDEBUFF, 7 ) );
			Lapis.Add( new Lapi( ELapi.ANTIDEBUFF, 8 ) );
			Lapis.Add( new Lapi( ELapi.ANTIDEBUFF, 9 ) );
			Lapis.Add( new Lapi( ELapi.ANTIDEBUFF, 10 ) );
			Lapis.Add( new Lapi( ELapi.ANTIDEBUFF, 11 ) );
			Lapis.Add( new Lapi( ELapi.ANTIDEBUFF, 12 ) );
			Lapis.Add( new Lapi( ELapi.ANTIDEBUFF, 13 ) );
			Lapis.Add( new Lapi( ELapi.ANTIDEBUFF, 14 ) );
		}

	}

}
