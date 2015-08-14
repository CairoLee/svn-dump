package NewQuestSystem
{
    import BuffSystem.*;
    import Communication.VO.*;
    import Enums.*;
    import Interface.*;
    import ServerState.*;
    import __AS3__.vec.*;
    import flash.utils.*;
    import nLib.*;

    public class QuestManagerStatic extends Object
    {
        public static const TYPE_SECTOR:int = 5;
        public static const QUEST_UPDATE_SET_HINT_DATA:int = 3;
        public static const QUEST_UPDATE_ADVENTURE_WON:int = 2;
        private static const TRIGGER_NAME_ALL_EXPLORERS:String = "AllExplorers";
        private static var mActivateQuestSystem:Boolean = true;
        public static const TYPE_DAILYLOGIN:int = 13;
        public static const TYPE_BUILDING:int = 1;
        public static const QUEST_UPDATE_PAY_FOR_QUEST:int = 14;
        public static const TYPE_XP:int = 3;
        public static const CONDITION_GREATER_OR_EQUAL_DELTA:int = 14;
        public static const CONDITION_SELL:int = 18;
        public static const NOQUEST_ACTIVE_TEXT:String = "no quest active";
        public static const CONDITION_BUY:int = 17;
        public static const TYPE_ADVENTURE:int = 10;
        public static const TYPE_RANDOM_QUEST_LIST:int = 15;
        public static const QUEST_MODE_REWARD_COLLECTED_IDLE:int = 11;
        private static var mTypeDictionary:cStringIntDictionary = new cStringIntDictionary();
        public static const TYPE_BUFF:int = 8;
        public static const CONDITION_GREATER_OR_EQUAL:int = 3;
        public static const TYPE_PAY_FOR_QUEST_FINISH:int = 18;
        public static const QUEST_MODE_PENDING_NEXT_RANDOM_DAILY_QUEST:int = 9;
        public static const TYPE_BUFF_BY_FRIEND:int = 17;
        private static var mType_vector:Vector.<String> = new Vector.<String>;
        public static var mQuestContainer_map:Dictionary = new Dictionary();
        public static const SERVER_STACK_PAY_FOR_QUEST_FINISH:int = 5;
        public static const QUEST_MODE_REWARD_WINDOW_WAIT_FOR_BUTTON_ACTIVE:int = 5;
        public static const QUEST_TYPE_DAILY_QUEST:int = 3;
        public static const TYPE_SPECIALIST:int = 6;
        public static const SERVER_STACK_GET_LATEST_QUEST_LIST:int = 4;
        public static const SPECIAL_TYPE_LAST_QUEST:String = "lastQuest";
        public static const SERVER_STACK_JUST_REFRESH:int = 3;
        public static const CONDITION_FOUND_DEPOSIT:int = 10;
        public static const QUEST_TYPE_DAILY_LOGIN_QUEST:int = 2;
        public static const CONDITION_SELECTED:int = 9;
        public static const CONDITION_ASSIGNED_UNITS:int = 7;
        public static const CONDITION_LESS:int = 12;
        public static const QUEST_MODE_RUNNING:int = 3;
        public static const QUEST_MODE_SHOW_WINDOW_DESCRIPTION:int = 7;
        public static const SERVER_STACK_REWARD_BUTTON_OK:int = 1;
        public static const TYPE_RESOURCE:int = 2;
        private static var mCondition_vector:Vector.<String> = new Vector.<String>;
        public static const SPECIAL_TYPE_FIRST_DAILY_QUEST:String = "firstDailyQuest";
        public static const QUEST_MODE_START_DELAY:int = 6;
        public static const CONDITION_CLAIMED:int = 6;
        public static const QUEST_TYPE_DEFAULT:int = 0;
        public static const ACTIVATE_LOGS:Boolean = false;
        public static const CONDITION_PRODUCE:int = 15;
        public static const TYPE_FRIENDS:int = 19;
        public static const TYPE_DAILYTIME:int = 12;
        public static const QUEST_TYPE_IS_IN_RANDOM_LIST_OF_DAILY_QUEST:int = 1;
        private static const TRIGGER_NAME_ALL_GEOLOGISTS:String = "AllGeologists";
        public static const QUEST_MODE_PRESS_REWARD_BUTTON:int = 8;
        public static const CONDITION_CREATED:int = 2;
        public static const TYPE_LOOT:int = 11;
        public static const CONDITION_UPGRADED:int = 8;
        public static const CONDITION_CONSUME:int = 16;
        public static const CONDITION_USED:int = 11;
        public static const TYPE_BUILDINGS_WITH_UNITS:int = 9;
        public static const QUEST_UPDATE_APPLY_REWARD_EFFECTS:int = 1;
        private static var mConditionDictionary:cStringIntDictionary = new cStringIntDictionary();
        public static const TYPE_PLAYERLEVEL:int = 4;
        public static const QUEST_MODE_START_WINDOW_DESCRIPTION_WAIT_FOR_BUTTON_PRESSED:int = 2;
        public static const SERVER_STACK_CANCEL_QUEST:int = 6;
        public static const SERVER_STACK_BUILDING_SELECTED:int = 2;
        public static const SPECIAL_TYPE_FIRST_QUEST:String = "firstQuest";
        public static const TYPE_BUFF_ON_FRIEND:int = 16;
        public static const CONDITION_ONMAP:int = 1;
        public static const CONDITION_DESTROYED:int = 4;
        public static const QUEST_MODE_INIT_REWARD_WINDOW:int = 4;
        public static const TYPE_UNSET:int = 0;
        public static const CONDITION_UNSET:int = 0;
        public static const CONDITION_ONMAP_VISITOR:int = 13;
        public static const ACTIVATE_SIMPLE_LOGS:Boolean = true;
        public static const QUEST_UPDATE_HIDE_QUEST_WINDOW:int = 12;
        public static const QUEST_MODE_LOOP_UNTIL_QUEST_REWARD_COULD_BE_ASSIGNED:int = 1;
        public static const QUEST_UPDATE_QUEST_TRIGGER_CHANGED:int = 13;
        private static const TRIGGER_NAME_ALL_GENERALS:String = "AllGenerals";
        public static const TYPE_STARTQUEST:int = 14;
        public static const QUEST_MODE_DEACTIVATED:int = 10;
        public static const CONDITION_EXPLORED:int = 5;
        public static const TYPE_MILITARYUNIT:int = 7;
        public static const QUEST_UPDATE_REFRESH_QUEST_LIST:int = 10;
        public static const SERVER_STACK_QUEST_BUTTON_OK:int = 0;
        public static const QUEST_UPDATE_SHOW_QUEST_WINDOW:int = 11;

        public function QuestManagerStatic()
        {
            return;
        }// end function

        public static function GetQuestModeString(param1:int) : String
        {
            switch(param1)
            {
                case QUEST_MODE_START_WINDOW_DESCRIPTION_WAIT_FOR_BUTTON_PRESSED:
                {
                    return "QuestWindowWaitForButtonPressed";
                }
                case QUEST_MODE_RUNNING:
                {
                    return "Running";
                }
                case QUEST_MODE_INIT_REWARD_WINDOW:
                {
                    return "InitRewardWindow";
                }
                case QUEST_MODE_REWARD_WINDOW_WAIT_FOR_BUTTON_ACTIVE:
                {
                    return "RewardWindowWaitForButtonActive";
                }
                case QUEST_MODE_START_DELAY:
                {
                    return "StartDelay";
                }
                case QUEST_MODE_SHOW_WINDOW_DESCRIPTION:
                {
                    return "QUEST_MODE_SHOW_WINDOW_DESCRIPTION";
                }
                case QUEST_MODE_DEACTIVATED:
                {
                    return "QUEST_MODE_DEACTIVATED";
                }
                case QUEST_MODE_REWARD_COLLECTED_IDLE:
                {
                    return "Finished!";
                }
                case QUEST_MODE_PENDING_NEXT_RANDOM_DAILY_QUEST:
                {
                    return "QUEST_MODE_PENDING_NEXT_RANDOM_DAILY_QUEST";
                }
                default:
                {
                    return "Unknown: " + param1;
                    continue;
                }
            }
        }// end function

        private static function InitDictionaries() : void
        {
            mTypeDictionary.Reset();
            mType_vector.length = 0;
            AddToTypDictionary("Unset");
            AddToTypDictionary("Building");
            AddToTypDictionary("Resource");
            AddToTypDictionary("XP");
            AddToTypDictionary("PlayerLevel");
            AddToTypDictionary("Sector");
            AddToTypDictionary("Specialist");
            AddToTypDictionary("MilitaryUnit");
            AddToTypDictionary("Buff");
            AddToTypDictionary("BuildingsWithUnits");
            AddToTypDictionary("Adventure");
            AddToTypDictionary("Loot");
            AddToTypDictionary("DailyTime");
            AddToTypDictionary("DailyLogin");
            AddToTypDictionary("StartQuest");
            AddToTypDictionary("RandomQuestList");
            AddToTypDictionary("BuffOnFriend");
            AddToTypDictionary("BuffByFriend");
            AddToTypDictionary("PayForQuestFinish");
            AddToTypDictionary("Friends");
            mConditionDictionary.Reset();
            mCondition_vector.length = 0;
            AddToConditionDictionary("unset");
            AddToConditionDictionary("onMap");
            AddToConditionDictionary("created");
            AddToConditionDictionary("ge");
            AddToConditionDictionary("destroyed");
            AddToConditionDictionary("explored");
            AddToConditionDictionary("claimed");
            AddToConditionDictionary("assignedUnits");
            AddToConditionDictionary("upgraded");
            AddToConditionDictionary("selected");
            AddToConditionDictionary("foundDeposit");
            AddToConditionDictionary("used");
            AddToConditionDictionary("l");
            AddToConditionDictionary("onMapVisitor");
            AddToConditionDictionary("geDelta");
            AddToConditionDictionary("produce");
            AddToConditionDictionary("consume");
            AddToConditionDictionary("buy");
            AddToConditionDictionary("sell");
            return;
        }// end function

        public static function GetConditionString(param1:int) : String
        {
            return mCondition_vector[param1];
        }// end function

        private static function AddToTypDictionary(param1:String) : void
        {
            mTypeDictionary.Put(param1, mType_vector.length);
            mType_vector.push(param1);
            return;
        }// end function

        public static function ConvertTypeToString(param1:int) : String
        {
            if (param1 >= 0 && param1 < mType_vector.length)
            {
                return mType_vector[param1];
            }
            return "<unknown Type>";
        }// end function

        public static function Init() : void
        {
            InitDictionaries();
            return;
        }// end function

        public static function ConvertStringToType(param1:String) : int
        {
            return mTypeDictionary.Get(param1);
        }// end function

        public static function GetQuestInfo(param1:dQuestDefinitionVO) : String
        {
            if (param1 != null)
            {
                return "{" + param1.questName_string + "}";
            }
            return " {null}";
        }// end function

        public static function ConvertConditionToString(param1:int) : String
        {
            if (param1 >= 0 && param1 < mCondition_vector.length)
            {
                return mCondition_vector[param1];
            }
            return "<unknown condition>";
        }// end function

        public static function GetQuestTypeString(param1:int) : String
        {
            switch(param1)
            {
                case QUEST_TYPE_DEFAULT:
                {
                    return "default";
                }
                case QUEST_TYPE_IS_IN_RANDOM_LIST_OF_DAILY_QUEST:
                {
                    return "Is in random List of a Daily Quest";
                }
                case QUEST_TYPE_DAILY_LOGIN_QUEST:
                {
                    return "Daily Login Quest";
                }
                case QUEST_TYPE_DAILY_QUEST:
                {
                    return "Daily Quest";
                }
                default:
                {
                    return "Unknown: " + param1;
                    continue;
                }
            }
        }// end function

        public static function GetQuestRewardString(param1:int) : String
        {
            return mType_vector[param1];
        }// end function

        private static function AddToConditionDictionary(param1:String) : void
        {
            mConditionDictionary.Put(param1, mCondition_vector.length);
            mCondition_vector.push(param1);
            return;
        }// end function

        public static function CheckPreviousQuestDefinitionRecursiv(param1:dQuestDefinitionVO, param2:String) : Boolean
        {
            if (param1.previousQuestDefinition != null)
            {
                if (param1.previousQuestDefinition.questName_string == param2)
                {
                    return true;
                }
                if (CheckPreviousQuestDefinitionRecursiv(param1.previousQuestDefinition, param2))
                {
                    return true;
                }
            }
            return false;
        }// end function

        public static function IsQuestReadyForSubmit(param1:dQuestElementVO) : Boolean
        {
            var _loc_4:dQuestDefinitionTriggerVO = null;
            var _loc_5:dQuestTriggerVO = null;
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            while (_loc_3 < param1.mQuestDefinition.questTriggers_vector.length)
            {
                
                _loc_4 = param1.mQuestDefinition.questTriggers_vector[_loc_3];
                _loc_5 = param1.mQuestTriggersFinished_vector[_loc_3];
                switch(_loc_4.type)
                {
                    case QuestManagerStatic.TYPE_PAY_FOR_QUEST_FINISH:
                    {
                        if (global.ui.mCurrentPlayerZone.GetResources(global.ui.mCurrentPlayer).HasPlayerResource(_loc_4.name_string, _loc_4.amount))
                        {
                            _loc_2++;
                        }
                        break;
                    }
                    default:
                    {
                        if (_loc_5.status > 0)
                        {
                            _loc_2++;
                        }
                        break;
                    }
                }
                _loc_3++;
            }
            return _loc_2 == param1.mQuestDefinition.questTriggers_vector.length;
        }// end function

        public static function GetAmountOfSpecialistsForTriggerName(param1:cGeneralInterface, param2:int, param3:String) : int
        {
            gMisc.Assert(param3 != null, "GetAmountOfSpecialistsForTriggerName(): _triggerName must not be null!");
            var _loc_4:int = 0;
            if (param3 == TRIGGER_NAME_ALL_GENERALS)
            {
                _loc_4 = param1.mCurrentPlayerZone.GetAmountOfBaseSpecialists(param2, SPECIALIST_TYPE.GENERAL);
            }
            else if (param3 == TRIGGER_NAME_ALL_EXPLORERS)
            {
                _loc_4 = param1.mCurrentPlayerZone.GetAmountOfBaseSpecialists(param2, SPECIALIST_TYPE.EXPLORER);
            }
            else if (param3 == TRIGGER_NAME_ALL_GEOLOGISTS)
            {
                _loc_4 = param1.mCurrentPlayerZone.GetAmountOfBaseSpecialists(param2, SPECIALIST_TYPE.GEOLOGIST);
            }
            else
            {
                _loc_4 = param1.mCurrentPlayerZone.GetAmountOfSpecialists(param2, SPECIALIST_TYPE.parse(param3));
            }
            return _loc_4;
        }// end function

        public static function GetRandomQuest(param1:dQuestDefinitionPostrequisitsVO) : dQuestDefinitionPostrequisitsVO
        {
            var _loc_2:* = gMisc.GetRandomMinMax(0, (param1.postrequisits_vector.length - 1)) as int;
            return param1.postrequisits_vector[_loc_2];
        }// end function

        public static function ConvertStringToCondition(param1:String) : int
        {
            return mConditionDictionary.Get(param1);
        }// end function

        public static function ApplyRewardEffects(param1:cGeneralInterface, param2:dQuestElementVO, param3:cPlayerData) : void
        {
            var _loc_5:dQuestDefinitionRewardVO = null;
            var _loc_6:cResources = null;
            var _loc_7:dResource = null;
            var _loc_8:int = 0;
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            var _loc_11:dUniqueID = null;
            var _loc_12:dBuffVO = null;
            var _loc_13:dUniqueID = null;
            var _loc_14:cBuff = null;
            var _loc_15:int = 0;
            var _loc_4:* = param2.mQuestDefinition;
            for each (_loc_5 in _loc_4.questReward)
            {
                
                if (gLog.isInfoEnabled(LOG_TYPE.QUEST))
                {
                    gLog.logInfo(LOG_TYPE.QUEST, "QuestReward achieved for Quest : " + param2.mQuestName_string + " Reward :" + _loc_5);
                }
                switch(_loc_5.type)
                {
                    case QuestManagerStatic.TYPE_RESOURCE:
                    {
                        _loc_6 = param1.mCurrentPlayerZone.GetResources(param3);
                        _loc_7 = _loc_6.GetPlayerResource(_loc_5.name_string);
                        _loc_8 = _loc_7.maxLimit - _loc_7.amount;
                        if (_loc_5.amount <= _loc_8)
                        {
                            _loc_9 = _loc_5.amount;
                        }
                        else
                        {
                            _loc_9 = _loc_8;
                            globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.QUEST_REWARD_LIMIT_REACHED, new dResource().Init(_loc_5.name_string, _loc_5.amount));
                            _loc_12 = new dBuffVO();
                            _loc_12.buffName_string = "AddResource";
                            _loc_12.amount = _loc_5.amount - _loc_9;
                            _loc_12.remaining = _loc_12.amount;
                            _loc_12.resourceName_string = _loc_5.name_string;
                            _loc_13 = param2.mUniqueIDs_vector.getItemAt(0) as dUniqueID;
                            param2.mUniqueIDs_vector.removeItemAt(0);
                            _loc_12.uniqueId1 = _loc_13.uniqueID1;
                            _loc_12.uniqueId2 = _loc_13.uniqueID2;
                            _loc_14 = cBuff.CreateBuffFromVO(_loc_12);
                            param1.mCurrentPlayer.mAvailableBuffs_vector.push(_loc_14);
                        }
                        _loc_6.AddResource(_loc_5.name_string, _loc_9);
                        break;
                    }
                    case QuestManagerStatic.TYPE_XP:
                    {
                        param3.AddXP(int(_loc_5.amount));
                        break;
                    }
                    case QuestManagerStatic.TYPE_SPECIALIST:
                    {
                        _loc_10 = SPECIALIST_TYPE.parse(_loc_5.name_string);
                        _loc_11 = new dUniqueID();
                        _loc_11.uniqueID1 = gMisc.GetMaxIntValue() - 10000;
                        _loc_11.uniqueID2 = gMisc.GetMaxIntValue() - 10000;
                        _loc_15 = 0;
                        while (_loc_15 < _loc_4.questName_string.length)
                        {
                            
                            _loc_11.uniqueID2 = _loc_11.uniqueID2 + _loc_4.questName_string.charCodeAt(_loc_15);
                            _loc_15++;
                        }
                        (param1 as cGameInterface).BuySpecialistDirect(param3, _loc_10, _loc_11, false);
                        break;
                    }
                    case QuestManagerStatic.TYPE_MILITARYUNIT:
                    {
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
            param1.RefreshGui();
            return;
        }// end function

        public static function GetQuestFromName(param1:int, param2:String) : dQuestDefinitionVO
        {
            var _loc_4:dQuestDefinitionVO = null;
            var _loc_3:* = QuestManagerStatic.mQuestContainer_map[param1];
            for each (_loc_4 in _loc_3.questDefinitions)
            {
                
                if (_loc_4.questName_string == param2)
                {
                    return _loc_4;
                }
            }
            return null;
        }// end function

        public static function PreApplyRewardEffects(param1:cGeneralInterface, param2:dQuestElementVO, param3:cPlayerData) : void
        {
            return;
        }// end function

        public static function IsActive() : Boolean
        {
            return mActivateQuestSystem;
        }// end function

    }
}
