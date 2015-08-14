package Communication.VO
{
    import flash.events.*;
    import mx.events.*;

    public class dAcceptItemTradeVO extends Object implements IEventDispatcher
    {
        private var _bindingEventDispatcher:EventDispatcher;
        private var _209269578receiverID:int;
        private var _3035219buff:dBuffVO;
        private var _94849606costs:dResourceVO;
        private var _1081574094mailId:int;

        public function dAcceptItemTradeVO()
        {
            this._bindingEventDispatcher = new EventDispatcher(IEventDispatcher(this));
            return;
        }// end function

        public function dispatchEvent(event:Event) : Boolean
        {
            return this._bindingEventDispatcher.dispatchEvent(event);
        }// end function

        public function get costs() : dResourceVO
        {
            return this._94849606costs;
        }// end function

        public function get receiverID() : int
        {
            return this._209269578receiverID;
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

        public function removeEventListener(param1:String, param2:Function, param3:Boolean = false) : void
        {
            this._bindingEventDispatcher.removeEventListener(param1, param2, param3);
            return;
        }// end function

        public function get buff() : dBuffVO
        {
            return this._3035219buff;
        }// end function

        public function willTrigger(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.willTrigger(param1);
        }// end function

        public function set receiverID(param1:int) : void
        {
            var _loc_2:* = this._209269578receiverID;
            if (_loc_2 !== param1)
            {
                this._209269578receiverID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "receiverID", _loc_2, param1));
            }
            return;
        }// end function

        public function addEventListener(param1:String, param2:Function, param3:Boolean = false, param4:int = 0, param5:Boolean = false) : void
        {
            this._bindingEventDispatcher.addEventListener(param1, param2, param3, param4, param5);
            return;
        }// end function

        public function set mailId(param1:int) : void
        {
            var _loc_2:* = this._1081574094mailId;
            if (_loc_2 !== param1)
            {
                this._1081574094mailId = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mailId", _loc_2, param1));
            }
            return;
        }// end function

        public function set buff(param1:dBuffVO) : void
        {
            var _loc_2:* = this._3035219buff;
            if (_loc_2 !== param1)
            {
                this._3035219buff = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "buff", _loc_2, param1));
            }
            return;
        }// end function

        public function get mailId() : int
        {
            return this._1081574094mailId;
        }// end function

        public function hasEventListener(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.hasEventListener(param1);
        }// end function

    }
}
