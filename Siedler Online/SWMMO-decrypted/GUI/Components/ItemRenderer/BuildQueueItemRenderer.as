package GUI.Components.ItemRenderer
{
    import GO.*;
    import GUI.Assets.*;
    import GUI.Components.ToolTips.*;
    import GUI.GAME.*;
    import ServerState.*;
    import flash.display.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.collections.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import mx.states.*;
    import mx.utils.*;
    import nLib.*;

    public class BuildQueueItemRenderer extends Canvas implements IBindingClient
    {
        private var _94069271btnUp:Button;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _763044039progressLabel:Label;
        var _watchers:Array;
        public var _BuildQueueItemRenderer_RemoveChild1:RemoveChild;
        public var _BuildQueueItemRenderer_RemoveChild2:RemoveChild;
        private var _11548545buttonBar:HBox;
        private var _768057317btnInstant:Button;
        private var _1332194002background:Canvas;
        private var dataProvider:ArrayCollection;
        private var _1019779949offset:int;
        private var _982759091buildingIcon:Image;
        private var _551038464btnRemove:Button;
        var _bindingsBeginWithWord:Object;
        private var _1704413560resourceMissing:Image;
        var _bindingsByDestination:Object;
        private var _100346066index:int;
        private var _377281308dataProxy:ObjectProxy;
        var _bindings:Array;
        private var _205752606btnDown:Button;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function BuildQueueItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                return {width:82, height:93, childDescriptors:[new UIComponentDescriptor({type:Canvas, id:"background", stylesFactory:function () : void
                {
                    this.backgroundSize = "100%";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:100, percentHeight:100};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"buildingIcon", events:{click:"__buildingIcon_click"}, stylesFactory:function () : void
                {
                    this.top = "5";
                    this.bottom = "30";
                    this.horizontalAlign = "center";
                    this.verticalAlign = "middle";
                    this.left = "6";
                    this.right = "8";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {scaleContent:false};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"resourceMissing", events:{click:"__resourceMissing_click"}, stylesFactory:function () : void
                {
                    null.top = this;
                    this.bottom = "37";
                    this.horizontalAlign = "left";
                    this.verticalAlign = "top";
                    this.left = "6";
                    this.right = "17";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {scaleContent:false};
                }// end function
                }), new UIComponentDescriptor({type:Label, id:"progressLabel", stylesFactory:function () : void
                {
                    null.bottom = this;
                    this.textAlign = "center";
                    this.fontWeight = "normal";
                    this.color = 16777215;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:100};
                }// end function
                }), new UIComponentDescriptor({type:HBox, id:"buttonBar", stylesFactory:function () : void
                {
                    this.horizontalCenter = "0";
                    this.bottom = "5";
                    this.horizontalGap = 0;
                    this.horizontalAlign = "center";
                    this.paddingTop = 0;
                    this.paddingBottom = 0;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {percentWidth:100, childDescriptors:[new UIComponentDescriptor({type:Button, id:"btnUp", events:{click:"__btnUp_click"}, propertiesFactory:function () : Object
                    {
                        return {null:25, height:23};
                    }// end function
                    }), new UIComponentDescriptor({type:Button, id:"btnDown", events:{click:"__btnDown_click"}, propertiesFactory:function () : Object
                    {
                        return {null:25, height:23};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {childDescriptors:[new UIComponentDescriptor({type:Button, id:"btnRemove", events:{click:"__btnRemove_click"}, propertiesFactory:function () : Object
                        {
                            return {null:null, height:23};
                        }// end function
                        }), new UIComponentDescriptor({type:Button, id:"btnInstant", events:{toolTipCreate:"__btnInstant_toolTipCreate", click:"__btnInstant_click"}, propertiesFactory:function () : Object
                        {
                            return {null:null, width:25, height:23};
                        }// end function
                        })]};
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
            this.width = 82;
            this.height = 93;
            this.states = [this._BuildQueueItemRenderer_State1_c()];
            this.addEventListener("toolTipCreate", this.___BuildQueueItemRenderer_Canvas1_toolTipCreate);
            return;
        }// end function

        public function __btnUp_click(event:MouseEvent) : void
        {
            this.dispatchEvent(new ListEvent(cBuildQueue.MOVE_UP, true, false, 0, (data as cBuilding).GetBuildingGrid()));
            return;
        }// end function

        public function get buttonBar() : HBox
        {
            return this._11548545buttonBar;
        }// end function

        public function set buttonBar(param1:HBox) : void
        {
            var _loc_2:* = this._11548545buttonBar;
            if (_loc_2 !== param1)
            {
                this._11548545buttonBar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "buttonBar", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnRemove() : Button
        {
            return this._551038464btnRemove;
        }// end function

        private function _BuildQueueItemRenderer_RemoveChild1_i() : RemoveChild
        {
            var _loc_1:* = new RemoveChild();
            this._BuildQueueItemRenderer_RemoveChild1 = _loc_1;
            BindingManager.executeBindings(this, "_BuildQueueItemRenderer_RemoveChild1", this._BuildQueueItemRenderer_RemoveChild1);
            return _loc_1;
        }// end function

        private function _BuildQueueItemRenderer_State1_c() : State
        {
            var _loc_1:* = new State();
            _loc_1.name = "emptySlot";
            _loc_1.overrides = [this._BuildQueueItemRenderer_RemoveChild1_i(), this._BuildQueueItemRenderer_RemoveChild2_i()];
            return _loc_1;
        }// end function

        public function __btnInstant_click(event:MouseEvent) : void
        {
            this.btnInstant.enabled = false;
            this.dispatchEvent(new ListEvent(cBuildQueue.INSTANT_BUILD, true, false, 0, (data as cBuilding).GetBuildingGrid()));
            return;
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

        override public function initialize() : void
        {
            var target:BuildQueueItemRenderer;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._BuildQueueItemRenderer_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ItemRenderer_BuildQueueItemRendererWatcherSetupUtil");
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

        private function ScrollToPosition() : void
        {
            if (data is cBuilding)
            {
                global.ui.mCurrentPlayerZone.ScrollToGrid((data as cBuilding).GetBuildingGrid());
            }
            return;
        }// end function

        private function get offset() : int
        {
            return this._1019779949offset;
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

        public function set buildingIcon(param1:Image) : void
        {
            var _loc_2:* = this._982759091buildingIcon;
            if (_loc_2 !== param1)
            {
                this._982759091buildingIcon = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "buildingIcon", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnDown() : Button
        {
            return this._205752606btnDown;
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

        private function _BuildQueueItemRenderer_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : DisplayObject
            {
                return resourceMissing;
            }// end function
            , function (param1:DisplayObject) : void
            {
                _BuildQueueItemRenderer_RemoveChild1.target = param1;
                return;
            }// end function
            , "_BuildQueueItemRenderer_RemoveChild1.target");
            result[0] = binding;
            binding = new Binding(this, function () : DisplayObject
            {
                return buttonBar;
            }// end function
            , function (param1:DisplayObject) : void
            {
                _BuildQueueItemRenderer_RemoveChild2.target = param1;
                return;
            }// end function
            , "_BuildQueueItemRenderer_RemoveChild2.target");
            result[1] = binding;
            binding = new Binding(this, function () : Object
            {
                return dataProxy.itemBackground;
            }// end function
            , function (param1:Object) : void
            {
                background.setStyle("backgroundImage", param1);
                return;
            }// end function
            , "background.backgroundImage");
            result[2] = binding;
            binding = new Binding(this, function () : Object
            {
                return dataProxy.bitmap;
            }// end function
            , function (param1:Object) : void
            {
                null.source = null;
                return;
            }// end function
            , "buildingIcon.source");
            result[3] = binding;
            binding = new Binding(this, function () : Object
            {
                return null.GetBitmap(null);
            }// end function
            , function (param1:Object) : void
            {
                null.source = null;
                return;
            }// end function
            , "resourceMissing.source");
            result[4] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return null == 0;
            }// end function
            , function (param1:Boolean) : void
            {
                progressLabel.visible = param1;
                return;
            }// end function
            , "progressLabel.visible");
            result[5] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ArrowUp");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnUp.upSkin");
            result[6] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                btnUp.setStyle("downSkin", param1);
                return;
            }// end function
            , "btnUp.downSkin");
            result[7] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ArrowUpHighlight");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnUp.overSkin");
            result[8] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ArrowUpDisabled");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnUp.disabledSkin");
            result[9] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ArrowDown");
            }// end function
            , function (param1:Class) : void
            {
                btnDown.setStyle("upSkin", param1);
                return;
            }// end function
            , "btnDown.upSkin");
            result[10] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("downSkin", param1);
                return;
            }// end function
            , "btnDown.downSkin");
            result[11] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("overSkin", param1);
                return;
            }// end function
            , "btnDown.overSkin");
            result[12] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ArrowDownDisabled");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("disabledSkin", param1);
                return;
            }// end function
            , "btnDown.disabledSkin");
            result[13] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("upSkin", param1);
                return;
            }// end function
            , "btnRemove.upSkin");
            result[14] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnRemove.downSkin");
            result[15] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("CloseHighlight");
            }// end function
            , function (param1:Class) : void
            {
                btnRemove.setStyle("overSkin", param1);
                return;
            }// end function
            , "btnRemove.overSkin");
            result[16] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("CloseDisabled");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnRemove.disabledSkin");
            result[17] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnInstant.upSkin");
            result[18] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("HalfTimeHighlight");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("downSkin", param1);
                return;
            }// end function
            , "btnInstant.downSkin");
            result[19] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("HalfTimeHighlight");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnInstant.overSkin");
            result[20] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("HalfTimeDisabled");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("disabledSkin", param1);
                return;
            }// end function
            , "btnInstant.disabledSkin");
            result[21] = binding;
            return result;
        }// end function

        public function __btnRemove_click(event:MouseEvent) : void
        {
            this.dispatchEvent(new ListEvent(cBuildQueue.REMOVE, true, false, 0, (data as cBuilding).GetBuildingGrid()));
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

        public function get btnUp() : Button
        {
            return this._94069271btnUp;
        }// end function

        public function __resourceMissing_click(event:MouseEvent) : void
        {
            this.ScrollToPosition();
            return;
        }// end function

        public function set btnUp(param1:Button) : void
        {
            var _loc_2:* = this._94069271btnUp;
            if (_loc_2 !== param1)
            {
                this._94069271btnUp = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnUp", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnDown(param1:Button) : void
        {
            var _loc_2:* = this._205752606btnDown;
            if (_loc_2 !== param1)
            {
                this._205752606btnDown = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnDown", _loc_2, param1));
            }
            return;
        }// end function

        public function __btnInstant_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.INSTANT_BUILD_string, event, (data as cBuilding).GetBuildInstantCosts());
            return;
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

        private function _BuildQueueItemRenderer_RemoveChild2_i() : RemoveChild
        {
            var _loc_1:* = new RemoveChild();
            this._BuildQueueItemRenderer_RemoveChild2 = _loc_1;
            BindingManager.executeBindings(this, "_BuildQueueItemRenderer_RemoveChild2", this._BuildQueueItemRenderer_RemoveChild2);
            return _loc_1;
        }// end function

        public function get buildingIcon() : Image
        {
            return this._982759091buildingIcon;
        }// end function

        private function get index() : int
        {
            return this._100346066index;
        }// end function

        override public function set data(param1:Object) : void
        {
            var _loc_2:cBuilding = null;
            var _loc_3:cResources = null;
            var _loc_4:String = null;
            if (param1 != null && param1 is cBuilding)
            {
                this.currentState = null;
                this.btnInstant.enabled = true;
                _loc_2 = param1 as cBuilding;
                super.data = _loc_2;
                this.dataProvider = ArrayCollection(List(owner).dataProvider);
                this.dataProxy = new ObjectProxy();
                this.dataProxy.label = _loc_2.GetBuildingName_string();
                this.dataProxy.bitmap = gAssetManager.GetBuildingIcon(_loc_2.GetBuildingName_string());
                _loc_3 = global.ui.mCurrentPlayerZone.GetResourcesForPlayerID(_loc_2.GetPlayerID());
                this.resourceMissing.visible = _loc_3 != null && !_loc_3.CanPlayerAffordBuilding(_loc_2.GetBuildingName_string());
                toolTip = _loc_2.GetBuildingName_string();
                this.index = this.dataProvider.getItemIndex(data);
                if ((this.dataProvider[0] as cBuilding).GetBuildingMode() == cBuilding.BUILDING_MODE_QUEUED)
                {
                    this.offset = 0;
                }
                else
                {
                    this.offset = 1;
                }
                if (this.index >= global.ui.mCurrentPlayer.mBuildQueue.GetMaxCount())
                {
                    this.dataProxy.itemBackground = gAssetManager.GetClass("QueuePaidBackground");
                }
                else
                {
                    this.dataProxy.itemBackground = gAssetManager.GetClass("QueueStdBackground");
                }
                this.btnUp.enabled = this.index > this.offset;
                this.btnDown.enabled = this.index < (this.dataProvider.length - 1) && this.dataProvider[(this.index + 1)] is cBuilding;
                this.btnRemove.enabled = true;
                this.btnUp.visible = _loc_2.GetBuildingMode() == cBuilding.BUILDING_MODE_QUEUED;
                this.btnDown.visible = _loc_2.GetBuildingMode() == cBuilding.BUILDING_MODE_QUEUED;
                this.btnRemove.visible = _loc_2.GetBuildingMode() == cBuilding.BUILDING_MODE_QUEUED;
                this.btnInstant.visible = _loc_2.GetBuildingMode() != cBuilding.BUILDING_MODE_QUEUED;
                if (global.ui.mCurrentPlayer.mBuildQueue.AreMoveButtonsDisabled())
                {
                    this.btnUp.enabled = false;
                    this.btnDown.enabled = false;
                    this.btnRemove.enabled = false;
                }
                if (_loc_2.GetBuildingMode() != cBuilding.BUILDING_MODE_QUEUED)
                {
                    this.resourceMissing.visible = false;
                    this.progressLabel.visible = true;
                    _loc_4 = gMisc.IsNaN(_loc_2.mBuildingProgress) ? ("0") : (Math.floor(_loc_2.mBuildingProgress / defines.BUILDING_PROGRESS_SCALE_FACTOR).toString());
                    this.progressLabel.text = _loc_4 + "%";
                }
                else
                {
                    this.progressLabel.visible = false;
                }
            }
            else if (param1 != null && param1 is cBuildSlot)
            {
                this.dataProxy = new ObjectProxy();
                this.currentState = "emptySlot";
                toolTip = null;
                this.progressLabel.visible = param1.mType == cBuildSlot.TEMPORARY_BUILDSLOT;
                if (param1.mType == cBuildSlot.REGULAR_BUILDSLOT)
                {
                    this.dataProxy.itemBackground = gAssetManager.GetClass("QueueEmptyBackground");
                }
                else
                {
                    this.dataProxy.itemBackground = gAssetManager.GetClass("QueuePaidBackground");
                    if (param1.mType == cBuildSlot.TEMPORARY_BUILDSLOT)
                    {
                        this.dataProxy.bitmap = gAssetManager.GetClass("BuildQueueTempSlotTimeLeftIcon");
                        this.progressLabel.text = param1.mTimeLeft;
                    }
                }
            }
            dispatchEvent(new FlexEvent(FlexEvent.DATA_CHANGE));
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

        public function __btnDown_click(event:MouseEvent) : void
        {
            this.dispatchEvent(new ListEvent(cBuildQueue.MOVE_DOWN, true, false, 0, (data as cBuilding).GetBuildingGrid()));
            return;
        }// end function

        private function _BuildQueueItemRenderer_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.resourceMissing;
            _loc_1 = this.buttonBar;
            _loc_1 = this.dataProxy.itemBackground;
            _loc_1 = this.dataProxy.bitmap;
            _loc_1 = gAssetManager.GetBitmap("BuildQueueResourceMissing");
            _loc_1 = this.index == 0;
            _loc_1 = gAssetManager.GetClass("ArrowUp");
            _loc_1 = gAssetManager.GetClass("ArrowUpHighlight");
            _loc_1 = gAssetManager.GetClass("ArrowUpHighlight");
            _loc_1 = gAssetManager.GetClass("ArrowUpDisabled");
            _loc_1 = gAssetManager.GetClass("ArrowDown");
            _loc_1 = gAssetManager.GetClass("ArrowDownHighlight");
            _loc_1 = gAssetManager.GetClass("ArrowDownHighlight");
            _loc_1 = gAssetManager.GetClass("ArrowDownDisabled");
            _loc_1 = gAssetManager.GetClass("Close");
            _loc_1 = gAssetManager.GetClass("CloseHighlight");
            _loc_1 = gAssetManager.GetClass("CloseHighlight");
            _loc_1 = gAssetManager.GetClass("CloseDisabled");
            _loc_1 = gAssetManager.GetClass("HalfTime");
            _loc_1 = gAssetManager.GetClass("HalfTimeHighlight");
            _loc_1 = gAssetManager.GetClass("HalfTimeHighlight");
            _loc_1 = gAssetManager.GetClass("HalfTimeDisabled");
            return;
        }// end function

        private function get dataProxy() : ObjectProxy
        {
            return this._377281308dataProxy;
        }// end function

        public function get progressLabel() : Label
        {
            return this._763044039progressLabel;
        }// end function

        public function set resourceMissing(param1:Image) : void
        {
            var _loc_2:* = this._1704413560resourceMissing;
            if (_loc_2 !== param1)
            {
                this._1704413560resourceMissing = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourceMissing", _loc_2, param1));
            }
            return;
        }// end function

        public function ___BuildQueueItemRenderer_Canvas1_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.BUILDQUEUE_ITEM_string, event, data);
            return;
        }// end function

        public function get btnInstant() : Button
        {
            return this._768057317btnInstant;
        }// end function

        public function set btnInstant(param1:Button) : void
        {
            var _loc_2:* = this._768057317btnInstant;
            if (_loc_2 !== param1)
            {
                this._768057317btnInstant = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnInstant", _loc_2, param1));
            }
            return;
        }// end function

        public function get resourceMissing() : Image
        {
            return this._1704413560resourceMissing;
        }// end function

        public function __buildingIcon_click(event:MouseEvent) : void
        {
            this.ScrollToPosition();
            return;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
