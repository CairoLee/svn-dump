package GUI.GAME
{
    import Communication.VO.*;
    import Enums.*;
    import GUI.Components.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import Interface.*;
    import ServerState.*;
    import Specialists.*;
    import flash.events.*;
    import mx.controls.*;
    import mx.events.*;

    public class cSpecialistCooldownPanel extends cBasicPanel
    {
        protected var speedUpCosts:int;
        protected var task:cSpecialistTask;
        protected var mSpecialist:cSpecialist;
        private var mGI:cGameInterface;
        protected var mPanel:SpecialistCooldownPanel;

        public function cSpecialistCooldownPanel()
        {
            return;
        }// end function

        private function onCreateToolTip(event:ToolTipEvent) : void
        {
            this.mPanel.btnPay.toolTip = "HalveTimeCost";
            cToolTipUtil.createToolTip(cToolTipUtil.INSTANT_BUILD_string, event, this.speedUpCosts);
            return;
        }// end function

        override public function Hide() : void
        {
            super.Hide();
            return;
        }// end function

        public function SetData(param1:cSpecialist) : void
        {
            var _loc_3:String = null;
            var _loc_2:* = cLocaManager.GetInstance();
            this.task = param1.GetTask();
            this.mSpecialist = param1;
            this.speedUpCosts = cSpecialistTask.GetSpeedUpCosts(this.task.GetType());
            if (this.task.GetType() == SPECIALIST_TASK_TYPES.DEPOSIT_SEARCH)
            {
                _loc_3 = (this.task as cSpecialistTask_FindDeposit).GetDepositToSearch_string();
                this.speedUpCosts = cSpecialistTask_FindDeposit.GetSpeedUpCostsForDeposit(_loc_3);
            }
            this.mPanel.specialistRenderer.data = param1;
            this.mPanel.headline.text = _loc_2.GetText(LOCA_GROUP.SPECIALISTS, SPECIALIST_TYPE.toString(param1.GetType()));
            this.mPanel.description.text = _loc_2.GetText(LOCA_GROUP.DESCRIPTIONS, SPECIALIST_TYPE.toString(param1.GetType()));
            this.mPanel.timeRemain.text = _loc_2.GetText(LOCA_GROUP.LABELS, "TimeRemaining") + " " + _loc_2.FormatDuration(this.task.GetRemainingTime());
            this.mPanel.btnPay.enabled = true;
            return;
        }// end function

        public function Init(param1:SpecialistCooldownPanel) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            this.mPanel.btnClose.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            this.mPanel.btnOK.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            this.mPanel.btnPay.addEventListener(MouseEvent.CLICK, this.onAccelerateClick);
            this.mPanel.btnPay.addEventListener(ToolTipEvent.TOOL_TIP_CREATE, this.onCreateToolTip);
            return;
        }// end function

        protected function onAccelerateClick(event:MouseEvent) : void
        {
            var _loc_2:* = this.mGI.mCurrentPlayerZone.GetResources(this.mGI.mCurrentPlayer);
            if (_loc_2.HasPlayerResource(defines.HARD_CURRENCY_RESOURCE_NAME_string, this.speedUpCosts))
            {
                global.ui.mClientMessages.SendMessagetoServer(COMMAND.BUY_ONE_CLICK_SHOP_ITEM, this.mGI.mCurrentViewedZoneID, new dBuyOneClickShopItemVO().InitWithUniqueID(8005, this.mSpecialist.GetUniqueID()));
                this.mPanel.btnPay.enabled = false;
            }
            else
            {
                CustomAlert.show("MissingHardCurrency", "", Alert.OK | Alert.CANCEL, null, this.AddHardCurrencyHandler, null, Alert.OK, true, CustomAlert.STYLE_PAYMENT);
            }
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

        private function ClosePanel(event:Event) : void
        {
            this.Hide();
            return;
        }// end function

        public function Refresh() : void
        {
            if (this.mSpecialist)
            {
                this.SetData(this.mSpecialist);
            }
            return;
        }// end function

        override public function Show() : void
        {
            super.Show();
            return;
        }// end function

    }
}
