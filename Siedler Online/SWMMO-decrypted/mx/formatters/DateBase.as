package mx.formatters
{
    import flash.events.*;
    import mx.resources.*;

    public class DateBase extends Object
    {
        private static var _resourceManager:IResourceManager;
        private static var monthNamesShortOverride:Array;
        private static var _dayNamesShort:Array;
        private static var initialized:Boolean = false;
        private static var _dayNamesLong:Array;
        private static var dayNamesLongOverride:Array;
        private static var _monthNamesLong:Array;
        private static var timeOfDayOverride:Array;
        private static var monthNamesLongOverride:Array;
        private static var _monthNamesShort:Array;
        static const VERSION:String = "3.5.0.12683";
        private static var _timeOfDay:Array;
        private static var dayNamesShortOverride:Array;

        public function DateBase()
        {
            return;
        }// end function

        public static function get monthNamesLong() : Array
        {
            initialize();
            return _monthNamesLong;
        }// end function

        public static function set monthNamesLong(param1:Array) : void
        {
            var _loc_2:String = null;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            monthNamesLongOverride = param1;
            _monthNamesLong = param1 != null ? (param1) : (resourceManager.getStringArray("SharedResources", "monthNames"));
            if (param1 == null)
            {
                _loc_2 = resourceManager.getString("SharedResources", "monthSymbol");
                if (_loc_2 != " ")
                {
                    _loc_3 = _monthNamesLong ? (_monthNamesLong.length) : (0);
                    _loc_4 = 0;
                    while (_loc_4 < _loc_3)
                    {
                        
                        _monthNamesLong[_loc_4] = _monthNamesLong[_loc_4] + _loc_2;
                        _loc_4++;
                    }
                }
            }
            return;
        }// end function

        public static function get dayNamesLong() : Array
        {
            initialize();
            return _dayNamesLong;
        }// end function

        private static function static_resourceManager_changeHandler(event:Event) : void
        {
            static_resourcesChanged();
            return;
        }// end function

        static function get defaultStringKey() : Array
        {
            initialize();
            return monthNamesLong.concat(timeOfDay);
        }// end function

        public static function set dayNamesLong(param1:Array) : void
        {
            dayNamesLongOverride = param1;
            _dayNamesLong = param1 != null ? (param1) : (resourceManager.getStringArray("SharedResources", "dayNames"));
            return;
        }// end function

        public static function set timeOfDay(param1:Array) : void
        {
            timeOfDayOverride = param1;
            var _loc_2:* = resourceManager.getString("formatters", "am");
            var _loc_3:* = resourceManager.getString("formatters", "pm");
            _timeOfDay = param1 != null ? (param1) : ([_loc_2, _loc_3]);
            return;
        }// end function

        public static function set monthNamesShort(param1:Array) : void
        {
            var _loc_2:String = null;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            monthNamesShortOverride = param1;
            _monthNamesShort = param1 != null ? (param1) : (resourceManager.getStringArray("formatters", "monthNamesShort"));
            if (param1 == null)
            {
                _loc_2 = resourceManager.getString("SharedResources", "monthSymbol");
                if (_loc_2 != " ")
                {
                    _loc_3 = _monthNamesShort ? (_monthNamesShort.length) : (0);
                    _loc_4 = 0;
                    while (_loc_4 < _loc_3)
                    {
                        
                        _monthNamesShort[_loc_4] = _monthNamesShort[_loc_4] + _loc_2;
                        _loc_4++;
                    }
                }
            }
            return;
        }// end function

        public static function get dayNamesShort() : Array
        {
            initialize();
            return _dayNamesShort;
        }// end function

        private static function static_resourcesChanged() : void
        {
            dayNamesLong = dayNamesLongOverride;
            dayNamesShort = dayNamesShortOverride;
            monthNamesLong = monthNamesLongOverride;
            monthNamesShort = monthNamesShortOverride;
            timeOfDay = timeOfDayOverride;
            return;
        }// end function

        public static function get timeOfDay() : Array
        {
            initialize();
            return _timeOfDay;
        }// end function

        static function extractTokenDate(param1:Date, param2:Object) : String
        {
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:String = null;
            var _loc_8:int = 0;
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            var _loc_11:int = 0;
            initialize();
            var _loc_3:String = "";
            var _loc_4:* = int(param2.end) - int(param2.begin);
            switch(param2.token)
            {
                case "Y":
                {
                    _loc_7 = param1.getFullYear().toString();
                    if (_loc_4 < 3)
                    {
                        return _loc_7.substr(2);
                    }
                    if (_loc_4 > 4)
                    {
                        return setValue(Number(_loc_7), _loc_4);
                    }
                    return _loc_7;
                }
                case "M":
                {
                    _loc_8 = int(param1.getMonth());
                    if (_loc_4 < 3)
                    {
                        _loc_8++;
                        _loc_3 = _loc_3 + setValue(_loc_8, _loc_4);
                        return _loc_3;
                    }
                    if (_loc_4 == 3)
                    {
                        return monthNamesShort[_loc_8];
                    }
                    return monthNamesLong[_loc_8];
                }
                case "D":
                {
                    _loc_5 = int(param1.getDate());
                    _loc_3 = _loc_3 + setValue(_loc_5, _loc_4);
                    return _loc_3;
                }
                case "E":
                {
                    _loc_5 = int(param1.getDay());
                    if (_loc_4 < 3)
                    {
                        _loc_3 = _loc_3 + setValue(_loc_5, _loc_4);
                        return _loc_3;
                    }
                    if (_loc_4 == 3)
                    {
                        return dayNamesShort[_loc_5];
                    }
                    return dayNamesLong[_loc_5];
                }
                case "A":
                {
                    _loc_6 = int(param1.getHours());
                    if (_loc_6 < 12)
                    {
                        return timeOfDay[0];
                    }
                    return timeOfDay[1];
                }
                case "H":
                {
                    _loc_6 = int(param1.getHours());
                    if (_loc_6 == 0)
                    {
                        _loc_6 = 24;
                    }
                    _loc_3 = _loc_3 + setValue(_loc_6, _loc_4);
                    return _loc_3;
                }
                case "J":
                {
                    _loc_6 = int(param1.getHours());
                    _loc_3 = _loc_3 + setValue(_loc_6, _loc_4);
                    return _loc_3;
                }
                case "K":
                {
                    _loc_6 = int(param1.getHours());
                    if (_loc_6 >= 12)
                    {
                        _loc_6 = _loc_6 - 12;
                    }
                    _loc_3 = _loc_3 + setValue(_loc_6, _loc_4);
                    return _loc_3;
                }
                case "L":
                {
                    _loc_6 = int(param1.getHours());
                    if (_loc_6 == 0)
                    {
                        _loc_6 = 12;
                    }
                    else if (_loc_6 > 12)
                    {
                        _loc_6 = _loc_6 - 12;
                    }
                    _loc_3 = _loc_3 + setValue(_loc_6, _loc_4);
                    return _loc_3;
                }
                case "N":
                {
                    _loc_9 = int(param1.getMinutes());
                    _loc_3 = _loc_3 + setValue(_loc_9, _loc_4);
                    return _loc_3;
                }
                case "S":
                {
                    _loc_10 = int(param1.getSeconds());
                    _loc_3 = _loc_3 + setValue(_loc_10, _loc_4);
                    return _loc_3;
                }
                case "Q":
                {
                    _loc_11 = int(param1.getMilliseconds());
                    _loc_3 = _loc_3 + setValue(_loc_11, _loc_4);
                    return _loc_3;
                }
                default:
                {
                    break;
                }
            }
            return _loc_3;
        }// end function

        private static function initialize() : void
        {
            if (!initialized)
            {
                resourceManager.addEventListener(Event.CHANGE, static_resourceManager_changeHandler, false, 0, true);
                static_resourcesChanged();
                initialized = true;
            }
            return;
        }// end function

        public static function set dayNamesShort(param1:Array) : void
        {
            dayNamesShortOverride = param1;
            _dayNamesShort = param1 != null ? (param1) : (resourceManager.getStringArray("formatters", "dayNamesShort"));
            return;
        }// end function

        private static function get resourceManager() : IResourceManager
        {
            if (!_resourceManager)
            {
                _resourceManager = ResourceManager.getInstance();
            }
            return _resourceManager;
        }// end function

        public static function get monthNamesShort() : Array
        {
            initialize();
            return _monthNamesShort;
        }// end function

        private static function setValue(param1:Object, param2:int) : String
        {
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_3:String = "";
            var _loc_4:* = param1.toString().length;
            if (param1.toString().length < param2)
            {
                _loc_5 = param2 - _loc_4;
                _loc_6 = 0;
                while (_loc_6 < _loc_5)
                {
                    
                    _loc_3 = _loc_3 + "0";
                    _loc_6++;
                }
            }
            _loc_3 = _loc_3 + param1.toString();
            return _loc_3;
        }// end function

    }
}
