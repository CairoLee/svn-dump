package org.igniterealtime.xiff.conference
{
    import flash.events.*;
    import org.igniterealtime.xiff.core.*;
    import org.igniterealtime.xiff.data.im.*;

    public class RoomOccupant extends EventDispatcher implements Contact
    {
        private var _jid:UnescapedJID;
        private var _nickname:String;
        private var _uid:String;
        private var _role:String;
        private var _show:String;
        private var _affiliation:String;
        private var _room:Room;

        public function RoomOccupant(param1:String, param2:String, param3:String, param4:String, param5:UnescapedJID, param6:Room)
        {
            this.displayName = param1;
            this.show = param2;
            this.affiliation = param3;
            this.role = param4;
            this.jid = param5;
            _room = param6;
            return;
        }// end function

        public function set show(param1:String) : void
        {
            _show = param1;
            return;
        }// end function

        public function get show() : String
        {
            return _show;
        }// end function

        public function get jid() : UnescapedJID
        {
            return _jid;
        }// end function

        public function get uid() : String
        {
            return _uid;
        }// end function

        public function get online() : Boolean
        {
            return true;
        }// end function

        public function set jid(param1:UnescapedJID) : void
        {
            _jid = param1;
            return;
        }// end function

        public function get room() : Room
        {
            return _room;
        }// end function

        public function set affiliation(param1:String) : void
        {
            _affiliation = param1;
            return;
        }// end function

        public function set online(param1:Boolean) : void
        {
            return;
        }// end function

        public function set uid(param1:String) : void
        {
            _uid = param1;
            return;
        }// end function

        public function set role(param1:String) : void
        {
            _role = param1;
            return;
        }// end function

        public function get displayName() : String
        {
            return _nickname;
        }// end function

        public function get affiliation() : String
        {
            return _affiliation;
        }// end function

        public function set displayName(param1:String) : void
        {
            _nickname = param1;
            return;
        }// end function

        public function get role() : String
        {
            return _role;
        }// end function

        public function set room(param1:Room) : void
        {
            _room = param1;
            return;
        }// end function

        public function get rosterItem() : RosterItemVO
        {
            if (!_jid)
            {
                return null;
            }
            return RosterItemVO.get(_jid, true);
        }// end function

    }
}
