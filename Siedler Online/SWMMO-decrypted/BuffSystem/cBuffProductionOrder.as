package BuffSystem
{
    import Enums.*;
    import GO.*;
    import Interface.*;
    import ServerState.*;
    import TimedProduction.*;

    public class cBuffProductionOrder extends cAbstractTimedProductionOrder
    {
        private var buffDefinition:cBuffDefinition;

        public function cBuffProductionOrder(param1:String, param2:int)
        {
            super(param1, param2, TIMED_PRODUCTION_TYPE.BUFF);
            this.buffDefinition = global.map_BuffName_BuffDefinition[param1];
            return;
        }// end function

        override public function GetOnFinishedAvatarMessageType() : String
        {
            return AVATAR_MESSAGE_TYPE.PRODUCTION_FINISHED;
        }// end function

        override public function GetCostsToBuy_vector()
        {
            return this.buffDefinition.GetCosts_vector();
        }// end function

        override public function GetInstantBuildCosts() : int
        {
            return this.buffDefinition.GetInstantBuildCosts();
        }// end function

        override public function GetTimeBonus(param1:cGeneralInterface) : Number
        {
            var _loc_3:cBuilding = null;
            var _loc_4:Number = NaN;
            var _loc_5:BuffAppliance = null;
            var _loc_2:cBuilding = null;
            for each (_loc_3 in param1.mCurrentPlayerZone.mStreetDataMap.GetBuildings_vector())
            {
                
                if (_loc_3.GetBuildingName_string() == defines.PROVISIONHOUSE_NAME_string)
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
            var _loc_4:* = global.map_BuffName_BuffDefinition[GetType_string()];
            var _loc_5:* = new cBuff(_loc_4, GetNextUniqueId(), param3);
            if (_loc_4.GetAmount() > 0)
            {
                _loc_5.SetAmount(_loc_5.GetAmount() * _loc_5.GetCount());
                _loc_5.SetRemaining(_loc_5.GetAmount());
                _loc_5.SetCount(0);
            }
            param1.mAvailableBuffs_vector.push(_loc_5);
            return;
        }// end function

        override public function GetProductionTime() : int
        {
            return this.buffDefinition.GetProductionTime();
        }// end function

    }
}
