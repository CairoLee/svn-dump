package GUI.Components
{
    import GUI.Assets.*;
    import GUI.Components.ToolTips.*;
    import ShopSystem.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class BuildQueueExtension extends Canvas implements IBindingClient
    {
        var _bindings:Array;
        private var expandedHeight:int;
        var _bindingsByDestination:Object;
        var _watchers:Array;
        private var offset:int;
        private var _1434162020btnBuyTempSlot:StandardButton;
        var _bindingsBeginWithWord:Object;
        private var _1292169788resizeWindow:Button;
        private var resizing:Boolean = false;
        private var _1332194002background:Canvas;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function BuildQueueExtension()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:122, height:50, childDescriptors:[new UIComponentDescriptor({type:Canvas, id:"background", stylesFactory:function () : void
                {
                    this.backgroundSize = "100%";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    var _loc_1:String = null;
                    return {percentWidth:100, percentHeight:100, childDescriptors:[new UIComponentDescriptor({type:StandardButton, id:"btnBuyTempSlot", events:{toolTipCreate:"__btnBuyTempSlot_toolTipCreate"}, stylesFactory:function () : void
                    {
                        this.verticalCenter = "-4";
                        this.horizontalCenter = "0";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {width:65, height:25, enabled:true};
                    }// end function
                    }), new UIComponentDescriptor({type:Button, id:"resizeWindow", events:{mouseDown:"__resizeWindow_mouseDown"}, stylesFactory:function () : void
                    {
                        this.bottom = "3";
                        this.horizontalCenter = "-2";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {null:"chatScaleButton"};
                    }// end function
                    })]};
                }// end function
                })]};
            }// end function
            });
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.styleName = "buildQueueItem";
            this.horizontalScrollPolicy = "off";
            this.verticalScrollPolicy = "off";
            this.width = 122;
            this.height = 50;
            this.addEventListener("toolTipCreate", this.___BuildQueueExtension_Canvas1_toolTipCreate);
            return;
        }// end function

        public function set resizeWindow(param1:Button) : void
        {
            var _loc_2:* = this._1292169788resizeWindow;
            if (_loc_2 !== param1)
            {
                this._1292169788resizeWindow = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resizeWindow", _loc_2, param1));
            }
            return;
        }// end function

        public function get resizeWindow() : Button
        {
            return this._1292169788resizeWindow;
        }// end function

        public function __resizeWindow_mouseDown(event:MouseEvent) : void
        {
            this.StartResizing(event);
            return;
        }// end function

        private function StartResizing(event:MouseEvent) : void
        {
            this.resizing = true;
            this.offset = event.localY;
            Application.application.addEventListener(MouseEvent.MOUSE_UP, this.StopResizing);
            Application.application.addEventListener(MouseEvent.ROLL_OUT, this.StopResizing);
            Application.application.addEventListener(MouseEvent.MOUSE_MOVE, this.Resize);
            return;
        }// end function

        private function Resize(event:MouseEvent) : void
        {
            var _loc_2:* = Application.application.height + event.stageY + (this.parent as Canvas).getConstraintValue("bottom") - this.offset;
            var _loc_3:int = 350;
            if (event.stageY > _loc_3)
            {
                if (event.stageY < Application.application.screen.height - 200)
                {
                    this.parent.height = event.stageY;
                }
                else
                {
                    this.parent.height = Application.application.screen.height - 200;
                }
            }
            return;
        }// end function

        override public function initialize() : void
        {
            var target:BuildQueueExtension;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._BuildQueueExtension_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_BuildQueueExtensionWatcherSetupUtil");
                var _loc_2:* = watcherSetupUtilClass;
                _loc_2.watcherSetupUtilClass["init"](null);
            }
            _watcherSetupUtil.setup(this, function (param1:String)
            {
                return null[null];
            }// end function
            , bindings, watchers);
            var i:uint;
            while (i < bindings.length)
            {
                
                Binding(bindings[i]).execute();
                i = (i + 1);
            }
            mx_internal::_bindings = mx_internal::_bindings.concat(bindings);
            mx_internal::_watchers = mx_internal::_watchers.concat(watchers);
            super.initialize();
            return;
        }// end function

        public function set background(param1:Canvas) : void
        {
            var _loc_2:* = this._1332194002background;
            if (_loc_2 !== param1)
            {
                this._1332194002background = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "background", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnBuyTempSlot() : StandardButton
        {
            return this._1434162020btnBuyTempSlot;
        }// end function

        private function _BuildQueueExtension_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Object
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Object) : void
            {
                background.setStyle("backgroundImage", param1);
                return;
            }// end function
            , "background.backgroundImage");
            result[0] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnBuyTempSlot.icon");
            result[1] = binding;
            return result;
        }// end function

        public function get background() : Canvas
        {
            return this._1332194002background;
        }// end function

        public function ___BuildQueueExtension_Canvas1_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event, data);
            return;
        }// end function

        public function set btnBuyTempSlot(param1:StandardButton) : void
        {
            var _loc_2:* = this._1434162020btnBuyTempSlot;
            if (_loc_2 !== param1)
            {
                this._1434162020btnBuyTempSlot = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnBuyTempSlot", _loc_2, param1));
            }
            return;
        }// end function

        private function StopResizing(event:MouseEvent) : void
        {
            this.resizing = false;
            this.expandedHeight = this.height;
            Application.application.removeEventListener(MouseEvent.MOUSE_UP, this.StopResizing);
            Application.application.removeEventListener(MouseEvent.ROLL_OUT, this.StopResizing);
            Application.application.removeEventListener(MouseEvent.MOUSE_MOVE, this.Resize);
            return;
        }// end function

        private function _BuildQueueExtension_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = gAssetManager.GetClass("BuildQueueExtensionBar");
            _loc_1 = gAssetManager.GetClass("BuyTempSlot");
            return;
        }// end function

        public function __btnBuyTempSlot_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SHOP_ITEM_WITH_COSTS_string, event, cShopItem.GetShopItem(8007));
            return;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
