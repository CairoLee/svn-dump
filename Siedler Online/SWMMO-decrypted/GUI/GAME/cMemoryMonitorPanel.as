package GUI.GAME
{
    import GUI.*;
    import Interface.*;
    import flash.events.*;
    import mx.containers.*;
    import mx.core.*;

    public class cMemoryMonitorPanel extends cGuiBaseElement
    {
        protected var mPanel:Panel;
        private var mGI:cGameInterface;

        public function cMemoryMonitorPanel()
        {
            return;
        }// end function

        public function Init(param1:Panel) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            return;
        }// end function

        override public function Hide() : void
        {
            this.mPanel.removeEventListener(Event.ENTER_FRAME, this.CalculateMemoryUsage);
            super.Hide();
            return;
        }// end function

        private function CalculateMemoryUsage(event:Event) : void
        {
            Application.application.mMemoryMonitor.CalculateMemoryUsage();
            return;
        }// end function

        override public function Show() : void
        {
            this.mPanel.addEventListener(Event.ENTER_FRAME, this.CalculateMemoryUsage);
            super.Show();
            return;
        }// end function

    }
}
