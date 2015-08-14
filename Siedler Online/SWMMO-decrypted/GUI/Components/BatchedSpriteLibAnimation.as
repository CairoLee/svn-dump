package GUI.Components
{
    import GO.*;
    import __AS3__.vec.*;
    import flash.display.*;
    import flash.events.*;
    import flash.geom.*;
    import mx.controls.*;
    import nLib.*;

    public class BatchedSpriteLibAnimation extends Image
    {
        private var _spriteLib:cSpriteLib;
        private var _subTypes:Vector.<int>;
        private var _speed:Number;
        private var _points:Vector.<Point>;
        private var _maxOffset:int;
        private var _animationName:String;
        private var _bitmapData:BitmapData;
        private var _maxFrames:int;
        private var _frameOffsets:Vector.<int>;
        private var _frame:int = -1;
        private var _offsetFrames:int;
        private var _numInstances:int;

        public function BatchedSpriteLibAnimation()
        {
            this.addEventListener(Event.ADDED_TO_STAGE, this.init);
            return;
        }// end function

        public function init(event:Event = null) : void
        {
            this._spriteLib = global.effectGroup.GetSpriteLibFromNameGOList(this._animationName);
            this._speed = (this._spriteLib.GetContainer() as cGOSpriteLibContainer).mEffectDefaultAnimSpeed;
            this._bitmapData = new BitmapData(this.width, this.height, true, 0);
            this.source = new Bitmap(this._bitmapData);
            return;
        }// end function

        public function get offsetFrames() : int
        {
            return this._offsetFrames;
        }// end function

        public function set animationName(param1:String) : void
        {
            this._animationName = param1;
            return;
        }// end function

        private function animate(event:Event) : void
        {
            this._spriteLib.Animate(global.ui.mCalculateTicks.mDeltaTicksOne);
            if (this._frame != int(this._spriteLib.GetAnimFrame()))
            {
                this.render();
            }
            return;
        }// end function

        private function render() : void
        {
            var _loc_2:int = 0;
            this._bitmapData.fillRect(this._bitmapData.rect, 0);
            if (this._frame >= this._spriteLib.GetNofFrames(0) + this._maxOffset - 1)
            {
                this.visible = false;
                return;
            }
            var _loc_1:int = 0;
            while (_loc_1 < this._points.length)
            {
                
                _loc_2 = this._frame + this._frameOffsets[_loc_1];
                if (_loc_2 >= 0 && _loc_2 <= (this._spriteLib.GetNofFrames(0) - 1))
                {
                    this._bitmapData.copyPixels(this._spriteLib.GetBitmapFromSubTypeAndFrame(this._subTypes[_loc_1], _loc_2), this._bitmapData.rect, this._points[_loc_1], null, null, true);
                }
                var _loc_3:* = this._frameOffsets;
                var _loc_4:* = _loc_1;
                var _loc_5:* = this._frameOffsets[_loc_1] + 1;
                _loc_3[_loc_4] = _loc_5;
                _loc_1++;
            }
            var _loc_3:String = this;
            var _loc_4:* = this._frame + 1;
            _loc_3._frame = _loc_4;
            return;
        }// end function

        public function get numInstances() : int
        {
            return this._numInstances;
        }// end function

        public function set numInstances(param1:int) : void
        {
            this._numInstances = param1;
            return;
        }// end function

        public function get animationName() : String
        {
            return this._animationName;
        }// end function

        public function set offsetFrames(param1:int) : void
        {
            this._offsetFrames = param1;
            return;
        }// end function

        override public function set visible(param1:Boolean) : void
        {
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            if (param1)
            {
                this._points = new Vector.<Point>;
                this._frameOffsets = new Vector.<int>;
                this._subTypes = new Vector.<int>;
                _loc_2 = 0;
                while (_loc_2 < this._numInstances)
                {
                    
                    _loc_3 = int(Math.random() * this._spriteLib.GetNofSubTypes());
                    _loc_4 = this._spriteLib.GetMaxWidthForSubType(_loc_3);
                    _loc_5 = this._spriteLib.GetMaxHeightForSubType(_loc_3);
                    _loc_6 = Math.round(Math.random() * ((this.width - _loc_4) / _loc_4));
                    _loc_7 = Math.round(Math.random() * ((this.height - _loc_5) / _loc_5));
                    this._points.push(new Point(_loc_6 * _loc_4, _loc_7 * _loc_5));
                    this._frameOffsets.push(_loc_2 * this._offsetFrames * -1);
                    this._subTypes.push(_loc_3);
                    _loc_2++;
                }
                this._maxOffset = this._numInstances * this._offsetFrames - this._offsetFrames;
                this.addEventListener(Event.ENTER_FRAME, this.animate);
                this._spriteLib.SetAnim(this._speed, true);
                this._frame = 0;
                this.render();
            }
            else
            {
                this.removeEventListener(Event.ENTER_FRAME, this.animate);
            }
            super.visible = param1;
            return;
        }// end function

    }
}
