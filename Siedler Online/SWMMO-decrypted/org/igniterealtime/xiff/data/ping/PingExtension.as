package org.igniterealtime.xiff.data.ping
{
    import flash.xml.*;
    import org.igniterealtime.xiff.data.*;

    public class PingExtension extends Object implements IExtension, ISerializable
    {
        public static const NS:String = "urn:xmpp:ping";
        public static const ELEMENT_NAME:String = "ping";

        public function PingExtension()
        {
            return;
        }// end function

        public function getNS() : String
        {
            return NS;
        }// end function

        public function serialize(param1:XMLNode) : Boolean
        {
            var _loc_2:* = new XMLNode(1, ELEMENT_NAME);
            _loc_2.attributes.xmlns = NS;
            param1.appendChild(_loc_2);
            return true;
        }// end function

        public function getElementName() : String
        {
            return ELEMENT_NAME;
        }// end function

        public function deserialize(param1:XMLNode) : Boolean
        {
            return true;
        }// end function

        public static function enable() : Boolean
        {
            return ExtensionClassRegistry.register();
        }// end function

    }
}
