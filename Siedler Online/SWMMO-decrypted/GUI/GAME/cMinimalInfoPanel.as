package GUI.GAME
{
    import Enums.*;
    import GO.*;
    import GUI.Assets.*;
    import GUI.Components.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import Interface.*;
    import flash.events.*;
    import mx.controls.*;
    import mx.events.*;

    public class cMinimalInfoPanel extends cBasicInfoPanel
    {
        protected var mBuilding:cBuilding;
        private var mGI:cGameInterface;
        protected var mPanel:MinimalInfoPanel;

        public function cMinimalInfoPanel()
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
            var _loc_2:* = param1.GetContainerName_string();
            this.mBuilding = param1;
            this.mPanel.label = cLocaManager.GetInstance().GetText(LOCA_GROUP.BUILDINGS, _loc_2);
            this.mPanel.description.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, _loc_2);
            this.mPanel.image.source = gAssetManager.GetBuildingIcon(_loc_2);
            this.mPanel.btnKnockDown.enabled = param1.IsKnockdownAllowed();
            if (this.mBuilding.GetRecurringBuff() != null)
            {
                this.mPanel.payshopItemIndicator.visible = true;
                this.mPanel.btnKnockDown.toolTip = "KnockDownRecurring";
            }
            else
            {
                this.mPanel.payshopItemIndicator.visible = false;
                this.mPanel.btnKnockDown.toolTip = "KnockDown";
            }
            if (this.mBuilding.GetBuildingMode() == cBuilding.BUILDING_MODE_SETTLER_WALKS_TO_BUILDING_GROUND_PLACE || this.mBuilding.GetBuildingMode() == cBuilding.BUILDING_MODE_CONSTRUCTION)
            {
            }
            return;
        }// end function

        public function Init(param1:MinimalInfoPanel) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            this.mPanel.btnClose.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            this.mPanel.btnKnockDown.addEventListener(MouseEvent.CLICK, this.ConfirmRemoveBuilding);
            this.mPanel.btnKnockDown.addEventListener(ToolTipEvent.TOOL_TIP_CREATE, this.CreateKnockDownToolTip);
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
