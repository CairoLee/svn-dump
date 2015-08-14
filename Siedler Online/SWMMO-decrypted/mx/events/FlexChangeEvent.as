package mx.events
{
    import flash.events.*;

    public class FlexChangeEvent extends Event
    {
        public var data:Object;
        public static const REMOVE_CHILD_BRIDGE:String = "removeChildBridge";
        static const VERSION:String = "3.5.0.12683";
        public static const ADD_CHILD_BRIDGE:String = "addChildBridge";

        public function FlexChangeEvent(param1:String, param2:Boolean = false, param3:Boolean = false, param4:Object = null)
        {
            super(param1, param2, param3);
            this.data = param4;
            return;
        }// end function

        override public function clone() : Event
        {
            return new FlexChangeEvent(type, bubbles, cancelable, data);
        }// end function

    }
}
