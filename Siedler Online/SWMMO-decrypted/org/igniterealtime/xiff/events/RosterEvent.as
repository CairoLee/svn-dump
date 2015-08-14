package org.igniterealtime.xiff.events
{
    import flash.events.*;
    import org.igniterealtime.xiff.core.*;

    public class RosterEvent extends Event
    {
        private var _jid:UnescapedJID;
        private var _data:Object;
        public static const SUBSCRIPTION_REVOCATION:String = "subscriptionRevocation";
        public static const USER_UNAVAILABLE:String = "userUnavailable";
        public static const SUBSCRIPTION_DENIAL:String = "subscriptionDenial";
        public static const USER_PRESENCE_UPDATED:String = "userPresenceUpdated";
        public static const USER_ADDED:String = "userAdded";
        public static const SUBSCRIPTION_REQUEST:String = "subscriptionRequest";
        public static const USER_REMOVED:String = "userRemoved";
        public static const USER_SUBSCRIPTION_UPDATED:String = "userSubscriptionUpdated";
        public static const USER_AVAILABLE:String = "userAvailable";
        public static const ROSTER_LOADED:String = "rosterLoaded";

        public function RosterEvent(param1:String, param2:Boolean = false, param3:Boolean = false)
        {
            super(param1, param2, param3);
            return;
        }// end function

        public function set jid(param1:UnescapedJID) : void
        {
            _jid = param1;
            return;
        }// end function

        public function set data(param1) : void
        {
            _data = param1;
            return;
        }// end function

        public function get jid() : UnescapedJID
        {
            return _jid;
        }// end function

        public function get data()
        {
            return _data;
        }// end function

        override public function toString() : String
        {
            return "[RosterEvent type=\"" + type + "\" bubbles=" + bubbles + " cancelable=" + cancelable + " eventPhase=" + eventPhase + "]";
        }// end function

        override public function clone() : Event
        {
            var _loc_1:* = new RosterEvent(type, bubbles, cancelable);
            _loc_1.data = _data;
            _loc_1.jid = _jid;
            return _loc_1;
        }// end function

    }
}
