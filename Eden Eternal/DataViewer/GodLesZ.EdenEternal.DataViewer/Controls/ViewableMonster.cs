using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace GodLesZ.EdenEternal.DataViewer.Controls {

	public class ViewableMonster {
		protected DataRow mRow;

		public string ID;
		public string Icon;
		public string Name;

		public DataRow Source {
			get { return mRow; }
		}


		public ViewableMonster(DataRow row) {
			mRow = row;

			ID = row["ID"].ToString();
			Icon = row["Icon"].ToString();
			Name = row["Name"].ToString();
		}


		public string[] ToArray() {
			var data = new List<string>(new[] {
				ID,
				Name
			});

			for (var i = 0; i < mRow.ItemArray.Length; i++) {
				var value = mRow.ItemArray[i];
				var column = mRow.Table.Columns[i];
				
				data.Add(value.ToString());
			}

			return data.ToArray();
		}

	}

}