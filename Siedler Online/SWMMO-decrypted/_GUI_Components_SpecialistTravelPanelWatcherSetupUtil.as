package 
{
    import GUI.Components.*;
    import GUI.Loca.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_SpecialistTravelPanelWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_SpecialistTravelPanelWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            var target:* = param1;
            var propertyGetter:* = param2;
            var bindings:* = param3;
            var watchers:* = param4;
            watchers[5] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[2]], null);
            watchers[6] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "Cancel"];
            }// end function
            , {languageChanged:true}, [bindings[2]], null);
            watchers[3] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[1]], null);
            watchers[4] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "OK"];
            }// end function
            , {languageChanged:true}, [bindings[1]], null);
            watchers[0] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[0]], null);
            watchers[1] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "Duration"];
            }// end function
            , {languageChanged:true}, [bindings[0]], null);
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
            SpecialistTravelPanel.watcherSetupUtil = new _GUI_Components_SpecialistTravelPanelWatcherSetupUtil;
            return;
        }// end function

    }
}
