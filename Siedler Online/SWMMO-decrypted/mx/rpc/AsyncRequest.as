package mx.rpc
{
    import mx.messaging.*;
    import mx.messaging.events.*;
    import mx.messaging.messages.*;

    public class AsyncRequest extends Producer
    {
        private var _pendingRequests:Object;

        public function AsyncRequest()
        {
            _pendingRequests = {};
            return;
        }// end function

        override public function hasPendingRequestForMessage(param1:IMessage) : Boolean
        {
            var _loc_2:* = param1.messageId;
            return _pendingRequests[_loc_2];
        }// end function

        override public function fault(param1:ErrorMessage, param2:IMessage) : void
        {
            super.fault(param1, param2);
            if (_ignoreFault)
            {
                return;
            }
            var _loc_3:* = param2.messageId;
            var _loc_4:* = IResponder(_pendingRequests[_loc_3]);
            if (IResponder(_pendingRequests[_loc_3]))
            {
                delete _pendingRequests[_loc_3];
                _loc_4.fault(MessageFaultEvent.createEvent(param1));
            }
            return;
        }// end function

        public function invoke(param1:IMessage, param2:IResponder) : void
        {
            _pendingRequests[param1.messageId] = param2;
            send(param1);
            return;
        }// end function

        override public function acknowledge(param1:AcknowledgeMessage, param2:IMessage) : void
        {
            var _loc_4:String = null;
            var _loc_5:IResponder = null;
            var _loc_3:* = param1.headers[AcknowledgeMessage.ERROR_HINT_HEADER];
            super.acknowledge(param1, param2);
            if (!_loc_3)
            {
                _loc_4 = param1.correlationId;
                _loc_5 = IResponder(_pendingRequests[_loc_4]);
                if (_loc_5)
                {
                    delete _pendingRequests[_loc_4];
                    _loc_5.result(MessageEvent.createEvent(MessageEvent.RESULT, param1));
                }
            }
            return;
        }// end function

    }
}
