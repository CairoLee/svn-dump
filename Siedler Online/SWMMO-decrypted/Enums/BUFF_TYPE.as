package Enums
{
    import nLib.*;

    public class BUFF_TYPE extends Object
    {
        public static const INSTANT:int = 1;
        public static const ZONE:int = 3;
        public static const TIMED:int = 2;
        public static const UPGRADE:int = 0;

        public function BUFF_TYPE()
        {
            return;
        }// end function

        public static function Parse(param1:String) : int
        {
            if (param1 == toString(UPGRADE))
            {
                return UPGRADE;
            }
            if (param1 == toString(INSTANT))
            {
                return INSTANT;
            }
            if (param1 == toString(TIMED))
            {
                return TIMED;
            }
            if (param1 == toString(ZONE))
            {
                return ZONE;
            }
            gMisc.Assert(false, "Could not interpret buff string \'" + param1 + "\'!");
            return -1;
        }// end function

        public static function toString(param1:int) : String
        {
            switch(param1)
            {
                case UPGRADE:
                {
                    return "Upgrade";
                }
                case INSTANT:
                {
                    return "Instant";
                }
                case TIMED:
                {
                    return "Timed";
                }
                case ZONE:
                {
                    return "Zone";
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
