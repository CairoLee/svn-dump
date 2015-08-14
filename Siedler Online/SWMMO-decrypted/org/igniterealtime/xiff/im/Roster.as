package org.igniterealtime.xiff.im
{
    import flash.utils.*;
    import org.igniterealtime.xiff.collections.*;
    import org.igniterealtime.xiff.core.*;
    import org.igniterealtime.xiff.data.*;
    import org.igniterealtime.xiff.data.im.*;
    import org.igniterealtime.xiff.events.*;

    public class Roster extends ArrayCollection
    {
        private var pendingSubscriptionRequests:Dictionary;
        private var _presenceMap:Object;
        private var _groups:Object;
        private var _connection:XMPPConnection;
        private static const staticConstructorDependencies:Array = [ExtensionClassRegistry, RosterExtension];
        private static var rosterStaticConstructed:Boolean = RosterStaticConstructor();

        public function Roster(param1:XMPPConnection = null)
        {
            _groups = {};
            _presenceMap = {};
            pendingSubscriptionRequests = new Dictionary();
            if (param1 != null)
            {
                connection = param1;
            }
            return;
        }// end function

        public function updateContactName(param1:RosterItemVO, param2:String) : void
        {
            var _loc_4:RosterGroup = null;
            var _loc_3:Array = [];
            for each (_loc_4 in getContainingGroups(param1))
            {
                
                _loc_3.push(_loc_4.label);
            }
            updateContact(param1, param2, _loc_3);
            return;
        }// end function

        public function set connection(param1:XMPPConnection) : void
        {
            _connection = param1;
            _connection.addEventListener(PresenceEvent.PRESENCE, handleEvent);
            _connection.addEventListener(LoginEvent.LOGIN, handleEvent);
            _connection.addEventListener(RosterExtension.NS, handleEvent);
            return;
        }// end function

        public function addContact(param1:UnescapedJID, param2:String, param3:String = null, param4:Boolean = true) : void
        {
            if (param2 == null)
            {
                param2 = param1.toString();
            }
            var _loc_5:Function = null;
            var _loc_6:* = RosterExtension.SUBSCRIBE_TYPE_NONE;
            var _loc_7:* = RosterExtension.ASK_TYPE_NONE;
            var _loc_8:* = XMPPStanza.generateID("add_user_");
            if (param4 == true)
            {
                _loc_5 = addContact_result;
                pendingSubscriptionRequests[_loc_8.toString()] = param1;
                _loc_6 = RosterExtension.SUBSCRIBE_TYPE_TO;
                _loc_7 = RosterExtension.ASK_TYPE_SUBSCRIBE;
            }
            var _loc_9:* = new IQ(null, IQ.TYPE_SET, _loc_8, _loc_5);
            var _loc_10:* = new RosterExtension(_loc_9.getNode());
            new RosterExtension(_loc_9.getNode()).addItem(param1.escaped, null, param2, param3 ? ([param3]) : (null));
            _loc_9.addExtension(_loc_10);
            _connection.send(_loc_9);
            addRosterItem(param1, param2, RosterExtension.SHOW_PENDING, RosterExtension.SHOW_PENDING, [param3], _loc_6, _loc_7);
            return;
        }// end function

        public function getGroup(param1:String) : RosterGroup
        {
            return _groups[param1] as RosterGroup;
        }// end function

        public function updateContactGroups(param1:RosterItemVO, param2:Array) : void
        {
            updateContact(param1, param1.displayName, param2);
            return;
        }// end function

        public function setPresence(param1:String, param2:String, param3:int) : void
        {
            var _loc_4:* = new Presence(null, null, null, param1, param2, param3);
            _connection.send(_loc_4);
            return;
        }// end function

        public function denySubscription(param1:UnescapedJID) : void
        {
            var _loc_2:* = new Presence(param1.escaped, null, Presence.TYPE_UNSUBSCRIBED);
            _connection.send(_loc_2);
            return;
        }// end function

        private function updateRosterItemPresence(param1:RosterItemVO, param2:Presence) : void
        {
            var event:RosterEvent;
            var item:* = param1;
            var presence:* = param2;
            try
            {
                item.status = presence.status;
                item.show = presence.show;
                item.priority = presence.priority;
                if (!presence.type)
                {
                    item.online = true;
                }
                else if (presence.type == Presence.TYPE_UNAVAILABLE)
                {
                    item.online = false;
                }
                itemUpdated(item);
                event = new RosterEvent(RosterEvent.USER_PRESENCE_UPDATED);
                event.jid = item.jid;
                event.data = item;
                dispatchEvent(event);
                _presenceMap[item.jid.toString()] = presence;
            }
            catch (error:Error)
            {
                trace(error.getStackTrace());
            }
            return;
        }// end function

        public function unsubscribe_result(param1:IQ) : void
        {
            return;
        }// end function

        public function requestSubscription(param1:UnescapedJID, param2:Boolean = false) : void
        {
            var _loc_3:Presence = null;
            if (param2)
            {
                _loc_3 = new Presence(param1.escaped, null, Presence.TYPE_SUBSCRIBE);
                _connection.send(_loc_3);
                return;
            }
            if (contains(RosterItemVO.get(param1, false)))
            {
                _loc_3 = new Presence(param1.escaped, null, Presence.TYPE_SUBSCRIBE);
                _connection.send(_loc_3);
            }
            return;
        }// end function

        private function handlePresences(param1:Array) : void
        {
            var _loc_2:Presence = null;
            var _loc_3:String = null;
            var _loc_4:RosterEvent = null;
            var _loc_5:RosterItemVO = null;
            var _loc_6:RosterItemVO = null;
            for each (_loc_2 in param1)
            {
                
                _loc_3 = _loc_2.type ? (_loc_2.type.toLowerCase()) : (null);
                _loc_4 = null;
                switch(_loc_3)
                {
                    case Presence.TYPE_SUBSCRIBE:
                    {
                        _loc_4 = new RosterEvent(RosterEvent.SUBSCRIPTION_REQUEST);
                        break;
                    }
                    case Presence.TYPE_UNSUBSCRIBED:
                    {
                        _loc_4 = new RosterEvent(RosterEvent.SUBSCRIPTION_DENIAL);
                        break;
                    }
                    case Presence.TYPE_UNAVAILABLE:
                    {
                        _loc_4 = new RosterEvent(RosterEvent.USER_UNAVAILABLE);
                        _loc_5 = RosterItemVO.get(_loc_2.from.unescaped, false);
                        if (!_loc_5)
                        {
                            break;
                        }
                        updateRosterItemPresence(_loc_5, _loc_2);
                        break;
                    }
                    default:
                    {
                        _loc_4 = new RosterEvent(RosterEvent.USER_AVAILABLE);
                        _loc_4.data = _loc_2;
                        if (_loc_2.from)
                        {
                            _loc_6 = RosterItemVO.get(_loc_2.from.unescaped, false);
                        }
                        if (!_loc_6)
                        {
                            break;
                        }
                        updateRosterItemPresence(_loc_6, _loc_2);
                        break;
                        break;
                    }
                }
                if (_loc_4 != null)
                {
                    if (_loc_2.from)
                    {
                        _loc_4.jid = _loc_2.from.unescaped;
                    }
                    dispatchEvent(_loc_4);
                }
            }
            return;
        }// end function

        public function grantSubscription(param1:UnescapedJID, param2:Boolean = true) : void
        {
            var _loc_3:* = new Presence(param1.escaped, null, Presence.TYPE_SUBSCRIBED);
            _connection.send(_loc_3);
            if (param2)
            {
                requestSubscription(param1, true);
            }
            return;
        }// end function

        public function addContact_result(param1:IQ) : void
        {
            var _loc_3:UnescapedJID = null;
            var _loc_2:* = param1.id.toString();
            if (pendingSubscriptionRequests.hasOwnProperty(_loc_2))
            {
                _loc_3 = pendingSubscriptionRequests[_loc_2] as UnescapedJID;
                requestSubscription(_loc_3);
                delete pendingSubscriptionRequests[_loc_2];
            }
            return;
        }// end function

        private function updateContact(param1:RosterItemVO, param2:String, param3:Array) : void
        {
            var _loc_4:* = new IQ(null, IQ.TYPE_SET, XMPPStanza.generateID("update_contact_"));
            var _loc_5:* = new RosterExtension(_loc_4.getNode());
            new RosterExtension(_loc_4.getNode()).addItem(param1.jid.escaped, param1.subscribeType, param2, param3);
            _loc_4.addExtension(_loc_5);
            _connection.send(_loc_4);
            return;
        }// end function

        private function handleEvent(param1) : void
        {
            var ext:RosterExtension;
            var items:Array;
            var item:*;
            var jid:UnescapedJID;
            var rosterItemVO:RosterItemVO;
            var rosterEvent:RosterEvent;
            var group:RosterGroup;
            var groupNames:Array;
            var askType:String;
            var eventObj:* = param1;
            switch(eventObj.type)
            {
                case PresenceEvent.PRESENCE:
                {
                    handlePresences(eventObj.data);
                    break;
                }
                case LoginEvent.LOGIN:
                {
                    fetchRoster();
                    setPresence(null, "Online", 5);
                    break;
                }
                case RosterExtension.NS:
                {
                    try
                    {
                        ext = (eventObj.iq as IQ).getAllExtensionsByNS(RosterExtension.NS)[0] as RosterExtension;
                        items = ext.getAllItems();
                        var _loc_3:int = 0;
                        var _loc_4:* = items;
                        while (_loc_4 in _loc_3)
                        {
                            
                            item = _loc_4[_loc_3];
                            jid = new UnescapedJID(item.jid);
                            rosterItemVO = RosterItemVO.get(jid, true);
                            if (contains(rosterItemVO))
                            {
                                switch(item.subscription.toLowerCase())
                                {
                                    case RosterExtension.SUBSCRIBE_TYPE_NONE:
                                    {
                                        rosterEvent = new RosterEvent(RosterEvent.SUBSCRIPTION_REVOCATION);
                                        rosterEvent.jid = jid;
                                        dispatchEvent(rosterEvent);
                                        break;
                                    }
                                    case RosterExtension.SUBSCRIBE_TYPE_REMOVE:
                                    {
                                        rosterEvent = new RosterEvent(RosterEvent.USER_REMOVED);
                                        var _loc_5:int = 0;
                                        var _loc_6:* = getContainingGroups(rosterItemVO);
                                        while (_loc_6 in _loc_5)
                                        {
                                            
                                            group = _loc_6[_loc_5];
                                            group.removeItem(rosterItemVO);
                                        }
                                        rosterEvent.data = removeItemAt(getItemIndex(rosterItemVO));
                                        rosterEvent.jid = jid;
                                        dispatchEvent(rosterEvent);
                                        break;
                                    }
                                    default:
                                    {
                                        updateRosterItemSubscription(rosterItemVO, item.subscription.toLowerCase(), item.name, item.groupNames);
                                        break;
                                        break;
                                    }
                                }
                                continue;
                            }
                            groupNames = item.groupNames;
                            askType = item.askType != null ? (item.askType.toLowerCase()) : (RosterExtension.ASK_TYPE_NONE);
                            if (item.subscription.toLowerCase() != RosterExtension.SUBSCRIBE_TYPE_REMOVE && item.subscription.toLowerCase() != RosterExtension.SUBSCRIBE_TYPE_NONE)
                            {
                                addRosterItem(jid, item.name, RosterExtension.SHOW_UNAVAILABLE, "Offline", groupNames, item.subscription.toLowerCase(), askType);
                                continue;
                            }
                            if ((item.subscription.toLowerCase() == RosterExtension.SUBSCRIBE_TYPE_NONE || item.subscription.toLowerCase() == RosterExtension.SUBSCRIBE_TYPE_FROM) && item.askType == RosterExtension.ASK_TYPE_SUBSCRIBE)
                            {
                                addRosterItem(jid, item.name, RosterExtension.SHOW_PENDING, "Pending", groupNames, item.subscription.toLowerCase(), askType);
                            }
                        }
                    }
                    catch (error:Error)
                    {
                        trace(error.getStackTrace());
                    }
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

        private function updateRosterItemSubscription(param1:RosterItemVO, param2:String, param3:String, param4:Array) : void
        {
            param1.subscribeType = param2;
            setContactGroups(param1, param4);
            if (param3)
            {
                param1.displayName = param3;
            }
            var _loc_5:* = new RosterEvent(RosterEvent.USER_SUBSCRIPTION_UPDATED);
            new RosterEvent(RosterEvent.USER_SUBSCRIPTION_UPDATED).jid = param1.jid;
            _loc_5.data = param1;
            dispatchEvent(_loc_5);
            return;
        }// end function

        public function fetchRoster() : void
        {
            var _loc_1:* = new IQ(null, IQ.TYPE_GET, XMPPStanza.generateID("roster_"), fetchRoster_result);
            _loc_1.addExtension(new RosterExtension(_loc_1.getNode()));
            _connection.send(_loc_1);
            return;
        }// end function

        private function setContactGroups(param1:RosterItemVO, param2:Array) : void
        {
            var _loc_3:String = null;
            var _loc_4:RosterGroup = null;
            if (!param2 || param2.length == 0)
            {
                param2 = ["General"];
            }
            for each (_loc_3 in param2)
            {
                
                if (!getGroup(_loc_3))
                {
                    _groups[_loc_3] = new RosterGroup(_loc_3);
                }
            }
            for each (_loc_4 in _groups)
            {
                
                if (param2.indexOf(_loc_4.label) >= 0)
                {
                    _loc_4.addItem(param1);
                    continue;
                }
                _loc_4.removeItem(param1);
            }
            return;
        }// end function

        public function get connection() : XMPPConnection
        {
            return _connection;
        }// end function

        public function getPresence(param1:UnescapedJID) : Presence
        {
            return _presenceMap[param1.toString()] as Presence;
        }// end function

        public function fetchRoster_result(param1:IQ) : void
        {
            var ext:RosterExtension;
            var rosterEvent:RosterEvent;
            var item:*;
            var askType:String;
            var resultIQ:* = param1;
            removeAll();
            try
            {
                var _loc_3:int = 0;
                var _loc_4:* = resultIQ.getAllExtensionsByNS(RosterExtension.NS);
                while (_loc_4 in _loc_3)
                {
                    
                    ext = _loc_4[_loc_3];
                    var _loc_5:int = 0;
                    var _loc_6:* = ext.getAllItems();
                    while (_loc_6 in _loc_5)
                    {
                        
                        item = _loc_6[_loc_5];
                        if (!item is XMLStanza)
                        {
                            continue;
                        }
                        askType = item.askType != null ? (item.askType.toLowerCase()) : (RosterExtension.ASK_TYPE_NONE);
                        addRosterItem(new UnescapedJID(item.jid), item.name, RosterExtension.SHOW_UNAVAILABLE, "Offline", item.groupNames, item.subscription.toLowerCase(), askType);
                    }
                }
                rosterEvent = new RosterEvent(RosterEvent.ROSTER_LOADED, false, false);
                dispatchEvent(rosterEvent);
            }
            catch (error:Error)
            {
                trace(error.getStackTrace());
            }
            return;
        }// end function

        public function getContainingGroups(param1:RosterItemVO) : Array
        {
            var _loc_3:String = null;
            var _loc_4:RosterGroup = null;
            var _loc_2:Array = [];
            for (_loc_3 in _groups)
            {
                
                _loc_4 = _groups[_loc_3] as RosterGroup;
                if (_loc_4.contains(param1))
                {
                    _loc_2.push(_loc_4);
                }
            }
            return _loc_2;
        }// end function

        public function removeContact(param1:RosterItemVO) : void
        {
            var _loc_2:IQ = null;
            var _loc_3:RosterExtension = null;
            if (contains(param1))
            {
                _loc_2 = new IQ(null, IQ.TYPE_SET, XMPPStanza.generateID("remove_user_"), unsubscribe_result);
                _loc_3 = new RosterExtension(_loc_2.getNode());
                _loc_3.addItem(new EscapedJID(param1.jid.bareJID), RosterExtension.SUBSCRIBE_TYPE_REMOVE);
                _loc_2.addExtension(_loc_3);
                _connection.send(_loc_2);
            }
            return;
        }// end function

        private function addRosterItem(param1:UnescapedJID, param2:String, param3:String, param4:String, param5:Array, param6:String, param7:String = "none") : Boolean
        {
            if (!param1)
            {
                return false;
            }
            var _loc_8:* = RosterItemVO.get(param1, true);
            if (!contains(_loc_8))
            {
                addItem(_loc_8);
            }
            if (param2)
            {
                _loc_8.displayName = param2;
            }
            _loc_8.subscribeType = param6;
            _loc_8.askType = param7;
            _loc_8.status = param4;
            _loc_8.show = param3;
            setContactGroups(_loc_8, param5);
            var _loc_9:* = new RosterEvent(RosterEvent.USER_ADDED);
            new RosterEvent(RosterEvent.USER_ADDED).jid = param1;
            _loc_9.data = _loc_8;
            dispatchEvent(_loc_9);
            return true;
        }// end function

        private static function RosterStaticConstructor() : Boolean
        {
            ExtensionClassRegistry.register(RosterExtension);
            return true;
        }// end function

    }
}
