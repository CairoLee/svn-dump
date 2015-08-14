package 
{
    import GUI.Components.*;
    import GUI.Loca.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_TavernInfoPanelWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_TavernInfoPanelWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            var target:* = param1;
            var propertyGetter:* = param2;
            var bindings:* = param3;
            var watchers:* = param4;
            watchers[9] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[4]], null);
            watchers[10] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "BuildingIntegrity"];
            }// end function
            , {languageChanged:true}, [bindings[4]], null);
            watchers[13] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[7]], null);
            watchers[14] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "Repair"];
            }// end function
            , {languageChanged:true}, [bindings[7]], null);
            watchers[5] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[2]], null);
            watchers[6] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "NotPossible"];
            }// end function
            , {languageChanged:true}, [bindings[2]], null);
            watchers[0] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[0]], null);
            watchers[1] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "Upgrade"];
            }// end function
            , {languageChanged:true}, [bindings[0]], null);
            watchers[3] = new PropertyWatcher("upgradeTime", {propertyChange:true}, [bindings[1]], propertyGetter);
            watchers[4] = new PropertyWatcher("visible", {hide:true, show:true}, [bindings[1]], null);
            watchers[9].updateParent(cLocaManager);
            watchers[10].parentWatcher = watchers[9];
            watchers[9].addChild(watchers[10]);
            watchers[13].updateParent(cLocaManager);
            watchers[14].parentWatcher = watchers[13];
            watchers[13].addChild(watchers[14]);
            watchers[5].updateParent(cLocaManager);
            watchers[6].parentWatcher = watchers[5];
            watchers[5].addChild(watchers[6]);
            watchers[0].updateParent(cLocaManager);
            watchers[1].parentWatcher = watchers[0];
            watchers[0].addChild(watchers[1]);
            watchers[3].updateParent(target);
            watchers[3].addChild(watchers[4]);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            TavernInfoPanel.watcherSetupUtil = new _GUI_Components_TavernInfoPanelWatcherSetupUtil;
            return;
        }// end function

    }
}
