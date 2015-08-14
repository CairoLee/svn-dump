package Specialists
{
    import Communication.VO.*;
    import Enums.*;
    import GO.*;
    import Interface.*;
    import PathFinding.*;
    import ServerState.*;
    import nLib.*;

    public class cSpecialistTask_Move extends cSpecialistTask_WithSettler
    {
        private var mNewGarrisonGridIdx:int;
        private var mCurrentGarrisonGridIdx:int;

        public function cSpecialistTask_Move(param1:cGeneralInterface, param2:cSpecialist, param3:int, param4:int, param5:int)
        {
            super(param1, SPECIALIST_TASK_TYPES.MOVE, param2, param4, param5);
            this.mNewGarrisonGridIdx = param3;
            return;
        }// end function

        override protected function PerformTaskPhase(param1:int) : void
        {
            switch(GetTaskPhase())
            {
                case TASK_PHASES_MOVE.STRIKE_GARRISON:
                {
                    if (mOwner.GetGarrison() == null || mOwner.GetGarrison().GetBuildingMode() == cBuilding.BUILDING_MODE_DESTRUCTED)
                    {
                        mCollectedTime = 0;
                        SetPathPos(0);
                        SpawnSettler(0, 0);
                        mOwner.SetGarrison(null);
                        NextPhase();
                    }
                    break;
                }
                case TASK_PHASES_MOVE.MOVE:
                {
                    IncPathPos(int(param1 * SPECIALIST_WALK_SPEED));
                    if (GetPathPos() >= GetDestinationPath().pathLenX10000)
                    {
                        mCollectedTime = 0;
                        RemoveSettler();
                        NextPhase();
                        this.GetNewGarrison().SetBuildingMode(cBuilding.BUILDING_MODE_CONSTRUCTION);
                        gMisc.ConsoleOut("Reached target position. Going to next phase. collectedTime=" + mCollectedTime);
                    }
                    break;
                }
                case TASK_PHASES_MOVE.BUILD_GARRISON:
                {
                    if (this.GetNewGarrison().GetBuildingMode() == cBuilding.BUILDING_MODE_PRODUCES_NO_RESOURCES)
                    {
                        mOwner.SetGarrison(this.GetNewGarrison());
                        NextPhase();
                    }
                    break;
                }
                case TASK_PHASES_MOVE.WAIT_FOR_ORDERS:
                {
                    mOwner.SetTask(null);
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

        override public function StartTask() : void
        {
            var _loc_5:int = 0;
            super.StartTask();
            globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.GENERAL_STARTET_TRANSFER, mOwner);
            var _loc_1:* = mGeneralInterface.FindPlayerFromId(mOwner.GetPlayerID());
            var _loc_2:* = mGeneralInterface.mCurrentPlayerZone.SetAtGridPosition(_loc_1, OBJECTTYPE.BUILDING, "Garrison", this.mNewGarrisonGridIdx) as cBuilding;
            _loc_2.SetBuildingMode(cBuilding.BUILDING_MODE_SET_BUILDING_GROUND_PLACE);
            _loc_2.GetResourceCreation().SetSettlerKIStateDeactivate();
            _loc_2.mDirtyIndicator = _loc_2.mDirtyIndicator | DIRTY_INDICATOR.CREATED_BIT;
            if (_loc_2.GetResourceCreation() != null)
            {
                _loc_2.GetResourceCreation().mDirtyIndicator = _loc_2.GetResourceCreation().mDirtyIndicator | DIRTY_INDICATOR.CREATED_BIT;
            }
            var _loc_3:* = _loc_2.GetStreetGridEntry();
            var _loc_4:* = mOwner.GetGarrison();
            if (mOwner.GetGarrison() == null)
            {
                SetDestinationPath(mGeneralInterface.mPathFinder.CalculatePathForWarehouse(_loc_3, mOwner.GetPlayerID()));
                if (GetDestinationPath() != null && GetDestinationPath().dest_vector.length > 0)
                {
                    _loc_5 = (GetDestinationPath().dest_vector[0] as dPathObjectItem).streetGridIdx;
                    _loc_5 = gCalculations.MoveStreetGridToDir8(_loc_5, defines.DIR8_NORTH_WEST);
                    _loc_4 = mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_5].mBuilding;
                    this.mCurrentGarrisonGridIdx = _loc_4.GetStreetGridEntry();
                    SpawnSettler(_loc_4.GetXInt(), _loc_4.GetYInt());
                    SetTaskPhase(TASK_PHASES_MOVE.MOVE);
                }
                else
                {
                    SetTaskPhase(TASK_PHASES_MOVE.BUILD_GARRISON);
                    this.GetNewGarrison().SetBuildingMode(cBuilding.BUILDING_MODE_CONSTRUCTION);
                }
            }
            else
            {
                this.mCurrentGarrisonGridIdx = _loc_4.GetBuildingGrid();
                SetDestinationPath(mGeneralInterface.mPathFinder.CalculatePath(_loc_4.GetStreetGridEntry(), _loc_3, mOwner.GetPlayerID(), false));
                mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.DeconstructBuildingGridPos(this.mCurrentGarrisonGridIdx);
                SetTaskPhase(TASK_PHASES_MOVE.STRIKE_GARRISON);
            }
            return;
        }// end function

        public function GetCurrentGarrisonGridIdx() : int
        {
            return this.mCurrentGarrisonGridIdx;
        }// end function

        public function GetNewGarrisonGridIdx() : int
        {
            return this.mNewGarrisonGridIdx;
        }// end function

        override public function CreateTaskVOFromSpecialistTask() : dSpecialistTaskVO
        {
            var _loc_1:* = new dSpecialistTask_MoveVO();
            _loc_1.type = GetType();
            _loc_1.phase = GetTaskPhase();
            _loc_1.collectedTime = GetCollectedTime();
            _loc_1.currentGarrisonGridIdx = this.mCurrentGarrisonGridIdx;
            _loc_1.newGarrisonGridIdx = this.mNewGarrisonGridIdx;
            _loc_1.pathPos = GetPathPos();
            return _loc_1;
        }// end function

        public function GetNewGarrison() : cBuilding
        {
            return mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[this.mNewGarrisonGridIdx].mBuilding;
        }// end function

        override protected function CheckSettler() : void
        {
            switch(GetTaskPhase())
            {
                case TASK_PHASES_MOVE.STRIKE_GARRISON:
                case TASK_PHASES_MOVE.BUILD_GARRISON:
                case TASK_PHASES_MOVE.WAIT_FOR_ORDERS:
                {
                    if (GetSettler() != null)
                    {
                        RemoveSettler();
                    }
                    break;
                }
                case TASK_PHASES_MOVE.MOVE:
                {
                    if (GetSettler() == null)
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

        public static function CreateTaskFromVO(param1:cGeneralInterface, param2:dSpecialistTask_MoveVO, param3:cSpecialist) : cSpecialistTask_Move
        {
            var _loc_4:* = new cSpecialistTask_Move(param1, param3, param2.newGarrisonGridIdx, param2.collectedTime, param2.phase);
            new cSpecialistTask_Move(param1, param3, param2.newGarrisonGridIdx, param2.collectedTime, param2.phase).SetPathPos(param2.pathPos);
            _loc_4.mCurrentGarrisonGridIdx = param2.currentGarrisonGridIdx;
            _loc_4.mNewGarrisonGridIdx = param2.newGarrisonGridIdx;
            var _loc_5:* = _loc_4.GetNewGarrison();
            if (_loc_4.GetNewGarrison() == null)
            {
                gMisc.Assert(false, "P" + param3.GetPlayerID() + ": Error while creating task from VO: new garrison does not exists. newGarrisonGridIdx: " + _loc_4.mNewGarrisonGridIdx);
            }
            _loc_4.SetDestinationPath(param1.mPathFinder.CalculatePath(_loc_4.mCurrentGarrisonGridIdx, _loc_5.GetStreetGridEntry(), param3.GetPlayerID(), false));
            return _loc_4;
        }// end function

    }
}
