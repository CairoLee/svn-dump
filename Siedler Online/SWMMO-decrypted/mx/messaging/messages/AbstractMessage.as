package mx.messaging.messages
{
    import flash.utils.*;
    import mx.messaging.messages.*;
    import mx.utils.*;

    public class AbstractMessage extends Object implements IMessage
    {
        private var _body:Object;
        private var _messageId:String;
        private var messageIdBytes:ByteArray;
        private var _timestamp:Number = 0;
        private var _clientId:String;
        private var clientIdBytes:ByteArray;
        private var _headers:Object;
        private var _destination:String = "";
        private var _timeToLive:Number = 0;
        public static const FLEX_CLIENT_ID_HEADER:String = "DSId";
        private static const MESSAGE_ID_FLAG:uint = 16;
        public static const PRIORITY_HEADER:String = "DSPriority";
        private static const TIME_TO_LIVE_FLAG:uint = 64;
        private static const TIMESTAMP_FLAG:uint = 32;
        private static const CLIENT_ID_BYTES_FLAG:uint = 1;
        public static const REQUEST_TIMEOUT_HEADER:String = "DSRequestTimeout";
        private static const DESTINATION_FLAG:uint = 4;
        public static const STATUS_CODE_HEADER:String = "DSStatusCode";
        private static const CLIENT_ID_FLAG:uint = 2;
        private static const HEADERS_FLAG:uint = 8;
        private static const BODY_FLAG:uint = 1;
        public static const REMOTE_CREDENTIALS_CHARSET_HEADER:String = "DSRemoteCredentialsCharset";
        private static const MESSAGE_ID_BYTES_FLAG:uint = 2;
        public static const DESTINATION_CLIENT_ID_HEADER:String = "DSDstClientId";
        public static const REMOTE_CREDENTIALS_HEADER:String = "DSRemoteCredentials";
        private static const HAS_NEXT_FLAG:uint = 128;
        public static const ENDPOINT_HEADER:String = "DSEndpoint";

        public function AbstractMessage()
        {
            _body = {};
            return;
        }// end function

        public function set messageId(param1:String) : void
        {
            _messageId = param1;
            messageIdBytes = null;
            return;
        }// end function

        public function get headers() : Object
        {
            if (_headers == null)
            {
                _headers = {};
            }
            return _headers;
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            var _loc_4:uint = 0;
            var _loc_5:uint = 0;
            var _loc_6:uint = 0;
            var _loc_2:* = readFlags(param1);
            var _loc_3:uint = 0;
            while (_loc_3 < _loc_2.length)
            {
                
                _loc_4 = _loc_2[_loc_3] as uint;
                _loc_5 = 0;
                if (_loc_3 == 0)
                {
                    if ((_loc_4 & BODY_FLAG) != 0)
                    {
                        body = param1.readObject();
                    }
                    else
                    {
                        body = null;
                    }
                    if ((_loc_4 & CLIENT_ID_FLAG) != 0)
                    {
                        clientId = param1.readObject();
                    }
                    if ((_loc_4 & DESTINATION_FLAG) != 0)
                    {
                        destination = param1.readObject() as String;
                    }
                    if ((_loc_4 & HEADERS_FLAG) != 0)
                    {
                        headers = param1.readObject();
                    }
                    if ((_loc_4 & MESSAGE_ID_FLAG) != 0)
                    {
                        messageId = param1.readObject() as String;
                    }
                    if ((_loc_4 & TIMESTAMP_FLAG) != 0)
                    {
                        timestamp = param1.readObject() as Number;
                    }
                    if ((_loc_4 & TIME_TO_LIVE_FLAG) != 0)
                    {
                        timeToLive = param1.readObject() as Number;
                    }
                    _loc_5 = 7;
                }
                else if (_loc_3 == 1)
                {
                    if ((_loc_4 & CLIENT_ID_BYTES_FLAG) != 0)
                    {
                        clientIdBytes = param1.readObject() as ByteArray;
                        clientId = RPCUIDUtil.fromByteArray(clientIdBytes);
                    }
                    if ((_loc_4 & MESSAGE_ID_BYTES_FLAG) != 0)
                    {
                        messageIdBytes = param1.readObject() as ByteArray;
                        messageId = RPCUIDUtil.fromByteArray(messageIdBytes);
                    }
                    _loc_5 = 2;
                }
                if (_loc_4 >> _loc_5 != 0)
                {
                    _loc_6 = _loc_5;
                    while (_loc_6 < 6)
                    {
                        
                        if ((_loc_4 >> _loc_6 & 1) != 0)
                        {
                            param1.readObject();
                        }
                        _loc_6 = _loc_6 + 1;
                    }
                }
                _loc_3 = _loc_3 + 1;
            }
            return;
        }// end function

        public function get messageId() : String
        {
            if (_messageId == null)
            {
                _messageId = RPCUIDUtil.createUID();
            }
            return _messageId;
        }// end function

        public function set clientId(param1:String) : void
        {
            _clientId = param1;
            clientIdBytes = null;
            return;
        }// end function

        public function get destination() : String
        {
            return _destination;
        }// end function

        public function get timestamp() : Number
        {
            return _timestamp;
        }// end function

        protected function readFlags(param1:IDataInput) : Array
        {
            var _loc_4:uint = 0;
            var _loc_2:Boolean = true;
            var _loc_3:Array = [];
            while (_loc_2 && param1.bytesAvailable > 0)
            {
                
                _loc_4 = param1.readUnsignedByte();
                _loc_3.push(_loc_4);
                if ((_loc_4 & HAS_NEXT_FLAG) != 0)
                {
                    _loc_2 = true;
                    continue;
                }
                _loc_2 = false;
            }
            return _loc_3;
        }// end function

        public function set headers(param1:Object) : void
        {
            _headers = param1;
            return;
        }// end function

        public function get body() : Object
        {
            return _body;
        }// end function

        public function set destination(param1:String) : void
        {
            _destination = param1;
            return;
        }// end function

        public function set timestamp(param1:Number) : void
        {
            _timestamp = param1;
            return;
        }// end function

        protected function addDebugAttributes(param1:Object) : void
        {
            param1["body"] = body;
            param1["clientId"] = clientId;
            param1["destination"] = destination;
            param1["headers"] = headers;
            param1["messageId"] = messageId;
            param1["timestamp"] = timestamp;
            param1["timeToLive"] = timeToLive;
            return;
        }// end function

        public function get timeToLive() : Number
        {
            return _timeToLive;
        }// end function

        public function set body(param1:Object) : void
        {
            _body = param1;
            return;
        }// end function

        public function get clientId() : String
        {
            return _clientId;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            var _loc_2:uint = 0;
            var _loc_3:* = messageId;
            if (clientIdBytes == null)
            {
                clientIdBytes = RPCUIDUtil.toByteArray(_clientId);
            }
            if (messageIdBytes == null)
            {
                messageIdBytes = RPCUIDUtil.toByteArray(_messageId);
            }
            if (body != null)
            {
                _loc_2 = _loc_2 | BODY_FLAG;
            }
            if (clientId != null && clientIdBytes == null)
            {
                _loc_2 = _loc_2 | CLIENT_ID_FLAG;
            }
            if (destination != null)
            {
                _loc_2 = _loc_2 | DESTINATION_FLAG;
            }
            if (headers != null)
            {
                _loc_2 = _loc_2 | HEADERS_FLAG;
            }
            if (messageId != null && messageIdBytes == null)
            {
                _loc_2 = _loc_2 | MESSAGE_ID_FLAG;
            }
            if (timestamp != 0)
            {
                _loc_2 = _loc_2 | TIMESTAMP_FLAG;
            }
            if (timeToLive != 0)
            {
                _loc_2 = _loc_2 | TIME_TO_LIVE_FLAG;
            }
            if (clientIdBytes != null || messageIdBytes != null)
            {
                _loc_2 = _loc_2 | HAS_NEXT_FLAG;
            }
            param1.writeByte(_loc_2);
            _loc_2 = 0;
            if (clientIdBytes != null)
            {
                _loc_2 = _loc_2 | CLIENT_ID_BYTES_FLAG;
            }
            if (messageIdBytes != null)
            {
                _loc_2 = _loc_2 | MESSAGE_ID_BYTES_FLAG;
            }
            if (_loc_2 != 0)
            {
                param1.writeByte(_loc_2);
            }
            if (body != null)
            {
                param1.writeObject(body);
            }
            if (clientId != null && clientIdBytes == null)
            {
                param1.writeObject(clientId);
            }
            if (destination != null)
            {
                param1.writeObject(destination);
            }
            if (headers != null)
            {
                param1.writeObject(headers);
            }
            if (messageId != null && messageIdBytes == null)
            {
                param1.writeObject(messageId);
            }
            if (timestamp != 0)
            {
                param1.writeObject(timestamp);
            }
            if (timeToLive != 0)
            {
                param1.writeObject(timeToLive);
            }
            if (clientIdBytes != null)
            {
                param1.writeObject(clientIdBytes);
            }
            if (messageIdBytes != null)
            {
                param1.writeObject(messageIdBytes);
            }
            return;
        }// end function

        final protected function getDebugString() : String
        {
            var _loc_4:String = null;
            var _loc_5:uint = 0;
            var _loc_6:String = null;
            var _loc_7:String = null;
            var _loc_1:* = "(" + getQualifiedClassName(this) + ")";
            var _loc_2:Object = {};
            addDebugAttributes(_loc_2);
            var _loc_3:Array = [];
            for (_loc_4 in _loc_2)
            {
                
                _loc_3.push(_loc_4);
            }
            _loc_3.sort();
            _loc_5 = 0;
            while (_loc_5 < _loc_3.length)
            {
                
                _loc_6 = String(_loc_3[_loc_5]);
                _loc_7 = RPCObjectUtil.toString(_loc_2[_loc_6]);
                _loc_1 = _loc_1 + RPCStringUtil.substitute("\n  {0}={1}", _loc_6, _loc_7);
                _loc_5 = _loc_5 + 1;
            }
            return _loc_1;
        }// end function

        public function toString() : String
        {
            return RPCObjectUtil.toString(this);
        }// end function

        public function set timeToLive(param1:Number) : void
        {
            _timeToLive = param1;
            return;
        }// end function

    }
}
