package Map
{
    import Communication.VO.*;
    import __AS3__.vec.*;

    public class cSector extends Object
    {
        private var mOwnerPlayerID:int;
        private var mCityLevelAtWhichSectorIsActivated:int;
        public var mAmount:int;
        public const mAdjactedSectorIds_vector:Vector.<int>;
        private var mExplorePriority:int;
        private var mSectorID:int;

        public function cSector(param1:int, param2:int, param3:int, param4:int)
        {
            this.mAdjactedSectorIds_vector = new Vector.<int>;
            this.mSectorID = param1;
            this.mOwnerPlayerID = param2;
            this.mExplorePriority = param3;
            this.mCityLevelAtWhichSectorIsActivated = param4;
            return;
        }// end function

        public function GetExplorePriority() : int
        {
            return this.mExplorePriority;
        }// end function

        public function CreateSectorVOFromSector() : dSectorVO
        {
            var _loc_1:* = new dSectorVO();
            _loc_1.playerID = this.mOwnerPlayerID;
            _loc_1.sectorID = this.mSectorID;
            _loc_1.explorePriority = this.mExplorePriority;
            _loc_1.cityLevelAtWhichSectorIsActivated = this.mCityLevelAtWhichSectorIsActivated;
            return _loc_1;
        }// end function

        public function toString() : String
        {
            return "<Sector sectorID=\'" + this.mSectorID + "\' mOwnerPlayerID=\'" + this.mOwnerPlayerID + "\' />";
        }// end function

        public function SetOwnerPlayerID(param1:int) : void
        {
            this.mOwnerPlayerID = param1;
            return;
        }// end function

        public function GetSectorID() : int
        {
            return this.mSectorID;
        }// end function

        public function GetOwnerPlayerID() : int
        {
            return this.mOwnerPlayerID;
        }// end function

        public function GetCityLevelAtWhichSectorIsActivated() : int
        {
            return this.mCityLevelAtWhichSectorIsActivated;
        }// end function

        public function SetExplorePriority(param1:int) : void
        {
            this.mExplorePriority = param1;
            return;
        }// end function

        public function SetCityLevelAtWhichSectorIsActivated(param1:int) : void
        {
            this.mCityLevelAtWhichSectorIsActivated = param1;
            return;
        }// end function

    }
}
