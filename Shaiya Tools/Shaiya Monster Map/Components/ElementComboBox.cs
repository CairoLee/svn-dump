using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace ShaiyaMonsterMap.Components {

	public class ElementComboBox : ComboBox {

		public ElementComboBox() {
			IntegralHeight = false;
			Sorted = false;
			DropDownStyle = ComboBoxStyle.DropDownList;
			DrawMode = DrawMode.OwnerDrawVariable;
		}

		protected override void OnDrawItem( System.Windows.Forms.DrawItemEventArgs e ) {
			if( e.Index > -1 ) {
				string itemText = Items[ e.Index ].ToString();
				Color col = Color.Black;
				if( itemText == "Feuer" )
					col = Color.Red;
				else if( itemText == "Wasser" )
					col = Color.Navy;
				else if( itemText == "Wind" )
					col = Color.YellowGreen;
				else if( itemText == "Erde" )
					col = Color.Brown;

				if( ( e.State & DrawItemState.Focus ) == 0 ) {
					e.Graphics.FillRectangle( new SolidBrush( SystemColors.Window ), e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height );
					e.Graphics.DrawString( itemText, this.Font, new SolidBrush( col ), e.Bounds.X, e.Bounds.Y );
				} else {
					e.Graphics.FillRectangle( new SolidBrush( SystemColors.Highlight ), e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height );
					e.Graphics.DrawString( itemText, this.Font, new SolidBrush( col ), e.Bounds.X, e.Bounds.Y );
				}
			}

			base.OnDrawItem( e );
		}

	}

}


