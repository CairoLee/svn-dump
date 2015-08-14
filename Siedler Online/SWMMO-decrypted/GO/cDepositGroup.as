package GO
{
    import Communication.VO.*;
    import Interface.*;
    import __AS3__.vec.*;
    import mx.collections.*;
    import nLib.*;

    public class cDepositGroup extends Object
    {
        private var mDepositType_string:String = "";
        private var mMaxAccessible:int;
        private var mGeneralInterface:cGeneralInterface;
        private var mId:int;
        private var mAverageAmount:int;
        private var mUbiRandom:cUbiRandom;
        private var mDepositGridIdxs_vector:Vector.<int>;

        public function cDepositGroup(param1:cGeneralInterface, param2:int, param3:int, param4:int, param5:int, param6:String)
        {
            this.mDepositGridIdxs_vector = new Vector.<int>;
            this.mGeneralInterface = param1;
            this.mId = param2;
            this.mMaxAccessible = param3;
            this.mAverageAmount = param4;
            this.mDepositType_string = param6;
            this.mUbiRandom = new cUbiRandom(param5);
            return;
        }// end function

        public function GetDepositType_string() : String
        {
            return this.mDepositType_string;
        }// end function

        public function CreateVO() : dDepositGroupVO
        {
            var _loc_2:int = 0;
            var _loc_1:* = new dDepositGroupVO();
            _loc_1.mId = this.mId;
            _loc_1.mDepositType_string = this.mDepositType_string;
            _loc_1.mMaxAccessible = this.mMaxAccessible;
            _loc_1.mAverageAmount = this.mAverageAmount;
            _loc_1.mAverageAmount = this.mAverageAmount;
            _loc_1.mDepositsVector = new ArrayCollection();
            for each (_loc_2 in this.mDepositGridIdxs_vector)
            {
                
                _loc_1.mDepositsVector.addItem(_loc_2);
            }
            _loc_1.mUbiRandom = this.mUbiRandom.GetSeed();
            return _loc_1;
        }// end function

        public function SetMaxAccessible(param1:int) : void
        {
            this.mMaxAccessible = param1;
            return;
        }// end function

        public function SetDepositType_string(param1:String) : void
        {
            this.mDepositType_string = param1;
            return;
        }// end function

        public function RemoveDeposit(param1:cDeposit) : void
        {
            var _loc_2:* = this.mDepositGridIdxs_vector.indexOf(param1.GetGridIdx());
            if (_loc_2 != -1)
            {
                this.mDepositGridIdxs_vector.splice(_loc_2, 1);
            }
            return;
        }// end function

        public function GetMaxAccessible() : int
        {
            return this.mMaxAccessible;
        }// end function

        public function toString() : String
        {
            return "<DepositGroup " + this.mDepositGridIdxs_vector + " >";
        }// end function

        public function GetId() : int
        {
            return this.mId;
        }// end function

        public function SetAverageAmount(param1:int) : void
        {
            this.mAverageAmount = param1;
            return;
        }// end function

        public function AddDepositGridIdx(param1:int) : void
        {
            this.mDepositGridIdxs_vector.push(param1);
            return;
        }// end function

        public function GetDepositGridIdxs_vector()
        {
            return this.mDepositGridIdxs_vector;
        }// end function

        public function GetAverageAmount() : int
        {
            return this.mAverageAmount;
        }// end function

    }
}
