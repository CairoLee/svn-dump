package nLib
{
    import Map.*;
    import flash.geom.*;

    public class cZoom extends Object
    {
        public var mCacheZoomInvScaleScrollPosYMinusHalfScreenHeight:Number;
        public var mSmoothing:Boolean = true;
        private var mNLibInterface:cNLibInterface;
        private var mFactor:Number = -1;
        public var mFactorDivDefaultZoom:Number = -1;
        public var mCacheZoomInvScaleScrollPosXMinusHalfScreenWidth:Number;
        private var mDefaultZoomDivFactor:Number = -1;
        private var mScrollPosX:Number;
        private var mScrollPosY:Number;
        public static const DEFAULT_ZOOM:Number = 1000;

        public function cZoom()
        {
            return;
        }// end function

        public function InvScale(param1:Number, param2:Number) : Number
        {
            return param1 * this.mFactor / param2;
        }// end function

        public function InvCalculateScrollPos(param1:cPosInt) : void
        {
            var _loc_2:* = param1.x;
            var _loc_3:* = param1.y;
            _loc_2 = _loc_2 * this.mDefaultZoomDivFactor;
            _loc_3 = _loc_3 * this.mDefaultZoomDivFactor;
            _loc_2 = _loc_2 + this.mScrollPosX;
            _loc_3 = _loc_3 + this.mScrollPosY;
            _loc_2 = _loc_2 - global.screenWidthHalf * this.mDefaultZoomDivFactor;
            _loc_3 = _loc_3 - global.screenHeightHalf * this.mDefaultZoomDivFactor;
            param1.x = _loc_2;
            param1.y = _loc_3;
            return;
        }// end function

        public function ScrollX(param1:Number) : void
        {
            this.mScrollPosX = this.mScrollPosX + param1;
            this.RestrictScrollPos();
            return;
        }// end function

        public function GetScrollPosY() : Number
        {
            return this.mScrollPosY;
        }// end function

        public function UpdateScrollCacheValuesX() : void
        {
            this.mCacheZoomInvScaleScrollPosXMinusHalfScreenWidth = this.InvScale(this.mScrollPosX, cZoom.DEFAULT_ZOOM) - global.screenWidthHalf;
            return;
        }// end function

        public function RestrictScrollPos() : void
        {
            var _loc_1:int = 0;
            var _loc_2:int = 0;
            var _loc_3:* = global.streetGridX * (defines.STREET_ZONE_SIZE_X + defines.STREET_ZONE_BORDER) + 4;
            var _loc_4:* = global.streetGridYHalf * (defines.STREET_ZONE_SIZE_Y + defines.STREET_ZONE_BORDER) + 4;
            if (this.mScrollPosX < _loc_1)
            {
                this.mScrollPosX = _loc_1;
            }
            if (this.mScrollPosY < _loc_2)
            {
                this.mScrollPosY = _loc_2;
            }
            if (this.mScrollPosX > _loc_3)
            {
                this.mScrollPosX = _loc_3;
            }
            if (this.mScrollPosY > _loc_4)
            {
                this.mScrollPosY = _loc_4;
            }
            return;
        }// end function

        public function SetScrollPosToScreen() : void
        {
            this.SetScrollPos(-global.screenWidthHalf, -global.screenHeightHalf);
            this.SetScaleFactor(1000, true);
            return;
        }// end function

        public function Scroll(param1:int, param2:Number, param3:Boolean) : void
        {
            var _loc_4:Number = NaN;
            var _loc_5:Boolean = false;
            _loc_4 = param2;
            if (param1 == defines.SCROLL_LEFT)
            {
                this.ScrollX(-_loc_4);
                if (param3)
                {
                    cBackbuffer.SetClippingXYWH(this.InvScale(this.GetScrollPosX(), cZoom.DEFAULT_ZOOM), this.InvScale(this.GetScrollPosY(), cZoom.DEFAULT_ZOOM), _loc_4, global.screenHeight);
                    this.mNLibInterface.CacheBackgroundScroll();
                    cBackbuffer.SetDefaultClipping();
                }
            }
            if (param1 == defines.SCROLL_RIGHT)
            {
                this.ScrollX(_loc_4);
                if (param3)
                {
                    cBackbuffer.SetClippingXYWH(this.InvScale(this.GetScrollPosX(), cZoom.DEFAULT_ZOOM) + (global.screenWidth - _loc_4), this.InvScale(this.GetScrollPosY(), cZoom.DEFAULT_ZOOM), _loc_4, global.screenHeight);
                    this.mNLibInterface.CacheBackgroundScroll();
                    cBackbuffer.SetDefaultClipping();
                }
            }
            if (param1 == defines.SCROLL_UP)
            {
                this.ScrollY(-_loc_4);
                if (param3)
                {
                    cBackbuffer.SetClippingXYWH(this.InvScale(this.GetScrollPosX(), cZoom.DEFAULT_ZOOM), this.InvScale(this.GetScrollPosY(), cZoom.DEFAULT_ZOOM), global.screenWidth, _loc_4);
                    this.mNLibInterface.CacheBackgroundScroll();
                    cBackbuffer.SetDefaultClipping();
                }
            }
            if (param1 == defines.SCROLL_DOWN)
            {
                this.ScrollY(_loc_4);
                if (param3)
                {
                    cBackbuffer.SetClippingXYWH(this.InvScale(this.GetScrollPosX(), cZoom.DEFAULT_ZOOM), this.InvScale(this.GetScrollPosY(), cZoom.DEFAULT_ZOOM) + (global.screenHeight - _loc_4), global.screenWidth, _loc_4);
                    this.mNLibInterface.CacheBackgroundScroll();
                    cBackbuffer.SetDefaultClipping();
                }
            }
            return;
        }// end function

        public function AddScaleFactor(param1:Number) : void
        {
            this.SetScaleFactor(this.mFactor + param1, true);
            return;
        }// end function

        public function ScrollY(param1:Number) : void
        {
            this.mScrollPosY = this.mScrollPosY + param1;
            this.RestrictScrollPos();
            return;
        }// end function

        public function SetScrollPosPlayerZone(param1:cPlayerZoneScreen, param2:int, param3:int) : void
        {
            var _loc_4:* = defines.STREET_ZONE_SIZE_X / defines.SECTORS_X;
            var _loc_5:* = defines.STREET_ZONE_SIZE_Y / defines.SECTORS_Y;
            var _loc_6:* = param2 * (_loc_4 + defines.STREET_ZONE_BORDER) * global.streetGridX;
            var _loc_7:* = param3 * (_loc_5 + defines.STREET_ZONE_BORDER) * global.streetGridYHalf;
            var _loc_8:* = _loc_6 + ((_loc_4 >> 1) + (defines.STREET_MAP_MIN_USABLE_AREA_X - 1) + defines.STREET_ZONE_BORDER) * global.streetGridX;
            var _loc_9:* = _loc_7 + ((_loc_5 >> 1) + (defines.STREET_MAP_MIN_USABLE_AREA_Y - 1) + defines.STREET_ZONE_BORDER) * global.streetGridYHalf;
            this.SetScrollPos(_loc_8, _loc_9);
            return;
        }// end function

        public function GetScrollPosX() : Number
        {
            return this.mScrollPosX;
        }// end function

        public function SetScaleFactor(param1:Number, param2:Boolean) : void
        {
            if (param2)
            {
                if (param1 > global.maxZoom)
                {
                    param1 = global.maxZoom;
                }
                if (param1 < global.minZoom)
                {
                    param1 = global.minZoom;
                }
            }
            if (Math.floor(this.mFactor) != Math.floor(param1))
            {
                this.mFactor = param1;
                this.mFactorDivDefaultZoom = this.mFactor / DEFAULT_ZOOM;
                this.mDefaultZoomDivFactor = DEFAULT_ZOOM / this.mFactor;
                this.mNLibInterface.ZoomHasChanged();
                this.UpdateScrollCacheValuesX();
                this.UpdateScrollCacheValuesY();
                this.mNLibInterface.UpdatePositions();
                gGfxResource.ApplyZoom(this.mDefaultZoomDivFactor);
            }
            return;
        }// end function

        public function CalculateZoomMatrix(param1:Number) : Matrix
        {
            var _loc_2:* = new Matrix();
            _loc_2.identity();
            var _loc_3:* = this.mFactor / param1;
            _loc_2.scale(_loc_3, _loc_3);
            return _loc_2;
        }// end function

        public function GetInvScaleFactor() : Number
        {
            return this.mDefaultZoomDivFactor;
        }// end function

        public function CalculateScrollPos(param1:cPosInt) : void
        {
            var _loc_2:* = param1.x;
            var _loc_3:* = param1.y;
            _loc_2 = _loc_2 * this.mFactorDivDefaultZoom;
            _loc_3 = _loc_3 * this.mFactorDivDefaultZoom;
            _loc_2 = _loc_2 - this.mCacheZoomInvScaleScrollPosXMinusHalfScreenWidth;
            _loc_3 = _loc_3 - this.mCacheZoomInvScaleScrollPosYMinusHalfScreenHeight;
            param1.x = _loc_2;
            param1.y = _loc_3;
            return;
        }// end function

        public function GetScaleFactor() : Number
        {
            return this.mFactor;
        }// end function

        public function ScaleInt(param1:Number, param2:Number) : int
        {
            return int(param1 * param2 / this.mFactor);
        }// end function

        public function GetScrollPosXInt() : int
        {
            return int(this.mScrollPosX);
        }// end function

        public function SetScrollPosPlayerZoneSectorNr(param1:cPlayerZoneScreen, param2:int) : void
        {
            var _loc_5:int = 0;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            while (_loc_4 < defines.SECTORS_Y)
            {
                
                _loc_5 = 0;
                while (_loc_5 < defines.SECTORS_X)
                {
                    
                    if (_loc_3 == param2)
                    {
                        this.SetScrollPosPlayerZone(param1, _loc_5, _loc_4);
                        return;
                    }
                    _loc_3++;
                    _loc_5++;
                }
                _loc_4++;
            }
            return;
        }// end function

        public function SetScrollPos(param1:Number, param2:Number) : void
        {
            this.mScrollPosX = param1;
            this.mScrollPosY = param2;
            this.UpdateScrollCacheValuesX();
            this.UpdateScrollCacheValuesY();
            return;
        }// end function

        public function UpdateScrollCacheValuesY() : void
        {
            this.mCacheZoomInvScaleScrollPosYMinusHalfScreenHeight = this.InvScale(this.mScrollPosY, cZoom.DEFAULT_ZOOM) - global.screenHeightHalf;
            return;
        }// end function

        public function Init(param1:Number, param2:cNLibInterface) : void
        {
            this.mNLibInterface = param2;
            this.ResetFactorAndPos(cZoom.DEFAULT_ZOOM);
            return;
        }// end function

        public function Scale(param1:Number, param2:Number) : Number
        {
            return param1 * param2 / this.mFactor;
        }// end function

        public function GetScrollPosYInt() : int
        {
            return int(this.mScrollPosY);
        }// end function

        public function InvScaleInt(param1:Number, param2:Number) : int
        {
            return int(param1 * this.mFactor / param2);
        }// end function

        public function ResetFactorAndPos(param1:Number) : void
        {
            this.mScrollPosX = defines.STREET_ZONE_SIZE_X * global.streetGridX / 2 + defines.STREET_MAP_MIN_USABLE_AREA_X;
            this.mScrollPosY = defines.STREET_ZONE_SIZE_Y * global.streetGridYHalf / 2 + defines.STREET_MAP_MIN_USABLE_AREA_Y;
            this.mFactor = -1;
            this.SetScaleFactor(param1, true);
            return;
        }// end function

    }
}
