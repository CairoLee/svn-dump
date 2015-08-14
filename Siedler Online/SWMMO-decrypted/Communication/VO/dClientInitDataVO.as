package Communication.VO
{

    public class dClientInitDataVO extends Object
    {
        public var clientCapabilities:String;
        public var clientInitDuration:int;

        public function dClientInitDataVO()
        {
            return;
        }// end function

        public function toString() : String
        {
            var _loc_1:* = "<dClientInitDataVO" + " clientInitDuration=\'" + this.clientInitDuration + "\' clientCapabilities=\'" + this.clientCapabilities + "\' >\n";
            _loc_1 = _loc_1 + "</dClientInitDataVO>";
            return _loc_1;
        }// end function

    }
}
