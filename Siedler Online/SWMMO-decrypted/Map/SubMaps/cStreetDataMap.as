package Map.SubMaps
{
    import BuffSystem.*;
    import Communication.VO.Guild.*;
    import Enums.*;
    import GO.*;
    import GUI.Loca.*;
    import Interface.*;
    import Map.*;
    import PathFinding.*;
    import ServerState.*;
    import __AS3__.vec.*;
    import flash.display.*;
    import nLib.*;

    public class cStreetDataMap extends Object
    {
        private var mDeposits_vector:Vector.<cDeposit>;
        protected var mCachedZoomScale:Number = -1;
        private var mCheckFreeLandscapeCntr:int = 0;
        private var mLoadedFromMap:Boolean = false;
        protected var mConvertPixelPosToGridPosRes:cPosInt;
        public var mStreetInDirectionResultPos:cPosInt;
        private var mGuildHouse:cBuilding = null;
        protected var mTempPosInt:cPosInt;
        private var mSettlerYSortMap_list:Vector.<dSettlerList>;
        protected var mCachedScrollPosX:Number = -1;
        protected var mCachedScrollPosY:Number = -1;
        private var mMayorHouse:cBuilding = null;
        private var mStreetCreationPreview_vector:Vector.<cStreet>;
        protected var mGoGroup:cGOGroup;
        private var mStreets_vector:Vector.<cStreet>;
        private var mRandomBuildingArray_vector:Vector.<cGOSpriteLibContainer> = null;
        public var mIsoMap_list:Vector.<cIsoElement>;
        private var mLogisticsHouse:cBuilding = null;
        private var mSinTable_vector:Vector.<int>;
        private var mTempPos:cPosInt;
        public var mLandingFields_vector:Vector.<cLandingField>;
        protected var mGeneralInterface:cGeneralInterface;
        private var mCosTable_vector:Vector.<int>;
        private var mBuildings_vector:Vector.<cBuilding>;
        public var mFreeLandscape_vector:Vector.<cFreeLandscape>;
        private var mBuildingsAndTrees_vector:Vector.<cGO>;
        protected var mElementName_string:String;
        protected var mTempClippingRectangle:cClippingRectangle;
        private static const ACTIVATE_ISO_RENDER_DEBUG_INFO:Boolean = true;
        private static const ACTIVATE_RENDER_DEBUG_INFO_OVER_BUILDING:Boolean = true;

        public function cStreetDataMap(param1:cGeneralInterface)
        {
            this.mIsoMap_list = new Vector.<cIsoElement>(defines.STREET_MAP_SIZE_FINAL);
            this.mStreetInDirectionResultPos = new cPosInt(0, 0);
            this.mLandingFields_vector = new Vector.<cLandingField>;
            this.mFreeLandscape_vector = new Vector.<cFreeLandscape>;
            this.mTempPosInt = new cPosInt();
            this.mTempClippingRectangle = new cClippingRectangle();
            this.mConvertPixelPosToGridPosRes = new cPosInt();
            this.mSettlerYSortMap_list = new Vector.<dSettlerList>(defines.STREET_MAP_HEIGHT_FINAL);
            this.mDeposits_vector = new Vector.<cDeposit>;
            this.mBuildings_vector = new Vector.<cBuilding>;
            this.mBuildingsAndTrees_vector = new Vector.<cGO>;
            this.mStreets_vector = new Vector.<cStreet>;
            this.mTempPos = new cPosInt();
            this.mStreetCreationPreview_vector = new Vector.<cStreet>;
            this.mGeneralInterface = param1;
            this.InitializeMap();
            return;
        }// end function

        public function SetWatchpoint(param1:int, param2:int, param3:cBuilding) : void
        {
            var _loc_4:* = gCalculations.ConvertPixelPosToStreetGridPos(param1, param2);
            if (gCalculations.ConvertPixelPosToStreetGridPos(param1, param2) == defines.ILLEGAL_INT_POS)
            {
                return;
            }
            if (param3.GetPlayerID() == this.mGeneralInterface.mCurrentPlayerZone.mSectorList_vector[this.mIsoMap_list[_loc_4].mSectorId].GetOwnerPlayerID())
            {
                this.mIsoMap_list[_loc_4].AddWatchingBuilding(param3);
            }
            return;
        }// end function

        public function RenderWatchAreaOfSelectedBuilding(param1:cBuilding) : void
        {
            var _loc_7:int = 0;
            var _loc_8:int = 0;
            var _loc_2:* = new cClippingRectangle();
            this.CalculateMapClipping(GCB_MODE_CLIPPING.CLIP_TO_SCREEN_FOREGROUND, _loc_2);
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_5:* = global.streetGridX * _loc_2.minX;
            _loc_4 = _loc_4 + global.streetGridYHalf * _loc_2.minY;
            var _loc_6:* = _loc_2.minY;
            while (_loc_6 <= _loc_2.maxY)
            {
                
                if ((_loc_6 & 1) == 0)
                {
                    _loc_3 = -global.streetGridXHalf + _loc_5;
                }
                else
                {
                    _loc_3 = _loc_5;
                }
                _loc_7 = (_loc_6 << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + _loc_2.minX;
                _loc_8 = _loc_2.minX;
                while (_loc_8 <= _loc_2.maxX)
                {
                    
                    if (this.mIsoMap_list[_loc_7].IsBuildingWatching(param1))
                    {
                        this.mGeneralInterface.mStreetCursorWhite.SetPosition(_loc_3, _loc_4);
                        this.mGeneralInterface.mStreetCursorWhite.RenderTransform(_loc_3, _loc_4, BlendMode.NORMAL, 1, 1, 0);
                    }
                    _loc_3 = _loc_3 + global.streetGridX;
                    _loc_7++;
                    _loc_8++;
                }
                _loc_4 = _loc_4 + global.streetGridYHalf;
                _loc_6++;
            }
            return;
        }// end function

        public function GetIsoElementFromGridPosition(param1:int) : cIsoElement
        {
            if (param1 != defines.ILLEGAL_INT_POS)
            {
                return this.mIsoMap_list[param1];
            }
            return null;
        }// end function

        public function IsLandingfieldAtPosition(param1:int) : cLandingField
        {
            var _loc_2:cLandingField = null;
            for each (_loc_2 in this.mLandingFields_vector)
            {
                
                if (_loc_2.mGrid == param1)
                {
                    return _loc_2;
                }
            }
            return null;
        }// end function

        public function IsDepositIn8DirectionsAroundGridPos(param1:int) : Boolean
        {
            var _loc_3:int = 0;
            if (this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[param1].mDeposit != null)
            {
                return true;
            }
            var _loc_2:int = 0;
            while (_loc_2 < defines.DIR8_MAX)
            {
                
                _loc_3 = gCalculations.MoveStreetGridToDir8(param1, _loc_2);
                if (this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_3].mDeposit != null)
                {
                    return true;
                }
                _loc_2++;
            }
            return false;
        }// end function

        public function CalculateFogBorders(param1:cPlayerData) : void
        {
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:cSector = null;
            var _loc_8:cIsoElement = null;
            var _loc_9:cVectorListInt = null;
            var _loc_11:int = 0;
            if (!this.mGeneralInterface.showFogOfWar)
            {
                this.mGeneralInterface.mCurrentPlayerZone.SetFogRendering(false);
                return;
            }
            var _loc_10:* = param1.GetPlayerId();
            _loc_3 = defines.STREET_MAP_MIN_USABLE_AREA_Y;
            while (_loc_3 <= defines.STREET_MAP_MAX_USABLE_AREA_Y)
            {
                
                _loc_4 = (_loc_3 << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + defines.STREET_MAP_MIN_USABLE_AREA_X;
                _loc_2 = defines.STREET_MAP_MIN_USABLE_AREA_X;
                while (_loc_2 < defines.STREET_MAP_MAX_USABLE_AREA_X + 2)
                {
                    
                    _loc_8 = this.mIsoMap_list[_loc_4++];
                    _loc_8.mFogBorder = 0;
                    _loc_7 = this.mGeneralInterface.mCurrentPlayerZone.mSectorList_vector[_loc_8.mSectorId];
                    if (_loc_8.mSectorId > 0 && _loc_8.mSectorId < param1.GetSectorsAmount())
                    {
                        if (_loc_7.GetOwnerPlayerID() != _loc_10 && param1.GetSectorDiscovery(_loc_8.mSectorId) != SECTOR_DISCOVERY_TYPE.EXPLORED)
                        {
                            _loc_8.mFogBorder = 4;
                        }
                    }
                    _loc_2++;
                }
                _loc_3++;
            }
            _loc_3 = defines.STREET_MAP_MIN_USABLE_AREA_Y;
            while (_loc_3 <= defines.STREET_MAP_MAX_USABLE_AREA_Y)
            {
                
                _loc_4 = (_loc_3 << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + defines.STREET_MAP_MIN_USABLE_AREA_X;
                _loc_9 = gCalculations.m8DirectionTableStreetGridDirection_vector[_loc_3 & 1];
                _loc_2 = defines.STREET_MAP_MIN_USABLE_AREA_X;
                while (_loc_2 < defines.STREET_MAP_MAX_USABLE_AREA_X + 2)
                {
                    
                    _loc_8 = this.mIsoMap_list[_loc_4];
                    if (_loc_8.mFogBorder == 4)
                    {
                        _loc_11 = 0;
                        while (_loc_11 < 8)
                        {
                            
                            _loc_6 = _loc_4 + _loc_9.mList_vector[_loc_11];
                            if (this.mIsoMap_list[_loc_6].mFogBorder == 0)
                            {
                                _loc_8.mFogBorder = 1;
                                break;
                            }
                            _loc_11++;
                        }
                    }
                    _loc_4++;
                    _loc_2++;
                }
                _loc_3++;
            }
            _loc_3 = defines.STREET_MAP_MIN_USABLE_AREA_Y;
            while (_loc_3 <= defines.STREET_MAP_MAX_USABLE_AREA_Y)
            {
                
                _loc_4 = (_loc_3 << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + defines.STREET_MAP_MIN_USABLE_AREA_X;
                _loc_9 = gCalculations.m8DirectionTableStreetGridDirection_vector[_loc_3 & 1];
                _loc_2 = defines.STREET_MAP_MIN_USABLE_AREA_X;
                while (_loc_2 < defines.STREET_MAP_MAX_USABLE_AREA_X + 2)
                {
                    
                    _loc_8 = this.mIsoMap_list[_loc_4];
                    if (_loc_8.mFogBorder == 4)
                    {
                        _loc_5 = 0;
                        while (_loc_5 < 8)
                        {
                            
                            _loc_6 = _loc_4 + _loc_9.mList_vector[_loc_5];
                            if (this.mIsoMap_list[_loc_6].mFogBorder == 1)
                            {
                                _loc_8.mFogBorder = 2;
                                break;
                            }
                            _loc_5++;
                        }
                    }
                    _loc_4++;
                    _loc_2++;
                }
                _loc_3++;
            }
            _loc_3 = defines.STREET_MAP_MIN_USABLE_AREA_Y;
            while (_loc_3 <= defines.STREET_MAP_MAX_USABLE_AREA_Y)
            {
                
                _loc_4 = (_loc_3 << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + defines.STREET_MAP_MIN_USABLE_AREA_X;
                _loc_9 = gCalculations.m8DirectionTableStreetGridDirection_vector[_loc_3 & 1];
                _loc_2 = defines.STREET_MAP_MIN_USABLE_AREA_X;
                while (_loc_2 < defines.STREET_MAP_MAX_USABLE_AREA_X + 2)
                {
                    
                    _loc_8 = this.mIsoMap_list[_loc_4];
                    if (_loc_8.mFogBorder == 4)
                    {
                        _loc_5 = 0;
                        while (_loc_5 < 8)
                        {
                            
                            _loc_6 = _loc_4 + _loc_9.mList_vector[_loc_5];
                            if (this.mIsoMap_list[_loc_6].mFogBorder == 2)
                            {
                                _loc_8.mFogBorder = 3;
                                break;
                            }
                            _loc_5++;
                        }
                    }
                    _loc_4++;
                    _loc_2++;
                }
                _loc_3++;
            }
            return;
        }// end function

        public function RefreshMayorHouse() : void
        {
            var _loc_1:cBuilding = null;
            this.mMayorHouse = null;
            for each (_loc_1 in this.GetBuildings_vector())
            {
                
                if (_loc_1.GetBuildingName_string() == defines.MAYORHOUSE_NAME_string)
                {
                    this.mMayorHouse = _loc_1;
                    break;
                }
            }
            if (this.mMayorHouse == null)
            {
            }
            return;
        }// end function

        public function RemoveDepletedDepositBuildingIfOneIsThere(param1:int) : Boolean
        {
            var _loc_2:cBuilding = null;
            if (this.mIsoMap_list[param1].mBuilding != null)
            {
                if (this.IsADepletedDeposit(this.mIsoMap_list[param1].mBuilding))
                {
                    _loc_2 = this.mIsoMap_list[param1].mBuilding;
                    this.RemoveBuildingGridPos(param1);
                    this.RemoveBuildingFromGameLogic(_loc_2);
                    return true;
                }
                return false;
            }
            return true;
        }// end function

        public function GetDeposits_vector()
        {
            return this.mDeposits_vector;
        }// end function

        public function CalculateMapClipping(param1:int, param2:cClippingRectangle) : void
        {
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:Number = NaN;
            if (param1 == GCB_MODE_CLIPPING.CLIP_TO_SCREEN_FOREGROUND)
            {
                _loc_7 = this.mGeneralInterface.mZoom.Scale(-global.screenWidthHalf, cZoom.DEFAULT_ZOOM);
                _loc_3 = int(_loc_7) + this.mGeneralInterface.mZoom.GetScrollPosXInt();
                _loc_7 = this.mGeneralInterface.mZoom.Scale(-global.screenHeightHalf, cZoom.DEFAULT_ZOOM);
                _loc_4 = int(_loc_7) + this.mGeneralInterface.mZoom.GetScrollPosYInt();
                _loc_7 = this.mGeneralInterface.mZoom.Scale(global.screenWidthHalf, cZoom.DEFAULT_ZOOM);
                _loc_5 = int(_loc_7) + this.mGeneralInterface.mZoom.GetScrollPosXInt();
                _loc_7 = this.mGeneralInterface.mZoom.Scale(global.screenHeightHalf, cZoom.DEFAULT_ZOOM);
                _loc_6 = int(_loc_7) + this.mGeneralInterface.mZoom.GetScrollPosYInt();
                _loc_3 = _loc_3 / global.streetGridX;
                _loc_4 = _loc_4 / global.streetGridYHalf;
                _loc_5 = _loc_5 / global.streetGridX;
                _loc_6 = _loc_6 / global.streetGridYHalf;
                _loc_5 = _loc_5 + 2;
                _loc_4 = _loc_4 + 1;
                _loc_6 = _loc_6 + 8;
                if (_loc_3 < defines.STREET_MAP_MIN_USABLE_AREA_X)
                {
                    _loc_3 = defines.STREET_MAP_MIN_USABLE_AREA_X;
                }
                if (_loc_4 < defines.STREET_MAP_MIN_USABLE_AREA_Y)
                {
                    _loc_4 = defines.STREET_MAP_MIN_USABLE_AREA_Y;
                }
                if (_loc_5 > defines.STREET_MAP_MAX_USABLE_AREA_X)
                {
                    _loc_5 = defines.STREET_MAP_MAX_USABLE_AREA_X;
                }
                if (_loc_6 > defines.STREET_MAP_MAX_USABLE_AREA_Y)
                {
                    _loc_6 = defines.STREET_MAP_MAX_USABLE_AREA_Y;
                }
            }
            else if (param1 == GCB_MODE_CLIPPING.CLIP_TO_SCREEN_BACKGROUND)
            {
                _loc_7 = this.mGeneralInterface.mZoom.Scale(cBackbuffer.mClipMinX - global.screenWidthHalf, cZoom.DEFAULT_ZOOM);
                _loc_3 = int(_loc_7);
                _loc_7 = this.mGeneralInterface.mZoom.Scale(cBackbuffer.mClipMinY - global.screenHeightHalf, cZoom.DEFAULT_ZOOM);
                _loc_4 = int(_loc_7);
                _loc_7 = this.mGeneralInterface.mZoom.Scale(cBackbuffer.mClipMaxX - global.screenWidthHalf, cZoom.DEFAULT_ZOOM);
                _loc_5 = int(_loc_7);
                _loc_7 = this.mGeneralInterface.mZoom.Scale(cBackbuffer.mClipMaxY - global.screenHeightHalf, cZoom.DEFAULT_ZOOM);
                _loc_6 = int(_loc_7);
                _loc_3 = _loc_3 / global.streetGridX;
                _loc_4 = _loc_4 / global.streetGridYHalf;
                _loc_5 = _loc_5 / global.streetGridX;
                _loc_6 = _loc_6 / global.streetGridYHalf;
                _loc_5 = _loc_5 + 1;
                _loc_6 = _loc_6 + 1;
                if (_loc_3 < defines.STREET_MAP_MIN_USABLE_AREA_X)
                {
                    _loc_3 = defines.STREET_MAP_MIN_USABLE_AREA_X;
                }
                if (_loc_4 < defines.STREET_MAP_MIN_USABLE_AREA_Y)
                {
                    _loc_4 = defines.STREET_MAP_MIN_USABLE_AREA_Y;
                }
                if (_loc_5 > defines.STREET_MAP_MAX_USABLE_AREA_X)
                {
                    _loc_5 = defines.STREET_MAP_MAX_USABLE_AREA_X;
                }
                if (_loc_6 > defines.STREET_MAP_MAX_USABLE_AREA_Y)
                {
                    _loc_6 = defines.STREET_MAP_MAX_USABLE_AREA_Y;
                }
            }
            else
            {
                _loc_3 = defines.STREET_MAP_MIN_USABLE_AREA_X;
                _loc_4 = defines.STREET_MAP_MIN_USABLE_AREA_Y;
                _loc_5 = defines.STREET_MAP_MAX_USABLE_AREA_X;
                _loc_6 = defines.STREET_MAP_MAX_USABLE_AREA_Y;
            }
            param2.minX = _loc_3;
            param2.minY = _loc_4;
            param2.maxX = _loc_5;
            param2.maxY = _loc_6;
            return;
        }// end function

        public function LogicCompute() : void
        {
            var _loc_3:cBuilding = null;
            var _loc_4:int = 0;
            var _loc_1:* = this.GetBuildings_vector();
            var _loc_2:int = 0;
            while (_loc_2 < _loc_1.length)
            {
                
                _loc_3 = _loc_1[_loc_2];
                _loc_4 = _loc_1.length;
                _loc_3.Compute();
                _loc_2 = _loc_2 - (_loc_4 - _loc_1.length);
                _loc_2++;
            }
            return;
        }// end function

        public function RecalculateBlockingGridAndPathFinding(param1:int) : void
        {
            var _loc_2:cBuilding = null;
            if (!this.mGeneralInterface.mRefreshZoneIsActive)
            {
                this.CalculateBlockingGrid();
                this.mGeneralInterface.mPathFinder.InvalidateAll(param1);
                for each (_loc_2 in this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.GetBuildings_vector())
                {
                    
                    if (_loc_2.GetResourceCreation() != null)
                    {
                        _loc_2.GetResourceCreation().SetInvalidatePaths(true);
                    }
                }
            }
            return;
        }// end function

        public function RenderGrid() : void
        {
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            var _loc_1:* = new cClippingRectangle();
            this.CalculateMapClipping(GCB_MODE_CLIPPING.CLIP_TO_SCREEN_FOREGROUND, _loc_1);
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            var _loc_4:* = global.streetGridX * _loc_1.minX;
            _loc_3 = _loc_3 + global.streetGridYHalf * _loc_1.minY;
            var _loc_5:* = _loc_1.minY;
            while (_loc_5 <= _loc_1.maxY)
            {
                
                if ((_loc_5 & 1) == 0)
                {
                    _loc_2 = -global.streetGridXHalf + _loc_4;
                }
                else
                {
                    _loc_2 = _loc_4;
                }
                _loc_6 = (_loc_5 << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + _loc_1.minX;
                _loc_7 = _loc_1.minX;
                while (_loc_7 <= _loc_1.maxX)
                {
                    
                    if ((_loc_5 & 1) == 0)
                    {
                        this.mGeneralInterface.mStreetCursorGrid.SetPosition(_loc_2, _loc_3);
                        this.mGeneralInterface.mStreetCursorGrid.Render();
                    }
                    _loc_2 = _loc_2 + global.streetGridX;
                    _loc_6++;
                    _loc_7++;
                }
                _loc_3 = _loc_3 + global.streetGridYHalf;
                _loc_5++;
            }
            return;
        }// end function

        public function SetMilitaryPreviewPath(param1:cPlayerData, param2:int) : void
        {
            var _loc_3:* = new cStreet(this.mGeneralInterface);
            gCalculations.ConvertStreetGridToPixelPos(param2, this.mTempPos);
            _loc_3.SetPosition(this.mTempPos.x, this.mTempPos.y);
            this.mStreetCreationPreview_vector.push(_loc_3);
            return;
        }// end function

        public function RenderFreeBackground(param1:int) : void
        {
            var _loc_2:cFreeLandscape = null;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            for each (_loc_2 in this.mFreeLandscape_vector)
            {
                
                _loc_3 = _loc_2.GetX();
                _loc_4 = _loc_2.GetY();
                _loc_2.RenderPos(_loc_3, _loc_4);
            }
            return;
        }// end function

        public function CreateStreetWayFromPathStreet(param1:cPlayerData, param2:cPathObject, param3:Boolean) : void
        {
            var _loc_4:cPlayerZoneScreen = null;
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            var _loc_8:int = 0;
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            var _loc_11:int = 0;
            var _loc_15:String = null;
            var _loc_16:int = 0;
            var _loc_5:* = param2.dest_vector.length;
            if (param3)
            {
                this.ResetStreetPreview();
            }
            if (_loc_5 < 2)
            {
                return;
            }
            var _loc_12:* = new dPathObjectItem();
            var _loc_13:* = new dPathObjectItem();
            var _loc_14:* = new dPathObjectItem();
            _loc_6 = 0;
            while (_loc_6 < _loc_5)
            {
                
                if (_loc_6 > 0)
                {
                    _loc_12 = param2.dest_vector[(_loc_6 - 1)] as dPathObjectItem;
                }
                _loc_13 = param2.dest_vector[_loc_6] as dPathObjectItem;
                if (_loc_6 < (_loc_5 - 1))
                {
                    _loc_14 = param2.dest_vector[(_loc_6 + 1)] as dPathObjectItem;
                }
                _loc_7 = GetStreetDirection(_loc_13, _loc_12);
                _loc_8 = GetStreetDirection(_loc_13, _loc_14);
                _loc_15 = "";
                if (_loc_6 == 0)
                {
                    _loc_15 = "" + _loc_8;
                }
                else if (_loc_6 == (_loc_5 - 1))
                {
                    _loc_15 = "" + _loc_7;
                }
                else
                {
                    if (_loc_7 > _loc_8)
                    {
                        _loc_16 = _loc_7;
                        _loc_7 = _loc_8;
                        _loc_8 = _loc_16;
                    }
                    if (_loc_7 == 0)
                    {
                        if (_loc_8 == 1)
                        {
                            _loc_15 = "01";
                        }
                        else if (_loc_8 == 2)
                        {
                            _loc_15 = "02";
                        }
                        else if (_loc_8 == 3)
                        {
                            _loc_15 = "03";
                        }
                    }
                    else if (_loc_7 == 1)
                    {
                        if (_loc_8 == 2)
                        {
                            _loc_15 = "12";
                        }
                        else if (_loc_8 == 3)
                        {
                            _loc_15 = "13";
                        }
                    }
                    else if (_loc_7 == 2)
                    {
                        if (_loc_8 == 3)
                        {
                            _loc_15 = "23";
                        }
                    }
                }
                if (_loc_15 != "")
                {
                    _loc_4 = this.mGeneralInterface.mCurrentPlayerZone;
                    if (_loc_13.x > _loc_4.mSectorStartX && _loc_13.x < _loc_4.mSectorEndX && _loc_13.y > _loc_4.mSectorStartY && _loc_13.y < _loc_4.mSectorEndY)
                    {
                        _loc_4.mStreetDataMap.SetStreet(param1, _loc_15, _loc_13.streetGridIdx, param3);
                    }
                }
                _loc_6++;
            }
            return;
        }// end function

        public function RenderIsoElementDebugInfo(param1:Graphics) : void
        {
            var _loc_2:cClippingRectangle = null;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            var _loc_8:int = 0;
            if (this.mGeneralInterface.showIsoDebugGrid && ACTIVATE_ISO_RENDER_DEBUG_INFO)
            {
                _loc_2 = new cClippingRectangle();
                this.CalculateMapClipping(GCB_MODE_CLIPPING.CLIP_TO_SCREEN_FOREGROUND, _loc_2);
                _loc_3 = 0;
                _loc_4 = 0;
                _loc_5 = global.streetGridX * _loc_2.minX;
                _loc_4 = _loc_4 + global.streetGridYHalf * _loc_2.minY;
                _loc_6 = _loc_2.minY;
                while (_loc_6 <= _loc_2.maxY)
                {
                    
                    if ((_loc_6 & 1) == 0)
                    {
                        _loc_3 = -global.streetGridXHalf + _loc_5;
                    }
                    else
                    {
                        _loc_3 = _loc_5;
                    }
                    _loc_7 = (_loc_6 << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + _loc_2.minX;
                    _loc_8 = _loc_2.minX;
                    while (_loc_8 <= _loc_2.maxX)
                    {
                        
                        this.mGeneralInterface.mStreetCursorGrid.SetPosition(_loc_3, _loc_4);
                        this.mGeneralInterface.mStreetCursorGrid.Render();
                        if (this.mIsoMap_list[_loc_7].mFogBorder != 0)
                        {
                            this.mGeneralInterface.mCurrentPlayerZone.RenderText(cBackbuffer.mBackBuffer, "" + this.mIsoMap_list[_loc_7].mFogBorder, _loc_3 - 16, _loc_4 - 50);
                        }
                        _loc_3 = _loc_3 + global.streetGridX;
                        _loc_7++;
                        _loc_8++;
                    }
                    _loc_4 = _loc_4 + global.streetGridYHalf;
                    _loc_6++;
                }
            }
            return;
        }// end function

        public function CheckIfBuildingIsSouthSouthEastAndSouthWest(param1:int) : cBuilding
        {
            var _loc_2:int = 0;
            var _loc_3:cBuilding = null;
            var _loc_4:cIsoElement = null;
            var _loc_5:cBuilding = null;
            if (!defines.EXTENDED_BUILDING_SELECTION)
            {
                return null;
            }
            _loc_2 = gCalculations.MoveStreetGridToDir8(param1, defines.DIR8_SOUTH);
            _loc_3 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_2].mBuilding;
            if (_loc_3 != null && _loc_3.GetGoGroup() == global.buildingGroup && !global.hiddenBanditCamps_dictionary.Contains(_loc_3.GetBuildingName_string()))
            {
                return _loc_3;
            }
            _loc_2 = gCalculations.MoveStreetGridToDir8(param1, defines.DIR8_SOUTH_EAST);
            _loc_3 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_2].mBuilding;
            if (_loc_3 != null && _loc_3.GetGoGroup() == global.buildingGroup && !global.hiddenBanditCamps_dictionary.Contains(_loc_3.GetBuildingName_string()))
            {
                return _loc_3;
            }
            _loc_2 = gCalculations.MoveStreetGridToDir8(param1, defines.DIR8_SOUTH_WEST);
            _loc_3 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_2].mBuilding;
            if (_loc_3 != null && _loc_3.GetGoGroup() == global.buildingGroup && !global.hiddenBanditCamps_dictionary.Contains(_loc_3.GetBuildingName_string()))
            {
                return _loc_3;
            }
            _loc_4 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[param1];
            if (_loc_4.mBlockedIsoElementSource != null)
            {
                _loc_5 = _loc_4.mBlockedIsoElementSource.mBuilding as cBuilding;
                if (_loc_5 != null && _loc_5.GetGoGroup() == global.buildingGroup && !global.hiddenBanditCamps_dictionary.Contains(_loc_5.GetBuildingName_string()))
                {
                    return _loc_4.mBlockedIsoElementSource.mBuilding;
                }
            }
            return null;
        }// end function

        public function GetBuildingNameFromGridPos_string(param1:int) : String
        {
            var _loc_2:* = this.mIsoMap_list[param1].mBuilding;
            if (_loc_2 != null)
            {
                return _loc_2.GetContainerName_string();
            }
            return null;
        }// end function

        public function RenderSectorGrid() : void
        {
            var _loc_8:int = 0;
            var _loc_9:int = 0;
            var _loc_10:cIsoElement = null;
            var _loc_11:int = 0;
            var _loc_1:* = new cClippingRectangle();
            this.CalculateMapClipping(GCB_MODE_CLIPPING.CLIP_TO_SCREEN_FOREGROUND, _loc_1);
            var _loc_2:int = 0;
            var _loc_3:* = -global.streetGridYHalf;
            var _loc_4:int = 0;
            var _loc_5:int = -0;
            var _loc_6:* = global.streetGridX * _loc_1.minX;
            _loc_5 = _loc_5 + global.streetGridYHalf * _loc_1.minY;
            var _loc_7:* = _loc_1.minY;
            while (_loc_7 <= _loc_1.maxY)
            {
                
                if ((_loc_7 & 1) == 0)
                {
                    _loc_4 = -global.streetGridXHalf + _loc_6;
                }
                else
                {
                    _loc_4 = _loc_6;
                }
                _loc_8 = (_loc_7 << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + _loc_1.minX;
                _loc_9 = _loc_1.minX;
                while (_loc_9 <= _loc_1.maxX)
                {
                    
                    _loc_10 = this.mIsoMap_list[_loc_8];
                    _loc_11 = _loc_10.mSectorId & 7;
                    this.RenderStreetCursorColor(_loc_11, _loc_4, _loc_5);
                    this.mGeneralInterface.mCurrentPlayerZone.RenderTextCenter(cBackbuffer.mBackBuffer, gMisc.ConvertDoubleToString_string(_loc_10.mSectorId), _loc_4 + _loc_2, _loc_5 + _loc_3);
                    _loc_4 = _loc_4 + global.streetGridX;
                    _loc_8++;
                    _loc_9++;
                }
                _loc_5 = _loc_5 + global.streetGridYHalf;
                _loc_7++;
            }
            return;
        }// end function

        private function CalculateStreetVariation(param1:int, param2:cStreet, param3:cStreet, param4:Boolean) : Boolean
        {
            if (--param1 < 0)
            {
                --param1 = 0;
            }
            if (this.mGeneralInterface.IsAdventureZoneID(this.mGeneralInterface.mHomePlayer.GetPlayerId()))
            {
                --param1 = 0;
            }
            var _loc_6:int = -1;
            if (param2 != null)
            {
                if (param2.GetContainerName_string() == param3.GetContainerName_string())
                {
                    _loc_6 = param2.GetVariationNr();
                    if (--param1 != param2.GetStreetCityLevel())
                    {
                        _loc_6 = -1;
                    }
                }
            }
            param3.SetStreetCityLevel(_loc_5);
            if (_loc_6 == -1)
            {
                if (!param4)
                {
                    _loc_6 = gMisc.GetRandomMinMaxInt(0, 99);
                }
                else
                {
                    _loc_6 = 0;
                }
                param3.SetVariationNr(_loc_6);
            }
            return true;
        }// end function

        public function DepositGroupConvertXMLStringToMap(param1:String, param2:int) : void
        {
            var _loc_4:int = 0;
            var _loc_7:cXML = null;
            var _loc_8:int = 0;
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            var _loc_11:String = null;
            var _loc_12:cDepositGroup = null;
            var _loc_3:* = new cXML();
            _loc_3.SetXMLString(param1);
            var _loc_5:* = _loc_3.MoveToSubNode("DepositGroups");
            var _loc_6:* = _loc_3.MoveToSubNode("DepositGroups").CreateChildrenArray();
            this.mGeneralInterface.mServerOnly.mDepositGroups_vector.length = 0;
            for each (_loc_7 in _loc_6)
            {
                
                _loc_8 = _loc_7.GetAttributeInt("id");
                _loc_9 = _loc_7.GetAttributeInt("maxAccessible");
                _loc_10 = _loc_7.GetAttributeInt("averageAmount");
                _loc_11 = _loc_7.GetAttributeString_string("depositName");
                _loc_12 = new cDepositGroup(this.mGeneralInterface, _loc_8, _loc_9, _loc_10, 0, _loc_11);
                this.mGeneralInterface.mServerOnly.mDepositGroups_vector.push(_loc_12);
            }
            _loc_4 = 0;
            while (_loc_4 < defines.STREET_MAP_SIZE_FINAL)
            {
                
                this.mIsoMap_list[_loc_4].mDeposit = null;
                _loc_4++;
            }
            this.mDeposits_vector = new Vector.<cDeposit>;
            this.UpdateObjectPositions();
            return;
        }// end function

        public function Clear() : void
        {
            var _loc_1:int = 0;
            _loc_1 = 0;
            while (_loc_1 < defines.STREET_MAP_SIZE_FINAL)
            {
                
                this.mIsoMap_list[_loc_1].Clear();
                _loc_1++;
            }
            this.mFreeLandscape_vector.length = 0;
            this.mLandingFields_vector.length = 0;
            this.ResetListsAndScrolling();
            return;
        }// end function

        public function ShowStreetPreview() : void
        {
            var _loc_1:cStreet = null;
            for each (_loc_1 in this.mStreetCreationPreview_vector)
            {
                
                _loc_1.Render();
            }
            return;
        }// end function

        public function Init() : void
        {
            return;
        }// end function

        public function RefreshGuildHouse() : void
        {
            var _loc_1:cBuilding = null;
            this.SetGuildHouse(null);
            for each (_loc_1 in this.GetBuildings_vector())
            {
                
                if (_loc_1.GetBuildingName_string() == defines.GUILDHOUSE_NAME_string)
                {
                    this.SetGuildHouse(_loc_1);
                    break;
                }
            }
            return;
        }// end function

        public function RenderDepositsAll() : void
        {
            var _loc_1:int = 0;
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_8:cIsoElement = null;
            var _loc_9:cDeposit = null;
            var _loc_12:int = 0;
            var _loc_13:String = null;
            var _loc_14:String = null;
            var _loc_15:int = 0;
            var _loc_16:int = 0;
            this.CalculateMapClipping(GCB_MODE_CLIPPING.CLIP_TO_SCREEN_FOREGROUND, this.mTempClippingRectangle);
            _loc_1 = this.mTempClippingRectangle.minX;
            _loc_2 = this.mTempClippingRectangle.minY;
            _loc_3 = this.mTempClippingRectangle.maxX;
            _loc_4 = this.mTempClippingRectangle.maxY;
            var _loc_5:int = -32;
            var _loc_6:* = -(global.streetGridY - 12);
            var _loc_7:int = 28;
            var _loc_10:int = 0;
            var _loc_11:* = _loc_2 - 1;
            while (_loc_11 <= (_loc_4 + 1))
            {
                
                _loc_10 = (_loc_11 << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + _loc_1;
                _loc_12 = _loc_1;
                while (_loc_12 <= _loc_3)
                {
                    
                    _loc_8 = this.mIsoMap_list[_loc_10];
                    _loc_9 = _loc_8.mDeposit;
                    if (_loc_9 != null)
                    {
                        _loc_13 = _loc_9.GetName_string();
                        _loc_14 = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, _loc_13);
                        _loc_15 = int(_loc_9.GetX());
                        _loc_16 = int(_loc_9.GetY());
                        if (_loc_9.GetAccessibleType() == DEPOSIT_ACCESSIBLE_TYPES.ACCESSIBLE)
                        {
                            _loc_9.RenderPos(_loc_15, _loc_16);
                            this.mGeneralInterface.mCurrentPlayerZone.RenderText(cBackbuffer.mBackBuffer, gMisc.ConvertDoubleToString_string(_loc_9.GetAmount()) + " " + _loc_14, _loc_15 + _loc_5, _loc_16 + _loc_6);
                        }
                        else
                        {
                            this.mGeneralInterface.mCurrentPlayerZone.RenderText(cBackbuffer.mBackBuffer, "[" + gMisc.ConvertDoubleToString_string(_loc_9.GetAmount()) + " " + _loc_13 + " in Group: " + _loc_9.GetDepositGroupID() + "]", _loc_15 + _loc_5, _loc_16 + _loc_6);
                            _loc_9.RenderTransform(_loc_15, _loc_16, BlendMode.DARKEN, 1, 1, 0);
                        }
                    }
                    _loc_10++;
                    _loc_12++;
                }
                _loc_11++;
            }
            return;
        }// end function

        public function RenderFog() : void
        {
            var _loc_12:int = 0;
            var _loc_13:int = 0;
            var _loc_14:int = 0;
            var _loc_15:int = 0;
            var _loc_16:int = 0;
            var _loc_1:* = new cClippingRectangle();
            this.CalculateMapClipping(GCB_MODE_CLIPPING.CLIP_TO_SCREEN_FOREGROUND, _loc_1);
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            var _loc_4:* = global.streetGridX * _loc_1.minX;
            _loc_3 = _loc_3 + global.streetGridYHalf * _loc_1.minY;
            var _loc_5:int = 0;
            var _loc_6:int = 3;
            var _loc_7:int = 3;
            var _loc_8:* = gMisc.GetTimeSinceStartup() / 120;
            var _loc_9:* = _loc_1.minX % _loc_6;
            _loc_4 = _loc_4 - _loc_9 * global.streetGridX;
            _loc_1.minX = _loc_1.minX - _loc_9;
            _loc_1.maxX = _loc_1.maxX + (_loc_6 - _loc_9);
            var _loc_10:* = _loc_1.minY % _loc_7;
            _loc_3 = _loc_3 - _loc_10 * global.streetGridYHalf;
            _loc_1.minY = _loc_1.minY - _loc_10;
            this.mGeneralInterface.mFog.SetSubType(0);
            var _loc_11:* = _loc_1.minY;
            while (_loc_11 <= _loc_1.maxY)
            {
                
                if ((_loc_11 & 1) == 0)
                {
                    _loc_2 = -global.streetGridXHalf + _loc_4;
                }
                else
                {
                    _loc_2 = _loc_4;
                }
                _loc_12 = (_loc_11 << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + _loc_1.minX;
                _loc_13 = _loc_1.minX;
                while (_loc_13 < _loc_1.maxX + 2)
                {
                    
                    if (this.mIsoMap_list[_loc_12].mFogBorder > 1)
                    {
                        _loc_14 = 0;
                        if ((_loc_11 & 3) == 0)
                        {
                            _loc_5 = (_loc_12 + _loc_11 / _loc_6) % 3;
                        }
                        else
                        {
                            _loc_5 = (_loc_12 + _loc_13) / _loc_6 % 3;
                        }
                        this.mGeneralInterface.mFog.SetAnimFrame(_loc_5);
                        _loc_15 = _loc_8 + (_loc_13 << 4) & 255;
                        _loc_16 = _loc_8 + (_loc_11 << 3) & 255;
                        this.mGeneralInterface.mFog.RenderPos(_loc_2 + this.mSinTable_vector[_loc_15], _loc_3 + this.mCosTable_vector[_loc_16]);
                    }
                    _loc_2 = _loc_2 + global.streetGridX * _loc_6;
                    _loc_12 = _loc_12 + _loc_6;
                    _loc_13 = _loc_13 + _loc_6;
                }
                _loc_3 = _loc_3 + global.streetGridYHalf * _loc_7;
                _loc_11 = _loc_11 + _loc_7;
            }
            return;
        }// end function

        public function SetBuildingGridPos(param1:cGO, param2:int, param3:Boolean) : Boolean
        {
            var _loc_5:String = null;
            var _loc_4:* = param1 as cBuilding;
            gCalculations.ConvertStreetGridToPixelPos(param2, this.mTempPos);
            _loc_4.SetPosition(this.mTempPos.x, this.mTempPos.y + global.streetGridYHalf);
            if (param2 == defines.ILLEGAL_INT_POS)
            {
                return false;
            }
            this.mIsoMap_list[param2].mBuilding = _loc_4;
            if (this.mIsoMap_list[param2].mLandscape != null)
            {
                _loc_5 = this.mIsoMap_list[param2].mLandscape.GetContainerName_string();
                if (this.mGeneralInterface.mCurrentPlayerZone.IsDepositFoundType(_loc_5))
                {
                    this.mGeneralInterface.mCurrentPlayerZone.RemoveDepositIcon(param2);
                }
            }
            this.AddBuildingToList(_loc_4);
            _loc_4.mBuildingCreationTime = this.mGeneralInterface.GetClientTime();
            _loc_4.SetBuildingGrid(param2);
            _loc_4.SetBuildingMode(cBuilding.BUILDING_MODE_NONE);
            _loc_4.SetStreetGridEntry(gCalculations.MoveStreetGridToDir8(param2, defines.DIR8_SOUTH_EAST));
            if (this.mGeneralInterface.mEnumUIType == UITYPE.GAME)
            {
                if (!param3)
                {
                    _loc_4.SetBuildingMode(cBuilding.BUILDING_MODE_PRODUCES_NO_RESOURCES);
                }
                else
                {
                    _loc_4.SetBuildingMode(cBuilding.BUILDING_MODE_QUEUED);
                    this.AddBuildingToGameLogic(_loc_4);
                }
            }
            else
            {
                _loc_4.SetBuildingMode(cBuilding.BUILDING_MODE_PRODUCES_NO_RESOURCES);
            }
            this.mGeneralInterface.mCurrentPlayerZone.mSettlerKIManager.BuildingWasPlaced(_loc_4, param2);
            this.RecalculateBlockingGridAndPathFinding(_loc_4.GetPlayerID());
            return true;
        }// end function

        public function ShowMilitaryPathPreview() : void
        {
            var _loc_2:cStreet = null;
            var _loc_1:int = 0;
            for each (_loc_2 in this.mStreetCreationPreview_vector)
            {
                
                if (_loc_1 >= 2)
                {
                    _loc_1 = 0;
                    _loc_2.RenderMilitryPathPreview();
                }
                _loc_1++;
            }
            return;
        }// end function

        public function ReAssignSectorID(param1:int, param2:int) : void
        {
            var _loc_3:cIsoElement = null;
            for each (_loc_3 in this.mIsoMap_list)
            {
                
                if (_loc_3.mSectorId == param1)
                {
                    _loc_3.mSectorId = param2;
                }
            }
            return;
        }// end function

        public function RemoveBuildingFromList(param1:cBuilding) : void
        {
            var _loc_2:int = 0;
            var _loc_4:cBuilding = null;
            var _loc_3:* = param1.GetBuildingGrid();
            _loc_2 = 0;
            while (_loc_2 < this.mBuildings_vector.length)
            {
                
                if (this.mBuildings_vector[_loc_2].GetBuildingGrid() == _loc_3)
                {
                    this.mBuildings_vector.splice(_loc_2, 1);
                    _loc_2 = _loc_2 - 1;
                }
                _loc_2++;
            }
            _loc_2 = 0;
            while (_loc_2 < this.mBuildingsAndTrees_vector.length)
            {
                
                if (this.mBuildingsAndTrees_vector[_loc_2] is cBuilding)
                {
                    _loc_4 = this.mBuildingsAndTrees_vector[_loc_2] as cBuilding;
                    if (_loc_4.GetBuildingGrid() == _loc_3)
                    {
                        this.mBuildingsAndTrees_vector.splice(_loc_2, 1);
                        _loc_2 = _loc_2 - 1;
                    }
                }
                _loc_2++;
            }
            return;
        }// end function

        public function RemoveStreetFromList(param1:cStreet) : void
        {
            var _loc_2:int = 0;
            _loc_2 = this.mStreets_vector.indexOf(param1);
            if (_loc_2 != -1)
            {
                this.mStreets_vector.splice(_loc_2, 1);
            }
            return;
        }// end function

        public function SetPrePlaceBuildingGridPosWithLevel(param1:cPlayerData, param2:String, param3:int, param4:int) : Boolean
        {
            var _loc_6:cLandscape = null;
            var _loc_7:String = null;
            if (!this.RemoveDepletedDepositBuildingIfOneIsThere(param3))
            {
                return false;
            }
            var _loc_5:* = cBuilding.CreateFromString(param1, global.buildingGroup, param2, this.mGeneralInterface);
            gCalculations.ConvertStreetGridToPixelPos(param3, this.mTempPos);
            _loc_5.SetPosition(this.mTempPos.x, this.mTempPos.y + global.streetGridYHalf);
            if (param3 == defines.ILLEGAL_INT_POS)
            {
                return false;
            }
            this.mIsoMap_list[param3].mBuilding = _loc_5;
            if (this.mIsoMap_list[param3].mLandscape != null)
            {
                _loc_6 = this.mIsoMap_list[param3].mLandscape;
                _loc_7 = _loc_6.GetContainerName_string();
                if (!this.mGeneralInterface.mCurrentPlayerZone.IsDepositFoundType(_loc_7))
                {
                    this.mIsoMap_list[param3].mLandscape = null;
                }
            }
            param1.AddPrePlacesBuildingToList(_loc_5);
            this.AddBuildingToList(_loc_5);
            _loc_5.mBuildingCreationTime = this.mGeneralInterface.GetClientTime();
            _loc_5.SetBuildingGrid(param3);
            _loc_5.SetBuildingMode(cBuilding.BUILDING_MODE_NONE);
            _loc_5.SetStreetGridEntry(gCalculations.MoveStreetGridToDir8(param3, defines.DIR8_SOUTH_EAST));
            _loc_5.SetUpgradeLevel(param4);
            _loc_5.SetBuildingMode(cBuilding.BUILDING_MODE_PLACED);
            if (!this.mGeneralInterface.mRefreshZoneIsActive)
            {
                this.CalculateBlockingGrid();
            }
            return true;
        }// end function

        public function SetLandscapeGridPos(param1:cGO, param2:int) : Boolean
        {
            var _loc_4:cLandscape = null;
            var _loc_5:int = 0;
            var _loc_3:* = param1 as cLandscape;
            if (this.mIsoMap_list[param2].mLandscape != null)
            {
                _loc_4 = this.mIsoMap_list[param2].mLandscape;
                _loc_5 = this.mBuildingsAndTrees_vector.indexOf(_loc_4);
                if (_loc_5 != -1)
                {
                    this.mBuildingsAndTrees_vector.splice(_loc_5, 1);
                }
            }
            gCalculations.ConvertStreetGridToPixelPos(param2, this.mTempPos);
            _loc_3.SetPosition(this.mTempPos.x, this.mTempPos.y + global.streetGridYHalf);
            _loc_3.SetName_string(param1.GetContainerName_string());
            _loc_3.SetGrid(param2);
            if (param2 == defines.ILLEGAL_INT_POS)
            {
                return false;
            }
            this.mIsoMap_list[param2].mLandscape = _loc_3;
            this.AddLandscapeToList(_loc_3);
            return true;
        }// end function

        public function ResetStreetPreview() : void
        {
            this.mStreetCreationPreview_vector = new Vector.<cStreet>;
            return;
        }// end function

        public function GetStreetFromGridPosition(param1:int) : cStreet
        {
            return this.mIsoMap_list[param1].mStreet;
        }// end function

        public function RenderStreets(param1:int) : void
        {
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            var _loc_26:Number = NaN;
            var _loc_27:cIsoElement = null;
            var _loc_28:cStreet = null;
            var _loc_29:int = 0;
            if (param1 == GCB_MODE_CLIPPING.CLIP_TO_SCREEN_BACKGROUND)
            {
                _loc_26 = this.mGeneralInterface.mZoom.Scale(cBackbuffer.mClipMinX - global.screenWidthHalf, cZoom.DEFAULT_ZOOM);
                _loc_2 = int(_loc_26);
                _loc_26 = this.mGeneralInterface.mZoom.Scale(cBackbuffer.mClipMinY - global.screenHeightHalf, cZoom.DEFAULT_ZOOM);
                _loc_3 = int(_loc_26);
                _loc_26 = this.mGeneralInterface.mZoom.Scale(cBackbuffer.mClipMaxX - global.screenWidthHalf, cZoom.DEFAULT_ZOOM);
                _loc_4 = int(_loc_26);
                _loc_26 = this.mGeneralInterface.mZoom.Scale(cBackbuffer.mClipMaxY - global.screenHeightHalf, cZoom.DEFAULT_ZOOM);
                _loc_5 = int(_loc_26);
                _loc_2 = _loc_2 / global.streetGridX;
                _loc_3 = _loc_3 / global.streetGridYHalf;
                _loc_4 = _loc_4 / global.streetGridX;
                _loc_5 = _loc_5 / global.streetGridYHalf;
                _loc_2 = _loc_2 - 4;
                _loc_3 = _loc_3 - 6;
                _loc_4 = _loc_4 + 5;
                _loc_5 = _loc_5 + 5;
                if (_loc_2 < defines.STREET_MAP_MIN_USABLE_AREA_X)
                {
                    _loc_2 = defines.STREET_MAP_MIN_USABLE_AREA_X;
                }
                if (_loc_3 < defines.STREET_MAP_MIN_USABLE_AREA_Y)
                {
                    _loc_3 = defines.STREET_MAP_MIN_USABLE_AREA_Y;
                }
                if (_loc_4 > defines.STREET_MAP_MAX_USABLE_AREA_X)
                {
                    _loc_4 = defines.STREET_MAP_MAX_USABLE_AREA_X;
                }
                if (_loc_5 > defines.STREET_MAP_MAX_USABLE_AREA_Y)
                {
                    _loc_5 = defines.STREET_MAP_MAX_USABLE_AREA_Y;
                }
            }
            else
            {
                this.CalculateMapClipping(param1, this.mTempClippingRectangle);
                _loc_2 = this.mTempClippingRectangle.minX;
                _loc_3 = this.mTempClippingRectangle.minY;
                _loc_4 = this.mTempClippingRectangle.maxX;
                _loc_5 = this.mTempClippingRectangle.maxY;
            }
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            var _loc_8:int = 0;
            var _loc_11:* = global.streetGridX * _loc_2;
            _loc_7 = _loc_7 + global.streetGridYHalf * _loc_3;
            var _loc_12:* = new cPosInt();
            new cPosInt().x = global.streetGridXHalf / 2;
            _loc_12.y = global.streetGridYHalf / 2;
            var _loc_13:* = _loc_12.x * _loc_12.x + _loc_12.y * _loc_12.y;
            var _loc_14:* = gMisc.FastIntegerSqrt(_loc_13);
            var _loc_15:* = new cPosInt();
            var _loc_16:* = 75 * _loc_14 / 100;
            _loc_15.x = _loc_12.x * _loc_16 / _loc_14;
            _loc_15.y = _loc_12.y * _loc_16 / _loc_14;
            _loc_16 = 175 * _loc_14 / 100;
            var _loc_17:* = new cPosInt();
            new cPosInt().x = _loc_12.x * _loc_16 / _loc_14;
            _loc_17.y = _loc_12.y * _loc_16 / _loc_14;
            var _loc_18:* = _loc_15.x;
            var _loc_19:* = -global.streetGridYHalf - _loc_15.y;
            var _loc_20:* = -_loc_15.x;
            var _loc_21:* = -global.streetGridYHalf - _loc_15.y;
            var _loc_22:* = _loc_15.x;
            var _loc_23:* = -global.streetGridYHalf + _loc_15.y;
            var _loc_24:* = -_loc_15.x;
            var _loc_25:* = -global.streetGridYHalf + _loc_15.y;
            _loc_10 = _loc_3;
            while (_loc_10 <= _loc_5)
            {
                
                if ((_loc_10 & 1) == 0)
                {
                    _loc_6 = -global.streetGridXHalf + _loc_11;
                }
                else
                {
                    _loc_6 = _loc_11;
                }
                _loc_8 = (_loc_10 << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + _loc_2;
                _loc_9 = _loc_2;
                while (_loc_9 <= _loc_4)
                {
                    
                    _loc_27 = this.mIsoMap_list[_loc_8];
                    if (_loc_27.mFogBorder < 3)
                    {
                        if (_loc_27.mStreet != null)
                        {
                            _loc_28 = _loc_27.mStreet;
                            _loc_28.SetPosition(_loc_6, _loc_7);
                            _loc_28.Render();
                        }
                        if (_loc_27.mBorder != 0)
                        {
                            _loc_29 = _loc_27.mBorder;
                            if (_loc_29 != 0)
                            {
                                this.mGeneralInterface.mBorder.SetSubType(_loc_27.mBorderColor);
                                if ((_loc_29 & defines.DIR8_NORTH_EAST_BIT) > 0)
                                {
                                    this.mGeneralInterface.mBorder.RenderPos(_loc_6 + _loc_18, _loc_7 + _loc_19);
                                }
                                if ((_loc_29 & defines.DIR8_NORTH_WEST_BIT) > 0)
                                {
                                    this.mGeneralInterface.mBorder.RenderPos(_loc_6 + _loc_20, _loc_7 + _loc_21);
                                }
                                if ((_loc_29 & defines.DIR8_SOUTH_EAST_BIT) > 0)
                                {
                                    this.mGeneralInterface.mBorder.RenderPos(_loc_6 + _loc_22, _loc_7 + _loc_23);
                                }
                                if ((_loc_29 & defines.DIR8_SOUTH_WEST_BIT) > 0)
                                {
                                    this.mGeneralInterface.mBorder.RenderPos(_loc_6 + _loc_24, _loc_7 + _loc_25);
                                }
                            }
                        }
                    }
                    _loc_6 = _loc_6 + global.streetGridX;
                    _loc_8++;
                    _loc_9++;
                }
                _loc_7 = _loc_7 + global.streetGridYHalf;
                _loc_10++;
            }
            return;
        }// end function

        public function UpgradeBuildingGridPos(param1:cPlayerData, param2:int) : Boolean
        {
            var _loc_3:cBuilding = null;
            var _loc_4:cResources = null;
            if (this.mIsoMap_list[param2].mBuilding != null)
            {
                _loc_3 = this.mIsoMap_list[param2].mBuilding;
                if (this.mGeneralInterface.mEnumUIType == UITYPE.GAME && !this.mGeneralInterface.mRefreshZoneIsActive)
                {
                    _loc_4 = this.mGeneralInterface.mCurrentPlayerZone.GetResources(param1);
                    if (_loc_4.HasPlayerResourcesInListOne(_loc_3.GetUpgradeCosts_vector()))
                    {
                        _loc_3.BuyUpgrade();
                        _loc_3.StartBuildingUpgrade();
                        _loc_3.mWaitForCommand = false;
                    }
                }
            }
            this.UpdateObjectPositions();
            return true;
        }// end function

        public function SetBackgroundBlocking(param1:int, param2:int, param3:int) : void
        {
            var _loc_4:* = gCalculations.ConvertPixelPosToStreetGridPos(param1, param2);
            if (gCalculations.ConvertPixelPosToStreetGridPos(param1, param2) == defines.ILLEGAL_INT_POS)
            {
                return;
            }
            this.mIsoMap_list[_loc_4].SetBlocked(param3);
            this.mIsoMap_list[_loc_4].SetBackgroundBlocking(param3);
            return;
        }// end function

        public function RemoveStreetGridPos(param1:int) : Boolean
        {
            var _loc_2:* = this.mIsoMap_list[param1].mStreet as cStreet;
            if (_loc_2 != null)
            {
                this.mIsoMap_list[param1].mStreet = null;
                this.RemoveStreetFromList(_loc_2);
                return true;
            }
            return false;
        }// end function

        public function GetStreets_vector()
        {
            return this.mStreets_vector;
        }// end function

        public function RemoveBuildingFromGameLogic(param1:cBuilding) : void
        {
            var _loc_2:cDeposit = null;
            var _loc_3:int = 0;
            if (!this.IsADepletedDeposit(param1))
            {
                _loc_2 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[param1.GetBuildingGrid()].mDeposit;
                if (_loc_2 != null)
                {
                    this.mGeneralInterface.mPathFinder.InvalidateDepositMatrix(param1.GetPlayerID(), _loc_2.GetName_string(), cPathFinder.AMOUNT_TYPE_ABOVE_ZERO);
                    if (_loc_2.GetDepositGroupID() != -1)
                    {
                        _loc_2.SetAccessibleType(DEPOSIT_ACCESSIBLE_TYPES.NOT_ACCESSIBLE);
                        this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[param1.GetBuildingGrid()].mDeposit = null;
                    }
                    else if (param1.GetGOContainer().mAddDepositAmount != -1)
                    {
                        _loc_3 = _loc_2.GetGridIdx();
                        this.RemoveDepositGridPos(_loc_3);
                    }
                }
            }
            if (param1.GetResourceCreation() != null)
            {
                if (param1.GetResourceCreation().GetStoreHouse() == param1)
                {
                    param1.GetResourceCreation().SetStoreHouse(null);
                }
                param1.GetResourceCreation().SetRemove(true);
            }
            if (param1.IsWarehouseType())
            {
                this.mGeneralInterface.mPathFinder.InvalidateWarehouseMatrix(param1.GetPlayerID());
            }
            if (!this.mGeneralInterface.mRefreshZoneIsActive)
            {
                this.mGeneralInterface.mCurrentPlayerZone.RemoveWatchArea(OBJECTTYPE.BUILDING, param1.GetBuildingName_string(), param1);
            }
            if (param1.GetBuildingName_string() == defines.LOGISTICS_NAME_string)
            {
                this.SetLogisticsHouse(null);
            }
            if (param1.GetBuildingName_string() == defines.GUILDHOUSE_NAME_string)
            {
                this.SetGuildHouse(null);
            }
            return;
        }// end function

        public function SetLoadedFromMap(param1:Boolean) : void
        {
            this.mLoadedFromMap = param1;
            return;
        }// end function

        public function AddBuildingToList(param1:cBuilding) : void
        {
            this.mBuildings_vector.push(param1);
            this.mBuildingsAndTrees_vector.push(param1);
            return;
        }// end function

        public function SetLandscapeFreePos(param1:cGO, param2:int, param3:int) : Boolean
        {
            var _loc_4:* = param1 as cFreeLandscape;
            (param1 as cFreeLandscape).SetPosition(param2, param3);
            _loc_4.SetName_string(param1.GetContainerName_string());
            this.mFreeLandscape_vector.push(_loc_4);
            return true;
        }// end function

        public function GetDestructionProgressInPercent(param1:cBuilding) : int
        {
            var _loc_2:* = int(this.mGeneralInterface.GetClientTime() - param1.mBuildingDestructionTime);
            var _loc_3:* = _loc_2 / 10 / param1.GetGOContainer().mDestructionDuration;
            if (_loc_3 < 0)
            {
                _loc_3 = 0;
            }
            if (_loc_3 > 100)
            {
                _loc_3 = 100;
            }
            return _loc_3;
        }// end function

        public function IsLandscapeAtFreePosition(param1:int, param2:int, param3:int) : cGO
        {
            var _loc_4:cFreeLandscape = null;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            for each (_loc_4 in this.mFreeLandscape_vector)
            {
                
                _loc_5 = Math.abs(_loc_4.GetXInt() - param1);
                if (_loc_5 < param3)
                {
                    _loc_6 = Math.abs(_loc_4.GetYInt() - param2);
                    if (_loc_6 < param3)
                    {
                        return _loc_4;
                    }
                }
            }
            return null;
        }// end function

        public function RenderCursorInfo(param1:int) : void
        {
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            if (this.mGeneralInterface.mEnumUIType == UITYPE.EDITOR)
            {
                return;
            }
            var _loc_2:* = new cClippingRectangle();
            this.CalculateMapClipping(GCB_MODE_CLIPPING.CLIP_TO_SCREEN_FOREGROUND, _loc_2);
            var _loc_3:* = new cPosInt();
            gCalculations.ConvertStreetGridToPixelPos(param1, _loc_3);
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:* = global.streetGridX * _loc_2.minX;
            _loc_5 = _loc_5 + global.streetGridYHalf * _loc_2.minY;
            var _loc_7:int = 1000;
            var _loc_8:* = _loc_2.minY;
            while (_loc_8 <= _loc_2.maxY)
            {
                
                if ((_loc_8 & 1) == 0)
                {
                    _loc_4 = -global.streetGridXHalf + _loc_6;
                }
                else
                {
                    _loc_4 = _loc_6;
                }
                _loc_9 = (_loc_8 << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + _loc_2.minX;
                _loc_10 = _loc_2.minX;
                while (_loc_10 <= _loc_2.maxX)
                {
                    
                    if (this.mIsoMap_list[_loc_9].mCursorVisible == -1)
                    {
                        if (_loc_7 > 0)
                        {
                            if (this.mGeneralInterface.mCurrentCursor.CheckIfGarrisonIsPlacableInGame(_loc_9) == CURSOR_VALID.OK)
                            {
                                this.mIsoMap_list[_loc_9].mCursorVisible = 1;
                            }
                            else
                            {
                                this.mIsoMap_list[_loc_9].mCursorVisible = 0;
                            }
                            _loc_7 = _loc_7 - 1;
                        }
                    }
                    if (this.mIsoMap_list[_loc_9].mCursorVisible == 1)
                    {
                        this.mGeneralInterface.mStreetCursorMagenta.SetPosition(_loc_4, _loc_5);
                        this.mGeneralInterface.mStreetCursorMagenta.Render();
                    }
                    _loc_4 = _loc_4 + global.streetGridX;
                    _loc_9++;
                    _loc_10++;
                }
                _loc_5 = _loc_5 + global.streetGridYHalf;
                _loc_8++;
            }
            return;
        }// end function

        public function SetPrePlaceBuildingGridPos(param1:cPlayerData, param2:String, param3:int) : Boolean
        {
            return this.SetPrePlaceBuildingGridPosWithLevel(param1, param2, param3, 1);
        }// end function

        public function SetLandscapeAtFreePosition(param1:String, param2:int, param3:int) : cGO
        {
            var _loc_4:cFreeLandscape = null;
            _loc_4 = cFreeLandscape.CreateFromString(global.landscapeGroup, param1, this.mGeneralInterface);
            if (!this.SetLandscapeFreePos(_loc_4, param2, param3))
            {
                return null;
            }
            this.mGeneralInterface.mCurrentPlayerZone.LevelBackgroundHasChanged();
            return _loc_4;
        }// end function

        public function SetSectorId(param1:int, param2:int, param3:int) : void
        {
            var _loc_4:* = gCalculations.ConvertPixelPosToStreetGridPos(param1, param2);
            if (gCalculations.ConvertPixelPosToStreetGridPos(param1, param2) == defines.ILLEGAL_INT_POS)
            {
                return;
            }
            var _loc_5:* = this.mGeneralInterface.mCurrentPlayerZone.mSectorList_vector[this.mIsoMap_list[_loc_4].mSectorId];
            var _loc_6:* = this.mGeneralInterface.mCurrentPlayerZone.mSectorList_vector[this.mIsoMap_list[_loc_4].mSectorId].mAmount - 1;
            _loc_5.mAmount = _loc_6;
            var _loc_5:* = this.mGeneralInterface.mCurrentPlayerZone.mSectorList_vector[param3];
            var _loc_6:* = this.mGeneralInterface.mCurrentPlayerZone.mSectorList_vector[param3].mAmount + 1;
            _loc_5.mAmount = _loc_6;
            this.mIsoMap_list[_loc_4].mSectorId = param3;
            return;
        }// end function

        public function ResetBuildingAndLandscapeList() : void
        {
            this.mBuildings_vector.length = 0;
            this.mBuildingsAndTrees_vector.length = 0;
            return;
        }// end function

        public function AddStreetsTolist(param1:cStreet) : void
        {
            this.mStreets_vector.push(param1);
            return;
        }// end function

        public function SetStreetGridPos(param1:cGO, param2:int) : Boolean
        {
            var _loc_3:cStreet = null;
            var _loc_4:int = 0;
            if (param2 != defines.ILLEGAL_INT_POS)
            {
                if (this.mIsoMap_list[param2].mStreet != null)
                {
                    _loc_4 = this.mStreets_vector.indexOf(this.mIsoMap_list[param2].mStreet);
                    if (_loc_4 != -1)
                    {
                        this.mStreets_vector.splice(_loc_4, 1);
                    }
                }
                _loc_3 = param1 as cStreet;
                _loc_3.SetGridPos(param2);
                this.mIsoMap_list[param2].mStreet = _loc_3;
                this.AddStreetsTolist(_loc_3);
                return true;
            }
            return false;
        }// end function

        public function InitializeMap() : void
        {
            var _loc_1:int = 0;
            var _loc_3:Number = NaN;
            var _loc_4:Number = NaN;
            var _loc_5:Number = NaN;
            _loc_1 = 0;
            while (_loc_1 < defines.STREET_MAP_SIZE_FINAL)
            {
                
                this.mIsoMap_list[_loc_1] = new cIsoElement(this.mGeneralInterface, _loc_1);
                _loc_1++;
            }
            this.mSinTable_vector = new Vector.<int>;
            this.mCosTable_vector = new Vector.<int>;
            var _loc_2:int = 0;
            while (_loc_2 < 256)
            {
                
                _loc_3 = _loc_2;
                _loc_4 = Math.sin(_loc_3 * (Math.PI * 2) / 256) * 10;
                _loc_5 = Math.cos(_loc_3 * (Math.PI * 2) / 256) * 10;
                this.mSinTable_vector.push(_loc_4);
                this.mCosTable_vector.push(_loc_4);
                _loc_2++;
            }
            this.ResetListsAndScrolling();
            return;
        }// end function

        public function CalculateBlockingGrid() : void
        {
            var _loc_1:cIsoElement = null;
            var _loc_2:cBuilding = null;
            var _loc_3:cLandscape = null;
            var _loc_4:cBlockingData = null;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            for each (_loc_1 in this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list)
            {
                
                _loc_1.SetBlocked(_loc_1.GetBackgroundBlocking());
            }
            for each (_loc_1 in this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list)
            {
                
                if (_loc_1.mBuilding != null)
                {
                    _loc_2 = _loc_1.mBuilding;
                    this.mGeneralInterface.mCurrentPlayerZone.SetBlockingByTypeAndPosition(OBJECTTYPE.BUILDING, _loc_2.GetBuildingName_string(), _loc_2.GetXInt(), _loc_2.GetYInt() - global.streetGridYHalf, _loc_1);
                }
                if (_loc_1.mLandscape != null)
                {
                    _loc_3 = _loc_1.mLandscape;
                    this.mGeneralInterface.mCurrentPlayerZone.SetBlockingByTypeAndPosition(OBJECTTYPE.LANDSCAPE, _loc_3.GetLandscapeName_string(), _loc_3.GetXInt(), _loc_3.GetYInt() - global.streetGridYHalf, null);
                }
                if (_loc_1.mDeposit != null && _loc_1.mDeposit.mDepositGfx != null)
                {
                    for each (_loc_4 in _loc_1.mDeposit.mDepositGfx.mBlocking_vector)
                    {
                        
                        _loc_5 = _loc_1.mDeposit.GetXInt() + _loc_4.getXPixelOffset() * global.streetGridX / 100;
                        _loc_6 = _loc_1.mDeposit.GetYInt() - global.streetGridYHalf + _loc_4.getYPixelOffset() * global.streetGridY / 100;
                        this.SetBlockingPixelPos(_loc_5, _loc_6, _loc_4.getBlockingType(), null);
                    }
                }
            }
            return;
        }// end function

        public function AddLandscapeToList(param1:cLandscape) : void
        {
            this.mBuildingsAndTrees_vector.push(param1);
            return;
        }// end function

        public function RefreshLogisticsHouse() : void
        {
            var _loc_1:cBuilding = null;
            this.SetLogisticsHouse(null);
            for each (_loc_1 in this.GetBuildings_vector())
            {
                
                if (_loc_1.GetBuildingName_string() == defines.LOGISTICS_NAME_string)
                {
                    this.SetLogisticsHouse(_loc_1);
                    break;
                }
            }
            return;
        }// end function

        public function IsFogAtGridPosition(param1:int) : Boolean
        {
            if (param1 == defines.ILLEGAL_INT_POS)
            {
                return false;
            }
            return this.mIsoMap_list[param1].mFogBorder != 0;
        }// end function

        private function RenderStreetCursorColor(param1:int, param2:int, param3:int) : void
        {
            if (param1 == 0)
            {
                this.mGeneralInterface.mStreetCursorWhite.SetPosition(param2, param3);
                this.mGeneralInterface.mStreetCursorWhite.Render();
            }
            else if (param1 == 1)
            {
                this.mGeneralInterface.mStreetCursorYellow.SetPosition(param2, param3);
                this.mGeneralInterface.mStreetCursorYellow.Render();
            }
            else if (param1 == 2)
            {
                this.mGeneralInterface.mStreetCursorGreen.SetPosition(param2, param3);
                this.mGeneralInterface.mStreetCursorGreen.Render();
            }
            else if (param1 == 3)
            {
                this.mGeneralInterface.mStreetCursorRed.SetPosition(param2, param3);
                this.mGeneralInterface.mStreetCursorRed.Render();
            }
            else if (param1 == 4)
            {
                this.mGeneralInterface.mStreetCursorBlue.SetPosition(param2, param3);
                this.mGeneralInterface.mStreetCursorBlue.Render();
            }
            else if (param1 == 5)
            {
                this.mGeneralInterface.mStreetCursorMagenta.SetPosition(param2, param3);
                this.mGeneralInterface.mStreetCursorMagenta.Render();
            }
            else if (param1 == 6)
            {
                this.mGeneralInterface.mStreetCursorGrid.SetPosition(param2, param3);
                this.mGeneralInterface.mStreetCursorGrid.Render();
            }
            else
            {
                this.mGeneralInterface.mStreetPathCursor.SetPosition(param2, param3);
                this.mGeneralInterface.mStreetPathCursor.Render();
            }
            return;
        }// end function

        public function RemoveBuildingGridPos(param1:int) : Boolean
        {
            var _loc_3:BuffAppliance = null;
            var _loc_4:cPlayerData = null;
            var _loc_5:cBuff = null;
            var _loc_2:* = this.mIsoMap_list[param1].mBuilding as cBuilding;
            if (_loc_2 != null)
            {
                _loc_4 = this.mGeneralInterface.FindPlayerFromId(_loc_2.GetPlayerID());
                if (_loc_4 != null)
                {
                    _loc_4.DecBuildingCount(_loc_2);
                    _loc_4.DecBuildingAll(_loc_2);
                    if (_loc_2.GetRecurringBuff() != null)
                    {
                        _loc_5 = cBuff.CreateBuffFromVO(_loc_2.GetRecurringBuff());
                        _loc_4.mAvailableBuffs_vector.push(_loc_5);
                    }
                }
                else if (_loc_2.GetPlayerID() == -1)
                {
                    this.mGeneralInterface.mHomePlayer.DecAnyBuildingCount(_loc_2);
                }
            }
            this.mIsoMap_list[param1].mBuilding = null;
            this.RemoveBuildingFromList(_loc_2);
            for each (_loc_3 in _loc_2.mBuffs_vector)
            {
                
                _loc_3.BuffRemoved(this.mGeneralInterface);
            }
            return true;
        }// end function

        public function RenderCompute() : void
        {
            if (this.mGeneralInterface != null)
            {
                gGfxResource.mWaitForCommandIcon.mSprite.Animate(this.mGeneralInterface.mCalculateTicks.mDeltaTicksOne);
            }
            this.RenderComputeFreeBackground();
            return;
        }// end function

        public function GetLogisticsHouse() : cBuilding
        {
            return this.mLogisticsHouse;
        }// end function

        public function ResetListsAndScrolling() : void
        {
            this.ResetBuildingAndLandscapeList();
            this.ResetStreetList();
            this.mCachedScrollPosX = -1;
            this.mCachedScrollPosY = -1;
            this.mCachedZoomScale = -1;
            return;
        }// end function

        public function SetBlockingPixelPos(param1:int, param2:int, param3:int, param4:cIsoElement) : void
        {
            var _loc_5:* = gCalculations.ConvertPixelPosToStreetGridPos(param1, param2);
            if (gCalculations.ConvertPixelPosToStreetGridPos(param1, param2) == defines.ILLEGAL_INT_POS)
            {
                return;
            }
            if (this.mIsoMap_list[_loc_5].IsBlockedAllowedAll() || param3 < this.mIsoMap_list[_loc_5].GetBlocked())
            {
                this.mIsoMap_list[_loc_5].SetBlocked(param3);
            }
            if (param4 != null)
            {
                if (param3 != cBlockingData.BLOCK_TYPE_ALLOW_ALL)
                {
                    this.mIsoMap_list[_loc_5].mBlockedIsoElementSource = param4;
                }
            }
            return;
        }// end function

        public function SetAdditionalParameter(param1:cGOGroup, param2:String) : void
        {
            this.mGoGroup = param1;
            this.mElementName_string = param2;
            return;
        }// end function

        public function IsFogAtPixelPosition(param1:int, param2:int) : Boolean
        {
            var _loc_3:* = gCalculations.ConvertPixelPosToStreetGridPos(param1, param2);
            return this.mIsoMap_list[_loc_3].mFogBorder != 0;
        }// end function

        public function CalculateSetStreetData(param1:cPlayerData, param2:String, param3:int, param4:Boolean) : cStreet
        {
            var _loc_7:int = 0;
            var _loc_8:int = 0;
            var _loc_5:* = this.GetStreetFromGridPosition(param3);
            if (this.GetStreetFromGridPosition(param3) != null)
            {
                _loc_7 = cStreet.ConvertStreetNameToBitField(param2);
                _loc_8 = _loc_5.GetStreetBits() | _loc_7;
                param2 = cStreet.CreateStringFromStreetBitField_string(_loc_8);
            }
            var _loc_6:* = cStreet.CreateFromString(param1, global.streetGroup, "Street_" + param2, this.mGeneralInterface);
            if (_loc_5 != null)
            {
                _loc_6.mDirtyIndicator = _loc_6.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            }
            else
            {
                _loc_6.mDirtyIndicator = _loc_6.mDirtyIndicator | DIRTY_INDICATOR.CREATED_BIT;
            }
            this.CalculateStreetVariation(param1.GetCityLevel(), _loc_5, _loc_6, param4);
            return _loc_6;
        }// end function

        public function SetDepositGridPos(param1:cPlayerData, param2:cGO, param3:int) : Boolean
        {
            var _loc_4:* = param2 as cDeposit;
            gCalculations.ConvertStreetGridToPixelPos(param3, this.mTempPos);
            if (param3 == defines.ILLEGAL_INT_POS)
            {
                return false;
            }
            if (this.mIsoMap_list[param3].mDeposit != null)
            {
                this.RemoveDepositGridPos(param3);
            }
            _loc_4.SetPosition(this.mTempPos.x, this.mTempPos.y + global.streetGridYHalf);
            _loc_4.SetGridIdx(param3);
            this.mDeposits_vector.push(_loc_4);
            this.mGeneralInterface.mPathFinder.InvalidateDepositMatrix(param1.GetPlayerId(), _loc_4.GetName_string(), cPathFinder.AMOUNT_TYPE_ABOVE_ZERO);
            this.mIsoMap_list[param3].SetDeposit(_loc_4);
            return true;
        }// end function

        public function DeconstructBuildingGridPos(param1:int) : Boolean
        {
            var _loc_2:cBuilding = null;
            var _loc_3:dResourceCreationDefinition = null;
            if (param1 == defines.ILLEGAL_INT_POS)
            {
                return false;
            }
            if (this.mIsoMap_list[param1].mBuilding != null)
            {
                _loc_2 = this.mIsoMap_list[param1].mBuilding as cBuilding;
                _loc_2.mBuildingDestructionTime = this.mGeneralInterface.GetClientTime();
                _loc_2.SetBuildingMode(cBuilding.BUILDING_MODE_DESTRUCTION);
                _loc_2.Refund();
                if (this.mGeneralInterface.mEnumUIType == UITYPE.GAME)
                {
                    this.RemoveBuildingFromGameLogic(_loc_2);
                }
                this.mGeneralInterface.mGoSetListAnimationManager.Remove(param1);
                if (_loc_2.GetResourceCreation() != null)
                {
                    if (_loc_2.GetGOContainer().mDepositAnimName_string != null)
                    {
                        _loc_3 = _loc_2.GetResourceCreation().GetResourceCreationDefinition();
                        if (_loc_3 != null)
                        {
                            if (_loc_3.typeEnumResourceType == RESOURCE_TYPE.CREATED_BY_BUILDING)
                            {
                                if (_loc_2.GetResourceCreation().GetDepositBuildingGridPos() != -1)
                                {
                                    this.mGeneralInterface.mGoSetListAnimationManager.Remove(_loc_2.GetResourceCreation().GetDepositBuildingGridPos());
                                }
                            }
                        }
                    }
                }
            }
            this.UpdateObjectPositions();
            return true;
        }// end function

        public function RemoveDepositGridPos(param1:int) : Boolean
        {
            var _loc_2:int = 0;
            if (param1 == defines.ILLEGAL_INT_POS)
            {
                return false;
            }
            if (this.mIsoMap_list[param1].mDeposit != null)
            {
                this.mIsoMap_list[param1].mDeposit.mDirtyIndicator = this.mIsoMap_list[param1].mDeposit.mDirtyIndicator | DIRTY_INDICATOR.DATA_DELETED_BIT;
                _loc_2 = this.mDeposits_vector.indexOf(this.mIsoMap_list[param1].mDeposit);
                if (_loc_2 != -1)
                {
                    this.mDeposits_vector.splice(_loc_2, 1);
                }
                this.mIsoMap_list[param1].mDeposit = null;
            }
            return true;
        }// end function

        public function CalculateSectors(param1:cPlayerData) : void
        {
            var _loc_2:cIsoElement = null;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            if (this.mGeneralInterface.mCurrentPlayerZone.mSectorList_vector.length == 0)
            {
                return;
            }
            _loc_4 = defines.STREET_MAP_MIN_USABLE_AREA_Y;
            while (_loc_4 <= defines.STREET_MAP_MAX_USABLE_AREA_Y)
            {
                
                _loc_5 = (_loc_4 << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + defines.STREET_MAP_MIN_USABLE_AREA_X;
                _loc_3 = defines.STREET_MAP_MIN_USABLE_AREA_X;
                while (_loc_3 <= defines.STREET_MAP_MAX_USABLE_AREA_X)
                {
                    
                    _loc_2 = this.mIsoMap_list[_loc_5++];
                    if (_loc_2.mBuilding != null && _loc_2.mBuilding.IsWarehouseType())
                    {
                        this.mGeneralInterface.mCurrentPlayerZone.mSectorList_vector[_loc_2.mSectorId].SetOwnerPlayerID(_loc_2.mBuilding.GetPlayerID());
                    }
                    _loc_3++;
                }
                _loc_4++;
            }
            this.CalculateFogBorders(param1);
            return;
        }// end function

        public function SetLogisticsHouse(param1:cBuilding) : void
        {
            if (param1 == null || this.mGeneralInterface.mCurrentPlayer.mIsPlayerZone)
            {
                this.mLogisticsHouse = param1;
            }
            return;
        }// end function

        public function CalculateBorders() : void
        {
            var _loc_1:int = 0;
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            var _loc_8:cVectorListInt = null;
            var _loc_9:int = 0;
            var _loc_10:cIsoElement = null;
            var _loc_11:int = 0;
            var _loc_12:cSector = null;
            var _loc_13:int = 0;
            var _loc_14:int = 0;
            var _loc_15:int = 0;
            _loc_1 = defines.STREET_MAP_MIN_USABLE_AREA_X;
            _loc_2 = defines.STREET_MAP_MIN_USABLE_AREA_Y;
            _loc_3 = defines.STREET_MAP_MAX_USABLE_AREA_X;
            _loc_4 = defines.STREET_MAP_MAX_USABLE_AREA_Y;
            var _loc_5:int = 0;
            _loc_7 = _loc_2;
            while (_loc_7 <= _loc_4)
            {
                
                _loc_5 = (_loc_7 << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + _loc_1;
                _loc_8 = gCalculations.m8DirectionTableStreetGridDirection_vector[_loc_7 & 1];
                _loc_6 = _loc_1;
                while (_loc_6 <= _loc_3)
                {
                    
                    _loc_9 = 0;
                    _loc_10 = this.mIsoMap_list[_loc_5];
                    _loc_11 = _loc_10.mSectorId;
                    if (_loc_11 < this.mGeneralInterface.mCurrentPlayerZone.mSectorList_vector.length)
                    {
                        _loc_12 = this.mGeneralInterface.mCurrentPlayerZone.mSectorList_vector[_loc_11];
                        _loc_13 = _loc_5 + _loc_8.mList_vector[defines.DIR8_NORTH_EAST];
                        if (this.mIsoMap_list[_loc_13].mSectorId != _loc_11)
                        {
                            if (_loc_12.mAdjactedSectorIds_vector.indexOf(this.mIsoMap_list[_loc_13].mSectorId) == -1)
                            {
                                _loc_12.mAdjactedSectorIds_vector.push(this.mIsoMap_list[_loc_13].mSectorId);
                            }
                            _loc_9 = _loc_9 | defines.DIR8_NORTH_EAST_BIT;
                        }
                        _loc_13 = _loc_5 + _loc_8.mList_vector[defines.DIR8_NORTH_WEST];
                        if (this.mIsoMap_list[_loc_13].mSectorId != _loc_11)
                        {
                            if (_loc_12.mAdjactedSectorIds_vector.indexOf(this.mIsoMap_list[_loc_13].mSectorId) == -1)
                            {
                                _loc_12.mAdjactedSectorIds_vector.push(this.mIsoMap_list[_loc_13].mSectorId);
                            }
                            _loc_9 = _loc_9 | defines.DIR8_NORTH_WEST_BIT;
                        }
                        _loc_13 = _loc_5 + _loc_8.mList_vector[defines.DIR8_SOUTH_EAST];
                        if (this.mIsoMap_list[_loc_13].mSectorId != _loc_11)
                        {
                            if (_loc_12.mAdjactedSectorIds_vector.indexOf(this.mIsoMap_list[_loc_13].mSectorId) == -1)
                            {
                                _loc_12.mAdjactedSectorIds_vector.push(this.mIsoMap_list[_loc_13].mSectorId);
                            }
                            _loc_9 = _loc_9 | defines.DIR8_SOUTH_EAST_BIT;
                        }
                        _loc_13 = _loc_5 + _loc_8.mList_vector[defines.DIR8_SOUTH_WEST];
                        if (this.mIsoMap_list[_loc_13].mSectorId != _loc_11)
                        {
                            if (_loc_12.mAdjactedSectorIds_vector.indexOf(this.mIsoMap_list[_loc_13].mSectorId) == -1)
                            {
                                _loc_12.mAdjactedSectorIds_vector.push(this.mIsoMap_list[_loc_13].mSectorId);
                            }
                            _loc_9 = _loc_9 | defines.DIR8_SOUTH_WEST_BIT;
                        }
                        _loc_10.mBorder = _loc_9;
                        _loc_10.mBorderColor = 13;
                        if (_loc_11 >= 0)
                        {
                            _loc_14 = this.mGeneralInterface.mCurrentPlayerZone.mSectorList_vector[_loc_11].GetOwnerPlayerID();
                            if (_loc_14 != -1)
                            {
                                _loc_15 = this.mGeneralInterface.mCurrentPlayerZone.GetPlayerColorIdx(_loc_14);
                                _loc_10.mBorderColor = _loc_15;
                            }
                        }
                    }
                    _loc_5++;
                    _loc_6++;
                }
                _loc_7++;
            }
            return;
        }// end function

        public function GetBuildings_vector()
        {
            return this.mBuildings_vector;
        }// end function

        public function RenderLandingFields() : void
        {
            var _loc_2:cLandingField = null;
            var _loc_1:* = new cPosInt();
            for each (_loc_2 in this.mLandingFields_vector)
            {
                
                gCalculations.ConvertStreetGridToPixelPos(_loc_2.mGrid, _loc_1);
                this.RenderStreetCursorColor(_loc_2.mId, _loc_1.x, _loc_1.y);
                this.mGeneralInterface.mCurrentPlayerZone.RenderTextCenter(cBackbuffer.mBackBuffer, gMisc.ConvertIntToString_string(_loc_2.mId), _loc_1.x, _loc_1.y - global.streetGridYHalf);
            }
            return;
        }// end function

        public function IsADepletedDeposit(param1:cBuilding) : Boolean
        {
            var _loc_3:String = null;
            var _loc_2:* = param1.GetBuildingName_string().length;
            if (_loc_2 >= defines.MINEDEPOSITDEPLETED_NAME_string.length)
            {
                _loc_3 = gMisc.GetSubString_string(param1.GetBuildingName_string(), 0, defines.MINEDEPOSITDEPLETED_NAME_string.length);
                if (_loc_3 == defines.MINEDEPOSITDEPLETED_NAME_string)
                {
                    return true;
                }
            }
            return false;
        }// end function

        public function RecalculateStreetVariations(param1:int) : Boolean
        {
            var _loc_3:cIsoElement = null;
            var _loc_2:Boolean = false;
            for each (_loc_3 in this.mIsoMap_list)
            {
                
                if (_loc_3.mStreet != null)
                {
                    if (this.CalculateStreetVariation(param1, null, _loc_3.mStreet, false))
                    {
                        _loc_2 = true;
                    }
                }
            }
            return _loc_2;
        }// end function

        public function GetStreetNameFromGridPos_string(param1:int) : String
        {
            var _loc_2:* = this.mIsoMap_list[param1].mStreet;
            if (_loc_2 != null)
            {
                return _loc_2.GetContainerName_string();
            }
            return null;
        }// end function

        public function SetDeposits_vector(param1) : void
        {
            this.mDeposits_vector = param1;
            return;
        }// end function

        public function InitRenderCursorInfo() : void
        {
            var _loc_1:int = 0;
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            if (this.mGeneralInterface.mEnumUIType == UITYPE.EDITOR)
            {
                return;
            }
            if (this.mGeneralInterface.mCurrentCursor == null)
            {
                return;
            }
            _loc_1 = defines.STREET_MAP_MIN_USABLE_AREA_X;
            _loc_2 = defines.STREET_MAP_MIN_USABLE_AREA_Y;
            _loc_3 = defines.STREET_MAP_MAX_USABLE_AREA_X;
            _loc_4 = defines.STREET_MAP_MAX_USABLE_AREA_Y;
            var _loc_5:int = 0;
            _loc_7 = _loc_2;
            while (_loc_7 <= _loc_4)
            {
                
                _loc_5 = (_loc_7 << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + _loc_1;
                _loc_6 = _loc_1;
                while (_loc_6 <= _loc_3)
                {
                    
                    this.mIsoMap_list[_loc_5].mCursorVisible = -1;
                    _loc_5++;
                    _loc_6++;
                }
                _loc_7++;
            }
            return;
        }// end function

        public function CheckStreetConnectionAroundPoint(param1:int) : int
        {
            var _loc_4:int = 0;
            var _loc_5:cStreet = null;
            var _loc_2:int = 15;
            var _loc_3:int = 0;
            while (_loc_3 < defines.STREET_DIR_NOF)
            {
                
                _loc_4 = gCalculations.MoveStreetGridToDir8(param1, _loc_3);
                _loc_5 = this.mGeneralInterface.mCurrentPlayerZone.GetStreetObjectFromGridPosition(_loc_4);
                if (_loc_5 != null)
                {
                    _loc_2 = _loc_2 & ~(1 << _loc_3);
                }
                _loc_3++;
            }
            return _loc_2;
        }// end function

        public function RenderComputeFreeBackground() : void
        {
            var _loc_1:cFreeLandscape = null;
            var _loc_3:int = 0;
            var _loc_2:* = this.mFreeLandscape_vector.length;
            if (_loc_2 > 0)
            {
                _loc_3 = 0;
                while (_loc_3 < 30)
                {
                    
                    var _loc_4:String = this;
                    var _loc_5:* = this.mCheckFreeLandscapeCntr + 1;
                    _loc_4.mCheckFreeLandscapeCntr = _loc_5;
                    if (this.mCheckFreeLandscapeCntr >= _loc_2)
                    {
                        this.mCheckFreeLandscapeCntr = 0;
                    }
                    _loc_1 = this.mFreeLandscape_vector[this.mCheckFreeLandscapeCntr];
                    if (_loc_1.GetGOContainer().mStreamingFinished)
                    {
                        if (!_loc_1.mAnimationInitialized)
                        {
                            _loc_1.SetAnimation();
                        }
                    }
                    _loc_3++;
                }
                for each (_loc_1 in this.mFreeLandscape_vector)
                {
                    
                    if (_loc_1.mIsAnimated)
                    {
                        _loc_1.Animate();
                    }
                }
            }
            return;
        }// end function

        public function AddBuildingToGameLogic(param1:cBuilding) : void
        {
            if (!this.mGeneralInterface.mRefreshZoneIsActive)
            {
                if (!param1.IsBuildingActive())
                {
                    this.mGeneralInterface.mComputeResourceCreation.CreateResourceCreationForBuilding(param1);
                }
                this.mGeneralInterface.mComputeResourceCreation.CalculateProductionPaths(param1, false);
            }
            return;
        }// end function

        public function RefreshExploredDeposits() : void
        {
            var _loc_1:int = 0;
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            var _loc_4:cSector = null;
            var _loc_5:cIsoElement = null;
            var _loc_6:String = null;
            var _loc_7:String = null;
            _loc_2 = defines.STREET_MAP_MIN_USABLE_AREA_Y;
            while (_loc_2 <= defines.STREET_MAP_MAX_USABLE_AREA_Y)
            {
                
                _loc_3 = (_loc_2 << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + defines.STREET_MAP_MIN_USABLE_AREA_X;
                _loc_1 = defines.STREET_MAP_MIN_USABLE_AREA_X;
                while (_loc_1 < defines.STREET_MAP_MAX_USABLE_AREA_X + 2)
                {
                    
                    _loc_5 = this.mIsoMap_list[_loc_3++];
                    if (_loc_5.mDeposit != null)
                    {
                        if (_loc_5.mLandscape != null)
                        {
                            if (_loc_5.mBuilding != null)
                            {
                                if (!this.IsADepletedDeposit(_loc_5.mBuilding))
                                {
                                    ;
                                }
                            }
                            _loc_6 = _loc_5.mLandscape.GetContainerName_string();
                            if (this.mGeneralInterface.mCurrentPlayerZone.IsDepositFoundType(_loc_6))
                            {
                                if (_loc_5.mDeposit.GetAmount() > 0)
                                {
                                    _loc_7 = gMisc.GetSubString_string(_loc_6, defines.DEPOSITFOUND_NAME_string.length, _loc_6.length - defines.DEPOSITFOUND_NAME_string.length);
                                    this.mGeneralInterface.mCurrentPlayerZone.AddDepositIcon(_loc_7, (_loc_3 - 1));
                                }
                            }
                        }
                    }
                    _loc_1++;
                }
                _loc_2++;
            }
            return;
        }// end function

        public function UpdateObjectPositions() : void
        {
            var _loc_1:int = 0;
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_8:int = 0;
            var _loc_9:int = 0;
            _loc_1 = defines.STREET_MAP_MIN_USABLE_AREA_X;
            _loc_2 = defines.STREET_MAP_MIN_USABLE_AREA_Y;
            _loc_3 = defines.STREET_MAP_MAX_USABLE_AREA_X;
            _loc_4 = defines.STREET_MAP_MAX_USABLE_AREA_Y;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            var _loc_10:* = global.streetGridX * _loc_1;
            _loc_6 = _loc_6 + global.streetGridYHalf * _loc_2;
            _loc_6 = _loc_6 + global.streetGridYHalf;
            _loc_9 = _loc_2;
            while (_loc_9 <= _loc_4)
            {
                
                if ((_loc_9 & 1) == 0)
                {
                    _loc_5 = -global.streetGridXHalf + _loc_10;
                }
                else
                {
                    _loc_5 = _loc_10;
                }
                _loc_7 = (_loc_9 << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + _loc_1;
                _loc_8 = _loc_1;
                while (_loc_8 <= _loc_3)
                {
                    
                    if (this.mIsoMap_list[_loc_7].mBuilding != null)
                    {
                        this.mIsoMap_list[_loc_7].mBuilding.SetPosition(_loc_5, _loc_6);
                    }
                    if (this.mIsoMap_list[_loc_7].mLandscape != null)
                    {
                        this.mIsoMap_list[_loc_7].mLandscape.SetPosition(_loc_5, _loc_6);
                    }
                    if (this.mIsoMap_list[_loc_7].mDeposit != null)
                    {
                        this.mIsoMap_list[_loc_7].mDeposit.SetPosition(_loc_5, _loc_6);
                    }
                    _loc_5 = _loc_5 + global.streetGridX;
                    _loc_7++;
                    _loc_8++;
                }
                _loc_6 = _loc_6 + global.streetGridYHalf;
                _loc_9++;
            }
            return;
        }// end function

        public function GetGuildHouse() : cBuilding
        {
            return this.mGuildHouse;
        }// end function

        public function RemoveLandscapeGridPos(param1:int) : Boolean
        {
            if (param1 == defines.ILLEGAL_INT_POS)
            {
                return false;
            }
            var _loc_2:* = this.mIsoMap_list[param1].mLandscape;
            this.mIsoMap_list[param1].mLandscape = null;
            this.RemoveLandscapeFromList(_loc_2);
            this.CalculateBlockingGrid();
            return true;
        }// end function

        public function SetBuildingsAndTrees_vector(param1) : void
        {
            this.mBuildingsAndTrees_vector = param1;
            return;
        }// end function

        public function InitConvertMapToXMLString_string() : void
        {
            var _loc_1:int = 0;
            while (_loc_1 < defines.STREET_MAP_SIZE_FINAL)
            {
                
                this.mIsoMap_list[_loc_1].mBuilding = null;
                this.mIsoMap_list[_loc_1].mLandscape = null;
                _loc_1++;
            }
            this.mBuildings_vector = new Vector.<cBuilding>;
            this.mBuildingsAndTrees_vector = new Vector.<cGO>;
            return;
        }// end function

        public function SetSingleStreet(param1:cPlayerData, param2:String, param3:int) : void
        {
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_4:String = "";
            var _loc_7:int = 0;
            var _loc_8:int = 0;
            var _loc_9:int = 0;
            _loc_5 = gCalculations.MoveStreetGridToDir8(param3, defines.DIR8_NORTH_EAST);
            _loc_4 = this.GetStreetNameFromGridPos_string(_loc_5);
            if (_loc_4 != null)
            {
                if (cStreet.ConvertStreetNameToBitField(_loc_4) != 0)
                {
                    this.SetStreet(param1, "2", _loc_5, false);
                    _loc_9 = _loc_9 | 1 << 0;
                }
            }
            _loc_5 = gCalculations.MoveStreetGridToDir8(param3, defines.DIR8_SOUTH_EAST);
            _loc_4 = this.GetStreetNameFromGridPos_string(_loc_5);
            if (_loc_4 != null)
            {
                if (cStreet.ConvertStreetNameToBitField(_loc_4) != 0)
                {
                    this.SetStreet(param1, "3", _loc_5, false);
                    _loc_9 = _loc_9 | 1 << 1;
                }
            }
            _loc_5 = gCalculations.MoveStreetGridToDir8(param3, defines.DIR8_NORTH_WEST);
            _loc_4 = this.GetStreetNameFromGridPos_string(_loc_5);
            if (_loc_4 != null)
            {
                if (cStreet.ConvertStreetNameToBitField(_loc_4) != 0)
                {
                    this.SetStreet(param1, "0", _loc_5, false);
                    _loc_9 = _loc_9 | 1 << 2;
                }
            }
            _loc_5 = gCalculations.MoveStreetGridToDir8(param3, defines.DIR8_SOUTH_WEST);
            _loc_4 = this.GetStreetNameFromGridPos_string(_loc_5);
            if (_loc_4 != null)
            {
                if (cStreet.ConvertStreetNameToBitField(_loc_4) != 0)
                {
                    this.SetStreet(param1, "1", _loc_5, false);
                    _loc_9 = _loc_9 | 1 << 3;
                }
            }
            if (param2 != null)
            {
                _loc_9 = _loc_9 | cStreet.ConvertStreetNameToBitField(param2);
            }
            if (_loc_9 != 0)
            {
                this.SetStreet(param1, cStreet.CreateStringFromStreetBitField_string(_loc_9), param3, false);
            }
            return;
        }// end function

        public function SetGuildHouse(param1:cBuilding) : void
        {
            var _loc_2:dGuildVO = null;
            var _loc_3:int = 0;
            var _loc_4:* = undefined;
            if (param1 == null || this.mGeneralInterface.mCurrentPlayer.mIsPlayerZone)
            {
                this.mGuildHouse = param1;
                _loc_2 = this.mGeneralInterface.GetCurrentPlayerGuild();
                if (this.mGuildHouse && _loc_2)
                {
                    _loc_3 = 0;
                    for (_loc_4 in global.guildUpgradeLevels)
                    {
                        
                        if (_loc_2.maxSize >= global.guildUpgradeLevels[_loc_4])
                        {
                            _loc_3 = _loc_4;
                            continue;
                        }
                        break;
                    }
                    this.mGuildHouse.SetUpgradeLevel(_loc_3);
                }
            }
            return;
        }// end function

        public function GetBlockType(param1:int) : int
        {
            if (param1 == defines.ILLEGAL_INT_POS)
            {
                return cBlockingData.BLOCK_TYPE_ALLOW_NOTHING;
            }
            return this.mIsoMap_list[param1].GetBlocked();
        }// end function

        public function RemovePrePlaceBuildingGridPos(param1:cPlayerData, param2:int) : Boolean
        {
            var _loc_3:* = this.mIsoMap_list[param2].mBuilding as cBuilding;
            this.mIsoMap_list[param2].mBuilding = null;
            param1.RemovePrePlacesBuildingToList(_loc_3);
            this.RemoveBuildingFromList(_loc_3);
            this.CalculateBlockingGrid();
            return true;
        }// end function

        public function GetBuildingsAndLandscape_vector()
        {
            return this.mBuildingsAndTrees_vector;
        }// end function

        public function ResetStreetList() : void
        {
            this.mStreets_vector.length = 0;
            return;
        }// end function

        public function GetMayorHouse() : cBuilding
        {
            return this.mMayorHouse;
        }// end function

        public function RenderBuildingsWithSettlers(param1:int) : void
        {
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_10:int = 0;
            var _loc_11:int = 0;
            var _loc_12:cSettler = null;
            var _loc_13:int = 0;
            var _loc_15:dSettlerList = null;
            var _loc_16:cIsoElement = null;
            this.CalculateMapClipping(param1, this.mTempClippingRectangle);
            _loc_2 = this.mTempClippingRectangle.minX;
            _loc_3 = this.mTempClippingRectangle.minY;
            _loc_4 = this.mTempClippingRectangle.maxX;
            _loc_5 = this.mTempClippingRectangle.maxY;
            var _loc_6:* = _loc_3 - 1;
            var _loc_7:* = _loc_5 + 1;
            var _loc_8:* = _loc_2 - 1;
            var _loc_9:* = _loc_4 + 1;
            _loc_11 = _loc_6;
            while (_loc_11 <= _loc_7)
            {
                
                this.mSettlerYSortMap_list[_loc_11] = null;
                _loc_11++;
            }
            for each (_loc_12 in this.mGeneralInterface.mCurrentPlayerZone.mSettlerKIManager.mSettlersList_vector)
            {
                
                _loc_11 = (_loc_12.GetYInt() + global.streetGridY) / global.streetGridYHalf;
                if (_loc_11 >= _loc_6 && _loc_11 <= _loc_7)
                {
                    _loc_10 = _loc_12.GetXInt() / global.streetGridX;
                    if (_loc_10 >= _loc_8 && _loc_10 <= _loc_9)
                    {
                        if (this.mSettlerYSortMap_list[_loc_11] == null)
                        {
                            this.mSettlerYSortMap_list[_loc_11] = new dSettlerList();
                        }
                        _loc_15 = this.mSettlerYSortMap_list[_loc_11];
                        _loc_15.settlerList_vector.push(_loc_12);
                    }
                }
            }
            _loc_13 = -1;
            if (this.mGeneralInterface.mCurrentCursor.GetEditMode() == COMMAND.SELECT_BUILDING)
            {
                if (this.mGeneralInterface.mCurrentCursor.IsCursorValid())
                {
                    _loc_13 = this.mGeneralInterface.mCurrentCursor.GetGridPosition();
                    this.SelectBuilding(_loc_13, true);
                }
            }
            if (this.mGeneralInterface.GetSelectedBuilding() != null)
            {
                this.SelectBuilding(this.mGeneralInterface.GetSelectedBuilding().GetBuildingGrid(), true);
            }
            var _loc_14:int = 0;
            _loc_11 = _loc_6;
            while (_loc_11 <= _loc_7)
            {
                
                _loc_14 = (_loc_11 << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + _loc_2;
                if (this.mSettlerYSortMap_list[_loc_11] != null)
                {
                    for each (_loc_12 in this.mSettlerYSortMap_list[_loc_11].settlerList_vector)
                    {
                        
                        _loc_12.Render();
                    }
                }
                if (_loc_11 >= _loc_3 && _loc_11 <= _loc_5)
                {
                    _loc_10 = _loc_2;
                    while (_loc_10 <= _loc_4)
                    {
                        
                        _loc_16 = this.mIsoMap_list[_loc_14];
                        if (_loc_16.mFogBorder < 3)
                        {
                            if (_loc_16.mLandscape != null)
                            {
                                _loc_16.mLandscape.Render();
                            }
                            if (_loc_16.mBuilding != null)
                            {
                                _loc_16.mBuilding.Render();
                            }
                            if (_loc_16.mDeposit != null && _loc_16.mDeposit.mDepositGfx != null)
                            {
                                _loc_16.mDeposit.mDepositGfx.Render(_loc_16.mDeposit.GetXInt(), _loc_16.mDeposit.GetYInt());
                            }
                            if (_loc_16.mLandmark != null)
                            {
                                _loc_16.mLandmark.Render();
                            }
                            if (_loc_16.mGoSetListAnimation != null)
                            {
                                _loc_16.mGoSetListAnimation.animGoSetListContainer.Animate(this.mGeneralInterface.mCalculateTicks.mDeltaTicksOne);
                                _loc_16.mGoSetListAnimation.animGoSetListContainer.Render(_loc_16.mGoSetListAnimation.pixelPos.x, _loc_16.mGoSetListAnimation.pixelPos.y);
                            }
                            if (_loc_16.mIconGoSetListAnimation != null)
                            {
                                _loc_16.mIconGoSetListAnimation.animGoSetListContainer.Render(_loc_16.mIconGoSetListAnimation.pixelPos.x, _loc_16.mIconGoSetListAnimation.pixelPos.y);
                            }
                        }
                        _loc_14++;
                        _loc_10++;
                    }
                }
                _loc_11++;
            }
            if (_loc_13 != -1)
            {
                this.SelectBuilding(this.mGeneralInterface.mCurrentCursor.GetGridPosition(), false);
            }
            if (this.mGeneralInterface.GetSelectedBuilding() != null)
            {
                this.SelectBuilding(this.mGeneralInterface.GetSelectedBuilding().GetBuildingGrid(), false);
            }
            return;
        }// end function

        public function RemoveLandscapeAtFreePosition(param1:int, param2:int, param3:int) : cFreeLandscape
        {
            var _loc_6:cFreeLandscape = null;
            var _loc_7:int = 0;
            var _loc_8:int = 0;
            var _loc_4:cFreeLandscape = null;
            var _loc_5:int = 0;
            while (_loc_5 < this.mFreeLandscape_vector.length)
            {
                
                _loc_6 = this.mFreeLandscape_vector[_loc_5];
                _loc_7 = Math.abs(_loc_6.GetXInt() - param1);
                if (_loc_7 < param3)
                {
                    _loc_8 = Math.abs(_loc_6.GetYInt() - param2);
                    if (_loc_8 < param3)
                    {
                        _loc_4 = _loc_6;
                        this.mFreeLandscape_vector.splice(_loc_5, 1);
                        _loc_5 = _loc_5 - 1;
                    }
                }
                _loc_5++;
            }
            return _loc_4;
        }// end function

        public function BuildingGridCallBack(param1:Function, param2:int, param3:Boolean) : void
        {
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            if (param1 == null)
            {
                return;
            }
            this.CalculateMapClipping(param2, this.mTempClippingRectangle);
            _loc_4 = this.mTempClippingRectangle.minX;
            _loc_5 = this.mTempClippingRectangle.minY;
            _loc_6 = this.mTempClippingRectangle.maxX;
            _loc_7 = this.mTempClippingRectangle.maxY;
            var _loc_8:int = 0;
            if (param3)
            {
                _loc_10 = _loc_5;
                while (_loc_10 <= _loc_7)
                {
                    
                    _loc_8 = (_loc_10 << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + _loc_4;
                    _loc_9 = _loc_4;
                    while (_loc_9 <= _loc_6)
                    {
                        
                        this.param1(this.mIsoMap_list[_loc_8].mBuilding, _loc_8, _loc_9, _loc_10);
                        _loc_8++;
                        _loc_9++;
                    }
                    _loc_10++;
                }
            }
            else
            {
                _loc_10 = _loc_5;
                while (_loc_10 <= _loc_7)
                {
                    
                    _loc_8 = (_loc_10 << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + _loc_4;
                    _loc_9 = _loc_4;
                    while (_loc_9 <= _loc_6)
                    {
                        
                        if (this.mIsoMap_list[_loc_8].mBuilding != null)
                        {
                            this.param1(this.mIsoMap_list[_loc_8].mBuilding, _loc_8, _loc_9, _loc_10);
                        }
                        _loc_8++;
                        _loc_9++;
                    }
                    _loc_10++;
                }
            }
            return;
        }// end function

        public function ClearDeposits() : void
        {
            this.mDeposits_vector.length = 0;
            return;
        }// end function

        public function BuildingRenderBuildingDebugInfo(param1:Graphics) : void
        {
            var _loc_2:cBuilding = null;
            var _loc_3:String = null;
            var _loc_4:String = null;
            if (this.mGeneralInterface.showBuildingDebugGrid && ACTIVATE_RENDER_DEBUG_INFO_OVER_BUILDING)
            {
                for each (_loc_2 in this.GetBuildings_vector())
                {
                    
                    _loc_3 = "P: " + _loc_2.GetPlayerID() + " G:" + _loc_2.GetBuildingGrid();
                    _loc_2.RenderTextAboveGo(param1, _loc_3, -global.streetGridY);
                    _loc_4 = "";
                    _loc_4 = _loc_2.GetCurrentHitPoints() + "/" + _loc_2.GetMaxHitPoints();
                    _loc_2.RenderTextAboveGo(param1, _loc_4, -(global.streetGridY + 30));
                }
            }
            return;
        }// end function

        public function SetStreet(param1:cPlayerData, param2:String, param3:int, param4:Boolean) : void
        {
            var _loc_5:* = this.CalculateSetStreetData(param1, param2, param3, param4);
            if (param4)
            {
                gCalculations.ConvertStreetGridToPixelPos(param3, this.mTempPos);
                _loc_5.SetSubType(_loc_5.GetStreetCityLevel());
                _loc_5.SetVariationNr(_loc_5.GetVariationNr());
                _loc_5.SetPosition(this.mTempPos.x, this.mTempPos.y);
                _loc_5.SetPlayerID(param1.GetPlayerId());
                this.mStreetCreationPreview_vector.push(_loc_5);
            }
            else
            {
                this.SetStreetGridPos(_loc_5, param3);
                this.mGeneralInterface.mCurrentPlayerZone.SetBackgroundHasChanged(true);
            }
            return;
        }// end function

        public function RemoveWatchpoint(param1:int, param2:int, param3:cBuilding) : void
        {
            var _loc_4:* = gCalculations.ConvertPixelPosToStreetGridPos(param1, param2);
            if (gCalculations.ConvertPixelPosToStreetGridPos(param1, param2) == defines.ILLEGAL_INT_POS)
            {
                return;
            }
            this.mIsoMap_list[_loc_4].RemoveWatchingBuilding(param3);
            return;
        }// end function

        public function PostProcessConvertMapToXMLString_string() : void
        {
            this.UpdateObjectPositions();
            this.CalculateSectors(this.mGeneralInterface.mCurrentPlayer);
            this.CalculateBlockingGrid();
            this.CalculateWatchAreas();
            this.CalculateBorders();
            globalFlash.gui.RefreshDepositGroupWindow();
            return;
        }// end function

        private function SelectBuilding(param1:int, param2:Boolean) : void
        {
            var _loc_3:* = this.mIsoMap_list[param1].mBuilding;
            if (_loc_3 == null)
            {
                _loc_3 = this.CheckIfBuildingIsSouthSouthEastAndSouthWest(param1);
            }
            if (_loc_3 != null)
            {
                _loc_3.mCursorHighlight = param2;
            }
            return;
        }// end function

        public function CreateMilitaryPreviewFromPathStreet(param1:cPlayerData, param2:cPathObject) : void
        {
            var _loc_3:cPlayerZoneScreen = null;
            var _loc_5:int = 0;
            var _loc_4:* = param2.dest_vector.length;
            this.ResetStreetPreview();
            if (_loc_4 < 2)
            {
                return;
            }
            var _loc_6:* = new dPathObjectItem();
            _loc_5 = 0;
            while (_loc_5 < (_loc_4 - 1))
            {
                
                _loc_6 = param2.dest_vector[_loc_5] as dPathObjectItem;
                _loc_3 = this.mGeneralInterface.mCurrentPlayerZone;
                if (_loc_6.x > _loc_3.mSectorStartX && _loc_6.x < _loc_3.mSectorEndX && _loc_6.y > _loc_3.mSectorStartY && _loc_6.y < _loc_3.mSectorEndY)
                {
                    _loc_3.mStreetDataMap.SetMilitaryPreviewPath(param1, _loc_6.streetGridIdx);
                }
                _loc_5++;
            }
            return;
        }// end function

        public function CalculateWatchAreas() : void
        {
            var _loc_1:cIsoElement = null;
            for each (_loc_1 in this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list)
            {
                
                _loc_1.RemoveAllWatchingTowers();
            }
            for each (_loc_1 in this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list)
            {
                
                if (_loc_1.mBuilding != null)
                {
                    this.mGeneralInterface.mCurrentPlayerZone.SetWatchArea(_loc_1.mBuilding.GetLevelEnumObjectType(), _loc_1.mBuilding.GetBuildingName_string(), _loc_1.mBuilding);
                }
            }
            return;
        }// end function

        public function GetLoadedFromMap() : Boolean
        {
            return this.mLoadedFromMap;
        }// end function

        public function RenderBlockingGrid() : void
        {
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            var _loc_8:int = 0;
            var _loc_1:* = new cClippingRectangle();
            this.CalculateMapClipping(GCB_MODE_CLIPPING.CLIP_TO_SCREEN_FOREGROUND, _loc_1);
            if (this.mGeneralInterface.showCostMatrix)
            {
                if (this.mGeneralInterface.mCreatePath.costMatrix_list == null)
                {
                    return;
                }
            }
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            var _loc_4:* = global.streetGridX * _loc_1.minX;
            _loc_3 = _loc_3 + global.streetGridYHalf * _loc_1.minY;
            var _loc_5:* = _loc_1.minY;
            while (_loc_5 <= _loc_1.maxY)
            {
                
                if ((_loc_5 & 1) == 0)
                {
                    _loc_2 = -global.streetGridXHalf + _loc_4;
                }
                else
                {
                    _loc_2 = _loc_4;
                }
                _loc_6 = (_loc_5 << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + _loc_1.minX;
                _loc_7 = _loc_1.minX;
                while (_loc_7 <= _loc_1.maxX)
                {
                    
                    if (this.mGeneralInterface.showCostMatrix)
                    {
                        _loc_8 = this.mGeneralInterface.mCreatePath.costMatrix_list[_loc_6];
                        if (_loc_8 == cCreatePath.WAYPOINT_UNSET)
                        {
                            this.mGeneralInterface.mStreetCursorWhite.SetPosition(_loc_2, _loc_3);
                            this.mGeneralInterface.mStreetCursorWhite.Render();
                        }
                        else if (_loc_8 == cCreatePath.WAYPOINT_BLOCKED)
                        {
                            this.mGeneralInterface.mStreetCursorRed.SetPosition(_loc_2, _loc_3);
                            this.mGeneralInterface.mStreetCursorRed.Render();
                        }
                        else if (_loc_8 == cCreatePath.WAYPOINT_START)
                        {
                            this.mGeneralInterface.mStreetCursorGreen.SetPosition(_loc_2, _loc_3);
                            this.mGeneralInterface.mStreetCursorGreen.Render();
                        }
                        else if (_loc_8 == cCreatePath.WAYPOINT_DEST)
                        {
                            this.mGeneralInterface.mStreetCursorBlue.SetPosition(_loc_2, _loc_3);
                            this.mGeneralInterface.mStreetCursorBlue.Render();
                        }
                        else
                        {
                            this.mGeneralInterface.mCurrentPlayerZone.RenderText(cBackbuffer.mBackBuffer, "" + _loc_8, _loc_2, _loc_3 - global.streetGridYHalf);
                        }
                    }
                    else if (this.mGeneralInterface.showBlockingGrid)
                    {
                        switch((this.mIsoMap_list[_loc_6] as cIsoElement).GetBlocked())
                        {
                            case cBlockingData.BLOCK_TYPE_ALLOW_NOTHING:
                            {
                                this.mGeneralInterface.mStreetCursorRed.SetPosition(_loc_2, _loc_3);
                                this.mGeneralInterface.mStreetCursorRed.Render();
                                break;
                            }
                            case cBlockingData.BLOCK_TYPE_ALLOW_STREETS:
                            {
                                this.mGeneralInterface.mStreetCursorYellow.SetPosition(_loc_2, _loc_3);
                                this.mGeneralInterface.mStreetCursorYellow.Render();
                                break;
                            }
                            default:
                            {
                                break;
                            }
                        }
                    }
                    else if (this.mGeneralInterface.showWatchAreas)
                    {
                        if (this.mIsoMap_list[_loc_6].IsWatchedByTowers())
                        {
                            this.mGeneralInterface.mStreetCursorYellow.SetPosition(_loc_2, _loc_3);
                            this.mGeneralInterface.mStreetCursorYellow.Render();
                        }
                    }
                    _loc_2 = _loc_2 + global.streetGridX;
                    _loc_6++;
                    _loc_7++;
                }
                _loc_3 = _loc_3 + global.streetGridYHalf;
                _loc_5++;
            }
            return;
        }// end function

        public function IsBlockedForStreetAtGridIdx(param1:int) : Boolean
        {
            if (this.GetBlockType(param1) == cBlockingData.BLOCK_TYPE_ALLOW_NOTHING)
            {
                return true;
            }
            return false;
        }// end function

        public function RenderDepositsGame(param1:String) : void
        {
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_9:cIsoElement = null;
            var _loc_10:cDeposit = null;
            var _loc_15:int = 0;
            var _loc_16:int = 0;
            var _loc_17:String = null;
            var _loc_18:String = null;
            var _loc_19:String = null;
            var _loc_20:int = 0;
            var _loc_21:int = 0;
            this.CalculateMapClipping(GCB_MODE_CLIPPING.CLIP_TO_SCREEN_FOREGROUND, this.mTempClippingRectangle);
            _loc_2 = this.mTempClippingRectangle.minX;
            _loc_3 = this.mTempClippingRectangle.minY;
            _loc_4 = this.mTempClippingRectangle.maxX;
            _loc_5 = this.mTempClippingRectangle.maxY;
            var _loc_6:int = -32;
            var _loc_7:* = -(global.streetGridY - 24);
            var _loc_8:int = 28;
            var _loc_11:Boolean = true;
            var _loc_12:* = this.mGeneralInterface.mZoom.GetScaleFactor();
            if (this.mGeneralInterface.mZoom.GetScaleFactor() < 600)
            {
                _loc_11 = false;
            }
            var _loc_13:int = 0;
            var _loc_14:* = _loc_3 - 1;
            while (_loc_14 <= (_loc_5 + 1))
            {
                
                _loc_13 = (_loc_14 << defines.STREET_MAP_WIDTH_FINAL_SHIFT) + _loc_2;
                _loc_15 = _loc_2;
                while (_loc_15 <= _loc_4)
                {
                    
                    _loc_9 = this.mIsoMap_list[_loc_13];
                    _loc_10 = _loc_9.mDeposit;
                    if (_loc_9.mDeposit != null)
                    {
                        _loc_16 = this.mGeneralInterface.mCurrentPlayerZone.mSectorList_vector[_loc_9.mSectorId].GetOwnerPlayerID();
                        if (_loc_16 != -1)
                        {
                            _loc_17 = _loc_10.GetContainerName_string();
                            _loc_18 = gMisc.GetSubString_string(_loc_17, 7, _loc_17.length - 7);
                            if (param1 == null || param1 == _loc_18)
                            {
                                _loc_19 = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, _loc_18);
                                _loc_20 = int(_loc_10.GetX());
                                _loc_21 = int(_loc_10.GetY());
                                if (_loc_10.GetAccessibleType() == DEPOSIT_ACCESSIBLE_TYPES.ACCESSIBLE)
                                {
                                    _loc_10.RenderPos(_loc_20, _loc_21);
                                    if (_loc_11)
                                    {
                                        this.mGeneralInterface.mCurrentPlayerZone.RenderTextCenter(cBackbuffer.mBackBuffer, gMisc.ConvertDoubleToString_string(_loc_10.GetAmount()) + " " + _loc_19, _loc_20, _loc_21 + _loc_7);
                                    }
                                }
                                else
                                {
                                    _loc_10.RenderTransform(_loc_20, _loc_21, BlendMode.DARKEN, 1, 1, 0);
                                    if (_loc_11)
                                    {
                                        this.mGeneralInterface.mCurrentPlayerZone.RenderTextCenter(cBackbuffer.mBackBuffer, "[" + gMisc.ConvertDoubleToString_string(_loc_10.GetAmount()) + " " + _loc_19 + " in Group: " + _loc_10.GetDepositGroupID() + "]", _loc_20, _loc_21 + _loc_7);
                                    }
                                }
                            }
                        }
                    }
                    _loc_13++;
                    _loc_15++;
                }
                _loc_14++;
            }
            return;
        }// end function

        public function RemoveLandscapeFromList(param1:cLandscape) : void
        {
            var _loc_2:* = this.mBuildingsAndTrees_vector.indexOf(param1);
            if (_loc_2 != -1)
            {
                this.mBuildingsAndTrees_vector.splice(_loc_2, 1);
            }
            return;
        }// end function

        public static function GetStreetDirection(param1:cPosInt, param2:cPosInt) : int
        {
            if (param2.x > param1.x)
            {
                if (param2.y > param1.y)
                {
                    return 1;
                }
                return 0;
            }
            if (param2.y > param1.y)
            {
                return 2;
            }
            return 3;
        }// end function

    }
}
