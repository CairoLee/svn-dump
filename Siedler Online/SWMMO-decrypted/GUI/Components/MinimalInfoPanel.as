package GUI.Components
{
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Loca.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class MinimalInfoPanel extends BasicPanel implements IBindingClient
    {
        private var _315005082btnKnockDown:StandardButton;
        var _bindingsByDestination:Object;
        var _bindingsBeginWithWord:Object;
        private var _1651126590payshopItemIndicator:Image;
        var _watchers:Array;
        private var _1724546052description:Text;
        public var _MinimalInfoPanel_Label1:Label;
        var _bindings:Array;
        private var _100313435image:Image;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function MinimalInfoPanel()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:BasicPanel, propertiesFactory:function () : Object
            {
                return {width:250, height:168};
            }// end function
            });
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.width = 250;
            this.height = 168;
            this.subComponents = [this._MinimalInfoPanel_Canvas1_c(), this._MinimalInfoPanel_Canvas2_c()];
            return;
        }// end function

        private function _MinimalInfoPanel_Text1_i() : Text
        {
            var _loc_1:* = new Text();
            this.description = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("left", "70");
            _loc_1.setStyle("right", "15");
            _loc_1.setStyle("top", "6");
            _loc_1.setStyle("bottom", "2");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "description";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
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

        public function set btnKnockDown(param1:StandardButton) : void
        {
            var _loc_2:* = this._315005082btnKnockDown;
            if (_loc_2 !== param1)
            {
                this._315005082btnKnockDown = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnKnockDown", _loc_2, param1));
            }
            return;
        }// end function

        private function _MinimalInfoPanel_Image1_i() : Image
        {
            var _loc_1:* = new Image();
            this.payshopItemIndicator = _loc_1;
            _loc_1.setStyle("top", "3");
            _loc_1.setStyle("left", "11");
            _loc_1.id = "payshopItemIndicator";
            BindingManager.executeBindings(this, "payshopItemIndicator", this.payshopItemIndicator);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _MinimalInfoPanel_Image2_i() : Image
        {
            var _loc_1:* = new Image();
            this.image = _loc_1;
            _loc_1.setStyle("left", "10");
            _loc_1.setStyle("verticalCenter", "1");
            _loc_1.id = "image";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get payshopItemIndicator() : Image
        {
            return this._1651126590payshopItemIndicator;
        }// end function

        private function _MinimalInfoPanel_Label1_i() : Label
        {
            var _loc_1:* = new Label();
            this._MinimalInfoPanel_Label1 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_MinimalInfoPanel_Label1";
            BindingManager.executeBindings(this, "_MinimalInfoPanel_Label1", this._MinimalInfoPanel_Label1);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        override public function initialize() : void
        {
            var target:MinimalInfoPanel;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._MinimalInfoPanel_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_MinimalInfoPanelWatcherSetupUtil");
                var _loc_2:* = watcherSetupUtilClass;
                _loc_2.watcherSetupUtilClass["init"](null);
            }
            _watcherSetupUtil.setup(this, function (param1:String)
            {
                return target[param1];
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

        public function get image() : Image
        {
            return this._100313435image;
        }// end function

        public function set payshopItemIndicator(param1:Image) : void
        {
            var _loc_2:* = this._1651126590payshopItemIndicator;
            if (_loc_2 !== param1)
            {
                this._1651126590payshopItemIndicator = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "payshopItemIndicator", _loc_2, param1));
            }
            return;
        }// end function

        private function _MinimalInfoPanel_StandardButton1_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnKnockDown = _loc_1;
            _loc_1.enabled = false;
            _loc_1.playSound = false;
            _loc_1.width = 68;
            _loc_1.height = 39;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "btnKnockDown";
            BindingManager.executeBindings(this, "btnKnockDown", this.btnKnockDown);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _MinimalInfoPanel_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Object
            {
                return null.GetBitmap(null);
            }// end function
            , function (param1:Object) : void
            {
                payshopItemIndicator.source = param1;
                return;
            }// end function
            , "payshopItemIndicator.source");
            result[0] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "KnockDown");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _MinimalInfoPanel_Label1.text = param1;
                return;
            }// end function
            , "_MinimalInfoPanel_Label1.text");
            result[1] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnKnockDown.icon");
            result[2] = binding;
            return result;
        }// end function

        public function get btnKnockDown() : StandardButton
        {
            return this._315005082btnKnockDown;
        }// end function

        private function _MinimalInfoPanel_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = gAssetManager.GetBitmap("PayshopIndicator");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "KnockDown");
            _loc_1 = gAssetManager.GetClass("ButtonIconBomb");
            return;
        }// end function

        private function _MinimalInfoPanel_Canvas1_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsHeader";
            _loc_1.height = 60;
            _loc_1.horizontalScrollPolicy = "off";
            _loc_1.verticalScrollPolicy = "off";
            _loc_1.clipContent = false;
            _loc_1.setStyle("left", "2");
            _loc_1.setStyle("right", "2");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MinimalInfoPanel_Image1_i());
            _loc_1.addChild(this._MinimalInfoPanel_Image2_i());
            _loc_1.addChild(this._MinimalInfoPanel_Text1_i());
            return _loc_1;
        }// end function

        private function _MinimalInfoPanel_Canvas3_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.percentWidth = 100;
            _loc_1.height = 18;
            _loc_1.setStyle("top", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MinimalInfoPanel_Label1_i());
            return _loc_1;
        }// end function

        private function _MinimalInfoPanel_Canvas4_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.setStyle("left", "1");
            _loc_1.setStyle("right", "1");
            _loc_1.setStyle("top", "18");
            _loc_1.setStyle("bottom", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MinimalInfoPanel_StandardButton1_i());
            return _loc_1;
        }// end function

        public function set description(param1:Text) : void
        {
            var _loc_2:* = this._1724546052description;
            if (_loc_2 !== param1)
            {
                this._1724546052description = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "description", _loc_2, param1));
            }
            return;
        }// end function

        private function _MinimalInfoPanel_Canvas2_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.width = 155;
            _loc_1.setStyle("left", "8");
            _loc_1.setStyle("right", "7");
            _loc_1.setStyle("top", "62");
            _loc_1.setStyle("bottom", "5");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MinimalInfoPanel_Canvas3_c());
            _loc_1.addChild(this._MinimalInfoPanel_Canvas4_c());
            return _loc_1;
        }// end function

        public function get description() : Text
        {
            return this._1724546052description;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
