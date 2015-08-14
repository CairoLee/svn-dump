package GUI.Components
{
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.DataGrid.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import Interface.*;
    import com.bluebyte.bluefire.api.model.vo.*;
    import com.bluebyte.bluefire.flex3.defaultClient.*;
    import com.bluebyte.bluefire.puremvc.view.*;
    import com.bluebyte.tso.chat.*;
    import flash.display.*;
    import flash.events.*;
    import flash.text.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.collections.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.controls.dataGridClasses.*;
    import mx.core.*;
    import mx.effects.*;
    import mx.effects.easing.*;
    import mx.events.*;
    import mx.states.*;

    public class ChatPanel extends Canvas implements IChatPanel, IBindingClient
    {
        private var _1282133823fadeIn:Fade;
        private var _925180581rotate:Rotate;
        private var _1784002189messageHistory:ChatHistoryList;
        private var _1305707236scaleButton:Button;
        private var _1091436750fadeOut:Fade;
        private var _11548545buttonBar:ChannelBar;
        private var _1484920424currentOfferBox:HBox;
        private var _676870449autoScrollBox:StandardCheckBox;
        private var _1755722810chatstatusboxicon:Image;
        public var WaitingIcon:Class;
        private var _43974591chatstatusbox:HBox;
        private var _1599613778chatInput:CustomInput;
        var _bindingsByDestination:Object;
        private var _1848789024expiresLabel:Label;
        private var _embed_mxml_____data_src_gfx_embedded_camera_arrow_s_mouseover_png_919877690:Class;
        public var _ChatPanel_Label2:Label;
        private var resizing:Boolean = false;
        private var _embed_mxml_____data_src_gfx_embedded_chat_connect_server_png_941273496:Class;
        private var _488002274maximizeButton:Button;
        private var _805270785tradeChannel:Canvas;
        private var offset:int;
        private var _embed_mxml_____data_src_gfx_embedded_camera_arrow_n_mouseover_png_1235953604:Class;
        private var _1404469421chatstatusboxlabel:Label;
        private var _embed_mxml_____data_src_gfx_embedded_camera_arrow_n_standard_png_882950362:Class;
        private var _183043583fadeOutRollOut:Fade;
        public var _ChatPanel_Button4:Button;
        public var _ChatPanel_Button5:Button;
        private var _701607628privatedetailsHeader:Canvas;
        private var _1971376321privateList:CustomTileList;
        public var _ChatPanel_DataGridColumn1:DataGridColumn;
        public var _ChatPanel_DataGridColumn2:DataGridColumn;
        public var _ChatPanel_DataGridColumn3:DataGridColumn;
        private var _1839887387tradeOffers:CustomDataGrid;
        private var expandedHeight:int;
        private var _1089764471btnClearTradeOffer:StandardButton;
        public var _ChatPanel_RemoveChild1:RemoveChild;
        private var _1884483282fadeInRollOver:Fade;
        private var _1337132433currentOfferResource:TradeResourceItemRenderer;
        private var _475811618btnResetCooldown:StandardButton;
        private var _168913776minimizeButton:Button;
        private var _3613077vbox:VBox;
        var _watchers:Array;
        private var _82641980btnUpdateOffers:StandardButton;
        private var _embed_mxml_____data_src_gfx_embedded_slider_slider_arrow_e_standard_png_1341751878:Class;
        private var mSelectedChannel:ChannelVO;
        var _bindingsBeginWithWord:Object;
        private var _620975237currentCostsResource:TradeResourceItemRenderer;
        private var _528790711btnAddOffer:StandardButton;
        private var _embed_mxml_____data_src_gfx_embedded_camera_arrow_s_standard_png_12632284:Class;
        var _bindings:Array;
        private var _643911744btnSendTrade:StandardButton;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;
        public static var CSSFile:Class = ChatPanel_CSSFile;

        public function ChatPanel()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {childDescriptors:[new UIComponentDescriptor({type:Button, id:"scaleButton", events:{mouseDown:"__scaleButton_mouseDown"}, stylesFactory:function () : void
                {
                    this.top = "0";
                    this.horizontalCenter = "1";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null};
                }// end function
                }), new UIComponentDescriptor({type:Button, id:"maximizeButton", events:{click:"__maximizeButton_click"}, stylesFactory:function () : void
                {
                    null.top = this;
                    this.right = "4";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {styleName:"chatMaximizeButton", visible:false};
                }// end function
                }), new UIComponentDescriptor({type:Button, id:"minimizeButton", events:{click:"__minimizeButton_click"}, stylesFactory:function () : void
                {
                    this.top = "0";
                    this.right = "4";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null};
                }// end function
                }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                {
                    null.left = this;
                    this.right = "5";
                    this.top = "12";
                    this.bottom = "57";
                    this.paddingRight = 15;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {childDescriptors:[new UIComponentDescriptor({type:Canvas, id:"privatedetailsHeader", stylesFactory:function () : void
                    {
                        null.left = this;
                        this.bottom = "0";
                        this.right = "17";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {null:"detailsSubHeader", height:51, visible:false, percentWidth:100};
                    }// end function
                    }), new UIComponentDescriptor({type:VBox, id:"vbox", stylesFactory:function () : void
                    {
                        this.verticalGap = 6;
                        this.horizontalGap = 0;
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {percentWidth:100, percentHeight:100, childDescriptors:[new UIComponentDescriptor({type:HBox, propertiesFactory:function () : Object
                        {
                            var _loc_1:String = null;
                            return {percentWidth:100, percentHeight:100, childDescriptors:[new UIComponentDescriptor({type:ChatHistoryList, id:"messageHistory", stylesFactory:function () : void
                            {
                                null.backgroundAlpha = this;
                                this.borderThickness = 0;
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {null:false, selectable:false, verticalScrollPolicy:"off", variableRowHeight:true, percentHeight:100, percentWidth:100, itemRenderer:_ChatPanel_ClassFactory1_c()};
                            }// end function
                            }), new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                            {
                                var _loc_1:String = null;
                                return {width:18, clipContent:true, percentHeight:100, childDescriptors:[new UIComponentDescriptor({type:Button, id:"_ChatPanel_Button4", events:{mouseDown:"___ChatPanel_Button4_mouseDown"}, stylesFactory:function () : void
                                {
                                    null.upSkin = this;
                                    this.downSkin = _embed_mxml_____data_src_gfx_embedded_camera_arrow_n_mouseover_png_1235953604;
                                    this.overSkin = _embed_mxml_____data_src_gfx_embedded_camera_arrow_n_mouseover_png_1235953604;
                                    this.disabledSkin = _embed_mxml_____data_src_gfx_embedded_camera_arrow_n_standard_png_882950362;
                                    this.top = "0";
                                    this.horizontalCenter = "0";
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    return {null:null, height:22};
                                }// end function
                                }), new UIComponentDescriptor({type:Button, id:"_ChatPanel_Button5", events:{mouseDown:"___ChatPanel_Button5_mouseDown"}, stylesFactory:function () : void
                                {
                                    this.upSkin = _embed_mxml_____data_src_gfx_embedded_camera_arrow_s_standard_png_12632284;
                                    this.downSkin = _embed_mxml_____data_src_gfx_embedded_camera_arrow_s_mouseover_png_919877690;
                                    this.overSkin = _embed_mxml_____data_src_gfx_embedded_camera_arrow_s_mouseover_png_919877690;
                                    this.disabledSkin = _embed_mxml_____data_src_gfx_embedded_camera_arrow_s_standard_png_12632284;
                                    this.bottom = "23";
                                    this.horizontalCenter = "0";
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    return {width:22, height:22};
                                }// end function
                                }), new UIComponentDescriptor({type:StandardCheckBox, id:"autoScrollBox", events:{click:"__autoScrollBox_click"}, stylesFactory:function () : void
                                {
                                    null.bottom = this;
                                    this.horizontalCenter = "-1";
                                    return;
                                }// end function
                                })]};
                            }// end function
                            })]};
                        }// end function
                        }), new UIComponentDescriptor({type:CustomTileList, id:"privateList", stylesFactory:function () : void
                        {
                            this.color = 16777215;
                            this.backgroundAlpha = 0;
                            this.borderThickness = 0;
                            this.useRollOver = false;
                            this.bottom = "0";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {percentWidth:100, columnCount:4, rowCount:2, visible:false, verticalScrollPolicy:"on", height:0, itemRenderer:_ChatPanel_ClassFactory2_c()};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:HBox, id:"chatstatusbox", stylesFactory:function () : void
                    {
                        null.horizontalCenter = this;
                        this.verticalCenter = "1";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {visible:false, childDescriptors:[new UIComponentDescriptor({type:Image, id:"chatstatusboxicon", propertiesFactory:function () : Object
                        {
                            return {null:null};
                        }// end function
                        }), new UIComponentDescriptor({type:Label, id:"chatstatusboxlabel", stylesFactory:function () : void
                        {
                            this.color = 16777215;
                            return;
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, id:"tradeChannel", stylesFactory:function () : void
                    {
                        this.top = "0";
                        this.left = "0";
                        this.right = "0";
                        this.bottom = "0";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {visible:false, childDescriptors:[new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                        {
                            this.left = "-1";
                            this.bottom = "0";
                            this.right = "17";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {styleName:"detailsSubHeader", height:51};
                        }// end function
                        }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                        {
                            this.left = "-1";
                            this.bottom = "53";
                            this.top = "2";
                            this.right = "17";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {null:null};
                        }// end function
                        }), new UIComponentDescriptor({type:VBox, propertiesFactory:function () : Object
                        {
                            var _loc_1:String = null;
                            return {percentWidth:100, percentHeight:100, childDescriptors:[new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                            {
                                var _loc_1:String = null;
                                return {percentWidth:100, percentHeight:100, childDescriptors:[new UIComponentDescriptor({type:CustomDataGrid, id:"tradeOffers", events:{toolTipCreate:"__tradeOffers_toolTipCreate"}, stylesFactory:function () : void
                                {
                                    null.color = this;
                                    this.verticalAlign = "middle";
                                    this.iconColor = 13077059;
                                    this.selectionColor = 8482380;
                                    this.rollOverColor = 7957587;
                                    this.borderThickness = 0;
                                    this.left = "0";
                                    this.right = "1";
                                    this.top = "5";
                                    this.bottom = "0";
                                    this.horizontalGridLines = false;
                                    this.verticalGridLineColor = 7693901;
                                    this.headerColors = [3155998];
                                    this.borderColor = 7693901;
                                    this.headerStyleName = "mailDataGridHeader";
                                    this.headerBackgroundSkin = CustomDataGridHeaderBackgroundSkin;
                                    this.headerSeparatorSkin = CustomDataGridHeaderSeparator;
                                    this.backgroundAlpha = 0;
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    return {null:null, rowHeight:25, headerHeight:20, columns:[_ChatPanel_DataGridColumn1_i(), _ChatPanel_DataGridColumn2_i(), _ChatPanel_DataGridColumn3_i()]};
                                }// end function
                                })]};
                            }// end function
                            }), new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                            {
                                var _loc_1:String = null;
                                return {percentWidth:100, childDescriptors:[new UIComponentDescriptor({type:StandardButton, id:"btnUpdateOffers", stylesFactory:function () : void
                                {
                                    null.left = this;
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    return {null:null};
                                }// end function
                                }), new UIComponentDescriptor({type:StandardButton, id:"btnSendTrade", stylesFactory:function () : void
                                {
                                    null.right = this;
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    return {null:null, enabled:false};
                                }// end function
                                })]};
                            }// end function
                            }), new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                            {
                                return {height:51, percentWidth:100, childDescriptors:[new UIComponentDescriptor({type:HBox, id:"currentOfferBox", stylesFactory:function () : void
                                {
                                    this.top = "4";
                                    this.left = "3";
                                    this.verticalAlign = "middle";
                                    this.horizontalGap = 0;
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    var _loc_1:String = null;
                                    return {height:26, visible:false, childDescriptors:[new UIComponentDescriptor({type:Label, id:"_ChatPanel_Label2", stylesFactory:function () : void
                                    {
                                        this.color = 16777215;
                                        return;
                                    }// end function
                                    }), new UIComponentDescriptor({type:TradeResourceItemRenderer, id:"currentOfferResource"}), new UIComponentDescriptor({type:Image, propertiesFactory:function () : Object
                                    {
                                        return {null:null};
                                    }// end function
                                    }), new UIComponentDescriptor({type:TradeResourceItemRenderer, id:"currentCostsResource"})]};
                                }// end function
                                }), new UIComponentDescriptor({type:Label, id:"expiresLabel", stylesFactory:function () : void
                                {
                                    this.top = "29";
                                    this.color = 16777215;
                                    this.left = "3";
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    return {null:null};
                                }// end function
                                }), new UIComponentDescriptor({type:StandardButton, id:"btnClearTradeOffer", stylesFactory:function () : void
                                {
                                    this.right = "20";
                                    this.top = "7";
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    return {null:null, visible:false};
                                }// end function
                                }), new UIComponentDescriptor({type:StandardButton, id:"btnAddOffer", stylesFactory:function () : void
                                {
                                    this.right = "20";
                                    this.top = "7";
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    return {null:null, visible:true};
                                }// end function
                                }), new UIComponentDescriptor({type:StandardButton, id:"btnResetCooldown", stylesFactory:function () : void
                                {
                                    this.right = "20";
                                    this.top = "7";
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    return {height:26, visible:false, toolTip:"TradeCooldownReset"};
                                }// end function
                                })]};
                            }// end function
                            })]};
                        }// end function
                        })]};
                    }// end function
                    })]};
                }// end function
                }), new UIComponentDescriptor({type:ChannelBar, id:"buttonBar", events:{itemClick:"__buttonBar_itemClick"}, stylesFactory:function () : void
                {
                    null.bottom = this;
                    this.left = "5";
                    this.right = "5";
                    this.color = 16777215;
                    this.backgroundAlpha = 0;
                    this.borderThickness = 0;
                    this.useRollOver = false;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {focusEnabled:false, rowCount:1, columnWidth:48, height:30, itemRenderer:_ChatPanel_ClassFactory6_c(), labelField:"label"};
                }// end function
                }), new UIComponentDescriptor({type:CustomInput, id:"chatInput", stylesFactory:function () : void
                {
                    this.left = "5";
                    this.right = "35";
                    this.bottom = "2";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {maxChars:500, styleName:"chatInput", height:20, restrict:"^\\<"};
                }// end function
                })]};
            }// end function
            });
            this._embed_mxml_____data_src_gfx_embedded_camera_arrow_n_mouseover_png_1235953604 = ChatPanel__embed_mxml_____data_src_gfx_embedded_camera_arrow_n_mouseover_png_1235953604;
            this._embed_mxml_____data_src_gfx_embedded_camera_arrow_n_standard_png_882950362 = ChatPanel__embed_mxml_____data_src_gfx_embedded_camera_arrow_n_standard_png_882950362;
            this._embed_mxml_____data_src_gfx_embedded_camera_arrow_s_mouseover_png_919877690 = ChatPanel__embed_mxml_____data_src_gfx_embedded_camera_arrow_s_mouseover_png_919877690;
            this._embed_mxml_____data_src_gfx_embedded_camera_arrow_s_standard_png_12632284 = ChatPanel__embed_mxml_____data_src_gfx_embedded_camera_arrow_s_standard_png_12632284;
            this._embed_mxml_____data_src_gfx_embedded_chat_connect_server_png_941273496 = ChatPanel__embed_mxml_____data_src_gfx_embedded_chat_connect_server_png_941273496;
            this._embed_mxml_____data_src_gfx_embedded_slider_slider_arrow_e_standard_png_1341751878 = ChatPanel__embed_mxml_____data_src_gfx_embedded_slider_slider_arrow_e_standard_png_1341751878;
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.styleName = "chatPanel";
            this.cacheAsBitmap = true;
            this.label = "Chat";
            this.percentWidth = 100;
            this.percentHeight = 100;
            this.visible = false;
            this.states = [this._ChatPanel_State1_c()];
            this._ChatPanel_Fade1_i();
            this._ChatPanel_Fade4_i();
            this._ChatPanel_Fade2_i();
            this._ChatPanel_Fade3_i();
            this._ChatPanel_Rotate1_i();
            this.addEventListener("creationComplete", this.___ChatPanel_Canvas1_creationComplete);
            return;
        }// end function

        public function set tradeChannel(param1:Canvas) : void
        {
            var _loc_2:* = this._805270785tradeChannel;
            if (_loc_2 !== param1)
            {
                this._805270785tradeChannel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "tradeChannel", _loc_2, param1));
            }
            return;
        }// end function

        public function get messageInput() : IBFTextInput
        {
            return this.chatInput;
        }// end function

        public function get mucs() : IBFList
        {
            return this.buttonBar;
        }// end function

        protected function HandleScrollDownStop(event:Event) : void
        {
            Application.application.removeEventListener(Event.ENTER_FRAME, this.HandleScrollDown);
            Application.application.removeEventListener(MouseEvent.MOUSE_UP, this.HandleScrollDownStop);
            return;
        }// end function

        public function get tradeOffers() : CustomDataGrid
        {
            return this._1839887387tradeOffers;
        }// end function

        public function get expiresLabel() : Label
        {
            return this._1848789024expiresLabel;
        }// end function

        private function _ChatPanel_DataGridColumn3_i() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            this._ChatPanel_DataGridColumn3 = _loc_1;
            _loc_1.resizable = false;
            _loc_1.draggable = false;
            _loc_1.dataField = "senderName";
            _loc_1.itemRenderer = this._ChatPanel_ClassFactory5_c();
            BindingManager.executeBindings(this, "_ChatPanel_DataGridColumn3", this._ChatPanel_DataGridColumn3);
            return _loc_1;
        }// end function

        public function ___ChatPanel_Button4_mouseDown(event:MouseEvent) : void
        {
            this.button2_clickHandler(event);
            return;
        }// end function

        private function set _174067176selectedChannel(param1:ChannelVO) : void
        {
            this.mSelectedChannel = param1;
            if (this.mucs.dataProvider.getItemIndex(this.mSelectedChannel) != -1)
            {
                this.mucs.selectedItem = this.mSelectedChannel;
            }
            return;
        }// end function

        public function set tradeOffers(param1:CustomDataGrid) : void
        {
            var _loc_2:* = this._1839887387tradeOffers;
            if (_loc_2 !== param1)
            {
                this._1839887387tradeOffers = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "tradeOffers", _loc_2, param1));
            }
            return;
        }// end function

        public function __autoScrollBox_click(event:MouseEvent) : void
        {
            this.button1_clickHandler(event);
            return;
        }// end function

        public function get chatstatusboxicon() : Image
        {
            return this._1755722810chatstatusboxicon;
        }// end function

        private function SetAlpha(param1:Number) : void
        {
            this.setStyle("backgroundAlpha", param1);
            this.privateList.alpha = param1;
            this.privatedetailsHeader.alpha = param1;
            return;
        }// end function

        public function set scaleButton(param1:Button) : void
        {
            var _loc_2:* = this._1305707236scaleButton;
            if (_loc_2 !== param1)
            {
                this._1305707236scaleButton = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "scaleButton", _loc_2, param1));
            }
            return;
        }// end function

        public function handleClick(event:MouseEvent) : void
        {
            this.messageInput.setFocus();
            (global.ui as cGameInterface).ActivateChatWindow(true);
            return;
        }// end function

        public function get chatstatusbox() : HBox
        {
            return this._43974591chatstatusbox;
        }// end function

        public function get btnUpdateOffers() : StandardButton
        {
            return this._82641980btnUpdateOffers;
        }// end function

        public function set expiresLabel(param1:Label) : void
        {
            var _loc_2:* = this._1848789024expiresLabel;
            if (_loc_2 !== param1)
            {
                this._1848789024expiresLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "expiresLabel", _loc_2, param1));
            }
            return;
        }// end function

        public function set maximizeButton(param1:Button) : void
        {
            var _loc_2:* = this._488002274maximizeButton;
            if (_loc_2 !== param1)
            {
                this._488002274maximizeButton = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "maximizeButton", _loc_2, param1));
            }
            return;
        }// end function

        private function _ChatPanel_DataGridColumn2_i() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            this._ChatPanel_DataGridColumn2 = _loc_1;
            _loc_1.resizable = false;
            _loc_1.draggable = false;
            _loc_1.width = 80;
            _loc_1.dataField = "costs";
            _loc_1.itemRenderer = this._ChatPanel_ClassFactory4_c();
            BindingManager.executeBindings(this, "_ChatPanel_DataGridColumn2", this._ChatPanel_DataGridColumn2);
            return _loc_1;
        }// end function

        public function deactivateWhisper() : void
        {
            this.privateList.visible = false;
            this.privatedetailsHeader.visible = false;
            this.privateList.height = 0;
            return;
        }// end function

        public function get currentOfferBox() : HBox
        {
            return this._1484920424currentOfferBox;
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

        private function _ChatPanel_ClassFactory6_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = ChannelBarItemRenderer;
            return _loc_1;
        }// end function

        public function set btnUpdateOffers(param1:StandardButton) : void
        {
            var _loc_2:* = this._82641980btnUpdateOffers;
            if (_loc_2 !== param1)
            {
                this._82641980btnUpdateOffers = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnUpdateOffers", _loc_2, param1));
            }
            return;
        }// end function

        public function set chatstatusboxicon(param1:Image) : void
        {
            var _loc_2:* = this._1755722810chatstatusboxicon;
            if (_loc_2 !== param1)
            {
                this._1755722810chatstatusboxicon = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "chatstatusboxicon", _loc_2, param1));
            }
            return;
        }// end function

        public function set chatstatusbox(param1:HBox) : void
        {
            var _loc_2:* = this._43974591chatstatusbox;
            if (_loc_2 !== param1)
            {
                this._43974591chatstatusbox = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "chatstatusbox", _loc_2, param1));
            }
            return;
        }// end function

        public function get messageHistory() : ChatHistoryList
        {
            return this._1784002189messageHistory;
        }// end function

        private function _ChatPanel_RemoveChild1_i() : RemoveChild
        {
            var _loc_1:* = new RemoveChild();
            this._ChatPanel_RemoveChild1 = _loc_1;
            BindingManager.executeBindings(this, "_ChatPanel_RemoveChild1", this._ChatPanel_RemoveChild1);
            return _loc_1;
        }// end function

        private function _ChatPanel_DataGridColumn1_i() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            this._ChatPanel_DataGridColumn1 = _loc_1;
            _loc_1.resizable = false;
            _loc_1.draggable = false;
            _loc_1.width = 80;
            _loc_1.dataField = "offer";
            _loc_1.itemRenderer = this._ChatPanel_ClassFactory3_c();
            BindingManager.executeBindings(this, "_ChatPanel_DataGridColumn1", this._ChatPanel_DataGridColumn1);
            return _loc_1;
        }// end function

        public function set chatInput(param1:CustomInput) : void
        {
            var _loc_2:* = this._1599613778chatInput;
            if (_loc_2 !== param1)
            {
                this._1599613778chatInput = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "chatInput", _loc_2, param1));
            }
            return;
        }// end function

        public function set chatstatusboxlabel(param1:Label) : void
        {
            var _loc_2:* = this._1404469421chatstatusboxlabel;
            if (_loc_2 !== param1)
            {
                this._1404469421chatstatusboxlabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "chatstatusboxlabel", _loc_2, param1));
            }
            return;
        }// end function

        private function _ChatPanel_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.fadeIn;
            _loc_1 = this.fadeOut;
            _loc_1 = this.chatstatusbox;
            _loc_1 = this.selectedChannel.messages;
            _loc_1 = this.enabled;
            _loc_1 = this.enabled;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ChatAutoScroll");
            _loc_1 = this.messageHistory.autoscroll;
            _loc_1 = new ArrayCollection();
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.CHAT_MESSAGES, "ClientServerConnecting");
            _loc_1 = [];
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Offer");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Costs");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "From");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Update");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "SendTradeRequest");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "TradeCurrentOffer");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "TradeOfferClear");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "TradeOfferAdd");
            _loc_1 = gAssetManager.GetClass("HalfTime");
            _loc_1 = this.chatstatusboxicon;
            _loc_1 = this.chatstatusboxicon.x + this.chatstatusboxicon.width / 2;
            _loc_1 = this.chatstatusboxicon.x + this.chatstatusboxicon.height / 2;
            _loc_1 = new ArrayCollection();
            return;
        }// end function

        private function _ChatPanel_Rotate1_i() : Rotate
        {
            var _loc_1:* = new Rotate();
            this.rotate = _loc_1;
            _loc_1.angleFrom = 0;
            _loc_1.angleTo = 360;
            _loc_1.duration = 1000;
            _loc_1.repeatCount = 0;
            _loc_1.easingFunction = Linear.easeNone;
            BindingManager.executeBindings(this, "rotate", this.rotate);
            return _loc_1;
        }// end function

        protected function HandleScrollUp(event:Event) : void
        {
            this.messageHistory.ScrollList(-3);
            return;
        }// end function

        private function StopResizing(event:MouseEvent) : void
        {
            this.resizing = false;
            this.expandedHeight = this.height;
            if (!this.hitTestPoint(event.stageX, event.stageY))
            {
                this.SetAlpha(1);
            }
            Application.application.removeEventListener(MouseEvent.MOUSE_UP, this.StopResizing);
            Application.application.removeEventListener(MouseEvent.ROLL_OUT, this.StopResizing);
            Application.application.removeEventListener(MouseEvent.MOUSE_MOVE, this.Resize);
            return;
        }// end function

        public function set rotate(param1:Rotate) : void
        {
            var _loc_2:* = this._925180581rotate;
            if (_loc_2 !== param1)
            {
                this._925180581rotate = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "rotate", _loc_2, param1));
            }
            return;
        }// end function

        private function _ChatPanel_Fade4_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeInRollOver = _loc_1;
            _loc_1.alphaFrom = 0;
            _loc_1.alphaTo = 1;
            _loc_1.duration = 150;
            return _loc_1;
        }// end function

        private function Expand() : void
        {
            this.currentState = "";
            this.parent.height = this.expandedHeight;
            this.setStyle("backgroundImage", gAssetManager.GetClass("ChatTab"));
            this.setStyle("backgroundSize", "100%");
            this.minimizeButton.visible = true;
            this.maximizeButton.visible = false;
            return;
        }// end function

        private function _ChatPanel_ClassFactory5_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = TradeGridPlayerItemRenderer;
            return _loc_1;
        }// end function

        public function get btnAddOffer() : StandardButton
        {
            return this._528790711btnAddOffer;
        }// end function

        public function get fadeIn() : Fade
        {
            return this._1282133823fadeIn;
        }// end function

        public function get privatedetailsHeader() : Canvas
        {
            return this._701607628privatedetailsHeader;
        }// end function

        public function get autoScrollBox() : StandardCheckBox
        {
            return this._676870449autoScrollBox;
        }// end function

        protected function HandleScrollUpStop(event:Event) : void
        {
            Application.application.removeEventListener(Event.ENTER_FRAME, this.HandleScrollUp);
            Application.application.removeEventListener(MouseEvent.MOUSE_UP, this.HandleScrollUpStop);
            return;
        }// end function

        private function StartResizing(event:MouseEvent) : void
        {
            if (event.stageY > this.parent.y && event.stageY < this.parent.y + 11 && this.currentState != "minimized")
            {
                this.resizing = true;
                this.offset = event.localY;
                Application.application.addEventListener(MouseEvent.MOUSE_UP, this.StopResizing);
                Application.application.addEventListener(MouseEvent.ROLL_OUT, this.StopResizing);
                Application.application.addEventListener(MouseEvent.MOUSE_MOVE, this.Resize);
            }
            return;
        }// end function

        private function Resize(event:MouseEvent) : void
        {
            var _loc_2:* = Application.application.height - event.stageY - (this.parent as Canvas).getConstraintValue("bottom") + this.offset;
            var _loc_3:int = 220;
            if (event.stageY - this.offset > 0)
            {
                if (event.stageY - this.offset < Application.application.height - (this.parent as Canvas).getConstraintValue("bottom") - _loc_3)
                {
                    this.parent.height = _loc_2;
                }
                else
                {
                    this.parent.height = _loc_3;
                }
            }
            return;
        }// end function

        public function set currentOfferBox(param1:HBox) : void
        {
            var _loc_2:* = this._1484920424currentOfferBox;
            if (_loc_2 !== param1)
            {
                this._1484920424currentOfferBox = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "currentOfferBox", _loc_2, param1));
            }
            return;
        }// end function

        public function ___ChatPanel_Button5_mouseDown(event:MouseEvent) : void
        {
            this.button3_clickHandler(event);
            return;
        }// end function

        public function get btnResetCooldown() : StandardButton
        {
            return this._475811618btnResetCooldown;
        }// end function

        public function get fadeInRollOver() : Fade
        {
            return this._1884483282fadeInRollOver;
        }// end function

        public function get privateList() : CustomTileList
        {
            return this._1971376321privateList;
        }// end function

        private function _ChatPanel_Fade3_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeOutRollOut = _loc_1;
            _loc_1.alphaFrom = 0;
            _loc_1.alphaTo = 1;
            _loc_1.duration = 150;
            return _loc_1;
        }// end function

        public function set currentCostsResource(param1:TradeResourceItemRenderer) : void
        {
            var _loc_2:* = this._620975237currentCostsResource;
            if (_loc_2 !== param1)
            {
                this._620975237currentCostsResource = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "currentCostsResource", _loc_2, param1));
            }
            return;
        }// end function

        public function get tradeChannel() : Canvas
        {
            return this._805270785tradeChannel;
        }// end function

        private function _ChatPanel_ClassFactory4_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = TradeGridResourceItemRenderer;
            return _loc_1;
        }// end function

        public function __maximizeButton_click(event:MouseEvent) : void
        {
            this.MinMaxClickHandler();
            return;
        }// end function

        public function set buttonBar(param1:ChannelBar) : void
        {
            var _loc_2:* = this._11548545buttonBar;
            if (_loc_2 !== param1)
            {
                this._11548545buttonBar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "buttonBar", _loc_2, param1));
            }
            return;
        }// end function

        protected function button3_clickHandler(event:MouseEvent) : void
        {
            Application.application.addEventListener(Event.ENTER_FRAME, this.HandleScrollDown);
            Application.application.addEventListener(MouseEvent.MOUSE_UP, this.HandleScrollDownStop);
            return;
        }// end function

        public function activateWhisper() : void
        {
            this.privateList.visible = true;
            this.privatedetailsHeader.visible = true;
            this.privateList.height = 51;
            return;
        }// end function

        public function set btnClearTradeOffer(param1:StandardButton) : void
        {
            var _loc_2:* = this._1089764471btnClearTradeOffer;
            if (_loc_2 !== param1)
            {
                this._1089764471btnClearTradeOffer = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnClearTradeOffer", _loc_2, param1));
            }
            return;
        }// end function

        public function __buttonBar_itemClick(event:ListEvent) : void
        {
            if (this.currentState == "minimized")
            {
                this.Expand();
            }
            return;
        }// end function

        public function set minimizeButton(param1:Button) : void
        {
            var _loc_2:* = this._168913776minimizeButton;
            if (_loc_2 !== param1)
            {
                this._168913776minimizeButton = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "minimizeButton", _loc_2, param1));
            }
            return;
        }// end function

        public function set messageHistory(param1:ChatHistoryList) : void
        {
            var _loc_2:* = this._1784002189messageHistory;
            if (_loc_2 !== param1)
            {
                this._1784002189messageHistory = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "messageHistory", _loc_2, param1));
            }
            return;
        }// end function

        public function get scaleButton() : Button
        {
            return this._1305707236scaleButton;
        }// end function

        public function get maximizeButton() : Button
        {
            return this._488002274maximizeButton;
        }// end function

        public function set currentOfferResource(param1:TradeResourceItemRenderer) : void
        {
            var _loc_2:* = this._1337132433currentOfferResource;
            if (_loc_2 !== param1)
            {
                this._1337132433currentOfferResource = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "currentOfferResource", _loc_2, param1));
            }
            return;
        }// end function

        public function set vbox(param1:VBox) : void
        {
            var _loc_2:* = this._3613077vbox;
            if (_loc_2 !== param1)
            {
                this._3613077vbox = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "vbox", _loc_2, param1));
            }
            return;
        }// end function

        private function _ChatPanel_Fade2_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeOut = _loc_1;
            _loc_1.alphaFrom = 1;
            _loc_1.alphaTo = 0;
            _loc_1.duration = 150;
            return _loc_1;
        }// end function

        private function Init() : void
        {
            SWMMOChatMessage.enable();
            if (CustomChatMessage.STYLESHEET == null)
            {
                CustomChatMessage.STYLESHEET = new StyleSheet();
                CustomChatMessage.STYLESHEET.parseCSS(new CSSFile().toString());
            }
            this.expandedHeight = this.height;
            this.setStyle("backgroundImage", gAssetManager.GetClass("ChatTab"));
            this.setStyle("backgroundSize", "100%");
            this.addEventListener(MouseEvent.MOUSE_DOWN, this.StartResizing);
            this.SetAlpha(1);
            this.rotate.play();
            return;
        }// end function

        public function get whispers() : IBFList
        {
            return this.privateList;
        }// end function

        public function get fadeOut() : Fade
        {
            return this._1091436750fadeOut;
        }// end function

        private function _ChatPanel_ClassFactory3_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = TradeGridResourceItemRenderer;
            return _loc_1;
        }// end function

        public function ___ChatPanel_Canvas1_creationComplete(event:FlexEvent) : void
        {
            this.Init();
            return;
        }// end function

        protected function button2_clickHandler(event:MouseEvent) : void
        {
            Application.application.addEventListener(Event.ENTER_FRAME, this.HandleScrollUp);
            Application.application.addEventListener(MouseEvent.MOUSE_UP, this.HandleScrollUpStop);
            return;
        }// end function

        public function get chatInput() : CustomInput
        {
            return this._1599613778chatInput;
        }// end function

        public function get chatstatusboxlabel() : Label
        {
            return this._1404469421chatstatusboxlabel;
        }// end function

        public function get rotate() : Rotate
        {
            return this._925180581rotate;
        }// end function

        private function _ChatPanel_Fade1_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeIn = _loc_1;
            _loc_1.alphaFrom = 0;
            _loc_1.alphaTo = 1;
            _loc_1.duration = 150;
            return _loc_1;
        }// end function

        public function set btnAddOffer(param1:StandardButton) : void
        {
            var _loc_2:* = this._528790711btnAddOffer;
            if (_loc_2 !== param1)
            {
                this._528790711btnAddOffer = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnAddOffer", _loc_2, param1));
            }
            return;
        }// end function

        public function get minimizeButton() : Button
        {
            return this._168913776minimizeButton;
        }// end function

        private function _ChatPanel_ClassFactory2_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = ChatTabPrivateListItemRenderer;
            return _loc_1;
        }// end function

        protected function HandleScrollDown(event:Event) : void
        {
            this.messageHistory.ScrollList(3);
            return;
        }// end function

        public function get currentCostsResource() : TradeResourceItemRenderer
        {
            return this._620975237currentCostsResource;
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

        public function get buttonBar() : ChannelBar
        {
            return this._11548545buttonBar;
        }// end function

        public function get btnClearTradeOffer() : StandardButton
        {
            return this._1089764471btnClearTradeOffer;
        }// end function

        override public function initialize() : void
        {
            var target:ChatPanel;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._ChatPanel_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ChatPanelWatcherSetupUtil");
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

        public function get currentOfferResource() : TradeResourceItemRenderer
        {
            return this._1337132433currentOfferResource;
        }// end function

        private function MinMaxClickHandler() : void
        {
            if (this.currentState == "minimized")
            {
                this.Expand();
            }
            else
            {
                this.Collapse();
            }
            return;
        }// end function

        public function get vbox() : VBox
        {
            return this._3613077vbox;
        }// end function

        public function set privatedetailsHeader(param1:Canvas) : void
        {
            var _loc_2:* = this._701607628privatedetailsHeader;
            if (_loc_2 !== param1)
            {
                this._701607628privatedetailsHeader = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "privatedetailsHeader", _loc_2, param1));
            }
            return;
        }// end function

        public function set fadeInRollOver(param1:Fade) : void
        {
            var _loc_2:* = this._1884483282fadeInRollOver;
            if (_loc_2 !== param1)
            {
                this._1884483282fadeInRollOver = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "fadeInRollOver", _loc_2, param1));
            }
            return;
        }// end function

        protected function button1_clickHandler(event:MouseEvent) : void
        {
            this.messageHistory.autoscroll = (event.target as CheckBox).selected;
            return;
        }// end function

        public function set privateList(param1:CustomTileList) : void
        {
            var _loc_2:* = this._1971376321privateList;
            if (_loc_2 !== param1)
            {
                this._1971376321privateList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "privateList", _loc_2, param1));
            }
            return;
        }// end function

        private function _ChatPanel_ClassFactory1_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = CustomChatMessage;
            return _loc_1;
        }// end function

        public function __scaleButton_mouseDown(event:MouseEvent) : void
        {
            this.StartResizing(event);
            return;
        }// end function

        public function set autoScrollBox(param1:StandardCheckBox) : void
        {
            var _loc_2:* = this._676870449autoScrollBox;
            if (_loc_2 !== param1)
            {
                this._676870449autoScrollBox = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "autoScrollBox", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnResetCooldown(param1:StandardButton) : void
        {
            var _loc_2:* = this._475811618btnResetCooldown;
            if (_loc_2 !== param1)
            {
                this._475811618btnResetCooldown = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnResetCooldown", _loc_2, param1));
            }
            return;
        }// end function

        private function _ChatPanel_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function ()
            {
                return fadeIn;
            }// end function
            , function (param1) : void
            {
                null.setStyle(this, param1);
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
                this.setStyle("hideEffect", param1);
                return;
            }// end function
            , "this.hideEffect");
            result[1] = binding;
            binding = new Binding(this, function () : DisplayObject
            {
                return chatstatusbox;
            }// end function
            , function (param1:DisplayObject) : void
            {
                null.target = param1;
                return;
            }// end function
            , "_ChatPanel_RemoveChild1.target");
            result[2] = binding;
            binding = new Binding(this, function () : Object
            {
                return this.selectedChannel.messages;
            }// end function
            , function (param1:Object) : void
            {
                null.dataProvider = null;
                return;
            }// end function
            , "messageHistory.dataProvider");
            result[3] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return this.enabled;
            }// end function
            , function (param1:Boolean) : void
            {
                null.enabled = param1;
                return;
            }// end function
            , "_ChatPanel_Button4.enabled");
            result[4] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return this.enabled;
            }// end function
            , function (param1:Boolean) : void
            {
                null.enabled = null;
                return;
            }// end function
            , "_ChatPanel_Button5.enabled");
            result[5] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "ChatAutoScroll");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                autoScrollBox.toolTip = param1;
                return;
            }// end function
            , "autoScrollBox.toolTip");
            result[6] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return messageHistory.autoscroll;
            }// end function
            , function (param1:Boolean) : void
            {
                autoScrollBox.selected = param1;
                return;
            }// end function
            , "autoScrollBox.selected");
            result[7] = binding;
            binding = new Binding(this, function () : Object
            {
                return new ArrayCollection();
            }// end function
            , function (param1:Object) : void
            {
                privateList.dataProvider = param1;
                return;
            }// end function
            , "privateList.dataProvider");
            result[8] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.CHAT_MESSAGES, "ClientServerConnecting");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "chatstatusboxlabel.text");
            result[9] = binding;
            binding = new Binding(this, function () : Array
            {
                return [];
            }// end function
            , function (param1:Array) : void
            {
                tradeOffers.setStyle("alternatingItemColors", param1);
                return;
            }// end function
            , "tradeOffers.alternatingItemColors");
            result[10] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Offer");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.headerText = null;
                return;
            }// end function
            , "_ChatPanel_DataGridColumn1.headerText");
            result[11] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "Costs");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.headerText = param1;
                return;
            }// end function
            , "_ChatPanel_DataGridColumn2.headerText");
            result[12] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "From");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.headerText = null;
                return;
            }// end function
            , "_ChatPanel_DataGridColumn3.headerText");
            result[13] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "Update");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnUpdateOffers.label");
            result[14] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "SendTradeRequest");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                btnSendTrade.label = param1;
                return;
            }// end function
            , "btnSendTrade.label");
            result[15] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "TradeCurrentOffer");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "_ChatPanel_Label2.text");
            result[16] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "TradeOfferClear");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnClearTradeOffer.label");
            result[17] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "TradeOfferAdd");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnAddOffer.label");
            result[18] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("HalfTime");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnResetCooldown.icon");
            result[19] = binding;
            binding = new Binding(this, function () : Object
            {
                return chatstatusboxicon;
            }// end function
            , function (param1:Object) : void
            {
                null.target = null;
                return;
            }// end function
            , "rotate.target");
            result[20] = binding;
            binding = new Binding(this, function () : Number
            {
                return null.x + chatstatusboxicon.width / 2;
            }// end function
            , function (param1:Number) : void
            {
                rotate.originX = param1;
                return;
            }// end function
            , "rotate.originX");
            result[21] = binding;
            binding = new Binding(this, function () : Number
            {
                return null + chatstatusboxicon.height / 2;
            }// end function
            , function (param1:Number) : void
            {
                null.originY = null;
                return;
            }// end function
            , "rotate.originY");
            result[22] = binding;
            binding = new Binding(this, function () : Object
            {
                return new ArrayCollection();
            }// end function
            , function (param1:Object) : void
            {
                null.dataProvider = null;
                return;
            }// end function
            , "buttonBar.dataProvider");
            result[23] = binding;
            return result;
        }// end function

        public function __tradeOffers_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function get btnSendTrade() : StandardButton
        {
            return this._643911744btnSendTrade;
        }// end function

        private function Collapse() : void
        {
            this.expandedHeight = this.parent.height;
            this.currentState = "minimized";
            this.setStyle("backgroundImage", gAssetManager.GetClass("ChatTabMinimized"));
            this.setStyle("backgroundSize", "100%");
            this.minimizeButton.visible = false;
            this.maximizeButton.visible = true;
            this.parent.height = 70;
            return;
        }// end function

        public function set selectedChannel(param1:ChannelVO) : void
        {
            var _loc_2:* = this.selectedChannel;
            if (_loc_2 !== param1)
            {
                this._174067176selectedChannel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "selectedChannel", _loc_2, param1));
            }
            return;
        }// end function

        private function _ChatPanel_State1_c() : State
        {
            var _loc_1:* = new State();
            _loc_1.name = "minimized";
            _loc_1.overrides = [this._ChatPanel_RemoveChild1_i()];
            return _loc_1;
        }// end function

        public function __minimizeButton_click(event:MouseEvent) : void
        {
            this.MinMaxClickHandler();
            return;
        }// end function

        public function get selectedChannel() : ChannelVO
        {
            return this.mSelectedChannel;
        }// end function

        public function set fadeOutRollOut(param1:Fade) : void
        {
            var _loc_2:* = this._183043583fadeOutRollOut;
            if (_loc_2 !== param1)
            {
                this._183043583fadeOutRollOut = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "fadeOutRollOut", _loc_2, param1));
            }
            return;
        }// end function

        public function get fadeOutRollOut() : Fade
        {
            return this._183043583fadeOutRollOut;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            ChatPanel._watcherSetupUtil = param1;
            return;
        }// end function

    }
}
