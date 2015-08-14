package SettlerKI
{
    import GO.*;
    import PathFinding.*;
    import ServerState.*;
    import nLib.*;

    public class cSettlerKIWalkToDestination extends cSettlerKI
    {
        private var visible:Boolean = true;
        public var mResourceCreation:cResourceCreation;

        public function cSettlerKIWalkToDestination(param1:cSettler)
        {
            super(param1);
            return;
        }// end function

        public function SetResourcePath(param1:cResourceCreation) : void
        {
            this.mResourceCreation = param1;
            return;
        }// end function

        override public function Compute() : void
        {
            this.visible = true;
            switch(mState)
            {
                case SETTLER_STATE_WALKING_ON_RESOURCE_PATH:
                {
                    mSettlerPos.x = mSettler.GetX();
                    mSettlerPos.y = mSettler.GetY();
                    this.WalkOnResourcePath();
                    break;
                }
                case SETTLER_STATE_WALKING_ON_DEPOSIT_PATH:
                {
                    mSettlerPos.x = mSettler.GetX();
                    mSettlerPos.y = mSettler.GetY();
                    this.WalkOnDepositPath();
                    break;
                }
                case SETTLER_STATE_WAIT_FOR_STORE_HOUSE:
                {
                    if (this.mResourceCreation.GetStoreHouse() != null)
                    {
                        mState = SETTLER_STATE_WALKING_ON_RESOURCE_PATH;
                    }
                    break;
                }
                default:
                {
                    this.visible = false;
                    break;
                    break;
                }
            }
            mVisible = this.visible;
            mSettler.SetPosition(int(mSettlerPos.x), int(mSettlerPos.y));
            return;
        }// end function

        private function WalkOnDepositPath() : void
        {
            var _loc_1:int = 0;
            var _loc_2:int = 0;
            if (this.mResourceCreation.GetDepositPath() == null)
            {
                this.visible = false;
                return;
            }
            var _loc_3:* = this.mResourceCreation.pathPos;
            var _loc_4:* = mSettler.mGeneralInterface.GetClientTime() - mSettler.mGeneralInterface.mLastGameTickRefreshClientTime;
            _loc_3 = _loc_3 + _loc_4 * cComputeResourceCreation.SETTLER_WALK_SPEED_INT;
            if (!this.mResourceCreation.GetRemove() && this.mResourceCreation.GetResourceCreationHouse() != null)
            {
                switch(this.mResourceCreation.GetResourceCreationHouse().GetBuildingMode())
                {
                    case cBuilding.BUILDING_MODE_SETTLER_WALKS_FROM_RESOURCECREATIONHOUSE_TO_EXTERNAL_RESOURCE:
                    {
                        if (_loc_3 > this.mResourceCreation.GetDepositPath().pathLenX10000)
                        {
                            this.visible = false;
                            return;
                        }
                        break;
                    }
                    case cBuilding.BUILDING_MODE_SETTLER_WALKS_FROM_EXTERNAL_RESOURCE_TO_RESOURCECREATIONHOUSE:
                    {
                        if (_loc_3 >= this.mResourceCreation.GetDepositPath().pathLenX20000)
                        {
                            this.visible = false;
                            return;
                        }
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
            var _loc_5:* = _loc_3;
            _loc_5 = _loc_3 / defines.INT_SCALE_FACTOR;
            var _loc_6:* = this.mResourceCreation.GetDepositPath().pathLenX10000 / defines.INT_SCALE_FACTOR;
            _loc_1 = int(_loc_5);
            if (_loc_1 >= _loc_6)
            {
                _loc_1 = int(_loc_6 * 2 - 1 - _loc_1);
                _loc_2 = _loc_1 - 1;
            }
            else
            {
                _loc_2 = _loc_1 + 1;
            }
            _loc_5 = _loc_5 % 1;
            var _loc_7:Boolean = false;
            if (_loc_2 < 0)
            {
                _loc_7 = true;
                _loc_2 = 0;
            }
            if (_loc_2 >= _loc_6)
            {
                _loc_7 = true;
                _loc_2 = int((_loc_6 - 1));
            }
            if (_loc_7)
            {
                this.visible = false;
                return;
            }
            if (_loc_1 < 0)
            {
                _loc_1 = 0;
            }
            if (_loc_1 >= _loc_6)
            {
                _loc_1 = int((_loc_6 - 1));
            }
            var _loc_8:* = this.mResourceCreation.GetDepositPath().dest_vector[_loc_1] as cPosInt;
            var _loc_9:* = this.mResourceCreation.GetDepositPath().dest_vector[_loc_2] as cPosInt;
            var _loc_10:* = int(_loc_5 * 256);
            mSettlerPos.x = (_loc_10 * (_loc_9.x - _loc_8.x) >> 8) + _loc_8.x;
            mSettlerPos.y = (_loc_10 * (_loc_9.y - _loc_8.y) >> 8) + _loc_8.y;
            mSettlerPos.y = mSettlerPos.y - global.streetGridYHalf;
            var _loc_11:* = Get4DirectionFromXY(_loc_9.x - _loc_8.x, _loc_9.y - _loc_8.y);
            mSettler.SetSubType(_loc_11);
            mSettler.Animate();
            return;
        }// end function

        private function WalkOnResourcePath() : void
        {
            var _loc_1:int = 0;
            var _loc_2:int = 0;
            if (this.mResourceCreation.GetPath() == null)
            {
                this.visible = false;
                return;
            }
            var _loc_3:* = this.mResourceCreation.pathPos;
            var _loc_4:* = mSettler.mGeneralInterface.GetClientTime() - mSettler.mGeneralInterface.mLastGameTickRefreshClientTime;
            _loc_3 = _loc_3 + _loc_4 * cComputeResourceCreation.SETTLER_WALK_SPEED_INT;
            if (!this.mResourceCreation.GetRemove() && this.mResourceCreation.GetResourceCreationHouse() != null)
            {
                switch(this.mResourceCreation.GetResourceCreationHouse().GetBuildingMode())
                {
                    case cBuilding.BUILDING_MODE_SETTLER_WALKS_FROM_STOREHOUSE_TO_RESOURCECREATIONHOUSE:
                    case cBuilding.BUILDING_MODE_SETTLER_WALKS_TO_BUILDING_GROUND_PLACE:
                    {
                        if (_loc_3 >= this.mResourceCreation.GetPath().pathLenX10000)
                        {
                            this.visible = false;
                            return;
                        }
                        break;
                    }
                    case cBuilding.BUILDING_MODE_SETTLER_WALKS_FROM_RESOURCECREATIONHOUSE_TO_STOREHOUSE:
                    case cBuilding.BUILDING_MODE_BUILDER_WALKS_FROM_RESOURCECREATIONHOUSE_TO_STOREHOUSE:
                    {
                        if (_loc_3 > this.mResourceCreation.GetPath().pathLenX20000)
                        {
                            this.visible = false;
                            return;
                        }
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
            var _loc_5:* = _loc_3;
            _loc_5 = _loc_3 / defines.INT_SCALE_FACTOR;
            var _loc_6:* = this.mResourceCreation.GetPath().dest_vector.length;
            _loc_1 = int(_loc_5);
            if (_loc_1 >= _loc_6)
            {
                if (this.mResourceCreation.GetStoreHouse() == null)
                {
                    this.visible = false;
                    return;
                }
                _loc_1 = int(_loc_6 * 2 - 1 - _loc_1);
                _loc_2 = _loc_1 - 1;
            }
            else
            {
                _loc_2 = _loc_1 + 1;
            }
            _loc_5 = _loc_5 % 1;
            var _loc_7:Boolean = false;
            if (_loc_2 < 0)
            {
                _loc_7 = true;
                _loc_2 = 0;
            }
            if (_loc_2 >= _loc_6)
            {
                _loc_7 = true;
                _loc_2 = int((_loc_6 - 1));
            }
            if (_loc_7)
            {
                this.visible = false;
                return;
            }
            if (_loc_1 < 0)
            {
                _loc_1 = 0;
            }
            if (_loc_1 >= _loc_6)
            {
                _loc_1 = int((_loc_6 - 1));
            }
            var _loc_8:* = this.mResourceCreation.GetPath().dest_vector[_loc_1] as dPathObjectItem;
            var _loc_9:* = this.mResourceCreation.GetPath().dest_vector[_loc_2] as dPathObjectItem;
            mSettlerPos.x = _loc_5 * (_loc_9.x - _loc_8.x) + _loc_8.x;
            mSettlerPos.y = _loc_5 * (_loc_9.y - _loc_8.y) + _loc_8.y;
            mSettlerPos.y = mSettlerPos.y - global.streetGridYHalf;
            var _loc_10:* = Get4DirectionFromXY(_loc_9.x - _loc_8.x, _loc_9.y - _loc_8.y);
            mSettler.SetSubType(_loc_10);
            mSettler.Animate();
            return;
        }// end function

    }
}
