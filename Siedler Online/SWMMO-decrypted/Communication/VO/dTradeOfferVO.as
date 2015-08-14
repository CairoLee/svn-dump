package Communication.VO
{
    import flash.events.*;
    import flash.utils.*;
    import mx.events.*;

    public class dTradeOfferVO extends Object implements IEventDispatcher
    {
        private var _bindingEventDispatcher:EventDispatcher;
        private var _105650780offer:dResourceVO;
        private var _94849606costs:dResourceVO;
        private var _1681791655receipientId:int;

        public function dTradeOfferVO()
        {
            this._bindingEventDispatcher = new EventDispatcher(IEventDispatcher(this));
            return;
        }// end function

        public function dispatchEvent(event:Event) : Boolean
        {
            return this._bindingEventDispatcher.dispatchEvent(event);
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            this.receipientId = param1.readInt();
            this.offer = param1.readObject() as dResourceVO;
            this.costs = param1.readObject() as dResourceVO;
            return;
        }// end function

        public function get costs() : dResourceVO
        {
            return this._94849606costs;
        }// end function

        public function set costs(param1:dResourceVO) : void
        {
            var _loc_2:* = this._94849606costs;
            if (_loc_2 !== param1)
            {
                this._94849606costs = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "costs", _loc_2, param1));
            }
            return;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeInt(this.receipientId);
            param1.writeObject(this.offer);
            param1.writeObject(this.costs);
            return;
        }// end function

        public function willTrigger(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.willTrigger(param1);
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

        public function get receipientId() : int
        {
            return this._1681791655receipientId;
        }// end function

        public function get offer() : dResourceVO
        {
            return this._105650780offer;
        }// end function

        public function toString() : String
        {
            return "<dTradeOfferVO receipientId=\'" + this.receipientId + "\' offer=\'" + this.offer + "\' costs=\'" + this.costs + "\' />";
        }// end function

        public function set receipientId(param1:int) : void
        {
            var _loc_2:* = this._1681791655receipientId;
            if (_loc_2 !== param1)
            {
                this._1681791655receipientId = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "receipientId", _loc_2, param1));
            }
            return;
        }// end function

        public function hasEventListener(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.hasEventListener(param1);
        }// end function

        public function set offer(param1:dResourceVO) : void
        {
            var _loc_2:* = this._105650780offer;
            if (_loc_2 !== param1)
            {
                this._105650780offer = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "offer", _loc_2, param1));
            }
            return;
        }// end function

    }
}
