package org.igniterealtime.xiff.data
{
    import flash.xml.*;
    import org.igniterealtime.xiff.core.*;
    import org.igniterealtime.xiff.data.*;

    public class IQ extends XMPPStanza implements ISerializable
    {
        private var myErrorCallback:Function;
        private var myQueryName:String;
        private var myCallback:Function;
        private var myQueryFields:Array;
        public static const TYPE_GET:String = "get";
        public static const TYPE_ERROR:String = "error";
        public static const TYPE_RESULT:String = "result";
        public static const TYPE_SET:String = "set";

        public function IQ(param1:EscapedJID = null, param2:String = null, param3:String = null, param4:Function = null, param5:Function = null)
        {
            var _loc_6:* = exists(param3) ? (param3) : (generateID("iq_"));
            super(param1, null, param2, _loc_6, "iq");
            callback = param4;
            errorCallback = param5;
            return;
        }// end function

        override public function serialize(param1:XMLNode) : Boolean
        {
            return super.serialize(param1);
        }// end function

        public function get callback() : Function
        {
            return myCallback;
        }// end function

        public function get errorCallback() : Function
        {
            return myErrorCallback;
        }// end function

        public function set callback(param1:Function) : void
        {
            myCallback = param1;
            return;
        }// end function

        public function set errorCallback(param1:Function) : void
        {
            myErrorCallback = param1;
            return;
        }// end function

        override public function deserialize(param1:XMLNode) : Boolean
        {
            return super.deserialize(param1);
        }// end function

    }
}
