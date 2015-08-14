package mx.messaging
{
    import flash.events.*;
    import mx.core.*;
    import mx.events.*;
    import mx.logging.*;
    import mx.messaging.config.*;
    import mx.messaging.errors.*;
    import mx.messaging.events.*;
    import mx.messaging.messages.*;
    import mx.netmon.*;
    import mx.resources.*;
    import mx.utils.*;

    public class MessageAgent extends EventDispatcher implements IMXMLObject
    {
        private var _needsConfig:Boolean;
        protected var _disconnectBarrier:Boolean;
        protected var _log:ILogger;
        private var _connected:Boolean = false;
        private var _clientId:String;
        private var _sendRemoteCredentials:Boolean;
        private var _authenticated:Boolean;
        protected var _ignoreFault:Boolean = false;
        private var _id:String;
        protected var _credentials:String;
        private var resourceManager:IResourceManager;
        private var _channelSetMode:int = 0;
        var configRequested:Boolean = false;
        private var _pendingConnectEvent:ChannelEvent;
        protected var _credentialsCharset:String;
        private var _remoteCredentials:String = "";
        private var _destination:String = "";
        protected var _agentType:String = "mx.messaging.MessageAgent";
        private var _requestTimeout:int = -1;
        private var _remoteCredentialsCharset:String;
        private var _clientIdWaitQueue:Array;
        private var _channelSet:ChannelSet;
        static const AUTO_CONFIGURED_CHANNELSET:int = 0;
        static const MANUALLY_ASSIGNED_CHANNELSET:int = 1;

        public function MessageAgent()
        {
            resourceManager = ResourceManager.getInstance();
            _id = UIDUtil.createUID();
            return;
        }// end function

        public function get connected() : Boolean
        {
            return _connected;
        }// end function

        public function get destination() : String
        {
            return _destination;
        }// end function

        protected function initChannelSet(param1:IMessage) : void
        {
            if (_channelSet == null)
            {
                _channelSetMode = AUTO_CONFIGURED_CHANNELSET;
                internalSetChannelSet(ServerConfig.getChannelSet(destination));
            }
            if (_channelSet.connected && needsConfig && !configRequested)
            {
                param1.headers[CommandMessage.NEEDS_CONFIG_HEADER] = true;
                configRequested = true;
            }
            _channelSet.connect(this);
            if (_credentials != null)
            {
                channelSet.setCredentials(_credentials, this, _credentialsCharset);
            }
            return;
        }// end function

        function set needsConfig(param1:Boolean) : void
        {
            var cs:ChannelSet;
            var value:* = param1;
            if (_needsConfig == value)
            {
                return;
            }
            _needsConfig = value;
            if (_needsConfig)
            {
                cs = channelSet;
                disconnect();
                finally
                {
                    var _loc_3:* = new catch0;
                    throw null;
                }
                finally
                {
                    internalSetChannelSet(cs);
                }
            }
            return;
        }// end function

        public function logout() : void
        {
            _credentials = null;
            if (channelSet)
            {
                channelSet.logout(this);
            }
            return;
        }// end function

        public function get id() : String
        {
            return _id;
        }// end function

        public function set destination(param1:String) : void
        {
            var _loc_2:PropertyChangeEvent = null;
            if (param1 == null || param1.length == 0)
            {
                return;
            }
            if (_destination != param1)
            {
                if (_channelSetMode == AUTO_CONFIGURED_CHANNELSET && channelSet != null)
                {
                    channelSet.disconnect(this);
                    channelSet = null;
                }
                _loc_2 = PropertyChangeEvent.createUpdateEvent(this, "destination", _destination, param1);
                _destination = param1;
                dispatchEvent(_loc_2);
                if (Log.isInfo())
                {
                    _log.info("\'{0}\' {2} set destination to \'{1}\'.", id, _destination, _agentType);
                }
            }
            return;
        }// end function

        function get channelSetMode() : int
        {
            return _channelSetMode;
        }// end function

        public function acknowledge(param1:AcknowledgeMessage, param2:IMessage) : void
        {
            var mpiutil:MessagePerformanceUtils;
            var ackMsg:* = param1;
            var msg:* = param2;
            if (Log.isInfo())
            {
                _log.info("\'{0}\' {2} acknowledge of \'{1}\'.", id, msg.messageId, _agentType);
            }
            if (Log.isDebug() && channelSet != null && channelSet.currentChannel != null && channelSet.currentChannel.mpiEnabled)
            {
                try
                {
                    mpiutil = new MessagePerformanceUtils(ackMsg);
                    _log.debug(mpiutil.prettyPrint());
                }
                catch (e:Error)
                {
                    _log.debug("Could not get message performance information for: " + msg.toString());
                }
            }
            if (configRequested)
            {
                configRequested = false;
                ServerConfig.updateServerConfigData(ackMsg.body as ConfigMap);
                needsConfig = false;
                if (_pendingConnectEvent)
                {
                    channelConnectHandler(_pendingConnectEvent);
                }
                _pendingConnectEvent = null;
            }
            if (clientId == null)
            {
                if (ackMsg.clientId != null)
                {
                    setClientId(ackMsg.clientId);
                }
                else
                {
                    flushClientIdWaitQueue();
                }
            }
            dispatchEvent(MessageAckEvent.createEvent(ackMsg, msg));
            monitorRpcMessage(ackMsg, msg);
            return;
        }// end function

        function internalSetChannelSet(param1:ChannelSet) : void
        {
            var _loc_2:PropertyChangeEvent = null;
            if (_channelSet != param1)
            {
                if (_channelSet != null)
                {
                    _channelSet.disconnect(this);
                }
                _loc_2 = PropertyChangeEvent.createUpdateEvent(this, "channelSet", _channelSet, param1);
                _channelSet = param1;
                if (_channelSet != null)
                {
                    if (_credentials)
                    {
                        _channelSet.setCredentials(_credentials, this, _credentialsCharset);
                    }
                    _channelSet.connect(this);
                }
                dispatchEvent(_loc_2);
            }
            return;
        }// end function

        public function fault(param1:ErrorMessage, param2:IMessage) : void
        {
            if (Log.isError())
            {
                _log.error("\'{0}\' {2} fault for \'{1}\'.", id, param2.messageId, _agentType);
            }
            _ignoreFault = false;
            configRequested = false;
            if (param1.headers[ErrorMessage.RETRYABLE_HINT_HEADER])
            {
                delete param1.headers[ErrorMessage.RETRYABLE_HINT_HEADER];
            }
            if (clientId == null)
            {
                if (param1.clientId != null)
                {
                    setClientId(param1.clientId);
                }
                else
                {
                    flushClientIdWaitQueue();
                }
            }
            dispatchEvent(MessageFaultEvent.createEvent(param1));
            monitorRpcMessage(param1, param2);
            if (param1.faultCode == "Client.Authentication" && authenticated && channelSet != null && channelSet.currentChannel != null)
            {
                channelSet.currentChannel.setAuthenticated(false);
                if (channelSet.currentChannel.loginAfterDisconnect)
                {
                    reAuthorize(param2);
                    _ignoreFault = true;
                }
            }
            return;
        }// end function

        public function set requestTimeout(param1:int) : void
        {
            var _loc_2:PropertyChangeEvent = null;
            if (_requestTimeout != param1)
            {
                _loc_2 = PropertyChangeEvent.createUpdateEvent(this, "requestTimeout", _requestTimeout, param1);
                _requestTimeout = param1;
                dispatchEvent(_loc_2);
            }
            return;
        }// end function

        public function disconnect() : void
        {
            if (!_disconnectBarrier)
            {
                _clientIdWaitQueue = null;
                if (connected)
                {
                    _disconnectBarrier = true;
                }
                if (_channelSetMode == AUTO_CONFIGURED_CHANNELSET)
                {
                    internalSetChannelSet(null);
                }
                else if (_channelSet != null)
                {
                    _channelSet.disconnect(this);
                }
            }
            return;
        }// end function

        public function set id(param1:String) : void
        {
            var _loc_2:PropertyChangeEvent = null;
            if (_id != param1)
            {
                _loc_2 = PropertyChangeEvent.createUpdateEvent(this, "id", _id, param1);
                _id = param1;
                dispatchEvent(_loc_2);
            }
            return;
        }// end function

        public function set channelSet(param1:ChannelSet) : void
        {
            internalSetChannelSet(param1);
            _channelSetMode = MANUALLY_ASSIGNED_CHANNELSET;
            return;
        }// end function

        public function get clientId() : String
        {
            return _clientId;
        }// end function

        protected function setConnected(param1:Boolean) : void
        {
            var _loc_2:PropertyChangeEvent = null;
            if (_connected != param1)
            {
                _loc_2 = PropertyChangeEvent.createUpdateEvent(this, "connected", _connected, param1);
                _connected = param1;
                dispatchEvent(_loc_2);
                setAuthenticated(param1 && channelSet && channelSet.authenticated, _credentials);
            }
            return;
        }// end function

        function setClientId(param1:String) : void
        {
            var _loc_2:PropertyChangeEvent = null;
            if (_clientId != param1)
            {
                _loc_2 = PropertyChangeEvent.createUpdateEvent(this, "clientId", _clientId, param1);
                _clientId = param1;
                flushClientIdWaitQueue();
                dispatchEvent(_loc_2);
            }
            return;
        }// end function

        public function setCredentials(param1:String, param2:String, param3:String = null) : void
        {
            var _loc_4:String = null;
            var _loc_5:Base64Encoder = null;
            if (param1 == null && param2 == null)
            {
                _credentials = null;
                _credentialsCharset = null;
            }
            else
            {
                _loc_4 = param1 + ":" + param2;
                _loc_5 = new Base64Encoder();
                if (param3 == Base64Encoder.CHARSET_UTF_8)
                {
                    _loc_5.encodeUTFBytes(_loc_4);
                }
                else
                {
                    _loc_5.encode(_loc_4);
                }
                _credentials = _loc_5.drain();
                _credentialsCharset = param3;
            }
            if (channelSet != null)
            {
                channelSet.setCredentials(_credentials, this, _credentialsCharset);
            }
            return;
        }// end function

        public function channelDisconnectHandler(event:ChannelEvent) : void
        {
            if (Log.isWarn())
            {
                _log.warn("\'{0}\' {1} channel disconnected.", id, _agentType);
            }
            setConnected(false);
            if (_remoteCredentials != null)
            {
                _sendRemoteCredentials = true;
            }
            dispatchEvent(event);
            return;
        }// end function

        public function setRemoteCredentials(param1:String, param2:String, param3:String = null) : void
        {
            var _loc_4:String = null;
            var _loc_5:Base64Encoder = null;
            if (param1 == null && param2 == null)
            {
                _remoteCredentials = "";
                _remoteCredentialsCharset = null;
            }
            else
            {
                _loc_4 = param1 + ":" + param2;
                _loc_5 = new Base64Encoder();
                if (param3 == Base64Encoder.CHARSET_UTF_8)
                {
                    _loc_5.encodeUTFBytes(_loc_4);
                }
                else
                {
                    _loc_5.encode(_loc_4);
                }
                _remoteCredentials = _loc_5.drain();
                _remoteCredentialsCharset = param3;
            }
            _sendRemoteCredentials = true;
            return;
        }// end function

        function get needsConfig() : Boolean
        {
            return _needsConfig;
        }// end function

        public function hasPendingRequestForMessage(param1:IMessage) : Boolean
        {
            return false;
        }// end function

        public function get authenticated() : Boolean
        {
            return _authenticated;
        }// end function

        public function get requestTimeout() : int
        {
            return _requestTimeout;
        }// end function

        public function initialized(param1:Object, param2:String) : void
        {
            this.id = param2;
            return;
        }// end function

        function getNetmonId() : String
        {
            return null;
        }// end function

        final protected function flushClientIdWaitQueue() : void
        {
            var _loc_1:Array = null;
            if (_clientIdWaitQueue != null)
            {
                if (clientId != null)
                {
                    while (_clientIdWaitQueue.length > 0)
                    {
                        
                        internalSend(_clientIdWaitQueue.shift() as IMessage);
                    }
                }
                if (clientId == null)
                {
                    if (_clientIdWaitQueue.length > 0)
                    {
                        _loc_1 = _clientIdWaitQueue;
                        _clientIdWaitQueue = null;
                        internalSend(_loc_1.shift() as IMessage);
                        _clientIdWaitQueue = _loc_1;
                    }
                    else
                    {
                        _clientIdWaitQueue = null;
                    }
                }
            }
            return;
        }// end function

        private function monitorRpcMessage(param1:IMessage, param2:IMessage) : void
        {
            if (NetworkMonitor.isMonitoring())
            {
                if (param1 is ErrorMessage)
                {
                    NetworkMonitor.monitorFault(param2, MessageFaultEvent.createEvent(ErrorMessage(param1)));
                }
                else if (param1 is AcknowledgeMessage)
                {
                    NetworkMonitor.monitorResult(param1, MessageEvent.createEvent(MessageEvent.RESULT, param2));
                }
                else
                {
                    NetworkMonitor.monitorInvocation(getNetmonId(), param1, this);
                }
            }
            return;
        }// end function

        final protected function assertCredentials(param1:String) : void
        {
            var _loc_2:ErrorMessage = null;
            if (_credentials != null && _credentials != param1)
            {
                _loc_2 = new ErrorMessage();
                _loc_2.faultCode = "Client.Authentication.Error";
                _loc_2.faultString = "Credentials specified do not match those used on underlying connection.";
                _loc_2.faultDetail = "Channel was authenticated with a different set of credentials than those used for this agent.";
                dispatchEvent(MessageFaultEvent.createEvent(_loc_2));
            }
            return;
        }// end function

        public function get channelSet() : ChannelSet
        {
            return _channelSet;
        }// end function

        public function channelConnectHandler(event:ChannelEvent) : void
        {
            _disconnectBarrier = false;
            if (needsConfig)
            {
                if (Log.isInfo())
                {
                    _log.info("\'{0}\' {1} waiting for configuration information.", id, _agentType);
                }
                _pendingConnectEvent = event;
            }
            else
            {
                if (Log.isInfo())
                {
                    _log.info("\'{0}\' {1} connected.", id, _agentType);
                }
                setConnected(true);
                dispatchEvent(event);
            }
            return;
        }// end function

        function internalSetCredentials(param1:String) : void
        {
            _credentials = param1;
            return;
        }// end function

        public function channelFaultHandler(event:ChannelFaultEvent) : void
        {
            if (Log.isWarn())
            {
                _log.warn("\'{0}\' {1} channel faulted with {2} {3}", id, _agentType, event.faultCode, event.faultDetail);
            }
            if (!event.channel.connected)
            {
                setConnected(false);
                if (_remoteCredentials != null)
                {
                    _sendRemoteCredentials = true;
                }
            }
            dispatchEvent(event);
            return;
        }// end function

        protected function internalSend(param1:IMessage, param2:Boolean = true) : void
        {
            var _loc_3:String = null;
            if (param1.clientId == null && param2 && clientId == null)
            {
                if (_clientIdWaitQueue == null)
                {
                    _clientIdWaitQueue = [];
                }
                else
                {
                    _clientIdWaitQueue.push(param1);
                    return;
                }
            }
            if (param1.clientId == null)
            {
                param1.clientId = clientId;
            }
            if (requestTimeout > 0)
            {
                param1.headers[AbstractMessage.REQUEST_TIMEOUT_HEADER] = requestTimeout;
            }
            if (_sendRemoteCredentials)
            {
                if (!(param1 is CommandMessage && CommandMessage(param1).operation == CommandMessage.TRIGGER_CONNECT_OPERATION))
                {
                    param1.headers[AbstractMessage.REMOTE_CREDENTIALS_HEADER] = _remoteCredentials;
                    param1.headers[AbstractMessage.REMOTE_CREDENTIALS_CHARSET_HEADER] = _remoteCredentialsCharset;
                    _sendRemoteCredentials = false;
                }
            }
            if (channelSet != null)
            {
                if (!connected && _channelSetMode == MANUALLY_ASSIGNED_CHANNELSET)
                {
                    _channelSet.connect(this);
                }
                if (channelSet.connected && needsConfig && !configRequested)
                {
                    param1.headers[CommandMessage.NEEDS_CONFIG_HEADER] = true;
                    configRequested = true;
                }
                channelSet.send(this, param1);
                monitorRpcMessage(param1, param1);
            }
            else if (destination != null && destination.length > 0)
            {
                initChannelSet(param1);
                if (channelSet != null)
                {
                    channelSet.send(this, param1);
                    monitorRpcMessage(param1, param1);
                }
            }
            else
            {
                _loc_3 = resourceManager.getString("messaging", "destinationNotSet");
                throw new InvalidDestinationError(_loc_3);
            }
            return;
        }// end function

        function setAuthenticated(param1:Boolean, param2:String) : void
        {
            var _loc_3:PropertyChangeEvent = null;
            if (_authenticated != param1)
            {
                _loc_3 = PropertyChangeEvent.createUpdateEvent(this, "authenticated", _authenticated, param1);
                _authenticated = param1;
                dispatchEvent(_loc_3);
                if (param1)
                {
                    assertCredentials(param2);
                }
            }
            return;
        }// end function

        protected function reAuthorize(param1:IMessage) : void
        {
            disconnect();
            internalSend(param1);
            return;
        }// end function

    }
}
