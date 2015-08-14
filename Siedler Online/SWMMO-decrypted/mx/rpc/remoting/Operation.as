package mx.rpc.remoting
{
    import mx.managers.*;
    import mx.messaging.events.*;
    import mx.messaging.messages.*;
    import mx.resources.*;
    import mx.rpc.*;
    import mx.rpc.events.*;
    import mx.rpc.mxml.*;

    public class Operation extends AbstractOperation
    {
        private var _makeObjectsBindableSet:Boolean;
        public var argumentNames:Array;
        private var _concurrency:String;
        var remoteObject:RemoteObject;
        private var _concurrencySet:Boolean;
        private var _showBusyCursor:Boolean;
        private var _showBusyCursorSet:Boolean;
        private var resourceManager:IResourceManager;

        public function Operation(param1:AbstractService = null, param2:String = null)
        {
            resourceManager = ResourceManager.getInstance();
            super(param1, param2);
            argumentNames = [];
            this.remoteObject = RemoteObject(param1);
            return;
        }// end function

        override public function cancel(param1:String = null) : AsyncToken
        {
            if (showBusyCursor)
            {
                CursorManager.removeBusyCursor();
            }
            return super.cancel(param1);
        }// end function

        override public function send(... args) : AsyncToken
        {
            var _loc_3:AsyncToken = null;
            var _loc_4:String = null;
            var _loc_5:Fault = null;
            var _loc_6:FaultEvent = null;
            var _loc_7:int = 0;
            if (service != null)
            {
                service.initialize();
            }
            if (remoteObject.convertParametersHandler != null)
            {
                args = remoteObject.convertParametersHandler(args);
            }
            if (operationManager != null)
            {
                return operationManager(args);
            }
            if (Concurrency.SINGLE == concurrency && activeCalls.hasActiveCalls())
            {
                _loc_3 = new AsyncToken(null);
                _loc_4 = resourceManager.getString("rpc", "pendingCallExists");
                _loc_5 = new Fault("ConcurrencyError", _loc_4);
                _loc_6 = FaultEvent.createEvent(_loc_5, _loc_3);
                new AsyncDispatcher(dispatchRpcEvent, [_loc_6], 10);
                return _loc_3;
            }
            if (asyncRequest.channelSet == null && remoteObject.endpoint != null)
            {
                remoteObject.initEndpoint();
            }
            if (!args || args.length == 0 && this.arguments)
            {
                if (this.arguments is Array)
                {
                    args = this.arguments as Array;
                }
                else
                {
                    args = [];
                    _loc_7 = 0;
                    while (_loc_7 < argumentNames.length)
                    {
                        
                        args[_loc_7] = this.arguments[argumentNames[_loc_7]];
                        _loc_7++;
                    }
                }
            }
            args = new RemotingMessage();
            args.operation = name;
            args.body = args;
            args.source = RemoteObject(service).source;
            return invoke(args);
        }// end function

        public function get showBusyCursor() : Boolean
        {
            if (_showBusyCursorSet)
            {
                return _showBusyCursor;
            }
            return remoteObject.showBusyCursor;
        }// end function

        public function get concurrency() : String
        {
            if (_concurrencySet)
            {
                return _concurrency;
            }
            return remoteObject.concurrency;
        }// end function

        public function set showBusyCursor(param1:Boolean) : void
        {
            _showBusyCursor = param1;
            _showBusyCursorSet = true;
            return;
        }// end function

        public function set concurrency(param1:String) : void
        {
            _concurrency = param1;
            _concurrencySet = true;
            return;
        }// end function

        override function preHandle(event:MessageEvent) : AsyncToken
        {
            if (showBusyCursor)
            {
                CursorManager.removeBusyCursor();
            }
            var _loc_2:* = activeCalls.wasLastCall(AsyncMessage(event.message).correlationId);
            var _loc_3:* = super.preHandle(event);
            if (Concurrency.LAST == concurrency && !_loc_2)
            {
                return null;
            }
            return _loc_3;
        }// end function

        override function processResult(param1:IMessage, param2:AsyncToken) : Boolean
        {
            if (super.processResult(param1, param2))
            {
                if (remoteObject.convertResultHandler != null)
                {
                    _result = remoteObject.convertResultHandler(_result, this);
                }
                return true;
            }
            return false;
        }// end function

        override function setService(param1:AbstractService) : void
        {
            super.setService(param1);
            remoteObject = RemoteObject(param1);
            return;
        }// end function

        override function invoke(param1:IMessage, param2:AsyncToken = null) : AsyncToken
        {
            if (showBusyCursor)
            {
                CursorManager.setBusyCursor();
            }
            return super.invoke(param1, param2);
        }// end function

        override public function set makeObjectsBindable(param1:Boolean) : void
        {
            _makeObjectsBindable = param1;
            _makeObjectsBindableSet = true;
            return;
        }// end function

        override public function get makeObjectsBindable() : Boolean
        {
            if (_makeObjectsBindableSet)
            {
                return _makeObjectsBindable;
            }
            return RemoteObject(service).makeObjectsBindable;
        }// end function

    }
}
