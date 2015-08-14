package GUI.GAME
{
    import Communication.VO.*;
    import Communication.VO.UpdateVO.*;
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import Interface.*;
    import NewQuestSystem.*;
    import Sound.*;
    import flash.events.*;
    import mx.collections.*;
    import mx.controls.*;
    import nLib.*;

    public class cDailyLoginPanel extends cBasicPanel
    {
        private var mGI:cGameInterface;
        private var mCurrentQuest:dQuestElementVO;
        protected var mPanel:DailyLoginPanel;

        public function cDailyLoginPanel()
        {
            return;
        }// end function

        override public function Hide() : void
        {
            globalFlash.gui.mDarkenPanel.Hide();
            super.Hide();
            return;
        }// end function

        private function SortQuestChain(param1:ArrayCollection, param2:dQuestDefinitionVO) : ArrayCollection
        {
            var _loc_5:dQuestDefinitionVO = null;
            var _loc_7:int = 0;
            var _loc_3:* = new ArrayCollection();
            var _loc_4:String = null;
            var _loc_6:* = new ArrayCollection();
            new ArrayCollection().addItem(param2);
            for each (_loc_5 in param1)
            {
                
                _loc_6.addItem(_loc_5);
            }
            _loc_7 = _loc_6.length;
            for each (_loc_5 in _loc_6)
            {
                
                if (_loc_5.specialType_string == QuestManagerStatic.SPECIAL_TYPE_FIRST_DAILY_QUEST)
                {
                    _loc_6.removeItemAt(_loc_6.getItemIndex(_loc_5));
                    _loc_3.addItem(_loc_5);
                    _loc_4 = (_loc_5.questPostrequisits.getItemAt(0) as dQuestDefinitionPostrequisitsVO).name_string;
                    break;
                }
            }
            gMisc.Assert(_loc_4 != null, "First Daily Quest not found specialType=\'firstDailyQuest\' is missing");
            while (_loc_3.length < _loc_7)
            {
                
                for each (_loc_5 in _loc_6)
                {
                    
                    if (_loc_5.questName_string == _loc_4)
                    {
                        _loc_6.removeItemAt(_loc_6.getItemIndex(_loc_5));
                        _loc_3.addItem(_loc_5);
                        _loc_4 = (_loc_5.questPostrequisits.getItemAt(0) as dQuestDefinitionPostrequisitsVO).name_string;
                        break;
                    }
                }
            }
            return _loc_3;
        }// end function

        private function Accept(event:MouseEvent) : void
        {
            this.mGI.mQuestClientCallbacks.RewardOkButtonPressedFromGui(this.mCurrentQuest);
            cSoundManager.GetInstance().PlayEffect("MenuClose");
            this.Hide();
            return;
        }// end function

        public function SetData(param1:dQuestElementVO, param2:int) : void
        {
            var _loc_3:Frame = null;
            var _loc_4:Label = null;
            var _loc_5:dQuestDefinitionVO = null;
            var _loc_6:dQuestDefinitionVO = null;
            var _loc_7:ArrayCollection = null;
            var _loc_8:int = 0;
            var _loc_9:int = 0;
            this.mCurrentQuest = param1;
            this.mPanel.label = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "DailyLoginReward");
            this.mPanel.description.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "DailyLoginReward");
            for each (_loc_3 in this.mPanel.rewardsList.getChildren())
            {
                
                _loc_3.Clear();
            }
            for each (_loc_4 in this.mPanel.daysLabels.getChildren())
            {
                
                _loc_4.setStyle("fontWeight", "normal");
            }
            _loc_5 = param1.mQuestDefinition;
            _loc_6 = null;
            _loc_7 = param1.mOtherQuestDefinition_vector;
            _loc_7 = this.SortQuestChain(_loc_7, _loc_5);
            _loc_8 = 1;
            while (_loc_8 <= _loc_7.length)
            {
                
                if (_loc_7.getItemAt((_loc_8 - 1)) == _loc_5)
                {
                    break;
                }
                _loc_8++;
            }
            _loc_6 = _loc_7.getItemAt((_loc_7.length - 1)) as dQuestDefinitionVO;
            if (param2 > 0)
            {
                if (_loc_8 + param2)
                {
                    _loc_9 = 1;
                    while (_loc_9 <= _loc_7.length)
                    {
                        
                        if (_loc_9 < _loc_8)
                        {
                            this.mPanel["day" + _loc_9 + "result"].visible = true;
                            this.mPanel["day" + _loc_9 + "result"].source = gAssetManager.GetBitmap("DailyLoginPassed");
                            this.mPanel["day" + _loc_9].type = Frame.DAILY_LOGIN;
                        }
                        else
                        {
                            if (_loc_9 < _loc_8 + param2 - 1)
                            {
                                this.mPanel["day" + _loc_9].type = Frame.DAILY_LOGIN;
                            }
                            this.mPanel["day" + _loc_9 + "result"].visible = true;
                            this.mPanel["day" + _loc_9 + "result"].source = gAssetManager.GetBitmap("DailyLoginFailed");
                        }
                        _loc_9++;
                    }
                }
                if (_loc_8 + param2 - 1 <= _loc_7.length)
                {
                    this.mPanel["day" + (_loc_8 + param2 - 1) + "label"].setStyle("fontWeight", "bold");
                    this.mPanel["day" + (_loc_8 + param2 - 1)].type = Frame.BUFF_TIMED;
                }
                this.mPanel.daysRemaining.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "DailyLoginFailed");
            }
            else
            {
                _loc_9 = 1;
                while (_loc_9 <= _loc_7.length)
                {
                    
                    if (_loc_9 < _loc_8)
                    {
                        this.mPanel["day" + _loc_9 + "result"].visible = true;
                        this.mPanel["day" + _loc_9 + "result"].source = gAssetManager.GetBitmap("DailyLoginPassed");
                        this.mPanel["day" + _loc_9].type = Frame.DAILY_LOGIN;
                    }
                    else if (_loc_9 > _loc_8 && _loc_9 != _loc_7.length)
                    {
                        this.mPanel["day" + _loc_9 + "result"].visible = true;
                        this.mPanel["day" + _loc_9 + "result"].source = gAssetManager.GetBitmap("DailyLoginQuestionMark");
                    }
                    else
                    {
                        this.mPanel["day" + _loc_9 + "result"].visible = false;
                    }
                    _loc_9++;
                }
                this.mPanel["day" + _loc_8 + "label"].setStyle("fontWeight", "bold");
                if (param1.mLootItemsVO_vector.length > 0)
                {
                    this.DisplayLootReward("day" + _loc_8, param1.mLootItemsVO_vector[0], Frame.BUFF_TIMED);
                }
                else
                {
                    this.DisplayReward("day" + _loc_8, _loc_5.questReward.getItemAt(0) as dQuestDefinitionRewardVO, Frame.BUFF_TIMED);
                }
                this.DisplayReward("day" + _loc_7.length, _loc_6.questReward.getItemAt(0) as dQuestDefinitionRewardVO, Frame.DAILY_LOGIN_LAST);
                this.mPanel.daysRemaining.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "DailyLoginRemainingDays", [_loc_8.toString(), this.mPanel["day" + _loc_8].amount.toString(), this.mPanel["day" + _loc_8].content]);
            }
            return;
        }// end function

        public function Init(param1:DailyLoginPanel) : void
        {
            this.mGI = global.ui as cGameInterface;
            openSound = "";
            AddBaseElement(param1);
            this.mPanel = param1;
            this.mPanel.btnOK.addEventListener(MouseEvent.CLICK, this.Accept);
            return;
        }// end function

        private function DisplayReward(param1:String, param2:dQuestDefinitionRewardVO, param3:String = "empty") : void
        {
            var _loc_4:* = this.mPanel[param1] as Frame;
            (this.mPanel[param1] as Frame).type = param3;
            var _loc_5:int = 0;
            switch(param2.type)
            {
                case QuestManagerStatic.TYPE_XP:
                {
                    _loc_5 = _loc_5 + param2.amount;
                    _loc_4.contentType = Frame.CONTENT_TYPE_RESOURCE;
                    _loc_4.amount = param2.amount;
                    _loc_4.content = "XP";
                    _loc_4.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, "XP");
                    break;
                }
                case QuestManagerStatic.TYPE_RESOURCE:
                {
                    _loc_4.contentType = Frame.CONTENT_TYPE_RESOURCE;
                    _loc_4.amount = param2.amount;
                    _loc_4.content = param2.name_string;
                    _loc_4.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, param2.name_string);
                    break;
                }
                case QuestManagerStatic.TYPE_ADVENTURE:
                {
                    _loc_4.contentType = Frame.CONTENT_TYPE_ADVENTURE;
                    _loc_4.content = param2.name_string;
                    _loc_4.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.ADVENTURE_NAME, param2.name_string);
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

        private function DisplayLootReward(param1:String, param2:dLootItemsVO, param3:String = "empty") : void
        {
            var _loc_6:dBuffVO = null;
            var _loc_7:String = null;
            var _loc_8:dSpecialistVO = null;
            var _loc_9:dResourceVO = null;
            var _loc_4:* = this.mPanel[param1] as Frame;
            (this.mPanel[param1] as Frame).type = param3;
            var _loc_5:* = param2.items[0];
            if (param2.items[0] is dBuffVO)
            {
                _loc_6 = _loc_5 as dBuffVO;
                _loc_7 = _loc_6.resourceName_string == "" ? (_loc_6.buffName_string) : (_loc_6.resourceName_string);
                _loc_4.contentType = Frame.CONTENT_TYPE_RESOURCE;
                _loc_4.content = _loc_7;
                _loc_4.amount = _loc_6.amount;
                _loc_4.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, _loc_7);
            }
            else if (_loc_5 is dSpecialistVO)
            {
                _loc_8 = _loc_5 as dSpecialistVO;
                _loc_4.contentType = Frame.CONTENT_TYPE_NORMAL;
                _loc_4.content = SPECIALIST_TYPE.toString(_loc_8.specialistType);
                _loc_4.amount = 1;
                _loc_4.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.SPECIALISTS, SPECIALIST_TYPE.toString(_loc_8.specialistType));
            }
            else if (_loc_5 is dResourceVO)
            {
                _loc_9 = _loc_5 as dResourceVO;
                _loc_4.contentType = Frame.CONTENT_TYPE_RESOURCE;
                _loc_4.content = _loc_9.name_string;
                _loc_4.amount = _loc_9.amount;
                _loc_4.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, _loc_9.name_string);
            }
            else
            {
                gMisc.Assert(false, "Could not interpret item " + _loc_5 + " for a loot item!");
            }
            return;
        }// end function

        private function ClosePanel(event:Event) : void
        {
            this.Hide();
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
