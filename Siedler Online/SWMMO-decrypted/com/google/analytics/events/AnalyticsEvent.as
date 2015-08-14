package com.google.analytics.events
{
    import com.google.analytics.*;
    import flash.events.*;

    public class AnalyticsEvent extends Event
    {
        public var tracker:AnalyticsTracker;
        public static const READY:String = "ready";

        public function AnalyticsEvent(param1:String, param2:AnalyticsTracker, param3:Boolean = false, param4:Boolean = false)
        {
            super(param1, param3, param4);
            this.tracker = param2;
            return;
        }// end function

        override public function clone() : Event
        {
            return new AnalyticsEvent(type, tracker, bubbles, cancelable);
        }// end function

    }
}
