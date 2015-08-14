package ServerState
{
    import BuffSystem.*;
    import Communication.VO.*;
    import Enums.*;
    import GO.*;
    import Interface.*;
    import Map.*;
    import __AS3__.vec.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.collections.*;
    import mx.events.*;
    import nLib.*;

    public class cPlayerData extends EventDispatcher
    {
        private var mTemporaryBuildQueueSlotsCount:int = 0;
        private var mGeologistsAmount:int;
        private var mXP:int = 0;
        public var mDirtyIndicator:int = 0;
        private var mLogLevel:int;
        private var mCurrentlyBuildingsCount:Dictionary;
        private var mLastUpdate:Number;
        private var mExplorersAmount:int;
        private var mLogActions:Boolean;
        private var mPlayerId:int = -1;
        private const mPrePlacedBuildingCounter_vector:Vector.<cBuilding>;
        public const mPurchasedShopItems_vector:Vector.<dPurchasedShopItemVO>;
        private var mPlayerLevel:int = 1;
        public const mAvailableTempSlots_vector:Vector.<dTempBuildSlotVO>;
        private var mPlayerState:int = -1;
        public var mCurrentBuildingsCountAll:int;
        public var mUpdateCheckCounter:int = 0;
        public var mBuildQueue:cBuildQueueData = null;
        private var mGeneralsAmount:int;
        private var mCurrentMaximumBuildingsCountAll:int = 0;
        private var mUnique:dUniqueID;
        private var mPlayerListItem:dPlayerListItemVO;
        private const mDiscoveredSector_vector:Vector.<cSectorDiscovery>;
        private var mPlayerCanCheat:Boolean;
        private var mPlayerName_string:String = "";
        private var _1900481957mIsAdventureZone:Boolean = true;
        private var mGeneralInterface:cGeneralInterface;
        private var mXPChanged:Boolean;
        public const mAvailableBuffs_vector:Vector.<cBuff>;
        private var mAvatarId:int = 1;
        private var _1779503100mIsPlayerZone:Boolean = true;
        private var mPermanentBuildQueueSlotsCount:int = 0;
        private var mCityLevel:int = 0;
        private var mLogTypeMask:int;
        public static const PLAYER_STATE_START_GAME:int = 0;
        public static const PLAYER_STATE_UNDEFINED:int = -1;

        public function cPlayerData(param1:cGeneralInterface)
        {
            this.mAvailableBuffs_vector = new Vector.<cBuff>;
            this.mCurrentlyBuildingsCount = new Dictionary();
            this.mUnique = new dUniqueID();
            this.mPrePlacedBuildingCounter_vector = new Vector.<cBuilding>;
            this.mDiscoveredSector_vector = new Vector.<cSectorDiscovery>;
            this.mPurchasedShopItems_vector = new Vector.<dPurchasedShopItemVO>;
            this.mAvailableTempSlots_vector = new Vector.<dTempBuildSlotVO>;
            this.mGeneralInterface = param1;
            this.mBuildQueue = new cBuildQueueData(this.mGeneralInterface, this);
            if (definesMaster.MASTER_VERSION)
            {
                this.mPlayerCanCheat = false;
            }
            else
            {
                this.mPlayerCanCheat = true;
            }
            return;
        }// end function

        public function get mIsPlayerZone() : Boolean
        {
            return this._1779503100mIsPlayerZone;
        }// end function

        public function InitMaxBuildingCount(param1:int) : void
        {
            this.mCurrentMaximumBuildingsCountAll = param1;
            return;
        }// end function

        public function DecBuildingAll(param1:cBuilding) : void
        {
            if (param1.GetPlayerID() != this.GetPlayerId())
            {
                return;
            }
            if (param1.mOrigin == cBuilding.BUILDING_ORIGIN_FROM_GAME)
            {
                if (this.IsBuildingCounted(param1.GetBuildingName_string()))
                {
                    var _loc_2:String = this;
                    var _loc_3:* = this.mCurrentBuildingsCountAll - 1;
                    _loc_2.mCurrentBuildingsCountAll = _loc_3;
                    if (globalFlash.gui.mInfoBar != null)
                    {
                        globalFlash.gui.mInfoBar.SetBuildingsCount(this.mCurrentBuildingsCountAll, this.mCurrentMaximumBuildingsCountAll);
                    }
                }
            }
            return;
        }// end function

        public function IncAnyBuildingCount(param1:cBuilding) : void
        {
            var _loc_2:* = param1.GetBuildingName_string();
            if (isNaN(this.mCurrentlyBuildingsCount[_loc_2]))
            {
                this.mCurrentlyBuildingsCount[_loc_2] = 0;
            }
            (this.mCurrentlyBuildingsCount[_loc_2] + 1);
            return;
        }// end function

        public function GetPlayerName_string() : String
        {
            return this.mPlayerName_string;
        }// end function

        public function set mIsPlayerZone(param1:Boolean) : void
        {
            var _loc_2:* = this._1779503100mIsPlayerZone;
            if (_loc_2 !== param1)
            {
                this._1779503100mIsPlayerZone = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mIsPlayerZone", _loc_2, param1));
            }
            return;
        }// end function

        public function IsMaximumPlacedBuildingCountReached(param1:String) : Boolean
        {
            var _loc_5:cBuilding = null;
            var _loc_6:cBuilding = null;
            var _loc_7:int = 0;
            var _loc_8:int = 0;
            var _loc_2:* = this.mCurrentlyBuildingsCount[param1];
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            for each (_loc_5 in this.mBuildQueue.GetQueue_vector())
            {
                
                if (_loc_5.GetBuildingName_string() == param1)
                {
                    _loc_4++;
                }
                if (this.IsBuildingCounted(_loc_5.GetBuildingName_string()))
                {
                    _loc_3++;
                }
            }
            for each (_loc_6 in this.mPrePlacedBuildingCounter_vector)
            {
                
                if (_loc_6.GetBuildingName_string() == param1)
                {
                    _loc_4++;
                }
                if (this.IsBuildingCounted(_loc_6.GetBuildingName_string()))
                {
                    _loc_3++;
                }
            }
            _loc_2 = _loc_2 + _loc_4;
            _loc_7 = global.buildingGroup.GetNrFromName(param1);
            _loc_8 = global.buildingGroup.mGOList_vector[_loc_7].mMaxBuildingLimit;
            if (_loc_2 >= _loc_8)
            {
                return true;
            }
            if (this.IsBuildingCounted(param1))
            {
                if (this.mCurrentBuildingsCountAll >= this.mCurrentMaximumBuildingsCountAll)
                {
                    return true;
                }
            }
            return false;
        }// end function

        public function GetPlayerLevel() : int
        {
            return this.mPlayerLevel;
        }// end function

        public function SetUniqueID(param1:dUniqueID) : void
        {
            this.mUnique = param1;
            return;
        }// end function

        public function GetUniqueID() : dUniqueID
        {
            return this.mUnique;
        }// end function

        public function GetMaxBuildingCount() : int
        {
            return this.mCurrentMaximumBuildingsCountAll;
        }// end function

        public function GetBuildingCount(param1:String) : int
        {
            return this.mCurrentlyBuildingsCount[param1];
        }// end function

        public function GetPurchasedShopItemAmount(param1:int) : int
        {
            var _loc_3:dPurchasedShopItemVO = null;
            var _loc_2:int = 0;
            for each (_loc_3 in this.mPurchasedShopItems_vector)
            {
                
                if (_loc_3.shopItemID == param1 && _loc_3.giftedToPlayerId == 0)
                {
                    _loc_2++;
                }
            }
            return _loc_2;
        }// end function

        public function GetPrePlacesBuildingCounter() : int
        {
            return this.mPrePlacedBuildingCounter_vector.length;
        }// end function

        public function Init(param1:int) : void
        {
            this.mPlayerState = PLAYER_STATE_START_GAME;
            if (global.playerLevels_vector.length < (global.playerInitialLevel + 1))
            {
                this.mXP = global.playerLevels_vector[(global.playerLevels_vector.length - 1)];
            }
            else
            {
                this.mXP = global.playerLevels_vector[(global.playerInitialLevel - 1)];
            }
            this.mPlayerLevel = global.playerInitialLevel;
            this.mCurrentMaximumBuildingsCountAll = global.defaultMaximumBuildingsCountAll;
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            while (_loc_3 < global.cityLevels_vector.length)
            {
                
                if (global.cityLevels_vector[_loc_3] <= this.mXP)
                {
                    _loc_2 = _loc_3 + 1;
                }
                else
                {
                    break;
                }
                _loc_3++;
            }
            this.mCityLevel = _loc_2;
            this.mXPChanged = true;
            return;
        }// end function

        public function DecAnyBuildingCount(param1:cBuilding) : void
        {
            var _loc_2:* = param1.GetBuildingName_string();
            (this.mCurrentlyBuildingsCount[_loc_2] - 1);
            return;
        }// end function

        public function GetPlayerId() : int
        {
            return this.mPlayerId;
        }// end function

        public function AddXP(param1:int) : void
        {
            if (param1 == 0)
            {
                return;
            }
            if (this.mXP == 0 && this.GetHomeZoneId() != this.mGeneralInterface.mCurrentViewedZoneID)
            {
                this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.CREATED_BIT;
            }
            this.mXP = this.mXP + param1;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            while (_loc_3 < global.playerLevels_vector.length)
            {
                
                if (global.playerLevels_vector[_loc_3] <= this.mXP)
                {
                    _loc_2 = _loc_3 + 1;
                }
                else
                {
                    break;
                }
                _loc_3++;
            }
            var _loc_4:* = this.mPlayerLevel;
            this.mPlayerLevel = _loc_2;
            this.mPlayerListItem = null;
            if (this.mPlayerLevel >= global.playerLevels_vector.length)
            {
                this.mPlayerLevel = global.playerLevels_vector.length - 1;
                this.mXP = global.playerLevels_vector[this.mPlayerLevel];
                _loc_2 = this.mPlayerLevel;
            }
            _loc_2 = 0;
            var _loc_5:int = 0;
            while (_loc_5 < global.cityLevels_vector.length)
            {
                
                if (global.cityLevels_vector[_loc_5] <= this.mXP)
                {
                    _loc_2 = (_loc_5 + 1) == global.cityLevels_vector.length ? (_loc_5) : ((_loc_5 + 1));
                }
                else
                {
                    break;
                }
                _loc_5++;
            }
            if (_loc_2 > this.mCityLevel)
            {
                this.IncreaseCityLevelHandler(_loc_2);
            }
            this.mCityLevel = _loc_2;
            this.mXPChanged = true;
            return;
        }// end function

        public function GetSpecialistAmount(param1:int) : int
        {
            switch(param1)
            {
                case SPECIALIST_TYPE.GENERAL:
                {
                    return this.mGeneralsAmount;
                }
                case SPECIALIST_TYPE.EXPLORER:
                {
                    return this.mExplorersAmount;
                }
                case SPECIALIST_TYPE.GEOLOGIST:
                {
                    return this.mGeologistsAmount;
                }
                default:
                {
                    return 0;
                    continue;
                }
            }
        }// end function

        public function GetCityLevel() : int
        {
            return this.mCityLevel;
        }// end function

        public function SetPlayerId(param1:int) : void
        {
            this.mPlayerId = param1;
            return;
        }// end function

        public function SetSectorDiscovery(param1:int, param2:int) : void
        {
            var _loc_3:cSectorDiscovery = null;
            gMisc.Assert(param1 <= this.mDiscoveredSector_vector.length, "You can only add one new sector discovery!");
            if (param1 == this.mDiscoveredSector_vector.length)
            {
                _loc_3 = new cSectorDiscovery(param1, param2);
                _loc_3.mDirtyIndicator = _loc_3.mDirtyIndicator | DIRTY_INDICATOR.CREATED_BIT;
                this.mDiscoveredSector_vector.push(_loc_3);
            }
            else
            {
                _loc_3 = this.mDiscoveredSector_vector[param1];
                _loc_3.SetDiscoveryType(param2);
                _loc_3.mDirtyIndicator = _loc_3.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            }
            return;
        }// end function

        public function GetBuildingCountAll() : int
        {
            return this.mCurrentBuildingsCountAll;
        }// end function

        public function set mIsAdventureZone(param1:Boolean) : void
        {
            var _loc_2:* = this._1900481957mIsAdventureZone;
            if (_loc_2 !== param1)
            {
                this._1900481957mIsAdventureZone = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mIsAdventureZone", _loc_2, param1));
            }
            return;
        }// end function

        public function GetNewUniqueID() : dUniqueID
        {
            var _loc_2:* = this.mUnique;
            var _loc_3:* = this.mUnique.uniqueID1 + 1;
            _loc_2.uniqueID1 = _loc_3;
            if (this.mUnique.uniqueID1 == 0)
            {
                var _loc_2:* = this.mUnique;
                var _loc_3:* = this.mUnique.uniqueID2 + 1;
                _loc_2.uniqueID2 = _loc_3;
            }
            var _loc_1:* = new dUniqueID();
            _loc_1.uniqueID1 = this.mUnique.uniqueID1;
            _loc_1.uniqueID2 = this.mUnique.uniqueID2;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return _loc_1;
        }// end function

        public function CreatePlayerVOFromPlayer(param1:Boolean) : dPlayerVO
        {
            var _loc_3:cSectorDiscovery = null;
            var _loc_4:cBuff = null;
            var _loc_5:dSectorDiscoveryVO = null;
            var _loc_6:dBuffVO = null;
            var _loc_7:dPurchasedShopItemVO = null;
            var _loc_8:dTempBuildSlotVO = null;
            var _loc_2:* = new dPlayerVO();
            _loc_2.userID = this.GetPlayerId();
            _loc_2.username_string = this.GetPlayerName_string();
            _loc_2.playerLevel = this.GetPlayerLevel();
            _loc_2.uniqueID = this.mUnique;
            _loc_2.discoveredSectors = new ArrayCollection();
            for each (_loc_3 in this.mDiscoveredSector_vector)
            {
                
                _loc_5 = new dSectorDiscoveryVO();
                _loc_5.sectorID = _loc_3.GetSectorID();
                _loc_5.discoveryType = _loc_3.GetDiscoveryType();
                _loc_2.discoveredSectors.addItem(_loc_5);
            }
            for each (_loc_4 in this.mAvailableBuffs_vector)
            {
                
                _loc_6 = _loc_4.CreateBuffVOFromBuff();
                _loc_2.availableBuffs_vector.addItem(_loc_6);
            }
            if (!param1)
            {
                _loc_2.xp = this.GetXP();
                _loc_2.cityLevel = this.GetCityLevel();
                _loc_2.zoneID = this.GetHomeZoneId();
                _loc_2.avatarId = this.GetAvatarId();
                _loc_2.canCheat = this.getPlayerCanCheat();
                _loc_2.generalsAmount = this.GetSpecialistAmount(SPECIALIST_TYPE.GENERAL);
                _loc_2.explorersAmount = this.GetSpecialistAmount(SPECIALIST_TYPE.EXPLORER);
                _loc_2.geologistsAmount = this.GetSpecialistAmount(SPECIALIST_TYPE.GEOLOGIST);
                _loc_2.currentMaximumBuildingsCountAll = this.mCurrentMaximumBuildingsCountAll;
                _loc_2.permanentBuildQueueSlotsCount = this.mPermanentBuildQueueSlotsCount;
                for each (_loc_7 in this.mPurchasedShopItems_vector)
                {
                    
                    _loc_2.purchasedShopItems_vector.addItem(_loc_7);
                }
                for each (_loc_8 in this.mAvailableTempSlots_vector)
                {
                    
                    _loc_2.availableTempSlots_vector.addItem(_loc_8);
                }
            }
            else
            {
                _loc_2.zoneID = _loc_2.userID;
                _loc_2.avatarId = this.GetAvatarId();
            }
            _loc_2.logLevel = this.mLogLevel;
            _loc_2.logType = this.mLogTypeMask;
            _loc_2.logActions = this.mLogActions;
            return _loc_2;
        }// end function

        public function InitBaseData(param1:int, param2:String, param3:int, param4:int, param5:int, param6:int, param7:dUniqueID, param8:Boolean, param9:int, param10:int, param11:int, param12:int, param13:int, param14:int, param15:Boolean, param16:int) : cPlayerData
        {
            this.mPlayerId = param1;
            this.mPlayerName_string = param2;
            this.mXP = param3;
            this.mPlayerLevel = param4;
            this.mCityLevel = param5;
            this.mAvatarId = param6;
            this.mUnique = param7;
            this.mPlayerCanCheat = param8;
            this.mGeneralsAmount = param9;
            this.mExplorersAmount = param10;
            this.mGeologistsAmount = param11;
            this.mCurrentMaximumBuildingsCountAll = param12;
            this.mLogLevel = param13;
            this.mLogTypeMask = param14;
            this.mLogActions = param15;
            this.mPermanentBuildQueueSlotsCount = param16;
            return this;
        }// end function

        override public function toString() : String
        {
            return "<cPlayerData playerId=" + this.mPlayerId + " >";
        }// end function

        public function IncPermanentBuildSlotsAvailable(param1:int) : void
        {
            this.mPermanentBuildQueueSlotsCount = this.mPermanentBuildQueueSlotsCount + param1;
            this.mBuildQueue.ReadjustGridPositionsOfTempSlotsFrom(-1);
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            this.mBuildQueue.UpdateGUI();
            return;
        }// end function

        public function GetPlayerLogTypeMask() : int
        {
            return this.mLogTypeMask;
        }// end function

        public function GetPlayerLogLevel() : int
        {
            return this.mLogLevel;
        }// end function

        public function setLogPlayerActions(param1:Boolean) : void
        {
            this.mLogActions = param1;
            return;
        }// end function

        public function AddPrePlacesBuildingToList(param1:cBuilding) : void
        {
            this.mPrePlacedBuildingCounter_vector.push(param1);
            return;
        }// end function

        public function GetHomeZoneId() : int
        {
            return this.mPlayerId;
        }// end function

        public function IncMaxBuildingCount(param1:int) : void
        {
            this.mCurrentMaximumBuildingsCountAll = this.mCurrentMaximumBuildingsCountAll + param1;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function InitSectorDiscovery(param1:ArrayCollection) : void
        {
            var _loc_2:dSectorDiscoveryVO = null;
            for each (_loc_2 in param1)
            {
                
                this.mDiscoveredSector_vector.push(new cSectorDiscovery(_loc_2.sectorID, _loc_2.discoveryType));
            }
            return;
        }// end function

        public function SetPlayerLogLevel(param1:int) : void
        {
            if (param1 >= LOG_LEVEL.OFF && param1 <= LOG_LEVEL.FATAL)
            {
                this.mLogLevel = param1;
            }
            return;
        }// end function

        public function SetXPChanged() : void
        {
            (this.mGeneralInterface as cGameInterface).ResetResourceViewUpdate();
            this.mXPChanged = true;
            return;
        }// end function

        public function IncBuildingCount(param1:cBuilding) : void
        {
            if (param1.GetPlayerID() != this.GetPlayerId())
            {
                return;
            }
            var _loc_2:* = param1.GetBuildingName_string();
            if (isNaN(this.mCurrentlyBuildingsCount[_loc_2]))
            {
                this.mCurrentlyBuildingsCount[_loc_2] = 0;
            }
            (this.mCurrentlyBuildingsCount[_loc_2] + 1);
            return;
        }// end function

        public function isLogPlayerActionsEnabled() : Boolean
        {
            return this.mLogActions;
        }// end function

        public function GetPlayerListItem() : dPlayerListItemVO
        {
            if (this.mPlayerListItem != null)
            {
                return this.mPlayerListItem;
            }
            this.mPlayerListItem = new dPlayerListItemVO();
            this.mPlayerListItem.id = this.GetPlayerId();
            this.mPlayerListItem.avatarId = this.GetAvatarId();
            this.mPlayerListItem.username = this.GetPlayerName_string();
            this.mPlayerListItem.playerLevel = this.GetPlayerLevel();
            return this.mPlayerListItem;
        }// end function

        public function GetAvatarId() : int
        {
            return this.mAvatarId;
        }// end function

        public function get mIsAdventureZone() : Boolean
        {
            return this._1900481957mIsAdventureZone;
        }// end function

        public function IsMaximumBuildingCountReached(param1:String) : Boolean
        {
            var _loc_2:* = this.mCurrentlyBuildingsCount[param1];
            var _loc_3:* = global.buildingGroup.GetNrFromName(param1);
            var _loc_4:* = global.buildingGroup.mGOList_vector[_loc_3].mMaxBuildingLimit;
            if (_loc_2 >= _loc_4)
            {
                return true;
            }
            if (this.IsBuildingCounted(param1))
            {
                if (this.mCurrentBuildingsCountAll >= this.mCurrentMaximumBuildingsCountAll)
                {
                    return true;
                }
            }
            return false;
        }// end function

        public function GetXP() : int
        {
            return this.mXP;
        }// end function

        public function GetSectorDiscoveries_vector()
        {
            return this.mDiscoveredSector_vector;
        }// end function

        private function IncreaseCityLevelHandler(param1:int) : void
        {
            var _loc_4:cSector = null;
            (this.mGeneralInterface as cGameInterface).RefreshGui();
            var _loc_2:* = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.RecalculateStreetVariations(param1);
            var _loc_3:Boolean = false;
            for each (_loc_4 in this.mGeneralInterface.mCurrentPlayerZone.mSectorList_vector)
            {
                
                if (_loc_4.GetCityLevelAtWhichSectorIsActivated() > 0 && param1 >= _loc_4.GetCityLevelAtWhichSectorIsActivated())
                {
                    this.mGeneralInterface.mCurrentPlayerZone.SetFogForSector(_loc_4.GetSectorID());
                    this.SetSectorDiscovery(_loc_4.GetSectorID(), SECTOR_DISCOVERY_TYPE.EXPLORED);
                    _loc_3 = true;
                }
            }
            if (_loc_3)
            {
                this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.CalculateBorders();
            }
            if (_loc_2)
            {
                this.mGeneralInterface.mCurrentPlayerZone.SetBackgroundHasChanged(true);
            }
            return;
        }// end function

        public function CheckXPChanged() : Boolean
        {
            var _loc_1:* = this.mXPChanged;
            this.mXPChanged = false;
            return _loc_1;
        }// end function

        public function GetPermanentBuildQueueSlotsCount() : int
        {
            return this.mPermanentBuildQueueSlotsCount;
        }// end function

        public function SetAvatarId(param1:int) : void
        {
            this.mAvatarId = param1;
            return;
        }// end function

        public function IncBuildingCountAll(param1:cBuilding, param2:Boolean) : void
        {
            if (param1.GetPlayerID() != this.GetPlayerId())
            {
                return;
            }
            if (param1.mOrigin == cBuilding.BUILDING_ORIGIN_FROM_GAME)
            {
                if (this.IsBuildingCounted(param1.GetBuildingName_string()))
                {
                    var _loc_3:String = this;
                    var _loc_4:* = this.mCurrentBuildingsCountAll + 1;
                    _loc_3.mCurrentBuildingsCountAll = _loc_4;
                    if (this.mCurrentMaximumBuildingsCountAll == this.mCurrentBuildingsCountAll && param2)
                    {
                        globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.LAST_BUILDING_LICENSE_USED);
                    }
                    if (param2)
                    {
                        globalFlash.gui.mInfoBar.SetBuildingsCount(this.mCurrentBuildingsCountAll, this.mCurrentMaximumBuildingsCountAll);
                    }
                }
            }
            return;
        }// end function

        public function GetMaxXP() : int
        {
            return global.playerLevels_vector[(global.playerLevels_vector.length - 1)];
        }// end function

        public function IncSpecialistAmount(param1:int) : void
        {
            switch(param1)
            {
                case SPECIALIST_TYPE.GENERAL:
                {
                    var _loc_2:String = this;
                    var _loc_3:* = this.mGeneralsAmount + 1;
                    _loc_2.mGeneralsAmount = _loc_3;
                    break;
                }
                case SPECIALIST_TYPE.EXPLORER:
                {
                    var _loc_2:String = this;
                    var _loc_3:* = this.mExplorersAmount + 1;
                    _loc_2.mExplorersAmount = _loc_3;
                    break;
                }
                case SPECIALIST_TYPE.GEOLOGIST:
                {
                    var _loc_2:String = this;
                    var _loc_3:* = this.mGeologistsAmount + 1;
                    _loc_2.mGeologistsAmount = _loc_3;
                    break;
                }
                default:
                {
                    break;
                    break;
                }
            }
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function RefreshBuildingList() : void
        {
            var _loc_1:cBuilding = null;
            this.mPrePlacedBuildingCounter_vector.length = 0;
            this.mCurrentBuildingsCountAll = 0;
            this.mCurrentlyBuildingsCount = new Dictionary();
            for each (_loc_1 in this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.GetBuildings_vector())
            {
                
                if (_loc_1.GetPlayerID() == -1)
                {
                    this.IncAnyBuildingCount(_loc_1);
                    continue;
                }
                if (_loc_1.GetPlayerID() == this.GetPlayerId())
                {
                    if (_loc_1.GetBuildingMode() >= cBuilding.BUILDING_MODE_QUEUED)
                    {
                        this.IncBuildingCountAll(_loc_1, false);
                    }
                    if (_loc_1.GetBuildingMode() >= cBuilding.BUILDING_MODE_BUILDING_IS_ACTIVE_MIN)
                    {
                        this.IncBuildingCount(_loc_1);
                    }
                    if (_loc_1.GetBuildingMode() == cBuilding.BUILDING_MODE_PLACED)
                    {
                        this.AddPrePlacesBuildingToList(_loc_1);
                    }
                }
            }
            return;
        }// end function

        public function GetSectorDiscovery(param1:int) : int
        {
            return this.mDiscoveredSector_vector[param1].GetDiscoveryType();
        }// end function

        public function GetLastUpdate() : Number
        {
            return this.mLastUpdate;
        }// end function

        public function UpdateGridPositionForAvailableTempSlotsWith(param1:Number, param2:int) : void
        {
            var _loc_3:int = 0;
            while (_loc_3 < this.mAvailableTempSlots_vector.length)
            {
                
                if (this.mAvailableTempSlots_vector[_loc_3].timeOfPurchase == param1)
                {
                    this.mAvailableTempSlots_vector[_loc_3].buildingGridPos = param2;
                    return;
                }
                _loc_3++;
            }
            return;
        }// end function

        public function SetPlayerLogTypeMask(param1:int) : void
        {
            if (param1 >= LOG_TYPE.NONE && param1 <= LOG_TYPE.ALL)
            {
                this.mLogTypeMask = param1;
            }
            return;
        }// end function

        public function SetLastUpdate(param1:Number) : void
        {
            this.mLastUpdate = param1;
            return;
        }// end function

        public function getPlayerCanCheat() : Boolean
        {
            return this.mPlayerCanCheat;
        }// end function

        public function WillLevelUp(param1:int) : Boolean
        {
            return global.playerLevels_vector[this.mPlayerLevel] <= this.mXP + param1;
        }// end function

        public function SetPlayerName(param1:String) : void
        {
            this.mPlayerName_string = param1;
            return;
        }// end function

        public function GetSectorsAmount() : int
        {
            return this.mDiscoveredSector_vector.length;
        }// end function

        public function GetMissingXPForNextLevel() : int
        {
            return global.playerLevels_vector[this.mPlayerLevel] - this.mXP;
        }// end function

        public function IsBuildingCounted(param1:String) : Boolean
        {
            return !global.buildingDefaultParameterDoNotCountList_dictionary.Contains(param1);
        }// end function

        public function RemovePrePlacesBuildingToList(param1:cBuilding) : void
        {
            var _loc_2:int = 0;
            while (_loc_2 < this.mPrePlacedBuildingCounter_vector.length)
            {
                
                if (param1 == this.mPrePlacedBuildingCounter_vector[_loc_2])
                {
                    this.mPrePlacedBuildingCounter_vector.splice(_loc_2, 1);
                    break;
                }
                _loc_2++;
            }
            return;
        }// end function

        public function DecBuildingCount(param1:cBuilding) : void
        {
            if (param1.GetPlayerID() != this.GetPlayerId())
            {
                return;
            }
            var _loc_2:* = param1.GetBuildingName_string();
            (this.mCurrentlyBuildingsCount[_loc_2] - 1);
            return;
        }// end function

        public function GetRefundResourcesByReturnRate(param1:String)
        {
            var _loc_4:dResource = null;
            var _loc_5:dResource = null;
            var _loc_2:* = global.buildingGroup.GetCostListFromName_vector(param1);
            var _loc_3:* = new Vector.<dResource>;
            if (_loc_2 == null)
            {
                return _loc_3;
            }
            for each (_loc_4 in _loc_2)
            {
                
                _loc_5 = new dResource();
                _loc_5.amount = _loc_4.amount * global.returnRate / 100;
                _loc_5.group_string = _loc_4.group_string;
                _loc_5.maxLimit = _loc_4.maxLimit;
                _loc_5.name_string = _loc_4.name_string;
                _loc_3.push(_loc_5);
            }
            return _loc_3;
        }// end function

        public function SetPlayerCanCheat(param1:Boolean) : void
        {
            this.mPlayerCanCheat = param1;
            return;
        }// end function

    }
}
