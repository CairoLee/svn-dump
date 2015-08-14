package GUI.Components
{
    import Sound.*;
    import flash.events.*;
    import mx.controls.*;

    public class CloseButton extends Button
    {

        public function CloseButton()
        {
            this.styleName = "close";
            this.width = 25;
            this.height = 23;
            this.addEventListener("click", this.___CloseButton_Button1_click);
            return;
        }// end function

        override public function initialize() : void
        {
            super.initialize();
            return;
        }// end function

        public function ___CloseButton_Button1_click(event:MouseEvent) : void
        {
            cSoundManager.GetInstance().PlayEffect("MenuClose");
            return;
        }// end function

    }
}
