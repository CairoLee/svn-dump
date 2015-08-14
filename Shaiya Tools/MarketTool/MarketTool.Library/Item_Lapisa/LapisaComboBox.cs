using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MarketTool.Library.Controls {
	
	public class LapisaComboBox : ImageComboBox {

		public LapisaComboBox()
			: base() {

			string[] names = Enum.GetNames( typeof( ELapisa ) );
			for( int i = 0; i < names.Length; i++ )
				Items.Add( new ImageComboItem( names[ i ], this.Font, Color.Black, i, EImageComboItemTextAlign.Right ) );

		}

	}

}
