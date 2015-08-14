using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Microsoft.Win32;
using System.Threading;
using System.Collections;
using System.Reflection.Emit;

namespace GodLesZ.BlubbRO.Patcher {


	public class Tools {


		public static string GetFileSize(long Bytes) {
			if (Bytes >= 1073741824) {
				Decimal size = Decimal.Divide(Bytes, 1073741824);
				return String.Format("{0:##.##} GB", size);
			} else if (Bytes >= 1048576) {
				Decimal size = Decimal.Divide(Bytes, 1048576);
				return String.Format("{0:##.##} MB", size);
			} else if (Bytes >= 1024) {
				Decimal size = Decimal.Divide(Bytes, 1024);
				return String.Format("{0:##.##} KB", size);
			} else if (Bytes > 0 & Bytes < 1024) {
				Decimal size = Bytes;
				return String.Format("{0:##.##} B", size);
			} else {
				return "0 B";
			}
		}


	}


}
