package 
{
    import com.bluebyte.bluefire.flex3.defaultClient.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _com_bluebyte_bluefire_flex3_defaultClient_ButtonBarItemRendererWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _com_bluebyte_bluefire_flex3_defaultClient_ButtonBarItemRendererWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            param4[1] = new PropertyWatcher("important", null, [param3[0]], param2);
            param4[3] = new PropertyWatcher("name", null, [param3[1]], param2);
            param4[0] = new PropertyWatcher("data", {dataChange:true}, [param3[0], param3[1]], param2);
            param4[2] = new PropertyWatcher("newMessages", null, [param3[0], param3[1]], param2);
            param4[1].updateParent(param1);
            param4[3].updateParent(param1);
            param4[0].updateParent(param1);
            param4[2].updateParent(param1);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            ButtonBarItemRenderer.watcherSetupUtil = new _com_bluebyte_bluefire_flex3_defaultClient_ButtonBarItemRendererWatcherSetupUtil;
            return;
        }// end function

    }
}
