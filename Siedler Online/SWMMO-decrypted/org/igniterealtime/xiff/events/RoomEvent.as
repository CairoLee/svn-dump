package org.igniterealtime.xiff.events
{
    import flash.events.*;

    public class RoomEvent extends Event
    {
        private var _from:String;
        private var _nickname:String;
        private var _data:Object;
        private var _errorCode:uint;
        private var _errorCondition:String;
        private var _errorType:String;
        private var _subject:String;
        private var _reason:String;
        private var _errorMessage:String;
        public static const AFFILIATIONS:String = "affiliations";
        public static const PASSWORD_ERROR:String = "passwordError";
        public static const BANNED_ERROR:String = "bannedError";
        public static const SUBJECT_CHANGE:String = "subjectChange";
        public static const PRIVATE_MESSAGE:String = "privateMessage";
        public static const USER_BANNED:String = "userBanned";
        public static const MAX_USERS_ERROR:String = "maxUsersError";
        public static const ADMIN_ERROR:String = "adminError";
        public static const USER_KICKED:String = "userKicked";
        public static const USER_JOIN:String = "userJoin";
        public static const GROUP_MESSAGE:String = "groupMessage";
        public static const USER_DEPARTURE:String = "userDeparture";
        public static const REGISTRATION_REQ_ERROR:String = "registrationReqError";
        public static const CONFIGURE_ROOM_COMPLETE:String = "configureRoomComplete";
        public static const USER_PRESENCE_CHANGE:String = "userPresenceChange";
        public static const ROOM_DESTROYED:String = "roomDestroyed";
        public static const DECLINED:String = "declined";
        public static const LOCKED_ERROR:String = "lockedError";
        public static const CONFIGURE_ROOM:String = "configureRoom";
        public static const NICK_CONFLICT:String = "nickConflict";
        public static const AFFILIATION_CHANGE_COMPLETE:String = "affiliationChangeComplete";
        public static const ROOM_LEAVE:String = "roomLeave";
        public static const ROOM_JOIN:String = "roomJoin";

        public function RoomEvent(param1:String, param2:Boolean = false, param3:Boolean = false)
        {
            super(param1, param2, param3);
            return;
        }// end function

        public function set errorType(param1:String) : void
        {
            _errorType = param1;
            return;
        }// end function

        public function set errorMessage(param1:String) : void
        {
            _errorMessage = param1;
            return;
        }// end function

        public function set reason(param1:String) : void
        {
            _reason = param1;
            return;
        }// end function

        public function get reason() : String
        {
            return _reason;
        }// end function

        override public function toString() : String
        {
            return "[RoomEvent type=\"" + type + "\" bubbles=" + bubbles + " cancelable=" + cancelable + " eventPhase=" + eventPhase + "]";
        }// end function

        public function set data(param1) : void
        {
            _data = param1;
            return;
        }// end function

        public function set subject(param1:String) : void
        {
            _subject = param1;
            return;
        }// end function

        public function set from(param1:String) : void
        {
            _from = param1;
            return;
        }// end function

        public function get errorCode() : uint
        {
            return _errorCode;
        }// end function

        override public function clone() : Event
        {
            var _loc_1:* = new RoomEvent(type, bubbles, cancelable);
            _loc_1.subject = _subject;
            _loc_1.data = _data;
            _loc_1.errorCondition = _errorCondition;
            _loc_1.errorMessage = _errorMessage;
            _loc_1.errorType = _errorType;
            _loc_1.errorCode = _errorCode;
            _loc_1.nickname = _nickname;
            _loc_1.from = _from;
            _loc_1.reason = _reason;
            return _loc_1;
        }// end function

        public function get errorMessage() : String
        {
            return _errorMessage;
        }// end function

        public function get errorType() : String
        {
            return _errorType;
        }// end function

        public function set errorCondition(param1:String) : void
        {
            _errorCondition = param1;
            return;
        }// end function

        public function set errorCode(param1:uint) : void
        {
            _errorCode = param1;
            return;
        }// end function

        public function set nickname(param1:String) : void
        {
            _nickname = param1;
            return;
        }// end function

        public function get nickname() : String
        {
            return _nickname;
        }// end function

        public function get data()
        {
            return _data;
        }// end function

        public function get errorCondition() : String
        {
            return _errorCondition;
        }// end function

        public function get from() : String
        {
            return _from;
        }// end function

        public function get subject() : String
        {
            return _subject;
        }// end function

    }
}
