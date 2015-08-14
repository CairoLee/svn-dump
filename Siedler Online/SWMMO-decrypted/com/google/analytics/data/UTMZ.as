package com.google.analytics.data
{
    import com.google.analytics.utils.*;

    public class UTMZ extends UTMCookie
    {
        private var _campaignTracking:String;
        private var _campaignCreation:Number;
        private var _responseCount:Number;
        private var _domainHash:Number;
        private var _campaignSessions:Number;
        public static var defaultTimespan:Number = Timespan.sixmonths;

        public function UTMZ(param1:Number = NaN, param2:Number = NaN, param3:Number = NaN, param4:Number = NaN, param5:String = "")
        {
            super("utmz", "__utmz", ["domainHash", "campaignCreation", "campaignSessions", "responseCount", "campaignTracking"], defaultTimespan * 1000);
            this.domainHash = param1;
            this.campaignCreation = param2;
            this.campaignSessions = param3;
            this.responseCount = param4;
            this.campaignTracking = param5;
            return;
        }// end function

        public function set responseCount(param1:Number) : void
        {
            _responseCount = param1;
            update();
            return;
        }// end function

        public function set domainHash(param1:Number) : void
        {
            _domainHash = param1;
            update();
            return;
        }// end function

        public function set campaignCreation(param1:Number) : void
        {
            _campaignCreation = param1;
            update();
            return;
        }// end function

        public function get campaignTracking() : String
        {
            return _campaignTracking;
        }// end function

        public function get campaignSessions() : Number
        {
            return _campaignSessions;
        }// end function

        public function get domainHash() : Number
        {
            return _domainHash;
        }// end function

        public function get responseCount() : Number
        {
            return _responseCount;
        }// end function

        public function get campaignCreation() : Number
        {
            return _campaignCreation;
        }// end function

        public function set campaignSessions(param1:Number) : void
        {
            _campaignSessions = param1;
            update();
            return;
        }// end function

        public function set campaignTracking(param1:String) : void
        {
            _campaignTracking = param1;
            update();
            return;
        }// end function

    }
}
