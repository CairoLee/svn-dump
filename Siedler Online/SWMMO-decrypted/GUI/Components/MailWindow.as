package GUI.Components
{
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.DataGrid.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import flash.display.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.controls.dataGridClasses.*;
    import mx.core.*;
    import mx.events.*;
    import mx.states.*;

    public class MailWindow extends BasicPanel implements IBindingClient
    {
        public var _MailWindow_Label4:Label;
        private var _821604459contentTrade:Canvas;
        private var _1190827904contentAdventureInvite:Canvas;
        private var _2095988206btnReply:Button;
        private var _151526158friendInvitationInfoText:Text;
        public var _MailWindow_Label7:Label;
        public var _MailWindow_Label1:Label;
        private var _1485434818btnGuildRequestDecline:StandardButton;
        private var _1053444476btnFriendDecline:StandardButton;
        private var _920304973buffedInfoText:Text;
        var _bindingsByDestination:Object;
        private var _206189572btnSend:StandardButton;
        private var _1571200404guildIncreaseButtons:HBox;
        private var _823564144contentFriendInvitation:Canvas;
        private var _632301194offerResource:TradeResourceItemRenderer;
        private var _542559094adventureTodo:Text;
        private var _2100227641subcontent:VBox;
        private var _448280449tradeInfoText:Text;
        private var _389538019contentGems:Canvas;
        private var _1148819822btnTradeDecline:StandardButton;
        private var _1572676149contentGuildRequest:Canvas;
        private var _551124323btnReplay:StandardButton;
        private var _1175114225toInput:TextInput;
        private var _2041813227offerItemTrade:HBox;
        private var _875838146mailContent:ViewStack;
        private var _291002278mailsList:CustomDataGrid;
        private var _1529844226subjectInput:TextInput;
        private var _2034009179btnAdventureInviteAccept:StandardButton;
        private var _1395382469guildRequestButtons:HBox;
        private var _791496620adventureInviteInfoText:Text;
        private var _1681735474gemsResource:TradeResourceItemRenderer;
        private var _1702646255bodyText:TextArea;
        private var _1123239400contentFriendRequest:Canvas;
        private var _1602032215editText:TextArea;
        private var _2086341061stateEdit:State;
        public var _MailWindow_StandardButton2:StandardButton;
        public var _MailWindow_RemoveChild1:RemoveChild;
        private var _655478139btnNewMail:StandardButton;
        private var _1527474904subjectLabel:Label;
        private var _204771335btnAdventureInviteDecline:StandardButton;
        var _bindingsBeginWithWord:Object;
        private var _1122683948friendRequestInfoText:Text;
        private var _1044724955contentBattleReport:Canvas;
        private var _1062952084btnFriendInvitationSendRequest:StandardButton;
        private var _1944015055offerBuff:StarMenuItemRenderer;
        private var _1801856499tradeDeclineInfoText:Text;
        private var _1798226240btnGuildRequestAccept:StandardButton;
        private var _1887180115contentTradeAccept:Canvas;
        private var _1325806476costsResource:TradeResourceItemRenderer;
        private var _894203876reciepientList:List;
        private var _688277242buffedBuilding:Image;
        private var _224902324btnAcceptLoot:StandardButton;
        private var _695688944friendInvitationAvatar:AvatarListItemRenderer;
        public var _MailWindow_Image1:Image;
        private var _1307817904btnAcceptCostsResource:StandardButton;
        private var _1093012491contentTradeDecline:Canvas;
        private var _1191904423battleReportText:TextArea;
        private var _650289766btnAcceptOfferResource:StandardButton;
        private var _1184245415tradeAcceptInfoText:Text;
        private var _664767253lootAcceptInfoText:Text;
        private var _389363248contentMail:Canvas;
        private var _853018207declinedBuff:StarMenuItemRenderer;
        private var _1775181318btnGuildIncreaseSize:StandardButton;
        private var _1851797616btnTradeAccept:StandardButton;
        private var _1892806565buffedBuff:StarMenuItemRenderer;
        private var _1593124407guildRequestInfoText:CustomText;
        private var _436988324declinedResource:TradeResourceItemRenderer;
        public var _MailWindow_DataGridColumn1:DataGridColumn;
        public var _MailWindow_DataGridColumn2:DataGridColumn;
        public var _MailWindow_DataGridColumn3:DataGridColumn;
        public var _MailWindow_DataGridColumn4:DataGridColumn;
        private var _1805383481missionHeader:Canvas;
        private var _2123879298itemsList:HBox;
        private var _361883074btnFriendAccept:StandardButton;
        private var _2094231009gemsInfoText:Text;
        private var _1440651116difficultyIndicator:AdventureDifficultyIndicator;
        var _watchers:Array;
        private var _458905385contentLootAccept:Canvas;
        private var _812468725contentBuffed:Canvas;
        public var _MailWindow_AddChild1:AddChild;
        public var _MailWindow_AddChild2:AddChild;
        private var _1154862891acceptedResource:TradeResourceItemRenderer;
        private var _151453800offerTrade:HBox;
        private var _1047735924itemsHolder:HBox;
        private var _895480118friendRequestAvatar:AvatarListItemRenderer;
        public var _MailWindow_Label2:Label;
        public var _MailWindow_Label5:Label;
        public var _MailWindow_Label6:Label;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function MailWindow()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:BasicPanel, propertiesFactory:function () : Object
            {
                return {null:null, height:400};
            }// end function
            });
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.width = 600;
            this.height = 400;
            this.states = [this._MailWindow_State1_i()];
            this.subComponents = [this._MailWindow_VBox2_i()];
            return;
        }// end function

        public function set btnGuildIncreaseSize(param1:StandardButton) : void
        {
            var _loc_2:* = this._1775181318btnGuildIncreaseSize;
            if (_loc_2 !== param1)
            {
                this._1775181318btnGuildIncreaseSize = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnGuildIncreaseSize", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnSend() : StandardButton
        {
            return this._206189572btnSend;
        }// end function

        public function set btnSend(param1:StandardButton) : void
        {
            var _loc_2:* = this._206189572btnSend;
            if (_loc_2 !== param1)
            {
                this._206189572btnSend = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnSend", _loc_2, param1));
            }
            return;
        }// end function

        public function get contentTradeDecline() : Canvas
        {
            return this._1093012491contentTradeDecline;
        }// end function

        public function set contentBuffed(param1:Canvas) : void
        {
            var _loc_2:* = this._812468725contentBuffed;
            if (_loc_2 !== param1)
            {
                this._812468725contentBuffed = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "contentBuffed", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_StandardButton17_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnGuildIncreaseSize = _loc_1;
            _loc_1.width = 150;
            _loc_1.height = 32;
            _loc_1.id = "btnGuildIncreaseSize";
            BindingManager.executeBindings(this, "btnGuildIncreaseSize", this.btnGuildIncreaseSize);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set tradeDeclineInfoText(param1:Text) : void
        {
            var _loc_2:* = this._1801856499tradeDeclineInfoText;
            if (_loc_2 !== param1)
            {
                this._1801856499tradeDeclineInfoText = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "tradeDeclineInfoText", _loc_2, param1));
            }
            return;
        }// end function

        public function set contentTradeDecline(param1:Canvas) : void
        {
            var _loc_2:* = this._1093012491contentTradeDecline;
            if (_loc_2 !== param1)
            {
                this._1093012491contentTradeDecline = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "contentTradeDecline", _loc_2, param1));
            }
            return;
        }// end function

        public function set subjectInput(param1:TextInput) : void
        {
            var _loc_2:* = this._1529844226subjectInput;
            if (_loc_2 !== param1)
            {
                this._1529844226subjectInput = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "subjectInput", _loc_2, param1));
            }
            return;
        }// end function

        public function set toInput(param1:TextInput) : void
        {
            var _loc_2:* = this._1175114225toInput;
            if (_loc_2 !== param1)
            {
                this._1175114225toInput = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "toInput", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_Canvas3_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.setStyle("left", "6");
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "60");
            _loc_1.setStyle("bottom", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_TextArea1_i());
            return _loc_1;
        }// end function

        private function _MailWindow_AddChild2_i() : AddChild
        {
            var _loc_1:* = new AddChild();
            this._MailWindow_AddChild2 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._MailWindow_List1_i);
            BindingManager.executeBindings(this, "_MailWindow_AddChild2", this._MailWindow_AddChild2);
            return _loc_1;
        }// end function

        private function _MailWindow_VBox5_c() : VBox
        {
            var _loc_1:* = new VBox();
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_StandardButton12_i());
            _loc_1.addChild(this._MailWindow_Spacer4_c());
            return _loc_1;
        }// end function

        public function get friendRequestInfoText() : Text
        {
            return this._1122683948friendRequestInfoText;
        }// end function

        public function __btnTradeAccept_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, !this.btnTradeAccept.enabled);
            return;
        }// end function

        public function get btnGuildRequestDecline() : StandardButton
        {
            return this._1485434818btnGuildRequestDecline;
        }// end function

        public function set contentFriendRequest(param1:Canvas) : void
        {
            var _loc_2:* = this._1123239400contentFriendRequest;
            if (_loc_2 !== param1)
            {
                this._1123239400contentFriendRequest = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "contentFriendRequest", _loc_2, param1));
            }
            return;
        }// end function

        public function formatDate(param1:Object, param2:DataGridColumn) : String
        {
            return cLocaManager.GetInstance().FormatDate(param1.timestamp).toString();
        }// end function

        public function get btnAcceptCostsResource() : StandardButton
        {
            return this._1307817904btnAcceptCostsResource;
        }// end function

        public function get adventureInviteInfoText() : Text
        {
            return this._791496620adventureInviteInfoText;
        }// end function

        private function _MailWindow_StandardButton16_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnGuildRequestDecline = _loc_1;
            _loc_1.width = 70;
            _loc_1.height = 32;
            _loc_1.id = "btnGuildRequestDecline";
            BindingManager.executeBindings(this, "btnGuildRequestDecline", this.btnGuildRequestDecline);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get mailsList() : CustomDataGrid
        {
            return this._291002278mailsList;
        }// end function

        public function set friendRequestInfoText(param1:Text) : void
        {
            var _loc_2:* = this._1122683948friendRequestInfoText;
            if (_loc_2 !== param1)
            {
                this._1122683948friendRequestInfoText = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "friendRequestInfoText", _loc_2, param1));
            }
            return;
        }// end function

        public function set gemsInfoText(param1:Text) : void
        {
            var _loc_2:* = this._2094231009gemsInfoText;
            if (_loc_2 !== param1)
            {
                this._2094231009gemsInfoText = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "gemsInfoText", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_Canvas2_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.percentWidth = 100;
            _loc_1.height = 60;
            _loc_1.styleName = "detailsHeader";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_Label1_i());
            _loc_1.addChild(this._MailWindow_TextInput1_i());
            _loc_1.addChild(this._MailWindow_Label2_i());
            _loc_1.addChild(this._MailWindow_TextInput2_i());
            return _loc_1;
        }// end function

        private function _MailWindow_AddChild1_i() : AddChild
        {
            var _loc_1:* = new AddChild();
            this._MailWindow_AddChild1 = _loc_1;
            _loc_1.position = "lastChild";
            _loc_1.targetFactory = new DeferredInstanceFromFunction(this._MailWindow_VBox1_c);
            BindingManager.executeBindings(this, "_MailWindow_AddChild1", this._MailWindow_AddChild1);
            return _loc_1;
        }// end function

        public function get offerTrade() : HBox
        {
            return this._151453800offerTrade;
        }// end function

        private function _MailWindow_VBox4_c() : VBox
        {
            var _loc_1:* = new VBox();
            _loc_1.setStyle("left", "24");
            _loc_1.setStyle("right", "24");
            _loc_1.setStyle("top", "5");
            _loc_1.setStyle("bottom", "5");
            _loc_1.setStyle("horizontalAlign", "center");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_Text6_i());
            _loc_1.addChild(this._MailWindow_HBox11_i());
            return _loc_1;
        }// end function

        public function get contentTrade() : Canvas
        {
            return this._821604459contentTrade;
        }// end function

        public function set contentGuildRequest(param1:Canvas) : void
        {
            var _loc_2:* = this._1572676149contentGuildRequest;
            if (_loc_2 !== param1)
            {
                this._1572676149contentGuildRequest = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "contentGuildRequest", _loc_2, param1));
            }
            return;
        }// end function

        public function set subcontent(param1:VBox) : void
        {
            var _loc_2:* = this._2100227641subcontent;
            if (_loc_2 !== param1)
            {
                this._2100227641subcontent = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "subcontent", _loc_2, param1));
            }
            return;
        }// end function

        public function set guildRequestInfoText(param1:CustomText) : void
        {
            var _loc_2:* = this._1593124407guildRequestInfoText;
            if (_loc_2 !== param1)
            {
                this._1593124407guildRequestInfoText = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "guildRequestInfoText", _loc_2, param1));
            }
            return;
        }// end function

        public function get costsResource() : TradeResourceItemRenderer
        {
            return this._1325806476costsResource;
        }// end function

        public function set btnGuildRequestDecline(param1:StandardButton) : void
        {
            var _loc_2:* = this._1485434818btnGuildRequestDecline;
            if (_loc_2 !== param1)
            {
                this._1485434818btnGuildRequestDecline = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnGuildRequestDecline", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_Text9_i() : Text
        {
            var _loc_1:* = new Text();
            this.buffedInfoText = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("left", "24");
            _loc_1.setStyle("right", "24");
            _loc_1.setStyle("top", "5");
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "buffedInfoText";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get itemsList() : HBox
        {
            return this._2123879298itemsList;
        }// end function

        public function get tradeInfoText() : Text
        {
            return this._448280449tradeInfoText;
        }// end function

        public function get contentAdventureInvite() : Canvas
        {
            return this._1190827904contentAdventureInvite;
        }// end function

        private function _MailWindow_CustomText1_i() : CustomText
        {
            var _loc_1:* = new CustomText();
            this.guildRequestInfoText = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("left", "24");
            _loc_1.setStyle("right", "24");
            _loc_1.setStyle("top", "5");
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "guildRequestInfoText";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set stateEdit(param1:State) : void
        {
            var _loc_2:* = this._2086341061stateEdit;
            if (_loc_2 !== param1)
            {
                this._2086341061stateEdit = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "stateEdit", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_StarMenuItemRenderer3_i() : StarMenuItemRenderer
        {
            var _loc_1:* = new StarMenuItemRenderer();
            this.buffedBuff = _loc_1;
            _loc_1.setStyle("horizontalCenter", "-50");
            _loc_1.setStyle("verticalCenter", "10");
            _loc_1.id = "buffedBuff";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _MailWindow_Button1_i() : Button
        {
            var _loc_1:* = new Button();
            this.btnReply = _loc_1;
            _loc_1.visible = false;
            _loc_1.width = 25;
            _loc_1.height = 18;
            _loc_1.setStyle("right", "25");
            _loc_1.setStyle("top", "6");
            _loc_1.addEventListener("toolTipCreate", this.__btnReply_toolTipCreate);
            _loc_1.id = "btnReply";
            BindingManager.executeBindings(this, "btnReply", this.btnReply);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _MailWindow_Spacer4_c() : Spacer
        {
            var _loc_1:* = new Spacer();
            _loc_1.height = 13;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _MailWindow_StandardButton15_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnGuildRequestAccept = _loc_1;
            _loc_1.width = 70;
            _loc_1.height = 32;
            _loc_1.addEventListener("toolTipCreate", this.__btnGuildRequestAccept_toolTipCreate);
            _loc_1.id = "btnGuildRequestAccept";
            BindingManager.executeBindings(this, "btnGuildRequestAccept", this.btnGuildRequestAccept);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get btnFriendInvitationSendRequest() : StandardButton
        {
            return this._1062952084btnFriendInvitationSendRequest;
        }// end function

        public function set btnAcceptCostsResource(param1:StandardButton) : void
        {
            var _loc_2:* = this._1307817904btnAcceptCostsResource;
            if (_loc_2 !== param1)
            {
                this._1307817904btnAcceptCostsResource = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnAcceptCostsResource", _loc_2, param1));
            }
            return;
        }// end function

        public function get difficultyIndicator() : AdventureDifficultyIndicator
        {
            return this._1440651116difficultyIndicator;
        }// end function

        private function _MailWindow_Canvas1_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_Canvas2_c());
            _loc_1.addChild(this._MailWindow_Canvas3_c());
            return _loc_1;
        }// end function

        public function set adventureInviteInfoText(param1:Text) : void
        {
            var _loc_2:* = this._791496620adventureInviteInfoText;
            if (_loc_2 !== param1)
            {
                this._791496620adventureInviteInfoText = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "adventureInviteInfoText", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_VBox3_c() : VBox
        {
            var _loc_1:* = new VBox();
            _loc_1.setStyle("left", "24");
            _loc_1.setStyle("right", "24");
            _loc_1.setStyle("top", "5");
            _loc_1.setStyle("bottom", "5");
            _loc_1.setStyle("horizontalAlign", "center");
            _loc_1.setStyle("verticalGap", 2);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_Text2_i());
            _loc_1.addChild(this._MailWindow_Spacer1_c());
            _loc_1.addChild(this._MailWindow_AdventureDifficultyIndicator1_i());
            _loc_1.addChild(this._MailWindow_Canvas14_c());
            _loc_1.addChild(this._MailWindow_Spacer2_c());
            _loc_1.addChild(this._MailWindow_HBox5_c());
            _loc_1.addChild(this._MailWindow_Spacer3_c());
            return _loc_1;
        }// end function

        public function set editText(param1:TextArea) : void
        {
            var _loc_2:* = this._1602032215editText;
            if (_loc_2 !== param1)
            {
                this._1602032215editText = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "editText", _loc_2, param1));
            }
            return;
        }// end function

        public function set mailsList(param1:CustomDataGrid) : void
        {
            var _loc_2:* = this._291002278mailsList;
            if (_loc_2 !== param1)
            {
                this._291002278mailsList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mailsList", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_Text8_i() : Text
        {
            var _loc_1:* = new Text();
            this.tradeDeclineInfoText = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("left", "24");
            _loc_1.setStyle("right", "24");
            _loc_1.setStyle("top", "5");
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "tradeDeclineInfoText";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set declinedResource(param1:TradeResourceItemRenderer) : void
        {
            var _loc_2:* = this._436988324declinedResource;
            if (_loc_2 !== param1)
            {
                this._436988324declinedResource = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "declinedResource", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_StarMenuItemRenderer2_i() : StarMenuItemRenderer
        {
            var _loc_1:* = new StarMenuItemRenderer();
            this.declinedBuff = _loc_1;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "declinedBuff";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get guildRequestButtons() : HBox
        {
            return this._1395382469guildRequestButtons;
        }// end function

        public function get offerBuff() : StarMenuItemRenderer
        {
            return this._1944015055offerBuff;
        }// end function

        private function _MailWindow_Spacer3_c() : Spacer
        {
            var _loc_1:* = new Spacer();
            _loc_1.height = 2;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set contentTrade(param1:Canvas) : void
        {
            var _loc_2:* = this._821604459contentTrade;
            if (_loc_2 !== param1)
            {
                this._821604459contentTrade = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "contentTrade", _loc_2, param1));
            }
            return;
        }// end function

        public function set offerTrade(param1:HBox) : void
        {
            var _loc_2:* = this._151453800offerTrade;
            if (_loc_2 !== param1)
            {
                this._151453800offerTrade = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "offerTrade", _loc_2, param1));
            }
            return;
        }// end function

        public function set guildIncreaseButtons(param1:HBox) : void
        {
            var _loc_2:* = this._1571200404guildIncreaseButtons;
            if (_loc_2 !== param1)
            {
                this._1571200404guildIncreaseButtons = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "guildIncreaseButtons", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnAcceptOfferResource(param1:StandardButton) : void
        {
            var _loc_2:* = this._650289766btnAcceptOfferResource;
            if (_loc_2 !== param1)
            {
                this._650289766btnAcceptOfferResource = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnAcceptOfferResource", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_StandardButton14_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnAcceptOfferResource = _loc_1;
            _loc_1.height = 32;
            _loc_1.minWidth = 70;
            _loc_1.id = "btnAcceptOfferResource";
            BindingManager.executeBindings(this, "btnAcceptOfferResource", this.btnAcceptOfferResource);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get acceptedResource() : TradeResourceItemRenderer
        {
            return this._1154862891acceptedResource;
        }// end function

        public function set costsResource(param1:TradeResourceItemRenderer) : void
        {
            var _loc_2:* = this._1325806476costsResource;
            if (_loc_2 !== param1)
            {
                this._1325806476costsResource = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "costsResource", _loc_2, param1));
            }
            return;
        }// end function

        public function get lootAcceptInfoText() : Text
        {
            return this._664767253lootAcceptInfoText;
        }// end function

        private function _MailWindow_Label7_i() : Label
        {
            var _loc_1:* = new Label();
            this._MailWindow_Label7 = _loc_1;
            _loc_1.id = "_MailWindow_Label7";
            BindingManager.executeBindings(this, "_MailWindow_Label7", this._MailWindow_Label7);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get friendInvitationInfoText() : Text
        {
            return this._151526158friendInvitationInfoText;
        }// end function

        private function _MailWindow_StarMenuItemRenderer1_i() : StarMenuItemRenderer
        {
            var _loc_1:* = new StarMenuItemRenderer();
            this.offerBuff = _loc_1;
            _loc_1.id = "offerBuff";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set itemsList(param1:HBox) : void
        {
            var _loc_2:* = this._2123879298itemsList;
            if (_loc_2 !== param1)
            {
                this._2123879298itemsList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "itemsList", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_VBox2_i() : VBox
        {
            var _loc_1:* = new VBox();
            this.subcontent = _loc_1;
            _loc_1.setStyle("left", "3");
            _loc_1.setStyle("right", "3");
            _loc_1.setStyle("top", "5");
            _loc_1.setStyle("bottom", "8");
            _loc_1.id = "subcontent";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_HBox2_c());
            _loc_1.addChild(this._MailWindow_Canvas7_c());
            return _loc_1;
        }// end function

        public function set tradeInfoText(param1:Text) : void
        {
            var _loc_2:* = this._448280449tradeInfoText;
            if (_loc_2 !== param1)
            {
                this._448280449tradeInfoText = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "tradeInfoText", _loc_2, param1));
            }
            return;
        }// end function

        public function set contentAdventureInvite(param1:Canvas) : void
        {
            var _loc_2:* = this._1190827904contentAdventureInvite;
            if (_loc_2 !== param1)
            {
                this._1190827904contentAdventureInvite = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "contentAdventureInvite", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_Text7_i() : Text
        {
            var _loc_1:* = new Text();
            this.tradeAcceptInfoText = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("left", "24");
            _loc_1.setStyle("right", "24");
            _loc_1.setStyle("top", "5");
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "tradeAcceptInfoText";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get buffedBuilding() : Image
        {
            return this._688277242buffedBuilding;
        }// end function

        private function _MailWindow_ClassFactory5_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = MailGridDeleteItemRenderer;
            return _loc_1;
        }// end function

        private function _MailWindow_Spacer2_c() : Spacer
        {
            var _loc_1:* = new Spacer();
            _loc_1.height = 4;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get friendInvitationAvatar() : AvatarListItemRenderer
        {
            return this._695688944friendInvitationAvatar;
        }// end function

        private function _MailWindow_RemoveChild1_i() : RemoveChild
        {
            var _loc_1:* = new RemoveChild();
            this._MailWindow_RemoveChild1 = _loc_1;
            BindingManager.executeBindings(this, "_MailWindow_RemoveChild1", this._MailWindow_RemoveChild1);
            return _loc_1;
        }// end function

        private function _MailWindow_Canvas19_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.contentTrade = _loc_1;
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            _loc_1.styleName = "detailsContentBox";
            _loc_1.id = "contentTrade";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_Text5_i());
            _loc_1.addChild(this._MailWindow_HBox7_i());
            _loc_1.addChild(this._MailWindow_HBox8_i());
            _loc_1.addChild(this._MailWindow_HBox9_c());
            _loc_1.addChild(this._MailWindow_HBox10_c());
            return _loc_1;
        }// end function

        private function _MailWindow_Label6_i() : Label
        {
            var _loc_1:* = new Label();
            this._MailWindow_Label6 = _loc_1;
            _loc_1.id = "_MailWindow_Label6";
            BindingManager.executeBindings(this, "_MailWindow_Label6", this._MailWindow_Label6);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _MailWindow_VBox1_c() : VBox
        {
            var _loc_1:* = new VBox();
            _loc_1.setStyle("left", "3");
            _loc_1.setStyle("right", "3");
            _loc_1.setStyle("top", "5");
            _loc_1.setStyle("bottom", "5");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_Canvas1_c());
            _loc_1.addChild(this._MailWindow_HBox1_c());
            return _loc_1;
        }// end function

        public function set btnFriendInvitationSendRequest(param1:StandardButton) : void
        {
            var _loc_2:* = this._1062952084btnFriendInvitationSendRequest;
            if (_loc_2 !== param1)
            {
                this._1062952084btnFriendInvitationSendRequest = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnFriendInvitationSendRequest", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_TextArea3_i() : TextArea
        {
            var _loc_1:* = new TextArea();
            this.battleReportText = _loc_1;
            _loc_1.editable = false;
            _loc_1.selectable = false;
            _loc_1.setStyle("left", "24");
            _loc_1.setStyle("right", "24");
            _loc_1.setStyle("top", "5");
            _loc_1.setStyle("bottom", "50");
            _loc_1.setStyle("backgroundAlpha", 0);
            _loc_1.setStyle("borderThickness", 0);
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "battleReportText";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _MailWindow_StandardButton13_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnAcceptCostsResource = _loc_1;
            _loc_1.height = 32;
            _loc_1.minWidth = 70;
            _loc_1.id = "btnAcceptCostsResource";
            BindingManager.executeBindings(this, "btnAcceptCostsResource", this.btnAcceptCostsResource);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set difficultyIndicator(param1:AdventureDifficultyIndicator) : void
        {
            var _loc_2:* = this._1440651116difficultyIndicator;
            if (_loc_2 !== param1)
            {
                this._1440651116difficultyIndicator = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "difficultyIndicator", _loc_2, param1));
            }
            return;
        }// end function

        public function formatSubject(param1:Object, param2:DataGridColumn) : String
        {
            var _loc_3:Array = null;
            var _loc_4:Array = null;
            var _loc_5:Array = null;
            switch(param1.type)
            {
                case MAIL_TYPE.TRADE:
                {
                    _loc_3 = param1.subject.split(",");
                    _loc_4 = _loc_3[0].split(" ");
                    _loc_4[0] = int(_loc_4[0]).toString();
                    _loc_5 = _loc_3[1].split(" ");
                    _loc_5[0] = int(_loc_5[0]).toString();
                    return cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "TradeMailSubject", _loc_4.concat(_loc_5));
                }
                case MAIL_TYPE.ITEM_TRADE:
                {
                    _loc_3 = param1.subject.split(",");
                    _loc_4 = _loc_3[0].split(" ");
                    _loc_5 = _loc_3[1].split(" ");
                    _loc_5[0] = int(_loc_5[0]).toString();
                    return cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ItemTradeAdventureMailSubject", _loc_4.concat(_loc_5));
                }
                case MAIL_TYPE.FRIEND_REQUEST:
                {
                    return cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FriendMailSubject", [param1.senderName]);
                }
                case MAIL_TYPE.FRIEND_INVITATION_CONFIRMED:
                {
                    return cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FriendInvitationConfirmedSubject", [param1.subject]);
                }
                case MAIL_TYPE.GIFT:
                {
                    return cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GiftMailSubject", [param1.senderName]);
                }
                case MAIL_TYPE.BUFF:
                {
                    return cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GiftMailSubject", [param1.senderName]);
                }
                case MAIL_TYPE.BUFFED_BUILDING:
                {
                    return cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "BuffedBuildingMailSubject", [param1.senderName]);
                }
                case MAIL_TYPE.BUFFED_DEPOSIT:
                {
                    return cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "BuffedDepositMailSubject", [param1.senderName]);
                }
                case MAIL_TYPE.BATTLE_REPORT:
                case MAIL_TYPE.BATTLE_REPORT_INTERCEPTED:
                {
                    if (param1.subject != "")
                    {
                        return cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, MAIL_TYPE.toString(param1.type) + "AdventureMailSubject", [param1.subject]);
                    }
                    return cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, MAIL_TYPE.toString(param1.type) + "MailSubject");
                }
                case MAIL_TYPE.ACCEPT_TRADE:
                case MAIL_TYPE.ACCEPT_ITEM_TRADE:
                {
                    return cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "TradeAcceptedSubject");
                }
                case MAIL_TYPE.DECLINE_TRADE:
                case MAIL_TYPE.DECLINE_ITEM_TRADE:
                {
                    return cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "TradeDeclinedSubject");
                }
                case MAIL_TYPE.ADVENTURE_WON_LOOT:
                case MAIL_TYPE.ADVENTURE_LOST_LOOT:
                {
                    return cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "AdventureLootMailSubject", [param1.senderName]);
                }
                case MAIL_TYPE.TREASURE_LOOT:
                case MAIL_TYPE.BANDITS_LOOT:
                case MAIL_TYPE.FIND_ADVENTURE_LOOT_POSITIVE:
                case MAIL_TYPE.FIND_ADVENTURE_LOOT_NEGATIVE:
                case MAIL_TYPE.FIND_ADVENTURE_LOOT_MAP_FRAGMENT:
                case MAIL_TYPE.QUEST_LOOT:
                {
                    return cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, MAIL_TYPE.toString(param1.type) + "MailSubject");
                }
                case MAIL_TYPE.HARD_CURRENCY_PURCHASED:
                {
                    return cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "HardCurrencyAppliedSubject");
                }
                case MAIL_TYPE.INVITED_FRIEND_PURCHASED:
                {
                    return cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "InvitedFriendPurchasedSubject");
                }
                case MAIL_TYPE.GUILD_INVITE:
                {
                    return cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildInviteMailSubject", [param1.subject]);
                }
                case MAIL_TYPE.GUILD_INVITE_DECLINE:
                case MAIL_TYPE.GUILD_INVITE_FULL:
                {
                    return cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, MAIL_TYPE.toString(param1.type) + "MailSubject", [param1.senderName]);
                }
                case MAIL_TYPE.GUILD_KICK:
                case MAIL_TYPE.INVITE_TO_ADVENTURE:
                {
                    return cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, MAIL_TYPE.toString(param1.type) + "MailSubject", [param1.subject]);
                }
                default:
                {
                    return param1.subject;
                    continue;
                }
            }
        }// end function

        public function set offerResource(param1:TradeResourceItemRenderer) : void
        {
            var _loc_2:* = this._632301194offerResource;
            if (_loc_2 !== param1)
            {
                this._632301194offerResource = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "offerResource", _loc_2, param1));
            }
            return;
        }// end function

        public function get subjectLabel() : Label
        {
            return this._1527474904subjectLabel;
        }// end function

        private function _MailWindow_Text6_i() : Text
        {
            var _loc_1:* = new Text();
            this.lootAcceptInfoText = _loc_1;
            _loc_1.percentWidth = 100;
            _loc_1.selectable = false;
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "lootAcceptInfoText";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _MailWindow_ClassFactory4_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = MailGridTextItemRenderer;
            return _loc_1;
        }// end function

        private function _MailWindow_StandardButton12_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnAcceptLoot = _loc_1;
            _loc_1.width = 90;
            _loc_1.height = 32;
            _loc_1.enabled = false;
            _loc_1.addEventListener("toolTipCreate", this.__btnAcceptLoot_toolTipCreate);
            _loc_1.id = "btnAcceptLoot";
            BindingManager.executeBindings(this, "btnAcceptLoot", this.btnAcceptLoot);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get buffedInfoText() : Text
        {
            return this._920304973buffedInfoText;
        }// end function

        public function set tradeAcceptInfoText(param1:Text) : void
        {
            var _loc_2:* = this._1184245415tradeAcceptInfoText;
            if (_loc_2 !== param1)
            {
                this._1184245415tradeAcceptInfoText = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "tradeAcceptInfoText", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_Spacer1_c() : Spacer
        {
            var _loc_1:* = new Spacer();
            _loc_1.height = 4;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _MailWindow_TextInput2_i() : TextInput
        {
            var _loc_1:* = new TextInput();
            this.subjectInput = _loc_1;
            _loc_1.height = 20;
            _loc_1.styleName = "standardInput";
            _loc_1.setStyle("left", "95");
            _loc_1.setStyle("right", "15");
            _loc_1.setStyle("top", "35");
            _loc_1.id = "subjectInput";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get contentTradeAccept() : Canvas
        {
            return this._1887180115contentTradeAccept;
        }// end function

        private function _MailWindow_StandardButton9_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnFriendInvitationSendRequest = _loc_1;
            _loc_1.height = 32;
            _loc_1.id = "btnFriendInvitationSendRequest";
            BindingManager.executeBindings(this, "btnFriendInvitationSendRequest", this.btnFriendInvitationSendRequest);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _MailWindow_Canvas18_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.contentFriendInvitation = _loc_1;
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            _loc_1.styleName = "detailsContentBox";
            _loc_1.id = "contentFriendInvitation";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_Text4_i());
            _loc_1.addChild(this._MailWindow_AvatarListItemRenderer2_i());
            _loc_1.addChild(this._MailWindow_HBox6_c());
            return _loc_1;
        }// end function

        public function get btnReplay() : StandardButton
        {
            return this._551124323btnReplay;
        }// end function

        private function _MailWindow_List1_i() : List
        {
            var _loc_1:* = new List();
            this.reciepientList = _loc_1;
            _loc_1.visible = false;
            _loc_1.height = 112;
            _loc_1.labelField = "username";
            _loc_1.styleName = "standardInput";
            _loc_1.setStyle("left", "110");
            _loc_1.setStyle("right", "30");
            _loc_1.setStyle("top", "34");
            _loc_1.setStyle("borderThickness", 1);
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.setStyle("rollOverColor", 7957587);
            _loc_1.setStyle("selectionColor", 8482380);
            _loc_1.id = "reciepientList";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _MailWindow_TextArea2_i() : TextArea
        {
            var _loc_1:* = new TextArea();
            this.bodyText = _loc_1;
            _loc_1.editable = false;
            _loc_1.setStyle("left", "24");
            _loc_1.setStyle("right", "8");
            _loc_1.setStyle("top", "0");
            _loc_1.setStyle("bottom", "0");
            _loc_1.setStyle("backgroundAlpha", 0);
            _loc_1.setStyle("borderThickness", 0);
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.setStyle("paddingBottom", 0);
            _loc_1.setStyle("paddingRight", 16);
            _loc_1.setStyle("paddingTop", 5);
            _loc_1.id = "bodyText";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _MailWindow_Label5_i() : Label
        {
            var _loc_1:* = new Label();
            this._MailWindow_Label5 = _loc_1;
            _loc_1.id = "_MailWindow_Label5";
            BindingManager.executeBindings(this, "_MailWindow_Label5", this._MailWindow_Label5);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get btnTradeDecline() : StandardButton
        {
            return this._1148819822btnTradeDecline;
        }// end function

        private function _MailWindow_Text5_i() : Text
        {
            var _loc_1:* = new Text();
            this.tradeInfoText = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("left", "24");
            _loc_1.setStyle("right", "24");
            _loc_1.setStyle("top", "5");
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "tradeInfoText";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get btnNewMail() : StandardButton
        {
            return this._655478139btnNewMail;
        }// end function

        public function get btnFriendDecline() : StandardButton
        {
            return this._1053444476btnFriendDecline;
        }// end function

        public function set btnGuildRequestAccept(param1:StandardButton) : void
        {
            var _loc_2:* = this._1798226240btnGuildRequestAccept;
            if (_loc_2 !== param1)
            {
                this._1798226240btnGuildRequestAccept = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnGuildRequestAccept", _loc_2, param1));
            }
            return;
        }// end function

        public function set guildRequestButtons(param1:HBox) : void
        {
            var _loc_2:* = this._1395382469guildRequestButtons;
            if (_loc_2 !== param1)
            {
                this._1395382469guildRequestButtons = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "guildRequestButtons", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_HBox16_i() : HBox
        {
            var _loc_1:* = new HBox();
            this.guildIncreaseButtons = _loc_1;
            _loc_1.setStyle("bottom", "5");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.id = "guildIncreaseButtons";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_StandardButton17_i());
            return _loc_1;
        }// end function

        private function _MailWindow_ClassFactory3_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = MailGridTextItemRenderer;
            return _loc_1;
        }// end function

        private function _MailWindow_StandardButton11_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnTradeDecline = _loc_1;
            _loc_1.width = 70;
            _loc_1.height = 32;
            _loc_1.id = "btnTradeDecline";
            BindingManager.executeBindings(this, "btnTradeDecline", this.btnTradeDecline);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get itemsHolder() : HBox
        {
            return this._1047735924itemsHolder;
        }// end function

        public function set friendRequestAvatar(param1:AvatarListItemRenderer) : void
        {
            var _loc_2:* = this._895480118friendRequestAvatar;
            if (_loc_2 !== param1)
            {
                this._895480118friendRequestAvatar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "friendRequestAvatar", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_TextInput1_i() : TextInput
        {
            var _loc_1:* = new TextInput();
            this.toInput = _loc_1;
            _loc_1.height = 20;
            _loc_1.styleName = "standardInput";
            _loc_1.setStyle("left", "95");
            _loc_1.setStyle("right", "15");
            _loc_1.setStyle("top", "10");
            _loc_1.id = "toInput";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _MailWindow_StandardButton8_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnAdventureInviteDecline = _loc_1;
            _loc_1.width = 70;
            _loc_1.height = 32;
            _loc_1.id = "btnAdventureInviteDecline";
            BindingManager.executeBindings(this, "btnAdventureInviteDecline", this.btnAdventureInviteDecline);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _MailWindow_Canvas17_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.setStyle("left", "10");
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "7");
            _loc_1.setStyle("bottom", "7");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_Text3_i());
            return _loc_1;
        }// end function

        public function set mailContent(param1:ViewStack) : void
        {
            var _loc_2:* = this._875838146mailContent;
            if (_loc_2 !== param1)
            {
                this._875838146mailContent = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mailContent", _loc_2, param1));
            }
            return;
        }// end function

        public function set offerBuff(param1:StarMenuItemRenderer) : void
        {
            var _loc_2:* = this._1944015055offerBuff;
            if (_loc_2 !== param1)
            {
                this._1944015055offerBuff = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "offerBuff", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_HBox9_c() : HBox
        {
            var _loc_1:* = new HBox();
            _loc_1.setStyle("horizontalCenter", "80");
            _loc_1.setStyle("verticalAlign", "middle");
            _loc_1.setStyle("verticalCenter", "-5");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_Label7_i());
            _loc_1.addChild(this._MailWindow_TradeResourceItemRenderer2_i());
            return _loc_1;
        }// end function

        private function _MailWindow_Label4_i() : Label
        {
            var _loc_1:* = new Label();
            this._MailWindow_Label4 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.id = "_MailWindow_Label4";
            BindingManager.executeBindings(this, "_MailWindow_Label4", this._MailWindow_Label4);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function __btnNewMail_click(event:MouseEvent) : void
        {
            this.currentState = "edit";
            return;
        }// end function

        private function _MailWindow_TextArea1_i() : TextArea
        {
            var _loc_1:* = new TextArea();
            this.editText = _loc_1;
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "4");
            _loc_1.setStyle("bottom", "3");
            _loc_1.setStyle("backgroundAlpha", 0);
            _loc_1.setStyle("borderThickness", 0);
            _loc_1.setStyle("focusAlpha", 0);
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "editText";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _MailWindow_TradeResourceItemRenderer5_i() : TradeResourceItemRenderer
        {
            var _loc_1:* = new TradeResourceItemRenderer();
            this.gemsResource = _loc_1;
            _loc_1.setStyle("bottom", "40");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.id = "gemsResource";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function formatSenderName(param1:Object, param2:DataGridColumn) : String
        {
            switch(param1.type)
            {
                case MAIL_TYPE.ADVENTURE_WON_LOOT:
                case MAIL_TYPE.ADVENTURE_LOST_LOOT:
                {
                    return cLocaManager.GetInstance().GetText(LOCA_GROUP.ADVENTURE_NAME, param1.senderName);
                }
                case MAIL_TYPE.BATTLE_REPORT:
                case MAIL_TYPE.BATTLE_REPORT_INTERCEPTED:
                {
                    if (global.ui.IsAdventureZoneID(param1.senderId))
                    {
                        return cLocaManager.GetInstance().GetText(LOCA_GROUP.ADVENTURE_NAME, param1.senderName);
                    }
                }
                default:
                {
                    return param1.senderName;
                    continue;
                }
            }
        }// end function

        private function _MailWindow_Text4_i() : Text
        {
            var _loc_1:* = new Text();
            this.friendInvitationInfoText = _loc_1;
            _loc_1.height = 50;
            _loc_1.selectable = false;
            _loc_1.setStyle("left", "24");
            _loc_1.setStyle("right", "24");
            _loc_1.setStyle("top", "5");
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "friendInvitationInfoText";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get declinedBuff() : StarMenuItemRenderer
        {
            return this._853018207declinedBuff;
        }// end function

        private function _MailWindow_DataGridColumn5_c() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            _loc_1.width = 30;
            _loc_1.dataField = "id";
            _loc_1.draggable = false;
            _loc_1.headerText = "";
            _loc_1.itemRenderer = this._MailWindow_ClassFactory5_c();
            _loc_1.resizable = false;
            _loc_1.sortable = false;
            return _loc_1;
        }// end function

        private function _MailWindow_CustomDataGrid1_i() : CustomDataGrid
        {
            var _loc_1:* = new CustomDataGrid();
            this.mailsList = _loc_1;
            _loc_1.headerHeight = 20;
            _loc_1.rowHeight = 25;
            _loc_1.columns = [this._MailWindow_DataGridColumn1_i(), this._MailWindow_DataGridColumn2_i(), this._MailWindow_DataGridColumn3_i(), this._MailWindow_DataGridColumn4_i(), this._MailWindow_DataGridColumn5_c()];
            _loc_1.setStyle("left", "12");
            _loc_1.setStyle("right", "13");
            _loc_1.setStyle("top", "5");
            _loc_1.setStyle("bottom", "0");
            _loc_1.setStyle("backgroundAlpha", 0);
            _loc_1.setStyle("borderColor", 7693901);
            _loc_1.setStyle("borderThickness", 0);
            _loc_1.setStyle("headerBackgroundSkin", CustomDataGridHeaderBackgroundSkin);
            _loc_1.setStyle("headerColors", [3155998]);
            _loc_1.setStyle("headerSeparatorSkin", CustomDataGridHeaderSeparator);
            _loc_1.setStyle("headerStyleName", "mailDataGridHeader");
            _loc_1.setStyle("horizontalGridLines", false);
            _loc_1.setStyle("iconColor", 13077059);
            _loc_1.setStyle("rollOverColor", 7957587);
            _loc_1.setStyle("selectionColor", 8482380);
            _loc_1.setStyle("verticalAlign", "middle");
            _loc_1.setStyle("verticalGridLineColor", 7693901);
            _loc_1.addEventListener("toolTipCreate", this.__mailsList_toolTipCreate);
            _loc_1.id = "mailsList";
            BindingManager.executeBindings(this, "mailsList", this.mailsList);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get btnFriendAccept() : StandardButton
        {
            return this._361883074btnFriendAccept;
        }// end function

        private function _MailWindow_HBox15_i() : HBox
        {
            var _loc_1:* = new HBox();
            this.guildRequestButtons = _loc_1;
            _loc_1.setStyle("bottom", "5");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.id = "guildRequestButtons";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_StandardButton15_i());
            _loc_1.addChild(this._MailWindow_StandardButton16_i());
            return _loc_1;
        }// end function

        private function _MailWindow_ClassFactory2_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = MailGridTextItemRenderer;
            return _loc_1;
        }// end function

        public function get contentMail() : Canvas
        {
            return this._389363248contentMail;
        }// end function

        private function _MailWindow_StandardButton10_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnTradeAccept = _loc_1;
            _loc_1.width = 70;
            _loc_1.height = 32;
            _loc_1.enabled = false;
            _loc_1.addEventListener("toolTipCreate", this.__btnTradeAccept_toolTipCreate);
            _loc_1.id = "btnTradeAccept";
            BindingManager.executeBindings(this, "btnTradeAccept", this.btnTradeAccept);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set lootAcceptInfoText(param1:Text) : void
        {
            var _loc_2:* = this._664767253lootAcceptInfoText;
            if (_loc_2 !== param1)
            {
                this._664767253lootAcceptInfoText = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "lootAcceptInfoText", _loc_2, param1));
            }
            return;
        }// end function

        public function set acceptedResource(param1:TradeResourceItemRenderer) : void
        {
            var _loc_2:* = this._1154862891acceptedResource;
            if (_loc_2 !== param1)
            {
                this._1154862891acceptedResource = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "acceptedResource", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_StandardButton7_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnAdventureInviteAccept = _loc_1;
            _loc_1.width = 70;
            _loc_1.height = 32;
            _loc_1.addEventListener("toolTipCreate", this.__btnAdventureInviteAccept_toolTipCreate);
            _loc_1.id = "btnAdventureInviteAccept";
            BindingManager.executeBindings(this, "btnAdventureInviteAccept", this.btnAdventureInviteAccept);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _MailWindow_Canvas16_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.height = 90;
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.setStyle("left", "1");
            _loc_1.setStyle("right", "1");
            _loc_1.setStyle("top", "18");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_Canvas17_c());
            return _loc_1;
        }// end function

        private function _MailWindow_Label3_i() : Label
        {
            var _loc_1:* = new Label();
            this.subjectLabel = _loc_1;
            _loc_1.setStyle("left", "30");
            _loc_1.setStyle("right", "80");
            _loc_1.setStyle("top", "6");
            _loc_1.id = "subjectLabel";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set friendInvitationInfoText(param1:Text) : void
        {
            var _loc_2:* = this._151526158friendInvitationInfoText;
            if (_loc_2 !== param1)
            {
                this._151526158friendInvitationInfoText = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "friendInvitationInfoText", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_HBox8_i() : HBox
        {
            var _loc_1:* = new HBox();
            this.offerItemTrade = _loc_1;
            _loc_1.setStyle("horizontalCenter", "-80");
            _loc_1.setStyle("verticalAlign", "middle");
            _loc_1.setStyle("verticalCenter", "-5");
            _loc_1.id = "offerItemTrade";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_Label6_i());
            _loc_1.addChild(this._MailWindow_StarMenuItemRenderer1_i());
            return _loc_1;
        }// end function

        public function get btnReply() : Button
        {
            return this._2095988206btnReply;
        }// end function

        private function _MailWindow_TradeResourceItemRenderer4_i() : TradeResourceItemRenderer
        {
            var _loc_1:* = new TradeResourceItemRenderer();
            this.declinedResource = _loc_1;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "declinedResource";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get bodyText() : TextArea
        {
            return this._1702646255bodyText;
        }// end function

        private function _MailWindow_Text3_i() : Text
        {
            var _loc_1:* = new Text();
            this.adventureTodo = _loc_1;
            _loc_1.percentWidth = 100;
            _loc_1.selectable = false;
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.setStyle("paddingRight", 10);
            _loc_1.id = "adventureTodo";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get btnGuildIncreaseSize() : StandardButton
        {
            return this._1775181318btnGuildIncreaseSize;
        }// end function

        private function _MailWindow_DataGridColumn4_i() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            this._MailWindow_DataGridColumn4 = _loc_1;
            _loc_1.width = 80;
            _loc_1.dataField = "timestamp";
            _loc_1.draggable = false;
            _loc_1.itemRenderer = this._MailWindow_ClassFactory4_c();
            _loc_1.labelFunction = this.formatDate;
            _loc_1.resizable = false;
            BindingManager.executeBindings(this, "_MailWindow_DataGridColumn4", this._MailWindow_DataGridColumn4);
            return _loc_1;
        }// end function

        private function _MailWindow_HBox14_c() : HBox
        {
            var _loc_1:* = new HBox();
            _loc_1.setStyle("bottom", "5");
            _loc_1.setStyle("horizontalCenter", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_StandardButton14_i());
            return _loc_1;
        }// end function

        public function get subjectInput() : TextInput
        {
            return this._1529844226subjectInput;
        }// end function

        private function _MailWindow_ClassFactory1_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = MailGridTypeIconItemRenderer;
            return _loc_1;
        }// end function

        public function get contentBuffed() : Canvas
        {
            return this._812468725contentBuffed;
        }// end function

        public function get tradeDeclineInfoText() : Text
        {
            return this._1801856499tradeDeclineInfoText;
        }// end function

        public function __btnReply_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function get toInput() : TextInput
        {
            return this._1175114225toInput;
        }// end function

        public function set buffedBuilding(param1:Image) : void
        {
            var _loc_2:* = this._688277242buffedBuilding;
            if (_loc_2 !== param1)
            {
                this._688277242buffedBuilding = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "buffedBuilding", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_StandardButton6_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnFriendDecline = _loc_1;
            _loc_1.width = 70;
            _loc_1.height = 32;
            _loc_1.id = "btnFriendDecline";
            BindingManager.executeBindings(this, "btnFriendDecline", this.btnFriendDecline);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _MailWindow_Canvas15_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.missionHeader = _loc_1;
            _loc_1.height = 18;
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.setStyle("left", "0");
            _loc_1.setStyle("right", "0");
            _loc_1.id = "missionHeader";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_Label4_i());
            return _loc_1;
        }// end function

        public function set friendInvitationAvatar(param1:AvatarListItemRenderer) : void
        {
            var _loc_2:* = this._695688944friendInvitationAvatar;
            if (_loc_2 !== param1)
            {
                this._695688944friendInvitationAvatar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "friendInvitationAvatar", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_Label2_i() : Label
        {
            var _loc_1:* = new Label();
            this._MailWindow_Label2 = _loc_1;
            _loc_1.width = 70;
            _loc_1.setStyle("left", "15");
            _loc_1.setStyle("top", "36");
            _loc_1.setStyle("textAlign", "right");
            _loc_1.id = "_MailWindow_Label2";
            BindingManager.executeBindings(this, "_MailWindow_Label2", this._MailWindow_Label2);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _MailWindow_HBox7_i() : HBox
        {
            var _loc_1:* = new HBox();
            this.offerTrade = _loc_1;
            _loc_1.setStyle("horizontalCenter", "-80");
            _loc_1.setStyle("verticalAlign", "middle");
            _loc_1.setStyle("verticalCenter", "-5");
            _loc_1.id = "offerTrade";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_Label5_i());
            _loc_1.addChild(this._MailWindow_TradeResourceItemRenderer1_i());
            return _loc_1;
        }// end function

        public function get gemsInfoText() : Text
        {
            return this._2094231009gemsInfoText;
        }// end function

        public function get contentFriendRequest() : Canvas
        {
            return this._1123239400contentFriendRequest;
        }// end function

        public function set offerItemTrade(param1:HBox) : void
        {
            var _loc_2:* = this._2041813227offerItemTrade;
            if (_loc_2 !== param1)
            {
                this._2041813227offerItemTrade = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "offerItemTrade", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_TradeResourceItemRenderer3_i() : TradeResourceItemRenderer
        {
            var _loc_1:* = new TradeResourceItemRenderer();
            this.acceptedResource = _loc_1;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "acceptedResource";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get contentGuildRequest() : Canvas
        {
            return this._1572676149contentGuildRequest;
        }// end function

        private function _MailWindow_Text2_i() : Text
        {
            var _loc_1:* = new Text();
            this.adventureInviteInfoText = _loc_1;
            _loc_1.percentWidth = 100;
            _loc_1.selectable = false;
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "adventureInviteInfoText";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get guildRequestInfoText() : CustomText
        {
            return this._1593124407guildRequestInfoText;
        }// end function

        public function get subcontent() : VBox
        {
            return this._2100227641subcontent;
        }// end function

        private function _MailWindow_DataGridColumn3_i() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            this._MailWindow_DataGridColumn3 = _loc_1;
            _loc_1.width = 190;
            _loc_1.dataField = "subject";
            _loc_1.draggable = false;
            _loc_1.itemRenderer = this._MailWindow_ClassFactory3_c();
            _loc_1.labelFunction = this.formatSubject;
            _loc_1.resizable = false;
            BindingManager.executeBindings(this, "_MailWindow_DataGridColumn3", this._MailWindow_DataGridColumn3);
            return _loc_1;
        }// end function

        private function _MailWindow_Canvas26_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.contentGuildRequest = _loc_1;
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            _loc_1.styleName = "detailsContentBox";
            _loc_1.id = "contentGuildRequest";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_CustomText1_i());
            _loc_1.addChild(this._MailWindow_HBox15_i());
            _loc_1.addChild(this._MailWindow_HBox16_i());
            return _loc_1;
        }// end function

        private function _MailWindow_HBox13_c() : HBox
        {
            var _loc_1:* = new HBox();
            _loc_1.setStyle("bottom", "5");
            _loc_1.setStyle("horizontalCenter", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_StandardButton13_i());
            return _loc_1;
        }// end function

        public function set contentBattleReport(param1:Canvas) : void
        {
            var _loc_2:* = this._1044724955contentBattleReport;
            if (_loc_2 !== param1)
            {
                this._1044724955contentBattleReport = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "contentBattleReport", _loc_2, param1));
            }
            return;
        }// end function

        public function set subjectLabel(param1:Label) : void
        {
            var _loc_2:* = this._1527474904subjectLabel;
            if (_loc_2 !== param1)
            {
                this._1527474904subjectLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "subjectLabel", _loc_2, param1));
            }
            return;
        }// end function

        public function set contentGems(param1:Canvas) : void
        {
            var _loc_2:* = this._389538019contentGems;
            if (_loc_2 !== param1)
            {
                this._389538019contentGems = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "contentGems", _loc_2, param1));
            }
            return;
        }// end function

        public function get stateEdit() : State
        {
            return this._2086341061stateEdit;
        }// end function

        private function _MailWindow_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : DisplayObject
            {
                return subcontent;
            }// end function
            , function (param1:DisplayObject) : void
            {
                null.target = param1;
                return;
            }// end function
            , "_MailWindow_RemoveChild1.target");
            result[0] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return content;
            }// end function
            , function (param1:UIComponent) : void
            {
                _MailWindow_AddChild1.relativeTo = param1;
                return;
            }// end function
            , "_MailWindow_AddChild1.relativeTo");
            result[1] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "To");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _MailWindow_Label1.text = param1;
                return;
            }// end function
            , "_MailWindow_Label1.text");
            result[2] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Subject");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _MailWindow_Label2.text = param1;
                return;
            }// end function
            , "_MailWindow_Label2.text");
            result[3] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "Send");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "btnSend.label");
            result[4] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Cancel");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "_MailWindow_StandardButton2.label");
            result[5] = binding;
            binding = new Binding(this, function () : UIComponent
            {
                return content;
            }// end function
            , function (param1:UIComponent) : void
            {
                _MailWindow_AddChild2.relativeTo = param1;
                return;
            }// end function
            , "_MailWindow_AddChild2.relativeTo");
            result[6] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "NewMail");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "btnNewMail.label");
            result[7] = binding;
            binding = new Binding(this, function () : Array
            {
                return [];
            }// end function
            , function (param1:Array) : void
            {
                null.setStyle("alternatingItemColors", param1);
                return;
            }// end function
            , "mailsList.alternatingItemColors");
            result[8] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Type");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.headerText = null;
                return;
            }// end function
            , "_MailWindow_DataGridColumn1.headerText");
            result[9] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "From");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.headerText = null;
                return;
            }// end function
            , "_MailWindow_DataGridColumn2.headerText");
            result[10] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "Subject");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.headerText = param1;
                return;
            }// end function
            , "_MailWindow_DataGridColumn3.headerText");
            result[11] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Recieved");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.headerText = param1;
                return;
            }// end function
            , "_MailWindow_DataGridColumn4.headerText");
            result[12] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("IconMailReply");
            }// end function
            , function (param1:Class) : void
            {
                btnReply.setStyle("disabledSkin", param1);
                return;
            }// end function
            , "btnReply.disabledSkin");
            result[13] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("IconMailReply");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("downSkin", param1);
                return;
            }// end function
            , "btnReply.downSkin");
            result[14] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("IconMailReply");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnReply.overSkin");
            result[15] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "Reply");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.toolTip = param1;
                return;
            }// end function
            , "btnReply.toolTip");
            result[16] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                btnReply.setStyle("upSkin", param1);
                return;
            }// end function
            , "btnReply.upSkin");
            result[17] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ReplayBattle");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                btnReplay.label = param1;
                return;
            }// end function
            , "btnReplay.label");
            result[18] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Accept");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "btnFriendAccept.label");
            result[19] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Decline");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnFriendDecline.label");
            result[20] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Mission");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "_MailWindow_Label4.text");
            result[21] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Accept");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnAdventureInviteAccept.label");
            result[22] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "Decline");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "btnAdventureInviteDecline.label");
            result[23] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "AddFriend");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnFriendInvitationSendRequest.label");
            result[24] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Offer");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _MailWindow_Label5.text = param1;
                return;
            }// end function
            , "_MailWindow_Label5.text");
            result[25] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "Offer");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _MailWindow_Label6.text = param1;
                return;
            }// end function
            , "_MailWindow_Label6.text");
            result[26] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "Costs");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _MailWindow_Label7.text = param1;
                return;
            }// end function
            , "_MailWindow_Label7.text");
            result[27] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Accept");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "btnTradeAccept.label");
            result[28] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Decline");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "btnTradeDecline.label");
            result[29] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Accept");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnAcceptLoot.label");
            result[30] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Accept");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                btnAcceptCostsResource.label = param1;
                return;
            }// end function
            , "btnAcceptCostsResource.label");
            result[31] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Accept");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnAcceptOfferResource.label");
            result[32] = binding;
            binding = new Binding(this, function () : Object
            {
                return gAssetManager.GetBitmap("ProductionArrow");
            }// end function
            , function (param1:Object) : void
            {
                null.source = param1;
                return;
            }// end function
            , "_MailWindow_Image1.source");
            result[33] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "Accept");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnGuildRequestAccept.label");
            result[34] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Decline");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "btnGuildRequestDecline.label");
            result[35] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "GuildIncreaseSize");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "btnGuildIncreaseSize.label");
            result[36] = binding;
            return result;
        }// end function

        private function _MailWindow_StandardButton5_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnFriendAccept = _loc_1;
            _loc_1.width = 70;
            _loc_1.height = 32;
            _loc_1.id = "btnFriendAccept";
            BindingManager.executeBindings(this, "btnFriendAccept", this.btnFriendAccept);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _MailWindow_Canvas14_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.percentWidth = 100;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_Canvas15_i());
            _loc_1.addChild(this._MailWindow_Canvas16_c());
            return _loc_1;
        }// end function

        public function set contentLootAccept(param1:Canvas) : void
        {
            var _loc_2:* = this._458905385contentLootAccept;
            if (_loc_2 !== param1)
            {
                this._458905385contentLootAccept = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "contentLootAccept", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_Image2_i() : Image
        {
            var _loc_1:* = new Image();
            this.buffedBuilding = _loc_1;
            _loc_1.setStyle("horizontalCenter", "50");
            _loc_1.setStyle("verticalCenter", "10");
            _loc_1.addEventListener("toolTipCreate", this.__buffedBuilding_toolTipCreate);
            _loc_1.id = "buffedBuilding";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get declinedResource() : TradeResourceItemRenderer
        {
            return this._436988324declinedResource;
        }// end function

        private function _MailWindow_HBox6_c() : HBox
        {
            var _loc_1:* = new HBox();
            _loc_1.setStyle("bottom", "5");
            _loc_1.setStyle("horizontalCenter", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_StandardButton9_i());
            return _loc_1;
        }// end function

        private function _MailWindow_Label1_i() : Label
        {
            var _loc_1:* = new Label();
            this._MailWindow_Label1 = _loc_1;
            _loc_1.width = 70;
            _loc_1.setStyle("left", "15");
            _loc_1.setStyle("top", "11");
            _loc_1.setStyle("textAlign", "right");
            _loc_1.id = "_MailWindow_Label1";
            BindingManager.executeBindings(this, "_MailWindow_Label1", this._MailWindow_Label1);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set gemsResource(param1:TradeResourceItemRenderer) : void
        {
            var _loc_2:* = this._1681735474gemsResource;
            if (_loc_2 !== param1)
            {
                this._1681735474gemsResource = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "gemsResource", _loc_2, param1));
            }
            return;
        }// end function

        public function get guildIncreaseButtons() : HBox
        {
            return this._1571200404guildIncreaseButtons;
        }// end function

        private function _MailWindow_TradeResourceItemRenderer2_i() : TradeResourceItemRenderer
        {
            var _loc_1:* = new TradeResourceItemRenderer();
            this.costsResource = _loc_1;
            _loc_1.id = "costsResource";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set missionHeader(param1:Canvas) : void
        {
            var _loc_2:* = this._1805383481missionHeader;
            if (_loc_2 !== param1)
            {
                this._1805383481missionHeader = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "missionHeader", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_Text1_i() : Text
        {
            var _loc_1:* = new Text();
            this.friendRequestInfoText = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("left", "24");
            _loc_1.setStyle("right", "24");
            _loc_1.setStyle("top", "5");
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "friendRequestInfoText";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get editText() : TextArea
        {
            return this._1602032215editText;
        }// end function

        private function _MailWindow_DataGridColumn2_i() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            this._MailWindow_DataGridColumn2 = _loc_1;
            _loc_1.width = 130;
            _loc_1.dataField = "senderName";
            _loc_1.draggable = false;
            _loc_1.itemRenderer = this._MailWindow_ClassFactory2_c();
            _loc_1.labelFunction = this.formatSenderName;
            _loc_1.resizable = false;
            BindingManager.executeBindings(this, "_MailWindow_DataGridColumn2", this._MailWindow_DataGridColumn2);
            return _loc_1;
        }// end function

        private function _MailWindow_Canvas25_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.contentGems = _loc_1;
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            _loc_1.styleName = "detailsContentBox";
            _loc_1.id = "contentGems";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_Text10_i());
            _loc_1.addChild(this._MailWindow_TradeResourceItemRenderer5_i());
            return _loc_1;
        }// end function

        private function _MailWindow_HBox12_i() : HBox
        {
            var _loc_1:* = new HBox();
            this.itemsList = _loc_1;
            _loc_1.height = 90;
            _loc_1.maxWidth = 440;
            _loc_1.id = "itemsList";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get offerResource() : TradeResourceItemRenderer
        {
            return this._632301194offerResource;
        }// end function

        public function get btnAcceptOfferResource() : StandardButton
        {
            return this._650289766btnAcceptOfferResource;
        }// end function

        private function _MailWindow_StandardButton4_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnReplay = _loc_1;
            _loc_1.height = 32;
            _loc_1.minWidth = 70;
            _loc_1.id = "btnReplay";
            BindingManager.executeBindings(this, "btnReplay", this.btnReplay);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _MailWindow_Canvas13_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.percentHeight = 100;
            _loc_1.horizontalScrollPolicy = "off";
            _loc_1.verticalScrollPolicy = "auto";
            _loc_1.setStyle("left", "0");
            _loc_1.setStyle("right", "8");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_VBox3_c());
            return _loc_1;
        }// end function

        public function set btnAcceptLoot(param1:StandardButton) : void
        {
            var _loc_2:* = this._224902324btnAcceptLoot;
            if (_loc_2 !== param1)
            {
                this._224902324btnAcceptLoot = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnAcceptLoot", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_Image1_i() : Image
        {
            var _loc_1:* = new Image();
            this._MailWindow_Image1 = _loc_1;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "10");
            _loc_1.id = "_MailWindow_Image1";
            BindingManager.executeBindings(this, "_MailWindow_Image1", this._MailWindow_Image1);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set buffedInfoText(param1:Text) : void
        {
            var _loc_2:* = this._920304973buffedInfoText;
            if (_loc_2 !== param1)
            {
                this._920304973buffedInfoText = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "buffedInfoText", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_HBox5_c() : HBox
        {
            var _loc_1:* = new HBox();
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_StandardButton7_i());
            _loc_1.addChild(this._MailWindow_StandardButton8_i());
            return _loc_1;
        }// end function

        private function _MailWindow_TradeResourceItemRenderer1_i() : TradeResourceItemRenderer
        {
            var _loc_1:* = new TradeResourceItemRenderer();
            this.offerResource = _loc_1;
            _loc_1.id = "offerResource";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set contentTradeAccept(param1:Canvas) : void
        {
            var _loc_2:* = this._1887180115contentTradeAccept;
            if (_loc_2 !== param1)
            {
                this._1887180115contentTradeAccept = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "contentTradeAccept", _loc_2, param1));
            }
            return;
        }// end function

        public function get tradeAcceptInfoText() : Text
        {
            return this._1184245415tradeAcceptInfoText;
        }// end function

        private function _MailWindow_Canvas9_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.contentMail = _loc_1;
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            _loc_1.styleName = "detailsContentBox";
            _loc_1.id = "contentMail";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_TextArea2_i());
            return _loc_1;
        }// end function

        public function set battleReportText(param1:TextArea) : void
        {
            var _loc_2:* = this._1191904423battleReportText;
            if (_loc_2 !== param1)
            {
                this._1191904423battleReportText = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "battleReportText", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_DataGridColumn1_i() : DataGridColumn
        {
            var _loc_1:* = new DataGridColumn();
            this._MailWindow_DataGridColumn1 = _loc_1;
            _loc_1.width = 40;
            _loc_1.dataField = "type";
            _loc_1.draggable = false;
            _loc_1.itemRenderer = this._MailWindow_ClassFactory1_c();
            _loc_1.resizable = false;
            BindingManager.executeBindings(this, "_MailWindow_DataGridColumn1", this._MailWindow_DataGridColumn1);
            return _loc_1;
        }// end function

        private function _MailWindow_Canvas24_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.contentBuffed = _loc_1;
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            _loc_1.styleName = "detailsContentBox";
            _loc_1.id = "contentBuffed";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_Text9_i());
            _loc_1.addChild(this._MailWindow_StarMenuItemRenderer3_i());
            _loc_1.addChild(this._MailWindow_Image1_i());
            _loc_1.addChild(this._MailWindow_Image2_i());
            return _loc_1;
        }// end function

        public function get btnGuildRequestAccept() : StandardButton
        {
            return this._1798226240btnGuildRequestAccept;
        }// end function

        public function get mailContent() : ViewStack
        {
            return this._875838146mailContent;
        }// end function

        private function _MailWindow_HBox11_i() : HBox
        {
            var _loc_1:* = new HBox();
            this.itemsHolder = _loc_1;
            _loc_1.setStyle("verticalAlign", "middle");
            _loc_1.id = "itemsHolder";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_HBox12_i());
            _loc_1.addChild(this._MailWindow_VBox5_c());
            return _loc_1;
        }// end function

        public function get friendRequestAvatar() : AvatarListItemRenderer
        {
            return this._895480118friendRequestAvatar;
        }// end function

        public function set btnReplay(param1:StandardButton) : void
        {
            var _loc_2:* = this._551124323btnReplay;
            if (_loc_2 !== param1)
            {
                this._551124323btnReplay = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnReplay", _loc_2, param1));
            }
            return;
        }// end function

        public function ___MailWindow_StandardButton2_click(event:MouseEvent) : void
        {
            this.currentState = "";
            return;
        }// end function

        private function _MailWindow_StandardButton3_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnNewMail = _loc_1;
            _loc_1.addEventListener("click", this.__btnNewMail_click);
            _loc_1.id = "btnNewMail";
            BindingManager.executeBindings(this, "btnNewMail", this.btnNewMail);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _MailWindow_HBox4_c() : HBox
        {
            var _loc_1:* = new HBox();
            _loc_1.setStyle("bottom", "5");
            _loc_1.setStyle("horizontalCenter", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_StandardButton5_i());
            _loc_1.addChild(this._MailWindow_StandardButton6_i());
            return _loc_1;
        }// end function

        public function set contentFriendInvitation(param1:Canvas) : void
        {
            var _loc_2:* = this._823564144contentFriendInvitation;
            if (_loc_2 !== param1)
            {
                this._823564144contentFriendInvitation = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "contentFriendInvitation", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_Canvas12_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.contentAdventureInvite = _loc_1;
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            _loc_1.styleName = "detailsContentBox";
            _loc_1.id = "contentAdventureInvite";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_Canvas13_c());
            return _loc_1;
        }// end function

        private function _MailWindow_Canvas8_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.percentWidth = 100;
            _loc_1.height = 25;
            _loc_1.styleName = "detailsHeader";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_Label3_i());
            _loc_1.addChild(this._MailWindow_Button1_i());
            return _loc_1;
        }// end function

        public function set adventureTodo(param1:Text) : void
        {
            var _loc_2:* = this._542559094adventureTodo;
            if (_loc_2 !== param1)
            {
                this._542559094adventureTodo = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "adventureTodo", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_Text10_i() : Text
        {
            var _loc_1:* = new Text();
            this.gemsInfoText = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("left", "24");
            _loc_1.setStyle("right", "24");
            _loc_1.setStyle("top", "5");
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.id = "gemsInfoText";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set btnTradeDecline(param1:StandardButton) : void
        {
            var _loc_2:* = this._1148819822btnTradeDecline;
            if (_loc_2 !== param1)
            {
                this._1148819822btnTradeDecline = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnTradeDecline", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnNewMail(param1:StandardButton) : void
        {
            var _loc_2:* = this._655478139btnNewMail;
            if (_loc_2 !== param1)
            {
                this._655478139btnNewMail = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnNewMail", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnFriendDecline(param1:StandardButton) : void
        {
            var _loc_2:* = this._1053444476btnFriendDecline;
            if (_loc_2 !== param1)
            {
                this._1053444476btnFriendDecline = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnFriendDecline", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.subcontent;
            _loc_1 = content;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "To");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Subject");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Send");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Cancel");
            _loc_1 = content;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "NewMail");
            _loc_1 = [];
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Type");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "From");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Subject");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Recieved");
            _loc_1 = gAssetManager.GetClass("IconMailReply");
            _loc_1 = gAssetManager.GetClass("IconMailReply");
            _loc_1 = gAssetManager.GetClass("IconMailReply");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Reply");
            _loc_1 = gAssetManager.GetClass("IconMailReply");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ReplayBattle");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Accept");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Decline");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Mission");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Accept");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Decline");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "AddFriend");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Offer");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Offer");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Costs");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Accept");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Decline");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Accept");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Accept");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Accept");
            _loc_1 = gAssetManager.GetBitmap("ProductionArrow");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Accept");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Decline");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildIncreaseSize");
            return;
        }// end function

        private function _MailWindow_Canvas23_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.contentTradeDecline = _loc_1;
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            _loc_1.styleName = "detailsContentBox";
            _loc_1.id = "contentTradeDecline";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_Text8_i());
            _loc_1.addChild(this._MailWindow_TradeResourceItemRenderer4_i());
            _loc_1.addChild(this._MailWindow_StarMenuItemRenderer2_i());
            _loc_1.addChild(this._MailWindow_HBox14_c());
            return _loc_1;
        }// end function

        private function _MailWindow_HBox10_c() : HBox
        {
            var _loc_1:* = new HBox();
            _loc_1.setStyle("bottom", "5");
            _loc_1.setStyle("horizontalCenter", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_StandardButton10_i());
            _loc_1.addChild(this._MailWindow_StandardButton11_i());
            return _loc_1;
        }// end function

        private function _MailWindow_StandardButton2_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this._MailWindow_StandardButton2 = _loc_1;
            _loc_1.width = 70;
            _loc_1.height = 32;
            _loc_1.addEventListener("click", this.___MailWindow_StandardButton2_click);
            _loc_1.id = "_MailWindow_StandardButton2";
            BindingManager.executeBindings(this, "_MailWindow_StandardButton2", this._MailWindow_StandardButton2);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get offerItemTrade() : HBox
        {
            return this._2041813227offerItemTrade;
        }// end function

        private function _MailWindow_HBox3_c() : HBox
        {
            var _loc_1:* = new HBox();
            _loc_1.setStyle("bottom", "5");
            _loc_1.setStyle("horizontalCenter", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_StandardButton4_i());
            return _loc_1;
        }// end function

        public function get contentGems() : Canvas
        {
            return this._389538019contentGems;
        }// end function

        public function set itemsHolder(param1:HBox) : void
        {
            var _loc_2:* = this._1047735924itemsHolder;
            if (_loc_2 !== param1)
            {
                this._1047735924itemsHolder = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "itemsHolder", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnTradeAccept(param1:StandardButton) : void
        {
            var _loc_2:* = this._1851797616btnTradeAccept;
            if (_loc_2 !== param1)
            {
                this._1851797616btnTradeAccept = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnTradeAccept", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_Canvas11_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.contentFriendRequest = _loc_1;
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            _loc_1.styleName = "detailsContentBox";
            _loc_1.id = "contentFriendRequest";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_Text1_i());
            _loc_1.addChild(this._MailWindow_AvatarListItemRenderer1_i());
            _loc_1.addChild(this._MailWindow_HBox4_c());
            return _loc_1;
        }// end function

        public function get contentBattleReport() : Canvas
        {
            return this._1044724955contentBattleReport;
        }// end function

        public function __buffedBuilding_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function get contentLootAccept() : Canvas
        {
            return this._458905385contentLootAccept;
        }// end function

        private function _MailWindow_Canvas7_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_Canvas8_c());
            _loc_1.addChild(this._MailWindow_ViewStack1_i());
            return _loc_1;
        }// end function

        public function __btnAcceptLoot_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, !this.btnAcceptLoot.enabled);
            return;
        }// end function

        public function get gemsResource() : TradeResourceItemRenderer
        {
            return this._1681735474gemsResource;
        }// end function

        public function get missionHeader() : Canvas
        {
            return this._1805383481missionHeader;
        }// end function

        private function _MailWindow_Canvas22_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.contentTradeAccept = _loc_1;
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            _loc_1.styleName = "detailsContentBox";
            _loc_1.id = "contentTradeAccept";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_Text7_i());
            _loc_1.addChild(this._MailWindow_TradeResourceItemRenderer3_i());
            _loc_1.addChild(this._MailWindow_HBox13_c());
            return _loc_1;
        }// end function

        public function set declinedBuff(param1:StarMenuItemRenderer) : void
        {
            var _loc_2:* = this._853018207declinedBuff;
            if (_loc_2 !== param1)
            {
                this._853018207declinedBuff = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "declinedBuff", _loc_2, param1));
            }
            return;
        }// end function

        public function set buffedBuff(param1:StarMenuItemRenderer) : void
        {
            var _loc_2:* = this._1892806565buffedBuff;
            if (_loc_2 !== param1)
            {
                this._1892806565buffedBuff = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "buffedBuff", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnAcceptLoot() : StandardButton
        {
            return this._224902324btnAcceptLoot;
        }// end function

        public function set btnAdventureInviteAccept(param1:StandardButton) : void
        {
            var _loc_2:* = this._2034009179btnAdventureInviteAccept;
            if (_loc_2 !== param1)
            {
                this._2034009179btnAdventureInviteAccept = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnAdventureInviteAccept", _loc_2, param1));
            }
            return;
        }// end function

        public function get battleReportText() : TextArea
        {
            return this._1191904423battleReportText;
        }// end function

        private function _MailWindow_HBox2_c() : HBox
        {
            var _loc_1:* = new HBox();
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            _loc_1.setStyle("horizontalGap", 0);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_StandardButton3_i());
            _loc_1.addChild(this._MailWindow_Canvas4_c());
            return _loc_1;
        }// end function

        private function _MailWindow_StandardButton1_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnSend = _loc_1;
            _loc_1.width = 70;
            _loc_1.height = 32;
            _loc_1.enabled = false;
            _loc_1.id = "btnSend";
            BindingManager.executeBindings(this, "btnSend", this.btnSend);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _MailWindow_Canvas6_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.setStyle("left", "6");
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "25");
            _loc_1.setStyle("bottom", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get contentFriendInvitation() : Canvas
        {
            return this._823564144contentFriendInvitation;
        }// end function

        private function _MailWindow_Canvas10_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.contentBattleReport = _loc_1;
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            _loc_1.styleName = "detailsContentBox";
            _loc_1.id = "contentBattleReport";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_TextArea3_i());
            _loc_1.addChild(this._MailWindow_HBox3_c());
            return _loc_1;
        }// end function

        private function _MailWindow_Canvas21_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.percentHeight = 100;
            _loc_1.horizontalScrollPolicy = "off";
            _loc_1.verticalScrollPolicy = "auto";
            _loc_1.setStyle("left", "0");
            _loc_1.setStyle("right", "8");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_VBox4_c());
            return _loc_1;
        }// end function

        private function _MailWindow_AvatarListItemRenderer2_i() : AvatarListItemRenderer
        {
            var _loc_1:* = new AvatarListItemRenderer();
            this.friendInvitationAvatar = _loc_1;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "friendInvitationAvatar";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get adventureTodo() : Text
        {
            return this._542559094adventureTodo;
        }// end function

        public function set btnFriendAccept(param1:StandardButton) : void
        {
            var _loc_2:* = this._361883074btnFriendAccept;
            if (_loc_2 !== param1)
            {
                this._361883074btnFriendAccept = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnFriendAccept", _loc_2, param1));
            }
            return;
        }// end function

        public function __btnAdventureInviteAccept_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, !this.btnAdventureInviteAccept.enabled);
            return;
        }// end function

        override public function initialize() : void
        {
            var target:MailWindow;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._MailWindow_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_MailWindowWatcherSetupUtil");
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

        private function _MailWindow_ViewStack1_i() : ViewStack
        {
            var _loc_1:* = new ViewStack();
            this.mailContent = _loc_1;
            _loc_1.setStyle("left", "6");
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("top", "25");
            _loc_1.setStyle("bottom", "0");
            _loc_1.id = "mailContent";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_Canvas9_i());
            _loc_1.addChild(this._MailWindow_Canvas10_i());
            _loc_1.addChild(this._MailWindow_Canvas11_i());
            _loc_1.addChild(this._MailWindow_Canvas12_i());
            _loc_1.addChild(this._MailWindow_Canvas18_i());
            _loc_1.addChild(this._MailWindow_Canvas19_i());
            _loc_1.addChild(this._MailWindow_Canvas20_i());
            _loc_1.addChild(this._MailWindow_Canvas22_i());
            _loc_1.addChild(this._MailWindow_Canvas23_i());
            _loc_1.addChild(this._MailWindow_Canvas24_i());
            _loc_1.addChild(this._MailWindow_Canvas25_i());
            _loc_1.addChild(this._MailWindow_Canvas26_i());
            return _loc_1;
        }// end function

        private function _MailWindow_HBox1_c() : HBox
        {
            var _loc_1:* = new HBox();
            _loc_1.percentWidth = 100;
            _loc_1.setStyle("horizontalAlign", "right");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_StandardButton1_i());
            _loc_1.addChild(this._MailWindow_StandardButton2_i());
            return _loc_1;
        }// end function

        public function __btnGuildRequestAccept_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, !this.btnGuildRequestAccept.enabled);
            return;
        }// end function

        private function _MailWindow_State1_i() : State
        {
            var _loc_1:* = new State();
            this.stateEdit = _loc_1;
            _loc_1.name = "edit";
            _loc_1.overrides = [this._MailWindow_RemoveChild1_i(), this._MailWindow_AddChild1_i(), this._MailWindow_AddChild2_i()];
            return _loc_1;
        }// end function

        public function get btnAdventureInviteAccept() : StandardButton
        {
            return this._2034009179btnAdventureInviteAccept;
        }// end function

        public function set contentMail(param1:Canvas) : void
        {
            var _loc_2:* = this._389363248contentMail;
            if (_loc_2 !== param1)
            {
                this._389363248contentMail = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "contentMail", _loc_2, param1));
            }
            return;
        }// end function

        private function _MailWindow_Canvas5_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.percentWidth = 100;
            _loc_1.height = 25;
            _loc_1.styleName = "detailsHeader";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get buffedBuff() : StarMenuItemRenderer
        {
            return this._1892806565buffedBuff;
        }// end function

        public function get btnTradeAccept() : StandardButton
        {
            return this._1851797616btnTradeAccept;
        }// end function

        private function _MailWindow_AvatarListItemRenderer1_i() : AvatarListItemRenderer
        {
            var _loc_1:* = new AvatarListItemRenderer();
            this.friendRequestAvatar = _loc_1;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "-10");
            _loc_1.id = "friendRequestAvatar";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _MailWindow_Canvas20_i() : Canvas
        {
            var _loc_1:* = new Canvas();
            this.contentLootAccept = _loc_1;
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            _loc_1.styleName = "detailsContentBox";
            _loc_1.id = "contentLootAccept";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_Canvas21_c());
            return _loc_1;
        }// end function

        public function __mailsList_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function set reciepientList(param1:List) : void
        {
            var _loc_2:* = this._894203876reciepientList;
            if (_loc_2 !== param1)
            {
                this._894203876reciepientList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "reciepientList", _loc_2, param1));
            }
            return;
        }// end function

        public function set bodyText(param1:TextArea) : void
        {
            var _loc_2:* = this._1702646255bodyText;
            if (_loc_2 !== param1)
            {
                this._1702646255bodyText = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "bodyText", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnReply(param1:Button) : void
        {
            var _loc_2:* = this._2095988206btnReply;
            if (_loc_2 !== param1)
            {
                this._2095988206btnReply = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnReply", _loc_2, param1));
            }
            return;
        }// end function

        public function get reciepientList() : List
        {
            return this._894203876reciepientList;
        }// end function

        private function _MailWindow_Canvas4_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._MailWindow_Canvas5_c());
            _loc_1.addChild(this._MailWindow_Canvas6_c());
            _loc_1.addChild(this._MailWindow_CustomDataGrid1_i());
            return _loc_1;
        }// end function

        private function _MailWindow_AdventureDifficultyIndicator1_i() : AdventureDifficultyIndicator
        {
            var _loc_1:* = new AdventureDifficultyIndicator();
            this.difficultyIndicator = _loc_1;
            _loc_1.percentWidth = 100;
            _loc_1.id = "difficultyIndicator";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set btnAdventureInviteDecline(param1:StandardButton) : void
        {
            var _loc_2:* = this._204771335btnAdventureInviteDecline;
            if (_loc_2 !== param1)
            {
                this._204771335btnAdventureInviteDecline = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnAdventureInviteDecline", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnAdventureInviteDecline() : StandardButton
        {
            return this._204771335btnAdventureInviteDecline;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
