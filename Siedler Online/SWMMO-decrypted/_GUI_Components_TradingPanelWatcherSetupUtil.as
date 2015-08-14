package 
{
    import Enums.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_TradingPanelWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_TradingPanelWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            var target:* = param1;
            var propertyGetter:* = param2;
            var bindings:* = param3;
            var watchers:* = param4;
            watchers[5] = new PropertyWatcher("tradeContent", {propertyChange:true}, [bindings[2]], propertyGetter);
            watchers[17] = new PropertyWatcher("offerResourceRenderer", {propertyChange:true}, [bindings[9]], propertyGetter);
            watchers[18] = new PropertyWatcher("visible", {hide:true, show:true}, [bindings[9]], null);
            watchers[22] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[11]], null);
            watchers[23] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "Select"];
            }// end function
            , {languageChanged:true}, [bindings[11]], null);
            watchers[9] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[5]], null);
            watchers[10] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "Trade"];
            }// end function
            , {languageChanged:true}, [bindings[5]], null);
            watchers[11] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[6]], null);
            watchers[12] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "TradingIntroduction"];
            }// end function
            , {languageChanged:true}, [bindings[6]], null);
            watchers[7] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[4]], null);
            watchers[8] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "Select"];
            }// end function
            , {languageChanged:true}, [bindings[4]], null);
            watchers[24] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[12]], null);
            watchers[25] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "WareToRecieve"];
            }// end function
            , {languageChanged:true}, [bindings[12]], null);
            watchers[6] = new PropertyWatcher("description", {propertyChange:true}, [bindings[3]], propertyGetter);
            watchers[3] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[1]], null);
            watchers[4] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "Cancel"];
            }// end function
            , {languageChanged:true}, [bindings[1]], null);
            watchers[14] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[7]], null);
            watchers[15] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "WareToDeliver"];
            }// end function
            , {languageChanged:true}, [bindings[7]], null);
            watchers[19] = new PropertyWatcher("offerBuffRenderer", {propertyChange:true}, [bindings[9]], propertyGetter);
            watchers[20] = new PropertyWatcher("visible", {hide:true, show:true}, [bindings[9]], null);
            watchers[0] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[0]], null);
            watchers[1] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "OK"];
            }// end function
            , {languageChanged:true}, [bindings[0]], null);
            watchers[27] = new PropertyWatcher("costRenderer", {propertyChange:true}, [bindings[14]], propertyGetter);
            watchers[28] = new PropertyWatcher("visible", {hide:true, show:true}, [bindings[14]], null);
            watchers[30] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[16]], null);
            watchers[31] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "Select"];
            }// end function
            , {languageChanged:true}, [bindings[16]], null);
            watchers[5].updateParent(target);
            watchers[17].updateParent(target);
            watchers[17].addChild(watchers[18]);
            watchers[22].updateParent(cLocaManager);
            watchers[23].parentWatcher = watchers[22];
            watchers[22].addChild(watchers[23]);
            watchers[9].updateParent(cLocaManager);
            watchers[10].parentWatcher = watchers[9];
            watchers[9].addChild(watchers[10]);
            watchers[11].updateParent(cLocaManager);
            watchers[12].parentWatcher = watchers[11];
            watchers[11].addChild(watchers[12]);
            watchers[7].updateParent(cLocaManager);
            watchers[8].parentWatcher = watchers[7];
            watchers[7].addChild(watchers[8]);
            watchers[24].updateParent(cLocaManager);
            watchers[25].parentWatcher = watchers[24];
            watchers[24].addChild(watchers[25]);
            watchers[6].updateParent(target);
            watchers[3].updateParent(cLocaManager);
            watchers[4].parentWatcher = watchers[3];
            watchers[3].addChild(watchers[4]);
            watchers[14].updateParent(cLocaManager);
            watchers[15].parentWatcher = watchers[14];
            watchers[14].addChild(watchers[15]);
            watchers[19].updateParent(target);
            watchers[19].addChild(watchers[20]);
            watchers[0].updateParent(cLocaManager);
            watchers[1].parentWatcher = watchers[0];
            watchers[0].addChild(watchers[1]);
            watchers[27].updateParent(target);
            watchers[27].addChild(watchers[28]);
            watchers[30].updateParent(cLocaManager);
            watchers[31].parentWatcher = watchers[30];
            watchers[30].addChild(watchers[31]);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            TradingPanel.watcherSetupUtil = new _GUI_Components_TradingPanelWatcherSetupUtil;
            return;
        }// end function

    }
}
