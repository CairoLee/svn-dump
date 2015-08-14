package Specialists
{
    import Communication.VO.*;
    import Communication.VO.UpdateVO.*;
    import Enums.*;
    import GO.*;
    import Interface.*;
    import MilitarySystem.*;
    import PathFinding.*;
    import ServerState.*;
    import __AS3__.vec.*;
    import nLib.*;

    public class cSpecialistTask_AttackBuilding extends cSpecialistTask_WithSettler
    {
        private var mArmyDestination:cBuilding;
        private var mTargetBuildingGridIdx:int;
        private var mHitPointsOfOneDamageLevel:int = -1;
        private var mBuildingDamage:int;
        private var mTimeOfNextDamageLevel:int = -1;
        private var mTimeToReduceOneDamageLevel:int = -1;
        private var mGeneralRetreated:Boolean;
        private var mAttackBuildingMode:int;
        private const phaseDescriptions_list:Vector.<String>;
        private var mArmyDestinationGridIdx:int;
        private var mTargetBuilding:cBuilding;
        private var mStartingArmySize:int;
        private var mBattleResultVO:dBattleResultVO;
        private static var onePopulation_vector:Vector.<dResource> = null;

        public function cSpecialistTask_AttackBuilding(param1:cGeneralInterface, param2:cSpecialist, param3:int, param4:int, param5:int, param6:int)
        {
            var _loc_8:dResource = null;
            var _loc_9:int = 0;
            this.phaseDescriptions_list = new Vector.<String>(4);
            super(param1, SPECIALIST_TASK_TYPES.ATTACK_BUILDING, param2, param5, param6);
            this.phaseDescriptions_list[1] = "Units with first strike attack:";
            this.phaseDescriptions_list[2] = "Units attack:";
            this.phaseDescriptions_list[3] = "Slow units attack:";
            if (onePopulation_vector == null)
            {
                onePopulation_vector = new Vector.<dResource>;
                _loc_8 = new dResource();
                _loc_8.name_string = defines.POPULATION_RESOURCE_NAME_string;
                _loc_8.amount = 1;
                onePopulation_vector.push(_loc_8);
            }
            if (mGeneralInterface.mLog.isDebugEnabled(LOG_TYPE.MILITARY))
            {
                mGeneralInterface.mLog.logDebug(LOG_TYPE.MILITARY, "cSpecialistTask_AttackBuilding() owner:" + param2 + ", targetBuildingGridIdx:" + param3);
            }
            var _loc_7:* = param1.mCurrentPlayerZone.GetBuildingFromGridPosition(param3);
            this.mTargetBuildingGridIdx = param3;
            this.mTargetBuilding = _loc_7;
            this.mArmyDestinationGridIdx = param3;
            this.mArmyDestination = _loc_7;
            this.mAttackBuildingMode = param4;
            this.mGeneralRetreated = false;
            if (param2.GetGarrison() != null)
            {
                _loc_9 = gCalculations.MoveStreetGridToDir8(param3, defines.DIR8_SOUTH_EAST);
                SetDestinationPath(param1.mPathFinder.CalculatePath(param2.GetGarrison().GetStreetGridEntry(), _loc_9, param2.GetPlayerID(), false));
            }
            return;
        }// end function

        override public function CreateTaskVOFromSpecialistTask() : dSpecialistTaskVO
        {
            var _loc_1:* = new dSpecialistTask_AttackBuildingVO();
            _loc_1.type = GetType();
            _loc_1.phase = GetTaskPhase();
            _loc_1.collectedTime = GetCollectedTime();
            _loc_1.attackBuildingMode = this.mAttackBuildingMode;
            _loc_1.armyDestinationBuildingGridPos = this.GetArmyDestinationGridIdx();
            _loc_1.targetBuildingGridPos = this.GetTargetBuildingGridIdx();
            _loc_1.pathPos = GetPathPos();
            _loc_1.battleResultVO = this.mBattleResultVO;
            return _loc_1;
        }// end function

        public function GetArmyDestinationGridIdx() : int
        {
            return this.mArmyDestinationGridIdx;
        }// end function

        private function PerformRetreat() : void
        {
            if (mGeneralInterface.mLog.isDebugEnabled(LOG_TYPE.MILITARY))
            {
                mGeneralInterface.mLog.logDebug(LOG_TYPE.MILITARY, "cSpecialistTask_AttackBuilding.PerformRetreat() in phase: " + TASK_PHASES_ATTACK_BUILDING.toString(GetTaskPhase()));
            }
            this.mTargetBuilding.SetIsEngagedInCombat(false);
            if (GetTaskPhase() == TASK_PHASES_ATTACK_BUILDING.ATTACK_TARGET)
            {
                this.mTargetBuilding.SetCurrentHitPoints(this.mTargetBuilding.GetMaxHitPoints());
            }
            if (mGeneralInterface.mLog.isDebugEnabled(LOG_TYPE.MILITARY))
            {
                mGeneralInterface.mLog.logDebug(LOG_TYPE.MILITARY, "cSpecialistTask_AttackBuilding.PerformRetreat() mTargetBuilding: " + this.mTargetBuilding);
            }
            this.GoToGarrison();
            SetTaskPhase(TASK_PHASES_ATTACK_BUILDING.RETURN_TO_GARRISON);
            if (mGeneralInterface.mCurrentPlayer.GetPlayerId() == mOwner.GetPlayerID())
            {
                globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.GENERAL_RETREAT, mOwner);
            }
            else
            {
                globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.GENERAL_RETREAT_VIEWER, mOwner);
            }
            this.EndBattleAnimationOnMap(this.mTargetBuilding);
            this.mTargetBuilding.SetIsEngagedInCombat(false);
            mOwner.SetWaitingForServer(false);
            return;
        }// end function

        public function GetBattleResultVO() : dBattleResultVO
        {
            return this.mBattleResultVO;
        }// end function

        public function EndBattleAnimationOnMap(param1:cBuilding) : void
        {
            if (mSettler == null)
            {
                return;
            }
            mSettler.mSettlerKi.mAnimate = true;
            var _loc_2:* = param1.GetBuildingGrid();
            mGeneralInterface.mGoSetListAnimationManager.Remove(_loc_2);
            return;
        }// end function

        public function GetAttackBuildingMode() : int
        {
            return this.mAttackBuildingMode;
        }// end function

        public function toString() : String
        {
            return "<cSpecialistTask_AttackBuilding target=\'" + this.mTargetBuilding + "\' attackBuidlingMode=\'" + SPECIALIST_TASK_ATTACK_BUILDING_MODE.toString(this.mAttackBuildingMode) + "\' >";
        }// end function

        public function GetTargetBuilding() : cBuilding
        {
            return this.mTargetBuilding;
        }// end function

        public function SetBattleResultVO(param1:dBattleResultVO) : void
        {
            this.mBattleResultVO = param1;
            return;
        }// end function

        public function GetBuildingDamage() : int
        {
            return this.mBuildingDamage;
        }// end function

        public function StartBattleAnimationOnMap(param1:cBuilding) : void
        {
            var _loc_3:int = 0;
            if (mSettler == null)
            {
                return;
            }
            var _loc_2:* = param1.GetGOContainer().mBattleAnimation_string;
            if (_loc_2 != null)
            {
                _loc_3 = param1.GetBuildingGrid();
                if (!mGeneralInterface.mGoSetListAnimationManager.IsAnimationAtGridPos(_loc_3))
                {
                    mGeneralInterface.mGoSetListAnimationManager.AddAnimation(_loc_3, _loc_2, 0, global.streetGridYHalf, null);
                    mSettler.mSettlerKi.mAnimate = false;
                }
            }
            return;
        }// end function

        public function GetArmyDestination() : cBuilding
        {
            return this.mArmyDestination;
        }// end function

        public function GetTargetBuildingGridIdx() : int
        {
            return this.mTargetBuildingGridIdx;
        }// end function

        private function GoFromTowerToArmyDestination() : void
        {
            var _loc_1:int = 0;
            if (mGeneralInterface.mLog.isDebugEnabled(LOG_TYPE.MILITARY))
            {
                mGeneralInterface.mLog.logDebug(LOG_TYPE.MILITARY, "cSpecialistTask_AttackBuilding.GoFromTowerToArmyDestination()");
            }
            if (GetDestinationPath().dest_vector.length > 0)
            {
                _loc_1 = GetDestinationPath().CalculateGridIdxForPathPos(GetPathPos());
                this.mTargetBuildingGridIdx = this.mArmyDestinationGridIdx;
                this.mTargetBuilding = this.mArmyDestination;
                SetDestinationPath(mGeneralInterface.mPathFinder.CalculatePath(_loc_1, this.mTargetBuilding.GetStreetGridEntry(), mOwner.GetPlayerID(), false));
                mDirtyIndicator = mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            }
            SetPathPos(0);
            return;
        }// end function

        override public function StartTask() : void
        {
            super.StartTask();
            SpawnSettler(mOwner.GetGarrison().GetXInt(), mOwner.GetGarrison().GetYInt());
            return;
        }// end function

        private function GoToGarrison() : void
        {
            var _loc_1:int = 0;
            var _loc_2:cPathObject = null;
            if (mGeneralInterface.mLog.isDebugEnabled(LOG_TYPE.MILITARY))
            {
                mGeneralInterface.mLog.logDebug(LOG_TYPE.MILITARY, "cSpecialistTask_AttackBuilding.GoToGarrison()");
            }
            if (GetDestinationPath().dest_vector.length > 0)
            {
                _loc_1 = GetDestinationPath().CalculateGridIdxForPathPos(GetPathPos());
                _loc_2 = mGeneralInterface.mPathFinder.CalculatePath(_loc_1, mOwner.GetGarrison().GetStreetGridEntry(), mOwner.GetPlayerID(), false);
                _loc_2.dest_vector.reverse();
                SetDestinationPath(_loc_2);
                SetPathPos(GetDestinationPath().pathLenX10000);
            }
            return;
        }// end function

        public function Retreat() : void
        {
            if (mGeneralInterface.mLog.isDebugEnabled(LOG_TYPE.MILITARY))
            {
                mGeneralInterface.mLog.logDebug(LOG_TYPE.MILITARY, "cSpecialistTask_AttackBuilding.Retreat()");
            }
            if (GetTaskPhase() == TASK_PHASES_ATTACK_BUILDING.GO_TO_TARGET || GetTaskPhase() == TASK_PHASES_ATTACK_BUILDING.WAIT_FOR_ORDERS || GetTaskPhase() == TASK_PHASES_ATTACK_BUILDING.ATTACK_TARGET)
            {
                mOwner.SetWaitingForServer(true);
                globalFlash.gui.mSpecialistPanel.Refresh(mOwner);
                mGeneralInterface.mClientMessages.SendMessagetoServer(COMMAND.RETREAT, mGeneralInterface.mCurrentViewedZoneID, mOwner.GetUniqueID());
            }
            else if (mGeneralInterface.mLog.isInfoEnabled(LOG_TYPE.MILITARY))
            {
                mGeneralInterface.mLog.logInfo(LOG_TYPE.MILITARY, "cSpecialistTask_AttackBuilding.Retreat() cannot retreat because general is in phase " + TASK_PHASES_ATTACK_BUILDING.toString(GetTaskPhase()));
            }
            return;
        }// end function

        public function GetStartingArmySize() : int
        {
            return this.mStartingArmySize;
        }// end function

        override protected function PerformTaskPhase(param1:int) : void
        {
            var _loc_2:int = 0;
            var _loc_3:cPlayerData = null;
            var _loc_4:cIsoElement = null;
            var _loc_5:cSquad = null;
            if (mGeneralInterface.mLog.isTraceEnabled(LOG_TYPE.MILITARY))
            {
                mGeneralInterface.mLog.logTrace(LOG_TYPE.MILITARY, "cSpecialistTask_AttackBuilding.PerformTaskPhase()");
            }
            if (GetTaskPhase() < TASK_PHASES_ATTACK_BUILDING.RETURN_TO_GARRISON && mGeneralInterface.mCurrentPlayerZone.GetBuildingFromGridPosition(this.mTargetBuildingGridIdx) == null)
            {
                if (this.mTargetBuilding == this.mArmyDestination)
                {
                    this.GoToGarrison();
                    SetTaskPhase(TASK_PHASES_ATTACK_BUILDING.RETURN_TO_GARRISON);
                }
                else
                {
                    if (mGeneralInterface.mLog.isDebugEnabled(LOG_TYPE.MILITARY))
                    {
                        mGeneralInterface.mLog.logDebug(LOG_TYPE.MILITARY, "cSpecialistTask_AttackBuilding.PerformTaskPhase(): next phase: GO_TO_TARGET");
                    }
                    SetTaskPhase(TASK_PHASES_ATTACK_BUILDING.GO_TO_TARGET);
                    this.GoFromTowerToArmyDestination();
                }
            }
            switch(GetTaskPhase())
            {
                case TASK_PHASES_ATTACK_BUILDING.GO_TO_TARGET:
                {
                    if (this.mGeneralRetreated)
                    {
                        this.PerformRetreat();
                        break;
                    }
                    _loc_2 = GetDestinationPath().CalculateGridIdxForPathPos(GetPathPos());
                    IncPathPos(mGeneralInterface.mClientDeltaTime * SPECIALIST_WALK_SPEED);
                    if (_loc_2 >= 0 && _loc_2 < mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list.length)
                    {
                        _loc_4 = mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_2];
                        if (_loc_4.IsWatchedByTowers() && !_loc_4.IsBuildingWatching(this.GetTargetBuilding()) && GetPathPos() / defines.INT_SCALE_FACTOR % 1 < 0.5)
                        {
                            this.GoToEnemyTower(_loc_4, _loc_2);
                            if (mGeneralInterface.mLog.isDebugEnabled(LOG_TYPE.MILITARY))
                            {
                                mGeneralInterface.mLog.logDebug(LOG_TYPE.MILITARY, "cSpecialistTask_AttackBuilding.PerformTaskPhase(): Army was disrupted by tower " + this.mTargetBuildingGridIdx + " at gridIdx " + _loc_2);
                            }
                        }
                    }
                    if (!this.mGeneralRetreated && GetPathPos() >= GetDestinationPath().pathLenX10000)
                    {
                        if (mGeneralInterface.mLog.isDebugEnabled(LOG_TYPE.MILITARY))
                        {
                            mGeneralInterface.mLog.logDebug(LOG_TYPE.MILITARY, "cSpecialistTask_AttackBuilding.PerformTaskPhase(): reached target: " + this.mTargetBuilding + ", GetPathPos():" + GetPathPos() + ", GetDestinationPath().pathLenX10000:" + GetDestinationPath().pathLenX10000 + ", next phase: WAIT_AT_TARGET");
                        }
                        NextPhase();
                    }
                    break;
                }
                case TASK_PHASES_ATTACK_BUILDING.WAIT_AT_TARGET:
                {
                    if (this.mGeneralRetreated)
                    {
                        this.PerformRetreat();
                        break;
                    }
                    else if (this.GetTargetBuilding() == null || !this.GetTargetBuilding().IsEngagedInCombat())
                    {
                        if (mGeneralInterface.mCurrentPlayer.GetPlayerId() == mOwner.GetPlayerID())
                        {
                            globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.GENERAL_STARTET_ATTACK, mOwner);
                        }
                        else
                        {
                            globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.GENERAL_STARTET_ATTACK_VIEWER, mOwner);
                        }
                        mDirtyIndicator = mDirtyIndicator | DIRTY_INDICATOR.DATA_ADDED_BIT;
                        SetCollectedTime(0);
                        if (mGeneralInterface.mLog.isDebugEnabled(LOG_TYPE.MILITARY))
                        {
                            mGeneralInterface.mLog.logDebug(LOG_TYPE.MILITARY, "cSpecialistTask_AttackBuilding.PerformTaskPhase(): next phase: ATTACK_TARGET");
                        }
                        NextPhase();
                        this.StartBattleAnimationOnMap(this.mTargetBuilding);
                        globalFlash.gui.mSpecialistPanel.Refresh(mOwner);
                        this.mTargetBuilding.SetIsEngagedInCombat(true);
                    }
                    break;
                }
                case TASK_PHASES_ATTACK_BUILDING.ATTACK_TARGET:
                {
                    if (this.mGeneralRetreated)
                    {
                        this.PerformRetreat();
                        break;
                    }
                    _loc_3 = null;
                    if (!this.mGeneralRetreated && this.mBattleResultVO != null && this.mBattleResultVO.buildingHitPoints <= 0)
                    {
                        if (this.mTimeToReduceOneDamageLevel == -1)
                        {
                            this.mHitPointsOfOneDamageLevel = this.mTargetBuilding.GetMaxHitPoints() / cBuilding.DAMAGE_LEVEL_AMOUNT;
                            this.mTimeToReduceOneDamageLevel = (this.mBattleResultVO.combatDuration - this.mBattleResultVO.unitFightDuration) / cBuilding.DAMAGE_LEVEL_AMOUNT;
                            this.mTimeOfNextDamageLevel = this.mBattleResultVO.unitFightDuration + this.mTimeToReduceOneDamageLevel;
                        }
                        while (GetCollectedTime() >= this.mTimeOfNextDamageLevel && this.mTargetBuilding.GetCurrentHitPoints() - this.mHitPointsOfOneDamageLevel > 0)
                        {
                            
                            if (mGeneralInterface.mLog.isDebugEnabled(LOG_TYPE.MILITARY))
                            {
                                mGeneralInterface.mLog.logDebug(LOG_TYPE.MILITARY, "cSpecialistTask_AttackBuilding.PerformTaskPhase(): calculating building battle!");
                            }
                            if (_loc_3 == null)
                            {
                                _loc_3 = mGeneralInterface.FindPlayerFromId(mOwner.GetPlayerID());
                                gMisc.Assert(_loc_3 != null, "Could not find player with ID " + mOwner.GetPlayerID());
                            }
                            this.mTargetBuilding.DamageBuilding(this.mHitPointsOfOneDamageLevel, _loc_3);
                            this.mTimeOfNextDamageLevel = this.mTimeOfNextDamageLevel + this.mTimeToReduceOneDamageLevel;
                        }
                    }
                    if (!this.mGeneralRetreated && this.mBattleResultVO != null && GetCollectedTime() >= this.mBattleResultVO.combatDuration)
                    {
                        this.HandleApplyBattleResult();
                    }
                    break;
                }
                case TASK_PHASES_ATTACK_BUILDING.RETURN_TO_GARRISON:
                {
                    IncPathPos(mGeneralInterface.mClientDeltaTime * SPECIALIST_WALK_SPEED);
                    if (GetDestinationPath() == null || GetPathPos() >= GetDestinationPath().pathLenX20000)
                    {
                        NextPhase();
                    }
                    break;
                }
                case TASK_PHASES_ATTACK_BUILDING.WAIT_FOR_ORDERS:
                {
                    if (!mOwner.GetArmy().HasUnits())
                    {
                        if (mGeneralInterface.mCurrentPlayer.GetPlayerId() == mOwner.GetPlayerID())
                        {
                            globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.GENERAL_FINISHED_NEGATIVE, mOwner);
                        }
                        else
                        {
                            globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.GENERAL_FINISHED_NEGATIVE_VIEWER, mOwner);
                        }
                        mOwner.SetTask(new cSpecialistTask_Recover(mGeneralInterface, mOwner, 0, TASK_PHASES_RECOVER.RECOVER));
                    }
                    else
                    {
                        if (mGeneralInterface.mCurrentPlayer.GetPlayerId() == mOwner.GetPlayerID())
                        {
                            globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.GENERAL_FINISHED_POSITIVE, mOwner);
                        }
                        else
                        {
                            globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.GENERAL_FINISHED_POSITIVE_VIEWER, mOwner);
                        }
                        mOwner.SetTask(null);
                    }
                    for each (_loc_5 in mOwner.GetArmy().GetSquads_vector())
                    {
                        
                        (_loc_7[_loc_6]).Heal(_loc_5.GetUnitDescription().GetHitPoints());
                    }
                    RemoveSettler();
                    globalFlash.gui.mSpecialistPanel.Refresh(mOwner);
                    break;
                }
                default:
                {
                    gMisc.Assert(false, "Could not interpret task phase " + GetTaskPhase() + "!");
                    break;
                }
            }
            return;
        }// end function

        public function HandleRetreat() : void
        {
            if (mGeneralInterface.mLog.isInfoEnabled(LOG_TYPE.MILITARY))
            {
                mGeneralInterface.mLog.logInfo(LOG_TYPE.MILITARY, "cSpecialistTask_AttackBuilding.HandleRetreat() in phase: " + TASK_PHASES_ATTACK_BUILDING.toString(GetTaskPhase()) + " at mCollectedTime:" + mCollectedTime);
            }
            if (GetTaskPhase() != TASK_PHASES_ATTACK_BUILDING.ATTACK_TARGET || mCollectedTime <= defines.GAMETICK_SYSTEM_POSTPROCESS_TIME_MIN)
            {
                this.mGeneralRetreated = true;
                this.mBattleResultVO = null;
            }
            return;
        }// end function

        private function GoToEnemyTower(param1:cIsoElement, param2:int) : void
        {
            var _loc_4:cPathObject = null;
            var _loc_5:int = 0;
            if (mGeneralInterface.mLog.isTraceEnabled(LOG_TYPE.MILITARY))
            {
                mGeneralInterface.mLog.logTrace(LOG_TYPE.MILITARY, "cSpecialistTask_AttackBuilding.GoToEnemyTower()");
            }
            var _loc_3:* = param1.GetReadyTowerGridIdxs();
            if (_loc_3.length > 0)
            {
                _loc_4 = mGeneralInterface.mPathFinder.CalculatePathForDestinations(param2, _loc_3, mGeneralInterface.FindPlayerFromId(mOwner.GetPlayerID()).GetPlayerId());
                if (_loc_4.dest_vector.length > 0)
                {
                    _loc_4.dest_vector.reverse();
                    SetDestinationPath(_loc_4);
                    _loc_5 = gCalculations.MoveStreetGridToDir8(_loc_4.dest_vector[(_loc_4.dest_vector.length - 1)].streetGridIdx, defines.DIR8_NORTH_WEST);
                    this.mTargetBuildingGridIdx = _loc_5;
                    this.mTargetBuilding = mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_5].mBuilding;
                    mDirtyIndicator = mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
                }
                else
                {
                    if (mGeneralInterface.mLog.isDebugEnabled(LOG_TYPE.MILITARY))
                    {
                        mGeneralInterface.mLog.logDebug(LOG_TYPE.MILITARY, "cSpecialistTask_AttackBuilding.GoToEnemyTower(): Could not find path from " + param2 + " to " + _loc_3 + ". Going back to garrison.");
                    }
                    this.GoToGarrison();
                }
                SetPathPos(0);
            }
            return;
        }// end function

        private function HandleApplyBattleResult() : void
        {
            if (this.mGeneralRetreated)
            {
                if (mGeneralInterface.mLog.isDebugEnabled(LOG_TYPE.MILITARY))
                {
                    mGeneralInterface.mLog.logDebug(LOG_TYPE.MILITARY, "cSpecialistTask_AttackBuilding.HandleApplyBattleResult() perform retreat!");
                }
                this.PerformRetreat();
                return;
            }
            if (this.mBattleResultVO == null)
            {
                if (mGeneralInterface.mLog.isErrorEnabled(LOG_TYPE.MILITARY))
                {
                    mGeneralInterface.mLog.logError(LOG_TYPE.MILITARY, "cSpecialistTask_AttackBuilding.HandleApplyBattleResult(): no battle result found!");
                }
                this.PerformRetreat();
                return;
            }
            if (mGeneralInterface.mLog.isDebugEnabled(LOG_TYPE.MILITARY))
            {
                mGeneralInterface.mLog.logDebug(LOG_TYPE.MILITARY, "cSpecialistTask_AttackBuilding.HandleApplyBattleResult()");
            }
            this.EndBattleAnimationOnMap(this.mTargetBuilding);
            mOwner.GetArmy().ApplyArmyVO(this.mBattleResultVO.attackingArmyVO);
            mOwner.GetArmy().RemoveUnits(mOwner.GetSpecialistDescription().GetMilitaryUnitType_string(), 1);
            this.mTargetBuilding.GetArmy().ApplyArmyVO(this.mBattleResultVO.defendingArmyVO);
            var _loc_1:* = mGeneralInterface.FindPlayerFromId(mOwner.GetPlayerID());
            gMisc.Assert(_loc_1 != null, "Could not find player with ID " + mOwner.GetPlayerID());
            var _loc_2:* = mGeneralInterface.mCurrentPlayerZone.GetResources(_loc_1);
            if (_loc_2 != null)
            {
                _loc_2.FreeMilitary(this.mBattleResultVO.lostPopulationAttacker);
                _loc_2.RemovePlayerResourcesFromResourcesInList(onePopulation_vector, this.mBattleResultVO.lostPopulationAttacker);
            }
            mOwner.IncUnitsDefeated(this.mBattleResultVO.casualtiesDefender);
            _loc_1.AddXP(this.mBattleResultVO.gainedXp);
            if (this.mBattleResultVO.buildingHitPoints <= 0)
            {
                this.mTargetBuilding.DamageBuilding(this.mTargetBuilding.GetCurrentHitPoints(), _loc_1);
            }
            else
            {
                this.mTargetBuilding.DamageBuilding(this.mTargetBuilding.GetCurrentHitPoints() - this.mBattleResultVO.buildingHitPoints, _loc_1);
            }
            if (this.mTargetBuilding.GetCurrentHitPoints() <= 0)
            {
                mOwner.IncBuildingsDestroyed();
            }
            switch(this.mBattleResultVO.battleResult)
            {
                case BATTLE_RESULT.GENERAL_WON_AND_CONTINUES:
                {
                    if (mGeneralInterface.mCurrentPlayer.GetPlayerId() == mOwner.GetPlayerID())
                    {
                        globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.GENERAL_WON_AND_CONTINUES, mOwner);
                    }
                    else
                    {
                        globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.GENERAL_WON_AND_CONTINUES_VIEWER, mOwner);
                    }
                    SetTaskPhase(TASK_PHASES_ATTACK_BUILDING.GO_TO_TARGET);
                    this.mBattleResultVO = null;
                    this.GoFromTowerToArmyDestination();
                    break;
                }
                case BATTLE_RESULT.GENERAL_WON_AND_RETURNS:
                {
                    if (mGeneralInterface.mCurrentPlayer.GetPlayerId() == mOwner.GetPlayerID())
                    {
                        globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.GENERAL_WON_AND_RETURNS, mOwner);
                    }
                    else
                    {
                        globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.GENERAL_WON_AND_RETURNS_VIEWER, mOwner);
                    }
                    this.mBattleResultVO = null;
                    this.GoToGarrison();
                    NextPhase();
                    break;
                }
                case BATTLE_RESULT.GENERAL_LOST:
                {
                    if (mGeneralInterface.mCurrentPlayer.GetPlayerId() == mOwner.GetPlayerID())
                    {
                        globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.GENERAL_LOST, mOwner);
                    }
                    else
                    {
                        globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.GENERAL_LOST_VIEWER, mOwner);
                    }
                    this.mBattleResultVO = null;
                    this.GoToGarrison();
                    SetTaskPhase(TASK_PHASES_ATTACK_BUILDING.RETURN_TO_GARRISON);
                    this.mTargetBuilding.SetIsEngagedInCombat(false);
                    this.EndBattleAnimationOnMap(this.mTargetBuilding);
                    globalFlash.gui.mSpecialistPanel.Refresh(mOwner);
                    break;
                }
                default:
                {
                    if (mGeneralInterface.mLog.isDebugEnabled(LOG_TYPE.MILITARY))
                    {
                        mGeneralInterface.mLog.logDebug(LOG_TYPE.MILITARY, "cSpecialistTask_AttackBuilding.ApplyBattleResult(): battleResult:" + BATTLE_RESULT.toString(this.mBattleResultVO.battleResult));
                    }
                    gMisc.Assert(false, "Could not interpret battle result " + this.mBattleResultVO.battleResult);
                    break;
                }
            }
            return;
        }// end function

        override protected function CheckSettler() : void
        {
            if (mGeneralInterface.mLog.isTraceEnabled(LOG_TYPE.MILITARY))
            {
                mGeneralInterface.mLog.logTrace(LOG_TYPE.MILITARY, "cSpecialistTask_AttackBuilding.CheckSettler()");
            }
            switch(GetTaskPhase())
            {
                case TASK_PHASES_ATTACK_BUILDING.WAIT_FOR_ORDERS:
                {
                    if (GetSettler() != null)
                    {
                        RemoveSettler();
                    }
                    break;
                }
                case TASK_PHASES_ATTACK_BUILDING.WAIT_AT_TARGET:
                case TASK_PHASES_ATTACK_BUILDING.GO_TO_TARGET:
                case TASK_PHASES_ATTACK_BUILDING.ATTACK_TARGET:
                case TASK_PHASES_ATTACK_BUILDING.RETURN_TO_GARRISON:
                {
                    if (GetSettler() == null)
                    {
                        SpawnSettler(0, 0);
                    }
                    break;
                }
                default:
                {
                    if (mGeneralInterface.mLog.isErrorEnabled(LOG_TYPE.MILITARY))
                    {
                        mGeneralInterface.mLog.logError(LOG_TYPE.MILITARY, "cSpecialistTask_AttackBuilding.CheckSettler(): Could not interpret task phase " + GetTaskPhase());
                    }
                    break;
                    break;
                }
            }
            return;
        }// end function

        public static function CreateTaskFromVO(param1:cGeneralInterface, param2:dSpecialistTask_AttackBuildingVO, param3:cSpecialist) : cSpecialistTask_AttackBuilding
        {
            var _loc_4:* = new cSpecialistTask_AttackBuilding(param1, param3, param2.targetBuildingGridPos, param2.attackBuildingMode, param2.collectedTime, param2.phase);
            new cSpecialistTask_AttackBuilding(param1, param3, param2.targetBuildingGridPos, param2.attackBuildingMode, param2.collectedTime, param2.phase).SetPathPos(param2.pathPos);
            _loc_4.mArmyDestinationGridIdx = param2.armyDestinationBuildingGridPos;
            _loc_4.mArmyDestination = param1.mCurrentPlayerZone.GetBuildingFromGridPosition(_loc_4.mArmyDestinationGridIdx);
            _loc_4.mStartingArmySize = param2.startingArmySize;
            _loc_4.mBattleResultVO = param2.battleResultVO;
            _loc_4.mGeneralRetreated = false;
            _loc_4.CheckSettler();
            if (param2.phase == TASK_PHASES_ATTACK_BUILDING.ATTACK_TARGET)
            {
                _loc_4.SetPathPos(_loc_4.GetDestinationPath().pathLenX10000);
                _loc_4.StartBattleAnimationOnMap(_loc_4.mTargetBuilding);
            }
            return _loc_4;
        }// end function

    }
}
