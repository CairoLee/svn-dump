package 
{
    import GUI.Components.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_FriendsListFilterSelectorWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_FriendsListFilterSelectorWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            FriendsListFilterSelector.watcherSetupUtil = new _GUI_Components_FriendsListFilterSelectorWatcherSetupUtil;
            return;
        }// end function

    }
}
