using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GodLesZ.Library.Imaging.Dds;

namespace GodLesZ.EdenEternal.DataViewer.Controls {

	public partial class MonsterListControl : UserControl {
		public static string MobIconDir = @"C:\Games\Eden Eternal\EdenEternal-DE\pkg\_Unpack\UI\uiicon\";

		protected DataTable mMonsterData = null;

		public DataTable MonsterData {
			get { return mMonsterData; }
			set {
				if (mMonsterData == value) {
					return;
				}

				mMonsterData = value;
				FillListView();
			}
		}


		public MonsterListControl()
			: this(null) {

		}

		public MonsterListControl(DataTable data) {

			InitializeComponent();

			mMonsterData = data;
			if (mMonsterData != null) {
				FillListView();
			}
		}


		private void FillListView() {

			listMonsters.Items.Clear();
			listMonsters.BeginUpdate();

			// For debug, fill up columns
			var columnsAdded = false;
			foreach (var row in mMonsterData.Rows) {
				var mob = new ViewableMonster((DataRow)row);
				if (columnsAdded == false) {
					columnsAdded = true;
					foreach (var column in mob.Source.Table.Columns) {
						listMonsters.Columns.Add(column.ToString());
					}
				}

				var iconName = BuildMobImageSmall(mob);

				var lvi = new ListViewItem(mob.ToArray(), iconName);
				listMonsters.Items.Add(lvi);
			}
			listMonsters.EndUpdate();
			listMonsters.Refresh();
		}


		private string BuildMobImageSmall(ViewableMonster mob) {
			var iconColumnValue = mob.Icon;
			var iconName = iconColumnValue.Substring(0, 4);
			if (listMonsters.SmallImageList.Images.ContainsKey(iconName) == false) {
				// [M014]010
				var iconFilename = string.Format("{0}.dds", iconName);
				var iconFilepath = Path.Combine(MobIconDir, iconFilename);
				if (File.Exists(iconFilepath)) {

					var dds = new DdsFile();
					using (var stream = File.OpenRead(iconFilepath)) {
						dds.Deserialize(stream);
					}

					var png = dds.AsPng();
					listMonsters.SmallImageList.Images.Add(iconName, png);
					listMonsters.LargeImageList.Images.Add(iconName, png);
				}
			}

			return iconName;
		}

	}

}
