package mx.messaging.messages
{

    public class ErrorMessage extends AcknowledgeMessage
    {
        public var faultString:String;
        public var extendedData:Object;
        public var rootCause:Object;
        public var faultCode:String;
        public var faultDetail:String;
        public static const RETRYABLE_HINT_HEADER:String = "DSRetryableErrorHint";
        public static const MESSAGE_DELIVERY_IN_DOUBT:String = "Client.Error.DeliveryInDoubt";

        public function ErrorMessage()
        {
            return;
        }// end function

        override public function getSmallMessage() : IMessage
        {
            return null;
        }// end function

    }
}
