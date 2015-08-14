package 
{
    import Enums.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_ShopWindowWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_ShopWindowWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            var target:* = param1;
            var propertyGetter:* = param2;
            var bindings:* = param3;
            var watchers:* = param4;
            watchers[6] = new PropertyWatcher("giftTo", {propertyChange:true}, [bindings[7]], propertyGetter);
            watchers[1] = new PropertyWatcher("fadeOut", {propertyChange:true}, [bindings[1]], propertyGetter);
            watchers[8] = new PropertyWatcher("label", {labelChanged:true}, [bindings[9]], propertyGetter);
            watchers[19] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[17]], null);
            watchers[20] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "Categories"];
            }// end function
            , {languageChanged:true}, [bindings[17]], null);
            watchers[7] = new PropertyWatcher("available", {propertyChange:true}, [bindings[8]], propertyGetter);
            watchers[4] = new PropertyWatcher("giftPlayerAvatar", {propertyChange:true}, [bindings[5]], propertyGetter);
            watchers[21] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[18]], null);
            watchers[22] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "Buy"];
            }// end function
            , {languageChanged:true}, [bindings[18]], null);
            watchers[9] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[10]], null);
            watchers[10] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "MakeAGift"];
            }// end function
            , {languageChanged:true}, [bindings[10]], null);
            watchers[0] = new PropertyWatcher("fadeIn", {propertyChange:true}, [bindings[0]], propertyGetter);
            watchers[12] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[11]], null);
            watchers[13] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "Available"];
            }// end function
            , {languageChanged:true}, [bindings[11]], null);
            watchers[23] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[19]], null);
            watchers[24] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "Cancel"];
            }// end function
            , {languageChanged:true}, [bindings[19]], null);
            watchers[2] = new PropertyWatcher("shopHeader", {propertyChange:true}, [bindings[2]], propertyGetter);
            watchers[3] = new PropertyWatcher("shopHeaderBar", {propertyChange:true}, [bindings[3], bindings[4]], propertyGetter);
            watchers[5] = new PropertyWatcher("giftPlayerName", {propertyChange:true}, [bindings[6]], propertyGetter);
            watchers[6].updateParent(target);
            watchers[1].updateParent(target);
            watchers[8].updateParent(target);
            watchers[19].updateParent(cLocaManager);
            watchers[20].parentWatcher = watchers[19];
            watchers[19].addChild(watchers[20]);
            watchers[7].updateParent(target);
            watchers[4].updateParent(target);
            watchers[21].updateParent(cLocaManager);
            watchers[22].parentWatcher = watchers[21];
            watchers[21].addChild(watchers[22]);
            watchers[9].updateParent(cLocaManager);
            watchers[10].parentWatcher = watchers[9];
            watchers[9].addChild(watchers[10]);
            watchers[0].updateParent(target);
            watchers[12].updateParent(cLocaManager);
            watchers[13].parentWatcher = watchers[12];
            watchers[12].addChild(watchers[13]);
            watchers[23].updateParent(cLocaManager);
            watchers[24].parentWatcher = watchers[23];
            watchers[23].addChild(watchers[24]);
            watchers[2].updateParent(target);
            watchers[3].updateParent(target);
            watchers[5].updateParent(target);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            ShopWindow.watcherSetupUtil = new _GUI_Components_ShopWindowWatcherSetupUtil;
            return;
        }// end function

    }
}
