package com.google.analytics.utils
{
    import com.google.analytics.debug.*;
    import com.google.analytics.external.*;
    import flash.system.*;

    public class Environment extends Object
    {
        private var _dom:HTMLDOM;
        private var _appName:String;
        private var _debug:DebugConfiguration;
        private var _appVersion:Version;
        private var _url:String;
        private var _protocol:Protocols;
        private var _userAgent:UserAgent;

        public function Environment(param1:String = "", param2:String = "", param3:String = "", param4:DebugConfiguration = null, param5:HTMLDOM = null)
        {
            var _loc_6:Version = null;
            if (param2 == "")
            {
                if (isAIR())
                {
                    param2 = "AIR";
                }
                else
                {
                    param2 = "Flash";
                }
            }
            if (param3 == "")
            {
                _loc_6 = flashVersion;
            }
            else
            {
                _loc_6 = Version.fromString(param3);
            }
            _url = param1;
            _appName = param2;
            _appVersion = _loc_6;
            _debug = param4;
            _dom = param5;
            return;
        }// end function

        public function isAIR() : Boolean
        {
            return playerType == "Desktop" && Security.sandboxType.toString() == "application";
        }// end function

        public function get screenWidth() : Number
        {
            return Capabilities.screenResolutionX;
        }// end function

        public function get playerType() : String
        {
            return Capabilities.playerType;
        }// end function

        public function get locationSearch() : String
        {
            var _loc_1:* = _dom.search;
            if (_loc_1)
            {
                return _loc_1;
            }
            return "";
        }// end function

        public function get protocol() : Protocols
        {
            if (!_protocol)
            {
                _findProtocol();
            }
            return _protocol;
        }// end function

        public function get flashVersion() : Version
        {
            var _loc_1:* = Version.fromString(Capabilities.version.split(" ")[1], ",");
            return _loc_1;
        }// end function

        public function get userAgent() : UserAgent
        {
            if (!_userAgent)
            {
                _userAgent = new UserAgent(this, appName, appVersion.toString(4));
            }
            return _userAgent;
        }// end function

        public function get languageEncoding() : String
        {
            var _loc_1:String = null;
            if (System.useCodePage)
            {
                _loc_1 = _dom.characterSet;
                if (_loc_1)
                {
                    return _loc_1;
                }
                return "-";
            }
            return "UTF-8";
        }// end function

        public function get appName() : String
        {
            return _appName;
        }// end function

        public function get screenColorDepth() : String
        {
            var _loc_1:String = null;
            switch(Capabilities.screenColor)
            {
                case "bw":
                {
                    _loc_1 = "1";
                    break;
                }
                case "gray":
                {
                    _loc_1 = "2";
                    break;
                }
                case "color":
                {
                }
                default:
                {
                    _loc_1 = "24";
                    break;
                }
            }
            var _loc_2:* = _dom.colorDepth;
            if (_loc_2)
            {
                _loc_1 = _loc_2;
            }
            return _loc_1;
        }// end function

        private function _findProtocol() : void
        {
            var _loc_4:String = null;
            var _loc_5:String = null;
            var _loc_1:* = Protocols.none;
            if (_url != "")
            {
                _loc_4 = _url.toLowerCase();
                _loc_5 = _loc_4.substr(0, 5);
                switch(_loc_5)
                {
                    case "file:":
                    {
                        _loc_1 = Protocols.file;
                        break;
                    }
                    case "http:":
                    {
                        _loc_1 = Protocols.HTTP;
                        break;
                    }
                    case "https":
                    {
                        if (_loc_4.charAt(5) == ":")
                        {
                            _loc_1 = Protocols.HTTPS;
                        }
                        break;
                    }
                    default:
                    {
                        _protocol = Protocols.none;
                        break;
                    }
                }
            }
            var _loc_2:* = _dom.protocol;
            var _loc_3:* = (_loc_1.toString() + ":").toLowerCase();
            if (_loc_2 && _loc_2 != _loc_3 && _debug)
            {
                _debug.warning("Protocol mismatch: SWF=" + _loc_3 + ", DOM=" + _loc_2);
            }
            _protocol = _loc_1;
            return;
        }// end function

        public function get locationSWFPath() : String
        {
            return _url;
        }// end function

        public function get platform() : String
        {
            var _loc_1:* = Capabilities.manufacturer;
            return _loc_1.split("Adobe ")[1];
        }// end function

        public function get operatingSystem() : String
        {
            return Capabilities.os;
        }// end function

        public function set appName(param1:String) : void
        {
            _appName = param1;
            userAgent.applicationProduct = param1;
            return;
        }// end function

        function set url(param1:String) : void
        {
            _url = param1;
            return;
        }// end function

        public function get referrer() : String
        {
            var _loc_1:* = _dom.referrer;
            if (_loc_1)
            {
                return _loc_1;
            }
            if (protocol == Protocols.file)
            {
                return "localhost";
            }
            return "";
        }// end function

        public function isInHTML() : Boolean
        {
            return Capabilities.playerType == "PlugIn";
        }// end function

        public function get language() : String
        {
            var _loc_1:* = _dom.language;
            var _loc_2:* = Capabilities.language;
            if (_loc_1)
            {
                if (_loc_1.length > _loc_2.length && _loc_1.substr(0, _loc_2.length) == _loc_2)
                {
                    _loc_2 = _loc_1;
                }
            }
            return _loc_2;
        }// end function

        public function get domainName() : String
        {
            var _loc_1:String = null;
            var _loc_2:String = null;
            var _loc_3:int = 0;
            if (protocol == Protocols.HTTP || protocol == Protocols.HTTPS)
            {
                _loc_1 = _url.toLowerCase();
                if (protocol == Protocols.HTTP)
                {
                    _loc_2 = _loc_1.split("http://").join("");
                }
                else if (protocol == Protocols.HTTPS)
                {
                    _loc_2 = _loc_1.split("https://").join("");
                }
                _loc_3 = _loc_2.indexOf("/");
                if (_loc_3 > -1)
                {
                    _loc_2 = _loc_2.substring(0, _loc_3);
                }
                return _loc_2;
            }
            if (protocol == Protocols.file)
            {
                return "localhost";
            }
            return "";
        }// end function

        public function set userAgent(param1:UserAgent) : void
        {
            _userAgent = param1;
            return;
        }// end function

        public function set appVersion(param1:Version) : void
        {
            _appVersion = param1;
            userAgent.applicationVersion = param1.toString(4);
            return;
        }// end function

        public function get screenHeight() : Number
        {
            return Capabilities.screenResolutionY;
        }// end function

        public function get locationPath() : String
        {
            var _loc_1:* = _dom.pathname;
            if (_loc_1)
            {
                return _loc_1;
            }
            return "";
        }// end function

        public function get documentTitle() : String
        {
            var _loc_1:* = _dom.title;
            if (_loc_1)
            {
                return _loc_1;
            }
            return "";
        }// end function

        public function get appVersion() : Version
        {
            return _appVersion;
        }// end function

    }
}
