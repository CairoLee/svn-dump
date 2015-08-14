package mx.messaging
{
    import mx.events.*;
    import mx.messaging.messages.*;

    public class Consumer extends AbstractConsumer
    {
        private var _selector:String = "";
        private var _subtopic:String = "";

        public function Consumer(param1:String = "flex.messaging.messages.AsyncMessage")
        {
            return;
        }// end function

        public function set subtopic(param1:String) : void
        {
            var _loc_2:Boolean = false;
            if (subtopic != param1)
            {
                _loc_2 = false;
                if (subscribed)
                {
                    unsubscribe();
                    _loc_2 = true;
                }
                _subtopic = param1;
                if (_loc_2)
                {
                    subscribe();
                }
            }
            return;
        }// end function

        override protected function internalSend(param1:IMessage, param2:Boolean = true) : void
        {
            if (subtopic.length > 0)
            {
                param1.headers[AsyncMessage.SUBTOPIC_HEADER] = subtopic;
            }
            if (_selector.length > 0)
            {
                param1.headers[CommandMessage.SELECTOR_HEADER] = _selector;
            }
            super.internalSend(param1, param2);
            return;
        }// end function

        public function set selector(param1:String) : void
        {
            var _loc_2:PropertyChangeEvent = null;
            var _loc_3:Boolean = false;
            if (_selector !== param1)
            {
                _loc_2 = PropertyChangeEvent.createUpdateEvent(this, "selector", _selector, param1);
                _loc_3 = false;
                if (subscribed)
                {
                    unsubscribe();
                    _loc_3 = true;
                }
                _selector = param1;
                if (_loc_3)
                {
                    subscribe(clientId);
                }
                dispatchEvent(_loc_2);
            }
            return;
        }// end function

        public function get subtopic() : String
        {
            return _subtopic;
        }// end function

        public function get selector() : String
        {
            return _selector;
        }// end function

    }
}
