package Communication.VO
{
    import Communication.VO.UpdateVO.*;

    public class dSpecialistTask_FindEventZoneVO extends dSpecialistTaskVO
    {
        public var findEventZoneResponseVO:dFindEventZoneResponseVO;

        public function dSpecialistTask_FindEventZoneVO()
        {
            return;
        }// end function

        override public function toString() : String
        {
            return "<dSpecialistTask_FindEventZoneVO " + super.dataString() + " findEventZoneResponseVO=\'" + this.findEventZoneResponseVO + "\' />";
        }// end function

    }
}
