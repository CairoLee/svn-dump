package com.google.analytics.external
{
    import com.google.analytics.debug.*;

    public class HTMLDOM extends JavascriptProxy
    {
        private var _referrer:String;
        private var _language:String;
        private var _host:String;
        private var _pathname:String;
        private var _location:String;
        private var _search:String;
        private var _characterSet:String;
        private var _title:String;
        private var _protocol:String;
        private var _colorDepth:String;
        public static var cache_properties_js:XML = <script>
n            <![CDATA[
n                    function()
n                    {
n                        var obj = {};
n                            obj.host         = document.location.host;
n                            obj.language     = navigator.language ? navigator.language : navigator.browserLanguage;
n                            obj.characterSet = document.characterSet ? document.characterSet : document.charset;
n                            obj.colorDepth   = window.screen.colorDepth;
n                            obj.location     = document.location.toString();
n                            obj.pathname     = document.location.pathname;
n                            obj.protocol     = document.location.protocol;
n                            obj.search       = document.location.search;
n                            obj.referrer     = document.referrer;
n                            obj.title        = document.title;
n                        
n                        return obj;
n                    }
n                ]]>
n         </script>")("<script>
            <![CDATA[
                    function()
                    {
                        var obj = {};
                            obj.host         = document.location.host;
                            obj.language     = navigator.language ? navigator.language : navigator.browserLanguage;
                            obj.characterSet = document.characterSet ? document.characterSet : document.charset;
                            obj.colorDepth   = window.screen.colorDepth;
                            obj.location     = document.location.toString();
                            obj.pathname     = document.location.pathname;
                            obj.protocol     = document.location.protocol;
                            obj.search       = document.location.search;
                            obj.referrer     = document.referrer;
                            obj.title        = document.title;
                        
                        return obj;
                    }
                ]]>
         </script>;

        public function HTMLDOM(param1:DebugConfiguration)
        {
            super(param1);
            return;
        }// end function

        public function get search() : String
        {
            if (_search)
            {
                return _search;
            }
            if (!isAvailable())
            {
                return null;
            }
            _search = getProperty("document.location.search");
            return _search;
        }// end function

        public function get location() : String
        {
            if (_location)
            {
                return _location;
            }
            if (!isAvailable())
            {
                return null;
            }
            _location = getPropertyString("document.location");
            return _location;
        }// end function

        public function get pathname() : String
        {
            if (_pathname)
            {
                return _pathname;
            }
            if (!isAvailable())
            {
                return null;
            }
            _pathname = getProperty("document.location.pathname");
            return _pathname;
        }// end function

        public function cacheProperties() : void
        {
            if (!isAvailable())
            {
                return;
            }
            var _loc_1:* = call(cache_properties_js);
            if (_loc_1)
            {
                _host = _loc_1.host;
                _language = _loc_1.language;
                _characterSet = _loc_1.characterSet;
                _colorDepth = _loc_1.colorDepth;
                _location = _loc_1.location;
                _pathname = _loc_1.pathname;
                _protocol = _loc_1.protocol;
                _search = _loc_1.search;
                _referrer = _loc_1.referrer;
                _title = _loc_1.title;
            }
            return;
        }// end function

        public function get language() : String
        {
            if (_language)
            {
                return _language;
            }
            if (!isAvailable())
            {
                return null;
            }
            var _loc_1:* = getProperty("navigator.language");
            if (_loc_1 == null)
            {
                _loc_1 = getProperty("navigator.browserLanguage");
            }
            _language = _loc_1;
            return _language;
        }// end function

        public function get colorDepth() : String
        {
            if (_colorDepth)
            {
                return _colorDepth;
            }
            if (!isAvailable())
            {
                return null;
            }
            _colorDepth = getProperty("window.screen.colorDepth");
            return _colorDepth;
        }// end function

        public function get referrer() : String
        {
            if (_referrer)
            {
                return _referrer;
            }
            if (!isAvailable())
            {
                return null;
            }
            _referrer = getProperty("document.referrer");
            return _referrer;
        }// end function

        public function get protocol() : String
        {
            if (_protocol)
            {
                return _protocol;
            }
            if (!isAvailable())
            {
                return null;
            }
            _protocol = getProperty("document.location.protocol");
            return _protocol;
        }// end function

        public function get host() : String
        {
            if (_host)
            {
                return _host;
            }
            if (!isAvailable())
            {
                return null;
            }
            _host = getProperty("document.location.host");
            return _host;
        }// end function

        public function get characterSet() : String
        {
            if (_characterSet)
            {
                return _characterSet;
            }
            if (!isAvailable())
            {
                return null;
            }
            var _loc_1:* = getProperty("document.characterSet");
            if (_loc_1 == null)
            {
                _loc_1 = getProperty("document.charset");
            }
            _characterSet = _loc_1;
            return _characterSet;
        }// end function

        public function get title() : String
        {
            if (_title)
            {
                return _title;
            }
            if (!isAvailable())
            {
                return null;
            }
            _title = getProperty("document.title");
            return _title;
        }// end function

    }
}
