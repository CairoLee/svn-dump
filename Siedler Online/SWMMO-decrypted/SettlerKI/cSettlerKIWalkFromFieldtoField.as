package SettlerKI
{
    import GO.*;
    import __AS3__.vec.*;
    import flash.geom.*;
    import nLib.*;

    public class cSettlerKIWalkFromFieldtoField extends cSettlerKI
    {
        private var mGridPos:int;
        private var mPos:Point;
        private var mWait:Number;
        private var mRandomWalkPositions_vector:Vector.<Point> = null;
        private var mDead:Boolean;
        private var mLastWait:Boolean;

        public function cSettlerKIWalkFromFieldtoField(param1:cSettler)
        {
            this.mPos = new Point();
            super(param1);
            this.mWait = 1;
            this.mDead = false;
            this.mRandomWalkPositions_vector = new Vector.<Point>;
            var _loc_2:* = global.streetGridXHalf / 3;
            var _loc_3:* = global.streetGridYHalf / 3;
            var _loc_4:* = global.streetGridXHalf / 4;
            var _loc_5:* = global.streetGridYHalf / 4;
            this.mRandomWalkPositions_vector.push(new Point(0, 0));
            this.mRandomWalkPositions_vector.push(new Point(-_loc_2, 0));
            this.mRandomWalkPositions_vector.push(new Point(_loc_2, 0));
            this.mRandomWalkPositions_vector.push(new Point(0, -_loc_3));
            this.mRandomWalkPositions_vector.push(new Point(0, _loc_3));
            this.mRandomWalkPositions_vector.push(new Point(_loc_4, -_loc_3));
            this.mRandomWalkPositions_vector.push(new Point(_loc_4, _loc_3));
            this.mRandomWalkPositions_vector.push(new Point(-_loc_4, -_loc_3));
            this.mRandomWalkPositions_vector.push(new Point(-_loc_4, _loc_3));
            this.mRandomWalkPositions_vector.push(new Point(_loc_2, -_loc_5));
            this.mRandomWalkPositions_vector.push(new Point(_loc_2, _loc_5));
            this.mRandomWalkPositions_vector.push(new Point(-_loc_2, -_loc_5));
            this.mRandomWalkPositions_vector.push(new Point(-_loc_2, _loc_5));
            return;
        }// end function

        override public function BuildingWasPlaced(param1:cBuilding, param2:int) : void
        {
            if (param2 == this.mGridPos)
            {
            }
            this.mWait = 0;
            if (!this.SelectRandomNeighbourField(this.mPos.x, this.mPos.y, SPEED * 2))
            {
                DeactivateKI();
            }
            return;
        }// end function

        override public function Init() : void
        {
            this.mPos.x = mSettler.GetX();
            this.mPos.y = mSettler.GetY();
            this.mGridPos = gCalculations.ConvertPixelPosToStreetGridPos(int(this.mPos.x), int(this.mPos.y));
            return;
        }// end function

        private function CreateDestinationPos(param1:Number, param2:Number, param3:Number) : void
        {
            var _loc_4:Number = NaN;
            var _loc_5:Number = NaN;
            _loc_4 = param1 - this.mPos.x;
            _loc_5 = param2 - this.mPos.y;
            mNewDirection = Math.sqrt(_loc_4 * _loc_4 + _loc_5 * _loc_5);
            mDirection.x = _loc_4 / mNewDirection;
            mDirection.y = _loc_5 / mNewDirection;
            mDirection.x = mDirection.x * param3;
            mDirection.y = mDirection.y * param3;
            return;
        }// end function

        private function SelectRandomNeighbourField(param1:Number, param2:Number, param3:Number) : Boolean
        {
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            var _loc_8:int = 0;
            var _loc_10:cPosInt = null;
            var _loc_11:int = 0;
            mNewDirection = 0;
            var _loc_9:int = -1;
            _loc_5 = 0;
            while (_loc_5 < 2)
            {
                
                _loc_6 = 0;
                _loc_4 = 0;
                while (_loc_4 < 8)
                {
                    
                    _loc_10 = gCalculations.m8DirectionTableStreetGrid_vector[_loc_4] as cPosInt;
                    _loc_7 = param1 + _loc_10.x;
                    _loc_8 = param2 + _loc_10.y;
                    _loc_11 = gCalculations.ConvertPixelPosToStreetGridPos(_loc_7, _loc_8);
                    if (_loc_11 != defines.ILLEGAL_INT_POS)
                    {
                        if (!mSettler.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_11].IsBlockedAllowedNothing())
                        {
                            if (_loc_9 == _loc_6)
                            {
                                this.mGridPos = _loc_11;
                                this.CreateDestinationPos(_loc_7, _loc_8, param3);
                                return true;
                            }
                            _loc_6++;
                        }
                    }
                    _loc_4++;
                }
                _loc_9 = gMisc.GetRandomMinMaxInt(0, (_loc_6 - 1));
                _loc_5++;
            }
            return false;
        }// end function

        override public function Compute() : void
        {
            var _loc_1:int = 0;
            var _loc_5:Point = null;
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            var _loc_11:int = 0;
            if (this.mDead)
            {
                return;
            }
            if (mSettler.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[this.mGridPos].mFogBorder != 0)
            {
                mVisible = false;
                return;
            }
            mVisible = true;
            var _loc_2:Number = 0;
            var _loc_3:Number = 0;
            var _loc_4:Number = 0;
            var _loc_6:Boolean = false;
            if (this.mWait > 0)
            {
                this.mWait = this.mWait - mSettler.mGeneralInterface.mCalculateTicks.mDeltaTicksMs;
                if (this.mWait <= 0)
                {
                    this.mWait = 0;
                    _loc_6 = true;
                    this.mLastWait = true;
                }
            }
            else
            {
                _loc_3 = mDirection.x * mSettler.mGeneralInterface.mCalculateTicks.mDeltaTicksOne;
                _loc_4 = mDirection.y * mSettler.mGeneralInterface.mCalculateTicks.mDeltaTicksOne;
                _loc_2 = Math.sqrt(_loc_3 * _loc_3 + _loc_4 * _loc_4);
                mNewDirection = mNewDirection - _loc_2;
                if (mNewDirection <= 0)
                {
                    _loc_6 = true;
                    this.mLastWait = false;
                }
            }
            if (_loc_2 > 0)
            {
                mSettler.Animate();
            }
            if (_loc_6)
            {
                if (this.mLastWait)
                {
                    _loc_1 = gMisc.GetRandomMinMaxInt(0, 5);
                    _loc_1 = 0;
                    if (_loc_1 == 0)
                    {
                        if (!this.SelectRandomNeighbourField(this.mPos.x, this.mPos.y, SPEED))
                        {
                            DeactivateKI();
                        }
                    }
                    else
                    {
                        _loc_1 = gMisc.GetRandomMinMaxInt(0, (this.mRandomWalkPositions_vector.length - 1));
                        _loc_5 = this.mRandomWalkPositions_vector[_loc_1];
                        _loc_9 = this.mPos.x + _loc_5.x;
                        _loc_10 = this.mPos.y + _loc_5.y;
                        this.CreateDestinationPos(_loc_9, _loc_10, SPEED);
                        if (mNewDirection < 5)
                        {
                            this.mWait = gMisc.GetRandomMinMax(2 * 1000, 4 * 1000);
                        }
                    }
                }
                else
                {
                    this.mWait = gMisc.GetRandomMinMax(0.5 * 1000, 4 * 1000);
                }
            }
            else if (this.mWait == 0)
            {
                _loc_11 = Get8DirectionFromXY(int(mDirection.x * 1000), int(mDirection.y * 1000));
                mSettler.SetSubType(_loc_11);
            }
            var _loc_7:* = this.mPos.x;
            var _loc_8:* = this.mPos.y;
            _loc_7 = _loc_7 + _loc_3;
            _loc_8 = _loc_8 + _loc_4;
            this.mPos.x = _loc_7;
            this.mPos.y = _loc_8;
            mSettler.SetPosition(_loc_7, _loc_8 - global.streetGridYHalf);
            return;
        }// end function

    }
}
