package Communication.VO
{
    import Enums.*;
    import flash.utils.*;

    public class dSectorDiscoveryVO extends Object
    {
        public var sectorID:int;
        public var discoveryType:int;

        public function dSectorDiscoveryVO()
        {
            return;
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            this.sectorID = param1.readInt();
            this.discoveryType = param1.readInt();
            return;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeInt(this.sectorID);
            param1.writeInt(this.discoveryType);
            return;
        }// end function

        public function toString() : String
        {
            return "<SectorDiscoveryVO sectorID=\'" + this.sectorID + "\' discoveryType=\'" + SECTOR_DISCOVERY_TYPE.toString(this.discoveryType) + "\' />";
        }// end function

    }
}
