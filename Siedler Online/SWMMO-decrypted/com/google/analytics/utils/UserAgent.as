package com.google.analytics.utils
{
    import com.google.analytics.core.*;
    import flash.system.*;

    public class UserAgent extends Object
    {
        private var _localInfo:Environment;
        private var _applicationProduct:String;
        private var _version:Version;
        public static var minimal:Boolean = false;

        public function UserAgent(param1:Environment, param2:String = "", param3:String = "")
        {
            _localInfo = param1;
            applicationProduct = param2;
            _version = Version.fromString(param3);
            return;
        }// end function

        public function get tamarinProductToken() : String
        {
            if (UserAgent.minimal)
            {
                return "";
            }
            if (System.vmVersion)
            {
                return "Tamarin/" + Utils.trim(System.vmVersion, true);
            }
            return "";
        }// end function

        public function get applicationVersion() : String
        {
            return _version.toString(2);
        }// end function

        public function get vendorProductToken() : String
        {
            var _loc_1:String = "";
            if (_localInfo.isAIR())
            {
                _loc_1 = _loc_1 + "AIR";
            }
            else
            {
                _loc_1 = _loc_1 + "FlashPlayer";
            }
            _loc_1 = _loc_1 + "/";
            _loc_1 = _loc_1 + _version.toString(3);
            return _loc_1;
        }// end function

        public function toString() : String
        {
            var _loc_1:String = "";
            _loc_1 = _loc_1 + applicationProductToken;
            if (applicationComment != "")
            {
                _loc_1 = _loc_1 + (" " + applicationComment);
            }
            if (tamarinProductToken != "")
            {
                _loc_1 = _loc_1 + (" " + tamarinProductToken);
            }
            if (vendorProductToken != "")
            {
                _loc_1 = _loc_1 + (" " + vendorProductToken);
            }
            return _loc_1;
        }// end function

        public function get applicationComment() : String
        {
            var _loc_1:Array = [];
            _loc_1.push(_localInfo.platform);
            _loc_1.push(_localInfo.playerType);
            if (!UserAgent.minimal)
            {
                _loc_1.push(_localInfo.operatingSystem);
                _loc_1.push(_localInfo.language);
            }
            if (Capabilities.isDebugger)
            {
                _loc_1.push("DEBUG");
            }
            if (_loc_1.length > 0)
            {
                return "(" + _loc_1.join("; ") + ")";
            }
            return "";
        }// end function

        public function set applicationVersion(param1:String) : void
        {
            _version = Version.fromString(param1);
            return;
        }// end function

        public function get applicationProductToken() : String
        {
            var _loc_1:* = applicationProduct;
            if (applicationVersion != "")
            {
                _loc_1 = _loc_1 + ("/" + applicationVersion);
            }
            return _loc_1;
        }// end function

        public function set applicationProduct(param1:String) : void
        {
            _applicationProduct = param1;
            return;
        }// end function

        public function get applicationProduct() : String
        {
            return _applicationProduct;
        }// end function

    }
}
