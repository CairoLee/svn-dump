using System.Collections.Generic;
using Rovolution.Server.Geometry;
using Rovolution.Server.Helper;
using Rovolution.Server.Objects;

namespace Rovolution.Server.Network.Packets {

	public class WorldServ {

		/// First packet after selecting a character
		/// 0x0436 19: <accountID>.L <charID>.L <loginID1>.L <clientTick>.L <sex>.B
		public static void WantToConnect(NetState state, PacketReader reader) {
			int accountID = reader.ReadInt32();
			int charID = reader.ReadInt32();
			int loginID1 = reader.ReadInt32();
			int clientTick = reader.ReadInt32();
			byte iSex = reader.ReadByte();
			EAccountSex sex = (EAccountSex)iSex;

			state.Account = (Account)World.Objects[EDatabaseType.Account, accountID];
			if (state.Account == null || state.Account.AccountState != EAccountState.Char) {
				ServerConsole.DebugLine("Invalid account or account state: {0}", (state.Account != null ? state.Account.AccountState.ToString() : "null"));
				state.Disconnect();
				return;
			}
			if (state.Account.LoginID1 != loginID1 || state.Account.Sex != sex) {
				ServerConsole.DebugLine("Invalid loginID or sex: {0} != {1}; {2} != {3}", state.Account.LoginID1, loginID1, state.Account.Sex, sex);
				state.Disconnect();
				return;
			}
			if (state.Account.ActiveChar == null || state.Account.ActiveChar.ID != charID) {
				ServerConsole.DebugLine("Invalid active character or charID: {0}", (state.ActiveChar != null ? state.ActiveChar.ID.ToString() : "null"));
				state.Disconnect();
				return;
			}

			// Seems to be valid, save the netstate
			state.Account.Netstate = state;

			long tick = Timer.Ticks;

			// Mark as authed
			state.Account.AccountState = EAccountState.World;

			// pc_setnew
			state.ActiveChar.Status.Sex = state.Account.Sex;
			state.ActiveChar.LoginID1 = loginID1;
			state.ActiveChar.LoginID2 = 0;
			state.ActiveChar.ClientTick = clientTick;
			state.ActiveChar.State.Active = false; //Is set to true after player is fully authed and loaded

			state.ActiveChar.CanLogTick = tick;
			// Required to prevent homunculus copuing a base speed of 0
			state.ActiveChar.BattleStatus.Speed = (ushort)Global.DEFAULT_WALK_SPEED;

			// pc_authok
			if (state.ActiveChar.Status.HP == 0) {
				state.ActiveChar.SetDead();
			}
			state.ActiveChar.State.ConnectNew = true;

			state.ActiveChar.FollowTimer = null;
			state.ActiveChar.InvisibleTimer = null;
			state.ActiveChar.NpcTimer = null;
			state.ActiveChar.PvpTimer = null;

			state.ActiveChar.CanUseItemTick = tick;
			state.ActiveChar.CanUseCashFoodTick = tick;
			state.ActiveChar.CanEquipTick = tick;
			state.ActiveChar.CanTalkTick = tick;
			state.ActiveChar.CanSendMailTick = tick;

			state.ActiveChar.SpiritTimer = new List<Timer>();
			state.ActiveChar.AutoBonus.Clear();
			state.ActiveChar.AutoBonus2.Clear();
			state.ActiveChar.AutoBonus3.Clear();

			if (Config.ItemAutoGet) {
				state.ActiveChar.State.Autoloot = 10000;
			}
			if (Config.DispExperience) {
				state.ActiveChar.State.Showexp = true;
			}
			if (Config.DispZeny) {
				state.ActiveChar.State.Showzeny = true;
			}
			if ((Config.DisplaySkillFail & 2) > 0) {
				state.ActiveChar.State.Showdelay = true;
			}

			// Check and move equip 
			//pc_setinventorydata(sd);
			for (int i = 0; i < state.ActiveChar.Status.Inventory.Count; i++) {
			}
			//pc_setequipindex(sd);

			// status_change_init here!
			// Note: eAthena dosnt realy init the status here, just memset() all to 0

			// TODO: why did i set StatusChange.Clear() HERE? confirm this..
			state.ActiveChar.StatusChange.Clear();

			// TODO: implement player commands (eAthenas @commands)
			//if ((battle_config.atc_gmonly == 0 || pc_isGM(sd)) && (pc_isGM(sd) >= get_atcommand_level(atcommand_hide)))
			//	sd->status.option &= (OPTION_MASK | OPTION_INVISIBLE);
			//else
			state.ActiveChar.Status.Option &= EStatusOption.Mask;

			state.ActiveChar.StatusChange.Option = state.ActiveChar.Status.Option; // This is the actual option used in battle
			// Set here because we need the inventory data for weapon sprite parsing
			state.ActiveChar.ViewData = WorldObjectViewData.GetViewData(state.ActiveChar.Status, (int)state.ActiveChar.Status.Class);

			// Set base timer for walkable units (from unit_setdata)
			// TODO: maybe this should be placed in a WorldObjectUnit-method to be used for every walkable unit..
			state.ActiveChar.WalkTimer = null;
			state.ActiveChar.ActiveSkillTimer = null;
			state.ActiveChar.AttackTimer = null;
			state.ActiveChar.AttackableTick =
				state.ActiveChar.CanActTick =
				state.ActiveChar.CanMoveTick = tick;

			// clif_authok crap
			state.ActiveChar.GuildPosition = new Point2D(-1, -1);

			// Event timer
			state.ActiveChar.EventTimer = new List<Timer>();
			// Rental Timer
			state.ActiveChar.RentalTimer = null;

			state.ActiveChar.HateMob = new short[3]{
				-1,-1,-1
			};

			// Character enters the map block
			// TODO: Position checking
			state.ActiveChar.Location.Map.OnEnter(state.ActiveChar);
			/*
			if ((i = pc_setpos(sd, sd->status.last_point.map, sd->status.last_point.x, sd->status.last_point.y, CLR_OUTSIGHT)) != 0) {
				ShowError("Last_point_map %s - id %d not found (error code %d)\n", mapindex_id2name(sd->status.last_point.map), sd->status.last_point.map, i);

				// try warping to a default map instead (church graveyard)
				if (pc_setpos(sd, mapindex_name2id(MAP_PRONTERA), 273, 354, CLR_OUTSIGHT) != 0) {
					// if we fail again
					clif_authfail_fd(sd->fd, 0);
					return false;
				}
			}
			*/

			// Let the client know that the authendication was successfull
			state.Send(new WorldResponseAuthOK(state.Account));

			// eA puts the "char logged in" message here..

			// TODO: send friend list

			// TODO: message about expired accounts, night flag

			// TODO: request registry
			//		 or dont need an async load of registry?

			state.ActiveChar.DieCounter = -1;
		}

		/// Notification that the client ressource loading has completed
		/// 007D 2: No data given
		public static void LoadEndAck(NetState state, PacketReader reader) {
			if (state.IsValid(EAccountState.World) == false) {
				state.Disconnect();
				return;
			}


			state.Send(new WorldMessageOverHead("Welcome to Rovolution v0.1 Alpha!"));
			state.Send(new WorldMessageOverHead("© GodLesZ 2011"));

			// TODO: eAthena requests the registery and then trigger clif_parse_LoadEndAckk
			//		 so move the code to a callback (if implemented an async registry loading)

			// pc_reg_received

			// TODO: party_member_joined, guild_member_joined

			// TODO request pet and homunculus data..

			state.ActiveChar.BaseStatus.CalculateCharacter(true);

			// TODO: request mail box, quest log

			// TODO: pc_inventory_rentals()


			// clif_parse_LoadEndAck()
			// Note: This is called as a packet from the client
			//		 but if the registry loading hasent been finished, its stoped and called manually
			//		 from pc_reg_received

			// TODO: ChangeLook

			// Update clothes color, or some sprite bugs & display errors will happen
			if (state.ActiveChar.ViewData.ClothesColor > 0) {
				state.Send(new WorldRefreshLook((int)state.Account.ID, ELookType.Clothes_color, (short)state.ActiveChar.ViewData.ClothesColor));
			}

			// Send inventory
			// Note: This is a special packet..
			//		 In OnBeforeSend() is checked if items are found; only if found, the packet will be send
			//		 In OnSend() is checked for arrow and stackable items and send, if found
			//		 So this call may send 3 packet a time, to each player
			World.Send(new WorldInventoryList(state.ActiveChar), state.ActiveChar, ESendTarget.Self);
			// Client got the item infos, now validate inventory
			// TODO: :D

			state.Send(new WorldUpdateStatus(state.ActiveChar, EStatusParam.Weight));
			state.Send(new WorldUpdateStatus(state.ActiveChar, EStatusParam.Maxweight));


			// TODO:shit
			//		- check if variable loading and every other shit has been finished
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

			// Inform nearby objects about me
			WorldObjectSpawn.Send(state.ActiveChar, true);

			// Info about nearby objects
			//map_foreachinarea(clif_getareachar, sd->bl.m, sd->bl.x - AREA_SIZE, sd->bl.y - AREA_SIZE, sd->bl.x + AREA_SIZE, sd->bl.y + AREA_SIZE, BL_ALL, sd);
			state.ActiveChar.Map.ForeachInRange(new Rectangle2D(state.ActiveChar.Location.Point - Global.AREA_SIZE_POINT, state.ActiveChar.Location.Point - Global.AREA_SIZE_POINT), EDatabaseType.All, new ForeachInRangeVoidDelegate(Callback_GetAreaChar), new object[] { state.ActiveChar });

			// TODO: spawn pets, homu, ect


			if (state.ActiveChar.State.ConnectNew == true) {
				state.ActiveChar.State.ConnectNew = false;

				// send skills, hotkeys, status, ..
				state.Send(new WorldSendSkillList(state.ActiveChar));
				state.Send(new WorldSendHotkeys(state.ActiveChar));

				state.Send(new WorldUpdateStatus(state.ActiveChar, EStatusParam.Baseexp));
				state.Send(new WorldUpdateStatus(state.ActiveChar, EStatusParam.Nextbaseexp));
				state.Send(new WorldUpdateStatus(state.ActiveChar, EStatusParam.Jobexp));
				state.Send(new WorldUpdateStatus(state.ActiveChar, EStatusParam.Nextjobexp));
				state.Send(new WorldUpdateStatus(state.ActiveChar, EStatusParam.Skillpoint));

				state.Send(new WorldSendInitialStatus(state.ActiveChar));

				if ((state.ActiveChar.StatusChange.Option & EStatusOption.Falcon) > 0) {
					//clif_status_load(&sd->bl, SI_FALCON, 1);
				}
				if ((state.ActiveChar.StatusChange.Option & EStatusOption.Riding) > 0) {
					//clif_status_load(&sd->bl, SI_RIDING, 1);
				}

				if (state.ActiveChar.Status.Manner < 0) {
					//sc_start(&sd->bl,SC_NOCHAT,100,0,0);
				}
				/*
				//Auron reported that This skill only triggers when you logon on the map o.O
				if ((lv = pc_checkskill(sd,SG_KNOWLEDGE)) > 0) {
					if(sd->bl.m == sd->feel_map[0].m
						|| sd->bl.m == sd->feel_map[1].m
						|| sd->bl.m == sd->feel_map[2].m)
						sc_start(&sd->bl, SC_KNOWLEDGE, 100, lv, skill_get_time(SG_KNOWLEDGE, lv));
				}
				*/
				//if(sd->pd && sd->pd->pet.intimate > 900)
				//	clif_pet_emotion(sd->pd,(sd->pd->pet.class_ - 100)*100 + 50 + pet_hungry_val(sd->pd));

				//if(merc_is_hom_active(sd->hd))
				//	merc_hom_init_timers(sd->hd);

				//if (night_flag && map[sd->bl.m].flag.nightenabled) {
				//	sd->state.night = 1;
				//	clif_status_load(&sd->bl, SI_NIGHT, 1);
				//}

				// Notify everyone that this friend logged in
				//map_foreachpc(clif_friendslist_toggle_sub, sd->status.account_id, sd->status.char_id, 1);

				// TODO: npc login event
			} else {
				// refresh infos ect
			}

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
			state.Account.ActiveChar.State.Lesseffect = reader.ReadBoolean();
		}

		/// Sends information about the guild of the target
		/// 014f 6: <state>.L
		public static void GuildRequestInfo(NetState state, PacketReader reader) {
			if (state.IsValid(EAccountState.World) == false) {
				state.Disconnect();
				return;
			}

			Character c = state.Account.ActiveChar;
			// Nothing to send?
			if (!(c.Status.GuildID is WorldID)) {
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

			short baseLength = (short)(reader.ReadInt16() - 4);
			string baseMessage = reader.ReadString(baseLength);

			string username, message;
			if (ChatHelper.ValidateMessage(state, baseMessage, out username, out message) == false) {
				return;
			}
			// Check is implemented, but no commands yet.. xD
			if (PlayerCommandHelper.IsCommand(message) == true) {
				PlayerCommandHelper.Execute(state, message);
				return;
			}

			// Send packet to all players in the chatroom or in hearable area
			// Note: yes, the Client needs the full String "Name : Message"
			//		 and dosnt take the name from the source..
			//		 so we just use the original received string
			ESendTarget target = (state.ActiveChar.Status.ChatID is WorldID ? ESendTarget.ChatWithoutSelf : ESendTarget.HearableAreaWithoutChatrooms);
			World.Send(new WorldChatMessage(state.ActiveChar, baseMessage), state.ActiveChar, target);

			// Send packet to himself
			// Note: the base string "Name : Message" is used again..
			World.Send(new WorldMessageOverHead(baseMessage), state.ActiveChar, ESendTarget.Self);
			// TODO:
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
			//		 but the client didnt care about it
			//		 but we could implement a latency info if we diff the ticks.. o.o
		}


		/// Requesting unit's name
		/// 0094 14: <dont_know>.? Position 10 <object id>.L
		public static void CharNameRequest(NetState state, PacketReader reader) {
			if (state.IsValid(EAccountState.World) == false) {
				state.Disconnect();
				return;
			}

			reader.Seek(10, System.IO.SeekOrigin.Begin);
			int id = reader.ReadInt32();
			// Disguises using -ID..
			if (id < 0 && -id == state.Account.ID) {
				id = (int)state.Account.ID;
			}

			// First option - a character
			WorldObject obj = World.Objects[EDatabaseType.Char, id];
			if (obj == null) {
				// 2nd - a monster
				obj = World.Objects[EDatabaseType.Mob, id];
				if (obj == null) {
					// 3rd - a item (?)
					obj = World.Objects[EDatabaseType.Item, id];
					if (obj == null) {
						// Lagged clients could request names of already gone mobs/players..
						// so no disconnect on invalid requests..
						//state.Disconnect();
						return;
					}
				}
			}

			// Fix: we send the accountID as unique ID for chars (its working because no account could connect twice)
			//		this leads to this situation, we will get the account object from World.Objects
			//		instead of the character
			if (obj is Account) {
				obj = (obj as Account).ActiveChar;
			}

			// Moveable unit?
			if (
				(obj is WorldObjectUnit) && (
					(obj as WorldObjectUnit).Location.Map != state.Account.ActiveChar.Location.Map ||
					(obj as WorldObjectUnit).InRange(state.ActiveChar, Global.AREA_SIZE) == false
				)
			) {
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

			state.Send(new WorldResponseCharNameAck(obj));
		}

		/// Request for game exiting
		/// 018A 4: <dont_know>.W
		public static void QuitGame(NetState state, PacketReader reader) {
			if (state.IsValid(EAccountState.World) == false) {
				state.Disconnect();
				return;
			}

			// TODO: logout check

			// Save data
			state.ActiveChar.Save();

			state.Send(new WorldResponseGameExit(true));
		}

		/// Request to walk
		/// 0x00A7 9: 
		public static void WalkToXY(NetState state, PacketReader reader) {
			if (state.IsValid(EAccountState.World) == false) {
				state.Disconnect();
				return;
			}

			// TODO: this is the worst system i've ever seen..
			//		 we receive the FINAL position instead of step by step packets
			//		 and have to search a path to the final position
			//		 if a path has been found, we walk it step by step
			//		 this is done using a Timer..
			Character c = state.Account.ActiveChar;

			int unkInt = reader.ReadInt32();
			// Since 2008-08-27aRagexeRE, X/Y starts at pos 6
			byte b1 = reader.ReadByte();
			byte b2 = reader.ReadByte();
			byte b3 = reader.ReadByte();
			int x = b1 * 4 + (b2 >> 6);
			int y = ((b2 & 63) << 4) + (b3 >> 4);
			ServerConsole.DebugLine("WalkToXY: from " + c.Location.X + "/" + c.Location.Y + " to " + x + "/" + y);
			WalkingHelper.WalkToXY(c, new Point2D(x, y));
		}

		/// Request for attack (single or continue), sit or stand
		/// 0437 4: <type>.B <objectID>.L
		public static void ActionRequest(NetState state, PacketReader reader) {
			if (state.IsValid(EAccountState.World) == false) {
				state.Disconnect();
				return;
			}

			int id = reader.ReadInt32();
			byte action = reader.ReadByte();

			Callback_ActionRequest(state.ActiveChar, action, id);
		}

		/// Request for attack stop
		/// 0118 2: 
		public static void StopAttack(NetState state, PacketReader reader) {
			if (state.IsValid(EAccountState.World) == false) {
				state.Disconnect();
				return;
			}

			state.ActiveChar.StopAttack();
		}







		/// <summary>
		/// Callback for ForeachInRange call, identifies the found object and sends infos about it to the client
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="args"></param>
		private static void Callback_GetAreaChar(WorldObject obj, object[] args) {
			Character src = (Character)args[0];
			if (src == null || obj == null) {
				return;
			}

			switch (obj.Type) {
				case EDatabaseType.Item:
					break;
				case EDatabaseType.Skill:
					break;
				default:
					// Dont send info about me 
					if (src == obj) {
						break;
					}
					Callback_GetAreaCharUnit(obj, args);
					break;
			}
		}

		/// <summary>
		/// Callback sub-method for all units (player, npc, mob, pet, homu, merc)
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="args"></param>
		private static void Callback_GetAreaCharUnit(WorldObject obj, object[] args) {
			Character src = (Character)args[0];
			if (src == null || obj == null) {
				return;
			}

			WorldObjectViewData vd = WorldObject.GetViewData(obj);
			if (vd == null/* || vd.Class == INVISIBLE_CLASS)*/) {
				return;
			}

			// Unit is walking?
			if ((obj is WorldObjectUnit) && (obj as WorldObjectUnit).WalkTimer != null) {
				World.Send(new WorldSendUnitWalking(obj), src, ESendTarget.Self);
			} else {
				World.Send(new WorldSendUnitIdle(obj, false), src, ESendTarget.Self);
			}

			if (vd.ClothesColor > 0) {
				//clif_refreshlook(&sd->bl,bl->id,LOOK_CLOTHES_COLOR,vd->cloth_color,SELF);
			}

			switch (obj.Type) {
				case EDatabaseType.Char:
					//clif_getareachar_pc

					// Special states
					// Battleground emblem
					break;

				case EDatabaseType.Mob:
					// Special states/sizes
					break;

				case EDatabaseType.Mercenary:
					// Devotion effect
					break;

				case EDatabaseType.Npc:
					// Chat over head
					// Special states/sizes
					break;

				case EDatabaseType.Pet:
					// Head bottom (Pet equip)
					break;

			}
		}

		/// <summary>
		/// Callback for executing an action (attack/sit/stand) to a target (ID)
		/// </summary>
		/// <param name="character"></param>
		/// <param name="action"></param>
		/// <param name="id"></param>
		private static void Callback_ActionRequest(Character character, byte action, int id) {
			// TODO: check for dead player
			// TODO: check for trickdead, autocounter or bladestop (no action available)

			character.StopWalking(0x1);
			character.StopAttack();

			// For disguise
			if (id < 0 && -id == character.AccountID) {
				id = (int)character.AccountID;
			}

			switch (action) {
				case 0x0: // Attack once
				case 0x7: // Attack continue
					if (character.CantAct() == false || (character.StatusChange.Option & EStatusOption.Hide) > 0) {
						return;
					}
					EStatusOption badOptions = (EStatusOption.Wedding | EStatusOption.Xmas | EStatusOption.Summer);
					if ((character.StatusChange.Option & badOptions) > 0) {
						return;
					}

					// TODO: basilica
					// TODO: freecast check

					character.ResetInvisibleTimer();
					character.Attack(id, (action != 0x0));
					break;
				case 0x02: // sitdown
					/*
					if (battle_config.basic_skill_check && pc_checkskill(sd, NV_BASIC) < 3) {
						clif_skill_fail(sd, 1, 0, 2);
						break;
					}
					*/

					if (character.IsSit() == true) {
						// Bugged client? Just refresh them
						World.Send(new WorldUnitSitStand(character, true), character, ESendTarget.Area);
						return;
					}

					if (Timer.IsValid(character.ActiveSkillTimer) == true || character.StatusChange.Option1 != EStatusOption1.None) {
						break;
					}
					/*
					if (sd->sc.count && (
						sd->sc.data[SC_DANCING] ||
						(sd->sc.data[SC_GRAVITATION] && sd->sc.data[SC_GRAVITATION]->val3 == BCT_SELF)
					)) //No sitting during these states either.
						break;
					*/
					character.SetSit();
					//skill_sit(sd, 1);
					World.Send(new WorldUnitSitStand(character, true), character, ESendTarget.Area);
					break;
				case 0x03: // standup
					if (character.IsSit() == false) {
						World.Send(new WorldUnitSitStand(character, false), character, ESendTarget.Area);
						return;
					}
					character.SetStand();
					//skill_sit(sd, 0);
					World.Send(new WorldUnitSitStand(character, false), character, ESendTarget.Area);
					break;
			}

		}

	}

}
