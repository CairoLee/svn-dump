package GUI.Components.ItemRenderer
{
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.*;
    import GUI.Components.ToolTips.*;
    import GUI.GAME.*;
    import GUI.Loca.*;
    import MilitarySystem.*;
    import TimedProduction.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.collections.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import mx.utils.*;

    public class OrderItemRenderer extends Canvas implements IBindingClient
    {
        private var _763044039progressLabel:Label;
        var _watchers:Array;
        private var _1131509414progressBar:ProgressBar;
        private var _1332194002background:Canvas;
        private var dataProvider:ArrayCollection;
        private var _1019779949offset:int;
        var _bindingsBeginWithWord:Object;
        private var _391766279orderName:Label;
        private var _551038464btnRemove:Button;
        var _bindingsByDestination:Object;
        private var _100346066index:int;
        private var _377281308dataProxy:ObjectProxy;
        var _bindings:Array;
        private var _391913241orderIcon:Image;
        private var _963230283btnHalfProductionTime:Button;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function OrderItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:225, height:63, childDescriptors:[new UIComponentDescriptor({type:Canvas, id:"background", stylesFactory:function () : void
                {
                    this.backgroundSize = "100%";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null, percentHeight:100};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"orderIcon", stylesFactory:function () : void
                {
                    this.verticalCenter = "-8";
                    this.left = "10";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:26, height:25};
                }// end function
                }), new UIComponentDescriptor({type:Label, id:"orderName", stylesFactory:function () : void
                {
                    null.top = this;
                    this.left = "43";
                    this.color = 16777215;
                    return;
                }// end function
                }), new UIComponentDescriptor({type:Label, id:"progressLabel", stylesFactory:function () : void
                {
                    this.color = 16777215;
                    this.fontWeight = "normal";
                    this.left = "43";
                    this.top = "30";
                    return;
                }// end function
                }), new UIComponentDescriptor({type:ProgressBar, id:"progressBar", stylesFactory:function () : void
                {
                    this.left = "45";
                    this.top = "21";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:130};
                }// end function
                }), new UIComponentDescriptor({type:Button, id:"btnHalfProductionTime", events:{toolTipCreate:"__btnHalfProductionTime_toolTipCreate", click:"__btnHalfProductionTime_click"}, stylesFactory:function () : void
                {
                    null.right = this;
                    this.bottom = "5";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null, toolTip:"InstantFinishProduction", width:25, height:23};
                }// end function
                }), new UIComponentDescriptor({type:Button, id:"btnRemove", events:{click:"__btnRemove_click"}, stylesFactory:function () : void
                {
                    this.right = "15";
                    this.bottom = "5";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null, height:23};
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
            this.width = 225;
            this.height = 63;
            this.addEventListener("toolTipCreate", this.___OrderItemRenderer_Canvas1_toolTipCreate);
            return;
        }// end function

        public function get btnRemove() : Button
        {
            return this._551038464btnRemove;
        }// end function

        public function set btnRemove(param1:Button) : void
        {
            var _loc_2:* = this._551038464btnRemove;
            if (_loc_2 !== param1)
            {
                this._551038464btnRemove = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnRemove", _loc_2, param1));
            }
            return;
        }// end function

        public function set progressLabel(param1:Label) : void
        {
            var _loc_2:* = this._763044039progressLabel;
            if (_loc_2 !== param1)
            {
                this._763044039progressLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "progressLabel", _loc_2, param1));
            }
            return;
        }// end function

        private function get offset() : int
        {
            return this._1019779949offset;
        }// end function

        private function _OrderItemRenderer_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Object
            {
                return gAssetManager.GetClass("QueueBackground");
            }// end function
            , function (param1:Object) : void
            {
                background.setStyle("backgroundImage", param1);
                return;
            }// end function
            , "background.backgroundImage");
            result[0] = binding;
            binding = new Binding(this, function () : Number
            {
                return (data as cTimedProduction).GetProductionProgress();
            }// end function
            , function (param1:Number) : void
            {
                null.value = null;
                return;
            }// end function
            , "progressBar.value");
            result[1] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("upSkin", param1);
                return;
            }// end function
            , "btnHalfProductionTime.upSkin");
            result[2] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("HalfTimeHighlight");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("downSkin", param1);
                return;
            }// end function
            , "btnHalfProductionTime.downSkin");
            result[3] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("HalfTimeHighlight");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnHalfProductionTime.overSkin");
            result[4] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnHalfProductionTime.disabledSkin");
            result[5] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("Close");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnRemove.upSkin");
            result[6] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("CloseHighlight");
            }// end function
            , function (param1:Class) : void
            {
                btnRemove.setStyle("downSkin", param1);
                return;
            }// end function
            , "btnRemove.downSkin");
            result[7] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("CloseHighlight");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnRemove.overSkin");
            result[8] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("CloseDisabled");
            }// end function
            , function (param1:Class) : void
            {
                btnRemove.setStyle("disabledSkin", param1);
                return;
            }// end function
            , "btnRemove.disabledSkin");
            result[9] = binding;
            return result;
        }// end function

        override public function initialize() : void
        {
            var target:OrderItemRenderer;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._OrderItemRenderer_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ItemRenderer_OrderItemRendererWatcherSetupUtil");
                var _loc_2:* = watcherSetupUtilClass;
                _loc_2.watcherSetupUtilClass["init"](null);
            }
            _watcherSetupUtil.setup(this, function (param1:String)
            {
                return target[param1];
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

        public function __btnHalfProductionTime_click(event:MouseEvent) : void
        {
            this.btnHalfProductionTime.enabled = false;
            this.dispatchEvent(new ListEvent(cTimedProductionInfoPanel.HALF_TIME, true, false, 0, this.index));
            return;
        }// end function

        public function ___OrderItemRenderer_Canvas1_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.TIMED_PRODUCTION_ORDER_string, event, data);
            return;
        }// end function

        private function set index(param1:int) : void
        {
            var _loc_2:* = this._100346066index;
            if (_loc_2 !== param1)
            {
                this._100346066index = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "index", _loc_2, param1));
            }
            return;
        }// end function

        public function get progressBar() : ProgressBar
        {
            return this._1131509414progressBar;
        }// end function

        public function __btnRemove_click(event:MouseEvent) : void
        {
            this.dispatchEvent(new ListEvent(cTimedProductionInfoPanel.REMOVE, true, false, 0, this.index));
            return;
        }// end function

        private function set offset(param1:int) : void
        {
            var _loc_2:* = this._1019779949offset;
            if (_loc_2 !== param1)
            {
                this._1019779949offset = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "offset", _loc_2, param1));
            }
            return;
        }// end function

        public function get background() : Canvas
        {
            return this._1332194002background;
        }// end function

        public function get btnHalfProductionTime() : Button
        {
            return this._963230283btnHalfProductionTime;
        }// end function

        private function set dataProxy(param1:ObjectProxy) : void
        {
            var _loc_2:* = this._377281308dataProxy;
            if (_loc_2 !== param1)
            {
                this._377281308dataProxy = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "dataProxy", _loc_2, param1));
            }
            return;
        }// end function

        private function get index() : int
        {
            return this._100346066index;
        }// end function

        private function _OrderItemRenderer_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = gAssetManager.GetClass("QueueBackground");
            _loc_1 = (data as cTimedProduction).GetProductionProgress();
            _loc_1 = gAssetManager.GetClass("HalfTime");
            _loc_1 = gAssetManager.GetClass("HalfTimeHighlight");
            _loc_1 = gAssetManager.GetClass("HalfTimeHighlight");
            _loc_1 = gAssetManager.GetClass("HalfTimeDisabled");
            _loc_1 = gAssetManager.GetClass("Close");
            _loc_1 = gAssetManager.GetClass("CloseHighlight");
            _loc_1 = gAssetManager.GetClass("CloseHighlight");
            _loc_1 = gAssetManager.GetClass("CloseDisabled");
            return;
        }// end function

        override public function set data(param1:Object) : void
        {
            var _loc_2:cTimedProduction = null;
            if (param1 != null)
            {
                _loc_2 = param1 as cTimedProduction;
                super.data = _loc_2;
                this.dataProvider = ArrayCollection(TileList(owner).dataProvider);
                this.orderName.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, _loc_2.GetType_string());
                this.orderIcon.source = gAssetManager.GetResourceIcon(_loc_2.GetType_string());
                this.btnHalfProductionTime.visible = _loc_2.HasStarted();
                this.btnHalfProductionTime.enabled = !_loc_2.GetWaitingForServer() && _loc_2.GetInstantBuildCosts() > 0;
                this.btnRemove.visible = !_loc_2.HasStarted();
                this.index = this.dataProvider.getItemIndex(data);
                toolTip = _loc_2.GetType_string();
                if (this.index > 0)
                {
                    this.progressLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "OrdersWaiting", [_loc_2.GetAmount().toString()]);
                }
                else if (_loc_2.GetProductionOrder() is cMilitaryUnitProductionOrder)
                {
                    this.progressLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Recruited", [_loc_2.GetProducedItems().toString(), _loc_2.GetAmount().toString()]);
                }
                else
                {
                    this.progressLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Produced", [_loc_2.GetProducedItems().toString(), _loc_2.GetAmount().toString()]);
                }
            }
            return;
        }// end function

        public function __btnHalfProductionTime_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.INSTANT_BUILD_string, event, (data as cTimedProduction).GetInstantBuildCosts());
            return;
        }// end function

        public function get progressLabel() : Label
        {
            return this._763044039progressLabel;
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

        public function set orderIcon(param1:Image) : void
        {
            var _loc_2:* = this._391913241orderIcon;
            if (_loc_2 !== param1)
            {
                this._391913241orderIcon = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "orderIcon", _loc_2, param1));
            }
            return;
        }// end function

        public function set progressBar(param1:ProgressBar) : void
        {
            var _loc_2:* = this._1131509414progressBar;
            if (_loc_2 !== param1)
            {
                this._1131509414progressBar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "progressBar", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnHalfProductionTime(param1:Button) : void
        {
            var _loc_2:* = this._963230283btnHalfProductionTime;
            if (_loc_2 !== param1)
            {
                this._963230283btnHalfProductionTime = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnHalfProductionTime", _loc_2, param1));
            }
            return;
        }// end function

        private function get dataProxy() : ObjectProxy
        {
            return this._377281308dataProxy;
        }// end function

        public function set orderName(param1:Label) : void
        {
            var _loc_2:* = this._391766279orderName;
            if (_loc_2 !== param1)
            {
                this._391766279orderName = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "orderName", _loc_2, param1));
            }
            return;
        }// end function

        public function get orderName() : Label
        {
            return this._391766279orderName;
        }// end function

        public function get orderIcon() : Image
        {
            return this._391913241orderIcon;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
