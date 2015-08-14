package AdventureSystem
{
    import Communication.VO.*;
    import Communication.VO.UpdateVO.*;
    import Enums.*;
    import Interface.*;
    import MilitarySystem.*;
    import Specialists.*;
    import __AS3__.vec.*;
    import nLib.*;

    public class cAdventure extends Object
    {
        private var mStartDate:Number;
        private var mZoneID:int;
        private var mAdventureDefinition:cAdventureDefinition = null;
        private var mOwnerPlayerID:int;
        private var mAdventurePlayers_vector:Vector.<dAdventurePlayerVO>;
        private var mEndDate:Number;
        private var mStatus:int = 0;
        public static const STATUS_STARTED:int = 1;
        public static const STATUS_FINISHED_WON:int = 2;
        public static const STATUS_INITIALIZED:int = 0;
        public static const STATUS_FINISHED_LOST:int = 3;

        public function cAdventure(param1:int, param2:String, param3:Number, param4:int, param5:int, param6:int)
        {
            this.mAdventurePlayers_vector = new Vector.<dAdventurePlayerVO>;
            this.mZoneID = param1;
            var _loc_7:* = cAdventureDefinition.FindAdventureDefinition(param2);
            gMisc.Assert(_loc_7 != null, "Could not init adventure with name \'" + param2 + "\'!");
            this.mAdventureDefinition = _loc_7;
            this.mStartDate = param3;
            this.mOwnerPlayerID = param6;
            this.mEndDate = this.mStartDate + param4 + param5;
            return;
        }// end function

        public function GetCurrentPlayersCount() : int
        {
            return this.mAdventurePlayers_vector.length;
        }// end function

        public function GetStatus() : int
        {
            return this.mStatus;
        }// end function

        public function UpdatePlayerStatus(param1:int, param2:int) : void
        {
            var _loc_3:dAdventurePlayerVO = null;
            for each (_loc_3 in this.mAdventurePlayers_vector)
            {
                
                if (_loc_3.playerID == param1)
                {
                    _loc_3.status = param2;
                    return;
                }
            }
            return;
        }// end function

        public function RemoveAdventurePlayer(param1:int) : void
        {
            var _loc_3:dAdventurePlayerVO = null;
            var _loc_2:int = 0;
            while (_loc_2 < this.mAdventurePlayers_vector.length)
            {
                
                _loc_3 = this.mAdventurePlayers_vector[_loc_2] as dAdventurePlayerVO;
                if (_loc_3.playerID == param1)
                {
                    this.mAdventurePlayers_vector.splice(_loc_2, 1);
                    return;
                }
                _loc_2++;
            }
            return;
        }// end function

        public function AddAdventurePlayer(param1:dAdventurePlayerVO) : void
        {
            this.mAdventurePlayers_vector.push(param1);
            return;
        }// end function

        public function HasPlayerInAdventure(param1:int) : Boolean
        {
            var _loc_2:dAdventurePlayerVO = null;
            for each (_loc_2 in this.mAdventurePlayers_vector)
            {
                
                if (_loc_2.playerID == param1)
                {
                    return true;
                }
            }
            return false;
        }// end function

        public function GetEndDate() : Number
        {
            return this.mEndDate;
        }// end function

        public function GetAdventureID() : int
        {
            return this.mZoneID;
        }// end function

        public function GetAdventurePlayers()
        {
            return this.mAdventurePlayers_vector;
        }// end function

        public function GetStartDate() : Number
        {
            return this.mStartDate;
        }// end function

        public function SetStatus(param1:int, param2:cGeneralInterface) : void
        {
            var _loc_3:int = 0;
            var _loc_4:Vector.<cSpecialist> = null;
            var _loc_5:cSpecialist = null;
            var _loc_6:cArmy = null;
            var _loc_7:dSpecialistVO = null;
            var _loc_8:cSpecialist = null;
            this.mStatus = param1;
            if (param1 >= STATUS_FINISHED_WON)
            {
                for each (_loc_3 in param2.mCurrentPlayerZone.map_PlayerID_Army)
                {
                    
                    _loc_6 = param2.mCurrentPlayerZone.GetArmy(_loc_3);
                    if (_loc_6.GetUnitsCount() > 0)
                    {
                        _loc_7 = new dSpecialistVO();
                        _loc_7.playerID = _loc_3;
                        _loc_7.specialistType = SPECIALIST_TYPE.TMP_ARMY_TRANSPORTER;
                        _loc_7.garrisonBuildingGridPos = -1;
                        _loc_7.uniqueID = new dUniqueID().Init(-this.mZoneID, -this.mZoneID);
                        _loc_7.armyVO = _loc_6.CreateArmyVO();
                        _loc_8 = cSpecialist.CreateSpecialistFromVO(param2, _loc_7, true);
                        param2.mCurrentPlayerZone.GetSpecialists_vector().push(_loc_8);
                        _loc_6.DisbandArmy(null);
                    }
                }
                _loc_4 = new Vector.<cSpecialist>;
                _loc_4.concat(param2.mCurrentPlayerZone.GetSpecialists_vector());
                for each (_loc_5 in _loc_4)
                {
                    
                    _loc_5.SetTask(new cSpecialistTask_TravelToZone(param2, _loc_5, _loc_5.GetPlayerID(), 0, TASK_PHASES_TRAVEL_TO_ZONE.STRIKE_GARRISON));
                    if (_loc_5.GetTask() != null)
                    {
                        (_loc_5.GetTask() as cSpecialistTask_TravelToZone).BeginTravel();
                    }
                }
            }
            return;
        }// end function

        public function GetMaxPlayersCount() : int
        {
            return this.mAdventureDefinition.mMaxPlayers;
        }// end function

        public function GetAdventureDefinition() : cAdventureDefinition
        {
            return this.mAdventureDefinition;
        }// end function

        public function StartAdventure() : void
        {
            this.mStatus = STATUS_STARTED;
            return;
        }// end function

        public function GetName_string() : String
        {
            return this.mAdventureDefinition.mName_string;
        }// end function

        public function IsActive() : Boolean
        {
            return this.mStatus == cAdventure.STATUS_STARTED;
        }// end function

        public function InviteAdventurePlayer(param1:dAdventurePlayerVO) : void
        {
            this.AddAdventurePlayer(param1);
            return;
        }// end function

        public function GetOwnerPlayerID() : int
        {
            return this.mOwnerPlayerID;
        }// end function

        public static function GetStatusString(param1:int) : String
        {
            switch(param1)
            {
                case STATUS_INITIALIZED:
                {
                    return "Initialized";
                }
                case STATUS_STARTED:
                {
                    return "Started";
                }
                case STATUS_FINISHED_WON:
                {
                    return "Finished-Won";
                }
                case STATUS_FINISHED_LOST:
                {
                    return "Finished-Lost";
                }
                default:
                {
                    return "Unknown adventure status: " + param1;
                    continue;
                }
            }
        }// end function

        public static function CreateAdventureFromAdventureVO(param1:dAdventureVO) : cAdventure
        {
            var _loc_2:* = new cAdventure(param1.adventureID, param1.adventureDefinitionName, param1.startTime, param1.adventureDuration, param1.serverDownDuration, param1.ownerPlayerID);
            _loc_2.mStatus = param1.state;
            return _loc_2;
        }// end function

    }
}
