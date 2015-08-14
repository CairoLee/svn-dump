package Map
{
    import Enums.*;

    public class cSectorDiscovery extends Object
    {
        public var mDirtyIndicator:int;
        private var mDiscoveryType:int = 0;
        private var mSectorID:int;

        public function cSectorDiscovery(param1:int, param2:int)
        {
            this.mSectorID = param1;
            this.mDiscoveryType = param2;
            return;
        }// end function

        public function GetSectorID() : int
        {
            return this.mSectorID;
        }// end function

        public function SetDiscoveryType(param1:int) : void
        {
            this.mDiscoveryType = param1;
            return;
        }// end function

        public function toString() : String
        {
            return "<SectorDiscovery sectorId=\'" + this.mSectorID + "\' discoveryType=\'" + SECTOR_DISCOVERY_TYPE.toString(this.mDiscoveryType) + "\' />";
        }// end function

        public function GetDiscoveryType() : int
        {
            return this.mDiscoveryType;
        }// end function

    }
}
