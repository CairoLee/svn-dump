package mx.events
{
    import flash.events.*;

    public class ResizeEvent extends Event
    {
        public var oldHeight:Number;
        public var oldWidth:Number;
        static const VERSION:String = "3.5.0.12683";
        public static const RESIZE:String = "resize";

        public function ResizeEvent(param1:String, param2:Boolean = false, param3:Boolean = false, param4:Number = NaN, param5:Number = NaN)
        {
            super(param1, param2, param3);
            this.oldWidth = param4;
            this.oldHeight = param5;
            return;
        }// end function

        override public function clone() : Event
        {
            return new ResizeEvent(type, bubbles, cancelable, oldWidth, oldHeight);
        }// end function

    }
}
