package mx.events
{
    import flash.events.*;

    public class MoveEvent extends Event
    {
        public var oldX:Number;
        public var oldY:Number;
        static const VERSION:String = "3.5.0.12683";
        public static const MOVE:String = "move";

        public function MoveEvent(param1:String, param2:Boolean = false, param3:Boolean = false, param4:Number = NaN, param5:Number = NaN)
        {
            super(param1, param2, param3);
            this.oldX = param4;
            this.oldY = param5;
            return;
        }// end function

        override public function clone() : Event
        {
            return new MoveEvent(type, bubbles, cancelable, oldX, oldY);
        }// end function

    }
}
