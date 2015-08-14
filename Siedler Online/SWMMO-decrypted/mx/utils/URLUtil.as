package mx.utils
{
    import mx.messaging.config.*;

    public class URLUtil extends Object
    {
        public static const SERVER_NAME_TOKEN:String = "{server.name}";
        private static const SERVER_PORT_REGEX:RegExp = new RegExp("\\{server.port\\}", "g");
        private static const SERVER_NAME_REGEX:RegExp = new RegExp("\\{server.name\\}", "g");
        public static const SERVER_PORT_TOKEN:String = "{server.port}";

        public function URLUtil()
        {
            return;
        }// end function

        public static function hasUnresolvableTokens() : Boolean
        {
            return LoaderConfig.url != null;
        }// end function

        public static function getServerName(param1:String) : String
        {
            var _loc_2:* = getServerNameWithPort(param1);
            var _loc_3:* = _loc_2.indexOf("]");
            _loc_3 = _loc_3 > -1 ? (_loc_2.indexOf(":", _loc_3)) : (_loc_2.indexOf(":"));
            if (_loc_3 > 0)
            {
                _loc_2 = _loc_2.substring(0, _loc_3);
            }
            return _loc_2;
        }// end function

        public static function isHttpsURL(param1:String) : Boolean
        {
            return param1 != null && param1.indexOf("https://") == 0;
        }// end function

        private static function internalObjectToString(param1:Object, param2:String, param3:String, param4:Boolean) : String
        {
            var _loc_7:String = null;
            var _loc_8:Object = null;
            var _loc_9:String = null;
            var _loc_5:String = "";
            var _loc_6:Boolean = true;
            for (_loc_7 in param1)
            {
                
                if (_loc_6)
                {
                    _loc_6 = false;
                }
                else
                {
                    _loc_5 = _loc_5 + param2;
                }
                _loc_8 = param1[_loc_7];
                _loc_9 = param3 ? (param3 + "." + _loc_7) : (_loc_7);
                if (param4)
                {
                    _loc_9 = encodeURIComponent(_loc_9);
                }
                if (_loc_8 is String)
                {
                    _loc_5 = _loc_5 + (_loc_9 + "=" + (param4 ? (encodeURIComponent(_loc_8 as String)) : (_loc_8)));
                    continue;
                }
                if (_loc_8 is Number)
                {
                    _loc_8 = _loc_8.toString();
                    if (param4)
                    {
                        _loc_8 = encodeURIComponent(_loc_8 as String);
                    }
                    _loc_5 = _loc_5 + (_loc_9 + "=" + _loc_8);
                    continue;
                }
                if (_loc_8 is Boolean)
                {
                    _loc_5 = _loc_5 + (_loc_9 + "=" + (_loc_8 ? ("true") : ("false")));
                    continue;
                }
                if (_loc_8 is Array)
                {
                    _loc_5 = _loc_5 + internalArrayToString(_loc_8 as Array, param2, _loc_9, param4);
                    continue;
                }
                _loc_5 = _loc_5 + internalObjectToString(_loc_8, param2, _loc_9, param4);
            }
            return _loc_5;
        }// end function

        public static function getFullURL(param1:String, param2:String) : String
        {
            var _loc_3:Number = NaN;
            if (param2 != null && !URLUtil.isHttpURL(param2))
            {
                if (param2.indexOf("./") == 0)
                {
                    param2 = param2.substring(2);
                }
                if (URLUtil.isHttpURL(param1))
                {
                    if (param2.charAt(0) == "/")
                    {
                        _loc_3 = param1.indexOf("/", 8);
                        if (_loc_3 == -1)
                        {
                            _loc_3 = param1.length;
                        }
                    }
                    else
                    {
                        _loc_3 = param1.lastIndexOf("/") + 1;
                        if (_loc_3 <= 8)
                        {
                            param1 = param1 + "/";
                            _loc_3 = param1.length;
                        }
                    }
                    if (_loc_3 > 0)
                    {
                        param2 = param1.substring(0, _loc_3) + param2;
                    }
                }
            }
            return param2;
        }// end function

        public static function getServerNameWithPort(param1:String) : String
        {
            var _loc_2:* = param1.indexOf("/") + 2;
            var _loc_3:* = param1.indexOf("/", _loc_2);
            return _loc_3 == -1 ? (param1.substring(_loc_2)) : (param1.substring(_loc_2, _loc_3));
        }// end function

        public static function replaceProtocol(param1:String, param2:String) : String
        {
            return param1.replace(getProtocol(param1), param2);
        }// end function

        public static function urisEqual(param1:String, param2:String) : Boolean
        {
            if (param1 != null && param2 != null)
            {
                param1 = StringUtil.trim(param1).toLowerCase();
                param2 = StringUtil.trim(param2).toLowerCase();
                if (param1.charAt((param1.length - 1)) != "/")
                {
                    param1 = param1 + "/";
                }
                if (param2.charAt((param2.length - 1)) != "/")
                {
                    param2 = param2 + "/";
                }
            }
            return param1 == param2;
        }// end function

        public static function getProtocol(param1:String) : String
        {
            var _loc_2:* = param1.indexOf("/");
            var _loc_3:* = param1.indexOf(":/");
            if (_loc_3 > -1 && _loc_3 < _loc_2)
            {
                return param1.substring(0, _loc_3);
            }
            _loc_3 = param1.indexOf("::");
            if (_loc_3 > -1 && _loc_3 < _loc_2)
            {
                return param1.substring(0, _loc_3);
            }
            return "";
        }// end function

        private static function internalArrayToString(param1:Array, param2:String, param3:String, param4:Boolean) : String
        {
            var _loc_9:Object = null;
            var _loc_10:String = null;
            var _loc_5:String = "";
            var _loc_6:Boolean = true;
            var _loc_7:* = param1.length;
            var _loc_8:int = 0;
            while (_loc_8 < _loc_7)
            {
                
                if (_loc_6)
                {
                    _loc_6 = false;
                }
                else
                {
                    _loc_5 = _loc_5 + param2;
                }
                _loc_9 = param1[_loc_8];
                _loc_10 = param3 + "." + _loc_8;
                if (param4)
                {
                    _loc_10 = encodeURIComponent(_loc_10);
                }
                if (_loc_9 is String)
                {
                    _loc_5 = _loc_5 + (_loc_10 + "=" + (param4 ? (encodeURIComponent(_loc_9 as String)) : (_loc_9)));
                }
                else if (_loc_9 is Number)
                {
                    _loc_9 = _loc_9.toString();
                    if (param4)
                    {
                        _loc_9 = encodeURIComponent(_loc_9 as String);
                    }
                    _loc_5 = _loc_5 + (_loc_10 + "=" + _loc_9);
                }
                else if (_loc_9 is Boolean)
                {
                    _loc_5 = _loc_5 + (_loc_10 + "=" + (_loc_9 ? ("true") : ("false")));
                }
                else if (_loc_9 is Array)
                {
                    _loc_5 = _loc_5 + internalArrayToString(_loc_9 as Array, param2, _loc_10, param4);
                }
                else
                {
                    _loc_5 = _loc_5 + internalObjectToString(_loc_9, param2, _loc_10, param4);
                }
                _loc_8++;
            }
            return _loc_5;
        }// end function

        public static function objectToString(param1:Object, param2:String = ";", param3:Boolean = true) : String
        {
            var _loc_4:* = internalObjectToString(param1, param2, null, param3);
            return internalObjectToString(param1, param2, null, param3);
        }// end function

        public static function replaceTokens(param1:String) : String
        {
            var _loc_4:String = null;
            var _loc_5:String = null;
            var _loc_6:uint = 0;
            var _loc_2:* = LoaderConfig.url == null ? ("") : (LoaderConfig.url);
            if (param1.indexOf(SERVER_NAME_TOKEN) > 0)
            {
                _loc_4 = URLUtil.getProtocol(_loc_2);
                _loc_5 = "localhost";
                if (_loc_4.toLowerCase() != "file")
                {
                    _loc_5 = URLUtil.getServerName(_loc_2);
                }
                param1 = param1.replace(SERVER_NAME_REGEX, _loc_5);
            }
            var _loc_3:* = param1.indexOf(SERVER_PORT_TOKEN);
            if (_loc_3 > 0)
            {
                _loc_6 = URLUtil.getPort(_loc_2);
                if (_loc_6 > 0)
                {
                    param1 = param1.replace(SERVER_PORT_REGEX, _loc_6);
                }
                else
                {
                    if (param1.charAt((_loc_3 - 1)) == ":")
                    {
                        param1 = param1.substring(0, (_loc_3 - 1)) + param1.substring(_loc_3);
                    }
                    param1 = param1.replace(SERVER_PORT_REGEX, "");
                }
            }
            return param1;
        }// end function

        public static function getPort(param1:String) : uint
        {
            var _loc_5:Number = NaN;
            var _loc_2:* = getServerNameWithPort(param1);
            var _loc_3:* = _loc_2.indexOf("]");
            _loc_3 = _loc_3 > -1 ? (_loc_2.indexOf(":", _loc_3)) : (_loc_2.indexOf(":"));
            var _loc_4:uint = 0;
            if (_loc_3 > 0)
            {
                _loc_5 = Number(_loc_2.substring((_loc_3 + 1)));
                if (!isNaN(_loc_5))
                {
                    _loc_4 = int(_loc_5);
                }
            }
            return _loc_4;
        }// end function

        public static function stringToObject(param1:String, param2:String = ";", param3:Boolean = true) : Object
        {
            var _loc_8:Array = null;
            var _loc_9:String = null;
            var _loc_10:Object = null;
            var _loc_11:Object = null;
            var _loc_12:int = 0;
            var _loc_13:int = 0;
            var _loc_14:Object = null;
            var _loc_15:String = null;
            var _loc_16:String = null;
            var _loc_17:Object = null;
            var _loc_4:Object = {};
            var _loc_5:* = param1.split(param2);
            var _loc_6:* = param1.split(param2).length;
            var _loc_7:int = 0;
            while (_loc_7 < _loc_6)
            {
                
                _loc_8 = _loc_5[_loc_7].split("=");
                _loc_9 = _loc_8[0];
                if (param3)
                {
                    _loc_9 = decodeURIComponent(_loc_9);
                }
                _loc_10 = _loc_8[1];
                if (param3)
                {
                    _loc_10 = decodeURIComponent(_loc_10 as String);
                }
                if (_loc_10 == "true")
                {
                    _loc_10 = true;
                }
                else if (_loc_10 == "false")
                {
                    _loc_10 = false;
                }
                else
                {
                    _loc_14 = int(_loc_10);
                    if (_loc_14.toString() == _loc_10)
                    {
                        _loc_10 = _loc_14;
                    }
                    else
                    {
                        _loc_14 = Number(_loc_10);
                        if (_loc_14.toString() == _loc_10)
                        {
                            _loc_10 = _loc_14;
                        }
                    }
                }
                _loc_11 = _loc_4;
                _loc_8 = _loc_9.split(".");
                _loc_12 = _loc_8.length;
                _loc_13 = 0;
                while (_loc_13 < (_loc_12 - 1))
                {
                    
                    _loc_15 = _loc_8[_loc_13];
                    if (_loc_11[_loc_15] == null && _loc_13 < (_loc_12 - 1))
                    {
                        _loc_16 = _loc_8[(_loc_13 + 1)];
                        _loc_17 = int(_loc_16);
                        if (_loc_17.toString() == _loc_16)
                        {
                            _loc_11[_loc_15] = [];
                        }
                        else
                        {
                            _loc_11[_loc_15] = {};
                        }
                    }
                    _loc_11 = _loc_11[_loc_15];
                    _loc_13++;
                }
                _loc_11[_loc_8[_loc_13]] = _loc_10;
                _loc_7++;
            }
            return _loc_4;
        }// end function

        public static function replacePort(param1:String, param2:uint) : String
        {
            var _loc_6:int = 0;
            var _loc_3:String = "";
            var _loc_4:* = param1.indexOf("]");
            if (param1.indexOf("]") == -1)
            {
                _loc_4 = param1.indexOf(":");
            }
            var _loc_5:* = param1.indexOf(":", (_loc_4 + 1));
            if (param1.indexOf(":", (_loc_4 + 1)) > -1)
            {
                _loc_5++;
                _loc_6 = param1.indexOf("/", _loc_5);
                _loc_3 = param1.substring(0, _loc_5) + param2.toString() + param1.substring(_loc_6, param1.length);
            }
            else
            {
                _loc_6 = param1.indexOf("/", _loc_4);
                if (_loc_6 > -1)
                {
                    if (param1.charAt((_loc_6 + 1)) == "/")
                    {
                        _loc_6 = param1.indexOf("/", _loc_6 + 2);
                    }
                    if (_loc_6 > 0)
                    {
                        _loc_3 = param1.substring(0, _loc_6) + ":" + param2.toString() + param1.substring(_loc_6, param1.length);
                    }
                    else
                    {
                        _loc_3 = param1 + ":" + param2.toString();
                    }
                }
                else
                {
                    _loc_3 = param1 + ":" + param2.toString();
                }
            }
            return _loc_3;
        }// end function

        public static function isHttpURL(param1:String) : Boolean
        {
            return param1 != null && (param1.indexOf("http://") == 0 || param1.indexOf("https://") == 0);
        }// end function

    }
}
