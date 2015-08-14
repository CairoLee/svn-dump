package MilitarySystem
{
    import ServerState.*;
    import TimedProduction.*;
    import __AS3__.vec.*;
    import nLib.*;

    public class cMilitaryUnitDescription extends Object implements iTimedProductionDefinition
    {
        private var mType:int;
        private var mType_string:String;
        private var mInstantBuildCosts:int;
        private var mProduceable:Boolean;
        private var mSequencePrio:int;
        private var mXpForDefeat:int;
        private var mMissDamage:int;
        private var mHitPercentage:int;
        private var mCosts_vector:Vector.<dResource>;
        private var mMap_SkillType_Skill:Object;
        private var mHitPoints:int;
        private var mProductionTime:int;
        private var mHitDamage:int;
        private var mPlayerLevel:int;
        private static var map_UnitType_UnitDescription:Object = new Object();

        public function cMilitaryUnitDescription(param1:String, param2:int, param3:int, param4:int, param5:int, param6:int, param7:int, param8:Boolean, param9:int, param10:int, param11:int, param12:int, param13, param14)
        {
            var _loc_15:cMilitaryUnitSkill = null;
            this.mMap_SkillType_Skill = new Object();
            this.mType_string = param1;
            this.mType = param2;
            this.mHitPoints = param3;
            this.mSequencePrio = param4;
            this.mHitPercentage = param5;
            this.mHitDamage = param6;
            this.mMissDamage = param7;
            this.mProduceable = param8;
            this.mProductionTime = param9;
            this.mPlayerLevel = param10;
            this.mXpForDefeat = param11;
            this.mInstantBuildCosts = param12;
            this.mCosts_vector = param13;
            for each (_loc_15 in param14)
            {
                
                this.mMap_SkillType_Skill[_loc_15.GetType()] = _loc_15;
            }
            return;
        }// end function

        public function GetSequencePrio() : int
        {
            return this.mSequencePrio;
        }// end function

        public function GetSkill(param1:int) : cMilitaryUnitSkill
        {
            return this.mMap_SkillType_Skill[param1];
        }// end function

        public function toString() : String
        {
            return "<MilitaryUnitDescription \'" + this.mType_string + "\' " + this.GetSkills() + " >";
        }// end function

        public function GetSkills()
        {
            var _loc_2:cMilitaryUnitSkill = null;
            var _loc_1:* = new Vector.<cMilitaryUnitSkill>;
            for each (_loc_2 in this.mMap_SkillType_Skill)
            {
                
                _loc_1.push(_loc_2);
            }
            return _loc_1;
        }// end function

        public function GetXpForDefeat() : int
        {
            return this.mXpForDefeat;
        }// end function

        public function GetHitPoints() : int
        {
            return this.mHitPoints;
        }// end function

        public function IsProduceable() : Boolean
        {
            return this.mProduceable;
        }// end function

        public function GetHitDamage() : int
        {
            return this.mHitDamage;
        }// end function

        public function GetPlayerLevel() : int
        {
            return this.mPlayerLevel;
        }// end function

        public function GetInstantBuildCosts() : int
        {
            return this.mInstantBuildCosts;
        }// end function

        public function GetType_Int() : int
        {
            return this.mType;
        }// end function

        public function GetMissDamage() : int
        {
            return this.mMissDamage;
        }// end function

        public function GetType_string() : String
        {
            return this.mType_string;
        }// end function

        public function GetCosts_vector()
        {
            return this.mCosts_vector;
        }// end function

        public function GetProductionTime() : int
        {
            return this.mProductionTime;
        }// end function

        public function GetHitPercentage() : int
        {
            return this.mHitPercentage;
        }// end function

        public static function GetUnitDescriptionForType(param1:String) : cMilitaryUnitDescription
        {
            return map_UnitType_UnitDescription[param1];
        }// end function

        public static function GetAllUnitDescriptions(param1:Boolean) : Array
        {
            var _loc_3:String = null;
            var _loc_2:Array = [];
            for (_loc_3 in map_UnitType_UnitDescription)
            {
                
                if ((map_UnitType_UnitDescription[_loc_3] as cMilitaryUnitDescription).IsProduceable() || !param1)
                {
                    _loc_2.push(map_UnitType_UnitDescription[_loc_3]);
                }
            }
            _loc_2.sort(SortUnits);
            return _loc_2;
        }// end function

        public static function SortUnits(param1:cMilitaryUnitDescription, param2:cMilitaryUnitDescription) : int
        {
            return param1.GetPlayerLevel() - param2.GetPlayerLevel();
        }// end function

        public static function InitData(param1:cXML) : void
        {
            var _loc_5:cXML = null;
            var _loc_6:String = null;
            var _loc_7:int = 0;
            var _loc_8:int = 0;
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            var _loc_11:Boolean = false;
            var _loc_12:int = 0;
            var _loc_13:int = 0;
            var _loc_14:int = 0;
            var _loc_15:int = 0;
            var _loc_16:int = 0;
            var _loc_17:Vector.<dResource> = null;
            var _loc_18:cXML = null;
            var _loc_19:Vector.<cXML> = null;
            var _loc_20:cXML = null;
            var _loc_21:Vector.<cMilitaryUnitSkill> = null;
            var _loc_22:cXML = null;
            var _loc_23:Vector.<cXML> = null;
            var _loc_24:cXML = null;
            var _loc_25:cMilitaryUnitDescription = null;
            var _loc_26:dResource = null;
            var _loc_27:int = 0;
            var _loc_28:int = 0;
            var _loc_2:* = new Vector.<int>;
            var _loc_3:* = param1.CreateChildrenArray();
            var _loc_4:int = 0;
            for each (_loc_5 in _loc_3)
            {
                
                _loc_6 = _loc_5.GetAttributeString_string("type");
                _loc_7 = _loc_5.GetAttributeInt("hitPoints");
                _loc_8 = _loc_5.GetAttributeInt("hitPercentage");
                _loc_9 = _loc_5.GetAttributeInt("hitDamage");
                _loc_10 = _loc_5.GetAttributeInt("missDamage");
                _loc_11 = _loc_5.GetAttributeBool("produceable");
                _loc_12 = _loc_5.GetAttributeInt("productionTimeSeconds") * 1000;
                _loc_13 = _loc_5.GetAttributeInt("playerLevel");
                _loc_14 = _loc_5.GetAttributeInt("xpForDefeat");
                _loc_15 = _loc_5.GetAttributeInt("instantBuildCosts");
                _loc_16 = _loc_5.GetAttributeInt("sequencePrio");
                if (_loc_2.indexOf(_loc_16) != -1)
                {
                    gMisc.Assert(false, "sequencePrio " + _loc_16 + " is already assigned.");
                }
                _loc_2.push(_loc_16);
                _loc_17 = new Vector.<dResource>;
                _loc_18 = _loc_5.MoveToSubNode("Costs");
                _loc_19 = _loc_18.CreateChildrenArray();
                for each (_loc_20 in _loc_19)
                {
                    
                    _loc_26 = new dResource();
                    _loc_26.name_string = _loc_20.GetAttributeString_string("name");
                    _loc_26.amount = _loc_20.GetAttributeInt("count");
                    _loc_17.push(_loc_26);
                }
                _loc_21 = new Vector.<cMilitaryUnitSkill>;
                _loc_22 = _loc_5.MoveToSubNode("Skills");
                _loc_23 = _loc_22.CreateChildrenArray();
                for each (_loc_24 in _loc_23)
                {
                    
                    _loc_27 = _loc_24.GetAttributeInt("type");
                    _loc_28 = _loc_24.GetAttributeInt("data");
                    _loc_21.push(new cMilitaryUnitSkill(_loc_27, _loc_28));
                }
                _loc_25 = new cMilitaryUnitDescription(_loc_6, _loc_4, _loc_7, _loc_16, _loc_8, _loc_9, _loc_10, _loc_11, _loc_12, _loc_13, _loc_14, _loc_15, _loc_17, _loc_21);
                map_UnitType_UnitDescription[_loc_6] = _loc_25;
                _loc_4++;
            }
            return;
        }// end function

        public static function GetHitPointsForUnit(param1:String) : int
        {
            return GetUnitDescriptionForType(param1).GetHitPoints();
        }// end function

    }
}
