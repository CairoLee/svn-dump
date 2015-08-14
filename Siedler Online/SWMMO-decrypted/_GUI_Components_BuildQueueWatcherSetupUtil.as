package 
{
    import GUI.Components.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_BuildQueueWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_BuildQueueWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            param4[2] = new PropertyWatcher("fadeIn", {propertyChange:true}, [param3[1]], param2);
            param4[3] = new PropertyWatcher("fadeOut", {propertyChange:true}, [param3[2]], param2);
            param4[0] = new PropertyWatcher("list", {propertyChange:true}, [param3[0]], param2);
            param4[1] = new PropertyWatcher("maxVerticalScrollPosition", {maxVerticalScrollPositionChanged:true}, [param3[0]], null);
            param4[2].updateParent(param1);
            param4[3].updateParent(param1);
            param4[0].updateParent(param1);
            param4[0].addChild(param4[1]);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            BuildQueue.watcherSetupUtil = new _GUI_Components_BuildQueueWatcherSetupUtil;
            return;
        }// end function

    }
}
