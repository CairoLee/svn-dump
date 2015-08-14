package 
{
    import GUI.Components.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_BattleWindowWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_BattleWindowWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            param4[2] = new PropertyWatcher("hideOverlayText", {propertyChange:true}, [param3[3], param3[5]], param2);
            param4[0] = new PropertyWatcher("rotationContainer", {propertyChange:true}, [param3[0], param3[1]], param2);
            param4[1] = new PropertyWatcher("showOverlayText", {propertyChange:true}, [param3[2], param3[4]], param2);
            param4[2].updateParent(param1);
            param4[0].updateParent(param1);
            param4[1].updateParent(param1);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            BattleWindow.watcherSetupUtil = new _GUI_Components_BattleWindowWatcherSetupUtil;
            return;
        }// end function

    }
}
