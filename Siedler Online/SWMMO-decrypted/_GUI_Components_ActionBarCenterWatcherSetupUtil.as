package 
{
    import GUI.Components.*;
    import GUI.Loca.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_ActionBarCenterWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_ActionBarCenterWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            var target:* = param1;
            var propertyGetter:* = param2;
            var bindings:* = param3;
            var watchers:* = param4;
            watchers[4] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[4]], null);
            watchers[5] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "StarMenu"];
            }// end function
            , {languageChanged:true}, [bindings[4]], null);
            watchers[4].updateParent(cLocaManager);
            watchers[5].parentWatcher = watchers[4];
            watchers[4].addChild(watchers[5]);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            ActionBarCenter.watcherSetupUtil = new _GUI_Components_ActionBarCenterWatcherSetupUtil;
            return;
        }// end function

    }
}
