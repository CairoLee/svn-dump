package GO
{
    import Communication.VO.*;
    import Enums.*;
    import GOSets.*;
    import Interface.*;

    public class cDeposit extends cGO
    {
        private var mAccessible:int = 0;
        public var mDepositGfx:cGOSetList = null;
        private var mDepositGroupdId:int = -1;
        private var mName_string:String;
        private var mAmount:int;
        private var mGridIdx:int = -1;
        private var mEmptied:uint = 0;
        public var mDirtyIndicator:int;
        private var mMaxAmount:int;
        private var mGOSetListName_string:String = null;

        public function cDeposit(param1:cGeneralInterface)
        {
            super(param1);
            mPlayerID = -1;
            SetLevelEnumObjectType(OBJECTTYPE.DEPOSIT);
            return;
        }// end function

        public function CreateDepositVOFromDeposit() : dDepositVO
        {
            var _loc_1:* = new dDepositVO();
            _loc_1.accessible = this.GetAccessibleType();
            _loc_1.gridIdx = this.GetGridIdx();
            _loc_1.depositGroupdId = this.GetDepositGroupID();
            _loc_1.emptied = this.GetEmptied();
            _loc_1.name_string = this.GetName_string();
            _loc_1.amount = this.GetAmount();
            _loc_1.maxAmount = this.GetMaxAmount();
            _loc_1.goSetListName_string = this.GetGOSetListName_string();
            return _loc_1;
        }// end function

        public function GetGridIdx() : int
        {
            return this.mGridIdx;
        }// end function

        public function IncEmptied() : void
        {
            var _loc_1:String = this;
            var _loc_2:* = this.mEmptied + 1;
            _loc_1.mEmptied = _loc_2;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function SetAmount(param1:int) : Boolean
        {
            this.mAmount = param1;
            return true;
        }// end function

        public function GetEmptied() : int
        {
            return this.mEmptied;
        }// end function

        public function ChangeAmount(param1:int) : void
        {
            this.mAmount = this.mAmount + param1;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function SetMaxAmount(param1:int) : void
        {
            this.mMaxAmount = param1;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function GetMaxAmount() : int
        {
            return this.mMaxAmount;
        }// end function

        public function GetDepositID() : int
        {
            return global.guiIconGroup.GetNrFromName("Deposit" + this.GetName_string());
        }// end function

        public function GetAccessibleType() : int
        {
            return this.mAccessible;
        }// end function

        public function toString() : String
        {
            return "<Deposit \'" + this.mName_string + "\' @" + this.GetGridIdx() + ", " + this.GetAmount() + "/" + this.GetMaxAmount() + " accessible=" + DEPOSIT_ACCESSIBLE_TYPES.toString(this.mAccessible) + " >";
        }// end function

        public function GetAmount() : int
        {
            return this.mAmount;
        }// end function

        public function SetAccessibleType(param1:int) : Boolean
        {
            this.mAccessible = param1;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return true;
        }// end function

        public function SetGridIdx(param1:uint) : Boolean
        {
            this.mGridIdx = param1;
            return true;
        }// end function

        public function Init(param1:String, param2:int, param3:int, param4:int, param5:int, param6:int, param7:int, param8:String) : void
        {
            this.mName_string = param1;
            this.mGridIdx = param2;
            this.mAmount = param3;
            this.mMaxAmount = param4;
            this.mDepositGroupdId = param5;
            this.mAccessible = param6;
            this.mEmptied = param7;
            this.mGOSetListName_string = param8;
            return;
        }// end function

        public function EmptyDeposit() : void
        {
            this.mAmount = 0;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function GetDepositGroupID() : int
        {
            return this.mDepositGroupdId;
        }// end function

        public function GetGOSetListName_string() : String
        {
            return this.mGOSetListName_string;
        }// end function

        public function IsEqualToVOIgnoreGrid(param1:dDepositVO) : Boolean
        {
            if (param1.amount != this.mAmount)
            {
                return false;
            }
            if (param1.name_string != this.mName_string)
            {
                return false;
            }
            if (param1.accessible != this.mAccessible)
            {
                return false;
            }
            return true;
        }// end function

        public function GetName_string() : String
        {
            return this.mName_string;
        }// end function

        public static function CreateDepositFromVO(param1:dDepositVO, param2:cGeneralInterface) : cDeposit
        {
            var _loc_3:* = cDeposit.CreateFromString(global.guiIconGroup, "Deposit" + param1.name_string, param2);
            _loc_3.Init(param1.name_string, param1.gridIdx, param1.amount, param1.maxAmount, param1.depositGroupdId, param1.accessible, param1.emptied, param1.goSetListName_string);
            return _loc_3;
        }// end function

        public static function CreateFromString(param1:cGOGroup, param2:String, param3:cGeneralInterface) : cDeposit
        {
            var _loc_4:* = param1.GetNrFromName(param2);
            var _loc_5:* = new cDeposit(param3);
            new cDeposit(param3).InitFromNr(param1, _loc_4);
            _loc_5.SetLevelEnumObjectType(OBJECTTYPE.DEPOSIT);
            return _loc_5;
        }// end function

    }
}
