using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GodLesZ.Library.Amf.IO;

namespace AmfTest {

	public class Program {

		public static void Main(string[] args) {
			string filepath = @"D:\Xampp\htdocs\amf\dso-amf-fulldata-response.bin";
			var amf = new DsoAmfHelper(File.ReadAllBytes(filepath));
			

			Console.ReadLine();
		}

	}

}
