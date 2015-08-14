package Enums
{
    import nLib.*;

    public class SPECIALIST_TASK_TYPES extends Object
    {
        public static const DISBAND_ARMY:int = 5;
        public static const RECOVER:int = 2;
        public static const FIND_TREASURE_LONG:int = 14;
        public static const DEPOSIT_SEARCH:int = 0;
        public static const ATTACK_BUILDING:int = 1;
        public static const MOVE:int = 3;
        public static const TRAVEL_TO_ZONE:int = 8;
        public static const FIND_ADVENTURE_ZONE_MEDIUM:int = 11;
        public static const WAIT_FOR_CONFIRMATION:int = 10;
        public static const FIND_ADVENTURE_ZONE_LONG:int = 12;
        public static const FIND_TREASURE_SHORT:int = 6;
        public static const EXPLORE_SECTOR:int = 4;
        public static const FIND_TREASURE_EVEN_LONGER:int = 15;
        public static const FIND_WILD_ZONE:int = 9;
        public static const FIND_ADVENTURE_ZONE_SHORT:int = 7;
        public static const FIND_TREASURE_MEDIUM:int = 13;

        public function SPECIALIST_TASK_TYPES()
        {
            return;
        }// end function

        public static function toString(param1:int) : String
        {
            switch(param1)
            {
                case DEPOSIT_SEARCH:
                {
                    return "FindDeposit";
                }
                case ATTACK_BUILDING:
                {
                    return "AttackBuilding";
                }
                case RECOVER:
                {
                    return "Recover";
                }
                case MOVE:
                {
                    return "Move";
                }
                case EXPLORE_SECTOR:
                {
                    return "ExploreSector";
                }
                case DISBAND_ARMY:
                {
                    return "DisbandArmy";
                }
                case FIND_TREASURE_SHORT:
                {
                    return "FindTreasureShort";
                }
                case FIND_TREASURE_MEDIUM:
                {
                    return "FindTreasureMedium";
                }
                case FIND_TREASURE_LONG:
                {
                    return "FindTreasureLong";
                }
                case FIND_TREASURE_EVEN_LONGER:
                {
                    return "FindTreasureEvenLonger";
                }
                case FIND_ADVENTURE_ZONE_SHORT:
                {
                    return "FindAdventureZoneShort";
                }
                case FIND_ADVENTURE_ZONE_MEDIUM:
                {
                    return "FindAdventureZoneMedium";
                }
                case FIND_ADVENTURE_ZONE_LONG:
                {
                    return "FindAdventureZoneLong";
                }
                case TRAVEL_TO_ZONE:
                {
                    return "TravelToZone";
                }
                case FIND_WILD_ZONE:
                {
                    return "FindWildZone";
                }
                case WAIT_FOR_CONFIRMATION:
                {
                    return "WaitForConfirmation";
                }
                default:
                {
                    return "Unknown: " + param1;
                    continue;
                }
            }
        }// end function

        public static function parse(param1:String) : int
        {
            if (param1 == toString(DEPOSIT_SEARCH))
            {
                return DEPOSIT_SEARCH;
            }
            if (param1 == toString(ATTACK_BUILDING))
            {
                return ATTACK_BUILDING;
            }
            if (param1 == toString(RECOVER))
            {
                return RECOVER;
            }
            if (param1 == toString(MOVE))
            {
                return MOVE;
            }
            if (param1 == toString(EXPLORE_SECTOR))
            {
                return EXPLORE_SECTOR;
            }
            if (param1 == toString(DISBAND_ARMY))
            {
                return DISBAND_ARMY;
            }
            if (param1 == toString(FIND_TREASURE_SHORT))
            {
                return FIND_TREASURE_SHORT;
            }
            if (param1 == toString(FIND_TREASURE_MEDIUM))
            {
                return FIND_TREASURE_MEDIUM;
            }
            if (param1 == toString(FIND_TREASURE_LONG))
            {
                return FIND_TREASURE_LONG;
            }
            if (param1 == toString(FIND_TREASURE_EVEN_LONGER))
            {
                return FIND_TREASURE_EVEN_LONGER;
            }
            if (param1 == toString(FIND_ADVENTURE_ZONE_SHORT))
            {
                return FIND_ADVENTURE_ZONE_SHORT;
            }
            if (param1 == toString(FIND_ADVENTURE_ZONE_MEDIUM))
            {
                return FIND_ADVENTURE_ZONE_MEDIUM;
            }
            if (param1 == toString(FIND_ADVENTURE_ZONE_LONG))
            {
                return FIND_ADVENTURE_ZONE_LONG;
            }
            if (param1 == toString(TRAVEL_TO_ZONE))
            {
                return TRAVEL_TO_ZONE;
            }
            if (param1 == toString(FIND_WILD_ZONE))
            {
                return FIND_WILD_ZONE;
            }
            if (param1 == toString(WAIT_FOR_CONFIRMATION))
            {
                return WAIT_FOR_CONFIRMATION;
            }
            gMisc.Assert(false, "Could not interpret \'" + param1 + "\' for a task string!");
            return -1;
        }// end function

    }
}
