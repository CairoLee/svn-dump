package Communication.VO
{
    import Enums.*;
    import Interface.*;
    import NewQuestSystem.*;
    import ServerState.*;
    import flash.events.*;
    import mx.collections.*;
    import mx.events.*;
    import nLib.*;

    public class dQuestElementVO extends Object implements IEventDispatcher
    {
        private var _1812175400mSelected:Boolean = false;
        public var mQuestName_string:String;
        public var mRandomSeed:int;
        public var mDirtyIndicator:int;
        public var mQuestDefinition:dQuestDefinitionVO = null;
        public var mQuestMode:int;
        public var mQuestTriggersFinished_vector:ArrayCollection;
        public var mUniqueIDs_vector:ArrayCollection;
        private var _bindingEventDispatcher:EventDispatcher;
        public var mQuestWindowShowState:Boolean = false;
        public var mRewardTrials:int = 0;
        public var mRandomPosition:int;
        public var mUniqueID:dUniqueID;
        public var mLootItemsVO_vector:ArrayCollection;
        public var mLastBuildingUpgraded:String = null;
        public var mStartTime:Number;
        public var mRewardWindowShowState:Boolean = false;
        public var mQuestTriggersFinishedGuiRefreshCache_vector:ArrayCollection;
        public var mIsTrackedMission:Boolean = false;
        public var mOtherQuestDefinition_vector:ArrayCollection;

        public function dQuestElementVO()
        {
            this.mQuestTriggersFinished_vector = new ArrayCollection();
            this.mQuestTriggersFinishedGuiRefreshCache_vector = new ArrayCollection();
            this.mUniqueIDs_vector = new ArrayCollection();
            this.mLootItemsVO_vector = new ArrayCollection();
            this.mOtherQuestDefinition_vector = new ArrayCollection();
            this._bindingEventDispatcher = new EventDispatcher(IEventDispatcher(this));
            return;
        }// end function

        public function CheckGreaterEqualDeltaWin(param1:dQuestDefinitionTriggerVO, param2:int) : void
        {
            this.CheckCounterWin(param1, param2, QuestManagerStatic.CONDITION_GREATER_OR_EQUAL_DELTA);
            return;
        }// end function

        public function IsInFinishedState() : Boolean
        {
            return this.mQuestMode == QuestManagerStatic.QUEST_MODE_REWARD_WINDOW_WAIT_FOR_BUTTON_ACTIVE;
        }// end function

        public function GetQuestTriggersFinished_vector() : ArrayCollection
        {
            return this.mQuestTriggersFinished_vector;
        }// end function

        public function SetQuestMode(param1:int) : void
        {
            this.mQuestMode = param1;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function InitQuestFromSaveGame(param1:int, param2:dQuestDefinitionVO, param3:dQuestElementVO) : void
        {
            var _loc_4:dQuestTriggerVO = null;
            var _loc_5:dQuestTriggerVO = null;
            this.mUniqueID = param3.mUniqueID;
            this.mQuestDefinition = param2;
            this.mQuestName_string = param2.questName_string;
            this.mLastBuildingUpgraded = null;
            this.mQuestWindowShowState = param3.mQuestWindowShowState;
            this.mRewardWindowShowState = param3.mRewardWindowShowState;
            this.mIsTrackedMission = param3.mIsTrackedMission;
            this.mQuestMode = param3.mQuestMode;
            this.mStartTime = param3.mStartTime;
            this.mRandomSeed = param3.mRandomSeed;
            this.mRandomPosition = param3.mRandomPosition;
            this.CreateOtherQuestDefinition(param1);
            this.mQuestTriggersFinished_vector.removeAll();
            this.mQuestTriggersFinishedGuiRefreshCache_vector.removeAll();
            for each (_loc_4 in param3.mQuestTriggersFinished_vector)
            {
                
                this.mQuestTriggersFinished_vector.addItem(_loc_4);
                _loc_5 = new dQuestTriggerVO();
                _loc_5.deltaStart = _loc_4.deltaStart;
                _loc_5.status = _loc_4.status;
                this.mQuestTriggersFinishedGuiRefreshCache_vector.addItem(_loc_5);
            }
            return;
        }// end function

        public function IncreaseDeltaStart(param1:int, param2:Number) : void
        {
            this.mQuestTriggersFinished_vector[param1].deltaStart = this.mQuestTriggersFinished_vector[param1].deltaStart + param2;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.DATA_MODIFIED_BIT;
            return;
        }// end function

        public function willTrigger(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.willTrigger(param1);
        }// end function

        public function CreateOtherQuestDefinition(param1:int) : void
        {
            var _loc_2:dQuestDefinitionVO = null;
            var _loc_3:dQuestDefinitionVO = null;
            var _loc_4:dQuestDefinitionPostrequisitsVO = null;
            if (this.IsADailyLoginQuest())
            {
                _loc_2 = this.mQuestDefinition;
                while (true)
                {
                    
                    _loc_3 = null;
                    for each (_loc_4 in _loc_2.questPostrequisits)
                    {
                        
                        if (_loc_4.type == QuestManagerStatic.TYPE_STARTQUEST)
                        {
                            if (_loc_4.name_string != null)
                            {
                                _loc_3 = QuestManagerStatic.GetQuestFromName(param1, _loc_4.name_string);
                                break;
                            }
                            continue;
                        }
                        gMisc.Assert(false, "Error: Only StartQuest is allowed in Daily quest Postrequisits!" + _loc_4);
                    }
                    gMisc.Assert(_loc_3 != null, "Error: No Circular Quest Definition for daily Login");
                    if (_loc_3.questName_string == this.mQuestDefinition.questName_string)
                    {
                        break;
                    }
                    _loc_2 = _loc_3;
                    this.mOtherQuestDefinition_vector.addItem(_loc_2);
                }
            }
            return;
        }// end function

        public function GetQuestMode() : int
        {
            return this.mQuestMode;
        }// end function

        public function IsRunning() : Boolean
        {
            return this.mQuestMode == QuestManagerStatic.QUEST_MODE_RUNNING;
        }// end function

        public function hasEventListener(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.hasEventListener(param1);
        }// end function

        public function CheckGreaterEqualWin(param1:dQuestDefinitionTriggerVO, param2:int) : void
        {
            this.CheckCounterWin(param1, param2, QuestManagerStatic.CONDITION_GREATER_OR_EQUAL);
            return;
        }// end function

        public function SetTriggerWon(param1:int) : void
        {
            var _loc_2:* = global.ui;
            if (_loc_2 != null && _loc_2.mTriggerEffects != null && this.mQuestDefinition.questTriggers_vector[param1] != null)
            {
                _loc_2.mTriggerEffects.startOnCompleteEffects(this.mQuestDefinition.questTriggers_vector[param1]);
            }
            return;
        }// end function

        public function GetUniqueId() : dUniqueID
        {
            return this.mUniqueID;
        }// end function

        public function IsQuestModeAllowedForQuestList() : Boolean
        {
            if (!(this.mQuestMode == QuestManagerStatic.QUEST_MODE_RUNNING || this.mQuestMode == QuestManagerStatic.QUEST_MODE_START_WINDOW_DESCRIPTION_WAIT_FOR_BUTTON_PRESSED || this.mQuestMode == QuestManagerStatic.QUEST_MODE_PENDING_NEXT_RANDOM_DAILY_QUEST || this.mQuestMode == QuestManagerStatic.QUEST_MODE_REWARD_WINDOW_WAIT_FOR_BUTTON_ACTIVE))
            {
                return false;
            }
            if (this.mQuestDefinition.FindTriggerWithType(QuestManagerStatic.TYPE_DAILYLOGIN) != -1)
            {
                return false;
            }
            if (this.mQuestDefinition.FindTriggerWithType(QuestManagerStatic.TYPE_DAILYTIME) != -1)
            {
                return false;
            }
            return true;
        }// end function

        public function IsEqualTo(param1:dQuestElementVO) : Boolean
        {
            if (this.mUniqueID.uniqueID1 != param1.mUniqueID.uniqueID1 || this.mUniqueID.uniqueID2 != param1.mUniqueID.uniqueID2 || this.mQuestMode != param1.mQuestMode || this.mQuestName_string != param1.mQuestName_string)
            {
                return false;
            }
            return true;
        }// end function

        public function SetTriggerStatus(param1:int, param2:int) : void
        {
            this.mQuestTriggersFinished_vector[param1].status = param2;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.DATA_MODIFIED_BIT;
            return;
        }// end function

        public function IsTriggerAndConditionInQuest(param1:int, param2:int) : dQuestDefinitionTriggerVO
        {
            var _loc_3:dQuestDefinitionTriggerVO = null;
            var _loc_4:int = 0;
            for each (_loc_3 in this.mQuestDefinition.questTriggers_vector)
            {
                
                if (_loc_3.type == param1 && _loc_3.condition == param2)
                {
                    return _loc_3;
                }
                _loc_4++;
            }
            return null;
        }// end function

        public function SetUniqueId(param1:dUniqueID) : void
        {
            this.mUniqueID = param1;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.DATA_MODIFIED_BIT;
            return;
        }// end function

        public function GetRandomSeed() : int
        {
            return this.mRandomSeed;
        }// end function

        private function Log(param1:String) : void
        {
            return;
        }// end function

        public function GetTriggerStatus(param1:int) : int
        {
            return this.mQuestTriggersFinished_vector[param1].status;
        }// end function

        public function SetRandomSeed(param1:int) : void
        {
            this.mRandomSeed = param1;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function get mSelected() : Boolean
        {
            return this._1812175400mSelected;
        }// end function

        public function IsADailyLoginQuest() : Boolean
        {
            return this.mQuestDefinition.FindTriggerWithType(QuestManagerStatic.TYPE_DAILYLOGIN) != -1;
        }// end function

        public function removeEventListener(param1:String, param2:Function, param3:Boolean = false) : void
        {
            this._bindingEventDispatcher.removeEventListener(param1, param2, param3);
            return;
        }// end function

        public function GetQuestDefinition() : dQuestDefinitionVO
        {
            return this.mQuestDefinition;
        }// end function

        public function DeActivate() : void
        {
            return;
        }// end function

        public function IsATriggerConditionName(param1:int, param2:int, param3:String) : Boolean
        {
            var _loc_4:dQuestDefinitionTriggerVO = null;
            var _loc_5:int = 0;
            for each (_loc_4 in this.mQuestDefinition.questTriggers_vector)
            {
                
                if (_loc_4.type == param1 && _loc_4.condition == param2)
                {
                    if (_loc_4.name_string == param3 || _loc_4.name_string.length == 0)
                    {
                        return true;
                    }
                }
                _loc_5++;
            }
            return false;
        }// end function

        public function StartQuest() : void
        {
            if (this.GetQuestDefinition().showQuestWindow)
            {
                this.SetQuestMode(QuestManagerStatic.QUEST_MODE_SHOW_WINDOW_DESCRIPTION);
            }
            else
            {
                this.SetQuestMode(QuestManagerStatic.QUEST_MODE_RUNNING);
            }
            return;
        }// end function

        public function addEventListener(param1:String, param2:Function, param3:Boolean = false, param4:int = 0, param5:Boolean = false) : void
        {
            this._bindingEventDispatcher.addEventListener(param1, param2, param3, param4, param5);
            return;
        }// end function

        public function CheckTriggerCondition(param1:int, param2:int) : void
        {
            var _loc_3:dQuestDefinitionTriggerVO = null;
            if (!this.IsRunning())
            {
                return;
            }
            var _loc_4:int = 0;
            for each (_loc_3 in this.mQuestDefinition.questTriggers_vector)
            {
                
                if (_loc_3.type == param1 && _loc_3.condition == param2)
                {
                    this.SetTriggerWon(_loc_4);
                    return;
                }
                _loc_4++;
            }
            return;
        }// end function

        public function IsTriggerInQuest(param1:int) : Boolean
        {
            var _loc_2:dQuestDefinitionTriggerVO = null;
            for each (_loc_2 in this.mQuestDefinition.questTriggers_vector)
            {
                
                if (_loc_2.type == param1)
                {
                    return true;
                }
            }
            return false;
        }// end function

        public function dispatchEvent(event:Event) : Boolean
        {
            return this._bindingEventDispatcher.dispatchEvent(event);
        }// end function

        public function GetDeltaStart(param1:int) : Number
        {
            return this.mQuestTriggersFinished_vector[param1].deltaStart;
        }// end function

        public function SetAllTriggersToWon(param1:int) : void
        {
            var _loc_2:int = 0;
            while (_loc_2 < this.mQuestDefinition.questTriggers_vector.length)
            {
                
                if (this.mQuestDefinition.questTriggers_vector[_loc_2].type == param1)
                {
                    this.SetTriggerWon(_loc_2);
                }
                _loc_2++;
            }
            return;
        }// end function

        public function GetQuestStartTime() : Number
        {
            return this.mStartTime;
        }// end function

        public function CreateNewQuest(param1:cPlayerData, param2:dQuestDefinitionVO) : void
        {
            var _loc_3:int = 0;
            if (!QuestManagerStatic.IsActive())
            {
                return;
            }
            if (param2 == null)
            {
                return;
            }
            this.mQuestDefinition = param2;
            this.mQuestName_string = param2.questName_string;
            this.mQuestWindowShowState = false;
            this.mRewardWindowShowState = false;
            this.mUniqueID = param1.GetNewUniqueID();
            this.CreateOtherQuestDefinition(param1.GetPlayerId());
            this.ResetQuestFinishedTriggers(this.GetQuestDefinition().questTriggers_vector);
            this.StartQuest();
            if (param2.FindTriggerWithType(QuestManagerStatic.TYPE_DAILYTIME) != -1)
            {
                _loc_3 = gMisc.GetRandomMinMaxInt(1, 2147483647);
                this.SetRandomSeed(_loc_3);
            }
            this.mDirtyIndicator = DIRTY_INDICATOR.CREATED_BIT;
            return;
        }// end function

        public function CheckCounterWin(param1:dQuestDefinitionTriggerVO, param2:int, param3:int) : void
        {
            var _loc_4:int = 0;
            if (param1.condition == param3)
            {
                _loc_4 = this.GetDeltaStart(param2) as int;
                if (_loc_4 >= param1.amount)
                {
                    this.SetTriggerWon(param2);
                }
            }
            return;
        }// end function

        public function SetDeltaStart(param1:int, param2:Number) : void
        {
            this.mQuestTriggersFinished_vector[param1].deltaStart = param2;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.DATA_MODIFIED_BIT;
            return;
        }// end function

        public function SetRandomPosition(param1:int) : void
        {
            this.mRandomPosition = param1;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function ResetQuestFinishedTriggers(param1:ArrayCollection) : void
        {
            var _loc_2:dQuestDefinitionTriggerVO = null;
            var _loc_3:dQuestTriggerVO = null;
            var _loc_4:dQuestTriggerVO = null;
            this.mLastBuildingUpgraded = null;
            this.mQuestTriggersFinished_vector.removeAll();
            this.mQuestTriggersFinishedGuiRefreshCache_vector.removeAll();
            for each (_loc_2 in param1)
            {
                
                _loc_3 = new dQuestTriggerVO();
                _loc_3.status = 0;
                _loc_3.deltaStart = 0;
                this.mQuestTriggersFinished_vector.addItem(_loc_3);
                _loc_4 = new dQuestTriggerVO();
                _loc_4.status = 0;
                _loc_4.deltaStart = 0;
                this.mQuestTriggersFinishedGuiRefreshCache_vector.addItem(_loc_4);
            }
            return;
        }// end function

        public function SetTriggerFailed(param1:int) : void
        {
            this.mQuestTriggersFinished_vector[param1].status = -1;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.DATA_MODIFIED_BIT;
            return;
        }// end function

        public function ResetQuestFinishedTriggersRestartMode() : void
        {
            this.mLastBuildingUpgraded = null;
            var _loc_1:int = 0;
            while (_loc_1 < this.mQuestTriggersFinished_vector.length)
            {
                
                this.mQuestTriggersFinished_vector[_loc_1].status = 0;
                this.mQuestTriggersFinishedGuiRefreshCache_vector[_loc_1].status = 0;
                _loc_1++;
            }
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.DATA_MODIFIED_BIT;
            return;
        }// end function

        public function CheckTriggerConditionName(param1:int, param2:int, param3:String) : Boolean
        {
            var _loc_4:dQuestDefinitionTriggerVO = null;
            if (!this.IsRunning())
            {
                return false;
            }
            var _loc_5:int = 0;
            for each (_loc_4 in this.mQuestDefinition.questTriggers_vector)
            {
                
                if (_loc_4.type == param1 && _loc_4.condition == param2)
                {
                    if (_loc_4.name_string == param3 || _loc_4.name_string.length == 0)
                    {
                        this.SetTriggerWon(_loc_5);
                        return true;
                    }
                }
                _loc_5++;
            }
            return false;
        }// end function

        public function GetRandomPosition() : int
        {
            return this.mRandomPosition;
        }// end function

        public function toString() : String
        {
            var _loc_2:dQuestTriggerVO = null;
            var _loc_3:String = null;
            var _loc_1:String = "";
            for each (_loc_2 in this.mQuestTriggersFinished_vector)
            {
                
                if (_loc_1 != "")
                {
                    _loc_1 = _loc_1 + ",";
                }
                _loc_1 = _loc_1 + _loc_2;
            }
            _loc_3 = "<QuestVO mQuestDefinition=\'" + this.mQuestDefinition + "\' activeQuest=\'" + this.mQuestName_string + "\' questMode=\'" + this.mQuestMode + "\' startTime=\'" + this.mStartTime + "\' randomSeed=\'" + this.mRandomSeed + "\' randomPosition=\'" + this.mRandomPosition + "\' mQuestWindowShowState=\'" + this.mQuestWindowShowState + "\' mRewardWindowShowState=\'" + this.mRewardWindowShowState + "\' mQuestTriggersFinished=\'" + _loc_1 + "\' />\n";
            return _loc_3;
        }// end function

        public function IsQuestTriggerValid(param1:int) : Boolean
        {
            if (param1 == QuestManagerStatic.SERVER_STACK_REWARD_BUTTON_OK)
            {
                if (this.GetQuestMode() != QuestManagerStatic.QUEST_MODE_REWARD_WINDOW_WAIT_FOR_BUTTON_ACTIVE)
                {
                    return false;
                }
            }
            return true;
        }// end function

        public function set mSelected(param1:Boolean) : void
        {
            var _loc_2:* = this._1812175400mSelected;
            if (_loc_2 !== param1)
            {
                this._1812175400mSelected = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mSelected", _loc_2, param1));
            }
            return;
        }// end function

        public function SetQuestStartTime(param1:Number) : void
        {
            this.mStartTime = param1;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function IsActive() : Boolean
        {
            return this.mQuestDefinition != null;
        }// end function

    }
}
