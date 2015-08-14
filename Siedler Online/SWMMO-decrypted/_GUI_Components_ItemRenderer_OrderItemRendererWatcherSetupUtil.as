package 
{
    import GUI.Components.ItemRenderer.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_ItemRenderer_OrderItemRendererWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_ItemRenderer_OrderItemRendererWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            param4[1] = new PropertyWatcher("data", {dataChange:true}, [param3[1]], param2);
            param4[1].updateParent(param1);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            OrderItemRenderer.watcherSetupUtil = new _GUI_Components_ItemRenderer_OrderItemRendererWatcherSetupUtil;
            return;
        }// end function

    }
}
