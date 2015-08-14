using System;

namespace GodLesZ.FunRO.Patcher {

	public static class LongExtensions {

		public static string GetFileSize(this long bytes) {
			string fileSize = "0 B";

			if (bytes >= 1073741824) {
				decimal size = Decimal.Divide(bytes, 1073741824);
				fileSize = string.Format("{0:##.##} GB", size);
			} else if (bytes >= 1048576) {
				decimal size = Decimal.Divide(bytes, 1048576);
				fileSize = string.Format("{0:##.##} MB", size);
			} else if (bytes >= 1024) {
				decimal size = Decimal.Divide(bytes, 1024);
				fileSize = string.Format("{0:##.##} KB", size);
			} else if (bytes > 0 & bytes < 1024) {
				decimal size = bytes;
				fileSize = string.Format("{0:##.##} B", size);
			}

			return fileSize;
		}

	}

}
