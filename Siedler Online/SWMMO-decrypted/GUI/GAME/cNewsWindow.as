package GUI.GAME
{
    import Enums.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import Interface.*;
    import Sound.*;
    import flash.events.*;
    import flash.utils.*;
    import nLib.*;

    public class cNewsWindow extends cBasicPanel
    {
        private var mMessageDuration:int = 10000;
        private var mGI:cGameInterface;
        protected var mPanel:NewsWindow;
        private const TIP_DURATION:int = 10000;
        private var mPreviousMessage:int = 0;
        private var mTipChanged:Number;
        private var mLoadingMessageChanged:Number;
        private var mPreviousTip:int = 0;

        public function cNewsWindow()
        {
            return;
        }// end function

        private function SetLoadingMessage() : void
        {
            return;
        }// end function

        public function SetData() : void
        {
            this.SetRandomTip();
            this.SetLoadingMessage();
            this.mPanel.pulsate.play();
            this.mPanel.lastChanges.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, global.latestChangesIdentifier);
            return;
        }// end function

        private function ClosePanel(event:MouseEvent) : void
        {
            this.Hide();
            return;
        }// end function

        override public function Show() : void
        {
            this.SetData();
            if (global.tipOfTheDayCount > 1)
            {
                this.mPanel.addEventListener(Event.ENTER_FRAME, this.UpdateTip);
            }
            if (global.loadingMessageCount > 1)
            {
                this.mPanel.addEventListener(Event.ENTER_FRAME, this.UpdateLoadingMessage);
            }
            super.Show();
            return;
        }// end function

        public function SetLoadingMessageFromBB(param1:String) : void
        {
            this.mPanel.loadingLabel.text = param1;
            return;
        }// end function

        override public function Hide() : void
        {
            this.mPanel.removeEventListener(Event.ENTER_FRAME, this.UpdateTip);
            super.Hide();
            return;
        }// end function

        public function Enable() : void
        {
            this.mPanel.btnOK.visible = true;
            this.mPanel.loadingLabel.visible = false;
            this.mPanel.pulsate.stop();
            this.mPanel.removeEventListener(Event.ENTER_FRAME, this.UpdateLoadingMessage);
            cSoundManager.GetInstance().Init();
            return;
        }// end function

        public function Init(param1:NewsWindow) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            this.mPanel.btnOK.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            return;
        }// end function

        private function UpdateTip(event:Event) : void
        {
            if (getTimer() - this.mTipChanged > this.TIP_DURATION)
            {
                this.SetRandomTip();
            }
            return;
        }// end function

        private function UpdateLoadingMessage(event:Event) : void
        {
            if (getTimer() - this.mLoadingMessageChanged > this.mMessageDuration)
            {
                this.SetLoadingMessage();
            }
            return;
        }// end function

        private function SetRandomTip() : void
        {
            var _loc_2:String = null;
            var _loc_1:* = gMisc.GetRandomMinMaxInt(1, global.tipOfTheDayCount);
            while (_loc_1 == this.mPreviousTip)
            {
                
                _loc_1 = gMisc.GetRandomMinMaxInt(1, global.tipOfTheDayCount);
            }
            if (_loc_1 < 10)
            {
                _loc_2 = "TipOfTheDay0" + _loc_1;
            }
            else
            {
                _loc_2 = "TipOfTheDay" + _loc_1;
            }
            this.mPanel.tipText = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, _loc_2);
            this.mTipChanged = getTimer();
            this.mPreviousTip = _loc_1;
            return;
        }// end function

    }
}
