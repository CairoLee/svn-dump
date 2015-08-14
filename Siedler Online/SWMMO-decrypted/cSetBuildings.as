package 
{
    import BuffSystem.*;
    import Communication.VO.*;
    import Enums.*;
    import GO.*;
    import GUI.Components.*;
    import Interface.*;
    import Map.*;
    import PathFinding.*;
    import ServerState.*;
    import Sound.*;
    import Specialists.*;
    import __AS3__.vec.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import nLib.*;

    public class cSetBuildings extends Object
    {
        private var mTempPos:cPosInt;
        private var mGeneralInterface:cGeneralInterface;
        private var mCursorGrid:int = 0;
        public var mMilitaryPathVisible:Boolean;
        private var mMilitaryPathCostMatrix_list:Vector.<int> = null;
        private var mMilitaryPathStartingPositionGridIdx:int;
        private var mPlayerData:cPlayerData = null;
        private var mMilitaryPathOldCursorGridIdx:int = -1;
        private var mPlayerZone:cPlayerZoneScreen = null;
        public var mMilitaryPathObject:cPathObject;

        public function cSetBuildings(param1:cGeneralInterface)
        {
            this.mMilitaryPathObject = new cPathObject();
            this.mTempPos = new cPosInt();
            this.mGeneralInterface = param1;
            return;
        }// end function

        public function MouseClickOnMap(param1:cPlayerData, param2:cPlayerZoneScreen) : Boolean
        {
            var _loc_3:cSpecialist = null;
            var _loc_4:cBuff = null;
            var _loc_6:dServerAction = null;
            var _loc_10:ResourceAlert = null;
            var _loc_11:Object = null;
            var _loc_5:cBuilding = null;
            var _loc_7:* = this.mGeneralInterface.mCurrentCursor.GetCursorXPixelPos();
            var _loc_8:* = this.mGeneralInterface.mCurrentCursor.GetCursorYPixelPos();
            var _loc_9:* = this.mGeneralInterface.mCurrentCursor.GetGridPosition();
            switch(this.mGeneralInterface.mCurrentCursor.GetEditMode())
            {
                case COMMAND.SELECT_BUILDING:
                {
                    if (!this.mGeneralInterface.mCurrentCursor.IsCursorValid())
                    {
                        return false;
                    }
                    _loc_5 = param2.GetBuildingFromGridPosition(_loc_9);
                    if (_loc_5 == null)
                    {
                        _loc_5 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.CheckIfBuildingIsSouthSouthEastAndSouthWest(_loc_9);
                    }
                    if (this.mGeneralInterface.mEnumUIType == UITYPE.EDITOR)
                    {
                        if (_loc_5 != null && _loc_5.IsBuildingSelectable())
                        {
                            this.mGeneralInterface.SelectBuilding(_loc_5);
                        }
                    }
                    else if (_loc_5 != null && _loc_5.IsBuildingSelectable() && !_loc_5.IsEngagedInCombat() && param1.mIsPlayerZone && _loc_5.GetBuildingName_string() != null && _loc_5.GetPlayerID() != 0)
                    {
                        this.mGeneralInterface.SelectBuilding(_loc_5);
                    }
                    return true;
                }
                case COMMAND.SET_BUILDING_IN_GAME:
                case COMMAND.SET_BUILDING_BY_BUFF:
                {
                    if (!this.mGeneralInterface.mCurrentCursor.IsCursorValid())
                    {
                        this.mGeneralInterface.mCurrentCursor.SetCursorEditMode(COMMAND.SELECT_BUILDING);
                        return false;
                    }
                    if (this.mGeneralInterface.mCurrentCursor.GetEditMode() != COMMAND.SET_BUILDING_BY_BUFF)
                    {
                        if (param1.IsMaximumPlacedBuildingCountReached(this.mGeneralInterface.mCurrentCursor.mLevelObject_string))
                        {
                            CustomAlert.show("MaxBuildingCountReached", "MaxBuildingCountReached");
                            this.mGeneralInterface.mCurrentCursor.SetCursorEditMode(COMMAND.SELECT_BUILDING);
                            return false;
                        }
                    }
                    if (this.mGeneralInterface.mCurrentCursor.GetEditMode() == COMMAND.SET_BUILDING_BY_BUFF || !param1.mBuildQueue.IsFull() && !param1.mBuildQueue.IsBlockedUntilBuildQueueIsProceed())
                    {
                        param1.mBuildQueue.SetBlockedUntilBuildQueueIsProceed();
                        this.mGeneralInterface.SendServerAction(this.mGeneralInterface.mCurrentCursor.GetEditMode(), global.buildingGroup.GetNrFromName(this.mGeneralInterface.mCurrentCursor.mLevelObject_string), _loc_9, 0, this.mGeneralInterface.mCurrentCursor.GetEditMode() == COMMAND.SET_BUILDING_BY_BUFF ? (this.mGeneralInterface.mCurrentCursor.mCurrentBuff.GetUniqueId()) : (null));
                        if (this.mGeneralInterface.mCurrentCursor.GetEditMode() == COMMAND.SET_BUILDING_BY_BUFF)
                        {
                            this.mGeneralInterface.mCurrentCursor.mCurrentBuff.IncWaitingForServerCount();
                        }
                        if (param2.mStreetDataMap.SetPrePlaceBuildingGridPos(param1, this.mGeneralInterface.mCurrentCursor.mLevelObject_string, _loc_9))
                        {
                            cSoundManager.GetInstance().PlayEffect("BuildingPlace");
                        }
                        else
                        {
                            gErrorMessages.ShowErrorMessage("Could not set building - illegal Position!");
                        }
                    }
                    this.mGeneralInterface.mCurrentCursor.SetCursorEditMode(COMMAND.SELECT_BUILDING);
                    return true;
                }
                case COMMAND.MOVE_BUILDING:
                {
                    if (this.mGeneralInterface.mCurrentCursor.IsCursorValid())
                    {
                        this.mPlayerData = param1;
                        this.mPlayerZone = param2;
                        this.mCursorGrid = _loc_9;
                        _loc_10 = ResourceAlert.show("ConfirmMoveBuilding", "ConfirmMoveBuilding", this.mGeneralInterface.mCurrentCursor.mCurrentBuilding.GetMovementCosts_vector(), Alert.CANCEL | Alert.OK, null, this.MoveBuilding);
                        _loc_10.addEventListener(CloseEvent.CLOSE, this.MoveBuilding);
                    }
                    return true;
                }
                case COMMAND.ATTACK_BUILDING:
                {
                    if (!this.mGeneralInterface.mCurrentCursor.IsCursorValid())
                    {
                        return false;
                    }
                    _loc_5 = param2.GetBuildingFromGridPosition(_loc_9);
                    if (_loc_5 != null && _loc_5.IsBuildingSelectable() && param1.mIsPlayerZone && _loc_5.GetBuildingName_string() != null)
                    {
                        _loc_3 = this.mGeneralInterface.mCurrentCursor.mCurrentSpecialist;
                        Application.application.mGeneralInterface.SendServerAction(COMMAND.SET_TASK, SPECIALIST_TASK_TYPES.ATTACK_BUILDING, _loc_5.GetBuildingGrid(), SPECIALIST_TASK_ATTACK_BUILDING_MODE.BUILDING_ONLY, _loc_3.GetUniqueID());
                        _loc_3.SetTask(new cSpecialistTask_WaitForConfirmation(this.mGeneralInterface, _loc_3, 0));
                        this.mGeneralInterface.mCurrentCursor.SetCursorEditMode(COMMAND.SELECT_BUILDING);
                        this.mGeneralInterface.mCurrentCursor.mCurrentSpecialist = null;
                        this.mMilitaryPathVisible = false;
                        cSoundManager.GetInstance().PlayEffect("GeneralAttack");
                    }
                    return true;
                }
                case COMMAND.MOVE_GARISSON:
                {
                    if (!this.mGeneralInterface.mCurrentCursor.IsCursorValid())
                    {
                        return false;
                    }
                    if (param1.mIsPlayerZone)
                    {
                        if (param2.mStreetDataMap.SetPrePlaceBuildingGridPos(param1, this.mGeneralInterface.mCurrentCursor.mLevelObject_string, _loc_9))
                        {
                            _loc_3 = this.mGeneralInterface.mCurrentCursor.mCurrentSpecialist;
                            Application.application.mGeneralInterface.SendServerAction(COMMAND.SET_TASK, SPECIALIST_TASK_TYPES.MOVE, this.mGeneralInterface.mCurrentCursor.GetGridPosition(), 0, _loc_3.GetUniqueID());
                            _loc_3.SetTask(new cSpecialistTask_WaitForConfirmation(this.mGeneralInterface, _loc_3, 0));
                        }
                        else
                        {
                            gErrorMessages.ShowErrorMessage("Could not set building - illegal Position!");
                        }
                        this.mGeneralInterface.mCurrentCursor.SetCursorEditMode(COMMAND.SELECT_BUILDING);
                        this.mGeneralInterface.mCurrentCursor.mCurrentSpecialist = null;
                        this.mMilitaryPathVisible = false;
                    }
                    return true;
                }
                case COMMAND.APPLY_BUFF:
                {
                    if (!this.mGeneralInterface.mCurrentCursor.IsCursorValid())
                    {
                        return false;
                    }
                    global.buffingBlockedUntil = gMisc.GetTimeSinceStartup() + defines.BUFF_BLOCKING_DURATION;
                    _loc_4 = this.mGeneralInterface.mCurrentCursor.mCurrentBuff;
                    _loc_11 = _loc_4.IsApplyable(param1, this.mGeneralInterface, _loc_9);
                    if (_loc_11 is cGO)
                    {
                        this.mGeneralInterface.SendServerAction(COMMAND.APPLY_BUFF, 0, _loc_9, 0, _loc_4.GetUniqueId());
                        _loc_4.IncWaitingForServerCount();
                    }
                    if (this.mGeneralInterface.mCurrentCursor.mCurrentBuff.GetCount() - this.mGeneralInterface.mCurrentCursor.mCurrentBuff.GetWaitingForServerCount() <= 0)
                    {
                        this.mGeneralInterface.mCurrentCursor.SetCursorEditMode(COMMAND.SELECT_BUILDING);
                        this.mGeneralInterface.mCurrentCursor.mCurrentBuff = null;
                    }
                    return true;
                }
                default:
                {
                    break;
                }
            }
            return false;
        }// end function

        public function SetDepositMode(param1:cGeneralInterface, param2:cPlayerZoneScreen, param3:cPlayerData, param4:String, param5:String, param6:String, param7:int, param8:int, param9:int) : cDeposit
        {
            var _loc_11:String = null;
            var _loc_12:cResources = null;
            var _loc_13:cXML = null;
            var _loc_14:Vector.<cXML> = null;
            var _loc_15:cXML = null;
            var _loc_16:String = null;
            var _loc_17:int = 0;
            var _loc_10:cDeposit = null;
            if (param1.GetDepositType() == param1.DEPOSIT_TYPE_SINGLE)
            {
                if (param4 != null)
                {
                    _loc_12 = param1.mCurrentPlayerZone.GetResources(param3);
                    if (!_loc_12.CanPlayerAffordBuilding(param4))
                    {
                        return null;
                    }
                    _loc_12.RemoveBuildingResourcesFromPlayerResources(param4);
                }
                _loc_10 = param2.SetAtGridPosition(param3, param7, param6, param9) as cDeposit;
                _loc_11 = _loc_10.GetGOSetListName_string();
                if (param5 != null)
                {
                    _loc_13 = global.gfxSettingsRootXML.MoveToSubNode("GameObjects").MoveToSubNode("Deposits");
                    _loc_14 = _loc_13.CreateChildrenArray();
                    for each (_loc_15 in _loc_14)
                    {
                        
                        if (param5 == _loc_15.GetAttributeString_string("name"))
                        {
                            _loc_11 = _loc_15.GetAttributeString_string("gosetlist");
                            param1.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_10.GetGridIdx()].RefreshDepositGfx();
                        }
                    }
                }
                _loc_10.Init(gMisc.GetSubString_string(param6, 7, param6.length - 7), param9, param8, param8, -1, DEPOSIT_ACCESSIBLE_TYPES.ACCESSIBLE, 0, _loc_11);
            }
            else if (Application.application.DepositGroupDataGrid.selectedItem != null)
            {
                _loc_16 = Application.application.DepositGroupDataGrid.selectedItem.assignedDeposit;
                if (_loc_16 != null)
                {
                    _loc_17 = Application.application.DepositGroupDataGrid.selectedItem.averageAmount;
                    _loc_10 = param2.SetAtGridPosition(param3, param7, "Deposit" + _loc_16, param9) as cDeposit;
                    _loc_10.Init(_loc_16, param9, _loc_17, _loc_17, Application.application.DepositGroupDataGrid.selectedItem.groupId, DEPOSIT_ACCESSIBLE_TYPES.NOT_ACCESSIBLE, 0, null);
                }
                else
                {
                    gErrorMessages.ShowGameInfo("No Deposit assigned to Group!\nAssign a Deposit to Group " + Application.application.DepositGroupDataGrid.selectedItem.groupId);
                }
            }
            else
            {
                gErrorMessages.ShowGameInfo("No Group selected");
            }
            if (_loc_10 != null)
            {
                _loc_10.mDirtyIndicator = _loc_10.mDirtyIndicator | DIRTY_INDICATOR.CREATED_BIT;
            }
            return _loc_10;
        }// end function

        public function Init() : void
        {
            return;
        }// end function

        private function MoveBuilding(event:CloseEvent) : void
        {
            var _loc_6:dResource = null;
            var _loc_8:cBuffDefinition = null;
            var _loc_2:* = this.mGeneralInterface.mCurrentCursor.mCurrentBuilding;
            if (event.detail != Alert.OK || _loc_2 == null || _loc_2.GetMovementCosts_vector() == null || this.mPlayerData == null || this.mPlayerZone == null || this.mCursorGrid == 0)
            {
                this.ResetMovedBuilding();
                return;
            }
            var _loc_3:Number = 0;
            if (_loc_2.mBuildingUpgradeIsInProgress)
            {
                _loc_8 = _loc_2.GetUpgradeLevelBonusesForLevel((_loc_2.GetUpgradeLevel() + 1));
                if (_loc_8 != null)
                {
                    _loc_3 = _loc_8.GetProductionTime() - (this.mGeneralInterface.GetClientTime() - _loc_2.GetUpgradeStartTime());
                    if (_loc_3 < defines.MIN_UPGRADE_TIME_TO_MOVE_UPGRADING_BUILDING_FOR_GUI)
                    {
                        CustomAlert.show("MoveBuildingErrorUpgradeTooClose", "MoveBuildingError");
                        this.ResetMovedBuilding();
                        return;
                    }
                }
            }
            var _loc_4:* = this.mGeneralInterface.mCurrentCursor.mCurrentBuilding.GetMovementCosts_vector();
            var _loc_5:* = this.mGeneralInterface.mCurrentPlayerZone.GetResources(this.mPlayerData);
            for each (_loc_6 in _loc_4)
            {
                
                if (!_loc_5.HasPlayerResource(_loc_6.name_string, _loc_6.amount))
                {
                    ResourceAlert.show("MoveBuildingErrorMissingResources", "MoveBuildingError", _loc_4);
                    if (this.mGeneralInterface.mLog.isErrorEnabled(LOG_TYPE.BUILDING))
                    {
                        this.mGeneralInterface.mLog.logError(LOG_TYPE.BUILDING, "Player has not enough resources to move building!");
                    }
                    this.ResetMovedBuilding();
                    return;
                }
            }
            if (!this.mGeneralInterface.mCurrentCursor.IsCursorValid() || !this.mPlayerZone.mStreetDataMap.SetPrePlaceBuildingGridPosWithLevel(this.mPlayerData, this.mGeneralInterface.mCurrentCursor.mLevelObject_string, this.mCursorGrid, this.mGeneralInterface.mCurrentCursor.mCurrentBuilding.GetUpgradeLevel()))
            {
                gErrorMessages.ShowErrorMessage("Could not move building - illegal position!");
                this.ResetMovedBuilding();
                return;
            }
            if (this.mGeneralInterface.mLog.isDebugEnabled(LOG_TYPE.BUILDING))
            {
                this.mGeneralInterface.mLog.logDebug(LOG_TYPE.BUILDING, "mode:" + COMMAND.MOVE_BUILDING + ", type:" + global.buildingGroup.GetNrFromName(this.mGeneralInterface.mCurrentCursor.mLevelObject_string) + ", grid:" + this.mCursorGrid + ", data:" + this.mGeneralInterface.mCurrentCursor.mCurrentBuilding.GetBuildingGrid());
            }
            cSoundManager.GetInstance().PlayEffect("BuildingPlace");
            this.mGeneralInterface.mCurrentCursor.mCurrentBuilding.SetBuildingMode(cBuilding.BUILDING_MODE_MOVING);
            var _loc_7:* = this.mGeneralInterface.mCurrentCursor.mCurrentBuilding.GetResourceCreation();
            if (this.mGeneralInterface.mCurrentCursor.mCurrentBuilding.GetResourceCreation() != null)
            {
                _loc_7.SetKIStateMoving();
            }
            this.mGeneralInterface.SendServerAction(COMMAND.MOVE_BUILDING, global.buildingGroup.GetNrFromName(this.mGeneralInterface.mCurrentCursor.mLevelObject_string), this.mCursorGrid, 0, this.mGeneralInterface.mCurrentCursor.mCurrentBuilding.GetBuildingGrid());
            this.ResetMovedBuilding();
            return;
        }// end function

        public function MouseMove(param1:cPlayerZoneScreen) : Boolean
        {
            return this.MouseDownOnMap(param1);
        }// end function

        private function ResetMovedBuilding() : void
        {
            this.mGeneralInterface.mCurrentCursor.SetCursorEditMode(COMMAND.SELECT_BUILDING);
            this.mGeneralInterface.mCurrentCursor.mCurrentBuilding = null;
            this.mPlayerData = null;
            this.mPlayerZone = null;
            this.mCursorGrid = 0;
            return;
        }// end function

        public function InitShowMilitaryPathInRealTime(param1:int) : void
        {
            this.mMilitaryPathStartingPositionGridIdx = param1;
            var _loc_2:* = new Vector.<int>(1);
            _loc_2.push(this.mMilitaryPathStartingPositionGridIdx);
            this.mMilitaryPathCostMatrix_list = this.mGeneralInterface.mCreatePath.CalculatePathCostMatrix_list(_loc_2);
            this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.ResetStreetPreview();
            this.mMilitaryPathVisible = true;
            return;
        }// end function

        public function MouseDownOnMap(param1:cPlayerZoneScreen) : Boolean
        {
            return false;
        }// end function

        public function ShowMilitaryPathInRealTime(param1:cPlayerData) : void
        {
            var _loc_2:int = 0;
            if (this.mGeneralInterface.mCurrentCursor.GetEditMode() == COMMAND.ATTACK_BUILDING || this.mGeneralInterface.mCurrentCursor.GetEditMode() == COMMAND.MOVE_GARISSON)
            {
                if (this.mMilitaryPathVisible)
                {
                    _loc_2 = this.mGeneralInterface.mCurrentCursor.GetGridPosition();
                    if (this.mMilitaryPathOldCursorGridIdx != _loc_2)
                    {
                        this.mMilitaryPathOldCursorGridIdx = _loc_2;
                        this.mMilitaryPathObject.Reset();
                        this.mMilitaryPathObject = this.mGeneralInterface.mCreatePath.CalculateStreetPathFromMatrix(_loc_2, this.mMilitaryPathStartingPositionGridIdx, this.mMilitaryPathCostMatrix_list, false);
                        if (this.mGeneralInterface.mCurrentCursor.GetEditMode() == COMMAND.ATTACK_BUILDING)
                        {
                            if (this.mMilitaryPathObject.pathLenX10000 == 0)
                            {
                                this.mGeneralInterface.mCurrentCursor.SetCursorGfx(OBJECTTYPE.STREET, "Street_AttackCursor_Disabled");
                            }
                            else
                            {
                                this.mGeneralInterface.mCurrentCursor.SetCursorGfx(OBJECTTYPE.STREET, "Street_AttackCursor");
                            }
                        }
                        if (this.mGeneralInterface.mCurrentCursor.GetEditMode() == COMMAND.MOVE_GARISSON)
                        {
                            if (this.mMilitaryPathObject.pathLenX10000 == 0)
                            {
                                this.mGeneralInterface.mCurrentCursor.SetCursorGfx(OBJECTTYPE.BUILDING, "GarrisonTransferCursor_Disabled");
                            }
                            else
                            {
                                this.mGeneralInterface.mCurrentCursor.SetCursorGfx(OBJECTTYPE.BUILDING, "GarrisonTransferCursor");
                            }
                        }
                    }
                    this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.CreateMilitaryPreviewFromPathStreet(param1, this.mMilitaryPathObject);
                    this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.ShowMilitaryPathPreview();
                }
            }
            return;
        }// end function

    }
}
