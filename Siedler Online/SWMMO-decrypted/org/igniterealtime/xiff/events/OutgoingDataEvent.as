package org.igniterealtime.xiff.events
{
    import flash.events.*;
    import flash.utils.*;

    public class OutgoingDataEvent extends Event
    {
        private var _data:ByteArray;
        public static const OUTGOING_DATA:String = "outgoingData";

        public function OutgoingDataEvent()
        {
            super(OUTGOING_DATA, false, false);
            return;
        }// end function

        public function set data(param1:ByteArray) : void
        {
            _data = param1;
            return;
        }// end function

        public function get data() : ByteArray
        {
            return _data;
        }// end function

        override public function toString() : String
        {
            return "[OutgoingDataEvent type=\"" + type + "\" bubbles=" + bubbles + " cancelable=" + cancelable + " eventPhase=" + eventPhase + "]";
        }// end function

        override public function clone() : Event
        {
            var _loc_1:* = new OutgoingDataEvent();
            _loc_1.data = _data;
            return _loc_1;
        }// end function

    }
}
