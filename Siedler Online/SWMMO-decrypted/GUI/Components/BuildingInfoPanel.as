package GUI.Components
{
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class BuildingInfoPanel extends BasicPanel implements IBindingClient
    {
        private var _1595352697cycleOutput:TradeResourceItemRenderer;
        private var _3642148way3:Label;
        private var _188974544levelLabel:Label;
        private var _11548545buttonBar:CustomToggleButtonBar;
        private var _1657431254labelWay3b:Label;
        private var _1657431224labelWay4a:Label;
        var _bindingsByDestination:Object;
        private var _823514743btnInstantUpgrade:StandardButton;
        private var _3642147way2:Label;
        private var _252650492costsList:HBox;
        public var _BuildingInfoPanel_Label2:Label;
        public var _BuildingInfoPanel_Label4:Label;
        public var _BuildingInfoPanel_Label5:Label;
        public var _BuildingInfoPanel_Label6:Label;
        public var _BuildingInfoPanel_Label7:Label;
        public var _BuildingInfoPanel_Label9:Label;
        private var _909318622statusLabel:Label;
        private var _1657431316labelWay1b:Label;
        private var _1025880371arrowWay3:Image;
        public var _BuildingInfoPanel_Label10:Label;
        private var _1420684256btnUpgrade:StandardButton;
        public var _BuildingInfoPanel_Label17:Label;
        private var _315005082btnKnockDown:StandardButton;
        public var _BuildingInfoPanel_Label25:Label;
        public var _BuildingInfoPanel_Label27:Label;
        private var _384625385workerIcon:ResourceIconRenderer;
        private var _1706723208inputList:VBox;
        private var _1025880373arrowWay1:Image;
        private var _1414920550detailsStack:ViewStack;
        private var _71109249iconOverallTime:Image;
        private var _1657431285labelWay2b:Label;
        private var _1657431255labelWay3a:Label;
        public var _BuildingInfoPanel_Image3:Image;
        private var _3642146way1:Label;
        public var _BuildingInfoPanel_Image9:Image;
        private var _1505249416btnStartStop:StandardButton;
        private var _1657431317labelWay1a:Label;
        private var _1274191590outputIcon:ResourceIconRenderer;
        private var _1724546052description:Text;
        private var _182170406productionTime:Label;
        private var _1080366632btnInstantBuff:StandardButton;
        private var _1025880370arrowWay4:Image;
        var _watchers:Array;
        private var _1657431223labelWay4b:Label;
        private var _3642149way4:Label;
        private var _100313435image:Image;
        var _bindingsBeginWithWord:Object;
        private var _1025880372arrowWay2:Image;
        private var _1657431286labelWay2a:Label;
        private var _1651126590payshopItemIndicator:Image;
        private var _551113993btnRepair:StandardButton;
        private var _205698255btnBuff:StandardButton;
        private var _1276447558overallTime:Label;
        private var _492830541integrity:HealthBar;
        private var _1844579575upgradeTime:Label;
        private var _679687681productionCycleStatus:HealthBar;
        var _bindings:Array;
        private var _487043394cycleInputList:VBox;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function BuildingInfoPanel()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:BasicPanel, propertiesFactory:function () : Object
            {
                return {width:321, height:398};
            }// end function
            });
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.width = 321;
            this.height = 398;
            this.subComponents = [this._BuildingInfoPanel_Canvas1_c(), this._BuildingInfoPanel_ViewStack1_i(), this._BuildingInfoPanel_Canvas25_c(), this._BuildingInfoPanel_CustomToggleButtonBar1_i()];
            return;
        }// end function

        private function _BuildingInfoPanel_HealthBar2_i() : HealthBar
        {
            var _loc_1:* = new HealthBar();
            this.productionCycleStatus = _loc_1;
            _loc_1.toolTip = "ProductionFinished";
            _loc_1.setStyle("left", "2");
            _loc_1.setStyle("right", "0");
            _loc_1.setStyle("bottom", "5");
            _loc_1.id = "productionCycleStatus";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_Label25_i() : Label
        {
            var _loc_1:* = new Label();
            this._BuildingInfoPanel_Label25 = _loc_1;
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.setStyle("left", "40");
            _loc_1.id = "_BuildingInfoPanel_Label25";
            BindingManager.executeBindings(this, "_BuildingInfoPanel_Label25", this._BuildingInfoPanel_Label25);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_Label2_i() : Label
        {
            var _loc_1:* = new Label();
            this._BuildingInfoPanel_Label2 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "_BuildingInfoPanel_Label2";
            BindingManager.executeBindings(this, "_BuildingInfoPanel_Label2", this._BuildingInfoPanel_Label2);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set productionCycleStatus(param1:HealthBar) : void
        {
            var _loc_2:* = this._679687681productionCycleStatus;
            if (_loc_2 !== param1)
            {
                this._679687681productionCycleStatus = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "productionCycleStatus", _loc_2, param1));
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

        private function _BuildingInfoPanel_StandardButton4_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnInstantBuff = _loc_1;
            _loc_1.enabled = false;
            _loc_1.width = 68;
            _loc_1.height = 39;
            _loc_1.setStyle("bottom", "2");
            _loc_1.setStyle("right", "6");
            _loc_1.addEventListener("toolTipCreate", this.__btnInstantBuff_toolTipCreate);
            _loc_1.id = "btnInstantBuff";
            BindingManager.executeBindings(this, "btnInstantBuff", this.btnInstantBuff);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set labelWay2a(param1:Label) : void
        {
            var _loc_2:* = this._1657431286labelWay2a;
            if (_loc_2 !== param1)
            {
                this._1657431286labelWay2a = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "labelWay2a", _loc_2, param1));
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

        private function _BuildingInfoPanel_HBox6_c() : HBox
        {
            var _loc_1:* = new HBox();
            _loc_1.setStyle("verticalAlign", "middle");
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("top", "99");
            _loc_1.setStyle("horizontalGap", 0);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._BuildingInfoPanel_Label22_i());
            _loc_1.addChild(this._BuildingInfoPanel_Image7_i());
            _loc_1.addChild(this._BuildingInfoPanel_Label23_i());
            return _loc_1;
        }// end function

        public function set labelWay2b(param1:Label) : void
        {
            var _loc_2:* = this._1657431285labelWay2b;
            if (_loc_2 !== param1)
            {
                this._1657431285labelWay2b = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "labelWay2b", _loc_2, param1));
            }
            return;
        }// end function

        private function _BuildingInfoPanel_Canvas23_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.percentWidth = 100;
            _loc_1.height = 18;
            _loc_1.setStyle("top", "194");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._BuildingInfoPanel_Label27_i());
            return _loc_1;
        }// end function

        public function get statusLabel() : Label
        {
            return this._909318622statusLabel;
        }// end function

        private function _BuildingInfoPanel_Label13_i() : Label
        {
            var _loc_1:* = new Label();
            this.way1 = _loc_1;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.setStyle("textAlign", "right");
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "5");
            _loc_1.id = "way1";
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

        public function get btnUpgrade() : StandardButton
        {
            return this._1420684256btnUpgrade;
        }// end function

        private function _BuildingInfoPanel_Canvas5_c() : Canvas
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
            _loc_1.addChild(this._BuildingInfoPanel_Canvas6_c());
            _loc_1.addChild(this._BuildingInfoPanel_StandardButton1_i());
            _loc_1.addChild(this._BuildingInfoPanel_StandardButton2_i());
            return _loc_1;
        }// end function

        public function set workerIcon(param1:ResourceIconRenderer) : void
        {
            var _loc_2:* = this._384625385workerIcon;
            if (_loc_2 !== param1)
            {
                this._384625385workerIcon = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "workerIcon", _loc_2, param1));
            }
            return;
        }// end function

        private function _BuildingInfoPanel_Canvas11_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.width = 135;
            _loc_1.setStyle("top", "0");
            _loc_1.setStyle("right", "0");
            _loc_1.setStyle("bottom", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._BuildingInfoPanel_Canvas12_c());
            _loc_1.addChild(this._BuildingInfoPanel_Canvas13_c());
            _loc_1.addChild(this._BuildingInfoPanel_Canvas15_c());
            _loc_1.addChild(this._BuildingInfoPanel_Canvas16_c());
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_Text1_i() : Text
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

        public function __outputIcon_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function set outputIcon(param1:ResourceIconRenderer) : void
        {
            var _loc_2:* = this._1274191590outputIcon;
            if (_loc_2 !== param1)
            {
                this._1274191590outputIcon = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "outputIcon", _loc_2, param1));
            }
            return;
        }// end function

        private function _BuildingInfoPanel_Image2_i() : Image
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

        private function _BuildingInfoPanel_HealthBar1_i() : HealthBar
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

        private function _BuildingInfoPanel_Label1_i() : Label
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

        private function _BuildingInfoPanel_Label24_i() : Label
        {
            var _loc_1:* = new Label();
            this.way4 = _loc_1;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.setStyle("textAlign", "right");
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "99");
            _loc_1.id = "way4";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set way2(param1:Label) : void
        {
            var _loc_2:* = this._3642147way2;
            if (_loc_2 !== param1)
            {
                this._3642147way2 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "way2", _loc_2, param1));
            }
            return;
        }// end function

        private function _BuildingInfoPanel_Canvas19_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.height = 174;
            _loc_1.setStyle("left", "1");
            _loc_1.setStyle("right", "1");
            _loc_1.setStyle("top", "18");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._BuildingInfoPanel_Canvas20_c());
            _loc_1.addChild(this._BuildingInfoPanel_Canvas22_c());
            return _loc_1;
        }// end function

        public function set way3(param1:Label) : void
        {
            var _loc_2:* = this._3642148way3;
            if (_loc_2 !== param1)
            {
                this._3642148way3 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "way3", _loc_2, param1));
            }
            return;
        }// end function

        private function _BuildingInfoPanel_Label9_i() : Label
        {
            var _loc_1:* = new Label();
            this._BuildingInfoPanel_Label9 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_BuildingInfoPanel_Label9";
            BindingManager.executeBindings(this, "_BuildingInfoPanel_Label9", this._BuildingInfoPanel_Label9);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set productionTime(param1:Label) : void
        {
            var _loc_2:* = this._182170406productionTime;
            if (_loc_2 !== param1)
            {
                this._182170406productionTime = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "productionTime", _loc_2, param1));
            }
            return;
        }// end function

        private function _BuildingInfoPanel_StandardButton3_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnBuff = _loc_1;
            _loc_1.enabled = false;
            _loc_1.width = 68;
            _loc_1.height = 39;
            _loc_1.setStyle("bottom", "2");
            _loc_1.setStyle("left", "6");
            _loc_1.id = "btnBuff";
            BindingManager.executeBindings(this, "btnBuff", this.btnBuff);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Object
            {
                return gAssetManager.GetBitmap("PayshopIndicator");
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
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Upgrade");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "_BuildingInfoPanel_Label2.text");
            result[1] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return !null;
            }// end function
            , function (param1:Boolean) : void
            {
                _BuildingInfoPanel_Label4.visible = param1;
                return;
            }// end function
            , "_BuildingInfoPanel_Label4.visible");
            result[2] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.DESCRIPTIONS, "NotPossible");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "_BuildingInfoPanel_Label4.text");
            result[3] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                btnUpgrade.setStyle("icon", param1);
                return;
            }// end function
            , "btnUpgrade.icon");
            result[4] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "ComingSoon");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.toolTip = param1;
                return;
            }// end function
            , "btnInstantUpgrade.toolTip");
            result[5] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ButtonIconUpgradeGems");
            }// end function
            , function (param1:Class) : void
            {
                btnInstantUpgrade.setStyle("icon", param1);
                return;
            }// end function
            , "btnInstantUpgrade.icon");
            result[6] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Buff");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "_BuildingInfoPanel_Label5.text");
            result[7] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("icon", param1);
                return;
            }// end function
            , "btnBuff.icon");
            result[8] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "Buff");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                btnBuff.toolTip = param1;
                return;
            }// end function
            , "btnBuff.toolTip");
            result[9] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "ComingSoon");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.toolTip = null;
                return;
            }// end function
            , "btnInstantBuff.toolTip");
            result[10] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ButtonIconCrownGems");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("icon", param1);
                return;
            }// end function
            , "btnInstantBuff.icon");
            result[11] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "BuildingIntegrity");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "_BuildingInfoPanel_Label6.text");
            result[12] = binding;
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
            result[13] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                btnRepair.setStyle("icon", param1);
                return;
            }// end function
            , "btnRepair.icon");
            result[14] = binding;
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
            result[15] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "ProductionStatus");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "_BuildingInfoPanel_Label7.text");
            result[16] = binding;
            binding = new Binding(this, function () : Object
            {
                return null.GetBitmap("ProductionArrow");
            }// end function
            , function (param1:Object) : void
            {
                _BuildingInfoPanel_Image3.source = param1;
                return;
            }// end function
            , "_BuildingInfoPanel_Image3.source");
            result[17] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Worker");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _BuildingInfoPanel_Label9.text = param1;
                return;
            }// end function
            , "_BuildingInfoPanel_Label9.text");
            result[18] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "ProductionDetailsTime");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "_BuildingInfoPanel_Label10.text");
            result[19] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.BUILDINGS, "Warehouse");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "labelWay1a.text");
            result[20] = binding;
            binding = new Binding(this, function () : Object
            {
                return null.GetBitmap("ArrowSmallRight");
            }// end function
            , function (param1:Object) : void
            {
                null.source = param1;
                return;
            }// end function
            , "arrowWay1.source");
            result[21] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Workyard");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "labelWay1b.text");
            result[22] = binding;
            binding = new Binding(this, function () : Object
            {
                return null.GetBitmap("ArrowSmallRight");
            }// end function
            , function (param1:Object) : void
            {
                null.source = null;
                return;
            }// end function
            , "arrowWay2.source");
            result[23] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "DetailsDeposit");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "labelWay2b.text");
            result[24] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "DetailsProductionTime");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "_BuildingInfoPanel_Label17.text");
            result[25] = binding;
            binding = new Binding(this, function () : Object
            {
                return gAssetManager.GetBitmap("ArrowSmallRight");
            }// end function
            , function (param1:Object) : void
            {
                arrowWay3.source = param1;
                return;
            }// end function
            , "arrowWay3.source");
            result[26] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Workyard");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "labelWay3b.text");
            result[27] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "Workyard");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                labelWay4a.text = param1;
                return;
            }// end function
            , "labelWay4a.text");
            result[28] = binding;
            binding = new Binding(this, function () : Object
            {
                return null.GetBitmap(null);
            }// end function
            , function (param1:Object) : void
            {
                arrowWay4.source = param1;
                return;
            }// end function
            , "arrowWay4.source");
            result[29] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.BUILDINGS, "Warehouse");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                labelWay4b.text = param1;
                return;
            }// end function
            , "labelWay4b.text");
            result[30] = binding;
            binding = new Binding(this, function () : Object
            {
                return null.GetBitmap("DetailsIconOverallTime");
            }// end function
            , function (param1:Object) : void
            {
                null.source = null;
                return;
            }// end function
            , "iconOverallTime.source");
            result[31] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "DetailsTotalTime");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _BuildingInfoPanel_Label25.text = param1;
                return;
            }// end function
            , "_BuildingInfoPanel_Label25.text");
            result[32] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ProductionDetailsCycle");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "_BuildingInfoPanel_Label27.text");
            result[33] = binding;
            binding = new Binding(this, function () : Object
            {
                return null.GetBitmap(null);
            }// end function
            , function (param1:Object) : void
            {
                _BuildingInfoPanel_Image9.source = param1;
                return;
            }// end function
            , "_BuildingInfoPanel_Image9.source");
            result[34] = binding;
            return result;
        }// end function

        public function set labelWay3b(param1:Label) : void
        {
            var _loc_2:* = this._1657431254labelWay3b;
            if (_loc_2 !== param1)
            {
                this._1657431254labelWay3b = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "labelWay3b", _loc_2, param1));
            }
            return;
        }// end function

        private function _BuildingInfoPanel_Canvas22_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.width = 196;
            _loc_1.height = 40;
            _loc_1.setStyle("bottom", "4");
            _loc_1.setStyle("left", "4");
            _loc_1.setStyle("right", "4");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._BuildingInfoPanel_Image8_i());
            _loc_1.addChild(this._BuildingInfoPanel_Label25_i());
            _loc_1.addChild(this._BuildingInfoPanel_Label26_i());
            return _loc_1;
        }// end function

        public function set labelWay3a(param1:Label) : void
        {
            var _loc_2:* = this._1657431255labelWay3a;
            if (_loc_2 !== param1)
            {
                this._1657431255labelWay3a = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "labelWay3a", _loc_2, param1));
            }
            return;
        }// end function

        private function _BuildingInfoPanel_HBox5_c() : HBox
        {
            var _loc_1:* = new HBox();
            _loc_1.setStyle("verticalAlign", "middle");
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("top", "77");
            _loc_1.setStyle("horizontalGap", 0);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._BuildingInfoPanel_Label19_i());
            _loc_1.addChild(this._BuildingInfoPanel_Image6_i());
            _loc_1.addChild(this._BuildingInfoPanel_Label20_i());
            return _loc_1;
        }// end function

        public function set statusLabel(param1:Label) : void
        {
            var _loc_2:* = this._909318622statusLabel;
            if (_loc_2 !== param1)
            {
                this._909318622statusLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "statusLabel", _loc_2, param1));
            }
            return;
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

        private function _BuildingInfoPanel_Label12_i() : Label
        {
            var _loc_1:* = new Label();
            this.labelWay1b = _loc_1;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "labelWay1b";
            BindingManager.executeBindings(this, "labelWay1b", this.labelWay1b);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_Canvas4_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.percentWidth = 100;
            _loc_1.height = 18;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._BuildingInfoPanel_Label1_i());
            return _loc_1;
        }// end function

        public function set way1(param1:Label) : void
        {
            var _loc_2:* = this._3642146way1;
            if (_loc_2 !== param1)
            {
                this._3642146way1 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "way1", _loc_2, param1));
            }
            return;
        }// end function

        public function set way4(param1:Label) : void
        {
            var _loc_2:* = this._3642149way4;
            if (_loc_2 !== param1)
            {
                this._3642149way4 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "way4", _loc_2, param1));
            }
            return;
        }// end function

        private function _BuildingInfoPanel_ResourceIconRenderer2_i() : ResourceIconRenderer
        {
            var _loc_1:* = new ResourceIconRenderer();
            this.workerIcon = _loc_1;
            _loc_1.resourceName = "Population";
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "workerIcon";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_Canvas10_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.height = 66;
            _loc_1.setStyle("left", "1");
            _loc_1.setStyle("right", "1");
            _loc_1.setStyle("top", "204");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._BuildingInfoPanel_StandardButton5_i());
            _loc_1.addChild(this._BuildingInfoPanel_StandardButton6_i());
            _loc_1.addChild(this._BuildingInfoPanel_HealthBar1_i());
            return _loc_1;
        }// end function

        public function __btnInstantBuff_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        private function _BuildingInfoPanel_Image1_i() : Image
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

        public function get btnInstantUpgrade() : StandardButton
        {
            return this._823514743btnInstantUpgrade;
        }// end function

        private function _BuildingInfoPanel_Canvas18_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.percentWidth = 100;
            _loc_1.height = 18;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._BuildingInfoPanel_Label10_i());
            return _loc_1;
        }// end function

        public function get iconOverallTime() : Image
        {
            return this._71109249iconOverallTime;
        }// end function

        private function _BuildingInfoPanel_Label23_i() : Label
        {
            var _loc_1:* = new Label();
            this.labelWay4b = _loc_1;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "labelWay4b";
            BindingManager.executeBindings(this, "labelWay4b", this.labelWay4b);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_Image9_i() : Image
        {
            var _loc_1:* = new Image();
            this._BuildingInfoPanel_Image9 = _loc_1;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "_BuildingInfoPanel_Image9";
            BindingManager.executeBindings(this, "_BuildingInfoPanel_Image9", this._BuildingInfoPanel_Image9);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get btnStartStop() : StandardButton
        {
            return this._1505249416btnStartStop;
        }// end function

        private function _BuildingInfoPanel_Label8_i() : Label
        {
            var _loc_1:* = new Label();
            this.statusLabel = _loc_1;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "statusLabel";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set cycleInputList(param1:VBox) : void
        {
            var _loc_2:* = this._487043394cycleInputList;
            if (_loc_2 !== param1)
            {
                this._487043394cycleInputList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "cycleInputList", _loc_2, param1));
            }
            return;
        }// end function

        public function set labelWay4a(param1:Label) : void
        {
            var _loc_2:* = this._1657431224labelWay4a;
            if (_loc_2 !== param1)
            {
                this._1657431224labelWay4a = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "labelWay4a", _loc_2, param1));
            }
            return;
        }// end function

        private function _BuildingInfoPanel_StandardButton2_i() : StandardButton
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

        public function set labelWay4b(param1:Label) : void
        {
            var _loc_2:* = this._1657431223labelWay4b;
            if (_loc_2 !== param1)
            {
                this._1657431223labelWay4b = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "labelWay4b", _loc_2, param1));
            }
            return;
        }// end function

        private function _BuildingInfoPanel_HBox4_c() : HBox
        {
            var _loc_1:* = new HBox();
            _loc_1.setStyle("verticalAlign", "middle");
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("top", "27");
            _loc_1.setStyle("horizontalGap", 0);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._BuildingInfoPanel_Label14_i());
            _loc_1.addChild(this._BuildingInfoPanel_Image5_i());
            _loc_1.addChild(this._BuildingInfoPanel_Label15_i());
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_Label11_i() : Label
        {
            var _loc_1:* = new Label();
            this.labelWay1a = _loc_1;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "labelWay1a";
            BindingManager.executeBindings(this, "labelWay1a", this.labelWay1a);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_Canvas21_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.setStyle("left", "0");
            _loc_1.setStyle("right", "0");
            _loc_1.setStyle("top", "49");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._BuildingInfoPanel_Label17_i());
            _loc_1.addChild(this._BuildingInfoPanel_Label18_i());
            return _loc_1;
        }// end function

        public function get btnKnockDown() : StandardButton
        {
            return this._315005082btnKnockDown;
        }// end function

        private function _BuildingInfoPanel_Label19_i() : Label
        {
            var _loc_1:* = new Label();
            this.labelWay3a = _loc_1;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "labelWay3a";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_VBox2_i() : VBox
        {
            var _loc_1:* = new VBox();
            this.cycleInputList = _loc_1;
            _loc_1.setStyle("horizontalCenter", "-50");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.setStyle("verticalGap", 3);
            _loc_1.id = "cycleInputList";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_Canvas3_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.width = 155;
            _loc_1.setStyle("top", "0");
            _loc_1.setStyle("left", "0");
            _loc_1.setStyle("bottom", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._BuildingInfoPanel_Canvas4_c());
            _loc_1.addChild(this._BuildingInfoPanel_Canvas5_c());
            _loc_1.addChild(this._BuildingInfoPanel_Canvas7_c());
            _loc_1.addChild(this._BuildingInfoPanel_Canvas8_c());
            _loc_1.addChild(this._BuildingInfoPanel_Canvas9_c());
            _loc_1.addChild(this._BuildingInfoPanel_Canvas10_c());
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_ResourceIconRenderer1_i() : ResourceIconRenderer
        {
            var _loc_1:* = new ResourceIconRenderer();
            this.outputIcon = _loc_1;
            _loc_1.setStyle("right", "10");
            _loc_1.setStyle("verticalCenter", "-10");
            _loc_1.addEventListener("toolTipCreate", this.__outputIcon_toolTipCreate);
            _loc_1.id = "outputIcon";
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

        public function get overallTime() : Label
        {
            return this._1276447558overallTime;
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

        public function __btnUpgrade_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.UPGRADE_BUILDING_string, event);
            return;
        }// end function

        private function _BuildingInfoPanel_Label22_i() : Label
        {
            var _loc_1:* = new Label();
            this.labelWay4a = _loc_1;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "labelWay4a";
            BindingManager.executeBindings(this, "labelWay4a", this.labelWay4a);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_Image8_i() : Image
        {
            var _loc_1:* = new Image();
            this.iconOverallTime = _loc_1;
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.setStyle("left", "0");
            _loc_1.id = "iconOverallTime";
            BindingManager.executeBindings(this, "iconOverallTime", this.iconOverallTime);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_Label7_i() : Label
        {
            var _loc_1:* = new Label();
            this._BuildingInfoPanel_Label7 = _loc_1;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_BuildingInfoPanel_Label7";
            BindingManager.executeBindings(this, "_BuildingInfoPanel_Label7", this._BuildingInfoPanel_Label7);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get arrowWay1() : Image
        {
            return this._1025880373arrowWay1;
        }// end function

        public function get arrowWay2() : Image
        {
            return this._1025880372arrowWay2;
        }// end function

        public function get arrowWay4() : Image
        {
            return this._1025880370arrowWay4;
        }// end function

        public function get btnBuff() : StandardButton
        {
            return this._205698255btnBuff;
        }// end function

        private function _BuildingInfoPanel_StandardButton1_i() : StandardButton
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

        public function set detailsStack(param1:ViewStack) : void
        {
            var _loc_2:* = this._1414920550detailsStack;
            if (_loc_2 !== param1)
            {
                this._1414920550detailsStack = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "detailsStack", _loc_2, param1));
            }
            return;
        }// end function

        public function get arrowWay3() : Image
        {
            return this._1025880371arrowWay3;
        }// end function

        private function _BuildingInfoPanel_Canvas20_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.height = 122;
            _loc_1.setStyle("top", "4");
            _loc_1.setStyle("left", "4");
            _loc_1.setStyle("right", "4");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._BuildingInfoPanel_HBox3_c());
            _loc_1.addChild(this._BuildingInfoPanel_Label13_i());
            _loc_1.addChild(this._BuildingInfoPanel_HBox4_c());
            _loc_1.addChild(this._BuildingInfoPanel_Label16_i());
            _loc_1.addChild(this._BuildingInfoPanel_Canvas21_c());
            _loc_1.addChild(this._BuildingInfoPanel_HBox5_c());
            _loc_1.addChild(this._BuildingInfoPanel_Label21_i());
            _loc_1.addChild(this._BuildingInfoPanel_HBox6_c());
            _loc_1.addChild(this._BuildingInfoPanel_Label24_i());
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_HBox3_c() : HBox
        {
            var _loc_1:* = new HBox();
            _loc_1.setStyle("verticalAlign", "middle");
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("top", "5");
            _loc_1.setStyle("horizontalGap", 0);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._BuildingInfoPanel_Label11_i());
            _loc_1.addChild(this._BuildingInfoPanel_Image4_i());
            _loc_1.addChild(this._BuildingInfoPanel_Label12_i());
            return _loc_1;
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

        private function _BuildingInfoPanel_Canvas17_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._BuildingInfoPanel_Canvas18_c());
            _loc_1.addChild(this._BuildingInfoPanel_Canvas19_c());
            _loc_1.addChild(this._BuildingInfoPanel_Canvas23_c());
            _loc_1.addChild(this._BuildingInfoPanel_Canvas24_c());
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_Label10_i() : Label
        {
            var _loc_1:* = new Label();
            this._BuildingInfoPanel_Label10 = _loc_1;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_BuildingInfoPanel_Label10";
            BindingManager.executeBindings(this, "_BuildingInfoPanel_Label10", this._BuildingInfoPanel_Label10);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_Canvas2_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._BuildingInfoPanel_Canvas3_c());
            _loc_1.addChild(this._BuildingInfoPanel_Canvas11_c());
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_VBox1_i() : VBox
        {
            var _loc_1:* = new VBox();
            this.inputList = _loc_1;
            _loc_1.setStyle("left", "10");
            _loc_1.setStyle("verticalCenter", "-10");
            _loc_1.setStyle("verticalGap", 0);
            _loc_1.id = "inputList";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get labelWay1b() : Label
        {
            return this._1657431316labelWay1b;
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

        private function _BuildingInfoPanel_Label18_i() : Label
        {
            var _loc_1:* = new Label();
            this.productionTime = _loc_1;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.setStyle("textAlign", "right");
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "3");
            _loc_1.setStyle("bottom", "3");
            _loc_1.id = "productionTime";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get labelWay1a() : Label
        {
            return this._1657431317labelWay1a;
        }// end function

        private function _BuildingInfoPanel_Canvas16_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.height = 95;
            _loc_1.setStyle("left", "1");
            _loc_1.setStyle("right", "1");
            _loc_1.setStyle("top", "175");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._BuildingInfoPanel_ResourceIconRenderer2_i());
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_Label21_i() : Label
        {
            var _loc_1:* = new Label();
            this.way3 = _loc_1;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.setStyle("textAlign", "right");
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "77");
            _loc_1.id = "way3";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_Image7_i() : Image
        {
            var _loc_1:* = new Image();
            this.arrowWay4 = _loc_1;
            _loc_1.id = "arrowWay4";
            BindingManager.executeBindings(this, "arrowWay4", this.arrowWay4);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_Label6_i() : Label
        {
            var _loc_1:* = new Label();
            this._BuildingInfoPanel_Label6 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_BuildingInfoPanel_Label6";
            BindingManager.executeBindings(this, "_BuildingInfoPanel_Label6", this._BuildingInfoPanel_Label6);
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

        public function get labelWay2a() : Label
        {
            return this._1657431286labelWay2a;
        }// end function

        public function set btnStartStop(param1:StandardButton) : void
        {
            var _loc_2:* = this._1505249416btnStartStop;
            if (_loc_2 !== param1)
            {
                this._1505249416btnStartStop = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnStartStop", _loc_2, param1));
            }
            return;
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

        public function get labelWay2b() : Label
        {
            return this._1657431285labelWay2b;
        }// end function

        private function _BuildingInfoPanel_TradeResourceItemRenderer1_i() : TradeResourceItemRenderer
        {
            var _loc_1:* = new TradeResourceItemRenderer();
            this.cycleOutput = _loc_1;
            _loc_1.setStyle("horizontalCenter", "50");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "cycleOutput";
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

        public function set cycleOutput(param1:TradeResourceItemRenderer) : void
        {
            var _loc_2:* = this._1595352697cycleOutput;
            if (_loc_2 !== param1)
            {
                this._1595352697cycleOutput = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "cycleOutput", _loc_2, param1));
            }
            return;
        }// end function

        private function _BuildingInfoPanel_HBox2_c() : HBox
        {
            var _loc_1:* = new HBox();
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("horizontalGap", 0);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._BuildingInfoPanel_Label7_i());
            _loc_1.addChild(this._BuildingInfoPanel_Label8_i());
            return _loc_1;
        }// end function

        public function set inputList(param1:VBox) : void
        {
            var _loc_2:* = this._1706723208inputList;
            if (_loc_2 !== param1)
            {
                this._1706723208inputList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "inputList", _loc_2, param1));
            }
            return;
        }// end function

        private function _BuildingInfoPanel_Canvas1_c() : Canvas
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
            _loc_1.addChild(this._BuildingInfoPanel_Image1_i());
            _loc_1.addChild(this._BuildingInfoPanel_Image2_i());
            _loc_1.addChild(this._BuildingInfoPanel_Text1_i());
            return _loc_1;
        }// end function

        public function get way2() : Label
        {
            return this._3642147way2;
        }// end function

        public function set iconOverallTime(param1:Image) : void
        {
            var _loc_2:* = this._71109249iconOverallTime;
            if (_loc_2 !== param1)
            {
                this._71109249iconOverallTime = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "iconOverallTime", _loc_2, param1));
            }
            return;
        }// end function

        public function get way4() : Label
        {
            return this._3642149way4;
        }// end function

        public function __buttonBar_itemClick(event:ItemClickEvent) : void
        {
            this.detailsStack.selectedIndex = this.buttonBar.selectedIndex;
            return;
        }// end function

        public function __btnStartStop_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        private function _BuildingInfoPanel_Canvas9_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.percentWidth = 100;
            _loc_1.height = 18;
            _loc_1.setStyle("top", "186");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._BuildingInfoPanel_Label6_i());
            return _loc_1;
        }// end function

        public function get labelWay3b() : Label
        {
            return this._1657431254labelWay3b;
        }// end function

        public function get way3() : Label
        {
            return this._3642148way3;
        }// end function

        public function get productionTime() : Label
        {
            return this._182170406productionTime;
        }// end function

        private function _BuildingInfoPanel_Label17_i() : Label
        {
            var _loc_1:* = new Label();
            this._BuildingInfoPanel_Label17 = _loc_1;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.setStyle("textAlign", "right");
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("top", "3");
            _loc_1.setStyle("bottom", "3");
            _loc_1.id = "_BuildingInfoPanel_Label17";
            BindingManager.executeBindings(this, "_BuildingInfoPanel_Label17", this._BuildingInfoPanel_Label17);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get way1() : Label
        {
            return this._3642146way1;
        }// end function

        public function get outputIcon() : ResourceIconRenderer
        {
            return this._1274191590outputIcon;
        }// end function

        public function get workerIcon() : ResourceIconRenderer
        {
            return this._384625385workerIcon;
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

        private function _BuildingInfoPanel_Label20_i() : Label
        {
            var _loc_1:* = new Label();
            this.labelWay3b = _loc_1;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "labelWay3b";
            BindingManager.executeBindings(this, "labelWay3b", this.labelWay3b);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_Image6_i() : Image
        {
            var _loc_1:* = new Image();
            this.arrowWay3 = _loc_1;
            _loc_1.id = "arrowWay3";
            BindingManager.executeBindings(this, "arrowWay3", this.arrowWay3);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_Canvas15_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.percentWidth = 100;
            _loc_1.height = 18;
            _loc_1.setStyle("top", "157");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._BuildingInfoPanel_Label9_i());
            return _loc_1;
        }// end function

        public function get payshopItemIndicator() : Image
        {
            return this._1651126590payshopItemIndicator;
        }// end function

        private function _BuildingInfoPanel_Label5_i() : Label
        {
            var _loc_1:* = new Label();
            this._BuildingInfoPanel_Label5 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_BuildingInfoPanel_Label5";
            BindingManager.executeBindings(this, "_BuildingInfoPanel_Label5", this._BuildingInfoPanel_Label5);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get labelWay4a() : Label
        {
            return this._1657431224labelWay4a;
        }// end function

        public function get cycleInputList() : VBox
        {
            return this._487043394cycleInputList;
        }// end function

        public function get labelWay3a() : Label
        {
            return this._1657431255labelWay3a;
        }// end function

        public function get integrity() : HealthBar
        {
            return this._492830541integrity;
        }// end function

        private function _BuildingInfoPanel_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = gAssetManager.GetBitmap("PayshopIndicator");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Upgrade");
            _loc_1 = !this.upgradeTime.visible;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "NotPossible");
            _loc_1 = gAssetManager.GetClass("ButtonIconUpgrade");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ComingSoon");
            _loc_1 = gAssetManager.GetClass("ButtonIconUpgradeGems");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Buff");
            _loc_1 = gAssetManager.GetClass("ButtonIconCrown");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Buff");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ComingSoon");
            _loc_1 = gAssetManager.GetClass("ButtonIconCrownGems");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "BuildingIntegrity");
            _loc_1 = gAssetManager.GetClass("ButtonIconBomb");
            _loc_1 = gAssetManager.GetClass("ButtonIconTools");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Repair");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ProductionStatus");
            _loc_1 = gAssetManager.GetBitmap("ProductionArrow");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Worker");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ProductionDetailsTime");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.BUILDINGS, "Warehouse");
            _loc_1 = gAssetManager.GetBitmap("ArrowSmallRight");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Workyard");
            _loc_1 = gAssetManager.GetBitmap("ArrowSmallRight");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "DetailsDeposit");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "DetailsProductionTime");
            _loc_1 = gAssetManager.GetBitmap("ArrowSmallRight");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Workyard");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Workyard");
            _loc_1 = gAssetManager.GetBitmap("ArrowSmallRight");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.BUILDINGS, "Warehouse");
            _loc_1 = gAssetManager.GetBitmap("DetailsIconOverallTime");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "DetailsTotalTime");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ProductionDetailsCycle");
            _loc_1 = gAssetManager.GetBitmap("ProductionArrow");
            return;
        }// end function

        private function _BuildingInfoPanel_StandardButton7_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnStartStop = _loc_1;
            _loc_1.width = 68;
            _loc_1.height = 39;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("top", "96");
            _loc_1.addEventListener("toolTipCreate", this.__btnStartStop_toolTipCreate);
            _loc_1.id = "btnStartStop";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_CustomToggleButtonBar1_i() : CustomToggleButtonBar
        {
            var _loc_1:* = new CustomToggleButtonBar();
            this.buttonBar = _loc_1;
            _loc_1.setStyle("buttonStyleName", "tab");
            _loc_1.setStyle("selectedButtonTextStyleName", "tabSelected");
            _loc_1.setStyle("bottom", "0");
            _loc_1.setStyle("left", "2");
            _loc_1.setStyle("right", "0");
            _loc_1.addEventListener("itemClick", this.__buttonBar_itemClick);
            _loc_1.id = "buttonBar";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_HBox1_i() : HBox
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

        public function get labelWay4b() : Label
        {
            return this._1657431223labelWay4b;
        }// end function

        public function get image() : Image
        {
            return this._100313435image;
        }// end function

        public function get detailsStack() : ViewStack
        {
            return this._1414920550detailsStack;
        }// end function

        private function _BuildingInfoPanel_Label16_i() : Label
        {
            var _loc_1:* = new Label();
            this.way2 = _loc_1;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.setStyle("textAlign", "right");
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "27");
            _loc_1.id = "way2";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_Canvas8_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.height = 43;
            _loc_1.setStyle("left", "1");
            _loc_1.setStyle("right", "1");
            _loc_1.setStyle("top", "141");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._BuildingInfoPanel_StandardButton3_i());
            _loc_1.addChild(this._BuildingInfoPanel_StandardButton4_i());
            return _loc_1;
        }// end function

        public function set overallTime(param1:Label) : void
        {
            var _loc_2:* = this._1276447558overallTime;
            if (_loc_2 !== param1)
            {
                this._1276447558overallTime = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "overallTime", _loc_2, param1));
            }
            return;
        }// end function

        private function _BuildingInfoPanel_Canvas14_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.percentWidth = 100;
            _loc_1.height = 94;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._BuildingInfoPanel_VBox1_i());
            _loc_1.addChild(this._BuildingInfoPanel_Image3_i());
            _loc_1.addChild(this._BuildingInfoPanel_ResourceIconRenderer1_i());
            _loc_1.addChild(this._BuildingInfoPanel_HealthBar2_i());
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_Image5_i() : Image
        {
            var _loc_1:* = new Image();
            this.arrowWay2 = _loc_1;
            _loc_1.id = "arrowWay2";
            BindingManager.executeBindings(this, "arrowWay2", this.arrowWay2);
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

        private function _BuildingInfoPanel_Label4_i() : Label
        {
            var _loc_1:* = new Label();
            this._BuildingInfoPanel_Label4 = _loc_1;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("top", "15");
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "_BuildingInfoPanel_Label4";
            BindingManager.executeBindings(this, "_BuildingInfoPanel_Label4", this._BuildingInfoPanel_Label4);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_Label27_i() : Label
        {
            var _loc_1:* = new Label();
            this._BuildingInfoPanel_Label27 = _loc_1;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_BuildingInfoPanel_Label27";
            BindingManager.executeBindings(this, "_BuildingInfoPanel_Label27", this._BuildingInfoPanel_Label27);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get inputList() : VBox
        {
            return this._1706723208inputList;
        }// end function

        private function _BuildingInfoPanel_StandardButton6_i() : StandardButton
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

        public function set arrowWay1(param1:Image) : void
        {
            var _loc_2:* = this._1025880373arrowWay1;
            if (_loc_2 !== param1)
            {
                this._1025880373arrowWay1 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "arrowWay1", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnBuff(param1:StandardButton) : void
        {
            var _loc_2:* = this._205698255btnBuff;
            if (_loc_2 !== param1)
            {
                this._205698255btnBuff = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnBuff", _loc_2, param1));
            }
            return;
        }// end function

        override public function initialize() : void
        {
            var target:BuildingInfoPanel;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._BuildingInfoPanel_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_BuildingInfoPanelWatcherSetupUtil");
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

        public function set arrowWay3(param1:Image) : void
        {
            var _loc_2:* = this._1025880371arrowWay3;
            if (_loc_2 !== param1)
            {
                this._1025880371arrowWay3 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "arrowWay3", _loc_2, param1));
            }
            return;
        }// end function

        private function _BuildingInfoPanel_Canvas25_c() : Canvas
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

        public function set arrowWay4(param1:Image) : void
        {
            var _loc_2:* = this._1025880370arrowWay4;
            if (_loc_2 !== param1)
            {
                this._1025880370arrowWay4 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "arrowWay4", _loc_2, param1));
            }
            return;
        }// end function

        private function _BuildingInfoPanel_Label15_i() : Label
        {
            var _loc_1:* = new Label();
            this.labelWay2b = _loc_1;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "labelWay2b";
            BindingManager.executeBindings(this, "labelWay2b", this.labelWay2b);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_Canvas7_c() : Canvas
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
            _loc_1.addChild(this._BuildingInfoPanel_Label5_i());
            return _loc_1;
        }// end function

        public function get cycleOutput() : TradeResourceItemRenderer
        {
            return this._1595352697cycleOutput;
        }// end function

        public function set arrowWay2(param1:Image) : void
        {
            var _loc_2:* = this._1025880372arrowWay2;
            if (_loc_2 !== param1)
            {
                this._1025880372arrowWay2 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "arrowWay2", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnInstantBuff(param1:StandardButton) : void
        {
            var _loc_2:* = this._1080366632btnInstantBuff;
            if (_loc_2 !== param1)
            {
                this._1080366632btnInstantBuff = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnInstantBuff", _loc_2, param1));
            }
            return;
        }// end function

        private function _BuildingInfoPanel_Image4_i() : Image
        {
            var _loc_1:* = new Image();
            this.arrowWay1 = _loc_1;
            _loc_1.id = "arrowWay1";
            BindingManager.executeBindings(this, "arrowWay1", this.arrowWay1);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_Canvas13_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.height = 137;
            _loc_1.setStyle("left", "1");
            _loc_1.setStyle("right", "1");
            _loc_1.setStyle("top", "18");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._BuildingInfoPanel_Canvas14_c());
            _loc_1.addChild(this._BuildingInfoPanel_StandardButton7_i());
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_Label3_i() : Label
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

        private function _BuildingInfoPanel_Label26_i() : Label
        {
            var _loc_1:* = new Label();
            this.overallTime = _loc_1;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("textAlign", "right");
            _loc_1.id = "overallTime";
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

        private function _BuildingInfoPanel_StandardButton5_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnKnockDown = _loc_1;
            _loc_1.playSound = false;
            _loc_1.enabled = false;
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

        public function get btnInstantBuff() : StandardButton
        {
            return this._1080366632btnInstantBuff;
        }// end function

        private function _BuildingInfoPanel_Label14_i() : Label
        {
            var _loc_1:* = new Label();
            this.labelWay2a = _loc_1;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "labelWay2a";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_Canvas6_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.percentWidth = 100;
            _loc_1.height = 60;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._BuildingInfoPanel_Label2_i());
            _loc_1.addChild(this._BuildingInfoPanel_Label3_i());
            _loc_1.addChild(this._BuildingInfoPanel_Label4_i());
            _loc_1.addChild(this._BuildingInfoPanel_HBox1_i());
            return _loc_1;
        }// end function

        private function _BuildingInfoPanel_Canvas24_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.setStyle("left", "1");
            _loc_1.setStyle("right", "1");
            _loc_1.setStyle("top", "212");
            _loc_1.setStyle("bottom", "2");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._BuildingInfoPanel_VBox2_i());
            _loc_1.addChild(this._BuildingInfoPanel_Image9_i());
            _loc_1.addChild(this._BuildingInfoPanel_TradeResourceItemRenderer1_i());
            return _loc_1;
        }// end function

        public function set labelWay1a(param1:Label) : void
        {
            var _loc_2:* = this._1657431317labelWay1a;
            if (_loc_2 !== param1)
            {
                this._1657431317labelWay1a = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "labelWay1a", _loc_2, param1));
            }
            return;
        }// end function

        public function set labelWay1b(param1:Label) : void
        {
            var _loc_2:* = this._1657431316labelWay1b;
            if (_loc_2 !== param1)
            {
                this._1657431316labelWay1b = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "labelWay1b", _loc_2, param1));
            }
            return;
        }// end function

        private function _BuildingInfoPanel_ViewStack1_i() : ViewStack
        {
            var _loc_1:* = new ViewStack();
            this.detailsStack = _loc_1;
            _loc_1.setStyle("left", "8");
            _loc_1.setStyle("right", "7");
            _loc_1.setStyle("top", "62");
            _loc_1.setStyle("bottom", "33");
            _loc_1.id = "detailsStack";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._BuildingInfoPanel_Canvas2_c());
            _loc_1.addChild(this._BuildingInfoPanel_Canvas17_c());
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

        private function _BuildingInfoPanel_Canvas12_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.percentWidth = 100;
            _loc_1.height = 18;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._BuildingInfoPanel_HBox2_c());
            return _loc_1;
        }// end function

        public function get description() : Text
        {
            return this._1724546052description;
        }// end function

        private function _BuildingInfoPanel_Image3_i() : Image
        {
            var _loc_1:* = new Image();
            this._BuildingInfoPanel_Image3 = _loc_1;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "-10");
            _loc_1.id = "_BuildingInfoPanel_Image3";
            BindingManager.executeBindings(this, "_BuildingInfoPanel_Image3", this._BuildingInfoPanel_Image3);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get productionCycleStatus() : HealthBar
        {
            return this._679687681productionCycleStatus;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
