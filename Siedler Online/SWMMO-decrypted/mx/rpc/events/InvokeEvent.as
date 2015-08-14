package mx.rpc.events
{
    import flash.events.*;
    import mx.messaging.messages.*;
    import mx.rpc.*;

    public class InvokeEvent extends AbstractEvent
    {
        public static const INVOKE:String = "invoke";

        public function InvokeEvent(param1:String, param2:Boolean = false, param3:Boolean = false, param4:AsyncToken = null, param5:IMessage = null)
        {
            super(param1, param2, param3, param4, param5);
            return;
        }// end function

        override public function toString() : String
        {
            return formatToString("InvokeEvent", "messageId", "type", "bubbles", "cancelable", "eventPhase");
        }// end function

        override public function clone() : Event
        {
            return new InvokeEvent(type, bubbles, cancelable, token, message);
        }// end function

        public static function createEvent(param1:AsyncToken = null, param2:IMessage = null) : InvokeEvent
        {
            return new InvokeEvent(InvokeEvent.INVOKE, false, false, param1, param2);
        }// end function

    }
}
