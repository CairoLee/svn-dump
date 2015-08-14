package Interface
{
    import BuffSystem.*;
    import Communication.VO.*;
    import Communication.VO.Guild.*;
    import Enums.*;
    import GO.*;
    import Map.*;
    import MilitarySystem.*;
    import NewQuestSystem.Client.*;
    import NewQuestSystem.Server.*;
    import PathFinding.*;
    import ServerOnly.*;
    import ServerSimulation.*;
    import ServerState.*;
    import Specialists.*;
    import Text.*;
    import __AS3__.vec.*;
    import flash.events.*;
    import flash.geom.*;
    import flash.system.*;
    import flash.utils.*;
    import mx.core.*;
    import mx.events.*;
    import mx.formatters.*;
    import nLib.*;
    import unitTest.*;

    public class cGeneralInterface extends Object implements IEventDispatcher
    {
        public var CHEAT_KEYS:Boolean = false;
        public var mClientMessages:cClientMessagesII;
        public var mTriggerEffects:TriggerActions;
        public var mGetUpdatesSend:Boolean;
        protected var mStreamingPhase:int = 0;
        public var mQuestClientCallbacks:QuestClientCallbacks;
        public var mServer:cServer;
        public const mGameTickCommand_vector:Vector.<dGameTickCommandVO>;
        public var mZoneMapName:String = null;
        public var mCurrentlySelectededBuilding:cBuilding = null;
        public var mLastGameTickRefreshClientTime:Number = 0;
        public var mLastServerResponse:Vector.<dServerResponse>;
        public var showCursorDebugInfo:Boolean = false;
        public var mBackgroundCursorRed:cGO = null;
        public var mShowIngameDetailErrorLog:Boolean = false;
        public var mServerSimulation:cServerSimulation;
        public var SHOW_DEBUG_TEXT:Boolean = false;
        public var mTestKI:cTestKI;
        public var mComputeResourceCreation:cComputeResourceCreation;
        public var mBirthTime:Number = 0;
        private var mDepositType:int;
        public var mShowLocalDebugInfo:int = 0;
        public var mIntP:cPosInt;
        public var mStreetCursorYellow:cGO = null;
        public var mSetStreets:cSetStreets;
        public var mLastServerResponseRead:Boolean = false;
        public var mSynchronisationErrorBitField:int = 0;
        public var mStreetCursorGreen:cGO = null;
        public var showBuildingDebugGrid:Boolean = false;
        public var mOnScreenHelpDisplay:cOnScreenHelpDisplay;
        public var mStreetCursorRed:cGO = null;
        public var mLogScrollPos:int = 0;
        public var mEnumUIType:int;
        public var mCalculateTicks:cCalculateTicks;
        protected var mInGameErrorMessagesLogDetail_vector:Vector.<String>;
        public var mCalculateEconomy:Boolean = true;
        private var mGameClientTime:Number = 0;
        public var mWobbling:Number = 0;
        public var showSectorGrid:Boolean = false;
        public const DEPOSIT_TYPE_SINGLE:int = 0;
        protected var mRenderScreen:Boolean;
        public var mStreetCursorGrid:cGO = null;
        public var showBlockingGrid:Boolean = false;
        public var showDepositMap:Boolean = false;
        public var mCurrentCursor:cCursor = null;
        public var mComputeAndInputActive:Boolean = false;
        public var mMousePressed:Boolean = false;
        public var showCostMatrix:Boolean = false;
        public var scroll:int = 0;
        public var showIsoDebugGrid:Boolean = false;
        public var mStreetPathCursor:cGO = null;
        private var _bindingEventDispatcher:EventDispatcher;
        public var mActiveG:Boolean = false;
        public var temp_string:String = "";
        public var mCheckZoneHomePlayerLevel:int = -1;
        public var temp2:int;
        public var temp3:int;
        public var temp4:int;
        public var mDetailLogScrollPosLen:int = 15;
        public var showWatchAreas:Boolean = false;
        protected var mFadeInCntr:Number;
        protected var mBlackScreenTimeout:Number;
        public var mClientDeltaTime:int = 0;
        public var mSynchronizeZone:dZoneVO = null;
        public var mSpoolingIsActive:Boolean = false;
        public var mHomePlayer:cPlayerData;
        public var mConnectionLost:int = 0;
        public var mBorder:cGO = null;
        public var mLastSynchronizetime:Number = 0;
        public var mPathFinder:cPathFinder;
        public var mSetBuildings:cSetBuildings;
        public var mDetailLogScrollPosLastMouseY:int = -1;
        public var mFog:cGO = null;
        public var mOnScreenFps:Boolean;
        public var mShowOnScreenInfoGameTickCommands:Boolean = true;
        protected var mInGameErrorMessagesLog_vector:Vector.<String>;
        public var mIsBuffOnFriendQuestActive:Boolean = false;
        public var mLogScrollPosLastMouseY:int = -1;
        public var mRenderBuildingShadows:Boolean = true;
        private var _617771443mCurrentPlayer:cPlayerData = null;
        private var mTempDate:Date;
        public var mZoneCheckUpdateVO:dZoneCheckVO = null;
        protected var mDateFormatter:DateFormatter;
        public var mWobblingInt:int = 0;
        public var mCurrentViewedZoneID:int = 0;
        public var GameTickSystemPostProcessTime:Number = 2500;
        public var mLocalNLibInterface:cLocalNLibInterface;
        public var GameTickPeriodicRefreshTime:Number = 1000;
        public var mMouseCursorSecondary:cCursor;
        public var mRefreshZoneIsActive:Boolean = false;
        public var mShowOnScreenInfoPlayer:Boolean = true;
        public const DEPOSIT_TYPE_GROUP:int = 1;
        protected var mBackGroundIsStreamed:Boolean;
        public var mShowIngameErrorLog:Boolean = true;
        public var mP:Point;
        public var mLogScrollPosLen:int = 15;
        public var mLastServerResponseII:Vector.<dServerResponse>;
        public var mStreetCursorMagenta:cGO = null;
        public var mLastZoomPos:Dictionary;
        public var mDataTracking:cDataTracking;
        protected var mDebugTextXPos:int;
        public var mStreetCursorWhite:cGO = null;
        public var mCreatePath:cCreatePath;
        public var mLog:cLog;
        public var mCurrentPlayerZone:cPlayerZoneScreen;
        public var showFogOfWar:Boolean = true;
        public var mDetailLogScrollPos:int = 0;
        public var mCurrentPlayerGuild:dGuildVO = null;
        public var mMouseCursor:cCursor;
        public var mCurrentAsciiZone:String = null;
        public var showLandingFields:Boolean = false;
        public var showIsoGrid:Boolean = false;
        public var mInitStartTime:Number = 0;
        public var mLastServerResponseIIRead:Boolean = false;
        public var mStreetCursorBlue:cGO = null;
        public var mZoneCheckVO:dZoneCheckVO;
        public var mQuestFileName:String = null;
        public var mActivateDebugQuestGui:Boolean = false;
        public var mShowAdditionalDebugInfo:Boolean;
        public var temp:int;
        public var mLastZoneRefreshTime:Number = 0;
        public var mGoSetListAnimationManager:cGoSetListAnimationManager;
        public var mServerOnly:cServerOnly;
        public var mMilitaryPath:cGO = null;
        public var mServerDate:dClientDateVO;
        public var mZoom:cZoom;
        private var mPlayersOnMap_vector:Vector.<cPlayerData>;
        protected var mStreamingParallelCntr:int = 0;
        public var mSynchronizetime:Number = 0;
        public var showBackgroundGrid:Boolean = false;
        public var mGlobalTimeScale:Number = 100;
        protected var mDebugTextYPos:int;
        public var mGameTickRefreshCounter:int;
        public var mCurrentSecondaryCursor:cCursor = null;
        public var mShowOnScreenInfoQuest:Boolean = true;
        public static const SYNCHRONISATION_JUST_REFRESH:int = 1 << 0;
        public static const SYNCHRONISATION_ERROR_DEFAULT:int = 1 << 1;
        public static const SYNCHRONISATION_ERROR_GARRISON_MISMATCH:int = 1 << 11;
        public static const BUILDING_OWNERSHIP_PLAYER:int = 1;
        public static const SYNCHRONISATION_ERROR_MISSED_GAMETICK:int = 1 << 2;
        public static const BUILDING_OWNERSHIP_FREE:int = 0;
        public static const SYNCHRONISATION_ERROR_BUILDING_MISMATCH:int = 1 << 9;
        public static const SYNCHRONISATION_ERROR_ADVENTUREZONE_DIFFERENT_MAP:int = 1 << 7;
        public static const SYNCHRONISATION_ERROR_SERVER_PREPLACEDBUILDINGCOULDNOTBEPLACED:int = 1 << 4;
        public static const SYNCHRONISATION_ERROR_SERVER_CLIENT_TIME_MISMATCH:int = 1 << 5;
        public static const SYNCHRONISATION_ERROR_BANDIT_MISMATCH:int = 1 << 14;
        public static const SYNCHRONISATION_ERROR_SQUAD_MISMATCH:int = 1 << 13;
        public static const SYNCHRONISATION_ERROR_SPECIALIST_MISMATCH:int = 1 << 12;
        public static const SYNCHRONISATION_ERROR_BUILDING_MODE_MISMATCH:int = 1 << 10;
        public static const SYNCHRONISATION_ERROR_RESOURCE_MISMATCH:int = 1 << 8;
        public static const SYNCHRONISATION_ERROR_GAMETICK_MISMATCH_ERROR:int = 1 << 6;
        public static const SYNCHRONISATION_ERROR_GAMETICK_COMMAND_KILLED_ERROR:int = 1 << 3;
        public static const BUILDING_OWNERSHIP_BANDITCAMP:int = -1;

        public function cGeneralInterface()
        {
            this.mTriggerEffects = new TriggerActions(this as cGeneralInterface);
            this.mQuestClientCallbacks = new QuestClientCallbacks(this as cGeneralInterface);
            this.mServer = new cServer(this as cGeneralInterface);
            this.mDataTracking = new cDataTracking(this as cGeneralInterface);
            this.mComputeResourceCreation = new cComputeResourceCreation(this as cGeneralInterface);
            this.mClientMessages = new cClientMessagesII(this as cGeneralInterface);
            this.mServerSimulation = new cServerSimulation(this as cGeneralInterface);
            this.mGoSetListAnimationManager = new cGoSetListAnimationManager(this as cGeneralInterface);
            this.mLastServerResponse = new Vector.<dServerResponse>;
            this.mLastServerResponseII = new Vector.<dServerResponse>;
            this.mZoom = new cZoom();
            this.mCalculateTicks = new cCalculateTicks();
            this.mLocalNLibInterface = new cLocalNLibInterface(this as cGeneralInterface);
            this.mOnScreenHelpDisplay = new cOnScreenHelpDisplay(this as cGeneralInterface);
            this.mPathFinder = new cPathFinder(this as cGeneralInterface);
            this.mServerOnly = new cServerOnly(this as cGeneralInterface);
            this.mCreatePath = new cCreatePath(this as cGeneralInterface);
            this.mSetStreets = new cSetStreets(this as cGeneralInterface);
            this.mSetBuildings = new cSetBuildings(this as cGeneralInterface);
            this.mMouseCursor = new cCursor(this as cGeneralInterface);
            this.mMouseCursorSecondary = new cCursor(this as cGeneralInterface);
            this.mTestKI = new cTestKI(this as cGeneralInterface);
            this.mGameTickCommand_vector = new Vector.<dGameTickCommandVO>;
            this.mEnumUIType = UITYPE.DUMMY;
            this.mP = new Point();
            this.mIntP = new cPosInt();
            this.mHomePlayer = new cPlayerData(this as cGeneralInterface);
            this.mCurrentPlayerZone = new cPlayerZoneScreen(this as cGeneralInterface);
            this.mLog = new cLog(this as cGeneralInterface);
            this.mZoneCheckVO = new dZoneCheckVO();
            this.mLastZoomPos = new Dictionary();
            this.mInGameErrorMessagesLog_vector = new Vector.<String>;
            this.mInGameErrorMessagesLogDetail_vector = new Vector.<String>;
            this.mPlayersOnMap_vector = new Vector.<cPlayerData>;
            this.mTempDate = new Date();
            this.mDateFormatter = new DateFormatter();
            this._bindingEventDispatcher = new EventDispatcher(IEventDispatcher(this));
            return;
        }// end function

        public function MouseClick(event:MouseEvent) : void
        {
            return;
        }// end function

        public function KeyDownOnMap(event:KeyboardEvent) : void
        {
            if (!this.IsActiveAndInputActive())
            {
                return;
            }
            if (event.charCode == gMisc.AsciiKeyCode("+"))
            {
                this.mZoom.AddScaleFactor(global.zoomSpeed);
            }
            if (event.charCode == gMisc.AsciiKeyCode("-"))
            {
                this.mZoom.AddScaleFactor(-global.zoomSpeed);
            }
            if (event.charCode == gMisc.AsciiKeyCode("0"))
            {
                this.mZoom.ResetFactorAndPos(global.defaultZoom);
            }
            return;
        }// end function

        public function MouseUp(event:MouseEvent) : void
        {
            return;
        }// end function

        public function ResetPlayerList() : void
        {
            this.mPlayersOnMap_vector.length = 0;
            return;
        }// end function

        public function Compute() : void
        {
            return;
        }// end function

        protected function ComputeStreaming() : void
        {
            if (this.mStreamingParallelCntr < 16)
            {
                if (this.mStreamingPhase == 0)
                {
                    this.StreamGroup(global.backgroundGroup);
                    if (global.backgroundGroup.mStreamIsIdle)
                    {
                        this.mBackGroundIsStreamed = true;
                    }
                }
                else if (this.mStreamingPhase == 1)
                {
                    if (this.mBackGroundIsStreamed)
                    {
                        this.StreamGroup(global.streetGroup);
                    }
                }
                else if (this.mStreamingPhase == 2)
                {
                    if (this.mBackGroundIsStreamed)
                    {
                        this.StreamGroup(global.landscapeGroup);
                    }
                }
                else if (this.mStreamingPhase == 3)
                {
                    if (this.mBackGroundIsStreamed)
                    {
                        this.StreamGroup(global.buildingGroup);
                    }
                }
                else if (this.mStreamingPhase == 4)
                {
                    if (this.mBackGroundIsStreamed)
                    {
                        this.StreamGroup(global.settlerGroup);
                    }
                }
                else if (this.mStreamingPhase == 5)
                {
                    if (this.mBackGroundIsStreamed)
                    {
                        this.StreamGroup(global.animalGroup);
                    }
                }
                else if (this.mStreamingPhase == 6)
                {
                    if (this.mBackGroundIsStreamed)
                    {
                        this.StreamGroup(global.guiIconGroup);
                    }
                }
                else if (this.mStreamingPhase == 7)
                {
                    if (this.mBackGroundIsStreamed)
                    {
                        this.StreamGroup(global.effectGroup);
                    }
                }
                var _loc_1:String = this;
                var _loc_2:* = this.mStreamingPhase + 1;
                _loc_1.mStreamingPhase = _loc_2;
                this.mStreamingPhase = this.mStreamingPhase % 8;
            }
            if (global.backgroundGroup.mStreamIsIdle)
            {
                if (!this.mRenderScreen)
                {
                    this.mRenderScreen = true;
                    this.mFadeInCntr = defines.FADEIN_TIME;
                }
            }
            if (gMisc.GetTimeSinceStartup() > this.mBlackScreenTimeout)
            {
                if (!this.mRenderScreen)
                {
                    this.mRenderScreen = true;
                    this.mFadeInCntr = 0;
                }
            }
            return;
        }// end function

        public function GetDepositType() : int
        {
            return this.mDepositType;
        }// end function

        public function SwitchOnScreenFps() : void
        {
            this.mOnScreenFps = !this.mOnScreenFps;
            return;
        }// end function

        public function GetClientTimeAsString_string() : String
        {
            var _loc_1:* = this.GetClientTime();
            this.mTempDate.setTime(_loc_1);
            return this.mDateFormatter.format(this.mTempDate);
        }// end function

        public function IsActiveAndInputActive() : Boolean
        {
            return this.mActiveG && this.mComputeAndInputActive;
        }// end function

        public function TileListSetModeClick(event:ListEvent) : void
        {
            globalFlash.gui.tileListSetMode.Click(event);
            return;
        }// end function

        public function SendServerActionSimple(param1:int, param2:Object) : dServerAction
        {
            var _loc_3:* = new dServerAction();
            _loc_3.type = param1;
            _loc_3.data = param2;
            this.mClientMessages.SendMessagetoServer(param1, this.mCurrentViewedZoneID, _loc_3);
            return _loc_3;
        }// end function

        public function SelectBuilding(param1:cBuilding) : void
        {
            this.mCurrentlySelectededBuilding = param1;
            return;
        }// end function

        protected function SetUsageCntrGroup(param1:cGOGroup) : void
        {
            var _loc_2:cGOSpriteLibContainer = null;
            for each (_loc_2 in param1.mGOList_vector)
            {
                
                _loc_2.SetUsageCounter(1);
            }
            return;
        }// end function

        public function TileListResourcesClick(event:ListEvent) : void
        {
            globalFlash.gui.tileListGo.Click(event);
            return;
        }// end function

        public function SetCurrentPlayerGuild(param1:dGuildVO) : void
        {
            var _loc_2:dGuildVO = null;
            var _loc_3:dGuildPlayerListItemVO = null;
            var _loc_4:dGuildPlayerListItemVO = null;
            if (this.mCurrentPlayerGuild != null)
            {
                _loc_2 = this.mCurrentPlayerGuild;
            }
            this.mCurrentPlayerGuild = param1;
            globalFlash.gui.mFriendsList.Refresh();
            if (_loc_2 != null && this.mCurrentPlayerGuild != null)
            {
                for each (_loc_3 in _loc_2.members)
                {
                    
                    for each (_loc_4 in this.mCurrentPlayerGuild.members)
                    {
                        
                        if (_loc_3.username == _loc_4.username)
                        {
                            _loc_4.onlineStatus = _loc_3.onlineStatus;
                            break;
                        }
                    }
                }
            }
            if (this.mCurrentPlayerGuild)
            {
                globalFlash.gui.mChatPanel.setGuildTag(this.mCurrentPlayerGuild.tag);
            }
            else if (globalFlash.gui.mChatPanel != null)
            {
                globalFlash.gui.mChatPanel.setGuildTag();
            }
            return;
        }// end function

        public function dispatchEvent(event:Event) : Boolean
        {
            return this._bindingEventDispatcher.dispatchEvent(event);
        }// end function

        public function GetCurrentPlayerGuild() : dGuildVO
        {
            return this.mCurrentPlayerGuild;
        }// end function

        public function GetPlayerName_string(param1:int) : String
        {
            if (param1 < 0)
            {
                return "Bandits";
            }
            if (param1 == 0)
            {
                return "None";
            }
            return this.FindPlayerFromId(param1).GetPlayerName_string();
        }// end function

        public function InitPreCreatedGOs() : void
        {
            this.mBackgroundCursorRed = cGO.CreateGoFromLevelObject(this.mHomePlayer, OBJECTTYPE.BACKGROUND, "BackgroundCursorRed", this);
            this.mMilitaryPath = cGO.CreateGoFromLevelObject(this.mHomePlayer, OBJECTTYPE.STREET, "MilitaryPath", this);
            this.mStreetCursorGrid = cGO.CreateGoFromLevelObject(this.mHomePlayer, OBJECTTYPE.STREET, "Street_Grid", this);
            this.mStreetCursorGreen = cGO.CreateGoFromLevelObject(this.mHomePlayer, OBJECTTYPE.STREET, "Street_Grid_Green", this);
            this.mStreetCursorBlue = cGO.CreateGoFromLevelObject(this.mHomePlayer, OBJECTTYPE.STREET, "Street_Grid_Blue", this);
            this.mStreetCursorMagenta = cGO.CreateGoFromLevelObject(this.mHomePlayer, OBJECTTYPE.STREET, "Street_Grid_Magenta", this);
            this.mStreetCursorRed = cGO.CreateGoFromLevelObject(this.mHomePlayer, OBJECTTYPE.STREET, "Street_Grid_Red", this);
            this.mStreetCursorWhite = cGO.CreateGoFromLevelObject(this.mHomePlayer, OBJECTTYPE.STREET, "Street_Grid_White", this);
            this.mStreetCursorYellow = cGO.CreateGoFromLevelObject(this.mHomePlayer, OBJECTTYPE.STREET, "Street_Grid_Yellow", this);
            this.mStreetPathCursor = cGO.CreateGoFromLevelObject(this.mHomePlayer, OBJECTTYPE.STREET, "Street_PathCursor", this);
            this.mBorder = cGO.CreateGoFromLevelObject(this.mHomePlayer, OBJECTTYPE.STREET, "border", this);
            this.mFog = cGO.CreateGoFromLevelObject(this.mHomePlayer, OBJECTTYPE.STREET, "Fog", this);
            return;
        }// end function

        public function GetGameTickPostProcessTime(param1:Number) : Number
        {
            if (param1 == 0)
            {
                param1 = this.GameTickSystemPostProcessTime;
            }
            var _loc_2:* = this.GetClientTime() + param1 * this.mGlobalTimeScale;
            return _loc_2;
        }// end function

        public function ZoneFinished() : void
        {
            var _loc_1:cGOSpriteLibContainer = null;
            var _loc_2:dClientInitDataVO = null;
            var _loc_3:cBuffDefinition = null;
            var _loc_4:dResource = null;
            globalFlash.gui.ShowDefaultGuiElements();
            this.mActiveG = true;
            this.mComputeAndInputActive = true;
            this.mClientMessages.SendMessagetoServer(COMMAND.GUILD_GET_OWN, this.mCurrentPlayer.GetHomeZoneId(), null);
            for each (_loc_1 in global.buildingGroup.mGOList_vector)
            {
                
                for each (_loc_3 in _loc_1.buildingUpgradeBonuses_vector)
                {
                    
                    for each (_loc_4 in _loc_3.GetCosts_vector())
                    {
                        
                        if (!global.resourceHardcurrencyValues.hasOwnProperty(_loc_4.name_string))
                        {
                            gMisc.Assert(false, "Resource: " + _loc_4.name_string + " not listed in ResourceHardcurrencyValues");
                        }
                    }
                }
            }
            _loc_2 = new dClientInitDataVO();
            _loc_2.clientInitDuration = getTimer() - this.mInitStartTime;
            _loc_2.clientCapabilities = Capabilities.serverString;
            this.mClientMessages.SendMessagetoServer(COMMAND.INIT_CLIENT_DONE, this.mCurrentViewedZoneID, _loc_2);
            return;
        }// end function

        public function ShowDebugInfoMessage(param1:String, param2:Number) : void
        {
            return;
        }// end function

        public function CalculateZoneCheckSum() : void
        {
            var _loc_8:cBuilding = null;
            var _loc_9:int = 0;
            var _loc_10:Vector.<cBuilding> = null;
            var _loc_11:cBuilding = null;
            var _loc_12:int = 0;
            var _loc_13:int = 0;
            var _loc_14:Vector.<cSpecialist> = null;
            var _loc_15:Vector.<dResource> = null;
            var _loc_16:dResource = null;
            var _loc_17:int = 0;
            var _loc_18:Vector.<cSquad> = null;
            var _loc_19:cSquad = null;
            var _loc_20:cSpecialist = null;
            var _loc_21:Vector.<cSquad> = null;
            var _loc_22:cSquad = null;
            this.mZoneCheckVO.clientTime = int(this.GetClientTime()) & 2147483647;
            this.mZoneCheckVO.gameTickRefreshCounter = this.mGameTickRefreshCounter;
            var _loc_1:* = this.mCurrentPlayerZone.GetResources(this.mHomePlayer);
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            if (_loc_1 != null)
            {
                _loc_15 = _loc_1.GetPlayerResources_vector(RESOURCE_GROUP.ALL);
                for each (_loc_16 in _loc_15)
                {
                    
                    _loc_3 = _loc_3 ^ _loc_16.amount + (_loc_2 << 12);
                    _loc_2++;
                }
            }
            this.mZoneCheckVO.zoneCheckSumResources = _loc_3;
            _loc_2 = 0;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:* = this.mCurrentPlayerZone.mStreetDataMap.GetBuildings_vector();
            for each (_loc_8 in _loc_7)
            {
                
                _loc_17 = int(_loc_8.mBuildingCreationTime) & 2147483647;
                if (_loc_8.GetBuildingName_string() == defines.GARRISON_NAME_string)
                {
                    _loc_4 = _loc_4 ^ _loc_8.GetBuildingMode() + (_loc_8.GetBuildingGrid() << 4) + (_loc_17 << 16);
                    _loc_4 = _loc_4 ^ _loc_8.GetUpgradeLevel() + (_loc_8.GetGOContainer().mGfxResourceListNr << 6) + (_loc_8.GetPlayerID() << 16);
                    continue;
                }
                _loc_6 = _loc_6 ^ _loc_8.GetBuildingMode();
                _loc_5 = _loc_5 ^ _loc_8.GetBuildingGrid() + (_loc_17 << 6);
                _loc_5 = _loc_5 ^ _loc_8.GetUpgradeLevel() + (_loc_8.GetGOContainer().mGfxResourceListNr << 6) + (_loc_8.GetPlayerID() << 16);
            }
            this.mZoneCheckVO.zoneCheckSumBuildings = _loc_5;
            this.mZoneCheckVO.zoneCheckSumBuildingModes = _loc_6;
            this.mZoneCheckVO.zoneCheckSumGarrisons = _loc_4;
            _loc_9 = 0;
            _loc_10 = this.mCurrentPlayerZone.mStreetDataMap.GetBuildings_vector();
            for each (_loc_11 in _loc_10)
            {
                
                _loc_18 = _loc_11.GetArmy().GetSquads_vector();
                for each (_loc_19 in _loc_18)
                {
                    
                    _loc_9 = _loc_9 ^ _loc_19.GetType_Int() + (_loc_19.GetAmount() << 6);
                }
            }
            this.mZoneCheckVO.zoneCheckSumBandits = _loc_9;
            _loc_12 = 0;
            _loc_13 = 0;
            _loc_14 = this.mCurrentPlayerZone.GetSpecialists_vector();
            if (_loc_14 != null)
            {
                for each (_loc_20 in _loc_14)
                {
                    
                    _loc_12 = _loc_12 ^ _loc_20.GetType();
                    if (_loc_20.GetTask() != null && _loc_20.GetTask().GetType() != SPECIALIST_TASK_TYPES.WAIT_FOR_CONFIRMATION)
                    {
                        _loc_12 = _loc_12 ^ (_loc_20.GetTask().GetType() << 6) + (_loc_20.GetTask().GetTaskPhase() << 16);
                    }
                    _loc_21 = _loc_20.GetArmy().GetSquads_vector();
                    if (_loc_21 != null)
                    {
                        for each (_loc_22 in _loc_21)
                        {
                            
                            _loc_13 = _loc_13 ^ _loc_22.GetAmount() + (_loc_22.GetType_Int() << 6);
                        }
                    }
                }
            }
            this.mZoneCheckVO.zoneCheckSumSpecialists = _loc_12;
            this.mZoneCheckVO.zoneCheckSumSquads = _loc_13;
            this.mZoneCheckUpdateVO = this.mZoneCheckVO;
            return;
        }// end function

        public function IsAdventureZoneID(param1:int) : Boolean
        {
            return param1 <= defines.ADVENTUREZONEID;
        }// end function

        public function RefreshGui() : void
        {
            return;
        }// end function

        public function get mCurrentPlayer() : cPlayerData
        {
            return this._617771443mCurrentPlayer;
        }// end function

        public function MouseOut(event:MouseEvent) : void
        {
            return;
        }// end function

        public function IsMoreThanOnePlayerOnMap() : Boolean
        {
            return this.mPlayersOnMap_vector.length > 2;
        }// end function

        public function addEventListener(param1:String, param2:Function, param3:Boolean = false, param4:int = 0, param5:Boolean = false) : void
        {
            this._bindingEventDispatcher.addEventListener(param1, param2, param3, param4, param5);
            return;
        }// end function

        public function AddClientTime(param1:Number) : void
        {
            this.mGameClientTime = this.mGameClientTime + param1;
            return;
        }// end function

        public function set mCurrentPlayer(param1:cPlayerData) : void
        {
            var _loc_2:* = this._617771443mCurrentPlayer;
            if (_loc_2 !== param1)
            {
                this._617771443mCurrentPlayer = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mCurrentPlayer", _loc_2, param1));
            }
            return;
        }// end function

        protected function StreamGroup(param1:cGOGroup) : void
        {
            var _loc_2:cGOSpriteLibContainer = null;
            for each (_loc_2 in param1.mGOList_vector)
            {
                
                if (_loc_2.mStream && !_loc_2.mStreamingInProgress && _loc_2.GetUsageCounter())
                {
                    if (_loc_2.IsStreamingEnabled())
                    {
                        _loc_2.mStreamingInProgress = true;
                        _loc_2.LoadAll(_loc_2.mFileName_string, this.StreamingComplete, _loc_2.mDeltaCompression);
                        var _loc_5:String = this;
                        var _loc_6:* = this.mStreamingParallelCntr + 1;
                        _loc_5.mStreamingParallelCntr = _loc_6;
                    }
                }
            }
            for each (_loc_2 in param1.mGOWorkAnimList_vector)
            {
                
                if (_loc_2)
                {
                    if (_loc_2.mStream && !_loc_2.mStreamingInProgress && _loc_2.GetUsageCounter())
                    {
                        _loc_2.mStreamingInProgress = true;
                        _loc_2.LoadAll(_loc_2.mFileName_string, this.StreamingComplete, _loc_2.mDeltaCompression);
                        var _loc_5:String = this;
                        var _loc_6:* = this.mStreamingParallelCntr + 1;
                        _loc_5.mStreamingParallelCntr = _loc_6;
                    }
                }
            }
            if (param1.mLastCurrentStreams == param1.mCurrentStreams)
            {
                var _loc_3:* = param1;
                var _loc_4:* = param1.mStreamedDelay - 1;
                _loc_3.mStreamedDelay = _loc_4;
                if (param1.mStreamedDelay < 0)
                {
                    param1.mStreamIsIdle = true;
                }
            }
            else
            {
                param1.mStreamedDelay = cGOGroup.STREAM_IDLE_DELAY;
                param1.mLastCurrentStreams = global.backgroundGroup.mCurrentStreams;
                param1.mStreamIsIdle = false;
            }
            return;
        }// end function

        public function MouseDown(event:MouseEvent) : void
        {
            return;
        }// end function

        public function UnselectBuilding() : void
        {
            this.mCurrentlySelectededBuilding = null;
            return;
        }// end function

        public function AddGameTickCommand(param1:dGameTickCommandVO) : void
        {
            this.mGameTickCommand_vector.push(param1);
            return;
        }// end function

        public function KeyDownAlways(event:KeyboardEvent) : void
        {
            return;
        }// end function

        public function FocusOutHandler(event:FocusEvent) : void
        {
            return;
        }// end function

        public function ApplicationResized() : void
        {
            return;
        }// end function

        public function hasEventListener(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.hasEventListener(param1);
        }// end function

        public function ZoomHasChanged() : void
        {
            return;
        }// end function

        public function FindPlayerFromId(param1:int) : cPlayerData
        {
            var _loc_2:cPlayerData = null;
            for each (_loc_2 in this.mPlayersOnMap_vector)
            {
                
                if (_loc_2.GetPlayerId() == param1)
                {
                    return _loc_2;
                }
            }
            return null;
        }// end function

        public function GetClientTime() : Number
        {
            return this.mGameClientTime;
        }// end function

        public function AddNewPlayer(param1:cPlayerData) : void
        {
            this.mPlayersOnMap_vector.push(param1);
            return;
        }// end function

        public function SendServerAction(param1:int, param2:int, param3:int, param4:int, param5:Object) : dServerAction
        {
            var _loc_6:* = new dServerAction();
            new dServerAction().type = param2;
            _loc_6.grid = param3;
            _loc_6.endGrid = param4;
            _loc_6.data = param5;
            this.mClientMessages.SendMessagetoServer(param1, this.mCurrentViewedZoneID, _loc_6);
            return _loc_6;
        }// end function

        public function SwitchOnScreenDisplay() : void
        {
            this.mShowAdditionalDebugInfo = !this.mShowAdditionalDebugInfo;
            return;
        }// end function

        public function Init(param1:int) : void
        {
            this.mGlobalTimeScale = global.initGlobalTimeScale;
            this.mHomePlayer.SetPlayerId(param1);
            this.AddNewPlayer(this.mHomePlayer);
            this.mCurrentPlayer = this.mHomePlayer;
            this.mCurrentViewedZoneID = param1;
            this.mMousePressed = false;
            this.mShowAdditionalDebugInfo = false;
            this.mOnScreenFps = false;
            this.mGetUpdatesSend = false;
            this.SHOW_DEBUG_TEXT = false;
            this.CHEAT_KEYS = global.CHEAT_KEYS;
            this.mActivateDebugQuestGui = global.activateDebugQuestGui;
            this.mCurrentlySelectededBuilding = null;
            this.mGameTickCommand_vector.length = 0;
            if (!defines.USE_EXTERNAL_SERVER)
            {
                this.SetGameTickRefreshCommand(this.mCurrentPlayer);
            }
            this.mCalculateTicks.InitFpsCounter();
            this.mZoom.Init(global.defaultZoom, this.mLocalNLibInterface);
            this.mZoom.ResetFactorAndPos(cZoom.DEFAULT_ZOOM);
            return;
        }// end function

        public function CreateGameTickCommand(param1:int, param2:int, param3:Object, param4:int) : dGameTickCommandVO
        {
            var _loc_6:dGameTickCommandVO = null;
            var _loc_7:dGameTickCommandVO = null;
            var _loc_5:* = this.GetGameTickPostProcessTime(0) + param4;
            for each (_loc_6 in this.mGameTickCommand_vector)
            {
                
                if (_loc_6.time == _loc_5)
                {
                    _loc_5 = _loc_5 + 100;
                    break;
                }
            }
            _loc_7 = new dGameTickCommandVO();
            _loc_7.playerID = param1;
            _loc_7.time = _loc_5;
            _loc_7.mode = param2;
            _loc_7.data = param3;
            this.mGameTickCommand_vector.push(_loc_7);
            return _loc_7;
        }// end function

        protected function RenderBackBufferToCanvas() : void
        {
            Application.application.myCanvas.graphics.clear();
            Application.application.myCanvas.graphics.beginBitmapFill(cBackbuffer.mBackBuffer, null, false, false);
            Application.application.myCanvas.graphics.drawRect(0, 0, cBackbuffer.GetWidth(), cBackbuffer.GetHeight());
            Application.application.myCanvas.graphics.endFill();
            return;
        }// end function

        public function KeyUp(event:KeyboardEvent) : void
        {
            return;
        }// end function

        public function SetClientTime(param1:Number) : void
        {
            this.mGameClientTime = param1;
            return;
        }// end function

        public function Exit() : void
        {
            return;
        }// end function

        protected function InitStreaming() : void
        {
            this.mStreamingParallelCntr = 0;
            this.mStreamingPhase = 0;
            this.mBlackScreenTimeout = gMisc.GetTimeSinceStartup() + 10000;
            if (defines.STREAMING_SET_SCREEN_TO_BLACK_UNTIL_BACKGROUND_IS_STREAMED)
            {
                this.mRenderScreen = false;
                this.mFadeInCntr = 0;
            }
            else
            {
                this.mRenderScreen = true;
                this.mFadeInCntr = defines.FADEIN_TIME;
            }
            this.mBackGroundIsStreamed = false;
            return;
        }// end function

        public function GetPlayerListPositionFromId(param1:int) : int
        {
            var _loc_2:* = this.mPlayersOnMap_vector.length;
            var _loc_3:int = 0;
            while (_loc_3 < _loc_2)
            {
                
                if (this.mPlayersOnMap_vector[_loc_3].GetPlayerId() == param1)
                {
                    return _loc_3;
                }
                _loc_3++;
            }
            return 0;
        }// end function

        public function removeEventListener(param1:String, param2:Function, param3:Boolean = false) : void
        {
            this._bindingEventDispatcher.removeEventListener(param1, param2, param3);
            return;
        }// end function

        public function GameTickErrorMessage(param1:String) : void
        {
            this.LocalLogMessage(param1);
            return;
        }// end function

        public function SetDepositType(param1:int) : void
        {
            this.mDepositType = param1;
            return;
        }// end function

        public function SetGameTickRefreshCommand(param1:cPlayerData) : void
        {
            var _loc_2:* = this.CreateGameTickCommand(param1.GetPlayerId(), COMMAND.GAMETICK_REFRESH_COMMAND, null, 0);
            _loc_2.time = this.GetGameTickPostProcessTime(this.GameTickPeriodicRefreshTime);
            return;
        }// end function

        public function ClearLevel() : void
        {
            return;
        }// end function

        public function TileListGOClick(event:ListEvent) : void
        {
            globalFlash.gui.tileListGo.Click(event);
            return;
        }// end function

        public function getZoneTypes(param1:int) : int
        {
            var _loc_2:int = 0;
            if (this.mCurrentViewedZoneID == param1)
            {
                _loc_2 = _loc_2 | BUFF_TARGET_ZONE.HOME;
            }
            else if (this.mCurrentViewedZoneID > 0)
            {
                _loc_2 = _loc_2 | BUFF_TARGET_ZONE.FRIEND;
            }
            if (this.mCurrentViewedZoneID <= defines.ADVENTUREZONEID)
            {
                _loc_2 = _loc_2 | BUFF_TARGET_ZONE.ADVENTURE;
            }
            return _loc_2;
        }// end function

        public function ClearLevelOnTheFly() : void
        {
            return;
        }// end function

        public function ZoneUpdateAfterMapRefreshed() : void
        {
            var _loc_2:cPlayerData = null;
            var _loc_1:* = this.mCurrentPlayerZone.GetResources(this.mCurrentPlayer);
            _loc_1.CalculateMaxLimitsForResources(this.mCurrentPlayer.GetPlayerId());
            _loc_1.mDirtyIndicator = DIRTY_INDICATOR.CLEAN;
            this.mCurrentPlayer.SetXPChanged();
            for each (_loc_2 in this.mPlayersOnMap_vector)
            {
                
                _loc_2.RefreshBuildingList();
            }
            if (this.mHomePlayer.GetPlayerId() == this.mCurrentPlayer.GetPlayerId())
            {
                globalFlash.gui.mInfoBar.SetBuildingsCount(this.mCurrentPlayer.mCurrentBuildingsCountAll, this.mCurrentPlayer.GetMaxBuildingCount());
            }
            this.mCurrentPlayerZone.mStreetDataMap.RefreshMayorHouse();
            this.mCurrentPlayerZone.mStreetDataMap.RefreshLogisticsHouse();
            this.mCurrentPlayerZone.mStreetDataMap.RefreshGuildHouse();
            this.mCurrentPlayerZone.mStreetDataMap.CalculateSectors(this.mCurrentPlayer);
            this.mCurrentPlayerZone.mStreetDataMap.CalculateBlockingGrid();
            this.mCurrentPlayerZone.mStreetDataMap.CalculateWatchAreas();
            this.mCurrentPlayerZone.mStreetDataMap.CalculateBorders();
            this.mCurrentPlayerZone.mStreetDataMap.RefreshExploredDeposits();
            return;
        }// end function

        public function willTrigger(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.willTrigger(param1);
        }// end function

        protected function StreamingComplete(param1:cEventWithData) : void
        {
            var _loc_2:* = param1.mObject as cGOSpriteLibContainer;
            _loc_2.mStream = false;
            _loc_2.mStreamingInProgress = false;
            var _loc_3:String = this;
            var _loc_4:* = this.mStreamingParallelCntr - 1;
            _loc_3.mStreamingParallelCntr = _loc_4;
            var _loc_3:* = _loc_2.mGoGroup;
            var _loc_4:* = _loc_2.mGoGroup.mCurrentStreams + 1;
            _loc_3.mCurrentStreams = _loc_4;
            if (_loc_2.mRefreshAfterStream)
            {
                this.mCurrentPlayerZone.SetBackgroundHasChanged(true);
            }
            return;
        }// end function

        public function GetUnscaledClientTime() : Number
        {
            return gMisc.GetTimeSinceStartup();
        }// end function

        public function Render() : void
        {
            return;
        }// end function

        public function IsCurrentPlayerQuestPlayer() : Boolean
        {
            var _loc_1:* = this.mHomePlayer.GetPlayerId();
            if (this.IsAdventureZoneID(_loc_1))
            {
                return true;
            }
            if (_loc_1 == this.mCurrentPlayer.GetPlayerId())
            {
                return true;
            }
            return false;
        }// end function

        public function IsQuestPlayerOnMap() : Boolean
        {
            var _loc_2:cPlayerData = null;
            var _loc_1:* = this.mHomePlayer.GetPlayerId();
            if (this.IsAdventureZoneID(_loc_1))
            {
                return true;
            }
            for each (_loc_2 in this.mPlayersOnMap_vector)
            {
                
                if (_loc_2.GetPlayerId() == _loc_1)
                {
                    return true;
                }
            }
            return false;
        }// end function

        public function GetPlayerList_vector()
        {
            return this.mPlayersOnMap_vector;
        }// end function

        public function LocalLogMessageDetail(param1:String) : void
        {
            var _loc_4:String = null;
            if (this.mInGameErrorMessagesLogDetail_vector.length > 1000)
            {
                this.mInGameErrorMessagesLogDetail_vector.splice(0, 100);
            }
            var _loc_2:* = param1.split("\n");
            if (_loc_2.length == 0)
            {
                _loc_2.push(param1);
            }
            var _loc_3:* = "[" + int(gMisc.GetTimeSinceStartup() / 100) + "] ";
            for each (_loc_4 in _loc_2)
            {
                
                _loc_3 = _loc_3 + (_loc_4 + " <cr>");
            }
            this.mInGameErrorMessagesLogDetail_vector.push(_loc_3);
            param1 = _loc_3;
            if (this.mLog.isDebugEnabled(LOG_TYPE.PERIODICAL))
            {
                this.mLog.logDebug(LOG_TYPE.PERIODICAL, "[LocalLogMessageDetail] " + param1);
            }
            return;
        }// end function

        public function GetPlayerIDString() : String
        {
            return "P " + this.mCurrentPlayer.GetPlayerId() + ": ";
        }// end function

        public function StartScrolling(param1:int) : void
        {
            this.scroll = param1;
            return;
        }// end function

        public function LocalLogMessage(param1:String) : void
        {
            var _loc_4:String = null;
            if (this.mInGameErrorMessagesLogDetail_vector.length > 1000)
            {
                this.mInGameErrorMessagesLogDetail_vector.splice(0, 100);
            }
            if (this.mInGameErrorMessagesLog_vector.length > 100)
            {
                this.mInGameErrorMessagesLog_vector.splice(0, 10);
            }
            var _loc_2:* = param1.split("\n");
            if (_loc_2.length == 0)
            {
                _loc_2.push(param1);
            }
            var _loc_3:String = "";
            for each (_loc_4 in _loc_2)
            {
                
                _loc_3 = _loc_3 + (_loc_4 + " <cr>");
            }
            this.mInGameErrorMessagesLogDetail_vector.push(_loc_3);
            this.mInGameErrorMessagesLog_vector.push(_loc_3);
            param1 = _loc_3;
            if (this.mLog.isDebugEnabled(LOG_TYPE.PERIODICAL))
            {
                this.mLog.logDebug(LOG_TYPE.PERIODICAL, "[LocalLogMessage] " + param1);
            }
            return;
        }// end function

        public function MouseWheel(event:MouseEvent) : void
        {
            return;
        }// end function

        public function GetSelectedBuilding() : cBuilding
        {
            return this.mCurrentlySelectededBuilding;
        }// end function

        public function SendClientLogMessagesToServer() : void
        {
            var _loc_2:String = null;
            var _loc_1:* = new dClientLogMessagesVO();
            for each (_loc_2 in this.mInGameErrorMessagesLogDetail_vector)
            {
                
                _loc_1.logMessages_vector.addItem(_loc_2);
            }
            this.mClientMessages.SendMessagetoServer(COMMAND.CLIENT_LOG, this.mCurrentViewedZoneID, _loc_1);
            return;
        }// end function

        public function MouseMove(event:MouseEvent) : void
        {
            return;
        }// end function

        public static function GetSynchronisationErrorText(param1:int) : String
        {
            var _loc_2:String = "";
            if ((param1 & SYNCHRONISATION_JUST_REFRESH) != 0)
            {
                _loc_2 = _loc_2 + "[SYNCHRONISATION_JUST_REFRESH]";
            }
            if ((param1 & SYNCHRONISATION_ERROR_DEFAULT) != 0)
            {
                _loc_2 = _loc_2 + "[ERROR_DEFAULT]";
            }
            if ((param1 & SYNCHRONISATION_ERROR_MISSED_GAMETICK) != 0)
            {
                _loc_2 = _loc_2 + "[ERROR_MISSED_GAMETICK]";
            }
            if ((param1 & SYNCHRONISATION_ERROR_GAMETICK_COMMAND_KILLED_ERROR) != 0)
            {
                _loc_2 = _loc_2 + "[ERROR_GAMETICK_COMMAND_KILLED_ERROR]";
            }
            if ((param1 & SYNCHRONISATION_ERROR_SERVER_PREPLACEDBUILDINGCOULDNOTBEPLACED) != 0)
            {
                _loc_2 = _loc_2 + "[ERROR_SERVER_PREPLACEDBUILDINGCOULDNOTBEPLACED]";
            }
            if ((param1 & SYNCHRONISATION_ERROR_SERVER_CLIENT_TIME_MISMATCH) != 0)
            {
                _loc_2 = _loc_2 + "[ERROR_SERVER_CLIENT_TIME_MISMATCH]";
            }
            if ((param1 & SYNCHRONISATION_ERROR_GAMETICK_MISMATCH_ERROR) != 0)
            {
                _loc_2 = _loc_2 + "[ERROR_GAMETICK_MISMATCH_ERROR]";
            }
            if ((param1 & SYNCHRONISATION_ERROR_ADVENTUREZONE_DIFFERENT_MAP) != 0)
            {
                _loc_2 = _loc_2 + "[ERROR_ADVENTUREZONE_DIFFERENT_MAP]";
            }
            if ((param1 & SYNCHRONISATION_ERROR_RESOURCE_MISMATCH) != 0)
            {
                _loc_2 = _loc_2 + "[ERROR_RESOURCE_MISMATCH]";
            }
            if ((param1 & SYNCHRONISATION_ERROR_BUILDING_MISMATCH) != 0)
            {
                _loc_2 = _loc_2 + "[ERROR_BUILDING_MISMATCH]";
            }
            if ((param1 & SYNCHRONISATION_ERROR_BUILDING_MODE_MISMATCH) != 0)
            {
                _loc_2 = _loc_2 + "[ERROR_BUILDING_MODE_MISMATCH]";
            }
            if ((param1 & SYNCHRONISATION_ERROR_GARRISON_MISMATCH) != 0)
            {
                _loc_2 = _loc_2 + "[ERROR_GARRISON_MISMATCH]";
            }
            if ((param1 & SYNCHRONISATION_ERROR_SPECIALIST_MISMATCH) != 0)
            {
                _loc_2 = _loc_2 + "[ERROR_SPECIALIST_MISMATCH]";
            }
            if ((param1 & SYNCHRONISATION_ERROR_SQUAD_MISMATCH) != 0)
            {
                _loc_2 = _loc_2 + "[ERROR_SQUAD_MISMATCH]";
            }
            if ((param1 & SYNCHRONISATION_ERROR_BANDIT_MISMATCH) != 0)
            {
                _loc_2 = _loc_2 + "[ERROR_BANDIT_MISMATCH]";
            }
            return _loc_2;
        }// end function

    }
}
