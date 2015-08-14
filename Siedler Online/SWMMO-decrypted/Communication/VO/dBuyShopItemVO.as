package Communication.VO
{
    import mx.collections.*;

    public class dBuyShopItemVO extends Object
    {
        public var shopItemContent_vector:ArrayCollection;
        public var giftedPlayerID:int;
        public var itemID:int;

        public function dBuyShopItemVO()
        {
            this.shopItemContent_vector = new ArrayCollection();
            return;
        }// end function

        public function toString() : String
        {
            var _loc_1:* = "<dBuyShopItemVO giftedPlayerID=\'" + this.giftedPlayerID + "\' itemID=\'" + this.itemID + "\' >";
            gCalculations.createListString("ShopItemContent", this.shopItemContent_vector);
            _loc_1 = _loc_1 + "</dBuyShopItemVO>";
            return _loc_1;
        }// end function

    }
}
