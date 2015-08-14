package Communication.VO
{
    import flash.events.*;
    import flash.utils.*;
    import mx.events.*;

    public class dResourceVO extends Object implements IEventDispatcher
    {
        private var _1413853096amount:int;
        private var _324534341name_string:String;
        private var _bindingEventDispatcher:EventDispatcher;

        public function dResourceVO()
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
            this.name_string = param1.readUTF();
            this.amount = param1.readInt();
            return;
        }// end function

        public function removeEventListener(param1:String, param2:Function, param3:Boolean = false) : void
        {
            this._bindingEventDispatcher.removeEventListener(param1, param2, param3);
            return;
        }// end function

        public function hasEventListener(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.hasEventListener(param1);
        }// end function

        public function get name_string() : String
        {
            return this._324534341name_string;
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

        public function toString() : String
        {
            return "<ResourceVO name=\'" + this.name_string + "\' amount=\'" + this.amount + "\' />";
        }// end function

        public function addEventListener(param1:String, param2:Function, param3:Boolean = false, param4:int = 0, param5:Boolean = false) : void
        {
            this._bindingEventDispatcher.addEventListener(param1, param2, param3, param4, param5);
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

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeUTF(this.name_string);
            param1.writeInt(this.amount);
            return;
        }// end function

        public function get amount() : int
        {
            return this._1413853096amount;
        }// end function

        public function willTrigger(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.willTrigger(param1);
        }// end function

    }
}
