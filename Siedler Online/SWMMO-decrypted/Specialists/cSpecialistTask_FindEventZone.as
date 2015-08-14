package Specialists
{
    import Communication.VO.*;
    import Communication.VO.UpdateVO.*;
    import Enums.*;
    import Interface.*;
    import __AS3__.vec.*;
    import nLib.*;

    public class cSpecialistTask_FindEventZone extends cSpecialistTask
    {
        private var mNeededPlayerLevel:int;
        private var mSearchDuration:int;
        private var mTimeToCalculateEventZone:int = 0;
        private var mFindEventZoneResponseVO:dFindEventZoneResponseVO;
        public static var PERFORM_TASK_COSTS_LONG_vector:Vector.<dResource> = null;
        public static var PLAYER_LEVEL_SHORT:int = 0;
        public static var PLAYER_LEVEL_LONG:int = 0;
        public static var TIME_TO_FIND_ADVENTURE_ZONE_MEDIUM:int = 140000;
        public static var PERFORM_TASK_COSTS_MEDIUM_vector:Vector.<dResource> = null;
        public static var TIME_TO_FIND_ADVENTURE_ZONE_SHORT:int = 70000;
        public static var PLAYER_LEVEL_MEDIUM:int = 0;
        public static var TIME_TO_FIND_ADVENTURE_ZONE_LONG:int = 280000;
        public static var FIND_ADVENTURE_ZONE_CALCULATION_HEADSTART:int = 60000;
        public static var PERFORM_TASK_COSTS_SHORT_vector:Vector.<dResource> = null;

        public function cSpecialistTask_FindEventZone(param1:cGeneralInterface, param2:cSpecialist, param3:int, param4:int, param5:int)
        {
            this.mSearchDuration = TIME_TO_FIND_ADVENTURE_ZONE_LONG;
            this.mNeededPlayerLevel = PLAYER_LEVEL_LONG;
            super(param1, param5, param2, param3, param4);
            switch(param5)
            {
                case SPECIALIST_TASK_TYPES.FIND_ADVENTURE_ZONE_SHORT:
                {
                    this.mSearchDuration = TIME_TO_FIND_ADVENTURE_ZONE_SHORT;
                    break;
                }
                case SPECIALIST_TASK_TYPES.FIND_ADVENTURE_ZONE_MEDIUM:
                {
                    this.mSearchDuration = TIME_TO_FIND_ADVENTURE_ZONE_MEDIUM;
                    break;
                }
                case SPECIALIST_TASK_TYPES.FIND_ADVENTURE_ZONE_LONG:
                {
                    this.mSearchDuration = TIME_TO_FIND_ADVENTURE_ZONE_LONG;
                    break;
                }
                default:
                {
                    gMisc.Assert(false, "Could not interpret search type " + param5);
                    break;
                }
            }
            this.mTimeToCalculateEventZone = Math.max(this.mSearchDuration - FIND_ADVENTURE_ZONE_CALCULATION_HEADSTART, 0);
            return;
        }// end function

        override public function CreateTaskVOFromSpecialistTask() : dSpecialistTaskVO
        {
            var _loc_1:* = new dSpecialistTask_FindEventZoneVO();
            _loc_1.type = GetType();
            _loc_1.phase = GetTaskPhase();
            _loc_1.collectedTime = GetCollectedTime();
            _loc_1.findEventZoneResponseVO = this.mFindEventZoneResponseVO;
            return _loc_1;
        }// end function

        public function SetFindEventZoneResponseVO(param1:dFindEventZoneResponseVO) : void
        {
            this.mFindEventZoneResponseVO = param1;
            return;
        }// end function

        override public function StartTask() : void
        {
            super.StartTask();
            this.PerformTaskPhase(0);
            globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.EXPLORER_STARTED_FIND_EVENT_ZONE);
            return;
        }// end function

        public function GetFindEventZoneResponseVO() : dFindEventZoneResponseVO
        {
            return this.mFindEventZoneResponseVO;
        }// end function

        override public function GetNeededTime() : int
        {
            return this.mSearchDuration;
        }// end function

        override protected function PerformTaskPhase(param1:int) : void
        {
            switch(GetTaskPhase())
            {
                case TASK_PHASES_FIND_EVENT_ZONE.FIND_EVENT_ZONE:
                {
                    if (GetCollectedTime() >= this.mSearchDuration)
                    {
                        if (this.mFindEventZoneResponseVO != null)
                        {
                            if (this.mFindEventZoneResponseVO.adventureName_string != "None")
                            {
                                if (this.mFindEventZoneResponseVO.adventureName_string == "MapPart")
                                {
                                    globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.EXPLORER_FOUND_MAP_FRAGMENT);
                                }
                                else
                                {
                                    globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.EXPLORER_FOUND_EVENT_ZONE);
                                }
                            }
                            else
                            {
                                globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.EXPLORER_DID_NOT_FIND_EVENT_ZONE);
                            }
                            NextPhase();
                        }
                        else
                        {
                            globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.EXPLORER_DID_NOT_FIND_EVENT_ZONE);
                            NextPhase();
                        }
                    }
                    break;
                }
                case TASK_PHASES_FIND_EVENT_ZONE.WAIT_FOR_ORDERS:
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

        public function GetTimeToCalculateEventZone() : int
        {
            return this.mTimeToCalculateEventZone;
        }// end function

        public static function CreateTaskFromVO(param1:cGeneralInterface, param2:dSpecialistTask_FindEventZoneVO, param3:cSpecialist) : cSpecialistTask_FindEventZone
        {
            var _loc_4:* = new cSpecialistTask_FindEventZone(param1, param3, param2.collectedTime + param2.bonusTime, param2.phase, param2.type);
            new cSpecialistTask_FindEventZone(param1, param3, param2.collectedTime + param2.bonusTime, param2.phase, param2.type).mBonusTime = param2.bonusTime;
            _loc_4.mFindEventZoneResponseVO = param2.findEventZoneResponseVO;
            return _loc_4;
        }// end function

    }
}
