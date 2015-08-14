package unitTest
{
    import Enums.*;
    import GO.*;
    import Interface.*;
    import Specialists.*;
    import __AS3__.vec.*;
    import nLib.*;

    public class cTestKI extends Object
    {
        private var mLoopStartCntr:int;
        public var mRandomCreateBuildings:Boolean = false;
        public var mSpecialistBought:Boolean = false;
        public var mPlayGame:Boolean = false;
        public var mPlayGameCntr:int;
        private var mLoopStartLoops:int;
        private var mPlayGame_vector:Vector.<cTestKiElement> = null;
        private var mRandomCreateBuildingsCntr:int;
        private var mGeneralInterface:cGeneralInterface;
        public static const TESTKI_ELEMENT_TYPE_SPECIALIST_EXPLORER_EXPLORE_NEW_SECTOR:int = 81;
        public static const TESTKI_ELEMENT_TYPE_QUEST_SELECT_BUILDING:int = 60;
        public static const TESTKI_ELEMENT_TYPE_SPECIALIST_BUY:int = 70;
        public static const TESTKI_ELEMENT_TYPE_KLICK_QUEST_REWARD_OK:int = 30;
        private static var mX:int;
        public static const TESTKI_ELEMENT_TYPE_LOOP_END:int = 100;
        public static const TESTKI_ELEMENT_GRID_SUITABLE:int = -10;
        public static const PROTOKOLL_PLAYGAME:Boolean = true;
        public static const TESTKI_ELEMENT_TYPE_KLICK_QUEST_OK:int = 40;
        public static const TESTKI_ELEMENT_TYPE_LOOP_START:int = 90;
        public static const TESTKI_ELEMENT_TYPE_CHEAT:int = 110;
        public static const TESTKI_ELEMENT_TYPE_KLICK_QUEST_OK_OR_CONTINUE_IF_ALREADY_RUNNUNG:int = 50;
        public static const TESTKI_ELEMENT_TYPE_DESTRUCT_BUILDING:int = 11;
        public static const TESTKI_ELEMENT_TYPE_NONE:int = 0;
        public static const TESTKI_ELEMENT_TYPE_WAIT_UNTIL_BUILDING_IS_FINISHED:int = 20;
        public static const TESTKI_ELEMENT_TYPE_KLICK_QUEST_REWARD_OK_OR_CONTINUE_IF_ALREADY_RUNNUNG:int = 31;
        public static const TESTKI_ELEMENT_TYPE_BUILD_BUILDING:int = 10;
        public static const TESTKI_ELEMENT_TYPE_SPECIALIST_GEOLOGIST_FIND_DEPOSIT:int = 80;

        public function cTestKI(param1:cGeneralInterface)
        {
            this.mGeneralInterface = param1;
            return;
        }// end function

        private function DestructBuilding() : Boolean
        {
            var _loc_1:int = 0;
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            var _loc_17:cVectorListInt = null;
            var _loc_18:cIsoElement = null;
            var _loc_19:int = 0;
            _loc_1 = defines.STREET_MAP_MIN_USABLE_AREA_X;
            _loc_2 = defines.STREET_MAP_MIN_USABLE_AREA_Y;
            _loc_3 = defines.STREET_MAP_MAX_USABLE_AREA_X;
            _loc_4 = defines.STREET_MAP_MAX_USABLE_AREA_Y;
            var _loc_5:int = 0;
            var _loc_8:Boolean = false;
            var _loc_9:int = 0;
            var _loc_10:int = -1;
            var _loc_11:* = new cPosInt();
            var _loc_12:* = new cPosInt();
            var _loc_13:* = gMisc.GetMaxIntValue();
            var _loc_14:int = -1;
            var _loc_15:int = -1;
            var _loc_16:int = -1;
            _loc_9 = 0;
            _loc_7 = _loc_2;
            while (_loc_7 <= _loc_4)
            {
                
                _loc_5 = (_loc_7 << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + _loc_1;
                _loc_17 = gCalculations.m8DirectionTableStreetGridDirection_vector[_loc_7 & 1];
                _loc_6 = _loc_1;
                while (_loc_6 <= _loc_3)
                {
                    
                    _loc_18 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_5];
                    if (_loc_18.mBuilding != null)
                    {
                        if (_loc_18.mBuilding.IsBuildingActive())
                        {
                            if (!this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.IsFogAtGridPosition(_loc_18.mGridIdx))
                            {
                                if (!_loc_18.mBuilding.IsWarehouseType())
                                {
                                    _loc_19 = this.mGeneralInterface.mCurrentPlayerZone.mSectorList_vector[_loc_18.mSectorId].GetOwnerPlayerID();
                                    if (_loc_18.mBuilding.GetPlayerID() == _loc_19)
                                    {
                                        this.mGeneralInterface.mCurrentPlayerZone.SendDestructBuildingCommand(_loc_18.mGridIdx);
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                    _loc_5++;
                    _loc_6++;
                }
                _loc_7++;
            }
            return false;
        }// end function

        public function ActivateRandomCreateBuildings() : void
        {
            this.mRandomCreateBuildings = !this.mRandomCreateBuildings;
            this.mRandomCreateBuildingsCntr = 0;
            return;
        }// end function

        public function Compute() : void
        {
            var _loc_1:cSpecialist = null;
            var _loc_2:cTestKiElement = null;
            var _loc_3:Boolean = false;
            var _loc_4:String = null;
            var _loc_5:int = 0;
            var _loc_6:Array = null;
            var _loc_7:cIsoElement = null;
            var _loc_8:cPosInt = null;
            var _loc_9:cSpecialistTask_FindDeposit = null;
            if (this.mPlayGame)
            {
                if (this.mPlayGameCntr >= this.mPlayGame_vector.length)
                {
                    if (PROTOKOLL_PLAYGAME)
                    {
                        gMisc.ConsoleOut("PLAYGAME -> end");
                    }
                    this.mPlayGame = false;
                    return;
                }
                _loc_2 = this.mPlayGame_vector[this.mPlayGameCntr];
                switch(_loc_2.mType)
                {
                    case TESTKI_ELEMENT_TYPE_BUILD_BUILDING:
                    {
                        _loc_3 = this.mGeneralInterface.mCurrentPlayerZone.mShowErrorMessageIsBuildingPlacable;
                        this.mGeneralInterface.mCurrentPlayerZone.mShowErrorMessageIsBuildingPlacable = false;
                        if (!this.mGeneralInterface.mCurrentPlayer.mBuildQueue.IsFull() && !this.mGeneralInterface.mCurrentPlayer.mBuildQueue.IsBlockedUntilBuildQueueIsProceed())
                        {
                            _loc_5 = -1;
                            _loc_6 = _loc_2.mString.split(/\,""\,/);
                            if (_loc_6.length == 1)
                            {
                                _loc_4 = _loc_2.mString;
                            }
                            else
                            {
                                _loc_4 = _loc_6[0];
                                _loc_5 = gMisc.ParseInt(_loc_6[1]);
                            }
                            this.mGeneralInterface.mCurrentCursor.SetCursorEditMode(COMMAND.SET_BUILDING_IN_GAME);
                            this.mGeneralInterface.mCurrentCursor.SetCursor(OBJECTTYPE.BUILDING, _loc_4);
                            if (_loc_5 == -1)
                            {
                                _loc_7 = this.SetCurrentCursorObjectOnPossibleBuildplace();
                            }
                            else
                            {
                                _loc_7 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_5];
                                _loc_8 = new cPosInt();
                                gCalculations.ConvertStreetGridToPixelPos(_loc_7.mGridIdx, _loc_8);
                                this.mGeneralInterface.mCurrentCursor.SetPosition(_loc_8.x, _loc_8.y + global.streetGridYHalf);
                                if (this.mGeneralInterface.mCurrentCursor.IsCursorValid())
                                {
                                    this.mGeneralInterface.mSetBuildings.MouseClickOnMap(this.mGeneralInterface.mCurrentPlayer, this.mGeneralInterface.mCurrentPlayerZone);
                                }
                                else
                                {
                                    _loc_7 = null;
                                }
                            }
                            if (_loc_7 == null)
                            {
                                gMisc.ConsoleOut("PLAYGAME No suitable buildplace ");
                            }
                            if (PROTOKOLL_PLAYGAME)
                            {
                                gMisc.ConsoleOut("PLAYGAME TESTKI_ELEMENT_TYPE_BUILD_BUILDING finished -> Next Command");
                            }
                            var _loc_10:String = this;
                            var _loc_11:* = this.mPlayGameCntr + 1;
                            _loc_10.mPlayGameCntr = _loc_11;
                        }
                        this.mGeneralInterface.mCurrentPlayerZone.mShowErrorMessageIsBuildingPlacable = _loc_3;
                        break;
                    }
                    case TESTKI_ELEMENT_TYPE_DESTRUCT_BUILDING:
                    {
                        if (!this.DestructBuilding())
                        {
                            gMisc.ConsoleOut("PLAYGAME No suitable buildplace -> No Building found");
                        }
                        if (PROTOKOLL_PLAYGAME)
                        {
                            gMisc.ConsoleOut("PLAYGAME TESTKI_ELEMENT_TYPE_DESTRUCT_BUILDING finished -> Next Command");
                        }
                        var _loc_10:String = this;
                        var _loc_11:* = this.mPlayGameCntr + 1;
                        _loc_10.mPlayGameCntr = _loc_11;
                        break;
                    }
                    case TESTKI_ELEMENT_TYPE_KLICK_QUEST_REWARD_OK:
                    {
                        break;
                    }
                    case TESTKI_ELEMENT_TYPE_KLICK_QUEST_REWARD_OK_OR_CONTINUE_IF_ALREADY_RUNNUNG:
                    {
                        break;
                    }
                    case TESTKI_ELEMENT_TYPE_KLICK_QUEST_OK:
                    {
                        break;
                    }
                    case TESTKI_ELEMENT_TYPE_KLICK_QUEST_OK_OR_CONTINUE_IF_ALREADY_RUNNUNG:
                    {
                        break;
                    }
                    case TESTKI_ELEMENT_TYPE_QUEST_SELECT_BUILDING:
                    {
                        break;
                    }
                    case TESTKI_ELEMENT_TYPE_SPECIALIST_BUY:
                    {
                        break;
                    }
                    case TESTKI_ELEMENT_TYPE_SPECIALIST_GEOLOGIST_FIND_DEPOSIT:
                    {
                        for each (_loc_1 in this.mGeneralInterface.mCurrentPlayerZone.GetSpecialists_vector())
                        {
                            
                            if (_loc_1.GetType() == SPECIALIST_TYPE.GEOLOGIST)
                            {
                                _loc_9 = new cSpecialistTask_FindDeposit(this.mGeneralInterface, _loc_1, _loc_2.mString, 0, TASK_PHASES_FIND_DEPOSIT.SEARCH_DEPOSIT);
                                _loc_1.SetTask(_loc_9);
                                if (PROTOKOLL_PLAYGAME)
                                {
                                    gMisc.ConsoleOut("PLAYGAME TESTKI_ELEMENT_TYPE_SPECIALIST_GEOLOGIST_FIND_DEPOSIT finished -> Next Command");
                                }
                                var _loc_12:String = this;
                                var _loc_13:* = this.mPlayGameCntr + 1;
                                _loc_12.mPlayGameCntr = _loc_13;
                                break;
                            }
                        }
                        break;
                    }
                    case TESTKI_ELEMENT_TYPE_SPECIALIST_EXPLORER_EXPLORE_NEW_SECTOR:
                    {
                        for each (_loc_1 in this.mGeneralInterface.mCurrentPlayerZone.GetSpecialists_vector())
                        {
                            
                            if (_loc_1.GetType() == SPECIALIST_TYPE.EXPLORER)
                            {
                                if (_loc_1.GetTask() == null)
                                {
                                    _loc_1.SetTask(new cSpecialistTask_ExploreSector(this.mGeneralInterface, _loc_1, 0, TASK_PHASES_EXPLORE_SECTOR.EXPLORE_SECTOR));
                                }
                                else if (_loc_1.GetTask().GetTaskPhase() == TASK_PHASES_EXPLORE_SECTOR.WAIT_FOR_ORDERS)
                                {
                                    if (PROTOKOLL_PLAYGAME)
                                    {
                                        gMisc.ConsoleOut("PLAYGAME TESTKI_ELEMENT_TYPE_SPECIALIST_EXPLORER_EXPLORE_NEW_SECTOR finished -> Next Command");
                                    }
                                    var _loc_12:String = this;
                                    var _loc_13:* = this.mPlayGameCntr + 1;
                                    _loc_12.mPlayGameCntr = _loc_13;
                                }
                                break;
                            }
                        }
                        break;
                    }
                    case TESTKI_ELEMENT_TYPE_LOOP_START:
                    {
                        this.mLoopStartCntr = this.mPlayGameCntr + 1;
                        this.mLoopStartLoops = gMisc.ParseInt(_loc_2.mString);
                        if (PROTOKOLL_PLAYGAME)
                        {
                            gMisc.ConsoleOut("PLAYGAME TESTKI_ELEMENT_TYPE_LOOP_START finished -> Next Command");
                        }
                        var _loc_10:String = this;
                        var _loc_11:* = this.mPlayGameCntr + 1;
                        _loc_10.mPlayGameCntr = _loc_11;
                        break;
                    }
                    case TESTKI_ELEMENT_TYPE_LOOP_END:
                    {
                        var _loc_10:String = this;
                        var _loc_11:* = this.mLoopStartLoops - 1;
                        _loc_10.mLoopStartLoops = _loc_11;
                        if (this.mLoopStartLoops > 0)
                        {
                            this.mPlayGameCntr = this.mLoopStartCntr;
                        }
                        else
                        {
                            if (PROTOKOLL_PLAYGAME)
                            {
                                gMisc.ConsoleOut("PLAYGAME TESTKI_ELEMENT_TYPE_LOOP_END finished -> Next Command");
                            }
                            var _loc_10:String = this;
                            var _loc_11:* = this.mPlayGameCntr + 1;
                            _loc_10.mPlayGameCntr = _loc_11;
                        }
                        break;
                    }
                    case TESTKI_ELEMENT_TYPE_CHEAT:
                    {
                        this.mGeneralInterface.mClientMessages.SendMessagetoServer(COMMAND.RESOURCES_CHEAT, this.mGeneralInterface.mCurrentViewedZoneID, null);
                        if (PROTOKOLL_PLAYGAME)
                        {
                            gMisc.ConsoleOut("PLAYGAME TESTKI_ELEMENT_TYPE_CHEAT finished -> Next Command");
                        }
                        var _loc_10:String = this;
                        var _loc_11:* = this.mPlayGameCntr + 1;
                        _loc_10.mPlayGameCntr = _loc_11;
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
            if (this.mRandomCreateBuildings)
            {
                var _loc_10:String = this;
                var _loc_11:* = this.mRandomCreateBuildingsCntr + 1;
                _loc_10.mRandomCreateBuildingsCntr = _loc_11;
                if (this.mRandomCreateBuildingsCntr > 50)
                {
                    this.mRandomCreateBuildingsCntr = 0;
                    if (!this.mGeneralInterface.mCurrentPlayer.mBuildQueue.IsFull())
                    {
                        this.mGeneralInterface.mCurrentCursor.SetCursorEditMode(COMMAND.SET_BUILDING_IN_GAME);
                        this.mGeneralInterface.mCurrentCursor.SetCursor(OBJECTTYPE.BUILDING, "WoodCutter");
                        this.SetCurrentCursorObjectOnPossibleBuildplace();
                    }
                }
            }
            return;
        }// end function

        public function Init() : void
        {
            return;
        }// end function

        private function SetCurrentCursorObjectOnPossibleBuildplace() : cIsoElement
        {
            var _loc_1:int = 0;
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            var _loc_13:int = 0;
            var _loc_14:int = 0;
            var _loc_25:cVectorListInt = null;
            var _loc_26:cIsoElement = null;
            var _loc_27:int = 0;
            var _loc_28:int = 0;
            var _loc_29:int = 0;
            _loc_1 = defines.STREET_MAP_MIN_USABLE_AREA_X;
            _loc_2 = defines.STREET_MAP_MIN_USABLE_AREA_Y;
            _loc_3 = defines.STREET_MAP_MAX_USABLE_AREA_X;
            _loc_4 = defines.STREET_MAP_MAX_USABLE_AREA_Y;
            var _loc_5:int = 117;
            var _loc_6:int = 72;
            var _loc_7:* = _loc_5 / 2;
            var _loc_8:* = _loc_6 / 2;
            var _loc_11:* = _loc_5 * _loc_1;
            var _loc_12:int = 0;
            var _loc_15:Boolean = false;
            var _loc_16:int = 0;
            var _loc_17:int = -1;
            var _loc_18:* = new cPosInt();
            var _loc_19:* = new cPosInt();
            var _loc_20:* = gMisc.GetMaxIntValue();
            var _loc_21:int = -1;
            var _loc_22:int = -1;
            var _loc_23:int = -1;
            var _loc_24:int = 0;
            while (_loc_24 < 3)
            {
                
                _loc_9 = 0;
                _loc_10 = _loc_8 * _loc_2;
                _loc_16 = 0;
                _loc_14 = _loc_2;
                while (_loc_14 <= _loc_4)
                {
                    
                    if ((_loc_14 & 1) == 0)
                    {
                        _loc_9 = -_loc_7 + _loc_11;
                    }
                    else
                    {
                        _loc_9 = _loc_11;
                    }
                    _loc_12 = (_loc_14 << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + _loc_1;
                    _loc_25 = gCalculations.m8DirectionTableStreetGridDirection_vector[_loc_14 & 1];
                    _loc_13 = _loc_1;
                    while (_loc_13 <= _loc_3)
                    {
                        
                        _loc_26 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_12];
                        if (_loc_24 == 0)
                        {
                            if (_loc_26.mBuilding != null && _loc_26.mBuilding.GetBuildingName_string() == defines.MAYORHOUSE_NAME_string)
                            {
                                _loc_19.x = _loc_9;
                                _loc_19.y = _loc_10;
                            }
                        }
                        else if (_loc_26.mBuilding == null && _loc_26.IsBlockedAllowedAll())
                        {
                            this.mGeneralInterface.mCurrentCursor.SetPosition(_loc_9, _loc_10 + global.streetGridYHalf);
                            if (this.mGeneralInterface.mCurrentCursor.IsCursorValid())
                            {
                                if (_loc_24 == 1)
                                {
                                    _loc_27 = _loc_19.x - _loc_9;
                                    _loc_28 = _loc_19.y - _loc_10;
                                    _loc_29 = _loc_27 * _loc_27 + _loc_28 * _loc_28;
                                    if (_loc_29 < _loc_20)
                                    {
                                        _loc_20 = _loc_29;
                                        _loc_21 = _loc_16;
                                    }
                                    if (_loc_29 > _loc_22)
                                    {
                                        _loc_22 = _loc_29;
                                        _loc_23 = _loc_16;
                                    }
                                }
                                else if (_loc_16 == _loc_21)
                                {
                                    this.mGeneralInterface.mSetBuildings.MouseClickOnMap(this.mGeneralInterface.mCurrentPlayer, this.mGeneralInterface.mCurrentPlayerZone);
                                    return _loc_26;
                                }
                                _loc_16++;
                            }
                        }
                        _loc_9 = _loc_9 + _loc_5;
                        _loc_12++;
                        _loc_13++;
                    }
                    _loc_10 = _loc_10 + _loc_8;
                    _loc_14++;
                }
                _loc_24++;
            }
            return null;
        }// end function

        public function ActivatePlayGame(param1:String) : void
        {
            this.CreateTestPlayGame();
            this.mPlayGameCntr = 0;
            this.mPlayGame = true;
            this.mSpecialistBought = false;
            this.mLoopStartCntr = -1;
            return;
        }// end function

        public function DeactivatePlayGame() : void
        {
            this.mPlayGame = false;
            return;
        }// end function

        private function CreateTestPlayGame() : void
        {
            this.mPlayGame_vector = new Vector.<cTestKiElement>;
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_CHEAT, ""));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_CHEAT, ""));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_CHEAT, ""));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_CHEAT, ""));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_CHEAT, ""));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_CHEAT, ""));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_CHEAT, ""));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_CHEAT, ""));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_KLICK_QUEST_OK_OR_CONTINUE_IF_ALREADY_RUNNUNG, null));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_BUILD_BUILDING, "WoodCutter"));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_KLICK_QUEST_REWARD_OK, null));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_KLICK_QUEST_OK, null));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_BUILD_BUILDING, "Sawmill"));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_KLICK_QUEST_REWARD_OK, null));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_KLICK_QUEST_OK, null));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_BUILD_BUILDING, "Forester"));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_KLICK_QUEST_REWARD_OK, null));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_KLICK_QUEST_OK, null));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_BUILD_BUILDING, "SimpleResidence"));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_KLICK_QUEST_REWARD_OK, null));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_KLICK_QUEST_OK, null));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_SPECIALIST_BUY, "Explorer"));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_SPECIALIST_EXPLORER_EXPLORE_NEW_SECTOR, null));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_BUILD_BUILDING, "Warehouse,4880"));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_LOOP_START, "500"));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_BUILD_BUILDING, "WoodCutter"));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_BUILD_BUILDING, "Sawmill"));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_BUILD_BUILDING, "Forester"));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_BUILD_BUILDING, "SimpleResidence"));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_CHEAT, ""));
            this.mPlayGame_vector.push(new cTestKiElement(TESTKI_ELEMENT_TYPE_LOOP_END, null));
            return;
        }// end function

        private static function setmX(param1:int) : void
        {
            mX = mX + param1;
            return;
        }// end function

        private static function getmX() : int
        {
            return mX;
        }// end function

        public static function SpeedTests() : void
        {
            var _loc_1:int = 0;
            var _loc_2:Number = NaN;
            var _loc_3:Number = NaN;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_4:int = 0;
            while (_loc_4 < 3)
            {
                
                _loc_2 = gMisc.GetTimeSinceStartup();
                _loc_1 = 0;
                mX = 0;
                _loc_5 = 0;
                while (_loc_5 < 1000000)
                {
                    
                    _loc_1 = _loc_1 + mX;
                    var _loc_8:* = mX + 1;
                    mX = _loc_8;
                    _loc_5++;
                }
                _loc_3 = gMisc.GetTimeSinceStartup() - _loc_2;
                gMisc.ConsoleOut("Without Getter Time: " + _loc_3 + " Test:" + _loc_1);
                _loc_2 = gMisc.GetTimeSinceStartup();
                _loc_1 = 0;
                mX = 0;
                _loc_6 = 0;
                while (_loc_6 < 1000000)
                {
                    
                    _loc_1 = _loc_1 + getmX();
                    setmX((getmX() + 1));
                    _loc_6++;
                }
                _loc_3 = gMisc.GetTimeSinceStartup() - _loc_2;
                gMisc.ConsoleOut("With Getter Time: " + _loc_3 + " Test:" + _loc_1);
                _loc_4++;
            }
            return;
        }// end function

    }
}
