package GUI.GAME
{
    import Communication.VO.*;
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

    public class cDecorationInfoPanel extends cBasicInfoPanel
    {
        protected var mBuilding:cBuilding;
        private var mInitialOffsetX:int = 0;
        private var mInitialOffsetY:int = 0;
        private var mGI:cGameInterface;
        protected var mPanel:DecorationInfoPanel;
        private var mOffsetChanged:Boolean = false;

        public function cDecorationInfoPanel()
        {
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
                this.mPanel.btnKnockDown.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "KnockDownRecurring");
            }
            else
            {
                this.mPanel.payshopItemIndicator.visible = false;
                this.mPanel.btnKnockDown.toolTip = "KnockDown";
            }
            this.mInitialOffsetX = this.mBuilding.GetOffsetX();
            this.mInitialOffsetY = this.mBuilding.GetOffsetY();
            this.CheckMaximumReached();
            return;
        }// end function

        private function SaveOffset(event:MouseEvent = null) : void
        {
            var _loc_2:dPosVO = null;
            if (this.mOffsetChanged)
            {
                this.mInitialOffsetX = this.mBuilding.GetOffsetX();
                this.mInitialOffsetY = this.mBuilding.GetOffsetY();
                this.mOffsetChanged = false;
                this.CheckMaximumReached();
                _loc_2 = new dPosVO();
                _loc_2.x = this.mBuilding.GetOffsetX();
                _loc_2.y = this.mBuilding.GetOffsetY();
                this.mGI.SendServerAction(COMMAND.SET_BUILDING_OFFSETS, 0, this.mBuilding.GetBuildingGrid(), 0, _loc_2);
            }
            return;
        }// end function

        private function ClosePanel(event:Event) : void
        {
            this.ResetPosition();
            this.Hide();
            return;
        }// end function

        private function ConfirmRemoveBuilding(event:Event) : void
        {
            var _loc_2:* = CustomAlert.show("ConfirmTeardown", "ConfirmTeardown", Alert.CANCEL | Alert.OK, this.mPanel, this.RemoveBuilding);
            _loc_2.addEventListener(CloseEvent.CLOSE, this.RemoveBuilding);
            return;
        }// end function

        private function CheckMaximumReached() : void
        {
            this.mPanel.btnMoveUp.enabled = this.mBuilding.GetOffsetY() > -defines.MAX_BUILDING_OFFSET;
            this.mPanel.btnMoveDown.enabled = this.mBuilding.GetOffsetY() < defines.MAX_BUILDING_OFFSET;
            this.mPanel.btnMoveLeft.enabled = this.mBuilding.GetOffsetX() > -defines.MAX_BUILDING_OFFSET;
            this.mPanel.btnMoveRight.enabled = this.mBuilding.GetOffsetX() < defines.MAX_BUILDING_OFFSET;
            this.mPanel.btnOK.enabled = this.mOffsetChanged;
            this.mPanel.btnCancel.enabled = this.mOffsetChanged;
            return;
        }// end function

        override public function Show() : void
        {
            this.mOffsetChanged = false;
            super.Show();
            return;
        }// end function

        private function MoveLeft(event:MouseEvent) : void
        {
            this.mBuilding.ModifyOffsetX(-1);
            this.mBuilding.SetPosition(this.mBuilding.GetX(), this.mBuilding.GetY());
            this.mOffsetChanged = true;
            this.CheckMaximumReached();
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

        private function MoveRight(event:MouseEvent) : void
        {
            this.mBuilding.ModifyOffsetX(1);
            this.mBuilding.SetPosition(this.mBuilding.GetX(), this.mBuilding.GetY());
            this.mOffsetChanged = true;
            this.CheckMaximumReached();
            return;
        }// end function

        private function MoveUp(event:MouseEvent) : void
        {
            this.mBuilding.ModifyOffsetY(-1);
            this.mBuilding.SetPosition(this.mBuilding.GetX(), this.mBuilding.GetY());
            this.mOffsetChanged = true;
            this.CheckMaximumReached();
            return;
        }// end function

        public function Init(param1:DecorationInfoPanel) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            this.mPanel.btnClose.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            this.mPanel.btnKnockDown.addEventListener(MouseEvent.CLICK, this.ConfirmRemoveBuilding);
            this.mPanel.btnKnockDown.addEventListener(ToolTipEvent.TOOL_TIP_CREATE, this.CreateKnockDownToolTip);
            this.mPanel.btnMoveUp.addEventListener(MouseEvent.CLICK, this.MoveUp);
            this.mPanel.btnMoveDown.addEventListener(MouseEvent.CLICK, this.MoveDown);
            this.mPanel.btnMoveLeft.addEventListener(MouseEvent.CLICK, this.MoveLeft);
            this.mPanel.btnMoveRight.addEventListener(MouseEvent.CLICK, this.MoveRight);
            this.mPanel.btnOK.addEventListener(MouseEvent.CLICK, this.SaveOffset);
            this.mPanel.btnCancel.addEventListener(MouseEvent.CLICK, this.ResetPosition);
            return;
        }// end function

        private function MoveDown(event:MouseEvent) : void
        {
            this.mBuilding.ModifyOffsetY(1);
            this.mBuilding.SetPosition(this.mBuilding.GetX(), this.mBuilding.GetY());
            this.mOffsetChanged = true;
            this.CheckMaximumReached();
            return;
        }// end function

        private function ResetPosition(event:MouseEvent = null) : void
        {
            this.mBuilding.InitOffsets(this.mInitialOffsetX, this.mInitialOffsetY);
            this.mBuilding.SetPosition(this.mBuilding.GetX(), this.mBuilding.GetY());
            this.mOffsetChanged = false;
            this.CheckMaximumReached();
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
