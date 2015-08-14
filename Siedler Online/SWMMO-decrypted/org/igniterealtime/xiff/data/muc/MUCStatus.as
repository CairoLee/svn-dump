package org.igniterealtime.xiff.data.muc
{
    import flash.xml.*;
    import org.igniterealtime.xiff.data.*;

    public class MUCStatus extends Object
    {
        private var node:XMLNode;
        private var parent:XMLStanza;

        public function MUCStatus(param1:XMLNode, param2:XMLStanza)
        {
            node = param1 ? (param1) : (new XMLNode(1, "status"));
            parent = param2;
            return;
        }// end function

        public function set code(param1:Number) : void
        {
            node.attributes.code = param1.toString();
            return;
        }// end function

        public function get message() : String
        {
            if (node.firstChild)
            {
                return node.firstChild.nodeValue;
            }
            return null;
        }// end function

        public function get code() : Number
        {
            return node.attributes.code;
        }// end function

        public function set message(param1:String) : void
        {
            node = parent.replaceTextNode(parent.getNode(), node, "status", param1);
            return;
        }// end function

    }
}
