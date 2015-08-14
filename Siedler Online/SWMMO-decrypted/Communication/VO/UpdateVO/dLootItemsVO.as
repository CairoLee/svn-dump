package Communication.VO.UpdateVO
{
    import Communication.VO.*;
    import mx.collections.*;

    public class dLootItemsVO extends Object
    {
        public var items:ArrayCollection;
        public var shopItemId:int;
        public var uniqueIDs:ArrayCollection;
        public var mailId:int;
        public var uniqueID:dUniqueID;

        public function dLootItemsVO()
        {
            this.items = new ArrayCollection();
            this.uniqueIDs = new ArrayCollection();
            return;
        }// end function

        public function toString() : String
        {
            var _loc_2:Object = null;
            var _loc_3:Object = null;
            var _loc_1:String = "";
            _loc_1 = _loc_1 + ("<dLootItemsVO shopItemId=\'" + this.shopItemId + " mailId=\'" + this.mailId + "\' uniqueID=\'" + _loc_3 + "\' >");
            for each (_loc_2 in this.items)
            {
                
                _loc_1 = _loc_1 + ("  " + _loc_2 + "\n");
            }
            for each (_loc_3 in this.uniqueIDs)
            {
                
                _loc_1 = _loc_1 + ("  " + _loc_3 + "\n");
            }
            _loc_1 = _loc_1 + "</dLootItemsVO>\n";
            return _loc_1;
        }// end function

    }
}
