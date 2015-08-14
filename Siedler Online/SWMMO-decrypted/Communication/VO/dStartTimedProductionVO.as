package Communication.VO
{
    import Enums.*;
    import mx.collections.*;

    public class dStartTimedProductionVO extends Object
    {
        public var productionType:int;
        public var type_string:String;
        public var uniqueIds:ArrayCollection;
        public var amount:int;

        public function dStartTimedProductionVO()
        {
            return;
        }// end function

        public function toString() : String
        {
            return "<dStartTimedProductionVO productionType=\'" + TIMED_PRODUCTION_TYPE.toString(this.productionType) + "\' type_string=\'" + this.type_string + "\' amount=\'" + this.amount + "\' />";
        }// end function

    }
}
