package SettlerKI
{
    import Enums.*;
    import GO.*;
    import PathFinding.*;
    import Specialists.*;
    import nLib.*;

    public class cSettlerAI_WalkToTarget extends cSettlerKI
    {
        private var generalTask:cSpecialistTask_WithSettler;

        public function cSettlerAI_WalkToTarget(param1:cSettler)
        {
            super(param1);
            return;
        }// end function

        public function SetGeneralTask(param1:cSpecialistTask_WithSettler) : void
        {
            this.generalTask = param1;
            mState = SETTLER_STATE_WALKING_ON_PATH;
            return;
        }// end function

        private function WalkOnPath() : void
        {
            var _loc_1:int = 0;
            var _loc_2:* = this.generalTask.GetPathPos();
            var _loc_3:* = mSettler.mGeneralInterface.GetClientTime() - mSettler.mGeneralInterface.mLastGameTickRefreshClientTime;
            _loc_2 = _loc_2 + _loc_3 * cSpecialistTask.SPECIALIST_WALK_SPEED;
            var _loc_4:* = _loc_2;
            _loc_4 = _loc_2 / defines.INT_SCALE_FACTOR;
            var _loc_5:* = this.generalTask.GetDestinationPath().dest_vector.length;
            if (this.generalTask.GetDestinationPath().dest_vector.length <= 0)
            {
                return;
            }
            if (this.generalTask.GetType() == SPECIALIST_TASK_TYPES.ATTACK_BUILDING && (this.generalTask.GetTaskPhase() == TASK_PHASES_ATTACK_BUILDING.ATTACK_TARGET || this.generalTask.GetTaskPhase() == TASK_PHASES_ATTACK_BUILDING.WAIT_AT_TARGET))
            {
                mVisible = false;
            }
            var _loc_6:* = int(_loc_4);
            if (int(_loc_4) >= _loc_5)
            {
                _loc_6 = int(_loc_5 * 2 - 1 - _loc_6);
                _loc_1 = _loc_6 - 1;
                if (this.generalTask.GetType() == SPECIALIST_TASK_TYPES.ATTACK_BUILDING && this.generalTask.GetTaskPhase() == TASK_PHASES_ATTACK_BUILDING.GO_TO_TARGET)
                {
                    mVisible = false;
                }
            }
            else
            {
                _loc_1 = _loc_6 + 1;
            }
            _loc_4 = _loc_4 % 1;
            if (_loc_1 < 0)
            {
                _loc_1 = 0;
                mVisible = false;
            }
            else if (_loc_1 >= _loc_5)
            {
                _loc_1 = int((_loc_5 - 1));
                mVisible = false;
            }
            if (_loc_6 < 0)
            {
                _loc_6 = 0;
            }
            else if (_loc_6 >= _loc_5)
            {
                _loc_6 = int((_loc_5 - 1));
            }
            var _loc_7:* = this.generalTask.GetDestinationPath().dest_vector[_loc_6] as dPathObjectItem;
            var _loc_8:* = this.generalTask.GetDestinationPath().dest_vector[_loc_1] as dPathObjectItem;
            mSettlerPos.x = _loc_4 * (_loc_8.x - _loc_7.x) + _loc_7.x;
            mSettlerPos.y = _loc_4 * (_loc_8.y - _loc_7.y) + _loc_7.y;
            mSettlerPos.y = mSettlerPos.y - global.streetGridYHalf;
            var _loc_9:* = Get4DirectionFromXY(_loc_8.x - _loc_7.x, _loc_8.y - _loc_7.y);
            mSettler.SetSubType(_loc_9);
            if (mAnimate)
            {
                mSettler.Animate();
            }
            return;
        }// end function

        override public function Compute() : void
        {
            mVisible = true;
            switch(mState)
            {
                case SETTLER_STATE_WALKING_ON_PATH:
                case SETTLER_STATE_ATTACKING:
                {
                    mSettlerPos.x = mSettler.GetX();
                    mSettlerPos.y = mSettler.GetY();
                    this.WalkOnPath();
                    break;
                }
                case SETTLER_STATE_REMOVE_SETTLER:
                {
                    break;
                }
                default:
                {
                    gMisc.Assert(false, "Could not interpret state " + mState);
                    break;
                }
            }
            mSettler.SetPosition(int(mSettlerPos.x), int(mSettlerPos.y));
            return;
        }// end function

    }
}
