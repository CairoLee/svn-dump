using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace eAthenaStudio.Client {

	public partial class frmSettings : Form {
		private Dictionary<int, pnlTreeNode> mPanels = new Dictionary<int, pnlTreeNode>();
		private pnlTreeNode mLastPanel = null;


		public frmSettings() {
			InitializeComponent();

			mPanels.Add(GetIndex(treeProperties.Nodes[0].Nodes[0]), new pnlTreeNodeEathenaRoot());
		}


		#region treeProperties Events
		private void treeProperties_AfterSelect(object sender, TreeViewEventArgs e) {
			if (e.Node.FirstNode != null) {
				treeProperties.SelectedNode = e.Node.FirstNode;
				return;
			}

			int i = GetIndex(e.Node);
			System.Diagnostics.Debug.WriteLine("selected Index from '" + e.Node.Name + "': " + i);
			if (i >= 0 && mPanels.ContainsKey(i))
				SetActivePanel(mPanels[i]);
		}

		private void treeProperties_AfterExpand(object sender, TreeViewEventArgs e) {
			e.Node.ImageIndex = 1;
			if (e.Node.FirstNode != null)
				treeProperties.SelectedNode = e.Node.FirstNode;
		}

		private void treeProperties_AfterCollapse(object sender, TreeViewEventArgs e) {
			e.Node.ImageIndex = 0;
		}
		#endregion

		#region OK/Cancel
		private void btnOK_Click(object sender, EventArgs e) {
			// TODO: re-create Settings File
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			// nothign todo?
			DialogResult = DialogResult.Cancel;
			Close();
		}
		#endregion


		public void SetActivePanel(pnlTreeNode Panel) {
			if (mLastPanel != null) {
				if (mLastPanel == Panel)
					return;
				panelControls.Controls.Clear();
			}

			panelControls.Controls.Add(Panel);
			mLastPanel = Panel;
		}

		private int GetIndex(TreeNode Node) {
			int index = int.Parse(Node.Tag.ToString());
			while ((Node = Node.Parent) != null)
				index += int.Parse(Node.Tag.ToString());

			return index;
		}

	}

}
