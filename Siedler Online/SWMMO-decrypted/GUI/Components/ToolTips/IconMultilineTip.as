package GUI.Components.ToolTips
{
    import GUI.Components.*;
    import GUI.Components.ToolTips.*;
    import flash.display.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class IconMultilineTip extends Canvas implements IDataToolTip, IBindingClient
    {
        public var _IconMultilineTip_CustomText1:CustomText;
        var _bindingsByDestination:Object;
        var _bindingsBeginWithWord:Object;
        var _watchers:Array;
        private var _icon:Bitmap;
        private var _91291148_text:String;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _1792450820toolTipIcon:Image;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function IconMultilineTip()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {childDescriptors:[new UIComponentDescriptor({type:Image, id:"toolTipIcon", stylesFactory:function () : void
                {
                    this.top = "2";
                    this.left = "5";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null, height:48, scaleContent:false};
                }// end function
                }), new UIComponentDescriptor({type:CustomText, id:"_IconMultilineTip_CustomText1", stylesFactory:function () : void
                {
                    this.top = "2";
                    this.bottom = "2";
                    this.left = "60";
                    this.right = "5";
                    this.fontWeight = "bold";
                    this.color = 16777215;
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
            this.minWidth = 300;
            this.minHeight = 52;
            this.styleName = "toolTip";
            return;
        }// end function

        public function get toolTipIcon() : Image
        {
            return this._1792450820toolTipIcon;
        }// end function

        override public function initialize() : void
        {
            var target:IconMultilineTip;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._IconMultilineTip_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ToolTips_IconMultilineTipWatcherSetupUtil");
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

        private function get _text() : String
        {
            return this._91291148_text;
        }// end function

        private function _IconMultilineTip_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : String
            {
                var _loc_1:String = null;
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "_IconMultilineTip_CustomText1.text");
            result[0] = binding;
            return result;
        }// end function

        public function set toolTipData(param1:Object) : void
        {
            this._icon = param1 as Bitmap;
            return;
        }// end function

        private function set _text(param1:String) : void
        {
            var _loc_2:* = this._91291148_text;
            if (_loc_2 !== param1)
            {
                this._91291148_text = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "_text", _loc_2, param1));
            }
            return;
        }// end function

        public function get text() : String
        {
            return this._text;
        }// end function

        public function set toolTipIcon(param1:Image) : void
        {
            var _loc_2:* = this._1792450820toolTipIcon;
            if (_loc_2 !== param1)
            {
                this._1792450820toolTipIcon = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "toolTipIcon", _loc_2, param1));
            }
            return;
        }// end function

        private function _IconMultilineTip_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this._text;
            return;
        }// end function

        public function set text(param1:String) : void
        {
            this._text = param1;
            this.toolTipIcon.source = this._icon;
            return;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
