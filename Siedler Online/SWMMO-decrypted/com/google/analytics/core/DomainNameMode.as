package com.google.analytics.core
{

    public class DomainNameMode extends Object
    {
        private var _value:int;
        private var _name:String;
        public static const custom:DomainNameMode = new DomainNameMode(2, "custom");
        public static const none:DomainNameMode = new DomainNameMode(0, "none");
        public static const auto:DomainNameMode = new DomainNameMode(1, "auto");

        public function DomainNameMode(param1:int = 0, param2:String = "")
        {
            _value = param1;
            _name = param2;
            return;
        }// end function

        public function valueOf() : int
        {
            return _value;
        }// end function

        public function toString() : String
        {
            return _name;
        }// end function

    }
}
