package GUI.GAME
{
    import Communication.VO.*;
    import Communication.VO.Guild.*;
    import Communication.VO.UpdateVO.*;
    import Enums.*;
    import GUI.*;
    import GUI.Components.*;
    import Interface.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.containers.*;
    import mx.events.*;
    import mx.utils.*;

    public class cFriendsList extends cGuiBaseElement
    {
        private var mOnlineStatusFriendQueue:Object;
        private var mTempAdventureJoinedCounter:int = 0;
        private var mGI:cGameInterface;
        private var mPreviousFilter:int = 0;
        protected var mFriendsList:FriendsList;
        private var mList:Array;
        private var mOnlineStatusGuildQueue:Object;
        private var mGuildRanksPositionMapping:Object;
        private var mFilter:int = 0;
        private var mTempAdventureStartedCounter:int = 0;
        private var mIsLoaded:Boolean = false;
        private var mAdventureTickTimer:Timer;
        private var mFriendListPlayer:dPlayerListItemVO;
        private static const ZONE_TICK_TIMER_DURATION:int = 10000;

        public function cFriendsList()
        {
            return;
        }// end function

        public function SetOnlineStatus(param1:String, param2:Boolean, param3:Boolean = false) : void
        {
            var _loc_4:dPlayerListItemVO = null;
            var _loc_5:dGuildPlayerListItemVO = null;
            if (!param3)
            {
                _loc_4 = this.GetFriendByName_string(param1);
                if (_loc_4)
                {
                    _loc_4.onlineStatus = param2;
                }
                else
                {
                    this.mOnlineStatusFriendQueue[param1] = param2;
                }
            }
            else
            {
                _loc_5 = this.GetGuildMemberByName_string(param1);
                if (_loc_5)
                {
                    _loc_5.onlineStatus = param2;
                }
                else
                {
                    this.mOnlineStatusGuildQueue[param1] = param2;
                }
            }
            return;
        }// end function

        private function SortGuildMembers(param1:dGuildPlayerListItemVO, param2:dGuildPlayerListItemVO) : Number
        {
            if (this.mGuildRanksPositionMapping[param1.rankID] > this.mGuildRanksPositionMapping[param2.rankID])
            {
                return 1;
            }
            if (this.mGuildRanksPositionMapping[param1.rankID] < this.mGuildRanksPositionMapping[param2.rankID])
            {
                return -1;
            }
            if (param1.playerLevel < param2.playerLevel)
            {
                return 1;
            }
            if (param1.playerLevel > param2.playerLevel)
            {
                return -1;
            }
            return ObjectUtil.compare(param1.username, param2.username);
        }// end function

        public function SetData(param1:Array) : void
        {
            var _loc_6:dPlayerListItemVO = null;
            var _loc_7:String = null;
            var _loc_12:dGuildPlayerListItemVO = null;
            var _loc_13:dGuildRankListItemVO = null;
            var _loc_14:int = 0;
            if (param1 == null)
            {
                param1 = [];
            }
            else
            {
                this.mIsLoaded = true;
            }
            this.mList = param1;
            var _loc_2:Array = [];
            var _loc_3:Array = [];
            var _loc_4:Array = [];
            var _loc_5:Array = [];
            for each (_loc_6 in param1)
            {
                
                if (this.mOnlineStatusFriendQueue[_loc_6.username.toLowerCase()] != null)
                {
                    _loc_6.onlineStatus = this.mOnlineStatusFriendQueue[_loc_6.username.toLowerCase()];
                    this.mOnlineStatusFriendQueue[_loc_6.username.toLowerCase()] = null;
                    delete this.mOnlineStatusFriendQueue[_loc_6.username.toLowerCase()];
                }
                if (_loc_6.id > -1)
                {
                    _loc_3.push(_loc_6);
                    continue;
                }
                if (_loc_6.id < -1)
                {
                    _loc_4.push(_loc_6);
                }
            }
            for each (_loc_7 in this.mOnlineStatusFriendQueue)
            {
                
                if (this.mOnlineStatusFriendQueue[_loc_7] == false)
                {
                    this.mOnlineStatusFriendQueue[_loc_7] = null;
                    delete this.mOnlineStatusFriendQueue[_loc_7];
                }
            }
            if (this.mFriendListPlayer)
            {
                _loc_3.push(this.mFriendListPlayer);
            }
            var _loc_8:* = this.mGI.GetCurrentPlayerGuild();
            this.mGuildRanksPositionMapping = {};
            if (_loc_8)
            {
                _loc_5 = _loc_8.members.toArray();
                for each (_loc_12 in _loc_5)
                {
                    
                    if (this.mOnlineStatusGuildQueue[_loc_12.username.toLowerCase()] != null)
                    {
                        _loc_12.onlineStatus = this.mOnlineStatusGuildQueue[_loc_12.username.toLowerCase()];
                        this.mOnlineStatusGuildQueue[_loc_12.username.toLowerCase()] = null;
                        delete this.mOnlineStatusGuildQueue[_loc_12.username.toLowerCase()];
                    }
                }
                for each (_loc_7 in this.mOnlineStatusGuildQueue)
                {
                    
                    if (this.mOnlineStatusGuildQueue[_loc_7] == false)
                    {
                        this.mOnlineStatusGuildQueue[_loc_7] = null;
                        delete this.mOnlineStatusGuildQueue[_loc_7];
                    }
                }
                for each (_loc_13 in _loc_8.ranks)
                {
                    
                    this.mGuildRanksPositionMapping[_loc_13.id] = _loc_8.ranks.getItemIndex(_loc_13);
                }
            }
            switch(this.mFilter)
            {
                case FriendsListFilterSelector.ALL:
                {
                    if (_loc_8)
                    {
                        _loc_14 = 0;
                        while (_loc_14 < _loc_3.length)
                        {
                            
                            if (this.IsGuildMember(_loc_3[_loc_14]))
                            {
                                _loc_3.splice(_loc_14, 1);
                                _loc_14 = _loc_14 - 1;
                            }
                            _loc_14++;
                        }
                    }
                    _loc_3 = _loc_3.concat(_loc_5);
                    _loc_3.sort(this.SortFriends);
                    _loc_2 = _loc_2.concat(_loc_3);
                    break;
                }
                case FriendsListFilterSelector.FRIENDS:
                {
                    _loc_2 = _loc_2.concat(_loc_3);
                    _loc_2.sort(this.SortFriends);
                    break;
                }
                case FriendsListFilterSelector.ZONES:
                {
                    _loc_2 = _loc_2.concat(_loc_4);
                    _loc_2.sort(this.SortAdventuresDesc);
                    break;
                }
                case FriendsListFilterSelector.GUILD:
                {
                    _loc_2 = _loc_2.concat(_loc_5);
                    _loc_2.sort(this.SortGuildMembers);
                    break;
                }
                default:
                {
                    break;
                }
            }
            var _loc_9:* = this.mFriendsList.list.width / (this.mFriendsList.list.itemRenderer.newInstance() as Canvas).width;
            var _loc_10:* = this.mFriendsList.list.width / (this.mFriendsList.list.itemRenderer.newInstance() as Canvas).width - _loc_2.length;
            _loc_14 = 0;
            while (_loc_14 < _loc_10)
            {
                
                _loc_2.push(null);
                _loc_14++;
            }
            var _loc_11:* = this.mFriendsList.list.horizontalScrollPosition;
            this.mFriendsList.list.dataProvider = _loc_2;
            if (this.mFilter == this.mPreviousFilter)
            {
                this.mFriendsList.list.horizontalScrollPosition = _loc_11;
            }
            this.mPreviousFilter = this.mFilter;
            this.mFriendsList.optionButtons.btnReturnHome.enabled = this.mGI.mCurrentPlayer.GetHomeZoneId() != this.mGI.mCurrentViewedZoneID;
            globalFlash.gui.mTrackedMissionList.Refresh();
            return;
        }// end function

        public function GetStartedAdventuresCount() : int
        {
            var _loc_2:dPlayerListItemVO = null;
            var _loc_1:* = this.mTempAdventureStartedCounter;
            for each (_loc_2 in this.mList)
            {
                
                if (_loc_2.adventureVO && _loc_2.adventureVO.ownerPlayerID == global.ui.mCurrentPlayer.GetPlayerId())
                {
                    _loc_1++;
                }
            }
            return _loc_1;
        }// end function

        public function IsFriend(param1:dPlayerListItemVO) : Boolean
        {
            var _loc_2:dPlayerListItemVO = null;
            if (param1.id == this.mGI.mCurrentPlayer.GetPlayerId())
            {
                return true;
            }
            for each (_loc_2 in this.mList)
            {
                
                if (_loc_2.username == param1.username)
                {
                    return true;
                }
            }
            return false;
        }// end function

        public function IncreaseJoinedAdventuresCount() : void
        {
            var _loc_1:String = this;
            var _loc_2:* = this.mTempAdventureJoinedCounter + 1;
            _loc_1.mTempAdventureJoinedCounter = _loc_2;
            return;
        }// end function

        public function AddConfirmedFriend(param1:dPlayerListItemVO) : void
        {
            if (this.IsFriend(param1))
            {
                return;
            }
            if (param1.id <= -100)
            {
                globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.ADVENTURE_STARTED, param1.adventureVO);
                if (param1.adventureVO.ownerPlayerID == this.mGI.mCurrentPlayer.GetPlayerId())
                {
                    var _loc_2:String = this;
                    var _loc_3:* = this.mTempAdventureStartedCounter - 1;
                    _loc_2.mTempAdventureStartedCounter = _loc_3;
                }
                else
                {
                    var _loc_2:String = this;
                    var _loc_3:* = this.mTempAdventureJoinedCounter - 1;
                    _loc_2.mTempAdventureJoinedCounter = _loc_3;
                }
            }
            this.mList.push(param1);
            this.SetData(this.mList);
            if (param1.id <= -100)
            {
                param1.adventureVO.isTrackedMission = true;
                globalFlash.gui.mQuestBook.SendTrackedMissionList(true);
            }
            return;
        }// end function

        public function GetCurrentAdventureVOIdAndName(param1:int, param2:String) : dAdventureClientInfoVO
        {
            var _loc_3:dPlayerListItemVO = null;
            for each (_loc_3 in this.mList)
            {
                
                if (_loc_3.adventureVO)
                {
                    if (param1 == _loc_3.id && _loc_3.adventureVO.adventureName == param2)
                    {
                        return _loc_3.adventureVO;
                    }
                }
            }
            return null;
        }// end function

        public function IncreaseStartedAdventuresCount() : void
        {
            var _loc_1:String = this;
            var _loc_2:* = this.mTempAdventureStartedCounter + 1;
            _loc_1.mTempAdventureStartedCounter = _loc_2;
            return;
        }// end function

        private function TickAdventureZones(event:TimerEvent) : void
        {
            var _loc_2:dPlayerListItemVO = null;
            var _loc_3:Number = NaN;
            for each (_loc_2 in this.mList)
            {
                
                if (_loc_2.adventureVO)
                {
                    _loc_2.adventureVO.collectedTime = _loc_2.adventureVO.collectedTime + ZONE_TICK_TIMER_DURATION;
                    _loc_3 = _loc_2.adventureVO.totalDuration - _loc_2.adventureVO.collectedTime;
                    if (_loc_3 <= 0)
                    {
                        global.ui.mClientMessages.SendMessagetoServer(COMMAND.PING_ZONE, _loc_2.adventureVO.zoneID, null);
                        this.RemoveFriendById(_loc_2.adventureVO.zoneID);
                    }
                }
            }
            if (this.mFriendsList.list.dataProvider)
            {
                this.mFriendsList.list.dataProvider.refresh();
            }
            globalFlash.gui.mTrackedMissionList.Refresh();
            return;
        }// end function

        public function Init(param1:FriendsList) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mFriendsList = param1;
            this.mFriendsList.filterSelector.buttonBar.addEventListener(ItemClickEvent.ITEM_CLICK, this.FilterList);
            this.mAdventureTickTimer = new Timer(ZONE_TICK_TIMER_DURATION);
            this.mAdventureTickTimer.addEventListener(TimerEvent.TIMER, this.TickAdventureZones);
            this.mAdventureTickTimer.start();
            this.mFriendsList.optionButtons.btnAddFriend.addEventListener(MouseEvent.CLICK, globalFlash.gui.mFriendsListMenu.ShowAddFriendPanel);
            this.mFriendsList.optionButtons.btnInvite.addEventListener(MouseEvent.CLICK, globalFlash.gui.mFriendsListMenu.Invite);
            this.mFriendsList.optionButtons.btnReturnHome.addEventListener(MouseEvent.CLICK, this.ReturnHome);
            this.mOnlineStatusFriendQueue = {};
            this.mOnlineStatusGuildQueue = {};
            return;
        }// end function

        public function GetAdventures() : Array
        {
            var _loc_2:dPlayerListItemVO = null;
            var _loc_1:Array = [];
            for each (_loc_2 in this.mList)
            {
                
                if (_loc_2.id < 0 && _loc_2.adventureVO)
                {
                    _loc_1.push(_loc_2.adventureVO);
                }
            }
            return _loc_1;
        }// end function

        public function Refresh() : void
        {
            this.mFriendsList.list.dataProvider = [];
            this.mFriendsList.list.validateNow();
            this.AddCurrentPlayer();
            return;
        }// end function

        public function AddCurrentPlayer() : void
        {
            var _loc_1:* = globalFlash.gui.mAvatar.GetDisplayedPlayerVO();
            this.mFriendListPlayer = _loc_1;
            this.SetData(this.mList);
            return;
        }// end function

        public function IsGuildMember(param1:dPlayerListItemVO) : Boolean
        {
            var _loc_3:dGuildPlayerListItemVO = null;
            var _loc_2:* = this.mGI.GetCurrentPlayerGuild();
            if (_loc_2 == null)
            {
                return false;
            }
            for each (_loc_3 in _loc_2.members)
            {
                
                if (_loc_3.id == param1.id)
                {
                    return true;
                }
            }
            return false;
        }// end function

        public function GetGuildMemberById(param1:int) : dGuildPlayerListItemVO
        {
            var _loc_2:dGuildPlayerListItemVO = null;
            if (this.mGI.GetCurrentPlayerGuild() == null)
            {
                return null;
            }
            for each (_loc_2 in this.mGI.GetCurrentPlayerGuild().members)
            {
                
                if (_loc_2.id == param1)
                {
                    return _loc_2;
                }
            }
            return null;
        }// end function

        public function GetJoinedAdventuresCount() : int
        {
            var _loc_2:dPlayerListItemVO = null;
            var _loc_1:* = this.mTempAdventureJoinedCounter;
            for each (_loc_2 in this.mList)
            {
                
                if (_loc_2.adventureVO && _loc_2.adventureVO.ownerPlayerID != global.ui.mCurrentPlayer.GetPlayerId())
                {
                    _loc_1++;
                }
            }
            return _loc_1;
        }// end function

        private function ReturnHome(event:MouseEvent) : void
        {
            cBasicPanel.HideCurrentActivePanel();
            globalFlash.gui.mLoadingZonePanel.Show();
            global.ui.mCurrentPlayerZone.SaveZoneStartZoom();
            global.ui.mClientMessages.SendMessagetoServer(COMMAND.GET_ZONE, global.ui.mCurrentPlayer.GetHomeZoneId(), false);
            return;
        }// end function

        public function RefreshOnZoneLoad() : void
        {
            var _loc_1:* = this.mFriendsList.list.dataProvider as Array;
            this.mFriendsList.list.dataProvider = [];
            this.mFriendsList.list.dataProvider = _loc_1;
            return;
        }// end function

        public function GetGuildMemberByName_string(param1:String) : dGuildPlayerListItemVO
        {
            var _loc_3:dGuildPlayerListItemVO = null;
            var _loc_2:* = this.mGI.GetCurrentPlayerGuild();
            if (!_loc_2)
            {
                return null;
            }
            for each (_loc_3 in _loc_2.members)
            {
                
                if (_loc_3.username.toLowerCase() == param1)
                {
                    return _loc_3;
                }
            }
            return null;
        }// end function

        public function GetFriendByName_string(param1:String) : dPlayerListItemVO
        {
            var _loc_2:dPlayerListItemVO = null;
            for each (_loc_2 in this.mList)
            {
                
                if (_loc_2.username.toLowerCase() == param1)
                {
                    return _loc_2;
                }
            }
            return null;
        }// end function

        public function RemoveFriendById(param1:int) : void
        {
            var _loc_2:int = 0;
            while (_loc_2 < this.mList.length)
            {
                
                if ((this.mList[_loc_2] as dPlayerListItemVO).id == param1)
                {
                    this.mList.splice(_loc_2, 1);
                    break;
                }
                _loc_2++;
            }
            this.SetData(this.mList);
            return;
        }// end function

        public function RemoveFriend(param1:int) : void
        {
            global.ui.mClientMessages.SendMessagetoServer(COMMAND.REMOVE_FRIEND, 0, param1);
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.PLAYER_ACTION, this.mGI.mCurrentViewedZoneID, "Remove Friend");
            this.RemoveFriendById(param1);
            return;
        }// end function

        public function FilterList(event:ItemClickEvent) : void
        {
            this.mFilter = event.item.selection;
            this.SetData(this.mList);
            return;
        }// end function

        public function GetFriendById(param1:int) : dPlayerListItemVO
        {
            var _loc_2:dPlayerListItemVO = null;
            for each (_loc_2 in this.mList)
            {
                
                if (_loc_2.id == param1)
                {
                    return _loc_2;
                }
            }
            return null;
        }// end function

        public function GetFilteredFriends(param1:String, param2:Boolean = false) : Array
        {
            var _loc_4:dPlayerListItemVO = null;
            var _loc_6:dGuildPlayerListItemVO = null;
            var _loc_3:Array = [];
            param1 = param1.toLowerCase();
            for each (_loc_4 in this.mList)
            {
                
                if (_loc_4.id < 0)
                {
                    continue;
                }
                if (_loc_4.username.toLocaleLowerCase().indexOf(param1) == 0)
                {
                    _loc_3.push(_loc_4);
                }
            }
            if (!param2 || !this.mGI.GetCurrentPlayerGuild())
            {
                return _loc_3;
            }
            var _loc_5:int = 0;
            while (_loc_5 < _loc_3.length)
            {
                
                if (this.IsGuildMember(_loc_3[_loc_5]))
                {
                    _loc_3.splice(_loc_5, 1);
                    _loc_5 = _loc_5 - 1;
                }
                _loc_5++;
            }
            for each (_loc_6 in this.mGI.GetCurrentPlayerGuild().members)
            {
                
                if (_loc_6.id == this.mGI.mCurrentPlayer.GetPlayerId())
                {
                    continue;
                }
                if (_loc_6.username.toLocaleLowerCase().indexOf(param1) == 0)
                {
                    _loc_3.push(_loc_6);
                }
            }
            return _loc_3;
        }// end function

        public function GetCurrentAdventureVO() : dAdventureClientInfoVO
        {
            var _loc_1:dPlayerListItemVO = null;
            for each (_loc_1 in this.mList)
            {
                
                if (_loc_1.id < 0 && _loc_1.adventureVO && _loc_1.adventureVO.zoneID == this.mGI.mCurrentViewedZoneID)
                {
                    return _loc_1.adventureVO;
                }
            }
            return null;
        }// end function

        public function IsLoaded() : Boolean
        {
            return this.mIsLoaded;
        }// end function

        private function SortAdventuresDesc(param1:dPlayerListItemVO, param2:dPlayerListItemVO) : Number
        {
            if (param1.adventureVO.collectedTime < param2.adventureVO.collectedTime)
            {
                return 1;
            }
            if (param1.adventureVO.collectedTime > param2.adventureVO.collectedTime)
            {
                return -1;
            }
            return 0;
        }// end function

        private function SortFriends(param1:dPlayerListItemVO, param2:dPlayerListItemVO) : Number
        {
            if (param1.playerLevel < param2.playerLevel)
            {
                return 1;
            }
            if (param1.playerLevel > param2.playerLevel)
            {
                return -1;
            }
            return ObjectUtil.compare(param1.username, param2.username);
        }// end function

        public function AddFriend(param1:dPlayerListItemVO) : void
        {
            if (this.IsFriend(param1))
            {
                return;
            }
            if (param1.id > 0)
            {
            }
            global.ui.mClientMessages.SendMessagetoServer(COMMAND.ADD_FRIEND, 0, param1.id);
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.PLAYER_ACTION, this.mGI.mCurrentViewedZoneID, "Send Friend Request");
            return;
        }// end function

    }
}
