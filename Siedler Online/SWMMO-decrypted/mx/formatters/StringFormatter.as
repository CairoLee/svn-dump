package mx.formatters
{

    public class StringFormatter extends Object
    {
        private var reqFormat:String;
        private var extractToken:Function;
        private var patternInfo:Array;
        static const VERSION:String = "3.5.0.12683";

        public function StringFormatter(param1:String, param2:String, param3:Function)
        {
            formatPattern(param1, param2);
            extractToken = param3;
            return;
        }// end function

        public function formatValue(param1:Object) : String
        {
            var _loc_2:* = patternInfo[0];
            var _loc_3:* = reqFormat.substring(0, _loc_2.begin) + extractToken(param1, _loc_2);
            var _loc_4:* = _loc_2;
            var _loc_5:* = patternInfo.length;
            var _loc_6:int = 1;
            while (_loc_6 < _loc_5)
            {
                
                _loc_2 = patternInfo[_loc_6];
                _loc_3 = _loc_3 + (reqFormat.substring(_loc_4.end, _loc_2.begin) + extractToken(param1, _loc_2));
                _loc_4 = _loc_2;
                _loc_6++;
            }
            if (_loc_4.end > 0 && _loc_4.end != reqFormat.length)
            {
                _loc_3 = _loc_3 + reqFormat.substring(_loc_4.end);
            }
            return _loc_3;
        }// end function

        private function compareValues(param1:Object, param2:Object) : int
        {
            if (param1.begin > param2.begin)
            {
                return 1;
            }
            if (param1.begin < param2.begin)
            {
                return -1;
            }
            return 0;
        }// end function

        private function formatPattern(param1:String, param2:String) : void
        {
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:* = param2.split(",");
            reqFormat = param1;
            patternInfo = [];
            var _loc_7:* = _loc_6.length;
            var _loc_8:int = 0;
            while (_loc_8 < _loc_7)
            {
                
                _loc_3 = reqFormat.indexOf(_loc_6[_loc_8]);
                if (_loc_3 >= 0 && _loc_3 < reqFormat.length)
                {
                    _loc_4 = reqFormat.lastIndexOf(_loc_6[_loc_8]);
                    _loc_4 = _loc_4 >= 0 ? ((_loc_4 + 1)) : ((_loc_3 + 1));
                    patternInfo.splice(_loc_5, 0, {token:_loc_6[_loc_8], begin:_loc_3, end:_loc_4});
                    _loc_5++;
                }
                _loc_8++;
            }
            patternInfo.sort(compareValues);
            return;
        }// end function

    }
}
