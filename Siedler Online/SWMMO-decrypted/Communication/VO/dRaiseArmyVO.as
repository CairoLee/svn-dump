package Communication.VO
{
    import mx.collections.*;

    public class dRaiseArmyVO extends Object
    {
        public var armyHolderSpecialistVO:dSpecialistVO = null;
        public var unitSquads:ArrayCollection;
        public var armyHolderBuildingVO:dBuildingVO = null;

        public function dRaiseArmyVO()
        {
            this.unitSquads = new ArrayCollection();
            return;
        }// end function

        public function toString() : String
        {
            var _loc_1:* = "<RaiseArmyVO armyHolderBuildingVO=\'" + this.armyHolderBuildingVO + "\' armyHolderSpecialistVO=\'" + this.armyHolderSpecialistVO.uniqueID + "\' >\n";
            _loc_1 = _loc_1 + gCalculations.createListString("Squads", this.unitSquads);
            _loc_1 = _loc_1 + "</RaiseArmyVO>";
            return _loc_1;
        }// end function

    }
}
