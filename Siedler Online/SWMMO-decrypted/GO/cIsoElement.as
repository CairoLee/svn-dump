package GO
{
    import GOSets.*;
    import Interface.*;
    import Map.*;
    import __AS3__.vec.*;

    final public class cIsoElement extends Object
    {
        public var mBorder:int = 0;
        public var mBuilding:cBuilding = null;
        public var mLandmark:cGO = null;
        private var mWatchingTowers_vector:Vector.<cBuilding> = null;
        public var mLandscape:cLandscape = null;
        public var mCursorVisible:int;
        public var mBackgroundBlocking:int = 0;
        public var mBlockedIsoElementSource:cIsoElement = null;
        public var mStreet:cStreet = null;
        public var mGoSetListAnimation:cGoSetListAnimationItem = null;
        public var mFogBorder:int = 0;
        public var mBorderColor:int = 0;
        public var mSectorId:int = 0;
        public var mGridIdx:int;
        public var mIconGoSetListAnimation:cGoSetListAnimationItem = null;
        public var mDeposit:cDeposit = null;
        public var mBlocked:int = 0;

        public function cIsoElement(param1:cGeneralInterface, param2:int)
        {
            this.mGridIdx = param2;
            return;
        }// end function

        public function RefreshDepositGfx() : void
        {
            var _loc_1:cGOSetListController = null;
            if (this.mDeposit != null)
            {
                if (this.mDeposit.GetGOSetListName_string() != null)
                {
                    _loc_1 = new cGOSetListControllerPercentage(this.mDeposit.GetMaxAmount());
                    this.mDeposit.mDepositGfx = cGOSetManager.CreateGOSetList(this.mDeposit.GetGOSetListName_string(), _loc_1);
                    this.mDeposit.mDepositGfx.SetValue(this.mDeposit.GetAmount());
                }
                else
                {
                    this.mDeposit.mDepositGfx = null;
                }
            }
            return;
        }// end function

        public function IsBuildingWatching(param1:cBuilding) : Boolean
        {
            var _loc_2:int = 0;
            if (this.mWatchingTowers_vector != null)
            {
                _loc_2 = this.mWatchingTowers_vector.indexOf(param1);
                if (_loc_2 != -1)
                {
                    return true;
                }
            }
            return false;
        }// end function

        public function RemoveWatchingBuilding(param1:cBuilding) : void
        {
            var _loc_2:int = 0;
            if (this.mWatchingTowers_vector != null)
            {
                _loc_2 = this.mWatchingTowers_vector.indexOf(param1);
                if (_loc_2 != -1)
                {
                    this.mWatchingTowers_vector.splice(_loc_2, 1);
                }
                if (this.mWatchingTowers_vector.length == 0)
                {
                    this.mWatchingTowers_vector = null;
                }
            }
            return;
        }// end function

        public function GetBlocked() : int
        {
            return this.mBlocked;
        }// end function

        public function GetReadyTowerGridIdxs()
        {
            var _loc_2:cBuilding = null;
            var _loc_1:* = new Vector.<int>;
            if (this.mWatchingTowers_vector != null)
            {
                for each (_loc_2 in this.mWatchingTowers_vector)
                {
                    
                    if (_loc_2.IsReadyToIntercept())
                    {
                        _loc_1.push(_loc_2.GetStreetGridEntry());
                    }
                }
            }
            return _loc_1;
        }// end function

        public function RemoveAllWatchingTowers() : void
        {
            this.mWatchingTowers_vector = null;
            return;
        }// end function

        public function SetBackgroundBlocking(param1:int) : void
        {
            this.mBackgroundBlocking = param1;
            return;
        }// end function

        public function GetBackgroundBlocking() : int
        {
            return this.mBackgroundBlocking;
        }// end function

        public function Clear() : void
        {
            this.mBlocked = cBlockingData.BLOCK_TYPE_ALLOW_ALL;
            this.mBackgroundBlocking = cBlockingData.BLOCK_TYPE_ALLOW_ALL;
            this.mSectorId = 0;
            this.mFogBorder = 0;
            this.mStreet = null;
            this.mBuilding = null;
            this.mLandscape = null;
            this.mGoSetListAnimation = null;
            this.mIconGoSetListAnimation = null;
            this.mBorder = 0;
            this.mBorderColor = 0;
            this.mDeposit = null;
            this.mLandmark = null;
            this.mWatchingTowers_vector = null;
            return;
        }// end function

        public function AddWatchingBuilding(param1:cBuilding) : void
        {
            if (this.mWatchingTowers_vector == null)
            {
                this.mWatchingTowers_vector = new Vector.<cBuilding>;
            }
            this.mWatchingTowers_vector.push(param1);
            return;
        }// end function

        public function IsWatchedByTowers() : Boolean
        {
            if (this.mWatchingTowers_vector != null && this.mWatchingTowers_vector.length > 0)
            {
                return true;
            }
            return false;
        }// end function

        public function IsBlockedAllowedNothing() : Boolean
        {
            return this.mBlocked == cBlockingData.BLOCK_TYPE_ALLOW_NOTHING;
        }// end function

        public function SetBlocked(param1:int) : void
        {
            this.mBlocked = param1;
            return;
        }// end function

        public function IsBlockedAllowedAll() : Boolean
        {
            return this.mBlocked == cBlockingData.BLOCK_TYPE_ALLOW_ALL;
        }// end function

        public function SetDeposit(param1:cDeposit) : void
        {
            this.mDeposit = param1;
            this.RefreshDepositGfx();
            return;
        }// end function

    }
}
