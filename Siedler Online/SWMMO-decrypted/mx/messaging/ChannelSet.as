package mx.messaging
{
    import flash.errors.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.events.*;
    import mx.messaging.channels.*;
    import mx.messaging.config.*;
    import mx.messaging.errors.*;
    import mx.messaging.events.*;
    import mx.messaging.messages.*;
    import mx.resources.*;
    import mx.rpc.*;
    import mx.rpc.events.*;
    import mx.utils.*;

    public class ChannelSet extends EventDispatcher
    {
        private var _shouldHunt:Boolean;
        private var _connected:Boolean;
        private var _hasRequestedClusterEndpoints:Boolean;
        private var _clustered:Boolean;
        private var _channels:Array;
        private var _hunting:Boolean;
        private var _authenticated:Boolean;
        private var _pendingMessages:Dictionary;
        private var _authAgent:AuthenticationAgent;
        private var resourceManager:IResourceManager;
        private var _heartbeatTimer:Timer;
        private var _credentials:String;
        private var _reconnectTimer:Timer = null;
        private var _credentialsCharset:String;
        private var _initialDestinationId:String;
        private var _shouldBeConnected:Boolean;
        private var _connecting:Boolean;
        private var _channelIds:Array;
        private var _configured:Boolean;
        private var _heartbeatInterval:int = 0;
        private var _currentChannel:Channel;
        private var _currentChannelIndex:int;
        private var _pendingSends:Array;
        private var _messageAgents:Array;
        private var _channelFailoverURIs:Object;

        public function ChannelSet(param1:Array = null, param2:Boolean = false)
        {
            resourceManager = ResourceManager.getInstance();
            _clustered = param2;
            _connected = false;
            _connecting = false;
            _currentChannelIndex = -1;
            if (param1 != null)
            {
                _channelIds = param1;
                _channels = new Array(_channelIds.length);
                _configured = true;
            }
            else
            {
                _channels = [];
                _configured = false;
            }
            _hasRequestedClusterEndpoints = false;
            _hunting = false;
            _messageAgents = [];
            _pendingMessages = new Dictionary();
            _pendingSends = [];
            _shouldBeConnected = false;
            _shouldHunt = true;
            return;
        }// end function

        private function reconnectChannel(event:TimerEvent) : void
        {
            _reconnectTimer.stop();
            _reconnectTimer.removeEventListener(TimerEvent.TIMER, reconnectChannel);
            _reconnectTimer = null;
            connectChannel();
            return;
        }// end function

        public function get connected() : Boolean
        {
            return _connected;
        }// end function

        public function login(param1:String, param2:String, param3:String = null) : AsyncToken
        {
            var _loc_7:String = null;
            var _loc_8:Base64Encoder = null;
            if (authenticated)
            {
                throw new IllegalOperationError("ChannelSet is already authenticated.");
            }
            if (_authAgent != null && _authAgent.state != AuthenticationAgent.LOGGED_OUT_STATE)
            {
                throw new IllegalOperationError("ChannelSet is in the process of logging in or logging out.");
            }
            if (param3 != Base64Encoder.CHARSET_UTF_8)
            {
                param3 = null;
            }
            var _loc_4:String = null;
            if (param1 != null && param2 != null)
            {
                _loc_7 = param1 + ":" + param2;
                _loc_8 = new Base64Encoder();
                if (param3 == Base64Encoder.CHARSET_UTF_8)
                {
                    _loc_8.encodeUTFBytes(_loc_7);
                }
                else
                {
                    _loc_8.encode(_loc_7);
                }
                _loc_4 = _loc_8.drain();
            }
            var _loc_5:* = new CommandMessage();
            new CommandMessage().operation = CommandMessage.LOGIN_OPERATION;
            _loc_5.body = _loc_4;
            if (param3 != null)
            {
                _loc_5.headers[CommandMessage.CREDENTIALS_CHARSET_HEADER] = param3;
            }
            _loc_5.destination = "auth";
            var _loc_6:* = new AsyncToken(_loc_5);
            if (_authAgent == null)
            {
                _authAgent = new AuthenticationAgent(this);
            }
            _authAgent.registerToken(_loc_6);
            _authAgent.state = AuthenticationAgent.LOGGING_IN_STATE;
            send(_authAgent, _loc_5);
            return _loc_6;
        }// end function

        protected function sendHeartbeat() : void
        {
            var _loc_1:* = currentChannel as PollingChannel;
            if (_loc_1 != null && _loc_1._shouldPoll)
            {
                return;
            }
            var _loc_2:* = new CommandMessage();
            _loc_2.operation = CommandMessage.CLIENT_PING_OPERATION;
            _loc_2.headers[CommandMessage.HEARTBEAT_HEADER] = true;
            currentChannel.sendInternalMessage(new MessageResponder(null, _loc_2));
            return;
        }// end function

        private function hunt() : Boolean
        {
            var _loc_1:String = null;
            if (_channels.length == 0)
            {
                _loc_1 = resourceManager.getString("messaging", "noAvailableChannels");
                throw new NoChannelAvailableError(_loc_1);
            }
            if (_currentChannel != null)
            {
                disconnectChannel();
            }
            if (++_currentChannelIndex >= _channels.length)
            {
                _currentChannelIndex = -1;
                return false;
            }
            if (_currentChannelIndex > 0)
            {
                _hunting = true;
            }
            if (configured)
            {
                if (_channels[_currentChannelIndex] != null)
                {
                    _currentChannel = _channels[_currentChannelIndex];
                }
                else
                {
                    _currentChannel = ServerConfig.getChannel(_channelIds[_currentChannelIndex], _clustered);
                    _currentChannel.setCredentials(_credentials);
                    _channels[_currentChannelIndex] = _currentChannel;
                }
            }
            else
            {
                _currentChannel = _channels[_currentChannelIndex];
            }
            if (_channelFailoverURIs != null && _channelFailoverURIs[_currentChannel.id] != null)
            {
                _currentChannel.failoverURIs = _channelFailoverURIs[_currentChannel.id];
            }
            return true;
        }// end function

        public function get clustered() : Boolean
        {
            return _clustered;
        }// end function

        public function disconnect(param1:MessageAgent) : void
        {
            var _loc_2:Array = null;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            var _loc_8:PendingSend = null;
            if (param1 == null)
            {
                _loc_2 = _messageAgents.slice();
                _loc_3 = _loc_2.length;
                _loc_4 = 0;
                while (_loc_4 < _loc_3)
                {
                    
                    _loc_2[_loc_4].disconnect();
                    _loc_4++;
                }
                if (_authAgent != null)
                {
                    _authAgent.state = AuthenticationAgent.SHUTDOWN_STATE;
                    _authAgent = null;
                }
            }
            else
            {
                _loc_5 = param1 != null ? (_messageAgents.indexOf(param1)) : (-1);
                if (_loc_5 != -1)
                {
                    _messageAgents.splice(_loc_5, 1);
                    removeEventListener(ChannelEvent.CONNECT, param1.channelConnectHandler);
                    removeEventListener(ChannelEvent.DISCONNECT, param1.channelDisconnectHandler);
                    removeEventListener(ChannelFaultEvent.FAULT, param1.channelFaultHandler);
                    if (connected || _connecting)
                    {
                        param1.channelDisconnectHandler(ChannelEvent.createEvent(ChannelEvent.DISCONNECT, _currentChannel, false));
                    }
                    else
                    {
                        _loc_6 = _pendingSends.length;
                        _loc_7 = 0;
                        while (_loc_7 < _loc_6)
                        {
                            
                            _loc_8 = PendingSend(_pendingSends[_loc_7]);
                            if (_loc_8.agent == param1)
                            {
                                _pendingSends.splice(_loc_7, 1);
                                _loc_7 = _loc_7 - 1;
                                _loc_6 = _loc_6 - 1;
                                delete _pendingMessages[_loc_8.message];
                            }
                            _loc_7++;
                        }
                    }
                    if (_messageAgents.length == 0)
                    {
                        _shouldBeConnected = false;
                        _currentChannelIndex = -1;
                        if (connected)
                        {
                            disconnectChannel();
                        }
                    }
                    if (param1.channelSetMode == MessageAgent.AUTO_CONFIGURED_CHANNELSET)
                    {
                        param1.internalSetChannelSet(null);
                    }
                }
            }
            return;
        }// end function

        public function set channels(param1:Array) : void
        {
            var _loc_5:String = null;
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            if (configured)
            {
                _loc_5 = resourceManager.getString("messaging", "cannotAddWhenConfigured");
                throw new IllegalOperationError(_loc_5);
            }
            var _loc_2:* = _channels.slice();
            var _loc_3:* = _loc_2.length;
            var _loc_4:int = 0;
            while (_loc_4 < _loc_3)
            {
                
                removeChannel(_loc_2[_loc_4]);
                _loc_4++;
            }
            if (param1 != null && param1.length > 0)
            {
                _loc_6 = param1.length;
                _loc_7 = 0;
                while (_loc_7 < _loc_6)
                {
                    
                    addChannel(param1[_loc_7]);
                    _loc_7++;
                }
            }
            return;
        }// end function

        public function addChannel(param1:Channel) : void
        {
            var _loc_2:String = null;
            if (param1 == null)
            {
                return;
            }
            if (configured)
            {
                _loc_2 = resourceManager.getString("messaging", "cannotAddWhenConfigured");
                throw new IllegalOperationError(_loc_2);
            }
            if (clustered && param1.id == null)
            {
                _loc_2 = resourceManager.getString("messaging", "cannotAddNullIdChannelWhenClustered");
                throw new IllegalOperationError(_loc_2);
            }
            if (_channels.indexOf(param1) != -1)
            {
                return;
            }
            _channels.push(param1);
            if (_credentials)
            {
                param1.setCredentials(_credentials, null, _credentialsCharset);
            }
            return;
        }// end function

        protected function scheduleHeartbeat() : void
        {
            if (_heartbeatTimer == null && heartbeatInterval > 0)
            {
                _heartbeatTimer = new Timer(heartbeatInterval, 1);
                _heartbeatTimer.addEventListener(TimerEvent.TIMER, sendHeartbeatHandler);
                _heartbeatTimer.start();
            }
            return;
        }// end function

        public function send(param1:MessageAgent, param2:IMessage) : void
        {
            var _loc_3:AcknowledgeMessage = null;
            var _loc_4:CommandMessage = null;
            if (_currentChannel != null && _currentChannel.connected && !param1.needsConfig)
            {
                if (param2 is CommandMessage && CommandMessage(param2).operation == CommandMessage.TRIGGER_CONNECT_OPERATION)
                {
                    _loc_3 = new AcknowledgeMessage();
                    _loc_3.clientId = param1.clientId;
                    _loc_3.correlationId = param2.messageId;
                    new AsyncDispatcher(param1.acknowledge, [_loc_3, param2], 1);
                    return;
                }
                if (!_hasRequestedClusterEndpoints && clustered)
                {
                    _loc_4 = new CommandMessage();
                    if (param1 is AuthenticationAgent)
                    {
                        _loc_4.destination = initialDestinationId;
                    }
                    else
                    {
                        _loc_4.destination = param1.destination;
                    }
                    _loc_4.operation = CommandMessage.CLUSTER_REQUEST_OPERATION;
                    _currentChannel.sendInternalMessage(new ClusterMessageResponder(_loc_4, this));
                    _hasRequestedClusterEndpoints = true;
                }
                unscheduleHeartbeat();
                _currentChannel.send(param1, param2);
                scheduleHeartbeat();
            }
            else
            {
                if (_pendingMessages[param2] == null)
                {
                    _pendingMessages[param2] = true;
                    _pendingSends.push(new PendingSend(param1, param2));
                }
                if (!_connecting)
                {
                    if (_currentChannel == null || _currentChannelIndex == -1)
                    {
                        hunt();
                    }
                    if (_currentChannel is NetConnectionChannel)
                    {
                        if (_reconnectTimer == null)
                        {
                            _reconnectTimer = new Timer(1, 1);
                            _reconnectTimer.addEventListener(TimerEvent.TIMER, reconnectChannel);
                            _reconnectTimer.start();
                        }
                    }
                    else
                    {
                        connectChannel();
                    }
                }
            }
            return;
        }// end function

        public function logout(param1:MessageAgent = null) : AsyncToken
        {
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            var _loc_4:CommandMessage = null;
            var _loc_5:AsyncToken = null;
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            _credentials = null;
            if (param1 == null)
            {
                if (_authAgent != null && (_authAgent.state == AuthenticationAgent.LOGGING_OUT_STATE || _authAgent.state == AuthenticationAgent.LOGGING_IN_STATE))
                {
                    throw new IllegalOperationError("ChannelSet is in the process of logging in or logging out.");
                }
                _loc_2 = _messageAgents.length;
                _loc_3 = 0;
                while (_loc_3 < _loc_2)
                {
                    
                    _messageAgents[_loc_3].internalSetCredentials(null);
                    _loc_3++;
                }
                _loc_2 = _channels.length;
                _loc_3 = 0;
                while (_loc_3 < _loc_2)
                {
                    
                    if (_channels[_loc_3] != null)
                    {
                        _channels[_loc_3].internalSetCredentials(null);
                        if (_channels[_loc_3] is PollingChannel)
                        {
                            PollingChannel(_channels[_loc_3]).disablePolling();
                        }
                    }
                    _loc_3++;
                }
                _loc_4 = new CommandMessage();
                _loc_4.operation = CommandMessage.LOGOUT_OPERATION;
                _loc_4.destination = "auth";
                _loc_5 = new AsyncToken(_loc_4);
                if (_authAgent == null)
                {
                    _authAgent = new AuthenticationAgent(this);
                }
                _authAgent.registerToken(_loc_5);
                _authAgent.state = AuthenticationAgent.LOGGING_OUT_STATE;
                send(_authAgent, _loc_4);
                return _loc_5;
                ;
            }
            _loc_6 = _channels.length;
            _loc_7 = 0;
            while (_loc_7 < _loc_6)
            {
                
                if (_channels[_loc_7] != null)
                {
                    _channels[_loc_7].logout(param1);
                }
                _loc_7++;
            }
            return null;
        }// end function

        public function set clustered(param1:Boolean) : void
        {
            var _loc_2:Array = null;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_5:String = null;
            if (_clustered != param1)
            {
                if (param1)
                {
                    _loc_2 = channelIds;
                    _loc_3 = _loc_2.length;
                    _loc_4 = 0;
                    while (_loc_4 < _loc_3)
                    {
                        
                        if (_loc_2[_loc_4] == null)
                        {
                            _loc_5 = resourceManager.getString("messaging", "cannotSetClusteredWithdNullChannelIds");
                            throw new IllegalOperationError(_loc_5);
                        }
                        _loc_4++;
                    }
                }
                _clustered = param1;
            }
            return;
        }// end function

        public function get channelIds() : Array
        {
            var _loc_1:Array = null;
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            if (_channelIds != null)
            {
                return _channelIds;
            }
            _loc_1 = [];
            _loc_2 = _channels.length;
            _loc_3 = 0;
            while (_loc_3 < _loc_2)
            {
                
                if (_channels[_loc_3] != null)
                {
                    _loc_1.push(_channels[_loc_3].id);
                }
                else
                {
                    _loc_1.push(null);
                }
                _loc_3++;
            }
            return _loc_1;
        }// end function

        public function get authenticated() : Boolean
        {
            return _authenticated;
        }// end function

        private function connectChannel() : void
        {
            _connecting = true;
            _currentChannel.connect(this);
            _currentChannel.addEventListener(MessageEvent.MESSAGE, messageHandler);
            return;
        }// end function

        protected function unscheduleHeartbeat() : void
        {
            if (_heartbeatTimer != null)
            {
                _heartbeatTimer.stop();
                _heartbeatTimer.removeEventListener(TimerEvent.TIMER, sendHeartbeatHandler);
                _heartbeatTimer = null;
            }
            return;
        }// end function

        function get channelFailoverURIs() : Object
        {
            return _channelFailoverURIs;
        }// end function

        function get configured() : Boolean
        {
            return _configured;
        }// end function

        public function setCredentials(param1:String, param2:MessageAgent, param3:String = null) : void
        {
            _credentials = param1;
            var _loc_4:* = _channels.length;
            var _loc_5:int = 0;
            while (_loc_5 < _loc_4)
            {
                
                if (_channels[_loc_5] != null)
                {
                    _channels[_loc_5].setCredentials(_credentials, param2, param3);
                }
                _loc_5++;
            }
            return;
        }// end function

        public function set heartbeatInterval(param1:int) : void
        {
            var _loc_2:PropertyChangeEvent = null;
            if (_heartbeatInterval != param1)
            {
                _loc_2 = PropertyChangeEvent.createUpdateEvent(this, "heartbeatInterval", _heartbeatInterval, param1);
                _heartbeatInterval = param1;
                dispatchEvent(_loc_2);
                if (_heartbeatInterval > 0 && connected)
                {
                    scheduleHeartbeat();
                }
            }
            return;
        }// end function

        protected function messageHandler(event:MessageEvent) : void
        {
            dispatchEvent(event);
            return;
        }// end function

        protected function setConnected(param1:Boolean) : void
        {
            var _loc_2:PropertyChangeEvent = null;
            if (_connected != param1)
            {
                _loc_2 = PropertyChangeEvent.createUpdateEvent(this, "connected", _connected, param1);
                _connected = param1;
                dispatchEvent(_loc_2);
                setAuthenticated(param1 && currentChannel && currentChannel.authenticated, _credentials, false);
                if (!connected)
                {
                    unscheduleHeartbeat();
                }
                else if (heartbeatInterval > 0)
                {
                    scheduleHeartbeat();
                }
            }
            return;
        }// end function

        public function get currentChannel() : Channel
        {
            return _currentChannel;
        }// end function

        private function disconnectChannel() : void
        {
            _connecting = false;
            _currentChannel.removeEventListener(MessageEvent.MESSAGE, messageHandler);
            _currentChannel.disconnect(this);
            return;
        }// end function

        public function get channels() : Array
        {
            return _channels;
        }// end function

        public function set initialDestinationId(param1:String) : void
        {
            _initialDestinationId = param1;
            return;
        }// end function

        protected function faultPendingSends(event:ChannelEvent) : void
        {
            var _loc_2:PendingSend = null;
            var _loc_3:IMessage = null;
            var _loc_4:ErrorMessage = null;
            var _loc_5:ChannelFaultEvent = null;
            while (_pendingSends.length > 0)
            {
                
                _loc_2 = _pendingSends.shift() as PendingSend;
                _loc_3 = _loc_2.message;
                delete _pendingMessages[_loc_3];
                _loc_4 = new ErrorMessage();
                _loc_4.correlationId = _loc_3.messageId;
                _loc_4.headers[ErrorMessage.RETRYABLE_HINT_HEADER] = true;
                _loc_4.faultCode = "Client.Error.MessageSend";
                _loc_4.faultString = resourceManager.getString("messaging", "sendFailed");
                if (event is ChannelFaultEvent)
                {
                    _loc_5 = event as ChannelFaultEvent;
                    _loc_4.faultDetail = _loc_5.faultCode + " " + _loc_5.faultString + " " + _loc_5.faultDetail;
                    if (_loc_5.faultCode == "Channel.Authentication.Error")
                    {
                        _loc_4.faultCode = _loc_5.faultCode;
                    }
                }
                else
                {
                    _loc_4.faultDetail = resourceManager.getString("messaging", "cannotConnectToDestination");
                }
                _loc_4.rootCause = event;
                _loc_2.agent.fault(_loc_4, _loc_3);
            }
            return;
        }// end function

        public function channelDisconnectHandler(event:ChannelEvent) : void
        {
            _connecting = false;
            setConnected(false);
            if (_shouldBeConnected && !event.reconnecting && !event.rejected)
            {
                if (_shouldHunt && hunt())
                {
                    event.reconnecting = true;
                    dispatchEvent(event);
                    if (_currentChannel is NetConnectionChannel)
                    {
                        if (_reconnectTimer == null)
                        {
                            _reconnectTimer = new Timer(1, 1);
                            _reconnectTimer.addEventListener(TimerEvent.TIMER, reconnectChannel);
                            _reconnectTimer.start();
                        }
                    }
                    else
                    {
                        connectChannel();
                    }
                }
                else
                {
                    dispatchEvent(event);
                    faultPendingSends(event);
                }
            }
            else
            {
                dispatchEvent(event);
                if (event.rejected)
                {
                    faultPendingSends(event);
                }
            }
            _shouldHunt = true;
            return;
        }// end function

        public function removeChannel(param1:Channel) : void
        {
            var _loc_3:String = null;
            if (configured)
            {
                _loc_3 = resourceManager.getString("messaging", "cannotRemoveWhenConfigured");
                throw new IllegalOperationError(_loc_3);
            }
            var _loc_2:* = _channels.indexOf(param1);
            if (_loc_2 > -1)
            {
                _channels.splice(_loc_2, 1);
                if (_currentChannel != null && _currentChannel == param1)
                {
                    if (connected)
                    {
                        _shouldHunt = false;
                        disconnectChannel();
                    }
                    _currentChannel = null;
                    _currentChannelIndex = -1;
                }
            }
            return;
        }// end function

        public function get heartbeatInterval() : int
        {
            return _heartbeatInterval;
        }// end function

        public function channelConnectHandler(event:ChannelEvent) : void
        {
            var _loc_3:PendingSend = null;
            var _loc_4:CommandMessage = null;
            var _loc_5:AcknowledgeMessage = null;
            _connecting = false;
            _connected = true;
            _currentChannelIndex = -1;
            while (_pendingSends.length > 0)
            {
                
                _loc_3 = PendingSend(_pendingSends.shift());
                delete _pendingMessages[_loc_3.message];
                _loc_4 = _loc_3.message as CommandMessage;
                if (_loc_4 != null)
                {
                    if (_loc_4.operation == CommandMessage.TRIGGER_CONNECT_OPERATION)
                    {
                        _loc_5 = new AcknowledgeMessage();
                        _loc_5.clientId = _loc_3.agent.clientId;
                        _loc_5.correlationId = _loc_4.messageId;
                        _loc_3.agent.acknowledge(_loc_5, _loc_4);
                        continue;
                    }
                    if (!_loc_3.agent.configRequested && _loc_3.agent.needsConfig && _loc_4.operation == CommandMessage.CLIENT_PING_OPERATION)
                    {
                        _loc_4.headers[CommandMessage.NEEDS_CONFIG_HEADER] = true;
                        _loc_3.agent.configRequested = true;
                    }
                }
                send(_loc_3.agent, _loc_3.message);
            }
            if (_hunting)
            {
                event.reconnecting = true;
                _hunting = false;
            }
            dispatchEvent(event);
            var _loc_2:* = PropertyChangeEvent.createUpdateEvent(this, "connected", false, true);
            dispatchEvent(_loc_2);
            return;
        }// end function

        public function get initialDestinationId() : String
        {
            return _initialDestinationId;
        }// end function

        public function connect(param1:MessageAgent) : void
        {
            if (param1 != null && _messageAgents.indexOf(param1) == -1)
            {
                _shouldBeConnected = true;
                _messageAgents.push(param1);
                param1.internalSetChannelSet(this);
                addEventListener(ChannelEvent.CONNECT, param1.channelConnectHandler);
                addEventListener(ChannelEvent.DISCONNECT, param1.channelDisconnectHandler);
                addEventListener(ChannelFaultEvent.FAULT, param1.channelFaultHandler);
                if (connected && !param1.needsConfig)
                {
                    param1.channelConnectHandler(ChannelEvent.createEvent(ChannelEvent.CONNECT, _currentChannel, false, false, connected));
                }
            }
            return;
        }// end function

        public function channelFaultHandler(event:ChannelFaultEvent) : void
        {
            if (event.channel.connected)
            {
                dispatchEvent(event);
            }
            else
            {
                _connecting = false;
                setConnected(false);
                if (_shouldBeConnected && !event.reconnecting && !event.rejected)
                {
                    if (hunt())
                    {
                        event.reconnecting = true;
                        dispatchEvent(event);
                        if (_currentChannel is NetConnectionChannel)
                        {
                            if (_reconnectTimer == null)
                            {
                                _reconnectTimer = new Timer(1, 1);
                                _reconnectTimer.addEventListener(TimerEvent.TIMER, reconnectChannel);
                                _reconnectTimer.start();
                            }
                        }
                        else
                        {
                            connectChannel();
                        }
                    }
                    else
                    {
                        dispatchEvent(event);
                        faultPendingSends(event);
                    }
                }
                else
                {
                    dispatchEvent(event);
                    if (event.rejected)
                    {
                        faultPendingSends(event);
                    }
                }
            }
            return;
        }// end function

        function setAuthenticated(param1:Boolean, param2:String, param3:Boolean = true) : void
        {
            var _loc_4:PropertyChangeEvent = null;
            var _loc_5:MessageAgent = null;
            var _loc_6:int = 0;
            if (_authenticated != param1)
            {
                _loc_4 = PropertyChangeEvent.createUpdateEvent(this, "authenticated", _authenticated, param1);
                _authenticated = param1;
                if (param3)
                {
                    _loc_6 = 0;
                    while (_loc_6 < _messageAgents.length)
                    {
                        
                        _loc_5 = MessageAgent(_messageAgents[_loc_6]);
                        _loc_5.setAuthenticated(param1, param2);
                        _loc_6++;
                    }
                }
                dispatchEvent(_loc_4);
            }
            return;
        }// end function

        protected function sendHeartbeatHandler(event:TimerEvent) : void
        {
            unscheduleHeartbeat();
            if (currentChannel != null)
            {
                sendHeartbeat();
                scheduleHeartbeat();
            }
            return;
        }// end function

        private function dispatchRPCEvent(event:AbstractEvent) : void
        {
            event.callTokenResponders();
            dispatchEvent(event);
            return;
        }// end function

        function authenticationSuccess(param1:AuthenticationAgent, param2:AsyncToken, param3:AcknowledgeMessage) : void
        {
            var _loc_8:int = 0;
            var _loc_9:int = 0;
            var _loc_4:* = CommandMessage(param2.message);
            var _loc_5:* = CommandMessage(param2.message).operation == CommandMessage.LOGIN_OPERATION;
            var _loc_6:* = CommandMessage(param2.message).operation == CommandMessage.LOGIN_OPERATION ? (String(_loc_4.body)) : (null);
            if (_loc_5)
            {
                _credentials = _loc_6;
                _loc_8 = _messageAgents.length;
                _loc_9 = 0;
                while (_loc_9 < _loc_8)
                {
                    
                    _messageAgents[_loc_9].internalSetCredentials(_loc_6);
                    _loc_9++;
                }
                _loc_8 = _channels.length;
                _loc_9 = 0;
                while (_loc_9 < _loc_8)
                {
                    
                    if (_channels[_loc_9] != null)
                    {
                        _channels[_loc_9].internalSetCredentials(_loc_6);
                    }
                    _loc_9++;
                }
                param1.state = AuthenticationAgent.LOGGED_IN_STATE;
                currentChannel.setAuthenticated(true);
            }
            else
            {
                param1.state = AuthenticationAgent.SHUTDOWN_STATE;
                _authAgent = null;
                disconnect(param1);
                currentChannel.setAuthenticated(false);
            }
            var _loc_7:* = ResultEvent.createEvent(param3.body, param2, param3);
            dispatchRPCEvent(_loc_7);
            return;
        }// end function

        public function disconnectAll() : void
        {
            disconnect(null);
            return;
        }// end function

        public function get messageAgents() : Array
        {
            return _messageAgents;
        }// end function

        function set channelFailoverURIs(param1:Object) : void
        {
            var _loc_4:Channel = null;
            _channelFailoverURIs = param1;
            var _loc_2:* = _channels.length;
            var _loc_3:int = 0;
            while (_loc_3 < _loc_2)
            {
                
                _loc_4 = _channels[_loc_3];
                if (_loc_4 == null)
                {
                    break;
                }
                else if (_channelFailoverURIs[_loc_4.id] != null)
                {
                    _loc_4.failoverURIs = _channelFailoverURIs[_loc_4.id];
                }
                _loc_3++;
            }
            return;
        }// end function

        function authenticationFailure(param1:AuthenticationAgent, param2:AsyncToken, param3:ErrorMessage) : void
        {
            var _loc_4:* = MessageFaultEvent.createEvent(param3);
            var _loc_5:* = FaultEvent.createEventFromMessageFault(_loc_4, param2);
            param1.state = AuthenticationAgent.SHUTDOWN_STATE;
            _authAgent = null;
            disconnect(param1);
            dispatchRPCEvent(_loc_5);
            return;
        }// end function

        override public function toString() : String
        {
            var _loc_1:String = "[ChannelSet ";
            var _loc_2:uint = 0;
            while (_loc_2 < _channels.length)
            {
                
                if (_channels[_loc_2] != null)
                {
                    _loc_1 = _loc_1 + (_channels[_loc_2].id + " ");
                }
                _loc_2 = _loc_2 + 1;
            }
            _loc_1 = _loc_1 + "]";
            return _loc_1;
        }// end function

    }
}

class PendingSend extends Object
{
    public var agent:MessageAgent;
    public var message:IMessage;

    function PendingSend(param1:MessageAgent, param2:IMessage)
    {
        this.agent = param1;
        this.message = param2;
        return;
    }// end function

}

