package mx.messaging.events
{
    import flash.events.*;
    import mx.messaging.messages.*;

    public class MessageEvent extends Event
    {
        public var message:IMessage;
        public static const RESULT:String = "result";
        public static const MESSAGE:String = "message";

        public function MessageEvent(param1:String, param2:Boolean = false, param3:Boolean = false, param4:IMessage = null)
        {
            super(param1, param2, param3);
            this.message = param4;
            return;
        }// end function

        public function get messageId() : String
        {
            if (message != null)
            {
                return message.messageId;
            }
            return null;
        }// end function

        override public function toString() : String
        {
            return formatToString("MessageEvent", "messageId", "type", "bubbles", "cancelable", "eventPhase");
        }// end function

        override public function clone() : Event
        {
            return new MessageEvent(type, bubbles, cancelable, message);
        }// end function

        public static function createEvent(param1:String, param2:IMessage) : MessageEvent
        {
            return new MessageEvent(param1, false, false, param2);
        }// end function

    }
}
