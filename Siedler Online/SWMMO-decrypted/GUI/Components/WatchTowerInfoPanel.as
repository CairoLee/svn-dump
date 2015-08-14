package GUI.Components
{
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import flash.display.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import mx.states.*;

    public class WatchTowerInfoPanel extends BasicPanel implements IBindingClient
    {
        private var _1655307837leftColumn:Canvas;
        public var _WatchTowerInfoPanel_StandardButton2:StandardButton;
        private var _1564391859btnCommitArmyChanges:StandardButton;
        private var _188974544levelLabel:Label;
        private var _1138906016manageArmyList:TileList;
        private var _798965730btnManageArmy:StandardButton;
        private var _455005011unitsList:CustomTileList;
        private var _1724546052description:Text;
        var _bindingsByDestination:Object;
        private var _2100227641subcontent:Canvas;
        public var _WatchTowerInfoPanel_AddChild2:AddChild;
        public var _WatchTowerInfoPanel_AddChild1:AddChild;
        private var _1541638163stateManageArmy:State;
        private var _867684882manageUnitsAmountLabel:Label;
        private var _252650492costsList:HBox;
        public var _WatchTowerInfoPanel_RemoveChild1:RemoveChild;
        public var _WatchTowerInfoPanel_RemoveChild2:RemoveChild;
        var _watchers:Array;
        public var _WatchTowerInfoPanel_Label3:Label;
        public var _WatchTowerInfoPanel_Label5:Label;
        public var _WatchTowerInfoPanel_Label6:Label;
        public var _WatchTowerInfoPanel_Label7:Label;
        private var _100313435image:Image;
        private var _1420684256btnUpgrade:StandardButton;
        private var _315005082btnKnockDown:StandardButton;
        var _bindingsBeginWithWord:Object;
        private var _873431918rightColumn:Canvas;
        private var _551113993btnRepair:StandardButton;
        private var _492830541integrity:HealthBar;
        private var _1844579575upgradeTime:Label;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function WatchTowerInfoPanel()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:BasicPanel, propertiesFactory:function () : Object
            {
                return {null:null, height:305};
            }// end function
            });
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.width = 408;
            this.height = 305;
            this.states = [this._WatchTowerInfoPanel_State1_i()];
            this.subComponents = [this._WatchTowerInfoPanel_Canvas4_i()];
            return;
        }// end function

        private function _WatchTowerInfoPanel_Image1_i() : Image
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

        public function get costsList() : HBox
        {
            return this._252650492costsList;
        }// end function

        private function _WatchTowerInfoPanel_Canvas12_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.rightColumn = _loc_1;
            _loc_1.setStyle("left", "166");
            _loc_1.setStyle("right", "6");
            _loc_1.setStyle("top", "62");
            _loc_1.setStyle("bottom", "5");
            _loc_1.id = "rightColumn";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._WatchTowerInfoPanel_Canvas13_c());
            _loc_1.addChild(this._WatchTowerInfoPanel_Canvas14_c());
            _loc_1.addChild(this._WatchTowerInfoPanel_CustomTileList1_i());
            return _loc_1;
        }// end function

        private function _WatchTowerInfoPanel_SetProperty1_c() : SetProperty
        {
            var _loc_1:* = new SetProperty();
            _loc_1.name = "height";
            _loc_1.value = 309;
            return _loc_1;
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

        public function get btnRepair() : StandardButton
        {
            return this._551113993btnRepair;
        }// end function

        private function _WatchTowerInfoPanel_StandardButton1_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnCommitArmyChanges = _loc_1;
            _loc_1.width = 70;
            _loc_1.height = 32;
            _loc_1.addEventListener("click", this.__btnCommitArmyChanges_click);
            _loc_1.id = "btnCommitArmyChanges";
            BindingManager.executeBindings(this, "btnCommitArmyChanges", this.btnCommitArmyChanges);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _WatchTowerInfoPanel_State1_i() : State
        {
            var _loc_1:* = new State();
            this.stateManageArmy = _loc_1;
            _loc_1.name = "ManageArmy";
            _loc_1.overrides = [this._WatchTowerInfoPanel_SetProperty1_c(), this._WatchTowerInfoPanel_RemoveChild1_i(), this._WatchTowerInfoPanel_RemoveChild2_i(), this._WatchTowerInfoPanel_AddChild1_i(), this._WatchTowerInfoPanel_AddChild2_i()];
            return _loc_1;
        }// end function

        private function _WatchTowerInfoPanel_StandardButton5_i() : StandardButton
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

        private function _WatchTowerInfoPanel_HBox1_c() : HBox
        {
            var _loc_1:* = new HBox();
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("bottom", "5");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._WatchTowerInfoPanel_StandardButton1_i());
            _loc_1.addChild(this._WatchTowerInfoPanel_StandardButton2_i());
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

        private function _WatchTowerInfoPanel_Label4_i() : Label
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

        public function get manageUnitsAmountLabel() : Label
        {
            return this._867684882manageUnitsAmountLabel;
        }// end function

        public function get stateManageArmy() : State
        {
            return this._1541638163stateManageArmy;
        }// end function

        private function _WatchTowerInfoPanel_Canvas2_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.percentWidth = 100;
            _loc_1.height = 18;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._WatchTowerInfoPanel_Label1_i());
            return _loc_1;
        }// end function

        public function get btnManageArmy() : StandardButton
        {
            return this._798965730btnManageArmy;
        }// end function

        private function _WatchTowerInfoPanel_AddChild2_i() : AddChild
        {
            var _loc_1:* = new AddChild();
            this._WatchTowerInfoPanel_AddChild2 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._WatchTowerInfoPanel_HBox1_c);
            BindingManager.executeBindings(this, "_WatchTowerInfoPanel_AddChild2", this._WatchTowerInfoPanel_AddChild2);
            return _loc_1;
        }// end function

        public function get btnUpgrade() : StandardButton
        {
            return this._1420684256btnUpgrade;
        }// end function

        public function set manageUnitsAmountLabel(param1:Label) : void
        {
            var _loc_2:* = this._867684882manageUnitsAmountLabel;
            if (_loc_2 !== param1)
            {
                this._867684882manageUnitsAmountLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "manageUnitsAmountLabel", _loc_2, param1));
            }
            return;
        }// end function

        private function _WatchTowerInfoPanel_Canvas6_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.leftColumn = _loc_1;
            _loc_1.width = 155;
            _loc_1.setStyle("top", "62");
            _loc_1.setStyle("left", "7");
            _loc_1.setStyle("bottom", "5");
            _loc_1.id = "leftColumn";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._WatchTowerInfoPanel_Canvas7_c());
            _loc_1.addChild(this._WatchTowerInfoPanel_Canvas8_c());
            _loc_1.addChild(this._WatchTowerInfoPanel_Canvas10_c());
            _loc_1.addChild(this._WatchTowerInfoPanel_Canvas11_c());
            return _loc_1;
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

        public function set rightColumn(param1:Canvas) : void
        {
            var _loc_2:* = this._873431918rightColumn;
            if (_loc_2 !== param1)
            {
                this._873431918rightColumn = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "rightColumn", _loc_2, param1));
            }
            return;
        }// end function

        public function set stateManageArmy(param1:State) : void
        {
            var _loc_2:* = this._1541638163stateManageArmy;
            if (_loc_2 !== param1)
            {
                this._1541638163stateManageArmy = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "stateManageArmy", _loc_2, param1));
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

        public function get subcontent() : Canvas
        {
            return this._2100227641subcontent;
        }// end function

        public function set btnManageArmy(param1:StandardButton) : void
        {
            var _loc_2:* = this._798965730btnManageArmy;
            if (_loc_2 !== param1)
            {
                this._798965730btnManageArmy = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnManageArmy", _loc_2, param1));
            }
            return;
        }// end function

        public function get leftColumn() : Canvas
        {
            return this._1655307837leftColumn;
        }// end function

        private function _WatchTowerInfoPanel_Canvas11_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.height = 66;
            _loc_1.setStyle("left", "1");
            _loc_1.setStyle("right", "1");
            _loc_1.setStyle("top", "141");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._WatchTowerInfoPanel_StandardButton4_i());
            _loc_1.addChild(this._WatchTowerInfoPanel_StandardButton5_i());
            _loc_1.addChild(this._WatchTowerInfoPanel_HealthBar1_i());
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

        private function _WatchTowerInfoPanel_Canvas15_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.percentWidth = 100;
            _loc_1.height = 36;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._WatchTowerInfoPanel_StandardButton6_i());
            return _loc_1;
        }// end function

        public function __btnManageArmy_click(event:MouseEvent) : void
        {
            this.currentState = "ManageArmy";
            return;
        }// end function

        private function _WatchTowerInfoPanel_TileList1_i() : TileList
        {
            var _loc_1:* = new TileList();
            this.manageArmyList = _loc_1;
            _loc_1.itemRenderer = this._WatchTowerInfoPanel_ClassFactory1_c();
            _loc_1.selectable = false;
            _loc_1.setStyle("backgroundAlpha", 0);
            _loc_1.setStyle("borderThickness", 0);
            _loc_1.setStyle("left", "3");
            _loc_1.setStyle("right", "3");
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("bottom", "0");
            _loc_1.setStyle("useRollOver", false);
            _loc_1.id = "manageArmyList";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _WatchTowerInfoPanel_Label7_i() : Label
        {
            var _loc_1:* = new Label();
            this._WatchTowerInfoPanel_Label7 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_WatchTowerInfoPanel_Label7";
            BindingManager.executeBindings(this, "_WatchTowerInfoPanel_Label7", this._WatchTowerInfoPanel_Label7);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _WatchTowerInfoPanel_Label3_i() : Label
        {
            var _loc_1:* = new Label();
            this._WatchTowerInfoPanel_Label3 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "_WatchTowerInfoPanel_Label3";
            BindingManager.executeBindings(this, "_WatchTowerInfoPanel_Label3", this._WatchTowerInfoPanel_Label3);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _WatchTowerInfoPanel_StandardButton4_i() : StandardButton
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

        private function _WatchTowerInfoPanel_Canvas1_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.setStyle("left", "7");
            _loc_1.setStyle("right", "6");
            _loc_1.setStyle("top", "62");
            _loc_1.setStyle("bottom", "42");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._WatchTowerInfoPanel_Canvas2_c());
            _loc_1.addChild(this._WatchTowerInfoPanel_Canvas3_c());
            return _loc_1;
        }// end function

        public function get integrity() : HealthBar
        {
            return this._492830541integrity;
        }// end function

        private function _WatchTowerInfoPanel_AddChild1_i() : AddChild
        {
            var _loc_1:* = new AddChild();
            this._WatchTowerInfoPanel_AddChild1 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._WatchTowerInfoPanel_Canvas1_c);
            BindingManager.executeBindings(this, "_WatchTowerInfoPanel_AddChild1", this._WatchTowerInfoPanel_AddChild1);
            return _loc_1;
        }// end function

        public function get manageArmyList() : TileList
        {
            return this._1138906016manageArmyList;
        }// end function

        public function set unitsList(param1:CustomTileList) : void
        {
            var _loc_2:* = this._455005011unitsList;
            if (_loc_2 !== param1)
            {
                this._455005011unitsList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "unitsList", _loc_2, param1));
            }
            return;
        }// end function

        private function _WatchTowerInfoPanel_Canvas9_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.percentWidth = 100;
            _loc_1.height = 60;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._WatchTowerInfoPanel_Label3_i());
            _loc_1.addChild(this._WatchTowerInfoPanel_Label4_i());
            _loc_1.addChild(this._WatchTowerInfoPanel_Label5_i());
            _loc_1.addChild(this._WatchTowerInfoPanel_HBox2_i());
            return _loc_1;
        }// end function

        private function _WatchTowerInfoPanel_ClassFactory2_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = WarehouseDetailsItemRenderer;
            return _loc_1;
        }// end function

        private function _WatchTowerInfoPanel_Canvas5_c() : Canvas
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
            _loc_1.addChild(this._WatchTowerInfoPanel_Image1_i());
            _loc_1.addChild(this._WatchTowerInfoPanel_Text1_i());
            return _loc_1;
        }// end function

        public function get image() : Image
        {
            return this._100313435image;
        }// end function

        public function get upgradeTime() : Label
        {
            return this._1844579575upgradeTime;
        }// end function

        public function set btnCommitArmyChanges(param1:StandardButton) : void
        {
            var _loc_2:* = this._1564391859btnCommitArmyChanges;
            if (_loc_2 !== param1)
            {
                this._1564391859btnCommitArmyChanges = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnCommitArmyChanges", _loc_2, param1));
            }
            return;
        }// end function

        public function set subcontent(param1:Canvas) : void
        {
            var _loc_2:* = this._2100227641subcontent;
            if (_loc_2 !== param1)
            {
                this._2100227641subcontent = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "subcontent", _loc_2, param1));
            }
            return;
        }// end function

        public function set leftColumn(param1:Canvas) : void
        {
            var _loc_2:* = this._1655307837leftColumn;
            if (_loc_2 !== param1)
            {
                this._1655307837leftColumn = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "leftColumn", _loc_2, param1));
            }
            return;
        }// end function

        private function _WatchTowerInfoPanel_Canvas10_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.percentWidth = 100;
            _loc_1.height = 18;
            _loc_1.setStyle("top", "123");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._WatchTowerInfoPanel_Label6_i());
            return _loc_1;
        }// end function

        public function __btnManageArmy_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        private function _WatchTowerInfoPanel_ClassFactory1_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = ManageArmyItemRenderer;
            return _loc_1;
        }// end function

        private function _WatchTowerInfoPanel_RemoveChild2_i() : RemoveChild
        {
            var _loc_1:* = new RemoveChild();
            this._WatchTowerInfoPanel_RemoveChild2 = _loc_1;
            BindingManager.executeBindings(this, "_WatchTowerInfoPanel_RemoveChild2", this._WatchTowerInfoPanel_RemoveChild2);
            return _loc_1;
        }// end function

        private function _WatchTowerInfoPanel_Canvas14_c() : Canvas
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
            _loc_1.addChild(this._WatchTowerInfoPanel_Canvas15_c());
            return _loc_1;
        }// end function

        private function _WatchTowerInfoPanel_Label2_i() : Label
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

        private function _WatchTowerInfoPanel_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : DisplayObject
            {
                return leftColumn;
            }// end function
            , function (param1:DisplayObject) : void
            {
                null.target = param1;
                return;
            }// end function
            , "_WatchTowerInfoPanel_RemoveChild1.target");
            result[0] = binding;
            binding = new Binding(this, function () : DisplayObject
            {
                return rightColumn;
            }// end function
            , function (param1:DisplayObject) : void
            {
                null.target = param1;
                return;
            }// end function
            , "_WatchTowerInfoPanel_RemoveChild2.target");
            result[1] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return subcontent;
            }// end function
            , function (param1:UIComponent) : void
            {
                _WatchTowerInfoPanel_AddChild1.relativeTo = param1;
                return;
            }// end function
            , "_WatchTowerInfoPanel_AddChild1.relativeTo");
            result[2] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return subcontent;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = param1;
                return;
            }// end function
            , "_WatchTowerInfoPanel_AddChild2.relativeTo");
            result[3] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "OK");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                btnCommitArmyChanges.label = param1;
                return;
            }// end function
            , "btnCommitArmyChanges.label");
            result[4] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Cancel");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "_WatchTowerInfoPanel_StandardButton2.label");
            result[5] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Upgrade");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _WatchTowerInfoPanel_Label3.text = param1;
                return;
            }// end function
            , "_WatchTowerInfoPanel_Label3.text");
            result[6] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return !null;
            }// end function
            , function (param1:Boolean) : void
            {
                null.visible = param1;
                return;
            }// end function
            , "_WatchTowerInfoPanel_Label5.visible");
            result[7] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "NotPossible");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "_WatchTowerInfoPanel_Label5.text");
            result[8] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ButtonIconUpgrade");
            }// end function
            , function (param1:Class) : void
            {
                btnUpgrade.setStyle("icon", param1);
                return;
            }// end function
            , "btnUpgrade.icon");
            result[9] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "BuildingIntegrity");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _WatchTowerInfoPanel_Label6.text = param1;
                return;
            }// end function
            , "_WatchTowerInfoPanel_Label6.text");
            result[10] = binding;
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
            result[11] = binding;
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
            result[12] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Repair");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.toolTip = param1;
                return;
            }// end function
            , "btnRepair.toolTip");
            result[13] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "Army");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "_WatchTowerInfoPanel_Label7.text");
            result[14] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "ManageArmy");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnManageArmy.label");
            result[15] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "ManageArmy");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.toolTip = null;
                return;
            }// end function
            , "btnManageArmy.toolTip");
            result[16] = binding;
            return result;
        }// end function

        override public function initialize() : void
        {
            var target:WatchTowerInfoPanel;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._WatchTowerInfoPanel_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_WatchTowerInfoPanelWatcherSetupUtil");
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

        public function get rightColumn() : Canvas
        {
            return this._873431918rightColumn;
        }// end function

        private function _WatchTowerInfoPanel_StandardButton3_i() : StandardButton
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

        private function _WatchTowerInfoPanel_Label6_i() : Label
        {
            var _loc_1:* = new Label();
            this._WatchTowerInfoPanel_Label6 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_WatchTowerInfoPanel_Label6";
            BindingManager.executeBindings(this, "_WatchTowerInfoPanel_Label6", this._WatchTowerInfoPanel_Label6);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get btnKnockDown() : StandardButton
        {
            return this._315005082btnKnockDown;
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

        private function _WatchTowerInfoPanel_Canvas8_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.height = 103;
            _loc_1.setStyle("left", "1");
            _loc_1.setStyle("right", "1");
            _loc_1.setStyle("top", "18");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._WatchTowerInfoPanel_Canvas9_c());
            _loc_1.addChild(this._WatchTowerInfoPanel_StandardButton3_i());
            return _loc_1;
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

        private function _WatchTowerInfoPanel_Canvas4_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.subcontent = _loc_1;
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            _loc_1.id = "subcontent";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._WatchTowerInfoPanel_Canvas5_c());
            _loc_1.addChild(this._WatchTowerInfoPanel_Canvas6_i());
            _loc_1.addChild(this._WatchTowerInfoPanel_Canvas12_i());
            return _loc_1;
        }// end function

        public function get unitsList() : CustomTileList
        {
            return this._455005011unitsList;
        }// end function

        public function get btnCommitArmyChanges() : StandardButton
        {
            return this._1564391859btnCommitArmyChanges;
        }// end function

        private function _WatchTowerInfoPanel_CustomTileList1_i() : CustomTileList
        {
            var _loc_1:* = new CustomTileList();
            this.unitsList = _loc_1;
            _loc_1.itemRenderer = this._WatchTowerInfoPanel_ClassFactory2_c();
            _loc_1.setStyle("useRollOver", false);
            _loc_1.setStyle("borderThickness", 0);
            _loc_1.setStyle("backgroundAlpha", 0);
            _loc_1.setStyle("left", "8");
            _loc_1.setStyle("right", "8");
            _loc_1.setStyle("top", "60");
            _loc_1.setStyle("bottom", "3");
            _loc_1.id = "unitsList";
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

        public function __btnUpgrade_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.UPGRADE_BUILDING_string, event);
            return;
        }// end function

        private function _WatchTowerInfoPanel_RemoveChild1_i() : RemoveChild
        {
            var _loc_1:* = new RemoveChild();
            this._WatchTowerInfoPanel_RemoveChild1 = _loc_1;
            BindingManager.executeBindings(this, "_WatchTowerInfoPanel_RemoveChild1", this._WatchTowerInfoPanel_RemoveChild1);
            return _loc_1;
        }// end function

        private function _WatchTowerInfoPanel_HealthBar1_i() : HealthBar
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

        private function _WatchTowerInfoPanel_Label1_i() : Label
        {
            var _loc_1:* = new Label();
            this.manageUnitsAmountLabel = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "manageUnitsAmountLabel";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function ___WatchTowerInfoPanel_StandardButton2_click(event:MouseEvent) : void
        {
            this.currentState = "";
            return;
        }// end function

        private function _WatchTowerInfoPanel_StandardButton2_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this._WatchTowerInfoPanel_StandardButton2 = _loc_1;
            _loc_1.width = 70;
            _loc_1.height = 32;
            _loc_1.addEventListener("click", this.___WatchTowerInfoPanel_StandardButton2_click);
            _loc_1.id = "_WatchTowerInfoPanel_StandardButton2";
            BindingManager.executeBindings(this, "_WatchTowerInfoPanel_StandardButton2", this._WatchTowerInfoPanel_StandardButton2);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _WatchTowerInfoPanel_Label5_i() : Label
        {
            var _loc_1:* = new Label();
            this._WatchTowerInfoPanel_Label5 = _loc_1;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("top", "15");
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "_WatchTowerInfoPanel_Label5";
            BindingManager.executeBindings(this, "_WatchTowerInfoPanel_Label5", this._WatchTowerInfoPanel_Label5);
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

        private function _WatchTowerInfoPanel_StandardButton6_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnManageArmy = _loc_1;
            _loc_1.width = 175;
            _loc_1.height = 27;
            _loc_1.setStyle("right", "27");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.addEventListener("click", this.__btnManageArmy_click);
            _loc_1.addEventListener("toolTipCreate", this.__btnManageArmy_toolTipCreate);
            _loc_1.id = "btnManageArmy";
            BindingManager.executeBindings(this, "btnManageArmy", this.btnManageArmy);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _WatchTowerInfoPanel_Canvas13_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.percentWidth = 100;
            _loc_1.height = 18;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._WatchTowerInfoPanel_Label7_i());
            return _loc_1;
        }// end function

        private function _WatchTowerInfoPanel_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.leftColumn;
            _loc_1 = this.rightColumn;
            _loc_1 = this.subcontent;
            _loc_1 = this.subcontent;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "OK");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Cancel");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Upgrade");
            _loc_1 = !this.upgradeTime.visible;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "NotPossible");
            _loc_1 = gAssetManager.GetClass("ButtonIconUpgrade");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "BuildingIntegrity");
            _loc_1 = gAssetManager.GetClass("ButtonIconBomb");
            _loc_1 = gAssetManager.GetClass("ButtonIconTools");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Repair");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Army");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ManageArmy");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ManageArmy");
            return;
        }// end function

        public function __btnCommitArmyChanges_click(event:MouseEvent) : void
        {
            this.currentState = "";
            return;
        }// end function

        private function _WatchTowerInfoPanel_Canvas3_c() : Canvas
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
            _loc_1.addChild(this._WatchTowerInfoPanel_TileList1_i());
            return _loc_1;
        }// end function

        private function _WatchTowerInfoPanel_HBox2_i() : HBox
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

        private function _WatchTowerInfoPanel_Canvas7_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.percentWidth = 100;
            _loc_1.height = 18;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._WatchTowerInfoPanel_Label2_i());
            return _loc_1;
        }// end function

        private function _WatchTowerInfoPanel_Text1_i() : Text
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

        public function set manageArmyList(param1:TileList) : void
        {
            var _loc_2:* = this._1138906016manageArmyList;
            if (_loc_2 !== param1)
            {
                this._1138906016manageArmyList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "manageArmyList", _loc_2, param1));
            }
            return;
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
