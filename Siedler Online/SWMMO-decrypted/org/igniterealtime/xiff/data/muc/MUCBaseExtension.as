package org.igniterealtime.xiff.data.muc
{
    import flash.xml.*;
    import org.igniterealtime.xiff.core.*;
    import org.igniterealtime.xiff.data.*;

    public class MUCBaseExtension extends Extension implements IExtendable, ISerializable
    {
        private var _items:Array;

        public function MUCBaseExtension(param1:XMLNode = null)
        {
            _items = [];
            super(param1);
            return;
        }// end function

        public function serialize(param1:XMLNode) : Boolean
        {
            var _loc_6:* = undefined;
            var _loc_2:* = getNode();
            var _loc_3:* = _items.length;
            var _loc_4:uint = 0;
            while (_loc_4 < _loc_3)
            {
                
                if (!_items[_loc_4].serialize(_loc_2))
                {
                    return false;
                }
                _loc_4 = _loc_4 + 1;
            }
            var _loc_5:* = getAllExtensions();
            for each (_loc_6 in _loc_5)
            {
                
                if (!_loc_6.serialize(_loc_2))
                {
                    return false;
                }
            }
            if (param1 != _loc_2.parentNode)
            {
                param1.appendChild(_loc_2.cloneNode(true));
            }
            return true;
        }// end function

        public function addItem(param1:String = null, param2:String = null, param3:String = null, param4:EscapedJID = null, param5:String = null, param6:String = null) : MUCItem
        {
            var _loc_7:* = new MUCItem(getNode());
            if (exists(param1))
            {
                _loc_7.affiliation = param1;
            }
            if (exists(param2))
            {
                _loc_7.role = param2;
            }
            if (exists(param3))
            {
                _loc_7.nick = param3;
            }
            if (exists(param4))
            {
                _loc_7.jid = param4;
            }
            if (exists(param5))
            {
                _loc_7.actor = new EscapedJID(param5);
            }
            if (exists(param6))
            {
                _loc_7.reason = param6;
            }
            _items.push(_loc_7);
            return _loc_7;
        }// end function

        public function getAllItems() : Array
        {
            return _items;
        }// end function

        public function removeAllItems() : void
        {
            var _loc_3:MUCItem = null;
            var _loc_1:* = _items.length;
            var _loc_2:uint = 0;
            while (_loc_2 < _loc_1)
            {
                
                _loc_3 = _items[_loc_2] as MUCItem;
                _loc_3.setNode(null);
                _loc_2 = _loc_2 + 1;
            }
            _items = [];
            return;
        }// end function

        public function deserialize(param1:XMLNode) : Boolean
        {
            var _loc_2:XMLNode = null;
            var _loc_3:MUCItem = null;
            var _loc_4:Class = null;
            var _loc_5:IExtension = null;
            setNode(param1);
            removeAllItems();
            for each (_loc_2 in param1.childNodes)
            {
                
                switch(_loc_2.nodeName)
                {
                    case "item":
                    {
                        _loc_3 = new MUCItem(getNode());
                        _loc_3.deserialize(_loc_2);
                        _items.push(_loc_3);
                        break;
                    }
                    default:
                    {
                        _loc_4 = ExtensionClassRegistry.lookup(_loc_2.attributes.xmlns);
                        if (_loc_4 != null)
                        {
                            _loc_5 = new _loc_4;
                            if (_loc_5 != null)
                            {
                                if (_loc_5 is ISerializable)
                                {
                                    ISerializable(_loc_5).deserialize(_loc_2);
                                }
                                addExtension(_loc_5);
                            }
                        }
                        break;
                        break;
                    }
                }
            }
            return true;
        }// end function

    }
}
