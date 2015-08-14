package Communication.VO
{
    import mx.collections.*;

    public class dQuestVO extends Object
    {
        public var questWindowShowState:Boolean = false;
        public var startQuestTime:Number;
        public var questTriggersFinished:ArrayCollection;
        public var activeQuest_string:String;
        public var rewardWindowShowState:Boolean = false;
        public var activeQuestMode:int;

        public function dQuestVO()
        {
            return;
        }// end function

        public function toString() : String
        {
            var _loc_2:int = 0;
            var _loc_3:String = null;
            var _loc_1:String = "";
            for each (_loc_2 in this.questTriggersFinished)
            {
                
                if (_loc_1 != "")
                {
                    _loc_1 = _loc_1 + ",";
                }
                _loc_1 = _loc_1 + _loc_2;
            }
            _loc_3 = "<QuestVO activeQuest=\'" + this.activeQuest_string + "\' activeQuestMode=\'" + this.activeQuestMode + "\' startQuestTime=\'" + this.startQuestTime + "\' questWindowShowState=\'" + this.questWindowShowState + "\' rewardWindowShowState=\'" + this.rewardWindowShowState + "\' questTriggersFinished=\'" + _loc_1 + "\' />\n";
            return _loc_3;
        }// end function

    }
}
