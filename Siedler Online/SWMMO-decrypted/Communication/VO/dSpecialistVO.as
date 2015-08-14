package Communication.VO
{
    import Enums.*;

    public class dSpecialistVO extends Object
    {
        public var task:dSpecialistTaskVO;
        public var diceBonus:int;
        public var specialistType:int;
        public var buildingsDestroyed:int;
        public var battlesWon:int;
        public var xpProduced:int;
        public var currentHitPoints:int;
        public var unitsDefeated:int;
        public var retreatThreshold:int;
        public var armyVO:dArmyVO;
        public var uniqueID:dUniqueID;
        public var garrisonBuildingGridPos:int;
        public var xp:int;
        public var playerID:int;
        public var faceType:int;

        public function dSpecialistVO()
        {
            this.armyVO = new dArmyVO();
            return;
        }// end function

        public function toString() : String
        {
            var _loc_1:* = "<dSpecialistVO type=\'" + SPECIALIST_TYPE.toString(this.specialistType) + "\'";
            _loc_1 = _loc_1 + (" currentHitPoints=\'" + this.currentHitPoints + "\'");
            _loc_1 = _loc_1 + (" uniqueId=\'" + this.uniqueID + "\'");
            _loc_1 = _loc_1 + (" playerId=\'" + this.playerID + "\'");
            _loc_1 = _loc_1 + (" faceType=\'" + this.faceType + "\'");
            _loc_1 = _loc_1 + (" xp=\'" + this.xp + "\'");
            _loc_1 = _loc_1 + (" diceBonus=\'" + this.diceBonus + "\'");
            _loc_1 = _loc_1 + (" retreatThreshold=\'" + this.retreatThreshold + "\'");
            _loc_1 = _loc_1 + (" task=\'" + this.task + "\'");
            _loc_1 = _loc_1 + (" garrisonBuildingGridPos=\'" + this.garrisonBuildingGridPos + "\'");
            _loc_1 = _loc_1 + (" xpProduced=\'" + this.xpProduced + "\'");
            _loc_1 = _loc_1 + (" battlesWon=\'" + this.battlesWon + "\'");
            _loc_1 = _loc_1 + (" unitsDefeated=\'" + this.unitsDefeated + "\'");
            _loc_1 = _loc_1 + (" buildingsDestroyed=\'" + this.buildingsDestroyed + "\'");
            _loc_1 = _loc_1 + " >";
            if (this.task != null)
            {
                _loc_1 = _loc_1 + ("\n" + this.task);
            }
            _loc_1 = _loc_1 + ("\n" + this.armyVO);
            _loc_1 = _loc_1 + "</dSpecialistVO>";
            return _loc_1;
        }// end function

    }
}
