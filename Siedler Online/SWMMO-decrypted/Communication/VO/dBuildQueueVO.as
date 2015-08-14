package Communication.VO
{
    import mx.collections.*;

    public class dBuildQueueVO extends Object
    {
        public var tempSlots:ArrayCollection;
        public var permanentSlotsCount:int;
        public var maxCount:int;
        public var tempSlotsCount:int;
        public var buildings:ArrayCollection;

        public function dBuildQueueVO()
        {
            this.buildings = new ArrayCollection();
            this.tempSlots = new ArrayCollection();
            return;
        }// end function

        public function toString() : String
        {
            var _loc_1:* = "<dBuildQueueVO maxCount=\'" + this.maxCount + "\' permanentSlotsCount=\'" + this.permanentSlotsCount + "\' tempSlotsCount=\'" + this.tempSlotsCount + "\' >\n";
            _loc_1 = _loc_1 + gCalculations.createListString("Buildings", this.buildings);
            _loc_1 = _loc_1 + "</dBuildQueueVO>";
            return _loc_1;
        }// end function

    }
}
