package com.bluebyte.bluefire.flex3.defaultClient
{
    import com.bluebyte.bluefire.api.model.vo.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.styles.*;

    public class ButtonBarItemRenderer extends Canvas implements IBindingClient
    {
        public var _ButtonBarItemRenderer_Label1:Label;
        var _bindingsByDestination:Object;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        var _bindingsBeginWithWord:Object;
        var _watchers:Array;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function ButtonBarItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {childDescriptors:[new UIComponentDescriptor({type:HBox, propertiesFactory:function () : Object
                {
                    var _loc_1:String = null;
                    return {childDescriptors:[new UIComponentDescriptor({type:Label, id:"_ButtonBarItemRenderer_Label1", stylesFactory:function () : void
                    {
                        null.left = this;
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {null:null, percentWidth:100};
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
            if (!this.styleDeclaration)
            {
                this.styleDeclaration = new CSSStyleDeclaration();
            }
            this.styleDeclaration.defaultFactory = function () : void
            {
                this.verticalCenter = "0";
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

        private function _ButtonBarItemRenderer_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = (data as ChannelVO).important && (data as ChannelVO).newMessages ? (4294901760) : (16777215);
            _loc_1 = (data as ChannelVO).newMessages ? ("*" + (data as ChannelVO).name) : ((data as ChannelVO).name);
            return;
        }// end function

        private function _ButtonBarItemRenderer_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : uint
            {
                return (data as ChannelVO).important && (data as ChannelVO).newMessages ? (4294901760) : (16777215);
            }// end function
            , function (param1:uint) : void
            {
                this.setStyle("backgroundColor", param1);
                return;
            }// end function
            , "this.backgroundColor");
            result[0] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = (null as null).newMessages ? ("*" + (data as ChannelVO).name) : ((data as ChannelVO).name);
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "_ButtonBarItemRenderer_Label1.text");
            result[1] = binding;
            return result;
        }// end function

        override public function initialize() : void
        {
            var target:ButtonBarItemRenderer;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._ButtonBarItemRenderer_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_com_bluebyte_bluefire_flex3_defaultClient_ButtonBarItemRendererWatcherSetupUtil");
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
            return;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            ButtonBarItemRenderer._watcherSetupUtil = param1;
            return;
        }// end function

    }
}
