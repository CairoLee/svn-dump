package GUI.GAME
{
    import GUI.*;
    import Sound.*;

    public class cBasicPanel extends cGuiBaseElement
    {
        protected var openSound:String = "MenuOpen";
        static var mCurrentActivePanel:cBasicPanel = null;

        public function cBasicPanel()
        {
            return;
        }// end function

        override public function Hide() : void
        {
            if (!this.IsVisible())
            {
                return;
            }
            global.ui.UnselectBuilding();
            super.Hide();
            globalFlash.gui.ShowQuestWindowDelayed();
            return;
        }// end function

        override public function Show() : void
        {
            if (mCurrentActivePanel && mCurrentActivePanel != this && mCurrentActivePanel.IsVisible())
            {
                mCurrentActivePanel.Hide();
            }
            mCurrentActivePanel = this;
            super.Show();
            if (this.openSound != "")
            {
                cSoundManager.GetInstance().PlayEffect(this.openSound);
            }
            return;
        }// end function

        public static function IsCurrentActivePanelVisible() : Boolean
        {
            if (!mCurrentActivePanel)
            {
                return false;
            }
            return mCurrentActivePanel.IsVisible();
        }// end function

        public static function HideCurrentActivePanel() : void
        {
            if (mCurrentActivePanel)
            {
                mCurrentActivePanel.Hide();
            }
            mCurrentActivePanel = null;
            return;
        }// end function

    }
}
