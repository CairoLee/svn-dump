package org.igniterealtime.xiff.events
{
    import flash.events.*;
    import org.igniterealtime.xiff.data.*;

    public class IQEvent extends Event
    {
        private var _iq:IQ;
        private var _data:IExtension;

        public function IQEvent(param1:String)
        {
            super(param1, false, false);
            return;
        }// end function

        public function set iq(param1:IQ) : void
        {
            _iq = param1;
            return;
        }// end function

        public function set data(param1:IExtension) : void
        {
            _data = param1;
            return;
        }// end function

        public function get iq() : IQ
        {
            return _iq;
        }// end function

        public function get data() : IExtension
        {
            return _data;
        }// end function

        override public function toString() : String
        {
            return "[IQEvent type=\"" + type + "\" bubbles=" + bubbles + " cancelable=" + cancelable + " eventPhase=" + eventPhase + "]";
        }// end function

        override public function clone() : Event
        {
            var _loc_1:* = new IQEvent(type);
            _loc_1.data = _data;
            _loc_1.iq = _iq;
            return _loc_1;
        }// end function

    }
}
