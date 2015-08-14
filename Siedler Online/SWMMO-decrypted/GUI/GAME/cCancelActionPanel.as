package GUI.GAME
{
    import Enums.*;
    import GUI.*;
    import GUI.Components.*;
    import Interface.*;
    import flash.events.*;

    public class cCancelActionPanel extends cGuiBaseElement
    {
        private var mGI:cGameInterface;
        protected var mPanel:CancelActionPanel;

        public function cCancelActionPanel()
        {
            return;
        }// end function

        public function Init(param1:CancelActionPanel) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            this.mPanel.cancel.addEventListener(MouseEvent.CLICK, this.CancelAction);
            return;
        }// end function

        private function CancelAction(event:MouseEvent) : void
        {
            this.mGI.mCurrentCursor.SetCursorEditMode(COMMAND.SELECT_BUILDING);
            return;
        }// end function

    }
}
