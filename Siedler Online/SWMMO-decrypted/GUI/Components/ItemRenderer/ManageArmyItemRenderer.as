package GUI.Components.ItemRenderer
{
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.collections.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class ManageArmyItemRenderer extends Canvas implements IBindingClient
    {
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _293001187unitIcon:Image;
        private var _765989721amountSlider:ExtendedHSlider;
        var _watchers:Array;
        private var _1332194002background:Canvas;
        private var _1229015684amountLabel:Label;
        private var dataProvider:ArrayCollection;
        private var _1019779949offset:int;
        private var _1215755049nameLabel:Label;
        var _bindingsBeginWithWord:Object;
        var _bindingsByDestination:Object;
        private var _100346066index:int;
        var _bindings:Array;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function ManageArmyItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                return {width:125, height:50, childDescriptors:[new UIComponentDescriptor({type:Canvas, id:"background", stylesFactory:function () : void
                {
                    this.backgroundSize = "100%";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {percentWidth:100, percentHeight:100};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"unitIcon", events:{toolTipCreate:"__unitIcon_toolTipCreate"}, stylesFactory:function () : void
                {
                    null.top = this;
                    this.left = "5";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:26, height:25};
                }// end function
                }), new UIComponentDescriptor({type:Label, id:"nameLabel", events:{toolTipCreate:"__nameLabel_toolTipCreate"}, stylesFactory:function () : void
                {
                    null.left = this;
                    this.textAlign = "center";
                    this.top = "2";
                    this.color = 16777215;
                    this.fontWeight = "bold";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:95};
                }// end function
                }), new UIComponentDescriptor({type:Label, id:"amountLabel", stylesFactory:function () : void
                {
                    this.horizontalCenter = "10";
                    this.top = "15";
                    this.color = 16777215;
                    this.fontWeight = "normal";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {text:""};
                }// end function
                }), new UIComponentDescriptor({type:ExtendedHSlider, id:"amountSlider", events:{change:"__amountSlider_change"}, stylesFactory:function () : void
                {
                    this.left = "4";
                    this.right = "5";
                    this.bottom = "6";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {liveDragging:true, minimum:0};
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
            this.width = 125;
            this.height = 50;
            return;
        }// end function

        override public function initialize() : void
        {
            var target:ManageArmyItemRenderer;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._ManageArmyItemRenderer_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ItemRenderer_ManageArmyItemRendererWatcherSetupUtil");
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

        private function get offset() : int
        {
            return this._1019779949offset;
        }// end function

        public function get unitIcon() : Image
        {
            return this._293001187unitIcon;
        }// end function

        private function UpdateAmount(event:SliderEvent) : void
        {
            if (isNaN(event.value))
            {
                return;
            }
            data.current = event.value;
            this.DisplayValues();
            dispatchEvent(new FlexEvent(FlexEvent.DATA_CHANGE, true));
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

        public function get nameLabel() : Label
        {
            return this._1215755049nameLabel;
        }// end function

        public function get background() : Canvas
        {
            return this._1332194002background;
        }// end function

        public function set amountSlider(param1:ExtendedHSlider) : void
        {
            var _loc_2:* = this._765989721amountSlider;
            if (_loc_2 !== param1)
            {
                this._765989721amountSlider = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "amountSlider", _loc_2, param1));
            }
            return;
        }// end function

        public function set unitIcon(param1:Image) : void
        {
            var _loc_2:* = this._293001187unitIcon;
            if (_loc_2 !== param1)
            {
                this._293001187unitIcon = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "unitIcon", _loc_2, param1));
            }
            return;
        }// end function

        public function __nameLabel_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        private function _ManageArmyItemRenderer_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Object
            {
                return null.GetClass("BackgroundNormal");
            }// end function
            , function (param1:Object) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "background.backgroundImage");
            result[0] = binding;
            return result;
        }// end function

        private function get index() : int
        {
            return this._100346066index;
        }// end function

        public function get amountSlider() : ExtendedHSlider
        {
            return this._765989721amountSlider;
        }// end function

        override public function set data(param1:Object) : void
        {
            super.data = param1;
            if (param1 != null)
            {
                this.unitIcon.toolTip = data.name_string;
                this.nameLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, data.name_string);
                this.unitIcon.source = gAssetManager.GetResourceIcon(data.name_string);
                this.amountSlider.maximum = data.available;
                this.amountSlider.value = data.current;
                this.amountSlider.enabled = data.enabled && data.available > 0;
            }
            this.DisplayValues();
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

        private function DisplayValues() : void
        {
            this.amountLabel.text = data.current + "/" + data.available;
            return;
        }// end function

        private function _ManageArmyItemRenderer_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = gAssetManager.GetClass("BackgroundNormal");
            return;
        }// end function

        public function __amountSlider_change(event:SliderEvent) : void
        {
            this.UpdateAmount(event);
            return;
        }// end function

        public function set amountLabel(param1:Label) : void
        {
            var _loc_2:* = this._1229015684amountLabel;
            if (_loc_2 !== param1)
            {
                this._1229015684amountLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "amountLabel", _loc_2, param1));
            }
            return;
        }// end function

        public function get amountLabel() : Label
        {
            return this._1229015684amountLabel;
        }// end function

        public function __unitIcon_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.MILITARY_UNIT_EXTENDED_string, event);
            return;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
