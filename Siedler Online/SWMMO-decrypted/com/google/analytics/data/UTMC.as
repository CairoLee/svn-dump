package com.google.analytics.data
{

    public class UTMC extends UTMCookie
    {
        private var _domainHash:Number;

        public function UTMC(param1:Number = NaN)
        {
            super("utmc", "__utmc", ["domainHash"]);
            this.domainHash = param1;
            return;
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

    }
}
