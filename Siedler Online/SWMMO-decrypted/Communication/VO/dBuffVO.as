package Communication.VO
{

    public class dBuffVO extends Object
    {
        public var uniqueId1:int;
        public var uniqueId2:int;
        public var count:int;
        public var recurringChance:int;
        public var buffName_string:String;
        public var remaining:int;
        public var resourceName_string:String;
        public var amount:int;

        public function dBuffVO()
        {
            return;
        }// end function

        public function toString() : String
        {
            var _loc_1:String = "<dBuffVO ";
            _loc_1 = _loc_1 + ("uniqueId1=\'" + this.uniqueId1 + "\' ");
            _loc_1 = _loc_1 + ("uniqueId2=\'" + this.uniqueId2 + "\' ");
            _loc_1 = _loc_1 + ("buffName_string=\'" + this.buffName_string + "\' ");
            _loc_1 = _loc_1 + ("resourceName=\'" + this.resourceName_string + "\' ");
            _loc_1 = _loc_1 + ("amount=\'" + this.amount + "\' ");
            _loc_1 = _loc_1 + ("remaining=\'" + this.remaining + "\' ");
            _loc_1 = _loc_1 + ("recurringChance=\'" + this.recurringChance + "\' ");
            _loc_1 = _loc_1 + " />\n";
            return _loc_1;
        }// end function

    }
}
