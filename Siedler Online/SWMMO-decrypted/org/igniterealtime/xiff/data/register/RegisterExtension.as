package org.igniterealtime.xiff.data.register
{
    import flash.xml.*;
    import org.igniterealtime.xiff.data.*;

    public class RegisterExtension extends Extension implements IExtension, ISerializable
    {
        private var _instructionsNode:XMLNode;
        private var _keyNode:XMLNode;
        private var _removeNode:XMLNode;
        private var _fields:Object;
        public static const NS:String = "jabber:iq:register";
        private static var staticDepends:Class = ExtensionClassRegistry;
        public static const ELEMENT_NAME:String = "query";

        public function RegisterExtension(param1:XMLNode = null)
        {
            _fields = {};
            super(param1);
            return;
        }// end function

        public function getElementName() : String
        {
            return RegisterExtension.ELEMENT_NAME;
        }// end function

        public function set first(param1:String) : void
        {
            setField("first", param1);
            return;
        }// end function

        public function get state() : String
        {
            return getField("state");
        }// end function

        public function get last() : String
        {
            return getField("last");
        }// end function

        public function getNS() : String
        {
            return RegisterExtension.NS;
        }// end function

        public function get email() : String
        {
            return getField("email");
        }// end function

        public function get zip() : String
        {
            return getField("zip");
        }// end function

        public function get instructions() : String
        {
            if (_instructionsNode && _instructionsNode.firstChild)
            {
                return _instructionsNode.firstChild.nodeValue;
            }
            return null;
        }// end function

        public function set state(param1:String) : void
        {
            setField("state", param1);
            return;
        }// end function

        public function get password() : String
        {
            return getField("password");
        }// end function

        public function set username(param1:String) : void
        {
            setField("username", param1);
            return;
        }// end function

        public function get text() : String
        {
            return getField("text");
        }// end function

        public function get date() : String
        {
            return getField("date");
        }// end function

        public function set password(param1:String) : void
        {
            setField("password", param1);
            return;
        }// end function

        public function get first() : String
        {
            return getField("first");
        }// end function

        public function setField(param1:String, param2:String) : void
        {
            _fields[param1] = replaceTextNode(getNode(), _fields[param1], param1, param2);
            return;
        }// end function

        public function set last(param1:String) : void
        {
            setField("last", param1);
            return;
        }// end function

        public function get unregister() : Boolean
        {
            return exists(_removeNode);
        }// end function

        public function set key(param1:String) : void
        {
            _keyNode = replaceTextNode(getNode(), _keyNode, "key", param1);
            return;
        }// end function

        public function set email(param1:String) : void
        {
            setField("email", param1);
            return;
        }// end function

        public function getField(param1:String) : String
        {
            var _loc_2:* = _fields[param1];
            if (_loc_2 && _loc_2.firstChild)
            {
                return _loc_2.firstChild.nodeValue;
            }
            return null;
        }// end function

        public function set nick(param1:String) : void
        {
            setField("nick", param1);
            return;
        }// end function

        public function set zip(param1:String) : void
        {
            setField("zip", param1);
            return;
        }// end function

        public function set instructions(param1:String) : void
        {
            _instructionsNode = replaceTextNode(getNode(), _instructionsNode, "instructions", param1);
            return;
        }// end function

        public function get username() : String
        {
            return getField("username");
        }// end function

        public function set text(param1:String) : void
        {
            setField("text", param1);
            return;
        }// end function

        public function set phone(param1:String) : void
        {
            setField("phone", param1);
            return;
        }// end function

        public function set city(param1:String) : void
        {
            setField("city", param1);
            return;
        }// end function

        public function set url(param1:String) : void
        {
            setField("url", param1);
            return;
        }// end function

        public function get key() : String
        {
            if (_keyNode && _keyNode.firstChild)
            {
                return _keyNode.firstChild.nodeValue;
            }
            return null;
        }// end function

        public function serialize(param1:XMLNode) : Boolean
        {
            if (!exists(getNode().parentNode))
            {
                param1.appendChild(getNode().cloneNode(true));
            }
            return true;
        }// end function

        public function getRequiredFieldNames() : Array
        {
            var _loc_2:String = null;
            var _loc_1:Array = [];
            for (_loc_2 in _fields)
            {
                
                _loc_1.push(_loc_2);
            }
            return _loc_1;
        }// end function

        public function set address(param1:String) : void
        {
            setField("address", param1);
            return;
        }// end function

        public function get nick() : String
        {
            return getField("nick");
        }// end function

        public function get city() : String
        {
            return getField("city");
        }// end function

        public function get misc() : String
        {
            return getField("misc");
        }// end function

        public function get phone() : String
        {
            return getField("phone");
        }// end function

        public function get url() : String
        {
            return getField("url");
        }// end function

        public function set misc(param1:String) : void
        {
            setField("misc", param1);
            return;
        }// end function

        public function get address() : String
        {
            return getField("address");
        }// end function

        public function set unregister(param1:Boolean) : void
        {
            _removeNode = replaceTextNode(getNode(), _removeNode, "remove", "");
            return;
        }// end function

        public function set date(param1:String) : void
        {
            setField("date", param1);
            return;
        }// end function

        public function deserialize(param1:XMLNode) : Boolean
        {
            var _loc_3:String = null;
            setNode(param1);
            var _loc_2:* = getNode().childNodes;
            for (_loc_3 in _loc_2)
            {
                
                switch(_loc_2[_loc_3].nodeName)
                {
                    case "key":
                    {
                        _keyNode = _loc_2[_loc_3];
                        break;
                    }
                    case "instructions":
                    {
                        _instructionsNode = _loc_2[_loc_3];
                        break;
                    }
                    case "remove":
                    {
                        _removeNode = _loc_2[_loc_3];
                        break;
                    }
                    default:
                    {
                        _fields[_loc_2[_loc_3].nodeName] = _loc_2[_loc_3];
                        break;
                        break;
                    }
                }
            }
            return true;
        }// end function

        public static function enable() : void
        {
            ExtensionClassRegistry.register(RegisterExtension);
            return;
        }// end function

    }
}
