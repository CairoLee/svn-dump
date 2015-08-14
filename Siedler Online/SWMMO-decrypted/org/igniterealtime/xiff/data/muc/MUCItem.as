package org.igniterealtime.xiff.data.muc
{
    import flash.xml.*;
    import org.igniterealtime.xiff.core.*;
    import org.igniterealtime.xiff.data.*;

    public class MUCItem extends XMLStanza implements ISerializable
    {
        private var myActorNode:XMLNode;
        private var myReasonNode:XMLNode;
        public static const ELEMENT_NAME:String = "item";

        public function MUCItem(param1:XMLNode = null)
        {
            getNode().nodeName = ELEMENT_NAME;
            if (exists(param1))
            {
                param1.appendChild(getNode());
            }
            return;
        }// end function

        public function serialize(param1:XMLNode) : Boolean
        {
            if (param1 != getNode().parentNode)
            {
                param1.appendChild(getNode().cloneNode(true));
            }
            return true;
        }// end function

        public function get nick() : String
        {
            return getNode().attributes.nick;
        }// end function

        public function get jid() : EscapedJID
        {
            if (getNode().attributes.jid == null)
            {
                return null;
            }
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
                    case "actor":
                    {
                        myActorNode = _loc_2[_loc_3];
                        break;
                    }
                    case "reason":
                    {
                        myReasonNode = _loc_2[_loc_3];
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

        public function set reason(param1:String) : void
        {
            myReasonNode = replaceTextNode(getNode(), myReasonNode, "reason", param1);
            return;
        }// end function

        public function set actor(param1:EscapedJID) : void
        {
            myActorNode = ensureNode(myActorNode, "actor");
            myActorNode.attributes.jid = param1.toString();
            return;
        }// end function

        public function set role(param1:String) : void
        {
            getNode().attributes.role = param1;
            return;
        }// end function

        public function set nick(param1:String) : void
        {
            getNode().attributes.nick = param1;
            return;
        }// end function

        public function set affiliation(param1:String) : void
        {
            getNode().attributes.affiliation = param1;
            return;
        }// end function

        public function get affiliation() : String
        {
            return getNode().attributes.affiliation;
        }// end function

        public function set jid(param1:EscapedJID) : void
        {
            getNode().attributes.jid = param1.toString();
            return;
        }// end function

        public function get actor() : EscapedJID
        {
            return new EscapedJID(myActorNode.attributes.jid);
        }// end function

        public function get reason() : String
        {
            if (myReasonNode && myReasonNode.firstChild)
            {
                return myReasonNode.firstChild.nodeValue;
            }
            return null;
        }// end function

        public function get role() : String
        {
            return getNode().attributes.role;
        }// end function

    }
}
