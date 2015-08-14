package GUI.Components.ItemRenderer
{
    import com.bluebyte.bluefire.api.model.vo.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import mx.styles.*;

    public class ChatTabPrivateListItemRenderer extends Canvas implements IBindingClient
    {
        public var _ChatTabPrivateListItemRenderer_Label1:Label;
        var _bindingsByDestination:Object;
        var _bindings:Array;
        var _bindingsBeginWithWord:Object;
        private var _documentDescriptor_:UIComponentDescriptor;
        var _watchers:Array;
        public static const PRIVATE_LIST_REMOVE:String = "privateListRemove";
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function ChatTabPrivateListItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {childDescriptors:[new UIComponentDescriptor({type:Label, id:"_ChatTabPrivateListItemRenderer_Label1", stylesFactory:function () : void
                {
                    null.left = this;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:100, minWidth:60, maxWidth:60};
                }// end function
                }), new UIComponentDescriptor({type:Button, events:{click:"___ChatTabPrivateListItemRenderer_Button1_click"}, stylesFactory:function () : void
                {
                    this.right = "3";
                    this.bottom = "6";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {styleName:"closeSmall", width:13, height:12};
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
                null.verticalCenter = this;
                this.backgroundAlpha = 1;
                this.backgroundSize = "100%";
                return;
            }// end function
            ;
            this.percentWidth = 25;
            this.percentHeight = 50;
            this.minWidth = 75;
            this.maxWidth = 75;
            return;
        }// end function

        public function ___ChatTabPrivateListItemRenderer_Button1_click(event:MouseEvent) : void
        {
            this.HandleRemoveClick(event);
            return;
        }// end function

        private function _ChatTabPrivateListItemRenderer_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = (data as ChannelVO).name;
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "_ChatTabPrivateListItemRenderer_Label1.text");
            result[0] = binding;
            return result;
        }// end function

        override public function initialize() : void
        {
            var target:ChatTabPrivateListItemRenderer;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._ChatTabPrivateListItemRenderer_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ItemRenderer_ChatTabPrivateListItemRendererWatcherSetupUtil");
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
            super.data = param1;
            if (param1 is ChannelVO)
            {
                if (TileList(owner).selectedItem == data)
                {
                    this.styleName = StyleManager.getStyleDeclaration(".chatPrivateListSelected");
                }
                else if (ChannelVO(data).newMessages)
                {
                    this.styleName = StyleManager.getStyleDeclaration(".chatPrivateListNewMessage");
                }
                else
                {
                    this.styleName = StyleManager.getStyleDeclaration(".chatPrivateList");
                }
            }
            return;
        }// end function

        private function HandleRemoveClick(event:Event) : void
        {
            this.dispatchEvent(new ListEvent(PRIVATE_LIST_REMOVE, true, false, 0, TileList(owner).dataProvider.getItemIndex(data)));
            event.stopImmediatePropagation();
            event.preventDefault();
            return;
        }// end function

        private function _ChatTabPrivateListItemRenderer_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = (data as ChannelVO).name;
            return;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
