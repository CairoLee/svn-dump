package Specialists
{
    import Communication.VO.*;
    import Enums.*;
    import Interface.*;
    import MilitarySystem.*;
    import nLib.*;

    public class cSpecialistTask_Recover extends cSpecialistTask
    {
        public static var TIME_TO_RECOVER:int = 20000;

        public function cSpecialistTask_Recover(param1:cGeneralInterface, param2:cSpecialist, param3:int, param4:int)
        {
            super(param1, SPECIALIST_TASK_TYPES.RECOVER, param2, param3, param4);
            return;
        }// end function

        override public function GetNeededTime() : int
        {
            return TIME_TO_RECOVER;
        }// end function

        override public function CreateTaskVOFromSpecialistTask() : dSpecialistTaskVO
        {
            var _loc_1:* = new dSpecialistTask_RecoverVO();
            _loc_1.type = GetType();
            _loc_1.phase = GetTaskPhase();
            _loc_1.collectedTime = GetCollectedTime();
            return _loc_1;
        }// end function

        override protected function PerformTaskPhase(param1:int) : void
        {
            switch(GetTaskPhase())
            {
                case TASK_PHASES_RECOVER.RECOVER:
                {
                    if (GetCollectedTime() >= TIME_TO_RECOVER)
                    {
                        NextPhase();
                    }
                    break;
                }
                case TASK_PHASES_RECOVER.WAIT_FOR_ORDERS:
                {
                    mOwner.SetTask(null);
                    mOwner.SetCurrentHitPoints(cMilitaryUnitDescription.GetHitPointsForUnit(mOwner.GetSpecialistDescription().GetMilitaryUnitType_string()));
                    globalFlash.gui.mSpecialistPanel.Refresh(mOwner);
                    break;
                }
                default:
                {
                    gMisc.Assert(false, "Could not interpret task phase " + GetTaskPhase() + "!");
                    break;
                }
            }
            return;
        }// end function

        public static function CreateTaskFromVO(param1:cGeneralInterface, param2:dSpecialistTask_RecoverVO, param3:cSpecialist) : cSpecialistTask_Recover
        {
            var _loc_4:* = new cSpecialistTask_Recover(param1, param3, param2.collectedTime + param2.bonusTime, param2.phase);
            new cSpecialistTask_Recover(param1, param3, param2.collectedTime + param2.bonusTime, param2.phase).mBonusTime = param2.bonusTime;
            return _loc_4;
        }// end function

    }
}
