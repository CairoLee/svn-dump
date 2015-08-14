package 
{
    import GUI.Components.ItemRenderer.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_ItemRenderer_QuestListGroupItemRendererWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_ItemRenderer_QuestListGroupItemRendererWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            param4[6] = new PropertyWatcher("title", {propertyChange:true}, [param3[6]], param2);
            param4[3] = new PropertyWatcher("btnTitle", {propertyChange:true}, [param3[4]], param2);
            param4[5] = new PropertyWatcher("height", {heightChanged:true}, [param3[4]], null);
            param4[4] = new PropertyWatcher("x", {xChanged:true}, [param3[4]], null);
            param4[2] = new PropertyWatcher("empty", {propertyChange:true}, [param3[2], param3[3]], param2);
            param4[9] = new PropertyWatcher("emptyText", {propertyChange:true}, [param3[8]], param2);
            param4[1] = new PropertyWatcher("list", {propertyChange:true}, [param3[2], param3[3]], param2);
            param4[0] = new PropertyWatcher("expandToHeight", {propertyChange:true}, [param3[0]], param2);
            param4[8] = new PropertyWatcher("collapsed", {propertyChange:true}, [param3[7]], param2);
            param4[6].updateParent(param1);
            param4[3].updateParent(param1);
            param4[3].addChild(param4[5]);
            param4[3].addChild(param4[4]);
            param4[2].updateParent(param1);
            param4[9].updateParent(param1);
            param4[1].updateParent(param1);
            param4[0].updateParent(param1);
            param4[8].updateParent(param1);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            QuestListGroupItemRenderer.watcherSetupUtil = new _GUI_Components_ItemRenderer_QuestListGroupItemRendererWatcherSetupUtil;
            return;
        }// end function

    }
}
