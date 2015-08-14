package 
{
    import Enums.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_OptionsPanelWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_OptionsPanelWatcherSetupUtil()
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
            , null, [bindings[6]], null);
            watchers[10] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "Forum"];
            }// end function
            , {languageChanged:true}, [bindings[6]], null);
            watchers[11] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[7]], null);
            watchers[12] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "OptionsExpandCollapse"];
            }// end function
            , {languageChanged:true}, [bindings[7]], null);
            watchers[7] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[5]], null);
            watchers[8] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "Support"];
            }// end function
            , {languageChanged:true}, [bindings[5]], null);
            watchers[13] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[8]], null);
            watchers[14] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "Logout"];
            }// end function
            , {languageChanged:true}, [bindings[8]], null);
            watchers[5] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[4]], null);
            watchers[6] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "ToggleCameraPanel"];
            }// end function
            , {languageChanged:true}, [bindings[4]], null);
            watchers[3] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[3]], null);
            watchers[4] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "ToggleSoundEffects"];
            }// end function
            , {languageChanged:true}, [bindings[3]], null);
            watchers[0] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[2]], null);
            watchers[1] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "ToggleSoundLoop"];
            }// end function
            , {languageChanged:true}, [bindings[2]], null);
            watchers[9].updateParent(cLocaManager);
            watchers[10].parentWatcher = watchers[9];
            watchers[9].addChild(watchers[10]);
            watchers[11].updateParent(cLocaManager);
            watchers[12].parentWatcher = watchers[11];
            watchers[11].addChild(watchers[12]);
            watchers[7].updateParent(cLocaManager);
            watchers[8].parentWatcher = watchers[7];
            watchers[7].addChild(watchers[8]);
            watchers[13].updateParent(cLocaManager);
            watchers[14].parentWatcher = watchers[13];
            watchers[13].addChild(watchers[14]);
            watchers[5].updateParent(cLocaManager);
            watchers[6].parentWatcher = watchers[5];
            watchers[5].addChild(watchers[6]);
            watchers[3].updateParent(cLocaManager);
            watchers[4].parentWatcher = watchers[3];
            watchers[3].addChild(watchers[4]);
            watchers[0].updateParent(cLocaManager);
            watchers[1].parentWatcher = watchers[0];
            watchers[0].addChild(watchers[1]);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            OptionsPanel.watcherSetupUtil = new _GUI_Components_OptionsPanelWatcherSetupUtil;
            return;
        }// end function

    }
}
