package 
{
    import GUI.Components.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_BasicPanelWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_BasicPanelWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            param4[3] = new PropertyWatcher("headline", {propertyChange:true}, [param3[3]], param2);
            param4[4] = new PropertyWatcher("width", {widthChanged:true}, [param3[3]], null);
            param4[0] = new PropertyWatcher("fadeIn", {propertyChange:true}, [param3[0]], param2);
            param4[5] = new PropertyWatcher("width", {widthChanged:true}, [param3[3], param3[4]], param2);
            param4[1] = new PropertyWatcher("fadeOut", {propertyChange:true}, [param3[1]], param2);
            param4[2] = new PropertyWatcher("label", {labelChanged:true}, [param3[2]], param2);
            param4[3].updateParent(param1);
            param4[3].addChild(param4[4]);
            param4[0].updateParent(param1);
            param4[5].updateParent(param1);
            param4[1].updateParent(param1);
            param4[2].updateParent(param1);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            BasicPanel.watcherSetupUtil = new _GUI_Components_BasicPanelWatcherSetupUtil;
            return;
        }// end function

    }
}
