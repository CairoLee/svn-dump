package org.igniterealtime.xiff.util
{

    public class SHA1 extends Object
    {
        private static const HEX_STR:String = "0123456789abcdef";

        public function SHA1()
        {
            return;
        }// end function

        public static function calcSHA1(param1:String) : String
        {
            var _loc_10:Number = NaN;
            var _loc_11:Number = NaN;
            var _loc_12:Number = NaN;
            var _loc_13:Number = NaN;
            var _loc_14:Number = NaN;
            var _loc_15:Number = NaN;
            var _loc_16:Number = NaN;
            var _loc_2:* = str2blks(param1);
            var _loc_3:* = new Array(80);
            var _loc_4:Number = 1732584193;
            var _loc_5:Number = -271733879;
            var _loc_6:Number = -1732584194;
            var _loc_7:Number = 271733878;
            var _loc_8:Number = -1009589776;
            var _loc_9:Number = 0;
            while (_loc_9 < _loc_2.length)
            {
                
                _loc_10 = _loc_4;
                _loc_11 = _loc_5;
                _loc_12 = _loc_6;
                _loc_13 = _loc_7;
                _loc_14 = _loc_8;
                _loc_15 = 0;
                while (_loc_15 < 80)
                {
                    
                    if (_loc_15 < 16)
                    {
                        _loc_3[_loc_15] = _loc_2[_loc_9 + _loc_15];
                    }
                    else
                    {
                        _loc_3[_loc_15] = rol(_loc_3[_loc_15 - 3] ^ _loc_3[_loc_15 - 8] ^ _loc_3[_loc_15 - 14] ^ _loc_3[_loc_15 - 16], 1);
                    }
                    _loc_16 = safe_add(safe_add(rol(_loc_4, 5), ft(_loc_15, _loc_5, _loc_6, _loc_7)), safe_add(safe_add(_loc_8, _loc_3[_loc_15]), kt(_loc_15)));
                    _loc_8 = _loc_7;
                    _loc_7 = _loc_6;
                    _loc_6 = rol(_loc_5, 30);
                    _loc_5 = _loc_4;
                    _loc_4 = _loc_16;
                    _loc_15 = _loc_15 + 1;
                }
                _loc_4 = safe_add(_loc_4, _loc_10);
                _loc_5 = safe_add(_loc_5, _loc_11);
                _loc_6 = safe_add(_loc_6, _loc_12);
                _loc_7 = safe_add(_loc_7, _loc_13);
                _loc_8 = safe_add(_loc_8, _loc_14);
                _loc_9 = _loc_9 + 16;
            }
            return hex(_loc_4) + hex(_loc_5) + hex(_loc_6) + hex(_loc_7) + hex(_loc_8);
        }// end function

        private static function str2blks(param1:String) : Array
        {
            var _loc_2:* = (param1.length + 8 >> 6) + 1;
            var _loc_3:* = new Array(_loc_2 * 16);
            var _loc_4:Number = 0;
            while (_loc_4 < _loc_2 * 16)
            {
                
                _loc_3[_loc_4] = 0;
                _loc_4 = _loc_4 + 1;
            }
            var _loc_5:Number = 0;
            while (_loc_5 < param1.length)
            {
                
                _loc_3[_loc_5 >> 2] = _loc_3[_loc_5 >> 2] | param1.charCodeAt(_loc_5) << 24 - _loc_5 % 4 * 8;
                _loc_5 = _loc_5 + 1;
            }
            _loc_3[_loc_5 >> 2] = _loc_3[_loc_5 >> 2] | 128 << 24 - _loc_5 % 4 * 8;
            _loc_3[_loc_2 * 16 - 1] = param1.length * 8;
            return _loc_3;
        }// end function

        private static function rol(param1:Number, param2:Number) : Number
        {
            return param1 << param2 | param1 >>> 32 - param2;
        }// end function

        private static function kt(param1:Number) : Number
        {
            return param1 < 20 ? (1518500249) : (param1 < 40 ? (1859775393) : (param1 < 60 ? (-1894007588) : (-899497514)));
        }// end function

        private static function hex(param1:Number) : String
        {
            var _loc_2:String = "";
            var _loc_3:Number = 7;
            while (_loc_3 >= 0)
            {
                
                _loc_2 = _loc_2 + HEX_STR.charAt(param1 >> _loc_3 * 4 & 15);
                _loc_3 = _loc_3 - 1;
            }
            return _loc_2;
        }// end function

        private static function ft(param1:Number, param2:Number, param3:Number, param4:Number) : Number
        {
            if (param1 < 20)
            {
                return param2 & param3 | ~param2 & param4;
            }
            if (param1 < 40)
            {
                return param2 ^ param3 ^ param4;
            }
            if (param1 < 60)
            {
                return param2 & param3 | param2 & param4 | param3 & param4;
            }
            return param2 ^ param3 ^ param4;
        }// end function

        private static function safe_add(param1:Number, param2:Number) : Number
        {
            var _loc_3:* = (param1 & 65535) + (param2 & 65535);
            var _loc_4:* = (param1 >> 16) + (param2 >> 16) + (_loc_3 >> 16);
            return (param1 >> 16) + (param2 >> 16) + (_loc_3 >> 16) << 16 | _loc_3 & 65535;
        }// end function

    }
}
