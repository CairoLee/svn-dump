package org.igniterealtime.xiff.events
{
    import flash.events.*;
    import flash.utils.*;

    public class IncomingDataEvent extends Event
    {
        private var _data:ByteArray;
        public static const INCOMING_DATA:String = "incomingData";

        public function IncomingDataEvent()
        {
            super(INCOMING_DATA, false, false);
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
            return "[IncomingDataEvent type=\"" + type + "\" bubbles=" + bubbles + " cancelable=" + cancelable + " eventPhase=" + eventPhase + "]";
        }// end function

        override public function clone() : Event
        {
            var _loc_1:* = new IncomingDataEvent();
            _loc_1.data = _data;
            return _loc_1;
        }// end function

    }
}
