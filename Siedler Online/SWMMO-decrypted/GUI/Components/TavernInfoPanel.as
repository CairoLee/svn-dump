package GUI.Components
{
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class TavernInfoPanel extends BasicPanel implements IBindingClient
    {
        private var _3322014list:VBox;
        var _watchers:Array;
        private var _252650492costsList:HBox;
        private var _188974544levelLabel:Label;
        private var _100313435image:Image;
        public var _TavernInfoPanel_Label2:Label;
        public var _TavernInfoPanel_Label4:Label;
        public var _TavernInfoPanel_Label5:Label;
        private var _315005082btnKnockDown:StandardButton;
        private var _1420684256btnUpgrade:StandardButton;
        var _bindingsByDestination:Object;
        var _bindingsBeginWithWord:Object;
        private var _551113993btnRepair:StandardButton;
        private var _1724546052description:Text;
        private var _492830541integrity:HealthBar;
        private var _1844579575upgradeTime:Label;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function TavernInfoPanel()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:BasicPanel, propertiesFactory:function () : Object
            {
                return {null:null, height:314};
            }// end function
            });
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.width = 435;
            this.height = 314;
            this.subComponents = [this._TavernInfoPanel_Canvas1_c(), this._TavernInfoPanel_Canvas2_c(), this._TavernInfoPanel_Canvas8_c(), this._TavernInfoPanel_Canvas9_c()];
            return;
        }// end function

        private function _TavernInfoPanel_Canvas5_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.percentWidth = 100;
            _loc_1.height = 60;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._TavernInfoPanel_Label2_i());
            _loc_1.addChild(this._TavernInfoPanel_Label3_i());
            _loc_1.addChild(this._TavernInfoPanel_Label4_i());
            _loc_1.addChild(this._TavernInfoPanel_HBox1_i());
            return _loc_1;
        }// end function

        private function _TavernInfoPanel_Canvas7_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.height = 66;
            _loc_1.setStyle("left", "1");
            _loc_1.setStyle("right", "1");
            _loc_1.setStyle("top", "150");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._TavernInfoPanel_StandardButton2_i());
            _loc_1.addChild(this._TavernInfoPanel_StandardButton3_i());
            _loc_1.addChild(this._TavernInfoPanel_HealthBar1_i());
            return _loc_1;
        }// end function

        public function get costsList() : HBox
        {
            return this._252650492costsList;
        }// end function

        private function _TavernInfoPanel_Canvas9_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.horizontalScrollPolicy = "off";
            _loc_1.verticalScrollPolicy = "auto";
            _loc_1.setStyle("left", "168");
            _loc_1.setStyle("right", "6");
            _loc_1.setStyle("top", "65");
            _loc_1.setStyle("bottom", "8");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._TavernInfoPanel_VBox1_i());
            return _loc_1;
        }// end function

        public function set btnUpgrade(param1:StandardButton) : void
        {
            var _loc_2:* = this._1420684256btnUpgrade;
            if (_loc_2 !== param1)
            {
                this._1420684256btnUpgrade = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnUpgrade", _loc_2, param1));
            }
            return;
        }// end function

        public function set costsList(param1:HBox) : void
        {
            var _loc_2:* = this._252650492costsList;
            if (_loc_2 !== param1)
            {
                this._252650492costsList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "costsList", _loc_2, param1));
            }
            return;
        }// end function

        public function get description() : Text
        {
            return this._1724546052description;
        }// end function

        override public function initialize() : void
        {
            var target:TavernInfoPanel;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._TavernInfoPanel_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_TavernInfoPanelWatcherSetupUtil");
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

        private function _TavernInfoPanel_Text1_i() : Text
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

        public function set btnRepair(param1:StandardButton) : void
        {
            var _loc_2:* = this._551113993btnRepair;
            if (_loc_2 !== param1)
            {
                this._551113993btnRepair = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnRepair", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnKnockDown() : StandardButton
        {
            return this._315005082btnKnockDown;
        }// end function

        public function get list() : VBox
        {
            return this._3322014list;
        }// end function

        private function _TavernInfoPanel_Image1_i() : Image
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

        public function get btnUpgrade() : StandardButton
        {
            return this._1420684256btnUpgrade;
        }// end function

        public function set integrity(param1:HealthBar) : void
        {
            var _loc_2:* = this._492830541integrity;
            if (_loc_2 !== param1)
            {
                this._492830541integrity = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "integrity", _loc_2, param1));
            }
            return;
        }// end function

        private function _TavernInfoPanel_Label4_i() : Label
        {
            var _loc_1:* = new Label();
            this._TavernInfoPanel_Label4 = _loc_1;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("top", "15");
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "_TavernInfoPanel_Label4";
            BindingManager.executeBindings(this, "_TavernInfoPanel_Label4", this._TavernInfoPanel_Label4);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get btnRepair() : StandardButton
        {
            return this._551113993btnRepair;
        }// end function

        private function _TavernInfoPanel_StandardButton1_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnUpgrade = _loc_1;
            _loc_1.enabled = false;
            _loc_1.playSound = false;
            _loc_1.width = 68;
            _loc_1.height = 39;
            _loc_1.setStyle("bottom", "2");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.addEventListener("toolTipCreate", this.__btnUpgrade_toolTipCreate);
            _loc_1.id = "btnUpgrade";
            BindingManager.executeBindings(this, "btnUpgrade", this.btnUpgrade);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _TavernInfoPanel_Label2_i() : Label
        {
            var _loc_1:* = new Label();
            this._TavernInfoPanel_Label2 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "_TavernInfoPanel_Label2";
            BindingManager.executeBindings(this, "_TavernInfoPanel_Label2", this._TavernInfoPanel_Label2);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
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

        private function _TavernInfoPanel_StandardButton3_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnRepair = _loc_1;
            _loc_1.enabled = false;
            _loc_1.width = 68;
            _loc_1.height = 39;
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "5");
            _loc_1.id = "btnRepair";
            BindingManager.executeBindings(this, "btnRepair", this.btnRepair);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _TavernInfoPanel_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Upgrade");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _TavernInfoPanel_Label2.text = param1;
                return;
            }// end function
            , "_TavernInfoPanel_Label2.text");
            result[0] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return !upgradeTime.visible;
            }// end function
            , function (param1:Boolean) : void
            {
                _TavernInfoPanel_Label4.visible = param1;
                return;
            }// end function
            , "_TavernInfoPanel_Label4.visible");
            result[1] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "NotPossible");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "_TavernInfoPanel_Label4.text");
            result[2] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ButtonIconUpgrade");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("icon", param1);
                return;
            }// end function
            , "btnUpgrade.icon");
            result[3] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "BuildingIntegrity");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _TavernInfoPanel_Label5.text = param1;
                return;
            }// end function
            , "_TavernInfoPanel_Label5.text");
            result[4] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ButtonIconBomb");
            }// end function
            , function (param1:Class) : void
            {
                btnKnockDown.setStyle("icon", param1);
                return;
            }// end function
            , "btnKnockDown.icon");
            result[5] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ButtonIconTools");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("icon", param1);
                return;
            }// end function
            , "btnRepair.icon");
            result[6] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Repair");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                btnRepair.toolTip = param1;
                return;
            }// end function
            , "btnRepair.toolTip");
            result[7] = binding;
            return result;
        }// end function

        private function _TavernInfoPanel_HBox1_i() : HBox
        {
            var _loc_1:* = new HBox();
            this.costsList = _loc_1;
            _loc_1.setStyle("top", "32");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.id = "costsList";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set list(param1:VBox) : void
        {
            var _loc_2:* = this._3322014list;
            if (_loc_2 !== param1)
            {
                this._3322014list = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "list", _loc_2, param1));
            }
            return;
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

        public function set upgradeTime(param1:Label) : void
        {
            var _loc_2:* = this._1844579575upgradeTime;
            if (_loc_2 !== param1)
            {
                this._1844579575upgradeTime = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "upgradeTime", _loc_2, param1));
            }
            return;
        }// end function

        private function _TavernInfoPanel_Canvas2_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.width = 155;
            _loc_1.setStyle("top", "62");
            _loc_1.setStyle("left", "8");
            _loc_1.setStyle("bottom", "5");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._TavernInfoPanel_Canvas3_c());
            _loc_1.addChild(this._TavernInfoPanel_Canvas4_c());
            _loc_1.addChild(this._TavernInfoPanel_Canvas6_c());
            _loc_1.addChild(this._TavernInfoPanel_Canvas7_c());
            return _loc_1;
        }// end function

        private function _TavernInfoPanel_VBox1_i() : VBox
        {
            var _loc_1:* = new VBox();
            this.list = _loc_1;
            _loc_1.setStyle("verticalGap", 0);
            _loc_1.setStyle("left", "0");
            _loc_1.setStyle("top", "0");
            _loc_1.setStyle("bottom", "0");
            _loc_1.id = "list";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _TavernInfoPanel_Canvas6_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.percentWidth = 100;
            _loc_1.height = 18;
            _loc_1.setStyle("top", "132");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._TavernInfoPanel_Label5_i());
            return _loc_1;
        }// end function

        private function _TavernInfoPanel_Canvas8_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "listBackgroundShadow";
            _loc_1.setStyle("left", "165");
            _loc_1.setStyle("right", "23");
            _loc_1.setStyle("top", "63");
            _loc_1.setStyle("bottom", "5");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _TavernInfoPanel_Canvas4_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.height = 112;
            _loc_1.setStyle("left", "1");
            _loc_1.setStyle("right", "1");
            _loc_1.setStyle("top", "18");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._TavernInfoPanel_Canvas5_c());
            _loc_1.addChild(this._TavernInfoPanel_StandardButton1_i());
            return _loc_1;
        }// end function

        public function get integrity() : HealthBar
        {
            return this._492830541integrity;
        }// end function

        public function __btnUpgrade_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.UPGRADE_BUILDING_string, event);
            return;
        }// end function

        public function set levelLabel(param1:Label) : void
        {
            var _loc_2:* = this._188974544levelLabel;
            if (_loc_2 !== param1)
            {
                this._188974544levelLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "levelLabel", _loc_2, param1));
            }
            return;
        }// end function

        public function get image() : Image
        {
            return this._100313435image;
        }// end function

        public function get upgradeTime() : Label
        {
            return this._1844579575upgradeTime;
        }// end function

        private function _TavernInfoPanel_HealthBar1_i() : HealthBar
        {
            var _loc_1:* = new HealthBar();
            this.integrity = _loc_1;
            _loc_1.setStyle("left", "2");
            _loc_1.setStyle("right", "0");
            _loc_1.setStyle("top", "50");
            _loc_1.id = "integrity";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _TavernInfoPanel_Label1_i() : Label
        {
            var _loc_1:* = new Label();
            this.levelLabel = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "levelLabel";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get levelLabel() : Label
        {
            return this._188974544levelLabel;
        }// end function

        private function _TavernInfoPanel_Label3_i() : Label
        {
            var _loc_1:* = new Label();
            this.upgradeTime = _loc_1;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("top", "15");
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "upgradeTime";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _TavernInfoPanel_Label5_i() : Label
        {
            var _loc_1:* = new Label();
            this._TavernInfoPanel_Label5 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_TavernInfoPanel_Label5";
            BindingManager.executeBindings(this, "_TavernInfoPanel_Label5", this._TavernInfoPanel_Label5);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _TavernInfoPanel_StandardButton2_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnKnockDown = _loc_1;
            _loc_1.enabled = false;
            _loc_1.playSound = false;
            _loc_1.width = 68;
            _loc_1.height = 39;
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("top", "5");
            _loc_1.id = "btnKnockDown";
            BindingManager.executeBindings(this, "btnKnockDown", this.btnKnockDown);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
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

        private function _TavernInfoPanel_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Upgrade");
            _loc_1 = !this.upgradeTime.visible;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "NotPossible");
            _loc_1 = gAssetManager.GetClass("ButtonIconUpgrade");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "BuildingIntegrity");
            _loc_1 = gAssetManager.GetClass("ButtonIconBomb");
            _loc_1 = gAssetManager.GetClass("ButtonIconTools");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Repair");
            return;
        }// end function

        private function _TavernInfoPanel_Canvas1_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsHeader";
            _loc_1.height = 60;
            _loc_1.setStyle("left", "2");
            _loc_1.setStyle("right", "2");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._TavernInfoPanel_Image1_i());
            _loc_1.addChild(this._TavernInfoPanel_Text1_i());
            return _loc_1;
        }// end function

        private function _TavernInfoPanel_Canvas3_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.percentWidth = 100;
            _loc_1.height = 18;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._TavernInfoPanel_Label1_i());
            return _loc_1;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
