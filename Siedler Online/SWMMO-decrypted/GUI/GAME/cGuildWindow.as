package GUI.GAME
{
    import Communication.VO.*;
    import Communication.VO.Guild.*;
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import GuildSystem.*;
    import Interface.*;
    import flash.events.*;
    import mx.collections.*;
    import mx.controls.*;
    import mx.events.*;

    public class cGuildWindow extends cBasicPanel
    {
        private var mMyRankPosition:int = 0;
        private var mGI:cGameInterface;
        protected var mPanel:GuildWindow;
        private var mIsOwnGuild:Boolean;
        private var mSelectedGuild:dGuildVO;
        private var mOnlyWhiteSpaces:Object;
        private var mMyRank:dGuildRankListItemVO = null;
        private var mPermissions:dGuildPlayerPermissionVO;
        private var mCurrentRankPosition:int = 0;
        private var mSelectedMember:dGuildPlayerListItemVO;
        private var mMaxPage:int;
        private var mSelectedBanner:int;
        private var mCurrentPage:int;

        public function cGuildWindow()
        {
            this.mOnlyWhiteSpaces = /^\s*$""^\s*$/;
            return;
        }// end function

        private function RanksEditKeyUpHandler(event:KeyboardEvent) : void
        {
            this.mPanel.btnSaveRankChanges.enabled = this.RanksChanged() && this.RanksValid();
            this.mPanel.btnDiscardRankChanges.enabled = this.RanksChanged();
            return;
        }// end function

        public function ResetValue(param1:dGuildEditValueVO) : void
        {
            switch(param1.type)
            {
                case EDIT_TYPE.MOTD:
                {
                    this.mPanel.motd.text = param1.newValue;
                    break;
                }
                case EDIT_TYPE.DESCRIPTION:
                {
                    this.mPanel.guildDescription.text = param1.newValue;
                    break;
                }
                case EDIT_TYPE.NOTE:
                {
                    this.mPanel.note.text = param1.newValue;
                    break;
                }
                case EDIT_TYPE.OFFICER_NOTE:
                {
                    this.mPanel.officerNote.text = param1.newValue;
                    break;
                }
                case EDIT_TYPE.BANNER:
                {
                    this.mPanel.banner.source = gAssetManager.GetGuildBannerUrlById(parseInt(param1.newValue));
                    this.mPanel.selectedBanner.source = gAssetManager.GetGuildBannerUrlById(parseInt(param1.newValue));
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

        private function KickHandler(event:MouseEvent) : void
        {
            CustomAlert.show("ConfirmKickMember", "ConfirmKickMember", Alert.OK | Alert.CANCEL, null, this.KickMember);
            return;
        }// end function

        private function ClosePanel(event:MouseEvent) : void
        {
            this.Hide();
            return;
        }// end function

        private function RanksChanged() : Boolean
        {
            return (this.mSelectedGuild.ranks.getItemAt(0) as dGuildRankListItemVO).name != this.mPanel.rankName1.text || (this.mSelectedGuild.ranks.getItemAt(1) as dGuildRankListItemVO).name != this.mPanel.rankName2.text || (this.mSelectedGuild.ranks.getItemAt(2) as dGuildRankListItemVO).name != this.mPanel.rankName3.text || (this.mSelectedGuild.ranks.getItemAt(3) as dGuildRankListItemVO).name != this.mPanel.rankName4.text;
        }// end function

        private function DisbandGuild(event:CloseEvent) : void
        {
            if (event.detail != Alert.OK)
            {
                return;
            }
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.GUILD_LEAVE, this.mGI.mCurrentViewedZoneID, null);
            this.mGI.SetCurrentPlayerGuild(null);
            globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.GUILD_DISBANDED);
            globalFlash.gui.mChatPanel.leaveGuildChannels();
            var _loc_2:* = this.mPanel.guildList.dataProvider as ArrayCollection;
            var _loc_3:int = 0;
            while (_loc_3 < _loc_2.length)
            {
                
                if ((_loc_2.getItemAt(_loc_3) as dGuildVO).id == this.mSelectedGuild.id)
                {
                    _loc_2.removeItemAt(_loc_3);
                    break;
                }
                _loc_3++;
            }
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.PLAYER_ACTION, this.mGI.mCurrentViewedZoneID, "Disband Guild");
            this.Hide();
            return;
        }// end function

        private function ShowGuildDetails(event:ListEvent) : void
        {
            if (!this.mPanel.guildList.selectedItem)
            {
                return;
            }
            var _loc_2:* = this.mPanel.guildList.selectedItem as dGuildVO;
            var _loc_3:* = this.mGI.GetCurrentPlayerGuild();
            if (_loc_3 != null && _loc_2.id == _loc_3.id)
            {
                this.ShowMyGuildDetails(null);
                return;
            }
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.GUILD_GET, this.mGI.mCurrentPlayer.GetPlayerId(), _loc_2.id);
            this.mPanel.subcontent.selectedIndex = 1;
            this.mPanel.guildDetailsStack.selectedIndex = 0;
            this.mPanel.buttonBar.selectedIndex = 0;
            return;
        }// end function

        private function ShowGuildList(event:MouseEvent) : void
        {
            this.ClearGuildDetails();
            this.mPanel.label = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildList");
            this.mPanel.banner.source = null;
            this.mPanel.subcontent.selectedIndex = 0;
            return;
        }// end function

        private function RanksValid() : Boolean
        {
            if (this.mPanel.rankName1.text == "" || this.mPanel.rankName2.text == "" || this.mPanel.rankName3.text == "" || this.mPanel.rankName4.text == "")
            {
                return false;
            }
            if (this.mPanel.rankName1.text.match(this.mOnlyWhiteSpaces) != null || this.mPanel.rankName2.text.match(this.mOnlyWhiteSpaces) != null || this.mPanel.rankName3.text.match(this.mOnlyWhiteSpaces) != null || this.mPanel.rankName4.text.match(this.mOnlyWhiteSpaces) != null)
            {
                return false;
            }
            return true;
        }// end function

        private function ShowMyGuildDetails(event:MouseEvent) : void
        {
            this.SetGuild(this.mGI.GetCurrentPlayerGuild());
            this.mPanel.subcontent.selectedIndex = 1;
            this.mPanel.guildDetailsStack.selectedIndex = 0;
            this.mPanel.buttonBar.selectedIndex = 0;
            return;
        }// end function

        private function DiscardBannerChanges(event:MouseEvent) : void
        {
            this.mSelectedBanner = this.mSelectedGuild.bannerID;
            this.ChangeBanner();
            return;
        }// end function

        private function DiscardRanksChanges(event:MouseEvent) : void
        {
            this.mPanel.btnSaveRankChanges.enabled = false;
            this.mPanel.btnDiscardRankChanges.enabled = false;
            this.SetRanks();
            return;
        }// end function

        private function ClearMemberDetails() : void
        {
            this.mPanel.memberAvatar.data = null;
            this.mPanel.memberAvatar.visible = false;
            this.mPanel.btnRankDown.visible = false;
            this.mPanel.btnRankUp.visible = false;
            this.mPanel.memberName.text = "";
            this.mPanel.memberLevel.text = "";
            this.mPanel.memberRank.text = "";
            this.mPanel.note.text = "";
            this.mPanel.note.editable = false;
            this.mPanel.officerNote.text = "";
            this.mPanel.officerNote.editable = false;
            return;
        }// end function

        override public function Show() : void
        {
            this.GetGuildListPage(1);
            var _loc_1:* = this.mGI.GetCurrentPlayerGuild();
            if (_loc_1)
            {
                this.ShowMyGuildDetails(null);
            }
            else
            {
                this.ShowGuildList(null);
            }
            this.mPanel.btnMyGuild.visible = _loc_1 != null;
            this.mPanel.btnFoundGuild.visible = _loc_1 == null;
            this.mPanel.btnFoundGuild.enabled = this.mGI.mCurrentPlayerZone.mStreetDataMap.GetGuildHouse() != null;
            globalFlash.gui.mDarkenPanel.Show();
            super.Show();
            return;
        }// end function

        private function KickMember(event:CloseEvent) : void
        {
            if (event.detail != Alert.OK)
            {
                return;
            }
            this.mSelectedGuild.members.removeItemAt(this.mSelectedGuild.members.getItemIndex(this.mSelectedMember));
            this.ClearMemberDetails();
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.GUILD_KICK, this.mGI.mCurrentViewedZoneID, this.mSelectedMember.id);
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.PLAYER_ACTION, this.mGI.mCurrentViewedZoneID, "Kick Member");
            this.mSelectedMember = null;
            return;
        }// end function

        public function InviteMember(param1:dPlayerListItemVO) : void
        {
            if (param1.id > 0)
            {
                globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.GUILD_INVITE_SENT);
            }
            global.ui.mClientMessages.SendMessagetoServer(COMMAND.GUILD_INVITE, global.ui.mCurrentViewedZoneID, param1.id);
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.PLAYER_ACTION, this.mGI.mCurrentViewedZoneID, "Invite to Guild");
            return;
        }// end function

        private function SetRanks() : void
        {
            var _loc_2:TextInput = null;
            var _loc_1:int = 0;
            while (_loc_1 < this.mSelectedGuild.ranks.length)
            {
                
                _loc_2 = this.mPanel["rankName" + (_loc_1 + 1)] as TextInput;
                if (_loc_2)
                {
                    _loc_2.text = (this.mSelectedGuild.ranks.getItemAt(_loc_1) as dGuildRankListItemVO).name;
                }
                _loc_1++;
            }
            return;
        }// end function

        private function IsRankUpAllowed(param1:int) : Boolean
        {
            var _loc_2:* = this.GetCurrentRankPosition(param1);
            return _loc_2 > 0 && this.mPermissions && this.mPermissions.RanksAssign() && this.mMyRankPosition < (_loc_2 - 1);
        }// end function

        private function SendChanges(param1:dGuildEditValueVO) : void
        {
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.GUILD_EDIT_VALUE, 0, param1);
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.PLAYER_ACTION, this.mGI.mCurrentViewedZoneID, "Leave Guild");
            return;
        }// end function

        private function Invite(event:MouseEvent) : void
        {
            globalFlash.gui.mAddFriendsPanel.SetMode(cAddFriendsPanel.GUILD_INVITE);
            globalFlash.gui.mAddFriendsPanel.Show();
            return;
        }// end function

        private function GuildMail(event:MouseEvent) : void
        {
            globalFlash.gui.mMailWindow.EditGuildMail(this.mSelectedGuild);
            return;
        }// end function

        public function Init(param1:GuildWindow) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            this.mPanel.label = "Guild list";
            this.mPanel.btnClose.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            this.mPanel.buttonBar.addEventListener(ItemClickEvent.ITEM_CLICK, this.SwitchDetailsViewstack);
            this.mPanel.btnPrevPage.addEventListener(MouseEvent.CLICK, this.PreviousPage);
            this.mPanel.btnNextPage.addEventListener(MouseEvent.CLICK, this.NextPage);
            this.mPanel.btnFoundGuild.addEventListener(MouseEvent.CLICK, this.FoundGuild);
            this.mPanel.btnBackToList.addEventListener(MouseEvent.CLICK, this.ShowGuildList);
            this.mPanel.btnMyGuild.addEventListener(MouseEvent.CLICK, this.ShowMyGuildDetails);
            this.mPanel.membersList.addEventListener(ListEvent.ITEM_CLICK, this.ShowMemberDetails);
            this.mPanel.guildList.addEventListener(ListEvent.ITEM_CLICK, this.ShowGuildDetails);
            this.mPanel.btnInvite.addEventListener(MouseEvent.CLICK, this.Invite);
            this.mPanel.btnMail.addEventListener(MouseEvent.CLICK, this.GuildMail);
            this.mPanel.btnLeave.addEventListener(MouseEvent.CLICK, this.LeaveHandler);
            this.mPanel.btnIncrease.addEventListener(MouseEvent.CLICK, this.IncreaseGuildHandler);
            this.mPanel.btnKick.addEventListener(MouseEvent.CLICK, this.KickHandler);
            this.mPanel.btnSaveRankChanges.addEventListener(MouseEvent.CLICK, this.SaveRanksChanges);
            this.mPanel.btnDiscardRankChanges.addEventListener(MouseEvent.CLICK, this.DiscardRanksChanges);
            this.mPanel.btnRankUp.addEventListener(MouseEvent.CLICK, this.AssignRank);
            this.mPanel.btnRankDown.addEventListener(MouseEvent.CLICK, this.AssignRank);
            this.mPanel.btnBannerLeft.addEventListener(MouseEvent.CLICK, this.ChangeBanner);
            this.mPanel.btnBannerRight.addEventListener(MouseEvent.CLICK, this.ChangeBanner);
            this.mPanel.btnSaveBannerChanges.addEventListener(MouseEvent.CLICK, this.SaveBannerChanges);
            this.mPanel.btnDiscardBannerChanges.addEventListener(MouseEvent.CLICK, this.DiscardBannerChanges);
            this.mPanel.rankName1.addEventListener(KeyboardEvent.KEY_UP, this.RanksEditKeyUpHandler);
            this.mPanel.rankName2.addEventListener(KeyboardEvent.KEY_UP, this.RanksEditKeyUpHandler);
            this.mPanel.rankName3.addEventListener(KeyboardEvent.KEY_UP, this.RanksEditKeyUpHandler);
            this.mPanel.rankName4.addEventListener(KeyboardEvent.KEY_UP, this.RanksEditKeyUpHandler);
            this.mPanel.motd.addEventListener("SaveChanges", this.SaveChanges);
            this.mPanel.guildDescription.addEventListener("SaveChanges", this.SaveChanges);
            this.mPanel.note.addEventListener("SaveChanges", this.SaveChanges);
            this.mPanel.officerNote.addEventListener("SaveChanges", this.SaveChanges);
            return;
        }// end function

        private function FoundGuild(event:MouseEvent) : void
        {
            globalFlash.gui.mFoundGuildPanel.Show();
            return;
        }// end function

        private function ShowMemberDetails(event:ListEvent) : void
        {
            if (!this.mPanel.membersList.selectedItem)
            {
                this.ClearMemberDetails();
                return;
            }
            this.mSelectedMember = this.mPanel.membersList.selectedItem as dGuildPlayerListItemVO;
            this.mPanel.memberAvatar.data = this.mSelectedMember;
            this.mPanel.memberAvatar.visible = true;
            this.mPanel.memberName.text = this.mSelectedMember.username;
            this.mPanel.memberLevel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Level", [this.mSelectedMember.playerLevel == 0 ? ("1") : (this.mSelectedMember.playerLevel.toString())]);
            this.mPanel.memberRank.text = (this.mPanel.rankMappings[this.mSelectedMember.rankID] as dGuildRankListItemVO).name;
            this.mPanel.note.editable = this.mIsOwnGuild && (this.mPermissions.NoteWrite() || this.mSelectedMember.id == this.mGI.mCurrentPlayer.GetPlayerId());
            this.mPanel.officerNote.editable = this.mIsOwnGuild && this.mPermissions.OfficerNoteWrite();
            this.mPanel.btnKick.enabled = this.mIsOwnGuild && this.mPermissions.Kick() && this.GetCurrentRankPosition(this.mSelectedMember.rankID) > this.mMyRankPosition;
            if (!this.mIsOwnGuild)
            {
                return;
            }
            this.mPanel.btnRankUp.visible = this.mPermissions.RanksAssign();
            this.mPanel.btnRankUp.enabled = this.IsRankUpAllowed(this.mSelectedMember.rankID);
            this.mPanel.btnRankDown.visible = this.mPermissions.RanksAssign();
            this.mPanel.btnRankDown.enabled = this.IsRankDownAllowed(this.mSelectedMember.rankID);
            this.mPanel.note.text = this.mSelectedMember.note;
            this.mPanel.officerNote.text = this.mSelectedMember.officerNote;
            return;
        }// end function

        private function LeaveHandler(event:MouseEvent) : void
        {
            if (this.mMyRankPosition == 0)
            {
                CustomAlert.show("ConfirmDisbandGuild", "ConfirmDisbandGuild", Alert.OK | Alert.CANCEL, null, this.DisbandGuild);
            }
            else
            {
                CustomAlert.show("ConfirmLeaveGuild", "ConfirmLeaveGuild", Alert.OK | Alert.CANCEL, null, this.LeaveGuild);
            }
            return;
        }// end function

        private function ClearGuildDetails() : void
        {
            this.mPanel.motd.text = "";
            this.mPanel.guildInfo.text = "";
            this.mPanel.guildDescription.text = "";
            this.mPanel.guildLog.dataProvider = null;
            this.mPanel.membersList.dataProvider = null;
            this.mSelectedGuild = null;
            this.mPanel.guildDetailsStack.selectedIndex = 0;
            this.mPanel.buttonBar.selectedIndex = 0;
            this.ClearMemberDetails();
            return;
        }// end function

        private function IsRankDownAllowed(param1:int) : Boolean
        {
            var _loc_2:* = this.GetCurrentRankPosition(param1);
            return _loc_2 < (this.mSelectedGuild.ranks.length - 1) && this.mPermissions && this.mPermissions.RanksAssign() && _loc_2 > this.mMyRankPosition;
        }// end function

        private function SaveRanksChanges(event:MouseEvent) : void
        {
            var _loc_4:dGuildRankListItemVO = null;
            if (!this.mIsOwnGuild)
            {
                return;
            }
            this.mPanel.btnSaveRankChanges.enabled = false;
            this.mPanel.btnDiscardRankChanges.enabled = false;
            if (!this.RanksChanged())
            {
                return;
            }
            var _loc_2:int = 0;
            while (_loc_2 < this.mSelectedGuild.ranks.length)
            {
                
                _loc_4 = this.mSelectedGuild.ranks.getItemAt(_loc_2) as dGuildRankListItemVO;
                _loc_4.name = this.mPanel["rankName" + (_loc_2 + 1)].text;
                _loc_2++;
            }
            var _loc_3:* = new dGuildEditValueVO();
            _loc_3.type = EDIT_TYPE.RANK_NAME;
            _loc_3.parameters = this.mSelectedGuild.ranks;
            this.SendChanges(_loc_3);
            globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.GUILD_CHANGES_SAVED);
            return;
        }// end function

        private function LeaveGuild(event:CloseEvent) : void
        {
            if (event.detail != Alert.OK)
            {
                return;
            }
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.GUILD_LEAVE, this.mGI.mCurrentViewedZoneID, null);
            this.mGI.SetCurrentPlayerGuild(null);
            globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.GUILD_LEFT);
            globalFlash.gui.mChatPanel.leaveGuildChannels();
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.PLAYER_ACTION, this.mGI.mCurrentViewedZoneID, "Leave Guild");
            this.Hide();
            return;
        }// end function

        private function PreviousPage(event:MouseEvent) : void
        {
            this.GetGuildListPage((this.mCurrentPage - 1));
            return;
        }// end function

        private function NextPage(event:MouseEvent) : void
        {
            this.GetGuildListPage((this.mCurrentPage + 1));
            return;
        }// end function

        private function GetGuildListPage(param1:int) : void
        {
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.GUILD_GET_HEADERS, this.mGI.mCurrentPlayer.GetPlayerId(), param1);
            return;
        }// end function

        public function SetGuild(param1:dGuildVO) : void
        {
            var _loc_4:dGuildRankListItemVO = null;
            var _loc_5:dGuildPlayerListItemVO = null;
            var _loc_6:dGuildLogListItemVO = null;
            var _loc_7:Array = null;
            var _loc_8:dGuildPlayerListItemVO = null;
            var _loc_9:int = 0;
            var _loc_10:String = null;
            this.mSelectedGuild = param1;
            this.mPanel.label = param1.name + " [" + param1.tag + "]";
            var _loc_2:* = this.mGI.GetCurrentPlayerGuild();
            this.mIsOwnGuild = _loc_2 && param1.id == _loc_2.id;
            var _loc_3:Object = {};
            for each (_loc_4 in param1.ranks)
            {
                
                _loc_3[_loc_4.id] = _loc_4;
            }
            this.mPanel.rankMappings = _loc_3;
            if (this.mIsOwnGuild)
            {
                for each (_loc_8 in this.mSelectedGuild.members)
                {
                    
                    if (_loc_8.id == this.mGI.mCurrentPlayer.GetPlayerId())
                    {
                        this.mMyRank = this.mPanel.rankMappings[_loc_8.rankID] as dGuildRankListItemVO;
                        break;
                    }
                }
                _loc_9 = 0;
                while (_loc_9 < this.mSelectedGuild.ranks.length)
                {
                    
                    _loc_4 = this.mSelectedGuild.ranks.getItemAt(_loc_9) as dGuildRankListItemVO;
                    if (_loc_4.id == this.mMyRank.id)
                    {
                        this.mMyRankPosition = _loc_9;
                        break;
                    }
                    _loc_9++;
                }
            }
            else
            {
                this.mMyRank = null;
                this.mMyRankPosition = -1;
            }
            this.mPermissions = param1.playerPermissions;
            this.mPanel.banner.source = gAssetManager.GetGuildBannerUrlById(param1.bannerID);
            this.mSelectedBanner = param1.bannerID;
            this.ChangeBanner();
            this.mPanel.btnInvite.enabled = this.mIsOwnGuild && this.mPermissions && this.mPermissions.Invite();
            this.mPanel.btnMail.enabled = this.mIsOwnGuild && this.mPermissions && this.mPermissions.GuildMail();
            this.mPanel.btnLeave.label = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, this.mMyRankPosition == 0 ? ("GuildDisband") : ("GuildLeave"));
            this.mPanel.btnLeave.enabled = this.mMyRankPosition == 0 ? (this.mSelectedGuild.size == 1) : (this.mIsOwnGuild);
            this.mPanel.btnIncrease.enabled = this.mIsOwnGuild;
            this.mPanel.btnKick.enabled = false;
            this.mPanel.membersList.dataProvider = param1.members;
            this.mPanel.motd.text = param1.motd;
            this.mPanel.motd.editable = this.mPermissions && this.mPermissions.MOTDWrite();
            this.mPanel.guildInfo.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildDetailsFounded", [cLocaManager.GetInstance().FormatDate(param1.foundTime).toString()]);
            this.mPanel.guildInfo.text = this.mPanel.guildInfo.text + ("\n" + cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildDetailsPlayersCount", [param1.size.toString()]));
            if (this.mIsOwnGuild)
            {
                this.mPanel.guildInfo.text = this.mPanel.guildInfo.text + ("\n" + cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildDetailsMaxPlayersCount", [param1.maxSize]));
            }
            for each (_loc_5 in param1.members)
            {
                
                if (_loc_5.rankID == (param1.ranks[0] as dGuildRankListItemVO).id)
                {
                    break;
                }
            }
            this.mPanel.leaderAvatar.data = _loc_5;
            this.mPanel.leaderName.text = _loc_5.username;
            this.mPanel.guildDescription.text = param1.description;
            this.mPanel.guildDescription.editable = this.mPermissions && this.mPermissions.DescriptionWrite();
            this.mPanel.guildLog.dataProvider = new ArrayCollection();
            for each (_loc_6 in param1.log)
            {
                
                _loc_10 = cLocaManager.GetInstance().GetText(LOCA_GROUP.GUILD_LOG_RECORDS, GUILD_LOG_IDENTIFIER.toString(_loc_6.identifier), _loc_6.parameters.toArray());
                this.mPanel.guildLog.dataProvider.addItem(cLocaManager.GetInstance().FormatDate(_loc_6.timestamp).toString() + ": " + _loc_10);
            }
            this.mPanel.btnSaveRankChanges.enabled = false;
            this.mPanel.btnSaveBannerChanges.enabled = false;
            _loc_7 = [cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildPage"), cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildMembers")];
            if (this.IsAdminTabAllowed())
            {
                _loc_7.push(cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildAdministration"));
            }
            this.mPanel.buttonBar.dataProvider = _loc_7;
            if (!this.mIsOwnGuild)
            {
                return;
            }
            this.mPanel.rankName1.editable = this.mPermissions && this.mPermissions.RanksEdit();
            this.mPanel.rankName2.editable = this.mPermissions && this.mPermissions.RanksEdit();
            this.mPanel.rankName3.editable = this.mPermissions && this.mPermissions.RanksEdit();
            this.mPanel.rankName4.editable = this.mPermissions && this.mPermissions.RanksEdit();
            this.SetRanks();
            return;
        }// end function

        private function SwitchDetailsViewstack(event:ItemClickEvent) : void
        {
            this.mPanel.guildDetailsStack.selectedIndex = this.mPanel.buttonBar.selectedIndex;
            return;
        }// end function

        private function IsAdminTabAllowed() : Boolean
        {
            return this.mIsOwnGuild && this.mPermissions && (this.mPermissions.BannerWrite() || this.mPermissions.RanksEdit());
        }// end function

        private function IncreaseGuildHandler(event:MouseEvent) : void
        {
            globalFlash.gui.mShopWindow.ShowDeepLink("GuildWindow", 0, 3);
            return;
        }// end function

        private function SaveBannerChanges(event:MouseEvent) : void
        {
            this.mSelectedGuild.bannerID = this.mSelectedBanner;
            this.mPanel.banner.source = gAssetManager.GetGuildBannerUrlById(this.mSelectedBanner);
            this.ChangeBanner();
            var _loc_2:* = new dGuildEditValueVO();
            _loc_2.type = EDIT_TYPE.BANNER;
            _loc_2.newValue = this.mSelectedBanner.toString();
            this.SendChanges(_loc_2);
            return;
        }// end function

        private function AssignRank(event:MouseEvent) : void
        {
            var _loc_2:dGuildRankListItemVO = null;
            switch(event.target)
            {
                case this.mPanel.btnRankUp:
                {
                    if (this.IsRankUpAllowed(this.mSelectedMember.rankID))
                    {
                        _loc_2 = this.mSelectedGuild.ranks.getItemAt((this.GetCurrentRankPosition(this.mSelectedMember.rankID) - 1)) as dGuildRankListItemVO;
                    }
                    break;
                }
                case this.mPanel.btnRankDown:
                {
                    if (this.IsRankDownAllowed(this.mSelectedMember.rankID))
                    {
                        _loc_2 = this.mSelectedGuild.ranks.getItemAt((this.GetCurrentRankPosition(this.mSelectedMember.rankID) + 1)) as dGuildRankListItemVO;
                    }
                    break;
                }
                default:
                {
                    break;
                }
            }
            if (!_loc_2)
            {
                return;
            }
            this.mSelectedMember.rankID = _loc_2.id;
            this.ShowMemberDetails(null);
            this.mSelectedGuild.members.refresh();
            var _loc_3:* = new dGuildEditValueVO();
            _loc_3.type = EDIT_TYPE.RANK_ASSIGN;
            _loc_3.newValue = _loc_2.id.toString();
            _loc_3.parameters = new ArrayCollection([this.mSelectedMember.id.toString()]);
            this.SendChanges(_loc_3);
            return;
        }// end function

        public function SetHeaders(param1:dGuildHeadersListVO) : void
        {
            this.mCurrentPage = param1.page;
            this.mMaxPage = param1.maxPages;
            this.mPanel.guildList.dataProvider = param1.list;
            this.mPanel.btnPrevPage.enabled = this.mCurrentPage > 1;
            this.mPanel.btnNextPage.enabled = this.mCurrentPage < this.mMaxPage;
            return;
        }// end function

        override public function Hide() : void
        {
            globalFlash.gui.mDarkenPanel.Hide();
            super.Hide();
            return;
        }// end function

        private function SaveChanges(event:Event) : void
        {
            var _loc_2:* = new dGuildEditValueVO();
            ;
            
            _loc_2.type = EDIT_TYPE.MOTD;
            ;
            
            _loc_2.type = EDIT_TYPE.DESCRIPTION;
            ;
            
            _loc_2.type = EDIT_TYPE.NOTE;
            _loc_2.parameters = new ArrayCollection([new String(this.mSelectedMember.id)]);
            ;
            
            _loc_2.type = EDIT_TYPE.OFFICER_NOTE;
            _loc_2.parameters = new ArrayCollection([new String(this.mSelectedMember.id)]);
            ;
            
            return;
        }// end function

        public function RefreshOwnGuild() : void
        {
            var _loc_2:dGuildPlayerListItemVO = null;
            if (!this.mIsOwnGuild)
            {
                return;
            }
            var _loc_1:* = this.mGI.GetCurrentPlayerGuild();
            if (!_loc_1)
            {
                this.Hide();
                return;
            }
            this.SetGuild(_loc_1);
            if (this.mPanel.guildDetailsStack.selectedChild == this.mPanel.administration && !this.IsAdminTabAllowed())
            {
                this.mPanel.guildDetailsStack.selectedIndex = 0;
            }
            else
            {
                this.mPanel.buttonBar.selectedIndex = this.mPanel.guildDetailsStack.selectedIndex;
            }
            if (this.mSelectedMember)
            {
                for each (_loc_2 in this.mSelectedGuild.members)
                {
                    
                    if (_loc_2.id == this.mSelectedMember.id)
                    {
                        break;
                    }
                }
                if (_loc_2)
                {
                    this.mPanel.membersList.selectedItem = _loc_2;
                }
                this.ShowMemberDetails(null);
            }
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
            this.mPanel.btnBannerLeft.enabled = this.mSelectedBanner > 1 && this.mPermissions && this.mPermissions.BannerWrite();
            this.mPanel.btnBannerRight.enabled = this.mSelectedBanner < global.guildBannerCount && this.mPermissions && this.mPermissions.BannerWrite();
            this.mPanel.btnSaveBannerChanges.enabled = this.mSelectedBanner != this.mSelectedGuild.bannerID && this.mPermissions && this.mPermissions.BannerWrite();
            this.mPanel.btnDiscardBannerChanges.enabled = this.mSelectedBanner != this.mSelectedGuild.bannerID;
            return;
        }// end function

        private function GetCurrentRankPosition(param1:int) : int
        {
            var _loc_3:dGuildRankListItemVO = null;
            var _loc_2:int = 0;
            while (_loc_2 < this.mSelectedGuild.ranks.length)
            {
                
                _loc_3 = this.mSelectedGuild.ranks.getItemAt(_loc_2) as dGuildRankListItemVO;
                if (_loc_3.id == param1)
                {
                    return _loc_2;
                }
                _loc_2++;
            }
            return -1;
        }// end function

    }
}
