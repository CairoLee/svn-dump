package Communication.VO
{
    import flash.utils.*;

    public class dDepositQualityVO extends Object
    {
        public var depositBonus:int;
        public var diceThrow:int;

        public function dDepositQualityVO()
        {
            return;
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            this.depositBonus = param1.readInt();
            this.diceThrow = param1.readInt();
            return;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeInt(this.depositBonus);
            param1.writeInt(this.diceThrow);
            return;
        }// end function

        public function toString() : String
        {
            return "<dDepositQualityVO depositBonus=\'" + this.depositBonus + "\' diceThrow=\'" + this.diceThrow + "\' />";
        }// end function

    }
}
