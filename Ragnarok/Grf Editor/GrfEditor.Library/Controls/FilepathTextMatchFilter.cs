using System;
using GodLesZ.Library.Controls;

namespace GrfEditor.Library.Controls {

	public class FilepathTextMatchFilter : TextMatchFilter {

		public FilepathTextMatchFilter(ObjectListView olv, string text, MatchKind match) :
			base(olv, text, match, StringComparison.CurrentCultureIgnoreCase) {

			this.Columns = new OLVColumn[]{
				(OLVColumn)olv.Columns[1]
			};
		}


		public override bool Filter(object modelObject) {
			if (this.ListView == null || String.IsNullOrEmpty(this.Text)) {
				return true;
			}

			// Don't do anything if the Regex is invalid
			if (this.Match == MatchKind.Regex && this.IsRegexInvalid) {
				return true;
			}

			foreach (OLVColumn column in this.IterateColumns()) {
				if (column.IsVisible) {
					string cellText = column.GetStringValue(modelObject);
					if (this.MatchesText(cellText)) {
						return true;
					}
				}
			}

			return false;
		}

	}

}
