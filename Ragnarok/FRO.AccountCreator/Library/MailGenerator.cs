using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;

namespace FRO.AccountCreator.Library {

	/// <summary>
	/// Creates mail accounts from ...
	/// </summary>
	public class MailGenerator {

		public MailGenerator() {
		}


		public static string createMail() {
			return createMail(1);
		}
		public static string createMail(int level) {
			string email = "";

			if (level >= 10) {
				return "";
			}

			string emailName = GetRandomString();
			PostResult result = WebUtil.GetPage("http://mailinator.com/maildir.jsp", "http://www.guerillamail.org/", PostRequest.PostTypeEnum.Get, "email=" + emailName + "&x=0&y=0");
			string webContent = result.ResponseString;
			// Check email..
			if (webContent.Contains("Inbox for: " + emailName) == false) {
				return createMail(level + 1);
			}

			email = emailName + "@mailinator.com";
			return email;
		}

		public static bool CheckResponseEmail(string email) {
			email = email.Replace("@mailinator.com", "");
			PostResult result = WebUtil.GetPage("http://mailinator.com/maildir.jsp", "http://mailinator.com/", PostRequest.PostTypeEnum.Get, "email=" + email + "&x=0&y=0");
			string webContent = result.ResponseString;
			if (webContent.Contains("gamemaster@ragnarokonline.fr") == false) {
				return false;
			}

			Regex re = new Regex(@"<tr><td bgcolor=#EEEEFF><b>gamemaster@ragnarokonline.fr</b></td><td bgcolor=#EEEEFF align=center><a href=/displayemail.jsp\?(email=" + email + "&msgid=[0-9]+)>Inscription Ã  Ragnarok Online</a></td></tr>");
			Match m = re.Match(webContent);
			if (m.Success == false) {
				return false;
			}
			string linkParam = m.Groups[1].Captures[0].Value.Trim();
			result = WebUtil.GetPage("http://mailinator.com/displayemail.jsp", "http://mailinator.com/", PostRequest.PostTypeEnum.Get, linkParam);
			webContent = result.ResponseString;

			Regex reValidation = new Regex(@"Pour jouer &agrave; Ragnarok Online, vous devez maintenant valider votre compte en cliquant sur le lien suivant:  <a href='http://www.ragnarokonline.fr/site/pad/accConfirm.php\?(id=[0-9]+&cc=[^']+)' rel='nofollow' target='_blank'>VALIDER </a>");
			Match mValidation = reValidation.Match(webContent);
			if (mValidation.Success == false) {
				// Badly.. we got the correct E-Mail response, but cant find the link to validate?
				// Should error here.. mabye FRO changed the Text
				return false;
			}

			string validationParam = mValidation.Groups[1].Captures[0].Value.Trim();
			result = WebUtil.GetPage("http://www.ragnarokonline.fr/site/pad/accConfirm.php", "http://mailinator.com/", PostRequest.PostTypeEnum.Get, validationParam);
			webContent = result.ResponseString;

			return true;
		}


		private static string GetRandomString() {
			string result = "";
			char[] chars = "abzdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
			Random rand = new Random();

			for (int i = 0; i < 6; i++) {
				result += chars[rand.Next(chars.Length - 1)];
			}

			return result;
		}
	}

}