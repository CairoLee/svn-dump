package ServerState
{
    import BuffSystem.*;
    import Communication.VO.*;
    import Enums.*;
    import GO.*;
    import Interface.*;
    import PathFinding.*;
    import SettlerKI.*;
    import Sound.*;
    import __AS3__.vec.*;
    import mx.collections.*;
    import nLib.*;

    public class cComputeResourceCreation extends Object
    {
        private var mCurrentTime:Number;
        public var mResourceProcoll:ArrayCollection;
        public var mResourceCreation_vector:Vector.<cResourceCreation>;
        private var mResourceCreationPlayer:cPlayerData;
        private var mCurrentResourceNr:int;
        private var mResourceCreationResources:cResources;
        private var mTempPoint:cPosInt;
        private var mGeneralInterface:cGeneralInterface;
        private static var mComputeResourceCreationLogZone:Boolean = false;
        public static const SETTLER_WALK_SPEED_INT:int = 5;
        private static const INCREASE_RESOURCE_RESULT_OK:int = 0;
        private static const DEPOSIT_CREATION_INFO:Boolean = false;
        private static const INCREASE_RESOURCE_SET_SETTLER_TO_IDLE:int = 1;

        public function cComputeResourceCreation(param1:cGeneralInterface)
        {
            this.mResourceCreation_vector = new Vector.<cResourceCreation>;
            this.mResourceProcoll = new ArrayCollection();
            this.mTempPoint = new cPosInt();
            this.mGeneralInterface = param1;
            return;
        }// end function

        private function ComputeBuildingProcesses() : void
        {
            var _loc_1:int = 0;
            var _loc_3:cBuilding = null;
            var _loc_4:Number = NaN;
            var _loc_5:Number = NaN;
            var _loc_6:cResources = null;
            var _loc_2:* = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.GetBuildings_vector();
            for each (_loc_3 in _loc_2)
            {
                
                if (_loc_3.mBuildingUpgradeIsInProgress)
                {
                    _loc_4 = this.mCurrentTime - _loc_3.GetUpgradeStartTime();
                    _loc_1 = _loc_3.GetUpgradeDuration();
                    _loc_5 = _loc_4 * 100 / _loc_1;
                    _loc_3.mBuildingUpgradeProgress = int(_loc_5);
                    if (_loc_3.mBuildingUpgradeProgress >= 100)
                    {
                        _loc_3.Upgrade();
                        _loc_3.mBuildingUpgradeProgress = 100;
                        this.mGeneralInterface.mCurrentPlayerZone.SetBackgroundHasChanged(true);
                        _loc_3.mBuildingUpgradeIsInProgress = false;
                        if (_loc_3.GetResourceCreation() != null)
                        {
                            _loc_3.SetBuildingMode(cBuilding.BUILDING_MODE_SETTLER_WALKS_FROM_STOREHOUSE_TO_RESOURCECREATIONHOUSE);
                            if (!_loc_3.GetGOContainer().mConstructBuildingWithoutSettler)
                            {
                                _loc_3.GetResourceCreation().SetSettlerKIState(cSettlerKI.SETTLER_STATE_WALKING_ON_RESOURCE_PATH);
                                _loc_3.GetResourceCreation().pathPos = 0;
                            }
                        }
                        else
                        {
                            _loc_3.SetBuildingMode(cBuilding.BUILDING_MODE_PRODUCES_NO_RESOURCES);
                        }
                        _loc_6 = this.mGeneralInterface.mCurrentPlayerZone.GetResourcesForPlayerID(_loc_3.GetPlayerID());
                        _loc_6.CalculateMaxLimitsForResources(_loc_3.GetPlayerID());
                        this.mGeneralInterface.RefreshGui();
                    }
                }
                if (_loc_3.IsBuildingActive() && _loc_3.GetRecoveringHitPoints() > 0 && !_loc_3.IsEngagedInCombat())
                {
                    if (_loc_3.CheckForRepairRound())
                    {
                        _loc_3.RepairBuilding(_loc_3.GetRecoveringHitPoints());
                        if (_loc_3.GetCurrentHitPoints() >= _loc_3.GetMaxHitPoints())
                        {
                            _loc_3.SetRecoveringHitPoints(0);
                        }
                    }
                }
            }
            return;
        }// end function

        private function CreateResourceCreation(param1:cPlayerData, param2:dResourceCreationDefinition, param3:cBuilding) : void
        {
            var _loc_4:* = new cResourceCreation(param1.GetPlayerId(), param2, param3);
            new cResourceCreation(param1.GetPlayerId(), param2, param3).SetProductionState(cResourceCreation.PRODUCTIONSTATE_WORKING);
            if (param3 != null)
            {
                this.AssignSettlerGfx(_loc_4);
            }
            param3.SetResourceCreation(_loc_4);
            this.mResourceCreation_vector.push(_loc_4);
            this.SpawnSettler(param1, _loc_4, defines.SETTLER_BUILDER_string);
            return;
        }// end function

        public function CalculateProductionPaths(param1:cBuilding, param2:Boolean) : void
        {
            var _loc_3:cResourceCreation = null;
            var _loc_4:String = null;
            if (this.mGeneralInterface.mLog.isTraceEnabled(LOG_TYPE.ECONOMY))
            {
                this.mGeneralInterface.mLog.logTrace(LOG_TYPE.ECONOMY, "CalculateProductionPaths(" + param1 + ", " + param2 + ")");
            }
            if (param1 == null)
            {
                for each (_loc_3 in this.mResourceCreation_vector)
                {
                    
                    if (!this.CalculateProductionPath(_loc_3, param2))
                    {
                        if (!_loc_3.GetRemove() && _loc_3.GetResourceCreationHouse() != null)
                        {
                            _loc_4 = _loc_3.GetResourceCreationHouse().GetBuildingName_string();
                            if (_loc_4 != defines.GARRISON_NAME_string)
                            {
                                _loc_3.GetResourceCreationHouse().SetBuildingMode(cBuilding.BUILDING_MODE_PRODUCES_NO_RESOURCES);
                            }
                        }
                    }
                }
            }
            else
            {
                this.CalculateProductionPath(param1.GetResourceCreation(), param2);
            }
            return;
        }// end function

        public function CreateResourceCreationForBuilding(param1:cBuilding) : void
        {
            var _loc_2:* = this.mGeneralInterface.mCurrentPlayer;
            if (_loc_2.GetPlayerId() != param1.GetPlayerID())
            {
                _loc_2 = this.mGeneralInterface.FindPlayerFromId(param1.GetPlayerID());
            }
            gMisc.Assert(_loc_2 != null, "Could not find player for " + param1);
            var _loc_3:* = gEconomics.GetResourcesCreationDefinitionForBuilding(param1.GetBuildingName_string());
            if (_loc_3 != null)
            {
                this.CreateResourceCreation(_loc_2, _loc_3, param1);
            }
            else
            {
                this.CreateResourceCreation(_loc_2, null, param1);
            }
            return;
        }// end function

        public function Compute() : void
        {
            var _loc_1:cSettlerKIWalkToDestination = null;
            var _loc_3:cResourceCreation = null;
            var _loc_4:int = 0;
            var _loc_5:dResourceCreationDefinition = null;
            var _loc_6:cBuilding = null;
            var _loc_7:int = 0;
            var _loc_8:String = null;
            var _loc_9:cResourceCreation = null;
            if (this.mGeneralInterface.mLog.isTraceEnabled(LOG_TYPE.ECONOMY))
            {
                this.mGeneralInterface.mLog.logTrace(LOG_TYPE.ECONOMY, "++*** BEGIN cComputeResourceCreation.Compute() *****");
            }
            this.mCurrentTime = this.mGeneralInterface.GetClientTime();
            this.ComputeBuildingProcesses();
            var _loc_2:int = 0;
            while (_loc_2 < this.mResourceCreation_vector.length)
            {
                
                _loc_3 = this.mResourceCreation_vector[_loc_2];
                this.mCurrentResourceNr = _loc_2;
                if (_loc_3.GetPlayerID() == this.mGeneralInterface.mCurrentPlayer.GetPlayerId())
                {
                    this.mResourceCreationPlayer = this.mGeneralInterface.mCurrentPlayer;
                }
                else
                {
                    this.mResourceCreationPlayer = this.mGeneralInterface.FindPlayerFromId(_loc_3.GetPlayerID());
                }
                if (this.mResourceCreationPlayer == null)
                {
                }
                else
                {
                    this.mResourceCreationResources = this.mGeneralInterface.mCurrentPlayerZone.GetResources(this.mResourceCreationPlayer);
                    if (_loc_3.GetRemove())
                    {
                        _loc_3.SetSettlerKIStateDeactivate();
                        if (_loc_3.GetAssignedSettler() && this.mResourceCreationResources != null)
                        {
                            this.mResourceCreationResources.FreeWorkers(1);
                        }
                        this.mResourceCreation_vector.splice(_loc_2, 1);
                        _loc_2 = _loc_2 - 1;
                    }
                    else
                    {
                        if (_loc_3.GetResourceCreationDefinition() != null)
                        {
                            if (_loc_3.GetResourceCreationDefinition().typeEnumResourceType == RESOURCE_TYPE.CREATED_BY_BUILDING)
                            {
                                if (_loc_3.GetStoreHouse() == null)
                                {
                                    _loc_3.SetProductionState(cResourceCreation.PRODUCTIONSTATE_STOPPED_PRODUCTION);
                                }
                            }
                        }
                        _loc_4 = this.IncreaseResource(_loc_3, this.mGeneralInterface.mClientDeltaTime);
                        if (_loc_4 != INCREASE_RESOURCE_RESULT_OK)
                        {
                            if (_loc_4 == INCREASE_RESOURCE_SET_SETTLER_TO_IDLE)
                            {
                                _loc_3.SetSettlerKIState(cSettlerKI.SETTLER_STATE_WAIT_FOR_STORE_HOUSE);
                                if (_loc_3.GetSettler() != null)
                                {
                                    (_loc_3.GetSettler().mSettlerKi as cSettlerKIWalkToDestination).mVisible = false;
                                }
                            }
                        }
                        _loc_5 = _loc_3.GetResourceCreationDefinition();
                        if (_loc_5 != null)
                        {
                            if (_loc_5.typeEnumResourceType == RESOURCE_TYPE.CREATED_BY_BUILDING)
                            {
                                _loc_6 = _loc_3.GetResourceCreationHouse();
                                if (!_loc_3.GetRemove() && _loc_6 != null)
                                {
                                    if (_loc_6.GetGOContainer().mDepositAnimName_string != null)
                                    {
                                        if (_loc_3.GetDepositBuildingGridPos() != -1)
                                        {
                                            _loc_7 = _loc_3.GetDepositBuildingGridPos();
                                            if (_loc_6.GetBuildingMode() == cBuilding.BUILDING_MODE_WORKANIM_IS_WORKING_AT_EXTERNAL_DEPOSIT && _loc_3.GetProductionState() == cResourceCreation.PRODUCTIONSTATE_WORKING)
                                            {
                                                _loc_8 = _loc_6.GetGOContainer().mDepositAnimName_string;
                                                if (this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_7].mGoSetListAnimation == null)
                                                {
                                                    this.mGeneralInterface.mGoSetListAnimationManager.AddAnimation(_loc_7, _loc_8, 0, global.streetGridYHalf, _loc_3);
                                                }
                                            }
                                            else if (this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_7].mGoSetListAnimation != null)
                                            {
                                                _loc_9 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_7].mGoSetListAnimation.object as cResourceCreation;
                                                if (_loc_9 == _loc_3)
                                                {
                                                    this.mGeneralInterface.mGoSetListAnimationManager.Remove(_loc_7);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                _loc_2++;
            }
            if (this.mGeneralInterface.mLog.isTraceEnabled(LOG_TYPE.ECONOMY))
            {
                this.mGeneralInterface.mLog.logTrace(LOG_TYPE.ECONOMY, "***** END cComputeResourceCreation.Compute() *****");
            }
            return;
        }// end function

        public function ResetResourceCreation() : void
        {
            this.mResourceCreation_vector = new Vector.<cResourceCreation>;
            return;
        }// end function

        public function SearchForNearestDepositFast(param1:cResourceCreation) : Boolean
        {
            var _loc_3:cPathObject = null;
            var _loc_6:int = 0;
            var _loc_7:cDeposit = null;
            var _loc_8:dPathObjectItem = null;
            var _loc_2:* = param1.GetResourceCreationDefinition().externalResource_string;
            var _loc_4:* = defines.NO_PLAYERID;
            if (!param1.GetRemove() && param1.GetResourceCreationHouse() != null)
            {
                _loc_7 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[param1.GetResourceCreationHouse().GetBuildingGrid()].mDeposit;
                if (_loc_7 != null && _loc_7.GetName_string() == _loc_2)
                {
                    _loc_3 = new cPathObject();
                    param1.SetDepositBuildingGridPos(param1.GetResourceCreationHouse().GetBuildingGrid());
                    param1.SetDepositPath(_loc_3);
                    param1.pathPos = 0;
                    return true;
                }
                _loc_4 = param1.GetResourceCreationHouse().GetPlayerID();
            }
            var _loc_5:* = param1.GetResourceCreationHouse().GetStreetGridEntry();
            if (param1.GetResourceCreationDefinition().amountRemoved > 0)
            {
                _loc_6 = cPathFinder.AMOUNT_TYPE_ABOVE_ZERO;
            }
            else
            {
                _loc_6 = cPathFinder.AMOUNT_TYPE_BELOW_MAX;
            }
            _loc_3 = this.mGeneralInterface.mPathFinder.CalculatePathForDeposit(_loc_2, _loc_5, _loc_4, _loc_6);
            if (_loc_3 != null && _loc_3.dest_vector.length > 0)
            {
                _loc_8 = _loc_3.dest_vector[0];
                param1.SetDepositBuildingGridPos(_loc_8.streetGridIdx);
                param1.SetDepositPath(_loc_3);
                param1.pathPos = 0;
                _loc_3.dest_vector.reverse();
                return true;
            }
            param1.SetDepositBuildingGridPos(-1);
            return false;
        }// end function

        private function IncreaseResource(param1:cResourceCreation, param2:int) : int
        {
            var _loc_3:cDeposit = null;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:cBuff = null;
            var _loc_8:cBuilding = null;
            var _loc_9:cBuilding = null;
            var _loc_10:int = 0;
            var _loc_11:int = 0;
            var _loc_12:int = 0;
            var _loc_13:cIsoElement = null;
            var _loc_14:int = 0;
            var _loc_15:cResourceCreation = null;
            var _loc_16:int = 0;
            var _loc_17:cBuilding = null;
            var _loc_18:cBuilding = null;
            var _loc_19:cBuilding = null;
            var _loc_20:int = 0;
            var _loc_21:int = 0;
            var _loc_22:int = 0;
            var _loc_23:Boolean = false;
            var _loc_24:int = 0;
            var _loc_25:cBuilding = null;
            var _loc_26:Vector.<BuffAppliance> = null;
            var _loc_27:BuffAppliance = null;
            var _loc_28:int = 0;
            if (this.mGeneralInterface.mLog.isTraceEnabled(LOG_TYPE.ECONOMY))
            {
                this.mGeneralInterface.mLog.logTrace(LOG_TYPE.ECONOMY, "IncreaseResource(" + param1 + ", " + param2 + ")");
            }
            var _loc_7:* = param1.GetResourceCreationDefinition();
            if (param1.GetResourceCreationDefinition() == null || _loc_7.typeEnumResourceType == RESOURCE_TYPE.CREATED_BY_BUILDING)
            {
            }
            _loc_8 = param1.GetResourceCreationHouse();
            if (_loc_8 == null)
            {
                this.mGeneralInterface.mLog.logPossibleError(676, "Possible java.lang.NullPointerException -> building is null " + param1, !mComputeResourceCreationLogZone);
                mComputeResourceCreationLogZone = true;
                param1.SetRemove(true);
                return INCREASE_RESOURCE_RESULT_OK;
            }
            ;
            
            if (!_loc_8.GetGOContainer().mConstructBuildingWithoutSettler)
            {
                _loc_5 = int(this.mCurrentTime - _loc_8.mBuildingCreationTime);
                param1.pathPos = _loc_5 * SETTLER_WALK_SPEED_INT;
                param1.protocollResourceCreationProcessCntr = 0;
                if (!definesMaster.MASTER_VERSION && defines.PROTOKOLL_RESOURCE_CREATION)
                {
                    this.PROTOKOLL_RESOURCE_CREATION_WRITE(param1, this.mCurrentResourceNr, _loc_8.mBuildingCreationTime, 0, "START SET_BUILDING_GROUND_PLACE  Delta: " + param2 + " time: " + this.mCurrentTime + "restTime: " + _loc_5);
                    if (defines.PROTOKOLL_RESOURCE_CREATION_DESTTIME)
                    {
                        _loc_4 = (param1.GetPath().pathLenX10000 - param1.pathPos) / SETTLER_WALK_SPEED_INT;
                        this.PROTOKOLL_RESOURCE_CREATION_WRITE(param1, this.mCurrentResourceNr, _loc_4 + this.mCurrentTime, 0 + 1000, "DESTTIME START SET_BUILDING_GROUND_PLACE Delta: " + param2 + " time: " + this.mCurrentTime + "restTime: " + _loc_5 + " building.mBuildingCreationTime:" + _loc_8.mBuildingCreationTime);
                    }
                    var _loc_29:* = param1;
                    var _loc_30:* = param1.protocollResourceCreationProcessCntr + 1;
                    _loc_29.protocollResourceCreationProcessCntr = _loc_30;
                    param1.protocollResourceCreationLastBuildingMode = 0;
                }
                param1.SetSettlerKIState(cSettlerKI.SETTLER_STATE_WALKING_ON_RESOURCE_PATH);
                _loc_8.SetBuildingMode(cBuilding.BUILDING_MODE_SETTLER_WALKS_TO_BUILDING_GROUND_PLACE);
            }
            ;
            
            param1.SetSettlerKIState(cSettlerKI.SETTLER_STATE_WALKING_ON_RESOURCE_PATH);
            param1.pathPos = param1.pathPos + param2 * SETTLER_WALK_SPEED_INT;
            if (param1.pathPos >= param1.GetPath().pathLenX10000)
            {
                _loc_5 = (param1.pathPos - param1.GetPath().pathLenX10000) / SETTLER_WALK_SPEED_INT;
                if (!definesMaster.MASTER_VERSION && defines.PROTOKOLL_RESOURCE_CREATION)
                {
                    this.PROTOKOLL_RESOURCE_CREATION_WRITE(param1, this.mCurrentResourceNr, this.mCurrentTime - _loc_5, 1, "SETTLER_WALKS_TO_BUILDING_GROUND_PLACE Delta: " + param2 + " time: " + this.mCurrentTime + " restTime:" + _loc_5 + " GetPath: " + param1.GetPath());
                    var _loc_29:* = param1;
                    var _loc_30:* = param1.protocollResourceCreationProcessCntr + 1;
                    _loc_29.protocollResourceCreationProcessCntr = _loc_30;
                    param1.protocollResourceCreationLastBuildingMode = 1;
                }
                param1.SetSettlerKIState(cSettlerKI.SETTLER_STATE_IS_WORKING_IN_RESOURCE_CREATION_HOUSE);
                _loc_8.mBuildingProgress = _loc_5 * 1000 / _loc_8.GetGOContainer().mConstructionDuration;
                _loc_8.SetBuildingMode(cBuilding.BUILDING_MODE_CONSTRUCTION);
            }
            ;
            
            param1.SetSettlerKIState(cSettlerKI.SETTLER_STATE_IS_WORKING_IN_RESOURCE_CREATION_HOUSE);
            _loc_8.mBuildingProgress = _loc_8.mBuildingProgress + param2 * 1000 / _loc_8.GetGOContainer().mConstructionDuration;
            if (_loc_8.mBuildingProgress >= 100 * defines.BUILDING_PROGRESS_SCALE_FACTOR)
            {
                _loc_5 = (_loc_8.mBuildingProgress - 100 * defines.BUILDING_PROGRESS_SCALE_FACTOR) * _loc_8.GetGOContainer().mConstructionDuration / 1000;
                if (!definesMaster.MASTER_VERSION && defines.PROTOKOLL_RESOURCE_CREATION)
                {
                    this.PROTOKOLL_RESOURCE_CREATION_WRITE(param1, this.mCurrentResourceNr, this.mCurrentTime - _loc_5, 2, "CONSTRUCTION Delta: " + param2 + " time: " + this.mCurrentTime + " restTime:" + _loc_5);
                    var _loc_29:* = param1;
                    var _loc_30:* = param1.protocollResourceCreationProcessCntr + 1;
                    _loc_29.protocollResourceCreationProcessCntr = _loc_30;
                    param1.protocollResourceCreationLastBuildingMode = 2;
                }
                _loc_8.mBuildingProgress = 100 * defines.BUILDING_PROGRESS_SCALE_FACTOR;
                if (!this.mGeneralInterface.mRefreshZoneIsActive)
                {
                    this.mGeneralInterface.mCurrentPlayerZone.SetWatchArea(OBJECTTYPE.BUILDING, _loc_8.GetBuildingName_string(), _loc_8);
                }
                if (_loc_8.IsWarehouseType())
                {
                    _loc_10 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_8.GetBuildingGrid()].mSectorId;
                    if (this.mGeneralInterface.mCurrentPlayerZone.GetSectorOwnerPlayerID(_loc_10) == 0)
                    {
                        this.mGeneralInterface.mCurrentPlayerZone.SetPlayerForSector(_loc_10, _loc_8.GetPlayerID());
                        this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.CalculateBorders();
                        globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.CLAIMED_SECTOR);
                    }
                }
                if (_loc_8.GetBuildingName_string() == defines.LOGISTICS_NAME_string)
                {
                    this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.SetLogisticsHouse(_loc_8);
                }
                if (_loc_8.GetBuildingName_string() == defines.GUILDHOUSE_NAME_string)
                {
                    this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.SetGuildHouse(_loc_8);
                }
                if (_loc_8.GetGOContainer().mAddDepositAmount != -1)
                {
                    this.mGeneralInterface.SetDepositType(this.mGeneralInterface.DEPOSIT_TYPE_SINGLE);
                    _loc_3 = this.mGeneralInterface.mSetBuildings.SetDepositMode(this.mGeneralInterface, this.mGeneralInterface.mCurrentPlayerZone, this.mResourceCreationPlayer, null, null, _loc_8.GetGOContainer().mAddDepositName, OBJECTTYPE.DEPOSIT, _loc_8.GetGOContainer().mAddDepositAmount, _loc_8.GetBuildingGrid());
                    this.mGeneralInterface.mPathFinder.InvalidateDepositMatrix(_loc_8.GetPlayerID(), _loc_3.GetName_string(), cPathFinder.AMOUNT_TYPE_ABOVE_ZERO);
                }
                this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.CalculateBorders();
                if (!_loc_8.GetGOContainer().mConstructBuildingWithoutSettler)
                {
                    _loc_8.SetBuildingMode(cBuilding.BUILDING_MODE_BUILDER_WALKS_FROM_RESOURCECREATIONHOUSE_TO_STOREHOUSE);
                    param1.SetSettlerKIState(cSettlerKI.SETTLER_STATE_WALKING_ON_RESOURCE_PATH);
                    param1.pathPos = param1.GetPath().pathLenX10000 + _loc_5 * SETTLER_WALK_SPEED_INT;
                    if (!definesMaster.MASTER_VERSION && defines.PROTOKOLL_RESOURCE_CREATION_DESTTIME)
                    {
                        _loc_4 = (param1.GetPath().pathLenX20000 - param1.pathPos) / SETTLER_WALK_SPEED_INT;
                        this.PROTOKOLL_RESOURCE_CREATION_WRITE(param1, this.mCurrentResourceNr, _loc_4 + this.mCurrentTime, 3, "DESTTIME BUILDER_WALKS_FROM_RESOURCECREATIONHOUSE_TO_STOREHOUSE Delta: " + param2 + " time: " + this.mCurrentTime + " restTime:" + _loc_5);
                        var _loc_29:* = param1;
                        var _loc_30:* = param1.protocollResourceCreationProcessCntr + 1;
                        _loc_29.protocollResourceCreationProcessCntr = _loc_30;
                        param1.protocollResourceCreationLastBuildingMode = 3;
                    }
                }
                else if (_loc_7 != null)
                {
                    _loc_8.SetBuildingMode(cBuilding.BUILDING_MODE_SETTLER_WALKS_FROM_STOREHOUSE_TO_RESOURCECREATIONHOUSE);
                    param1.pathPos = _loc_5 * SETTLER_WALK_SPEED_INT;
                }
                else
                {
                    _loc_8.SetBuildingMode(cBuilding.BUILDING_MODE_PRODUCES_NO_RESOURCES);
                }
                if (this.mResourceCreationResources != null)
                {
                    this.mResourceCreationResources.CalculateMaxLimitsForResources(this.mResourceCreationPlayer.GetPlayerId());
                }
                param1.SetProductionState(cResourceCreation.PRODUCTIONSTATE_WORKING);
                this.mGeneralInterface.mPathFinder.InvalidateAll(this.mResourceCreationPlayer.GetPlayerId());
                for each (_loc_9 in this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.GetBuildings_vector())
                {
                    
                    if (_loc_9.GetResourceCreation() != null)
                    {
                        _loc_9.GetResourceCreation().SetInvalidatePaths(true);
                    }
                }
                this.mResourceCreationPlayer.IncBuildingCount(_loc_8);
                this.mGeneralInterface.mDataTracking.AddTrackingValue(cDataTracking.DATA_TRACKING_BUILDING_BUILT, 1);
                this.mGeneralInterface.mCurrentPlayerZone.SetBackgroundHasChanged(true);
                _loc_8.mBuildingCreationTime = this.mCurrentTime - _loc_5;
                this.mResourceCreationPlayer.AddXP(_loc_8.GetGOContainer().mXP);
                this.mGeneralInterface.RefreshGui();
                this.mGeneralInterface.mQuestClientCallbacks.BuildingCreated(_loc_8.GetBuildingName_string());
                cSoundManager.GetInstance().PlayEffect("BuildingReady");
            }
            ;
            
            param1.pathPos = param1.pathPos + param2 * SETTLER_WALK_SPEED_INT;
            if (param1.pathPos >= param1.GetPath().pathLenX20000)
            {
                if (_loc_7 == null)
                {
                    _loc_8.SetBuildingMode(cBuilding.BUILDING_MODE_PRODUCES_NO_RESOURCES);
                    param1.SetRemove(true);
                    return INCREASE_RESOURCE_RESULT_OK;
                }
                if (this.mResourceCreationResources.AssignWorkers(1))
                {
                    param1.pathPos = param1.pathPos - param1.GetPath().pathLenX20000;
                    param1.SetWorkingSettler();
                    param1.SetAssignedSettler(true);
                    _loc_8.SetBuildingMode(cBuilding.BUILDING_MODE_SETTLER_WALKS_FROM_STOREHOUSE_TO_RESOURCECREATIONHOUSE);
                    param1.SetSettlerKIState(cSettlerKI.SETTLER_STATE_WALKING_ON_RESOURCE_PATH);
                    param1.SetProductionState(cResourceCreation.PRODUCTIONSTATE_WORKING);
                    if (!definesMaster.MASTER_VERSION && defines.PROTOKOLL_RESOURCE_CREATION)
                    {
                        _loc_5 = param1.pathPos / SETTLER_WALK_SPEED_INT;
                        this.PROTOKOLL_RESOURCE_CREATION_WRITE(param1, this.mCurrentResourceNr, this.mCurrentTime - _loc_5, 4, "BUILDER_WALKS_FROM_RESOURCECREATIONHOUSE_TO_STOREHOUSE Delta: " + param2 + " time: " + this.mCurrentTime + " restTime:" + _loc_5 + " _resourceCreation.GetPath().pathLenX20000" + param1.GetPath().pathLenX20000 + " GetPath: " + param1.GetPath());
                        if (!definesMaster.MASTER_VERSION && defines.PROTOKOLL_RESOURCE_CREATION_DESTTIME)
                        {
                            _loc_4 = (param1.GetPath().pathLenX10000 - param1.pathPos) / SETTLER_WALK_SPEED_INT;
                            this.PROTOKOLL_RESOURCE_CREATION_WRITE(param1, this.mCurrentResourceNr, _loc_4 + this.mCurrentTime, 4 + 1000, "DESTTIME SETTLER_WALKS_FROM_STOREHOUSE_TO_RESOURCECREATIONHOUSE Delta: " + param2 + " time: " + this.mCurrentTime + " restTime:" + _loc_5 + " _resourceCreation.GetPath().pathLenX20000" + param1.GetPath().pathLenX20000 + " GetPath: " + param1.GetPath());
                        }
                        var _loc_29:* = param1;
                        var _loc_30:* = param1.protocollResourceCreationProcessCntr + 1;
                        _loc_29.protocollResourceCreationProcessCntr = _loc_30;
                        param1.protocollResourceCreationLastBuildingMode = 4;
                    }
                }
                else
                {
                    param1.pathPos = param1.pathPos - defines.POPULATION_WAIT_TIME;
                    param1.SetSettlerKIState(cSettlerKI.SETTLER_STATE_WAITS_FOR_POPULATION);
                    param1.SetProductionState(cResourceCreation.PRODUCTIONSTATE_ERROR_WAITING_FOR_SETTLER);
                    if (!definesMaster.MASTER_VERSION && defines.PROTOKOLL_RESOURCE_CREATION)
                    {
                        this.PROTOKOLL_RESOURCE_CREATION_WRITE(param1, this.mCurrentResourceNr, 0, 5, "BUILDER_WALKS_FROM_RESOURCECREATIONHOUSE_TO_STOREHOUSE -> BUILDING_MODE_WAITING_FOR_SETTLER Delta: " + param2 + " time: " + this.mCurrentTime + " _resourceCreation.GetPath().pathLenX20000" + param1.GetPath().pathLenX20000 + " GetPath: " + param1.GetPath());
                        var _loc_29:* = param1;
                        var _loc_30:* = param1.protocollResourceCreationProcessCntr + 1;
                        _loc_29.protocollResourceCreationProcessCntr = _loc_30;
                        param1.protocollResourceCreationLastBuildingMode = 5;
                    }
                }
            }
            ;
            
            ;
            
            if (_loc_7 == null)
            {
                return INCREASE_RESOURCE_RESULT_OK;
            }
            param1.SetSettlerKIState(cSettlerKI.SETTLER_STATE_WALKING_ON_RESOURCE_PATH);
            param1.pathPos = param1.pathPos + param2 * SETTLER_WALK_SPEED_INT;
            if (param1.pathPos >= param1.GetPath().pathLenX10000)
            {
                if (param1.GetStoreHouse() == null)
                {
                    return INCREASE_RESOURCE_SET_SETTLER_TO_IDLE;
                }
                _loc_5 = (param1.pathPos - param1.GetPath().pathLenX10000) / SETTLER_WALK_SPEED_INT;
                _loc_11 = param1.pathPos;
                param1.pathPos = param1.GetPath().pathLenX10000;
                param1.SetSettlerKIState(cSettlerKI.SETTLER_STATE_IS_WORKING_IN_RESOURCE_CREATION_HOUSE);
                if (_loc_7.externalResource_string != "")
                {
                    _loc_8.mStartWorkCounter = -_loc_5;
                    _loc_8.SetBuildingMode(cBuilding.BUILDING_MODE_WORKANIM_IS_WORKING_AT_WORKYARD_EXTERNAL_WORKYARD_SYSTEM_ACTIVE);
                    if (!definesMaster.MASTER_VERSION && defines.PROTOKOLL_RESOURCE_CREATION)
                    {
                        this.PROTOKOLL_RESOURCE_CREATION_WRITE(param1, this.mCurrentResourceNr, this.mCurrentTime - _loc_5, 7, "External Resource SETTLER_WALKS_FROM_STOREHOUSE_TO_RESOURCECREATIONHOUSE Delta: " + param2 + " time: " + this.mCurrentTime + " restTime:" + _loc_5 + " oldPathPos: " + _loc_11 + " _resourceCreation.GetPath().pathLenX10000:" + param1.GetPath().pathLenX10000 + " GetPath: " + param1.GetPath());
                        if (!definesMaster.MASTER_VERSION && defines.PROTOKOLL_RESOURCE_CREATION_DESTTIME)
                        {
                            _loc_4 = -_loc_5;
                            this.PROTOKOLL_RESOURCE_CREATION_WRITE(param1, this.mCurrentResourceNr, _loc_4 + this.mCurrentTime, 7 + 1000, "DESTTIME WORKANIM_IS_WORKING_AT_WORKYARD_EXTERNAL_WORKYARD_SYSTEM_ACTIVE Delta: " + param2 + " time: " + this.mCurrentTime + " restTime:" + _loc_5 + " oldPathPos: " + _loc_11 + " _resourceCreation.GetPath().pathLenX10000:" + param1.GetPath().pathLenX10000 + " GetPath: " + param1.GetPath());
                        }
                        var _loc_29:* = param1;
                        var _loc_30:* = param1.protocollResourceCreationProcessCntr + 1;
                        _loc_29.protocollResourceCreationProcessCntr = _loc_30;
                        param1.protocollResourceCreationLastBuildingMode = 7;
                    }
                }
                else
                {
                    _loc_12 = param1.GetPath().pathLenX20000 / SETTLER_WALK_SPEED_INT;
                    _loc_8.mStartWorkCounter = -_loc_5 + _loc_12 + _loc_7.workTime * 1000;
                    _loc_8.SetBuildingMode(cBuilding.BUILDING_MODE_WORKANIM_IS_WORKING_AT_WORKYARD_LOCAL_WORKYARD_SYSTEM);
                    if (!definesMaster.MASTER_VERSION && defines.PROTOKOLL_RESOURCE_CREATION)
                    {
                        this.PROTOKOLL_RESOURCE_CREATION_WRITE(param1, this.mCurrentResourceNr, this.mCurrentTime - _loc_5, 8, "internal Resource SETTLER_WALKS_FROM_STOREHOUSE_TO_RESOURCECREATIONHOUSE Delta: " + param2 + " time: " + this.mCurrentTime + " oldPathPos: " + _loc_11 + " _resourceCreation.GetPath().pathLenX10000:" + param1.GetPath().pathLenX10000);
                        var _loc_29:* = param1;
                        var _loc_30:* = param1.protocollResourceCreationProcessCntr + 1;
                        _loc_29.protocollResourceCreationProcessCntr = _loc_30;
                        param1.protocollResourceCreationLastBuildingMode = 8;
                    }
                }
            }
            ;
            
            param1.SetSettlerKIState(cSettlerKI.SETTLER_STATE_IS_WORKING_IN_RESOURCE_CREATION_HOUSE);
            _loc_8.mStartWorkCounter = _loc_8.mStartWorkCounter - param2;
            if (_loc_8.mStartWorkCounter <= 0)
            {
                if (!_loc_8.IsProductionActive())
                {
                    _loc_8.mStartWorkCounter = _loc_8.mStartWorkCounter + (param2 + defines.PRODUCTION_STOP_WAITTIME);
                    param1.SetProductionState(cResourceCreation.PRODUCTIONSTATE_STOPPED_PRODUCTION);
                    ;
                }
                if (_loc_8.mBuildingUpgradeIsInProgress)
                {
                    _loc_8.mStartWorkCounter = _loc_8.mStartWorkCounter + param2;
                    ;
                }
                _loc_5 = -_loc_8.mStartWorkCounter;
                param1.pathPos = param1.GetPath().pathLenX10000 + _loc_5 * SETTLER_WALK_SPEED_INT;
                if (!definesMaster.MASTER_VERSION && defines.PROTOKOLL_RESOURCE_CREATION)
                {
                    this.PROTOKOLL_RESOURCE_CREATION_WRITE(param1, this.mCurrentResourceNr, this.mCurrentTime - _loc_5, 9, "WORKANIM_IS_WORKING_AT_WORKYARD_LOCAL_WORKYARD_SYSTEM Delta: " + param2 + " time: " + this.mCurrentTime + " restTime:" + _loc_5);
                    var _loc_29:* = param1;
                    var _loc_30:* = param1.protocollResourceCreationProcessCntr + 1;
                    _loc_29.protocollResourceCreationProcessCntr = _loc_30;
                    param1.protocollResourceCreationLastBuildingMode = 9;
                }
                param1.SetSettlerKIState(cSettlerKI.SETTLER_STATE_WALKING_ON_RESOURCE_PATH);
                param1.SetGatheredResource(_loc_7.amountRemoved);
                _loc_8.SetBuildingMode(cBuilding.BUILDING_MODE_SETTLER_WALKS_FROM_RESOURCECREATIONHOUSE_TO_STOREHOUSE);
            }
            ;
            
            param1.SetSettlerKIState(cSettlerKI.SETTLER_STATE_IS_WORKING_IN_RESOURCE_CREATION_HOUSE);
            _loc_8.mStartWorkCounter = _loc_8.mStartWorkCounter - param2;
            if (_loc_8.mStartWorkCounter <= 0)
            {
                if (!_loc_8.IsProductionActive())
                {
                    _loc_8.mStartWorkCounter = _loc_8.mStartWorkCounter + (param2 + defines.PRODUCTION_STOP_WAITTIME);
                    param1.SetProductionState(cResourceCreation.PRODUCTIONSTATE_STOPPED_PRODUCTION);
                    ;
                }
                if (_loc_8.mBuildingUpgradeIsInProgress)
                {
                    _loc_8.mStartWorkCounter = _loc_8.mStartWorkCounter + param2;
                    ;
                }
                _loc_5 = -_loc_8.mStartWorkCounter;
                if (this.SearchForNearestDepositFast(param1))
                {
                    param1.SetProductionState(cResourceCreation.PRODUCTIONSTATE_WORKING);
                    _loc_8.SetBuildingMode(cBuilding.BUILDING_MODE_SETTLER_WALKS_FROM_RESOURCECREATIONHOUSE_TO_EXTERNAL_RESOURCE);
                    param1.SetSettlerKIState(cSettlerKI.SETTLER_STATE_WALKING_ON_DEPOSIT_PATH);
                    param1.pathPos = _loc_5 * SETTLER_WALK_SPEED_INT;
                    if (!definesMaster.MASTER_VERSION && defines.PROTOKOLL_RESOURCE_CREATION)
                    {
                        this.PROTOKOLL_RESOURCE_CREATION_WRITE(param1, this.mCurrentResourceNr, param1.GetDepositPath().pathLenX10000, 20, "WORKANIM_IS_WORKING_AT_WORKYARD_EXTERNAL_WORKYARD_SYSTEM_ACTIVE PATHLEN Delta: " + param2 + " time: " + this.mCurrentTime + " pathlen: " + param1.GetDepositPath().pathLenX10000 + " Path:" + param1.GetDepositPath());
                        var _loc_29:* = param1;
                        var _loc_30:* = param1.protocollResourceCreationProcessCntr + 1;
                        _loc_29.protocollResourceCreationProcessCntr = _loc_30;
                        param1.protocollResourceCreationLastBuildingMode = 10 + 1000;
                    }
                    if (!definesMaster.MASTER_VERSION && defines.PROTOKOLL_RESOURCE_CREATION)
                    {
                        this.PROTOKOLL_RESOURCE_CREATION_WRITE(param1, this.mCurrentResourceNr, this.mCurrentTime - _loc_5, 10, "WORKANIM_IS_WORKING_AT_WORKYARD_EXTERNAL_WORKYARD_SYSTEM_ACTIVE Delta: " + param2 + " time: " + this.mCurrentTime + " restTime:" + _loc_5 + " GetDepositPath().pathLenX10000:" + param1.GetDepositPath().pathLenX10000 + " pathPos: " + param1.pathPos + " building.mStartWorkCounter:" + _loc_8.mStartWorkCounter);
                        if (defines.PROTOKOLL_RESOURCE_CREATION_DESTTIME)
                        {
                            _loc_4 = (param1.GetDepositPath().pathLenX10000 - param1.pathPos) / SETTLER_WALK_SPEED_INT;
                            this.PROTOKOLL_RESOURCE_CREATION_WRITE(param1, this.mCurrentResourceNr, _loc_4 + this.mCurrentTime, 10 + 1000, "SETTLER_WALKS_FROM_RESOURCECREATIONHOUSE_TO_EXTERNAL_RESOURCE Delta: " + param2 + " time: " + this.mCurrentTime + " restTime:" + _loc_5 + " GetDepositPath().pathLenX10000:" + param1.GetDepositPath().pathLenX10000 + " pathPos: " + param1.pathPos + " building.mStartWorkCounter:" + _loc_8.mStartWorkCounter);
                        }
                        var _loc_29:* = param1;
                        var _loc_30:* = param1.protocollResourceCreationProcessCntr + 1;
                        _loc_29.protocollResourceCreationProcessCntr = _loc_30;
                        param1.protocollResourceCreationLastBuildingMode = 10 + 1000;
                    }
                }
                else
                {
                    _loc_8.mStartWorkCounter = _loc_8.mStartWorkCounter + (param2 + defines.PRODUCTION_STOP_WAITTIME);
                    if (_loc_8.GetGOContainer().mShowMissingResources)
                    {
                        param1.SetProductionState(cResourceCreation.PRODUCTIONSTATE_ERROR_NECESSARY_RESOURCE_MISSING);
                        if (this.mGeneralInterface.mLog.isTraceEnabled(LOG_TYPE.ECONOMY))
                        {
                            this.mGeneralInterface.mLog.logTrace(LOG_TYPE.ECONOMY, "WORKANIM_IS_WORKING_AT_WORKYARD_EXTERNAL_WORKYARD_SYSTEM_ACTIVE Waiting: " + _loc_8.mStartWorkCounter);
                        }
                    }
                    ;
                }
            }
            ;
            
            if (_loc_7 == null)
            {
                return INCREASE_RESOURCE_RESULT_OK;
            }
            param1.SetSettlerKIState(cSettlerKI.SETTLER_STATE_WALKING_ON_DEPOSIT_PATH);
            param1.pathPos = param1.pathPos + param2 * SETTLER_WALK_SPEED_INT;
            if (param1.GetDepositPath() == null)
            {
                this.mGeneralInterface.mLog.logPossibleError(1187, "Possible java.lang.NullPointerException for deposit path! " + param1, !mComputeResourceCreationLogZone);
                mComputeResourceCreationLogZone = true;
                this.ErrorResetResourceCreation(param1);
                ;
            }
            if (param1.pathPos >= param1.GetDepositPath().pathLenX10000)
            {
                if (param1.GetStoreHouse() == null)
                {
                    return INCREASE_RESOURCE_SET_SETTLER_TO_IDLE;
                }
                _loc_5 = (param1.pathPos - param1.GetDepositPath().pathLenX10000) / SETTLER_WALK_SPEED_INT;
                if (!definesMaster.MASTER_VERSION && defines.PROTOKOLL_RESOURCE_CREATION)
                {
                    this.PROTOKOLL_RESOURCE_CREATION_WRITE(param1, this.mCurrentResourceNr, this.mCurrentTime - _loc_5, 12, "SETTLER_WALKS_FROM_RESOURCECREATIONHOUSE_TO_EXTERNAL_RESOURCE Delta: " + param2 + " time: " + this.mCurrentTime + " restTime:" + _loc_5);
                    var _loc_29:* = param1;
                    var _loc_30:* = param1.protocollResourceCreationProcessCntr + 1;
                    _loc_29.protocollResourceCreationProcessCntr = _loc_30;
                    param1.protocollResourceCreationLastBuildingMode = 12;
                }
                _loc_8.SetBuildingMode(cBuilding.BUILDING_MODE_WORKANIM_IS_WORKING_AT_EXTERNAL_DEPOSIT);
                param1.SetSettlerKIState(cSettlerKI.SETTLER_STATE_IS_WORKING_IN_EXTERNAL_WORKYARD);
                _loc_8.mStartWorkCounter = _loc_7.workTime * 1000 - _loc_5;
            }
            ;
            
            param1.SetSettlerKIState(cSettlerKI.SETTLER_STATE_IS_WORKING_IN_EXTERNAL_WORKYARD);
            _loc_8.mStartWorkCounter = _loc_8.mStartWorkCounter - param2;
            if (_loc_8.mStartWorkCounter <= 0)
            {
            }
            if (!_loc_8.IsProductionActive())
            {
                _loc_8.mStartWorkCounter = _loc_8.mStartWorkCounter + (param2 + defines.PRODUCTION_STOP_WAITTIME);
                param1.SetProductionState(cResourceCreation.PRODUCTIONSTATE_STOPPED_PRODUCTION);
                ;
            }
            if (_loc_8.mBuildingUpgradeIsInProgress)
            {
                _loc_8.mStartWorkCounter = _loc_8.mStartWorkCounter + param2;
                ;
            }
            _loc_5 = -_loc_8.mStartWorkCounter;
            if (!definesMaster.MASTER_VERSION && defines.PROTOKOLL_RESOURCE_CREATION)
            {
                this.PROTOKOLL_RESOURCE_CREATION_WRITE(param1, this.mCurrentResourceNr, this.mCurrentTime - _loc_5, 13, "WORKANIM_IS_WORKING_AT_EXTERNAL_DEPOSIT Delta: " + param2 + " time: " + this.mCurrentTime + " restTime:" + _loc_5 + " _resourceCreation.GetDepositPath().pathLenX10000: " + param1.GetDepositPath().pathLenX10000 + " DepositPath:" + param1.GetDepositPath());
                var _loc_29:* = param1;
                var _loc_30:* = param1.protocollResourceCreationProcessCntr + 1;
                _loc_29.protocollResourceCreationProcessCntr = _loc_30;
                param1.protocollResourceCreationLastBuildingMode = 13;
            }
            if (param1.GetDepositBuildingGridPos() != -1)
            {
            }
            if (param1.GetDepositPath() == null)
            {
                this.mGeneralInterface.mLog.logPossibleError(1187, "Possible java.lang.NullPointerException for deposit path! " + param1, !mComputeResourceCreationLogZone);
                mComputeResourceCreationLogZone = true;
                this.ErrorResetResourceCreation(param1);
                ;
            }
            param1.pathPos = param1.GetDepositPath().pathLenX10000 + _loc_5 * SETTLER_WALK_SPEED_INT;
            _loc_3 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[param1.GetDepositBuildingGridPos()].mDeposit;
            param1.SetGatheredResource(0);
            if (_loc_3 != null)
            {
            }
            if (_loc_3.GetAmount() > 0 || param1.GetResourceCreationDefinition().amountRemoved < 0)
            {
            }
            _loc_13 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_3.GetGridIdx()];
            if (_loc_13.mDeposit != null && _loc_13.mDeposit.mDepositGfx != null)
            {
                _loc_13.mDeposit.mDepositGfx.SetValue(_loc_3.GetAmount());
            }
            _loc_14 = _loc_7.amountRemoved;
            if (_loc_14 < 0)
            {
                _loc_14 = _loc_14 * _loc_8.GetResourceOutputFactor();
            }
            else
            {
                _loc_14 = _loc_14 * _loc_8.GetResourceInputFactor();
            }
            if (_loc_14 == 0)
            {
                _loc_8.mStartWorkCounter = _loc_8.mStartWorkCounter + (param2 + defines.PRODUCTION_STOP_WAITTIME);
                param1.SetProductionState(cResourceCreation.PRODUCTIONSTATE_BUFF_STOPPED_PRODUCTION);
                ;
            }
            if (DEPOSIT_CREATION_INFO && this.mGeneralInterface.mLog.isInfoEnabled(LOG_TYPE.ECONOMY))
            {
                this.mGeneralInterface.mLog.logInfo(LOG_TYPE.ECONOMY, this.mCurrentResourceNr + "Reached deposit: " + _loc_3.GetName_string() + " Amount: " + _loc_3.GetAmount() + " removed: " + _loc_7.amountRemoved);
            }
            if (_loc_3.GetAmount() >= _loc_3.GetMaxAmount() && _loc_3.GetAmount() - _loc_14 < _loc_3.GetMaxAmount())
            {
                this.mGeneralInterface.mPathFinder.InvalidateDepositMatrix(_loc_8.GetPlayerID(), _loc_3.GetName_string(), cPathFinder.AMOUNT_TYPE_BELOW_MAX);
            }
            if (_loc_3.GetAmount() <= 0 && _loc_3.GetAmount() - _loc_14 > 0)
            {
                this.mGeneralInterface.mPathFinder.InvalidateDepositMatrix(_loc_8.GetPlayerID(), _loc_3.GetName_string(), cPathFinder.AMOUNT_TYPE_ABOVE_ZERO);
            }
            _loc_3.ChangeAmount(-_loc_14);
            param1.SetGatheredResource(_loc_7.amountRemoved);
            if (_loc_3.GetAmount() <= 0)
            {
            }
            if (_loc_3.GetName_string().indexOf("Wood") == -1 && _loc_3.GetName_string() != "Fish")
            {
                globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.DEPOSIT_DEPLETED, _loc_3);
            }
            param1.SetGatheredResource(param1.GetGatheredResource() + _loc_3.GetAmount());
            _loc_3.EmptyDeposit();
            if (_loc_3.GetDepositGroupID() != -1)
            {
                _loc_3.IncEmptied();
                _loc_3.SetAccessibleType(DEPOSIT_ACCESSIBLE_TYPES.NOT_ACCESSIBLE);
            }
            this.mGeneralInterface.mPathFinder.InvalidateDepositMatrix(_loc_8.GetPlayerID(), _loc_3.GetName_string(), cPathFinder.AMOUNT_TYPE_ABOVE_ZERO);
            for each (_loc_15 in this.mResourceCreation_vector)
            {
                
                if (_loc_15.GetDepositBuildingGridPos() == param1.GetDepositBuildingGridPos())
                {
                    if (_loc_15 != param1)
                    {
                        _loc_17 = _loc_15.GetResourceCreationHouse();
                        if (!_loc_15.GetRemove() && _loc_17 != null)
                        {
                            if (_loc_15.GetResourceCreationDefinition() != null && _loc_15.GetResourceCreationDefinition().amountRemoved > 0)
                            {
                                if (_loc_17.GetBuildingMode() == cBuilding.BUILDING_MODE_WORKANIM_IS_WORKING_AT_EXTERNAL_DEPOSIT)
                                {
                                    _loc_17.SetBuildingMode(cBuilding.BUILDING_MODE_SETTLER_WALKS_FROM_EXTERNAL_RESOURCE_TO_RESOURCECREATIONHOUSE);
                                    _loc_15.pathPos = param1.GetDepositPath().pathLenX10000;
                                    _loc_15.SetWorkingSettler();
                                    _loc_15.SetSettlerKIState(cSettlerKI.SETTLER_STATE_WALKING_ON_DEPOSIT_PATH);
                                    continue;
                                }
                                if (_loc_17.GetBuildingMode() == cBuilding.BUILDING_MODE_SETTLER_WALKS_FROM_RESOURCECREATIONHOUSE_TO_EXTERNAL_RESOURCE)
                                {
                                    _loc_17.SetBuildingMode(cBuilding.BUILDING_MODE_SETTLER_WALKS_FROM_EXTERNAL_RESOURCE_TO_RESOURCECREATIONHOUSE);
                                    _loc_15.pathPos = param1.GetDepositPath().pathLenX20000 - _loc_15.pathPos;
                                    _loc_15.SetWorkingSettler();
                                    _loc_15.SetSettlerKIState(cSettlerKI.SETTLER_STATE_WALKING_ON_DEPOSIT_PATH);
                                }
                            }
                        }
                    }
                }
            }
            if (_loc_3.GetDepositGroupID() != -1)
            {
            }
            _loc_16 = _loc_3.GetGridIdx();
            this.mGeneralInterface.mCurrentPlayerZone.RemoveDepositIcon(_loc_16);
            if (this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_16].mBuilding != null)
            {
                _loc_18 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_16].mBuilding;
                this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.RemoveBuildingGridPos(_loc_18.GetBuildingGrid());
                this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.RemoveBuildingFromGameLogic(_loc_18);
            }
            this.mGeneralInterface.mCurrentPlayerZone.DepositWasDepleted(this.mGeneralInterface.mCurrentPlayer, _loc_16, _loc_3.GetContainerName_string());
            this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[param1.GetDepositBuildingGridPos()].mDeposit = null;
            this.mGeneralInterface.mDataTracking.AddTrackingValue(cDataTracking.DATA_TRACKING_MINES_EMPTIED, 1);
            return INCREASE_RESOURCE_RESULT_OK;
        }// end function

        public function AssignSettlerGfx(param1:cResourceCreation) : void
        {
            var _loc_2:* = param1.GetResourceCreationHouse().GetGOContainer().mGfxResourceListName_string;
            var _loc_3:String = "Default_carries";
            var _loc_4:String = "Default";
            switch(_loc_2)
            {
                case "RealWoodCutter":
                case "ExoticWoodCutter":
                case "WoodCutter":
                {
                    _loc_3 = "Wood_carries";
                    _loc_4 = "Wood";
                    break;
                }
                case "Mason":
                case "MarbleMason":
                case "GraniteMason":
                {
                    _loc_3 = "Stone_carries";
                    _loc_4 = "Stone";
                    break;
                }
                case "Forester":
                {
                    _loc_3 = "Wood";
                    _loc_4 = "Wood";
                    break;
                }
                case "Fisher":
                {
                    _loc_3 = "Fish_carries";
                    _loc_4 = "Fish";
                    break;
                }
                case "Farm":
                {
                    _loc_3 = "Corn_carries";
                    _loc_4 = "Corn";
                    break;
                }
                case "Toolmaker":
                {
                    _loc_3 = "Tool_carries";
                    _loc_4 = "Tool";
                    break;
                }
                default:
                {
                    break;
                }
            }
            param1.settlerWithGoods = defines.SETTLER_DEFAULT_WORKER_string + _loc_3;
            param1.settlerWithoutGoods = defines.SETTLER_DEFAULT_WORKER_string + _loc_4;
            return;
        }// end function

        private function CalculateProductionPath(param1:cResourceCreation, param2:Boolean) : Boolean
        {
            if (this.mGeneralInterface.mLog.isTraceEnabled(LOG_TYPE.ECONOMY))
            {
                this.mGeneralInterface.mLog.logTrace(LOG_TYPE.ECONOMY, "CalculateProductionPath(" + param1 + ", " + param2 + ")");
            }
            var _loc_3:* = param1.GetResourceCreationHouse();
            if (param1.GetRemove() || _loc_3 == null)
            {
                return false;
            }
            if (param1.GetResourceCreationDefinition() != null && param1.GetResourceCreationDefinition().typeEnumResourceType == RESOURCE_TYPE.CREATED_ALWAYS)
            {
                return false;
            }
            var _loc_4:* = _loc_3.GetPlayerID();
            var _loc_5:* = this.mGeneralInterface.mPathFinder.CalculatePathForWarehouse(_loc_3.GetStreetGridEntry(), _loc_4);
            if (this.mGeneralInterface.mPathFinder.CalculatePathForWarehouse(_loc_3.GetStreetGridEntry(), _loc_4) == null || _loc_5.dest_vector.length < 1)
            {
                param1.SetStoreHouse(null);
                return false;
            }
            var _loc_6:* = (_loc_5.dest_vector[0] as dPathObjectItem).streetGridIdx;
            var _loc_7:* = gCalculations.MoveStreetGridToDir8(_loc_6, defines.DIR8_NORTH_WEST);
            var _loc_8:* = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_7].mBuilding as cBuilding;
            param1.SetStoreHouse(_loc_8);
            param1.SetPath(_loc_5);
            if (!param2)
            {
                param1.pathPos = 0;
            }
            if (param1.GetPath().dest_vector.length == 0)
            {
                gMisc.Assert(false, "Path to warehouse has length 0!");
                param1.SetStoreHouse(null);
                param1.SetPath(null);
            }
            return true;
        }// end function

        public function SpawnSettler(param1:cPlayerData, param2:cResourceCreation, param3:String) : Boolean
        {
            gMisc.Assert(param2 != null, "");
            if (param2.GetRemove() || param2.GetResourceCreationHouse() == null)
            {
                return false;
            }
            if (param2.GetStoreHouse() == null)
            {
                param2.SetPath(null);
            }
            this.mGeneralInterface.mCurrentPlayerZone.mSettlerKIManager.SpawnSettlerOnResourcePath(param1, param2, param3);
            return true;
        }// end function

        public function Init() : void
        {
            this.ResetResourceCreation();
            return;
        }// end function

        public function ErrorResetResourceCreation(param1:cResourceCreation) : void
        {
            var _loc_2:* = param1.GetResourceCreationHouse();
            if (_loc_2 == null)
            {
                if (this.mGeneralInterface.mLog.isWarnEnabled(LOG_TYPE.ECONOMY))
                {
                    this.mGeneralInterface.mLog.logWarn(LOG_TYPE.ECONOMY, "(681) [PlayerId]" + param1.GetPlayerID() + " ResetResourceCreation building is null! " + param1);
                }
                param1.SetRemove(true);
                return;
            }
            _loc_2.SetBuildingMode(cBuilding.BUILDING_MODE_SETTLER_WALKS_FROM_STOREHOUSE_TO_RESOURCECREATIONHOUSE);
            param1.SetSettlerKIState(cSettlerKI.SETTLER_STATE_WALKING_ON_RESOURCE_PATH);
            param1.SetProductionState(cResourceCreation.PRODUCTIONSTATE_WORKING);
            param1.SetDepositPath(new cPathObject());
            param1.pathPos = 0;
            param1.SetAssignedSettler(true);
            if (param1.GetSettler() != null)
            {
                param1.SetWorkingSettler();
            }
            return;
        }// end function

        private function PROTOKOLL_RESOURCE_CREATION_WRITE(param1:cResourceCreation, param2:int, param3:Number, param4:int, param5:String) : void
        {
            var _loc_6:dProductionProtocollVO = null;
            if (defines.PROTOKOLL_RESOURCE_CREATION_WRITE_TO_ARRAY)
            {
                if (param1.GetResourceCreationDefinition() != null)
                {
                    if (this.mResourceProcoll.length > 100)
                    {
                        this.mResourceProcoll.removeItemAt(0);
                    }
                    _loc_6 = new dProductionProtocollVO();
                    _loc_6.resourceName = param1.GetResourceCreationDefinition().defaultSetting.resourceName_string;
                    _loc_6.currentResourceNr = param2;
                    if (!param1.GetRemove() && param1.GetResourceCreationHouse() != null)
                    {
                        _loc_6.buildingGrid = param1.GetResourceCreationHouse().GetBuildingGrid();
                    }
                    else
                    {
                        _loc_6.buildingGrid = -1;
                    }
                    _loc_6.processCntr = param1.protocollResourceCreationProcessCntr;
                    _loc_6.lastBuildingMode = param1.protocollResourceCreationLastBuildingMode;
                    _loc_6.phase = param4;
                    _loc_6.text = param5;
                    _loc_6.currentTime = param3;
                    this.mResourceProcoll.addItem(_loc_6);
                    this.mGeneralInterface.mLog.logDebug(LOG_TYPE.ECONOMY, "***** " + _loc_6);
                }
            }
            else
            {
                this.mGeneralInterface.mLog.logDebug(LOG_TYPE.ECONOMY, "***** r: " + param2 + " p: " + param4 + " c: " + param3);
            }
            return;
        }// end function

        public function CreateResourceCreationFromResourceCreationVO(param1:dResourceCreationVO) : void
        {
            var _loc_4:dResourceCreationDefinition = null;
            var _loc_7:cPlayerData = null;
            var _loc_8:int = 0;
            var _loc_9:cPathObject = null;
            var _loc_10:int = 0;
            var _loc_11:dPathObjectItem = null;
            var _loc_12:cPosInt = null;
            var _loc_13:cPathObject = null;
            var _loc_14:cBuilding = null;
            if (this.mGeneralInterface.mLog.isTraceEnabled(LOG_TYPE.ECONOMY))
            {
                this.mGeneralInterface.mLog.logTrace(LOG_TYPE.ECONOMY, "CreateResourceCreationFromResourceCreationVO(" + param1 + ")");
            }
            var _loc_2:cBuilding = null;
            var _loc_3:* = this.mGeneralInterface.mCurrentPlayer;
            if (param1.playerId == cGeneralInterface.BUILDING_OWNERSHIP_PLAYER)
            {
                param1.playerId = _loc_3.GetPlayerId();
            }
            else if (_loc_3.GetPlayerId() != param1.playerId)
            {
                _loc_7 = this.mGeneralInterface.FindPlayerFromId(param1.playerId);
                if (_loc_7 != null)
                {
                    _loc_3 = _loc_7;
                }
                else
                {
                    param1.playerId = _loc_3.GetPlayerId();
                }
            }
            var _loc_5:* = param1.resourceDefinitionID;
            if (param1.resourceDefinitionID != -1)
            {
                _loc_4 = gEconomics.mResourceCreationDefinition_vector[_loc_5];
            }
            else
            {
                _loc_4 = null;
            }
            if (param1.resourceCreationHouseGrid > -1)
            {
                _loc_8 = param1.resourceCreationHouseGrid;
                _loc_2 = this.mGeneralInterface.mCurrentPlayerZone.GetBuildingFromGridPosition(_loc_8);
            }
            var _loc_6:* = new cResourceCreation(param1.playerId, _loc_4, _loc_2);
            new cResourceCreation(param1.playerId, _loc_4, _loc_2).protocollResourceCreationProcessCntr = param1.protocollResourceCreationProcessCntr;
            _loc_6.protocollResourceCreationLastBuildingMode = param1.protocollResourceCreationLastBuildingMode;
            _loc_6.SetAssignedSettler(param1.assignedSettler);
            _loc_6.SetGatheredResource(param1.gatheredResource);
            _loc_6.SetProductionState(param1.productionState);
            _loc_6.SetDepositBuildingGridPos(param1.depositBuildingGridPos);
            _loc_6.SetRemove(param1.remove);
            if (_loc_2 != null)
            {
                _loc_2.SetResourceCreation(_loc_6);
                this.AssignSettlerGfx(_loc_6);
                if (_loc_4 != null)
                {
                    if (_loc_4.externalResource_string != null && _loc_4.externalResource_string != "")
                    {
                        if (param1.pathVO != null)
                        {
                            _loc_9 = new cPathObject();
                            _loc_9.Reset();
                            for each (_loc_10 in param1.pathVO.mPath)
                            {
                                
                                _loc_11 = new dPathObjectItem();
                                _loc_11.streetGridIdx = _loc_10;
                                _loc_12 = new cPosInt();
                                gCalculations.ConvertStreetGridToPixelPos(_loc_10, _loc_12);
                                _loc_11.x = _loc_12.x;
                                _loc_11.y = _loc_12.y;
                                _loc_9.dest_vector.push(_loc_11);
                            }
                            _loc_9.RefreshLength();
                            _loc_6.SetDepositPath(_loc_9);
                        }
                        else if (param1.depositBuildingGridPos != -1)
                        {
                            if (this.mGeneralInterface.mLog.isInfoEnabled(LOG_TYPE.ECONOMY))
                            {
                                this.mGeneralInterface.mLog.logInfo(LOG_TYPE.ECONOMY, "mGeneralInterface.mPathFinder: " + this.mGeneralInterface.mPathFinder);
                                this.mGeneralInterface.mLog.logInfo(LOG_TYPE.ECONOMY, "resourceCreation: " + _loc_6);
                                this.mGeneralInterface.mLog.logInfo(LOG_TYPE.ECONOMY, "_resourceCreationVO: " + param1);
                                this.mGeneralInterface.mLog.logInfo(LOG_TYPE.ECONOMY, "playerData: " + _loc_3);
                            }
                            _loc_13 = this.mGeneralInterface.mPathFinder.CalculatePath(_loc_6.GetResourceCreationHouse().GetStreetGridEntry(), param1.depositBuildingGridPos, _loc_3.GetPlayerId(), true);
                            _loc_6.SetDepositPath(_loc_13);
                        }
                        else if (_loc_2.GetBuildingMode() != cBuilding.BUILDING_MODE_WORKANIM_IS_WORKING_AT_WORKYARD_EXTERNAL_WORKYARD_SYSTEM_ACTIVE)
                        {
                            if (this.mGeneralInterface.mLog.isInfoEnabled(LOG_TYPE.ECONOMY))
                            {
                                this.mGeneralInterface.mLog.logInfo(LOG_TYPE.ECONOMY, "No deposit found (" + _loc_4.externalResource_string + " for " + _loc_2.GetBuildingName_string() + ")");
                            }
                            this.ErrorResetResourceCreation(_loc_6);
                        }
                    }
                }
            }
            _loc_6.pathPos = param1.pathPos;
            this.mResourceCreation_vector.push(_loc_6);
            this.SpawnSettler(_loc_3, _loc_6, defines.SETTLER_BUILDER_string);
            _loc_6.SetSettlerKIState(param1.settlerKIState);
            if (_loc_6.GetAssignedSettler())
            {
                if (_loc_6.GetSettler() != null)
                {
                    _loc_14 = _loc_6.GetResourceCreationHouse();
                    if (_loc_14 != null)
                    {
                        switch(_loc_14.GetBuildingMode())
                        {
                            case cBuilding.BUILDING_MODE_SETTLER_WALKS_FROM_EXTERNAL_RESOURCE_TO_RESOURCECREATIONHOUSE:
                            {
                                _loc_6.SetWorkingSettlerCarries();
                                break;
                            }
                            default:
                            {
                                _loc_6.SetWorkingSettler();
                                break;
                            }
                        }
                    }
                }
            }
            _loc_6.mDirtyIndicator = DIRTY_INDICATOR.CLEAN;
            return;
        }// end function

    }
}
