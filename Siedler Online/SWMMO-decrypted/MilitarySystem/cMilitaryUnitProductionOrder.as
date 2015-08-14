package MilitarySystem
{
    import BuffSystem.*;
    import Enums.*;
    import GO.*;
    import Interface.*;
    import ServerState.*;
    import TimedProduction.*;

    public class cMilitaryUnitProductionOrder extends cAbstractTimedProductionOrder
    {
        private var unitDefinition:cMilitaryUnitDescription;

        public function cMilitaryUnitProductionOrder(param1:String, param2:int)
        {
            super(param1, param2, TIMED_PRODUCTION_TYPE.MILITARY_UNIT);
            this.unitDefinition = cMilitaryUnitDescription.GetUnitDescriptionForType(GetType_string());
            return;
        }// end function

        override public function GetOnFinishedAvatarMessageType() : String
        {
            return AVATAR_MESSAGE_TYPE.RECRUITMENT_FINISHED;
        }// end function

        override public function GetCostsToBuy_vector()
        {
            return this.unitDefinition.GetCosts_vector();
        }// end function

        override public function GetInstantBuildCosts() : int
        {
            return this.unitDefinition.GetInstantBuildCosts();
        }// end function

        override public function GetProductionTime() : int
        {
            return this.unitDefinition.GetProductionTime();
        }// end function

        override public function GetTimeBonus(param1:cGeneralInterface) : Number
        {
            var _loc_3:cBuilding = null;
            var _loc_4:Number = NaN;
            var _loc_5:BuffAppliance = null;
            var _loc_2:cBuilding = null;
            for each (_loc_3 in param1.mCurrentPlayerZone.mStreetDataMap.GetBuildings_vector())
            {
                
                if (_loc_3.GetBuildingName_string() == defines.BARRACKS_NAME_string)
                {
                    _loc_2 = _loc_3;
                    break;
                }
            }
            _loc_4 = 1;
            if (_loc_2 != null)
            {
                _loc_4 = _loc_2.GetUpgradeLevelBonuses().getRecruitingTime() / 100;
                for each (_loc_5 in _loc_2.mBuffs_vector)
                {
                    
                    _loc_4 = _loc_4 * (_loc_5.GetBuffDefinition().getRecruitingTime() / 100);
                }
            }
            return _loc_4;
        }// end function

        override public function CreateItem(param1:cPlayerData, param2:cGeneralInterface, param3:int) : void
        {
            param2.mCurrentPlayerZone.GetArmy(param1.GetPlayerId()).AddUnits(this.unitDefinition.GetType_string(), param3, true);
            param2.mDataTracking.IncTrackingDetail(cDataTracking.DATA_TRACKING_GENERAL_X_UNITS_OF_TYPE_X_TRAINED, GetType_string(), param3);
            return;
        }// end function

    }
}
