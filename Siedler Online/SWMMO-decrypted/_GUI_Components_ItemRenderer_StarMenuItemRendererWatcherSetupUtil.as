package 
{
    import GUI.Components.ItemRenderer.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_ItemRenderer_StarMenuItemRendererWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_ItemRenderer_StarMenuItemRendererWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            param4[0] = new PropertyWatcher("dataProxy", {propertyChange:true}, [param3[0], param3[1], param3[2]], param2);
            param4[3] = new PropertyWatcher("progress", {propertyChange:true}, [param3[2]], null);
            param4[1] = new PropertyWatcher("icon", {propertyChange:true}, [param3[0]], null);
            param4[2] = new PropertyWatcher("resourceIcon", {propertyChange:true}, [param3[1]], null);
            param4[0].updateParent(param1);
            param4[0].addChild(param4[3]);
            param4[0].addChild(param4[1]);
            param4[0].addChild(param4[2]);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            StarMenuItemRenderer.watcherSetupUtil = new _GUI_Components_ItemRenderer_StarMenuItemRendererWatcherSetupUtil;
            return;
        }// end function

    }
}
