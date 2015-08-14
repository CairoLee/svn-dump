using System.Collections.Generic;
using System.Text;
using Rovolution.Server.Objects;
using Rovolution.Server.Network;

namespace Rovolution.Server.Network.Packets {

	public class LoginServ {

		public static void AccountLogin(NetState state, PacketReader reader) {
			int clientVersion = reader.ReadInt32();
			string loginName = reader.ReadString(24);
			string loginPassword = reader.ReadString(24);
			byte clientType = reader.ReadByte();

			Account acc;
			EAccountLoadResult result = Account.Load(state, loginName, loginPassword, out acc, false);
			if (result != EAccountLoadResult.Success) {
				state.Send(new LoginResponseAccountError((byte)result));
				state.Disconnect();
				return;
			}


			// Update current state & last login
			acc.AccountState = EAccountState.Login;
			acc.UpdateLastLogin(state.Address.ToString());

			state.Send(new LoginResponseServerList(acc));
		}

	}

}