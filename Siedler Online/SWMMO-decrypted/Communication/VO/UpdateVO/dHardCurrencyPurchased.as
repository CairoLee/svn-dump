package Communication.VO.UpdateVO
{

    public class dHardCurrencyPurchased extends Object
    {
        public var mAmount:int;
        public var mHardCurrencyPurchasedID:int;

        public function dHardCurrencyPurchased()
        {
            return;
        }// end function

        public function init(param1:int, param2:int) : dHardCurrencyPurchased
        {
            this.mAmount = param1;
            this.mHardCurrencyPurchasedID = param2;
            return this;
        }// end function

        public function toString() : String
        {
            return "<dHardCurrencyPurchased amount=" + this.mAmount + ", hardCurrencyPurchasedID=" + this.mHardCurrencyPurchasedID + " >";
        }// end function

    }
}
