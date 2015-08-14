using System;

namespace GodLesZ.Games.Ragnarok.RoBot.Library.Objects.Enumerations {
	
	[Flags()]
	public enum EItemRestriction {
		None = 0,

		NoDrop = 1,
		NoTradeVend = 2,
		PartnerCanOverride = 4, // Wedded partner can override flag 2
		NoSoldToNpc = 8,
		NoPlacedInCart = 16,
		NoPlacedInStorage = 32,
		NoPlacedInGuildStorage = 64,
	}

}
