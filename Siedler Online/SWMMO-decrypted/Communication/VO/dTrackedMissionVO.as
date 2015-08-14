package Communication.VO
{

    public class dTrackedMissionVO extends Object
    {
        public var id1:int;
        public var id2:int;
        public var missionType:int;

        public function dTrackedMissionVO()
        {
            return;
        }// end function

        public function init(param1:int, param2:int, param3:int) : dTrackedMissionVO
        {
            this.missionType = param1;
            this.id1 = param2;
            this.id2 = param3;
            return this;
        }// end function

    }
}
