package 
{
    import Enums.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_NewsWindowWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_NewsWindowWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            var target:* = param1;
            var propertyGetter:* = param2;
            var bindings:* = param3;
            var watchers:* = param4;
            watchers[7] = new PropertyWatcher("showTip", {propertyChange:true}, [bindings[5]], propertyGetter);
            watchers[9] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[7]], null);
            watchers[10] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "LatestChanges"];
            }// end function
            , {languageChanged:true}, [bindings[7]], null);
            watchers[0] = new PropertyWatcher("fadeIn", {propertyChange:true}, [bindings[0]], propertyGetter);
            watchers[3] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[3]], null);
            watchers[4] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "TipOfTheDay"];
            }// end function
            , {languageChanged:true}, [bindings[3]], null);
            watchers[2] = new PropertyWatcher("loadingLabel", {propertyChange:true}, [bindings[2]], propertyGetter);
            watchers[1] = new PropertyWatcher("fadeOut", {propertyChange:true}, [bindings[1]], propertyGetter);
            watchers[8] = new PropertyWatcher("hideTip", {propertyChange:true}, [bindings[6]], propertyGetter);
            watchers[7].updateParent(target);
            watchers[9].updateParent(cLocaManager);
            watchers[10].parentWatcher = watchers[9];
            watchers[9].addChild(watchers[10]);
            watchers[0].updateParent(target);
            watchers[3].updateParent(cLocaManager);
            watchers[4].parentWatcher = watchers[3];
            watchers[3].addChild(watchers[4]);
            watchers[2].updateParent(target);
            watchers[1].updateParent(target);
            watchers[8].updateParent(target);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            NewsWindow.watcherSetupUtil = new _GUI_Components_NewsWindowWatcherSetupUtil;
            return;
        }// end function

    }
}
