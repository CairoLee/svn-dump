package Enums
{

    public class MAIL_TYPE extends Object
    {
        public static const QUEST_LOOT:int = 28;
        public static const HARD_CURRENCY_PURCHASED:int = 12;
        public static const GUILD_INVITE_DECLINE:int = 20;
        public static const COOPERATION_REWARD:int = 30;
        public static const FIND_ADVENTURE_LOOT_MAP_FRAGMENT:int = 27;
        public static const ITEM_TRADE:int = 14;
        public static const GUILD_INVITE_FULL:int = 21;
        public static const BATTLE_REPORT:int = 8;
        public static const BATTLE_REPORT_INTERCEPTED:int = 29;
        public static const BUFFED_BUILDING:int = 11;
        public static const FRIEND_INVITATION_CONFIRMED:int = 17;
        public static const DECLINE_TRADE:int = 5;
        public static const ACCEPT_ITEM_TRADE:int = 15;
        public static const INVITE_TO_ADVENTURE:int = 23;
        public static const FIND_ADVENTURE_LOOT_POSITIVE:int = 25;
        public static const BANDITS_LOOT:int = 7;
        public static const MAIL:int = 0;
        public static const TREASURE_LOOT:int = 6;
        public static const GUILD_KICK:int = 22;
        public static const GIFT:int = 9;
        public static const ADVENTURE_WON_LOOT:int = 19;
        public static const DECLINE_ITEM_TRADE:int = 16;
        public static const TRADE:int = 1;
        public static const ACCEPT_TRADE:int = 4;
        public static const FRIEND_REQUEST:int = 2;
        public static const BUFF:int = 10;
        public static const ADVENTURE_LOST_LOOT:int = 24;
        public static const FIND_ADVENTURE_LOOT_NEGATIVE:int = 26;
        public static const INVITED_FRIEND_PURCHASED:int = 18;
        public static const BUFFED_DEPOSIT:int = 13;
        public static const GUILD_INVITE:int = 3;

        public function MAIL_TYPE()
        {
            return;
        }// end function

        public static function parse(param1:String) : int
        {
            if (param1 == toString(MAIL))
            {
                return MAIL;
            }
            if (param1 == toString(TRADE))
            {
                return TRADE;
            }
            if (param1 == toString(FRIEND_REQUEST))
            {
                return FRIEND_REQUEST;
            }
            if (param1 == toString(GUILD_INVITE))
            {
                return GUILD_INVITE;
            }
            if (param1 == toString(ACCEPT_TRADE))
            {
                return ACCEPT_TRADE;
            }
            if (param1 == toString(DECLINE_TRADE))
            {
                return DECLINE_TRADE;
            }
            if (param1 == toString(TREASURE_LOOT))
            {
                return TREASURE_LOOT;
            }
            if (param1 == toString(BANDITS_LOOT))
            {
                return BANDITS_LOOT;
            }
            if (param1 == toString(BATTLE_REPORT))
            {
                return BATTLE_REPORT;
            }
            if (param1 == toString(GIFT))
            {
                return GIFT;
            }
            if (param1 == toString(BUFF))
            {
                return BUFF;
            }
            if (param1 == toString(BUFFED_BUILDING))
            {
                return BUFFED_BUILDING;
            }
            if (param1 == toString(HARD_CURRENCY_PURCHASED))
            {
                return HARD_CURRENCY_PURCHASED;
            }
            if (param1 == toString(BUFFED_DEPOSIT))
            {
                return BUFFED_DEPOSIT;
            }
            if (param1 == toString(ITEM_TRADE))
            {
                return ITEM_TRADE;
            }
            if (param1 == toString(ACCEPT_ITEM_TRADE))
            {
                return ACCEPT_ITEM_TRADE;
            }
            if (param1 == toString(DECLINE_ITEM_TRADE))
            {
                return DECLINE_ITEM_TRADE;
            }
            if (param1 == toString(FRIEND_INVITATION_CONFIRMED))
            {
                return FRIEND_INVITATION_CONFIRMED;
            }
            if (param1 == toString(INVITED_FRIEND_PURCHASED))
            {
                return INVITED_FRIEND_PURCHASED;
            }
            if (param1 == toString(ADVENTURE_WON_LOOT))
            {
                return ADVENTURE_WON_LOOT;
            }
            if (param1 == toString(GUILD_INVITE_DECLINE))
            {
                return GUILD_INVITE_DECLINE;
            }
            if (param1 == toString(GUILD_INVITE_FULL))
            {
                return GUILD_INVITE_FULL;
            }
            if (param1 == toString(GUILD_KICK))
            {
                return GUILD_KICK;
            }
            if (param1 == toString(INVITE_TO_ADVENTURE))
            {
                return INVITE_TO_ADVENTURE;
            }
            if (param1 == toString(ADVENTURE_LOST_LOOT))
            {
                return ADVENTURE_LOST_LOOT;
            }
            if (param1 == toString(FIND_ADVENTURE_LOOT_POSITIVE))
            {
                return FIND_ADVENTURE_LOOT_POSITIVE;
            }
            if (param1 == toString(FIND_ADVENTURE_LOOT_NEGATIVE))
            {
                return FIND_ADVENTURE_LOOT_NEGATIVE;
            }
            if (param1 == toString(FIND_ADVENTURE_LOOT_MAP_FRAGMENT))
            {
                return FIND_ADVENTURE_LOOT_MAP_FRAGMENT;
            }
            if (param1 == toString(QUEST_LOOT))
            {
                return QUEST_LOOT;
            }
            if (param1 == toString(BATTLE_REPORT_INTERCEPTED))
            {
                return BATTLE_REPORT_INTERCEPTED;
            }
            if (param1 == toString(COOPERATION_REWARD))
            {
                return COOPERATION_REWARD;
            }
            return MAIL;
        }// end function

        public static function toString(param1:int) : String
        {
            switch(param1)
            {
                case MAIL:
                {
                    return "Mail";
                }
                case TRADE:
                {
                    return "Trade";
                }
                case FRIEND_REQUEST:
                {
                    return "FriendRequest";
                }
                case GUILD_INVITE:
                {
                    return "GuildInvite";
                }
                case ACCEPT_TRADE:
                {
                    return "AcceptTrade";
                }
                case DECLINE_TRADE:
                {
                    return "DeclineTrade";
                }
                case TREASURE_LOOT:
                {
                    return "TreasureLoot";
                }
                case BANDITS_LOOT:
                {
                    return "BanditsLoot";
                }
                case BATTLE_REPORT:
                {
                    return "BattleReport";
                }
                case GIFT:
                {
                    return "Gift";
                }
                case BUFF:
                {
                    return "Buff";
                }
                case BUFFED_BUILDING:
                {
                    return "BuffedBuilding";
                }
                case HARD_CURRENCY_PURCHASED:
                {
                    return "HardCurrencyPurchased";
                }
                case BUFFED_DEPOSIT:
                {
                    return "BuffedDeposit";
                }
                case ITEM_TRADE:
                {
                    return "ItemTrade";
                }
                case ACCEPT_ITEM_TRADE:
                {
                    return "AcceptItemTrade";
                }
                case DECLINE_ITEM_TRADE:
                {
                    return "DeclineItemTrade";
                }
                case FRIEND_INVITATION_CONFIRMED:
                {
                    return "FriendInvitationConfirmed";
                }
                case INVITED_FRIEND_PURCHASED:
                {
                    return "InvitedFriendPurchased";
                }
                case ADVENTURE_WON_LOOT:
                {
                    return "AdventureWonLoot";
                }
                case GUILD_INVITE_DECLINE:
                {
                    return "GuildInviteDecline";
                }
                case GUILD_INVITE_FULL:
                {
                    return "GuildInviteFull";
                }
                case GUILD_KICK:
                {
                    return "GuildKick";
                }
                case INVITE_TO_ADVENTURE:
                {
                    return "InviteToAdventure";
                }
                case ADVENTURE_LOST_LOOT:
                {
                    return "AdventureLostLoot";
                }
                case FIND_ADVENTURE_LOOT_POSITIVE:
                {
                    return "FindAdventureLootPositive";
                }
                case FIND_ADVENTURE_LOOT_NEGATIVE:
                {
                    return "FindAdventureLootNegative";
                }
                case FIND_ADVENTURE_LOOT_MAP_FRAGMENT:
                {
                    return "FindAdventureLootMapFragment";
                }
                case QUEST_LOOT:
                {
                    return "QuestLoot";
                }
                case BATTLE_REPORT_INTERCEPTED:
                {
                    return "BattleReportIntercepted";
                }
                case COOPERATION_REWARD:
                {
                    return "CooperationReward";
                }
                default:
                {
                    return "Unknown: " + param1;
                    continue;
                }
            }
        }// end function

    }
}
