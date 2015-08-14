package mx.binding
{
    import flash.events.*;
    import mx.core.*;

    public class FunctionReturnWatcher extends Watcher
    {
        private var parameterFunction:Function;
        private var functionName:String;
        private var functionGetter:Function;
        public var parentWatcher:Watcher;
        private var parentObj:Object;
        private var events:Object;
        private var document:Object;
        static const VERSION:String = "3.5.0.12683";

        public function FunctionReturnWatcher(param1:String, param2:Object, param3:Function, param4:Object, param5:Array, param6:Function = null)
        {
            super(param5);
            this.functionName = param1;
            this.document = param2;
            this.parameterFunction = param3;
            this.events = param4;
            this.functionGetter = param6;
            return;
        }// end function

        override protected function shallowClone() : Watcher
        {
            var _loc_1:* = new FunctionReturnWatcher(functionName, document, parameterFunction, events, listeners, functionGetter);
            return _loc_1;
        }// end function

        override public function updateParent(param1:Object) : void
        {
            if (!(param1 is Watcher))
            {
                setupParentObj(param1);
            }
            else if (param1 == parentWatcher)
            {
                setupParentObj(parentWatcher.value);
            }
            updateFunctionReturn();
            return;
        }// end function

        private function setupParentObj(param1:Object) : void
        {
            var _loc_2:IEventDispatcher = null;
            var _loc_3:String = null;
            if (parentObj != null && parentObj is IEventDispatcher && events != null)
            {
                _loc_2 = parentObj as IEventDispatcher;
                for (_loc_3 in events)
                {
                    
                    _loc_2.removeEventListener(_loc_3, eventHandler);
                }
            }
            parentObj = param1;
            if (parentObj != null && parentObj is IEventDispatcher && events != null)
            {
                _loc_2 = parentObj as IEventDispatcher;
                for (_loc_3 in events)
                {
                    
                    if (_loc_3 != "__NoChangeEvent__")
                    {
                        _loc_2.addEventListener(_loc_3, eventHandler, false, EventPriority.BINDING, true);
                    }
                }
            }
            return;
        }// end function

        public function updateFunctionReturn() : void
        {
            wrapUpdate(function () : void
            {
                if (null != null)
                {
                    value = functionGetter(functionName).apply(parentObj, parameterFunction.apply(document));
                }
                else
                {
                    value = parentObj[functionName].apply(parentObj, parameterFunction.apply(document));
                }
                updateChildren();
                return;
            }// end function
            );
            return;
        }// end function

        public function eventHandler(event:Event) : void
        {
            updateFunctionReturn();
            notifyListeners(events[event.type]);
            return;
        }// end function

    }
}
