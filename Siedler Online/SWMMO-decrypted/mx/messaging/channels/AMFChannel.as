package mx.messaging.channels
{
    import flash.events.*;
    import flash.net.*;
    import mx.logging.*;
    import mx.messaging.*;
    import mx.messaging.config.*;
    import mx.messaging.events.*;
    import mx.messaging.messages.*;
    import mx.resources.*;
    import mx.utils.*;

    public class AMFChannel extends NetConnectionChannel
    {
        protected var _reconnectingWithSessionId:Boolean;
        private var _ignoreNetStatusEvents:Boolean;
        private var resourceManager:IResourceManager;

        public function AMFChannel(param1:String = null, param2:String = null)
        {
            resourceManager = ResourceManager.getInstance();
            super(param1, param2);
            return;
        }// end function

        override public function AppendToGatewayUrl(param1:String) : void
        {
            if (param1 != null && param1 != "" && _appendToURL != param1)
            {
                super.AppendToGatewayUrl(param1);
                _reconnectingWithSessionId = true;
            }
            return;
        }// end function

        public function get polling() : Boolean
        {
            return pollOutstanding;
        }// end function

        public function get pollingEnabled() : Boolean
        {
            return internalPollingEnabled;
        }// end function

        public function get piggybackingEnabled() : Boolean
        {
            return internalPiggybackingEnabled;
        }// end function

        override protected function statusHandler(event:NetStatusEvent) : void
        {
            var _loc_2:ChannelFaultEvent = null;
            var _loc_4:Object = null;
            var _loc_5:String = null;
            if (_ignoreNetStatusEvents)
            {
                return;
            }
            if (Log.isDebug())
            {
                _log.debug("\'{0}\' channel got status. {1}", id, ObjectUtil.toString(event.info));
            }
            var _loc_3:Boolean = true;
            if (event.info != null)
            {
                _loc_4 = event.info;
                if (_loc_4.level == "error")
                {
                    if (_loc_4.code == "Client.Data.UnderFlow")
                    {
                        if (Log.isDebug())
                        {
                            _log.debug("\'{0}\' channel received a \'Client.Data.Underflow\' status event.");
                        }
                        return;
                    }
                    if (connected)
                    {
                        if (_loc_4.code.indexOf("Call.Failed") != -1)
                        {
                            _loc_2 = ChannelFaultEvent.createEvent(this, false, "Channel.Call.Failed", _loc_4.level, _loc_4.code + ": " + _loc_4.description);
                            _loc_2.rootCause = _loc_4;
                            dispatchEvent(_loc_2);
                        }
                        internalDisconnect();
                    }
                    else
                    {
                        _loc_2 = ChannelFaultEvent.createEvent(this, false, "Channel.Connect.Failed", _loc_4.level, _loc_4.code + ": " + _loc_4.description + ": url: \'" + endpoint + "\'");
                        _loc_2.rootCause = _loc_4;
                        connectFailed(_loc_2);
                    }
                }
                else if (!connected)
                {
                    _loc_3 = _loc_4.level == "status" && _loc_4.code.indexOf("Connect.Closed") != -1;
                }
                else
                {
                    _loc_3 = false;
                }
            }
            else
            {
                _loc_3 = false;
            }
            if (!_loc_3)
            {
                _loc_5 = resourceManager.getString("messaging", "invalidURL");
                connectFailed(ChannelFaultEvent.createEvent(this, false, "Channel.Connect.Failed", "error", _loc_5 + " url: \'" + endpoint + "\'"));
            }
            return;
        }// end function

        public function get pollingInterval() : Number
        {
            return internalPollingInterval;
        }// end function

        protected function handleReconnectWithSessionId() : void
        {
            if (_reconnectingWithSessionId)
            {
                _reconnectingWithSessionId = false;
                shutdownNetConnection();
                super.internalConnect();
                _ignoreNetStatusEvents = false;
            }
            return;
        }// end function

        public function set piggybackingEnabled(param1:Boolean) : void
        {
            internalPiggybackingEnabled = param1;
            return;
        }// end function

        override protected function internalConnect() : void
        {
            super.internalConnect();
            _ignoreNetStatusEvents = false;
            var _loc_1:* = new CommandMessage();
            if (credentials != null)
            {
                _loc_1.operation = CommandMessage.LOGIN_OPERATION;
                _loc_1.body = credentials;
            }
            else
            {
                _loc_1.operation = CommandMessage.CLIENT_PING_OPERATION;
            }
            _loc_1.headers[CommandMessage.MESSAGING_VERSION] = messagingVersion;
            if (ServerConfig.needsConfig(this))
            {
                _loc_1.headers[CommandMessage.NEEDS_CONFIG_HEADER] = true;
            }
            setFlexClientIdOnMessage(_loc_1);
            netConnection.call(null, new Responder(resultHandler, faultHandler), _loc_1);
            if (Log.isDebug())
            {
                _log.debug("\'{0}\' pinging endpoint.", id);
            }
            return;
        }// end function

        protected function faultHandler(param1:ErrorMessage) : void
        {
            var _loc_2:ChannelFaultEvent = null;
            var _loc_3:Number = NaN;
            if (param1 != null)
            {
                _loc_2 = null;
                if (param1.faultCode == "Client.Authentication")
                {
                    resultHandler(param1);
                    _loc_2 = ChannelFaultEvent.createEvent(this, false, "Channel.Authentication.Error", "warn", param1.faultString);
                    _loc_2.rootCause = param1;
                    dispatchEvent(_loc_2);
                }
                else
                {
                    _log.debug("\'{0}\' fault handler called. {1}", id, param1.toString());
                    if (FlexClient.getInstance().id == null && param1.headers[AbstractMessage.FLEX_CLIENT_ID_HEADER] != null)
                    {
                        FlexClient.getInstance().id = param1.headers[AbstractMessage.FLEX_CLIENT_ID_HEADER];
                    }
                    if (param1.headers[CommandMessage.MESSAGING_VERSION] != null)
                    {
                        _loc_3 = param1.headers[CommandMessage.MESSAGING_VERSION] as Number;
                        handleServerMessagingVersion(_loc_3);
                    }
                    _loc_2 = ChannelFaultEvent.createEvent(this, false, "Channel.Ping.Failed", "error", param1.faultString + " url: \'" + endpoint + (_appendToURL == null ? ("") : (_appendToURL + "\'")) + "\'");
                    _loc_2.rootCause = param1;
                    connectFailed(_loc_2);
                }
            }
            handleReconnectWithSessionId();
            return;
        }// end function

        public function set pollingInterval(param1:Number) : void
        {
            internalPollingInterval = param1;
            return;
        }// end function

        override public function applySettings(param1:XML) : void
        {
            super.applySettings(param1);
            applyPollingSettings(param1);
            return;
        }// end function

        override protected function internalSend(param1:MessageResponder) : void
        {
            handleReconnectWithSessionId();
            super.internalSend(param1);
            return;
        }// end function

        override public function get protocol() : String
        {
            return "http";
        }// end function

        override protected function internalDisconnect(param1:Boolean = false) : void
        {
            var _loc_2:CommandMessage = null;
            if (!param1 && !shouldBeConnected)
            {
                _loc_2 = new CommandMessage();
                _loc_2.operation = CommandMessage.DISCONNECT_OPERATION;
                internalSend(new MessageResponder(null, _loc_2, null));
            }
            setConnected(false);
            super.internalDisconnect(param1);
            return;
        }// end function

        protected function resultHandler(param1:IMessage) : void
        {
            var _loc_2:Number = NaN;
            if (param1 != null)
            {
                ServerConfig.updateServerConfigData(param1.body as ConfigMap, endpoint);
                if (FlexClient.getInstance().id == null && param1.headers[AbstractMessage.FLEX_CLIENT_ID_HEADER] != null)
                {
                    FlexClient.getInstance().id = param1.headers[AbstractMessage.FLEX_CLIENT_ID_HEADER];
                }
                if (param1.headers[CommandMessage.MESSAGING_VERSION] != null)
                {
                    _loc_2 = param1.headers[CommandMessage.MESSAGING_VERSION] as Number;
                    handleServerMessagingVersion(_loc_2);
                }
            }
            handleReconnectWithSessionId();
            connectSuccess();
            if (credentials != null && !(param1 is ErrorMessage))
            {
                setAuthenticated(true);
            }
            return;
        }// end function

        public function set pollingEnabled(param1:Boolean) : void
        {
            internalPollingEnabled = param1;
            return;
        }// end function

        override protected function shutdownNetConnection() : void
        {
            _nc.removeEventListener(SecurityErrorEvent.SECURITY_ERROR, securityErrorHandler);
            _nc.removeEventListener(IOErrorEvent.IO_ERROR, ioErrorHandler);
            _ignoreNetStatusEvents = true;
            _nc.close();
            return;
        }// end function

    }
}
