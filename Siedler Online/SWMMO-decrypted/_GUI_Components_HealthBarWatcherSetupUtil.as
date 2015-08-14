package 
{
    import GUI.Components.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_HealthBarWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_HealthBarWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            param4[0] = new PropertyWatcher("barMask", {propertyChange:true}, [param3[0]], param2);
            param4[0].updateParent(param1);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            HealthBar.watcherSetupUtil = new _GUI_Components_HealthBarWatcherSetupUtil;
            return;
        }// end function

    }
}
