package 
{
    import com.bluebyte.bluefire.flex3.defaultClient.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _com_bluebyte_bluefire_flex3_defaultClient_ChatPanelWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _com_bluebyte_bluefire_flex3_defaultClient_ChatPanelWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            param4[2] = new PropertyWatcher("enabled", {enabledChanged:true}, [param3[1], param3[2]], param2);
            param4[5] = new PropertyWatcher("whispersList", {propertyChange:true}, [param3[4]], param2);
            param4[6] = new PropertyWatcher("visible", {hide:true, show:true}, [param3[4]], null);
            param4[0] = new PropertyWatcher("selectedChannel", {propertyChange:true}, [param3[0]], param2);
            param4[1] = new PropertyWatcher("messages", {propertyChange:true}, [param3[0]], null);
            param4[3] = new PropertyWatcher("messageHistory", {propertyChange:true}, [param3[3]], param2);
            param4[4] = new PropertyWatcher("autoscroll", {propertyChange:true}, [param3[3]], null);
            param4[2].updateParent(param1);
            param4[5].updateParent(param1);
            param4[5].addChild(param4[6]);
            param4[0].updateParent(param1);
            param4[0].addChild(param4[1]);
            param4[3].updateParent(param1);
            param4[3].addChild(param4[4]);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            ChatPanel.watcherSetupUtil = new _com_bluebyte_bluefire_flex3_defaultClient_ChatPanelWatcherSetupUtil;
            return;
        }// end function

    }
}
