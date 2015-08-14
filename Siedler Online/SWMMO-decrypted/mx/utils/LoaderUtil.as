package mx.utils
{
    import flash.display.*;
    import mx.core.*;

    public class LoaderUtil extends Object
    {
        static const VERSION:String = "3.5.0.12683";
        static var urlFilters:Array = [{searchString:"/[[DYNAMIC]]/", filterFunction:dynamicURLFilter}, {searchString:"/[[IMPORT]]/", filterFunction:importURLFilter}];

        public function LoaderUtil()
        {
            return;
        }// end function

        private static function importURLFilter(param1:String, param2:int) : String
        {
            var _loc_3:* = param1.indexOf("://");
            return param1.substring(0, _loc_3 + 3) + param1.substring(param2 + 12);
        }// end function

        public static function normalizeURL(param1:LoaderInfo) : String
        {
            var _loc_3:int = 0;
            var _loc_4:String = null;
            var _loc_5:Function = null;
            var _loc_2:* = param1.url;
            var _loc_6:* = mx_internal::urlFilters.length;
            var _loc_7:uint = 0;
            while (_loc_7 < _loc_6)
            {
                
                _loc_4 = mx_internal::urlFilters[_loc_7].searchString;
                var _loc_8:* = _loc_2.indexOf(_loc_4);
                _loc_3 = _loc_2.indexOf(_loc_4);
                if (_loc_8 != -1)
                {
                    _loc_5 = mx_internal::urlFilters[_loc_7].filterFunction;
                    _loc_2 = LoaderUtil._loc_5(_loc_2, _loc_3);
                }
                _loc_7 = _loc_7 + 1;
            }
            return _loc_2;
        }// end function

        public static function createAbsoluteURL(param1:String, param2:String) : String
        {
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_3:* = param2;
            if (param1 && !(param2.indexOf(":") > -1 || param2.indexOf("/") == 0 || param2.indexOf("\\") == 0))
            {
                var _loc_6:* = param1.indexOf("?");
                _loc_4 = param1.indexOf("?");
                if (_loc_6 != -1)
                {
                    param1 = param1.substring(0, _loc_4);
                }
                var _loc_6:* = param1.indexOf("#");
                _loc_4 = param1.indexOf("#");
                if (_loc_6 != -1)
                {
                    param1 = param1.substring(0, _loc_4);
                }
                _loc_5 = Math.max(param1.lastIndexOf("\\"), param1.lastIndexOf("/"));
                if (param2.indexOf("./") == 0)
                {
                    param2 = param2.substring(2);
                }
                else
                {
                    while (param2.indexOf("../") == 0)
                    {
                        
                        param2 = param2.substring(3);
                        _loc_5 = Math.max(param1.lastIndexOf("\\", (_loc_5 - 1)), param1.lastIndexOf("/", (_loc_5 - 1)));
                    }
                }
                if (_loc_5 != -1)
                {
                    _loc_3 = param1.substr(0, (_loc_5 + 1)) + param2;
                }
            }
            return _loc_3;
        }// end function

        private static function dynamicURLFilter(param1:String, param2:int) : String
        {
            return param1.substring(0, param2);
        }// end function

    }
}
