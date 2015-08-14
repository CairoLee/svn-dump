package 
{
    import Enums.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_LegalPanelWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_LegalPanelWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            var target:* = param1;
            var propertyGetter:* = param2;
            var bindings:* = param3;
            var watchers:* = param4;
            watchers[10] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[6]], null);
            watchers[11] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.DESCRIPTIONS, "LegalInfo"];
            }// end function
            , {languageChanged:true}, [bindings[6]], null);
            watchers[7] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[5]], null);
            watchers[8] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.DESCRIPTIONS, "LegalInfo"];
            }// end function
            , {languageChanged:true}, [bindings[5]], null);
            watchers[12] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[7]], null);
            watchers[13] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "IAgree"];
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
                return [null, "IDisagree"];
            }// end function
            , {languageChanged:true}, [bindings[8]], null);
            watchers[3] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[3]], null);
            watchers[4] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "LegalTerms"];
            }// end function
            , {languageChanged:true}, [bindings[3]], null);
            watchers[1] = new PropertyWatcher("fadeOut", {propertyChange:true}, [bindings[1]], propertyGetter);
            watchers[10].updateParent(cLocaManager);
            watchers[11].parentWatcher = watchers[10];
            watchers[10].addChild(watchers[11]);
            watchers[7].updateParent(cLocaManager);
            watchers[8].parentWatcher = watchers[7];
            watchers[7].addChild(watchers[8]);
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
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            LegalPanel.watcherSetupUtil = new _GUI_Components_LegalPanelWatcherSetupUtil;
            return;
        }// end function

    }
}
