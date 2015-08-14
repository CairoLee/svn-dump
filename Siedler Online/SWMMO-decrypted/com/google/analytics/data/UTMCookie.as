package com.google.analytics.data
{
    import com.google.analytics.core.*;
    import com.google.analytics.data.*;

    public class UTMCookie extends Object implements Cookie
    {
        protected var inURL:String;
        protected var name:String;
        private var _creation:Date;
        private var _expiration:Date;
        public var proxy:Buffer;
        protected var fields:Array;
        private var _timespan:Number;

        public function UTMCookie(param1:String, param2:String, param3:Array, param4:Number = 0)
        {
            this.name = param1;
            this.inURL = param2;
            this.fields = param3;
            _timestamp(param4);
            return;
        }// end function

        public function isEmpty() : Boolean
        {
            var _loc_2:String = null;
            var _loc_1:int = 0;
            var _loc_3:int = 0;
            while (_loc_3 < fields.length)
            {
                
                _loc_2 = fields[_loc_3];
                if (this[_loc_2] is Number && isNaN(this[_loc_2]))
                {
                    _loc_1++;
                }
                else if (this[_loc_2] is String && this[_loc_2] == "")
                {
                    _loc_1++;
                }
                _loc_3++;
            }
            if (_loc_1 == fields.length)
            {
                return true;
            }
            return false;
        }// end function

        public function resetTimestamp(param1:Number = NaN) : void
        {
            if (!isNaN(param1))
            {
                _timespan = param1;
            }
            _creation = null;
            _expiration = null;
            _timestamp(_timespan);
            return;
        }// end function

        protected function update() : void
        {
            resetTimestamp();
            if (proxy)
            {
                proxy.update(name, toSharedObject());
            }
            return;
        }// end function

        public function reset() : void
        {
            var _loc_1:String = null;
            var _loc_2:int = 0;
            while (_loc_2 < fields.length)
            {
                
                _loc_1 = fields[_loc_2];
                if (this[_loc_1] is Number)
                {
                    this[_loc_1] = NaN;
                }
                else if (this[_loc_1] is String)
                {
                    this[_loc_1] = "";
                }
                _loc_2++;
            }
            resetTimestamp();
            update();
            return;
        }// end function

        public function fromSharedObject(param1:Object) : void
        {
            var _loc_2:String = null;
            var _loc_3:* = fields.length;
            var _loc_4:int = 0;
            while (_loc_4 < _loc_3)
            {
                
                _loc_2 = fields[_loc_4];
                if (param1[_loc_2])
                {
                    this[_loc_2] = param1[_loc_2];
                }
                _loc_4++;
            }
            if (param1.creation)
            {
                this.creation = param1.creation;
            }
            if (param1.expiration)
            {
                this.expiration = param1.expiration;
            }
            return;
        }// end function

        private function _timestamp(param1:Number) : void
        {
            creation = new Date();
            _timespan = param1;
            if (param1 > 0)
            {
                expiration = new Date(creation.valueOf() + param1);
            }
            return;
        }// end function

        public function isExpired() : Boolean
        {
            var _loc_1:* = new Date();
            var _loc_2:* = expiration.valueOf() - _loc_1.valueOf();
            if (_loc_2 <= 0)
            {
                return true;
            }
            return false;
        }// end function

        public function set expiration(param1:Date) : void
        {
            _expiration = param1;
            return;
        }// end function

        public function get creation() : Date
        {
            return _creation;
        }// end function

        public function valueOf() : String
        {
            var _loc_2:String = null;
            var _loc_3:* = undefined;
            var _loc_1:Array = [];
            var _loc_4:int = 0;
            while (_loc_4 < fields.length)
            {
                
                _loc_2 = fields[_loc_4];
                _loc_3 = this[_loc_2];
                if (_loc_3 is String)
                {
                    if (_loc_3 == "")
                    {
                        _loc_3 = "-";
                        _loc_1.push(_loc_3);
                    }
                    else
                    {
                        _loc_1.push(_loc_3);
                    }
                }
                else if (_loc_3 is Number)
                {
                    if (_loc_3 == 0)
                    {
                        _loc_1.push(_loc_3);
                    }
                    else if (isNaN(_loc_3))
                    {
                        _loc_3 = "-";
                        _loc_1.push(_loc_3);
                    }
                    else
                    {
                        _loc_1.push(_loc_3);
                    }
                }
                _loc_4++;
            }
            return "" + _loc_1.join(".");
        }// end function

        public function toURLString() : String
        {
            return inURL + "=" + valueOf();
        }// end function

        public function get expiration() : Date
        {
            if (_expiration)
            {
                return _expiration;
            }
            return new Date(new Date().valueOf() + 1000);
        }// end function

        public function toSharedObject() : Object
        {
            var _loc_2:String = null;
            var _loc_3:* = undefined;
            var _loc_1:Object = {};
            var _loc_4:int = 0;
            while (_loc_4 < fields.length)
            {
                
                _loc_2 = fields[_loc_4];
                _loc_3 = this[_loc_2];
                if (_loc_3 is String)
                {
                    _loc_1[_loc_2] = _loc_3;
                }
                else if (_loc_3 == 0)
                {
                    _loc_1[_loc_2] = _loc_3;
                }
                else if (isNaN(_loc_3))
                {
                    ;
                }
                else
                {
                    _loc_1[_loc_2] = _loc_3;
                }
                _loc_4++;
            }
            _loc_1.creation = creation;
            _loc_1.expiration = expiration;
            return _loc_1;
        }// end function

        public function toString(param1:Boolean = false) : String
        {
            var _loc_3:String = null;
            var _loc_4:* = undefined;
            var _loc_2:Array = [];
            var _loc_5:* = fields.length;
            var _loc_6:int = 0;
            while (_loc_6 < _loc_5)
            {
                
                _loc_3 = fields[_loc_6];
                _loc_4 = this[_loc_3];
                if (_loc_4 is String)
                {
                    _loc_2.push(_loc_3 + ": \"" + _loc_4 + "\"");
                }
                else if (_loc_4 == 0)
                {
                    _loc_2.push(_loc_3 + ": " + _loc_4);
                }
                else if (isNaN(_loc_4))
                {
                    ;
                }
                else
                {
                    _loc_2.push(_loc_3 + ": " + _loc_4);
                }
                _loc_6++;
            }
            var _loc_7:* = name.toUpperCase() + " {" + _loc_2.join(", ") + "}";
            if (param1)
            {
                _loc_7 = _loc_7 + (" creation:" + creation + ", expiration:" + expiration);
            }
            return _loc_7;
        }// end function

        public function set creation(param1:Date) : void
        {
            _creation = param1;
            return;
        }// end function

    }
}
