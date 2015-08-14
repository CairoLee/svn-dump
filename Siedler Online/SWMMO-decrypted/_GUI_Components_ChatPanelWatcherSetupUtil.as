package 
{
    import Enums.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import flash.display.*;
    import mx.binding.*;
    import mx.core.*;

    public class _GUI_Components_ChatPanelWatcherSetupUtil extends Sprite implements IWatcherSetupUtil
    {

        public function _GUI_Components_ChatPanelWatcherSetupUtil()
        {
            return;
        }// end function

        public function setup(param1:Object, param2:Function, param3:Array, param4:Array) : void
        {
            var target:* = param1;
            var propertyGetter:* = param2;
            var bindings:* = param3;
            var watchers:* = param4;
            watchers[5] = new PropertyWatcher("enabled", {enabledChanged:true}, [bindings[4], bindings[5]], propertyGetter);
            watchers[16] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[12]], null);
            watchers[17] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "Costs"];
            }// end function
            , {languageChanged:true}, [bindings[12]], null);
            watchers[1] = new PropertyWatcher("fadeOut", {propertyChange:true}, [bindings[1]], propertyGetter);
            watchers[18] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[13]], null);
            watchers[19] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null.LABELS, "From"];
            }// end function
            , {languageChanged:true}, [bindings[13]], null);
            watchers[28] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[18]], null);
            watchers[29] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "TradeOfferAdd"];
            }// end function
            , {languageChanged:true}, [bindings[18]], null);
            watchers[2] = new PropertyWatcher("chatstatusbox", {propertyChange:true}, [bindings[2]], propertyGetter);
            watchers[3] = new PropertyWatcher("selectedChannel", {propertyChange:true}, [bindings[3]], propertyGetter);
            watchers[4] = new PropertyWatcher("messages", {propertyChange:true}, [bindings[3]], null);
            watchers[9] = new PropertyWatcher("messageHistory", {propertyChange:true}, [bindings[7]], propertyGetter);
            watchers[10] = new PropertyWatcher("autoscroll", {propertyChange:true}, [bindings[7]], null);
            watchers[31] = new PropertyWatcher("chatstatusboxicon", {propertyChange:true}, [bindings[21], bindings[20], bindings[22]], propertyGetter);
            watchers[34] = new PropertyWatcher("height", {heightChanged:true}, [bindings[22]], null);
            watchers[33] = new PropertyWatcher("width", {widthChanged:true}, [bindings[21]], null);
            watchers[32] = new PropertyWatcher("x", {xChanged:true}, [bindings[21], bindings[22]], null);
            watchers[22] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[15]], null);
            watchers[23] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.LABELS, "SendTradeRequest"];
            }// end function
            , {languageChanged:true}, [bindings[15]], null);
            watchers[20] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[14]], null);
            watchers[21] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "Update"];
            }// end function
            , {languageChanged:true}, [bindings[14]], null);
            watchers[11] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[9]], null);
            watchers[12] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [LOCA_GROUP.CHAT_MESSAGES, "ClientServerConnecting"];
            }// end function
            , {languageChanged:true}, [bindings[9]], null);
            watchers[26] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[17]], null);
            watchers[27] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "TradeOfferClear"];
            }// end function
            , {languageChanged:true}, [bindings[17]], null);
            watchers[6] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[6]], null);
            watchers[7] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "ChatAutoScroll"];
            }// end function
            , {languageChanged:true}, [bindings[6]], null);
            watchers[0] = new PropertyWatcher("fadeIn", {propertyChange:true}, [bindings[0]], propertyGetter);
            watchers[24] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[16]], null);
            watchers[25] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "TradeCurrentOffer"];
            }// end function
            , {languageChanged:true}, [bindings[16]], null);
            watchers[14] = new FunctionReturnWatcher("GetInstance", target, function () : Array
            {
                return [];
            }// end function
            , null, [bindings[11]], null);
            watchers[15] = new FunctionReturnWatcher("GetText", target, function () : Array
            {
                return [null, "Offer"];
            }// end function
            , {languageChanged:true}, [bindings[11]], null);
            watchers[5].updateParent(target);
            watchers[16].updateParent(cLocaManager);
            watchers[17].parentWatcher = watchers[16];
            watchers[16].addChild(watchers[17]);
            watchers[1].updateParent(target);
            watchers[18].updateParent(cLocaManager);
            watchers[19].parentWatcher = watchers[18];
            watchers[18].addChild(watchers[19]);
            watchers[28].updateParent(cLocaManager);
            watchers[29].parentWatcher = watchers[28];
            watchers[28].addChild(watchers[29]);
            watchers[2].updateParent(target);
            watchers[3].updateParent(target);
            watchers[3].addChild(watchers[4]);
            watchers[9].updateParent(target);
            watchers[9].addChild(watchers[10]);
            watchers[31].updateParent(target);
            watchers[31].addChild(watchers[34]);
            watchers[31].addChild(watchers[33]);
            watchers[31].addChild(watchers[32]);
            watchers[22].updateParent(cLocaManager);
            watchers[23].parentWatcher = watchers[22];
            watchers[22].addChild(watchers[23]);
            watchers[20].updateParent(cLocaManager);
            watchers[21].parentWatcher = watchers[20];
            watchers[20].addChild(watchers[21]);
            watchers[11].updateParent(cLocaManager);
            watchers[12].parentWatcher = watchers[11];
            watchers[11].addChild(watchers[12]);
            watchers[26].updateParent(cLocaManager);
            watchers[27].parentWatcher = watchers[26];
            watchers[26].addChild(watchers[27]);
            watchers[6].updateParent(cLocaManager);
            watchers[7].parentWatcher = watchers[6];
            watchers[6].addChild(watchers[7]);
            watchers[0].updateParent(target);
            watchers[24].updateParent(cLocaManager);
            watchers[25].parentWatcher = watchers[24];
            watchers[24].addChild(watchers[25]);
            watchers[14].updateParent(cLocaManager);
            watchers[15].parentWatcher = watchers[14];
            watchers[14].addChild(watchers[15]);
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            ChatPanel.watcherSetupUtil = new _GUI_Components_ChatPanelWatcherSetupUtil;
            return;
        }// end function

    }
}
