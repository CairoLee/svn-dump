package Communication.VO
{
    import mx.collections.*;

    public class dDepositGroupVO extends Object
    {
        public var mDepositType_string:String;
        public var mId:int;
        public var mDepositsVector:ArrayCollection;
        public var mMaxAccessible:int;
        public var mAverageAmount:int;
        public var mUbiRandom:int;

        public function dDepositGroupVO()
        {
            this.mDepositsVector = new ArrayCollection();
            return;
        }// end function

        public function toString() : String
        {
            var _loc_3:int = 0;
            var _loc_1:String = "";
            var _loc_2:Boolean = true;
            for each (_loc_3 in this.mDepositsVector)
            {
                
                if (!_loc_2)
                {
                    _loc_1 = _loc_1 + ",";
                    _loc_2 = true;
                }
                _loc_1 = _loc_1 + ("" + _loc_3);
            }
            return "<DepositGroups mId=\'" + this.mId + "\' mDepositType_string=\'" + this.mDepositType_string + "\' mMaxAccessible=\'" + this.mMaxAccessible + "\' mAverageAmount=\'" + this.mAverageAmount + "\' mUbiRandom=\'" + this.mUbiRandom + "\' mDepositsVector=\'" + _loc_1 + "\' />";
        }// end function

    }
}
