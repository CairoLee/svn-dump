package Enums
{

    public class BUFF_APPLIANCE_MODE extends Object
    {
        public static const PLAYER:int = 0;
        public static const GUILD_MEMBER:int = 2;
        public static const FRIEND:int = 1;

        public function BUFF_APPLIANCE_MODE()
        {
            return;
        }// end function

        public static function parseString(param1:String) : int
        {
            if (toString(PLAYER) == param1)
            {
                return PLAYER;
            }
            if (toString(FRIEND) == param1)
            {
                return FRIEND;
            }
            if (toString(GUILD_MEMBER) == param1)
            {
                return GUILD_MEMBER;
            }
            return PLAYER;
        }// end function

        public static function toString(param1:int) : String
        {
            switch(param1)
            {
                case PLAYER:
                {
                    return "Player";
                }
                case FRIEND:
                {
                    return "Friend";
                }
                case GUILD_MEMBER:
                {
                    return "GuildMember";
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
