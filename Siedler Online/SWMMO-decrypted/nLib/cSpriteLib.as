package nLib
{
    import __AS3__.vec.*;
    import flash.display.*;
    import flash.geom.*;
    import nLib.SpriteLibDataClass.*;

    public class cSpriteLib extends Object
    {
        private var mFrame:int;
        private var mAnimSpeed:Number;
        private var mAnimLoop:Boolean;
        private var mSubType:int;
        private var mSpriteLibContainer:cSpriteLibContainer = null;
        public var mAnimFrame:Number;
        private var mPosition:cPosInt;
        private static var mTempRect:Rectangle = new Rectangle();
        private static var mFinalPosition:cPosInt = new cPosInt(0, 0);
        private static var mNumberPosition:Point = new Point();

        public function cSpriteLib()
        {
            this.mPosition = new cPosInt(0, 0);
            this.Reset();
            return;
        }// end function

        public function GetBitmapFromSubTypeAndFrame(param1:int, param2:int) : BitmapData
        {
            if (this.mSpriteLibContainer.IsStreamingActiveIfNotActivate(param1, 0))
            {
                return null;
            }
            var _loc_3:* = this.mSpriteLibContainer.mSubtypeCalculated_vector;
            var _loc_4:* = _loc_3[param1];
            var _loc_5:* = _loc_3[param1].frameList_vector[param2];
            return _loc_3[param1].frameList_vector[param2].orginalBitmap;
        }// end function

        public function Render() : void
        {
            this.RenderSubTypeAndFrame(this.mPosition.x, this.mPosition.y, 0, 0);
            return;
        }// end function

        public function GetMaxHeightForSubType(param1:int) : int
        {
            var _loc_4:int = 0;
            var _loc_5:dFrameCalculated = null;
            if (this.mSpriteLibContainer.IsStreamingActiveIfNotActivate(param1, this.mAnimFrame))
            {
                return 0;
            }
            var _loc_2:* = this.mSpriteLibContainer.mSubtypeCalculated_vector;
            var _loc_3:* = _loc_2[param1];
            for each (_loc_5 in _loc_3.frameList_vector)
            {
                
                if (_loc_5.size_v > _loc_4)
                {
                    _loc_4 = _loc_5.size_v;
                }
            }
            return _loc_4;
        }// end function

        public function Animate(param1:Number) : Boolean
        {
            if (this.mSpriteLibContainer.IsStreamingActiveIfNotActivate(this.mSubType, this.mAnimFrame))
            {
                return false;
            }
            var _loc_2:* = this.mSpriteLibContainer.mSubtypeCalculated_vector;
            var _loc_3:* = _loc_2[this.mSubType];
            var _loc_4:* = _loc_3.numFrames;
            this.mAnimFrame = this.mAnimFrame + this.mAnimSpeed * param1;
            if (this.mAnimFrame >= _loc_4)
            {
                if (this.mAnimLoop)
                {
                    do
                    {
                        
                        this.mAnimFrame = this.mAnimFrame - _loc_4;
                    }while (this.mAnimFrame >= _loc_4)
                }
                else
                {
                    this.mAnimFrame = _loc_4 - 1;
                    return true;
                }
            }
            return false;
        }// end function

        public function RenderTransform2NoScaling(param1:int, param2:int, param3:String, param4:Number, param5:Number, param6:Number) : void
        {
            this.RenderSubTypeAndFrameTransformNoScaling(param1, param2, this.mSubType, this.mFrame, param3, param4, param5, param6);
            return;
        }// end function

        public function SetPosition(param1:int, param2:int) : void
        {
            this.mPosition.x = param1;
            this.mPosition.y = param2;
            return;
        }// end function

        public function GetHeight() : int
        {
            if (this.mSpriteLibContainer.IsStreamingActiveIfNotActivate(this.mSubType, this.mAnimFrame))
            {
                return 0;
            }
            var _loc_1:* = this.mSpriteLibContainer.mSubtypeCalculated_vector;
            var _loc_2:* = _loc_1[this.mSubType];
            var _loc_3:* = _loc_2.frameList_vector[this.mFrame];
            return _loc_3.size_v;
        }// end function

        public function GetAnimFrame() : Number
        {
            return this.mAnimFrame;
        }// end function

        public function RenderSubTypeAndFrame(param1:int, param2:int, param3:int, param4:int) : void
        {
            param1 = param1 * global.ui.mZoom.mFactorDivDefaultZoom;
            param2 = param2 * global.ui.mZoom.mFactorDivDefaultZoom;
            this.RenderSubTypeAndFrameNoScaling(param1, param2, param3, param4);
            return;
        }// end function

        public function GetMaxWidthForSubType(param1:int) : int
        {
            var _loc_4:int = 0;
            var _loc_5:dFrameCalculated = null;
            if (this.mSpriteLibContainer.IsStreamingActiveIfNotActivate(param1, this.mAnimFrame))
            {
                return 0;
            }
            var _loc_2:* = this.mSpriteLibContainer.mSubtypeCalculated_vector;
            var _loc_3:* = _loc_2[param1];
            for each (_loc_5 in _loc_3.frameList_vector)
            {
                
                if (_loc_5.size_u > _loc_4)
                {
                    _loc_4 = _loc_5.size_u;
                }
            }
            return _loc_4;
        }// end function

        public function GetSubType() : int
        {
            return this.mSubType;
        }// end function

        public function RenderSubTypeAndFrameTransformNoScaling(param1:int, param2:int, param3:int, param4:int, param5:String, param6:Number, param7:Number, param8:Number) : void
        {
            var _loc_12:Matrix = null;
            if (this.mSpriteLibContainer.IsStreamingActiveIfNotActivate(param3, param4))
            {
                return;
            }
            if (param3 != -1)
            {
                this.mSubType = param3;
                this.mFrame = param4;
            }
            var _loc_9:* = this.mSpriteLibContainer.mSubtypeCalculated_vector;
            var _loc_10:* = this.mSpriteLibContainer.mSubtypeCalculated_vector[this.mSubType];
            var _loc_11:* = this.mSpriteLibContainer.mSubtypeCalculated_vector[this.mSubType].frameList_vector[this.mFrame];
            this.mSpriteLibContainer.Rescale(this.mSubType, this.mFrame);
            mFinalPosition.x = param1 + _loc_11.frameOffsXScaledCache - global.ui.mZoom.mCacheZoomInvScaleScrollPosXMinusHalfScreenWidth;
            mFinalPosition.y = param2 + _loc_11.frameOffsYScaledCache - global.ui.mZoom.mCacheZoomInvScaleScrollPosYMinusHalfScreenHeight;
            _loc_11.zoomMatrix.tx = mFinalPosition.x;
            _loc_11.zoomMatrix.ty = mFinalPosition.y;
            if (param6 == 1 && param7 == 1 && param8 == 0)
            {
                mTempRect.x = mFinalPosition.x;
                mTempRect.y = mFinalPosition.y;
                mTempRect.width = _loc_11.scaledBitmap.width;
                mTempRect.height = _loc_11.scaledBitmap.height;
                cBackbuffer.Draw(_loc_11.scaledBitmap, _loc_11.zoomMatrix, param5, mTempRect);
            }
            else
            {
                _loc_12 = _loc_11.zoomMatrix.clone();
                _loc_12.scale(param6, param7);
                _loc_12.rotate(param8);
                _loc_12.tx = _loc_11.zoomMatrix.tx;
                _loc_12.ty = _loc_11.zoomMatrix.ty;
                cBackbuffer.Draw(_loc_11.scaledBitmap, _loc_12, param5, _loc_11.scaledBitmapRectangle);
            }
            return;
        }// end function

        public function RenderPosNoScaling(param1:int, param2:int) : void
        {
            this.RenderSubTypeAndFrameNoScaling(param1, param2, this.mSubType, this.mAnimFrame);
            return;
        }// end function

        public function RenderTransform(param1:String) : void
        {
            this.RenderSubTypeAndFrameTransform(this.mPosition.x, this.mPosition.y, 0, 0, param1, 1, 1, 0);
            return;
        }// end function

        public function RenderTransformNoScaling(param1:String) : void
        {
            this.RenderSubTypeAndFrameTransformNoScaling(this.mPosition.x, this.mPosition.y, 0, 0, param1, 1, 1, 0);
            return;
        }// end function

        public function RenderSubTypeAndFrameTransform(param1:int, param2:int, param3:int, param4:int, param5:String, param6:Number, param7:Number, param8:Number) : void
        {
            param1 = param1 * global.ui.mZoom.mFactorDivDefaultZoom;
            param2 = param2 * global.ui.mZoom.mFactorDivDefaultZoom;
            this.RenderSubTypeAndFrameTransformNoScaling(param1, param2, param3, param4, param5, param6, param7, param8);
            return;
        }// end function

        public function SetSubTypeAndFrame(param1:int, param2:int) : void
        {
            this.mSubType = param1;
            this.mFrame = param2;
            return;
        }// end function

        public function RenderNoScaling() : void
        {
            this.RenderSubTypeAndFrameNoScaling(this.mPosition.x, this.mPosition.y, 0, 0);
            return;
        }// end function

        public function SetContainer(param1:Object) : void
        {
            if (param1 != this.mSpriteLibContainer)
            {
                this.mSpriteLibContainer = param1 as cSpriteLibContainer;
                this.SetSubTypeAndFrame(0, 0);
            }
            return;
        }// end function

        public function SetFrame(param1:int) : void
        {
            if (this.mFrame != param1)
            {
                this.mFrame = param1;
            }
            return;
        }// end function

        public function RenderPosNoScalingNoAlpha(param1:int, param2:int) : void
        {
            if (this.mSpriteLibContainer.IsStreamingActiveIfNotActivate(this.mSubType, this.mFrame))
            {
                return;
            }
            var _loc_3:* = this.mSpriteLibContainer.mSubtypeCalculated_vector;
            var _loc_4:* = _loc_3[this.mSubType];
            var _loc_5:* = _loc_3[this.mSubType].frameList_vector[this.mFrame];
            this.mSpriteLibContainer.Rescale(this.mSubType, this.mFrame);
            mFinalPosition.x = param1 + _loc_5.frameOffsXScaledCache - global.ui.mZoom.mCacheZoomInvScaleScrollPosXMinusHalfScreenWidth;
            mFinalPosition.y = param2 + _loc_5.frameOffsYScaledCache - global.ui.mZoom.mCacheZoomInvScaleScrollPosYMinusHalfScreenHeight;
            mNumberPosition.x = mFinalPosition.x;
            mNumberPosition.y = mFinalPosition.y;
            cBackbuffer.CopyPixels(_loc_5.scaledBitmap, _loc_5.scaledBitmapRectangle, mNumberPosition, false);
            return;
        }// end function

        public function RenderSubTypeAndFrameNoScaling(param1:int, param2:int, param3:int, param4:int) : void
        {
            if (this.mSpriteLibContainer.IsStreamingActiveIfNotActivate(param3, param4))
            {
                return;
            }
            if (param3 != -1)
            {
                this.mSubType = param3;
                this.mFrame = param4;
            }
            var _loc_5:* = this.mSpriteLibContainer.mSubtypeCalculated_vector;
            var _loc_6:* = this.mSpriteLibContainer.mSubtypeCalculated_vector[this.mSubType];
            var _loc_7:* = this.mSpriteLibContainer.mSubtypeCalculated_vector[this.mSubType].frameList_vector[this.mFrame];
            this.mSpriteLibContainer.Rescale(this.mSubType, this.mFrame);
            mFinalPosition.x = param1 + _loc_7.frameOffsXScaledCache - global.ui.mZoom.mCacheZoomInvScaleScrollPosXMinusHalfScreenWidth;
            mFinalPosition.y = param2 + _loc_7.frameOffsYScaledCache - global.ui.mZoom.mCacheZoomInvScaleScrollPosYMinusHalfScreenHeight;
            mNumberPosition.x = mFinalPosition.x;
            mNumberPosition.y = mFinalPosition.y;
            cBackbuffer.CopyPixels(_loc_7.scaledBitmap, _loc_7.scaledBitmapRectangle, mNumberPosition, true);
            return;
        }// end function

        public function SetAnimFrame(param1:Number) : void
        {
            this.mAnimFrame = param1;
            return;
        }// end function

        public function GetNofSubTypes() : int
        {
            var _loc_1:* = this.mSpriteLibContainer.mSubtypeCalculated_vector;
            return _loc_1.length;
        }// end function

        public function GetContainer() : cSpriteLibContainer
        {
            return this.mSpriteLibContainer;
        }// end function

        public function GetWidth() : int
        {
            if (this.mSpriteLibContainer.IsStreamingActiveIfNotActivate(this.mSubType, this.mAnimFrame))
            {
                return 0;
            }
            var _loc_1:* = this.mSpriteLibContainer.mSubtypeCalculated_vector;
            var _loc_2:* = _loc_1[this.mSubType];
            var _loc_3:* = _loc_2.frameList_vector[this.mFrame];
            return _loc_3.size_u;
        }// end function

        public function IsInsideScreen(param1:int, param2:int, param3:int, param4:int) : Boolean
        {
            if (this.mSpriteLibContainer.IsStreamingActiveIfNotActivate(param3, param4))
            {
                return false;
            }
            if (param3 != -1)
            {
                this.mSubType = param3;
                this.mFrame = param4;
            }
            this.mSpriteLibContainer.Rescale(this.mSubType, this.mFrame);
            var _loc_5:* = this.mSpriteLibContainer.mSubtypeCalculated_vector;
            var _loc_6:* = this.mSpriteLibContainer.mSubtypeCalculated_vector[this.mSubType];
            var _loc_7:* = this.mSpriteLibContainer.mSubtypeCalculated_vector[this.mSubType].frameList_vector[this.mFrame];
            mFinalPosition.x = param1 - _loc_6.seqFootXScaled + _loc_7.frameOffsXScaled;
            mFinalPosition.y = param2 - _loc_6.seqFootYScaled + _loc_7.frameOffsYScaled;
            global.ui.mZoom.CalculateScrollPos(mFinalPosition);
            if (mFinalPosition.x + _loc_7.scaledBitmap.width < cBackbuffer.mClipMinX || mFinalPosition.y + _loc_7.scaledBitmap.height < cBackbuffer.mClipMinY || mFinalPosition.x > cBackbuffer.mClipMaxX || mFinalPosition.y > cBackbuffer.mClipMaxY)
            {
                return false;
            }
            return true;
        }// end function

        public function RenderTransform2(param1:int, param2:int, param3:String, param4:Number, param5:Number, param6:Number) : void
        {
            this.RenderSubTypeAndFrameTransform(param1, param2, this.mSubType, this.mFrame, param3, param4, param5, param6);
            return;
        }// end function

        public function GetNofFrames(param1:int) : int
        {
            if (this.mSpriteLibContainer.IsStreamingActiveIfNotActivate(param1, 0))
            {
                return 0;
            }
            if (param1 == -1)
            {
                param1 = this.mSubType;
            }
            this.SetSubType(param1);
            var _loc_2:* = this.mSpriteLibContainer.mSubtypeCalculated_vector;
            var _loc_3:* = _loc_2[this.mSubType];
            return _loc_3.numFrames;
        }// end function

        public function Reset() : void
        {
            this.SetPosition(0, 0);
            this.mSpriteLibContainer = null;
            this.mSubType = -1;
            this.mAnimFrame = 0;
            this.mFrame = -1;
            this.mAnimLoop = false;
            return;
        }// end function

        public function SetRandomAnimFrame() : void
        {
            var _loc_1:* = this.GetNofFrames(this.mSubType);
            this.mAnimFrame = gMisc.GetRandomMinMax(0, (_loc_1 - 1));
            return;
        }// end function

        public function SetSubType(param1:int) : void
        {
            if (this.mSubType == param1)
            {
                return;
            }
            this.mSubType = param1;
            this.mFrame = -1;
            return;
        }// end function

        public function SetAnim(param1:Number, param2:Boolean) : void
        {
            if (param1 < 0)
            {
                param1 = 0;
            }
            this.mAnimFrame = 0;
            this.mAnimSpeed = param1;
            this.mAnimLoop = param2;
            return;
        }// end function

        public function IsSpriteInSpriteLib(param1:String) : Boolean
        {
            return this.mSpriteLibContainer.GetSpritePackIDByName(param1) != null;
        }// end function

        public function RenderPos(param1:int, param2:int) : void
        {
            this.RenderSubTypeAndFrame(param1, param2, this.mSubType, this.mAnimFrame);
            return;
        }// end function

        public function GetPosition() : cPosInt
        {
            return this.mPosition;
        }// end function

    }
}
