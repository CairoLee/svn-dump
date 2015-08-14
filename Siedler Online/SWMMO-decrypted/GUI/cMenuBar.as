package GUI
{
    import mx.controls.*;
    import mx.events.*;

    public class cMenuBar extends cGuiBaseElement
    {
        protected var mMenuBar:MenuBar;

        public function cMenuBar()
        {
            return;
        }// end function

        public function Init(param1:MenuBar) : void
        {
            AddBaseElement(param1);
            this.mMenuBar = param1;
            return;
        }// end function

        public function Handler(event:MenuEvent) : void
        {
            return;
        }// end function

    }
}
