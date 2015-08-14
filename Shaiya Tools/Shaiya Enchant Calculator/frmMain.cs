using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shaiya_Enchant_Calculator {

	public partial class frmMain : Form {
		private int[] mChanceList = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };


		public frmMain() {
			InitializeComponent();
		}

		#region MenuProgram
		private void MenuProgramClose_Click( object sender, EventArgs e ) {
			this.Close();
		}
		#endregion


		#region frmMain Events
		private void frmMain_Load( object sender, EventArgs e ) {
			cmbType.SelectedIndex = 0;
			cmbTrycount.SelectedIndex = 0;
			// apply all Numbers from 0 to 19
			for( int i = 0; i < mChanceList.Length - 1; i++ )
				cmbFrom.Items.Add( mChanceList[ i ] );
		}
		#endregion

		#region link Events
		private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e ) {
			System.Diagnostics.Process.Start( "http://forums.aeriagames.com/viewtopic.php?t=612427" );
		}
		#endregion

		#region cmb Events
		private void cmbFrom_SelectedIndexChanged( object sender, EventArgs e ) {
			ApplyList( cmbFrom.SelectedIndex + 1 );
		}

		private void cmbTo_SelectedIndexChanged( object sender, EventArgs e ) {
			CalcResult();
		} 
		#endregion

		private void btnCalc_Click( object sender, EventArgs e ) {
			CalcResult();
		}



		private void CalcResult() {
		}

		private void ApplyList( int From ) {
			cmbTo.Items.Clear();
			for( int i = From; i < mChanceList.Length; i++ ) {
				cmbTo.Items.Add( mChanceList[ i ].ToString() );
			}

			cmbTo.SelectedIndex = 0;
			cmbTo.Enabled = true;
			btnCalc.Enabled = true;
		}


	}

}
