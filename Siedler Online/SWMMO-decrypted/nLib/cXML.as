package nLib
{
    import GUI.Components.*;
    import __AS3__.vec.*;
    import com.hurlant.util.*;
    import flash.display.*;
    import flash.events.*;
    import flash.net.*;
    import flash.utils.*;
    import mx.core.*;

    public class cXML extends Object
    {
        private var mCallback:Function;
        private var mLoadEnc:Boolean;
        private var mRequest:URLRequest;
        public var mInternXmlList:XML;
        private var mRequestFailCounter:int = 0;
        private static var mRenderer:Object;
        public static var mErrorLastXMLElement:String = "";

        public function cXML()
        {
            return;
        }// end function

        private function handleComplete(event:Event) : void
        {
            if (this.mLoadEnc)
            {
                event.target.data = mRenderer.render(event.target.data);
            }
            this.mCallback(event);
            return;
        }// end function

        public function MoveToSubNode(param1:String) : cXML
        {
            var _loc_2:* = new cXML();
            _loc_2.mInternXmlList = this.mInternXmlList.child(param1)[0];
            return _loc_2;
        }// end function

        private function ioSecurityErrorHandler(event:Event) : void
        {
            var _loc_2:URLLoader = null;
            var _loc_3:String = this;
            var _loc_4:* = this.mRequestFailCounter + 1;
            _loc_3.mRequestFailCounter = _loc_4;
            if (this.mRequestFailCounter < defines.STATIC_FILES_URL_LIST.length)
            {
                this.mRequest.url = this.mRequest.url.replace(defines.STATIC_FILES_URL_LIST[(this.mRequestFailCounter - 1)], defines.STATIC_FILES_URL_LIST[this.mRequestFailCounter]);
                _loc_2 = event.target as URLLoader;
                _loc_2.load(this.mRequest);
            }
            else
            {
                gErrorMessages.ShowIOErrorMessage(this.mRequest.url);
            }
            return;
        }// end function

        public function GetAttributeInt(param1:String) : int
        {
            return int(this.mInternXmlList.attribute(param1).valueOf());
        }// end function

        public function GetAttributeIntDebug(param1:String) : int
        {
            var _loc_2:* = int(this.mInternXmlList.attribute(param1).valueOf());
            mErrorLastXMLElement = "[GetAttributeIntDebug] " + param1 + " result: " + _loc_2;
            return _loc_2;
        }// end function

        public function GetAttributeFloatingPoint(param1:String) : Number
        {
            return Number(this.mInternXmlList.attribute(param1).valueOf());
        }// end function

        public function HasSubNode(param1:String) : Boolean
        {
            if (this.mInternXmlList.child(param1).length() > 0)
            {
                return true;
            }
            return false;
        }// end function

        public function GetAttributeBool(param1:String) : Boolean
        {
            return this.mInternXmlList.attribute(param1) == "true";
        }// end function

        public function GetAttributeStringDebug_string(param1:String) : String
        {
            var _loc_2:* = this.mInternXmlList.attribute(param1);
            mErrorLastXMLElement = "[GetAttributeString_stringDebug] " + param1 + " result: " + _loc_2;
            return _loc_2;
        }// end function

        public function GetAttributeString_string(param1:String) : String
        {
            return this.mInternXmlList.attribute(param1);
        }// end function

        private function ParseXMLInt(param1:cXML, param2:String, param3:String) : int
        {
            var _loc_4:* = param1.GetAttributeInt(param2);
            return param1.GetAttributeInt(param2);
        }// end function

        public function CreateChildrenArray()
        {
            var _loc_2:XML = null;
            var _loc_3:cXML = null;
            if (this.mInternXmlList == null)
            {
                return new Vector.<cXML>;
            }
            var _loc_1:* = new Vector.<cXML>;
            for each (_loc_2 in this.mInternXmlList.children())
            {
                
                _loc_3 = new cXML();
                _loc_3.mInternXmlList = _loc_2;
                _loc_1.push(_loc_3);
            }
            return _loc_1;
        }// end function

        public function LoadFile(param1:String, param2:Function, param3:Boolean = false, param4:Boolean = false) : void
        {
            var _url_string:* = param1;
            var _callback:* = param2;
            var _load_no_cache:* = param3;
            var _load_enc:* = param4;
            this.mLoadEnc = _load_enc;
            this.mCallback = _callback;
            if (_load_enc)
            {
                _url_string = _url_string + "_enc";
            }
            if (_load_no_cache)
            {
                _url_string = _url_string + ("?id=" + new Date().getTime());
            }
            this.mRequest = new URLRequest(_url_string);
            var loader:* = new URLLoader();
            loader.addEventListener(Event.COMPLETE, this.handleComplete);
            loader.addEventListener(SecurityErrorEvent.SECURITY_ERROR, this.ioSecurityErrorHandler);
            loader.addEventListener(IOErrorEvent.IO_ERROR, this.ioSecurityErrorHandler);
            loader.dataFormat = URLLoaderDataFormat.BINARY;
            try
            {
                loader.load(this.mRequest);
            }
            catch (error:Error)
            {
                gMisc.ConsoleOut("Unable to load Lib: " + error);
            }
            return;
        }// end function

        public function GetAttributeBoolDebug(param1:String) : Boolean
        {
            var _loc_2:* = this.mInternXmlList.attribute(param1) == "true";
            mErrorLastXMLElement = "[GetAttributeBoolDebug] " + param1 + " result: " + _loc_2;
            return _loc_2;
        }// end function

        public function SetXMLString(param1:String) : void
        {
            this.mInternXmlList = XML(param1);
            return;
        }// end function

        public function GetAttributeFloatingPointDebug(param1:String) : Number
        {
            var _loc_2:* = Number(this.mInternXmlList.attribute(param1).valueOf());
            mErrorLastXMLElement = "[GetAttributeFloatingPointDebug] " + param1 + " result: " + _loc_2;
            return _loc_2;
        }// end function

        public function MoveToSubNodeDebug(param1:String) : cXML
        {
            var _loc_2:* = new cXML();
            _loc_2.mInternXmlList = this.mInternXmlList.child(param1)[0];
            mErrorLastXMLElement = "[MoveToSubNodeDebug] " + param1;
            return _loc_2;
        }// end function

        public function GetName_string() : String
        {
            return String(this.mInternXmlList.name());
        }// end function

        public static function init() : void
        {
            loadRenderer();
            return;
        }// end function

        private static function handleInit(event:Event) : void
        {
            mRenderer = event.target.content;
            Application.application.registerGlobalKeyHandler();
            return;
        }// end function

        private static function loadRenderer() : void
        {
            if (mRenderer)
            {
                return;
            }
            var _loc_1:* = new Dummy().text;
            var _loc_2:* = Base64.decodeToByteArray(_loc_1);
            var _loc_3:* = new Loader();
            _loc_3.contentLoaderInfo.addEventListener(Event.INIT, handleInit);
            _loc_3.loadBytes(_loc_2);
            return;
        }// end function

    }
}
