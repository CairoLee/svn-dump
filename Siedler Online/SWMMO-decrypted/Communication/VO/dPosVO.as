package Communication.VO
{
    import flash.events.*;
    import flash.utils.*;
    import mx.events.*;

    public class dPosVO extends Object implements IEventDispatcher
    {
        private var _120x:Number;
        private var _121y:Number;
        private var _bindingEventDispatcher:EventDispatcher;

        public function dPosVO()
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
            this.x = param1.readDouble();
            this.y = param1.readDouble();
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
            param1.writeDouble(this.x);
            param1.writeDouble(this.y);
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

        public function set y(param1:Number) : void
        {
            var _loc_2:* = this._121y;
            if (_loc_2 !== param1)
            {
                this._121y = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "y", _loc_2, param1));
            }
            return;
        }// end function

        public function set x(param1:Number) : void
        {
            var _loc_2:* = this._120x;
            if (_loc_2 !== param1)
            {
                this._120x = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "x", _loc_2, param1));
            }
            return;
        }// end function

        public function get x() : Number
        {
            return this._120x;
        }// end function

        public function get y() : Number
        {
            return this._121y;
        }// end function

    }
}
