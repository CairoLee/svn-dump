package Specialists
{
    import Communication.VO.*;
    import Communication.VO.UpdateVO.*;
    import Enums.*;
    import Interface.*;
    import nLib.*;

    public class cSpecialistTask_FindTreasure extends cSpecialistTask
    {
        private var mTimeToCalculateTreasure:int = 0;
        private var mSearchDuration:int;
        private var mFindTreasureResponseVO:dFindTreasureResponseVO;
        public static var TIME_TO_FIND_TREASURE_SHORT:int = 70000;
        public static var PLAYER_LEVEL_SHORT:int = 0;
        public static var PLAYER_LEVEL_EVEN_LONGER:int = 0;
        public static var PLAYER_LEVEL_MEDIUM:int = 0;
        public static var TIME_TO_FIND_TREASURE_MEDIUM:int = 70000;
        public static var TIME_TO_FIND_TREASURE_EVEN_LONGER:int = 70000;
        public static var PLAYER_LEVEL_LONG:int = 0;
        public static var TIME_TO_FIND_TREASURE_LONG:int = 70000;
        public static var FIND_TREASURE_CALCULATION_HEADSTART:int = 60000;

        public function cSpecialistTask_FindTreasure(param1:cGeneralInterface, param2:cSpecialist, param3:int, param4:int, param5:int)
        {
            this.mSearchDuration = TIME_TO_FIND_TREASURE_EVEN_LONGER;
            super(param1, param5, param2, param3, param4);
            switch(param5)
            {
                case SPECIALIST_TASK_TYPES.FIND_TREASURE_SHORT:
                {
                    this.mSearchDuration = TIME_TO_FIND_TREASURE_SHORT;
                    break;
                }
                case SPECIALIST_TASK_TYPES.FIND_TREASURE_MEDIUM:
                {
                    this.mSearchDuration = TIME_TO_FIND_TREASURE_MEDIUM;
                    break;
                }
                case SPECIALIST_TASK_TYPES.FIND_TREASURE_LONG:
                {
                    this.mSearchDuration = TIME_TO_FIND_TREASURE_LONG;
                    break;
                }
                case SPECIALIST_TASK_TYPES.FIND_TREASURE_EVEN_LONGER:
                {
                    this.mSearchDuration = TIME_TO_FIND_TREASURE_EVEN_LONGER;
                    break;
                }
                default:
                {
                    gMisc.Assert(false, "Could not interpret search type " + param5);
                    break;
                }
            }
            this.mTimeToCalculateTreasure = Math.max(this.mSearchDuration - FIND_TREASURE_CALCULATION_HEADSTART, 0);
            return;
        }// end function

        public function SetFindTreasureResponseVO(param1:dFindTreasureResponseVO) : void
        {
            this.mFindTreasureResponseVO = param1;
            return;
        }// end function

        override public function StartTask() : void
        {
            super.StartTask();
            this.PerformTaskPhase(0);
            globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.EXPLORER_STARTED_FIND_TREASURE);
            return;
        }// end function

        override protected function PerformTaskPhase(param1:int) : void
        {
            switch(GetTaskPhase())
            {
                case TASK_PHASES_FIND_TREASURE.FIND_TREASURE:
                {
                    if (GetCollectedTime() >= this.mSearchDuration)
                    {
                        if (this.mFindTreasureResponseVO != null)
                        {
                            globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.EXPLORER_FOUND_TREASURE);
                            NextPhase();
                        }
                        else
                        {
                            globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.EXPLORER_DID_NOT_FIND_TREASURE);
                            NextPhase();
                        }
                    }
                    break;
                }
                case TASK_PHASES_FIND_TREASURE.WAIT_FOR_ORDERS:
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

        public function GetTimeToCalculateTreasure() : int
        {
            return this.mTimeToCalculateTreasure;
        }// end function

        public function GetFindTreasureResponseVO() : dFindTreasureResponseVO
        {
            return this.mFindTreasureResponseVO;
        }// end function

        override public function CreateTaskVOFromSpecialistTask() : dSpecialistTaskVO
        {
            var _loc_1:* = new dSpecialistTask_FindTreasureVO();
            _loc_1.type = GetType();
            _loc_1.phase = GetTaskPhase();
            _loc_1.collectedTime = GetCollectedTime();
            _loc_1.findTreasureResponseVO = this.mFindTreasureResponseVO;
            return _loc_1;
        }// end function

        override public function GetNeededTime() : int
        {
            return this.mSearchDuration;
        }// end function

        public static function CreateTaskFromVO(param1:cGeneralInterface, param2:dSpecialistTask_FindTreasureVO, param3:cSpecialist) : cSpecialistTask_FindTreasure
        {
            var _loc_4:* = new cSpecialistTask_FindTreasure(param1, param3, param2.collectedTime + param2.bonusTime, param2.phase, param2.type);
            new cSpecialistTask_FindTreasure(param1, param3, param2.collectedTime + param2.bonusTime, param2.phase, param2.type).mBonusTime = param2.bonusTime;
            _loc_4.mFindTreasureResponseVO = param2.findTreasureResponseVO;
            return _loc_4;
        }// end function

    }
}
