using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GodLesZ.Library.Network;
using GodLesZ.Library.Network.WebRequest;
using System.Text.RegularExpressions;
using System.Drawing;
using System.IO;


namespace FRO.AccountChecker {
	
	public static class CharacterHelper {
		public static List<CharacterInfo> Chars = new List<CharacterInfo>();
		private static string BASEURI = "http://ragnarokonline.fr/site/";


		public static bool LoadInfos(string username, string password) {
			Chars.Clear();

			WebUtil.Cookies = null;
			PostResult result = WebUtil.GetPage(BASEURI + "scripts/connection_compte.php", BASEURI, PostRequest.PostTypeEnum.Post, "email=" + username + "&password=" + password);
			if (result.ResponseString == "non") {
				return false;
			}

			WebUtil.Cookies = result.Cookies;
			result = WebUtil.GetPage(BASEURI, BASEURI, "");
			FilterInfos(result.ResponseString);

			return true;
		}


		private static void FilterInfos(string page) {
			string fromElement = "infosCompte";
			string toElement = "optionsCompte";

			string infos = page.Substring(page.IndexOf(fromElement), page.IndexOf(toElement));
			infos = infos.Replace("'", "\"");
			
			//<div style='display: block;' id='perso-1' rel='2054903'>Nom:GodLesZ<br/>Job:Novice<br/>Job Level:6 - LVL:8<br/>Zeny:150</div>
			string pattern = "<div style=['\"][^'\"]*['\"] id=['\"]([^'\"]*)['\"] rel=['\"]([^'\"]*)['\"][^>]*>";
			pattern += "Nom:([^<]*)<br/>Job:([^<]*)<br/>Job Level:([^ ]*) - LVL:([^<]*)<br/>Zeny:([^<]*)</div>";
			Regex rBlock = new Regex(pattern);
			MatchCollection matches = rBlock.Matches(infos);
			foreach (Match m in matches) {
				string elementID = m.Groups[1].Captures[0].Value.Trim();
				string charID = m.Groups[2].Captures[0].Value.Trim();
				string charName = m.Groups[3].Captures[0].Value.Trim();
				string charCLass = m.Groups[4].Captures[0].Value.Trim();
				string charLevelJob = m.Groups[5].Captures[0].Value.Trim();
				string charLevelBase = m.Groups[6].Captures[0].Value.Trim();
				string charZeny = m.Groups[7].Captures[0].Value.Trim();

				CharacterInfo c = new CharacterInfo {
					PageElementID = elementID,
					CharID = charID,
					Name = charName,
					Class = charCLass,
					LevelBase = charLevelBase,
					LevelJob = charLevelJob,
					Zeny = charZeny
				};

				// Search ava img
				Regex rAva = new Regex("rel='" + c.CharID + "'>[ \t\n]*<img src=\"([^'\"]*)\"");
				Match mAva = rAva.Match(page);
				string avaPath = mAva.Groups[1].Captures[0].Value.Trim();
				avaPath = BASEURI + avaPath;
				c.Avatar = (Bitmap)Bitmap.FromStream(new MemoryStream(WebUtil.GetPage(avaPath, BASEURI, "").ResponseData));


				Chars.Add(c);
			}

		}

	}

}
