package org.igniterealtime.xiff.data
{
    import flash.xml.*;
    import org.igniterealtime.xiff.core.*;
    import org.igniterealtime.xiff.data.*;

    public class Presence extends XMPPStanza implements ISerializable
    {
        private var myStatusNode:XMLNode;
        private var myShowNode:XMLNode;
        private var myPriorityNode:XMLNode;
        public static const TYPE_ERROR:String = "error";
        public static const TYPE_SUBSCRIBE:String = "subscribe";
        public static const TYPE_UNSUBSCRIBED:String = "unsubscribed";
        public static const TYPE_UNAVAILABLE:String = "unavailable";
        public static const TYPE_UNSUBSCRIBE:String = "unsubscribe";
        public static const SHOW_XA:String = "xa";
        public static const SHOW_DND:String = "dnd";
        public static const TYPE_PROBE:String = "probe";
        public static const SHOW_AWAY:String = "away";
        public static const SHOW_CHAT:String = "chat";
        public static const TYPE_SUBSCRIBED:String = "subscribed";

        public function Presence(param1:EscapedJID = null, param2:EscapedJID = null, param3:String = null, param4:String = null, param5:String = null, param6:int = 0)
        {
            super(param1, param2, param3, null, "presence");
            show = param4;
            status = param5;
            priority = param6;
            return;
        }// end function

        override public function deserialize(param1:XMLNode) : Boolean
        {
            var _loc_3:Array = null;
            var _loc_4:String = null;
            var _loc_2:* = super.deserialize(param1);
            if (_loc_2)
            {
                _loc_3 = param1.childNodes;
                for (_loc_4 in _loc_3)
                {
                    
                    switch(_loc_3[_loc_4].nodeName)
                    {
                        case "show":
                        {
                            myShowNode = _loc_3[_loc_4];
                            break;
                        }
                        case "status":
                        {
                            myStatusNode = _loc_3[_loc_4];
                            break;
                        }
                        case "priority":
                        {
                            myPriorityNode = _loc_3[_loc_4];
                            break;
                        }
                        default:
                        {
                            break;
                        }
                    }
                }
            }
            return _loc_2;
        }// end function

        public function set priority(param1:int) : void
        {
            myPriorityNode = replaceTextNode(getNode(), myPriorityNode, "priority", param1.toString());
            return;
        }// end function

        public function get priority() : int
        {
            if (myPriorityNode == null)
            {
                return NaN;
            }
            var _loc_1:* = int(myPriorityNode.firstChild.nodeValue);
            if (isNaN(_loc_1))
            {
                return NaN;
            }
            return _loc_1;
        }// end function

        override public function serialize(param1:XMLNode) : Boolean
        {
            return super.serialize(param1);
        }// end function

        public function get status() : String
        {
            if (myStatusNode == null || myStatusNode.firstChild == null)
            {
                return null;
            }
            return myStatusNode.firstChild.nodeValue;
        }// end function

        public function set show(param1:String) : void
        {
            if (param1 != SHOW_AWAY && param1 != SHOW_CHAT && param1 != SHOW_DND && param1 != SHOW_XA && param1 != null && param1 != "")
            {
                throw new Error("Invalid show value: " + param1 + " for presence");
            }
            if (myShowNode && (param1 == null || param1 == ""))
            {
                myShowNode.removeNode();
                myShowNode = null;
            }
            myShowNode = replaceTextNode(getNode(), myShowNode, "show", param1);
            return;
        }// end function

        public function set status(param1:String) : void
        {
            myStatusNode = replaceTextNode(getNode(), myStatusNode, "status", param1);
            return;
        }// end function

        public function get show() : String
        {
            if (!myShowNode || !exists(myShowNode.firstChild))
            {
                return null;
            }
            return myShowNode.firstChild.nodeValue;
        }// end function

    }
}
