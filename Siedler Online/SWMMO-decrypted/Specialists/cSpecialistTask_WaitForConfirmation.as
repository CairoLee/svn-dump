package Specialists
{
    import Communication.VO.*;
    import Enums.*;
    import Interface.*;
    import nLib.*;

    public class cSpecialistTask_WaitForConfirmation extends cSpecialistTask
    {
        public static var MAX_TIME_TO_WAIT:int = 120000;

        public function cSpecialistTask_WaitForConfirmation(param1:cGeneralInterface, param2:cSpecialist, param3:int)
        {
            super(param1, SPECIALIST_TASK_TYPES.WAIT_FOR_CONFIRMATION, param2, param3, TASK_PHASES_WAIT_FOR_CONFIRMATION.WAIT_FOR_CONFIRMATION);
            return;
        }// end function

        override public function CreateTaskVOFromSpecialistTask() : dSpecialistTaskVO
        {
            var _loc_1:* = new dSpecialistTask_WaitForConfirmationVO();
            _loc_1.type = GetType();
            _loc_1.phase = GetTaskPhase();
            _loc_1.collectedTime = GetCollectedTime();
            return _loc_1;
        }// end function

        override protected function PerformTaskPhase(param1:int) : void
        {
            switch(GetTaskPhase())
            {
                case TASK_PHASES_WAIT_FOR_CONFIRMATION.WAIT_FOR_CONFIRMATION:
                {
                    if (GetCollectedTime() >= MAX_TIME_TO_WAIT)
                    {
                        NextPhase();
                    }
                    break;
                }
                case TASK_PHASES_EXPLORE_SECTOR.WAIT_FOR_ORDERS:
                {
                    mOwner.SetTask(null);
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

    }
}
