package GUI.Components
{
    import GO.*;
    import flash.display.*;
    import flash.events.*;
    import flash.geom.*;
    import mx.controls.*;
    import nLib.*;

    public class SpriteLibAnimation extends Image
    {
        private var _spriteLib:cSpriteLib;
        private var _loop:Boolean = false;
        private var _speed:Number;
        private var _frame:int = -1;
        private var _point:Point;
        private var _animationName:String;
        private var _bitmapData:BitmapData;

        public function SpriteLibAnimation()
        {
            this._point = new Point(0, 0);
            this.addEventListener(Event.ADDED_TO_STAGE, this.init);
            return;
        }// end function

        public function get loop() : Boolean
        {
            return this._loop;
        }// end function

        private function render() : void
        {
            this._frame = this._spriteLib.GetAnimFrame();
            if (this._frame >= (this._spriteLib.GetNofFrames(0) - 1))
            {
                if (!this._loop)
                {
                    this.visible = false;
                }
            }
            this._bitmapData.fillRect(this._bitmapData.rect, 0);
            this._bitmapData.copyPixels(this._spriteLib.GetBitmapFromSubTypeAndFrame(0, this._frame), this._bitmapData.rect, this._point, null, null, false);
            return;
        }// end function

        override public function set visible(param1:Boolean) : void
        {
            if (param1)
            {
                this.addEventListener(Event.ENTER_FRAME, this.animate);
                this._spriteLib.SetAnim(this._speed, this._loop);
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

        public function set loop(param1:Boolean) : void
        {
            this._loop = param1;
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

        public function get animationName() : String
        {
            return this._animationName;
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

        public function set animationName(param1:String) : void
        {
            this._animationName = param1;
            return;
        }// end function

    }
}
