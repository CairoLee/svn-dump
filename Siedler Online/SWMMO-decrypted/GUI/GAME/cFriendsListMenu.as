package GUI.GAME
{
    import AdventureSystem.*;
    import Communication.VO.*;
    import Enums.*;
    import GUI.*;
    import GUI.Components.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Loca.*;
    import Interface.*;
    import __AS3__.vec.*;
    import flash.events.*;
    import flash.net.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import nLib.*;

    public class cFriendsListMenu extends cGuiBaseElement
    {
        private var mPlayerStatus:int;
        private const GUILD_MEMBER:int = 2;
        private var mGI:cGameInterface;
        private const EVENT_ZONE:int = 4;
        private const OWN_PLAYER:int = 0;
        private var mRendererPool:Vector.<FriendsListMenuItemRenderer>;
        private const ADD_FRIEND:int = 5;
        private const FRIEND:int = 1;
        private const FOREIGNER:int = 3;
        protected var mMenu:FriendsListMenu;
        private var mPlayer:dPlayerListItemVO;

        public function cFriendsListMenu()
        {
            return;
        }// end function

        public function Invite(event:MouseEvent) : void
        {
            navigateToURL(new URLRequest(defines.INVITE_URL), "_blank");
            return;
        }// end function

        private function CancelAdventure(event:CloseEvent) : void
        {
            if (event.detail != Alert.OK)
            {
                return;
            }
            globalFlash.gui.mFriendsList.RemoveFriendById(this.mPlayer.id);
            global.ui.mClientMessages.SendMessagetoServer(COMMAND.CANCEL_ADVENTURE, this.mPlayer.id, null);
            return;
        }// end function

        private function Trade(event:MouseEvent) : void
        {
            if (this.mGI.mCurrentPlayerZone.IsBuildingOnMap(defines.LOGISTICS_NAME_string))
            {
                globalFlash.gui.mTradingPanel.SetData(this.mPlayer);
                globalFlash.gui.mTradingPanel.Show();
            }
            else
            {
                CustomAlert.show("NoTradeWithoutLogistics", "NoTradeWithoutLogistics");
            }
            return;
        }// end function

        private function ConfirmRemoveFriend(event:MouseEvent) : void
        {
            CustomAlert.show(cLocaManager.GetInstance().GetText(LOCA_GROUP.ALERT_MESSAGES, "ConfirmRemoveFriend", [this.mPlayer.username]), cLocaManager.GetInstance().GetText(LOCA_GROUP.ALERT_TITLES, "ConfirmRemoveFriend"), Alert.OK | Alert.CANCEL, null, this.RemoveFriend, null, 4, false);
            return;
        }// end function

        public function SetData(param1:dPlayerListItemVO) : void
        {
            this.mPlayer = param1;
            this.mMenu.removeAllChildren();
            if (this.mPlayer == null)
            {
                this.mPlayerStatus = this.ADD_FRIEND;
                this.AddMenuItem("AddFriend", true, this.ShowAddFriendPanel);
                this.AddMenuItem("InviteByMail", true, this.Invite);
            }
            else if (this.mPlayer.id == this.mGI.mCurrentPlayer.GetPlayerId())
            {
                this.mPlayerStatus = this.OWN_PLAYER;
                this.AddMenuItem("ReturnHome", this.mGI.mCurrentPlayer.GetHomeZoneId() != this.mGI.mCurrentViewedZoneID, this.Visit);
                this.AddMenuItem("Whisper", false, this.Whisper);
                this.AddMenuItem("SendMail", false, this.SendMail);
                this.AddMenuItem("Gift", false, this.Gift);
                this.AddMenuItem("Trade", false, this.Trade);
                this.AddMenuItem("RemoveFriend", false, this.ConfirmRemoveFriend);
                this.AddMenuItem("SendArmy", this.mGI.mCurrentViewedZoneID != this.mPlayer.id, this.SendSpecialist);
            }
            else if (this.mPlayer.id < 0)
            {
                this.mPlayerStatus = this.EVENT_ZONE;
                this.AddMenuItem("Visit", this.mGI.mCurrentViewedZoneID != this.mPlayer.id, this.Visit);
                this.AddMenuItem("ShowAdventureDetails", true, this.ShowAdventureDetails);
                this.AddMenuItem("AdventureInvitePlayer", this.mPlayer.adventureVO.players.length < cAdventureDefinition.FindAdventureDefinition(this.mPlayer.adventureVO.adventureName).mMaxPlayers && this.mPlayer.adventureVO.ownerPlayerID == this.mGI.mCurrentPlayer.GetPlayerId(), this.ShowAdventureDetails);
                if (this.mGI.mCurrentViewedZoneID == this.mPlayer.id)
                {
                    this.AddMenuItem("SendArmyBack", this.mPlayer.adventureVO.collectedTime < this.mPlayer.adventureVO.totalDuration && this.mPlayer.adventureVO.status < cAdventure.STATUS_FINISHED_WON, this.SendSpecialist);
                }
                else
                {
                    this.AddMenuItem("SendArmy", this.mPlayer.adventureVO.collectedTime < this.mPlayer.adventureVO.totalDuration && this.mPlayer.adventureVO.status < cAdventure.STATUS_FINISHED_WON, this.SendSpecialist);
                }
                this.AddMenuItem("CancelAdventure", this.mGI.mCurrentPlayer.GetHomeZoneId() == this.mPlayer.adventureVO.ownerPlayerID && this.mPlayer.adventureVO.collectedTime < this.mPlayer.adventureVO.totalDuration && this.mPlayer.adventureVO.status < cAdventure.STATUS_FINISHED_WON, this.ConfirmCancelAdventure);
            }
            else if (globalFlash.gui.mFriendsList.IsFriend(this.mPlayer))
            {
                this.mPlayerStatus = this.FRIEND;
                this.mPlayer = globalFlash.gui.mFriendsList.GetFriendById(this.mPlayer.id);
                this.AddMenuItem("Visit", this.mGI.mCurrentViewedZoneID != this.mPlayer.id, this.Visit);
                this.AddMenuItem("Whisper", true, this.Whisper);
                this.AddMenuItem("SendMail", true, this.SendMail);
                this.AddMenuItem("Gift", true, this.Gift);
                this.AddMenuItem("Trade", true, this.Trade);
                this.AddMenuItem("RemoveFriend", true, this.ConfirmRemoveFriend);
            }
            else if (globalFlash.gui.mFriendsList.IsGuildMember(this.mPlayer))
            {
                this.mPlayerStatus = this.GUILD_MEMBER;
                this.mPlayer = globalFlash.gui.mFriendsList.GetGuildMemberById(this.mPlayer.id);
                this.AddMenuItem("Visit", true, this.Visit);
                this.AddMenuItem("Whisper", true, this.Whisper);
                this.AddMenuItem("SendMail", true, this.SendMail);
                this.AddMenuItem("Gift", true, this.Gift);
                this.AddMenuItem("Trade", true, this.Trade);
            }
            else
            {
                this.mPlayerStatus = this.FOREIGNER;
                this.AddMenuItem("Whisper", true, this.Whisper);
                this.AddMenuItem("SendMail", true, this.SendMail);
                this.AddMenuItem("AddFriend", true, this.AddFriend);
            }
            return;
        }// end function

        private function SendMail(event:MouseEvent) : void
        {
            globalFlash.gui.mMailWindow.EditMailPreselected(this.mPlayer);
            return;
        }// end function

        private function Gift(event:MouseEvent) : void
        {
            globalFlash.gui.mShopWindow.SetGiftPlayer(this.mPlayer);
            globalFlash.gui.mShopWindow.Show();
            return;
        }// end function

        private function ShowAdventureDetails(event:MouseEvent) : void
        {
            globalFlash.gui.mAdventurePanel.SetData(this.mPlayer.adventureVO);
            globalFlash.gui.mAdventurePanel.Show();
            return;
        }// end function

        private function ShowAdventurePlayers(event:MouseEvent) : void
        {
            globalFlash.gui.mAdventurePanel.SetData(this.mPlayer.adventureVO);
            globalFlash.gui.mAdventurePanel.Show();
            return;
        }// end function

        override public function Show() : void
        {
            Application.application.addEventListener(MouseEvent.CLICK, this.HideMenu);
            super.Show();
            this.ResizeHandler(null);
            return;
        }// end function

        private function HideMenu(event:MouseEvent) : void
        {
            Application.application.removeEventListener(MouseEvent.CLICK, this.HideMenu);
            this.Hide();
            return;
        }// end function

        private function RemoveFriend(event:CloseEvent) : void
        {
            if (event.detail != Alert.OK)
            {
                return;
            }
            globalFlash.gui.mFriendsList.RemoveFriend(this.mPlayer.id);
            return;
        }// end function

        private function ResizeHandler(event:ResizeEvent) : void
        {
            if (this.mMenu.x < 0)
            {
                this.mMenu.x = 0;
            }
            if (this.mMenu.y < 0)
            {
                this.mMenu.y = 0;
            }
            if (this.mMenu.x > Application.application.stage.stageWidth - this.mMenu.width)
            {
                this.mMenu.x = Application.application.stage.stageWidth - this.mMenu.width;
            }
            if (this.mMenu.y > Application.application.stage.stageHeight - this.mMenu.height)
            {
                this.mMenu.y = Application.application.stage.stageHeight - this.mMenu.height;
            }
            return;
        }// end function

        private function Visit(event:MouseEvent) : void
        {
            cBasicPanel.HideCurrentActivePanel();
            globalFlash.gui.mLoadingZonePanel.Show();
            globalFlash.gui.mStarMenu.ResetScrollPosition();
            global.ui.mCurrentPlayerZone.SaveZoneStartZoom();
            var _loc_2:* = gMisc.IntToObject(int(this.mGI.mQuestClientCallbacks.IsBuffOnFriendQuestActive()));
            global.ui.mClientMessages.SendMessagetoServer(COMMAND.GET_ZONE, this.mPlayer.id, _loc_2);
            return;
        }// end function

        public function Init(param1:FriendsListMenu) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mMenu = param1;
            this.mRendererPool = new Vector.<FriendsListMenuItemRenderer>;
            this.mMenu.addEventListener(ResizeEvent.RESIZE, this.ResizeHandler);
            return;
        }// end function

        public function Move(param1:int, param2:int) : void
        {
            this.mMenu.x = param1;
            this.mMenu.y = param2;
            return;
        }// end function

        private function AddMenuItem(param1:String, param2:Boolean, param3:Function) : void
        {
            var _loc_4:FriendsListMenuItemRenderer = null;
            if (this.mRendererPool.length > this.mMenu.numChildren)
            {
                _loc_4 = this.mRendererPool[this.mMenu.numChildren];
                _loc_4.removeAllClickEventListeners();
            }
            else
            {
                _loc_4 = new FriendsListMenuItemRenderer();
                this.mRendererPool.push(_loc_4);
            }
            _loc_4.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, param1);
            _loc_4.enabled = param2;
            _loc_4.addEventListener(MouseEvent.CLICK, param3);
            this.mMenu.addChild(_loc_4);
            this.mMenu.y = this.mMenu.y - (_loc_4.height + 1);
            return;
        }// end function

        public function ShowAddFriendPanel(event:MouseEvent) : void
        {
            globalFlash.gui.mAddFriendsPanel.SetMode(cAddFriendsPanel.ADD_FRIEND);
            globalFlash.gui.mAddFriendsPanel.Show();
            return;
        }// end function

        private function SendSpecialist(event:MouseEvent) : void
        {
            globalFlash.gui.mSpecialistTravelPanel.SetData(this.mPlayer.id);
            globalFlash.gui.mSpecialistTravelPanel.Show();
            return;
        }// end function

        private function Whisper(event:MouseEvent) : void
        {
            globalFlash.gui.mChatPanel.ActivatePrivateChat(this.mPlayer.username);
            return;
        }// end function

        private function ConfirmCancelAdventure(event:MouseEvent) : void
        {
            CustomAlert.show(cLocaManager.GetInstance().GetText(LOCA_GROUP.ALERT_MESSAGES, "ConfirmCancelAdventure", [this.mPlayer.adventureVO.adventureName]), cLocaManager.GetInstance().GetText(LOCA_GROUP.ALERT_TITLES, "ConfirmCancelAdventure"), Alert.OK | Alert.CANCEL, null, this.CancelAdventure, null, 4, false);
            return;
        }// end function

        private function AddFriend(event:MouseEvent) : void
        {
            globalFlash.gui.mFriendsList.AddFriend(this.mPlayer);
            return;
        }// end function

    }
}
