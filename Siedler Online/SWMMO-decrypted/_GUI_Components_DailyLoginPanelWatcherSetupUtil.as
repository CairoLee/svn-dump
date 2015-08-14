package 
{
    import Enums.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_DailyLoginPanelWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_DailyLoginPanelWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            var target:* = param1;
            var propertyGetter:* = param2;
            var bindings:* = param3;
            var watchers:* = param4;
            watchers[1] = new PropertyWatcher("fadeOut", {propertyChange:true}, [bindings[1]], propertyGetter);
            watchers[17] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[10]], null);
            watchers[18] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "DailyLoginDay", ["6"]];
            }// end function
            , {languageChanged:true}, [bindings[10]], null);
            watchers[3] = new PropertyWatcher("label", {labelChanged:true}, [bindings[3]], propertyGetter);
            watchers[19] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[11]], null);
            watchers[20] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "DailyLoginDay", ["7"]];
            }// end function
            , {languageChanged:true}, [bindings[11]], null);
            watchers[21] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[12]], null);
            watchers[22] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "OK"];
            }// end function
            , {languageChanged:true}, [bindings[12]], null);
            watchers[9] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[6]], null);
            watchers[10] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "DailyLoginDay", ["2"]];
            }// end function
            , {languageChanged:true}, [bindings[6]], null);
            watchers[11] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[7]], null);
            watchers[12] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "DailyLoginDay", ["3"]];
            }// end function
            , {languageChanged:true}, [bindings[7]], null);
            watchers[7] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[5]], null);
            watchers[8] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "DailyLoginDay", ["1"]];
            }// end function
            , {languageChanged:true}, [bindings[5]], null);
            watchers[13] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[8]], null);
            watchers[14] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "DailyLoginDay", ["4"]];
            }// end function
            , {languageChanged:true}, [bindings[8]], null);
            watchers[0] = new PropertyWatcher("fadeIn", {propertyChange:true}, [bindings[0]], propertyGetter);
            watchers[4] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[4]], null);
            watchers[5] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "Rewards"];
            }// end function
            , {languageChanged:true}, [bindings[4]], null);
            watchers[15] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[9]], null);
            watchers[16] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "DailyLoginDay", ["5"]];
            }// end function
            , {languageChanged:true}, [bindings[9]], null);
            watchers[1].updateParent(target);
            watchers[17].updateParent(cLocaManager);
            watchers[18].parentWatcher = watchers[17];
            watchers[17].addChild(watchers[18]);
            watchers[3].updateParent(target);
            watchers[19].updateParent(cLocaManager);
            watchers[20].parentWatcher = watchers[19];
            watchers[19].addChild(watchers[20]);
            watchers[21].updateParent(cLocaManager);
            watchers[22].parentWatcher = watchers[21];
            watchers[21].addChild(watchers[22]);
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
            watchers[0].updateParent(target);
            watchers[4].updateParent(cLocaManager);
            watchers[5].parentWatcher = watchers[4];
            watchers[4].addChild(watchers[5]);
            watchers[15].updateParent(cLocaManager);
            watchers[16].parentWatcher = watchers[15];
            watchers[15].addChild(watchers[16]);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            DailyLoginPanel.watcherSetupUtil = new _GUI_Components_DailyLoginPanelWatcherSetupUtil;
            return;
        }// end function

    }
}
