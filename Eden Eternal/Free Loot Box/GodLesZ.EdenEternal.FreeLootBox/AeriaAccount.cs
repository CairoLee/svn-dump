using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GodLesZ.Library.Network.WebRequest;
using GodLesZ.Library.Network;
using GodLesZ.Library;
using Newtonsoft.Json.Linq;

namespace GodLesZ.EdenEternal.FreeLootBox {

	public class AeriaAccount {
		const int CRAP_DELAY = (60 * 60) + 10; // 10sec space

		private JObject mLastObject;
		private int mTimeWaiting;

		public string Username;
		public string Password;
		public PostRequest Request;

		public int TimeLast {
			get { return int.Parse(((JValue)mLastObject["last_played"]).ToString()); }
		}

		public int TimeNow {
			get { return int.Parse(((JValue)mLastObject["current_time"]).ToString()); }
		}

		public bool HasPending {
			get { return (mTimeWaiting > 0); }
		}


		public AeriaAccount() {
			Request = new PostRequest();
			Request.AutoRedirect = false;
			mTimeWaiting = 0;
		}


		public bool EnsureLogin() {
			int loop = 0;
			while(loop < 3) {
				Request.Type = PostRequest.PostTypeEnum.Get;
				Request.PostItems.Clear();
				Request.UrlReferer = "http://edeneternal.aeriagames.com/itemmall/free-rewards";
				PostResult result = Request.Post("http://edeneternal.aeriagames.com/freerewards/get-event/ee");

				if(result.ResponseString.Contains("\"uid\":0") == true) {
					Login();
					loop++;
				} else {
					//CConsole.StatusLine("[{0}] Login successfull", Username);
					return true;
				}

			}

			CConsole.ErrorLine("[{0}] Failed to login {1} times, break..", Username, loop);
			return false;
		}

		public void TryCatchItem() {
			Request.Type = PostRequest.PostTypeEnum.Get;
			Request.PostItems.Clear();
			Request.UrlReferer = "http://edeneternal.aeriagames.com/itemmall/free-rewards";
			PostResult result = Request.Post("http://edeneternal.aeriagames.com/freerewards/get-event/ee");
			while(result.ResponseString.Contains("\"uid\":0") == true) {
				// Dont forget to save the last object!
				// Even if login failed..
				mLastObject = JObject.Parse(result.ResponseString);
				InitializeWaiting();
				return;
			}

			mLastObject = JObject.Parse(result.ResponseString);
			if((TimeLast + CRAP_DELAY) < TimeNow) {
				CrapItem();
			} else {
				InitializeWaiting();
			}
		}

		public void InitializeWaiting() {
			mTimeWaiting = (TimeLast + CRAP_DELAY) - TimeNow;

			CConsole.InfoLine("[{0}] Need to wait: {1}", Username, new TimeSpan(0, 0, mTimeWaiting));
		}

		public void RefreshWaiting(int sec) {
			mTimeWaiting -= sec;
			if(mTimeWaiting < 0) {
				mTimeWaiting = 0;
			}
		}


		private void Login() {
			Request.Type = PostRequest.PostTypeEnum.Post;
			Request.UrlReferer = "https://www.aeriagames.com/user/login?destination=http%3A%2F%2Fedeneternal.aeriagames.com%2F";
			Request.PostItems.Clear();
			Request.PostItems.Add("edit[form_id]", "user_login");
			Request.PostItems.Add("edit[name]", Username);
			Request.PostItems.Add("edit[pass]", Password);
			Request.PostItems.Add("op", "Log in");
			PostResult result = Request.Post("https://www.aeriagames.com/user/login?destination=http%3A%2F%2Fedeneternal.aeriagames.com%2F");
			Request.Cookies = result.Cookies;
		}

		private void CrapItem() {
			PostResult result = null;
			CConsole.InfoLine("[{0}] Crapping Item *_*", Username);

			Request.Type = PostRequest.PostTypeEnum.Post;
			Request.UrlReferer = "http://edeneternal.aeriagames.com/itemmall/free-rewards";
			Request.PostItems.Clear();
			Request.AdditionalHeader.Add("X-Requested-With", "XMLHttpRequest");
			Request.AdditionalHeader.Add("X-Request", "JSON");
			result = Request.Post("http://edeneternal.aeriagames.com/freerewards/play/33");

			try {
				JObject responseObj = JObject.Parse(result.ResponseString);
				int error = int.Parse(((JValue)responseObj["error_code"]).ToString());
				if(error == 0) {
					int success = int.Parse(((JValue)responseObj["is_successful"]).ToString());
					if(success == 1) {
						JObject wonItem = (JObject)responseObj["won_item"];
						string itemName = ((JValue)wonItem["name"]).ToString();
						CConsole.StatusLine("[{0}] Got the item: {1}", Username, itemName);
					} else {
						CConsole.ErrorLine("[{0}] Failed to crap item, success was 0? [Please report this to GodLesZ!]", Username);
						Request.AdditionalHeader.Clear();
						return;
					}
				}
			} catch(Exception e) {
				CConsole.ErrorLine("[{0}] Failed to crap item - exception message: {1}", Username, e.Message);
				Request.AdditionalHeader.Clear();
				return;
			}

			result = Request.Post("http://edeneternal.aeriagames.com/freerewards/redeem/ee");

			try {
				JObject redeemResponse = JObject.Parse(result.ResponseString);
				int error = int.Parse(((JValue)redeemResponse["error_code"]).ToString());
				string message = ((JValue)redeemResponse["message"]).ToString();
				if(error == 0) {
					CConsole.StatusLine("[{0}] Rdeemed the item successfully", Username);
				} else {
					CConsole.ErrorLine("[{0}] Redeem failed - code {1}, message: {2}", Username, error, message);
				}
			} catch(Exception e) {
				CConsole.ErrorLine("[{0}] Failed to redeem the item - exception message: {1}", Username, e.Message);
				return;
			} finally {
				Request.AdditionalHeader.Clear();
			}

		}

	}

}
