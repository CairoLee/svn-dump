package Specialists
{
    import Communication.VO.*;
    import Enums.*;
    import GO.*;
    import Interface.*;
    import MilitarySystem.*;
    import ServerState.*;
    import __AS3__.vec.*;
    import flash.events.*;
    import mx.events.*;
    import nLib.*;

    public class cSpecialist extends Object implements iMilitaryUnitHolder, IEventDispatcher
    {
        public var mDirtyIndicator:int;
        private var mBattlesWon:int = 0;
        private var mUnitsDefeated:int = 0;
        private const TIMEOUT:int = 30000;
        private var mLastServerCall:int = 0;
        private var mXp:int;
        private var mType:int;
        private var mPlayerID:int;
        private var _58515489mTaskProgress:Number = 0;
        private var mTimeBonus:int = 0;
        private var mWaitingForServerResponse:Boolean = false;
        private var mTask:cSpecialistTask;
        private var mZoneID:int;
        private var army:cArmy;
        private var mSpecialistDescription:cSpecialistDescription;
        private var uniqueID:dUniqueID;
        private var mGarrison:cBuilding = null;
        private var mFaceType:int;
        private var mGarrisonGridIdx:int = -1;
        private var mDiceBonus:int = 0;
        private var _bindingEventDispatcher:EventDispatcher;
        private var currentHitPoints:int;
        private var mBuildingsDestroyed:int = 0;
        private var mXpProduced:int = 0;
        private var mRetreatThreshold:int = 0;
        private static var map_SpecialistType_SpecialistDescription:Object = new Object();
        private static var map_SpecialistType_CostList:Object = new Object();

        public function cSpecialist(param1:Boolean)
        {
            this._bindingEventDispatcher = new EventDispatcher(IEventDispatcher(this));
            if (param1)
            {
                this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.CREATED_BIT;
            }
            return;
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
                globalFlash.gui.mSpecialistPanel.Refresh(this);
            }
            return;
        }// end function

        public function GetUniqueID() : dUniqueID
        {
            return this.uniqueID;
        }// end function

        public function GetBaseType() : int
        {
            switch(this.mType)
            {
                case SPECIALIST_TYPE.GENERAL:
                case SPECIALIST_TYPE.MASTER_GENERAL:
                case SPECIALIST_TYPE.HALLOWEEN_GENERAL:
                case SPECIALIST_TYPE.RETAIL_BOX_GENERAL:
                case SPECIALIST_TYPE.EASTER_GENERAL:
                {
                    return SPECIALIST_TYPE.GENERAL;
                }
                case SPECIALIST_TYPE.EXPLORER:
                case SPECIALIST_TYPE.MASTER_EXPLORER:
                case SPECIALIST_TYPE.EASTER_EXPLORER:
                {
                    return SPECIALIST_TYPE.EXPLORER;
                }
                case SPECIALIST_TYPE.GEOLOGIST:
                case SPECIALIST_TYPE.MASTER_GEOLOGIST:
                {
                    return SPECIALIST_TYPE.GEOLOGIST;
                }
                case SPECIALIST_TYPE.TMP_ARMY_TRANSPORTER:
                {
                    return SPECIALIST_TYPE.TMP_ARMY_TRANSPORTER;
                }
                default:
                {
                    gMisc.Assert(false, "GetBaseType(): Unsupported specialist type: " + this.mType);
                    return -1;
                    continue;
                }
            }
        }// end function

        public function GetUnitsDefeated() : int
        {
            return this.mUnitsDefeated;
        }// end function

        public function CreateSpecialistVOFromSpecialist() : dSpecialistVO
        {
            var _loc_2:cSquad = null;
            var _loc_3:dSpecialistTaskVO = null;
            var _loc_4:dSquadVO = null;
            var _loc_1:* = new dSpecialistVO();
            _loc_1.uniqueID = this.GetUniqueID();
            _loc_1.specialistType = this.GetType();
            _loc_1.currentHitPoints = this.GetCurrentHitPoints();
            _loc_1.playerID = this.GetPlayerID();
            _loc_1.faceType = this.GetFaceType();
            _loc_1.xp = this.GetXP();
            _loc_1.diceBonus = this.GetDiceBonus();
            _loc_1.retreatThreshold = this.GetRetreatThreshold();
            if (this.GetGarrison() != null)
            {
                _loc_1.garrisonBuildingGridPos = this.GetGarrison().GetBuildingGrid();
            }
            else
            {
                _loc_1.garrisonBuildingGridPos = -1;
            }
            for each (_loc_2 in this.army.GetSquads_vector())
            {
                
                _loc_4 = new dSquadVO().init(_loc_2.GetType_string(), _loc_2.GetAmount(), _loc_2.GetCurrentHitPoints());
                _loc_1.armyVO.squads.addItem(_loc_4);
            }
            _loc_3 = null;
            if (this.GetTask() != null)
            {
                _loc_3 = this.GetTask().CreateTaskVOFromSpecialistTask();
            }
            _loc_1.task = _loc_3;
            _loc_1.xpProduced = this.mXpProduced;
            _loc_1.battlesWon = this.mBattlesWon;
            _loc_1.unitsDefeated = this.mUnitsDefeated;
            _loc_1.buildingsDestroyed = this.mBuildingsDestroyed;
            return _loc_1;
        }// end function

        public function GetPlayerID() : int
        {
            return this.mPlayerID;
        }// end function

        public function HasUnits() : Boolean
        {
            return this.army.HasUnits();
        }// end function

        public function SetPlayerID(param1:int) : void
        {
            this.mPlayerID = param1;
            return;
        }// end function

        public function GetDiceBonus() : int
        {
            return this.mDiceBonus;
        }// end function

        public function GetTaskProgress() : Number
        {
            return this.mTaskProgress;
        }// end function

        public function GetSortIndex() : int
        {
            return this.mSpecialistDescription.GetSortIndex();
        }// end function

        public function SetCurrentHitPoints(param1:int) : void
        {
            this.currentHitPoints = param1;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function dispatchEvent(event:Event) : Boolean
        {
            return this._bindingEventDispatcher.dispatchEvent(event);
        }// end function

        public function GetCurrentHitPoints() : int
        {
            return this.currentHitPoints;
        }// end function

        public function removeEventListener(param1:String, param2:Function, param3:Boolean = false) : void
        {
            this._bindingEventDispatcher.removeEventListener(param1, param2, param3);
            return;
        }// end function

        public function addEventListener(param1:String, param2:Function, param3:Boolean = false, param4:int = 0, param5:Boolean = false) : void
        {
            this._bindingEventDispatcher.addEventListener(param1, param2, param3, param4, param5);
            return;
        }// end function

        public function PerformTask() : void
        {
            if (this.mTask != null)
            {
                this.mTaskProgress = this.mTask.GetTaskProgress();
                this.mTask.Perform();
            }
            return;
        }// end function

        public function toString() : String
        {
            return "<Specialist type=\'" + SPECIALIST_TYPE.toString(this.mType) + "\' uniqueID=\'" + this.GetUniqueID() + " playerId=\'" + this.GetPlayerID() + "\' />";
        }// end function

        public function GetBuildingsDestroyed() : int
        {
            return this.mBuildingsDestroyed;
        }// end function

        public function GetXpProduced() : int
        {
            return this.mXpProduced;
        }// end function

        public function GetSpecialistDescription() : cSpecialistDescription
        {
            return this.mSpecialistDescription;
        }// end function

        public function GetGarrison() : cBuilding
        {
            return this.mGarrison;
        }// end function

        public function IncUnitsDefeated(param1:int) : void
        {
            this.mUnitsDefeated = this.mUnitsDefeated + param1;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function SetGarrison(param1:cBuilding) : void
        {
            if (param1 != null)
            {
                this.mGarrisonGridIdx = param1.GetBuildingGrid();
            }
            else
            {
                this.mGarrisonGridIdx = -1;
                this.DisableWaitForCommandAnimation();
            }
            this.mGarrison = param1;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function willTrigger(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.willTrigger(param1);
        }// end function

        public function GetType() : int
        {
            return this.mType;
        }// end function

        public function DisplayTaskProgress() : Boolean
        {
            if (this.mTask == null)
            {
                return false;
            }
            switch(this.mTask.GetType())
            {
                case SPECIALIST_TASK_TYPES.WAIT_FOR_CONFIRMATION:
                case SPECIALIST_TASK_TYPES.MOVE:
                case SPECIALIST_TASK_TYPES.ATTACK_BUILDING:
                case SPECIALIST_TASK_TYPES.DISBAND_ARMY:
                {
                    return false;
                }
                default:
                {
                    return true;
                    continue;
                }
            }
        }// end function

        public function GetFaceType() : int
        {
            return this.mFaceType;
        }// end function

        public function GetZoneID() : int
        {
            return this.mZoneID;
        }// end function

        public function InitSpecialistFromType(param1:int, param2:dUniqueID, param3:int, param4:int) : cSpecialist
        {
            this.mSpecialistDescription = map_SpecialistType_SpecialistDescription[param1];
            this.mType = param1;
            this.uniqueID = param2;
            this.mDiceBonus = this.mSpecialistDescription.GetDiceBonus();
            this.mTimeBonus = this.mSpecialistDescription.GetTimeBonus();
            this.mPlayerID = param3;
            this.mZoneID = param4;
            this.army = new cArmy(param4, param3, ARMY_OWNER_TYPE.SPECIALIST, this);
            return this;
        }// end function

        public function GetXP() : int
        {
            return this.mXp;
        }// end function

        public function GetBattlesWon() : int
        {
            return this.mBattlesWon;
        }// end function

        public function GetMaxMilitaryUnits() : int
        {
            if (this.mSpecialistDescription.GetMaxUnits() > 0)
            {
                return this.mSpecialistDescription.GetMaxUnits();
            }
            return 0;
        }// end function

        private function set mTaskProgress(param1:Number) : void
        {
            var _loc_2:* = this._58515489mTaskProgress;
            if (_loc_2 !== param1)
            {
                this._58515489mTaskProgress = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mTaskProgress", _loc_2, param1));
            }
            return;
        }// end function

        public function GetRetreatThreshold() : int
        {
            return this.mRetreatThreshold;
        }// end function

        public function DisableWaitForCommandAnimation() : void
        {
            if (this.mGarrison != null)
            {
                this.mGarrison.mGarrissonWaitForCommand = false;
            }
            return;
        }// end function

        public function SetRetreatThreshold(param1:int) : void
        {
            this.mRetreatThreshold = param1;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function GetTask() : cSpecialistTask
        {
            return this.mTask;
        }// end function

        public function GetGarrisonGridIdx() : int
        {
            return this.mGarrisonGridIdx;
        }// end function

        private function get mTaskProgress() : Number
        {
            return this._58515489mTaskProgress;
        }// end function

        public function SetTask(param1:cSpecialistTask) : void
        {
            this.mTask = param1;
            if (this.mTask != null)
            {
                this.mTask.StartTask();
            }
            return;
        }// end function

        public function hasEventListener(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.hasEventListener(param1);
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

        public function IncBuildingsDestroyed() : void
        {
            var _loc_1:String = this;
            var _loc_2:* = this.mBuildingsDestroyed + 1;
            _loc_1.mBuildingsDestroyed = _loc_2;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function GetArmy() : cArmy
        {
            return this.army;
        }// end function

        public function IsInUse() : Boolean
        {
            return this.mTask != null;
        }// end function

        public static function CreateSpecialistFromVO(param1:cGeneralInterface, param2:dSpecialistVO, param3:Boolean) : cSpecialist
        {
            var _loc_5:dSquadVO = null;
            var _loc_4:* = new cSpecialist(param3).InitSpecialistFromType(param2.specialistType, param2.uniqueID, param2.playerID, param1.mCurrentViewedZoneID);
            new cSpecialist(param3).InitSpecialistFromType(param2.specialistType, param2.uniqueID, param2.playerID, param1.mCurrentViewedZoneID).currentHitPoints = param2.currentHitPoints;
            _loc_4.mFaceType = param2.faceType;
            _loc_4.mXp = param2.xp;
            _loc_4.mRetreatThreshold = param2.retreatThreshold;
            _loc_4.mGarrisonGridIdx = param2.garrisonBuildingGridPos;
            if (param2.garrisonBuildingGridPos != -1)
            {
                _loc_4.SetGarrison(param1.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[param2.garrisonBuildingGridPos].mBuilding);
            }
            for each (_loc_5 in param2.armyVO.squads)
            {
                
                _loc_4.GetArmy().AddSquadVO(_loc_5, param3);
            }
            _loc_4.mTask = cSpecialistTask.CreateTaskFromVO(param1, param2.task, _loc_4);
            if (_loc_4.mTask != null && param3)
            {
                _loc_4.GetTask().mDirtyIndicator = _loc_4.GetTask().mDirtyIndicator | DIRTY_INDICATOR.CREATED_BIT;
            }
            _loc_4.mXpProduced = param2.xpProduced;
            _loc_4.mBattlesWon = param2.battlesWon;
            _loc_4.mUnitsDefeated = param2.unitsDefeated;
            _loc_4.mBuildingsDestroyed = param2.buildingsDestroyed;
            return _loc_4;
        }// end function

        public static function InitData(param1:cXML, param2:cXML) : void
        {
            var _loc_4:cXML = null;
            var _loc_5:Vector.<cXML> = null;
            var _loc_6:cXML = null;
            var _loc_7:int = 0;
            var _loc_8:int = 0;
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            var _loc_11:String = null;
            var _loc_12:Boolean = false;
            var _loc_13:int = 0;
            var _loc_14:cSpecialistDescription = null;
            var _loc_15:int = 0;
            var _loc_16:int = 0;
            var _loc_17:Vector.<Vector.<dResource>> = null;
            var _loc_18:Vector.<cXML> = null;
            var _loc_19:cXML = null;
            var _loc_20:Vector.<dResource> = null;
            var _loc_3:* = param1.CreateChildrenArray();
            for each (_loc_4 in _loc_3)
            {
                
                _loc_7 = _loc_4.GetAttributeInt("type");
                _loc_8 = _loc_4.GetAttributeInt("diceBonus");
                _loc_9 = _loc_4.GetAttributeInt("timeBonus");
                _loc_10 = _loc_4.GetAttributeInt("maxUnits");
                _loc_11 = _loc_4.GetAttributeString_string("militaryUnitType");
                _loc_12 = _loc_4.GetAttributeBool("producable");
                _loc_13 = _loc_4.GetAttributeInt("sortIndex");
                _loc_14 = new cSpecialistDescription(_loc_7, _loc_8, _loc_9, _loc_10, _loc_11, _loc_12, _loc_13);
                map_SpecialistType_SpecialistDescription[_loc_7] = _loc_14;
            }
            _loc_5 = param2.CreateChildrenArray();
            for each (_loc_6 in _loc_5)
            {
                
                _loc_15 = SPECIALIST_TYPE.parse(_loc_6.GetAttributeString_string("specialistType"));
                _loc_16 = 0;
                _loc_17 = new Vector.<Vector.<dResource>>;
                _loc_18 = _loc_6.CreateChildrenArray();
                for each (_loc_19 in _loc_18)
                {
                    
                    _loc_20 = gParse.ParseCosts(_loc_19);
                    _loc_17[_loc_16] = _loc_20;
                    _loc_16++;
                }
                map_SpecialistType_CostList[_loc_15] = _loc_17;
            }
            return;
        }// end function

        public static function GetAllSpecialistDescriptions() : Array
        {
            var _loc_2:String = null;
            var _loc_3:cSpecialistDescription = null;
            var _loc_1:Array = [];
            for (_loc_2 in map_SpecialistType_SpecialistDescription)
            {
                
                _loc_3 = map_SpecialistType_SpecialistDescription[_loc_2] as cSpecialistDescription;
                if (_loc_3.IsRecruitable())
                {
                    _loc_1.push(_loc_3);
                }
            }
            return _loc_1;
        }// end function

        public static function BuySpecialist(param1:int, param2:cGeneralInterface) : void
        {
            var _loc_3:* = map_SpecialistType_SpecialistDescription[param1] as cSpecialistDescription;
            var _loc_4:* = param2.mCurrentPlayerZone.GetResources(param2.mCurrentPlayer);
            if (!param2.mCurrentPlayerZone.GetResources(param2.mCurrentPlayer).HasPlayerResourcesInListOne(GetCostsToBuy_vector(param1, param2.mCurrentPlayer.GetSpecialistAmount(param1))))
            {
                gMisc.ConsoleOut("Player cannot afford specialist!");
                return;
            }
            param2.SendServerAction(COMMAND.BUY_SPECIALIST, param1, 0, 0, 0);
            return;
        }// end function

        public static function GetCostsToBuy_vector(param1:int, param2:int)
        {
            if (map_SpecialistType_CostList[param1].length > param2)
            {
                return map_SpecialistType_CostList[param1][param2];
            }
            return null;
        }// end function

        public static function GetSpecialistDescriptionForType(param1:int) : cSpecialistDescription
        {
            return map_SpecialistType_SpecialistDescription[param1] as cSpecialistDescription;
        }// end function

    }
}
