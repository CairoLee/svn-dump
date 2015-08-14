package GUI.GAME
{
    import Communication.VO.*;
    import Enums.*;
    import GUI.*;
    import GUI.Assets.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import Interface.*;
    import ServerState.*;
    import __AS3__.vec.*;
    import flash.events.*;

    public class cAvatar extends cGuiBaseElement
    {
        private var mPreviousLevel:int = 0;
        protected var mAvatar:Avatar;
        private var mProgressBarWidth:int;
        private var mGI:cGameInterface;
        private var mDisplayedPlayer:dPlayerListItemVO;
        private var mPreviousXP:int = 0;

        public function cAvatar()
        {
            return;
        }// end function

        private function ShowLevelUpAnim() : void
        {
            this.mAvatar.animLevelUp.visible = true;
            return;
        }// end function

        public function HideMailNotification() : void
        {
            this.mAvatar.btnNewMail.visible = false;
            return;
        }// end function

        public function GetDisplayedPlayerVO() : dPlayerListItemVO
        {
            return this.mDisplayedPlayer;
        }// end function

        private function ShowXPAnim() : void
        {
            this.mAvatar.animXP.visible = true;
            return;
        }// end function

        public function Init(param1:Avatar) : void
        {
            var _avatar:* = param1;
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(_avatar);
            this.mAvatar = _avatar;
            this.mProgressBarWidth = this.mAvatar.progressBar.width;
            this.mAvatar.btnNewMail.addEventListener(MouseEvent.CLICK, function () : void
            {
                globalFlash.gui.mMailWindow.Show();
                return;
            }// end function
            );
            this.mAvatar.btnQuestBook.addEventListener(MouseEvent.CLICK, function () : void
            {
                globalFlash.gui.mQuestBook.Show();
                return;
            }// end function
            );
            return;
        }// end function

        public function SetData(param1:cPlayerData, param2) : void
        {
            var _loc_5:Array = null;
            var _loc_6:cPlayerData = null;
            if ((!this.mDisplayedPlayer || this.mDisplayedPlayer && this.mDisplayedPlayer.username != param1.GetPlayerListItem().username) && globalFlash.gui.mChatPanel != null)
            {
                globalFlash.gui.mChatPanel.setPlayerName(param1.GetPlayerListItem().username);
            }
            this.mDisplayedPlayer = param1.GetPlayerListItem();
            this.mDisplayedPlayer.onlineStatus = true;
            var _loc_3:* = this.mGI.mCurrentPlayerZone.GetPlayerColorIdx(param1.GetPlayerId()) + 1;
            this.mAvatar.playerName.text = !param1.GetPlayerName_string() || param1.GetPlayerName_string().length == 0 ? ("[Playername]") : (param1.GetPlayerName_string());
            var _loc_4:* = Math.round(this.GetProgressPercentage(param1.GetXP(), param1.GetPlayerLevel()) * this.mProgressBarWidth);
            this.mAvatar.progressBar.width = _loc_4 > this.mProgressBarWidth ? (this.mProgressBarWidth) : (_loc_4);
            this.mAvatar.level.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Level", [param1.GetPlayerLevel().toString()]);
            this.mAvatar.avatarBackground.source = gAssetManager.GetBitmap("AvatarBackground0" + _loc_3);
            this.mAvatar.avatarImage.source = gAssetManager.GetAvatarUrl(param1.GetAvatarId());
            if (param1.GetXP() >= param1.GetMaxXP())
            {
                this.mAvatar.xpTooltipMask.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "XPLimitReached", [param1.GetXP().toString()]);
            }
            else
            {
                this.mAvatar.xpTooltipMask.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "XPNeeded", [param1.GetXP().toString(), param1.GetMissingXPForNextLevel().toString()]);
            }
            if (this.mPreviousXP < param1.GetXP())
            {
                this.ShowXPAnim();
            }
            if (this.mPreviousLevel < param1.GetPlayerLevel())
            {
                this.ShowLevelUpAnim();
                globalFlash.gui.mFriendsList.Refresh();
            }
            this.mPreviousXP = param1.GetXP();
            this.mPreviousLevel = param1.GetPlayerLevel();
            this.mAvatar.tutorial.visible = param1.GetPlayerLevel() < 16;
            if (param2.length > 1)
            {
                _loc_5 = [];
                for each (_loc_6 in param2)
                {
                    
                    if (param1.GetPlayerId() != _loc_6.GetPlayerId())
                    {
                        _loc_5.push(_loc_6);
                    }
                }
                this.mAvatar.otherPlayers.visible = true;
                this.mAvatar.otherPlayers.dataProvider = _loc_5;
            }
            else
            {
                this.mAvatar.otherPlayers.visible = false;
            }
            return;
        }// end function

        private function GetProgressPercentage(param1:int, param2:int) : Number
        {
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_3:* = global.playerLevels_vector;
            if (param2 > 0)
            {
                _loc_4 = global.playerLevels_vector[param2] - global.playerLevels_vector[(param2 - 1)];
                _loc_5 = param1 - global.playerLevels_vector[(param2 - 1)];
            }
            else
            {
                _loc_4 = global.playerLevels_vector[param2];
                _loc_5 = param1;
            }
            return _loc_5 == _loc_4 ? (0) : (_loc_5 / _loc_4);
        }// end function

        public function ShowMailNotification() : void
        {
            this.mAvatar.btnNewMail.visible = true;
            return;
        }// end function

    }
}
