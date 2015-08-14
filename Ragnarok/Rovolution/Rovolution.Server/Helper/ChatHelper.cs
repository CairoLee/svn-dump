using System;
using Rovolution.Server.Network;

namespace Rovolution.Server.Helper {

	public class ChatHelper {

		/// <summary>
		/// Initialize defines, globals, bla..
		/// </summary>
		public static void Initialize() {
		}


		public static bool ValidateMessage(NetState state, string text, out string username, out string message) {
			// Delimiter for <username> and <message>
			// and yep, this means, the client sends us "Username : message" as one string
			// so we have to parse it..
			string delim = " : ";

			username = "";
			message = "";

			// TODO: i saw a topic in eA source request about fakename talking
			//		 he wanted to display the fakename in the chat
			//		 if implementing such a mod, we should check here for the fakename too!
			if (text.StartsWith(state.ActiveChar.Status.Name + delim) == false) {
				// This is just to check for a hacked packet
				// The message always has to start with <username><delimiter>, so its incorrect either @ this point
				if (text.StartsWith(state.ActiveChar.Status.Name) == false) {
					ServerConsole.DebugLine("Chatting.ValidateMessage: Player '{0}' sent a message using an incorrect name! Forcing a relog...", state.ActiveChar.Status.Name);
					state.Dispose();
				}
				return false;
			}

			// Split by delimiter
			string[] messageParts = text.Split(new string[] { delim }, StringSplitOptions.None);
			// Just in case..
			if (messageParts.Length != 2) {
				return false;
			}

			// TODO: couldnt trim here to not modify the message, but i should.. maybe.. or not? o.o
			username = messageParts[0];
			message = messageParts[1];

			// Remove |00
			if (message.StartsWith("|00") == true) {
				message = message.Substring(3);
			}

			// TODO: We didnt have max size for message as eAthena
			//		 but the client has (max display size is 254 + 1)
			//		 so.. ? o.o
			if (message.Length >= Global.CHAT_SIZE_MAX) {
				ServerConsole.WarningLine("Chatting.ValidateMessage: Message is to long! Max {0} length, msg has {1}: {2}", Global.CHAT_SIZE_MAX, message.Length, message);
				message = message.Substring(0, Global.CHAT_SIZE_MAX - 1);
			}

			return true;
		}

	}

}
