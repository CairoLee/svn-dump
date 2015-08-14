package Enums
{

    public class CURSOR_VALID extends Object
    {
        public static const SET_STREET_STREET_ALREADY_AT_POSITION:int = nr + 1;
        public static const SET_STREET_SECTOR_IS_OWNED_BY_BANDITS:int = nr + 1;
        public static const APPLY_BUFF_COULD_NOT_INTERPRET_TYPE_SNH:int = nr + 1;
        public static const BUILDING_PLACED_TRY_TO_PLACE_NORMAL_BUILDING_OVER_DEPOSIT:int = nr + 1;
        public static const SET_STREET_COVERED_WITH_FOG:int = nr + 1;
        public static const MINE_TYPE_PLACE_IS_BLOCKED:int = nr + 1;
        public static const APPLY_BUFF_BUILDING_IS_INACTIVE:int = nr + 1;
        public static const BUILDING_PLACED_BLOCKED_BY_BLOCKING:int = nr + 1;
        public static const BUILDING_PLACED_PLACE_IS_COVERED_WITH_FOG:int = nr + 1;
        public static const ATTACK_MODE_ON_ADVENTURE_ZONE_BUT_NOT_PVP:int = nr + 1;
        public static const ATTACK_MODE_BUILDING_BELONGS_TO_CURRENT_PLAYER:int = nr + 1;
        public static const APPLY_BUFF_DEPOSIT_IS_OF_WRONG_TYPE:int = nr + 1;
        public static const PLACE_IS_NOT_REACHABLE_BY_PATH_FINDING:int = nr + 1;
        public static const SECTOR_DOES_NOT_BELONG_TO_PLAYER:int = nr + 1;
        public static const SECTOR_BELONGS_TO_BANDITS:int = nr + 1;
        public static const APPLY_BUFF_ON_FOREIGN_ZONE_BUILDING_IS_NOT_OF_CORRECT_TYPE:int = nr + 1;
        public static const APPLY_BUFF_MAXIMUM_NUMBER_OF_BUFFS_REACHED_FOR_THIS_BUILDING:int = nr + 1;
        public static const APPLY_BUFF_ON_DEPOSIT_NO_DEPOSIT_HERE:int = nr + 1;
        public static const SET_STREET_SECTOR_IS_NOT_OWNED_BY_PLAYER:int = nr + 1;
        public static const SET_STREET_PLACE_IS_BLOCKED_BY_BLOCKING:int = nr + 1;
        public static const APPLY_BUFF_WRONG_ZONE_TYPE:int = nr + 1;
        public static const GARISSON_SECTOR_IS_OWNED_BY_BANDITS:int = nr + 1;
        public static const MINE_PLACED_NO_DEPOSIT_HERE:int = nr + 1;
        public static const APPLY_BUFF_ZONE_IS_NOT_HOMEZONE:int = nr + 1;
        private static var nr:int = 0;
        public static const BUILDING_PLACED_BUILDING_IS_IN_LIST_SNH:int = nr + 1;
        public static const SET_STREET_PLACE_IS_BLOCKED_BY_DEPOSIT:int = nr + 1;
        public static const ATTACK_MODE_PLAYER_ID_OF_BUILDING_IS_ZERO_SNH:int = nr + 1;
        public static const APPLY_BUFF_NO_BUILDING_AT_POSITION:int = nr + 1;
        public static const EDITOR_PLACE_OTHER_BUILDING_IS_TO_NEAR:int = nr + 1;
        public static const ILLEGAL_POS:int = nr + 1;
        public static const OK:int = nr + 1;
        public static const EDITOR_PLACE_ALLOCATED_WITH_STREET:int = nr + 1;
        public static const SECTOR_IS_OWNED_BY_BANDITS:int = nr + 1;
        public static const ATTACK_MODE_BUILDING_BELONGS_TO_HOMEZONE_PLAYER:int = nr + 1;
        public static const EDITOR_PLACE_ALLOCATED_WITH_BUILDING:int = nr + 1;
        public static const EDITOR_ERASE_BUILDING:int = nr + 1;
        public static const APPLY_BUFF_TEMPORARILY_BLOCKED:int = nr + 1;
        public static const MINE_PLACED_OVER_BUILDING_BUT_IT_IS_NOT_A_DEPLETED_DEPOSIT:int = nr + 1;
        public static const APPLY_BUFF_NO_PLAYER_SNH:int = nr + 1;
        public static const PLACE_IS_COVERED_WITH_FOG:int = nr + 1;
        public static const PLACE_IS_BLOCKED_BY_BUILDING:int = nr + 1;
        public static const ATTACK_MODE_HIDDEN_CAMP:int = nr + 1;
        public static const APPLY_BUFF_ON_GUILD_HOUSE_PLAYER_IS_NOT_IN_GUILD:int = nr + 1;
        public static const ATTACK_MODE_NO_BUILDING_AT_DESTINATION:int = nr + 1;
        public static const ERASE_BUILDING_NO_BUILDING_AT_POSITION:int = nr + 1;
        public static const BUILDING_PLACED_BUILDING_IS_ALREADY_THERE:int = nr + 1;
        public static const APPLY_BUFF_ON_GUILD_HOUSE_MAXIMUM_NUMBER_OF_GUILD_MEMBERS_REACHED:int = nr + 1;

        public function CURSOR_VALID()
        {
            return;
        }// end function

        public static function toString(param1:int) : String
        {
            switch(param1)
            {
                case OK:
                {
                    return "OK";
                }
                case BUILDING_PLACED_BUILDING_IS_ALREADY_THERE:
                {
                    return "BUILDING_PLACED_BUILDING_IS_ALREADY_THERE";
                }
                case BUILDING_PLACED_BLOCKED_BY_BLOCKING:
                {
                    return "BUILDING_PLACED_BLOCKED_BY_BLOCKING";
                }
                case ILLEGAL_POS:
                {
                    return "ILLEGAL_POS";
                }
                case PLACE_IS_COVERED_WITH_FOG:
                {
                    return "PLACE_IS_COVERED_WITH_FOG";
                }
                case PLACE_IS_BLOCKED_BY_BUILDING:
                {
                    return "PLACE_IS_BLOCKED_BY_BUILDING";
                }
                case SECTOR_BELONGS_TO_BANDITS:
                {
                    return "SECTOR_BELONGS_TO_BANDITS";
                }
                case SECTOR_DOES_NOT_BELONG_TO_PLAYER:
                {
                    return "SECTOR_DOES_NOT_BELONG_TO_PLAYER";
                }
                case SECTOR_IS_OWNED_BY_BANDITS:
                {
                    return "SECTOR_IS_OWNED_BY_BANDITS";
                }
                case ATTACK_MODE_NO_BUILDING_AT_DESTINATION:
                {
                    return "ATTACK_MODE_NO_BUILDING_AT_DESTINATION";
                }
                case ATTACK_MODE_BUILDING_BELONGS_TO_CURRENT_PLAYER:
                {
                    return "ATTACK_MODE_BUILDING_BELONGS_TO_CURRENT_PLAYER";
                }
                case ATTACK_MODE_BUILDING_BELONGS_TO_HOMEZONE_PLAYER:
                {
                    return "ATTACK_MODE_BUILDING_BELONGS_TO_HOMEZONE_PLAYER";
                }
                case ATTACK_MODE_ON_ADVENTURE_ZONE_BUT_NOT_PVP:
                {
                    return "ATTACK_MODE_ON_ADVENTURE_ZONE_BUT_NOT_PVP";
                }
                case APPLY_BUFF_NO_BUILDING_AT_POSITION:
                {
                    return "APPLY_BUFF_NO_BUILDING_AT_POSITION";
                }
                case APPLY_BUFF_ON_FOREIGN_ZONE_BUILDING_IS_NOT_OF_CORRECT_TYPE:
                {
                    return "APPLY_BUFF_ON_FOREIGN_ZONE_BUILDING_IS_NOT_OF_CORRECT_TYPE";
                }
                case APPLY_BUFF_ON_GUILD_HOUSE_PLAYER_IS_NOT_IN_GUILD:
                {
                    return "APPLY_BUFF_ON_GUILD_HOUSE_PLAYER_IS_NOT_IN_GUILD";
                }
                case APPLY_BUFF_ON_GUILD_HOUSE_MAXIMUM_NUMBER_OF_GUILD_MEMBERS_REACHED:
                {
                    return "APPLY_BUFF_ON_GUILD_HOUSE_MAXIMUM_NUMBER_OF_GUILD_MEMBERS_REACHED";
                }
                case APPLY_BUFF_BUILDING_IS_INACTIVE:
                {
                    return "APPLY_BUFF_BUILDING_IS_INACTIVE";
                }
                case APPLY_BUFF_MAXIMUM_NUMBER_OF_BUFFS_REACHED_FOR_THIS_BUILDING:
                {
                    return "APPLY_BUFF_MAXIMUM_NUMBER_OF_BUFFS_REACHED_FOR_THIS_BUILDING";
                }
                case APPLY_BUFF_ON_DEPOSIT_NO_DEPOSIT_HERE:
                {
                    return "APPLY_BUFF_ON_DEPOSIT_NO_DEPOSIT_HERE";
                }
                case APPLY_BUFF_DEPOSIT_IS_OF_WRONG_TYPE:
                {
                    return "APPLY_BUFF_DEPOSIT_IS_OF_WRONG_TYPE";
                }
                case APPLY_BUFF_ZONE_IS_NOT_HOMEZONE:
                {
                    return "APPLY_BUFF_ZONE_IS_NOT_HOMEZONE";
                }
                case BUILDING_PLACED_PLACE_IS_COVERED_WITH_FOG:
                {
                    return "BUILDING_PLACED_PLACE_IS_COVERED_WITH_FOG";
                }
                case GARISSON_SECTOR_IS_OWNED_BY_BANDITS:
                {
                    return "GARISSON_SECTOR_IS_OWNED_BY_BANDITS";
                }
                case ERASE_BUILDING_NO_BUILDING_AT_POSITION:
                {
                    return "ERASE_BUILDING_NO_BUILDING_AT_POSITION";
                }
                case PLACE_IS_NOT_REACHABLE_BY_PATH_FINDING:
                {
                    return "PLACE_IS_NOT_REACHABLE_BY_PATH_FINDING";
                }
                case MINE_PLACED_OVER_BUILDING_BUT_IT_IS_NOT_A_DEPLETED_DEPOSIT:
                {
                    return "MINE_PLACED_OVER_BUILDING_BUT_IT_IS_NOT_A_DEPLETED_DEPOSIT";
                }
                case MINE_PLACED_NO_DEPOSIT_HERE:
                {
                    return "MINE_PLACED_NO_DEPOSIT_HERE";
                }
                case BUILDING_PLACED_TRY_TO_PLACE_NORMAL_BUILDING_OVER_DEPOSIT:
                {
                    return "BUILDING_PLACED_TRY_TO_PLACE_NORMAL_BUILDING_OVER_DEPOSIT";
                }
                case SET_STREET_STREET_ALREADY_AT_POSITION:
                {
                    return "SET_STREET_STREET_ALREADY_AT_POSITION";
                }
                case SET_STREET_COVERED_WITH_FOG:
                {
                    return "SET_STREET_COVERED_WITH_FOG";
                }
                case SET_STREET_SECTOR_IS_OWNED_BY_BANDITS:
                {
                    return "SET_STREET_SECTOR_IS_OWNED_BY_BANDITS";
                }
                case SET_STREET_SECTOR_IS_NOT_OWNED_BY_PLAYER:
                {
                    return "SET_STREET_SECTOR_IS_NOT_OWNED_BY_PLAYER";
                }
                case SET_STREET_PLACE_IS_BLOCKED_BY_DEPOSIT:
                {
                    return "SET_STREET_PLACE_IS_BLOCKED_BY_DEPOSIT";
                }
                case SET_STREET_PLACE_IS_BLOCKED_BY_BLOCKING:
                {
                    return "SET_STREET_PLACE_IS_BLOCKED_BY_BLOCKING";
                }
                case ATTACK_MODE_PLAYER_ID_OF_BUILDING_IS_ZERO_SNH:
                {
                    return "ATTACK_MODE_PLAYER_ID_OF_BUILDING_IS_ZERO_SNH";
                }
                case APPLY_BUFF_NO_PLAYER_SNH:
                {
                    return "APPLY_BUFF_NO_PLAYER_SNH";
                }
                case APPLY_BUFF_COULD_NOT_INTERPRET_TYPE_SNH:
                {
                    return "APPLY_BUFF_COULD_NOT_INTERPRET_TYPE_SNH";
                }
                case APPLY_BUFF_WRONG_ZONE_TYPE:
                {
                    return "APPLY_BUFF_WRONG_ZONE_TYPE";
                }
                case BUILDING_PLACED_BUILDING_IS_IN_LIST_SNH:
                {
                    return "BUILDING_PLACED_BUILDING_IS_IN_LIST_SNH";
                }
                case MINE_TYPE_PLACE_IS_BLOCKED:
                {
                    return "MINE_TYPE_PLACE_IS_BLOCKED";
                }
                case EDITOR_ERASE_BUILDING:
                {
                    return "EDITOR_ERASE_BUILDING";
                }
                case EDITOR_PLACE_ALLOCATED_WITH_BUILDING:
                {
                    return "EDITOR_PLACE_ALLOCATED_WITH_BUILDING";
                }
                case EDITOR_PLACE_ALLOCATED_WITH_STREET:
                {
                    return "EDITOR_PLACE_ALLOCATED_WITH_STREET";
                }
                case EDITOR_PLACE_OTHER_BUILDING_IS_TO_NEAR:
                {
                    return "EDITOR_PLACE_OTHER_BUILDING_IS_TO_NEAR";
                }
                default:
                {
                    break;
                }
            }
            return "Unknown: " + param1;
        }// end function

    }
}
