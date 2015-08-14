package mx.formatters
{
    import mx.core.*;

    public class DateFormatter extends Formatter
    {
        private var formatStringOverride:String;
        private var _formatString:String;
        static const VERSION:String = "3.5.0.12683";
        private static const VALID_PATTERN_CHARS:String = "Y,M,D,A,E,H,J,K,L,N,S,Q";

        public function DateFormatter()
        {
            return;
        }// end function

        public function set formatString(param1:String) : void
        {
            formatStringOverride = param1;
            _formatString = param1 != null ? (param1) : (resourceManager.getString("SharedResources", "dateFormat"));
            return;
        }// end function

        override protected function resourcesChanged() : void
        {
            super.resourcesChanged();
            formatString = formatStringOverride;
            return;
        }// end function

        override public function format(param1:Object) : String
        {
            var _loc_2:String = null;
            if (error)
            {
                error = null;
            }
            if (!param1 || param1 is String && param1 == "")
            {
                error = defaultInvalidValueError;
                return "";
            }
            if (param1 is String)
            {
                param1 = parseDateString(String(param1));
                if (!param1)
                {
                    error = defaultInvalidValueError;
                    return "";
                }
            }
            else if (!(param1 is Date))
            {
                error = defaultInvalidValueError;
                return "";
            }
            var _loc_3:int = 0;
            var _loc_4:String = "";
            var _loc_5:* = formatString.length;
            var _loc_6:int = 0;
            while (_loc_6 < _loc_5)
            {
                
                _loc_2 = formatString.charAt(_loc_6);
                if (VALID_PATTERN_CHARS.indexOf(_loc_2) != -1 && _loc_2 != ",")
                {
                    _loc_3++;
                    if (_loc_4.indexOf(_loc_2) == -1)
                    {
                        _loc_4 = _loc_4 + _loc_2;
                    }
                    else if (_loc_2 != formatString.charAt(Math.max((_loc_6 - 1), 0)))
                    {
                        error = defaultInvalidFormatError;
                        return "";
                    }
                }
                _loc_6++;
            }
            if (_loc_3 < 1)
            {
                error = defaultInvalidFormatError;
                return "";
            }
            var _loc_7:* = new StringFormatter(formatString, VALID_PATTERN_CHARS, mx_internal::extractTokenDate);
            return new StringFormatter(formatString, VALID_PATTERN_CHARS, mx_internal::extractTokenDate).formatValue(param1);
        }// end function

        public function get formatString() : String
        {
            return _formatString;
        }// end function

        public static function parseDateString(param1:String) : Date
        {
            var _loc_14:String = null;
            var _loc_15:int = 0;
            var _loc_16:int = 0;
            var _loc_17:String = null;
            var _loc_18:String = null;
            var _loc_19:int = 0;
            if (!param1 || param1 == "")
            {
                return null;
            }
            var _loc_2:int = -1;
            var _loc_3:int = -1;
            var _loc_4:int = -1;
            var _loc_5:int = -1;
            var _loc_6:int = -1;
            var _loc_7:int = -1;
            var _loc_8:String = "";
            var _loc_9:Object = 0;
            var _loc_10:int = 0;
            var _loc_11:* = param1.length;
            var _loc_12:* = /(GMT|UTC)((\+|-)\d\d\d\d )?""(GMT|UTC)((\+|-)\d\d\d\d )?/ig;
            param1 = param1.replace(_loc_12, "");
            while (_loc_10 < _loc_11)
            {
                
                _loc_8 = param1.charAt(_loc_10);
                _loc_10++;
                if (_loc_8 <= " " || _loc_8 == ",")
                {
                    continue;
                }
                if (_loc_8 == "/" || _loc_8 == ":" || _loc_8 == "+" || _loc_8 == "-")
                {
                    _loc_9 = _loc_8;
                    continue;
                }
                if (_loc_8 >= "a" && _loc_8 <= "z" || _loc_8 >= "A" && _loc_8 <= "Z")
                {
                    _loc_14 = _loc_8;
                    while (_loc_10 < _loc_11)
                    {
                        
                        _loc_8 = param1.charAt(_loc_10);
                        if (!(_loc_8 >= "a" && _loc_8 <= "z" || _loc_8 >= "A" && _loc_8 <= "Z"))
                        {
                            break;
                        }
                        _loc_14 = _loc_14 + _loc_8;
                        _loc_10++;
                    }
                    _loc_15 = mx_internal::defaultStringKey.length;
                    _loc_16 = 0;
                    while (_loc_16 < _loc_15)
                    {
                        
                        _loc_17 = String(mx_internal::defaultStringKey[_loc_16]);
                        if (_loc_17.toLowerCase() == _loc_14.toLowerCase() || _loc_17.toLowerCase().substr(0, 3) == _loc_14.toLowerCase())
                        {
                            if (_loc_16 == 13)
                            {
                                if (_loc_5 > 12 || _loc_5 < 1)
                                {
                                    break;
                                }
                                else if (_loc_5 < 12)
                                {
                                    _loc_5 = _loc_5 + 12;
                                }
                            }
                            else if (_loc_16 == 12)
                            {
                                if (_loc_5 > 12 || _loc_5 < 1)
                                {
                                    break;
                                }
                                else if (_loc_5 == 12)
                                {
                                    _loc_5 = 0;
                                }
                            }
                            else if (_loc_16 < 12)
                            {
                                if (_loc_3 < 0)
                                {
                                    _loc_3 = _loc_16;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            break;
                        }
                        _loc_16++;
                    }
                    _loc_9 = 0;
                    continue;
                }
                if (_loc_8 >= "0" && _loc_8 <= "9")
                {
                    _loc_18 = _loc_8;
                    do
                    {
                        
                        _loc_18 = _loc_18 + _loc_8;
                        _loc_10++;
                        var _loc_20:* = param1.charAt(_loc_10);
                        _loc_8 = param1.charAt(_loc_10);
                    }while (_loc_20 >= "0" && _loc_8 <= "9" && _loc_10 < _loc_11)
                    _loc_19 = int(_loc_18);
                    if (_loc_19 >= 70)
                    {
                        if (_loc_2 != -1)
                        {
                            break;
                        }
                        else if (_loc_8 <= " " || _loc_8 == "," || _loc_8 == "." || _loc_8 == "/" || _loc_8 == "-" || _loc_10 >= _loc_11)
                        {
                            _loc_2 = _loc_19;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else if (_loc_8 == "/" || _loc_8 == "-" || _loc_8 == ".")
                    {
                        if (_loc_3 < 0)
                        {
                            _loc_3 = _loc_19 - 1;
                        }
                        else if (_loc_4 < 0)
                        {
                            _loc_4 = _loc_19;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else if (_loc_8 == ":")
                    {
                        if (_loc_5 < 0)
                        {
                            _loc_5 = _loc_19;
                        }
                        else if (_loc_6 < 0)
                        {
                            _loc_6 = _loc_19;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else if (_loc_5 >= 0 && _loc_6 < 0)
                    {
                        _loc_6 = _loc_19;
                    }
                    else if (_loc_6 >= 0 && _loc_7 < 0)
                    {
                        _loc_7 = _loc_19;
                    }
                    else if (_loc_4 < 0)
                    {
                        _loc_4 = _loc_19;
                    }
                    else if (_loc_2 < 0 && _loc_3 >= 0 && _loc_4 >= 0)
                    {
                        _loc_2 = 2000 + _loc_19;
                    }
                    else
                    {
                        break;
                    }
                    _loc_9 = 0;
                }
            }
            if (_loc_2 < 0 || _loc_3 < 0 || _loc_3 > 11 || _loc_4 < 1 || _loc_4 > 31)
            {
                return null;
            }
            if (_loc_7 < 0)
            {
                _loc_7 = 0;
            }
            if (_loc_6 < 0)
            {
                _loc_6 = 0;
            }
            if (_loc_5 < 0)
            {
                _loc_5 = 0;
            }
            var _loc_13:* = new Date(_loc_2, _loc_3, _loc_4, _loc_5, _loc_6, _loc_7);
            if (_loc_4 != _loc_13.getDate() || _loc_3 != _loc_13.getMonth())
            {
                return null;
            }
            return _loc_13;
        }// end function

    }
}
