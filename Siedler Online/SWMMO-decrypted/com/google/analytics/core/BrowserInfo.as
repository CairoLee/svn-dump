package com.google.analytics.core
{
    import com.google.analytics.utils.*;
    import com.google.analytics.v4.*;

    public class BrowserInfo extends Object
    {
        private var _config:Configuration;
        private var _info:Environment;

        public function BrowserInfo(param1:Configuration, param2:Environment)
        {
            _config = param1;
            _info = param2;
            return;
        }// end function

        public function get utmul() : String
        {
            return _info.language.toLowerCase();
        }// end function

        public function get utmje() : String
        {
            return "0";
        }// end function

        public function toURLString() : String
        {
            var _loc_1:* = toVariables();
            return _loc_1.toString();
        }// end function

        public function get utmsr() : String
        {
            return _info.screenWidth + "x" + _info.screenHeight;
        }// end function

        public function get utmfl() : String
        {
            var _loc_1:Version = null;
            if (_config.detectFlash)
            {
                _loc_1 = _info.flashVersion;
                return _loc_1.major + "." + _loc_1.minor + " r" + _loc_1.build;
            }
            return "-";
        }// end function

        public function get utmcs() : String
        {
            return _info.languageEncoding;
        }// end function

        public function toVariables() : Variables
        {
            var _loc_1:* = new Variables();
            _loc_1.URIencode = true;
            _loc_1.utmcs = utmcs;
            _loc_1.utmsr = utmsr;
            _loc_1.utmsc = utmsc;
            _loc_1.utmul = utmul;
            _loc_1.utmje = utmje;
            _loc_1.utmfl = utmfl;
            return _loc_1;
        }// end function

        public function get utmsc() : String
        {
            return _info.screenColorDepth + "-bit";
        }// end function

    }
}
