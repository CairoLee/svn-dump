package mx.messaging.messages
{
    import flash.utils.*;
    import mx.messaging.messages.*;
    import mx.utils.*;

    public class AsyncMessage extends AbstractMessage implements ISmallMessage
    {
        private var _correlationId:String;
        private var correlationIdBytes:ByteArray;
        private static const CORRELATION_ID_FLAG:uint = 1;
        private static const CORRELATION_ID_BYTES_FLAG:uint = 2;
        public static const SUBTOPIC_HEADER:String = "DSSubtopic";

        public function AsyncMessage(param1:Object = null, param2:Object = null)
        {
            correlationId = "";
            if (param1 != null)
            {
                this.body = param1;
            }
            if (param2 != null)
            {
                this.headers = param2;
            }
            return;
        }// end function

        override protected function addDebugAttributes(param1:Object) : void
        {
            super.addDebugAttributes(param1);
            param1["correlationId"] = correlationId;
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
                    if ((_loc_4 & CORRELATION_ID_FLAG) != 0)
                    {
                        correlationId = param1.readObject() as String;
                    }
                    if ((_loc_4 & CORRELATION_ID_BYTES_FLAG) != 0)
                    {
                        correlationIdBytes = param1.readObject() as ByteArray;
                        correlationId = RPCUIDUtil.fromByteArray(correlationIdBytes);
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

        public function getSmallMessage() : IMessage
        {
            var _loc_1:Object = this;
            if (_loc_1.constructor == AsyncMessage)
            {
                return new AsyncMessageExt(this);
            }
            return null;
        }// end function

        override public function writeExternal(param1:IDataOutput) : void
        {
            super.writeExternal(param1);
            if (correlationIdBytes == null)
            {
                correlationIdBytes = RPCUIDUtil.toByteArray(_correlationId);
            }
            var _loc_2:uint = 0;
            if (correlationId != null && correlationIdBytes == null)
            {
                _loc_2 = _loc_2 | CORRELATION_ID_FLAG;
            }
            if (correlationIdBytes != null)
            {
                _loc_2 = _loc_2 | CORRELATION_ID_BYTES_FLAG;
            }
            param1.writeByte(_loc_2);
            if (correlationId != null && correlationIdBytes == null)
            {
                param1.writeObject(correlationId);
            }
            if (correlationIdBytes != null)
            {
                param1.writeObject(correlationIdBytes);
            }
            return;
        }// end function

        public function set correlationId(param1:String) : void
        {
            _correlationId = param1;
            correlationIdBytes = null;
            return;
        }// end function

        public function get correlationId() : String
        {
            return _correlationId;
        }// end function

    }
}
