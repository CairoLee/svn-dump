package GUI.GAME
{
    import AdventureSystem.*;
    import BuffSystem.*;
    import Communication.VO.*;
    import Communication.VO.UpdateVO.*;
    import Enums.*;
    import GUI.Components.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Loca.*;
    import Interface.*;
    import flash.events.*;
    import mx.controls.*;
    import mx.events.*;

    public class cAdventurePanel extends cBasicPanel
    {
        private var mCurrentAdventure:dAdventureClientInfoVO;
        private var mGI:cGameInterface;
        protected var mPanel:AdventurePanel;

        public function cAdventurePanel()
        {
            return;
        }// end function

        override public function Hide() : void
        {
            globalFlash.gui.mDarkenPanel.Hide();
            super.Hide();
            return;
        }// end function

        private function InviteFriend(event:MouseEvent) : void
        {
            globalFlash.gui.mAddFriendsPanel.SetMode(cAddFriendsPanel.ADVENTURE_INVITE);
            globalFlash.gui.mAddFriendsPanel.Show();
            return;
        }// end function

        public function AddInvitedPlayer(param1:dPlayerListItemVO) : void
        {
            var _loc_2:* = new dAdventurePlayerListItemVO().InitFromPlayerListItemVO(param1);
            this.mCurrentAdventure.players.addItem(_loc_2);
            this.SetData(this.mCurrentAdventure);
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.INVITE_TO_ADVENTURE, this.mCurrentAdventure.zoneID, param1.id);
            return;
        }// end function

        public function SetData(param1:dAdventureClientInfoVO) : void
        {
            var _loc_3:cAdventureDefinition = null;
            var _loc_4:Number = NaN;
            var _loc_5:Number = NaN;
            this.mCurrentAdventure = param1;
            var _loc_2:* = cLocaManager.GetInstance();
            _loc_3 = cAdventureDefinition.FindAdventureDefinition(this.mCurrentAdventure.adventureName);
            this.mPanel.label = _loc_2.GetText(LOCA_GROUP.ADVENTURE_NAME, this.mCurrentAdventure.adventureName);
            this.mPanel.todo.text = _loc_2.GetText(LOCA_GROUP.ADVENTURE_TODO, this.mCurrentAdventure.adventureName);
            this.mPanel.playerCount1.text = _loc_2.GetText(LOCA_GROUP.LABELS, "PlayersAllowed", [_loc_3.mMaxPlayers.toString()]);
            this.mPanel.teaserImage.source = _loc_3.GetTeaserImage();
            this.mPanel.difficultyIndicator.difficulty = _loc_3.mDifficulty;
            if (this.mCurrentAdventure.status == cAdventure.STATUS_STARTED)
            {
                this.mPanel.opener.text = _loc_2.GetText(LOCA_GROUP.ADVENTURE_OPENER, this.mCurrentAdventure.adventureName);
                this.mPanel.height = 612;
                this.mPanel.buttonsInitialized.visible = false;
                this.mPanel.buttonsFinished.visible = false;
                this.mPanel.buttonsActive.visible = true;
                this.mPanel.playerCount2.text = _loc_2.GetText(LOCA_GROUP.LABELS, "ActivePlayers", [this.mCurrentAdventure.players.length.toString()]);
                this.mPanel.missionHeader.visible = true;
                this.mPanel.missionPanel.visible = true;
                this.mPanel.playerListHeader.visible = true;
                this.mPanel.playerListPanel.visible = true;
                this.mPanel.playerListHeader.setConstraintValue("top", 347);
                this.mPanel.playerListPanel.setConstraintValue("top", 365);
                this.mPanel.playerCountPanel.setConstraintValue("top", 440);
                this.mPanel.durationBar.visible = true;
                _loc_4 = this.mCurrentAdventure.collectedTime / this.mCurrentAdventure.totalDuration;
                _loc_5 = this.mCurrentAdventure.totalDuration - this.mCurrentAdventure.collectedTime;
                this.mPanel.durationBar.value = _loc_4;
                this.mPanel.durationBar.toolTip = cLocaManager.GetInstance().FormatDuration(_loc_5 > 0 ? (_loc_5) : (0), cLocaManager.DURATION_FORMAT_NORMAL);
                this.createPlayerList(_loc_3);
            }
            else if (this.mCurrentAdventure.status == cAdventure.STATUS_FINISHED_LOST || this.mCurrentAdventure.status == cAdventure.STATUS_FINISHED_WON)
            {
                if (this.mCurrentAdventure.status == cAdventure.STATUS_FINISHED_LOST)
                {
                    this.mPanel.opener.text = _loc_2.GetText(LOCA_GROUP.ADVENTURE_LOST, this.mCurrentAdventure.adventureName);
                }
                else
                {
                    this.mPanel.opener.text = _loc_2.GetText(LOCA_GROUP.ADVENTURE_WON, this.mCurrentAdventure.adventureName);
                }
                this.mPanel.height = 488;
                this.mPanel.durationBar.visible = false;
                this.mPanel.buttonsFinished.visible = true;
                this.mPanel.buttonsInitialized.visible = false;
                this.mPanel.buttonsActive.visible = false;
                this.mPanel.playerCount2.text = _loc_2.GetText(LOCA_GROUP.LABELS, "ActivePlayers", [this.mCurrentAdventure.players.length.toString()]);
                this.mPanel.missionHeader.visible = false;
                this.mPanel.missionPanel.visible = false;
                this.mPanel.playerListHeader.visible = true;
                this.mPanel.playerListPanel.visible = true;
                this.mPanel.playerListHeader.setConstraintValue("top", 237);
                this.mPanel.playerListPanel.setConstraintValue("top", 255);
                this.mPanel.playerCountPanel.setConstraintValue("top", 330);
                this.createPlayerList(_loc_3);
            }
            else
            {
                this.mPanel.missionHeader.visible = true;
                this.mPanel.missionPanel.visible = true;
                this.mPanel.playerListHeader.visible = false;
                this.mPanel.playerListPanel.visible = false;
                this.mPanel.playerCountPanel.setConstraintValue("top", 345);
                this.mPanel.opener.text = _loc_2.GetText(LOCA_GROUP.ADVENTURE_OPENER, this.mCurrentAdventure.adventureName);
                this.mPanel.height = 503;
                this.mPanel.durationBar.visible = false;
                this.mPanel.buttonsFinished.visible = false;
                this.mPanel.buttonsInitialized.visible = true;
                this.mPanel.buttonsActive.visible = false;
                this.mPanel.playerCount2.text = _loc_2.GetText(LOCA_GROUP.LABELS, "AvailableTime", [_loc_2.FormatDuration(_loc_3.mDuration)]);
                if (globalFlash.gui.mFriendsList.GetStartedAdventuresCount() >= global.adventureMaximumOwner)
                {
                    this.mPanel.btnStart.enabled = false;
                    this.mPanel.btnStart.toolTip = _loc_2.GetText(LOCA_GROUP.LABELS, "AdventuresStartedLimitReached");
                }
                else if (this.mGI.mCurrentPlayer.GetPlayerLevel() < _loc_3.mPlayerLevel)
                {
                    this.mPanel.btnStart.enabled = false;
                    this.mPanel.btnStart.toolTip = _loc_2.GetText(LOCA_GROUP.LABELS, "LevelRequired", [_loc_3.mPlayerLevel]);
                }
                else
                {
                    this.mPanel.btnStart.enabled = true;
                    this.mPanel.btnStart.toolTip = "";
                }
            }
            return;
        }// end function

        public function SetName(param1:String) : void
        {
            var _loc_2:* = new dAdventureClientInfoVO();
            _loc_2.adventureName = param1;
            _loc_2.status = cAdventure.STATUS_INITIALIZED;
            this.SetData(_loc_2);
            return;
        }// end function

        public function Init(param1:AdventurePanel) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            this.mPanel.btnClose.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            this.mPanel.btnCancel.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            this.mPanel.btnOK.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            this.mPanel.btnStart.addEventListener(MouseEvent.CLICK, this.StartAdventureHandler);
            this.mPanel.btnReturnHome.addEventListener(MouseEvent.CLICK, this.ReturnHome);
            return;
        }// end function

        private function ClosePanel(event:MouseEvent) : void
        {
            this.Hide();
            return;
        }// end function

        private function StartAdventure(event:CloseEvent) : void
        {
            if (event.detail != Alert.OK)
            {
                return;
            }
            var _loc_2:* = this.mGI.mCurrentCursor.mCurrentBuff;
            this.mGI.SendServerAction(COMMAND.APPLY_BUFF, 0, this.mGI.mCurrentPlayerZone.mStreetDataMap.GetMayorHouse().GetBuildingGrid(), 0, _loc_2.GetUniqueId());
            _loc_2.IncWaitingForServerCount();
            this.mGI.mCurrentCursor.mCurrentBuff = null;
            this.mGI.mCurrentCursor.SetCursorEditMode(COMMAND.SELECT_BUILDING);
            globalFlash.gui.mFriendsList.IncreaseStartedAdventuresCount();
            this.Hide();
            return;
        }// end function

        private function ReturnHome(event:MouseEvent) : void
        {
            this.Hide();
            global.ui.mCurrentPlayerZone.SaveZoneStartZoom();
            globalFlash.gui.mFriendsList.RemoveFriendById(global.ui.mHomePlayer.GetPlayerId());
            global.ui.mClientMessages.SendMessagetoServer(COMMAND.GET_ZONE, global.ui.mCurrentPlayer.GetPlayerId(), false);
            return;
        }// end function

        private function createPlayerList(param1:cAdventureDefinition) : void
        {
            var _loc_2:dAdventurePlayerListItemVO = null;
            var _loc_3:int = 0;
            var _loc_4:AvatarListItemRenderer = null;
            this.mPanel.playerList.removeAllChildren();
            for each (_loc_2 in this.mCurrentAdventure.players)
            {
                
                _loc_4 = new AvatarListItemRenderer();
                _loc_4.data = _loc_2;
                _loc_4.active = _loc_2.status != ADVENTURE_INVITATION_STATUS.PENDING;
                this.mPanel.playerList.addChild(_loc_4);
            }
            _loc_3 = 0;
            while (_loc_3 < param1.mMaxPlayers - this.mCurrentAdventure.players.length)
            {
                
                _loc_4 = new AvatarListItemRenderer();
                if (this.mCurrentAdventure.ownerPlayerID == this.mGI.mCurrentPlayer.GetPlayerId())
                {
                    _loc_4.addEventListener(MouseEvent.CLICK, this.InviteFriend);
                    _loc_4.addMode = this.mCurrentAdventure.status == cAdventure.STATUS_STARTED;
                }
                this.mPanel.playerList.addChild(_loc_4);
                _loc_3++;
            }
            return;
        }// end function

        private function StartAdventureHandler(event:MouseEvent) : void
        {
            var _loc_2:* = CustomAlert.show("ConfirmStartAdventure", "ConfirmStartAdventure", Alert.CANCEL | Alert.OK, this.mPanel, this.StartAdventure);
            _loc_2.addEventListener(CloseEvent.CLOSE, this.StartAdventure);
            return;
        }// end function

        override public function Show() : void
        {
            globalFlash.gui.mDarkenPanel.Show();
            super.Show();
            return;
        }// end function

    }
}
