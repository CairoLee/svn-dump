package com.google.analytics.core
{
    import com.google.analytics.external.*;
    import com.google.analytics.utils.*;
    import com.google.analytics.v4.*;

    public class DocumentInfo extends Object
    {
        private var _pageURL:String;
        private var _utmr:String;
        private var _config:Configuration;
        private var _adSense:AdSenseGlobals;
        private var _info:Environment;

        public function DocumentInfo(param1:Configuration, param2:Environment, param3:String, param4:String = null, param5:AdSenseGlobals = null)
        {
            _config = param1;
            _info = param2;
            _utmr = param3;
            _pageURL = param4;
            _adSense = param5;
            return;
        }// end function

        public function get utmr() : String
        {
            if (!_utmr)
            {
                return "-";
            }
            return _utmr;
        }// end function

        public function toURLString() : String
        {
            var _loc_1:* = toVariables();
            return _loc_1.toString();
        }// end function

        private function _renderPageURL(param1:String = "") : String
        {
            var _loc_2:* = _info.locationPath;
            var _loc_3:* = _info.locationSearch;
            if (!param1 || param1 == "")
            {
                param1 = _loc_2 + unescape(_loc_3);
            }
            return param1;
        }// end function

        public function get utmp() : String
        {
            return _renderPageURL(_pageURL);
        }// end function

        public function get utmhid() : String
        {
            return String(_generateHitId());
        }// end function

        private function _generateHitId() : Number
        {
            var _loc_1:Number = NaN;
            if (_adSense.hid && _adSense.hid != "")
            {
                _loc_1 = Number(_adSense.hid);
            }
            else
            {
                _loc_1 = Math.round(Math.random() * 2147483647);
                _adSense.hid = String(_loc_1);
            }
            return _loc_1;
        }// end function

        public function toVariables() : Variables
        {
            var _loc_1:* = new Variables();
            _loc_1.URIencode = true;
            if (_config.detectTitle && utmdt != "")
            {
                _loc_1.utmdt = utmdt;
            }
            _loc_1.utmhid = utmhid;
            _loc_1.utmr = utmr;
            _loc_1.utmp = utmp;
            return _loc_1;
        }// end function

        public function get utmdt() : String
        {
            return _info.documentTitle;
        }// end function

    }
}
