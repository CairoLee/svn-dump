package org.igniterealtime.xiff.data.disco
{
    import flash.xml.*;
    import org.igniterealtime.xiff.data.*;

    public class InfoDiscoExtension extends DiscoExtension implements IExtension
    {
        private var _features:Array;
        private var _identities:Array;
        public static const NS:String = "http://jabber.org/protocol/disco#info";

        public function InfoDiscoExtension(param1:XMLNode = null)
        {
            super(param1);
            return;
        }// end function

        override public function deserialize(param1:XMLNode) : Boolean
        {
            var _loc_2:XMLNode = null;
            if (!super.deserialize(param1))
            {
                return false;
            }
            _identities = [];
            _features = [];
            for each (_loc_2 in getNode().childNodes)
            {
                
                switch(_loc_2.nodeName)
                {
                    case "identity":
                    {
                        _identities.push(_loc_2.attributes);
                        break;
                    }
                    case "feature":
                    {
                        _features.push(_loc_2.attributes["var"]);
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

        public function getElementName() : String
        {
            return DiscoExtension.ELEMENT_NAME;
        }// end function

        public function getNS() : String
        {
            return InfoDiscoExtension.NS;
        }// end function

        public function get identities() : Array
        {
            return _identities;
        }// end function

        public function get features() : Array
        {
            return _features;
        }// end function

        public static function enable() : void
        {
            ExtensionClassRegistry.register(InfoDiscoExtension);
            return;
        }// end function

    }
}
