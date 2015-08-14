package com.google.analytics.utils
{

    public class URL extends Object
    {
        private var _url:String;

        public function URL(param1:String = "")
        {
            _url = param1.toLowerCase();
            return;
        }// end function

        public function get domain() : String
        {
            var _loc_1:Array = null;
            if (hostName != "" && hostName.indexOf(".") > -1)
            {
                _loc_1 = hostName.split(".");
                switch(_loc_1.length)
                {
                    case 2:
                    {
                        return hostName;
                    }
                    case 3:
                    {
                        if (_loc_1[1] == "co")
                        {
                            return hostName;
                        }
                        _loc_1.shift();
                        return _loc_1.join(".");
                    }
                    case 4:
                    {
                        _loc_1.shift();
                        return _loc_1.join(".");
                    }
                    default:
                    {
                        break;
                    }
                }
            }
            return "";
        }// end function

        public function get path() : String
        {
            var _loc_1:* = _url;
            if (_loc_1.indexOf("://") > -1)
            {
                _loc_1 = _loc_1.split("://")[1];
            }
            if (_loc_1.indexOf(hostName) == 0)
            {
                _loc_1 = _loc_1.substr(hostName.length);
            }
            if (_loc_1.indexOf("?") > -1)
            {
                _loc_1 = _loc_1.split("?")[0];
            }
            if (_loc_1.charAt(0) != "/")
            {
                _loc_1 = "/" + _loc_1;
            }
            return _loc_1;
        }// end function

        public function get protocol() : Protocols
        {
            var _loc_1:* = _url.split("://")[0];
            switch(_loc_1)
            {
                case "file":
                {
                    return Protocols.file;
                }
                case "http":
                {
                    return Protocols.HTTP;
                }
                case "https":
                {
                    return Protocols.HTTPS;
                }
                default:
                {
                    return Protocols.none;
                    continue;
                }
            }
        }// end function

        public function get hostName() : String
        {
            var _loc_1:* = _url;
            if (_loc_1.indexOf("://") > -1)
            {
                _loc_1 = _loc_1.split("://")[1];
            }
            if (_loc_1.indexOf("/") > -1)
            {
                _loc_1 = _loc_1.split("/")[0];
            }
            if (_loc_1.indexOf("?") > -1)
            {
                _loc_1 = _loc_1.split("?")[0];
            }
            if (protocol == Protocols.file || protocol == Protocols.none)
            {
                return "";
            }
            return _loc_1;
        }// end function

        public function get subDomain() : String
        {
            if (domain != "" && domain != hostName)
            {
                return hostName.split("." + domain).join("");
            }
            return "";
        }// end function

        public function get search() : String
        {
            var _loc_1:* = _url;
            if (_loc_1.indexOf("://") > -1)
            {
                _loc_1 = _loc_1.split("://")[1];
            }
            if (_loc_1.indexOf(hostName) == 0)
            {
                _loc_1 = _loc_1.substr(hostName.length);
            }
            if (_loc_1.indexOf("?") > -1)
            {
                _loc_1 = _loc_1.split("?")[1];
            }
            else
            {
                _loc_1 = "";
            }
            return _loc_1;
        }// end function

    }
}
