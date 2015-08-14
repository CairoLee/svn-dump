package GUI.GAME
{
    import Communication.VO.*;
    import Enums.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import Interface.*;
    import flash.events.*;
    import mx.events.*;

    public class cAddFriendsPanel extends cBasicPanel
    {
        protected var mPanel:AddFriendsPanel;
        private var mGI:cGameInterface;
        private var mMode:int;
        private var mCachedClientPlayers:Array;
        public static const GUILD_INVITE:int = 1;
        public static const ADD_FRIEND:int = 0;
        public static const ADVENTURE_INVITE:int = 2;

        public function cAddFriendsPanel()
        {
            return;
        }// end function

        private function AddFriend(event:MouseEvent) : void
        {
            var _loc_2:* = this.mPanel.usersList.selectedItem as dPlayerListItemVO;
            if (_loc_2)
            {
                switch(this.mMode)
                {
                    case ADD_FRIEND:
                    {
                        globalFlash.gui.mFriendsList.AddFriend(_loc_2);
                        this.Hide();
                        break;
                    }
                    case GUILD_INVITE:
                    {
                        globalFlash.gui.mGuildWindow.InviteMember(_loc_2);
                        globalFlash.gui.mGuildWindow.Show();
                        break;
                    }
                    case ADVENTURE_INVITE:
                    {
                        globalFlash.gui.mAdventurePanel.AddInvitedPlayer(_loc_2);
                        globalFlash.gui.mAdventurePanel.Show();
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
            return;
        }// end function

        public function SetMode(param1:int) : void
        {
            this.mMode = param1;
            return;
        }// end function

        private function SelectUser(event:ListEvent) : void
        {
            var _loc_2:* = this.mPanel.usersList.selectedItem as dPlayerListItemVO;
            if (_loc_2)
            {
                this.mPanel.avatarPreview.data = _loc_2;
                this.mPanel.namePreview.text = _loc_2.username;
            }
            return;
        }// end function

        private function KeyUpHandler(event:KeyboardEvent) : void
        {
            if (this.mMode == ADVENTURE_INVITE)
            {
                this.SetData(globalFlash.gui.mFriendsList.GetFilteredFriends(this.mPanel.searchInput.text, true));
            }
            else if (this.mPanel.searchInput.text.length >= 3)
            {
                this.mGI.mClientMessages.SendMessagetoServer(COMMAND.SEARCH_PLAYER_LIST, 0, this.mPanel.searchInput.text);
            }
            return;
        }// end function

        public function SetData(param1:Array) : void
        {
            var _loc_3:dPlayerListItemVO = null;
            if (this.mMode == ADVENTURE_INVITE)
            {
                this.mPanel.usersList.dataProvider = param1;
                return;
            }
            var _loc_2:Array = [];
            for each (_loc_3 in param1)
            {
                
                if (_loc_3.id == this.mGI.mCurrentPlayer.GetPlayerId())
                {
                    continue;
                }
                switch(this.mMode)
                {
                    case ADD_FRIEND:
                    {
                        if (!globalFlash.gui.mFriendsList.IsFriend(_loc_3))
                        {
                            _loc_2.push(_loc_3);
                        }
                        break;
                    }
                    case GUILD_INVITE:
                    {
                        if (!globalFlash.gui.mFriendsList.IsGuildMember(_loc_3))
                        {
                            _loc_2.push(_loc_3);
                        }
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
            this.mPanel.usersList.dataProvider = _loc_2;
            return;
        }// end function

        private function Clear() : void
        {
            this.mPanel.searchInput.text = "";
            this.mPanel.usersList.dataProvider = null;
            this.mPanel.namePreview.text = "";
            return;
        }// end function

        private function ClosePanel(event:MouseEvent) : void
        {
            if (this.mMode == ADVENTURE_INVITE)
            {
                globalFlash.gui.mAdventurePanel.Show();
            }
            else
            {
                this.Hide();
            }
            return;
        }// end function

        override public function Show() : void
        {
            this.Clear();
            switch(this.mMode)
            {
                case ADD_FRIEND:
                {
                    this.mPanel.label = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "AddFriends");
                    this.mPanel.enterNameLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "EnterFriendsName");
                    this.mPanel.height = 235;
                    break;
                }
                case GUILD_INVITE:
                {
                    this.mPanel.label = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildInvitePlayer");
                    this.mPanel.enterNameLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "EnterFriendsName");
                    this.mPanel.height = 235;
                    break;
                }
                case ADVENTURE_INVITE:
                {
                    this.mPanel.label = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "AdventureInvitePlayer");
                    this.mPanel.enterNameLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "EnterFriendsNameAdventure");
                    this.mPanel.height = 250;
                    this.KeyUpHandler(null);
                    break;
                }
                default:
                {
                    break;
                }
            }
            super.Show();
            return;
        }// end function

        public function Init(param1:AddFriendsPanel) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            this.mPanel.btnClose.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            this.mPanel.btnCancel.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            this.mPanel.btnOK.addEventListener(MouseEvent.CLICK, this.AddFriend);
            this.mPanel.usersList.addEventListener(ListEvent.ITEM_CLICK, this.SelectUser);
            this.mPanel.searchInput.addEventListener(KeyboardEvent.KEY_UP, this.KeyUpHandler);
            return;
        }// end function

    }
}
