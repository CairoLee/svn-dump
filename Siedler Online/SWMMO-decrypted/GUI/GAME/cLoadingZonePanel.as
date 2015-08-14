package GUI.GAME
{
    import GUI.*;
    import mx.containers.*;

    public class cLoadingZonePanel extends cGuiBaseElement
    {
        protected var mPanel:Canvas;

        public function cLoadingZonePanel()
        {
            return;
        }// end function

        public function Init(param1:Canvas) : void
        {
            AddBaseElement(param1);
            this.mPanel = param1;
            return;
        }// end function

    }
}
