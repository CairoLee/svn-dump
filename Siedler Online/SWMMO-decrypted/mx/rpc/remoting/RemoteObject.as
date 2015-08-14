package mx.rpc.remoting
{
    import mx.messaging.*;
    import mx.messaging.channels.*;
    import mx.rpc.*;
    import mx.rpc.mxml.*;

    dynamic public class RemoteObject extends AbstractService
    {
        public var convertResultHandler:Function;
        private var _endpoint:String;
        public var convertParametersHandler:Function;
        private var _concurrency:String;
        private var _showBusyCursor:Boolean;
        private var _source:String;
        private var _makeObjectsBindable:Boolean;

        public function RemoteObject(param1:String = null)
        {
            super(param1);
            concurrency = Concurrency.MULTIPLE;
            makeObjectsBindable = true;
            showBusyCursor = false;
            return;
        }// end function

        function initEndpoint() : void
        {
            var _loc_1:Channel = null;
            if (endpoint != null)
            {
                if (endpoint.indexOf("https") == 0)
                {
                    _loc_1 = new SecureAMFChannel(null, endpoint);
                }
                else
                {
                    _loc_1 = new AMFChannel(null, endpoint);
                }
                channelSet = new ChannelSet();
                channelSet.addChannel(_loc_1);
            }
            return;
        }// end function

        public function set makeObjectsBindable(param1:Boolean) : void
        {
            _makeObjectsBindable = param1;
            return;
        }// end function

        public function get showBusyCursor() : Boolean
        {
            return _showBusyCursor;
        }// end function

        public function get concurrency() : String
        {
            return _concurrency;
        }// end function

        public function get endpoint() : String
        {
            return _endpoint;
        }// end function

        public function set showBusyCursor(param1:Boolean) : void
        {
            _showBusyCursor = param1;
            return;
        }// end function

        public function get source() : String
        {
            return _source;
        }// end function

        override public function setRemoteCredentials(param1:String, param2:String, param3:String = null) : void
        {
            super.setRemoteCredentials(param1, param2, param3);
            return;
        }// end function

        public function set concurrency(param1:String) : void
        {
            _concurrency = param1;
            return;
        }// end function

        public function set endpoint(param1:String) : void
        {
            if (_endpoint != param1 || param1 == null)
            {
                _endpoint = param1;
                channelSet = null;
            }
            return;
        }// end function

        public function toString() : String
        {
            var _loc_1:String = "[RemoteObject ";
            _loc_1 = _loc_1 + (" destination=\"" + destination + "\"");
            if (source)
            {
                _loc_1 = _loc_1 + (" source=\"" + source + "\"");
            }
            _loc_1 = _loc_1 + (" channelSet=\"" + channelSet + "\"]");
            return _loc_1;
        }// end function

        override public function getOperation(param1:String) : AbstractOperation
        {
            var _loc_2:* = super.getOperation(param1);
            if (_loc_2 == null)
            {
                _loc_2 = new Operation(this, param1);
                _operations[param1] = _loc_2;
                _loc_2.asyncRequest = asyncRequest;
            }
            return _loc_2;
        }// end function

        public function set source(param1:String) : void
        {
            _source = param1;
            return;
        }// end function

        public function get makeObjectsBindable() : Boolean
        {
            return _makeObjectsBindable;
        }// end function

    }
}
