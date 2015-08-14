package Enums
{

    public class SPECIALIST_TASK_ATTACK_BUILDING_MODE extends Object
    {
        public static const CLEAR_SECTOR:int = 1;
        public static const BUILDING_ONLY:int = 0;

        public function SPECIALIST_TASK_ATTACK_BUILDING_MODE()
        {
            return;
        }// end function

        public static function toString(param1:int) : String
        {
            switch(param1)
            {
                case BUILDING_ONLY:
                {
                    return "BuildingOnly";
                }
                case CLEAR_SECTOR:
                {
                    return "ClearSector";
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
