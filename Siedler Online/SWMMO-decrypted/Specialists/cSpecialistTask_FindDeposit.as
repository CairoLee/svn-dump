package Specialists
{
    import Communication.VO.*;
    import Enums.*;
    import GO.*;
    import Interface.*;
    import ServerState.*;
    import nLib.*;

    public class cSpecialistTask_FindDeposit extends cSpecialistTask
    {
        private var mExploredDeposit:cDeposit = null;
        private var mTimeToCalculateDeposit:int = 0;
        private var mNeededTimeToFindDeposit:int = 0;
        private var mDepositToSearch_string:String;
        private var mExploredDepositResult:int = 0;
        public static var FIND_DEPOSIT_CALCULATION_HEADSTART:int = 60000;
        private static const map_DepositString_SearchDuration:Object = new Object();
        private static const map_DepositString_PlayerLevel:Object = new Object();
        private static const map_DepositString_SpeedUpCosts:Object = new Object();
        private static const map_DepositString_SpeedUpFactor:Object = new Object();

        public function cSpecialistTask_FindDeposit(param1:cGeneralInterface, param2:cSpecialist, param3:String, param4:int, param5:int)
        {
            super(param1, SPECIALIST_TASK_TYPES.DEPOSIT_SEARCH, param2, param4, param5);
            this.mDepositToSearch_string = param3;
            this.mNeededTimeToFindDeposit = map_DepositString_SearchDuration[param3];
            this.mTimeToCalculateDeposit = Math.max(this.mNeededTimeToFindDeposit - FIND_DEPOSIT_CALCULATION_HEADSTART, 0);
            return;
        }// end function

        public function GetTimeToCalculateDeposit() : int
        {
            return this.mTimeToCalculateDeposit;
        }// end function

        public function GetDepositToSearch_string() : String
        {
            return this.mDepositToSearch_string;
        }// end function

        public function SetExploredDepositResult(param1:int, param2:cDeposit) : void
        {
            this.mExploredDepositResult = param1;
            this.mExploredDeposit = param2;
            mDirtyIndicator = mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        override public function CreateTaskVOFromSpecialistTask() : dSpecialistTaskVO
        {
            var _loc_1:* = new dSpecialistTask_FindDepositVO();
            _loc_1.type = GetType();
            _loc_1.phase = GetTaskPhase();
            _loc_1.collectedTime = GetCollectedTime();
            _loc_1.depositToSearch_string = this.GetDepositToSearch_string();
            _loc_1.exploredDepositVO = null;
            if (this.GetExploredDeposit() != null)
            {
                _loc_1.exploredDepositVO = this.GetExploredDeposit().CreateDepositVOFromDeposit();
            }
            _loc_1.exploredDepositResult = this.mExploredDepositResult;
            return _loc_1;
        }// end function

        public function toString() : String
        {
            return "<cSpecialistTask_FindDeposit depositToSearch=\'" + this.mDepositToSearch_string + "\', mExploredDeposit=" + this.mExploredDeposit + ", mNeededTimeToFindDeposit=" + this.mNeededTimeToFindDeposit + ", mTimeToCalculateDeposit=" + this.mTimeToCalculateDeposit + " >";
        }// end function

        override public function StartTask() : void
        {
            super.StartTask();
            if (mGeneralInterface.mLog.isInfoEnabled(LOG_TYPE.SPECIALIST))
            {
                mGeneralInterface.mLog.logInfo(LOG_TYPE.SPECIALIST, "Geologist " + mOwner.GetUniqueID() + " starts to search for " + this.mDepositToSearch_string);
            }
            globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.GEOLOGIST_STARTED);
            return;
        }// end function

        public function GetExploredDepositResult() : int
        {
            return this.mExploredDepositResult;
        }// end function

        override protected function PerformTaskPhase(param1:int) : void
        {
            var _loc_2:cPlayerData = null;
            switch(GetTaskPhase())
            {
                case TASK_PHASES_FIND_DEPOSIT.SEARCH_DEPOSIT:
                {
                    if (GetCollectedTime() >= this.mNeededTimeToFindDeposit)
                    {
                        if (mGeneralInterface.mLog.isInfoEnabled(LOG_TYPE.SPECIALIST))
                        {
                            mGeneralInterface.mLog.logInfo(LOG_TYPE.SPECIALIST, "Geologist " + mOwner.GetUniqueID() + " finished search for " + this.mDepositToSearch_string);
                        }
                        if (this.mExploredDeposit != null)
                        {
                            _loc_2 = mGeneralInterface.FindPlayerFromId(mOwner.GetPlayerID());
                            mGeneralInterface.mCurrentPlayerZone.AddLandscape(_loc_2, defines.DEPOSITFOUND_NAME_string + this.mExploredDeposit.GetContainerName_string(), this.mExploredDeposit.GetGridIdx());
                            mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.RemoveDepletedDepositBuildingIfOneIsThere(this.mExploredDeposit.GetGridIdx());
                            mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.SetDepositGridPos(_loc_2, this.mExploredDeposit, this.mExploredDeposit.GetGridIdx());
                            mGeneralInterface.mCurrentPlayerZone.AddDepositIcon(this.mExploredDeposit.GetContainerName_string(), this.mExploredDeposit.GetGridIdx());
                            mGeneralInterface.mCurrentPlayerZone.LevelBackgroundHasChanged();
                            this.mExploredDeposit.SetAccessibleType(DEPOSIT_ACCESSIBLE_TYPES.ACCESSIBLE);
                            globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.GEOLOGIST_FINISHED_POSITIVE, this.mExploredDeposit);
                        }
                        else
                        {
                            switch(this.mExploredDepositResult)
                            {
                                case EXPLORED_DEPOSIT_RESULT.ALL_DEPOSITS_ACCESSIBLE:
                                {
                                    globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.GEOLOGIST_FINISHED_NEGATIVE_ALL_ACCESSIBLE, this.GetDepositToSearch_string());
                                    break;
                                }
                                case EXPLORED_DEPOSIT_RESULT.NO_DEPOSIT_IN_SECTORS:
                                {
                                    globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.GEOLOGIST_FINISHED_NEGATIVE_NO_DEPOSIT, this.GetDepositToSearch_string());
                                    break;
                                }
                                default:
                                {
                                    globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.GEOLOGIST_FINISHED_NEGATIVE, this.GetDepositToSearch_string());
                                    gMisc.ConsoleOut("Could not interpret explored deposit result code " + this.mExploredDepositResult);
                                    break;
                                    break;
                                }
                            }
                        }
                        NextPhase();
                    }
                    break;
                }
                case TASK_PHASES_FIND_DEPOSIT.WAIT_FOR_ORDERS:
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

        public function GetExploredDeposit() : cDeposit
        {
            return this.mExploredDeposit;
        }// end function

        override public function GetNeededTime() : int
        {
            return this.mNeededTimeToFindDeposit;
        }// end function

        public static function CreateTaskFromVO(param1:cGeneralInterface, param2:dSpecialistTask_FindDepositVO, param3:cSpecialist) : cSpecialistTask_FindDeposit
        {
            var _loc_4:* = new cSpecialistTask_FindDeposit(param1, param3, param2.depositToSearch_string, param2.collectedTime + param2.bonusTime, param2.phase);
            new cSpecialistTask_FindDeposit(param1, param3, param2.depositToSearch_string, param2.collectedTime + param2.bonusTime, param2.phase).mBonusTime = param2.bonusTime;
            var _loc_5:cDeposit = null;
            if (param2.exploredDepositVO != null)
            {
                _loc_5 = param1.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[param2.exploredDepositVO.gridIdx].mDeposit;
                if (_loc_5 == null)
                {
                    _loc_5 = cDeposit.CreateDepositFromVO(param2.exploredDepositVO, param1);
                }
            }
            _loc_4.mExploredDepositResult = param2.exploredDepositResult;
            _loc_4.mExploredDeposit = _loc_5;
            return _loc_4;
        }// end function

        public static function GetSearchDurationForDeposit(param1:String) : int
        {
            return map_DepositString_SearchDuration[param1] as int;
        }// end function

        public static function GetPlayerLevelForDeposit(param1:String) : int
        {
            return map_DepositString_PlayerLevel[param1] as int;
        }// end function

        public static function AddFindDepositData(param1:String, param2:int, param3:int, param4:int, param5:int) : void
        {
            map_DepositString_SearchDuration[param1] = param2;
            map_DepositString_PlayerLevel[param1] = param3;
            map_DepositString_SpeedUpCosts[param1] = param4;
            map_DepositString_SpeedUpFactor[param1] = param5;
            return;
        }// end function

        public static function GetSpeedUpCostsForDeposit(param1:String) : int
        {
            return map_DepositString_SpeedUpCosts[param1] as int;
        }// end function

        public static function GetSpeedUpFactorForDeposit(param1:String) : int
        {
            return map_DepositString_SpeedUpFactor[param1] as int;
        }// end function

    }
}
