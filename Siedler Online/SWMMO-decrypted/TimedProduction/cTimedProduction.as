package TimedProduction
{
    import BuffSystem.*;
    import Communication.VO.*;
    import Enums.*;
    import Interface.*;
    import MilitarySystem.*;
    import ServerState.*;
    import __AS3__.vec.*;
    import flash.events.*;
    import mx.events.*;
    import nLib.*;

    public class cTimedProduction extends Object implements IEventDispatcher
    {
        private var mType_string:String;
        private var mAmount:int;
        public var mDirtyIndicator:int;
        private var mWaitingForServer:Boolean;
        private var mProducedItems:int;
        private var _1098885459mProductionProgress:Number = 0;
        private var _bindingEventDispatcher:EventDispatcher;
        private var mCollectedTime:Number = 0;
        private var mHasStarted:Boolean = false;
        private var mUniqueId:dUniqueID;
        private var mProductionType:int;
        private var mProductionOrder:iProductionOrder;
        private var mPlayerId:int;
        private var mProductionTime:int;

        public function cTimedProduction()
        {
            this._bindingEventDispatcher = new EventDispatcher(IEventDispatcher(this));
            return;
        }// end function

        public function SetWaitingForServer(param1:Boolean) : void
        {
            this.mWaitingForServer = param1;
            return;
        }// end function

        public function GetUniqueID() : dUniqueID
        {
            return this.mUniqueId;
        }// end function

        public function GetProductionTime() : int
        {
            return this.mProductionTime;
        }// end function

        public function GetProducedItems() : int
        {
            return this.mProducedItems;
        }// end function

        public function willTrigger(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.willTrigger(param1);
        }// end function

        public function IncCollectedTime(param1:Number, param2:cGeneralInterface) : void
        {
            this.mHasStarted = true;
            if (param1 > 0)
            {
                this.mCollectedTime = this.mCollectedTime + param1 * this.mProductionOrder.GetTimeBonus(param2);
            }
            else
            {
                this.mCollectedTime = this.mCollectedTime + param1;
            }
            this.mProductionProgress = Math.min(this.mCollectedTime / Number(this.mProductionTime), 1);
            return;
        }// end function

        public function SetPlayerID(param1:int) : void
        {
            this.mPlayerId = param1;
            return;
        }// end function

        public function GetCollectedTime() : Number
        {
            return this.mCollectedTime;
        }// end function

        public function GetPlayerID() : int
        {
            return this.mPlayerId;
        }// end function

        public function GetInstantBuildCosts() : int
        {
            return (this.mAmount - this.mProducedItems) * this.mProductionOrder.GetInstantBuildCosts();
        }// end function

        private function set mProductionProgress(param1:Number) : void
        {
            var _loc_2:* = this._1098885459mProductionProgress;
            if (_loc_2 !== param1)
            {
                this._1098885459mProductionProgress = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mProductionProgress", _loc_2, param1));
            }
            return;
        }// end function

        public function GetType_string() : String
        {
            return this.mType_string;
        }// end function

        public function HasStarted() : Boolean
        {
            return this.mHasStarted;
        }// end function

        public function Init(param1:dUniqueID, param2:int, param3:iProductionOrder) : cTimedProduction
        {
            gMisc.ConsoleOut("cTimedProduction.Init(" + param1 + ", " + param2 + ", " + param3 + ")");
            this.mProductionOrder = param3;
            this.mPlayerId = param2;
            this.mType_string = param3.GetType_string();
            this.mAmount = param3.GetAmount();
            this.mUniqueId = param1;
            this.mProductionTime = param3.GetProductionTime();
            this.mDirtyIndicator = DIRTY_INDICATOR.CREATED_BIT;
            return this;
        }// end function

        public function GetAmount() : int
        {
            return this.mAmount;
        }// end function

        public function dispatchEvent(event:Event) : Boolean
        {
            return this._bindingEventDispatcher.dispatchEvent(event);
        }// end function

        public function FinishProduction(param1:cPlayerData, param2:cGeneralInterface) : void
        {
            this.mProductionOrder.CreateItem(param1, param2, this.mAmount);
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function CreateTimedProductionVO() : dTimedProductionVO
        {
            var _loc_2:dUniqueID = null;
            var _loc_1:* = new dTimedProductionVO();
            _loc_1.uniqueId = this.mUniqueId;
            _loc_1.playerId = this.mPlayerId;
            if (this.mProductionOrder is cMilitaryUnitProductionOrder)
            {
                _loc_1.productionType = TIMED_PRODUCTION_TYPE.MILITARY_UNIT;
            }
            else if (this.mProductionOrder is cBuffProductionOrder)
            {
                _loc_1.productionType = TIMED_PRODUCTION_TYPE.BUFF;
            }
            else
            {
                gMisc.Assert(false, "Could not create production type for " + this.mProductionOrder);
                return null;
            }
            _loc_1.type_string = this.mType_string;
            _loc_1.amount = this.mAmount;
            _loc_1.producedItems = this.mProducedItems;
            _loc_1.collectedTime = this.mCollectedTime;
            for each (_loc_2 in this.mProductionOrder.GetUniqueIds_vector())
            {
                
                _loc_1.uniqueIds.addItem(_loc_2);
            }
            return _loc_1;
        }// end function

        public function removeEventListener(param1:String, param2:Function, param3:Boolean = false) : void
        {
            this._bindingEventDispatcher.removeEventListener(param1, param2, param3);
            return;
        }// end function

        private function get mProductionProgress() : Number
        {
            return this._1098885459mProductionProgress;
        }// end function

        public function GetProductionProgress() : Number
        {
            return this.mProductionProgress;
        }// end function

        public function addEventListener(param1:String, param2:Function, param3:Boolean = false, param4:int = 0, param5:Boolean = false) : void
        {
            this._bindingEventDispatcher.addEventListener(param1, param2, param3, param4, param5);
            return;
        }// end function

        public function toString() : String
        {
            return "<TimedProduction " + this.mProducedItems + "/" + this.mAmount + " \'" + this.mType_string + "\', collectedTime=" + this.mCollectedTime + "/" + this.mProductionTime + " >";
        }// end function

        public function GetProductionType() : int
        {
            return this.mProductionType;
        }// end function

        public function hasEventListener(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.hasEventListener(param1);
        }// end function

        public function GetWaitingForServer() : Boolean
        {
            return this.mWaitingForServer;
        }// end function

        public function SetProducedItems(param1:int) : void
        {
            this.mProducedItems = param1;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function SetProductionType(param1:int) : void
        {
            this.mProductionType = param1;
            return;
        }// end function

        public function GetProductionOrder() : iProductionOrder
        {
            return this.mProductionOrder;
        }// end function

        public static function ProduceItems(param1:cPlayerData, param2:cGeneralInterface, param3:iProductionOrder) : cTimedProduction
        {
            var _loc_6:dResource = null;
            var _loc_7:cResources = null;
            gMisc.ConsoleOut("ProduceItems(" + param2 + ", " + param3 + ")");
            var _loc_4:dResource = null;
            var _loc_5:* = new Vector.<dResource>;
            for each (_loc_6 in param3.GetCostsToBuy_vector())
            {
                
                if (_loc_6.name_string == defines.POPULATION_RESOURCE_NAME_string)
                {
                    _loc_4 = _loc_6;
                    continue;
                }
                _loc_5.push(_loc_6);
            }
            _loc_7 = param2.mCurrentPlayerZone.GetResources(param1);
            if (!_loc_7.HasPlayerResourcesInList(_loc_5, param3.GetAmount()))
            {
                return null;
            }
            if (_loc_4 != null && _loc_7.GetNumberOfUnassignedPopulation() < _loc_4.amount * param3.GetAmount())
            {
                return null;
            }
            if (_loc_4 != null)
            {
                _loc_7.AssignMilitary(int(_loc_4.amount * param3.GetAmount()));
            }
            _loc_7.RemovePlayerResourcesFromResourcesInList(_loc_5, param3.GetAmount());
            var _loc_8:* = new cTimedProduction.Init(param1.GetNewUniqueID(), param1.GetPlayerId(), param3);
            return new cTimedProduction.Init(param1.GetNewUniqueID(), param1.GetPlayerId(), param3);
        }// end function

        public static function CreateTimedProductionFromVO(param1:dTimedProductionVO) : cTimedProduction
        {
            var _loc_3:iProductionOrder = null;
            var _loc_2:* = new cTimedProduction;
            _loc_2.mUniqueId = param1.uniqueId;
            _loc_2.mPlayerId = param1.playerId;
            _loc_2.mProductionType = param1.productionType;
            _loc_2.mType_string = param1.type_string;
            _loc_2.mAmount = param1.amount;
            _loc_2.mCollectedTime = param1.collectedTime;
            _loc_2.mProducedItems = param1.producedItems;
            if (_loc_2.mProducedItems > 0 || _loc_2.mCollectedTime > 0)
            {
                _loc_2.mHasStarted = true;
            }
            ;
            
            _loc_3 = new cBuffProductionOrder(param1.type_string, param1.amount);
            _loc_3.AddUniqueIds(param1.uniqueIds);
            ;
            
            _loc_3 = new cMilitaryUnitProductionOrder(param1.type_string, param1.amount);
            _loc_3.AddUniqueIds(param1.uniqueIds);
            ;
            
            gMisc.Assert(false, "Could not interpret production type " + param1.productionType);
            return null;
        }// end function

    }
}
