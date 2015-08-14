package GO
{
    import BuffSystem.*;
    import Communication.VO.*;
    import Enums.*;
    import GOSets.*;
    import GUI.Assets.*;
    import GUI.Loca.*;
    import Interface.*;
    import MilitarySystem.*;
    import ServerState.*;
    import SettlerKI.*;
    import __AS3__.vec.*;
    import flash.display.*;
    import flash.events.*;
    import flash.geom.*;
    import mx.events.*;
    import nLib.*;

    public class cBuilding extends cGO implements iMilitaryUnitHolder, IEventDispatcher
    {
        public var mOrigin:int = 0;
        public var mBuildingDestructionTime:Number = 0;
        public var mDirtyIndicator:int;
        public var mIsSelectable:Boolean = true;
        private var mSmokeEffectSet:cGOSetList = null;
        private var mIsBought:Boolean = false;
        private var mRecoveringHitPoints:int = 0;
        private var mBuildingModeBeforeMoving:int = 0;
        private var mMaxHitPoints:int = 0;
        private var mSpriteWorkAnim:cSpriteLib = null;
        public var mStartWorkCounter:int;
        public var mPlayerData:cPlayerData;
        private var mTempPos:Point;
        private var mConstructionAnimEffectSet:cGOSetList = null;
        private var _2088099370mHealthBar:Number = 1;
        private var _bindingEventDispatcher:EventDispatcher;
        public const mBuffs_vector:Vector.<BuffAppliance>;
        private var mInitialSetOnMap:Boolean = false;
        private var mOffsetX:int = 0;
        private var mOffsetY:int = 0;
        private var mLastRepairTime:Number = 0;
        private var mBuildingInfoIconDelayEndTime:Number = -1;
        private var mDamageAnimEffectSet:cGOSetList = null;
        private var mBuildingGrid:int;
        public var mBuildingCreationTime:Number = 0;
        private var mConstructionSpriteLib:cSpriteLib = null;
        private var mBuildingName_string:String = null;
        private var mIsEngagedInCombat:Boolean = false;
        private var mGoGroup:cGOGroup;
        public var mWaitForCommand:Boolean;
        private var mCurrentDamageLevel:int;
        private var mCurrentHitPoints:int;
        public var mBuildingUpgradeIsInProgress:Boolean = false;
        private var mBuildingMode:int = 0;
        private var recurringBuffVO:dBuffVO = null;
        private var _1324158862mBuildingProgress:int = 0;
        private var mFlagEffectSet:cGOSetList = null;
        private var mResourceCreation:cResourceCreation = null;
        private var mArmy:cArmy;
        private var mProductionActive:Boolean = true;
        private var mBuffTwinkleEffectSet:cGOSetList = null;
        public var mCursorHighlight:Boolean;
        private var mUpgradeLevel:int = 1;
        public var mGarrissonWaitForCommand:Boolean;
        private var mStreetGridEntry:int;
        private var mLoadingInProgress:Boolean = false;
        public var mBuildingUpgradeProgress:int;
        private var mLastProgress:Number = 0;
        private var mBuildingUpgradeStartTime:Number;
        private var mDestructionAnimEffectSet:cGOSetList = null;
        public static const BUILDING_MODE_WORKANIM_IS_WORKING_AT_EXTERNAL_DEPOSIT:int = 27;
        public static const BUILDING_MODE_QUEUED:int = 1;
        public static const BUILDING_MODE_NONE:int = 0;
        public static const BUILDING_MODE_DESTRUCTED:int = 6;
        public static const BUILDING_MODE_PLACED:int = 7;
        public static const BUILDING_MODE_WORKANIM_IS_WORKING_AT_WORKYARD_LOCAL_WORKYARD_SYSTEM:int = 23;
        public static const BUILDING_MODE_BUILDER_WALKS_FROM_RESOURCECREATIONHOUSE_TO_STOREHOUSE:int = 20;
        public static const BUILDING_MODE_PRODUCES_NO_RESOURCES:int = 28;
        public static const BUILDING_ORIGIN_FROM_GAME:int = 0;
        public static const BUILDING_MODE_SETTLER_WALKS_FROM_STOREHOUSE_TO_RESOURCECREATIONHOUSE:int = 21;
        public static const BUILDING_MODE_SETTLER_WALKS_FROM_RESOURCECREATIONHOUSE_TO_STOREHOUSE:int = 22;
        public static const BUILDING_MODE_DESTRUCTION:int = 5;
        public static const DAMAGE_LEVEL_AMOUNT:int = 10;
        public static const BUILDING_MODE_MOVING:int = 8;
        public static const BUILDING_MODE_CONSTRUCTION:int = 4;
        public static const BUILDING_MODE_SETTLER_WALKS_FROM_EXTERNAL_RESOURCE_TO_RESOURCECREATIONHOUSE:int = 26;
        public static const BUILDING_MODE_BUILDING_IS_IN_PRODUCTION_MIN:int = 21;
        public static const BUILDING_MODE_SET_BUILDING_GROUND_PLACE:int = 2;
        public static const BUILDING_MODE_SETTLER_WALKS_TO_BUILDING_GROUND_PLACE:int = 3;
        public static const BUILDING_MODE_WORKANIM_IS_WORKING_AT_WORKYARD_EXTERNAL_WORKYARD_SYSTEM_ACTIVE:int = 24;
        public static const BUILDING_MODE_SETTLER_WALKS_FROM_RESOURCECREATIONHOUSE_TO_EXTERNAL_RESOURCE:int = 25;
        public static const BUILDING_MODE_BUILDING_IS_ACTIVE_MIN:int = 20;
        public static const BUILDING_ORIGIN_FROM_BUFF:int = 1;

        public function cBuilding(param1:cGeneralInterface, param2:int)
        {
            this.mBuffs_vector = new Vector.<BuffAppliance>;
            this.mTempPos = new Point(0, 0);
            this._bindingEventDispatcher = new EventDispatcher(IEventDispatcher(this));
            super(param1);
            if (param1 != null)
            {
                mPlayerID = param2;
                this.mArmy = new cArmy(param1.mCurrentViewedZoneID, mPlayerID, ARMY_OWNER_TYPE.BUILDING, this);
            }
            return;
        }// end function

        public function GetMovementCosts_vector()
        {
            return this.GetMovementCostsForLevel_vector(this.mUpgradeLevel);
        }// end function

        public function GetLastRepairTime() : Number
        {
            return this.mLastRepairTime;
        }// end function

        public function GetUpgradeInstantCosts() : int
        {
            var _loc_2:dResource = null;
            var _loc_3:Number = NaN;
            var _loc_1:int = 0;
            for each (_loc_2 in this.GetUpgradeCosts_vector())
            {
                
                if (global.resourceHardcurrencyValues.hasOwnProperty(_loc_2.name_string))
                {
                    _loc_1 = this.int(_loc_2.amount * global.resourceHardcurrencyValues[_loc_2.name_string]);
                    break;
                }
            }
            _loc_3 = GetGOContainer().mUpgradeInstantBonusPercentage;
            if (_loc_3 <= 0)
            {
                _loc_3 = global.defaultUpgradeInstantBonusPercentage;
            }
            var _loc_4:* = int(_loc_3 / 100 * _loc_1);
            _loc_1 = _loc_1 - _loc_4;
            gMisc.ConsoleOut("costs " + _loc_1);
            return _loc_1;
        }// end function

        public function IsBuildingInfoIconDelayPassed() : Boolean
        {
            return this.mProductionActive && this.mBuildingInfoIconDelayEndTime < gMisc.GetTimeSinceStartup();
        }// end function

        public function GetOffsetX() : int
        {
            return this.mOffsetX;
        }// end function

        public function GetOffsetY() : int
        {
            return this.mOffsetY;
        }// end function

        public function IsEngagedInCombat() : Boolean
        {
            return this.mIsEngagedInCombat;
        }// end function

        public function GetUpgradeLevelBonuses() : cBuffDefinition
        {
            return this.GetUpgradeLevelBonusesForLevel(this.mUpgradeLevel);
        }// end function

        override public function Compute() : void
        {
            var _loc_2:Number = NaN;
            var _loc_5:BuffAppliance = null;
            var _loc_6:cResources = null;
            var _loc_7:String = null;
            var _loc_8:String = null;
            super.Compute();
            var _loc_1:int = 0;
            while (_loc_1 < this.mBuffs_vector.length)
            {
                
                _loc_5 = this.mBuffs_vector[_loc_1];
                if (_loc_5.Calculate(mGeneralInterface.GetClientTime()))
                {
                    _loc_5.BuffRemoved(mGeneralInterface);
                    this.mBuffs_vector.splice(_loc_1, 1);
                    _loc_1 = _loc_1 - 1;
                }
                _loc_1++;
            }
            var _loc_3:Number = 0;
            var _loc_4:int = 0;
            if (this.mBuildingMode == BUILDING_MODE_CONSTRUCTION)
            {
                this.mLastProgress = _loc_3;
            }
            else if (this.mBuildingMode == BUILDING_MODE_DESTRUCTION)
            {
                _loc_3 = mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.GetDestructionProgressInPercent(this);
                if (_loc_3 != this.mLastProgress)
                {
                    if (_loc_3 == 100)
                    {
                        if (GetGOContainer().mAddDepositAmount != -1)
                        {
                            mGeneralInterface.mCurrentPlayerZone.RemoveAtGridPosition(this.mPlayerData, OBJECTTYPE.DEPOSIT, this.GetBuildingGrid());
                        }
                        mGeneralInterface.mCurrentPlayerZone.RemoveAtGridPosition(this.mPlayerData, OBJECTTYPE.BUILDING, this.GetBuildingGrid());
                        _loc_6 = mGeneralInterface.mCurrentPlayerZone.GetResources(this.mPlayerData);
                        if (_loc_6 != null)
                        {
                            _loc_6.CalculateMaxLimitsForResources(this.mPlayerData.GetPlayerId());
                        }
                    }
                }
                this.mLastProgress = _loc_3;
            }
            else
            {
                if (this.mSpriteWorkAnim != null)
                {
                    if (this.mProductionActive)
                    {
                        _loc_2 = 0.75 + Math.random() * 0.5;
                        this.mSpriteWorkAnim.Animate(mGeneralInterface.mCalculateTicks.mDeltaTicksOne * _loc_2);
                    }
                    else
                    {
                        this.mSpriteWorkAnim.SetFrame(0);
                    }
                }
                if (this.mDamageAnimEffectSet != null)
                {
                    _loc_2 = 0.75 + Math.random() * 0.5;
                    this.mDamageAnimEffectSet.Animate(mGeneralInterface.mCalculateTicks.mDeltaTicksOne * _loc_2);
                }
            }
            if (this.mBuildingMode == BUILDING_MODE_WORKANIM_IS_WORKING_AT_WORKYARD_LOCAL_WORKYARD_SYSTEM || this.mBuildingMode == BUILDING_MODE_WORKANIM_IS_WORKING_AT_WORKYARD_EXTERNAL_WORKYARD_SYSTEM_ACTIVE)
            {
                if (this.mSmokeEffectSet != null)
                {
                    _loc_2 = 0.75 + Math.random() * 0.5;
                    this.mSmokeEffectSet.Animate(mGeneralInterface.mCalculateTicks.mDeltaTicksOne * _loc_2);
                }
                else
                {
                    _loc_7 = GetGOContainer().mSmokeEffectSetName_string;
                    if (_loc_7 != null && _loc_7 != "")
                    {
                        this.mSmokeEffectSet = cGOSetManager.CreateGOSetList(_loc_7, null);
                    }
                }
            }
            if (this.mBuffs_vector.length > 0)
            {
                if (this.mBuffTwinkleEffectSet != null)
                {
                    this.mBuffTwinkleEffectSet.Animate(mGeneralInterface.mCalculateTicks.mDeltaTicksOne);
                }
                else if (this.mBuffs_vector[0].GetApplicanceMode() == BUFF_APPLIANCE_MODE.PLAYER)
                {
                    _loc_8 = gAssetManager.buffCursorTypes[this.mBuffs_vector[0].GetBuffDefinition().GetName_string()];
                    if (_loc_8 == null)
                    {
                        _loc_8 = global.defaultGosetBuffTwinkleName;
                    }
                    this.mBuffTwinkleEffectSet = cGOSetManager.CreateGOSetList(_loc_8, null);
                }
                else if (this.mBuffs_vector[0].GetApplicanceMode() == BUFF_APPLIANCE_MODE.FRIEND)
                {
                    _loc_8 = gAssetManager.buffCursorTypesForeign[this.mBuffs_vector[0].GetBuffDefinition().GetName_string()];
                    if (_loc_8 == null)
                    {
                        _loc_8 = global.defaultGosetFriendBuffTwinkleName;
                    }
                    this.mBuffTwinkleEffectSet = cGOSetManager.CreateGOSetList(_loc_8, null);
                }
            }
            return;
        }// end function

        public function SetIsEngagedInCombat(param1:Boolean) : void
        {
            var _loc_2:cSquad = null;
            this.mIsEngagedInCombat = param1;
            if (!this.mIsEngagedInCombat)
            {
                for each (_loc_2 in this.mArmy.GetSquads_vector())
                {
                    
                    _loc_2.Heal(_loc_2.GetUnitDescription().GetHitPoints());
                }
            }
            else
            {
                this.SetRecoveringHitPoints(0);
            }
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function GetBuildingModeBeforeMoving() : int
        {
            return this.mBuildingModeBeforeMoving;
        }// end function

        override public function SetPlayerID(param1:int) : Boolean
        {
            if (this.mFlagEffectSet != null)
            {
                this.mFlagEffectSet.SetSubTypeCurrentGOSetItem(mGeneralInterface.mCurrentPlayerZone.GetPlayerColorIdx(param1));
            }
            return super.SetPlayerID(param1);
        }// end function

        public function StartBuildingUpgrade() : void
        {
            var _loc_1:cGOSpriteLibContainer = null;
            if (this.mConstructionSpriteLib != null && this.mConstructionSpriteLib.GetNofFrames(0) > 1)
            {
                _loc_1 = this.mConstructionSpriteLib.GetContainer() as cGOSpriteLibContainer;
                this.mConstructionSpriteLib.SetAnim(_loc_1.mConstructionAnimSpeed, true);
            }
            this.mBuildingUpgradeIsInProgress = true;
            this.mBuildingUpgradeStartTime = mGeneralInterface.GetClientTime();
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            this.mBuildingUpgradeProgress = 0;
            if (this.mResourceCreation != null)
            {
                this.mResourceCreation.SetSettlerKIState(cSettlerKI.SETTLER_STATE_IS_WORKING_IN_RESOURCE_CREATION_HOUSE);
            }
            return;
        }// end function

        public function SetUpgradeLevel(param1:int) : void
        {
            this.mUpgradeLevel = param1;
            this.mMaxHitPoints = 0;
            return;
        }// end function

        public function GetCurrentHitPoints() : int
        {
            return this.mCurrentHitPoints;
        }// end function

        public function RenderBuildingName() : void
        {
            var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.BUILDINGS, this.GetBuildingName_string());
            mGeneralInterface.mCurrentPlayerZone.RenderTextCenter(cBackbuffer.mBackBuffer, _loc_1, GetXInt(), GetYInt() - global.streetGridY * 2 + 34);
            return;
        }// end function

        private function get mHealthBar() : Number
        {
            return this._2088099370mHealthBar;
        }// end function

        private function IsResourcePathValid() : Boolean
        {
            if (this.mResourceCreation != null && this.mResourceCreation.GetPath() != null)
            {
                return true;
            }
            return false;
        }// end function

        public function dispatchEvent(event:Event) : Boolean
        {
            return this._bindingEventDispatcher.dispatchEvent(event);
        }// end function

        public function IsInConstructionMode() : Boolean
        {
            return this.mBuildingMode == cBuilding.BUILDING_MODE_QUEUED || this.mBuildingMode == cBuilding.BUILDING_MODE_CONSTRUCTION || this.mBuildingMode == cBuilding.BUILDING_MODE_SET_BUILDING_GROUND_PLACE || this.mBuildingMode == cBuilding.BUILDING_MODE_SETTLER_WALKS_TO_BUILDING_GROUND_PLACE;
        }// end function

        public function GetMovementCostsForLevel_vector(param1:int)
        {
            if (GetGOContainer().buildingMovementCosts_vector == null)
            {
                return null;
            }
            if (param1 > 0 && param1 <= GetGOContainer().buildingMovementCosts_vector.length)
            {
                return GetGOContainer().buildingMovementCosts_vector[(param1 - 1)];
            }
            return null;
        }// end function

        public function RenderFlag() : void
        {
            if (this.mFlagEffectSet == null)
            {
                return;
            }
            if (this.mBuildingMode == BUILDING_MODE_CONSTRUCTION || this.mBuildingMode == BUILDING_MODE_QUEUED || this.mBuildingMode == BUILDING_MODE_SET_BUILDING_GROUND_PLACE || this.mBuildingMode == BUILDING_MODE_SETTLER_WALKS_TO_BUILDING_GROUND_PLACE)
            {
                return;
            }
            this.mFlagEffectSet.Render(int(mXNotScaled), int(mYNotScaled));
            return;
        }// end function

        public function addEventListener(param1:String, param2:Function, param3:Boolean = false, param4:int = 0, param5:Boolean = false) : void
        {
            this._bindingEventDispatcher.addEventListener(param1, param2, param3, param4, param5);
            return;
        }// end function

        public function IsReadyToIntercept() : Boolean
        {
            if (!this.mArmy.HasUnits() || this.mIsEngagedInCombat)
            {
                return false;
            }
            return true;
        }// end function

        public function SetRecoveringHitPoints(param1:int) : void
        {
            return;
        }// end function

        public function SetWorkAnimation() : void
        {
            var _loc_1:cSpriteLibContainer = null;
            var _loc_2:Number = NaN;
            if (this.mSpriteWorkAnim != null)
            {
                _loc_1 = this.mSpriteWorkAnim.GetContainer() as cSpriteLibContainer;
                _loc_2 = _loc_1.mAnimationSpeed;
                this.mSpriteWorkAnim.SetAnim(_loc_1.mAnimationSpeed, true);
            }
            return;
        }// end function

        private function set mHealthBar(param1:Number) : void
        {
            var _loc_2:* = this._2088099370mHealthBar;
            if (_loc_2 !== param1)
            {
                this._2088099370mHealthBar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mHealthBar", _loc_2, param1));
            }
            return;
        }// end function

        override public function RenderTransform(param1:int, param2:int, param3:String, param4:Number, param5:Number, param6:Number) : void
        {
            super.RenderTransform(param1, param2, param3, param4, param5, param6);
            return;
        }// end function

        public function GetResourceCreation() : cResourceCreation
        {
            return this.mResourceCreation;
        }// end function

        public function Buy() : void
        {
            if (!this.mIsBought)
            {
                this.mIsBought = true;
                mGeneralInterface.mCurrentPlayerZone.GetResources(this.mPlayerData).RemoveBuildingResourcesFromPlayerResources(GetGOContainer().mGfxResourceListName_string);
                this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            }
            else
            {
                gErrorMessages.ShowErrorMessage("Error: Building has already been bought!");
            }
            return;
        }// end function

        public function GetGoGroup() : cGOGroup
        {
            return this.mGoGroup;
        }// end function

        public function toString() : String
        {
            return "<Building name=\'" + this.mBuildingName_string + "\' grid=\'" + this.GetBuildingGrid() + "\' player=\'" + mPlayerID + "\' mode=\'" + GetBuildingModeString(this.mBuildingMode) + "\' health=\'" + this.GetCurrentHitPoints() + "\' />";
        }// end function

        public function GetBuildingGrid() : int
        {
            return this.mBuildingGrid;
        }// end function

        public function AddBuff(param1:cBuff, param2:int, param3:int) : void
        {
            var _loc_4:* = new BuffAppliance(param1.GetBuffDefinition(), param2, param3, param1.GetResourceName_string());
            new BuffAppliance(param1.GetBuffDefinition(), param2, param3, param1.GetResourceName_string()).SetStartTime(mGeneralInterface.GetClientTime());
            this.mBuffs_vector.push(_loc_4);
            _loc_4.mDirtyIndicator = _loc_4.mDirtyIndicator | DIRTY_INDICATOR.CREATED_BIT;
            if (!mGeneralInterface.mCurrentPlayer.mIsPlayerZone)
            {
                if (param1.GetBuffDefinition().getProductivityOutputPercent() < 100)
                {
                    globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.PLACED_BUFF_ON_FRIEND_NEGATIVE, this);
                }
                else
                {
                    globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.PLACED_BUFF_ON_FRIEND, this);
                }
            }
            else if (param2 == BUFF_APPLIANCE_MODE.FRIEND || param2 == BUFF_APPLIANCE_MODE.GUILD_MEMBER)
            {
                if (param1.GetBuffDefinition().getProductivityOutputPercent() < 100)
                {
                    globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.PLACED_BUFF_BY_FRIEND_NEGATIVE, this);
                }
                else
                {
                    globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.PLACED_BUFF_BY_FRIEND, this);
                }
            }
            else
            {
                globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.PLACED_BUFF, this);
            }
            this.mBuffTwinkleEffectSet = null;
            return;
        }// end function

        public function IsEqualToVOIgnoreGrid(param1:dBuildingVO) : Boolean
        {
            var _loc_2:dSquadVO = null;
            var _loc_3:cSquad = null;
            if (param1.buildingCreationTime != this.mBuildingCreationTime)
            {
                return false;
            }
            if (param1.buildingName_string != this.mBuildingName_string)
            {
                return false;
            }
            if (param1.upgradeStartTime != this.mBuildingUpgradeStartTime)
            {
                return false;
            }
            for each (_loc_2 in param1.armyVO.squads)
            {
                
                _loc_3 = this.mArmy.GetSquad(_loc_2.GetType_string());
                if (_loc_3 == null || _loc_3.GetAmount() != _loc_2.GetAmount())
                {
                    return false;
                }
            }
            return true;
        }// end function

        public function CheckForRepairRound() : Boolean
        {
            if (mGeneralInterface.GetClientTime() - this.mLastRepairTime >= global.repairRoundDuration)
            {
                this.mLastRepairTime = mGeneralInterface.GetClientTime();
                this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
                return true;
            }
            return false;
        }// end function

        public function GetUpgradeCosts_vector()
        {
            var _loc_1:* = this.GetUpgradeLevelBonusesForLevel((this.mUpgradeLevel + 1));
            if (_loc_1 == null)
            {
                return null;
            }
            return _loc_1.GetCosts_vector();
        }// end function

        public function IsProductionActive() : Boolean
        {
            return this.mProductionActive;
        }// end function

        public function SetConstructionAnimEffectSet(param1:cGOSetList) : void
        {
            this.mConstructionAnimEffectSet = param1;
            return;
        }// end function

        public function SetProductionActiveCommand(param1:Boolean) : void
        {
            var _loc_2:* = new dServerAction();
            _loc_2.grid = this.mBuildingGrid;
            _loc_2.type = param1 ? (1) : (0);
            mGeneralInterface.mClientMessages.SendMessagetoServer(COMMAND.STOP_PRODUCTION, mGeneralInterface.mCurrentViewedZoneID, _loc_2);
            this.mWaitForCommand = true;
            return;
        }// end function

        public function GetMaxMilitaryUnits() : int
        {
            var _loc_1:* = this.GetUpgradeLevelBonuses();
            if (_loc_1 != null)
            {
                return GetGOContainer().mMaxUnits + _loc_1.getMilitaryUnitCapacity();
            }
            return GetGOContainer().mMaxUnits;
        }// end function

        public function IsKnockdownAllowed() : Boolean
        {
            if (this.mBuildingMode == BUILDING_MODE_DESTRUCTION || this.mBuildingMode == BUILDING_MODE_DESTRUCTED || this.IsInitialOnXMLMap())
            {
                return false;
            }
            return true;
        }// end function

        public function IsBuildingActive() : Boolean
        {
            if (this.mBuildingMode >= BUILDING_MODE_BUILDING_IS_ACTIVE_MIN)
            {
                return true;
            }
            return false;
        }// end function

        public function GetBuildingMode() : int
        {
            return this.mBuildingMode;
        }// end function

        public function SetDestructionAnimEffectSet(param1:cGOSetList) : void
        {
            this.mDestructionAnimEffectSet = param1;
            return;
        }// end function

        public function IsBought() : Boolean
        {
            return this.mIsBought;
        }// end function

        public function BuyUpgrade() : void
        {
            mGeneralInterface.mCurrentPlayerZone.GetResources(this.mPlayerData).RemovePlayerResourcesFromResourcesInList(this.GetUpgradeCosts_vector(), 1);
            return;
        }// end function

        override public function IsCursorPlacable(param1:int, param2:int, param3:int) : int
        {
            var _loc_4:cBuilding = null;
            if (param3 == COMMAND.SELECT_BUILDING)
            {
                _loc_4 = mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[param1].mBuilding;
                if (_loc_4 != null)
                {
                    if (_loc_4.mGoGroup == global.buildingGroup)
                    {
                        return CURSOR_PLACABLE.BASEBUILDING_PLACE;
                    }
                }
                else
                {
                    _loc_4 = mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.CheckIfBuildingIsSouthSouthEastAndSouthWest(param1);
                    if (_loc_4 != null)
                    {
                        return CURSOR_PLACABLE.BASEBUILDING_PLACE;
                    }
                }
                return CURSOR_PLACABLE.UNPLACABLE;
            }
            return CURSOR_PLACABLE.BASEBUILDING_PLACE;
        }// end function

        public function GetRecoveringHitPoints() : int
        {
            return this.mRecoveringHitPoints;
        }// end function

        public function GetUpgradeStartTime() : Number
        {
            return this.mBuildingUpgradeStartTime;
        }// end function

        public function InitOffsets(param1:int, param2:int) : void
        {
            this.mOffsetX = param1;
            this.mOffsetY = param2;
            return;
        }// end function

        public function hasEventListener(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.hasEventListener(param1);
        }// end function

        private function IsBuildingCreatingResources() : Boolean
        {
            return this.mResourceCreation != null;
        }// end function

        public function IsBuildingInProduction() : Boolean
        {
            if (this.mBuildingMode >= BUILDING_MODE_BUILDING_IS_IN_PRODUCTION_MIN)
            {
                return true;
            }
            return false;
        }// end function

        public function GetRemainingConstructionDuration() : int
        {
            var _loc_1:Number = 0;
            switch(this.mBuildingMode)
            {
                case cBuilding.BUILDING_MODE_SETTLER_WALKS_TO_BUILDING_GROUND_PLACE:
                {
                    _loc_1 = (this.GetResourceCreation().GetPath().pathLenX10000 - this.GetResourceCreation().pathPos) / cComputeResourceCreation.SETTLER_WALK_SPEED_INT / mGeneralInterface.mGlobalTimeScale;
                }
                case cBuilding.BUILDING_MODE_CONSTRUCTION:
                {
                    _loc_1 = _loc_1 + this.GetGOContainer().mConstructionDuration * 1000 * (1 - this.mBuildingProgress / (100 * defines.BUILDING_PROGRESS_SCALE_FACTOR));
                    break;
                }
                default:
                {
                    break;
                }
            }
            return int(_loc_1);
        }// end function

        public function IsBuildingSelectable() : Boolean
        {
            if (mGeneralInterface.mEnumUIType == UITYPE.EDITOR)
            {
                return true;
            }
            if (!this.mIsSelectable)
            {
                return false;
            }
            return this.mBuildingMode != BUILDING_MODE_NONE && this.mBuildingMode != BUILDING_MODE_DESTRUCTION && this.mBuildingMode != BUILDING_MODE_DESTRUCTED;
        }// end function

        public function set mBuildingProgress(param1:int) : void
        {
            var _loc_2:* = this._1324158862mBuildingProgress;
            if (_loc_2 !== param1)
            {
                this._1324158862mBuildingProgress = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mBuildingProgress", _loc_2, param1));
            }
            return;
        }// end function

        public function GetUpgradeLevel() : int
        {
            return this.mUpgradeLevel;
        }// end function

        public function SetDamageAnimEffectSet(param1:cGOSetList) : void
        {
            this.mDamageAnimEffectSet = param1;
            return;
        }// end function

        public function InitFromVO(param1:dBuildingVO) : void
        {
            var _loc_2:dSquadVO = null;
            var _loc_3:dBuffApplianceVO = null;
            var _loc_4:BuffAppliance = null;
            this.mBuildingCreationTime = param1.buildingCreationTime;
            this.mStartWorkCounter = param1.startWorkCounter;
            this.mUpgradeLevel = param1.upgradeLevel;
            this.SetCurrentHitPoints(param1.hitPoints);
            this.mLastRepairTime = param1.lastRepairTime;
            this.mRecoveringHitPoints = param1.recoveringHitPoints;
            this.mInitialSetOnMap = param1.initialSetOnXMLMap;
            this.mIsBought = param1.isBought;
            this.mProductionActive = param1.isProductionActive;
            this.mBuildingDestructionTime = param1.destructionTime;
            this.mBuildingUpgradeProgress = param1.upgradeProgress;
            this.mBuildingUpgradeIsInProgress = param1.upgradeIsInProgress;
            this.mBuildingUpgradeStartTime = param1.upgradeStartTime;
            this.mBuildingProgress = param1.buildingProgress;
            this.mBuildingMode = param1.buildingMode;
            this.mOffsetX = param1.offsetX;
            this.mOffsetY = param1.offsetY;
            this.recurringBuffVO = param1.recurringBuffVO;
            this.mOrigin = param1.origin;
            this.mIsEngagedInCombat = param1.isEngagedInCombat;
            for each (_loc_2 in param1.armyVO.squads)
            {
                
                this.mArmy.AddSquadVO(_loc_2, false);
            }
            for each (_loc_3 in param1.buffs)
            {
                
                _loc_4 = BuffAppliance.CreateBuffApplianceFromVO(_loc_3);
                this.mBuffs_vector.push(_loc_4);
                if (_loc_4.GetBuffDefinition().GetName_string() == "ChangeColorScheme")
                {
                    if (gGfxResource.SetFilter(_loc_4.GetResourceName_string(), FILTER_SOURCE.BUFF))
                    {
                        gGfxResource.ApplyZoom(mGeneralInterface.mZoom.GetInvScaleFactor());
                        mGeneralInterface.mCurrentPlayerZone.SetBackgroundHasChanged(true);
                        mGeneralInterface.mCurrentPlayerZone.SetAllRescaleDirtyFlags();
                    }
                }
            }
            return;
        }// end function

        public function GetRecurringBuff() : dBuffVO
        {
            return this.recurringBuffVO;
        }// end function

        public function GetResourceOutputFactor() : int
        {
            var _loc_2:BuffAppliance = null;
            var _loc_1:int = 1;
            _loc_1 = this.GetUpgradeLevelBonuses().getProductivityOutputPercent() / 100;
            for each (_loc_2 in this.mBuffs_vector)
            {
                
                _loc_1 = _loc_1 * (_loc_2.GetBuffDefinition().getProductivityOutputPercent() / 100);
            }
            return _loc_1;
        }// end function

        public function IsInitialOnXMLMap() : Boolean
        {
            return this.mInitialSetOnMap;
        }// end function

        public function SetCurrentHitPoints(param1:int) : void
        {
            this.mCurrentHitPoints = param1;
            if (this.mCurrentHitPoints > this.GetMaxHitPoints())
            {
                this.mCurrentHitPoints = this.GetMaxHitPoints();
            }
            if (this.mCurrentHitPoints < 0)
            {
                this.mCurrentHitPoints = 0;
            }
            if (this.mDamageAnimEffectSet != null)
            {
                this.mDamageAnimEffectSet.SetValue(this.mCurrentHitPoints);
            }
            var _loc_2:* = this.GetMaxHitPoints() / DAMAGE_LEVEL_AMOUNT;
            this.mCurrentDamageLevel = Math.round(this.mCurrentHitPoints / _loc_2);
            this.mHealthBar = Math.min(this.mCurrentHitPoints / this.GetMaxHitPoints(), 1);
            return;
        }// end function

        public function SetInitialOnXMLMap(param1:Boolean) : void
        {
            this.mInitialSetOnMap = param1;
            return;
        }// end function

        public function IsInUpgradableBuildingMode() : Boolean
        {
            return this.mBuildingMode != cBuilding.BUILDING_MODE_QUEUED && this.mBuildingMode != cBuilding.BUILDING_MODE_CONSTRUCTION && this.mBuildingMode != cBuilding.BUILDING_MODE_SET_BUILDING_GROUND_PLACE && this.mBuildingMode != cBuilding.BUILDING_MODE_SETTLER_WALKS_TO_BUILDING_GROUND_PLACE;
        }// end function

        public function SetBuildingName_string(param1:String) : void
        {
            this.mBuildingName_string = param1;
            return;
        }// end function

        public function CreateFlagEffectSet(param1:String) : void
        {
            this.mFlagEffectSet = cGOSetManager.CreateGOSetList(param1, null);
            this.mFlagEffectSet.SetSubTypeCurrentGOSetItem(mGeneralInterface.mCurrentPlayerZone.GetPlayerColorIdx(this.GetPlayerID()));
            return;
        }// end function

        public function removeEventListener(param1:String, param2:Function, param3:Boolean = false) : void
        {
            this._bindingEventDispatcher.removeEventListener(param1, param2, param3);
            return;
        }// end function

        public function RenderPlayerName() : void
        {
            if (this.mPlayerData.GetPlayerName_string() == null)
            {
                return;
            }
            mGeneralInterface.mCurrentPlayerZone.RenderTextCenter(cBackbuffer.mBackBuffer, this.mPlayerData.GetPlayerName_string(), GetXInt(), GetYInt() - global.streetGridY * 2 + 34);
            return;
        }// end function

        public function DamageBuilding(param1:int, param2:cPlayerData) : void
        {
            if (param1 == 0)
            {
                return;
            }
            this.SetCurrentHitPoints(this.mCurrentHitPoints - param1);
            if (this.mCurrentHitPoints <= 0)
            {
                mGeneralInterface.mCurrentPlayerZone.DestroyBuildingByAttack(this, param2);
                mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.RemoveBuildingFromGameLogic(this);
            }
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function SetStreetGridEntry(param1:int) : Boolean
        {
            this.mStreetGridEntry = param1;
            return true;
        }// end function

        public function SetResourceCreation(param1:cResourceCreation) : void
        {
            this.mResourceCreation = param1;
            return;
        }// end function

        public function IsWarehouseType() : Boolean
        {
            return this.mGoGroup.IsWarehouse(this.mBuildingName_string);
        }// end function

        public function GetUpgradeLevelBonusesForLevel(param1:int) : cBuffDefinition
        {
            var _loc_2:cBuffDefinition = null;
            if (GetGOContainer().buildingUpgradeBonuses_vector != null)
            {
                if (param1 < GetGOContainer().buildingUpgradeBonuses_vector.length)
                {
                    _loc_2 = GetGOContainer().buildingUpgradeBonuses_vector[param1];
                }
                else
                {
                    return null;
                }
            }
            else if (param1 < global.buildingUpgradeBonuses_vector.length)
            {
                _loc_2 = global.buildingUpgradeBonuses_vector[param1];
            }
            return _loc_2;
        }// end function

        public function SetBuildingGrid(param1:int) : void
        {
            this.mBuildingGrid = param1;
            return;
        }// end function

        public function GetSpriteWorkAnim() : cSpriteLib
        {
            return this.mSpriteWorkAnim;
        }// end function

        public function GetRefundResources()
        {
            return this.mPlayerData.GetRefundResourcesByReturnRate(GetGOContainer().mGfxResourceListName_string);
        }// end function

        public function RepairBuilding(param1:int) : void
        {
            if (param1 == 0)
            {
                return;
            }
            this.SetCurrentHitPoints(this.mCurrentHitPoints + param1);
            if (this.mCurrentHitPoints > this.GetMaxHitPoints())
            {
                this.mCurrentHitPoints = this.GetMaxHitPoints();
            }
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function SetProductionActive(param1:Boolean) : void
        {
            this.mProductionActive = param1;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            this.mWaitForCommand = false;
            if (this.GetResourceCreation() != null)
            {
                if (!param1)
                {
                    this.GetResourceCreation().SetProductionState(cResourceCreation.PRODUCTIONSTATE_STOPPED_PRODUCTION);
                }
                else
                {
                    this.GetResourceCreation().SetProductionState(cResourceCreation.PRODUCTIONSTATE_WORKING);
                }
            }
            globalFlash.gui.mBuildingInfoPanel.DisplayProductionState();
            return;
        }// end function

        public function willTrigger(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.willTrigger(param1);
        }// end function

        public function get mBuildingProgress() : int
        {
            return this._1324158862mBuildingProgress;
        }// end function

        public function SetSpriteWorkAnim(param1:cSpriteLib) : void
        {
            this.mSpriteWorkAnim = param1;
            return;
        }// end function

        override public function SetPosition(param1:Number, param2:Number) : void
        {
            mXNotScaled = param1;
            mYNotScaled = param2;
            mXScaled = param1 * mGeneralInterface.mZoom.mFactorDivDefaultZoom + this.mOffsetX * mGeneralInterface.mZoom.mFactorDivDefaultZoom;
            mYScaled = param2 * mGeneralInterface.mZoom.mFactorDivDefaultZoom + this.mOffsetY * mGeneralInterface.mZoom.mFactorDivDefaultZoom;
            return;
        }// end function

        public function GetHealthBar() : Number
        {
            return this.mHealthBar;
        }// end function

        public function SetOffsets(param1:int, param2:int) : void
        {
            this.mOffsetX = param1;
            this.mOffsetY = param2;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function Refund() : void
        {
            if (this.mIsBought)
            {
                mGeneralInterface.mCurrentPlayerZone.GetResources(this.mPlayerData).RefundBuildingResourcesToPlayerResources(GetGOContainer().mGfxResourceListName_string);
            }
            return;
        }// end function

        public function IsDecoration() : Boolean
        {
            return this.GetGOContainer().mEnumGoSubType == GO_SUBTYPE.DECORATION;
        }// end function

        public function GetRepairCosts()
        {
            var _loc_2:dResource = null;
            var _loc_3:dResource = null;
            var _loc_1:* = new Vector.<dResource>;
            if (this.GetCurrentHitPoints() >= this.GetMaxHitPoints())
            {
            }
            else
            {
                for each (_loc_2 in GetGOContainer().mCostList_vector)
                {
                    
                    _loc_3 = new dResource();
                    _loc_3.name_string = _loc_2.name_string;
                    _loc_3.amount = int(_loc_2.amount * global.repairCostFactor * this.mHealthBar / 100);
                    _loc_1.push(_loc_3);
                }
            }
            return _loc_1;
        }// end function

        public function GetMaxHitPoints() : int
        {
            if (this.mMaxHitPoints <= 0)
            {
                this.mMaxHitPoints = GetGOContainer().mHitPoints;
                if (this.mUpgradeLevel > 1)
                {
                    this.mMaxHitPoints = this.mMaxHitPoints + this.GetUpgradeLevelBonuses().getHitPoints();
                }
            }
            return this.mMaxHitPoints;
        }// end function

        public function SetRecurringBuff(param1:dBuffVO) : void
        {
            this.recurringBuffVO = param1;
            return;
        }// end function

        public function GetResourceInputFactor() : int
        {
            var _loc_2:BuffAppliance = null;
            var _loc_1:int = 1;
            _loc_1 = this.GetUpgradeLevelBonuses().getProductivityInputPercent() / 100;
            for each (_loc_2 in this.mBuffs_vector)
            {
                
                _loc_1 = _loc_1 * (_loc_2.GetBuffDefinition().getProductivityInputPercent() / 100);
            }
            return _loc_1;
        }// end function

        public function SetWorkAnimSubtype(param1:int) : void
        {
            this.mSpriteWorkAnim.SetSubType(param1);
            return;
        }// end function

        public function GetUpgradeDuration() : int
        {
            var _loc_1:* = this.GetUpgradeLevelBonusesForLevel((this.mUpgradeLevel + 1));
            if (_loc_1 == null)
            {
                return -1;
            }
            return _loc_1.GetProductionTime();
        }// end function

        override public function Render() : void
        {
            var _loc_6:Number = NaN;
            var _loc_7:String = null;
            var _loc_1:* = int(mXScaled);
            var _loc_2:* = int(mYScaled);
            var _loc_3:* = int(mXNotScaled + this.mOffsetX);
            var _loc_4:* = int(mYNotScaled + this.mOffsetY);
            var _loc_5:int = 0;
            switch(this.mBuildingMode)
            {
                case BUILDING_MODE_PLACED:
                {
                    gGfxResource.mPreBuild.mSprite.SetSubType(0);
                    gGfxResource.mPreBuild.mSprite.RenderPosNoScaling(_loc_1, _loc_2);
                    break;
                }
                case BUILDING_MODE_QUEUED:
                {
                    gGfxResource.mPreBuild.mSprite.SetSubType(0);
                    gGfxResource.mPreBuild.mSprite.RenderPosNoScaling(_loc_1, _loc_2);
                    if (this.mResourceCreation != null)
                    {
                        if (this.mResourceCreation.GetProductionState() != cResourceCreation.PRODUCTIONSTATE_WORKING)
                        {
                            gGfxResource.mBuildingInfoIcons.SetSubType(this.mResourceCreation.GetProductionState());
                            gGfxResource.mBuildingInfoIcons.RenderPos(_loc_3, _loc_4 - (global.streetGridY + global.streetGridYHalf) - mGeneralInterface.mWobblingInt);
                        }
                        else
                        {
                            gGfxResource.mBuildingQueuedIcon.RenderPos(_loc_3, _loc_4 - global.streetGridY * 2);
                        }
                    }
                    break;
                }
                case BUILDING_MODE_SETTLER_WALKS_TO_BUILDING_GROUND_PLACE:
                case BUILDING_MODE_SET_BUILDING_GROUND_PLACE:
                {
                    gGfxResource.mPreBuild.mSprite.SetSubType(0);
                    gGfxResource.mPreBuild.mSprite.RenderPosNoScaling(_loc_1, _loc_2);
                    if (this.mResourceCreation != null)
                    {
                        if (this.mResourceCreation.GetProductionState() != cResourceCreation.PRODUCTIONSTATE_WORKING)
                        {
                            gGfxResource.mBuildingInfoIcons.SetSubType(this.mResourceCreation.GetProductionState());
                            gGfxResource.mBuildingInfoIcons.RenderPos(_loc_3, _loc_4 - (global.streetGridY + global.streetGridYHalf) - mGeneralInterface.mWobblingInt);
                        }
                    }
                    break;
                }
                case BUILDING_MODE_CONSTRUCTION:
                {
                    if (this.mConstructionSpriteLib != null)
                    {
                        this.mConstructionSpriteLib.Animate(mGeneralInterface.mCalculateTicks.mDeltaTicksOne);
                        this.mConstructionSpriteLib.RenderPosNoScaling(_loc_1, _loc_2);
                    }
                    _loc_5 = int(this.mBuildingProgress / defines.BUILDING_PROGRESS_SCALE_FACTOR);
                    if (this.mConstructionAnimEffectSet != null)
                    {
                        this.mConstructionAnimEffectSet.SetValue(_loc_5);
                        this.mConstructionAnimEffectSet.Animate(mGeneralInterface.mCalculateTicks.mDeltaTicksOne);
                        this.mConstructionAnimEffectSet.Render(GetXInt(), GetYInt());
                    }
                    mGeneralInterface.mCurrentPlayerZone.RenderText(cBackbuffer.mBackBuffer, _loc_5 + "%", _loc_3, _loc_4 - global.streetGridY);
                    break;
                }
                case BUILDING_MODE_DESTRUCTION:
                {
                    if (this.mConstructionSpriteLib != null)
                    {
                        this.mConstructionSpriteLib.Animate(mGeneralInterface.mCalculateTicks.mDeltaTicksOne);
                        this.mConstructionSpriteLib.RenderPosNoScaling(_loc_1, _loc_2);
                    }
                    _loc_5 = 100 - int(mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.GetDestructionProgressInPercent(this));
                    if (this.mDestructionAnimEffectSet != null)
                    {
                        this.mDestructionAnimEffectSet.SetValue(_loc_5);
                        this.mDestructionAnimEffectSet.Animate(mGeneralInterface.mCalculateTicks.mDeltaTicksOne);
                        this.mDestructionAnimEffectSet.Render(GetXInt(), GetYInt());
                    }
                    mGeneralInterface.mCurrentPlayerZone.RenderText(cBackbuffer.mBackBuffer, _loc_5 + "%", _loc_3, _loc_4 - global.streetGridY);
                    break;
                }
                default:
                {
                    if (mSprite.GetContainer().mNofStreamUpgrades != 0)
                    {
                        SetSubType(gCalculations.CalculateGFXUpgradeLevel(this.mUpgradeLevel, (mSprite.GetContainer().mNofStreamUpgrades - 1)));
                    }
                    else
                    {
                        SetSubType(gCalculations.CalculateGFXUpgradeLevel(this.mUpgradeLevel, (GetNofSubTypes() - 1)));
                    }
                    if (this.mCursorHighlight || mGeneralInterface.mCurrentCursor.GetEditMode() == COMMAND.APPLY_BUFF && global.buffingBlockedUntil < gMisc.GetTimeSinceStartup() && mGeneralInterface.mCurrentCursor.mCurrentBuff.IsApplyable(mGeneralInterface.mCurrentPlayer, mGeneralInterface, this.mBuildingGrid) == this)
                    {
                        super.Render();
                        if (mPlayerID != 0 || mGeneralInterface.mEnumUIType == UITYPE.EDITOR)
                        {
                            super.mSprite.RenderTransform2NoScaling(_loc_1, _loc_2, BlendMode.ADD, 1, 1, 0);
                        }
                        if (this.mSpriteWorkAnim != null)
                        {
                            this.mSpriteWorkAnim.RenderPosNoScaling(_loc_1, _loc_2);
                            if (mPlayerID != 0)
                            {
                                this.mSpriteWorkAnim.RenderTransform2NoScaling(_loc_1, _loc_2, BlendMode.ADD, 1, 1, 0);
                            }
                        }
                    }
                    else
                    {
                        super.Render();
                        if (this.mSpriteWorkAnim != null)
                        {
                            this.mSpriteWorkAnim.RenderPosNoScaling(_loc_1, _loc_2);
                        }
                    }
                    if (this.mRecoveringHitPoints > 0)
                    {
                        gGfxResource.mBuildingRepairIcon.RenderPos(_loc_3, this.int(_loc_4 - global.streetGridY * 1.75 + 10));
                    }
                    if (this.mCurrentHitPoints < this.mMaxHitPoints)
                    {
                        gGfxResource.mHealthBarIcons.SetSubTypeAndFrame(this.mCurrentDamageLevel, 0);
                        gGfxResource.mHealthBarIcons.RenderPos(_loc_3 - gGfxResource.mHealthBarIcons.mSprite.GetWidth() / 2, _loc_4 - global.streetGridY * 1 + 10);
                    }
                    if (this.mDamageAnimEffectSet != null)
                    {
                        this.mDamageAnimEffectSet.Render(GetXInt(), GetYInt());
                    }
                    if (this.mBuildingUpgradeIsInProgress)
                    {
                        gGfxResource.mBuildingInfoIcons.SetSubType(cResourceCreation.BUILDINGUPGRADE_PRODUCTIONSTATE_UPDATE_IN_PROGRESS);
                        gGfxResource.mBuildingInfoIcons.RenderPos(_loc_3, _loc_4 - (global.streetGridY + global.streetGridY) - mGeneralInterface.mWobblingInt);
                    }
                    else if (this.mResourceCreation != null)
                    {
                        if (this.mResourceCreation.GetProductionState() != cResourceCreation.PRODUCTIONSTATE_WORKING)
                        {
                            _loc_6 = mGeneralInterface.GetClientTime() - this.mBuildingCreationTime;
                            if (_loc_6 < defines.BUILDING_INFO_ICON_TIME_FOR_DELAY)
                            {
                                if (this.mBuildingInfoIconDelayEndTime == -1)
                                {
                                    this.mBuildingInfoIconDelayEndTime = gMisc.GetTimeSinceStartup() + global.buildingInfoIconDelay;
                                }
                            }
                            else
                            {
                                this.mBuildingInfoIconDelayEndTime = -1;
                            }
                            if (!this.mProductionActive)
                            {
                                gGfxResource.mBuildingInfoIcons.SetSubType(cResourceCreation.PRODUCTIONSTATE_STOPPED_PRODUCTION);
                                gGfxResource.mBuildingInfoIcons.RenderPos(_loc_3, _loc_4 - (global.streetGridY + global.streetGridY) - mGeneralInterface.mWobblingInt);
                            }
                            else if (this.mBuildingInfoIconDelayEndTime < gMisc.GetTimeSinceStartup())
                            {
                                gGfxResource.mBuildingInfoIcons.SetSubType(this.mResourceCreation.GetProductionState());
                                gGfxResource.mBuildingInfoIcons.RenderPos(_loc_3, _loc_4 - (global.streetGridY + global.streetGridY) - mGeneralInterface.mWobblingInt);
                            }
                        }
                        else
                        {
                            this.mBuildingInfoIconDelayEndTime = -1;
                            if (this.mBuildingMode == BUILDING_MODE_WORKANIM_IS_WORKING_AT_WORKYARD_LOCAL_WORKYARD_SYSTEM || this.mBuildingMode == BUILDING_MODE_WORKANIM_IS_WORKING_AT_WORKYARD_EXTERNAL_WORKYARD_SYSTEM_ACTIVE)
                            {
                                if (this.mSmokeEffectSet != null)
                                {
                                    this.mSmokeEffectSet.Render(_loc_3, _loc_4);
                                }
                            }
                        }
                    }
                    this.RenderFlag();
                    if (mGeneralInterface.mHomePlayer.GetPlayerId() <= defines.ADVENTUREZONEID)
                    {
                        if (mPlayerID > 0)
                        {
                            if (GetGOContainer().mMaxUnits > 0)
                            {
                                this.RenderUpgradeLevelAndPlayerColor();
                                this.RenderPlayerName();
                                if (this.mGarrissonWaitForCommand)
                                {
                                    if (mGeneralInterface.IsMoreThanOnePlayerOnMap())
                                    {
                                        gGfxResource.mWaitForCommandIcon.RenderPos(_loc_3, _loc_4 - global.streetGridY * 2);
                                    }
                                }
                            }
                        }
                    }
                    if (this.mBuffs_vector.length > 0)
                    {
                        if (this.mBuffTwinkleEffectSet != null)
                        {
                            this.mBuffTwinkleEffectSet.Render(_loc_3, _loc_4);
                        }
                    }
                    if (this.mBuildingUpgradeIsInProgress)
                    {
                        _loc_5 = this.mBuildingUpgradeProgress;
                        mGeneralInterface.mCurrentPlayerZone.RenderText(cBackbuffer.mBackBuffer, _loc_5 + "%", _loc_3, _loc_4 - global.streetGridY);
                    }
                    break;
                    break;
                }
            }
            return;
        }// end function

        public function GetDestructionAnimEffectSet() : cGOSetList
        {
            return this.mDestructionAnimEffectSet;
        }// end function

        public function CreateBuildingVOFromBuilding() : dBuildingVO
        {
            var _loc_2:cSquad = null;
            var _loc_3:BuffAppliance = null;
            var _loc_1:* = new dBuildingVO();
            _loc_1.buildingCreationTime = this.mBuildingCreationTime;
            _loc_1.buildingName_string = this.GetBuildingName_string();
            _loc_1.buildingGrid = this.GetBuildingGrid();
            _loc_1.buildingMode = this.GetBuildingMode();
            _loc_1.startWorkCounter = this.mStartWorkCounter;
            _loc_1.upgradeLevel = this.GetUpgradeLevel();
            _loc_1.hitPoints = this.GetCurrentHitPoints();
            _loc_1.lastRepairTime = this.mLastRepairTime;
            _loc_1.recoveringHitPoints = this.GetRecoveringHitPoints();
            _loc_1.initialSetOnXMLMap = this.mInitialSetOnMap;
            _loc_1.isBought = this.mIsBought;
            _loc_1.isProductionActive = this.mProductionActive;
            _loc_1.destructionTime = this.mBuildingDestructionTime;
            _loc_1.buildingProgress = this.mBuildingProgress;
            _loc_1.upgradeIsInProgress = this.mBuildingUpgradeIsInProgress;
            _loc_1.upgradeProgress = this.mBuildingUpgradeProgress;
            _loc_1.upgradeStartTime = this.mBuildingUpgradeStartTime;
            _loc_1.offsetX = this.mOffsetX as int;
            _loc_1.offsetY = this.mOffsetY as int;
            _loc_1.recurringBuffVO = this.GetRecurringBuff();
            _loc_1.origin = this.mOrigin;
            _loc_1.isEngagedInCombat = this.mIsEngagedInCombat;
            _loc_1.playerID = GetPlayerID();
            for each (_loc_2 in this.mArmy.GetSquads_vector())
            {
                
                _loc_1.armyVO.squads.addItem(new dSquadVO().init(_loc_2.GetType_string(), _loc_2.GetAmount(), _loc_2.GetCurrentHitPoints()));
            }
            for each (_loc_3 in this.mBuffs_vector)
            {
                
                _loc_1.buffs.addItem(_loc_3.CreateBuffApplianceVOFromBuff());
            }
            return _loc_1;
        }// end function

        private function ConstructionBuildingAnimComplete(event:Event) : void
        {
            this.mLoadingInProgress = false;
            return;
        }// end function

        public function IsUpgradeAllowed(param1:Boolean) : Boolean
        {
            if (param1 && !mGeneralInterface.mCurrentPlayerZone.GetResources(this.mPlayerData).HasPlayerResourcesInListOne(this.GetUpgradeCosts_vector()) || !param1 && this.GetUpgradeCosts_vector() == null || this.mBuildingMode == BUILDING_MODE_DESTRUCTION || this.mBuildingMode == BUILDING_MODE_DESTRUCTED || this.mBuildingUpgradeIsInProgress || !this.IsInUpgradableBuildingMode())
            {
                return false;
            }
            return true;
        }// end function

        public function SetBuildingMode(param1:int) : Boolean
        {
            var _loc_2:cGOSpriteLibContainer = null;
            if (param1 == BUILDING_MODE_QUEUED)
            {
                this.mLastProgress = -1;
            }
            else if (param1 == BUILDING_MODE_SET_BUILDING_GROUND_PLACE)
            {
                this.mLastProgress = -1;
            }
            else if (param1 == BUILDING_MODE_CONSTRUCTION)
            {
                if (this.mConstructionSpriteLib != null && this.mConstructionSpriteLib.GetNofFrames(0) > 1)
                {
                    _loc_2 = this.mConstructionSpriteLib.GetContainer() as cGOSpriteLibContainer;
                    this.mConstructionSpriteLib.SetAnim(_loc_2.mConstructionAnimSpeed, true);
                }
                this.mLastProgress = -1;
            }
            else if (param1 == BUILDING_MODE_DESTRUCTION)
            {
                mGeneralInterface.mCurrentPlayer.mBuildQueue.RemoveBuildingFromQueue(this.GetBuildingGrid());
            }
            else if (param1 == BUILDING_MODE_PRODUCES_NO_RESOURCES)
            {
                if (this.mResourceCreation != null)
                {
                    this.mResourceCreation.SetSettlerKIStateDeactivate();
                }
            }
            else if (param1 == BUILDING_MODE_BUILDER_WALKS_FROM_RESOURCECREATIONHOUSE_TO_STOREHOUSE)
            {
                if (this.mResourceCreation != null)
                {
                    this.mResourceCreation.SetSettlerKIState(cSettlerKI.SETTLER_STATE_WALKING_ON_RESOURCE_PATH);
                }
            }
            else if (param1 == BUILDING_MODE_MOVING)
            {
                this.mBuildingModeBeforeMoving = this.mBuildingMode;
                this.mBuildingMode = param1;
                return true;
            }
            if (this.mBuildingMode != BUILDING_MODE_NONE && this.mBuildingMode != BUILDING_MODE_MOVING)
            {
                if (this.IsBuildingInProduction())
                {
                    this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.WEAK_MODIFICATION_BIT;
                }
                else
                {
                    this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
                }
            }
            this.mBuildingMode = param1;
            if (this.mResourceCreation != null && this.mResourceCreation.HasInvalidatedPaths())
            {
                switch(this.GetBuildingMode())
                {
                    case BUILDING_MODE_SETTLER_WALKS_TO_BUILDING_GROUND_PLACE:
                    case BUILDING_MODE_BUILDER_WALKS_FROM_RESOURCECREATIONHOUSE_TO_STOREHOUSE:
                    case BUILDING_MODE_SETTLER_WALKS_FROM_EXTERNAL_RESOURCE_TO_RESOURCECREATIONHOUSE:
                    case BUILDING_MODE_SETTLER_WALKS_FROM_RESOURCECREATIONHOUSE_TO_STOREHOUSE:
                    case BUILDING_MODE_SETTLER_WALKS_FROM_RESOURCECREATIONHOUSE_TO_EXTERNAL_RESOURCE:
                    {
                        mGeneralInterface.mComputeResourceCreation.CalculateProductionPaths(this, true);
                        this.mResourceCreation.SetInvalidatePaths(false);
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
            return true;
        }// end function

        public function GetBuildingName_string() : String
        {
            return this.mBuildingName_string;
        }// end function

        public function GetBuildInstantCosts() : int
        {
            if (GetGOContainer().mBuildInstantCosts > 0)
            {
                return GetGOContainer().mBuildInstantCosts;
            }
            return global.defaultBuildInstantCosts;
        }// end function

        public function RenderUpgradeLevelAndPlayerColor() : void
        {
            var _loc_1:* = GetXInt();
            var _loc_2:* = GetYInt();
            var _loc_3:* = mGeneralInterface.mCurrentPlayerZone.GetPlayerColorIdx(GetPlayerID());
            gGfxResource.mUpgradeLevelIcons.SetSubType(_loc_3);
            gGfxResource.mUpgradeLevelIcons.RenderPos(_loc_1, _loc_2 - global.streetGridY * 2);
            gGfxResource.mUpgradeLevelNumbers.SetSubType(this.mUpgradeLevel);
            gGfxResource.mUpgradeLevelNumbers.RenderPos(_loc_1, _loc_2 - global.streetGridY * 2 + 6);
            return;
        }// end function

        public function ModifyOffsetX(param1:int) : void
        {
            this.mOffsetX = this.mOffsetX + param1;
            return;
        }// end function

        public function ModifyOffsetY(param1:int) : void
        {
            this.mOffsetY = this.mOffsetY + param1;
            return;
        }// end function

        public function SetGoGroup(param1:cGOGroup) : Boolean
        {
            this.mGoGroup = param1;
            return true;
        }// end function

        public function GetStreetGridEntry() : int
        {
            return this.mStreetGridEntry;
        }// end function

        public function GetArmy() : cArmy
        {
            return this.mArmy;
        }// end function

        public function Upgrade() : Boolean
        {
            var _loc_1:* = this.GetMaxHitPoints();
            var _loc_2:String = this;
            var _loc_3:* = this.mUpgradeLevel + 1;
            _loc_2.mUpgradeLevel = _loc_3;
            this.mMaxHitPoints = 0;
            this.SetCurrentHitPoints(this.mCurrentHitPoints + (this.GetMaxHitPoints() - _loc_1));
            this.mBuildingUpgradeStartTime = 0;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return true;
        }// end function

        public static function GetBuildingModeString(param1:int) : String
        {
            switch(param1)
            {
                case BUILDING_MODE_NONE:
                {
                    return "None";
                }
                case BUILDING_MODE_QUEUED:
                {
                    return "Queued";
                }
                case BUILDING_MODE_SET_BUILDING_GROUND_PLACE:
                {
                    return "SetBuildingGroundPlace";
                }
                case BUILDING_MODE_SETTLER_WALKS_TO_BUILDING_GROUND_PLACE:
                {
                    return "SettlerWalksToBuildingGroundPlace";
                }
                case BUILDING_MODE_CONSTRUCTION:
                {
                    return "Construction";
                }
                case BUILDING_MODE_DESTRUCTION:
                {
                    return "Destruction";
                }
                case BUILDING_MODE_DESTRUCTED:
                {
                    return "Destructed";
                }
                case BUILDING_MODE_BUILDER_WALKS_FROM_RESOURCECREATIONHOUSE_TO_STOREHOUSE:
                {
                    return "BuilderWalksFromResourceCreationHouseToStorehouse";
                }
                case BUILDING_MODE_SETTLER_WALKS_FROM_STOREHOUSE_TO_RESOURCECREATIONHOUSE:
                {
                    return "SettlerWalksFromStorehouseToResourceCreationHouse";
                }
                case BUILDING_MODE_SETTLER_WALKS_FROM_RESOURCECREATIONHOUSE_TO_STOREHOUSE:
                {
                    return "SettlerWalksFromResourceCreationHouseToStorehouse";
                }
                case BUILDING_MODE_WORKANIM_IS_WORKING_AT_WORKYARD_LOCAL_WORKYARD_SYSTEM:
                {
                    return "WorkanimIsWorkingAtWorkyardLocalWorkyardSystem";
                }
                case BUILDING_MODE_WORKANIM_IS_WORKING_AT_WORKYARD_EXTERNAL_WORKYARD_SYSTEM_ACTIVE:
                {
                    return "WorkanimIsWorkingAtWorkyardExternalWorkyardSystemActive";
                }
                case BUILDING_MODE_SETTLER_WALKS_FROM_RESOURCECREATIONHOUSE_TO_EXTERNAL_RESOURCE:
                {
                    return "SettlerWalksFromResourceCreationHouseToExternalResource";
                }
                case BUILDING_MODE_SETTLER_WALKS_FROM_EXTERNAL_RESOURCE_TO_RESOURCECREATIONHOUSE:
                {
                    return "SettlerWalksFromExternalResourceToResourceCreationHouse";
                }
                case BUILDING_MODE_WORKANIM_IS_WORKING_AT_EXTERNAL_DEPOSIT:
                {
                    return "WorkanimIsWorkingAtExternalDeposit";
                }
                case BUILDING_MODE_PRODUCES_NO_RESOURCES:
                {
                    return "ProducesNoResources";
                }
                default:
                {
                    return "Unknown: " + param1;
                    continue;
                }
            }
        }// end function

        public static function CreateFromString(param1:cPlayerData, param2:cGOGroup, param3:String, param4:cGeneralInterface) : cBuilding
        {
            var _loc_5:* = param2.GetNrFromName(param3);
            var _loc_6:* = new cBuilding(param4, param1 != null ? (param1.GetPlayerId()) : (-1));
            new cBuilding(param4, param1 != null ? (param1.GetPlayerId()) : (-1)).InitFromNr(param2, _loc_5);
            _loc_6.mSpriteWorkAnim = param2.GetSpriteLibFromNr(param2.mGOWorkAnimList_vector, _loc_5);
            if (_loc_6.mSpriteWorkAnim != null)
            {
                _loc_6.SetWorkAnimation();
            }
            _loc_6.mBuildingName_string = param3;
            _loc_6.mGoGroup = param2;
            _loc_6.mStartWorkCounter = 0;
            _loc_6.mIsBought = false;
            _loc_6.mWaitForCommand = false;
            _loc_6.mGarrissonWaitForCommand = false;
            _loc_6.mBuildingMode = BUILDING_MODE_NONE;
            _loc_6.mCurrentHitPoints = _loc_6.GetMaxHitPoints();
            _loc_6.mPlayerData = param1;
            if (param1 != null)
            {
                _loc_6.mPlayerID = param1.GetPlayerId();
            }
            else
            {
                _loc_6.mPlayerID = -1;
            }
            _loc_6.mLevelEnumObjectType = OBJECTTYPE.BUILDING;
            var _loc_7:* = param2.GetGoSpriteLibContainerFromNr(_loc_5).mFlagEffectSetName_string;
            if (param2.GetGoSpriteLibContainerFromNr(_loc_5).mFlagEffectSetName_string != null && _loc_7 != "")
            {
                _loc_6.CreateFlagEffectSet(_loc_7);
            }
            var _loc_8:* = param2.mConstructionFileName_vector[_loc_5];
            if (param2.mConstructionFileName_vector[_loc_5] != null)
            {
                _loc_6.SetConstructionAnimEffectSet(cGOSetManager.CreateGOSetList(_loc_8, new cGOSetListControllerPercentage(100)));
            }
            var _loc_9:* = param2.mDestructionFileName_vector[_loc_5];
            if (param2.mDestructionFileName_vector[_loc_5] != null)
            {
                _loc_6.SetDestructionAnimEffectSet(cGOSetManager.CreateGOSetList(_loc_9, new cGOSetListControllerPercentage(100)));
            }
            var _loc_10:* = cGOSetManager.CreateGOSetList("damageAnimEffectSet", new cGOSetListControllerPercentage(_loc_6.GetMaxHitPoints()));
            cGOSetManager.CreateGOSetList("damageAnimEffectSet", new cGOSetListControllerPercentage(_loc_6.GetMaxHitPoints())).SetValue(_loc_6.GetMaxHitPoints());
            _loc_6.SetDamageAnimEffectSet(_loc_10);
            return _loc_6;
        }// end function

    }
}
