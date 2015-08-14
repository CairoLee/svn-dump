package com.bluebyte.bluefire.api.controller
{

    public class TextController extends Object
    {
        private var _textList:Object;
        public static const UNDEFINED:String = "[undefined text]";
        private static var _instance:TextController;

        public function TextController(param1:SingletonEnforcer)
        {
            this._textList = new Object();
            if (param1 == null)
            {
                throw new Error("TextController is a Sigleton. Use instance to use this class.");
            }
            return;
        }// end function

        private function replaceVariables(param1:String, param2:Array) : String
        {
            var _loc_4:Array = null;
            var _loc_5:String = null;
            if (!param2)
            {
                return param1;
            }
            var _loc_3:int = 0;
            while (_loc_3 < param2.length)
            {
                
                _loc_4 = param1.match("{(" + _loc_3 + "|" + _loc_3 + ",[A-Z]{1,3})}");
                if (_loc_4)
                {
                    if ((_loc_4[1] as String).indexOf(",") > 0)
                    {
                        _loc_5 = this.getText(param2[_loc_3]);
                    }
                    else
                    {
                        _loc_5 = param2[_loc_3];
                    }
                    param1 = param1.replace(_loc_4[0], _loc_5);
                }
                _loc_3++;
            }
            return param1;
        }// end function

        public function getText(param1:String, param2:Array = null) : String
        {
            if (!param1)
            {
                throw new Error(false, "Text identifier must not be null.");
            }
            var _loc_3:* = this._textList[param1.toLowerCase()];
            if (_loc_3 && _loc_3.length > 0)
            {
                return this.replaceVariables(_loc_3, param2);
            }
            trace(UNDEFINED + " / " + param1);
            return UNDEFINED;
        }// end function

        public function registerIdentifier(param1:String, param2:String) : void
        {
            if (this._textList.hasOwnProperty(param1.toLowerCase()))
            {
                throw new Error("Identifier: " + param1.toLowerCase() + " already registered!");
            }
            this._textList[param1.toLowerCase()] = param2;
            return;
        }// end function

        public static function get instance() : TextController
        {
            if (_instance == null)
            {
                _instance = new TextController(new SingletonEnforcer());
            }
            return _instance;
        }// end function

    }
}
