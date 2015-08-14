package mx.messaging.messages
{
    import flash.utils.*;

    public class CommandMessage extends AsyncMessage
    {
        public var operation:uint;
        public static const SUBSCRIBE_OPERATION:uint = 0;
        public static const MAX_FREQUENCY_HEADER:String = "DSMaxFrequency";
        private static const OPERATION_FLAG:uint = 1;
        public static const CLIENT_SYNC_OPERATION:uint = 4;
        public static const POLL_WAIT_HEADER:String = "DSPollWait";
        public static const ADD_SUBSCRIPTIONS:String = "DSAddSub";
        public static const SUBSCRIPTION_INVALIDATE_OPERATION:uint = 10;
        public static const TRIGGER_CONNECT_OPERATION:uint = 13;
        public static const CLIENT_PING_OPERATION:uint = 5;
        public static const UNSUBSCRIBE_OPERATION:uint = 1;
        private static var operationTexts:Object = null;
        public static const CREDENTIALS_CHARSET_HEADER:String = "DSCredentialsCharset";
        public static const AUTHENTICATION_MESSAGE_REF_TYPE:String = "flex.messaging.messages.AuthenticationMessage";
        public static const POLL_OPERATION:uint = 2;
        public static const MULTI_SUBSCRIBE_OPERATION:uint = 11;
        public static const LOGIN_OPERATION:uint = 8;
        public static const CLUSTER_REQUEST_OPERATION:uint = 7;
        public static const HEARTBEAT_HEADER:String = "DS<3";
        public static const LOGOUT_OPERATION:uint = 9;
        public static const REMOVE_SUBSCRIPTIONS:String = "DSRemSub";
        public static const MESSAGING_VERSION:String = "DSMessagingVersion";
        public static const NEEDS_CONFIG_HEADER:String = "DSNeedsConfig";
        public static const SELECTOR_HEADER:String = "DSSelector";
        public static const UNKNOWN_OPERATION:uint = 10000;
        public static const PRESERVE_DURABLE_HEADER:String = "DSPreserveDurable";
        public static const NO_OP_POLL_HEADER:String = "DSNoOpPoll";
        public static const SUBTOPIC_SEPARATOR:String = "_;_";
        public static const DISCONNECT_OPERATION:uint = 12;

        public function CommandMessage()
        {
            operation = UNKNOWN_OPERATION;
            return;
        }// end function

        override public function readExternal(param1:IDataInput) : void
        {
            var _loc_4:uint = 0;
            var _loc_5:uint = 0;
            var _loc_6:uint = 0;
            super.readExternal(param1);
            var _loc_2:* = readFlags(param1);
            var _loc_3:uint = 0;
            while (_loc_3 < _loc_2.length)
            {
                
                _loc_4 = _loc_2[_loc_3] as uint;
                _loc_5 = 0;
                if (_loc_3 == 0)
                {
                    if ((_loc_4 & OPERATION_FLAG) != 0)
                    {
                        operation = param1.readObject() as uint;
                    }
                    _loc_5 = 1;
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

        override protected function addDebugAttributes(param1:Object) : void
        {
            super.addDebugAttributes(param1);
            param1["operation"] = getOperationAsString(operation);
            return;
        }// end function

        override public function writeExternal(param1:IDataOutput) : void
        {
            super.writeExternal(param1);
            var _loc_2:uint = 0;
            if (operation != 0)
            {
                _loc_2 = _loc_2 | OPERATION_FLAG;
            }
            param1.writeByte(_loc_2);
            if (operation != 0)
            {
                param1.writeObject(operation);
            }
            return;
        }// end function

        override public function toString() : String
        {
            return getDebugString();
        }// end function

        override public function getSmallMessage() : IMessage
        {
            if (operation == POLL_OPERATION)
            {
                return new CommandMessageExt(this);
            }
            return null;
        }// end function

        public static function getOperationAsString(param1:uint) : String
        {
            if (operationTexts == null)
            {
                operationTexts = {};
                operationTexts[SUBSCRIBE_OPERATION] = "subscribe";
                operationTexts[UNSUBSCRIBE_OPERATION] = "unsubscribe";
                operationTexts[POLL_OPERATION] = "poll";
                operationTexts[CLIENT_SYNC_OPERATION] = "client sync";
                operationTexts[CLIENT_PING_OPERATION] = "client ping";
                operationTexts[CLUSTER_REQUEST_OPERATION] = "cluster request";
                operationTexts[LOGIN_OPERATION] = "login";
                operationTexts[LOGOUT_OPERATION] = "logout";
                operationTexts[SUBSCRIPTION_INVALIDATE_OPERATION] = "subscription invalidate";
                operationTexts[MULTI_SUBSCRIBE_OPERATION] = "multi-subscribe";
                operationTexts[DISCONNECT_OPERATION] = "disconnect";
                operationTexts[TRIGGER_CONNECT_OPERATION] = "trigger connect";
                operationTexts[UNKNOWN_OPERATION] = "unknown";
            }
            var _loc_2:* = operationTexts[param1];
            return _loc_2 == undefined ? (param1.toString()) : (String(_loc_2));
        }// end function

    }
}
