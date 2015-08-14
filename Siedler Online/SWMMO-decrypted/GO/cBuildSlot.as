package GO
{
    import GUI.Loca.*;
    import flash.events.*;
    import mx.events.*;

    public class cBuildSlot extends Object implements IEventDispatcher
    {
        public var mType:int = 0;
        private var _1457004543mTimeLeft:String = "00:00";
        private var mBuildingGridPos:int = 0;
        private var mTimeOfPurchase:Number = 0;
        private var _bindingEventDispatcher:EventDispatcher;
        public static const REGULAR_BUILDSLOT:int = 0;
        public static const PERMANENT_BUILDSLOT:int = 1;
        public static const TEMPORARY_BUILDSLOT:int = 2;

        public function cBuildSlot(param1:Number, param2:int)
        {
            this._bindingEventDispatcher = new EventDispatcher(IEventDispatcher(this));
            this.mTimeOfPurchase = param1;
            this.mBuildingGridPos = param2;
            return;
        }// end function

        public function dispatchEvent(event:Event) : Boolean
        {
            return this._bindingEventDispatcher.dispatchEvent(event);
        }// end function

        public function get mTimeLeft() : String
        {
            return this._1457004543mTimeLeft;
        }// end function

        public function set mTimeLeft(param1:String) : void
        {
            var _loc_2:* = this._1457004543mTimeLeft;
            if (_loc_2 !== param1)
            {
                this._1457004543mTimeLeft = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mTimeLeft", _loc_2, param1));
            }
            return;
        }// end function

        public function SetBuildingGridPosition(param1:int) : void
        {
            this.mBuildingGridPos = param1;
            return;
        }// end function

        public function willTrigger(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.willTrigger(param1);
        }// end function

        public function addEventListener(param1:String, param2:Function, param3:Boolean = false, param4:int = 0, param5:Boolean = false) : void
        {
            this._bindingEventDispatcher.addEventListener(param1, param2, param3, param4, param5);
            return;
        }// end function

        public function removeEventListener(param1:String, param2:Function, param3:Boolean = false) : void
        {
            this._bindingEventDispatcher.removeEventListener(param1, param2, param3);
            return;
        }// end function

        public function GetTimeOfPurchase() : Number
        {
            return this.mTimeOfPurchase;
        }// end function

        public function updateTimeLeft(param1:Number) : Boolean
        {
            var _loc_2:* = global.tempSlotDuration - (param1 - this.mTimeOfPurchase);
            if (_loc_2 > 0)
            {
                this.mTimeLeft = cLocaManager.GetInstance().FormatDuration(_loc_2, cLocaManager.DURATION_FORMAT_NUMERIC_SHORT);
                return true;
            }
            return false;
        }// end function

        public function hasEventListener(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.hasEventListener(param1);
        }// end function

        public function GetBuildingGridPosition() : int
        {
            return this.mBuildingGridPos;
        }// end function

    }
}
