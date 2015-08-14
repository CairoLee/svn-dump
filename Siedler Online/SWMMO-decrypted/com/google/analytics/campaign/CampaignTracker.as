package com.google.analytics.campaign
{
    import com.google.analytics.utils.*;

    public class CampaignTracker extends Object
    {
        public var content:String;
        public var source:String;
        public var clickId:String;
        public var name:String;
        public var term:String;
        public var medium:String;
        public var id:String;

        public function CampaignTracker(param1:String = "", param2:String = "", param3:String = "", param4:String = "", param5:String = "", param6:String = "", param7:String = "")
        {
            this.id = param1;
            this.source = param2;
            this.clickId = param3;
            this.name = param4;
            this.medium = param5;
            this.term = param6;
            this.content = param7;
            return;
        }// end function

        public function isValid() : Boolean
        {
            if (id != "" || source != "" || clickId != "")
            {
                return true;
            }
            return false;
        }// end function

        public function toTrackerString() : String
        {
            var _loc_1:Array = [];
            _addIfNotEmpty(_loc_1, "utmcsr=", source);
            _addIfNotEmpty(_loc_1, "utmccn=", name);
            _addIfNotEmpty(_loc_1, "utmcmd=", medium);
            _addIfNotEmpty(_loc_1, "utmctr=", term);
            _addIfNotEmpty(_loc_1, "utmcct=", content);
            _addIfNotEmpty(_loc_1, "utmcid=", id);
            _addIfNotEmpty(_loc_1, "utmgclid=", clickId);
            return _loc_1.join(CampaignManager.trackingDelimiter);
        }// end function

        private function _addIfNotEmpty(param1:Array, param2:String, param3:String) : void
        {
            if (param3 != "")
            {
                param3 = param3.split("+").join("%20");
                param3 = param3.split(" ").join("%20");
                param1.push(param2 + param3);
            }
            return;
        }// end function

        public function fromTrackerString(param1:String) : void
        {
            var _loc_2:* = param1.split(CampaignManager.trackingDelimiter).join("&");
            var _loc_3:* = new Variables(_loc_2);
            if (_loc_3.hasOwnProperty("utmcid"))
            {
                this.id = _loc_3["utmcid"];
            }
            if (_loc_3.hasOwnProperty("utmcsr"))
            {
                this.source = _loc_3["utmcsr"];
            }
            if (_loc_3.hasOwnProperty("utmccn"))
            {
                this.name = _loc_3["utmccn"];
            }
            if (_loc_3.hasOwnProperty("utmcmd"))
            {
                this.medium = _loc_3["utmcmd"];
            }
            if (_loc_3.hasOwnProperty("utmctr"))
            {
                this.term = _loc_3["utmctr"];
            }
            if (_loc_3.hasOwnProperty("utmcct"))
            {
                this.content = _loc_3["utmcct"];
            }
            if (_loc_3.hasOwnProperty("utmgclid"))
            {
                this.clickId = _loc_3["utmgclid"];
            }
            return;
        }// end function

    }
}
