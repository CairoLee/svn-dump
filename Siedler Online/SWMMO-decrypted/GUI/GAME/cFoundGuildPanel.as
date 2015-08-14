package GUI.GAME
{
    import Communication.VO.Guild.*;
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import Interface.*;
    import flash.events.*;
    import mx.collections.*;
    import mx.controls.*;

    public class cFoundGuildPanel extends cBasicPanel
    {
        private var mNameValid:Boolean = false;
        private var mTagValid:Boolean = false;
        private var mSelectedBanner:int;
        private var mGI:cGameInterface;
        protected var mPanel:FoundGuildPanel;

        public function cFoundGuildPanel()
        {
            return;
        }// end function

        public function ValidateName(param1:String, param2:int) : void
        {
            if (this.mPanel.guildName.text != param1)
            {
                return;
            }
            if (param2 == ERROR_CODES.NO_ERROR)
            {
                this.mPanel.guildName.setStyle("color", 16777215);
                this.mNameValid = true;
            }
            else
            {
                this.mPanel.guildName.setStyle("color", 16711680);
                this.mNameValid = false;
            }
            this.ValidateInputs();
            return;
        }// end function

        private function ValidateInputs(event:KeyboardEvent = null) : void
        {
            this.mPanel.btnFound.enabled = this.mNameValid && this.mTagValid;
            return;
        }// end function

        public function ValidateTag(param1:String, param2:int) : void
        {
            if (this.mPanel.guildTag.text != param1)
            {
                return;
            }
            if (param2 == ERROR_CODES.NO_ERROR)
            {
                this.mPanel.guildTag.setStyle("color", 16777215);
                this.mTagValid = true;
            }
            else
            {
                this.mPanel.guildTag.setStyle("color", 16711680);
                this.mTagValid = false;
            }
            this.ValidateInputs();
            return;
        }// end function

        private function ClosePanel(event:MouseEvent) : void
        {
            this.Hide();
            return;
        }// end function

        private function Clear() : void
        {
            this.mPanel.guildName.text = "";
            this.mPanel.guildTag.text = "";
            this.mNameValid = false;
            this.mTagValid = false;
            this.mSelectedBanner = 1;
            this.ChangeBanner();
            return;
        }// end function

        public function Init(param1:FoundGuildPanel) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            this.mPanel.btnClose.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            this.mPanel.btnFound.addEventListener(MouseEvent.CLICK, this.FoundGuild);
            this.mPanel.guildName.addEventListener(KeyboardEvent.KEY_UP, this.KeyUpHandler);
            this.mPanel.guildTag.addEventListener(KeyboardEvent.KEY_UP, this.KeyUpHandler);
            this.mPanel.btnBannerLeft.addEventListener(MouseEvent.CLICK, this.ChangeBanner);
            this.mPanel.btnBannerRight.addEventListener(MouseEvent.CLICK, this.ChangeBanner);
            return;
        }// end function

        private function FoundGuild(event:MouseEvent) : void
        {
            var _loc_4:dGuildRankListItemVO = null;
            var _loc_2:* = new dGuildVO();
            _loc_2.name = this.mPanel.guildName.text;
            _loc_2.tag = this.mPanel.guildTag.text;
            _loc_2.motd = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildDefaultMOTD");
            _loc_2.bannerID = this.mSelectedBanner;
            _loc_2.ranks = new ArrayCollection();
            var _loc_3:int = 1;
            while (_loc_3 <= 4)
            {
                
                _loc_4 = new dGuildRankListItemVO();
                _loc_4.name = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildDefaultRank" + _loc_3);
                _loc_2.ranks.addItem(_loc_4);
                _loc_3++;
            }
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.GUILD_FOUND, this.mGI.mCurrentPlayer.GetPlayerId(), _loc_2);
            this.Hide();
            return;
        }// end function

        private function ChangeBanner(event:MouseEvent = null) : void
        {
            if (event)
            {
                switch(event.target)
                {
                    case this.mPanel.btnBannerLeft:
                    {
                        if (this.mSelectedBanner > 1)
                        {
                            var _loc_2:String = this;
                            var _loc_3:* = this.mSelectedBanner - 1;
                            _loc_2.mSelectedBanner = _loc_3;
                        }
                        break;
                    }
                    case this.mPanel.btnBannerRight:
                    {
                        if (this.mSelectedBanner < global.guildBannerCount)
                        {
                            var _loc_2:String = this;
                            var _loc_3:* = this.mSelectedBanner + 1;
                            _loc_2.mSelectedBanner = _loc_3;
                        }
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
            this.mPanel.selectedBanner.source = gAssetManager.GetGuildBannerUrlById(this.mSelectedBanner);
            this.mPanel.btnBannerLeft.enabled = this.mSelectedBanner > 1;
            this.mPanel.btnBannerRight.enabled = this.mSelectedBanner < global.guildBannerCount;
            return;
        }// end function

        override public function Show() : void
        {
            this.mPanel.label = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildFound");
            this.Clear();
            super.Show();
            return;
        }// end function

        private function KeyUpHandler(event:KeyboardEvent) : void
        {
            var _loc_2:* = event.currentTarget as TextInput;
            switch(_loc_2)
            {
                case this.mPanel.guildName:
                {
                    if (_loc_2.text.length < 3)
                    {
                        this.mNameValid = false;
                        this.ValidateInputs();
                        return;
                    }
                    this.mGI.mClientMessages.SendMessagetoServer(COMMAND.GUILD_FOUND_VALIDATE_NAME, 0, _loc_2.text);
                    break;
                }
                case this.mPanel.guildTag:
                {
                    if (_loc_2.text.length < 1)
                    {
                        this.mTagValid = false;
                        this.ValidateInputs();
                        return;
                    }
                    this.mGI.mClientMessages.SendMessagetoServer(COMMAND.GUILD_FOUND_VALIDATE_TAG, 0, _loc_2.text);
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

    }
}
