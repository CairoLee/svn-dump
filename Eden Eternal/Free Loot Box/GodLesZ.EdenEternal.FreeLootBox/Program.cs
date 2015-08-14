using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GodLesZ.Library;

namespace GodLesZ.EdenEternal.FreeLootBox {

	public class Program {
		private static AeriagamesHelper mGame;

		public static void Main(string[] args) {
			mGame = new AeriagamesHelper();

			if(ReadLogins() == false) {
				Console.WriteLine(Environment.NewLine + "Press any key to exit");
				Console.Read();
				return;
			}

			CConsole.StatusLine("Start to fetch items..");

			mGame.Run();
		}


		private static bool ReadLogins() {
			string filepath = "Accounts.txt";
			if(File.Exists(filepath) == false) {
				CConsole.ErrorLine("Failed to find \"" + filepath + "\"!");
				return false;
			}
			string[] lines = File.ReadAllLines(filepath);
			foreach(string line in lines) {
				if(line.Length == 0 || line.StartsWith("//") == true || line.IndexOf('\t') == -1) {
					continue;
				}

				string[] parts = line.Split('\t');
				AeriaAccount acc = new AeriaAccount() { 
					Username = parts[0], 
					Password = parts[1]
				};
				CConsole.StatusLine("Add account [{0}]", acc.Username);

				mGame.Accounts.Add(acc);
			}

			return (mGame.Accounts.Count > 0);
		}

	}

}
