package 
{
    import BuffSystem.*;
    import Enums.*;
    import GO.*;
    import GOSets.*;
    import GUI.Loca.*;
    import Interface.*;
    import Map.SubMaps.*;
    import ServerState.*;
    import Specialists.*;
    import __AS3__.vec.*;
    import flash.display.*;
    import flash.events.*;
    import nLib.*;

    public class cCursor extends Object
    {
        private var mCursorGridPos:int = -32767;
        private var mCurrentEnumCursorEditMode:int = 3000;
        private var mCursorSpritePosition:cPosInt;
        public var mLastMousePosition:cPosInt;
        public var mCurrentBuilding:cBuilding = null;
        public var mCurrentSpecialist:cSpecialist = null;
        private var mEnumCursorGridMode:int;
        private var mLastEnumCursorEditMode:int = 3000;
        private var mCursorValidReason:int;
        private var mGeneralInterface:cGeneralInterface;
        public var mCurrentBuff:cBuff = null;
        private var mTempPos:cPosInt;
        private var mVisible:Boolean = true;
        private var mDepositGfx:cGOSetList = null;
        public var mLevelObject_string:String;
        private var mGOCursor:cGO = null;
        public var mLevelEnumObjectType:int = 8;

        public function cCursor(param1:cGeneralInterface)
        {
            this.mLastMousePosition = new cPosInt();
            this.mCursorSpritePosition = new cPosInt();
            this.mCursorValidReason = CURSOR_VALID.ILLEGAL_POS;
            this.mEnumCursorGridMode = CURSOR_GRID_MODE.UNDEFINED;
            this.mTempPos = new cPosInt();
            this.mGeneralInterface = param1;
            return;
        }// end function

        public function SetToLastEditMode() : void
        {
            this.SetCursorEditMode(this.mLastEnumCursorEditMode);
            return;
        }// end function

        private function SetCursorPosition() : void
        {
            if (this.mEnumCursorGridMode == CURSOR_GRID_MODE.SET_STREET)
            {
                this.mGOCursor.SetPosition(this.mCursorSpritePosition.x, this.mCursorSpritePosition.y);
            }
            else if (this.mEnumCursorGridMode == CURSOR_GRID_MODE.SET_FREEPOS)
            {
                this.mGOCursor.SetPosition(this.mCursorSpritePosition.x, this.mCursorSpritePosition.y);
            }
            else if (this.mEnumCursorGridMode == CURSOR_GRID_MODE.SET_BUILDING)
            {
                this.mGOCursor.SetPosition(this.mCursorSpritePosition.x, this.mCursorSpritePosition.y + global.streetGridYHalf);
            }
            else if (this.mEnumCursorGridMode == CURSOR_GRID_MODE.SET_BACKGROUND)
            {
                this.mGOCursor.SetPosition(this.mCursorSpritePosition.x, this.mCursorSpritePosition.y);
            }
            return;
        }// end function

        private function IsStreetCursorType() : Boolean
        {
            return this.mCurrentEnumCursorEditMode == COMMAND.SELECT_BUILDING || this.mCurrentEnumCursorEditMode == COMMAND.ERASE_BUILDING || this.mCurrentEnumCursorEditMode == COMMAND.SET_SECTOR || this.mCurrentEnumCursorEditMode == COMMAND.SET_LANDINGZONE || this.mCurrentEnumCursorEditMode == COMMAND.ERASE_LANDINGZONE || this.mCurrentEnumCursorEditMode == COMMAND.ERASE_DEPOSIT || this.mCurrentEnumCursorEditMode == COMMAND.SET_BLOCKING || this.mCurrentEnumCursorEditMode == COMMAND.ERASE_BLOCKING;
        }// end function

        public function MouseMove(event:MouseEvent) : void
        {
            this.mLastMousePosition.x = event.stageX;
            this.mLastMousePosition.y = event.stageY;
            return;
        }// end function

        public function GetCursorGoObject() : cGO
        {
            return this.mGOCursor;
        }// end function

        public function CheckIfCursorIsPlacableInGame(param1:int) : int
        {
            var _loc_3:cBuilding = null;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:Object = null;
            var _loc_7:int = 0;
            var _loc_2:* = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[param1];
            if (this.mCurrentEnumCursorEditMode == COMMAND.SET_BUILDING_BY_BUFF || this.mCurrentEnumCursorEditMode == COMMAND.SET_BUILDING_IN_GAME || this.mCurrentEnumCursorEditMode == COMMAND.MOVE_BUILDING || this.mCurrentEnumCursorEditMode == COMMAND.BUILD_WAY || this.mCurrentEnumCursorEditMode == COMMAND.BUILD_WAY_SECONDARY)
            {
                _loc_4 = this.mGeneralInterface.mCurrentPlayerZone.mSectorList_vector[_loc_2.mSectorId].GetOwnerPlayerID();
                if (_loc_4 < 0)
                {
                    return CURSOR_VALID.SECTOR_BELONGS_TO_BANDITS;
                }
            }
            if (_loc_2.mFogBorder != 0)
            {
                return CURSOR_VALID.PLACE_IS_COVERED_WITH_FOG;
            }
            if (this.IsInSetBuildingMode())
            {
            }
            _loc_5 = this.mGeneralInterface.mCurrentPlayerZone.IsBuildingPlacableGridPosition(this.mGOCursor, this.mGeneralInterface.mCurrentPlayer, param1);
            if (_loc_5 != 0)
            {
            }
            ;
            
            return CURSOR_VALID.BUILDING_PLACED_PLACE_IS_COVERED_WITH_FOG;
        }// end function

        public function SetCursorVisible(param1:Boolean) : void
        {
            this.mVisible = param1;
            return;
        }// end function

        public function IsCursorValid() : Boolean
        {
            return this.mCursorValidReason == CURSOR_VALID.OK;
        }// end function

        public function SetCursorGfx(param1:int, param2:String) : void
        {
            this.mGOCursor = cGO.CreateGoFromLevelObject(this.mGeneralInterface.mCurrentPlayer, param1, param2, this.mGeneralInterface);
            return;
        }// end function

        public function GetEditMode() : int
        {
            return this.mCurrentEnumCursorEditMode;
        }// end function

        public function SetCursorEditMode(param1:int) : void
        {
            this.SetCursorEditModeObjectName(param1, null);
            return;
        }// end function

        public function CheckIfGarrisonIsPlacableInGame(param1:int) : int
        {
            var _loc_3:int = 0;
            var _loc_4:cBuilding = null;
            var _loc_2:* = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[param1];
            if (_loc_2.mFogBorder != 0)
            {
                return CURSOR_VALID.PLACE_IS_COVERED_WITH_FOG;
            }
            if (this.mCurrentEnumCursorEditMode == COMMAND.MOVE_GARISSON)
            {
            }
            _loc_3 = this.mGeneralInterface.mCurrentPlayerZone.IsBuildingPlacableGridPosition(this.mGOCursor, this.mGeneralInterface.mCurrentPlayer, param1);
            if (_loc_3 != 0)
            {
            }
            ;
            
            return CURSOR_VALID.BUILDING_PLACED_PLACE_IS_COVERED_WITH_FOG;
        }// end function

        public function IsACursorGoSubType() : Boolean
        {
            return this.mGOCursor.GetGOContainer().mEnumGoSubType == GO_SUBTYPE.CURSOR;
        }// end function

        public function Init() : void
        {
            this.mCursorGridPos = defines.ILLEGAL_INT_POS;
            this.mCursorValidReason = CURSOR_VALID.ILLEGAL_POS;
            return;
        }// end function

        private function ConvertMouseToCursorPos() : void
        {
            this.mCursorSpritePosition.x = this.mLastMousePosition.x;
            this.mCursorSpritePosition.y = this.mLastMousePosition.y;
            this.ConvertScreenPosToMapPos(this.mCursorSpritePosition);
            this.SetCursorPosition();
            return;
        }// end function

        public function RenderUnderBuildings() : void
        {
            return;
        }// end function

        public function SetCursor(param1:int, param2:String) : void
        {
            var _loc_3:cGOSetListController = null;
            var _loc_4:cXML = null;
            var _loc_5:Vector.<cXML> = null;
            var _loc_6:cXML = null;
            var _loc_7:String = null;
            this.mLevelEnumObjectType = param1;
            this.mLevelObject_string = param2;
            this.SetCursorGfx(param1, param2);
            this.mCursorGridPos = defines.ILLEGAL_INT_POS;
            this.mCursorValidReason = CURSOR_VALID.ILLEGAL_POS;
            this.ConvertMouseToCursorPos();
            if (param1 == OBJECTTYPE.DEPOSIT)
            {
                this.mDepositGfx = null;
                _loc_3 = new cGOSetListControllerPercentage(100);
                _loc_4 = global.gfxSettingsRootXML.MoveToSubNode("GameObjects").MoveToSubNode("Deposits");
                _loc_5 = _loc_4.CreateChildrenArray();
                for each (_loc_6 in _loc_5)
                {
                    
                    if (globalFlash.gui.tileListGo.mLastLevelObjectString_string == _loc_6.GetAttributeString_string("name"))
                    {
                        _loc_7 = _loc_6.GetAttributeString_string("gosetlist");
                        this.mDepositGfx = cGOSetManager.CreateGOSetList(_loc_7, _loc_3);
                        this.mDepositGfx.SetValue(100);
                        break;
                    }
                }
            }
            if (this.IsInCursorInfoMode())
            {
                this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.InitRenderCursorInfo();
            }
            return;
        }// end function

        public function GetCursorYPixelPos() : int
        {
            return this.mCursorSpritePosition.y;
        }// end function

        private function SetCursorEditModeObjectNameLocal(param1:int, param2:String) : void
        {
            var _loc_3:dResourceCreationDefinition = null;
            var _loc_4:cBuilding = null;
            var _loc_5:int = 0;
            var _loc_6:cBuilding = null;
            var _loc_7:int = 0;
            this.mLastEnumCursorEditMode = this.mCurrentEnumCursorEditMode;
            this.mGeneralInterface.mCurrentPlayerZone.mShowDeposit = false;
            if (this.mGeneralInterface.mEnumUIType == UITYPE.EDITOR)
            {
            }
            if (param1 == COMMAND.SET_BACKGROUND)
            {
            }
            if (this.mCurrentEnumCursorEditMode != COMMAND.SET_BACKGROUND)
            {
                globalFlash.gui.tileListGo.Show();
                this.mGeneralInterface.UnselectBuilding();
                this.mCurrentEnumCursorEditMode = COMMAND.SET_BACKGROUND;
                this.mEnumCursorGridMode = CURSOR_GRID_MODE.SET_BACKGROUND;
                globalFlash.gui.tileListGo.SetData();
                if (this.mLevelEnumObjectType != OBJECTTYPE.BACKGROUND || this.IsACursorGoSubType())
                {
                    this.SetCursor(OBJECTTYPE.BACKGROUND, "P1");
                }
            }
            return;
        }// end function

        public function GetCursorXPixelPos() : int
        {
            return this.mCursorSpritePosition.x;
        }// end function

        private function RenderCursor() : void
        {
            var _loc_1:int = 0;
            var _loc_3:cGO = null;
            var _loc_2:* = new cPosInt();
            if (this.mGOCursor == null)
            {
                return;
            }
            if (this.IsPlayerMapGridType() && this.mVisible)
            {
                if (this.IsStreetCursorType())
                {
                    _loc_3 = this.mGeneralInterface.mStreetCursorRed;
                    if (this.mCursorValidReason == CURSOR_VALID.OK)
                    {
                        _loc_3 = this.mGeneralInterface.mStreetCursorGreen;
                    }
                    if (this.mGeneralInterface.mEnumUIType != UITYPE.EDITOR)
                    {
                        return;
                    }
                }
                if (!(this.mCurrentEnumCursorEditMode == COMMAND.SET_SECTOR || this.mCurrentEnumCursorEditMode == COMMAND.SET_LANDINGZONE || this.mCurrentEnumCursorEditMode == COMMAND.ERASE_LANDINGZONE || this.mCurrentEnumCursorEditMode == COMMAND.SET_BLOCKING || this.mCurrentEnumCursorEditMode == COMMAND.ERASE_BLOCKING || this.mCurrentEnumCursorEditMode == COMMAND.APPLY_BUFF))
                {
                    if (this.mCursorValidReason == CURSOR_VALID.OK)
                    {
                        this.mGOCursor.RenderCursorTypeXY(int(this.mGOCursor.GetX()), int(this.mGOCursor.GetY()), CURSOR_RENDERMODE.PLACABLE);
                    }
                    else
                    {
                        this.mGOCursor.RenderCursorTypeXY(int(this.mGOCursor.GetX()), int(this.mGOCursor.GetY()), CURSOR_RENDERMODE.UNPLACABLE);
                    }
                }
            }
            if (this.mCurrentEnumCursorEditMode == COMMAND.SET_DEPOSIT)
            {
                if (this.mDepositGfx != null)
                {
                    this.mDepositGfx.Render(int(this.mGOCursor.GetX()), int(this.mGOCursor.GetY()));
                }
            }
            return;
        }// end function

        public function ConvertScreenPosToMapPos(param1:cPosInt) : void
        {
            var _loc_2:Number = NaN;
            var _loc_3:Number = NaN;
            var _loc_4:Number = NaN;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            if (this.mGOCursor == null)
            {
                return;
            }
            if (this.mGOCursor.mSprite.GetContainer().IsStreamingActiveIfNotActivate(this.mGOCursor.mSprite.GetSubType(), int(this.mGOCursor.mSprite.GetAnimFrame())))
            {
                return;
            }
            this.mGOCursor.mSprite.GetContainer().Rescale(this.mGOCursor.mSprite.GetSubType(), int(this.mGOCursor.mSprite.GetAnimFrame()));
            _loc_2 = this.mGOCursor.mSprite.GetContainer().mOriginalScaleFactor;
            if (this.mEnumCursorGridMode == CURSOR_GRID_MODE.SET_BUILDING || this.mEnumCursorGridMode == CURSOR_GRID_MODE.SET_FREEPOS || this.mEnumCursorGridMode == CURSOR_GRID_MODE.SET_STREET)
            {
                _loc_4 = global.streetGridYHalf * cZoom.DEFAULT_ZOOM / _loc_2;
                _loc_5 = int(_loc_4);
                param1.y = param1.y + int(this.mGeneralInterface.mZoom.InvScale(_loc_5, cZoom.DEFAULT_ZOOM));
            }
            else
            {
                _loc_4 = cBackgroundRectangleDataMap.RECTANGLE_ELEMENT_HEIGHT * cZoom.DEFAULT_ZOOM / _loc_2;
                _loc_5 = int(_loc_4);
                param1.y = param1.y + int(this.mGeneralInterface.mZoom.InvScale(_loc_5, cZoom.DEFAULT_ZOOM));
                _loc_4 = cBackgroundRectangleDataMap.RECTANGLE_ELEMENT_WIDTH / 2 * cZoom.DEFAULT_ZOOM / _loc_2;
                _loc_5 = int(_loc_4);
                param1.x = param1.x + int(this.mGeneralInterface.mZoom.InvScale(_loc_5, cZoom.DEFAULT_ZOOM));
            }
            this.mGeneralInterface.mZoom.InvCalculateScrollPos(param1);
            if (this.mEnumCursorGridMode == CURSOR_GRID_MODE.SET_BUILDING)
            {
                gCalculations.RestrictPixelPosToStreetGrid(param1);
            }
            else if (this.mEnumCursorGridMode == CURSOR_GRID_MODE.SET_STREET)
            {
                gCalculations.RestrictPixelPosToStreetGrid(param1);
            }
            else if (this.mEnumCursorGridMode == CURSOR_GRID_MODE.SET_BACKGROUND)
            {
                _loc_6 = this.mGeneralInterface.mCurrentPlayerZone.mBackgroundDataMap.ConvertPixelPosToGrid(param1.x, param1.y);
                param1.x = this.mGeneralInterface.mCurrentPlayerZone.mBackgroundDataMap.ConvertGridToXPos(_loc_6);
                param1.y = this.mGeneralInterface.mCurrentPlayerZone.mBackgroundDataMap.ConvertGridToYPos(_loc_6);
            }
            return;
        }// end function

        public function SetPosition(param1:int, param2:int) : void
        {
            this.mCursorSpritePosition.x = param1;
            this.mCursorSpritePosition.y = param2;
            if (this.mGOCursor == null)
            {
                return;
            }
            this.mCursorGridPos = defines.ILLEGAL_INT_POS;
            this.mCursorValidReason = CURSOR_VALID.OK;
            this.SetCursorPosition();
            if (this.mEnumCursorGridMode == CURSOR_GRID_MODE.SET_STREET || this.mEnumCursorGridMode == CURSOR_GRID_MODE.SET_BUILDING)
            {
                this.mCursorGridPos = gCalculations.ConvertPixelPosToStreetGridPos(this.mCursorSpritePosition.x, this.mCursorSpritePosition.y);
            }
            else if (this.mEnumCursorGridMode == CURSOR_GRID_MODE.SET_BACKGROUND)
            {
                this.mCursorGridPos = this.mGeneralInterface.mCurrentPlayerZone.mBackgroundDataMap.ConvertPixelPosToGrid(this.mCursorSpritePosition.x, this.mCursorSpritePosition.y);
            }
            if (this.mCursorGridPos == defines.ILLEGAL_INT_POS)
            {
                this.mCursorValidReason = CURSOR_VALID.ILLEGAL_POS;
                return;
            }
            if (this.mCursorValidReason == CURSOR_VALID.OK)
            {
                this.mCursorValidReason = this.CheckIfCursorIsPlacableInGame(this.mCursorGridPos);
            }
            return;
        }// end function

        public function RenderCursorDebugInfo() : void
        {
            this.mGeneralInterface.mCurrentPlayerZone.RenderText(cBackbuffer.mBackBuffer, "g: " + this.mCursorGridPos, this.mCursorSpritePosition.x, this.mCursorSpritePosition.y);
            return;
        }// end function

        public function IsInCursorInfoMode() : Boolean
        {
            return this.mCurrentEnumCursorEditMode == COMMAND.MOVE_GARISSON || this.mCurrentEnumCursorEditMode == COMMAND.ATTACK_BUILDING;
        }// end function

        public function IsSelectionCursor() : Boolean
        {
            return this.mGOCursor.GetGOContainer().mEnumGoSubType == GO_SUBTYPE.CURSOR;
        }// end function

        private function LightGoObject(param1:Boolean, param2:Boolean) : void
        {
            var _loc_3:cBuilding = null;
            var _loc_4:cLandscape = null;
            if (this.mCursorValidReason != CURSOR_VALID.OK)
            {
                return;
            }
            if (param1)
            {
                _loc_3 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[this.mCursorGridPos].mBuilding;
                if (_loc_3 != null)
                {
                    if (_loc_3.GetBuildingMode() >= cBuilding.BUILDING_MODE_BUILDING_IS_ACTIVE_MIN || this.mGeneralInterface.mEnumUIType == UITYPE.EDITOR)
                    {
                        _loc_3.RenderTransform(_loc_3.GetXInt(), _loc_3.GetYInt(), BlendMode.MULTIPLY, 1, 1, 0);
                        _loc_3.RenderTransform(_loc_3.GetXInt(), _loc_3.GetYInt(), BlendMode.ADD, 1, 1, 0);
                    }
                }
            }
            if (param2)
            {
                _loc_4 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[this.mCursorGridPos].mLandscape;
                if (_loc_4 != null)
                {
                    _loc_4.RenderTransform(_loc_4.GetXInt(), _loc_4.GetYInt(), BlendMode.ADD, 1, 1, 0);
                }
            }
            return;
        }// end function

        private function IsPlayerMapGridType() : Boolean
        {
            return this.mEnumCursorGridMode != CURSOR_GRID_MODE.UNDEFINED;
        }// end function

        public function GetGridPosition() : int
        {
            return this.mCursorGridPos;
        }// end function

        private function ShowCursorBlockedInfo(param1:int, param2:int, param3:int) : void
        {
            return;
        }// end function

        public function IsInSetBuildingMode() : Boolean
        {
            return this.mCurrentEnumCursorEditMode == COMMAND.SET_BUILDING_IN_GAME || this.mCurrentEnumCursorEditMode == COMMAND.SET_BUILDING_BY_BUFF || this.mCurrentEnumCursorEditMode == COMMAND.SET_BUILDING_IN_EDITOR || this.mCurrentEnumCursorEditMode == COMMAND.ADD_DEPOSIT_ANIM || this.mCurrentEnumCursorEditMode == COMMAND.MOVE_BUILDING || this.mCurrentEnumCursorEditMode == COMMAND.MOVE_GARISSON;
        }// end function

        public function SetCursorSpritePosition(param1:int, param2:int) : void
        {
            this.mCursorSpritePosition.x = param1;
            this.mCursorSpritePosition.y = param2;
            return;
        }// end function

        public function SetCursorGfxWithUpgradeLevel(param1:int, param2:String, param3:int) : void
        {
            var _loc_5:cBuilding = null;
            var _loc_4:* = cGO.CreateGoFromLevelObject(this.mGeneralInterface.mCurrentPlayer, param1, param2, this.mGeneralInterface);
            if (param1 == OBJECTTYPE.BUILDING)
            {
                _loc_5 = _loc_4 as cBuilding;
                _loc_5.SetUpgradeLevel(param3);
                if (_loc_5.mSprite.GetContainer().mNofStreamUpgrades != 0)
                {
                    _loc_5.SetSubType(gCalculations.CalculateGFXUpgradeLevel(param3, (_loc_5.mSprite.GetContainer().mNofStreamUpgrades - 1)));
                }
                else
                {
                    _loc_5.SetSubType(gCalculations.CalculateGFXUpgradeLevel(param3, (_loc_5.GetNofSubTypes() - 1)));
                }
            }
            this.mGOCursor = _loc_4;
            return;
        }// end function

        public function SetGridPosition(param1:int) : void
        {
            this.mCursorGridPos = param1;
            return;
        }// end function

        public function SetCursorEditModeObjectName(param1:int, param2:String) : void
        {
            this.SetCursorEditModeObjectNameLocal(param1, param2);
            return;
        }// end function

        public function IsInSetStreetMode() : Boolean
        {
            return this.mCurrentEnumCursorEditMode == COMMAND.BUILD_WAY || this.mCurrentEnumCursorEditMode == COMMAND.BUILD_WAY_SECONDARY || this.mCurrentEnumCursorEditMode == COMMAND.ERASE_WAY;
        }// end function

        public function PostRender() : void
        {
            var _loc_1:cBuilding = null;
            var _loc_2:cDeposit = null;
            var _loc_3:cIsoElement = null;
            var _loc_4:String = null;
            var _loc_5:String = null;
            var _loc_6:String = null;
            var _loc_7:Boolean = false;
            var _loc_8:int = 0;
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            this.ConvertMouseToCursorPos();
            this.SetPosition(this.mCursorSpritePosition.x, this.mCursorSpritePosition.y);
            this.RenderCursor();
            if (this.mGeneralInterface.mEnumUIType == UITYPE.GAME)
            {
                if (this.mCurrentEnumCursorEditMode == COMMAND.SELECT_BUILDING || this.mCurrentEnumCursorEditMode == COMMAND.APPLY_BUFF)
                {
                    if (this.mCursorValidReason == CURSOR_VALID.OK)
                    {
                        _loc_1 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[this.mCursorGridPos].mBuilding;
                        if (_loc_1 == null)
                        {
                            _loc_1 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.CheckIfBuildingIsSouthSouthEastAndSouthWest(this.mCursorGridPos);
                        }
                        if (_loc_1 != null)
                        {
                            if (_loc_1.GetPlayerID() != 0)
                            {
                                if (_loc_1.mIsSelectable)
                                {
                                    if (_loc_1.GetUpgradeLevelBonusesForLevel(2) != null)
                                    {
                                        _loc_1.RenderUpgradeLevelAndPlayerColor();
                                    }
                                    if (this.mGeneralInterface.mHomePlayer.GetPlayerId() <= defines.ADVENTUREZONEID && _loc_1.GetPlayerID() > 0 && _loc_1.GetGOContainer().mMaxUnits > 0)
                                    {
                                        _loc_1.RenderPlayerName();
                                    }
                                    else
                                    {
                                        _loc_1.RenderBuildingName();
                                    }
                                }
                            }
                        }
                    }
                    if (this.mCursorGridPos != defines.ILLEGAL_INT_POS)
                    {
                        _loc_2 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[this.mCursorGridPos].mDeposit;
                        if (_loc_2 == null)
                        {
                            _loc_3 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[this.mCursorGridPos];
                            if (_loc_3.mBlockedIsoElementSource != null)
                            {
                                _loc_2 = _loc_3.mBlockedIsoElementSource.mDeposit as cDeposit;
                            }
                        }
                        if (_loc_2 != null && _loc_2.GetName_string() != null)
                        {
                            if (!global.hideMouseOverDepositAmount_dictionary.Contains(_loc_2.GetName_string()))
                            {
                                _loc_4 = _loc_2.GetContainerName_string();
                                _loc_5 = gMisc.GetSubString_string(_loc_4, 7, _loc_4.length - 7);
                                _loc_6 = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, _loc_5);
                                _loc_7 = true;
                                _loc_8 = -(global.streetGridY - 24);
                                _loc_9 = int(_loc_2.GetX());
                                _loc_10 = int(_loc_2.GetY());
                                if (_loc_2.GetAccessibleType() == DEPOSIT_ACCESSIBLE_TYPES.ACCESSIBLE)
                                {
                                    _loc_2.RenderPos(_loc_9, _loc_10);
                                    if (_loc_7)
                                    {
                                        this.mGeneralInterface.mCurrentPlayerZone.RenderTextCenter(cBackbuffer.mBackBuffer, gMisc.ConvertDoubleToString_string(_loc_2.GetAmount()) + " " + _loc_6, _loc_9, _loc_10 + _loc_8);
                                    }
                                }
                                else
                                {
                                    _loc_2.RenderTransform(_loc_9, _loc_10, BlendMode.DARKEN, 1, 1, 0);
                                    if (_loc_7)
                                    {
                                        this.mGeneralInterface.mCurrentPlayerZone.RenderTextCenter(cBackbuffer.mBackBuffer, "[" + gMisc.ConvertDoubleToString_string(_loc_2.GetAmount()) + " " + _loc_6 + " in Group: " + _loc_2.GetDepositGroupID() + "]", _loc_9, _loc_10 + _loc_8);
                                    }
                                }
                            }
                        }
                    }
                }
                else if (this.mCurrentEnumCursorEditMode == COMMAND.ATTACK_BUILDING)
                {
                    if (this.mCursorValidReason == CURSOR_VALID.OK)
                    {
                        this.mGOCursor.RenderCursorTypeXY(this.mCursorSpritePosition.x, this.mCursorSpritePosition.y, CURSOR_RENDERMODE.PLACABLE);
                    }
                    else
                    {
                        this.mGOCursor.RenderCursorTypeXY(this.mCursorSpritePosition.x, this.mCursorSpritePosition.y, CURSOR_RENDERMODE.UNPLACABLE);
                    }
                }
                if (this.mCurrentEnumCursorEditMode == COMMAND.SET_BUILDING_IN_GAME || this.mCurrentEnumCursorEditMode == COMMAND.SET_BUILDING_BY_BUFF || this.mCurrentEnumCursorEditMode == COMMAND.ATTACK_BUILDING || this.mCurrentEnumCursorEditMode == COMMAND.MOVE_GARISSON || this.mCurrentEnumCursorEditMode == COMMAND.BUILD_WAY || this.mCurrentEnumCursorEditMode == COMMAND.BUILD_WAY_SECONDARY || this.mCurrentEnumCursorEditMode == COMMAND.APPLY_BUFF || this.mCurrentEnumCursorEditMode == COMMAND.MOVE_BUILDING)
                {
                    if (this.mCursorValidReason != CURSOR_VALID.OK)
                    {
                        this.ShowCursorBlockedInfo(this.mCursorValidReason, this.mCursorSpritePosition.x, this.mCursorSpritePosition.y);
                    }
                }
            }
            else if (this.mCurrentEnumCursorEditMode == COMMAND.SET_BUILDING_IN_EDITOR || this.mCurrentEnumCursorEditMode == COMMAND.ERASE_BUILDING || this.mCurrentEnumCursorEditMode == COMMAND.SELECT_BUILDING)
            {
                if (this.mCursorValidReason != CURSOR_VALID.OK)
                {
                }
            }
            if (this.mCurrentEnumCursorEditMode == COMMAND.APPLY_BUFF)
            {
                if (this.mCursorValidReason == CURSOR_VALID.OK)
                {
                    this.mGOCursor.RenderCursorTypeXY(int(this.mGOCursor.GetX()), int(this.mGOCursor.GetY()), CURSOR_RENDERMODE.PLACABLE);
                }
                else
                {
                    this.mGOCursor.RenderCursorTypeXY(int(this.mGOCursor.GetX()), int(this.mGOCursor.GetY()), CURSOR_RENDERMODE.UNPLACABLE);
                }
                if (this.mCurrentBuff != null)
                {
                    if (this.mCurrentBuff.GetCount() > 0)
                    {
                        gGfxResource.mUpgradeLevelNumbers.SetSubType(this.mCurrentBuff.GetCount());
                        gGfxResource.mUpgradeLevelNumbers.RenderPos(this.mCursorSpritePosition.x + 31, this.mCursorSpritePosition.y - 23);
                    }
                }
            }
            return;
        }// end function

    }
}
