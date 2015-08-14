package 
{
    import Enums.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_WatchTowerInfoPanelWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_WatchTowerInfoPanelWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            var target:* = param1;
            var propertyGetter:* = param2;
            var bindings:* = param3;
            var watchers:* = param4;
            watchers[2] = new PropertyWatcher("subcontent", {propertyChange:true}, [bindings[2], bindings[3]], propertyGetter);
            watchers[0] = new PropertyWatcher("leftColumn", {propertyChange:true}, [bindings[0]], propertyGetter);
            watchers[1] = new PropertyWatcher("rightColumn", {propertyChange:true}, [bindings[1]], propertyGetter);
            watchers[16] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[10]], null);
            watchers[17] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "BuildingIntegrity"];
            }// end function
            , {languageChanged:true}, [bindings[10]], null);
            watchers[10] = new PropertyWatcher("upgradeTime", {propertyChange:true}, [bindings[7]], propertyGetter);
            watchers[11] = new PropertyWatcher("visible", {hide:true, show:true}, [bindings[7]], null);
            watchers[22] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[14]], null);
            watchers[23] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "Army"];
            }// end function
            , {languageChanged:true}, [bindings[14]], null);
            watchers[20] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[13]], null);
            watchers[21] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "Repair"];
            }// end function
            , {languageChanged:true}, [bindings[13]], null);
            watchers[8] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[6]], null);
            watchers[9] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "Upgrade"];
            }// end function
            , {languageChanged:true}, [bindings[6]], null);
            watchers[26] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[16]], null);
            watchers[27] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "ManageArmy"];
            }// end function
            , {languageChanged:true}, [bindings[16]], null);
            watchers[6] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[5]], null);
            watchers[7] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "Cancel"];
            }// end function
            , {languageChanged:true}, [bindings[5]], null);
            watchers[12] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[8]], null);
            watchers[13] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "NotPossible"];
            }// end function
            , {languageChanged:true}, [bindings[8]], null);
            watchers[24] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[15]], null);
            watchers[25] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "ManageArmy"];
            }// end function
            , {languageChanged:true}, [bindings[15]], null);
            watchers[3] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[4]], null);
            watchers[4] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "OK"];
            }// end function
            , {languageChanged:true}, [bindings[4]], null);
            watchers[2].updateParent(target);
            watchers[0].updateParent(target);
            watchers[1].updateParent(target);
            watchers[16].updateParent(cLocaManager);
            watchers[17].parentWatcher = watchers[16];
            watchers[16].addChild(watchers[17]);
            watchers[10].updateParent(target);
            watchers[10].addChild(watchers[11]);
            watchers[22].updateParent(cLocaManager);
            watchers[23].parentWatcher = watchers[22];
            watchers[22].addChild(watchers[23]);
            watchers[20].updateParent(cLocaManager);
            watchers[21].parentWatcher = watchers[20];
            watchers[20].addChild(watchers[21]);
            watchers[8].updateParent(cLocaManager);
            watchers[9].parentWatcher = watchers[8];
            watchers[8].addChild(watchers[9]);
            watchers[26].updateParent(cLocaManager);
            watchers[27].parentWatcher = watchers[26];
            watchers[26].addChild(watchers[27]);
            watchers[6].updateParent(cLocaManager);
            watchers[7].parentWatcher = watchers[6];
            watchers[6].addChild(watchers[7]);
            watchers[12].updateParent(cLocaManager);
            watchers[13].parentWatcher = watchers[12];
            watchers[12].addChild(watchers[13]);
            watchers[24].updateParent(cLocaManager);
            watchers[25].parentWatcher = watchers[24];
            watchers[24].addChild(watchers[25]);
            watchers[3].updateParent(cLocaManager);
            watchers[4].parentWatcher = watchers[3];
            watchers[3].addChild(watchers[4]);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            WatchTowerInfoPanel.watcherSetupUtil = new _GUI_Components_WatchTowerInfoPanelWatcherSetupUtil;
            return;
        }// end function

    }
}
