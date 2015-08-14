package GUI.Components.ToolTips
{
    import flash.events.*;
    import flash.geom.*;
    import flash.utils.*;
    import mx.core.*;
    import mx.events.*;

    public class cToolTipUtil extends Object
    {
        private var dummy10:SimpleErrorTip;
        private var dummy11:BuffTip;
        private var dummy12:MultilineTip;
        private var dummy13:InstantBuildTip;
        private var dummy3:UpgradeBuildingTip;
        private var dummy4:DemolishBuildingTip;
        private var dummy5:BuildQueueItemTip;
        private var dummy6:PopulationOverviewTip;
        private var dummy7:MilitaryUnitTip;
        private var dummy1:SimpleTip;
        private var dummy2:BuildingsListTip;
        private var dummy15:ProductionDurationTip;
        private var dummy8:ShopItemTip;
        private var dummy9:SpecialistTip;
        private var dummy14:TimedProductionOrderTip;
        private var dummy16:SendArmyTip;
        private var dummy17:MilitaryUnitExtendedTip;
        private var dummy19:MoveBuildingTip;
        private var dummy21:ShopItemWithCostsTip;
        private var dummy18:IconMultilineTip;
        private var dummy20:TrackedMissionTip;
        public static const DEMOLISH_BUILDING_string:String = "DemolishBuilding";
        public static const MULTILINE_string:String = "Multiline";
        public static const SIMPLE_string:String = "Simple";
        public static const UPGRADE_BUILDING_string:String = "UpgradeBuilding";
        public static const MILITARY_UNIT_EXTENDED_string:String = "MilitaryUnitExtended";
        public static const SEND_ARMY:String = "SendArmy";
        public static const TRACKED_MISSION_string:String = "TrackedMission";
        public static const PRODUCTION_DURATION:String = "ProductionDuration";
        public static const MOVE_BUILDING_string:String = "MoveBuilding";
        public static const SPECIALIST_string:String = "Specialist";
        public static const SHOP_ITEM_WITH_COSTS_string:String = "ShopItemWithCosts";
        public static const BUILDQUEUE_ITEM_string:String = "BuildQueueItem";
        public static const POPULATION_OVERVIEW_string:String = "PopulationOverview";
        public static const INSTANT_BUILD_string:String = "InstantBuild";
        public static const ICON_MULTILINE:String = "IconMultiline";
        public static const TIMED_PRODUCTION_ORDER_string:String = "TimedProductionOrder";
        public static const BUILDINGS_LIST_string:String = "BuildingsList";
        public static const SHOP_ITEM_string:String = "ShopItem";
        public static const SIMPLE_ERROR_string:String = "SimpleError";
        public static const MILITARY_UNIT_string:String = "MilitaryUnit";
        public static const BUFF_string:String = "Buff";

        public function cToolTipUtil()
        {
            return;
        }// end function

        public static function createToolTip(param1:String, param2:ToolTipEvent, param3:Object = null) : void
        {
            var _loc_5:IDataToolTip = null;
            var _loc_6:IToolTip = null;
            var _loc_4:* = getDefinitionByName("GUI.Components.ToolTips." + param1 + "Tip") as Class;
            if (param3)
            {
                _loc_5 = new _loc_4;
                _loc_5.addEventListener(Event.RESIZE, fixPosition);
                _loc_5.toolTipData = param3;
                param2.toolTip = _loc_5;
            }
            else
            {
                _loc_6 = new _loc_4;
                _loc_6.addEventListener(Event.RESIZE, fixPosition);
                param2.toolTip = _loc_6;
            }
            return;
        }// end function

        private static function fixPosition(event:Event) : void
        {
            var _loc_2:* = event.currentTarget as UIComponent;
            if (_loc_2.x + _loc_2.width > _loc_2.stage.stageWidth)
            {
                _loc_2.x = _loc_2.stage.stageWidth - _loc_2.width;
            }
            if (_loc_2.x < 0)
            {
                _loc_2.x = 0;
            }
            if (_loc_2.y < 0)
            {
                _loc_2.y = 0;
            }
            if (_loc_2.y + _loc_2.height > _loc_2.stage.stageHeight)
            {
                _loc_2.y = _loc_2.stage.stageHeight - _loc_2.height;
            }
            return;
        }// end function

        public static function positionActionBarTip(event:ToolTipEvent) : void
        {
            var _loc_2:* = event.currentTarget as UIComponent;
            var _loc_3:* = new Point();
            _loc_3 = _loc_2.contentToGlobal(_loc_3);
            event.toolTip.x = _loc_3.x + Math.floor((_loc_2.width - event.toolTip.width) / 2);
            event.toolTip.y = _loc_3.y - 25;
            return;
        }// end function

    }
}
