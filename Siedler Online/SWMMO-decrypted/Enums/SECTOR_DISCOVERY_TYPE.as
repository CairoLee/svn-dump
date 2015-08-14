package Enums
{

    public class SECTOR_DISCOVERY_TYPE extends Object
    {
        public static const EXPLORED:int = 2;
        public static const RESERVED:int = 1;
        public static const UNEXPLORED:int = 0;

        public function SECTOR_DISCOVERY_TYPE()
        {
            return;
        }// end function

        public static function toString(param1:int) : String
        {
            switch(param1)
            {
                case UNEXPLORED:
                {
                    return "Unexplored";
                }
                case RESERVED:
                {
                    return "Reserved";
                }
                case EXPLORED:
                {
                    return "Explored";
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
