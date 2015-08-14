package com.google.analytics.core
{
    import com.google.analytics.data.*;
    import com.google.analytics.utils.*;

    public class EventInfo extends Object
    {
        private var _ext10:X10;
        private var _isEventHit:Boolean;
        private var _x10:X10;

        public function EventInfo(param1:Boolean, param2:X10, param3:X10 = null)
        {
            _isEventHit = param1;
            _x10 = param2;
            _ext10 = param3;
            return;
        }// end function

        public function toURLString() : String
        {
            var _loc_1:* = toVariables();
            return _loc_1.toString();
        }// end function

        public function get utmt() : String
        {
            return "event";
        }// end function

        public function get utme() : String
        {
            return _x10.renderMergedUrlString(_ext10);
        }// end function

        public function toVariables() : Variables
        {
            var _loc_1:* = new Variables();
            _loc_1.URIencode = true;
            if (_isEventHit)
            {
                _loc_1.utmt = utmt;
            }
            _loc_1.utme = utme;
            return _loc_1;
        }// end function

    }
}
