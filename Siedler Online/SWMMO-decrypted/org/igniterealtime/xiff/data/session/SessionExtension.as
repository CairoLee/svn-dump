package org.igniterealtime.xiff.data.session
{
    import flash.xml.*;
    import org.igniterealtime.xiff.data.*;

    public class SessionExtension extends Extension implements IExtension, ISerializable
    {
        private var jid:String;
        public static const NS:String = "urn:ietf:params:xml:ns:xmpp-session";
        public static const ELEMENT_NAME:String = "session";

        public function SessionExtension(param1:XMLNode = null)
        {
            super(param1);
            return;
        }// end function

        public function serialize(param1:XMLNode) : Boolean
        {
            var _loc_2:XMLNode = null;
            if (!exists(getNode().parentNode))
            {
                _loc_2 = getNode().cloneNode(true);
                param1.appendChild(_loc_2);
            }
            return true;
        }// end function

        public function getElementName() : String
        {
            return ELEMENT_NAME;
        }// end function

        public function getNS() : String
        {
            return NS;
        }// end function

        public function deserialize(param1:XMLNode) : Boolean
        {
            setNode(param1);
            return true;
        }// end function

        public function getJID() : String
        {
            return jid;
        }// end function

        public static function enable() : void
        {
            ExtensionClassRegistry.register();
            return;
        }// end function

    }
}
