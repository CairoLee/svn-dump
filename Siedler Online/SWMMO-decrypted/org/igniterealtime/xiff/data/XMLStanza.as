package org.igniterealtime.xiff.data
{
    import flash.xml.*;
    import org.igniterealtime.xiff.data.*;

    public class XMLStanza extends ExtensionContainer implements INodeProxy, IExtendable
    {
        private var myXML:XMLNode;
        public static var XMLData:XML = new XML();
        public static var XMLFactory:XMLDocument = new XMLDocument();

        public function XMLStanza()
        {
            myXML = XMLStanza.XMLFactory.createElement("");
            return;
        }// end function

        public function addTextNode(param1:XMLNode, param2:String, param3:String) : XMLNode
        {
            var _loc_4:* = XMLStanza.XMLFactory.createElement(param2);
            XMLStanza.XMLFactory.createElement(param2).appendChild(XMLFactory.createTextNode(param3));
            param1.appendChild(_loc_4);
            return _loc_4;
        }// end function

        public function setNode(param1:XMLNode) : Boolean
        {
            var _loc_2:* = myXML.parentNode;
            myXML.removeNode();
            myXML = param1;
            if (exists(myXML) && _loc_2 != null)
            {
                _loc_2.appendChild(myXML);
            }
            return true;
        }// end function

        public function ensureNode(param1:XMLNode, param2:String) : XMLNode
        {
            if (!exists(param1))
            {
                param1 = XMLStanza.XMLFactory.createElement(param2);
                getNode().appendChild(param1);
            }
            return param1;
        }// end function

        public function getNode() : XMLNode
        {
            return myXML;
        }// end function

        public function replaceTextNode(param1:XMLNode, param2:XMLNode, param3:String, param4:String) : XMLNode
        {
            var _loc_5:XMLNode = null;
            if (param2 != null)
            {
                param2.removeNode();
            }
            if (exists(param4))
            {
                _loc_5 = XMLStanza.XMLFactory.createElement(param3);
                if (param4.length > 0)
                {
                    _loc_5.appendChild(XMLStanza.XMLFactory.createTextNode(param4));
                }
                param1.appendChild(_loc_5);
            }
            return _loc_5;
        }// end function

        public static function exists(param1) : Boolean
        {
            if (param1 != null && param1 !== undefined)
            {
                return true;
            }
            return false;
        }// end function

    }
}
