package Communication.VO
{
    import Enums.*;

    public class dSpecialistTask_FindDepositVO extends dSpecialistTaskVO
    {
        public var exploredDepositVO:dDepositVO;
        public var exploredDepositResult:int;
        public var depositToSearch_string:String;

        public function dSpecialistTask_FindDepositVO()
        {
            return;
        }// end function

        override public function toString() : String
        {
            return "<dSpecialistTask_FindDepositVO " + super.dataString() + " exploredDeposit=\'" + this.exploredDepositVO + "\' depositToSearch_string=\'" + this.depositToSearch_string + "\' exploredDepositResult=\'" + this.exploredDepositResult + "\' exploredDepositResultString=\'" + EXPLORED_DEPOSIT_RESULT.toString(this.exploredDepositResult) + "\' />";
        }// end function

    }
}
