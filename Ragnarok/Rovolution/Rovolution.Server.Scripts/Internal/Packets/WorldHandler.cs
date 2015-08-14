using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rovolution.Server.Network;
using Rovolution.Server.Objects;
using Rovolution.Server.Geometry;

namespace Rovolution.Server.Scripts.Packets.Handler {

	public class WorldServ {

		/// <summary>
		/// <para>ID 0x0436</para>
		/// <para>Length 19</para>
		/// <para>First packet after selecting a character</para>
		/// </summary>
		public static void WantToConnect(NetState state, PacketReader reader) {
			int accountID = reader.ReadInt32();
			int charID = reader.ReadInt32();
			int loginID1 = reader.ReadInt32();
			int clientTick = reader.ReadInt32();
			byte iSex = reader.ReadByte();
			EAccountSex sex = (EAccountSex)iSex;

			state.Account = World.GetAccount(accountID);
			if (state.Account == null || state.Account.AccountState != EAccountState.Char) {
				state.Disconnect();
				return;
			}
			if (state.Account.LoginID1 != loginID1 || state.Account.Sex != sex) {
				state.Disconnect();
				return;
			}
			if (state.Account.ActiveChar == null || state.Account.ActiveChar.ID != charID) {
				state.Disconnect();
				return;
			}

			// Mark as authed
			state.Account.AccountState = EAccountState.World;
			state.Send(new Response.WorldAuthOK(state.Account));
		}

		/// <summary>
		/// <para>ID 0x007D</para>
		/// <para>Length 0</para>
		/// <para>Notification that the client ressource loading has completed</para>
		/// <para>
		/// No data given, but its the right place to load and send 
		/// everything else.
		/// </para>
		/// </summary>
		public static void LoadEndAck(NetState state, PacketReader reader) {
			if (state.IsValid(EAccountState.World) == false) {
				state.Disconnect();
				return;
			}

			// TODO:
			//		- check if variable loading and every other hist has been finished
			//		- check for rewarp (find out)
			//		- changelook calls
			//		- send inventory list
			//		- check items
			//		- if cart on, send cart-info and check items
			//		- send weights
			//		- if guild, send short guild info
			//		- check for invicible timer
			//		- clif_spawn() (.. what? Oo)
			//		- if party, send infos
			//		- check for pvp, gvg, duel, ...
			//		- getareacharinfo for nearby objects
			//		- pet, homunculus, mercanery
			//		- if first connection, send complete status
			//		- send friendlist info (friend logged in)
			//		- login npc events
			//		- if not first connect, refresh some infos
			//		- many many more..

		}


		/// Notification of the state of client command /effect (CZ_LESSEFFECT)
		/// 021D 6: <state>.L
		public static void LessEffect(NetState state, PacketReader reader) {
			if (state.IsValid(EAccountState.World) == false) {
				state.Disconnect();
				return;
			}

			// 0 = Full effects
			// 1 = Reduced effects
			int lessEffect = reader.ReadInt32();
		}

		/// 014f 6: <state>.L
		public static void GuildRequestInfo(NetState state, PacketReader reader) {
			if (state.IsValid(EAccountState.World) == false) {
				state.Disconnect();
				return;
			}

			Character c = state.Account.ActiveChar;
			// Nothing to send?
			if (!(c.GuildID is Serial)) {
				// TODO: or battleground ID
				return;
			}

			int requestType = reader.ReadInt32();
			switch (requestType) {
				case 0:
					//clif_guild_basicinfo(sd);
					//clif_guild_allianceinfo(sd);
					break;
				case 1:
					//clif_guild_positionnamelist(sd);
					//clif_guild_memberlist(sd);
					break;
				case 2:
					//clif_guild_positionnamelist(sd);
					//clif_guild_positioninfolist(sd);
					break;
				case 3:
					//clif_guild_skillinfo(sd);
					break;
				case 4:
					//clif_guild_expulsionlist(sd);
					break;
				default:
					ServerConsole.ErrorLine("GuildRequestInfo: Unknown request type {0}", requestType);
					break;
			}
		}

		/// Validates and processes global messages
		/// 008C/00F3 -1: <packet len>.W <text>.?B (<name> : <message>) 00
		public static void GlobalMessage(NetState state, PacketReader reader) {
			if (state.IsValid(EAccountState.World) == false) {
				state.Disconnect();
				return;
			}

			short textLen = (short)(reader.ReadInt16() - 4);
			string text = reader.ReadString(textLen);

			// TODO:
			//		- check name/message
			//		- check atcommand
			//		- process message to all in range (9 cells)
			//		- trigger listening npc's
			//		- log chat
		}

		/// Request servert ticks
		/// 0089 11: <clientTicks>.L
		public static void TickSend(NetState state, PacketReader reader) {
			if (state.IsValid(EAccountState.World) == false) {
				state.Disconnect();
				return;
			}

			// TODO: has a length of 11..
			// state.Account.ClientTick = reader.ReadInt32();
			// TODO: send server ticks
		}


		/// Requesting unit's name
		/// 0094 6: <object id>.L
		public static void CharNameRequest(NetState state, PacketReader reader) {
			if (state.IsValid(EAccountState.World) == false) {
				state.Disconnect();
				return;
			}

			int id = reader.ReadInt32();
			// Disguises using -ID..
			if (id < 0 && -id == state.Account.ID) {
				id = (int)state.Account.ID;
			}

			SerialObject obj = World.GetObject(id);
			if (obj == null) {
				// Lagged clients could request names of already gone mobs/players..
				// so no disconnect on invalid requests..
				//state.Disconnect();
				return;
			}

			if (obj.Location.Map != state.Account.ActiveChar.Location.Map) {
				// || !check_distance_bl(&sd->bl, bl, AREA_SIZE)
				return; // Block namerequests past view range
			}

			// 'see people in GM hide' cheat detection
			/* disabled due to false positives (network lag + request name of char that's about to hide = race condition)
			sc = status_get_sc(bl);
			if (sc && sc->option&OPTION_INVISIBLE && !disguised(bl) &&
				bl->type != BL_NPC && //Skip hidden NPCs which can be seen using Maya Purple
				pc_isGM(sd) < battle_config.hack_info_GM_level
			) {
				char gm_msg[256];
				sprintf(gm_msg, "Hack on NameRequest: character '%s' (account: %d) requested the name of an invisible target (id: %d).\n", sd->status.name, sd->status.account_id, id);
				ShowWarning(gm_msg);
				// information is sent to all online GMs
				intif_wis_message_to_gm(wisp_server_name, battle_config.hack_info_GM_level, gm_msg);
				return;
			}
			*/

			// TODO: implement me :o
			//clif_charnameack(fd, bl);
		}

		/// Request for game exiting
		/// 018A 4: <dont_know>.W
		public static void QuitGame(NetState state, PacketReader reader) {
			if (state.IsValid(EAccountState.World) == false) {
				state.Disconnect();
				return;
			}

			// TODO: logout check
			state.Send(new Response.WorldConfirmGameExit(true));
		}

		/// Request to walk
		/// 0x00A7 9: 
		public static void WalkToXY(NetState state, PacketReader reader) {
			if (state.IsValid(EAccountState.World) == false) {
				state.Disconnect();
				return;
			}

			Character c = state.Account.ActiveChar;

			int unkInt = reader.ReadInt32();
			// Since 2008-08-27aRagexeRE, X/Y starts at pos 6
			byte b1 = reader.ReadByte();
			byte b2 = reader.ReadByte();
			byte b3 = reader.ReadByte();
			int x = b1 * 4 + (b2 >> 6);
			int y = ((b2 & 0x3f) << 4) + (b3 >> 4);
			Point2D targetLoc = new Point2D(x, y);
			c.TargetLocation = c.Location.Point + (c.Location.Point - targetLoc);
		}

	}

}
