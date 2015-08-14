package org.igniterealtime.xiff.data.bind
{
    import flash.xml.*;
    import org.igniterealtime.xiff.core.*;
    import org.igniterealtime.xiff.data.*;

    public class BindExtension extends Extension implements IExtension, ISerializable
    {
        private var _jid:EscapedJID;
        private var _resource:String;
        public static const NS:String = "urn:ietf:params:xml:ns:xmpp-bind";
        public static const ELEMENT_NAME:String = "bind";

        public function BindExtension(param1:XMLNode = null)
        {
            super(param1);
            return;
        }// end function

        public function serialize(param1:XMLNode) : Boolean
        {
            var _loc_2:XMLNode = null;
            var _loc_3:XMLNode = null;
            if (!exists(getNode().parentNode))
            {
                _loc_2 = getNode().cloneNode(true);
                _loc_3 = new XMLNode(1, "resource");
                _loc_3.appendChild(XMLStanza.XMLFactory.createTextNode(resource ? (resource) : ("xiff")));
                _loc_2.appendChild(_loc_3);
                param1.appendChild(_loc_2);
            }
            return true;
        }// end function

        public function get jid() : EscapedJID
        {
            return _jid;
        }// end function

        public function getElementName() : String
        {
            return ELEMENT_NAME;
        }// end function

        public function get resource() : String
        {
            return _resource;
        }// end function

        public function getNS() : String
        {
            return NS;
        }// end function

        public function set resource(param1:String) : void
        {
            _resource = param1;
            return;
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
                    case "jid":
                    {
                        _jid = new EscapedJID(_loc_2[_loc_3].firstChild.nodeValue);
                        break;
                    }
                    default:
                    {
                        throw "Unknown element: " + _loc_2[_loc_3].nodeName;
                        break;
                    }
                }
            }
            return true;
        }// end function

        public static function enable() : void
        {
            ExtensionClassRegistry.register();
            return;
        }// end function

    }
}
