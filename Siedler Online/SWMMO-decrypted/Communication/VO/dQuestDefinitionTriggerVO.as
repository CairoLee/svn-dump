package Communication.VO
{
    import NewQuestSystem.*;

    public class dQuestDefinitionTriggerVO extends Object
    {
        public var name_string:String;
        public var locaExtension_string:String;
        public var cachedDate:Number;
        public var amount:int;
        public var type:int;
        public var condition:int;
        public var onComplete:String;

        public function dQuestDefinitionTriggerVO()
        {
            return;
        }// end function

        public function toString() : String
        {
            var _loc_1:* = QuestManagerStatic.ConvertTypeToString(this.type);
            var _loc_2:* = QuestManagerStatic.GetConditionString(this.condition);
            return _loc_1 + (_loc_2 != "unset" ? ("_" + _loc_2) : ("")) + (this.name_string != "" ? ("_" + this.name_string) : ("")) + (this.locaExtension_string != "" ? ("_" + this.locaExtension_string) : (""));
        }// end function

    }
}
