package mx.logging
{
    import flash.events.*;
    import mx.logging.*;
    import mx.resources.*;

    public class LogLogger extends EventDispatcher implements ILogger
    {
        private var _category:String;
        private var resourceManager:IResourceManager;
        static const VERSION:String = "3.5.0.12683";

        public function LogLogger(param1:String)
        {
            resourceManager = ResourceManager.getInstance();
            _category = param1;
            return;
        }// end function

        public function log(param1:int, param2:String, ... args) : void
        {
            args = null;
            var _loc_5:int = 0;
            if (param1 < LogEventLevel.DEBUG)
            {
                args = resourceManager.getString("logging", "levelLimit");
                throw new ArgumentError(args);
            }
            if (hasEventListener(LogEvent.LOG))
            {
                _loc_5 = 0;
                while (_loc_5 < args.length)
                {
                    
                    param2 = param2.replace(new RegExp("\\{" + _loc_5 + "\\}", "g"), args[_loc_5]);
                    _loc_5++;
                }
                dispatchEvent(new LogEvent(param2, param1));
            }
            return;
        }// end function

        public function error(param1:String, ... args) : void
        {
            args = 0;
            if (hasEventListener(LogEvent.LOG))
            {
                args = 0;
                while (args < args.length)
                {
                    
                    param1 = param1.replace(new RegExp("\\{" + args + "\\}", "g"), args[args]);
                    args++;
                }
                dispatchEvent(new LogEvent(param1, LogEventLevel.ERROR));
            }
            return;
        }// end function

        public function warn(param1:String, ... args) : void
        {
            args = 0;
            if (hasEventListener(LogEvent.LOG))
            {
                args = 0;
                while (args < args.length)
                {
                    
                    param1 = param1.replace(new RegExp("\\{" + args + "\\}", "g"), args[args]);
                    args++;
                }
                dispatchEvent(new LogEvent(param1, LogEventLevel.WARN));
            }
            return;
        }// end function

        public function get category() : String
        {
            return _category;
        }// end function

        public function info(param1:String, ... args) : void
        {
            args = 0;
            if (hasEventListener(LogEvent.LOG))
            {
                args = 0;
                while (args < args.length)
                {
                    
                    param1 = param1.replace(new RegExp("\\{" + args + "\\}", "g"), args[args]);
                    args++;
                }
                dispatchEvent(new LogEvent(param1, LogEventLevel.INFO));
            }
            return;
        }// end function

        public function debug(param1:String, ... args) : void
        {
            args = 0;
            if (hasEventListener(LogEvent.LOG))
            {
                args = 0;
                while (args < args.length)
                {
                    
                    param1 = param1.replace(new RegExp("\\{" + args + "\\}", "g"), args[args]);
                    args++;
                }
                dispatchEvent(new LogEvent(param1, LogEventLevel.DEBUG));
            }
            return;
        }// end function

        public function fatal(param1:String, ... args) : void
        {
            args = 0;
            if (hasEventListener(LogEvent.LOG))
            {
                args = 0;
                while (args < args.length)
                {
                    
                    param1 = param1.replace(new RegExp("\\{" + args + "\\}", "g"), args[args]);
                    args++;
                }
                dispatchEvent(new LogEvent(param1, LogEventLevel.FATAL));
            }
            return;
        }// end function

    }
}
