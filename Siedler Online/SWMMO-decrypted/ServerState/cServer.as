package ServerState
{
    import AdventureSystem.*;
    import BuffSystem.*;
    import Communication.VO.*;
    import Enums.*;
    import GO.*;
    import Interface.*;
    import Map.*;
    import MilitarySystem.*;
    import NewQuestSystem.*;
    import Specialists.*;
    import TimedProduction.*;
    import __AS3__.vec.*;
    import nLib.*;

    public class cServer extends Object
    {
        private var mServerInitialized:Boolean = false;
        private var mGeneralInterface:cGeneralInterface = null;

        public function cServer(param1:cGeneralInterface)
        {
            this.mGeneralInterface = param1;
            return;
        }// end function

        public function CreateDepositGroupFromDepositGroupVO(param1:dDepositGroupVO) : void
        {
            var _loc_3:int = 0;
            var _loc_2:* = new cDepositGroup(this.mGeneralInterface, param1.mId, param1.mMaxAccessible, param1.mAverageAmount, param1.mUbiRandom, param1.mDepositType_string);
            for each (_loc_3 in param1.mDepositsVector)
            {
                
                _loc_2.AddDepositGridIdx(_loc_3);
            }
            this.mGeneralInterface.mServerOnly.mDepositGroups_vector.push(_loc_2);
            return;
        }// end function

        public function CreateLandingFieldFromLandingFieldVO(param1:dLandingFieldVO) : void
        {
            var _loc_2:* = new cLandingField();
            _loc_2.mGrid = param1.grid;
            _loc_2.mId = param1.id;
            this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mLandingFields_vector.push(_loc_2);
            return;
        }// end function

        public function RefreshZoneLocal(param1:dZoneVO, param2:dQuestDefinitionContainerVO, param3:Boolean, param4:Boolean, param5:Boolean, param6:Boolean, param7:int, param8:int) : void
        {
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            var _loc_11:int = 0;
            var _loc_13:cPlayerData = null;
            var _loc_14:dSectorVO = null;
            var _loc_15:cResources = null;
            var _loc_16:cArmy = null;
            var _loc_17:String = null;
            var _loc_18:dTimedProductionVO = null;
            var _loc_19:dTimedProductionVO = null;
            var _loc_20:dBuildingVO = null;
            var _loc_21:dLandscapeVO = null;
            var _loc_22:dDepositVO = null;
            var _loc_23:dStreetVO = null;
            var _loc_24:dFreeLandscapeVO = null;
            var _loc_25:dLandingFieldVO = null;
            var _loc_27:dResourceCreationVO = null;
            var _loc_28:dSpecialistVO = null;
            var _loc_29:int = 0;
            var _loc_30:dDataTrackingVO = null;
            var _loc_31:dGameTickCommandVO = null;
            var _loc_32:dGameTickCommandVO = null;
            var _loc_33:dPlayerVO = null;
            var _loc_34:cPlayerData = null;
            var _loc_35:cPlayerData = null;
            var _loc_36:cPlayerData = null;
            var _loc_37:cBuff = null;
            var _loc_38:cBuff = null;
            var _loc_39:int = 0;
            var _loc_40:int = 0;
            var _loc_41:dArmyVO = null;
            var _loc_42:cArmy = null;
            var _loc_43:dSquadVO = null;
            var _loc_44:cTimedProduction = null;
            var _loc_45:cTimedProduction = null;
            var _loc_46:cIsoElement = null;
            var _loc_47:dMapValueItemVO = null;
            var _loc_48:dBackgroundTileVO = null;
            var _loc_49:cBackground = null;
            var _loc_50:cAdventureDefinition = null;
            var _loc_51:cSpecialist = null;
            var _loc_52:dUniqueID = null;
            var _loc_53:Vector.<cBuff> = null;
            var _loc_54:cBuff = null;
            var _loc_55:int = 0;
            var _loc_12:* = new Vector.<cPlayerData>;
            if (gGfxResource.SetFilter(null, FILTER_SOURCE.REFRESH_ZONE))
            {
                gGfxResource.ApplyZoom(this.mGeneralInterface.mZoom.GetInvScaleFactor());
                this.mGeneralInterface.mCurrentPlayerZone.SetBackgroundHasChanged(true);
                this.mGeneralInterface.mCurrentPlayerZone.SetAllRescaleDirtyFlags();
            }
            for each (_loc_13 in this.mGeneralInterface.GetPlayerList_vector())
            {
                
                _loc_12.push(_loc_13);
            }
            this.mGeneralInterface.mRefreshZoneIsActive = true;
            if (param3)
            {
                this.mGeneralInterface.ClearLevelOnTheFly();
            }
            else
            {
                this.mGeneralInterface.ClearLevel();
            }
            this.mGeneralInterface.mCurrentViewedZoneID = param7;
            if (!param6)
            {
                this.mGeneralInterface.ResetPlayerList();
                for each (_loc_33 in param1.playersOnMap)
                {
                    
                    _loc_35 = new cPlayerData(this.mGeneralInterface);
                    this.CreatePlayerFromPlayerVO(_loc_35, _loc_33);
                    if (param6)
                    {
                        _loc_35.SetPlayerId(param7);
                    }
                    this.mGeneralInterface.AddNewPlayer(_loc_35);
                }
                for each (_loc_34 in _loc_12)
                {
                    
                    _loc_36 = this.mGeneralInterface.FindPlayerFromId(_loc_34.GetPlayerId());
                    if (!_loc_36)
                    {
                        continue;
                    }
                    for each (_loc_37 in _loc_34.mAvailableBuffs_vector)
                    {
                        
                        for each (_loc_38 in _loc_36.mAvailableBuffs_vector)
                        {
                            
                            if (_loc_37.GetUniqueId().equals(_loc_38.GetUniqueId()))
                            {
                                _loc_38.SetWaitingForServerCount(_loc_37.GetWaitingForServerCount());
                                break;
                            }
                        }
                    }
                }
                this.mGeneralInterface.mCurrentPlayer = this.mGeneralInterface.FindPlayerFromId(param8);
                this.mGeneralInterface.mHomePlayer = this.mGeneralInterface.FindPlayerFromId(param7);
                if (this.mGeneralInterface.mCurrentPlayer.GetPlayerName_string() == null)
                {
                    this.mGeneralInterface.mCurrentPlayer.SetPlayerName(globalFlash.gui.mAvatar.GetDisplayedPlayerVO().username);
                }
                globalFlash.gui.mFriendsList.AddCurrentPlayer();
            }
            if (param8 == param7)
            {
                this.mGeneralInterface.mCurrentPlayer.mIsPlayerZone = true;
                this.mGeneralInterface.mCurrentPlayer.mIsAdventureZone = false;
                this.mGeneralInterface.mCalculateEconomy = true;
            }
            else if (this.mGeneralInterface.IsAdventureZoneID(this.mGeneralInterface.mHomePlayer.GetPlayerId()))
            {
                this.mGeneralInterface.mCurrentPlayer.mIsPlayerZone = true;
                this.mGeneralInterface.mCurrentPlayer.mIsAdventureZone = true;
                this.mGeneralInterface.mCalculateEconomy = true;
            }
            else
            {
                this.mGeneralInterface.mCurrentPlayer.mIsPlayerZone = false;
                this.mGeneralInterface.mCurrentPlayer.mIsAdventureZone = false;
                this.mGeneralInterface.mCalculateEconomy = false;
            }
            if (param4)
            {
                this.mGeneralInterface.mLog.init(this.mGeneralInterface.mCurrentPlayer.GetPlayerId(), this.mGeneralInterface.mCurrentPlayer.GetPlayerLogLevel(), this.mGeneralInterface.mCurrentPlayer.GetPlayerLogTypeMask(), this.mGeneralInterface.mCurrentPlayer.isLogPlayerActionsEnabled());
            }
            QuestManagerStatic.mQuestContainer_map = null;
            this.mGeneralInterface.mCurrentPlayerZone.mSectorList_vector.length = 0;
            for each (_loc_14 in param1.sectors)
            {
                
                _loc_39 = _loc_14.playerID;
                if (param6)
                {
                    if (_loc_39 != 0 && _loc_39 != -1)
                    {
                        _loc_39 = param7;
                    }
                }
                this.mGeneralInterface.mCurrentPlayerZone.mSectorList_vector.push(new cSector(_loc_14.sectorID, _loc_39, _loc_14.explorePriority, _loc_14.cityLevelAtWhichSectorIsActivated));
            }
            if (param1.resourcesVO != null)
            {
                _loc_15 = param1.resourcesVO.CreateResourcesFromVO(this.mGeneralInterface, this.mGeneralInterface.mCurrentViewedZoneID, this.mGeneralInterface.mCurrentPlayer.GetPlayerId());
            }
            else
            {
                _loc_15 = new cResources(this.mGeneralInterface, this.mGeneralInterface.mCurrentViewedZoneID, this.mGeneralInterface.mCurrentPlayer.GetPlayerId());
                _loc_15.CreateResourceEntries();
                _loc_15.CalculateMaxLimitsForResources(this.mGeneralInterface.mCurrentPlayer.GetPlayerId());
                _loc_15.mDirtyIndicator = DIRTY_INDICATOR.CLEAN;
            }
            this.mGeneralInterface.mCurrentPlayerZone.AddResources(_loc_15);
            for each (_loc_16 in this.mGeneralInterface.mCurrentPlayerZone.map_PlayerID_Army)
            {
                
                _loc_16.DisbandArmy(null);
            }
            for (_loc_17 in param1.map_PlayerID_Army)
            {
                
                _loc_40 = gMisc.ParseInt(_loc_17);
                _loc_41 = param1.map_PlayerID_Army[_loc_40] as dArmyVO;
                _loc_42 = this.mGeneralInterface.mCurrentPlayerZone.GetArmy(_loc_40);
                for each (_loc_43 in _loc_41.squads)
                {
                    
                    _loc_42.AddSquadVO(_loc_43, false);
                }
            }
            this.mGeneralInterface.mCurrentPlayerZone.GetMilitaryUnitRecruitments().mTimedProductions_vector.length = 0;
            for each (_loc_18 in param1.militaryUnitRecruitments_vector)
            {
                
                _loc_44 = cTimedProduction.CreateTimedProductionFromVO(_loc_18);
                this.mGeneralInterface.mCurrentPlayerZone.GetMilitaryUnitRecruitments().mTimedProductions_vector.push(_loc_44);
            }
            globalFlash.gui.mTimedProductionInfoPanel.Refresh();
            this.mGeneralInterface.mCurrentPlayerZone.GetBuffProductionQueue().mTimedProductions_vector.length = 0;
            for each (_loc_19 in param1.buffProduction_vector)
            {
                
                _loc_45 = cTimedProduction.CreateTimedProductionFromVO(_loc_19);
                this.mGeneralInterface.mCurrentPlayerZone.GetBuffProductionQueue().mTimedProductions_vector.push(_loc_45);
            }
            globalFlash.gui.mTimedProductionInfoPanel.Refresh();
            for each (_loc_20 in param1.buildings)
            {
                
                if (param6)
                {
                    this.CreateBuildingFromBuildingVO(param7, _loc_20);
                    continue;
                }
                this.CreateBuildingFromBuildingVO(_loc_20.playerID, _loc_20);
            }
            for each (_loc_21 in param1.landscapes)
            {
                
                this.CreateLandscapeFromLandscapeVO(_loc_21);
            }
            for each (_loc_22 in param1.deposits)
            {
                
                this.CreateDepositFromDepositVO(_loc_22, param6);
            }
            for each (_loc_23 in param1.streets)
            {
                
                this.CreateStreetFromStreetVO(_loc_23);
            }
            for each (_loc_24 in param1.freeLandscapes)
            {
                
                this.CreateFreeLandscapeFromFreeLandscapeVO(_loc_24);
            }
            for each (_loc_25 in param1.landingFields)
            {
                
                this.CreateLandingFieldFromLandingFieldVO(_loc_25);
            }
            if (this.mGeneralInterface.mCurrentPlayer.GetHomeZoneId() == param7)
            {
                this.mGeneralInterface.mCurrentPlayer.mBuildQueue.Init(param1.buildQueue);
            }
            var _loc_26:int = 0;
            _loc_11 = defines.STREET_MAP_MIN_USABLE_AREA_Y;
            while (_loc_11 <= defines.STREET_MAP_MAX_USABLE_AREA_Y)
            {
                
                _loc_9 = (_loc_11 << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + defines.STREET_MAP_MIN_USABLE_AREA_X;
                _loc_10 = defines.STREET_MAP_MIN_USABLE_AREA_X;
                while (_loc_10 <= defines.STREET_MAP_MAX_USABLE_AREA_X)
                {
                    
                    _loc_46 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_9];
                    _loc_47 = param1.mapValues[_loc_26];
                    _loc_46.SetBackgroundBlocking(_loc_47.mBackgroundBlocking);
                    _loc_46.mSectorId = _loc_47.mSectorId;
                    _loc_9++;
                    _loc_26++;
                    _loc_10++;
                }
                _loc_11++;
            }
            if (!param3)
            {
                _loc_9 = 0;
                _loc_11 = 0;
                while (_loc_11 < defines.RECTANGLE_MAP_HEIGHT)
                {
                    
                    _loc_10 = 0;
                    while (_loc_10 < defines.RECTANGLE_MAP_WIDTH)
                    {
                        
                        _loc_48 = param1.backgroundTiles[_loc_9] as dBackgroundTileVO;
                        _loc_49 = null;
                        if (_loc_48 != null)
                        {
                            _loc_49 = cBackground.CreateFromString(_loc_48.name_string, this.mGeneralInterface);
                        }
                        this.mGeneralInterface.mCurrentPlayerZone.mBackgroundDataMap.mMap_list[_loc_9] = _loc_49;
                        _loc_9++;
                        _loc_10++;
                    }
                    _loc_11++;
                }
            }
            this.mGeneralInterface.mCurrentPlayerZone.mBackgroundDataMap.UpdatePositions();
            this.mGeneralInterface.ZoneUpdateAfterMapRefreshed();
            for each (_loc_27 in param1.resourceCreations)
            {
                
                this.mGeneralInterface.mComputeResourceCreation.CreateResourceCreationFromResourceCreationVO(_loc_27);
            }
            if (!param3)
            {
                (this.mGeneralInterface as cGameInterface).UpdateGuiOnZoneLoad();
            }
            this.mGeneralInterface.mCurrentPlayerZone.mZoneColorSchema = null;
            if (param1.adventureName != null)
            {
                _loc_50 = cAdventureDefinition.FindAdventureDefinition(param1.adventureName);
                this.mGeneralInterface.mCurrentPlayerZone.mZoneColorSchema = _loc_50.mColorSchema;
                if (_loc_50.mColorSchema != null)
                {
                    if (gGfxResource.SetFilter(_loc_50.mColorSchema, FILTER_SOURCE.ZONE))
                    {
                        gGfxResource.ApplyZoom(this.mGeneralInterface.mZoom.GetInvScaleFactor());
                        this.mGeneralInterface.mCurrentPlayerZone.SetBackgroundHasChanged(true);
                        this.mGeneralInterface.mCurrentPlayerZone.SetAllRescaleDirtyFlags();
                    }
                }
            }
            this.mGeneralInterface.mQuestClientCallbacks.ZoneRefreshed(param7, param3, param4, param1);
            this.mGeneralInterface.mPathFinder.InvalidateAll(this.mGeneralInterface.mCurrentPlayer.GetPlayerId());
            this.mGeneralInterface.mComputeResourceCreation.CalculateProductionPaths(null, true);
            this.mGeneralInterface.mCurrentPlayerZone.GetSpecialists_vector().length = 0;
            for each (_loc_28 in param1.specialists_vector)
            {
                
                _loc_51 = cSpecialist.CreateSpecialistFromVO(this.mGeneralInterface, _loc_28, false);
                this.mGeneralInterface.mCurrentPlayerZone.GetSpecialists_vector().push(_loc_51);
            }
            _loc_29 = 0;
            for each (_loc_30 in param1.dataTracking_vector)
            {
                
                this.mGeneralInterface.mDataTracking.mDataTrackingItem_vector[_loc_29].CreateFromVO(_loc_30);
                _loc_29++;
            }
            this.mGeneralInterface.mCurrentPlayerZone.SetBackgroundHasChanged(true);
            this.mGeneralInterface.mRefreshZoneIsActive = false;
            if (!this.mServerInitialized)
            {
                this.mServerInitialized = true;
                this.mGeneralInterface.ZoneFinished();
            }
            this.mGeneralInterface.SetClientTime(param1.serverTime);
            this.mGeneralInterface.mLastGameTickRefreshClientTime = param1.lastGameTickRefreshTime;
            for each (_loc_31 in this.mGeneralInterface.mGameTickCommand_vector)
            {
                
                if (_loc_31.mode == COMMAND.APPLY_BUFF)
                {
                    _loc_52 = _loc_31.data.data as dUniqueID;
                    _loc_53 = this.mGeneralInterface.FindPlayerFromId(_loc_31.playerID).mAvailableBuffs_vector;
                    _loc_54 = null;
                    _loc_55 = 0;
                    while (_loc_55 < _loc_53.length && _loc_54 == null)
                    {
                        
                        if (_loc_53[_loc_55].GetUniqueId().equals(_loc_52))
                        {
                            _loc_54 = _loc_53[_loc_55];
                        }
                        _loc_55++;
                    }
                    if (_loc_54)
                    {
                        _loc_54.DecWaitingForServerCount();
                        trace("decreasing wainting count");
                    }
                }
            }
            this.mGeneralInterface.mGameTickCommand_vector.length = 0;
            for each (_loc_32 in param1.gameTickCommands_vector)
            {
                
                this.mGeneralInterface.mGameTickCommand_vector.push(_loc_32);
            }
            this.mGeneralInterface.mGameTickRefreshCounter = param1.gameTickRefreshCounter;
            return;
        }// end function

        public function CreateBuildingFromBuildingVO(param1:int, param2:dBuildingVO) : cBuilding
        {
            var _loc_3:int = 0;
            var _loc_4:cPlayerData = null;
            var _loc_5:* = param2.buildingGrid;
            if (param2.playerID == -1 || param2.playerID == 0)
            {
                _loc_3 = param2.playerID;
                _loc_4 = null;
            }
            else
            {
                _loc_3 = param1;
                _loc_4 = this.mGeneralInterface.FindPlayerFromId(_loc_3);
            }
            var _loc_6:* = this.mGeneralInterface.mCurrentPlayerZone.SetAtGridPosition(_loc_4, OBJECTTYPE.BUILDING, param2.buildingName_string, _loc_5) as cBuilding;
            (this.mGeneralInterface.mCurrentPlayerZone.SetAtGridPosition(_loc_4, OBJECTTYPE.BUILDING, param2.buildingName_string, _loc_5) as cBuilding).SetPlayerID(_loc_3);
            if (param2.hitPoints == -1)
            {
                param2.hitPoints = _loc_6.GetMaxHitPoints();
            }
            _loc_6.InitFromVO(param2);
            _loc_6.mDirtyIndicator = DIRTY_INDICATOR.CLEAN;
            return _loc_6;
        }// end function

        public function CreatePlayerFromPlayerVO(param1:cPlayerData, param2:dPlayerVO) : void
        {
            var _loc_3:dBuffVO = null;
            var _loc_4:dPurchasedShopItemVO = null;
            var _loc_5:dTempBuildSlotVO = null;
            param1.InitBaseData(param2.userID, param2.username_string, param2.xp, param2.playerLevel, param2.cityLevel, param2.avatarId, param2.uniqueID, param2.canCheat, param2.generalsAmount, param2.explorersAmount, param2.geologistsAmount, param2.currentMaximumBuildingsCountAll, param2.logLevel, param2.logType, param2.logActions, param2.permanentBuildQueueSlotsCount);
            param1.InitSectorDiscovery(param2.discoveredSectors);
            for each (_loc_3 in param2.availableBuffs_vector)
            {
                
                param1.mAvailableBuffs_vector.push(cBuff.CreateBuffFromVO(_loc_3));
            }
            for each (_loc_4 in param2.purchasedShopItems_vector)
            {
                
                param1.mPurchasedShopItems_vector.push(_loc_4);
            }
            for each (_loc_5 in param2.availableTempSlots_vector)
            {
                
                param1.mAvailableTempSlots_vector.push(_loc_5);
            }
            if (param1.mAvailableTempSlots_vector.length > 0)
            {
                param1.mBuildQueue.updateTempSlots();
            }
            return;
        }// end function

        public function CreateFreeLandscapeFromFreeLandscapeVO(param1:dFreeLandscapeVO) : void
        {
            var _loc_2:* = param1.x;
            var _loc_3:* = param1.y;
            this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.SetLandscapeAtFreePosition(param1.name_string, _loc_2, _loc_3);
            return;
        }// end function

        public function CreateStreetFromStreetVO(param1:dStreetVO) : void
        {
            var _loc_2:* = param1.grid;
            var _loc_3:* = cStreet.CreateStringFromStreetBitField_string(param1.streetBits);
            var _loc_4:* = this.mGeneralInterface.mCurrentPlayerZone.SetAtGridPosition(this.mGeneralInterface.mCurrentPlayer, OBJECTTYPE.STREET, defines.STREET_ELEMENT_NAME_string + "_" + _loc_3, _loc_2) as cStreet;
            (this.mGeneralInterface.mCurrentPlayerZone.SetAtGridPosition(this.mGeneralInterface.mCurrentPlayer, OBJECTTYPE.STREET, defines.STREET_ELEMENT_NAME_string + "_" + _loc_3, _loc_2) as cStreet).Init(param1.streetCityLevel, param1.streetVariation, _loc_2);
            _loc_4.SetPlayerID(param1.playerID);
            return;
        }// end function

        public function RefreshZone(param1:dZoneVO, param2:Boolean, param3:Boolean, param4:Boolean) : void
        {
            this.RefreshZoneLocal(param1, param1.questDefinitionContainer, param2, param3, param4, false, param1.zoneOwnerPlayerID, param1.zoneVisitorPlayerID);
            return;
        }// end function

        public function CreateDepositQualityFromDepositQualityVO(param1:dDepositQualityVO) : void
        {
            var _loc_2:* = new cDepositQuality(param1.depositBonus, param1.diceThrow);
            this.mGeneralInterface.mServerOnly.mDepositQualities_vector.push(_loc_2);
            return;
        }// end function

        public function CreateLandscapeFromLandscapeVO(param1:dLandscapeVO) : void
        {
            var _loc_2:* = param1.grid;
            var _loc_3:* = this.mGeneralInterface.mCurrentPlayer;
            if (_loc_3.GetPlayerId() != param1.playerID)
            {
                _loc_3 = this.mGeneralInterface.FindPlayerFromId(param1.playerID);
            }
            var _loc_4:* = this.mGeneralInterface.mCurrentPlayerZone.SetAtGridPosition(_loc_3, OBJECTTYPE.LANDSCAPE, param1.name_string, _loc_2) as cLandscape;
            (this.mGeneralInterface.mCurrentPlayerZone.SetAtGridPosition(_loc_3, OBJECTTYPE.LANDSCAPE, param1.name_string, _loc_2) as cLandscape).SetPlayerID(param1.playerID);
            _loc_4.SetName_string(param1.name_string);
            _loc_4.SetGrid(param1.grid);
            return;
        }// end function

        public function CreateDepositFromDepositVO(param1:dDepositVO, param2:Boolean) : void
        {
            var _loc_3:* = param1.gridIdx;
            var _loc_4:* = this.mGeneralInterface.mCurrentPlayerZone.SetAtGridPosition(this.mGeneralInterface.mCurrentPlayer, OBJECTTYPE.DEPOSIT, "Deposit" + param1.name_string, _loc_3) as cDeposit;
            (this.mGeneralInterface.mCurrentPlayerZone.SetAtGridPosition(this.mGeneralInterface.mCurrentPlayer, OBJECTTYPE.DEPOSIT, "Deposit" + param1.name_string, _loc_3) as cDeposit).Init(param1.name_string, _loc_3, param1.amount, param1.maxAmount, param1.depositGroupdId, param1.accessible, param1.emptied, param1.goSetListName_string);
            this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_3].RefreshDepositGfx();
            return;
        }// end function

    }
}
