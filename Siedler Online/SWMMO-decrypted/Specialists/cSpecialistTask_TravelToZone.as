package Specialists
{
    import Communication.VO.*;
    import Enums.*;
    import GO.*;
    import Interface.*;
    import ServerState.*;
    import __AS3__.vec.*;
    import nLib.*;

    public class cSpecialistTask_TravelToZone extends cSpecialistTask_WithSettler
    {
        private var mGarrisonGridIdx:int;
        private var mDestinationZoneID:int;
        public static var TIME_TO_TRAVEL_TO_ZONE:int = 200000;
        public static var PLAYER_LEVEL:int = 0;

        public function cSpecialistTask_TravelToZone(param1:cGeneralInterface, param2:cSpecialist, param3:int, param4:int, param5:int)
        {
            super(param1, SPECIALIST_TASK_TYPES.TRAVEL_TO_ZONE, param2, param4, param5);
            this.mDestinationZoneID = param3;
            this.mGarrisonGridIdx = param2.GetGarrisonGridIdx();
            return;
        }// end function

        public function BeginTravel() : void
        {
            var _loc_1:Boolean = true;
            if (!_loc_1)
            {
                mOwner.GetArmy().DisbandArmy(mGeneralInterface.mCurrentPlayerZone.GetArmy(mOwner.GetPlayerID()));
                mOwner.SetTask(null);
                return;
            }
            var _loc_2:* = mGeneralInterface.mCurrentPlayerZone.GetSpecialists_vector().indexOf(mOwner);
            if (_loc_2 == -1)
            {
                return;
            }
            mGeneralInterface.mCurrentPlayerZone.GetSpecialists_vector().splice(_loc_2, 1);
            mOwner.SetTask(null);
            (mGeneralInterface as cGameInterface).forceDatabaseUpdate("SpecialistStartsTravel");
            return;
        }// end function

        override protected function CheckSettler() : void
        {
            gMisc.ConsoleOut("cSpecialistTask_TravelToZone.CheckSettler()");
            switch(GetTaskPhase())
            {
                case TASK_PHASES_TRAVEL_TO_ZONE.STRIKE_GARRISON:
                case TASK_PHASES_TRAVEL_TO_ZONE.TRAVEL_TO_ZONE:
                case TASK_PHASES_TRAVEL_TO_ZONE.BUILD_GARRISON:
                case TASK_PHASES_TRAVEL_TO_ZONE.WAIT_FOR_ORDERS:
                {
                    if (GetSettler() != null)
                    {
                        RemoveSettler();
                    }
                    break;
                }
                case TASK_PHASES_TRAVEL_TO_ZONE.MOVE_TO_WAREHOUSE:
                {
                    if (GetSettler() == null && GetDestinationPath() != null && GetDestinationPath().dest_vector.length > 0)
                    {
                        SpawnSettler(0, 0);
                    }
                    break;
                }
                default:
                {
                    gMisc.ConsoleOut("Could not interpret task phase " + GetTaskPhase());
                    break;
                    break;
                }
            }
            return;
        }// end function

        public function toString() : String
        {
            return "<cSpecialistTask_TravelToZone destinationZoneID=\'" + this.mDestinationZoneID + "\' garrisonGridIdx=\'" + this.mGarrisonGridIdx + "\' />";
        }// end function

        override public function StartTask() : void
        {
            super.StartTask();
            globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.GENERAL_TRAVELS_TO_ZONE, mOwner);
            var _loc_1:* = mOwner.GetGarrison();
            if (_loc_1 == null)
            {
                this.BeginTravel();
                SetTaskPhase(TASK_PHASES_TRAVEL_TO_ZONE.TRAVEL_TO_ZONE);
            }
            else
            {
                SetDestinationPath(mGeneralInterface.mPathFinder.CalculatePathForWarehouse(_loc_1.GetStreetGridEntry(), mOwner.GetPlayerID()));
                mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.DeconstructBuildingGridPos(_loc_1.GetBuildingGrid());
                SetTaskPhase(TASK_PHASES_TRAVEL_TO_ZONE.STRIKE_GARRISON);
            }
            return;
        }// end function

        override protected function PerformTaskPhase(param1:int) : void
        {
            var _loc_2:Vector.<cLandingField> = null;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:cPlayerData = null;
            var _loc_8:cBuilding = null;
            switch(GetTaskPhase())
            {
                case TASK_PHASES_TRAVEL_TO_ZONE.STRIKE_GARRISON:
                {
                    if (mOwner.GetGarrison() == null || mOwner.GetGarrison().GetBuildingMode() == cBuilding.BUILDING_MODE_DESTRUCTED)
                    {
                        mCollectedTime = 0;
                        mOwner.SetGarrison(null);
                        if (GetDestinationPath() != null && GetDestinationPath().dest_vector.length > 0)
                        {
                            SetPathPos(GetDestinationPath().pathLenX10000);
                            SpawnSettler(0, 0);
                            NextPhase();
                        }
                        else
                        {
                            SetTaskPhase(TASK_PHASES_TRAVEL_TO_ZONE.TRAVEL_TO_ZONE);
                            this.BeginTravel();
                        }
                    }
                    break;
                }
                case TASK_PHASES_TRAVEL_TO_ZONE.MOVE_TO_WAREHOUSE:
                {
                    IncPathPos(int(param1 * SPECIALIST_WALK_SPEED));
                    if (GetPathPos() >= GetDestinationPath().pathLenX20000)
                    {
                        mCollectedTime = 0;
                        RemoveSettler();
                        this.BeginTravel();
                    }
                    break;
                }
                case TASK_PHASES_TRAVEL_TO_ZONE.TRAVEL_TO_ZONE:
                {
                    if (mCollectedTime >= TIME_TO_TRAVEL_TO_ZONE)
                    {
                        _loc_2 = new Vector.<cLandingField>;
                        _loc_2 = _loc_2.concat(mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mLandingFields_vector);
                        _loc_3 = -1;
                        _loc_4 = -1;
                        if (mOwner.GetBaseType() == SPECIALIST_TYPE.GENERAL)
                        {
                            while (_loc_2.length > 0)
                            {
                                
                                _loc_3 = 0;
                                _loc_4 = _loc_2[_loc_3].mGrid;
                                if (mGeneralInterface.mCurrentPlayerZone.GetBuildingFromGridPosition(_loc_4) != null)
                                {
                                    _loc_2.splice(_loc_3, 1);
                                    _loc_4 = -1;
                                    continue;
                                }
                                _loc_5 = gCalculations.MoveStreetGridToDir8(_loc_4, defines.DIR8_SOUTH_EAST);
                                if (mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.GetBlockType(_loc_5) == cBlockingData.BLOCK_TYPE_ALLOW_NOTHING)
                                {
                                    _loc_2.splice(_loc_3, 1);
                                    _loc_4 = -1;
                                    continue;
                                }
                                break;
                            }
                        }
                        if (_loc_4 == -1)
                        {
                            mOwner.SetGarrison(null);
                            mOwner.GetArmy().DisbandArmy(mGeneralInterface.mCurrentPlayerZone.GetArmy(mOwner.GetPlayerID()));
                            SetTaskPhase(TASK_PHASES_TRAVEL_TO_ZONE.WAIT_FOR_ORDERS);
                            if (mOwner.GetType() == SPECIALIST_TYPE.TMP_ARMY_TRANSPORTER)
                            {
                                _loc_6 = mGeneralInterface.mCurrentPlayerZone.GetSpecialists_vector().indexOf(mOwner);
                                if (_loc_6 != -1)
                                {
                                    mGeneralInterface.mCurrentPlayerZone.GetSpecialists_vector().splice(_loc_6, 1);
                                }
                            }
                        }
                        else
                        {
                            _loc_7 = mGeneralInterface.FindPlayerFromId(mOwner.GetPlayerID());
                            if (_loc_7 == null)
                            {
                                _loc_7 = new cPlayerData(mGeneralInterface);
                                mGeneralInterface.mServer.CreatePlayerFromPlayerVO(_loc_7, dPlayerVO.CreateVisitorPlayer(mGeneralInterface, mOwner.GetPlayerID()));
                                mGeneralInterface.GetPlayerList_vector().push(_loc_7);
                            }
                            _loc_8 = mGeneralInterface.mCurrentPlayerZone.SetAtGridPosition(_loc_7, OBJECTTYPE.BUILDING, defines.GARRISON_NAME_string, _loc_4) as cBuilding;
                            _loc_8.SetBuildingMode(cBuilding.BUILDING_MODE_CONSTRUCTION);
                            _loc_8.GetResourceCreation().SetSettlerKIStateDeactivate();
                            _loc_8.mDirtyIndicator = _loc_8.mDirtyIndicator | DIRTY_INDICATOR.CREATED_BIT;
                            _loc_8.GetResourceCreation().mDirtyIndicator = _loc_8.GetResourceCreation().mDirtyIndicator | DIRTY_INDICATOR.CREATED_BIT;
                            mOwner.SetGarrison(_loc_8);
                            NextPhase();
                        }
                    }
                    break;
                }
                case TASK_PHASES_TRAVEL_TO_ZONE.BUILD_GARRISON:
                {
                    if (mOwner.GetGarrison().GetBuildingMode() == cBuilding.BUILDING_MODE_PRODUCES_NO_RESOURCES)
                    {
                        NextPhase();
                    }
                    break;
                }
                case TASK_PHASES_TRAVEL_TO_ZONE.WAIT_FOR_ORDERS:
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

        override public function GetNeededTime() : int
        {
            return TIME_TO_TRAVEL_TO_ZONE;
        }// end function

        override public function CreateTaskVOFromSpecialistTask() : dSpecialistTaskVO
        {
            var _loc_1:* = new dSpecialistTask_TravelToZoneVO();
            _loc_1.type = GetType();
            _loc_1.phase = GetTaskPhase();
            _loc_1.collectedTime = GetCollectedTime();
            _loc_1.destinationZoneID = this.mDestinationZoneID;
            _loc_1.pathPos = GetPathPos();
            return _loc_1;
        }// end function

        public function GetGarrisonGridIdx() : int
        {
            return this.mGarrisonGridIdx;
        }// end function

        public function GetDestinationZoneID() : int
        {
            return this.mDestinationZoneID;
        }// end function

        public static function CreateTaskFromVO(param1:cGeneralInterface, param2:dSpecialistTask_TravelToZoneVO, param3:cSpecialist) : cSpecialistTask_TravelToZone
        {
            var _loc_4:* = new cSpecialistTask_TravelToZone(param1, param3, param2.destinationZoneID, param2.collectedTime, param2.phase);
            new cSpecialistTask_TravelToZone(param1, param3, param2.destinationZoneID, param2.collectedTime, param2.phase).SetPathPos(param2.pathPos);
            _loc_4.mGarrisonGridIdx = param2.garrisonGridIdx;
            if (_loc_4.GetGarrisonGridIdx() > -1)
            {
                _loc_4.SetDestinationPath(param1.mPathFinder.CalculatePathForWarehouse(_loc_4.GetGarrisonGridIdx(), param3.GetPlayerID()));
            }
            return _loc_4;
        }// end function

    }
}
