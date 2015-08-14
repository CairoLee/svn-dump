package Map.SubMaps
{
    import Enums.*;
    import GO.*;
    import Interface.*;
    import __AS3__.vec.*;
    import nLib.*;

    public class cBackgroundRectangleDataMap extends Object
    {
        protected var mGeneralInterface:cGeneralInterface;
        protected var mTempClippingRectangle:cClippingRectangle;
        public var mMap_list:Vector.<cGO>;
        private var mStreetGridMap_list:Vector.<int>;
        public static const RECTANGLE_ELEMENT_HEIGHT:int = 144;
        public static const RECTANGLE_ELEMENT_WIDTH:int = 234;

        public function cBackgroundRectangleDataMap(param1:cGeneralInterface)
        {
            this.mMap_list = new Vector.<cGO>(defines.RECTANGLE_MAP_SIZE);
            this.mStreetGridMap_list = new Vector.<int>(defines.RECTANGLE_MAP_SIZE);
            this.mTempClippingRectangle = new cClippingRectangle();
            this.mGeneralInterface = param1;
            return;
        }// end function

        public function UpdatePositions() : void
        {
            var _loc_6:int = 0;
            var _loc_1:int = 0;
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            while (_loc_5 < defines.RECTANGLE_MAP_HEIGHT)
            {
                
                _loc_1 = _loc_4;
                _loc_6 = 0;
                while (_loc_6 < defines.RECTANGLE_MAP_WIDTH)
                {
                    
                    if (this.mMap_list[_loc_3] != null)
                    {
                        this.mMap_list[_loc_3].SetPosition(_loc_1, _loc_2);
                    }
                    _loc_1 = _loc_1 + RECTANGLE_ELEMENT_WIDTH;
                    _loc_3++;
                    _loc_6++;
                }
                _loc_2 = _loc_2 + RECTANGLE_ELEMENT_HEIGHT;
                _loc_5++;
            }
            this.mGeneralInterface.mCurrentPlayerZone.SetBackgroundHasChanged(true);
            return;
        }// end function

        public function FillWithPattern() : void
        {
            var _loc_1:int = 0;
            while (_loc_1 < defines.RECTANGLE_MAP_SIZE)
            {
                
                this.mMap_list[_loc_1] = cBackground.CreateFromString("P1", this.mGeneralInterface);
                _loc_1++;
            }
            this.UpdatePositions();
            return;
        }// end function

        public function SetGridPos(param1:cGO, param2:int) : Boolean
        {
            var _loc_3:Boolean = false;
            var _loc_4:* = this.ConvertGridToXPos(param2);
            var _loc_5:* = this.ConvertGridToYPos(param2);
            param1.SetPosition(_loc_4, _loc_5);
            if (param2 != defines.ILLEGAL_INT_POS)
            {
                this.mMap_list[param2] = param1;
                _loc_3 = true;
            }
            return _loc_3;
        }// end function

        public function RenderWaterBorder(param1:int) : void
        {
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            var _loc_8:int = 0;
            var _loc_10:int = 0;
            _loc_4 = this.mGeneralInterface.mZoom.Scale(-global.screenWidthHalf, cZoom.DEFAULT_ZOOM);
            _loc_5 = int(_loc_4) + this.mGeneralInterface.mZoom.GetScrollPosXInt();
            _loc_4 = this.mGeneralInterface.mZoom.Scale(-global.screenHeightHalf, cZoom.DEFAULT_ZOOM);
            _loc_6 = int(_loc_4) + this.mGeneralInterface.mZoom.GetScrollPosYInt();
            _loc_4 = this.mGeneralInterface.mZoom.Scale(global.screenWidthHalf, cZoom.DEFAULT_ZOOM);
            _loc_7 = int(_loc_4) + this.mGeneralInterface.mZoom.GetScrollPosXInt();
            _loc_4 = this.mGeneralInterface.mZoom.Scale(global.screenHeightHalf, cZoom.DEFAULT_ZOOM);
            _loc_8 = int(_loc_4) + this.mGeneralInterface.mZoom.GetScrollPosYInt();
            _loc_5 = _loc_5 / RECTANGLE_ELEMENT_WIDTH;
            _loc_6 = _loc_6 / RECTANGLE_ELEMENT_HEIGHT;
            _loc_7 = _loc_7 / RECTANGLE_ELEMENT_WIDTH;
            _loc_8 = _loc_8 / RECTANGLE_ELEMENT_HEIGHT;
            _loc_5 = _loc_5 - 1;
            _loc_7 = _loc_7 + 1;
            _loc_8 = _loc_8 + 3;
            var _loc_9:* = _loc_5 * RECTANGLE_ELEMENT_WIDTH;
            var _loc_11:* = _loc_6 * RECTANGLE_ELEMENT_HEIGHT;
            _loc_3 = _loc_6;
            while (_loc_3 <= _loc_8)
            {
                
                _loc_10 = _loc_9;
                _loc_2 = _loc_5;
                while (_loc_2 <= _loc_7)
                {
                    
                    if (_loc_2 < 0 || _loc_2 >= defines.RECTANGLE_MAP_WIDTH || _loc_3 < 0 || _loc_3 >= defines.RECTANGLE_MAP_HEIGHT)
                    {
                        gGfxResource.mWaterTile.mSprite.RenderPos(_loc_10, _loc_11);
                    }
                    _loc_10 = _loc_10 + RECTANGLE_ELEMENT_WIDTH;
                    _loc_2++;
                }
                _loc_11 = _loc_11 + RECTANGLE_ELEMENT_HEIGHT;
                _loc_3++;
            }
            return;
        }// end function

        public function ConvertGridToYPos(param1:int) : int
        {
            return int(param1 / defines.RECTANGLE_MAP_WIDTH) * RECTANGLE_ELEMENT_HEIGHT;
        }// end function

        public function RenderGrid(param1:int) : void
        {
            var _loc_2:cGO = null;
            var _loc_8:int = 0;
            var _loc_9:int = 0;
            this.CalculateMapClipping(param1, this.mTempClippingRectangle);
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:* = this.mTempClippingRectangle.minX;
            var _loc_7:* = this.mTempClippingRectangle.minY;
            while (_loc_7 <= this.mTempClippingRectangle.maxY)
            {
                
                _loc_8 = _loc_6 + _loc_7 * defines.RECTANGLE_MAP_WIDTH;
                _loc_9 = this.mTempClippingRectangle.minX;
                while (_loc_9 <= this.mTempClippingRectangle.maxX)
                {
                    
                    if (this.mMap_list[_loc_8] != null)
                    {
                        _loc_3 = this.ConvertGridToXPos(_loc_8);
                        _loc_4 = this.ConvertGridToYPos(_loc_8);
                        this.mGeneralInterface.mBackgroundCursorRed.SetPosition(_loc_3, _loc_4);
                        this.mGeneralInterface.mBackgroundCursorRed.Render();
                    }
                    _loc_8++;
                    _loc_9++;
                }
                _loc_7++;
            }
            return;
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
                _loc_3 = _loc_3 / RECTANGLE_ELEMENT_WIDTH;
                _loc_4 = _loc_4 / RECTANGLE_ELEMENT_HEIGHT;
                _loc_5 = _loc_5 / RECTANGLE_ELEMENT_WIDTH;
                _loc_6 = _loc_6 / RECTANGLE_ELEMENT_HEIGHT;
                _loc_5 = _loc_5 + 1;
                _loc_6 = _loc_6 + 3;
                if (_loc_3 < defines.RECTANGLE_MAP_MIN_USABLE_AREA_X)
                {
                    _loc_3 = defines.RECTANGLE_MAP_MIN_USABLE_AREA_X;
                }
                if (_loc_4 < defines.RECTANGLE_MAP_MIN_USABLE_AREA_Y)
                {
                    _loc_4 = defines.RECTANGLE_MAP_MIN_USABLE_AREA_Y;
                }
                if (_loc_5 > defines.RECTANGLE_MAP_MAX_USABLE_AREA_X)
                {
                    _loc_5 = defines.RECTANGLE_MAP_MAX_USABLE_AREA_X;
                }
                if (_loc_6 > defines.RECTANGLE_MAP_MAX_USABLE_AREA_Y)
                {
                    _loc_6 = defines.RECTANGLE_MAP_MAX_USABLE_AREA_Y;
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
                _loc_3 = _loc_3 / RECTANGLE_ELEMENT_WIDTH;
                _loc_4 = _loc_4 / RECTANGLE_ELEMENT_HEIGHT;
                _loc_5 = _loc_5 / RECTANGLE_ELEMENT_WIDTH;
                _loc_6 = _loc_6 / RECTANGLE_ELEMENT_HEIGHT;
                _loc_5 = _loc_5 + 1;
                _loc_6 = _loc_6 + 1;
                if (_loc_3 < defines.RECTANGLE_MAP_MIN_USABLE_AREA_X)
                {
                    _loc_3 = defines.RECTANGLE_MAP_MIN_USABLE_AREA_X;
                }
                if (_loc_4 < defines.RECTANGLE_MAP_MIN_USABLE_AREA_Y)
                {
                    _loc_4 = defines.RECTANGLE_MAP_MIN_USABLE_AREA_Y;
                }
                if (_loc_5 > defines.RECTANGLE_MAP_MAX_USABLE_AREA_X)
                {
                    _loc_5 = defines.RECTANGLE_MAP_MAX_USABLE_AREA_X;
                }
                if (_loc_6 > defines.RECTANGLE_MAP_MAX_USABLE_AREA_Y)
                {
                    _loc_6 = defines.RECTANGLE_MAP_MAX_USABLE_AREA_Y;
                }
            }
            else
            {
                _loc_3 = defines.RECTANGLE_MAP_MIN_USABLE_AREA_X;
                _loc_4 = defines.RECTANGLE_MAP_MIN_USABLE_AREA_Y;
                _loc_5 = defines.RECTANGLE_MAP_MAX_USABLE_AREA_X;
                _loc_6 = defines.RECTANGLE_MAP_MAX_USABLE_AREA_Y;
            }
            param2.minX = _loc_3;
            param2.minY = _loc_4;
            param2.maxX = _loc_5;
            param2.maxY = _loc_6;
            return;
        }// end function

        public function ConvertPixelPosToGrid(param1:int, param2:int) : int
        {
            var _loc_3:* = param1 / RECTANGLE_ELEMENT_WIDTH;
            var _loc_4:* = param2 / RECTANGLE_ELEMENT_HEIGHT;
            if (!this.IsGridPosUsable(_loc_3, _loc_4))
            {
                return defines.ILLEGAL_INT_POS;
            }
            var _loc_5:* = _loc_3 + _loc_4 * defines.RECTANGLE_MAP_WIDTH;
            return _loc_3 + _loc_4 * defines.RECTANGLE_MAP_WIDTH;
        }// end function

        public function Remove(param1:int, param2:int) : Boolean
        {
            var _loc_5:cGO = null;
            var _loc_3:Boolean = false;
            var _loc_4:* = this.ConvertPixelPosToGrid(param1, param2);
            if (this.ConvertPixelPosToGrid(param1, param2) != defines.ILLEGAL_INT_POS)
            {
                if (this.mMap_list[_loc_4] != null)
                {
                    _loc_5 = this.mMap_list[_loc_4];
                    this.mMap_list[_loc_4] = null;
                    _loc_3 = true;
                }
            }
            return _loc_3;
        }// end function

        public function RemoveGridPos(param1:int) : Boolean
        {
            var _loc_3:cGO = null;
            var _loc_2:Boolean = false;
            if (param1 != defines.ILLEGAL_INT_POS)
            {
                if (this.mMap_list[param1] != null)
                {
                    _loc_3 = this.mMap_list[param1];
                    this.mMap_list[param1] = null;
                    _loc_2 = true;
                }
            }
            return _loc_2;
        }// end function

        public function IsGridPosUsable(param1:int, param2:int) : Boolean
        {
            return !(param1 < defines.RECTANGLE_MAP_MIN_USABLE_AREA_X || param1 > defines.RECTANGLE_MAP_MAX_USABLE_AREA_X || param2 < defines.RECTANGLE_MAP_MIN_USABLE_AREA_Y || param2 > defines.RECTANGLE_MAP_MAX_USABLE_AREA_Y);
        }// end function

        public function Clear() : void
        {
            var _loc_1:int = 0;
            while (_loc_1 < defines.RECTANGLE_MAP_SIZE)
            {
                
                this.mMap_list[_loc_1] = null;
                _loc_1++;
            }
            return;
        }// end function

        public function ConvertGridToXPos(param1:int) : int
        {
            return param1 % defines.RECTANGLE_MAP_WIDTH * RECTANGLE_ELEMENT_WIDTH;
        }// end function

        public function GridCallBack(param1:Function, param2:int, param3:Boolean) : void
        {
            return;
        }// end function

        public function Render(param1:int) : void
        {
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            var _loc_8:cGO = null;
            var _loc_12:int = 0;
            this.CalculateMapClipping(param1, this.mTempClippingRectangle);
            var _loc_4:* = this.mTempClippingRectangle.minX;
            var _loc_5:* = this.mTempClippingRectangle.minY;
            var _loc_6:* = this.mTempClippingRectangle.maxX;
            var _loc_7:* = this.mTempClippingRectangle.maxY;
            var _loc_9:* = this.mTempClippingRectangle.minX;
            var _loc_10:int = 0;
            var _loc_11:* = _loc_5 * RECTANGLE_ELEMENT_HEIGHT;
            _loc_3 = _loc_5;
            while (_loc_3 <= _loc_7)
            {
                
                _loc_12 = _loc_9 + _loc_3 * defines.RECTANGLE_MAP_WIDTH;
                _loc_2 = _loc_4;
                while (_loc_2 <= _loc_6)
                {
                    
                    _loc_8 = this.mMap_list[_loc_12];
                    if (_loc_8 != null)
                    {
                        if (this.mStreetGridMap_list[_loc_12] != defines.ILLEGAL_INT_POS)
                        {
                            if (this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[this.mStreetGridMap_list[_loc_12]].mFogBorder < 4)
                            {
                                _loc_8.RenderNoAlpha();
                            }
                        }
                        else
                        {
                            _loc_8.RenderNoAlpha();
                        }
                    }
                    _loc_12++;
                    _loc_2++;
                }
                _loc_3++;
            }
            return;
        }// end function

        public function Init() : void
        {
            var _loc_6:int = 0;
            this.Clear();
            var _loc_1:int = 0;
            var _loc_2:int = 0;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            while (_loc_5 < defines.RECTANGLE_MAP_HEIGHT)
            {
                
                _loc_1 = _loc_4;
                _loc_6 = 0;
                while (_loc_6 < defines.RECTANGLE_MAP_WIDTH)
                {
                    
                    this.mStreetGridMap_list[_loc_3] = gCalculations.ConvertPixelPosToStreetGridPos(_loc_1, _loc_2);
                    _loc_1 = _loc_1 + RECTANGLE_ELEMENT_WIDTH;
                    _loc_3++;
                    _loc_6++;
                }
                _loc_2 = _loc_2 + RECTANGLE_ELEMENT_HEIGHT;
                _loc_5++;
            }
            return;
        }// end function

        public function ConvertXMLStringToMap(param1:String) : void
        {
            var _loc_3:int = 0;
            var _loc_8:cXML = null;
            var _loc_9:String = null;
            var _loc_10:Array = null;
            var _loc_11:int = 0;
            var _loc_12:String = null;
            var _loc_13:cBackground = null;
            var _loc_2:* = new cXML();
            _loc_2.SetXMLString(param1);
            var _loc_4:* = _loc_2.MoveToSubNode("BackgroundMap");
            var _loc_5:* = _loc_2.MoveToSubNode("BackgroundMap").CreateChildrenArray();
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            for each (_loc_8 in _loc_5)
            {
                
                _loc_9 = _loc_8.GetAttributeString_string("element");
                _loc_10 = _loc_9.split(",");
                _loc_11 = 0;
                _loc_7 = _loc_11 + _loc_6 * defines.RECTANGLE_MAP_WIDTH;
                if (_loc_6 < defines.RECTANGLE_MAP_HEIGHT)
                {
                    for each (_loc_12 in _loc_10)
                    {
                        
                        if (_loc_12 != "#")
                        {
                            _loc_13 = cBackground.CreateFromString(_loc_12, this.mGeneralInterface);
                            if (_loc_11 < defines.RECTANGLE_MAP_WIDTH)
                            {
                                this.mMap_list[_loc_7] = _loc_13;
                            }
                        }
                        else if (_loc_11 < defines.RECTANGLE_MAP_WIDTH)
                        {
                            this.mMap_list[_loc_7] = null;
                        }
                        _loc_11++;
                        _loc_7++;
                    }
                }
                _loc_6++;
            }
            this.UpdatePositions();
            return;
        }// end function

        public function GetNameFromGrid_string(param1:int) : String
        {
            var _loc_2:* = this.mMap_list[param1];
            if (_loc_2 != null)
            {
                return _loc_2.GetContainerName_string();
            }
            return null;
        }// end function

    }
}
