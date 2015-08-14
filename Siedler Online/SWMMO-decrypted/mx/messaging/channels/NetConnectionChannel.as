package mx.messaging.channels
{
    import flash.events.*;
    import flash.net.*;
    import mx.logging.*;
    import mx.messaging.*;
    import mx.messaging.config.*;
    import mx.messaging.events.*;
    import mx.messaging.messages.*;
    import mx.netmon.*;

    public class NetConnectionChannel extends PollingChannel
    {
        var _appendToURL:String;
        protected var _nc:NetConnection;

        public function NetConnectionChannel(param1:String = null, param2:String = null)
        {
            super(param1, param2);
            _nc = new NetConnection();
            _nc.objectEncoding = ObjectEncoding.AMF3;
            _nc.client = this;
            return;
        }// end function

        public function AppendToGatewayUrl(param1:String) : void
        {
            if (param1 != null && param1 != "" && param1 != _appendToURL)
            {
                if (Log.isDebug())
                {
                    _log.debug("\'{0}\' channel will disconnect and reconnect with with its session identifier \'{1}\' appended to its endpoint url \n", id, param1);
                }
                _appendToURL = param1;
            }
            return;
        }// end function

        public function receive(param1:IMessage, ... args) : void
        {
            args = new activation;
            var mpiutil:MessagePerformanceUtils;
            var msg:* = param1;
            var rest:* = args;
            if (Log.isDebug())
            {
                _log.debug("\'{0}\' channel got message\n{1}\n", id, toString());
                if (this.mpiEnabled)
                {
                    try
                    {
                        mpiutil = new MessagePerformanceUtils();
                        _log.debug(prettyPrint());
                    }
                    catch (e:Error)
                    {
                        _log.debug("Could not get message performance information for: " + e.toString());
                    }
                }
            }
            dispatchEvent(MessageEvent.createEvent(MessageEvent.MESSAGE, ));
            return;
        }// end function

        override protected function internalSend(param1:MessageResponder) : void
        {
            var _loc_3:MessagePerformanceInfo = null;
            var _loc_4:IMessage = null;
            setFlexClientIdOnMessage(param1.message);
            if (mpiEnabled)
            {
                _loc_3 = new MessagePerformanceInfo();
                if (recordMessageTimes)
                {
                    _loc_3.sendTime = new Date().getTime();
                }
                param1.message.headers[MessagePerformanceUtils.MPI_HEADER_IN] = _loc_3;
            }
            var _loc_2:* = param1.message;
            if (useSmallMessages && _loc_2 is ISmallMessage)
            {
                _loc_4 = ISmallMessage(_loc_2).getSmallMessage();
                if (_loc_4 != null)
                {
                    _loc_2 = _loc_4;
                }
            }
            _nc.call(null, param1, _loc_2);
            return;
        }// end function

        override protected function getDefaultMessageResponder(param1:MessageAgent, param2:IMessage) : MessageResponder
        {
            return new NetConnectionMessageResponder(param1, param2, this);
        }// end function

        protected function securityErrorHandler(event:SecurityErrorEvent) : void
        {
            defaultErrorHandler("Channel.Security.Error", event);
            return;
        }// end function

        private function defaultErrorHandler(param1:String, param2:ErrorEvent) : void
        {
            var _loc_3:* = ChannelFaultEvent.createEvent(this, false, param1, "error", param2.text + " url: \'" + endpoint + "\'");
            _loc_3.rootCause = param2;
            if (_connecting)
            {
                connectFailed(_loc_3);
            }
            else
            {
                dispatchEvent(_loc_3);
            }
            return;
        }// end function

        override public function get useSmallMessages() : Boolean
        {
            return super.useSmallMessages && _nc != null && _nc.objectEncoding >= ObjectEncoding.AMF3;
        }// end function

        override protected function internalConnect() : void
        {
            var url:String;
            var i:int;
            var temp:String;
            var j:int;
            var redirectedUrl:String;
            super.internalConnect();
            url = endpoint;
            if (_appendToURL != null)
            {
                i = url.indexOf("wsrp-url=");
                if (i != -1)
                {
                    temp = url.substr(i + 9, url.length);
                    j = temp.indexOf("&");
                    if (j != -1)
                    {
                        temp = temp.substr(0, j);
                    }
                    url = url.replace(temp, temp + _appendToURL);
                }
                else
                {
                    url = url + _appendToURL;
                }
            }
            if (_nc.uri != null && _nc.uri.length > 0 && _nc.connected)
            {
                _nc.removeEventListener(NetStatusEvent.NET_STATUS, statusHandler);
                _nc.close();
            }
            _nc.addEventListener(NetStatusEvent.NET_STATUS, statusHandler);
            _nc.addEventListener(SecurityErrorEvent.SECURITY_ERROR, securityErrorHandler);
            _nc.addEventListener(IOErrorEvent.IO_ERROR, ioErrorHandler);
            _nc.addEventListener(AsyncErrorEvent.ASYNC_ERROR, asyncErrorHandler);
            try
            {
                if (NetworkMonitor.isMonitoring())
                {
                    redirectedUrl = NetworkMonitor.adjustNetConnectionURL(LoaderConfig.url, url);
                    if (redirectedUrl != null)
                    {
                        url = redirectedUrl;
                    }
                }
                _nc.connect(url);
            }
            catch (e:Error)
            {
                e.message = e.message + ("  url: \'" + url + "\'");
                throw e;
            }
            return;
        }// end function

        protected function ioErrorHandler(event:IOErrorEvent) : void
        {
            defaultErrorHandler("Channel.IO.Error", event);
            return;
        }// end function

        protected function statusHandler(event:NetStatusEvent) : void
        {
            return;
        }// end function

        override protected function internalDisconnect(param1:Boolean = false) : void
        {
            super.internalDisconnect(param1);
            shutdownNetConnection();
            disconnectSuccess(param1);
            return;
        }// end function

        override protected function connectTimeoutHandler(event:TimerEvent) : void
        {
            shutdownNetConnection();
            super.connectTimeoutHandler(event);
            return;
        }// end function

        public function get netConnection() : NetConnection
        {
            return _nc;
        }// end function

        protected function shutdownNetConnection() : void
        {
            _nc.removeEventListener(SecurityErrorEvent.SECURITY_ERROR, securityErrorHandler);
            _nc.removeEventListener(IOErrorEvent.IO_ERROR, ioErrorHandler);
            _nc.removeEventListener(NetStatusEvent.NET_STATUS, statusHandler);
            _nc.removeEventListener(AsyncErrorEvent.ASYNC_ERROR, asyncErrorHandler);
            _nc.close();
            return;
        }// end function

        protected function asyncErrorHandler(event:AsyncErrorEvent) : void
        {
            defaultErrorHandler("Channel.Async.Error", event);
            return;
        }// end function

    }
}
