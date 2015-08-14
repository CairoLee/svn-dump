using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GodLesZ.EdenEternal.DataViewer.Library.Formats.Scene;

namespace GodLesZ.EdenEternal.DataViewer.Controls {

	public partial class FormMapView : Form {
		
		public FormMapView(Form parent, string name, SceneFile scene) {
			InitializeComponent();
			
			MdiParent = parent;
			Name = "FormMapView_" + name;
			Tag = name;
			mapViewControl.SceneFile = scene;
		}

	}

}
