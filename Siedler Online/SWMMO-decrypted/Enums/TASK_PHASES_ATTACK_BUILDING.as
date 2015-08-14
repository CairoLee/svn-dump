package Enums
{

    public class TASK_PHASES_ATTACK_BUILDING extends Object
    {
        public static const WAIT_AT_TARGET:int = 1;
        public static const WAIT_FOR_ORDERS:int = 4;
        public static const ATTACK_TARGET:int = 2;
        public static const GO_TO_TARGET:int = 0;
        public static const RETURN_TO_GARRISON:int = 3;

        public function TASK_PHASES_ATTACK_BUILDING()
        {
            return;
        }// end function

        public static function toString(param1:int) : String
        {
            switch(param1)
            {
                case GO_TO_TARGET:
                {
                    return "GoToTarget";
                }
                case WAIT_AT_TARGET:
                {
                    return "WaitAtTarget";
                }
                case ATTACK_TARGET:
                {
                    return "AttackTarget";
                }
                case RETURN_TO_GARRISON:
                {
                    return "ReturnToGarrison";
                }
                case WAIT_FOR_ORDERS:
                {
                    return "WaitForOrders";
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
