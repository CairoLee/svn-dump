package Communication.VO.Guild
{
    import flash.events.*;
    import mx.collections.*;
    import mx.events.*;

    public class dGuildHeadersListVO extends Object implements IEventDispatcher
    {
        private var _bindingEventDispatcher:EventDispatcher;
        private var _3322014list:ArrayCollection;
        private var _3433103page:int;
        private var _393681088maxPages:int;

        public function dGuildHeadersListVO()
        {
            this._bindingEventDispatcher = new EventDispatcher(IEventDispatcher(this));
            return;
        }// end function

        public function get maxPages() : int
        {
            return this._393681088maxPages;
        }// end function

        public function removeEventListener(param1:String, param2:Function, param3:Boolean = false) : void
        {
            this._bindingEventDispatcher.removeEventListener(param1, param2, param3);
            return;
        }// end function

        public function set maxPages(param1:int) : void
        {
            var _loc_2:* = this._393681088maxPages;
            if (_loc_2 !== param1)
            {
                this._393681088maxPages = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "maxPages", _loc_2, param1));
            }
            return;
        }// end function

        public function addEventListener(param1:String, param2:Function, param3:Boolean = false, param4:int = 0, param5:Boolean = false) : void
        {
            this._bindingEventDispatcher.addEventListener(param1, param2, param3, param4, param5);
            return;
        }// end function

        public function willTrigger(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.willTrigger(param1);
        }// end function

        public function get page() : int
        {
            return this._3433103page;
        }// end function

        public function dispatchEvent(event:Event) : Boolean
        {
            return this._bindingEventDispatcher.dispatchEvent(event);
        }// end function

        public function get list() : ArrayCollection
        {
            return this._3322014list;
        }// end function

        public function set page(param1:int) : void
        {
            var _loc_2:* = this._3433103page;
            if (_loc_2 !== param1)
            {
                this._3433103page = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "page", _loc_2, param1));
            }
            return;
        }// end function

        public function hasEventListener(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.hasEventListener(param1);
        }// end function

        public function set list(param1:ArrayCollection) : void
        {
            var _loc_2:* = this._3322014list;
            if (_loc_2 !== param1)
            {
                this._3322014list = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "list", _loc_2, param1));
            }
            return;
        }// end function

    }
}
