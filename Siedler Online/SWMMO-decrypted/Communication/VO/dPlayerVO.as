package Communication.VO
{
    import Communication.VO.Guild.*;
    import Enums.*;
    import Interface.*;
    import Map.*;
    import mx.collections.*;

    public class dPlayerVO extends Object
    {
        public var generalsAmount:int;
        public var zoneID:int;
        public var purchasedShopItems_vector:ArrayCollection;
        public var currentMaximumBuildingsCountAll:int;
        public var availableBuffs_vector:ArrayCollection;
        public var explorersAmount:int;
        public var logActions:Boolean;
        public var avatarId:int;
        public var cityLevel:int;
        public var username_string:String;
        public var logType:int;
        public var logLevel:int;
        public var playerLevel:int;
        public var resources:ArrayCollection;
        public var userID:int;
        public var canCheat:Boolean;
        public var uniqueID:dUniqueID;
        public var permanentBuildQueueSlotsCount:int = 0;
        public var availableTempSlots_vector:ArrayCollection;
        public var guildVO:dGuildVO;
        public var xp:int;
        public var geologistsAmount:int;
        public var discoveredSectors:ArrayCollection;

        public function dPlayerVO()
        {
            this.resources = new ArrayCollection();
            this.discoveredSectors = new ArrayCollection();
            this.availableBuffs_vector = new ArrayCollection();
            this.purchasedShopItems_vector = new ArrayCollection();
            this.availableTempSlots_vector = new ArrayCollection();
            return;
        }// end function

        public function toString() : String
        {
            var _loc_2:dResourceVO = null;
            var _loc_3:dSectorDiscoveryVO = null;
            var _loc_4:dBuffVO = null;
            var _loc_5:dPurchasedShopItemVO = null;
            var _loc_6:dTempBuildSlotVO = null;
            var _loc_1:* = "<PlayerVO username=\'" + this.username_string + "\' userID=\'" + this.userID + "\' zoneID=\'" + this.zoneID + "\' xp=\'" + this.xp + "\' cityLevel=\'" + this.cityLevel + "\' playerLevel=\'" + this.playerLevel + "\' avatarId=\'" + this.avatarId + "\' uniqueID=\'" + this.uniqueID + "\' canCheat=\'" + this.canCheat + "\' generalsAmount=\'" + this.generalsAmount + "\' explorersAmount=\'" + this.explorersAmount + "\' geologistsAmount=\'" + this.geologistsAmount + "\' currentMaximumBuildingsCountAll=\'" + this.currentMaximumBuildingsCountAll + "\' >\n";
            _loc_1 = _loc_1 + "  <Resources>\n";
            if (this.resources != null)
            {
                for each (_loc_2 in this.resources)
                {
                    
                    _loc_1 = _loc_1 + ("    " + _loc_2 + "\n");
                }
            }
            _loc_1 = _loc_1 + "  </Resources>\n";
            _loc_1 = _loc_1 + "  <DiscoveredSectors>\n";
            if (this.discoveredSectors != null)
            {
                for each (_loc_3 in this.discoveredSectors)
                {
                    
                    _loc_1 = _loc_1 + ("    " + _loc_3 + "\n");
                }
            }
            _loc_1 = _loc_1 + "  </DiscoveredSectors>\n";
            _loc_1 = _loc_1 + "  <AvailableBuffs>\n";
            if (this.availableBuffs_vector != null)
            {
                for each (_loc_4 in this.availableBuffs_vector)
                {
                    
                    _loc_1 = _loc_1 + ("    " + _loc_4 + "\n");
                }
            }
            _loc_1 = _loc_1 + "  </AvailableBuffs>\n";
            _loc_1 = _loc_1 + "  <PurchasedShopItems>\n";
            if (this.purchasedShopItems_vector != null)
            {
                for each (_loc_5 in this.purchasedShopItems_vector)
                {
                    
                    _loc_1 = _loc_1 + ("    " + _loc_5 + "\n");
                }
            }
            _loc_1 = _loc_1 + "  </PurchasedShopItems>\n";
            _loc_1 = _loc_1 + "  <AvailableTempSlots>\n";
            if (this.availableTempSlots_vector != null)
            {
                for each (_loc_6 in this.availableTempSlots_vector)
                {
                    
                    _loc_1 = _loc_1 + ("    " + _loc_6 + "\n");
                }
            }
            _loc_1 = _loc_1 + "  </AvailableTempSlots>\n";
            _loc_1 = _loc_1 + "</PlayerVO>\n";
            return _loc_1;
        }// end function

        public static function CreateVisitorPlayer(param1:cGeneralInterface, param2:int) : dPlayerVO
        {
            var _loc_4:cSector = null;
            var _loc_5:dSectorDiscoveryVO = null;
            var _loc_3:* = new dPlayerVO;
            _loc_3.userID = param2;
            _loc_3.uniqueID = new dUniqueID();
            for each (_loc_4 in param1.mCurrentPlayerZone.mSectorList_vector)
            {
                
                _loc_5 = new dSectorDiscoveryVO();
                _loc_5.sectorID = _loc_4.GetSectorID();
                _loc_5.discoveryType = SECTOR_DISCOVERY_TYPE.EXPLORED;
                _loc_3.discoveredSectors.addItem(_loc_5);
            }
            return _loc_3;
        }// end function

    }
}
