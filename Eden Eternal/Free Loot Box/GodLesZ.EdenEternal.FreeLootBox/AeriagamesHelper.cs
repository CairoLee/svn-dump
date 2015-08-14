using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GodLesZ.Library.Network.WebRequest;
using GodLesZ.Library.Network;
using Newtonsoft.Json.Linq;
using GodLesZ.Library;

namespace GodLesZ.EdenEternal.FreeLootBox {

	public class AeriagamesHelper {
		private List<AeriaAccount> mAccounts = new List<AeriaAccount>();

		public List<AeriaAccount> Accounts {
			get { return mAccounts; }
		}


		public void Run() {
			double currentSeconds = 0, lastSeconds = 0;
			Random mRandSleep = new Random();

			while(true) {
				lastSeconds = currentSeconds;
				currentSeconds = new TimeSpan(DateTime.Now.Ticks).TotalSeconds;
				if(lastSeconds == 0) {
					// First run..
					lastSeconds = currentSeconds;
				}

				int delay = (int)(currentSeconds - lastSeconds);
				for(int i = 0; i < Accounts.Count; i++) {
					AeriaAccount acc = Accounts[i];

					if(acc.HasPending == false) {
						// Only try to catch if we are logged in
						if(acc.EnsureLogin() == false) {
							CConsole.ErrorLine("[{0}] Removing account due to invalid password", acc.Username);
							Accounts.RemoveAt(i);
							i--;
						} else {
							// Try to catch it
							acc.TryCatchItem();
						}
					} else {
						// Sub the delay from our waiting period
						acc.RefreshWaiting(delay);
					}

				}

				// Sleep ~30sec, so we dont spam the website with the requests
				System.Threading.Thread.Sleep(mRandSleep.Next(28000, 35000));
			}

			CConsole.InfoLine("Program run out of the loop. Press any key to exit.");
			Console.Read();
		}

	}

}
