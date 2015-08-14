package org.igniterealtime.xiff.data.im
{
    import flash.xml.*;
    import org.igniterealtime.xiff.core.*;
    import org.igniterealtime.xiff.data.*;

    public class RosterExtension extends Extension implements IExtension, ISerializable
    {
        private var _items:Array;
        public static const NS:String = "jabber:iq:roster";
        public static const SUBSCRIBE_TYPE_NONE:String = "none";
        public static const SUBSCRIBE_TYPE_TO:String = "to";
        public static const ELEMENT_NAME:String = "query";
        public static const SUBSCRIBE_TYPE_BOTH:String = "both";
        public static const ASK_TYPE_SUBSCRIBE:String = "subscribe";
        public static const SUBSCRIBE_TYPE_REMOVE:String = "remove";
        public static const ASK_TYPE_UNSUBSCRIBE:String = "unsubscribe";
        public static const SHOW_UNAVAILABLE:String = "unavailable";
        public static const SHOW_PENDING:String = "Pending";
        public static const ASK_TYPE_NONE:String = "none";
        private static var staticDepends:Array = [ExtensionClassRegistry];
        public static const SUBSCRIBE_TYPE_FROM:String = "from";

        public function RosterExtension(param1:XMLNode = null)
        {
            _items = [];
            super(param1);
            return;
        }// end function

        public function serialize(param1:XMLNode) : Boolean
        {
            var _loc_3:String = null;
            var _loc_2:* = getNode();
            for (_loc_3 in _items)
            {
                
                if (!_items[_loc_3].serialize(_loc_2))
                {
                    return false;
                }
            }
            if (!exists(getNode().parentNode))
            {
                param1.appendChild(getNode().cloneNode(true));
            }
            return true;
        }// end function

        public function removeAllItems() : void
        {
            var _loc_1:String = null;
            for (_loc_1 in _items)
            {
                
                _items[_loc_1].setNode(null);
            }
            _items = [];
            return;
        }// end function

        public function getItemByJID(param1:EscapedJID) : RosterItem
        {
            var _loc_2:String = null;
            for (_loc_2 in _items)
            {
                
                if (_items[_loc_2].jid == param1.toString())
                {
                    return _items[_loc_2];
                }
            }
            return null;
        }// end function

        public function addItem(param1:EscapedJID = null, param2:String = "", param3:String = "", param4:Array = null) : void
        {
            var _loc_6:String = null;
            var _loc_5:* = new RosterItem(getNode());
            if (exists(param1))
            {
                _loc_5.jid = param1;
            }
            if (exists(param2))
            {
                _loc_5.subscription = param2;
            }
            if (exists(param3))
            {
                _loc_5.name = param3;
            }
            if (exists(param4))
            {
                for each (_loc_6 in param4)
                {
                    
                    if (_loc_6)
                    {
                        _loc_5.addGroupNamed(_loc_6);
                    }
                }
            }
            return;
        }// end function

        public function getAllItems() : Array
        {
            return _items;
        }// end function

        public function getElementName() : String
        {
            return RosterExtension.ELEMENT_NAME;
        }// end function

        public function getNS() : String
        {
            return RosterExtension.NS;
        }// end function

        public function deserialize(param1:XMLNode) : Boolean
        {
            var _loc_3:String = null;
            var _loc_4:RosterItem = null;
            setNode(param1);
            removeAllItems();
            var _loc_2:* = param1.childNodes;
            for (_loc_3 in _loc_2)
            {
                
                switch(_loc_2[_loc_3].nodeName)
                {
                    case "item":
                    {
                        _loc_4 = new RosterItem(getNode());
                        if (!_loc_4.deserialize(_loc_2[_loc_3]))
                        {
                            return false;
                        }
                        _items.push(_loc_4);
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
            return true;
        }// end function

        public static function enable() : void
        {
            ExtensionClassRegistry.register(RosterExtension);
            return;
        }// end function

    }
}
