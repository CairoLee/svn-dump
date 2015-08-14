package GUI.Components
{
    import flash.events.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import mx.styles.*;

    public class ExtendedHSlider extends Canvas implements IBindingClient
    {
        private var _embed_mxml_____data_src_gfx_embedded_slider_slider_arrow_e_highlight_png_1277632294:Class;
        private var _intervalWidth:Number;
        private var _795618446sliderBar:Canvas;
        private var _1224577496handle:Image;
        private var _handleMin:int;
        private var _snapInterval:Number = 1;
        private var _embed_mxml_____data_src_gfx_embedded_slider_slider_arrow_w_inactive_png_251234950:Class;
        private var _embed_mxml_____data_src_gfx_embedded_slider_slider_BG_png_1809072365:Class;
        private var _handleMax:int;
        private var _embed_mxml_____data_src_gfx_embedded_slider_slider_arrow_e_standard_png_1341751878:Class;
        private var _embed_mxml_____data_src_gfx_embedded_slider_slider_we_png_546138488:Class;
        var _watchers:Array;
        private var _embed_mxml_____data_src_gfx_embedded_slider_slider_arrow_w_highlight_png_332927322:Class;
        private var _handleRange:int;
        private var _handleOffset:Number;
        private var _embed_mxml_____data_src_gfx_embedded_slider_slider_arrow_e_inactive_png_1257876294:Class;
        private var _liveDragging:Boolean = false;
        var _bindingsBeginWithWord:Object;
        private var _minimum:Number = 0;
        private const DRAW_REAL_TICKS:Boolean = true;
        private const DRAW_CLICK_AREAS:Boolean = true;
        var _bindingsByDestination:Object;
        private var _maximum:Number = 10;
        var _bindings:Array;
        public var _ExtendedHSlider_Button1:Button;
        public var _ExtendedHSlider_Button2:Button;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _value:Number = 0;
        private var _embed_mxml_____data_src_gfx_embedded_slider_slider_arrow_w_standard_png_148478022:Class;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function ExtendedHSlider()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:40, height:12, childDescriptors:[new UIComponentDescriptor({type:Canvas, id:"sliderBar", events:{click:"__sliderBar_click"}, stylesFactory:function () : void
                {
                    null.left = this;
                    this.right = "15";
                    this.backgroundSize = "100%";
                    this.backgroundImage = _embed_mxml_____data_src_gfx_embedded_slider_slider_BG_png_1809072365;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null};
                }// end function
                }), new UIComponentDescriptor({type:Button, id:"_ExtendedHSlider_Button1", events:{click:"___ExtendedHSlider_Button1_click"}, stylesFactory:function () : void
                {
                    null.upSkin = this;
                    this.downSkin = _embed_mxml_____data_src_gfx_embedded_slider_slider_arrow_w_highlight_png_332927322;
                    this.overSkin = _embed_mxml_____data_src_gfx_embedded_slider_slider_arrow_w_highlight_png_332927322;
                    this.disabledSkin = _embed_mxml_____data_src_gfx_embedded_slider_slider_arrow_w_inactive_png_251234950;
                    this.left = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {width:12, height:12};
                }// end function
                }), new UIComponentDescriptor({type:Button, id:"_ExtendedHSlider_Button2", events:{click:"___ExtendedHSlider_Button2_click"}, stylesFactory:function () : void
                {
                    null.upSkin = this;
                    this.downSkin = _embed_mxml_____data_src_gfx_embedded_slider_slider_arrow_e_highlight_png_1277632294;
                    this.overSkin = _embed_mxml_____data_src_gfx_embedded_slider_slider_arrow_e_highlight_png_1277632294;
                    this.disabledSkin = _embed_mxml_____data_src_gfx_embedded_slider_slider_arrow_e_inactive_png_1257876294;
                    this.right = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:12, height:12};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"handle", events:{mouseDown:"__handle_mouseDown"}, propertiesFactory:function () : Object
                {
                    return {null:null, width:35, height:10, y:1};
                }// end function
                })]};
            }// end function
            });
            this._embed_mxml_____data_src_gfx_embedded_slider_slider_BG_png_1809072365 = ExtendedHSlider__embed_mxml_____data_src_gfx_embedded_slider_slider_BG_png_1809072365;
            this._embed_mxml_____data_src_gfx_embedded_slider_slider_arrow_e_highlight_png_1277632294 = ExtendedHSlider__embed_mxml_____data_src_gfx_embedded_slider_slider_arrow_e_highlight_png_1277632294;
            this._embed_mxml_____data_src_gfx_embedded_slider_slider_arrow_e_inactive_png_1257876294 = ExtendedHSlider__embed_mxml_____data_src_gfx_embedded_slider_slider_arrow_e_inactive_png_1257876294;
            this._embed_mxml_____data_src_gfx_embedded_slider_slider_arrow_e_standard_png_1341751878 = ExtendedHSlider__embed_mxml_____data_src_gfx_embedded_slider_slider_arrow_e_standard_png_1341751878;
            this._embed_mxml_____data_src_gfx_embedded_slider_slider_arrow_w_highlight_png_332927322 = ExtendedHSlider__embed_mxml_____data_src_gfx_embedded_slider_slider_arrow_w_highlight_png_332927322;
            this._embed_mxml_____data_src_gfx_embedded_slider_slider_arrow_w_inactive_png_251234950 = ExtendedHSlider__embed_mxml_____data_src_gfx_embedded_slider_slider_arrow_w_inactive_png_251234950;
            this._embed_mxml_____data_src_gfx_embedded_slider_slider_arrow_w_standard_png_148478022 = ExtendedHSlider__embed_mxml_____data_src_gfx_embedded_slider_slider_arrow_w_standard_png_148478022;
            this._embed_mxml_____data_src_gfx_embedded_slider_slider_we_png_546138488 = ExtendedHSlider__embed_mxml_____data_src_gfx_embedded_slider_slider_we_png_546138488;
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            if (!this.styleDeclaration)
            {
                this.styleDeclaration = new CSSStyleDeclaration();
            }
            this.styleDeclaration.defaultFactory = function () : void
            {
                this.disabledOverlayAlpha = 0;
                return;
            }// end function
            ;
            this.width = 40;
            this.height = 12;
            this.addEventListener("creationComplete", this.___ExtendedHSlider_Canvas1_creationComplete);
            return;
        }// end function

        private function _ExtendedHSlider_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.enabled;
            _loc_1 = this.enabled;
            _loc_1 = this.enabled;
            return;
        }// end function

        override public function initialize() : void
        {
            var target:ExtendedHSlider;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._ExtendedHSlider_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ExtendedHSliderWatcherSetupUtil");
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

        public function ___ExtendedHSlider_Canvas1_creationComplete(event:FlexEvent) : void
        {
            this.updateLayout();
            return;
        }// end function

        public function get minimum() : Number
        {
            return this._minimum;
        }// end function

        public function ___ExtendedHSlider_Button1_click(event:MouseEvent) : void
        {
            this.leftClickHandler();
            return;
        }// end function

        public function __sliderBar_click(event:MouseEvent) : void
        {
            this.moveSliderOnClick();
            return;
        }// end function

        public function set minimum(param1:Number) : void
        {
            var _loc_2:* = param1;
            this._value = param1;
            this._minimum = _loc_2;
            dispatchEvent(new SliderEvent(SliderEvent.CHANGE));
            this.updateIntervalWidth();
            return;
        }// end function

        public function get maximum() : Number
        {
            return this._maximum;
        }// end function

        public function get sliderBar() : Canvas
        {
            return this._795618446sliderBar;
        }// end function

        public function get handle() : Image
        {
            return this._1224577496handle;
        }// end function

        public function set liveDragging(param1:Boolean) : void
        {
            this._liveDragging = param1;
            return;
        }// end function

        private function startSliderDrag(event:MouseEvent) : void
        {
            this._handleOffset = this.handle.contentMouseX;
            Application.application.addEventListener(MouseEvent.MOUSE_UP, this.stopSliderDrag);
            Application.application.addEventListener(MouseEvent.MOUSE_MOVE, this.moveSliderOnDrag);
            return;
        }// end function

        private function updateIntervalWidth() : void
        {
            this._intervalWidth = this._handleRange / (this._maximum - this._minimum);
            this.updateHandle();
            return;
        }// end function

        public function set maximum(param1:Number) : void
        {
            this._maximum = param1;
            this._value = this._minimum;
            dispatchEvent(new SliderEvent(SliderEvent.CHANGE));
            this.updateIntervalWidth();
            return;
        }// end function

        private function updateHandle() : void
        {
            var _loc_1:Number = NaN;
            if (this.handle)
            {
                _loc_1 = this._value - this._minimum;
                this.handle.x = this._handleMin + _loc_1 * this._intervalWidth;
            }
            return;
        }// end function

        private function updateLayout() : void
        {
            this._handleMin = this.sliderBar.x + 1;
            this._handleMax = this.sliderBar.x + this.sliderBar.width - this.handle.width - 1;
            this._handleRange = this._handleMax - this._handleMin;
            this.updateIntervalWidth();
            return;
        }// end function

        private function stopSliderDrag(event:MouseEvent) : void
        {
            Application.application.removeEventListener(MouseEvent.MOUSE_MOVE, this.moveSliderOnDrag);
            Application.application.removeEventListener(MouseEvent.MOUSE_UP, this.stopSliderDrag);
            return;
        }// end function

        private function leftClickHandler() : void
        {
            if (this._value > this._minimum)
            {
                this.value = this.value - this._snapInterval;
            }
            return;
        }// end function

        public function get liveDragging() : Boolean
        {
            return this._liveDragging;
        }// end function

        private function rightClickHandler() : void
        {
            if (this._value < this._maximum)
            {
                this.value = this.value + this._snapInterval;
            }
            return;
        }// end function

        public function set handle(param1:Image) : void
        {
            var _loc_2:* = this._1224577496handle;
            if (_loc_2 !== param1)
            {
                this._1224577496handle = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "handle", _loc_2, param1));
            }
            return;
        }// end function

        private function moveSliderOnDrag(event:MouseEvent) : void
        {
            var _loc_2:Number = NaN;
            if (this.contentMouseX < this._handleMin)
            {
                this.value = this._minimum;
            }
            else if (this.contentMouseX > this._handleMax + (this.handle.width - this.handle.contentMouseX))
            {
                this.value = this._maximum;
            }
            else
            {
                _loc_2 = Math.round((this.contentMouseX - this._handleMin - this.handle.width / 2) / this._intervalWidth + this._minimum);
                this.value = _loc_2 < this._minimum ? (this._minimum) : (_loc_2);
            }
            return;
        }// end function

        private function _ExtendedHSlider_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Boolean
            {
                return this.enabled;
            }// end function
            , function (param1:Boolean) : void
            {
                null.enabled = null;
                return;
            }// end function
            , "_ExtendedHSlider_Button1.enabled");
            result[0] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return this.enabled;
            }// end function
            , function (param1:Boolean) : void
            {
                _ExtendedHSlider_Button2.enabled = param1;
                return;
            }// end function
            , "_ExtendedHSlider_Button2.enabled");
            result[1] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return this.enabled;
            }// end function
            , function (param1:Boolean) : void
            {
                null.visible = param1;
                return;
            }// end function
            , "handle.visible");
            result[2] = binding;
            return result;
        }// end function

        public function set value(param1:Number) : void
        {
            if (param1 != this._value)
            {
                this._value = param1;
                this.updateHandle();
                dispatchEvent(new SliderEvent(SliderEvent.CHANGE, false, false, -1, param1));
            }
            return;
        }// end function

        public function ___ExtendedHSlider_Button2_click(event:MouseEvent) : void
        {
            this.rightClickHandler();
            return;
        }// end function

        public function __handle_mouseDown(event:MouseEvent) : void
        {
            this.startSliderDrag(event);
            return;
        }// end function

        private function moveSliderOnClick() : void
        {
            var _loc_1:* = Math.round((this.contentMouseX - this._handleMin - this.handle.width / 2) / this._intervalWidth + this._minimum);
            if (_loc_1 < this._minimum)
            {
                this.value = this._minimum;
            }
            else if (_loc_1 > this._maximum)
            {
                this.value = this._maximum;
            }
            else
            {
                this.value = _loc_1;
            }
            return;
        }// end function

        public function get value() : Number
        {
            return this._value;
        }// end function

        public function set sliderBar(param1:Canvas) : void
        {
            var _loc_2:* = this._795618446sliderBar;
            if (_loc_2 !== param1)
            {
                this._795618446sliderBar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "sliderBar", _loc_2, param1));
            }
            return;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            ExtendedHSlider._watcherSetupUtil = param1;
            return;
        }// end function

    }
}
