package nLib
{
    import __AS3__.vec.*;
    import flash.display.*;
    import flash.geom.*;

    public class cBackbuffer extends Object
    {
        private static const mWidthSegmentShift:int = 8;
        public static var mSegmentCounter:int = 0;
        private static const mWidthSegment:int = 256;
        private static const mHeightSegment:int = 256;
        private static const mHeightSegmentShift:int = 8;
        private static var mTempPos:Point = new Point();
        public static var mClipMinX:int;
        public static var mClipMinY:int;
        public static const ACTIVATE_SEGMENTBUFFER:Boolean = true;
        private static var mXSegments:int;
        private static var mYSegments:int;
        public static var mBackBuffer:BitmapData;
        private static var mBackBufferBitmapData_vector:Vector.<cSegmentBackBufferBitmap> = null;
        private static var mBackBufferArray_vector:Vector.<cSegmentBackbufferElement> = null;
        private static var mTempRect:Rectangle = new Rectangle();
        public static var mNeededSegmentCounter:int = 0;
        private static var mRedirectToSegmentBuffer:Boolean;
        private static var mScreenBufferElements:int;
        public static var mClipMaxX:int;
        public static var mClipMaxY:int;

        public function cBackbuffer()
        {
            return;
        }// end function

        public static function SetDefaultClipping() : void
        {
            mClipMinX = 0;
            mClipMinY = 0;
            mClipMaxX = mBackBuffer.width;
            mClipMaxY = mBackBuffer.height;
            return;
        }// end function

        public static function InitSegmentBuffer(param1:int, param2:int, param3:int, param4:Boolean) : void
        {
            var _loc_8:int = 0;
            var _loc_9:cSegmentBackbufferElement = null;
            var _loc_10:cSegmentBackBufferBitmap = null;
            if (!ACTIVATE_SEGMENTBUFFER)
            {
                return;
            }
            mXSegments = param1;
            mYSegments = param2;
            mScreenBufferElements = param3;
            mBackBufferArray_vector = new Vector.<cSegmentBackbufferElement>;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            while (_loc_6 < mYSegments)
            {
                
                _loc_8 = 0;
                while (_loc_8 < mXSegments)
                {
                    
                    _loc_9 = new cSegmentBackbufferElement();
                    _loc_9.backBufferBitmap = null;
                    _loc_9.x = _loc_8 * mWidthSegment;
                    _loc_9.y = _loc_6 * mHeightSegment;
                    mBackBufferArray_vector.push(_loc_9);
                    _loc_5++;
                    _loc_8++;
                }
                _loc_6++;
            }
            mBackBufferBitmapData_vector = new Vector.<cSegmentBackBufferBitmap>;
            var _loc_7:int = 0;
            while (_loc_7 < mScreenBufferElements)
            {
                
                _loc_10 = new cSegmentBackBufferBitmap();
                _loc_10.bitmapData = new BitmapData(mWidthSegment, mHeightSegment, param4);
                _loc_10.usedBy = null;
                mBackBufferBitmapData_vector.push(_loc_10);
                _loc_7++;
            }
            return;
        }// end function

        public static function CopyPixels(param1:BitmapData, param2:Rectangle, param3:Point, param4:Boolean) : void
        {
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            var _loc_8:int = 0;
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            var _loc_11:int = 0;
            var _loc_12:cSegmentBackbufferElement = null;
            var _loc_13:cSegmentBackBufferBitmap = null;
            if (mRedirectToSegmentBuffer)
            {
                _loc_5 = 0;
                _loc_6 = param3.x >> mWidthSegmentShift;
                _loc_7 = param3.y >> mHeightSegmentShift;
                _loc_8 = param3.x + param2.width >> mWidthSegmentShift;
                _loc_9 = param3.y + param2.height >> mHeightSegmentShift;
                if (!(_loc_6 >= 0 && _loc_6 + _loc_8 < mXSegments && _loc_7 >= 0 && _loc_7 + _loc_9 < mYSegments))
                {
                    return;
                }
                _loc_10 = _loc_7;
                while (_loc_10 <= _loc_9)
                {
                    
                    _loc_11 = _loc_6;
                    while (_loc_11 <= _loc_8)
                    {
                        
                        _loc_5 = _loc_11 + _loc_10 * mXSegments;
                        _loc_12 = mBackBufferArray_vector[_loc_5] as cSegmentBackbufferElement;
                        mTempPos.x = param3.x - _loc_12.x;
                        mTempPos.y = param3.y - _loc_12.y;
                        if (mTempPos.x + param2.width < 0 || mTempPos.y + param2.height < 0 || mTempPos.x > mWidthSegment || mTempPos.y > mHeightSegment)
                        {
                        }
                        else
                        {
                            if (_loc_12.backBufferBitmap == null)
                            {
                                for each (_loc_13 in mBackBufferBitmapData_vector)
                                {
                                    
                                    if (_loc_13.usedBy == null)
                                    {
                                        _loc_12.backBufferBitmap = _loc_13;
                                        _loc_13.usedBy = _loc_12;
                                        var _loc_17:* = mSegmentCounter + 1;
                                        mSegmentCounter = _loc_17;
                                        break;
                                    }
                                }
                                var _loc_15:* = mNeededSegmentCounter + 1;
                                mNeededSegmentCounter = _loc_15;
                            }
                            if (_loc_12.backBufferBitmap != null)
                            {
                                _loc_12.backBufferBitmap.bitmapData.copyPixels(param1, param2, mTempPos, null, null, param4);
                            }
                        }
                        _loc_11++;
                    }
                    _loc_10++;
                }
            }
            else
            {
                if (param3.x + param2.width < mClipMinX || param3.y + param2.height < mClipMinY || param3.x > mClipMaxX || param3.y > mClipMaxY)
                {
                    return;
                }
                mBackBuffer.copyPixels(param1, param2, param3, null, null, param4);
            }
            return;
        }// end function

        public static function Clear(param1:uint) : void
        {
            var _loc_2:cSegmentBackBufferBitmap = null;
            if (mRedirectToSegmentBuffer)
            {
                for each (_loc_2 in mBackBufferBitmapData_vector)
                {
                    
                    _loc_2.bitmapData.fillRect(_loc_2.bitmapData.rect, param1);
                    if (_loc_2.usedBy != null)
                    {
                        _loc_2.usedBy.backBufferBitmap = null;
                        _loc_2.usedBy = null;
                    }
                }
            }
            else
            {
                mBackBuffer.fillRect(mBackBuffer.rect, param1);
            }
            return;
        }// end function

        public static function Init(param1:int, param2:int, param3:Boolean) : void
        {
            mBackBuffer = new BitmapData(param1, param2, param3);
            SetClippingXYWH(0, 0, param1, param2);
            SetRedirectToSegmentBuffer(false);
            return;
        }// end function

        public static function ClearAlpha(param1:Number) : void
        {
            var _loc_3:cSegmentBackBufferBitmap = null;
            var _loc_2:* = new ColorTransform();
            _loc_2.alphaMultiplier = param1;
            if (mRedirectToSegmentBuffer)
            {
                for each (_loc_3 in mBackBufferBitmapData_vector)
                {
                    
                    _loc_3.bitmapData.colorTransform(mBackBuffer.rect, _loc_2);
                    if (_loc_3.usedBy != null)
                    {
                        _loc_3.usedBy.backBufferBitmap = null;
                        _loc_3.usedBy = null;
                    }
                }
            }
            else
            {
                mBackBuffer.colorTransform(mBackBuffer.rect, _loc_2);
            }
            return;
        }// end function

        public static function SetClippingXYWH(param1:int, param2:int, param3:int, param4:int) : void
        {
            mClipMinX = param1;
            mClipMinY = param2;
            mClipMaxX = param3 + param1;
            mClipMaxY = param4 + param2;
            return;
        }// end function

        public static function GetWidth() : int
        {
            return mBackBuffer.rect.width;
        }// end function

        public static function CopyFromSegmentBuffer(param1:Rectangle) : void
        {
            var _loc_2:cSegmentBackBufferBitmap = null;
            var _loc_3:cSegmentBackbufferElement = null;
            var _loc_4:Number = NaN;
            var _loc_5:Number = NaN;
            var _loc_6:Number = NaN;
            var _loc_7:Number = NaN;
            for each (_loc_2 in mBackBufferBitmapData_vector)
            {
                
                if (_loc_2.usedBy != null)
                {
                    _loc_3 = _loc_2.usedBy;
                    mTempPos.x = _loc_3.x;
                    mTempPos.y = _loc_3.y;
                    _loc_4 = _loc_3.x;
                    _loc_5 = _loc_3.y;
                    _loc_6 = _loc_3.x + mWidthSegment;
                    _loc_7 = _loc_3.y + mHeightSegment;
                    if (_loc_4 < param1.x)
                    {
                        mTempPos.x = mTempPos.x + (param1.x - _loc_4);
                        _loc_4 = param1.x;
                    }
                    if (_loc_5 < param1.y)
                    {
                        mTempPos.y = mTempPos.y + (param1.y - _loc_5);
                        _loc_5 = param1.y;
                    }
                    if (_loc_6 > param1.x + param1.width)
                    {
                        _loc_6 = param1.x + param1.width;
                    }
                    if (_loc_7 > param1.y + param1.height)
                    {
                        _loc_7 = param1.y + param1.height;
                    }
                    mTempRect.x = _loc_4 - _loc_3.x;
                    mTempRect.y = _loc_5 - _loc_3.y;
                    mTempRect.width = _loc_6 - _loc_4;
                    mTempRect.height = _loc_7 - _loc_5;
                    mTempPos.x = mTempPos.x - param1.x;
                    mTempPos.y = mTempPos.y - param1.y;
                    mBackBuffer.copyPixels(_loc_3.backBufferBitmap.bitmapData, mTempRect, mTempPos, null, null, false);
                }
            }
            return;
        }// end function

        public static function Lock() : void
        {
            mBackBuffer.lock();
            return;
        }// end function

        public static function RemoveUnusedSegments(param1:int, param2:int, param3:uint) : void
        {
            var _loc_4:cSegmentBackBufferBitmap = null;
            var _loc_5:cSegmentBackbufferElement = null;
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            param1 = global.ui.mZoom.InvScale(param1, cZoom.DEFAULT_ZOOM);
            param2 = global.ui.mZoom.InvScale(param2, cZoom.DEFAULT_ZOOM);
            for each (_loc_4 in mBackBufferBitmapData_vector)
            {
                
                if (_loc_4.usedBy != null)
                {
                    _loc_5 = _loc_4.usedBy;
                    _loc_6 = _loc_5.x - param1;
                    _loc_7 = _loc_5.y - param2;
                    if (_loc_6 + mWidthSegment < 0 || _loc_7 + mHeightSegment < 0 || _loc_6 > mBackBuffer.rect.width || _loc_7 > mBackBuffer.rect.height)
                    {
                        _loc_4.bitmapData.fillRect(_loc_4.bitmapData.rect, param3);
                        _loc_4.usedBy.backBufferBitmap = null;
                        _loc_4.usedBy = null;
                    }
                }
            }
            return;
        }// end function

        public static function UpdateSegmentBuffer(param1:Rectangle) : void
        {
            return;
        }// end function

        public static function Unlock() : void
        {
            mBackBuffer.unlock();
            return;
        }// end function

        public static function SetRedirectToSegmentBuffer(param1:Boolean) : void
        {
            if (!ACTIVATE_SEGMENTBUFFER)
            {
                mRedirectToSegmentBuffer = false;
                return;
            }
            mRedirectToSegmentBuffer = param1;
            if (param1)
            {
                mSegmentCounter = 0;
                mNeededSegmentCounter = 0;
            }
            return;
        }// end function

        public static function Draw(param1:BitmapData, param2:Matrix, param3:String, param4:Rectangle) : void
        {
            if (mRedirectToSegmentBuffer)
            {
            }
            else
            {
                if (param2.tx + param1.width < mClipMinX || param2.ty + param1.height < mClipMinY || param2.tx > mClipMaxX || param2.ty > mClipMaxY)
                {
                    return;
                }
                mBackBuffer.draw(param1, param2, null, param3, param4, true);
            }
            return;
        }// end function

        public static function GetHeight() : int
        {
            return mBackBuffer.rect.height;
        }// end function

    }
}
