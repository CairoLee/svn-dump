package Enums
{

    public class DEPOSIT_ACCESSIBLE_TYPES extends Object
    {
        public static const NOT_ACCESSIBLE:int = 0;
        public static const ACCESSIBLE:int = 2;
        public static const RESERVED:int = 1;

        public function DEPOSIT_ACCESSIBLE_TYPES()
        {
            return;
        }// end function

        public static function toString(param1:int) : String
        {
            switch(param1)
            {
                case NOT_ACCESSIBLE:
                {
                    return "Not Accessible";
                }
                case RESERVED:
                {
                    return "Reserved";
                }
                case ACCESSIBLE:
                {
                    return "Accessible";
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
