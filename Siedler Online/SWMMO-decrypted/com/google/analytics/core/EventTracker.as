package com.google.analytics.core
{
    import com.google.analytics.v4.*;

    public class EventTracker extends Object
    {
        private var _parent:GoogleAnalyticsAPI;
        public var name:String;

        public function EventTracker(param1:String, param2:GoogleAnalyticsAPI)
        {
            this.name = param1;
            _parent = param2;
            return;
        }// end function

        public function trackEvent(param1:String, param2:String = null, param3:Number = NaN) : Boolean
        {
            return _parent.trackEvent(name, param1, param2, param3);
        }// end function

    }
}
