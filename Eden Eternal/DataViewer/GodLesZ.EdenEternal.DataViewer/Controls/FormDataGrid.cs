using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GodLesZ.EdenEternal.DataViewer.Controls {

	public partial class FormDataGrid : Form {

		public DataGridView DataGrid {
			get { return dataGrid; }
		}


		public FormDataGrid(Form parent, string name, object data, IComparer sortComparer = null) {
			InitializeComponent();

			MdiParent = parent;

			Name = "FormDataGrid_" + name;
			Tag = name;
			dataGrid.Name = "dataGrid_" + name;
			dataGrid.DataSource = data;
			if (sortComparer != null) {
				dataGrid.ColumnHeaderMouseClick += (sender, args) => dataGrid.Sort(sortComparer);
			}
		}

	}

}
