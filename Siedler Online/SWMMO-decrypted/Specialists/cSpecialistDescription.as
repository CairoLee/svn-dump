package Specialists
{

    public class cSpecialistDescription extends Object
    {
        private var mTimeBonus:int = 0;
        private var mType:int;
        private var mDiceBonus:int;
        private var mSortIndex:int;
        private var mRecruitable:Boolean;
        private var mMaxUnits:int;
        private var mMilitaryUnitType_string:String;

        public function cSpecialistDescription(param1:int, param2:int, param3:int, param4:int, param5:String, param6:Boolean, param7:int)
        {
            this.mType = param1;
            this.mDiceBonus = param2;
            this.mTimeBonus = param3;
            this.mMaxUnits = param4;
            this.mMilitaryUnitType_string = param5;
            this.mRecruitable = param6;
            this.mSortIndex = param7;
            return;
        }// end function

        public function GetMaxUnits() : int
        {
            return this.mMaxUnits;
        }// end function

        public function GetDiceBonus() : int
        {
            return this.mDiceBonus;
        }// end function

        public function IsRecruitable() : Boolean
        {
            return this.mRecruitable;
        }// end function

        public function GetType() : int
        {
            return this.mType;
        }// end function

        public function toString() : String
        {
            return "<SpecialistDescription type=\'" + this.mType + "\', diceBonus=\'" + this.mDiceBonus + "\' />";
        }// end function

        public function SetMaxUnits(param1:int) : void
        {
            this.mMaxUnits = param1;
            return;
        }// end function

        public function GetMilitaryUnitType_string() : String
        {
            return this.mMilitaryUnitType_string;
        }// end function

        public function GetTimeBonus() : int
        {
            return this.mTimeBonus;
        }// end function

        public function GetSortIndex() : int
        {
            return this.mSortIndex;
        }// end function

    }
}
