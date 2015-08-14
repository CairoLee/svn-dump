package 
{
    import Enums.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_TimedProductionInfoPanelWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_TimedProductionInfoPanelWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            var target:* = param1;
            var propertyGetter:* = param2;
            var bindings:* = param3;
            var watchers:* = param4;
            watchers[4] = new PropertyWatcher("subcontent", {propertyChange:true}, [bindings[4]], propertyGetter);
            watchers[8] = new PropertyWatcher("amountSlider", {propertyChange:true}, [bindings[6], bindings[7]], propertyGetter);
            watchers[11] = new PropertyWatcher("enabled", {enabledChanged:true}, [bindings[7]], null);
            watchers[10] = new PropertyWatcher("maximum", {change:true}, [bindings[6]], null);
            watchers[9] = new PropertyWatcher("value", {valueCommit:true, change:true}, [bindings[6]], null);
            watchers[16] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[10]], null);
            watchers[17] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "Upgrade"];
            }// end function
            , {languageChanged:true}, [bindings[10]], null);
            watchers[27] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[16]], null);
            watchers[28] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "BuildingIntegrity"];
            }// end function
            , {languageChanged:true}, [bindings[16]], null);
            watchers[1] = new PropertyWatcher("middleColumn", {propertyChange:true}, [bindings[1]], propertyGetter);
            watchers[0] = new PropertyWatcher("btnOK", {propertyChange:true}, [bindings[0]], propertyGetter);
            watchers[18] = new PropertyWatcher("upgradeTime", {propertyChange:true}, [bindings[11]], propertyGetter);
            watchers[19] = new PropertyWatcher("visible", {hide:true, show:true}, [bindings[11]], null);
            watchers[3] = new PropertyWatcher("currentOrdersList", {propertyChange:true}, [bindings[3]], propertyGetter);
            watchers[20] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[12]], null);
            watchers[21] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.DESCRIPTIONS, "NotPossible"];
            }// end function
            , {languageChanged:true}, [bindings[12]], null);
            watchers[5] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[5]], null);
            watchers[6] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "Select"];
            }// end function
            , {languageChanged:true}, [bindings[5]], null);
            watchers[12] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[8]], null);
            watchers[13] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "OK"];
            }// end function
            , {languageChanged:true}, [bindings[8]], null);
            watchers[24] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[14]], null);
            watchers[25] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "ComingSoon"];
            }// end function
            , {languageChanged:true}, [bindings[14]], null);
            watchers[2] = new PropertyWatcher("listBackground", {propertyChange:true}, [bindings[2]], propertyGetter);
            watchers[14] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[9]], null);
            watchers[15] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "Cancel"];
            }// end function
            , {languageChanged:true}, [bindings[9]], null);
            watchers[31] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[19]], null);
            watchers[32] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "Repair"];
            }// end function
            , {languageChanged:true}, [bindings[19]], null);
            watchers[33] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[20]], null);
            watchers[34] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "Select"];
            }// end function
            , {languageChanged:true}, [bindings[20]], null);
            watchers[4].updateParent(target);
            watchers[8].updateParent(target);
            watchers[8].addChild(watchers[11]);
            watchers[8].addChild(watchers[10]);
            watchers[8].addChild(watchers[9]);
            watchers[16].updateParent(cLocaManager);
            watchers[17].parentWatcher = watchers[16];
            watchers[16].addChild(watchers[17]);
            watchers[27].updateParent(cLocaManager);
            watchers[28].parentWatcher = watchers[27];
            watchers[27].addChild(watchers[28]);
            watchers[1].updateParent(target);
            watchers[0].updateParent(target);
            watchers[18].updateParent(target);
            watchers[18].addChild(watchers[19]);
            watchers[3].updateParent(target);
            watchers[20].updateParent(cLocaManager);
            watchers[21].parentWatcher = watchers[20];
            watchers[20].addChild(watchers[21]);
            watchers[5].updateParent(cLocaManager);
            watchers[6].parentWatcher = watchers[5];
            watchers[5].addChild(watchers[6]);
            watchers[12].updateParent(cLocaManager);
            watchers[13].parentWatcher = watchers[12];
            watchers[12].addChild(watchers[13]);
            watchers[24].updateParent(cLocaManager);
            watchers[25].parentWatcher = watchers[24];
            watchers[24].addChild(watchers[25]);
            watchers[2].updateParent(target);
            watchers[14].updateParent(cLocaManager);
            watchers[15].parentWatcher = watchers[14];
            watchers[14].addChild(watchers[15]);
            watchers[31].updateParent(cLocaManager);
            watchers[32].parentWatcher = watchers[31];
            watchers[31].addChild(watchers[32]);
            watchers[33].updateParent(cLocaManager);
            watchers[34].parentWatcher = watchers[33];
            watchers[33].addChild(watchers[34]);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            TimedProductionInfoPanel.watcherSetupUtil = new _GUI_Components_TimedProductionInfoPanelWatcherSetupUtil;
            return;
        }// end function

    }
}
