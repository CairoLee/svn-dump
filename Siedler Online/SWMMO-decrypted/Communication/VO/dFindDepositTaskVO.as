package Communication.VO
{
    import flash.events.*;
    import flash.utils.*;
    import mx.events.*;

    public class dFindDepositTaskVO extends Object implements IEventDispatcher
    {
        private var _1468320392search_string:String;
        private var _bindingEventDispatcher:EventDispatcher;
        private var _294460244uniqueID:dUniqueID;

        public function dFindDepositTaskVO()
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
            this.uniqueID = param1.readObject() as dUniqueID;
            this.search_string = param1.readUTF();
            return;
        }// end function

        public function hasEventListener(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.hasEventListener(param1);
        }// end function

        public function willTrigger(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.willTrigger(param1);
        }// end function

        public function get search_string() : String
        {
            return this._1468320392search_string;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeObject(this.uniqueID);
            param1.writeUTF(this.search_string);
            return;
        }// end function

        public function get uniqueID() : dUniqueID
        {
            return this._294460244uniqueID;
        }// end function

        public function addEventListener(param1:String, param2:Function, param3:Boolean = false, param4:int = 0, param5:Boolean = false) : void
        {
            this._bindingEventDispatcher.addEventListener(param1, param2, param3, param4, param5);
            return;
        }// end function

        public function set search_string(param1:String) : void
        {
            var _loc_2:* = this._1468320392search_string;
            if (_loc_2 !== param1)
            {
                this._1468320392search_string = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "search_string", _loc_2, param1));
            }
            return;
        }// end function

        public function removeEventListener(param1:String, param2:Function, param3:Boolean = false) : void
        {
            this._bindingEventDispatcher.removeEventListener(param1, param2, param3);
            return;
        }// end function

        public function toString() : String
        {
            return "<dFindDepositTaskVO uniqueID=" + this.uniqueID + " search_string=\'" + this.search_string + "\' >";
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

    }
}
