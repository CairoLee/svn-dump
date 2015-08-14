package PathFinding
{
    import Interface.*;
    import __AS3__.vec.*;

    public class cPathFinder extends Object
    {
        public var map_PlayerId_CostMatrices:Object;
        private var mGeneralInterface:cGeneralInterface;
        public static const AMOUNT_TYPE_ABOVE_ZERO:int = 0;
        public static const AMOUNT_TYPE_BELOW_MAX:int = 1;

        public function cPathFinder(param1:cGeneralInterface)
        {
            this.map_PlayerId_CostMatrices = new Object();
            this.mGeneralInterface = param1;
            return;
        }// end function

        public function CalculatePathForDeposit(param1:String, param2:int, param3:int, param4:int) : cPathObject
        {
            var _loc_5:* = this.map_PlayerId_CostMatrices[param3];
            if (this.map_PlayerId_CostMatrices[param3] == null)
            {
                _loc_5 = new cCostMatrices(param3, this.mGeneralInterface);
                this.map_PlayerId_CostMatrices[param3] = _loc_5;
            }
            var _loc_6:* = _loc_5.getCostMatrixForDeposit_list(param1, param4);
            if (_loc_5.getCostMatrixForDeposit_list(param1, param4) === cCostMatrices.RESOURCE_NOT_AVAILABLE_list)
            {
                return null;
            }
            var _loc_7:* = this.mGeneralInterface.mCreatePath.GetNearestDestinationGridIdx(param2, _loc_6);
            return this.mGeneralInterface.mCreatePath.CalculateStreetPathFromMatrix(param2, _loc_7, _loc_6, true);
        }// end function

        public function CalculatePathForDestinations(param1:int, param2, param3:int) : cPathObject
        {
            var _loc_4:* = this.mGeneralInterface.mCreatePath.CalculatePathCostMatrix_list(param2);
            var _loc_5:* = this.mGeneralInterface.mCreatePath.GetNearestDestinationGridIdx(param1, _loc_4);
            return this.mGeneralInterface.mCreatePath.CalculateStreetPathFromMatrix(param1, _loc_5, _loc_4, false);
        }// end function

        public function InvalidateDepositMatrix(param1:int, param2:String, param3:int) : void
        {
            var _loc_4:* = this.map_PlayerId_CostMatrices[param1];
            if (this.map_PlayerId_CostMatrices[param1] != null)
            {
                _loc_4.invalidateCostMatrixForDeposit(param2, param3);
            }
            return;
        }// end function

        public function CalculatePathForWarehouse(param1:int, param2:int) : cPathObject
        {
            var _loc_3:* = this.map_PlayerId_CostMatrices[param2];
            if (_loc_3 == null)
            {
                _loc_3 = new cCostMatrices(param2, this.mGeneralInterface);
                this.map_PlayerId_CostMatrices[param2] = _loc_3;
            }
            var _loc_4:* = _loc_3.getCostMatrixForWarehouse_list();
            if (_loc_3.getCostMatrixForWarehouse_list() == cCostMatrices.WAREHOUSE_NOT_AVAILABLE_list)
            {
                return null;
            }
            var _loc_5:* = this.mGeneralInterface.mCreatePath.GetNearestDestinationGridIdx(param1, _loc_4);
            return this.mGeneralInterface.mCreatePath.CalculateStreetPathFromMatrix(param1, _loc_5, _loc_4, false);
        }// end function

        public function InvalidateAll(param1:int) : void
        {
            var _loc_2:* = this.map_PlayerId_CostMatrices[param1];
            if (_loc_2 != null)
            {
                _loc_2.InvalidateAll();
            }
            return;
        }// end function

        public function InvalidateWarehouseMatrix(param1:int) : void
        {
            var _loc_2:* = this.map_PlayerId_CostMatrices[param1];
            if (_loc_2 != null)
            {
                _loc_2.invalidateCostMatrixForWarehouse();
            }
            return;
        }// end function

        public function CalculatePath(param1:int, param2:int, param3:int, param4:Boolean) : cPathObject
        {
            var _loc_5:* = new Vector.<int>;
            new Vector.<int>.push(param1);
            var _loc_6:* = this.mGeneralInterface.mCreatePath.CalculatePathCostMatrix_list(_loc_5);
            return this.mGeneralInterface.mCreatePath.CalculateStreetPathFromMatrix(param2, param1, _loc_6, param4);
        }// end function

        public function PrintDepositMatrix(param1:int, param2:String) : void
        {
            var _loc_3:* = this.map_PlayerId_CostMatrices[param1];
            if (_loc_3 != null)
            {
                cCreatePath.printWayCostMatrix(_loc_3.getCostMatrixForDeposit_list(param2, AMOUNT_TYPE_ABOVE_ZERO), false);
            }
            return;
        }// end function

    }
}
