package Communication.VO.UpdateVO
{
    import mx.collections.*;

    public class dAdventureClientInfoVO extends Object
    {
        public var zoneID:int;
        public var ownerPlayerID:int;
        public var status:int;
        public var isTrackedMission:Boolean = false;
        public var totalDuration:Number;
        public var players:ArrayCollection;
        public var adventureName:String;
        public var collectedTime:Number;

        public function dAdventureClientInfoVO()
        {
            this.players = new ArrayCollection();
            return;
        }// end function

        public function toString() : String
        {
            return "<dAdventureVO adventureName=\'" + this.adventureName + "\' zoneID=\'" + this.zoneID + "\' status=\'" + this.status + "\' collectedTime=\'" + this.collectedTime + "\' totalDuration=\'" + this.totalDuration + "\' ownerPlayerID=\'" + this.ownerPlayerID + "/>";
        }// end function

    }
}
