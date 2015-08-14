package org.igniterealtime.xiff.data.muc
{
    import flash.xml.*;
    import org.igniterealtime.xiff.core.*;
    import org.igniterealtime.xiff.data.*;

    public class MUCOwnerExtension extends MUCBaseExtension implements IExtension
    {
        private var _destroyNode:XMLNode;
        public static const NS:String = "http://jabber.org/protocol/muc#owner";
        public static const ELEMENT_NAME:String = "query";

        public function MUCOwnerExtension(param1:XMLNode = null)
        {
            super(param1);
            return;
        }// end function

        override public function serialize(param1:XMLNode) : Boolean
        {
            return super.serialize(param1);
        }// end function

        public function getElementName() : String
        {
            return MUCOwnerExtension.ELEMENT_NAME;
        }// end function

        public function destroy(param1:String, param2:EscapedJID = null) : void
        {
            var _loc_3:XMLNode = null;
            _destroyNode = ensureNode(_destroyNode, "destroy");
            for each (_loc_3 in _destroyNode.childNodes)
            {
                
                _loc_3.removeNode();
            }
            if (exists(param1))
            {
                replaceTextNode(_destroyNode, undefined, "reason", param1);
            }
            if (exists(param2))
            {
                _destroyNode.attributes.jid = param2.toString();
            }
            return;
        }// end function

        public function getNS() : String
        {
            return MUCOwnerExtension.NS;
        }// end function

        override public function deserialize(param1:XMLNode) : Boolean
        {
            var _loc_3:String = null;
            super.deserialize(param1);
            var _loc_2:* = param1.childNodes;
            for (_loc_3 in _loc_2)
            {
                
                switch(_loc_2[_loc_3].nodeName)
                {
                    case "destroy":
                    {
                        _destroyNode = _loc_2[_loc_3];
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

    }
}
