package Communication.VO
{
    import Enums.*;
    import flash.events.*;
    import mx.events.*;

    public class dDepositVO extends Object implements IEventDispatcher
    {
        private var _bindingEventDispatcher:EventDispatcher;
        private var _287344023gridIdx:uint;
        private var _1141400650accessible:int;
        private var _1266057854depositGroupdId:int;
        private var _1623837028emptied:uint;
        private var _1935748339goSetListName_string:String;
        private var _324534341name_string:String;
        private var _1413853096amount:int;
        private var _1098889508maxAmount:int;

        public function dDepositVO()
        {
            this._bindingEventDispatcher = new EventDispatcher(IEventDispatcher(this));
            return;
        }// end function

        public function dispatchEvent(event:Event) : Boolean
        {
            return this._bindingEventDispatcher.dispatchEvent(event);
        }// end function

        public function hasEventListener(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.hasEventListener(param1);
        }// end function

        public function get accessible() : int
        {
            return this._1141400650accessible;
        }// end function

        public function willTrigger(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.willTrigger(param1);
        }// end function

        public function set name_string(param1:String) : void
        {
            var _loc_2:* = this._324534341name_string;
            if (_loc_2 !== param1)
            {
                this._324534341name_string = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "name_string", _loc_2, param1));
            }
            return;
        }// end function

        public function get name_string() : String
        {
            return this._324534341name_string;
        }// end function

        public function get goSetListName_string() : String
        {
            return this._1935748339goSetListName_string;
        }// end function

        public function removeEventListener(param1:String, param2:Function, param3:Boolean = false) : void
        {
            this._bindingEventDispatcher.removeEventListener(param1, param2, param3);
            return;
        }// end function

        public function addEventListener(param1:String, param2:Function, param3:Boolean = false, param4:int = 0, param5:Boolean = false) : void
        {
            this._bindingEventDispatcher.addEventListener(param1, param2, param3, param4, param5);
            return;
        }// end function

        public function get gridIdx() : uint
        {
            return this._287344023gridIdx;
        }// end function

        public function get amount() : int
        {
            return this._1413853096amount;
        }// end function

        public function set goSetListName_string(param1:String) : void
        {
            var _loc_2:* = this._1935748339goSetListName_string;
            if (_loc_2 !== param1)
            {
                this._1935748339goSetListName_string = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "goSetListName_string", _loc_2, param1));
            }
            return;
        }// end function

        public function get emptied() : uint
        {
            return this._1623837028emptied;
        }// end function

        public function get maxAmount() : int
        {
            return this._1098889508maxAmount;
        }// end function

        public function set accessible(param1:int) : void
        {
            var _loc_2:* = this._1141400650accessible;
            if (_loc_2 !== param1)
            {
                this._1141400650accessible = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "accessible", _loc_2, param1));
            }
            return;
        }// end function

        public function set gridIdx(param1:uint) : void
        {
            var _loc_2:* = this._287344023gridIdx;
            if (_loc_2 !== param1)
            {
                this._287344023gridIdx = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "gridIdx", _loc_2, param1));
            }
            return;
        }// end function

        public function set amount(param1:int) : void
        {
            var _loc_2:* = this._1413853096amount;
            if (_loc_2 !== param1)
            {
                this._1413853096amount = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "amount", _loc_2, param1));
            }
            return;
        }// end function

        public function toString() : String
        {
            return "<dDepositVO name_string=\'" + this.name_string + "\' amount=\'" + this.amount + "\' maxAmount=\'" + this.maxAmount + "\' gridIdx=\'" + this.gridIdx + "\' depositGroupdId=\'" + this.depositGroupdId + "\' accessible=\'" + this.accessible + "\' accessibleString=\'" + DEPOSIT_ACCESSIBLE_TYPES.toString(this.accessible) + "\' emptied=\'" + this.emptied + "\' goSetListName_string= \'" + this.goSetListName_string + "\' />";
        }// end function

        public function IsEqualToVOIgnoreGrid(param1:dDepositVO) : Boolean
        {
            if (param1.amount != this.amount)
            {
                return false;
            }
            if (param1.name_string != this.name_string)
            {
                return false;
            }
            if (param1.accessible != this.accessible)
            {
                return false;
            }
            return true;
        }// end function

        public function set emptied(param1:uint) : void
        {
            var _loc_2:* = this._1623837028emptied;
            if (_loc_2 !== param1)
            {
                this._1623837028emptied = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "emptied", _loc_2, param1));
            }
            return;
        }// end function

        public function set depositGroupdId(param1:int) : void
        {
            var _loc_2:* = this._1266057854depositGroupdId;
            if (_loc_2 !== param1)
            {
                this._1266057854depositGroupdId = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "depositGroupdId", _loc_2, param1));
            }
            return;
        }// end function

        public function get depositGroupdId() : int
        {
            return this._1266057854depositGroupdId;
        }// end function

        public function set maxAmount(param1:int) : void
        {
            var _loc_2:* = this._1098889508maxAmount;
            if (_loc_2 !== param1)
            {
                this._1098889508maxAmount = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "maxAmount", _loc_2, param1));
            }
            return;
        }// end function

    }
}
