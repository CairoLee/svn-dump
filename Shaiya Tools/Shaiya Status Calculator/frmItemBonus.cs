using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ssc {

	public partial class frmItemBonus : Form {
		private int mBonusCount = 0;
		private string[] mComboValues;

		public frmItemBonus( SItem Item, string ItemType ) {
			InitializeComponent();

			this.Text += ItemType;
			if( Item.Name != string.Empty )
				this.Text += " [" + Item.Name + "]";
			mComboValues = Enum.GetNames( typeof( EItemBonus ) );

			numSockel.Value = Item.Sockel;
			txtName.Text = Item.Name;
			for( int i = 0; i < Item.Bonus.Count; i++ ) {
				AddControlRow();

				( this.Controls[ "cb" + i ] as ComboBox ).SelectedIndex = (int)Item.Bonus[ i ].Type;
				( this.Controls[ "num" + i ] as NumericUpDown ).Value = Item.Bonus[ i ].Value;
			}

			mBonusCount = Item.Bonus.Count;
		}

		private void frmItemBonus_Load( object sender, EventArgs e ) {
			if( mBonusCount == 0 )
				btnAddBonus.PerformClick();
		}

		private void Button_Click( object sender, EventArgs e ) {
			this.Close();
		}

		private void btnAddBonus_Click( object sender, EventArgs e ) {
			AddControlRow();
		}

		public List<SItemBonus> GetBonusList() {
			List<SItemBonus> bonus = new List<SItemBonus>();
			for( int i = 0; i < mBonusCount; i++ ) {
				SItemBonus b = new SItemBonus();
				b.Type = (EItemBonus)( Controls[ "cb" + i ] as ComboBox ).SelectedIndex;
				b.Value = (int)( Controls[ "num" + i ] as NumericUpDown ).Value;
				
				if( b.Value == 0 )
					continue;

				bonus.Add( b );
			}

			return bonus;
		}




		private void AddControlRow() {
			int yMod = mBonusCount + 1;

			Label lbl = new Label();
			lbl.AutoSize = true;
			lbl.Location = new System.Drawing.Point( 12, 30 + ( 37 * yMod ) + 7 + 3 );
			lbl.Name = "lbl" + mBonusCount;
			lbl.Size = new System.Drawing.Size( 46, 13 );
			lbl.Text = "Bonus " + ( mBonusCount + 1 );

			ComboBox com = new ComboBox();
			com.FormattingEnabled = true;
			com.Location = new System.Drawing.Point( 64, 30 + ( 37 * yMod ) + 7 );
			com.Name = "cb" + mBonusCount;
			com.Size = new System.Drawing.Size( 79, 21 );
			com.Items.AddRange( mComboValues );
			com.SelectedIndex = 0;

			NumericUpDown num = new NumericUpDown();
			num.Location = new System.Drawing.Point( 149, 30 + ( 37 * yMod ) + 7 );
			num.Name = "num" + mBonusCount;
			num.Size = new System.Drawing.Size( 52, 20 );
			num.Minimum = -1000;
			num.Maximum = 1000;
			num.Value = 0;

			this.Controls.Add( lbl );
			this.Controls.Add( num );
			this.Controls.Add( com );

			this.Height = 145 + ( yMod * 37 );

			mBonusCount++;
		}

	}

}
