package org.igniterealtime.xiff.data.muc
{
    import flash.xml.*;
    import org.igniterealtime.xiff.data.*;

    public class MUCAdminExtension extends MUCBaseExtension implements IExtension
    {
        private var _items:Array;
        public static const NS:String = "http://jabber.org/protocol/muc#admin";
        public static const ELEMENT_NAME:String = "query";

        public function MUCAdminExtension(param1:XMLNode = null)
        {
            super(param1);
            return;
        }// end function

        public function getElementName() : String
        {
            return MUCAdminExtension.ELEMENT_NAME;
        }// end function

        public function getNS() : String
        {
            return MUCAdminExtension.NS;
        }// end function

    }
}
