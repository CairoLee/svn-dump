package Communication.VO
{
    import Interface.*;
    import NewQuestSystem.*;
    import mx.collections.*;

    public class dQuestPoolVO extends Object
    {
        public var mQuestVO_vector:ArrayCollection;

        public function dQuestPoolVO()
        {
            this.mQuestVO_vector = new ArrayCollection();
            return;
        }// end function

        public function IsTriggerAndConditionInAtLeastOneQuestAndQuestRunning(param1:int, param2:int) : dQuestDefinitionTriggerVO
        {
            var _loc_3:dQuestElementVO = null;
            var _loc_4:dQuestDefinitionTriggerVO = null;
            if (!QuestManagerStatic.IsActive())
            {
                return null;
            }
            for each (_loc_3 in this.mQuestVO_vector)
            {
                
                if (_loc_3.mQuestMode < QuestManagerStatic.QUEST_MODE_DEACTIVATED)
                {
                    _loc_4 = _loc_3.IsTriggerAndConditionInQuest(param1, param2);
                    if (_loc_4 != null)
                    {
                        return _loc_4;
                    }
                }
            }
            return null;
        }// end function

        public function AddQuest(param1:dQuestElementVO) : void
        {
            var _loc_3:dQuestElementVO = null;
            var _loc_2:int = 0;
            while (_loc_2 < this.mQuestVO_vector.length)
            {
                
                _loc_3 = this.mQuestVO_vector.getItemAt(_loc_2) as dQuestElementVO;
                if (param1.mQuestName_string == _loc_3.mQuestName_string)
                {
                    return;
                }
                _loc_2++;
            }
            this.mQuestVO_vector.addItem(param1);
            return;
        }// end function

        public function GetQuestFromUniqueID(param1:dUniqueID) : dQuestElementVO
        {
            var _loc_2:dQuestElementVO = null;
            for each (_loc_2 in this.mQuestVO_vector)
            {
                
                if (_loc_2.GetUniqueId().eq(param1))
                {
                    return _loc_2;
                }
            }
            return null;
        }// end function

        public function CheckQuestTrigger(param1:int, param2:int, param3:String, param4:cGeneralInterface) : void
        {
            var _loc_5:dQuestElementVO = null;
            for each (_loc_5 in this.mQuestVO_vector)
            {
                
                if (_loc_5.mQuestMode < QuestManagerStatic.QUEST_MODE_DEACTIVATED)
                {
                    _loc_5.CheckTriggerConditionName(param1, param2, param3);
                }
            }
            return;
        }// end function

        public function GetNofQuestsActive() : int
        {
            return this.mQuestVO_vector.length;
        }// end function

        public function IsQuestDefinitionInPool(param1:dQuestDefinitionVO) : Boolean
        {
            var _loc_2:dQuestElementVO = null;
            for each (_loc_2 in this.mQuestVO_vector)
            {
                
                if (_loc_2.mQuestDefinition == param1)
                {
                    return true;
                }
            }
            return false;
        }// end function

        public function RemoveAllQuests() : void
        {
            this.mQuestVO_vector.removeAll();
            return;
        }// end function

        public function IsQuestTriggerInAtLeastOneQuestValid(param1:int) : Boolean
        {
            var _loc_2:dQuestElementVO = null;
            if (!QuestManagerStatic.IsActive())
            {
                return false;
            }
            for each (_loc_2 in this.mQuestVO_vector)
            {
                
                if (_loc_2.IsQuestTriggerValid(param1))
                {
                    return true;
                }
            }
            return false;
        }// end function

        public function GetRunningQuestSeriesInPool(param1:String) : dQuestElementVO
        {
            var _loc_2:dQuestElementVO = null;
            for each (_loc_2 in this.mQuestVO_vector)
            {
                
                if (_loc_2.mQuestMode < QuestManagerStatic.QUEST_MODE_DEACTIVATED)
                {
                    if (_loc_2.mQuestName_string == param1)
                    {
                        return _loc_2;
                    }
                    if (QuestManagerStatic.CheckPreviousQuestDefinitionRecursiv(_loc_2.mQuestDefinition, param1))
                    {
                        return _loc_2;
                    }
                }
            }
            return null;
        }// end function

        public function IsTriggerInAtLeastOneQuestAndQuestRunning(param1:int) : Boolean
        {
            var _loc_2:dQuestElementVO = null;
            if (!QuestManagerStatic.IsActive())
            {
                return false;
            }
            for each (_loc_2 in this.mQuestVO_vector)
            {
                
                if (_loc_2.mQuestMode < QuestManagerStatic.QUEST_MODE_DEACTIVATED)
                {
                    if (_loc_2.IsTriggerInQuest(param1))
                    {
                        return true;
                    }
                }
            }
            return false;
        }// end function

        public function GetQuest_vector() : ArrayCollection
        {
            return this.mQuestVO_vector;
        }// end function

        public function IsAnyQuestsActive() : Boolean
        {
            return this.mQuestVO_vector.length > 0;
        }// end function

        public function GetQuestFromIndex(param1:int) : dQuestElementVO
        {
            return this.mQuestVO_vector.getItemAt(param1) as dQuestElementVO;
        }// end function

        public function RemoveQuest(param1:String) : void
        {
            var _loc_3:dQuestElementVO = null;
            var _loc_2:int = 0;
            while (_loc_2 < this.mQuestVO_vector.length)
            {
                
                _loc_3 = this.mQuestVO_vector.getItemAt(_loc_2) as dQuestElementVO;
                if (param1 == _loc_3.mQuestName_string)
                {
                    this.mQuestVO_vector.removeItemAt(_loc_2);
                    break;
                }
                _loc_2++;
            }
            return;
        }// end function

    }
}
