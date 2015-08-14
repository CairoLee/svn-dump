package 
{
    import GUI.Components.*;
    import GUI.Loca.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_ActionBarRightWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_ActionBarRightWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            var target:* = param1;
            var propertyGetter:* = param2;
            var bindings:* = param3;
            var watchers:* = param4;
            watchers[0] = new StaticPropertyWatcher("ui", {propertyChange:true}, [bindings[0], bindings[18], bindings[6], bindings[12]], null);
            watchers[1] = new PropertyWatcher("mCurrentPlayer", {propertyChange:true}, [bindings[0], bindings[18], bindings[6], bindings[12]], null);
            watchers[22] = new PropertyWatcher("mIsAdventureZone", {propertyChange:true}, [bindings[18]], null);
            watchers[2] = new PropertyWatcher("mIsPlayerZone", {propertyChange:true}, [bindings[0], bindings[18], bindings[6], bindings[12]], null);
            watchers[27] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[23]], null);
            watchers[28] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "PayShop"];
            }// end function
            , {languageChanged:true}, [bindings[23]], null);
            watchers[20] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[17]], null);
            watchers[21] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "ViewMailWindow"];
            }// end function
            , {languageChanged:true}, [bindings[17]], null);
            watchers[7] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[5]], null);
            watchers[8] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "ComingSoon"];
            }// end function
            , {languageChanged:true}, [bindings[5]], null);
            watchers[14] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[11]], null);
            watchers[15] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "Guilds"];
            }// end function
            , {languageChanged:true}, [bindings[11]], null);
            watchers[0].updateParent(global);
            watchers[0].addChild(watchers[1]);
            watchers[1].addChild(watchers[22]);
            watchers[1].addChild(watchers[2]);
            watchers[27].updateParent(cLocaManager);
            watchers[28].parentWatcher = watchers[27];
            watchers[27].addChild(watchers[28]);
            watchers[20].updateParent(cLocaManager);
            watchers[21].parentWatcher = watchers[20];
            watchers[20].addChild(watchers[21]);
            watchers[7].updateParent(cLocaManager);
            watchers[8].parentWatcher = watchers[7];
            watchers[7].addChild(watchers[8]);
            watchers[14].updateParent(cLocaManager);
            watchers[15].parentWatcher = watchers[14];
            watchers[14].addChild(watchers[15]);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            ActionBarRight.watcherSetupUtil = new _GUI_Components_ActionBarRightWatcherSetupUtil;
            return;
        }// end function

    }
}
