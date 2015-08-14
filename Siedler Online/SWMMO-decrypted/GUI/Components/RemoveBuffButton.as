package GUI.Components
{
    import Sound.*;
    import flash.events.*;
    import mx.controls.*;

    public class RemoveBuffButton extends Button
    {

        public function RemoveBuffButton()
        {
            this.styleName = "closeSmall";
            this.width = 13;
            this.height = 12;
            this.addEventListener("click", this.___RemoveBuffButton_Button1_click);
            return;
        }// end function

        override public function initialize() : void
        {
            super.initialize();
            return;
        }// end function

        public function ___RemoveBuffButton_Button1_click(event:MouseEvent) : void
        {
            cSoundManager.GetInstance().PlayEffect("ButtonClick");
            return;
        }// end function

    }
}
