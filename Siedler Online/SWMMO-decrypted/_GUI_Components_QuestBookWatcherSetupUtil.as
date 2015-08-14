package 
{
    import Enums.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_QuestBookWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_QuestBookWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            var target:* = param1;
            var propertyGetter:* = param2;
            var bindings:* = param3;
            var watchers:* = param4;
            watchers[16] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[8]], null);
            watchers[17] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "AdventureInvitePlayer"];
            }// end function
            , {languageChanged:true}, [bindings[8]], null);
            watchers[1] = new PropertyWatcher("fadeOut", {propertyChange:true}, [bindings[1]], propertyGetter);
            watchers[19] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[10]], null);
            watchers[20] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "QuestFinish"];
            }// end function
            , {languageChanged:true}, [bindings[10]], null);
            watchers[21] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[11]], null);
            watchers[22] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "Cancel"];
            }// end function
            , {languageChanged:true}, [bindings[11]], null);
            watchers[8] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[4]], null);
            watchers[9] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "Rewards"];
            }// end function
            , {languageChanged:true}, [bindings[4]], null);
            watchers[10] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[5]], null);
            watchers[11] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "Visit"];
            }// end function
            , {languageChanged:true}, [bindings[5]], null);
            watchers[25] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[13]], null);
            watchers[26] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "CancelAdventure"];
            }// end function
            , {languageChanged:true}, [bindings[13]], null);
            watchers[0] = new PropertyWatcher("fadeIn", {propertyChange:true}, [bindings[0]], propertyGetter);
            watchers[12] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[6]], null);
            watchers[13] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "SendArmy"];
            }// end function
            , {languageChanged:true}, [bindings[6]], null);
            watchers[23] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[12]], null);
            watchers[24] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "OK"];
            }// end function
            , {languageChanged:true}, [bindings[12]], null);
            watchers[14] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[7]], null);
            watchers[15] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "ShowAdventureDetails"];
            }// end function
            , {languageChanged:true}, [bindings[7]], null);
            watchers[2] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[2]], null);
            watchers[3] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "QuestBook"];
            }// end function
            , {languageChanged:true}, [bindings[2]], null);
            watchers[5] = new PropertyWatcher("triggers", {propertyChange:true}, [bindings[3]], propertyGetter);
            watchers[6] = new PropertyWatcher("dataProvider", {collectionChange:true}, [bindings[3]], null);
            watchers[7] = new PropertyWatcher("length", null, [bindings[3]], null);
            watchers[16].updateParent(cLocaManager);
            watchers[17].parentWatcher = watchers[16];
            watchers[16].addChild(watchers[17]);
            watchers[1].updateParent(target);
            watchers[19].updateParent(cLocaManager);
            watchers[20].parentWatcher = watchers[19];
            watchers[19].addChild(watchers[20]);
            watchers[21].updateParent(cLocaManager);
            watchers[22].parentWatcher = watchers[21];
            watchers[21].addChild(watchers[22]);
            watchers[8].updateParent(cLocaManager);
            watchers[9].parentWatcher = watchers[8];
            watchers[8].addChild(watchers[9]);
            watchers[10].updateParent(cLocaManager);
            watchers[11].parentWatcher = watchers[10];
            watchers[10].addChild(watchers[11]);
            watchers[25].updateParent(cLocaManager);
            watchers[26].parentWatcher = watchers[25];
            watchers[25].addChild(watchers[26]);
            watchers[0].updateParent(target);
            watchers[12].updateParent(cLocaManager);
            watchers[13].parentWatcher = watchers[12];
            watchers[12].addChild(watchers[13]);
            watchers[23].updateParent(cLocaManager);
            watchers[24].parentWatcher = watchers[23];
            watchers[23].addChild(watchers[24]);
            watchers[14].updateParent(cLocaManager);
            watchers[15].parentWatcher = watchers[14];
            watchers[14].addChild(watchers[15]);
            watchers[2].updateParent(cLocaManager);
            watchers[3].parentWatcher = watchers[2];
            watchers[2].addChild(watchers[3]);
            watchers[5].updateParent(target);
            watchers[5].addChild(watchers[6]);
            watchers[6].addChild(watchers[7]);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            QuestBook.watcherSetupUtil = new _GUI_Components_QuestBookWatcherSetupUtil;
            return;
        }// end function

    }
}
