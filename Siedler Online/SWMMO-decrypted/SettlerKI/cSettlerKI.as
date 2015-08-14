package SettlerKI
{
    import GO.*;
    import flash.geom.*;

    public class cSettlerKI extends Object
    {
        protected var mP:Point;
        public var mVisible:Boolean = false;
        protected var mNewDirection:Number = 0;
        protected var mDirection:Point;
        public var mAnimate:Boolean = true;
        protected var mSettlerPos:Point;
        protected var mSettler:cSettler;
        protected var mState:int = 0;
        protected var mStateBeforeMoving:int = 0;
        public static const SETTLER_STATE_IS_QUEUED:int = 11;
        public static const SETTLER_STATE_WAIT_FOR_STORE_HOUSE:int = 5;
        public static const SETTLER_STATE_REMOVE_SETTLER:int = 2;
        public static const SETTLER_STATE_IS_WORKING_IN_RESOURCE_CREATION_HOUSE:int = 9;
        public static const SETTLER_STATE_WALKING_ON_DEPOSIT_PATH:int = 4;
        public static const SETTLER_STATE_NONE:int = 0;
        public static const SETTLER_STATE_WALKING_ON_RESOURCE_PATH:int = 3;
        public static const SETTLER_STATE_ATTACKING:int = 7;
        public static const SETTLER_STATE_HAS_NO_WORK:int = 1;
        static const SPEED:Number = 2;
        public static const SETTLER_STATE_WAITS_FOR_POPULATION:int = 12;
        public static const SETTLER_STATE_IS_WORKING_IN_EXTERNAL_WORKYARD:int = 10;
        public static const SETTLER_STATE_WAITS_BECAUSE_WAREHOUSE_IS_FULL:int = 13;
        public static const SETTLER_STATE_WAITS_BECAUSE_BUILDING_IS_MOVING:int = 14;
        public static const SETTLER_STATE_WALKING_ON_PATH:int = 6;

        public function cSettlerKI(param1:cSettler)
        {
            this.mDirection = new Point(0, 0);
            this.mP = new Point();
            this.mSettlerPos = new Point(0, 0);
            this.mSettler = param1;
            this.mState = SETTLER_STATE_NONE;
            this.mStateBeforeMoving = SETTLER_STATE_NONE;
            this.mVisible = true;
            this.mAnimate = true;
            this.mNewDirection = 0;
            this.mSettler.SetSubType(0);
            return;
        }// end function

        public function Get4DirectionFromXY(param1:int, param2:int) : int
        {
            if (param1 >= 0)
            {
            }
            if (param2 >= 0)
            {
                return defines.DIR8_SOUTH_EAST;
            }
            return defines.DIR8_NORTH_EAST;
        }// end function

        public function SetKIState(param1:int) : void
        {
            this.mState = param1;
            return;
        }// end function

        public function Compute() : void
        {
            return;
        }// end function

        public function BuildingWasPlaced(param1:cBuilding, param2:int) : void
        {
            return;
        }// end function

        public function GetKIState() : int
        {
            return this.mState;
        }// end function

        protected function BounceBackFromBoarder() : void
        {
            var _loc_1:Number = 0;
            var _loc_2:* = global.streetGridX * defines.STREET_MAP_WIDTH_FINAL;
            var _loc_3:* = global.streetGridYHalf * defines.STREET_MAP_HEIGHT_FINAL;
            var _loc_4:Boolean = false;
            if (this.mSettler.GetX() >= _loc_2)
            {
                _loc_1 = 0.25;
                _loc_4 = true;
            }
            else if (this.mSettler.GetX() <= 0)
            {
                _loc_1 = 0.75;
                _loc_4 = true;
            }
            if (this.mSettler.GetY() >= _loc_3)
            {
                _loc_1 = 0.5;
                _loc_4 = true;
            }
            else if (this.mSettler.GetY() <= 0)
            {
                _loc_1 = 0;
                _loc_4 = true;
            }
            if (_loc_4)
            {
                this.mNewDirection = 10;
                this.mDirection = gCalculations.TransFormPoint(_loc_1, 1);
            }
            return;
        }// end function

        protected function SetSubTypeFromDirection() : void
        {
            var _loc_1:* = this.mSettler.GetX();
            var _loc_2:* = this.mSettler.GetY();
            _loc_1 = _loc_1 + this.mDirection.x * SPEED * this.mSettler.mGeneralInterface.mCalculateTicks.mDeltaTicksOne;
            _loc_2 = _loc_2 + this.mDirection.y * SPEED * this.mSettler.mGeneralInterface.mCalculateTicks.mDeltaTicksOne;
            this.mSettler.SetPosition(int(_loc_1), int(_loc_2));
            var _loc_3:* = this.Get4DirectionFromXY(int(this.mDirection.x * 1000), int(this.mDirection.y * 1000));
            this.mSettler.SetSubType(_loc_3);
            return;
        }// end function

        public function Get8DirectionFromXY(param1:int, param2:int) : int
        {
            var _loc_3:Number = 0.92388;
            this.mP.x = param1;
            this.mP.y = param2;
            this.mP.normalize(1);
            if (this.mP.x >= 0 && this.mP.y >= 0)
            {
                if (this.mP.x > _loc_3)
                {
                    return defines.DIR8_EAST;
                }
                if (this.mP.y > _loc_3)
                {
                    return defines.DIR8_SOUTH;
                }
                return defines.DIR8_SOUTH_EAST;
            }
            if (this.mP.x >= 0 && this.mP.y <= 0)
            {
                if (this.mP.x > _loc_3)
                {
                    return defines.DIR8_EAST;
                }
                if (this.mP.y < -_loc_3)
                {
                    return defines.DIR8_NORTH;
                }
                return defines.DIR8_NORTH_EAST;
            }
            if (this.mP.x <= 0 && this.mP.y <= 0)
            {
                if (this.mP.x < -_loc_3)
                {
                    return defines.DIR8_WEST;
                }
                if (this.mP.y < -_loc_3)
                {
                    return defines.DIR8_NORTH;
                }
                return defines.DIR8_NORTH_WEST;
            }
            if (this.mP.x < -_loc_3)
            {
                return defines.DIR8_WEST;
            }
            if (this.mP.y > _loc_3)
            {
                return defines.DIR8_SOUTH;
            }
            return defines.DIR8_SOUTH_WEST;
        }// end function

        public function Init() : void
        {
            return;
        }// end function

        public function DeactivateKI() : void
        {
            this.mState = SETTLER_STATE_REMOVE_SETTLER;
            return;
        }// end function

        public function RestoreKIStateBeforeMoving() : void
        {
            this.mState = this.mStateBeforeMoving;
            return;
        }// end function

        public function SetKIStateMoving() : void
        {
            this.mStateBeforeMoving = this.mState;
            this.mState = SETTLER_STATE_WAITS_BECAUSE_BUILDING_IS_MOVING;
            return;
        }// end function

    }
}
