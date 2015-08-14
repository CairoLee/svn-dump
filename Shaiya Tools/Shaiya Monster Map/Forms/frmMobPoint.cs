using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ShaiyaMonsterMap.Forms {

	public partial class frmMobPoint : Form {

		public frmMobPoint( string TitleType ) {
			InitializeComponent();

			this.Cursor = frmMain.ShaiyaCursor;
			this.Text += " " + TitleType;
			foreach( string name in Enum.GetNames( typeof( ShaiyaMonsterMap.Enumerations.EMobElement ) ) )
				cbElement.Items.Add( name );
			cbElement.SelectedIndex = 0;
			cbCount.SelectedIndex = 0;
		}


		public static int CountToInt( string Count ) {
			switch( Count ) {
				case "wenig (1-5)":
					return 1;
				case "mittel (5-10)":
					return 2;
				case "viele (10-15)":
					return 3;
				case "sehr viele (15+)":
					return 4;
				case "1 (Boss)":
					return 5;
				default:
					return 1;
			}
		}

	}

}
