package 
{
    import Enums.*;
    import GUI.*;
    import GUI.Components.*;
    import GUI.GAME.Chat.*;
    import GUI.Loca.*;
    import Interface.*;
    import MilitarySystem.*;
    import SWMMO.*;
    import ServerState.*;
    import flash.events.*;
    import flash.external.*;
    import flash.system.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.collections.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.controls.dataGridClasses.*;
    import mx.core.*;
    import mx.events.*;
    import mx.states.*;
    import mx.styles.*;
    import nLib.*;
    import unitTest.*;

    public class SWMMO extends Application implements IBindingClient
    {
        private var _embed_css_____data_src_gfx_embedded_chat_bg_chattab_selected_png_700177882:Class;
        private var _1393716736GAMESTATE_ID_GUILD_WINDOW:GuildWindow;
        private var _1053263437GAMESTATE_ID_LIST_CL3_BUILDINGS:BuildingsList;
        private var _embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_mouseover_png_890993175:Class;
        private var _embed_css_____data_src_gfx_embedded_chat_minimize_standard_png_197453125:Class;
        public var mIsDebugPlayer:Boolean = false;
        private var _embed_css_____data_src_gfx_embedded_buttons_x_small_selected_png_400774907:Class;
        private var _1970511437GAMESTATE_ID_BATTLE_WINDOW:BattleWindow;
        private var _embed_css_____data_src_gfx_embedded_buttons_standard_highlight_png_160955392:Class;
        private var _1267151564GAMESTATE_ID_WATCHTOWER_INFO_PANEL:WatchTowerInfoPanel;
        private var _embed_css_____data_src_gfx_embedded_basicpanel_subheader_png_797926995:Class;
        private var _1776177564SetLandingZoneID:RadioButton;
        private var _637642909RemoveUnitID:Button;
        private var _1110417475label1:Label;
        private var _142638398ID_DebugInfoPanelShowSettlerDebugInfo:CheckBox;
        private var _77743879FilterGoListID:Canvas;
        private var _137831375mResourceProductionWindowDataGridDataProvider:ArrayCollection;
        var _bindingsByDestination:Object;
        private var _1665083201SectorIdButton2:Button;
        private var _85130591SectorListID:TitleWindow;
        public var mIgnoreNextClick:Boolean = false;
        private var _embed_css_____data_src_gfx_embedded_options_option_bg_small_png_911592548:Class;
        private var _1444752500GAMESTATE_ID_LIST_CL2_BUILDINGS:BuildingsList;
        private var _194875837ReAssignSectorID:TitleWindow;
        private var _embed_css_____data_src_gfx_embedded_chat_scale_highlighted_png_935498501:Class;
        private var _embed_css_____data_src_gfx_embedded_alert_alert_background_png_1445621566:Class;
        private var _embed_css_____data_src_gfx_embedded_buildingmenu_tooltip_background_png_166192939:Class;
        private var _embed_css_____data_src_gfx_embedded_buildinginfo_tilelist_bg_png_1613316706:Class;
        private var _1041187408FILTER_BUILDING_INVERT_ID0:Button;
        private var _1506992000ID_DebugInfoPanelShowErrorLog:CheckBox;
        private var _267857324mMemoryMonitor:gMemoryMonitor;
        private var _639313698SPECIALIST_COOLDOWN_PANEL:SpecialistCooldownPanel;
        private var _1681376410GroupDepositID:Canvas;
        private var _1148490103radiogroupOwnerShipfree:RadioButton;
        private var _embed_css_____data_src_gfx_embedded_camera_camera_bg_png_902640356:Class;
        private var _embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_push_png_1621504697:Class;
        private var _1513045444FILTER_BUILDING_Enemy:CheckBox;
        private var _1395871100GAMESTATE_ID_DAILY_LOGIN_PANEL:DailyLoginPanel;
        private var _1859197251ID_DebugInfoPanelShowAll:CheckBox;
        private var _1095300049DepositGroupDataGrid:DataGrid;
        private var _embed_css_____data_src_gfx_embedded_infobar_infobar_mid_png_222120674:Class;
        private var _embed_css_____data_src_gfx_embedded_friendslist_friendslist1_png_2010943604:Class;
        private var _embed_css_____data_src_gfx_embedded_chat_button_selected_png_381018229:Class;
        private var _2050543604FILTER_BUILDING_Decoration:CheckBox;
        private var _1422934488EraseLandingZoneID:RadioButton;
        private var _193268130GAMESTATE_ID_DECORATION_INFO_PANEL:DecorationInfoPanel;
        private var _embed_css_____data_src_gfx_embedded_friendslist_friendslist3_png_1983284784:Class;
        private var _1767827589brushSizeRadioID:Panel;
        private var _143676367mTileListDataProviderSetMode:ArrayCollection;
        private var _embed_css_____data_src_gfx_embedded_options_textbutton_inactive_png_40222180:Class;
        public var mIsDebugBuild:Boolean = false;
        private var _1209783630GAMESTATE_ID_LIST_BASE_BUILDINGS:BuildingsList;
        private var _1383535623EDITORSTATE_MenuBar:MenuBar;
        private var _1665083196SectorIdButton7:Button;
        private var _embed_css_____data_src_gfx_embedded_trade_avatar_box_png_782837924:Class;
        private var _83384109UPGRADLEVEL_ID_TEXT:TextInput;
        private var _1066993359GAMESTATE_ID_ADVENTURE_PANEL:AdventurePanel;
        private var _embed_css_____data_src_gfx_embedded_shop_buy_item_bg_details_png_1231834048:Class;
        private var _1954153967FILTER_BUILDING_workyard:CheckBox;
        private var _2105831032GAMESTATE_ID_STAR_MENU:StarMenu;
        private var _1584604980ID_DebugInfoPanelShowQuestInfo:CheckBox;
        var _bindingsBeginWithWord:Object;
        private var _445266123AssignUnitsWindowID:TitleWindow;
        private var _585034434RedBlockingRadioButtonID:RadioButton;
        private var _embed_css_____data_src_gfx_embedded_friendslist_friendslist2_png_1667250557:Class;
        private var _154230399YellowBlockingRadioButtonID:RadioButton;
        private var _1504873592btnStartGame:Button;
        private var _1370867518SetBlockingWindowID:TitleWindow;
        private var _embed_css_____data_src_gfx_embedded_shop_footer_png_1480837470:Class;
        private var _643659396FILTER_BUILDING_None:CheckBox;
        private var _587777860EDITORSTATE_ApplicationActivated:Panel;
        private var _embed_css_____data_src_gfx_embedded_basicpanel_header_png_1330748332:Class;
        private var _350084012radiogroupOwnerShipBanditCamp:RadioButton;
        private var _1282310620myCanvas:Canvas;
        private var _710490583GAMESTATE_ID_SPECIALIST_TRAVEL_PANEL:SpecialistTravelPanel;
        private var _embed_css_____data_src_gfx_embedded_chat_minimize_highlighted_png_1579240229:Class;
        private var _1665083200SectorIdButton3:Button;
        private var _1146070859GAMESTATE_ID_SHOP_WINDOW:ShopWindow;
        private var _embed_css_____data_src_gfx_embedded_options_textbutton_mouseover_png_1972989270:Class;
        private var _223965420GAMESTATE_ID_CAMERA_CONTROL_PANEL:CameraControlPanel;
        private var _1994189721SectorModeWindow:TitleWindow;
        private var _768529271GAMESTATE_ID_FOUND_GUILD_PANEL:FoundGuildPanel;
        public var _SWMMO_AddChild1:AddChild;
        public var _SWMMO_AddChild2:AddChild;
        private var _1590085518EDITORSTATE_btnEditor:Button;
        public var _SWMMO_AddChild4:AddChild;
        public var _SWMMO_AddChild5:AddChild;
        public var _SWMMO_AddChild6:AddChild;
        public var _SWMMO_AddChild7:AddChild;
        public var _SWMMO_AddChild8:AddChild;
        public var _SWMMO_AddChild9:AddChild;
        public var _SWMMO_AddChild3:AddChild;
        private var _338299245ID_DebugInfoPanelShowPlayerInfo:CheckBox;
        private var _361154989GAMESTATE_ID_WAREHOUSE_INFO_PANEL:WarehouseInfoPanel;
        private var _embed_css_____data_src_gfx_embedded_scrollbars_slider_png_2042007750:Class;
        private var _embed_css_____data_src_gfx_embedded_buttons_x_highlight_png_1750437863:Class;
        private var _962977397SingleDepositAmountTextBoxID:TextInput;
        private var _2088117886GAMESTATE_ID_TRADING_PANEL:TradingPanel;
        private var _1594990820GAMESTATE_ID_BUILD_QUEUE:BuildQueue;
        private var _1838855873GAMESTATE_ID_OPTIONS_PANEL:OptionsPanel;
        private var _embed_css_____data_src_gfx_embedded_friendslist_frame_arrow_png_1710501041:Class;
        private var _283820919GAMESTATE_ID_HINT_POINTER:HintPointer;
        private var _1665083199SectorIdButton4:Button;
        public var GAMESTATE_ID_CHAT_PANEL:ChatPanel = null;
        private var _994711914GAMESTATE_ID_QUEST_BOOK:QuestBook;
        private var _1299074340newSectorIDTextInput:TextInput;
        private var _672299061AssignGroupID:Button;
        private var _embed_css_____data_src_gfx_embedded_basicpanel_standard_png_1527688305:Class;
        private var _embed_css_____data_src_gfx_embedded_chat_button_active_png_1795709403:Class;
        private var _2078777808GAMESTATE_ID_RESIDENCE_INFO_PANEL:ResidenceInfoPanel;
        public var mCanvasFocused:Boolean = true;
        private var _embed_css_____data_src_gfx_embedded_buttons_x_standard_png_1960716715:Class;
        public var mApplicationActive:Boolean = true;
        private var _139379434mCheatBoxtDataProvider:ArrayCollection;
        private var _210862169GAMESTATE_ID_ACTIONBAR:ActionBar;
        private var _620159487EDITORSTATE_PressoktocontinueId:Text;
        private var _619849891mAssignUnitsData:ArrayCollection;
        private var _embed_css_____data_src_gfx_embedded_actionbar_actionbar4_png_198323484:Class;
        private var _embed_css_____data_src_gfx_embedded_actionbar_actionbar1_png_182802203:Class;
        private var _1391140623ID_DebugInfoPanelShowDetailErrorLog:CheckBox;
        private var _1665083195SectorIdButton8:Button;
        private var _1808756020DepositGroupWindowID:TabNavigator;
        private var _embed_css_____data_src_gfx_embedded_options_textbutton_standard_png_250050480:Class;
        private var _embed_css_____data_src_gfx_embedded_scrollbars_bar_png_2145225976:Class;
        private var _338894559EDITORSTATE_ID_TILE_LIST_GO:TileList;
        private var _embed_css_____data_src_gfx_embedded_infobar_infobar_left_png_1559235610:Class;
        private var _embed_css_____data_src_gfx_embedded_scrollbars_arrow_down_png_2004989061:Class;
        private var _777035857DeletegroupID:Button;
        private var _embed_css_____data_src_gfx_embedded_shop_buy_banner_bg_png_1642103810:Class;
        private var _394601000EDITORSTATE_focusID:List;
        private var _1603470112GAMESTATE_ID_MEMORY_MONITOR:MemoryMonitorPanel;
        private var _1665083203SectorIdButton0:Button;
        public var mMouseMove:int = 0;
        private var mDepositGroupDataNr:int;
        private var _embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_standard_png_475121235:Class;
        private var _1999815380GAMESTATE_ID_MAIL_WINDOW:MailWindow;
        private var _1810592364FILTER_BUILDING_Timedproduction:CheckBox;
        private var _embed_css_____data_src_gfx_embedded_quest_quest_ornamental1_png_1017257770:Class;
        private var _533088117radiogroupOwnerShip:RadioButtonGroup;
        var _bindings:Array;
        private var _486907459FILTER_BUILDING_ALL_ID:Button;
        private var _310338915SetSectorID:RadioButton;
        private var _374144381ID_SHOW_DEBUG_INFO_PANEL:Panel;
        private var _1087128877AssignedUnitID:DataGrid;
        private var _1430755399AutorefreshID:CheckBox;
        private var _2063705802GAMESTATE_ID_TRACKED_MISSION_LIST:TrackedMissionList;
        private var _1034233257ResourceProductionWindow:TitleWindow;
        private var lastEnterFrame:Number = 0;
        private var _1081215185SectorListCloseID:DataGrid;
        private var _177000173ID_DebugInfoPanelAdditionalDebugInfo:CheckBox;
        private var _embed_css_____data_src_gfx_embedded_chat_maximize_highlighted_png_503401341:Class;
        private var _680378296GAMESTATE_ID_LOADING_ZONE_PANEL:LoadingZonePanel;
        private var _257851832GAMESTATE_ID_ADD_FRIENDS_PANEL:AddFriendsPanel;
        private var _1121668823SectorIDInput:TextInput;
        private var _embed_css_____data_src_gfx_embedded_news_news_bg_bottom_png_2063566116:Class;
        private var _386188467radiogroupSetBlocking:RadioButtonGroup;
        private var _embed_css_____data_src_gfx_embedded_buttons_x_inactive_png_1807742325:Class;
        private var _1301551436GAMESTATE_ID_FRIENDS_LIST:FriendsList;
        private const DEACTIVATE_HANDLER_ACTIVE:Boolean = true;
        private var _831698110FILTER_BUILDING_Residence:CheckBox;
        private var _182712865SingleDepositAmountLabelID:Label;
        private var _1939975865UnitListDataID:DataGrid;
        private var _embed_css_____data_src_gfx_embedded_trade_line_png_1788743121:Class;
        private var _embed_css_____data_src_gfx_embedded_scrollbars_arrow_up_png_729897109:Class;
        private var _1559728843oldSectorIDTextInput:TextInput;
        private var _1320391867mSectorListData:ArrayCollection;
        private var _embed_css_____data_src_gfx_embedded_actionbar_actionbar2_png_198840077:Class;
        private var _embed_css_____data_src_gfx_embedded_quest_quest_bg_top_png_222217371:Class;
        private var _387573656GAMESTATE_ID_DARKEN_PANEL:DarkenPanel;
        private var _1702874708FILTER_BUILDING_undefined:CheckBox;
        private var _embed_css_____data_src_gfx_embedded_chat_bg_chattab_png_1946073156:Class;
        private var _433533921brushSizeRadiogroup:RadioButtonGroup;
        private var _embed_css_____data_src_gfx_embedded_infobar_infobar_right_png_2090990534:Class;
        private var _1792787757blueFireComponent:BlueFireComponent;
        private var _1859193339ID_DebugInfoPanelShowFPS:CheckBox;
        private var _25308226mGeneralInterface:cGeneralInterface = null;
        private var _embed_css_____data_src_gfx_embedded_chat_maximize_standard_png_1106313599:Class;
        private var _743085236radiogroupOwnerShipPlayer:RadioButton;
        private var _embed_css_____data_src_gfx_embedded_trade_item_background_png_2047890676:Class;
        private var _1726370163GAMESTATE_ID_TIMED_PRODUCTION_INFO_PANEL:TimedProductionInfoPanel;
        private var _1665083198SectorIdButton5:Button;
        private var _132846140mTileListDataProviderGO:ArrayCollection;
        private var _1166847129GAMESTATE_ID_LIST_CL01_BUILDINGS:BuildingsList;
        private var _892028954GAMESTATE_ID_LEGAL_PANEL:LegalPanel;
        private var _embed_css_____data_src_gfx_embedded_quest_quest_bg_bottom_gold_png_1079221376:Class;
        public var mMouseOverCanvas:Boolean = false;
        private var _1794906212GAMESTATE_ID_CANCEL_ACTION_PANEL:CancelActionPanel;
        private var _embed_css_____data_src_gfx_embedded_chat_textbox_png_1978418198:Class;
        private var mAssignedUnitsSelectedRow:int = -1;
        public var _SWMMO_AddChild10:AddChild;
        public var _SWMMO_AddChild11:AddChild;
        public var _SWMMO_AddChild12:AddChild;
        public var _SWMMO_AddChild14:AddChild;
        public var _SWMMO_AddChild15:AddChild;
        public var _SWMMO_AddChild16:AddChild;
        public var _SWMMO_AddChild17:AddChild;
        public var _SWMMO_AddChild18:AddChild;
        public var _SWMMO_AddChild19:AddChild;
        private var _754674511SingleDepositID:Canvas;
        private var _646604368BrushSizeVBox:VBox;
        public var _SWMMO_AddChild13:AddChild;
        public var _SWMMO_AddChild20:AddChild;
        public var _SWMMO_AddChild21:AddChild;
        public var _SWMMO_AddChild23:AddChild;
        public var _SWMMO_AddChild24:AddChild;
        public var _SWMMO_AddChild25:AddChild;
        public var _SWMMO_AddChild26:AddChild;
        public var _SWMMO_AddChild27:AddChild;
        public var _SWMMO_AddChild28:AddChild;
        public var _SWMMO_AddChild29:AddChild;
        private var _1887414006GAMESTATE_ID_TAVERN_INFO_PANEL:TavernInfoPanel;
        public var _SWMMO_AddChild22:AddChild;
        private var _1665083194SectorIdButton9:Button;
        private var _embed_css_____data_src_gfx_embedded_chat_bg_chattab_highlight_png_158597178:Class;
        private var mCurrentRow:int = -1;
        public var _SWMMO_AddChild30:AddChild;
        public var _SWMMO_AddChild31:AddChild;
        public var _SWMMO_AddChild32:AddChild;
        public var _SWMMO_AddChild33:AddChild;
        public var _SWMMO_AddChild34:AddChild;
        public var _SWMMO_AddChild35:AddChild;
        public var _SWMMO_AddChild36:AddChild;
        public var _SWMMO_AddChild37:AddChild;
        public var _SWMMO_AddChild38:AddChild;
        public var _SWMMO_AddChild39:AddChild;
        private var _1709618990btnRunTests:Button;
        private var _270958984GAMESTATE_ID_AVATAR_MESSAGE_LIST:AvatarMessageList;
        public var mEditorInterface:cEditorInterface = null;
        private var _embed_css_____data_src_gfx_embedded_quest_quest_bg_bottom_png_856676144:Class;
        public var _SWMMO_AddChild41:AddChild;
        public var _SWMMO_AddChild43:AddChild;
        public var _SWMMO_AddChild44:AddChild;
        public var _SWMMO_AddChild45:AddChild;
        public var _SWMMO_AddChild47:AddChild;
        public var _SWMMO_AddChild42:AddChild;
        public var _SWMMO_AddChild46:AddChild;
        public var _SWMMO_AddChild48:AddChild;
        public var _SWMMO_AddChild49:AddChild;
        private var _1404469379GAMESTATE_ID_ENEMY_BUILDING_INFO_PANEL:EnemyBuildingInfoPanel;
        private var _97475834GAMESTATE_ID_INFO_BAR:InfoBar;
        public var _SWMMO_AddChild51:AddChild;
        public var _SWMMO_AddChild52:AddChild;
        public var _SWMMO_AddChild54:AddChild;
        public var _SWMMO_AddChild56:AddChild;
        private var _1730107957GAMESTATE_ID_MYSTERYBOX_PANEL:MysteryBoxPanel;
        public var _SWMMO_AddChild58:AddChild;
        private var _1665083202SectorIdButton1:Button;
        public var _SWMMO_AddChild53:AddChild;
        public var _SWMMO_AddChild55:AddChild;
        private var _embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_home_standard_png_211790793:Class;
        public var _SWMMO_AddChild57:AddChild;
        public var _SWMMO_AddChild50:AddChild;
        public var _SWMMO_AddChild59:AddChild;
        private var mUnitsListSelectedRow:int = -1;
        public var _SWMMO_AddChild40:AddChild;
        private var _1514347810FILTER_BUILDING_Watchtower:CheckBox;
        public var _SWMMO_AddChild60:AddChild;
        public var _SWMMO_AddChild61:AddChild;
        public var _SWMMO_AddChild62:AddChild;
        public var _SWMMO_AddChild63:AddChild;
        public var _SWMMO_AddChild64:AddChild;
        public var _SWMMO_AddChild65:AddChild;
        public var _SWMMO_AddChild66:AddChild;
        public var _SWMMO_AddChild67:AddChild;
        public var _SWMMO_AddChild68:AddChild;
        public var _SWMMO_AddChild69:AddChild;
        public var _SWMMO_SetProperty15:SetProperty;
        public var _SWMMO_SetProperty16:SetProperty;
        private var _1665653573btnStartGameDebug:Button;
        private var _885774311mUnitListData:ArrayCollection;
        public var _SWMMO_AddChild70:AddChild;
        public var _SWMMO_AddChild71:AddChild;
        public var _SWMMO_AddChild72:AddChild;
        public var _SWMMO_AddChild73:AddChild;
        public var _SWMMO_AddChild74:AddChild;
        public var _SWMMO_AddChild75:AddChild;
        public var _SWMMO_AddChild76:AddChild;
        public var _SWMMO_AddChild77:AddChild;
        private var _embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_home_mouseover_png_356112253:Class;
        private var _526777977ResourceProductionWindowDataGrid:DataGrid;
        private var _211822309SelectBuildingWindowID:TitleWindow;
        private var _1764493255AddgroupID:Button;
        private var _embed_css_____data_src_gfx_embedded_actionbar_actionbar3_png_187868604:Class;
        private var _embed_css_____data_src_gfx_embedded_alert_alert_payment_background_png_1386292608:Class;
        private var _825365214FILTER_BUILDING_NONE_ID:Button;
        private var _1892912377EDITORSTATE_ID_TILE_LIST_SET_MODE:TileList;
        private var _1283861792GAMESTATE_ID_CHEAT_WINDOW:CheatWindow;
        private var _314430682GAMESTATE_ID_BUILDING_INFO_PANEL:BuildingInfoPanel;
        private var _embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_home_push_png_924116583:Class;
        private var _236967708EDITORSTATE__ID_CHEAT_WINDOW:CheatWindow;
        private var _embed_css_____data_src_gfx_embedded_quest_vertical_line_png_301357951:Class;
        private var _embed_css_____data_src_gfx_embedded_basicpanel_special_png_1513629018:Class;
        private var _embed_css_____data_src_gfx_embedded_buildqueue_background_png_1041264038:Class;
        private var _embed_css_____data_src_gfx_embedded_quest_quest_bg_gold_png_435591269:Class;
        private var _1059232882GAMESTATE_ID_FRIENDS_LIST_MENU:FriendsListMenu;
        private var _2118605938AssignUnitID:Button;
        private var _77996922GAMESTATE_ID_SPECIALIST_PANEL:SpecialistPanel;
        private var _embed_css_____data_src_gfx_embedded_buttons_x_small_standard_png_54314235:Class;
        private var _1895114508EDITORSTATE_ApplicationdisabledId:Text;
        private var _592859997BrushSizeTextInputId:TextInput;
        private var _embed_css_____data_src_gfx_embedded_friendslist_friendslist4_png_1649435005:Class;
        private var _embed_css_____data_src_gfx_embedded_buildingmenu_bg_item_png_1037144546:Class;
        private var _embed_css_____data_src_gfx_embedded_buttons_standard_png_198723130:Class;
        private var _embed_css_____data_src_gfx_embedded_chat_button_standard_png_1496437355:Class;
        public var _SWMMO_SetProperty2:SetProperty;
        public var _SWMMO_SetProperty3:SetProperty;
        private var _345705597GAMESTATE_ID_AVATAR:Avatar;
        public var _SWMMO_SetProperty8:SetProperty;
        public var _SWMMO_SetProperty9:SetProperty;
        public var _SWMMO_SetProperty5:SetProperty;
        private var _802978248GAMESTATE_ID_NEWS_WINDOW:NewsWindow;
        private var _761777309GAMESTATE_ID_CONSTRUCTION_INFO_PANEL:ConstructionInfoPanel;
        var _watchers:Array;
        private var _528971107ReAssignSectorIDCancel:Button;
        private var _1665083197SectorIdButton6:Button;
        private var _626564234GAMESTATE_ID_QUEST_NEW_QUEST_SYSTEM_LIST_PANEL:QuestNewQuestSystemList;
        private var _1921297217SectorListCloseIDButton:Button;
        private var _722613835GAMESTATE_ID_MINIMAL_INFO_PANEL:MinimalInfoPanel;
        private var _538934443ReAssignSectorIDButton:Button;
        private var _226797582menuBarCollection:XMLListCollection;
        private var _1311028358FILTER_BUILDING_SortNames:CheckBox;
        private var _712858845FILTER_BUILDING_Minimal:CheckBox;
        private var _1897880070ID_DebugInfoPanelShowOnScreenGameTickCommands:CheckBox;
        private var _embed_css_____data_src_gfx_embedded_buttons_standard_disabled_png_1784034958:Class;
        private var _1231251544mDepositGroupData:ArrayCollection;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _embed_css_____data_src_gfx_embedded_chat_scale_standard_png_103566885:Class;
        private static var _watcherSetupUtil:IWatcherSetupUtil;
        static var _SWMMO_StylesInit_done:Boolean = false;

        public function SWMMO()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Application, propertiesFactory:function () : Object
            {
                return {childDescriptors:[new UIComponentDescriptor({type:Canvas, id:"myCanvas", propertiesFactory:function () : Object
                {
                    return {null:0, y:0, percentWidth:100, percentHeight:100};
                }// end function
                })]};
            }// end function
            });
            this._267857324mMemoryMonitor = new gMemoryMonitor();
            this._embed_css_____data_src_gfx_embedded_actionbar_actionbar1_png_182802203 = SWMMO__embed_css_____data_src_gfx_embedded_actionbar_actionbar1_png_182802203;
            this._embed_css_____data_src_gfx_embedded_actionbar_actionbar2_png_198840077 = SWMMO__embed_css_____data_src_gfx_embedded_actionbar_actionbar2_png_198840077;
            this._embed_css_____data_src_gfx_embedded_actionbar_actionbar3_png_187868604 = SWMMO__embed_css_____data_src_gfx_embedded_actionbar_actionbar3_png_187868604;
            this._embed_css_____data_src_gfx_embedded_actionbar_actionbar4_png_198323484 = SWMMO__embed_css_____data_src_gfx_embedded_actionbar_actionbar4_png_198323484;
            this._embed_css_____data_src_gfx_embedded_alert_alert_background_png_1445621566 = SWMMO__embed_css_____data_src_gfx_embedded_alert_alert_background_png_1445621566;
            this._embed_css_____data_src_gfx_embedded_alert_alert_payment_background_png_1386292608 = SWMMO__embed_css_____data_src_gfx_embedded_alert_alert_payment_background_png_1386292608;
            this._embed_css_____data_src_gfx_embedded_basicpanel_header_png_1330748332 = SWMMO__embed_css_____data_src_gfx_embedded_basicpanel_header_png_1330748332;
            this._embed_css_____data_src_gfx_embedded_basicpanel_special_png_1513629018 = SWMMO__embed_css_____data_src_gfx_embedded_basicpanel_special_png_1513629018;
            this._embed_css_____data_src_gfx_embedded_basicpanel_standard_png_1527688305 = SWMMO__embed_css_____data_src_gfx_embedded_basicpanel_standard_png_1527688305;
            this._embed_css_____data_src_gfx_embedded_basicpanel_subheader_png_797926995 = SWMMO__embed_css_____data_src_gfx_embedded_basicpanel_subheader_png_797926995;
            this._embed_css_____data_src_gfx_embedded_buildinginfo_tilelist_bg_png_1613316706 = SWMMO__embed_css_____data_src_gfx_embedded_buildinginfo_tilelist_bg_png_1613316706;
            this._embed_css_____data_src_gfx_embedded_buildingmenu_bg_item_png_1037144546 = SWMMO__embed_css_____data_src_gfx_embedded_buildingmenu_bg_item_png_1037144546;
            this._embed_css_____data_src_gfx_embedded_buildingmenu_tooltip_background_png_166192939 = SWMMO__embed_css_____data_src_gfx_embedded_buildingmenu_tooltip_background_png_166192939;
            this._embed_css_____data_src_gfx_embedded_buildqueue_background_png_1041264038 = SWMMO__embed_css_____data_src_gfx_embedded_buildqueue_background_png_1041264038;
            this._embed_css_____data_src_gfx_embedded_buttons_standard_disabled_png_1784034958 = SWMMO__embed_css_____data_src_gfx_embedded_buttons_standard_disabled_png_1784034958;
            this._embed_css_____data_src_gfx_embedded_buttons_standard_highlight_png_160955392 = SWMMO__embed_css_____data_src_gfx_embedded_buttons_standard_highlight_png_160955392;
            this._embed_css_____data_src_gfx_embedded_buttons_standard_png_198723130 = SWMMO__embed_css_____data_src_gfx_embedded_buttons_standard_png_198723130;
            this._embed_css_____data_src_gfx_embedded_buttons_x_highlight_png_1750437863 = SWMMO__embed_css_____data_src_gfx_embedded_buttons_x_highlight_png_1750437863;
            this._embed_css_____data_src_gfx_embedded_buttons_x_inactive_png_1807742325 = SWMMO__embed_css_____data_src_gfx_embedded_buttons_x_inactive_png_1807742325;
            this._embed_css_____data_src_gfx_embedded_buttons_x_small_selected_png_400774907 = SWMMO__embed_css_____data_src_gfx_embedded_buttons_x_small_selected_png_400774907;
            this._embed_css_____data_src_gfx_embedded_buttons_x_small_standard_png_54314235 = SWMMO__embed_css_____data_src_gfx_embedded_buttons_x_small_standard_png_54314235;
            this._embed_css_____data_src_gfx_embedded_buttons_x_standard_png_1960716715 = SWMMO__embed_css_____data_src_gfx_embedded_buttons_x_standard_png_1960716715;
            this._embed_css_____data_src_gfx_embedded_camera_camera_bg_png_902640356 = SWMMO__embed_css_____data_src_gfx_embedded_camera_camera_bg_png_902640356;
            this._embed_css_____data_src_gfx_embedded_chat_bg_chattab_highlight_png_158597178 = SWMMO__embed_css_____data_src_gfx_embedded_chat_bg_chattab_highlight_png_158597178;
            this._embed_css_____data_src_gfx_embedded_chat_bg_chattab_png_1946073156 = SWMMO__embed_css_____data_src_gfx_embedded_chat_bg_chattab_png_1946073156;
            this._embed_css_____data_src_gfx_embedded_chat_bg_chattab_selected_png_700177882 = SWMMO__embed_css_____data_src_gfx_embedded_chat_bg_chattab_selected_png_700177882;
            this._embed_css_____data_src_gfx_embedded_chat_button_active_png_1795709403 = SWMMO__embed_css_____data_src_gfx_embedded_chat_button_active_png_1795709403;
            this._embed_css_____data_src_gfx_embedded_chat_button_selected_png_381018229 = SWMMO__embed_css_____data_src_gfx_embedded_chat_button_selected_png_381018229;
            this._embed_css_____data_src_gfx_embedded_chat_button_standard_png_1496437355 = SWMMO__embed_css_____data_src_gfx_embedded_chat_button_standard_png_1496437355;
            this._embed_css_____data_src_gfx_embedded_chat_maximize_highlighted_png_503401341 = SWMMO__embed_css_____data_src_gfx_embedded_chat_maximize_highlighted_png_503401341;
            this._embed_css_____data_src_gfx_embedded_chat_maximize_standard_png_1106313599 = SWMMO__embed_css_____data_src_gfx_embedded_chat_maximize_standard_png_1106313599;
            this._embed_css_____data_src_gfx_embedded_chat_minimize_highlighted_png_1579240229 = SWMMO__embed_css_____data_src_gfx_embedded_chat_minimize_highlighted_png_1579240229;
            this._embed_css_____data_src_gfx_embedded_chat_minimize_standard_png_197453125 = SWMMO__embed_css_____data_src_gfx_embedded_chat_minimize_standard_png_197453125;
            this._embed_css_____data_src_gfx_embedded_chat_scale_highlighted_png_935498501 = SWMMO__embed_css_____data_src_gfx_embedded_chat_scale_highlighted_png_935498501;
            this._embed_css_____data_src_gfx_embedded_chat_scale_standard_png_103566885 = SWMMO__embed_css_____data_src_gfx_embedded_chat_scale_standard_png_103566885;
            this._embed_css_____data_src_gfx_embedded_chat_textbox_png_1978418198 = SWMMO__embed_css_____data_src_gfx_embedded_chat_textbox_png_1978418198;
            this._embed_css_____data_src_gfx_embedded_friendslist_frame_arrow_png_1710501041 = SWMMO__embed_css_____data_src_gfx_embedded_friendslist_frame_arrow_png_1710501041;
            this._embed_css_____data_src_gfx_embedded_friendslist_friendslist1_png_2010943604 = SWMMO__embed_css_____data_src_gfx_embedded_friendslist_friendslist1_png_2010943604;
            this._embed_css_____data_src_gfx_embedded_friendslist_friendslist2_png_1667250557 = SWMMO__embed_css_____data_src_gfx_embedded_friendslist_friendslist2_png_1667250557;
            this._embed_css_____data_src_gfx_embedded_friendslist_friendslist3_png_1983284784 = SWMMO__embed_css_____data_src_gfx_embedded_friendslist_friendslist3_png_1983284784;
            this._embed_css_____data_src_gfx_embedded_friendslist_friendslist4_png_1649435005 = SWMMO__embed_css_____data_src_gfx_embedded_friendslist_friendslist4_png_1649435005;
            this._embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_home_mouseover_png_356112253 = SWMMO__embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_home_mouseover_png_356112253;
            this._embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_home_push_png_924116583 = SWMMO__embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_home_push_png_924116583;
            this._embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_home_standard_png_211790793 = SWMMO__embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_home_standard_png_211790793;
            this._embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_mouseover_png_890993175 = SWMMO__embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_mouseover_png_890993175;
            this._embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_push_png_1621504697 = SWMMO__embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_push_png_1621504697;
            this._embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_standard_png_475121235 = SWMMO__embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_standard_png_475121235;
            this._embed_css_____data_src_gfx_embedded_infobar_infobar_left_png_1559235610 = SWMMO__embed_css_____data_src_gfx_embedded_infobar_infobar_left_png_1559235610;
            this._embed_css_____data_src_gfx_embedded_infobar_infobar_mid_png_222120674 = SWMMO__embed_css_____data_src_gfx_embedded_infobar_infobar_mid_png_222120674;
            this._embed_css_____data_src_gfx_embedded_infobar_infobar_right_png_2090990534 = SWMMO__embed_css_____data_src_gfx_embedded_infobar_infobar_right_png_2090990534;
            this._embed_css_____data_src_gfx_embedded_news_news_bg_bottom_png_2063566116 = SWMMO__embed_css_____data_src_gfx_embedded_news_news_bg_bottom_png_2063566116;
            this._embed_css_____data_src_gfx_embedded_options_option_bg_small_png_911592548 = SWMMO__embed_css_____data_src_gfx_embedded_options_option_bg_small_png_911592548;
            this._embed_css_____data_src_gfx_embedded_options_textbutton_inactive_png_40222180 = SWMMO__embed_css_____data_src_gfx_embedded_options_textbutton_inactive_png_40222180;
            this._embed_css_____data_src_gfx_embedded_options_textbutton_mouseover_png_1972989270 = SWMMO__embed_css_____data_src_gfx_embedded_options_textbutton_mouseover_png_1972989270;
            this._embed_css_____data_src_gfx_embedded_options_textbutton_standard_png_250050480 = SWMMO__embed_css_____data_src_gfx_embedded_options_textbutton_standard_png_250050480;
            this._embed_css_____data_src_gfx_embedded_quest_quest_bg_bottom_gold_png_1079221376 = SWMMO__embed_css_____data_src_gfx_embedded_quest_quest_bg_bottom_gold_png_1079221376;
            this._embed_css_____data_src_gfx_embedded_quest_quest_bg_bottom_png_856676144 = SWMMO__embed_css_____data_src_gfx_embedded_quest_quest_bg_bottom_png_856676144;
            this._embed_css_____data_src_gfx_embedded_quest_quest_bg_gold_png_435591269 = SWMMO__embed_css_____data_src_gfx_embedded_quest_quest_bg_gold_png_435591269;
            this._embed_css_____data_src_gfx_embedded_quest_quest_bg_top_png_222217371 = SWMMO__embed_css_____data_src_gfx_embedded_quest_quest_bg_top_png_222217371;
            this._embed_css_____data_src_gfx_embedded_quest_quest_ornamental1_png_1017257770 = SWMMO__embed_css_____data_src_gfx_embedded_quest_quest_ornamental1_png_1017257770;
            this._embed_css_____data_src_gfx_embedded_quest_vertical_line_png_301357951 = SWMMO__embed_css_____data_src_gfx_embedded_quest_vertical_line_png_301357951;
            this._embed_css_____data_src_gfx_embedded_scrollbars_arrow_down_png_2004989061 = SWMMO__embed_css_____data_src_gfx_embedded_scrollbars_arrow_down_png_2004989061;
            this._embed_css_____data_src_gfx_embedded_scrollbars_arrow_up_png_729897109 = SWMMO__embed_css_____data_src_gfx_embedded_scrollbars_arrow_up_png_729897109;
            this._embed_css_____data_src_gfx_embedded_scrollbars_bar_png_2145225976 = SWMMO__embed_css_____data_src_gfx_embedded_scrollbars_bar_png_2145225976;
            this._embed_css_____data_src_gfx_embedded_scrollbars_slider_png_2042007750 = SWMMO__embed_css_____data_src_gfx_embedded_scrollbars_slider_png_2042007750;
            this._embed_css_____data_src_gfx_embedded_shop_buy_banner_bg_png_1642103810 = SWMMO__embed_css_____data_src_gfx_embedded_shop_buy_banner_bg_png_1642103810;
            this._embed_css_____data_src_gfx_embedded_shop_buy_item_bg_details_png_1231834048 = SWMMO__embed_css_____data_src_gfx_embedded_shop_buy_item_bg_details_png_1231834048;
            this._embed_css_____data_src_gfx_embedded_shop_footer_png_1480837470 = SWMMO__embed_css_____data_src_gfx_embedded_shop_footer_png_1480837470;
            this._embed_css_____data_src_gfx_embedded_trade_avatar_box_png_782837924 = SWMMO__embed_css_____data_src_gfx_embedded_trade_avatar_box_png_782837924;
            this._embed_css_____data_src_gfx_embedded_trade_item_background_png_2047890676 = SWMMO__embed_css_____data_src_gfx_embedded_trade_item_background_png_2047890676;
            this._embed_css_____data_src_gfx_embedded_trade_line_png_1788743121 = SWMMO__embed_css_____data_src_gfx_embedded_trade_line_png_1788743121;
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            if (!this.styleDeclaration)
            {
                this.styleDeclaration = new CSSStyleDeclaration();
            }
            this.styleDeclaration.defaultFactory = function () : void
            {
                null.backgroundGradientColors = [this, 4151151];
                this.borderStyle = "solid";
                this.paddingTop = 0;
                this.paddingBottom = 0;
                this.paddingLeft = 0;
                this.paddingRight = 0;
                return;
            }// end function
            ;
            .mx_internal::_SWMMO_StylesInit();
            this.clipContent = true;
            this.layout = "absolute";
            this.horizontalPageScrollSize = 0;
            this.horizontalScrollPolicy = "off";
            this.horizontalScrollPosition = 0;
            this.verticalPageScrollSize = 0;
            this.verticalScrollPolicy = "off";
            this.verticalScrollPosition = 0;
            this.currentState = "LoadSettings";
            this.states = [this._SWMMO_State1_c(), this._SWMMO_State2_c(), this._SWMMO_State3_c(), this._SWMMO_State4_c()];
            this._SWMMO_RadioButtonGroup1_i();
            this._SWMMO_RadioButtonGroup2_i();
            this._SWMMO_RadioButtonGroup3_i();
            this.addEventListener("applicationComplete", this.___SWMMO_Application1_applicationComplete);
            this.addEventListener("creationComplete", this.___SWMMO_Application1_creationComplete);
            this.addEventListener("enterFrame", this.___SWMMO_Application1_enterFrame);
            this.addEventListener("click", this.___SWMMO_Application1_click);
            this.addEventListener("mouseDown", this.___SWMMO_Application1_mouseDown);
            this.addEventListener("mouseUp", this.___SWMMO_Application1_mouseUp);
            this.addEventListener("mouseMove", this.___SWMMO_Application1_mouseMove);
            this.addEventListener("mouseOut", this.___SWMMO_Application1_mouseOut);
            return;
        }// end function

        public function get FILTER_BUILDING_Decoration() : CheckBox
        {
            return this._2050543604FILTER_BUILDING_Decoration;
        }// end function

        public function __DepositGroupDataGrid_creationComplete(event:FlexEvent) : void
        {
            this.DepositGroupInitDataGridData(event);
            return;
        }// end function

        private function RefreshAssignUnitsGroupWindow() : void
        {
            return;
        }// end function

        protected function SectorListID_creationCompleteHandler(event:FlexEvent) : void
        {
            return;
        }// end function

        private function _SWMMO_TextInput4_i() : TextInput
        {
            var _loc_1:* = new TextInput();
            this.UPGRADLEVEL_ID_TEXT = _loc_1;
            _loc_1.x = 107;
            _loc_1.y = 136;
            _loc_1.width = 35;
            _loc_1.text = "1";
            _loc_1.addEventListener("change", this.__UPGRADLEVEL_ID_TEXT_change);
            _loc_1.id = "UPGRADLEVEL_ID_TEXT";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function get mUnitListData() : ArrayCollection
        {
            return this._885774311mUnitListData;
        }// end function

        public function get GAMESTATE_ID_LEGAL_PANEL() : LegalPanel
        {
            return this._892028954GAMESTATE_ID_LEGAL_PANEL;
        }// end function

        private function _SWMMO_CheckBox14_i() : CheckBox
        {
            var _loc_1:CheckBox = null;
            _loc_1 = new CheckBox();
            this.ID_DebugInfoPanelShowFPS = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 68;
            _loc_1.label = "Show FPS";
            _loc_1.id = "ID_DebugInfoPanelShowFPS";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        protected function ID_SHOW_DEBUG_INFO_PANEL_clickHandler(event:MouseEvent) : void
        {
            this.ID_SHOW_DEBUG_INFO_PANEL_hideHandler(null);
            return;
        }// end function

        public function __ID_SHOW_DEBUG_INFO_PANEL_click(event:MouseEvent) : void
        {
            this.ID_SHOW_DEBUG_INFO_PANEL_clickHandler(event);
            return;
        }// end function

        protected function AssignedUnitID_itemClickHandler(event:ListEvent) : void
        {
            if (this.mGeneralInterface.mCurrentlySelectededBuilding != null)
            {
                this.mAssignedUnitsSelectedRow = event.itemRenderer.data.SortID;
            }
            return;
        }// end function

        protected function TabNavigatorID_tabChildrenChangeHandler(event:Event) : void
        {
            return;
        }// end function

        protected function radiobuttonFree_clickHandler(event:MouseEvent) : void
        {
            return;
        }// end function

        private function _SWMMO_BuildingsList2_i() : BuildingsList
        {
            var _loc_1:BuildingsList = null;
            _loc_1 = new BuildingsList();
            this.GAMESTATE_ID_LIST_CL01_BUILDINGS = _loc_1;
            _loc_1.visible = false;
            _loc_1.id = "GAMESTATE_ID_LIST_CL01_BUILDINGS";
            BindingManager.executeBindings(this, "GAMESTATE_ID_LIST_CL01_BUILDINGS", this.GAMESTATE_ID_LIST_CL01_BUILDINGS);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set GAMESTATE_ID_LEGAL_PANEL(param1:LegalPanel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._892028954GAMESTATE_ID_LEGAL_PANEL;
            if (_loc_2 !== param1)
            {
                this._892028954GAMESTATE_ID_LEGAL_PANEL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_LEGAL_PANEL", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_Button17_i() : Button
        {
            var _loc_1:* = new Button();
            this.ReAssignSectorIDButton = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 63;
            _loc_1.label = "Re Assign";
            _loc_1.addEventListener("click", this.__ReAssignSectorIDButton_click);
            _loc_1.id = "ReAssignSectorIDButton";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set brushSizeRadiogroup(param1:RadioButtonGroup) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._433533921brushSizeRadiogroup;
            if (_loc_2 !== param1)
            {
                this._433533921brushSizeRadiogroup = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "brushSizeRadiogroup", _loc_2, param1));
            }
            return;
        }// end function

        public function get AddgroupID() : Button
        {
            return this._1764493255AddgroupID;
        }// end function

        private function set mUnitListData(param1:ArrayCollection) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._885774311mUnitListData;
            if (_loc_2 !== param1)
            {
                this._885774311mUnitListData = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mUnitListData", _loc_2, param1));
            }
            return;
        }// end function

        public function get AutorefreshID() : CheckBox
        {
            return this._1430755399AutorefreshID;
        }// end function

        private function _SWMMO_ClassFactory2_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = cItemRendererTileList;
            return _loc_1;
        }// end function

        private function get mDepositGroupData() : ArrayCollection
        {
            return this._1231251544mDepositGroupData;
        }// end function

        private function _SWMMO_SetProperty15_i() : SetProperty
        {
            var _loc_1:SetProperty = null;
            _loc_1 = new SetProperty();
            this._SWMMO_SetProperty15 = _loc_1;
            _loc_1.name = "verticalScrollPolicy";
            _loc_1.value = "off";
            BindingManager.executeBindings(this, "_SWMMO_SetProperty15", this._SWMMO_SetProperty15);
            return _loc_1;
        }// end function

        private function _SWMMO_AddChild60_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild60 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_SpecialistTravelPanel1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild60", this._SWMMO_AddChild60);
            return _loc_1;
        }// end function

        public function ___SWMMO_Application1_creationComplete(event:FlexEvent) : void
        {
            this.creationComplete();
            return;
        }// end function

        public function set mTileListDataProviderSetMode(param1:ArrayCollection) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._143676367mTileListDataProviderSetMode;
            if (_loc_2 !== param1)
            {
                this._143676367mTileListDataProviderSetMode = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mTileListDataProviderSetMode", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_RadioButton6_c() : RadioButton
        {
            var _loc_1:* = new RadioButton();
            _loc_1.label = "3";
            _loc_1.groupName = "brushSizeRadiogroup";
            _loc_1.addEventListener("click", this.___SWMMO_RadioButton6_click);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get GAMESTATE_ID_ACTIONBAR() : ActionBar
        {
            return this._210862169GAMESTATE_ID_ACTIONBAR;
        }// end function

        private function _SWMMO_AddChild71_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild71 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_NewsWindow1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild71", this._SWMMO_AddChild71);
            return _loc_1;
        }// end function

        private function _SWMMO_AddChild7_i() : AddChild
        {
            var _loc_1:* = new AddChild();
            this._SWMMO_AddChild7 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_TitleWindow1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild7", this._SWMMO_AddChild7);
            return _loc_1;
        }// end function

        public function get GAMESTATE_ID_DARKEN_PANEL() : DarkenPanel
        {
            return this._387573656GAMESTATE_ID_DARKEN_PANEL;
        }// end function

        private function _SWMMO_DataGrid2_i() : DataGrid
        {
            var _loc_1:* = new DataGrid();
            this.AssignedUnitID = _loc_1;
            _loc_1.y = 26;
            _loc_1.height = 228;
            _loc_1.editable = true;
            _loc_1.columns = [this._SWMMO_DataGridColumn5_c(), this._SWMMO_DataGridColumn6_c()];
            _loc_1.setStyle("left", "379.5");
            _loc_1.setStyle("right", "10");
            _loc_1.addEventListener("itemClick", this.__AssignedUnitID_itemClick);
            _loc_1.addEventListener("itemEditEnd", this.__AssignedUnitID_itemEditEnd);
            _loc_1.id = "AssignedUnitID";
            BindingManager.executeBindings(this, "AssignedUnitID", this.AssignedUnitID);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_AddChild18_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild18 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_Label10_c);
            BindingManager.executeBindings(this, "_SWMMO_AddChild18", this._SWMMO_AddChild18);
            return _loc_1;
        }// end function

        public function get ID_DebugInfoPanelShowErrorLog() : CheckBox
        {
            return this._1506992000ID_DebugInfoPanelShowErrorLog;
        }// end function

        private function _SWMMO_TimedProductionInfoPanel1_i() : TimedProductionInfoPanel
        {
            var _loc_1:TimedProductionInfoPanel = null;
            _loc_1 = new TimedProductionInfoPanel();
            this.GAMESTATE_ID_TIMED_PRODUCTION_INFO_PANEL = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "GAMESTATE_ID_TIMED_PRODUCTION_INFO_PANEL";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get GAMESTATE_ID_ENEMY_BUILDING_INFO_PANEL() : EnemyBuildingInfoPanel
        {
            return this._1404469379GAMESTATE_ID_ENEMY_BUILDING_INFO_PANEL;
        }// end function

        private function _SWMMO_RadioButton13_i() : RadioButton
        {
            var _loc_1:* = new RadioButton();
            this.RedBlockingRadioButtonID = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 10;
            _loc_1.label = "Red Blocking (All)";
            _loc_1.groupName = "radiogroupSetBlocking";
            _loc_1.selected = true;
            _loc_1.id = "RedBlockingRadioButtonID";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get radiogroupOwnerShip() : RadioButtonGroup
        {
            return this._533088117radiogroupOwnerShip;
        }// end function

        private function _SWMMO_CheckBox8_i() : CheckBox
        {
            var _loc_1:* = new CheckBox();
            this.FILTER_BUILDING_Timedproduction = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 76;
            _loc_1.label = "Timedproduction";
            _loc_1.setStyle("color", 0);
            _loc_1.setStyle("fontSize", 12);
            _loc_1.addEventListener("click", this.__FILTER_BUILDING_Timedproduction_click);
            _loc_1.id = "FILTER_BUILDING_Timedproduction";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set AutorefreshID(param1:CheckBox) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1430755399AutorefreshID;
            if (_loc_2 !== param1)
            {
                this._1430755399AutorefreshID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "AutorefreshID", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_TextInput2_i() : TextInput
        {
            var _loc_1:* = new TextInput();
            this.BrushSizeTextInputId = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 161;
            _loc_1.width = 42;
            _loc_1.text = "1";
            _loc_1.addEventListener("change", this.__BrushSizeTextInputId_change);
            _loc_1.id = "BrushSizeTextInputId";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_Label9_c() : Label
        {
            var _loc_1:Label = null;
            _loc_1 = new Label();
            _loc_1.text = "Settlers Web MMO Alpha ";
            _loc_1.y = 170;
            _loc_1.setStyle("fontSize", 30);
            _loc_1.setStyle("color", 0);
            _loc_1.setStyle("horizontalCenter", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_AddChild29_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild29 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_InfoBar1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild29", this._SWMMO_AddChild29);
            return _loc_1;
        }// end function

        private function _SWMMO_CheckBox12_i() : CheckBox
        {
            var _loc_1:CheckBox = null;
            _loc_1 = new CheckBox();
            this.ID_DebugInfoPanelShowAll = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 10;
            _loc_1.label = "Show All";
            _loc_1.id = "ID_DebugInfoPanelShowAll";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function ___SWMMO_RadioButton4_click(event:MouseEvent) : void
        {
            this.UpdateBrushSizeRadioButtons();
            return;
        }// end function

        public function __DepositGroupWindowID_change(event:IndexChangedEvent) : void
        {
            this.TabNavigatorID_changeHandler(event);
            return;
        }// end function

        public function set AddgroupID(param1:Button) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1764493255AddgroupID;
            if (_loc_2 !== param1)
            {
                this._1764493255AddgroupID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "AddgroupID", _loc_2, param1));
            }
            return;
        }// end function

        public function __FILTER_BUILDING_SortNames_click(event:MouseEvent) : void
        {
            this.FILTER_BUILDING_clickHandler(event);
            return;
        }// end function

        private function set mDepositGroupData(param1:ArrayCollection) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1231251544mDepositGroupData;
            if (_loc_2 !== param1)
            {
                this._1231251544mDepositGroupData = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mDepositGroupData", _loc_2, param1));
            }
            return;
        }// end function

        public function set GAMESTATE_ID_ACTIONBAR(param1:ActionBar) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._210862169GAMESTATE_ID_ACTIONBAR;
            if (_loc_2 !== param1)
            {
                this._210862169GAMESTATE_ID_ACTIONBAR = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_ACTIONBAR", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_Button15_i() : Button
        {
            var _loc_1:* = new Button();
            this.RemoveUnitID = _loc_1;
            _loc_1.x = 273;
            _loc_1.y = 67;
            _loc_1.label = "Remove Unit";
            _loc_1.width = 98.5;
            _loc_1.addEventListener("click", this.__RemoveUnitID_click);
            _loc_1.id = "RemoveUnitID";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get GAMESTATE_ID_SHOP_WINDOW() : ShopWindow
        {
            return this._1146070859GAMESTATE_ID_SHOP_WINDOW;
        }// end function

        public function get SectorIdButton0() : Button
        {
            return this._1665083203SectorIdButton0;
        }// end function

        public function get SectorIdButton1() : Button
        {
            return this._1665083202SectorIdButton1;
        }// end function

        public function get SectorIdButton2() : Button
        {
            return this._1665083201SectorIdButton2;
        }// end function

        public function get SectorIdButton3() : Button
        {
            return this._1665083200SectorIdButton3;
        }// end function

        public function get SectorIdButton5() : Button
        {
            return this._1665083198SectorIdButton5;
        }// end function

        public function get SectorIdButton7() : Button
        {
            return this._1665083196SectorIdButton7;
        }// end function

        public function get SectorIdButton8() : Button
        {
            return this._1665083195SectorIdButton8;
        }// end function

        private function _SWMMO_TabNavigator1_i() : TabNavigator
        {
            var _loc_1:* = new TabNavigator();
            this.DepositGroupWindowID = _loc_1;
            _loc_1.width = 482;
            _loc_1.height = 238;
            _loc_1.selectedIndex = 1;
            _loc_1.visible = false;
            _loc_1.setStyle("bottom", "118");
            _loc_1.setStyle("left", "10");
            _loc_1.addEventListener("change", this.__DepositGroupWindowID_change);
            _loc_1.id = "DepositGroupWindowID";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SWMMO_Canvas1_i());
            _loc_1.addChild(this._SWMMO_Canvas2_i());
            return _loc_1;
        }// end function

        public function __FILTER_BUILDING_Watchtower_click(event:MouseEvent) : void
        {
            this.FILTER_BUILDING_clickHandler(event);
            return;
        }// end function

        public function get SetBlockingWindowID() : TitleWindow
        {
            return this._1370867518SetBlockingWindowID;
        }// end function

        private function _SWMMO_SetProperty13_c() : SetProperty
        {
            var _loc_1:SetProperty = null;
            _loc_1 = new SetProperty();
            _loc_1.name = "horizontalScrollPolicy";
            _loc_1.value = "off";
            return _loc_1;
        }// end function

        public function get AssignUnitsWindowID() : TitleWindow
        {
            return this._445266123AssignUnitsWindowID;
        }// end function

        public function get ID_DebugInfoPanelShowQuestInfo() : CheckBox
        {
            return this._1584604980ID_DebugInfoPanelShowQuestInfo;
        }// end function

        public function get SectorIdButton9() : Button
        {
            return this._1665083194SectorIdButton9;
        }// end function

        private function _SWMMO_EnemyBuildingInfoPanel1_i() : EnemyBuildingInfoPanel
        {
            var _loc_1:EnemyBuildingInfoPanel = null;
            _loc_1 = new EnemyBuildingInfoPanel();
            this.GAMESTATE_ID_ENEMY_BUILDING_INFO_PANEL = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("right", "100");
            _loc_1.setStyle("bottom", "180");
            _loc_1.id = "GAMESTATE_ID_ENEMY_BUILDING_INFO_PANEL";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set GAMESTATE_ID_DARKEN_PANEL(param1:DarkenPanel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._387573656GAMESTATE_ID_DARKEN_PANEL;
            if (_loc_2 !== param1)
            {
                this._387573656GAMESTATE_ID_DARKEN_PANEL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_DARKEN_PANEL", _loc_2, param1));
            }
            return;
        }// end function

        public function get SectorIdButton6() : Button
        {
            return this._1665083197SectorIdButton6;
        }// end function

        public function get EDITORSTATE_ApplicationActivated() : Panel
        {
            return this._587777860EDITORSTATE_ApplicationActivated;
        }// end function

        public function get SectorIdButton4() : Button
        {
            return this._1665083199SectorIdButton4;
        }// end function

        private function _SWMMO_RadioButton4_c() : RadioButton
        {
            var _loc_1:* = new RadioButton();
            _loc_1.label = "1";
            _loc_1.groupName = "brushSizeRadiogroup";
            _loc_1.selected = true;
            _loc_1.addEventListener("click", this.___SWMMO_RadioButton4_click);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        protected function FILTERLIST_ALL_ID_clickHandler(event:MouseEvent) : void
        {
            return;
        }// end function

        public function ___SWMMO_Application1_enterFrame(event:Event) : void
        {
            this.enterFrame(event);
            return;
        }// end function

        public function get btnRunTests() : Button
        {
            return this._1709618990btnRunTests;
        }// end function

        public function __UPGRADLEVEL_ID_TEXT_change(event:Event) : void
        {
            this.UPGRADLEVEL_ID_TEXT_changeHandler(event);
            return;
        }// end function

        private function _SWMMO_TileList1_i() : TileList
        {
            var _loc_1:* = new TileList();
            this.EDITORSTATE_ID_TILE_LIST_GO = _loc_1;
            _loc_1.itemRenderer = this._SWMMO_ClassFactory1_c();
            _loc_1.rowHeight = 80;
            _loc_1.columnWidth = 80;
            _loc_1.width = 265;
            _loc_1.direction = "horizontal";
            _loc_1.columnCount = 1;
            _loc_1.maxRows = 1;
            _loc_1.liveScrolling = true;
            _loc_1.useHandCursor = true;
            _loc_1.alpha = 1;
            _loc_1.visible = false;
            _loc_1.variableRowHeight = true;
            _loc_1.dragEnabled = false;
            _loc_1.dragMoveEnabled = false;
            _loc_1.tabEnabled = false;
            _loc_1.setStyle("cornerRadius", 20);
            _loc_1.setStyle("borderColor", 0);
            _loc_1.setStyle("borderStyle", "solid");
            _loc_1.setStyle("borderThickness", 2);
            _loc_1.setStyle("backgroundColor", 16777215);
            _loc_1.setStyle("right", "10");
            _loc_1.setStyle("top", "16");
            _loc_1.setStyle("bottom", "163");
            _loc_1.setStyle("backgroundAlpha", 0.6);
            _loc_1.addEventListener("itemClick", this.__EDITORSTATE_ID_TILE_LIST_GO_itemClick);
            _loc_1.id = "EDITORSTATE_ID_TILE_LIST_GO";
            BindingManager.executeBindings(this, "EDITORSTATE_ID_TILE_LIST_GO", this.EDITORSTATE_ID_TILE_LIST_GO);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set GAMESTATE_ID_FRIENDS_LIST_MENU(param1:FriendsListMenu) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1059232882GAMESTATE_ID_FRIENDS_LIST_MENU;
            if (_loc_2 !== param1)
            {
                this._1059232882GAMESTATE_ID_FRIENDS_LIST_MENU = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_FRIENDS_LIST_MENU", _loc_2, param1));
            }
            return;
        }// end function

        public function __FILTER_BUILDING_None_click(event:MouseEvent) : void
        {
            this.FILTER_BUILDING_clickHandler(event);
            return;
        }// end function

        private function StartEditorClicked(event:Event) : void
        {
            currentState = "Editor";
            return;
        }// end function

        public function set btnStartGame(param1:Button) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1504873592btnStartGame;
            if (_loc_2 !== param1)
            {
                this._1504873592btnStartGame = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnStartGame", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_AddChild5_i() : AddChild
        {
            var _loc_1:* = new AddChild();
            this._SWMMO_AddChild5 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_TileList2_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild5", this._SWMMO_AddChild5);
            return _loc_1;
        }// end function

        private function menuHandler(event:MenuEvent) : void
        {
            globalFlash.gui.MenuBar.Handler(event);
            return;
        }// end function

        private function _SWMMO_TitleWindow7_i() : TitleWindow
        {
            var _loc_1:TitleWindow = null;
            _loc_1 = new TitleWindow();
            this.ResourceProductionWindow = _loc_1;
            _loc_1.x = 138;
            _loc_1.y = 84;
            _loc_1.width = 972;
            _loc_1.height = 315;
            _loc_1.layout = "absolute";
            _loc_1.visible = false;
            _loc_1.title = "Production";
            _loc_1.id = "ResourceProductionWindow";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SWMMO_DataGrid5_i());
            _loc_1.addChild(this._SWMMO_CheckBox11_i());
            return _loc_1;
        }// end function

        public function get SPECIALIST_COOLDOWN_PANEL() : SpecialistCooldownPanel
        {
            return this._639313698SPECIALIST_COOLDOWN_PANEL;
        }// end function

        public function get ID_DebugInfoPanelShowDetailErrorLog() : CheckBox
        {
            return this._1391140623ID_DebugInfoPanelShowDetailErrorLog;
        }// end function

        public function get FilterGoListID() : Canvas
        {
            return this._77743879FilterGoListID;
        }// end function

        public function get GAMESTATE_ID_CAMERA_CONTROL_PANEL() : CameraControlPanel
        {
            return this._223965420GAMESTATE_ID_CAMERA_CONTROL_PANEL;
        }// end function

        private function _SWMMO_AddChild16_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild16 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_Button22_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild16", this._SWMMO_AddChild16);
            return _loc_1;
        }// end function

        public function set GAMESTATE_ID_AVATAR(param1:Avatar) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._345705597GAMESTATE_ID_AVATAR;
            if (_loc_2 !== param1)
            {
                this._345705597GAMESTATE_ID_AVATAR = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_AVATAR", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_RadioButton11_i() : RadioButton
        {
            var _loc_1:* = new RadioButton();
            this.radiogroupOwnerShipfree = _loc_1;
            _loc_1.label = "free";
            _loc_1.groupName = "radiogroupOwnerShip";
            _loc_1.x = 10;
            _loc_1.y = 96;
            _loc_1.addEventListener("click", this.__radiogroupOwnerShipfree_click);
            _loc_1.id = "radiogroupOwnerShipfree";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __SetLandingZoneID_click(event:MouseEvent) : void
        {
            this.SetLandingZoneID_clickHandler(event);
            return;
        }// end function

        public function set ID_DebugInfoPanelShowErrorLog(param1:CheckBox) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1506992000ID_DebugInfoPanelShowErrorLog;
            if (_loc_2 !== param1)
            {
                this._1506992000ID_DebugInfoPanelShowErrorLog = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "ID_DebugInfoPanelShowErrorLog", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_CheckBox6_i() : CheckBox
        {
            var _loc_1:* = new CheckBox();
            this.FILTER_BUILDING_Minimal = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 57;
            _loc_1.label = "Minimal";
            _loc_1.setStyle("color", 0);
            _loc_1.setStyle("fontSize", 12);
            _loc_1.addEventListener("click", this.__FILTER_BUILDING_Minimal_click);
            _loc_1.id = "FILTER_BUILDING_Minimal";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_QuestNewQuestSystemList1_i() : QuestNewQuestSystemList
        {
            var _loc_1:QuestNewQuestSystemList = null;
            _loc_1 = new QuestNewQuestSystemList();
            this.GAMESTATE_ID_QUEST_NEW_QUEST_SYSTEM_LIST_PANEL = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("top", "250");
            _loc_1.id = "GAMESTATE_ID_QUEST_NEW_QUEST_SYSTEM_LIST_PANEL";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        protected function radiobuttonPlayer_clickHandler(event:MouseEvent) : void
        {
            return;
        }// end function

        private function _SWMMO_DataGridColumn19_c() : DataGridColumn
        {
            var _loc_1:DataGridColumn = null;
            _loc_1 = new DataGridColumn();
            _loc_1.headerText = "Building";
            _loc_1.dataField = "building";
            return _loc_1;
        }// end function

        private function DepositGroupAssignedDepositClicked(event:Event) : void
        {
            return;
        }// end function

        public function set GAMESTATE_ID_HINT_POINTER(param1:HintPointer) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._283820919GAMESTATE_ID_HINT_POINTER;
            if (_loc_2 !== param1)
            {
                this._283820919GAMESTATE_ID_HINT_POINTER = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_HINT_POINTER", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_Label7_c() : Label
        {
            var _loc_1:* = new Label();
            _loc_1.x = 10;
            _loc_1.y = 10;
            _loc_1.text = "old Sector ID";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set FILTER_BUILDING_SortNames(param1:CheckBox) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1311028358FILTER_BUILDING_SortNames;
            if (_loc_2 !== param1)
            {
                this._1311028358FILTER_BUILDING_SortNames = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "FILTER_BUILDING_SortNames", _loc_2, param1));
            }
            return;
        }// end function

        public function __UnitListDataID_itemClick(event:ListEvent) : void
        {
            this.UnitListDataID_itemClickHandler(event);
            return;
        }// end function

        public function set GAMESTATE_ID_ENEMY_BUILDING_INFO_PANEL(param1:EnemyBuildingInfoPanel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1404469379GAMESTATE_ID_ENEMY_BUILDING_INFO_PANEL;
            if (_loc_2 !== param1)
            {
                this._1404469379GAMESTATE_ID_ENEMY_BUILDING_INFO_PANEL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_ENEMY_BUILDING_INFO_PANEL", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_CheckBox10_i() : CheckBox
        {
            var _loc_1:* = new CheckBox();
            this.FILTER_BUILDING_SortNames = _loc_1;
            _loc_1.x = 127;
            _loc_1.y = 95;
            _loc_1.label = "Sort Names";
            _loc_1.setStyle("color", 0);
            _loc_1.setStyle("fontSize", 12);
            _loc_1.addEventListener("click", this.__FILTER_BUILDING_SortNames_click);
            _loc_1.id = "FILTER_BUILDING_SortNames";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get EDITORSTATE_ID_TILE_LIST_GO() : TileList
        {
            return this._338894559EDITORSTATE_ID_TILE_LIST_GO;
        }// end function

        public function get ID_DebugInfoPanelAdditionalDebugInfo() : CheckBox
        {
            return this._177000173ID_DebugInfoPanelAdditionalDebugInfo;
        }// end function

        private function _SWMMO_AddChild27_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild27 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_ActionBar1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild27", this._SWMMO_AddChild27);
            return _loc_1;
        }// end function

        public function set radiogroupOwnerShip(param1:RadioButtonGroup) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._533088117radiogroupOwnerShip;
            if (_loc_2 !== param1)
            {
                this._533088117radiogroupOwnerShip = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "radiogroupOwnerShip", _loc_2, param1));
            }
            return;
        }// end function

        public function __DeletegroupID_click(event:MouseEvent) : void
        {
            this.DepositGroupDeleteGroupClicked(event);
            return;
        }// end function

        public function get SectorIDInput() : TextInput
        {
            return this._1121668823SectorIDInput;
        }// end function

        public function get SelectBuildingWindowID() : TitleWindow
        {
            return this._211822309SelectBuildingWindowID;
        }// end function

        private function _SWMMO_Button13_i() : Button
        {
            var _loc_1:* = new Button();
            this.AssignGroupID = _loc_1;
            _loc_1.label = "Assign Deposit Name";
            _loc_1.x = 316;
            _loc_1.visible = true;
            _loc_1.enabled = true;
            _loc_1.setStyle("bottom", "15");
            _loc_1.addEventListener("click", this.__AssignGroupID_click);
            _loc_1.id = "AssignGroupID";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set GroupDepositID(param1:Canvas) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1681376410GroupDepositID;
            if (_loc_2 !== param1)
            {
                this._1681376410GroupDepositID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GroupDepositID", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_WarehouseInfoPanel1_i() : WarehouseInfoPanel
        {
            var _loc_1:WarehouseInfoPanel = null;
            _loc_1 = new WarehouseInfoPanel();
            this.GAMESTATE_ID_WAREHOUSE_INFO_PANEL = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("right", "100");
            _loc_1.setStyle("bottom", "180");
            _loc_1.id = "GAMESTATE_ID_WAREHOUSE_INFO_PANEL";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get GAMESTATE_ID_ADVENTURE_PANEL() : AdventurePanel
        {
            return this._1066993359GAMESTATE_ID_ADVENTURE_PANEL;
        }// end function

        public function set GAMESTATE_ID_CONSTRUCTION_INFO_PANEL(param1:ConstructionInfoPanel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._761777309GAMESTATE_ID_CONSTRUCTION_INFO_PANEL;
            if (_loc_2 !== param1)
            {
                this._761777309GAMESTATE_ID_CONSTRUCTION_INFO_PANEL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_CONSTRUCTION_INFO_PANEL", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_AddChild38_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild38 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_MinimalInfoPanel1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild38", this._SWMMO_AddChild38);
            return _loc_1;
        }// end function

        public function get GAMESTATE_ID_OPTIONS_PANEL() : OptionsPanel
        {
            return this._1838855873GAMESTATE_ID_OPTIONS_PANEL;
        }// end function

        private function _SWMMO_BlueFireComponent1_i() : BlueFireComponent
        {
            var _loc_1:BlueFireComponent = null;
            _loc_1 = new BlueFireComponent();
            this.blueFireComponent = _loc_1;
            _loc_1.width = 350;
            _loc_1.height = 250;
            _loc_1.panelClass = ChatPanel;
            _loc_1.chatPanelMediatorClass = TSOChatMediator;
            _loc_1.visible = false;
            _loc_1.setStyle("left", "0");
            _loc_1.id = "blueFireComponent";
            BindingManager.executeBindings(this, "blueFireComponent", this.blueFireComponent);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_ShopWindow1_i() : ShopWindow
        {
            var _loc_1:ShopWindow = null;
            _loc_1 = new ShopWindow();
            this.GAMESTATE_ID_SHOP_WINDOW = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "-50");
            _loc_1.id = "GAMESTATE_ID_SHOP_WINDOW";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get UnitListDataID() : DataGrid
        {
            return this._1939975865UnitListDataID;
        }// end function

        private function _SWMMO_SetProperty11_c() : SetProperty
        {
            var _loc_1:SetProperty = null;
            _loc_1 = new SetProperty();
            _loc_1.name = "minHeight";
            _loc_1.value = 800;
            return _loc_1;
        }// end function

        private function _SWMMO_Panel2_i() : Panel
        {
            var _loc_1:* = new Panel();
            this.brushSizeRadioID = _loc_1;
            _loc_1.width = 106;
            _loc_1.layout = "absolute";
            _loc_1.visible = false;
            _loc_1.height = 239;
            _loc_1.setStyle("left", "10");
            _loc_1.setStyle("top", "30");
            _loc_1.id = "brushSizeRadioID";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SWMMO_VBox1_i());
            _loc_1.addChild(this._SWMMO_Label1_c());
            _loc_1.addChild(this._SWMMO_TextInput2_i());
            return _loc_1;
        }// end function

        protected function ReAssignSectorIDButton_clickHandler(event:MouseEvent) : void
        {
            var _loc_2:* = gMisc.ParseInt(Application.application.oldSectorIDTextInput.text);
            var _loc_3:* = gMisc.ParseInt(Application.application.newSectorIDTextInput.text);
            this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.ReAssignSectorID(_loc_2, _loc_3);
            return;
        }// end function

        private function _SWMMO_Button24_i() : Button
        {
            var _loc_1:Button = null;
            _loc_1 = new Button();
            this.btnRunTests = _loc_1;
            _loc_1.y = 373;
            _loc_1.label = "Run Tests";
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.addEventListener("click", this.__btnRunTests_click);
            _loc_1.id = "btnRunTests";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __FILTER_BUILDING_undefined_click(event:MouseEvent) : void
        {
            this.FILTER_BUILDING_clickHandler(event);
            return;
        }// end function

        public function ___SWMMO_Application1_mouseMove(event:MouseEvent) : void
        {
            this.mouseMove(event);
            return;
        }// end function

        public function get GAMESTATE_ID_FRIENDS_LIST() : FriendsList
        {
            return this._1301551436GAMESTATE_ID_FRIENDS_LIST;
        }// end function

        private function _SWMMO_RadioButton2_i() : RadioButton
        {
            var _loc_1:* = new RadioButton();
            this.SetLandingZoneID = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 182;
            _loc_1.label = "SetLandingZone";
            _loc_1.groupName = "SectorLandingZoneRadioButtonGroup";
            _loc_1.addEventListener("click", this.__SetLandingZoneID_click);
            _loc_1.id = "SetLandingZoneID";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set radiogroupSetBlocking(param1:RadioButtonGroup) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._386188467radiogroupSetBlocking;
            if (_loc_2 !== param1)
            {
                this._386188467radiogroupSetBlocking = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "radiogroupSetBlocking", _loc_2, param1));
            }
            return;
        }// end function

        public function __SectorIdButton3_click(event:MouseEvent) : void
        {
            this.SectorIDNumberClicked(event);
            return;
        }// end function

        private function _SWMMO_TitleWindow5_i() : TitleWindow
        {
            var _loc_1:* = new TitleWindow();
            this.ReAssignSectorID = _loc_1;
            _loc_1.width = 218;
            _loc_1.height = 144;
            _loc_1.layout = "absolute";
            _loc_1.title = "Re Assign Sector IDs";
            _loc_1.visible = false;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "-8");
            _loc_1.id = "ReAssignSectorID";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SWMMO_TextInput5_i());
            _loc_1.addChild(this._SWMMO_TextInput6_i());
            _loc_1.addChild(this._SWMMO_Label7_c());
            _loc_1.addChild(this._SWMMO_Label8_c());
            _loc_1.addChild(this._SWMMO_Button17_i());
            _loc_1.addChild(this._SWMMO_Button18_i());
            return _loc_1;
        }// end function

        private function _SWMMO_AddChild49_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild49 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_FoundGuildPanel1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild49", this._SWMMO_AddChild49);
            return _loc_1;
        }// end function

        private function _SWMMO_AddChild3_i() : AddChild
        {
            var _loc_1:* = new AddChild();
            this._SWMMO_AddChild3 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_MenuBar1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild3", this._SWMMO_AddChild3);
            return _loc_1;
        }// end function

        protected function questOkbutton_clickHandler(event:MouseEvent) : void
        {
            this.mGeneralInterface.mQuestClientCallbacks.QuestOkButtonPressedFromGui(null);
            return;
        }// end function

        private function enterFrame(event:Event) : void
        {
            var _loc_2:Number = NaN;
            _loc_2 = gMisc.GetTimeSinceStartup() - this.lastEnterFrame;
            if (_loc_2 < 1000 / 30)
            {
                return;
            }
            this.lastEnterFrame = gMisc.GetTimeSinceStartup();
            if (gMisc.PROFILE_ACTIVE)
            {
                if (gMisc.PROFILE_ACTIVE)
                {
                    gMisc.ProfilerEnd("Other");
                }
            }
            if (cUnitTest.UNIT_TESTS_ENABLED && cUnitTest.isInitialized())
            {
                cUnitTest.runTests();
            }
            else if (this.mGeneralInterface != null)
            {
                this.mGeneralInterface.Compute();
                this.mGeneralInterface.Render();
            }
            if (gMisc.PROFILE_ACTIVE)
            {
                if (gMisc.PROFILE_ACTIVE)
                {
                    gMisc.ProfilerStart("Other");
                }
            }
            return;
        }// end function

        public function get radiogroupOwnerShipfree() : RadioButton
        {
            return this._1148490103radiogroupOwnerShipfree;
        }// end function

        public function set EDITORSTATE_ApplicationActivated(param1:Panel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._587777860EDITORSTATE_ApplicationActivated;
            if (_loc_2 !== param1)
            {
                this._587777860EDITORSTATE_ApplicationActivated = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "EDITORSTATE_ApplicationActivated", _loc_2, param1));
            }
            return;
        }// end function

        public function set SectorIdButton0(param1:Button) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1665083203SectorIdButton0;
            if (_loc_2 !== param1)
            {
                this._1665083203SectorIdButton0 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SectorIdButton0", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_AddChild14_i() : AddChild
        {
            var _loc_1:* = new AddChild();
            this._SWMMO_AddChild14 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_TitleWindow6_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild14", this._SWMMO_AddChild14);
            return _loc_1;
        }// end function

        public function get FILTER_BUILDING_None() : CheckBox
        {
            return this._643659396FILTER_BUILDING_None;
        }// end function

        public function set btnStartGameDebug(param1:Button) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1665653573btnStartGameDebug;
            if (_loc_2 !== param1)
            {
                this._1665653573btnStartGameDebug = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnStartGameDebug", _loc_2, param1));
            }
            return;
        }// end function

        public function set SectorIdButton2(param1:Button) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1665083201SectorIdButton2;
            if (_loc_2 !== param1)
            {
                this._1665083201SectorIdButton2 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SectorIdButton2", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_DataGridColumn17_c() : DataGridColumn
        {
            var _loc_1:DataGridColumn = null;
            _loc_1 = new DataGridColumn();
            _loc_1.headerText = "Amount";
            _loc_1.dataField = "amount";
            return _loc_1;
        }// end function

        private function set mSectorListData(param1:ArrayCollection) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1320391867mSectorListData;
            if (_loc_2 !== param1)
            {
                this._1320391867mSectorListData = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mSectorListData", _loc_2, param1));
            }
            return;
        }// end function

        public function set SectorIdButton6(param1:Button) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1665083197SectorIdButton6;
            if (_loc_2 !== param1)
            {
                this._1665083197SectorIdButton6 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SectorIdButton6", _loc_2, param1));
            }
            return;
        }// end function

        public function get ResourceProductionWindowDataGrid() : DataGrid
        {
            return this._526777977ResourceProductionWindowDataGrid;
        }// end function

        private function _SWMMO_CheckBox4_i() : CheckBox
        {
            var _loc_1:* = new CheckBox();
            this.FILTER_BUILDING_Watchtower = _loc_1;
            _loc_1.x = 84;
            _loc_1.y = 57;
            _loc_1.label = "Watchtower";
            _loc_1.setStyle("color", 0);
            _loc_1.setStyle("fontSize", 12);
            _loc_1.addEventListener("click", this.__FILTER_BUILDING_Watchtower_click);
            _loc_1.id = "FILTER_BUILDING_Watchtower";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get GAMESTATE_ID_TRADING_PANEL() : TradingPanel
        {
            return this._2088117886GAMESTATE_ID_TRADING_PANEL;
        }// end function

        public function get GAMESTATE_ID_QUEST_BOOK() : QuestBook
        {
            return this._994711914GAMESTATE_ID_QUEST_BOOK;
        }// end function

        public function __EDITORSTATE_MenuBar_itemClick(event:MenuEvent) : void
        {
            this.menuHandler(event);
            return;
        }// end function

        public function get SingleDepositAmountTextBoxID() : TextInput
        {
            return this._962977397SingleDepositAmountTextBoxID;
        }// end function

        private function StartTestClicked(event:Event) : void
        {
            cUnitTest.UNIT_TESTS_ENABLED = true;
            currentState = "Game";
            return;
        }// end function

        public function set AssignUnitsWindowID(param1:TitleWindow) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._445266123AssignUnitsWindowID;
            if (_loc_2 !== param1)
            {
                this._445266123AssignUnitsWindowID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "AssignUnitsWindowID", _loc_2, param1));
            }
            return;
        }// end function

        public function set GAMESTATE_ID_SHOP_WINDOW(param1:ShopWindow) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1146070859GAMESTATE_ID_SHOP_WINDOW;
            if (_loc_2 !== param1)
            {
                this._1146070859GAMESTATE_ID_SHOP_WINDOW = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_SHOP_WINDOW", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_Label5_c() : Label
        {
            var _loc_1:* = new Label();
            _loc_1.x = 10;
            _loc_1.y = 0;
            _loc_1.text = "Unit List";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set SectorIdButton8(param1:Button) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1665083195SectorIdButton8;
            if (_loc_2 !== param1)
            {
                this._1665083195SectorIdButton8 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SectorIdButton8", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_AddChild25_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild25 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_Label14_c);
            BindingManager.executeBindings(this, "_SWMMO_AddChild25", this._SWMMO_AddChild25);
            return _loc_1;
        }// end function

        private function _SWMMO_Button9_i() : Button
        {
            var _loc_1:* = new Button();
            this.SectorIdButton8 = _loc_1;
            _loc_1.x = 62;
            _loc_1.y = 41;
            _loc_1.label = "8";
            _loc_1.width = 43;
            _loc_1.height = 20;
            _loc_1.addEventListener("click", this.__SectorIdButton8_click);
            _loc_1.id = "SectorIdButton8";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set SectorIdButton3(param1:Button) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1665083200SectorIdButton3;
            if (_loc_2 !== param1)
            {
                this._1665083200SectorIdButton3 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SectorIdButton3", _loc_2, param1));
            }
            return;
        }// end function

        public function get SetLandingZoneID() : RadioButton
        {
            return this._1776177564SetLandingZoneID;
        }// end function

        public function set SectorIdButton4(param1:Button) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1665083199SectorIdButton4;
            if (_loc_2 !== param1)
            {
                this._1665083199SectorIdButton4 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SectorIdButton4", _loc_2, param1));
            }
            return;
        }// end function

        public function set SectorIdButton5(param1:Button) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1665083198SectorIdButton5;
            if (_loc_2 !== param1)
            {
                this._1665083198SectorIdButton5 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SectorIdButton5", _loc_2, param1));
            }
            return;
        }// end function

        public function set SectorIdButton1(param1:Button) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1665083202SectorIdButton1;
            if (_loc_2 !== param1)
            {
                this._1665083202SectorIdButton1 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SectorIdButton1", _loc_2, param1));
            }
            return;
        }// end function

        public function get GAMESTATE_ID_STAR_MENU() : StarMenu
        {
            return this._2105831032GAMESTATE_ID_STAR_MENU;
        }// end function

        public function set btnRunTests(param1:Button) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1709618990btnRunTests;
            if (_loc_2 !== param1)
            {
                this._1709618990btnRunTests = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnRunTests", _loc_2, param1));
            }
            return;
        }// end function

        public function get FILTER_BUILDING_undefined() : CheckBox
        {
            return this._1702874708FILTER_BUILDING_undefined;
        }// end function

        public function __SectorIdButton8_click(event:MouseEvent) : void
        {
            this.SectorIDNumberClicked(event);
            return;
        }// end function

        private function _SWMMO_Button11_i() : Button
        {
            var _loc_1:* = new Button();
            this.AddgroupID = _loc_1;
            _loc_1.label = "Addgroup";
            _loc_1.x = 98;
            _loc_1.enabled = true;
            _loc_1.setStyle("bottom", "15");
            _loc_1.addEventListener("click", this.__AddgroupID_click);
            _loc_1.id = "AddgroupID";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set SetBlockingWindowID(param1:TitleWindow) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1370867518SetBlockingWindowID;
            if (_loc_2 !== param1)
            {
                this._1370867518SetBlockingWindowID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SetBlockingWindowID", _loc_2, param1));
            }
            return;
        }// end function

        public function get GAMESTATE_ID_BATTLE_WINDOW() : BattleWindow
        {
            return this._1970511437GAMESTATE_ID_BATTLE_WINDOW;
        }// end function

        public function set GAMESTATE_ID_BUILDING_INFO_PANEL(param1:BuildingInfoPanel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._314430682GAMESTATE_ID_BUILDING_INFO_PANEL;
            if (_loc_2 !== param1)
            {
                this._314430682GAMESTATE_ID_BUILDING_INFO_PANEL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_BUILDING_INFO_PANEL", _loc_2, param1));
            }
            return;
        }// end function

        public function get GAMESTATE_ID_MINIMAL_INFO_PANEL() : MinimalInfoPanel
        {
            return this._722613835GAMESTATE_ID_MINIMAL_INFO_PANEL;
        }// end function

        public function set SingleDepositID(param1:Canvas) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._754674511SingleDepositID;
            if (_loc_2 !== param1)
            {
                this._754674511SingleDepositID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SingleDepositID", _loc_2, param1));
            }
            return;
        }// end function

        public function set SectorIdButton9(param1:Button) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1665083194SectorIdButton9;
            if (_loc_2 !== param1)
            {
                this._1665083194SectorIdButton9 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SectorIdButton9", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_AddChild36_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild36 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_ConstructionInfoPanel1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild36", this._SWMMO_AddChild36);
            return _loc_1;
        }// end function

        public function set SPECIALIST_COOLDOWN_PANEL(param1:SpecialistCooldownPanel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._639313698SPECIALIST_COOLDOWN_PANEL;
            if (_loc_2 !== param1)
            {
                this._639313698SPECIALIST_COOLDOWN_PANEL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SPECIALIST_COOLDOWN_PANEL", _loc_2, param1));
            }
            return;
        }// end function

        public function get GAMESTATE_ID_ADD_FRIENDS_PANEL() : AddFriendsPanel
        {
            return this._257851832GAMESTATE_ID_ADD_FRIENDS_PANEL;
        }// end function

        public function set FILTER_BUILDING_Minimal(param1:CheckBox) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._712858845FILTER_BUILDING_Minimal;
            if (_loc_2 !== param1)
            {
                this._712858845FILTER_BUILDING_Minimal = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "FILTER_BUILDING_Minimal", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_QuestBook1_i() : QuestBook
        {
            var _loc_1:QuestBook = null;
            _loc_1 = new QuestBook();
            this.GAMESTATE_ID_QUEST_BOOK = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "GAMESTATE_ID_QUEST_BOOK";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get FILTER_BUILDING_ALL_ID() : Button
        {
            return this._486907459FILTER_BUILDING_ALL_ID;
        }// end function

        public function set ID_DebugInfoPanelShowQuestInfo(param1:CheckBox) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1584604980ID_DebugInfoPanelShowQuestInfo;
            if (_loc_2 !== param1)
            {
                this._1584604980ID_DebugInfoPanelShowQuestInfo = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "ID_DebugInfoPanelShowQuestInfo", _loc_2, param1));
            }
            return;
        }// end function

        protected function rewardCloseButton_clickHandler(event:MouseEvent) : void
        {
            this.mGeneralInterface.mQuestClientCallbacks.RewardCloseButtonPressedFromGui();
            return;
        }// end function

        public function set SectorIdButton7(param1:Button) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1665083196SectorIdButton7;
            if (_loc_2 !== param1)
            {
                this._1665083196SectorIdButton7 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SectorIdButton7", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_TavernInfoPanel1_i() : TavernInfoPanel
        {
            var _loc_1:TavernInfoPanel = null;
            _loc_1 = new TavernInfoPanel();
            this.GAMESTATE_ID_TAVERN_INFO_PANEL = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("right", "100");
            _loc_1.setStyle("bottom", "180");
            _loc_1.id = "GAMESTATE_ID_TAVERN_INFO_PANEL";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_TrackedMissionList1_i() : TrackedMissionList
        {
            var _loc_1:TrackedMissionList = null;
            _loc_1 = new TrackedMissionList();
            this.GAMESTATE_ID_TRACKED_MISSION_LIST = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("right", "0");
            _loc_1.id = "GAMESTATE_ID_TRACKED_MISSION_LIST";
            BindingManager.executeBindings(this, "GAMESTATE_ID_TRACKED_MISSION_LIST", this.GAMESTATE_ID_TRACKED_MISSION_LIST);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_AddChild47_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild47 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_TavernInfoPanel1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild47", this._SWMMO_AddChild47);
            return _loc_1;
        }// end function

        private function _SWMMO_Button22_i() : Button
        {
            var _loc_1:Button = null;
            _loc_1 = new Button();
            this.EDITORSTATE_btnEditor = _loc_1;
            _loc_1.y = 246;
            _loc_1.label = "Start Editor";
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.addEventListener("click", this.__EDITORSTATE_btnEditor_click);
            _loc_1.id = "EDITORSTATE_btnEditor";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get EraseLandingZoneID() : RadioButton
        {
            return this._1422934488EraseLandingZoneID;
        }// end function

        public function set ID_DebugInfoPanelShowDetailErrorLog(param1:CheckBox) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1391140623ID_DebugInfoPanelShowDetailErrorLog;
            if (_loc_2 !== param1)
            {
                this._1391140623ID_DebugInfoPanelShowDetailErrorLog = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "ID_DebugInfoPanelShowDetailErrorLog", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_List1_i() : List
        {
            var _loc_1:* = new List();
            this.EDITORSTATE_focusID = _loc_1;
            _loc_1.width = 39;
            _loc_1.height = 19;
            _loc_1.visible = false;
            _loc_1.setStyle("right", "0");
            _loc_1.setStyle("bottom", "0");
            _loc_1.setStyle("cornerRadius", 20);
            _loc_1.setStyle("borderThickness", 2);
            _loc_1.id = "EDITORSTATE_focusID";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_AddChild1_i() : AddChild
        {
            var _loc_1:* = new AddChild();
            this._SWMMO_AddChild1 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_TileList1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild1", this._SWMMO_AddChild1);
            return _loc_1;
        }// end function

        private function _SWMMO_TitleWindow3_i() : TitleWindow
        {
            var _loc_1:* = new TitleWindow();
            this.AssignUnitsWindowID = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 75;
            _loc_1.width = 597;
            _loc_1.height = 304;
            _loc_1.layout = "absolute";
            _loc_1.title = "Assign Units Window";
            _loc_1.visible = false;
            _loc_1.id = "AssignUnitsWindowID";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SWMMO_DataGrid2_i());
            _loc_1.addChild(this._SWMMO_DataGrid3_i());
            _loc_1.addChild(this._SWMMO_Button14_i());
            _loc_1.addChild(this._SWMMO_Button15_i());
            _loc_1.addChild(this._SWMMO_Label5_c());
            _loc_1.addChild(this._SWMMO_Label6_c());
            return _loc_1;
        }// end function

        public function set GAMESTATE_ID_CAMERA_CONTROL_PANEL(param1:CameraControlPanel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._223965420GAMESTATE_ID_CAMERA_CONTROL_PANEL;
            if (_loc_2 !== param1)
            {
                this._223965420GAMESTATE_ID_CAMERA_CONTROL_PANEL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_CAMERA_CONTROL_PANEL", _loc_2, param1));
            }
            return;
        }// end function

        public function set EDITORSTATE_ID_TILE_LIST_SET_MODE(param1:TileList) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1892912377EDITORSTATE_ID_TILE_LIST_SET_MODE;
            if (_loc_2 !== param1)
            {
                this._1892912377EDITORSTATE_ID_TILE_LIST_SET_MODE = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "EDITORSTATE_ID_TILE_LIST_SET_MODE", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_MysteryBoxPanel1_i() : MysteryBoxPanel
        {
            var _loc_1:MysteryBoxPanel = null;
            _loc_1 = new MysteryBoxPanel();
            this.GAMESTATE_ID_MYSTERYBOX_PANEL = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "GAMESTATE_ID_MYSTERYBOX_PANEL";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_AddChild12_i() : AddChild
        {
            var _loc_1:* = new AddChild();
            this._SWMMO_AddChild12 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_TitleWindow4_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild12", this._SWMMO_AddChild12);
            return _loc_1;
        }// end function

        private function _SWMMO_AddChild58_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild58 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_StarMenu1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild58", this._SWMMO_AddChild58);
            return _loc_1;
        }// end function

        private function _SWMMO_DataGridColumn15_c() : DataGridColumn
        {
            var _loc_1:DataGridColumn = null;
            _loc_1 = new DataGridColumn();
            _loc_1.headerText = "Group";
            _loc_1.dataField = "group";
            return _loc_1;
        }// end function

        private function _SWMMO_DataGridColumn8_c() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            _loc_1.headerText = "HP";
            _loc_1.dataField = "UnitHP";
            return _loc_1;
        }// end function

        private function _SWMMO_TradingPanel1_i() : TradingPanel
        {
            var _loc_1:TradingPanel = null;
            _loc_1 = new TradingPanel();
            this.GAMESTATE_ID_TRADING_PANEL = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.id = "GAMESTATE_ID_TRADING_PANEL";
            BindingManager.executeBindings(this, "GAMESTATE_ID_TRADING_PANEL", this.GAMESTATE_ID_TRADING_PANEL);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_CheckBox2_i() : CheckBox
        {
            var _loc_1:* = new CheckBox();
            this.FILTER_BUILDING_Enemy = _loc_1;
            _loc_1.x = 176;
            _loc_1.y = 37;
            _loc_1.label = "Enemy";
            _loc_1.setStyle("color", 0);
            _loc_1.setStyle("fontSize", 12);
            _loc_1.addEventListener("click", this.__FILTER_BUILDING_Enemy_click);
            _loc_1.id = "FILTER_BUILDING_Enemy";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get GAMESTATE_ID_GUILD_WINDOW() : GuildWindow
        {
            return this._1393716736GAMESTATE_ID_GUILD_WINDOW;
        }// end function

        public function set FilterGoListID(param1:Canvas) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._77743879FilterGoListID;
            if (_loc_2 !== param1)
            {
                this._77743879FilterGoListID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "FilterGoListID", _loc_2, param1));
            }
            return;
        }// end function

        public function get ID_DebugInfoPanelShowOnScreenGameTickCommands() : CheckBox
        {
            return this._1897880070ID_DebugInfoPanelShowOnScreenGameTickCommands;
        }// end function

        private function _SWMMO_NewsWindow1_i() : NewsWindow
        {
            var _loc_1:NewsWindow = null;
            _loc_1 = new NewsWindow();
            this.GAMESTATE_ID_NEWS_WINDOW = _loc_1;
            _loc_1.visible = true;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "GAMESTATE_ID_NEWS_WINDOW";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function mouseMove(event:MouseEvent) : void
        {
            if (this.mGeneralInterface == null)
            {
                return;
            }
            var _loc_2:String = this;
            var _loc_3:* = this.mMouseMove + 1;
            _loc_2.mMouseMove = _loc_3;
            if (this.IsMouseOverCanvas(event))
            {
                this.mMouseOverCanvas = true;
                if (this.mGeneralInterface.mCurrentCursor)
                {
                    this.mGeneralInterface.mCurrentCursor.SetCursorVisible(true);
                }
                this.mGeneralInterface.MouseMove(event);
            }
            else
            {
                this.mMouseOverCanvas = false;
                if (this.mGeneralInterface.mCurrentCursor)
                {
                    this.mGeneralInterface.mCurrentCursor.SetCursorVisible(false);
                }
            }
            return;
        }// end function

        private function _SWMMO_AddChild69_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild69 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_FriendsListMenu1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild69", this._SWMMO_AddChild69);
            return _loc_1;
        }// end function

        private function _SWMMO_Label3_c() : Label
        {
            var _loc_1:* = new Label();
            _loc_1.text = "Ownership";
            _loc_1.x = 10;
            _loc_1.y = 10;
            _loc_1.setStyle("fontWeight", "bold");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_SetProperty9_i() : SetProperty
        {
            var _loc_1:SetProperty = null;
            _loc_1 = new SetProperty();
            this._SWMMO_SetProperty9 = _loc_1;
            _loc_1.name = "minWidth";
            _loc_1.value = 600;
            BindingManager.executeBindings(this, "_SWMMO_SetProperty9", this._SWMMO_SetProperty9);
            return _loc_1;
        }// end function

        private function mouseUp(event:MouseEvent) : void
        {
            if (this.mGeneralInterface == null)
            {
                return;
            }
            this.mGeneralInterface.MouseUp(event);
            return;
        }// end function

        private function _SWMMO_Button7_i() : Button
        {
            var _loc_1:* = new Button();
            this.SectorIdButton6 = _loc_1;
            _loc_1.x = 113;
            _loc_1.y = 69;
            _loc_1.label = "6";
            _loc_1.width = 43;
            _loc_1.height = 20;
            _loc_1.addEventListener("click", this.__SectorIdButton6_click);
            _loc_1.id = "SectorIdButton6";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __FILTER_BUILDING_Timedproduction_click(event:MouseEvent) : void
        {
            this.FILTER_BUILDING_clickHandler(event);
            return;
        }// end function

        private function SetApplicationWidthandHeight() : void
        {
            global.screenWidth = Application.application.width;
            global.screenHeight = Application.application.height;
            global.screenWidthHalf = global.screenWidth / 2;
            global.screenHeightHalf = global.screenHeight / 2;
            return;
        }// end function

        private function _SWMMO_AddChild23_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild23 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_Label12_c);
            BindingManager.executeBindings(this, "_SWMMO_AddChild23", this._SWMMO_AddChild23);
            return _loc_1;
        }// end function

        public function ___SWMMO_Application1_mouseDown(event:MouseEvent) : void
        {
            this.mouseDown(event);
            return;
        }// end function

        public function set ID_DebugInfoPanelAdditionalDebugInfo(param1:CheckBox) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._177000173ID_DebugInfoPanelAdditionalDebugInfo;
            if (_loc_2 !== param1)
            {
                this._177000173ID_DebugInfoPanelAdditionalDebugInfo = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "ID_DebugInfoPanelAdditionalDebugInfo", _loc_2, param1));
            }
            return;
        }// end function

        public function get SingleDepositAmountLabelID() : Label
        {
            return this._182712865SingleDepositAmountLabelID;
        }// end function

        public function get GAMESTATE_ID_MYSTERYBOX_PANEL() : MysteryBoxPanel
        {
            return this._1730107957GAMESTATE_ID_MYSTERYBOX_PANEL;
        }// end function

        public function set SelectBuildingWindowID(param1:TitleWindow) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._211822309SelectBuildingWindowID;
            if (_loc_2 !== param1)
            {
                this._211822309SelectBuildingWindowID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SelectBuildingWindowID", _loc_2, param1));
            }
            return;
        }// end function

        public function get mTileListDataProviderGO() : ArrayCollection
        {
            return this._132846140mTileListDataProviderGO;
        }// end function

        private function _SWMMO_AddChild34_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild34 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_FriendsList1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild34", this._SWMMO_AddChild34);
            return _loc_1;
        }// end function

        public function set EDITORSTATE_ID_TILE_LIST_GO(param1:TileList) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._338894559EDITORSTATE_ID_TILE_LIST_GO;
            if (_loc_2 !== param1)
            {
                this._338894559EDITORSTATE_ID_TILE_LIST_GO = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "EDITORSTATE_ID_TILE_LIST_GO", _loc_2, param1));
            }
            return;
        }// end function

        public function RefreshSectorListWindowIfVisible() : void
        {
            return;
        }// end function

        public function set GAMESTATE_ID_CHEAT_WINDOW(param1:CheatWindow) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1283861792GAMESTATE_ID_CHEAT_WINDOW;
            if (_loc_2 !== param1)
            {
                this._1283861792GAMESTATE_ID_CHEAT_WINDOW = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_CHEAT_WINDOW", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_CheatWindow1_i() : CheatWindow
        {
            var _loc_1:* = new CheatWindow();
            this.EDITORSTATE__ID_CHEAT_WINDOW = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("right", "4");
            _loc_1.setStyle("top", "40");
            _loc_1.id = "EDITORSTATE__ID_CHEAT_WINDOW";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        protected function EnterEditor(event:Event) : void
        {
            return;
        }// end function

        private function _SWMMO_Button20_i() : Button
        {
            var _loc_1:* = new Button();
            this.FILTER_BUILDING_NONE_ID = _loc_1;
            _loc_1.x = 73;
            _loc_1.y = 10;
            _loc_1.label = "None";
            _loc_1.width = 71;
            _loc_1.height = 19;
            _loc_1.setStyle("fontSize", 12);
            _loc_1.setStyle("color", 0);
            _loc_1.addEventListener("click", this.__FILTER_BUILDING_NONE_ID_click);
            _loc_1.id = "FILTER_BUILDING_NONE_ID";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set SectorIDInput(param1:TextInput) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1121668823SectorIDInput;
            if (_loc_2 !== param1)
            {
                this._1121668823SectorIDInput = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SectorIDInput", _loc_2, param1));
            }
            return;
        }// end function

        protected function FILTERLIST_INVERT_ID0_clickHandler(event:MouseEvent) : void
        {
            return;
        }// end function

        public function get ResourceProductionWindow() : TitleWindow
        {
            return this._1034233257ResourceProductionWindow;
        }// end function

        private function _SWMMO_AddChild45_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild45 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_WatchTowerInfoPanel1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild45", this._SWMMO_AddChild45);
            return _loc_1;
        }// end function

        public function set AssignedUnitID(param1:DataGrid) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1087128877AssignedUnitID;
            if (_loc_2 !== param1)
            {
                this._1087128877AssignedUnitID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "AssignedUnitID", _loc_2, param1));
            }
            return;
        }// end function

        public function set blueFireComponent(param1:BlueFireComponent) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1792787757blueFireComponent;
            if (_loc_2 !== param1)
            {
                this._1792787757blueFireComponent = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "blueFireComponent", _loc_2, param1));
            }
            return;
        }// end function

        public function set GAMESTATE_ID_ADVENTURE_PANEL(param1:AdventurePanel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1066993359GAMESTATE_ID_ADVENTURE_PANEL;
            if (_loc_2 !== param1)
            {
                this._1066993359GAMESTATE_ID_ADVENTURE_PANEL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_ADVENTURE_PANEL", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_TitleWindow1_i() : TitleWindow
        {
            var _loc_1:* = new TitleWindow();
            this.SectorModeWindow = _loc_1;
            _loc_1.width = 191;
            _loc_1.height = 276;
            _loc_1.layout = "absolute";
            _loc_1.showCloseButton = false;
            _loc_1.visible = false;
            _loc_1.setStyle("bottom", "110");
            _loc_1.setStyle("left", "10");
            _loc_1.id = "SectorModeWindow";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SWMMO_Text3_c());
            _loc_1.addChild(this._SWMMO_TextInput1_i());
            _loc_1.addChild(this._SWMMO_Button1_i());
            _loc_1.addChild(this._SWMMO_Button2_i());
            _loc_1.addChild(this._SWMMO_Button3_i());
            _loc_1.addChild(this._SWMMO_Button4_i());
            _loc_1.addChild(this._SWMMO_Button5_i());
            _loc_1.addChild(this._SWMMO_Button6_i());
            _loc_1.addChild(this._SWMMO_Button7_i());
            _loc_1.addChild(this._SWMMO_Button8_i());
            _loc_1.addChild(this._SWMMO_Button9_i());
            _loc_1.addChild(this._SWMMO_Button10_i());
            _loc_1.addChild(this._SWMMO_RadioButton1_i());
            _loc_1.addChild(this._SWMMO_RadioButton2_i());
            _loc_1.addChild(this._SWMMO_RadioButton3_i());
            return _loc_1;
        }// end function

        public function set oldSectorIDTextInput(param1:TextInput) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1559728843oldSectorIDTextInput;
            if (_loc_2 !== param1)
            {
                this._1559728843oldSectorIDTextInput = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "oldSectorIDTextInput", _loc_2, param1));
            }
            return;
        }// end function

        public function __FILTER_BUILDING_Residence_click(event:MouseEvent) : void
        {
            this.FILTER_BUILDING_clickHandler(event);
            return;
        }// end function

        public function ___SWMMO_RadioButton7_click(event:MouseEvent) : void
        {
            this.UpdateBrushSizeRadioButtons();
            return;
        }// end function

        public function set GAMESTATE_ID_WATCHTOWER_INFO_PANEL(param1:WatchTowerInfoPanel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1267151564GAMESTATE_ID_WATCHTOWER_INFO_PANEL;
            if (_loc_2 !== param1)
            {
                this._1267151564GAMESTATE_ID_WATCHTOWER_INFO_PANEL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_WATCHTOWER_INFO_PANEL", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_LoadingZonePanel1_i() : LoadingZonePanel
        {
            var _loc_1:LoadingZonePanel = null;
            _loc_1 = new LoadingZonePanel();
            this.GAMESTATE_ID_LOADING_ZONE_PANEL = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "GAMESTATE_ID_LOADING_ZONE_PANEL";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function DepositGroupDeleteGroupClicked(event:Event) : void
        {
            return;
        }// end function

        private function _SWMMO_AddChild10_i() : AddChild
        {
            var _loc_1:* = new AddChild();
            this._SWMMO_AddChild10 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_TitleWindow2_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild10", this._SWMMO_AddChild10);
            return _loc_1;
        }// end function

        protected function questCloseButton_clickHandler(event:MouseEvent) : void
        {
            this.mGeneralInterface.mQuestClientCallbacks.QuestCloseButtonPressedFromGui();
            return;
        }// end function

        private function _SWMMO_CancelActionPanel1_i() : CancelActionPanel
        {
            var _loc_1:CancelActionPanel = null;
            _loc_1 = new CancelActionPanel();
            this.GAMESTATE_ID_CANCEL_ACTION_PANEL = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.id = "GAMESTATE_ID_CANCEL_ACTION_PANEL";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_FoundGuildPanel1_i() : FoundGuildPanel
        {
            var _loc_1:FoundGuildPanel = null;
            _loc_1 = new FoundGuildPanel();
            this.GAMESTATE_ID_FOUND_GUILD_PANEL = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "GAMESTATE_ID_FOUND_GUILD_PANEL";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set ID_DebugInfoPanelShowSettlerDebugInfo(param1:CheckBox) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._142638398ID_DebugInfoPanelShowSettlerDebugInfo;
            if (_loc_2 !== param1)
            {
                this._142638398ID_DebugInfoPanelShowSettlerDebugInfo = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "ID_DebugInfoPanelShowSettlerDebugInfo", _loc_2, param1));
            }
            return;
        }// end function

        private function DepositGroupItemEditEnd(event:DataGridEvent) : void
        {
            return;
        }// end function

        public function set GAMESTATE_ID_OPTIONS_PANEL(param1:OptionsPanel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1838855873GAMESTATE_ID_OPTIONS_PANEL;
            if (_loc_2 !== param1)
            {
                this._1838855873GAMESTATE_ID_OPTIONS_PANEL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_OPTIONS_PANEL", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_DataGridColumn13_c() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            _loc_1.dataField = "Amount";
            _loc_1.headerText = "Amount";
            _loc_1.width = 50;
            _loc_1.sortable = false;
            return _loc_1;
        }// end function

        private function _SWMMO_DataGridColumn6_c() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            _loc_1.dataField = "Nr";
            _loc_1.headerText = "Nr";
            return _loc_1;
        }// end function

        public function get FILTER_BUILDING_Timedproduction() : CheckBox
        {
            return this._1810592364FILTER_BUILDING_Timedproduction;
        }// end function

        private function _SWMMO_AddChild56_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild56 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_MemoryMonitorPanel1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild56", this._SWMMO_AddChild56);
            return _loc_1;
        }// end function

        public function get GAMESTATE_ID_DAILY_LOGIN_PANEL() : DailyLoginPanel
        {
            return this._1395871100GAMESTATE_ID_DAILY_LOGIN_PANEL;
        }// end function

        function _SWMMO_StylesInit() : void
        {
            var style:CSSStyleDeclaration;
            var effects:Array;
            if (mx_internal::_SWMMO_StylesInit_done)
            {
                return;
            }
            mx_internal::_SWMMO_StylesInit_done = true;
            style = StyleManager.getStyleDeclaration(".questPanelFooter");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".questPanelFooter", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundSize = "100%";
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_quest_quest_bg_bottom_png_856676144;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".shopItemDetails");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".shopItemDetails", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundSize = "100%";
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_shop_buy_item_bg_details_png_1231834048;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration("CustomAlert");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration("CustomAlert", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.modalTransparency = 0.7;
                this.modalTransparencyBlur = 0;
                this.modalTransparencyColor = 0;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".optionsPanel");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".optionsPanel", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundSize = "100%";
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_options_option_bg_small_png_911592548;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".rewardPanel");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".rewardPanel", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundSize = "100%";
                this.fontWeight = "bold";
                this.color = 16777215;
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_quest_quest_bg_gold_png_435591269;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".questPanelHeader");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".questPanelHeader", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundSize = "100%";
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_quest_quest_bg_top_png_222217371;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".chatMaximizeButton");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".chatMaximizeButton", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                null.upSkin = this;
                this.downSkin = _embed_css_____data_src_gfx_embedded_chat_maximize_standard_png_1106313599;
                this.overSkin = _embed_css_____data_src_gfx_embedded_chat_maximize_highlighted_png_503401341;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".newsPanelFooter");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".newsPanelFooter", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundSize = "100%";
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_news_news_bg_bottom_png_2063566116;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".tab");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".tab", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                null.overSkin = this;
                this.downSkin = _embed_css_____data_src_gfx_embedded_chat_bg_chattab_png_1946073156;
                this.focusAlpha = 0;
                this.textRollOverColor = 16777215;
                this.selectedUpSkin = _embed_css_____data_src_gfx_embedded_chat_bg_chattab_selected_png_700177882;
                this.fontSize = 11;
                this.focusThickness = 0;
                this.paddingLeft = 0;
                this.paddingRight = 0;
                this.upSkin = _embed_css_____data_src_gfx_embedded_chat_bg_chattab_png_1946073156;
                this.fontWeight = "normal";
                this.selectedDownSkin = _embed_css_____data_src_gfx_embedded_chat_bg_chattab_selected_png_700177882;
                this.color = 16777215;
                this.textSelectedColor = 16777215;
                this.selectedOverSkin = _embed_css_____data_src_gfx_embedded_chat_bg_chattab_selected_png_700177882;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".close");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".close", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.upSkin = _embed_css_____data_src_gfx_embedded_buttons_x_standard_png_1960716715;
                this.downSkin = _embed_css_____data_src_gfx_embedded_buttons_x_highlight_png_1750437863;
                this.overSkin = _embed_css_____data_src_gfx_embedded_buttons_x_highlight_png_1750437863;
                this.disabledSkin = _embed_css_____data_src_gfx_embedded_buttons_x_inactive_png_1807742325;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".paymentAlert");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".paymentAlert", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundSize = "100%";
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_alert_alert_payment_background_png_1386292608;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".labelLeft");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".labelLeft", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.textAlign = "left";
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".friendsListControllsLeft");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".friendsListControllsLeft", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundSize = "100%";
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_friendslist_friendslist1_png_2010943604;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".standardInput");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".standardInput", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.fontWeight = "normal";
                this.borderStyle = "solid";
                this.borderColor = 3419683;
                this.backgroundColor = 5787196;
                this.color = 16777215;
                this.backgroundDisabledColor = 5459008;
                this.focusAlpha = 0;
                this.borderThickness = 1;
                this.disabledColor = 16777215;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".optionsMenu");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".optionsMenu", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                null.upSkin = this;
                this.downSkin = _embed_css_____data_src_gfx_embedded_options_textbutton_mouseover_png_1972989270;
                this.overSkin = _embed_css_____data_src_gfx_embedded_options_textbutton_mouseover_png_1972989270;
                this.color = 15123590;
                this.textRollOverColor = 15123590;
                this.disabledSkin = _embed_css_____data_src_gfx_embedded_options_textbutton_inactive_png_40222180;
                this.paddingLeft = 3;
                this.paddingBottom = 5;
                this.textSelectedColor = 15123590;
                this.paddingRight = 5;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".actionBarRight");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".actionBarRight", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundSize = "100%";
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_actionbar_actionbar4_png_198323484;
                this.horizontalGap = 2;
                this.paddingBottom = 0;
                this.paddingLeft = 5;
                this.paddingRight = 50;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".chatTabNewMessage");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".chatTabNewMessage", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                null.backgroundSize = this;
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_chat_bg_chattab_highlight_png_158597178;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".tabSelected");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".tabSelected", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                null.fontWeight = this;
                this.focusAlpha = 0;
                this.focusThickness = 0;
                this.fontSize = 11;
                this.paddingLeft = 0;
                this.paddingRight = 0;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".chatMinimizeButton");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".chatMinimizeButton", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.upSkin = _embed_css_____data_src_gfx_embedded_chat_minimize_standard_png_197453125;
                this.downSkin = _embed_css_____data_src_gfx_embedded_chat_minimize_standard_png_197453125;
                this.overSkin = _embed_css_____data_src_gfx_embedded_chat_minimize_highlighted_png_1579240229;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".infoBarRight");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".infoBarRight", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                null.backgroundSize = this;
                this.paddingTop = 8;
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_infobar_infobar_right_png_2090990534;
                this.paddingLeft = 15;
                this.paddingRight = 75;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".listBackgroundShadow");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".listBackgroundShadow", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundSize = "100%";
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_buildinginfo_tilelist_bg_png_1613316706;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".friendsListBackground");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".friendsListBackground", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundSize = "100%";
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_friendslist_friendslist4_png_1649435005;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".detailsSubContentBox");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".detailsSubContentBox", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundColor = 0;
                this.backgroundAlpha = 0.15;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".tradeDetailsBox");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".tradeDetailsBox", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundSize = "100%";
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_trade_avatar_box_png_782837924;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".actionBarLeft");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".actionBarLeft", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                null.backgroundSize = this;
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_actionbar_actionbar2_png_198840077;
                this.horizontalGap = 2;
                this.paddingBottom = 0;
                this.paddingLeft = 50;
                this.paddingRight = 5;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".buildingListToolTip");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".buildingListToolTip", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundSize = "100%";
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_buildingmenu_tooltip_background_png_166192939;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".buildingListItem");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".buildingListItem", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundSize = "100%";
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_buildingmenu_bg_item_png_1037144546;
                this.backgroundAlpha = 1;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".detailsHeader");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".detailsHeader", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundSize = "100%";
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_basicpanel_header_png_1330748332;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".chatPrivateList");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".chatPrivateList", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundSize = "100%";
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_chat_button_standard_png_1496437355;
                this.paddingLeft = 0;
                this.paddingRight = 0;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration("ResourceAlert");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration("ResourceAlert", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.modalTransparency = 0.7;
                this.modalTransparencyBlur = 0;
                this.modalTransparencyColor = 0;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".chatInput");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".chatInput", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundSize = "100%";
                this.borderStyle = "solid";
                this.paddingTop = 0;
                this.backgroundColor = "none";
                this.color = 16777215;
                this.borderThickness = 0;
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_chat_textbox_png_1978418198;
                this.focusAlpha = 0;
                this.fontSize = 12;
                this.paddingLeft = 3;
                this.paddingBottom = 0;
                this.paddingRight = 3;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".cameraControlPanel");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".cameraControlPanel", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundSize = "100%";
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_camera_camera_bg_png_902640356;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".basicPanel");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".basicPanel", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                null.backgroundSize = this;
                this.fontWeight = "bold";
                this.color = 16777215;
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_basicpanel_standard_png_1527688305;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".actionBarBackground");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".actionBarBackground", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                null.backgroundSize = this;
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_actionbar_actionbar1_png_182802203;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".specialPanel");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".specialPanel", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundSize = "100%";
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_basicpanel_special_png_1513629018;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".infoBarLeft");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".infoBarLeft", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                null.backgroundSize = this;
                this.paddingTop = 8;
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_infobar_infobar_left_png_1559235610;
                this.paddingLeft = 75;
                this.paddingRight = 15;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".customAlert");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".customAlert", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                null.backgroundSize = this;
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_alert_alert_background_png_1445621566;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".detailsContentBox");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".detailsContentBox", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                null.backgroundColor = this;
                this.backgroundAlpha = 0.75;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".chatPrivateListSelected");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".chatPrivateListSelected", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundSize = "100%";
                this.fontWeight = "bold";
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_chat_button_active_png_1795709403;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".chatTabSelected");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".chatTabSelected", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                null.backgroundSize = this;
                this.fontWeight = "bold";
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_chat_bg_chattab_selected_png_700177882;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".friendsListArrowFrame");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".friendsListArrowFrame", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_friendslist_frame_arrow_png_1710501041;
                this.horizontalAlign = "center";
                this.verticalAlign = "middle";
                this.verticalGap = 0;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".friendsListControllsRight");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".friendsListControllsRight", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundSize = "100%";
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_friendslist_friendslist3_png_1983284784;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".shopFooter");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".shopFooter", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundSize = "100%";
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_shop_buy_banner_bg_png_1642103810;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration("ScrollBar");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration("ScrollBar", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.downArrowSkin = _embed_css_____data_src_gfx_embedded_scrollbars_arrow_down_png_2004989061;
                this.trackSkin = _embed_css_____data_src_gfx_embedded_scrollbars_bar_png_2145225976;
                this.upArrowSkin = _embed_css_____data_src_gfx_embedded_scrollbars_arrow_up_png_729897109;
                this.thumbSkin = _embed_css_____data_src_gfx_embedded_scrollbars_slider_png_2042007750;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".itemBackground");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".itemBackground", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                null.backgroundSize = this;
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_trade_item_background_png_2047890676;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".hr");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".hr", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundSize = "100%";
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_trade_line_png_1788743121;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".detailsSubHeader");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".detailsSubHeader", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                null.backgroundSize = this;
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_basicpanel_subheader_png_797926995;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".vr");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".vr", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                null.backgroundSize = this;
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_quest_vertical_line_png_301357951;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".populationTipLabel");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".populationTipLabel", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.fontWeight = "bold";
                this.color = 16777215;
                this.textAlign = "left";
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".buildQueue");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".buildQueue", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundSize = "100%";
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_buildqueue_background_png_1041264038;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration("Panel");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration("Panel", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.paddingTop = 0;
                this.paddingLeft = 0;
                this.paddingBottom = 0;
                this.paddingRight = 0;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".buildingsList");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".buildingsList", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                null.borderStyle = this;
                this.useRollOver = false;
                this.selectionColor = "none";
                this.backgroundAlpha = 0;
                this.paddingLeft = 5;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".chatTab");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".chatTab", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                null.backgroundSize = this;
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_chat_bg_chattab_png_1946073156;
                this.paddingLeft = 0;
                this.paddingRight = 0;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".returnHome");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".returnHome", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.upSkin = _embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_home_standard_png_211790793;
                this.downSkin = _embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_home_push_png_924116583;
                this.overSkin = _embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_home_mouseover_png_356112253;
                this.disabledSkin = _embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_standard_png_475121235;
                this.paddingLeft = 1;
                this.paddingRight = 1;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".questOrnamental");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".questOrnamental", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                null.backgroundSize = this;
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_quest_quest_ornamental1_png_1017257770;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".infoBarMiddle");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".infoBarMiddle", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundSize = "100%";
                this.paddingTop = 8;
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_infobar_infobar_mid_png_222120674;
                this.paddingLeft = 15;
                this.paddingRight = 15;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".questPanelFooterReward");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".questPanelFooterReward", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundSize = "100%";
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_quest_quest_bg_bottom_gold_png_1079221376;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".standard");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".standard", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.upSkin = _embed_css_____data_src_gfx_embedded_buttons_standard_png_198723130;
                this.selectedDownSkin = _embed_css_____data_src_gfx_embedded_buttons_standard_highlight_png_160955392;
                this.downSkin = _embed_css_____data_src_gfx_embedded_buttons_standard_highlight_png_160955392;
                this.overSkin = _embed_css_____data_src_gfx_embedded_buttons_standard_highlight_png_160955392;
                this.color = 0;
                this.selectedUpSkin = _embed_css_____data_src_gfx_embedded_buttons_standard_highlight_png_160955392;
                this.disabledSkin = _embed_css_____data_src_gfx_embedded_buttons_standard_disabled_png_1784034958;
                this.selectedOverSkin = _embed_css_____data_src_gfx_embedded_buttons_standard_highlight_png_160955392;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".toolTip");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".toolTip", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.borderStyle = "solid";
                this.borderColor = 9934473;
                this.backgroundColor = 2828058;
                this.cornerRadius = 5;
                this.borderThickness = 1;
                this.backgroundAlpha = 0.9;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".mailDataGridHeader");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".mailDataGridHeader", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                null.fontWeight = this;
                this.useRollOver = false;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".shopFooterSmall");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".shopFooterSmall", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                null.backgroundSize = this;
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_shop_footer_png_1480837470;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".chatPrivateListNewMessage");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".chatPrivateListNewMessage", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.backgroundSize = "100%";
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_chat_button_selected_png_381018229;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".friendsList");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".friendsList", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                null.backgroundSize = this;
                this.paddingTop = 3;
                this.useRollOver = false;
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_friendslist_friendslist2_png_1667250557;
                this.borderThickness = 0;
                this.paddingLeft = 0;
                this.paddingBottom = 0;
                this.paddingRight = 0;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".filterFriendsList");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".filterFriendsList", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.upSkin = _embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_standard_png_475121235;
                this.selectedDownSkin = _embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_push_png_1621504697;
                this.downSkin = _embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_push_png_1621504697;
                this.overSkin = _embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_mouseover_png_890993175;
                this.selectedUpSkin = _embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_push_png_1621504697;
                this.disabledSkin = _embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_standard_png_475121235;
                this.paddingLeft = 1;
                this.selectedOverSkin = _embed_css_____data_src_gfx_embedded_friendslist_neighbours_tab_push_png_1621504697;
                this.paddingRight = 1;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".chatScaleButton");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".chatScaleButton", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.upSkin = _embed_css_____data_src_gfx_embedded_chat_scale_standard_png_103566885;
                this.downSkin = _embed_css_____data_src_gfx_embedded_chat_scale_standard_png_103566885;
                this.overSkin = _embed_css_____data_src_gfx_embedded_chat_scale_highlighted_png_935498501;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".specialClaim");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".specialClaim", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.fontWeight = "bold";
                this.color = 16772864;
                this.fontSize = 15;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".closeSmall");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".closeSmall", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                null.upSkin = this;
                this.downSkin = _embed_css_____data_src_gfx_embedded_buttons_x_small_selected_png_400774907;
                this.overSkin = _embed_css_____data_src_gfx_embedded_buttons_x_small_selected_png_400774907;
                this.disabledSkin = _embed_css_____data_src_gfx_embedded_buttons_x_small_standard_png_54314235;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration("Alert");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration("Alert", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                this.modalTransparency = 0.7;
                this.modalTransparencyBlur = 0;
                this.modalTransparencyColor = 0;
                return;
            }// end function
            ;
            }
            style = StyleManager.getStyleDeclaration(".actionBarCenter");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".actionBarCenter", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                null.backgroundSize = this;
                this.backgroundImage = _embed_css_____data_src_gfx_embedded_actionbar_actionbar3_png_187868604;
                return;
            }// end function
            ;
            }
            var _loc_2:* = StyleManager;
            _loc_2.mx_internal::initProtoChainRoots();
            return;
        }// end function

        private function AssignDeposit(param1:String) : void
        {
            return;
        }// end function

        private function _SWMMO_Label1_c() : Label
        {
            var _loc_1:* = new Label();
            _loc_1.text = "Brush Size";
            _loc_1.height = 18;
            _loc_1.x = -1;
            _loc_1.y = 3;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function ShowMilitaryUnitsWindow(param1:Boolean) : void
        {
            return;
        }// end function

        private function _SWMMO_AddChild21_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild21 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_Button24_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild21", this._SWMMO_AddChild21);
            return _loc_1;
        }// end function

        private function _SWMMO_AddChild67_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild67 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_QuestBook1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild67", this._SWMMO_AddChild67);
            return _loc_1;
        }// end function

        private function _SWMMO_MenuBar1_i() : MenuBar
        {
            var _loc_1:* = new MenuBar();
            this.EDITORSTATE_MenuBar = _loc_1;
            _loc_1.labelField = "@label";
            _loc_1.width = 180;
            _loc_1.visible = false;
            _loc_1.setStyle("borderColor", 0);
            _loc_1.setStyle("cornerRadius", 10);
            _loc_1.setStyle("left", "0");
            _loc_1.setStyle("top", "4");
            _loc_1.addEventListener("itemClick", this.__EDITORSTATE_MenuBar_itemClick);
            _loc_1.id = "EDITORSTATE_MenuBar";
            BindingManager.executeBindings(this, "EDITORSTATE_MenuBar", this.EDITORSTATE_MenuBar);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function ___SWMMO_Application1_mouseOut(event:MouseEvent) : void
        {
            this.mouseOut(event);
            return;
        }// end function

        public function ___SWMMO_Application1_mouseUp(event:MouseEvent) : void
        {
            this.mouseUp(event);
            return;
        }// end function

        protected function AssignedUnitID_itemEditEndClickHandler(event:DataGridEvent) : void
        {
            var _loc_2:int = 0;
            var _loc_3:String = null;
            var _loc_4:int = 0;
            var _loc_5:cArmy = null;
            if (this.mGeneralInterface.mCurrentlySelectededBuilding != null)
            {
                if (this.mAssignedUnitsSelectedRow != -1)
                {
                    _loc_2 = event.rowIndex;
                    _loc_3 = this.mAssignUnitsData[this.mAssignedUnitsSelectedRow].UnitType;
                    _loc_4 = this.mAssignUnitsData[this.mAssignedUnitsSelectedRow].Nr;
                    _loc_5 = this.mGeneralInterface.mCurrentlySelectededBuilding.GetArmy();
                    _loc_5.GetSquad(_loc_3).SetAmount(_loc_4);
                }
            }
            return;
        }// end function

        public function __EDITORSTATE_ID_TILE_LIST_SET_MODE_itemClick(event:ListEvent) : void
        {
            this.mGeneralInterface.TileListSetModeClick(event);
            return;
        }// end function

        private function _SWMMO_DataGridColumn24_c() : DataGridColumn
        {
            var _loc_1:DataGridColumn = null;
            _loc_1 = new DataGridColumn();
            _loc_1.headerText = "PathLen";
            _loc_1.dataField = "pathLen";
            return _loc_1;
        }// end function

        private function _SWMMO_Button5_i() : Button
        {
            var _loc_1:* = new Button();
            this.SectorIdButton4 = _loc_1;
            _loc_1.x = 11;
            _loc_1.y = 69;
            _loc_1.label = "4";
            _loc_1.width = 43;
            _loc_1.height = 20;
            _loc_1.addEventListener("click", this.__SectorIdButton4_click);
            _loc_1.id = "SectorIdButton4";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_SetProperty7_c() : SetProperty
        {
            var _loc_1:SetProperty = null;
            _loc_1 = new SetProperty();
            _loc_1.name = "layout";
            _loc_1.value = "vertical";
            return _loc_1;
        }// end function

        private function _SWMMO_Label13_c() : Label
        {
            var _loc_1:Label = null;
            _loc_1 = new Label();
            _loc_1.y = 405;
            _loc_1.text = "Load game_setting_debug.xml -> works only without server";
            _loc_1.setStyle("horizontalCenter", "272");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set GAMESTATE_ID_LIST_BASE_BUILDINGS(param1:BuildingsList) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1209783630GAMESTATE_ID_LIST_BASE_BUILDINGS;
            if (_loc_2 !== param1)
            {
                this._1209783630GAMESTATE_ID_LIST_BASE_BUILDINGS = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_LIST_BASE_BUILDINGS", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_SpecialistCooldownPanel1_i() : SpecialistCooldownPanel
        {
            var _loc_1:SpecialistCooldownPanel = null;
            _loc_1 = new SpecialistCooldownPanel();
            this.SPECIALIST_COOLDOWN_PANEL = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("right", "100");
            _loc_1.setStyle("bottom", "180");
            _loc_1.id = "SPECIALIST_COOLDOWN_PANEL";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_InfoBar1_i() : InfoBar
        {
            var _loc_1:InfoBar = null;
            _loc_1 = new InfoBar();
            this.GAMESTATE_ID_INFO_BAR = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("top", "-3");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.id = "GAMESTATE_ID_INFO_BAR";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get ReAssignSectorIDCancel() : Button
        {
            return this._528971107ReAssignSectorIDCancel;
        }// end function

        private function _SWMMO_AddChild32_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild32 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_AvatarMessageList1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild32", this._SWMMO_AddChild32);
            return _loc_1;
        }// end function

        public function set UnitListDataID(param1:DataGrid) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1939975865UnitListDataID;
            if (_loc_2 !== param1)
            {
                this._1939975865UnitListDataID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "UnitListDataID", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_Text2_i() : Text
        {
            var _loc_1:* = new Text();
            this.EDITORSTATE_PressoktocontinueId = _loc_1;
            _loc_1.x = 146.5;
            _loc_1.y = 92;
            _loc_1.text = "Press ok to continue";
            _loc_1.id = "EDITORSTATE_PressoktocontinueId";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        protected function FILTER_BUILDING_clickHandler(event:MouseEvent) : void
        {
            return;
        }// end function

        protected function FILTERLIST_NONE_ID_clickHandler(event:MouseEvent) : void
        {
            return;
        }// end function

        protected function EnterGame(event:Event) : void
        {
            gMisc.InitTimeSinceStartup();
            if (global.GAME_STATE != "MainMenu")
            {
                global.gameSettingsFilename = defines.FILENAME_GAME_SETTINGS;
            }
            global.ui = new cGameInterface();
            this.mGeneralInterface = global.ui;
            this.mGeneralInterface.mInitStartTime = getTimer();
            ExternalInterface.call("logStartUpTime");
            this.mGeneralInterface.mClientMessages.InitializeServerCommunication();
            this.mMemoryMonitor.Init(this.mGeneralInterface);
            this.mGeneralInterface.Init(0);
            if (cUnitTest.UNIT_TESTS_ENABLED)
            {
                cUnitTest.init(this.mGeneralInterface);
            }
            return;
        }// end function

        public function get DepositGroupWindowID() : TabNavigator
        {
            return this._1808756020DepositGroupWindowID;
        }// end function

        public function get GAMESTATE_ID_MAIL_WINDOW() : MailWindow
        {
            return this._1999815380GAMESTATE_ID_MAIL_WINDOW;
        }// end function

        public function set SetSectorID(param1:RadioButton) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._310338915SetSectorID;
            if (_loc_2 !== param1)
            {
                this._310338915SetSectorID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SetSectorID", _loc_2, param1));
            }
            return;
        }// end function

        public function set SectorListID(param1:TitleWindow) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._85130591SectorListID;
            if (_loc_2 !== param1)
            {
                this._85130591SectorListID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SectorListID", _loc_2, param1));
            }
            return;
        }// end function

        private function activateHandler(event:Event) : void
        {
            if (!this.DEACTIVATE_HANDLER_ACTIVE)
            {
                return;
            }
            if (!this.mApplicationActive)
            {
                this.mIgnoreNextClick = true;
                this.mApplicationActive = true;
                this.EnableApplication();
            }
            return;
        }// end function

        public function set GAMESTATE_ID_QUEST_BOOK(param1:QuestBook) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._994711914GAMESTATE_ID_QUEST_BOOK;
            if (_loc_2 !== param1)
            {
                this._994711914GAMESTATE_ID_QUEST_BOOK = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_QUEST_BOOK", _loc_2, param1));
            }
            return;
        }// end function

        public function get newSectorIDTextInput() : TextInput
        {
            return this._1299074340newSectorIDTextInput;
        }// end function

        private function _SWMMO_RadioButtonGroup2_i() : RadioButtonGroup
        {
            var _loc_1:* = new RadioButtonGroup();
            this.radiogroupOwnerShip = _loc_1;
            _loc_1.initialized(this, "radiogroupOwnerShip");
            return _loc_1;
        }// end function

        public function get FILTER_BUILDING_NONE_ID() : Button
        {
            return this._825365214FILTER_BUILDING_NONE_ID;
        }// end function

        private function _SWMMO_AddChild43_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild43 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_EnemyBuildingInfoPanel1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild43", this._SWMMO_AddChild43);
            return _loc_1;
        }// end function

        private function mouseDown(event:MouseEvent) : void
        {
            if (this.mGeneralInterface == null)
            {
                return;
            }
            if (event.target is UIComponent)
            {
                if (event.target.owner is UIComponent)
                {
                    if ((event.target.owner as UIComponent).id != "messageInput")
                    {
                        if (this.GAMESTATE_ID_CHAT_PANEL != null && this.GAMESTATE_ID_CHAT_PANEL.messageInput)
                        {
                            if (focusManager.getFocus() == this.GAMESTATE_ID_CHAT_PANEL.messageInput)
                            {
                                event.target.setFocus();
                            }
                        }
                    }
                }
            }
            if (this.IsMouseOverCanvas(event))
            {
                this.mGeneralInterface.MouseDown(event);
            }
            return;
        }// end function

        public function get mCheatBoxtDataProvider() : ArrayCollection
        {
            return this._139379434mCheatBoxtDataProvider;
        }// end function

        public function set GAMESTATE_ID_FRIENDS_LIST(param1:FriendsList) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1301551436GAMESTATE_ID_FRIENDS_LIST;
            if (_loc_2 !== param1)
            {
                this._1301551436GAMESTATE_ID_FRIENDS_LIST = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_FRIENDS_LIST", _loc_2, param1));
            }
            return;
        }// end function

        public function get FILTER_BUILDING_Watchtower() : CheckBox
        {
            return this._1514347810FILTER_BUILDING_Watchtower;
        }// end function

        public function __SectorIdButton1_click(event:MouseEvent) : void
        {
            this.SectorIDNumberClicked(event);
            return;
        }// end function

        private function _SWMMO_CheckBox19_i() : CheckBox
        {
            var _loc_1:CheckBox = null;
            _loc_1 = new CheckBox();
            this.ID_DebugInfoPanelShowDetailErrorLog = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 213;
            _loc_1.label = "ShowDetailErrorLog";
            _loc_1.id = "ID_DebugInfoPanelShowDetailErrorLog";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __BrushSizeTextInputId_change(event:Event) : void
        {
            this.BrushSizeTextInputIdChanged();
            return;
        }// end function

        public function __radiogroupOwnerShipPlayer_click(event:MouseEvent) : void
        {
            this.radiobuttonPlayer_clickHandler(event);
            return;
        }// end function

        public function set FILTER_BUILDING_None(param1:CheckBox) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._643659396FILTER_BUILDING_None;
            if (_loc_2 !== param1)
            {
                this._643659396FILTER_BUILDING_None = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "FILTER_BUILDING_None", _loc_2, param1));
            }
            return;
        }// end function

        public function set ID_SHOW_DEBUG_INFO_PANEL(param1:Panel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._374144381ID_SHOW_DEBUG_INFO_PANEL;
            if (_loc_2 !== param1)
            {
                this._374144381ID_SHOW_DEBUG_INFO_PANEL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "ID_SHOW_DEBUG_INFO_PANEL", _loc_2, param1));
            }
            return;
        }// end function

        public function get RedBlockingRadioButtonID() : RadioButton
        {
            return this._585034434RedBlockingRadioButtonID;
        }// end function

        private function SectorIDNumberClicked(event:Event) : void
        {
            return;
        }// end function

        private function _SWMMO_AddChild54_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild54 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_LoadingZonePanel1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild54", this._SWMMO_AddChild54);
            return _loc_1;
        }// end function

        private function _SWMMO_DataGridColumn4_c() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            _loc_1.headerText = "Assigned Deposit";
            _loc_1.dataField = "assignedDeposit";
            _loc_1.sortable = false;
            return _loc_1;
        }// end function

        private function _SWMMO_DataGridColumn11_c() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            _loc_1.headerText = "Expl. Priority";
            _loc_1.dataField = "ExplorerPriority";
            _loc_1.width = 80;
            _loc_1.sortable = false;
            return _loc_1;
        }// end function

        public function set GAMESTATE_ID_TRADING_PANEL(param1:TradingPanel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._2088117886GAMESTATE_ID_TRADING_PANEL;
            if (_loc_2 !== param1)
            {
                this._2088117886GAMESTATE_ID_TRADING_PANEL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_TRADING_PANEL", _loc_2, param1));
            }
            return;
        }// end function

        public function get GAMESTATE_ID_INFO_BAR() : InfoBar
        {
            return this._97475834GAMESTATE_ID_INFO_BAR;
        }// end function

        public function set ResourceProductionWindowDataGrid(param1:DataGrid) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._526777977ResourceProductionWindowDataGrid;
            if (_loc_2 !== param1)
            {
                this._526777977ResourceProductionWindowDataGrid = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "ResourceProductionWindowDataGrid", _loc_2, param1));
            }
            return;
        }// end function

        private function DepositGroupAddGroupClicked(event:Event) : void
        {
            return;
        }// end function

        public function set GAMESTATE_ID_STAR_MENU(param1:StarMenu) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._2105831032GAMESTATE_ID_STAR_MENU;
            if (_loc_2 !== param1)
            {
                this._2105831032GAMESTATE_ID_STAR_MENU = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_STAR_MENU", _loc_2, param1));
            }
            return;
        }// end function

        public function set SingleDepositAmountTextBoxID(param1:TextInput) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._962977397SingleDepositAmountTextBoxID;
            if (_loc_2 !== param1)
            {
                this._962977397SingleDepositAmountTextBoxID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SingleDepositAmountTextBoxID", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_AddChild65_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild65 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_GuildWindow1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild65", this._SWMMO_AddChild65);
            return _loc_1;
        }// end function

        private function _SWMMO_Button3_i() : Button
        {
            var _loc_1:* = new Button();
            this.SectorIdButton2 = _loc_1;
            _loc_1.x = 61;
            _loc_1.y = 97;
            _loc_1.label = "2";
            _loc_1.width = 43;
            _loc_1.height = 20;
            _loc_1.addEventListener("click", this.__SectorIdButton2_click);
            _loc_1.id = "SectorIdButton2";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_SetProperty5_i() : SetProperty
        {
            var _loc_1:* = new SetProperty();
            this._SWMMO_SetProperty5 = _loc_1;
            _loc_1.name = "visible";
            _loc_1.value = true;
            BindingManager.executeBindings(this, "_SWMMO_SetProperty5", this._SWMMO_SetProperty5);
            return _loc_1;
        }// end function

        private function _SWMMO_DataGridColumn22_c() : DataGridColumn
        {
            var _loc_1:DataGridColumn = null;
            _loc_1 = new DataGridColumn();
            _loc_1.headerText = "Removed";
            _loc_1.dataField = "amountRemoved";
            return _loc_1;
        }// end function

        public function __FILTER_BUILDING_workyard_click(event:MouseEvent) : void
        {
            this.FILTER_BUILDING_clickHandler(event);
            return;
        }// end function

        private function moveWindow(event:MouseEvent) : void
        {
            return;
        }// end function

        private function _SWMMO_FriendsList1_i() : FriendsList
        {
            var _loc_1:FriendsList = null;
            _loc_1 = new FriendsList();
            this.GAMESTATE_ID_FRIENDS_LIST = _loc_1;
            _loc_1.visible = false;
            _loc_1.id = "GAMESTATE_ID_FRIENDS_LIST";
            BindingManager.executeBindings(this, "GAMESTATE_ID_FRIENDS_LIST", this.GAMESTATE_ID_FRIENDS_LIST);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get GAMESTATE_ID_MEMORY_MONITOR() : MemoryMonitorPanel
        {
            return this._1603470112GAMESTATE_ID_MEMORY_MONITOR;
        }// end function

        private function _SWMMO_Label11_i() : Label
        {
            var _loc_1:Label = null;
            _loc_1 = new Label();
            this.label1 = _loc_1;
            _loc_1.selectable = true;
            _loc_1.text = "";
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("bottom", "20");
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "label1";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __SectorIdButton6_click(event:MouseEvent) : void
        {
            this.SectorIDNumberClicked(event);
            return;
        }// end function

        private function _SWMMO_Canvas3_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.FilterGoListID = _loc_1;
            _loc_1.width = 265;
            _loc_1.height = 125;
            _loc_1.visible = true;
            _loc_1.alpha = 1;
            _loc_1.setStyle("backgroundColor", 8092539);
            _loc_1.setStyle("backgroundAlpha", 0.6);
            _loc_1.setStyle("cornerRadius", 20);
            _loc_1.setStyle("bottom", "10");
            _loc_1.setStyle("right", "10");
            _loc_1.id = "FilterGoListID";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SWMMO_Button19_i());
            _loc_1.addChild(this._SWMMO_Button20_i());
            _loc_1.addChild(this._SWMMO_Button21_i());
            _loc_1.addChild(this._SWMMO_CheckBox1_i());
            _loc_1.addChild(this._SWMMO_CheckBox2_i());
            _loc_1.addChild(this._SWMMO_CheckBox3_i());
            _loc_1.addChild(this._SWMMO_CheckBox4_i());
            _loc_1.addChild(this._SWMMO_CheckBox5_i());
            _loc_1.addChild(this._SWMMO_CheckBox6_i());
            _loc_1.addChild(this._SWMMO_CheckBox7_i());
            _loc_1.addChild(this._SWMMO_CheckBox8_i());
            _loc_1.addChild(this._SWMMO_CheckBox9_i());
            _loc_1.addChild(this._SWMMO_CheckBox10_i());
            return _loc_1;
        }// end function

        private function _SWMMO_AddChild30_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild30 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_Avatar1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild30", this._SWMMO_AddChild30);
            return _loc_1;
        }// end function

        private function _SWMMO_AddChild76_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild76 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_TitleWindow7_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild76", this._SWMMO_AddChild76);
            return _loc_1;
        }// end function

        public function set SetLandingZoneID(param1:RadioButton) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1776177564SetLandingZoneID;
            if (_loc_2 !== param1)
            {
                this._1776177564SetLandingZoneID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SetLandingZoneID", _loc_2, param1));
            }
            return;
        }// end function

        public function get SectorListCloseIDButton() : Button
        {
            return this._1921297217SectorListCloseIDButton;
        }// end function

        public function get FILTER_BUILDING_Residence() : CheckBox
        {
            return this._831698110FILTER_BUILDING_Residence;
        }// end function

        public function get radiogroupOwnerShipPlayer() : RadioButton
        {
            return this._743085236radiogroupOwnerShipPlayer;
        }// end function

        protected function UnitListDataID_itemClickHandler(event:ListEvent) : void
        {
            if (this.mGeneralInterface.mCurrentlySelectededBuilding != null)
            {
                this.mUnitsListSelectedRow = event.itemRenderer.data.SortID;
            }
            return;
        }// end function

        public function set radiogroupOwnerShipfree(param1:RadioButton) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1148490103radiogroupOwnerShipfree;
            if (_loc_2 !== param1)
            {
                this._1148490103radiogroupOwnerShipfree = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "radiogroupOwnerShipfree", _loc_2, param1));
            }
            return;
        }// end function

        public function __radiogroupOwnerShipBanditCamp_click(event:MouseEvent) : void
        {
            this.radiobuttonBanditCamp_clickHandler(event);
            return;
        }// end function

        private function _SWMMO_State3_c() : State
        {
            var _loc_1:State = null;
            _loc_1 = new State();
            _loc_1.name = "LoadSettings";
            _loc_1.overrides = [this._SWMMO_AddChild25_i()];
            return _loc_1;
        }// end function

        private function _SWMMO_AddChild41_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild41 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_BuildingInfoPanel1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild41", this._SWMMO_AddChild41);
            return _loc_1;
        }// end function

        public function get BrushSizeTextInputId() : TextInput
        {
            return this._592859997BrushSizeTextInputId;
        }// end function

        public function set FILTER_BUILDING_undefined(param1:CheckBox) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1702874708FILTER_BUILDING_undefined;
            if (_loc_2 !== param1)
            {
                this._1702874708FILTER_BUILDING_undefined = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "FILTER_BUILDING_undefined", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_CheckBox17_i() : CheckBox
        {
            var _loc_1:CheckBox = null;
            _loc_1 = new CheckBox();
            this.ID_DebugInfoPanelShowQuestInfo = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 155;
            _loc_1.label = "ShowQuestInfo";
            _loc_1.id = "ID_DebugInfoPanelShowQuestInfo";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set FILTER_BUILDING_INVERT_ID0(param1:Button) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1041187408FILTER_BUILDING_INVERT_ID0;
            if (_loc_2 !== param1)
            {
                this._1041187408FILTER_BUILDING_INVERT_ID0 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "FILTER_BUILDING_INVERT_ID0", _loc_2, param1));
            }
            return;
        }// end function

        public function set GAMESTATE_ID_MINIMAL_INFO_PANEL(param1:MinimalInfoPanel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._722613835GAMESTATE_ID_MINIMAL_INFO_PANEL;
            if (_loc_2 !== param1)
            {
                this._722613835GAMESTATE_ID_MINIMAL_INFO_PANEL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_MINIMAL_INFO_PANEL", _loc_2, param1));
            }
            return;
        }// end function

        public function __FILTER_BUILDING_Enemy_click(event:MouseEvent) : void
        {
            this.FILTER_BUILDING_clickHandler(event);
            return;
        }// end function

        public function get GAMESTATE_ID_LIST_CL01_BUILDINGS() : BuildingsList
        {
            return this._1166847129GAMESTATE_ID_LIST_CL01_BUILDINGS;
        }// end function

        private function _SWMMO_AddChild52_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild52 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_BuildingsList3_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild52", this._SWMMO_AddChild52);
            return _loc_1;
        }// end function

        private function _SWMMO_DataGridColumn2_c() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            _loc_1.headerText = "Max Accessible";
            _loc_1.dataField = "maxAccessible";
            _loc_1.sortable = false;
            return _loc_1;
        }// end function

        public function set GAMESTATE_ID_ADD_FRIENDS_PANEL(param1:AddFriendsPanel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._257851832GAMESTATE_ID_ADD_FRIENDS_PANEL;
            if (_loc_2 !== param1)
            {
                this._257851832GAMESTATE_ID_ADD_FRIENDS_PANEL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_ADD_FRIENDS_PANEL", _loc_2, param1));
            }
            return;
        }// end function

        public function get GAMESTATE_ID_QUEST_NEW_QUEST_SYSTEM_LIST_PANEL() : QuestNewQuestSystemList
        {
            return this._626564234GAMESTATE_ID_QUEST_NEW_QUEST_SYSTEM_LIST_PANEL;
        }// end function

        public function get GAMESTATE_ID_FOUND_GUILD_PANEL() : FoundGuildPanel
        {
            return this._768529271GAMESTATE_ID_FOUND_GUILD_PANEL;
        }// end function

        public function set FILTER_BUILDING_Enemy(param1:CheckBox) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1513045444FILTER_BUILDING_Enemy;
            if (_loc_2 !== param1)
            {
                this._1513045444FILTER_BUILDING_Enemy = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "FILTER_BUILDING_Enemy", _loc_2, param1));
            }
            return;
        }// end function

        public function get GAMESTATE_ID_LIST_CL2_BUILDINGS() : BuildingsList
        {
            return this._1444752500GAMESTATE_ID_LIST_CL2_BUILDINGS;
        }// end function

        public function get AssignUnitID() : Button
        {
            return this._2118605938AssignUnitID;
        }// end function

        public function set mMemoryMonitor(param1:gMemoryMonitor) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._267857324mMemoryMonitor;
            if (_loc_2 !== param1)
            {
                this._267857324mMemoryMonitor = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mMemoryMonitor", _loc_2, param1));
            }
            return;
        }// end function

        public function set GAMESTATE_ID_BATTLE_WINDOW(param1:BattleWindow) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1970511437GAMESTATE_ID_BATTLE_WINDOW;
            if (_loc_2 !== param1)
            {
                this._1970511437GAMESTATE_ID_BATTLE_WINDOW = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_BATTLE_WINDOW", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_AddChild63_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild63 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_BattleWindow1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild63", this._SWMMO_AddChild63);
            return _loc_1;
        }// end function

        override public function initialize() : void
        {
            var target:SWMMO;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._SWMMO_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_SWMMOWatcherSetupUtil");
                var _loc_2:* = watcherSetupUtilClass;
                _loc_2.watcherSetupUtilClass["init"](null);
            }
            _watcherSetupUtil.setup(this, function (param1:String)
            {
                return null[param1];
            }// end function
            , bindings, watchers);
            var i:uint;
            while (i < bindings.length)
            {
                
                Binding(bindings[i]).execute();
                i = (i + 1);
            }
            mx_internal::_bindings = mx_internal::_bindings.concat(bindings);
            mx_internal::_watchers = mx_internal::_watchers.concat(watchers);
            super.initialize();
            return;
        }// end function

        private function _SWMMO_SetProperty3_i() : SetProperty
        {
            var _loc_1:* = new SetProperty();
            this._SWMMO_SetProperty3 = _loc_1;
            _loc_1.name = "y";
            BindingManager.executeBindings(this, "_SWMMO_SetProperty3", this._SWMMO_SetProperty3);
            return _loc_1;
        }// end function

        private function _SWMMO_DataGridColumn20_c() : DataGridColumn
        {
            var _loc_1:DataGridColumn = null;
            _loc_1 = new DataGridColumn();
            _loc_1.headerText = "necessary Resource";
            _loc_1.dataField = "necessaryResource";
            return _loc_1;
        }// end function

        private function _SWMMO_Button1_i() : Button
        {
            var _loc_1:* = new Button();
            this.SectorIdButton0 = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 125;
            _loc_1.label = "0";
            _loc_1.width = 43;
            _loc_1.height = 20;
            _loc_1.addEventListener("click", this.__SectorIdButton0_click);
            _loc_1.id = "SectorIdButton0";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_AddFriendsPanel1_i() : AddFriendsPanel
        {
            var _loc_1:AddFriendsPanel = null;
            _loc_1 = new AddFriendsPanel();
            this.GAMESTATE_ID_ADD_FRIENDS_PANEL = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "GAMESTATE_ID_ADD_FRIENDS_PANEL";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function UpdateBrushSizeRadioButtons() : void
        {
            return;
        }// end function

        public function get SectorModeWindow() : TitleWindow
        {
            return this._1994189721SectorModeWindow;
        }// end function

        private function _SWMMO_WatchTowerInfoPanel1_i() : WatchTowerInfoPanel
        {
            var _loc_1:WatchTowerInfoPanel = null;
            _loc_1 = new WatchTowerInfoPanel();
            this.GAMESTATE_ID_WATCHTOWER_INFO_PANEL = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("right", "100");
            _loc_1.setStyle("bottom", "180");
            _loc_1.id = "GAMESTATE_ID_WATCHTOWER_INFO_PANEL";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __AssignedUnitID_itemEditEnd(event:DataGridEvent) : void
        {
            this.AssignedUnitID_itemEditEndClickHandler(event);
            return;
        }// end function

        private function _SWMMO_AddChild74_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild74 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_LegalPanel1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild74", this._SWMMO_AddChild74);
            return _loc_1;
        }// end function

        public function ___SWMMO_Application1_applicationComplete(event:FlexEvent) : void
        {
            this.initXML();
            return;
        }// end function

        private function _SWMMO_Canvas1_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.GroupDepositID = _loc_1;
            _loc_1.label = "Group Deposit";
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            _loc_1.visible = true;
            _loc_1.id = "GroupDepositID";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SWMMO_DataGrid1_i());
            _loc_1.addChild(this._SWMMO_Button11_i());
            _loc_1.addChild(this._SWMMO_Button12_i());
            _loc_1.addChild(this._SWMMO_Button13_i());
            return _loc_1;
        }// end function

        public function get radiogroupOwnerShipBanditCamp() : RadioButton
        {
            return this._350084012radiogroupOwnerShipBanditCamp;
        }// end function

        private function _SWMMO_DataGrid5_i() : DataGrid
        {
            var _loc_1:DataGrid = null;
            _loc_1 = new DataGrid();
            this.ResourceProductionWindowDataGrid = _loc_1;
            _loc_1.columns = [this._SWMMO_DataGridColumn14_c(), this._SWMMO_DataGridColumn15_c(), this._SWMMO_DataGridColumn16_c(), this._SWMMO_DataGridColumn17_c(), this._SWMMO_DataGridColumn18_c(), this._SWMMO_DataGridColumn19_c(), this._SWMMO_DataGridColumn20_c(), this._SWMMO_DataGridColumn21_c(), this._SWMMO_DataGridColumn22_c(), this._SWMMO_DataGridColumn23_c(), this._SWMMO_DataGridColumn24_c(), this._SWMMO_DataGridColumn25_c()];
            _loc_1.setStyle("right", "10");
            _loc_1.setStyle("left", "10");
            _loc_1.setStyle("bottom", "10");
            _loc_1.setStyle("top", "22");
            _loc_1.id = "ResourceProductionWindowDataGrid";
            BindingManager.executeBindings(this, "ResourceProductionWindowDataGrid", this.ResourceProductionWindowDataGrid);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function RefreshUnitsListGroupWindow() : void
        {
            var _loc_2:cMilitaryUnitDescription = null;
            this.mUnitListData = new ArrayCollection();
            var _loc_1:int = 0;
            for each (_loc_2 in cMilitaryUnitDescription.GetAllUnitDescriptions(false))
            {
                
                this.mUnitListData.addItem({SortID:"" + _loc_1, UnitType:"" + _loc_2.GetType_string(), UnitHP:"" + _loc_2.GetHitPoints(), UnitDamage:"" + _loc_2.GetHitDamage()});
                _loc_1++;
            }
            return;
        }// end function

        public function get mGeneralInterface() : cGeneralInterface
        {
            return this._25308226mGeneralInterface;
        }// end function

        private function _SWMMO_RadioButton9_i() : RadioButton
        {
            var _loc_1:* = new RadioButton();
            this.radiogroupOwnerShipPlayer = _loc_1;
            _loc_1.label = "Player";
            _loc_1.groupName = "radiogroupOwnerShip";
            _loc_1.selected = true;
            _loc_1.x = 10;
            _loc_1.y = 32;
            _loc_1.addEventListener("click", this.__radiogroupOwnerShipPlayer_click);
            _loc_1.id = "radiogroupOwnerShipPlayer";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __FILTER_BUILDING_Minimal_click(event:MouseEvent) : void
        {
            this.FILTER_BUILDING_clickHandler(event);
            return;
        }// end function

        public function get mResourceProductionWindowDataGridDataProvider() : ArrayCollection
        {
            return this._137831375mResourceProductionWindowDataGridDataProvider;
        }// end function

        public function get DepositGroupDataGrid() : DataGrid
        {
            return this._1095300049DepositGroupDataGrid;
        }// end function

        public function set EDITORSTATE_focusID(param1:List) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._394601000EDITORSTATE_focusID;
            if (_loc_2 !== param1)
            {
                this._394601000EDITORSTATE_focusID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "EDITORSTATE_focusID", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_TextInput5_i() : TextInput
        {
            var _loc_1:* = new TextInput();
            this.oldSectorIDTextInput = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 33;
            _loc_1.width = 80;
            _loc_1.id = "oldSectorIDTextInput";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_State1_c() : State
        {
            var _loc_1:* = new State();
            _loc_1.name = "Editor";
            _loc_1.overrides = [this._SWMMO_AddChild1_i(), this._SWMMO_AddChild2_i(), this._SWMMO_AddChild3_i(), this._SWMMO_SetProperty1_c(), this._SWMMO_SetProperty2_i(), this._SWMMO_SetProperty3_i(), this._SWMMO_SetProperty4_c(), this._SWMMO_AddChild4_i(), this._SWMMO_AddChild5_i(), this._SWMMO_AddChild6_i(), this._SWMMO_AddChild7_i(), this._SWMMO_AddChild8_i(), this._SWMMO_AddChild9_i(), this._SWMMO_AddChild10_i(), this._SWMMO_AddChild11_i(), this._SWMMO_AddChild12_i(), this._SWMMO_SetProperty5_i(), this._SWMMO_AddChild13_i(), this._SWMMO_AddChild14_i(), this._SWMMO_AddChild15_i()];
            _loc_1.addEventListener("enterState", this.___SWMMO_State1_enterState);
            _loc_1.addEventListener("exitState", this.___SWMMO_State1_exitState);
            return _loc_1;
        }// end function

        public function get ReAssignSectorIDButton() : Button
        {
            return this._538934443ReAssignSectorIDButton;
        }// end function

        public function set EraseLandingZoneID(param1:RadioButton) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1422934488EraseLandingZoneID;
            if (_loc_2 !== param1)
            {
                this._1422934488EraseLandingZoneID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "EraseLandingZoneID", _loc_2, param1));
            }
            return;
        }// end function

        public function set FILTER_BUILDING_workyard(param1:CheckBox) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1954153967FILTER_BUILDING_workyard;
            if (_loc_2 !== param1)
            {
                this._1954153967FILTER_BUILDING_workyard = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "FILTER_BUILDING_workyard", _loc_2, param1));
            }
            return;
        }// end function

        protected function ID_SHOW_DEBUG_INFO_PANEL_hideHandler(event:FlexEvent) : void
        {
            this.mGeneralInterface.SHOW_DEBUG_TEXT = this.ID_DebugInfoPanelShowAll.selected;
            this.mGeneralInterface.mShowAdditionalDebugInfo = this.ID_DebugInfoPanelAdditionalDebugInfo.selected;
            this.mGeneralInterface.mOnScreenFps = this.ID_DebugInfoPanelShowFPS.selected;
            this.mGeneralInterface.mShowOnScreenInfoPlayer = this.ID_DebugInfoPanelShowPlayerInfo.selected;
            this.mGeneralInterface.mShowOnScreenInfoGameTickCommands = this.ID_DebugInfoPanelShowOnScreenGameTickCommands.selected;
            this.mGeneralInterface.mShowOnScreenInfoQuest = this.ID_DebugInfoPanelShowQuestInfo.selected;
            this.mGeneralInterface.mShowIngameErrorLog = this.ID_DebugInfoPanelShowErrorLog.selected;
            this.mGeneralInterface.mShowIngameDetailErrorLog = this.ID_DebugInfoPanelShowDetailErrorLog.selected;
            this.mGeneralInterface.mCurrentPlayerZone.mSettlerKIManager.ACTIVATE_SETTLER_DEBUG_INFO = this.ID_DebugInfoPanelShowSettlerDebugInfo.selected;
            return;
        }// end function

        private function _SWMMO_AvatarMessageList1_i() : AvatarMessageList
        {
            var _loc_1:AvatarMessageList = null;
            _loc_1 = new AvatarMessageList();
            this.GAMESTATE_ID_AVATAR_MESSAGE_LIST = _loc_1;
            _loc_1.visible = true;
            _loc_1.setStyle("top", "0");
            _loc_1.id = "GAMESTATE_ID_AVATAR_MESSAGE_LIST";
            BindingManager.executeBindings(this, "GAMESTATE_ID_AVATAR_MESSAGE_LIST", this.GAMESTATE_ID_AVATAR_MESSAGE_LIST);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function ___SWMMO_RadioButton5_click(event:MouseEvent) : void
        {
            this.UpdateBrushSizeRadioButtons();
            return;
        }// end function

        public function RefreshDepositGroupWindow() : void
        {
            return;
        }// end function

        protected function UPGRADLEVEL_ID_TEXT_changeHandler(event:Event) : void
        {
            return;
        }// end function

        private function _SWMMO_AddChild50_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild50 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_BuildingsList1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild50", this._SWMMO_AddChild50);
            return _loc_1;
        }// end function

        private function _SWMMO_Button18_i() : Button
        {
            var _loc_1:* = new Button();
            this.ReAssignSectorIDCancel = _loc_1;
            _loc_1.x = 108;
            _loc_1.y = 63;
            _loc_1.label = "Close";
            _loc_1.visible = true;
            _loc_1.addEventListener("click", this.__ReAssignSectorIDCancel_click);
            _loc_1.id = "ReAssignSectorIDCancel";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_BuildingsList3_i() : BuildingsList
        {
            var _loc_1:BuildingsList = null;
            _loc_1 = new BuildingsList();
            this.GAMESTATE_ID_LIST_CL2_BUILDINGS = _loc_1;
            _loc_1.visible = false;
            _loc_1.id = "GAMESTATE_ID_LIST_CL2_BUILDINGS";
            BindingManager.executeBindings(this, "GAMESTATE_ID_LIST_CL2_BUILDINGS", this.GAMESTATE_ID_LIST_CL2_BUILDINGS);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __btnRunTests_click(event:MouseEvent) : void
        {
            this.StartTestClicked(event);
            return;
        }// end function

        private function _SWMMO_CheckBox15_i() : CheckBox
        {
            var _loc_1:CheckBox = null;
            _loc_1 = new CheckBox();
            this.ID_DebugInfoPanelShowPlayerInfo = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 97;
            _loc_1.label = "ShowPlayerInfo";
            _loc_1.id = "ID_DebugInfoPanelShowPlayerInfo";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __ReAssignSectorIDButton_click(event:MouseEvent) : void
        {
            this.ReAssignSectorIDButton_clickHandler(event);
            return;
        }// end function

        public function get EDITORSTATE_MenuBar() : MenuBar
        {
            return this._1383535623EDITORSTATE_MenuBar;
        }// end function

        protected function RemoveUnitID_clickHandler(event:MouseEvent) : void
        {
            var _loc_2:String = null;
            var _loc_3:cArmy = null;
            if (this.mGeneralInterface.mCurrentlySelectededBuilding != null)
            {
                if (this.mAssignedUnitsSelectedRow != -1)
                {
                    _loc_2 = this.mAssignUnitsData[this.mAssignedUnitsSelectedRow].UnitType;
                    _loc_3 = this.mGeneralInterface.mCurrentlySelectededBuilding.GetArmy();
                    _loc_3.RemoveUnits(_loc_2, 1);
                    this.RefreshAssignUnitsGroupWindow();
                }
                else
                {
                    gErrorMessages.ShowGameInfo("Select a Unit in Units List");
                }
            }
            return;
        }// end function

        public function set GAMESTATE_ID_GUILD_WINDOW(param1:GuildWindow) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1393716736GAMESTATE_ID_GUILD_WINDOW;
            if (_loc_2 !== param1)
            {
                this._1393716736GAMESTATE_ID_GUILD_WINDOW = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_GUILD_WINDOW", _loc_2, param1));
            }
            return;
        }// end function

        public function set EDITORSTATE_PressoktocontinueId(param1:Text) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._620159487EDITORSTATE_PressoktocontinueId;
            if (_loc_2 !== param1)
            {
                this._620159487EDITORSTATE_PressoktocontinueId = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "EDITORSTATE_PressoktocontinueId", _loc_2, param1));
            }
            return;
        }// end function

        public function set ID_DebugInfoPanelShowFPS(param1:CheckBox) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1859193339ID_DebugInfoPanelShowFPS;
            if (_loc_2 !== param1)
            {
                this._1859193339ID_DebugInfoPanelShowFPS = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "ID_DebugInfoPanelShowFPS", _loc_2, param1));
            }
            return;
        }// end function

        public function set ID_DebugInfoPanelShowOnScreenGameTickCommands(param1:CheckBox) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1897880070ID_DebugInfoPanelShowOnScreenGameTickCommands;
            if (_loc_2 !== param1)
            {
                this._1897880070ID_DebugInfoPanelShowOnScreenGameTickCommands = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "ID_DebugInfoPanelShowOnScreenGameTickCommands", _loc_2, param1));
            }
            return;
        }// end function

        public function set FILTER_BUILDING_ALL_ID(param1:Button) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._486907459FILTER_BUILDING_ALL_ID;
            if (_loc_2 !== param1)
            {
                this._486907459FILTER_BUILDING_ALL_ID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "FILTER_BUILDING_ALL_ID", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_SetProperty1_c() : SetProperty
        {
            var _loc_1:* = new SetProperty();
            _loc_1.name = "width";
            _loc_1.value = "100%";
            return _loc_1;
        }// end function

        public function RefreshResourceProductionWindow() : void
        {
            var _loc_1:cResourceCreation = null;
            var _loc_2:String = null;
            var _loc_3:String = null;
            var _loc_4:cResources = null;
            this.mResourceProductionWindowDataGridDataProvider = new ArrayCollection();
            for each (_loc_1 in this.mGeneralInterface.mComputeResourceCreation.mResourceCreation_vector)
            {
                
                if (_loc_1.GetResourceCreationDefinition() == null)
                {
                    continue;
                }
                _loc_2 = "-";
                if (_loc_1.GetPath() != null)
                {
                    _loc_2 = "" + _loc_1.GetPath().pathLenX10000 / defines.INT_SCALE_FACTOR;
                }
                _loc_3 = "-";
                if (_loc_1.GetDepositPath() != null)
                {
                    _loc_3 = "" + _loc_1.GetDepositPath().pathLenX10000 / defines.INT_SCALE_FACTOR;
                }
                _loc_4 = this.mGeneralInterface.mCurrentPlayerZone.GetResources(this.mGeneralInterface.mCurrentPlayer);
                this.mResourceProductionWindowDataGridDataProvider.addItem({resource:"" + _loc_1.GetResourceCreationDefinition().defaultSetting.resourceName_string, group:"" + _loc_1.GetResourceCreationDefinition().defaultSetting.group_string, type:"" + _loc_1.GetResourceTypeString(), amount:"" + _loc_4.GetPlayerResource(_loc_1.GetResourceCreationDefinition().defaultSetting.resourceName_string).amount, maxlimit:"" + _loc_4.GetPlayerResource(_loc_1.GetResourceCreationDefinition().defaultSetting.resourceName_string).maxLimit, building:"" + _loc_1.GetResourceCreationDefinition().buildingName_string, necessaryResource:"" + _loc_1.GetNecessaryResourceTypeString(), externalResource:"" + _loc_1.GetResourceCreationDefinition().externalResource_string, amountRemoved:"" + _loc_1.GetResourceCreationDefinition().amountRemoved, workTime:"" + _loc_1.GetResourceCreationDefinition().workTime, pathLen:"" + _loc_2, depositPathLen:"" + _loc_3});
            }
            return;
        }// end function

        private function _SWMMO_SetProperty16_i() : SetProperty
        {
            var _loc_1:SetProperty = null;
            _loc_1 = new SetProperty();
            this._SWMMO_SetProperty16 = _loc_1;
            _loc_1.name = "horizontalScrollPolicy";
            _loc_1.value = "off";
            BindingManager.executeBindings(this, "_SWMMO_SetProperty16", this._SWMMO_SetProperty16);
            return _loc_1;
        }// end function

        public function get brushSizeRadiogroup() : RadioButtonGroup
        {
            return this._433533921brushSizeRadiogroup;
        }// end function

        private function _SWMMO_RadioButton7_c() : RadioButton
        {
            var _loc_1:* = new RadioButton();
            _loc_1.label = "7";
            _loc_1.groupName = "brushSizeRadiogroup";
            _loc_1.addEventListener("click", this.___SWMMO_RadioButton7_click);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get GAMESTATE_ID_SPECIALIST_PANEL() : SpecialistPanel
        {
            return this._77996922GAMESTATE_ID_SPECIALIST_PANEL;
        }// end function

        private function _SWMMO_Avatar1_i() : Avatar
        {
            var _loc_1:Avatar = null;
            _loc_1 = new Avatar();
            this.GAMESTATE_ID_AVATAR = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("top", "0");
            _loc_1.setStyle("left", "0");
            _loc_1.id = "GAMESTATE_ID_AVATAR";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_AddChild61_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild61 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_DarkenPanel1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild61", this._SWMMO_AddChild61);
            return _loc_1;
        }// end function

        public function get mTileListDataProviderSetMode() : ArrayCollection
        {
            return this._143676367mTileListDataProviderSetMode;
        }// end function

        private function deactivateHandler(event:Event) : void
        {
            if (!this.DEACTIVATE_HANDLER_ACTIVE)
            {
                return;
            }
            this.mApplicationActive = false;
            this.DisableApplication();
            return;
        }// end function

        private function _SWMMO_AddChild8_i() : AddChild
        {
            var _loc_1:* = new AddChild();
            this._SWMMO_AddChild8 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_Panel2_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild8", this._SWMMO_AddChild8);
            return _loc_1;
        }// end function

        private function _SWMMO_MemoryMonitorPanel1_i() : MemoryMonitorPanel
        {
            var _loc_1:MemoryMonitorPanel = null;
            _loc_1 = new MemoryMonitorPanel();
            this.GAMESTATE_ID_MEMORY_MONITOR = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("top", "0");
            _loc_1.setStyle("right", "0");
            _loc_1.id = "GAMESTATE_ID_MEMORY_MONITOR";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __SectorListID_creationComplete(event:FlexEvent) : void
        {
            this.SectorListID_creationCompleteHandler(event);
            return;
        }// end function

        private function _SWMMO_AddChild19_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild19 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_Button23_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild19", this._SWMMO_AddChild19);
            return _loc_1;
        }// end function

        public function __EraseLandingZoneID_click(event:MouseEvent) : void
        {
            this.EraseLandingZoneID_clickHandler(event);
            return;
        }// end function

        private function _SWMMO_AddChild72_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild72 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_HintPointer1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild72", this._SWMMO_AddChild72);
            return _loc_1;
        }// end function

        public function __AssignGroupID_click(event:MouseEvent) : void
        {
            this.DepositGroupAssignedDepositClicked(event);
            return;
        }// end function

        public function set myCanvas(param1:Canvas) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1282310620myCanvas;
            if (_loc_2 !== param1)
            {
                this._1282310620myCanvas = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "myCanvas", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_DataGrid3_i() : DataGrid
        {
            var _loc_1:* = new DataGrid();
            this.UnitListDataID = _loc_1;
            _loc_1.y = 26;
            _loc_1.height = 228;
            _loc_1.editable = false;
            _loc_1.columns = [this._SWMMO_DataGridColumn7_c(), this._SWMMO_DataGridColumn8_c(), this._SWMMO_DataGridColumn9_c()];
            _loc_1.setStyle("left", "10");
            _loc_1.setStyle("right", "312");
            _loc_1.addEventListener("itemClick", this.__UnitListDataID_itemClick);
            _loc_1.id = "UnitListDataID";
            BindingManager.executeBindings(this, "UnitListDataID", this.UnitListDataID);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        protected function ExitEditor(event:Event) : void
        {
            return;
        }// end function

        private function _SWMMO_CheckBox9_i() : CheckBox
        {
            var _loc_1:* = new CheckBox();
            this.FILTER_BUILDING_undefined = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 95;
            _loc_1.label = "Undefined";
            _loc_1.setStyle("color", 0);
            _loc_1.setStyle("fontSize", 12);
            _loc_1.addEventListener("click", this.__FILTER_BUILDING_undefined_click);
            _loc_1.id = "FILTER_BUILDING_undefined";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __DepositGroupDataGrid_itemEditEnd(event:DataGridEvent) : void
        {
            this.DepositGroupItemEditEnd(event);
            return;
        }// end function

        public function set SingleDepositAmountLabelID(param1:Label) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._182712865SingleDepositAmountLabelID;
            if (_loc_2 !== param1)
            {
                this._182712865SingleDepositAmountLabelID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SingleDepositAmountLabelID", _loc_2, param1));
            }
            return;
        }// end function

        public function set GAMESTATE_ID_SPECIALIST_TRAVEL_PANEL(param1:SpecialistTravelPanel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._710490583GAMESTATE_ID_SPECIALIST_TRAVEL_PANEL;
            if (_loc_2 !== param1)
            {
                this._710490583GAMESTATE_ID_SPECIALIST_TRAVEL_PANEL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_SPECIALIST_TRAVEL_PANEL", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_TextInput3_i() : TextInput
        {
            var _loc_1:* = new TextInput();
            this.SingleDepositAmountTextBoxID = _loc_1;
            _loc_1.x = 154;
            _loc_1.y = 10;
            _loc_1.width = 30;
            _loc_1.text = "100";
            _loc_1.id = "SingleDepositAmountTextBoxID";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_SpecialistTravelPanel1_i() : SpecialistTravelPanel
        {
            var _loc_1:SpecialistTravelPanel = null;
            _loc_1 = new SpecialistTravelPanel();
            this.GAMESTATE_ID_SPECIALIST_TRAVEL_PANEL = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "GAMESTATE_ID_SPECIALIST_TRAVEL_PANEL";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_StarMenu1_i() : StarMenu
        {
            var _loc_1:StarMenu = null;
            _loc_1 = new StarMenu();
            this.GAMESTATE_ID_STAR_MENU = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.id = "GAMESTATE_ID_STAR_MENU";
            BindingManager.executeBindings(this, "GAMESTATE_ID_STAR_MENU", this.GAMESTATE_ID_STAR_MENU);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set GAMESTATE_ID_RESIDENCE_INFO_PANEL(param1:ResidenceInfoPanel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._2078777808GAMESTATE_ID_RESIDENCE_INFO_PANEL;
            if (_loc_2 !== param1)
            {
                this._2078777808GAMESTATE_ID_RESIDENCE_INFO_PANEL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_RESIDENCE_INFO_PANEL", _loc_2, param1));
            }
            return;
        }// end function

        private function mouseOut(event:MouseEvent) : void
        {
            if (this.mGeneralInterface == null)
            {
                return;
            }
            this.mGeneralInterface.MouseOut(event);
            return;
        }// end function

        public function set GAMESTATE_ID_MYSTERYBOX_PANEL(param1:MysteryBoxPanel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1730107957GAMESTATE_ID_MYSTERYBOX_PANEL;
            if (_loc_2 !== param1)
            {
                this._1730107957GAMESTATE_ID_MYSTERYBOX_PANEL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_MYSTERYBOX_PANEL", _loc_2, param1));
            }
            return;
        }// end function

        public function __FILTER_BUILDING_ALL_ID_click(event:MouseEvent) : void
        {
            this.FILTERLIST_ALL_ID_clickHandler(event);
            return;
        }// end function

        public function set GAMESTATE_ID_NEWS_WINDOW(param1:NewsWindow) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._802978248GAMESTATE_ID_NEWS_WINDOW;
            if (_loc_2 !== param1)
            {
                this._802978248GAMESTATE_ID_NEWS_WINDOW = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_NEWS_WINDOW", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_BuildingsList1_i() : BuildingsList
        {
            var _loc_1:BuildingsList = null;
            _loc_1 = new BuildingsList();
            this.GAMESTATE_ID_LIST_BASE_BUILDINGS = _loc_1;
            _loc_1.visible = false;
            _loc_1.id = "GAMESTATE_ID_LIST_BASE_BUILDINGS";
            BindingManager.executeBindings(this, "GAMESTATE_ID_LIST_BASE_BUILDINGS", this.GAMESTATE_ID_LIST_BASE_BUILDINGS);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_Button16_i() : Button
        {
            var _loc_1:* = new Button();
            this.SectorListCloseIDButton = _loc_1;
            _loc_1.x = 110.5;
            _loc_1.y = 169;
            _loc_1.label = "Close";
            _loc_1.height = 20;
            _loc_1.width = 71;
            _loc_1.labelPlacement = "left";
            _loc_1.addEventListener("click", this.__SectorListCloseIDButton_click);
            _loc_1.id = "SectorListCloseIDButton";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get btnStartGame() : Button
        {
            return this._1504873592btnStartGame;
        }// end function

        public function get GAMESTATE_ID_FRIENDS_LIST_MENU() : FriendsListMenu
        {
            return this._1059232882GAMESTATE_ID_FRIENDS_LIST_MENU;
        }// end function

        private function _SWMMO_CheckBox13_i() : CheckBox
        {
            var _loc_1:CheckBox = null;
            _loc_1 = new CheckBox();
            this.ID_DebugInfoPanelAdditionalDebugInfo = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 39;
            _loc_1.label = "Additional Debug Info";
            _loc_1.id = "ID_DebugInfoPanelAdditionalDebugInfo";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get GAMESTATE_ID_AVATAR() : Avatar
        {
            return this._345705597GAMESTATE_ID_AVATAR;
        }// end function

        public function set mTileListDataProviderGO(param1:ArrayCollection) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._132846140mTileListDataProviderGO;
            if (_loc_2 !== param1)
            {
                this._132846140mTileListDataProviderGO = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mTileListDataProviderGO", _loc_2, param1));
            }
            return;
        }// end function

        public function get FILTER_BUILDING_SortNames() : CheckBox
        {
            return this._1311028358FILTER_BUILDING_SortNames;
        }// end function

        public function get GAMESTATE_ID_HINT_POINTER() : HintPointer
        {
            return this._283820919GAMESTATE_ID_HINT_POINTER;
        }// end function

        public function set ReAssignSectorID(param1:TitleWindow) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._194875837ReAssignSectorID;
            if (_loc_2 !== param1)
            {
                this._194875837ReAssignSectorID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "ReAssignSectorID", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_ClassFactory1_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = cItemRendererTileList;
            return _loc_1;
        }// end function

        private function BrushSizeTextInputIdChanged() : void
        {
            return;
        }// end function

        private function DepositGroupItemClick(event:ListEvent) : void
        {
            return;
        }// end function

        private function _SWMMO_TileList2_i() : TileList
        {
            var _loc_1:* = new TileList();
            this.EDITORSTATE_ID_TILE_LIST_SET_MODE = _loc_1;
            _loc_1.width = 985;
            _loc_1.height = 92;
            _loc_1.alpha = 1;
            _loc_1.direction = "vertical";
            _loc_1.rowHeight = 80;
            _loc_1.columnWidth = 70;
            _loc_1.maxRows = 1;
            _loc_1.rowCount = 1;
            _loc_1.itemRenderer = this._SWMMO_ClassFactory2_c();
            _loc_1.liveScrolling = true;
            _loc_1.visible = true;
            _loc_1.setStyle("borderStyle", "solid");
            _loc_1.setStyle("borderThickness", 2);
            _loc_1.setStyle("cornerRadius", 20);
            _loc_1.setStyle("borderColor", 2462430);
            _loc_1.setStyle("bottom", "10");
            _loc_1.setStyle("right", "279");
            _loc_1.setStyle("fontSize", 8);
            _loc_1.setStyle("backgroundAlpha", 0.6);
            _loc_1.addEventListener("itemClick", this.__EDITORSTATE_ID_TILE_LIST_SET_MODE_itemClick);
            _loc_1.id = "EDITORSTATE_ID_TILE_LIST_SET_MODE";
            BindingManager.executeBindings(this, "EDITORSTATE_ID_TILE_LIST_SET_MODE", this.EDITORSTATE_ID_TILE_LIST_SET_MODE);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_RadioButton5_c() : RadioButton
        {
            var _loc_1:* = new RadioButton();
            _loc_1.label = "2";
            _loc_1.groupName = "brushSizeRadiogroup";
            _loc_1.addEventListener("click", this.___SWMMO_RadioButton5_click);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set GAMESTATE_ID_LIST_CL3_BUILDINGS(param1:BuildingsList) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1053263437GAMESTATE_ID_LIST_CL3_BUILDINGS;
            if (_loc_2 !== param1)
            {
                this._1053263437GAMESTATE_ID_LIST_CL3_BUILDINGS = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_LIST_CL3_BUILDINGS", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_SetProperty14_c() : SetProperty
        {
            var _loc_1:SetProperty = null;
            _loc_1 = new SetProperty();
            _loc_1.name = "verticalScrollPolicy";
            _loc_1.value = "off";
            return _loc_1;
        }// end function

        public function __ID_SHOW_DEBUG_INFO_PANEL_show(event:FlexEvent) : void
        {
            this.ID_SHOW_DEBUG_INFO_PANEL_showHandler(event);
            return;
        }// end function

        public function __SectorIdButton4_click(event:MouseEvent) : void
        {
            this.SectorIDNumberClicked(event);
            return;
        }// end function

        public function set GAMESTATE_ID_WAREHOUSE_INFO_PANEL(param1:WarehouseInfoPanel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._361154989GAMESTATE_ID_WAREHOUSE_INFO_PANEL;
            if (_loc_2 !== param1)
            {
                this._361154989GAMESTATE_ID_WAREHOUSE_INFO_PANEL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_WAREHOUSE_INFO_PANEL", _loc_2, param1));
            }
            return;
        }// end function

        public function set ResourceProductionWindow(param1:TitleWindow) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1034233257ResourceProductionWindow;
            if (_loc_2 !== param1)
            {
                this._1034233257ResourceProductionWindow = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "ResourceProductionWindow", _loc_2, param1));
            }
            return;
        }// end function

        public function set BrushSizeVBox(param1:VBox) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._646604368BrushSizeVBox;
            if (_loc_2 !== param1)
            {
                this._646604368BrushSizeVBox = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "BrushSizeVBox", _loc_2, param1));
            }
            return;
        }// end function

        public function registerGlobalKeyHandler() : void
        {
            stage.addEventListener(Event.ACTIVATE, this.activateHandler);
            stage.addEventListener(Event.DEACTIVATE, this.deactivateHandler);
            stage.addEventListener(Event.RESIZE, this.resizeHandler);
            stage.addEventListener(KeyboardEvent.KEY_DOWN, this.keyDown);
            stage.addEventListener(KeyboardEvent.KEY_UP, this.keyUp);
            stage.addEventListener(FocusEvent.FOCUS_OUT, this.FocusOutHandler);
            this.resizeHandler(null);
            this.SetApplicationWidthandHeight();
            systemManager.addEventListener(MouseEvent.MOUSE_WHEEL, this.mouseWheel);
            gInitStaticForAllZones.Init(this.SwitchState);
            return;
        }// end function

        public function get GAMESTATE_ID_CONSTRUCTION_INFO_PANEL() : ConstructionInfoPanel
        {
            return this._761777309GAMESTATE_ID_CONSTRUCTION_INFO_PANEL;
        }// end function

        public function __EDITORSTATE_ID_TILE_LIST_GO_itemClick(event:ListEvent) : void
        {
            this.mGeneralInterface.TileListGOClick(event);
            return;
        }// end function

        private function _SWMMO_AddChild6_i() : AddChild
        {
            var _loc_1:* = new AddChild();
            this._SWMMO_AddChild6 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_CheatWindow1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild6", this._SWMMO_AddChild6);
            return _loc_1;
        }// end function

        private function _SWMMO_BuildingInfoPanel1_i() : BuildingInfoPanel
        {
            var _loc_1:BuildingInfoPanel = null;
            _loc_1 = new BuildingInfoPanel();
            this.GAMESTATE_ID_BUILDING_INFO_PANEL = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("right", "100");
            _loc_1.setStyle("bottom", "180");
            _loc_1.id = "GAMESTATE_ID_BUILDING_INFO_PANEL";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set GAMESTATE_ID_DECORATION_INFO_PANEL(param1:DecorationInfoPanel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._193268130GAMESTATE_ID_DECORATION_INFO_PANEL;
            if (_loc_2 !== param1)
            {
                this._193268130GAMESTATE_ID_DECORATION_INFO_PANEL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_DECORATION_INFO_PANEL", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_DataGrid1_i() : DataGrid
        {
            var _loc_1:* = new DataGrid();
            this.DepositGroupDataGrid = _loc_1;
            _loc_1.width = 447;
            _loc_1.rowCount = 4;
            _loc_1.selectedIndex = 0;
            _loc_1.dragEnabled = true;
            _loc_1.editable = true;
            _loc_1.enabled = true;
            _loc_1.x = 10;
            _loc_1.columns = [this._SWMMO_DataGridColumn1_c(), this._SWMMO_DataGridColumn2_c(), this._SWMMO_DataGridColumn3_c(), this._SWMMO_DataGridColumn4_c()];
            _loc_1.setStyle("bottom", "44");
            _loc_1.setStyle("top", "10");
            _loc_1.addEventListener("creationComplete", this.__DepositGroupDataGrid_creationComplete);
            _loc_1.addEventListener("itemEditEnd", this.__DepositGroupDataGrid_itemEditEnd);
            _loc_1.addEventListener("itemClick", this.__DepositGroupDataGrid_itemClick);
            _loc_1.id = "DepositGroupDataGrid";
            BindingManager.executeBindings(this, "DepositGroupDataGrid", this.DepositGroupDataGrid);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function stopMoveWindow(event:MouseEvent) : void
        {
            return;
        }// end function

        private function _SWMMO_RadioButton12_i() : RadioButton
        {
            var _loc_1:* = new RadioButton();
            this.YellowBlockingRadioButtonID = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 30;
            _loc_1.label = "Yellow Blocking (Streets)";
            _loc_1.groupName = "radiogroupSetBlocking";
            _loc_1.selected = true;
            _loc_1.id = "YellowBlockingRadioButtonID";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get GroupDepositID() : Canvas
        {
            return this._1681376410GroupDepositID;
        }// end function

        private function _SWMMO_AddChild70_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild70 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_CameraControlPanel1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild70", this._SWMMO_AddChild70);
            return _loc_1;
        }// end function

        private function _SWMMO_CheckBox7_i() : CheckBox
        {
            var _loc_1:* = new CheckBox();
            this.FILTER_BUILDING_Decoration = _loc_1;
            _loc_1.x = 127;
            _loc_1.y = 76;
            _loc_1.label = "Decoration";
            _loc_1.setStyle("color", 0);
            _loc_1.setStyle("fontSize", 12);
            _loc_1.addEventListener("click", this.__FILTER_BUILDING_Decoration_click);
            _loc_1.id = "FILTER_BUILDING_Decoration";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_AddChild17_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild17 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_Label9_c);
            BindingManager.executeBindings(this, "_SWMMO_AddChild17", this._SWMMO_AddChild17);
            return _loc_1;
        }// end function

        public function get radiogroupSetBlocking() : RadioButtonGroup
        {
            return this._386188467radiogroupSetBlocking;
        }// end function

        private function _SWMMO_Label8_c() : Label
        {
            var _loc_1:* = new Label();
            _loc_1.x = 108;
            _loc_1.y = 10;
            _loc_1.text = "new Sector ID";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get GAMESTATE_ID_BUILDING_INFO_PANEL() : BuildingInfoPanel
        {
            return this._314430682GAMESTATE_ID_BUILDING_INFO_PANEL;
        }// end function

        public function ToggleShowSectorListWindow() : void
        {
            return;
        }// end function

        private function initXML() : void
        {
            cXML.init();
            var _loc_1:Boolean = true;
            if (_loc_1 && definesMaster.MASTER_VERSION == true && loaderInfo.hasOwnProperty("uncaughtErrorEvents"))
            {
                IEventDispatcher(loaderInfo["uncaughtErrorEvents"]).addEventListener("uncaughtError", this.uncaughtErrorHandler);
            }
            return;
        }// end function

        private function _SWMMO_TextInput1_i() : TextInput
        {
            var _loc_1:* = new TextInput();
            this.SectorIDInput = _loc_1;
            _loc_1.x = 85;
            _loc_1.y = 8;
            _loc_1.width = 75;
            _loc_1.text = "0";
            _loc_1.id = "SectorIDInput";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_AddChild28_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild28 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_CancelActionPanel1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild28", this._SWMMO_AddChild28);
            return _loc_1;
        }// end function

        public function __radiogroupOwnerShipfree_click(event:MouseEvent) : void
        {
            this.radiobuttonFree_clickHandler(event);
            return;
        }// end function

        private function _SWMMO_ResidenceInfoPanel1_i() : ResidenceInfoPanel
        {
            var _loc_1:ResidenceInfoPanel = null;
            _loc_1 = new ResidenceInfoPanel();
            this.GAMESTATE_ID_RESIDENCE_INFO_PANEL = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("right", "100");
            _loc_1.setStyle("bottom", "180");
            _loc_1.id = "GAMESTATE_ID_RESIDENCE_INFO_PANEL";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_Button14_i() : Button
        {
            var _loc_1:* = new Button();
            this.AssignUnitID = _loc_1;
            _loc_1.x = 273;
            _loc_1.y = 37;
            _loc_1.label = "Assign Unit";
            _loc_1.width = 101;
            _loc_1.addEventListener("click", this.__AssignUnitID_click);
            _loc_1.id = "AssignUnitID";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __SectorIdButton9_click(event:MouseEvent) : void
        {
            this.SectorIDNumberClicked(event);
            return;
        }// end function

        public function get FILTER_BUILDING_Minimal() : CheckBox
        {
            return this._712858845FILTER_BUILDING_Minimal;
        }// end function

        public function get btnStartGameDebug() : Button
        {
            return this._1665653573btnStartGameDebug;
        }// end function

        private function _SWMMO_CheckBox11_i() : CheckBox
        {
            var _loc_1:CheckBox = null;
            _loc_1 = new CheckBox();
            this.AutorefreshID = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 0;
            _loc_1.label = "Autorefresh";
            _loc_1.visible = true;
            _loc_1.width = 109;
            _loc_1.height = 23;
            _loc_1.enabled = true;
            _loc_1.selected = true;
            _loc_1.id = "AutorefreshID";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __FILTER_BUILDING_NONE_ID_click(event:MouseEvent) : void
        {
            this.FILTERLIST_NONE_ID_clickHandler(event);
            return;
        }// end function

        private function _SWMMO_SetProperty12_c() : SetProperty
        {
            var _loc_1:SetProperty = null;
            _loc_1 = new SetProperty();
            _loc_1.name = "minWidth";
            _loc_1.value = 600;
            return _loc_1;
        }// end function

        private function _SWMMO_Panel3_i() : Panel
        {
            var _loc_1:Panel = null;
            _loc_1 = new Panel();
            this.ID_SHOW_DEBUG_INFO_PANEL = _loc_1;
            _loc_1.x = 742;
            _loc_1.y = 116;
            _loc_1.width = 253;
            _loc_1.height = 329;
            _loc_1.layout = "absolute";
            _loc_1.visible = false;
            _loc_1.title = "Debug Info Panel";
            _loc_1.addEventListener("hide", this.__ID_SHOW_DEBUG_INFO_PANEL_hide);
            _loc_1.addEventListener("show", this.__ID_SHOW_DEBUG_INFO_PANEL_show);
            _loc_1.addEventListener("click", this.__ID_SHOW_DEBUG_INFO_PANEL_click);
            _loc_1.id = "ID_SHOW_DEBUG_INFO_PANEL";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SWMMO_CheckBox12_i());
            _loc_1.addChild(this._SWMMO_CheckBox13_i());
            _loc_1.addChild(this._SWMMO_CheckBox14_i());
            _loc_1.addChild(this._SWMMO_CheckBox15_i());
            _loc_1.addChild(this._SWMMO_CheckBox16_i());
            _loc_1.addChild(this._SWMMO_CheckBox17_i());
            _loc_1.addChild(this._SWMMO_CheckBox18_i());
            _loc_1.addChild(this._SWMMO_CheckBox19_i());
            _loc_1.addChild(this._SWMMO_CheckBox20_i());
            return _loc_1;
        }// end function

        private function _SWMMO_AddChild39_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild39 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_SpecialistCooldownPanel1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild39", this._SWMMO_AddChild39);
            return _loc_1;
        }// end function

        public function set GAMESTATE_ID_DAILY_LOGIN_PANEL(param1:DailyLoginPanel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1395871100GAMESTATE_ID_DAILY_LOGIN_PANEL;
            if (_loc_2 !== param1)
            {
                this._1395871100GAMESTATE_ID_DAILY_LOGIN_PANEL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_DAILY_LOGIN_PANEL", _loc_2, param1));
            }
            return;
        }// end function

        public function get EDITORSTATE_ID_TILE_LIST_SET_MODE() : TileList
        {
            return this._1892912377EDITORSTATE_ID_TILE_LIST_SET_MODE;
        }// end function

        private function uncaughtErrorHandler(event:Event) : void
        {
            if (int(event["error"]["errorID"]) == 1009 && String(event["error"]["name"]) == "TypeError")
            {
                return;
            }
            cClientMessagesII.LogMessageToBigBrother(event);
            event.preventDefault();
            return;
        }// end function

        private function _SWMMO_Button25_i() : Button
        {
            var _loc_1:Button = null;
            _loc_1 = new Button();
            this.btnStartGameDebug = _loc_1;
            _loc_1.y = 403;
            _loc_1.label = "Start Game (Debug Settings)";
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.addEventListener("click", this.__btnStartGameDebug_click);
            _loc_1.id = "btnStartGameDebug";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get GAMESTATE_ID_CHEAT_WINDOW() : CheatWindow
        {
            return this._1283861792GAMESTATE_ID_CHEAT_WINDOW;
        }// end function

        private function _SWMMO_RadioButton3_i() : RadioButton
        {
            var _loc_1:* = new RadioButton();
            this.EraseLandingZoneID = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 208;
            _loc_1.label = "EraseLandingZone";
            _loc_1.groupName = "SectorLandingZoneRadioButtonGroup";
            _loc_1.addEventListener("click", this.__EraseLandingZoneID_click);
            _loc_1.id = "EraseLandingZoneID";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __btnStartGameDebug_click(event:MouseEvent) : void
        {
            this.StartGameDebugClicked(event);
            return;
        }// end function

        public function set ID_DebugInfoPanelShowPlayerInfo(param1:CheckBox) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._338299245ID_DebugInfoPanelShowPlayerInfo;
            if (_loc_2 !== param1)
            {
                this._338299245ID_DebugInfoPanelShowPlayerInfo = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "ID_DebugInfoPanelShowPlayerInfo", _loc_2, param1));
            }
            return;
        }// end function

        public function set GAMESTATE_ID_AVATAR_MESSAGE_LIST(param1:AvatarMessageList) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._270958984GAMESTATE_ID_AVATAR_MESSAGE_LIST;
            if (_loc_2 !== param1)
            {
                this._270958984GAMESTATE_ID_AVATAR_MESSAGE_LIST = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_AVATAR_MESSAGE_LIST", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_TitleWindow6_i() : TitleWindow
        {
            var _loc_1:* = new TitleWindow();
            this.SetBlockingWindowID = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 308;
            _loc_1.width = 198;
            _loc_1.height = 105;
            _loc_1.layout = "absolute";
            _loc_1.title = "Set Blocking Type";
            _loc_1.visible = false;
            _loc_1.id = "SetBlockingWindowID";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SWMMO_RadioButton12_i());
            _loc_1.addChild(this._SWMMO_RadioButton13_i());
            return _loc_1;
        }// end function

        public function get AssignedUnitID() : DataGrid
        {
            return this._1087128877AssignedUnitID;
        }// end function

        private function get mSectorListData() : ArrayCollection
        {
            return this._1320391867mSectorListData;
        }// end function

        private function _SWMMO_AddChild4_i() : AddChild
        {
            var _loc_1:* = new AddChild();
            this._SWMMO_AddChild4 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_Panel1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild4", this._SWMMO_AddChild4);
            return _loc_1;
        }// end function

        public function set GAMESTATE_ID_TIMED_PRODUCTION_INFO_PANEL(param1:TimedProductionInfoPanel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1726370163GAMESTATE_ID_TIMED_PRODUCTION_INFO_PANEL;
            if (_loc_2 !== param1)
            {
                this._1726370163GAMESTATE_ID_TIMED_PRODUCTION_INFO_PANEL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_TIMED_PRODUCTION_INFO_PANEL", _loc_2, param1));
            }
            return;
        }// end function

        public function get GAMESTATE_ID_WATCHTOWER_INFO_PANEL() : WatchTowerInfoPanel
        {
            return this._1267151564GAMESTATE_ID_WATCHTOWER_INFO_PANEL;
        }// end function

        public function get SingleDepositID() : Canvas
        {
            return this._754674511SingleDepositID;
        }// end function

        public function set YellowBlockingRadioButtonID(param1:RadioButton) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._154230399YellowBlockingRadioButtonID;
            if (_loc_2 !== param1)
            {
                this._154230399YellowBlockingRadioButtonID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "YellowBlockingRadioButtonID", _loc_2, param1));
            }
            return;
        }// end function

        private function creationComplete() : void
        {
            this.mIsDebugPlayer = isDebugPlayer();
            this.mIsDebugBuild = isDebugBuild();
            return;
        }// end function

        public function set ReAssignSectorIDCancel(param1:Button) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._528971107ReAssignSectorIDCancel;
            if (_loc_2 !== param1)
            {
                this._528971107ReAssignSectorIDCancel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "ReAssignSectorIDCancel", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_AddChild15_i() : AddChild
        {
            var _loc_1:* = new AddChild();
            this._SWMMO_AddChild15 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_Canvas3_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild15", this._SWMMO_AddChild15);
            return _loc_1;
        }// end function

        public function get ID_DebugInfoPanelShowSettlerDebugInfo() : CheckBox
        {
            return this._142638398ID_DebugInfoPanelShowSettlerDebugInfo;
        }// end function

        private function _SWMMO_RadioButton10_i() : RadioButton
        {
            var _loc_1:* = new RadioButton();
            this.radiogroupOwnerShipBanditCamp = _loc_1;
            _loc_1.label = "BanditCamp";
            _loc_1.groupName = "radiogroupOwnerShip";
            _loc_1.x = 10;
            _loc_1.y = 61;
            _loc_1.height = 27;
            _loc_1.addEventListener("click", this.__radiogroupOwnerShipBanditCamp_click);
            _loc_1.id = "radiogroupOwnerShipBanditCamp";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        protected function rewardOkbutton_clickHandler(event:MouseEvent) : void
        {
            return;
        }// end function

        private function GetLastMouseOverCanvas() : Boolean
        {
            return this.mCanvasFocused;
        }// end function

        private function _SWMMO_CheckBox5_i() : CheckBox
        {
            var _loc_1:* = new CheckBox();
            this.FILTER_BUILDING_Residence = _loc_1;
            _loc_1.x = 176;
            _loc_1.y = 57;
            _loc_1.label = "Residence";
            _loc_1.setStyle("color", 0);
            _loc_1.setStyle("fontSize", 12);
            _loc_1.addEventListener("click", this.__FILTER_BUILDING_Residence_click);
            _loc_1.id = "FILTER_BUILDING_Residence";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_FriendsListMenu1_i() : FriendsListMenu
        {
            var _loc_1:FriendsListMenu = null;
            _loc_1 = new FriendsListMenu();
            this.GAMESTATE_ID_FRIENDS_LIST_MENU = _loc_1;
            _loc_1.visible = false;
            _loc_1.id = "GAMESTATE_ID_FRIENDS_LIST_MENU";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __ReAssignSectorIDCancel_click(event:MouseEvent) : void
        {
            this.ReAssignSectorIDCancel_clickHandler(event);
            return;
        }// end function

        public function get GAMESTATE_ID_LIST_BASE_BUILDINGS() : BuildingsList
        {
            return this._1209783630GAMESTATE_ID_LIST_BASE_BUILDINGS;
        }// end function

        public function get blueFireComponent() : BlueFireComponent
        {
            return this._1792787757blueFireComponent;
        }// end function

        private function _SWMMO_DataGridColumn18_c() : DataGridColumn
        {
            var _loc_1:DataGridColumn = null;
            _loc_1 = new DataGridColumn();
            _loc_1.headerText = "Max Limit";
            _loc_1.dataField = "maxlimit";
            return _loc_1;
        }// end function

        public function get oldSectorIDTextInput() : TextInput
        {
            return this._1559728843oldSectorIDTextInput;
        }// end function

        private function _SWMMO_Label6_c() : Label
        {
            var _loc_1:* = new Label();
            _loc_1.x = 379.5;
            _loc_1.y = 0;
            _loc_1.text = "Assigned Units";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function keyUp(event:KeyboardEvent) : void
        {
            if (this.mGeneralInterface == null)
            {
                return;
            }
            this.mGeneralInterface.KeyUp(event);
            return;
        }// end function

        private function _SWMMO_AddChild26_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild26 = _loc_1;
            _loc_1.position = "lastChild";
            BindingManager.executeBindings(this, "_SWMMO_AddChild26", this._SWMMO_AddChild26);
            return _loc_1;
        }// end function

        public function get SectorListID() : TitleWindow
        {
            return this._85130591SectorListID;
        }// end function

        public function get SetSectorID() : RadioButton
        {
            return this._310338915SetSectorID;
        }// end function

        public function DisableApplication() : void
        {
            if (this.mGeneralInterface != null)
            {
                this.mGeneralInterface.mComputeAndInputActive = false;
            }
            return;
        }// end function

        public function __FILTER_BUILDING_Decoration_click(event:MouseEvent) : void
        {
            this.FILTER_BUILDING_clickHandler(event);
            return;
        }// end function

        public function set FILTER_BUILDING_Timedproduction(param1:CheckBox) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1810592364FILTER_BUILDING_Timedproduction;
            if (_loc_2 !== param1)
            {
                this._1810592364FILTER_BUILDING_Timedproduction = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "FILTER_BUILDING_Timedproduction", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_Button12_i() : Button
        {
            var _loc_1:* = new Button();
            this.DeletegroupID = _loc_1;
            _loc_1.label = "Deletegroup";
            _loc_1.x = 291;
            _loc_1.visible = true;
            _loc_1.enabled = true;
            _loc_1.setStyle("bottom", "15");
            _loc_1.addEventListener("click", this.__DeletegroupID_click);
            _loc_1.id = "DeletegroupID";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_ActionBar1_i() : ActionBar
        {
            var _loc_1:ActionBar = null;
            _loc_1 = new ActionBar();
            this.GAMESTATE_ID_ACTIONBAR = _loc_1;
            _loc_1.visible = false;
            _loc_1.id = "GAMESTATE_ID_ACTIONBAR";
            BindingManager.executeBindings(this, "GAMESTATE_ID_ACTIONBAR", this.GAMESTATE_ID_ACTIONBAR);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __AssignUnitID_click(event:MouseEvent) : void
        {
            this.AssignUnitID_clickHandler(event);
            return;
        }// end function

        public function get ID_SHOW_DEBUG_INFO_PANEL() : Panel
        {
            return this._374144381ID_SHOW_DEBUG_INFO_PANEL;
        }// end function

        public function set ID_DebugInfoPanelShowAll(param1:CheckBox) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1859197251ID_DebugInfoPanelShowAll;
            if (_loc_2 !== param1)
            {
                this._1859197251ID_DebugInfoPanelShowAll = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "ID_DebugInfoPanelShowAll", _loc_2, param1));
            }
            return;
        }// end function

        public function set RedBlockingRadioButtonID(param1:RadioButton) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._585034434RedBlockingRadioButtonID;
            if (_loc_2 !== param1)
            {
                this._585034434RedBlockingRadioButtonID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "RedBlockingRadioButtonID", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_CheckBox20_i() : CheckBox
        {
            var _loc_1:CheckBox = null;
            _loc_1 = new CheckBox();
            this.ID_DebugInfoPanelShowSettlerDebugInfo = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 242;
            _loc_1.label = "Settler Debug Info";
            _loc_1.id = "ID_DebugInfoPanelShowSettlerDebugInfo";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_SetProperty10_c() : SetProperty
        {
            var _loc_1:SetProperty = null;
            _loc_1 = new SetProperty();
            _loc_1.name = "height";
            _loc_1.value = "100%";
            return _loc_1;
        }// end function

        private function _SWMMO_AddChild37_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild37 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_DecorationInfoPanel1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild37", this._SWMMO_AddChild37);
            return _loc_1;
        }// end function

        private function click(event:MouseEvent) : void
        {
            if (this.mGeneralInterface == null)
            {
                return;
            }
            if (this.mIgnoreNextClick)
            {
                this.mIgnoreNextClick = false;
                return;
            }
            if (this.IsMouseOverCanvas(event))
            {
                this.mGeneralInterface.MouseClick(event);
            }
            return;
        }// end function

        public function __RemoveUnitID_click(event:MouseEvent) : void
        {
            this.RemoveUnitID_clickHandler(event);
            return;
        }// end function

        private function _SWMMO_Button23_i() : Button
        {
            var _loc_1:Button = null;
            _loc_1 = new Button();
            this.btnStartGame = _loc_1;
            _loc_1.y = 276;
            _loc_1.label = "Start Game";
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.addEventListener("click", this.__btnStartGame_click);
            _loc_1.id = "btnStartGame";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set DepositGroupWindowID(param1:TabNavigator) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1808756020DepositGroupWindowID;
            if (_loc_2 !== param1)
            {
                this._1808756020DepositGroupWindowID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "DepositGroupWindowID", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_Panel1_i() : Panel
        {
            var _loc_1:* = new Panel();
            this.EDITORSTATE_ApplicationActivated = _loc_1;
            _loc_1.x = 317.5;
            _loc_1.y = 195;
            _loc_1.width = 432;
            _loc_1.height = 258;
            _loc_1.layout = "absolute";
            _loc_1.enabled = false;
            _loc_1.visible = false;
            _loc_1.id = "EDITORSTATE_ApplicationActivated";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SWMMO_Text1_i());
            _loc_1.addChild(this._SWMMO_Text2_i());
            return _loc_1;
        }// end function

        public function __AssignedUnitID_itemClick(event:ListEvent) : void
        {
            this.AssignedUnitID_itemClickHandler(event);
            return;
        }// end function

        private function _SWMMO_AddChild48_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild48 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_AddFriendsPanel1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild48", this._SWMMO_AddChild48);
            return _loc_1;
        }// end function

        private function SwitchState(event:Event) : void
        {
            currentState = global.GAME_STATE;
            gInitStaticForAllZones.ClearScreen();
            return;
        }// end function

        private function _SWMMO_RadioButton1_i() : RadioButton
        {
            var _loc_1:* = new RadioButton();
            this.SetSectorID = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 153;
            _loc_1.label = "SetSector";
            _loc_1.groupName = "SectorLandingZoneRadioButtonGroup";
            _loc_1.selected = true;
            _loc_1.addEventListener("click", this.__SetSectorID_click);
            _loc_1.id = "SetSectorID";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function ___SWMMO_RadioButton8_click(event:MouseEvent) : void
        {
            this.UpdateBrushSizeRadioButtons();
            return;
        }// end function

        public function set GAMESTATE_ID_MAIL_WINDOW(param1:MailWindow) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1999815380GAMESTATE_ID_MAIL_WINDOW;
            if (_loc_2 !== param1)
            {
                this._1999815380GAMESTATE_ID_MAIL_WINDOW = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_MAIL_WINDOW", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_TitleWindow4_i() : TitleWindow
        {
            var _loc_1:* = new TitleWindow();
            this.SectorListID = _loc_1;
            _loc_1.width = 300;
            _loc_1.height = 239;
            _loc_1.layout = "absolute";
            _loc_1.title = "Sector List";
            _loc_1.visible = false;
            _loc_1.setStyle("left", "100");
            _loc_1.setStyle("top", "30");
            _loc_1.addEventListener("creationComplete", this.__SectorListID_creationComplete);
            _loc_1.id = "SectorListID";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SWMMO_DataGrid4_i());
            _loc_1.addChild(this._SWMMO_Button16_i());
            return _loc_1;
        }// end function

        public function set GAMESTATE_ID_TRACKED_MISSION_LIST(param1:TrackedMissionList) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._2063705802GAMESTATE_ID_TRACKED_MISSION_LIST;
            if (_loc_2 !== param1)
            {
                this._2063705802GAMESTATE_ID_TRACKED_MISSION_LIST = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_TRACKED_MISSION_LIST", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_AddChild2_i() : AddChild
        {
            var _loc_1:* = new AddChild();
            this._SWMMO_AddChild2 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_List1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild2", this._SWMMO_AddChild2);
            return _loc_1;
        }// end function

        protected function radiobuttonBanditCamp_clickHandler(event:MouseEvent) : void
        {
            return;
        }// end function

        private function mouseWheel(event:MouseEvent) : void
        {
            if (this.mGeneralInterface == null)
            {
                return;
            }
            if (this.IsMouseOverCanvas(event))
            {
                this.mGeneralInterface.MouseWheel(event);
            }
            return;
        }// end function

        public function __EDITORSTATE_btnEditor_click(event:MouseEvent) : void
        {
            this.StartEditorClicked(event);
            return;
        }// end function

        public function set newSectorIDTextInput(param1:TextInput) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1299074340newSectorIDTextInput;
            if (_loc_2 !== param1)
            {
                this._1299074340newSectorIDTextInput = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "newSectorIDTextInput", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_AddChild13_i() : AddChild
        {
            var _loc_1:* = new AddChild();
            this._SWMMO_AddChild13 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_TitleWindow5_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild13", this._SWMMO_AddChild13);
            return _loc_1;
        }// end function

        private function _SWMMO_AdventurePanel1_i() : AdventurePanel
        {
            var _loc_1:AdventurePanel = null;
            _loc_1 = new AdventurePanel();
            this.GAMESTATE_ID_ADVENTURE_PANEL = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "GAMESTATE_ID_ADVENTURE_PANEL";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_AddChild59_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild59 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_SpecialistPanel1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild59", this._SWMMO_AddChild59);
            return _loc_1;
        }// end function

        public function ___SWMMO_State1_exitState(event:FlexEvent) : void
        {
            this.ExitEditor(event);
            return;
        }// end function

        private function _SWMMO_DataGridColumn9_c() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            _loc_1.headerText = "Damage";
            _loc_1.dataField = "UnitDamage";
            return _loc_1;
        }// end function

        private function _SWMMO_CheckBox3_i() : CheckBox
        {
            var _loc_1:* = new CheckBox();
            this.FILTER_BUILDING_None = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 37;
            _loc_1.label = "None";
            _loc_1.setStyle("color", 0);
            _loc_1.setStyle("fontSize", 12);
            _loc_1.addEventListener("click", this.__FILTER_BUILDING_None_click);
            _loc_1.id = "FILTER_BUILDING_None";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_ConstructionInfoPanel1_i() : ConstructionInfoPanel
        {
            var _loc_1:ConstructionInfoPanel = null;
            _loc_1 = new ConstructionInfoPanel();
            this.GAMESTATE_ID_CONSTRUCTION_INFO_PANEL = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("right", "100");
            _loc_1.setStyle("bottom", "180");
            _loc_1.id = "GAMESTATE_ID_CONSTRUCTION_INFO_PANEL";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_Label4_c() : Label
        {
            var _loc_1:* = new Label();
            _loc_1.x = 10;
            _loc_1.y = 138;
            _loc_1.text = "UpgradeLevel";
            _loc_1.height = 23;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get mMemoryMonitor() : gMemoryMonitor
        {
            return this._267857324mMemoryMonitor;
        }// end function

        protected function ID_SHOW_DEBUG_INFO_PANEL_showHandler(event:FlexEvent) : void
        {
            this.ID_DebugInfoPanelShowAll.selected = this.mGeneralInterface.SHOW_DEBUG_TEXT;
            this.ID_DebugInfoPanelAdditionalDebugInfo.selected = this.mGeneralInterface.mShowAdditionalDebugInfo;
            this.ID_DebugInfoPanelShowFPS.selected = this.mGeneralInterface.mOnScreenFps;
            this.ID_DebugInfoPanelShowPlayerInfo.selected = this.mGeneralInterface.mShowOnScreenInfoPlayer;
            this.ID_DebugInfoPanelShowOnScreenGameTickCommands.selected = this.mGeneralInterface.mShowOnScreenInfoGameTickCommands;
            this.ID_DebugInfoPanelShowQuestInfo.selected = this.mGeneralInterface.mShowOnScreenInfoQuest;
            this.ID_DebugInfoPanelShowErrorLog.selected = this.mGeneralInterface.mShowIngameErrorLog;
            this.ID_DebugInfoPanelShowDetailErrorLog.selected = this.mGeneralInterface.mShowIngameDetailErrorLog;
            this.ID_DebugInfoPanelShowSettlerDebugInfo.selected = this.mGeneralInterface.mCurrentPlayerZone.mSettlerKIManager.ACTIVATE_SETTLER_DEBUG_INFO;
            return;
        }// end function

        public function set mCheatBoxtDataProvider(param1:ArrayCollection) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._139379434mCheatBoxtDataProvider;
            if (_loc_2 !== param1)
            {
                this._139379434mCheatBoxtDataProvider = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mCheatBoxtDataProvider", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_Button8_i() : Button
        {
            var _loc_1:* = new Button();
            this.SectorIdButton7 = _loc_1;
            _loc_1.x = 11;
            _loc_1.y = 41;
            _loc_1.label = "7";
            _loc_1.width = 43;
            _loc_1.height = 20;
            _loc_1.addEventListener("click", this.__SectorIdButton7_click);
            _loc_1.id = "SectorIdButton7";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set FILTER_BUILDING_NONE_ID(param1:Button) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._825365214FILTER_BUILDING_NONE_ID;
            if (_loc_2 !== param1)
            {
                this._825365214FILTER_BUILDING_NONE_ID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "FILTER_BUILDING_NONE_ID", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_AddChild24_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild24 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_Label13_c);
            BindingManager.executeBindings(this, "_SWMMO_AddChild24", this._SWMMO_AddChild24);
            return _loc_1;
        }// end function

        public function __AddgroupID_click(event:MouseEvent) : void
        {
            this.DepositGroupAddGroupClicked(event);
            return;
        }// end function

        private function _SWMMO_DataGridColumn16_c() : DataGridColumn
        {
            var _loc_1:DataGridColumn = null;
            _loc_1 = new DataGridColumn();
            _loc_1.headerText = "Type";
            _loc_1.dataField = "type";
            return _loc_1;
        }// end function

        public function get EDITORSTATE_focusID() : List
        {
            return this._394601000EDITORSTATE_focusID;
        }// end function

        private function CheatBoxChange() : void
        {
            return;
        }// end function

        public function get FILTER_BUILDING_INVERT_ID0() : Button
        {
            return this._1041187408FILTER_BUILDING_INVERT_ID0;
        }// end function

        public function ___SWMMO_State4_exitState(event:FlexEvent) : void
        {
            this.ExitGame(event);
            return;
        }// end function

        public function get FILTER_BUILDING_workyard() : CheckBox
        {
            return this._1954153967FILTER_BUILDING_workyard;
        }// end function

        protected function AssignUnitID_clickHandler(event:MouseEvent) : void
        {
            return;
        }// end function

        public function set GAMESTATE_ID_TAVERN_INFO_PANEL(param1:TavernInfoPanel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1887414006GAMESTATE_ID_TAVERN_INFO_PANEL;
            if (_loc_2 !== param1)
            {
                this._1887414006GAMESTATE_ID_TAVERN_INFO_PANEL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_TAVERN_INFO_PANEL", _loc_2, param1));
            }
            return;
        }// end function

        protected function SetSectorID_clickHandler(event:MouseEvent) : void
        {
            return;
        }// end function

        private function _SWMMO_AddChild35_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild35 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_TrackedMissionList1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild35", this._SWMMO_AddChild35);
            return _loc_1;
        }// end function

        public function get ID_DebugInfoPanelShowFPS() : CheckBox
        {
            return this._1859193339ID_DebugInfoPanelShowFPS;
        }// end function

        private function _SWMMO_VBox1_i() : VBox
        {
            var _loc_1:* = new VBox();
            this.BrushSizeVBox = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 20;
            _loc_1.height = 133;
            _loc_1.width = 42;
            _loc_1.label = "Brush Size";
            _loc_1.setStyle("horizontalAlign", "center");
            _loc_1.setStyle("verticalAlign", "middle");
            _loc_1.setStyle("verticalGap", 0);
            _loc_1.id = "BrushSizeVBox";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SWMMO_RadioButton4_c());
            _loc_1.addChild(this._SWMMO_RadioButton5_c());
            _loc_1.addChild(this._SWMMO_RadioButton6_c());
            _loc_1.addChild(this._SWMMO_RadioButton7_c());
            _loc_1.addChild(this._SWMMO_RadioButton8_c());
            return _loc_1;
        }// end function

        public function get EDITORSTATE_PressoktocontinueId() : Text
        {
            return this._620159487EDITORSTATE_PressoktocontinueId;
        }// end function

        private function _SWMMO_Button21_i() : Button
        {
            var _loc_1:* = new Button();
            this.FILTER_BUILDING_INVERT_ID0 = _loc_1;
            _loc_1.x = 152;
            _loc_1.y = 10;
            _loc_1.label = "Invert";
            _loc_1.width = 71;
            _loc_1.height = 19;
            _loc_1.setStyle("fontSize", 12);
            _loc_1.setStyle("color", 0);
            _loc_1.addEventListener("click", this.__FILTER_BUILDING_INVERT_ID0_click);
            _loc_1.id = "FILTER_BUILDING_INVERT_ID0";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __FILTER_BUILDING_INVERT_ID0_click(event:MouseEvent) : void
        {
            this.FILTERLIST_INVERT_ID0_clickHandler(event);
            return;
        }// end function

        private function _SWMMO_AddChild46_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild46 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_WarehouseInfoPanel1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild46", this._SWMMO_AddChild46);
            return _loc_1;
        }// end function

        private function _SWMMO_Button10_i() : Button
        {
            var _loc_1:* = new Button();
            this.SectorIdButton9 = _loc_1;
            _loc_1.x = 113;
            _loc_1.y = 41;
            _loc_1.label = "9";
            _loc_1.width = 43;
            _loc_1.height = 20;
            _loc_1.addEventListener("click", this.__SectorIdButton9_click);
            _loc_1.id = "SectorIdButton9";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_SpecialistPanel1_i() : SpecialistPanel
        {
            var _loc_1:SpecialistPanel = null;
            _loc_1 = new SpecialistPanel();
            this.GAMESTATE_ID_SPECIALIST_PANEL = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "GAMESTATE_ID_SPECIALIST_PANEL";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_CheatWindow2_i() : CheatWindow
        {
            var _loc_1:CheatWindow = null;
            _loc_1 = new CheatWindow();
            this.GAMESTATE_ID_CHEAT_WINDOW = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("right", "4");
            _loc_1.setStyle("top", "40");
            _loc_1.id = "GAMESTATE_ID_CHEAT_WINDOW";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_TitleWindow2_i() : TitleWindow
        {
            var _loc_1:* = new TitleWindow();
            this.SelectBuildingWindowID = _loc_1;
            _loc_1.width = 172;
            _loc_1.height = 211;
            _loc_1.layout = "absolute";
            _loc_1.visible = false;
            _loc_1.setStyle("left", "10");
            _loc_1.setStyle("bottom", "117");
            _loc_1.id = "SelectBuildingWindowID";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SWMMO_RadioButton9_i());
            _loc_1.addChild(this._SWMMO_RadioButton10_i());
            _loc_1.addChild(this._SWMMO_RadioButton11_i());
            _loc_1.addChild(this._SWMMO_Label3_c());
            _loc_1.addChild(this._SWMMO_Label4_c());
            _loc_1.addChild(this._SWMMO_TextInput4_i());
            return _loc_1;
        }// end function

        public function __SectorIdButton2_click(event:MouseEvent) : void
        {
            this.SectorIDNumberClicked(event);
            return;
        }// end function

        public function get GAMESTATE_ID_SPECIALIST_TRAVEL_PANEL() : SpecialistTravelPanel
        {
            return this._710490583GAMESTATE_ID_SPECIALIST_TRAVEL_PANEL;
        }// end function

        private function _SWMMO_AddChild11_i() : AddChild
        {
            var _loc_1:* = new AddChild();
            this._SWMMO_AddChild11 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_TitleWindow3_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild11", this._SWMMO_AddChild11);
            return _loc_1;
        }// end function

        private function _SWMMO_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.myCanvas;
            _loc_1 = this.mTileListDataProviderGO;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.menuBarCollection;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.mTileListDataProviderSetMode;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.mDepositGroupData;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.mAssignUnitsData;
            _loc_1 = this.mUnitListData;
            _loc_1 = this.myCanvas;
            _loc_1 = this.mSectorListData;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.label1;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.GAMESTATE_ID_FRIENDS_LIST.height;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.GAMESTATE_ID_AVATAR.width - 5;
            _loc_1 = this.myCanvas;
            _loc_1 = this.GAMESTATE_ID_FRIENDS_LIST.height;
            _loc_1 = this.myCanvas;
            _loc_1 = this.GAMESTATE_ID_ACTIONBAR.y + this.GAMESTATE_ID_ACTIONBAR.height;
            _loc_1 = this.myCanvas;
            _loc_1 = this.GAMESTATE_ID_BUILD_QUEUE.height;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "CL01Buildings");
            _loc_1 = this.GAMESTATE_ID_ACTIONBAR.getAnchorX(this.GAMESTATE_ID_ACTIONBAR.actionBarLeft.btnActionBar01) - this.GAMESTATE_ID_LIST_BASE_BUILDINGS.width / 2;
            _loc_1 = this.GAMESTATE_ID_ACTIONBAR.y - this.GAMESTATE_ID_LIST_BASE_BUILDINGS.height;
            _loc_1 = this.myCanvas;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "CL2Buildings");
            _loc_1 = this.GAMESTATE_ID_ACTIONBAR.getAnchorX(this.GAMESTATE_ID_ACTIONBAR.actionBarLeft.btnActionBar02) - this.GAMESTATE_ID_LIST_CL01_BUILDINGS.width / 2;
            _loc_1 = this.GAMESTATE_ID_ACTIONBAR.y - this.GAMESTATE_ID_LIST_CL01_BUILDINGS.height;
            _loc_1 = this.myCanvas;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "CL3Buildings");
            _loc_1 = this.GAMESTATE_ID_ACTIONBAR.getAnchorX(this.GAMESTATE_ID_ACTIONBAR.actionBarLeft.btnActionBar03) - this.GAMESTATE_ID_LIST_CL2_BUILDINGS.width / 2;
            _loc_1 = this.GAMESTATE_ID_ACTIONBAR.y - this.GAMESTATE_ID_LIST_CL2_BUILDINGS.height;
            _loc_1 = this.myCanvas;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "CLSBuildings");
            _loc_1 = this.GAMESTATE_ID_ACTIONBAR.getAnchorX(this.GAMESTATE_ID_ACTIONBAR.actionBarLeft.btnActionBar04) - this.GAMESTATE_ID_LIST_CL3_BUILDINGS.width / 2;
            _loc_1 = this.GAMESTATE_ID_ACTIONBAR.y - this.GAMESTATE_ID_LIST_CL3_BUILDINGS.height;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = int((Application.application.height - 350) / 2);
            _loc_1 = this.myCanvas;
            _loc_1 = this.GAMESTATE_ID_FRIENDS_LIST.height + 100;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.myCanvas;
            _loc_1 = this.mResourceProductionWindowDataGridDataProvider;
            _loc_1 = this.myCanvas;
            return;
        }// end function

        private function _SWMMO_AddChild57_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild57 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_TradingPanel1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild57", this._SWMMO_AddChild57);
            return _loc_1;
        }// end function

        public function get ReAssignSectorID() : TitleWindow
        {
            return this._194875837ReAssignSectorID;
        }// end function

        private function _SWMMO_CheckBox1_i() : CheckBox
        {
            var _loc_1:* = new CheckBox();
            this.FILTER_BUILDING_workyard = _loc_1;
            _loc_1.x = 82;
            _loc_1.y = 37;
            _loc_1.label = "Workyard";
            _loc_1.setStyle("color", 0);
            _loc_1.setStyle("fontSize", 12);
            _loc_1.addEventListener("click", this.__FILTER_BUILDING_workyard_click);
            _loc_1.id = "FILTER_BUILDING_workyard";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get myCanvas() : Canvas
        {
            return this._1282310620myCanvas;
        }// end function

        public function get FILTER_BUILDING_Enemy() : CheckBox
        {
            return this._1513045444FILTER_BUILDING_Enemy;
        }// end function

        public function get GAMESTATE_ID_LIST_CL3_BUILDINGS() : BuildingsList
        {
            return this._1053263437GAMESTATE_ID_LIST_CL3_BUILDINGS;
        }// end function

        private function _SWMMO_DataGridColumn7_c() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            _loc_1.headerText = "Unit Type";
            _loc_1.dataField = "UnitType";
            return _loc_1;
        }// end function

        private function _SWMMO_Button6_i() : Button
        {
            var _loc_1:* = new Button();
            this.SectorIdButton5 = _loc_1;
            _loc_1.x = 62;
            _loc_1.y = 69;
            _loc_1.label = "5";
            _loc_1.width = 43;
            _loc_1.height = 20;
            _loc_1.addEventListener("click", this.__SectorIdButton5_click);
            _loc_1.id = "SectorIdButton5";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_bindingsSetup() : Array
        {
            var result:Array;
            var binding:Binding;
            result;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = null;
                return;
            }// end function
            , "_SWMMO_AddChild1.relativeTo");
            result[0] = binding;
            binding = new Binding(this, function () : Object
            {
                return mTileListDataProviderGO;
            }// end function
            , function (param1:Object) : void
            {
                null.dataProvider = null;
                return;
            }// end function
            , "EDITORSTATE_ID_TILE_LIST_GO.dataProvider");
            result[1] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                _SWMMO_AddChild2.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild2.relativeTo");
            result[2] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild3.relativeTo");
            result[3] = binding;
            binding = new Binding(this, function () : Object
            {
                return menuBarCollection;
            }// end function
            , function (param1:Object) : void
            {
                null.dataProvider = null;
                return;
            }// end function
            , "EDITORSTATE_MenuBar.dataProvider");
            result[4] = binding;
            binding = new Binding(this, function () : Object
            {
                return myCanvas;
            }// end function
            , function (param1:Object) : void
            {
                null.target = param1;
                return;
            }// end function
            , "_SWMMO_SetProperty2.target");
            result[5] = binding;
            binding = new Binding(this, function () : Object
            {
                return myCanvas;
            }// end function
            , function (param1:Object) : void
            {
                null.target = null;
                return;
            }// end function
            , "_SWMMO_SetProperty3.target");
            result[6] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                _SWMMO_AddChild4.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild4.relativeTo");
            result[7] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild5.relativeTo");
            result[8] = binding;
            binding = new Binding(this, function () : Object
            {
                return mTileListDataProviderSetMode;
            }// end function
            , function (param1:Object) : void
            {
                null.dataProvider = param1;
                return;
            }// end function
            , "EDITORSTATE_ID_TILE_LIST_SET_MODE.dataProvider");
            result[9] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild6.relativeTo");
            result[10] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                _SWMMO_AddChild7.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild7.relativeTo");
            result[11] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = null;
                return;
            }// end function
            , "_SWMMO_AddChild8.relativeTo");
            result[12] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                _SWMMO_AddChild9.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild9.relativeTo");
            result[13] = binding;
            binding = new Binding(this, function () : Object
            {
                return mDepositGroupData;
            }// end function
            , function (param1:Object) : void
            {
                null.dataProvider = null;
                return;
            }// end function
            , "DepositGroupDataGrid.dataProvider");
            result[14] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                _SWMMO_AddChild10.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild10.relativeTo");
            result[15] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                _SWMMO_AddChild11.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild11.relativeTo");
            result[16] = binding;
            binding = new Binding(this, function () : Object
            {
                return mAssignUnitsData;
            }// end function
            , function (param1:Object) : void
            {
                null.dataProvider = null;
                return;
            }// end function
            , "AssignedUnitID.dataProvider");
            result[17] = binding;
            binding = new Binding(this, function () : Object
            {
                return mUnitListData;
            }// end function
            , function (param1:Object) : void
            {
                null.dataProvider = null;
                return;
            }// end function
            , "UnitListDataID.dataProvider");
            result[18] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = null;
                return;
            }// end function
            , "_SWMMO_AddChild12.relativeTo");
            result[19] = binding;
            binding = new Binding(this, function () : Object
            {
                return mSectorListData;
            }// end function
            , function (param1:Object) : void
            {
                SectorListCloseID.dataProvider = param1;
                return;
            }// end function
            , "SectorListCloseID.dataProvider");
            result[20] = binding;
            binding = new Binding(this, function () : Object
            {
                return myCanvas;
            }// end function
            , function (param1:Object) : void
            {
                null.target = param1;
                return;
            }// end function
            , "_SWMMO_SetProperty5.target");
            result[21] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild13.relativeTo");
            result[22] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild14.relativeTo");
            result[23] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = null;
                return;
            }// end function
            , "_SWMMO_AddChild15.relativeTo");
            result[24] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = null;
                return;
            }// end function
            , "_SWMMO_AddChild16.relativeTo");
            result[25] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = null;
                return;
            }// end function
            , "_SWMMO_AddChild17.relativeTo");
            result[26] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild18.relativeTo");
            result[27] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = null;
                return;
            }// end function
            , "_SWMMO_AddChild19.relativeTo");
            result[28] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild20.relativeTo");
            result[29] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = null;
                return;
            }// end function
            , "_SWMMO_AddChild21.relativeTo");
            result[30] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return label1;
            }// end function
            , function (param1:UIComponent) : void
            {
                _SWMMO_AddChild22.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild22.relativeTo");
            result[31] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild23.relativeTo");
            result[32] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = null;
                return;
            }// end function
            , "_SWMMO_AddChild24.relativeTo");
            result[33] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = null;
                return;
            }// end function
            , "_SWMMO_AddChild25.relativeTo");
            result[34] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = null;
                return;
            }// end function
            , "_SWMMO_AddChild26.relativeTo");
            result[35] = binding;
            binding = new Binding(this, function () : Object
            {
                return myCanvas;
            }// end function
            , function (param1:Object) : void
            {
                null.target = null;
                return;
            }// end function
            , "_SWMMO_SetProperty8.target");
            result[36] = binding;
            binding = new Binding(this, function () : Object
            {
                return myCanvas;
            }// end function
            , function (param1:Object) : void
            {
                _SWMMO_SetProperty9.target = param1;
                return;
            }// end function
            , "_SWMMO_SetProperty9.target");
            result[37] = binding;
            binding = new Binding(this, function () : Object
            {
                return myCanvas;
            }// end function
            , function (param1:Object) : void
            {
                null.target = param1;
                return;
            }// end function
            , "_SWMMO_SetProperty15.target");
            result[38] = binding;
            binding = new Binding(this, function () : Object
            {
                return myCanvas;
            }// end function
            , function (param1:Object) : void
            {
                _SWMMO_SetProperty16.target = param1;
                return;
            }// end function
            , "_SWMMO_SetProperty16.target");
            result[39] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild27.relativeTo");
            result[40] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:String = null;
                var _loc_2:* = undefined;
                _loc_1 = GAMESTATE_ID_FRIENDS_LIST.height;
                _loc_2 = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "GAMESTATE_ID_ACTIONBAR.bottom");
            result[41] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = null;
                return;
            }// end function
            , "_SWMMO_AddChild28.relativeTo");
            result[42] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild29.relativeTo");
            result[43] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                _SWMMO_AddChild30.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild30.relativeTo");
            result[44] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                _SWMMO_AddChild31.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild31.relativeTo");
            result[45] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild32.relativeTo");
            result[46] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = undefined;
                var _loc_2:* = undefined;
                _loc_1 = GAMESTATE_ID_AVATAR.width - 5;
                _loc_2 = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.setStyle("left", param1);
                return;
            }// end function
            , "GAMESTATE_ID_AVATAR_MESSAGE_LIST.left");
            result[47] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild33.relativeTo");
            result[48] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:String = null;
                var _loc_2:* = undefined;
                _loc_1 = GAMESTATE_ID_FRIENDS_LIST.height;
                _loc_2 = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                blueFireComponent.setStyle("bottom", param1);
                return;
            }// end function
            , "blueFireComponent.bottom");
            result[49] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = null;
                return;
            }// end function
            , "_SWMMO_AddChild34.relativeTo");
            result[50] = binding;
            binding = new Binding(this, function () : Number
            {
                return null + GAMESTATE_ID_ACTIONBAR.height;
            }// end function
            , function (param1:Number) : void
            {
                GAMESTATE_ID_FRIENDS_LIST.y = param1;
                return;
            }// end function
            , "GAMESTATE_ID_FRIENDS_LIST.y");
            result[51] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                _SWMMO_AddChild35.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild35.relativeTo");
            result[52] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:String = null;
                var _loc_2:* = undefined;
                _loc_1 = GAMESTATE_ID_BUILD_QUEUE.height;
                _loc_2 = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                GAMESTATE_ID_TRACKED_MISSION_LIST.setStyle("top", param1);
                return;
            }// end function
            , "GAMESTATE_ID_TRACKED_MISSION_LIST.top");
            result[53] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = null;
                return;
            }// end function
            , "_SWMMO_AddChild36.relativeTo");
            result[54] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild37.relativeTo");
            result[55] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild38.relativeTo");
            result[56] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild39.relativeTo");
            result[57] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                _SWMMO_AddChild40.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild40.relativeTo");
            result[58] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                _SWMMO_AddChild41.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild41.relativeTo");
            result[59] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                _SWMMO_AddChild42.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild42.relativeTo");
            result[60] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                _SWMMO_AddChild43.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild43.relativeTo");
            result[61] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = null;
                return;
            }// end function
            , "_SWMMO_AddChild44.relativeTo");
            result[62] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                _SWMMO_AddChild45.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild45.relativeTo");
            result[63] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                _SWMMO_AddChild46.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild46.relativeTo");
            result[64] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild47.relativeTo");
            result[65] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                _SWMMO_AddChild48.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild48.relativeTo");
            result[66] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = null;
                return;
            }// end function
            , "_SWMMO_AddChild49.relativeTo");
            result[67] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = null;
                return;
            }// end function
            , "_SWMMO_AddChild50.relativeTo");
            result[68] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = undefined;
                var _loc_2:* = undefined;
                _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "CL01Buildings");
                _loc_2 = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                GAMESTATE_ID_LIST_BASE_BUILDINGS.label = param1;
                return;
            }// end function
            , "GAMESTATE_ID_LIST_BASE_BUILDINGS.label");
            result[69] = binding;
            binding = new Binding(this, function () : Number
            {
                return null.getAnchorX(GAMESTATE_ID_ACTIONBAR.actionBarLeft.btnActionBar01) - GAMESTATE_ID_LIST_BASE_BUILDINGS.width / 2;
            }// end function
            , function (param1:Number) : void
            {
                null.x = param1;
                return;
            }// end function
            , "GAMESTATE_ID_LIST_BASE_BUILDINGS.x");
            result[70] = binding;
            binding = new Binding(this, function () : Number
            {
                return null.y - GAMESTATE_ID_LIST_BASE_BUILDINGS.height;
            }// end function
            , function (param1:Number) : void
            {
                GAMESTATE_ID_LIST_BASE_BUILDINGS.y = param1;
                return;
            }// end function
            , "GAMESTATE_ID_LIST_BASE_BUILDINGS.y");
            result[71] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = null;
                return;
            }// end function
            , "_SWMMO_AddChild51.relativeTo");
            result[72] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:String = null;
                var _loc_2:* = undefined;
                _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "CL2Buildings");
                _loc_2 = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "GAMESTATE_ID_LIST_CL01_BUILDINGS.label");
            result[73] = binding;
            binding = new Binding(this, function () : Number
            {
                return null.getAnchorX(null.actionBarLeft.btnActionBar02) - GAMESTATE_ID_LIST_CL01_BUILDINGS.width / 2;
            }// end function
            , function (param1:Number) : void
            {
                null.x = param1;
                return;
            }// end function
            , "GAMESTATE_ID_LIST_CL01_BUILDINGS.x");
            result[74] = binding;
            binding = new Binding(this, function () : Number
            {
                return null - GAMESTATE_ID_LIST_CL01_BUILDINGS.height;
            }// end function
            , function (param1:Number) : void
            {
                null.y = param1;
                return;
            }// end function
            , "GAMESTATE_ID_LIST_CL01_BUILDINGS.y");
            result[75] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild52.relativeTo");
            result[76] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = undefined;
                var _loc_2:* = undefined;
                _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "CL3Buildings");
                _loc_2 = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "GAMESTATE_ID_LIST_CL2_BUILDINGS.label");
            result[77] = binding;
            binding = new Binding(this, function () : Number
            {
                return null.getAnchorX(null.actionBarLeft.btnActionBar03) - GAMESTATE_ID_LIST_CL2_BUILDINGS.width / 2;
            }// end function
            , function (param1:Number) : void
            {
                null.x = null;
                return;
            }// end function
            , "GAMESTATE_ID_LIST_CL2_BUILDINGS.x");
            result[78] = binding;
            binding = new Binding(this, function () : Number
            {
                return null - GAMESTATE_ID_LIST_CL2_BUILDINGS.height;
            }// end function
            , function (param1:Number) : void
            {
                null.y = param1;
                return;
            }// end function
            , "GAMESTATE_ID_LIST_CL2_BUILDINGS.y");
            result[79] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild53.relativeTo");
            result[80] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = undefined;
                var _loc_2:* = undefined;
                _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "CLSBuildings");
                _loc_2 = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                GAMESTATE_ID_LIST_CL3_BUILDINGS.label = param1;
                return;
            }// end function
            , "GAMESTATE_ID_LIST_CL3_BUILDINGS.label");
            result[81] = binding;
            binding = new Binding(this, function () : Number
            {
                return GAMESTATE_ID_ACTIONBAR.getAnchorX(GAMESTATE_ID_ACTIONBAR.actionBarLeft.btnActionBar04) - GAMESTATE_ID_LIST_CL3_BUILDINGS.width / 2;
            }// end function
            , function (param1:Number) : void
            {
                null.x = null;
                return;
            }// end function
            , "GAMESTATE_ID_LIST_CL3_BUILDINGS.x");
            result[82] = binding;
            binding = new Binding(this, function () : Number
            {
                return GAMESTATE_ID_ACTIONBAR.y - GAMESTATE_ID_LIST_CL3_BUILDINGS.height;
            }// end function
            , function (param1:Number) : void
            {
                null.y = null;
                return;
            }// end function
            , "GAMESTATE_ID_LIST_CL3_BUILDINGS.y");
            result[83] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = null;
                return;
            }// end function
            , "_SWMMO_AddChild54.relativeTo");
            result[84] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                _SWMMO_AddChild55.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild55.relativeTo");
            result[85] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = null;
                return;
            }// end function
            , "_SWMMO_AddChild56.relativeTo");
            result[86] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = null;
                return;
            }// end function
            , "_SWMMO_AddChild57.relativeTo");
            result[87] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = undefined;
                var _loc_2:* = undefined;
                _loc_1 = int((Application.application.height - 350) / 2);
                _loc_2 = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.setStyle("top", param1);
                return;
            }// end function
            , "GAMESTATE_ID_TRADING_PANEL.top");
            result[88] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = null;
                return;
            }// end function
            , "_SWMMO_AddChild58.relativeTo");
            result[89] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:String = null;
                var _loc_2:* = undefined;
                _loc_1 = GAMESTATE_ID_FRIENDS_LIST.height + 100;
                _loc_2 = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.setStyle("bottom", param1);
                return;
            }// end function
            , "GAMESTATE_ID_STAR_MENU.bottom");
            result[90] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild59.relativeTo");
            result[91] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                _SWMMO_AddChild60.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild60.relativeTo");
            result[92] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                _SWMMO_AddChild61.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild61.relativeTo");
            result[93] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild62.relativeTo");
            result[94] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = null;
                return;
            }// end function
            , "_SWMMO_AddChild63.relativeTo");
            result[95] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild64.relativeTo");
            result[96] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                _SWMMO_AddChild65.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild65.relativeTo");
            result[97] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                _SWMMO_AddChild66.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild66.relativeTo");
            result[98] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                _SWMMO_AddChild67.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild67.relativeTo");
            result[99] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                _SWMMO_AddChild68.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild68.relativeTo");
            result[100] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = null;
                return;
            }// end function
            , "_SWMMO_AddChild69.relativeTo");
            result[101] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = null;
                return;
            }// end function
            , "_SWMMO_AddChild70.relativeTo");
            result[102] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                _SWMMO_AddChild71.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild71.relativeTo");
            result[103] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild72.relativeTo");
            result[104] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = null;
                return;
            }// end function
            , "_SWMMO_AddChild73.relativeTo");
            result[105] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = null;
                return;
            }// end function
            , "_SWMMO_AddChild74.relativeTo");
            result[106] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                _SWMMO_AddChild75.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild75.relativeTo");
            result[107] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                _SWMMO_AddChild76.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild76.relativeTo");
            result[108] = binding;
            binding = new Binding(this, function () : Object
            {
                return mResourceProductionWindowDataGridDataProvider;
            }// end function
            , function (param1:Object) : void
            {
                null.dataProvider = param1;
                return;
            }// end function
            , "ResourceProductionWindowDataGrid.dataProvider");
            result[109] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return myCanvas;
            }// end function
            , function (param1:UIComponent) : void
            {
                _SWMMO_AddChild77.relativeTo = param1;
                return;
            }// end function
            , "_SWMMO_AddChild77.relativeTo");
            result[110] = binding;
            return result;
        }// end function

        public function get GAMESTATE_ID_RESIDENCE_INFO_PANEL() : ResidenceInfoPanel
        {
            return this._2078777808GAMESTATE_ID_RESIDENCE_INFO_PANEL;
        }// end function

        private function _SWMMO_SetProperty8_i() : SetProperty
        {
            var _loc_1:SetProperty = null;
            _loc_1 = new SetProperty();
            this._SWMMO_SetProperty8 = _loc_1;
            _loc_1.name = "minHeight";
            _loc_1.value = 800;
            BindingManager.executeBindings(this, "_SWMMO_SetProperty8", this._SWMMO_SetProperty8);
            return _loc_1;
        }// end function

        private function StartGameClicked(event:Event) : void
        {
            global.gameSettingsFilename = defines.FILENAME_GAME_SETTINGS;
            currentState = "Game";
            return;
        }// end function

        private function _SWMMO_AddChild68_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild68 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_DailyLoginPanel1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild68", this._SWMMO_AddChild68);
            return _loc_1;
        }// end function

        private function _SWMMO_Label2_i() : Label
        {
            var _loc_1:* = new Label();
            this.SingleDepositAmountLabelID = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 14;
            _loc_1.text = "Single Deposit Amount ";
            _loc_1.id = "SingleDepositAmountLabelID";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_AddChild22_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild22 = _loc_1;
            _loc_1.position = "before";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_Button25_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild22", this._SWMMO_AddChild22);
            return _loc_1;
        }// end function

        protected function ExitGame(event:Event) : void
        {
            this.mGeneralInterface.Exit();
            global.ui = new cGeneralInterface();
            this.mGeneralInterface = global.ui;
            return;
        }// end function

        public function __SectorIdButton7_click(event:MouseEvent) : void
        {
            this.SectorIDNumberClicked(event);
            return;
        }// end function

        private function _SWMMO_MinimalInfoPanel1_i() : MinimalInfoPanel
        {
            var _loc_1:MinimalInfoPanel = null;
            _loc_1 = new MinimalInfoPanel();
            this.GAMESTATE_ID_MINIMAL_INFO_PANEL = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("right", "100");
            _loc_1.setStyle("bottom", "180");
            _loc_1.id = "GAMESTATE_ID_MINIMAL_INFO_PANEL";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get GAMESTATE_ID_DECORATION_INFO_PANEL() : DecorationInfoPanel
        {
            return this._193268130GAMESTATE_ID_DECORATION_INFO_PANEL;
        }// end function

        private function _SWMMO_DataGridColumn14_c() : DataGridColumn
        {
            var _loc_1:DataGridColumn = null;
            _loc_1 = new DataGridColumn();
            _loc_1.headerText = "Resource";
            _loc_1.dataField = "resource";
            return _loc_1;
        }// end function

        private function _SWMMO_HintPointer1_i() : HintPointer
        {
            var _loc_1:HintPointer = null;
            _loc_1 = new HintPointer();
            this.GAMESTATE_ID_HINT_POINTER = _loc_1;
            _loc_1.visible = false;
            _loc_1.id = "GAMESTATE_ID_HINT_POINTER";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set UPGRADLEVEL_ID_TEXT(param1:TextInput) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._83384109UPGRADLEVEL_ID_TEXT;
            if (_loc_2 !== param1)
            {
                this._83384109UPGRADLEVEL_ID_TEXT = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "UPGRADLEVEL_ID_TEXT", _loc_2, param1));
            }
            return;
        }// end function

        protected function SetLandingZoneID_clickHandler(event:MouseEvent) : void
        {
            return;
        }// end function

        private function _SWMMO_Text3_c() : Text
        {
            var _loc_1:* = new Text();
            _loc_1.x = 10;
            _loc_1.y = 10;
            _loc_1.text = "ID\n";
            _loc_1.width = 67;
            _loc_1.height = 24;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_AddChild33_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild33 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_BlueFireComponent1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild33", this._SWMMO_AddChild33);
            return _loc_1;
        }// end function

        private function _SWMMO_Label14_c() : Label
        {
            var _loc_1:Label = null;
            _loc_1 = new Label();
            _loc_1.setStyle("fontSize", 13);
            _loc_1.setStyle("horizontalCenter", "22");
            _loc_1.setStyle("verticalCenter", "-171");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_OptionsPanel1_i() : OptionsPanel
        {
            var _loc_1:OptionsPanel = null;
            _loc_1 = new OptionsPanel();
            this.GAMESTATE_ID_OPTIONS_PANEL = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("top", "203");
            _loc_1.setStyle("left", "10");
            _loc_1.id = "GAMESTATE_ID_OPTIONS_PANEL";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set GAMESTATE_ID_MEMORY_MONITOR(param1:MemoryMonitorPanel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1603470112GAMESTATE_ID_MEMORY_MONITOR;
            if (_loc_2 !== param1)
            {
                this._1603470112GAMESTATE_ID_MEMORY_MONITOR = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_MEMORY_MONITOR", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_BattleWindow1_i() : BattleWindow
        {
            var _loc_1:BattleWindow = null;
            _loc_1 = new BattleWindow();
            this.GAMESTATE_ID_BATTLE_WINDOW = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "-50");
            _loc_1.id = "GAMESTATE_ID_BATTLE_WINDOW";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get GAMESTATE_ID_AVATAR_MESSAGE_LIST() : AvatarMessageList
        {
            return this._270958984GAMESTATE_ID_AVATAR_MESSAGE_LIST;
        }// end function

        public function set SectorListCloseIDButton(param1:Button) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1921297217SectorListCloseIDButton;
            if (_loc_2 !== param1)
            {
                this._1921297217SectorListCloseIDButton = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SectorListCloseIDButton", _loc_2, param1));
            }
            return;
        }// end function

        public function get GAMESTATE_ID_TIMED_PRODUCTION_INFO_PANEL() : TimedProductionInfoPanel
        {
            return this._1726370163GAMESTATE_ID_TIMED_PRODUCTION_INFO_PANEL;
        }// end function

        public function get BrushSizeVBox() : VBox
        {
            return this._646604368BrushSizeVBox;
        }// end function

        public function set SectorListCloseID(param1:DataGrid) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1081215185SectorListCloseID;
            if (_loc_2 !== param1)
            {
                this._1081215185SectorListCloseID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SectorListCloseID", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_RadioButtonGroup3_i() : RadioButtonGroup
        {
            var _loc_1:* = new RadioButtonGroup();
            this.radiogroupSetBlocking = _loc_1;
            _loc_1.initialized(this, "radiogroupSetBlocking");
            return _loc_1;
        }// end function

        private function _SWMMO_DataGridColumn25_c() : DataGridColumn
        {
            var _loc_1:DataGridColumn = null;
            _loc_1 = new DataGridColumn();
            _loc_1.headerText = "DepPathLen";
            _loc_1.dataField = "depositPathLen";
            return _loc_1;
        }// end function

        public function get ID_DebugInfoPanelShowPlayerInfo() : CheckBox
        {
            return this._338299245ID_DebugInfoPanelShowPlayerInfo;
        }// end function

        public function set EDITORSTATE__ID_CHEAT_WINDOW(param1:CheatWindow) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._236967708EDITORSTATE__ID_CHEAT_WINDOW;
            if (_loc_2 !== param1)
            {
                this._236967708EDITORSTATE__ID_CHEAT_WINDOW = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "EDITORSTATE__ID_CHEAT_WINDOW", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_CameraControlPanel1_i() : CameraControlPanel
        {
            var _loc_1:CameraControlPanel = null;
            _loc_1 = new CameraControlPanel();
            this.GAMESTATE_ID_CAMERA_CONTROL_PANEL = _loc_1;
            _loc_1.y = 195;
            _loc_1.x = 130;
            _loc_1.visible = false;
            _loc_1.id = "GAMESTATE_ID_CAMERA_CONTROL_PANEL";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_AddChild44_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild44 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_TimedProductionInfoPanel1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild44", this._SWMMO_AddChild44);
            return _loc_1;
        }// end function

        public function get YellowBlockingRadioButtonID() : RadioButton
        {
            return this._154230399YellowBlockingRadioButtonID;
        }// end function

        public function set FILTER_BUILDING_Watchtower(param1:CheckBox) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1514347810FILTER_BUILDING_Watchtower;
            if (_loc_2 !== param1)
            {
                this._1514347810FILTER_BUILDING_Watchtower = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "FILTER_BUILDING_Watchtower", _loc_2, param1));
            }
            return;
        }// end function

        public function set FILTER_BUILDING_Residence(param1:CheckBox) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._831698110FILTER_BUILDING_Residence;
            if (_loc_2 !== param1)
            {
                this._831698110FILTER_BUILDING_Residence = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "FILTER_BUILDING_Residence", _loc_2, param1));
            }
            return;
        }// end function

        public function get GAMESTATE_ID_WAREHOUSE_INFO_PANEL() : WarehouseInfoPanel
        {
            return this._361154989GAMESTATE_ID_WAREHOUSE_INFO_PANEL;
        }// end function

        public function set ReAssignSectorIDButton(param1:Button) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._538934443ReAssignSectorIDButton;
            if (_loc_2 !== param1)
            {
                this._538934443ReAssignSectorIDButton = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "ReAssignSectorIDButton", _loc_2, param1));
            }
            return;
        }// end function

        public function set GAMESTATE_ID_BUILD_QUEUE(param1:BuildQueue) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1594990820GAMESTATE_ID_BUILD_QUEUE;
            if (_loc_2 !== param1)
            {
                this._1594990820GAMESTATE_ID_BUILD_QUEUE = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_BUILD_QUEUE", _loc_2, param1));
            }
            return;
        }// end function

        public function set GAMESTATE_ID_INFO_BAR(param1:InfoBar) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._97475834GAMESTATE_ID_INFO_BAR;
            if (_loc_2 !== param1)
            {
                this._97475834GAMESTATE_ID_INFO_BAR = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_INFO_BAR", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_AddChild55_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild55 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_BuildQueue1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild55", this._SWMMO_AddChild55);
            return _loc_1;
        }// end function

        private function _SWMMO_DailyLoginPanel1_i() : DailyLoginPanel
        {
            var _loc_1:DailyLoginPanel = null;
            _loc_1 = new DailyLoginPanel();
            this.GAMESTATE_ID_DAILY_LOGIN_PANEL = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "GAMESTATE_ID_DAILY_LOGIN_PANEL";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get GAMESTATE_ID_NEWS_WINDOW() : NewsWindow
        {
            return this._802978248GAMESTATE_ID_NEWS_WINDOW;
        }// end function

        public function get ID_DebugInfoPanelShowAll() : CheckBox
        {
            return this._1859197251ID_DebugInfoPanelShowAll;
        }// end function

        private function _SWMMO_DataGridColumn12_c() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            _loc_1.headerText = "City Level";
            _loc_1.dataField = "CityLevel";
            _loc_1.width = 60;
            _loc_1.sortable = false;
            return _loc_1;
        }// end function

        public function set BrushSizeTextInputId(param1:TextInput) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._592859997BrushSizeTextInputId;
            if (_loc_2 !== param1)
            {
                this._592859997BrushSizeTextInputId = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "BrushSizeTextInputId", _loc_2, param1));
            }
            return;
        }// end function

        public function set radiogroupOwnerShipPlayer(param1:RadioButton) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._743085236radiogroupOwnerShipPlayer;
            if (_loc_2 !== param1)
            {
                this._743085236radiogroupOwnerShipPlayer = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "radiogroupOwnerShipPlayer", _loc_2, param1));
            }
            return;
        }// end function

        public function set RemoveUnitID(param1:Button) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._637642909RemoveUnitID;
            if (_loc_2 !== param1)
            {
                this._637642909RemoveUnitID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "RemoveUnitID", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_DataGridColumn5_c() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            _loc_1.headerText = "Unit Type";
            _loc_1.dataField = "UnitType";
            _loc_1.editable = false;
            return _loc_1;
        }// end function

        private function set mAssignUnitsData(param1:ArrayCollection) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._619849891mAssignUnitsData;
            if (_loc_2 !== param1)
            {
                this._619849891mAssignUnitsData = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mAssignUnitsData", _loc_2, param1));
            }
            return;
        }// end function

        public function get GAMESTATE_ID_TRACKED_MISSION_LIST() : TrackedMissionList
        {
            return this._2063705802GAMESTATE_ID_TRACKED_MISSION_LIST;
        }// end function

        public function set GAMESTATE_ID_LIST_CL01_BUILDINGS(param1:BuildingsList) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1166847129GAMESTATE_ID_LIST_CL01_BUILDINGS;
            if (_loc_2 !== param1)
            {
                this._1166847129GAMESTATE_ID_LIST_CL01_BUILDINGS = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_LIST_CL01_BUILDINGS", _loc_2, param1));
            }
            return;
        }// end function

        public function set EDITORSTATE_ApplicationdisabledId(param1:Text) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1895114508EDITORSTATE_ApplicationdisabledId;
            if (_loc_2 !== param1)
            {
                this._1895114508EDITORSTATE_ApplicationdisabledId = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "EDITORSTATE_ApplicationdisabledId", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_AddChild20_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild20 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_Label11_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild20", this._SWMMO_AddChild20);
            return _loc_1;
        }// end function

        private function _SWMMO_AddChild66_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild66 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_AdventurePanel1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild66", this._SWMMO_AddChild66);
            return _loc_1;
        }// end function

        private function _SWMMO_Button4_i() : Button
        {
            var _loc_1:* = new Button();
            this.SectorIdButton3 = _loc_1;
            _loc_1.x = 113;
            _loc_1.y = 97;
            _loc_1.label = "3";
            _loc_1.width = 43;
            _loc_1.height = 20;
            _loc_1.addEventListener("click", this.__SectorIdButton3_click);
            _loc_1.id = "SectorIdButton3";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_SetProperty6_c() : SetProperty
        {
            var _loc_1:SetProperty = null;
            _loc_1 = new SetProperty();
            _loc_1.name = "width";
            _loc_1.value = "100%";
            return _loc_1;
        }// end function

        private function _SWMMO_LegalPanel1_i() : LegalPanel
        {
            var _loc_1:LegalPanel = null;
            _loc_1 = new LegalPanel();
            this.GAMESTATE_ID_LEGAL_PANEL = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "GAMESTATE_ID_LEGAL_PANEL";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_DataGridColumn23_c() : DataGridColumn
        {
            var _loc_1:DataGridColumn = null;
            _loc_1 = new DataGridColumn();
            _loc_1.headerText = "WorkTime";
            _loc_1.dataField = "workTime";
            return _loc_1;
        }// end function

        private function _SWMMO_Label12_c() : Label
        {
            var _loc_1:Label = null;
            _loc_1 = new Label();
            _loc_1.y = 347;
            _loc_1.text = "Debug Functions";
            _loc_1.setStyle("horizontalCenter", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __ID_SHOW_DEBUG_INFO_PANEL_hide(event:FlexEvent) : void
        {
            this.ID_SHOW_DEBUG_INFO_PANEL_hideHandler(event);
            return;
        }// end function

        public function set GAMESTATE_ID_QUEST_NEW_QUEST_SYSTEM_LIST_PANEL(param1:QuestNewQuestSystemList) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._626564234GAMESTATE_ID_QUEST_NEW_QUEST_SYSTEM_LIST_PANEL;
            if (_loc_2 !== param1)
            {
                this._626564234GAMESTATE_ID_QUEST_NEW_QUEST_SYSTEM_LIST_PANEL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_QUEST_NEW_QUEST_SYSTEM_LIST_PANEL", _loc_2, param1));
            }
            return;
        }// end function

        public function __SectorListCloseID_itemEditEnd(event:DataGridEvent) : void
        {
            this.SectorListItemEditEnd(event);
            return;
        }// end function

        private function FocusOutHandler(event:FocusEvent) : void
        {
            if (this.mGeneralInterface == null)
            {
                return;
            }
            this.mGeneralInterface.FocusOutHandler(event);
            return;
        }// end function

        public function set GAMESTATE_ID_FOUND_GUILD_PANEL(param1:FoundGuildPanel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._768529271GAMESTATE_ID_FOUND_GUILD_PANEL;
            if (_loc_2 !== param1)
            {
                this._768529271GAMESTATE_ID_FOUND_GUILD_PANEL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_FOUND_GUILD_PANEL", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_AddChild31_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild31 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_OptionsPanel1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild31", this._SWMMO_AddChild31);
            return _loc_1;
        }// end function

        private function _SWMMO_AddChild77_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild77 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_Panel3_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild77", this._SWMMO_AddChild77);
            return _loc_1;
        }// end function

        public function __btnStartGame_click(event:MouseEvent) : void
        {
            this.StartGameClicked(event);
            return;
        }// end function

        private function _SWMMO_Text1_i() : Text
        {
            var _loc_1:* = new Text();
            this.EDITORSTATE_ApplicationdisabledId = _loc_1;
            _loc_1.text = "Application disabled";
            _loc_1.width = 367;
            _loc_1.x = 22.5;
            _loc_1.y = 27;
            _loc_1.setStyle("fontSize", 29);
            _loc_1.setStyle("textAlign", "center");
            _loc_1.id = "EDITORSTATE_ApplicationdisabledId";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get GAMESTATE_ID_TAVERN_INFO_PANEL() : TavernInfoPanel
        {
            return this._1887414006GAMESTATE_ID_TAVERN_INFO_PANEL;
        }// end function

        protected function ReAssignSectorIDCancel_clickHandler(event:MouseEvent) : void
        {
            Application.application.ReAssignSectorID.visible = false;
            return;
        }// end function

        private function _SWMMO_DarkenPanel1_i() : DarkenPanel
        {
            var _loc_1:DarkenPanel = null;
            _loc_1 = new DarkenPanel();
            this.GAMESTATE_ID_DARKEN_PANEL = _loc_1;
            _loc_1.visible = false;
            _loc_1.id = "GAMESTATE_ID_DARKEN_PANEL";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set brushSizeRadioID(param1:Panel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1767827589brushSizeRadioID;
            if (_loc_2 !== param1)
            {
                this._1767827589brushSizeRadioID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "brushSizeRadioID", _loc_2, param1));
            }
            return;
        }// end function

        private function RefreshSectorListWindow() : void
        {
            return;
        }// end function

        public function get EDITORSTATE_ApplicationdisabledId() : Text
        {
            return this._1895114508EDITORSTATE_ApplicationdisabledId;
        }// end function

        private function _SWMMO_State4_c() : State
        {
            var _loc_1:State = null;
            _loc_1 = new State();
            _loc_1.name = "Game";
            _loc_1.overrides = [this._SWMMO_SetProperty6_c(), this._SWMMO_SetProperty7_c(), this._SWMMO_AddChild26_i(), this._SWMMO_SetProperty8_i(), this._SWMMO_SetProperty9_i(), this._SWMMO_SetProperty10_c(), this._SWMMO_SetProperty11_c(), this._SWMMO_SetProperty12_c(), this._SWMMO_SetProperty13_c(), this._SWMMO_SetProperty14_c(), this._SWMMO_SetProperty15_i(), this._SWMMO_SetProperty16_i(), this._SWMMO_AddChild27_i(), this._SWMMO_AddChild28_i(), this._SWMMO_AddChild29_i(), this._SWMMO_AddChild30_i(), this._SWMMO_AddChild31_i(), this._SWMMO_AddChild32_i(), this._SWMMO_AddChild33_i(), this._SWMMO_AddChild34_i(), this._SWMMO_AddChild35_i(), this._SWMMO_AddChild36_i(), this._SWMMO_AddChild37_i(), this._SWMMO_AddChild38_i(), this._SWMMO_AddChild39_i(), this._SWMMO_AddChild40_i(), this._SWMMO_AddChild41_i(), this._SWMMO_AddChild42_i(), this._SWMMO_AddChild43_i(), this._SWMMO_AddChild44_i(), this._SWMMO_AddChild45_i(), this._SWMMO_AddChild46_i(), this._SWMMO_AddChild47_i(), this._SWMMO_AddChild48_i(), this._SWMMO_AddChild49_i(), this._SWMMO_AddChild50_i(), this._SWMMO_AddChild51_i(), this._SWMMO_AddChild52_i(), this._SWMMO_AddChild53_i(), this._SWMMO_AddChild54_i(), this._SWMMO_AddChild55_i(), this._SWMMO_AddChild56_i(), this._SWMMO_AddChild57_i(), this._SWMMO_AddChild58_i(), this._SWMMO_AddChild59_i(), this._SWMMO_AddChild60_i(), this._SWMMO_AddChild61_i(), this._SWMMO_AddChild62_i(), this._SWMMO_AddChild63_i(), this._SWMMO_AddChild64_i(), this._SWMMO_AddChild65_i(), this._SWMMO_AddChild66_i(), this._SWMMO_AddChild67_i(), this._SWMMO_AddChild68_i(), this._SWMMO_AddChild69_i(), this._SWMMO_AddChild70_i(), this._SWMMO_AddChild71_i(), this._SWMMO_AddChild72_i(), this._SWMMO_AddChild73_i(), this._SWMMO_AddChild74_i(), this._SWMMO_AddChild75_i(), this._SWMMO_AddChild76_i(), this._SWMMO_AddChild77_i()];
            _loc_1.addEventListener("enterState", this.___SWMMO_State4_enterState);
            _loc_1.addEventListener("exitState", this.___SWMMO_State4_exitState);
            return _loc_1;
        }// end function

        public function set AssignUnitID(param1:Button) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._2118605938AssignUnitID;
            if (_loc_2 !== param1)
            {
                this._2118605938AssignUnitID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "AssignUnitID", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_RadioButtonGroup1_i() : RadioButtonGroup
        {
            var _loc_1:* = new RadioButtonGroup();
            this.brushSizeRadiogroup = _loc_1;
            _loc_1.initialized(this, "brushSizeRadiogroup");
            return _loc_1;
        }// end function

        public function get EDITORSTATE__ID_CHEAT_WINDOW() : CheatWindow
        {
            return this._236967708EDITORSTATE__ID_CHEAT_WINDOW;
        }// end function

        public function ___SWMMO_RadioButton6_click(event:MouseEvent) : void
        {
            this.UpdateBrushSizeRadioButtons();
            return;
        }// end function

        private function _SWMMO_GuildWindow1_i() : GuildWindow
        {
            var _loc_1:GuildWindow = null;
            _loc_1 = new GuildWindow();
            this.GAMESTATE_ID_GUILD_WINDOW = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "GAMESTATE_ID_GUILD_WINDOW";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set GAMESTATE_ID_SPECIALIST_PANEL(param1:SpecialistPanel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._77996922GAMESTATE_ID_SPECIALIST_PANEL;
            if (_loc_2 !== param1)
            {
                this._77996922GAMESTATE_ID_SPECIALIST_PANEL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_SPECIALIST_PANEL", _loc_2, param1));
            }
            return;
        }// end function

        private function IsMouseOverCanvas(event:Event) : Boolean
        {
            var _loc_2:Boolean = false;
            if (this.mGeneralInterface == null)
            {
                return false;
            }
            var _loc_3:* = event.target.toString();
            if (event.target != this.myCanvas)
            {
                _loc_2 = false;
            }
            else
            {
                _loc_2 = true;
            }
            if (_loc_2 == true && this.mCanvasFocused == false)
            {
                if (this.mGeneralInterface.mEnumUIType == UITYPE.GAME)
                {
                }
                else if (this.mGeneralInterface.mEnumUIType == UITYPE.EDITOR)
                {
                    if (this.EDITORSTATE_focusID != null)
                    {
                        this.EDITORSTATE_focusID.setFocus();
                    }
                }
            }
            this.mCanvasFocused = _loc_2;
            return this.mCanvasFocused;
        }// end function

        public function get SectorListCloseID() : DataGrid
        {
            return this._1081215185SectorListCloseID;
        }// end function

        public function set GAMESTATE_ID_LIST_CL2_BUILDINGS(param1:BuildingsList) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1444752500GAMESTATE_ID_LIST_CL2_BUILDINGS;
            if (_loc_2 !== param1)
            {
                this._1444752500GAMESTATE_ID_LIST_CL2_BUILDINGS = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_LIST_CL2_BUILDINGS", _loc_2, param1));
            }
            return;
        }// end function

        public function __SectorListCloseIDButton_click(event:MouseEvent) : void
        {
            this.SectorListCloseID_clickHandler(event);
            return;
        }// end function

        public function set SectorModeWindow(param1:TitleWindow) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1994189721SectorModeWindow;
            if (_loc_2 !== param1)
            {
                this._1994189721SectorModeWindow = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "SectorModeWindow", _loc_2, param1));
            }
            return;
        }// end function

        public function set EDITORSTATE_btnEditor(param1:Button) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1590085518EDITORSTATE_btnEditor;
            if (_loc_2 !== param1)
            {
                this._1590085518EDITORSTATE_btnEditor = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "EDITORSTATE_btnEditor", _loc_2, param1));
            }
            return;
        }// end function

        public function __DepositGroupDataGrid_itemClick(event:ListEvent) : void
        {
            this.DepositGroupItemClick(event);
            return;
        }// end function

        private function _SWMMO_AddChild53_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild53 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_BuildingsList4_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild53", this._SWMMO_AddChild53);
            return _loc_1;
        }// end function

        private function _SWMMO_DataGridColumn3_c() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            _loc_1.headerText = "Average Amount";
            _loc_1.dataField = "averageAmount";
            _loc_1.sortable = false;
            return _loc_1;
        }// end function

        private function _SWMMO_CheckBox18_i() : CheckBox
        {
            var _loc_1:CheckBox = null;
            _loc_1 = new CheckBox();
            this.ID_DebugInfoPanelShowErrorLog = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 184;
            _loc_1.label = "ShowErrorLog";
            _loc_1.id = "ID_DebugInfoPanelShowErrorLog";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_DataGridColumn10_c() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            _loc_1.headerText = "ID";
            _loc_1.dataField = "SectorID";
            _loc_1.width = 30;
            _loc_1.resizable = true;
            _loc_1.sortable = false;
            return _loc_1;
        }// end function

        public function get UPGRADLEVEL_ID_TEXT() : TextInput
        {
            return this._83384109UPGRADLEVEL_ID_TEXT;
        }// end function

        public function set GAMESTATE_ID_CANCEL_ACTION_PANEL(param1:CancelActionPanel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1794906212GAMESTATE_ID_CANCEL_ACTION_PANEL;
            if (_loc_2 !== param1)
            {
                this._1794906212GAMESTATE_ID_CANCEL_ACTION_PANEL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_CANCEL_ACTION_PANEL", _loc_2, param1));
            }
            return;
        }// end function

        public function get GAMESTATE_ID_BUILD_QUEUE() : BuildQueue
        {
            return this._1594990820GAMESTATE_ID_BUILD_QUEUE;
        }// end function

        public function ___SWMMO_Application1_click(event:MouseEvent) : void
        {
            this.click(event);
            return;
        }// end function

        private function _SWMMO_AddChild42_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild42 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_ResidenceInfoPanel1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild42", this._SWMMO_AddChild42);
            return _loc_1;
        }// end function

        private function _SWMMO_SetProperty4_c() : SetProperty
        {
            var _loc_1:* = new SetProperty();
            _loc_1.name = "layout";
            _loc_1.value = "horizontal";
            return _loc_1;
        }// end function

        private function _SWMMO_Button2_i() : Button
        {
            var _loc_1:* = new Button();
            this.SectorIdButton1 = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 97;
            _loc_1.label = "1";
            _loc_1.width = 43;
            _loc_1.height = 20;
            _loc_1.addEventListener("click", this.__SectorIdButton1_click);
            _loc_1.id = "SectorIdButton1";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set radiogroupOwnerShipBanditCamp(param1:RadioButton) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._350084012radiogroupOwnerShipBanditCamp;
            if (_loc_2 !== param1)
            {
                this._350084012radiogroupOwnerShipBanditCamp = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "radiogroupOwnerShipBanditCamp", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_AddChild64_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild64 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_MailWindow1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild64", this._SWMMO_AddChild64);
            return _loc_1;
        }// end function

        private function _SWMMO_DataGridColumn21_c() : DataGridColumn
        {
            var _loc_1:DataGridColumn = null;
            _loc_1 = new DataGridColumn();
            _loc_1.headerText = "ExtResource";
            _loc_1.dataField = "externalResource";
            return _loc_1;
        }// end function

        private function _SWMMO_Label10_c() : Label
        {
            var _loc_1:Label = null;
            _loc_1 = new Label();
            _loc_1.y = 220;
            _loc_1.text = "Blue Byte Software";
            _loc_1.setStyle("horizontalCenter", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_BuildQueue1_i() : BuildQueue
        {
            var _loc_1:BuildQueue = null;
            _loc_1 = new BuildQueue();
            this.GAMESTATE_ID_BUILD_QUEUE = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("top", "0");
            _loc_1.setStyle("right", "0");
            _loc_1.id = "GAMESTATE_ID_BUILD_QUEUE";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get RemoveUnitID() : Button
        {
            return this._637642909RemoveUnitID;
        }// end function

        public function set GAMESTATE_ID_LOADING_ZONE_PANEL(param1:LoadingZonePanel) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._680378296GAMESTATE_ID_LOADING_ZONE_PANEL;
            if (_loc_2 !== param1)
            {
                this._680378296GAMESTATE_ID_LOADING_ZONE_PANEL = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "GAMESTATE_ID_LOADING_ZONE_PANEL", _loc_2, param1));
            }
            return;
        }// end function

        public function set label1(param1:Label) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1110417475label1;
            if (_loc_2 !== param1)
            {
                this._1110417475label1 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "label1", _loc_2, param1));
            }
            return;
        }// end function

        public function get brushSizeRadioID() : Panel
        {
            return this._1767827589brushSizeRadioID;
        }// end function

        public function set mGeneralInterface(param1:cGeneralInterface) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._25308226mGeneralInterface;
            if (_loc_2 !== param1)
            {
                this._25308226mGeneralInterface = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mGeneralInterface", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_AddChild75_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild75 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_CheatWindow2_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild75", this._SWMMO_AddChild75);
            return _loc_1;
        }// end function

        private function get mAssignUnitsData() : ArrayCollection
        {
            return this._619849891mAssignUnitsData;
        }// end function

        private function _SWMMO_Canvas2_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.SingleDepositID = _loc_1;
            _loc_1.label = "Single Deposit";
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            _loc_1.id = "SingleDepositID";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SWMMO_TextInput3_i());
            _loc_1.addChild(this._SWMMO_Label2_i());
            return _loc_1;
        }// end function

        public function ___SWMMO_State1_enterState(event:FlexEvent) : void
        {
            this.EnterEditor(event);
            return;
        }// end function

        public function set DeletegroupID(param1:Button) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._777035857DeletegroupID;
            if (_loc_2 !== param1)
            {
                this._777035857DeletegroupID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "DeletegroupID", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_AddChild40_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild40 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_MysteryBoxPanel1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild40", this._SWMMO_AddChild40);
            return _loc_1;
        }// end function

        private function _SWMMO_TextInput6_i() : TextInput
        {
            var _loc_1:* = new TextInput();
            this.newSectorIDTextInput = _loc_1;
            _loc_1.x = 108;
            _loc_1.y = 33;
            _loc_1.width = 81;
            _loc_1.id = "newSectorIDTextInput";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SWMMO_State2_c() : State
        {
            var _loc_1:* = new State();
            _loc_1.name = "MainMenu";
            _loc_1.overrides = [this._SWMMO_AddChild16_i(), this._SWMMO_AddChild17_i(), this._SWMMO_AddChild18_i(), this._SWMMO_AddChild19_i(), this._SWMMO_AddChild20_i(), this._SWMMO_AddChild21_i(), this._SWMMO_AddChild22_i(), this._SWMMO_AddChild23_i(), this._SWMMO_AddChild24_i()];
            return _loc_1;
        }// end function

        private function keyDown(event:KeyboardEvent) : void
        {
            if (this.mGeneralInterface == null)
            {
                return;
            }
            this.mGeneralInterface.KeyDownAlways(event);
            if (this.GetLastMouseOverCanvas())
            {
                this.mGeneralInterface.KeyDownOnMap(event);
            }
            return;
        }// end function

        public function ___SWMMO_State4_enterState(event:FlexEvent) : void
        {
            this.EnterGame(event);
            return;
        }// end function

        private function _SWMMO_CheckBox16_i() : CheckBox
        {
            var _loc_1:CheckBox = null;
            _loc_1 = new CheckBox();
            this.ID_DebugInfoPanelShowOnScreenGameTickCommands = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 126;
            _loc_1.label = "OnScreenGameTickCommands";
            _loc_1.id = "ID_DebugInfoPanelShowOnScreenGameTickCommands";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __SectorIdButton0_click(event:MouseEvent) : void
        {
            this.SectorIDNumberClicked(event);
            return;
        }// end function

        private function _SWMMO_MailWindow1_i() : MailWindow
        {
            var _loc_1:MailWindow = null;
            _loc_1 = new MailWindow();
            this.GAMESTATE_ID_MAIL_WINDOW = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "GAMESTATE_ID_MAIL_WINDOW";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        protected function EraseLandingZoneID_clickHandler(event:MouseEvent) : void
        {
            return;
        }// end function

        public function get GAMESTATE_ID_CANCEL_ACTION_PANEL() : CancelActionPanel
        {
            return this._1794906212GAMESTATE_ID_CANCEL_ACTION_PANEL;
        }// end function

        public function EnableApplication() : void
        {
            if (this.mGeneralInterface != null)
            {
                cGuiBaseElement.SetEnableStateForAllGuiElements(true);
                this.mGeneralInterface.mComputeAndInputActive = true;
            }
            return;
        }// end function

        public function get DeletegroupID() : Button
        {
            return this._777035857DeletegroupID;
        }// end function

        public function get EDITORSTATE_btnEditor() : Button
        {
            return this._1590085518EDITORSTATE_btnEditor;
        }// end function

        protected function SectorListCloseID_clickHandler(event:MouseEvent) : void
        {
            this.SectorListID.visible = false;
            return;
        }// end function

        private function _SWMMO_AddChild51_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild51 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_BuildingsList2_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild51", this._SWMMO_AddChild51);
            return _loc_1;
        }// end function

        public function set mResourceProductionWindowDataGridDataProvider(param1:ArrayCollection) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._137831375mResourceProductionWindowDataGridDataProvider;
            if (_loc_2 !== param1)
            {
                this._137831375mResourceProductionWindowDataGridDataProvider = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mResourceProductionWindowDataGridDataProvider", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_Button19_i() : Button
        {
            var _loc_1:* = new Button();
            this.FILTER_BUILDING_ALL_ID = _loc_1;
            _loc_1.x = 10;
            _loc_1.y = 10;
            _loc_1.label = "All";
            _loc_1.width = 55;
            _loc_1.height = 19;
            _loc_1.setStyle("fontSize", 12);
            _loc_1.setStyle("color", 0);
            _loc_1.addEventListener("click", this.__FILTER_BUILDING_ALL_ID_click);
            _loc_1.id = "FILTER_BUILDING_ALL_ID";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        protected function TabNavigatorID_changeHandler(event:IndexChangedEvent) : void
        {
            return;
        }// end function

        public function set DepositGroupDataGrid(param1:DataGrid) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1095300049DepositGroupDataGrid;
            if (_loc_2 !== param1)
            {
                this._1095300049DepositGroupDataGrid = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "DepositGroupDataGrid", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_DataGridColumn1_c() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            _loc_1.headerText = "Group ID";
            _loc_1.dataField = "groupId";
            _loc_1.sortable = false;
            return _loc_1;
        }// end function

        public function get label1() : Label
        {
            return this._1110417475label1;
        }// end function

        public function get GAMESTATE_ID_LOADING_ZONE_PANEL() : LoadingZonePanel
        {
            return this._680378296GAMESTATE_ID_LOADING_ZONE_PANEL;
        }// end function

        private function _SWMMO_BuildingsList4_i() : BuildingsList
        {
            var _loc_1:BuildingsList = null;
            _loc_1 = new BuildingsList();
            this.GAMESTATE_ID_LIST_CL3_BUILDINGS = _loc_1;
            _loc_1.visible = false;
            _loc_1.id = "GAMESTATE_ID_LIST_CL3_BUILDINGS";
            BindingManager.executeBindings(this, "GAMESTATE_ID_LIST_CL3_BUILDINGS", this.GAMESTATE_ID_LIST_CL3_BUILDINGS);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function StartGameDebugClicked(event:Event) : void
        {
            global.gameSettingsFilename = defines.FILENAME_GAME_DEBUG_SETTINGS;
            currentState = "Game";
            return;
        }// end function

        private function DepositGroupInitDataGridData(event:Event) : void
        {
            return;
        }// end function

        public function set AssignGroupID(param1:Button) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._672299061AssignGroupID;
            if (_loc_2 !== param1)
            {
                this._672299061AssignGroupID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "AssignGroupID", _loc_2, param1));
            }
            return;
        }// end function

        public function __SetSectorID_click(event:MouseEvent) : void
        {
            this.SetSectorID_clickHandler(event);
            return;
        }// end function

        private function _SWMMO_AddChild62_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild62 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_ShopWindow1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild62", this._SWMMO_AddChild62);
            return _loc_1;
        }// end function

        private function _SWMMO_SetProperty2_i() : SetProperty
        {
            var _loc_1:* = new SetProperty();
            this._SWMMO_SetProperty2 = _loc_1;
            _loc_1.name = "x";
            BindingManager.executeBindings(this, "_SWMMO_SetProperty2", this._SWMMO_SetProperty2);
            return _loc_1;
        }// end function

        private function _SWMMO_RadioButton8_c() : RadioButton
        {
            var _loc_1:* = new RadioButton();
            _loc_1.label = "22";
            _loc_1.groupName = "brushSizeRadiogroup";
            _loc_1.addEventListener("click", this.___SWMMO_RadioButton8_click);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get AssignGroupID() : Button
        {
            return this._672299061AssignGroupID;
        }// end function

        public function set menuBarCollection(param1:XMLListCollection) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._226797582menuBarCollection;
            if (_loc_2 !== param1)
            {
                this._226797582menuBarCollection = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "menuBarCollection", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_DecorationInfoPanel1_i() : DecorationInfoPanel
        {
            var _loc_1:DecorationInfoPanel = null;
            _loc_1 = new DecorationInfoPanel();
            this.GAMESTATE_ID_DECORATION_INFO_PANEL = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("right", "100");
            _loc_1.setStyle("bottom", "180");
            _loc_1.id = "GAMESTATE_ID_DECORATION_INFO_PANEL";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __SectorIdButton5_click(event:MouseEvent) : void
        {
            this.SectorIDNumberClicked(event);
            return;
        }// end function

        public function set FILTER_BUILDING_Decoration(param1:CheckBox) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._2050543604FILTER_BUILDING_Decoration;
            if (_loc_2 !== param1)
            {
                this._2050543604FILTER_BUILDING_Decoration = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "FILTER_BUILDING_Decoration", _loc_2, param1));
            }
            return;
        }// end function

        public function set EDITORSTATE_MenuBar(param1:MenuBar) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1383535623EDITORSTATE_MenuBar;
            if (_loc_2 !== param1)
            {
                this._1383535623EDITORSTATE_MenuBar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "EDITORSTATE_MenuBar", _loc_2, param1));
            }
            return;
        }// end function

        private function _SWMMO_AddChild73_i() : AddChild
        {
            var _loc_1:AddChild = null;
            _loc_1 = new AddChild();
            this._SWMMO_AddChild73 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_QuestNewQuestSystemList1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild73", this._SWMMO_AddChild73);
            return _loc_1;
        }// end function

        private function _SWMMO_AddChild9_i() : AddChild
        {
            var _loc_1:* = new AddChild();
            this._SWMMO_AddChild9 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SWMMO_TabNavigator1_i);
            BindingManager.executeBindings(this, "_SWMMO_AddChild9", this._SWMMO_AddChild9);
            return _loc_1;
        }// end function

        public function get menuBarCollection() : XMLListCollection
        {
            return this._226797582menuBarCollection;
        }// end function

        private function SectorListItemEditEnd(event:DataGridEvent) : void
        {
            return;
        }// end function

        private function _SWMMO_DataGrid4_i() : DataGrid
        {
            var _loc_1:* = new DataGrid();
            this.SectorListCloseID = _loc_1;
            _loc_1.editable = true;
            _loc_1.enabled = true;
            _loc_1.x = 10;
            _loc_1.y = 10;
            _loc_1.width = 260;
            _loc_1.height = 151;
            _loc_1.columns = [this._SWMMO_DataGridColumn10_c(), this._SWMMO_DataGridColumn11_c(), this._SWMMO_DataGridColumn12_c(), this._SWMMO_DataGridColumn13_c()];
            _loc_1.addEventListener("itemEditEnd", this.__SectorListCloseID_itemEditEnd);
            _loc_1.id = "SectorListCloseID";
            BindingManager.executeBindings(this, "SectorListCloseID", this.SectorListCloseID);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function resizeHandler(event:Event) : void
        {
            this.myCanvas.width = stage.stageWidth;
            this.myCanvas.height = stage.stageHeight;
            this.SetApplicationWidthandHeight();
            if (this.mGeneralInterface == null)
            {
                return;
            }
            this.mGeneralInterface.ApplicationResized();
            return;
        }// end function

        public static function isReleaseBuild() : Boolean
        {
            return !isDebugBuild();
        }// end function

        public static function isDebugBuild() : Boolean
        {
            return new Error().getStackTrace().search(/:[0-9]+]$"":[0-9]+]$/m) > -1;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

        public static function isDebugPlayer() : Boolean
        {
            return Capabilities.isDebugger;
        }// end function

    }
}
