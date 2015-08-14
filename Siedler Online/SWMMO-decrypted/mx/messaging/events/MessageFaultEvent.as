package mx.messaging.events
{
    import flash.events.*;
    import mx.messaging.messages.*;

    public class MessageFaultEvent extends Event
    {
        public var message:ErrorMessage;
        public static const FAULT:String = "fault";

        public function MessageFaultEvent(param1:String, param2:Boolean = false, param3:Boolean = false, param4:ErrorMessage = null)
        {
            super(param1, param2, param3);
            this.message = param4;
            return;
        }// end function

        public function get faultString() : String
        {
            return message.faultString;
        }// end function

        public function get faultDetail() : String
        {
            return message.faultDetail;
        }// end function

        public function get rootCause() : Object
        {
            return message.rootCause;
        }// end function

        override public function toString() : String
        {
            return formatToString("MessageFaultEvent", "faultCode", "faultDetail", "faultString", "rootCause", "type", "bubbles", "cancelable", "eventPhase");
        }// end function

        override public function clone() : Event
        {
            return new MessageFaultEvent(type, bubbles, cancelable, message);
        }// end function

        public function get faultCode() : String
        {
            return message.faultCode;
        }// end function

        public static function createEvent(param1:ErrorMessage) : MessageFaultEvent
        {
            return new MessageFaultEvent(MessageFaultEvent.FAULT, false, false, param1);
        }// end function

    }
}
