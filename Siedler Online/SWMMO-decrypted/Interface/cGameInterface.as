package Interface
{
    import AdventureSystem.*;
    import BuffSystem.*;
    import Communication.VO.*;
    import Communication.VO.UpdateVO.*;
    import Enums.*;
    import GO.*;
    import GUI.Components.*;
    import GUI.GAME.*;
    import MilitarySystem.*;
    import NewQuestSystem.*;
    import ServerState.*;
    import ShopSystem.*;
    import Sound.*;
    import Specialists.*;
    import TimedProduction.*;
    import __AS3__.vec.*;
    import flash.events.*;
    import flash.net.*;
    import flash.ui.*;
    import mx.collections.*;
    import mx.controls.*;
    import mx.core.*;
    import nLib.*;

    public class cGameInterface extends cGeneralInterface
    {
        private var mRefreshResourceProductionWindow:int = 0;
        private var mCurrentFloodedZoneDelay:int = 0;
        private var mInitInitalizedStartGame:Boolean = false;
        private var mLastUpdateCounter:int = 0;
        public var mChatWindowActive:Boolean = false;
        private const ACTIVATE_AUTOPLAY:Boolean = false;
        private var mGameTickCommandPlayer:cPlayerData;
        private var mInitInitalized:Boolean = false;
        public var mUpdateThreadIdx:int = -1;
        private var fileReferenceList:FileReferenceList;
        private var mCurrentFloodedZone:int = 0;
        private var mLastXPUpdate:Number;
        private var mResourceUpdateCnt:int;
        public var mGfxDeltaTicks:Number;
        private var mCheatcodeEntered:int = 0;
        public var mResourceProcollCheck:ArrayCollection;
        private var mStartActivateAutoPlay:Number;
        private var fr:FileReference;
        private var mCheatcodeEnteredString:String = "";
        private var mActivateMessageFlood:Boolean = false;
        public var mUpdateFrequenceTyp:int = 0;
        public var mLastGfxDeltaTicksUpdate:Number = -1;
        public static const LOAD_MAP_DIRECT:Boolean = !defines.USE_EXTERNAL_SERVER;

        public function cGameInterface()
        {
            this.mResourceProcollCheck = new ArrayCollection();
            return;
        }// end function

        public function setLastDatabaseUpdateCounter(param1:int) : void
        {
            this.mLastUpdateCounter = param1;
            return;
        }// end function

        override public function MouseClick(event:MouseEvent) : void
        {
            if (!IsActiveAndInputActive())
            {
                return;
            }
            mCurrentPlayerZone.MouseClick(event);
            return;
        }// end function

        public function BuySpecialistDirect(param1:cPlayerData, param2:int, param3:dUniqueID, param4:Boolean) : void
        {
            var _loc_6:cResources = null;
            var _loc_7:Vector.<dResource> = null;
            if (param4)
            {
                _loc_6 = mCurrentPlayerZone.GetResources(param1);
                _loc_7 = cSpecialist.GetCostsToBuy_vector(param2, param1.GetSpecialistAmount(param2));
                if (!_loc_6.HasPlayerResourcesInListOne(_loc_7))
                {
                    gErrorMessages.ShowInfoMessage("Player cannot afford specialist!");
                    return;
                }
                _loc_6.RemovePlayerResourcesFromResourcesInList(_loc_7, 1);
            }
            var _loc_5:* = new cSpecialist(true).InitSpecialistFromType(param2, param3, param1.GetPlayerId(), mCurrentViewedZoneID);
            mCurrentPlayerZone.GetSpecialists_vector().push(_loc_5);
            param1.IncSpecialistAmount(_loc_5.GetType());
            switch(_loc_5.GetType())
            {
                case SPECIALIST_TYPE.GEOLOGIST:
                {
                    globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.NEW_GEOLOGIST);
                    break;
                }
                case SPECIALIST_TYPE.GENERAL:
                {
                    globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.NEW_GENERAL);
                    break;
                }
                case SPECIALIST_TYPE.EXPLORER:
                {
                    globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.NEW_EXPLORER);
                    break;
                }
                default:
                {
                    gMisc.ConsoleOut("Could not interpret specialist type " + _loc_5.GetType());
                    break;
                }
            }
            if (globalFlash.gui.mTavernInfoPanel.IsVisible())
            {
                globalFlash.gui.mTavernInfoPanel.Refresh();
            }
            return;
        }// end function

        public function ResetResourceViewUpdate() : void
        {
            this.mLastXPUpdate = gMisc.GetTimeSinceStartup() - 100000;
            this.mResourceUpdateCnt = 0;
            return;
        }// end function

        override public function ZoomHasChanged() : void
        {
            mCurrentPlayerZone.SetBackgroundHasChanged(true);
            return;
        }// end function

        private function HandleStartTimedProduction(param1:cPlayerData, param2:dGameTickCommandVO) : void
        {
            var _loc_3:dStartTimedProductionVO = null;
            var _loc_8:cBuffDefinition = null;
            var _loc_9:cMilitaryUnitDescription = null;
            _loc_3 = param2.data as dStartTimedProductionVO;
            var _loc_4:String = null;
            ;
            
            _loc_4 = defines.PROVISIONHOUSE_NAME_string;
            ;
            
            _loc_4 = defines.BARRACKS_NAME_string;
            ;
            
            return;
        }// end function

        override public function MouseUp(event:MouseEvent) : void
        {
            if (!IsActiveAndInputActive())
            {
                return;
            }
            mMousePressed = false;
            mCurrentPlayerZone.MouseUp(event);
            return;
        }// end function

        public function SpoolTimeDeltaValue(param1:Number) : Number
        {
            var _loc_2:* = gMisc.GetTimeSinceStartup();
            var _loc_3:* = mCalculateTicks.mDeltaTicksMs;
            var _loc_4:* = mGlobalTimeScale;
            mSpoolingIsActive = true;
            mGlobalTimeScale = 5;
            var _loc_5:* = param1 * (_loc_4 / mGlobalTimeScale);
            var _loc_6:Number = 0;
            while (true)
            {
                
                mCalculateTicks.mDeltaTicksMs = 2500;
                this.CalculateGameTickLogic();
                _loc_5 = _loc_5 - mCalculateTicks.mDeltaTicksMs;
                if (_loc_5 <= 0)
                {
                    break;
                }
                _loc_6 = gMisc.GetTimeSinceStartup() - _loc_2;
                if (_loc_6 > 60000)
                {
                    LocalLogMessageDetail("Spooling takes to long!");
                    break;
                }
            }
            mSpoolingIsActive = false;
            mGlobalTimeScale = _loc_4;
            mCalculateTicks.mDeltaTicksMs = _loc_3;
            return _loc_6;
        }// end function

        override public function Compute() : void
        {
            var _loc_6:dServerResponse = null;
            var _loc_7:dServerResponse = null;
            mLastServerResponseRead = true;
            if (mLastServerResponse.length != 0)
            {
                for each (_loc_6 in mLastServerResponse)
                {
                    
                    mClientMessages.ReceivedMessageFromServer(_loc_6);
                }
                mLastServerResponse.length = 0;
            }
            mLastServerResponseRead = false;
            mLastServerResponseIIRead = true;
            if (mLastServerResponseII.length != 0)
            {
                for each (_loc_7 in mLastServerResponseII)
                {
                    
                    mClientMessages.ReceivedMessageFromServer(_loc_7);
                }
                mLastServerResponseII.length = 0;
            }
            mLastServerResponseIIRead = false;
            if (!mActiveG)
            {
                return;
            }
            if (gMisc.PROFILE_ACTIVE)
            {
                gMisc.ProfilerStart("Compute");
            }
            mCalculateTicks.CalculateDeltaTicks();
            if (defines.ACTIVATE_STREAMING)
            {
                ComputeStreaming();
            }
            mWobbling = GetUnscaledClientTime() / 50;
            mWobbling = mWobbling % 20;
            if (mWobbling > 10)
            {
                mWobbling = 20 - mWobbling;
            }
            mWobblingInt = int(mWobbling);
            this.CalculateGameTickLogic();
            if (this.ACTIVATE_AUTOPLAY)
            {
                if (this.mStartActivateAutoPlay != -1)
                {
                    if (GetUnscaledClientTime() - this.mStartActivateAutoPlay > 10000)
                    {
                        mTestKI.ActivatePlayGame("");
                        gMisc.ConsoleOut("Player ID: " + mHomePlayer.GetPlayerId() + "Play Game KI activated ");
                        this.mStartActivateAutoPlay = -1;
                    }
                }
            }
            if (Application.application.AutorefreshID.selected)
            {
                var _loc_8:String = this;
                var _loc_9:* = this.mRefreshResourceProductionWindow + 1;
                _loc_8.mRefreshResourceProductionWindow = _loc_9;
                if (this.mRefreshResourceProductionWindow > 10)
                {
                    this.mRefreshResourceProductionWindow = 0;
                    if (Application.application.ResourceProductionWindow.visible)
                    {
                        Application.application.RefreshResourceProductionWindow();
                    }
                }
            }
            var _loc_1:* = gMisc.GetTimeSinceStartup();
            var _loc_2:* = _loc_1 - this.mLastXPUpdate;
            if (_loc_2 > 1000)
            {
                if (mCurrentPlayer.CheckXPChanged() && mCurrentPlayer.GetPlayerId() == mHomePlayer.GetPlayerId())
                {
                    globalFlash.gui.mAvatar.SetData(mCurrentPlayer, GetPlayerList_vector());
                }
                this.mLastXPUpdate = _loc_1;
            }
            var _loc_3:* = mCurrentPlayerZone.GetResources(mCurrentPlayer);
            var _loc_4:* = _loc_3.GetPlayerResources_vector(RESOURCE_GROUP.ALL);
            var _loc_8:String = this;
            var _loc_9:* = this.mResourceUpdateCnt + 1;
            _loc_8.mResourceUpdateCnt = _loc_9;
            if (this.mResourceUpdateCnt >= _loc_4.length)
            {
                this.mResourceUpdateCnt = 0;
            }
            var _loc_5:* = _loc_4[this.mResourceUpdateCnt];
            if (_loc_4[this.mResourceUpdateCnt].name_string == defines.POPULATION_RESOURCE_NAME_string)
            {
                globalFlash.gui.mInfoBar.SetPopulation(_loc_3);
            }
            else
            {
                globalFlash.gui.mInfoBar.SetResource(_loc_5);
            }
            if (globalFlash.gui.mWarehouseInfoPanel.IsVisible())
            {
                globalFlash.gui.mWarehouseInfoPanel.UpdateResources();
            }
            mCurrentPlayerZone.CalculateDeltaScrolls();
            if (gMisc.PROFILE_ACTIVE)
            {
                gMisc.ProfilerEnd("Compute");
            }
            return;
        }// end function

        public function GameSettingsXMLSanityCheck() : void
        {
            return;
        }// end function

        private function HandleInitiateItemTrade(param1:cPlayerData, param2:dGameTickCommandVO) : Boolean
        {
            if (param2.data == null)
            {
                return false;
            }
            var _loc_3:* = param2.data as dItemTradeOfferVO;
            var _loc_4:* = new dUniqueID();
            new dUniqueID().uniqueID1 = _loc_3.buff.uniqueId1;
            _loc_4.uniqueID2 = _loc_3.buff.uniqueId2;
            var _loc_5:dBuffVO = null;
            var _loc_6:cBuff = null;
            var _loc_7:int = 0;
            while (_loc_7 < param1.mAvailableBuffs_vector.length && _loc_6 == null)
            {
                
                if (param1.mAvailableBuffs_vector[_loc_7].GetUniqueId().equals(_loc_4))
                {
                    _loc_6 = param1.mAvailableBuffs_vector[_loc_7];
                    _loc_5 = _loc_6.CreateBuffVOFromBuff();
                    param1.mAvailableBuffs_vector.splice(_loc_7, 1);
                    break;
                }
                _loc_7++;
            }
            if (_loc_6 == null)
            {
                CustomAlert.show("CannotAffordSendTrade", "CannotAffordSendTrade");
                return false;
            }
            return true;
        }// end function

        public function GameTickRefresh(param1:cPlayerData) : void
        {
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:cResourceCreation = null;
            mLastGameTickRefreshClientTime = GetClientTime();
            var _loc_2:* = mGameTickRefreshCounter % 10;
            if (_loc_2 == 0)
            {
            }
            if (mCalculateEconomy)
            {
                _loc_3 = mClientDeltaTime;
                mClientDeltaTime = int(GameTickPeriodicRefreshTime);
                if (mGlobalTimeScale > 5)
                {
                    _loc_4 = 0;
                    while (_loc_4 < mGlobalTimeScale)
                    {
                        
                        this.CalculateLogicOncePerSecond();
                        _loc_4++;
                    }
                }
                else
                {
                    mClientDeltaTime = int(GameTickPeriodicRefreshTime * mGlobalTimeScale);
                    this.CalculateLogicOncePerSecond();
                }
                mClientDeltaTime = _loc_3;
            }
            if (_loc_2 == 3)
            {
                if (param1.mIsPlayerZone && !mSpoolingIsActive)
                {
                    if (!definesMaster.MASTER_VERSION && defines.PROTOKOLL_RESOURCE_CREATION)
                    {
                        gMisc.ConsoleOut("[" + mGameTickRefreshCounter + "]" + " Player: " + param1.GetPlayerId() + "  : " + gMisc.ConvertDoubleToString_string(GetClientTime()));
                    }
                    if (!definesMaster.MASTER_VERSION && defines.PROTOKOLL_RESOURCES_ORDER_CHECK)
                    {
                        gMisc.ConsoleOut("Resource Creation changed: ClientTime: " + GetClientTime() + " Counter: " + mGameTickRefreshCounter);
                        _loc_5 = 0;
                        _loc_6 = 0;
                        while (_loc_6 < mComputeResourceCreation.mResourceCreation_vector.length)
                        {
                            
                            _loc_7 = mComputeResourceCreation.mResourceCreation_vector[_loc_6];
                            if (_loc_7.GetResourceCreationDefinition() != null)
                            {
                                this.PROTOKOLL_RESOURCE_CREATION_WRITE_CHECK(_loc_7, _loc_5, GetClientTime(), mGameTickRefreshCounter, "PROTOKOLL_RESOURCES");
                                _loc_5++;
                            }
                            _loc_6++;
                        }
                    }
                }
            }
            if (_loc_2 == 6)
            {
                if (!mSpoolingIsActive)
                {
                    CalculateZoneCheckSum();
                }
            }
            if (this.mUpdateFrequenceTyp == 0)
            {
                if (_loc_2 == 3 || _loc_2 == 6 || _loc_2 == 9)
                {
                    this.GetUpdates(param1);
                }
            }
            else if (this.mUpdateFrequenceTyp == 1)
            {
                if (_loc_2 == 4 || _loc_2 == 9)
                {
                    this.GetUpdates(param1);
                }
            }
            else if (this.mUpdateFrequenceTyp >= 2)
            {
                if (_loc_2 == 6)
                {
                    this.GetUpdates(param1);
                }
            }
            var _loc_9:* = mGameTickRefreshCounter + 1;
            mGameTickRefreshCounter = _loc_9;
            param1.mBuildQueue.ComputeBuildQueue();
            return;
        }// end function

        private function ShowPlayerInfo() : void
        {
            var _loc_1:int = 10;
            var _loc_3:* = mDebugTextYPos + _loc_1;
            mDebugTextYPos = mDebugTextYPos + _loc_1;
            globalFlash.gui.WriteDebugText(cBackbuffer.mBackBuffer, "-- Player Info --", mDebugTextXPos, _loc_3);
            var _loc_3:* = mDebugTextYPos + _loc_1;
            mDebugTextYPos = mDebugTextYPos + _loc_1;
            globalFlash.gui.WriteDebugText(cBackbuffer.mBackBuffer, "Player ID: " + mCurrentPlayer.GetPlayerId() + " Client session: " + mClientMessages.getClientSession() + " BuildingCount: " + mCurrentPlayer.GetBuildingCountAll() + " GridPos: " + mCurrentCursor.GetGridPosition(), mDebugTextXPos, _loc_3);
            var _loc_3:* = mDebugTextYPos + _loc_1;
            mDebugTextYPos = mDebugTextYPos + _loc_1;
            globalFlash.gui.WriteDebugText(cBackbuffer.mBackBuffer, "LastGameTickRefreshTime: " + mLastGameTickRefreshClientTime + " GameTickCounter: " + mGameTickRefreshCounter + " ClientTime: " + GetClientTime(), mDebugTextXPos, _loc_3);
            var _loc_3:* = mDebugTextYPos + _loc_1;
            mDebugTextYPos = mDebugTextYPos + _loc_1;
            globalFlash.gui.WriteDebugText(cBackbuffer.mBackBuffer, "Time scale: " + mGlobalTimeScale + " mLastSynchronizetime: " + mLastSynchronizetime + " PostProcessTime:" + GameTickSystemPostProcessTime + " GameTickPeriodicRefreshTime:" + GameTickPeriodicRefreshTime, mDebugTextXPos, _loc_3);
            var _loc_2:String = "";
            if (Application.application.mIsDebugPlayer)
            {
                _loc_2 = "Debug Player";
            }
            if (Application.application.mIsDebugBuild)
            {
                var _loc_3:* = mDebugTextYPos + _loc_1;
                mDebugTextYPos = mDebugTextYPos + _loc_1;
                globalFlash.gui.WriteDebugText(cBackbuffer.mBackBuffer, "- Debug Version " + _loc_2 + " -", mDebugTextXPos, _loc_3);
            }
            else
            {
                var _loc_3:* = mDebugTextYPos + _loc_1;
                mDebugTextYPos = mDebugTextYPos + _loc_1;
                globalFlash.gui.WriteDebugText(cBackbuffer.mBackBuffer, "- Release Version " + _loc_2 + " -", mDebugTextXPos, _loc_3);
            }
            return;
        }// end function

        private function ShowIngameErrorMessagesDetail() : void
        {
            var _loc_4:String = null;
            var _loc_1:int = 10;
            var _loc_5:* = mDebugTextYPos + _loc_1;
            mDebugTextYPos = mDebugTextYPos + _loc_1;
            globalFlash.gui.WriteDebugText(cBackbuffer.mBackBuffer, "-- Detail Logs (" + mInGameErrorMessagesLogDetail_vector.length + ") (end+mouse=scroll)--", mDebugTextXPos, _loc_5);
            var _loc_2:* = (mInGameErrorMessagesLogDetail_vector.length - 1) - mDetailLogScrollPos;
            var _loc_3:int = 0;
            while (_loc_3 < mDetailLogScrollPosLen)
            {
                
                if (_loc_2 >= 0 && _loc_2 < mInGameErrorMessagesLogDetail_vector.length)
                {
                    _loc_4 = mInGameErrorMessagesLogDetail_vector[_loc_2];
                    var _loc_5:* = mDebugTextYPos + _loc_1;
                    mDebugTextYPos = mDebugTextYPos + _loc_1;
                    globalFlash.gui.WriteDebugText(cBackbuffer.mBackBuffer, _loc_2 + ") " + _loc_4, mDebugTextXPos, _loc_5);
                    _loc_2 = _loc_2 - 1;
                }
                _loc_3++;
            }
            return;
        }// end function

        private function HandleApplyLoottableBuff(param1:cPlayerData, param2:dGameTickCommandVO) : void
        {
            var _loc_7:int = 0;
            var _loc_8:Object = null;
            var _loc_9:dUniqueID = null;
            var _loc_10:dBuffVO = null;
            var _loc_11:cBuff = null;
            var _loc_12:dSpecialistVO = null;
            var _loc_13:dResourceVO = null;
            var _loc_3:* = param2.data as dLootItemsVO;
            var _loc_4:cBuff = null;
            var _loc_5:* = param1.mAvailableBuffs_vector;
            var _loc_6:int = 0;
            while (_loc_6 < _loc_5.length && _loc_4 == null)
            {
                
                if (_loc_5[_loc_6].GetUniqueId().equals(_loc_3.uniqueID))
                {
                    _loc_4 = _loc_5[_loc_6];
                }
                _loc_6++;
            }
            if (_loc_4 != null)
            {
                globalFlash.gui.mMysteryBoxPanel.SetResult(_loc_3);
                _loc_7 = 0;
                while (_loc_7 < _loc_3.items.length)
                {
                    
                    _loc_8 = _loc_3.items[_loc_7];
                    _loc_9 = _loc_3.uniqueIDs[_loc_7] as dUniqueID;
                    if (_loc_8 is dBuffVO)
                    {
                        _loc_10 = _loc_8 as dBuffVO;
                        _loc_10.uniqueId1 = _loc_9.uniqueID1;
                        _loc_10.uniqueId2 = _loc_9.uniqueID2;
                        if (_loc_10.buffName_string == "AddResource" && _loc_10.resourceName_string == defines.HARD_CURRENCY_RESOURCE_NAME_string)
                        {
                            mCurrentPlayerZone.GetResources(param1).AddResource(defines.HARD_CURRENCY_RESOURCE_NAME_string, _loc_10.amount);
                            this.forceDatabaseUpdate("AddHardCurrencyByLoottableBuff");
                        }
                        else
                        {
                            _loc_11 = cBuff.CreateBuffFromVO(_loc_10);
                            param1.mAvailableBuffs_vector.push(_loc_11);
                        }
                    }
                    else if (_loc_8 is dSpecialistVO)
                    {
                        _loc_12 = _loc_8 as dSpecialistVO;
                        _loc_12.uniqueID = _loc_9;
                        mCurrentPlayerZone.GetSpecialists_vector().push(cSpecialist.CreateSpecialistFromVO(this, _loc_12, true));
                        param1.IncSpecialistAmount(_loc_12.specialistType);
                    }
                    else if (_loc_8 is dResourceVO)
                    {
                        _loc_13 = _loc_8 as dResourceVO;
                        if (_loc_13.name_string == "XP")
                        {
                            param1.AddXP(_loc_13.amount);
                        }
                        else
                        {
                            gMisc.Assert(false, "Could not interpret resource " + _loc_13 + " for loot item!");
                        }
                    }
                    else
                    {
                        gMisc.Assert(false, "Could not interpret item " + _loc_8 + " for a loot item!");
                    }
                    _loc_7++;
                }
                _loc_5.splice((_loc_6 - 1), 1);
            }
            return;
        }// end function

        override public function Init(param1:int) : void
        {
            gMisc.Assert(!this.mInitInitalized, "Init already initialized!");
            this.mInitInitalized = true;
            super.Init(param1);
            this.ApplicationResized();
            gInitStaticForAllZones.ShowLoadingScreen(50);
            gMisc.Assert(!this.mInitInitalizedStartGame, "Game already initialized!");
            this.mInitInitalizedStartGame = true;
            mEnumUIType = UITYPE.GAME;
            mSynchronisationErrorBitField = 0;
            mZoneCheckUpdateVO = null;
            GameTickSystemPostProcessTime = defines.GAMETICK_SYSTEM_POSTPROCESS_TIME_MIN;
            GameTickPeriodicRefreshTime = defines.GAMETICK_PERIODIC_REFRESH_TIME;
            gInitStaticForAllZones.ShowLoadingScreen(100);
            cBackbuffer.InitSegmentBuffer(80, 48, 12 * 7, false);
            cBackbuffer.SetRedirectToSegmentBuffer(true);
            cBackbuffer.Clear(mCurrentPlayerZone.CLEAR_COLOR);
            cBackbuffer.SetRedirectToSegmentBuffer(false);
            globalFlash.gui.InitGuiElements(this);
            mMouseCursor.Init();
            mMouseCursor.SetCursorEditMode(COMMAND.SELECT_BUILDING);
            mCurrentCursor = mMouseCursor;
            mMouseCursorSecondary.Init();
            mMouseCursorSecondary.SetCursorEditMode(COMMAND.SELECT_BUILDING);
            mCurrentSecondaryCursor = mMouseCursorSecondary;
            InitPreCreatedGOs();
            mCurrentPlayerZone.Init();
            mZoom.SetScrollPosPlayerZone(mCurrentPlayerZone, 0, 2);
            this.ResetResourceViewUpdate();
            this.ClearLevel();
            mTestKI.Init();
            mCurrentPlayer.mIsPlayerZone = true;
            mCalculateEconomy = true;
            if (mEnumUIType == UITYPE.EDITOR)
            {
                return;
            }
            gEconomics.Init();
            mCurrentPlayer.Init(0);
            mComputeResourceCreation.Init();
            mDateFormatter.formatString = "JJ:NN:SS";
            gMisc.Assert(gEconomics.mResourceCreationDefinition_vector != null, "gServer.Init: Economics is not initialized!");
            this.GameSettingsXMLSanityCheck();
            if (defines.ACTIVATE_STREAMING)
            {
                InitStreaming();
            }
            else
            {
                mRenderScreen = true;
                mFadeInCntr = defines.FADEIN_TIME;
            }
            mLastZoneRefreshTime = 0;
            mSynchronizetime = 0;
            mLastSynchronizetime = 0;
            mLastGameTickRefreshClientTime = 0;
            SetClientTime(0);
            if (this.ACTIVATE_AUTOPLAY)
            {
                this.mStartActivateAutoPlay = GetUnscaledClientTime();
            }
            if (LOAD_MAP_DIRECT)
            {
            }
            else
            {
                this.ServerLoadedFinished();
            }
            return;
        }// end function

        private function HandleAcceptLoot(param1:cPlayerData, param2:dGameTickCommandVO) : Boolean
        {
            var _loc_5:Object = null;
            var _loc_6:dUniqueID = null;
            var _loc_7:dBuffVO = null;
            var _loc_8:cBuff = null;
            var _loc_9:dSpecialistVO = null;
            var _loc_10:dResourceVO = null;
            var _loc_3:* = param2.data as dLootItemsVO;
            var _loc_4:int = 0;
            while (_loc_4 < _loc_3.items.length)
            {
                
                _loc_5 = _loc_3.items[_loc_4];
                _loc_6 = _loc_3.uniqueIDs[_loc_4] as dUniqueID;
                if (_loc_5 is dBuffVO)
                {
                    _loc_7 = _loc_5 as dBuffVO;
                    if (_loc_7.buffName_string == "AddResource" && _loc_7.resourceName_string == defines.HARD_CURRENCY_RESOURCE_NAME_string)
                    {
                        mCurrentPlayerZone.GetResources(param1).AddResource(defines.HARD_CURRENCY_RESOURCE_NAME_string, _loc_7.amount);
                        this.forceDatabaseUpdate("AddHardCurrencyByLootMail");
                    }
                    else
                    {
                        _loc_7.uniqueId1 = _loc_6.uniqueID1;
                        _loc_7.uniqueId2 = _loc_6.uniqueID2;
                        _loc_8 = cBuff.CreateBuffFromVO(_loc_7);
                        param1.mAvailableBuffs_vector.push(_loc_8);
                    }
                }
                else if (_loc_5 is dSpecialistVO)
                {
                    _loc_9 = _loc_5 as dSpecialistVO;
                    _loc_9.uniqueID = _loc_6;
                    mCurrentPlayerZone.GetSpecialists_vector().push(cSpecialist.CreateSpecialistFromVO(this, _loc_9, true));
                    param1.IncSpecialistAmount(_loc_9.specialistType);
                }
                else if (_loc_5 is dResourceVO)
                {
                    _loc_10 = _loc_5 as dResourceVO;
                    if (_loc_10.name_string == "XP")
                    {
                        param1.AddXP(_loc_10.amount);
                    }
                    else
                    {
                        gMisc.Assert(false, "Could not interpret resource " + _loc_10 + " for loot item!");
                    }
                }
                else
                {
                    gMisc.Assert(false, "Could not interpret item " + _loc_5 + " for a loot item!");
                }
                _loc_4++;
            }
            return true;
        }// end function

        private function HandleAcceptAdventureInvitation(param1:cPlayerData, param2:dGameTickCommandVO) : Boolean
        {
            return true;
        }// end function

        override public function KeyUp(event:KeyboardEvent) : void
        {
            if (!IsActiveAndInputActive() || this.mChatWindowActive)
            {
                return;
            }
            if (event.keyCode == Keyboard.LEFT || event.keyCode == Keyboard.RIGHT || event.keyCode == Keyboard.UP || event.keyCode == Keyboard.DOWN || event.charCode == gMisc.AsciiKeyCode("w") || event.charCode == gMisc.AsciiKeyCode("a") || event.charCode == gMisc.AsciiKeyCode("s") || event.charCode == gMisc.AsciiKeyCode("d"))
            {
                this.ResetScrolling();
            }
            mCurrentPlayerZone.KeyUp(event);
            return;
        }// end function

        private function LogOneClickShopPurchase(param1:cPlayerData, param2:dBuyOneClickShopItemVO, param3:int) : void
        {
            var _loc_4:* = new dPurchasedShopItemVO();
            new dPurchasedShopItemVO().shopItemID = param2.itemId;
            _loc_4.playerLevelAtPurchase = param1.GetPlayerLevel();
            _loc_4.hardCurrencySpend = param3;
            _loc_4.dirtyIndicator = _loc_4.dirtyIndicator | DIRTY_INDICATOR.CREATED_BIT;
            mCurrentPlayer.mPurchasedShopItems_vector.push(_loc_4);
            return;
        }// end function

        override public function Exit() : void
        {
            globalFlash.gui.ExitGuiElements();
            mCurrentPlayerZone.Exit();
            mActiveG = false;
            mComputeAndInputActive = false;
            return;
        }// end function

        private function HandleRaiseArmy(param1:cPlayerData, param2:dGameTickCommandVO) : void
        {
            var _loc_6:dResourceVO = null;
            var _loc_7:cSpecialist = null;
            var _loc_3:* = param2.data as dRaiseArmyVO;
            var _loc_4:iMilitaryUnitHolder = null;
            if (_loc_3.armyHolderBuildingVO != null)
            {
                _loc_4 = mCurrentPlayerZone.GetBuildingFromGridPosition(_loc_3.armyHolderBuildingVO.buildingGrid);
            }
            else if (_loc_3.armyHolderSpecialistVO != null)
            {
                _loc_7 = mCurrentPlayerZone.getSpecialist(param1.GetPlayerId(), _loc_3.armyHolderSpecialistVO.uniqueID);
                if (_loc_7 == null)
                {
                    if (mLog.isInfoEnabled(LOG_TYPE.SPECIALIST))
                    {
                        mLog.logInfo(LOG_TYPE.SPECIALIST, "Could not find specialist on zone for " + _loc_3);
                    }
                    return;
                }
                if (_loc_7.GetTask() != null)
                {
                    if (mLog.isInfoEnabled(LOG_TYPE.SPECIALIST))
                    {
                        mLog.logInfo(LOG_TYPE.SPECIALIST, "Specialist must not have task if raising army " + _loc_7);
                    }
                    _loc_7.SetWaitingForServer(false);
                    return;
                }
                _loc_4 = _loc_7;
            }
            else
            {
                gMisc.Assert(false, "Could not retrieve army holder from " + _loc_3 + "!");
                return;
            }
            if (_loc_4 == null)
            {
                if (mLog.isInfoEnabled(LOG_TYPE.SPECIALIST))
                {
                    mLog.logInfo(LOG_TYPE.SPECIALIST, "Could not find unit holder " + _loc_3);
                }
                return;
            }
            var _loc_5:* = new Vector.<dResourceVO>;
            for each (_loc_6 in _loc_3.unitSquads)
            {
                
                _loc_5.push(_loc_6);
            }
            cMilitaryUtil.RaiseArmy(mCurrentPlayerZone.GetArmy(_loc_4.GetPlayerID()), _loc_4, _loc_5);
            if (_loc_4 is cSpecialist)
            {
                (_loc_4 as cSpecialist).SetWaitingForServer(false);
            }
            return;
        }// end function

        private function PROTOKOLL_RESOURCE_CREATION_WRITE_CHECK(param1:cResourceCreation, param2:int, param3:Number, param4:int, param5:String) : void
        {
            var _loc_6:dProductionProtocollVO = null;
            if (defines.PROTOKOLL_RESOURCE_CREATION_WRITE_TO_ARRAY_CHECK)
            {
                if (this.mResourceProcollCheck.length > 100)
                {
                    this.mResourceProcollCheck.removeItemAt(0);
                }
                _loc_6 = new dProductionProtocollVO();
                _loc_6.resourceName = param1.GetResourceCreationDefinition().defaultSetting.resourceName_string;
                _loc_6.currentResourceNr = param2;
                if (!param1.GetRemove() && param1.GetResourceCreationHouse() != null)
                {
                    _loc_6.buildingGrid = param1.GetResourceCreationHouse().GetBuildingGrid();
                }
                else
                {
                    _loc_6.buildingGrid = -1;
                }
                _loc_6.processCntr = param1.protocollResourceCreationProcessCntr;
                _loc_6.lastBuildingMode = param1.protocollResourceCreationLastBuildingMode;
                _loc_6.phase = param4;
                _loc_6.text = param5;
                _loc_6.currentTime = param3;
                this.mResourceProcollCheck.addItem(_loc_6);
                gMisc.ConsoleOut("*** " + _loc_6);
            }
            else
            {
                gMisc.ConsoleOut("*** r: " + param2 + " p: " + param4 + " c: " + param3);
            }
            return;
        }// end function

        public function CalculateGameTickLogic() : void
        {
            var _loc_2:Boolean = false;
            var _loc_3:dGameTickCommandVO = null;
            var _loc_4:Boolean = false;
            var _loc_5:int = 0;
            var _loc_6:Number = NaN;
            var _loc_7:int = 0;
            var _loc_8:Number = NaN;
            var _loc_9:Number = NaN;
            var _loc_10:Number = NaN;
            var _loc_11:dGameTickCommandVO = null;
            var _loc_12:int = 0;
            var _loc_13:dGameTickCommandVO = null;
            var _loc_14:int = 0;
            var _loc_15:Number = NaN;
            var _loc_1:* = int(mCalculateTicks.mDeltaTicksMs * mGlobalTimeScale);
            while (true)
            {
                
                _loc_4 = true;
                if (Math.abs(mSynchronizetime) > 100)
                {
                    _loc_5 = 50;
                    if (Math.abs(mSynchronizetime) > 500)
                    {
                        _loc_5 = 250;
                    }
                    _loc_6 = mSynchronizetime;
                    if (_loc_6 > _loc_5)
                    {
                        _loc_6 = _loc_5;
                    }
                    if (_loc_6 < -_loc_5)
                    {
                        _loc_6 = -_loc_5;
                    }
                    _loc_1 = _loc_1 + _loc_6;
                    if (_loc_1 < 1)
                    {
                        _loc_6 = _loc_6 + (-_loc_1 + 1);
                        _loc_1 = 1;
                    }
                    mSynchronizetime = mSynchronizetime - _loc_6;
                }
                mLastSynchronizetime = mSynchronizetime;
                mClientDeltaTime = _loc_1;
                if (mClientDeltaTime > 2500)
                {
                    mClientDeltaTime = 2500;
                    _loc_1 = _loc_1 - 2500;
                    _loc_4 = false;
                }
                AddClientTime(mClientDeltaTime);
                if (mGameTickCommand_vector.length > 0)
                {
                    _loc_7 = mClientDeltaTime;
                    _loc_8 = GetClientTime() - _loc_7;
                    _loc_9 = GetClientTime();
                    while (true)
                    {
                        
                        _loc_10 = defines.MAX_DOUBLE_VALUE;
                        _loc_11 = null;
                        _loc_12 = 0;
                        _loc_14 = 0;
                        for each (_loc_13 in mGameTickCommand_vector)
                        {
                            
                            if (_loc_9 >= _loc_13.time)
                            {
                                _loc_15 = _loc_13.time - _loc_8;
                                if (_loc_15 < _loc_10)
                                {
                                    _loc_10 = _loc_15;
                                    _loc_11 = _loc_13;
                                    _loc_12 = _loc_14;
                                }
                            }
                            _loc_14++;
                        }
                        if (_loc_11 != null)
                        {
                            SetClientTime(_loc_11.time);
                            mClientDeltaTime = int(_loc_11.time - _loc_8);
                            if (mClientDeltaTime >= 0)
                            {
                                if (mClientDeltaTime > 0)
                                {
                                    this.ComputeLogic();
                                }
                                mGameTickCommand_vector.splice(_loc_12, 1);
                                this.ProcessGameTickCommands(_loc_11);
                                _loc_8 = _loc_11.time;
                            }
                            else
                            {
                                GameTickErrorMessage("Missed Command: Difference: " + mClientDeltaTime + "  Action mode: " + _loc_11.mode);
                                mSynchronisationErrorBitField = mSynchronisationErrorBitField | cGeneralInterface.SYNCHRONISATION_ERROR_MISSED_GAMETICK;
                                mGameTickCommand_vector.splice(_loc_12, 1);
                                if (_loc_11.mode == COMMAND.GAMETICK_REFRESH_COMMAND)
                                {
                                    gMisc.ConsoleOut("Gametick Refresh Command missed: recreating it!");
                                    GameTickErrorMessage("Gametick Refresh Command missed: recreating it!");
                                    SetGameTickRefreshCommand(mHomePlayer);
                                }
                            }
                            continue;
                        }
                        SetClientTime(_loc_9);
                        mClientDeltaTime = int(_loc_9 - _loc_8);
                        break;
                    }
                }
                this.ComputeLogic();
                if (_loc_4)
                {
                    break;
                }
            }
            _loc_2 = false;
            for each (_loc_3 in mGameTickCommand_vector)
            {
                
                if (_loc_3.mode == COMMAND.GAMETICK_REFRESH_COMMAND)
                {
                    _loc_2 = true;
                    break;
                }
            }
            if (!_loc_2)
            {
                gMisc.ConsoleOut("SHOULD NOT HAPPEN!!! Gametick Command killed: recreating it!");
                GameTickErrorMessage("SHOULD NOT HAPPEN!!! Gametick Command killed: recreating it!");
                mSynchronisationErrorBitField = mSynchronisationErrorBitField | cGeneralInterface.SYNCHRONISATION_ERROR_GAMETICK_COMMAND_KILLED_ERROR;
                SetGameTickRefreshCommand(mHomePlayer);
            }
            return;
        }// end function

        public function IsZoneSavable() : Boolean
        {
            return true;
        }// end function

        private function SaveClientDebugMessagesToFile() : void
        {
            var _loc_3:String = null;
            var _loc_4:dZoneVO = null;
            var _loc_1:* = new FileReference();
            var _loc_2:String = "";
            _loc_2 = _loc_2 + "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n";
            _loc_2 = _loc_2 + "<!--\n";
            for each (_loc_3 in mInGameErrorMessagesLogDetail_vector)
            {
                
                _loc_2 = _loc_2 + (_loc_3 + "\n\r");
            }
            _loc_4 = mServerOnly.CreateZoneVO(mHomePlayer.GetPlayerId());
            _loc_2 = _loc_2 + "***************************************************\n";
            _loc_2 = _loc_2 + "***************************************************\n";
            _loc_2 = _loc_2 + "***************************************************\n";
            _loc_2 = _loc_2 + "Player zone\n";
            _loc_2 = _loc_2 + "***************************************************\n";
            _loc_2 = _loc_2 + "***************************************************\n";
            _loc_2 = _loc_2 + "***************************************************\n";
            _loc_2 = _loc_2 + "-->\n";
            _loc_2 = _loc_2 + "\n";
            _loc_2 = _loc_2 + "<Root>\n";
            _loc_2 = _loc_2 + ("" + _loc_4);
            _loc_2 = _loc_2 + "</Root>\n";
            _loc_1.save(_loc_2, "DebugMessages.txt");
            return;
        }// end function

        private function HandleBuyOneClickShopItem(param1:cPlayerData, param2:dGameTickCommandVO) : Boolean
        {
            var _loc_3:dBuyOneClickShopItemVO = null;
            var _loc_4:cBuilding = null;
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            var _loc_8:cTimedProductionQueue = null;
            var _loc_9:int = 0;
            var _loc_10:cShopItem = null;
            var _loc_11:dUniqueID = null;
            var _loc_12:cSpecialist = null;
            var _loc_13:cSpecialistTask = null;
            var _loc_14:int = 0;
            var _loc_15:int = 0;
            var _loc_16:int = 0;
            var _loc_17:int = 0;
            var _loc_18:cShopItem = null;
            var _loc_19:cTimedProduction = null;
            var _loc_20:int = 0;
            var _loc_21:dResource = null;
            var _loc_22:String = null;
            var _loc_23:dUniqueID = null;
            var _loc_24:dQuestElementVO = null;
            var _loc_25:int = 0;
            var _loc_26:dTempBuildSlotVO = null;
            _loc_3 = param2.data as dBuyOneClickShopItemVO;
            var _loc_5:* = mCurrentPlayerZone.GetResources(param1);
            ;
            
            _loc_4 = mCurrentPlayerZone.GetBuildingFromGridPosition(_loc_3.buildingGridIdx);
            if (_loc_4 == null)
            {
                return false;
            }
            if (_loc_4.GetBuildingMode() != cBuilding.BUILDING_MODE_SETTLER_WALKS_TO_BUILDING_GROUND_PLACE && _loc_4.GetBuildingMode() != cBuilding.BUILDING_MODE_CONSTRUCTION)
            {
                return false;
            }
            _loc_6 = _loc_4.GetBuildInstantCosts();
            if (!_loc_5.HasPlayerResource(defines.HARD_CURRENCY_RESOURCE_NAME_string, _loc_6))
            {
                return false;
            }
            _loc_5.AddResource(defines.HARD_CURRENCY_RESOURCE_NAME_string, -_loc_6);
            _loc_4.SetBuildingMode(cBuilding.BUILDING_MODE_CONSTRUCTION);
            _loc_4.mBuildingProgress = 100 * defines.BUILDING_PROGRESS_SCALE_FACTOR;
            this.LogOneClickShopPurchase(param1, _loc_3, _loc_6);
            ;
            
            return false;
        }// end function

        override public function ClearLevel() : void
        {
            mCurrentPlayerZone.Clear();
            mGoSetListAnimationManager.Reset();
            mComputeResourceCreation.ResetResourceCreation();
            return;
        }// end function

        private function HandleDeclineAdventureInvitation(param1:cPlayerData, param2:dGameTickCommandVO) : Boolean
        {
            return true;
        }// end function

        public function SpoolTime(param1:Number, param2:Boolean) : String
        {
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            var _loc_8:int = 0;
            var _loc_3:String = "";
            var _loc_4:* = param1 - GetClientTime();
            var _loc_5:* = this.SpoolTimeDeltaValue(_loc_4);
            if (this.SpoolTimeDeltaValue(_loc_4) == -1)
            {
                if (param2)
                {
                    _loc_3 = _loc_3 + "spooling takes longer than 60 seconds, stopping\n";
                }
            }
            if (param2)
            {
                _loc_6 = int(_loc_4 / 1000);
                _loc_7 = _loc_6 / 60;
                _loc_8 = _loc_7 / 60;
                _loc_3 = _loc_3 + "**************************************************\n";
                _loc_3 = _loc_3 + ("spooling " + _loc_6 + "sec = " + _loc_7 + "min = " + _loc_8 + " h into the future takes " + _loc_5 / 1000 + " sec \n");
                _loc_3 = _loc_3 + "**************************************************\n";
            }
            return _loc_3;
        }// end function

        private function HandleRemoveBuff(param1:cPlayerData, param2:dGameTickCommandVO) : Boolean
        {
            var _loc_3:cBuff = null;
            var _loc_4:* = param2.data as dServerAction;
            var _loc_5:* = (param2.data as dServerAction).data as dUniqueID;
            var _loc_6:* = param1.mAvailableBuffs_vector;
            var _loc_7:int = 0;
            while (_loc_7 < _loc_6.length && _loc_3 == null)
            {
                
                if (_loc_6[_loc_7].GetUniqueId().equals(_loc_5))
                {
                    _loc_3 = _loc_6[_loc_7];
                }
                _loc_7++;
            }
            if (_loc_3 != null)
            {
                param1.mAvailableBuffs_vector.splice((_loc_7 - 1), 1);
                if (param1.GetPlayerId() == mHomePlayer.GetPlayerId())
                {
                    globalFlash.gui.mStarMenu.Refresh();
                }
            }
            return true;
        }// end function

        private function HandleApplyCasualty(param1:cPlayerData, param2:dGameTickCommandVO) : Boolean
        {
            var _loc_3:* = param2.data as dCasualty;
            mCurrentPlayerZone.GetResources(param1).ModifyMilitaryPopulationResource(-_loc_3.mAmount);
            return true;
        }// end function

        private function HandleRetreat(param1:cPlayerData, param2:dGameTickCommandVO) : Boolean
        {
            var _loc_4:cSpecialistTask = null;
            if (!(param2.data is dUniqueID))
            {
                return false;
            }
            var _loc_3:* = mCurrentPlayerZone.getSpecialist(param1.GetPlayerId(), this.dUniqueID(param2.data));
            if (_loc_3 != null)
            {
                _loc_4 = _loc_3.GetTask();
                if (_loc_4 != null && _loc_4.GetType() == SPECIALIST_TASK_TYPES.ATTACK_BUILDING && (_loc_4.GetTaskPhase() == TASK_PHASES_ATTACK_BUILDING.GO_TO_TARGET || _loc_4.GetTaskPhase() == TASK_PHASES_ATTACK_BUILDING.WAIT_AT_TARGET || _loc_4.GetTaskPhase() == TASK_PHASES_ATTACK_BUILDING.ATTACK_TARGET))
                {
                    (_loc_4 as cSpecialistTask_AttackBuilding).HandleRetreat();
                }
            }
            return true;
        }// end function

        private function HandleBuyShopItem(param1:dGameTickCommandVO) : Boolean
        {
            var _loc_7:dPurchasedShopItemVO = null;
            var _loc_8:dResource = null;
            var _loc_9:Object = null;
            var _loc_10:dBuffVO = null;
            var _loc_11:cBuff = null;
            var _loc_12:dSpecialistVO = null;
            if (!(param1.data is dBuyShopItemVO))
            {
                return false;
            }
            var _loc_2:* = param1.data as dBuyShopItemVO;
            var _loc_3:* = cShopItem.GetShopItem(_loc_2.itemID);
            if (_loc_3 == null)
            {
                return false;
            }
            if (_loc_3.hideInShop())
            {
                return false;
            }
            var _loc_4:* = FindPlayerFromId(param1.playerID);
            gMisc.Assert(_loc_4 != null, "Could not find player with id " + param1.playerID);
            if (_loc_2.giftedPlayerID == 0 && _loc_3.GetPerPlayer() > 0)
            {
                if (_loc_4.GetPurchasedShopItemAmount(_loc_3.GetId()) >= _loc_3.GetPerPlayer())
                {
                    return false;
                }
            }
            var _loc_5:* = _loc_3.GetIncCosts_vector(mCurrentPlayer.GetPurchasedShopItemAmount(_loc_3.GetId()));
            var _loc_6:* = mCurrentPlayerZone.GetResources(_loc_4);
            if (mCurrentPlayerZone.GetResources(_loc_4).HasPlayerResourcesInList(_loc_5, 1))
            {
                _loc_6.RemovePlayerResourcesFromResourcesInList(_loc_5, 1);
                _loc_7 = new dPurchasedShopItemVO();
                _loc_7.shopItemID = _loc_3.GetId();
                _loc_7.playerLevelAtPurchase = _loc_4.GetPlayerLevel();
                _loc_7.giftedToPlayerId = _loc_2.giftedPlayerID;
                for each (_loc_8 in _loc_5)
                {
                    
                    if (_loc_8.name_string == defines.HARD_CURRENCY_RESOURCE_NAME_string)
                    {
                        _loc_7.hardCurrencySpend = _loc_7.hardCurrencySpend + _loc_8.amount;
                        continue;
                    }
                    _loc_7.resourcesSpend = _loc_7.resourcesSpend + ((_loc_7.resourcesSpend.length > 0 ? (",") : ("")) + _loc_8.amount + " " + _loc_8.name_string);
                }
                _loc_7.dirtyIndicator = _loc_7.dirtyIndicator | DIRTY_INDICATOR.CREATED_BIT;
                _loc_4.mPurchasedShopItems_vector.push(_loc_7);
                if (_loc_2.giftedPlayerID == 0)
                {
                    for each (_loc_9 in _loc_2.shopItemContent_vector)
                    {
                        
                        if (_loc_9 is dBuffVO)
                        {
                            _loc_10 = _loc_9 as dBuffVO;
                            _loc_11 = cBuff.CreateBuffFromVO(_loc_10);
                            _loc_4.mAvailableBuffs_vector.push(_loc_11);
                            continue;
                        }
                        if (_loc_9 is dSpecialistVO)
                        {
                            _loc_12 = _loc_9 as dSpecialistVO;
                            mCurrentPlayerZone.GetSpecialists_vector().push(cSpecialist.CreateSpecialistFromVO(this, _loc_12, true));
                            _loc_4.IncSpecialistAmount(_loc_12.specialistType);
                            continue;
                        }
                        return false;
                    }
                    globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.PURCHASE_SUCCESSFUL);
                }
                else
                {
                    globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.PURCHASE_GIFT_SUCCESSFUL);
                }
            }
            else
            {
                return false;
            }
            if (globalFlash.gui.mShopWindow.IsVisible())
            {
                globalFlash.gui.mShopWindow.Refresh();
            }
            return true;
        }// end function

        override public function ClearLevelOnTheFly() : void
        {
            mCurrentPlayerZone.ClearOnTheFly();
            mGoSetListAnimationManager.Reset();
            mComputeResourceCreation.ResetResourceCreation();
            return;
        }// end function

        private function HandleApplyBuff(param1:cPlayerData, param2:dGameTickCommandVO) : Boolean
        {
            var _loc_8:Boolean = false;
            var _loc_9:Object = null;
            var _loc_10:cGO = null;
            var _loc_11:int = 0;
            var _loc_3:cBuff = null;
            var _loc_4:* = param2.data as dServerAction;
            var _loc_5:* = (param2.data as dServerAction).data as dUniqueID;
            var _loc_6:* = param1.mAvailableBuffs_vector;
            var _loc_7:int = 0;
            while (_loc_7 < _loc_6.length && _loc_3 == null)
            {
                
                if (_loc_6[_loc_7].GetUniqueId().equals(_loc_5))
                {
                    _loc_3 = _loc_6[_loc_7];
                }
                _loc_7++;
            }
            if (_loc_3 != null)
            {
                _loc_8 = false;
                _loc_9 = _loc_3.IsApplyable(param1, this, _loc_4.grid);
                if (_loc_9 is cGO)
                {
                    _loc_10 = _loc_9 as cGO;
                    _loc_11 = _loc_3.ApplyBuff(param1, this, _loc_10);
                    if (_loc_11 >= 0)
                    {
                        _loc_8 = true;
                    }
                }
                if (_loc_3.GetCount() <= 0 && _loc_8 && _loc_3.GetRemaining() == 0)
                {
                    _loc_6.splice((_loc_7 - 1), 1);
                }
                cSoundManager.GetInstance().PlayEffect("BuffPlace", _loc_3.GetBuffDefinition().GetName_string());
                _loc_3.DecWaitingForServerCount();
                if (param1.GetPlayerId() == mHomePlayer.GetPlayerId())
                {
                    globalFlash.gui.mStarMenu.Refresh();
                }
            }
            return true;
        }// end function

        private function SaveServerDebugMessagesToFileSend() : void
        {
            mClientMessages.SendMessagetoServer(COMMAND.GET_ASCIIZONE, mHomePlayer.GetHomeZoneId(), null);
            return;
        }// end function

        override public function RefreshGui() : void
        {
            globalFlash.gui.Refresh();
            return;
        }// end function

        private function HandleAcceptItemTrade(param1:cPlayerData, param2:dGameTickCommandVO) : void
        {
            var _loc_5:cBuff = null;
            gMisc.ConsoleOut("Accepting item trade " + param2.data + " at " + param2.time);
            var _loc_3:* = param2.data as dAcceptItemTradeVO;
            var _loc_4:* = mCurrentPlayerZone.GetResources(this.mGameTickCommandPlayer);
            if (mCurrentPlayerZone.GetResources(this.mGameTickCommandPlayer).HasPlayerResource(_loc_3.costs.name_string, _loc_3.costs.amount))
            {
                _loc_4.AddResource(_loc_3.costs.name_string, -_loc_3.costs.amount);
                _loc_5 = cBuff.CreateBuffFromVO(_loc_3.buff);
                this.mGameTickCommandPlayer.mAvailableBuffs_vector.push(_loc_5);
                globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.TRADE_ACCEPTED);
            }
            return;
        }// end function

        public function ResetScrolling() : void
        {
            scroll = defines.SCROLL_NOT;
            return;
        }// end function

        private function ComputeLogic() : void
        {
            if (this.mActivateMessageFlood)
            {
                if (gMisc.GetTimeSinceStartup() - this.mCurrentFloodedZoneDelay > 10)
                {
                    this.mCurrentFloodedZoneDelay = gMisc.GetTimeSinceStartup();
                    mClientMessages.SendMessagetoServer(COMMAND.SET_CITY_LEVEL, mCurrentPlayer.GetHomeZoneId(), gMisc.DoubleToObject(0));
                    gMisc.ConsoleOut("Message to Zone: " + this.mCurrentFloodedZone);
                    var _loc_1:String = this;
                    var _loc_2:* = this.mCurrentFloodedZone + 1;
                    _loc_1.mCurrentFloodedZone = _loc_2;
                    if (this.mCurrentFloodedZone > 500)
                    {
                        this.mCurrentFloodedZone = 100;
                    }
                }
            }
            mTestKI.Compute();
            mCurrentPlayerZone.LogicCompute();
            mCurrentPlayerZone.RenderCompute();
            return;
        }// end function

        override public function MouseOut(event:MouseEvent) : void
        {
            mMousePressed = false;
            return;
        }// end function

        public function getLastDatabaseUpdateCounter() : int
        {
            return this.mLastUpdateCounter;
        }// end function

        private function LoadZonefromStringfileSelectHandler(event:Event) : void
        {
            var _loc_2:* = this.fileReferenceList.fileList;
            this.fr = _loc_2[0];
            this.fr.addEventListener(Event.COMPLETE, this.LoadZonefromStringfileLoadCompleteHandler);
            this.fr.load();
            return;
        }// end function

        private function HandleSetTask(param1:cPlayerData, param2:dGameTickCommandVO) : Boolean
        {
            var _loc_4:dServerAction = null;
            var _loc_5:dUniqueID = null;
            var _loc_6:cSpecialist = null;
            var _loc_7:int = 0;
            var _loc_8:dFindDepositTaskVO = null;
            var _loc_9:cResources = null;
            var _loc_10:dFindDepositTaskVO = null;
            var _loc_11:Vector.<dResource> = null;
            var _loc_12:cResources = null;
            var _loc_13:int = 0;
            var _loc_14:int = 0;
            var _loc_15:cBuilding = null;
            var _loc_16:int = 0;
            var _loc_17:int = 0;
            var _loc_18:cBuilding = null;
            var _loc_19:cSpecialistTask_AttackBuilding = null;
            var _loc_20:String = null;
            var _loc_3:cSpecialistTask = null;
            _loc_4 = param2.data as dServerAction;
            switch(_loc_4.type)
            {
                case SPECIALIST_TASK_TYPES.DEPOSIT_SEARCH:
                {
                    if (!(_loc_4.data is dFindDepositTaskVO))
                    {
                        return false;
                    }
                    _loc_8 = _loc_4.data as dFindDepositTaskVO;
                    _loc_9 = mCurrentPlayerZone.GetResources(param1);
                    if (_loc_8.search_string == null || _loc_9.GetPlayerResource(_loc_8.search_string) == null)
                    {
                        return false;
                    }
                    if (cSpecialistTask_FindDeposit.GetPlayerLevelForDeposit(_loc_8.search_string) > param1.GetPlayerLevel())
                    {
                        return false;
                    }
                    _loc_5 = _loc_8.uniqueID;
                    break;
                }
                default:
                {
                    if (!(_loc_4.data is dUniqueID))
                    {
                        return false;
                    }
                    _loc_5 = _loc_4.data as dUniqueID;
                    break;
                    break;
                }
            }
            _loc_6 = mCurrentPlayerZone.getSpecialist(param1.GetPlayerId(), _loc_5);
            if (_loc_6 == null)
            {
                if (mLog.isErrorEnabled(LOG_TYPE.SPECIALIST))
                {
                    mLog.logError(LOG_TYPE.SPECIALIST, "Could not find specialist " + _loc_5 + "!");
                }
                return false;
            }
            if (_loc_6.GetTask() != null)
            {
                if (_loc_6.GetTask().GetType() == SPECIALIST_TASK_TYPES.WAIT_FOR_CONFIRMATION)
                {
                    _loc_6.SetTask(null);
                }
                else
                {
                    if (mLog.isErrorEnabled(LOG_TYPE.SPECIALIST))
                    {
                        mLog.logError(LOG_TYPE.SPECIALIST, "Specialist " + _loc_5 + " has a task already!");
                    }
                    return false;
                }
            }
            ;
            
            if (mLog.isInfoEnabled(LOG_TYPE.SPECIALIST))
            {
                mLog.logInfo(LOG_TYPE.SPECIALIST, "Ordered Specialist to search deposit: actionData=" + _loc_4.data);
            }
            _loc_10 = _loc_4.data as dFindDepositTaskVO;
            _loc_3 = new cSpecialistTask_FindDeposit(this, _loc_6, _loc_10.search_string, 0, TASK_PHASES_FIND_DEPOSIT.SEARCH_DEPOSIT);
            ;
            
            if (mLog.isInfoEnabled(LOG_TYPE.SPECIALIST))
            {
                mLog.logInfo(LOG_TYPE.SPECIALIST, "Ordered Specialist to explore sector");
            }
            _loc_3 = new cSpecialistTask_ExploreSector(this, _loc_6, 0, TASK_PHASES_EXPLORE_SECTOR.EXPLORE_SECTOR);
            ;
            
            if (mLog.isInfoEnabled(LOG_TYPE.SPECIALIST))
            {
                mLog.logInfo(LOG_TYPE.SPECIALIST, "Ordered specialist " + _loc_4.data + " to find treasure.");
            }
            _loc_3 = new cSpecialistTask_FindTreasure(this, _loc_6, 0, TASK_PHASES_FIND_TREASURE.FIND_TREASURE, _loc_4.type);
            ;
            
            if (mLog.isInfoEnabled(LOG_TYPE.SPECIALIST))
            {
                mLog.logInfo(LOG_TYPE.SPECIALIST, "Ordered specialist " + _loc_4.data + " to find event zone with search type " + _loc_4.type);
            }
            _loc_11 = null;
            switch(_loc_4.type)
            {
                case SPECIALIST_TASK_TYPES.FIND_ADVENTURE_ZONE_SHORT:
                {
                    _loc_11 = cSpecialistTask_FindEventZone.PERFORM_TASK_COSTS_SHORT_vector;
                    break;
                }
                case SPECIALIST_TASK_TYPES.FIND_ADVENTURE_ZONE_MEDIUM:
                {
                    _loc_11 = cSpecialistTask_FindEventZone.PERFORM_TASK_COSTS_MEDIUM_vector;
                    break;
                }
                case SPECIALIST_TASK_TYPES.FIND_ADVENTURE_ZONE_LONG:
                {
                    _loc_11 = cSpecialistTask_FindEventZone.PERFORM_TASK_COSTS_LONG_vector;
                    break;
                }
                default:
                {
                    gMisc.Assert(false, "Could not find perform costs for action type " + _loc_4.type);
                    break;
                }
            }
            _loc_12 = mCurrentPlayerZone.GetResourcesForPlayerID(_loc_6.GetPlayerID());
            if (_loc_12.HasPlayerResourcesInListOne(_loc_11))
            {
                _loc_12.RemovePlayerResourcesFromResourcesInList(_loc_11, 1);
                _loc_3 = new cSpecialistTask_FindEventZone(this, _loc_6, 0, TASK_PHASES_FIND_EVENT_ZONE.FIND_EVENT_ZONE, _loc_4.type);
            }
            else
            {
                if (mLog.isErrorEnabled(LOG_TYPE.SPECIALIST))
                {
                    mLog.logError(LOG_TYPE.SPECIALIST, "Player cannot afford task " + _loc_4.type);
                }
                return false;
            }
            ;
            
            if (_loc_4.grid == mCurrentViewedZoneID)
            {
                if (mLog.isErrorEnabled(LOG_TYPE.SPECIALIST))
                {
                    mLog.logError(LOG_TYPE.SPECIALIST, "Invalid destination zone for travelling (equal to home zone): " + _loc_4.grid + "!");
                }
                return false;
            }
            if (mLog.isInfoEnabled(LOG_TYPE.SPECIALIST))
            {
                mLog.logInfo(LOG_TYPE.SPECIALIST, "Ordered specialist " + _loc_4.data + " to travel to zone " + _loc_4.grid);
            }
            _loc_3 = new cSpecialistTask_TravelToZone(this, _loc_6, _loc_4.grid, 0, TASK_PHASES_TRAVEL_TO_ZONE.STRIKE_GARRISON);
            ;
            
            if (mLog.isInfoEnabled(LOG_TYPE.SPECIALIST))
            {
                mLog.logInfo(LOG_TYPE.SPECIALIST, "Ordered Specialist " + _loc_4.data + " to move to " + _loc_4.grid);
            }
            _loc_13 = _loc_4.grid;
            if (_loc_13 < 0)
            {
                if (mLog.isErrorEnabled(LOG_TYPE.SPECIALIST))
                {
                    mLog.logError(LOG_TYPE.SPECIALIST, "SPECIALIST_TASK_TYPES.MOVE: Invalid destination grid: " + _loc_13 + "!");
                }
                return false;
            }
            _loc_7 = mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_13].mSectorId;
            _loc_14 = mCurrentPlayerZone.mSectorList_vector[_loc_7].GetOwnerPlayerID();
            if (_loc_14 != 0 && _loc_14 != _loc_6.GetPlayerID())
            {
                _loc_20 = "Wants to set garrison in a sector which does not belong to him!";
                if (mLog.isErrorEnabled(LOG_TYPE.SPECIALIST))
                {
                    mLog.logError(LOG_TYPE.SPECIALIST, _loc_20);
                }
                return false;
            }
            _loc_15 = mCurrentPlayerZone.GetBuildingFromGridPosition(_loc_13);
            if (_loc_15 != null)
            {
                if (_loc_15.GetBuildingMode() == cBuilding.BUILDING_MODE_PLACED || _loc_15.GetBuildingName_string() == defines.MINEDEPOSITDEPLETEDCORN_NAME_string || _loc_15.GetBuildingName_string() == defines.MINEDEPOSITDEPLETEDWATER_NAME_string)
                {
                    mCurrentPlayerZone.mStreetDataMap.RemovePrePlaceBuildingGridPos(param1, _loc_13);
                }
                else
                {
                    if (mLog.isErrorEnabled(LOG_TYPE.SPECIALIST))
                    {
                        mLog.logError(LOG_TYPE.SPECIALIST, "Error building already set at position \'Garrison\' at " + _loc_13 + "!");
                    }
                    return false;
                }
            }
            _loc_3 = new cSpecialistTask_Move(this, _loc_6, _loc_13, 0, TASK_PHASES_MOVE.STRIKE_GARRISON);
            ;
            
            if (mLog.isInfoEnabled(LOG_TYPE.SPECIALIST))
            {
                mLog.logInfo(LOG_TYPE.SPECIALIST, "Ordered Specialist General to attack building at " + _loc_4.grid);
            }
            _loc_16 = _loc_4.grid;
            _loc_17 = _loc_4.endGrid;
            if (_loc_6.GetGarrisonGridIdx() == -1)
            {
                return false;
            }
            if (_loc_6.GetArmy() == null || !_loc_6.GetArmy().HasUnits())
            {
                return false;
            }
            _loc_18 = mCurrentPlayerZone.GetBuildingFromGridPosition(_loc_16);
            if (_loc_18 == null)
            {
                return false;
            }
            if (_loc_18.GetPlayerID() == param2.playerID)
            {
                return false;
            }
            _loc_7 = mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_16].mSectorId;
            if (FindPlayerFromId(_loc_6.GetPlayerID()).GetSectorDiscovery(_loc_7) != SECTOR_DISCOVERY_TYPE.EXPLORED)
            {
                return false;
            }
            _loc_19 = new cSpecialistTask_AttackBuilding(this, _loc_6, _loc_16, _loc_17, 0, TASK_PHASES_ATTACK_BUILDING.GO_TO_TARGET);
            if (_loc_19.GetDestinationPath().dest_vector.length == 0)
            {
                globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.GENERAL_CANNOT_REACH_TARGET);
                return false;
            }
            _loc_3 = _loc_19;
            _loc_3.PrepareTask();
            _loc_6.DisableWaitForCommandAnimation();
            ;
            
            return false;
        }// end function

        private function LoadZonefromStringfileLoadCompleteHandler(event:Event) : void
        {
            return;
        }// end function

        private function CalculateLogicOncePerSecond() : void
        {
            var _loc_4:cSpecialist = null;
            var _loc_1:* = mCurrentPlayerZone.GetSpecialists_vector();
            var _loc_2:* = _loc_1.length;
            var _loc_3:int = 0;
            while (_loc_3 < _loc_2)
            {
                
                _loc_4 = _loc_1[_loc_3];
                _loc_4.PerformTask();
                if (_loc_1.indexOf(_loc_4) == -1)
                {
                    _loc_3 = _loc_3 - 1;
                    _loc_2 = _loc_2 - 1;
                }
                _loc_3++;
            }
            mComputeResourceCreation.Compute();
            return;
        }// end function

        private function LoadZonefromString() : void
        {
            this.fileReferenceList = new FileReferenceList();
            this.fileReferenceList.addEventListener(Event.SELECT, this.LoadZonefromStringfileSelectHandler);
            this.fileReferenceList.browse([new FileFilter("Sector Files", "*.xml")]);
            return;
        }// end function

        private function HandleAcceptItemTradeResource(param1:cPlayerData, param2:dGameTickCommandVO) : void
        {
            gMisc.ConsoleOut("Accepting item trade resource " + param2.data + " at " + param2.time);
            var _loc_3:dBuffVO = null;
            _loc_3 = param2.data as dBuffVO;
            var _loc_4:* = cBuff.CreateBuffFromVO(_loc_3);
            this.mGameTickCommandPlayer.mAvailableBuffs_vector.push(_loc_4);
            globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.TRADE_ACCEPTED);
            return;
        }// end function

        private function ResetMovedBuilding(param1:cBuilding) : void
        {
            param1.SetBuildingMode(param1.GetBuildingModeBeforeMoving());
            var _loc_2:* = param1.GetResourceCreation();
            if (_loc_2 != null)
            {
                _loc_2.RestoreKIStateBeforeMoving();
            }
            return;
        }// end function

        private function HandleInviteToAdventure(param1:cPlayerData, param2:dGameTickCommandVO) : Boolean
        {
            if (mCurrentPlayerZone.mAdventure.GetCurrentPlayersCount() >= mCurrentPlayerZone.mAdventure.GetMaxPlayersCount())
            {
                globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.ADVENTURE_IS_FULL);
                return false;
            }
            var _loc_3:* = mCurrentPlayerZone.mAdventure;
            var _loc_4:* = param2.data as int;
            if (_loc_3.HasPlayerInAdventure(_loc_4))
            {
                globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.ADVENTURE_HAS_PLAYER_ALREADY);
                return false;
            }
            _loc_3.InviteAdventurePlayer(new dAdventurePlayerVO().Init(_loc_3.GetAdventureID(), _loc_4));
            globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.ADVENTURE_INVITATION_SENT);
            return true;
        }// end function

        private function GetUpdates(param1:cPlayerData) : void
        {
            var _loc_2:* = new dUpateVO();
            _loc_2.synchronisationClientTime = GetClientTime();
            if (param1.mIsPlayerZone)
            {
                _loc_2.synchronisationErrorBitField = mSynchronisationErrorBitField;
                _loc_2.zoneCheckVO = mZoneCheckUpdateVO;
            }
            else
            {
                _loc_2.synchronisationErrorBitField = 0;
                _loc_2.zoneCheckVO = null;
            }
            mSynchronisationErrorBitField = 0;
            mZoneCheckUpdateVO = null;
            if (!mGetUpdatesSend)
            {
                mClientMessages.SendMessagetoServer(COMMAND.GET_UPDATES, mCurrentViewedZoneID, _loc_2);
                mGetUpdatesSend = true;
            }
            return;
        }// end function

        override public function Render() : void
        {
            cSpriteLibContainer.ResetSwitchAntialiasingRenderCntr();
            var _loc_1:* = gMisc.GetTimeSinceStartup();
            if (this.mLastGfxDeltaTicksUpdate != -1)
            {
                this.mGfxDeltaTicks = _loc_1 - this.mLastGfxDeltaTicksUpdate;
            }
            else
            {
                this.mGfxDeltaTicks = 0;
            }
            this.mLastGfxDeltaTicksUpdate = _loc_1;
            if (!mActiveG)
            {
                return;
            }
            if (gMisc.PROFILE_ACTIVE)
            {
                gMisc.ProfilerStart("Render");
            }
            cBackbuffer.Lock();
            if (mCurrentPlayerZone.mClearBackGround)
            {
                if (gMisc.PROFILE_ACTIVE)
                {
                    gMisc.ProfilerStart("cBackbuffer.Clear");
                }
                cBackbuffer.Clear(mCurrentPlayerZone.CLEAR_COLOR);
                if (gMisc.PROFILE_ACTIVE)
                {
                    gMisc.ProfilerEnd("cBackbuffer.Clear");
                }
            }
            if (gMisc.PROFILE_ACTIVE)
            {
                gMisc.ProfilerStart("ScreenRender");
            }
            mCurrentPlayerZone.Render();
            if (gMisc.PROFILE_ACTIVE)
            {
                gMisc.ProfilerEnd("ScreenRender");
            }
            if (mOnScreenFps)
            {
                globalFlash.gui.WriteTextBig(cBackbuffer.mBackBuffer, mOnScreenHelpDisplay.CreateFPSText_string(), global.screenWidth - 100, global.screenHeight - 150);
            }
            mDebugTextXPos = 160;
            mDebugTextYPos = -5;
            var _loc_2:int = 10;
            if (mShowLocalDebugInfo >= 8)
            {
                var _loc_3:* = mDebugTextYPos + _loc_2;
                mDebugTextYPos = mDebugTextYPos + _loc_2;
                globalFlash.gui.WriteDebugText(cBackbuffer.mBackBuffer, "-- Local Client Info --", mDebugTextXPos, _loc_3);
                this.ShowPlayerInfo();
                this.ShowGameTickInfo();
                this.ShowIngameErrorMessages();
            }
            if (!mRenderScreen)
            {
                if (mCurrentPlayerZone.mClearBackGround)
                {
                    cBackbuffer.Clear(mCurrentPlayerZone.CLEAR_COLOR);
                }
            }
            cBackbuffer.Unlock();
            if (gMisc.PROFILE_ACTIVE)
            {
                gMisc.ProfilerStart("canvasBitmapFill");
            }
            RenderBackBufferToCanvas();
            if (gMisc.PROFILE_ACTIVE)
            {
                gMisc.ProfilerEnd("canvasBitmapFill");
            }
            if (gMisc.PROFILE_ACTIVE)
            {
                gMisc.ProfilerEnd("Render");
            }
            return;
        }// end function

        private function ShowAddtionalDebugGameInfo_string() : void
        {
            var _loc_1:String = "";
            var _loc_2:* = gMisc.ProfileInfoText_string();
            if (_loc_2 != null)
            {
                this.ShowDebugString(_loc_2);
            }
            this.ShowDebugString("-- Debug Info --");
            this.ShowDebugString("Zoom: " + Math.round(mZoom.GetScaleFactor()));
            this.ShowDebugString("ScrollPos: " + Math.round(mZoom.GetScrollPosX()) + "," + Math.round(mZoom.GetScrollPosY()));
            this.ShowDebugString("SmoothZoom: " + mZoom.mSmoothing + "SegmentCounter: " + cBackbuffer.mSegmentCounter + "NeededSegmentCounter: " + cBackbuffer.mNeededSegmentCounter);
            this.ShowDebugString("tempString: " + temp_string);
            this.ShowDebugString("MouseOverCanvas: " + Application.application.mMouseOverCanvas + " MouseMove: " + Application.application.mMouseMove);
            this.ShowDebugString("mActive: " + mActiveG);
            this.ShowDebugString("mComputeAndInputActive: " + mComputeAndInputActive);
            this.ShowDebugString("mCanvasFocused: " + Application.application.mCanvasFocused);
            this.ShowDebugString("mApplicationActive: " + Application.application.mApplicationActive);
            this.ShowDebugString("mIgnoreNextClick: " + Application.application.mIgnoreNextClick);
            this.ShowDebugString("Player XP: " + mCurrentPlayer.GetXP());
            this.ShowDebugString("Player PlayerLevel: " + mCurrentPlayer.GetPlayerLevel());
            this.ShowDebugString("Player CityLevel: " + mCurrentPlayer.GetCityLevel());
            this.ShowDebugString("Player Name: " + mCurrentPlayer.GetPlayerName_string());
            return;
        }// end function

        private function ShowGameTickInfo() : void
        {
            var _loc_2:dGameTickCommandVO = null;
            var _loc_1:int = 10;
            var _loc_3:* = mDebugTextYPos + _loc_1;
            mDebugTextYPos = mDebugTextYPos + _loc_1;
            globalFlash.gui.WriteDebugText(cBackbuffer.mBackBuffer, "-- GameTick Info --", mDebugTextXPos, _loc_3);
            for each (_loc_2 in mGameTickCommand_vector)
            {
                
                var _loc_5:* = mDebugTextYPos + _loc_1;
                mDebugTextYPos = mDebugTextYPos + _loc_1;
                globalFlash.gui.WriteDebugText(cBackbuffer.mBackBuffer, _loc_2.toString().replace("<dGameTickCommandVO ", "<").replace("</dGameTickCommandVO>\n", ""), mDebugTextXPos, _loc_5);
            }
            return;
        }// end function

        public function ProcessGameTickCommands(param1:dGameTickCommandVO) : void
        {
            var _loc_3:cBuilding = null;
            var _loc_4:dQuestElementVO = null;
            var _loc_5:int = 0;
            var _loc_6:dGameTickCommandVO = null;
            var _loc_7:cResources = null;
            var _loc_8:int = 0;
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            var _loc_11:int = 0;
            var _loc_12:cMilitaryUnitDescription = null;
            var _loc_13:dSpecialistResultVO = null;
            var _loc_2:dServerAction = null;
            this.mGameTickCommandPlayer = FindPlayerFromId(param1.playerID);
            if (this.mGameTickCommandPlayer == null)
            {
                return;
            }
            if (param1.mode != COMMAND.GAMETICK_REFRESH_COMMAND)
            {
                LocalLogMessageDetail("PGTC: playerID=" + param1.playerID + " mode=" + param1.mode + " data=" + param1.data);
            }
            switch(param1.mode)
            {
                case COMMAND.STOP_GAME:
                {
                    gMisc.Assert(false, "Game stopped");
                    break;
                }
                case COMMAND.SET_BUILDING_BY_BUFF:
                case COMMAND.SET_BUILDING_IN_GAME:
                {
                    this.HandleSetBuilding(this.mGameTickCommandPlayer, param1);
                    break;
                }
                case COMMAND.BUILDQUEUE_MOVE_UP:
                {
                    if (param1.data == null)
                    {
                        gErrorMessages.ShowInfoMessage("COMMAND.BUILDQUEUE_MOVE_UP: data is null!");
                        break;
                    }
                    this.mGameTickCommandPlayer.mBuildQueue.MoveUp(gMisc.ObjectToInt(param1.data));
                    break;
                }
                case COMMAND.BUILDQUEUE_MOVE_DOWN:
                {
                    if (param1.data == null)
                    {
                        gErrorMessages.ShowInfoMessage("COMMAND.BUILDQUEUE_MOVE_DOWN: data is null!");
                        break;
                    }
                    this.mGameTickCommandPlayer.mBuildQueue.MoveDown(gMisc.ObjectToInt(param1.data));
                    break;
                }
                case COMMAND.BUILDQUEUE_REMOVE:
                {
                    if (param1.data == null)
                    {
                        gErrorMessages.ShowInfoMessage("COMMAND.BUILDQUEUE_REMOVE: data is null!");
                        break;
                    }
                    this.mGameTickCommandPlayer.mBuildQueue.Remove(gMisc.ObjectToInt(param1.data));
                    break;
                }
                case COMMAND.SET_TASK:
                {
                    this.HandleSetTask(this.mGameTickCommandPlayer, param1);
                    break;
                }
                case COMMAND.QUEST_APPLY_REWARD_EFFECTS:
                {
                    if (IsCurrentPlayerQuestPlayer())
                    {
                        _loc_4 = param1.data as dQuestElementVO;
                        QuestManagerStatic.ApplyRewardEffects(this, _loc_4, this.mGameTickCommandPlayer);
                    }
                    break;
                }
                case COMMAND.QUEST_PAY_FOR_QUEST_FINISH:
                {
                    this.HandlePayForQuestFinish(this.mGameTickCommandPlayer, param1);
                    break;
                }
                case COMMAND.SPEEDMODE:
                {
                    _loc_5 = gMisc.ObjectToInt(param1.data);
                    mGlobalTimeScale = _loc_5;
                    for each (_loc_6 in mGameTickCommand_vector)
                    {
                        
                        _loc_6.time = param1.time + GameTickSystemPostProcessTime * mGlobalTimeScale;
                    }
                    break;
                }
                case COMMAND.RESOURCES_CHEAT:
                {
                    _loc_7 = mCurrentPlayerZone.GetResources(this.mGameTickCommandPlayer);
                    _loc_7.ApplyResourceListForCheat(param1.data as dResourcesVO);
                    break;
                }
                case COMMAND.SET_CITY_LEVEL:
                {
                    _loc_8 = this.mGameTickCommandPlayer.GetPlayerLevel();
                    _loc_9 = gMisc.ObjectToInt(param1.data);
                    if (_loc_9 > _loc_8)
                    {
                        _loc_10 = _loc_8;
                        while (_loc_10 < _loc_9)
                        {
                            
                            if (_loc_10 >= global.playerLevels_vector.length)
                            {
                                break;
                            }
                            _loc_11 = global.playerLevels_vector[_loc_10];
                            this.mGameTickCommandPlayer.AddXP(_loc_11 - this.mGameTickCommandPlayer.GetXP());
                            _loc_10++;
                        }
                    }
                    globalFlash.gui.mAvatar.SetData(this.mGameTickCommandPlayer, GetPlayerList_vector());
                    mCurrentPlayerZone.SetBackgroundHasChanged(true);
                    break;
                }
                case COMMAND.MAX_UNITS_CHEAT:
                {
                    for each (_loc_12 in cMilitaryUnitDescription.GetAllUnitDescriptions(false))
                    {
                        
                        mCurrentPlayerZone.GetArmy(mCurrentPlayer.GetPlayerId()).AddUnits(_loc_12.GetType_string(), 10000, true);
                    }
                    break;
                }
                case COMMAND.ADD_HARD_CURRENCY:
                {
                    this.HandleAddHardCurrency(this.mGameTickCommandPlayer, param1);
                    break;
                }
                case COMMAND.RETREAT:
                {
                    this.HandleRetreat(this.mGameTickCommandPlayer, param1);
                    break;
                }
                case COMMAND.APPLY_CASUALTIES:
                {
                    this.HandleApplyCasualty(this.mGameTickCommandPlayer, param1);
                    break;
                }
                case COMMAND.ACCEPT_LOOT:
                {
                    this.HandleAcceptLoot(this.mGameTickCommandPlayer, param1);
                    break;
                }
                case COMMAND.INVITE_TO_ADVENTURE:
                {
                    this.HandleInviteToAdventure(this.mGameTickCommandPlayer, param1);
                    break;
                }
                case COMMAND.ACCEPT_ADVENTURE_INVITATION:
                {
                    this.HandleAcceptAdventureInvitation(this.mGameTickCommandPlayer, param1);
                    break;
                }
                case COMMAND.DECLINE_ADVENTURE_INVITATION:
                {
                    this.HandleDeclineAdventureInvitation(this.mGameTickCommandPlayer, param1);
                    break;
                }
                case COMMAND.BUY_ONE_CLICK_SHOP_ITEM:
                {
                    this.HandleBuyOneClickShopItem(this.mGameTickCommandPlayer, param1);
                    break;
                }
                case COMMAND.RAISE_ARMY:
                {
                    this.HandleRaiseArmy(this.mGameTickCommandPlayer, param1);
                    break;
                }
                case COMMAND.ACCEPT_TRADE:
                {
                    this.HandleAcceptTrade(this.mGameTickCommandPlayer, param1);
                    break;
                }
                case COMMAND.BUY_SPECIALIST:
                {
                    _loc_13 = param1.data as dSpecialistResultVO;
                    this.BuySpecialistDirect(this.mGameTickCommandPlayer, _loc_13.type, _loc_13.uniqueID, _loc_13.withCosts);
                    break;
                }
                case COMMAND.APPLY_BUFF:
                {
                    this.HandleApplyBuff(this.mGameTickCommandPlayer, param1);
                    break;
                }
                case COMMAND.APPLY_LOOTTABLE_BUFF:
                {
                    this.HandleApplyLoottableBuff(this.mGameTickCommandPlayer, param1);
                    break;
                }
                case COMMAND.REMOVE_BUFF:
                {
                    this.HandleRemoveBuff(this.mGameTickCommandPlayer, param1);
                    break;
                }
                case COMMAND.START_TIMED_PRODUCTION:
                {
                    this.HandleStartTimedProduction(this.mGameTickCommandPlayer, param1);
                    break;
                }
                case COMMAND.BUY_SHOP_ITEM:
                {
                    this.HandleBuyShopItem(param1);
                    break;
                }
                case COMMAND.DESTRUCT_BUILDING:
                {
                    this.HandleDestructBuilding(param1);
                    break;
                }
                case COMMAND.INITIATE_TRADE:
                {
                    this.HandleInitiateTrade(this.mGameTickCommandPlayer, param1);
                    break;
                }
                case COMMAND.UPGRADE_BUILDING:
                {
                    if (param1.data == null)
                    {
                        gErrorMessages.ShowInfoMessage("COMMAND.UPGRADE_BUILDING: data is null!");
                        break;
                    }
                    mCurrentPlayerZone.mStreetDataMap.UpgradeBuildingGridPos(this.mGameTickCommandPlayer, gMisc.ObjectToInt(param1.data));
                    break;
                }
                case COMMAND.STOP_PRODUCTION:
                {
                    _loc_2 = param1.data as dServerAction;
                    _loc_3 = mCurrentPlayerZone.GetBuildingFromGridPosition(_loc_2.grid);
                    _loc_3.SetProductionActive(_loc_2.type == 1 ? (true) : (false));
                    break;
                }
                case COMMAND.GAMETICK_REFRESH_COMMAND:
                {
                    this.GameTickRefresh(this.mGameTickCommandPlayer);
                    SetGameTickRefreshCommand(this.mGameTickCommandPlayer);
                    break;
                }
                case COMMAND.INITIATE_ITEM_TRADE:
                {
                    this.HandleInitiateItemTrade(this.mGameTickCommandPlayer, param1);
                    break;
                }
                case COMMAND.ACCEPT_ITEM_TRADE:
                {
                    this.HandleAcceptItemTrade(this.mGameTickCommandPlayer, param1);
                    break;
                }
                case COMMAND.ADD_ITEM_TRADE_RESOURCE:
                {
                    this.HandleAcceptItemTradeResource(this.mGameTickCommandPlayer, param1);
                    break;
                }
                case COMMAND.CHANGE_GAMEPLAY_PARAMETER:
                {
                    this.HandleChangeGameplayParameter(this.mGameTickCommandPlayer, param1);
                    break;
                }
                case COMMAND.REMOVE_TEMP_BUILD_SLOT:
                {
                    this.RemoveTemporaryBuildSlot(this.mGameTickCommandPlayer, param1);
                    break;
                }
                case COMMAND.INIT_CHAT:
                {
                    mClientMessages.InitChat();
                    break;
                }
                case COMMAND.RECONNECT_TO_CHAT:
                {
                    if (globalFlash.gui.mChatPanel.IsConnectionEstablished())
                    {
                        break;
                    }
                    mClientMessages.SendMessagetoServer(COMMAND.RECONNECT_TO_CHAT, global.ui.mCurrentPlayer.GetPlayerId(), null);
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

        override public function MouseDown(event:MouseEvent) : void
        {
            if (!IsActiveAndInputActive())
            {
                return;
            }
            mMousePressed = true;
            mCurrentPlayerZone.MouseDown(event);
            return;
        }// end function

        private function HandleSetBuilding(param1:cPlayerData, param2:dGameTickCommandVO) : void
        {
            var _loc_10:cBuff = null;
            var _loc_3:* = param2.data as dServerAction;
            if (!gCalculations.IsGridInsideMap(_loc_3.grid))
            {
                LocalLogMessageDetail("P " + param1.GetPlayerId() + ": Error could not set building #" + _loc_3.type + " at " + _loc_3.grid + "\' because position is illegal!");
                return;
            }
            if (param2.mode != COMMAND.SET_BUILDING_BY_BUFF)
            {
                if (this.mGameTickCommandPlayer.mBuildQueue.IsBuildingAtGridPositionInQueue(_loc_3.grid))
                {
                    LocalLogMessageDetail("P " + param1.GetPlayerId() + ": Duplicate grid entry in buildqueue: " + _loc_3.grid + "!");
                    return;
                }
            }
            var _loc_4:* = mCurrentPlayerZone.GetBuildingFromGridPosition(_loc_3.grid);
            if (mCurrentPlayerZone.GetBuildingFromGridPosition(_loc_3.grid) != null)
            {
                if (_loc_4.GetBuildingMode() == cBuilding.BUILDING_MODE_PLACED)
                {
                    mCurrentPlayerZone.mStreetDataMap.RemovePrePlaceBuildingGridPos(this.mGameTickCommandPlayer, _loc_3.grid);
                }
                else
                {
                    LocalLogMessageDetail("P " + param1.GetPlayerId() + ": Could not set building #" + _loc_3.type + " because there is already a building at position " + _loc_3.grid + "!");
                    return;
                }
            }
            var _loc_5:* = global.buildingGroup.GetNameFromNr_string(global.buildingGroup.mGOList_vector, _loc_3.type);
            if (param2.mode != COMMAND.SET_BUILDING_BY_BUFF)
            {
                if (this.mGameTickCommandPlayer.mBuildQueue.IsFull())
                {
                    LocalLogMessageDetail("P " + param1.GetPlayerId() + ": Error could not set \'" + _loc_5 + "\' at " + _loc_3.grid + " because buildqueue is full!");
                    return;
                }
                if (this.mGameTickCommandPlayer.IsMaximumBuildingCountReached(_loc_5))
                {
                    LocalLogMessageDetail("P " + param1.GetPlayerId() + ": Could not set \'" + _loc_5 + "\' at " + _loc_3.grid + " because maximum building limit is reached!");
                    return;
                }
            }
            var _loc_6:cBuff = null;
            var _loc_7:int = -1;
            if (param2.mode == COMMAND.SET_BUILDING_BY_BUFF)
            {
                _loc_7 = 0;
                while (_loc_7 < this.mGameTickCommandPlayer.mAvailableBuffs_vector.length)
                {
                    
                    _loc_10 = this.mGameTickCommandPlayer.mAvailableBuffs_vector[_loc_7];
                    if (_loc_10.GetUniqueId().equals(_loc_3.data))
                    {
                        _loc_6 = this.mGameTickCommandPlayer.mAvailableBuffs_vector[_loc_7];
                        break;
                    }
                    _loc_7++;
                }
                if (_loc_6 == null)
                {
                    LocalLogMessageDetail("Could not find buff " + _loc_3.data + "!");
                    return;
                }
            }
            var _loc_8:* = cBuilding.CreateFromString(this.mGameTickCommandPlayer, global.buildingGroup, _loc_5, this);
            if (cBuilding.CreateFromString(this.mGameTickCommandPlayer, global.buildingGroup, _loc_5, this) == null)
            {
                LocalLogMessageDetail("Error could not set A \'" + _loc_5 + " at " + _loc_3.grid + " time: " + GetClientTime() + "\' could not create building!");
                return;
            }
            if (_loc_8.GetGOContainer().mPlayerLevel > this.mGameTickCommandPlayer.GetPlayerLevel() && param2.mode != COMMAND.SET_BUILDING_BY_BUFF)
            {
                LocalLogMessageDetail("Error could not set \'" + _loc_5 + " at " + _loc_3.grid + " time: " + GetClientTime() + "\' because playerLevel is to low!");
                return;
            }
            var _loc_9:* = mCurrentPlayerZone.IsBuildingPlacableGridPosition(_loc_8, this.mGameTickCommandPlayer, _loc_3.grid);
            if (mCurrentPlayerZone.IsBuildingPlacableGridPosition(_loc_8, this.mGameTickCommandPlayer, _loc_3.grid) != 0)
            {
                LocalLogMessageDetail("Error could not set B \'" + _loc_5 + " at " + _loc_3.grid + " time: " + GetClientTime() + "\' invalid build pos IsBuildingPlacableGridPosition!");
                return;
            }
            _loc_8 = mCurrentPlayerZone.SetGoAtGridPosition(this.mGameTickCommandPlayer, _loc_8, OBJECTTYPE.BUILDING, _loc_3.grid) as cBuilding;
            if (_loc_8 == null)
            {
                LocalLogMessageDetail("Error could not set A \'" + _loc_5 + " at " + _loc_3.grid + " time: " + GetClientTime() + "\' invalid build pos!");
                return;
            }
            _loc_8.mDirtyIndicator = _loc_8.mDirtyIndicator | DIRTY_INDICATOR.CREATED_BIT;
            if (_loc_8.GetResourceCreation() != null)
            {
                _loc_8.GetResourceCreation().mDirtyIndicator = _loc_8.GetResourceCreation().mDirtyIndicator | DIRTY_INDICATOR.CREATED_BIT;
            }
            if (param2.mode == COMMAND.SET_BUILDING_BY_BUFF)
            {
                _loc_8.SetBuildingMode(cBuilding.BUILDING_MODE_SET_BUILDING_GROUND_PLACE);
            }
            else
            {
                this.mGameTickCommandPlayer.mBuildQueue.Add(_loc_8);
                this.mGameTickCommandPlayer.IncBuildingCountAll(_loc_8, true);
            }
            if (_loc_6 != null)
            {
                _loc_8.mOrigin = cBuilding.BUILDING_ORIGIN_FROM_BUFF;
                if (gMisc.GetRandomMinMaxInt(1, 100) <= _loc_6.GetRecurrentChance())
                {
                    _loc_8.SetRecurringBuff(_loc_6.CreateBuffVOFromBuff());
                }
                this.mGameTickCommandPlayer.mAvailableBuffs_vector.splice(_loc_7, 1);
                _loc_6.DecWaitingForServerCount();
                if (this.mGameTickCommandPlayer.GetPlayerId() == mHomePlayer.GetPlayerId())
                {
                    globalFlash.gui.mStarMenu.Refresh();
                }
            }
            else
            {
                _loc_8.mOrigin = cBuilding.BUILDING_ORIGIN_FROM_GAME;
            }
            LocalLogMessageDetail("P " + param1.GetPlayerId() + ": Building \'" + _loc_5 + "\' set at " + _loc_3.grid + " time: " + GetClientTime());
            return;
        }// end function

        private function ShowIngameErrorMessages() : void
        {
            var _loc_4:String = null;
            var _loc_1:int = 10;
            var _loc_5:* = mDebugTextYPos + _loc_1;
            mDebugTextYPos = mDebugTextYPos + _loc_1;
            globalFlash.gui.WriteDebugText(cBackbuffer.mBackBuffer, "-- Logs  (" + mInGameErrorMessagesLog_vector.length + ") (home+mouse=scroll)--", mDebugTextXPos, _loc_5);
            var _loc_2:* = (mInGameErrorMessagesLog_vector.length - 1) - mLogScrollPos;
            var _loc_3:int = 0;
            while (_loc_3 < mLogScrollPosLen)
            {
                
                if (_loc_2 >= 0 && _loc_2 < mInGameErrorMessagesLog_vector.length)
                {
                    _loc_4 = mInGameErrorMessagesLog_vector[_loc_2];
                    var _loc_5:* = mDebugTextYPos + _loc_1;
                    mDebugTextYPos = mDebugTextYPos + _loc_1;
                    globalFlash.gui.WriteDebugText(cBackbuffer.mBackBuffer, _loc_2 + ") " + _loc_4, mDebugTextXPos, _loc_5);
                    _loc_2 = _loc_2 - 1;
                }
                _loc_3++;
            }
            return;
        }// end function

        private function HandleDestructBuilding(param1:dGameTickCommandVO) : Boolean
        {
            if (param1.data == null)
            {
                return false;
            }
            var _loc_2:* = gMisc.ObjectToInt(param1.data);
            if (_loc_2 == defines.ILLEGAL_INT_POS)
            {
                return false;
            }
            var _loc_3:* = mCurrentPlayerZone.GetBuildingFromGridPosition(_loc_2);
            if (_loc_3 == null)
            {
                return false;
            }
            mCurrentPlayerZone.mStreetDataMap.DeconstructBuildingGridPos(_loc_2);
            return true;
        }// end function

        private function HandleAcceptTrade(param1:cPlayerData, param2:dGameTickCommandVO) : Boolean
        {
            var resources:cResources;
            var tradeAccepted:Boolean;
            var _playerData:* = param1;
            var _gameTickCommand:* = param2;
            gMisc.ConsoleOut("Accepting trade " + _gameTickCommand.data + " at " + _gameTickCommand.time);
            var tradeVO:dTradeVO;
            try
            {
                tradeVO = _gameTickCommand.data as dTradeVO;
                resources = mCurrentPlayerZone.GetResources(this.mGameTickCommandPlayer);
                if (resources.HasPlayerResource(tradeVO.resourceToDeduct.name_string, tradeVO.resourceToDeduct.amount))
                {
                    tradeAccepted;
                    if (tradeAccepted)
                    {
                        resources.AddResource(tradeVO.resourceToDeduct.name_string, -tradeVO.resourceToDeduct.amount);
                        resources.AddResource(tradeVO.resourceToAdd.name_string, tradeVO.resourceToAdd.amount);
                        globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.TRADE_ACCEPTED);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (error:Error)
            {
                gMisc.ConsoleOut("A database error ocurred while accepting trade: " + error);
            }
            return true;
        }// end function

        override public function MouseWheel(event:MouseEvent) : void
        {
            if (!IsActiveAndInputActive())
            {
                return;
            }
            mCurrentPlayerZone.MouseWheel(event);
            return;
        }// end function

        public function ActivateChatWindow(param1:Boolean) : void
        {
            this.mChatWindowActive = param1;
            return;
        }// end function

        private function SaveServerDebugMessagesToFile() : void
        {
            if (mCurrentAsciiZone == null)
            {
                gMisc.MessageBox("No Zone converted!");
                return;
            }
            var _loc_1:* = new FileReference();
            _loc_1.save(mCurrentAsciiZone, "ServerZone.txt");
            return;
        }// end function

        override public function ApplicationResized() : void
        {
            cBackbuffer.Init(global.screenWidth, global.screenHeight, false);
            this.ZoomHasChanged();
            return;
        }// end function

        public function ServerLoadedFinished() : void
        {
            globalFlash.gui.mNewsWindow.Show();
            if (!defines.USE_BIG_BROTHER)
            {
                mClientMessages.SendMessagetoServer(COMMAND.GET_ZONE, mCurrentViewedZoneID, false);
            }
            return;
        }// end function

        private function HandleInitiateTrade(param1:cPlayerData, param2:dGameTickCommandVO) : Boolean
        {
            if (param2.data == null)
            {
                return false;
            }
            var _loc_3:* = param2.data as dTradeOfferVO;
            var _loc_4:* = mCurrentPlayerZone.GetResources(param1);
            if (!mCurrentPlayerZone.GetResources(param1).HasPlayerResource(_loc_3.offer.name_string, _loc_3.offer.amount))
            {
                CustomAlert.show("CannotAffordSendTrade", "CannotAffordSendTrade");
                return false;
            }
            _loc_4.AddResource(_loc_3.offer.name_string, -_loc_3.offer.amount);
            return true;
        }// end function

        private function ShowDebugString(param1:String) : void
        {
            var _loc_2:* = mDebugTextYPos + 10;
            mDebugTextYPos = mDebugTextYPos + 10;
            globalFlash.gui.WriteDebugText(cBackbuffer.mBackBuffer, param1, mDebugTextXPos, _loc_2);
            return;
        }// end function

        public function UpdateGuiOnZoneLoad() : void
        {
            mCurrentCursor.SetCursorEditMode(COMMAND.SELECT_BUILDING);
            globalFlash.gui.UpdateGuiOnZoneLoad();
            return;
        }// end function

        private function HandleChangeGameplayParameter(param1:cPlayerData, param2:dGameTickCommandVO) : Boolean
        {
            var _loc_3:* = gMisc.ObjectToInt(param2.data);
            if (_loc_3 != -1)
            {
                if (_loc_3 >= 0 && _loc_3 <= 3)
                {
                    LocalLogMessage("changed UpdateFrequency HandleChangeGameplayParameter: " + _loc_3);
                    this.mUpdateFrequenceTyp = _loc_3;
                }
                else
                {
                    LocalLogMessage("unknown HandleChangeGameplayParameter: " + _loc_3);
                }
            }
            return true;
        }// end function

        private function HandlePayForQuestFinish(param1:cPlayerData, param2:dGameTickCommandVO) : void
        {
            var _loc_3:dQuestElementVO = null;
            var _loc_4:Boolean = false;
            var _loc_5:cResources = null;
            var _loc_6:Vector.<dResource> = null;
            var _loc_7:int = 0;
            var _loc_8:dQuestDefinitionTriggerVO = null;
            var _loc_9:dResource = null;
            if (IsCurrentPlayerQuestPlayer())
            {
                _loc_3 = param2.data as dQuestElementVO;
                _loc_4 = true;
                _loc_5 = mCurrentPlayerZone.GetResources(param1);
                _loc_6 = new Vector.<dResource>;
                _loc_7 = 0;
                while (_loc_7 < _loc_3.mQuestDefinition.questTriggers_vector.length)
                {
                    
                    _loc_8 = _loc_3.mQuestDefinition.questTriggers_vector[_loc_7];
                    if (_loc_3.GetTriggerStatus(_loc_7) == 0 && _loc_8.type == QuestManagerStatic.TYPE_PAY_FOR_QUEST_FINISH)
                    {
                        if (_loc_5.HasPlayerResource(_loc_8.name_string, _loc_8.amount))
                        {
                            _loc_9 = new dResource();
                            _loc_9.name_string = _loc_8.name_string;
                            _loc_9.amount = _loc_8.amount;
                            _loc_6.push(_loc_9);
                        }
                        else
                        {
                            _loc_4 = false;
                            break;
                        }
                    }
                    _loc_7++;
                }
                if (_loc_4 && _loc_6.length > 0)
                {
                    _loc_5.RemovePlayerResourcesFromResourcesInList(_loc_6, 1);
                    _loc_3.SetAllTriggersToWon(QuestManagerStatic.TYPE_PAY_FOR_QUEST_FINISH);
                    _loc_3.SetQuestMode(QuestManagerStatic.QUEST_MODE_PRESS_REWARD_BUTTON);
                }
            }
            return;
        }// end function

        public function forceDatabaseUpdate(param1:String) : void
        {
            this.mLastUpdateCounter = -1000;
            return;
        }// end function

        override public function KeyDownAlways(event:KeyboardEvent) : void
        {
            if (!IsActiveAndInputActive())
            {
                return;
            }
            if (event.charCode == gMisc.AsciiKeyCode("q"))
            {
                if (mShowLocalDebugInfo != 8)
                {
                    if (mShowLocalDebugInfo == 0)
                    {
                        mShowLocalDebugInfo = 1;
                    }
                    else
                    {
                        mShowLocalDebugInfo = 0;
                    }
                }
            }
            if (event.charCode == gMisc.AsciiKeyCode("u"))
            {
                if (mShowLocalDebugInfo != 8)
                {
                    if (mShowLocalDebugInfo == 1)
                    {
                        mShowLocalDebugInfo = 2;
                    }
                    else
                    {
                        mShowLocalDebugInfo = 0;
                    }
                }
            }
            if (event.charCode == gMisc.AsciiKeyCode("x"))
            {
                if (mShowLocalDebugInfo != 8)
                {
                    if (mShowLocalDebugInfo == 2)
                    {
                        mShowLocalDebugInfo = 3;
                    }
                    else
                    {
                        mShowLocalDebugInfo = 0;
                    }
                }
            }
            if (event.charCode == gMisc.AsciiKeyCode("o"))
            {
                if (mShowLocalDebugInfo != 8)
                {
                    if (mShowLocalDebugInfo == 3)
                    {
                        mShowLocalDebugInfo = 4;
                    }
                    else
                    {
                        mShowLocalDebugInfo = 0;
                    }
                }
            }
            if (event.charCode == gMisc.AsciiKeyCode("r"))
            {
                if (mShowLocalDebugInfo != 8)
                {
                    if (mShowLocalDebugInfo == 4)
                    {
                        mShowLocalDebugInfo = 5;
                    }
                    else
                    {
                        mShowLocalDebugInfo = 0;
                    }
                }
            }
            if (event.charCode == gMisc.AsciiKeyCode("0"))
            {
                if (mShowLocalDebugInfo != 8)
                {
                    if (mShowLocalDebugInfo == 5)
                    {
                        mShowLocalDebugInfo = 6;
                    }
                    else
                    {
                        mShowLocalDebugInfo = 0;
                    }
                }
            }
            if (event.charCode == gMisc.AsciiKeyCode("1"))
            {
                if (mShowLocalDebugInfo != 8)
                {
                    if (mShowLocalDebugInfo == 6)
                    {
                        mShowLocalDebugInfo = 7;
                    }
                    else
                    {
                        mShowLocalDebugInfo = 0;
                    }
                }
            }
            if (event.charCode == gMisc.AsciiKeyCode("7"))
            {
                if (mShowLocalDebugInfo != 8)
                {
                    if (mShowLocalDebugInfo == 7)
                    {
                        mShowLocalDebugInfo = 8;
                    }
                    else
                    {
                        mShowLocalDebugInfo = 0;
                    }
                }
            }
            return;
        }// end function

        override public function FocusOutHandler(event:FocusEvent) : void
        {
            if (!mActiveG || globalFlash.gui.mCameraControlPanel.PositionIsOverGuiElement())
            {
                return;
            }
            this.ResetScrolling();
            return;
        }// end function

        private function HandleAddHardCurrency(param1:cPlayerData, param2:dGameTickCommandVO) : Boolean
        {
            var _loc_3:* = param2.data as dHardCurrencyPurchased;
            mCurrentPlayerZone.GetResources(param1).AddResource(defines.HARD_CURRENCY_RESOURCE_NAME_string, _loc_3.mAmount);
            return true;
        }// end function

        override public function MouseMove(event:MouseEvent) : void
        {
            if (!IsActiveAndInputActive())
            {
                return;
            }
            mCurrentPlayerZone.MouseMove(event);
            return;
        }// end function

        override public function SelectBuilding(param1:cBuilding) : void
        {
            var _loc_2:cSpecialist = null;
            var _loc_3:cSpecialist = null;
            var _loc_4:cBasicInfoPanel = null;
            if (param1 == null)
            {
                return;
            }
            mCurrentlySelectededBuilding = param1;
            cSoundManager.GetInstance().PlayEffect("SelectBuilding", param1.GetBuildingName_string());
            if (param1.GetPlayerID() != mCurrentPlayer.GetPlayerId())
            {
                globalFlash.gui.mEnemyBuildingInfoPanel.SetData(param1);
                globalFlash.gui.mEnemyBuildingInfoPanel.Show();
            }
            else if (param1.GetBuildingName_string() == defines.GARRISON_NAME_string)
            {
                if (param1.IsBuildingActive())
                {
                    _loc_2 = null;
                    for each (_loc_3 in mCurrentPlayerZone.GetSpecialists_vector())
                    {
                        
                        if (_loc_3.GetGarrison() == param1)
                        {
                            _loc_2 = _loc_3;
                            break;
                        }
                    }
                    if (_loc_2 != null)
                    {
                        globalFlash.gui.mSpecialistPanel.SetData(_loc_2);
                        globalFlash.gui.mSpecialistPanel.Show();
                    }
                    else
                    {
                        gMisc.Assert(false, "There is a garrison without general: " + param1);
                    }
                }
                else
                {
                    gMisc.ConsoleOut("Cannot manage army whose garrison is not ready. TODO: Create a special window.");
                }
            }
            else if (param1.GetBuildingMode() == cBuilding.BUILDING_MODE_MOVING)
            {
            }
            else if (!param1.IsBuildingActive())
            {
                globalFlash.gui.mConstructionInfoPanel.SetData(param1);
                globalFlash.gui.mConstructionInfoPanel.Show();
            }
            else
            {
                _loc_4 = globalFlash.gui.GetInfoPanel(param1.GetBuildingName_string());
                _loc_4.SetData(param1);
                _loc_4.Show();
            }
            mCurrentlySelectededBuilding = param1;
            mQuestClientCallbacks.BuildingSelectedGui(param1);
            return;
        }// end function

        public function IsChatWindowActive() : Boolean
        {
            return this.mChatWindowActive;
        }// end function

        override public function KeyDownOnMap(event:KeyboardEvent) : void
        {
            super.KeyDownOnMap(event);
            if (event.target is TextArea || event.target is TextInput || event.target is UITextField)
            {
                return;
            }
            if (event.keyCode == Keyboard.LEFT || event.charCode == gMisc.AsciiKeyCode("a"))
            {
                scroll = defines.SCROLL_LEFT;
            }
            if (event.keyCode == Keyboard.RIGHT || event.charCode == gMisc.AsciiKeyCode("d"))
            {
                scroll = defines.SCROLL_RIGHT;
            }
            if (event.keyCode == Keyboard.UP || event.charCode == gMisc.AsciiKeyCode("w"))
            {
                scroll = defines.SCROLL_UP;
            }
            if (event.keyCode == Keyboard.DOWN || event.charCode == gMisc.AsciiKeyCode("s"))
            {
                scroll = defines.SCROLL_DOWN;
            }
            if (!IsActiveAndInputActive() || this.mChatWindowActive)
            {
                return;
            }
            if (event.keyCode == Keyboard.ENTER)
            {
                if (!this.mChatWindowActive)
                {
                    Application.application.GAMESTATE_ID_CHAT_PANEL.handleClick(null);
                }
            }
            mCurrentPlayerZone.KeyDown(event);
            return;
        }// end function

        private function RemoveTemporaryBuildSlot(param1:cPlayerData, param2:dGameTickCommandVO) : Boolean
        {
            var _loc_3:* = (param2.data as dTempBuildSlotVO).timeOfPurchase;
            var _loc_4:dTempBuildSlotVO = null;
            var _loc_5:* = param1.mAvailableTempSlots_vector;
            var _loc_6:int = 0;
            while (_loc_6 < _loc_5.length && _loc_4 == null)
            {
                
                if (_loc_5[_loc_6].timeOfPurchase == _loc_3)
                {
                    _loc_4 = _loc_5[_loc_6];
                    break;
                }
                _loc_6++;
            }
            if (_loc_4 != null)
            {
                param1.mAvailableTempSlots_vector.splice(_loc_6, 1);
                globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.TEMP_BUILD_SLOT_REMOVED);
            }
            return true;
        }// end function

    }
}
