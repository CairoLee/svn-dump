package org.igniterealtime.xiff.conference
{
    import org.igniterealtime.xiff.collections.*;
    import org.igniterealtime.xiff.core.*;
    import org.igniterealtime.xiff.data.*;
    import org.igniterealtime.xiff.data.forms.*;
    import org.igniterealtime.xiff.data.muc.*;
    import org.igniterealtime.xiff.events.*;

    public class Room extends ArrayCollection
    {
        private var _password:String;
        private var _active:Boolean;
        private var affiliationExtension:MUCBaseExtension;
        private var _affiliation:String;
        private var pendingNickname:String;
        private var myIsReserved:Boolean;
        private var _nickname:String;
        private var _role:String;
        private var _roomJID:UnescapedJID;
        private var affiliationArgs:Array;
        private var _anonymous:Boolean = true;
        private var _subject:String;
        private var _connection:XMPPConnection;
        public static const AFFILIATION_ADMIN:String = "admin";
        public static const ROLE_NONE:String = "none";
        public static const AFFILIATION_OWNER:String = "owner";
        public static const ROLE_VISITOR:String = "visitor";
        public static const AFFILIATION_NONE:String = "none";
        public static const AFFILIATION_MEMBER:String = "member";
        public static const ROLE_PARTICIPANT:String = "participant";
        private static var roomStaticConstructed:Boolean = RoomStaticConstructor();
        private static var staticConstructorDependencies:Array = [FormExtension, MUC];
        public static const ROLE_MODERATOR:String = "moderator";
        public static const AFFILIATION_OUTCAST:String = "outcast";

        public function Room(param1:XMPPConnection = null)
        {
            affiliationArgs = [];
            setActive(false);
            if (param1 != null)
            {
                connection = param1;
            }
            affiliationExtension = new MUCAdminExtension();
            return;
        }// end function

        private function grant_response(param1:IQ) : void
        {
            affiliationArgs = [];
            var _loc_2:* = new RoomEvent(RoomEvent.AFFILIATION_CHANGE_COMPLETE);
            dispatchEvent(_loc_2);
            return;
        }// end function

        public function get anonymous() : Boolean
        {
            return _anonymous;
        }// end function

        public function revoke(param1:Array) : void
        {
            grant(Room.AFFILIATION_NONE, param1);
            return;
        }// end function

        private function setActive(param1:Boolean) : void
        {
            var _loc_2:* = _active;
            _active = param1;
            if (_active != _loc_2)
            {
                dispatchChangeEvent("active", _active, _loc_2);
            }
            return;
        }// end function

        public function invite(param1:UnescapedJID, param2:String) : void
        {
            var _loc_3:* = new Message(roomJID.escaped);
            var _loc_4:* = new MUCUserExtension();
            new MUCUserExtension().invite(param1.escaped, undefined, param2);
            _loc_3.addExtension(_loc_4);
            _connection.send(_loc_3);
            return;
        }// end function

        public function set roomName(param1:String) : void
        {
            roomJID = new UnescapedJID(param1 + "@" + conferenceServer);
            return;
        }// end function

        public function set conferenceServer(param1:String) : void
        {
            roomJID = new UnescapedJID(roomName + "@" + param1);
            return;
        }// end function

        public function get conferenceServer() : String
        {
            return _roomJID.domain;
        }// end function

        public function ban(param1:Array) : void
        {
            var _loc_4:UnescapedJID = null;
            var _loc_2:* = new IQ(roomJID.escaped, IQ.TYPE_SET, null, ban_response, ban_error);
            var _loc_3:* = new MUCAdminExtension();
            for each (_loc_4 in param1)
            {
                
                _loc_3.addItem(Room.AFFILIATION_OUTCAST, null, null, _loc_4.escaped, null, null);
            }
            _loc_2.addExtension(_loc_3);
            _connection.send(_loc_2);
            return;
        }// end function

        public function destroy(param1:String, param2:UnescapedJID = null, param3:Function = null) : void
        {
            var _loc_6:EscapedJID = null;
            var _loc_4:* = new IQ(roomJID.escaped, IQ.TYPE_SET);
            var _loc_5:* = new MUCOwnerExtension();
            if (param2 != null)
            {
                _loc_6 = param2.escaped;
            }
            _loc_4.callback = param3;
            _loc_5.destroy(param1, _loc_6);
            _loc_4.addExtension(_loc_5);
            _connection.send(_loc_4);
            return;
        }// end function

        public function set nickname(param1:String) : void
        {
            var _loc_2:Presence = null;
            if (isActive)
            {
                pendingNickname = param1;
                _loc_2 = new Presence(new EscapedJID(userJID + "/" + param1));
                _connection.send(_loc_2);
            }
            else
            {
                _nickname = param1;
            }
            return;
        }// end function

        private function admin_error(param1:IQ) : void
        {
            var _loc_2:* = new RoomEvent(RoomEvent.ADMIN_ERROR);
            _loc_2.errorCondition = param1.errorCondition;
            _loc_2.errorMessage = param1.errorMessage;
            _loc_2.errorType = param1.errorType;
            _loc_2.errorCode = param1.errorCode;
            dispatchEvent(_loc_2);
            return;
        }// end function

        public function get password() : String
        {
            return _password;
        }// end function

        public function cancelConfiguration() : void
        {
            var _loc_1:* = new IQ(roomJID.escaped, IQ.TYPE_SET);
            var _loc_2:* = new MUCOwnerExtension();
            var _loc_3:* = new FormExtension();
            _loc_3.type = FormExtension.TYPE_CANCEL;
            _loc_2.addExtension(_loc_3);
            _loc_1.addExtension(_loc_2);
            _connection.send(_loc_1);
            return;
        }// end function

        public function get roomName() : String
        {
            return _roomJID.node;
        }// end function

        public function kickOccupant(param1:String, param2:String) : void
        {
            var _loc_3:IQ = null;
            var _loc_4:MUCAdminExtension = null;
            if (isActive)
            {
                _loc_3 = new IQ(roomJID.escaped, IQ.TYPE_SET, XMPPStanza.generateID("kick_occupant_"));
                _loc_4 = new MUCAdminExtension(_loc_3.getNode());
                _loc_4.addItem(null, MUC.ROLE_NONE, param1, null, null, param2);
                _loc_3.addExtension(_loc_4);
                _connection.send(_loc_3);
            }
            return;
        }// end function

        public function requestConfiguration() : void
        {
            var _loc_1:* = new IQ(roomJID.escaped, IQ.TYPE_GET, null, requestConfiguration_response, requestConfiguration_error);
            var _loc_2:* = new MUCOwnerExtension();
            _loc_1.addExtension(_loc_2);
            _connection.send(_loc_1);
            return;
        }// end function

        public function grant(param1:String, param2:Array) : void
        {
            var _loc_5:UnescapedJID = null;
            affiliationArgs = arguments;
            arguments = new IQ(roomJID.escaped, IQ.TYPE_SET, null, grant_response, grant_error);
            for each (_loc_5 in param2)
            {
                
                affiliationExtension.addItem(param1, null, null, _loc_5.escaped, null, null);
            }
            arguments.addExtension(affiliationExtension as IExtension);
            _connection.send(arguments);
            return;
        }// end function

        public function sendPrivateMessage(param1:String, param2:String = null, param3:String = null) : void
        {
            var _loc_4:Message = null;
            if (isActive)
            {
                _loc_4 = new Message(new EscapedJID(roomJID + "/" + param1), null, param2, param3, Message.TYPE_CHAT);
                _connection.send(_loc_4);
            }
            return;
        }// end function

        private function requestAffiliations_response(param1:IQ) : void
        {
            var _loc_2:MUCAdminExtension = null;
            var _loc_3:Array = null;
            var _loc_4:RoomEvent = null;
            if (param1.type == IQ.TYPE_RESULT)
            {
                _loc_2 = param1.getAllExtensionsByNS(MUCAdminExtension.NS)[0];
                _loc_3 = _loc_2.getAllItems();
                _loc_4 = new RoomEvent(RoomEvent.AFFILIATIONS);
                _loc_4.data = _loc_3;
                dispatchEvent(_loc_4);
            }
            return;
        }// end function

        public function requestAffiliations(param1:String) : void
        {
            var _loc_2:* = new IQ(roomJID.escaped, IQ.TYPE_GET, null, requestAffiliations_response, requestAffiliations_error);
            var _loc_3:* = new MUCAdminExtension();
            _loc_3.addItem(param1);
            _loc_2.addExtension(_loc_3);
            _connection.send(_loc_2);
            return;
        }// end function

        public function setOccupantVoice(param1:String, param2:Boolean) : void
        {
            var _loc_3:IQ = null;
            var _loc_4:MUCAdminExtension = null;
            if (isActive)
            {
                _loc_3 = new IQ(roomJID.escaped, IQ.TYPE_SET, XMPPStanza.generateID("voice_"));
                _loc_4 = new MUCAdminExtension(_loc_3.getNode());
                _loc_4.addItem(null, param2 ? (MUC.ROLE_PARTICIPANT) : (MUC.ROLE_VISITOR), param1);
                _loc_3.addExtension(_loc_4);
                _connection.send(_loc_3);
            }
            return;
        }// end function

        public function set password(param1:String) : void
        {
            _password = param1;
            return;
        }// end function

        public function leave() : void
        {
            var _loc_1:Presence = null;
            if (isActive)
            {
                _loc_1 = new Presence(userJID.escaped, null, Presence.TYPE_UNAVAILABLE);
                _connection.send(_loc_1);
                removeAll();
                _connection.removeEventListener(MessageEvent.MESSAGE, handleEvent);
                _connection.removeEventListener(DisconnectionEvent.DISCONNECT, handleEvent);
            }
            return;
        }// end function

        private function admin_response(param1:IQ) : void
        {
            return;
        }// end function

        public function join(param1:Boolean = false, param2:Array = null) : Boolean
        {
            var _loc_3:* = new MUCExtension();
            if (password != null)
            {
                _loc_3.password = password;
            }
            return joinWithExplicitMUCExtension(param1, _loc_3, param2);
        }// end function

        private function requestAffiliations_error(param1:IQ) : void
        {
            admin_error(param1);
            return;
        }// end function

        public function set connection(param1:XMPPConnection) : void
        {
            if (_connection != null)
            {
                _connection.removeEventListener(MessageEvent.MESSAGE, handleEvent);
                _connection.removeEventListener(PresenceEvent.PRESENCE, handleEvent);
                _connection.removeEventListener(DisconnectionEvent.DISCONNECT, handleEvent);
            }
            _connection = param1;
            _connection.addEventListener(MessageEvent.MESSAGE, handleEvent, false, 0, true);
            _connection.addEventListener(PresenceEvent.PRESENCE, handleEvent, false, 0, true);
            _connection.addEventListener(DisconnectionEvent.DISCONNECT, handleEvent, false, 0, true);
            return;
        }// end function

        private function grant_error(param1:IQ) : void
        {
            if (affiliationExtension is MUCAdminExtension && affiliationArgs.length > 0)
            {
                affiliationExtension = new MUCOwnerExtension();
                grant.apply(null, affiliationArgs);
            }
            else
            {
                affiliationArgs = [];
                admin_error(param1);
            }
            return;
        }// end function

        private function unlockRoom(param1:Boolean) : void
        {
            var _loc_2:IQ = null;
            var _loc_3:MUCOwnerExtension = null;
            var _loc_4:FormExtension = null;
            if (param1)
            {
                requestConfiguration();
            }
            else
            {
                _loc_2 = new IQ(roomJID.escaped, IQ.TYPE_SET);
                _loc_3 = new MUCOwnerExtension();
                _loc_4 = new FormExtension();
                _loc_4.type = FormExtension.TYPE_SUBMIT;
                _loc_3.addExtension(_loc_4);
                _loc_2.addExtension(_loc_3);
                _connection.send(_loc_2);
            }
            return;
        }// end function

        public function get userJID() : UnescapedJID
        {
            if (_roomJID != null)
            {
                return new UnescapedJID(_roomJID.bareJID + "/" + nickname);
            }
            return null;
        }// end function

        public function get roomJID() : UnescapedJID
        {
            return _roomJID;
        }// end function

        public function get subject() : String
        {
            return _subject;
        }// end function

        public function getOccupantNamed(param1:String) : RoomOccupant
        {
            var _loc_2:RoomOccupant = null;
            for each (_loc_2 in this)
            {
                
                if (_loc_2.displayName == param1)
                {
                    return _loc_2;
                }
            }
            return null;
        }// end function

        public function joinWithExplicitMUCExtension(param1:Boolean, param2:MUCExtension, param3:Array = null) : Boolean
        {
            var _loc_5:* = undefined;
            if (!_connection.isActive() || isActive)
            {
                return false;
            }
            myIsReserved = param1;
            var _loc_4:* = new Presence(userJID.escaped);
            new Presence(userJID.escaped).addExtension(param2);
            if (param3 != null)
            {
                for each (_loc_5 in param3)
                {
                    
                    _loc_4.addExtension(_loc_5);
                }
            }
            _connection.send(_loc_4);
            return true;
        }// end function

        public function allow(param1:Array) : void
        {
            grant(Room.AFFILIATION_NONE, param1);
            return;
        }// end function

        private function configure_response(param1:IQ) : void
        {
            var _loc_2:* = new RoomEvent(RoomEvent.CONFIGURE_ROOM_COMPLETE);
            dispatchEvent(_loc_2);
            return;
        }// end function

        public function get isActive() : Boolean
        {
            return _active;
        }// end function

        private function handleEvent(param1:Object) : void
        {
            var _loc_2:MUCUserExtension = null;
            var _loc_3:Message = null;
            var _loc_4:Array = null;
            var _loc_5:RoomEvent = null;
            var _loc_6:Array = null;
            var _loc_7:Presence = null;
            var _loc_8:MUCStatus = null;
            switch(param1.type)
            {
                case "message":
                {
                    _loc_3 = param1.data;
                    _loc_4 = _loc_3.getAllExtensionsByNS(MUCUserExtension.NS);
                    if (isThisRoom(_loc_3.from.unescaped))
                    {
                        if (_loc_3.type == Message.TYPE_GROUPCHAT)
                        {
                            if (_loc_3.subject != null)
                            {
                                _subject = _loc_3.subject;
                                _loc_5 = new RoomEvent(RoomEvent.SUBJECT_CHANGE);
                                _loc_5.subject = _loc_3.subject;
                                dispatchEvent(_loc_5);
                            }
                            else if (!_loc_4 || _loc_4.length == 0 || !_loc_4[0].hasStatusCode(100))
                            {
                                _loc_5 = new RoomEvent(RoomEvent.GROUP_MESSAGE);
                                _loc_5.nickname = _loc_3.from.resource;
                                _loc_5.data = _loc_3;
                                dispatchEvent(_loc_5);
                            }
                        }
                        else if (_loc_3.type == Message.TYPE_NORMAL)
                        {
                            _loc_6 = _loc_3.getAllExtensionsByNS(FormExtension.NS)[0];
                            if (_loc_6)
                            {
                                _loc_5 = new RoomEvent(RoomEvent.CONFIGURE_ROOM);
                                _loc_5.data = _loc_6;
                                dispatchEvent(_loc_5);
                            }
                        }
                        else if (_loc_3.type == Message.TYPE_CHAT)
                        {
                            _loc_5 = new RoomEvent(RoomEvent.PRIVATE_MESSAGE);
                            _loc_5.data = _loc_3;
                            dispatchEvent(_loc_5);
                        }
                    }
                    else if (_loc_3.to.node && isThisUser(_loc_3.to.unescaped) && _loc_3.type == Message.TYPE_CHAT)
                    {
                        _loc_5 = new RoomEvent(RoomEvent.PRIVATE_MESSAGE);
                        _loc_5.data = _loc_3;
                        dispatchEvent(_loc_5);
                    }
                    else if (_loc_4 != null && _loc_4.length > 0)
                    {
                        _loc_2 = _loc_4[0];
                        if (_loc_2 && _loc_2.type == MUCUserExtension.TYPE_DECLINE)
                        {
                            _loc_5 = new RoomEvent(RoomEvent.DECLINED);
                            _loc_5.from = _loc_2.reason;
                            _loc_5.reason = _loc_2.reason;
                            _loc_5.data = _loc_3;
                            dispatchEvent(_loc_5);
                        }
                    }
                    break;
                }
                case "presence":
                {
                    for each (_loc_7 in param1.data)
                    {
                        
                        if (isThisRoom(_loc_7.from.unescaped))
                        {
                            if (_loc_7.type == Presence.TYPE_ERROR)
                            {
                                switch(_loc_7.errorCode)
                                {
                                    case 401:
                                    {
                                        _loc_5 = new RoomEvent(RoomEvent.PASSWORD_ERROR);
                                        break;
                                    }
                                    case 403:
                                    {
                                        _loc_5 = new RoomEvent(RoomEvent.BANNED_ERROR);
                                        break;
                                    }
                                    case 404:
                                    {
                                        _loc_5 = new RoomEvent(RoomEvent.LOCKED_ERROR);
                                        break;
                                    }
                                    case 407:
                                    {
                                        _loc_5 = new RoomEvent(RoomEvent.REGISTRATION_REQ_ERROR);
                                        break;
                                    }
                                    case 409:
                                    {
                                        _loc_5 = new RoomEvent(RoomEvent.NICK_CONFLICT);
                                        _loc_5.nickname = nickname;
                                        break;
                                    }
                                    case 503:
                                    {
                                        _loc_5 = new RoomEvent(RoomEvent.MAX_USERS_ERROR);
                                        break;
                                    }
                                    default:
                                    {
                                        _loc_5 = new RoomEvent("MUC Error of type: " + _loc_7.errorCode);
                                        break;
                                        break;
                                    }
                                }
                                _loc_5.errorCode = _loc_7.errorCode;
                                _loc_5.errorMessage = _loc_7.errorMessage;
                                dispatchEvent(_loc_5);
                                continue;
                            }
                            if (_loc_7.from.resource == pendingNickname)
                            {
                                _nickname = pendingNickname;
                                pendingNickname = null;
                            }
                            _loc_2 = _loc_7.getAllExtensionsByNS(MUCUserExtension.NS)[0];
                            for each (_loc_8 in _loc_2.statuses)
                            {
                                
                                switch(_loc_8.code)
                                {
                                    case 100:
                                    case 172:
                                    {
                                        _anonymous = false;
                                        break;
                                    }
                                    case 174:
                                    {
                                        _anonymous = true;
                                        break;
                                    }
                                    case 201:
                                    {
                                        unlockRoom(myIsReserved);
                                        break;
                                    }
                                    default:
                                    {
                                        break;
                                    }
                                }
                            }
                            updateRoomRoster(_loc_7);
                            if (_loc_7.type == Presence.TYPE_UNAVAILABLE && isActive && isThisUser(_loc_7.from.unescaped))
                            {
                                setActive(false);
                                if (_loc_2.type == MUCUserExtension.TYPE_DESTROY)
                                {
                                    _loc_5 = new RoomEvent(RoomEvent.ROOM_DESTROYED);
                                }
                                else
                                {
                                    _loc_5 = new RoomEvent(RoomEvent.ROOM_LEAVE);
                                }
                                dispatchEvent(_loc_5);
                                _connection.removeEventListener(PresenceEvent.PRESENCE, handleEvent);
                            }
                        }
                    }
                    break;
                }
                case "disconnection":
                {
                    setActive(false);
                    removeAll();
                    _loc_5 = new RoomEvent(RoomEvent.ROOM_LEAVE);
                    dispatchEvent(_loc_5);
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

        public function isThisUser(param1:UnescapedJID) : Boolean
        {
            var _loc_2:Boolean = false;
            if (userJID != null)
            {
                _loc_2 = param1.toString().toLowerCase() == userJID.toString().toLowerCase();
            }
            return _loc_2;
        }// end function

        public function set roomJID(param1:UnescapedJID) : void
        {
            _roomJID = param1;
            return;
        }// end function

        public function getMessage(param1:String = null, param2:String = null) : Message
        {
            var _loc_3:* = new Message(roomJID.escaped, null, param1, param2, Message.TYPE_GROUPCHAT);
            return _loc_3;
        }// end function

        private function requestConfiguration_response(param1:IQ) : void
        {
            var _loc_4:RoomEvent = null;
            var _loc_2:* = param1.getAllExtensionsByNS(MUCOwnerExtension.NS)[0];
            var _loc_3:* = _loc_2.getAllExtensionsByNS(FormExtension.NS)[0];
            if (_loc_3.type == FormExtension.TYPE_REQUEST)
            {
                _loc_4 = new RoomEvent(RoomEvent.CONFIGURE_ROOM);
                _loc_4.data = _loc_3;
                dispatchEvent(_loc_4);
            }
            return;
        }// end function

        public function sendMessage(param1:String = null, param2:String = null) : void
        {
            var _loc_3:Message = null;
            if (isActive)
            {
                _loc_3 = new Message(roomJID.escaped, null, param1, param2, Message.TYPE_GROUPCHAT);
                _connection.send(_loc_3);
            }
            return;
        }// end function

        public function changeSubject(param1:String) : void
        {
            var _loc_2:Message = null;
            if (isActive)
            {
                _loc_2 = new Message(roomJID.escaped, null, null, null, Message.TYPE_GROUPCHAT, param1);
                _connection.send(_loc_2);
            }
            return;
        }// end function

        public function get connection() : XMPPConnection
        {
            return _connection;
        }// end function

        public function configure(param1:Object) : void
        {
            var _loc_4:FormExtension = null;
            var _loc_2:* = new IQ(roomJID.escaped, IQ.TYPE_SET, null, configure_response, configure_error);
            var _loc_3:* = new MUCOwnerExtension();
            if (param1 is FormExtension)
            {
                _loc_4 = FormExtension(param1);
            }
            else
            {
                _loc_4 = new FormExtension();
                param1["FORM_TYPE"] = ["http://jabber.org/protocol/muc#roomconfig"];
                _loc_4.setFields(param1);
            }
            _loc_4.type = FormExtension.TYPE_SUBMIT;
            _loc_3.addExtension(_loc_4);
            _loc_2.addExtension(_loc_3);
            _connection.send(_loc_2);
            return;
        }// end function

        private function ban_error(param1:IQ) : void
        {
            admin_error(param1);
            return;
        }// end function

        public function get role() : String
        {
            return _role;
        }// end function

        public function isThisRoom(param1:UnescapedJID) : Boolean
        {
            var _loc_2:Boolean = false;
            if (_roomJID != null)
            {
                _loc_2 = param1.bareJID.toLowerCase() == roomJID.bareJID.toLowerCase();
            }
            return _loc_2;
        }// end function

        override public function toString() : String
        {
            return "[object Room]";
        }// end function

        private function configure_error(param1:IQ) : void
        {
            admin_error(param1);
            return;
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

        private function ban_response(param1:IQ) : void
        {
            return;
        }// end function

        public function get nickname() : String
        {
            return _nickname == null ? (_connection.username) : (_nickname);
        }// end function

        public function decline(param1:UnescapedJID, param2:String) : void
        {
            var _loc_3:* = new Message(roomJID.escaped);
            var _loc_4:* = new MUCUserExtension();
            new MUCUserExtension().decline(param1.escaped, undefined, param2);
            _loc_3.addExtension(_loc_4);
            _connection.send(_loc_3);
            return;
        }// end function

        private function requestConfiguration_error(param1:IQ) : void
        {
            admin_error(param1);
            return;
        }// end function

        public function sendMessageWithExtension(param1:Message) : void
        {
            if (isActive)
            {
                _connection.send(param1);
            }
            return;
        }// end function

        private function updateRoomRoster(param1:Presence) : void
        {
            var _loc_5:RoomEvent = null;
            var _loc_7:String = null;
            var _loc_8:String = null;
            var _loc_9:MUCUserExtension = null;
            var _loc_10:MUCStatus = null;
            var _loc_2:* = param1.from.unescaped.resource;
            var _loc_3:* = param1.getAllExtensionsByNS(MUCUserExtension.NS);
            var _loc_4:* = _loc_3[0].getAllItems()[0];
            if (isThisUser(param1.from.unescaped))
            {
                _loc_7 = _affiliation;
                _affiliation = _loc_4.affiliation;
                if (_affiliation != _loc_7)
                {
                    dispatchChangeEvent("affiliation", _affiliation, _loc_7);
                }
                _loc_8 = _role;
                _role = _loc_4.role;
                if (_role != _loc_8)
                {
                    dispatchChangeEvent("role", _role, _loc_8);
                }
                if (!isActive && param1.type != Presence.TYPE_UNAVAILABLE)
                {
                    setActive(true);
                    _loc_5 = new RoomEvent(RoomEvent.ROOM_JOIN);
                    dispatchEvent(_loc_5);
                }
            }
            var _loc_6:* = getOccupantNamed(_loc_2);
            if (getOccupantNamed(_loc_2))
            {
                if (param1.type == Presence.TYPE_UNAVAILABLE)
                {
                    removeItemAt(getItemIndex(_loc_6));
                    _loc_9 = param1.getAllExtensionsByNS(MUCUserExtension.NS)[0];
                    for each (_loc_10 in _loc_9.statuses)
                    {
                        
                        switch(_loc_10.code)
                        {
                            case 301:
                            {
                                _loc_5 = new RoomEvent(RoomEvent.USER_BANNED);
                                _loc_5.nickname = _loc_2;
                                _loc_5.data = param1;
                                dispatchEvent(_loc_5);
                                return;
                            }
                            case 307:
                            {
                                _loc_5 = new RoomEvent(RoomEvent.USER_KICKED);
                                _loc_5.nickname = _loc_2;
                                _loc_5.data = param1;
                                dispatchEvent(_loc_5);
                                return;
                            }
                            default:
                            {
                                break;
                            }
                        }
                    }
                    _loc_5 = new RoomEvent(RoomEvent.USER_DEPARTURE);
                    _loc_5.nickname = _loc_2;
                    _loc_5.data = param1;
                    dispatchEvent(_loc_5);
                }
                else
                {
                    _loc_6.affiliation = _loc_4.affiliation;
                    _loc_6.role = _loc_4.role;
                    _loc_6.show = param1.show;
                    _loc_5 = new RoomEvent(RoomEvent.USER_PRESENCE_CHANGE);
                    _loc_5.nickname = _loc_2;
                    _loc_5.data = param1;
                    dispatchEvent(_loc_5);
                }
            }
            else if (param1.type != Presence.TYPE_UNAVAILABLE)
            {
                addItem(new RoomOccupant(_loc_2, param1.show, _loc_4.affiliation, _loc_4.role, _loc_4.jid ? (_loc_4.jid.unescaped) : (null), this));
                _loc_5 = new RoomEvent(RoomEvent.USER_JOIN);
                _loc_5.nickname = _loc_2;
                _loc_5.data = param1;
                dispatchEvent(_loc_5);
            }
            return;
        }// end function

        public function get affiliation() : String
        {
            return _affiliation;
        }// end function

        private static function RoomStaticConstructor() : Boolean
        {
            MUC.enable();
            FormExtension.enable();
            return true;
        }// end function

    }
}
