package Enums
{

    final public class GUILD_LOG_IDENTIFIER extends Object
    {
        public static const BANNER_CHANGE:int = 7;
        public static const MAX_SIZE_INCREASE:int = 6;
        public static const MEMBER_RANK_DEGRADE:int = 5;
        public static const MEMBER_INVITE:int = 0;
        public static const MEMBER_JOIN:int = 2;
        public static const RANK_NAME_CHANGE:int = 9;
        public static const MEMBER_RANK_PROMOTE:int = 4;
        public static const DESCRIPTION_CHANGE:int = 8;
        public static const MEMBER_LEAVE:int = 3;
        public static const MEMBER_KICK:int = 1;
        public static const MOTD_CHANGE:int = 10;

        public function GUILD_LOG_IDENTIFIER()
        {
            return;
        }// end function

        public static function toString(param1:int) : String
        {
            switch(param1)
            {
                case MEMBER_INVITE:
                {
                    return "MemberInvite";
                }
                case MEMBER_KICK:
                {
                    return "MemberKick";
                }
                case MEMBER_JOIN:
                {
                    return "MemberJoin";
                }
                case MEMBER_LEAVE:
                {
                    return "MemberLeave";
                }
                case MEMBER_RANK_PROMOTE:
                {
                    return "MemberRankPromote";
                }
                case MEMBER_RANK_DEGRADE:
                {
                    return "MemberRankDegrade";
                }
                case MAX_SIZE_INCREASE:
                {
                    return "MaxSizeIncrease";
                }
                case BANNER_CHANGE:
                {
                    return "BannerChange";
                }
                case DESCRIPTION_CHANGE:
                {
                    return "DescriptionChange";
                }
                case RANK_NAME_CHANGE:
                {
                    return "RankNameChange";
                }
                case MOTD_CHANGE:
                {
                    return "MOTDChange";
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
