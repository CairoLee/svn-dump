package ServerState
{
    import Communication.VO.*;
    import Enums.*;
    import GO.*;
    import Interface.*;
    import __AS3__.vec.*;
    import nLib.*;

    public class cBuildQueueData extends Object
    {
        private var mUserNotified:Boolean = false;
        private var mMaxCount:int = 3;
        public var mDirtyIndicator:int;
        private var mGeneralInterface:cGeneralInterface;
        private var mBlocked:Boolean;
        private var mNoBuildMaterial:Boolean;
        private var mTempBuildSlots_vector:Vector.<cBuildSlot>;
        private var mQueue_vector:Vector.<cBuilding>;
        private var mWaitForBuildqueueMovedCommand:Boolean = false;
        private var mShowNoBuildMaterialMessageCntr:Number;
        private var mPlayerData:cPlayerData;

        public function cBuildQueueData(param1:cGeneralInterface, param2:cPlayerData)
        {
            this.mQueue_vector = new Vector.<cBuilding>;
            this.mTempBuildSlots_vector = new Vector.<cBuildSlot>;
            this.mGeneralInterface = param1;
            this.mPlayerData = param2;
            return;
        }// end function

        public function Add(param1:cBuilding) : Boolean
        {
            if (this.mQueue_vector.length < this.GetTotalAvailableSlots())
            {
                this.mQueue_vector.push(param1);
                this.ReadjustGridPositionsOfTempSlotsFrom((this.mQueue_vector.length - 1) - (this.GetMaxCount() + this.mPlayerData.GetPermanentBuildQueueSlotsCount()));
                this.UpdateGUI();
                this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
                return true;
            }
            return false;
        }// end function

        public function IsBuildingInBuildQueue(param1:int) : Boolean
        {
            var _loc_2:* = this.GetBuildingWithIndex(param1);
            if (_loc_2 < 0)
            {
                return false;
            }
            return true;
        }// end function

        public function GetQueue_vector()
        {
            return this.mQueue_vector;
        }// end function

        public function MoveDownGui(param1:int) : void
        {
            var _loc_2:* = this.GetBuildingWithIndex(param1);
            if (_loc_2 < 0)
            {
                return;
            }
            if (_loc_2 >= (this.mQueue_vector.length - 1))
            {
                return;
            }
            if (!this.mWaitForBuildqueueMovedCommand)
            {
                this.SetBuildqueueBusy(true);
                this.mGeneralInterface.SendServerAction(COMMAND.BUILDQUEUE_MOVE_DOWN, 0, param1, 0, null);
                this.UpdateGUI();
            }
            return;
        }// end function

        public function UpdateGUI() : void
        {
            globalFlash.gui.mBuildQueue.SetData(this.mQueue_vector);
            return;
        }// end function

        private function removeTempSlot(param1:dTempBuildSlotVO) : void
        {
            global.ui.mClientMessages.SendMessagetoServer(COMMAND.REMOVE_TEMP_BUILD_SLOT, this.mGeneralInterface.mHomePlayer.GetHomeZoneId(), param1);
            var _loc_2:int = 0;
            while (_loc_2 < this.mTempBuildSlots_vector.length)
            {
                
                if (this.mTempBuildSlots_vector[_loc_2].GetTimeOfPurchase() == param1.timeOfPurchase)
                {
                    this.mTempBuildSlots_vector.splice(_loc_2, 1);
                    break;
                }
                _loc_2++;
            }
            return;
        }// end function

        public function SetBlockedUntilBuildQueueIsProceedAndRemoveBuildqueueCommands() : void
        {
            var _loc_2:dGameTickCommandVO = null;
            var _loc_1:int = 0;
            while (_loc_1 < this.mGeneralInterface.mGameTickCommand_vector.length)
            {
                
                _loc_2 = this.mGeneralInterface.mGameTickCommand_vector[_loc_1];
                switch(_loc_2.mode)
                {
                    case COMMAND.BUILDQUEUE_MOVE_UP:
                    case COMMAND.BUILDQUEUE_MOVE_DOWN:
                    case COMMAND.BUILDQUEUE_REMOVE:
                    {
                        this.mGeneralInterface.mGameTickCommand_vector.splice(_loc_1, 1);
                        _loc_1 = _loc_1 - 1;
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
                _loc_1++;
            }
            this.SetBuildqueueBusy(false);
            this.mBlocked = true;
            return;
        }// end function

        public function Remove(param1:int) : void
        {
            var _loc_2:* = this.GetBuildingWithIndex(param1);
            if (_loc_2 < 0)
            {
                return;
            }
            this.SetBuildqueueBusy(false);
            this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.DeconstructBuildingGridPos(param1);
            this.mGeneralInterface.UnselectBuilding();
            this.RemoveBuildingFromQueue(param1);
            return;
        }// end function

        public function IsBuildingAtGridPositionInQueue(param1:int) : Boolean
        {
            var _loc_2:cBuilding = null;
            for each (_loc_2 in this.mQueue_vector)
            {
                
                if (_loc_2.GetBuildingGrid() == param1)
                {
                    return true;
                }
            }
            return false;
        }// end function

        private function updateTempSlotsTimer() : void
        {
            var _loc_1:* = this.GetMaxCount() + this.mPlayerData.GetPermanentBuildQueueSlotsCount();
            var _loc_2:int = 0;
            while (_loc_2 < this.mTempBuildSlots_vector.length)
            {
                
                if (!this.mTempBuildSlots_vector[_loc_2].updateTimeLeft(this.mGeneralInterface.GetClientTime()))
                {
                    if (this.mTempBuildSlots_vector[_loc_2].GetBuildingGridPosition() <= 0)
                    {
                        this.updateTempSlots();
                    }
                }
                _loc_2++;
            }
            return;
        }// end function

        public function MoveUpGui(param1:int) : void
        {
            var _loc_2:* = this.GetBuildingWithIndex(param1);
            if (_loc_2 < 1)
            {
                return;
            }
            if (!this.mWaitForBuildqueueMovedCommand)
            {
                this.SetBuildqueueBusy(true);
                this.mGeneralInterface.SendServerAction(COMMAND.BUILDQUEUE_MOVE_UP, 0, param1, 0, null);
                this.UpdateGUI();
            }
            return;
        }// end function

        public function Init(param1:dBuildQueueVO) : void
        {
            var _loc_2:dBuildingVO = null;
            var _loc_3:cBuilding = null;
            if (param1 == null)
            {
                this.mQueue_vector = new Vector.<cBuilding>;
            }
            else
            {
                this.mMaxCount = param1.maxCount;
                for each (_loc_2 in param1.buildings)
                {
                    
                    for each (_loc_3 in this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.GetBuildings_vector())
                    {
                        
                        if (_loc_3.GetBuildingGrid() == _loc_2.buildingGrid)
                        {
                            this.mQueue_vector.push(_loc_3);
                            break;
                        }
                    }
                }
                this.updateTempSlots();
            }
            this.mWaitForBuildqueueMovedCommand = false;
            this.mBlocked = false;
            if (globalFlash.gui.mBuildQueue != null)
            {
                this.UpdateGUI();
            }
            return;
        }// end function

        public function MoveDown(param1:int) : void
        {
            var _loc_2:* = this.GetBuildingWithIndex(param1);
            if (_loc_2 < 0)
            {
                return;
            }
            if (_loc_2 == 0)
            {
                if (this.GetCurrentBuildingProcess().GetBuildingMode() >= cBuilding.BUILDING_MODE_SET_BUILDING_GROUND_PLACE)
                {
                    return;
                }
            }
            if (_loc_2 >= (this.mQueue_vector.length - 1))
            {
                return;
            }
            this.SetBuildqueueBusy(false);
            var _loc_3:* = this.mQueue_vector[_loc_2];
            this.mQueue_vector[_loc_2] = this.mQueue_vector[(_loc_2 + 1)];
            this.mQueue_vector[(_loc_2 + 1)] = _loc_3;
            var _loc_4:* = this.GetMaxCount() + this.mPlayerData.GetPermanentBuildQueueSlotsCount();
            if (_loc_2 >= _loc_4)
            {
                this.mTempBuildSlots_vector[_loc_2 - _loc_4].SetBuildingGridPosition(this.mQueue_vector[_loc_2].GetBuildingGrid());
                this.mTempBuildSlots_vector[(_loc_2 + 1) - _loc_4].SetBuildingGridPosition(this.mQueue_vector[(_loc_2 + 1)].GetBuildingGrid());
                this.mPlayerData.UpdateGridPositionForAvailableTempSlotsWith(this.mTempBuildSlots_vector[_loc_2 - _loc_4].GetTimeOfPurchase(), this.mTempBuildSlots_vector[_loc_2 - _loc_4].GetBuildingGridPosition());
                this.mPlayerData.UpdateGridPositionForAvailableTempSlotsWith(this.mTempBuildSlots_vector[(_loc_2 + 1) - _loc_4].GetTimeOfPurchase(), this.mTempBuildSlots_vector[(_loc_2 + 1) - _loc_4].GetBuildingGridPosition());
            }
            else if (_loc_2 == (_loc_4 - 1))
            {
                this.mTempBuildSlots_vector[(_loc_2 + 1) - _loc_4].SetBuildingGridPosition(this.mQueue_vector[(_loc_2 + 1)].GetBuildingGrid());
                this.mPlayerData.UpdateGridPositionForAvailableTempSlotsWith(this.mTempBuildSlots_vector[(_loc_2 + 1) - _loc_4].GetTimeOfPurchase(), this.mTempBuildSlots_vector[(_loc_2 + 1) - _loc_4].GetBuildingGridPosition());
            }
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            this.UpdateGUI();
            return;
        }// end function

        public function AreMoveButtonsDisabled() : Boolean
        {
            return this.mWaitForBuildqueueMovedCommand || this.mBlocked;
        }// end function

        public function GetTotalAvailableSlots() : int
        {
            return this.mMaxCount + this.mPlayerData.GetPermanentBuildQueueSlotsCount() + this.mTempBuildSlots_vector.length;
        }// end function

        public function ComputeBuildQueue() : void
        {
            var _loc_1:cBuilding = null;
            var _loc_2:cResources = null;
            this.mBlocked = false;
            this.mNoBuildMaterial = false;
            if (this.mQueue_vector.length > 0)
            {
                _loc_1 = this.mQueue_vector[0];
                if (_loc_1.GetBuildingMode() == cBuilding.BUILDING_MODE_QUEUED)
                {
                    _loc_2 = this.mGeneralInterface.mCurrentPlayerZone.GetResourcesForPlayerID(_loc_1.GetPlayerID());
                    if (_loc_2 != null && _loc_2.CanPlayerAffordBuilding(_loc_1.GetBuildingName_string()))
                    {
                        if (!definesMaster.MASTER_VERSION && defines.PROTOKOLL_RESOURCE_CREATION)
                        {
                            gMisc.ConsoleOut("Player: " + this.mPlayerData.GetPlayerId() + "*** ComputeBuildQueue (" + _loc_1 + "): Build ClientTime: " + this.mGeneralInterface.GetClientTime());
                        }
                        this.mUserNotified = false;
                        _loc_1.mBuildingCreationTime = this.mGeneralInterface.GetClientTime();
                        _loc_1.mBuildingProgress = 0;
                        if (_loc_1.GetResourceCreation() != null)
                        {
                            if (!definesMaster.MASTER_VERSION && defines.PROTOKOLL_RESOURCE_CREATION)
                            {
                                gMisc.ConsoleOut("Player: " + this.mPlayerData.GetPlayerId() + "*** ComputeBuildQueue (" + _loc_1 + "): Build ClientTime Set Last Resourcecreation CreationTime: " + this.mGeneralInterface.GetClientTime());
                            }
                        }
                        else if (!definesMaster.MASTER_VERSION && defines.PROTOKOLL_RESOURCE_CREATION)
                        {
                            gMisc.ConsoleOut("Player: " + this.mPlayerData.GetPlayerId() + "*** ComputeBuildQueue (" + _loc_1 + "): Build ClientTime no ResourceCreation CreationTime: " + this.mGeneralInterface.GetClientTime());
                        }
                        _loc_1.Buy();
                        _loc_1.SetBuildingMode(cBuilding.BUILDING_MODE_SET_BUILDING_GROUND_PLACE);
                        this.UpdateGUI();
                    }
                    else
                    {
                        if (!definesMaster.MASTER_VERSION && defines.PROTOKOLL_RESOURCE_CREATION)
                        {
                            gMisc.ConsoleOut("Player: " + this.mPlayerData.GetPlayerId() + "*** ComputeBuildQueue (" + _loc_1 + ") cannot afford  ClientTime: " + this.mGeneralInterface.GetClientTime());
                        }
                        if (!this.mUserNotified)
                        {
                            this.UpdateGUI();
                            this.mUserNotified = true;
                        }
                        if (_loc_2 == null)
                        {
                            if (_loc_1.GetResourceCreation() != null)
                            {
                            }
                        }
                        if (_loc_1.GetResourceCreation() != null)
                        {
                            _loc_1.GetResourceCreation().SetProductionState(cResourceCreation.PRODUCTIONSTATE_ERROR_NECESSARY_RESOURCE_MISSING);
                        }
                        this.mNoBuildMaterial = true;
                    }
                }
                else if (!_loc_1.IsInConstructionMode())
                {
                    this.SetBlockedUntilBuildQueueIsProceedAndRemoveBuildqueueCommands();
                    if (!definesMaster.MASTER_VERSION && defines.PROTOKOLL_RESOURCE_CREATION)
                    {
                        gMisc.ConsoleOut("Player: " + this.mPlayerData.GetPlayerId() + "*** ComputeBuildQueue (" + _loc_1 + ") !constructionmode ClientTime: " + this.mGeneralInterface.GetClientTime());
                    }
                    this.mQueue_vector.shift();
                    this.ReadjustGridPositionsOfTempSlotsFrom(-1);
                    this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
                    this.UpdateGUI();
                }
                if (this.mTempBuildSlots_vector.length > 0)
                {
                    this.updateTempSlotsTimer();
                }
            }
            return;
        }// end function

        public function IsBlockedUntilBuildQueueIsProceed() : Boolean
        {
            return this.mBlocked;
        }// end function

        private function TempSlotPosInVector(param1:cBuildSlot) : int
        {
            if (param1 == null)
            {
                return -1;
            }
            var _loc_2:int = 0;
            while (_loc_2 < this.mTempBuildSlots_vector.length)
            {
                
                if (param1.GetTimeOfPurchase() == this.mTempBuildSlots_vector[_loc_2].GetTimeOfPurchase())
                {
                    return _loc_2;
                }
                _loc_2++;
            }
            return -1;
        }// end function

        private function GetTempSlotWithIndex(param1:int) : int
        {
            var _loc_3:cBuildSlot = null;
            var _loc_2:int = -1;
            for each (_loc_3 in this.mTempBuildSlots_vector)
            {
                
                _loc_2++;
                if (_loc_3.GetBuildingGridPosition() == param1)
                {
                    return _loc_2;
                }
            }
            return -1;
        }// end function

        public function SetBlockedUntilBuildQueueIsProceed() : void
        {
            this.mBlocked = true;
            return;
        }// end function

        public function GetCurrentBuildingProcess() : cBuilding
        {
            if (this.mQueue_vector.length > 0)
            {
                return this.mQueue_vector[0];
            }
            return null;
        }// end function

        private function GetBuildingWithIndex(param1:int) : int
        {
            var _loc_3:cBuilding = null;
            var _loc_2:int = -1;
            for each (_loc_3 in this.mQueue_vector)
            {
                
                _loc_2++;
                if (_loc_3.GetBuildingGrid() == param1)
                {
                    return _loc_2;
                }
            }
            return -1;
        }// end function

        public function ReadjustGridPositionsOfTempSlotsFrom(param1:int) : void
        {
            var _loc_5:Boolean = false;
            var _loc_2:* = this.GetMaxCount() + this.mPlayerData.GetPermanentBuildQueueSlotsCount();
            var _loc_3:Boolean = false;
            if (param1 < 0)
            {
                param1 = 0;
            }
            var _loc_4:* = param1;
            while (_loc_4 < this.mTempBuildSlots_vector.length)
            {
                
                if (_loc_2 + _loc_4 < this.mQueue_vector.length)
                {
                    _loc_5 = this.mTempBuildSlots_vector[_loc_4].updateTimeLeft(this.mGeneralInterface.GetClientTime());
                    if (_loc_5 || !_loc_5 && _loc_3)
                    {
                        this.mTempBuildSlots_vector[_loc_4].SetBuildingGridPosition(this.mQueue_vector[_loc_2 + _loc_4].GetBuildingGrid());
                    }
                    else
                    {
                        this.mTempBuildSlots_vector[_loc_4].SetBuildingGridPosition(0);
                        _loc_3 = true;
                    }
                }
                else if (_loc_3 && _loc_2 + _loc_4 - 1 < this.mQueue_vector.length)
                {
                    this.mTempBuildSlots_vector[_loc_4].SetBuildingGridPosition(this.mQueue_vector[_loc_2 + _loc_4 - 1].GetBuildingGrid());
                }
                else
                {
                    this.mTempBuildSlots_vector[_loc_4].SetBuildingGridPosition(0);
                }
                this.mPlayerData.UpdateGridPositionForAvailableTempSlotsWith(this.mTempBuildSlots_vector[_loc_4].GetTimeOfPurchase(), this.mTempBuildSlots_vector[_loc_4].GetBuildingGridPosition());
                _loc_4++;
            }
            return;
        }// end function

        public function GetTempSlots_vector()
        {
            return this.mTempBuildSlots_vector;
        }// end function

        private function SetBuildqueueBusy(param1:Boolean) : void
        {
            this.mWaitForBuildqueueMovedCommand = param1;
            return;
        }// end function

        public function GetMaxCount() : int
        {
            return this.mMaxCount;
        }// end function

        public function MoveUp(param1:int) : void
        {
            var _loc_2:* = this.GetBuildingWithIndex(param1);
            if (_loc_2 < 1)
            {
                return;
            }
            if (_loc_2 == 1)
            {
                if (this.GetCurrentBuildingProcess().GetBuildingMode() >= cBuilding.BUILDING_MODE_SET_BUILDING_GROUND_PLACE)
                {
                    return;
                }
            }
            this.SetBuildqueueBusy(false);
            var _loc_3:* = this.mQueue_vector[_loc_2];
            this.mQueue_vector[_loc_2] = this.mQueue_vector[(_loc_2 - 1)];
            this.mQueue_vector[(_loc_2 - 1)] = _loc_3;
            var _loc_4:* = this.GetMaxCount() + this.mPlayerData.GetPermanentBuildQueueSlotsCount();
            if (_loc_2 > _loc_4)
            {
                this.mTempBuildSlots_vector[_loc_2 - _loc_4].SetBuildingGridPosition(this.mQueue_vector[_loc_2].GetBuildingGrid());
                this.mTempBuildSlots_vector[(_loc_2 - 1) - _loc_4].SetBuildingGridPosition(this.mQueue_vector[(_loc_2 - 1)].GetBuildingGrid());
                this.mPlayerData.UpdateGridPositionForAvailableTempSlotsWith(this.mTempBuildSlots_vector[_loc_2 - _loc_4].GetTimeOfPurchase(), this.mTempBuildSlots_vector[_loc_2 - _loc_4].GetBuildingGridPosition());
                this.mPlayerData.UpdateGridPositionForAvailableTempSlotsWith(this.mTempBuildSlots_vector[(_loc_2 - 1) - _loc_4].GetTimeOfPurchase(), this.mTempBuildSlots_vector[(_loc_2 - 1) - _loc_4].GetBuildingGridPosition());
            }
            else if (_loc_2 == _loc_4 && this.mTempBuildSlots_vector.length > 0)
            {
                this.mTempBuildSlots_vector[_loc_2 - _loc_4].SetBuildingGridPosition(this.mQueue_vector[_loc_4].GetBuildingGrid());
                this.mPlayerData.UpdateGridPositionForAvailableTempSlotsWith(this.mTempBuildSlots_vector[_loc_2 - _loc_4].GetTimeOfPurchase(), this.mTempBuildSlots_vector[_loc_2 - _loc_4].GetBuildingGridPosition());
            }
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            this.UpdateGUI();
            return;
        }// end function

        public function SetMaxCount(param1:int) : void
        {
            this.mMaxCount = param1;
            return;
        }// end function

        public function RemoveBuildingFromQueue(param1:int) : void
        {
            var _loc_2:* = this.GetBuildingWithIndex(param1);
            if (_loc_2 < 0)
            {
                return;
            }
            this.mQueue_vector.splice(_loc_2, 1);
            this.ReadjustGridPositionsOfTempSlotsFrom(this.GetTempSlotWithIndex(param1));
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            this.UpdateGUI();
            return;
        }// end function

        public function RemoveGui(param1:int) : void
        {
            var _loc_2:* = this.GetBuildingWithIndex(param1);
            if (_loc_2 < 0)
            {
                return;
            }
            if (!this.mWaitForBuildqueueMovedCommand)
            {
                this.SetBuildqueueBusy(true);
                this.mGeneralInterface.SendServerAction(COMMAND.BUILDQUEUE_REMOVE, 0, param1, 0, null);
                this.UpdateGUI();
            }
            return;
        }// end function

        public function updateTempSlots() : void
        {
            var _loc_2:dTempBuildSlotVO = null;
            var _loc_3:cBuildSlot = null;
            var _loc_4:int = 0;
            var _loc_1:* = this.mTempBuildSlots_vector.length;
            for each (_loc_2 in this.mPlayerData.mAvailableTempSlots_vector)
            {
                
                _loc_3 = new cBuildSlot(_loc_2.timeOfPurchase, _loc_2.buildingGridPos);
                _loc_3.mType = cBuildSlot.TEMPORARY_BUILDSLOT;
                _loc_4 = this.TempSlotPosInVector(_loc_3);
                if (_loc_3.updateTimeLeft(this.mGeneralInterface.GetClientTime()))
                {
                    if (_loc_4 < 0)
                    {
                        this.mTempBuildSlots_vector.push(_loc_3);
                    }
                    continue;
                }
                if (_loc_4 >= 0 && this.mTempBuildSlots_vector[_loc_4].GetBuildingGridPosition() > 0 || _loc_4 < 0 && _loc_3.GetBuildingGridPosition() > 0)
                {
                    if (_loc_4 < 0 && this.IsBuildingAtGridPositionInQueue(_loc_3.GetBuildingGridPosition()))
                    {
                        this.mTempBuildSlots_vector.push(_loc_3);
                    }
                    continue;
                }
                this.removeTempSlot(_loc_2);
            }
            if (globalFlash.gui.mBuildQueue != null && this.mTempBuildSlots_vector.length != _loc_1)
            {
                globalFlash.gui.mBuildQueue.SetEnableBuyTempBuildSlot(this.mTempBuildSlots_vector.length < global.maxTempSlotsAvailablePerPlayer);
                this.UpdateGUI();
            }
            return;
        }// end function

        public function IsFull() : Boolean
        {
            return this.mQueue_vector.length + this.mPlayerData.GetPrePlacesBuildingCounter() >= this.GetTotalAvailableSlots();
        }// end function

        public function IsAnythingInBuildqueue() : Boolean
        {
            return this.mQueue_vector.length >= 2;
        }// end function

    }
}
