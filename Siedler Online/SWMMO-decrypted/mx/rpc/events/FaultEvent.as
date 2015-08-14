package mx.rpc.events
{
    import flash.events.*;
    import mx.messaging.events.*;
    import mx.messaging.messages.*;
    import mx.rpc.*;

    public class FaultEvent extends AbstractEvent
    {
        private var _fault:Fault;
        private var _headers:Object;
        private var _statusCode:int;
        public static const FAULT:String = "fault";

        public function FaultEvent(param1:String, param2:Boolean = false, param3:Boolean = true, param4:Fault = null, param5:AsyncToken = null, param6:IMessage = null)
        {
            super(param1, param2, param3, param5, param6);
            if (param6 != null && param6.headers != null)
            {
                _statusCode = param6.headers[AbstractMessage.STATUS_CODE_HEADER] as int;
            }
            _fault = param4;
            return;
        }// end function

        public function get fault() : Fault
        {
            return _fault;
        }// end function

        public function set headers(param1:Object) : void
        {
            _headers = param1;
            return;
        }// end function

        override function callTokenResponders() : void
        {
            if (token != null)
            {
                token.applyFault(this);
            }
            return;
        }// end function

        public function get headers() : Object
        {
            return _headers;
        }// end function

        override public function toString() : String
        {
            return formatToString("FaultEvent", "fault", "messageId", "type", "bubbles", "cancelable", "eventPhase");
        }// end function

        override public function clone() : Event
        {
            return new FaultEvent(type, bubbles, cancelable, fault, token, message);
        }// end function

        public function get statusCode() : int
        {
            return _statusCode;
        }// end function

        public static function createEventFromMessageFault(event:MessageFaultEvent, param2:AsyncToken = null) : FaultEvent
        {
            var _loc_3:* = new Fault(event.faultCode, event.faultString, event.faultDetail);
            _loc_3.rootCause = event.rootCause;
            return new FaultEvent(FaultEvent.FAULT, false, true, _loc_3, param2, event.message);
        }// end function

        public static function createEvent(param1:Fault, param2:AsyncToken = null, param3:IMessage = null) : FaultEvent
        {
            return new FaultEvent(FaultEvent.FAULT, false, true, param1, param2, param3);
        }// end function

    }
}
