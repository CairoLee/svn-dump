package 
{
    import GUI.Components.*;
    import GUI.Loca.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_LoadingZonePanelWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_LoadingZonePanelWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            var target:* = param1;
            var propertyGetter:* = param2;
            var bindings:* = param3;
            var watchers:* = param4;
            watchers[0] = new PropertyWatcher("fadeIn", {propertyChange:true}, [bindings[0]], propertyGetter);
            watchers[2] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[2]], null);
            watchers[3] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "LoadingZone"];
            }// end function
            , {languageChanged:true}, [bindings[2]], null);
            watchers[1] = new PropertyWatcher("fadeOut", {propertyChange:true}, [bindings[1]], propertyGetter);
            watchers[0].updateParent(target);
            watchers[2].updateParent(cLocaManager);
            watchers[3].parentWatcher = watchers[2];
            watchers[2].addChild(watchers[3]);
            watchers[1].updateParent(target);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            LoadingZonePanel.watcherSetupUtil = new _GUI_Components_LoadingZonePanelWatcherSetupUtil;
            return;
        }// end function

    }
}
