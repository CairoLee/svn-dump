package Communication.VO
{

    public class dResourceCreationVO extends Object
    {
        public var resourceCreationHouseGrid:int = 0;
        public var remove:Boolean;
        public var gatheredResource:int;
        public var protocollResourceCreationLastBuildingMode:int;
        public var productionState:int;
        public var assignedSettler:Boolean;
        public var depositBuildingGridPos:int;
        public var pathVO:dPathVO;
        public var resourceDefinitionID:int;
        public var playerId:int;
        public var settlerKIState:int;
        public var pathPos:int;
        public var protocollResourceCreationProcessCntr:int;

        public function dResourceCreationVO()
        {
            return;
        }// end function

        public function toString() : String
        {
            var _loc_1:* = "<ResourceCreationVO resourceDefinitionID=\'" + this.resourceDefinitionID + "\' resourceCreationHouseGrid=\'" + this.resourceCreationHouseGrid + "\' depositBuildingGridPos=\'" + this.depositBuildingGridPos + "\' pathPos=\'" + this.pathPos + "\' playerId=\'" + this.playerId + "\' gatheredResource=\'" + this.gatheredResource + "\' assignedSettler=\'" + this.assignedSettler + "\' settlerKIState=\'" + this.settlerKIState + "\' productionState=\'" + this.productionState + "\'  >\n";
            if (this.pathVO != null)
            {
                _loc_1 = _loc_1 + ("" + this.pathVO);
            }
            _loc_1 = _loc_1 + "</ResourceCreationVO>";
            return _loc_1;
        }// end function

    }
}
