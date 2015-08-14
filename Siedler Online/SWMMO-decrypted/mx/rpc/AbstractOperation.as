package mx.rpc
{
    import mx.resources.*;
    import mx.rpc.events.*;

    public class AbstractOperation extends AbstractInvoker
    {
        var _service:AbstractService;
        private var _name:String;
        public var properties:Object;
        public var arguments:Object;
        private var resourceManager:IResourceManager;

        public function AbstractOperation(param1:AbstractService = null, param2:String = null)
        {
            resourceManager = ResourceManager.getInstance();
            _service = param1;
            _name = param2;
            this.arguments = {};
            return;
        }// end function

        public function send(... args) : AsyncToken
        {
            return null;
        }// end function

        public function get name() : String
        {
            return _name;
        }// end function

        override function dispatchRpcEvent(event:AbstractEvent) : void
        {
            event.callTokenResponders();
            if (!event.isDefaultPrevented())
            {
                if (hasEventListener(event.type))
                {
                    dispatchEvent(event);
                }
                else if (_service != null)
                {
                    _service.dispatchEvent(event);
                }
            }
            return;
        }// end function

        function setService(param1:AbstractService) : void
        {
            var _loc_2:String = null;
            if (!_service)
            {
                _service = param1;
            }
            else
            {
                _loc_2 = resourceManager.getString("rpc", "cannotResetService");
                throw new Error(_loc_2);
            }
            return;
        }// end function

        public function get service() : AbstractService
        {
            return _service;
        }// end function

        public function set name(param1:String) : void
        {
            var _loc_2:String = null;
            if (!_name)
            {
                _name = param1;
            }
            else
            {
                _loc_2 = resourceManager.getString("rpc", "cannotResetOperationName");
                throw new Error(_loc_2);
            }
            return;
        }// end function

    }
}
