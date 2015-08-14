package NewQuestSystem.Client
{
    import AdventureSystem.*;
    import BuffSystem.*;
    import Communication.VO.*;
    import Communication.VO.UpdateVO.*;
    import Enums.*;
    import GO.*;
    import Interface.*;
    import MilitarySystem.*;
    import NewQuestSystem.*;
    import ServerState.*;
    import Specialists.*;
    import flash.utils.*;

    public class QuestClientCallbacks extends Object
    {
        private var mClientQuestPool:dQuestPoolVO = null;
        private var mLastActiveQuestWindow:dQuestElementVO;
        private var mGeneralInterface:cGeneralInterface;

        public function QuestClientCallbacks(param1:cGeneralInterface)
        {
            this.mGeneralInterface = param1;
            return;
        }// end function

        public function SetColorSchema(param1:dQuestPoolVO) : void
        {
            var _loc_2:dQuestElementVO = null;
            if (!defines.FILTER_ACTIVATED)
            {
                return;
            }
            if (this.mGeneralInterface.mCurrentPlayerZone.mZoneColorSchema != null)
            {
                return;
            }
            var _loc_3:String = null;
            var _loc_4:String = null;
            for each (_loc_2 in param1.GetQuest_vector())
            {
                
                if (_loc_2.mQuestMode == QuestManagerStatic.QUEST_MODE_RUNNING)
                {
                    _loc_3 = _loc_2.mQuestDefinition.colorSchema_string;
                    if (_loc_3 != "")
                    {
                        _loc_4 = _loc_3;
                        break;
                    }
                }
            }
            if (gGfxResource.SetFilter(_loc_4, FILTER_SOURCE.QUEST))
            {
                gGfxResource.ApplyZoom(this.mGeneralInterface.mZoom.GetInvScaleFactor());
                this.mGeneralInterface.mCurrentPlayerZone.SetBackgroundHasChanged(true);
                this.mGeneralInterface.mCurrentPlayerZone.SetAllRescaleDirtyFlags();
            }
            return;
        }// end function

        public function GetLatestQuestList() : void
        {
            if (!this.IsActive())
            {
                return;
            }
            if (!this.mGeneralInterface.IsCurrentPlayerQuestPlayer())
            {
                return;
            }
            this.SendServerQuestTrigger(QuestManagerStatic.SERVER_STACK_GET_LATEST_QUEST_LIST, null);
            return;
        }// end function

        public function GetClientQuestPool() : dQuestPoolVO
        {
            return this.mClientQuestPool;
        }// end function

        public function RewardCloseButtonPressedFromGui() : void
        {
            return;
        }// end function

        public function ZoneRefreshed(param1:int, param2:Boolean, param3:Boolean, param4:dZoneVO) : void
        {
            var _loc_5:dQuestElementVO = null;
            if (!QuestManagerStatic.IsActive())
            {
                return;
            }
            this.mClientQuestPool = new dQuestPoolVO();
            if (this.mGeneralInterface.IsCurrentPlayerQuestPlayer())
            {
                this.mClientQuestPool = param4.questPool;
                for each (_loc_5 in this.mClientQuestPool.GetQuest_vector())
                {
                    
                    if (_loc_5.mQuestDefinition == null)
                    {
                        _loc_5.mQuestDefinition = QuestManagerStatic.GetQuestFromName(param1, _loc_5.mQuestName_string);
                    }
                }
                this.SetColorSchema(this.mClientQuestPool);
                if (!param2)
                {
                    this.mLastActiveQuestWindow = null;
                    for each (_loc_5 in this.mClientQuestPool.GetQuest_vector())
                    {
                        
                        if (_loc_5.IsADailyLoginQuest())
                        {
                            if (this.ShowCurrentQuestWindow(_loc_5, param3))
                            {
                                break;
                            }
                        }
                    }
                    for each (_loc_5 in this.mClientQuestPool.GetQuest_vector())
                    {
                        
                        if (!_loc_5.IsADailyLoginQuest())
                        {
                            if (this.ShowCurrentQuestWindow(_loc_5, param3))
                            {
                                break;
                            }
                        }
                    }
                }
                else
                {
                    for each (_loc_5 in this.mClientQuestPool.GetQuest_vector())
                    {
                        
                        if (!_loc_5.IsADailyLoginQuest())
                        {
                            if (_loc_5.mQuestMode != QuestManagerStatic.QUEST_MODE_RUNNING)
                            {
                                if (this.mLastActiveQuestWindow == null || !this.mLastActiveQuestWindow.IsEqualTo(_loc_5))
                                {
                                    if (this.ShowCurrentQuestWindow(_loc_5, true))
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            this.RefreshQuestList(this.mClientQuestPool);
            return;
        }// end function

        public function GetTotalValuesForQuestTrigger(param1:cPlayerData, param2:dQuestElementVO, param3:int) : int
        {
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_4:* = param2.mQuestDefinition.questTriggers_vector[param3];
            switch(_loc_4.type)
            {
                case QuestManagerStatic.TYPE_BUILDING:
                {
                    if (_loc_4.condition == QuestManagerStatic.CONDITION_LESS)
                    {
                        _loc_5 = param1.GetBuildingCount(_loc_4.name_string) - (_loc_4.amount - 1);
                        if (_loc_5 < 0)
                        {
                            _loc_5 = 0;
                        }
                        return _loc_5;
                    }
                    break;
                }
                case QuestManagerStatic.TYPE_PLAYERLEVEL:
                {
                    if (_loc_4.condition == QuestManagerStatic.CONDITION_LESS)
                    {
                        _loc_6 = param1.GetPlayerLevel() - (_loc_4.amount - 1);
                        if (_loc_6 < 0)
                        {
                            _loc_6 = 0;
                        }
                        return _loc_6;
                    }
                    break;
                }
                case QuestManagerStatic.TYPE_SECTOR:
                {
                    if (_loc_4.condition == QuestManagerStatic.CONDITION_CLAIMED)
                    {
                        return 1;
                    }
                    break;
                }
                default:
                {
                    break;
                }
            }
            return _loc_4.amount;
        }// end function

        public function ShowQuestInfo() : void
        {
            return;
        }// end function

        public function RefreshQuestElement(param1:dQuestElementVO) : void
        {
            var _loc_3:dQuestElementVO = null;
            if (param1 == null)
            {
                return;
            }
            var _loc_2:int = 0;
            while (_loc_2 < this.mClientQuestPool.GetQuest_vector().length)
            {
                
                _loc_3 = this.mClientQuestPool.GetQuest_vector().getItemAt(_loc_2) as dQuestElementVO;
                if (_loc_3.mUniqueID.equals(param1.mUniqueID))
                {
                    this.mClientQuestPool.GetQuest_vector().setItemAt(param1, _loc_2);
                    break;
                }
                _loc_2++;
            }
            return;
        }// end function

        public function ReceivedMessagesFromServer(param1:dQuestUpdateVO) : void
        {
            var _loc_2:dQuestElementVO = null;
            var _loc_3:dAdventureClientInfoVO = null;
            var _loc_4:dAdventureClientInfoVO = null;
            var _loc_5:dGameTickCommandVO = null;
            if (!this.mGeneralInterface.IsCurrentPlayerQuestPlayer())
            {
                return;
            }
            switch(param1.mode)
            {
                case QuestManagerStatic.QUEST_UPDATE_APPLY_REWARD_EFFECTS:
                {
                    this.mGeneralInterface.AddGameTickCommand(param1.object as dGameTickCommandVO);
                    break;
                }
                case QuestManagerStatic.QUEST_UPDATE_REFRESH_QUEST_LIST:
                {
                    this.RefreshQuestList(param1.object as dQuestPoolVO);
                    break;
                }
                case QuestManagerStatic.QUEST_UPDATE_ADVENTURE_WON:
                {
                    _loc_3 = param1.object as dAdventureClientInfoVO;
                    _loc_4 = globalFlash.gui.mFriendsList.GetCurrentAdventureVOIdAndName(_loc_3.ownerPlayerID, _loc_3.adventureName);
                    if (_loc_4 != null)
                    {
                        _loc_4.status = cAdventure.STATUS_FINISHED_WON;
                        globalFlash.gui.mAdventurePanel.SetData(_loc_4);
                        globalFlash.gui.mAdventurePanel.Show();
                    }
                    else
                    {
                        globalFlash.gui.mAdventurePanel.SetData(_loc_3);
                        globalFlash.gui.mAdventurePanel.Show();
                    }
                    break;
                }
                case QuestManagerStatic.QUEST_UPDATE_SET_HINT_DATA:
                {
                    _loc_2 = param1.object as dQuestElementVO;
                    globalFlash.gui.mHintPointer.SetDataAsArrayCollection(_loc_2.GetQuestDefinition().questHints);
                    break;
                }
                case QuestManagerStatic.QUEST_UPDATE_SHOW_QUEST_WINDOW:
                {
                    _loc_2 = param1.object as dQuestElementVO;
                    if (this.mLastActiveQuestWindow == null || !this.mLastActiveQuestWindow.IsEqualTo(_loc_2))
                    {
                        this.ShowCurrentQuestWindow(_loc_2, true);
                    }
                    break;
                }
                case QuestManagerStatic.QUEST_UPDATE_QUEST_TRIGGER_CHANGED:
                {
                    _loc_2 = param1.object as dQuestElementVO;
                    this.RefreshLastQuestList(_loc_2);
                    break;
                }
                case QuestManagerStatic.QUEST_UPDATE_HIDE_QUEST_WINDOW:
                {
                    _loc_2 = param1.object as dQuestElementVO;
                    this.RefreshLastQuestList(_loc_2);
                    break;
                }
                case QuestManagerStatic.QUEST_UPDATE_PAY_FOR_QUEST:
                {
                    _loc_5 = param1.object as dGameTickCommandVO;
                    this.mGeneralInterface.AddGameTickCommand(_loc_5);
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

        public function InitiatePayForQuestFinish(param1:dUniqueID) : void
        {
            if (!this.IsActive())
            {
                return;
            }
            if (!this.mGeneralInterface.IsCurrentPlayerQuestPlayer())
            {
                return;
            }
            this.SendServerQuestTrigger(QuestManagerStatic.SERVER_STACK_PAY_FOR_QUEST_FINISH, param1);
            return;
        }// end function

        public function GetRemainingValuesForQuestTrigger(param1:cPlayerData, param2:dQuestElementVO, param3:int) : int
        {
            var _loc_5:cSpecialist = null;
            var _loc_6:int = 0;
            var _loc_7:cPlayerData = null;
            var _loc_8:cBuilding = null;
            var _loc_9:cResources = null;
            var _loc_10:int = 0;
            var _loc_11:cResources = null;
            var _loc_12:int = 0;
            var _loc_13:int = 0;
            var _loc_14:String = null;
            var _loc_15:cSquad = null;
            var _loc_16:int = 0;
            var _loc_17:cBuff = null;
            var _loc_4:* = param2.mQuestDefinition.questTriggers_vector[param3];
            ;
            
            switch(_loc_4.condition)
            {
                case QuestManagerStatic.CONDITION_ONMAP:
                {
                    return param1.GetBuildingCount(_loc_4.name_string) > 0 ? (0) : (1);
                }
                case QuestManagerStatic.CONDITION_ONMAP_VISITOR:
                {
                    _loc_6 = this.mGeneralInterface.mHomePlayer.GetPlayerId();
                    for each (_loc_7 in this.mGeneralInterface.GetPlayerList_vector())
                    {
                        
                        if (_loc_7.GetPlayerId() != _loc_6)
                        {
                            return _loc_7.GetBuildingCount(_loc_4.name_string) > 0 ? (0) : (1);
                        }
                    }
                    break;
                }
                case QuestManagerStatic.CONDITION_GREATER_OR_EQUAL:
                {
                    return _loc_4.amount - param1.GetBuildingCount(_loc_4.name_string);
                }
                case QuestManagerStatic.CONDITION_LESS:
                {
                    return 0;
                }
                case QuestManagerStatic.CONDITION_ASSIGNED_UNITS:
                {
                    for each (_loc_8 in this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.GetBuildings_vector())
                    {
                        
                        if (_loc_8.GetBuildingName_string() == _loc_4.name_string)
                        {
                            return _loc_8.GetArmy().HasUnits() ? (0) : (1);
                        }
                    }
                    break;
                }
                case QuestManagerStatic.CONDITION_SELECTED:
                case QuestManagerStatic.CONDITION_DESTROYED:
                case QuestManagerStatic.CONDITION_UPGRADED:
                {
                    return 1 - param2.GetTriggerStatus(param3);
                }
                default:
                {
                    break;
                }
            }
            ;
            
            if (_loc_4.condition == QuestManagerStatic.CONDITION_GREATER_OR_EQUAL)
            {
                _loc_9 = this.mGeneralInterface.mCurrentPlayerZone.GetResources(param1);
                return _loc_4.amount - _loc_9.GetPlayerResource(_loc_4.name_string).amount;
            }
            if (_loc_4.condition == QuestManagerStatic.CONDITION_GREATER_OR_EQUAL_DELTA)
            {
            }
            if (param2.GetTriggerStatus(param3) == 1)
            {
                return 0;
            }
            _loc_10 = param2.GetDeltaStart(param3) as int;
            _loc_11 = this.mGeneralInterface.mCurrentPlayerZone.GetResources(param1);
            _loc_12 = _loc_11.GetPlayerResource(_loc_4.name_string).amount;
            _loc_13 = _loc_12 - _loc_10;
            return _loc_4.amount - _loc_13;
        }// end function

        public function QuestOkButtonPressedFromGui(param1:dQuestElementVO) : void
        {
            if (!this.IsActive())
            {
                return;
            }
            if (!this.mGeneralInterface.IsCurrentPlayerQuestPlayer())
            {
                return;
            }
            var _loc_2:dUniqueID = null;
            if (param1 != null)
            {
                _loc_2 = param1.GetUniqueId();
                param1.SetQuestMode(QuestManagerStatic.QUEST_MODE_RUNNING);
                this.SetColorSchema(this.mClientQuestPool);
            }
            else if (this.mGeneralInterface.mLog.isErrorEnabled(LOG_TYPE.QUEST))
            {
                this.mGeneralInterface.mLog.logError(LOG_TYPE.QUEST, "QuestOkButtonPressedFromGui: Quest is null not found!");
            }
            this.SendServerQuestTrigger(QuestManagerStatic.SERVER_STACK_QUEST_BUTTON_OK, _loc_2);
            return;
        }// end function

        private function SendServerQuestTrigger(param1:int, param2:Object) : void
        {
            var _loc_3:dServerAction = null;
            _loc_3 = new dServerAction();
            _loc_3.type = param1;
            _loc_3.data = param2;
            this.mGeneralInterface.mClientMessages.SendMessagetoServer(COMMAND.QUEST_TRIGGER, this.mGeneralInterface.mCurrentViewedZoneID, _loc_3);
            return;
        }// end function

        private function RefreshQuestList(param1:dQuestPoolVO) : void
        {
            this.mClientQuestPool = param1;
            this.RefreshLastQuestList(null);
            return;
        }// end function

        public function CancelQuest(param1:dUniqueID) : void
        {
            if (!this.IsActive())
            {
                return;
            }
            if (!this.mGeneralInterface.IsCurrentPlayerQuestPlayer())
            {
                return;
            }
            this.SendServerQuestTrigger(QuestManagerStatic.SERVER_STACK_CANCEL_QUEST, param1);
            return;
        }// end function

        public function RewardOkButtonPressedFromGui(param1:dQuestElementVO) : void
        {
            if (!this.IsActive())
            {
                return;
            }
            if (!this.mGeneralInterface.IsCurrentPlayerQuestPlayer())
            {
                return;
            }
            var _loc_2:dUniqueID = null;
            if (param1 != null)
            {
                param1.SetQuestMode(QuestManagerStatic.QUEST_MODE_LOOP_UNTIL_QUEST_REWARD_COULD_BE_ASSIGNED);
                _loc_2 = param1.GetUniqueId();
            }
            else if (this.mGeneralInterface.mLog.isErrorEnabled(LOG_TYPE.QUEST))
            {
                this.mGeneralInterface.mLog.logError(LOG_TYPE.QUEST, "RewardOkButtonPressedFromGui: Quest  not found!");
            }
            this.SendServerQuestTrigger(QuestManagerStatic.SERVER_STACK_REWARD_BUTTON_OK, _loc_2);
            return;
        }// end function

        public function IsBuffOnFriendQuestActive() : Boolean
        {
            return this.mClientQuestPool.IsTriggerInAtLeastOneQuestAndQuestRunning(QuestManagerStatic.TYPE_BUFF_ON_FRIEND);
        }// end function

        public function RefreshLastQuestList(param1:dQuestElementVO) : void
        {
            if (param1 != null)
            {
                this.RefreshQuestElement(param1);
            }
            globalFlash.gui.mQuestBook.SetQuestData(this.mClientQuestPool);
            return;
        }// end function

        public function IsActive() : Boolean
        {
            return QuestManagerStatic.IsActive() && this.mClientQuestPool != null;
        }// end function

        public function BuildingSelectedGui(param1:cBuilding) : void
        {
            if (!this.IsActive())
            {
                return;
            }
            if (!this.mGeneralInterface.IsCurrentPlayerQuestPlayer())
            {
                return;
            }
            var _loc_2:* = this.mClientQuestPool.IsTriggerAndConditionInAtLeastOneQuestAndQuestRunning(QuestManagerStatic.TYPE_BUILDING, QuestManagerStatic.CONDITION_SELECTED);
            if (_loc_2 != null)
            {
                this.SendServerQuestTrigger(QuestManagerStatic.SERVER_STACK_BUILDING_SELECTED, param1.GetBuildingGrid());
                this.mClientQuestPool.CheckQuestTrigger(QuestManagerStatic.TYPE_BUILDING, QuestManagerStatic.CONDITION_SELECTED, param1.GetBuildingName_string(), this.mGeneralInterface);
            }
            return;
        }// end function

        public function BuildingCreated(param1:String) : void
        {
            this.JustRefresh();
            return;
        }// end function

        public function JustRefresh() : void
        {
            if (!this.IsActive())
            {
                return;
            }
            if (!this.mGeneralInterface.IsCurrentPlayerQuestPlayer())
            {
                return;
            }
            this.SendServerQuestTrigger(QuestManagerStatic.SERVER_STACK_JUST_REFRESH, null);
            return;
        }// end function

        public function QuestCloseButtonPressedFromGui() : void
        {
            if (!this.IsActive())
            {
                return;
            }
            if (!this.mGeneralInterface.IsCurrentPlayerQuestPlayer())
            {
            }
            return;
        }// end function

        public function IsADailyQuestFromRandomListRunning(param1:dQuestElementVO) : Boolean
        {
            var _loc_3:dQuestElementVO = null;
            var _loc_4:dQuestDefinitionPostrequisitsVO = null;
            var _loc_5:dQuestDefinitionPostrequisitsVO = null;
            var _loc_6:String = null;
            var _loc_7:dQuestElementVO = null;
            var _loc_2:* = new Dictionary();
            if (param1.mQuestDefinition.questTyp == QuestManagerStatic.QUEST_TYPE_DAILY_QUEST)
            {
                for each (_loc_4 in param1.mQuestDefinition.questPostrequisits)
                {
                    
                    if (_loc_4.type == QuestManagerStatic.TYPE_RANDOM_QUEST_LIST)
                    {
                        for each (_loc_5 in _loc_4.postrequisits_vector)
                        {
                            
                            _loc_6 = _loc_5.name_string;
                            _loc_2[_loc_6] = param1;
                        }
                    }
                }
            }
            for each (_loc_3 in this.mClientQuestPool.GetQuest_vector())
            {
                
                _loc_7 = _loc_2[_loc_3.mQuestName_string];
                if (_loc_7 != null)
                {
                    if (_loc_3.mQuestMode == QuestManagerStatic.QUEST_MODE_RUNNING)
                    {
                        return true;
                    }
                }
            }
            return false;
        }// end function

        public function ShowCurrentQuestWindow(param1:dQuestElementVO, param2:Boolean) : Boolean
        {
            var _loc_4:int = 0;
            var _loc_5:dQuestTriggerVO = null;
            var _loc_3:Boolean = false;
            this.mLastActiveQuestWindow = null;
            this.SetColorSchema(this.mClientQuestPool);
            if (param1.mQuestDefinition != null)
            {
                switch(param1.GetQuestMode())
                {
                    case QuestManagerStatic.QUEST_MODE_RUNNING:
                    {
                        if (param1.mQuestDefinition.showQuestWindow)
                        {
                            if (param2)
                            {
                                this.mLastActiveQuestWindow = param1;
                                _loc_3 = true;
                            }
                        }
                        break;
                    }
                    case QuestManagerStatic.QUEST_MODE_START_WINDOW_DESCRIPTION_WAIT_FOR_BUTTON_PRESSED:
                    {
                        if (param1.mQuestDefinition.showQuestWindow)
                        {
                            if (param2)
                            {
                                if (!globalFlash.gui.mAvatarMessageList.IsMessageInList(AVATAR_MESSAGE_TYPE.NEW_QUEST))
                                {
                                    globalFlash.gui.ShowNewQuestNotification(param1);
                                    globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.NEW_QUEST);
                                }
                                this.mLastActiveQuestWindow = param1;
                                _loc_3 = true;
                            }
                        }
                        break;
                    }
                    case QuestManagerStatic.QUEST_MODE_REWARD_WINDOW_WAIT_FOR_BUTTON_ACTIVE:
                    {
                        _loc_4 = param1.GetQuestDefinition().FindTriggerWithType(QuestManagerStatic.TYPE_DAILYLOGIN);
                        if (_loc_4 != -1)
                        {
                            if (param1.mQuestDefinition.showRewardWindow)
                            {
                                if (param2)
                                {
                                    this.mLastActiveQuestWindow = param1;
                                    _loc_5 = param1.mQuestTriggersFinished_vector[_loc_4];
                                    if (_loc_5.status < 0)
                                    {
                                        globalFlash.gui.SetDataDailyLogin(param1, -_loc_5.status);
                                    }
                                    else
                                    {
                                        globalFlash.gui.SetDataDailyLogin(param1, 0);
                                    }
                                }
                            }
                        }
                        else if (param1.mQuestDefinition.showRewardWindow)
                        {
                            if (param2)
                            {
                                this.mLastActiveQuestWindow = param1;
                                globalFlash.gui.ShowCompletedQuestNotification(param1);
                                _loc_3 = true;
                            }
                        }
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
            if (_loc_3)
            {
                this.RefreshLastQuestList(param1);
            }
            return _loc_3;
        }// end function

    }
}
