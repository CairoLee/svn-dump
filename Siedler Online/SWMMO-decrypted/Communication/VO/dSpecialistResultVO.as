package Communication.VO
{
    import flash.events.*;
    import flash.utils.*;
    import mx.events.*;

    public class dSpecialistResultVO extends Object implements IEventDispatcher
    {
        private var _bindingEventDispatcher:EventDispatcher;
        private var _3575610type:int;
        private var _886715680withCosts:Boolean;
        private var _294460244uniqueID:dUniqueID;

        public function dSpecialistResultVO()
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
            this.type = param1.readInt();
            this.uniqueID = param1.readObject() as dUniqueID;
            this.withCosts = param1.readBoolean();
            return;
        }// end function

        public function set type(param1:int) : void
        {
            var _loc_2:* = this._3575610type;
            if (_loc_2 !== param1)
            {
                this._3575610type = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "type", _loc_2, param1));
            }
            return;
        }// end function

        public function willTrigger(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.willTrigger(param1);
        }// end function

        public function set withCosts(param1:Boolean) : void
        {
            var _loc_2:* = this._886715680withCosts;
            if (_loc_2 !== param1)
            {
                this._886715680withCosts = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "withCosts", _loc_2, param1));
            }
            return;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeInt(this.type);
            param1.writeObject(this.uniqueID);
            param1.writeBoolean(this.withCosts);
            return;
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

        public function set uniqueID(param1:dUniqueID) : void
        {
            var _loc_2:* = this._294460244uniqueID;
            if (_loc_2 !== param1)
            {
                this._294460244uniqueID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "uniqueID", _loc_2, param1));
            }
            return;
        }// end function

        public function get withCosts() : Boolean
        {
            return this._886715680withCosts;
        }// end function

        public function get uniqueID() : dUniqueID
        {
            return this._294460244uniqueID;
        }// end function

        public function hasEventListener(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.hasEventListener(param1);
        }// end function

        public function get type() : int
        {
            return this._3575610type;
        }// end function

    }
}
