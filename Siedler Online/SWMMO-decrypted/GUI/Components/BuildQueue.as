package GUI.Components
{
    import GUI.Components.ItemRenderer.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.effects.*;
    import mx.events.*;

    public class BuildQueue extends Canvas implements IBindingClient
    {
        private var _1282133823fadeIn:Fade;
        var _bindingsBeginWithWord:Object;
        private var _817942897buildExtension:BuildQueueExtension;
        var _bindingsByDestination:Object;
        private var _3322014list:List;
        var _watchers:Array;
        private var _1091436750fadeOut:Fade;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function BuildQueue()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {height:360, childDescriptors:[new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                {
                    this.left = "0";
                    this.right = "0";
                    this.top = "0";
                    this.bottom = "30";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {styleName:"buildQueue"};
                }// end function
                }), new UIComponentDescriptor({type:List, id:"list", stylesFactory:function () : void
                {
                    this.paddingLeft = 0;
                    this.paddingTop = 0;
                    this.paddingRight = 0;
                    this.paddingBottom = 0;
                    this.backgroundAlpha = 0;
                    this.left = "10";
                    this.top = "14";
                    this.bottom = "50";
                    this.right = "8";
                    this.borderThickness = 0;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null, verticalScrollPolicy:"auto", selectable:false, itemRenderer:_BuildQueue_ClassFactory1_c(), height:279};
                }// end function
                }), new UIComponentDescriptor({type:BuildQueueExtension, id:"buildExtension", stylesFactory:function () : void
                {
                    null.left = this;
                    this.bottom = "0";
                    this.right = "0";
                    this.backgroundAlpha = 0;
                    this.borderThickness = 0;
                    this.paddingBottom = 0;
                    this.paddingLeft = 0;
                    this.paddingRight = 0;
                    this.paddingTop = 0;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:50};
                }// end function
                })]};
            }// end function
            });
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.cacheAsBitmap = true;
            this.height = 360;
            this.verticalScrollPolicy = "off";
            this.horizontalScrollPolicy = "off";
            this._BuildQueue_Fade1_i();
            this._BuildQueue_Fade2_i();
            this.addEventListener("scroll", this.___BuildQueue_Canvas1_scroll);
            return;
        }// end function

        public function get fadeIn() : Fade
        {
            return this._1282133823fadeIn;
        }// end function

        private function _BuildQueue_Fade1_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeIn = _loc_1;
            _loc_1.alphaFrom = 0;
            _loc_1.alphaTo = 1;
            _loc_1.duration = 150;
            return _loc_1;
        }// end function

        private function _BuildQueue_Fade2_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeOut = _loc_1;
            _loc_1.alphaFrom = 1;
            _loc_1.alphaTo = 0;
            _loc_1.duration = 150;
            return _loc_1;
        }// end function

        private function _BuildQueue_ClassFactory1_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = BuildQueueItemRenderer;
            return _loc_1;
        }// end function

        override public function initialize() : void
        {
            var target:BuildQueue;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._BuildQueue_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_BuildQueueWatcherSetupUtil");
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

        private function _BuildQueue_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Number
            {
                return list.maxVerticalScrollPosition > 0 ? (127) : (110);
            }// end function
            , function (param1:Number) : void
            {
                this.width = param1;
                return;
            }// end function
            , "this.width");
            result[0] = binding;
            binding = new Binding(this, function ()
            {
                return fadeIn;
            }// end function
            , function (param1) : void
            {
                this.setStyle("showEffect", param1);
                return;
            }// end function
            , "this.showEffect");
            result[1] = binding;
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
            result[2] = binding;
            return result;
        }// end function

        public function ___BuildQueue_Canvas1_scroll(event:ScrollEvent) : void
        {
            return;
        }// end function

        public function set buildExtension(param1:BuildQueueExtension) : void
        {
            var _loc_2:* = this._817942897buildExtension;
            if (_loc_2 !== param1)
            {
                this._817942897buildExtension = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "buildExtension", _loc_2, param1));
            }
            return;
        }// end function

        public function get list() : List
        {
            return this._3322014list;
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

        public function get buildExtension() : BuildQueueExtension
        {
            return this._817942897buildExtension;
        }// end function

        public function get fadeOut() : Fade
        {
            return this._1091436750fadeOut;
        }// end function

        public function set list(param1:List) : void
        {
            var _loc_2:* = this._3322014list;
            if (_loc_2 !== param1)
            {
                this._3322014list = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "list", _loc_2, param1));
            }
            return;
        }// end function

        private function _BuildQueue_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.list.maxVerticalScrollPosition > 0 ? (127) : (110);
            _loc_1 = this.fadeIn;
            _loc_1 = this.fadeOut;
            return;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
