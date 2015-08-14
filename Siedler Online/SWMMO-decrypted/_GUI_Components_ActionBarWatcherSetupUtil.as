package 
{
    import GUI.Components.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_ActionBarWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_ActionBarWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            param4[0] = new StaticPropertyWatcher("application", null, [param3[0]], null);
            param4[1] = new PropertyWatcher("blueFireComponent", null, [param3[0]], null);
            param4[2] = new PropertyWatcher("width", null, [param3[0]], null);
            param4[0].updateParent(Application);
            param4[0].addChild(param4[1]);
            param4[1].addChild(param4[2]);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            ActionBar.watcherSetupUtil = new _GUI_Components_ActionBarWatcherSetupUtil;
            return;
        }// end function

    }
}
