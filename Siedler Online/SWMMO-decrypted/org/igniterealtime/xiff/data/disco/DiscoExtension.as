package org.igniterealtime.xiff.data.disco
{
    import flash.xml.*;
    import org.igniterealtime.xiff.core.*;
    import org.igniterealtime.xiff.data.*;

    public class DiscoExtension extends Extension implements ISerializable
    {
        public var _service:EscapedJID;
        public static const NS:String = "http://jabber.org/protocol/disco";
        public static const ELEMENT_NAME:String = "query";

        public function DiscoExtension(param1:XMLNode)
        {
            super(param1);
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

        public function deserialize(param1:XMLNode) : Boolean
        {
            setNode(param1);
            return true;
        }// end function

        public function get service() : EscapedJID
        {
            var _loc_1:* = getNode().parentNode;
            if (_loc_1.attributes.type == "result")
            {
                return new EscapedJID(_loc_1.attributes.from);
            }
            return new EscapedJID(_loc_1.attributes.to);
        }// end function

        public function get serviceNode() : String
        {
            return getNode().parentNode.attributes.node;
        }// end function

        public function set service(param1:EscapedJID) : void
        {
            var _loc_2:* = getNode().parentNode;
            if (_loc_2.attributes.type == "result")
            {
                _loc_2.attributes.from = param1.toString();
            }
            else
            {
                _loc_2.attributes.to = param1.toString();
            }
            return;
        }// end function

        public function set serviceNode(param1:String) : void
        {
            getNode().parentNode.attributes.node = param1;
            return;
        }// end function

    }
}
