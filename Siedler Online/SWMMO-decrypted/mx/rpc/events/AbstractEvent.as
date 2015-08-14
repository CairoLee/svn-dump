package mx.rpc.events
{
    import mx.messaging.events.*;
    import mx.messaging.messages.*;
    import mx.rpc.*;

    public class AbstractEvent extends MessageEvent
    {
        private var _token:AsyncToken;

        public function AbstractEvent(param1:String, param2:Boolean = false, param3:Boolean = true, param4:AsyncToken = null, param5:IMessage = null)
        {
            super(param1, param2, param3, param5);
            _token = param4;
            return;
        }// end function

        public function get token() : AsyncToken
        {
            return _token;
        }// end function

        function callTokenResponders() : void
        {
            return;
        }// end function

        function setToken(param1:AsyncToken) : void
        {
            _token = param1;
            return;
        }// end function

    }
}
