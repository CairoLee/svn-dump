package com.google.analytics.data
{

    public class X10 extends Object
    {
        private var _delimEnd:String = ")";
        private var _minimum:int;
        private var _delimSet:String = "*";
        private var _escapeChar:String = "\'";
        private var _delimBegin:String = "(";
        private var _delimNumValue:String = "!";
        private var _key:String = "k";
        private var _set:Array;
        private var _hasData:int;
        private var _escapeCharMap:Object;
        private var _projectData:Object;
        private var _value:String = "v";

        public function X10()
        {
            _set = [_key, _value];
            _projectData = {};
            _escapeCharMap = {};
            _escapeCharMap[_escapeChar] = "\'0";
            _escapeCharMap[_delimEnd] = "\'1";
            _escapeCharMap[_delimSet] = "\'2";
            _escapeCharMap[_delimNumValue] = "\'3";
            _minimum = 1;
            return;
        }// end function

        private function _setInternal(param1:Number, param2:String, param3:Number, param4:String) : void
        {
            if (!hasProject(param1))
            {
                _projectData[param1] = {};
            }
            if (_projectData[param1][param2] == undefined)
            {
                _projectData[param1][param2] = [];
            }
            _projectData[param1][param2][param3] = param4;
            (_hasData + 1);
            return;
        }// end function

        private function _renderProject(param1:Object) : String
        {
            var _loc_4:int = 0;
            var _loc_5:Array = null;
            var _loc_2:String = "";
            var _loc_3:Boolean = false;
            var _loc_6:* = _set.length;
            _loc_4 = 0;
            while (_loc_4 < _loc_6)
            {
                
                _loc_5 = param1[_set[_loc_4]];
                if (_loc_5)
                {
                    if (_loc_3)
                    {
                        _loc_2 = _loc_2 + _set[_loc_4];
                    }
                    _loc_2 = _loc_2 + _renderDataType(_loc_5);
                    _loc_3 = false;
                }
                else
                {
                    _loc_3 = true;
                }
                _loc_4++;
            }
            return _loc_2;
        }// end function

        public function hasProject(param1:Number) : Boolean
        {
            return _projectData[param1];
        }// end function

        public function clearKey(param1:Number) : void
        {
            _clearInternal(param1, _key);
            return;
        }// end function

        private function _renderDataType(param1:Array) : String
        {
            var _loc_3:String = null;
            var _loc_4:int = 0;
            var _loc_2:Array = [];
            _loc_4 = 0;
            while (_loc_4 < param1.length)
            {
                
                if (param1[_loc_4] != undefined)
                {
                    _loc_3 = "";
                    if (_loc_4 != _minimum && param1[(_loc_4 - 1)] == undefined)
                    {
                        _loc_3 = _loc_3 + _loc_4.toString();
                        _loc_3 = _loc_3 + _delimNumValue;
                    }
                    _loc_3 = _loc_3 + _escapeExtensibleValue(param1[_loc_4]);
                    _loc_2.push(_loc_3);
                }
                _loc_4++;
            }
            return _delimBegin + _loc_2.join(_delimSet) + _delimEnd;
        }// end function

        public function getKey(param1:Number, param2:Number) : String
        {
            return _getInternal(param1, _key, param2) as String;
        }// end function

        public function hasData() : Boolean
        {
            return _hasData > 0;
        }// end function

        public function renderMergedUrlString(param1:X10 = null) : String
        {
            var _loc_3:String = null;
            if (!param1)
            {
                return renderUrlString();
            }
            var _loc_2:Array = [param1.renderUrlString()];
            for (_loc_3 in _projectData)
            {
                
                if (hasProject(Number(_loc_3)) && !param1.hasProject(Number(_loc_3)))
                {
                    _loc_2.push(_loc_3 + _renderProject(_projectData[_loc_3]));
                }
            }
            return _loc_2.join("");
        }// end function

        public function setValue(param1:Number, param2:Number, param3:Number) : Boolean
        {
            if (Math.round(param3) != param3 || isNaN(param3) || param3 == Infinity)
            {
                return false;
            }
            _setInternal(param1, _value, param2, param3.toString());
            return true;
        }// end function

        public function renderUrlString() : String
        {
            var _loc_2:String = null;
            var _loc_1:Array = [];
            for (_loc_2 in _projectData)
            {
                
                if (hasProject(Number(_loc_2)))
                {
                    _loc_1.push(_loc_2 + _renderProject(_projectData[_loc_2]));
                }
            }
            return _loc_1.join("");
        }// end function

        private function _getInternal(param1:Number, param2:String, param3:Number) : Object
        {
            if (hasProject(param1) && _projectData[param1][param2] != undefined)
            {
                return _projectData[param1][param2][param3];
            }
            return undefined;
        }// end function

        public function setKey(param1:Number, param2:Number, param3:String) : Boolean
        {
            _setInternal(param1, _key, param2, param3);
            return true;
        }// end function

        public function clearValue(param1:Number) : void
        {
            _clearInternal(param1, _value);
            return;
        }// end function

        private function _clearInternal(param1:Number, param2:String) : void
        {
            var _loc_3:Boolean = false;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            if (hasProject(param1) && _projectData[param1][param2] != undefined)
            {
                _projectData[param1][param2] = undefined;
                _loc_3 = true;
                _loc_5 = _set.length;
                _loc_4 = 0;
                while (_loc_4 < _loc_5)
                {
                    
                    if (_projectData[param1][_set[_loc_4]] != undefined)
                    {
                        _loc_3 = false;
                        break;
                    }
                    _loc_4++;
                }
                if (_loc_3)
                {
                    _projectData[param1] = undefined;
                    (_hasData - 1);
                }
            }
            return;
        }// end function

        public function getValue(param1:Number, param2:Number)
        {
            var _loc_3:* = _getInternal(param1, _value, param2);
            if (_loc_3 == null)
            {
                return null;
            }
            return Number(_loc_3);
        }// end function

        private function _escapeExtensibleValue(param1:String) : String
        {
            var _loc_3:int = 0;
            var _loc_4:String = null;
            var _loc_5:String = null;
            var _loc_2:String = "";
            _loc_3 = 0;
            while (_loc_3 < param1.length)
            {
                
                _loc_4 = param1.charAt(_loc_3);
                _loc_5 = _escapeCharMap[_loc_4];
                if (_loc_5)
                {
                    _loc_2 = _loc_2 + _loc_5;
                }
                else
                {
                    _loc_2 = _loc_2 + _loc_4;
                }
                _loc_3++;
            }
            return _loc_2;
        }// end function

    }
}
