package Communication.VO
{
    import mx.collections.*;

    public class dQuestDefinitionRewardVO extends Object
    {
        public var type:int;
        public var name_string:String;
        public var amount:int;
        public var rewardTriggers:ArrayCollection;

        public function dQuestDefinitionRewardVO()
        {
            return;
        }// end function

        public function toString() : String
        {
            var _loc_2:dQuestDefinitionTriggerVO = null;
            var _loc_1:* = "<dQuestDefinitionRewardVO type=\'" + this.type + "\' name_string=\'" + this.name_string + "\' amount=\'" + this.amount;
            if (this.rewardTriggers.length > 0)
            {
                _loc_1 = _loc_1 + "\'>";
                for each (_loc_2 in this.rewardTriggers)
                {
                    
                    _loc_1 = _loc_1 + ("\t<Trigger amount=\'" + _loc_2.amount + "\' cachedDate=\'" + _loc_2.cachedDate + "\' condition=\'" + _loc_2.condition + " name=\'" + _loc_2.name_string + " type=\'" + _loc_2.type + "\'/>\n");
                }
                _loc_1 = _loc_1 + "</dQuestDefinitionRewardVO>\n";
            }
            else
            {
                _loc_1 = _loc_1 + "/>\n";
            }
            return _loc_1;
        }// end function

    }
}
