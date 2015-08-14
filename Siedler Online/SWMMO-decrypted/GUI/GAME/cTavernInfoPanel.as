package GUI.GAME
{
    import Enums.*;
    import GO.*;
    import GUI.Assets.*;
    import GUI.Components.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import Interface.*;
    import ServerState.*;
    import Specialists.*;
    import flash.events.*;
    import mx.controls.*;
    import mx.events.*;

    public class cTavernInfoPanel extends cBasicInfoPanel
    {
        protected var mBuilding:cBuilding;
        private var mGI:cGameInterface;
        protected var mPanel:TavernInfoPanel;

        public function cTavernInfoPanel()
        {
            return;
        }// end function

        private function BuySpecialist(event:ListEvent) : void
        {
            cSpecialist.BuySpecialist(event.rowIndex, this.mGI);
            this.Hide();
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
            var _loc_4:ResourceItemRenderer = null;
            var _loc_5:BuySpecialistItemRenderer = null;
            var _loc_6:cSpecialistDescription = null;
            var _loc_2:* = param1.GetContainerName_string();
            this.mBuilding = param1;
            this.mPanel.label = cLocaManager.GetInstance().GetText(LOCA_GROUP.BUILDINGS, _loc_2);
            this.mPanel.description.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, _loc_2);
            this.mPanel.image.source = gAssetManager.GetBuildingIcon(_loc_2);
            if (param1.GetUpgradeDuration() > 0)
            {
                this.mPanel.btnUpgrade.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "UpgradeTavern");
            }
            else
            {
                this.mPanel.btnUpgrade.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "NotPossible");
            }
            this.mPanel.btnUpgrade.enabled = param1.IsUpgradeAllowed(true);
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
                
                _loc_4 = new ResourceItemRenderer();
                _loc_4.data = _loc_3;
                this.mPanel.costsList.addChild(_loc_4);
            }
            if (this.mPanel.list.getChildren().length == cSpecialist.GetAllSpecialistDescriptions().length)
            {
                for each (_loc_5 in this.mPanel.list.getChildren())
                {
                    
                    _loc_5.refresh();
                }
            }
            else
            {
                this.mPanel.list.removeAllChildren();
                for each (_loc_6 in cSpecialist.GetAllSpecialistDescriptions())
                {
                    
                    _loc_5 = new BuySpecialistItemRenderer();
                    _loc_5.data = _loc_6;
                    this.mPanel.list.addChild(_loc_5);
                }
            }
            return;
        }// end function

        public function Init(param1:TavernInfoPanel) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            this.mPanel.btnClose.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            this.mPanel.btnKnockDown.addEventListener(MouseEvent.CLICK, this.ConfirmRemoveBuilding);
            this.mPanel.btnKnockDown.addEventListener(ToolTipEvent.TOOL_TIP_CREATE, this.CreateKnockDownToolTip);
            this.mPanel.btnUpgrade.addEventListener(MouseEvent.CLICK, this.UpgradeBuilding);
            this.mPanel.btnRepair.addEventListener(MouseEvent.CLICK, this.RepairBuilding);
            this.mPanel.list.addEventListener("BuySpecialist", this.BuySpecialist);
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
