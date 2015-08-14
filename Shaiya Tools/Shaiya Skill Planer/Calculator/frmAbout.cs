using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Ssc {
	partial class frmAbout : Form {

		public frmAbout() {
			InitializeComponent();
			this.Text = String.Format( "About {0}", AssemblyTitle );
		}


		private void okButton_Click( object sender, EventArgs e ) {
			Close();
		}



		public string AssemblyTitle {
			get {
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyTitleAttribute ), false );
				if( customAttributes.Length > 0 ) {
					AssemblyTitleAttribute attribute = (AssemblyTitleAttribute)customAttributes[ 0 ];
					if( attribute.Title != "" )
						return attribute.Title;
				}
				return System.IO.Path.GetFileNameWithoutExtension( Assembly.GetExecutingAssembly().CodeBase );
			}
		}


	}

}
