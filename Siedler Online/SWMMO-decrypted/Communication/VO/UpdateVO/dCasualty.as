package Communication.VO.UpdateVO
{

    public class dCasualty extends Object
    {
        public var mAmount:int;
        public var mCasualtyID:int;

        public function dCasualty()
        {
            return;
        }// end function

        public function init(param1:int, param2:int) : dCasualty
        {
            this.mAmount = param1;
            this.mCasualtyID = param2;
            return this;
        }// end function

        public function toString() : String
        {
            return "<dCasualty amount=" + this.mAmount + ", casualtyID=" + this.mCasualtyID + " >";
        }// end function

    }
}
