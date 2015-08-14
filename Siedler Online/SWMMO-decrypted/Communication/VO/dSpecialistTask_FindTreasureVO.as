package Communication.VO
{
    import Communication.VO.UpdateVO.*;

    public class dSpecialistTask_FindTreasureVO extends dSpecialistTaskVO
    {
        public var findTreasureResponseVO:dFindTreasureResponseVO;

        public function dSpecialistTask_FindTreasureVO()
        {
            return;
        }// end function

        override public function toString() : String
        {
            return "<dSpecialistTask_FindTreasureVO " + super.dataString() + " findTreasureResponseVO=\'" + this.findTreasureResponseVO + "\' />";
        }// end function

    }
}
