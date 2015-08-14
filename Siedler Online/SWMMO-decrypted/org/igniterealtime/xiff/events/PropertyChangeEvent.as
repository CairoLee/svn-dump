package org.igniterealtime.xiff.events
{
    import flash.events.*;

    public class PropertyChangeEvent extends Event
    {
        private var _oldValue:Object;
        private var _name:String;
        private var _newValue:Object;
        public static const CHANGE:String = "change";

        public function PropertyChangeEvent(param1:String, param2:Boolean = false, param3:Boolean = false)
        {
            super(param1, param2, param3);
            return;
        }// end function

        public function set newValue(param1) : void
        {
            _newValue = param1;
            return;
        }// end function

        public function get name()
        {
            return _name;
        }// end function

        override public function toString() : String
        {
            return "[PropertyChangeEvent type=\"" + type + "\" bubbles=" + bubbles + " cancelable=" + cancelable + " eventPhase=" + eventPhase + "]";
        }// end function

        public function get newValue()
        {
            return _newValue;
        }// end function

        public function set name(param1) : void
        {
            _name = param1;
            return;
        }// end function

        public function get oldValue()
        {
            return _oldValue;
        }// end function

        public function set oldValue(param1) : void
        {
            _oldValue = param1;
            return;
        }// end function

        override public function clone() : Event
        {
            var _loc_1:* = new PropertyChangeEvent(type, bubbles, cancelable);
            _loc_1.name = _name;
            _loc_1.newValue = _newValue;
            _loc_1.oldValue = _oldValue;
            return _loc_1;
        }// end function

    }
}
