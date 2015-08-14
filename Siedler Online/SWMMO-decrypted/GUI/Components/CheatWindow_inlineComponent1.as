package GUI.Components
{
    import GUI.Assets.*;
    import GUI.Components.ToolTips.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import mx.styles.*;

    public class CheatWindow_inlineComponent1 extends HBox implements IBindingClient
    {
        public var _CheatWindow_inlineComponent1_NumericStepper1:NumericStepper;
        var _bindingsByDestination:Object;
        var _bindingsBeginWithWord:Object;
        public var _CheatWindow_inlineComponent1_Image1:Image;
        var _watchers:Array;
        private var _88844982outerDocument:CheatWindow;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function CheatWindow_inlineComponent1()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:HBox, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {childDescriptors:[new UIComponentDescriptor({type:Image, id:"_CheatWindow_inlineComponent1_Image1", events:{toolTipCreate:"___CheatWindow_inlineComponent1_Image1_toolTipCreate"}}), new UIComponentDescriptor({type:NumericStepper, id:"_CheatWindow_inlineComponent1_NumericStepper1", events:{change:"___CheatWindow_inlineComponent1_NumericStepper1_change"}, propertiesFactory:function () : Object
                {
                    return {null:1, minimum:-99999, maximum:99999};
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
                null.paddingRight = this;
                this.paddingLeft = 5;
                return;
            }// end function
            ;
            return;
        }// end function

        private function _CheatWindow_inlineComponent1_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = gAssetManager.GetResourceIcon(data.name_string);
            _loc_1 = data.name_string;
            _loc_1 = data.amount;
            return;
        }// end function

        override public function initialize() : void
        {
            var target:CheatWindow_inlineComponent1;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._CheatWindow_inlineComponent1_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_CheatWindow_inlineComponent1WatcherSetupUtil");
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

        public function set outerDocument(param1:CheatWindow) : void
        {
            var _loc_2:* = this._88844982outerDocument;
            if (_loc_2 !== param1)
            {
                this._88844982outerDocument = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "outerDocument", _loc_2, param1));
            }
            return;
        }// end function

        public function ___CheatWindow_inlineComponent1_Image1_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function get outerDocument() : CheatWindow
        {
            return this._88844982outerDocument;
        }// end function

        public function ___CheatWindow_inlineComponent1_NumericStepper1_change(event:NumericStepperEvent) : void
        {
            data.amount = event.currentTarget.value;
            return;
        }// end function

        private function _CheatWindow_inlineComponent1_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Object
            {
                return null.GetResourceIcon(data.name_string);
            }// end function
            , function (param1:Object) : void
            {
                null.source = param1;
                return;
            }// end function
            , "_CheatWindow_inlineComponent1_Image1.source");
            result[0] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:String = null;
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.toolTip = param1;
                return;
            }// end function
            , "_CheatWindow_inlineComponent1_Image1.toolTip");
            result[1] = binding;
            binding = new Binding(this, function () : Number
            {
                return data.amount;
            }// end function
            , function (param1:Number) : void
            {
                _CheatWindow_inlineComponent1_NumericStepper1.value = param1;
                return;
            }// end function
            , "_CheatWindow_inlineComponent1_NumericStepper1.value");
            result[2] = binding;
            return result;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            CheatWindow_inlineComponent1._watcherSetupUtil = param1;
            return;
        }// end function

    }
}
