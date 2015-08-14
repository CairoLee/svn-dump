package com.google.analytics.data
{
    import com.google.analytics.utils.*;

    public class UTMA extends UTMCookie
    {
        private var _sessionId:Number;
        private var _domainHash:Number;
        private var _firstTime:Number;
        private var _currentTime:Number;
        private var _lastTime:Number;
        private var _sessionCount:Number;

        public function UTMA(param1:Number = NaN, param2:Number = NaN, param3:Number = NaN, param4:Number = NaN, param5:Number = NaN, param6:Number = NaN)
        {
            super("utma", "__utma", ["domainHash", "sessionId", "firstTime", "lastTime", "currentTime", "sessionCount"], Timespan.twoyears * 1000);
            this.domainHash = param1;
            this.sessionId = param2;
            this.firstTime = param3;
            this.lastTime = param4;
            this.currentTime = param5;
            this.sessionCount = param6;
            return;
        }// end function

        public function get lastTime() : Number
        {
            return _lastTime;
        }// end function

        public function set lastTime(param1:Number) : void
        {
            _lastTime = param1;
            update();
            return;
        }// end function

        public function set currentTime(param1:Number) : void
        {
            _currentTime = param1;
            update();
            return;
        }// end function

        public function get sessionId() : Number
        {
            return _sessionId;
        }// end function

        public function get sessionCount() : Number
        {
            return _sessionCount;
        }// end function

        public function get firstTime() : Number
        {
            return _firstTime;
        }// end function

        public function get currentTime() : Number
        {
            return _currentTime;
        }// end function

        public function set domainHash(param1:Number) : void
        {
            _domainHash = param1;
            update();
            return;
        }// end function

        public function set sessionId(param1:Number) : void
        {
            _sessionId = param1;
            update();
            return;
        }// end function

        public function set sessionCount(param1:Number) : void
        {
            _sessionCount = param1;
            update();
            return;
        }// end function

        public function get domainHash() : Number
        {
            return _domainHash;
        }// end function

        public function set firstTime(param1:Number) : void
        {
            _firstTime = param1;
            update();
            return;
        }// end function

    }
}
