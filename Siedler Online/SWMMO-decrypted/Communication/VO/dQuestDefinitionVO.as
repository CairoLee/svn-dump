package Communication.VO
{
    import NewQuestSystem.*;
    import mx.collections.*;

    public class dQuestDefinitionVO extends Object
    {
        public var questName_string:String;
        public var questTriggers_vector:ArrayCollection;
        public var questTyp:int;
        public var questHints:ArrayCollection;
        public var colorSchema_string:String;
        public var dailyMotherQuest:dQuestDefinitionVO = null;
        public var showRewardWindow:Boolean;
        public var previousQuestDefinition:dQuestDefinitionVO;
        public var questPostrequisits:ArrayCollection;
        public var questReward:ArrayCollection;
        public var showQuestWindow:Boolean;
        public var questWinGemCosts:int;
        public var specialType_string:String;

        public function dQuestDefinitionVO()
        {
            this.questTyp = QuestManagerStatic.QUEST_TYPE_DEFAULT;
            return;
        }// end function

        public function FindTriggerWithType(param1:int) : int
        {
            var _loc_3:dQuestDefinitionTriggerVO = null;
            var _loc_2:int = 0;
            while (_loc_2 < this.questTriggers_vector.length)
            {
                
                _loc_3 = this.questTriggers_vector[_loc_2];
                if (_loc_3.type == param1)
                {
                    return _loc_2;
                }
                _loc_2++;
            }
            return -1;
        }// end function

    }
}
