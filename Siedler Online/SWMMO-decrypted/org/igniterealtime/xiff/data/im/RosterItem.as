package org.igniterealtime.xiff.data.im
{
    import flash.xml.*;
    import org.igniterealtime.xiff.core.*;
    import org.igniterealtime.xiff.data.*;

    public class RosterItem extends XMLStanza implements ISerializable
    {
        private var myGroupNodes:Array;
        public static const ELEMENT_NAME:String = "item";

        public function RosterItem(param1:XMLNode = null)
        {
            getNode().nodeName = ELEMENT_NAME;
            myGroupNodes = [];
            if (exists(param1))
            {
                param1.appendChild(getNode());
            }
            return;
        }// end function

        public function serialize(param1:XMLNode) : Boolean
        {
            if (!exists(jid))
            {
                trace("Warning: required roster item attributes \'jid\' missing");
                return false;
            }
            if (param1 != getNode().parentNode)
            {
                param1.appendChild(getNode().cloneNode(true));
            }
            return true;
        }// end function

        public function get askType() : String
        {
            return getNode().attributes.ask;
        }// end function

        public function get subscription() : String
        {
            return getNode().attributes.subscription;
        }// end function

        public function get jid() : EscapedJID
        {
            return new EscapedJID(getNode().attributes.jid);
        }// end function

        public function deserialize(param1:XMLNode) : Boolean
        {
            var _loc_3:String = null;
            setNode(param1);
            var _loc_2:* = param1.childNodes;
            for (_loc_3 in _loc_2)
            {
                
                switch(_loc_2[_loc_3].nodeName)
                {
                    case "group":
                    {
                        myGroupNodes.push(_loc_2[_loc_3]);
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

        public function get groupNames() : Array
        {
            var _loc_2:String = null;
            var _loc_3:XMLNode = null;
            var _loc_1:Array = [];
            for (_loc_2 in myGroupNodes)
            {
                
                _loc_3 = myGroupNodes[_loc_2].firstChild;
                if (_loc_3 != null)
                {
                    _loc_1.push(_loc_3.nodeValue);
                }
            }
            return _loc_1;
        }// end function

        public function set jid(param1:EscapedJID) : void
        {
            getNode().attributes.jid = param1.toString();
            return;
        }// end function

        public function get name() : String
        {
            return getNode().attributes.name;
        }// end function

        public function set askType(param1:String) : void
        {
            getNode().attributes.ask = param1;
            return;
        }// end function

        public function get groupCount() : uint
        {
            return myGroupNodes.length;
        }// end function

        public function removeAllGroups() : void
        {
            var _loc_1:String = null;
            for (_loc_1 in myGroupNodes)
            {
                
                myGroupNodes[_loc_1].removeNode();
            }
            myGroupNodes = [];
            return;
        }// end function

        public function set name(param1:String) : void
        {
            getNode().attributes.name = param1;
            return;
        }// end function

        public function get pending() : Boolean
        {
            if (askType == RosterExtension.ASK_TYPE_SUBSCRIBE && (subscription == RosterExtension.SUBSCRIBE_TYPE_NONE || subscription == RosterExtension.SUBSCRIBE_TYPE_FROM))
            {
                return true;
            }
            return false;
        }// end function

        public function set subscription(param1:String) : void
        {
            getNode().attributes.subscription = param1;
            return;
        }// end function

        public function addGroupNamed(param1:String) : void
        {
            var _loc_2:* = addTextNode(getNode(), "group", param1);
            myGroupNodes.push(_loc_2);
            return;
        }// end function

        public function removeGroupByName(param1:String) : Boolean
        {
            var _loc_2:String = null;
            for (_loc_2 in myGroupNodes)
            {
                
                if (myGroupNodes[_loc_2].nodeValue == param1)
                {
                    myGroupNodes[_loc_2].removeNode();
                    myGroupNodes.splice(parseInt(_loc_2), 1);
                    return true;
                }
            }
            return false;
        }// end function

    }
}
