package 
{
    import GUI.Components.*;
    import GUI.Loca.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_ResidenceInfoPanelWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_ResidenceInfoPanelWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            var target:* = param1;
            var propertyGetter:* = param2;
            var bindings:* = param3;
            var watchers:* = param4;
            watchers[17] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[10]], null);
            watchers[18] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "Repair"];
            }// end function
            , {languageChanged:true}, [bindings[10]], null);
            watchers[19] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[11]], null);
            watchers[20] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "Capacity"];
            }// end function
            , {languageChanged:true}, [bindings[11]], null);
            watchers[4] = new PropertyWatcher("upgradeTime", {propertyChange:true}, [bindings[2]], propertyGetter);
            watchers[5] = new PropertyWatcher("visible", {hide:true, show:true}, [bindings[2]], null);
            watchers[10] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[5]], null);
            watchers[11] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "ComingSoon"];
            }// end function
            , {languageChanged:true}, [bindings[5]], null);
            watchers[6] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[3]], null);
            watchers[7] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "NotPossible"];
            }// end function
            , {languageChanged:true}, [bindings[3]], null);
            watchers[13] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[7]], null);
            watchers[14] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "BuildingIntegrity"];
            }// end function
            , {languageChanged:true}, [bindings[7]], null);
            watchers[1] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[1]], null);
            watchers[2] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "Upgrade"];
            }// end function
            , {languageChanged:true}, [bindings[1]], null);
            watchers[17].updateParent(cLocaManager);
            watchers[18].parentWatcher = watchers[17];
            watchers[17].addChild(watchers[18]);
            watchers[19].updateParent(cLocaManager);
            watchers[20].parentWatcher = watchers[19];
            watchers[19].addChild(watchers[20]);
            watchers[4].updateParent(target);
            watchers[4].addChild(watchers[5]);
            watchers[10].updateParent(cLocaManager);
            watchers[11].parentWatcher = watchers[10];
            watchers[10].addChild(watchers[11]);
            watchers[6].updateParent(cLocaManager);
            watchers[7].parentWatcher = watchers[6];
            watchers[6].addChild(watchers[7]);
            watchers[13].updateParent(cLocaManager);
            watchers[14].parentWatcher = watchers[13];
            watchers[13].addChild(watchers[14]);
            watchers[1].updateParent(cLocaManager);
            watchers[2].parentWatcher = watchers[1];
            watchers[1].addChild(watchers[2]);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            ResidenceInfoPanel.watcherSetupUtil = new _GUI_Components_ResidenceInfoPanelWatcherSetupUtil;
            return;
        }// end function

    }
}
