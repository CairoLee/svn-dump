package PathFinding
{
    import Interface.*;
    import __AS3__.vec.*;
    import nLib.*;

    public class cCreatePath extends Object
    {
        private var mGeneralInterface:cGeneralInterface;
        public var costMatrix_list:Vector.<int>;
        public static const WAYPOINT_DEST:int = 65535;
        public static const WAYPOINT_START:int = 65534;
        public static const WAYPOINT_UNSET:int = 65532;
        public static const WAYPOINT_BLOCKED:int = 65533;
        public static const MAX_PATH_LEN:int = 500;

        public function cCreatePath(param1:cGeneralInterface)
        {
            this.mGeneralInterface = param1;
            return;
        }// end function

        public function GetNearestDestinationGridIdx(param1:int, param2) : int
        {
            var _loc_7:int = 0;
            var _loc_12:int = 0;
            var _loc_13:int = 0;
            var _loc_14:int = 0;
            var _loc_15:int = 0;
            var _loc_16:int = 0;
            var _loc_19:int = 0;
            var _loc_20:int = 0;
            var _loc_21:int = 0;
            var _loc_22:int = 0;
            var _loc_3:* = param1 & defines.STREET_MAP_WIDTH_FINAL_AND;
            var _loc_4:* = param1 >> defines.STREET_MAP_WIDTH_FINAL_SHIFT;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_8:* = _loc_3;
            var _loc_9:* = _loc_4;
            var _loc_10:Boolean = false;
            var _loc_11:* = new Vector.<int>(4);
            var _loc_17:int = 0;
            while (!_loc_10 && _loc_17 < 1000)
            {
                
                _loc_17++;
                _loc_7 = _loc_8 + (_loc_9 << defines.STREET_MAP_WIDTH_FINAL_SHIFT);
                _loc_16 = _loc_9 & 1;
                _loc_12 = _loc_7 + (_loc_16 - defines.STREET_MAP_WIDTH_FINAL);
                if (_loc_12 >= 0 && _loc_12 < param2.length)
                {
                    _loc_11[defines.DIR4_NORTH_EAST] = param2[_loc_12];
                }
                else
                {
                    _loc_11[defines.DIR4_NORTH_EAST] = gMisc.GetMaxIntValue();
                }
                _loc_13 = _loc_7 + _loc_16 + defines.STREET_MAP_WIDTH_FINAL;
                if (_loc_13 >= 0 && _loc_13 < param2.length)
                {
                    _loc_11[defines.DIR4_SOUTH_EAST] = param2[_loc_13];
                }
                else
                {
                    _loc_11[defines.DIR4_SOUTH_EAST] = gMisc.GetMaxIntValue();
                }
                _loc_14 = _loc_7 - (1 - _loc_16) + defines.STREET_MAP_WIDTH_FINAL;
                if (_loc_14 >= 0 && _loc_14 < param2.length)
                {
                    _loc_11[defines.DIR4_SOUTH_WEST] = param2[_loc_14];
                }
                else
                {
                    _loc_11[defines.DIR4_SOUTH_WEST] = gMisc.GetMaxIntValue();
                }
                _loc_15 = _loc_7 - (1 - _loc_16) - defines.STREET_MAP_WIDTH_FINAL;
                if (_loc_15 >= 0 && _loc_15 < param2.length)
                {
                    _loc_11[defines.DIR4_NORTH_WEST] = param2[_loc_15];
                }
                else
                {
                    _loc_11[defines.DIR4_NORTH_WEST] = gMisc.GetMaxIntValue();
                }
                _loc_19 = gMisc.GetMaxIntValue();
                _loc_20 = defines.DIR4_NORTH_EAST;
                while (_loc_20 <= defines.DIR4_NORTH_WEST && !_loc_10)
                {
                    
                    _loc_21 = _loc_11[_loc_20];
                    if (_loc_21 == WAYPOINT_DEST)
                    {
                        _loc_10 = true;
                    }
                    else if (_loc_21 < _loc_19)
                    {
                        _loc_19 = _loc_11[_loc_20];
                    }
                    _loc_20++;
                }
                if (!_loc_10)
                {
                    _loc_22 = -1;
                    _loc_20 = defines.DIR4_NORTH_EAST;
                    while (_loc_20 <= defines.DIR4_NORTH_WEST)
                    {
                        
                        if (_loc_11[_loc_20] == _loc_19)
                        {
                            _loc_22 = _loc_20;
                        }
                        _loc_20++;
                    }
                    switch(_loc_22)
                    {
                        case defines.DIR4_NORTH_EAST:
                        {
                            _loc_8 = _loc_8 + _loc_16;
                            _loc_9 = _loc_9 - 1;
                            break;
                        }
                        case defines.DIR4_SOUTH_EAST:
                        {
                            _loc_8 = _loc_8 + _loc_16;
                            _loc_9++;
                            break;
                        }
                        case defines.DIR4_SOUTH_WEST:
                        {
                            _loc_8 = _loc_8 - (1 - _loc_16);
                            _loc_9++;
                            break;
                        }
                        case defines.DIR4_NORTH_WEST:
                        {
                            _loc_8 = _loc_8 - (1 - _loc_16);
                            _loc_9 = _loc_9 - 1;
                            break;
                        }
                        default:
                        {
                            break;
                        }
                    }
                    if (_loc_19 == 1)
                    {
                        _loc_10 = true;
                    }
                }
            }
            var _loc_18:Boolean = false;
            _loc_7 = _loc_8 + (_loc_9 << defines.STREET_MAP_WIDTH_FINAL_SHIFT);
            _loc_16 = _loc_9 & 1;
            if (!_loc_18)
            {
                _loc_12 = _loc_7 + (_loc_16 - defines.STREET_MAP_WIDTH_FINAL);
                if (_loc_12 >= 0 && _loc_12 < param2.length && param2[_loc_12] == WAYPOINT_DEST)
                {
                    _loc_18 = true;
                    _loc_5 = _loc_12 & defines.STREET_MAP_WIDTH_FINAL_AND;
                    _loc_6 = _loc_12 >> defines.STREET_MAP_WIDTH_FINAL_SHIFT;
                }
            }
            if (!_loc_18)
            {
                _loc_13 = _loc_7 + _loc_16 + defines.STREET_MAP_WIDTH_FINAL;
                if (_loc_13 >= 0 && _loc_13 < param2.length && param2[_loc_13] == WAYPOINT_DEST)
                {
                    _loc_18 = true;
                    _loc_5 = _loc_13 & defines.STREET_MAP_WIDTH_FINAL_AND;
                    _loc_6 = _loc_13 >> defines.STREET_MAP_WIDTH_FINAL_SHIFT;
                }
            }
            if (!_loc_18)
            {
                _loc_14 = _loc_7 - (1 - _loc_16) + defines.STREET_MAP_WIDTH_FINAL;
                if (_loc_14 >= 0 && _loc_14 < param2.length && param2[_loc_14] == WAYPOINT_DEST)
                {
                    _loc_18 = true;
                    _loc_5 = _loc_14 & defines.STREET_MAP_WIDTH_FINAL_AND;
                    _loc_6 = _loc_14 >> defines.STREET_MAP_WIDTH_FINAL_SHIFT;
                }
            }
            if (!_loc_18)
            {
                _loc_15 = _loc_7 - (1 - _loc_16) - defines.STREET_MAP_WIDTH_FINAL;
                if (_loc_15 >= 0 && _loc_15 < param2.length && param2[_loc_15] == WAYPOINT_DEST)
                {
                    _loc_18 = true;
                    _loc_5 = _loc_15 & defines.STREET_MAP_WIDTH_FINAL_AND;
                    _loc_6 = _loc_15 >> defines.STREET_MAP_WIDTH_FINAL_SHIFT;
                }
            }
            return _loc_5 + (_loc_6 << defines.STREET_MAP_WIDTH_FINAL_SHIFT);
        }// end function

        public function CalculatePathCostMatrix_list(param1)
        {
            var _loc_4:Vector.<int> = null;
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            var _loc_8:int = 0;
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            var _loc_11:int = 0;
            var _loc_12:int = 0;
            var _loc_13:int = 0;
            var _loc_14:int = 0;
            var _loc_15:int = 0;
            var _loc_16:int = 0;
            var _loc_2:* = new Vector.<int>;
            var _loc_3:* = new Vector.<int>;
            var _loc_5:int = 0;
            this.initCostMatrix();
            for each (_loc_6 in param1)
            {
                
                this.costMatrix_list[_loc_6] = WAYPOINT_DEST;
                _loc_2.push(_loc_6);
            }
            while (_loc_2.length > 0)
            {
                
                _loc_7 = this.costMatrix_list.length;
                for each (_loc_8 in _loc_2)
                {
                    
                    _loc_9 = _loc_8 >> defines.STREET_MAP_WIDTH_FINAL_SHIFT;
                    _loc_10 = _loc_9 & 1;
                    _loc_11 = 1 - _loc_10;
                    _loc_12 = _loc_10 - defines.STREET_MAP_WIDTH_FINAL;
                    _loc_13 = _loc_10 + defines.STREET_MAP_WIDTH_FINAL;
                    _loc_14 = -_loc_11 + defines.STREET_MAP_WIDTH_FINAL;
                    _loc_15 = -_loc_11 - defines.STREET_MAP_WIDTH_FINAL;
                    _loc_16 = _loc_8 + _loc_12;
                    if (_loc_16 >= 0 && _loc_16 < _loc_7 && this.costMatrix_list[_loc_16] == WAYPOINT_UNSET)
                    {
                        this.costMatrix_list[_loc_16] = _loc_5 + 1;
                        _loc_3.push(_loc_16);
                    }
                    _loc_16 = _loc_8 + _loc_13;
                    if (_loc_16 >= 0 && _loc_16 < _loc_7 && this.costMatrix_list[_loc_16] == WAYPOINT_UNSET)
                    {
                        this.costMatrix_list[_loc_16] = _loc_5 + 1;
                        _loc_3.push(_loc_16);
                    }
                    _loc_16 = _loc_8 + _loc_14;
                    if (_loc_16 >= 0 && _loc_16 < _loc_7 && this.costMatrix_list[_loc_16] == WAYPOINT_UNSET)
                    {
                        this.costMatrix_list[_loc_16] = _loc_5 + 1;
                        _loc_3.push(_loc_16);
                    }
                    _loc_16 = _loc_8 + _loc_15;
                    if (_loc_16 >= 0 && _loc_16 < _loc_7 && this.costMatrix_list[_loc_16] == WAYPOINT_UNSET)
                    {
                        this.costMatrix_list[_loc_16] = _loc_5 + 1;
                        _loc_3.push(_loc_16);
                    }
                }
                _loc_5++;
                _loc_4 = _loc_2;
                _loc_2 = _loc_3;
                _loc_3 = _loc_4;
                _loc_3.length = 0;
            }
            return this.costMatrix_list;
        }// end function

        public function initCostMatrix() : void
        {
            var _loc_3:int = 0;
            this.costMatrix_list = new Vector.<int>(defines.STREET_MAP_SIZE_FINAL);
            var _loc_1:int = 0;
            var _loc_2:int = 0;
            var _loc_4:* = (defines.STREET_MAP_MIN_USABLE_AREA_X - 1) + (defines.STREET_MAP_MIN_USABLE_AREA_Y << defines.STREET_MAP_WIDTH_FINAL_SHIFT);
            var _loc_5:* = (defines.STREET_MAP_MAX_USABLE_AREA_X + 1) + (defines.STREET_MAP_MIN_USABLE_AREA_Y << defines.STREET_MAP_WIDTH_FINAL_SHIFT);
            _loc_2 = defines.STREET_MAP_MIN_USABLE_AREA_Y;
            while (_loc_2 <= defines.STREET_MAP_MAX_USABLE_AREA_Y)
            {
                
                this.costMatrix_list[_loc_4] = WAYPOINT_BLOCKED;
                this.costMatrix_list[_loc_5] = WAYPOINT_BLOCKED;
                _loc_4 = _loc_4 + defines.STREET_MAP_WIDTH_FINAL;
                _loc_5 = _loc_5 + defines.STREET_MAP_WIDTH_FINAL;
                _loc_2++;
            }
            var _loc_6:* = ((defines.STREET_MAP_MIN_USABLE_AREA_Y - 1) << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + (defines.STREET_MAP_MIN_USABLE_AREA_X - 1);
            var _loc_7:* = ((defines.STREET_MAP_MAX_USABLE_AREA_Y + 1) << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + (defines.STREET_MAP_MIN_USABLE_AREA_X - 1);
            _loc_3 = defines.STREET_MAP_MAX_USABLE_AREA_X + 1;
            _loc_1 = defines.STREET_MAP_MIN_USABLE_AREA_X;
            while (_loc_1 <= _loc_3)
            {
                
                this.costMatrix_list[_loc_6] = WAYPOINT_BLOCKED;
                this.costMatrix_list[_loc_7] = WAYPOINT_BLOCKED;
                _loc_6++;
                _loc_7++;
                _loc_1++;
            }
            _loc_2 = defines.STREET_MAP_MIN_USABLE_AREA_Y;
            while (_loc_2 <= defines.STREET_MAP_MAX_USABLE_AREA_Y)
            {
                
                _loc_1 = (_loc_2 << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + defines.STREET_MAP_MIN_USABLE_AREA_X;
                _loc_3 = _loc_1 + (defines.STREET_MAP_MAX_USABLE_AREA_X - defines.STREET_MAP_MIN_USABLE_AREA_X);
                while (_loc_1 <= _loc_3)
                {
                    
                    if (this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_1].IsBlockedAllowedNothing())
                    {
                        this.costMatrix_list[_loc_1] = WAYPOINT_BLOCKED;
                    }
                    else
                    {
                        this.costMatrix_list[_loc_1] = WAYPOINT_UNSET;
                    }
                    _loc_1++;
                }
                _loc_2++;
            }
            return;
        }// end function

        public function printBlockMatrix(param1) : void
        {
            var _loc_3:String = null;
            var _loc_4:int = 0;
            var _loc_2:int = 0;
            while (_loc_2 < defines.STREET_MAP_HEIGHT_FINAL)
            {
                
                if (_loc_2 <= 15)
                {
                    _loc_3 = "0" + gMisc.ConvertIntToStringRadix_string(_loc_2, 16);
                }
                else
                {
                    _loc_3 = gMisc.ConvertIntToStringRadix_string(_loc_2, 16);
                }
                if (_loc_2 % 2 == 1)
                {
                    _loc_3 = _loc_3 + " ";
                }
                _loc_4 = 0;
                while (_loc_4 < defines.STREET_MAP_WIDTH_FINAL)
                {
                    
                    _loc_3 = _loc_3 + ("|" + (param1[_loc_2 * defines.STREET_MAP_WIDTH_FINAL + _loc_4] ? ("XX") : ("  ")));
                    _loc_4++;
                }
                gMisc.ConsoleOut(_loc_3);
                _loc_2++;
            }
            return;
        }// end function

        public function CalculateStreetPathFromMatrix(param1:int, param2:int, param3, param4:Boolean) : cPathObject
        {
            var _loc_14:int = 0;
            var _loc_19:int = 0;
            var _loc_20:int = 0;
            var _loc_21:int = 0;
            var _loc_22:int = 0;
            var _loc_23:int = 0;
            var _loc_28:int = 0;
            var _loc_29:int = 0;
            var _loc_30:int = 0;
            var _loc_31:int = 0;
            var _loc_32:int = 0;
            var _loc_33:int = 0;
            var _loc_34:int = 0;
            var _loc_35:int = 0;
            var _loc_36:int = 0;
            var _loc_37:int = 0;
            var _loc_38:int = 0;
            var _loc_39:int = 0;
            var _loc_40:int = 0;
            var _loc_41:int = 0;
            var _loc_42:int = 0;
            var _loc_43:int = 0;
            var _loc_5:* = new Vector.<int>;
            var _loc_6:* = new Vector.<int>;
            var _loc_7:* = param1 & defines.STREET_MAP_WIDTH_FINAL_AND;
            var _loc_8:* = param1 >> defines.STREET_MAP_WIDTH_FINAL_SHIFT;
            var _loc_9:* = param2 & defines.STREET_MAP_WIDTH_FINAL_AND;
            var _loc_10:* = param2 >> defines.STREET_MAP_WIDTH_FINAL_SHIFT;
            if (_loc_7 < defines.STREET_MAP_MIN_USABLE_AREA_X || _loc_7 > defines.STREET_MAP_MAX_USABLE_AREA_X || _loc_8 < defines.STREET_MAP_MIN_USABLE_AREA_Y || _loc_7 > defines.STREET_MAP_MAX_USABLE_AREA_Y || _loc_9 < defines.STREET_MAP_MIN_USABLE_AREA_X || _loc_9 > defines.STREET_MAP_MAX_USABLE_AREA_X || _loc_10 < defines.STREET_MAP_MIN_USABLE_AREA_Y || _loc_10 > defines.STREET_MAP_MAX_USABLE_AREA_Y)
            {
                return new cPathObject();
            }
            var _loc_11:Boolean = false;
            var _loc_12:* = _loc_10 & 1;
            _loc_11 = _loc_11 || param3[param2 + (_loc_12 - defines.STREET_MAP_WIDTH_FINAL)] < WAYPOINT_UNSET;
            _loc_11 = _loc_11 || param3[param2 + _loc_12 + defines.STREET_MAP_WIDTH_FINAL] < WAYPOINT_UNSET;
            _loc_11 = _loc_11 || param3[param2 - (1 - _loc_12) + defines.STREET_MAP_WIDTH_FINAL] < WAYPOINT_UNSET;
            _loc_11 = _loc_11 || param3[param2 - (1 - _loc_12) - defines.STREET_MAP_WIDTH_FINAL] < WAYPOINT_UNSET;
            if (!_loc_11)
            {
                return new cPathObject();
            }
            _loc_11 = false;
            var _loc_13:* = _loc_8 & 1;
            _loc_11 = _loc_11 || param3[param1 + (_loc_13 - defines.STREET_MAP_WIDTH_FINAL)] < WAYPOINT_UNSET;
            _loc_11 = _loc_11 || param3[param1 + _loc_13 + defines.STREET_MAP_WIDTH_FINAL] < WAYPOINT_UNSET;
            _loc_11 = _loc_11 || param3[param1 - (1 - _loc_13) + defines.STREET_MAP_WIDTH_FINAL] < WAYPOINT_UNSET;
            _loc_11 = _loc_11 || param3[param1 - (1 - _loc_13) - defines.STREET_MAP_WIDTH_FINAL] < WAYPOINT_UNSET;
            if (!_loc_11)
            {
                return new cPathObject();
            }
            var _loc_15:* = _loc_7;
            var _loc_16:* = _loc_8;
            if (param4 || !this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.IsBlockedForStreetAtGridIdx(param1))
            {
                _loc_5.push(_loc_7);
                _loc_6.push(_loc_8);
            }
            var _loc_17:Boolean = false;
            var _loc_18:* = new Vector.<int>(4);
            var _loc_24:int = 0;
            var _loc_25:* = new Vector.<int>(4);
            while (!_loc_17 && _loc_24 < 1000)
            {
                
                _loc_24++;
                _loc_14 = _loc_15 + (_loc_16 << defines.STREET_MAP_WIDTH_FINAL_SHIFT);
                _loc_23 = _loc_16 & 1;
                _loc_19 = _loc_14 + (_loc_23 - defines.STREET_MAP_WIDTH_FINAL);
                _loc_18[defines.DIR4_NORTH_EAST] = param3[_loc_19];
                _loc_28 = _loc_19 & defines.STREET_MAP_WIDTH_FINAL_AND;
                _loc_29 = _loc_19 >> defines.STREET_MAP_WIDTH_FINAL_SHIFT;
                _loc_25[defines.DIR4_NORTH_EAST] = (_loc_9 - _loc_28 < 0 ? (-(_loc_9 - _loc_28)) : (_loc_9 - _loc_28)) + (_loc_10 - _loc_29 < 0 ? (-(_loc_10 - _loc_29)) : (_loc_10 - _loc_29));
                _loc_20 = _loc_14 + _loc_23 + defines.STREET_MAP_WIDTH_FINAL;
                _loc_18[defines.DIR4_SOUTH_EAST] = param3[_loc_20];
                _loc_30 = _loc_20 & defines.STREET_MAP_WIDTH_FINAL_AND;
                _loc_31 = _loc_20 >> defines.STREET_MAP_WIDTH_FINAL_SHIFT;
                _loc_25[defines.DIR4_SOUTH_EAST] = (_loc_9 - _loc_30 < 0 ? (-(_loc_9 - _loc_30)) : (_loc_9 - _loc_30)) + (_loc_10 - _loc_31 < 0 ? (-(_loc_10 - _loc_31)) : (_loc_10 - _loc_31));
                _loc_21 = _loc_14 - (1 - _loc_23) + defines.STREET_MAP_WIDTH_FINAL;
                _loc_18[defines.DIR4_SOUTH_WEST] = param3[_loc_21];
                _loc_32 = _loc_21 & defines.STREET_MAP_WIDTH_FINAL_AND;
                _loc_33 = _loc_21 >> defines.STREET_MAP_WIDTH_FINAL_SHIFT;
                _loc_25[defines.DIR4_SOUTH_WEST] = (_loc_9 - _loc_32 < 0 ? (-(_loc_9 - _loc_32)) : (_loc_9 - _loc_32)) + (_loc_10 - _loc_33 < 0 ? (-(_loc_10 - _loc_33)) : (_loc_10 - _loc_33));
                _loc_22 = _loc_14 - (1 - _loc_23) - defines.STREET_MAP_WIDTH_FINAL;
                _loc_18[defines.DIR4_NORTH_WEST] = param3[_loc_22];
                _loc_34 = _loc_22 & defines.STREET_MAP_WIDTH_FINAL_AND;
                _loc_35 = _loc_22 >> defines.STREET_MAP_WIDTH_FINAL_SHIFT;
                _loc_25[defines.DIR4_NORTH_WEST] = (_loc_9 - _loc_34 < 0 ? (-(_loc_9 - _loc_34)) : (_loc_9 - _loc_34)) + (_loc_10 - _loc_35 < 0 ? (-(_loc_10 - _loc_35)) : (_loc_10 - _loc_35));
                _loc_36 = gMisc.GetMaxIntValue();
                _loc_37 = defines.DIR4_NORTH_EAST;
                while (_loc_37 <= defines.DIR4_NORTH_WEST && !_loc_17)
                {
                    
                    _loc_38 = _loc_18[_loc_37];
                    if (_loc_38 == WAYPOINT_DEST)
                    {
                        _loc_17 = true;
                    }
                    else if (_loc_38 < _loc_36)
                    {
                        _loc_36 = _loc_18[_loc_37];
                    }
                    _loc_37++;
                }
                if (!_loc_17)
                {
                    _loc_39 = gMisc.GetMaxIntValue();
                    _loc_40 = -1;
                    _loc_37 = defines.DIR4_NORTH_EAST;
                    while (_loc_37 <= defines.DIR4_NORTH_WEST)
                    {
                        
                        if (_loc_18[_loc_37] == _loc_36)
                        {
                            if (_loc_25[_loc_37] < _loc_39)
                            {
                                _loc_39 = _loc_25[_loc_37];
                                _loc_40 = _loc_37;
                            }
                        }
                        _loc_37++;
                    }
                    switch(_loc_40)
                    {
                        case defines.DIR4_NORTH_EAST:
                        {
                            _loc_15 = _loc_15 + _loc_23;
                            _loc_16 = _loc_16 - 1;
                            break;
                        }
                        case defines.DIR4_SOUTH_EAST:
                        {
                            _loc_15 = _loc_15 + _loc_23;
                            _loc_16++;
                            break;
                        }
                        case defines.DIR4_SOUTH_WEST:
                        {
                            _loc_15 = _loc_15 - (1 - _loc_23);
                            _loc_16++;
                            break;
                        }
                        case defines.DIR4_NORTH_WEST:
                        {
                            _loc_15 = _loc_15 - (1 - _loc_23);
                            _loc_16 = _loc_16 - 1;
                            break;
                        }
                        default:
                        {
                            break;
                        }
                    }
                    _loc_5.push(_loc_15);
                    _loc_6.push(_loc_16);
                    if (_loc_36 == 1)
                    {
                        _loc_17 = true;
                    }
                }
            }
            if (!_loc_17)
            {
                gMisc.ConsoleOut("WAY not found!");
            }
            if (_loc_24 >= 1000)
            {
                gMisc.ConsoleOut("Needed more than 1000 steps to calculate path!");
            }
            if (param4 || !this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.IsBlockedForStreetAtGridIdx(param2))
            {
                _loc_5.push(_loc_9);
                _loc_6.push(_loc_10);
            }
            var _loc_26:* = new cPathObject();
            var _loc_27:* = _loc_5.length - 1;
            while (_loc_27 >= 0)
            {
                
                _loc_41 = _loc_5[_loc_27];
                _loc_42 = _loc_6[_loc_27];
                _loc_43 = _loc_41 + (_loc_42 << defines.STREET_MAP_WIDTH_FINAL_SHIFT);
                this.AddDestination(_loc_26, _loc_43);
                _loc_27 = _loc_27 - 1;
            }
            _loc_26.RefreshLength();
            return _loc_26;
        }// end function

        private function getDirectionString(param1:int) : String
        {
            switch(param1)
            {
                case defines.DIR4_NORTH_EAST:
                {
                    return "NE";
                }
                case defines.DIR4_SOUTH_EAST:
                {
                    return "SE";
                }
                case defines.DIR4_SOUTH_WEST:
                {
                    return "SW";
                }
                case defines.DIR4_NORTH_WEST:
                {
                    return "NW";
                }
                default:
                {
                    break;
                }
            }
            return "Unknown: " + param1;
        }// end function

        public function AddDestination(param1:cPathObject, param2:int) : void
        {
            param1.state = cPathObject.STATE_GOTO_DESTINATION;
            var _loc_3:* = new dPathObjectItem();
            gCalculations.ConvertStreetGridToPixelPos(param2, _loc_3);
            _loc_3.streetGridIdx = param2;
            param1.dest_vector.push(_loc_3);
            return;
        }// end function

        public static function printWayCostMatrix(param1, param2:Boolean) : void
        {
            var _loc_4:int = 0;
            var _loc_3:String = "";
            _loc_3 = _loc_3 + "*** CostMatrix ***\n";
            _loc_3 = _loc_3 + "    ";
            _loc_4 = 0;
            while (_loc_4 < defines.STREET_MAP_WIDTH_FINAL)
            {
                
                if (_loc_4 < 16)
                {
                    _loc_3 = _loc_3 + ("|0" + gMisc.ConvertIntToStringRadix_string(_loc_4, 16));
                }
                else
                {
                    _loc_3 = _loc_3 + ("|" + gMisc.ConvertIntToStringRadix_string(_loc_4, 16));
                }
                _loc_4++;
            }
            _loc_3 = _loc_3 + "\n";
            var _loc_5:int = 0;
            while (_loc_5 < defines.STREET_MAP_HEIGHT_FINAL)
            {
                
                if (_loc_5 <= 15)
                {
                    _loc_3 = _loc_3 + ("0" + gMisc.ConvertIntToStringRadix_string(_loc_5, 16) + ": ");
                }
                else
                {
                    _loc_3 = _loc_3 + (gMisc.ConvertIntToStringRadix_string(_loc_5, 16) + ": ");
                }
                if (_loc_5 % 2 == 1)
                {
                    _loc_3 = _loc_3 + " ";
                }
                _loc_4 = 0;
                while (_loc_4 < defines.STREET_MAP_WIDTH_FINAL)
                {
                    
                    _loc_3 = _loc_3 + getStringForCosts(param1[_loc_5 * defines.STREET_MAP_WIDTH_FINAL + _loc_4], param2);
                    _loc_4++;
                }
                _loc_3 = _loc_3 + "\n";
                _loc_5++;
            }
            gMisc.ConsoleOut(_loc_3);
            return;
        }// end function

        private static function getStringForCosts(param1:int, param2:Boolean) : String
        {
            var _loc_3:String = "";
            if (!param2)
            {
                switch(param1)
                {
                    case WAYPOINT_BLOCKED:
                    {
                        _loc_3 = _loc_3 + "|##";
                        break;
                    }
                    case WAYPOINT_UNSET:
                    {
                        _loc_3 = _loc_3 + "|__";
                        break;
                    }
                    case WAYPOINT_START:
                    {
                        _loc_3 = _loc_3 + "|SS";
                        break;
                    }
                    case WAYPOINT_DEST:
                    {
                        _loc_3 = _loc_3 + "|DD";
                        break;
                    }
                    default:
                    {
                        _loc_3 = _loc_3 + ("|" + (param1 <= 15 ? ("0") : ("")) + gMisc.ConvertIntToStringRadix_string(param1, 16));
                        break;
                    }
                }
            }
            else
            {
                switch(param1)
                {
                    case WAYPOINT_BLOCKED:
                    {
                        _loc_3 = _loc_3 + "|XX";
                        break;
                    }
                    case WAYPOINT_START:
                    {
                        _loc_3 = _loc_3 + "|SS";
                        break;
                    }
                    case WAYPOINT_DEST:
                    {
                        _loc_3 = _loc_3 + "|DD";
                        break;
                    }
                    default:
                    {
                        _loc_3 = _loc_3 + "|__";
                        break;
                    }
                }
            }
            return _loc_3;
        }// end function

    }
}
