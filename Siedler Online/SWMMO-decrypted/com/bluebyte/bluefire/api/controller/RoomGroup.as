package com.bluebyte.bluefire.api.controller
{
    import com.bluebyte.bluefire.api.event.*;
    import com.bluebyte.bluefire.api.model.vo.*;
    import com.bluebyte.bluefire.puremvc.*;
    import com.bluebyte.bluefire.puremvc.model.*;
    import flash.events.*;
    import mx.collections.*;
    import org.igniterealtime.xiff.conference.*;
    import org.igniterealtime.xiff.core.*;
    import org.igniterealtime.xiff.data.*;
    import org.igniterealtime.xiff.events.*;

    class RoomGroup extends EventDispatcher
    {
        private var _currentInstanceIdx:int = 0;
        private var _autoJoin:Boolean = false;
        private var _lastRoomInstance:int = -1;
        private var _name:String;
        private var _roomJoinRequest:RoomJoinRequestVO;
        private var _connectionProxy:ConnectionProxy;
        private var _currentRoom:Room;
        private var _facade:BlueFireFacade;
        private var _connection:XMPPConnection;
        private var _instances:ArrayCollection;

        function RoomGroup(param1:BlueFireFacade, param2:RoomJoinRequestVO, param3:XMPPConnection)
        {
            this._instances = new ArrayCollection();
            this._facade = param1;
            this._connectionProxy = this._facade.retrieveProxy(ConnectionProxy.NAME) as ConnectionProxy;
            this._roomJoinRequest = param2;
            var _loc_4:* = new SortField();
            new SortField().numeric = true;
            var _loc_5:* = new Sort();
            new Sort().fields = [_loc_4];
            this._instances.sort = _loc_5;
            var _loc_6:* = param2.name.split(this._connectionProxy.CONSTANTS.ROOM_GROUP_SEPERATOR);
            this._name = _loc_6[0];
            this._connection = param3;
            return;
        }// end function

        public function leaveGroupChat() : void
        {
            this._currentRoom.leave();
            this._currentRoom = null;
            return;
        }// end function

        private function autoJoinGroupChat() : void
        {
            this.joinGroupChatInstance(this._instances[this._currentInstanceIdx]);
            var _loc_1:String = this;
            var _loc_2:* = this._currentInstanceIdx + 1;
            _loc_1._currentInstanceIdx = _loc_2;
            if (this._currentInstanceIdx > this._instances.length)
            {
                this._currentInstanceIdx = 0;
            }
            return;
        }// end function

        private function HandleGuildRoomUserLeave(event:RoomEvent) : void
        {
            var _loc_2:* = event.data;
            this._facade.sendNotification(BlueFireFacade.ROOM_OCCUPANT_PRESENCE_UPDATED, new RoomPresenceUpdatedVO(_loc_2.from.resource, _loc_2.from.node, false));
            return;
        }// end function

        private function handleRoomMaxUsers(event:RoomEvent) : void
        {
            this._currentRoom.removeEventListener(RoomEvent.ROOM_JOIN, this.handleRoomJoin);
            this._currentRoom.removeEventListener(RoomEvent.MAX_USERS_ERROR, this.handleRoomMaxUsers);
            this._currentRoom.removeEventListener(RoomEvent.ROOM_LEAVE, this.handleRoomLeave);
            if (this._lastRoomInstance == -1)
            {
                this.autoJoinGroupChat();
            }
            else
            {
                this.joinGroupChatInstance(this._lastRoomInstance);
            }
            return;
        }// end function

        public function get name() : String
        {
            return this._name;
        }// end function

        public function join() : void
        {
            this.autoJoinGroupChat();
            return;
        }// end function

        public function addRoomInstance(param1:int = -1) : void
        {
            var _loc_2:int = 0;
            for each (_loc_2 in this._instances)
            {
                
                if (_loc_2 == param1)
                {
                    return;
                }
            }
            this._instances.addItem(param1);
            this._instances.refresh();
            return;
        }// end function

        public function get autojoin() : Boolean
        {
            return this._autoJoin;
        }// end function

        private function handleRoomLeave(event:RoomEvent) : void
        {
            var _loc_2:* = new RoomManagerEvent(RoomEvent.ROOM_LEAVE);
            _loc_2.data = event.target;
            this.dispatchEvent(_loc_2);
            return;
        }// end function

        public function isInstancePresent(param1:int) : Boolean
        {
            var _loc_2:int = 0;
            for each (_loc_2 in this._instances)
            {
                
                if (_loc_2 == param1)
                {
                    return true;
                }
            }
            return false;
        }// end function

        public function joinGroupChatInstance(param1:int) : void
        {
            if (this._currentRoom && this._currentRoom.isActive)
            {
                this._currentRoom.leave();
            }
            this._currentRoom = new Room(this._connection);
            if (param1 != -1)
            {
                this._currentRoom.roomJID = new UnescapedJID(this._name + this._connectionProxy.CONSTANTS.ROOM_GROUP_SEPERATOR + param1 + "@conference." + this._connectionProxy.server.ip);
            }
            else
            {
                this._currentRoom.roomJID = new UnescapedJID(this._name + "@conference." + this._connectionProxy.server.ip);
            }
            this._currentRoom.addEventListener(RoomEvent.ROOM_JOIN, this.handleRoomJoin);
            this._currentRoom.addEventListener(RoomEvent.MAX_USERS_ERROR, this.handleRoomMaxUsers);
            this._currentRoom.addEventListener(RoomEvent.ROOM_LEAVE, this.handleRoomLeave);
            if (this._roomJoinRequest.useForOnlineStatus)
            {
                this._currentRoom.addEventListener(RoomEvent.USER_JOIN, this.HandleGuildRoomUserJoin);
                this._currentRoom.addEventListener(RoomEvent.USER_DEPARTURE, this.HandleGuildRoomUserLeave);
            }
            this._currentRoom.join();
            return;
        }// end function

        private function handleRoomError(event:RoomEvent) : void
        {
            return;
        }// end function

        private function handleRoomJoin(event:RoomEvent) : void
        {
            var _loc_4:RoomOccupant = null;
            var _loc_2:* = Room(event.target);
            this._lastRoomInstance = -1;
            if (_loc_2.roomName.split(this._connectionProxy.CONSTANTS.ROOM_GROUP_SEPERATOR).length > 1)
            {
                this._lastRoomInstance = _loc_2.roomName.split(this._connectionProxy.CONSTANTS.ROOM_GROUP_SEPERATOR)[1];
            }
            if (this._roomJoinRequest.useForOnlineStatus)
            {
                for each (_loc_4 in _loc_2.source)
                {
                    
                    this._facade.sendNotification(BlueFireFacade.ROOM_OCCUPANT_PRESENCE_UPDATED, new RoomPresenceUpdatedVO(_loc_4.displayName, _loc_2.roomName, true));
                }
            }
            var _loc_3:* = new RoomManagerEvent(RoomEvent.ROOM_JOIN);
            _loc_3.data = event.target;
            this.dispatchEvent(_loc_3);
            return;
        }// end function

        public function set autojoin(param1:Boolean) : void
        {
            this._autoJoin = param1;
            return;
        }// end function

        private function HandleGuildRoomUserJoin(event:RoomEvent) : void
        {
            var _loc_2:* = event.data;
            this._facade.sendNotification(BlueFireFacade.ROOM_OCCUPANT_PRESENCE_UPDATED, new RoomPresenceUpdatedVO(_loc_2.from.resource, _loc_2.from.node, true));
            return;
        }// end function

    }
}
