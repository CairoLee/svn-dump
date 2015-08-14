package Specialists
{
    import Communication.VO.*;
    import Enums.*;
    import Interface.*;
    import __AS3__.vec.*;
    import nLib.*;

    public class cSpecialistTask extends Object
    {
        protected var mOwner:cSpecialist;
        private var mType:int;
        protected var mCollectedTime:int = 0;
        protected var mGeneralInterface:cGeneralInterface;
        private var mTaskPhase:int = 0;
        protected var mBonusTime:int = 0;
        private var mTaskProgress:Number = 0;
        public var mDirtyIndicator:int;
        private static const NULL:String = "NULL";
        private static const map_TaskType_SuccessLootTableGroupId_vector:Vector.<int> = new Vector.<int>;
        private static const map_TaskType_SpeedUpFactor_vector:Vector.<int> = new Vector.<int>;
        private static const map_TaskType_FailureLootTableGroupId_vector:Vector.<int> = new Vector.<int>;
        private static const QUOTE:String = "\'";
        private static const map_TaskType_SpeedUpCosts_vector:Vector.<int> = new Vector.<int>;
        private static const COMMA:String = ",";
        public static const SHOW_SPECIALIST_INFO:Boolean = false;
        public static const SPECIALIST_WALK_SPEED:int = 3;

        public function cSpecialistTask(param1:cGeneralInterface, param2:int, param3:cSpecialist, param4:int, param5:int)
        {
            this.mGeneralInterface = param1;
            this.mType = param2;
            this.mOwner = param3;
            this.mCollectedTime = param4;
            this.mTaskPhase = param5;
            return;
        }// end function

        public function CreateTaskVOFromSpecialistTask() : dSpecialistTaskVO
        {
            gMisc.Assert(false, "Must not call CreateTaskVOFromSpecialistTask() directly!");
            return null;
        }// end function

        public function Perform() : void
        {
            this.mCollectedTime = this.mCollectedTime + this.mGeneralInterface.mClientDeltaTime * this.mOwner.GetSpecialistDescription().GetTimeBonus() / 100;
            this.mTaskProgress = this.mCollectedTime / this.GetNeededTime();
            this.PerformTaskPhase(this.mGeneralInterface.mClientDeltaTime);
            return;
        }// end function

        public function PrepareTask() : void
        {
            return;
        }// end function

        public function GetType() : int
        {
            return this.mType;
        }// end function

        public function SetCollectedTime(param1:int) : void
        {
            this.mCollectedTime = param1;
            return;
        }// end function

        public function GetRemainingTime() : int
        {
            return int((this.GetNeededTime() - this.GetCollectedTime()) / global.initGlobalTimeScale / this.mOwner.GetSpecialistDescription().GetTimeBonus() * 100);
        }// end function

        public function GetOwner() : cSpecialist
        {
            return this.mOwner;
        }// end function

        public function GetCollectedTime() : int
        {
            return this.mCollectedTime;
        }// end function

        protected function SetTaskPhase(param1:int) : void
        {
            this.mTaskPhase = param1;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function StartTask() : void
        {
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.CREATED_BIT;
            return;
        }// end function

        protected function NextPhase() : void
        {
            var _loc_1:String = this;
            var _loc_2:* = this.mTaskPhase + 1;
            _loc_1.mTaskPhase = _loc_2;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function IncBonusTime(param1:int) : void
        {
            this.mBonusTime = this.mBonusTime + param1;
            return;
        }// end function

        public function GetTaskPhase() : int
        {
            return this.mTaskPhase;
        }// end function

        protected function PerformTaskPhase(param1:int) : void
        {
            return;
        }// end function

        public function GetBonusTime() : int
        {
            return this.mBonusTime;
        }// end function

        public function GetTaskProgress() : Number
        {
            return this.mTaskProgress;
        }// end function

        public function GetNeededTime() : int
        {
            return 1;
        }// end function

        public function GetTaskPerformTime() : int
        {
            return 0;
        }// end function

        public static function GetSpeedUpCosts(param1:int) : int
        {
            return map_TaskType_SpeedUpCosts_vector[param1];
        }// end function

        public static function AddLootTableGroupData(param1:int, param2:int, param3:int) : void
        {
            while (map_TaskType_SuccessLootTableGroupId_vector.length <= param1)
            {
                
                map_TaskType_SuccessLootTableGroupId_vector.push(0);
            }
            map_TaskType_SuccessLootTableGroupId_vector[param1] = param2;
            while (map_TaskType_FailureLootTableGroupId_vector.length <= param1)
            {
                
                map_TaskType_FailureLootTableGroupId_vector.push(0);
            }
            map_TaskType_FailureLootTableGroupId_vector[param1] = param3;
            return;
        }// end function

        public static function AddSpeedUpData(param1:int, param2:int, param3:int) : void
        {
            while (map_TaskType_SpeedUpCosts_vector.length <= param1)
            {
                
                map_TaskType_SpeedUpCosts_vector.push(0);
            }
            map_TaskType_SpeedUpCosts_vector[param1] = param2;
            while (map_TaskType_SpeedUpFactor_vector.length <= param1)
            {
                
                map_TaskType_SpeedUpFactor_vector.push(0);
            }
            map_TaskType_SpeedUpFactor_vector[param1] = param3;
            return;
        }// end function

        public static function CreateTaskFromVO(param1:cGeneralInterface, param2:dSpecialistTaskVO, param3:cSpecialist) : cSpecialistTask
        {
            var _loc_5:dSpecialistTask_AttackBuildingVO = null;
            var _loc_6:dSpecialistTask_MoveVO = null;
            var _loc_7:dSpecialistTask_ExploreSectorVO = null;
            var _loc_8:dSpecialistTask_FindDepositVO = null;
            var _loc_9:dSpecialistTask_FindEventZoneVO = null;
            var _loc_10:dSpecialistTask_FindTreasureVO = null;
            var _loc_11:dSpecialistTask_TravelToZoneVO = null;
            var _loc_12:dSpecialistTask_RecoverVO = null;
            var _loc_4:cSpecialistTask = null;
            if (param2 != null)
            {
                switch(param2.type)
                {
                    case SPECIALIST_TASK_TYPES.ATTACK_BUILDING:
                    {
                        _loc_5 = param2 as dSpecialistTask_AttackBuildingVO;
                        _loc_4 = cSpecialistTask_AttackBuilding.CreateTaskFromVO(param1, _loc_5, param3);
                        break;
                    }
                    case SPECIALIST_TASK_TYPES.MOVE:
                    {
                        _loc_6 = param2 as dSpecialistTask_MoveVO;
                        _loc_4 = cSpecialistTask_Move.CreateTaskFromVO(param1, _loc_6, param3);
                        break;
                    }
                    case SPECIALIST_TASK_TYPES.EXPLORE_SECTOR:
                    {
                        _loc_7 = param2 as dSpecialistTask_ExploreSectorVO;
                        _loc_4 = cSpecialistTask_ExploreSector.CreateTaskFromVO(param1, _loc_7, param3);
                        break;
                    }
                    case SPECIALIST_TASK_TYPES.DEPOSIT_SEARCH:
                    {
                        _loc_8 = param2 as dSpecialistTask_FindDepositVO;
                        _loc_4 = cSpecialistTask_FindDeposit.CreateTaskFromVO(param1, _loc_8, param3);
                        break;
                    }
                    case SPECIALIST_TASK_TYPES.FIND_ADVENTURE_ZONE_SHORT:
                    case SPECIALIST_TASK_TYPES.FIND_ADVENTURE_ZONE_MEDIUM:
                    case SPECIALIST_TASK_TYPES.FIND_ADVENTURE_ZONE_LONG:
                    {
                        _loc_9 = param2 as dSpecialistTask_FindEventZoneVO;
                        _loc_4 = cSpecialistTask_FindEventZone.CreateTaskFromVO(param1, _loc_9, param3);
                        break;
                    }
                    case SPECIALIST_TASK_TYPES.FIND_TREASURE_SHORT:
                    case SPECIALIST_TASK_TYPES.FIND_TREASURE_MEDIUM:
                    case SPECIALIST_TASK_TYPES.FIND_TREASURE_LONG:
                    case SPECIALIST_TASK_TYPES.FIND_TREASURE_EVEN_LONGER:
                    {
                        _loc_10 = param2 as dSpecialistTask_FindTreasureVO;
                        _loc_4 = cSpecialistTask_FindTreasure.CreateTaskFromVO(param1, _loc_10, param3);
                        break;
                    }
                    case SPECIALIST_TASK_TYPES.TRAVEL_TO_ZONE:
                    {
                        _loc_11 = param2 as dSpecialistTask_TravelToZoneVO;
                        _loc_4 = cSpecialistTask_TravelToZone.CreateTaskFromVO(param1, _loc_11, param3);
                        break;
                    }
                    case SPECIALIST_TASK_TYPES.RECOVER:
                    {
                        _loc_12 = param2 as dSpecialistTask_RecoverVO;
                        _loc_4 = cSpecialistTask_Recover.CreateTaskFromVO(param1, _loc_12, param3);
                        break;
                    }
                    default:
                    {
                        gMisc.Assert(false, "Could not interpret task type " + param2);
                        break;
                        break;
                    }
                }
            }
            return _loc_4;
        }// end function

        public static function GetSpeedUpFactor(param1:int) : int
        {
            return map_TaskType_SpeedUpFactor_vector[param1];
        }// end function

        public static function GetFailureLootTableGroupId(param1:int) : int
        {
            return map_TaskType_FailureLootTableGroupId_vector[param1];
        }// end function

        public static function GetSuccessLootTableGroupId(param1:int) : int
        {
            return map_TaskType_SuccessLootTableGroupId_vector[param1];
        }// end function

    }
}
