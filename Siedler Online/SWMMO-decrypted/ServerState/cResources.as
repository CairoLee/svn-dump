package ServerState
{
    import Communication.VO.*;
    import Enums.*;
    import GO.*;
    import Interface.*;
    import __AS3__.vec.*;
    import nLib.*;

    public class cResources extends Object
    {
        private var mFree:int;
        private var mWorkers:int;
        private var mZoneID:int;
        private var mMilitary:int;
        public var mDirtyIndicator:int;
        private var mResources_vector:Vector.<dResource>;
        private var mMap_ResourceName_Resource:Object;
        private var mPlayerID:int;
        private var mGeneralInterface:cGeneralInterface;
        private static const MILITARY:int = 1;
        private static const WORKER:int = 0;

        public function cResources(param1:cGeneralInterface, param2:int, param3:int)
        {
            this.mResources_vector = new Vector.<dResource>;
            this.mMap_ResourceName_Resource = new Object();
            this.mGeneralInterface = param1;
            this.mZoneID = param2;
            this.mPlayerID = param3;
            return;
        }// end function

        public function FreeWorkers(param1:int) : void
        {
            this.FreePopulation(param1, WORKER);
            return;
        }// end function

        public function GetNumberOfUnassignedPopulation() : int
        {
            return this.mFree;
        }// end function

        public function GetPlayerID() : int
        {
            return this.mPlayerID;
        }// end function

        public function GetZoneID() : int
        {
            return this.mZoneID;
        }// end function

        public function GetWorkers() : int
        {
            return this.mWorkers;
        }// end function

        public function AssignWorkers(param1:int) : Boolean
        {
            return this.AssignPopulation(param1, WORKER);
        }// end function

        public function HasPlayerResource(param1:String, param2:int) : Boolean
        {
            var _loc_3:* = this.mMap_ResourceName_Resource[param1];
            if (_loc_3.amount >= param2)
            {
                return true;
            }
            return false;
        }// end function

        public function AddResource(param1:String, param2:int) : Boolean
        {
            var _loc_3:* = this.mMap_ResourceName_Resource[param1];
            var _loc_4:* = _loc_3.amount;
            if (param2 > 0)
            {
                if (_loc_4 >= _loc_3.maxLimit)
                {
                    return false;
                }
                if (_loc_4 + param2 > _loc_3.maxLimit)
                {
                    param2 = _loc_3.maxLimit - _loc_4;
                }
                _loc_4 = _loc_4 + param2;
                this.mGeneralInterface.mDataTracking.IncTrackingDetail(cDataTracking.DATA_TRACKING_PRODUCED_RESOURCES_OF_TYPE_X, param1, param2);
            }
            else
            {
                if (_loc_4 <= 0)
                {
                    return false;
                }
                _loc_4 = _loc_4 + param2;
                if (_loc_4 < 0)
                {
                    _loc_4 = 0;
                }
            }
            _loc_3.amount = _loc_4;
            if (_loc_3.name_string == defines.POPULATION_RESOURCE_NAME_string)
            {
                this.mFree = _loc_3.amount - this.mWorkers - this.mMilitary;
            }
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return true;
        }// end function

        public function Init(param1:int, param2:int, param3:int, param4) : void
        {
            var _loc_5:dResourceVO = null;
            var _loc_6:dResource = null;
            this.mWorkers = param1;
            this.mMilitary = param2;
            this.mFree = param3;
            for each (_loc_5 in param4)
            {
                
                _loc_6 = this.GetPlayerResource(_loc_5.name_string);
                _loc_6.amount = _loc_5.amount;
            }
            return;
        }// end function

        public function RefundBuildingResourcesToPlayerResources(param1:String) : void
        {
            var _loc_2:* = global.buildingGroup.GetCostListFromName_vector(param1);
            if (_loc_2 == null)
            {
                return;
            }
            this.RefundPlayerResourcesFromResourcesInListInPercent(_loc_2, global.returnRate);
            return;
        }// end function

        public function GetNumberOfAssignedPopulation() : int
        {
            return this.mWorkers + this.mMilitary;
        }// end function

        public function FreeMilitary(param1:int) : void
        {
            this.FreePopulation(param1, MILITARY);
            return;
        }// end function

        public function AssignMilitary(param1:int) : Boolean
        {
            return this.AssignPopulation(param1, MILITARY);
        }// end function

        public function RemovePlayerResourcesFromResourcesInList(param1, param2:int) : void
        {
            var _loc_3:dResource = null;
            for each (_loc_3 in param1)
            {
                
                this.AddResource(_loc_3.name_string, (-_loc_3.amount) * param2);
            }
            return;
        }// end function

        public function HasPlayerResourcesInListOne(param1) : Boolean
        {
            return this.HasPlayerResourcesInList(param1, 1);
        }// end function

        public function GetFree() : int
        {
            return this.mFree;
        }// end function

        private function AssignPopulation(param1:int, param2:int) : Boolean
        {
            if (this.mFree < param1)
            {
                return false;
            }
            switch(param2)
            {
                case WORKER:
                {
                    this.mWorkers = this.mWorkers + param1;
                    break;
                }
                case MILITARY:
                {
                    this.mMilitary = this.mMilitary + param1;
                    break;
                }
                default:
                {
                    gMisc.Assert(false, "Could not interpret population type " + param2);
                    break;
                }
            }
            this.mFree = this.mFree - param1;
            globalFlash.gui.mInfoBar.SetPopulation(this);
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return true;
        }// end function

        public function CanPlayerAffordBuilding(param1:String) : Boolean
        {
            if (this.mGeneralInterface.mEnumUIType == UITYPE.EDITOR)
            {
                return true;
            }
            var _loc_2:* = global.buildingGroup.GetCostListFromName_vector(param1);
            gMisc.Assert(_loc_2 != null, "Building \'" + param1 + "\' has no build costs!");
            return this.HasPlayerResourcesInListOne(_loc_2);
        }// end function

        public function IsMaxLimitOfPopulationReached() : Boolean
        {
            var _loc_1:* = this.GetPlayerResource(defines.POPULATION_RESOURCE_NAME_string);
            return this.mWorkers + this.mMilitary + this.mFree >= _loc_1.maxLimit;
        }// end function

        public function RefundPlayerResourcesFromResourcesInListInPercent(param1, param2:int) : void
        {
            var _loc_3:dResource = null;
            for each (_loc_3 in param1)
            {
                
                this.AddResource(_loc_3.name_string, _loc_3.amount * param2 / 100);
            }
            return;
        }// end function

        public function CreateResourcesVO() : dResourcesVO
        {
            var _loc_2:dResource = null;
            var _loc_3:dResourceVO = null;
            var _loc_1:* = new dResourcesVO();
            _loc_1.workers = this.mWorkers;
            _loc_1.military = this.mMilitary;
            _loc_1.free = this.mFree;
            for each (_loc_2 in this.mResources_vector)
            {
                
                _loc_3 = new dResourceVO();
                _loc_3.name_string = _loc_2.name_string;
                _loc_3.amount = _loc_2.amount;
                _loc_1.resources_vector.addItem(_loc_3);
            }
            return _loc_1;
        }// end function

        public function GetMilitary() : int
        {
            return this.mMilitary;
        }// end function

        public function ApplyResourceListForCheat(param1:dResourcesVO) : void
        {
            var _loc_3:String = null;
            var _loc_4:int = 0;
            var _loc_5:dResource = null;
            var _loc_2:int = 0;
            while (_loc_2 < param1.resources_vector.length)
            {
                
                _loc_3 = param1.resources_vector[_loc_2].name_string;
                _loc_4 = param1.resources_vector[_loc_2].amount;
                _loc_5 = this.GetPlayerResource(_loc_3);
                if (_loc_4 > _loc_5.maxLimit)
                {
                    _loc_5.maxLimit = _loc_4 * 110 / 100;
                }
                this.SetResource(_loc_5.name_string, _loc_4);
                _loc_2++;
            }
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function GetPlayerResource(param1:String) : dResource
        {
            var _loc_2:* = this.mMap_ResourceName_Resource[param1];
            return _loc_2;
        }// end function

        public function CreateResourceEntries() : void
        {
            var _loc_1:dResourceDefaultDefinition = null;
            var _loc_2:dResource = null;
            this.mResources_vector.length = 0;
            this.mMap_ResourceName_Resource = new Object();
            for each (_loc_1 in gEconomics.mResourceDefaultDefinition_vector)
            {
                
                _loc_2 = new dResource();
                _loc_2.name_string = _loc_1.resourceName_string;
                _loc_2.group_string = _loc_1.group_string;
                _loc_2.amount = 0;
                _loc_2.maxLimit = gMisc.GetMaxIntValue();
                this.mResources_vector.push(_loc_2);
                this.mMap_ResourceName_Resource[_loc_2.name_string] = _loc_2;
            }
            return;
        }// end function

        public function ModifyMilitaryPopulationResource(param1:int) : void
        {
            var _loc_2:* = this.GetPlayerResource(defines.POPULATION_RESOURCE_NAME_string);
            this.mMilitary = this.mMilitary + param1;
            if (this.mMilitary < 0)
            {
                this.mMilitary = 0;
            }
            _loc_2.amount = this.mFree + this.mMilitary + this.mWorkers;
            if (param1 > 0 && _loc_2.amount > _loc_2.maxLimit)
            {
                this.mFree = this.mFree - (_loc_2.amount - _loc_2.maxLimit);
                if (this.mFree < 0)
                {
                    this.mFree = 0;
                }
                _loc_2.amount = this.mFree + this.mMilitary + this.mWorkers;
            }
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function toString() : String
        {
            return "<cResources zoneID=\'" + this.mZoneID + "\' playerID=\'" + this.mPlayerID + " workers=\'" + this.mWorkers + "\' military=\'" + this.mMilitary + "\' free=\'" + this.mFree + "\' resources=\'" + this.mResources_vector + "\' />";
        }// end function

        public function RemoveBuildingResourcesFromPlayerResources(param1:String) : void
        {
            var _loc_2:* = global.buildingGroup.GetCostListFromName_vector(param1);
            gMisc.Assert(_loc_2 != null, "Building \'" + param1 + "\' has no build costs!");
            this.RemovePlayerResourcesFromResourcesInList(_loc_2, 1);
            return;
        }// end function

        public function SetResource(param1:String, param2:int) : Boolean
        {
            var _loc_3:Boolean = false;
            var _loc_4:* = this.mMap_ResourceName_Resource[param1];
            this.mMap_ResourceName_Resource[param1].amount = param2;
            _loc_3 = true;
            if (_loc_4.amount < 0)
            {
                _loc_4.amount = 0;
                _loc_3 = false;
            }
            if (param1 == defines.POPULATION_RESOURCE_NAME_string)
            {
                this.mFree = _loc_4.amount - this.mWorkers - this.mMilitary;
            }
            return _loc_3;
        }// end function

        public function CalculateMaxLimitsForResources(param1:int) : void
        {
            var _loc_2:dResource = null;
            var _loc_3:dResourceDefaultDefinition = null;
            var _loc_4:int = 0;
            var _loc_5:Vector.<cBuilding> = null;
            var _loc_6:cBuilding = null;
            var _loc_7:dExpandMaxLimit = null;
            _loc_2 = null;
            for each (_loc_3 in gEconomics.mResourceDefaultDefinition_vector)
            {
                
                _loc_4 = int(_loc_3.maxLimit);
                _loc_5 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.GetBuildings_vector();
                for each (_loc_6 in _loc_5)
                {
                    
                    if (_loc_6.GetPlayerID() != param1)
                    {
                        continue;
                    }
                    if (_loc_6.IsInUpgradableBuildingMode())
                    {
                        for each (_loc_7 in _loc_3.expandMaxLimitList_vector)
                        {
                            
                            if (_loc_7.name_string == _loc_6.GetBuildingName_string())
                            {
                                _loc_4 = _loc_4 + (_loc_7.amount + _loc_6.GetUpgradeLevelBonuses().getGoodsCapacity());
                            }
                        }
                    }
                }
                _loc_2 = this.GetPlayerResource(_loc_3.resourceName_string);
                if (_loc_2 == null)
                {
                    this.mGeneralInterface.mLog.logPossibleError(395, "Possible java.lang.NullPointerException in CalculateMaxLimitsForResources(" + _loc_3.resourceName_string + ")");
                    continue;
                }
                _loc_2.maxLimit = _loc_4;
            }
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function GetPlayerResources_vector(param1:String)
        {
            var _loc_3:dResource = null;
            if (param1 == RESOURCE_GROUP.ALL)
            {
                return this.mResources_vector;
            }
            var _loc_2:* = new Vector.<dResource>;
            for each (_loc_3 in this.mResources_vector)
            {
                
                if (_loc_3.group_string == param1)
                {
                    _loc_2.push(_loc_3);
                }
            }
            return _loc_2;
        }// end function

        private function FreePopulation(param1:int, param2:int) : void
        {
            switch(param2)
            {
                case WORKER:
                {
                    this.mWorkers = this.mWorkers - param1;
                    break;
                }
                case MILITARY:
                {
                    this.mMilitary = this.mMilitary - param1;
                    break;
                }
                default:
                {
                    gMisc.Assert(false, "Could not interpret population type " + param2);
                    break;
                }
            }
            this.mFree = this.mFree + param1;
            globalFlash.gui.mInfoBar.SetPopulation(this);
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function InitPlayerResources() : void
        {
            var _loc_2:dResource = null;
            this.CreateResourceEntries();
            this.CalculateMaxLimitsForResources(this.mPlayerID);
            this.mWorkers = 0;
            this.mMilitary = 0;
            this.mFree = 0;
            var _loc_1:* = new Vector.<dResource>;
            gEconomics.GetResourcesFromString(global.playerResources_string, _loc_1);
            for each (_loc_2 in _loc_1)
            {
                
                this.SetResource(_loc_2.name_string, _loc_2.amount);
                if (_loc_2.name_string == defines.POPULATION_RESOURCE_NAME_string)
                {
                    this.mFree = _loc_2.amount;
                }
            }
            return;
        }// end function

        public function HasPlayerResourcesInList(param1, param2:int) : Boolean
        {
            var _loc_3:dResource = null;
            var _loc_4:dResource = null;
            if (param1 == null)
            {
                return false;
            }
            for each (_loc_3 in param1)
            {
                
                _loc_4 = this.mMap_ResourceName_Resource[_loc_3.name_string];
                if (_loc_4.amount < _loc_3.amount * param2)
                {
                    return false;
                }
            }
            return true;
        }// end function

    }
}
