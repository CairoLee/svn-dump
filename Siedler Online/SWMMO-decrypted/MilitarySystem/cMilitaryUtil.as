package MilitarySystem
{
    import Communication.VO.*;
    import Enums.*;
    import GO.*;
    import Interface.*;
    import Specialists.*;
    import nLib.*;

    public class cMilitaryUtil extends Object
    {

        public function cMilitaryUtil()
        {
            return;
        }// end function

        public static function RaiseArmy(param1:cArmy, param2:iMilitaryUnitHolder, param3) : void
        {
            var _loc_4:dResourceVO = null;
            var _loc_5:int = 0;
            param2.GetArmy().DisbandArmy(param1);
            if (param3 != null)
            {
                for each (_loc_4 in param3)
                {
                    
                    _loc_5 = param1.RemoveUnits(_loc_4.name_string, _loc_4.amount);
                    param2.GetArmy().AddUnits(_loc_4.name_string, _loc_5, true);
                }
            }
            return;
        }// end function

        public static function SendRaiseArmyToServer(param1:cGeneralInterface, param2:iMilitaryUnitHolder, param3) : void
        {
            var _loc_5:dSquadVO = null;
            var _loc_6:dResourceVO = null;
            gMisc.ConsoleOut("SendRaiseArmyToServer(" + param1 + ", " + param2 + ", " + param3 + ")");
            var _loc_4:* = new dRaiseArmyVO();
            if (param2 is cBuilding)
            {
                _loc_4.armyHolderBuildingVO = (param2 as cBuilding).CreateBuildingVOFromBuilding();
            }
            else if (param2 is cSpecialist)
            {
                _loc_4.armyHolderSpecialistVO = (param2 as cSpecialist).CreateSpecialistVOFromSpecialist();
            }
            else
            {
                gMisc.Assert(false, "Could not assign " + param2 + " to dRaiseArmyVO!");
                return;
            }
            for each (_loc_5 in param3)
            {
                
                _loc_6 = new dResourceVO();
                _loc_6.name_string = _loc_5.GetType_string();
                _loc_6.amount = _loc_5.GetAmount();
                _loc_4.unitSquads.addItem(_loc_6);
            }
            param1.mClientMessages.SendMessagetoServer(COMMAND.RAISE_ARMY, param1.mCurrentViewedZoneID, _loc_4);
            return;
        }// end function

    }
}
