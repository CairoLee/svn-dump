using System;
using System.Diagnostics;
using System.Reflection;
using System.Drawing;
using DevComponents.DotNetBar.Controls;


namespace eACGUI {

	public class Tools {
		public static string AssemblyTitle {
			get {
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyTitleAttribute ), false );
				if( attributes.Length > 0 ) {
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[ 0 ];
					if( titleAttribute.Title != "" )
						return titleAttribute.Title;
				}
				return System.IO.Path.GetFileNameWithoutExtension( Assembly.GetExecutingAssembly().CodeBase );
			}
		}

		public static string AssemblyVersion {
			get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
		}

		public static string AssemblyProduct {
			get {
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyProductAttribute ), false );
				if( attributes.Length == 0 ) {
					return "";
				}
				return ( (AssemblyProductAttribute)attributes[ 0 ] ).Product;
			}
		}

		public static string AssemblyCopyright {
			get {
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyCopyrightAttribute ), false );
				if( attributes.Length == 0 ) {
					return "";
				}
				return ( (AssemblyCopyrightAttribute)attributes[ 0 ] ).Copyright;
			}
		}

		public static string AssemblyTrademark {
			get {
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyTrademarkAttribute ), false );
				if( attributes.Length == 0 ) {
					return "";
				}
				return ( (AssemblyTrademarkAttribute)attributes[ 0 ] ).Trademark;
			}
		}

		public static string AssemblyDescription {
			get {
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyDescriptionAttribute ), false );
				if( attributes.Length == 0 ) {
					return "";
				}
				return ( (AssemblyDescriptionAttribute)attributes[ 0 ] ).Description;
			}
		}


		public static void FillGrid( ref DevComponents.DotNetBar.Controls.DataGridViewX GridView, ref DevComponents.DotNetBar.ComboBoxItem Combo, EathenaConfigFile File, bool PrintComments ) {

			GridView.Rows.Clear();
			Combo.Items.Clear();
			int n = 0;
			for( int i = 0; i < File.Configs.Count; i++ ) {
				if( PrintComments == true )
					for( int c = 0; c < File.Configs[ i ].Comments.Length; c++ ) {
						n = GridView.Rows.Add();
						GridView.Rows[ n ].Tag = i; // save the "real" index
						GridView.Rows[ n ].Cells[ 0 ].Value = "// " + File.Configs[ i ].Comments[ c ];
						GridView.Rows[ n ].Cells[ 0 ].ReadOnly = true;
						GridView.Rows[ n ].Cells[ 1 ].ReadOnly = true;
						GridView.Rows[ n ].DefaultCellStyle.ForeColor = Color.DarkGreen;
					}

				n = GridView.Rows.Add();
				GridView.Rows[ n ].Tag = i; // save the "real" index
				GridView.Rows[ n ].Cells[ 0 ].Value = File.Configs[ i ].Name;
				GridView.Rows[ n ].Cells[ 1 ].Value = File.Configs[ i ].Value;
				GridView.Rows[ n ].DefaultCellStyle.ForeColor = Color.DarkBlue;
				GridView.Rows[ n ].DefaultCellStyle.Font = new Font( "Tahoma", 8.0f, FontStyle.Bold );

				GridView.Rows[ n ].Cells[ 0 ].ReadOnly = true;

				Combo.Items.Add( File.Configs[ i ].Name );
			}
		}

		public static void FillGrid( ref DataGridViewX GridView, EathenaConfigFile File, bool PrintComments ) {
			GridView.Rows.Clear();
			int n = 0;
			for( int i = 0; i < File.Configs.Count; i++ ) {
				if( PrintComments == true )
					for( int c = 0; c < File.Configs[ i ].Comments.Length; c++ ) {
						n = GridView.Rows.Add();
						GridView.Rows[ n ].Tag = i; // save the "real" index
						GridView.Rows[ n ].Cells[ 0 ].Value = "// " + File.Configs[ i ].Comments[ c ];
						GridView.Rows[ n ].Cells[ 0 ].ReadOnly = true;
						GridView.Rows[ n ].DefaultCellStyle.ForeColor = Color.DarkGreen;
					}

				n = GridView.Rows.Add();
				GridView.Rows[ n ].Tag = i; // save the "real" index
				GridView.Rows[ n ].Cells[ 0 ].Value = File.Configs[ i ].Name;
				GridView.Rows[ n ].Cells[ 1 ].Value = File.Configs[ i ].Value;
				GridView.Rows[ n ].DefaultCellStyle.ForeColor = Color.DarkBlue;
				GridView.Rows[ n ].DefaultCellStyle.Font = new Font( "Tahoma", 8.0f, FontStyle.Bold );

				GridView.Rows[ n ].Cells[ 0 ].ReadOnly = true;
			}
		}

		public static void Info( string Title, string Message ) {
			DevComponents.DotNetBar.MessageBoxEx.Show( Message, Title, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information );
		}

		public static void Error( string Title, string Message ) {
			DevComponents.DotNetBar.MessageBoxEx.Show( Message, Title, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
		}

	}



}
