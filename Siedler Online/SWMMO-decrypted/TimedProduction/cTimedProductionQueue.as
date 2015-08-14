package TimedProduction
{
    import Enums.*;
    import GO.*;
    import Interface.*;
    import ServerState.*;
    import __AS3__.vec.*;
    import nLib.*;

    public class cTimedProductionQueue extends Object
    {
        private var mProductionType:int;
        private const TIMEOUT:int = 30000;
        private var mLastServerCall:int = 0;
        private var mWaitingForServerResponse:Boolean = false;
        public const mTimedProductions_vector:Vector.<cTimedProduction>;
        private var mGeneralInterface:cGeneralInterface;

        public function cTimedProductionQueue(param1:cGeneralInterface, param2:int)
        {
            this.mTimedProductions_vector = new Vector.<cTimedProduction>;
            this.mGeneralInterface = param1;
            this.mProductionType = param2;
            return;
        }// end function

        public function FinishProduction(param1:cPlayerData) : void
        {
            if (this.mTimedProductions_vector.length == 0)
            {
                return;
            }
            var _loc_2:* = this.mTimedProductions_vector[0];
            _loc_2.FinishProduction(param1, this.mGeneralInterface);
            globalFlash.gui.mAvatarMessageList.AddMessage(_loc_2.GetProductionOrder().GetOnFinishedAvatarMessageType());
            this.mTimedProductions_vector.splice(0, 1);
            globalFlash.gui.mTimedProductionInfoPanel.Refresh();
            return;
        }// end function

        public function Perform(param1:cPlayerData) : void
        {
            var _loc_3:cBuilding = null;
            var _loc_4:Number = NaN;
            if (this.mTimedProductions_vector.length == 0)
            {
                return;
            }
            var _loc_2:* = this.mTimedProductions_vector[0];
            switch(_loc_2.GetProductionOrder().getProductionType())
            {
                case TIMED_PRODUCTION_TYPE.BUFF:
                {
                    _loc_3 = this.mGeneralInterface.mCurrentPlayerZone.GetFirstBuildingOnMap(defines.PROVISIONHOUSE_NAME_string);
                    if (_loc_3 != null && !_loc_3.mBuildingUpgradeIsInProgress)
                    {
                        _loc_2.IncCollectedTime(this.mGeneralInterface.mClientDeltaTime, this.mGeneralInterface);
                    }
                    break;
                }
                case TIMED_PRODUCTION_TYPE.MILITARY_UNIT:
                {
                    _loc_3 = this.mGeneralInterface.mCurrentPlayerZone.GetFirstBuildingOnMap(defines.BARRACKS_NAME_string);
                    if (_loc_3 != null && !_loc_3.mBuildingUpgradeIsInProgress)
                    {
                        _loc_2.IncCollectedTime(this.mGeneralInterface.mClientDeltaTime, this.mGeneralInterface);
                    }
                    break;
                }
                default:
                {
                    gMisc.Assert(false, "Could not interpret production type " + _loc_2.GetProductionOrder().GetType_string());
                    break;
                }
            }
            if (_loc_2.GetCollectedTime() >= _loc_2.GetProductionTime())
            {
                _loc_2.IncCollectedTime(-_loc_2.GetProductionTime(), this.mGeneralInterface);
                _loc_2.SetProducedItems((_loc_2.GetProducedItems() + 1));
                if (_loc_2.GetProducedItems() >= _loc_2.GetAmount())
                {
                    _loc_2.GetProductionOrder().CreateItem(param1, this.mGeneralInterface, _loc_2.GetAmount());
                    globalFlash.gui.mAvatarMessageList.AddMessage(_loc_2.GetProductionOrder().GetOnFinishedAvatarMessageType());
                    _loc_4 = _loc_2.GetCollectedTime();
                    this.mTimedProductions_vector.splice(0, 1);
                    if (this.mTimedProductions_vector.length > 0)
                    {
                        this.mTimedProductions_vector[0].IncCollectedTime(_loc_4, this.mGeneralInterface);
                        this.mTimedProductions_vector[0].mDirtyIndicator = this.mTimedProductions_vector[0].mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
                    }
                    globalFlash.gui.mTimedProductionInfoPanel.Refresh();
                }
            }
            return;
        }// end function

        public function CancelProduction(param1:int, param2:int) : void
        {
            var _loc_6:dResource = null;
            var _loc_7:cResources = null;
            if (param2 < 0 || param2 >= this.mTimedProductions_vector.length)
            {
                gMisc.ConsoleOut("Cannot remove production #" + param2 + ": length=" + this.mTimedProductions_vector.length);
                return;
            }
            var _loc_3:* = this.mTimedProductions_vector[param2];
            if (_loc_3.GetCollectedTime() > 0)
            {
                gMisc.ConsoleOut("Cannot cancel started recruitment!");
                return;
            }
            this.mTimedProductions_vector.splice(param2, 1);
            var _loc_4:* = new Vector.<dResource>;
            var _loc_5:dResource = null;
            for each (_loc_6 in _loc_3.GetProductionOrder().GetCostsToBuy_vector())
            {
                
                if (_loc_6.name_string == defines.POPULATION_RESOURCE_NAME_string)
                {
                    _loc_5 = _loc_6;
                    continue;
                }
                _loc_4.push(_loc_6);
            }
            _loc_7 = this.mGeneralInterface.mCurrentPlayerZone.GetResourcesForPlayerID(param1);
            _loc_7.RefundPlayerResourcesFromResourcesInListInPercent(_loc_4, _loc_3.GetAmount() * 100);
            if (_loc_5 != null)
            {
                _loc_7.FreeMilitary(_loc_3.GetAmount() * _loc_5.amount);
            }
            return;
        }// end function

        public function GetWaitingForServer() : Boolean
        {
            if (this.mLastServerCall > 0 && this.mLastServerCall < gMisc.GetTimeSinceStartup() - this.TIMEOUT)
            {
                this.mWaitingForServerResponse = false;
                gMisc.ConsoleOut("No server response for 30 seconds in: " + this);
            }
            return this.mWaitingForServerResponse;
        }// end function

        public function SetWaitingForServer(param1:Boolean) : void
        {
            if (param1)
            {
                this.mLastServerCall = gMisc.GetTimeSinceStartup();
            }
            else
            {
                this.mLastServerCall = 0;
            }
            this.mWaitingForServerResponse = param1;
            if (!param1)
            {
                globalFlash.gui.mTimedProductionInfoPanel.Refresh();
            }
            return;
        }// end function

    }
}
