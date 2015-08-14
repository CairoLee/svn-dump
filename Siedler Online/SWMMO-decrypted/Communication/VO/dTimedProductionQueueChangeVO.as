package Communication.VO
{

    public class dTimedProductionQueueChangeVO extends Object
    {
        public var queueIndex:int;
        public var productionType:int;

        public function dTimedProductionQueueChangeVO()
        {
            return;
        }// end function

        public function toString() : String
        {
            return "<dTimedProductionVO productionType=\'" + this.productionType + "\' queueIndex=\'" + this.queueIndex + "\' />";
        }// end function

    }
}
