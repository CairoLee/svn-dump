package GUI.Components
{
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import ServerState.*;
    import flash.display.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import mx.states.*;

    public class TradingPanel extends Canvas implements IBindingClient
    {
        private var _94756344close:CloseButton;
        private var _94069048btnOK:StandardButton;
        private var _894255569reciepientName:Label;
        private var _384566343resourceName:Label;
        private var _1177777389stateSelect:State;
        private var _384618036resourceList:CustomTileList;
        public var _TradingPanel_RemoveChild1:RemoveChild;
        private var _1530410928costRenderer:TradeResourceItemRenderer;
        private var _11548545buttonBar:CustomToggleButtonBar;
        private var _654142875btnSelectCost:StandardButton;
        private var _384713305resourceIcon:Image;
        private var _1363195570offerBuffRenderer:StarMenuItemRenderer;
        private var _1221270899header:Canvas;
        private var _1207208644btnSelectOffer:StandardButton;
        private var _1522789487buffList:CustomTileList;
        var _bindingsByDestination:Object;
        private var _766190694playerAvatar:Image;
        public var _TradingPanel_Label3:Label;
        public var _TradingPanel_Label4:Label;
        private var _1724546052description:Text;
        public var _TradingPanel_Label7:Label;
        private var _2095657228playerName:Label;
        private var _765989721amountSlider:ExtendedHSlider;
        private var _2049680801labelMiddleColumn:Label;
        var _watchers:Array;
        public var _TradingPanel_SetProperty2:SetProperty;
        private var _562086394resourceAmount:Label;
        private var _1902748013offerResourceRenderer:TradeResourceItemRenderer;
        public var _TradingPanel_StandardButton2:StandardButton;
        private var _1522884756buffIcon:StarMenuItemRenderer;
        public var _TradingPanel_Image2:Image;
        public var _TradingPanel_Image4:Image;
        public var _TradingPanel_Image5:Image;
        public var _TradingPanel_Image7:Image;
        var _bindingsBeginWithWord:Object;
        private var _33017631reciepientAvatar:Image;
        private var _592690571tradeContent:HBox;
        private var _672575543selectedResource:dResource = null;
        var _bindings:Array;
        private var _643911744btnSendTrade:StandardButton;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function TradingPanel()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:504, height:317, childDescriptors:[new UIComponentDescriptor({type:Label, id:"_TradingPanel_Label3", stylesFactory:function () : void
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
                }), new UIComponentDescriptor({type:Canvas, id:"header", stylesFactory:function () : void
                {
                    null.left = this;
                    this.right = "24";
                    this.top = "32";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {styleName:"detailsHeader", height:60, childDescriptors:[new UIComponentDescriptor({type:Text, id:"description", stylesFactory:function () : void
                    {
                        this.left = "18";
                        this.right = "15";
                        this.top = "6";
                        this.bottom = "2";
                        this.color = 16777215;
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {null:false};
                    }// end function
                    })]};
                }// end function
                }), new UIComponentDescriptor({type:HBox, id:"tradeContent", stylesFactory:function () : void
                {
                    null.left = this;
                    this.right = "27";
                    this.top = "96";
                    this.bottom = "14";
                    this.horizontalGap = 3;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {childDescriptors:[new UIComponentDescriptor({type:VBox, stylesFactory:function () : void
                    {
                        this.verticalGap = 0;
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {percentWidth:100, percentHeight:100, childDescriptors:[new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                        {
                            var _loc_1:String = null;
                            return {styleName:"detailsSubHeader", percentWidth:100, height:18, childDescriptors:[new UIComponentDescriptor({type:Label, id:"_TradingPanel_Label4", stylesFactory:function () : void
                            {
                                this.top = "1";
                                this.horizontalCenter = "0";
                                this.color = 16777215;
                                this.fontWeight = "bold";
                                return;
                            }// end function
                            })]};
                        }// end function
                        }), new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                        {
                            var _loc_1:String = null;
                            return {styleName:"detailsContentBox", percentWidth:100, percentHeight:100, childDescriptors:[new UIComponentDescriptor({type:Image, id:"_TradingPanel_Image2", stylesFactory:function () : void
                            {
                                null.right = this;
                                this.verticalCenter = "0";
                                return;
                            }// end function
                            }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                            {
                                this.verticalCenter = "0";
                                this.left = "5";
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                var _loc_1:String = null;
                                return {styleName:"tradeDetailsBox", width:100, height:180, childDescriptors:[new UIComponentDescriptor({type:Image, id:"playerAvatar", stylesFactory:function () : void
                                {
                                    this.top = "3";
                                    this.horizontalCenter = "-1";
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    return {null:60, height:60};
                                }// end function
                                }), new UIComponentDescriptor({type:Label, id:"playerName", events:{toolTipCreate:"__playerName_toolTipCreate"}, stylesFactory:function () : void
                                {
                                    this.horizontalCenter = "0";
                                    this.top = "52";
                                    this.color = 3284992;
                                    this.fontWeight = "bold";
                                    this.textAlign = "center";
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    return {null:null};
                                }// end function
                                }), new UIComponentDescriptor({type:Image, id:"_TradingPanel_Image4", stylesFactory:function () : void
                                {
                                    null.horizontalCenter = this;
                                    this.top = "96";
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    return {width:22, height:29};
                                }// end function
                                }), new UIComponentDescriptor({type:StarMenuItemRenderer, id:"offerBuffRenderer", stylesFactory:function () : void
                                {
                                    this.horizontalCenter = "0";
                                    this.top = "75";
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    return {null:null};
                                }// end function
                                }), new UIComponentDescriptor({type:TradeResourceItemRenderer, id:"offerResourceRenderer", stylesFactory:function () : void
                                {
                                    null.horizontalCenter = this;
                                    this.top = "100";
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    return {visible:false};
                                }// end function
                                }), new UIComponentDescriptor({type:StandardButton, id:"btnSelectOffer", stylesFactory:function () : void
                                {
                                    this.left = "5";
                                    this.right = "7";
                                    this.bottom = "7";
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    return {null:null};
                                }// end function
                                })]};
                            }// end function
                            })]};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:VBox, stylesFactory:function () : void
                    {
                        null.verticalGap = this;
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {width:130, percentHeight:100, childDescriptors:[new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                        {
                            return {styleName:"detailsSubHeader", percentWidth:100, height:18, childDescriptors:[new UIComponentDescriptor({type:Label, id:"labelMiddleColumn", events:{toolTipCreate:"__labelMiddleColumn_toolTipCreate"}, stylesFactory:function () : void
                            {
                                this.textAlign = "center";
                                this.color = 16777215;
                                this.fontWeight = "bold";
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {null:null};
                            }// end function
                            })]};
                        }// end function
                        }), new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                        {
                            return {styleName:"detailsContentBox", percentWidth:100, percentHeight:100, childDescriptors:[new UIComponentDescriptor({type:StandardButton, id:"btnSendTrade", events:{toolTipCreate:"__btnSendTrade_toolTipCreate"}, stylesFactory:function () : void
                            {
                                this.horizontalCenter = "0";
                                this.verticalCenter = "0";
                                this.left = "112";
                                this.top = "6";
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {null:false, width:95, height:50};
                            }// end function
                            })]};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:VBox, stylesFactory:function () : void
                    {
                        null.verticalGap = this;
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {percentWidth:100, percentHeight:100, childDescriptors:[new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                        {
                            var _loc_1:String = null;
                            return {styleName:"detailsSubHeader", percentWidth:100, height:18, childDescriptors:[new UIComponentDescriptor({type:Label, id:"_TradingPanel_Label7", stylesFactory:function () : void
                            {
                                this.top = "1";
                                this.horizontalCenter = "0";
                                this.color = 16777215;
                                this.fontWeight = "bold";
                                return;
                            }// end function
                            })]};
                        }// end function
                        }), new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                        {
                            var _loc_1:String = null;
                            return {styleName:"detailsContentBox", percentWidth:100, percentHeight:100, childDescriptors:[new UIComponentDescriptor({type:Image, id:"_TradingPanel_Image5", stylesFactory:function () : void
                            {
                                null.left = this;
                                this.verticalCenter = "0";
                                return;
                            }// end function
                            }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                            {
                                null.verticalCenter = this;
                                this.right = "3";
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                var _loc_1:String = null;
                                return {styleName:"tradeDetailsBox", width:100, height:180, childDescriptors:[new UIComponentDescriptor({type:Image, id:"reciepientAvatar", stylesFactory:function () : void
                                {
                                    null.top = this;
                                    this.horizontalCenter = "-1";
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    return {null:60, height:60};
                                }// end function
                                }), new UIComponentDescriptor({type:Label, id:"reciepientName", events:{toolTipCreate:"__reciepientName_toolTipCreate"}, stylesFactory:function () : void
                                {
                                    this.horizontalCenter = "0";
                                    this.top = "52";
                                    this.color = 3284992;
                                    this.fontWeight = "bold";
                                    this.textAlign = "center";
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    return {null:100};
                                }// end function
                                }), new UIComponentDescriptor({type:Image, id:"_TradingPanel_Image7", stylesFactory:function () : void
                                {
                                    this.horizontalCenter = "0";
                                    this.top = "96";
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    return {width:22, height:29};
                                }// end function
                                }), new UIComponentDescriptor({type:TradeResourceItemRenderer, id:"costRenderer", stylesFactory:function () : void
                                {
                                    this.horizontalCenter = "0";
                                    this.top = "100";
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    return {visible:false};
                                }// end function
                                }), new UIComponentDescriptor({type:StandardButton, id:"btnSelectCost", stylesFactory:function () : void
                                {
                                    null.left = this;
                                    this.right = "7";
                                    this.bottom = "7";
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    return {null:26};
                                }// end function
                                })]};
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
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.styleName = "specialPanel";
            this.width = 504;
            this.height = 317;
            this.states = [this._TradingPanel_State1_i()];
            this.addEventListener("show", this.___TradingPanel_Canvas1_show);
            return;
        }// end function

        private function _TradingPanel_CustomTileList1_i() : CustomTileList
        {
            var _loc_1:* = new CustomTileList();
            this.resourceList = _loc_1;
            _loc_1.itemRenderer = this._TradingPanel_ClassFactory1_c();
            _loc_1.setStyle("left", "4");
            _loc_1.setStyle("right", "4");
            _loc_1.setStyle("top", "4");
            _loc_1.setStyle("bottom", "32");
            _loc_1.setStyle("paddingTop", 0);
            _loc_1.setStyle("paddingBottom", 0);
            _loc_1.setStyle("paddingLeft", 0);
            _loc_1.setStyle("paddingRight", 0);
            _loc_1.setStyle("useRollOver", false);
            _loc_1.setStyle("borderThickness", 0);
            _loc_1.setStyle("backgroundAlpha", 0);
            _loc_1.id = "resourceList";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
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

        public function get stateSelect() : State
        {
            return this._1177777389stateSelect;
        }// end function

        private function _TradingPanel_State1_i() : State
        {
            var _loc_1:* = new State();
            this.stateSelect = _loc_1;
            _loc_1.name = "select";
            _loc_1.overrides = [this._TradingPanel_SetProperty1_c(), this._TradingPanel_AddChild1_c(), this._TradingPanel_AddChild2_c(), this._TradingPanel_AddChild3_c(), this._TradingPanel_RemoveChild1_i(), this._TradingPanel_SetProperty2_i()];
            return _loc_1;
        }// end function

        private function _TradingPanel_ExtendedHSlider1_i() : ExtendedHSlider
        {
            var _loc_1:* = new ExtendedHSlider();
            this.amountSlider = _loc_1;
            _loc_1.enabled = false;
            _loc_1.liveDragging = true;
            _loc_1.setStyle("bottom", "10");
            _loc_1.setStyle("left", "65");
            _loc_1.setStyle("right", "10");
            _loc_1.id = "amountSlider";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _TradingPanel_Canvas4_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "hr";
            _loc_1.height = 3;
            _loc_1.setStyle("left", "0");
            _loc_1.setStyle("right", "0");
            _loc_1.setStyle("bottom", "27");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __labelMiddleColumn_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
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

        public function get playerName() : Label
        {
            return this._2095657228playerName;
        }// end function

        public function get resourceAmount() : Label
        {
            return this._562086394resourceAmount;
        }// end function

        private function _TradingPanel_StarMenuItemRenderer1_i() : StarMenuItemRenderer
        {
            var _loc_1:* = new StarMenuItemRenderer();
            this.buffIcon = _loc_1;
            _loc_1.visible = false;
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.setStyle("left", "5");
            _loc_1.id = "buffIcon";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set header(param1:Canvas) : void
        {
            var _loc_2:* = this._1221270899header;
            if (_loc_2 !== param1)
            {
                this._1221270899header = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "header", _loc_2, param1));
            }
            return;
        }// end function

        public function set resourceAmount(param1:Label) : void
        {
            var _loc_2:* = this._562086394resourceAmount;
            if (_loc_2 !== param1)
            {
                this._562086394resourceAmount = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourceAmount", _loc_2, param1));
            }
            return;
        }// end function

        public function set playerName(param1:Label) : void
        {
            var _loc_2:* = this._2095657228playerName;
            if (_loc_2 !== param1)
            {
                this._2095657228playerName = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "playerName", _loc_2, param1));
            }
            return;
        }// end function

        private function _TradingPanel_ClassFactory1_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = WarehouseDetailsItemRenderer;
            return _loc_1;
        }// end function

        public function set buffList(param1:CustomTileList) : void
        {
            var _loc_2:* = this._1522789487buffList;
            if (_loc_2 !== param1)
            {
                this._1522789487buffList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "buffList", _loc_2, param1));
            }
            return;
        }// end function

        public function set playerAvatar(param1:Image) : void
        {
            var _loc_2:* = this._766190694playerAvatar;
            if (_loc_2 !== param1)
            {
                this._766190694playerAvatar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "playerAvatar", _loc_2, param1));
            }
            return;
        }// end function

        private function _TradingPanel_AddChild2_c() : AddChild
        {
            var _loc_1:* = new AddChild();
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._TradingPanel_HBox1_c);
            return _loc_1;
        }// end function

        private function _TradingPanel_StandardButton2_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this._TradingPanel_StandardButton2 = _loc_1;
            _loc_1.width = 70;
            _loc_1.height = 32;
            _loc_1.addEventListener("click", this.___TradingPanel_StandardButton2_click);
            _loc_1.id = "_TradingPanel_StandardButton2";
            BindingManager.executeBindings(this, "_TradingPanel_StandardButton2", this._TradingPanel_StandardButton2);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get reciepientAvatar() : Image
        {
            return this._33017631reciepientAvatar;
        }// end function

        private function _TradingPanel_Canvas3_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "listBackgroundShadow";
            _loc_1.setStyle("left", "0");
            _loc_1.setStyle("right", "0");
            _loc_1.setStyle("top", "0");
            _loc_1.setStyle("bottom", "29");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set reciepientAvatar(param1:Image) : void
        {
            var _loc_2:* = this._33017631reciepientAvatar;
            if (_loc_2 !== param1)
            {
                this._33017631reciepientAvatar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "reciepientAvatar", _loc_2, param1));
            }
            return;
        }// end function

        public function set resourceIcon(param1:Image) : void
        {
            var _loc_2:* = this._384713305resourceIcon;
            if (_loc_2 !== param1)
            {
                this._384713305resourceIcon = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourceIcon", _loc_2, param1));
            }
            return;
        }// end function

        private function _TradingPanel_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "OK");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Cancel");
            _loc_1 = this.tradeContent;
            _loc_1 = this.description;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Select");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Trade");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "TradingIntroduction");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "WareToDeliver");
            _loc_1 = gAssetManager.GetBitmap("ArrowRightGreen");
            _loc_1 = !(this.offerResourceRenderer.visible || this.offerBuffRenderer.visible);
            _loc_1 = gAssetManager.GetBitmap("QuestionMark");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Select");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "WareToRecieve");
            _loc_1 = gAssetManager.GetBitmap("ArrowLeftGreen");
            _loc_1 = !this.costRenderer.visible;
            _loc_1 = gAssetManager.GetBitmap("QuestionMark");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Select");
            return;
        }// end function

        public function get amountSlider() : ExtendedHSlider
        {
            return this._765989721amountSlider;
        }// end function

        public function set offerBuffRenderer(param1:StarMenuItemRenderer) : void
        {
            var _loc_2:* = this._1363195570offerBuffRenderer;
            if (_loc_2 !== param1)
            {
                this._1363195570offerBuffRenderer = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "offerBuffRenderer", _loc_2, param1));
            }
            return;
        }// end function

        public function ___TradingPanel_Canvas1_show(event:FlexEvent) : void
        {
            this.currentState = "";
            return;
        }// end function

        public function get btnSelectCost() : StandardButton
        {
            return this._654142875btnSelectCost;
        }// end function

        public function get offerResourceRenderer() : TradeResourceItemRenderer
        {
            return this._1902748013offerResourceRenderer;
        }// end function

        public function get labelMiddleColumn() : Label
        {
            return this._2049680801labelMiddleColumn;
        }// end function

        private function _TradingPanel_StandardButton1_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnOK = _loc_1;
            _loc_1.enabled = false;
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

        public function get btnOK() : StandardButton
        {
            return this._94069048btnOK;
        }// end function

        public function get buffIcon() : StarMenuItemRenderer
        {
            return this._1522884756buffIcon;
        }// end function

        public function get tradeContent() : HBox
        {
            return this._592690571tradeContent;
        }// end function

        public function __btnSendTrade_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, !this.btnSendTrade.enabled);
            return;
        }// end function

        private function _TradingPanel_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "OK");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnOK.label");
            result[0] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Cancel");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _TradingPanel_StandardButton2.label = param1;
                return;
            }// end function
            , "_TradingPanel_StandardButton2.label");
            result[1] = binding;
            binding = new Binding(this, function () : DisplayObject
            {
                return tradeContent;
            }// end function
            , function (param1:DisplayObject) : void
            {
                null.target = param1;
                return;
            }// end function
            , "_TradingPanel_RemoveChild1.target");
            result[2] = binding;
            binding = new Binding(this, function () : Object
            {
                return description;
            }// end function
            , function (param1:Object) : void
            {
                _TradingPanel_SetProperty2.target = param1;
                return;
            }// end function
            , "_TradingPanel_SetProperty2.target");
            result[3] = binding;
            binding = new Binding(this, function ()
            {
                return null.GetText(LOCA_GROUP.LABELS, "Select");
            }// end function
            , function (param1) : void
            {
                _TradingPanel_SetProperty2.value = param1;
                return;
            }// end function
            , "_TradingPanel_SetProperty2.value");
            result[4] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "Trade");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _TradingPanel_Label3.text = param1;
                return;
            }// end function
            , "_TradingPanel_Label3.text");
            result[5] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "TradingIntroduction");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "description.text");
            result[6] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "WareToDeliver");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "_TradingPanel_Label4.text");
            result[7] = binding;
            binding = new Binding(this, function () : Object
            {
                return null.GetBitmap("ArrowRightGreen");
            }// end function
            , function (param1:Object) : void
            {
                null.source = null;
                return;
            }// end function
            , "_TradingPanel_Image2.source");
            result[8] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return !(null.visible || offerBuffRenderer.visible);
            }// end function
            , function (param1:Boolean) : void
            {
                _TradingPanel_Image4.visible = param1;
                return;
            }// end function
            , "_TradingPanel_Image4.visible");
            result[9] = binding;
            binding = new Binding(this, function () : Object
            {
                return null.GetBitmap("QuestionMark");
            }// end function
            , function (param1:Object) : void
            {
                null.source = null;
                return;
            }// end function
            , "_TradingPanel_Image4.source");
            result[10] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Select");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "btnSelectOffer.label");
            result[11] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "WareToRecieve");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "_TradingPanel_Label7.text");
            result[12] = binding;
            binding = new Binding(this, function () : Object
            {
                return null.GetBitmap("ArrowLeftGreen");
            }// end function
            , function (param1:Object) : void
            {
                null.source = param1;
                return;
            }// end function
            , "_TradingPanel_Image5.source");
            result[13] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return !null.visible;
            }// end function
            , function (param1:Boolean) : void
            {
                null.visible = param1;
                return;
            }// end function
            , "_TradingPanel_Image7.visible");
            result[14] = binding;
            binding = new Binding(this, function () : Object
            {
                return gAssetManager.GetBitmap("QuestionMark");
            }// end function
            , function (param1:Object) : void
            {
                null.source = null;
                return;
            }// end function
            , "_TradingPanel_Image7.source");
            result[15] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Select");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "btnSelectCost.label");
            result[16] = binding;
            return result;
        }// end function

        private function _TradingPanel_AddChild1_c() : AddChild
        {
            var _loc_1:* = new AddChild();
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._TradingPanel_Canvas2_c);
            return _loc_1;
        }// end function

        private function _TradingPanel_RemoveChild1_i() : RemoveChild
        {
            var _loc_1:* = new RemoveChild();
            this._TradingPanel_RemoveChild1 = _loc_1;
            BindingManager.executeBindings(this, "_TradingPanel_RemoveChild1", this._TradingPanel_RemoveChild1);
            return _loc_1;
        }// end function

        private function _TradingPanel_Canvas2_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.setStyle("left", "32");
            _loc_1.setStyle("right", "29");
            _loc_1.setStyle("top", "96");
            _loc_1.setStyle("bottom", "95");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._TradingPanel_Canvas3_c());
            _loc_1.addChild(this._TradingPanel_CustomTileList1_i());
            _loc_1.addChild(this._TradingPanel_CustomTileList2_i());
            _loc_1.addChild(this._TradingPanel_Canvas4_c());
            _loc_1.addChild(this._TradingPanel_CustomToggleButtonBar1_i());
            return _loc_1;
        }// end function

        private function _TradingPanel_SetProperty2_i() : SetProperty
        {
            var _loc_1:* = new SetProperty();
            this._TradingPanel_SetProperty2 = _loc_1;
            _loc_1.name = "text";
            BindingManager.executeBindings(this, "_TradingPanel_SetProperty2", this._TradingPanel_SetProperty2);
            return _loc_1;
        }// end function

        private function _TradingPanel_Label2_i() : Label
        {
            var _loc_1:* = new Label();
            this.resourceAmount = _loc_1;
            _loc_1.setStyle("left", "80");
            _loc_1.setStyle("top", "30");
            _loc_1.setStyle("color", 16777215);
            _loc_1.id = "resourceAmount";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set btnSendTrade(param1:StandardButton) : void
        {
            var _loc_2:* = this._643911744btnSendTrade;
            if (_loc_2 !== param1)
            {
                this._643911744btnSendTrade = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnSendTrade", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnSelectOffer(param1:StandardButton) : void
        {
            var _loc_2:* = this._1207208644btnSelectOffer;
            if (_loc_2 !== param1)
            {
                this._1207208644btnSelectOffer = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnSelectOffer", _loc_2, param1));
            }
            return;
        }// end function

        public function set resourceName(param1:Label) : void
        {
            var _loc_2:* = this._384566343resourceName;
            if (_loc_2 !== param1)
            {
                this._384566343resourceName = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourceName", _loc_2, param1));
            }
            return;
        }// end function

        public function set costRenderer(param1:TradeResourceItemRenderer) : void
        {
            var _loc_2:* = this._1530410928costRenderer;
            if (_loc_2 !== param1)
            {
                this._1530410928costRenderer = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "costRenderer", _loc_2, param1));
            }
            return;
        }// end function

        override public function initialize() : void
        {
            var target:TradingPanel;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._TradingPanel_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_TradingPanelWatcherSetupUtil");
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

        public function get buffList() : CustomTileList
        {
            return this._1522789487buffList;
        }// end function

        public function get buttonBar() : CustomToggleButtonBar
        {
            return this._11548545buttonBar;
        }// end function

        public function get playerAvatar() : Image
        {
            return this._766190694playerAvatar;
        }// end function

        public function get header() : Canvas
        {
            return this._1221270899header;
        }// end function

        public function set selectedResource(param1:dResource) : void
        {
            var _loc_2:* = this._672575543selectedResource;
            if (_loc_2 !== param1)
            {
                this._672575543selectedResource = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "selectedResource", _loc_2, param1));
            }
            return;
        }// end function

        public function set reciepientName(param1:Label) : void
        {
            var _loc_2:* = this._894255569reciepientName;
            if (_loc_2 !== param1)
            {
                this._894255569reciepientName = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "reciepientName", _loc_2, param1));
            }
            return;
        }// end function

        public function get costRenderer() : TradeResourceItemRenderer
        {
            return this._1530410928costRenderer;
        }// end function

        public function __reciepientName_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function __playerName_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        private function _TradingPanel_HBox1_c() : HBox
        {
            var _loc_1:* = new HBox();
            _loc_1.setStyle("bottom", "20");
            _loc_1.setStyle("right", "28");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._TradingPanel_StandardButton1_i());
            _loc_1.addChild(this._TradingPanel_StandardButton2_i());
            return _loc_1;
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

        private function _TradingPanel_SetProperty1_c() : SetProperty
        {
            var _loc_1:* = new SetProperty();
            _loc_1.name = "height";
            _loc_1.value = 378;
            return _loc_1;
        }// end function

        public function get offerBuffRenderer() : StarMenuItemRenderer
        {
            return this._1363195570offerBuffRenderer;
        }// end function

        private function _TradingPanel_CustomTileList2_i() : CustomTileList
        {
            var _loc_1:* = new CustomTileList();
            this.buffList = _loc_1;
            _loc_1.itemRenderer = this._TradingPanel_ClassFactory2_c();
            _loc_1.setStyle("left", "4");
            _loc_1.setStyle("right", "4");
            _loc_1.setStyle("top", "4");
            _loc_1.setStyle("bottom", "32");
            _loc_1.setStyle("paddingTop", 0);
            _loc_1.setStyle("paddingBottom", 0);
            _loc_1.setStyle("paddingLeft", 0);
            _loc_1.setStyle("paddingRight", 0);
            _loc_1.setStyle("useRollOver", false);
            _loc_1.setStyle("borderThickness", 0);
            _loc_1.setStyle("backgroundAlpha", 0);
            _loc_1.id = "buffList";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _TradingPanel_Label1_i() : Label
        {
            var _loc_1:* = new Label();
            this.resourceName = _loc_1;
            _loc_1.setStyle("left", "80");
            _loc_1.setStyle("top", "12");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "resourceName";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set labelMiddleColumn(param1:Label) : void
        {
            var _loc_2:* = this._2049680801labelMiddleColumn;
            if (_loc_2 !== param1)
            {
                this._2049680801labelMiddleColumn = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "labelMiddleColumn", _loc_2, param1));
            }
            return;
        }// end function

        public function get resourceName() : Label
        {
            return this._384566343resourceName;
        }// end function

        public function get resourceIcon() : Image
        {
            return this._384713305resourceIcon;
        }// end function

        private function _TradingPanel_Canvas5_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.height = 75;
            _loc_1.horizontalScrollPolicy = "off";
            _loc_1.verticalScrollPolicy = "off";
            _loc_1.setStyle("left", "32");
            _loc_1.setStyle("bottom", "12");
            _loc_1.setStyle("right", "185");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._TradingPanel_StarMenuItemRenderer1_i());
            _loc_1.addChild(this._TradingPanel_Image1_i());
            _loc_1.addChild(this._TradingPanel_Label1_i());
            _loc_1.addChild(this._TradingPanel_Label2_i());
            _loc_1.addChild(this._TradingPanel_ExtendedHSlider1_i());
            return _loc_1;
        }// end function

        public function get btnSendTrade() : StandardButton
        {
            return this._643911744btnSendTrade;
        }// end function

        public function get selectedResource() : dResource
        {
            return this._672575543selectedResource;
        }// end function

        public function set btnSelectCost(param1:StandardButton) : void
        {
            var _loc_2:* = this._654142875btnSelectCost;
            if (_loc_2 !== param1)
            {
                this._654142875btnSelectCost = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnSelectCost", _loc_2, param1));
            }
            return;
        }// end function

        public function set buffIcon(param1:StarMenuItemRenderer) : void
        {
            var _loc_2:* = this._1522884756buffIcon;
            if (_loc_2 !== param1)
            {
                this._1522884756buffIcon = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "buffIcon", _loc_2, param1));
            }
            return;
        }// end function

        private function _TradingPanel_CustomToggleButtonBar1_i() : CustomToggleButtonBar
        {
            var _loc_1:* = new CustomToggleButtonBar();
            this.buttonBar = _loc_1;
            _loc_1.setStyle("buttonStyleName", "tab");
            _loc_1.setStyle("selectedButtonTextStyleName", "tabSelected");
            _loc_1.setStyle("bottom", "0");
            _loc_1.setStyle("left", "0");
            _loc_1.setStyle("right", "0");
            _loc_1.id = "buttonBar";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set resourceList(param1:CustomTileList) : void
        {
            var _loc_2:* = this._384618036resourceList;
            if (_loc_2 !== param1)
            {
                this._384618036resourceList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourceList", _loc_2, param1));
            }
            return;
        }// end function

        public function get reciepientName() : Label
        {
            return this._894255569reciepientName;
        }// end function

        public function set offerResourceRenderer(param1:TradeResourceItemRenderer) : void
        {
            var _loc_2:* = this._1902748013offerResourceRenderer;
            if (_loc_2 !== param1)
            {
                this._1902748013offerResourceRenderer = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "offerResourceRenderer", _loc_2, param1));
            }
            return;
        }// end function

        public function get resourceList() : CustomTileList
        {
            return this._384618036resourceList;
        }// end function

        private function _TradingPanel_ClassFactory2_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = StarMenuItemRenderer;
            return _loc_1;
        }// end function

        public function set stateSelect(param1:State) : void
        {
            var _loc_2:* = this._1177777389stateSelect;
            if (_loc_2 !== param1)
            {
                this._1177777389stateSelect = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "stateSelect", _loc_2, param1));
            }
            return;
        }// end function

        public function set tradeContent(param1:HBox) : void
        {
            var _loc_2:* = this._592690571tradeContent;
            if (_loc_2 !== param1)
            {
                this._592690571tradeContent = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "tradeContent", _loc_2, param1));
            }
            return;
        }// end function

        public function ___TradingPanel_StandardButton2_click(event:MouseEvent) : void
        {
            this.currentState = "";
            return;
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

        public function get btnSelectOffer() : StandardButton
        {
            return this._1207208644btnSelectOffer;
        }// end function

        public function get close() : CloseButton
        {
            return this._94756344close;
        }// end function

        public function get description() : Text
        {
            return this._1724546052description;
        }// end function

        private function _TradingPanel_Image1_i() : Image
        {
            var _loc_1:* = new Image();
            this.resourceIcon = _loc_1;
            _loc_1.visible = false;
            _loc_1.width = 26;
            _loc_1.height = 25;
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.setStyle("left", "22");
            _loc_1.id = "resourceIcon";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _TradingPanel_AddChild3_c() : AddChild
        {
            var _loc_1:* = new AddChild();
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._TradingPanel_Canvas5_c);
            return _loc_1;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            TradingPanel._watcherSetupUtil = param1;
            return;
        }// end function

    }
}
