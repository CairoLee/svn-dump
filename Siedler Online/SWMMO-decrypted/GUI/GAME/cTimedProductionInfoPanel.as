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
    import MilitarySystem.*;
    import ServerState.*;
    import TimedProduction.*;
    import __AS3__.vec.*;
    import flash.events.*;
    import mx.collections.*;
    import mx.controls.*;
    import mx.events.*;
    import nLib.*;

    public class cTimedProductionInfoPanel extends cBasicInfoPanel
    {
        protected var mBuilding:cBuilding;
        private var mSelectedTabIndex:int = 0;
        protected var mUpgradeTooltip:String;
        private var mGI:cGameInterface;
        protected var mPanel:TimedProductionInfoPanel;
        protected var mProductionType:int;
        private var mSelectedOrderType:iTimedProductionDefinition;
        public static const MOVE_DOWN:String = "ProductionMoveDown";
        public static const REMOVE:String = "ProductionRemove";
        public static const MOVE_UP:String = "ProductionMoveUp";
        public static const HALF_TIME:String = "ProductionHalfTime";

        public function cTimedProductionInfoPanel()
        {
            return;
        }// end function

        private function EnterManageOrderState(event:FlexEvent) : void
        {
            this.mPanel.selectedUnitIcon.source = gAssetManager.GetResourceIcon(this.mSelectedOrderType.GetType_string());
            this.mPanel.selectedUnitName.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, this.mSelectedOrderType.GetType_string());
            if (this.mSelectedOrderType is cBuffDefinition)
            {
                this.mPanel.selectedUnitDescription.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, this.mSelectedOrderType.GetType_string(), [(this.mSelectedOrderType as cBuffDefinition).GetAmount().toString(), (this.mSelectedOrderType as cBuffDefinition).GetResourceName_string()]);
            }
            else
            {
                this.mPanel.selectedUnitDescription.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, this.mSelectedOrderType.GetType_string());
            }
            this.mPanel.amountSlider.enabled = true;
            this.mPanel.amountSlider.value = 1;
            this.mPanel.amountSlider.maximum = defines.MAX_PRODUCTION_AMOUNT;
            this.mPanel.btnOK.addEventListener(MouseEvent.CLICK, this.Order);
            this.mPanel.amountSlider.addEventListener(SliderEvent.CHANGE, this.CalculateCosts);
            this.CalculateCosts();
            return;
        }// end function

        private function RepairBuilding(event:Event) : void
        {
            this.mBuilding.SetRecoveringHitPoints(global.repairRate);
            this.Hide();
            return;
        }// end function

        override public function SetData(param1:cBuilding) : void
        {
            var _loc_3:dResource = null;
            var _loc_4:Vector.<cTimedProduction> = null;
            var _loc_5:Array = null;
            var _loc_6:cTimedProduction = null;
            var _loc_7:ResourceItemRenderer = null;
            var _loc_8:Array = null;
            var _loc_9:Array = null;
            var _loc_10:cBuffDefinition = null;
            var _loc_2:* = param1.GetContainerName_string();
            this.mBuilding = param1;
            switch(this.mBuilding.GetBuildingName_string())
            {
                case defines.BARRACKS_NAME_string:
                {
                    this.mProductionType = TIMED_PRODUCTION_TYPE.MILITARY_UNIT;
                    this.mUpgradeTooltip = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "UpgradeBarracks");
                    break;
                }
                case defines.PROVISIONHOUSE_NAME_string:
                {
                    this.mProductionType = TIMED_PRODUCTION_TYPE.BUFF;
                    this.mUpgradeTooltip = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "UpgradeProvisionhouse");
                    break;
                }
                default:
                {
                    gMisc.Assert(false, "Could not create production type for " + this.mBuilding);
                    break;
                    break;
                }
            }
            this.mPanel.label = cLocaManager.GetInstance().GetText(LOCA_GROUP.BUILDINGS, _loc_2);
            this.mPanel.description.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, _loc_2);
            this.mPanel.image.source = gAssetManager.GetBuildingIcon(_loc_2);
            if (param1.GetUpgradeDuration() > 0)
            {
                this.mPanel.btnUpgrade.toolTip = this.mUpgradeTooltip;
            }
            else
            {
                this.mPanel.btnUpgrade.toolTip = "NotPossible";
            }
            this.mPanel.btnUpgrade.enabled = param1.IsUpgradeAllowed(true);
            this.mPanel.btnInstantUpgrade.enabled = false;
            this.mPanel.btnKnockDown.enabled = param1.IsKnockdownAllowed();
            if (this.mBuilding.GetRecurringBuff() != null)
            {
                this.mPanel.btnKnockDown.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "KnockDownRecurring");
            }
            else
            {
                this.mPanel.btnKnockDown.toolTip = "KnockDown";
            }
            this.mPanel.levelLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Level", [param1.GetUpgradeLevel().toString()]);
            this.mPanel.upgradeTime.text = cLocaManager.GetInstance().FormatDuration(param1.GetUpgradeDuration());
            this.mPanel.upgradeTime.visible = param1.GetUpgradeDuration() > 0;
            this.mPanel.integrity.value = param1.GetHealthBar();
            this.mPanel.btnRepair.enabled = param1.GetRepairCosts().length > 0;
            this.mPanel.costsList.removeAllChildren();
            for each (_loc_3 in param1.GetUpgradeCosts_vector())
            {
                
                _loc_7 = new ResourceItemRenderer();
                _loc_7.data = _loc_3;
                this.mPanel.costsList.addChild(_loc_7);
            }
            _loc_5 = [];
            switch(this.mProductionType)
            {
                case TIMED_PRODUCTION_TYPE.BUFF:
                {
                    _loc_8 = [];
                    _loc_9 = [];
                    for each (_loc_10 in cBuff.GetAllBuffDefinitions())
                    {
                        
                        if (_loc_8.indexOf(_loc_10.GetGroup_string()) == -1)
                        {
                            _loc_8.push(_loc_10.GetGroup_string());
                            _loc_9.push({label:cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "BuffGroup" + _loc_10.GetGroup_string()), group:_loc_10.GetGroup_string()});
                        }
                    }
                    if (_loc_9.length > 1)
                    {
                        this.mPanel.buttonBar.dataProvider = _loc_9;
                        this.mPanel.buttonBar.selectedIndex = this.mSelectedTabIndex;
                        if (this.mSelectedTabIndex == 0)
                        {
                            this.SetFilteredReciepeList();
                        }
                    }
                    else
                    {
                        this.mPanel.buttonBar.dataProvider = null;
                        this.mPanel.availableOrdersList.dataProvider = cBuff.GetAllBuffDefinitions();
                    }
                    _loc_4 = this.mGI.mCurrentPlayerZone.GetBuffProductionQueue().mTimedProductions_vector;
                    for each (_loc_6 in _loc_4)
                    {
                        
                        _loc_5.push(_loc_6);
                    }
                    this.mPanel.busy = this.mGI.mCurrentPlayerZone.GetBuffProductionQueue().GetWaitingForServer();
                    break;
                }
                case TIMED_PRODUCTION_TYPE.MILITARY_UNIT:
                {
                    this.mPanel.buttonBar.dataProvider = null;
                    this.mPanel.availableOrdersList.dataProvider = cMilitaryUnitDescription.GetAllUnitDescriptions(true);
                    _loc_4 = this.mGI.mCurrentPlayerZone.GetMilitaryUnitRecruitments().mTimedProductions_vector;
                    for each (_loc_6 in _loc_4)
                    {
                        
                        _loc_5.push(_loc_6);
                    }
                    this.mPanel.busy = this.mGI.mCurrentPlayerZone.GetMilitaryUnitRecruitments().GetWaitingForServer();
                    break;
                }
                default:
                {
                    break;
                }
            }
            this.mPanel.currentOrdersList.dataProvider = _loc_5;
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

        private function UpgradeBuilding(event:Event) : void
        {
            this.mGI.mCurrentPlayerZone.UpgradeBuildingOnGridPosition(this.mBuilding.GetBuildingGrid());
            this.Hide();
            return;
        }// end function

        private function ClosePanel(event:Event) : void
        {
            this.Hide();
            return;
        }// end function

        private function ConfirmRemoveBuilding(event:Event) : void
        {
            var _loc_2:* = CustomAlert.show("ConfirmTeardown", "ConfirmTeardown", Alert.CANCEL | Alert.OK, this.mPanel, this.RemoveBuilding);
            _loc_2.addEventListener(CloseEvent.CLOSE, this.RemoveBuilding);
            return;
        }// end function

        private function ProductionHalfTime(event:ListEvent) : void
        {
            var _loc_2:* = this.mGI.mCurrentPlayer;
            var _loc_3:cTimedProduction = null;
            var _loc_4:int = 0;
            if (this.mProductionType == TIMED_PRODUCTION_TYPE.MILITARY_UNIT)
            {
                _loc_3 = this.mGI.mCurrentPlayerZone.GetMilitaryUnitRecruitments().mTimedProductions_vector[0];
                _loc_4 = 8003;
            }
            else if (this.mProductionType == TIMED_PRODUCTION_TYPE.BUFF)
            {
                _loc_3 = this.mGI.mCurrentPlayerZone.GetBuffProductionQueue().mTimedProductions_vector[0];
                _loc_4 = 8002;
            }
            else
            {
                gMisc.Assert(false, "Could not interpret production type " + this.mProductionType);
            }
            var _loc_5:* = this.mGI.mCurrentPlayerZone.GetResources(_loc_2);
            if (this.mGI.mCurrentPlayerZone.GetResources(_loc_2).HasPlayerResource(defines.HARD_CURRENCY_RESOURCE_NAME_string, _loc_3.GetInstantBuildCosts()))
            {
                _loc_3.SetWaitingForServer(true);
                global.ui.mClientMessages.SendMessagetoServer(COMMAND.BUY_ONE_CLICK_SHOP_ITEM, this.mGI.mCurrentViewedZoneID, new dBuyOneClickShopItemVO().InitWithBuildingGrid(_loc_4, this.mBuilding.GetBuildingGrid()));
            }
            else
            {
                CustomAlert.show("MissingHardCurrency", "", Alert.OK | Alert.CANCEL, null, this.AddHardCurrencyHandler, null, Alert.OK, true, CustomAlert.STYLE_PAYMENT);
            }
            return;
        }// end function

        override public function Show() : void
        {
            this.mPanel.currentState = "";
            super.Show();
            return;
        }// end function

        override public function Hide() : void
        {
            this.mSelectedTabIndex = 0;
            super.Hide();
            return;
        }// end function

        private function SetFilteredReciepeList(event:ItemClickEvent = null) : void
        {
            var _loc_4:cBuffDefinition = null;
            var _loc_2:Array = [];
            if (event)
            {
                this.mSelectedTabIndex = event.index;
            }
            trace("### SetFilteredReciepeList() - mSelectedTabIndex: " + this.mSelectedTabIndex);
            var _loc_3:* = (this.mPanel.buttonBar.dataProvider as ArrayCollection).getItemAt(this.mSelectedTabIndex).group.toString();
            for each (_loc_4 in cBuff.GetAllBuffDefinitions())
            {
                
                if (_loc_4.GetGroup_string() == _loc_3)
                {
                    _loc_2.push(_loc_4);
                }
            }
            this.mPanel.availableOrdersList.dataProvider = _loc_2;
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

        private function SelectOrderType(event:ListEvent) : void
        {
            var _loc_2:* = this.mGI.mCurrentPlayer;
            var _loc_3:* = this.mPanel.availableOrdersList.selectedItem as iTimedProductionDefinition;
            if (_loc_3 == null)
            {
                return;
            }
            if (_loc_3.GetPlayerLevel() > _loc_2.GetPlayerLevel())
            {
                return;
            }
            this.mSelectedOrderType = this.mPanel.availableOrdersList.selectedItem as iTimedProductionDefinition;
            this.mPanel.currentState = "manageOrders";
            return;
        }// end function

        private function CalculateCosts(event:SliderEvent = null) : void
        {
            var _loc_5:dResource = null;
            var _loc_6:cResources = null;
            var _loc_7:Boolean = false;
            if (!this.mSelectedOrderType)
            {
                return;
            }
            this.mPanel.btnOK.enabled = true;
            var _loc_2:* = this.mGI.mCurrentPlayer;
            var _loc_3:* = this.mSelectedOrderType.GetCosts_vector();
            var _loc_4:Array = [];
            for each (_loc_5 in _loc_3)
            {
                
                _loc_6 = this.mGI.mCurrentPlayerZone.GetResources(_loc_2);
                if (_loc_5.name_string == defines.POPULATION_RESOURCE_NAME_string)
                {
                    _loc_7 = _loc_6.GetNumberOfUnassignedPopulation() >= this.mPanel.amountSlider.value * _loc_5.amount;
                }
                else
                {
                    _loc_7 = _loc_6.HasPlayerResource(_loc_5.name_string, this.mPanel.amountSlider.value * _loc_5.amount);
                }
                _loc_4.push({amount:this.mPanel.amountSlider.value, resource:_loc_5, canAfford:_loc_7});
                if (!_loc_7)
                {
                    this.mPanel.btnOK.enabled = false;
                }
            }
            this.mPanel.orderCostsList.dataProvider = _loc_4;
            return;
        }// end function

        public function Init(param1:TimedProductionInfoPanel) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            this.mPanel.btnClose.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            this.mPanel.btnKnockDown.addEventListener(MouseEvent.CLICK, this.ConfirmRemoveBuilding);
            this.mPanel.btnUpgrade.addEventListener(MouseEvent.CLICK, this.UpgradeBuilding);
            this.mPanel.btnInstantUpgrade.addEventListener(MouseEvent.CLICK, this.InstantUpgradeBuilding);
            this.mPanel.btnKnockDown.addEventListener(ToolTipEvent.TOOL_TIP_CREATE, this.CreateKnockDownToolTip);
            this.mPanel.btnRepair.addEventListener(MouseEvent.CLICK, this.RepairBuilding);
            this.mPanel.stateManageOrders.addEventListener(FlexEvent.ENTER_STATE, this.EnterManageOrderState);
            this.mPanel.currentOrdersList.addEventListener(cTimedProductionInfoPanel.REMOVE, this.ProductionRemove);
            this.mPanel.currentOrdersList.addEventListener(cTimedProductionInfoPanel.HALF_TIME, this.ProductionHalfTime);
            this.mPanel.availableOrdersList.addEventListener(ListEvent.ITEM_CLICK, this.SelectOrderType);
            this.mPanel.buttonBar.addEventListener(ListEvent.ITEM_CLICK, this.SetFilteredReciepeList);
            return;
        }// end function

        private function Order(event:MouseEvent) : void
        {
            var _loc_2:iProductionOrder = null;
            var _loc_3:cTimedProduction = null;
            var _loc_5:cTimedProductionQueue = null;
            var _loc_4:* = new dStartTimedProductionVO();
            new dStartTimedProductionVO().productionType = this.mProductionType;
            _loc_4.type_string = this.mSelectedOrderType.GetType_string();
            _loc_4.amount = this.mPanel.amountSlider.value;
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.START_TIMED_PRODUCTION, this.mGI.mCurrentViewedZoneID, _loc_4);
            this.mSelectedOrderType = null;
            if (this.mProductionType == TIMED_PRODUCTION_TYPE.MILITARY_UNIT)
            {
                _loc_5 = this.mGI.mCurrentPlayerZone.GetMilitaryUnitRecruitments();
            }
            else if (this.mProductionType == TIMED_PRODUCTION_TYPE.BUFF)
            {
                _loc_5 = this.mGI.mCurrentPlayerZone.GetBuffProductionQueue();
            }
            _loc_5.SetWaitingForServer(true);
            this.Refresh();
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

        private function ProductionRemove(event:ListEvent) : void
        {
            if (this.mProductionType == TIMED_PRODUCTION_TYPE.MILITARY_UNIT)
            {
                this.mGI.mCurrentPlayerZone.GetMilitaryUnitRecruitments().CancelProduction(this.mGI.mCurrentPlayer.GetPlayerId(), event.rowIndex);
            }
            else if (this.mProductionType == TIMED_PRODUCTION_TYPE.BUFF)
            {
                this.mGI.mCurrentPlayerZone.GetBuffProductionQueue().CancelProduction(this.mGI.mCurrentPlayer.GetPlayerId(), event.rowIndex);
            }
            this.Refresh();
            var _loc_2:* = new dTimedProductionQueueChangeVO();
            _loc_2.productionType = this.mProductionType;
            _loc_2.queueIndex = event.rowIndex;
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.PRODUCTION_REMOVE, this.mGI.mCurrentViewedZoneID, _loc_2);
            return;
        }// end function

    }
}
