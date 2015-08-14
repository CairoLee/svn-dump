using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Rendering;

namespace eACGUI {
	partial class AboutBox : Office2007Form {
		public AboutBox( string Description ) {
			InitializeComponent();
			this.Text = String.Format( "Über {0}", Tools.AssemblyTitle );
			this.labelProductName.Text = String.Format( "{0} - Version {1}", Tools.AssemblyProduct, Tools.AssemblyVersion );
			this.labelCopyright.Text = Tools.AssemblyCopyright;
			this.textBoxDescription.Text = Description;
		}


		private void okButton_Click( object sender, EventArgs e ) {
			Close();
		}
	}
}
