package GUI.Components
{
    import GUI.Components.ToolTips.*;
    import Sound.*;
    import flash.events.*;
    import mx.controls.*;
    import mx.events.*;
    import mx.styles.*;

    public class StandardButton extends Button
    {
        private var _soundEffect:String = "ButtonClick";
        private var _playSound:Boolean = true;

        public function StandardButton()
        {
            if (!this.styleDeclaration)
            {
                this.styleDeclaration = new CSSStyleDeclaration();
            }
            this.styleDeclaration.defaultFactory = function () : void
            {
                this.color = 0;
                return;
            }// end function
            ;
            this.styleName = "standard";
            this.addEventListener("toolTipCreate", this.___StandardButton_Button1_toolTipCreate);
            this.addEventListener("click", this.___StandardButton_Button1_click);
            return;
        }// end function

        public function get soundEffect() : String
        {
            return this._soundEffect;
        }// end function

        public function set soundEffect(param1:String) : void
        {
            this._soundEffect = param1;
            return;
        }// end function

        public function ___StandardButton_Button1_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        override public function initialize() : void
        {
            super.initialize();
            return;
        }// end function

        private function play() : void
        {
            if (this._playSound)
            {
                cSoundManager.GetInstance().PlayEffect(this._soundEffect);
            }
            return;
        }// end function

        public function set playSound(param1:Boolean) : void
        {
            this._playSound = param1;
            return;
        }// end function

        public function get playSound() : Boolean
        {
            return this._playSound;
        }// end function

        public function ___StandardButton_Button1_click(event:MouseEvent) : void
        {
            this.play();
            return;
        }// end function

    }
}
