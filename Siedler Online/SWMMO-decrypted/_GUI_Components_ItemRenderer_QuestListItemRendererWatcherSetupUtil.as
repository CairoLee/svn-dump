package 
{
    import GUI.Components.ItemRenderer.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_ItemRenderer_QuestListItemRendererWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_ItemRenderer_QuestListItemRendererWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            param4[1] = new PropertyWatcher("labelText", {propertyChange:true}, [param3[1]], param2);
            param4[3] = new PropertyWatcher("trackable", {propertyChange:true}, [param3[3]], param2);
            param4[0] = new PropertyWatcher("iconImage", {propertyChange:true}, [param3[0]], param2);
            param4[2] = new PropertyWatcher("tracked", {propertyChange:true}, [param3[2]], param2);
            param4[1].updateParent(param1);
            param4[3].updateParent(param1);
            param4[0].updateParent(param1);
            param4[2].updateParent(param1);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            QuestListItemRenderer.watcherSetupUtil = new _GUI_Components_ItemRenderer_QuestListItemRendererWatcherSetupUtil;
            return;
        }// end function

    }
}
