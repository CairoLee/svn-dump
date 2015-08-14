using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GodLesZ.Library.Json;
using GodLesZ.Library.Json.Linq;

namespace FreeWorld.Editor.Animation {

	public partial class FormImportRpgMaker : Form {
		private JObject mCurrentObject;

		public JToken SelectedAnimation {
			get;
			private set;
		}


		public FormImportRpgMaker() {
			InitializeComponent();

			DialogResult = DialogResult.Cancel;
		}


		private void btnOpenFile_Click(object sender, EventArgs e) {
			using (var dlg = new OpenFileDialog()) {
				if (dlg.ShowDialog(this) != DialogResult.OK) {
					return;
				}

				RefreshAnimationList(dlg.FileName);
			}
		}

		private void listAnimations_SelectedIndexChanged(object sender, EventArgs e) {
			btnImportSelected.Enabled = (listAnimations.SelectedIndices.Count != 0);
		}

		private void btnImportSelected_Click(object sender, EventArgs e) {
			if (listAnimations.SelectedIndices.Count == 0) {
				btnImportSelected.Enabled = false;
				return;
			}

			var selectedAnimationName = listAnimations.SelectedItems[0].Tag.ToString();
			SelectedAnimation = mCurrentObject[selectedAnimationName];

			DialogResult = DialogResult.OK;
			Close();
		}


		private void RefreshAnimationList(string fileName) {
			var jsonString = File.ReadAllText(fileName).Trim();

			listAnimations.Items.Clear();

			mCurrentObject = JObject.Parse(jsonString);
			foreach (var kvp in mCurrentObject) {
				var animation = kvp.Value;
				var aniName = animation["name"].ToString();
				var aniFrameCount = ((JArray)animation["frames"]).Count;
				var listItem = new ListViewItem(new string[] {
					(listAnimations.Items.Count+1).ToString(),
					aniName,
					aniFrameCount.ToString()
				}) {
					Tag = aniName
				};
				listAnimations.Items.Add(listItem);
			}

		}

	}

}
