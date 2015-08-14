using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FRO.AccountCreator.Library {

	public class AccountData {
		public string Login {
			get;
			set;
		}

		public string Password {
			get;
			set;
		}


		public string Prename {
			get;
			set;
		}

		public string Name {
			get;
			set;
		}

		public string Email {
			get;
			set;
		}

		public int BirthDay {
			get;
			set;
		}

		public int BirthMonth {
			get;
			set;
		}

		public int BirthYear {
			get;
			set;
		}


		public string CaptchaCode {
			get;
			set;
		}


		public AccountData(string email) {
			Random rnd = new Random();

			Email = email;
			Prename = AccountData.GetRandomName(6);
			Name = AccountData.GetRandomName(10);
			BirthDay = rnd.Next(1, 31);
			BirthMonth = rnd.Next(1, 12);
			BirthYear = rnd.Next(1960, 1991);
		}


		private static char[] mLetter = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
		private static string GetRandomName(int len) {
			string name = "";
			Random rnd = new Random();
			for (int i = 0; i < len; i++) {
				name += mLetter[rnd.Next(0, mLetter.Length - 1)];
			}

			return name;
		}


		public string ToUrl() {
			string url = "";

			return url;
		}

	}

}
