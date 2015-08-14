package GUI.GAME
{
    import BuffSystem.*;
    import Communication.VO.*;
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import Interface.*;
    import MilitarySystem.*;
    import ServerState.*;
    import __AS3__.vec.*;
    import flash.events.*;
    import mx.collections.*;
    import mx.events.*;

    public class cTradingPanel extends cBasicPanel
    {
        private var mCostsResource:dResource = null;
        private var mGI:cGameInterface;
        private var mSelectedResource:dResource = null;
        private var mSelectedBuff:cBuff = null;
        protected var mPanel:TradingPanel;
        private var mDestinationPlayer:dPlayerListItemVO;
        private var mOfferResource:dResource = null;
        private var mOfferBuff:cBuff = null;
        private var mResourceSlot:int = 0;
        private static const RESOURCE_SLOT_OFFER:int = 1;
        private static const RESOURCE_SLOT_COSTS:int = 2;

        public function cTradingPanel()
        {
            return;
        }// end function

        private function ApplySelection(event:MouseEvent) : void
        {
            switch(this.mResourceSlot)
            {
                case RESOURCE_SLOT_COSTS:
                {
                    this.mCostsResource = this.mSelectedResource;
                    this.mPanel.costRenderer.data = this.mCostsResource;
                    this.mPanel.costRenderer.visible = true;
                    break;
                }
                case RESOURCE_SLOT_OFFER:
                {
                    if (this.mSelectedResource)
                    {
                        this.mOfferBuff = null;
                        this.mOfferResource = this.mSelectedResource;
                        this.mPanel.offerResourceRenderer.data = this.mOfferResource;
                        this.mPanel.offerResourceRenderer.visible = true;
                        this.mPanel.offerBuffRenderer.visible = false;
                    }
                    else if (this.mSelectedBuff)
                    {
                        this.mOfferResource = null;
                        this.mOfferBuff = this.mSelectedBuff;
                        this.mPanel.offerBuffRenderer.data = this.mOfferBuff;
                        this.mPanel.offerBuffRenderer.visible = true;
                        this.mPanel.offerResourceRenderer.visible = false;
                    }
                    break;
                }
                default:
                {
                    break;
                }
            }
            this.mPanel.currentState = "";
            this.mPanel.btnSendTrade.enabled = this.mCostsResource && (this.mOfferBuff || this.mOfferResource && this.mOfferResource.name_string != this.mCostsResource.name_string);
            if (!(this.mOfferResource || this.mOfferBuff) || !this.mCostsResource)
            {
                this.mPanel.btnSendTrade.enabled = false;
                this.mPanel.btnSendTrade.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "SelectTradeResources");
            }
            else if (this.mOfferResource && this.mOfferResource.name_string == this.mCostsResource.name_string)
            {
                this.mPanel.btnSendTrade.enabled = false;
                this.mPanel.btnSendTrade.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "CannotTradeEqualResources");
            }
            else
            {
                this.mPanel.btnSendTrade.enabled = true;
                if (this.mDestinationPlayer)
                {
                    this.mPanel.btnSendTrade.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "SendTradeRequest");
                }
                else
                {
                    this.mPanel.btnSendTrade.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "TradeOfferAdd");
                }
            }
            return;
        }// end function

        private function SetAmount(event:SliderEvent) : void
        {
            this.mSelectedResource.amount = this.mPanel.amountSlider.value;
            this.mPanel.resourceAmount.text = this.mPanel.amountSlider.value + " / " + this.mPanel.amountSlider.maximum;
            this.mPanel.btnOK.enabled = true;
            return;
        }// end function

        private function SelectResource(event:ListEvent) : void
        {
            if ((this.mPanel.resourceList.selectedItem as dResource).amount == 0 && this.mResourceSlot == RESOURCE_SLOT_OFFER)
            {
                return;
            }
            this.mSelectedBuff = null;
            this.mSelectedResource = new dResource();
            this.mSelectedResource.name_string = (this.mPanel.resourceList.selectedItem as dResource).name_string;
            this.mSelectedResource.group_string = (this.mPanel.resourceList.selectedItem as dResource).group_string;
            this.mPanel.buffIcon.visible = false;
            this.mPanel.resourceIcon.visible = true;
            this.mPanel.resourceIcon.source = gAssetManager.GetResourceIcon(this.mSelectedResource.name_string);
            this.mPanel.resourceName.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, this.mSelectedResource.name_string);
            this.mPanel.amountSlider.minimum = 1;
            this.mPanel.amountSlider.maximum = this.mResourceSlot == RESOURCE_SLOT_OFFER ? ((this.mPanel.resourceList.selectedItem as dResource).amount < defines.MAX_TRADE_LIMIT ? (Math.floor((this.mPanel.resourceList.selectedItem as dResource).amount)) : (defines.MAX_TRADE_LIMIT)) : (defines.MAX_TRADE_LIMIT);
            this.mPanel.amountSlider.value = this.mResourceSlot == RESOURCE_SLOT_OFFER ? ((this.mPanel.resourceList.selectedItem as dResource).amount < defines.MAX_TRADE_LIMIT ? (Math.floor((this.mPanel.resourceList.selectedItem as dResource).amount)) : (defines.MAX_TRADE_LIMIT)) : (defines.MAX_TRADE_LIMIT);
            this.mPanel.amountSlider.enabled = true;
            this.SetAmount(null);
            return;
        }// end function

        public function SetData(param1:dPlayerListItemVO) : void
        {
            this.mDestinationPlayer = param1;
            var _loc_2:* = this.mGI.mCurrentPlayer.GetAvatarId();
            this.mPanel.playerName.text = this.mGI.mCurrentPlayer.GetPlayerName_string();
            this.mPanel.playerAvatar.source = gAssetManager.GetAvatarUrl(_loc_2, AVATAR_SIZE.SMALL);
            if (this.mDestinationPlayer)
            {
                this.mPanel.labelMiddleColumn.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "SendTradeRequest");
                this.mPanel.btnSendTrade.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "SelectTradeResources");
                this.mPanel.btnSendTrade.setStyle("icon", gAssetManager.GetClass("ButtonIconDiplomacy"));
                this.mPanel.reciepientName.text = this.mDestinationPlayer.username;
                this.mPanel.reciepientAvatar.source = gAssetManager.GetAvatarUrl(this.mDestinationPlayer.avatarId, AVATAR_SIZE.SMALL);
            }
            else
            {
                this.mPanel.labelMiddleColumn.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "TradeOfferAdd");
                this.mPanel.btnSendTrade.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "SelectTradeResources");
                this.mPanel.btnSendTrade.setStyle("icon", gAssetManager.GetClass("ButtonIconTrade"));
                this.mPanel.reciepientName.text = "Marketplace";
                this.mPanel.reciepientName.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Marketplace");
                this.mPanel.reciepientAvatar.source = gAssetManager.GetBitmap("AvatarSmall00");
            }
            return;
        }// end function

        private function SetResourceSlot(event:MouseEvent) : void
        {
            switch(event.currentTarget)
            {
                case this.mPanel.btnSelectCost:
                {
                    this.mResourceSlot = RESOURCE_SLOT_COSTS;
                    break;
                }
                case this.mPanel.btnSelectOffer:
                {
                    this.mResourceSlot = RESOURCE_SLOT_OFFER;
                    break;
                }
                default:
                {
                    break;
                }
            }
            this.mPanel.currentState = "select";
            return;
        }// end function

        private function ExitSelectState(event:FlexEvent) : void
        {
            this.mPanel.resourceIcon.source = null;
            this.mPanel.resourceIcon.visible = false;
            this.mPanel.buffIcon.data = null;
            this.mPanel.buffIcon.visible = false;
            this.mPanel.resourceName.text = "";
            this.mPanel.resourceAmount.text = "";
            this.mPanel.amountSlider.enabled = false;
            return;
        }// end function

        private function SendTrade(event:MouseEvent) : void
        {
            var _loc_2:dTradeOfferVO = null;
            var _loc_3:dItemTradeOfferVO = null;
            if (this.mDestinationPlayer)
            {
                if (this.mOfferResource)
                {
                    _loc_2 = new dTradeOfferVO();
                    _loc_2.offer = new dResourceVO();
                    _loc_2.offer.name_string = this.mOfferResource.name_string;
                    _loc_2.offer.amount = this.mOfferResource.amount;
                    _loc_2.costs = new dResourceVO();
                    _loc_2.costs.name_string = this.mCostsResource.name_string;
                    _loc_2.costs.amount = this.mCostsResource.amount;
                    _loc_2.receipientId = this.mDestinationPlayer.id;
                    this.mGI.mClientMessages.SendMessagetoServer(COMMAND.INITIATE_TRADE, this.mGI.mCurrentViewedZoneID, _loc_2);
                    globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.TRADE_INITIATED);
                }
                else if (this.mOfferBuff)
                {
                    this.mOfferBuff.IncWaitingForServerCount();
                    _loc_3 = new dItemTradeOfferVO();
                    _loc_3.buff = this.mOfferBuff.CreateBuffVOFromBuff();
                    _loc_3.costs = new dResourceVO();
                    _loc_3.costs.name_string = this.mCostsResource.name_string;
                    _loc_3.costs.amount = this.mCostsResource.amount;
                    _loc_3.receipientId = this.mDestinationPlayer.id;
                    this.mGI.mClientMessages.SendMessagetoServer(COMMAND.INITIATE_ITEM_TRADE, this.mGI.mCurrentViewedZoneID, _loc_3);
                    globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.TRADE_INITIATED);
                }
            }
            else
            {
                globalFlash.gui.mChatPanel.sendTradeOffer(this.mOfferResource, this.mCostsResource);
            }
            this.mPanel.btnSendTrade.enabled = false;
            this.Hide();
            return;
        }// end function

        private function EnterSelectState(event:FlexEvent) : void
        {
            this.mPanel.buttonBar.addEventListener(ListEvent.ITEM_CLICK, this.SetFilteredResourceList);
            this.mPanel.btnOK.addEventListener(MouseEvent.CLICK, this.ApplySelection);
            this.mPanel.btnOK.enabled = false;
            var _loc_2:Array = [{label:cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "WarehouseTab1"), group:RESOURCE_GROUP.CL1}, {label:cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "WarehouseTab2"), group:RESOURCE_GROUP.CL2}, {label:cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "WarehouseTab3"), group:RESOURCE_GROUP.CL3}, {label:cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "WarehouseTab4"), group:RESOURCE_GROUP.CL4}];
            if (this.mResourceSlot == RESOURCE_SLOT_OFFER && this.mDestinationPlayer != null)
            {
                _loc_2.push({label:cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "TradeTabItems"), group:RESOURCE_GROUP.ITEMS});
            }
            this.mPanel.buttonBar.dataProvider = _loc_2;
            this.mPanel.resourceList.selectedIndex = 0;
            this.SetFilteredResourceList();
            this.mPanel.resourceList.addEventListener(ListEvent.ITEM_CLICK, this.SelectResource);
            this.mPanel.buffList.addEventListener(ListEvent.ITEM_CLICK, this.SelectBuff);
            this.mPanel.amountSlider.addEventListener(SliderEvent.CHANGE, this.SetAmount);
            return;
        }// end function

        private function SelectBuff(event:ListEvent) : void
        {
            this.mSelectedResource = null;
            this.mSelectedBuff = this.mPanel.buffList.selectedItem as cBuff;
            this.mPanel.buffIcon.visible = true;
            this.mPanel.resourceIcon.visible = false;
            this.mPanel.buffIcon.data = this.mSelectedBuff;
            if (this.mSelectedBuff.GetType_string() == "Adventure")
            {
                this.mPanel.resourceName.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.ADVENTURE_NAME, this.mSelectedBuff.GetResourceName_string());
            }
            else
            {
                this.mPanel.resourceName.text = "";
            }
            this.mPanel.amountSlider.enabled = false;
            this.mPanel.resourceAmount.text = "1/1";
            this.mPanel.btnOK.enabled = true;
            return;
        }// end function

        private function Clear() : void
        {
            this.mSelectedResource = null;
            this.mSelectedBuff = null;
            this.mCostsResource = null;
            this.mOfferResource = null;
            this.mOfferBuff = null;
            this.mPanel.offerResourceRenderer.data = null;
            this.mPanel.offerResourceRenderer.visible = false;
            this.mPanel.offerBuffRenderer.data = null;
            this.mPanel.offerBuffRenderer.visible = false;
            this.mPanel.costRenderer.data = null;
            this.mPanel.costRenderer.visible = false;
            this.mPanel.btnSendTrade.enabled = false;
            return;
        }// end function

        public function Init(param1:TradingPanel) : void
        {
            var _panel:* = param1;
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(_panel);
            this.mPanel = _panel;
            this.mPanel.selectedResource = this.mSelectedResource;
            this.mPanel.close.addEventListener(MouseEvent.CLICK, function () : void
            {
                null.mTradingPanel.Hide();
                return;
            }// end function
            );
            this.mPanel.btnSelectCost.addEventListener(MouseEvent.CLICK, this.SetResourceSlot);
            this.mPanel.btnSelectOffer.addEventListener(MouseEvent.CLICK, this.SetResourceSlot);
            this.mPanel.stateSelect.addEventListener(FlexEvent.ENTER_STATE, this.EnterSelectState);
            this.mPanel.stateSelect.addEventListener(FlexEvent.EXIT_STATE, this.ExitSelectState);
            this.mPanel.btnSendTrade.addEventListener(MouseEvent.CLICK, this.SendTrade);
            return;
        }// end function

        private function SetFilteredResourceList(event:ItemClickEvent = null) : void
        {
            var _loc_6:dResource = null;
            var _loc_7:cSquad = null;
            var _loc_8:cBuff = null;
            var _loc_9:Vector.<String> = null;
            var _loc_10:cResources = null;
            var _loc_11:Vector.<dResource> = null;
            var _loc_12:dResource = null;
            var _loc_2:Array = [];
            var _loc_3:* = this.mGI.mCurrentPlayer;
            var _loc_4:* = event ? (event.index) : (0);
            var _loc_5:* = (this.mPanel.buttonBar.dataProvider as ArrayCollection).getItemAt(_loc_4).group as String;
            if (_loc_3 != null)
            {
                this.mPanel.resourceList.visible = _loc_5 != RESOURCE_GROUP.ITEMS;
                this.mPanel.buffList.visible = _loc_5 == RESOURCE_GROUP.ITEMS;
                if (_loc_5 == RESOURCE_GROUP.MILITARY)
                {
                    for each (_loc_7 in this.mGI.mCurrentPlayerZone.GetArmy(this.mGI.mCurrentPlayer.GetPlayerId()).GetSquads_vector())
                    {
                        
                        _loc_6 = new dResource();
                        _loc_6.name_string = _loc_7.GetType_string();
                        _loc_6.amount = this.mResourceSlot == RESOURCE_SLOT_OFFER ? (_loc_7.GetAmount()) : (-1);
                        _loc_2.push(_loc_6);
                    }
                    this.mPanel.resourceList.dataProvider = _loc_2;
                }
                else if (_loc_5 == RESOURCE_GROUP.ITEMS)
                {
                    for each (_loc_8 in this.mGI.mCurrentPlayer.mAvailableBuffs_vector)
                    {
                        
                        if (_loc_8.GetBuffDefinition().IsTradable() && !_loc_8.GetWaitingForServer())
                        {
                            _loc_2.push(_loc_8);
                        }
                    }
                    this.mPanel.buffList.dataProvider = _loc_2;
                }
                else
                {
                    _loc_9 = global.visibleResources_vector;
                    _loc_10 = this.mGI.mCurrentPlayerZone.GetResources(_loc_3);
                    _loc_11 = _loc_10.GetPlayerResources_vector(_loc_5);
                    for each (_loc_12 in _loc_11)
                    {
                        
                        if (global.visibleResources_vector.indexOf(_loc_12.name_string) > -1)
                        {
                            if (_loc_12.name_string != defines.POPULATION_RESOURCE_NAME_string)
                            {
                                _loc_6 = new dResource();
                                _loc_6.GetFromDResource(_loc_12);
                                _loc_6.amount = this.mResourceSlot == RESOURCE_SLOT_OFFER ? (_loc_6.amount) : (-1);
                                _loc_2.push(_loc_6);
                            }
                        }
                    }
                    this.mPanel.resourceList.dataProvider = _loc_2;
                }
            }
            return;
        }// end function

        override public function Show() : void
        {
            this.Clear();
            super.Show();
            return;
        }// end function

    }
}
