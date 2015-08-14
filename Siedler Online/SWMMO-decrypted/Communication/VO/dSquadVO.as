package Communication.VO
{
    import MilitarySystem.*;

    public class dSquadVO extends Object
    {
        public var name_string:String;
        public var type_int:int;
        protected var militaryUnitDescription:cMilitaryUnitDescription;
        public var mTotalHealth:int = 0;
        public var amount:int;
        protected var currentHitPoints:int;

        public function dSquadVO()
        {
            return;
        }// end function

        public function GetType_string() : String
        {
            return this.name_string;
        }// end function

        public function GetCurrentHitPoints() : int
        {
            return this.currentHitPoints;
        }// end function

        public function GetType_Int() : int
        {
            this.type_int = this.militaryUnitDescription.GetType_Int();
            return this.type_int;
        }// end function

        public function GetUnitDescription() : cMilitaryUnitDescription
        {
            return this.militaryUnitDescription;
        }// end function

        public function GetAmount() : int
        {
            return this.amount;
        }// end function

        public function init(param1:String, param2:int, param3:int) : dSquadVO
        {
            this.amount = param2;
            this.currentHitPoints = param3;
            this.name_string = param1;
            this.militaryUnitDescription = cMilitaryUnitDescription.GetUnitDescriptionForType(param1);
            return this;
        }// end function

        public function SetCurrentHitPoints(param1:int) : void
        {
            this.currentHitPoints = param1;
            return;
        }// end function

    }
}
