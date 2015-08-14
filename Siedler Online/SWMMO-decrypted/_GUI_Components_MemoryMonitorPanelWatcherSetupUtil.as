package 
{
    import GUI.Components.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_MemoryMonitorPanelWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_MemoryMonitorPanelWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            param4[0] = new StaticPropertyWatcher("application", null, [param3[0], param3[1], param3[2], param3[3], param3[4]], null);
            param4[1] = new PropertyWatcher("mMemoryMonitor", null, [param3[0], param3[1], param3[2], param3[3], param3[4]], null);
            param4[5] = new PropertyWatcher("mUsedBytesUnscaled", null, [param3[1]], null);
            param4[9] = new PropertyWatcher("mOtherMemory", null, [param3[3]], null);
            param4[7] = new PropertyWatcher("mUsedBytesScaled", null, [param3[2]], null);
            param4[3] = new PropertyWatcher("mUsedBytesSprites", null, [param3[0]], null);
            param4[11] = new PropertyWatcher("mTotalMemory", null, [param3[4]], null);
            param4[0].updateParent(Application);
            param4[0].addChild(param4[1]);
            param4[1].addChild(param4[5]);
            param4[1].addChild(param4[9]);
            param4[1].addChild(param4[7]);
            param4[1].addChild(param4[3]);
            param4[1].addChild(param4[11]);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            MemoryMonitorPanel.watcherSetupUtil = new _GUI_Components_MemoryMonitorPanelWatcherSetupUtil;
            return;
        }// end function

    }
}
