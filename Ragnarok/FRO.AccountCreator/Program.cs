using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FRO.AccountCreator.Library;
using System.IO;

namespace FRO.AccountCreator {

	public class Program {
		private static char[] mCursorData = "|/-\\".ToCharArray();


		public static void Main(string[] args) {
			WriteLine("------------------------------------------------------", ConsoleColor.Blue);
			WriteLine("[    France Ragnarok Account Creator - by GodLesZ    ]", ConsoleColor.Blue);
			WriteLine("------------------------------------------------------", ConsoleColor.Blue);
			WriteLine();

			Write("\t#1 fetch email..");
			string email = MailGenerator.createMail();
			if (email == "") {
				WriteLine(" failed! PLease report this to GodLesZ.", ConsoleColor.Red);
				CleanUp();
				Console.ReadKey();
				return;
			}
			WriteLine(" done", ConsoleColor.Green);

			Write("\t#2 build credentials..");
			AccountData userData = new AccountData(email);
			WriteLine(" done", ConsoleColor.Green);

			WriteLine("\t#3 create account..");
			try {
				EAccountResult res;
				if ((res = AccountHelper.CreateAccount(ref userData)) != EAccountResult.Success) {
					WriteLine("\tfailed to create account: " + res, ConsoleColor.Red);
					CleanUp();
					Console.ReadKey();
					return;
				}
			} catch (Exception ex) {
				WriteLine("\tfailed to create account: internal exception", ConsoleColor.Red);
				CleanUp();
				Console.WriteLine(ex);

				Console.ReadKey();
				return;
			}

			try {
				Write("\t#4 create file..");
				using (StreamWriter Writer = new StreamWriter("Account.txt", true)) {

					Writer.WriteLine("#----------- Account Daten ---------");
					Writer.WriteLine("# E-Mail  :  " + userData.Email);
					Writer.WriteLine("# Login   :  " + userData.Login);
					Writer.WriteLine("# Password:  " + userData.Password);
					Writer.WriteLine();

				}
				WriteLine(" done", ConsoleColor.Green);

			} catch (Exception WriterEX) {
				WriteLine("\failed to create file: internal exception", ConsoleColor.Red);
				CleanUp();
				Console.WriteLine(WriterEX);
				Console.ReadKey();
				return;
			}

			CleanUp();
			WriteLine();
			WriteLine("----------------------------------------", ConsoleColor.Green);

			WriteLine("Email    : " + userData.Email);
			WriteLine("Login    : " + userData.Login);
			WriteLine("Password : " + userData.Password);

			WriteLine("----------------------------------------", ConsoleColor.Green);
			Write("Wait for FRO email.. ");

			int i = 0;
			do {
				Console.Write("{0}{1}", (i > 0 ? "\b" : ""), mCursorData[i % mCursorData.Length]);

				if (MailGenerator.CheckResponseEmail(userData.Email) == true) {
					Write("\b received & validated!", ConsoleColor.Green);
					break;
				}

				System.Threading.Thread.Sleep(200);
				i++;
			} while (true);

			WriteLine();
			WriteLine();
			WriteLine("------------------------------------------------------", ConsoleColor.Blue);
			WriteLine("[                GodLesZ <3 Blaubeere                ]", ConsoleColor.Blue);
			WriteLine("------------------------------------------------------", ConsoleColor.Blue);
			Console.ReadKey();
		}


		public static void CleanUp() {
			if (System.IO.File.Exists(Environment.CurrentDirectory + "/captcha.png") == true) {
				System.IO.File.Delete(Environment.CurrentDirectory + "/captcha.png");
			}
		}


		public static void WriteLine() {
			WriteLine("");
		}

		public static void WriteLine(string text) {
			WriteLine(text, Console.ForegroundColor);
		}

		public static void WriteLine(string text, ConsoleColor color) {
			Write(text + Environment.NewLine, color);
		}

		public static void Write(string text) {
			Write(text, Console.ForegroundColor);
		}

		public static void Write(string text, ConsoleColor color) {
			Console.ForegroundColor = color;
			Console.Write(text);
			Console.ResetColor();
		}

	}

}

