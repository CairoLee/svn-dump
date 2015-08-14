package nLib
{
    import Communication.VO.*;
    import flash.net.*;
    import flash.utils.*;
    import mx.collections.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.utils.*;

    public class gMisc extends Object
    {
        private static var mProfileGlobalTime:Number = 0;
        private static var mProfileGlobalTimeCounter:int = 0;
        private static var mLastProfileGlobalTime:Number = -1;
        private static const PROFILER_UPDATE_INTERVALL:int = 10;
        public static const PROFILE_ACTIVE:Boolean = false;

        public function gMisc()
        {
            return;
        }// end function

        public static function AsciiKeyCode(param1:String) : int
        {
            return param1.charCodeAt(0);
        }// end function

        public static function ParseFloat(param1:String) : Number
        {
            return parseFloat(param1);
        }// end function

        public static function ReadObjectFromStringBytes(param1:String) : Object
        {
            var _loc_2:* = new Base64Decoder();
            _loc_2.decode(param1);
            var _loc_3:* = _loc_2.drain();
            _loc_3.position = 0;
            return _loc_3.readObject();
        }// end function

        public static function ProfileInfoText_string() : String
        {
            if (!PROFILE_ACTIVE)
            {
                return null;
            }
            var _loc_1:String = "-- Profile Info --\n";
            return _loc_1;
        }// end function

        public static function IntToObject(param1:int) : Object
        {
            var _loc_2:* = param1 as Object;
            return _loc_2;
        }// end function

        public static function ProfilerEnd(param1:String) : void
        {
            if (!PROFILE_ACTIVE)
            {
            }
            return;
        }// end function

        public static function ReplaceRightAlign_string(param1:String, param2:String) : String
        {
            return param2.substr(0, param2.length - param1.length) + param1;
        }// end function

        public static function GetObject(param1:Object, param2:Object)
        {
            var _loc_5:Object = null;
            var _loc_6:Object = null;
            var _loc_7:* = undefined;
            if (param1 == null || !param1.hasOwnProperty("metadata"))
            {
                return param1;
            }
            if (!param1.metadata.hasOwnProperty("type"))
            {
                return param1;
            }
            var _loc_3:* = getClassByAlias(param1.metadata.type);
            if (_loc_3 == null)
            {
                return param1;
            }
            var _loc_4:* = new _loc_3;
            for (_loc_5 in param1)
            {
                
                if (_loc_5 === "metadata")
                {
                    continue;
                }
                if (param1[_loc_5] != null)
                {
                    if (param1[_loc_5].hasOwnProperty("object"))
                    {
                        if (param1[_loc_5].object is ArrayCollection)
                        {
                            _loc_4[_loc_5] = new ArrayCollection();
                            if (param2 != null)
                            {
                                param2[_loc_5] = new ArrayCollection();
                            }
                            for each (_loc_6 in ArrayCollection(param1[_loc_5].object))
                            {
                                
                                _loc_7 = GetObject(_loc_6, param2);
                                ArrayCollection(_loc_4[_loc_5]).addItem(_loc_7);
                            }
                        }
                        else
                        {
                            _loc_4[_loc_5] = GetObject(param1[_loc_5].object, param2);
                            if (param2 != null)
                            {
                                param2[_loc_5] = _loc_4[_loc_5];
                            }
                        }
                        continue;
                    }
                    _loc_4[_loc_5] = param1[_loc_5];
                    if (param2 != null)
                    {
                        param2[_loc_5] = _loc_4[_loc_5];
                    }
                }
            }
            return _loc_4;
        }// end function

        public static function ConsoleOut(param1:String) : void
        {
            return;
        }// end function

        public static function GetExtensionString(param1:String) : String
        {
            return param1.substr(param1.lastIndexOf("."));
        }// end function

        public static function Replace_string(param1:String, param2:String) : String
        {
            return param1 + param2.substr(param1.length);
        }// end function

        public static function ReplaceRegEx_string(param1:String, param2:String, param3:String) : String
        {
            return param1.replace(param2, param3);
        }// end function

        public static function InitTimeSinceStartup() : void
        {
            return;
        }// end function

        public static function GetFileNameWithoutExtensionString(param1:String) : String
        {
            return param1.substr(0, param1.lastIndexOf("."));
        }// end function

        public static function GetTimeSinceStartup() : int
        {
            return getTimer();
        }// end function

        public static function ObjectToDouble(param1:Object) : Number
        {
            var _loc_2:* = param1 as dNumberVO;
            return _loc_2.value;
        }// end function

        public static function Trim_string(param1:String, param2:String) : String
        {
            return TrimBack_string(TrimFront_string(param1, param2), param2);
        }// end function

        public static function GetRandomMinMax(param1:Number, param2:Number) : Number
        {
            var _loc_3:* = (param2 + 1) - param1;
            return Math.random() * _loc_3 + param1;
        }// end function

        public static function ConvertIntToStringRadix_string(param1:int, param2:int) : String
        {
            return param1.toString(param2);
        }// end function

        private static function StringToCharacter_string(param1:String) : String
        {
            if (param1.length == 1)
            {
                return param1;
            }
            return param1.slice(0, 1);
        }// end function

        public static function GetMaxIntValue() : int
        {
            return 2147483647;
        }// end function

        public static function DoubleToObject(param1:Number) : Object
        {
            var _loc_2:* = new dNumberVO();
            _loc_2.value = param1;
            return _loc_2;
        }// end function

        public static function GetRandomMinMaxInt(param1:int, param2:int) : int
        {
            var _loc_3:* = (param2 + 1) - param1;
            return Math.random() * _loc_3 + param1;
        }// end function

        public static function ProfileReset() : void
        {
            return;
        }// end function

        public static function ConvertIntToString_string(param1:int) : String
        {
            return param1.toString();
        }// end function

        public static function TrimFront_string(param1:String, param2:String) : String
        {
            param2 = StringToCharacter_string(param2);
            if (param1.charAt(0) == param2)
            {
                param1 = TrimFront_string(param1.substring(1), param2);
            }
            return param1;
        }// end function

        public static function SerializeToString(param1:Object) : String
        {
            if (param1 == null)
            {
                throw new Error("null isn\'t a legal serialization candidate");
            }
            var _loc_2:* = new ByteArray();
            _loc_2.writeObject(param1);
            _loc_2.position = 0;
            var _loc_3:* = new Base64Encoder();
            _loc_3.encode(_loc_2.readUTFBytes(_loc_2.length));
            return _loc_3.drain();
        }// end function

        public static function TrimBack_string(param1:String, param2:String) : String
        {
            param2 = StringToCharacter_string(param2);
            if (param1.charAt((param1.length - 1)) == param2)
            {
                param1 = TrimBack_string(param1.substring(0, (param1.length - 1)), param2);
            }
            return param1;
        }// end function

        public static function IsNaN(param1:Number) : Boolean
        {
            return isNaN(param1);
        }// end function

        public static function ObjectToInt(param1:Object) : int
        {
            var _loc_2:* = param1 as int;
            return _loc_2;
        }// end function

        public static function ProfilerStart(param1:String) : void
        {
            if (!PROFILE_ACTIVE)
            {
            }
            return;
        }// end function

        public static function GetCallingMethodName(param1:int = 1) : String
        {
            var _loc_11:int = 0;
            var _loc_12:String = null;
            var _loc_13:int = 0;
            if (!SWMMO.isDebugPlayer())
            {
                return "";
            }
            var _loc_2:String = "";
            var _loc_3:* = new Error();
            var _loc_4:* = _loc_3.getStackTrace();
            var _loc_5:int = 0;
            switch(param1)
            {
                case 0:
                {
                    _loc_5 = _loc_4.indexOf("at ", (_loc_4.indexOf("at ") + 1));
                    break;
                }
                case 1:
                {
                    _loc_5 = _loc_4.indexOf("at ", (_loc_4.indexOf("at ", (_loc_4.indexOf("at ") + 1)) + 1));
                    break;
                }
                case 2:
                {
                    _loc_5 = _loc_4.indexOf("at ", (_loc_4.indexOf("at ", (_loc_4.indexOf("at ", (_loc_4.indexOf("at ") + 1)) + 1)) + 1));
                    break;
                }
                case 3:
                {
                    _loc_5 = _loc_4.indexOf("at ", (_loc_4.indexOf("at ", (_loc_4.indexOf("at ", (_loc_4.indexOf("at ", (_loc_4.indexOf("at ") + 1)) + 1)) + 1)) + 1));
                    break;
                }
                default:
                {
                    _loc_5 = _loc_4.indexOf("at ", (_loc_4.indexOf("at ", (_loc_4.indexOf("at ") + 1)) + 1));
                    break;
                    break;
                }
            }
            var _loc_6:* = _loc_4.indexOf("[", _loc_5);
            if (_loc_4.indexOf("[", _loc_5) > -1)
            {
                _loc_11 = _loc_4.indexOf("]", (_loc_5 + 1));
                _loc_12 = _loc_4.substring((_loc_6 + 1), _loc_11);
                _loc_13 = _loc_12.lastIndexOf("\\");
                _loc_2 = _loc_12.substring((_loc_13 + 1), _loc_12.length);
            }
            var _loc_7:* = _loc_4.indexOf("()", _loc_5);
            var _loc_8:* = _loc_4.substring(_loc_5 + 3, _loc_7);
            var _loc_9:* = _loc_4.substring(_loc_5 + 3, _loc_7).indexOf("/");
            var _loc_10:* = _loc_8.substring((_loc_9 + 1), _loc_8.length);
            if (_loc_2 != null)
            {
                return _loc_10 + " (" + _loc_2 + ")";
            }
            return _loc_10;
        }// end function

        public static function CloneObject(param1) : Object
        {
            var _loc_2:* = new ByteArray();
            _loc_2.writeObject(param1);
            _loc_2.position = 0;
            return _loc_2.readObject();
        }// end function

        public static function CheatWindowConsoleOut(param1:String) : void
        {
            Application.application.GAMESTATE_ID_CHEAT_WINDOW.console.text = Application.application.GAMESTATE_ID_CHEAT_WINDOW.console.text + (param1 + "\n");
            return;
        }// end function

        public static function FastIntegerSqrt(param1:int) : int
        {
            var _loc_3:int = 0;
            var _loc_5:int = 0;
            var _loc_2:int = 0;
            var _loc_4:* = -param1 - 1;
            _loc_3 = 30;
            while (_loc_3 >= 0)
            {
                
                _loc_2 = _loc_2 + _loc_2;
                _loc_5 = _loc_4 + (2 * _loc_2 + 1 << _loc_3);
                if (_loc_5 < 0)
                {
                    _loc_4 = _loc_5;
                    _loc_2++;
                }
                _loc_3 = _loc_3 - 2;
            }
            return _loc_2;
        }// end function

        public static function GetMaxFloatValue() : Number
        {
            return Number.MAX_VALUE;
        }// end function

        public static function MessageBox(param1:String) : void
        {
            Alert.show(param1);
            return;
        }// end function

        public static function Assert(param1:Boolean, param2:String) : void
        {
            var _loc_3:String = null;
            if (!param1)
            {
                _loc_3 = "Assert! \n" + param2 + "\n\n";
                throw new SyntaxError(_loc_3);
            }
            return;
        }// end function

        public static function ConvertDoubleToString_string(param1:Number) : String
        {
            return param1.toString();
        }// end function

        public static function ConvertDoubleToStringWithDecimalPlaces_string(param1:Number) : String
        {
            return param1.toFixed(2);
        }// end function

        public static function ParseInt(param1:String) : int
        {
            return parseInt(param1);
        }// end function

        public static function GetSubString_string(param1:String, param2:Number, param3:Number) : String
        {
            return param1.substr(param2, param3);
        }// end function

        public static function SearchString(param1:String, param2:String) : int
        {
            return param1.search(param2);
        }// end function

        public static function RemoveExtension(param1:String) : String
        {
            var _loc_2:* = param1.lastIndexOf(".");
            if (_loc_2 != -1)
            {
                return param1.substr(0, _loc_2);
            }
            return param1;
        }// end function

    }
}
