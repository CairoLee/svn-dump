package org.igniterealtime.xiff.data
{
    import flash.xml.*;

    public class Extension extends XMLStanza
    {

        public function Extension(param1:XMLNode = null)
        {
            getNode().nodeName = IExtension(this).getElementName();
            getNode().attributes.xmlns = IExtension(this).getNS();
            if (exists(param1))
            {
                param1.appendChild(getNode());
            }
            return;
        }// end function

        public function remove() : void
        {
            getNode().removeNode();
            return;
        }// end function

        public function toString() : String
        {
            return getNode().toString();
        }// end function

    }
}
