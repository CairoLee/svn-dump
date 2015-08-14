package mx.messaging.events
{
    import flash.events.*;
    import mx.messaging.*;
    import mx.messaging.messages.*;

    public class ChannelFaultEvent extends ChannelEvent
    {
        public var faultString:String;
        public var rootCause:Object;
        public var faultDetail:String;
        public var faultCode:String;
        public static const FAULT:String = "channelFault";

        public function ChannelFaultEvent(param1:String, param2:Boolean = false, param3:Boolean = false, param4:Channel = null, param5:Boolean = false, param6:String = null, param7:String = null, param8:String = null, param9:Boolean = false, param10:Boolean = false)
        {
            super(param1, param2, param3, param4, param5, param9, param10);
            faultCode = param6;
            faultString = param7;
            faultDetail = param8;
            return;
        }// end function

        override public function clone() : Event
        {
            var _loc_1:* = new ChannelFaultEvent(type, bubbles, cancelable, channel, reconnecting, faultCode, faultString, faultDetail, rejected, connected);
            _loc_1.rootCause = rootCause;
            return _loc_1;
        }// end function

        public function createErrorMessage() : ErrorMessage
        {
            var _loc_1:* = new ErrorMessage();
            _loc_1.faultCode = faultCode;
            _loc_1.faultString = faultString;
            _loc_1.faultDetail = faultDetail;
            _loc_1.rootCause = rootCause;
            return _loc_1;
        }// end function

        override public function toString() : String
        {
            return formatToString("ChannelFaultEvent", "faultCode", "faultString", "faultDetail", "channelId", "type", "bubbles", "cancelable", "eventPhase");
        }// end function

        public static function createEvent(param1:Channel, param2:Boolean = false, param3:String = null, param4:String = null, param5:String = null, param6:Boolean = false, param7:Boolean = false) : ChannelFaultEvent
        {
            return new ChannelFaultEvent(ChannelFaultEvent.FAULT, false, false, param1, param2, param3, param4, param5, param6, param7);
        }// end function

    }
}
