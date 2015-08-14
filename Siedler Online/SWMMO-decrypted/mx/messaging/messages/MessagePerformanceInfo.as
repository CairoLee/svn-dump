package mx.messaging.messages
{

    public class MessagePerformanceInfo extends Object
    {
        public var recordMessageSizes:Boolean;
        public var pushedFlag:Boolean;
        public var serverPrePushTime:Number;
        public var receiveTime:Number;
        public var overheadTime:Number;
        public var serverPostAdapterExternalTime:Number;
        private var _infoType:String;
        public var messageSize:int;
        public var serverPreAdapterExternalTime:Number;
        public var recordMessageTimes:Boolean;
        public var sendTime:Number = 0;
        public var serverPostAdapterTime:Number;
        public var serverPreAdapterTime:Number;

        public function MessagePerformanceInfo()
        {
            return;
        }// end function

        public function get infoType() : String
        {
            return this._infoType;
        }// end function

        public function set infoType(param1:String) : void
        {
            var _loc_2:Date = null;
            _infoType = param1;
            if (_infoType == "OUT")
            {
                _loc_2 = new Date();
                this.receiveTime = _loc_2.getTime();
            }
            return;
        }// end function

    }
}
