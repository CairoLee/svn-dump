using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace SDataEditor.Gui {

	public static class Extensions {

		public static string FixxHTML( this string HTML ) {
			HTML = HTML.Replace( "ä", "&auml;" );
			HTML = HTML.Replace( "ö", "&ouml;" );
			HTML = HTML.Replace( "ü", "&uuml;" );
			HTML = HTML.Replace( "Ä", "&Auml;" );
			HTML = HTML.Replace( "Ö", "&Ouml;" );
			HTML = HTML.Replace( "Ü", "&Uuml;" );
			HTML = HTML.Replace( "ß", "&szlig;" );

			return HTML;
		}




		public static bool Export( this DataGridView Grid, string SaveToFile ) {
			return Grid.Export( SaveToFile, 0, Grid.Rows.Count );
		}

		public static bool Export( this DataGridView Grid, string SaveToFile, int FromRow, int ToRow ) {
			if( FromRow >= Grid.Rows.Count )
				return false;
			ToRow = Math.Min( Grid.Rows.Count, ToRow );

			try {
				using( StreamWriter sw = new StreamWriter( SaveToFile, false ) ) {
					sw.WriteLine( 
						"<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">"
						+ "<html xmlns=\"http://www.w3.org/1999/xhtml\">"
						+ "<head>"
							+ "<title>Item.SData [" + FromRow + " - " + ToRow + "]</title>"
							+ "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=ISO-8859-1\" />"
						+ "</head>"
						+ "<body>"
					);
					sw.WriteLine( "<table border=\"1\" cellpadding=\"2\" cellspacing=\"0\"><tr>" );
					for( int i = 0; i < Grid.Columns.Count; i++ ) 
						sw.Write( "<th>" + Grid.Columns[ i ].HeaderText.FixxHTML() + "</th>" );

					sw.WriteLine( sw.NewLine + "</tr>" );

					for( int i = FromRow; i < ToRow; i++ ) {
						DataGridViewRow dr = Grid.Rows[ i ];
						sw.Write( "<tr>" );

						for( int c = 0; c < Grid.Columns.Count; c++ ) {
							if( !Convert.IsDBNull( dr.Cells[ c ] ) )
								sw.Write( "<td>" + dr.Cells[ c ].Value.ToString().FixxHTML() + "</td>" );
						}

						sw.Write( "</tr>"+sw.NewLine );
					}

					sw.WriteLine( "</table></body></html>" );
				}
				return true;
			} catch( Exception e ) {
				System.Diagnostics.Debug.WriteLine( e );
				return false;
			}


		}


	}

}
