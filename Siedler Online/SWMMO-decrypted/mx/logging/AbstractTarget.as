package mx.logging
{
    import mx.core.*;
    import mx.logging.*;
    import mx.logging.errors.*;
    import mx.resources.*;
    import mx.utils.*;

    public class AbstractTarget extends Object implements ILoggingTarget, IMXMLObject
    {
        private var _level:int = 0;
        private var _loggerCount:uint = 0;
        private var _id:String;
        private var _filters:Array;
        private var resourceManager:IResourceManager;
        static const VERSION:String = "3.5.0.12683";

        public function AbstractTarget()
        {
            resourceManager = ResourceManager.getInstance();
            _filters = ["*"];
            _id = UIDUtil.createUID();
            return;
        }// end function

        public function get level() : int
        {
            return _level;
        }// end function

        public function set level(param1:int) : void
        {
            Log.removeTarget(this);
            _level = param1;
            Log.addTarget(this);
            return;
        }// end function

        public function logEvent(event:LogEvent) : void
        {
            return;
        }// end function

        public function addLogger(param1:ILogger) : void
        {
            if (param1)
            {
                var _loc_3:* = _loggerCount + 1;
                _loggerCount = _loc_3;
                param1.addEventListener(LogEvent.LOG, logHandler);
            }
            return;
        }// end function

        public function initialized(param1:Object, param2:String) : void
        {
            _id = param2;
            Log.addTarget(this);
            return;
        }// end function

        public function get id() : String
        {
            return _id;
        }// end function

        private function logHandler(event:LogEvent) : void
        {
            if (event.level >= level)
            {
                logEvent(event);
            }
            return;
        }// end function

        public function removeLogger(param1:ILogger) : void
        {
            if (param1)
            {
                var _loc_3:* = _loggerCount - 1;
                _loggerCount = _loc_3;
                param1.removeEventListener(LogEvent.LOG, logHandler);
            }
            return;
        }// end function

        public function set filters(param1:Array) : void
        {
            var _loc_2:String = null;
            var _loc_3:int = 0;
            var _loc_4:String = null;
            var _loc_5:uint = 0;
            if (param1 && param1.length > 0)
            {
                _loc_5 = 0;
                while (_loc_5 < param1.length)
                {
                    
                    _loc_2 = param1[_loc_5];
                    if (Log.hasIllegalCharacters(_loc_2))
                    {
                        _loc_4 = resourceManager.getString("logging", "charsInvalid", [_loc_2]);
                        throw new InvalidFilterError(_loc_4);
                    }
                    _loc_3 = _loc_2.indexOf("*");
                    if (_loc_3 >= 0 && _loc_3 != (_loc_2.length - 1))
                    {
                        _loc_4 = resourceManager.getString("logging", "charPlacement", [_loc_2]);
                        throw new InvalidFilterError(_loc_4);
                    }
                    _loc_5 = _loc_5 + 1;
                }
            }
            else
            {
                param1 = ["*"];
            }
            if (_loggerCount > 0)
            {
                Log.removeTarget(this);
                _filters = param1;
                Log.addTarget(this);
            }
            else
            {
                _filters = param1;
            }
            return;
        }// end function

        public function get filters() : Array
        {
            return _filters;
        }// end function

    }
}
