package Map
{
    import AdventureSystem.*;
    import Communication.VO.*;
    import Enums.*;
    import GO.*;
    import Interface.*;
    import Map.SubMaps.*;
    import MilitarySystem.*;
    import PathFinding.*;
    import ServerState.*;
    import SettlerKI.*;
    import Sound.*;
    import Specialists.*;
    import TimedProduction.*;
    import __AS3__.vec.*;
    import flash.display.*;
    import flash.events.*;
    import flash.geom.*;
    import flash.ui.*;
    import nLib.*;

    public class cPlayerZoneScreen extends Object
    {
        private var mLastGOCursor:Point;
        public var mTrackedMissionList:dTrackedMissionListVO = null;
        private const mSpecialists_vector:Vector.<cSpecialist>;
        public var mAdventure:cAdventure = null;
        private const map_PlayerID_Resources:Object;
        private var mTempPoint:cPosInt;
        public var mShowDeposit:Boolean;
        public var mSectorStartX:int = 0;
        public var mSectorStartY:int = 0;
        public var mShiftPressed:Boolean = false;
        public var mClearBackGround:Boolean = false;
        public var mMouseMapScrolling:Boolean;
        public var mSettlerKIManager:cSettlerManager = null;
        public var mBackgroundDataMap:cBackgroundRectangleDataMap;
        private var mBuffProductionQueue:cTimedProductionQueue;
        private var mTempRect:Rectangle;
        public var mZoneColorSchema:String = null;
        public var mStreetDataMap:cStreetDataMap;
        public var mShowErrorMessageIsBuildingPlacable:Boolean = true;
        public var mShowDeposit_string:String = null;
        protected var mBackgroundHasChanged:Boolean;
        public const map_PlayerID_Army:Object;
        private var mErrorLastXMLElement:String;
        public var mSectorEndX:int = 0;
        public var CLEAR_COLOR:uint = 4151151;
        private var mMilitaryUnitRecruitments:cTimedProductionQueue;
        private var mGeneralInterface:cGeneralInterface;
        protected var mBackgroundHasChangedClear:Boolean;
        public var mSectorEndY:int = 0;
        private var mMouseDeltaScrollx:int = 0;
        private var mMouseDeltaScrolly:int = 0;
        public const mSectorList_vector:Vector.<cSector>;
        public var mControlPressed:Boolean = false;
        public var mMapScrolled:Boolean;

        public function cPlayerZoneScreen(param1:cGeneralInterface)
        {
            this.mSectorList_vector = new Vector.<cSector>;
            this.map_PlayerID_Army = new Object();
            this.map_PlayerID_Resources = new Object();
            this.mSpecialists_vector = new Vector.<cSpecialist>;
            this.mTempPoint = new cPosInt();
            this.mTempRect = new Rectangle();
            this.mLastGOCursor = new Point();
            this.mGeneralInterface = param1;
            this.mBackgroundDataMap = new cBackgroundRectangleDataMap(param1);
            this.mStreetDataMap = new cStreetDataMap(param1);
            this.mSettlerKIManager = new cSettlerManager(param1);
            this.mMilitaryUnitRecruitments = new cTimedProductionQueue(param1, TIMED_PRODUCTION_TYPE.MILITARY_UNIT);
            this.mBuffProductionQueue = new cTimedProductionQueue(param1, TIMED_PRODUCTION_TYPE.BUFF);
            return;
        }// end function

        public function MouseUp(event:MouseEvent) : void
        {
            this.mMouseMapScrolling = false;
            return;
        }// end function

        public function RenderText(param1:BitmapData, param2:String, param3:int, param4:int) : void
        {
            this.mTempPoint.x = param3;
            this.mTempPoint.y = param4;
            this.mGeneralInterface.mZoom.CalculateScrollPos(this.mTempPoint);
            param3 = this.mTempPoint.x;
            param4 = this.mTempPoint.y;
            globalFlash.gui.WriteDebugText(param1, param2, param3, param4);
            return;
        }// end function

        public function DepositWasDepleted(param1:cPlayerData, param2:int, param3:String) : void
        {
            var _loc_4:* = cBuilding.CreateFromString(param1, global.buildingGroup, defines.MINEDEPOSITDEPLETED_NAME_string + param3, this.mGeneralInterface);
            this.mStreetDataMap.SetBuildingGridPos(_loc_4, param2, false);
            _loc_4.SetBuildingMode(cBuilding.BUILDING_MODE_PRODUCES_NO_RESOURCES);
            _loc_4.mDirtyIndicator = _loc_4.mDirtyIndicator | DIRTY_INDICATOR.CREATED_BIT;
            if (_loc_4.GetResourceCreation() != null)
            {
                _loc_4.GetResourceCreation().mDirtyIndicator = _loc_4.GetResourceCreation().mDirtyIndicator | DIRTY_INDICATOR.CREATED_BIT;
            }
            this.SetLandscapeObjectToDepositHidden(param1, param2, param3);
            return;
        }// end function

        public function MouseClick(event:MouseEvent) : void
        {
            if (this.mMapScrolled)
            {
                this.mMapScrolled = false;
                return;
            }
            this.mGeneralInterface.mSetStreets.MouseClickOnMap(this.mGeneralInterface.mCurrentPlayer, this);
            this.mGeneralInterface.mSetBuildings.MouseClickOnMap(this.mGeneralInterface.mCurrentPlayer, this);
            return;
        }// end function

        public function GetArmy(param1:int) : cArmy
        {
            var _loc_2:* = this.map_PlayerID_Army[param1] as cArmy;
            if (_loc_2 == null)
            {
                _loc_2 = new cArmy(this.mGeneralInterface.mCurrentViewedZoneID, param1, ARMY_OWNER_TYPE.ZONE, this);
                this.map_PlayerID_Army[param1] = _loc_2;
            }
            return _loc_2;
        }// end function

        public function LevelBackgroundHasChanged() : void
        {
            this.mGeneralInterface.mCurrentPlayerZone.SetBackgroundHasChanged(true);
            return;
        }// end function

        public function AddDepositIcon(param1:String, param2:int) : void
        {
            this.mGeneralInterface.mGoSetListAnimationManager.AddSingleAnimation(param2, param1, 0, 0, global.streetGridY / 2, global.guiIconGroup, null);
            return;
        }// end function

        public function SetPlayerForSector(param1:int, param2:int) : void
        {
            var _loc_3:cSector = null;
            var _loc_4:cIsoElement = null;
            for each (_loc_3 in this.mGeneralInterface.mCurrentPlayerZone.mSectorList_vector)
            {
                
                if (_loc_3.GetSectorID() == param1)
                {
                    _loc_3.SetOwnerPlayerID(param2);
                }
            }
            for each (_loc_4 in this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list)
            {
                
                if (_loc_4.mSectorId == param1)
                {
                    if (_loc_4.mDeposit != null)
                    {
                        _loc_4.mDeposit.SetPlayerID(param2);
                    }
                }
            }
            return;
        }// end function

        public function UpgradeBuildingOnGridPosition(param1:int) : Boolean
        {
            var _loc_2:* = this.mStreetDataMap.mIsoMap_list[param1].mBuilding;
            if (_loc_2 == null)
            {
                return false;
            }
            if (_loc_2.mWaitForCommand)
            {
                return false;
            }
            _loc_2.mWaitForCommand = true;
            var _loc_3:* = new dServerAction();
            _loc_3.grid = param1;
            this.mGeneralInterface.mClientMessages.SendMessagetoServer(COMMAND.UPGRADE_BUILDING, this.mGeneralInterface.mCurrentViewedZoneID, _loc_3);
            cSoundManager.GetInstance().PlayEffect("BuildingUpgrade");
            return true;
        }// end function

        public function LogicCompute() : void
        {
            this.mStreetDataMap.LogicCompute();
            this.mMilitaryUnitRecruitments.Perform(this.mGeneralInterface.mHomePlayer);
            this.mBuffProductionQueue.Perform(this.mGeneralInterface.mHomePlayer);
            return;
        }// end function

        public function CacheBackgroundScroll() : void
        {
            this.CacheBackground(false);
            return;
        }// end function

        public function BackgroundDataMap_GridCallBack(param1:Function, param2:int, param3:Boolean) : void
        {
            this.mBackgroundDataMap.GridCallBack(param1, param2, param3);
            return;
        }// end function

        public function getSpecialist(param1:int, param2:dUniqueID) : cSpecialist
        {
            var _loc_3:cSpecialist = null;
            for each (_loc_3 in this.mSpecialists_vector)
            {
                
                if (_loc_3.GetPlayerID() == param1 && _loc_3.GetUniqueID().equals(param2))
                {
                    return _loc_3;
                }
            }
            return null;
        }// end function

        public function Clear() : void
        {
            this.mBackgroundDataMap.Clear();
            this.mStreetDataMap.Clear();
            this.mStreetDataMap.ClearDeposits();
            this.mSettlerKIManager.Clear();
            this.SetBackgroundHasChanged(true);
            return;
        }// end function

        public function CacheBackground(param1:Boolean) : void
        {
            var _loc_2:* = this.mGeneralInterface.mZoom.GetScrollPosX();
            var _loc_3:* = this.mGeneralInterface.mZoom.GetScrollPosY();
            if (cBackbuffer.ACTIVATE_SEGMENTBUFFER)
            {
                this.mGeneralInterface.mZoom.SetScrollPos(0, 0);
                cBackbuffer.SetRedirectToSegmentBuffer(true);
                if (param1)
                {
                    cBackbuffer.Clear(this.mGeneralInterface.mCurrentPlayerZone.CLEAR_COLOR);
                }
                else
                {
                    cBackbuffer.RemoveUnusedSegments(int(_loc_2), int(_loc_3), this.mGeneralInterface.mCurrentPlayerZone.CLEAR_COLOR);
                }
                this.mBackgroundDataMap.Render(GCB_MODE_CLIPPING.CLIP_TO_SCREEN_BACKGROUND);
                if (this.mGeneralInterface.showBackgroundGrid)
                {
                    this.mBackgroundDataMap.RenderGrid(GCB_MODE_CLIPPING.CLIP_TO_SCREEN_BACKGROUND);
                }
                this.mStreetDataMap.RenderStreets(GCB_MODE_CLIPPING.CLIP_TO_SCREEN_BACKGROUND);
                cBackbuffer.SetRedirectToSegmentBuffer(false);
            }
            this.mGeneralInterface.mZoom.SetScrollPos(_loc_2, _loc_3);
            return;
        }// end function

        public function GetPlayerColorIdx(param1:int) : int
        {
            if (param1 < 0)
            {
                return 13;
            }
            var _loc_2:* = this.mGeneralInterface.GetPlayerListPositionFromId(param1);
            return _loc_2 % 12;
        }// end function

        public function RemoveAtGridPosition(param1:cPlayerData, param2:int, param3:int) : Boolean
        {
            var _loc_6:int = 0;
            var _loc_7:cIsoElement = null;
            var _loc_8:String = null;
            var _loc_9:cGO = null;
            var _loc_10:cBuilding = null;
            var _loc_11:cBuilding = null;
            var _loc_12:cTimedProduction = null;
            var _loc_13:dResource = null;
            var _loc_14:iProductionOrder = null;
            var _loc_15:dResource = null;
            var _loc_16:cResources = null;
            var _loc_4:* = this.IsAtGridPosition(param2, param3);
            if (this.IsAtGridPosition(param2, param3) == null)
            {
                return false;
            }
            var _loc_5:Boolean = false;
            if (param2 == OBJECTTYPE.BACKGROUND)
            {
                _loc_5 = this.mBackgroundDataMap.RemoveGridPos(param3);
                this.LevelBackgroundHasChanged();
            }
            else if (param2 == OBJECTTYPE.LANDSCAPE)
            {
                _loc_5 = this.mStreetDataMap.RemoveLandscapeGridPos(param3);
                this.LevelBackgroundHasChanged();
            }
            else if (param2 == OBJECTTYPE.DEPOSIT)
            {
                _loc_5 = this.mStreetDataMap.RemoveDepositGridPos(param3);
                this.LevelBackgroundHasChanged();
            }
            else if (param2 == OBJECTTYPE.STREET)
            {
                _loc_5 = this.mStreetDataMap.RemoveStreetGridPos(param3);
                this.LevelBackgroundHasChanged();
            }
            else if (param2 == OBJECTTYPE.BUILDING)
            {
                _loc_10 = _loc_4 as cBuilding;
                this.mGeneralInterface.mCurrentPlayerZone.RemoveWatchArea(param2, _loc_10.GetBuildingName_string(), _loc_10);
                _loc_10.SetBuildingMode(cBuilding.BUILDING_MODE_DESTRUCTED);
                if (param1 != null)
                {
                    this.SetHiddenDepositAtRemovingBuilding(param1, param3, _loc_10);
                }
                _loc_5 = this.mStreetDataMap.RemoveBuildingGridPos(param3);
                if (this.mGeneralInterface.mEnumUIType == UITYPE.GAME)
                {
                    if (_loc_10.GetBuildingName_string() == defines.BARRACKS_NAME_string)
                    {
                        for each (_loc_12 in this.mMilitaryUnitRecruitments.mTimedProductions_vector)
                        {
                            
                            _loc_13 = null;
                            _loc_14 = _loc_12.GetProductionOrder();
                            for each (_loc_15 in _loc_14.GetCostsToBuy_vector())
                            {
                                
                                if (_loc_15.name_string == defines.POPULATION_RESOURCE_NAME_string)
                                {
                                    _loc_13 = _loc_15;
                                    break;
                                }
                            }
                            if (_loc_13 != null)
                            {
                                if (param1 != null)
                                {
                                    _loc_16 = this.mGeneralInterface.mCurrentPlayerZone.GetResources(param1);
                                    _loc_16.FreeMilitary(_loc_14.GetAmount() * _loc_13.amount);
                                }
                            }
                        }
                        this.mMilitaryUnitRecruitments.mTimedProductions_vector.length = 0;
                    }
                    else if (_loc_10.GetBuildingName_string() == defines.PROVISIONHOUSE_NAME_string)
                    {
                        this.mBuffProductionQueue.mTimedProductions_vector.length = 0;
                    }
                }
                if (_loc_10 != null && _loc_10.IsWarehouseType())
                {
                    this.mGeneralInterface.mPathFinder.InvalidateWarehouseMatrix(_loc_10.GetPlayerID());
                }
                this.mGeneralInterface.mPathFinder.InvalidateAll(this.mGeneralInterface.mCurrentPlayer.GetPlayerId());
                for each (_loc_11 in this.mStreetDataMap.GetBuildings_vector())
                {
                    
                    if (_loc_11.GetResourceCreation() != null)
                    {
                        _loc_11.GetResourceCreation().SetInvalidatePaths(true);
                    }
                }
                this.mStreetDataMap.UpdateObjectPositions();
                this.LevelBackgroundHasChanged();
            }
            if (_loc_5)
            {
                this.mStreetDataMap.CalculateBlockingGrid();
                return true;
            }
            return false;
        }// end function

        public function Init() : void
        {
            this.mGeneralInterface.showIsoGrid = false;
            this.mGeneralInterface.showBuildingDebugGrid = false;
            this.mGeneralInterface.showIsoDebugGrid = false;
            this.mSectorStartX = (defines.STREET_MAP_MIN_USABLE_AREA_X - 1) * global.streetGridX - global.streetGridXHalf;
            this.mSectorStartY = (defines.STREET_MAP_MIN_USABLE_AREA_Y - 1) * global.streetGridYHalf;
            this.mSectorEndX = (defines.STREET_ZONE_SIZE_X + defines.STREET_MAP_MIN_USABLE_AREA_X) * global.streetGridX - global.streetGridXHalf;
            this.mSectorEndY = (defines.STREET_ZONE_SIZE_Y + defines.STREET_MAP_MIN_USABLE_AREA_Y) * global.streetGridYHalf + global.streetGridYHalf;
            this.mBackgroundDataMap.Init();
            this.mStreetDataMap.Init();
            this.mSettlerKIManager.Init();
            this.mShowDeposit = false;
            this.mMouseMapScrolling = false;
            this.mMapScrolled = false;
            this.mMouseDeltaScrollx = 0;
            this.mMouseDeltaScrolly = 0;
            this.SetBackgroundHasChanged(true);
            return;
        }// end function

        public function RenderTextCenter(param1:BitmapData, param2:String, param3:int, param4:int) : void
        {
            this.mTempPoint.x = param3;
            this.mTempPoint.y = param4;
            this.mGeneralInterface.mZoom.CalculateScrollPos(this.mTempPoint);
            param3 = this.mTempPoint.x;
            param4 = this.mTempPoint.y;
            globalFlash.gui.WriteDebugTextCenter(param1, param2, param3, param4);
            return;
        }// end function

        private function CheckBlocking(param1:String, param2:int, param3:int, param4:String) : Boolean
        {
            var _loc_7:cBlockingData = null;
            var _loc_8:int = 0;
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            var _loc_11:int = 0;
            var _loc_12:cBlockingData = null;
            var _loc_13:cBlockingData = null;
            var _loc_5:* = cGO.GetBlockingList(OBJECTTYPE.BUILDING, param1);
            var _loc_6:Vector.<cBlockingData> = null;
            if (param4 != null)
            {
                _loc_6 = cGO.GetBlockingList(OBJECTTYPE.BUILDING, param4);
            }
            for each (_loc_7 in _loc_5)
            {
                
                if (param4 != null)
                {
                    _loc_12 = null;
                    for each (_loc_13 in _loc_6)
                    {
                        
                        if (_loc_7.getXPixelOffset() == _loc_13.getXPixelOffset() && _loc_7.getYPixelOffset() == _loc_13.getYPixelOffset())
                        {
                            _loc_12 = _loc_13;
                            break;
                        }
                    }
                    if (_loc_12 != null)
                    {
                        continue;
                    }
                }
                _loc_8 = param2 + _loc_7.getXPixelOffset() * global.streetGridX / 100;
                _loc_9 = param3 + _loc_7.getYPixelOffset() * global.streetGridY / 100;
                _loc_10 = gCalculations.ConvertPixelPosToStreetGridPos(_loc_8, _loc_9);
                _loc_11 = this.mStreetDataMap.GetBlockType(_loc_10);
                switch(_loc_7.getBlockingType())
                {
                    case cBlockingData.BLOCK_TYPE_ALLOW_NOTHING:
                    {
                        if (_loc_11 != cBlockingData.BLOCK_TYPE_ALLOW_ALL)
                        {
                            return false;
                        }
                        if ((this.mStreetDataMap.mIsoMap_list[_loc_10] as cIsoElement).mStreet != null)
                        {
                            return false;
                        }
                        break;
                    }
                    case cBlockingData.BLOCK_TYPE_ALLOW_STREETS:
                    {
                        if (_loc_11 == cBlockingData.BLOCK_TYPE_ALLOW_NOTHING)
                        {
                            return false;
                        }
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
            return true;
        }// end function

        public function Exit() : void
        {
            this.Clear();
            return;
        }// end function

        public function KeyUp(event:KeyboardEvent) : void
        {
            if (event.keyCode == Keyboard.SHIFT)
            {
                this.mShiftPressed = false;
            }
            if (event.keyCode == Keyboard.CONTROL)
            {
                this.mControlPressed = false;
            }
            return;
        }// end function

        public function SetAtGridPosition(param1:cPlayerData, param2:int, param3:String, param4:int) : cGO
        {
            var _loc_5:cGO = null;
            _loc_5 = cGO.CreateGoFromLevelObject(param1, param2, param3, this.mGeneralInterface);
            _loc_5 = this.SetGoAtGridPosition(param1, _loc_5, param2, param4);
            return _loc_5;
        }// end function

        public function IsStreetPlacableAtGridPosition(param1:cGO, param2:int) : int
        {
            var _loc_5:cIsoElement = null;
            var _loc_6:int = 0;
            if (this.mGeneralInterface.mEnumUIType == UITYPE.EDITOR)
            {
                return CURSOR_VALID.OK;
            }
            if (this.mStreetDataMap.IsFogAtGridPosition(param2))
            {
                return CURSOR_VALID.SET_STREET_COVERED_WITH_FOG;
            }
            var _loc_3:* = param1 as cStreet;
            if (_loc_3 != null)
            {
                _loc_5 = this.mStreetDataMap.mIsoMap_list[param2];
                _loc_6 = this.mSectorList_vector[_loc_5.mSectorId].GetOwnerPlayerID();
                if (_loc_6 < 0)
                {
                    return CURSOR_VALID.SET_STREET_SECTOR_IS_OWNED_BY_BANDITS;
                }
                if (_loc_3.GetPlayerID() != _loc_6)
                {
                    return CURSOR_VALID.SET_STREET_SECTOR_IS_NOT_OWNED_BY_PLAYER;
                }
                if (_loc_5.mLandscape != null)
                {
                    if (this.IsDepositFoundType(_loc_5.mLandscape.GetContainerName_string()))
                    {
                        return CURSOR_VALID.SET_STREET_PLACE_IS_BLOCKED_BY_DEPOSIT;
                    }
                }
            }
            var _loc_4:* = this.mStreetDataMap.GetBlockType(param2);
            if (this.mStreetDataMap.GetBlockType(param2) == cBlockingData.BLOCK_TYPE_ALLOW_NOTHING)
            {
                return CURSOR_VALID.SET_STREET_PLACE_IS_BLOCKED_BY_BLOCKING;
            }
            return CURSOR_VALID.OK;
        }// end function

        public function ScrollTo(param1:int, param2:int, param3:Number) : void
        {
            this.mGeneralInterface.mZoom.SetScrollPos(param1, param2);
            this.SetBackgroundHasChanged(true);
            return;
        }// end function

        public function IsAtGridPosition(param1:int, param2:int) : cGO
        {
            var _loc_3:cIsoElement = null;
            if (param1 == OBJECTTYPE.BACKGROUND)
            {
                return this.mBackgroundDataMap.mMap_list[param2];
            }
            if (param1 == OBJECTTYPE.LANDSCAPE)
            {
                return this.mStreetDataMap.mIsoMap_list[param2].mLandscape;
            }
            if (param1 == OBJECTTYPE.DEPOSIT)
            {
                return this.mStreetDataMap.mIsoMap_list[param2].mDeposit;
            }
            if (param1 == OBJECTTYPE.STREET)
            {
                return this.mStreetDataMap.mIsoMap_list[param2].mStreet;
            }
            if (param1 == OBJECTTYPE.BUILDING)
            {
                return this.mStreetDataMap.mIsoMap_list[param2].mBuilding;
            }
            return null;
        }// end function

        public function IsDepositFoundType(param1:String) : Boolean
        {
            var _loc_3:String = null;
            var _loc_2:* = defines.DEPOSITFOUND_NAME_string.length;
            if (param1.length >= _loc_2)
            {
                _loc_3 = gMisc.GetSubString_string(param1, 0, defines.DEPOSITFOUND_NAME_string.length);
                if (_loc_3 == defines.DEPOSITFOUND_NAME_string)
                {
                    return true;
                }
            }
            return false;
        }// end function

        public function AddLandscape(param1:cPlayerData, param2:String, param3:int) : cGO
        {
            var _loc_4:* = this.mGeneralInterface.mCurrentPlayerZone.SetAtGridPosition(param1, OBJECTTYPE.LANDSCAPE, param2, param3);
            (this.mGeneralInterface.mCurrentPlayerZone.SetAtGridPosition(param1, OBJECTTYPE.LANDSCAPE, param2, param3) as cLandscape).mDirtyIndicator = (_loc_4 as cLandscape).mDirtyIndicator | DIRTY_INDICATOR.CREATED_BIT;
            return _loc_4;
        }// end function

        public function DestroyBuildingByAttack(param1:cBuilding, param2:cPlayerData) : void
        {
            var _loc_3:Vector.<cBuilding> = null;
            var _loc_4:int = 0;
            var _loc_5:Boolean = false;
            var _loc_6:cBuilding = null;
            var _loc_7:cIsoElement = null;
            var _loc_8:cBuilding = null;
            var _loc_9:cSquad = null;
            this.RemoveAtGridPosition(param1.mPlayerData, OBJECTTYPE.BUILDING, param1.GetBuildingGrid());
            if (param1.IsWarehouseType())
            {
                _loc_3 = new Vector.<cBuilding>;
                _loc_4 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[param1.GetBuildingGrid()].mSectorId;
                _loc_5 = false;
                for each (_loc_6 in this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.GetBuildings_vector())
                {
                    
                    _loc_7 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_6.GetBuildingGrid()];
                    if (_loc_7.mSectorId == _loc_4)
                    {
                        if (_loc_6.IsWarehouseType())
                        {
                            _loc_5 = true;
                            break;
                            continue;
                        }
                        _loc_3.push(_loc_6);
                    }
                }
                if (!_loc_5)
                {
                    this.mGeneralInterface.mCurrentPlayerZone.SetPlayerForSector(_loc_4, 0);
                    for each (_loc_8 in _loc_3)
                    {
                        
                        if (_loc_8.GetBuildingName_string() == defines.GARRISON_NAME_string)
                        {
                            continue;
                        }
                        if (_loc_8.GetPlayerID() >= 0)
                        {
                            continue;
                        }
                        this.mGeneralInterface.mCurrentPlayerZone.RemoveWatchArea(OBJECTTYPE.BUILDING, _loc_8.GetBuildingName_string(), _loc_8);
                        _loc_8.SetBuildingMode(cBuilding.BUILDING_MODE_DESTRUCTED);
                        for each (_loc_9 in _loc_8.GetArmy().GetSquads_vector())
                        {
                            
                            param2.AddXP(_loc_9.GetUnitDescription().GetXpForDefeat() * _loc_9.GetAmount());
                        }
                        this.SetHiddenDepositAtRemovingBuilding(_loc_8.mPlayerData, param1.GetBuildingGrid(), _loc_8);
                        this.mStreetDataMap.RemoveBuildingGridPos(_loc_8.GetBuildingGrid());
                        this.mStreetDataMap.RemoveBuildingFromGameLogic(_loc_8);
                    }
                }
            }
            return;
        }// end function

        public function ClearOnTheFly() : void
        {
            this.mStreetDataMap.Clear();
            this.mStreetDataMap.ClearDeposits();
            this.mSettlerKIManager.Clear();
            this.SetBackgroundHasChanged(true);
            return;
        }// end function

        public function SetBlockingByTypeAndPosition(param1:int, param2:String, param3:int, param4:int, param5:cIsoElement) : void
        {
            var _loc_7:cBlockingData = null;
            var _loc_8:int = 0;
            var _loc_9:int = 0;
            var _loc_6:* = cGO.GetBlockingList(param1, param2);
            for each (_loc_7 in _loc_6)
            {
                
                _loc_8 = param3 + _loc_7.getXPixelOffset() * global.streetGridX / 100;
                _loc_9 = param4 + _loc_7.getYPixelOffset() * global.streetGridY / 100;
                this.mStreetDataMap.SetBlockingPixelPos(_loc_8, _loc_9, _loc_7.getBlockingType(), param5);
            }
            return;
        }// end function

        public function RenderOverlayGraphics(param1:Graphics) : void
        {
            this.mSettlerKIManager.RenderSettlerDebugInfo(param1);
            this.mStreetDataMap.BuildingRenderBuildingDebugInfo(param1);
            this.mStreetDataMap.RenderIsoElementDebugInfo(param1);
            return;
        }// end function

        public function IsADepletedDepositTypeWhichFreePlacable(param1:cBuilding) : Boolean
        {
            if (param1.GetBuildingName_string() == defines.MINEDEPOSITDEPLETEDCORN_NAME_string || param1.GetBuildingName_string() == defines.MINEDEPOSITDEPLETEDWATER_NAME_string)
            {
                return true;
            }
            return false;
        }// end function

        public function SaveZoneStartZoom() : void
        {
            var _loc_1:* = new cMapPos();
            _loc_1.mScrollposX = this.mGeneralInterface.mZoom.GetScrollPosX();
            _loc_1.mScrollposY = this.mGeneralInterface.mZoom.GetScrollPosY();
            _loc_1.mZoomScaleFactor = this.mGeneralInterface.mZoom.GetScaleFactor();
            this.mGeneralInterface.mLastZoomPos[this.mGeneralInterface.mHomePlayer.GetHomeZoneId()] = _loc_1;
            return;
        }// end function

        public function IsBuildingPlacableGridPosition(param1:cGO, param2:cPlayerData, param3:int) : int
        {
            var _loc_5:cIsoElement = null;
            var _loc_6:int = 0;
            var _loc_7:Boolean = false;
            var _loc_8:String = null;
            var _loc_9:String = null;
            var _loc_10:cPathObject = null;
            var _loc_11:cBuilding = null;
            var _loc_12:cPathObject = null;
            if (this.mStreetDataMap.IsFogAtGridPosition(param3))
            {
                return ERROR_CODES.BUILDING_IS_ON_FOG;
            }
            var _loc_4:* = param1 as cBuilding;
            if (param1 as cBuilding != null)
            {
                _loc_5 = this.mStreetDataMap.mIsoMap_list[param3];
                _loc_6 = this.mSectorList_vector[_loc_5.mSectorId].GetOwnerPlayerID();
                if (!_loc_4.IsWarehouseType() && this.mGeneralInterface.mCurrentCursor.GetEditMode() != COMMAND.MOVE_GARISSON && _loc_4.GetPlayerID() != _loc_6)
                {
                    if (this.mShowErrorMessageIsBuildingPlacable)
                    {
                    }
                    return ERROR_CODES.PLAYER_IS_NOT_SECTOR_OWNER;
                }
                if (_loc_6 < 0)
                {
                    if (this.mShowErrorMessageIsBuildingPlacable)
                    {
                    }
                    return ERROR_CODES.SECTOR_IS_OWNED_BY_BANDITS;
                }
                _loc_7 = false;
                _loc_8 = _loc_4.GetGOContainer().mRestrictPlacingToDeposit;
                if (_loc_8 != null)
                {
                    if (_loc_5.mBuilding != null)
                    {
                        if (!this.mStreetDataMap.IsADepletedDeposit(_loc_5.mBuilding))
                        {
                            return ERROR_CODES.MINE_TYPE_PLACE_IS_BLOCKED;
                        }
                    }
                    if (_loc_5.mDeposit != null && _loc_5.mDeposit.GetAccessibleType() == DEPOSIT_ACCESSIBLE_TYPES.ACCESSIBLE)
                    {
                        if (_loc_5.mDeposit.GetName_string() != _loc_8)
                        {
                            if (this.mShowErrorMessageIsBuildingPlacable)
                            {
                            }
                            return ERROR_CODES.MINE_TYPE_BUILDING_IS_NOT_PLACED_ON_DEPOSIT;
                        }
                        else
                        {
                            if (this.mGeneralInterface.mCurrentCursor.GetEditMode() != COMMAND.MOVE_GARISSON)
                            {
                                _loc_10 = this.mGeneralInterface.mPathFinder.CalculatePathForWarehouse(param3, param2.GetPlayerId());
                                if (_loc_10.dest_vector.length == 0)
                                {
                                    if (this.mShowErrorMessageIsBuildingPlacable)
                                    {
                                    }
                                    return ERROR_CODES.PLACE_IS_NOT_REACHABLE;
                                }
                            }
                            return ERROR_CODES.NO_ERROR;
                        }
                    }
                    else
                    {
                        return ERROR_CODES.MINE_TYPE_BUILDING_IS_NOT_PLACED_ON_DEPOSIT;
                    }
                }
                else if (_loc_5.mLandscape != null)
                {
                    if (this.IsDepositFoundType(_loc_5.mLandscape.GetContainerName_string()))
                    {
                        if (this.mShowErrorMessageIsBuildingPlacable)
                        {
                        }
                        return ERROR_CODES.TRY_TO_BUILD_ON_DEPOSIT;
                    }
                }
                _loc_9 = null;
                if (_loc_5.mBuilding != null)
                {
                    if (this.mStreetDataMap.IsADepletedDeposit(_loc_5.mBuilding))
                    {
                        if (!this.IsADepletedDepositTypeWhichFreePlacable(_loc_5.mBuilding))
                        {
                            return ERROR_CODES.PLACE_IS_BLOCKED_BY_BUILDING;
                        }
                        _loc_9 = _loc_5.mBuilding.GetBuildingName_string();
                    }
                    else
                    {
                        return ERROR_CODES.PLACE_IS_BLOCKED_BY_BUILDING;
                    }
                }
                if (_loc_9 == null)
                {
                    for each (_loc_11 in this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.GetBuildings_vector())
                    {
                        
                        if (_loc_11.GetBuildingGrid() == param3)
                        {
                            if (this.mShowErrorMessageIsBuildingPlacable)
                            {
                                this.mGeneralInterface.LocalLogMessageDetail(this.mGeneralInterface.GetPlayerIDString() + "  FALSE: Cannot set building because there is already one, but only in the building list");
                            }
                            this.mStreetDataMap.mIsoMap_list[param3].mBuilding = _loc_11;
                            return ERROR_CODES.PLACE_IS_BLOCKED_BY_BUILDING_IN_LIST;
                        }
                    }
                }
                gCalculations.ConvertStreetGridToPixelPos(param3, this.mTempPoint);
                if (!this.CheckBlocking(_loc_4.GetBuildingName_string(), this.mTempPoint.x, this.mTempPoint.y, _loc_9))
                {
                    return ERROR_CODES.PLACE_IS_BLOCKED_BY_BLOCKING_SYSTEM;
                }
                if (this.mGeneralInterface.mCurrentCursor.GetEditMode() != COMMAND.MOVE_GARISSON)
                {
                    _loc_12 = this.mGeneralInterface.mPathFinder.CalculatePathForWarehouse(param3, param2.GetPlayerId());
                    if (_loc_12.dest_vector.length == 0)
                    {
                        if (this.mShowErrorMessageIsBuildingPlacable)
                        {
                        }
                        return ERROR_CODES.PLACE_IS_NOT_REACHABLE;
                    }
                }
            }
            return 0;
        }// end function

        public function SetHiddenDepositAtRemovingBuilding(param1:cPlayerData, param2:int, param3:cBuilding) : void
        {
            var _loc_4:* = param3.GetGOContainer().mRestrictPlacingToDeposit;
            if (param3.GetGOContainer().mRestrictPlacingToDeposit != null)
            {
                this.SetLandscapeObjectToDepositHidden(param1, param2, _loc_4);
            }
            return;
        }// end function

        public function GetAmountOfBaseSpecialists(param1:int, param2:int) : int
        {
            var _loc_4:cSpecialist = null;
            var _loc_3:int = 0;
            for each (_loc_4 in this.mSpecialists_vector)
            {
                
                if (_loc_4.GetPlayerID() == param1 && _loc_4.GetBaseType() == param2)
                {
                    _loc_3++;
                }
            }
            return _loc_3;
        }// end function

        public function GetAmountOfSpecialists(param1:int, param2:int) : int
        {
            var _loc_4:cSpecialist = null;
            var _loc_3:int = 0;
            for each (_loc_4 in this.mSpecialists_vector)
            {
                
                if (_loc_4.GetPlayerID() == param1 && _loc_4.GetType() == param2)
                {
                    _loc_3++;
                }
            }
            return _loc_3;
        }// end function

        public function GetMilitaryUnitRecruitments() : cTimedProductionQueue
        {
            return this.mMilitaryUnitRecruitments;
        }// end function

        public function UpdatePositions() : void
        {
            this.mStreetDataMap.UpdateObjectPositions();
            this.mBackgroundDataMap.UpdatePositions();
            return;
        }// end function

        public function GetBuildingFromGridPosition(param1:int) : cBuilding
        {
            var _loc_2:* = this.mStreetDataMap.GetIsoElementFromGridPosition(param1);
            if (_loc_2 != null)
            {
                return _loc_2.mBuilding;
            }
            return null;
        }// end function

        public function RenderTextCenterBackground(param1:BitmapData, param2:String, param3:int, param4:int, param5:int) : void
        {
            this.mTempPoint.x = param3;
            this.mTempPoint.y = param4;
            this.mGeneralInterface.mZoom.CalculateScrollPos(this.mTempPoint);
            param3 = this.mTempPoint.x;
            param4 = this.mTempPoint.y;
            globalFlash.gui.WriteDebugTextCenterBackground(param1, param2, param3, param4, param5);
            return;
        }// end function

        public function KeyDown(event:KeyboardEvent) : void
        {
            var _loc_2:int = 0;
            if (this.mGeneralInterface.mHomePlayer.GetHomeZoneId() > defines.ADVENTUREZONEID)
            {
                if (event.charCode >= gMisc.AsciiKeyCode("1") && event.charCode <= gMisc.AsciiKeyCode("9"))
                {
                    _loc_2 = event.charCode.valueOf() - 49;
                    if (_loc_2 <= 2)
                    {
                        _loc_2 = _loc_2 + 6;
                    }
                    else if (_loc_2 >= 6)
                    {
                        _loc_2 = _loc_2 - 6;
                    }
                    this.mGeneralInterface.mZoom.SetScrollPosPlayerZoneSectorNr(this, _loc_2);
                    this.SetBackgroundHasChanged(true);
                }
            }
            if (event.charCode == gMisc.AsciiKeyCode("b"))
            {
                if (this.mGeneralInterface.mCurrentViewedZoneID == this.mGeneralInterface.mCurrentPlayer.GetPlayerId())
                {
                    globalFlash.gui.ShowBarracks();
                }
            }
            if (event.charCode == gMisc.AsciiKeyCode("p"))
            {
                if (this.mGeneralInterface.mCurrentViewedZoneID == this.mGeneralInterface.mCurrentPlayer.GetPlayerId())
                {
                    globalFlash.gui.ShowProvisionHouse();
                }
            }
            if (event.charCode == gMisc.AsciiKeyCode("h"))
            {
                if (this.mGeneralInterface.mCurrentViewedZoneID == this.mGeneralInterface.mCurrentPlayer.GetPlayerId())
                {
                    globalFlash.gui.ShowWarehouse();
                }
            }
            if (event.keyCode == Keyboard.SHIFT)
            {
                this.mShiftPressed = true;
            }
            if (event.keyCode == Keyboard.CONTROL)
            {
                this.mControlPressed = true;
            }
            return;
        }// end function

        public function IsBuildingOnMap(param1:String) : Boolean
        {
            var _loc_2:cBuilding = null;
            for each (_loc_2 in this.mStreetDataMap.GetBuildings_vector())
            {
                
                if (_loc_2.GetBuildingName_string() == param1 && _loc_2.IsBuildingActive())
                {
                    return true;
                }
            }
            return false;
        }// end function

        public function GetResources(param1:cPlayerData) : cResources
        {
            return this.GetResourcesForPlayerID(param1.GetPlayerId());
        }// end function

        public function RenderScreenInfo() : void
        {
            return;
        }// end function

        public function RenderCompute() : void
        {
            this.mStreetDataMap.RenderCompute();
            this.mGeneralInterface.mGoSetListAnimationManager.RenderCompute();
            if (this.mGeneralInterface.mCalculateEconomy)
            {
                this.mSettlerKIManager.RenderCompute();
            }
            return;
        }// end function

        public function AddResources(param1:cResources) : void
        {
            this.map_PlayerID_Resources[param1.GetPlayerID()] = param1;
            return;
        }// end function

        public function BuildingDataMap_GridCallBack(param1:Function, param2:int, param3:Boolean) : void
        {
            this.mStreetDataMap.BuildingGridCallBack(param1, param2, param3);
            return;
        }// end function

        public function GetFirstBuildingOnMap(param1:String) : cBuilding
        {
            var _loc_2:cBuilding = null;
            for each (_loc_2 in this.mStreetDataMap.GetBuildings_vector())
            {
                
                if (_loc_2.GetBuildingName_string() == param1 && _loc_2.IsBuildingActive())
                {
                    return _loc_2;
                }
            }
            return null;
        }// end function

        public function GetSectorOwnerPlayerID(param1:int) : int
        {
            var _loc_2:cSector = null;
            for each (_loc_2 in this.mGeneralInterface.mCurrentPlayerZone.mSectorList_vector)
            {
                
                if (_loc_2.GetSectorID() == param1)
                {
                    return _loc_2.GetOwnerPlayerID();
                }
            }
            gMisc.Assert(false, "Sector with ID: " + param1 + " not found!");
            return -1;
        }// end function

        public function Render() : void
        {
            var _loc_2:int = 0;
            var _loc_3:cDeposit = null;
            if (cBackbuffer.ACTIVATE_SEGMENTBUFFER)
            {
                if (this.mBackgroundHasChanged)
                {
                    cBackbuffer.SetClippingXYWH(this.mGeneralInterface.mZoom.InvScaleInt(this.mGeneralInterface.mZoom.GetScrollPosX(), cZoom.DEFAULT_ZOOM), this.mGeneralInterface.mZoom.InvScaleInt(this.mGeneralInterface.mZoom.GetScrollPosY(), cZoom.DEFAULT_ZOOM), global.screenWidth, global.screenHeight);
                    this.CacheBackground(this.mBackgroundHasChangedClear);
                    cBackbuffer.SetDefaultClipping();
                    this.mBackgroundHasChanged = false;
                }
                this.mTempRect.x = this.mGeneralInterface.mZoom.InvScale(this.mGeneralInterface.mZoom.GetScrollPosX(), cZoom.DEFAULT_ZOOM);
                this.mTempRect.y = this.mGeneralInterface.mZoom.InvScale(this.mGeneralInterface.mZoom.GetScrollPosY(), cZoom.DEFAULT_ZOOM);
                this.mTempRect.width = cBackbuffer.GetWidth();
                this.mTempRect.height = cBackbuffer.GetHeight();
                cBackbuffer.CopyFromSegmentBuffer(this.mTempRect);
            }
            else
            {
                this.mBackgroundDataMap.Render(GCB_MODE_CLIPPING.CLIP_TO_SCREEN_FOREGROUND);
                if (this.mGeneralInterface.showBackgroundGrid)
                {
                    this.mBackgroundDataMap.RenderGrid(GCB_MODE_CLIPPING.CLIP_TO_SCREEN_FOREGROUND);
                }
                this.mStreetDataMap.RenderStreets(GCB_MODE_CLIPPING.CLIP_TO_SCREEN_FOREGROUND);
            }
            if (!this.mClearBackGround)
            {
                this.mBackgroundDataMap.RenderWaterBorder(GCB_MODE_CLIPPING.CLIP_TO_SCREEN_FOREGROUND);
            }
            this.mStreetDataMap.RenderFreeBackground(GCB_MODE_CLIPPING.CLIP_TO_SCREEN_FOREGROUND);
            var _loc_1:* = this.mGeneralInterface.GetSelectedBuilding();
            if (this.mGeneralInterface.mCurrentCursor.GetEditMode() != COMMAND.SET_BUILDING_IN_GAME && this.mGeneralInterface.mCurrentCursor.GetEditMode() != COMMAND.SET_BUILDING_BY_BUFF && this.mGeneralInterface.mCurrentCursor.GetEditMode() != COMMAND.APPLY_BUFF)
            {
                this.mGeneralInterface.mCurrentPlayerZone.mShowDeposit = false;
            }
            if (this.mGeneralInterface.showIsoGrid)
            {
                this.mStreetDataMap.RenderGrid();
            }
            if (_loc_1 != null && _loc_1.GetGOContainer().mWatchAreaId != -1)
            {
                this.mStreetDataMap.RenderWatchAreaOfSelectedBuilding(_loc_1);
            }
            if (_loc_1 != null)
            {
                if (_loc_1.GetResourceCreation() != null)
                {
                    if (_loc_1.GetResourceCreation().GetResourceCreationDefinition() != null && _loc_1.GetResourceCreation().GetResourceCreationDefinition().externalResource_string != null && _loc_1.GetResourceCreation().GetResourceCreationDefinition().externalResource_string.length > 0)
                    {
                        this.mGeneralInterface.mCurrentPlayerZone.mShowDeposit_string = _loc_1.GetResourceCreation().GetResourceCreationDefinition().externalResource_string;
                        this.mGeneralInterface.mCurrentPlayerZone.mShowDeposit = true;
                    }
                }
                else if (_loc_1.GetGOContainer().mAddDepositAmount != -1)
                {
                    _loc_2 = _loc_1.GetBuildingGrid();
                    _loc_3 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_2].mDeposit;
                    if (_loc_3 != null)
                    {
                        this.mGeneralInterface.mCurrentPlayerZone.mShowDeposit_string = _loc_3.GetName_string();
                        this.mGeneralInterface.mCurrentPlayerZone.mShowDeposit = true;
                    }
                }
            }
            if (this.mMouseMapScrolling)
            {
            }
            else
            {
                this.mGeneralInterface.mSetStreets.ShowStreetsInRealTime(this.mGeneralInterface.mCurrentPlayer);
                if (!this.mGeneralInterface.mCurrentCursor.IsInSetBuildingMode())
                {
                    this.mGeneralInterface.mCurrentCursor.RenderUnderBuildings();
                }
            }
            cSpriteLibContainer.mActivateAntialiasing = true;
            this.mStreetDataMap.RenderBuildingsWithSettlers(GCB_MODE_CLIPPING.CLIP_TO_SCREEN_FOREGROUND);
            this.mGeneralInterface.mGoSetListAnimationManager.Render();
            if (this.mShowDeposit)
            {
                if (this.mShowDeposit_string.length > 0)
                {
                    this.mStreetDataMap.RenderDepositsGame(this.mShowDeposit_string);
                }
                else
                {
                    this.mStreetDataMap.RenderDepositsAll();
                }
            }
            else if (this.mGeneralInterface.showDepositMap)
            {
                this.mStreetDataMap.RenderDepositsAll();
            }
            cSpriteLibContainer.mActivateAntialiasing = false;
            if (this.mGeneralInterface.mCurrentCursor.IsInCursorInfoMode())
            {
                this.mStreetDataMap.RenderCursorInfo(this.mGeneralInterface.mCurrentCursor.GetGridPosition());
            }
            if (!this.mMouseMapScrolling)
            {
                this.mGeneralInterface.mCurrentCursor.PostRender();
                this.mGeneralInterface.mSetBuildings.ShowMilitaryPathInRealTime(this.mGeneralInterface.mCurrentPlayer);
            }
            if (this.mGeneralInterface.showFogOfWar)
            {
                this.mStreetDataMap.RenderFog();
            }
            if (this.mGeneralInterface.showBlockingGrid || this.mGeneralInterface.showWatchAreas)
            {
                this.mStreetDataMap.RenderBlockingGrid();
            }
            if (this.mGeneralInterface.showSectorGrid)
            {
                this.mStreetDataMap.RenderSectorGrid();
            }
            if (this.mGeneralInterface.showLandingFields)
            {
            }
            return;
        }// end function

        public function RemoveWatchArea(param1:int, param2:String, param3:cBuilding) : void
        {
            var _loc_8:cWatchData = null;
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            var _loc_4:* = cGO.GetWatchAreaId(param1, param2);
            if (cGO.GetWatchAreaId(param1, param2) <= 0)
            {
                return;
            }
            var _loc_5:* = global.watchAreas_vector[_loc_4];
            var _loc_6:* = param3.GetXInt();
            var _loc_7:* = param3.GetYInt() - global.streetGridYHalf;
            for each (_loc_8 in _loc_5)
            {
                
                _loc_9 = _loc_6 + _loc_8.getXPixelOffset() * global.streetGridX / 100;
                _loc_10 = _loc_7 + _loc_8.getYPixelOffset() * global.streetGridY / 100;
                this.mStreetDataMap.RemoveWatchpoint(_loc_9, _loc_10, param3);
            }
            return;
        }// end function

        public function SendDestructBuildingCommand(param1:int) : Boolean
        {
            var _loc_2:* = this.mStreetDataMap.mIsoMap_list[param1].mBuilding;
            if (_loc_2 == null)
            {
                return false;
            }
            if (_loc_2.mWaitForCommand)
            {
                return false;
            }
            _loc_2.mWaitForCommand = true;
            var _loc_3:* = new dServerAction();
            _loc_3.grid = param1;
            this.mGeneralInterface.mClientMessages.SendMessagetoServer(COMMAND.DESTRUCT_BUILDING, this.mGeneralInterface.mCurrentViewedZoneID, _loc_3);
            if (_loc_2.GetBuildingName_string() != defines.GARRISON_NAME_string)
            {
                cSoundManager.GetInstance().PlayEffect("BuildingDestroy");
            }
            return true;
        }// end function

        public function IsPositionInsideZone(param1:int, param2:int) : Boolean
        {
            return param1 > this.mSectorStartX && param1 < this.mSectorEndX && param2 > this.mSectorStartY && param2 < this.mSectorEndY;
        }// end function

        public function ScrollToGrid(param1:int) : void
        {
            var _loc_2:* = new cPosInt();
            gCalculations.ConvertStreetGridToPixelPos(param1, _loc_2);
            this.ScrollTo(_loc_2.x, _loc_2.y, 0);
            return;
        }// end function

        public function GetResourcesForPlayerID(param1:int) : cResources
        {
            var _loc_2:* = this.map_PlayerID_Resources[param1];
            return _loc_2;
        }// end function

        public function MouseDown(event:MouseEvent) : void
        {
            var _loc_2:* = this.mGeneralInterface.mZoom.Scale(event.stageX, cZoom.DEFAULT_ZOOM);
            var _loc_3:* = this.mGeneralInterface.mZoom.Scale(event.stageY, cZoom.DEFAULT_ZOOM);
            this.mLastGOCursor.x = _loc_2;
            this.mLastGOCursor.y = _loc_3;
            this.mMapScrolled = false;
            this.mMouseMapScrolling = true;
            if (this.mGeneralInterface.mEnumUIType == UITYPE.EDITOR)
            {
                if (this.mControlPressed)
                {
                    this.mMouseMapScrolling = false;
                    this.mGeneralInterface.mSetStreets.MouseClickOnMap(this.mGeneralInterface.mCurrentPlayer, this);
                    this.mGeneralInterface.mSetBuildings.MouseClickOnMap(this.mGeneralInterface.mCurrentPlayer, this);
                }
            }
            return;
        }// end function

        public function GetSpecialists_vector()
        {
            return this.mSpecialists_vector;
        }// end function

        public function SetFogRendering(param1:Boolean) : void
        {
            var _loc_2:cIsoElement = null;
            if (!param1)
            {
                for each (_loc_2 in this.mStreetDataMap.mIsoMap_list)
                {
                    
                    _loc_2.mFogBorder = 0;
                }
                this.mGeneralInterface.showFogOfWar = false;
            }
            else
            {
                this.mStreetDataMap.CalculateFogBorders(this.mGeneralInterface.mCurrentPlayer);
                this.mGeneralInterface.showFogOfWar = true;
            }
            this.mStreetDataMap.CalculateBorders();
            this.SetBackgroundHasChanged(true);
            return;
        }// end function

        public function SetGoAtGridPosition(param1:cPlayerData, param2:cGO, param3:int, param4:int) : cGO
        {
            var _loc_5:cSettler = null;
            if (param3 == OBJECTTYPE.BACKGROUND)
            {
                if (!this.mBackgroundDataMap.SetGridPos(param2, param4))
                {
                    return null;
                }
                this.LevelBackgroundHasChanged();
            }
            else if (param3 == OBJECTTYPE.LANDSCAPE)
            {
                if (!this.mStreetDataMap.SetLandscapeGridPos(param2, param4))
                {
                    return null;
                }
            }
            else if (param3 == OBJECTTYPE.DEPOSIT)
            {
                if (!this.mStreetDataMap.SetDepositGridPos(param1, param2, param4))
                {
                    return null;
                }
            }
            else if (param3 == OBJECTTYPE.STREET)
            {
                if (!this.mStreetDataMap.SetStreetGridPos(param2, param4))
                {
                    return null;
                }
                this.LevelBackgroundHasChanged();
            }
            else if (param3 == OBJECTTYPE.BUILDING)
            {
                if (!this.mStreetDataMap.SetBuildingGridPos(param2, param4, !this.mStreetDataMap.GetLoadedFromMap()))
                {
                    return null;
                }
            }
            else
            {
                gMisc.Assert(false, "Error: SetGoAtGridPosition illegal object type " + param3);
            }
            return param2;
        }// end function

        public function CalculateDeltaScrolls() : void
        {
            if (this.mMouseDeltaScrollx != 0 || this.mMouseDeltaScrolly != 0)
            {
                if (this.mMouseDeltaScrollx > 0)
                {
                    if (this.mMouseDeltaScrolly > 0)
                    {
                        this.Scroll(defines.SCROLL_RIGHT, this.mMouseDeltaScrollx);
                        this.Scroll(defines.SCROLL_DOWN, this.mMouseDeltaScrolly);
                    }
                    else
                    {
                        this.Scroll(defines.SCROLL_RIGHT, this.mMouseDeltaScrollx);
                        this.Scroll(defines.SCROLL_UP, -this.mMouseDeltaScrolly);
                    }
                }
                else if (this.mMouseDeltaScrolly > 0)
                {
                    this.Scroll(defines.SCROLL_LEFT, -this.mMouseDeltaScrollx);
                    this.Scroll(defines.SCROLL_DOWN, this.mMouseDeltaScrolly);
                }
                else
                {
                    this.Scroll(defines.SCROLL_LEFT, -this.mMouseDeltaScrollx);
                    this.Scroll(defines.SCROLL_UP, -this.mMouseDeltaScrolly);
                }
                this.mMouseDeltaScrollx = 0;
                this.mMouseDeltaScrolly = 0;
            }
            else
            {
                this.Scroll(this.mGeneralInterface.scroll, global.scrollSpeed * this.mGeneralInterface.mCalculateTicks.mDeltaTicksOne);
            }
            return;
        }// end function

        public function SetLandscapeObjectToDepositHidden(param1:cPlayerData, param2:int, param3:String) : void
        {
            if (global.landscapeGroup.IsSpriteInGroup(defines.DEPOSIT_HIDDEN_string + param3))
            {
                this.AddLandscape(param1, defines.DEPOSIT_HIDDEN_string + param3, param2);
            }
            return;
        }// end function

        public function SetWatchArea(param1:int, param2:String, param3:cBuilding) : void
        {
            var _loc_8:cWatchData = null;
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            var _loc_4:* = cGO.GetWatchAreaId(param1, param2);
            if (cGO.GetWatchAreaId(param1, param2) <= 0)
            {
                return;
            }
            var _loc_5:* = global.watchAreas_vector[_loc_4];
            var _loc_6:* = param3.GetXInt();
            var _loc_7:* = param3.GetYInt() - global.streetGridYHalf;
            for each (_loc_8 in _loc_5)
            {
                
                _loc_9 = _loc_6 + _loc_8.getXPixelOffset() * global.streetGridX / 100;
                _loc_10 = _loc_7 + _loc_8.getYPixelOffset() * global.streetGridY / 100;
                this.mStreetDataMap.SetWatchpoint(_loc_9, _loc_10, param3);
            }
            return;
        }// end function

        public function MouseWheel(event:MouseEvent) : void
        {
            this.mGeneralInterface.mZoom.AddScaleFactor(event.delta * (this.mGeneralInterface.mZoom.GetScaleFactor() / (1000 / global.zoomSpeed)));
            this.mGeneralInterface.mCurrentCursor.MouseMove(event);
            return;
        }// end function

        public function SetFogForSector(param1:int) : void
        {
            var _loc_2:cIsoElement = null;
            for each (_loc_2 in this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list)
            {
                
                if (_loc_2.mSectorId == param1)
                {
                    _loc_2.mFogBorder = 0;
                }
            }
            return;
        }// end function

        public function SetBackgroundHasChanged(param1:Boolean) : void
        {
            this.mBackgroundHasChanged = true;
            this.mBackgroundHasChangedClear = param1;
            return;
        }// end function

        public function SetAllRescaleDirtyFlags() : void
        {
            global.guiIconGroup.SetRescaleDirtyFlag();
            global.backgroundGroup.SetRescaleDirtyFlag();
            global.streetGroup.SetRescaleDirtyFlag();
            global.buildingGroup.SetRescaleDirtyFlag();
            global.landscapeGroup.SetRescaleDirtyFlag();
            global.settlerGroup.SetRescaleDirtyFlag();
            global.animalGroup.SetRescaleDirtyFlag();
            global.effectGroup.SetRescaleDirtyFlag();
            return;
        }// end function

        public function GetBuffProductionQueue() : cTimedProductionQueue
        {
            return this.mBuffProductionQueue;
        }// end function

        public function GetStreetObjectFromGridPosition(param1:int) : cStreet
        {
            return this.mStreetDataMap.mIsoMap_list[param1].mStreet;
        }// end function

        public function RemoveDepositIcon(param1:int) : void
        {
            this.mGeneralInterface.mGoSetListAnimationManager.RemoveSingleAnimation(param1);
            return;
        }// end function

        public function Scroll(param1:int, param2:Number) : void
        {
            this.mGeneralInterface.mZoom.Scroll(param1, param2, true);
            return;
        }// end function

        public function IsPositionInsideZoneGridPos(param1:int) : Boolean
        {
            gCalculations.ConvertStreetGridToPixelPos(param1, this.mTempPoint);
            return this.mTempPoint.x > this.mSectorStartX && this.mTempPoint.x < this.mSectorEndX && this.mTempPoint.y > this.mSectorStartY && this.mTempPoint.y < this.mSectorEndY;
        }// end function

        public function MouseMove(event:MouseEvent) : void
        {
            var _loc_2:Number = NaN;
            var _loc_3:Number = NaN;
            var _loc_4:Number = NaN;
            var _loc_5:Number = NaN;
            this.mGeneralInterface.mCurrentCursor.MouseMove(event);
            if (this.mGeneralInterface.mMousePressed)
            {
                if (this.mGeneralInterface.mEnumUIType == UITYPE.EDITOR)
                {
                    if (this.mControlPressed)
                    {
                        this.mMouseMapScrolling = false;
                        this.mGeneralInterface.mSetStreets.MouseClickOnMap(this.mGeneralInterface.mCurrentPlayer, this);
                        this.mGeneralInterface.mSetBuildings.MouseClickOnMap(this.mGeneralInterface.mCurrentPlayer, this);
                    }
                }
                if (this.mMouseMapScrolling)
                {
                    _loc_2 = this.mGeneralInterface.mZoom.Scale(event.stageX, cZoom.DEFAULT_ZOOM);
                    _loc_3 = this.mGeneralInterface.mZoom.Scale(event.stageY, cZoom.DEFAULT_ZOOM);
                    _loc_4 = this.mLastGOCursor.x - _loc_2;
                    _loc_5 = this.mLastGOCursor.y - _loc_3;
                    if (Math.abs(_loc_4) > defines.MAP_SCROLL_ACTIVATE_DELTA || Math.abs(_loc_5) > defines.MAP_SCROLL_ACTIVATE_DELTA)
                    {
                        this.mMapScrolled = true;
                    }
                    this.mMouseDeltaScrollx = this.mMouseDeltaScrollx + _loc_4;
                    this.mMouseDeltaScrolly = this.mMouseDeltaScrolly + _loc_5;
                    this.mLastGOCursor.x = _loc_2;
                    this.mLastGOCursor.y = _loc_3;
                    return;
                }
                if (!this.mMapScrolled)
                {
                    this.mGeneralInterface.mSetStreets.MouseMove(this);
                    this.mGeneralInterface.mSetBuildings.MouseMove(this);
                }
            }
            return;
        }// end function

        public function ZoneSetStartZoom() : void
        {
            var _loc_1:cBuilding = null;
            var _loc_3:cBuilding = null;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:cPosInt = null;
            var _loc_8:int = 0;
            var _loc_9:int = 0;
            var _loc_10:cLandingField = null;
            var _loc_11:cGO = null;
            var _loc_2:* = this.mGeneralInterface.mLastZoomPos[this.mGeneralInterface.mHomePlayer.GetHomeZoneId()];
            if (_loc_2 == null)
            {
                if (this.mGeneralInterface.mHomePlayer.GetHomeZoneId() <= defines.ADVENTUREZONEID)
                {
                    _loc_3 = null;
                    _loc_4 = -1;
                    for each (_loc_1 in this.mStreetDataMap.GetBuildings_vector())
                    {
                        
                        if (_loc_1.GetPlayerID() > 0)
                        {
                            if (_loc_1.GetArmy().GetUnitsCount() > _loc_4)
                            {
                                _loc_3 = _loc_1;
                                _loc_4 = _loc_1.GetArmy().GetUnitsCount();
                            }
                        }
                    }
                    if (_loc_3 != null)
                    {
                        this.ScrollToGrid(_loc_3.GetBuildingGrid());
                    }
                    else
                    {
                        _loc_5 = 0;
                        _loc_6 = 0;
                        _loc_7 = new cPosInt();
                        _loc_9 = 0;
                        while (_loc_9 < 20)
                        {
                            
                            _loc_8 = 0;
                            for each (_loc_10 in this.mStreetDataMap.mLandingFields_vector)
                            {
                                
                                if (_loc_10.mId == _loc_9)
                                {
                                    gCalculations.ConvertStreetGridToPixelPos(_loc_10.mGrid, _loc_7);
                                    _loc_5 = _loc_5 + _loc_7.x;
                                    _loc_6 = _loc_6 + _loc_7.y;
                                    _loc_8++;
                                }
                            }
                            if (_loc_8 != 0)
                            {
                                break;
                            }
                            _loc_9++;
                        }
                        if (_loc_8 == 0)
                        {
                            _loc_5 = 0;
                            _loc_6 = 0;
                            _loc_8 = 0;
                            for each (_loc_11 in this.mStreetDataMap.GetBuildingsAndLandscape_vector())
                            {
                                
                                _loc_5 = _loc_5 + _loc_11.GetX();
                                _loc_6 = _loc_6 + _loc_11.GetY();
                                _loc_8++;
                            }
                        }
                        if (_loc_8 != 0)
                        {
                            _loc_5 = _loc_5 / _loc_8;
                            _loc_6 = _loc_6 / _loc_8;
                            this.mGeneralInterface.mZoom.SetScrollPos(_loc_5, _loc_6);
                        }
                    }
                    this.mGeneralInterface.mZoom.SetScaleFactor(500, true);
                }
                else
                {
                    for each (_loc_1 in this.mStreetDataMap.GetBuildings_vector())
                    {
                        
                        if (_loc_1.GetBuildingName_string() == defines.MAYORHOUSE_NAME_string)
                        {
                            this.ScrollToGrid(_loc_1.GetBuildingGrid());
                            break;
                        }
                    }
                    this.mGeneralInterface.mZoom.SetScaleFactor(500, true);
                }
                _loc_2 = new cMapPos();
                _loc_2.mScrollposX = this.mGeneralInterface.mZoom.GetScrollPosX();
                _loc_2.mScrollposY = this.mGeneralInterface.mZoom.GetScrollPosY();
                _loc_2.mZoomScaleFactor = this.mGeneralInterface.mZoom.GetScaleFactor();
                this.mGeneralInterface.mLastZoomPos[this.mGeneralInterface.mHomePlayer.GetHomeZoneId()] = _loc_2;
            }
            else
            {
                this.mGeneralInterface.mZoom.SetScrollPos(_loc_2.mScrollposX, _loc_2.mScrollposY);
                this.mGeneralInterface.mZoom.SetScaleFactor(_loc_2.mZoomScaleFactor, false);
            }
            return;
        }// end function

    }
}
