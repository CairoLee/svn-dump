package com.bluebyte.bluefire.api.controller
{
    import __AS3__.vec.*;
    import com.bluebyte.bluefire.api.event.*;
    import com.bluebyte.bluefire.api.model.vo.*;
    import com.bluebyte.bluefire.puremvc.*;
    import com.bluebyte.bluefire.puremvc.model.*;
    import flash.events.*;
    import mx.collections.*;
    import org.igniterealtime.xiff.core.*;
    import org.igniterealtime.xiff.data.*;
    import org.igniterealtime.xiff.data.disco.*;
    import org.igniterealtime.xiff.events.*;

    public class RoomManager extends EventDispatcher
    {
        private var _pendingRoomsToJoin:ArrayCollection;
        private var _roomGroups:Vector.<RoomGroup>;
        private var _connectionProxy:ConnectionProxy;
        private var _joinRoomInProgress:Boolean = false;
        private var _facade:BlueFireFacade;
        private var _connection:XMPPConnection;

        public function RoomManager(param1:BlueFireFacade, param2:XMPPConnection)
        {
            this._roomGroups = new Vector.<RoomGroup>;
            this._pendingRoomsToJoin = new ArrayCollection();
            this._connection = param2;
            this._facade = param1;
            this._connectionProxy = this._facade.retrieveProxy(ConnectionProxy.NAME) as ConnectionProxy;
            return;
        }// end function

        public function joinRoomExplicit(param1:RoomJoinRequestVO) : void
        {
            var _loc_2:* = param1.name.split(this._connectionProxy.CONSTANTS.ROOM_GROUP_SEPERATOR);
            var _loc_3:* = this.findRoomGroupByName(_loc_2[0]);
            if (!_loc_3)
            {
                _loc_3 = new RoomGroup(this._facade as BlueFireFacade, param1, this._connection);
                _loc_3.addEventListener(RoomEvent.ROOM_JOIN, this.handleRoomJoin);
                _loc_3.addEventListener(RoomEvent.ROOM_LEAVE, this.handleRoomLeave);
                if (_loc_2.length > 1)
                {
                    _loc_3.addRoomInstance(_loc_2[1]);
                }
                else
                {
                    _loc_3.addRoomInstance(-1);
                }
                this._roomGroups.push(_loc_3);
            }
            var _loc_4:int = -1;
            if (_loc_2.length != 1)
            {
                _loc_4 = int(_loc_2[1]);
            }
            _loc_3.joinGroupChatInstance(_loc_4);
            return;
        }// end function

        public function setChannelAutoJoin(param1:String, param2:Boolean) : void
        {
            var _loc_3:* = param1.split(this._connectionProxy.CONSTANTS.ROOM_GROUP_SEPERATOR);
            var _loc_4:* = _loc_3[0];
            var _loc_5:* = this.findRoomGroupByName(_loc_4);
            if (!this.findRoomGroupByName(_loc_4))
            {
                _loc_5 = new RoomGroup(this._facade, new RoomJoinRequestVO(_loc_4), this._connection);
                _loc_5.addEventListener(RoomEvent.ROOM_JOIN, this.handleRoomJoin);
                _loc_5.addEventListener(RoomEvent.ROOM_LEAVE, this.handleRoomLeave);
                if (_loc_3.length > 1)
                {
                    _loc_5.addRoomInstance(_loc_3[1]);
                }
                else
                {
                    _loc_5.addRoomInstance(-1);
                }
                this._roomGroups.push(_loc_5);
            }
            _loc_5.autojoin = param2;
            return;
        }// end function

        private function findRoomGroupByName(param1:String) : RoomGroup
        {
            var _loc_2:RoomGroup = null;
            for each (_loc_2 in this._roomGroups)
            {
                
                if (_loc_2.name == param1)
                {
                    return _loc_2;
                }
            }
            return null;
        }// end function

        public function leaveRoomByCommand(param1:String) : int
        {
            var _loc_2:* = param1.split(this._connectionProxy.CONSTANTS.ROOM_GROUP_SEPERATOR);
            var _loc_3:* = this.findRoomGroupByName(_loc_2[0]);
            if (!_loc_3)
            {
                return 0;
            }
            var _loc_4:int = -1;
            if (_loc_2.length != 1)
            {
                _loc_4 = int(_loc_2[1]);
            }
            if (!_loc_3.isInstancePresent(_loc_4))
            {
                return 0;
            }
            _loc_3.leaveGroupChat();
            return 1;
        }// end function

        public function resetJoinInProgress() : void
        {
            this._joinRoomInProgress = false;
            return;
        }// end function

        private function handleRoomJoin(event:RoomManagerEvent) : void
        {
            if (this._pendingRoomsToJoin.getItemIndex(event.target) != -1)
            {
                this._pendingRoomsToJoin.removeItemAt(this._pendingRoomsToJoin.getItemIndex(event.target));
            }
            this.dispatchEvent(event);
            if (this._pendingRoomsToJoin.length > 0)
            {
                this._pendingRoomsToJoin[0].join();
            }
            else
            {
                dispatchEvent(new RoomManagerEvent(RoomManagerEvent.ALL_ROOMS_JOINED));
            }
            return;
        }// end function

        public function joinRoomByCommand(param1:String) : int
        {
            if (this._joinRoomInProgress)
            {
                return 2;
            }
            var _loc_2:* = param1.split(this._connectionProxy.CONSTANTS.ROOM_GROUP_SEPERATOR);
            var _loc_3:* = this.findRoomGroupByName(_loc_2[0]);
            if (!_loc_3)
            {
                return 0;
            }
            var _loc_4:int = -1;
            if (_loc_2.length != 1)
            {
                _loc_4 = int(_loc_2[1]);
            }
            if (!_loc_3.isInstancePresent(_loc_4))
            {
                return 0;
            }
            _loc_3.joinGroupChatInstance(_loc_4);
            this._joinRoomInProgress = true;
            return 1;
        }// end function

        private function handleRoomLeave(event:RoomManagerEvent) : void
        {
            this.dispatchEvent(event);
            return;
        }// end function

        public function joinRooms() : void
        {
            var _loc_1:* = new Browser(this._connection);
            _loc_1.getServiceItems(new EscapedJID("conference." + this._connectionProxy.server.ip), this.getRoomNames);
            return;
        }// end function

        public function getRoomNames(param1:IQ) : void
        {
            var _loc_4:RoomGroup = null;
            var _loc_5:ItemDiscoExtension = null;
            var _loc_6:Array = null;
            var _loc_7:uint = 0;
            var _loc_8:RoomGroup = null;
            var _loc_9:Object = null;
            var _loc_10:String = null;
            var _loc_11:Array = null;
            var _loc_12:String = null;
            var _loc_13:int = 0;
            var _loc_2:* = param1.getAllExtensions();
            var _loc_3:int = 0;
            while (_loc_3 < _loc_2.length)
            {
                
                _loc_5 = _loc_2[_loc_3];
                _loc_6 = _loc_5.items;
                _loc_7 = 0;
                while (_loc_7 < _loc_6.length)
                {
                    
                    _loc_8 = null;
                    _loc_9 = _loc_6[_loc_7] as Object;
                    _loc_10 = _loc_9.name;
                    _loc_11 = _loc_10.split("-");
                    _loc_12 = _loc_11[0];
                    _loc_13 = -1;
                    _loc_8 = this.findRoomGroupByName(_loc_12);
                    if (_loc_11.length != 1)
                    {
                        _loc_13 = int(_loc_11[1]);
                    }
                    if (!_loc_8)
                    {
                        _loc_8 = new RoomGroup(this._facade, new RoomJoinRequestVO(_loc_12), this._connection);
                        _loc_8.addEventListener(RoomEvent.ROOM_JOIN, this.handleRoomJoin);
                        _loc_8.addEventListener(RoomEvent.ROOM_LEAVE, this.handleRoomLeave);
                        if (_loc_8.name != "trade")
                        {
                            this._roomGroups.push(_loc_8);
                        }
                    }
                    _loc_8.addRoomInstance(_loc_13);
                    _loc_7 = _loc_7 + 1;
                }
                _loc_3++;
            }
            for each (_loc_4 in this._roomGroups)
            {
                
                if (_loc_4.autojoin)
                {
                    this._pendingRoomsToJoin.addItem(_loc_4);
                }
            }
            if (this._pendingRoomsToJoin.length > 0)
            {
                this._pendingRoomsToJoin[0].join();
            }
            return;
        }// end function

    }
}
