package GUI.Components
{
    import GUI.Components.ToolTips.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.effects.*;
    import mx.events.*;

    public class BasicPanel extends Canvas implements IBindingClient
    {
        private var _1282133823fadeIn:Fade;
        var _bindingsByDestination:Object;
        var _bindingsBeginWithWord:Object;
        private var _2082343164btnClose:CloseButton;
        var _watchers:Array;
        private var _951530617content:Canvas;
        private var _1115058732headline:Label;
        private var _1091436750fadeOut:Fade;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _subComponents:Array;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function BasicPanel()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {childDescriptors:[new UIComponentDescriptor({type:CloseButton, id:"btnClose", stylesFactory:function () : void
                {
                    this.top = "5";
                    this.right = "15";
                    return;
                }// end function
                }), new UIComponentDescriptor({type:Label, id:"headline", events:{toolTipCreate:"__headline_toolTipCreate"}, stylesFactory:function () : void
                {
                    null.top = this;
                    this.fontWeight = "bold";
                    this.textAlign = "center";
                    return;
                }// end function
                }), new UIComponentDescriptor({type:Canvas, id:"content", stylesFactory:function () : void
                {
                    this.top = "30";
                    this.bottom = "1";
                    this.left = "7";
                    this.right = "5";
                    return;
                }// end function
                })]};
            }// end function
            });
            this._subComponents = [];
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.cacheAsBitmap = true;
            this.styleName = "basicPanel";
            this._BasicPanel_Fade1_i();
            this._BasicPanel_Fade2_i();
            this.addEventListener("creationComplete", this.___BasicPanel_Canvas1_creationComplete);
            return;
        }// end function

        public function set content(param1:Canvas) : void
        {
            var _loc_2:* = this._951530617content;
            if (_loc_2 !== param1)
            {
                this._951530617content = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "content", _loc_2, param1));
            }
            return;
        }// end function

        public function set subComponents(param1:Array) : void
        {
            this._subComponents = param1;
            return;
        }// end function

        private function _BasicPanel_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function ()
            {
                return fadeIn;
            }// end function
            , function (param1) : void
            {
                null.setStyle(this, param1);
                return;
            }// end function
            , "this.showEffect");
            result[0] = binding;
            binding = new Binding(this, function ()
            {
                return fadeOut;
            }// end function
            , function (param1) : void
            {
                null.setStyle(this, param1);
                return;
            }// end function
            , "this.hideEffect");
            result[1] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = label;
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "headline.text");
            result[2] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = headline.width > width - 76 ? ((width - 76 - headline.width) / 2) : (0);
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.setStyle("horizontalCenter", param1);
                return;
            }// end function
            , "headline.horizontalCenter");
            result[3] = binding;
            binding = new Binding(this, function () : Number
            {
                return null - null;
            }// end function
            , function (param1:Number) : void
            {
                null.maxWidth = null;
                return;
            }// end function
            , "headline.maxWidth");
            result[4] = binding;
            return result;
        }// end function

        public function get fadeIn() : Fade
        {
            return this._1282133823fadeIn;
        }// end function

        public function set fadeIn(param1:Fade) : void
        {
            var _loc_2:* = this._1282133823fadeIn;
            if (_loc_2 !== param1)
            {
                this._1282133823fadeIn = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "fadeIn", _loc_2, param1));
            }
            return;
        }// end function

        private function addSubComponents() : void
        {
            var _loc_1:int = 0;
            while (_loc_1 < this._subComponents.length)
            {
                
                this.content.addChild(this._subComponents[_loc_1]);
                _loc_1++;
            }
            return;
        }// end function

        override public function initialize() : void
        {
            var target:BasicPanel;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._BasicPanel_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_BasicPanelWatcherSetupUtil");
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

        public function get headline() : Label
        {
            return this._1115058732headline;
        }// end function

        public function __fadeOut_effectEnd(event:EffectEvent) : void
        {
            globalFlash.gui.ShowQuestWindowDelayed();
            return;
        }// end function

        private function _BasicPanel_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.fadeIn;
            _loc_1 = this.fadeOut;
            _loc_1 = label;
            _loc_1 = this.headline.width > width - 76 ? ((width - 76 - this.headline.width) / 2) : (0);
            _loc_1 = width - 52;
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

        public function ___BasicPanel_Canvas1_creationComplete(event:FlexEvent) : void
        {
            this.addSubComponents();
            return;
        }// end function

        public function get fadeOut() : Fade
        {
            return this._1091436750fadeOut;
        }// end function

        public function set headline(param1:Label) : void
        {
            var _loc_2:* = this._1115058732headline;
            if (_loc_2 !== param1)
            {
                this._1115058732headline = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "headline", _loc_2, param1));
            }
            return;
        }// end function

        public function __headline_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        private function _BasicPanel_Fade1_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeIn = _loc_1;
            _loc_1.alphaFrom = 0;
            _loc_1.alphaTo = 1;
            _loc_1.duration = 150;
            return _loc_1;
        }// end function

        public function set btnClose(param1:CloseButton) : void
        {
            var _loc_2:* = this._2082343164btnClose;
            if (_loc_2 !== param1)
            {
                this._2082343164btnClose = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnClose", _loc_2, param1));
            }
            return;
        }// end function

        public function get content() : Canvas
        {
            return this._951530617content;
        }// end function

        public function get btnClose() : CloseButton
        {
            return this._2082343164btnClose;
        }// end function

        private function _BasicPanel_Fade2_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeOut = _loc_1;
            _loc_1.alphaFrom = 1;
            _loc_1.alphaTo = 0;
            _loc_1.duration = 150;
            _loc_1.addEventListener("effectEnd", this.__fadeOut_effectEnd);
            return _loc_1;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            BasicPanel._watcherSetupUtil = param1;
            return;
        }// end function

    }
}
