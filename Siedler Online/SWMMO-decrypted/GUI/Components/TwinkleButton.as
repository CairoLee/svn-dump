package GUI.Components
{
    import flash.events.*;
    import flash.utils.*;
    import mx.controls.*;

    public class TwinkleButton extends Button
    {
        private var _twinkleDuration:int = 500;
        private var _timer:Timer;
        private var _twinkle:Boolean = true;

        public function TwinkleButton()
        {
            return;
        }// end function

        public function set twinkleDuration(param1:int) : void
        {
            this._twinkleDuration = param1;
            this.InitTimer();
            return;
        }// end function

        private function InitTimer() : void
        {
            this._timer = new Timer(this._twinkleDuration);
            this._timer.addEventListener(TimerEvent.TIMER, this.SwitchSkins);
            return;
        }// end function

        public function set twinkle(param1:Boolean) : void
        {
            this._twinkle = param1;
            if (this._twinkle)
            {
                if (!this._timer)
                {
                    this.InitTimer();
                }
                this._timer.start();
                this.SwitchSkins();
            }
            else
            {
                if (this._timer)
                {
                    this._timer.stop();
                }
                this.selected = false;
            }
            return;
        }// end function

        private function SwitchSkins(event:Event = null) : void
        {
            this.selected = !this.selected;
            return;
        }// end function

        public function get twinkle() : Boolean
        {
            return this._twinkle;
        }// end function

    }
}
