package 
{
    import GUI.Components.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_FriendsListWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_FriendsListWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            param4[0] = new PropertyWatcher("list", {propertyChange:true}, [param3[0], param3[20], param3[5], param3[25], param3[10], param3[15]], param2);
            param4[14] = new PropertyWatcher("maxHorizontalScrollPosition", {maxHorizontalScrollPositionChanged:true}, [param3[20], param3[25], param3[15]], null);
            param4[1] = new PropertyWatcher("horizontalScrollPosition", {scroll:true, viewChanged:true}, [param3[0], param3[20], param3[5], param3[25], param3[10], param3[15]], null);
            param4[0].updateParent(param1);
            param4[0].addChild(param4[14]);
            param4[0].addChild(param4[1]);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            FriendsList.watcherSetupUtil = new _GUI_Components_FriendsListWatcherSetupUtil;
            return;
        }// end function

    }
}
