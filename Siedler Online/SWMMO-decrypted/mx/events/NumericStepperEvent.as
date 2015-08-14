package mx.events
{
    import flash.events.*;

    public class NumericStepperEvent extends Event
    {
        public var value:Number;
        public var triggerEvent:Event;
        static const VERSION:String = "3.5.0.12683";
        public static const CHANGE:String = "change";

        public function NumericStepperEvent(param1:String, param2:Boolean = false, param3:Boolean = false, param4:Number = NaN, param5:Event = null)
        {
            super(param1, param2, param3);
            this.value = param4;
            this.triggerEvent = param5;
            return;
        }// end function

        override public function clone() : Event
        {
            return new NumericStepperEvent(type, bubbles, cancelable, value);
        }// end function

    }
}
