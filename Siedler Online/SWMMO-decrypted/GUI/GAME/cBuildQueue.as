package GUI.GAME
{
    import Communication.VO.*;
    import Enums.*;
    import GO.*;
    import GUI.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import Interface.*;
    import ServerState.*;
    import ShopSystem.*;
    import flash.events.*;
    import mx.controls.*;
    import mx.events.*;

    public class cBuildQueue extends cGuiBaseElement
    {
        private var mIndexToDelete:int = -1;
        private var mGI:cGameInterface;
        protected var mBuildQueue:BuildQueue;
        public static const MOVE_DOWN:String = "BuildQueueMoveDown";
        public static const REMOVE:String = "BuildQueueRemove";
        public static const MOVE_UP:String = "BuildQueueMoveUp";
        public static const INSTANT_BUILD:String = "BuildQueueInstantBuild";

        public function cBuildQueue()
        {
            return;
        }// end function

        private function Remove(event:CloseEvent) : void
        {
            if (event.detail != Alert.OK)
            {
                return;
            }
            this.mGI.mCurrentPlayer.mBuildQueue.RemoveGui(this.mIndexToDelete);
            return;
        }// end function

        private function AddATempBuildSlot(event:CloseEvent) : void
        {
            if (event.detail == Alert.OK)
            {
                global.ui.mClientMessages.SendMessagetoServer(COMMAND.BUY_ONE_CLICK_SHOP_ITEM, global.ui.mCurrentViewedZoneID, new dBuyOneClickShopItemVO().Init(8007));
            }
            else
            {
                this.SetEnableBuyTempBuildSlot(true);
            }
            return;
        }// end function

        private function MoveUp(event:ListEvent) : void
        {
            this.mGI.mCurrentPlayer.mBuildQueue.MoveUpGui(event.rowIndex);
            return;
        }// end function

        private function InstantBuild(event:ListEvent) : void
        {
            var _loc_2:* = this.mGI.mCurrentPlayerZone.GetBuildingFromGridPosition(event.rowIndex);
            var _loc_3:* = this.mGI.mCurrentPlayerZone.GetResources(this.mGI.mCurrentPlayer);
            if (_loc_3.HasPlayerResource(defines.HARD_CURRENCY_RESOURCE_NAME_string, _loc_2.GetBuildInstantCosts()))
            {
                global.ui.mClientMessages.SendMessagetoServer(COMMAND.BUY_ONE_CLICK_SHOP_ITEM, this.mGI.mCurrentViewedZoneID, new dBuyOneClickShopItemVO().InitWithBuildingGrid(8000, _loc_2.GetBuildingGrid()));
            }
            else
            {
                CustomAlert.show("MissingHardCurrency", "", Alert.OK | Alert.CANCEL, null, this.AddHardCurrencyHandler, null, Alert.OK, true, CustomAlert.STYLE_PAYMENT);
            }
            this.Hide();
            return;
        }// end function

        private function MoveDown(event:ListEvent) : void
        {
            this.mGI.mCurrentPlayer.mBuildQueue.MoveDownGui(event.rowIndex);
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

        public function Init(param1:BuildQueue) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mBuildQueue = param1;
            this.mBuildQueue.addEventListener(cBuildQueue.MOVE_UP, this.MoveUp);
            this.mBuildQueue.addEventListener(cBuildQueue.MOVE_DOWN, this.MoveDown);
            this.mBuildQueue.addEventListener(cBuildQueue.REMOVE, this.ConfirmRemoveBuilding);
            this.mBuildQueue.addEventListener(cBuildQueue.INSTANT_BUILD, this.InstantBuild);
            this.mBuildQueue.buildExtension.btnBuyTempSlot.addEventListener(MouseEvent.CLICK, this.BuyTempSlot);
            return;
        }// end function

        private function ConfirmRemoveBuilding(event:ListEvent) : void
        {
            this.mIndexToDelete = event.rowIndex;
            var _loc_2:* = CustomAlert.show("ConfirmTeardown", "ConfirmTeardown", Alert.CANCEL | Alert.OK, null, this.Remove);
            _loc_2.addEventListener(CloseEvent.CLOSE, this.Remove);
            return;
        }// end function

        public function SetData(param1) : void
        {
            var _loc_4:cBuilding = null;
            var _loc_6:cBuildSlot = null;
            var _loc_2:Array = [];
            var _loc_3:* = this.mGI.mHomePlayer.GetPermanentBuildQueueSlotsCount();
            for each (_loc_4 in param1)
            {
                
                _loc_2.push(_loc_4);
            }
            if (_loc_2.length > 0)
            {
                while (_loc_2.length < this.mGI.mHomePlayer.mBuildQueue.GetTotalAvailableSlots())
                {
                    
                    if (_loc_2.length < this.mGI.mHomePlayer.mBuildQueue.GetMaxCount() + _loc_3)
                    {
                        _loc_6 = new cBuildSlot(0, 0);
                        _loc_6.mType = _loc_2.length >= this.mGI.mHomePlayer.mBuildQueue.GetMaxCount() ? (cBuildSlot.PERMANENT_BUILDSLOT) : (cBuildSlot.REGULAR_BUILDSLOT);
                    }
                    else
                    {
                        _loc_6 = this.mGI.mHomePlayer.mBuildQueue.GetTempSlots_vector()[_loc_2.length - (_loc_3 + this.mGI.mHomePlayer.mBuildQueue.GetMaxCount())];
                    }
                    _loc_2.push(_loc_6);
                }
            }
            if (_loc_2.length > 0 && !this.IsVisible())
            {
                this.Show();
            }
            else if (_loc_2.length == 0)
            {
                this.Hide();
            }
            var _loc_5:* = this.mBuildQueue.list.verticalScrollPosition;
            this.mBuildQueue.list.dataProvider = _loc_2;
            this.mBuildQueue.list.verticalScrollPosition = _loc_5;
            this.mBuildQueue.buildExtension.btnBuyTempSlot.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.SHOP_ITEMS, "TempBuildSlot", [this.mGI.mHomePlayer.mBuildQueue.GetTempSlots_vector().length, global.maxTempSlotsAvailablePerPlayer]);
            this.mBuildQueue.width = this.mBuildQueue.list.measureHeightOfItems() > this.mBuildQueue.list.height ? (110) : (93);
            return;
        }// end function

        public function SetEnableBuyTempBuildSlot(param1:Boolean) : void
        {
            this.mBuildQueue.buildExtension.btnBuyTempSlot.enabled = param1;
            return;
        }// end function

        private function BuyTempSlot(event:MouseEvent) : void
        {
            var _loc_2:* = cShopItem.GetShopItem(8007);
            var _loc_3:* = global.ui.mCurrentPlayerZone.GetResources(global.ui.mCurrentPlayer);
            if (_loc_3.HasPlayerResourcesInList(_loc_2.GetCosts_vector(), 1))
            {
                this.SetEnableBuyTempBuildSlot(false);
                CustomAlert.show("ConfirmAddTempBuildQueueSlot", "ConfirmAddTempBuildQueueSlot", Alert.OK | Alert.CANCEL, null, this.AddATempBuildSlot, null, Alert.OK, true, CustomAlert.STYLE_DEFAULT);
            }
            else
            {
                CustomAlert.show("MissingHardCurrency", "", Alert.OK | Alert.CANCEL, null, this.AddHardCurrencyHandler, null, Alert.OK, true, CustomAlert.STYLE_PAYMENT);
            }
            return;
        }// end function

    }
}
