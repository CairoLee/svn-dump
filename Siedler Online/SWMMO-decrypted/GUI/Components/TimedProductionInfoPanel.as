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

    public class TimedProductionInfoPanel extends BasicPanel implements IBindingClient
    {
        private var _151081947stateManageOrders:State;
        private var _1696501657rightColumnRecruite:Canvas;
        private var _2071334935busyOverlay:Canvas;
        private var _714353731selectedUnitDescription:Text;
        private var _188974544levelLabel:Label;
        private var _11548545buttonBar:CustomToggleButtonBar;
        var _bindingsByDestination:Object;
        public var _TimedProductionInfoPanel_RemoveChild1:RemoveChild;
        public var _TimedProductionInfoPanel_RemoveChild2:RemoveChild;
        public var _TimedProductionInfoPanel_RemoveChild3:RemoveChild;
        private var _823514743btnInstantUpgrade:StandardButton;
        private var _2100227641subcontent:Canvas;
        private var _252650492costsList:HBox;
        private var _1420684256btnUpgrade:StandardButton;
        public var _TimedProductionInfoPanel_AddChild1:AddChild;
        private var _315005082btnKnockDown:StandardButton;
        public var _TimedProductionInfoPanel_SetProperty1:SetProperty;
        private var _94069048btnOK:StandardButton;
        private var _632007349middleColumn:Canvas;
        private var _372886614orderCostsList:HorizontalList;
        private var _624365078selectedUnitName:Label;
        private var _624512040selectedUnitIcon:Image;
        private var _1718313852currentOrdersList:TileList;
        private var _1133386838busyAnim:SpriteLibAnimation;
        public var _TimedProductionInfoPanel_Label1:Label;
        public var _TimedProductionInfoPanel_Label3:Label;
        public var _TimedProductionInfoPanel_Label5:Label;
        public var _TimedProductionInfoPanel_Label7:Label;
        public var _TimedProductionInfoPanel_Label8:Label;
        public var _TimedProductionInfoPanel_Label9:Label;
        private var _1724546052description:Text;
        public var _TimedProductionInfoPanel_StandardButton2:StandardButton;
        private var _765989721amountSlider:ExtendedHSlider;
        var _watchers:Array;
        private var _100313435image:Image;
        private var _199019724availableOrdersList:CustomTileList;
        var _bindingsBeginWithWord:Object;
        private var _551113993btnRepair:StandardButton;
        private var _492830541integrity:HealthBar;
        private var _1844579575upgradeTime:Label;
        var _bindings:Array;
        private var _824652908listBackground:Canvas;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function TimedProductionInfoPanel()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:BasicPanel, propertiesFactory:function () : Object
            {
                return {width:590, height:333};
            }// end function
            });
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.width = 590;
            this.height = 333;
            this.states = [this._TimedProductionInfoPanel_State1_i()];
            this.subComponents = [this._TimedProductionInfoPanel_Canvas7_i(), this._TimedProductionInfoPanel_Canvas20_c(), this._TimedProductionInfoPanel_CustomToggleButtonBar1_i()];
            return;
        }// end function

        private function _TimedProductionInfoPanel_Label7_i() : Label
        {
            var _loc_1:* = new Label();
            this._TimedProductionInfoPanel_Label7 = _loc_1;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("top", "15");
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "_TimedProductionInfoPanel_Label7";
            BindingManager.executeBindings(this, "_TimedProductionInfoPanel_Label7", this._TimedProductionInfoPanel_Label7);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
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

        private function _TimedProductionInfoPanel_Canvas19_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.busyOverlay = _loc_1;
            _loc_1.styleName = "detailsContentBox";
            _loc_1.visible = false;
            _loc_1.setStyle("left", "324");
            _loc_1.setStyle("right", "23");
            _loc_1.setStyle("top", "63");
            _loc_1.setStyle("bottom", "33");
            _loc_1.id = "busyOverlay";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._TimedProductionInfoPanel_SpriteLibAnimation1_i());
            return _loc_1;
        }// end function

        private function _TimedProductionInfoPanel_StandardButton6_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnRepair = _loc_1;
            _loc_1.enabled = false;
            _loc_1.width = 68;
            _loc_1.height = 39;
            _loc_1.setStyle("right", "6");
            _loc_1.setStyle("top", "5");
            _loc_1.id = "btnRepair";
            BindingManager.executeBindings(this, "btnRepair", this.btnRepair);
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

        private function _TimedProductionInfoPanel_HBox2_c() : HBox
        {
            var _loc_1:* = new HBox();
            _loc_1.percentWidth = 100;
            _loc_1.setStyle("horizontalAlign", "center");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._TimedProductionInfoPanel_StandardButton1_i());
            _loc_1.addChild(this._TimedProductionInfoPanel_StandardButton2_i());
            return _loc_1;
        }// end function

        public function get busyOverlay() : Canvas
        {
            return this._2071334935busyOverlay;
        }// end function

        public function get btnUpgrade() : StandardButton
        {
            return this._1420684256btnUpgrade;
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

        public function set busyOverlay(param1:Canvas) : void
        {
            var _loc_2:* = this._2071334935busyOverlay;
            if (_loc_2 !== param1)
            {
                this._2071334935busyOverlay = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "busyOverlay", _loc_2, param1));
            }
            return;
        }// end function

        private function _TimedProductionInfoPanel_Canvas7_i() : Canvas
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
            _loc_1.addChild(this._TimedProductionInfoPanel_Canvas8_c());
            _loc_1.addChild(this._TimedProductionInfoPanel_Canvas9_c());
            _loc_1.addChild(this._TimedProductionInfoPanel_Canvas15_i());
            _loc_1.addChild(this._TimedProductionInfoPanel_Canvas18_i());
            _loc_1.addChild(this._TimedProductionInfoPanel_TileList1_i());
            _loc_1.addChild(this._TimedProductionInfoPanel_Canvas19_i());
            return _loc_1;
        }// end function

        private function _TimedProductionInfoPanel_Canvas10_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.percentWidth = 100;
            _loc_1.height = 18;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._TimedProductionInfoPanel_Label4_i());
            return _loc_1;
        }// end function

        public function get subcontent() : Canvas
        {
            return this._2100227641subcontent;
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

        private function _TimedProductionInfoPanel_Canvas18_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.listBackground = _loc_1;
            _loc_1.styleName = "listBackgroundShadow";
            _loc_1.setStyle("left", "324");
            _loc_1.setStyle("right", "23");
            _loc_1.setStyle("top", "63");
            _loc_1.setStyle("bottom", "33");
            _loc_1.id = "listBackground";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _TimedProductionInfoPanel_Label6_i() : Label
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

        private function _TimedProductionInfoPanel_Spacer1_c() : Spacer
        {
            var _loc_1:* = new Spacer();
            _loc_1.height = 8;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _TimedProductionInfoPanel_StandardButton5_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnKnockDown = _loc_1;
            _loc_1.enabled = false;
            _loc_1.playSound = false;
            _loc_1.width = 68;
            _loc_1.height = 39;
            _loc_1.setStyle("left", "6");
            _loc_1.setStyle("top", "5");
            _loc_1.id = "btnKnockDown";
            BindingManager.executeBindings(this, "btnKnockDown", this.btnKnockDown);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _TimedProductionInfoPanel_HBox1_c() : HBox
        {
            var _loc_1:* = new HBox();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.height = 35;
            _loc_1.setStyle("horizontalAlign", "center");
            _loc_1.setStyle("verticalAlign", "middle");
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "5");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._TimedProductionInfoPanel_Image1_i());
            _loc_1.addChild(this._TimedProductionInfoPanel_Label2_i());
            return _loc_1;
        }// end function

        public function get orderCostsList() : HorizontalList
        {
            return this._372886614orderCostsList;
        }// end function

        private function _TimedProductionInfoPanel_Canvas6_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.percentWidth = 100;
            _loc_1.height = 35;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._TimedProductionInfoPanel_Label3_i());
            _loc_1.addChild(this._TimedProductionInfoPanel_ExtendedHSlider1_i());
            return _loc_1;
        }// end function

        public function get listBackground() : Canvas
        {
            return this._824652908listBackground;
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

        public function get btnInstantUpgrade() : StandardButton
        {
            return this._823514743btnInstantUpgrade;
        }// end function

        private function _TimedProductionInfoPanel_Canvas17_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.percentWidth = 100;
            _loc_1.setStyle("top", "18");
            _loc_1.setStyle("bottom", "0");
            _loc_1.setStyle("left", "1");
            _loc_1.setStyle("right", "1");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._TimedProductionInfoPanel_CustomTileList1_i());
            return _loc_1;
        }// end function

        private function _TimedProductionInfoPanel_HealthBar1_i() : HealthBar
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

        private function _TimedProductionInfoPanel_ExtendedHSlider1_i() : ExtendedHSlider
        {
            var _loc_1:* = new ExtendedHSlider();
            this.amountSlider = _loc_1;
            _loc_1.enabled = false;
            _loc_1.value = 1;
            _loc_1.liveDragging = true;
            _loc_1.minimum = 1;
            _loc_1.setStyle("bottom", "3");
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("left", "5");
            _loc_1.id = "amountSlider";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _TimedProductionInfoPanel_Label5_i() : Label
        {
            var _loc_1:* = new Label();
            this._TimedProductionInfoPanel_Label5 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "_TimedProductionInfoPanel_Label5";
            BindingManager.executeBindings(this, "_TimedProductionInfoPanel_Label5", this._TimedProductionInfoPanel_Label5);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _TimedProductionInfoPanel_Canvas20_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "hr";
            _loc_1.height = 3;
            _loc_1.setStyle("left", "2");
            _loc_1.setStyle("right", "0");
            _loc_1.setStyle("bottom", "27");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _TimedProductionInfoPanel_StandardButton4_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnInstantUpgrade = _loc_1;
            _loc_1.playSound = false;
            _loc_1.enabled = false;
            _loc_1.width = 68;
            _loc_1.height = 39;
            _loc_1.setStyle("bottom", "2");
            _loc_1.setStyle("right", "6");
            _loc_1.addEventListener("toolTipCreate", this.__btnInstantUpgrade_toolTipCreate);
            _loc_1.id = "btnInstantUpgrade";
            BindingManager.executeBindings(this, "btnInstantUpgrade", this.btnInstantUpgrade);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set middleColumn(param1:Canvas) : void
        {
            var _loc_2:* = this._632007349middleColumn;
            if (_loc_2 !== param1)
            {
                this._632007349middleColumn = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "middleColumn", _loc_2, param1));
            }
            return;
        }// end function

        private function _TimedProductionInfoPanel_CustomToggleButtonBar1_i() : CustomToggleButtonBar
        {
            var _loc_1:* = new CustomToggleButtonBar();
            this.buttonBar = _loc_1;
            _loc_1.setStyle("buttonStyleName", "tab");
            _loc_1.setStyle("selectedButtonTextStyleName", "tabSelected");
            _loc_1.setStyle("bottom", "0");
            _loc_1.setStyle("left", "2");
            _loc_1.setStyle("right", "0");
            _loc_1.addEventListener("toolTipCreate", this.__buttonBar_toolTipCreate);
            _loc_1.id = "buttonBar";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
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

        private function _TimedProductionInfoPanel_TileList1_i() : TileList
        {
            var _loc_1:* = new TileList();
            this.currentOrdersList = _loc_1;
            _loc_1.selectable = false;
            _loc_1.itemRenderer = this._TimedProductionInfoPanel_ClassFactory3_c();
            _loc_1.setStyle("useRollOver", false);
            _loc_1.setStyle("backgroundAlpha", 0);
            _loc_1.setStyle("borderThickness", 0);
            _loc_1.setStyle("left", "328");
            _loc_1.setStyle("right", "6");
            _loc_1.setStyle("top", "67");
            _loc_1.setStyle("bottom", "34");
            _loc_1.id = "currentOrdersList";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _TimedProductionInfoPanel_SpriteLibAnimation1_i() : SpriteLibAnimation
        {
            var _loc_1:* = new SpriteLibAnimation();
            this.busyAnim = _loc_1;
            _loc_1.animationName = "guianim_hourglass";
            _loc_1.loop = true;
            _loc_1.visible = false;
            _loc_1.width = 48;
            _loc_1.height = 48;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "busyAnim";
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

        private function _TimedProductionInfoPanel_Canvas5_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.verticalScrollPolicy = "auto";
            _loc_1.horizontalScrollPolicy = "off";
            _loc_1.setStyle("left", "3");
            _loc_1.setStyle("right", "0");
            _loc_1.setStyle("top", "5");
            _loc_1.setStyle("bottom", "5");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._TimedProductionInfoPanel_Text1_i());
            return _loc_1;
        }// end function

        public function __buttonBar_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function set orderCostsList(param1:HorizontalList) : void
        {
            var _loc_2:* = this._372886614orderCostsList;
            if (_loc_2 !== param1)
            {
                this._372886614orderCostsList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "orderCostsList", _loc_2, param1));
            }
            return;
        }// end function

        public function set amountSlider(param1:ExtendedHSlider) : void
        {
            var _loc_2:* = this._765989721amountSlider;
            if (_loc_2 !== param1)
            {
                this._765989721amountSlider = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "amountSlider", _loc_2, param1));
            }
            return;
        }// end function

        private function _TimedProductionInfoPanel_Canvas16_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.percentWidth = 100;
            _loc_1.height = 18;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._TimedProductionInfoPanel_Label9_i());
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

        private function _TimedProductionInfoPanel_State1_i() : State
        {
            var _loc_1:* = new State();
            this.stateManageOrders = _loc_1;
            _loc_1.name = "manageOrders";
            _loc_1.overrides = [this._TimedProductionInfoPanel_SetProperty1_i(), this._TimedProductionInfoPanel_RemoveChild1_i(), this._TimedProductionInfoPanel_RemoveChild2_i(), this._TimedProductionInfoPanel_RemoveChild3_i(), this._TimedProductionInfoPanel_AddChild1_i()];
            return _loc_1;
        }// end function

        private function _TimedProductionInfoPanel_Label4_i() : Label
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

        public function get availableOrdersList() : CustomTileList
        {
            return this._199019724availableOrdersList;
        }// end function

        public function set listBackground(param1:Canvas) : void
        {
            var _loc_2:* = this._824652908listBackground;
            if (_loc_2 !== param1)
            {
                this._824652908listBackground = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "listBackground", _loc_2, param1));
            }
            return;
        }// end function

        private function _TimedProductionInfoPanel_StandardButton3_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnUpgrade = _loc_1;
            _loc_1.playSound = false;
            _loc_1.enabled = false;
            _loc_1.width = 68;
            _loc_1.height = 39;
            _loc_1.setStyle("bottom", "2");
            _loc_1.setStyle("left", "6");
            _loc_1.addEventListener("toolTipCreate", this.__btnUpgrade_toolTipCreate);
            _loc_1.id = "btnUpgrade";
            BindingManager.executeBindings(this, "btnUpgrade", this.btnUpgrade);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _TimedProductionInfoPanel_Canvas4_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("top", "45");
            _loc_1.setStyle("bottom", "5");
            _loc_1.setStyle("right", "210");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._TimedProductionInfoPanel_Canvas5_c());
            return _loc_1;
        }// end function

        public function set btnInstantUpgrade(param1:StandardButton) : void
        {
            var _loc_2:* = this._823514743btnInstantUpgrade;
            if (_loc_2 !== param1)
            {
                this._823514743btnInstantUpgrade = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnInstantUpgrade", _loc_2, param1));
            }
            return;
        }// end function

        private function _TimedProductionInfoPanel_Text2_i() : Text
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

        public function set currentOrdersList(param1:TileList) : void
        {
            var _loc_2:* = this._1718313852currentOrdersList;
            if (_loc_2 !== param1)
            {
                this._1718313852currentOrdersList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "currentOrdersList", _loc_2, param1));
            }
            return;
        }// end function

        private function _TimedProductionInfoPanel_RemoveChild3_i() : RemoveChild
        {
            var _loc_1:* = new RemoveChild();
            this._TimedProductionInfoPanel_RemoveChild3 = _loc_1;
            BindingManager.executeBindings(this, "_TimedProductionInfoPanel_RemoveChild3", this._TimedProductionInfoPanel_RemoveChild3);
            return _loc_1;
        }// end function

        private function _TimedProductionInfoPanel_Canvas15_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.middleColumn = _loc_1;
            _loc_1.width = 155;
            _loc_1.setStyle("top", "62");
            _loc_1.setStyle("left", "166");
            _loc_1.setStyle("bottom", "33");
            _loc_1.id = "middleColumn";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._TimedProductionInfoPanel_Canvas16_c());
            _loc_1.addChild(this._TimedProductionInfoPanel_Canvas17_c());
            return _loc_1;
        }// end function

        private function _TimedProductionInfoPanel_Label3_i() : Label
        {
            var _loc_1:* = new Label();
            this._TimedProductionInfoPanel_Label3 = _loc_1;
            _loc_1.setStyle("top", "3");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.id = "_TimedProductionInfoPanel_Label3";
            BindingManager.executeBindings(this, "_TimedProductionInfoPanel_Label3", this._TimedProductionInfoPanel_Label3);
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

        public function set buttonBar(param1:CustomToggleButtonBar) : void
        {
            var _loc_2:* = this._11548545buttonBar;
            if (_loc_2 !== param1)
            {
                this._11548545buttonBar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "buttonBar", _loc_2, param1));
            }
            return;
        }// end function

        private function _TimedProductionInfoPanel_StandardButton2_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this._TimedProductionInfoPanel_StandardButton2 = _loc_1;
            _loc_1.width = 70;
            _loc_1.height = 32;
            _loc_1.addEventListener("click", this.___TimedProductionInfoPanel_StandardButton2_click);
            _loc_1.id = "_TimedProductionInfoPanel_StandardButton2";
            BindingManager.executeBindings(this, "_TimedProductionInfoPanel_StandardButton2", this._TimedProductionInfoPanel_StandardButton2);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __btnInstantUpgrade_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function get upgradeTime() : Label
        {
            return this._1844579575upgradeTime;
        }// end function

        private function _TimedProductionInfoPanel_Canvas3_c() : Canvas
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
            _loc_1.addChild(this._TimedProductionInfoPanel_HBox1_c());
            _loc_1.addChild(this._TimedProductionInfoPanel_Canvas4_c());
            _loc_1.addChild(this._TimedProductionInfoPanel_VBox1_c());
            return _loc_1;
        }// end function

        public function set rightColumnRecruite(param1:Canvas) : void
        {
            var _loc_2:* = this._1696501657rightColumnRecruite;
            if (_loc_2 !== param1)
            {
                this._1696501657rightColumnRecruite = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "rightColumnRecruite", _loc_2, param1));
            }
            return;
        }// end function

        private function _TimedProductionInfoPanel_Text1_i() : Text
        {
            var _loc_1:* = new Text();
            this.selectedUnitDescription = _loc_1;
            _loc_1.percentWidth = 100;
            _loc_1.selectable = false;
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.setStyle("paddingLeft", 0);
            _loc_1.setStyle("paddingTop", 0);
            _loc_1.setStyle("paddingBottom", 0);
            _loc_1.setStyle("paddingRight", 12);
            _loc_1.id = "selectedUnitDescription";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get btnOK() : StandardButton
        {
            return this._94069048btnOK;
        }// end function

        private function _TimedProductionInfoPanel_Canvas14_c() : Canvas
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
            _loc_1.addChild(this._TimedProductionInfoPanel_StandardButton5_i());
            _loc_1.addChild(this._TimedProductionInfoPanel_StandardButton6_i());
            _loc_1.addChild(this._TimedProductionInfoPanel_HealthBar1_i());
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

        private function _TimedProductionInfoPanel_RemoveChild2_i() : RemoveChild
        {
            var _loc_1:* = new RemoveChild();
            this._TimedProductionInfoPanel_RemoveChild2 = _loc_1;
            BindingManager.executeBindings(this, "_TimedProductionInfoPanel_RemoveChild2", this._TimedProductionInfoPanel_RemoveChild2);
            return _loc_1;
        }// end function

        private function _TimedProductionInfoPanel_Label2_i() : Label
        {
            var _loc_1:* = new Label();
            this.selectedUnitName = _loc_1;
            _loc_1.setStyle("color", 16777215);
            _loc_1.id = "selectedUnitName";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _TimedProductionInfoPanel_ClassFactory3_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = OrderItemRenderer;
            return _loc_1;
        }// end function

        public function get integrity() : HealthBar
        {
            return this._492830541integrity;
        }// end function

        private function _TimedProductionInfoPanel_StandardButton1_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnOK = _loc_1;
            _loc_1.enabled = false;
            _loc_1.width = 70;
            _loc_1.height = 32;
            _loc_1.addEventListener("click", this.__btnOK_click);
            _loc_1.id = "btnOK";
            BindingManager.executeBindings(this, "btnOK", this.btnOK);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set busyAnim(param1:SpriteLibAnimation) : void
        {
            var _loc_2:* = this._1133386838busyAnim;
            if (_loc_2 !== param1)
            {
                this._1133386838busyAnim = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "busyAnim", _loc_2, param1));
            }
            return;
        }// end function

        public function get middleColumn() : Canvas
        {
            return this._632007349middleColumn;
        }// end function

        public function get amountSlider() : ExtendedHSlider
        {
            return this._765989721amountSlider;
        }// end function

        public function ___TimedProductionInfoPanel_StandardButton2_click(event:MouseEvent) : void
        {
            this.currentState = "";
            return;
        }// end function

        public function get image() : Image
        {
            return this._100313435image;
        }// end function

        private function _TimedProductionInfoPanel_Canvas2_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.percentWidth = 100;
            _loc_1.height = 18;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._TimedProductionInfoPanel_Label1_i());
            return _loc_1;
        }// end function

        public function set selectedUnitDescription(param1:Text) : void
        {
            var _loc_2:* = this._714353731selectedUnitDescription;
            if (_loc_2 !== param1)
            {
                this._714353731selectedUnitDescription = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "selectedUnitDescription", _loc_2, param1));
            }
            return;
        }// end function

        private function _TimedProductionInfoPanel_Image2_i() : Image
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

        public function get currentOrdersList() : TileList
        {
            return this._1718313852currentOrdersList;
        }// end function

        private function _TimedProductionInfoPanel_RemoveChild1_i() : RemoveChild
        {
            var _loc_1:* = new RemoveChild();
            this._TimedProductionInfoPanel_RemoveChild1 = _loc_1;
            BindingManager.executeBindings(this, "_TimedProductionInfoPanel_RemoveChild1", this._TimedProductionInfoPanel_RemoveChild1);
            return _loc_1;
        }// end function

        private function _TimedProductionInfoPanel_Canvas13_c() : Canvas
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
            _loc_1.addChild(this._TimedProductionInfoPanel_Label8_i());
            return _loc_1;
        }// end function

        private function _TimedProductionInfoPanel_Label1_i() : Label
        {
            var _loc_1:* = new Label();
            this._TimedProductionInfoPanel_Label1 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_TimedProductionInfoPanel_Label1";
            BindingManager.executeBindings(this, "_TimedProductionInfoPanel_Label1", this._TimedProductionInfoPanel_Label1);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get buttonBar() : CustomToggleButtonBar
        {
            return this._11548545buttonBar;
        }// end function

        private function _TimedProductionInfoPanel_Label9_i() : Label
        {
            var _loc_1:* = new Label();
            this._TimedProductionInfoPanel_Label9 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_TimedProductionInfoPanel_Label9";
            BindingManager.executeBindings(this, "_TimedProductionInfoPanel_Label9", this._TimedProductionInfoPanel_Label9);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _TimedProductionInfoPanel_ClassFactory2_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = TimedProductionTypeItemRenderer;
            return _loc_1;
        }// end function

        override public function initialize() : void
        {
            var target:TimedProductionInfoPanel;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._TimedProductionInfoPanel_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_TimedProductionInfoPanelWatcherSetupUtil");
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

        private function _TimedProductionInfoPanel_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.btnOK;
            _loc_1 = this.middleColumn;
            _loc_1 = this.listBackground;
            _loc_1 = this.currentOrdersList;
            _loc_1 = this.subcontent;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Select");
            _loc_1 = this.amountSlider.value + " / " + this.amountSlider.maximum;
            _loc_1 = this.amountSlider.enabled;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "OK");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Cancel");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Upgrade");
            _loc_1 = !this.upgradeTime.visible;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "NotPossible");
            _loc_1 = gAssetManager.GetClass("ButtonIconUpgrade");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ComingSoon");
            _loc_1 = gAssetManager.GetClass("ButtonIconUpgradeGems");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "BuildingIntegrity");
            _loc_1 = gAssetManager.GetClass("ButtonIconBomb");
            _loc_1 = gAssetManager.GetClass("ButtonIconTools");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Repair");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Select");
            return;
        }// end function

        public function get rightColumnRecruite() : Canvas
        {
            return this._1696501657rightColumnRecruite;
        }// end function

        public function set availableOrdersList(param1:CustomTileList) : void
        {
            var _loc_2:* = this._199019724availableOrdersList;
            if (_loc_2 !== param1)
            {
                this._199019724availableOrdersList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "availableOrdersList", _loc_2, param1));
            }
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

        private function _TimedProductionInfoPanel_AddChild1_i() : AddChild
        {
            var _loc_1:* = new AddChild();
            this._TimedProductionInfoPanel_AddChild1 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._TimedProductionInfoPanel_Canvas1_i);
            BindingManager.executeBindings(this, "_TimedProductionInfoPanel_AddChild1", this._TimedProductionInfoPanel_AddChild1);
            return _loc_1;
        }// end function

        private function _TimedProductionInfoPanel_Canvas1_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.rightColumnRecruite = _loc_1;
            _loc_1.setStyle("left", "166");
            _loc_1.setStyle("right", "7");
            _loc_1.setStyle("top", "62");
            _loc_1.setStyle("bottom", "33");
            _loc_1.id = "rightColumnRecruite";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._TimedProductionInfoPanel_Canvas2_c());
            _loc_1.addChild(this._TimedProductionInfoPanel_Canvas3_c());
            return _loc_1;
        }// end function

        public function get busyAnim() : SpriteLibAnimation
        {
            return this._1133386838busyAnim;
        }// end function

        private function _TimedProductionInfoPanel_Canvas9_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.width = 155;
            _loc_1.setStyle("top", "62");
            _loc_1.setStyle("left", "8");
            _loc_1.setStyle("bottom", "33");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._TimedProductionInfoPanel_Canvas10_c());
            _loc_1.addChild(this._TimedProductionInfoPanel_Canvas11_c());
            _loc_1.addChild(this._TimedProductionInfoPanel_Canvas13_c());
            _loc_1.addChild(this._TimedProductionInfoPanel_Canvas14_c());
            return _loc_1;
        }// end function

        public function set selectedUnitIcon(param1:Image) : void
        {
            var _loc_2:* = this._624512040selectedUnitIcon;
            if (_loc_2 !== param1)
            {
                this._624512040selectedUnitIcon = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "selectedUnitIcon", _loc_2, param1));
            }
            return;
        }// end function

        public function set stateManageOrders(param1:State) : void
        {
            var _loc_2:* = this._151081947stateManageOrders;
            if (_loc_2 !== param1)
            {
                this._151081947stateManageOrders = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "stateManageOrders", _loc_2, param1));
            }
            return;
        }// end function

        private function _TimedProductionInfoPanel_Canvas12_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.percentWidth = 100;
            _loc_1.height = 60;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._TimedProductionInfoPanel_Label5_i());
            _loc_1.addChild(this._TimedProductionInfoPanel_Label6_i());
            _loc_1.addChild(this._TimedProductionInfoPanel_Label7_i());
            _loc_1.addChild(this._TimedProductionInfoPanel_HBox3_i());
            return _loc_1;
        }// end function

        private function _TimedProductionInfoPanel_Image1_i() : Image
        {
            var _loc_1:* = new Image();
            this.selectedUnitIcon = _loc_1;
            _loc_1.width = 26;
            _loc_1.height = 25;
            _loc_1.id = "selectedUnitIcon";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get selectedUnitDescription() : Text
        {
            return this._714353731selectedUnitDescription;
        }// end function

        private function _TimedProductionInfoPanel_SetProperty1_i() : SetProperty
        {
            var _loc_1:* = new SetProperty();
            this._TimedProductionInfoPanel_SetProperty1 = _loc_1;
            _loc_1.name = "enabled";
            _loc_1.value = false;
            BindingManager.executeBindings(this, "_TimedProductionInfoPanel_SetProperty1", this._TimedProductionInfoPanel_SetProperty1);
            return _loc_1;
        }// end function

        private function _TimedProductionInfoPanel_Label8_i() : Label
        {
            var _loc_1:* = new Label();
            this._TimedProductionInfoPanel_Label8 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_TimedProductionInfoPanel_Label8";
            BindingManager.executeBindings(this, "_TimedProductionInfoPanel_Label8", this._TimedProductionInfoPanel_Label8);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _TimedProductionInfoPanel_ClassFactory1_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = OrderCostsItemRenderer;
            return _loc_1;
        }// end function

        public function get levelLabel() : Label
        {
            return this._188974544levelLabel;
        }// end function

        public function set selectedUnitName(param1:Label) : void
        {
            var _loc_2:* = this._624365078selectedUnitName;
            if (_loc_2 !== param1)
            {
                this._624365078selectedUnitName = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "selectedUnitName", _loc_2, param1));
            }
            return;
        }// end function

        private function _TimedProductionInfoPanel_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Object
            {
                return btnOK;
            }// end function
            , function (param1:Object) : void
            {
                null.target = null;
                return;
            }// end function
            , "_TimedProductionInfoPanel_SetProperty1.target");
            result[0] = binding;
            binding = new Binding(this, function () : DisplayObject
            {
                return middleColumn;
            }// end function
            , function (param1:DisplayObject) : void
            {
                _TimedProductionInfoPanel_RemoveChild1.target = param1;
                return;
            }// end function
            , "_TimedProductionInfoPanel_RemoveChild1.target");
            result[1] = binding;
            binding = new Binding(this, function () : DisplayObject
            {
                return listBackground;
            }// end function
            , function (param1:DisplayObject) : void
            {
                null.target = null;
                return;
            }// end function
            , "_TimedProductionInfoPanel_RemoveChild2.target");
            result[2] = binding;
            binding = new Binding(this, function () : DisplayObject
            {
                return currentOrdersList;
            }// end function
            , function (param1:DisplayObject) : void
            {
                null.target = null;
                return;
            }// end function
            , "_TimedProductionInfoPanel_RemoveChild3.target");
            result[3] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return subcontent;
            }// end function
            , function (param1:UIComponent) : void
            {
                null.relativeTo = null;
                return;
            }// end function
            , "_TimedProductionInfoPanel_AddChild1.relativeTo");
            result[4] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Select");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "_TimedProductionInfoPanel_Label1.text");
            result[5] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = amountSlider.value + " / " + amountSlider.maximum;
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "_TimedProductionInfoPanel_Label3.text");
            result[6] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return amountSlider.enabled;
            }// end function
            , function (param1:Boolean) : void
            {
                null.visible = null;
                return;
            }// end function
            , "_TimedProductionInfoPanel_Label3.visible");
            result[7] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "OK");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnOK.label");
            result[8] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "Cancel");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "_TimedProductionInfoPanel_StandardButton2.label");
            result[9] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Upgrade");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _TimedProductionInfoPanel_Label5.text = param1;
                return;
            }// end function
            , "_TimedProductionInfoPanel_Label5.text");
            result[10] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return !upgradeTime.visible;
            }// end function
            , function (param1:Boolean) : void
            {
                null.visible = param1;
                return;
            }// end function
            , "_TimedProductionInfoPanel_Label7.visible");
            result[11] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "NotPossible");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _TimedProductionInfoPanel_Label7.text = param1;
                return;
            }// end function
            , "_TimedProductionInfoPanel_Label7.text");
            result[12] = binding;
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
            result[13] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ComingSoon");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                btnInstantUpgrade.toolTip = param1;
                return;
            }// end function
            , "btnInstantUpgrade.toolTip");
            result[14] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("icon", param1);
                return;
            }// end function
            , "btnInstantUpgrade.icon");
            result[15] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "BuildingIntegrity");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "_TimedProductionInfoPanel_Label8.text");
            result[16] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ButtonIconBomb");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("icon", param1);
                return;
            }// end function
            , "btnKnockDown.icon");
            result[17] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ButtonIconTools");
            }// end function
            , function (param1:Class) : void
            {
                btnRepair.setStyle("icon", param1);
                return;
            }// end function
            , "btnRepair.icon");
            result[18] = binding;
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
            result[19] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Select");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _TimedProductionInfoPanel_Label9.text = param1;
                return;
            }// end function
            , "_TimedProductionInfoPanel_Label9.text");
            result[20] = binding;
            return result;
        }// end function

        public function get selectedUnitIcon() : Image
        {
            return this._624512040selectedUnitIcon;
        }// end function

        public function get stateManageOrders() : State
        {
            return this._151081947stateManageOrders;
        }// end function

        private function _TimedProductionInfoPanel_HorizontalList1_i() : HorizontalList
        {
            var _loc_1:* = new HorizontalList();
            this.orderCostsList = _loc_1;
            _loc_1.percentWidth = 100;
            _loc_1.itemRenderer = this._TimedProductionInfoPanel_ClassFactory1_c();
            _loc_1.selectable = false;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("backgroundAlpha", 0);
            _loc_1.setStyle("borderThickness", 0);
            _loc_1.setStyle("useRollOver", false);
            _loc_1.id = "orderCostsList";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _TimedProductionInfoPanel_HBox3_i() : HBox
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

        public function __btnOK_click(event:MouseEvent) : void
        {
            this.currentState = "";
            return;
        }// end function

        private function _TimedProductionInfoPanel_CustomTileList1_i() : CustomTileList
        {
            var _loc_1:* = new CustomTileList();
            this.availableOrdersList = _loc_1;
            _loc_1.itemRenderer = this._TimedProductionInfoPanel_ClassFactory2_c();
            _loc_1.setStyle("borderThickness", 0);
            _loc_1.setStyle("backgroundAlpha", 0);
            _loc_1.setStyle("useRollOver", false);
            _loc_1.setStyle("left", "10");
            _loc_1.setStyle("right", "8");
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("bottom", "0");
            _loc_1.id = "availableOrdersList";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _TimedProductionInfoPanel_VBox1_c() : VBox
        {
            var _loc_1:* = new VBox();
            _loc_1.width = 200;
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "45");
            _loc_1.setStyle("verticalGap", 0);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._TimedProductionInfoPanel_HorizontalList1_i());
            _loc_1.addChild(this._TimedProductionInfoPanel_Canvas6_c());
            _loc_1.addChild(this._TimedProductionInfoPanel_Spacer1_c());
            _loc_1.addChild(this._TimedProductionInfoPanel_HBox2_c());
            return _loc_1;
        }// end function

        private function _TimedProductionInfoPanel_Canvas8_c() : Canvas
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
            _loc_1.addChild(this._TimedProductionInfoPanel_Image2_i());
            _loc_1.addChild(this._TimedProductionInfoPanel_Text2_i());
            return _loc_1;
        }// end function

        public function set busy(param1:Boolean) : void
        {
            this.busyOverlay.visible = param1;
            this.busyAnim.visible = param1;
            return;
        }// end function

        private function _TimedProductionInfoPanel_Canvas11_c() : Canvas
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
            _loc_1.addChild(this._TimedProductionInfoPanel_Canvas12_c());
            _loc_1.addChild(this._TimedProductionInfoPanel_StandardButton3_i());
            _loc_1.addChild(this._TimedProductionInfoPanel_StandardButton4_i());
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

        public function get selectedUnitName() : Label
        {
            return this._624365078selectedUnitName;
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
