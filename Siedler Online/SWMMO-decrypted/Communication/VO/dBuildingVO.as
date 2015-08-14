package Communication.VO
{
    import GO.*;
    import mx.collections.*;

    public class dBuildingVO extends Object
    {
        public var buffs:ArrayCollection;
        public var buildingProgress:int = 0;
        public var recurringBuffVO:dBuffVO;
        public var startWorkCounter:int = 0;
        public var upgradeStartTime:Number = 0;
        public var armyVO:dArmyVO;
        public var buildingGrid:int;
        public var destructionTime:Number = 0;
        public var buildingCreationTime:Number = 0;
        public var initialSetOnXMLMap:Boolean;
        public var offsetX:int;
        public var offsetY:int;
        public var lastRepairTime:Number = 0;
        public var upgradeIsInProgress:Boolean;
        public var isEngagedInCombat:Boolean;
        public var isBought:Boolean;
        public var playerID:int;
        public var upgradeLevel:int = 0;
        public var hitPoints:int = 0;
        public var origin:int;
        public var upgradeProgress:int = 0;
        public var buildingName_string:String = null;
        public var isProductionActive:Boolean;
        public var buildingMode:int = 0;
        public var recoveringHitPoints:int = 0;

        public function dBuildingVO()
        {
            this.armyVO = new dArmyVO();
            this.buffs = new ArrayCollection();
            return;
        }// end function

        public function toString() : String
        {
            var _loc_3:dBuffApplianceVO = null;
            var _loc_1:String = "<dBuildingVO \n";
            _loc_1 = _loc_1 + (" playerID=\'" + this.playerID + "\'\n");
            _loc_1 = _loc_1 + (" buildingCreationTime=\'" + this.buildingCreationTime + "\'\n");
            _loc_1 = _loc_1 + (" buildingName_string=\'" + this.buildingName_string + "\'\n");
            _loc_1 = _loc_1 + (" buildingGrid=\'" + this.buildingGrid + "\'\n");
            _loc_1 = _loc_1 + (" buildingMode=\'" + this.buildingMode + "\'\n");
            _loc_1 = _loc_1 + (" buildingModeString=\'" + cBuilding.GetBuildingModeString(this.buildingMode) + "\'\n");
            _loc_1 = _loc_1 + (" startWorkCounter=\'" + this.startWorkCounter + "\'\n");
            _loc_1 = _loc_1 + (" upgradeLevel=\'" + this.upgradeLevel + "\'\n");
            _loc_1 = _loc_1 + (" hitPoints=\'" + this.hitPoints + "\'\n");
            _loc_1 = _loc_1 + (" lastRepairTime=\'" + this.lastRepairTime + "\'\n");
            _loc_1 = _loc_1 + (" recoveringHitPoints=\'" + this.recoveringHitPoints + "\'\n");
            _loc_1 = _loc_1 + (" initialSetOnXMLMap=\'" + this.initialSetOnXMLMap + "\'\n");
            _loc_1 = _loc_1 + (" isBought=\'" + this.isBought + "\'\n");
            _loc_1 = _loc_1 + (" isProductionActive=\'" + this.isProductionActive + "\'\n");
            _loc_1 = _loc_1 + (" buildingProgress=\'" + this.buildingProgress + "\'\n");
            _loc_1 = _loc_1 + (" upgradeIsInProgress=\'" + this.upgradeIsInProgress + "\'\n");
            _loc_1 = _loc_1 + (" upgradeStartTime=\'" + this.upgradeStartTime + "\'\n");
            _loc_1 = _loc_1 + (" upgradeProgress=\'" + this.upgradeProgress + "\'\n");
            _loc_1 = _loc_1 + (" destructionTime=\'" + this.destructionTime + "\'\n");
            _loc_1 = _loc_1 + (" offsetX=\'" + this.offsetX + "\'\n");
            _loc_1 = _loc_1 + (" offsetY=\'" + this.offsetY + "\'\n");
            _loc_1 = _loc_1 + (" origin=\'" + this.origin + "\'\n");
            _loc_1 = _loc_1 + (" isEngagedInCombat=\'" + this.isEngagedInCombat + "\'\n");
            _loc_1 = _loc_1 + ">\n";
            _loc_1 = _loc_1 + (this.armyVO + "\n");
            var _loc_2:String = "  <dBuffAppliancess>\n";
            for each (_loc_3 in this.buffs)
            {
                
                _loc_2 = _loc_2 + ("    " + _loc_3.toString() + "\n");
            }
            _loc_1 = _loc_1 + " <RecurringBuff>\n";
            if (this.recurringBuffVO != null)
            {
                _loc_1 = _loc_1 + ("  " + this.recurringBuffVO + " \n");
            }
            _loc_1 = _loc_1 + " </RecurringBuff>\n";
            _loc_1 = _loc_1 + "</dBuildingVO>";
            return _loc_1;
        }// end function

    }
}
