using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ImageHelper {

	public partial class ColorChooser : UserControl {
		private Color mSelectedColor = Color.White;

		[Browsable( true )]
		[XmlIgnore]
		public Color SelectedColor {
			get { return mSelectedColor; }
			set {
				mSelectedColor = value;
				imageColor.BackColor = value;
				if( ColorChanged != null )
					ColorChanged( imageColor, EventArgs.Empty );
			}
		}

		[Browsable( false )]
		[XmlElement( ElementName="SelectedColor")]
		public string XmlSelectedColor {
			get { return ColorTranslator.ToHtml( SelectedColor ); }
			set { SelectedColor = ColorTranslator.FromHtml( value ); }
		}

		[Browsable( true )]
		public event EventHandler ColorChanged;


		public ColorChooser() {
			InitializeComponent();
		}


		private void imageColor_Click( object sender, EventArgs e ) {
			ColorDialog dlg = new ColorDialog();
			dlg.Color = SelectedColor;
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			SelectedColor = dlg.Color;
		}

	}

}
