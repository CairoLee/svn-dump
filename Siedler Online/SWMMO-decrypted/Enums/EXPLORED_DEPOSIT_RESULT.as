package Enums
{

    public class EXPLORED_DEPOSIT_RESULT extends Object
    {
        public static const NO_DEPOSIT_IN_SECTORS:int = 2;
        public static const FOUND:int = 1;
        public static const PENDING:int = 0;
        public static const ALL_DEPOSITS_ACCESSIBLE:int = 3;

        public function EXPLORED_DEPOSIT_RESULT()
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
                case FOUND:
                {
                    return "Found";
                }
                case NO_DEPOSIT_IN_SECTORS:
                {
                    return "NoDepositInSectors";
                }
                case ALL_DEPOSITS_ACCESSIBLE:
                {
                    return "AllDepositsAccessible";
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
