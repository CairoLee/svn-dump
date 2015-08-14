package Enums
{

    public class LOG_TYPE extends Object
    {
        public static const ALL:int = 2.14748e+009;
        public static const QUEST:int = 1 << 10;
        public static const PERIODICAL:int = 1 << 4;
        public static const MILITARY:int = 1 << 9;
        public static const PERFORMANCE:int = 1 << 5;
        public static const TOTAL_COUNT:int = 14;
        public static const INVALID:int = -1;
        public static const SYNC:int = 1 << 2;
        public static const ECONOMY:int = 1 << 8;
        public static const PATHFINDING:int = 1 << 6;
        public static const GUI:int = 1 << 11;
        public static const COMMON:int = 1 << 1;
        public static const EXCEPTION:int = 1 << 0;
        public static const SPECIALIST:int = 1 << 13;
        public static const SHOP:int = 1 << 7;
        public static const NONE:int = 0;
        public static const EVENT:int = 1 << 3;
        public static const BUILDING:int = 1 << 12;

        public function LOG_TYPE()
        {
            return;
        }// end function

        public static function toString(param1:int) : String
        {
            switch(param1)
            {
                case NONE:
                {
                    return "NONE";
                }
                case EXCEPTION:
                {
                    return "EXCEPTION";
                }
                case COMMON:
                {
                    return "COMMON";
                }
                case SYNC:
                {
                    return "SYNC";
                }
                case PERIODICAL:
                {
                    return "PERIODICAL";
                }
                case EVENT:
                {
                    return "EVENT";
                }
                case PERFORMANCE:
                {
                    return "PERFORMANCE";
                }
                case PATHFINDING:
                {
                    return "PATHFINDING";
                }
                case SHOP:
                {
                    return "SHOP";
                }
                case ECONOMY:
                {
                    return "ECONOMY";
                }
                case MILITARY:
                {
                    return "MILITARY";
                }
                case QUEST:
                {
                    return "QUEST";
                }
                case GUI:
                {
                    return "GUI";
                }
                case BUILDING:
                {
                    return "BUILDING";
                }
                case SPECIALIST:
                {
                    return "SPECIALIST";
                }
                case ALL:
                {
                    return "ALL";
                }
                default:
                {
                    break;
                }
            }
            return "LOG_TYPE.UNDEFINED(" + param1 + ")";
        }// end function

    }
}
