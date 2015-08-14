package GUI.Effects
{
    import mx.effects.*;
    import mx.events.*;

    public class BounceMove extends Move
    {
        private var reversed:Boolean = false;
        public var bounceCount:Number = 0;
        private var _currentBounceCount:Number = 0;
        private var ending:Boolean = false;

        public function BounceMove(param1:Object = null)
        {
            super(param1);
            return;
        }// end function

        override protected function effectEndHandler(event:EffectEvent) : void
        {
            var _loc_2:* = event.effectInstance;
            if (!this.ending && (this._currentBounceCount <= (this.bounceCount + 1) || this.bounceCount == -1) || !this.reversed)
            {
                this.playAgain(this.targets, !this.reversed);
            }
            else
            {
                this.ending = false;
                this._currentBounceCount = 0;
                super.effectEndHandler(event);
                super.end(event.effectInstance);
            }
            return;
        }// end function

        override public function end(param1:IEffectInstance = null) : void
        {
            this.ending = true;
            return;
        }// end function

        private function playAgain(param1:Array = null, param2:Boolean = false) : Array
        {
            var _loc_3:String = this;
            var _loc_4:* = this._currentBounceCount + 1;
            _loc_3._currentBounceCount = _loc_4;
            this.reversed = param2;
            return super.play(param1, param2);
        }// end function

        public function get currentBounceCount() : Number
        {
            return this._currentBounceCount;
        }// end function

        override public function play(param1:Array = null, param2:Boolean = false) : Array
        {
            if (this._currentBounceCount > 0)
            {
                this._currentBounceCount = 0;
                return null;
            }
            var _loc_3:String = this;
            var _loc_4:* = this._currentBounceCount + 1;
            _loc_3._currentBounceCount = _loc_4;
            this.reversed = param2;
            return super.play(param1, param2);
        }// end function

    }
}
