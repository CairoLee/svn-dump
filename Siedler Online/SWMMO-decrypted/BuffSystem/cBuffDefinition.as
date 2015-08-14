package BuffSystem
{
    import Enums.*;
    import TimedProduction.*;
    import __AS3__.vec.*;
    import nLib.*;

    public class cBuffDefinition extends Object implements iTimedProductionDefinition
    {
        private var militaryUnitCapacity:int;
        private var productivityInputPercent:int;
        private var id:int;
        private var playerLevel:int;
        private var mAmount:int;
        private var productionTime:int;
        private var durations_vector:Vector.<int>;
        private var buffType:int;
        private var goodsCapacity:int;
        private var mResourceName_string:String;
        private var mTargetDescription_string:String;
        private var mTargetType:int;
        private var produceable:Boolean;
        private var name_string:String = "";
        private var upgradeLevel:int;
        private var recruitingTimePercentage:int;
        private var productivityOutputPercent:int;
        private var mInstantBuildCosts:int;
        private var hitPoints:int;
        private var deletable:Boolean;
        private var costs_vector:Vector.<dResource>;
        private var sortIndex:int;
        private var mTargetZoneTypes:int;
        private var tradable:Boolean;
        private var group:String = "";

        public function cBuffDefinition(param1:int, param2:String, param3:Boolean, param4:Boolean, param5:int, param6:int, param7:int, param8:String, param9:int, param10:Boolean, param11, param12, param13:int, param14:int, param15:int, param16:int, param17:int, param18:int, param19:int, param20:String, param21:int, param22:int, param23:String, param24:int, param25:int)
        {
            this.id = param1;
            this.name_string = param2;
            this.tradable = param3;
            this.deletable = param4;
            this.buffType = param5;
            this.productionTime = param6;
            this.upgradeLevel = param9;
            this.playerLevel = param7;
            this.durations_vector = param11;
            this.produceable = param10;
            this.costs_vector = param12;
            this.hitPoints = param13;
            this.goodsCapacity = param14;
            this.militaryUnitCapacity = param15;
            this.productivityInputPercent = param16;
            this.productivityOutputPercent = param17;
            this.recruitingTimePercentage = param18;
            this.group = param8;
            this.mAmount = param19;
            this.mResourceName_string = param20;
            this.mTargetZoneTypes = param21;
            this.mTargetType = param22;
            this.mTargetDescription_string = param23;
            this.sortIndex = param24;
            this.mInstantBuildCosts = param25;
            return;
        }// end function

        public function getMilitaryUnitCapacity() : int
        {
            return this.militaryUnitCapacity;
        }// end function

        public function GetTargetDescription_string() : String
        {
            return this.mTargetDescription_string;
        }// end function

        public function getDuration(param1:int) : int
        {
            return this.durations_vector[param1];
        }// end function

        public function getProductivityInputPercent() : int
        {
            return this.productivityInputPercent;
        }// end function

        public function GetPlayerLevel() : int
        {
            return this.playerLevel;
        }// end function

        public function IsProduceable() : Boolean
        {
            return this.produceable;
        }// end function

        public function GetType_string() : String
        {
            return this.name_string;
        }// end function

        public function getProductivityOutputPercent() : int
        {
            return this.productivityOutputPercent;
        }// end function

        public function GetGroup_string() : String
        {
            return this.group;
        }// end function

        public function GetAmount() : int
        {
            return this.mAmount;
        }// end function

        public function IsDeletable() : Boolean
        {
            return this.deletable;
        }// end function

        public function GetInstantBuildCosts() : int
        {
            return this.mInstantBuildCosts;
        }// end function

        public function GetBuffType() : int
        {
            return this.buffType;
        }// end function

        public function getUpgradeLevel() : int
        {
            return this.upgradeLevel;
        }// end function

        public function GetCosts_vector()
        {
            return this.costs_vector;
        }// end function

        public function getHitPoints() : int
        {
            return this.hitPoints;
        }// end function

        public function getRecruitingTime() : int
        {
            return this.recruitingTimePercentage;
        }// end function

        public function GetTargetType() : int
        {
            return this.mTargetType;
        }// end function

        public function GetName_string() : String
        {
            return this.name_string;
        }// end function

        public function GetResourceName_string() : String
        {
            return this.mResourceName_string;
        }// end function

        public function IsTradable() : Boolean
        {
            return this.tradable;
        }// end function

        public function getTargetZoneTypes() : int
        {
            return this.mTargetZoneTypes;
        }// end function

        public function GetSortIndex() : int
        {
            return this.sortIndex;
        }// end function

        public function toString() : String
        {
            var _loc_1:String = "<cBuffDefinition ";
            _loc_1 = _loc_1 + ("buffType=\'" + this.buffType + "\'");
            _loc_1 = _loc_1 + " />";
            return _loc_1;
        }// end function

        public function GetId() : int
        {
            return this.id;
        }// end function

        public function getGoodsCapacity() : int
        {
            return this.goodsCapacity;
        }// end function

        public function GetProductionTime() : int
        {
            return this.productionTime;
        }// end function

        public static function CreateBuffDefinitionFromXml(param1:cXML) : cBuffDefinition
        {
            var _loc_24:cXML = null;
            var _loc_25:int = 0;
            var _loc_26:int = 0;
            var _loc_27:String = null;
            var _loc_30:int = 0;
            var _loc_31:int = 0;
            var _loc_2:* = param1.GetAttributeInt("id");
            var _loc_3:* = param1.GetAttributeString_string("name");
            var _loc_4:* = param1.GetAttributeBool("tradable");
            var _loc_5:* = param1.GetAttributeBool("deletable");
            var _loc_6:* = BUFF_TYPE.Parse(param1.GetAttributeString_string("buffType"));
            var _loc_7:* = param1.GetAttributeInt("productionTime") * 1000;
            var _loc_8:* = param1.GetAttributeInt("playerLevel");
            var _loc_9:* = param1.GetAttributeInt("level");
            var _loc_10:* = param1.GetAttributeBool("produceable");
            var _loc_11:* = param1.GetAttributeInt("sortIndex");
            var _loc_12:* = param1.GetAttributeInt("hitPointsAmount");
            var _loc_13:* = param1.GetAttributeInt("goodsCapacityAmount");
            var _loc_14:* = param1.GetAttributeInt("militaryUnitCapacityAmount");
            var _loc_15:* = param1.GetAttributeInt("productivityInputPercent");
            var _loc_16:* = param1.GetAttributeInt("productivityOutputPercent");
            var _loc_17:* = param1.GetAttributeInt("recruitingTimePercent");
            var _loc_18:* = param1.GetAttributeString_string("group");
            var _loc_19:* = param1.GetAttributeInt("amount");
            var _loc_20:* = param1.GetAttributeString_string("resourceName");
            var _loc_21:* = param1.GetAttributeInt("instantBuildCosts");
            var _loc_22:* = new Vector.<int>;
            var _loc_23:* = param1.MoveToSubNode("Durations").CreateChildrenArray();
            for each (_loc_24 in _loc_23)
            {
                
                _loc_30 = BUFF_APPLIANCE_MODE.parseString(_loc_24.GetAttributeString_string("applianceMode"));
                _loc_31 = _loc_24.GetAttributeInt("seconds") * 1000;
                gMisc.Assert(_loc_30 == _loc_22.length, "Duration applianceMode was defined at the wrong position: " + _loc_30);
                _loc_22.push(_loc_31);
            }
            _loc_25 = BUFF_TARGET_ZONE.parse(param1.GetAttributeString_string("targetZones"));
            _loc_26 = -1;
            _loc_27 = param1.GetAttributeString_string("targetType");
            if (_loc_27.length > 0)
            {
                _loc_26 = BUFF_TARGET_TYPE.parse(_loc_27);
            }
            var _loc_28:* = param1.GetAttributeString_string("targetDescription");
            var _loc_29:* = gParse.ParseCosts(param1.MoveToSubNode("Costs"));
            return new cBuffDefinition(_loc_2, _loc_3, _loc_4, _loc_5, _loc_6, _loc_7, _loc_8, _loc_18, _loc_9, _loc_10, _loc_22, _loc_29, _loc_12, _loc_13, _loc_14, _loc_15, _loc_16, _loc_17, _loc_19, _loc_20, _loc_25, _loc_26, _loc_28, _loc_11, _loc_21);
        }// end function

    }
}
