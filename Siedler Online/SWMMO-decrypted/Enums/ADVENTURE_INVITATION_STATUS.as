package Enums
{

    public class ADVENTURE_INVITATION_STATUS extends Object
    {
        public static const PENDING:int = 0;
        public static const ACCEPTED:int = 1;
        public static const DECLINED:int = 2;

        public function ADVENTURE_INVITATION_STATUS()
        {
            return;
        }// end function

        public static function toString(param1:int) : String
        {
            switch(param1)
            {
                case PENDING:
                {
                    return "Pending";
                }
                case ACCEPTED:
                {
                    return "Accepted";
                }
                case DECLINED:
                {
                    return "Declined";
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
