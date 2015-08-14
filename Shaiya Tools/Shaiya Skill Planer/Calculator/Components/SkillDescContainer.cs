using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Ssc.Components {

	public partial class SkillDescContainer : UserControl {

		public SkillDescContainer() {
			InitializeComponent();
		}


		public void Clear() {
			this.Controls.Clear();
		}

		public void RefreshSkillInfo( SkillControl SkillPanel ) {
			Clear();

			SkillDescControl lastControl = null;
			int heightUntil = 5;
			for( int i = 0; i < SkillPanel.SkillLevel.Length; i++ ) {
				lastControl = new SkillDescControl();
				lastControl.SetSkillDesc( SkillPanel, i );
				lastControl.Location = new Point( 5, heightUntil );
				heightUntil += lastControl.Height + 5;

				this.Controls.Add( lastControl );
			}

			if( lastControl == null ) // huh? o.o
				return;

			if( this.Width < lastControl.Width + 10 )
				this.Width = lastControl.Width + 10;
			if( this.Height < heightUntil )
				this.Height = heightUntil;
		}

	}

}
