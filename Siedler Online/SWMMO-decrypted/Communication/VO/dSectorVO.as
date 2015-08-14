package Communication.VO
{
    import flash.utils.*;

    public class dSectorVO extends Object
    {
        public var sectorID:int;
        public var cityLevelAtWhichSectorIsActivated:int;
        public var explorePriority:int;
        public var playerID:int;

        public function dSectorVO()
        {
            return;
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            this.sectorID = param1.readInt();
            this.playerID = param1.readInt();
            this.explorePriority = param1.readInt();
            this.cityLevelAtWhichSectorIsActivated = param1.readInt();
            return;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeInt(this.sectorID);
            param1.writeInt(this.playerID);
            param1.writeInt(this.explorePriority);
            param1.writeInt(this.cityLevelAtWhichSectorIsActivated);
            return;
        }// end function

        public function toString() : String
        {
            return "<dSectorVO sectorID=\'" + this.sectorID + "\' playerID=\'" + this.playerID + "\' explorePriority=\'" + this.explorePriority + "\' cityLevelAtWhichSectorIsActivated=\'" + this.cityLevelAtWhichSectorIsActivated + "\' />";
        }// end function

    }
}
