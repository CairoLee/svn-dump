package org.igniterealtime.xiff.events
{
    import flash.events.*;
    import org.igniterealtime.xiff.data.*;

    public class XIFFErrorEvent extends Event
    {
        private var _errorType:String;
        private var _errorCondition:String;
        private var _errorCode:int;
        private var _errorExt:Extension;
        private var _errorMessage:String;
        public static const XIFF_ERROR:String = "error";

        public function XIFFErrorEvent()
        {
            super(XIFF_ERROR, false, false);
            return;
        }// end function

        public function set errorExt(param1:Extension) : void
        {
            _errorExt = param1;
            return;
        }// end function

        public function get errorType() : String
        {
            return _errorType;
        }// end function

        public function set errorMessage(param1:String) : void
        {
            _errorMessage = param1;
            return;
        }// end function

        public function set errorCode(param1:int) : void
        {
            _errorCode = param1;
            return;
        }// end function

        public function set errorType(param1:String) : void
        {
            _errorType = param1;
            return;
        }// end function

        public function set errorCondition(param1:String) : void
        {
            _errorCondition = param1;
            return;
        }// end function

        public function get errorCode() : int
        {
            return _errorCode;
        }// end function

        public function get errorExt() : Extension
        {
            return _errorExt;
        }// end function

        public function get errorCondition() : String
        {
            return _errorCondition;
        }// end function

        override public function toString() : String
        {
            return "[XIFFErrorEvent type=\"" + type + "\" bubbles=" + bubbles + " cancelable=" + cancelable + " eventPhase=" + eventPhase + "]";
        }// end function

        override public function clone() : Event
        {
            var _loc_1:* = new XIFFErrorEvent();
            _loc_1.errorCondition = _errorCondition;
            _loc_1.errorMessage = _errorMessage;
            _loc_1.errorType = _errorType;
            _loc_1.errorCode = _errorCode;
            _loc_1.errorExt = _errorExt;
            return _loc_1;
        }// end function

        public function get errorMessage() : String
        {
            return _errorMessage;
        }// end function

    }
}
