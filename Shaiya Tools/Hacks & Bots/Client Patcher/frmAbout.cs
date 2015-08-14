using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace ClientPatcher {
	partial class frmAbout : Form {

		public frmAbout( string Description ) {
			InitializeComponent();
			this.Text = String.Format( "Über {0}", AssemblyTitle );
			this.labelProductName.Text = String.Format( "{0} - Version {1}", AssemblyProduct, AssemblyVersion );
			this.labelCopyright.Text = AssemblyCopyright;
			this.textBoxDescription.Text = Description;
		}


		private void okButton_Click( object sender, EventArgs e ) {
			Close();
		}


		public string AssemblyCompany {
			get {
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyCompanyAttribute ), false );
				if( customAttributes.Length == 0 ) 
					return "";
				return ( (AssemblyCompanyAttribute)customAttributes[ 0 ] ).Company;
			}
		}

		public string AssemblyCopyright {
			get {
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyCopyrightAttribute ), false );
				if( customAttributes.Length == 0 ) 
					return "";
				return ( (AssemblyCopyrightAttribute)customAttributes[ 0 ] ).Copyright;
			}
		}

		public string AssemblyDescription {
			get {
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyDescriptionAttribute ), false );
				if( customAttributes.Length == 0 ) 
					return "";
				return ( (AssemblyDescriptionAttribute)customAttributes[ 0 ] ).Description;
			}
		}

		public string AssemblyProduct {
			get {
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyProductAttribute ), false );
				if( customAttributes.Length == 0 ) 
					return "";
				return ( (AssemblyProductAttribute)customAttributes[ 0 ] ).Product;
			}
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

		public string AssemblyVersion {
			get {				return Assembly.GetExecutingAssembly().GetName().Version.ToString();			}
		}

	}

}
