package GUI.GAME
{
    import GUI.*;
    import mx.containers.*;

    public class cDarkenPanel extends cGuiBaseElement
    {
        protected var mPanel:Canvas;

        public function cDarkenPanel()
        {
            return;
        }// end function

        public function Init(param1:Canvas) : void
        {
            AddBaseElement(param1);
            this.mPanel = param1;
            return;
        }// end function

        override public function Hide() : void
        {
            super.Hide();
            return;
        }// end function

        override public function Show() : void
        {
            super.Show();
            return;
        }// end function

    }
}
