package org.igniterealtime.xiff.data.browse
{
    import flash.xml.*;
    import org.igniterealtime.xiff.data.*;

    public class BrowseItem extends XMLStanza implements ISerializable
    {

        public function BrowseItem(param1:XMLNode)
        {
            getNode().nodeName = "item";
            if (exists(param1))
            {
                param1.appendChild(getNode());
            }
            return;
        }// end function

        public function serialize(param1:XMLNode) : Boolean
        {
            var _loc_2:* = getNode();
            if (!exists(_loc_2.parentNode))
            {
                param1.appendChild(_loc_2.cloneNode(true));
            }
            return true;
        }// end function

        public function get type() : String
        {
            return getNode().attributes.type;
        }// end function

        public function get jid() : String
        {
            return getNode().attributes.jid;
        }// end function

        public function set jid(param1:String) : void
        {
            getNode().attributes.jid = param1;
            return;
        }// end function

        public function get name() : String
        {
            return getNode().attributes.name;
        }// end function

        public function set version(param1:String) : void
        {
            getNode().attributes.version = param1;
            return;
        }// end function

        public function get namespaces() : Array
        {
            var _loc_2:XMLNode = null;
            var _loc_1:Array = [];
            for each (_loc_2 in getNode().childNodes)
            {
                
                if (_loc_2.nodeName == "ns")
                {
                    _loc_1.push(_loc_2.firstChild.nodeValue);
                }
            }
            return _loc_1;
        }// end function

        public function set type(param1:String) : void
        {
            getNode().attributes.type = param1;
            return;
        }// end function

        public function set name(param1:String) : void
        {
            getNode().attributes.name = param1;
            return;
        }// end function

        public function get version() : String
        {
            return getNode().attributes.version;
        }// end function

        public function addNamespace(param1:String) : XMLNode
        {
            return addTextNode(getNode(), "ns", param1);
        }// end function

        public function set category(param1:String) : void
        {
            getNode().attributes.category = param1;
            return;
        }// end function

        public function get category() : String
        {
            return getNode().attributes.category;
        }// end function

        public function deserialize(param1:XMLNode) : Boolean
        {
            setNode(param1);
            return true;
        }// end function

    }
}
