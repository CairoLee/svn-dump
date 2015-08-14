package Communication.VO
{
    import mx.collections.*;

    public class dZoneVO extends Object
    {
        public var zoneVisitorPlayerID:int;
        public var activateProduction:Boolean = false;
        public var resourceCreations:ArrayCollection;
        public var buffProduction_vector:ArrayCollection;
        public var depositGroups:ArrayCollection;
        public var deposits:ArrayCollection;
        public var map_PlayerID_Army:Object;
        public var resourcesVO:dResourcesVO;
        public var landscapes:ArrayCollection;
        public var lastGameTickRefreshTime:Number;
        public var freeLandscapes:ArrayCollection;
        public var questPool:dQuestPoolVO = null;
        public var activeQuestOldQuestSystem:dQuestVO = null;
        public var questFileName:String;
        public var questDefinitionContainer:dQuestDefinitionContainerVO;
        public var mapValues:ArrayCollection;
        public var landingFields:ArrayCollection;
        public var gameTickCommands_vector:ArrayCollection;
        public var adventureName:String;
        public var serverTime:Number;
        public var specialists_vector:ArrayCollection;
        public var militaryUnitRecruitments_vector:ArrayCollection;
        public var zoneMapName:String;
        public var zoneOwnerPlayerID:int;
        public var buildQueue:dBuildQueueVO;
        public var sectors:ArrayCollection;
        public var buildings:ArrayCollection;
        public var streets:ArrayCollection;
        public var dataTracking_vector:ArrayCollection;
        public var gameTickRefreshCounter:int;
        public var depositQualities:ArrayCollection;
        public var playersOnMap:ArrayCollection;
        public var backgroundTiles:ArrayCollection;

        public function dZoneVO()
        {
            this.buildings = new ArrayCollection();
            this.sectors = new ArrayCollection();
            this.landscapes = new ArrayCollection();
            this.freeLandscapes = new ArrayCollection();
            this.deposits = new ArrayCollection();
            this.depositGroups = new ArrayCollection();
            this.depositQualities = new ArrayCollection();
            this.streets = new ArrayCollection();
            this.resourceCreations = new ArrayCollection();
            this.backgroundTiles = new ArrayCollection();
            this.playersOnMap = new ArrayCollection();
            this.mapValues = new ArrayCollection();
            this.landingFields = new ArrayCollection();
            this.map_PlayerID_Army = new Object();
            this.militaryUnitRecruitments_vector = new ArrayCollection();
            this.buffProduction_vector = new ArrayCollection();
            this.gameTickCommands_vector = new ArrayCollection();
            this.specialists_vector = new ArrayCollection();
            this.dataTracking_vector = new ArrayCollection();
            this.buildQueue = new dBuildQueueVO();
            return;
        }// end function

        public function isPlayerOnMap(param1:int) : Boolean
        {
            var _loc_2:dPlayerVO = null;
            for each (_loc_2 in this.playersOnMap)
            {
                
                if (_loc_2.userID == param1)
                {
                    return true;
                }
            }
            return false;
        }// end function

        public function toString() : String
        {
            var _loc_2:dMapValueItemVO = null;
            var _loc_1:* = "<ZoneVO zoneVisitorPlayerID=\'" + this.zoneVisitorPlayerID + "\' zoneOwnerPlayerID=\'" + this.zoneOwnerPlayerID + "\' serverTime=\'" + this.serverTime + "\' lastGameTickRefreshTime=\'" + this.lastGameTickRefreshTime + "\' gameTickRefreshCounter=\'" + this.gameTickRefreshCounter + "\'>\n";
            _loc_1 = _loc_1 + gCalculations.createListString("Buildings", this.buildings);
            _loc_1 = _loc_1 + gCalculations.createListString("Sectors", this.sectors);
            _loc_1 = _loc_1 + gCalculations.createListString("Landscapes", this.landscapes);
            _loc_1 = _loc_1 + gCalculations.createListString("Deposits", this.deposits);
            _loc_1 = _loc_1 + gCalculations.createListString("DepositGroups", this.depositGroups);
            _loc_1 = _loc_1 + gCalculations.createListString("DepositQualities", this.depositQualities);
            _loc_1 = _loc_1 + gCalculations.createListString("Streets", this.streets);
            _loc_1 = _loc_1 + gCalculations.createListString("ResourceCreations", this.resourceCreations);
            _loc_1 = _loc_1 + gCalculations.createListString("BackgroundTiles", this.backgroundTiles);
            _loc_1 = _loc_1 + gCalculations.createListString("Players", this.playersOnMap);
            _loc_1 = _loc_1 + ("<MapValues count=\'" + this.mapValues.length + "\' list=\'");
            for each (_loc_2 in this.mapValues)
            {
                
                _loc_1 = _loc_1 + (_loc_2.mBackgroundBlocking + "," + 0 + "," + _loc_2.mSectorId + ",");
            }
            _loc_1 = _loc_1 + "\'/>\n";
            _loc_1 = _loc_1 + this.map_PlayerID_Army;
            _loc_1 = _loc_1 + gCalculations.createListString("MilitaryUnitRecruitments_vector", this.militaryUnitRecruitments_vector);
            _loc_1 = _loc_1 + gCalculations.createListString("BuffProduction_vector", this.buffProduction_vector);
            _loc_1 = _loc_1 + gCalculations.createListString("GameTickCommands_vector", this.gameTickCommands_vector);
            _loc_1 = _loc_1 + gCalculations.createListString("Specialists", this.specialists_vector);
            _loc_1 = _loc_1 + gCalculations.createListString("DataTracking", this.dataTracking_vector);
            _loc_1 = _loc_1 + ("\n" + this.buildQueue);
            _loc_1 = _loc_1 + "</ZoneVO>\n";
            return _loc_1;
        }// end function

    }
}
