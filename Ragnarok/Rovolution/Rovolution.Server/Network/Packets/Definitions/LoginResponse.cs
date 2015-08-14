using Rovolution.Server.Objects;

namespace Rovolution.Server.Network.Packets {

	public class LoginResponseServerError : Packet {

		public LoginResponseServerError(byte errNumber)
			: base(0x81, 3) {
			Write(errNumber);
		}
	}

	public class LoginResponseAccountError : Packet {

		public LoginResponseAccountError(byte errNumber)
			: base(0x6A, 23) {

			Write(errNumber);
			/*
				case   0: error = "Unregistered ID."; break; // 0 = Unregistered ID
				case   1: error = "Incorrect Password."; break; // 1 = Incorrect Password
				case   2: error = "Account Expired."; break; // 2 = This ID is expired
				case   3: error = "Rejected from server."; break; // 3 = Rejected from Server
				case   4: error = "Blocked by GM."; break; // 4 = You have been blocked by the GM Team
				case   5: error = "Not latest game EXE."; break; // 5 = Your Game's EXE file is not the latest version
				case   6: error = "Banned."; break; // 6 = Your are Prohibited to log in until %s
				case   7: error = "Server Over-population."; break; // 7 = Server is jammed due to over populated
				case   8: error = "Account limit from company"; break; // 8 = No more accounts may be connected from this company
				case   9: error = "Ban by DBA"; break; // 9 = MSI_REFUSE_BAN_BY_DBA
				case  10: error = "Email not confirmed"; break; // 10 = MSI_REFUSE_EMAIL_NOT_CONFIRMED
				case  11: error = "Ban by GM"; break; // 11 = MSI_REFUSE_BAN_BY_GM
				case  12: error = "Working in DB"; break; // 12 = MSI_REFUSE_TEMP_BAN_FOR_DBWORK
				case  13: error = "Self Lock"; break; // 13 = MSI_REFUSE_SELF_LOCK
				case  14: error = "Not Permitted Group"; break; // 14 = MSI_REFUSE_NOT_PERMITTED_GROUP
				case  15: error = "Not Permitted Group"; break; // 15 = MSI_REFUSE_NOT_PERMITTED_GROUP
				case  99: error = "Account gone."; break; // 99 = This ID has been totally erased
				case 100: error = "Login info remains."; break; // 100 = Login information remains at %s
				case 101: error = "Hacking investigation."; break; // 101 = Account has been locked for a hacking investigation. Please contact the GM Team for more information
				case 102: error = "Bug investigation."; break; // 102 = This account has been temporarily prohibited from login due to a bug-related investigation
				case 103: error = "Deleting char."; break; // 103 = This character is being deleted. Login is temporarily unavailable for the time being
				case 104: error = "Deleting spouse char."; break; // 104 = This character is being deleted. Login is temporarily unavailable for the time being
			*/
			if (errNumber != 6) {
				Writer.Fill(20);
			} else {
				// 6 = Your are Prohibited to log in until %s
				// TODO: sending date
				Writer.Fill(20);
			}
		}
	}

	public class LoginResponseServerList : Packet {

		public LoginResponseServerList(Account acc)
			: base(0x69) {

			int serverCount = 1;
			Write((short)(47 + (32 * serverCount)));
			Write(acc.LoginID1);
			Write((int)acc.WorldID.ID);
			Write(acc.LoginID2);
			Write((int)0); // in old version, that was for ip (not more used)
			Writer.Fill(24); // in old version, that was for name (not more used)
			Write((short)0); // unknown
			Write((byte)acc.Sex); // sd->sex

			// Server list
			// TODO: after M$ set the Address-property to deprecated, we need our own way to
			//		 convert an IP to a number.
			//		 Compare them vs more networks to ensure it works properly
			//int ipNum = (int)Core.Connector.Listener.IPs[0].Address; // Depri =/
			int ipNum = (int)Core.Connector.Listener.IPs[0].GetAddress();
			int port = Core.Connector.Listener.Ports[0];
			for (int i = 0; i < serverCount; i++) {
				Write(ipNum); // Server IP
				Write((short)port); // Server Port
				Write("Rovolution", 20); // Server Name
				Write((short)1337); // Usercount
				Write((short)0); // Server type (RPG/?)
				Write((short)i); // is new?
			}

		}

	}

}
