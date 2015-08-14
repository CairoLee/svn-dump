package GUI.GAME
{
    import AdventureSystem.*;
    import BuffSystem.*;
    import Communication.VO.*;
    import Communication.VO.Guild.*;
    import Communication.VO.Mail.*;
    import Communication.VO.UpdateVO.*;
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Loca.*;
    import Interface.*;
    import ServerState.*;
    import ShopSystem.*;
    import Specialists.*;
    import flash.events.*;
    import flash.ui.*;
    import flash.utils.*;
    import mx.collections.*;
    import mx.events.*;
    import nLib.*;

    public class cMailWindow extends cBasicPanel
    {
        private var mGI:cGameInterface;
        protected var mPanel:MailWindow;
        private var mMailCache:Dictionary;
        private var mCurrentMail:dMailVO;
        private var mSort:Sort;
        private var mMails:ArrayCollection;
        private var mReciepientGuild:dGuildVO;
        private var mReplyMail:dMailVO;
        private var mReciepient:dPlayerListItemVO;
        private static const GET_MAIL_COOLDOWN:int = 7500;
        public static const DELETE_MAIL:String = "DeleteMail";

        public function cMailWindow()
        {
            this.mMailCache = new Dictionary();
            return;
        }// end function

        private function DeclineAdventureInvite(event:MouseEvent) : void
        {
            if (!this.RemoveSelectedItemFromDataProvider("DeclineAdventureInvite", true))
            {
                return;
            }
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.DECLINE_ADVENTURE_INVITATION, (this.mCurrentMail.attachments as dAdventureClientInfoVO).zoneID, this.mCurrentMail.id);
            return;
        }// end function

        private function SelectReciepientByName(event:Event) : void
        {
            var _loc_2:dPlayerListItemVO = null;
            if (this.mPanel.getFocus() == this.mPanel.reciepientList)
            {
                return;
            }
            this.mPanel.reciepientList.visible = false;
            if (this.mReciepient)
            {
                return;
            }
            for each (_loc_2 in this.mPanel.reciepientList.dataProvider)
            {
                
                if (_loc_2.username == this.mPanel.toInput.text)
                {
                    this.mPanel.reciepientList.selectedIndex = 0;
                    this.SelectReciepientFromList(null);
                    return;
                }
            }
            this.mPanel.toInput.setStyle("color", 16711680);
            this.mPanel.btnSend.enabled = false;
            return;
        }// end function

        private function ExitEditState(event:Event) : void
        {
            this.mPanel.label = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Inbox");
            this.mReciepient = null;
            this.mReciepientGuild = null;
            this.mReplyMail = null;
            this.ClearEdit();
            return;
        }// end function

        private function KeyDownHandler(event:KeyboardEvent) : void
        {
            switch(event.keyCode)
            {
                case Keyboard.ENTER:
                {
                    this.mPanel.reciepientList.selectedIndex = 0;
                    this.SelectReciepientFromList(null);
                    this.mPanel.subjectInput.setFocus();
                    break;
                }
                case Keyboard.UP:
                {
                    if (this.mPanel.reciepientList.visible)
                    {
                        this.mPanel.reciepientList.setFocus();
                        this.mPanel.reciepientList.selectedIndex = (this.mPanel.reciepientList.dataProvider as ArrayCollection).length - 1;
                    }
                }
                case Keyboard.DOWN:
                {
                    if (this.mPanel.reciepientList.visible)
                    {
                        this.mPanel.reciepientList.setFocus();
                        this.mPanel.reciepientList.selectedIndex = 0;
                    }
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

        private function DeclineGuildRequest(event:MouseEvent) : void
        {
            if (!this.RemoveSelectedItemFromDataProvider("DeclineGuildRequest", true))
            {
                return;
            }
            ;
            
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.GUILD_INVITE_DECLINE, 0, this.mCurrentMail.id);
            ;
            
            return;
        }// end function

        private function DeclineFriend(event:MouseEvent) : void
        {
            if (!this.RemoveSelectedItemFromDataProvider("DeclineFriend", true))
            {
                return;
            }
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.DECLINE_FRIEND_REQUEST, this.mCurrentMail.senderId, this.mCurrentMail.id);
            return;
        }// end function

        public function SetMail(param1:dMailVO) : void
        {
            if (param1 == null)
            {
                CustomAlert.show("ErrorRetrievingMail", "ErrorRetrievingMail");
                this.GetMailHeaders();
                return;
            }
            this.mMailCache[param1.id] = param1;
            this.mCurrentMail = param1;
            this.DisplayMail();
            return;
        }// end function

        private function AcceptTrade(event:MouseEvent) : void
        {
            if (!this.RemoveSelectedItemFromDataProvider("AcceptTrade", true))
            {
                return;
            }
            if (this.mCurrentMail.type == MAIL_TYPE.TRADE)
            {
                this.mGI.mClientMessages.SendMessagetoServer(COMMAND.ACCEPT_TRADE, this.mGI.mCurrentPlayer.GetPlayerId(), this.mCurrentMail.id);
            }
            else if (this.mCurrentMail.type == MAIL_TYPE.ITEM_TRADE)
            {
                this.mGI.mClientMessages.SendMessagetoServer(COMMAND.ACCEPT_ITEM_TRADE, this.mGI.mCurrentPlayer.GetPlayerId(), this.mCurrentMail.id);
            }
            return;
        }// end function

        override public function Show() : void
        {
            globalFlash.gui.mAvatar.HideMailNotification();
            this.mPanel.label = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Inbox");
            globalFlash.gui.mDarkenPanel.Show();
            this.Clear();
            this.GetMailHeaders();
            super.Show();
            return;
        }// end function

        private function ReplayBattle(event:MouseEvent) : void
        {
            globalFlash.gui.mBattleWindow.SetData((this.mCurrentMail.attachments as dBattleReportBodyVO).battleScript);
            globalFlash.gui.mBattleWindow.Show();
            return;
        }// end function

        private function ReplyMail(event:MouseEvent) : void
        {
            this.mReciepient = new dPlayerListItemVO();
            this.mReciepient.id = this.mCurrentMail.senderId;
            this.mReciepient.username = this.mCurrentMail.senderName;
            this.mReplyMail = this.mCurrentMail;
            this.mPanel.currentState = "edit";
            return;
        }// end function

        private function DeleteMail(event:ListEvent) : void
        {
            if (this.mPanel.mailsList.selectedItem == null)
            {
                if (gLog.isWarnEnabled(LOG_TYPE.GUI))
                {
                    gLog.logWarn(LOG_TYPE.GUI, "DeleteMail(): mPanel.mailsList.selectedItem is null");
                }
                return;
            }
            var _loc_2:* = this.mPanel.mailsList.selectedItem as dMailVO;
            var _loc_3:* = (this.mPanel.mailsList.dataProvider as ArrayCollection).getItemIndex(_loc_2);
            if (_loc_3 < 0)
            {
                if (gLog.isWarnEnabled(LOG_TYPE.GUI))
                {
                    gLog.logWarn(LOG_TYPE.GUI, "DeleteMail(): index of mail is " + _loc_3);
                }
                return;
            }
            this.Clear();
            switch(_loc_2.type)
            {
                case MAIL_TYPE.TRADE:
                case MAIL_TYPE.ITEM_TRADE:
                {
                    this.mCurrentMail = _loc_2;
                    this.DeclineTrade(null);
                    break;
                }
                case MAIL_TYPE.FRIEND_REQUEST:
                {
                    this.mCurrentMail = _loc_2;
                    this.DeclineFriend(null);
                    break;
                }
                case MAIL_TYPE.INVITE_TO_ADVENTURE:
                {
                    this.mCurrentMail = _loc_2;
                    this.DeclineAdventureInvite(null);
                    break;
                }
                default:
                {
                    (this.mPanel.mailsList.dataProvider as ArrayCollection).removeItemAt(_loc_3);
                    this.mGI.mClientMessages.SendMessagetoServer(COMMAND.DELETE_MAIL, this.mGI.mCurrentViewedZoneID, _loc_2.id);
                    break;
                    break;
                }
            }
            this.mCurrentMail = null;
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.PLAYER_ACTION, this.mGI.mCurrentViewedZoneID, "Sent Mail");
            this.Clear();
            return;
        }// end function

        private function Clear() : void
        {
            this.mPanel.mailContent.selectedIndex = 0;
            this.mPanel.subjectLabel.text = "";
            this.mPanel.bodyText.text = "";
            this.mPanel.btnReply.visible = false;
            return;
        }// end function

        public function Init(param1:MailWindow) : void
        {
            var _panel:* = param1;
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(_panel);
            this.mPanel = _panel;
            this.mPanel.btnClose.addEventListener(MouseEvent.CLICK, function () : void
            {
                null.gui.mMailWindow.Hide();
                return;
            }// end function
            );
            this.mPanel.mailsList.addEventListener(ListEvent.ITEM_CLICK, this.GetFullMail);
            this.mPanel.mailsList.addEventListener(cMailWindow.DELETE_MAIL, this.DeleteMail);
            this.mPanel.stateEdit.addEventListener(FlexEvent.ENTER_STATE, this.EnterEditState);
            this.mPanel.stateEdit.addEventListener(FlexEvent.EXIT_STATE, this.ExitEditState);
            this.mPanel.btnReply.addEventListener(MouseEvent.CLICK, this.ReplyMail);
            this.mPanel.btnTradeAccept.addEventListener(MouseEvent.CLICK, this.AcceptTrade);
            this.mPanel.btnTradeDecline.addEventListener(MouseEvent.CLICK, this.DeclineTrade);
            this.mPanel.btnAcceptCostsResource.addEventListener(MouseEvent.CLICK, this.AcceptTradeResource);
            this.mPanel.btnAcceptOfferResource.addEventListener(MouseEvent.CLICK, this.AcceptTradeResource);
            this.mPanel.btnFriendAccept.addEventListener(MouseEvent.CLICK, this.AcceptFriend);
            this.mPanel.btnFriendDecline.addEventListener(MouseEvent.CLICK, this.DeclineFriend);
            this.mPanel.btnAcceptLoot.addEventListener(MouseEvent.CLICK, this.AcceptLoot);
            this.mPanel.btnReplay.addEventListener(MouseEvent.CLICK, this.ReplayBattle);
            this.mPanel.btnFriendInvitationSendRequest.addEventListener(MouseEvent.CLICK, this.SendInvitationFriendRequest);
            this.mPanel.btnGuildRequestAccept.addEventListener(MouseEvent.CLICK, this.AcceptGuildRequest);
            this.mPanel.btnGuildRequestDecline.addEventListener(MouseEvent.CLICK, this.DeclineGuildRequest);
            this.mPanel.btnGuildIncreaseSize.addEventListener(MouseEvent.CLICK, this.IncreaseGuildSize);
            this.mPanel.btnAdventureInviteAccept.addEventListener(MouseEvent.CLICK, this.AcceptAdventureInvite);
            this.mPanel.btnAdventureInviteDecline.addEventListener(MouseEvent.CLICK, this.DeclineAdventureInvite);
            this.mSort = new Sort();
            this.mSort.fields = [new SortField("timestamp", false, true)];
            return;
        }// end function

        private function DeclineTrade(event:MouseEvent) : void
        {
            if (!this.RemoveSelectedItemFromDataProvider("DeclineTrade", true))
            {
                return;
            }
            if (this.mCurrentMail.type == MAIL_TYPE.TRADE)
            {
                this.mGI.mClientMessages.SendMessagetoServer(COMMAND.DECLINE_TRADE, this.mGI.mCurrentPlayer.GetPlayerId(), this.mCurrentMail.id);
            }
            else if (this.mCurrentMail.type == MAIL_TYPE.ITEM_TRADE)
            {
                this.mGI.mClientMessages.SendMessagetoServer(COMMAND.DECLINE_ITEM_TRADE, this.mGI.mCurrentPlayer.GetPlayerId(), this.mCurrentMail.id);
            }
            return;
        }// end function

        private function SendInvitationFriendRequest(event:MouseEvent) : void
        {
            globalFlash.gui.mFriendsList.AddFriend((this.mCurrentMail.attachments as dFriendBodyVO).player);
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.PLAYER_ACTION, this.mGI.mCurrentViewedZoneID, "Sent Mail");
            this.DeleteMail(null);
            return;
        }// end function

        private function GetMailHeaders() : void
        {
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.GET_MAIL_HEADERS, this.mGI.mCurrentViewedZoneID, null);
            return;
        }// end function

        private function GetFullMail(event:ListEvent) : void
        {
            if (!this.mPanel.mailsList.selectedItem)
            {
                return;
            }
            var _loc_2:* = (this.mPanel.mailsList.selectedItem as dMailVO).id;
            if (_loc_2 < 0)
            {
                if (gLog.isWarnEnabled(LOG_TYPE.GUI))
                {
                    gLog.logWarn(LOG_TYPE.GUI, "DeleteMail(): index of mail is " + _loc_2);
                }
                return;
            }
            var _loc_3:* = this.mMailCache[_loc_2] as dMailVO;
            var _loc_4:* = this.mMailCache[_loc_2] as int;
            if (_loc_3 != null)
            {
                if (!_loc_3.read)
                {
                    this.mGI.mClientMessages.SendMessagetoServer(COMMAND.MARK_MAIL_AS_READ, this.mGI.mCurrentViewedZoneID, this.mPanel.mailsList.selectedItem.id);
                }
                this.SetMail(_loc_3);
            }
            else if (this.mMailCache[_loc_2] == null || _loc_4 > 0 && getTimer() - _loc_4 > GET_MAIL_COOLDOWN)
            {
                this.mMailCache[_loc_2] = getTimer() as int;
                this.mGI.mClientMessages.SendMessagetoServer(COMMAND.GET_MAIL, this.mGI.mCurrentViewedZoneID, this.mPanel.mailsList.selectedItem.id);
            }
            return;
        }// end function

        public function PutMailInCache(param1:dMailVO) : void
        {
            if (param1 == null)
            {
                return;
            }
            this.mMailCache[param1.id] = param1;
            return;
        }// end function

        private function KeyUpHandler(event:KeyboardEvent) : void
        {
            if (event.keyCode == Keyboard.DOWN || event.keyCode == Keyboard.UP)
            {
                return;
            }
            this.mReciepient = null;
            if (this.mPanel.toInput.text.length >= 3)
            {
                this.mGI.mClientMessages.SendMessagetoServer(COMMAND.SEARCH_RECIEPIENT_LIST, this.mGI.mCurrentViewedZoneID, this.mPanel.toInput.text);
            }
            else
            {
                this.mPanel.reciepientList.visible = false;
                this.mPanel.reciepientList.dataProvider = null;
            }
            return;
        }// end function

        private function ListKeyDownHandler(event:KeyboardEvent) : void
        {
            switch(event.keyCode)
            {
                case Keyboard.ENTER:
                {
                    this.SelectReciepientFromList(null);
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

        private function AcceptTradeResource(event:MouseEvent) : void
        {
            var _loc_2:dTradeResultVO = null;
            var _loc_3:cResources = null;
            if (!this.RemoveSelectedItemFromDataProvider("AcceptTradeResource"))
            {
                return;
            }
            if (this.mCurrentMail.type != MAIL_TYPE.DECLINE_ITEM_TRADE)
            {
                _loc_2 = this.mCurrentMail.attachments as dTradeResultVO;
                _loc_3 = this.mGI.mCurrentPlayerZone.GetResources(this.mGI.mCurrentPlayer);
                _loc_3.AddResource(_loc_2.result.name_string, _loc_2.result.amount);
                this.mGI.mClientMessages.SendMessagetoServer(COMMAND.ADD_TRADE_RESOURCE, this.mGI.mCurrentPlayer.GetPlayerId(), this.mCurrentMail.id);
            }
            else
            {
                this.mGI.mClientMessages.SendMessagetoServer(COMMAND.ADD_ITEM_TRADE_RESOURCE, this.mGI.mCurrentPlayer.GetPlayerId(), this.mCurrentMail.id);
            }
            this.Clear();
            return;
        }// end function

        public function SetReciepientList(param1:Array) : void
        {
            this.mPanel.reciepientList.dataProvider = param1;
            this.mPanel.reciepientList.visible = param1.length > 0;
            return;
        }// end function

        public function EditGuildMail(param1:dGuildVO) : void
        {
            this.mReciepientGuild = param1;
            this.mPanel.currentState = "edit";
            super.Show();
            return;
        }// end function

        private function IncreaseGuildSize(event:MouseEvent) : void
        {
            globalFlash.gui.mShopWindow.ShowDeepLink("MailWindow", 0, 3);
            return;
        }// end function

        private function ClearEdit() : void
        {
            this.mPanel.toInput.text = "";
            this.mPanel.subjectInput.text = "";
            this.mPanel.editText.text = "";
            this.mPanel.reciepientList.dataProvider = null;
            this.mPanel.reciepientList.visible = false;
            this.mPanel.toInput.enabled = true;
            return;
        }// end function

        private function RemoveSelectedItemFromDataProvider(param1:String, param2:Boolean = false) : Boolean
        {
            if (this.mPanel.mailsList.selectedItem == null)
            {
                if (gLog.isWarnEnabled(LOG_TYPE.GUI))
                {
                    gLog.logWarn(LOG_TYPE.GUI, param1 + "(): mPanel.mailsList.selectedItem is null");
                }
                return false;
            }
            var _loc_3:* = (this.mPanel.mailsList.dataProvider as ArrayCollection).getItemIndex(this.mPanel.mailsList.selectedItem as dMailVO);
            if (_loc_3 < 0)
            {
                if (gLog.isWarnEnabled(LOG_TYPE.GUI))
                {
                    gLog.logWarn(LOG_TYPE.GUI, param1 + "(): index of mail is " + _loc_3);
                }
                return false;
            }
            (this.mPanel.mailsList.dataProvider as ArrayCollection).removeItemAt(_loc_3);
            if (param2)
            {
                this.mGI.mClientMessages.SendMessagetoServer(COMMAND.PLAYER_ACTION, this.mGI.mCurrentViewedZoneID, "Sent Mail");
            }
            this.Clear();
            return true;
        }// end function

        override public function Hide() : void
        {
            globalFlash.gui.mDarkenPanel.Hide();
            this.mReciepient = null;
            super.Hide();
            this.mPanel.currentState = "";
            return;
        }// end function

        public function SetHeaders(param1:ArrayCollection) : void
        {
            param1.sort = this.mSort;
            param1.refresh();
            var _loc_2:* = param1;
            this.mMails = param1;
            this.mPanel.mailsList.dataProvider = _loc_2;
            return;
        }// end function

        private function AcceptFriend(event:MouseEvent) : void
        {
            if (!this.RemoveSelectedItemFromDataProvider("AcceptFriend", true))
            {
                return;
            }
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.ACCEPT_FRIEND_REQUEST, this.mCurrentMail.senderId, this.mCurrentMail.id);
            globalFlash.gui.mFriendsList.AddConfirmedFriend((this.mCurrentMail.attachments as dFriendBodyVO).player);
            return;
        }// end function

        private function EnterEditState(event:Event) : void
        {
            var event:* = event;
            this.ClearEdit();
            this.mPanel.label = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "NewMail");
            this.mPanel.btnSend.addEventListener(MouseEvent.CLICK, this.SendMail);
            this.mPanel.toInput.addEventListener(KeyboardEvent.KEY_UP, this.KeyUpHandler);
            this.mPanel.toInput.addEventListener(KeyboardEvent.KEY_DOWN, this.KeyDownHandler);
            this.mPanel.toInput.addEventListener(FocusEvent.FOCUS_OUT, this.SelectReciepientByName);
            this.mPanel.toInput.addEventListener(FocusEvent.FOCUS_IN, function () : void
            {
                mPanel.toInput.setStyle("color", 16777215);
                return;
            }// end function
            );
            this.mPanel.reciepientList.addEventListener(KeyboardEvent.KEY_DOWN, this.ListKeyDownHandler);
            this.mPanel.reciepientList.addEventListener(ListEvent.ITEM_CLICK, this.SelectReciepientFromList);
            if (this.mReciepient)
            {
                this.mPanel.toInput.text = this.mReciepient.username;
                this.mPanel.btnSend.enabled = true;
            }
            if (this.mReciepientGuild)
            {
                this.mPanel.toInput.text = "[" + cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Guild") + "] " + this.mReciepientGuild.name;
                this.mPanel.toInput.enabled = false;
                this.mPanel.btnSend.enabled = true;
            }
            if (this.mReplyMail)
            {
                this.mPanel.subjectInput.text = "Re: " + this.mReplyMail.subject;
                this.mPanel.editText.text = "\n\n-----------------------------------------------------------------------------------\n";
                this.mPanel.editText.text = this.mPanel.editText.text + (this.mReplyMail.senderName + ":\n\n");
                this.mPanel.editText.text = this.mPanel.editText.text + this.mReplyMail.body;
            }
            return;
        }// end function

        private function SelectReciepientFromList(event:ListEvent) : void
        {
            this.mReciepient = this.mPanel.reciepientList.selectedItem as dPlayerListItemVO;
            if (this.mReciepient)
            {
                this.mPanel.reciepientList.visible = false;
                this.mPanel.toInput.text = this.mReciepient.username;
                this.mPanel.btnSend.enabled = true;
            }
            else
            {
                this.mPanel.toInput.setStyle("color", 16711680);
                this.mPanel.btnSend.enabled = false;
            }
            return;
        }// end function

        private function AcceptGuildRequest(event:MouseEvent) : void
        {
            if (!this.RemoveSelectedItemFromDataProvider("AcceptGuildRequest", true))
            {
                return;
            }
            ;
            
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.GUILD_INVITE_ACCEPT, 0, this.mCurrentMail.id);
            ;
            
            return;
        }// end function

        private function AcceptLoot(event:MouseEvent) : void
        {
            if (!this.RemoveSelectedItemFromDataProvider("AcceptLoot", true))
            {
                return;
            }
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.ACCEPT_LOOT, this.mGI.mCurrentPlayer.GetPlayerId(), this.mCurrentMail.id);
            return;
        }// end function

        private function AcceptAdventureInvite(event:MouseEvent) : void
        {
            if (!this.RemoveSelectedItemFromDataProvider("AcceptAdventureInvite", true))
            {
                return;
            }
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.ACCEPT_ADVENTURE_INVITATION, (this.mCurrentMail.attachments as dAdventureClientInfoVO).zoneID, this.mCurrentMail.id);
            globalFlash.gui.mFriendsList.IncreaseJoinedAdventuresCount();
            return;
        }// end function

        private function DisplayMail() : void
        {
            var resources:Array;
            var res1:Array;
            var res2:Array;
            var mailSubjectLocaText:String;
            var mailBodyLocaText:String;
            var buff:cBuff;
            var gridIdx:int;
            var subjectParams:Array;
            var items:ArrayCollection;
            var item:*;
            var gemsResource:dResource;
            var offer:dResourceVO;
            var costs:dResourceVO;
            var tempBuff:cBuff;
            var buildingName:String;
            var depositName:String;
            var vo:*;
            var frame:Frame;
            var renderer:StarMenuItemRenderer;
            var shopItem:cShopItem;
            if (this.mPanel.mailsList.selectedItem == null)
            {
                if (gLog.isWarnEnabled(LOG_TYPE.GUI))
                {
                    gLog.logWarn(LOG_TYPE.GUI, "DisplayMail(): mPanel.mailsList.selectedItem is null");
                }
                return;
            }
            if (this.mCurrentMail == null)
            {
                if (gLog.isWarnEnabled(LOG_TYPE.GUI))
                {
                    gLog.logWarn(LOG_TYPE.GUI, "DisplayMail(): mCurrentMail is null");
                }
                return;
            }
            var _loc_2:Boolean = true;
            this.mCurrentMail.read = true;
            this.mPanel.mailsList.selectedItem.read = _loc_2;
            this.mPanel.mailsList.selectedItem.body = this.mCurrentMail.body;
            this.mPanel.mailsList.selectedItem.attachments = this.mCurrentMail.attachments;
            this.mPanel.btnReply.visible = this.mCurrentMail.type == MAIL_TYPE.MAIL;
            switch(this.mCurrentMail.type)
            {
                case MAIL_TYPE.MAIL:
                {
                    this.mPanel.subjectLabel.text = this.mCurrentMail.subject;
                    this.mPanel.mailContent.selectedChild = this.mPanel.contentMail;
                    this.mPanel.bodyText.text = this.mCurrentMail.body;
                    break;
                }
                case MAIL_TYPE.BATTLE_REPORT:
                case MAIL_TYPE.BATTLE_REPORT_INTERCEPTED:
                {
                    if (this.mCurrentMail.subject != "")
                    {
                        this.mPanel.subjectLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, MAIL_TYPE.toString(this.mCurrentMail.type) + "AdventureMailSubject", [this.mCurrentMail.subject]);
                        this.mPanel.battleReportText.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, MAIL_TYPE.toString(this.mCurrentMail.type) + "AdventureMailBody", [this.mCurrentMail.subject]);
                    }
                    else
                    {
                        this.mPanel.subjectLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, MAIL_TYPE.toString(this.mCurrentMail.type) + "MailSubject");
                        this.mPanel.battleReportText.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, MAIL_TYPE.toString(this.mCurrentMail.type) + "MailBody");
                    }
                    this.mPanel.mailContent.selectedChild = this.mPanel.contentBattleReport;
                    this.mPanel.btnReplay.enabled = (this.mCurrentMail.attachments as dBattleReportBodyVO).battleScript != "";
                    break;
                }
                case MAIL_TYPE.TRADE:
                case MAIL_TYPE.ITEM_TRADE:
                {
                    resources = this.mCurrentMail.subject.split(",");
                    res1 = resources[0].split(" ");
                    res2 = resources[1].split(" ");
                    if (this.mCurrentMail.type == MAIL_TYPE.TRADE)
                    {
                        this.mPanel.subjectLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "TradeMailSubject", res1.concat(res2));
                        this.mPanel.offerTrade.visible = true;
                        this.mPanel.offerItemTrade.visible = false;
                        offer = (this.mCurrentMail.attachments as dTradeBodyVO).offer;
                        this.mPanel.offerResource.data = offer;
                        costs = (this.mCurrentMail.attachments as dTradeBodyVO).costs;
                    }
                    else if (this.mCurrentMail.type == MAIL_TYPE.ITEM_TRADE)
                    {
                        this.mPanel.subjectLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ItemTradeAdventureMailSubject", res1.concat(res2));
                        this.mPanel.offerTrade.visible = false;
                        this.mPanel.offerItemTrade.visible = true;
                        tempBuff = cBuff.CreateBuffFromVO((this.mCurrentMail.attachments as dItemTradeOfferVO).buff);
                        this.mPanel.offerBuff.data = tempBuff;
                        this.mPanel.offerResource.data = offer;
                        costs = (this.mCurrentMail.attachments as dItemTradeOfferVO).costs;
                    }
                    this.mPanel.costsResource.data = costs;
                    this.mPanel.mailContent.selectedChild = this.mPanel.contentTrade;
                    this.mPanel.tradeInfoText.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "TradeOfferMailBody", [this.mCurrentMail.senderName]);
                    if (!this.mGI.mCurrentPlayerZone.IsBuildingOnMap(defines.LOGISTICS_NAME_string))
                    {
                        this.mPanel.btnTradeAccept.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "CannotAcceptTrade");
                        this.mPanel.btnTradeAccept.enabled = false;
                    }
                    else if (!this.mGI.mCurrentPlayerZone.GetResources(this.mGI.mCurrentPlayer).HasPlayerResource(costs.name_string, costs.amount))
                    {
                        this.mPanel.btnTradeAccept.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "CannotAffordTrade");
                        this.mPanel.btnTradeAccept.enabled = false;
                    }
                    else
                    {
                        this.mPanel.btnTradeAccept.toolTip = "";
                        this.mPanel.btnTradeAccept.enabled = true;
                    }
                    break;
                }
                case MAIL_TYPE.ACCEPT_TRADE:
                case MAIL_TYPE.ACCEPT_ITEM_TRADE:
                {
                    this.mPanel.mailContent.selectedChild = this.mPanel.contentTradeAccept;
                    this.mPanel.acceptedResource.data = (this.mCurrentMail.attachments as dTradeResultVO).result;
                    this.mPanel.tradeAcceptInfoText.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "TradeAcceptedMailBody", [this.mCurrentMail.senderName]);
                    this.mPanel.subjectLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "TradeAcceptedSubject");
                    break;
                }
                case MAIL_TYPE.DECLINE_TRADE:
                case MAIL_TYPE.DECLINE_ITEM_TRADE:
                {
                    this.mPanel.mailContent.selectedChild = this.mPanel.contentTradeDecline;
                    this.mPanel.tradeDeclineInfoText.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "TradeDeclinedMailBody", [this.mCurrentMail.senderName]);
                    this.mPanel.subjectLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "TradeDeclinedSubject");
                    if (this.mCurrentMail.type == MAIL_TYPE.DECLINE_TRADE)
                    {
                        this.mPanel.declinedResource.visible = true;
                        this.mPanel.declinedBuff.visible = false;
                        this.mPanel.declinedResource.data = (this.mCurrentMail.attachments as dTradeResultVO).result;
                    }
                    else if (this.mCurrentMail.type == MAIL_TYPE.DECLINE_ITEM_TRADE)
                    {
                        this.mPanel.declinedResource.visible = false;
                        this.mPanel.declinedBuff.visible = true;
                        tempBuff = cBuff.CreateBuffFromVO((this.mCurrentMail.attachments as dDeclineItemTradeVO).buff);
                        this.mPanel.declinedBuff.data = tempBuff;
                    }
                    break;
                }
                case MAIL_TYPE.BUFFED_BUILDING:
                case MAIL_TYPE.BUFFED_DEPOSIT:
                {
                    buff = cBuff.CreateBuffFromVO((this.mCurrentMail.attachments as dBuffedDataVO).buffVO);
                    gridIdx = (this.mCurrentMail.attachments as dBuffedDataVO).buffedObjectGridIdx;
                    if (this.mCurrentMail.type == MAIL_TYPE.BUFFED_BUILDING)
                    {
                        mailSubjectLocaText;
                        if (buff.GetBuffDefinition().getProductivityOutputPercent() < 100)
                        {
                            mailBodyLocaText;
                        }
                        else
                        {
                            mailBodyLocaText;
                        }
                        buildingName = this.mGI.mCurrentPlayerZone.GetBuildingFromGridPosition(gridIdx).GetBuildingName_string();
                        this.mPanel.buffedBuilding.source = gAssetManager.GetBuildingIcon(buildingName);
                        this.mPanel.buffedBuilding.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.BUILDINGS, buildingName);
                    }
                    else
                    {
                        mailSubjectLocaText;
                        mailBodyLocaText;
                        depositName = this.mGI.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[gridIdx].mDeposit.GetName_string();
                        this.mPanel.buffedBuilding.source = gAssetManager.GetResourceIcon(depositName);
                        this.mPanel.buffedBuilding.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, depositName);
                    }
                    this.mPanel.subjectLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, mailSubjectLocaText, [this.mCurrentMail.senderName]);
                    this.mPanel.buffedInfoText.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, mailBodyLocaText, [this.mCurrentMail.senderName]);
                    this.mPanel.mailContent.selectedChild = this.mPanel.contentBuffed;
                    this.mPanel.buffedBuff.data = buff;
                    break;
                }
                case MAIL_TYPE.GUILD_INVITE:
                {
                    this.mPanel.subjectLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildInviteMailSubject", [this.mCurrentMail.subject]);
                    this.mPanel.mailContent.selectedChild = this.mPanel.contentGuildRequest;
                    this.mPanel.guildRequestInfoText.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "GuildInviteMailBody", [this.mCurrentMail.senderName, (this.mCurrentMail.attachments as dGuildBodyVO).guildName]);
                    this.mPanel.guildRequestButtons.visible = true;
                    if (this.mGI.GetCurrentPlayerGuild() == null)
                    {
                        this.mPanel.btnGuildRequestAccept.toolTip = "";
                        this.mPanel.btnGuildRequestAccept.enabled = true;
                    }
                    else
                    {
                        this.mPanel.btnGuildRequestAccept.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "CannotAcceptGuildInvite");
                        this.mPanel.btnGuildRequestAccept.enabled = false;
                    }
                    this.mPanel.guildIncreaseButtons.visible = false;
                    break;
                }
                case MAIL_TYPE.GUILD_KICK:
                case MAIL_TYPE.GUILD_INVITE_DECLINE:
                case MAIL_TYPE.GUILD_INVITE_FULL:
                {
                    if (this.mCurrentMail.type == MAIL_TYPE.GUILD_KICK)
                    {
                        subjectParams;
                    }
                    else
                    {
                        subjectParams;
                    }
                    this.mPanel.subjectLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, MAIL_TYPE.toString(this.mCurrentMail.type) + "MailSubject", subjectParams);
                    this.mPanel.mailContent.selectedChild = this.mPanel.contentGuildRequest;
                    this.mPanel.guildRequestInfoText.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, MAIL_TYPE.toString(this.mCurrentMail.type) + "MailBody", [this.mCurrentMail.senderName, this.mCurrentMail.subject]);
                    this.mPanel.guildIncreaseButtons.visible = this.mCurrentMail.type == MAIL_TYPE.GUILD_INVITE_FULL;
                    this.mPanel.guildRequestButtons.visible = false;
                    break;
                }
                case MAIL_TYPE.FRIEND_REQUEST:
                {
                    this.mPanel.subjectLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FriendMailSubject", [this.mCurrentMail.senderName]);
                    this.mPanel.mailContent.selectedChild = this.mPanel.contentFriendRequest;
                    this.mPanel.friendRequestInfoText.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "FriendRequestMailBody", [this.mCurrentMail.senderName]);
                    this.mPanel.friendRequestAvatar.data = (this.mCurrentMail.attachments as dFriendBodyVO).player;
                    break;
                }
                case MAIL_TYPE.FRIEND_INVITATION_CONFIRMED:
                {
                    this.mPanel.subjectLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FriendInvitationConfirmedSubject", [this.mCurrentMail.subject]);
                    this.mPanel.mailContent.selectedChild = this.mPanel.contentFriendInvitation;
                    this.mPanel.friendInvitationInfoText.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "FriendInvitationConfirmedBody", [this.mCurrentMail.subject, (this.mCurrentMail.body as dFriendBodyVO).player.username]);
                    this.mPanel.friendInvitationAvatar.data = (this.mCurrentMail.attachments as dFriendBodyVO).player;
                    break;
                }
                case MAIL_TYPE.BANDITS_LOOT:
                case MAIL_TYPE.TREASURE_LOOT:
                case MAIL_TYPE.ADVENTURE_WON_LOOT:
                case MAIL_TYPE.ADVENTURE_LOST_LOOT:
                case MAIL_TYPE.GIFT:
                case MAIL_TYPE.BUFF:
                case MAIL_TYPE.FIND_ADVENTURE_LOOT_POSITIVE:
                case MAIL_TYPE.FIND_ADVENTURE_LOOT_NEGATIVE:
                case MAIL_TYPE.FIND_ADVENTURE_LOOT_MAP_FRAGMENT:
                case MAIL_TYPE.QUEST_LOOT:
                case MAIL_TYPE.COOPERATION_REWARD:
                {
                    if (this.mCurrentMail.type == MAIL_TYPE.BUFF)
                    {
                        this.mPanel.lootAcceptInfoText.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, MAIL_TYPE.toString(MAIL_TYPE.GIFT) + "MailBody", [this.mCurrentMail.senderName]);
                        this.mPanel.subjectLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, MAIL_TYPE.toString(MAIL_TYPE.GIFT) + "MailSubject", [this.mCurrentMail.senderName]);
                    }
                    else if (this.mCurrentMail.type == MAIL_TYPE.ADVENTURE_WON_LOOT)
                    {
                        this.mPanel.lootAcceptInfoText.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.ADVENTURE_WON, this.mCurrentMail.senderName);
                        this.mPanel.subjectLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "AdventureLootMailSubject", [this.mCurrentMail.senderName]);
                    }
                    else if (this.mCurrentMail.type == MAIL_TYPE.ADVENTURE_LOST_LOOT)
                    {
                        this.mPanel.lootAcceptInfoText.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.ADVENTURE_LOST, this.mCurrentMail.senderName);
                        this.mPanel.subjectLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "AdventureLootMailSubject", [this.mCurrentMail.senderName]);
                    }
                    else if (this.mCurrentMail.type == MAIL_TYPE.COOPERATION_REWARD)
                    {
                        this.mPanel.lootAcceptInfoText.text = this.mCurrentMail.body;
                        this.mPanel.subjectLabel.text = this.mCurrentMail.subject;
                    }
                    else
                    {
                        this.mPanel.lootAcceptInfoText.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, MAIL_TYPE.toString(this.mCurrentMail.type) + "MailBody", [this.mCurrentMail.senderName]);
                        this.mPanel.subjectLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, MAIL_TYPE.toString(this.mCurrentMail.type) + "MailSubject", [this.mCurrentMail.senderName]);
                    }
                    this.mPanel.mailContent.selectedChild = this.mPanel.contentLootAccept;
                    items = (this.mCurrentMail.attachments as dLootItemsVO).items;
                    this.mPanel.itemsList.removeAllChildren();
                    var _loc_2:int = 0;
                    var _loc_3:* = items;
                    while (_loc_3 in _loc_2)
                    {
                        
                        vo = _loc_3[_loc_2];
                        if (vo is dResourceVO && vo.name_string == "XP")
                        {
                            item = vo;
                            frame = new Frame();
                            frame.contentType = Frame.CONTENT_TYPE_RESOURCE;
                            frame.amount = vo.amount;
                            frame.content = vo.name_string;
                            frame.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, vo.name_string);
                            frame.addEventListener(ToolTipEvent.TOOL_TIP_CREATE, function (event:ToolTipEvent) : void
            {
                null.createToolTip(null.SIMPLE_string, event);
                return;
            }// end function
            );
                            this.mPanel.itemsList.addChild(frame);
                            continue;
                        }
                        if (vo is dBuffVO)
                        {
                            item = cBuff.CreateBuffFromVO(vo);
                        }
                        else if (vo is dSpecialistVO)
                        {
                            item = cSpecialist.CreateSpecialistFromVO(this.mGI, vo, false);
                        }
                        renderer = new StarMenuItemRenderer();
                        renderer.data = item;
                        this.mPanel.itemsList.addChild(renderer);
                    }
                    this.mPanel.btnAcceptLoot.visible = this.mCurrentMail.type != MAIL_TYPE.FIND_ADVENTURE_LOOT_NEGATIVE;
                    this.mPanel.btnAcceptLoot.toolTip = "";
                    this.mPanel.btnAcceptLoot.enabled = true;
                    if (this.mGI.mCurrentViewedZoneID != this.mGI.mCurrentPlayer.GetPlayerId() || this.mGI.IsAdventureZoneID(this.mGI.mCurrentViewedZoneID))
                    {
                        this.mPanel.btnAcceptLoot.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "AcceptLootHomezone");
                        this.mPanel.btnAcceptLoot.enabled = false;
                        break;
                    }
                    if (this.mCurrentMail.type == MAIL_TYPE.GIFT)
                    {
                        shopItem = cShopItem.GetShopItem((this.mCurrentMail.attachments as dLootItemsVO).shopItemId);
                        if (shopItem != null)
                        {
                            if (this.mGI.mCurrentPlayer.GetPlayerLevel() < shopItem.GetPlayerLevel())
                            {
                                this.mPanel.btnAcceptLoot.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "CannotAcceptItemLevelRequired", [shopItem.GetPlayerLevel().toString()]);
                                this.mPanel.btnAcceptLoot.enabled = false;
                            }
                            else if (shopItem.GetPerPlayer() > 0)
                            {
                                this.mPanel.btnAcceptLoot.enabled = false;
                            }
                        }
                    }
                    break;
                }
                case MAIL_TYPE.HARD_CURRENCY_PURCHASED:
                {
                    this.mPanel.subjectLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "HardCurrencyAppliedSubject", [this.mCurrentMail.senderName]);
                    this.mPanel.mailContent.selectedChild = this.mPanel.contentGems;
                    this.mPanel.gemsInfoText.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, this.mCurrentMail.subject, [this.mCurrentMail.senderName]);
                    gemsResource = new dResource();
                    gemsResource.name_string = "HardCurrency";
                    gemsResource.amount = (this.mCurrentMail.attachments as dHardCurrencyMailBodyVO).amount;
                    this.mPanel.gemsResource.data = gemsResource;
                    this.mPanel.gemsResource.visible = true;
                    break;
                }
                case MAIL_TYPE.INVITED_FRIEND_PURCHASED:
                {
                    this.mPanel.subjectLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "InvitedFriendPurchasedSubject");
                    this.mPanel.mailContent.selectedChild = this.mPanel.contentGems;
                    this.mPanel.gemsInfoText.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "InvitedFriendPurchasedBody", [this.mCurrentMail.subject]);
                    this.mPanel.gemsResource.visible = false;
                    break;
                }
                case MAIL_TYPE.INVITE_TO_ADVENTURE:
                {
                    this.mPanel.subjectLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "InviteToAdventureMailSubject");
                    this.mPanel.mailContent.selectedChild = this.mPanel.contentAdventureInvite;
                    this.mPanel.adventureInviteInfoText.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "InviteToAdventureMailBody", [(this.mCurrentMail.attachments as dAdventureClientInfoVO).adventureName]);
                    this.mPanel.adventureTodo.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.ADVENTURE_TODO, (this.mCurrentMail.attachments as dAdventureClientInfoVO).adventureName);
                    this.mPanel.difficultyIndicator.difficulty = cAdventureDefinition.FindAdventureDefinition((this.mCurrentMail.attachments as dAdventureClientInfoVO).adventureName).mDifficulty;
                    if (globalFlash.gui.mFriendsList.GetJoinedAdventuresCount() < global.adventureMaximumGuest)
                    {
                        this.mPanel.btnAdventureInviteAccept.enabled = true;
                        this.mPanel.btnAdventureInviteAccept.toolTip = "";
                    }
                    else
                    {
                        this.mPanel.btnAdventureInviteAccept.enabled = false;
                        this.mPanel.btnAdventureInviteAccept.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "AdventuresJoinedLimitReached");
                    }
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

        public function EditMailPreselected(param1:dPlayerListItemVO) : void
        {
            this.mReciepient = param1;
            this.mPanel.currentState = "edit";
            super.Show();
            return;
        }// end function

        private function SendMail(event:MouseEvent) : void
        {
            var _loc_2:* = new dMailVO();
            _loc_2.body = this.mPanel.editText.text;
            _loc_2.senderName = "";
            _loc_2.subject = this.mPanel.subjectInput.text;
            if (this.mReciepientGuild)
            {
                _loc_2.reciepientId = this.mReciepientGuild.id;
                this.mGI.mClientMessages.SendMessagetoServer(COMMAND.GUILD_SEND_MAIL, this.mGI.mCurrentViewedZoneID, _loc_2);
            }
            else
            {
                _loc_2.reciepientId = this.mReciepient.id;
                this.mGI.mClientMessages.SendMessagetoServer(COMMAND.SEND_MAIL, this.mGI.mCurrentViewedZoneID, _loc_2);
            }
            this.mReciepient = null;
            this.mReciepientGuild = null;
            globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.MAIL_SENT);
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.PLAYER_ACTION, this.mGI.mCurrentViewedZoneID, "Sent Mail");
            this.Hide();
            return;
        }// end function

    }
}
