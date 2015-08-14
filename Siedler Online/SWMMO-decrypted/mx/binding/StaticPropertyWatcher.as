package mx.binding
{
    import flash.events.*;
    import mx.core.*;
    import mx.events.*;

    public class StaticPropertyWatcher extends Watcher
    {
        private var propertyGetter:Function;
        private var parentObj:Class;
        protected var events:Object;
        private var _propertyName:String;
        static const VERSION:String = "3.5.0.12683";

        public function StaticPropertyWatcher(param1:String, param2:Object, param3:Array, param4:Function = null)
        {
            super(param3);
            _propertyName = param1;
            this.events = param2;
            this.propertyGetter = param4;
            return;
        }// end function

        private function eventNamesToString() : String
        {
            var _loc_2:String = null;
            var _loc_1:String = " ";
            for (_loc_2 in events)
            {
                
                _loc_1 = _loc_1 + (_loc_2 + " ");
            }
            return _loc_1;
        }// end function

        override public function updateParent(param1:Object) : void
        {
            var _loc_2:String = null;
            var _loc_3:IEventDispatcher = null;
            parentObj = Class(param1);
            if (parentObj["staticEventDispatcher"] != null)
            {
                for (_loc_2 in events)
                {
                    
                    if (_loc_2 != "__NoChangeEvent__")
                    {
                        _loc_3 = parentObj["staticEventDispatcher"];
                        _loc_3.addEventListener(_loc_2, eventHandler, false, EventPriority.BINDING, true);
                    }
                }
            }
            wrapUpdate(updateProperty);
            return;
        }// end function

        private function updateProperty() : void
        {
            if (parentObj)
            {
                if (propertyGetter != null)
                {
                    value = propertyGetter.apply(parentObj, [_propertyName]);
                }
                else
                {
                    value = parentObj[_propertyName];
                }
            }
            else
            {
                value = null;
            }
            updateChildren();
            return;
        }// end function

        override protected function shallowClone() : Watcher
        {
            var _loc_1:* = new StaticPropertyWatcher(_propertyName, events, listeners, propertyGetter);
            return _loc_1;
        }// end function

        private function traceInfo() : String
        {
            return "StaticPropertyWatcher(" + parentObj + "." + _propertyName + "): events = [" + eventNamesToString() + "]";
        }// end function

        public function get propertyName() : String
        {
            return _propertyName;
        }// end function

        public function eventHandler(event:Event) : void
        {
            var _loc_2:Object = null;
            if (event is PropertyChangeEvent)
            {
                _loc_2 = PropertyChangeEvent(event).property;
                if (_loc_2 != _propertyName)
                {
                    return;
                }
            }
            wrapUpdate(updateProperty);
            notifyListeners(events[event.type]);
            return;
        }// end function

    }
}
