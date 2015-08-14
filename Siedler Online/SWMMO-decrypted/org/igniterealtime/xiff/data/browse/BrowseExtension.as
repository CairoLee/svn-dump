package org.igniterealtime.xiff.data.browse
{
    import flash.xml.*;
    import org.igniterealtime.xiff.data.*;

    public class BrowseExtension extends BrowseItem implements IExtension, ISerializable
    {
        private var _items:Array;
        public static const NS:String = "jabber:iq:browse";
        private static var staticDepends:Class = ExtensionClassRegistry;
        public static const ELEMENT_NAME:String = "query";

        public function BrowseExtension(param1:XMLNode = null)
        {
            _items = [];
            super(param1);
            getNode().attributes.xmlns = getNS();
            getNode().nodeName = getElementName();
            return;
        }// end function

        override public function serialize(param1:XMLNode) : Boolean
        {
            var _loc_3:BrowseItem = null;
            var _loc_2:* = getNode();
            for each (_loc_3 in _items)
            {
                
                _loc_3.serialize(_loc_2);
            }
            if (!exists(_loc_2.parentNode))
            {
                param1.appendChild(_loc_2.cloneNode(true));
            }
            return true;
        }// end function

        public function get items() : Array
        {
            return _items;
        }// end function

        public function addItem(param1:BrowseItem) : BrowseItem
        {
            _items.push(param1);
            return param1;
        }// end function

        public function getElementName() : String
        {
            return BrowseExtension.ELEMENT_NAME;
        }// end function

        public function getNS() : String
        {
            return BrowseExtension.NS;
        }// end function

        override public function deserialize(param1:XMLNode) : Boolean
        {
            var _loc_2:XMLNode = null;
            var _loc_3:BrowseItem = null;
            setNode(param1);
            this["deserialized"] = true;
            _items = [];
            for each (_loc_2 in param1.childNodes)
            {
                
                switch(_loc_2.nodeName)
                {
                    case "item":
                    {
                        _loc_3 = new BrowseItem(getNode());
                        _loc_3.deserialize(_loc_2);
                        _items.push(_loc_3);
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

        public static function enable() : void
        {
            ExtensionClassRegistry.register(BrowseExtension);
            return;
        }// end function

    }
}
