package Communication.VO
{
    import flash.events.*;
    import flash.utils.*;
    import mx.events.*;

    public class dTradeVO extends Object implements IEventDispatcher
    {
        private var _481367759senderPlayerId:int;
        private var _969261240resourceToAdd:dResourceVO;
        private var _1081574094mailId:int;
        private var _283396428resourceToDeduct:dResourceVO;
        private var _40608021receiverPlayerId:int;
        private var _bindingEventDispatcher:EventDispatcher;

        public function dTradeVO()
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
            this.mailId = param1.readInt();
            this.senderPlayerId = param1.readInt();
            this.receiverPlayerId = param1.readInt();
            this.resourceToAdd = param1.readObject() as dResourceVO;
            this.resourceToDeduct = param1.readObject() as dResourceVO;
            return;
        }// end function

        public function hasEventListener(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.hasEventListener(param1);
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeInt(this.mailId);
            param1.writeInt(this.senderPlayerId);
            param1.writeInt(this.receiverPlayerId);
            param1.writeObject(this.resourceToAdd);
            param1.writeObject(this.resourceToDeduct);
            return;
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

        public function get resourceToDeduct() : dResourceVO
        {
            return this._283396428resourceToDeduct;
        }// end function

        public function willTrigger(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.willTrigger(param1);
        }// end function

        public function set receiverPlayerId(param1:int) : void
        {
            var _loc_2:* = this._40608021receiverPlayerId;
            if (_loc_2 !== param1)
            {
                this._40608021receiverPlayerId = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "receiverPlayerId", _loc_2, param1));
            }
            return;
        }// end function

        public function set resourceToDeduct(param1:dResourceVO) : void
        {
            var _loc_2:* = this._283396428resourceToDeduct;
            if (_loc_2 !== param1)
            {
                this._283396428resourceToDeduct = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourceToDeduct", _loc_2, param1));
            }
            return;
        }// end function

        public function set senderPlayerId(param1:int) : void
        {
            var _loc_2:* = this._481367759senderPlayerId;
            if (_loc_2 !== param1)
            {
                this._481367759senderPlayerId = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "senderPlayerId", _loc_2, param1));
            }
            return;
        }// end function

        public function get receiverPlayerId() : int
        {
            return this._40608021receiverPlayerId;
        }// end function

        public function toString() : String
        {
            return "<dTradeVO sender=\'" + this.senderPlayerId + "\' receiver=\'" + this.receiverPlayerId + "\' resourceToAdd=\'" + this.resourceToAdd + "\' resourceToDeduct=\'" + this.resourceToDeduct + "\' />";
        }// end function

        public function set resourceToAdd(param1:dResourceVO) : void
        {
            var _loc_2:* = this._969261240resourceToAdd;
            if (_loc_2 !== param1)
            {
                this._969261240resourceToAdd = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourceToAdd", _loc_2, param1));
            }
            return;
        }// end function

        public function get senderPlayerId() : int
        {
            return this._481367759senderPlayerId;
        }// end function

        public function get mailId() : int
        {
            return this._1081574094mailId;
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

        public function get resourceToAdd() : dResourceVO
        {
            return this._969261240resourceToAdd;
        }// end function

    }
}
