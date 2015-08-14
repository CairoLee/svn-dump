package mx.rpc
{

    public class Fault extends Error
    {
        public var rootCause:Object;
        protected var _faultCode:String;
        protected var _faultString:String;
        public var content:Object;
        protected var _faultDetail:String;

        public function Fault(param1:String, param2:String, param3:String = null)
        {
            super("faultCode:" + param1 + " faultString:\'" + param2 + "\' faultDetail:\'" + param3 + "\'");
            this._faultCode = param1;
            this._faultString = param2 ? (param2) : ("");
            this._faultDetail = param3;
            return;
        }// end function

        public function get faultString() : String
        {
            return _faultString;
        }// end function

        public function toString() : String
        {
            var _loc_1:String = "[RPC Fault";
            _loc_1 = _loc_1 + (" faultString=\"" + faultString + "\"");
            _loc_1 = _loc_1 + (" faultCode=\"" + faultCode + "\"");
            _loc_1 = _loc_1 + (" faultDetail=\"" + faultDetail + "\"]");
            return _loc_1;
        }// end function

        public function get faultCode() : String
        {
            return _faultCode;
        }// end function

        public function get faultDetail() : String
        {
            return _faultDetail;
        }// end function

    }
}
