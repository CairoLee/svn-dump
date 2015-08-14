package org.igniterealtime.xiff.events
{
    import flash.events.*;
    import org.igniterealtime.xiff.data.register.*;

    public class RegistrationFieldsEvent extends Event
    {
        private var _fields:Array;
        private var _data:RegisterExtension;
        public static const REG_FIELDS:String = "registrationFields";

        public function RegistrationFieldsEvent()
        {
            super(REG_FIELDS, false, false);
            return;
        }// end function

        public function get fields() : Array
        {
            return _fields;
        }// end function

        public function set data(param1:RegisterExtension) : void
        {
            _data = param1;
            return;
        }// end function

        public function get data() : RegisterExtension
        {
            return _data;
        }// end function

        override public function toString() : String
        {
            return "[RegistrationFieldsEvent type=\"" + type + "\" bubbles=" + bubbles + " cancelable=" + cancelable + " eventPhase=" + eventPhase + "]";
        }// end function

        override public function clone() : Event
        {
            var _loc_1:* = new RegistrationFieldsEvent();
            _loc_1.data = _data;
            _loc_1.fields = _fields;
            return _loc_1;
        }// end function

        public function set fields(param1:Array) : void
        {
            _fields = param1;
            return;
        }// end function

    }
}
