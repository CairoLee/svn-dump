package GUI.GAME
{
    import GUI.Components.*;
    import GUI.Loca.*;
    import Interface.*;
    import flash.events.*;

    public class cLegalPanel extends cBasicPanel
    {
        private var mLM:cLocaManager;
        protected var mPanel:LegalPanel;
        private var mGI:cGameInterface;

        public function cLegalPanel()
        {
            this.mLM = cLocaManager.GetInstance();
            return;
        }// end function

        public function Init(param1:LegalPanel) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            return;
        }// end function

        override public function Hide() : void
        {
            globalFlash.gui.mDarkenPanel.Hide();
            super.Hide();
            return;
        }// end function

        private function ClosePanel(event:Event) : void
        {
            this.Hide();
            return;
        }// end function

        override public function Show() : void
        {
            globalFlash.gui.mDarkenPanel.Show();
            super.Show();
            return;
        }// end function

    }
}
