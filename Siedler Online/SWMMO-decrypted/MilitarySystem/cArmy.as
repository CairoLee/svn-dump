package MilitarySystem
{
    import Communication.VO.*;
    import Enums.*;
    import __AS3__.vec.*;

    public class cArmy extends Object
    {
        private var mOwner:Object;
        private var mOwnerType:int;
        private var mPlayerID:int;
        private var mBuildingDamage:int = 0;
        private var mZoneID:int;
        private var map_UnitType_Squad:Object;

        public function cArmy(param1:int, param2:int, param3:int, param4:Object)
        {
            this.map_UnitType_Squad = new Object();
            this.mZoneID = param1;
            this.mPlayerID = param2;
            this.mOwnerType = param3;
            this.mOwner = param4;
            return;
        }// end function

        public function CalculateBuildingDamage() : int
        {
            var _loc_1:cSquad = null;
            this.mBuildingDamage = 0;
            for each (_loc_1 in this.map_UnitType_Squad)
            {
                
                this.mBuildingDamage = this.mBuildingDamage + _loc_1.GetBuildingDamage();
            }
            return this.mBuildingDamage;
        }// end function

        public function DisbandArmy(param1:cArmy) : void
        {
            var _loc_2:cSquad = null;
            if (param1 != null)
            {
                for each (_loc_2 in this.map_UnitType_Squad)
                {
                    
                    if (_loc_2.GetUnitDescription().GetSkill(MILLITARY_UNIT_SKILLS.IS_SPECIALIST) == null)
                    {
                        param1.AddUnits(_loc_2.GetType_string(), _loc_2.GetAmount(), true);
                    }
                }
            }
            this.map_UnitType_Squad = new Object();
            return;
        }// end function

        public function GetSquad(param1:String) : cSquad
        {
            return this.map_UnitType_Squad[param1];
        }// end function

        public function CreateArmyVO() : dArmyVO
        {
            var _loc_2:cSquad = null;
            var _loc_1:* = new dArmyVO();
            for each (_loc_2 in this.map_UnitType_Squad)
            {
                
                _loc_1.squads.addItem(_loc_2.CreateSquadVO());
            }
            return _loc_1;
        }// end function

        public function RemoveUnits(param1:String, param2:int) : int
        {
            var _loc_4:int = 0;
            var _loc_3:* = this.map_UnitType_Squad[param1];
            if (_loc_3 == null)
            {
                return 0;
            }
            _loc_4 = _loc_3.GetAmount();
            if (param2 < _loc_4)
            {
                _loc_4 = param2;
            }
            _loc_3.AddUnits(-_loc_4, true);
            if (_loc_3.GetAmount() == 0)
            {
                delete this.map_UnitType_Squad[param1];
            }
            return _loc_4;
        }// end function

        public function AddUnits(param1:String, param2:int, param3:Boolean) : void
        {
            var _loc_4:* = this.map_UnitType_Squad[param1];
            if (this.map_UnitType_Squad[param1] == null)
            {
                _loc_4 = new cSquad(param1, param2, cMilitaryUnitDescription.GetUnitDescriptionForType(param1).GetHitPoints(), param3);
                this.map_UnitType_Squad[param1] = _loc_4;
            }
            else
            {
                _loc_4.AddUnits(param2, param3);
            }
            return;
        }// end function

        public function ApplyArmyVO(param1:dArmyVO) : void
        {
            var _loc_2:dSquadVO = null;
            this.map_UnitType_Squad = new Object();
            for each (_loc_2 in param1.squads)
            {
                
                this.AddSquadVO(_loc_2, true);
            }
            return;
        }// end function

        public function HasUnits() : Boolean
        {
            var _loc_1:cSquad = null;
            for each (_loc_1 in this.map_UnitType_Squad)
            {
                
                if (_loc_1.GetAmount() > 0)
                {
                    return true;
                }
            }
            return false;
        }// end function

        public function GetUnitsCount() : int
        {
            var _loc_2:cSquad = null;
            var _loc_1:int = 0;
            for each (_loc_2 in this.map_UnitType_Squad)
            {
                
                _loc_1 = _loc_1 + _loc_2.GetAmount();
            }
            return _loc_1;
        }// end function

        public function AddSquadVO(param1:dSquadVO, param2:Boolean) : void
        {
            this.AddUnits(param1.GetType_string(), param1.GetAmount(), param2);
            return;
        }// end function

        public function GetSquads_vector()
        {
            var _loc_2:cSquad = null;
            var _loc_1:* = new Vector.<cSquad>;
            for each (_loc_2 in this.map_UnitType_Squad)
            {
                
                _loc_1.push(_loc_2);
            }
            return _loc_1;
        }// end function

        public function toString() : String
        {
            var _loc_2:cSquad = null;
            var _loc_1:String = "<Army>";
            for each (_loc_2 in this.map_UnitType_Squad)
            {
                
                _loc_1 = _loc_1 + _loc_2;
            }
            _loc_1 = _loc_1 + "</Army>";
            return _loc_1;
        }// end function

    }
}
