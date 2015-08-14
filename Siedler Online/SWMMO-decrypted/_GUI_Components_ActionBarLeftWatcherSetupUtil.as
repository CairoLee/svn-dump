package 
{
    import Enums.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_ActionBarLeftWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_ActionBarLeftWatcherSetupUtil()
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
            watchers[3] = new PropertyWatcher("mIsAdventureZone", {propertyChange:true}, [bindings[0], bindings[18], bindings[6], bindings[12]], null);
            watchers[2] = new PropertyWatcher("mIsPlayerZone", {propertyChange:true}, [bindings[0], bindings[18], bindings[6], bindings[12]], null);
            watchers[27] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[23]], null);
            watchers[28] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "CLSBuildings"];
            }// end function
            , {languageChanged:true}, [bindings[23]], null);
            watchers[21] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[17]], null);
            watchers[22] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "CL3Buildings"];
            }// end function
            , {languageChanged:true}, [bindings[17]], null);
            watchers[8] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[5]], null);
            watchers[9] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "CL01Buildings"];
            }// end function
            , {languageChanged:true}, [bindings[5]], null);
            watchers[15] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[11]], null);
            watchers[16] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "CL2Buildings"];
            }// end function
            , {languageChanged:true}, [bindings[11]], null);
            watchers[0].updateParent(global);
            watchers[0].addChild(watchers[1]);
            watchers[1].addChild(watchers[3]);
            watchers[1].addChild(watchers[2]);
            watchers[27].updateParent(cLocaManager);
            watchers[28].parentWatcher = watchers[27];
            watchers[27].addChild(watchers[28]);
            watchers[21].updateParent(cLocaManager);
            watchers[22].parentWatcher = watchers[21];
            watchers[21].addChild(watchers[22]);
            watchers[8].updateParent(cLocaManager);
            watchers[9].parentWatcher = watchers[8];
            watchers[8].addChild(watchers[9]);
            watchers[15].updateParent(cLocaManager);
            watchers[16].parentWatcher = watchers[15];
            watchers[15].addChild(watchers[16]);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            ActionBarLeft.watcherSetupUtil = new _GUI_Components_ActionBarLeftWatcherSetupUtil;
            return;
        }// end function

    }
}
