package Communication.VO.UpdateVO
{
    import Communication.VO.*;
    import Enums.*;

    public class dFoundDepositVO extends Object
    {
        public var depositVO:dDepositVO;
        public var exploredDepositResult:int;
        public var specialistID:dUniqueID;

        public function dFoundDepositVO()
        {
            return;
        }// end function

        public function toString() : String
        {
            return "<dFoundDepositVO specialistID=" + this.specialistID + ", depositVO=" + this.depositVO + ", exploredDepositResult=" + EXPLORED_DEPOSIT_RESULT.toString(this.exploredDepositResult) + " >";
        }// end function

    }
}
