package mx.rpc.events
{
    import flash.events.*;
    import mx.messaging.messages.*;
    import mx.rpc.*;

    public class ResultEvent extends AbstractEvent
    {
        private var _headers:Object;
        private var _result:Object;
        private var _statusCode:int;
        public static const RESULT:String = "result";

        public function ResultEvent(param1:String, param2:Boolean = false, param3:Boolean = true, param4:Object = null, param5:AsyncToken = null, param6:IMessage = null)
        {
            super(param1, param2, param3, param5, param6);
            if (param6 != null && param6.headers != null)
            {
                _statusCode = param6.headers[AbstractMessage.STATUS_CODE_HEADER] as int;
            }
            _result = param4;
            return;
        }// end function

        override public function clone() : Event
        {
            return new ResultEvent(type, bubbles, cancelable, result, token, message);
        }// end function

        public function get headers() : Object
        {
            return _headers;
        }// end function

        override public function toString() : String
        {
            return formatToString("ResultEvent", "messageId", "type", "bubbles", "cancelable", "eventPhase");
        }// end function

        override function callTokenResponders() : void
        {
            if (token != null)
            {
                token.applyResult(this);
            }
            return;
        }// end function

        public function get statusCode() : int
        {
            return _statusCode;
        }// end function

        public function set headers(param1:Object) : void
        {
            _headers = param1;
            return;
        }// end function

        public function get result() : Object
        {
            return _result;
        }// end function

        function setResult(param1:Object) : void
        {
            _result = param1;
            return;
        }// end function

        public static function createEvent(param1:Object = null, param2:AsyncToken = null, param3:IMessage = null) : ResultEvent
        {
            return new ResultEvent(ResultEvent.RESULT, false, true, param1, param2, param3);
        }// end function

    }
}
