package GUI.Components.ItemRenderer
{
    import GUI.Components.*;
    import com.bluebyte.bluefire.api.model.vo.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.binding.utils.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import mx.styles.*;

    public class ChannelBarItemRenderer extends Canvas implements IBindingClient
    {
        private var _timer:Timer;
        var _bindingsByDestination:Object;
        var _watchers:Array;
        var _bindingsBeginWithWord:Object;
        var _bindings:Array;
        private var _changeWatcher:ChangeWatcher;
        private var _documentDescriptor_:UIComponentDescriptor;
        public var _ChannelBarItemRenderer_Label1:Label;
        public static const PRIVATE_LIST_REMOVE:String = "privateListRemove";
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function ChannelBarItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {childDescriptors:[new UIComponentDescriptor({type:Label, id:"_ChannelBarItemRenderer_Label1", stylesFactory:function () : void
                {
                    this.left = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:100, minWidth:48, maxWidth:48};
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
                this.verticalCenter = "0";
                this.backgroundAlpha = 1;
                this.backgroundSize = "100%";
                return;
            }// end function
            ;
            this.percentWidth = 25;
            this.percentHeight = 50;
            this.minWidth = 75;
            this.maxWidth = 75;
            this.addEventListener("creationComplete", this.___ChannelBarItemRenderer_Canvas1_creationComplete);
            return;
        }// end function

        protected function canvas1_creationCompleteHandler(event:FlexEvent) : void
        {
            this._timer.addEventListener(TimerEvent.TIMER, this.onTimer);
            return;
        }// end function

        override public function initialize() : void
        {
            var target:ChannelBarItemRenderer;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._ChannelBarItemRenderer_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ItemRenderer_ChannelBarItemRendererWatcherSetupUtil");
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

        override public function set data(param1:Object) : void
        {
            var _loc_2:int = 0;
            super.data = param1;
            if (!this._timer)
            {
                this._timer = new Timer(1000, _loc_2);
            }
            _loc_2 = 6;
            if ((param1 as ChannelVO).name == "whisper")
            {
                _loc_2 = 0;
            }
            this._timer.repeatCount = _loc_2;
            if (this._changeWatcher)
            {
                this._changeWatcher.unwatch();
            }
            this._changeWatcher = ChangeWatcher.watch(super.data, "newMessages", this.handleNewMessageChange);
            if (param1 is ChannelVO)
            {
                if (ChannelBar(owner).selectedItem == data)
                {
                    this.styleName = StyleManager.getStyleDeclaration(".chatTabSelected");
                }
                else if (ChannelVO(data).newMessages)
                {
                    this.styleName = StyleManager.getStyleDeclaration(".chatTabNewMessage");
                }
                else
                {
                    this.styleName = StyleManager.getStyleDeclaration(".chatTab");
                }
            }
            return;
        }// end function

        private function handleNewMessageChange(event:PropertyChangeEvent) : void
        {
            if (event.newValue)
            {
                this._timer.reset();
                this._timer.start();
            }
            else
            {
                this._timer.stop();
            }
            return;
        }// end function

        private function onTimer(event:TimerEvent) : void
        {
            if (this.styleName == StyleManager.getStyleDeclaration(".chatTabNewMessage"))
            {
                this.styleName = StyleManager.getStyleDeclaration(".chatTab");
            }
            else if (this.styleName == StyleManager.getStyleDeclaration(".chatTab"))
            {
                this.styleName = StyleManager.getStyleDeclaration(".chatTabNewMessage");
            }
            return;
        }// end function

        private function _ChannelBarItemRenderer_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = (data as ChannelVO).label;
            return;
        }// end function

        private function _ChannelBarItemRenderer_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = (data as ChannelVO).label;
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "_ChannelBarItemRenderer_Label1.text");
            result[0] = binding;
            return result;
        }// end function

        public function ___ChannelBarItemRenderer_Canvas1_creationComplete(event:FlexEvent) : void
        {
            this.canvas1_creationCompleteHandler(event);
            return;
        }// end function

        private function HandleRemoveClick(event:Event) : void
        {
            this.dispatchEvent(new ListEvent(PRIVATE_LIST_REMOVE, true, false, 0, TileList(owner).dataProvider.getItemIndex(data)));
            event.stopImmediatePropagation();
            event.preventDefault();
            return;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
