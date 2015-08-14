package GUI.GAME
{
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

    public class cConstructionInfoPanel extends cBasicInfoPanel
    {
        protected var mBuilding:cBuilding;
        private var mGI:cGameInterface;
        protected var mPanel:ConstructionInfoPanel;

        public function cConstructionInfoPanel()
        {
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
            var _loc_4:ResourceItemRenderer = null;
            var _loc_2:* = param1.GetContainerName_string();
            this.mBuilding = param1;
            this.mPanel.label = cLocaManager.GetInstance().GetText(LOCA_GROUP.BUILDINGS, _loc_2);
            this.mPanel.description.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, _loc_2);
            this.mPanel.image.source = gAssetManager.GetBuildingIcon(_loc_2);
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
            if (this.mBuilding.GetBuildingMode() == cBuilding.BUILDING_MODE_SETTLER_WALKS_TO_BUILDING_GROUND_PLACE || this.mBuilding.GetBuildingMode() == cBuilding.BUILDING_MODE_CONSTRUCTION)
            {
                this.mPanel.costsLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "TimeRemaining");
                this.mPanel.timeLabel.text = cLocaManager.GetInstance().FormatDuration(this.mBuilding.GetRemainingConstructionDuration());
                this.mPanel.costsList.visible = false;
                this.mPanel.timeLabel.visible = true;
                this.mPanel.btnInstant.toolTip = "BuildInstant";
                this.mPanel.btnInstant.visible = true;
            }
            else
            {
                this.mPanel.costsLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Costs");
                this.mPanel.costsList.visible = true;
                this.mPanel.timeLabel.visible = false;
                this.mPanel.btnInstant.visible = false;
            }
            this.mPanel.costsList.removeAllChildren();
            for each (_loc_3 in global.buildingGroup.GetCostListFromName_vector(_loc_2))
            {
                
                _loc_4 = new ResourceItemRenderer();
                _loc_4.data = _loc_3;
                this.mPanel.costsList.addChild(_loc_4);
            }
            return;
        }// end function

        private function InstantBuild(event:MouseEvent) : void
        {
            var _loc_2:* = this.mGI.mCurrentPlayerZone.GetResources(this.mGI.mCurrentPlayer);
            if (_loc_2.HasPlayerResource(defines.HARD_CURRENCY_RESOURCE_NAME_string, this.mBuilding.GetBuildInstantCosts()))
            {
                global.ui.mClientMessages.SendMessagetoServer(COMMAND.BUY_ONE_CLICK_SHOP_ITEM, this.mGI.mCurrentViewedZoneID, new dBuyOneClickShopItemVO().InitWithBuildingGrid(8000, this.mBuilding.GetBuildingGrid()));
            }
            else
            {
                CustomAlert.show("MissingHardCurrency", "", Alert.OK | Alert.CANCEL, null, this.AddHardCurrencyHandler, null, Alert.OK, true, CustomAlert.STYLE_PAYMENT);
            }
            this.Hide();
            return;
        }// end function

        public function Init(param1:ConstructionInfoPanel) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            this.mPanel.btnClose.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            this.mPanel.btnKnockDown.addEventListener(MouseEvent.CLICK, this.ConfirmRemoveBuilding);
            this.mPanel.btnKnockDown.addEventListener(ToolTipEvent.TOOL_TIP_CREATE, this.CreateKnockDownToolTip);
            this.mPanel.btnInstant.addEventListener(MouseEvent.CLICK, this.InstantBuild);
            this.mPanel.btnInstant.addEventListener(ToolTipEvent.TOOL_TIP_CREATE, this.CreateInstantBuildTip);
            return;
        }// end function

        private function CreateInstantBuildTip(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.INSTANT_BUILD_string, event, this.mBuilding.GetBuildInstantCosts());
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
