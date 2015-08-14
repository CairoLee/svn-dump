package mx.binding.utils
{
    import flash.events.*;
    import mx.core.*;
    import mx.events.*;
    import mx.utils.*;

    public class ChangeWatcher extends Object
    {
        private var commitOnly:Boolean;
        private var host:Object;
        private var handler:Function;
        private var getter:Function;
        private var name:String;
        private var events:Object;
        private var next:ChangeWatcher;
        static const VERSION:String = "3.5.0.12683";

        public function ChangeWatcher(param1:Object, param2:Function, param3:Boolean = false, param4:ChangeWatcher = null)
        {
            host = null;
            name = param1 is String ? (param1 as String) : (param1.name);
            getter = param1 is String ? (null) : (param1.getter);
            this.handler = param2;
            this.commitOnly = param3;
            this.next = param4;
            events = {};
            return;
        }// end function

        private function getHostPropertyValue() : Object
        {
            return host == null ? (null) : (getter != null ? (getter(host)) : (host[name]));
        }// end function

        public function isWatching() : Boolean
        {
            return !isEmpty(events) && (next == null || next.isWatching());
        }// end function

        public function unwatch() : void
        {
            reset(null);
            return;
        }// end function

        private function wrapHandler(event:Event) : void
        {
            if (next)
            {
                next.reset(getHostPropertyValue());
            }
            if (event is PropertyChangeEvent)
            {
                if ((event as PropertyChangeEvent).property == name)
                {
                    handler(event as PropertyChangeEvent);
                }
            }
            else
            {
                handler(event);
            }
            return;
        }// end function

        public function setHandler(param1:Function) : void
        {
            this.handler = param1;
            if (next)
            {
                next.setHandler(param1);
            }
            return;
        }// end function

        public function getValue() : Object
        {
            return host == null ? (null) : (next == null ? (getHostPropertyValue()) : (next.getValue()));
        }// end function

        public function reset(param1:Object) : void
        {
            var _loc_2:String = null;
            if (host != null)
            {
                for (_loc_2 in events)
                {
                    
                    host.removeEventListener(_loc_2, wrapHandler);
                }
                events = {};
            }
            host = param1;
            if (host != null)
            {
                events = getEvents(host, name, commitOnly);
                for (_loc_2 in events)
                {
                    
                    host.addEventListener(_loc_2, wrapHandler, false, EventPriority.BINDING, false);
                }
            }
            if (next)
            {
                next.reset(getHostPropertyValue());
            }
            return;
        }// end function

        private static function isEmpty(param1:Object) : Boolean
        {
            var _loc_2:String = null;
            for (_loc_2 in param1)
            {
                
                return false;
            }
            return true;
        }// end function

        public static function getEvents(param1:Object, param2:String, param3:Boolean = false) : Object
        {
            var _loc_4:Object = null;
            var _loc_5:Object = null;
            var _loc_6:String = null;
            if (param1 is IEventDispatcher)
            {
                _loc_4 = DescribeTypeCache.describeType(param1).bindabilityInfo.getChangeEvents(param2);
                if (param3)
                {
                    _loc_5 = {};
                    for (_loc_6 in _loc_4)
                    {
                        
                        if (_loc_4[_loc_6])
                        {
                            _loc_5[_loc_6] = true;
                        }
                    }
                    return _loc_5;
                }
                else
                {
                    return _loc_4;
                }
                ;
            }
            return {};
        }// end function

        public static function watch(param1:Object, param2:Object, param3:Function, param4:Boolean = false) : ChangeWatcher
        {
            var _loc_5:ChangeWatcher = null;
            if (!(param2 is Array))
            {
                param2 = [param2];
            }
            if (param2.length > 0)
            {
                _loc_5 = new ChangeWatcher(param2[0], param3, param4, watch(null, param2.slice(1), param3, param4));
                _loc_5.reset(param1);
                return _loc_5;
            }
            return null;
        }// end function

        public static function canWatch(param1:Object, param2:String, param3:Boolean = false) : Boolean
        {
            return !isEmpty(getEvents(param1, param2, param3));
        }// end function

    }
}
