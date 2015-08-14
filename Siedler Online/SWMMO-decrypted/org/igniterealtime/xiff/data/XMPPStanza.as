package org.igniterealtime.xiff.data
{
    import flash.xml.*;
    import org.igniterealtime.xiff.core.*;
    import org.igniterealtime.xiff.data.*;
    import org.igniterealtime.xiff.data.id.*;

    dynamic public class XMPPStanza extends XMLStanza implements ISerializable, IExtendable
    {
        private var myErrorNode:XMLNode;
        private var myErrorConditionNode:XMLNode;
        public static const CLIENT_VERSION:String = "1.0";
        public static const CLIENT_NAMESPACE:String = "jabber:client";
        public static const NAMESPACE_STREAM:String = "http://etherx.jabber.org/streams";
        public static const NAMESPACE_FLASH:String = "http://www.jabber.com/streams/flash";
        public static const XML_LANG:String = "en";
        private static var staticDependencies:Array = [IncrementalGenerator, ExtensionContainer];
        private static var isStaticConstructed:Object = XMPPStanzaStaticConstructor();

        public function XMPPStanza(param1:EscapedJID, param2:EscapedJID, param3:String, param4:String, param5:String)
        {
            getNode().nodeName = param5;
            to = param1;
            from = param2;
            type = param3;
            id = param4;
            return;
        }// end function

        public function get type() : String
        {
            return getNode().attributes.type;
        }// end function

        public function set errorType(param1:String) : void
        {
            myErrorNode = ensureNode(myErrorNode, "error");
            delete myErrorNode.attributes.type;
            if (exists(param1))
            {
                myErrorNode.attributes.type = param1;
            }
            return;
        }// end function

        public function set from(param1:EscapedJID) : void
        {
            delete getNode().attributes.from;
            if (exists(param1))
            {
                getNode().attributes.from = param1.toString();
            }
            return;
        }// end function

        public function get errorCode() : int
        {
            return parseInt(myErrorNode.attributes.code);
        }// end function

        public function get id() : String
        {
            return getNode().attributes.id;
        }// end function

        public function get errorMessage() : String
        {
            if (exists(errorCondition))
            {
                return errorCondition.toString();
            }
            if (myErrorNode && myErrorNode.firstChild)
            {
                return myErrorNode.firstChild.nodeValue;
            }
            return null;
        }// end function

        public function serialize(param1:XMLNode) : Boolean
        {
            var _loc_4:ISerializable = null;
            var _loc_2:* = getNode();
            var _loc_3:* = getAllExtensions();
            for each (_loc_4 in _loc_3)
            {
                
                _loc_4.serialize(_loc_2);
            }
            if (!exists(_loc_2.parentNode))
            {
                _loc_2 = _loc_2.cloneNode(true);
                param1.appendChild(_loc_2);
            }
            return true;
        }// end function

        public function get errorType() : String
        {
            return myErrorNode.attributes.type;
        }// end function

        public function set errorCondition(param1:String) : void
        {
            myErrorNode = ensureNode(myErrorNode, "error");
            var _loc_2:* = myErrorNode.attributes;
            var _loc_3:* = errorMessage;
            if (exists(param1))
            {
                myErrorNode = replaceTextNode(getNode(), myErrorNode, "error", "");
                myErrorConditionNode = addTextNode(myErrorNode, param1, _loc_3);
            }
            else
            {
                myErrorNode = replaceTextNode(getNode(), myErrorNode, "error", _loc_3);
            }
            myErrorNode.attributes = _loc_2;
            return;
        }// end function

        public function get from() : EscapedJID
        {
            var _loc_1:* = getNode().attributes.from;
            return _loc_1 ? (new EscapedJID(_loc_1)) : (null);
        }// end function

        public function set errorCode(param1:int) : void
        {
            myErrorNode = ensureNode(myErrorNode, "error");
            delete myErrorNode.attributes.code;
            if (exists(param1))
            {
                myErrorNode.attributes.code = param1;
            }
            return;
        }// end function

        public function get errorCondition() : String
        {
            if (exists(myErrorConditionNode))
            {
                return myErrorConditionNode.nodeName;
            }
            return null;
        }// end function

        public function set type(param1:String) : void
        {
            delete getNode().attributes.type;
            if (exists(param1))
            {
                getNode().attributes.type = param1;
            }
            return;
        }// end function

        public function set id(param1:String) : void
        {
            delete getNode().attributes.id;
            if (exists(param1))
            {
                getNode().attributes.id = param1;
            }
            return;
        }// end function

        public function get to() : EscapedJID
        {
            if (!getNode().attributes.to)
            {
                return new EscapedJID(getNode().attributes.from);
            }
            return new EscapedJID(getNode().attributes.to);
        }// end function

        public function set to(param1:EscapedJID) : void
        {
            delete getNode().attributes.to;
            if (exists(param1))
            {
                getNode().attributes.to = param1.toString();
            }
            return;
        }// end function

        public function set errorMessage(param1:String) : void
        {
            var _loc_2:Object = null;
            myErrorNode = ensureNode(myErrorNode, "error");
            param1 = exists(param1) ? (param1) : ("");
            if (exists(errorCondition))
            {
                myErrorConditionNode = replaceTextNode(myErrorNode, myErrorConditionNode, errorCondition, param1);
            }
            else
            {
                _loc_2 = myErrorNode.attributes;
                myErrorNode = replaceTextNode(getNode(), myErrorNode, "error", param1);
                myErrorNode.attributes = _loc_2;
            }
            return;
        }// end function

        public function deserialize(param1:XMLNode) : Boolean
        {
            var _loc_3:String = null;
            var _loc_4:String = null;
            var _loc_5:String = null;
            var _loc_6:Class = null;
            var _loc_7:IExtension = null;
            setNode(param1);
            var _loc_2:* = param1.childNodes;
            for (_loc_3 in _loc_2)
            {
                
                _loc_4 = _loc_2[_loc_3].nodeName;
                _loc_5 = _loc_2[_loc_3].attributes.xmlns;
                _loc_5 = exists(_loc_5) ? (_loc_5) : (CLIENT_NAMESPACE);
                if (_loc_4 == "error")
                {
                    myErrorNode = _loc_2[_loc_3];
                    if (exists(myErrorNode.firstChild.nodeName))
                    {
                        myErrorConditionNode = myErrorNode.firstChild;
                    }
                    continue;
                }
                _loc_6 = ExtensionClassRegistry.lookup(_loc_5);
                if (_loc_6 != null)
                {
                    _loc_7 = new _loc_6;
                    ISerializable(_loc_7).deserialize(_loc_2[_loc_3]);
                    addExtension(_loc_7);
                }
            }
            return true;
        }// end function

        private static function XMPPStanzaStaticConstructor() : void
        {
            return;
        }// end function

        public static function generateID(param1:String) : String
        {
            var _loc_2:* = IncrementalGenerator.getInstance().getID(param1);
            return _loc_2;
        }// end function

        public static function setIDGenerator(param1:IIDGenerator) : void
        {
            return;
        }// end function

    }
}
