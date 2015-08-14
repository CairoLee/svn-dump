package BuffSystem
{
    import Communication.VO.*;
    import Communication.VO.Guild.*;
    import Enums.*;
    import GO.*;
    import Interface.*;
    import PathFinding.*;
    import ServerState.*;
    import TimedProduction.*;
    import nLib.*;

    public class cBuff extends Object implements iTimedProductionItem
    {
        private var buffDefinition:cBuffDefinition;
        private var mWaitingForServerResponse:Boolean = false;
        private var count:int;
        private var mAmount:int;
        public var mDirtyIndicator:int = 0;
        private var mResourceName_string:String;
        private var appliedAmount:int = 0;
        private var mWaitingForServerCount:int;
        private var recurrentChance:int;
        private var uniqueId:dUniqueID;
        private var remaining:int;
        private var markedAsDeletable:Boolean;

        public function cBuff(param1:cBuffDefinition, param2:dUniqueID, param3:int)
        {
            this.buffDefinition = param1;
            this.uniqueId = param2;
            this.count = param3;
            this.markedAsDeletable = false;
            this.mResourceName_string = param1.GetResourceName_string();
            this.mAmount = param1.GetAmount();
            this.remaining = this.mAmount;
            return;
        }// end function

        public function SetWaitingForServer() : void
        {
            if (this.GetCount() > 0)
            {
                this.mWaitingForServerCount = this.GetCount();
            }
            else
            {
                this.mWaitingForServerCount = 1;
            }
            return;
        }// end function

        public function SetWaitingForServerCount(param1:int) : void
        {
            this.mWaitingForServerCount = param1;
            return;
        }// end function

        public function IncWaitingForServerCount() : void
        {
            var _loc_1:String = this;
            var _loc_2:* = this.mWaitingForServerCount + 1;
            _loc_1.mWaitingForServerCount = _loc_2;
            return;
        }// end function

        public function SetResourceName(param1:String) : void
        {
            this.mResourceName_string = param1;
            return;
        }// end function

        public function MarkAsDeletable() : void
        {
            this.markedAsDeletable = true;
            return;
        }// end function

        public function SetRecurrentChance(param1:int) : void
        {
            this.recurrentChance = param1;
            return;
        }// end function

        public function GetType_string() : String
        {
            return this.GetBuffDefinition().GetType_string();
        }// end function

        public function GetWaitingForServerCount() : int
        {
            return this.mWaitingForServerCount;
        }// end function

        public function GetUniqueId() : dUniqueID
        {
            return this.uniqueId;
        }// end function

        public function GetRecurrentChance() : int
        {
            return this.recurrentChance;
        }// end function

        public function GetAppliedAmount() : int
        {
            return this.appliedAmount;
        }// end function

        public function HasDeletableFlag() : Boolean
        {
            return this.buffDefinition.IsDeletable();
        }// end function

        public function IsApplyable(param1:cPlayerData, param2:cGeneralInterface, param3:int) : Object
        {
            var _loc_4:cBuilding = null;
            var _loc_7:Boolean = false;
            var _loc_8:String = null;
            var _loc_9:Boolean = false;
            var _loc_10:dGuildVO = null;
            var _loc_11:cDeposit = null;
            var _loc_5:String = null;
            if (param1 == null)
            {
                return CURSOR_VALID.APPLY_BUFF_NO_PLAYER_SNH;
            }
            var _loc_6:* = param2.getZoneTypes(param1.GetPlayerId());
            if ((param2.getZoneTypes(param1.GetPlayerId()) & this.GetBuffDefinition().getTargetZoneTypes()) == 0)
            {
                return CURSOR_VALID.APPLY_BUFF_NO_PLAYER_SNH;
            }
            switch(this.GetBuffDefinition().GetTargetType())
            {
                case BUFF_TARGET_TYPE.BUILDING:
                {
                    _loc_4 = param2.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[param3].mBuilding;
                    if (_loc_4 == null)
                    {
                        _loc_4 = param2.mCurrentPlayerZone.mStreetDataMap.CheckIfBuildingIsSouthSouthEastAndSouthWest(param3);
                    }
                    if (_loc_4 == null)
                    {
                        return CURSOR_VALID.APPLY_BUFF_NO_BUILDING_AT_POSITION;
                    }
                    _loc_5 = this.buffDefinition.GetTargetDescription_string();
                    if (this.buffDefinition.GetName_string() == HALLOWEEN_EVENT.BUFF_GHOSTBUSTER)
                    {
                        if (_loc_4.mBuffs_vector.length == 0)
                        {
                            return null;
                        }
                        _loc_8 = (_loc_4.mBuffs_vector[0] as BuffAppliance).GetBuffDefinition().GetName_string();
                        _loc_9 = _loc_8 == HALLOWEEN_EVENT.BUFF_DARKNESS || _loc_8 == HALLOWEEN_EVENT.BUFF_HORROR;
                        return _loc_9 && _loc_5 == "Workyard" ? (_loc_4) : (null);
                    }
                    if (_loc_4.GetPlayerID() != param1.GetPlayerId())
                    {
                        if (_loc_5 != "Workyard" && _loc_5 != "Tavern" && this.buffDefinition.GetName_string().indexOf("GuildIncrease") != 0)
                        {
                            return CURSOR_VALID.APPLY_BUFF_ON_FOREIGN_ZONE_BUILDING_IS_NOT_OF_CORRECT_TYPE;
                        }
                    }
                    if (_loc_5 == defines.GUILDHOUSE_NAME_string)
                    {
                        if (_loc_4.GetPlayerID() == param2.mCurrentPlayer.GetPlayerId())
                        {
                            _loc_10 = param2.GetCurrentPlayerGuild();
                            if (_loc_10 == null)
                            {
                                return CURSOR_VALID.APPLY_BUFF_ON_GUILD_HOUSE_PLAYER_IS_NOT_IN_GUILD;
                            }
                            if (_loc_10.maxSize + this.buffDefinition.GetAmount() > global.guildMaxSizeLimit)
                            {
                                return CURSOR_VALID.APPLY_BUFF_ON_GUILD_HOUSE_MAXIMUM_NUMBER_OF_GUILD_MEMBERS_REACHED;
                            }
                        }
                    }
                    _loc_7 = true;
                    if (_loc_4.mBuffs_vector.length > 0)
                    {
                        _loc_7 = false;
                        switch(this.buffDefinition.GetBuffType())
                        {
                            case BUFF_TYPE.INSTANT:
                            case BUFF_TYPE.UPGRADE:
                            {
                                _loc_7 = true;
                            }
                            default:
                            {
                                break;
                            }
                        }
                    }
                    if (_loc_7 && _loc_4.IsBuildingActive())
                    {
                        if (_loc_5 != null && _loc_5.length > 0)
                        {
                            if (_loc_5 == "Workyard")
                            {
                                if (_loc_4.GetResourceCreation() != null && _loc_4.GetResourceCreation().GetResourceCreationDefinition() != null)
                                {
                                    return _loc_4;
                                }
                            }
                            else if (_loc_5 == "IsUpgradeAllowed")
                            {
                                if (_loc_4.IsUpgradeAllowed(false))
                                {
                                    return _loc_4;
                                }
                            }
                            else if (_loc_5 == _loc_4.GetBuildingName_string())
                            {
                                return _loc_4;
                            }
                        }
                        else
                        {
                            return _loc_4;
                        }
                    }
                    if (_loc_7)
                    {
                        return CURSOR_VALID.APPLY_BUFF_BUILDING_IS_INACTIVE;
                    }
                    return CURSOR_VALID.APPLY_BUFF_MAXIMUM_NUMBER_OF_BUFFS_REACHED_FOR_THIS_BUILDING;
                }
                case BUFF_TARGET_TYPE.DEPOSIT:
                {
                    _loc_11 = param2.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[param3].mDeposit;
                    if (_loc_11 == null)
                    {
                        return CURSOR_VALID.APPLY_BUFF_ON_DEPOSIT_NO_DEPOSIT_HERE;
                    }
                    if (!(this.GetResourceName_string().length == 0 || this.GetResourceName_string() == _loc_11.GetName_string()))
                    {
                        return CURSOR_VALID.APPLY_BUFF_DEPOSIT_IS_OF_WRONG_TYPE;
                    }
                    if (this.GetResourceName_string().length == 0 && _loc_11.GetName_string() == "HalloweenResource")
                    {
                        return CURSOR_VALID.APPLY_BUFF_DEPOSIT_IS_OF_WRONG_TYPE;
                    }
                    return _loc_11;
                }
                case -1:
                {
                    return param2.mCurrentPlayerZone.mStreetDataMap.GetMayorHouse();
                }
                default:
                {
                    gMisc.Assert(false, "Could not interpret target type " + this.GetBuffDefinition().GetTargetType());
                    return CURSOR_VALID.APPLY_BUFF_COULD_NOT_INTERPRET_TYPE_SNH;
                    continue;
                }
            }
        }// end function

        public function GetAmount() : int
        {
            return this.mAmount;
        }// end function

        public function IsDeletable() : Boolean
        {
            return this.markedAsDeletable && this.buffDefinition.IsDeletable();
        }// end function

        public function SetAmount(param1:int) : void
        {
            this.mAmount = param1;
            return;
        }// end function

        public function GetResourceName_string() : String
        {
            return this.mResourceName_string;
        }// end function

        public function CreateBuffVOFromBuff() : dBuffVO
        {
            var _loc_1:* = new dBuffVO();
            _loc_1.uniqueId1 = this.uniqueId.uniqueID1;
            _loc_1.uniqueId2 = this.uniqueId.uniqueID2;
            _loc_1.buffName_string = this.buffDefinition.GetType_string();
            _loc_1.resourceName_string = this.mResourceName_string;
            _loc_1.amount = this.mAmount;
            _loc_1.remaining = this.remaining;
            _loc_1.recurringChance = this.recurrentChance;
            _loc_1.count = this.count;
            return _loc_1;
        }// end function

        public function ApplyBuff(param1:cPlayerData, param2:cGeneralInterface, param3:cGO) : int
        {
            var _loc_4:cBuilding = null;
            var _loc_7:int = 0;
            var _loc_8:int = 0;
            var _loc_9:int = 0;
            var _loc_10:cDeposit = null;
            var _loc_11:cPlayerData = null;
            var _loc_12:cResources = null;
            var _loc_13:dResource = null;
            var _loc_14:int = 0;
            var _loc_15:int = 0;
            var _loc_16:int = 0;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            if (this.buffDefinition.GetName_string().indexOf("SpeedUpPopulationGrowth") == 0 || this.buffDefinition.GetName_string().indexOf("ProductivityBuffLvl") == 0 || this.buffDefinition.GetName_string().indexOf("PayProductivityBuffLvl") == 0 || this.buffDefinition.GetName_string().indexOf("RecruitingBuffLvl") == 0 || this.buffDefinition.GetName_string() == HALLOWEEN_EVENT.BUFF_HORROR)
            {
                _loc_7 = BUFF_APPLIANCE_MODE.PLAYER;
                if (param3.GetPlayerID() != param1.GetPlayerId())
                {
                    _loc_7 = BUFF_APPLIANCE_MODE.FRIEND;
                }
                _loc_4 = param3 as cBuilding;
                _loc_4.AddBuff(this, _loc_7, _loc_4.GetBuildingGrid());
                _loc_5 = _loc_4.GetBuildingGrid();
                this.remaining = 0;
                var _loc_17:String = this;
                var _loc_18:* = this.count - 1;
                _loc_17.count = _loc_18;
                ;
            }
            if (this.buffDefinition.GetName_string().indexOf("IncreaseMaxBuildingCount") == 0)
            {
                param1.IncMaxBuildingCount(this.GetAmount());
                globalFlash.gui.mInfoBar.SetBuildingsCount(param1.mCurrentBuildingsCountAll, param1.GetMaxBuildingCount());
                this.remaining = 0;
                _loc_6 = this.mAmount;
                globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.INCREASED_MAX_BUILDINGS, this);
                ;
            }
            if (this.buffDefinition.GetName_string() == "BuildingUpgrade")
            {
                _loc_4 = param3 as cBuilding;
                _loc_4.Upgrade();
                _loc_5 = _loc_4.GetBuildingGrid();
                this.remaining = 0;
                ;
            }
            if (this.buffDefinition.GetName_string().indexOf("ChangeColorScheme") == 0)
            {
                if (gGfxResource.SetFilter(this.mResourceName_string, FILTER_SOURCE.BUFF))
                {
                    gGfxResource.ApplyZoom(param2.mZoom.GetInvScaleFactor());
                    param2.mCurrentPlayerZone.SetBackgroundHasChanged(true);
                    param2.mCurrentPlayerZone.SetAllRescaleDirtyFlags();
                }
                _loc_7 = BUFF_APPLIANCE_MODE.PLAYER;
                if (param3.GetPlayerID() != param1.GetPlayerId())
                {
                    _loc_7 = BUFF_APPLIANCE_MODE.FRIEND;
                }
                _loc_4 = param3 as cBuilding;
                _loc_4.AddBuff(this, _loc_7, _loc_4.GetBuildingGrid());
                ;
            }
            if (this.buffDefinition.GetName_string() == "Adventure")
            {
                this.remaining = 0;
                ;
            }
            if (this.buffDefinition.GetName_string().indexOf("FillDeposit") == 0)
            {
                if (this.mAmount > 0)
                {
                    _loc_10 = param3 as cDeposit;
                    _loc_5 = _loc_10.GetGridIdx();
                    if (_loc_10.GetAmount() == 0)
                    {
                        _loc_8 = _loc_10.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_10.GetGridIdx()].mSectorId;
                        _loc_9 = _loc_10.mGeneralInterface.mCurrentPlayerZone.GetSectorOwnerPlayerID(_loc_8);
                        _loc_10.mGeneralInterface.mPathFinder.InvalidateDepositMatrix(_loc_9, _loc_10.GetName_string(), cPathFinder.AMOUNT_TYPE_ABOVE_ZERO);
                    }
                    _loc_10.ChangeAmount(this.mAmount);
                    if (_loc_10.GetAmount() >= _loc_10.GetMaxAmount())
                    {
                        _loc_8 = _loc_10.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_10.GetGridIdx()].mSectorId;
                        _loc_9 = _loc_10.mGeneralInterface.mCurrentPlayerZone.GetSectorOwnerPlayerID(_loc_8);
                        _loc_10.mGeneralInterface.mPathFinder.InvalidateDepositMatrix(_loc_9, _loc_10.GetName_string(), cPathFinder.AMOUNT_TYPE_BELOW_MAX);
                    }
                    _loc_10.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_5].RefreshDepositGfx();
                    globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.USED_DEPOSIT_BUFF, this);
                    _loc_6 = this.mAmount;
                    this.remaining = 0;
                }
                ;
            }
            if (this.buffDefinition.GetName_string().indexOf("GuildIncreaseSize") == 0)
            {
            }
            if (param2.GetCurrentPlayerGuild() == null)
            {
                return -1;
            }
            if (param3.GetPlayerID() != param1.GetPlayerId())
            {
                this.appliedAmount = this.remaining;
                this.remaining = 0;
                globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.GUILD_INCREASE_SIZE_MAIL, this);
                return this.appliedAmount;
            }
            globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.GUILD_INCREASE_SIZE, this);
            this.remaining = 0;
            return _loc_6;
        }// end function

        public function GetBuffDefinition() : cBuffDefinition
        {
            return this.buffDefinition;
        }// end function

        public function GetRemaining() : int
        {
            return this.remaining;
        }// end function

        public function SetRemaining(param1:int) : void
        {
            this.remaining = param1;
            return;
        }// end function

        public function UnmarkAsDeletable() : void
        {
            this.markedAsDeletable = false;
            return;
        }// end function

        public function SetCount(param1:int) : void
        {
            this.count = param1;
            return;
        }// end function

        public function DecWaitingForServerCount() : void
        {
            var _loc_1:String = this;
            var _loc_2:* = this.mWaitingForServerCount - 1;
            _loc_1.mWaitingForServerCount = _loc_2;
            return;
        }// end function

        public function GetWaitingForServer() : Boolean
        {
            return this.GetWaitingForServerCount() > 0 && this.GetWaitingForServerCount() >= this.GetCount();
        }// end function

        public function GetCount() : int
        {
            return this.count;
        }// end function

        public function toString() : String
        {
            return "<cBuff" + " uniqueId=\'" + this.uniqueId + "\'" + " type=\'" + BUFF_TYPE.toString(this.buffDefinition.GetBuffType()) + "\'" + " resourceName=\'" + this.mResourceName_string + "\'" + " amount=\'" + this.mAmount + "\'" + " remaining=\'" + this.remaining + "\'" + "\' />";
        }// end function

        public static function CreateBuffFromVO(param1:dBuffVO) : cBuff
        {
            var _loc_2:* = global.map_BuffName_BuffDefinition[param1.buffName_string];
            var _loc_3:* = new cBuff(_loc_2, new dUniqueID().Init(param1.uniqueId1, param1.uniqueId2), param1.count);
            _loc_3.SetResourceName(param1.resourceName_string);
            _loc_3.SetAmount(param1.amount);
            _loc_3.SetRemaining(param1.remaining);
            _loc_3.SetRecurrentChance(param1.recurringChance);
            return _loc_3;
        }// end function

        public static function GetAllBuffDefinitions() : Array
        {
            var _loc_2:String = null;
            var _loc_1:Array = [];
            for (_loc_2 in global.map_BuffName_BuffDefinition)
            {
                
                if ((global.map_BuffName_BuffDefinition[_loc_2] as cBuffDefinition).IsProduceable())
                {
                    _loc_1.push(global.map_BuffName_BuffDefinition[_loc_2]);
                }
            }
            _loc_1.sort(SortBuffs);
            return _loc_1;
        }// end function

        public static function SortBuffs(param1:cBuffDefinition, param2:cBuffDefinition) : int
        {
            return param1.GetSortIndex() - param2.GetSortIndex();
        }// end function

    }
}
