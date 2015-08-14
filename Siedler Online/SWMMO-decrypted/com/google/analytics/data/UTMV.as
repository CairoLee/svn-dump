package com.google.analytics.data
{
    import com.google.analytics.utils.*;

    public class UTMV extends UTMCookie
    {
        private var _domainHash:Number;
        private var _value:String;

        public function UTMV(param1:Number = NaN, param2:String = "")
        {
            super("utmv", "__utmv", ["domainHash", "value"], Timespan.twoyears * 1000);
            this.domainHash = param1;
            this.value = param2;
            return;
        }// end function

        override public function toURLString() : String
        {
            return inURL + "=" + encodeURI(valueOf());
        }// end function

        public function get value() : String
        {
            return _value;
        }// end function

        public function get domainHash() : Number
        {
            return _domainHash;
        }// end function

        public function set domainHash(param1:Number) : void
        {
            _domainHash = param1;
            update();
            return;
        }// end function

        public function set value(param1:String) : void
        {
            _value = param1;
            update();
            return;
        }// end function

    }
}
