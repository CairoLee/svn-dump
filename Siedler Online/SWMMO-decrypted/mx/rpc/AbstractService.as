package mx.rpc
{
    import flash.events.*;
    import flash.utils.*;
    import mx.messaging.*;
    import mx.resources.*;
    import mx.rpc.events.*;

    dynamic public class AbstractService extends Proxy implements IEventDispatcher
    {
        var _operations:Object;
        private var _initialized:Boolean = false;
        var _availableChannelIds:Array;
        private var resourceManager:IResourceManager;
        private var _managers:Array;
        private var nextNameArray:Array;
        private var eventDispatcher:EventDispatcher;
        var asyncRequest:AsyncRequest;

        public function AbstractService(param1:String = null)
        {
            resourceManager = ResourceManager.getInstance();
            eventDispatcher = new EventDispatcher(this);
            asyncRequest = new AsyncRequest();
            if (param1)
            {
                this.destination = param1;
                asyncRequest.destination = param1;
            }
            _operations = {};
            return;
        }// end function

        public function willTrigger(param1:String) : Boolean
        {
            return eventDispatcher.willTrigger(param1);
        }// end function

        public function get destination() : String
        {
            return asyncRequest.destination;
        }// end function

        public function initialize() : void
        {
            var _loc_1:int = 0;
            var _loc_2:Object = null;
            if (!_initialized && _managers != null)
            {
                _loc_1 = 0;
                while (_loc_1 < _managers.length)
                {
                    
                    _loc_2 = _managers[_loc_1];
                    if (_loc_2.hasOwnProperty("initialize"))
                    {
                        _loc_2.initialize();
                    }
                    _loc_1++;
                }
                _initialized = true;
            }
            return;
        }// end function

        public function logout() : void
        {
            asyncRequest.logout();
            return;
        }// end function

        public function setRemoteCredentials(param1:String, param2:String, param3:String = null) : void
        {
            asyncRequest.setRemoteCredentials(param1, param2, param3);
            return;
        }// end function

        function hasTokenResponders(event:Event) : Boolean
        {
            var _loc_2:AbstractEvent = null;
            if (event is AbstractEvent)
            {
                _loc_2 = event as AbstractEvent;
                if (_loc_2.token != null && _loc_2.token.hasResponder())
                {
                    return true;
                }
            }
            return false;
        }// end function

        public function disconnect() : void
        {
            asyncRequest.disconnect();
            return;
        }// end function

        override function nextName(param1:int) : String
        {
            return nextNameArray[(param1 - 1)];
        }// end function

        public function set destination(param1:String) : void
        {
            asyncRequest.destination = param1;
            return;
        }// end function

        public function set requestTimeout(param1:int) : void
        {
            if (requestTimeout != param1)
            {
                asyncRequest.requestTimeout = param1;
            }
            return;
        }// end function

        public function valueOf() : Object
        {
            return this;
        }// end function

        public function getOperation(param1:String) : AbstractOperation
        {
            var _loc_2:* = _operations[param1];
            var _loc_3:* = _loc_2 is AbstractOperation ? (AbstractOperation(_loc_2)) : (null);
            return _loc_3;
        }// end function

        public function setCredentials(param1:String, param2:String, param3:String = null) : void
        {
            asyncRequest.setCredentials(param1, param2, param3);
            return;
        }// end function

        public function set channelSet(param1:ChannelSet) : void
        {
            if (channelSet != param1)
            {
                asyncRequest.channelSet = param1;
            }
            return;
        }// end function

        public function dispatchEvent(event:Event) : Boolean
        {
            return eventDispatcher.dispatchEvent(event);
        }// end function

        public function removeEventListener(param1:String, param2:Function, param3:Boolean = false) : void
        {
            eventDispatcher.removeEventListener(param1, param2, param3);
            return;
        }// end function

        override function getProperty(param1)
        {
            return getOperation(getLocalName(param1));
        }// end function

        public function set managers(param1:Array) : void
        {
            var _loc_2:int = 0;
            var _loc_3:Object = null;
            if (_managers != null)
            {
                _loc_2 = 0;
                while (_loc_2 < _managers.length)
                {
                    
                    _loc_3 = _managers[_loc_2];
                    if (_loc_3.hasOwnProperty("service"))
                    {
                        _loc_3.service = null;
                    }
                    _loc_2++;
                }
            }
            _managers = param1;
            _loc_2 = 0;
            while (_loc_2 < param1.length)
            {
                
                _loc_3 = _managers[_loc_2];
                if (_loc_3.hasOwnProperty("service"))
                {
                    _loc_3.service = this;
                }
                if (_initialized && _loc_3.hasOwnProperty("initialize"))
                {
                    _loc_3.initialize();
                }
                _loc_2++;
            }
            return;
        }// end function

        public function get requestTimeout() : int
        {
            return asyncRequest.requestTimeout;
        }// end function

        override function callProperty(param1, ... args)
        {
            return getOperation(getLocalName(param1)).send.apply(null, args);
        }// end function

        public function addEventListener(param1:String, param2:Function, param3:Boolean = false, param4:int = 0, param5:Boolean = false) : void
        {
            eventDispatcher.addEventListener(param1, param2, param3, param4, param5);
            return;
        }// end function

        override function nextValue(param1:int)
        {
            return _operations[nextNameArray[(param1 - 1)]];
        }// end function

        override function setProperty(param1, param2) : void
        {
            var _loc_3:* = resourceManager.getString("rpc", "operationsNotAllowedInService", [getLocalName(param1)]);
            throw new Error(_loc_3);
        }// end function

        public function set operations(param1:Object) : void
        {
            var _loc_2:AbstractOperation = null;
            var _loc_3:String = null;
            for (_loc_3 in param1)
            {
                
                _loc_2 = AbstractOperation(param1[_loc_3]);
                _loc_2.setService(this);
                if (!_loc_2.name)
                {
                    _loc_2.name = _loc_3;
                }
                _loc_2.asyncRequest = asyncRequest;
            }
            _operations = param1;
            dispatchEvent(new Event("operationsChange"));
            return;
        }// end function

        public function get channelSet() : ChannelSet
        {
            return asyncRequest.channelSet;
        }// end function

        function getLocalName(param1:Object) : String
        {
            if (param1 is QName)
            {
                return QName(param1).localName;
            }
            return String(param1);
        }// end function

        override function nextNameIndex(param1:int) : int
        {
            var _loc_2:String = null;
            if (param1 == 0)
            {
                nextNameArray = [];
                for (_loc_2 in _operations)
                {
                    
                    nextNameArray.push(_loc_2);
                }
            }
            return param1 < nextNameArray.length ? ((param1 + 1)) : (0);
        }// end function

        public function get managers() : Array
        {
            return _managers;
        }// end function

        public function get operations() : Object
        {
            return _operations;
        }// end function

        public function hasEventListener(param1:String) : Boolean
        {
            return eventDispatcher.hasEventListener(param1);
        }// end function

    }
}
