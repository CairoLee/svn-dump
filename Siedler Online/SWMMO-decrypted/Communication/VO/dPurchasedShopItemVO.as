package Communication.VO
{

    public class dPurchasedShopItemVO extends Object
    {
        public var hardCurrencySpend:int;
        public var timeOfPurchase:Number = 0;
        public var giftedToPlayerId:int;
        public var shopItemID:int;
        public var playerLevelAtPurchase:int;
        public var resourcesSpend:String = "";
        public var dirtyIndicator:int;

        public function dPurchasedShopItemVO()
        {
            return;
        }// end function

        public function toString() : String
        {
            return "<dPurchasedShopItemVO shopItemID=\'" + this.shopItemID + "\' hardCurrencySpend=\'" + this.hardCurrencySpend + "\' resourcesSpend=\'" + this.resourcesSpend + "\' timeOfPurchase=\'" + this.timeOfPurchase + "\'playerLevelAtPurchase=\'" + this.playerLevelAtPurchase + "\'giftedToPlayerId=\'" + this.giftedToPlayerId + "\'/>";
        }// end function

    }
}
