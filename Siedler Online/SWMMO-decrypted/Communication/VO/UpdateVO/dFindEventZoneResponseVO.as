package Communication.VO.UpdateVO
{
    import Communication.VO.*;

    public class dFindEventZoneResponseVO extends Object
    {
        public var eventZonePlayerID:int;
        public var adventureName_string:String;
        public var specialistUniqueId:dUniqueID;
        public var buffUniqueID:dUniqueID;

        public function dFindEventZoneResponseVO()
        {
            return;
        }// end function

        public function toString() : String
        {
            return "<dFindEventZoneResponseVO specialistUniqueId=\'" + this.specialistUniqueId + " adventureName=\'" + this.adventureName_string + "\' eventZonePlayerID=\'" + this.eventZonePlayerID + "\', buffUniqueID=" + this.buffUniqueID + " />";
        }// end function

    }
}
