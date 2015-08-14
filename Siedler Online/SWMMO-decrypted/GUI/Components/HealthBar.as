package GUI.Components
{
    import flash.display.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.core.*;
    import mx.events.*;
    import mx.styles.*;

    public class HealthBar extends Canvas implements IBindingClient
    {
        private var _embed_mxml__437613576:Class;
        var _bindingsByDestination:Object;
        var _bindingsBeginWithWord:Object;
        var _watchers:Array;
        private var _205206032greenBar:Canvas;
        private var _334252641barMask:Canvas;
        private var _embed_mxml__1351627513:Class;
        var _bindings:Array;
        private var _value:Number = 0;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function HealthBar()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:34, height:12, childDescriptors:[new UIComponentDescriptor({type:Canvas, id:"greenBar", stylesFactory:function () : void
                {
                    null.backgroundImage = this;
                    this.backgroundSize = "100%";
                    this.top = "2";
                    this.bottom = "2";
                    this.left = "8";
                    this.right = "10";
                    return;
                }// end function
                }), new UIComponentDescriptor({type:Canvas, id:"barMask", events:{creationComplete:"__barMask_creationComplete"}, stylesFactory:function () : void
                {
                    null.backgroundColor = this;
                    this.top = "2";
                    this.bottom = "2";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null, width:0};
                }// end function
                })]};
            }// end function
            });
            this._embed_mxml__1351627513 = HealthBar__embed_mxml__1351627513;
            this._embed_mxml__437613576 = HealthBar__embed_mxml__437613576;
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
                this.backgroundImage = _embed_mxml__1351627513;
                this.backgroundSize = "100%";
                return;
            }// end function
            ;
            this.width = 34;
            this.height = 12;
            return;
        }// end function

        private function _HealthBar_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.barMask;
            return;
        }// end function

        private function _HealthBar_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : DisplayObject
            {
                return barMask;
            }// end function
            , function (param1:DisplayObject) : void
            {
                greenBar.mask = param1;
                return;
            }// end function
            , "greenBar.mask");
            result[0] = binding;
            return result;
        }// end function

        public function set barMask(param1:Canvas) : void
        {
            var _loc_2:* = this._334252641barMask;
            if (_loc_2 !== param1)
            {
                this._334252641barMask = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "barMask", _loc_2, param1));
            }
            return;
        }// end function

        override public function initialize() : void
        {
            var target:HealthBar;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._HealthBar_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_HealthBarWatcherSetupUtil");
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

        private function updateBarMask() : void
        {
            if (this.barMask)
            {
                this.barMask.width = this.greenBar.width * this._value;
            }
            return;
        }// end function

        public function set greenBar(param1:Canvas) : void
        {
            var _loc_2:* = this._205206032greenBar;
            if (_loc_2 !== param1)
            {
                this._205206032greenBar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "greenBar", _loc_2, param1));
            }
            return;
        }// end function

        public function set value(param1:Number) : void
        {
            if (param1 < 0)
            {
                this._value = 0;
            }
            else if (param1 > 1)
            {
                this._value = 1;
            }
            else
            {
                this._value = param1;
                this.updateBarMask();
            }
            return;
        }// end function

        public function get greenBar() : Canvas
        {
            return this._205206032greenBar;
        }// end function

        public function get barMask() : Canvas
        {
            return this._334252641barMask;
        }// end function

        public function get value() : Number
        {
            return this._value;
        }// end function

        public function __barMask_creationComplete(event:FlexEvent) : void
        {
            this.updateBarMask();
            return;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            HealthBar._watcherSetupUtil = param1;
            return;
        }// end function

    }
}
