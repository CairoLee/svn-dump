package org.igniterealtime.xiff.data.im
{
    import flash.events.*;
    import org.igniterealtime.xiff.core.*;
    import org.igniterealtime.xiff.data.im.*;
    import org.igniterealtime.xiff.events.*;

    public class RosterItemVO extends EventDispatcher implements Contact
    {
        private var _priority:int;
        private var _jid:UnescapedJID;
        private var _status:String;
        private var _askType:String;
        private var _show:String;
        private var _subscribeType:String;
        private var _displayName:String;
        private var _online:Boolean = false;
        private var _groups:Array;
        private static var allContacts:Object = {};

        public function RosterItemVO(param1:UnescapedJID)
        {
            _groups = [];
            jid = param1;
            return;
        }// end function

        public function set show(param1:String) : void
        {
            var _loc_2:* = show;
            _show = param1;
            dispatchChangeEvent("show", _show, _loc_2);
            return;
        }// end function

        public function get jid() : UnescapedJID
        {
            return _jid;
        }// end function

        public function get subscribeType() : String
        {
            return _subscribeType;
        }// end function

        public function set priority(param1:int) : void
        {
            var _loc_2:* = priority;
            _priority = param1;
            dispatchChangeEvent("priority", _priority, _loc_2);
            return;
        }// end function

        public function get uid() : String
        {
            return _jid.toString();
        }// end function

        public function get askType() : String
        {
            return _askType;
        }// end function

        public function get pending() : Boolean
        {
            return askType == RosterExtension.ASK_TYPE_SUBSCRIBE && (subscribeType == RosterExtension.SUBSCRIBE_TYPE_NONE || subscribeType == RosterExtension.SUBSCRIBE_TYPE_FROM);
        }// end function

        public function set jid(param1:UnescapedJID) : void
        {
            var _loc_2:* = _jid;
            _jid = param1;
            if (!_displayName)
            {
                dispatchChangeEvent("jid", param1, _loc_2);
            }
            return;
        }// end function

        public function set displayName(param1:String) : void
        {
            var _loc_2:* = displayName;
            _displayName = param1;
            dispatchChangeEvent("displayName", displayName, _loc_2);
            return;
        }// end function

        public function set subscribeType(param1:String) : void
        {
            var _loc_2:* = subscribeType;
            _subscribeType = param1;
            dispatchChangeEvent("subscribeType", _subscribeType, _loc_2);
            return;
        }// end function

        public function set uid(param1:String) : void
        {
            return;
        }// end function

        public function set status(param1:String) : void
        {
            var _loc_2:* = status;
            _status = param1;
            dispatchChangeEvent("status", _status, _loc_2);
            return;
        }// end function

        public function get online() : Boolean
        {
            return _online;
        }// end function

        override public function toString() : String
        {
            return jid.toString();
        }// end function

        private function dispatchChangeEvent(param1:String, param2, param3) : void
        {
            var _loc_4:* = new PropertyChangeEvent(PropertyChangeEvent.CHANGE);
            new PropertyChangeEvent(PropertyChangeEvent.CHANGE).name = param1;
            _loc_4.newValue = param2;
            _loc_4.oldValue = param3;
            dispatchEvent(_loc_4);
            return;
        }// end function

        public function get displayName() : String
        {
            return _displayName ? (_displayName) : (_jid.node);
        }// end function

        public function set askType(param1:String) : void
        {
            var _loc_2:* = askType;
            var _loc_3:* = pending;
            _askType = param1;
            dispatchChangeEvent("askType", askType, _loc_2);
            dispatchChangeEvent("pending", pending, _loc_3);
            return;
        }// end function

        public function get status() : String
        {
            if (!online)
            {
                return "Offline";
            }
            return _status ? (_status) : ("Available");
        }// end function

        public function get priority() : int
        {
            return _priority;
        }// end function

        public function get show() : String
        {
            return _show;
        }// end function

        public function set online(param1:Boolean) : void
        {
            if (param1 == online)
            {
                return;
            }
            var _loc_2:* = online;
            _online = param1;
            dispatchChangeEvent("online", _online, _loc_2);
            return;
        }// end function

        public static function get(param1:UnescapedJID, param2:Boolean = false) : RosterItemVO
        {
            var _loc_3:* = param1.bareJID;
            var _loc_4:* = allContacts[_loc_3];
            if (!allContacts[_loc_3] && param2)
            {
                var _loc_5:* = new RosterItemVO(new UnescapedJID(_loc_3));
                _loc_4 = new RosterItemVO(new UnescapedJID(_loc_3));
                allContacts[_loc_3] = _loc_5;
            }
            return _loc_4;
        }// end function

    }
}
