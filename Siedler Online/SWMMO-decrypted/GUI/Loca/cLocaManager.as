package GUI.Loca
{
    import Enums.*;
    import flash.events.*;
    import flash.net.*;
    import mx.core.*;
    import mx.events.*;
    import mx.formatters.*;
    import mx.styles.*;
    import nLib.*;

    public class cLocaManager extends EventDispatcher
    {
        private var mFontName:String = "DefaultFontEmbedded";
        private var mLatestChangesXML:cXML;
        private var mLoadedFilesCount:int = 0;
        private var mDefaultLanguage:String = "en-uk";
        private var mSelectedLanguage:String;
        private var mInitialized:Boolean = false;
        private var mXml:cXML;
        private var mTexts:Object;
        private var mCompleteFunction:Function;
        private static var mInstance:cLocaManager;
        public static const DURATION_FORMAT_NORMAL:int = 0;
        private static var formatter:DateFormatter = new DateFormatter();
        public static const DURATION_FORMAT_NUMERIC_SHORT:int = 3;
        private static var date:Date = new Date();
        public static const UNDEFINED:String = "[undefined text]";
        public static const DURATION_FORMAT_NUMERIC:int = 2;
        public static const DURATION_FORMAT_SHORT:int = 1;

        public function cLocaManager(param1:cSingletonEnforcer)
        {
            if (param1 == null)
            {
                throw new Error("cLocaManager is a Sigleton. Use GetInstance() to use this class.");
            }
            return;
        }// end function

        public function GetText(param1:String, param2:String, param3:Array = null) : String
        {
            if (!param2)
            {
                if (!definesMaster.MASTER_VERSION)
                {
                    gMisc.Assert(false, "[Loca] Text identifier must not be null (" + gMisc.GetCallingMethodName() + ").");
                }
                else
                {
                    gMisc.ConsoleOut("[Loca] Text identifier must not be null.");
                }
                return "";
            }
            if (!this.mTexts[param1])
            {
                return "[undefined group]";
            }
            var _loc_4:* = this.mTexts[param1][param2.toLowerCase()];
            if (this.mTexts[param1][param2.toLowerCase()] && _loc_4.length > 0)
            {
                return this.ReplaceVariables(_loc_4, param3);
            }
            if (!definesMaster.MASTER_VERSION)
            {
                gMisc.ConsoleOut("[undefined text] " + param1 + " / " + param2 + " (" + gMisc.GetCallingMethodName() + ")");
            }
            else
            {
                gMisc.ConsoleOut("[undefined text] " + param1 + " / " + param2);
            }
            return UNDEFINED;
        }// end function

        public function LoadLanguage(param1:String) : void
        {
            this.mInitialized = false;
            gMisc.ConsoleOut("Loading language: " + param1);
            this.mSelectedLanguage = param1;
            this.mXml = new cXML();
            this.mXml.LoadFile(gGfxResource.GetGfxFolder_string() + "loca/" + param1 + ".xml", this.LanguageLoaded, false, definesMaster.LOAD_ENC);
            this.mLatestChangesXML = new cXML();
            this.mLatestChangesXML.LoadFile(gGfxResource.GetGfxFolder_string() + "loca/changes_" + param1 + ".xml", this.ChangesLoaded, false, definesMaster.LOAD_ENC);
            return;
        }// end function

        public function FormatDuration(param1:Number, param2:int = 0) : String
        {
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            var _loc_3:* = Math.round(param1 / 1000);
            if (_loc_3 >= 86400)
            {
                _loc_4 = _loc_3 / 86400;
                _loc_5 = _loc_3 % 86400 / 3600;
                _loc_6 = _loc_3 % 3600 / 60;
                _loc_7 = _loc_3 % 60;
                if (param2 == DURATION_FORMAT_NORMAL)
                {
                    return this.GetText(LOCA_GROUP.FORMATS, "Days", [_loc_4.toString()]) + " " + this.GetText(LOCA_GROUP.FORMATS, "Hours", [_loc_5.toString()]) + " " + this.GetText(LOCA_GROUP.FORMATS, "Minutes", [_loc_6.toString()]);
                }
                if (param2 == DURATION_FORMAT_SHORT)
                {
                    return this.GetText(LOCA_GROUP.FORMATS, "DaysShort", [_loc_4.toString()]) + " " + this.GetText(LOCA_GROUP.FORMATS, "HoursShort", [_loc_5.toString()]) + " " + this.GetText(LOCA_GROUP.FORMATS, "MinutesShort", [_loc_6.toString()]);
                }
                if (param2 == DURATION_FORMAT_NUMERIC_SHORT)
                {
                    return _loc_4 + ":" + (_loc_5 > 9 ? (_loc_5) : ("0" + _loc_5)) + ":" + (_loc_6 > 9 ? (_loc_6) : ("0" + _loc_6)) + ":" + (_loc_7 > 9 ? (_loc_7) : ("0" + _loc_7));
                }
            }
            else if (_loc_3 >= 3600)
            {
                _loc_4 = 0;
                _loc_5 = _loc_3 / 3600;
                _loc_6 = _loc_3 % 3600 / 60;
                _loc_7 = _loc_3 % 60;
                if (param2 == DURATION_FORMAT_NORMAL)
                {
                    return this.GetText(LOCA_GROUP.FORMATS, "Hours", [_loc_5.toString()]) + " " + this.GetText(LOCA_GROUP.FORMATS, "Minutes", [_loc_6.toString()]);
                }
                if (param2 == DURATION_FORMAT_SHORT)
                {
                    return this.GetText(LOCA_GROUP.FORMATS, "HoursShort", [_loc_5.toString()]) + " " + this.GetText(LOCA_GROUP.FORMATS, "MinutesShort", [_loc_6.toString()]);
                }
                if (param2 == DURATION_FORMAT_NUMERIC_SHORT)
                {
                    return _loc_5 + ":" + (_loc_6 > 9 ? (_loc_6) : ("0" + _loc_6)) + ":" + (_loc_7 > 9 ? (_loc_7) : ("0" + _loc_7));
                }
            }
            else if (_loc_3 >= 60)
            {
                _loc_4 = 0;
                _loc_5 = 0;
                _loc_6 = _loc_3 / 60;
                _loc_7 = _loc_3 % 60;
                if (param2 == DURATION_FORMAT_NORMAL)
                {
                    return this.GetText(LOCA_GROUP.FORMATS, "Minutes", [_loc_6.toString()]) + " " + this.GetText(LOCA_GROUP.FORMATS, "Seconds", [_loc_7.toString()]);
                }
                if (param2 == DURATION_FORMAT_SHORT)
                {
                    return this.GetText(LOCA_GROUP.FORMATS, "MinutesShort", [_loc_6.toString()]) + " " + this.GetText(LOCA_GROUP.FORMATS, "SecondsShort", [_loc_7.toString()]);
                }
                if (param2 == DURATION_FORMAT_NUMERIC_SHORT)
                {
                    return _loc_6 + ":" + (_loc_7 > 9 ? (_loc_7) : ("0" + _loc_7));
                }
            }
            else
            {
                _loc_4 = 0;
                _loc_5 = 0;
                _loc_6 = 0;
                _loc_7 = _loc_3 % 60;
                if (param2 == DURATION_FORMAT_NORMAL)
                {
                    return this.GetText(LOCA_GROUP.FORMATS, "Seconds", [_loc_7.toString()]);
                }
                if (param2 == DURATION_FORMAT_SHORT)
                {
                    return this.GetText(LOCA_GROUP.FORMATS, "SecondsShort", [_loc_7.toString()]);
                }
                if (param2 == DURATION_FORMAT_NUMERIC_SHORT)
                {
                    return "00:" + (_loc_7 > 9 ? (_loc_7) : ("0" + _loc_7));
                }
            }
            return _loc_4 + ":" + (_loc_5 > 9 ? (_loc_5) : ("0" + _loc_5)) + ":" + (_loc_6 > 9 ? (_loc_6) : ("0" + _loc_6));
        }// end function

        private function ChangesLoaded(event:Event) : void
        {
            this.mLatestChangesXML.SetXMLString((event.currentTarget as URLLoader).data);
            var _loc_2:String = this;
            var _loc_3:* = this.mLoadedFilesCount + 1;
            _loc_2.mLoadedFilesCount = _loc_3;
            this.LoadLanguageComplete(event);
            return;
        }// end function

        private function ReplaceVariables(param1:String, param2:Array) : String
        {
            var _loc_4:Array = null;
            var _loc_5:int = 0;
            var _loc_6:String = null;
            var _loc_7:String = null;
            if (!param2)
            {
                return param1;
            }
            var _loc_3:int = 0;
            while (_loc_3 < param2.length)
            {
                
                _loc_4 = param1.match(new RegExp("{(" + _loc_3 + "|" + _loc_3 + ",[A-Z]{1,3})}", "g"));
                if (_loc_4)
                {
                    _loc_5 = 0;
                    while (_loc_5 < _loc_4.length)
                    {
                        
                        if ((_loc_4[_loc_5] as String).indexOf(",") > 0)
                        {
                            _loc_7 = (_loc_4[_loc_5] as String).split(",")[1];
                            _loc_7 = _loc_7.substr(0, (_loc_7.length - 1));
                            _loc_6 = this.GetText(_loc_7, param2[_loc_3]);
                        }
                        else
                        {
                            _loc_6 = param2[_loc_3];
                        }
                        param1 = param1.replace(_loc_4[_loc_5], _loc_6);
                        _loc_5++;
                    }
                }
                _loc_3++;
            }
            return param1;
        }// end function

        public function SetDefaultLanguage(param1:String) : void
        {
            this.mDefaultLanguage = param1;
            return;
        }// end function

        private function LanguageLoaded(event:Event) : void
        {
            this.mXml.SetXMLString((event.currentTarget as URLLoader).data);
            var _loc_2:String = this;
            var _loc_3:* = this.mLoadedFilesCount + 1;
            _loc_2.mLoadedFilesCount = _loc_3;
            this.LoadLanguageComplete(event);
            return;
        }// end function

        private function LoadLanguageComplete(event:Event) : void
        {
            var _loc_2:String = null;
            var _loc_3:cXML = null;
            var _loc_4:IEventDispatcher = null;
            var _loc_5:cXML = null;
            if (this.mLoadedFilesCount < 2)
            {
                return;
            }
            this.mLoadedFilesCount = 0;
            this.mTexts = new Object();
            for each (_loc_3 in this.mXml.MoveToSubNode("translations").CreateChildrenArray())
            {
                
                _loc_2 = _loc_3.GetAttributeString_string("name");
                this.mTexts[_loc_2] = new Object();
                for each (_loc_5 in _loc_3.CreateChildrenArray())
                {
                    
                    this.mTexts[_loc_2][_loc_5.GetAttributeString_string("id").toLowerCase()] = _loc_5.GetAttributeString_string("text");
                }
            }
            for each (_loc_3 in this.mLatestChangesXML.MoveToSubNode("translations").CreateChildrenArray())
            {
                
                _loc_2 = _loc_3.GetAttributeString_string("name");
                for each (_loc_5 in _loc_3.CreateChildrenArray())
                {
                    
                    this.mTexts[_loc_2][_loc_5.GetAttributeString_string("id").toLowerCase()] = _loc_5.GetAttributeString_string("text");
                }
            }
            dispatchEvent(new Event("languageChanged"));
            this.mInitialized = true;
            switch(this.mSelectedLanguage)
            {
                case "zh-cn":
                {
                    _loc_4 = StyleManager.loadStyleDeclarations(gGfxResource.GetGfxFolder_string() + "loca/styles/zh_cn.swf");
                    break;
                }
                default:
                {
                    _loc_4 = StyleManager.loadStyleDeclarations(gGfxResource.GetGfxFolder_string() + "loca/styles/defa.swf");
                    break;
                }
            }
            _loc_4.addEventListener(StyleEvent.COMPLETE, this.InitFonts);
            return;
        }// end function

        public function FormatDate(param1:Number) : String
        {
            date.setTime(param1);
            formatter.formatString = cLocaManager.GetInstance().GetText(LOCA_GROUP.FORMATS, "Date");
            return formatter.format(date);
        }// end function

        public function GetGroup(param1:String) : Object
        {
            return this.mTexts[param1];
        }// end function

        public function Init(param1:Function) : void
        {
            this.mCompleteFunction = param1;
            this.LoadLanguage(this.mDefaultLanguage);
            return;
        }// end function

        public function IsInitialized() : Boolean
        {
            return this.mInitialized;
        }// end function

        private function InitFonts(event:Event) : void
        {
            this.mFontName = Application.application.getStyle("fontFamily");
            globalFlash.gui.InitFonts(this.mFontName);
            if (this.mCompleteFunction != null)
            {
                this.mCompleteFunction(event);
            }
            this.mCompleteFunction = null;
            gMisc.ConsoleOut("Language loaded: " + this.mSelectedLanguage);
            return;
        }// end function

        public static function GetInstance() : cLocaManager
        {
            if (mInstance == null)
            {
                mInstance = new cLocaManager(new cSingletonEnforcer());
            }
            return mInstance;
        }// end function

    }
}
