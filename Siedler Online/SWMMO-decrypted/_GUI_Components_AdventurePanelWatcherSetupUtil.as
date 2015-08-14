package 
{
    import Enums.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_AdventurePanelWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_AdventurePanelWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            var target:* = param1;
            var propertyGetter:* = param2;
            var bindings:* = param3;
            var watchers:* = param4;
            watchers[8] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[5]], null);
            watchers[9] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "StartAdventure"];
            }// end function
            , {languageChanged:true}, [bindings[5]], null);
            watchers[10] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[6]], null);
            watchers[11] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "Cancel"];
            }// end function
            , {languageChanged:true}, [bindings[6]], null);
            watchers[6] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[4]], null);
            watchers[7] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "AttendingPlayers"];
            }// end function
            , {languageChanged:true}, [bindings[4]], null);
            watchers[12] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[7]], null);
            watchers[13] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "OK"];
            }// end function
            , {languageChanged:true}, [bindings[7]], null);
            watchers[0] = new PropertyWatcher("fadeIn", {propertyChange:true}, [bindings[0]], propertyGetter);
            watchers[14] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[8]], null);
            watchers[15] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "ReturnHome"];
            }// end function
            , {languageChanged:true}, [bindings[8]], null);
            watchers[3] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[3]], null);
            watchers[4] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "Mission"];
            }// end function
            , {languageChanged:true}, [bindings[3]], null);
            watchers[1] = new PropertyWatcher("fadeOut", {propertyChange:true}, [bindings[1]], propertyGetter);
            watchers[2] = new PropertyWatcher("label", {labelChanged:true}, [bindings[2]], propertyGetter);
            watchers[8].updateParent(cLocaManager);
            watchers[9].parentWatcher = watchers[8];
            watchers[8].addChild(watchers[9]);
            watchers[10].updateParent(cLocaManager);
            watchers[11].parentWatcher = watchers[10];
            watchers[10].addChild(watchers[11]);
            watchers[6].updateParent(cLocaManager);
            watchers[7].parentWatcher = watchers[6];
            watchers[6].addChild(watchers[7]);
            watchers[12].updateParent(cLocaManager);
            watchers[13].parentWatcher = watchers[12];
            watchers[12].addChild(watchers[13]);
            watchers[0].updateParent(target);
            watchers[14].updateParent(cLocaManager);
            watchers[15].parentWatcher = watchers[14];
            watchers[14].addChild(watchers[15]);
            watchers[3].updateParent(cLocaManager);
            watchers[4].parentWatcher = watchers[3];
            watchers[3].addChild(watchers[4]);
            watchers[1].updateParent(target);
            watchers[2].updateParent(target);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            AdventurePanel.watcherSetupUtil = new _GUI_Components_AdventurePanelWatcherSetupUtil;
            return;
        }// end function

    }
}
