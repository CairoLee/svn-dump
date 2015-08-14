package GUI.Components.ItemRenderer
{
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import ServerState.*;
    import ShopSystem.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class ShopItemRenderer extends Canvas implements IBindingClient
    {
        private var _1215755049nameLabel:Label;
        var _bindingsByDestination:Object;
        public var _ShopItemRenderer_Image2:Image;
        var _bindingsBeginWithWord:Object;
        private var _97692013frame:Frame;
        private var _252650492costsList:VBox;
        var _watchers:Array;
        private var _1391742627lockedIcon:Image;
        private var _267185744framedIcon:Image;
        private var _1332194002background:Canvas;
        private var _documentDescriptor_:UIComponentDescriptor;
        var _bindings:Array;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function ShopItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:164, height:112, childDescriptors:[new UIComponentDescriptor({type:Canvas, id:"background", stylesFactory:function () : void
                {
                    this.backgroundSize = "100%";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null, percentHeight:100};
                }// end function
                }), new UIComponentDescriptor({type:Label, id:"nameLabel", events:{toolTipCreate:"__nameLabel_toolTipCreate"}, stylesFactory:function () : void
                {
                    null.textAlign = this;
                    this.color = 0;
                    this.fontWeight = "bold";
                    this.left = "4";
                    this.top = "3";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:150};
                }// end function
                }), new UIComponentDescriptor({type:Frame, id:"frame", stylesFactory:function () : void
                {
                    this.right = "15";
                    this.verticalCenter = "7";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {type:"specialist", contentType:"shopitem"};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"framedIcon", stylesFactory:function () : void
                {
                    this.right = "15";
                    this.verticalCenter = "7";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {width:56, height:70};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"_ShopItemRenderer_Image2", stylesFactory:function () : void
                {
                    this.horizontalCenter = "0";
                    this.verticalCenter = "7";
                    return;
                }// end function
                }), new UIComponentDescriptor({type:VBox, id:"costsList", stylesFactory:function () : void
                {
                    this.left = "10";
                    this.top = "20";
                    this.verticalCenter = "7";
                    this.verticalGap = 0;
                    return;
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"lockedIcon", events:{toolTipCreate:"__lockedIcon_toolTipCreate"}, stylesFactory:function () : void
                {
                    null.right = this;
                    this.bottom = "7";
                    return;
                }// end function
                })]};
            }// end function
            });
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.horizontalScrollPolicy = "off";
            this.verticalScrollPolicy = "off";
            this.width = 164;
            this.height = 112;
            this.addEventListener("click", this.___ShopItemRenderer_Canvas1_click);
            this.addEventListener("rollOver", this.___ShopItemRenderer_Canvas1_rollOver);
            this.addEventListener("rollOut", this.___ShopItemRenderer_Canvas1_rollOut);
            this.addEventListener("toolTipCreate", this.___ShopItemRenderer_Canvas1_toolTipCreate);
            return;
        }// end function

        public function __lockedIcon_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, true);
            return;
        }// end function

        public function get frame() : Frame
        {
            return this._97692013frame;
        }// end function

        public function get lockedIcon() : Image
        {
            return this._1391742627lockedIcon;
        }// end function

        public function set costsList(param1:VBox) : void
        {
            var _loc_2:* = this._252650492costsList;
            if (_loc_2 !== param1)
            {
                this._252650492costsList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "costsList", _loc_2, param1));
            }
            return;
        }// end function

        public function __nameLabel_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        override public function initialize() : void
        {
            var target:ShopItemRenderer;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._ShopItemRenderer_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ItemRenderer_ShopItemRendererWatcherSetupUtil");
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

        public function ___ShopItemRenderer_Canvas1_rollOver(event:MouseEvent) : void
        {
            this.background.setStyle("backgroundImage", gAssetManager.GetClass("ShopItemBackgroundHighlight"));
            return;
        }// end function

        public function get costsList() : VBox
        {
            return this._252650492costsList;
        }// end function

        public function set lockedIcon(param1:Image) : void
        {
            var _loc_2:* = this._1391742627lockedIcon;
            if (_loc_2 !== param1)
            {
                this._1391742627lockedIcon = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "lockedIcon", _loc_2, param1));
            }
            return;
        }// end function

        public function set nameLabel(param1:Label) : void
        {
            var _loc_2:* = this._1215755049nameLabel;
            if (_loc_2 !== param1)
            {
                this._1215755049nameLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "nameLabel", _loc_2, param1));
            }
            return;
        }// end function

        override public function set data(param1:Object) : void
        {
            var _loc_3:dResource = null;
            var _loc_4:ResourceItemRenderer = null;
            super.data = param1;
            this.background.setStyle("backgroundImage", gAssetManager.GetClass("ShopItemBackground"));
            var _loc_2:* = param1 as cShopItem;
            if (_loc_2 != null)
            {
                toolTip = _loc_2.GetName_string();
                this.frame.content = _loc_2.GetName_string();
                this.frame.type = _loc_2.GetFrameType_string();
                this.nameLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.SHOP_ITEMS, _loc_2.GetName_string());
                this.costsList.removeAllChildren();
                for each (_loc_3 in _loc_2.GetCosts_vector())
                {
                    
                    _loc_4 = new ResourceItemRenderer();
                    _loc_4.data = _loc_3;
                    this.costsList.addChild(_loc_4);
                }
                this.lockedIcon.visible = global.ui.mCurrentPlayer.GetPlayerLevel() < _loc_2.GetPlayerLevel();
                if (this.lockedIcon.visible)
                {
                    this.lockedIcon.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LevelRequired", [_loc_2.GetPlayerLevel()]);
                }
                else
                {
                    this.lockedIcon.toolTip = "";
                }
            }
            return;
        }// end function

        private function _ShopItemRenderer_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = gAssetManager.GetBitmap("ProductionArrow");
            _loc_1 = gAssetManager.GetBitmap("IconPadlock");
            return;
        }// end function

        public function set framedIcon(param1:Image) : void
        {
            var _loc_2:* = this._267185744framedIcon;
            if (_loc_2 !== param1)
            {
                this._267185744framedIcon = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "framedIcon", _loc_2, param1));
            }
            return;
        }// end function

        protected function ShowDetails() : void
        {
            dispatchEvent(new Event("ShowItemDetails", true));
            return;
        }// end function

        private function _ShopItemRenderer_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Object
            {
                return null.GetBitmap(null);
            }// end function
            , function (param1:Object) : void
            {
                _ShopItemRenderer_Image2.source = param1;
                return;
            }// end function
            , "_ShopItemRenderer_Image2.source");
            result[0] = binding;
            binding = new Binding(this, function () : Object
            {
                return null.GetBitmap(null);
            }// end function
            , function (param1:Object) : void
            {
                null.source = null;
                return;
            }// end function
            , "lockedIcon.source");
            result[1] = binding;
            return result;
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

        public function ___ShopItemRenderer_Canvas1_click(event:MouseEvent) : void
        {
            this.ShowDetails();
            return;
        }// end function

        public function set frame(param1:Frame) : void
        {
            var _loc_2:* = this._97692013frame;
            if (_loc_2 !== param1)
            {
                this._97692013frame = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "frame", _loc_2, param1));
            }
            return;
        }// end function

        public function get background() : Canvas
        {
            return this._1332194002background;
        }// end function

        public function ___ShopItemRenderer_Canvas1_rollOut(event:MouseEvent) : void
        {
            this.background.setStyle("backgroundImage", gAssetManager.GetClass("ShopItemBackground"));
            return;
        }// end function

        public function get nameLabel() : Label
        {
            return this._1215755049nameLabel;
        }// end function

        public function ___ShopItemRenderer_Canvas1_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SHOP_ITEM_string, event, data);
            return;
        }// end function

        public function get framedIcon() : Image
        {
            return this._267185744framedIcon;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
