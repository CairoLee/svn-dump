package com.google.analytics.utils
{
    import flash.net.*;

    dynamic public class Variables extends Object
    {
        public var post:Array;
        public var URIencode:Boolean;
        public var pre:Array;
        public var sort:Boolean = true;

        public function Variables(param1:String = null, param2:Array = null, param3:Array = null)
        {
            pre = [];
            post = [];
            if (param1)
            {
                decode(param1);
            }
            if (param2)
            {
                this.pre = param2;
            }
            if (param3)
            {
                this.post = param3;
            }
            return;
        }// end function

        private function _join(param1:Variables) : void
        {
            var _loc_2:String = null;
            if (!param1)
            {
                return;
            }
            for (_loc_2 in param1)
            {
                
                this[_loc_2] = param1[_loc_2];
            }
            return;
        }// end function

        public function join(... args) : void
        {
            args = args.length;
            var _loc_3:int = 0;
            while (_loc_3 < args)
            {
                
                if (!(args[_loc_3] is Variables))
                {
                }
                else
                {
                    _join(args[_loc_3]);
                }
                _loc_3++;
            }
            return;
        }// end function

        public function toString() : String
        {
            var _loc_2:String = null;
            var _loc_3:String = null;
            var _loc_4:String = null;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:String = null;
            var _loc_8:String = null;
            var _loc_1:Array = [];
            for (_loc_3 in this)
            {
                
                _loc_2 = this[_loc_3];
                if (URIencode)
                {
                    _loc_2 = encodeURI(_loc_2);
                }
                _loc_1.push(_loc_3 + "=" + _loc_2);
            }
            if (sort)
            {
                _loc_1.sort();
            }
            if (pre.length > 0)
            {
                pre.reverse();
                _loc_5 = 0;
                while (_loc_5 < pre.length)
                {
                    
                    _loc_7 = pre[_loc_5];
                    _loc_6 = 0;
                    while (_loc_6 < _loc_1.length)
                    {
                        
                        _loc_4 = _loc_1[_loc_6];
                        if (_loc_4.indexOf(_loc_7) == 0)
                        {
                            _loc_1.unshift(_loc_1.splice(_loc_6, 1)[0]);
                        }
                        _loc_6++;
                    }
                    _loc_5++;
                }
                pre.reverse();
            }
            if (post.length > 0)
            {
                _loc_5 = 0;
                while (_loc_5 < post.length)
                {
                    
                    _loc_8 = post[_loc_5];
                    _loc_6 = 0;
                    while (_loc_6 < _loc_1.length)
                    {
                        
                        _loc_4 = _loc_1[_loc_6];
                        if (_loc_4.indexOf(_loc_8) == 0)
                        {
                            _loc_1.push(_loc_1.splice(_loc_6, 1)[0]);
                        }
                        _loc_6++;
                    }
                    _loc_5++;
                }
            }
            return _loc_1.join("&");
        }// end function

        public function decode(param1:String) : void
        {
            var _loc_2:Array = null;
            var _loc_3:String = null;
            var _loc_4:String = null;
            var _loc_5:String = null;
            var _loc_6:Array = null;
            if (param1 == "")
            {
                return;
            }
            if (param1.indexOf("&") > -1)
            {
                _loc_2 = param1.split("&");
            }
            else
            {
                _loc_2 = [param1];
            }
            var _loc_7:int = 0;
            while (_loc_7 < _loc_2.length)
            {
                
                _loc_3 = _loc_2[_loc_7];
                if (_loc_3.indexOf("=") > -1)
                {
                    _loc_6 = _loc_3.split("=");
                    _loc_4 = _loc_6[0];
                    _loc_5 = decodeURI(_loc_6[1]);
                    this[_loc_4] = _loc_5;
                }
                _loc_7++;
            }
            return;
        }// end function

        public function toURLVariables() : URLVariables
        {
            var _loc_2:String = null;
            var _loc_1:* = new URLVariables();
            for (_loc_2 in this)
            {
                
                _loc_1[_loc_2] = this[_loc_2];
            }
            return _loc_1;
        }// end function

    }
}
