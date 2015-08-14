package mx.rpc
{
    import flash.events.*;
    import flash.utils.*;
    import mx.logging.*;
    import mx.messaging.errors.*;
    import mx.messaging.events.*;
    import mx.messaging.messages.*;
    import mx.netmon.*;
    import mx.resources.*;
    import mx.rpc.events.*;
    import mx.utils.*;

    public class AbstractInvoker extends EventDispatcher
    {
        var _makeObjectsBindable:Boolean;
        public var operationManager:Function;
        var _responseHeaders:Array;
        private var _asyncRequest:AsyncRequest;
        private var _log:ILogger;
        var activeCalls:ActiveCalls;
        public var resultType:Class;
        public var resultElementType:Class;
        var _result:Object;
        private var resourceManager:IResourceManager;
        static const BINDING_RESULT:String = "resultForBinding";

        public function AbstractInvoker()
        {
            resourceManager = ResourceManager.getInstance();
            _log = Log.getLogger("mx.rpc.AbstractInvoker");
            activeCalls = new ActiveCalls();
            return;
        }// end function

        function getNetmonId() : String
        {
            return null;
        }// end function

        public function cancel(param1:String = null) : AsyncToken
        {
            if (param1 != null)
            {
                return activeCalls.removeCall(param1);
            }
            return activeCalls.cancelLast();
        }// end function

        function faultHandler(event:MessageFaultEvent) : void
        {
            var _loc_4:Fault = null;
            var _loc_5:FaultEvent = null;
            var _loc_2:* = MessageEvent.createEvent(MessageEvent.MESSAGE, event.message);
            var _loc_3:* = preHandle(_loc_2);
            if (_loc_3 == null && AsyncMessage(event.message).correlationId != null && AsyncMessage(event.message).correlationId != "" && event.faultCode != "Client.Authentication")
            {
                return;
            }
            if (processFault(event.message, _loc_3))
            {
                _loc_4 = new Fault(event.faultCode, event.faultString, event.faultDetail);
                _loc_4.content = event.message.body;
                _loc_4.rootCause = event.rootCause;
                _loc_5 = FaultEvent.createEvent(_loc_4, _loc_3, event.message);
                _loc_5.headers = _responseHeaders;
                dispatchRpcEvent(_loc_5);
            }
            return;
        }// end function

        public function clearResult(param1:Boolean = true) : void
        {
            if (param1)
            {
                setResult(null);
            }
            else
            {
                _result = null;
            }
            return;
        }// end function

        function get asyncRequest() : AsyncRequest
        {
            if (_asyncRequest == null)
            {
                _asyncRequest = new AsyncRequest();
            }
            return _asyncRequest;
        }// end function

        function dispatchRpcEvent(event:AbstractEvent) : void
        {
            event.callTokenResponders();
            if (!event.isDefaultPrevented())
            {
                dispatchEvent(event);
            }
            return;
        }// end function

        public function get lastResult() : Object
        {
            return _result;
        }// end function

        public function setResult(param1:Object) : void
        {
            _result = param1;
            dispatchEvent(new Event(BINDING_RESULT));
            return;
        }// end function

        function set asyncRequest(param1:AsyncRequest) : void
        {
            _asyncRequest = param1;
            return;
        }// end function

        function preHandle(event:MessageEvent) : AsyncToken
        {
            return activeCalls.removeCall(AsyncMessage(event.message).correlationId);
        }// end function

        function processResult(param1:IMessage, param2:AsyncToken) : Boolean
        {
            var _loc_3:* = param1.body;
            if (makeObjectsBindable && _loc_3 != null && getQualifiedClassName(_loc_3) == "Object")
            {
                _result = new ObjectProxy(_loc_3);
            }
            else
            {
                _result = _loc_3;
            }
            return true;
        }// end function

        function resultHandler(event:MessageEvent) : void
        {
            var _loc_3:ResultEvent = null;
            var _loc_2:* = preHandle(event);
            if (_loc_2 == null)
            {
                return;
            }
            if (processResult(event.message, _loc_2))
            {
                dispatchEvent(new Event(BINDING_RESULT));
                _loc_3 = ResultEvent.createEvent(_result, _loc_2, event.message);
                _loc_3.headers = _responseHeaders;
                dispatchRpcEvent(_loc_3);
            }
            return;
        }// end function

        function monitorRpcEvent(event:AbstractEvent) : void
        {
            if (NetworkMonitor.isMonitoring())
            {
                if (event is ResultEvent)
                {
                    NetworkMonitor.monitorResult(event.message, ResultEvent(event).result);
                }
                else if (event is FaultEvent)
                {
                    NetworkMonitor.monitorFault(event.message, FaultEvent(event).fault);
                }
            }
            return;
        }// end function

        function processFault(param1:IMessage, param2:AsyncToken) : Boolean
        {
            return true;
        }// end function

        function invoke(param1:IMessage, param2:AsyncToken = null) : AsyncToken
        {
            var fault:Fault;
            var errorText:String;
            var message:* = param1;
            var token:* = param2;
            if (token == null)
            {
                token = new AsyncToken(message);
            }
            else
            {
                token.setMessage(message);
            }
            activeCalls.addCall(message.messageId, token);
            try
            {
                asyncRequest.invoke(message, new Responder(resultHandler, faultHandler));
                dispatchRpcEvent(InvokeEvent.createEvent(token, message));
            }
            catch (e:MessagingError)
            {
                _log.warn(e.toString());
                errorText = resourceManager.getString("rpc", "cannotConnectToDestination", [asyncRequest.destination]);
                fault = new Fault("InvokeFailed", e.toString(), errorText);
                new AsyncDispatcher(dispatchRpcEvent, [FaultEvent.createEvent(fault, token, message)], 10);
                ;
            }
            catch (e2:Error)
            {
                _log.warn(e2.toString());
                fault = new Fault("InvokeFailed", e2.message);
                new AsyncDispatcher(dispatchRpcEvent, [FaultEvent.createEvent(fault, token, message)], 10);
            }
            return token;
        }// end function

        public function set makeObjectsBindable(param1:Boolean) : void
        {
            _makeObjectsBindable = param1;
            return;
        }// end function

        public function get makeObjectsBindable() : Boolean
        {
            return _makeObjectsBindable;
        }// end function

    }
}
