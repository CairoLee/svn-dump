package Communication.VO.Mail
{
    import flash.events.*;
    import flash.utils.*;
    import mx.events.*;

    public class dNewMailCountVO extends Object implements IEventDispatcher
    {
        private var _94851343count:int;
        private var _bindingEventDispatcher:EventDispatcher;

        public function dNewMailCountVO()
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
            this.count = param1.readInt();
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

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeInt(this.count);
            return;
        }// end function

        public function toString() : String
        {
            var _loc_1:String = "<dNewMailCountVO ";
            _loc_1 = _loc_1 + ("count=\'" + this.count + "\' ");
            _loc_1 = _loc_1 + " />\n";
            return _loc_1;
        }// end function

        public function get count() : int
        {
            return this._94851343count;
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

        public function set count(param1:int) : void
        {
            var _loc_2:* = this._94851343count;
            if (_loc_2 !== param1)
            {
                this._94851343count = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "count", _loc_2, param1));
            }
            return;
        }// end function

    }
}
