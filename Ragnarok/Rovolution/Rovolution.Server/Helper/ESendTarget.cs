using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Systems {

	public enum ESendTarget {
		AllClients,
		AllSameMap,
		Area,
		AreaWithoutSelf,
		AreaWithoutChatrooms,
		AreaWithoutOwnChatrooms,
		HearableAreaWithoutChatrooms,
		Chat,
		ChatWithoutSelf,
		Party,
		PartyWithoutSelf,
		PartySameMap,
		PartySameMapWithoutSelf,
		PartyArea,
		PartyAreaWithoutSelf,
		Guild,
		GuildWithoutSelf,
		GuildSameMap,
		GuildSameMapWithoutSelf,
		GuildArea,
		GuildAreaWithoutSelf,
		GuildWithoutBG,
		Duel,
		DuelWithoutSelf,
		ChatMainchat,
		Self,
		Battleground,
		BattlegroundWithoutSelf,
		BattlegroundSameMap,
		BattlegroundSameMapWithoutSelf,
		BattlegroundArea,
		BattlegroundAreaWithoutSelf,
	}

}
