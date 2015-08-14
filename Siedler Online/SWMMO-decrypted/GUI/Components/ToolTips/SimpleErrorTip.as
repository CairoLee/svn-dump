package GUI.Components.ToolTips
{
    import GUI.Components.ToolTips.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class SimpleErrorTip extends Canvas implements IDataToolTip, IBindingClient
    {
        private var _error:Boolean = false;
        var _bindingsBeginWithWord:Object;
        var _bindingsByDestination:Object;
        var _watchers:Array;
        private var _2014185703tipLabel:Label;
        private var _91291148_text:String;
        private var _documentDescriptor_:UIComponentDescriptor;
        var _bindings:Array;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function SimpleErrorTip()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                return {childDescriptors:[new UIComponentDescriptor({type:Label, id:"tipLabel", stylesFactory:function () : void
                {
                    null.top = this;
                    this.bottom = "2";
                    this.left = "5";
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
            this.mouseEnabled = false;
            this.mouseChildren = false;
            this.styleName = "toolTip";
            return;
        }// end function

        public function set text(param1:String) : void
        {
            this._text = param1;
            if (this._error)
            {
                this.tipLabel.setStyle("fontWeight", "normal");
                this.tipLabel.setStyle("color", 16711680);
            }
            else
            {
                this.tipLabel.setStyle("fontWeight", "bold");
                this.tipLabel.setStyle("color", 16777215);
            }
            return;
        }// end function

        override public function initialize() : void
        {
            var target:SimpleErrorTip;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._SimpleErrorTip_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ToolTips_SimpleErrorTipWatcherSetupUtil");
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

        private function get _text() : String
        {
            return this._91291148_text;
        }// end function

        private function _SimpleErrorTip_bindingsSetup() : Array
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
                tipLabel.text = param1;
                return;
            }// end function
            , "tipLabel.text");
            result[0] = binding;
            return result;
        }// end function

        public function get tipLabel() : Label
        {
            return this._2014185703tipLabel;
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

        public function set toolTipData(param1:Object) : void
        {
            this._error = param1 as Boolean;
            return;
        }// end function

        public function get text() : String
        {
            return this._text;
        }// end function

        private function _SimpleErrorTip_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this._text;
            return;
        }// end function

        public function set tipLabel(param1:Label) : void
        {
            var _loc_2:* = this._2014185703tipLabel;
            if (_loc_2 !== param1)
            {
                this._2014185703tipLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "tipLabel", _loc_2, param1));
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
