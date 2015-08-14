package Communication.VO
{
    import Communication.VO.UpdateVO.*;

    public class dSpecialistTask_ExploreSectorVO extends dSpecialistTaskVO
    {
        public var exploredSectorId:int;
        public var exploredSectorDataVO:dExploredSectorDataVO;

        public function dSpecialistTask_ExploreSectorVO()
        {
            return;
        }// end function

        override public function toString() : String
        {
            return "<dSpecialistTaskVO " + super.dataString() + " exploredSectorId=\'" + this.exploredSectorId + "\' exploredSectorDataVO=\'" + this.exploredSectorDataVO + "\' />";
        }// end function

    }
}
