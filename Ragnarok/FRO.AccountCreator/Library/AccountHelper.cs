using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace FRO.AccountCreator.Library {

	public class AccountHelper {

		public static EAccountResult CreateAccount(ref AccountData account) {
			EAccountResult result = EAccountResult.Success;
			PostResult postResult;

			PostRequest mClient = new PostRequest("http://ragnarokonline.fr/inscription/index.php", "http://ragnarokonline.fr/inscription/index.php");
			mClient.Type = PostRequest.PostTypeEnum.Get;
			postResult = mClient.Post();
			// apply cookies
			mClient.Cookies = postResult.Cookies;

			// visit register page (need to fetch new cookies)
			mClient.Url = "http://ragnarokonline.fr/inscription/inscrire.php";
			mClient.UrlReferer = "http://ragnarokonline.fr/inscription/inscrire.php";
			postResult = mClient.Post();
			// apply cookies..
			mClient.Cookies = postResult.Cookies;

			// download captcha
			mClient.Url = "http://ragnarokonline.fr/inscription/securimage/securimage_show.php";
			postResult = mClient.Post();
			// apply cookies.. again
			//mClient.Cookies = postResult.Cookies;
			string captchaPath = Path.GetTempFileName();
			File.Delete(captchaPath);
			captchaPath += ".png";
			File.WriteAllBytes(captchaPath, postResult.ResponseData);

			// open captcha
			Process p = Process.Start(captchaPath);
			Console.Write("\t\tCaptcha code: ");
			account.CaptchaCode = Console.ReadLine();

			// Only if we have admin rights, we may kill the process
			System.Security.Principal.WindowsPrincipal pricipal = new System.Security.Principal.WindowsPrincipal(System.Security.Principal.WindowsIdentity.GetCurrent());
			if (pricipal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator) == true) {
				try {
					if (p.CloseMainWindow() == false) {
						// fall trough
						throw new Exception("Failed to close captcha image process");
					}
				} catch (Exception ex) {
					// Failed to close.. so try minimize it
					try {
						System.Windows.Forms.Form frm = (System.Windows.Forms.Form)System.Windows.Forms.Form.FromHandle(p.MainWindowHandle);
						if (frm != null) {
							frm.WindowState = System.Windows.Forms.FormWindowState.Minimized;
						}
					} catch {
						// Nothing worked.. damn it
						// only native code may help now, but just to kill or minimize a process.. no way
					}
				}
			}

			mClient.Url = "http://ragnarokonline.fr/inscription/verifMail.php";
			mClient.Cookies = postResult.Cookies;
			mClient.PostItems.Add("email", account.Email);
			mClient.PostItems.Add("name", account.Prename);
			mClient.PostItems.Add("surname", account.Name);
			mClient.PostItems.Add("jour", account.BirthDay.ToString());
			mClient.PostItems.Add("mois", account.BirthMonth.ToString());
			mClient.PostItems.Add("annee", account.BirthYear.ToString());
			mClient.PostItems.Add("sexe", "1"); // Männlich
			mClient.PostItems.Add("captcha_code", account.CaptchaCode);

			postResult = mClient.Post();

			Regex re = new Regex("&resultat=([^&]*)&login=([^&]*)&pass=([^&]*)");
			Match match = re.Match(postResult.ResponseString);
			if (match.Success == false) {
				return CreateAccount(ref account);
			}

			account.Login = match.Groups[2].Captures[0].Value;
			account.Password = match.Groups[3].Captures[0].Value;

			int requestResult = int.Parse(match.Groups[1].Captures[0].Value);
			result = (EAccountResult)requestResult;


			return result;
		}
	}


	public enum EAccountResult {
		Success = 1,
		ErrorReturn2 = 2,
		ErrorReturn3 = 3,
		WrongCaptcha = 4
	}

}
