package mx.logging
{
    import mx.logging.errors.*;
    import mx.resources.*;

    public class Log extends Object
    {
        private static var _resourceManager:IResourceManager;
        private static var _targets:Array = [];
        static const VERSION:String = "3.5.0.12683";
        private static var _loggers:Array;
        private static var NONE:int = 2.14748e+009;
        private static var _targetLevel:int = NONE;

        public function Log()
        {
            return;
        }// end function

        private static function categoryMatchInFilterList(param1:String, param2:Array) : Boolean
        {
            var _loc_4:String = null;
            var _loc_3:Boolean = false;
            var _loc_5:int = -1;
            var _loc_6:uint = 0;
            while (_loc_6 < param2.length)
            {
                
                _loc_4 = param2[_loc_6];
                _loc_5 = _loc_4.indexOf("*");
                if (_loc_5 == 0)
                {
                    return true;
                }
                _loc_5 = _loc_5 < 0 ? (var _loc_7:* = param1.length, _loc_5 = param1.length, _loc_7) : ((_loc_5 - 1));
                if (param1.substring(0, _loc_5) == _loc_4.substring(0, _loc_5))
                {
                    return true;
                }
                _loc_6 = _loc_6 + 1;
            }
            return false;
        }// end function

        public static function flush() : void
        {
            _loggers = [];
            _targets = [];
            _targetLevel = NONE;
            return;
        }// end function

        public static function isDebug() : Boolean
        {
            return _targetLevel <= LogEventLevel.DEBUG ? (true) : (false);
        }// end function

        public static function getLogger(param1:String) : ILogger
        {
            var _loc_3:ILoggingTarget = null;
            checkCategory(param1);
            if (!_loggers)
            {
                _loggers = [];
            }
            var _loc_2:* = _loggers[param1];
            if (_loc_2 == null)
            {
                _loc_2 = new LogLogger(param1);
                _loggers[param1] = _loc_2;
            }
            var _loc_4:int = 0;
            while (_loc_4 < _targets.length)
            {
                
                _loc_3 = ILoggingTarget(_targets[_loc_4]);
                if (categoryMatchInFilterList(param1, _loc_3.filters))
                {
                    _loc_3.addLogger(_loc_2);
                }
                _loc_4++;
            }
            return _loc_2;
        }// end function

        public static function isWarn() : Boolean
        {
            return _targetLevel <= LogEventLevel.WARN ? (true) : (false);
        }// end function

        public static function addTarget(param1:ILoggingTarget) : void
        {
            var _loc_2:Array = null;
            var _loc_3:ILogger = null;
            var _loc_4:String = null;
            var _loc_5:String = null;
            if (param1)
            {
                _loc_2 = param1.filters;
                for (_loc_4 in _loggers)
                {
                    
                    if (categoryMatchInFilterList(_loc_4, _loc_2))
                    {
                        param1.addLogger(ILogger(_loggers[_loc_4]));
                    }
                }
                _targets.push(param1);
                if (_targetLevel == NONE)
                {
                    _targetLevel = param1.level;
                }
                else if (param1.level < _targetLevel)
                {
                    _targetLevel = param1.level;
                }
            }
            else
            {
                _loc_5 = resourceManager.getString("logging", "invalidTarget");
                throw new ArgumentError(_loc_5);
            }
            return;
        }// end function

        public static function hasIllegalCharacters(param1:String) : Boolean
        {
            return param1.search(/[\[\]\~\$\^\&\\\(\)\{\}\+\?\/=`!@#%,:;''""<>\s]""[\[\]\~\$\^\&\\(\)\{\}\+\?\/=`!@#%,:;'"<>\s]/) != -1;
        }// end function

        private static function checkCategory(param1:String) : void
        {
            var _loc_2:String = null;
            if (param1 == null || param1.length == 0)
            {
                _loc_2 = resourceManager.getString("logging", "invalidLen");
                throw new InvalidCategoryError(_loc_2);
            }
            if (hasIllegalCharacters(param1) || param1.indexOf("*") != -1)
            {
                _loc_2 = resourceManager.getString("logging", "invalidChars");
                throw new InvalidCategoryError(_loc_2);
            }
            return;
        }// end function

        private static function resetTargetLevel() : void
        {
            var _loc_1:* = NONE;
            var _loc_2:int = 0;
            while (_loc_2 < _targets.length)
            {
                
                if (_loc_1 == NONE || _targets[_loc_2].level < _loc_1)
                {
                    _loc_1 = _targets[_loc_2].level;
                }
                _loc_2++;
            }
            _targetLevel = _loc_1;
            return;
        }// end function

        public static function removeTarget(param1:ILoggingTarget) : void
        {
            var _loc_2:Array = null;
            var _loc_3:ILogger = null;
            var _loc_4:String = null;
            var _loc_5:int = 0;
            var _loc_6:String = null;
            if (param1)
            {
                _loc_2 = param1.filters;
                for (_loc_4 in _loggers)
                {
                    
                    if (categoryMatchInFilterList(_loc_4, _loc_2))
                    {
                        param1.removeLogger(ILogger(_loggers[_loc_4]));
                    }
                }
                _loc_5 = 0;
                while (_loc_5 < _targets.length)
                {
                    
                    if (param1 == _targets[_loc_5])
                    {
                        _targets.splice(_loc_5, 1);
                        _loc_5 = _loc_5 - 1;
                    }
                    _loc_5++;
                }
                resetTargetLevel();
            }
            else
            {
                _loc_6 = resourceManager.getString("logging", "invalidTarget");
                throw new ArgumentError(_loc_6);
            }
            return;
        }// end function

        public static function isInfo() : Boolean
        {
            return _targetLevel <= LogEventLevel.INFO ? (true) : (false);
        }// end function

        public static function isFatal() : Boolean
        {
            return _targetLevel <= LogEventLevel.FATAL ? (true) : (false);
        }// end function

        public static function isError() : Boolean
        {
            return _targetLevel <= LogEventLevel.ERROR ? (true) : (false);
        }// end function

        private static function get resourceManager() : IResourceManager
        {
            if (!_resourceManager)
            {
                _resourceManager = ResourceManager.getInstance();
            }
            return _resourceManager;
        }// end function

    }
}
