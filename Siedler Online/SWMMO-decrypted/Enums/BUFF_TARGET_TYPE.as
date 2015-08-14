package Enums
{
    import nLib.*;

    public class BUFF_TARGET_TYPE extends Object
    {
        public static const BUILDING:int = 0;
        public static const HOMEZONE:int = 2;
        public static const DEPOSIT:int = 1;

        public function BUFF_TARGET_TYPE()
        {
            return;
        }// end function

        public static function toString(param1:int) : String
        {
            switch(param1)
            {
                case BUILDING:
                {
                    return "Building";
                }
                case DEPOSIT:
                {
                    return "Deposit";
                }
                case HOMEZONE:
                {
                    return "Homezone";
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
            if (param1 == toString(BUILDING))
            {
                return BUILDING;
            }
            if (param1 == toString(DEPOSIT))
            {
                return DEPOSIT;
            }
            if (param1 == toString(HOMEZONE))
            {
                return HOMEZONE;
            }
            gMisc.Assert(false, "Could not interpret string \'" + param1 + "\' for buff target type!");
            return BUILDING;
        }// end function

    }
}
