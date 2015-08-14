package org.igniterealtime.xiff.data.xhtml
{
    import flash.xml.*;
    import org.igniterealtime.xiff.data.*;

    public class XHTMLExtension extends Extension implements IExtension, ISerializable
    {
        public static const NS:String = "http://jabber.org/protocol/xhtml-im";
        private static var staticDepends:Class = ExtensionClassRegistry;
        public static const ELEMENT_NAME:String = "html";

        public function XHTMLExtension(param1:XMLNode = null)
        {
            super(param1);
            return;
        }// end function

        public function serialize(param1:XMLNode) : Boolean
        {
            return true;
        }// end function

        public function getElementName() : String
        {
            return XHTMLExtension.ELEMENT_NAME;
        }// end function

        public function set body(param1:String) : void
        {
            var _loc_2:XMLNode = null;
            for each (_loc_2 in getNode().childNodes)
            {
                
                _loc_2.removeNode();
            }
            getNode().appendChild(new XMLDocument(param1));
            return;
        }// end function

        public function deserialize(param1:XMLNode) : Boolean
        {
            getNode().appendChild(param1.cloneNode(true));
            return true;
        }// end function

        public function get body() : String
        {
            var _loc_2:XMLNode = null;
            var _loc_1:Array = [];
            for each (_loc_2 in getNode().childNodes)
            {
                
                _loc_1.unshift(_loc_2.toString());
            }
            return _loc_1.join();
        }// end function

        public function getNS() : String
        {
            return XHTMLExtension.NS;
        }// end function

        public static function enable() : void
        {
            ExtensionClassRegistry.register(XHTMLExtension);
            return;
        }// end function

    }
}
