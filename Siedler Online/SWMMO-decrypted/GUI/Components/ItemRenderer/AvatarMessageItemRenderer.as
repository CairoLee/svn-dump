package GUI.Components.ItemRenderer
{
    import GUI.Assets.*;
    import GUI.Components.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.effects.*;
    import mx.events.*;
    import mx.styles.*;

    public class AvatarMessageItemRenderer extends Canvas implements IBindingClient
    {
        private var _1501988224headlineLabel:Label;
        private var _873639351messageBody:CustomText;
        var _bindingsByDestination:Object;
        var _bindingsBeginWithWord:Object;
        var _watchers:Array;
        private var displayDurationTicks:Number = 10000;
        private var _1091436750fadeOut:Fade;
        private var _100313435image:Image;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var hideTick:Number;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function AvatarMessageItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:250, childDescriptors:[new UIComponentDescriptor({type:Label, id:"headlineLabel", stylesFactory:function () : void
                {
                    this.color = 16777215;
                    this.fontWeight = "bold";
                    this.left = "61";
                    this.top = "8";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {width:177};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"image", stylesFactory:function () : void
                {
                    this.left = "0";
                    this.right = "185";
                    this.top = "5";
                    this.bottom = "5";
                    this.horizontalAlign = "center";
                    this.verticalAlign = "top";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:false};
                }// end function
                }), new UIComponentDescriptor({type:CustomText, id:"messageBody", stylesFactory:function () : void
                {
                    this.left = "63";
                    this.right = "14";
                    this.top = "26";
                    this.bottom = "5";
                    this.color = 16777215;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:false};
                }// end function
                })]};
            }// end function
            });
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
                this.backgroundSize = "100%";
                return;
            }// end function
            ;
            this.width = 250;
            this.minHeight = 82;
            this._AvatarMessageItemRenderer_Fade1_i();
            this.addEventListener("creationComplete", this.___AvatarMessageItemRenderer_Canvas1_creationComplete);
            this.addEventListener("rollOver", this.___AvatarMessageItemRenderer_Canvas1_rollOver);
            this.addEventListener("rollOut", this.___AvatarMessageItemRenderer_Canvas1_rollOut);
            this.addEventListener("addedToStage", this.___AvatarMessageItemRenderer_Canvas1_addedToStage);
            return;
        }// end function

        public function get headlineLabel() : Label
        {
            return this._1501988224headlineLabel;
        }// end function

        private function _AvatarMessageItemRenderer_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.fadeOut;
            return;
        }// end function

        public function set headlineLabel(param1:Label) : void
        {
            var _loc_2:* = this._1501988224headlineLabel;
            if (_loc_2 !== param1)
            {
                this._1501988224headlineLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "headlineLabel", _loc_2, param1));
            }
            return;
        }// end function

        public function set messageBody(param1:CustomText) : void
        {
            var _loc_2:* = this._873639351messageBody;
            if (_loc_2 !== param1)
            {
                this._873639351messageBody = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "messageBody", _loc_2, param1));
            }
            return;
        }// end function

        override public function initialize() : void
        {
            var target:AvatarMessageItemRenderer;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._AvatarMessageItemRenderer_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ItemRenderer_AvatarMessageItemRendererWatcherSetupUtil");
                var _loc_2:* = watcherSetupUtilClass;
                _loc_2.watcherSetupUtilClass["init"](null);
            }
            _watcherSetupUtil.setup(this, function (param1:String)
            {
                return null[param1];
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

        public function ___AvatarMessageItemRenderer_Canvas1_rollOut(event:MouseEvent) : void
        {
            this.setStyle("backgroundImage", gAssetManager.GetClass("AvatarMessageRed"));
            return;
        }// end function

        public function get image() : Image
        {
            return this._100313435image;
        }// end function

        public function __fadeOut_effectEnd(event:EffectEvent) : void
        {
            this.parent.removeChild(this);
            return;
        }// end function

        public function ___AvatarMessageItemRenderer_Canvas1_addedToStage(event:Event) : void
        {
            this.SetHideTime();
            return;
        }// end function

        public function set fadeOut(param1:Fade) : void
        {
            var _loc_2:* = this._1091436750fadeOut;
            if (_loc_2 !== param1)
            {
                this._1091436750fadeOut = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "fadeOut", _loc_2, param1));
            }
            return;
        }// end function

        private function _AvatarMessageItemRenderer_Fade1_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeOut = _loc_1;
            _loc_1.alphaFrom = 1;
            _loc_1.alphaTo = 0;
            _loc_1.duration = 1000;
            _loc_1.addEventListener("effectEnd", this.__fadeOut_effectEnd);
            return _loc_1;
        }// end function

        private function SetHideTime() : void
        {
            this.hideTick = global.ui.mCalculateTicks.GetLastTick() + this.displayDurationTicks;
            this.addEventListener(Event.ENTER_FRAME, this.CheckDisplay);
            return;
        }// end function

        public function get messageBody() : CustomText
        {
            return this._873639351messageBody;
        }// end function

        public function ___AvatarMessageItemRenderer_Canvas1_rollOver(event:MouseEvent) : void
        {
            this.setStyle("backgroundImage", gAssetManager.GetClass("AvatarMessageRedHighlight"));
            return;
        }// end function

        public function get fadeOut() : Fade
        {
            return this._1091436750fadeOut;
        }// end function

        private function _AvatarMessageItemRenderer_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function ()
            {
                return fadeOut;
            }// end function
            , function (param1) : void
            {
                this.setStyle("hideEffect", param1);
                return;
            }// end function
            , "this.hideEffect");
            result[0] = binding;
            return result;
        }// end function

        public function ___AvatarMessageItemRenderer_Canvas1_creationComplete(event:FlexEvent) : void
        {
            this.setStyle("backgroundImage", gAssetManager.GetClass("AvatarMessageRed"));
            return;
        }// end function

        private function CheckDisplay(event:Event) : void
        {
            if (global.ui.mCalculateTicks.GetLastTick() >= this.hideTick)
            {
                this.removeEventListener(Event.ENTER_FRAME, this.CheckDisplay);
                this.visible = false;
            }
            return;
        }// end function

        public function set image(param1:Image) : void
        {
            var _loc_2:* = this._100313435image;
            if (_loc_2 !== param1)
            {
                this._100313435image = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "image", _loc_2, param1));
            }
            return;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
