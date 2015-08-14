package org.igniterealtime.xiff.core
{
    import flash.events.*;
    import flash.net.*;
    import flash.utils.*;
    import flash.xml.*;
    import org.igniterealtime.xiff.auth.*;
    import org.igniterealtime.xiff.data.*;
    import org.igniterealtime.xiff.data.auth.*;
    import org.igniterealtime.xiff.data.bind.*;
    import org.igniterealtime.xiff.data.forms.*;
    import org.igniterealtime.xiff.data.ping.*;
    import org.igniterealtime.xiff.data.register.*;
    import org.igniterealtime.xiff.data.session.*;
    import org.igniterealtime.xiff.events.*;
    import org.igniterealtime.xiff.exception.*;

    public class XMPPConnection extends EventDispatcher
    {
        protected var _incomingBytes:uint = 0;
        private var presenceQueueTimer:Timer;
        protected var _active:Boolean = false;
        protected var sessionID:String;
        protected var _username:String;
        protected var _incompleteRawXML:String = "";
        protected var _expireTagSearch:Boolean;
        protected var loggedIn:Boolean = false;
        private var _ignoreWhitespace:Boolean = true;
        protected var pendingIQs:Object;
        protected var _port:uint = 5222;
        protected var _server:String;
        protected var _outgoingBytes:uint = 0;
        protected var _resource:String = "xiff";
        protected var socket:Socket;
        protected var _streamType:uint = 0;
        protected var openingStreamTag:String;
        protected var auth:SASLAuth;
        protected var compressionNegotiated:Boolean = false;
        protected var myswmmosid:String;
        protected var _compress:Boolean = false;
        protected var closingStreamTag:String;
        private var presenceQueue:Array;
        protected var _domain:String;
        protected var _useAnonymousLogin:Boolean = false;
        protected var _queuePresences:Boolean = true;
        protected var _password:String;
        static var saslMechanisms:Object = {PLAIN:Plain};
        public static const STREAM_TYPE_STANDARD:uint = 0;
        public static const STREAM_TYPE_FLASH:uint = 2;
        static var _openConnections:Array = [];
        public static const STREAM_TYPE_STANDARD_TERMINATED:uint = 1;
        public static const STREAM_TYPE_FLASH_TERMINATED:uint = 3;

        public function XMPPConnection()
        {
            pendingIQs = {};
            presenceQueue = [];
            AuthExtension.enable();
            BindExtension.enable();
            SessionExtension.enable();
            RegisterExtension.enable();
            FormExtension.enable();
            PingExtension.enable();
            return;
        }// end function

        public function set port(param1:uint) : void
        {
            _port = param1;
            return;
        }// end function

        public function get swmmosid() : String
        {
            return myswmmosid;
        }// end function

        public function get jid() : UnescapedJID
        {
            return new UnescapedJID(_username + "@" + _domain + "/" + _resource);
        }// end function

        public function set swmmosid(param1:String) : void
        {
            myswmmosid = param1;
            return;
        }// end function

        protected function onSecurityError(event:SecurityErrorEvent) : void
        {
            trace("there was a security error of type: " + event.type + "\nError: " + event.text);
            dispatchError("not-authorized", "Not Authorized", "auth", 401);
            return;
        }// end function

        protected function set active(param1:Boolean) : void
        {
            if (param1)
            {
                _openConnections.push(this);
            }
            else
            {
                _openConnections.splice(_openConnections.indexOf(this), 1);
            }
            _active = param1;
            return;
        }// end function

        protected function get active() : Boolean
        {
            return _active;
        }// end function

        public function get resource() : String
        {
            return _resource;
        }// end function

        protected function handleStreamTLS(param1:XMLNode) : void
        {
            if (param1.firstChild && param1.firstChild.nodeName == "required")
            {
            }
            dispatchError("TLS required", "The server requires TLS, but this feature is not implemented.", "cancel", 501);
            disconnect();
            return;
        }// end function

        protected function handleChallenge(param1:XMLNode) : void
        {
            var _loc_2:* = auth.handleChallenge(0, XML(param1.toString()));
            sendXML(_loc_2);
            return;
        }// end function

        public function set resource(param1:String) : void
        {
            if (param1.length > 0)
            {
                _resource = param1;
            }
            return;
        }// end function

        private function establishSession() : void
        {
            var _loc_1:* = new IQ(null, IQ.TYPE_SET);
            _loc_1.addExtension(new SessionExtension());
            _loc_1.callback = handleSessionResponse;
            _loc_1.errorCallback = handleSessionError;
            send(_loc_1);
            return;
        }// end function

        protected function handleStreamError(param1:XMLNode) : void
        {
            var node:* = param1;
            dispatchError("service-unavailable", "Remote Server Error", "cancel", 502);
            try
            {
                socket.close();
            }
            catch (error:Error)
            {
            }
            active = false;
            loggedIn = false;
            var disconnectionEvent:* = new DisconnectionEvent();
            dispatchEvent(disconnectionEvent);
            return;
        }// end function

        protected function handleStreamFeatures(param1:XMLNode) : void
        {
            var _loc_2:XMLNode = null;
            if (!loggedIn)
            {
                for each (_loc_2 in param1.childNodes)
                {
                    
                    if (_loc_2.nodeName == "starttls")
                    {
                        handleStreamTLS(_loc_2);
                        continue;
                    }
                    if (_loc_2.nodeName == "mechanisms")
                    {
                        configureAuthMechanisms(_loc_2);
                        continue;
                    }
                    if (_loc_2.nodeName == "compression")
                    {
                        if (_compress)
                        {
                            configureStreamCompression();
                        }
                    }
                }
                if (compress && compressionNegotiated || !compress)
                {
                    if (useAnonymousLogin || username != null && username.length > 0)
                    {
                        beginAuthentication();
                    }
                    else
                    {
                        getRegistrationFields();
                    }
                }
            }
            else
            {
                bindConnection();
            }
            return;
        }// end function

        protected function chooseStreamTags(param1:uint) : void
        {
            openingStreamTag = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            if (param1 == STREAM_TYPE_FLASH || param1 == STREAM_TYPE_FLASH_TERMINATED)
            {
                openingStreamTag = openingStreamTag + "<flash";
                closingStreamTag = "</flash:stream>";
            }
            else
            {
                openingStreamTag = openingStreamTag + "<stream";
                closingStreamTag = "</stream:stream>";
            }
            openingStreamTag = openingStreamTag + (":stream xmlns=\"" + XMPPStanza.CLIENT_NAMESPACE + "\" ");
            if (param1 == STREAM_TYPE_FLASH || param1 == STREAM_TYPE_FLASH_TERMINATED)
            {
                openingStreamTag = openingStreamTag + ("xmlns:flash=\"" + XMPPStanza.NAMESPACE_FLASH + "\"");
            }
            else
            {
                openingStreamTag = openingStreamTag + ("xmlns:stream=\"" + XMPPStanza.NAMESPACE_STREAM + "\"");
            }
            openingStreamTag = openingStreamTag + (" to=\"" + domain + "\"" + " xml:lang=\"" + XMPPStanza.XML_LANG + "\"" + " version=\"" + XMPPStanza.CLIENT_VERSION + "\"");
            if (param1 == STREAM_TYPE_FLASH_TERMINATED || param1 == STREAM_TYPE_STANDARD_TERMINATED)
            {
                openingStreamTag = openingStreamTag + " /";
            }
            openingStreamTag = openingStreamTag + ">";
            return;
        }// end function

        protected function flushPresenceQueue(event:TimerEvent) : void
        {
            var _loc_2:PresenceEvent = null;
            if (presenceQueue.length > 0)
            {
                _loc_2 = new PresenceEvent();
                _loc_2.data = presenceQueue;
                dispatchEvent(_loc_2);
                presenceQueue = [];
            }
            return;
        }// end function

        public function set password(param1:String) : void
        {
            _password = param1;
            return;
        }// end function

        protected function handlePresence(param1:XMLNode) : Presence
        {
            var _loc_3:PresenceEvent = null;
            if (!presenceQueueTimer)
            {
                presenceQueueTimer = new Timer(1, 1);
                presenceQueueTimer.addEventListener(TimerEvent.TIMER_COMPLETE, flushPresenceQueue);
            }
            var _loc_2:* = new Presence();
            if (!_loc_2.deserialize(param1))
            {
                throw new SerializationException();
            }
            if (queuePresences)
            {
                presenceQueue.push(_loc_2);
                presenceQueueTimer.reset();
                presenceQueueTimer.start();
            }
            else
            {
                _loc_3 = new PresenceEvent();
                _loc_3.data = [_loc_2];
                dispatchEvent(_loc_3);
            }
            return _loc_2;
        }// end function

        public function get server() : String
        {
            if (!_server)
            {
                return _domain;
            }
            return _server;
        }// end function

        protected function addIQCallbackToPending(param1:String, param2:Function, param3:Function) : void
        {
            pendingIQs[param1] = {func:param2, errorFunc:param3};
            return;
        }// end function

        protected function handleIQ(param1:XMLNode) : IQ
        {
            var _loc_3:* = undefined;
            var _loc_4:Array = null;
            var _loc_5:String = null;
            var _loc_6:IExtension = null;
            var _loc_7:IQEvent = null;
            var _loc_2:* = new IQ();
            if (!_loc_2.deserialize(param1))
            {
                throw new SerializationException();
            }
            if (_loc_2.type == IQ.TYPE_ERROR)
            {
                dispatchError(_loc_2.errorCondition, _loc_2.errorMessage, _loc_2.errorType, _loc_2.errorCode);
                if (pendingIQs[_loc_2.id] !== undefined)
                {
                    _loc_3 = pendingIQs[_loc_2.id];
                    if (_loc_3.errorFunc != null)
                    {
                        _loc_3.errorFunc(_loc_2);
                    }
                    pendingIQs[_loc_2.id] = null;
                    delete pendingIQs[_loc_2.id];
                }
            }
            else if (pendingIQs[_loc_2.id] !== undefined)
            {
                _loc_3 = pendingIQs[_loc_2.id];
                if (_loc_3.func != null)
                {
                    _loc_3.func(_loc_2);
                }
                pendingIQs[_loc_2.id] = null;
                delete pendingIQs[_loc_2.id];
            }
            else
            {
                _loc_4 = _loc_2.getAllExtensions();
                for (_loc_5 in _loc_4)
                {
                    
                    _loc_6 = _loc_4[_loc_5] as IExtension;
                    if (_loc_6 != null)
                    {
                        _loc_7 = new IQEvent(_loc_6.getNS());
                        _loc_7.data = _loc_6;
                        _loc_7.iq = _loc_2;
                        dispatchEvent(_loc_7);
                    }
                }
            }
            return _loc_2;
        }// end function

        private function handleSessionError(param1:IQ) : void
        {
            return;
        }// end function

        public function get useAnonymousLogin() : Boolean
        {
            return _useAnonymousLogin;
        }// end function

        public function get outgoingBytes() : uint
        {
            return _outgoingBytes;
        }// end function

        public function changePassword(param1:String) : void
        {
            var _loc_2:* = new IQ(new EscapedJID(domain), IQ.TYPE_SET, XMPPStanza.generateID("pswd_change_"), changePassword_result);
            var _loc_3:* = new RegisterExtension(_loc_2.getNode());
            _loc_3.username = jid.escaped.bareJID;
            _loc_3.password = param1;
            _loc_2.addExtension(_loc_3);
            send(_loc_2);
            return;
        }// end function

        protected function sendXML(param1) : void
        {
            param1 = param1 is XML ? (XML(param1).toXMLString()) : (param1);
            var _loc_2:* = new ByteArray();
            _loc_2.writeUTFBytes(param1);
            _loc_2.position = 0;
            if (compressionNegotiated)
            {
                _loc_2.compress();
                _loc_2.position = 0;
            }
            if (socket && socket.connected)
            {
                socket.writeBytes(_loc_2, 0, _loc_2.length);
                socket.flush();
            }
            _outgoingBytes = _outgoingBytes + _loc_2.length;
            var _loc_3:* = new OutgoingDataEvent();
            _loc_3.data = _loc_2;
            dispatchEvent(_loc_3);
            return;
        }// end function

        protected function changePassword_result(param1:IQ) : void
        {
            var _loc_2:ChangePasswordSuccessEvent = null;
            if (param1.type == IQ.TYPE_RESULT)
            {
                _loc_2 = new ChangePasswordSuccessEvent();
                dispatchEvent(_loc_2);
            }
            else
            {
                dispatchError("unexpected-request", "Unexpected Request", "wait", 400);
            }
            return;
        }// end function

        protected function getRegistrationFields_result(param1:IQ) : void
        {
            var ext:RegisterExtension;
            var fields:Array;
            var event:RegistrationFieldsEvent;
            var resultIQ:* = param1;
            try
            {
                ext = resultIQ.getAllExtensionsByNS(RegisterExtension.NS)[0];
                fields = ext.getRequiredFieldNames();
                event = new RegistrationFieldsEvent();
                event.fields = fields;
                event.data = ext;
                dispatchEvent(event);
            }
            catch (err:Error)
            {
                trace(err.getStackTrace());
            }
            return;
        }// end function

        protected function restartStream() : void
        {
            sendXML(openingStreamTag);
            return;
        }// end function

        public function sendRegistrationFields(param1:Object, param2:String) : void
        {
            var _loc_5:String = null;
            var _loc_3:* = new IQ(new EscapedJID(domain), IQ.TYPE_SET, XMPPStanza.generateID("reg_attempt_"), sendRegistrationFields_result);
            var _loc_4:* = new RegisterExtension(_loc_3.getNode());
            for (_loc_5 in param1)
            {
                
                _loc_4.setField(_loc_5, param1[_loc_5]);
            }
            if (param2 != null)
            {
                _loc_4.key = param2;
            }
            _loc_3.addExtension(_loc_4);
            send(_loc_3);
            return;
        }// end function

        protected function configureStreamCompression() : void
        {
            var _loc_1:* = <compress xmlns=""http://jabber.org/protocol/compress""><method>zlib</method></compress>")("<compress xmlns="http://jabber.org/protocol/compress"><method>zlib</method></compress>;
            sendXML(_loc_1);
            return;
        }// end function

        protected function beginAuthentication() : void
        {
            if (auth != null)
            {
                sendXML(auth.request);
            }
            return;
        }// end function

        protected function handleBindError(param1:IQ) : void
        {
            return;
        }// end function

        public function get compress() : Boolean
        {
            return _compress;
        }// end function

        public function set server(param1:String) : void
        {
            _server = param1;
            return;
        }// end function

        protected function createSocket() : void
        {
            socket = new Socket();
            socket.addEventListener(Event.CLOSE, socketClosed);
            socket.addEventListener(Event.CONNECT, socketConnected);
            socket.addEventListener(IOErrorEvent.IO_ERROR, onIOError);
            socket.addEventListener(ProgressEvent.SOCKET_DATA, socketDataReceived);
            socket.addEventListener(SecurityErrorEvent.SECURITY_ERROR, onSecurityError);
            return;
        }// end function

        public function get port() : uint
        {
            return _port;
        }// end function

        public function isLoggedIn() : Boolean
        {
            return loggedIn;
        }// end function

        public function set queuePresences(param1:Boolean) : void
        {
            if (_queuePresences && !param1)
            {
                if (presenceQueueTimer)
                {
                    presenceQueueTimer.stop();
                }
                flushPresenceQueue(null);
            }
            _queuePresences = param1;
            return;
        }// end function

        public function send(param1:XMPPStanza) : void
        {
            var _loc_2:XMLNode = null;
            var _loc_3:IQ = null;
            if (isActive())
            {
                if (param1 is IQ)
                {
                    _loc_3 = param1 as IQ;
                    if (_loc_3.callback != null || _loc_3.errorCallback != null)
                    {
                        addIQCallbackToPending(_loc_3.id, _loc_3.callback, _loc_3.errorCallback);
                    }
                }
                _loc_2 = param1.getNode().parentNode;
                if (_loc_2 == null)
                {
                    _loc_2 = new XMLDocument();
                }
                if (param1.serialize(_loc_2))
                {
                    sendXML(_loc_2.firstChild);
                }
                else
                {
                    throw new SerializationException();
                }
            }
            return;
        }// end function

        protected function sendRegistrationFields_result(param1:IQ) : void
        {
            var _loc_2:RegistrationSuccessEvent = null;
            if (param1.type == IQ.TYPE_RESULT)
            {
                _loc_2 = new RegistrationSuccessEvent();
                dispatchEvent(_loc_2);
            }
            else
            {
                dispatchError("unexpected-request", "Unexpected Request", "wait", 400);
            }
            return;
        }// end function

        public function get password() : String
        {
            return _password;
        }// end function

        public function set ignoreWhiteSpace(param1:Boolean) : void
        {
            _ignoreWhitespace = param1;
            XML.ignoreWhitespace = param1;
            return;
        }// end function

        public function sendKeepAlive() : void
        {
            var _loc_1:* = new IQ(new EscapedJID(server), IQ.TYPE_GET);
            _loc_1.addExtension(new PingExtension());
            send(_loc_1);
            return;
        }// end function

        public function disconnect() : void
        {
            var _loc_1:DisconnectionEvent = null;
            if (isActive())
            {
                sendXML(closingStreamTag);
                if (socket && socket.connected)
                {
                    socket.close();
                }
                active = false;
                loggedIn = false;
                _loc_1 = new DisconnectionEvent();
                dispatchEvent(_loc_1);
            }
            return;
        }// end function

        protected function handleNodeType(param1:XMLNode) : void
        {
            var _loc_2:* = param1.nodeName.toLowerCase();
            switch(_loc_2)
            {
                case "stream:stream":
                case "flash:stream":
                {
                    _expireTagSearch = false;
                    handleStream(param1);
                    break;
                }
                case "stream:error":
                {
                    handleStreamError(param1);
                    break;
                }
                case "stream:features":
                {
                    handleStreamFeatures(param1);
                    break;
                }
                case "iq":
                {
                    handleIQ(param1);
                    break;
                }
                case "message":
                {
                    handleMessage(param1);
                    break;
                }
                case "presence":
                {
                    handlePresence(param1);
                    break;
                }
                case "challenge":
                {
                    handleChallenge(param1);
                    break;
                }
                case "success":
                {
                    handleAuthentication(param1);
                    break;
                }
                case "compressed":
                {
                    compressionNegotiated = true;
                    restartStream();
                    break;
                }
                case "failure":
                {
                    handleAuthentication(param1);
                    break;
                }
                default:
                {
                    dispatchError("undefined-condition", "Unknown Error", "modify", 500);
                    break;
                    break;
                }
            }
            return;
        }// end function

        protected function configureAuthMechanisms(param1:XMLNode) : void
        {
            var _loc_2:Class = null;
            var _loc_3:XMLNode = null;
            for each (_loc_3 in param1.childNodes)
            {
                
                _loc_2 = saslMechanisms[_loc_3.firstChild.nodeValue];
                if (useAnonymousLogin)
                {
                    if (_loc_2 == Anonymous)
                    {
                        break;
                    }
                    continue;
                }
                if (_loc_2 != Anonymous && _loc_2 != null)
                {
                    break;
                }
            }
            if (!_loc_2)
            {
                dispatchError("SASL missing", "The server is not configured to support any available SASL mechanisms", "SASL", -1);
            }
            else
            {
                auth = new _loc_2(this);
            }
            return;
        }// end function

        protected function dispatchError(param1:String, param2:String, param3:String, param4:int, param5:Extension = null) : void
        {
            var _loc_6:* = new XIFFErrorEvent();
            new XIFFErrorEvent().errorCondition = param1;
            _loc_6.errorMessage = param2;
            _loc_6.errorType = param3;
            _loc_6.errorCode = param4;
            _loc_6.errorExt = param5;
            dispatchEvent(_loc_6);
            return;
        }// end function

        public function set domain(param1:String) : void
        {
            _domain = param1;
            return;
        }// end function

        public function set username(param1:String) : void
        {
            _username = param1;
            return;
        }// end function

        protected function socketDataReceived(event:ProgressEvent) : void
        {
            var _loc_2:* = new ByteArray();
            socket.readBytes(_loc_2);
            parseDataReceived(_loc_2);
            return;
        }// end function

        protected function handleMessage(param1:XMLNode) : Message
        {
            var _loc_3:Array = null;
            var _loc_4:MessageEvent = null;
            var _loc_2:* = new Message();
            if (!_loc_2.deserialize(param1))
            {
                throw new SerializationException();
            }
            if (_loc_2.type == Message.TYPE_ERROR && _loc_2.errorCondition != "item-not-found" && _loc_2.errorCondition != "not-acceptable")
            {
                _loc_3 = _loc_2.getAllExtensions();
                dispatchError(_loc_2.errorCondition, _loc_2.errorMessage, _loc_2.errorType, _loc_2.errorCode, _loc_3.length > 0 ? (_loc_3[0]) : (null));
            }
            else
            {
                _loc_4 = new MessageEvent();
                _loc_4.data = _loc_2;
                dispatchEvent(_loc_4);
            }
            return _loc_2;
        }// end function

        protected function handleAuthentication(param1:XMLNode) : void
        {
            var _loc_2:* = auth.handleResponse(0, XML(param1.toString()));
            if (_loc_2.authComplete)
            {
                if (_loc_2.authSuccess)
                {
                    loggedIn = true;
                    restartStream();
                }
                else
                {
                    dispatchError("Authentication Error", "", "", 401);
                    disconnect();
                }
            }
            return;
        }// end function

        protected function onIOError(event:IOErrorEvent) : void
        {
            dispatchError("service-unavailable", "Service Unavailable", "cancel", 503);
            return;
        }// end function

        public function getRegistrationFields() : void
        {
            var _loc_1:* = new IQ(new EscapedJID(domain), IQ.TYPE_GET, XMPPStanza.generateID("reg_info_"), getRegistrationFields_result);
            _loc_1.addExtension(new RegisterExtension(_loc_1.getNode()));
            send(_loc_1);
            return;
        }// end function

        public function get domain() : String
        {
            if (!_domain)
            {
                return _server;
            }
            return _domain;
        }// end function

        public function set useAnonymousLogin(param1:Boolean) : void
        {
            if (!isActive())
            {
                _useAnonymousLogin = param1;
            }
            return;
        }// end function

        protected function socketClosed(event:Event) : void
        {
            active = false;
            loggedIn = false;
            var _loc_2:* = new DisconnectionEvent();
            dispatchEvent(_loc_2);
            return;
        }// end function

        protected function handleStream(param1:XMLNode) : void
        {
            var _loc_2:XMLNode = null;
            sessionID = param1.attributes.id;
            domain = param1.attributes.from;
            for each (_loc_2 in param1.childNodes)
            {
                
                if (_loc_2.nodeName == "stream:features")
                {
                    handleStreamFeatures(_loc_2);
                }
            }
            return;
        }// end function

        public function isActive() : Boolean
        {
            return active;
        }// end function

        private function handleSessionResponse(param1:IQ) : void
        {
            dispatchEvent(new LoginEvent());
            return;
        }// end function

        public function set compress(param1:Boolean) : void
        {
            _compress = param1;
            return;
        }// end function

        protected function socketConnected(event:Event) : void
        {
            active = true;
            sendXML(openingStreamTag);
            var _loc_2:* = new ConnectionSuccessEvent();
            dispatchEvent(_loc_2);
            return;
        }// end function

        public function get ignoreWhiteSpace() : Boolean
        {
            return _ignoreWhitespace;
        }// end function

        public function get queuePresences() : Boolean
        {
            return _queuePresences;
        }// end function

        public function get username() : String
        {
            return _username;
        }// end function

        protected function handleBindResponse(param1:IQ) : void
        {
            var _loc_2:* = param1.getExtension("bind") as BindExtension;
            var _loc_3:* = _loc_2.jid.unescaped;
            _resource = _loc_3.resource;
            _username = _loc_3.node;
            _domain = _loc_3.domain;
            establishSession();
            return;
        }// end function

        public function connect(param1:uint = 0) : Boolean
        {
            createSocket();
            _streamType = param1;
            active = false;
            loggedIn = false;
            chooseStreamTags(param1);
            socket.connect(server, port);
            return true;
        }// end function

        public function get incomingBytes() : uint
        {
            return _incomingBytes;
        }// end function

        protected function bindConnection() : void
        {
            var _loc_1:* = new IQ(null, IQ.TYPE_SET);
            var _loc_2:* = new BindExtension();
            if (resource)
            {
                _loc_2.resource = resource;
            }
            _loc_1.addExtension(_loc_2);
            _loc_1.callback = handleBindResponse;
            _loc_1.errorCallback = handleBindError;
            send(_loc_1);
            return;
        }// end function

        protected function parseDataReceived(param1:ByteArray) : void
        {
            var data:String;
            var pattern:RegExp;
            var resultObj:Object;
            var pattern2:RegExp;
            var resultObj2:Object;
            var isComplete:Boolean;
            var incomingEvent:IncomingDataEvent;
            var len:uint;
            var i:int;
            var currentNode:XMLNode;
            var bytedata:* = param1;
            _incomingBytes = _incomingBytes + bytedata.length;
            if (compressionNegotiated)
            {
                bytedata.uncompress();
            }
            bytedata.position = 0;
            data = bytedata.readUTFBytes(bytedata.length);
            var rawXML:* = _incompleteRawXML + data;
            var rawData:* = new ByteArray();
            rawData.writeUTFBytes(rawXML);
            if (!_expireTagSearch)
            {
                pattern = new RegExp("<flash:stream");
                resultObj = pattern.exec(rawXML);
                if (resultObj != null)
                {
                    rawXML = rawXML.concat("</flash:stream>");
                    _expireTagSearch = true;
                }
            }
            if (!_expireTagSearch)
            {
                pattern2 = new RegExp("<stream:stream");
                resultObj2 = pattern2.exec(rawXML);
                if (resultObj2 != null)
                {
                    rawXML = rawXML.concat("</stream:stream>");
                    _expireTagSearch = true;
                }
            }
            var xmlData:* = new XMLDocument();
            xmlData.ignoreWhite = _ignoreWhitespace;
            try
            {
                isComplete;
                xmlData.parseXML(rawXML);
                _incompleteRawXML = "";
            }
            catch (err:Error)
            {
                isComplete;
                _incompleteRawXML = _incompleteRawXML + data;
            }
            if (isComplete)
            {
                incomingEvent = new IncomingDataEvent();
                incomingEvent.data = rawData;
                dispatchEvent(incomingEvent);
                len = xmlData.childNodes.length;
                i;
                while (i < len)
                {
                    
                    currentNode = xmlData.childNodes[i];
                    handleNodeType(currentNode);
                    i = (i + 1);
                }
            }
            return;
        }// end function

        public static function get openConnections() : Array
        {
            return _openConnections;
        }// end function

        public static function registerSASLMechanism(param1:String, param2:Class) : void
        {
            saslMechanisms[param1] = param2;
            return;
        }// end function

        public static function disableSASLMechanism(param1:String) : void
        {
            saslMechanisms[param1] = null;
            return;
        }// end function

    }
}
