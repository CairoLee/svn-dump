package mx.messaging
{
    import mx.events.*;
    import mx.logging.*;
    import mx.messaging.messages.*;

    public class Producer extends AbstractProducer
    {
        private var _subtopic:String = "";
        public static const DEFAULT_PRIORITY:int = 4;

        public function Producer()
        {
            _log = Log.getLogger("mx.messaging.Producer");
            _agentType = "producer";
            return;
        }// end function

        override protected function internalSend(param1:IMessage, param2:Boolean = true) : void
        {
            if (subtopic.length > 0)
            {
                param1.headers[AsyncMessage.SUBTOPIC_HEADER] = subtopic;
            }
            handlePriority(param1);
            super.internalSend(param1, param2);
            return;
        }// end function

        private function handlePriority(param1:IMessage) : void
        {
            var _loc_2:int = 0;
            if (param1.headers[AbstractMessage.PRIORITY_HEADER] != null)
            {
                _loc_2 = param1.headers[AbstractMessage.PRIORITY_HEADER];
                if (_loc_2 < 0)
                {
                    param1.headers[AbstractMessage.PRIORITY_HEADER] = 0;
                }
                else if (_loc_2 > 9)
                {
                    param1.headers[AbstractMessage.PRIORITY_HEADER] = 9;
                }
            }
            else if (priority > -1)
            {
                param1.headers[AbstractMessage.PRIORITY_HEADER] = priority;
            }
            return;
        }// end function

        public function set subtopic(param1:String) : void
        {
            var _loc_2:PropertyChangeEvent = null;
            if (_subtopic != param1)
            {
                if (param1 == null)
                {
                    param1 = "";
                }
                _loc_2 = PropertyChangeEvent.createUpdateEvent(this, "subtopic", _subtopic, param1);
                _subtopic = param1;
                dispatchEvent(_loc_2);
            }
            return;
        }// end function

        public function get subtopic() : String
        {
            return _subtopic;
        }// end function

    }
}
