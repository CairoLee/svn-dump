package com.google.analytics.core
{
    import flash.net.*;
    import flash.utils.*;

    public class RequestObject extends Object
    {
        public var start:int;
        public var end:int;
        public var request:URLRequest;

        public function RequestObject(param1:URLRequest)
        {
            start = getTimer();
            this.request = param1;
            return;
        }// end function

        public function hasCompleted() : Boolean
        {
            return end > 0;
        }// end function

        public function toString() : String
        {
            var _loc_1:Array = [];
            _loc_1.push("duration: " + duration + "ms");
            _loc_1.push("url: " + request.url);
            return "{ " + _loc_1.join(", ") + " }";
        }// end function

        public function complete() : void
        {
            end = getTimer();
            return;
        }// end function

        public function get duration() : int
        {
            if (!hasCompleted())
            {
                return 0;
            }
            return end - start;
        }// end function

    }
}
