package 
{
    import GUI.Components.*;
    import GUI.Loca.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_FriendsListButtonBarWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_FriendsListButtonBarWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            var target:* = param1;
            var propertyGetter:* = param2;
            var bindings:* = param3;
            var watchers:* = param4;
            watchers[6] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[3]], null);
            watchers[7] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "ReturnHome"];
            }// end function
            , {languageChanged:true}, [bindings[3]], null);
            watchers[4] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[2]], null);
            watchers[5] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "InviteByMail"];
            }// end function
            , {languageChanged:true}, [bindings[2]], null);
            watchers[1] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[1]], null);
            watchers[2] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "AddFriend"];
            }// end function
            , {languageChanged:true}, [bindings[1]], null);
            watchers[6].updateParent(cLocaManager);
            watchers[7].parentWatcher = watchers[6];
            watchers[6].addChild(watchers[7]);
            watchers[4].updateParent(cLocaManager);
            watchers[5].parentWatcher = watchers[4];
            watchers[4].addChild(watchers[5]);
            watchers[1].updateParent(cLocaManager);
            watchers[2].parentWatcher = watchers[1];
            watchers[1].addChild(watchers[2]);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            FriendsListButtonBar.watcherSetupUtil = new _GUI_Components_FriendsListButtonBarWatcherSetupUtil;
            return;
        }// end function

    }
}
