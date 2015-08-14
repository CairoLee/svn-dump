package com.bluebyte.bluefire.puremvc
{
    import com.bluebyte.bluefire.puremvc.controller.*;
    import mx.logging.*;
    import mx.logging.targets.*;
    import org.puremvc.as3.multicore.interfaces.*;
    import org.puremvc.as3.multicore.patterns.facade.*;

    public class BlueFireFacade extends Facade implements IFacade
    {
        public static const LEAVE_CHAT:String = "leaveChat";
        public static const LOGGED_IN:String = "loggedIn";
        public static const MESSAGE_CUSTOMALERT:String = "messageCustomAlert";
        public static const ROOM_JOIN:String = "roomJoin";
        public static const EVALUATE_SLASH_COMMAND:String = "evaluateSlashcommand";
        public static const ADD_CHANNEL:String = "addChannel";
        public static const REMOVE_WHISPER:String = "removeWhisper";
        public static const REMOVE_CHANNEL:String = "removeChannel";
        public static const ADD_MESSAGE:String = "addMessage";
        public static const ADD_WHISPER:String = "addWhisper";
        public static const REGISTER_SLASH_COMMAND:String = "registerSlashCommand";
        public static const SEND_MESSAGE:String = "sendMessage";
        public static const UPDATE_ROOM_GROUP_SEPERATOR:String = "updateRoomGroupSeperator";
        public static const ROOM_JOINED:String = "roomJoined";
        public static const ROOM_OCCUPANT_PRESENCE_UPDATED:String = "roomOccupantPresenceUpdated";
        public static const UPDATE_SERVER_DATA:String = "updateServerData";
        public static const SEND_MESSAGE_CREATED:String = "sendMessageCreated";
        public static const ROOM_LEAVE:String = "roomLeave";
        public static const ROOM_JOIN_EXPLICIT:String = "roomJoinExplicit";
        public static const CONNECTION_ERROR:String = "connectionError";
        public static const MESSAGE_CREATED_ADDED_AFTER:String = "messageCreatedAddedAfter";
        public static const MESSAGE_CREATED_ADDED:String = "messageCreatedAdded";
        public static const ROOM_JOIN_ALL:String = "roomJoinAll";
        public static const FRIEND_PRESENCE_UPDATED:String = "friendPresenceUpdated";
        public static const STARTUP:String = "startup";
        public static const CONNECTED:String = "connected";
        public static const UPDATE_PLAYER_DATA:String = "updatePlayerData";
        public static const ROOM_LEFT:String = "roomLeft";
        public static const MESSAGE_CREATED:String = "messageCreated";

        public function BlueFireFacade(param1:String)
        {
            super(param1);
            var _loc_2:* = new TraceTarget();
            _loc_2.filters = ["com.bluebyte.*"];
            _loc_2.level = LogEventLevel.ALL;
            _loc_2.includeDate = true;
            _loc_2.includeTime = true;
            _loc_2.includeCategory = true;
            _loc_2.includeLevel = true;
            Log.addTarget(_loc_2);
            return;
        }// end function

        override protected function initializeController() : void
        {
            super.initializeController();
            registerCommand(STARTUP, StartupCommand);
            registerCommand(ADD_MESSAGE, AddMessageCommand);
            registerCommand(SEND_MESSAGE, SendMessageCommand);
            registerCommand(UPDATE_PLAYER_DATA, UpdatePlayerDataCommand);
            registerCommand(UPDATE_SERVER_DATA, UpdateServerDataCommand);
            registerCommand(UPDATE_ROOM_GROUP_SEPERATOR, UpdateRoomGroupSeperatorCommand);
            registerCommand(ADD_CHANNEL, AddChannelCommand);
            registerCommand(REMOVE_CHANNEL, RemoveChannelCommand);
            return;
        }// end function

        public function startup(param1:Object, param2:Class) : void
        {
            sendNotification(STARTUP, [param1, param2]);
            return;
        }// end function

        public static function getInstance(param1:String) : BlueFireFacade
        {
            if (instanceMap[param1] == null)
            {
                instanceMap[param1] = new BlueFireFacade(param1);
            }
            return instanceMap[param1];
        }// end function

    }
}
