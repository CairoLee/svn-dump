package org.igniterealtime.xiff.data.muc
{
    import flash.xml.*;
    import org.igniterealtime.xiff.data.*;

    public class MUCExtension extends Extension implements IExtension, ISerializable
    {
        private var myPasswordNode:XMLNode;
        private var myHistoryNode:XMLNode;
        public static const NS:String = "http://jabber.org/protocol/muc";
        public static const ELEMENT_NAME:String = "x";

        public function MUCExtension(param1:XMLNode = null)
        {
            super(param1);
            return;
        }// end function

        public function get since() : String
        {
            return myHistoryNode.attributes.since;
        }// end function

        public function get seconds() : Number
        {
            return Number(myHistoryNode.attributes.seconds);
        }// end function

        public function deserialize(param1:XMLNode) : Boolean
        {
            var _loc_2:XMLNode = null;
            setNode(param1);
            for each (_loc_2 in param1.childNodes)
            {
                
                switch(_loc_2.nodeName)
                {
                    case "history":
                    {
                        myHistoryNode = _loc_2;
                        break;
                    }
                    case "password":
                    {
                        myPasswordNode = _loc_2;
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

        public function get history() : Boolean
        {
            return exists(myHistoryNode);
        }// end function

        public function addChildNode(param1:XMLNode) : void
        {
            getNode().appendChild(param1);
            return;
        }// end function

        public function serialize(param1:XMLNode) : Boolean
        {
            var _loc_3:IExtension = null;
            if (exists(getNode().parentNode))
            {
                return false;
            }
            var _loc_2:* = getNode().cloneNode(true);
            for each (_loc_3 in getAllExtensions())
            {
                
                if (_loc_3 is ISerializable)
                {
                    ISerializable(_loc_3).serialize(_loc_2);
                }
            }
            param1.appendChild(_loc_2);
            return true;
        }// end function

        public function get password() : String
        {
            if (myPasswordNode && myPasswordNode.firstChild)
            {
                return myPasswordNode.firstChild.nodeValue;
            }
            return null;
        }// end function

        public function set history(param1:Boolean) : void
        {
            if (param1)
            {
                myHistoryNode = ensureNode(myHistoryNode, "history");
            }
            else
            {
                myHistoryNode.removeNode();
                myHistoryNode = null;
            }
            return;
        }// end function

        public function getElementName() : String
        {
            return MUCExtension.ELEMENT_NAME;
        }// end function

        public function set maxchars(param1:int) : void
        {
            myHistoryNode = ensureNode(myHistoryNode, "history");
            myHistoryNode.attributes.maxchars = param1.toString();
            return;
        }// end function

        public function set maxstanzas(param1:int) : void
        {
            myHistoryNode = ensureNode(myHistoryNode, "history");
            myHistoryNode.attributes.maxstanzas = param1.toString();
            return;
        }// end function

        public function set password(param1:String) : void
        {
            myPasswordNode = replaceTextNode(getNode(), myPasswordNode, "password", param1);
            return;
        }// end function

        public function get maxchars() : int
        {
            return parseInt(myHistoryNode.attributes.maxchars);
        }// end function

        public function get maxstanzas() : int
        {
            return parseInt(myHistoryNode.attributes.maxstanzas);
        }// end function

        public function set since(param1:String) : void
        {
            myHistoryNode = ensureNode(myHistoryNode, "history");
            myHistoryNode.attributes.since = param1;
            return;
        }// end function

        public function getNS() : String
        {
            return MUCExtension.NS;
        }// end function

        public function set seconds(param1:Number) : void
        {
            myHistoryNode = ensureNode(myHistoryNode, "history");
            myHistoryNode.attributes.seconds = param1.toString();
            return;
        }// end function

    }
}
