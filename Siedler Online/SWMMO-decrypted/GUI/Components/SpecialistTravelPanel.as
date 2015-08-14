package GUI.Components
{
    import Enums.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Loca.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class SpecialistTravelPanel extends BasicPanel implements IBindingClient
    {
        public var _SpecialistTravelPanel_Label1:Label;
        var _bindingsByDestination:Object;
        private var _1450754795availabelSpecialists:CustomTileList;
        var _bindingsBeginWithWord:Object;
        private var _702386745taskDuration:Label;
        private var _117924854btnCancel:StandardButton;
        private var _128157573confirmFooter:Canvas;
        var _watchers:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        var _bindings:Array;
        private var _94069048btnOK:StandardButton;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function SpecialistTravelPanel()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:BasicPanel, propertiesFactory:function () : Object
            {
                return {null:510, height:418};
            }// end function
            });
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.width = 510;
            this.height = 418;
            this.subComponents = [this._SpecialistTravelPanel_Canvas1_c(), this._SpecialistTravelPanel_Canvas2_c(), this._SpecialistTravelPanel_CustomTileList1_i(), this._SpecialistTravelPanel_Canvas3_i()];
            return;
        }// end function

        public function set taskDuration(param1:Label) : void
        {
            var _loc_2:* = this._702386745taskDuration;
            if (_loc_2 !== param1)
            {
                this._702386745taskDuration = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "taskDuration", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistTravelPanel_StandardButton1_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnOK = _loc_1;
            _loc_1.enabled = false;
            _loc_1.playSound = false;
            _loc_1.width = 70;
            _loc_1.height = 32;
            _loc_1.id = "btnOK";
            BindingManager.executeBindings(this, "btnOK", this.btnOK);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistTravelPanel_StandardButton2_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnCancel = _loc_1;
            _loc_1.width = 70;
            _loc_1.height = 32;
            _loc_1.id = "btnCancel";
            BindingManager.executeBindings(this, "btnCancel", this.btnCancel);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistTravelPanel_HBox1_c() : HBox
        {
            var _loc_1:* = new HBox();
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("bottom", "5");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistTravelPanel_StandardButton1_i());
            _loc_1.addChild(this._SpecialistTravelPanel_StandardButton2_i());
            return _loc_1;
        }// end function

        public function get btnCancel() : StandardButton
        {
            return this._117924854btnCancel;
        }// end function

        override public function initialize() : void
        {
            var target:SpecialistTravelPanel;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._SpecialistTravelPanel_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_SpecialistTravelPanelWatcherSetupUtil");
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

        public function get confirmFooter() : Canvas
        {
            return this._128157573confirmFooter;
        }// end function

        private function _SpecialistTravelPanel_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Duration");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "OK");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Cancel");
            return;
        }// end function

        private function _SpecialistTravelPanel_Canvas1_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsHeader";
            _loc_1.height = 55;
            _loc_1.setStyle("left", "2");
            _loc_1.setStyle("right", "2");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistTravelPanel_CustomTileList1_i() : CustomTileList
        {
            var _loc_1:* = new CustomTileList();
            this.availabelSpecialists = _loc_1;
            _loc_1.columnWidth = 230;
            _loc_1.itemRenderer = this._SpecialistTravelPanel_ClassFactory1_c();
            _loc_1.setStyle("left", "11");
            _loc_1.setStyle("right", "9");
            _loc_1.setStyle("top", "60");
            _loc_1.setStyle("bottom", "116");
            _loc_1.setStyle("paddingTop", 0);
            _loc_1.setStyle("paddingBottom", 0);
            _loc_1.setStyle("paddingLeft", 0);
            _loc_1.setStyle("paddingRight", 0);
            _loc_1.setStyle("useRollOver", false);
            _loc_1.setStyle("borderThickness", 0);
            _loc_1.setStyle("backgroundAlpha", 0);
            _loc_1.id = "availabelSpecialists";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistTravelPanel_Canvas4_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.height = 18;
            _loc_1.percentWidth = 100;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistTravelPanel_Label1_i());
            return _loc_1;
        }// end function

        private function _SpecialistTravelPanel_Canvas5_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.height = 80;
            _loc_1.setStyle("left", "1");
            _loc_1.setStyle("right", "1");
            _loc_1.setStyle("top", "18");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistTravelPanel_Canvas6_c());
            _loc_1.addChild(this._SpecialistTravelPanel_HBox1_c());
            return _loc_1;
        }// end function

        private function _SpecialistTravelPanel_Canvas6_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.percentWidth = 100;
            _loc_1.height = 37;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistTravelPanel_Label2_i());
            return _loc_1;
        }// end function

        private function _SpecialistTravelPanel_Canvas3_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.confirmFooter = _loc_1;
            _loc_1.setStyle("left", "7");
            _loc_1.setStyle("right", "8");
            _loc_1.setStyle("bottom", "13");
            _loc_1.id = "confirmFooter";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistTravelPanel_Canvas4_c());
            _loc_1.addChild(this._SpecialistTravelPanel_Canvas5_c());
            return _loc_1;
        }// end function

        public function set confirmFooter(param1:Canvas) : void
        {
            var _loc_2:* = this._128157573confirmFooter;
            if (_loc_2 !== param1)
            {
                this._128157573confirmFooter = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "confirmFooter", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistTravelPanel_Canvas2_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "listBackgroundShadow";
            _loc_1.setStyle("left", "8");
            _loc_1.setStyle("right", "26");
            _loc_1.setStyle("top", "58");
            _loc_1.setStyle("bottom", "113");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get availabelSpecialists() : CustomTileList
        {
            return this._1450754795availabelSpecialists;
        }// end function

        private function _SpecialistTravelPanel_Label1_i() : Label
        {
            var _loc_1:* = new Label();
            this._SpecialistTravelPanel_Label1 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_SpecialistTravelPanel_Label1";
            BindingManager.executeBindings(this, "_SpecialistTravelPanel_Label1", this._SpecialistTravelPanel_Label1);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistTravelPanel_Label2_i() : Label
        {
            var _loc_1:* = new Label();
            this.taskDuration = _loc_1;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.id = "taskDuration";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set btnOK(param1:StandardButton) : void
        {
            var _loc_2:* = this._94069048btnOK;
            if (_loc_2 !== param1)
            {
                this._94069048btnOK = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnOK", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnCancel(param1:StandardButton) : void
        {
            var _loc_2:* = this._117924854btnCancel;
            if (_loc_2 !== param1)
            {
                this._117924854btnCancel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnCancel", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistTravelPanel_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Duration");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _SpecialistTravelPanel_Label1.text = param1;
                return;
            }// end function
            , "_SpecialistTravelPanel_Label1.text");
            result[0] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "OK");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                btnOK.label = param1;
                return;
            }// end function
            , "btnOK.label");
            result[1] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "Cancel");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnCancel.label");
            result[2] = binding;
            return result;
        }// end function

        public function set availabelSpecialists(param1:CustomTileList) : void
        {
            var _loc_2:* = this._1450754795availabelSpecialists;
            if (_loc_2 !== param1)
            {
                this._1450754795availabelSpecialists = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "availabelSpecialists", _loc_2, param1));
            }
            return;
        }// end function

        public function get taskDuration() : Label
        {
            return this._702386745taskDuration;
        }// end function

        private function _SpecialistTravelPanel_ClassFactory1_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = SpecialistTravelItemRenderer;
            return _loc_1;
        }// end function

        public function get btnOK() : StandardButton
        {
            return this._94069048btnOK;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
