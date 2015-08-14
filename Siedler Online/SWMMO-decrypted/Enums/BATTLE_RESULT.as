package Enums
{

    public class BATTLE_RESULT extends Object
    {
        public static const GENERAL_WON_AND_CONTINUES:int = 1;
        public static const GENERAL_LOST:int = 2;
        public static const GENERAL_WON_AND_RETURNS:int = 0;

        public function BATTLE_RESULT()
        {
            return;
        }// end function

        public static function toString(param1:int) : String
        {
            switch(param1)
            {
                case GENERAL_WON_AND_RETURNS:
                {
                    return AVATAR_MESSAGE_TYPE.GENERAL_WON_AND_RETURNS;
                }
                case GENERAL_WON_AND_CONTINUES:
                {
                    return AVATAR_MESSAGE_TYPE.GENERAL_WON_AND_CONTINUES;
                }
                case GENERAL_LOST:
                {
                    return AVATAR_MESSAGE_TYPE.GENERAL_LOST;
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
