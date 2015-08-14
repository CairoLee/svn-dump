using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rovolution.Server.Network;
using Rovolution.Server.Objects;

namespace Rovolution.Server.Scripts.Packets.Handler {

	public class CharServ {

		public static void AccountAuth(NetState state, PacketReader reader) {
			int accountID = reader.ReadInt32();
			int loginID1 = reader.ReadInt32();
			int loginID2 = reader.ReadInt32();
			int unknown = reader.ReadInt16(); // offset 14 - 16
			int iSex = reader.ReadByte();
			EAccountSex sex = (EAccountSex)iSex;

			state.Account = World.GetAccount(accountID);
			if (
				state.Account == null ||
				state.Account.AccountState != EAccountState.Login ||
				state.Account.LoginID1 != loginID1 ||
				state.Account.LoginID2 != loginID2 ||
				state.Account.Sex != sex
			) {
				// Wrong data - hack attempt?
				state.Account = null;
				state.Send(new Response.CharacterResponseError((byte)0));
				return;
			}

			// Mark as authed in character server
			state.Account.AccountState = EAccountState.Char;
			state.Account.LoadChars();

			// Auth successfull, send a special packet containing the AccountID
			state.Send(new Response.CharacterResponseSuccess(state.Account));
			// Send character list
			state.Send(new Response.CharacterList(state.Account));
		}

		public static void KeepAlive(NetState state, PacketReader reader) {
			int accountID = reader.ReadInt32();
			if (state.Account == null || state.Account.AccountState != EAccountState.Char || accountID != state.Account.Serial.Value) {
				state.Disconnect();
				return;
			}

			//state.UpdateAcitivty();
		}

		public static void CharacterCreation(NetState state, PacketReader reader) {
			if (state.Account == null || state.Account.AccountState != EAccountState.Char) {
				state.Disconnect();
				return;
			}

			string name = reader.ReadString(24);
			byte attrStr = reader.ReadByte();
			byte attrAgi = reader.ReadByte();
			byte attrVit = reader.ReadByte();
			byte attrInt = reader.ReadByte();
			byte attrDex = reader.ReadByte();
			byte attrLuk = reader.ReadByte();
			byte slot = reader.ReadByte();
			short hairColor = reader.ReadInt16();
			short hairStyle = reader.ReadInt16();

			Character newChar = null;
			ECharacterCreationResult result = Character.Create(state.Account, name, slot, attrStr, attrAgi, attrVit, attrInt, attrDex, attrLuk, hairColor, hairStyle, out newChar);
			if (result != ECharacterCreationResult.Success) {
				state.Send(new Response.CharacterCreationResponse(result));
				return;
			}

			// Creation was successfull, send new characterlist
			state.Send(new Response.NewCharacterData(newChar));
		}

		public static void CharacterSelect(NetState state, PacketReader reader) {
			short slot = reader.ReadByte();

			if (state.Account == null || state.Account.AccountState != EAccountState.Char) {
				state.Send(new Response.CharacterResponseError((byte)0));
				state.Disconnect();
				return;
			}
			if (state.Account.HasSlot(slot) == false) {
				state.Send(new Response.CharacterResponseError((byte)0));
				state.Disconnect();
				return;
			}

			Character selectedChar = state.Account.SetActiveChar(slot);
			state.Send(new Response.CharacterWorldLogin(selectedChar));
		}

	}

}
