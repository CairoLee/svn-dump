package org.igniterealtime.xiff.events
{
    import flash.events.*;

    public class PresenceEvent extends Event
    {
        private var _data:Array;
        public static const PRESENCE:String = "presence";

        public function PresenceEvent()
        {
            super(PRESENCE, bubbles, cancelable);
            return;
        }// end function

        public function set data(param1:Array) : void
        {
            _data = param1;
            return;
        }// end function

        public function get data() : Array
        {
            return _data;
        }// end function

        override public function toString() : String
        {
            return "[PresenceEvent type=\"" + type + "\" bubbles=" + bubbles + " cancelable=" + cancelable + " eventPhase=" + eventPhase + "]";
        }// end function

        override public function clone() : Event
        {
            var _loc_1:* = new PresenceEvent();
            _loc_1.data = _data;
            return _loc_1;
        }// end function

    }
}
