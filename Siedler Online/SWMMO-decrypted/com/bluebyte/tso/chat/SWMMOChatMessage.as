package com.bluebyte.tso.chat
{
    import com.bluebyte.bluefire.api.extensions.*;
    import flash.xml.*;
    import org.igniterealtime.xiff.data.*;

    public class SWMMOChatMessage extends Extension implements IMessageExtension, ISerializable
    {
        public var mPlayerName:String;
        public var mPlayerID:int;
        public var mPlayerTag:String = "";
        public static var NS:String = "bbmsg";
        public static var ELEMENT_NAME:String = "bbmsg";

        public function SWMMOChatMessage(param1:XMLNode = null)
        {
            super(param1);
            return;
        }// end function

        public function getNS() : String
        {
            return NS;
        }// end function

        public function serialize(param1:XMLNode) : Boolean
        {
            var _loc_2:XMLNode = null;
            if (!exists(getNode().parentNode))
            {
                _loc_2 = getNode().cloneNode(true);
                _loc_2.attributes.playerid = this.mPlayerID;
                _loc_2.attributes.playername = this.mPlayerName;
                _loc_2.attributes.playertag = this.mPlayerTag;
                param1.appendChild(_loc_2);
            }
            return true;
        }// end function

        public function getElementName() : String
        {
            return ELEMENT_NAME;
        }// end function

        public function deserialize(param1:XMLNode) : Boolean
        {
            setNode(param1);
            this.mPlayerID = param1.attributes.playerid;
            this.mPlayerName = param1.attributes.playername;
            this.mPlayerTag = param1.attributes.playertag;
            return true;
        }// end function

        public static function enable() : void
        {
            ExtensionClassRegistry.register();
            return;
        }// end function

    }
}
