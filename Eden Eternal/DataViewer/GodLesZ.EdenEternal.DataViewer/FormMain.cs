using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GodLesZ.EdenEternal.DataViewer.Controls;
using GodLesZ.EdenEternal.DataViewer.Library.Formats;
using GodLesZ.EdenEternal.DataViewer.Library.Formats.Scene;

namespace GodLesZ.EdenEternal.DataViewer {

	public partial class FormMain : Form {

		public FormMain() {
			InitializeComponent();
		}


		#region menuMainData Load core files
		private void menuMainDataLoadItem_Click(object sender, EventArgs e) {
			var filepath = ShowOpenFileDialog("item.ini|item.ini");
			if (string.IsNullOrEmpty(filepath)) {
				return;
			}

			var file = new ItemDataFile();
			file.Read(filepath);
			AddDataToDataView("item", file.Entries);
		}

		private void menuMainDataLoadMonster_Click(object sender, EventArgs e) {
			var filepath = ShowOpenFileDialog("c_monster.ini|c_monster.ini");
			if (string.IsNullOrEmpty(filepath)) {
				return;
			}

			var file = new MonsterDataFile();
			file.Read(filepath);
			AddDataToDataView("monster", file.Entries);
		}

		private void menuMainDataLoadScene_Click(object sender, EventArgs e) {
			var filepath = ShowOpenFileDialog("Scene File (sXXX.ini)|*.ini");
			if (string.IsNullOrEmpty(filepath)) {
				return;
			}

			var file = new SceneFile(filepath);
			var frm = new FormMapView(this, "scene", file);
			frm.Show();
		}
		#endregion


		#region menuMainData Load translations
		private void menuMainDataLoadItemTranslation_Click(object sender, EventArgs e) {
			var filepath = ShowOpenFileDialog("item.ini|item.ini");
			if (string.IsNullOrEmpty(filepath)) {
				return;
			}

			var file = new ItemTranslationDataFile();
			file.Read(filepath);
			AddDataToDataView("item_t", file.Entries);
		}

		private void menuMainDataLoadMonsterTranslation_Click(object sender, EventArgs e) {
			var filepath = ShowOpenFileDialog("c_monster.ini|c_monster.ini");
			if (string.IsNullOrEmpty(filepath)) {
				return;
			}

			var file = new MonsterTranslationDataFile();
			file.Read(filepath);

			var frm = new FormMonsterList(this, "monster_t", file.Entries);
			frm.Show();
		}
		#endregion



		private string ShowOpenFileDialog(string fileMask) {
			using (var dlg = new OpenFileDialog()) {
				dlg.Filter = fileMask;
				return dlg.ShowDialog() != DialogResult.OK ? null : dlg.FileName;
			}
		}

		private DataGridView AddDataToDataView(string name, DataTable data, IComparer sortComparer = null) {
			var frm = new FormDataGrid(this, name, data, sortComparer);
			//frm.MainMenuStrip = menuMain;
			frm.Show();

			return frm.DataGrid;
		}

	}

}
