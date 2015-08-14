package Communication.VO
{
    import flash.utils.*;

    public class dBuyOneClickShopItemVO extends Object
    {
        public var buildingGridIdx:int;
        public var itemId:int;
        public var uniqueID:dUniqueID;

        public function dBuyOneClickShopItemVO()
        {
            return;
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            this.itemId = param1.readInt();
            this.buildingGridIdx = param1.readInt();
            return;
        }// end function

        public function InitWithUniqueID(param1:int, param2:dUniqueID) : dBuyOneClickShopItemVO
        {
            this.itemId = param1;
            this.uniqueID = param2;
            return this;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeInt(this.itemId);
            param1.writeInt(this.buildingGridIdx);
            return;
        }// end function

        public function toString() : String
        {
            return "<dBuyOneClickShopItemVO itemId=\'" + this.itemId + "\' buildingGridIdx=\'" + this.buildingGridIdx + "\' uniqueID=\'" + this.uniqueID + "\' />";
        }// end function

        public function Init(param1:int) : dBuyOneClickShopItemVO
        {
            this.itemId = param1;
            return this;
        }// end function

        public function InitWithBuildingGrid(param1:int, param2:int) : dBuyOneClickShopItemVO
        {
            this.itemId = param1;
            this.buildingGridIdx = param2;
            return this;
        }// end function

    }
}
