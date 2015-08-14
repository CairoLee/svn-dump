package mx.events
{
    import flash.events.*;

    public class SliderEvent extends Event
    {
        public var value:Number;
        public var triggerEvent:Event;
        public var clickTarget:String;
        public var thumbIndex:int;
        public var keyCode:int;
        public static const THUMB_PRESS:String = "thumbPress";
        public static const CHANGE:String = "change";
        static const VERSION:String = "3.5.0.12683";
        public static const THUMB_DRAG:String = "thumbDrag";
        public static const THUMB_RELEASE:String = "thumbRelease";

        public function SliderEvent(param1:String, param2:Boolean = false, param3:Boolean = false, param4:int = -1, param5:Number = NaN, param6:Event = null, param7:String = null, param8:int = -1)
        {
            super(param1, param2, param3);
            this.thumbIndex = param4;
            this.value = param5;
            this.triggerEvent = param6;
            this.clickTarget = param7;
            this.keyCode = param8;
            return;
        }// end function

        override public function clone() : Event
        {
            return new SliderEvent(type, bubbles, cancelable, thumbIndex, value, triggerEvent, clickTarget, keyCode);
        }// end function

    }
}
