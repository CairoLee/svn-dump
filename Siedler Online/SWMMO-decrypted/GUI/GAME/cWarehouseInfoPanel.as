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
    import __AS3__.vec.*;
    import flash.events.*;
    import mx.collections.*;
    import mx.controls.*;
    import mx.events.*;

    public class cWarehouseInfoPanel extends cBasicInfoPanel
    {
        protected var mBuilding:cBuilding;
        public var mResources:Array;
        private var mGI:cGameInterface;
        protected var mPanel:WarehouseInfoPanel;
        private var mResourceUpdateCounter:int;

        public function cWarehouseInfoPanel()
        {
            this.mResources = [];
            return;
        }// end function

        public function Init(param1:WarehouseInfoPanel) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            this.mResources = [];
            this.mResourceUpdateCounter = 0;
            this.mPanel.btnClose.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            this.mPanel.btnKnockDown.addEventListener(MouseEvent.CLICK, this.ConfirmRemoveBuilding);
            this.mPanel.btnUpgrade.addEventListener(MouseEvent.CLICK, this.UpgradeBuilding);
            this.mPanel.btnInstantUpgrade.addEventListener(MouseEvent.CLICK, this.InstantUpgradeBuilding);
            this.mPanel.btnKnockDown.addEventListener(ToolTipEvent.TOOL_TIP_CREATE, this.CreateKnockDownToolTip);
            this.mPanel.buttonBar.addEventListener(ListEvent.ITEM_CLICK, this.SetFilteredResourceList);
            this.mPanel.list.addEventListener(ListEvent.ITEM_CLICK, this.DisplayShop);
            return;
        }// end function

        override public function SetData(param1:cBuilding) : void
        {
            var _loc_4:dResource = null;
            var _loc_5:cBuffDefinition = null;
            var _loc_6:cBuffDefinition = null;
            var _loc_7:int = 0;
            var _loc_8:ResourceItemRenderer = null;
            var _loc_2:* = param1.GetContainerName_string();
            this.mBuilding = param1;
            this.mPanel.label = cLocaManager.GetInstance().GetText(LOCA_GROUP.BUILDINGS, _loc_2);
            this.mPanel.description.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, _loc_2);
            this.mPanel.image.source = gAssetManager.GetBuildingIcon(_loc_2);
            if (param1.GetUpgradeDuration() > 0)
            {
                _loc_5 = this.mBuilding.GetUpgradeLevelBonusesForLevel(this.mBuilding.GetUpgradeLevel());
                _loc_6 = this.mBuilding.GetUpgradeLevelBonusesForLevel((this.mBuilding.GetUpgradeLevel() + 1));
                _loc_7 = _loc_6.getGoodsCapacity() - _loc_5.getGoodsCapacity();
                this.mPanel.btnUpgrade.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "UpgradeWarehouse", [_loc_7.toString()]);
            }
            else
            {
                this.mPanel.btnUpgrade.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "NotPossible");
            }
            this.mPanel.btnUpgrade.enabled = param1.IsUpgradeAllowed(true);
            this.mPanel.btnInstantUpgrade.enabled = false;
            var _loc_3:* = this.IsLastWarehouseInSector();
            this.mPanel.btnKnockDown.enabled = param1.IsKnockdownAllowed() && !_loc_3;
            if (this.mBuilding.GetBuildingName_string() == defines.MAYORHOUSE_NAME_string)
            {
                this.mPanel.btnKnockDown.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "KnockDownDisabledMayorhouse");
            }
            else if (_loc_3)
            {
                this.mPanel.btnKnockDown.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "KnockDownDisabledLastWarehouse");
            }
            else if (this.mBuilding.GetRecurringBuff() != null)
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
            for each (_loc_4 in param1.GetUpgradeCosts_vector())
            {
                
                _loc_8 = new ResourceItemRenderer();
                _loc_8.data = _loc_4;
                this.mPanel.costsList.addChild(_loc_8);
            }
            this.mPanel.buttonBar.dataProvider = [{label:cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "WarehouseTab1"), group:RESOURCE_GROUP.CL1}, {label:cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "WarehouseTab2"), group:RESOURCE_GROUP.CL2}, {label:cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "WarehouseTab3"), group:RESOURCE_GROUP.CL3}, {label:cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "WarehouseTab4"), group:RESOURCE_GROUP.CL4}, {label:cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "WarehouseTab5"), group:RESOURCE_GROUP.MILITARY}];
            this.mPanel.list.selectedIndex = 0;
            this.SetFilteredResourceList();
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

        override public function Show() : void
        {
            super.Show();
            return;
        }// end function

        private function ConfirmRemoveBuilding(event:Event) : void
        {
            var _loc_2:* = CustomAlert.show("ConfirmTeardown", "ConfirmTeardown", Alert.CANCEL | Alert.OK, this.mPanel, this.RemoveBuilding);
            _loc_2.addEventListener(CloseEvent.CLOSE, this.RemoveBuilding);
            return;
        }// end function

        override public function Hide() : void
        {
            super.Hide();
            return;
        }// end function

        private function SetFilteredResourceList(event:ItemClickEvent = null) : void
        {
            var _loc_5:dResource = null;
            var _loc_6:cMilitaryUnitDescription = null;
            var _loc_7:cSquad = null;
            var _loc_8:cResources = null;
            var _loc_9:Vector.<dResource> = null;
            var _loc_10:dResource = null;
            this.mResources = [];
            var _loc_2:* = this.mGI.FindPlayerFromId(this.mBuilding.GetPlayerID());
            var _loc_3:* = event ? (event.index) : (0);
            var _loc_4:* = (this.mPanel.buttonBar.dataProvider as ArrayCollection).getItemAt(_loc_3).group as String;
            if (_loc_2 != null)
            {
                if (_loc_4 == "Military")
                {
                    for each (_loc_6 in cMilitaryUnitDescription.GetAllUnitDescriptions(true))
                    {
                        
                        _loc_5 = new dResource();
                        _loc_5.group_string = RESOURCE_GROUP.MILITARY;
                        _loc_5.name_string = _loc_6.GetType_string();
                        _loc_5.amount = 0;
                        this.mResources.push(_loc_5);
                    }
                    for each (_loc_7 in this.mGI.mCurrentPlayerZone.GetArmy(this.mGI.mCurrentPlayer.GetPlayerId()).GetSquads_vector())
                    {
                        
                        for each (_loc_5 in this.mResources)
                        {
                            
                            if (_loc_5.name_string == _loc_7.GetType_string())
                            {
                                _loc_5.amount = _loc_7.GetAmount();
                                break;
                            }
                        }
                    }
                }
                else
                {
                    _loc_8 = this.mGI.mCurrentPlayerZone.GetResources(_loc_2);
                    _loc_9 = _loc_8.GetPlayerResources_vector(_loc_4);
                    for each (_loc_10 in _loc_9)
                    {
                        
                        if (global.visibleResources_vector.indexOf(_loc_10.name_string) > -1)
                        {
                            _loc_5 = new dResource();
                            _loc_5.GetFromDResource(_loc_10);
                            this.mResources.push(_loc_5);
                        }
                    }
                }
            }
            this.mPanel.list.dataProvider = this.mResources;
            this.mResourceUpdateCounter = 0;
            return;
        }// end function

        private function CreateKnockDownToolTip(event:ToolTipEvent) : void
        {
            if (this.mBuilding.GetRecurringBuff() != null || this.IsLastWarehouseInSector() || this.mBuilding.GetBuildingName_string() == defines.MAYORHOUSE_NAME_string)
            {
                cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            }
            else
            {
                cToolTipUtil.createToolTip(cToolTipUtil.DEMOLISH_BUILDING_string, event, this.mBuilding);
            }
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

        private function IsLastWarehouseInSector() : Boolean
        {
            var _loc_3:cBuilding = null;
            var _loc_4:cIsoElement = null;
            var _loc_1:* = global.ui;
            var _loc_2:* = _loc_1.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[this.mBuilding.GetBuildingGrid()].mSectorId;
            for each (_loc_3 in _loc_1.mCurrentPlayerZone.mStreetDataMap.GetBuildings_vector())
            {
                
                _loc_4 = _loc_1.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_3.GetBuildingGrid()];
                if (_loc_4.mSectorId == _loc_2)
                {
                    if (_loc_3.IsWarehouseType() && _loc_3.GetBuildingGrid() != this.mBuilding.GetBuildingGrid() && _loc_3.GetBuildingMode() > cBuilding.BUILDING_MODE_PLACED)
                    {
                        return false;
                    }
                }
            }
            return true;
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

        public function UpdateResources() : void
        {
            if (this.mResources.length == 0)
            {
                return;
            }
            if (this.mResourceUpdateCounter >= this.mResources.length)
            {
                this.mResourceUpdateCounter = 0;
            }
            var _loc_1:* = this.mResources[this.mResourceUpdateCounter];
            var _loc_2:* = this.mGI.mCurrentPlayerZone.GetResourcesForPlayerID(this.mBuilding.GetPlayerID());
            var _loc_3:* = _loc_2.GetPlayerResource(_loc_1.name_string);
            if (_loc_3 != null)
            {
                _loc_1.amount = _loc_3.amount;
                _loc_1.maxLimit = _loc_3.maxLimit;
            }
            var _loc_4:String = this;
            var _loc_5:* = this.mResourceUpdateCounter + 1;
            _loc_4.mResourceUpdateCounter = _loc_5;
            return;
        }// end function

        private function DisplayShop(event:ListEvent) : void
        {
            globalFlash.gui.mShopWindow.ShowDeepLink("Warehouse", -1, 1);
            return;
        }// end function

    }
}
