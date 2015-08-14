package GUI.GAME
{
    import Analytics.*;
    import Communication.VO.*;
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Loca.*;
    import Interface.*;
    import ServerState.*;
    import ShopSystem.*;
    import __AS3__.vec.*;
    import flash.events.*;
    import flash.net.*;
    import mx.controls.*;
    import mx.events.*;

    public class cShopWindow extends cBasicPanel
    {
        private var mTracker:ShopTracker;
        private var mGI:cGameInterface;
        protected var mPanel:ShopWindow;
        private var mBannersMap:Object;
        private var mIsDeepLink:Boolean = false;
        private var mSelectedItem:cShopItem = null;
        private var mGiftPlayer:dPlayerListItemVO;
        private static var mBannerConfig:Vector.<dBanner>;

        public function cShopWindow()
        {
            this.mBannersMap = {};
            return;
        }// end function

        public function ShowDeepLink(param1:String, param2:int, param3:int = 0) : void
        {
            this.mIsDeepLink = true;
            this.Show();
            var _loc_4:* = cShopItem.GetShopItem(param2);
            if (cShopItem.GetShopItem(param2))
            {
                this.mPanel.groupsList.selectedItem = cShopItemGroup.GetShopItemGroup(_loc_4.GetGroupId());
                this.SelectGroup(null);
                this.mPanel.shopItems.selectedItem = _loc_4;
                this.ShowItemDetails(null);
                this.mTracker.trackPageview("/ShopDeepLink/" + param1 + "/" + cShopItemGroup.GetShopItemGroup(_loc_4.GetGroupId()).GetName_string() + "/" + _loc_4.GetName_string());
                return;
            }
            if (param3 <= 0)
            {
                return;
            }
            var _loc_5:* = cShopItemGroup.GetShopItemGroup(param3);
            if (cShopItemGroup.GetShopItemGroup(param3))
            {
                this.mPanel.groupsList.selectedItem = _loc_5;
                this.SelectGroup(null);
                this.mPanel.itemsStack.selectedIndex = 0;
                this.mTracker.trackPageview("/ShopDeepLink/" + param1 + "/" + _loc_5.GetName_string());
                return;
            }
            this.mTracker.trackPageview("/ShopDeepLink/" + param1);
            return;
        }// end function

        private function EnterDetailsState(event:FlexEvent) : void
        {
            var _loc_3:cItemContent = null;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:dResource = null;
            var _loc_7:ShopResourceItemRenderer = null;
            if (!this.mPanel.frame)
            {
                this.mPanel.itemDetails.addEventListener(FlexEvent.CREATION_COMPLETE, this.EnterDetailsState);
                return;
            }
            if (event)
            {
                this.mPanel.removeEventListener(FlexEvent.CREATION_COMPLETE, this.EnterDetailsState);
            }
            this.mPanel.frame.content = this.mSelectedItem.GetName_string();
            this.mPanel.frame.type = this.mSelectedItem.GetFrameType_string();
            this.mPanel.nameLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.SHOP_ITEMS, this.mSelectedItem.GetName_string());
            this.mPanel.costsLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Costs");
            var _loc_2:Boolean = true;
            for each (_loc_3 in this.mSelectedItem.GetShopItemContent_vector())
            {
                
                if (_loc_3.GetType() != ITEM_CONTENT_TYPE.RESOURCE)
                {
                    _loc_2 = false;
                    break;
                }
            }
            _loc_4 = this.mGI.mCurrentPlayer.GetPurchasedShopItemAmount(this.mSelectedItem.GetId());
            _loc_5 = this.mSelectedItem.GetPerPlayer() - _loc_4;
            if (this.mSelectedItem.GetPerPlayer() > 0)
            {
                this.mPanel.remainingItemsBadge.visible = true;
                this.mPanel.headerContent.setStyle("horizontalCenter", -50);
            }
            else
            {
                this.mPanel.remainingItemsBadge.visible = false;
                this.mPanel.headerContent.setStyle("horizontalCenter", 0);
            }
            this.mPanel.remainingItems.text = _loc_5 + "x";
            if (_loc_5 > 0)
            {
                this.mPanel.remainingItemsBadge.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "RemainingItemsPerPlayer", [_loc_5.toString()]);
                this.mPanel.remainingItems.setStyle("color", 16777215);
            }
            else
            {
                this.mPanel.remainingItemsBadge.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LimitPerPlayerReached");
                this.mPanel.remainingItems.setStyle("color", 11040372);
            }
            this.mPanel.itemDescription1.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.SHOP_ITEM_DESCRIPTIONS_1, this.mSelectedItem.GetName_string());
            this.mPanel.itemDescription2.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.SHOP_ITEM_DESCRIPTIONS_2, this.mSelectedItem.GetName_string());
            if (_loc_2)
            {
                this.mPanel.itemDescription3.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.SHOP_ITEM_DESCRIPTIONS_3, "YouGet");
                for each (_loc_3 in this.mSelectedItem.GetShopItemContent_vector())
                {
                    
                    this.mPanel.itemDescription3.text = this.mPanel.itemDescription3.text + ("\n" + cLocaManager.GetInstance().GetText(LOCA_GROUP.SHOP_ITEM_DESCRIPTIONS_3, "StandardResourceList", [_loc_3.GetCount().toString(), _loc_3.GetResourceName_string()]));
                }
            }
            else
            {
                this.mPanel.itemDescription3.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.SHOP_ITEM_DESCRIPTIONS_3, this.mSelectedItem.GetName_string());
            }
            this.mPanel.costsList.removeAllChildren();
            for each (_loc_6 in this.mSelectedItem.GetCosts_vector())
            {
                
                _loc_7 = new ShopResourceItemRenderer();
                _loc_7.data = _loc_6;
                this.mPanel.costsList.addChild(_loc_7);
            }
            if (this.mGI.mCurrentPlayer.GetPlayerLevel() < this.mSelectedItem.GetPlayerLevel())
            {
                this.mPanel.btnBuy.enabled = false;
                this.mPanel.btnBuy.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LevelRequired", [this.mSelectedItem.GetPlayerLevel()]);
            }
            else if (this.mSelectedItem.GetPerPlayer() > 0 && _loc_4 >= this.mSelectedItem.GetPerPlayer())
            {
                this.mPanel.btnBuy.enabled = false;
                this.mPanel.btnBuy.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LimitPerPlayerReached");
            }
            else
            {
                this.mPanel.btnBuy.enabled = true;
                this.mPanel.btnBuy.toolTip = "";
            }
            this.mPanel.btnBuy.addEventListener(MouseEvent.CLICK, this.BuyItem);
            return;
        }// end function

        private function SelectGroup(event:ListEvent) : void
        {
            var _loc_4:cShopItem = null;
            this.mIsDeepLink = false;
            if (!this.mPanel.groupsList.selectedItem)
            {
                return;
            }
            var _loc_2:* = this.mPanel.groupsList.selectedItem as cShopItemGroup;
            this.mTracker.trackSelectGroup(_loc_2.GetName_string());
            var _loc_3:Array = [];
            for each (_loc_4 in _loc_2.shopItems_vector)
            {
                
                if (!_loc_4.hideInShop())
                {
                    if (this.mGiftPlayer)
                    {
                        if (_loc_4.GetPerPlayer() == 0)
                        {
                            _loc_3.push(_loc_4);
                        }
                        continue;
                    }
                    _loc_3.push(_loc_4);
                }
            }
            _loc_3.sort(SortShopItems);
            this.mPanel.shopItems.dataProvider = _loc_3;
            this.mPanel.itemsStack.selectedIndex = 0;
            return;
        }// end function

        public function SetData() : void
        {
            var _loc_1:* = this.mGI.mCurrentPlayerZone.GetResources(this.mGI.mCurrentPlayer);
            this.mPanel.resourceIconHardCurrency.source = gAssetManager.GetResourceIcon("HardCurrency");
            this.mPanel.resourceLabelHardCurrency.text = Math.floor(_loc_1.GetPlayerResource("HardCurrency").amount).toString();
            this.mPanel.hardCurrency.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, "HardCurrency");
            this.mPanel.groupsList.dataProvider = cShopItemGroup.GetAllShopItemGroups();
            if (this.mIsDeepLink)
            {
                return;
            }
            this.mPanel.groupsList.selectedIndex = 0;
            this.SelectGroup(null);
            return;
        }// end function

        private function ShowItemDetails(event:Event) : void
        {
            this.mSelectedItem = this.mPanel.shopItems.selectedItem as cShopItem;
            this.mTracker.trackSelectItem(this.mSelectedItem.GetName_string());
            this.EnterDetailsState(null);
            this.mPanel.itemsStack.selectedIndex = 1;
            return;
        }// end function

        public function SetGiftPlayer(param1:dPlayerListItemVO) : void
        {
            this.mGiftPlayer = param1;
            return;
        }// end function

        private function BuyItem(event:Event) : void
        {
            var _loc_5:dResource = null;
            var _loc_2:* = this.mPanel.shopItems.selectedItem as cShopItem;
            var _loc_3:* = this.mGI.mCurrentPlayerZone.GetResources(this.mGI.mCurrentPlayer);
            if (!_loc_3.HasPlayerResourcesInListOne(this.mSelectedItem.GetCosts_vector()))
            {
                for each (_loc_5 in this.mSelectedItem.GetCosts_vector())
                {
                    
                    if (_loc_5.name_string == defines.HARD_CURRENCY_RESOURCE_NAME_string && !_loc_3.HasPlayerResource(_loc_5.name_string, _loc_5.amount))
                    {
                        CustomAlert.show("ItemPurchaseSwitchToBuyGems", "", Alert.OK | Alert.CANCEL, null, this.ConfirmAddHardCurrency, null, Alert.OK, true, CustomAlert.STYLE_PAYMENT);
                        return;
                    }
                    CustomAlert.show("ItemPurchaseMissingResource", "ItemPurchaseMissingResource", Alert.OK);
                    return;
                }
            }
            var _loc_4:* = new dBuyShopItemVO();
            new dBuyShopItemVO().itemID = _loc_2.GetId();
            if (this.mGiftPlayer != null)
            {
                _loc_4.giftedPlayerID = this.mGiftPlayer.id;
            }
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.BUY_SHOP_ITEM, this.mGI.mCurrentViewedZoneID, _loc_4);
            this.mPanel.itemsStack.selectedIndex = 0;
            if (this.mGiftPlayer != null)
            {
                CustomAlert.show("GiftPurchased", "GiftPurchased");
            }
            else
            {
                CustomAlert.show("ItemPurchased", "ItemPurchased");
            }
            return;
        }// end function

        private function ClosePanel(event:MouseEvent) : void
        {
            this.Hide();
            return;
        }// end function

        private function BannerClick(event:MouseEvent) : void
        {
            var _loc_2:dBanner = null;
            var _loc_3:cShopItemGroup = null;
            var _loc_4:cShopItem = null;
            _loc_2 = this.mBannersMap[event.currentTarget];
            if (_loc_2 == null)
            {
                return;
            }
            switch(_loc_2.linkType)
            {
                case "ext":
                {
                    navigateToURL(new URLRequest(_loc_2.target), "_blank");
                    break;
                }
                case "group":
                {
                    _loc_3 = cShopItemGroup.GetShopItemGroup(_loc_2.id);
                    if (_loc_3)
                    {
                        this.mPanel.groupsList.selectedItem = _loc_3;
                        this.SelectGroup(null);
                        this.mPanel.itemsStack.selectedIndex = 0;
                    }
                    else
                    {
                        gErrorMessages.ShowErrorMessage("Could not find link target - group-id: " + _loc_2.id);
                    }
                    break;
                }
                case "item":
                {
                    _loc_4 = cShopItem.GetShopItem(_loc_2.id);
                    if (_loc_4)
                    {
                        this.mPanel.groupsList.selectedItem = cShopItemGroup.GetShopItemGroup(_loc_4.GetGroupId());
                        this.SelectGroup(null);
                        this.mPanel.shopItems.selectedItem = _loc_4;
                        this.ShowItemDetails(null);
                    }
                    else
                    {
                        gErrorMessages.ShowErrorMessage("Could not find link target - item-id: " + _loc_2.id);
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

        override public function Show() : void
        {
            if (this.mGiftPlayer)
            {
                this.mPanel.giftPlayerName.text = this.mGiftPlayer.username;
                this.mPanel.giftPlayerAvatar.data = this.mGiftPlayer;
                this.mPanel.currentState = "";
                this.mTracker.trackShowShop("GiftShop");
            }
            else
            {
                this.mPanel.currentState = "collapsed";
                this.mTracker.trackShowShop("PayShop");
            }
            this.mPanel.label = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "PayShop");
            this.SetData();
            globalFlash.gui.mDarkenPanel.Show();
            super.Show();
            return;
        }// end function

        override public function Hide() : void
        {
            this.mGiftPlayer = null;
            globalFlash.gui.mDarkenPanel.Hide();
            super.Hide();
            return;
        }// end function

        private function ConfirmAddHardCurrency(event:CloseEvent) : void
        {
            if (event.detail == Alert.OK)
            {
                globalFlash.gui.mShopWindow.AddHardCurrency(null);
            }
            return;
        }// end function

        public function Init(param1:ShopWindow) : void
        {
            var _panel:* = param1;
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(_panel);
            this.mPanel = _panel;
            this.InitBanners(cShopWindow.mBannerConfig);
            this.mPanel.btnAddCash.addEventListener(MouseEvent.CLICK, this.AddHardCurrency);
            this.mPanel.btnClose.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            this.mPanel.groupsList.addEventListener(ListEvent.ITEM_CLICK, this.SelectGroup);
            this.mPanel.itemsStack.addEventListener(FlexEvent.CREATION_COMPLETE, function () : void
            {
                null.addEventListener("ShowItemDetails", ShowItemDetails);
                return;
            }// end function
            );
            this.mTracker = new ShopTracker();
            return;
        }// end function

        public function InitBanners(param1) : void
        {
            var _loc_2:dBanner = null;
            var _loc_3:Image = null;
            for each (_loc_2 in param1)
            {
                
                switch(_loc_2.slot)
                {
                    case 1:
                    {
                        _loc_3 = this.mPanel.bannerSmall1;
                        break;
                    }
                    case 2:
                    {
                        _loc_3 = this.mPanel.bannerSmall2;
                        break;
                    }
                    case 3:
                    {
                        _loc_3 = this.mPanel.bannerLarge1;
                        break;
                    }
                    case 4:
                    {
                        _loc_3 = this.mPanel.bannerLarge2;
                        break;
                    }
                    case 5:
                    {
                        _loc_3 = this.mPanel.bannerLarge3;
                        break;
                    }
                    default:
                    {
                        _loc_3 = null;
                        break;
                    }
                }
                if (_loc_3)
                {
                    this.mBannersMap[_loc_3] = _loc_2;
                    _loc_3.source = _loc_2.url;
                    _loc_3.addEventListener(MouseEvent.CLICK, this.BannerClick);
                }
            }
            return;
        }// end function

        public function Refresh() : void
        {
            var _loc_1:* = this.mGI.mCurrentPlayerZone.GetResources(this.mGI.mCurrentPlayer);
            this.mPanel.resourceLabelHardCurrency.text = Math.floor(_loc_1.GetPlayerResource("HardCurrency").amount).toString();
            var _loc_2:* = this.mPanel.shopItems.verticalScrollPosition;
            var _loc_3:* = this.mPanel.shopItems.selectedIndex;
            this.mPanel.shopItems.dataProvider.refresh();
            this.mPanel.shopItems.validateNow();
            this.mPanel.shopItems.verticalScrollPosition = _loc_2;
            this.mPanel.shopItems.selectedIndex = _loc_3;
            this.mPanel.shopItems.invalidateDisplayList();
            this.EnterDetailsState(null);
            return;
        }// end function

        public function AddHardCurrency(event:MouseEvent) : void
        {
            navigateToURL(new URLRequest(defines.PAYMENT_URL), "_blank");
            return;
        }// end function

        private static function SortShopItems(param1:cShopItem, param2:cShopItem) : int
        {
            return param1.GetSortIdx() - param2.GetSortIdx();
        }// end function

        public static function SetBanners(param1) : void
        {
            mBannerConfig = param1;
            return;
        }// end function

    }
}
