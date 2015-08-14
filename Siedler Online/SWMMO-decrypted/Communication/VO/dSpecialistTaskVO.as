package Communication.VO
{
    import Enums.*;

    public class dSpecialistTaskVO extends Object
    {
        public var bonusTime:int;
        public var collectedTime:int;
        public var type:int;
        public var phase:int;

        public function dSpecialistTaskVO()
        {
            return;
        }// end function

        public function dataString() : String
        {
            return " type=\'" + this.type + "\' typeString=\'" + SPECIALIST_TASK_TYPES.toString(this.type) + "\' phase=\'" + this.phase + "\' collectedTime=\'" + this.collectedTime + "\' bonusTime=\'" + this.bonusTime + "\'";
        }// end function

        public function toString() : String
        {
            var _loc_1:String = "<dSpecialistTaskVO ";
            _loc_1 = _loc_1 + this.dataString();
            _loc_1 = _loc_1 + " />";
            return _loc_1;
        }// end function

    }
}
