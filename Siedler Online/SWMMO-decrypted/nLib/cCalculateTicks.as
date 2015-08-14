package nLib
{
    import __AS3__.vec.*;

    public class cCalculateTicks extends Object
    {
        public var mDeltaTicksOne:Number;
        private var mLastFps:Number = 0;
        private var mCurrentFpsNof:int = 0;
        private var mCurrentFpsCntr:Number = 0;
        private var mLastTicks:Number;
        private const SCALE_GAME_FRAMERATE:Number = 16;
        private const MAX_SMOOTH_FPS:int = 10;
        private var mLastGetFpsTicks:Number = 0;
        public var mDeltaTicksMs:Number;
        private const HIGHEST_FRAME_RATE:Number = 0.0166667;
        public var mCurrentTicksSmoothed:Number;
        private var mSmoothFpsTicks_vector:Vector.<Number>;
        private const LOWEST_FRAME_RATE:Number = 0.1;

        public function cCalculateTicks()
        {
            this.mSmoothFpsTicks_vector = new Vector.<Number>(this.MAX_SMOOTH_FPS);
            return;
        }// end function

        public function CalculateDeltaTicks() : void
        {
            var _loc_2:Number = NaN;
            var _loc_1:* = gMisc.GetTimeSinceStartup();
            if (this.mLastTicks != -1)
            {
                _loc_2 = _loc_1 - this.mLastTicks;
            }
            else
            {
                _loc_2 = 0;
            }
            this.mLastTicks = _loc_1;
            this.mDeltaTicksMs = _loc_2;
            var _loc_3:* = 1000 / this.mDeltaTicksMs;
            this.mCurrentFpsCntr = this.mCurrentFpsCntr + _loc_3;
            var _loc_4:String = this;
            var _loc_5:* = this.mCurrentFpsNof + 1;
            _loc_4.mCurrentFpsNof = _loc_5;
            if (this.mCurrentFpsNof >= 30)
            {
                this.mLastFps = this.mCurrentFpsCntr / this.mCurrentFpsNof;
                this.mCurrentFpsCntr = 0;
                this.mCurrentFpsNof = 0;
            }
            this.mDeltaTicksOne = _loc_2 / 1000 * this.SCALE_GAME_FRAMERATE;
            return;
        }// end function

        public function CalculateDeltaTicksSmooth() : void
        {
            var _loc_1:* = gMisc.GetTimeSinceStartup();
            if (this.mLastTicks != -1)
            {
                this.mCurrentTicksSmoothed = (_loc_1 - this.mLastTicks) / 1000;
            }
            else
            {
                this.mCurrentTicksSmoothed = 0;
            }
            this.mLastTicks = _loc_1;
            if (this.mCurrentTicksSmoothed > this.LOWEST_FRAME_RATE)
            {
                this.mCurrentTicksSmoothed = this.LOWEST_FRAME_RATE;
            }
            if (this.mCurrentTicksSmoothed < this.HIGHEST_FRAME_RATE)
            {
                this.mCurrentTicksSmoothed = this.HIGHEST_FRAME_RATE;
            }
            this.mSmoothFpsTicks_vector[0] = this.mCurrentTicksSmoothed;
            var _loc_2:* = this.MAX_SMOOTH_FPS - 1;
            while (_loc_2 >= 1)
            {
                
                this.mSmoothFpsTicks_vector[_loc_2] = this.mSmoothFpsTicks_vector[(_loc_2 - 1)];
                _loc_2 = _loc_2 - 1;
            }
            var _loc_3:Number = 0;
            var _loc_4:int = 0;
            while (_loc_4 < this.MAX_SMOOTH_FPS)
            {
                
                _loc_3 = _loc_3 + this.mSmoothFpsTicks_vector[_loc_4];
                _loc_4++;
            }
            _loc_3 = _loc_3 / this.MAX_SMOOTH_FPS;
            this.mDeltaTicksOne = _loc_3 * this.SCALE_GAME_FRAMERATE;
            if (_loc_1 - this.mLastGetFpsTicks > 500)
            {
                this.mLastGetFpsTicks = _loc_1;
                this.mLastFps = 1 / _loc_3;
            }
            return;
        }// end function

        public function InitFpsCounter() : void
        {
            this.mLastTicks = -1;
            var _loc_1:int = 0;
            while (_loc_1 < this.MAX_SMOOTH_FPS)
            {
                
                this.mSmoothFpsTicks_vector.push(0);
                _loc_1++;
            }
            return;
        }// end function

        public function GetLastTick() : Number
        {
            return this.mLastTicks;
        }// end function

        public function GetFps() : Number
        {
            return this.mLastFps;
        }// end function

    }
}
