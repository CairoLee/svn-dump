package TimedProduction
{
    import Communication.VO.*;
    import Interface.*;
    import ServerState.*;
    import TimedProduction.*;
    import __AS3__.vec.*;
    import mx.collections.*;
    import nLib.*;

    public class cAbstractTimedProductionOrder extends Object implements iProductionOrder
    {
        private var mType_string:String;
        private var productionType:int;
        private var uniqueIds_vector:Vector.<dUniqueID>;
        private var mAmount:int;

        public function cAbstractTimedProductionOrder(param1:String, param2:int, param3:int)
        {
            this.uniqueIds_vector = new Vector.<dUniqueID>;
            this.productionType = param3;
            this.mType_string = param1;
            this.mAmount = param2;
            return;
        }// end function

        public function GetOnFinishedAvatarMessageType() : String
        {
            gMisc.Assert(false, "This method must not be called!!");
            return "";
        }// end function

        public function GetNextUniqueId() : dUniqueID
        {
            var _loc_1:dUniqueID = null;
            if (this.uniqueIds_vector.length > 0)
            {
                _loc_1 = this.uniqueIds_vector[0];
                this.uniqueIds_vector.splice(0, 1);
                return _loc_1;
            }
            return null;
        }// end function

        public function GetTimeBonus(param1:cGeneralInterface) : Number
        {
            gMisc.Assert(false, "This method must not be called!!");
            return 1;
        }// end function

        public function GetCostsToBuy_vector()
        {
            gMisc.Assert(false, "This method must not be called!!");
            return null;
        }// end function

        public function getProductionType() : int
        {
            return this.productionType;
        }// end function

        public function setProductionType(param1:int) : void
        {
            this.productionType = param1;
            return;
        }// end function

        public function CreateItem(param1:cPlayerData, param2:cGeneralInterface, param3:int) : void
        {
            gMisc.Assert(false, "This method must not be called!!");
            return;
        }// end function

        public function GetType_string() : String
        {
            return this.mType_string;
        }// end function

        public function GetInstantBuildCosts() : int
        {
            gMisc.Assert(false, "This method must not be called!!");
            return 0;
        }// end function

        public function AddUniqueIds(param1:ArrayCollection) : void
        {
            var _loc_2:dUniqueID = null;
            for each (_loc_2 in param1)
            {
                
                this.uniqueIds_vector.push(_loc_2);
            }
            return;
        }// end function

        public function GetAmount() : int
        {
            return this.mAmount;
        }// end function

        public function GetUniqueIds_vector()
        {
            return this.uniqueIds_vector;
        }// end function

        public function GetProductionTime() : int
        {
            gMisc.Assert(false, "This method must not be called!!");
            return -1;
        }// end function

    }
}
