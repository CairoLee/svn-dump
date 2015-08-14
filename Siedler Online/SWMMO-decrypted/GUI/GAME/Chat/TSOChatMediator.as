package GUI.GAME.Chat
{
    import Communication.VO.*;
    import Communication.VO.Guild.*;
    import Enums.*;
    import GO.*;
    import GUI.Components.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import Interface.*;
    import ServerState.*;
    import ShopSystem.*;
    import Sound.*;
    import __AS3__.vec.*;
    import com.bluebyte.bluefire.api.controller.*;
    import com.bluebyte.bluefire.api.enum.*;
    import com.bluebyte.bluefire.api.model.vo.*;
    import com.bluebyte.bluefire.puremvc.*;
    import com.bluebyte.bluefire.puremvc.model.*;
    import com.bluebyte.bluefire.puremvc.view.*;
    import com.bluebyte.bluefire.puremvc.view.xiff.*;
    import com.bluebyte.tso.chat.*;
    import flash.events.*;
    import flash.ui.*;
    import flash.utils.*;
    import mx.collections.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import mx.utils.*;
    import nLib.*;
    import org.puremvc.as3.multicore.interfaces.*;

    public class TSOChatMediator extends ChatPanelMediator
    {
        private var mCurrentTradeOfferCooldownTimestamp:int = 0;
        private var _tradeJoined:Boolean = false;
        private var _guildChannelJoined:Boolean = false;
        private var _officersChannelJoined:Boolean = false;
        private var mTradeOffersQueue:Vector.<cTradeData>;
        private var mCurrentTradeOffer:cTradeData;
        private var _reconnectIntervall:int;
        private var _tsoDataProxy:TSODataProxy;
        private var _connectionEstablished:Boolean = false;
        private var mTradeEraseQueue:Object;
        private var mCurrentTradeOfferLastUpdate:int;
        private var mTradeOffers:Object;
        private var _tabSortingIndices:Object;

        public function TSOChatMediator(param1:IChatPanel)
        {
            this._tabSortingIndices = new Object();
            this.mTradeOffers = new Object();
            this.mTradeOffersQueue = new Vector.<cTradeData>;
            this.mTradeEraseQueue = new Object();
            super(param1);
            _roomSendCoolDown = new Timer(global.gameSettingsRootXML.MoveToSubNode("Globals").MoveToSubNode("ChatRoomSendCooldown").GetAttributeInt("value"), 1);
            this._reconnectIntervall = global.gameSettingsRootXML.MoveToSubNode("Globals").MoveToSubNode("ChatReconnectIntervall").GetAttributeInt("intervall");
            return;
        }// end function

        public function ResetTradeCooldown() : void
        {
            this.mCurrentTradeOfferCooldownTimestamp = 0;
            cLocalSettingsManager.tradeCooldownStartTime = null;
            this.SetCurrentTradeOffer(null);
            return;
        }// end function

        private function KeyDown(event:KeyboardEvent) : void
        {
            if (event.keyCode == Keyboard.ENTER)
            {
                (global.ui as cGameInterface).SendServerAction(COMMAND.PLAYER_ACTION, 0, 0, 0, "Sent Chat Message");
            }
            return;
        }// end function

        protected function get panel() : ChatPanel
        {
            return viewComponent as ChatPanel;
        }// end function

        public function clearTradeOffer() : void
        {
            this.sendMessage("trade", "clear");
            cLocalSettingsManager.currentTradeOffer = null;
            return;
        }// end function

        private function addTradeDataToQueue(param1:cTradeData) : void
        {
            this.mTradeOffersQueue.push(param1);
            return;
        }// end function

        public function SetTradeData(param1:Object) : void
        {
            var _loc_3:cTradeData = null;
            var _loc_2:Array = [];
            for each (_loc_3 in param1)
            {
                
                _loc_2.push(_loc_3);
            }
            this.panel.tradeOffers.dataProvider = _loc_2;
            return;
        }// end function

        public function SetCurrentTradeOffer(param1:cTradeData) : void
        {
            var _loc_2:int = 0;
            this.mCurrentTradeOffer = param1;
            if (this.mCurrentTradeOffer == null)
            {
                _loc_2 = this.mCurrentTradeOfferCooldownTimestamp - gMisc.GetTimeSinceStartup();
                if (_loc_2 <= 0)
                {
                    this.panel.btnResetCooldown.visible = false;
                    this.panel.btnAddOffer.visible = true;
                    this.panel.expiresLabel.visible = false;
                    this.panel.removeEventListener(Event.ENTER_FRAME, this.UpdateExpiresTime);
                }
                else
                {
                    this.panel.expiresLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "TradeOfferCooldown", [cLocaManager.GetInstance().FormatDuration(_loc_2)]);
                    this.panel.expiresLabel.visible = true;
                    this.panel.btnResetCooldown.visible = true;
                    this.panel.btnResetCooldown.enabled = true;
                    this.panel.btnAddOffer.visible = false;
                    this.panel.addEventListener(Event.ENTER_FRAME, this.UpdateExpiresTime);
                }
                this.panel.currentOfferBox.visible = false;
                this.panel.btnClearTradeOffer.visible = false;
                return;
            }
            this.panel.currentOfferResource.data = this.mCurrentTradeOffer.offer;
            this.panel.currentCostsResource.data = this.mCurrentTradeOffer.costs;
            this.panel.currentOfferBox.visible = true;
            this.panel.expiresLabel.visible = true;
            this.panel.btnClearTradeOffer.visible = true;
            this.panel.btnAddOffer.visible = false;
            this.panel.addEventListener(Event.ENTER_FRAME, this.UpdateExpiresTime);
            return;
        }// end function

        private function whispers_RemoveHandler(event:Event) : void
        {
            var _loc_2:* = event.target.data as ChannelVO;
            connectionProxy.removeWhisper(_loc_2.name);
            if (this.panel.selectedChannel == _loc_2)
            {
                this.panel.selectedChannel = connectionProxy.getChannel("whisper");
            }
            return;
        }// end function

        public function updateTradeOffers() : void
        {
            var _loc_2:cTradeData = null;
            var _loc_3:cTradeData = null;
            var _loc_4:String = null;
            var _loc_5:int = 0;
            var _loc_1:* = new Date().getTime();
            for each (_loc_2 in this.mTradeOffers)
            {
                
                if (_loc_2.accepted || _loc_2.startTime.time + global.tradeOfferDuration < _loc_1)
                {
                    delete this.mTradeOffers[_loc_2.senderID];
                }
            }
            for each (_loc_3 in this.mTradeOffersQueue)
            {
                
                this.mTradeOffers[_loc_3.senderID] = _loc_3;
            }
            this.mTradeOffersQueue = new Vector.<cTradeData>;
            for (_loc_4 in this.mTradeEraseQueue)
            {
                
                _loc_5 = parseInt(_loc_4);
                if (!this.mTradeOffers.hasOwnProperty(_loc_5))
                {
                    continue;
                }
                if (this.mTradeEraseQueue[_loc_5].getTime() > this.mTradeOffers[_loc_5].startTime)
                {
                    delete this.mTradeOffers[_loc_5];
                }
            }
            this.mTradeEraseQueue = new Object();
            this.SetTradeData(this.mTradeOffers);
            return;
        }// end function

        private function CreateResetCooldownTooltip(event:ToolTipEvent) : void
        {
            var _loc_4:dResource = null;
            var _loc_2:* = cShopItem.GetShopItem(8001);
            var _loc_3:int = 0;
            for each (_loc_4 in _loc_2.GetCosts_vector())
            {
                
                if (_loc_4.name_string == defines.HARD_CURRENCY_RESOURCE_NAME_string)
                {
                    _loc_3 = _loc_4.amount;
                }
            }
            cToolTipUtil.createToolTip(cToolTipUtil.INSTANT_BUILD_string, event, _loc_3);
            return;
        }// end function

        private function handleResetCooldownClick(event:MouseEvent) : void
        {
            var _loc_2:* = cShopItem.GetShopItem(8001);
            var _loc_3:* = global.ui.mCurrentPlayerZone.GetResources(global.ui.mCurrentPlayer);
            if (_loc_3.HasPlayerResourcesInList(_loc_2.GetCosts_vector(), 1))
            {
                global.ui.mClientMessages.SendMessagetoServer(COMMAND.BUY_ONE_CLICK_SHOP_ITEM, global.ui.mCurrentViewedZoneID, new dBuyOneClickShopItemVO().Init(8001));
                this.ResetTradeCooldown();
                this.panel.btnResetCooldown.enabled = false;
                this.panel.expiresLabel.visible = false;
            }
            else
            {
                CustomAlert.show("MissingHardCurrency", "", Alert.OK | Alert.CANCEL, null, this.AddHardCurrencyHandler, null, Alert.OK, true, CustomAlert.STYLE_PAYMENT);
            }
            return;
        }// end function

        public function Show() : void
        {
            this.panel.visible = true;
            return;
        }// end function

        override public function onRegister() : void
        {
            var _loc_2:String = null;
            var _loc_3:String = null;
            super.onRegister();
            this._tsoDataProxy = new TSODataProxy();
            facade.registerProxy(this._tsoDataProxy);
            ConnectionProxy.VERSION = defines["VERSION_INFO"];
            facade.registerMediator(new SlashCommandMediator());
            facade.registerMediator(new SlashCommandsMediator(this.panel));
            facade.registerMediator(new MessageMediator());
            facade.sendNotification(BlueFireFacade.UPDATE_ROOM_GROUP_SEPERATOR, "-");
            Application.application.GAMESTATE_ID_CHAT_PANEL = this.panel;
            globalFlash.gui.mChatPanel = this;
            Application.application.blueFireComponent.visible = true;
            this.panel.messageHistory.addEventListener(TextEvent.LINK, this.HandleLink);
            this.panel.whispers.addEventListener(ChatTabPrivateListItemRenderer.PRIVATE_LIST_REMOVE, this.whispers_RemoveHandler);
            this.panel.addEventListener(Event.ENTER_FRAME, this.handleEnterFrame);
            var _loc_1:* = cLocaManager.GetInstance().GetGroup(LOCA_GROUP.CHAT_MESSAGES);
            for (_loc_2 in _loc_1)
            {
                
                TextController.instance.registerIdentifier(_loc_2, _loc_1[_loc_2]);
            }
            _loc_1 = cLocaManager.GetInstance().GetGroup(LOCA_GROUP.LABELS);
            for (_loc_3 in _loc_1)
            {
                
                TextController.instance.registerIdentifier(_loc_3, _loc_1[_loc_3]);
            }
            this._tabSortingIndices["global"] = 0;
            this._tabSortingIndices["help"] = 1;
            this._tabSortingIndices["trade"] = 2;
            this._tabSortingIndices["gc"] = 3;
            this._tabSortingIndices["gco"] = 4;
            this._tabSortingIndices["whisper"] = 5;
            this._tabSortingIndices["news"] = 6;
            this._tabSortingIndices["all"] = 7;
            this.panel.btnAddOffer.addEventListener(MouseEvent.CLICK, this.handleAddOfferClick);
            this.panel.btnClearTradeOffer.addEventListener(MouseEvent.CLICK, this.handleClearOfferClick);
            this.panel.btnUpdateOffers.addEventListener(MouseEvent.CLICK, this.handleUpdateOffersClick);
            this.panel.btnSendTrade.addEventListener(MouseEvent.CLICK, this.SendTradeMail);
            this.panel.tradeOffers.addEventListener(ListEvent.ITEM_CLICK, this.HandleSelectTradeOffer);
            this.panel.btnResetCooldown.addEventListener(MouseEvent.CLICK, this.handleResetCooldownClick);
            this.panel.btnResetCooldown.addEventListener(ToolTipEvent.TOOL_TIP_CREATE, this.CreateResetCooldownTooltip);
            this.panel.messageInput.com.bluebyte.bluefire.puremvc.view:IBFTextInput::addEventListener(KeyboardEvent.KEY_UP, this.KeyDown);
            return;
        }// end function

        public function sendTradeOffer(param1:dResource, param2:dResource) : void
        {
            var _loc_3:* = new cTradeData();
            _loc_3.offer = param1;
            _loc_3.costs = param2;
            this.sendMessage("trade", _loc_3.toString());
            this.mCurrentTradeOfferCooldownTimestamp = gMisc.GetTimeSinceStartup() + global.tradeOfferDuration;
            _loc_3.senderName = "";
            this.SetCurrentTradeOffer(_loc_3);
            cLocalSettingsManager.currentTradeOffer = _loc_3;
            cLocalSettingsManager.tradeCooldownStartTime = new Date();
            return;
        }// end function

        private function HandleMessageHistoryStopClick(event:MouseEvent) : void
        {
            event.stopImmediatePropagation();
            event.preventDefault();
            this.panel.messageHistory.removeEventListener(MouseEvent.CLICK, this.HandleMessageHistoryStopClick);
            return;
        }// end function

        public function setGuildTag(param1:String = null) : void
        {
            this._tsoDataProxy.playerTag = param1;
            return;
        }// end function

        private function addTradeEraseToQueue(param1:int, param2:Date) : void
        {
            this.mTradeEraseQueue[param1] = param2;
            return;
        }// end function

        public function setPlayerName(param1:String) : void
        {
            if (!connectionProxy.player)
            {
                connectionProxy.player = new PlayerVO();
            }
            connectionProxy.player.name = param1;
            return;
        }// end function

        public function joinOfficersChannel(param1:dGuildVO) : void
        {
            if (connectionProxy.status == ConnectionStatus.LOGIN_FAILED || connectionProxy.status == ConnectionStatus.SERVER_NOT_AVAILABLE || connectionProxy.status == ConnectionStatus.TRYING_TO_CONNECT || connectionProxy.status == ConnectionStatus.LOGGING_IN)
            {
                return;
            }
            if (!this._officersChannelJoined)
            {
                facade.sendNotification(BlueFireFacade.ROOM_JOIN_EXPLICIT, new RoomJoinRequestVO("gco_" + param1.id));
            }
            this._officersChannelJoined = true;
            return;
        }// end function

        protected function handleEnterFrame(event:Event) : void
        {
            var _loc_2:int = 0;
            if (connectionProxy.status == ConnectionStatus.LOGGED_IN && global.ui.mCurrentPlayerZone.mStreetDataMap.GetLogisticsHouse() && !this._tradeJoined)
            {
                if (global.ui.mCurrentPlayerZone.mStreetDataMap.GetLogisticsHouse().GetBuildingMode() != cBuilding.BUILDING_MODE_PRODUCES_NO_RESOURCES)
                {
                    return;
                }
                sendNotification(BlueFireFacade.ROOM_JOIN_EXPLICIT, new RoomJoinRequestVO("trade"));
                this._tradeJoined = true;
                if (cLocalSettingsManager.tradeCooldownStartTime != null)
                {
                    _loc_2 = cLocalSettingsManager.tradeCooldownStartTime.getTime() + global.tradeOfferDuration - new Date().getTime();
                    if (_loc_2 > 0)
                    {
                        this.mCurrentTradeOfferCooldownTimestamp = gMisc.GetTimeSinceStartup() + _loc_2;
                        this.SetCurrentTradeOffer(cLocalSettingsManager.currentTradeOffer);
                    }
                }
            }
            else if (!global.ui.mCurrentPlayerZone.mStreetDataMap.GetLogisticsHouse() && this._tradeJoined)
            {
                sendNotification(BlueFireFacade.ROOM_LEAVE, "trade");
                sendNotification(BlueFireFacade.REMOVE_CHANNEL, "trade");
                if (this.panel.tradeChannel.visible)
                {
                    this.panel.messageInput.visible = true;
                    this.panel.tradeChannel.visible = false;
                    this.panel.vbox.visible = true;
                    this.panel.messageInput.visible = true;
                }
                this._tradeJoined = false;
            }
            return;
        }// end function

        public function setPlayerID(param1:int) : void
        {
            if (!connectionProxy.player)
            {
                connectionProxy.player = new PlayerVO();
            }
            connectionProxy.player.id = param1;
            return;
        }// end function

        public function IsConnectionEstablished() : Boolean
        {
            return this._connectionEstablished;
        }// end function

        private function handleAddOfferClick(event:MouseEvent) : void
        {
            globalFlash.gui.mTradingPanel.SetData(null);
            globalFlash.gui.mTradingPanel.Show();
            return;
        }// end function

        private function AddHardCurrencyHandler(event:CloseEvent) : void
        {
            if (event.detail == Alert.OK)
            {
                globalFlash.gui.mShopWindow.AddHardCurrency(null);
            }
            return;
        }// end function

        override public function handleNotification(param1:INotification) : void
        {
            var _loc_2:RoomPresenceUpdatedVO = null;
            var _loc_3:PresenceUpdatedVO = null;
            var _loc_4:MessageVO = null;
            var _loc_5:String = null;
            var _loc_6:Array = null;
            var _loc_7:int = 0;
            var _loc_8:int = 0;
            var _loc_9:ChannelVO = null;
            var _loc_10:int = 0;
            var _loc_11:ChannelVO = null;
            var _loc_12:int = 0;
            var _loc_13:dGuildVO = null;
            var _loc_14:RoomVO = null;
            var _loc_15:Array = null;
            var _loc_16:String = null;
            var _loc_17:int = 0;
            var _loc_18:String = null;
            var _loc_19:Boolean = false;
            var _loc_20:String = null;
            var _loc_21:int = 0;
            var _loc_22:int = 0;
            var _loc_23:String = null;
            var _loc_24:cTradeData = null;
            var _loc_25:Boolean = false;
            var _loc_26:String = null;
            var _loc_27:int = 0;
            var _loc_28:ChannelVO = null;
            super.handleNotification(param1);
            switch(param1.getName())
            {
                case BlueFireFacade.ADD_CHANNEL:
                case BlueFireFacade.REMOVE_CHANNEL:
                {
                    this.panel.mucs.dataProvider.refresh();
                    break;
                }
                case BlueFireFacade.CONNECTION_ERROR:
                {
                    _loc_7 = param1.getBody() as int;
                    switch(_loc_7)
                    {
                        case ConnectionStatus.LOGIN_FAILED:
                        {
                            PutMessageToChannelWithoutServer("news", new Date(), cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "chatnews"), cLocaManager.GetInstance().GetText(LOCA_GROUP.CHAT_MESSAGES, "ClientLoginFailed"), false, true);
                            _loc_8 = 0;
                            while (_loc_8 < connectionProxy.channels.length)
                            {
                                
                                _loc_9 = connectionProxy.channels[_loc_8];
                                if (_loc_9.name != "news")
                                {
                                    sendNotification(BlueFireFacade.REMOVE_CHANNEL, _loc_9.name);
                                    _loc_8 = _loc_8 - 1;
                                }
                                _loc_8++;
                            }
                            this.panel.chatstatusbox.visible = false;
                            break;
                        }
                        case ConnectionStatus.SERVER_NOT_AVAILABLE:
                        {
                            PutMessageToChannelWithoutServer("news", new Date(), cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "chatnews"), cLocaManager.GetInstance().GetText(LOCA_GROUP.CHAT_MESSAGES, "ClientNoServer"), false, true);
                            _loc_10 = 0;
                            while (_loc_10 < connectionProxy.channels.length)
                            {
                                
                                _loc_11 = connectionProxy.channels[_loc_10];
                                if (_loc_11.name != "news")
                                {
                                    sendNotification(BlueFireFacade.REMOVE_CHANNEL, _loc_11.name);
                                    _loc_10 = _loc_10 - 1;
                                }
                                _loc_10++;
                            }
                            this._tradeJoined = false;
                            this._guildChannelJoined = false;
                            this._officersChannelJoined = false;
                            this._connectionEstablished = false;
                            this.panel.chatstatusbox.visible = false;
                            global.ui.CreateGameTickCommand(global.ui.mCurrentPlayer.GetPlayerId(), COMMAND.RECONNECT_TO_CHAT, null, this._reconnectIntervall);
                            break;
                        }
                        case ConnectionStatus.TRYING_TO_CONNECT:
                        {
                            break;
                        }
                        default:
                        {
                            break;
                        }
                    }
                    break;
                }
                case BlueFireFacade.ROOM_OCCUPANT_PRESENCE_UPDATED:
                {
                    _loc_2 = param1.getBody() as RoomPresenceUpdatedVO;
                    globalFlash.gui.mFriendsList.SetOnlineStatus(_loc_2.name.toLowerCase(), _loc_2.online, true);
                    break;
                }
                case BlueFireFacade.FRIEND_PRESENCE_UPDATED:
                {
                    _loc_3 = param1.getBody() as PresenceUpdatedVO;
                    globalFlash.gui.mFriendsList.SetOnlineStatus(_loc_3.name.toLowerCase(), _loc_3.online, false);
                    break;
                }
                case XIFFConnectionMediator.XIFF_CONNECT:
                {
                    this.panel.chatstatusbox.visible = true;
                    break;
                }
                case BlueFireFacade.CONNECTED:
                {
                    this.panel.chatstatusbox.visible = false;
                    break;
                }
                case BlueFireFacade.LOGGED_IN:
                {
                    _loc_12 = cLocalSettingsManager.currentGlobalChatInstance;
                    if (_loc_12 != 0)
                    {
                        sendNotification(BlueFireFacade.ROOM_JOIN_EXPLICIT, new RoomJoinRequestVO("global-" + _loc_12));
                    }
                    else
                    {
                        this.joinGlobalRoomDependingOnCountry();
                    }
                    sendNotification(BlueFireFacade.ROOM_JOIN_EXPLICIT, new RoomJoinRequestVO("help"));
                    _loc_13 = global.ui.mCurrentPlayerGuild;
                    if (_loc_13)
                    {
                        this.joinGuildChannel(_loc_13);
                        if (_loc_13.playerPermissions.OfficersChannel())
                        {
                            this.joinOfficersChannel(_loc_13);
                        }
                    }
                    break;
                }
                case BlueFireFacade.ROOM_JOINED:
                {
                    _loc_14 = param1.getBody() as RoomVO;
                    _loc_15 = _loc_14.name.split("-");
                    if (_loc_15.length > 1)
                    {
                        _loc_16 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ChatLabelInstance", ["chat" + _loc_15[0], "ChatDelimiter", _loc_15[1]]);
                        cLocalSettingsManager.currentGlobalChatInstance = _loc_15[1];
                    }
                    else
                    {
                        _loc_16 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "chat" + _loc_15[0]);
                    }
                    if (_loc_14.name.indexOf("gc_") == 0)
                    {
                        _loc_16 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "chatguild");
                    }
                    else if (_loc_14.name.indexOf("gco_") == 0)
                    {
                        _loc_16 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "chatofficers");
                    }
                    _loc_17 = 0;
                    _loc_18 = _loc_14.name.toLowerCase().split("_")[0].split("-")[0];
                    if (this._tabSortingIndices.hasOwnProperty(_loc_18))
                    {
                        _loc_17 = this._tabSortingIndices[_loc_18];
                    }
                    _loc_19 = true;
                    this.addChannel(_loc_14.name, [_loc_14.name], _loc_19, _loc_17, _loc_16);
                    break;
                }
                case BlueFireFacade.ROOM_LEFT:
                {
                    _loc_20 = param1.getBody() as String;
                    _loc_21 = 0;
                    while (_loc_21 < this.panel.mucs.dataProvider.length)
                    {
                        
                        if ((this.panel.mucs.dataProvider[_loc_21] as ChannelVO).name == _loc_20)
                        {
                            this.panel.mucs.dataProvider.removeItemAt(_loc_21);
                            break;
                        }
                        _loc_21++;
                    }
                    break;
                }
                case BlueFireFacade.MESSAGE_CREATED_ADDED:
                {
                    _loc_4 = param1.getBody() as MessageVO;
                    if (TextController.instance.getText("ClientWelcomeRoom", [_loc_4.sender.name]))
                    {
                        if (_loc_4.sender.name.indexOf("gc_") == 0)
                        {
                            _loc_4.sender.name = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "chatguild");
                            _loc_4.text = global.ui.GetCurrentPlayerGuild().motd;
                        }
                        else if (_loc_4.sender.name.indexOf("gco_") == 0)
                        {
                            _loc_4.sender.name = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "chatofficers");
                            _loc_4.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.CHAT_MESSAGES, "ClientWelcomeOfficers");
                        }
                    }
                    if (_loc_4.room == "trade" && _loc_4.getExtension("bbmsg"))
                    {
                        _loc_22 = (_loc_4.getExtension("bbmsg") as SWMMOChatMessage).mPlayerID;
                        _loc_23 = (_loc_4.getExtension("bbmsg") as SWMMOChatMessage).mPlayerName;
                        if (_loc_23.toLowerCase() == connectionProxy.player.name.toLowerCase())
                        {
                            return;
                        }
                        if (_loc_4.text == "clear")
                        {
                            this.addTradeEraseToQueue(_loc_22, new Date());
                            return;
                        }
                        _loc_24 = new cTradeData();
                        _loc_24.senderID = _loc_22;
                        _loc_24.senderName = _loc_23;
                        _loc_25 = _loc_24.parseData(_loc_4.text, new Date());
                        if (!_loc_25)
                        {
                            return;
                        }
                        this.addTradeDataToQueue(_loc_24);
                        return;
                    }
                    if (!_loc_4.groupMessage && this.panel.selectedChannel.name.toLowerCase() != _loc_4.sender.name.toLowerCase() && global.ui.mCurrentPlayer.GetPlayerName_string().toLowerCase() != _loc_4.sender.name.toLowerCase())
                    {
                        cSoundManager.GetInstance().PlayEffect("ChatWhisper");
                    }
                    break;
                }
                case BlueFireFacade.MESSAGE_CUSTOMALERT:
                {
                    _loc_4 = param1.getBody() as MessageVO;
                    _loc_5 = "";
                    _loc_6 = _loc_4.text.split("|");
                    if (_loc_6.length > 1)
                    {
                        _loc_26 = _loc_6[0];
                        _loc_6 = _loc_6.slice(1);
                        _loc_5 = cLocaManager.GetInstance().GetText(LOCA_GROUP.CHAT_MESSAGES, _loc_26, _loc_6);
                    }
                    else
                    {
                        _loc_5 = _loc_4.text;
                    }
                    CustomAlert.show(_loc_5, _loc_4.sender.name, Alert.OK, null, null, null, 4, false);
                    break;
                }
                case BlueFireFacade.LEAVE_CHAT:
                {
                    if (connectionProxy.player.name.toLowerCase().indexOf("bb_") == 0 || connectionProxy.player.name.toLowerCase().indexOf("mod_") == 0)
                    {
                        _loc_27 = 0;
                        while (_loc_27 < connectionProxy.channels.length)
                        {
                            
                            _loc_28 = connectionProxy.channels[_loc_27];
                            if (_loc_28.name != "news")
                            {
                                sendNotification(BlueFireFacade.REMOVE_CHANNEL, _loc_28.name);
                                _loc_27 = _loc_27 - 1;
                            }
                            _loc_27++;
                        }
                        this.panel.chatstatusbox.visible = false;
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

        public function EstablishConnection(param1:String, param2:String) : void
        {
            if (this._connectionEstablished)
            {
                return;
            }
            if (global.ui.mCurrentPlayer.GetPlayerId() == 0)
            {
                return;
            }
            if (!globalFlash.gui.mFriendsList.IsLoaded())
            {
                return;
            }
            if (!connectionProxy.player)
            {
                connectionProxy.player = new PlayerVO();
            }
            if (!connectionProxy.player.name)
            {
                connectionProxy.player.name = param1;
            }
            if (!connectionProxy.player.id)
            {
                connectionProxy.player.id = global.ui.mCurrentPlayer.GetPlayerId();
            }
            connectionProxy.player.password = param2;
            var _loc_3:* = new ServerVO();
            _loc_3.port = URLUtil.getPort(defines.CHAT_BOSH_URL);
            _loc_3.ip = URLUtil.getServerName(defines.CHAT_SOCKET_URL);
            facade.sendNotification(BlueFireFacade.UPDATE_SERVER_DATA, _loc_3);
            this.addChannel("news", ["news"], true, this._tabSortingIndices["news"], cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ChatNews"));
            this.addChannel("whisper", [], true, this._tabSortingIndices["whisper"], cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ChatWhisper"));
            facade.sendNotification(XIFFConnectionMediator.XIFF_CONNECT);
            this._connectionEstablished = true;
            return;
        }// end function

        private function InputFocusInHandler(event:FocusEvent) : void
        {
            (global.ui as cGameInterface).ActivateChatWindow(true);
            if (this.panel.messageInput.text == cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ChatInputHelp"))
            {
                this.panel.messageInput.text = "";
            }
            return;
        }// end function

        public function joinGuildChannel(param1:dGuildVO) : void
        {
            if (connectionProxy.status == ConnectionStatus.LOGIN_FAILED || connectionProxy.status == ConnectionStatus.SERVER_NOT_AVAILABLE || connectionProxy.status == ConnectionStatus.TRYING_TO_CONNECT || connectionProxy.status == ConnectionStatus.LOGGING_IN)
            {
                return;
            }
            if (!this._guildChannelJoined)
            {
                facade.sendNotification(BlueFireFacade.ROOM_JOIN_EXPLICIT, new RoomJoinRequestVO("gc_" + param1.id, true));
            }
            this._guildChannelJoined = true;
            return;
        }// end function

        public function get roomSeperator() : String
        {
            return connectionProxy.CONSTANTS.ROOM_GROUP_SEPERATOR;
        }// end function

        public function sendMessage(param1:String, param2:String) : void
        {
            var _loc_3:* = new MessageVO();
            _loc_3.room = "trade";
            _loc_3.text = param2;
            _loc_3.groupMessage = true;
            sendNotification(BlueFireFacade.SEND_MESSAGE, _loc_3);
            (global.ui as cGameInterface).SendServerAction(COMMAND.PLAYER_ACTION, 0, 0, 0, "Sent Trade Message");
            return;
        }// end function

        private function handleUpdateOffersClick(event:MouseEvent) : void
        {
            this.updateTradeOffers();
            this.panel.btnSendTrade.enabled = false;
            return;
        }// end function

        public function reEstablishConnection(param1:String, param2:String) : void
        {
            if (this._connectionEstablished)
            {
                return;
            }
            if (global.ui.mCurrentPlayer.GetPlayerId() == 0)
            {
                return;
            }
            if (!globalFlash.gui.mFriendsList.IsLoaded())
            {
                return;
            }
            if (!connectionProxy.player)
            {
                connectionProxy.player = new PlayerVO();
            }
            if (!connectionProxy.player.name)
            {
                connectionProxy.player.name = param1;
            }
            if (!connectionProxy.player.id)
            {
                connectionProxy.player.id = global.ui.mCurrentPlayer.GetPlayerId();
            }
            connectionProxy.player.password = param2;
            facade.sendNotification(XIFFConnectionMediator.XIFF_CREATE_NEW_CONNECTION);
            this.addChannel("whisper", [], true, this._tabSortingIndices["whisper"], cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ChatWhisper"));
            facade.sendNotification(XIFFConnectionMediator.XIFF_CONNECT);
            this._connectionEstablished = true;
            return;
        }// end function

        private function addChannel(param1:String, param2:Array, param3:Boolean, param4:int, param5:String = null) : void
        {
            var _loc_7:String = null;
            var _loc_6:* = new ChannelVO();
            new ChannelVO().name = param1;
            _loc_6.label = param5;
            if (!_loc_6.label)
            {
                _loc_6.label = _loc_6.name;
            }
            for each (_loc_7 in param2)
            {
                
                _loc_6.addRoom(_loc_7);
            }
            _loc_6.visible = param3;
            _loc_6.sortingIndex = param4;
            facade.sendNotification(BlueFireFacade.ADD_CHANNEL, _loc_6);
            return;
        }// end function

        private function HandleLink(event:TextEvent) : void
        {
            var _loc_4:String = null;
            var _loc_5:Array = null;
            var _loc_6:dPlayerListItemVO = null;
            var _loc_2:* = event.text.split("?");
            var _loc_3:* = new Object();
            for each (_loc_4 in _loc_2)
            {
                
                _loc_5 = _loc_4.split("=");
                _loc_3[_loc_5[0]] = _loc_5[1];
            }
            if (_loc_3["action"] == "whisper")
            {
                globalFlash.gui.mFriendsListMenu.Move(Application.application.mouseX, Application.application.mouseY);
                _loc_6 = new dPlayerListItemVO();
                _loc_6.username = _loc_3["fname"].split("|")[0];
                _loc_6.id = _loc_3["fname"].split("|")[1];
                globalFlash.gui.mFriendsListMenu.SetData(_loc_6);
                globalFlash.gui.mFriendsListMenu.Show();
                this.panel.messageHistory.addEventListener(MouseEvent.CLICK, this.HandleMessageHistoryStopClick);
            }
            else
            {
                gMisc.Assert(false, "Wrong link type!");
            }
            return;
        }// end function

        override protected function HandleTabClick(event:ListEvent) : void
        {
            super.HandleTabClick(event);
            event.target.dataProvider.refresh();
            var _loc_2:* = event.itemRenderer.data as ChannelVO;
            if (_loc_2.name == "trade")
            {
                this.panel.vbox.visible = false;
                this.panel.privateList.visible = false;
                this.panel.privatedetailsHeader.visible = false;
                this.panel.tradeChannel.visible = true;
                this.panel.tradeOffers.selectedItem = null;
                this.panel.btnSendTrade.enabled = false;
                this.panel.messageInput.visible = false;
            }
            else if (_loc_2.name == "news")
            {
                this.panel.messageInput.visible = false;
                this.panel.tradeChannel.visible = false;
                this.panel.vbox.visible = true;
            }
            else
            {
                this.panel.messageInput.visible = true;
                this.panel.tradeChannel.visible = false;
                this.panel.vbox.visible = true;
                this.panel.messageInput.visible = true;
            }
            return;
        }// end function

        private function HandleSelectTradeOffer(event:ListEvent) : void
        {
            var _loc_4:dPlayerListItemVO = null;
            if (!this.panel.tradeOffers.selectedItem)
            {
                this.panel.btnSendTrade.enabled = false;
                return;
            }
            var _loc_2:* = this.panel.tradeOffers.selectedItem as cTradeData;
            var _loc_3:* = global.ui.mCurrentPlayerZone.GetResources(global.ui.mCurrentPlayer);
            this.panel.btnSendTrade.enabled = _loc_3.HasPlayerResource(_loc_2.costs.name_string, _loc_2.costs.amount) && this.panel.tradeOffers.selectedItem.accepted == false;
            if (event.itemRenderer is TradeGridPlayerItemRenderer)
            {
                globalFlash.gui.mFriendsListMenu.Move(Application.application.mouseX, Application.application.mouseY);
                _loc_4 = new dPlayerListItemVO();
                _loc_4.username = _loc_2.senderName;
                _loc_4.id = _loc_2.senderID;
                globalFlash.gui.mFriendsListMenu.SetData(_loc_4);
                globalFlash.gui.mFriendsListMenu.Show();
            }
            return;
        }// end function

        public function leaveGuildChannels() : void
        {
            this._guildChannelJoined = false;
            this._officersChannelJoined = false;
            return;
        }// end function

        override public function listNotificationInterests() : Array
        {
            var _loc_1:* = super.listNotificationInterests();
            _loc_1.push(BlueFireFacade.CONNECTED);
            _loc_1.push(XIFFConnectionMediator.XIFF_CONNECT);
            _loc_1.push(BlueFireFacade.LOGGED_IN);
            _loc_1.push(BlueFireFacade.ROOM_JOINED);
            _loc_1.push(BlueFireFacade.MESSAGE_CREATED_ADDED);
            _loc_1.push(BlueFireFacade.FRIEND_PRESENCE_UPDATED);
            _loc_1.push(BlueFireFacade.ROOM_OCCUPANT_PRESENCE_UPDATED);
            _loc_1.push(BlueFireFacade.ROOM_LEFT);
            _loc_1.push(BlueFireFacade.CONNECTION_ERROR);
            _loc_1.push(BlueFireFacade.MESSAGE_CUSTOMALERT);
            _loc_1.push(BlueFireFacade.LEAVE_CHAT);
            return _loc_1;
        }// end function

        private function joinGlobalRoomDependingOnCountry() : void
        {
            var _loc_2:cXML = null;
            var _loc_1:* = new Object();
            for each (_loc_2 in global.gameSettingsRootXML.MoveToSubNode("Globals").MoveToSubNode("ChatDefaultChannels").CreateChildrenArray())
            {
                
                _loc_1[_loc_2.GetAttributeString_string("country").toLowerCase()] = _loc_2.GetAttributeString_string("channel");
            }
            if (_loc_1[defines.USER_COUNTRY] > 0)
            {
                sendNotification(BlueFireFacade.ROOM_JOIN_EXPLICIT, new RoomJoinRequestVO("global-" + _loc_1[defines.USER_COUNTRY]));
            }
            else
            {
                sendNotification(BlueFireFacade.ROOM_JOIN_EXPLICIT, new RoomJoinRequestVO("global-1"));
            }
            return;
        }// end function

        private function handleClearOfferClick(event:MouseEvent) : void
        {
            this.clearTradeOffer();
            this.SetCurrentTradeOffer(null);
            return;
        }// end function

        private function SendTradeMail(event:MouseEvent) : void
        {
            var _loc_2:* = new dTradeOfferVO();
            var _loc_3:* = this.panel.tradeOffers.selectedItem as cTradeData;
            _loc_2.offer = new dResourceVO();
            _loc_2.offer.name_string = _loc_3.costs.name_string;
            _loc_2.offer.amount = _loc_3.costs.amount;
            _loc_2.costs = new dResourceVO();
            _loc_2.costs.name_string = _loc_3.offer.name_string;
            _loc_2.costs.amount = _loc_3.offer.amount;
            _loc_2.receipientId = _loc_3.senderID;
            global.ui.mClientMessages.SendMessagetoServer(COMMAND.INITIATE_TRADE, global.ui.mCurrentViewedZoneID, _loc_2);
            this.panel.tradeOffers.selectedItem = null;
            this.panel.btnSendTrade.enabled = false;
            _loc_3.accepted = true;
            (this.panel.tradeOffers.dataProvider as ArrayCollection).removeItemAt((this.panel.tradeOffers.dataProvider as ArrayCollection).getItemIndex(_loc_3));
            globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.TRADE_INITIATED);
            return;
        }// end function

        private function UpdateExpiresTime(event:Event) : void
        {
            var _loc_2:* = this.mCurrentTradeOfferCooldownTimestamp - gMisc.GetTimeSinceStartup();
            if (_loc_2 <= 0)
            {
                this.SetCurrentTradeOffer(null);
                return;
            }
            if (gMisc.GetTimeSinceStartup() - this.mCurrentTradeOfferLastUpdate < 1000)
            {
                return;
            }
            this.mCurrentTradeOfferLastUpdate = gMisc.GetTimeSinceStartup();
            if (this.mCurrentTradeOffer)
            {
                this.panel.expiresLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "TradeOfferExpireTime", [cLocaManager.GetInstance().FormatDuration(_loc_2)]);
            }
            else
            {
                this.panel.expiresLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "TradeOfferCooldown", [cLocaManager.GetInstance().FormatDuration(_loc_2)]);
            }
            return;
        }// end function

    }
}
