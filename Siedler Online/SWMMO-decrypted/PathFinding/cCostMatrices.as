package PathFinding
{
    import Enums.*;
    import GO.*;
    import Interface.*;
    import __AS3__.vec.*;
    import nLib.*;

    public class cCostMatrices extends Object
    {
        private var DepositName_PathCostMatrixAboveZero_map:Object;
        private var pathCostMatrix_Warehouse_list:Vector.<int> = null;
        private var DepositName_PathCostMatrixBelowMax_map:Object;
        private var playerId:int;
        private var mGeneralInterface:cGeneralInterface;
        public static const RESOURCE_NOT_AVAILABLE_list:Vector.<int> = new Vector.<int>(0);
        public static const WAREHOUSE_NOT_AVAILABLE_list:Vector.<int> = new Vector.<int>(0);

        public function cCostMatrices(param1:int, param2:cGeneralInterface)
        {
            this.DepositName_PathCostMatrixAboveZero_map = new Object();
            this.DepositName_PathCostMatrixBelowMax_map = new Object();
            this.playerId = param1;
            this.mGeneralInterface = param2;
            return;
        }// end function

        public function getCostMatrixForDeposit_list(param1:String, param2:int)
        {
            var _loc_4:Vector.<int> = null;
            var _loc_5:cDeposit = null;
            var _loc_6:Vector.<int> = null;
            var _loc_7:int = 0;
            var _loc_3:Vector.<int> = null;
            switch(param2)
            {
                case cPathFinder.AMOUNT_TYPE_ABOVE_ZERO:
                {
                    _loc_3 = this.DepositName_PathCostMatrixAboveZero_map[param1];
                    break;
                }
                case cPathFinder.AMOUNT_TYPE_BELOW_MAX:
                {
                    _loc_3 = this.DepositName_PathCostMatrixBelowMax_map[param1];
                    break;
                }
                default:
                {
                    gMisc.Assert(false, "Could not interpret amountType " + param2);
                    break;
                }
            }
            if (_loc_3 == null)
            {
                _loc_4 = new Vector.<int>;
                for each (_loc_5 in this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.GetDeposits_vector())
                {
                    
                    if (param1 == _loc_5.GetName_string() && (param2 == cPathFinder.AMOUNT_TYPE_ABOVE_ZERO ? (_loc_5.GetAmount() > 0) : (_loc_5.GetAmount() < _loc_5.GetMaxAmount())) && _loc_5.GetAccessibleType() == DEPOSIT_ACCESSIBLE_TYPES.ACCESSIBLE)
                    {
                        _loc_7 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_5.GetGridIdx()].mSectorId;
                        if (this.mGeneralInterface.mCurrentPlayerZone.mSectorList_vector[_loc_7].GetOwnerPlayerID() == this.playerId)
                        {
                            _loc_4.push(_loc_5.GetGridIdx());
                        }
                    }
                }
                if (_loc_4.length == 0)
                {
                    _loc_6 = RESOURCE_NOT_AVAILABLE_list;
                }
                else
                {
                    _loc_6 = this.mGeneralInterface.mCreatePath.CalculatePathCostMatrix_list(_loc_4);
                }
                switch(param2)
                {
                    case cPathFinder.AMOUNT_TYPE_ABOVE_ZERO:
                    {
                        this.DepositName_PathCostMatrixAboveZero_map[param1] = _loc_6;
                        break;
                    }
                    case cPathFinder.AMOUNT_TYPE_BELOW_MAX:
                    {
                        this.DepositName_PathCostMatrixBelowMax_map[param1] = _loc_6;
                        break;
                    }
                    default:
                    {
                        gMisc.Assert(false, "Could not interpret amountType " + param2);
                        break;
                    }
                }
                _loc_3 = _loc_6;
            }
            return _loc_3;
        }// end function

        public function invalidateCostMatrixForDeposit(param1:String, param2:int) : void
        {
            switch(param2)
            {
                case cPathFinder.AMOUNT_TYPE_ABOVE_ZERO:
                {
                    this.DepositName_PathCostMatrixAboveZero_map[param1] = null;
                    break;
                }
                case cPathFinder.AMOUNT_TYPE_BELOW_MAX:
                {
                    this.DepositName_PathCostMatrixBelowMax_map[param1] = null;
                    break;
                }
                default:
                {
                    gMisc.Assert(false, "Could not interpret amountType " + param2);
                    break;
                }
            }
            return;
        }// end function

        public function invalidateCostMatrixForWarehouse() : void
        {
            this.pathCostMatrix_Warehouse_list = null;
            return;
        }// end function

        public function InvalidateAll() : void
        {
            this.pathCostMatrix_Warehouse_list = null;
            this.DepositName_PathCostMatrixAboveZero_map = new Object();
            this.DepositName_PathCostMatrixBelowMax_map = new Object();
            return;
        }// end function

        public function getCostMatrixForWarehouse_list()
        {
            var _loc_1:Vector.<int> = null;
            var _loc_2:cBuilding = null;
            if (this.pathCostMatrix_Warehouse_list == null)
            {
                _loc_1 = new Vector.<int>;
                for each (_loc_2 in this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.GetBuildings_vector())
                {
                    
                    if (_loc_2.IsBuildingActive() && _loc_2.IsWarehouseType())
                    {
                        if (_loc_2.GetPlayerID() == this.playerId)
                        {
                            _loc_1.push(_loc_2.GetStreetGridEntry());
                        }
                    }
                }
                if (_loc_1.length == 0)
                {
                    return WAREHOUSE_NOT_AVAILABLE_list;
                }
                this.pathCostMatrix_Warehouse_list = this.mGeneralInterface.mCreatePath.CalculatePathCostMatrix_list(_loc_1);
            }
            return this.pathCostMatrix_Warehouse_list;
        }// end function

    }
}
