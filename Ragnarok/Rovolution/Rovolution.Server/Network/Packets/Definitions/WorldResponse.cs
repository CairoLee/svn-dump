using System;
using System.Collections.Generic;
using Rovolution.Server.Geometry;
using Rovolution.Server.Helper;
using Rovolution.Server.Objects;

namespace Rovolution.Server.Network.Packets {

	// TODO: split into multiple files.. 
	//		  dont want these to be 50.000 lines of code only searchable using strg+f..

	public class WorldResponseConnect : Packet {
		public WorldResponseConnect(Account account)
			: base(0x283, 6) {
			Write(account.ID);
		}
	}

	public class WorldResponseAuthOK : Packet {
		public WorldResponseAuthOK(Account account)
			: base(0x73, 11) {
			Write((int)DateTime.Now.Ticks);
			Write(account.ActiveChar.Location);
			Write((byte)5); // ignored..
			Write((byte)5); // ignored..
		}
	}

	public class WorldResponseGameExit : Packet {
		public WorldResponseGameExit(bool allowed)
			: base(0x18b, 4) {
			if (allowed == true) {
				Write((short)0);
			} else {
				Write((short)1);
			}
		}
	}

	public class WorldResponseWalkOK : Packet {
		public WorldResponseWalkOK(Character c)
			: base(0x87, 12) {
			Write((int)DateTime.Now.Ticks);
			Write(c.Location.Point, c.TargetLocation, new Point2D(8, 8));
		}
	}

	public class WorldResponseCharNameAck : Packet {
		public WorldResponseCharNameAck(WorldObject obj)
			: base(0x95, 30) {

			switch (obj.Type) {
				case EDatabaseType.Char:
					// Identify disguise using negative ID
					if ((obj as Character).Disguise != 0) {
						Write((int)-(obj as Character).AccountID);
					} else {
						Write((int)(obj as Character).AccountID);
					}

					// Charname
					Write((obj as Character).Status.Name, Global.NAME_LENGTH);
					// Character has a party or guild?
					if (!((obj as Character).Status.GuildID is WorldID) && !((obj as Character).Status.PartyID is WorldID)) {
						// Nothing of them
					} else {
						// Than its another packetID..
						PacketID = 0x195;
						Length = (78 + Global.NAME_LENGTH);
						// 30: Party name 
						// 54: Guild name
						// 78: Guild position/rank name
					}

					break;

				case EDatabaseType.Mob:
					Write((int)obj.ID);
					Write((obj as Monster).Name);
					int showInfo = Config.ShowMobInfo;

					// TODO: check for guild data

					// If no guild data..
					if (showInfo != 0) {
						List<string> mobinfo = new List<string>();
						// Its another packet..
						PacketID = 0x195;
						Length = (78 + Global.NAME_LENGTH);

						// Level
						if ((showInfo & 4) == 4) {
							mobinfo.Add(string.Format("Lv. {0}", (obj as Monster).Level));
						}
						// HP/HPMax
						if ((showInfo & 1) == 1) {
							mobinfo.Add(string.Format("HP: {0}/{1}", (obj as Monster).Status.HP, (obj as Monster).Status.HPMax));
						}
						// HP %
						if ((showInfo & 2) == 2) {
							mobinfo.Add(string.Format("HP: {0}%", (obj as Monster).Status.HP.Percent((obj as Monster).Status.HPMax)));
						}

						if (mobinfo.Count > 0) {
							string info = mobinfo.Implode(" | ");

							// Let the client show the info as party name: Mobname (info)
							Writer.Position = 30;
							Write(info, Global.NAME_LENGTH);
							Writer.Position = 78;
							Write(info, Global.NAME_LENGTH);
						}
					}

					break;
			}

		}
	}


	public class WorldChatMessage : Packet {
		public WorldChatMessage(Character c, string message)
			: base(0x8D) {
			Write((short)(message.Length + 1 + 8)); // Packet length
			Write(c.Parent.ID);
			Write(message, true);
		}
	}

	public class WorldMessageOverHead : Packet {
		public WorldMessageOverHead(string message)
			: base(0x8E) {
			Write((short)(message.Length + 1 + 4)); // Packet length
			Write(message, true);
		}
	}

	public class WorldMessageOnlySelf : Packet {
		public WorldMessageOnlySelf(string message)
			: base(0x17F) {
			Write((short)(message.Length + 1 + 4)); // Packet length
			Write(message, true);
		}
	}


	public class WorldChangeLook : Packet {
		public WorldChangeLook(DatabaseObject obj)
			: base(0x1d7, 11) {
		}
	}

	public class WorldRefreshLook : Packet {
		public WorldRefreshLook(int objID, ELookType type, short value)
			: base(0x1d7, 11) {
			Write(objID);
			Write((byte)type);
			Write(value);
			Write((short)0); // don't know
		}
	}

	public class WorldInventoryList : Packet {
		private int mStackableItems = 0;
		private int mNonStackableItems = 0;
		private Packet mStackablePacket;
		private int mArrowPosition = -1;

		public WorldInventoryList(Character c)
			: base(0x2e8) {
			// The client wants two single packets.. one for stackable and one for non-stackable..
			mStackablePacket = new Packet(0x2d0);
			foreach (CharacterItem item in c.Status.Inventory) {
				Write((short)(mNonStackableItems + mStackableItems + 2));

				if (item.Data.IsStackable == false) {
					// Non-stackable

					item.WriteItemData(this, (int)item.GetEquipLocation()); // 10 bytes
					item.WriteItemCardData(this); // 8 bytes
					Write((int)item.ExpireTime.Ticks);
					Write((short)0); // Unknown
					if ((item.Equip & EItemEquipLocation.Helm) > 0) {
						Write((short)item.Data.ViewID);
					} else {
						Write((short)0);
					}

					mNonStackableItems++;
				} else {
					// Stackable

					item.WriteItemData(mStackablePacket, -2); // 10 bytes
					// Remember arrow position in inventory
					if (item.Data.EquipLocation == EItemEquipLocation.Ammo && (int)item.Equip > 0) {
						mArrowPosition = (mNonStackableItems + mStackableItems);
					}
					item.WriteItemCardData(mStackablePacket); // 8 bytes
					mStackablePacket.Write((int)item.ExpireTime.Ticks);

					mStackableItems++;
				}
			} // end foreach


		}

		public override bool OnBeforeSend(NetState state) {
			if (base.OnBeforeSend(state) == false) {
				return false;
			}

			// Only send if items found
			return (mNonStackableItems > 0);
		}

		public override void OnSend(NetState state) {
			// after sending normal (non-stackable), send other data
			// Send arrow position, if found
			if (mArrowPosition != 1) {
				World.Send(new WorldArrowIndex((short)mArrowPosition), state.ActiveChar, ESendTarget.Self);
			}
			// Found stackable items? Send them
			if (mStackableItems > 0) {
				World.Send(mStackablePacket, state.ActiveChar, ESendTarget.Self);
			}

			base.OnSend(state);
		}


	}

	public class WorldArrowIndex : Packet {
		public WorldArrowIndex(short pos)
			: base(0x013c, 4) {
			Write((short)pos);
		}
	}

	public class WorldObjectSpawn {
		public static void Send(WorldObject obj, bool spawn) {

			World.Send(new WorldSendUnitIdle(obj, spawn), obj, ESendTarget.AreaWithoutSelf);

			// TODO: disguised

			// TODO: cloth color

			// TODO: specials for each object type (small/big i.e.)
		}
	}

	public class WorldSendUnitIdle : Packet {

		public WorldSendUnitIdle(WorldObject obj, bool spawn)
			: base(0) {
			string name = WorldObject.GetName(obj);
			WorldObjectStatus status = WorldObject.GetStatusData(obj);
			WorldObjectViewData vd = WorldObject.GetViewData(obj);
			WorldObjectStatusChangeList sc = WorldObject.GetStatusChange(obj);
			ushort speed = WorldObject.GetSpeed(obj);

			Writer.Position = 0;
			Write((short)(spawn ? 0x7f8 : 0x7f9));
			Write((short)((spawn ? 62 : 63) + name.Length));
			Write((byte)obj.GetPacketType());
			Write((uint)(obj is Character ? (obj as Character).Account.ID : obj.ID)); // For Character, send accountID as unique ID
			Write((ushort)speed); // status_get_speed(bl);
			Write((short)(sc != null ? sc.Option1 : 0)); // (sc) ? sc->opt1 : 0;
			Write((short)(sc != null ? sc.Option2 : 0)); // (sc) ? sc->opt2 : 0;
			Write((int)(sc != null ? sc.Option : 0)); // (sc) ? sc->option : 0;
			Write((short)(obj is NpcScript ? (obj as NpcScript).Class : (short)vd.Class)); // vd->class_;
			Write((short)(vd != null ? vd.HairStlye : 0)); // vd->hair_style;
			Write((short)(vd != null ? vd.Weapon : 0)); // vd->weapon;
			Write((short)(vd != null ? vd.Shield : 0)); // vd->shield;
			Write((short)(vd != null ? vd.HeadBottom : 0)); // vd->head_bottom
			Write((short)(vd != null ? vd.HeadTop : 0)); // vd->head_top;
			Write((short)(vd != null ? vd.HeadMid : 0)); // vd->head_mid;

			// TODO: implementieren!
			/*
			if (bl->type == BL_NPC && vd->class_ == FLAG_CLASS) {	//The hell, why flags work like this?
				WBUFL(buf, 22) = status_get_emblem_id(bl);
				WBUFL(buf, 26) = status_get_guild_id(bl);
			}
			*/

			Write((short)(vd != null ? vd.HairColor : 0)); // vd->hair_color;
			Write((short)(vd != null ? vd.ClothesColor : 0)); // vd->cloth_color;
			Write((short)0); // (sd) ? sd->head_dir : 0;


			Write((int)0); // status_get_guild_id(bl);
			Write((short)0); // status_get_emblem_id(bl);
			Write((short)0); // (sd) ? sd->status.manner : 0;

			Write((int)(sc != null ? sc.Option3 : 0)); // (sc) ? sc->opt3 : 0;

			Write((byte)0); // (sd) ? sd->status.karma : 0;
			Write((byte)(vd != null ? vd.Sex : 0)); // vd->sex;
			Write((obj as WorldObjectUnit).Location);
			Write((byte)(obj is Character ? 5 : 0)); // (sd) ? 5 : 0;
			Write((byte)(obj is Character ? 5 : 0)); // (sd) ? 5 : 0;
			if (!spawn) {
				Write((byte)(vd != null ? vd.DeadSit : 0)); // vd->dead_sit;
			}
			Write((short)WorldObject.GetLevel(obj)); // clif_setlevel(status_get_lv(bl));

			Write((short)0); // sd ? sd->state.user_font : 0;
			int pos = Writer.Position;
			Write(name);
			pos = Writer.Position;
		}

	}

	public class WorldSendUnitWalking : Packet {
		public WorldSendUnitWalking(WorldObject obj)
			: base(0) {

			WorldObjectStatusChangeList sc = WorldObject.GetStatusChange(obj);
			WorldObjectViewData vd = WorldObject.GetViewData(obj);
			string name = WorldObject.GetName(obj);
			ushort speed = WorldObject.GetSpeed(obj);

			Writer.Position = 0;
			Write((short)0x7f7);
			Write((short)(69 + name.Length));

			Write((byte)obj.GetPacketType());
			Write((uint)(obj is Character ? (obj as Character).Account.ID : obj.ID)); // For Character, send accountID as unique ID
			Write((ushort)speed); // status_get_speed(bl);
			Write((short)(sc != null ? sc.Option1 : 0)); // (sc) ? sc->opt1 : 0;
			Write((short)(sc != null ? sc.Option2 : 0)); // (sc) ? sc->opt2 : 0;
			Write((int)(sc != null ? sc.Option : 0)); // (sc) ? sc->option : 0;
			Write((short)vd.Class); // vd->class_;
			Write((short)vd.HairStlye); // vd->hair_style;
			Write((short)vd.Weapon); // vd->weapon;
			Write((short)vd.Shield); // vd->shield;
			Write((short)vd.HeadBottom); // vd->head_bottom
			Write((int)Timer.Ticks);
			Write((short)vd.HeadTop); // vd->head_top;
			Write((short)vd.HeadMid); // vd->head_mid;

			Write((short)vd.HairColor); // vd->hair_color;
			Write((short)vd.ClothesColor); // vd->cloth_color;
			Write((short)0); // (sd) ? sd->head_dir : 0;


			Write((int)0); // status_get_guild_id(bl);
			Write((short)0); // status_get_emblem_id(bl);
			Write((short)0); // (sd) ? sd->status.manner : 0;

			Write((int)(sc != null ? sc.Option3 : 0)); // (sc) ? sc->opt3 : 0;

			Write((byte)0); // (sd) ? sd->status.karma : 0;
			Write((byte)vd.Sex); // vd->sex;
			Write((obj as WorldObjectUnit).Location);
			Write((byte)(obj is Character ? 5 : 0)); // (sd) ? 5 : 0;
			Write((byte)(obj is Character ? 5 : 0)); // (sd) ? 5 : 0;
			Write((short)WorldObject.GetLevel(obj)); // clif_setlevel(status_get_lv(bl));

			Write((short)0); // sd ? sd->state.user_font : 0;
			int pos = Writer.Position;
			Write(name);
			pos = Writer.Position;
		}
	}

	public class WorldSendSkillList : Packet {
		public WorldSendSkillList(Character c)
			: base(0x10f) {

			SkillDatabaseData skill;
			int len = 0, i = 0, id = 0;
			for (; i < c.Status.Skills.Length; i++) {
				if (c.Status.Skills[i].ID != 0) {
					skill = World.Database[(ESkill)i];
					Write((ushort)skill.SkillID);
					Write((ushort)skill.Inf);
					Write((ushort)0); // Dont know
					Write((ushort)c.Status.Skills[i].Level);
					Write((ushort)skill.Level[c.Status.Skills[i].Level - 1].Sp);
					Write((ushort)skill.Level[c.Status.Skills[i].Level - 1].Range);
					Write(skill.Name, Global.NAME_LENGTH);
					if (c.Status.Skills[i].Flag == ESkillFlag.Permanent) {
						Write((byte)(c.Status.Skills[i].Level < SkillTree.Tree[(int)c.Status.Class][skill.SkillID].MaxLevel ? 1 : 0));
					} else {
						Write((byte)0);
					}
					len += 37;
				}
			}

			// Add packet length
			Write((short)len);
		}
	}

	public class WorldSendHotkeys : Packet {
		public WorldSendHotkeys(Character c)
			: base(0x07d9) {

			// The client wants the info about every hotkey, so..
			for (int i = 0; i < Global.MAX_HOTKEYS; i++) {
				Write((byte)c.Status.Hotkeys[i].Type);
				Write((int)c.Status.Hotkeys[i].ID);
				Write((short)c.Status.Hotkeys[i].Level);
			}
		}
	}

	public class WorldUpdateStatus : Packet {
		public WorldUpdateStatus(Character c, EStatusParam type)
			: base(0xb0) {
			// For misc calculation
			int len = 0;

			Write((short)type);
			switch (type) {
				case EStatusParam.Weight:
					// TODO: update ow50/ow90 state here
					Write((int)c.Weight);
					break;
				case EStatusParam.Maxweight:
					Write((int)c.MaxWeight);
					break;
				case EStatusParam.Speed:
					Write((int)c.BattleStatus.Speed);
					break;
				case EStatusParam.Baselevel:
					Write((int)c.Status.LevelBase);
					break;
				case EStatusParam.Joblevel:
					Write((int)c.Status.LevelJob);
					break;
				case EStatusParam.Karma:
					Write((int)c.Status.Karma);
					break;
				case EStatusParam.Manner:
					Write((int)c.Status.Manner);
					break;
				case EStatusParam.Statuspoint:
					Write((int)c.Status.StatusPoints);
					break;
				case EStatusParam.Skillpoint:
					Write((int)c.Status.SkillPoints);
					break;
				case EStatusParam.Hit:
					Write((int)c.BattleStatus.Hit);
					break;
				case EStatusParam.Flee1:
					Write((int)c.BattleStatus.Flee);
					break;
				case EStatusParam.Flee2:
					Write((int)(c.BattleStatus.Flee2 / 10));
					break;
				case EStatusParam.Maxhp:
					Write((int)c.BattleStatus.HPMax);
					break;
				case EStatusParam.Maxsp:
					Write((int)c.BattleStatus.SPMax);
					break;
				case EStatusParam.Hp:
					Write((int)c.BattleStatus.HP);
					//if (battle_config.disp_hpmeter)
					//	clif_hpmeter(sd);
					//if (!battle_config.party_hp_mode && sd->status.party_id)
					//	clif_party_hp(sd);
					//if (sd->bg_id)
					//	clif_bg_hp(sd);
					break;
				case EStatusParam.Sp:
					Write((int)c.BattleStatus.SP);
					break;
				case EStatusParam.Aspd:
					Write((int)c.BattleStatus.AMotion);
					break;
				case EStatusParam.Atk1:
					//WFIFOL(fd, 4) = sd->battle_status.batk + sd->battle_status.rhw.atk + sd->battle_status.lhw.atk;
					Write((int)c.BattleStatus.AtkBase);
					break;
				case EStatusParam.Def1:
					Write((int)c.BattleStatus.Def);
					break;
				case EStatusParam.Mdef1:
					Write((int)c.BattleStatus.MDef);
					break;
				case EStatusParam.Atk2:
					//WFIFOL(fd, 4) = sd->battle_status.rhw.atk2 + sd->battle_status.lhw.atk2;
					break;
				case EStatusParam.Def2:
					Write((int)c.BattleStatus.Def2);
					break;
				case EStatusParam.Mdef2:
					//negative check (in case you have something like Berserk active)
					len = (c.BattleStatus.MDef2 - (c.BattleStatus.Vit >> 1));
					if (len < 0) {
						len = 0;
					}
					Write((int)len);
					len = 0;
					break;
				case EStatusParam.Critical:
					Write((int)(c.BattleStatus.Crit / 10));
					break;
				case EStatusParam.Matk1:
					Write((int)c.BattleStatus.MagicAtkMax);
					break;
				case EStatusParam.Matk2:
					Write((int)c.BattleStatus.MagicAtkMin);
					break;


				// Another packet: 0xb1
				case EStatusParam.Zeny:
					PacketID = 0xb1;
					Write((int)c.Status.Zeny);
					break;
				case EStatusParam.Baseexp:
					PacketID = 0xb1;
					Write((int)c.Status.ExpBase);
					break;
				case EStatusParam.Jobexp:
					PacketID = 0xb1;
					Write((int)c.Status.ExpJob);
					break;
				case EStatusParam.Nextbaseexp:
					PacketID = 0xb1;
					Write((int)10); // TODO: pc_nextbaseexp()
					break;
				case EStatusParam.Nextjobexp:
					PacketID = 0xb1;
					Write((int)10); // TODO: pc_nextjobexp()
					break;

				// Another packet: 0xbe
				case EStatusParam.Ustr:
				case EStatusParam.Uagi:
				case EStatusParam.Uvit:
				case EStatusParam.Uint:
				case EStatusParam.Udex:
				case EStatusParam.Uluk:
					PacketID = 0xbe;
					//WFIFOB(fd, 4) = pc_need_status_point(sd, type - SP_USTR + SP_STR, 1);
					len = 5;
					break;

				// Another packet: 0x013a
				case EStatusParam.Attackrange:
					PacketID = 0x013a;
					//WFIFOW(fd, 2) = sd->battle_status.rhw.range;
					len = 4;
					break;

				// Another packet: 0141
				case EStatusParam.Str:
					PacketID = 0x141a;
					Write((int)c.Status.Str);
					Write((int)(c.BattleStatus.Str - c.Status.Str));
					len = 14;
					break;
				case EStatusParam.Agi:
					PacketID = 0x141a;
					Write((int)c.Status.Agi);
					Write((int)(c.BattleStatus.Agi - c.Status.Agi));
					len = 14;
					break;
				case EStatusParam.Vit:
					PacketID = 0x141a;
					Write((int)c.Status.Vit);
					Write((int)(c.BattleStatus.Vit - c.Status.Vit));
					len = 14;
					break;
				case EStatusParam.Int:
					PacketID = 0x141a;
					Write((int)c.Status.Int);
					Write((int)(c.BattleStatus.Int - c.Status.Int));
					len = 14;
					break;
				case EStatusParam.Dex:
					PacketID = 0x141a;
					Write((int)c.Status.Dex);
					Write((int)(c.BattleStatus.Dex - c.Status.Dex));
					len = 14;
					break;
				case EStatusParam.Luk:
					PacketID = 0x141a;
					Write((int)c.Status.Luk);
					Write((int)(c.BattleStatus.Luk - c.Status.Luk));
					len = 14;
					break;

				// Another packet: 0x121
				case EStatusParam.Cartinfo:
					// Completly different..
					Writer.Position = 0;
					Write((short)0x121);
					Write((short)c.CartNum);
					Write((short)Global.MAX_CART);
					Write((int)c.CartWeight);
					Write((int)8000); // battle_config.max_cart_weight;
					len = 14;
					break;
				default:
					ServerConsole.ErrorLine("Unknown StatusParam: " + type);
					break;
			}
		}
	}

	public class WorldSendInitialStatus : Packet {
		public WorldSendInitialStatus(Character c)
			: base(0xbd) {

			Write((short)c.Status.StatusPoints);
			Write((byte)c.Status.Str);
			Write((byte)c.Status.CalcNeededStatusPoints(EStatusParam.Str, 1));
			Write((byte)c.Status.Agi);
			Write((byte)c.Status.CalcNeededStatusPoints(EStatusParam.Agi, 1));
			Write((byte)c.Status.Dex);
			Write((byte)c.Status.CalcNeededStatusPoints(EStatusParam.Dex, 1));
			Write((byte)c.Status.Vit);
			Write((byte)c.Status.CalcNeededStatusPoints(EStatusParam.Vit, 1));
			Write((byte)c.Status.Int);
			Write((byte)c.Status.CalcNeededStatusPoints(EStatusParam.Int, 1));
			Write((byte)c.Status.Luk);
			Write((byte)c.Status.CalcNeededStatusPoints(EStatusParam.Luk, 1));

			Write((short)(c.BattleStatus.AtkBase + c.BattleStatus.Rhw.AtkMin + c.BattleStatus.Lhw.AtkMin)); // sd->battle_status.batk + sd->battle_status.rhw.atk + sd->battle_status.lhw.atk;
			Write((short)(c.BattleStatus.Rhw.AtkMax + c.BattleStatus.Lhw.AtkMax)); // sd->battle_status.rhw.atk2 + sd->battle_status.lhw.atk2; //atk bonus
			Write((short)c.BattleStatus.MagicAtkMax);
			Write((short)c.BattleStatus.MagicAtkMin);
			Write((short)c.BattleStatus.Def);
			Write((short)c.BattleStatus.Def2);
			Write((short)c.BattleStatus.MDef);
			int mdef2 = c.BattleStatus.MDef2 - (c.BattleStatus.Vit >> 1);
			if (mdef2 < 0) {
				mdef2 = 0; //Negative check for Frenzy'ed characters
			}
			Write((short)mdef2);
			Write((short)c.BattleStatus.Hit);
			Write((short)c.BattleStatus.Flee);
			Write((short)(c.BattleStatus.Flee2 / 10));
			Write((short)(c.BattleStatus.Crit / 10));
			Write((short)c.BattleStatus.AMotion);
			Write((short)c.Status.Manner); // FIXME: This is 'plusASPD', but what is it supposed to be?
		}

		public override void OnSend(NetState state) {
			base.OnSend(state);

			state.Send(new WorldUpdateStatus(state.ActiveChar, EStatusParam.Str));
			state.Send(new WorldUpdateStatus(state.ActiveChar, EStatusParam.Agi));
			state.Send(new WorldUpdateStatus(state.ActiveChar, EStatusParam.Dex));
			state.Send(new WorldUpdateStatus(state.ActiveChar, EStatusParam.Vit));
			state.Send(new WorldUpdateStatus(state.ActiveChar, EStatusParam.Int));
			state.Send(new WorldUpdateStatus(state.ActiveChar, EStatusParam.Luk));

			state.Send(new WorldUpdateStatus(state.ActiveChar, EStatusParam.Attackrange));
			state.Send(new WorldUpdateStatus(state.ActiveChar, EStatusParam.Aspd));
		}
	}


	/// Visually moves(slides) a character to x,y. If the target cell
	/// isn't walkable, the char doesn't move at all. If the char is
	/// sitting it will stand up.
	/// S 0088 <gid>.L <x>.W <y>.W
	public class WorldFixpos : Packet {

		public WorldFixpos(WorldObjectUnit obj)
			: base(0x88, 10) {
			Write((int)(obj is Character ? (obj as Character).AccountID : obj.ID));
			Write((short)obj.Location.X);
			Write((short)obj.Location.Y);
		}


		public override void OnSend(NetState state) {
			if (state.ActiveChar.Disguise > 0) {
				// Refresh pos for disguised chars
				Packet p = new Packet(0x88, 10);
				p.Write((int)-state.Account.ID);
				p.Write((short)state.ActiveChar.Location.X);
				p.Write((short)state.ActiveChar.Location.Y);

				World.Send(p, state.ActiveChar, ESendTarget.Self);
			}
			base.OnSend(state);
		}
	}

	public class WorldUnitSitStand : Packet {
		private bool mSitting;

		public WorldUnitSitStand(WorldObjectUnit obj, bool sitting)
			: base(0x8a, 27) {
			mSitting = sitting;

			Write((int)(obj is Character ? (obj as Character).AccountID : obj.ID));
			// Go, ask gravity..
			Writer.Position = 26;
			Write((byte)(sitting == true ? 2 : 3));
		}


		public override void OnSend(NetState state) {
			if (state.ActiveChar.Disguise > 0) {
				// Refresh for disguised chars
				Packet p = new Packet(0x8a, 27);
				p.Write((int)-state.Account.ID);
				Writer.Position = 26;
				Write((byte)(mSitting == true ? 2 : 3));

				World.Send(p, state.ActiveChar, ESendTarget.Self);
			}
			base.OnSend(state);
		}
	}

}
