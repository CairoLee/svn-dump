package mx.messaging
{
    import flash.events.*;
    import flash.utils.*;
    import mx.events.*;
    import mx.logging.*;
    import mx.messaging.channels.*;
    import mx.messaging.events.*;
    import mx.messaging.messages.*;
    import mx.resources.*;

    public class AbstractConsumer extends MessageAgent
    {
        private var _currentAttempt:int;
        private var _timestamp:Number = -1;
        private var _resubscribeInterval:int = 5000;
        private var _resubscribeAttempts:int = 5;
        private var _resubscribeTimer:Timer;
        protected var _shouldBeSubscribed:Boolean;
        private var _subscribeMsg:CommandMessage;
        private var _maxFrequency:uint = 0;
        private var _subscribed:Boolean;
        private var resourceManager:IResourceManager;

        public function AbstractConsumer()
        {
            resourceManager = ResourceManager.getInstance();
            _log = Log.getLogger("mx.messaging.Consumer");
            _agentType = "consumer";
            return;
        }// end function

        override public function channelFaultHandler(event:ChannelFaultEvent) : void
        {
            if (!event.channel.connected)
            {
                setSubscribed(false);
            }
            super.channelFaultHandler(event);
            if (_shouldBeSubscribed && !event.rejected && !event.channel.connected)
            {
                startResubscribeTimer();
            }
            return;
        }// end function

        protected function buildUnsubscribeMessage(param1:Boolean) : CommandMessage
        {
            var _loc_2:* = new CommandMessage();
            _loc_2.operation = CommandMessage.UNSUBSCRIBE_OPERATION;
            _loc_2.clientId = clientId;
            _loc_2.destination = destination;
            if (param1)
            {
                _loc_2.headers[CommandMessage.PRESERVE_DURABLE_HEADER] = param1;
            }
            return _loc_2;
        }// end function

        public function receive(param1:Number = 0) : void
        {
            var _loc_2:CommandMessage = null;
            if (clientId != null)
            {
                _loc_2 = new CommandMessage();
                _loc_2.operation = CommandMessage.POLL_OPERATION;
                _loc_2.destination = destination;
                internalSend(_loc_2);
            }
            return;
        }// end function

        protected function resubscribe(event:TimerEvent) : void
        {
            var _loc_2:ErrorMessage = null;
            if (_resubscribeAttempts != -1 && _currentAttempt >= _resubscribeAttempts)
            {
                stopResubscribeTimer();
                _shouldBeSubscribed = false;
                _loc_2 = new ErrorMessage();
                _loc_2.faultCode = "Client.Error.Subscribe";
                _loc_2.faultString = resourceManager.getString("messaging", "consumerSubscribeError");
                _loc_2.faultDetail = resourceManager.getString("messaging", "failedToSubscribe");
                _loc_2.correlationId = _subscribeMsg.messageId;
                fault(_loc_2, _subscribeMsg);
                return;
            }
            if (Log.isDebug())
            {
                _log.debug("\'{0}\' {1} trying to resubscribe.", id, _agentType);
            }
            _resubscribeTimer.delay = _resubscribeInterval;
            var _loc_4:* = _currentAttempt + 1;
            _currentAttempt = _loc_4;
            internalSend(_subscribeMsg, false);
            return;
        }// end function

        override function setClientId(param1:String) : void
        {
            var _loc_2:Boolean = false;
            if (super.clientId != param1)
            {
                _loc_2 = false;
                if (subscribed)
                {
                    unsubscribe();
                    _loc_2 = true;
                }
                super.setClientId(param1);
                if (_loc_2)
                {
                    subscribe(param1);
                }
            }
            return;
        }// end function

        override public function disconnect() : void
        {
            _shouldBeSubscribed = false;
            stopResubscribeTimer();
            setSubscribed(false);
            super.disconnect();
            return;
        }// end function

        public function subscribe(param1:String = null) : void
        {
            var _loc_2:* = param1 != null && super.clientId != param1 ? (true) : (false);
            if (subscribed && _loc_2)
            {
                unsubscribe();
            }
            stopResubscribeTimer();
            _shouldBeSubscribed = true;
            if (_loc_2)
            {
                super.setClientId(param1);
            }
            if (Log.isInfo())
            {
                _log.info("\'{0}\' {1} subscribe.", id, _agentType);
            }
            _subscribeMsg = buildSubscribeMessage();
            internalSend(_subscribeMsg);
            return;
        }// end function

        override public function channelDisconnectHandler(event:ChannelEvent) : void
        {
            setSubscribed(false);
            super.channelDisconnectHandler(event);
            if (_shouldBeSubscribed && !event.rejected)
            {
                startResubscribeTimer();
            }
            return;
        }// end function

        protected function buildSubscribeMessage() : CommandMessage
        {
            var _loc_1:* = new CommandMessage();
            _loc_1.operation = CommandMessage.SUBSCRIBE_OPERATION;
            _loc_1.clientId = clientId;
            _loc_1.destination = destination;
            if (maxFrequency > 0)
            {
                _loc_1.headers[CommandMessage.MAX_FREQUENCY_HEADER] = maxFrequency;
            }
            return _loc_1;
        }// end function

        protected function startResubscribeTimer() : void
        {
            if (_shouldBeSubscribed && _resubscribeTimer == null)
            {
                if (_resubscribeAttempts != 0 && _resubscribeInterval > 0)
                {
                    if (Log.isDebug())
                    {
                        _log.debug("\'{0}\' {1} starting resubscribe timer.", id, _agentType);
                    }
                    _resubscribeTimer = new Timer(1);
                    _resubscribeTimer.addEventListener(TimerEvent.TIMER, resubscribe);
                    _resubscribeTimer.start();
                    _currentAttempt = 0;
                }
            }
            return;
        }// end function

        public function unsubscribe(param1:Boolean = false) : void
        {
            _shouldBeSubscribed = false;
            if (subscribed)
            {
                if (channelSet != null)
                {
                    channelSet.removeEventListener(destination, messageHandler);
                }
                if (Log.isInfo())
                {
                    _log.info("\'{0}\' {1} unsubscribe.", id, _agentType);
                }
                internalSend(buildUnsubscribeMessage(param1));
            }
            else
            {
                stopResubscribeTimer();
            }
            return;
        }// end function

        function messageHandler(event:MessageEvent) : void
        {
            var _loc_3:CommandMessage = null;
            var _loc_2:* = event.message;
            if (_loc_2 is CommandMessage)
            {
                _loc_3 = _loc_2 as CommandMessage;
                switch(_loc_3.operation)
                {
                    case CommandMessage.SUBSCRIPTION_INVALIDATE_OPERATION:
                    {
                        if (channelSet.currentChannel is PollingChannel)
                        {
                            PollingChannel(channelSet.currentChannel).disablePolling();
                        }
                        setSubscribed(false);
                        break;
                    }
                    default:
                    {
                        if (Log.isWarn())
                        {
                            _log.warn("\'{0}\' received a CommandMessage \'{1}\' that could not be handled.", id, CommandMessage.getOperationAsString(_loc_3.operation));
                        }
                        break;
                    }
                }
                return;
            }
            if (_loc_2.timestamp > _timestamp)
            {
                _timestamp = _loc_2.timestamp;
            }
            if (_loc_2 is ErrorMessage)
            {
                dispatchEvent(MessageFaultEvent.createEvent(ErrorMessage(_loc_2)));
            }
            else
            {
                dispatchEvent(MessageEvent.createEvent(MessageEvent.MESSAGE, _loc_2));
            }
            return;
        }// end function

        public function get timestamp() : Number
        {
            return _timestamp;
        }// end function

        public function get maxFrequency() : uint
        {
            return _maxFrequency;
        }// end function

        public function get resubscribeInterval() : int
        {
            return _resubscribeInterval;
        }// end function

        public function get subscribed() : Boolean
        {
            return _subscribed;
        }// end function

        override public function fault(param1:ErrorMessage, param2:IMessage) : void
        {
            if (_disconnectBarrier)
            {
                return;
            }
            if (param1.headers[ErrorMessage.RETRYABLE_HINT_HEADER])
            {
                if (_resubscribeTimer == null)
                {
                    if (_subscribeMsg != null && param1.correlationId == _subscribeMsg.messageId)
                    {
                        _shouldBeSubscribed = false;
                    }
                    super.fault(param1, param2);
                }
            }
            else
            {
                super.fault(param1, param2);
            }
            return;
        }// end function

        override public function set destination(param1:String) : void
        {
            var _loc_2:Boolean = false;
            if (destination != param1)
            {
                _loc_2 = false;
                if (subscribed)
                {
                    unsubscribe();
                    _loc_2 = true;
                }
                super.destination = param1;
                if (_loc_2)
                {
                    subscribe();
                }
            }
            return;
        }// end function

        public function get resubscribeAttempts() : int
        {
            return _resubscribeAttempts;
        }// end function

        protected function stopResubscribeTimer() : void
        {
            if (_resubscribeTimer != null)
            {
                if (Log.isDebug())
                {
                    _log.debug("\'{0}\' {1} stopping resubscribe timer.", id, _agentType);
                }
                _resubscribeTimer.removeEventListener(TimerEvent.TIMER, resubscribe);
                _resubscribeTimer.reset();
                _resubscribeTimer = null;
            }
            return;
        }// end function

        override public function channelConnectHandler(event:ChannelEvent) : void
        {
            super.channelConnectHandler(event);
            if (connected && channelSet != null && channelSet.currentChannel != null && !channelSet.currentChannel.realtime && Log.isWarn())
            {
                _log.warn("\'{0}\' {1} connected over a non-realtime channel \'{2}\'" + " which means channel is not automatically receiving updates via polling or server push.", id, _agentType, channelSet.currentChannel.id);
            }
            return;
        }// end function

        protected function setSubscribed(param1:Boolean) : void
        {
            var _loc_2:PropertyChangeEvent = null;
            if (_subscribed != param1)
            {
                _loc_2 = PropertyChangeEvent.createUpdateEvent(this, "subscribed", _subscribed, param1);
                _subscribed = param1;
                if (_subscribed)
                {
                    ConsumerMessageDispatcher.getInstance().registerSubscription(this);
                    if (channelSet != null && channelSet.currentChannel != null && channelSet.currentChannel is PollingChannel)
                    {
                        PollingChannel(channelSet.currentChannel).enablePolling();
                    }
                }
                else
                {
                    ConsumerMessageDispatcher.getInstance().unregisterSubscription(this);
                    if (channelSet != null && channelSet.currentChannel != null && channelSet.currentChannel is PollingChannel)
                    {
                        PollingChannel(channelSet.currentChannel).disablePolling();
                    }
                }
                dispatchEvent(_loc_2);
            }
            return;
        }// end function

        public function set maxFrequency(param1:uint) : void
        {
            var _loc_2:* = PropertyChangeEvent.createUpdateEvent(this, "maxFrequency", _maxFrequency, param1);
            _maxFrequency = param1;
            dispatchEvent(_loc_2);
            return;
        }// end function

        override public function acknowledge(param1:AcknowledgeMessage, param2:IMessage) : void
        {
            var _loc_3:CommandMessage = null;
            var _loc_4:int = 0;
            var _loc_5:Array = null;
            var _loc_6:IMessage = null;
            if (_disconnectBarrier)
            {
                return;
            }
            if (!param1.headers[AcknowledgeMessage.ERROR_HINT_HEADER] && param2 is CommandMessage)
            {
                _loc_3 = param2 as CommandMessage;
                _loc_4 = _loc_3.operation;
                if (_loc_4 == CommandMessage.MULTI_SUBSCRIBE_OPERATION)
                {
                    if (param2.headers.DSlastUnsub != null)
                    {
                        _loc_4 = CommandMessage.UNSUBSCRIBE_OPERATION;
                    }
                    else
                    {
                        _loc_4 = CommandMessage.SUBSCRIBE_OPERATION;
                    }
                }
                switch(_loc_4)
                {
                    case CommandMessage.UNSUBSCRIBE_OPERATION:
                    {
                        if (Log.isInfo())
                        {
                            _log.info("\'{0}\' {1} acknowledge for unsubscribe.", id, _agentType);
                        }
                        super.setClientId(null);
                        setSubscribed(false);
                        param1.clientId = null;
                        super.acknowledge(param1, param2);
                        break;
                    }
                    case CommandMessage.SUBSCRIBE_OPERATION:
                    {
                        stopResubscribeTimer();
                        if (param1.timestamp > _timestamp)
                        {
                            _timestamp = param1.timestamp - 1;
                        }
                        if (Log.isInfo())
                        {
                            _log.info("\'{0}\' {1} acknowledge for subscribe. Client id \'{2}\' new timestamp {3}", id, _agentType, param1.clientId, _timestamp);
                        }
                        super.setClientId(param1.clientId);
                        setSubscribed(true);
                        super.acknowledge(param1, param2);
                        break;
                    }
                    case CommandMessage.POLL_OPERATION:
                    {
                        if (param1.body != null && param1.body is Array)
                        {
                            _loc_5 = param1.body as Array;
                            for each (_loc_6 in _loc_5)
                            {
                                
                                messageHandler(MessageEvent.createEvent(MessageEvent.MESSAGE, _loc_6));
                            }
                        }
                        super.acknowledge(param1, param2);
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
            else
            {
                super.acknowledge(param1, param2);
            }
            return;
        }// end function

        public function set resubscribeInterval(param1:int) : void
        {
            var _loc_2:PropertyChangeEvent = null;
            var _loc_3:String = null;
            if (_resubscribeInterval != param1)
            {
                if (param1 < 0)
                {
                    _loc_3 = resourceManager.getString("messaging", "resubscribeIntervalNegative");
                    throw new ArgumentError(_loc_3);
                }
                if (param1 == 0)
                {
                    stopResubscribeTimer();
                }
                else if (_resubscribeTimer != null)
                {
                    _resubscribeTimer.delay = param1;
                }
                _loc_2 = PropertyChangeEvent.createUpdateEvent(this, "resubscribeInterval", _resubscribeInterval, param1);
                _resubscribeInterval = param1;
                dispatchEvent(_loc_2);
            }
            return;
        }// end function

        public function set resubscribeAttempts(param1:int) : void
        {
            var _loc_2:PropertyChangeEvent = null;
            if (_resubscribeAttempts != param1)
            {
                if (param1 == 0)
                {
                    stopResubscribeTimer();
                }
                _loc_2 = PropertyChangeEvent.createUpdateEvent(this, "resubscribeAttempts", _resubscribeAttempts, param1);
                _resubscribeAttempts = param1;
                dispatchEvent(_loc_2);
            }
            return;
        }// end function

        public function set timestamp(param1:Number) : void
        {
            var _loc_2:PropertyChangeEvent = null;
            if (_timestamp != param1)
            {
                _loc_2 = PropertyChangeEvent.createUpdateEvent(this, "timestamp", _timestamp, param1);
                _timestamp = param1;
                dispatchEvent(_loc_2);
            }
            return;
        }// end function

    }
}
