package 
{
    import GUI.Components.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_CheatWindow_inlineComponent1WatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_CheatWindow_inlineComponent1WatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            param4[1] = new PropertyWatcher("data", {dataChange:true}, [param3[0], param3[1], param3[2]], param2);
            param4[3] = new PropertyWatcher("amount", null, [param3[2]], null);
            param4[2] = new PropertyWatcher("name_string", null, [param3[0], param3[1]], null);
            param4[1].updateParent(param1);
            param4[1].addChild(param4[3]);
            param4[1].addChild(param4[2]);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            CheatWindow_inlineComponent1.watcherSetupUtil = new _GUI_Components_CheatWindow_inlineComponent1WatcherSetupUtil;
            return;
        }// end function

    }
}
