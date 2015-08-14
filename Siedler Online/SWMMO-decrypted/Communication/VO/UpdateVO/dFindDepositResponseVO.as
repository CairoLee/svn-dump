package Communication.VO.UpdateVO
{
    import mx.collections.*;

    public class dFindDepositResponseVO extends Object
    {
        public var foundDeposits_vector:ArrayCollection;

        public function dFindDepositResponseVO()
        {
            this.foundDeposits_vector = new ArrayCollection();
            return;
        }// end function

        public function toString() : String
        {
            return gCalculations.createListString("dFindDepositResponseVO", this.foundDeposits_vector);
        }// end function

    }
}
