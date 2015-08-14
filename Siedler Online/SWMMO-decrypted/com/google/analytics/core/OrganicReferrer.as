package com.google.analytics.core
{

    public class OrganicReferrer extends Object
    {
        private var _engine:String;
        private var _keyword:String;

        public function OrganicReferrer(param1:String, param2:String)
        {
            this.engine = param1;
            this.keyword = param2;
            return;
        }// end function

        public function get keyword() : String
        {
            return _keyword;
        }// end function

        public function get engine() : String
        {
            return _engine;
        }// end function

        public function set engine(param1:String) : void
        {
            _engine = param1.toLowerCase();
            return;
        }// end function

        public function toString() : String
        {
            return engine + "?" + keyword;
        }// end function

        public function set keyword(param1:String) : void
        {
            _keyword = param1.toLowerCase();
            return;
        }// end function

    }
}
