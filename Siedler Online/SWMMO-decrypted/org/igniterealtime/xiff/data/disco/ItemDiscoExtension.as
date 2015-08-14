package org.igniterealtime.xiff.data.disco
{
    import flash.xml.*;
    import org.igniterealtime.xiff.data.*;

    public class ItemDiscoExtension extends DiscoExtension implements IExtension
    {
        private var _items:Array;
        public static const NS:String = "http://jabber.org/protocol/disco#items";

        public function ItemDiscoExtension(param1:XMLNode = null)
        {
            super(param1);
            return;
        }// end function

        public function getElementName() : String
        {
            return DiscoExtension.ELEMENT_NAME;
        }// end function

        public function get items() : Array
        {
            return _items;
        }// end function

        public function getNS() : String
        {
            return ItemDiscoExtension.NS;
        }// end function

        override public function deserialize(param1:XMLNode) : Boolean
        {
            var _loc_2:XMLNode = null;
            if (!super.deserialize(param1))
            {
                return false;
            }
            _items = [];
            for each (_loc_2 in getNode().childNodes)
            {
                
                _items.push(_loc_2.attributes);
            }
            return true;
        }// end function

        public static function enable() : void
        {
            ExtensionClassRegistry.register(ItemDiscoExtension);
            return;
        }// end function

    }
}
