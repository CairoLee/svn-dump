package com.google.analytics.core
{

    public class ServerOperationMode extends Object
    {
        private var _value:int;
        private var _name:String;
        public static const both:ServerOperationMode = new ServerOperationMode(2, "both");
        public static const remote:ServerOperationMode = new ServerOperationMode(1, "remote");
        public static const local:ServerOperationMode = new ServerOperationMode(0, "local");

        public function ServerOperationMode(param1:int = 0, param2:String = "")
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
