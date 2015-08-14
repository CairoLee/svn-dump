package mx.messaging
{
    import flash.errors.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.collections.*;
    import mx.core.*;
    import mx.events.*;
    import mx.logging.*;
    import mx.messaging.config.*;
    import mx.messaging.errors.*;
    import mx.messaging.events.*;
    import mx.messaging.messages.*;
    import mx.resources.*;
    import mx.rpc.*;
    import mx.utils.*;

    public class Channel extends EventDispatcher implements IMXMLObject
    {
        private var _failoverIndex:int;
        private var _ownsWaitGuard:Boolean;
        protected var _recordMessageTimes:Boolean = false;
        private var _reconnecting:Boolean = false;
        private var _reliableReconnectLastTimestamp:Number;
        private var _reliableReconnectAttempts:int;
        private var _authenticated:Boolean = false;
        protected var messagingVersion:Number = 1;
        private var _channelSets:Array;
        private var _connectTimeout:int = -1;
        var authenticating:Boolean;
        protected var _connecting:Boolean;
        private var _connectTimer:Timer;
        protected var _recordMessageSizes:Boolean = false;
        private var _failoverURIs:Array;
        protected var _log:ILogger;
        private var _connected:Boolean = false;
        private var _smallMessagesSupported:Boolean;
        private var _primaryURI:String;
        public var enableSmallMessages:Boolean = true;
        private var _id:String;
        private var _reliableReconnectBeginTimestamp:Number;
        private var resourceManager:IResourceManager;
        private var _uri:String;
        protected var _loginAfterDisconnect:Boolean = false;
        private var _isEndpointCalculated:Boolean;
        var reliableReconnectDuration:int = -1;
        private var _shouldBeConnected:Boolean;
        private var _previouslyConnected:Boolean;
        private var _requestTimeout:int = -1;
        private var _endpoint:String;
        protected var credentials:String;
        private static const ENABLE_SMALL_MESSAGES:String = "enable-small-messages";
        private static const FALSE:String = "false";
        private static const RECORD_MESSAGE_SIZES:String = "record-message-sizes";
        private static const TRUE:String = "true";
        private static const REQUEST_TIMEOUT_SECONDS:String = "request-timeout-seconds";
        private static const CONNECT_TIMEOUT_SECONDS:String = "connect-timeout-seconds";
        private static const CLIENT_LOAD_BALANCING:String = "client-load-balancing";
        private static const SERIALIZATION:String = "serialization";
        private static const RECORD_MESSAGE_TIMES:String = "record-message-times";
        public static const SMALL_MESSAGES_FEATURE:String = "small_messages";
        private static const dep:ArrayCollection = null;

        public function Channel(param1:String = null, param2:String = null)
        {
            resourceManager = ResourceManager.getInstance();
            _channelSets = [];
            _log = Log.getLogger("mx.messaging.Channel");
            _failoverIndex = -1;
            this.id = param1;
            _primaryURI = param2;
            this.uri = param2;
            return;
        }// end function

        private function shuffle(param1:Array) : void
        {
            var _loc_4:int = 0;
            var _loc_5:Object = null;
            var _loc_2:* = param1.length;
            var _loc_3:int = 0;
            while (_loc_3 < _loc_2)
            {
                
                _loc_4 = Math.floor(Math.random() * _loc_2);
                if (_loc_4 != _loc_3)
                {
                    _loc_5 = param1[_loc_3];
                    param1[_loc_3] = param1[_loc_4];
                    param1[_loc_4] = _loc_5;
                }
                _loc_3++;
            }
            return;
        }// end function

        public function get connected() : Boolean
        {
            return _connected;
        }// end function

        private function shutdownConnectTimer() : void
        {
            if (_connectTimer != null)
            {
                _connectTimer.stop();
                _connectTimer.removeEventListener(TimerEvent.TIMER, connectTimeoutHandler);
                _connectTimer = null;
            }
            return;
        }// end function

        public function get connectTimeout() : int
        {
            return _connectTimeout;
        }// end function

        public function get id() : String
        {
            return _id;
        }// end function

        private function calculateEndpoint() : void
        {
            var _loc_3:String = null;
            if (uri == null)
            {
                _loc_3 = resourceManager.getString("messaging", "noURLSpecified");
                throw new InvalidChannelError(_loc_3);
            }
            var _loc_1:* = uri;
            var _loc_2:* = URLUtil.getProtocol(_loc_1);
            if (_loc_2.length == 0)
            {
                _loc_1 = URLUtil.getFullURL(LoaderConfig.url, _loc_1);
            }
            if (!URLUtil.hasUnresolvableTokens())
            {
                _isEndpointCalculated = false;
                return;
            }
            _loc_1 = URLUtil.replaceTokens(_loc_1);
            _loc_2 = URLUtil.getProtocol(_loc_1);
            if (_loc_2.length > 0)
            {
                _endpoint = URLUtil.replaceProtocol(_loc_1, protocol);
            }
            else
            {
                _endpoint = protocol + ":" + _loc_1;
            }
            _isEndpointCalculated = true;
            if (Log.isInfo())
            {
                _log.info("\'{0}\' channel endpoint set to {1}", id, _endpoint);
            }
            return;
        }// end function

        public function get reconnecting() : Boolean
        {
            return _reconnecting;
        }// end function

        public function get useSmallMessages() : Boolean
        {
            return _smallMessagesSupported && enableSmallMessages;
        }// end function

        public function set connectTimeout(param1:int) : void
        {
            _connectTimeout = param1;
            return;
        }// end function

        public function get authenticated() : Boolean
        {
            return _authenticated;
        }// end function

        protected function getMessageResponder(param1:MessageAgent, param2:IMessage) : MessageResponder
        {
            throw new IllegalOperationError("Channel subclasses must override " + " getMessageResponder().");
        }// end function

        public function set failoverURIs(param1:Array) : void
        {
            if (param1 != null)
            {
                _failoverURIs = param1;
                _failoverIndex = -1;
            }
            return;
        }// end function

        protected function internalDisconnect(param1:Boolean = false) : void
        {
            return;
        }// end function

        public function setCredentials(param1:String, param2:MessageAgent = null, param3:String = null) : void
        {
            var _loc_5:CommandMessage = null;
            var _loc_4:* = this.credentials !== param1;
            if (authenticating && _loc_4)
            {
                throw new IllegalOperationError("Credentials cannot be set while authenticating or logging out.");
            }
            if (authenticated && _loc_4)
            {
                throw new IllegalOperationError("Credentials cannot be set when already authenticated. Logout must be performed before changing credentials.");
            }
            this.credentials = param1;
            if (connected && _loc_4 && param1 != null)
            {
                authenticating = true;
                _loc_5 = new CommandMessage();
                _loc_5.operation = CommandMessage.LOGIN_OPERATION;
                _loc_5.body = param1;
                if (param3 != null)
                {
                    _loc_5.headers[CommandMessage.CREDENTIALS_CHARSET_HEADER] = param3;
                }
                internalSend(new AuthenticationMessageResponder(param2, _loc_5, this, _log));
            }
            return;
        }// end function

        public function set id(param1:String) : void
        {
            if (_id != param1)
            {
                _id = param1;
            }
            return;
        }// end function

        public function get mpiEnabled() : Boolean
        {
            return _recordMessageSizes || _recordMessageTimes;
        }// end function

        protected function applyClientLoadBalancingSettings(param1:XML) : void
        {
            var _loc_5:XML = null;
            var _loc_2:* = param1[CLIENT_LOAD_BALANCING];
            if (_loc_2.length() == 0)
            {
                return;
            }
            var _loc_3:* = _loc_2.url.length();
            if (_loc_3 == 0)
            {
                return;
            }
            var _loc_4:* = new Array();
            for each (_loc_5 in _loc_2.url)
            {
                
                _loc_4.push(_loc_5.toString());
            }
            shuffle(_loc_4);
            if (Log.isInfo())
            {
                _log.info("\'{0}\' channel picked {1} as its main url.", id, _loc_4[0]);
            }
            this.url = _loc_4[0];
            var _loc_6:* = _loc_4.slice(1);
            if (_loc_4.slice(1).length > 0)
            {
                this.failoverURIs = _loc_6;
            }
            return;
        }// end function

        protected function setFlexClientIdOnMessage(param1:IMessage) : void
        {
            var _loc_2:* = FlexClient.getInstance().id;
            param1.headers[AbstractMessage.FLEX_CLIENT_ID_HEADER] = _loc_2 != null ? (_loc_2) : (FlexClient.NULL_FLEXCLIENT_ID);
            return;
        }// end function

        protected function connectTimeoutHandler(event:TimerEvent) : void
        {
            var _loc_2:String = null;
            var _loc_3:ChannelFaultEvent = null;
            shutdownConnectTimer();
            if (!connected)
            {
                _shouldBeConnected = false;
                _loc_2 = resourceManager.getString("messaging", "connectTimedOut");
                _loc_3 = ChannelFaultEvent.createEvent(this, false, "Channel.Connect.Failed", "error", _loc_2);
                connectFailed(_loc_3);
            }
            return;
        }// end function

        protected function flexClientWaitHandler(event:PropertyChangeEvent) : void
        {
            var _loc_2:FlexClient = null;
            if (event.property == "waitForFlexClientId")
            {
                _loc_2 = event.source as FlexClient;
                if (_loc_2.waitForFlexClientId == false)
                {
                    _loc_2.removeEventListener(PropertyChangeEvent.PROPERTY_CHANGE, flexClientWaitHandler);
                    _loc_2.waitForFlexClientId = true;
                    _ownsWaitGuard = true;
                    internalConnect();
                }
            }
            return;
        }// end function

        protected function get shouldBeConnected() : Boolean
        {
            return _shouldBeConnected;
        }// end function

        public function set useSmallMessages(param1:Boolean) : void
        {
            _smallMessagesSupported = param1;
            return;
        }// end function

        function internalSetCredentials(param1:String) : void
        {
            this.credentials = param1;
            return;
        }// end function

        private function reconnect(event:TimerEvent = null) : void
        {
            internalConnect();
            return;
        }// end function

        private function connectCleanup() : void
        {
            if (_ownsWaitGuard)
            {
                _ownsWaitGuard = false;
                FlexClient.getInstance().waitForFlexClientId = false;
            }
            _connecting = false;
            setReconnecting(false);
            reliableReconnectCleanup();
            return;
        }// end function

        function get realtime() : Boolean
        {
            return false;
        }// end function

        protected function internalConnect() : void
        {
            return;
        }// end function

        public function get url() : String
        {
            return uri;
        }// end function

        public function get recordMessageTimes() : Boolean
        {
            return _recordMessageTimes;
        }// end function

        public function get uri() : String
        {
            return _uri;
        }// end function

        private function initializeRequestTimeout(param1:MessageResponder) : void
        {
            var _loc_2:* = param1.message;
            if (_loc_2.headers[AbstractMessage.REQUEST_TIMEOUT_HEADER] != null)
            {
                param1.startRequestTimeout(_loc_2.headers[AbstractMessage.REQUEST_TIMEOUT_HEADER]);
            }
            else if (requestTimeout > 0)
            {
                param1.startRequestTimeout(requestTimeout);
            }
            return;
        }// end function

        public function send(param1:MessageAgent, param2:IMessage) : void
        {
            var _loc_4:String = null;
            if (param2.destination.length == 0)
            {
                if (param1.destination.length == 0)
                {
                    _loc_4 = resourceManager.getString("messaging", "noDestinationSpecified");
                    throw new InvalidDestinationError(_loc_4);
                }
                param2.destination = param1.destination;
            }
            if (Log.isDebug())
            {
                _log.debug("\'{0}\' channel sending message:\n{1}", id, param2.toString());
            }
            param2.headers[AbstractMessage.ENDPOINT_HEADER] = id;
            var _loc_3:* = getMessageResponder(param1, param2);
            initializeRequestTimeout(_loc_3);
            internalSend(_loc_3);
            return;
        }// end function

        public function logout(param1:MessageAgent) : void
        {
            var _loc_2:CommandMessage = null;
            if (connected && authenticated && credentials || authenticating && credentials)
            {
                _loc_2 = new CommandMessage();
                _loc_2.operation = CommandMessage.LOGOUT_OPERATION;
                internalSend(new AuthenticationMessageResponder(param1, _loc_2, this, _log));
                authenticating = true;
            }
            credentials = null;
            return;
        }// end function

        public function get endpoint() : String
        {
            if (!_isEndpointCalculated)
            {
                calculateEndpoint();
            }
            return _endpoint;
        }// end function

        public function get protocol() : String
        {
            throw new IllegalOperationError("Channel subclasses must override " + "the get function for \'protocol\' to return the proper protocol " + "string.");
        }// end function

        public function get failoverURIs() : Array
        {
            return _failoverURIs != null ? (_failoverURIs) : ([]);
        }// end function

        final public function disconnect(param1:ChannelSet) : void
        {
            if (_ownsWaitGuard)
            {
                _ownsWaitGuard = false;
                FlexClient.getInstance().waitForFlexClientId = false;
            }
            var _loc_2:* = param1 != null ? (_channelSets.indexOf(param1)) : (-1);
            if (_loc_2 != -1)
            {
                _channelSets.splice(_loc_2, 1);
                removeEventListener(ChannelEvent.CONNECT, param1.channelConnectHandler, false);
                removeEventListener(ChannelEvent.DISCONNECT, param1.channelDisconnectHandler, false);
                removeEventListener(ChannelFaultEvent.FAULT, param1.channelFaultHandler, false);
                if (connected)
                {
                    param1.channelDisconnectHandler(ChannelEvent.createEvent(ChannelEvent.DISCONNECT, this, false));
                }
                if (_channelSets.length == 0)
                {
                    _shouldBeConnected = false;
                    if (connected)
                    {
                        internalDisconnect();
                    }
                }
            }
            return;
        }// end function

        public function set requestTimeout(param1:int) : void
        {
            _requestTimeout = param1;
            return;
        }// end function

        private function shouldAttemptFailover() : Boolean
        {
            return _shouldBeConnected && (_previouslyConnected || reliableReconnectDuration != -1 || _failoverURIs != null && _failoverURIs.length > 0);
        }// end function

        private function setReconnecting(param1:Boolean) : void
        {
            var _loc_2:PropertyChangeEvent = null;
            if (_reconnecting != param1)
            {
                _loc_2 = PropertyChangeEvent.createUpdateEvent(this, "reconnecting", _reconnecting, param1);
                _reconnecting = param1;
                dispatchEvent(_loc_2);
            }
            return;
        }// end function

        public function applySettings(param1:XML) : void
        {
            var _loc_2:XML = null;
            var _loc_3:XMLList = null;
            if (Log.isInfo())
            {
                _log.info("\'{0}\' channel settings are:\n{1}", id, param1);
            }
            if (param1.properties.length() != 0)
            {
                _loc_2 = param1.properties[0];
                applyClientLoadBalancingSettings(_loc_2);
                if (_loc_2[CONNECT_TIMEOUT_SECONDS].length() != 0)
                {
                    connectTimeout = _loc_2[CONNECT_TIMEOUT_SECONDS].toString();
                }
                if (_loc_2[RECORD_MESSAGE_TIMES].length() != 0)
                {
                    _recordMessageTimes = _loc_2[RECORD_MESSAGE_TIMES].toString() == TRUE;
                }
                if (_loc_2[RECORD_MESSAGE_SIZES].length() != 0)
                {
                    _recordMessageSizes = _loc_2[RECORD_MESSAGE_SIZES].toString() == TRUE;
                }
                if (_loc_2[REQUEST_TIMEOUT_SECONDS].length() != 0)
                {
                    requestTimeout = _loc_2[REQUEST_TIMEOUT_SECONDS].toString();
                }
                _loc_3 = _loc_2[SERIALIZATION];
                if (_loc_3.length() != 0 && _loc_3[ENABLE_SMALL_MESSAGES].toString() == FALSE)
                {
                    enableSmallMessages = false;
                }
            }
            return;
        }// end function

        private function reliableReconnectCleanup() : void
        {
            reliableReconnectDuration = -1;
            _reliableReconnectBeginTimestamp = 0;
            _reliableReconnectLastTimestamp = 0;
            _reliableReconnectAttempts = 0;
            return;
        }// end function

        protected function connectSuccess() : void
        {
            var _loc_1:int = 0;
            var _loc_2:Array = null;
            var _loc_3:int = 0;
            shutdownConnectTimer();
            if (ServerConfig.fetchedConfig(endpoint))
            {
                _loc_1 = 0;
                while (_loc_1 < channelSets.length)
                {
                    
                    _loc_2 = ChannelSet(channelSets[_loc_1]).messageAgents;
                    _loc_3 = 0;
                    while (_loc_3 < _loc_2.length)
                    {
                        
                        _loc_2[_loc_3].needsConfig = false;
                        _loc_3++;
                    }
                    _loc_1++;
                }
            }
            setConnected(true);
            _failoverIndex = -1;
            if (Log.isInfo())
            {
                _log.info("\'{0}\' channel is connected.", id);
            }
            dispatchEvent(ChannelEvent.createEvent(ChannelEvent.CONNECT, this, reconnecting));
            connectCleanup();
            return;
        }// end function

        public function get recordMessageSizes() : Boolean
        {
            return _recordMessageSizes;
        }// end function

        protected function setConnected(param1:Boolean) : void
        {
            var _loc_2:PropertyChangeEvent = null;
            if (_connected != param1)
            {
                if (_connected)
                {
                    _previouslyConnected = true;
                }
                _loc_2 = PropertyChangeEvent.createUpdateEvent(this, "connected", _connected, param1);
                _connected = param1;
                dispatchEvent(_loc_2);
                if (!param1)
                {
                    setAuthenticated(false);
                }
            }
            return;
        }// end function

        public function get requestTimeout() : int
        {
            return _requestTimeout;
        }// end function

        protected function connectFailed(event:ChannelFaultEvent) : void
        {
            shutdownConnectTimer();
            setConnected(false);
            if (Log.isError())
            {
                _log.error("\'{0}\' channel connect failed.", id);
            }
            if (!event.rejected && shouldAttemptFailover())
            {
                _connecting = true;
                failover();
            }
            else
            {
                connectCleanup();
            }
            if (reconnecting)
            {
                event.reconnecting = true;
            }
            dispatchEvent(event);
            return;
        }// end function

        public function set uri(param1:String) : void
        {
            if (param1 != null)
            {
                _uri = param1;
                calculateEndpoint();
            }
            return;
        }// end function

        public function initialized(param1:Object, param2:String) : void
        {
            this.id = param2;
            return;
        }// end function

        public function set url(param1:String) : void
        {
            uri = param1;
            return;
        }// end function

        protected function disconnectSuccess(param1:Boolean = false) : void
        {
            setConnected(false);
            if (Log.isInfo())
            {
                _log.info("\'{0}\' channel disconnected.", id);
            }
            if (!param1 && shouldAttemptFailover())
            {
                _connecting = true;
                failover();
            }
            else
            {
                connectCleanup();
            }
            dispatchEvent(ChannelEvent.createEvent(ChannelEvent.DISCONNECT, this, reconnecting, param1));
            return;
        }// end function

        protected function internalSend(param1:MessageResponder) : void
        {
            return;
        }// end function

        function sendInternalMessage(param1:MessageResponder) : void
        {
            internalSend(param1);
            return;
        }// end function

        final public function connect(param1:ChannelSet) : void
        {
            var _loc_5:FlexClient = null;
            var _loc_2:Boolean = false;
            var _loc_3:* = _channelSets.length;
            var _loc_4:int = 0;
            while (_loc_4 < _channelSets.length)
            {
                
                if (_channelSets[_loc_4] == param1)
                {
                    _loc_2 = true;
                    break;
                }
                _loc_4++;
            }
            _shouldBeConnected = true;
            if (!_loc_2)
            {
                _channelSets.push(param1);
                addEventListener(ChannelEvent.CONNECT, param1.channelConnectHandler);
                addEventListener(ChannelEvent.DISCONNECT, param1.channelDisconnectHandler);
                addEventListener(ChannelFaultEvent.FAULT, param1.channelFaultHandler);
            }
            if (connected)
            {
                param1.channelConnectHandler(ChannelEvent.createEvent(ChannelEvent.CONNECT, this, false, false, connected));
            }
            else if (!_connecting)
            {
                _connecting = true;
                if (connectTimeout > 0)
                {
                    _connectTimer = new Timer(connectTimeout * 1000, 1);
                    _connectTimer.addEventListener(TimerEvent.TIMER, connectTimeoutHandler);
                    _connectTimer.start();
                }
                if (FlexClient.getInstance().id == null)
                {
                    _loc_5 = FlexClient.getInstance();
                    if (!_loc_5.waitForFlexClientId)
                    {
                        _loc_5.waitForFlexClientId = true;
                        _ownsWaitGuard = true;
                        internalConnect();
                    }
                    else
                    {
                        _loc_5.addEventListener(PropertyChangeEvent.PROPERTY_CHANGE, flexClientWaitHandler);
                    }
                }
                else
                {
                    internalConnect();
                }
            }
            return;
        }// end function

        private function resetToPrimaryURI() : void
        {
            _connecting = false;
            setReconnecting(false);
            uri = _primaryURI;
            _failoverIndex = -1;
            return;
        }// end function

        function setAuthenticated(param1:Boolean) : void
        {
            var _loc_2:PropertyChangeEvent = null;
            var _loc_3:ChannelSet = null;
            var _loc_4:int = 0;
            if (param1 != _authenticated)
            {
                _loc_2 = PropertyChangeEvent.createUpdateEvent(this, "authenticated", _authenticated, param1);
                _authenticated = param1;
                _loc_4 = 0;
                while (_loc_4 < _channelSets.length)
                {
                    
                    _loc_3 = ChannelSet(_channelSets[_loc_4]);
                    _loc_3.setAuthenticated(authenticated, credentials);
                    _loc_4++;
                }
                dispatchEvent(_loc_2);
            }
            return;
        }// end function

        protected function handleServerMessagingVersion(param1:Number) : void
        {
            useSmallMessages = param1 >= messagingVersion;
            return;
        }// end function

        function get loginAfterDisconnect() : Boolean
        {
            return _loginAfterDisconnect;
        }// end function

        private function failover() : void
        {
            var acs:Class;
            var duration:int;
            var channelSet:ChannelSet;
            var d:int;
            var remaining:Number;
            var delay:int;
            if (_previouslyConnected)
            {
                _previouslyConnected = false;
                acs;
                try
                {
                    acs = getDefinitionByName("mx.messaging.AdvancedChannelSet") as Class;
                }
                catch (ignore:Error)
                {
                }
                duration;
                if (acs != null)
                {
                    var _loc_2:int = 0;
                    var _loc_3:* = channelSets;
                    while (_loc_3 in _loc_2)
                    {
                        
                        channelSet = _loc_3[_loc_2];
                        if (channelSet is acs)
                        {
                            d = (channelSet as acs)["reliableReconnectDuration"];
                            if (d > duration)
                            {
                                duration = d;
                            }
                        }
                    }
                }
                if (duration != -1)
                {
                    setReconnecting(true);
                    reliableReconnectDuration = duration;
                    _reliableReconnectBeginTimestamp = new Date().valueOf();
                    new AsyncDispatcher(reconnect, null, 1);
                    return;
                }
            }
            if (reliableReconnectDuration != -1)
            {
                _reliableReconnectLastTimestamp = new Date().valueOf();
                remaining = reliableReconnectDuration - (_reliableReconnectLastTimestamp - _reliableReconnectBeginTimestamp);
                if (remaining > 0)
                {
                    delay;
                    if (delay < remaining)
                    {
                        new AsyncDispatcher(reconnect, null, delay);
                        return;
                    }
                }
                reliableReconnectCleanup();
            }
            var _loc_3:* = _failoverIndex + 1;
            _failoverIndex = _loc_3;
            if ((_failoverIndex + 1) <= failoverURIs.length)
            {
                setReconnecting(true);
                uri = failoverURIs[_failoverIndex];
                if (Log.isInfo())
                {
                    _log.info("\'{0}\' channel attempting to connect to {1}.", id, endpoint);
                }
                new AsyncDispatcher(reconnect, null, 1);
            }
            else
            {
                if (Log.isInfo())
                {
                    _log.info("\'{0}\' channel has exhausted failover options and has reset to its primary endpoint.", id);
                }
                resetToPrimaryURI();
            }
            return;
        }// end function

        public function get channelSets() : Array
        {
            return _channelSets;
        }// end function

        protected function disconnectFailed(event:ChannelFaultEvent) : void
        {
            _connecting = false;
            setConnected(false);
            if (Log.isError())
            {
                _log.error("\'{0}\' channel disconnect failed.", id);
            }
            if (reconnecting)
            {
                resetToPrimaryURI();
                event.reconnecting = false;
            }
            dispatchEvent(event);
            return;
        }// end function

    }
}
