package 
{
    import Communication.VO.*;
    import Enums.*;
    import GO.*;
    import Interface.*;
    import Map.*;
    import PathFinding.*;
    import ServerState.*;
    import __AS3__.vec.*;

    public class cSetStreets extends Object
    {
        private var mStartingPositionGridIdx:int;
        public var mSetStartPoint:Boolean;
        public var mPathObject:cPathObject;
        private var oldCursorGridIdx:int = -1;
        private var mPathCostMatrix_list:Vector.<int> = null;
        private var mGeneralInterface:cGeneralInterface;

        public function cSetStreets(param1:cGeneralInterface)
        {
            this.mPathObject = new cPathObject();
            this.mGeneralInterface = param1;
            return;
        }// end function

        public function Remove4StreetConnectionsAllSectorsGridPos(param1:cPlayerData, param2:int) : void
        {
            this.RemoveStreetConnectionsAllSectorsGridPos(param1, 1 << 2, gCalculations.MoveStreetGridToDir8(param2, defines.DIR8_NORTH_EAST));
            this.RemoveStreetConnectionsAllSectorsGridPos(param1, 1 << 3, gCalculations.MoveStreetGridToDir8(param2, defines.DIR8_SOUTH_EAST));
            this.RemoveStreetConnectionsAllSectorsGridPos(param1, 1 << 0, gCalculations.MoveStreetGridToDir8(param2, defines.DIR8_SOUTH_WEST));
            this.RemoveStreetConnectionsAllSectorsGridPos(param1, 1 << 1, gCalculations.MoveStreetGridToDir8(param2, defines.DIR8_NORTH_WEST));
            return;
        }// end function

        public function MouseMove(param1:cPlayerZoneScreen) : Boolean
        {
            return this.MouseDownOnMap(param1);
        }// end function

        public function MouseClickOnMap(param1:cPlayerData, param2:cPlayerZoneScreen) : Boolean
        {
            var _loc_3:dServerAction = null;
            var _loc_7:Vector.<int> = null;
            var _loc_8:String = null;
            if (!this.mGeneralInterface.mCurrentCursor.IsCursorValid())
            {
                return false;
            }
            var _loc_4:* = this.mGeneralInterface.mCurrentCursor.GetGridPosition();
            var _loc_5:* = this.mGeneralInterface.mCurrentCursor.GetCursorXPixelPos();
            var _loc_6:* = this.mGeneralInterface.mCurrentCursor.GetCursorYPixelPos();
            if (this.mGeneralInterface.mCurrentCursor.GetEditMode() == COMMAND.BUILD_WAY)
            {
            }
            if (this.mSetStartPoint)
            {
                this.mStartingPositionGridIdx = _loc_4;
                _loc_7 = new Vector.<int>(1);
                _loc_7.push(this.mStartingPositionGridIdx);
                this.mPathCostMatrix_list = this.mGeneralInterface.mCreatePath.CalculatePathCostMatrix_list(_loc_7);
                param2.mStreetDataMap.ResetStreetPreview();
                this.mGeneralInterface.mCurrentSecondaryCursor.SetCursorEditMode(COMMAND.BUILD_WAY_SECONDARY);
                this.mGeneralInterface.mCurrentSecondaryCursor.SetPosition(_loc_5, _loc_6);
            }
            else
            {
                this.mPathObject.Reset();
                this.mPathObject = this.mGeneralInterface.mCreatePath.CalculateStreetPathFromMatrix(_loc_4, this.mStartingPositionGridIdx, this.mPathCostMatrix_list, false);
                param2.mStreetDataMap.CreateStreetWayFromPathStreet(param1, this.mPathObject, false);
                param2.mStreetDataMap.ResetStreetPreview();
                this.mGeneralInterface.mCurrentCursor.SetCursorEditMode(COMMAND.SELECT_BUILDING);
                this.mGeneralInterface.SendServerAction(COMMAND.BUILD_WAY_SECONDARY, 0, _loc_4, this.mStartingPositionGridIdx, null);
            }
            this.mSetStartPoint = !this.mSetStartPoint;
            return true;
        }// end function

        public function ShowStreetsInRealTime(param1:cPlayerData) : void
        {
            var _loc_2:int = 0;
            if (this.mGeneralInterface.mCurrentCursor.GetEditMode() == COMMAND.BUILD_WAY)
            {
                if (!this.mSetStartPoint)
                {
                    _loc_2 = this.mGeneralInterface.mCurrentCursor.GetGridPosition();
                    if (this.oldCursorGridIdx != _loc_2)
                    {
                        this.oldCursorGridIdx = _loc_2;
                        this.mPathObject.Reset();
                        this.mPathObject = this.mGeneralInterface.mCreatePath.CalculateStreetPathFromMatrix(_loc_2, this.mStartingPositionGridIdx, this.mPathCostMatrix_list, false);
                    }
                    this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.CreateStreetWayFromPathStreet(param1, this.mPathObject, true);
                    this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.ShowStreetPreview();
                    this.mGeneralInterface.mCurrentSecondaryCursor.RenderUnderBuildings();
                }
            }
            return;
        }// end function

        public function MouseDownOnMap(param1:cPlayerZoneScreen) : Boolean
        {
            return false;
        }// end function

        private function RemoveStreetConnectionsAllSectorsGridPos(param1:cPlayerData, param2:int, param3:int) : void
        {
            var _loc_5:int = 0;
            var _loc_6:cGO = null;
            var _loc_4:* = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.GetStreetNameFromGridPos_string(param3);
            if (this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.GetStreetNameFromGridPos_string(param3) != null)
            {
                _loc_5 = cStreet.ConvertStreetNameToBitField(_loc_4);
                _loc_5 = _loc_5 & ~param2;
                if (_loc_5 != 0)
                {
                    _loc_6 = this.mGeneralInterface.mCurrentPlayerZone.SetAtGridPosition(param1, OBJECTTYPE.STREET, defines.STREET_ELEMENT_NAME_string + "_" + cStreet.CreateStringFromStreetBitField_string(_loc_5), param3);
                    if (_loc_6 != null)
                    {
                        (_loc_6 as cStreet).mDirtyIndicator = (_loc_6 as cStreet).mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
                    }
                }
                else
                {
                    this.mGeneralInterface.mCurrentPlayerZone.RemoveAtGridPosition(param1, OBJECTTYPE.STREET, param3);
                }
            }
            return;
        }// end function

    }
}
