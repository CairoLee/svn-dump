package org.igniterealtime.xiff.core
{
    import flash.events.*;
    import flash.net.*;
    import flash.utils.*;
    import flash.xml.*;
    import org.igniterealtime.xiff.data.*;
    import org.igniterealtime.xiff.events.*;

    public class XMPPBOSHConnection extends XMPPConnection
    {
        private var _boshPath:String = "http-bind/";
        private var responseTimer:Timer;
        private var rid:uint;
        private var _secure:Boolean;
        private var _hold:uint = 1;
        private var _maxConcurrentRequests:uint = 2;
        private var inactivity:uint;
        private var isDisconnecting:Boolean = false;
        private var requestQueue:Array;
        private var requestCount:int = 0;
        private var sid:String;
        private var responseQueue:Array;
        private var _wait:uint = 20;
        private var streamRestarted:Boolean;
        private var lastPollTime:Date = null;
        private var boshPollingInterval:uint = 10;
        private var pauseEnabled:Boolean = false;
        private var maxPause:uint;
        private var pollingEnabled:Boolean = false;
        public static const HTTPS_PORT:uint = 7443;
        public static const HTTP_PORT:uint = 7070;
        public static const BOSH_VERSION:String = "1.6";
        private static const headers:Object = {POST:[], GET:["Cache-Control", "no-store", "Cache-Control", "no-cache", "Pragma", "no-cache"]};

        public function XMPPBOSHConnection(param1:Boolean = false) : void
        {
            requestQueue = [];
            responseQueue = [];
            this.secure = param1;
            resource = "xiff-bosh";
            responseTimer = new Timer(0, 1);
            responseTimer.addEventListener(TimerEvent.TIMER_COMPLETE, processResponse);
            return;
        }// end function

        public function set hold(param1:uint) : void
        {
            _hold = param1;
            return;
        }// end function

        private function onRequestComplete(event:Event) : void
        {
            var _loc_7:XMLNode = null;
            var _loc_8:Boolean = false;
            var _loc_9:XMLNode = null;
            var _loc_2:* = event.target as URLLoader;
            var _loc_11:* = requestCount - 1;
            requestCount = _loc_11;
            var _loc_3:* = _loc_2.data as ByteArray;
            var _loc_4:* = new XMLDocument();
            new XMLDocument().ignoreWhite = ignoreWhiteSpace;
            _loc_4.parseXML(_loc_3.readUTFBytes(_loc_3.length));
            var _loc_5:* = new IncomingDataEvent();
            new IncomingDataEvent().data = _loc_3;
            dispatchEvent(_loc_5);
            var _loc_6:* = _loc_4.firstChild;
            if (streamRestarted && !_loc_6.hasChildNodes())
            {
                streamRestarted = false;
                bindConnection();
            }
            if (_loc_6.attributes["type"] == "terminate")
            {
                dispatchError("BOSH Error", _loc_6.attributes["condition"], "", -1);
                active = false;
            }
            if (_loc_6.attributes["sid"] && !loggedIn)
            {
                processConnectionResponse(_loc_6);
                _loc_8 = false;
                for each (_loc_9 in _loc_6.childNodes)
                {
                    
                    if (_loc_9.nodeName == "stream:features")
                    {
                        _loc_8 = true;
                    }
                }
                if (!_loc_8)
                {
                    pollingEnabled = true;
                    pollServer();
                }
            }
            for each (_loc_7 in _loc_6.childNodes)
            {
                
                responseQueue.push(_loc_7);
            }
            resetResponseProcessor();
            if (responseQueue.length == 0)
            {
                pollServer();
            }
            return;
        }// end function

        public function processConnectionResponse(param1:XMLNode) : void
        {
            dispatchEvent(new ConnectionSuccessEvent());
            var _loc_2:* = param1.attributes;
            sid = _loc_2.sid;
            wait = _loc_2.wait;
            if (_loc_2.polling)
            {
                boshPollingInterval = _loc_2.polling;
            }
            if (_loc_2.inactivity)
            {
                inactivity = _loc_2.inactivity;
            }
            if (_loc_2.maxpause)
            {
                maxPause = _loc_2.maxpause;
                pauseEnabled = true;
            }
            if (_loc_2.requests)
            {
                maxConcurrentRequests = _loc_2.requests;
            }
            trace("Polling interval: {0}", boshPollingInterval);
            trace("Inactivity timeout: {0}", inactivity);
            trace("Max requests: {0}", maxConcurrentRequests);
            trace("Max pause: {0}", maxPause);
            active = true;
            addEventListener(LoginEvent.LOGIN, handleLogin);
            return;
        }// end function

        public function get maxConcurrentRequests() : uint
        {
            return _maxConcurrentRequests;
        }// end function

        override public function sendKeepAlive() : void
        {
            return;
        }// end function

        private function handleLogin(event:LoginEvent) : void
        {
            pollingEnabled = true;
            pollServer();
            return;
        }// end function

        override protected function handleNodeType(param1:XMLNode) : void
        {
            super.handleNodeType(param1);
            var _loc_2:* = param1.nodeName.toLowerCase();
            if (_loc_2 == "stream:features")
            {
                streamRestarted = false;
            }
            return;
        }// end function

        private function get nextRID() : uint
        {
            if (!rid)
            {
                rid = Math.floor(Math.random() * 1000000 + 10);
            }
            return ++rid;
        }// end function

        override public function disconnect() : void
        {
            var _loc_1:XMLNode = null;
            if (active)
            {
                _loc_1 = createRequest();
                _loc_1.attributes.type = "terminate";
                sendRequests(_loc_1);
                active = false;
                loggedIn = false;
                dispatchEvent(new DisconnectionEvent());
            }
            return;
        }// end function

        public function get boshPath() : String
        {
            return _boshPath;
        }// end function

        public function set maxConcurrentRequests(param1:uint) : void
        {
            _maxConcurrentRequests = param1;
            return;
        }// end function

        public function get hold() : uint
        {
            return _hold;
        }// end function

        private function resetResponseProcessor() : void
        {
            if (responseQueue.length > 0)
            {
                responseTimer.reset();
                responseTimer.start();
            }
            return;
        }// end function

        public function pauseSession(param1:uint) : Boolean
        {
            trace("Pausing session for {0} seconds", param1);
            if (!pauseEnabled || param1 > maxPause || param1 <= boshPollingInterval)
            {
                return false;
            }
            pollingEnabled = false;
            var _loc_2:* = createRequest();
            _loc_2.attributes["pause"] = param1;
            sendRequests(_loc_2);
            var _loc_3:* = new Timer(param1 * 1000 - 2000, 1);
            _loc_3.addEventListener(TimerEvent.TIMER, handlePauseTimeout);
            _loc_3.start();
            return true;
        }// end function

        private function handlePauseTimeout(event:TimerEvent) : void
        {
            pollingEnabled = true;
            pollServer();
            return;
        }// end function

        private function processResponse(event:TimerEvent = null) : void
        {
            var _loc_2:* = responseQueue.shift();
            handleNodeType(_loc_2);
            resetResponseProcessor();
            if (requestCount == 0 && !sendQueuedRequests())
            {
                pollServer();
            }
            return;
        }// end function

        public function set boshPath(param1:String) : void
        {
            _boshPath = param1;
            return;
        }// end function

        private function pollServer() : void
        {
            if (!isActive() || !pollingEnabled || sendQueuedRequests() || requestCount > 0)
            {
                return;
            }
            sendRequests(null, true);
            return;
        }// end function

        override public function connect(param1:uint = 0) : Boolean
        {
            var _loc_2:Object = {xml:lang:XMPPStanza.XML_LANG, xmlns:"http://jabber.org/protocol/httpbind", xmlns:xmpp:"urn:xmpp:xbosh", xmpp:version:XMPPStanza.CLIENT_VERSION, hold:hold, rid:nextRID, secure:secure, wait:wait, ver:BOSH_VERSION, to:domain};
            var _loc_3:* = new XMLNode(1, "body");
            _loc_3.attributes = _loc_2;
            sendRequests(_loc_3);
            return true;
        }// end function

        private function sendRequests(param1:XMLNode = null, param2:Boolean = false) : Boolean
        {
            var _loc_7:Array = null;
            var _loc_8:uint = 0;
            var _loc_9:uint = 0;
            if (requestCount >= maxConcurrentRequests)
            {
                return false;
            }
            var _loc_11:* = requestCount + 1;
            requestCount = _loc_11;
            if (!param1)
            {
                if (param2)
                {
                    param1 = createRequest();
                }
                else
                {
                    _loc_7 = [];
                    _loc_8 = Math.min(10, requestQueue.length);
                    _loc_9 = 0;
                    while (_loc_9 < _loc_8)
                    {
                        
                        _loc_7.push(requestQueue.shift());
                        _loc_9 = _loc_9 + 1;
                    }
                    param1 = createRequest(_loc_7);
                }
            }
            var _loc_3:* = new ByteArray();
            _loc_3.writeUTFBytes(param1.toString());
            var _loc_4:* = new URLRequest(httpServer);
            new URLRequest(httpServer).method = URLRequestMethod.POST;
            _loc_4.contentType = "text/xml";
            _loc_4.requestHeaders = headers[_loc_4.method];
            _loc_4.data = _loc_3;
            var _loc_5:* = new URLLoader();
            new URLLoader().dataFormat = URLLoaderDataFormat.BINARY;
            _loc_5.addEventListener(Event.COMPLETE, onRequestComplete);
            _loc_5.addEventListener(SecurityErrorEvent.SECURITY_ERROR, onSecurityError);
            _loc_5.addEventListener(IOErrorEvent.IO_ERROR, onIOError);
            _loc_5.load(_loc_4);
            var _loc_6:* = new OutgoingDataEvent();
            new OutgoingDataEvent().data = _loc_3;
            dispatchEvent(_loc_6);
            if (param2)
            {
                lastPollTime = new Date();
            }
            return true;
        }// end function

        public function set secure(param1:Boolean) : void
        {
            _secure = param1;
            return;
        }// end function

        override protected function sendXML(param1) : void
        {
            var _loc_2:XMLNode = null;
            var _loc_3:XML = null;
            if (param1 is XML)
            {
                _loc_3 = param1 as XML;
                _loc_2 = new XMLDocument(_loc_3.toXMLString());
            }
            else
            {
                _loc_2 = param1 as XMLNode;
            }
            sendQueuedRequests(_loc_2);
            return;
        }// end function

        public function set wait(param1:uint) : void
        {
            _wait = param1;
            return;
        }// end function

        private function createRequest(param1:Array = null) : XMLNode
        {
            var _loc_4:XMLNode = null;
            var _loc_2:Object = {xmlns:"http://jabber.org/protocol/httpbind", rid:nextRID, sid:sid};
            var _loc_3:* = new XMLNode(1, "body");
            if (param1)
            {
                for each (_loc_4 in param1)
                {
                    
                    _loc_3.appendChild(_loc_4);
                }
            }
            _loc_3.attributes = _loc_2;
            return _loc_3;
        }// end function

        public function get wait() : uint
        {
            return _wait;
        }// end function

        override protected function restartStream() : void
        {
            var _loc_1:* = createRequest();
            _loc_1.attributes["xmpp:restart"] = "true";
            _loc_1.attributes["xmlns:xmpp"] = "urn:xmpp:xbosh";
            _loc_1.attributes["xml:lang"] = "en";
            _loc_1.attributes["to"] = domain;
            sendRequests(_loc_1);
            streamRestarted = true;
            return;
        }// end function

        public function get secure() : Boolean
        {
            return _secure;
        }// end function

        public function get httpServer() : String
        {
            return (secure ? ("https") : ("http")) + "://" + server + ":" + port + "/" + boshPath;
        }// end function

        private function sendQueuedRequests(param1:XMLNode = null) : Boolean
        {
            if (param1)
            {
                requestQueue.push(param1);
            }
            else if (requestQueue.length == 0)
            {
                return false;
            }
            return sendRequests();
        }// end function

    }
}
