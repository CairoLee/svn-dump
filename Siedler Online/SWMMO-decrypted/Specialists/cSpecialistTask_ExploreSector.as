package Specialists
{
    import Communication.VO.*;
    import Communication.VO.UpdateVO.*;
    import Enums.*;
    import Interface.*;
    import Map.*;
    import ServerState.*;
    import nLib.*;

    public class cSpecialistTask_ExploreSector extends cSpecialistTask
    {
        private var mExploredSectorDataVO:dExploredSectorDataVO = null;
        private var mTimeToCalculateSector:int = 0;
        private var mExploredSectorId:int = -1;
        public static var TIME_TO_EXPLORE_SECTOR:int = 120000;
        public static var PLAYER_LEVEL:int = 0;
        public static var EXPLORE_SECTOR_CALCULATION_HEADSTART:int = 60000;

        public function cSpecialistTask_ExploreSector(param1:cGeneralInterface, param2:cSpecialist, param3:int, param4:int)
        {
            super(param1, SPECIALIST_TASK_TYPES.EXPLORE_SECTOR, param2, param3, param4);
            this.mTimeToCalculateSector = Math.max(TIME_TO_EXPLORE_SECTOR - EXPLORE_SECTOR_CALCULATION_HEADSTART, 0);
            return;
        }// end function

        override public function CreateTaskVOFromSpecialistTask() : dSpecialistTaskVO
        {
            var _loc_1:* = new dSpecialistTask_ExploreSectorVO();
            _loc_1.type = GetType();
            _loc_1.phase = GetTaskPhase();
            _loc_1.collectedTime = GetCollectedTime();
            _loc_1.exploredSectorId = this.mExploredSectorId;
            _loc_1.exploredSectorDataVO = this.mExploredSectorDataVO;
            return _loc_1;
        }// end function

        public function GetTimeToCalculateExploredSector() : int
        {
            return this.mTimeToCalculateSector;
        }// end function

        public function GetExploredSector() : cSector
        {
            if (this.mExploredSectorId == -1)
            {
                return null;
            }
            return mGeneralInterface.mCurrentPlayerZone.mSectorList_vector[this.mExploredSectorId];
        }// end function

        public function GetExploredSectorDataVO() : dExploredSectorDataVO
        {
            return this.mExploredSectorDataVO;
        }// end function

        override protected function PerformTaskPhase(param1:int) : void
        {
            var _loc_2:cPlayerData = null;
            var _loc_3:dBuildingVO = null;
            var _loc_4:dLandscapeVO = null;
            var _loc_5:dDepositVO = null;
            var _loc_6:dStreetVO = null;
            switch(GetTaskPhase())
            {
                case TASK_PHASES_EXPLORE_SECTOR.EXPLORE_SECTOR:
                {
                    if (GetCollectedTime() >= TIME_TO_EXPLORE_SECTOR)
                    {
                        if (this.mExploredSectorId != -1)
                        {
                            globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.EXPLORER_FINISHED_POSITIVE);
                            if (this.mExploredSectorDataVO != null)
                            {
                                for each (_loc_3 in this.mExploredSectorDataVO.buildings)
                                {
                                    
                                    mGeneralInterface.mServer.CreateBuildingFromBuildingVO(_loc_3.playerID, _loc_3);
                                }
                                for each (_loc_4 in this.mExploredSectorDataVO.landscapes)
                                {
                                    
                                    mGeneralInterface.mServer.CreateLandscapeFromLandscapeVO(_loc_4);
                                }
                                for each (_loc_5 in this.mExploredSectorDataVO.deposits)
                                {
                                    
                                    mGeneralInterface.mServer.CreateDepositFromDepositVO(_loc_5, false);
                                }
                                for each (_loc_6 in this.mExploredSectorDataVO.streets)
                                {
                                    
                                    mGeneralInterface.mServer.CreateStreetFromStreetVO(_loc_6);
                                }
                            }
                            _loc_2 = mGeneralInterface.FindPlayerFromId(mOwner.GetPlayerID());
                            _loc_2.SetSectorDiscovery(this.mExploredSectorId, SECTOR_DISCOVERY_TYPE.EXPLORED);
                            mGeneralInterface.mCurrentPlayerZone.SetFogForSector(this.mExploredSectorId);
                            mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.CalculateBorders();
                            mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.CalculateFogBorders(_loc_2);
                            mGeneralInterface.mCurrentPlayerZone.SetBackgroundHasChanged(true);
                        }
                        else
                        {
                            globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.EXPLORER_FINISHED_NEGATIVE);
                        }
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

        override public function StartTask() : void
        {
            super.StartTask();
            globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.EXPLORER_STARTED);
            return;
        }// end function

        override public function GetNeededTime() : int
        {
            return TIME_TO_EXPLORE_SECTOR;
        }// end function

        public function SetExploredSector(param1:cSector) : void
        {
            if (param1 == null)
            {
                this.mExploredSectorId = -1;
            }
            else
            {
                this.mExploredSectorId = param1.GetSectorID();
            }
            return;
        }// end function

        override public function GetTaskPerformTime() : int
        {
            return TIME_TO_EXPLORE_SECTOR;
        }// end function

        public static function CreateTaskFromVO(param1:cGeneralInterface, param2:dSpecialistTask_ExploreSectorVO, param3:cSpecialist) : cSpecialistTask_ExploreSector
        {
            gMisc.ConsoleOut("cSpecialistTask_ExploreSector.CreateTaskFromVO(" + param1 + ", " + param2 + ", " + param3 + ")");
            var _loc_4:* = new cSpecialistTask_ExploreSector(param1, param3, param2.collectedTime + param2.bonusTime, param2.phase);
            new cSpecialistTask_ExploreSector(param1, param3, param2.collectedTime + param2.bonusTime, param2.phase).mBonusTime = param2.bonusTime;
            _loc_4.mExploredSectorId = param2.exploredSectorId;
            return _loc_4;
        }// end function

    }
}
