package Communication.VO
{
    import Enums.*;
    import mx.collections.*;

    public class dTimedProductionVO extends Object
    {
        public var producedItems:int;
        public var uniqueIds:ArrayCollection;
        public var productionType:int;
        public var type_string:String;
        public var amount:int;
        public var uniqueId:dUniqueID;
        public var playerId:int;
        public var collectedTime:Number;

        public function dTimedProductionVO()
        {
            this.uniqueIds = new ArrayCollection();
            return;
        }// end function

        public function toString() : String
        {
            var _loc_2:dUniqueID = null;
            var _loc_1:* = "<dTimedProductionVO uniqueId=\'" + this.uniqueId + "\' playerId=\'" + this.playerId + "productionType=\'" + TIMED_PRODUCTION_TYPE.toString(this.productionType) + "\' type=\'" + this.type_string + "\' amount=\'" + this.amount + "\' producedItems=\'" + this.producedItems + "\' mCollectedTime=\'" + this.collectedTime + " >";
            for each (_loc_2 in this.uniqueIds)
            {
                
                _loc_1 = _loc_1 + ("<uniqueIds id=\'" + _loc_2 + "\' />");
            }
            _loc_1 = _loc_1 + "</dTimedProductionVO>";
            return _loc_1;
        }// end function

    }
}
