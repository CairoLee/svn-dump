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
    import mx.effects.*;
    import mx.events.*;
    import mx.states.*;
    import mx.utils.*;

    public class SpecialistPanel extends Canvas implements IBindingClient
    {
        private var _413548460textExploreSector:CustomText;
        private var _110371416title:Label;
        private var _1398146422generalRightColumn:Canvas;
        private var _2136299818textFindTreasureMedium:CustomText;
        private var _1091436750fadeOut:Fade;
        private var _1001194825btnFindDepositSalpeter:StandardButton;
        private var _1906816914costsHolder:HBox;
        private var _301308949textFindDepositTitaniumOre:CustomText;
        private var _101681415btnFindTreasureEvenLonger:StandardButton;
        var _bindingsByDestination:Object;
        private var _455805296textFindDepositBronzeOre:CustomText;
        private var _123800555btnFindWildZone:StandardButton;
        private var _662302869textFindDepositMarble:CustomText;
        private var _117924854btnCancel:StandardButton;
        private var _978547872btnFindTreasureLong:StandardButton;
        private var _1001078227progress:ProgressBar;
        private var _1279979510textFindAdventureZone:CustomText;
        private var _880041745textFindDepositCoal:CustomText;
        public var _SpecialistPanel_CustomText1:CustomText;
        public var _SpecialistPanel_CustomText2:CustomText;
        public var _SpecialistPanel_CustomText3:CustomText;
        private var _234552695btnFindAdventureLong:StandardButton;
        private var _860383323btnFindAdventure:StandardButton;
        private var _94756344close:CloseButton;
        private var _1769179066textFindDepositSalpeter:CustomText;
        private var _182970263subContentExplorerBase:Canvas;
        private var _878320385generalBusy:Canvas;
        private var _1321480231textFindTreasureShort:CustomText;
        public var _SpecialistPanel_Label1:Label;
        public var _SpecialistPanel_Label2:Label;
        public var _SpecialistPanel_Label4:Label;
        public var _SpecialistPanel_Label5:Label;
        public var _SpecialistPanel_Label7:Label;
        private var _867684882manageUnitsAmountLabel:Label;
        private var _462284889btnFindDepositGranite:StandardButton;
        private var _371719110stateGeologist:State;
        private var _2044959678subContentFindAdventure:Canvas;
        private var _276470488btnFindTreasureShort:StandardButton;
        private var _1723375940specialistFrame:Frame;
        private var _1290420114textFindAdventureZoneLong:CustomText;
        private var _91139125btnRetreat:StandardButton;
        private var _1744270317btnResetArmyChanges:StandardButton;
        public var _SpecialistPanel_RemoveChild1:RemoveChild;
        var _bindingsBeginWithWord:Object;
        private var _702386745taskDuration:Label;
        private var _878160605btnExploreSector:StandardButton;
        private var _2044770799btnFindDepositIronOre:StandardButton;
        private var _1282133823fadeIn:Fade;
        private var _373943576textFindTreasureEvenLonger:CustomText;
        private var _767257665progressProxy:ObjectProxy;
        private var _2085942192btnFindAdventureMedium:StandardButton;
        private var _128157573confirmFooter:Canvas;
        private var _1354575398textFindAdventureZoneShort:CustomText;
        private var _29046788btnFindDepositTitaniumOre:StandardButton;
        private var _1234272665btnTransfer:StandardButton;
        private var _1897236111textFindTreasureLong:CustomText;
        private var _162733755generalLeftColumn:Canvas;
        private var _1502151446textFindDepositGranite:CustomText;
        private var _1379232572btnFindDepositStone:StandardButton;
        private var _201201486generalBusyAnim:SpriteLibAnimation;
        private var _601227934currentTask:CustomText;
        private var _93112087stateGeneral:State;
        private var _382706874btnFindDepositMarble:StandardButton;
        private var _94069048btnOK:StandardButton;
        private var _33091925textFindTreasure:CustomText;
        private var _1064369184btnFindDepositCoal:StandardButton;
        private var _1564391859btnCommitArmyChanges:StandardButton;
        private var _1771381052textFindWildZone:CustomText;
        private var _1138906016manageArmyList:TileList;
        private var _1496551411textFindDepositStone:CustomText;
        private var _1578203126textFindDepositGoldOre:CustomText;
        private var _1132717301textFindAdventureZoneMedium:CustomText;
        private var _78390212btnAttack:StandardButton;
        private var _1724546052description:Text;
        private var _1876869695btnFindDepositBronzeOre:StandardButton;
        private var _1022087103subContentFindTreasure:Canvas;
        private var _285760162textFindDepositIronOre:CustomText;
        private var _1312543519btnFindAdventureShort:StandardButton;
        var _watchers:Array;
        private var _386233209btnFindDepositGoldOre:StandardButton;
        private var _194231143btnFindTreasureMedium:StandardButton;
        private var _1614488572btnFindTreasure:StandardButton;
        var _bindings:Array;
        private var _852795408stateExplorer:State;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function SpecialistPanel()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:397, height:245, childDescriptors:[new UIComponentDescriptor({type:Label, id:"title", stylesFactory:function () : void
                {
                    this.fontWeight = "bold";
                    this.color = 16777215;
                    this.textAlign = "center";
                    this.horizontalCenter = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null};
                }// end function
                }), new UIComponentDescriptor({type:CloseButton, id:"close", stylesFactory:function () : void
                {
                    this.top = "7";
                    this.right = "22";
                    return;
                }// end function
                }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                {
                    this.left = "26";
                    this.right = "24";
                    this.top = "32";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    var _loc_1:String = null;
                    return {styleName:"detailsHeader", height:90, childDescriptors:[new UIComponentDescriptor({type:Text, id:"description", stylesFactory:function () : void
                    {
                        this.left = "80";
                        this.right = "15";
                        this.top = "12";
                        this.bottom = "2";
                        this.color = 16777215;
                        this.fontWeight = "normal";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {selectable:false};
                    }// end function
                    }), new UIComponentDescriptor({type:Frame, id:"specialistFrame", propertiesFactory:function () : Object
                    {
                        return {null:null, x:18, y:10};
                    }// end function
                    })]};
                }// end function
                }), new UIComponentDescriptor({type:Canvas, id:"confirmFooter", stylesFactory:function () : void
                {
                    this.left = "31";
                    this.right = "28";
                    this.bottom = "13";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {childDescriptors:[new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {styleName:"detailsSubHeader", height:18, percentWidth:100, childDescriptors:[new UIComponentDescriptor({type:Label, id:"_SpecialistPanel_Label7", stylesFactory:function () : void
                        {
                            this.top = "1";
                            this.horizontalCenter = "0";
                            this.color = 16777215;
                            this.fontWeight = "bold";
                            return;
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                    {
                        null.left = this;
                        this.right = "1";
                        this.top = "18";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {styleName:"detailsContentBox", height:80, childDescriptors:[new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                        {
                            var _loc_1:String = null;
                            return {styleName:"detailsSubContentBox", percentWidth:100, height:37, childDescriptors:[new UIComponentDescriptor({type:HBox, id:"costsHolder", stylesFactory:function () : void
                            {
                                this.horizontalCenter = "0";
                                this.verticalCenter = "0";
                                this.verticalAlign = "middle";
                                this.horizontalGap = 25;
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {childDescriptors:[new UIComponentDescriptor({type:Label, id:"taskDuration", stylesFactory:function () : void
                                {
                                    this.color = 16777215;
                                    return;
                                }// end function
                                })]};
                            }// end function
                            })]};
                        }// end function
                        }), new UIComponentDescriptor({type:HBox, stylesFactory:function () : void
                        {
                            this.horizontalCenter = "0";
                            this.bottom = "5";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            var _loc_1:String = null;
                            return {childDescriptors:[new UIComponentDescriptor({type:StandardButton, id:"btnOK", propertiesFactory:function () : Object
                            {
                                return {enabled:false, playSound:false, width:70, height:32};
                            }// end function
                            }), new UIComponentDescriptor({type:StandardButton, id:"btnCancel", propertiesFactory:function () : Object
                            {
                                return {null:null, height:32};
                            }// end function
                            })]};
                        }// end function
                        })]};
                    }// end function
                    })]};
                }// end function
                })]};
            }// end function
            });
            this._767257665progressProxy = new ObjectProxy();
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.styleName = "specialPanel";
            this.width = 397;
            this.height = 245;
            this.states = [this._SpecialistPanel_State1_i(), this._SpecialistPanel_State2_i(), this._SpecialistPanel_State3_i()];
            this._SpecialistPanel_Fade1_i();
            this._SpecialistPanel_Fade2_i();
            return;
        }// end function

        public function __btnFindAdventureShort_toolTipCreate(event:ToolTipEvent) : void
        {
            if (this.btnFindAdventureShort.enabled)
            {
                cToolTipUtil.createToolTip(cToolTipUtil.MULTILINE_string, event);
            }
            else
            {
                cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, true);
            }
            return;
        }// end function

        public function get btnFindDepositTitaniumOre() : StandardButton
        {
            return this._29046788btnFindDepositTitaniumOre;
        }// end function

        private function _SpecialistPanel_StandardButton23_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnFindDepositIronOre = _loc_1;
            _loc_1.enabled = false;
            _loc_1.width = 49;
            _loc_1.height = 39;
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "48");
            _loc_1.addEventListener("toolTipCreate", this.__btnFindDepositIronOre_toolTipCreate);
            _loc_1.id = "btnFindDepositIronOre";
            BindingManager.executeBindings(this, "btnFindDepositIronOre", this.btnFindDepositIronOre);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get textFindDepositGoldOre() : CustomText
        {
            return this._1578203126textFindDepositGoldOre;
        }// end function

        private function _SpecialistPanel_Canvas21_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.subContentFindAdventure = _loc_1;
            _loc_1.styleName = "detailsContentBox";
            _loc_1.height = 93;
            _loc_1.visible = false;
            _loc_1.setStyle("left", "32");
            _loc_1.setStyle("right", "29");
            _loc_1.setStyle("top", "142");
            _loc_1.id = "subContentFindAdventure";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_Canvas22_c());
            _loc_1.addChild(this._SpecialistPanel_StandardButton10_i());
            _loc_1.addChild(this._SpecialistPanel_Canvas23_c());
            _loc_1.addChild(this._SpecialistPanel_StandardButton11_i());
            _loc_1.addChild(this._SpecialistPanel_Canvas24_c());
            _loc_1.addChild(this._SpecialistPanel_StandardButton12_i());
            return _loc_1;
        }// end function

        public function get textFindDepositStone() : CustomText
        {
            return this._1496551411textFindDepositStone;
        }// end function

        public function set btnFindDepositTitaniumOre(param1:StandardButton) : void
        {
            var _loc_2:* = this._29046788btnFindDepositTitaniumOre;
            if (_loc_2 !== param1)
            {
                this._29046788btnFindDepositTitaniumOre = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnFindDepositTitaniumOre", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnResetArmyChanges() : StandardButton
        {
            return this._1744270317btnResetArmyChanges;
        }// end function

        public function set textFindDepositGoldOre(param1:CustomText) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1578203126textFindDepositGoldOre;
            if (_loc_2 !== param1)
            {
                this._1578203126textFindDepositGoldOre = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "textFindDepositGoldOre", _loc_2, param1));
            }
            return;
        }// end function

        public function get textFindDepositTitaniumOre() : CustomText
        {
            return this._301308949textFindDepositTitaniumOre;
        }// end function

        public function set btnFindTreasure(param1:StandardButton) : void
        {
            var _loc_2:* = this._1614488572btnFindTreasure;
            if (_loc_2 !== param1)
            {
                this._1614488572btnFindTreasure = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnFindTreasure", _loc_2, param1));
            }
            return;
        }// end function

        public function get textFindAdventureZone() : CustomText
        {
            return this._1279979510textFindAdventureZone;
        }// end function

        private function _SpecialistPanel_Canvas8_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.percentWidth = 100;
            _loc_1.height = 18;
            _loc_1.setStyle("top", "155");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_Label2_i());
            return _loc_1;
        }// end function

        public function set textFindDepositStone(param1:CustomText) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1496551411textFindDepositStone;
            if (_loc_2 !== param1)
            {
                this._1496551411textFindDepositStone = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "textFindDepositStone", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistPanel_CustomText19_i() : CustomText
        {
            var _loc_1:* = new CustomText();
            this.textFindDepositTitaniumOre = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "50");
            _loc_1.setStyle("verticalCenter", "2");
            _loc_1.id = "textFindDepositTitaniumOre";
            BindingManager.executeBindings(this, "textFindDepositTitaniumOre", this.textFindDepositTitaniumOre);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get btnFindTreasure() : StandardButton
        {
            return this._1614488572btnFindTreasure;
        }// end function

        public function set btnFindDepositIronOre(param1:StandardButton) : void
        {
            var _loc_2:* = this._2044770799btnFindDepositIronOre;
            if (_loc_2 !== param1)
            {
                this._2044770799btnFindDepositIronOre = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnFindDepositIronOre", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistPanel_StandardButton11_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnFindAdventureLong = _loc_1;
            _loc_1.width = 49;
            _loc_1.height = 39;
            _loc_1.setStyle("left", "112");
            _loc_1.setStyle("top", "48");
            _loc_1.addEventListener("toolTipCreate", this.__btnFindAdventureLong_toolTipCreate);
            _loc_1.id = "btnFindAdventureLong";
            BindingManager.executeBindings(this, "btnFindAdventureLong", this.btnFindAdventureLong);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get textFindTreasureShort() : CustomText
        {
            return this._1321480231textFindTreasureShort;
        }// end function

        public function set textFindDepositTitaniumOre(param1:CustomText) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._301308949textFindDepositTitaniumOre;
            if (_loc_2 !== param1)
            {
                this._301308949textFindDepositTitaniumOre = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "textFindDepositTitaniumOre", _loc_2, param1));
            }
            return;
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

        public function set textFindAdventureZone(param1:CustomText) : void
        {
            var _loc_2:* = this._1279979510textFindAdventureZone;
            if (_loc_2 !== param1)
            {
                this._1279979510textFindAdventureZone = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "textFindAdventureZone", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistPanel_Canvas32_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.width = 150;
            _loc_1.height = 37;
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("top", "7");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_CustomText16_i());
            return _loc_1;
        }// end function

        private function _SpecialistPanel_State3_i() : State
        {
            var _loc_1:* = new State();
            this.stateGeologist = _loc_1;
            _loc_1.name = "Geologist";
            _loc_1.overrides = [this._SpecialistPanel_SetProperty4_c(), this._SpecialistPanel_AddChild7_c(), this._SpecialistPanel_AddChild8_c()];
            return _loc_1;
        }// end function

        public function set btnResetArmyChanges(param1:StandardButton) : void
        {
            var _loc_2:* = this._1744270317btnResetArmyChanges;
            if (_loc_2 !== param1)
            {
                this._1744270317btnResetArmyChanges = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnResetArmyChanges", _loc_2, param1));
            }
            return;
        }// end function

        public function get subContentFindTreasure() : Canvas
        {
            return this._1022087103subContentFindTreasure;
        }// end function

        private function _SpecialistPanel_StandardButton22_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnFindDepositBronzeOre = _loc_1;
            _loc_1.enabled = false;
            _loc_1.width = 49;
            _loc_1.height = 39;
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "6");
            _loc_1.addEventListener("toolTipCreate", this.__btnFindDepositBronzeOre_toolTipCreate);
            _loc_1.id = "btnFindDepositBronzeOre";
            BindingManager.executeBindings(this, "btnFindDepositBronzeOre", this.btnFindDepositBronzeOre);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistPanel_Canvas20_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.width = 150;
            _loc_1.height = 37;
            _loc_1.verticalScrollPolicy = "off";
            _loc_1.setStyle("right", "13");
            _loc_1.setStyle("top", "49");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_CustomText8_i());
            return _loc_1;
        }// end function

        public function get textFindDepositSalpeter() : CustomText
        {
            return this._1769179066textFindDepositSalpeter;
        }// end function

        private function _SpecialistPanel_HBox1_c() : HBox
        {
            var _loc_1:* = new HBox();
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("bottom", "5");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_StandardButton4_i());
            _loc_1.addChild(this._SpecialistPanel_StandardButton5_i());
            return _loc_1;
        }// end function

        public function get progressProxy() : ObjectProxy
        {
            return this._767257665progressProxy;
        }// end function

        public function __btnFindAdventureMedium_toolTipCreate(event:ToolTipEvent) : void
        {
            if (this.btnFindAdventureMedium.enabled)
            {
                cToolTipUtil.createToolTip(cToolTipUtil.MULTILINE_string, event);
            }
            else
            {
                cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, true);
            }
            return;
        }// end function

        public function set textFindAdventureZoneShort(param1:CustomText) : void
        {
            var _loc_2:* = this._1354575398textFindAdventureZoneShort;
            if (_loc_2 !== param1)
            {
                this._1354575398textFindAdventureZoneShort = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "textFindAdventureZoneShort", _loc_2, param1));
            }
            return;
        }// end function

        public function set textFindTreasureShort(param1:CustomText) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1321480231textFindTreasureShort;
            if (_loc_2 !== param1)
            {
                this._1321480231textFindTreasureShort = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "textFindTreasureShort", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistPanel_AddChild8_c() : AddChild
        {
            var _loc_1:* = new AddChild();
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SpecialistPanel_Canvas31_c);
            return _loc_1;
        }// end function

        private function _SpecialistPanel_Canvas7_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.height = 37;
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("top", "91");
            _loc_1.setStyle("right", "10");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_CustomText3_i());
            return _loc_1;
        }// end function

        public function get btnFindDepositGranite() : StandardButton
        {
            return this._462284889btnFindDepositGranite;
        }// end function

        public function get manageArmyList() : TileList
        {
            return this._1138906016manageArmyList;
        }// end function

        private function _SpecialistPanel_CustomText18_i() : CustomText
        {
            var _loc_1:* = new CustomText();
            this.textFindDepositGoldOre = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "50");
            _loc_1.setStyle("verticalCenter", "2");
            _loc_1.id = "textFindDepositGoldOre";
            BindingManager.executeBindings(this, "textFindDepositGoldOre", this.textFindDepositGoldOre);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistPanel_StandardButton10_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnFindAdventureShort = _loc_1;
            _loc_1.width = 49;
            _loc_1.height = 39;
            _loc_1.setStyle("left", "112");
            _loc_1.setStyle("top", "6");
            _loc_1.addEventListener("toolTipCreate", this.__btnFindAdventureShort_toolTipCreate);
            _loc_1.id = "btnFindAdventureShort";
            BindingManager.executeBindings(this, "btnFindAdventureShort", this.btnFindAdventureShort);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistPanel_Canvas31_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.height = 219;
            _loc_1.setStyle("left", "32");
            _loc_1.setStyle("right", "29");
            _loc_1.setStyle("top", "142");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_Canvas32_c());
            _loc_1.addChild(this._SpecialistPanel_StandardButton17_i());
            _loc_1.addChild(this._SpecialistPanel_Canvas33_c());
            _loc_1.addChild(this._SpecialistPanel_StandardButton18_i());
            _loc_1.addChild(this._SpecialistPanel_Canvas34_c());
            _loc_1.addChild(this._SpecialistPanel_StandardButton19_i());
            _loc_1.addChild(this._SpecialistPanel_Canvas35_c());
            _loc_1.addChild(this._SpecialistPanel_StandardButton20_i());
            _loc_1.addChild(this._SpecialistPanel_Canvas36_c());
            _loc_1.addChild(this._SpecialistPanel_StandardButton21_i());
            _loc_1.addChild(this._SpecialistPanel_Canvas37_c());
            _loc_1.addChild(this._SpecialistPanel_StandardButton22_i());
            _loc_1.addChild(this._SpecialistPanel_Canvas38_c());
            _loc_1.addChild(this._SpecialistPanel_StandardButton23_i());
            _loc_1.addChild(this._SpecialistPanel_Canvas39_c());
            _loc_1.addChild(this._SpecialistPanel_StandardButton24_i());
            _loc_1.addChild(this._SpecialistPanel_Canvas40_c());
            _loc_1.addChild(this._SpecialistPanel_StandardButton25_i());
            return _loc_1;
        }// end function

        public function set progress(param1:ProgressBar) : void
        {
            var _loc_2:* = this._1001078227progress;
            if (_loc_2 !== param1)
            {
                this._1001078227progress = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "progress", _loc_2, param1));
            }
            return;
        }// end function

        public function get subContentExplorerBase() : Canvas
        {
            return this._182970263subContentExplorerBase;
        }// end function

        private function _SpecialistPanel_State2_i() : State
        {
            var _loc_1:* = new State();
            this.stateExplorer = _loc_1;
            _loc_1.name = "Explorer";
            _loc_1.overrides = [this._SpecialistPanel_SetProperty3_c(), this._SpecialistPanel_AddChild3_c(), this._SpecialistPanel_AddChild4_c(), this._SpecialistPanel_AddChild5_c(), this._SpecialistPanel_AddChild6_c()];
            return _loc_1;
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

        public function get confirmFooter() : Canvas
        {
            return this._128157573confirmFooter;
        }// end function

        public function get btnFindAdventure() : StandardButton
        {
            return this._860383323btnFindAdventure;
        }// end function

        public function set btnFindDepositBronzeOre(param1:StandardButton) : void
        {
            var _loc_2:* = this._1876869695btnFindDepositBronzeOre;
            if (_loc_2 !== param1)
            {
                this._1876869695btnFindDepositBronzeOre = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnFindDepositBronzeOre", _loc_2, param1));
            }
            return;
        }// end function

        public function __btnFindDepositCoal_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, !this.btnFindDepositCoal.enabled);
            return;
        }// end function

        public function set subContentFindTreasure(param1:Canvas) : void
        {
            var _loc_2:* = this._1022087103subContentFindTreasure;
            if (_loc_2 !== param1)
            {
                this._1022087103subContentFindTreasure = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "subContentFindTreasure", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistPanel_StandardButton21_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnFindDepositSalpeter = _loc_1;
            _loc_1.enabled = false;
            _loc_1.width = 49;
            _loc_1.height = 39;
            _loc_1.setStyle("left", "112");
            _loc_1.setStyle("top", "174");
            _loc_1.addEventListener("toolTipCreate", this.__btnFindDepositSalpeter_toolTipCreate);
            _loc_1.id = "btnFindDepositSalpeter";
            BindingManager.executeBindings(this, "btnFindDepositSalpeter", this.btnFindDepositSalpeter);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __btnFindAdventure_click(event:MouseEvent) : void
        {
            this.subContentFindAdventure.visible = true;
            this.subContentExplorerBase.visible = false;
            return;
        }// end function

        private function _SpecialistPanel_StandardButton9_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnFindWildZone = _loc_1;
            _loc_1.width = 49;
            _loc_1.height = 39;
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "48");
            _loc_1.addEventListener("toolTipCreate", this.__btnFindWildZone_toolTipCreate);
            _loc_1.id = "btnFindWildZone";
            BindingManager.executeBindings(this, "btnFindWildZone", this.btnFindWildZone);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistPanel_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function ()
            {
                return fadeIn;
            }// end function
            , function (param1) : void
            {
                this.setStyle("showEffect", param1);
                return;
            }// end function
            , "this.showEffect");
            result[0] = binding;
            binding = new Binding(this, function ()
            {
                return fadeOut;
            }// end function
            , function (param1) : void
            {
                null.setStyle(this, param1);
                return;
            }// end function
            , "this.hideEffect");
            result[1] = binding;
            binding = new Binding(this, function () : DisplayObject
            {
                return confirmFooter;
            }// end function
            , function (param1:DisplayObject) : void
            {
                null.target = null;
                return;
            }// end function
            , "_SpecialistPanel_RemoveChild1.target");
            result[2] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "Commands");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "_SpecialistPanel_Label1.text");
            result[3] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Attack");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "_SpecialistPanel_CustomText1.text");
            result[4] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnAttack.icon");
            result[5] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Attack");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.toolTip = null;
                return;
            }// end function
            , "btnAttack.toolTip");
            result[6] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Transfer");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "_SpecialistPanel_CustomText2.text");
            result[7] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ButtonIconTrumpet");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnTransfer.icon");
            result[8] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "Transfer");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.toolTip = param1;
                return;
            }// end function
            , "btnTransfer.toolTip");
            result[9] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "Retreat");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "_SpecialistPanel_CustomText3.text");
            result[10] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ButtonIconFlag");
            }// end function
            , function (param1:Class) : void
            {
                btnRetreat.setStyle("icon", param1);
                return;
            }// end function
            , "btnRetreat.icon");
            result[11] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "Retreat");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.toolTip = null;
                return;
            }// end function
            , "btnRetreat.toolTip");
            result[12] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "CurrentMission");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "_SpecialistPanel_Label2.text");
            result[13] = binding;
            binding = new Binding(this, function () : Number
            {
                return progressProxy.progress;
            }// end function
            , function (param1:Number) : void
            {
                null.value = null;
                return;
            }// end function
            , "progress.value");
            result[14] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "OK");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                btnCommitArmyChanges.label = param1;
                return;
            }// end function
            , "btnCommitArmyChanges.label");
            result[15] = binding;
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
            , "btnResetArmyChanges.label");
            result[16] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Commands");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _SpecialistPanel_Label4.text = param1;
                return;
            }// end function
            , "_SpecialistPanel_Label4.text");
            result[17] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "ExploreSector");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "textExploreSector.text");
            result[18] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ButtonIconExploreSector");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnExploreSector.icon");
            result[19] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindTreasure");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "textFindTreasure.text");
            result[20] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ButtonIconFindTreasure");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("icon", param1);
                return;
            }// end function
            , "btnFindTreasure.icon");
            result[21] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindTreasure");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                btnFindTreasure.toolTip = param1;
                return;
            }// end function
            , "btnFindTreasure.toolTip");
            result[22] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindAdventure");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "textFindAdventureZone.text");
            result[23] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("icon", param1);
                return;
            }// end function
            , "btnFindAdventure.icon");
            result[24] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "FindAdventure");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.toolTip = null;
                return;
            }// end function
            , "btnFindAdventure.toolTip");
            result[25] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindWildZone");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "textFindWildZone.text");
            result[26] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ButtonIconFindWildZone");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnFindWildZone.icon");
            result[27] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "FindAdventureShort");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "textFindAdventureZoneShort.text");
            result[28] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ButtonIconTaskShort");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnFindAdventureShort.icon");
            result[29] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindAdventureLong");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                textFindAdventureZoneLong.text = param1;
                return;
            }// end function
            , "textFindAdventureZoneLong.text");
            result[30] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ButtonIconTaskLong");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("icon", param1);
                return;
            }// end function
            , "btnFindAdventureLong.icon");
            result[31] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "FindAdventureMedium");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "textFindAdventureZoneMedium.text");
            result[32] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ButtonIconTaskMedium");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("icon", param1);
                return;
            }// end function
            , "btnFindAdventureMedium.icon");
            result[33] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindTreasureShort");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                textFindTreasureShort.text = param1;
                return;
            }// end function
            , "textFindTreasureShort.text");
            result[34] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                btnFindTreasureShort.setStyle("icon", param1);
                return;
            }// end function
            , "btnFindTreasureShort.icon");
            result[35] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "FindTreasureLong");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "textFindTreasureLong.text");
            result[36] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("icon", param1);
                return;
            }// end function
            , "btnFindTreasureLong.icon");
            result[37] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "FindTreasureMedium");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "textFindTreasureMedium.text");
            result[38] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ButtonIconTaskMedium");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("icon", param1);
                return;
            }// end function
            , "btnFindTreasureMedium.icon");
            result[39] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindTreasureEvenLonger");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                textFindTreasureEvenLonger.text = param1;
                return;
            }// end function
            , "textFindTreasureEvenLonger.text");
            result[40] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ButtonIconTaskEvenLonger");
            }// end function
            , function (param1:Class) : void
            {
                btnFindTreasureEvenLonger.setStyle("icon", param1);
                return;
            }// end function
            , "btnFindTreasureEvenLonger.icon");
            result[41] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Commands");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _SpecialistPanel_Label5.text = param1;
                return;
            }// end function
            , "_SpecialistPanel_Label5.text");
            result[42] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "FindDepositStone");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "textFindDepositStone.text");
            result[43] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ButtonIconStone");
            }// end function
            , function (param1:Class) : void
            {
                btnFindDepositStone.setStyle("icon", param1);
                return;
            }// end function
            , "btnFindDepositStone.icon");
            result[44] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "FindDepositMarble");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                textFindDepositMarble.text = param1;
                return;
            }// end function
            , "textFindDepositMarble.text");
            result[45] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ButtonIconMarble");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("icon", param1);
                return;
            }// end function
            , "btnFindDepositMarble.icon");
            result[46] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "FindDepositGold");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                textFindDepositGoldOre.text = param1;
                return;
            }// end function
            , "textFindDepositGoldOre.text");
            result[47] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ButtonIconGold");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("icon", param1);
                return;
            }// end function
            , "btnFindDepositGoldOre.icon");
            result[48] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "FindDepositAlloy");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "textFindDepositTitaniumOre.text");
            result[49] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnFindDepositTitaniumOre.icon");
            result[50] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "FindDepositSalpeter");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "textFindDepositSalpeter.text");
            result[51] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ButtonIconSalpeter");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnFindDepositSalpeter.icon");
            result[52] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "FindDepositBronze");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                textFindDepositBronzeOre.text = param1;
                return;
            }// end function
            , "textFindDepositBronzeOre.text");
            result[53] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ButtonIconBronze");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("icon", param1);
                return;
            }// end function
            , "btnFindDepositBronzeOre.icon");
            result[54] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "FindDepositIron");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                textFindDepositIronOre.text = param1;
                return;
            }// end function
            , "textFindDepositIronOre.text");
            result[55] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ButtonIconIron");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnFindDepositIronOre.icon");
            result[56] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "FindDepositCoal");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                textFindDepositCoal.text = param1;
                return;
            }// end function
            , "textFindDepositCoal.text");
            result[57] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ButtonIconCoal");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("icon", param1);
                return;
            }// end function
            , "btnFindDepositCoal.icon");
            result[58] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "FindDepositGranite");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "textFindDepositGranite.text");
            result[59] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                btnFindDepositGranite.setStyle("icon", param1);
                return;
            }// end function
            , "btnFindDepositGranite.icon");
            result[60] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "CostsDuration");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "_SpecialistPanel_Label7.text");
            result[61] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "OK");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnOK.label");
            result[62] = binding;
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
            , "btnCancel.label");
            result[63] = binding;
            return result;
        }// end function

        public function set textFindDepositSalpeter(param1:CustomText) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1769179066textFindDepositSalpeter;
            if (_loc_2 !== param1)
            {
                this._1769179066textFindDepositSalpeter = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "textFindDepositSalpeter", _loc_2, param1));
            }
            return;
        }// end function

        public function set progressProxy(param1:ObjectProxy) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._767257665progressProxy;
            if (_loc_2 !== param1)
            {
                this._767257665progressProxy = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "progressProxy", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistPanel_AddChild7_c() : AddChild
        {
            var _loc_1:* = new AddChild();
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SpecialistPanel_Canvas30_c);
            return _loc_1;
        }// end function

        private function _SpecialistPanel_Canvas6_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.height = 37;
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("top", "49");
            _loc_1.setStyle("right", "10");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_CustomText2_i());
            return _loc_1;
        }// end function

        private function _SpecialistPanel_CustomText17_i() : CustomText
        {
            var _loc_1:* = new CustomText();
            this.textFindDepositMarble = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "50");
            _loc_1.setStyle("verticalCenter", "2");
            _loc_1.id = "textFindDepositMarble";
            BindingManager.executeBindings(this, "textFindDepositMarble", this.textFindDepositMarble);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get textFindDepositMarble() : CustomText
        {
            return this._662302869textFindDepositMarble;
        }// end function

        public function __btnFindDepositGoldOre_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, !this.btnFindDepositGoldOre.enabled);
            return;
        }// end function

        private function _SpecialistPanel_Canvas30_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.height = 18;
            _loc_1.setStyle("left", "31");
            _loc_1.setStyle("right", "28");
            _loc_1.setStyle("top", "124");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_Label5_i());
            return _loc_1;
        }// end function

        public function get btnFindTreasureLong() : StandardButton
        {
            return this._978547872btnFindTreasureLong;
        }// end function

        public function get btnFindTreasureMedium() : StandardButton
        {
            return this._194231143btnFindTreasureMedium;
        }// end function

        private function _SpecialistPanel_RemoveChild1_i() : RemoveChild
        {
            var _loc_1:* = new RemoveChild();
            this._SpecialistPanel_RemoveChild1 = _loc_1;
            BindingManager.executeBindings(this, "_SpecialistPanel_RemoveChild1", this._SpecialistPanel_RemoveChild1);
            return _loc_1;
        }// end function

        public function set title(param1:Label) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._110371416title;
            if (_loc_2 !== param1)
            {
                this._110371416title = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "title", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnFindDepositGranite(param1:StandardButton) : void
        {
            var _loc_2:* = this._462284889btnFindDepositGranite;
            if (_loc_2 !== param1)
            {
                this._462284889btnFindDepositGranite = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnFindDepositGranite", _loc_2, param1));
            }
            return;
        }// end function

        public function get generalBusyAnim() : SpriteLibAnimation
        {
            return this._201201486generalBusyAnim;
        }// end function

        private function _SpecialistPanel_CustomText9_i() : CustomText
        {
            var _loc_1:* = new CustomText();
            this.textFindAdventureZoneShort = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "47");
            _loc_1.setStyle("verticalCenter", "2");
            _loc_1.id = "textFindAdventureZoneShort";
            BindingManager.executeBindings(this, "textFindAdventureZoneShort", this.textFindAdventureZoneShort);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistPanel_State1_i() : State
        {
            var _loc_1:* = new State();
            this.stateGeneral = _loc_1;
            _loc_1.name = "General";
            _loc_1.overrides = [this._SpecialistPanel_SetProperty1_c(), this._SpecialistPanel_SetProperty2_c(), this._SpecialistPanel_RemoveChild1_i(), this._SpecialistPanel_AddChild1_c(), this._SpecialistPanel_AddChild2_c()];
            return _loc_1;
        }// end function

        private function _SpecialistPanel_ClassFactory1_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = ManageArmyItemRenderer;
            return _loc_1;
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

        public function get fadeIn() : Fade
        {
            return this._1282133823fadeIn;
        }// end function

        private function _SpecialistPanel_StandardButton20_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnFindDepositTitaniumOre = _loc_1;
            _loc_1.enabled = false;
            _loc_1.width = 49;
            _loc_1.height = 39;
            _loc_1.setStyle("left", "112");
            _loc_1.setStyle("top", "132");
            _loc_1.addEventListener("toolTipCreate", this.__btnFindDepositTitaniumOre_toolTipCreate);
            _loc_1.id = "btnFindDepositTitaniumOre";
            BindingManager.executeBindings(this, "btnFindDepositTitaniumOre", this.btnFindDepositTitaniumOre);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set btnFindAdventure(param1:StandardButton) : void
        {
            var _loc_2:* = this._860383323btnFindAdventure;
            if (_loc_2 !== param1)
            {
                this._860383323btnFindAdventure = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnFindAdventure", _loc_2, param1));
            }
            return;
        }// end function

        public function __btnExploreSector_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, !this.btnExploreSector.enabled);
            return;
        }// end function

        public function set btnTransfer(param1:StandardButton) : void
        {
            var _loc_2:* = this._1234272665btnTransfer;
            if (_loc_2 !== param1)
            {
                this._1234272665btnTransfer = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnTransfer", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistPanel_StandardButton8_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnFindAdventure = _loc_1;
            _loc_1.width = 49;
            _loc_1.height = 39;
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "6");
            _loc_1.addEventListener("toolTipCreate", this.__btnFindAdventure_toolTipCreate);
            _loc_1.addEventListener("click", this.__btnFindAdventure_click);
            _loc_1.id = "btnFindAdventure";
            BindingManager.executeBindings(this, "btnFindAdventure", this.btnFindAdventure);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set subContentExplorerBase(param1:Canvas) : void
        {
            var _loc_2:* = this._182970263subContentExplorerBase;
            if (_loc_2 !== param1)
            {
                this._182970263subContentExplorerBase = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "subContentExplorerBase", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistPanel_Canvas5_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.height = 37;
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("top", "7");
            _loc_1.setStyle("right", "10");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_CustomText1_i());
            return _loc_1;
        }// end function

        private function _SpecialistPanel_CustomText16_i() : CustomText
        {
            var _loc_1:* = new CustomText();
            this.textFindDepositStone = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "50");
            _loc_1.setStyle("verticalCenter", "2");
            _loc_1.id = "textFindDepositStone";
            BindingManager.executeBindings(this, "textFindDepositStone", this.textFindDepositStone);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __fadeOut_effectEnd(event:EffectEvent) : void
        {
            globalFlash.gui.ShowQuestWindowDelayed();
            return;
        }// end function

        public function __btnFindDepositBronzeOre_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, !this.btnFindDepositBronzeOre.enabled);
            return;
        }// end function

        public function get btnFindAdventureShort() : StandardButton
        {
            return this._1312543519btnFindAdventureShort;
        }// end function

        private function _SpecialistPanel_AddChild6_c() : AddChild
        {
            var _loc_1:* = new AddChild();
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SpecialistPanel_Canvas25_i);
            return _loc_1;
        }// end function

        public function get textFindDepositGranite() : CustomText
        {
            return this._1502151446textFindDepositGranite;
        }// end function

        public function get textFindDepositCoal() : CustomText
        {
            return this._880041745textFindDepositCoal;
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

        private function _SpecialistPanel_CustomText8_i() : CustomText
        {
            var _loc_1:* = new CustomText();
            this.textFindWildZone = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "47");
            _loc_1.setStyle("verticalCenter", "2");
            _loc_1.id = "textFindWildZone";
            BindingManager.executeBindings(this, "textFindWildZone", this.textFindWildZone);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistPanel_TileList1_i() : TileList
        {
            var _loc_1:* = new TileList();
            this.manageArmyList = _loc_1;
            _loc_1.itemRenderer = this._SpecialistPanel_ClassFactory1_c();
            _loc_1.selectable = false;
            _loc_1.setStyle("backgroundAlpha", 0);
            _loc_1.setStyle("borderThickness", 0);
            _loc_1.setStyle("left", "6");
            _loc_1.setStyle("right", "3");
            _loc_1.setStyle("top", "4");
            _loc_1.setStyle("bottom", "0");
            _loc_1.setStyle("useRollOver", false);
            _loc_1.id = "manageArmyList";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistPanel_StandardButton7_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnFindTreasure = _loc_1;
            _loc_1.width = 49;
            _loc_1.height = 39;
            _loc_1.setStyle("left", "112");
            _loc_1.setStyle("top", "48");
            _loc_1.addEventListener("toolTipCreate", this.__btnFindTreasure_toolTipCreate);
            _loc_1.addEventListener("click", this.__btnFindTreasure_click);
            _loc_1.id = "btnFindTreasure";
            BindingManager.executeBindings(this, "btnFindTreasure", this.btnFindTreasure);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistPanel_Canvas40_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.width = 150;
            _loc_1.height = 37;
            _loc_1.setStyle("right", "13");
            _loc_1.setStyle("top", "133");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_CustomText24_i());
            return _loc_1;
        }// end function

        public function get btnFindTreasureEvenLonger() : StandardButton
        {
            return this._101681415btnFindTreasureEvenLonger;
        }// end function

        private function _SpecialistPanel_AddChild5_c() : AddChild
        {
            var _loc_1:* = new AddChild();
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SpecialistPanel_Canvas21_i);
            return _loc_1;
        }// end function

        public function set generalRightColumn(param1:Canvas) : void
        {
            var _loc_2:* = this._1398146422generalRightColumn;
            if (_loc_2 !== param1)
            {
                this._1398146422generalRightColumn = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "generalRightColumn", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistPanel_Canvas4_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.height = 135;
            _loc_1.setStyle("left", "1");
            _loc_1.setStyle("right", "1");
            _loc_1.setStyle("top", "18");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_Canvas5_c());
            _loc_1.addChild(this._SpecialistPanel_StandardButton1_i());
            _loc_1.addChild(this._SpecialistPanel_Canvas6_c());
            _loc_1.addChild(this._SpecialistPanel_StandardButton2_i());
            _loc_1.addChild(this._SpecialistPanel_Canvas7_c());
            _loc_1.addChild(this._SpecialistPanel_StandardButton3_i());
            return _loc_1;
        }// end function

        private function _SpecialistPanel_CustomText15_i() : CustomText
        {
            var _loc_1:* = new CustomText();
            this.textFindTreasureEvenLonger = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "47");
            _loc_1.setStyle("verticalCenter", "2");
            _loc_1.id = "textFindTreasureEvenLonger";
            BindingManager.executeBindings(this, "textFindTreasureEvenLonger", this.textFindTreasureEvenLonger);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get textFindTreasureEvenLonger() : CustomText
        {
            return this._373943576textFindTreasureEvenLonger;
        }// end function

        public function set textFindDepositBronzeOre(param1:CustomText) : void
        {
            var _loc_2:* = this._455805296textFindDepositBronzeOre;
            if (_loc_2 !== param1)
            {
                this._455805296textFindDepositBronzeOre = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "textFindDepositBronzeOre", _loc_2, param1));
            }
            return;
        }// end function

        public function set textFindDepositMarble(param1:CustomText) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._662302869textFindDepositMarble;
            if (_loc_2 !== param1)
            {
                this._662302869textFindDepositMarble = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "textFindDepositMarble", _loc_2, param1));
            }
            return;
        }// end function

        public function __btnRetreat_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function __btnFindDepositIronOre_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, !this.btnFindDepositIronOre.enabled);
            return;
        }// end function

        private function _SpecialistPanel_CustomText7_i() : CustomText
        {
            var _loc_1:* = new CustomText();
            this.textFindAdventureZone = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "47");
            _loc_1.setStyle("verticalCenter", "2");
            _loc_1.id = "textFindAdventureZone";
            BindingManager.executeBindings(this, "textFindAdventureZone", this.textFindAdventureZone);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set btnFindTreasureMedium(param1:StandardButton) : void
        {
            var _loc_2:* = this._194231143btnFindTreasureMedium;
            if (_loc_2 !== param1)
            {
                this._194231143btnFindTreasureMedium = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnFindTreasureMedium", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnOK() : StandardButton
        {
            return this._94069048btnOK;
        }// end function

        public function set btnFindTreasureLong(param1:StandardButton) : void
        {
            var _loc_2:* = this._978547872btnFindTreasureLong;
            if (_loc_2 !== param1)
            {
                this._978547872btnFindTreasureLong = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnFindTreasureLong", _loc_2, param1));
            }
            return;
        }// end function

        public function get textFindTreasureMedium() : CustomText
        {
            return this._2136299818textFindTreasureMedium;
        }// end function

        public function set currentTask(param1:CustomText) : void
        {
            var _loc_2:* = this._601227934currentTask;
            if (_loc_2 !== param1)
            {
                this._601227934currentTask = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "currentTask", _loc_2, param1));
            }
            return;
        }// end function

        public function set textFindDepositIronOre(param1:CustomText) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._285760162textFindDepositIronOre;
            if (_loc_2 !== param1)
            {
                this._285760162textFindDepositIronOre = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "textFindDepositIronOre", _loc_2, param1));
            }
            return;
        }// end function

        public function get generalLeftColumn() : Canvas
        {
            return this._162733755generalLeftColumn;
        }// end function

        private function _SpecialistPanel_StandardButton6_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnExploreSector = _loc_1;
            _loc_1.width = 49;
            _loc_1.height = 39;
            _loc_1.setStyle("left", "112");
            _loc_1.setStyle("top", "6");
            _loc_1.addEventListener("toolTipCreate", this.__btnExploreSector_toolTipCreate);
            _loc_1.id = "btnExploreSector";
            BindingManager.executeBindings(this, "btnExploreSector", this.btnExploreSector);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get textFindWildZone() : CustomText
        {
            return this._1771381052textFindWildZone;
        }// end function

        private function _SpecialistPanel_AddChild4_c() : AddChild
        {
            var _loc_1:* = new AddChild();
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SpecialistPanel_Canvas16_i);
            return _loc_1;
        }// end function

        private function _SpecialistPanel_Canvas3_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.percentWidth = 100;
            _loc_1.height = 18;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_Label1_i());
            return _loc_1;
        }// end function

        public function get textFindTreasure() : CustomText
        {
            return this._33091925textFindTreasure;
        }// end function

        private function _SpecialistPanel_CustomText14_i() : CustomText
        {
            var _loc_1:* = new CustomText();
            this.textFindTreasureMedium = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "47");
            _loc_1.setStyle("verticalCenter", "2");
            _loc_1.id = "textFindTreasureMedium";
            BindingManager.executeBindings(this, "textFindTreasureMedium", this.textFindTreasureMedium);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set generalBusyAnim(param1:SpriteLibAnimation) : void
        {
            var _loc_2:* = this._201201486generalBusyAnim;
            if (_loc_2 !== param1)
            {
                this._201201486generalBusyAnim = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "generalBusyAnim", _loc_2, param1));
            }
            return;
        }// end function

        public function __btnFindDepositMarble_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, !this.btnFindDepositMarble.enabled);
            return;
        }// end function

        public function get textFindTreasureLong() : CustomText
        {
            return this._1897236111textFindTreasureLong;
        }// end function

        public function set btnFindDepositSalpeter(param1:StandardButton) : void
        {
            var _loc_2:* = this._1001194825btnFindDepositSalpeter;
            if (_loc_2 !== param1)
            {
                this._1001194825btnFindDepositSalpeter = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnFindDepositSalpeter", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistPanel_CustomText6_i() : CustomText
        {
            var _loc_1:* = new CustomText();
            this.textFindTreasure = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "47");
            _loc_1.setStyle("verticalCenter", "2");
            _loc_1.id = "textFindTreasure";
            BindingManager.executeBindings(this, "textFindTreasure", this.textFindTreasure);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __btnFindTreasureShort_toolTipCreate(event:ToolTipEvent) : void
        {
            if (this.btnFindTreasureShort.enabled)
            {
                cToolTipUtil.createToolTip(cToolTipUtil.MULTILINE_string, event);
            }
            else
            {
                cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, true);
            }
            return;
        }// end function

        public function __btnFindDepositGranite_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, !this.btnFindDepositGranite.enabled);
            return;
        }// end function

        public function set specialistFrame(param1:Frame) : void
        {
            var _loc_2:* = this._1723375940specialistFrame;
            if (_loc_2 !== param1)
            {
                this._1723375940specialistFrame = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "specialistFrame", _loc_2, param1));
            }
            return;
        }// end function

        public function __btnFindTreasureLong_toolTipCreate(event:ToolTipEvent) : void
        {
            if (this.btnFindTreasureLong.enabled)
            {
                cToolTipUtil.createToolTip(cToolTipUtil.MULTILINE_string, event);
            }
            else
            {
                cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, true);
            }
            return;
        }// end function

        public function set fadeIn(param1:Fade) : void
        {
            var _loc_2:* = this._1282133823fadeIn;
            if (_loc_2 !== param1)
            {
                this._1282133823fadeIn = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "fadeIn", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistPanel_StandardButton5_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnResetArmyChanges = _loc_1;
            _loc_1.enabled = false;
            _loc_1.width = 70;
            _loc_1.height = 32;
            _loc_1.id = "btnResetArmyChanges";
            BindingManager.executeBindings(this, "btnResetArmyChanges", this.btnResetArmyChanges);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get btnFindAdventureLong() : StandardButton
        {
            return this._234552695btnFindAdventureLong;
        }// end function

        private function _SpecialistPanel_AddChild3_c() : AddChild
        {
            var _loc_1:* = new AddChild();
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SpecialistPanel_Canvas15_c);
            return _loc_1;
        }// end function

        private function _SpecialistPanel_CustomText13_i() : CustomText
        {
            var _loc_1:* = new CustomText();
            this.textFindTreasureLong = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "47");
            _loc_1.setStyle("verticalCenter", "2");
            _loc_1.id = "textFindTreasureLong";
            BindingManager.executeBindings(this, "textFindTreasureLong", this.textFindTreasureLong);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistPanel_Canvas2_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.generalLeftColumn = _loc_1;
            _loc_1.width = 155;
            _loc_1.setStyle("left", "31");
            _loc_1.setStyle("top", "124");
            _loc_1.id = "generalLeftColumn";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_Canvas3_c());
            _loc_1.addChild(this._SpecialistPanel_Canvas4_c());
            _loc_1.addChild(this._SpecialistPanel_Canvas8_c());
            _loc_1.addChild(this._SpecialistPanel_Canvas9_c());
            return _loc_1;
        }// end function

        public function __btnFindWildZone_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, !this.btnFindWildZone.enabled);
            return;
        }// end function

        public function __btnAttack_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function __btnFindTreasure_click(event:MouseEvent) : void
        {
            this.subContentFindTreasure.visible = true;
            this.subContentExplorerBase.visible = false;
            return;
        }// end function

        public function __btnFindTreasureEvenLonger_toolTipCreate(event:ToolTipEvent) : void
        {
            if (this.btnFindTreasureEvenLonger.enabled)
            {
                cToolTipUtil.createToolTip(cToolTipUtil.MULTILINE_string, event);
            }
            else
            {
                cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, true);
            }
            return;
        }// end function

        private function _SpecialistPanel_Canvas19_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.width = 150;
            _loc_1.height = 37;
            _loc_1.verticalScrollPolicy = "off";
            _loc_1.setStyle("right", "13");
            _loc_1.setStyle("top", "7");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_CustomText7_i());
            return _loc_1;
        }// end function

        public function set btnFindTreasureShort(param1:StandardButton) : void
        {
            var _loc_2:* = this._276470488btnFindTreasureShort;
            if (_loc_2 !== param1)
            {
                this._276470488btnFindTreasureShort = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnFindTreasureShort", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnCommitArmyChanges() : StandardButton
        {
            return this._1564391859btnCommitArmyChanges;
        }// end function

        private function _SpecialistPanel_CustomText24_i() : CustomText
        {
            var _loc_1:* = new CustomText();
            this.textFindDepositGranite = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "50");
            _loc_1.setStyle("verticalCenter", "2");
            _loc_1.id = "textFindDepositGranite";
            BindingManager.executeBindings(this, "textFindDepositGranite", this.textFindDepositGranite);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistPanel_CustomText5_i() : CustomText
        {
            var _loc_1:* = new CustomText();
            this.textExploreSector = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "47");
            _loc_1.setStyle("verticalCenter", "2");
            _loc_1.id = "textExploreSector";
            BindingManager.executeBindings(this, "textExploreSector", this.textExploreSector);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set btnExploreSector(param1:StandardButton) : void
        {
            var _loc_2:* = this._878160605btnExploreSector;
            if (_loc_2 !== param1)
            {
                this._878160605btnExploreSector = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnExploreSector", _loc_2, param1));
            }
            return;
        }// end function

        public function __btnFindAdventure_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, !this.btnFindAdventure.enabled);
            return;
        }// end function

        public function set btnFindAdventureShort(param1:StandardButton) : void
        {
            var _loc_2:* = this._1312543519btnFindAdventureShort;
            if (_loc_2 !== param1)
            {
                this._1312543519btnFindAdventureShort = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnFindAdventureShort", _loc_2, param1));
            }
            return;
        }// end function

        public function __btnFindTreasureMedium_toolTipCreate(event:ToolTipEvent) : void
        {
            if (this.btnFindTreasureMedium.enabled)
            {
                cToolTipUtil.createToolTip(cToolTipUtil.MULTILINE_string, event);
            }
            else
            {
                cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, true);
            }
            return;
        }// end function

        private function _SpecialistPanel_StandardButton4_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnCommitArmyChanges = _loc_1;
            _loc_1.enabled = false;
            _loc_1.width = 70;
            _loc_1.height = 32;
            _loc_1.id = "btnCommitArmyChanges";
            BindingManager.executeBindings(this, "btnCommitArmyChanges", this.btnCommitArmyChanges);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistPanel_AddChild2_c() : AddChild
        {
            var _loc_1:* = new AddChild();
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SpecialistPanel_Canvas10_i);
            return _loc_1;
        }// end function

        private function _SpecialistPanel_CustomText12_i() : CustomText
        {
            var _loc_1:* = new CustomText();
            this.textFindTreasureShort = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "47");
            _loc_1.setStyle("verticalCenter", "2");
            _loc_1.id = "textFindTreasureShort";
            BindingManager.executeBindings(this, "textFindTreasureShort", this.textFindTreasureShort);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __btnFindAdventureLong_toolTipCreate(event:ToolTipEvent) : void
        {
            if (this.btnFindAdventureLong.enabled)
            {
                cToolTipUtil.createToolTip(cToolTipUtil.MULTILINE_string, event);
            }
            else
            {
                cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, true);
            }
            return;
        }// end function

        public function set textFindDepositGranite(param1:CustomText) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1502151446textFindDepositGranite;
            if (_loc_2 !== param1)
            {
                this._1502151446textFindDepositGranite = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "textFindDepositGranite", _loc_2, param1));
            }
            return;
        }// end function

        public function set textFindDepositCoal(param1:CustomText) : void
        {
            var _loc_2:* = this._880041745textFindDepositCoal;
            if (_loc_2 !== param1)
            {
                this._880041745textFindDepositCoal = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "textFindDepositCoal", _loc_2, param1));
            }
            return;
        }// end function

        public function __btnFindTreasure_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, !this.btnFindTreasure.enabled);
            return;
        }// end function

        public function __btnFindDepositTitaniumOre_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, !this.btnFindDepositTitaniumOre.enabled);
            return;
        }// end function

        private function _SpecialistPanel_Canvas18_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.width = 150;
            _loc_1.height = 37;
            _loc_1.verticalScrollPolicy = "off";
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("top", "49");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_CustomText6_i());
            return _loc_1;
        }// end function

        private function _SpecialistPanel_CustomText23_i() : CustomText
        {
            var _loc_1:* = new CustomText();
            this.textFindDepositCoal = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "50");
            _loc_1.setStyle("verticalCenter", "2");
            _loc_1.id = "textFindDepositCoal";
            BindingManager.executeBindings(this, "textFindDepositCoal", this.textFindDepositCoal);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistPanel_CustomText4_i() : CustomText
        {
            var _loc_1:* = new CustomText();
            this.currentTask = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("top", "10");
            _loc_1.setStyle("color", 16777215);
            _loc_1.id = "currentTask";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get close() : CloseButton
        {
            return this._94756344close;
        }// end function

        public function set generalBusy(param1:Canvas) : void
        {
            var _loc_2:* = this._878320385generalBusy;
            if (_loc_2 !== param1)
            {
                this._878320385generalBusy = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "generalBusy", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistPanel_StandardButton3_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnRetreat = _loc_1;
            _loc_1.playSound = false;
            _loc_1.enabled = false;
            _loc_1.width = 49;
            _loc_1.height = 39;
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "90");
            _loc_1.addEventListener("toolTipCreate", this.__btnRetreat_toolTipCreate);
            _loc_1.id = "btnRetreat";
            BindingManager.executeBindings(this, "btnRetreat", this.btnRetreat);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistPanel_Canvas29_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.width = 150;
            _loc_1.height = 37;
            _loc_1.verticalScrollPolicy = "off";
            _loc_1.setStyle("right", "13");
            _loc_1.setStyle("top", "49");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_CustomText15_i());
            return _loc_1;
        }// end function

        private function _SpecialistPanel_AddChild1_c() : AddChild
        {
            var _loc_1:* = new AddChild();
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._SpecialistPanel_Canvas2_i);
            return _loc_1;
        }// end function

        public function get btnFindDepositIronOre() : StandardButton
        {
            return this._2044770799btnFindDepositIronOre;
        }// end function

        public function get manageUnitsAmountLabel() : Label
        {
            return this._867684882manageUnitsAmountLabel;
        }// end function

        private function _SpecialistPanel_CustomText11_i() : CustomText
        {
            var _loc_1:* = new CustomText();
            this.textFindAdventureZoneMedium = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "47");
            _loc_1.setStyle("verticalCenter", "2");
            _loc_1.id = "textFindAdventureZoneMedium";
            BindingManager.executeBindings(this, "textFindAdventureZoneMedium", this.textFindAdventureZoneMedium);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set btnFindTreasureEvenLonger(param1:StandardButton) : void
        {
            var _loc_2:* = this._101681415btnFindTreasureEvenLonger;
            if (_loc_2 !== param1)
            {
                this._101681415btnFindTreasureEvenLonger = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnFindTreasureEvenLonger", _loc_2, param1));
            }
            return;
        }// end function

        public function set textFindAdventureZoneMedium(param1:CustomText) : void
        {
            var _loc_2:* = this._1132717301textFindAdventureZoneMedium;
            if (_loc_2 !== param1)
            {
                this._1132717301textFindAdventureZoneMedium = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "textFindAdventureZoneMedium", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistPanel_SetProperty4_c() : SetProperty
        {
            var _loc_1:* = new SetProperty();
            _loc_1.name = "height";
            _loc_1.value = 474;
            return _loc_1;
        }// end function

        private function _SpecialistPanel_Canvas17_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.width = 150;
            _loc_1.height = 37;
            _loc_1.verticalScrollPolicy = "off";
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("top", "7");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_CustomText5_i());
            return _loc_1;
        }// end function

        public function set stateGeneral(param1:State) : void
        {
            var _loc_2:* = this._93112087stateGeneral;
            if (_loc_2 !== param1)
            {
                this._93112087stateGeneral = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "stateGeneral", _loc_2, param1));
            }
            return;
        }// end function

        public function set textFindTreasureEvenLonger(param1:CustomText) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._373943576textFindTreasureEvenLonger;
            if (_loc_2 !== param1)
            {
                this._373943576textFindTreasureEvenLonger = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "textFindTreasureEvenLonger", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistPanel_CustomText22_i() : CustomText
        {
            var _loc_1:* = new CustomText();
            this.textFindDepositIronOre = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "50");
            _loc_1.setStyle("verticalCenter", "2");
            _loc_1.id = "textFindDepositIronOre";
            BindingManager.executeBindings(this, "textFindDepositIronOre", this.textFindDepositIronOre);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistPanel_CustomText3_i() : CustomText
        {
            var _loc_1:* = new CustomText();
            this._SpecialistPanel_CustomText3 = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "50");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "_SpecialistPanel_CustomText3";
            BindingManager.executeBindings(this, "_SpecialistPanel_CustomText3", this._SpecialistPanel_CustomText3);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get textFindAdventureZoneShort() : CustomText
        {
            return this._1354575398textFindAdventureZoneShort;
        }// end function

        public function get taskDuration() : Label
        {
            return this._702386745taskDuration;
        }// end function

        private function _SpecialistPanel_StandardButton19_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnFindDepositGoldOre = _loc_1;
            _loc_1.enabled = false;
            _loc_1.width = 49;
            _loc_1.height = 39;
            _loc_1.setStyle("left", "112");
            _loc_1.setStyle("top", "90");
            _loc_1.addEventListener("toolTipCreate", this.__btnFindDepositGoldOre_toolTipCreate);
            _loc_1.id = "btnFindDepositGoldOre";
            BindingManager.executeBindings(this, "btnFindDepositGoldOre", this.btnFindDepositGoldOre);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get progress() : ProgressBar
        {
            return this._1001078227progress;
        }// end function

        public function get btnFindDepositBronzeOre() : StandardButton
        {
            return this._1876869695btnFindDepositBronzeOre;
        }// end function

        private function _SpecialistPanel_ProgressBar1_i() : ProgressBar
        {
            var _loc_1:* = new ProgressBar();
            this.progress = _loc_1;
            _loc_1.setStyle("left", "10");
            _loc_1.setStyle("right", "10");
            _loc_1.setStyle("bottom", "10");
            _loc_1.id = "progress";
            BindingManager.executeBindings(this, "progress", this.progress);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistPanel_StandardButton2_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnTransfer = _loc_1;
            _loc_1.enabled = false;
            _loc_1.width = 49;
            _loc_1.height = 39;
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "48");
            _loc_1.addEventListener("toolTipCreate", this.__btnTransfer_toolTipCreate);
            _loc_1.id = "btnTransfer";
            BindingManager.executeBindings(this, "btnTransfer", this.btnTransfer);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistPanel_SpriteLibAnimation1_i() : SpriteLibAnimation
        {
            var _loc_1:* = new SpriteLibAnimation();
            this.generalBusyAnim = _loc_1;
            _loc_1.animationName = "guianim_hourglass";
            _loc_1.loop = true;
            _loc_1.visible = false;
            _loc_1.width = 48;
            _loc_1.height = 48;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "generalBusyAnim";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistPanel_Canvas28_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.width = 150;
            _loc_1.height = 37;
            _loc_1.verticalScrollPolicy = "off";
            _loc_1.setStyle("right", "13");
            _loc_1.setStyle("top", "7");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_CustomText14_i());
            return _loc_1;
        }// end function

        private function _SpecialistPanel_CustomText10_i() : CustomText
        {
            var _loc_1:* = new CustomText();
            this.textFindAdventureZoneLong = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "47");
            _loc_1.setStyle("verticalCenter", "2");
            _loc_1.id = "textFindAdventureZoneLong";
            BindingManager.executeBindings(this, "textFindAdventureZoneLong", this.textFindAdventureZoneLong);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set textFindTreasureMedium(param1:CustomText) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._2136299818textFindTreasureMedium;
            if (_loc_2 !== param1)
            {
                this._2136299818textFindTreasureMedium = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "textFindTreasureMedium", _loc_2, param1));
            }
            return;
        }// end function

        public function get title() : Label
        {
            return this._110371416title;
        }// end function

        public function get btnTransfer() : StandardButton
        {
            return this._1234272665btnTransfer;
        }// end function

        private function _SpecialistPanel_SetProperty3_c() : SetProperty
        {
            var _loc_1:* = new SetProperty();
            _loc_1.name = "height";
            _loc_1.value = 348;
            return _loc_1;
        }// end function

        private function _SpecialistPanel_Canvas39_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.width = 150;
            _loc_1.height = 37;
            _loc_1.setStyle("right", "13");
            _loc_1.setStyle("top", "91");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_CustomText23_i());
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

        private function _SpecialistPanel_StandardButton18_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnFindDepositMarble = _loc_1;
            _loc_1.enabled = false;
            _loc_1.width = 49;
            _loc_1.height = 39;
            _loc_1.setStyle("left", "112");
            _loc_1.setStyle("top", "48");
            _loc_1.addEventListener("toolTipCreate", this.__btnFindDepositMarble_toolTipCreate);
            _loc_1.id = "btnFindDepositMarble";
            BindingManager.executeBindings(this, "btnFindDepositMarble", this.btnFindDepositMarble);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistPanel_CustomText2_i() : CustomText
        {
            var _loc_1:* = new CustomText();
            this._SpecialistPanel_CustomText2 = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "50");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "_SpecialistPanel_CustomText2";
            BindingManager.executeBindings(this, "_SpecialistPanel_CustomText2", this._SpecialistPanel_CustomText2);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistPanel_Label5_i() : Label
        {
            var _loc_1:* = new Label();
            this._SpecialistPanel_Label5 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_SpecialistPanel_Label5";
            BindingManager.executeBindings(this, "_SpecialistPanel_Label5", this._SpecialistPanel_Label5);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set fadeOut(param1:Fade) : void
        {
            var _loc_2:* = this._1091436750fadeOut;
            if (_loc_2 !== param1)
            {
                this._1091436750fadeOut = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "fadeOut", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnFindDepositStone(param1:StandardButton) : void
        {
            var _loc_2:* = this._1379232572btnFindDepositStone;
            if (_loc_2 !== param1)
            {
                this._1379232572btnFindDepositStone = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnFindDepositStone", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistPanel_StandardButton1_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnAttack = _loc_1;
            _loc_1.enabled = false;
            _loc_1.width = 49;
            _loc_1.height = 39;
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "6");
            _loc_1.addEventListener("toolTipCreate", this.__btnAttack_toolTipCreate);
            _loc_1.id = "btnAttack";
            BindingManager.executeBindings(this, "btnAttack", this.btnAttack);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set textFindWildZone(param1:CustomText) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1771381052textFindWildZone;
            if (_loc_2 !== param1)
            {
                this._1771381052textFindWildZone = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "textFindWildZone", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistPanel_Canvas16_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.subContentExplorerBase = _loc_1;
            _loc_1.styleName = "detailsContentBox";
            _loc_1.height = 93;
            _loc_1.setStyle("left", "32");
            _loc_1.setStyle("right", "29");
            _loc_1.setStyle("top", "142");
            _loc_1.id = "subContentExplorerBase";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_Canvas17_c());
            _loc_1.addChild(this._SpecialistPanel_StandardButton6_i());
            _loc_1.addChild(this._SpecialistPanel_Canvas18_c());
            _loc_1.addChild(this._SpecialistPanel_StandardButton7_i());
            _loc_1.addChild(this._SpecialistPanel_Canvas19_c());
            _loc_1.addChild(this._SpecialistPanel_StandardButton8_i());
            _loc_1.addChild(this._SpecialistPanel_Canvas20_c());
            _loc_1.addChild(this._SpecialistPanel_StandardButton9_i());
            return _loc_1;
        }// end function

        private function _SpecialistPanel_Canvas27_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.width = 150;
            _loc_1.height = 37;
            _loc_1.verticalScrollPolicy = "off";
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("top", "49");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_CustomText13_i());
            return _loc_1;
        }// end function

        public function get textFindDepositBronzeOre() : CustomText
        {
            return this._455805296textFindDepositBronzeOre;
        }// end function

        public function set generalLeftColumn(param1:Canvas) : void
        {
            var _loc_2:* = this._162733755generalLeftColumn;
            if (_loc_2 !== param1)
            {
                this._162733755generalLeftColumn = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "generalLeftColumn", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnFindDepositMarble(param1:StandardButton) : void
        {
            var _loc_2:* = this._382706874btnFindDepositMarble;
            if (_loc_2 !== param1)
            {
                this._382706874btnFindDepositMarble = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnFindDepositMarble", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistPanel_CustomText21_i() : CustomText
        {
            var _loc_1:* = new CustomText();
            this.textFindDepositBronzeOre = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "50");
            _loc_1.setStyle("verticalCenter", "2");
            _loc_1.id = "textFindDepositBronzeOre";
            BindingManager.executeBindings(this, "textFindDepositBronzeOre", this.textFindDepositBronzeOre);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get generalRightColumn() : Canvas
        {
            return this._1398146422generalRightColumn;
        }// end function

        public function get textFindDepositIronOre() : CustomText
        {
            return this._285760162textFindDepositIronOre;
        }// end function

        private function _SpecialistPanel_SetProperty2_c() : SetProperty
        {
            var _loc_1:* = new SetProperty();
            _loc_1.name = "height";
            _loc_1.value = 366;
            return _loc_1;
        }// end function

        private function _SpecialistPanel_Canvas15_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.height = 18;
            _loc_1.setStyle("left", "31");
            _loc_1.setStyle("right", "28");
            _loc_1.setStyle("top", "124");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_Label4_i());
            return _loc_1;
        }// end function

        public function get currentTask() : CustomText
        {
            return this._601227934currentTask;
        }// end function

        private function _SpecialistPanel_CustomText1_i() : CustomText
        {
            var _loc_1:* = new CustomText();
            this._SpecialistPanel_CustomText1 = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "50");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "_SpecialistPanel_CustomText1";
            BindingManager.executeBindings(this, "_SpecialistPanel_CustomText1", this._SpecialistPanel_CustomText1);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistPanel_Canvas38_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.width = 150;
            _loc_1.height = 37;
            _loc_1.setStyle("right", "13");
            _loc_1.setStyle("top", "49");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_CustomText22_i());
            return _loc_1;
        }// end function

        private function _SpecialistPanel_Label4_i() : Label
        {
            var _loc_1:* = new Label();
            this._SpecialistPanel_Label4 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_SpecialistPanel_Label4";
            BindingManager.executeBindings(this, "_SpecialistPanel_Label4", this._SpecialistPanel_Label4);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistPanel_StandardButton17_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnFindDepositStone = _loc_1;
            _loc_1.enabled = false;
            _loc_1.width = 49;
            _loc_1.height = 39;
            _loc_1.setStyle("left", "112");
            _loc_1.setStyle("top", "6");
            _loc_1.addEventListener("toolTipCreate", this.__btnFindDepositStone_toolTipCreate);
            _loc_1.id = "btnFindDepositStone";
            BindingManager.executeBindings(this, "btnFindDepositStone", this.btnFindDepositStone);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get specialistFrame() : Frame
        {
            return this._1723375940specialistFrame;
        }// end function

        private function _SpecialistPanel_CustomText20_i() : CustomText
        {
            var _loc_1:* = new CustomText();
            this.textFindDepositSalpeter = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "50");
            _loc_1.setStyle("verticalCenter", "2");
            _loc_1.id = "textFindDepositSalpeter";
            BindingManager.executeBindings(this, "textFindDepositSalpeter", this.textFindDepositSalpeter);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set textFindTreasure(param1:CustomText) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._33091925textFindTreasure;
            if (_loc_2 !== param1)
            {
                this._33091925textFindTreasure = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "textFindTreasure", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistPanel_Canvas26_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.width = 150;
            _loc_1.height = 37;
            _loc_1.verticalScrollPolicy = "off";
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("top", "7");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_CustomText12_i());
            return _loc_1;
        }// end function

        public function get btnFindDepositSalpeter() : StandardButton
        {
            return this._1001194825btnFindDepositSalpeter;
        }// end function

        public function get btnFindTreasureShort() : StandardButton
        {
            return this._276470488btnFindTreasureShort;
        }// end function

        public function get btnExploreSector() : StandardButton
        {
            return this._878160605btnExploreSector;
        }// end function

        public function set textFindTreasureLong(param1:CustomText) : void
        {
            var _loc_2:Object = null;
            _loc_2 = this._1897236111textFindTreasureLong;
            if (_loc_2 !== param1)
            {
                this._1897236111textFindTreasureLong = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "textFindTreasureLong", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistPanel_SetProperty1_c() : SetProperty
        {
            var _loc_1:* = new SetProperty();
            _loc_1.name = "width";
            _loc_1.value = 603;
            return _loc_1;
        }// end function

        private function _SpecialistPanel_Canvas37_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.width = 150;
            _loc_1.height = 37;
            _loc_1.setStyle("right", "13");
            _loc_1.setStyle("top", "7");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_CustomText21_i());
            return _loc_1;
        }// end function

        public function set btnFindAdventureLong(param1:StandardButton) : void
        {
            var _loc_2:* = this._234552695btnFindAdventureLong;
            if (_loc_2 !== param1)
            {
                this._234552695btnFindAdventureLong = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnFindAdventureLong", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistPanel_Canvas14_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.generalBusy = _loc_1;
            _loc_1.percentWidth = 100;
            _loc_1.height = 168;
            _loc_1.visible = false;
            _loc_1.setStyle("backgroundColor", 6970177);
            _loc_1.setStyle("backgroundAlpha", 0.7);
            _loc_1.id = "generalBusy";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_SpriteLibAnimation1_i());
            return _loc_1;
        }// end function

        public function set btnFindDepositGoldOre(param1:StandardButton) : void
        {
            var _loc_2:* = this._386233209btnFindDepositGoldOre;
            if (_loc_2 !== param1)
            {
                this._386233209btnFindDepositGoldOre = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnFindDepositGoldOre", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistPanel_Label3_i() : Label
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

        private function _SpecialistPanel_StandardButton16_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnFindTreasureEvenLonger = _loc_1;
            _loc_1.width = 49;
            _loc_1.height = 39;
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "48");
            _loc_1.addEventListener("toolTipCreate", this.__btnFindTreasureEvenLonger_toolTipCreate);
            _loc_1.id = "btnFindTreasureEvenLonger";
            BindingManager.executeBindings(this, "btnFindTreasureEvenLonger", this.btnFindTreasureEvenLonger);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get generalBusy() : Canvas
        {
            return this._878320385generalBusy;
        }// end function

        private function _SpecialistPanel_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.fadeIn;
            _loc_1 = this.fadeOut;
            _loc_1 = this.confirmFooter;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Commands");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Attack");
            _loc_1 = gAssetManager.GetClass("ButtonIconSwords");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Attack");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Transfer");
            _loc_1 = gAssetManager.GetClass("ButtonIconTrumpet");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Transfer");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Retreat");
            _loc_1 = gAssetManager.GetClass("ButtonIconFlag");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Retreat");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "CurrentMission");
            _loc_1 = this.progressProxy.progress;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "OK");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Cancel");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Commands");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ExploreSector");
            _loc_1 = gAssetManager.GetClass("ButtonIconExploreSector");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindTreasure");
            _loc_1 = gAssetManager.GetClass("ButtonIconFindTreasure");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindTreasure");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindAdventure");
            _loc_1 = gAssetManager.GetClass("ButtonIconFindAdventure");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindAdventure");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindWildZone");
            _loc_1 = gAssetManager.GetClass("ButtonIconFindWildZone");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindAdventureShort");
            _loc_1 = gAssetManager.GetClass("ButtonIconTaskShort");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindAdventureLong");
            _loc_1 = gAssetManager.GetClass("ButtonIconTaskLong");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindAdventureMedium");
            _loc_1 = gAssetManager.GetClass("ButtonIconTaskMedium");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindTreasureShort");
            _loc_1 = gAssetManager.GetClass("ButtonIconTaskShort");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindTreasureLong");
            _loc_1 = gAssetManager.GetClass("ButtonIconTaskLong");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindTreasureMedium");
            _loc_1 = gAssetManager.GetClass("ButtonIconTaskMedium");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindTreasureEvenLonger");
            _loc_1 = gAssetManager.GetClass("ButtonIconTaskEvenLonger");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Commands");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindDepositStone");
            _loc_1 = gAssetManager.GetClass("ButtonIconStone");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindDepositMarble");
            _loc_1 = gAssetManager.GetClass("ButtonIconMarble");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindDepositGold");
            _loc_1 = gAssetManager.GetClass("ButtonIconGold");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindDepositAlloy");
            _loc_1 = gAssetManager.GetClass("ButtonIconAlloy");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindDepositSalpeter");
            _loc_1 = gAssetManager.GetClass("ButtonIconSalpeter");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindDepositBronze");
            _loc_1 = gAssetManager.GetClass("ButtonIconBronze");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindDepositIron");
            _loc_1 = gAssetManager.GetClass("ButtonIconIron");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindDepositCoal");
            _loc_1 = gAssetManager.GetClass("ButtonIconCoal");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindDepositGranite");
            _loc_1 = gAssetManager.GetClass("ButtonIconGranite");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "CostsDuration");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "OK");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Cancel");
            return;
        }// end function

        public function __btnTransfer_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function get textFindAdventureZoneMedium() : CustomText
        {
            return this._1132717301textFindAdventureZoneMedium;
        }// end function

        private function _SpecialistPanel_Canvas25_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.subContentFindTreasure = _loc_1;
            _loc_1.styleName = "detailsContentBox";
            _loc_1.height = 93;
            _loc_1.visible = false;
            _loc_1.setStyle("left", "32");
            _loc_1.setStyle("right", "29");
            _loc_1.setStyle("top", "142");
            _loc_1.id = "subContentFindTreasure";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_Canvas26_c());
            _loc_1.addChild(this._SpecialistPanel_StandardButton13_i());
            _loc_1.addChild(this._SpecialistPanel_Canvas27_c());
            _loc_1.addChild(this._SpecialistPanel_StandardButton14_i());
            _loc_1.addChild(this._SpecialistPanel_Canvas28_c());
            _loc_1.addChild(this._SpecialistPanel_StandardButton15_i());
            _loc_1.addChild(this._SpecialistPanel_Canvas29_c());
            _loc_1.addChild(this._SpecialistPanel_StandardButton16_i());
            return _loc_1;
        }// end function

        public function __btnFindDepositSalpeter_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, !this.btnFindDepositSalpeter.enabled);
            return;
        }// end function

        public function __btnFindDepositStone_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, !this.btnFindDepositStone.enabled);
            return;
        }// end function

        public function set costsHolder(param1:HBox) : void
        {
            var _loc_2:* = this._1906816914costsHolder;
            if (_loc_2 !== param1)
            {
                this._1906816914costsHolder = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "costsHolder", _loc_2, param1));
            }
            return;
        }// end function

        public function get stateGeneral() : State
        {
            return this._93112087stateGeneral;
        }// end function

        private function _SpecialistPanel_StandardButton15_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnFindTreasureMedium = _loc_1;
            _loc_1.width = 49;
            _loc_1.height = 39;
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "6");
            _loc_1.addEventListener("toolTipCreate", this.__btnFindTreasureMedium_toolTipCreate);
            _loc_1.id = "btnFindTreasureMedium";
            BindingManager.executeBindings(this, "btnFindTreasureMedium", this.btnFindTreasureMedium);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistPanel_Canvas13_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.percentWidth = 100;
            _loc_1.height = 168;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_TileList1_i());
            return _loc_1;
        }// end function

        private function _SpecialistPanel_Canvas36_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.width = 150;
            _loc_1.height = 37;
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("top", "175");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_CustomText20_i());
            return _loc_1;
        }// end function

        public function set textFindAdventureZoneLong(param1:CustomText) : void
        {
            var _loc_2:* = this._1290420114textFindAdventureZoneLong;
            if (_loc_2 !== param1)
            {
                this._1290420114textFindAdventureZoneLong = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "textFindAdventureZoneLong", _loc_2, param1));
            }
            return;
        }// end function

        public function get fadeOut() : Fade
        {
            return this._1091436750fadeOut;
        }// end function

        private function _SpecialistPanel_Label2_i() : Label
        {
            var _loc_1:* = new Label();
            this._SpecialistPanel_Label2 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_SpecialistPanel_Label2";
            BindingManager.executeBindings(this, "_SpecialistPanel_Label2", this._SpecialistPanel_Label2);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistPanel_Fade2_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeOut = _loc_1;
            _loc_1.alphaFrom = 1;
            _loc_1.alphaTo = 0;
            _loc_1.duration = 150;
            _loc_1.addEventListener("effectEnd", this.__fadeOut_effectEnd);
            return _loc_1;
        }// end function

        public function get btnFindDepositStone() : StandardButton
        {
            return this._1379232572btnFindDepositStone;
        }// end function

        public function get btnFindDepositMarble() : StandardButton
        {
            return this._382706874btnFindDepositMarble;
        }// end function

        private function _SpecialistPanel_Canvas24_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.width = 150;
            _loc_1.height = 37;
            _loc_1.verticalScrollPolicy = "off";
            _loc_1.setStyle("right", "13");
            _loc_1.setStyle("top", "7");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_CustomText11_i());
            return _loc_1;
        }// end function

        public function set textExploreSector(param1:CustomText) : void
        {
            var _loc_2:* = this._413548460textExploreSector;
            if (_loc_2 !== param1)
            {
                this._413548460textExploreSector = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "textExploreSector", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnFindAdventureMedium(param1:StandardButton) : void
        {
            var _loc_2:* = this._2085942192btnFindAdventureMedium;
            if (_loc_2 !== param1)
            {
                this._2085942192btnFindAdventureMedium = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnFindAdventureMedium", _loc_2, param1));
            }
            return;
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

        private function _SpecialistPanel_StandardButton14_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnFindTreasureLong = _loc_1;
            _loc_1.width = 49;
            _loc_1.height = 39;
            _loc_1.setStyle("left", "112");
            _loc_1.setStyle("top", "48");
            _loc_1.addEventListener("toolTipCreate", this.__btnFindTreasureLong_toolTipCreate);
            _loc_1.id = "btnFindTreasureLong";
            BindingManager.executeBindings(this, "btnFindTreasureLong", this.btnFindTreasureLong);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistPanel_Canvas12_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.height = 211;
            _loc_1.setStyle("left", "1");
            _loc_1.setStyle("right", "1");
            _loc_1.setStyle("top", "18");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_Canvas13_c());
            _loc_1.addChild(this._SpecialistPanel_Canvas14_i());
            _loc_1.addChild(this._SpecialistPanel_HBox1_c());
            return _loc_1;
        }// end function

        private function _SpecialistPanel_Canvas35_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.width = 150;
            _loc_1.height = 37;
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("top", "133");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_CustomText19_i());
            return _loc_1;
        }// end function

        private function _SpecialistPanel_Fade1_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeIn = _loc_1;
            _loc_1.alphaFrom = 0;
            _loc_1.alphaTo = 1;
            _loc_1.duration = 150;
            return _loc_1;
        }// end function

        private function _SpecialistPanel_Label1_i() : Label
        {
            var _loc_1:* = new Label();
            this._SpecialistPanel_Label1 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_SpecialistPanel_Label1";
            BindingManager.executeBindings(this, "_SpecialistPanel_Label1", this._SpecialistPanel_Label1);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set subContentFindAdventure(param1:Canvas) : void
        {
            var _loc_2:* = this._2044959678subContentFindAdventure;
            if (_loc_2 !== param1)
            {
                this._2044959678subContentFindAdventure = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "subContentFindAdventure", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistPanel_StandardButton25_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnFindDepositGranite = _loc_1;
            _loc_1.enabled = false;
            _loc_1.width = 49;
            _loc_1.height = 39;
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "132");
            _loc_1.addEventListener("toolTipCreate", this.__btnFindDepositGranite_toolTipCreate);
            _loc_1.id = "btnFindDepositGranite";
            BindingManager.executeBindings(this, "btnFindDepositGranite", this.btnFindDepositGranite);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set stateGeologist(param1:State) : void
        {
            var _loc_2:* = this._371719110stateGeologist;
            if (_loc_2 !== param1)
            {
                this._371719110stateGeologist = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "stateGeologist", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistPanel_Canvas23_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.width = 150;
            _loc_1.height = 37;
            _loc_1.verticalScrollPolicy = "off";
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("top", "49");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_CustomText10_i());
            return _loc_1;
        }// end function

        override public function initialize() : void
        {
            var target:SpecialistPanel;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._SpecialistPanel_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_SpecialistPanelWatcherSetupUtil");
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

        public function get btnFindDepositGoldOre() : StandardButton
        {
            return this._386233209btnFindDepositGoldOre;
        }// end function

        public function get costsHolder() : HBox
        {
            return this._1906816914costsHolder;
        }// end function

        public function get textFindAdventureZoneLong() : CustomText
        {
            return this._1290420114textFindAdventureZoneLong;
        }// end function

        public function set btnRetreat(param1:StandardButton) : void
        {
            var _loc_2:* = this._91139125btnRetreat;
            if (_loc_2 !== param1)
            {
                this._91139125btnRetreat = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnRetreat", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnAttack(param1:StandardButton) : void
        {
            var _loc_2:* = this._78390212btnAttack;
            if (_loc_2 !== param1)
            {
                this._78390212btnAttack = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnAttack", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistPanel_StandardButton13_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnFindTreasureShort = _loc_1;
            _loc_1.width = 49;
            _loc_1.height = 39;
            _loc_1.setStyle("left", "112");
            _loc_1.setStyle("top", "6");
            _loc_1.addEventListener("toolTipCreate", this.__btnFindTreasureShort_toolTipCreate);
            _loc_1.id = "btnFindTreasureShort";
            BindingManager.executeBindings(this, "btnFindTreasureShort", this.btnFindTreasureShort);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistPanel_Canvas11_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.percentWidth = 100;
            _loc_1.height = 18;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_Label3_i());
            return _loc_1;
        }// end function

        private function _SpecialistPanel_Canvas34_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.width = 150;
            _loc_1.height = 37;
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("top", "91");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_CustomText18_i());
            return _loc_1;
        }// end function

        public function get textExploreSector() : CustomText
        {
            return this._413548460textExploreSector;
        }// end function

        public function get btnFindAdventureMedium() : StandardButton
        {
            return this._2085942192btnFindAdventureMedium;
        }// end function

        public function set btnFindDepositCoal(param1:StandardButton) : void
        {
            var _loc_2:* = this._1064369184btnFindDepositCoal;
            if (_loc_2 !== param1)
            {
                this._1064369184btnFindDepositCoal = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnFindDepositCoal", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnAttack() : StandardButton
        {
            return this._78390212btnAttack;
        }// end function

        public function get subContentFindAdventure() : Canvas
        {
            return this._2044959678subContentFindAdventure;
        }// end function

        private function _SpecialistPanel_StandardButton24_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnFindDepositCoal = _loc_1;
            _loc_1.enabled = false;
            _loc_1.width = 49;
            _loc_1.height = 39;
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "90");
            _loc_1.addEventListener("toolTipCreate", this.__btnFindDepositCoal_toolTipCreate);
            _loc_1.id = "btnFindDepositCoal";
            BindingManager.executeBindings(this, "btnFindDepositCoal", this.btnFindDepositCoal);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _SpecialistPanel_Canvas22_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.width = 150;
            _loc_1.height = 37;
            _loc_1.verticalScrollPolicy = "off";
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("top", "7");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_CustomText9_i());
            return _loc_1;
        }// end function

        public function get btnRetreat() : StandardButton
        {
            return this._91139125btnRetreat;
        }// end function

        public function get stateGeologist() : State
        {
            return this._371719110stateGeologist;
        }// end function

        public function set btnFindWildZone(param1:StandardButton) : void
        {
            var _loc_2:* = this._123800555btnFindWildZone;
            if (_loc_2 !== param1)
            {
                this._123800555btnFindWildZone = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnFindWildZone", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnFindDepositCoal() : StandardButton
        {
            return this._1064369184btnFindDepositCoal;
        }// end function

        private function _SpecialistPanel_Canvas9_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.height = 56;
            _loc_1.setStyle("left", "1");
            _loc_1.setStyle("right", "1");
            _loc_1.setStyle("top", "173");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_CustomText4_i());
            _loc_1.addChild(this._SpecialistPanel_ProgressBar1_i());
            return _loc_1;
        }// end function

        private function _SpecialistPanel_StandardButton12_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnFindAdventureMedium = _loc_1;
            _loc_1.width = 49;
            _loc_1.height = 39;
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "6");
            _loc_1.addEventListener("toolTipCreate", this.__btnFindAdventureMedium_toolTipCreate);
            _loc_1.id = "btnFindAdventureMedium";
            BindingManager.executeBindings(this, "btnFindAdventureMedium", this.btnFindAdventureMedium);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set stateExplorer(param1:State) : void
        {
            var _loc_2:* = this._852795408stateExplorer;
            if (_loc_2 !== param1)
            {
                this._852795408stateExplorer = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "stateExplorer", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnFindWildZone() : StandardButton
        {
            return this._123800555btnFindWildZone;
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

        private function _SpecialistPanel_Canvas33_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.width = 150;
            _loc_1.height = 37;
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("top", "49");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_CustomText17_i());
            return _loc_1;
        }// end function

        public function get stateExplorer() : State
        {
            return this._852795408stateExplorer;
        }// end function

        public function set busy(param1:Boolean) : void
        {
            switch(this.currentState)
            {
                case "General":
                {
                    this.generalBusy.visible = param1;
                    this.generalBusyAnim.visible = param1;
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

        public function get btnCancel() : StandardButton
        {
            return this._117924854btnCancel;
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

        private function _SpecialistPanel_Canvas10_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.generalRightColumn = _loc_1;
            _loc_1.setStyle("left", "188");
            _loc_1.setStyle("right", "28");
            _loc_1.setStyle("top", "124");
            _loc_1.id = "generalRightColumn";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._SpecialistPanel_Canvas11_c());
            _loc_1.addChild(this._SpecialistPanel_Canvas12_c());
            return _loc_1;
        }// end function

        public function get description() : Text
        {
            return this._1724546052description;
        }// end function

        public function set close(param1:CloseButton) : void
        {
            var _loc_2:* = this._94756344close;
            if (_loc_2 !== param1)
            {
                this._94756344close = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "close", _loc_2, param1));
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
