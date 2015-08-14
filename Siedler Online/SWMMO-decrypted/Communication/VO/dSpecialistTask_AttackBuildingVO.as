package Communication.VO
{
    import Communication.VO.UpdateVO.*;

    public class dSpecialistTask_AttackBuildingVO extends dSpecialistTaskVO
    {
        public var armyDestinationBuildingGridPos:int;
        public var battleReport_string:String;
        public var targetBuildingGridPos:int;
        public var startingArmySize:int;
        public var battleResultVO:dBattleResultVO;
        public var pathPos:int;
        public var battleScript_string:String;
        public var lastRound:Number;
        public var attackBuildingMode:int;

        public function dSpecialistTask_AttackBuildingVO()
        {
            return;
        }// end function

        override public function toString() : String
        {
            var _loc_1:String = "<dSpecialistTask_AttackBuildingVO ";
            _loc_1 = _loc_1 + super.dataString();
            _loc_1 = _loc_1 + (" targetBuildingGridPos=\'" + this.targetBuildingGridPos);
            _loc_1 = _loc_1 + ("\' armyDestinationBuildingGridPos=\'" + this.armyDestinationBuildingGridPos);
            _loc_1 = _loc_1 + ("\' startingArmySize=\'" + this.startingArmySize);
            _loc_1 = _loc_1 + ("\' lastRound=\'" + this.lastRound);
            _loc_1 = _loc_1 + ("\' pathPos=\'" + this.pathPos);
            _loc_1 = _loc_1 + ("\' attackBuildingMode=\'" + this.attackBuildingMode);
            _loc_1 = _loc_1 + ("\' battleReport=\'" + this.battleReport_string);
            _loc_1 = _loc_1 + ("\' battleScript=\'" + this.battleScript_string);
            _loc_1 = _loc_1 + ("\' battleResultVO=\'" + this.battleResultVO);
            _loc_1 = _loc_1 + "\' />";
            return _loc_1;
        }// end function

    }
}
