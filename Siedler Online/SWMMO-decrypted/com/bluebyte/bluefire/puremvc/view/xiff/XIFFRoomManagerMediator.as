package com.bluebyte.bluefire.puremvc.view.xiff
{
    import com.bluebyte.bluefire.api.controller.*;
    import com.bluebyte.bluefire.api.event.*;
    import com.bluebyte.bluefire.api.model.vo.*;
    import com.bluebyte.bluefire.puremvc.*;
    import com.bluebyte.bluefire.puremvc.model.*;
    import flash.events.*;
    import org.igniterealtime.xiff.conference.*;
    import org.igniterealtime.xiff.core.*;
    import org.igniterealtime.xiff.events.*;
    import org.puremvc.as3.multicore.interfaces.*;
    import org.puremvc.as3.multicore.patterns.mediator.*;

    public class XIFFRoomManagerMediator extends Mediator implements IMediator
    {
        private var _connectionProxy:ConnectionProxy;
        public static const NAME:String = "XIFFRoomManagerMediator";

        public function XIFFRoomManagerMediator(param1:String = null, param2:Object = null)
        {
            super(NAME);
            return;
        }// end function

        override public function listNotificationInterests() : Array
        {
            return [BlueFireFacade.CONNECTED, BlueFireFacade.ROOM_JOIN, BlueFireFacade.ROOM_JOIN_EXPLICIT, BlueFireFacade.ROOM_LEAVE, BlueFireFacade.ROOM_JOIN_ALL, BlueFireFacade.ROOM_JOINED];
        }// end function

        private function roomHandler_AllRoomsJoinedHandler(event:Event) : void
        {
            return;
        }// end function

        override public function onRegister() : void
        {
            this._connectionProxy = facade.retrieveProxy(ConnectionProxy.NAME) as ConnectionProxy;
            return;
        }// end function

        override public function handleNotification(param1:INotification) : void
        {
            switch(param1.getName())
            {
                case BlueFireFacade.CONNECTED:
                {
                    viewComponent = new RoomManager(facade as BlueFireFacade, param1.getBody() as XMPPConnection);
                    this.roomManager.addEventListener(RoomEvent.ROOM_JOIN, this.roomManager_RoomJoinHandler);
                    this.roomManager.addEventListener(RoomEvent.ROOM_LEAVE, this.roomManager_RoomLeaveHandler);
                    this.roomManager.addEventListener(RoomManagerEvent.ALL_ROOMS_JOINED, this.roomHandler_AllRoomsJoinedHandler);
                    this.roomManager.addEventListener(RoomEvent.USER_JOIN, this.roomManager_RoomUserJoinHandler);
                    this.roomManager.addEventListener(RoomEvent.USER_DEPARTURE, this.roomManager_RoomUserDepartureHandler);
                    break;
                }
                case BlueFireFacade.ROOM_JOIN_EXPLICIT:
                {
                    this.roomManager.joinRoomExplicit(param1.getBody() as RoomJoinRequestVO);
                    break;
                }
                case BlueFireFacade.ROOM_JOIN:
                {
                    this.roomManager.joinRoomByCommand(param1.getBody() as String);
                    break;
                }
                case BlueFireFacade.ROOM_LEAVE:
                {
                    this.roomManager.leaveRoomByCommand(param1.getBody() as String);
                    break;
                }
                case BlueFireFacade.ROOM_JOIN_ALL:
                {
                    this.roomManager.joinRooms();
                    break;
                }
                case BlueFireFacade.ROOM_JOINED:
                {
                    this.roomManager.resetJoinInProgress();
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

        private function roomManager_RoomUserJoinHandler(event:RoomEvent) : void
        {
            return;
        }// end function

        private function roomManager_RoomUserDepartureHandler(event:RoomEvent) : void
        {
            return;
        }// end function

        private function get roomManager() : RoomManager
        {
            return viewComponent as RoomManager;
        }// end function

        private function roomManager_RoomJoinHandler(event:RoomManagerEvent) : void
        {
            var _loc_4:RoomOccupant = null;
            var _loc_5:RoomOccupantVO = null;
            var _loc_2:* = Room(event.data);
            var _loc_3:* = new RoomVO();
            _loc_3.name = _loc_2.roomName;
            for each (_loc_4 in _loc_2.source)
            {
                
                _loc_5 = new RoomOccupantVO();
                _loc_5.name = _loc_4.displayName;
                _loc_3.addOccupant(_loc_5);
            }
            this._connectionProxy.addRoom(_loc_3);
            sendNotification(BlueFireFacade.ROOM_JOINED, _loc_3);
            return;
        }// end function

        private function roomManager_RoomLeaveHandler(event:RoomManagerEvent) : void
        {
            var _loc_2:* = Room(event.data);
            sendNotification(BlueFireFacade.ROOM_LEFT, _loc_2.roomName);
            return;
        }// end function

    }
}
