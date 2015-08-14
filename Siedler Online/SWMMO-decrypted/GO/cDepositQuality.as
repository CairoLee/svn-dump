package GO
{
    import Communication.VO.*;

    public class cDepositQuality extends Object
    {
        private var depositBonus:int;
        private var diceThrow:int;

        public function cDepositQuality(param1:int, param2:int)
        {
            this.depositBonus = param1;
            this.diceThrow = param2;
            return;
        }// end function

        public function CreateVO() : dDepositQualityVO
        {
            var _loc_1:* = new dDepositQualityVO();
            _loc_1.depositBonus = this.depositBonus;
            _loc_1.diceThrow = this.diceThrow;
            return _loc_1;
        }// end function

        public function GetDepositBonus() : int
        {
            return this.depositBonus;
        }// end function

        public function GetDiceThrow() : int
        {
            return this.diceThrow;
        }// end function

    }
}
