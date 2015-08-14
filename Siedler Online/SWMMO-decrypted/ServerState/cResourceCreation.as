package ServerState
{
    import Communication.VO.*;
    import Enums.*;
    import GO.*;
    import PathFinding.*;
    import SettlerKI.*;

    public class cResourceCreation extends Object
    {
        private var settler:cSettler;
        private var gatheredResource:int;
        private var resourceCreationHouse:cBuilding;
        public var settlerWithoutGoods:String = "";
        private var removeFlag:Boolean;
        private var path:cPathObject;
        public var mDirtyIndicator:int;
        private var playerID:int;
        private var storeHouse:cBuilding;
        private var resourceCreationDefinition:dResourceCreationDefinition;
        public var protocollResourceCreationLastBuildingMode:int;
        private var assignedSettler:Boolean;
        private var depositBuildingGridPos:int;
        private var productionState:int;
        private var depositPath:cPathObject;
        public var settlerWithGoods:String = "";
        private var settlerKIState:int;
        public var pathPos:int;
        private var invalidatePaths:Boolean = false;
        public var protocollResourceCreationProcessCntr:int;
        public static const PRODUCTIONSTATE_ERROR_WAITING_FOR_SETTLER:int = 3;
        public static const PRODUCTIONSTATE_ERROR_NECESSARY_RESOURCE_MISSING:int = 1;
        public static const PRODUCTIONSTATE_ERROR_WAREHOUSE_FULL:int = 2;
        public static const PRODUCTIONSTATE_WORKING:int = 0;
        public static const BUILDINGUPGRADE_PRODUCTIONSTATE_UPDATE_IN_PROGRESS:int = 7;
        public static const PRODUCTIONSTATE_BUFF_STOPPED_PRODUCTION:int = 8;
        public static const PRODUCTIONSTATE_STOPPED_PRODUCTION:int = 5;
        public static const PRODUCTIONSTATE_MISSING_STREET:int = 6;
        public static const PRODUCTIONSTATE_ERROR_WAITING_FOR_TOOL:int = 4;

        public function cResourceCreation(param1:int, param2:dResourceCreationDefinition, param3:cBuilding)
        {
            this.resourceCreationDefinition = param2;
            this.playerID = param1;
            this.resourceCreationHouse = param3;
            return;
        }// end function

        public function toString() : String
        {
            return "<ResourceCreation " + " depositBuildingGridPos=" + this.depositBuildingGridPos + " depositPath=" + this.depositPath + " resourceCreationDefinition=" + this.resourceCreationDefinition + " path=" + this.path + " invalidatePaths=" + this.invalidatePaths + " pathPos=" + this.pathPos + " gatheredResource=" + this.gatheredResource + " storeHouse=" + this.storeHouse + " resourceCreationHouse=" + this.resourceCreationHouse + " settler=" + this.settler + " playerID=" + this.playerID + " removeFlag=" + this.removeFlag + " assignedSettler=" + this.assignedSettler + " settlerKIState=" + this.settlerKIState + " productionState=" + this.productionState + " mDirtyIndicator=" + this.mDirtyIndicator + " definition=" + this.resourceCreationDefinition + " >";
        }// end function

        public function SetKIStateMoving() : void
        {
            if (this.settler != null && this.settler.mSettlerKi != null)
            {
                this.settler.mSettlerKi.SetKIStateMoving();
            }
            return;
        }// end function

        public function GetPlayerID() : int
        {
            return this.playerID;
        }// end function

        public function GetResourceCreationDefinition() : dResourceCreationDefinition
        {
            return this.resourceCreationDefinition;
        }// end function

        public function SetPlayerID(param1:int) : void
        {
            this.playerID = param1;
            return;
        }// end function

        public function SetPath(param1:cPathObject) : Boolean
        {
            this.path = param1;
            return true;
        }// end function

        public function SetStoreHouse(param1:cBuilding) : Boolean
        {
            this.storeHouse = param1;
            return true;
        }// end function

        public function GetStoreHouse() : cBuilding
        {
            return this.storeHouse;
        }// end function

        public function HasInvalidatedPaths() : Boolean
        {
            return this.invalidatePaths;
        }// end function

        public function SetProductionState(param1:int) : void
        {
            if (this.productionState == param1)
            {
                return;
            }
            this.productionState = param1;
            if (this.productionState != PRODUCTIONSTATE_STOPPED_PRODUCTION && this.resourceCreationHouse != null && this.resourceCreationHouse.IsBuildingInProduction())
            {
                this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.WEAK_MODIFICATION_BIT;
            }
            else
            {
                this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            }
            return;
        }// end function

        public function SetAssignedSettler(param1:Boolean) : void
        {
            if (param1 == this.assignedSettler)
            {
                return;
            }
            this.assignedSettler = param1;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function GetDepositBuildingGridPos() : int
        {
            return this.depositBuildingGridPos;
        }// end function

        public function SetDepositBuildingGridPos(param1:int) : Boolean
        {
            if (param1 == this.depositBuildingGridPos)
            {
                return true;
            }
            this.depositBuildingGridPos = param1;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return true;
        }// end function

        public function SetDepositPath(param1:cPathObject) : Boolean
        {
            this.depositPath = param1;
            return true;
        }// end function

        public function GetSettlerKIState() : int
        {
            return this.settlerKIState;
        }// end function

        public function GetAssignedSettler() : Boolean
        {
            return this.assignedSettler;
        }// end function

        public function CreateResourceCreationVOFromResourceCreation() : dResourceCreationVO
        {
            var _loc_2:dPathObjectItem = null;
            var _loc_1:* = new dResourceCreationVO();
            if (this.GetResourceCreationDefinition() != null)
            {
                _loc_1.resourceDefinitionID = this.GetResourceCreationDefinition().id;
            }
            else
            {
                _loc_1.resourceDefinitionID = -1;
            }
            _loc_1.protocollResourceCreationProcessCntr = this.protocollResourceCreationProcessCntr;
            _loc_1.protocollResourceCreationLastBuildingMode = this.protocollResourceCreationLastBuildingMode;
            _loc_1.depositBuildingGridPos = this.GetDepositBuildingGridPos();
            _loc_1.pathPos = this.pathPos;
            _loc_1.playerId = this.GetPlayerID();
            _loc_1.assignedSettler = this.GetAssignedSettler();
            _loc_1.settlerKIState = this.GetSettlerKIState();
            _loc_1.gatheredResource = this.GetGatheredResource();
            _loc_1.productionState = this.GetProductionState();
            _loc_1.remove = this.GetRemove();
            if (this.GetDepositPath() != null)
            {
                _loc_1.pathVO = new dPathVO();
                for each (_loc_2 in this.GetDepositPath().dest_vector)
                {
                    
                    _loc_1.pathVO.mPath.addItem(_loc_2.streetGridIdx);
                }
            }
            else
            {
                _loc_1.pathVO = null;
            }
            if (this.GetResourceCreationHouse() != null)
            {
                _loc_1.resourceCreationHouseGrid = this.GetResourceCreationHouse().GetBuildingGrid();
            }
            else
            {
                _loc_1.resourceCreationHouseGrid = -1;
            }
            return _loc_1;
        }// end function

        public function GetProductionState() : int
        {
            return this.productionState;
        }// end function

        public function GetDepositPath() : cPathObject
        {
            return this.depositPath;
        }// end function

        public function SetInvalidatePaths(param1:Boolean) : void
        {
            this.invalidatePaths = param1;
            return;
        }// end function

        public function SetSettlerKIState(param1:int) : void
        {
            this.settlerKIState = param1;
            if (this.resourceCreationHouse != null && this.resourceCreationHouse.IsBuildingInProduction())
            {
                this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.WEAK_MODIFICATION_BIT;
            }
            else
            {
                this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            }
            if (this.settler != null)
            {
                this.settler.mSettlerKi.SetKIState(param1);
            }
            return;
        }// end function

        public function GetRemove() : Boolean
        {
            return this.removeFlag;
        }// end function

        public function SetWorkingSettlerCarries() : void
        {
            this.settler.SetSpriteImage(this.settlerWithGoods);
            return;
        }// end function

        public function SetSettlerKIStateDeactivate() : void
        {
            this.SetSettlerKIState(cSettlerKI.SETTLER_STATE_REMOVE_SETTLER);
            return;
        }// end function

        public function GetGatheredResource() : int
        {
            return this.gatheredResource;
        }// end function

        public function SetGatheredResource(param1:int) : Boolean
        {
            this.gatheredResource = param1;
            if (this.resourceCreationHouse != null && this.resourceCreationHouse.IsBuildingInProduction())
            {
                this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.WEAK_MODIFICATION_BIT;
            }
            else
            {
                this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            }
            return true;
        }// end function

        public function GetNecessaryResourceTypeString() : String
        {
            var _loc_2:dResource = null;
            var _loc_1:String = "";
            for each (_loc_2 in this.GetResourceCreationDefinition().necessaryResources_vector)
            {
                
                if (_loc_1 != "")
                {
                    _loc_1 = _loc_1 + "|";
                }
                _loc_1 = _loc_1 + (_loc_2.name_string + "," + _loc_2.amount);
            }
            return _loc_1;
        }// end function

        public function SetRemove(param1:Boolean) : void
        {
            if (this.removeFlag == param1)
            {
                return;
            }
            this.removeFlag = param1;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function GetSettler() : cSettler
        {
            return this.settler;
        }// end function

        public function RestoreKIStateBeforeMoving() : void
        {
            this.settler.mSettlerKi.RestoreKIStateBeforeMoving();
            return;
        }// end function

        public function SetSettler(param1:cSettler) : void
        {
            this.settler = param1;
            return;
        }// end function

        public function GetResourceTypeString() : String
        {
            switch(this.GetResourceCreationDefinition().typeEnumResourceType)
            {
                case RESOURCE_TYPE.CREATED_BY_BUILDING:
                {
                    return "Created By Building";
                }
                case RESOURCE_TYPE.CREATED_ALWAYS:
                {
                    return "Created always";
                }
                default:
                {
                    break;
                }
            }
            return "unknown";
        }// end function

        public function GetPath() : cPathObject
        {
            return this.path;
        }// end function

        public function GetResourceCreationHouse() : cBuilding
        {
            return this.resourceCreationHouse;
        }// end function

        public function SetWorkingSettler() : void
        {
            this.settler.SetSpriteImage(this.settlerWithoutGoods);
            return;
        }// end function

    }
}
