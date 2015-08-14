package Enums
{

    public class TIMED_PRODUCTION_TYPE extends Object
    {
        public static const BUFF:int = 1;
        public static const MILITARY_UNIT:int = 0;

        public function TIMED_PRODUCTION_TYPE()
        {
            return;
        }// end function

        public static function toString(param1:int) : String
        {
            switch(param1)
            {
                case MILITARY_UNIT:
                {
                    return "MilitaryUnit";
                }
                case BUFF:
                {
                    return "Buff";
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
