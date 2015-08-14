package mx.messaging
{
    import flash.events.*;
    import flash.utils.*;
    import mx.events.*;
    import mx.logging.*;
    import mx.messaging.events.*;
    import mx.messaging.messages.*;
    import mx.resources.*;

    public class AbstractProducer extends MessageAgent
    {
        private var _priority:int = -1;
        private var _reconnectInterval:int;
        private var _autoConnect:Boolean = true;
        private var _reconnectTimer:Timer;
        protected var _shouldBeConnected:Boolean;
        private var _connectMsg:CommandMessage;
        private var _defaultHeaders:Object;
        private var _currentAttempt:int;
        private var _reconnectAttempts:int;
        private var resourceManager:IResourceManager;

        public function AbstractProducer()
        {
            resourceManager = ResourceManager.getInstance();
            return;
        }// end function

        public function set reconnectAttempts(param1:int) : void
        {
            var _loc_2:PropertyChangeEvent = null;
            if (_reconnectAttempts != param1)
            {
                if (param1 == 0)
                {
                    stopReconnectTimer();
                }
                _loc_2 = PropertyChangeEvent.createUpdateEvent(this, "reconnectAttempts", _reconnectAttempts, param1);
                _reconnectAttempts = param1;
                dispatchEvent(_loc_2);
            }
            return;
        }// end function

        public function get defaultHeaders() : Object
        {
            return _defaultHeaders;
        }// end function

        public function set reconnectInterval(param1:int) : void
        {
            var _loc_2:PropertyChangeEvent = null;
            var _loc_3:String = null;
            if (_reconnectInterval != param1)
            {
                if (param1 < 0)
                {
                    _loc_3 = resourceManager.getString("messaging", "reconnectIntervalNegative");
                    throw new ArgumentError(_loc_3);
                }
                if (param1 == 0)
                {
                    stopReconnectTimer();
                }
                else if (_reconnectTimer != null)
                {
                    _reconnectTimer.delay = param1;
                }
                _loc_2 = PropertyChangeEvent.createUpdateEvent(this, "reconnectInterval", _reconnectInterval, param1);
                _reconnectInterval = param1;
                dispatchEvent(_loc_2);
            }
            return;
        }// end function

        public function set defaultHeaders(param1:Object) : void
        {
            var _loc_2:PropertyChangeEvent = null;
            if (_defaultHeaders != param1)
            {
                _loc_2 = PropertyChangeEvent.createUpdateEvent(this, "defaultHeaders", _defaultHeaders, param1);
                _defaultHeaders = param1;
                dispatchEvent(_loc_2);
            }
            return;
        }// end function

        public function set priority(param1:int) : void
        {
            var _loc_2:PropertyChangeEvent = null;
            if (_priority != param1)
            {
                param1 = param1 < 0 ? (0) : (param1 > 9 ? (9) : (param1));
                _loc_2 = PropertyChangeEvent.createUpdateEvent(this, "priority", _priority, param1);
                _priority = param1;
                dispatchEvent(_loc_2);
            }
            return;
        }// end function

        protected function stopReconnectTimer() : void
        {
            if (_reconnectTimer != null)
            {
                if (Log.isDebug())
                {
                    _log.debug("\'{0}\' {1} stopping reconnect timer.", id, _agentType);
                }
                _reconnectTimer.removeEventListener(TimerEvent.TIMER, reconnect);
                _reconnectTimer.reset();
                _reconnectTimer = null;
            }
            return;
        }// end function

        override public function channelDisconnectHandler(event:ChannelEvent) : void
        {
            super.channelDisconnectHandler(event);
            if (_shouldBeConnected && !event.rejected)
            {
                startReconnectTimer();
            }
            return;
        }// end function

        public function send(param1:IMessage) : void
        {
            var _loc_2:String = null;
            var _loc_3:ErrorMessage = null;
            if (!connected && autoConnect)
            {
                _shouldBeConnected = true;
            }
            if (defaultHeaders != null)
            {
                for (_loc_2 in defaultHeaders)
                {
                    
                    if (!param1.headers.hasOwnProperty(_loc_2))
                    {
                        param1.headers[_loc_2] = defaultHeaders[_loc_2];
                    }
                }
            }
            if (!connected && !autoConnect)
            {
                _shouldBeConnected = false;
                _loc_3 = new ErrorMessage();
                _loc_3.faultCode = "Client.Error.MessageSend";
                _loc_3.faultString = resourceManager.getString("messaging", "producerSendError");
                _loc_3.faultDetail = resourceManager.getString("messaging", "producerSendErrorDetails");
                _loc_3.correlationId = param1.messageId;
                internalFault(_loc_3, param1, false, true);
            }
            else
            {
                if (Log.isInfo())
                {
                    _log.info("\'{0}\' {1} sending message \'{2}\'", id, _agentType, param1.messageId);
                }
                internalSend(param1);
            }
            return;
        }// end function

        private function buildConnectErrorMessage() : ErrorMessage
        {
            var _loc_1:* = new ErrorMessage();
            _loc_1.faultCode = "Client.Error.Connect";
            _loc_1.faultString = resourceManager.getString("messaging", "producerConnectError");
            _loc_1.faultDetail = resourceManager.getString("messaging", "failedToConnect");
            _loc_1.correlationId = _connectMsg.messageId;
            return _loc_1;
        }// end function

        override public function acknowledge(param1:AcknowledgeMessage, param2:IMessage) : void
        {
            if (_disconnectBarrier)
            {
                return;
            }
            super.acknowledge(param1, param2);
            if (param2 is CommandMessage && CommandMessage(param2).operation == CommandMessage.TRIGGER_CONNECT_OPERATION)
            {
                stopReconnectTimer();
            }
            return;
        }// end function

        public function get reconnectInterval() : int
        {
            return _reconnectInterval;
        }// end function

        override public function fault(param1:ErrorMessage, param2:IMessage) : void
        {
            internalFault(param1, param2);
            return;
        }// end function

        override public function disconnect() : void
        {
            _shouldBeConnected = false;
            stopReconnectTimer();
            super.disconnect();
            return;
        }// end function

        function internalFault(param1:ErrorMessage, param2:IMessage, param3:Boolean = true, param4:Boolean = false) : void
        {
            var _loc_5:ErrorMessage = null;
            if (_disconnectBarrier && !param4)
            {
                return;
            }
            if (param2 is CommandMessage && CommandMessage(param2).operation == CommandMessage.TRIGGER_CONNECT_OPERATION)
            {
                if (_reconnectTimer == null)
                {
                    if (_connectMsg != null && param1.correlationId == _connectMsg.messageId)
                    {
                        _shouldBeConnected = false;
                        _loc_5 = buildConnectErrorMessage();
                        _loc_5.rootCause = param1.rootCause;
                        super.fault(_loc_5, param2);
                    }
                    else
                    {
                        super.fault(param1, param2);
                    }
                }
            }
            else
            {
                super.fault(param1, param2);
            }
            return;
        }// end function

        public function connect() : void
        {
            if (!connected)
            {
                _shouldBeConnected = true;
                if (_connectMsg == null)
                {
                    _connectMsg = buildConnectMessage();
                }
                internalSend(_connectMsg, false);
            }
            return;
        }// end function

        public function get priority() : int
        {
            return _priority;
        }// end function

        private function buildConnectMessage() : CommandMessage
        {
            var _loc_1:* = new CommandMessage();
            _loc_1.operation = CommandMessage.TRIGGER_CONNECT_OPERATION;
            _loc_1.clientId = clientId;
            _loc_1.destination = destination;
            return _loc_1;
        }// end function

        protected function reconnect(event:TimerEvent) : void
        {
            if (_reconnectAttempts != -1 && _currentAttempt >= _reconnectAttempts)
            {
                stopReconnectTimer();
                _shouldBeConnected = false;
                fault(buildConnectErrorMessage(), _connectMsg);
                return;
            }
            if (Log.isDebug())
            {
                _log.debug("\'{0}\' {1} trying to reconnect.", id, _agentType);
            }
            _reconnectTimer.delay = _reconnectInterval;
            var _loc_3:* = _currentAttempt + 1;
            _currentAttempt = _loc_3;
            if (_connectMsg == null)
            {
                _connectMsg = buildConnectMessage();
            }
            internalSend(_connectMsg, false);
            return;
        }// end function

        protected function startReconnectTimer() : void
        {
            if (_shouldBeConnected && _reconnectTimer == null)
            {
                if (_reconnectAttempts != 0 && _reconnectInterval > 0)
                {
                    if (Log.isDebug())
                    {
                        _log.debug("\'{0}\' {1} starting reconnect timer.", id, _agentType);
                    }
                    _reconnectTimer = new Timer(1);
                    _reconnectTimer.addEventListener(TimerEvent.TIMER, reconnect);
                    _reconnectTimer.start();
                    _currentAttempt = 0;
                }
            }
            return;
        }// end function

        override public function channelFaultHandler(event:ChannelFaultEvent) : void
        {
            super.channelFaultHandler(event);
            if (_shouldBeConnected && !event.rejected && !event.channel.connected)
            {
                startReconnectTimer();
            }
            return;
        }// end function

        public function set autoConnect(param1:Boolean) : void
        {
            var _loc_2:PropertyChangeEvent = null;
            if (_autoConnect != param1)
            {
                _loc_2 = PropertyChangeEvent.createUpdateEvent(this, "autoConnect", _autoConnect, param1);
                _autoConnect = param1;
                dispatchEvent(_loc_2);
            }
            return;
        }// end function

        public function get autoConnect() : Boolean
        {
            return _autoConnect;
        }// end function

        public function get reconnectAttempts() : int
        {
            return _reconnectAttempts;
        }// end function

    }
}
