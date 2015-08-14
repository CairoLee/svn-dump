package ServerOnly
{
    import BuffSystem.*;
    import Communication.VO.*;
    import Communication.VO.UpdateVO.*;
    import Enums.*;
    import GO.*;
    import Interface.*;
    import LootTableSystem.*;
    import Map.*;
    import ServerState.*;
    import ShopSystem.*;
    import Specialists.*;
    import TimedProduction.*;
    import __AS3__.vec.*;
    import mx.collections.*;
    import nLib.*;

    public class cServerOnly extends Object
    {
        public const mDepositQualities_vector:Vector.<cDepositQuality>;
        public const mDepositGroups_vector:Vector.<cDepositGroup>;
        private var mGeneralInterface:cGeneralInterface = null;

        public function cServerOnly(param1:cGeneralInterface)
        {
            this.mDepositGroups_vector = new Vector.<cDepositGroup>;
            this.mDepositQualities_vector = new Vector.<cDepositQuality>;
            this.mGeneralInterface = param1;
            return;
        }// end function

        public function InitCreatedAlwaysProduction(param1:int, param2:int) : void
        {
            var _loc_3:dResourceCreationDefinition = null;
            var _loc_4:cResourceCreation = null;
            for each (_loc_3 in gEconomics.mResourceCreationDefinition_vector)
            {
                
                if (_loc_3.typeEnumResourceType == RESOURCE_TYPE.CREATED_ALWAYS)
                {
                    _loc_4 = new cResourceCreation(param1, _loc_3, null);
                    new cResourceCreation(param1, _loc_3, null).mDirtyIndicator = _loc_4.mDirtyIndicator | DIRTY_INDICATOR.CREATED_BIT;
                    this.mGeneralInterface.mComputeResourceCreation.mResourceCreation_vector.push(_loc_4);
                }
            }
            return;
        }// end function

        public function CreateZoneVO(param1:int) : dZoneVO
        {
            return this.CreateZoneVOLocal(param1, false);
        }// end function

        public function ExploreNewSector(param1:cPlayerData) : cSector
        {
            var _loc_3:cSector = null;
            var _loc_7:int = 0;
            var _loc_8:int = 0;
            if (this.mGeneralInterface.mLog.isDebugEnabled(LOG_TYPE.SPECIALIST))
            {
                this.mGeneralInterface.mLog.logDebug(LOG_TYPE.SPECIALIST, "ExploreNewSector(...)");
            }
            var _loc_2:cSector = null;
            var _loc_4:int = -1;
            var _loc_5:* = param1.GetPlayerId();
            var _loc_6:* = new Vector.<int>;
            for each (_loc_3 in this.mGeneralInterface.mCurrentPlayerZone.mSectorList_vector)
            {
                
                if (_loc_3.GetOwnerPlayerID() == _loc_5 || _loc_3.GetOwnerPlayerID() == 0 && param1.GetSectorDiscovery(_loc_3.GetSectorID()) == SECTOR_DISCOVERY_TYPE.EXPLORED)
                {
                    for each (_loc_7 in _loc_3.mAdjactedSectorIds_vector)
                    {
                        
                        if (_loc_7 > 0 && _loc_6.indexOf(_loc_7) == -1)
                        {
                            _loc_6.push(_loc_7);
                        }
                    }
                }
            }
            if (this.mGeneralInterface.mLog.isDebugEnabled(LOG_TYPE.SPECIALIST))
            {
                _loc_8 = _loc_6.length;
                this.mGeneralInterface.mLog.logDebug(LOG_TYPE.SPECIALIST, "Found " + _loc_8 + " reachable sectors: " + _loc_6);
            }
            for each (_loc_3 in this.mGeneralInterface.mCurrentPlayerZone.mSectorList_vector)
            {
                
                if (_loc_6.indexOf(_loc_3.GetSectorID()) != -1 && param1.GetSectorDiscovery(_loc_3.GetSectorID()) == SECTOR_DISCOVERY_TYPE.UNEXPLORED)
                {
                    if (_loc_3.GetExplorePriority() > _loc_4)
                    {
                        _loc_2 = _loc_3;
                        _loc_4 = _loc_3.GetExplorePriority();
                    }
                    continue;
                }
                if (this.mGeneralInterface.mLog.isDebugEnabled(LOG_TYPE.SPECIALIST))
                {
                    if (_loc_6.indexOf(_loc_3.GetSectorID()) == -1)
                    {
                        this.mGeneralInterface.mLog.logDebug(LOG_TYPE.SPECIALIST, "Could not explore " + _loc_3 + ", because it is not reachable.");
                        continue;
                    }
                    if (param1.GetSectorDiscovery(_loc_3.GetSectorID()) != SECTOR_DISCOVERY_TYPE.UNEXPLORED)
                    {
                        this.mGeneralInterface.mLog.logDebug(LOG_TYPE.SPECIALIST, "Could not explore " + _loc_3 + ", because it\'s discovery type is " + SECTOR_DISCOVERY_TYPE.toString(param1.GetSectorDiscovery(_loc_3.GetSectorID())));
                    }
                }
            }
            if (this.mGeneralInterface.mLog.isDebugEnabled(LOG_TYPE.SPECIALIST))
            {
                this.mGeneralInterface.mLog.logDebug(LOG_TYPE.SPECIALIST, "Explored sector " + _loc_2);
            }
            return _loc_2;
        }// end function

        private function ChooseNextAccessibleDeposit(param1:cDepositGroup) : cDeposit
        {
            var _loc_2:int = 0;
            var _loc_3:cDeposit = null;
            var _loc_8:cDeposit = null;
            if (this.mGeneralInterface.mLog.isDebugEnabled(LOG_TYPE.SPECIALIST))
            {
                this.mGeneralInterface.mLog.logDebug(LOG_TYPE.SPECIALIST, "ChooseNextAccessibleDeposit(" + param1 + ")");
            }
            var _loc_4:* = new Vector.<cDeposit>;
            var _loc_5:* = gMisc.GetMaxIntValue();
            var _loc_6:int = 0;
            for each (_loc_2 in param1.GetDepositGridIdxs_vector())
            {
                
                _loc_3 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_2].mDeposit;
                if (_loc_3.GetAccessibleType() == DEPOSIT_ACCESSIBLE_TYPES.NOT_ACCESSIBLE)
                {
                    _loc_4.push(_loc_3);
                    if (_loc_3.GetEmptied() < _loc_5)
                    {
                        _loc_5 = _loc_3.GetEmptied();
                    }
                    continue;
                }
                _loc_6++;
            }
            if (_loc_6 >= param1.GetMaxAccessible())
            {
                return null;
            }
            var _loc_7:* = new Vector.<cDeposit>;
            for each (_loc_8 in _loc_4)
            {
                
                if (_loc_8.GetEmptied() == _loc_5)
                {
                    _loc_7.push(_loc_8);
                }
            }
            if (_loc_7.length == 0)
            {
                return null;
            }
            var _loc_9:* = _loc_7[gMisc.GetRandomMinMaxInt(0, (_loc_7.length - 1))];
            return _loc_7[gMisc.GetRandomMinMaxInt(0, (_loc_7.length - 1))];
        }// end function

        public function CreateGenericZoneVO(param1:int) : dZoneVO
        {
            return this.CreateZoneVOLocal(param1, true);
        }// end function

        private function AddContentToInventory(param1:cPlayerData, param2:int, param3:cItemContent) : ArrayCollection
        {
            var _loc_4:cBuff = null;
            var _loc_5:cBuffDefinition = null;
            var _loc_6:int = 0;
            var _loc_8:dResourceVO = null;
            var _loc_9:cSpecialist = null;
            var _loc_7:* = new ArrayCollection();
            switch(param3.GetType())
            {
                case ITEM_CONTENT_TYPE.BUFF:
                {
                    _loc_5 = global.map_BuffName_BuffDefinition[param3.GetName_string()];
                    gMisc.Assert(_loc_5 != null, "Buffdefinition \'" + param3 + "\' does not exist!");
                    _loc_4 = new cBuff(_loc_5, param1.GetNewUniqueID(), 0);
                    _loc_4.SetResourceName(param3.GetResourceName_string());
                    _loc_4.SetAmount(param3.GetCount());
                    _loc_4.SetRemaining(_loc_4.GetAmount());
                    _loc_4.SetRecurrentChance(param3.GetRecurringChance());
                    _loc_7.addItem(_loc_4.CreateBuffVOFromBuff());
                    break;
                }
                case ITEM_CONTENT_TYPE.RESOURCE:
                {
                    _loc_5 = global.map_BuffName_BuffDefinition["AddResource"];
                    gMisc.Assert(_loc_5 != null, "Buffdefinition AddResource \'" + param3 + "\' does not exist!");
                    _loc_4 = new cBuff(_loc_5, param1.GetNewUniqueID(), 0);
                    _loc_4.SetResourceName(param3.GetResourceName_string());
                    _loc_4.SetAmount(param3.GetCount());
                    _loc_4.SetRemaining(_loc_4.GetAmount());
                    _loc_4.SetRecurrentChance(param3.GetRecurringChance());
                    _loc_7.addItem(_loc_4.CreateBuffVOFromBuff());
                    break;
                }
                case ITEM_CONTENT_TYPE.BUILDING:
                {
                    _loc_5 = global.map_BuffName_BuffDefinition["BuildBuilding"];
                    gMisc.Assert(_loc_5 != null, "Buffdefinition BuildBuilding \'" + param3 + "\' does not exist!");
                    _loc_4 = new cBuff(_loc_5, param1.GetNewUniqueID(), 0);
                    _loc_4.SetResourceName(param3.GetResourceName_string());
                    _loc_4.SetAmount(param3.GetCount());
                    _loc_4.SetRemaining(_loc_4.GetAmount());
                    _loc_4.SetRecurrentChance(param3.GetRecurringChance());
                    _loc_7.addItem(_loc_4.CreateBuffVOFromBuff());
                    break;
                }
                case ITEM_CONTENT_TYPE.SPECIALIST:
                {
                    _loc_6 = 0;
                    while (_loc_6 < param3.GetCount())
                    {
                        
                        _loc_9 = new cSpecialist(false).InitSpecialistFromType(SPECIALIST_TYPE.parse(param3.GetName_string()), param1.GetNewUniqueID(), param1.GetPlayerId(), param2);
                        _loc_7.addItem(_loc_9.CreateSpecialistVOFromSpecialist());
                        _loc_6++;
                    }
                    break;
                }
                case ITEM_CONTENT_TYPE.ADVENTURE:
                {
                    _loc_7.addItem(param3.GetName_string());
                    break;
                }
                case ITEM_CONTENT_TYPE.XP:
                {
                    _loc_8 = new dResourceVO();
                    _loc_8.name_string = "XP";
                    _loc_8.amount = param3.GetCount();
                    _loc_7.addItem(_loc_8);
                    break;
                }
                case ITEM_CONTENT_TYPE.NOTHING:
                {
                    break;
                }
                default:
                {
                    gMisc.Assert(false, "Could not interpret item content type " + param3.GetType() + "!");
                    break;
                    break;
                }
            }
            return _loc_7;
        }// end function

        public function CreateZoneVOLocal(param1:int, param2:Boolean) : dZoneVO
        {
            var _loc_5:cBuilding = null;
            var _loc_6:cSector = null;
            var _loc_7:cResources = null;
            var _loc_8:cSpecialist = null;
            var _loc_9:cDataTrackingItem = null;
            var _loc_10:cGO = null;
            var _loc_11:cFreeLandscape = null;
            var _loc_12:cLandingField = null;
            var _loc_13:cResourceCreation = null;
            var _loc_14:cDeposit = null;
            var _loc_15:cStreet = null;
            var _loc_16:String = null;
            var _loc_17:cTimedProduction = null;
            var _loc_18:cTimedProduction = null;
            var _loc_19:int = 0;
            var _loc_20:int = 0;
            var _loc_21:int = 0;
            var _loc_22:dGameTickCommandVO = null;
            var _loc_23:cPlayerData = null;
            var _loc_24:dPlayerVO = null;
            var _loc_25:cPlayerData = null;
            var _loc_26:dPlayerVO = null;
            var _loc_27:cLandscape = null;
            var _loc_28:cBuilding = null;
            var _loc_29:int = 0;
            var _loc_30:cIsoElement = null;
            var _loc_31:dMapValueItemVO = null;
            var _loc_32:String = null;
            var _loc_33:dBackgroundTileVO = null;
            var _loc_3:* = new dZoneVO();
            _loc_3.zoneMapName = this.mGeneralInterface.mZoneMapName;
            _loc_3.questFileName = this.mGeneralInterface.mQuestFileName;
            if (this.mGeneralInterface.mCurrentPlayerZone.mAdventure != null)
            {
                _loc_3.adventureName = this.mGeneralInterface.mCurrentPlayerZone.mAdventure.GetName_string();
            }
            else
            {
                _loc_3.adventureName = null;
            }
            _loc_3.serverTime = this.mGeneralInterface.GetClientTime();
            _loc_3.lastGameTickRefreshTime = this.mGeneralInterface.mLastGameTickRefreshClientTime;
            var _loc_4:* = this.mGeneralInterface.FindPlayerFromId(param1);
            _loc_3.zoneVisitorPlayerID = param1;
            _loc_3.zoneOwnerPlayerID = this.mGeneralInterface.mHomePlayer.GetPlayerId();
            this.UpdateDiscoveredSectorsForPlayer(_loc_4, param1);
            _loc_3.buildQueue = new dBuildQueueVO();
            _loc_3.buildQueue.maxCount = _loc_4.mBuildQueue.GetMaxCount();
            _loc_3.buildQueue.permanentSlotsCount = _loc_4.GetPermanentBuildQueueSlotsCount();
            for each (_loc_5 in _loc_4.mBuildQueue.GetQueue_vector())
            {
                
                _loc_3.buildQueue.buildings.addItem(_loc_5.CreateBuildingVOFromBuilding());
            }
            for each (_loc_6 in this.mGeneralInterface.mCurrentPlayerZone.mSectorList_vector)
            {
                
                _loc_3.sectors.addItem(_loc_6.CreateSectorVOFromSector());
            }
            if (_loc_3.zoneVisitorPlayerID == _loc_3.zoneOwnerPlayerID)
            {
                for each (_loc_23 in this.mGeneralInterface.GetPlayerList_vector())
                {
                    
                    _loc_24 = _loc_23.CreatePlayerVOFromPlayer(false);
                    _loc_3.playersOnMap.addItem(_loc_24);
                }
            }
            else
            {
                for each (_loc_25 in this.mGeneralInterface.GetPlayerList_vector())
                {
                    
                    if (_loc_3.zoneVisitorPlayerID == _loc_25.GetPlayerId())
                    {
                        _loc_26 = _loc_25.CreatePlayerVOFromPlayer(false);
                    }
                    else
                    {
                        _loc_26 = _loc_25.CreatePlayerVOFromPlayer(true);
                    }
                    _loc_3.playersOnMap.addItem(_loc_26);
                }
            }
            _loc_7 = this.mGeneralInterface.mCurrentPlayerZone.GetResources(_loc_4);
            if (_loc_7 != null)
            {
                _loc_3.resourcesVO = _loc_7.CreateResourcesVO();
            }
            for each (_loc_8 in this.mGeneralInterface.mCurrentPlayerZone.GetSpecialists_vector())
            {
                
                _loc_3.specialists_vector.addItem(_loc_8.CreateSpecialistVOFromSpecialist());
            }
            for each (_loc_9 in this.mGeneralInterface.mDataTracking.GetTrackingValues())
            {
                
                _loc_3.dataTracking_vector.addItem(_loc_9.CreateVO());
            }
            for each (_loc_10 in this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.GetBuildingsAndLandscape_vector())
            {
                
                if (_loc_10.GetLevelEnumObjectType() == OBJECTTYPE.LANDSCAPE)
                {
                    _loc_27 = _loc_10 as cLandscape;
                    _loc_3.landscapes.addItem(_loc_27.CreateLandscapeVOFromLandscape());
                    continue;
                }
                _loc_28 = _loc_10 as cBuilding;
                _loc_3.buildings.addItem(_loc_28.CreateBuildingVOFromBuilding());
            }
            for each (_loc_11 in this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mFreeLandscape_vector)
            {
                
                _loc_3.freeLandscapes.addItem(_loc_11.CreateVO());
            }
            for each (_loc_12 in this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mLandingFields_vector)
            {
                
                _loc_3.landingFields.addItem(_loc_12.CreateVO());
            }
            for each (_loc_13 in this.mGeneralInterface.mComputeResourceCreation.mResourceCreation_vector)
            {
                
                _loc_3.resourceCreations.addItem(_loc_13.CreateResourceCreationVOFromResourceCreation());
            }
            for each (_loc_14 in this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.GetDeposits_vector())
            {
                
                if (_loc_14.GetAccessibleType() == DEPOSIT_ACCESSIBLE_TYPES.ACCESSIBLE || param2)
                {
                    _loc_3.deposits.addItem(_loc_14.CreateDepositVOFromDeposit());
                }
            }
            for each (_loc_15 in this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.GetStreets_vector())
            {
                
                _loc_3.streets.addItem(_loc_15.CreateStreetVOFromStreet());
            }
            for (_loc_16 in this.mGeneralInterface.mCurrentPlayerZone.map_PlayerID_Army)
            {
                
                _loc_29 = gMisc.ParseInt(_loc_16);
                _loc_3.map_PlayerID_Army[_loc_29] = this.mGeneralInterface.mCurrentPlayerZone.GetArmy(_loc_29).CreateArmyVO();
            }
            for each (_loc_17 in this.mGeneralInterface.mCurrentPlayerZone.GetMilitaryUnitRecruitments().mTimedProductions_vector)
            {
                
                _loc_3.militaryUnitRecruitments_vector.addItem(_loc_17.CreateTimedProductionVO());
            }
            for each (_loc_18 in this.mGeneralInterface.mCurrentPlayerZone.GetBuffProductionQueue().mTimedProductions_vector)
            {
                
                _loc_3.buffProduction_vector.addItem(_loc_18.CreateTimedProductionVO());
            }
            _loc_21 = 0;
            _loc_20 = defines.STREET_MAP_MIN_USABLE_AREA_Y;
            while (_loc_20 <= defines.STREET_MAP_MAX_USABLE_AREA_Y)
            {
                
                _loc_21 = (_loc_20 << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + defines.STREET_MAP_MIN_USABLE_AREA_X;
                _loc_19 = defines.STREET_MAP_MIN_USABLE_AREA_X;
                while (_loc_19 <= defines.STREET_MAP_MAX_USABLE_AREA_X)
                {
                    
                    _loc_30 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_21];
                    _loc_31 = new dMapValueItemVO();
                    _loc_31.mBackgroundBlocking = _loc_30.GetBackgroundBlocking();
                    _loc_31.mSectorId = _loc_30.mSectorId;
                    _loc_3.mapValues.addItem(_loc_31);
                    _loc_21++;
                    _loc_19++;
                }
                _loc_20++;
            }
            _loc_21 = 0;
            _loc_20 = 0;
            while (_loc_20 < defines.RECTANGLE_MAP_HEIGHT)
            {
                
                _loc_19 = 0;
                while (_loc_19 < defines.RECTANGLE_MAP_WIDTH)
                {
                    
                    _loc_32 = this.mGeneralInterface.mCurrentPlayerZone.mBackgroundDataMap.GetNameFromGrid_string(_loc_21);
                    _loc_33 = new dBackgroundTileVO();
                    if (_loc_32 != null)
                    {
                        _loc_33.name_string = _loc_32;
                    }
                    _loc_3.backgroundTiles.addItem(_loc_33);
                    _loc_21++;
                    _loc_19++;
                }
                _loc_20++;
            }
            for each (_loc_22 in this.mGeneralInterface.mGameTickCommand_vector)
            {
                
                (_loc_35[_loc_34]).time = _loc_22.time + defines.GAMETICK_PERIODIC_ZONE_REFRESH_TOLERANCE_TIME * this.mGeneralInterface.mGlobalTimeScale;
                _loc_3.gameTickCommands_vector.addItem(_loc_22);
            }
            _loc_3.gameTickRefreshCounter = this.mGeneralInterface.mGameTickRefreshCounter;
            return _loc_3;
        }// end function

        public function UpdateDiscoveredSectorsForPlayer(param1:cPlayerData, param2:int) : void
        {
            var _loc_3:int = 0;
            if (param2 != this.mGeneralInterface.mHomePlayer.GetPlayerId())
            {
                if (!this.mGeneralInterface.IsAdventureZoneID(this.mGeneralInterface.mCurrentViewedZoneID))
                {
                    _loc_3 = 0;
                    while (_loc_3 < param1.GetSectorsAmount())
                    {
                        
                        param1.SetSectorDiscovery(_loc_3, this.mGeneralInterface.mHomePlayer.GetSectorDiscovery(_loc_3));
                        _loc_3++;
                    }
                }
                this.mGeneralInterface.FindPlayerFromId(param2).mIsPlayerZone = false;
            }
            else
            {
                this.mGeneralInterface.FindPlayerFromId(param2).mIsPlayerZone = true;
            }
            return;
        }// end function

        public function CalculateLootTables_vector(param1:int, param2:int, param3:cPlayerData)
        {
            var _loc_7:cLootTable = null;
            var _loc_8:int = 0;
            var _loc_9:cLootTable = null;
            var _loc_4:* = global.lootTableGroups_vector[param1];
            var _loc_5:* = new Vector.<cLootTable>;
            var _loc_6:* = new Vector.<cLootTable>;
            for each (_loc_7 in _loc_4)
            {
                
                if (param3.GetPlayerLevel() >= _loc_7.GetPlayerLevelMin() && param3.GetPlayerLevel() <= _loc_7.GetPlayerLevelMax())
                {
                    if (_loc_7.GetMinContribution() < 0)
                    {
                        _loc_5.push(_loc_7);
                        continue;
                    }
                    _loc_8 = 0;
                    while (_loc_8 < _loc_6.length)
                    {
                        
                        _loc_9 = _loc_6[_loc_8];
                        if (_loc_9.GetMinContribution() > _loc_7.GetMinContribution())
                        {
                            break;
                        }
                        _loc_8++;
                    }
                    _loc_6.splice(_loc_8, 0, _loc_7);
                }
            }
            for each (_loc_7 in _loc_6)
            {
                
                gMisc.ConsoleOut(_loc_7.toString());
            }
            return _loc_5;
        }// end function

        public function AddTreasure(param1:cPlayerData, param2:int, param3:cLootTable, param4:ArrayCollection) : void
        {
            var _loc_7:cLootTableItemContent = null;
            var _loc_8:int = 0;
            var _loc_9:int = 0;
            var _loc_10:String = null;
            var _loc_11:int = 0;
            var _loc_12:cLootTableItemContent = null;
            var _loc_5:int = 0;
            var _loc_6:* = new Object();
            for each (_loc_7 in param3.mItemContents_vector)
            {
                
                if (_loc_7.GetPrio() > 0)
                {
                    _loc_5 = _loc_5 + _loc_7.GetPrio();
                    _loc_6[_loc_5] = _loc_7;
                    continue;
                }
                param4.addAll(this.AddContentToInventory(param1, param2, _loc_7));
            }
            _loc_8 = 0;
            while (_loc_8 < param3.GetChanceItemsAmount())
            {
                
                _loc_9 = gMisc.GetRandomMinMaxInt(1, _loc_5);
                for (_loc_10 in _loc_6)
                {
                    
                    _loc_11 = gMisc.ParseInt(_loc_10);
                    if (_loc_9 <= _loc_11)
                    {
                        _loc_12 = _loc_6[_loc_11] as cLootTableItemContent;
                        param4.addAll(this.AddContentToInventory(param1, param2, _loc_12));
                        break;
                    }
                }
                _loc_8++;
            }
            return;
        }// end function

        public function AddShopItemContentToInventory(param1:cPlayerData, param2:int, param3:cShopItem) : ArrayCollection
        {
            var _loc_5:cItemContent = null;
            var _loc_4:* = new ArrayCollection();
            for each (_loc_5 in param3.GetShopItemContent_vector())
            {
                
                _loc_4.addAll(this.AddContentToInventory(param1, param2, _loc_5));
            }
            return _loc_4;
        }// end function

        public function FindNewDeposit(param1:String, param2:cSpecialist, param3:dFoundDepositVO) : void
        {
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            var _loc_8:cDepositGroup = null;
            var _loc_12:int = 0;
            var _loc_13:int = 0;
            var _loc_14:int = 0;
            var _loc_15:int = 0;
            var _loc_16:int = 0;
            var _loc_17:int = 0;
            var _loc_18:cDepositQuality = null;
            if (this.mGeneralInterface.mLog.isDebugEnabled(LOG_TYPE.SPECIALIST))
            {
                this.mGeneralInterface.mLog.logDebug(LOG_TYPE.SPECIALIST, "FindNewDeposit(" + param1 + ", " + param2 + ")");
            }
            var _loc_4:cDeposit = null;
            var _loc_5:* = EXPLORED_DEPOSIT_RESULT.FOUND;
            var _loc_9:* = new Vector.<cDeposit>;
            var _loc_10:* = new Vector.<cDepositGroup>;
            for each (_loc_8 in this.mDepositGroups_vector)
            {
                
                if (_loc_8.GetDepositGridIdxs_vector().length > 0)
                {
                    _loc_12 = _loc_8.GetDepositGridIdxs_vector()[0];
                    _loc_6 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_12].mSectorId;
                    _loc_7 = this.mGeneralInterface.mCurrentPlayerZone.mSectorList_vector[_loc_6].GetOwnerPlayerID();
                    if (_loc_8.GetDepositType_string() == param1 && _loc_7 == param2.GetPlayerID())
                    {
                        _loc_4 = this.ChooseNextAccessibleDeposit(_loc_8);
                        if (_loc_4 != null)
                        {
                            _loc_9.push(_loc_4);
                            _loc_10.push(_loc_8);
                            continue;
                        }
                        _loc_5 = EXPLORED_DEPOSIT_RESULT.ALL_DEPOSITS_ACCESSIBLE;
                    }
                }
            }
            if (this.mGeneralInterface.mLog.isDebugEnabled(LOG_TYPE.SPECIALIST))
            {
                _loc_13 = _loc_9.length;
                this.mGeneralInterface.mLog.logDebug(LOG_TYPE.SPECIALIST, "Found " + _loc_13 + " possible deposits: " + _loc_9);
            }
            var _loc_11:cDepositGroup = null;
            if (_loc_9.length > 0)
            {
                _loc_14 = gMisc.GetRandomMinMaxInt(0, (_loc_9.length - 1));
                _loc_4 = _loc_9[_loc_14];
                _loc_11 = _loc_10[_loc_14];
            }
            else
            {
                if (_loc_5 == EXPLORED_DEPOSIT_RESULT.FOUND)
                {
                    _loc_5 = EXPLORED_DEPOSIT_RESULT.NO_DEPOSIT_IN_SECTORS;
                }
                param3.depositVO = null;
                param3.exploredDepositResult = _loc_5;
                return;
            }
            if (_loc_4 != null)
            {
                _loc_15 = _loc_11.GetAverageAmount();
                _loc_16 = gMisc.GetRandomMinMaxInt(1, 100) + param2.GetDiceBonus();
                _loc_17 = 0;
                for each (_loc_18 in this.mDepositQualities_vector)
                {
                    
                    if (_loc_16 >= _loc_18.GetDiceThrow())
                    {
                        _loc_17 = _loc_18.GetDepositBonus();
                        gErrorMessages.TraceInfo("Found " + _loc_4.GetName_string() + "-deposit with " + _loc_17 + "% bonus to average amount.");
                        break;
                    }
                }
                _loc_15 = _loc_15 + _loc_15 * _loc_17 / 100;
                _loc_4.SetAmount(_loc_15);
                _loc_4.SetMaxAmount(_loc_15);
                _loc_4.SetAccessibleType(DEPOSIT_ACCESSIBLE_TYPES.RESERVED);
            }
            if (this.mGeneralInterface.mLog.isDebugEnabled(LOG_TYPE.SPECIALIST))
            {
                this.mGeneralInterface.mLog.logDebug(LOG_TYPE.SPECIALIST, "depositToMakeAccessible=" + _loc_4);
            }
            param3.depositVO = _loc_4.CreateDepositVOFromDeposit();
            param3.exploredDepositResult = EXPLORED_DEPOSIT_RESULT.FOUND;
            return;
        }// end function

    }
}
