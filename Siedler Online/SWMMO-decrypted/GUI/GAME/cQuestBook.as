package GUI.GAME
{
    import AdventureSystem.*;
    import Communication.VO.*;
    import Communication.VO.UpdateVO.*;
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.*;
    import GUI.Components.ToolTips.*;
    import GUI.Events.*;
    import GUI.Loca.*;
    import Interface.*;
    import NewQuestSystem.*;
    import ServerState.*;
    import Sound.*;
    import Specialists.*;
    import flash.events.*;
    import mx.collections.*;
    import mx.controls.*;
    import mx.events.*;
    import nLib.*;

    public class cQuestBook extends cBasicPanel
    {
        private var mBtnCancelAdventure:StandardButton;
        private var mGI:cGameInterface;
        private var mPanel:QuestBook;
        private var mQuestPool:dQuestPoolVO;
        private var mLM:cLocaManager;
        private var mNotificationQuest:dQuestElementVO;
        private var mBtnOK:StandardButton;
        private var mTrackingChanged:Boolean = false;
        private var mPreselectedQuest:dQuestElementVO;
        private var mBtnCancelQuest:StandardButton;
        private var mSelectedItem:Object;
        private var mBtnFinishQuest:StandardButton;
        private var mBtnInstantFinish:StandardButton;
        private static const MODE_RUNNING:int = 1;
        private static const MODE_DEACTIVATED:int = 3;
        private static const MODE_PREVIEW:int = 0;
        private static const MODE_FINISHED:int = 2;

        public function cQuestBook()
        {
            this.mLM = cLocaManager.GetInstance();
            return;
        }// end function

        public function SendTrackedMissionList(param1:Boolean = false) : void
        {
            var _loc_3:dQuestElementVO = null;
            var _loc_4:dAdventureClientInfoVO = null;
            var _loc_5:dServerAction = null;
            if (!this.mTrackingChanged && !param1)
            {
                return;
            }
            var _loc_2:* = new dTrackedMissionListVO();
            for each (_loc_3 in this.mGI.mQuestClientCallbacks.GetClientQuestPool().mQuestVO_vector)
            {
                
                if (_loc_3.mIsTrackedMission)
                {
                    _loc_2.trackedMissionList.addItem(new dTrackedMissionVO().init(MISSION_TYPE.QUEST, _loc_3.mUniqueID.uniqueID1, _loc_3.mUniqueID.uniqueID2));
                }
            }
            for each (_loc_4 in globalFlash.gui.mFriendsList.GetAdventures())
            {
                
                if (_loc_4.isTrackedMission)
                {
                    _loc_2.trackedMissionList.addItem(new dTrackedMissionVO().init(MISSION_TYPE.ADVENTURE, _loc_4.zoneID, 0));
                }
            }
            _loc_5 = new dServerAction();
            _loc_5.data = _loc_2;
            this.mGI.mClientMessages.SendMessagetoServer(COMMAND.CHANGE_TRACKED_MISSION_LIST, this.mGI.mCurrentViewedZoneID, _loc_5);
            this.mTrackingChanged = false;
            return;
        }// end function

        public function SetQuestData(param1:dQuestPoolVO) : void
        {
            this.mQuestPool = param1;
            this.SetData();
            globalFlash.gui.mTrackedMissionList.Refresh();
            return;
        }// end function

        private function ClosePanel(event:MouseEvent) : void
        {
            this.Hide();
            return;
        }// end function

        private function SetData() : void
        {
            var _loc_8:dQuestElementVO = null;
            var _loc_1:Array = [];
            var _loc_2:Array = [];
            var _loc_3:Array = [];
            var _loc_4:Boolean = false;
            var _loc_5:int = 0;
            while (_loc_5 < this.mQuestPool.GetQuest_vector().length)
            {
                
                _loc_8 = this.mQuestPool.GetQuest_vector()[_loc_5];
                if (_loc_8.mQuestDefinition != null)
                {
                    if (_loc_8.mQuestName_string == "DailyQuest")
                    {
                        _loc_4 = true;
                    }
                    if (_loc_8.IsQuestModeAllowedForQuestList())
                    {
                        if (_loc_8.mQuestDefinition.showQuestWindow || _loc_8.mQuestDefinition.showRewardWindow)
                        {
                            if (_loc_8.mQuestDefinition.questTyp == QuestManagerStatic.QUEST_TYPE_IS_IN_RANDOM_LIST_OF_DAILY_QUEST)
                            {
                                if (_loc_8.mQuestMode == QuestManagerStatic.QUEST_MODE_PENDING_NEXT_RANDOM_DAILY_QUEST)
                                {
                                    _loc_3.push(_loc_8);
                                }
                                else
                                {
                                    _loc_2.push(_loc_8);
                                }
                            }
                            else
                            {
                                _loc_1.push(_loc_8);
                            }
                        }
                    }
                }
                _loc_5++;
            }
            var _loc_6:Array = [];
            var _loc_7:* = this.mGI.mCurrentPlayer.GetPlayerLevel() < 16 && this.mGI.mCurrentPlayer.GetPlayerId() == this.mGI.mCurrentViewedZoneID ? ("TutorialQuests") : ("Quests");
            _loc_6.push({groupId:_loc_7, data:_loc_1});
            if (_loc_4)
            {
                _loc_6.push({groupId:"DailyQuests", data:_loc_2});
            }
            if (this.mGI.mCurrentPlayer.GetPlayerLevel() >= cSpecialistTask_FindEventZone.PLAYER_LEVEL_SHORT || globalFlash.gui.mFriendsList.GetAdventures().length > 0)
            {
                _loc_6.push({groupId:"ActiveAdventures", data:globalFlash.gui.mFriendsList.GetAdventures()});
            }
            if (_loc_4)
            {
                _loc_6.push({groupId:"WaitingDailyQuests", data:_loc_3});
            }
            this.mPanel.list.dataProvider = _loc_6;
            if (this.mSelectedItem)
            {
                this.mPanel.list.selectedItem = this.mSelectedItem;
            }
            return;
        }// end function

        public function SetNotificationQuest(param1:dQuestElementVO) : void
        {
            this.mNotificationQuest = param1;
            return;
        }// end function

        override public function Show() : void
        {
            cSoundManager.GetInstance().PlayEffect("QuestOpenLog");
            this.SetData();
            this.Clear();
            if (this.mPreselectedQuest)
            {
                this.DisplayQuest(this.mPreselectedQuest);
            }
            else if (this.mNotificationQuest)
            {
                this.DisplayQuest(this.mNotificationQuest);
            }
            else
            {
                this.DisplayNextItem();
            }
            super.Show();
            return;
        }// end function

        private function CancelAdventure(event:CloseEvent) : void
        {
            if (event.detail != Alert.OK)
            {
                return;
            }
            var _loc_2:* = this.mSelectedItem as dAdventureClientInfoVO;
            globalFlash.gui.mFriendsList.RemoveFriendById(_loc_2.zoneID);
            global.ui.mClientMessages.SendMessagetoServer(COMMAND.CANCEL_ADVENTURE, _loc_2.zoneID, null);
            this.SetData();
            this.DisplayNextItem(_loc_2);
            return;
        }// end function

        public function SetPreselectedQuest(param1:dQuestElementVO) : void
        {
            this.mPreselectedQuest = param1;
            return;
        }// end function

        private function Visit(event:MouseEvent) : void
        {
            globalFlash.gui.mStarMenu.ResetScrollPosition();
            global.ui.mCurrentPlayerZone.SaveZoneStartZoom();
            var _loc_2:* = gMisc.IntToObject(int(this.mGI.mQuestClientCallbacks.IsBuffOnFriendQuestActive()));
            global.ui.mClientMessages.SendMessagetoServer(COMMAND.GET_ZONE, (this.mSelectedItem as dAdventureClientInfoVO).zoneID, _loc_2);
            globalFlash.gui.mLoadingZonePanel.Show();
            return;
        }// end function

        private function Clear() : void
        {
            this.ClearDetails();
            this.mSelectedItem = null;
            this.mPanel.list.selectedItem = null;
            return;
        }// end function

        public function Init(param1:QuestBook) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            this.mPanel.btnClose.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            this.mPanel.btnShowDetails.addEventListener(MouseEvent.CLICK, this.ShowAdventureDetails);
            this.mPanel.btnInvite.addEventListener(MouseEvent.CLICK, this.ShowAdventureDetails);
            this.mPanel.btnSendArmy.addEventListener(MouseEvent.CLICK, this.SendArmy);
            this.mPanel.btnVisit.addEventListener(MouseEvent.CLICK, this.Visit);
            this.mPanel.list.addEventListener(TrackMissionEvent.TRACK_MISSION, this.TrackMission);
            this.mPanel.list.addEventListener(ItemClickEvent.ITEM_CLICK, this.ItemClickedHandler);
            this.mPanel.btnInstantFinish.addEventListener(MouseEvent.CLICK, this.InstantFinish);
            this.mPanel.btnInstantFinish.addEventListener(ToolTipEvent.TOOL_TIP_CREATE, this.CreateInstantFinishTip);
            this.mPanel.btnCancelQuest.addEventListener(MouseEvent.CLICK, this.ConfirmCancelQuest);
            this.mPanel.btnFinishQuest.addEventListener(MouseEvent.CLICK, this.FinishQuest);
            this.mPanel.btnOK.addEventListener(MouseEvent.CLICK, this.DisplayNextItem);
            this.mPanel.btnCancelAdventure.addEventListener(MouseEvent.CLICK, this.ConfirmCancelAdventure);
            this.mBtnInstantFinish = this.mPanel.btnInstantFinish;
            this.mBtnFinishQuest = this.mPanel.btnFinishQuest;
            this.mBtnCancelQuest = this.mPanel.btnCancelQuest;
            this.mBtnOK = this.mPanel.btnOK;
            this.mBtnCancelAdventure = this.mPanel.btnCancelAdventure;
            this.mPanel.footerButtons.removeAllChildren();
            return;
        }// end function

        private function InstantFinish(event:MouseEvent) : void
        {
            var _loc_2:* = this.mSelectedItem as dQuestElementVO;
            var _loc_3:* = this.mGI.mCurrentPlayerZone.GetResources(this.mGI.mCurrentPlayer);
            if (_loc_3.HasPlayerResource(defines.HARD_CURRENCY_RESOURCE_NAME_string, _loc_2.mQuestDefinition.questWinGemCosts))
            {
                this.Clear();
                _loc_2.mQuestMode = QuestManagerStatic.QUEST_MODE_REWARD_COLLECTED_IDLE;
                this.DisplayQuest(_loc_2);
                this.mGI.mClientMessages.SendMessagetoServer(COMMAND.BUY_ONE_CLICK_SHOP_ITEM, this.mGI.mCurrentViewedZoneID, new dBuyOneClickShopItemVO().InitWithUniqueID(8006, _loc_2.mUniqueID));
            }
            else
            {
                CustomAlert.show("MissingHardCurrency", "", Alert.OK | Alert.CANCEL, null, this.AddHardCurrencyHandler, null, Alert.OK, true, CustomAlert.STYLE_PAYMENT);
            }
            return;
        }// end function

        private function DisplayAdventure(param1:dAdventureClientInfoVO) : void
        {
            this.mSelectedItem = param1;
            this.mPanel.adventureOptions.visible = true;
            this.mPanel.adventureTodo.visible = true;
            this.mPanel.selectedIcon.source = cAdventureDefinition.FindAdventureDefinition(param1.adventureName).GetAvatarImage();
            this.mPanel.selectedIcon.visible = true;
            this.mPanel.detailsHeadline.text = this.mLM.GetText(LOCA_GROUP.ADVENTURE_NAME, param1.adventureName);
            this.mPanel.description.text = this.mLM.GetText(LOCA_GROUP.ADVENTURE_OPENER, param1.adventureName);
            this.mPanel.todoText.text = this.mLM.GetText(LOCA_GROUP.ADVENTURE_TODO, param1.adventureName);
            this.mPanel.todoText.text = this.mLM.GetText(LOCA_GROUP.ADVENTURE_TODO, param1.adventureName);
            this.mPanel.btnVisit.enabled = this.mGI.mCurrentViewedZoneID != param1.zoneID;
            this.mPanel.btnInvite.enabled = param1.players.length < cAdventureDefinition.FindAdventureDefinition(param1.adventureName).mMaxPlayers && param1.ownerPlayerID == this.mGI.mCurrentPlayer.GetPlayerId();
            this.mBtnCancelAdventure.enabled = this.mGI.mCurrentPlayer.GetHomeZoneId() == param1.ownerPlayerID && param1.collectedTime < param1.totalDuration && param1.status < cAdventure.STATUS_FINISHED_WON;
            this.mPanel.footerButtons.addChild(this.mBtnCancelAdventure);
            return;
        }// end function

        private function ItemClickedHandler(event:ItemClickEvent) : void
        {
            this.ClearDetails();
            if (event.item is dQuestElementVO)
            {
                this.DisplayQuest(event.item as dQuestElementVO);
            }
            else if (event.item is dAdventureClientInfoVO)
            {
                this.DisplayAdventure(event.item as dAdventureClientInfoVO);
            }
            return;
        }// end function

        private function ConfirmCancelQuest(event:MouseEvent) : void
        {
            CustomAlert.show("ConfirmCancelQuest", "ConfirmCancelQuest", Alert.OK | Alert.CANCEL, null, this.CancelQuest);
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

        private function ShowAdventureDetails(event:MouseEvent) : void
        {
            if (!(this.mSelectedItem as dAdventureClientInfoVO))
            {
                return;
            }
            globalFlash.gui.mAdventurePanel.SetData(this.mSelectedItem as dAdventureClientInfoVO);
            globalFlash.gui.mAdventurePanel.Show();
            return;
        }// end function

        private function ClearDetails() : void
        {
            this.mPanel.detailsHeadline.text = "";
            this.mPanel.description.text = "";
            this.mPanel.todoText.text = "";
            this.mPanel.triggers.dataProvider = null;
            this.mPanel.rewardsList.dataPovider = null;
            this.mPanel.rewardsList.visible = false;
            this.mPanel.adventureOptions.visible = false;
            this.mPanel.adventureTodo.visible = false;
            this.mPanel.rewardsTitle.visible = false;
            this.mPanel.selectedIcon.visible = false;
            this.mPanel.rewardOrnamentalLeft.visible = false;
            this.mPanel.rewardOrnamentalRight.visible = false;
            this.mPanel.footerButtons.removeAllChildren();
            this.mBtnFinishQuest.enabled = false;
            this.mBtnCancelQuest.enabled = false;
            this.mBtnInstantFinish.enabled = false;
            this.mPanel.background.styleName = "basicPanel";
            this.mPanel.backgroundFooter.styleName = "questPanelFooter";
            return;
        }// end function

        private function TrackMission(event:TrackMissionEvent) : void
        {
            var _loc_2:dAdventureClientInfoVO = null;
            var _loc_3:dQuestElementVO = null;
            if (event.item is dAdventureClientInfoVO)
            {
                _loc_2 = event.item as dAdventureClientInfoVO;
                _loc_2.isTrackedMission = event.track;
            }
            else if (event.item is dQuestElementVO)
            {
                _loc_3 = event.item as dQuestElementVO;
                _loc_3.mIsTrackedMission = event.track;
            }
            this.mTrackingChanged = true;
            globalFlash.gui.mTrackedMissionList.Refresh();
            return;
        }// end function

        private function CreateInstantFinishTip(event:ToolTipEvent) : void
        {
            var _loc_2:* = this.mSelectedItem as dQuestElementVO;
            cToolTipUtil.createToolTip(cToolTipUtil.INSTANT_BUILD_string, event, _loc_2.mQuestDefinition.questWinGemCosts);
            return;
        }// end function

        private function DisplayQuest(param1:dQuestElementVO) : void
        {
            var _loc_2:int = 0;
            var _loc_7:dQuestDefinitionTriggerVO = null;
            var _loc_8:dQuestTriggerVO = null;
            var _loc_9:int = 0;
            var _loc_10:Object = null;
            var _loc_11:int = 0;
            this.mSelectedItem = param1;
            if (param1 == this.mPreselectedQuest)
            {
                this.mPanel.list.selectedItem = param1;
                this.mPreselectedQuest = null;
            }
            if (param1 == this.mNotificationQuest)
            {
                this.mPanel.list.selectedItem = param1;
                this.mNotificationQuest = null;
                globalFlash.gui.HideQuestNotification();
            }
            switch(param1.mQuestMode)
            {
                case QuestManagerStatic.QUEST_MODE_DEACTIVATED:
                case QuestManagerStatic.QUEST_MODE_REWARD_COLLECTED_IDLE:
                case QuestManagerStatic.QUEST_MODE_LOOP_UNTIL_QUEST_REWARD_COULD_BE_ASSIGNED:
                {
                    _loc_2 = MODE_DEACTIVATED;
                    break;
                }
                case QuestManagerStatic.QUEST_MODE_REWARD_WINDOW_WAIT_FOR_BUTTON_ACTIVE:
                {
                    _loc_2 = MODE_FINISHED;
                    break;
                }
                case QuestManagerStatic.QUEST_MODE_PENDING_NEXT_RANDOM_DAILY_QUEST:
                {
                    _loc_2 = MODE_PREVIEW;
                    break;
                }
                default:
                {
                    _loc_2 = MODE_RUNNING;
                    break;
                }
            }
            this.mPanel.rewardsTitle.visible = true;
            this.mPanel.rewardsList.visible = true;
            if (_loc_2 == MODE_FINISHED || _loc_2 == MODE_DEACTIVATED)
            {
                this.mPanel.rewardOrnamentalLeft.visible = true;
                this.mPanel.rewardOrnamentalRight.visible = true;
                this.mPanel.background.styleName = "rewardPanel";
                this.mPanel.backgroundFooter.styleName = "questPanelFooterReward";
            }
            else
            {
                this.mPanel.selectedIcon.source = gAssetManager.GetBitmap("QuestAdvisorMedium");
                this.mPanel.selectedIcon.visible = true;
                this.mPanel.background.styleName = "basicPanel";
                this.mPanel.backgroundFooter.styleName = "questPanelFooter";
            }
            this.mPanel.detailsHeadline.text = this.mLM.GetText(LOCA_GROUP.QUEST_LABELS, param1.mQuestName_string);
            if (_loc_2 == MODE_FINISHED || _loc_2 == MODE_DEACTIVATED)
            {
                this.mPanel.description.text = this.mLM.GetText(LOCA_GROUP.QUEST_REWARD_DESCRIPTIONS, param1.mQuestName_string);
            }
            else
            {
                this.mPanel.description.text = this.mLM.GetText(LOCA_GROUP.QUEST_START_DESCRIPTIONS, param1.mQuestName_string);
            }
            var _loc_3:* = new ArrayCollection();
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            while (_loc_5 < param1.mQuestDefinition.questTriggers_vector.length)
            {
                
                _loc_7 = param1.mQuestDefinition.questTriggers_vector[_loc_5];
                _loc_8 = param1.mQuestTriggersFinished_vector[_loc_5];
                if (_loc_7.type == QuestManagerStatic.TYPE_PAY_FOR_QUEST_FINISH)
                {
                    _loc_11 = _loc_7.amount - this.mGI.mCurrentPlayerZone.GetResources(this.mGI.mCurrentPlayer).GetPlayerResource(_loc_7.name_string).amount;
                    _loc_4++;
                }
                else
                {
                    _loc_11 = this.mGI.mQuestClientCallbacks.GetRemainingValuesForQuestTrigger(this.mGI.mCurrentPlayer, param1, _loc_5);
                }
                _loc_9 = this.mGI.mQuestClientCallbacks.GetTotalValuesForQuestTrigger(this.mGI.mCurrentPlayer, param1, _loc_5);
                _loc_10 = {definition:_loc_7, trigger:_loc_8, remaining:_loc_11, total:_loc_9};
                _loc_3.addItem(_loc_10);
                _loc_5++;
            }
            this.mPanel.triggers.dataProvider = _loc_3;
            this.mPanel.rewardsList.dataPovider = param1.mQuestDefinition.questReward;
            var _loc_6:* = param1.mQuestDefinition.questTyp == QuestManagerStatic.QUEST_TYPE_IS_IN_RANDOM_LIST_OF_DAILY_QUEST || _loc_4 > 0;
            if (_loc_2 == MODE_RUNNING && param1.mQuestDefinition.questWinGemCosts > 0)
            {
                this.mBtnInstantFinish.enabled = true;
                this.mPanel.footerButtons.addChild(this.mBtnInstantFinish);
            }
            if (_loc_2 == MODE_RUNNING && _loc_6)
            {
                this.mBtnFinishQuest.enabled = QuestManagerStatic.IsQuestReadyForSubmit(param1);
                this.mPanel.footerButtons.addChild(this.mBtnFinishQuest);
            }
            if (_loc_2 == MODE_RUNNING && param1.mQuestDefinition.questTyp == QuestManagerStatic.QUEST_TYPE_IS_IN_RANDOM_LIST_OF_DAILY_QUEST)
            {
                this.mBtnCancelQuest.enabled = true;
                this.mPanel.footerButtons.addChild(this.mBtnCancelQuest);
            }
            if (_loc_2 == MODE_FINISHED || _loc_2 == MODE_DEACTIVATED)
            {
                this.mBtnOK.enabled = true;
                this.mPanel.footerButtons.addChild(this.mBtnOK);
            }
            if (_loc_2 == MODE_RUNNING)
            {
                this.mGI.mQuestClientCallbacks.QuestOkButtonPressedFromGui(param1);
            }
            else if (_loc_2 == MODE_FINISHED || _loc_2 == MODE_DEACTIVATED)
            {
                cSoundManager.GetInstance().PlayEffect("BuffPlace");
                this.mPanel.sparkleAnim.visible = true;
                param1.mQuestMode = QuestManagerStatic.QUEST_MODE_REWARD_COLLECTED_IDLE;
                this.mPanel.list.removeItem(param1);
                if (_loc_2 == MODE_FINISHED)
                {
                    this.mGI.mQuestClientCallbacks.RewardOkButtonPressedFromGui(param1);
                }
            }
            return;
        }// end function

        private function DisplayNextItem(param1:Object = null) : void
        {
            var _loc_3:Object = null;
            var _loc_4:Object = null;
            this.Clear();
            var _loc_2:Object = null;
            for each (_loc_3 in this.mPanel.list.dataProvider)
            {
                
                for each (_loc_4 in _loc_3.data)
                {
                    
                    if (_loc_4 && _loc_4 != param1)
                    {
                        _loc_2 = _loc_4;
                    }
                    break;
                }
                if (_loc_2)
                {
                    break;
                }
            }
            if (_loc_2 is dQuestElementVO)
            {
                this.DisplayQuest(_loc_2 as dQuestElementVO);
            }
            else if (_loc_2 is dAdventureClientInfoVO)
            {
                this.DisplayAdventure(_loc_2 as dAdventureClientInfoVO);
            }
            return;
        }// end function

        override public function Hide() : void
        {
            this.SendTrackedMissionList();
            this.mPanel.sparkleAnim.visible = false;
            super.Hide();
            this.Clear();
            return;
        }// end function

        private function SendArmy(event:MouseEvent) : void
        {
            globalFlash.gui.mSpecialistTravelPanel.SetData((this.mSelectedItem as dAdventureClientInfoVO).zoneID);
            globalFlash.gui.mSpecialistTravelPanel.Show();
            return;
        }// end function

        private function FinishQuest(event:MouseEvent) : void
        {
            var _loc_3:dQuestDefinitionTriggerVO = null;
            var _loc_2:* = this.mSelectedItem as dQuestElementVO;
            this.Clear();
            for each (_loc_3 in _loc_2.mQuestDefinition.questTriggers_vector)
            {
                
                if (_loc_3.type == QuestManagerStatic.TYPE_PAY_FOR_QUEST_FINISH)
                {
                    this.mGI.mQuestClientCallbacks.InitiatePayForQuestFinish(_loc_2.mUniqueID);
                    break;
                }
            }
            _loc_2.mQuestMode = QuestManagerStatic.QUEST_MODE_REWARD_COLLECTED_IDLE;
            this.DisplayQuest(_loc_2);
            return;
        }// end function

        private function ConfirmCancelAdventure(event:MouseEvent) : void
        {
            CustomAlert.show(cLocaManager.GetInstance().GetText(LOCA_GROUP.ALERT_MESSAGES, "ConfirmCancelAdventure", [(this.mSelectedItem as dAdventureClientInfoVO).adventureName]), cLocaManager.GetInstance().GetText(LOCA_GROUP.ALERT_TITLES, "ConfirmCancelAdventure"), Alert.OK | Alert.CANCEL, null, this.CancelAdventure, null, 4, false);
            return;
        }// end function

        private function CancelQuest(event:CloseEvent) : void
        {
            if (event.detail != Alert.OK)
            {
                return;
            }
            var _loc_2:* = this.mSelectedItem as dQuestElementVO;
            this.mGI.mQuestClientCallbacks.CancelQuest(_loc_2.mUniqueID);
            _loc_2.mQuestMode = QuestManagerStatic.QUEST_MODE_DEACTIVATED;
            this.DisplayNextItem(_loc_2);
            this.mPanel.list.removeItem(_loc_2);
            return;
        }// end function

    }
}
