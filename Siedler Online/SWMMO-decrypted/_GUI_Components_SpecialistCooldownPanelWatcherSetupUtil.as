package 
{
    import Enums.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_SpecialistCooldownPanelWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_SpecialistCooldownPanelWatcherSetupUtil()
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
            , null, [bindings[7]], null);
            watchers[10] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "OK"];
            }// end function
            , {languageChanged:true}, [bindings[7]], null);
            watchers[2] = new PropertyWatcher("loca", {propertyChange:true}, [bindings[2], bindings[4], bindings[6]], propertyGetter);
            watchers[3] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "ProductionStatus"];
            }// end function
            , {languageChanged:true}, [bindings[2]], null);
            watchers[6] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "NotAvailableText"];
            }// end function
            , {languageChanged:true}, [bindings[4]], null);
            watchers[8] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "HalfTheTime"];
            }// end function
            , {languageChanged:true}, [bindings[6]], null);
            watchers[0] = new PropertyWatcher("fadeIn", {propertyChange:true}, [bindings[0]], propertyGetter);
            watchers[1] = new PropertyWatcher("fadeOut", {propertyChange:true}, [bindings[1]], propertyGetter);
            watchers[9].updateParent(cLocaManager);
            watchers[10].parentWatcher = watchers[9];
            watchers[9].addChild(watchers[10]);
            watchers[2].updateParent(target);
            watchers[3].parentWatcher = watchers[2];
            watchers[2].addChild(watchers[3]);
            watchers[6].parentWatcher = watchers[2];
            watchers[2].addChild(watchers[6]);
            watchers[8].parentWatcher = watchers[2];
            watchers[2].addChild(watchers[8]);
            watchers[0].updateParent(target);
            watchers[1].updateParent(target);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            SpecialistCooldownPanel.watcherSetupUtil = new _GUI_Components_SpecialistCooldownPanelWatcherSetupUtil;
            return;
        }// end function

    }
}
