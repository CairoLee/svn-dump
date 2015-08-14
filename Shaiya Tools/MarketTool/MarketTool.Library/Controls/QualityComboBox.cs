using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MarketTool.Library {

	public class QualityComboBox : ComboBox {
		public static string[] Qualitys = null;

		public QualityComboBox()
			: base() {

			if( Qualitys == null ) 
				Qualitys = Enum.GetNames( typeof( EQuality ) );

		}

	}

}
