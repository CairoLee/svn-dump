package 
{
    import flash.system.*;
    import flash.utils.*;
    import mx.core.*;
    import mx.managers.*;

    public class _SWMMO_mx_managers_SystemManager extends SystemManager implements IFlexModuleFactory
    {
        private var _preloadedRSLs:Dictionary;

        public function _SWMMO_mx_managers_SystemManager()
        {
            FlexVersion.compatibilityVersionString = "3.0.0";
            return;
        }// end function

        override public function create(... args) : Object
        {
            if (args.length > 0 && !(args[0] is String))
            {
                return super.create.apply(this, args);
            }
            args = args.length == 0 ? ("SWMMO") : (String(args[0]));
            var _loc_3:* = Class(getDefinitionByName(args));
            if (!_loc_3)
            {
                return null;
            }
            var _loc_4:* = new _loc_3;
            if (new _loc_3 is IFlexModule)
            {
                IFlexModule(_loc_4).moduleFactory = this;
            }
            return _loc_4;
        }// end function

        override public function allowInsecureDomain(... args) : void
        {
            args = null;
            Security.allowInsecureDomain(args);
            for (args in this._preloadedRSLs)
            {
                
                if (args.content && "allowInsecureDomainInRSL" in args.content)
                {
                    var _loc_5:* = args.content;
                    _loc_5.args.content["allowInsecureDomainInRSL"](args);
                }
            }
            return;
        }// end function

        override public function info() : Object
        {
            return {applicationComplete:"initXML()", backgroundGradientColors:"[#3f576f, #3f576f]", borderStyle:"solid", click:"click(event)", clipContent:"true", compiledLocales:["en_US"], compiledResourceBundleNames:["SharedResources", "collections", "containers", "controls", "core", "effects", "formatters", "logging", "messaging", "rpc", "skins", "states", "styles", "utils"], creationComplete:"creationComplete()", currentDomain:ApplicationDomain.currentDomain, currentState:"LoadSettings", enterFrame:"enterFrame(event)", frameRate:"60", horizontalPageScrollSize:"0", horizontalScrollPolicy:"off", horizontalScrollPosition:"0", layout:"absolute", mainClassName:"SWMMO", mixins:["_SWMMO_FlexInit", "_alertButtonStyleStyle", "_SWFLoaderStyle", "_FormStyle", "_headerDateTextStyle", "_macMinButtonStyle", "_winCloseButtonStyle", "_TitleWindowStyle", "_todayStyleStyle", "_HorizontalListStyle", "_windowStylesStyle", "_FormItemLabelStyle", "_TextInputStyle", "_ApplicationControlBarStyle", "_dateFieldPopupStyle", "_FormItemStyle", "_winMinButtonStyle", "_dataGridStylesStyle", "_TabStyle", "_headerDragProxyStyleStyle", "_popUpMenuStyle", "_TabNavigatorStyle", "_ProgressBarStyle", "_DragManagerStyle", "_ContainerStyle", "_TextAreaStyle", "_NumericStepperStyle", "_windowStatusStyle", "_swatchPanelTextFieldStyle", "_RadioButtonStyle", "_ButtonBarStyle", "_textAreaHScrollBarStyleStyle", "_MenuBarStyle", "_macCloseButtonStyle", "_CheckBoxStyle", "_comboDropdownStyle", "_winMaxButtonStyle", "_ButtonStyle", "_linkButtonStyleStyle", "_richTextEditorTextAreaStyleStyle", "_ControlBarStyle", "_textAreaVScrollBarStyleStyle", "_globalStyle", "_ListBaseStyle", "_AlertStyle", "_TabBarStyle", "_TileListStyle", "_ApplicationStyle", "_ToolTipStyle", "_winRestoreButtonStyle", "_ButtonBarButtonStyle", "_CursorManagerStyle", "_opaquePanelStyle", "_errorTipStyle", "_MenuStyle", "_DataGridStyle", "_activeTabStyleStyle", "_PanelStyle", "_ScrollBarStyle", "_statusTextStyleStyle", "_macMaxButtonStyle", "_plainStyle", "_activeButtonStyleStyle", "_titleTextStyleStyle", "_DataGridItemRendererStyle", "_gripperSkinStyle", "_weekDayStyleStyle", "_com_bluebyte_bluefire_flex3_defaultClient_ChatPanelWatcherSetupUtil", "_com_bluebyte_bluefire_flex3_defaultClient_ButtonBarItemRendererWatcherSetupUtil", "_GUI_Components_ItemRenderer_BuildQueueItemRendererWatcherSetupUtil", "_GUI_Components_ItemRenderer_ChannelBarItemRendererWatcherSetupUtil", "_GUI_Components_ItemRenderer_FriendsListNullItemRendererWatcherSetupUtil", "_GUI_Components_ItemRenderer_StarMenuNullItemRendererWatcherSetupUtil", "_GUI_Components_ItemRenderer_FriendsListItemRendererWatcherSetupUtil", "_GUI_Components_ActionBarLeftWatcherSetupUtil", "_GUI_Components_ActionBarRightWatcherSetupUtil", "_GUI_Components_ItemRenderer_BuildingsListItemRendererWatcherSetupUtil", "_GUI_Components_ActionBarCenterWatcherSetupUtil", "_GUI_Components_ItemRenderer_QuestTriggerListItemRendererWatcherSetupUtil", "_GUI_Components_AdventureDifficultyIndicatorWatcherSetupUtil", "_GUI_Components_ItemRenderer_AvatarListItemRendererWatcherSetupUtil", "_GUI_Components_ItemRenderer_QuestListItemRendererWatcherSetupUtil", "_GUI_Components_FriendsListButtonBarWatcherSetupUtil", "_GUI_Components_ItemRenderer_AvatarMessageItemRendererWatcherSetupUtil", "_GUI_Components_ItemRenderer_ChatTabPrivateListItemRendererWatcherSetupUtil", "_GUI_Components_ProgressBarWatcherSetupUtil", "_GUI_Components_BattleHealthBarWatcherSetupUtil", "_GUI_Components_FriendsListFilterSelectorWatcherSetupUtil", "_GUI_Components_ItemRenderer_BattleSlotItemRendererWatcherSetupUtil", "_GUI_Components_QuestPointerWatcherSetupUtil", "_GUI_Components_ItemRenderer_OrderItemRendererWatcherSetupUtil", "_GUI_Components_ToolTips_MultilineTipWatcherSetupUtil", "_GUI_Components_ToolTips_SimpleErrorTipWatcherSetupUtil", "_GUI_Components_ToolTips_IconMultilineTipWatcherSetupUtil", "_GUI_Components_ToolTips_BuildingsListTipWatcherSetupUtil", "_GUI_Components_ToolTips_PopulationOverviewTipWatcherSetupUtil", "_GUI_Components_ToolTips_SimpleTipWatcherSetupUtil", "_GUI_Components_BasicPanelWatcherSetupUtil", "_GUI_Components_ItemRenderer_StarMenuItemRendererWatcherSetupUtil", "_GUI_Components_ItemRenderer_BuySpecialistItemRendererWatcherSetupUtil", "_GUI_Components_BuildQueueExtensionWatcherSetupUtil", "_GUI_Components_ItemRenderer_QuestListGroupItemRendererWatcherSetupUtil", "_GUI_Components_ItemRenderer_ShopItemRendererWatcherSetupUtil", "_GUI_Components_ItemRenderer_SpecialistTravelItemRendererWatcherSetupUtil", "_GUI_Components_DailyLoginPanelWatcherSetupUtil", "_GUI_Components_ExtendedHSliderWatcherSetupUtil", "_GUI_Components_ItemRenderer_ManageArmyItemRendererWatcherSetupUtil", "_GUI_Components_CancelActionPanelWatcherSetupUtil", "_GUI_Components_FoundGuildPanelWatcherSetupUtil", "_GUI_Components_HealthBarWatcherSetupUtil", "_GUI_Components_MemoryMonitorPanelWatcherSetupUtil", "_GUI_Components_TimedProductionInfoPanelWatcherSetupUtil", "_GUI_Components_TextEditorWatcherSetupUtil", "_GUI_Components_SpecialistPanelWatcherSetupUtil", "_GUI_Components_InfoBarWatcherSetupUtil", "_GUI_Components_BuildingsListWatcherSetupUtil", "_GUI_Components_ConstructionInfoPanelWatcherSetupUtil", "_GUI_Components_HintPointerWatcherSetupUtil", "_GUI_Components_SpecialistCooldownPanelWatcherSetupUtil", "_GUI_Components_OptionsPanelWatcherSetupUtil", "_GUI_Components_FriendsListWatcherSetupUtil", "_GUI_Components_AddFriendsPanelWatcherSetupUtil", "_GUI_Components_SpecialistTravelPanelWatcherSetupUtil", "_GUI_Components_BuildQueueWatcherSetupUtil", "_GUI_Components_ShopWindowWatcherSetupUtil", "_GUI_Components_QuestBookWatcherSetupUtil", "_GUI_Components_AdventurePanelWatcherSetupUtil", "_GUI_Components_MysteryBoxPanelWatcherSetupUtil", "_GUI_Components_DecorationInfoPanelWatcherSetupUtil", "_GUI_Components_TavernInfoPanelWatcherSetupUtil", "_GUI_Components_ActionBarWatcherSetupUtil", "_GUI_Components_LoadingZonePanelWatcherSetupUtil", "_GUI_Components_MinimalInfoPanelWatcherSetupUtil", "_GUI_Components_LegalPanelWatcherSetupUtil", "_GUI_Components_StarMenuWatcherSetupUtil", "_GUI_Components_AvatarWatcherSetupUtil", "_GUI_Components_BuildingInfoPanelWatcherSetupUtil", "_GUI_Components_CheatWindow_inlineComponent1WatcherSetupUtil", "_GUI_Components_TradingPanelWatcherSetupUtil", "_GUI_Components_WatchTowerInfoPanelWatcherSetupUtil", "_GUI_Components_ResidenceInfoPanelWatcherSetupUtil", "_GUI_Components_WarehouseInfoPanelWatcherSetupUtil", "_GUI_Components_NewsWindowWatcherSetupUtil", "_GUI_Components_MailWindowWatcherSetupUtil", "_GUI_Components_BattleWindowWatcherSetupUtil", "_GUI_Components_GuildWindowWatcherSetupUtil", "_GUI_Components_CameraControlPanelWatcherSetupUtil", "_SWMMOWatcherSetupUtil", "_GUI_Components_ChatPanelWatcherSetupUtil"], mouseDown:"mouseDown(event)", mouseMove:"mouseMove(event)", mouseOut:"mouseOut(event)", mouseUp:"mouseUp(event)", paddingBottom:"0", paddingLeft:"0", paddingRight:"0", paddingTop:"0", verticalPageScrollSize:"0", verticalScrollPolicy:"off", verticalScrollPosition:"0"};
        }// end function

        override public function get preloadedRSLs() : Dictionary
        {
            if (this._preloadedRSLs == null)
            {
                this._preloadedRSLs = new Dictionary(true);
            }
            return this._preloadedRSLs;
        }// end function

        override public function allowDomain(... args) : void
        {
            args = null;
            Security.allowDomain(args);
            for (args in this._preloadedRSLs)
            {
                
                if (args.content && "allowDomainInRSL" in args.content)
                {
                    var _loc_5:* = args.content;
                    _loc_5.args.content["allowDomainInRSL"](args);
                }
            }
            return;
        }// end function

    }
}
