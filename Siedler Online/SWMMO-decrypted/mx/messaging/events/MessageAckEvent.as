package mx.messaging.events
{
    import flash.events.*;
    import mx.messaging.messages.*;

    public class MessageAckEvent extends MessageEvent
    {
        public var correlation:IMessage;
        public static const ACKNOWLEDGE:String = "acknowledge";

        public function MessageAckEvent(param1:String, param2:Boolean = false, param3:Boolean = false, param4:AcknowledgeMessage = null, param5:IMessage = null)
        {
            super(param1, param2, param3, param4);
            this.correlation = param5;
            return;
        }// end function

        public function get acknowledgeMessage() : AcknowledgeMessage
        {
            return message as AcknowledgeMessage;
        }// end function

        public function get correlationId() : String
        {
            if (correlation != null)
            {
                return correlation.messageId;
            }
            return null;
        }// end function

        override public function clone() : Event
        {
            return new MessageAckEvent(type, bubbles, cancelable, message as AcknowledgeMessage, correlation);
        }// end function

        override public function toString() : String
        {
            return formatToString("MessageAckEvent", "messageId", "correlationId", "type", "bubbles", "cancelable", "eventPhase");
        }// end function

        public static function createEvent(param1:AcknowledgeMessage = null, param2:IMessage = null) : MessageAckEvent
        {
            return new MessageAckEvent(MessageAckEvent.ACKNOWLEDGE, false, false, param1, param2);
        }// end function

    }
}
