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
    import flash.events.*;
    import mx.controls.*;
    import mx.events.*;

    public class cResidenceInfoPanel extends cBasicInfoPanel
    {
        protected var mBuilding:cBuilding;
        private var mGI:cGameInterface;
        protected var mPanel:ResidenceInfoPanel;

        public function cResidenceInfoPanel()
        {
            return;
        }// end function

        private function RepairBuilding(event:Event) : void
        {
            this.mBuilding.SetRecoveringHitPoints(global.repairRate);
            this.Hide();
            return;
        }// end function

        override public function Hide() : void
        {
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

        override public function SetData(param1:cBuilding) : void
        {
            var _loc_3:dResource = null;
            var _loc_4:dResource = null;
            var _loc_5:dResourceDefaultDefinition = null;
            var _loc_6:dExpandMaxLimit = null;
            var _loc_7:cBuffDefinition = null;
            var _loc_8:cBuffDefinition = null;
            var _loc_9:int = 0;
            var _loc_10:ResourceItemRenderer = null;
            var _loc_2:* = param1.GetContainerName_string();
            this.mBuilding = param1;
            this.mPanel.label = cLocaManager.GetInstance().GetText(LOCA_GROUP.BUILDINGS, _loc_2);
            this.mPanel.description.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, _loc_2);
            this.mPanel.image.source = gAssetManager.GetBuildingIcon(_loc_2);
            if (param1.GetUpgradeDuration() > 0)
            {
                _loc_7 = this.mBuilding.GetUpgradeLevelBonusesForLevel(this.mBuilding.GetUpgradeLevel());
                _loc_8 = this.mBuilding.GetUpgradeLevelBonusesForLevel((this.mBuilding.GetUpgradeLevel() + 1));
                _loc_9 = _loc_8.getGoodsCapacity() - _loc_7.getGoodsCapacity();
                this.mPanel.btnUpgrade.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "UpgradeResidence", [_loc_9.toString()]);
            }
            else
            {
                this.mPanel.btnUpgrade.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "NotPossible");
            }
            this.mPanel.btnUpgrade.enabled = param1.IsUpgradeAllowed(true);
            this.mPanel.btnInstantUpgrade.enabled = false;
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
            for each (_loc_3 in param1.GetUpgradeCosts_vector())
            {
                
                _loc_10 = new ResourceItemRenderer();
                _loc_10.data = _loc_3;
                this.mPanel.costsList.addChild(_loc_10);
            }
            _loc_4 = new dResource();
            _loc_4.name_string = defines.POPULATION_RESOURCE_NAME_string;
            _loc_5 = gEconomics.GetResourcesDefaultDefinition(defines.POPULATION_RESOURCE_NAME_string);
            for each (_loc_6 in _loc_5.expandMaxLimitList_vector)
            {
                
                if (_loc_6.name_string == this.mBuilding.GetBuildingName_string())
                {
                    _loc_4.amount = _loc_4.amount + _loc_6.amount;
                }
            }
            _loc_4.amount = _loc_4.amount + this.mBuilding.GetUpgradeLevelBonuses().getGoodsCapacity();
            this.mPanel.population.data = _loc_4;
            this.mPanel.population.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "PopulationIncreased");
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

        public function Init(param1:ResidenceInfoPanel) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            this.mPanel.btnClose.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            this.mPanel.btnKnockDown.addEventListener(MouseEvent.CLICK, this.ConfirmRemoveBuilding);
            this.mPanel.btnUpgrade.addEventListener(MouseEvent.CLICK, this.UpgradeBuilding);
            this.mPanel.btnInstantUpgrade.addEventListener(MouseEvent.CLICK, this.InstantUpgradeBuilding);
            this.mPanel.btnRepair.addEventListener(MouseEvent.CLICK, this.RepairBuilding);
            this.mPanel.btnKnockDown.addEventListener(ToolTipEvent.TOOL_TIP_CREATE, this.CreateKnockDownToolTip);
            this.mPanel.population.addEventListener(MouseEvent.CLICK, this.ShopDeepLink);
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

        private function ConfirmRemoveBuilding(event:Event) : void
        {
            var _loc_2:* = CustomAlert.show("ConfirmTeardown", "ConfirmTeardown", Alert.CANCEL | Alert.OK, this.mPanel, this.RemoveBuilding);
            _loc_2.addEventListener(CloseEvent.CLOSE, this.RemoveBuilding);
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

        private function ShopDeepLink(event:MouseEvent) : void
        {
            globalFlash.gui.mShopWindow.ShowDeepLink("ResidenceInfo", 3003, 3);
            return;
        }// end function

        override public function Show() : void
        {
            super.Show();
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

    }
}
