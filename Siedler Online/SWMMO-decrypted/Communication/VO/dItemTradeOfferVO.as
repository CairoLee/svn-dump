﻿package Communication.VO
{
    import flash.events.*;
    import mx.events.*;

    public class dItemTradeOfferVO extends Object implements IEventDispatcher
    {
        private var _bindingEventDispatcher:EventDispatcher;
        private var _3035219buff:dBuffVO;
        private var _94849606costs:dResourceVO;
        private var _1681791655receipientId:int;

        public function dItemTradeOfferVO()
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

        public function removeEventListener(param1:String, param2:Function, param3:Boolean = false) : void
        {
            this._bindingEventDispatcher.removeEventListener(param1, param2, param3);
            return;
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

        public function get buff() : dBuffVO
        {
            return this._3035219buff;
        }// end function

        public function willTrigger(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.willTrigger(param1);
        }// end function

        public function get receipientId() : int
        {
            return this._1681791655receipientId;
        }// end function

        public function addEventListener(param1:String, param2:Function, param3:Boolean = false, param4:int = 0, param5:Boolean = false) : void
        {
            this._bindingEventDispatcher.addEventListener(param1, param2, param3, param4, param5);
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

    }
}