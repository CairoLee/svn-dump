package ServerState
{
    import Enums.*;
    import Interface.*;
    import __AS3__.vec.*;

    public class cDataTracking extends Object
    {
        public var mDataTrackingItem_vector:Vector.<cDataTrackingItem>;
        public var mDirtyIndicator:int;
        private var mGeneralInterface:cGeneralInterface = null;
        public static const DATA_TRACKING_X_EVENT_ZONES_COMPLETED:int = 9;
        public static const DATA_TRACKING_GENERAL_DEFEATED_X_UNITS:int = 3;
        public static const DATA_TRACKING_BUILDING_BUILT:int = 0;
        public static const DATA_TRACKING_GENERAL_X_UNITS_OF_TYPE_X_TRAINED:int = 4;
        public static const DATA_TRACKING_FOUGHT_X_BATTLES:int = 5;
        public static const DATA_TRACKING_EVENT_ZONE_X_COMPLETED:int = 10;
        public static const DATA_TRACKING_MINES_EMPTIED:int = 1;
        public static const DATA_TRACKING_BUFFED_A_FRIEND_X_TIMES:int = 6;
        public static const DATA_TRACKING_PRODUCED_RESOURCES_OF_TYPE_X:int = 2;
        public static const DATA_TRACKING_MILLISECONDS_OF_GAMEPLAY:int = 7;
        public static const DATA_TRACKING_MINUTES_OF_GAMEPLAY:int = 8;
        public static const DATA_TRACKING_NOF:int = 11;

        public function cDataTracking(param1:cGeneralInterface)
        {
            this.mDataTrackingItem_vector = new Vector.<cDataTrackingItem>;
            this.mGeneralInterface = param1;
            this.mDataTrackingItem_vector.length = 0;
            var _loc_2:int = 0;
            while (_loc_2 < DATA_TRACKING_NOF)
            {
                
                this.mDataTrackingItem_vector.push(new cDataTrackingItem(_loc_2));
                _loc_2++;
            }
            return;
        }// end function

        public function IncTrackingDetail(param1:int, param2:String, param3:int) : void
        {
            this.mDataTrackingItem_vector[param1].IncTrackingDetail(param2, param3);
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.WEAK_MODIFICATION_BIT;
            return;
        }// end function

        public function AddTrackingValue(param1:int, param2:int) : void
        {
            this.mDataTrackingItem_vector[param1].IncAmount(param2);
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.WEAK_MODIFICATION_BIT;
            return;
        }// end function

        public function CheckAchievements() : void
        {
            return;
        }// end function

        public function GetTrackingValues()
        {
            return this.mDataTrackingItem_vector;
        }// end function

    }
}
