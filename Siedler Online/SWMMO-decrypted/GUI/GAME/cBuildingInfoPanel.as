package GUI.GAME
{
    import BuffSystem.*;
    import Communication.VO.*;
    import Enums.*;
    import GO.*;
    import GUI.Assets.*;
    import GUI.Components.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import Interface.*;
    import ServerState.*;
    import SettlerKI.*;
    import flash.events.*;
    import mx.controls.*;
    import mx.events.*;

    public class cBuildingInfoPanel extends cBasicInfoPanel
    {
        protected var mBuilding:cBuilding;
        private var mCycleOverallTime:Number = 0;
        private var mOverallTime:Number = 0;
        private var mGI:cGameInterface;
        private const UPDATE_THRESHOLD:Number = 0.01;
        protected var mPanel:BuildingInfoPanel;
        private var mWayWarehouseToWorkyard:Number = 0;
        private var mPreviousProductionStatus:Number = 0;
        private var mProductionTime:Number = 0;
        private var mWayWorkyardToDeposit:Number = 0;

        public function cBuildingInfoPanel()
        {
            return;
        }// end function

        private function DisplayDetails() : void
        {
            var _loc_2:dResource = null;
            var _loc_3:dResource = null;
            var _loc_4:dResource = null;
            var _loc_5:ResourceItemRenderer = null;
            var _loc_6:ResourceIconRenderer = null;
            this.mPanel.cycleInputList.removeAllChildren();
            this.mPanel.way1.text = this.mWayWarehouseToWorkyard < 0 ? (cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "NotAvailable")) : (cLocaManager.GetInstance().FormatDuration(this.mWayWarehouseToWorkyard));
            this.mPanel.way2.text = this.mWayWorkyardToDeposit < 0 ? (cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "NotAvailable")) : (cLocaManager.GetInstance().FormatDuration(this.mWayWorkyardToDeposit));
            this.mPanel.way3.text = this.mWayWorkyardToDeposit < 0 ? (cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "NotAvailable")) : (cLocaManager.GetInstance().FormatDuration(this.mWayWorkyardToDeposit));
            this.mPanel.way4.text = this.mWayWarehouseToWorkyard < 0 ? (cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "NotAvailable")) : (cLocaManager.GetInstance().FormatDuration(this.mWayWarehouseToWorkyard));
            this.mPanel.productionTime.text = this.mProductionTime < 0 ? (cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "NotAvailable")) : (cLocaManager.GetInstance().FormatDuration(this.mProductionTime));
            this.mPanel.overallTime.text = this.mOverallTime < 0 ? (cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "NotAvailable")) : (cLocaManager.GetInstance().FormatDuration(this.mOverallTime));
            var _loc_1:* = gEconomics.GetResourcesCreationDefinitionForBuilding(this.mBuilding.GetBuildingName_string());
            if (!_loc_1)
            {
                return;
            }
            if (_loc_1.externalResource_string == "")
            {
                this.mPanel.arrowWay2.visible = false;
                this.mPanel.arrowWay3.visible = false;
                this.mPanel.labelWay2b.visible = false;
                this.mPanel.labelWay3b.visible = false;
                this.mPanel.labelWay2a.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "DetailsWay2Internal");
                this.mPanel.labelWay3a.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "DetailsWay3Internal");
            }
            else
            {
                this.mPanel.arrowWay2.visible = true;
                this.mPanel.arrowWay3.visible = true;
                this.mPanel.labelWay2b.visible = true;
                this.mPanel.labelWay3b.visible = true;
                this.mPanel.labelWay2a.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Workyard");
                this.mPanel.labelWay3a.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "DetailsDeposit");
            }
            if (_loc_1.amountRemoved > 0)
            {
                if (_loc_1.externalResource_string == "")
                {
                    for each (_loc_3 in _loc_1.necessaryResources_vector)
                    {
                        
                        _loc_4 = new dResource();
                        _loc_4.name_string = _loc_3.name_string;
                        _loc_4.amount = _loc_3.amount * this.mBuilding.GetResourceInputFactor();
                        _loc_5 = new ResourceItemRenderer();
                        _loc_5.data = _loc_4;
                        this.mPanel.cycleInputList.addChild(_loc_5);
                    }
                }
                else
                {
                    _loc_6 = new ResourceIconRenderer();
                    _loc_6.resourceName = "Deposit" + _loc_1.externalResource_string;
                    this.mPanel.cycleInputList.addChild(_loc_6);
                }
                _loc_2 = new dResource();
                _loc_2.name_string = _loc_1.defaultSetting.resourceName_string;
                _loc_2.amount = Math.abs(_loc_1.amountRemoved * this.mBuilding.GetResourceOutputFactor());
                this.mPanel.cycleOutput.data = _loc_2;
            }
            else
            {
                if (this.mBuilding.GetBuildingName_string().indexOf("Forester") > -1)
                {
                    _loc_6 = new ResourceIconRenderer();
                    _loc_6.resourceName = "Seed";
                    this.mPanel.cycleInputList.addChild(_loc_6);
                }
                _loc_2 = new dResource();
                _loc_2.name_string = "Deposit" + _loc_1.externalResource_string;
                _loc_2.amount = Math.abs(_loc_1.amountRemoved * this.mBuilding.GetResourceOutputFactor());
                this.mPanel.cycleOutput.data = _loc_2;
            }
            return;
        }// end function

        public function DisplayProductionState() : void
        {
            if (this.mBuilding.IsProductionActive())
            {
                this.mPanel.btnStartStop.setStyle("icon", gAssetManager.GetClass("ButtonIconStop"));
                this.mPanel.btnStartStop.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "StopProduction");
                this.mPanel.statusLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "StatusWorking");
                this.mPanel.statusLabel.setStyle("color", 16777215);
            }
            else
            {
                this.mPanel.btnStartStop.setStyle("icon", gAssetManager.GetClass("ButtonIconStart"));
                this.mPanel.btnStartStop.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "RestartProduction");
                this.mPanel.statusLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "StatusStopped");
                this.mPanel.statusLabel.setStyle("color", 16711680);
            }
            if (this.mBuilding.mWaitForCommand)
            {
                this.mPanel.btnStartStop.enabled = false;
                this.mPanel.statusLabel.text = "...";
            }
            else
            {
                this.mPanel.btnStartStop.enabled = true;
            }
            return;
        }// end function

        private function ToggleProductionState(event:MouseEvent) : void
        {
            this.mBuilding.SetProductionActiveCommand(!this.mBuilding.IsProductionActive());
            this.DisplayProductionState();
            return;
        }// end function

        private function MoveBuilding(event:Event) : void
        {
            this.mGI.mCurrentCursor.mCurrentBuilding = this.mBuilding;
            this.mGI.mCurrentCursor.SetCursorEditModeObjectName(COMMAND.MOVE_BUILDING, this.mBuilding.GetGOContainer().mGfxResourceListName_string);
            this.mGI.mCurrentCursor.SetCursor(this.mBuilding.GetLevelEnumObjectType(), this.mBuilding.GetGOContainer().mGfxResourceListName_string);
            this.mGI.mCurrentCursor.SetCursorGfxWithUpgradeLevel(this.mBuilding.GetLevelEnumObjectType(), this.mBuilding.GetGOContainer().mGfxResourceListName_string, this.mBuilding.GetUpgradeLevel());
            this.Hide();
            return;
        }// end function

        private function CalculateWays() : void
        {
            var _loc_1:* = this.mGI.mGlobalTimeScale;
            this.mWayWarehouseToWorkyard = 0;
            this.mWayWorkyardToDeposit = 0;
            this.mProductionTime = 0;
            this.mOverallTime = 0;
            if (this.mBuilding.GetResourceCreation() && this.mBuilding.GetResourceCreation().GetPath())
            {
                this.mWayWarehouseToWorkyard = this.mBuilding.GetResourceCreation().GetPath().pathLenX10000 / cComputeResourceCreation.SETTLER_WALK_SPEED_INT / _loc_1;
            }
            else
            {
                this.mWayWarehouseToWorkyard = -1;
            }
            if (this.mBuilding.GetResourceCreation() && this.mBuilding.GetResourceCreation().GetDepositPath())
            {
                this.mWayWorkyardToDeposit = this.mBuilding.GetResourceCreation().GetDepositPath().pathLenX10000 / cComputeResourceCreation.SETTLER_WALK_SPEED_INT / _loc_1;
            }
            else if (this.mBuilding.GetResourceCreation() && this.mBuilding.GetResourceCreation().GetPath() && this.mBuilding.GetResourceCreation().GetResourceCreationDefinition() && this.mBuilding.GetResourceCreation().GetResourceCreationDefinition().externalResource_string == "")
            {
                this.mWayWorkyardToDeposit = this.mWayWarehouseToWorkyard;
            }
            else
            {
                this.mWayWorkyardToDeposit = -1;
            }
            if (this.mBuilding.GetResourceCreation() != null && this.mBuilding.GetResourceCreation().GetResourceCreationDefinition() != null)
            {
                this.mProductionTime = this.mBuilding.GetResourceCreation().GetResourceCreationDefinition().workTime * 1000 / _loc_1;
            }
            else
            {
                this.mProductionTime = -1;
            }
            if (this.mWayWarehouseToWorkyard < 0 || this.mWayWorkyardToDeposit < 0 || this.mProductionTime < 0)
            {
                this.mOverallTime = -1;
            }
            else
            {
                this.mOverallTime = 2 * this.mWayWarehouseToWorkyard + 2 * this.mWayWorkyardToDeposit + this.mProductionTime;
            }
            return;
        }// end function

        override public function SetData(param1:cBuilding) : void
        {
            var _loc_4:dResource = null;
            var _loc_5:dResourceCreationDefinition = null;
            var _loc_6:cBuffDefinition = null;
            var _loc_7:ResourceItemRenderer = null;
            var _loc_8:cResources = null;
            var _loc_9:ResourceIconRenderer = null;
            var _loc_2:* = param1.GetContainerName_string();
            this.mBuilding = param1;
            this.mPanel.label = cLocaManager.GetInstance().GetText(LOCA_GROUP.BUILDINGS, _loc_2);
            this.mPanel.description.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, _loc_2);
            this.mPanel.image.source = gAssetManager.GetBuildingIcon(_loc_2);
            if (param1.GetUpgradeDuration() > 0)
            {
                this.mPanel.btnUpgrade.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "UpgradeWorkyard");
            }
            else
            {
                this.mPanel.btnUpgrade.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "NotPossible");
            }
            this.mPanel.btnUpgrade.enabled = param1.IsUpgradeAllowed(true);
            this.mPanel.btnInstantUpgrade.enabled = false;
            var _loc_3:Number = 0;
            if (this.mBuilding.mBuildingUpgradeIsInProgress)
            {
                _loc_6 = this.mBuilding.GetUpgradeLevelBonusesForLevel((this.mBuilding.GetUpgradeLevel() + 1));
                if (_loc_6 != null)
                {
                    _loc_3 = _loc_6.GetProductionTime() - (this.mGI.GetClientTime() - this.mBuilding.GetUpgradeStartTime());
                }
            }
            this.mPanel.btnKnockDown.enabled = param1.IsKnockdownAllowed();
            if (this.mBuilding.GetRecurringBuff() != null)
            {
                this.mPanel.payshopItemIndicator.visible = true;
                this.mPanel.btnKnockDown.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "KnockDownRecurring");
            }
            else
            {
                this.mPanel.payshopItemIndicator.visible = false;
                this.mPanel.btnKnockDown.toolTip = "KnockDown";
            }
            this.mPanel.levelLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Level", [param1.GetUpgradeLevel().toString()]);
            this.mPanel.upgradeTime.text = cLocaManager.GetInstance().FormatDuration(param1.GetUpgradeDuration());
            this.mPanel.upgradeTime.visible = param1.GetUpgradeDuration() > 0;
            this.mPanel.integrity.value = param1.GetHealthBar();
            this.mPanel.btnRepair.enabled = param1.GetRepairCosts().length > 0;
            this.mPanel.costsList.removeAllChildren();
            for each (_loc_4 in param1.GetUpgradeCosts_vector())
            {
                
                _loc_7 = new ResourceItemRenderer();
                _loc_7.data = _loc_4;
                this.mPanel.costsList.addChild(_loc_7);
            }
            this.mPanel.inputList.removeAllChildren();
            this.mPanel.outputIcon.clear();
            _loc_5 = gEconomics.GetResourcesCreationDefinitionForBuilding(_loc_2);
            if (_loc_5)
            {
                if (_loc_5.amountRemoved > 0)
                {
                    this.mPanel.outputIcon.resourceName = _loc_5.defaultSetting.resourceName_string;
                    if (this.mBuilding.mBuffs_vector.length > 0)
                    {
                        this.mPanel.outputIcon.buffed = (this.mBuilding.mBuffs_vector[0] as BuffAppliance).GetBuffDefinition().getProductivityOutputPercent() < 100 ? (ResourceIconRenderer.BUFFED_NEGATIVE) : (ResourceIconRenderer.BUFFED_POSITIVE);
                    }
                    else
                    {
                        this.mPanel.outputIcon.buffed = ResourceIconRenderer.BUFFED_NONE;
                    }
                    if (_loc_5.externalResource_string == "")
                    {
                        _loc_8 = this.mGI.mCurrentPlayerZone.GetResources(this.mGI.mCurrentPlayer);
                        for each (_loc_4 in _loc_5.necessaryResources_vector)
                        {
                            
                            _loc_9 = new ResourceIconRenderer();
                            _loc_9.missing = this.mBuilding.IsBuildingInfoIconDelayPassed() && this.mBuilding.GetResourceCreation().GetProductionState() == cResourceCreation.PRODUCTIONSTATE_ERROR_NECESSARY_RESOURCE_MISSING && !_loc_8.HasPlayerResource(_loc_4.name_string, _loc_4.amount * this.mBuilding.GetResourceInputFactor());
                            _loc_9.resourceName = _loc_4.name_string;
                            this.mPanel.inputList.addChild(_loc_9);
                        }
                    }
                    else
                    {
                        _loc_9 = new ResourceIconRenderer();
                        _loc_9.missing = this.mBuilding.IsBuildingInfoIconDelayPassed() && this.mBuilding.GetResourceCreation().GetProductionState() == cResourceCreation.PRODUCTIONSTATE_ERROR_NECESSARY_RESOURCE_MISSING;
                        _loc_9.resourceName = "Deposit" + _loc_5.externalResource_string;
                        this.mPanel.inputList.addChild(_loc_9);
                    }
                }
                else
                {
                    this.mPanel.outputIcon.resourceName = "Deposit" + _loc_5.externalResource_string;
                    if (this.mBuilding.mBuffs_vector.length > 0)
                    {
                        this.mPanel.outputIcon.buffed = (this.mBuilding.mBuffs_vector[0] as BuffAppliance).GetBuffDefinition().getProductivityOutputPercent() < 100 ? (ResourceIconRenderer.BUFFED_NEGATIVE) : (ResourceIconRenderer.BUFFED_POSITIVE);
                    }
                    else
                    {
                        this.mPanel.outputIcon.buffed = ResourceIconRenderer.BUFFED_NONE;
                    }
                    if (this.mBuilding.GetBuildingName_string().indexOf("Forester") > -1 || this.mBuilding.GetBuildingName_string().indexOf("silo") > -1)
                    {
                        _loc_9 = new ResourceIconRenderer();
                        _loc_9.resourceName = "Seed";
                        this.mPanel.inputList.addChild(_loc_9);
                    }
                }
            }
            this.mPanel.addEventListener(Event.ENTER_FRAME, this.UpdateProductionProgress);
            this.mPanel.productionCycleStatus.addEventListener(ToolTipEvent.TOOL_TIP_CREATE, this.createProductionTooltipHandler);
            if (this.mBuilding.GetResourceCreation())
            {
                this.mPanel.workerIcon.active = true;
                this.mPanel.workerIcon.missing = !this.mBuilding.GetResourceCreation().GetAssignedSettler();
            }
            else
            {
                this.mPanel.workerIcon.active = false;
            }
            this.DisplayProductionState();
            this.CalculateWays();
            this.DisplayDetails();
            return;
        }// end function

        private function RepairBuilding(event:Event) : void
        {
            this.mBuilding.SetRecoveringHitPoints(global.repairRate);
            this.Hide();
            return;
        }// end function

        private function ClosePanel(event:Event) : void
        {
            this.Hide();
            return;
        }// end function

        private function AddHardCurrencyHandler(event:CloseEvent) : void
        {
            if (event.detail == Alert.OK)
            {
                globalFlash.gui.mShopWindow.AddHardCurrency(null);
            }
            return;
        }// end function

        private function UpdateProductionProgress(event:Event) : void
        {
            var _loc_5:dResourceCreationDefinition = null;
            var _loc_6:Number = NaN;
            var _loc_2:Number = -1;
            var _loc_3:* = this.mBuilding.GetResourceCreation();
            if (_loc_3 != null)
            {
                if (!this.mBuilding.IsInConstructionMode())
                {
                    _loc_5 = _loc_3.GetResourceCreationDefinition();
                    if (_loc_5 != null)
                    {
                        this.mCycleOverallTime = 0;
                        if (_loc_5.externalResource_string != "")
                        {
                            if (_loc_3.GetDepositPath() != null)
                            {
                                this.mCycleOverallTime = this.mCycleOverallTime + _loc_3.GetPath().pathLenX10000 / cComputeResourceCreation.SETTLER_WALK_SPEED_INT;
                                this.mCycleOverallTime = this.mCycleOverallTime + _loc_3.GetDepositPath().pathLenX10000 / cComputeResourceCreation.SETTLER_WALK_SPEED_INT;
                                this.mCycleOverallTime = this.mCycleOverallTime + _loc_3.GetResourceCreationDefinition().workTime * 1000;
                                this.mCycleOverallTime = this.mCycleOverallTime + _loc_3.GetDepositPath().pathLenX10000 / cComputeResourceCreation.SETTLER_WALK_SPEED_INT;
                                this.mCycleOverallTime = this.mCycleOverallTime + _loc_3.GetPath().pathLenX10000 / cComputeResourceCreation.SETTLER_WALK_SPEED_INT;
                                switch(this.mBuilding.GetBuildingMode())
                                {
                                    case cBuilding.BUILDING_MODE_SETTLER_WALKS_FROM_STOREHOUSE_TO_RESOURCECREATIONHOUSE:
                                    {
                                        _loc_2 = _loc_3.pathPos / cComputeResourceCreation.SETTLER_WALK_SPEED_INT;
                                        break;
                                    }
                                    case cBuilding.BUILDING_MODE_WORKANIM_IS_WORKING_AT_WORKYARD_EXTERNAL_WORKYARD_SYSTEM_ACTIVE:
                                    {
                                        _loc_2 = _loc_3.GetPath().pathLenX10000 / cComputeResourceCreation.SETTLER_WALK_SPEED_INT;
                                        break;
                                    }
                                    case cBuilding.BUILDING_MODE_SETTLER_WALKS_FROM_RESOURCECREATIONHOUSE_TO_EXTERNAL_RESOURCE:
                                    {
                                        _loc_2 = _loc_3.GetPath().pathLenX10000 / cComputeResourceCreation.SETTLER_WALK_SPEED_INT;
                                        _loc_2 = _loc_2 + _loc_3.pathPos / cComputeResourceCreation.SETTLER_WALK_SPEED_INT;
                                        break;
                                    }
                                    case cBuilding.BUILDING_MODE_WORKANIM_IS_WORKING_AT_EXTERNAL_DEPOSIT:
                                    {
                                        _loc_2 = _loc_3.GetPath().pathLenX10000 / cComputeResourceCreation.SETTLER_WALK_SPEED_INT;
                                        _loc_2 = _loc_2 + _loc_3.GetDepositPath().pathLenX10000 / cComputeResourceCreation.SETTLER_WALK_SPEED_INT;
                                        _loc_2 = _loc_2 + (_loc_3.GetResourceCreationDefinition().workTime * 1000 - this.mBuilding.mStartWorkCounter);
                                        break;
                                    }
                                    case cBuilding.BUILDING_MODE_SETTLER_WALKS_FROM_EXTERNAL_RESOURCE_TO_RESOURCECREATIONHOUSE:
                                    {
                                        _loc_2 = _loc_3.GetPath().pathLenX10000 / cComputeResourceCreation.SETTLER_WALK_SPEED_INT;
                                        _loc_2 = _loc_2 + _loc_3.GetDepositPath().pathLenX10000 / cComputeResourceCreation.SETTLER_WALK_SPEED_INT;
                                        _loc_2 = _loc_2 + _loc_3.GetResourceCreationDefinition().workTime * 1000;
                                        _loc_2 = _loc_2 + (_loc_3.pathPos - _loc_3.GetDepositPath().pathLenX10000) / cComputeResourceCreation.SETTLER_WALK_SPEED_INT;
                                        break;
                                    }
                                    case cBuilding.BUILDING_MODE_SETTLER_WALKS_FROM_RESOURCECREATIONHOUSE_TO_STOREHOUSE:
                                    {
                                        _loc_2 = _loc_3.GetPath().pathLenX10000 / cComputeResourceCreation.SETTLER_WALK_SPEED_INT;
                                        _loc_2 = _loc_2 + _loc_3.GetDepositPath().pathLenX10000 / cComputeResourceCreation.SETTLER_WALK_SPEED_INT;
                                        _loc_2 = _loc_2 + _loc_3.GetResourceCreationDefinition().workTime * 1000;
                                        _loc_2 = _loc_2 + _loc_3.GetDepositPath().pathLenX10000 / cComputeResourceCreation.SETTLER_WALK_SPEED_INT;
                                        _loc_2 = _loc_2 + (_loc_3.pathPos - _loc_3.GetPath().pathLenX10000) / cComputeResourceCreation.SETTLER_WALK_SPEED_INT;
                                        break;
                                    }
                                    default:
                                    {
                                        _loc_2 = -1;
                                        break;
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            this.mCycleOverallTime = this.mCycleOverallTime + _loc_3.GetPath().pathLenX10000 / cComputeResourceCreation.SETTLER_WALK_SPEED_INT;
                            this.mCycleOverallTime = this.mCycleOverallTime + _loc_3.GetPath().pathLenX10000 / cComputeResourceCreation.SETTLER_WALK_SPEED_INT;
                            this.mCycleOverallTime = this.mCycleOverallTime + _loc_3.GetResourceCreationDefinition().workTime * 1000;
                            this.mCycleOverallTime = this.mCycleOverallTime + _loc_3.GetPath().pathLenX10000 / cComputeResourceCreation.SETTLER_WALK_SPEED_INT;
                            this.mCycleOverallTime = this.mCycleOverallTime + _loc_3.GetPath().pathLenX10000 / cComputeResourceCreation.SETTLER_WALK_SPEED_INT;
                            switch(this.mBuilding.GetBuildingMode())
                            {
                                case cBuilding.BUILDING_MODE_SETTLER_WALKS_FROM_STOREHOUSE_TO_RESOURCECREATIONHOUSE:
                                {
                                    _loc_2 = _loc_3.pathPos / cComputeResourceCreation.SETTLER_WALK_SPEED_INT;
                                    break;
                                }
                                case cBuilding.BUILDING_MODE_WORKANIM_IS_WORKING_AT_WORKYARD_LOCAL_WORKYARD_SYSTEM:
                                {
                                    _loc_2 = _loc_3.GetPath().pathLenX10000 / cComputeResourceCreation.SETTLER_WALK_SPEED_INT;
                                    _loc_2 = _loc_2 + (_loc_3.GetPath().pathLenX20000 / cComputeResourceCreation.SETTLER_WALK_SPEED_INT + _loc_5.workTime * 1000 - this.mBuilding.mStartWorkCounter);
                                    break;
                                }
                                case cBuilding.BUILDING_MODE_SETTLER_WALKS_FROM_RESOURCECREATIONHOUSE_TO_STOREHOUSE:
                                {
                                    _loc_2 = _loc_3.GetPath().pathLenX10000 / cComputeResourceCreation.SETTLER_WALK_SPEED_INT;
                                    _loc_2 = _loc_2 + (_loc_3.GetPath().pathLenX20000 / cComputeResourceCreation.SETTLER_WALK_SPEED_INT + _loc_5.workTime * 1000);
                                    _loc_2 = _loc_2 + (_loc_3.pathPos - _loc_3.GetPath().pathLenX10000) / cComputeResourceCreation.SETTLER_WALK_SPEED_INT;
                                    break;
                                }
                                default:
                                {
                                    _loc_2 = -1;
                                    break;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if (_loc_3 == null || _loc_2 == -1 || this.mCycleOverallTime == 0 || !this.mBuilding.IsProductionActive() || _loc_3.GetProductionState() != cResourceCreation.PRODUCTIONSTATE_WORKING || !_loc_3.GetAssignedSettler() || _loc_3.GetSettlerKIState() == cSettlerKI.SETTLER_STATE_WAITS_BECAUSE_WAREHOUSE_IS_FULL || _loc_3.GetSettlerKIState() == cSettlerKI.SETTLER_STATE_WAITS_FOR_POPULATION)
            {
                this.mPanel.productionCycleStatus.visible = false;
                return;
            }
            var _loc_4:* = _loc_2 / this.mCycleOverallTime;
            if (_loc_2 / this.mCycleOverallTime < 0)
            {
                _loc_4 = 0;
            }
            if (_loc_4 > 1)
            {
                _loc_4 = 1;
            }
            if (Math.abs(_loc_4 - this.mPanel.productionCycleStatus.value) > this.UPDATE_THRESHOLD)
            {
                this.mPanel.productionCycleStatus.value = _loc_4;
            }
            this.mPanel.productionCycleStatus.visible = true;
            return;
        }// end function

        private function ConfirmRemoveBuilding(event:Event) : void
        {
            var _loc_2:* = CustomAlert.show("ConfirmTeardown", "ConfirmTeardown", Alert.CANCEL | Alert.OK, this.mPanel, this.RemoveBuilding);
            _loc_2.addEventListener(CloseEvent.CLOSE, this.RemoveBuilding);
            return;
        }// end function

        override public function Show() : void
        {
            this.mPanel.detailsStack.selectedIndex = 0;
            this.mPanel.buttonBar.selectedIndex = 0;
            super.Show();
            return;
        }// end function

        private function UpgradeBuilding(event:Event) : void
        {
            this.mGI.mCurrentPlayerZone.UpgradeBuildingOnGridPosition(this.mBuilding.GetBuildingGrid());
            this.Hide();
            return;
        }// end function

        private function InstantBuffBuilding(event:Event) : void
        {
            this.Hide();
            return;
        }// end function

        override public function Hide() : void
        {
            this.mPanel.removeEventListener(Event.ENTER_FRAME, this.UpdateProductionProgress);
            super.Hide();
            return;
        }// end function

        private function CreateKnockDownToolTip(event:ToolTipEvent) : void
        {
            if (this.mBuilding.GetRecurringBuff() != null)
            {
                cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            }
            else
            {
                cToolTipUtil.createToolTip(cToolTipUtil.DEMOLISH_BUILDING_string, event, this.mBuilding);
            }
            return;
        }// end function

        public function Init(param1:BuildingInfoPanel) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            this.mPanel.buttonBar.dataProvider = [cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Overview"), cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Details")];
            this.mPanel.btnClose.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            this.mPanel.btnKnockDown.addEventListener(MouseEvent.CLICK, this.ConfirmRemoveBuilding);
            this.mPanel.btnUpgrade.addEventListener(MouseEvent.CLICK, this.UpgradeBuilding);
            this.mPanel.btnInstantUpgrade.addEventListener(MouseEvent.CLICK, this.InstantUpgradeBuilding);
            this.mPanel.btnInstantBuff.addEventListener(MouseEvent.CLICK, this.InstantBuffBuilding);
            this.mPanel.btnRepair.addEventListener(MouseEvent.CLICK, this.RepairBuilding);
            this.mPanel.btnKnockDown.addEventListener(ToolTipEvent.TOOL_TIP_CREATE, this.CreateKnockDownToolTip);
            this.mPanel.btnStartStop.addEventListener(MouseEvent.CLICK, this.ToggleProductionState);
            return;
        }// end function

        private function RemoveBuilding(event:CloseEvent) : void
        {
            if (event.detail != Alert.OK)
            {
                return;
            }
            this.mGI.mCurrentPlayerZone.SendDestructBuildingCommand(this.mBuilding.GetBuildingGrid());
            this.Hide();
            return;
        }// end function

        public function Refresh() : void
        {
            if (this.mBuilding)
            {
                this.SetData(this.mBuilding);
            }
            return;
        }// end function

        private function createProductionTooltipHandler(event:ToolTipEvent) : void
        {
            var _loc_2:* = this.mCycleOverallTime * (1 - this.mPanel.productionCycleStatus.value) / this.mGI.mGlobalTimeScale;
            cToolTipUtil.createToolTip(cToolTipUtil.PRODUCTION_DURATION, event, _loc_2);
            return;
        }// end function

        private function InstantUpgradeBuilding(event:Event) : void
        {
            var _loc_2:* = this.mGI.mCurrentPlayerZone.GetResources(this.mGI.mCurrentPlayer);
            if (_loc_2.HasPlayerResource(defines.HARD_CURRENCY_RESOURCE_NAME_string, this.mBuilding.GetBuildInstantCosts()))
            {
                global.ui.mClientMessages.SendMessagetoServer(COMMAND.BUY_ONE_CLICK_SHOP_ITEM, this.mGI.mCurrentViewedZoneID, new dBuyOneClickShopItemVO().InitWithBuildingGrid(8004, this.mBuilding.GetBuildingGrid()));
            }
            else
            {
                CustomAlert.show("MissingHardCurrency", "", Alert.OK | Alert.CANCEL, null, this.AddHardCurrencyHandler, null, Alert.OK, true, CustomAlert.STYLE_PAYMENT);
            }
            this.Hide();
            return;
        }// end function

        private function CreateMovementToolTip(event:ToolTipEvent) : void
        {
            if (this.mBuilding.GetMovementCosts_vector() == null)
            {
                cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            }
            else
            {
                cToolTipUtil.createToolTip(cToolTipUtil.MOVE_BUILDING_string, event, this.mBuilding.GetMovementCosts_vector());
            }
            return;
        }// end function

    }
}
