package GuiWrapper
{
    import Communication.VO.*;
    import Enums.*;
    import GO.*;
    import GUI.*;
    import GUI.EDITOR.*;
    import GUI.GAME.*;
    import GUI.GAME.Chat.*;
    import GUI.GENERAL.*;
    import Interface.*;
    import NewQuestSystem.Client.*;
    import __AS3__.vec.*;
    import flash.display.*;
    import flash.events.*;
    import flash.geom.*;
    import flash.text.*;
    import flash.utils.*;
    import mx.core.*;
    import nLib.*;

    public class cGuiWrapper extends Object
    {
        private var mRenderTextDebug:cRenderText;
        public var mHintPointer:cHintPointer = null;
        public var mTrackedMissionList:cTrackedMissionList = null;
        public var mActionBar:cGameActionBar = null;
        public var mTimedProductionInfoPanel:cTimedProductionInfoPanel = null;
        public var MenuBar:cMenuBar = null;
        public var mGuildWindow:cGuildWindow = null;
        public var mLegalPanel:cLegalPanel = null;
        public var tileListSetMode:cTileListSetMode = null;
        public var mOptionsPanel:cOptionsPanel = null;
        private var mRenderTextBigFont:cRenderText;
        public var mMysteryBoxPanel:cMysteryBoxPanel = null;
        public var mAvatar:cAvatar = null;
        public var mCL3BuildingsList:cBuildingsList = null;
        private var mShowQuestWindowDelayed:Boolean = false;
        public var mBaseBuildingsList:cBuildingsList = null;
        private var mDefaultGuiElementsLoaded:Boolean = false;
        private var mShowDailyRewardDelayed:Boolean = false;
        public var mAvatarMessageList:cAvatarMessageList = null;
        public var mFriendsList:cFriendsList = null;
        public var mInfoBar:cInfoBar = null;
        private var map_BuildingName_InfoPanel:Object;
        private var mInfoBarRect:Rectangle;
        public var mStarMenu:cStarMenu = null;
        public var mLoadingZonePanel:cLoadingZonePanel = null;
        public var mSpecialistPanel:cSpecialistPanel = null;
        public var tileListGo:cTileListGO = null;
        public var mTradingPanel:cTradingPanel = null;
        public var mDecorationInfoPanel:cDecorationInfoPanel = null;
        public var mSpecialistCooldownPanel:cSpecialistCooldownPanel = null;
        public var mCL2BuildingsList:cBuildingsList = null;
        public var mAddFriendsPanel:cAddFriendsPanel = null;
        public var mQuestNewQuestSystemList:cQuestNewQuestSystemList = null;
        public var mBuildQueue:cBuildQueue = null;
        public var mTavernInfoPanel:cTavernInfoPanel = null;
        public var mChatPanel:TSOChatMediator = null;
        public var mAdventurePanel:cAdventurePanel = null;
        public var mFriendsListMenu:cFriendsListMenu = null;
        public var mCL01BuildingsList:cBuildingsList = null;
        public var mCancelActionPanel:cCancelActionPanel = null;
        public var mMemoryMonitor:cMemoryMonitorPanel = null;
        public var mSpecialistTravelPanel:cSpecialistTravelPanel = null;
        public var mBuildingInfoPanel:cBuildingInfoPanel = null;
        public var mConstructionInfoPanel:cConstructionInfoPanel = null;
        public var mCameraControlPanel:cCameraControlPanel = null;
        private var mGeneralInterface:cGeneralInterface;
        public var mWarehouseInfoPanel:cWarehouseInfoPanel = null;
        public var mFoundGuildPanel:cFoundGuildPanel = null;
        public var mEnemyBuildingInfoPanel:cEnemyBuildingInfoPanel = null;
        public var mShopWindow:cShopWindow = null;
        public var mMailWindow:cMailWindow = null;
        public var mBattleWindow:cBattleWindow = null;
        private var mInfoBarPos:Point;
        public var mResidenceInfoPanel:cResidenceInfoPanel = null;
        public var mMinimalInfoPanel:cMinimalInfoPanel = null;
        public var mDailyLoginPanel:cDailyLoginPanel = null;
        public var mWatchTowerInfoPanel:cWatchTowerInfoPanel = null;
        public var mNewsWindow:cNewsWindow = null;
        public var mDarkenPanel:cDarkenPanel = null;
        public var mQuestBook:cQuestBook = null;

        public function cGuiWrapper()
        {
            this.map_BuildingName_InfoPanel = new Object();
            this.mInfoBarRect = new Rectangle();
            this.mInfoBarPos = new Point();
            return;
        }// end function

        public function ToggleCL3BuildingsMenu(event:Event) : void
        {
            var _loc_2:* = globalFlash.gui;
            if (_loc_2.mCL3BuildingsList.IsVisible())
            {
                _loc_2.mCL3BuildingsList.Hide();
            }
            else
            {
                _loc_2.mCL3BuildingsList.Show();
            }
            return;
        }// end function

        public function SetDataDailyLogin(param1:dQuestElementVO, param2:int) : void
        {
            this.mDailyLoginPanel.SetData(param1, param2);
            if (!cBasicPanel.IsCurrentActivePanelVisible() && this.mGeneralInterface.mCurrentCursor.GetEditMode() == COMMAND.SELECT_BUILDING)
            {
                this.mDailyLoginPanel.Show();
            }
            else if (!this.mDailyLoginPanel.IsVisible())
            {
                this.mShowDailyRewardDelayed = true;
            }
            return;
        }// end function

        public function GetDefaultGuiElementsLoaded() : Boolean
        {
            return this.mDefaultGuiElementsLoaded;
        }// end function

        public function InitGuiElements(param1:cGeneralInterface) : void
        {
            this.mGeneralInterface = param1;
            cGuiBaseElement.InitStatic();
            this.mActionBar = new cGameActionBar();
            this.mActionBar.Init(Application.application.GAMESTATE_ID_ACTIONBAR);
            this.mBaseBuildingsList = new cBuildingsList();
            this.mBaseBuildingsList.Init(Application.application.GAMESTATE_ID_LIST_BASE_BUILDINGS, cGOSpriteLibContainer.UI_TYPE_CL01_BUILDING);
            this.mCL01BuildingsList = new cBuildingsList();
            this.mCL01BuildingsList.Init(Application.application.GAMESTATE_ID_LIST_CL01_BUILDINGS, cGOSpriteLibContainer.UI_TYPE_CL2_BUILDING);
            this.mCL2BuildingsList = new cBuildingsList();
            this.mCL2BuildingsList.Init(Application.application.GAMESTATE_ID_LIST_CL2_BUILDINGS, cGOSpriteLibContainer.UI_TYPE_CL3_BUILDING);
            this.mCL3BuildingsList = new cBuildingsList();
            this.mCL3BuildingsList.Init(Application.application.GAMESTATE_ID_LIST_CL3_BUILDINGS, cGOSpriteLibContainer.UI_TYPE_BASEBUILDING);
            this.mInfoBar = new cInfoBar();
            this.mInfoBar.Init(Application.application.GAMESTATE_ID_INFO_BAR);
            this.mWatchTowerInfoPanel = new cWatchTowerInfoPanel();
            this.mWatchTowerInfoPanel.Init(Application.application.GAMESTATE_ID_WATCHTOWER_INFO_PANEL);
            this.mTimedProductionInfoPanel = new cTimedProductionInfoPanel();
            this.mTimedProductionInfoPanel.Init(Application.application.GAMESTATE_ID_TIMED_PRODUCTION_INFO_PANEL);
            this.mTavernInfoPanel = new cTavernInfoPanel();
            this.mTavernInfoPanel.Init(Application.application.GAMESTATE_ID_TAVERN_INFO_PANEL);
            this.mBuildingInfoPanel = new cBuildingInfoPanel();
            this.mBuildingInfoPanel.Init(Application.application.GAMESTATE_ID_BUILDING_INFO_PANEL);
            this.mResidenceInfoPanel = new cResidenceInfoPanel();
            this.mResidenceInfoPanel.Init(Application.application.GAMESTATE_ID_RESIDENCE_INFO_PANEL);
            this.mConstructionInfoPanel = new cConstructionInfoPanel();
            this.mConstructionInfoPanel.Init(Application.application.GAMESTATE_ID_CONSTRUCTION_INFO_PANEL);
            this.mDecorationInfoPanel = new cDecorationInfoPanel();
            this.mDecorationInfoPanel.Init(Application.application.GAMESTATE_ID_DECORATION_INFO_PANEL);
            this.mMinimalInfoPanel = new cMinimalInfoPanel();
            this.mMinimalInfoPanel.Init(Application.application.GAMESTATE_ID_MINIMAL_INFO_PANEL);
            this.mSpecialistCooldownPanel = new cSpecialistCooldownPanel();
            this.mSpecialistCooldownPanel.Init(Application.application.SPECIALIST_COOLDOWN_PANEL);
            this.mMysteryBoxPanel = new cMysteryBoxPanel();
            this.mMysteryBoxPanel.Init(Application.application.GAMESTATE_ID_MYSTERYBOX_PANEL);
            this.mEnemyBuildingInfoPanel = new cEnemyBuildingInfoPanel();
            this.mEnemyBuildingInfoPanel.Init(Application.application.GAMESTATE_ID_ENEMY_BUILDING_INFO_PANEL);
            this.mWarehouseInfoPanel = new cWarehouseInfoPanel();
            this.mWarehouseInfoPanel.Init(Application.application.GAMESTATE_ID_WAREHOUSE_INFO_PANEL);
            this.mLoadingZonePanel = new cLoadingZonePanel();
            this.mLoadingZonePanel.Init(Application.application.GAMESTATE_ID_LOADING_ZONE_PANEL);
            this.mBuildQueue = new cBuildQueue();
            this.mBuildQueue.Init(Application.application.GAMESTATE_ID_BUILD_QUEUE);
            this.mOptionsPanel = new cOptionsPanel();
            this.mOptionsPanel.Init(Application.application.GAMESTATE_ID_OPTIONS_PANEL);
            this.mCameraControlPanel = new cCameraControlPanel();
            this.mCameraControlPanel.Init(Application.application.GAMESTATE_ID_CAMERA_CONTROL_PANEL);
            this.mAvatar = new cAvatar();
            this.mAvatar.Init(Application.application.GAMESTATE_ID_AVATAR);
            this.mMemoryMonitor = new cMemoryMonitorPanel();
            this.mMemoryMonitor.Init(Application.application.GAMESTATE_ID_MEMORY_MONITOR);
            this.mFriendsListMenu = new cFriendsListMenu();
            this.mFriendsListMenu.Init(Application.application.GAMESTATE_ID_FRIENDS_LIST_MENU);
            this.mFriendsList = new cFriendsList();
            this.mFriendsList.Init(Application.application.GAMESTATE_ID_FRIENDS_LIST);
            this.mTradingPanel = new cTradingPanel();
            this.mTradingPanel.Init(Application.application.GAMESTATE_ID_TRADING_PANEL);
            this.mShopWindow = new cShopWindow();
            this.mShopWindow.Init(Application.application.GAMESTATE_ID_SHOP_WINDOW);
            this.mBattleWindow = new cBattleWindow();
            this.mBattleWindow.Init(Application.application.GAMESTATE_ID_BATTLE_WINDOW);
            this.mStarMenu = new cStarMenu();
            this.mStarMenu.Init(Application.application.GAMESTATE_ID_STAR_MENU);
            this.mSpecialistPanel = new cSpecialistPanel();
            this.mSpecialistPanel.Init(Application.application.GAMESTATE_ID_SPECIALIST_PANEL);
            this.mSpecialistTravelPanel = new cSpecialistTravelPanel();
            this.mSpecialistTravelPanel.Init(Application.application.GAMESTATE_ID_SPECIALIST_TRAVEL_PANEL);
            this.mCancelActionPanel = new cCancelActionPanel();
            this.mCancelActionPanel.Init(Application.application.GAMESTATE_ID_CANCEL_ACTION_PANEL);
            this.mAvatarMessageList = new cAvatarMessageList();
            this.mAvatarMessageList.Init(Application.application.GAMESTATE_ID_AVATAR_MESSAGE_LIST);
            this.mTrackedMissionList = new cTrackedMissionList();
            this.mTrackedMissionList.Init(Application.application.GAMESTATE_ID_TRACKED_MISSION_LIST);
            this.mAddFriendsPanel = new cAddFriendsPanel();
            this.mAddFriendsPanel.Init(Application.application.GAMESTATE_ID_ADD_FRIENDS_PANEL);
            this.mMailWindow = new cMailWindow();
            this.mMailWindow.Init(Application.application.GAMESTATE_ID_MAIL_WINDOW);
            this.mQuestBook = new cQuestBook();
            this.mQuestBook.Init(Application.application.GAMESTATE_ID_QUEST_BOOK);
            this.mDarkenPanel = new cDarkenPanel();
            this.mDarkenPanel.Init(Application.application.GAMESTATE_ID_DARKEN_PANEL);
            this.mHintPointer = new cHintPointer();
            this.mHintPointer.Init(Application.application.GAMESTATE_ID_HINT_POINTER);
            this.mNewsWindow = new cNewsWindow();
            this.mNewsWindow.Init(Application.application.GAMESTATE_ID_NEWS_WINDOW);
            this.mAdventurePanel = new cAdventurePanel();
            this.mAdventurePanel.Init(Application.application.GAMESTATE_ID_ADVENTURE_PANEL);
            this.mGuildWindow = new cGuildWindow();
            this.mGuildWindow.Init(Application.application.GAMESTATE_ID_GUILD_WINDOW);
            this.mFoundGuildPanel = new cFoundGuildPanel();
            this.mFoundGuildPanel.Init(Application.application.GAMESTATE_ID_FOUND_GUILD_PANEL);
            this.mQuestNewQuestSystemList = new cQuestNewQuestSystemList();
            this.mQuestNewQuestSystemList.Init(Application.application.GAMESTATE_ID_QUEST_NEW_QUEST_SYSTEM_LIST_PANEL);
            this.mDailyLoginPanel = new cDailyLoginPanel();
            this.mDailyLoginPanel.Init(Application.application.GAMESTATE_ID_DAILY_LOGIN_PANEL);
            this.mLegalPanel = new cLegalPanel();
            this.mLegalPanel.Init(Application.application.GAMESTATE_ID_LEGAL_PANEL);
            this.AssignInfoPannels();
            return;
        }// end function

        public function ToggleMailWindow(event:Event) : void
        {
            var _loc_2:* = globalFlash.gui;
            if (_loc_2.mMailWindow.IsVisible())
            {
                _loc_2.mMailWindow.Hide();
            }
            else
            {
                _loc_2.mMailWindow.Show();
            }
            return;
        }// end function

        public function ExitGuiElements() : void
        {
            return;
        }// end function

        public function WriteDebugText(param1:BitmapData, param2:String, param3:int, param4:int) : void
        {
            this.mRenderTextDebug.Write(param1, param2, param3, param4);
            return;
        }// end function

        public function ToggleCL01BuildingsMenu(event:Event) : void
        {
            var _loc_2:* = globalFlash.gui;
            if (_loc_2.mCL01BuildingsList.IsVisible())
            {
                _loc_2.mCL01BuildingsList.Hide();
            }
            else
            {
                _loc_2.mCL01BuildingsList.Show();
            }
            return;
        }// end function

        public function ToggleCL2BuildingsMenu(event:Event) : void
        {
            var _loc_2:* = globalFlash.gui;
            if (_loc_2.mCL2BuildingsList.IsVisible())
            {
                _loc_2.mCL2BuildingsList.Hide();
            }
            else
            {
                _loc_2.mCL2BuildingsList.Show();
            }
            return;
        }// end function

        public function InitEditorGuiElements() : void
        {
            cGuiBaseElement.InitStatic();
            this.tileListGo = new cTileListGO();
            this.tileListGo.InitFilterBuildingsAll(true);
            this.tileListGo.Init(Application.application.EDITORSTATE_ID_TILE_LIST_GO);
            this.tileListSetMode = new cEditorTileListSetMode();
            this.tileListSetMode.Init(Application.application.EDITORSTATE_ID_TILE_LIST_SET_MODE);
            this.MenuBar = new cEditorMenuBar();
            this.MenuBar.Init(Application.application.EDITORSTATE_MenuBar);
            return;
        }// end function

        public function ShowDefaultGuiElements() : void
        {
            if (this.mChatPanel != null)
            {
                this.mChatPanel.Show();
            }
            this.mActionBar.Show();
            this.mInfoBar.Show();
            this.mAvatar.Show();
            this.mFriendsList.Show();
            this.mOptionsPanel.Show();
            this.mDefaultGuiElementsLoaded = true;
            return;
        }// end function

        public function GetInfoPanel(param1:String) : cBasicInfoPanel
        {
            return this.map_BuildingName_InfoPanel[param1];
        }// end function

        public function ToggleStarMenu(event:Event) : void
        {
            var _loc_2:* = globalFlash.gui;
            if (_loc_2.mStarMenu.IsVisible())
            {
                _loc_2.mStarMenu.Hide();
            }
            else
            {
                _loc_2.mStarMenu.Show();
            }
            return;
        }// end function

        public function SetGuiTileListData() : void
        {
            this.tileListGo.SetData();
            Application.application.mTileListDataProviderSetMode = this.tileListSetMode.SetData();
            return;
        }// end function

        public function RegisterBuildingType(param1:String, param2:String) : void
        {
            if (param1 == "" || param2 == "")
            {
                gMisc.Assert(false, "No UI type specified for building: " + param1);
            }
            this.map_BuildingName_InfoPanel[param1] = param2;
            return;
        }// end function

        public function ShowWarehouse() : void
        {
            var _loc_1:cBuilding = null;
            for each (_loc_1 in global.ui.mCurrentPlayerZone.mStreetDataMap.GetBuildings_vector())
            {
                
                if (_loc_1.GetBuildingName_string() == defines.MAYORHOUSE_NAME_string)
                {
                    global.ui.SelectBuilding(_loc_1);
                    globalFlash.gui.mWarehouseInfoPanel.SetData(_loc_1);
                    globalFlash.gui.mWarehouseInfoPanel.Show();
                    return;
                }
            }
            return;
        }// end function

        public function ToggleShop(event:Event) : void
        {
            var _loc_2:* = globalFlash.gui;
            if (_loc_2.mShopWindow.IsVisible())
            {
                _loc_2.mShopWindow.Hide();
            }
            else
            {
                _loc_2.mShopWindow.Show();
            }
            return;
        }// end function

        public function ShowQuestWindowDelayed() : void
        {
            if (this.mShowDailyRewardDelayed)
            {
                this.mShowDailyRewardDelayed = false;
                setTimeout(function () : void
            {
                mDailyLoginPanel.Show();
                return;
            }// end function
            , 100);
            }
            return;
        }// end function

        public function ShowBarracks() : void
        {
            var _loc_1:cBuilding = null;
            for each (_loc_1 in global.ui.mCurrentPlayerZone.mStreetDataMap.GetBuildings_vector())
            {
                
                if (_loc_1.GetBuildingName_string() == defines.BARRACKS_NAME_string)
                {
                    global.ui.SelectBuilding(_loc_1);
                    globalFlash.gui.mTimedProductionInfoPanel.SetData(_loc_1);
                    globalFlash.gui.mTimedProductionInfoPanel.Show();
                    return;
                }
            }
            return;
        }// end function

        public function GetInfoPanelString(param1:String) : String
        {
            return this.map_BuildingName_InfoPanel[param1];
        }// end function

        public function ShowFriendListMenu(event:MouseEvent, param2:dPlayerListItemVO) : void
        {
            globalFlash.gui.mFriendsListMenu.Move(event.stageX, event.stageY);
            globalFlash.gui.mFriendsListMenu.SetData(param2);
            event.stopPropagation();
            globalFlash.gui.mFriendsListMenu.Show();
            return;
        }// end function

        public function AssignInfoPannels() : void
        {
            var _loc_2:String = null;
            var _loc_1:Object = {};
            for (_loc_2 in this.map_BuildingName_InfoPanel)
            {
                
                switch(this.map_BuildingName_InfoPanel[_loc_2])
                {
                    case "workyard":
                    {
                        _loc_1[_loc_2] = this.mBuildingInfoPanel;
                        break;
                    }
                    case "residence":
                    {
                        _loc_1[_loc_2] = this.mResidenceInfoPanel;
                        break;
                    }
                    case "timedproduction":
                    {
                        _loc_1[_loc_2] = this.mTimedProductionInfoPanel;
                        break;
                    }
                    case "warehouse":
                    {
                        _loc_1[_loc_2] = this.mWarehouseInfoPanel;
                        break;
                    }
                    case "decoration":
                    {
                        _loc_1[_loc_2] = this.mDecorationInfoPanel;
                        break;
                    }
                    case "enemy":
                    {
                        _loc_1[_loc_2] = this.mEnemyBuildingInfoPanel;
                        break;
                    }
                    case "minimal":
                    {
                        _loc_1[_loc_2] = this.mMinimalInfoPanel;
                        break;
                    }
                    case "tavern":
                    {
                        _loc_1[_loc_2] = this.mTavernInfoPanel;
                        break;
                    }
                    case "watchtower":
                    {
                        _loc_1[_loc_2] = this.mWatchTowerInfoPanel;
                        break;
                    }
                    case "none":
                    {
                        break;
                    }
                    default:
                    {
                        gMisc.Assert(false, "Unknown UI type \"" + this.map_BuildingName_InfoPanel[_loc_2] + "\" for building: " + _loc_2);
                        break;
                    }
                }
            }
            this.map_BuildingName_InfoPanel = _loc_1;
            return;
        }// end function

        public function WriteDebugTextCenterBackground(param1:BitmapData, param2:String, param3:int, param4:int, param5:int) : void
        {
            this.mRenderTextDebug.WriteCenterBackground(param1, param2, param3, param4, param5);
            return;
        }// end function

        public function HideQuestNotification() : void
        {
            this.mHintPointer.Hide();
            return;
        }// end function

        public function ToggleGuildWindow(event:Event) : void
        {
            var _loc_2:* = globalFlash.gui;
            if (_loc_2.mGuildWindow.IsVisible())
            {
                _loc_2.mGuildWindow.Hide();
            }
            else
            {
                _loc_2.mGuildWindow.Show();
            }
            return;
        }// end function

        public function InitFonts(param1:String) : void
        {
            trace("cGUIWrapper::InitFonts(\"" + param1 + "\")");
            this.mRenderTextDebug = new cRenderText(param1, 13, true, TextFormatAlign.LEFT, 16777215, "left");
            this.mRenderTextBigFont = new cRenderText(param1, 16, true, TextFormatAlign.LEFT, 65280, "left");
            return;
        }// end function

        public function Refresh() : void
        {
            this.mBaseBuildingsList.SetData();
            this.mCL01BuildingsList.SetData();
            this.mCL2BuildingsList.SetData();
            this.mCL3BuildingsList.SetData();
            return;
        }// end function

        public function ShowProvisionHouse() : void
        {
            var _loc_1:cBuilding = null;
            for each (_loc_1 in global.ui.mCurrentPlayerZone.mStreetDataMap.GetBuildings_vector())
            {
                
                if (_loc_1.GetBuildingName_string() == defines.PROVISIONHOUSE_NAME_string)
                {
                    global.ui.SelectBuilding(_loc_1);
                    globalFlash.gui.mTimedProductionInfoPanel.SetData(_loc_1);
                    globalFlash.gui.mTimedProductionInfoPanel.Show();
                    return;
                }
            }
            return;
        }// end function

        public function WriteDebugTextCenter(param1:BitmapData, param2:String, param3:int, param4:int) : void
        {
            this.mRenderTextDebug.WriteCenter(param1, param2, param3, param4);
            return;
        }// end function

        public function WriteDebugTextMapPos(param1:BitmapData, param2:String, param3:int, param4:int) : void
        {
            var _loc_5:* = new cPosInt();
            new cPosInt().x = int(param3);
            _loc_5.y = int(param4);
            Application.application.mGeneralInterface.mZoom.CalculateScrollPos(_loc_5);
            globalFlash.gui.WriteDebugText(cBackbuffer.mBackBuffer, param2, _loc_5.x, _loc_5.y);
            return;
        }// end function

        public function WriteTextBig(param1:BitmapData, param2:String, param3:int, param4:int) : void
        {
            this.mRenderTextBigFont.Write(param1, param2, param3, param4);
            return;
        }// end function

        public function ShowCompletedQuestNotification(param1:dQuestElementVO) : void
        {
            var _loc_2:* = new QuestHint();
            _loc_2.mPointTo = "QuestButton";
            _loc_2.mType = cHintPointer.COMPLETED_QUEST;
            _loc_2.mOffsetX = 25;
            var _loc_3:* = new Vector.<QuestHint>;
            _loc_3.push(_loc_2);
            this.mHintPointer.SetData(_loc_3);
            this.mQuestBook.SetNotificationQuest(param1);
            return;
        }// end function

        public function UpdateGuiOnZoneLoad() : void
        {
            if (this.mNewsWindow.IsVisible())
            {
                this.mNewsWindow.Enable();
            }
            else
            {
                cBasicPanel.HideCurrentActivePanel();
            }
            this.mLoadingZonePanel.Hide();
            return;
        }// end function

        public function ShowNewQuestNotification(param1:dQuestElementVO) : void
        {
            var _loc_2:* = new QuestHint();
            _loc_2.mPointTo = "QuestButton";
            _loc_2.mType = cHintPointer.NEW_QUEST;
            _loc_2.mOffsetX = 25;
            var _loc_3:* = new Vector.<QuestHint>;
            _loc_3.push(_loc_2);
            this.mHintPointer.SetData(_loc_3);
            this.mQuestBook.SetNotificationQuest(param1);
            return;
        }// end function

        public function RefreshDepositGroupWindow() : void
        {
            Application.application.RefreshDepositGroupWindow();
            return;
        }// end function

        public function ToggleBaseBuildingsMenu(event:Event) : void
        {
            var _loc_2:* = globalFlash.gui;
            if (_loc_2.mBaseBuildingsList.IsVisible())
            {
                _loc_2.mBaseBuildingsList.Hide();
            }
            else
            {
                _loc_2.mBaseBuildingsList.Show();
            }
            return;
        }// end function

    }
}
