package org.igniterealtime.xiff.core
{

    public class EscapedJID extends AbstractJID
    {

        public function EscapedJID(param1:String, param2:Boolean = false)
        {
            super(param1, param2);
            if (node)
            {
                _node = escapedNode(node);
            }
            return;
        }// end function

        public function get unescaped() : UnescapedJID
        {
            return new UnescapedJID(toString());
        }// end function

        public function equals(param1:EscapedJID, param2:Boolean) : Boolean
        {
            if (param2)
            {
                return param1.bareJID == bareJID;
            }
            return param1.toString() == toString();
        }// end function

    }
}
