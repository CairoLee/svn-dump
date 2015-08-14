package ServerState
{
    import Communication.VO.*;
    import Enums.*;

    public class cDataTrackingItem extends Object
    {
        private var dataTracking:Object;
        public var mDirtyIndicator:int;
        private var amount:int;
        private var type:int;

        public function cDataTrackingItem(param1:int)
        {
            this.dataTracking = new Object();
            this.type = param1;
            return;
        }// end function

        public function IncTrackingDetail(param1:String, param2:int) : void
        {
            if (isNaN(this.dataTracking[param1]))
            {
                this.dataTracking[param1] = param2;
            }
            else
            {
                this.dataTracking[param1] = this.dataTracking[param1] + param2;
            }
            return;
        }// end function

        public function toString() : String
        {
            var _loc_1:String = null;
            var _loc_2:String = null;
            var _loc_3:int = 0;
            _loc_1 = "<cDataTrackingItem type=\'" + this.type + "\' amount=\'" + this.amount;
            for (_loc_2 in this.dataTracking)
            {
                
                _loc_3 = this.dataTracking[_loc_2];
                _loc_1 = _loc_1 + ("..." + _loc_2 + "=" + _loc_3);
            }
            _loc_1 = _loc_1 + "\' />";
            return _loc_1;
        }// end function

        public function GetAmount() : int
        {
            return this.amount;
        }// end function

        public function CreateVO() : dDataTrackingVO
        {
            var _loc_2:String = null;
            var _loc_3:dDataIntStringVO = null;
            var _loc_1:* = new dDataTrackingVO();
            _loc_1.amount = this.amount;
            for (_loc_2 in this.dataTracking)
            {
                
                _loc_3 = new dDataIntStringVO();
                _loc_3.string = _loc_2;
                _loc_3.value = this.dataTracking[_loc_2];
                _loc_1.dataTracking.addItem(_loc_3);
            }
            return _loc_1;
        }// end function

        public function IncAmount(param1:int) : void
        {
            if (this.amount == 0)
            {
                this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.CREATED_BIT;
            }
            else
            {
                this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            }
            this.amount = this.amount + param1;
            return;
        }// end function

        public function GetType() : int
        {
            return this.type;
        }// end function

        public function CreateFromVO(param1:dDataTrackingVO) : void
        {
            var _loc_2:dDataIntStringVO = null;
            this.amount = param1.amount;
            this.dataTracking = new Object();
            for each (_loc_2 in param1.dataTracking)
            {
                
                this.dataTracking[_loc_2.string] = _loc_2.value;
            }
            return;
        }// end function

    }
}
