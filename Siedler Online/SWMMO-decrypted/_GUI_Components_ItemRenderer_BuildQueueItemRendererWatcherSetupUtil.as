package 
{
    import GUI.Components.ItemRenderer.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_ItemRenderer_BuildQueueItemRendererWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_ItemRenderer_BuildQueueItemRendererWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            param4[6] = new PropertyWatcher("index", {propertyChange:true}, [param3[5]], param2);
            param4[2] = new PropertyWatcher("dataProxy", {propertyChange:true}, [param3[2], param3[3]], param2);
            param4[4] = new PropertyWatcher("bitmap", {propertyChange:true}, [param3[3]], null);
            param4[3] = new PropertyWatcher("itemBackground", {propertyChange:true}, [param3[2]], null);
            param4[1] = new PropertyWatcher("buttonBar", {propertyChange:true}, [param3[1]], param2);
            param4[0] = new PropertyWatcher("resourceMissing", {propertyChange:true}, [param3[0]], param2);
            param4[6].updateParent(param1);
            param4[2].updateParent(param1);
            param4[2].addChild(param4[4]);
            param4[2].addChild(param4[3]);
            param4[1].updateParent(param1);
            param4[0].updateParent(param1);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            BuildQueueItemRenderer.watcherSetupUtil = new _GUI_Components_ItemRenderer_BuildQueueItemRendererWatcherSetupUtil;
            return;
        }// end function

    }
}
