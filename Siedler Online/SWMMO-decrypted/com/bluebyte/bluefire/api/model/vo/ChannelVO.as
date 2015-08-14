package com.bluebyte.bluefire.api.model.vo
{
    import flash.events.*;
    import mx.collections.*;
    import mx.events.*;

    public class ChannelVO extends Object implements IEventDispatcher
    {
        private var _bindingEventDispatcher:EventDispatcher;
        private var _sortingIndex:int;
        private var _important:Boolean;
        private var _newMessages:Boolean;
        private var _name:String;
        private var _messages:ArrayCollection;
        private var _label:String;
        private var _rooms:ArrayCollection;
        private var _visible:Boolean;

        public function ChannelVO()
        {
            this._rooms = new ArrayCollection();
            this._messages = new ArrayCollection();
            this._bindingEventDispatcher = new EventDispatcher(IEventDispatcher(this));
            return;
        }// end function

        public function dispatchEvent(event:Event) : Boolean
        {
            return this._bindingEventDispatcher.dispatchEvent(event);
        }// end function

        public function get visible() : Boolean
        {
            return this._visible;
        }// end function

        public function hasEventListener(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.hasEventListener(param1);
        }// end function

        public function set important(param1:Boolean) : void
        {
            var _loc_2:* = this.important;
            if (_loc_2 !== param1)
            {
                this._208525278important = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "important", _loc_2, param1));
            }
            return;
        }// end function

        public function set sortingIndex(param1:int) : void
        {
            this._sortingIndex = param1;
            return;
        }// end function

        public function removeEventListener(param1:String, param2:Function, param3:Boolean = false) : void
        {
            this._bindingEventDispatcher.removeEventListener(param1, param2, param3);
            return;
        }// end function

        public function get name() : String
        {
            return this._name;
        }// end function

        public function get messages() : ArrayCollection
        {
            return this._messages;
        }// end function

        private function set _462094004messages(param1:ArrayCollection) : void
        {
            throw new Error("not used, just for data binding!");
        }// end function

        public function hasRoom(param1:String) : Boolean
        {
            var _loc_2:String = null;
            for each (_loc_2 in this._rooms)
            {
                
                if (_loc_2.toLowerCase() == param1.toLowerCase())
                {
                    return true;
                }
            }
            return false;
        }// end function

        private function set _208525278important(param1:Boolean) : void
        {
            this._important = param1;
            return;
        }// end function

        public function get newMessages() : Boolean
        {
            return this._newMessages;
        }// end function

        private function set _3373707name(param1:String) : void
        {
            this._name = param1;
            return;
        }// end function

        public function set name(param1:String) : void
        {
            var _loc_2:* = this.name;
            if (_loc_2 !== param1)
            {
                this._3373707name = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "name", _loc_2, param1));
            }
            return;
        }// end function

        public function willTrigger(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.willTrigger(param1);
        }// end function

        public function set newMessages(param1:Boolean) : void
        {
            var _loc_2:* = this.newMessages;
            if (_loc_2 !== param1)
            {
                this._794652428newMessages = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "newMessages", _loc_2, param1));
            }
            return;
        }// end function

        public function get important() : Boolean
        {
            return this._important;
        }// end function

        public function set visible(param1:Boolean) : void
        {
            this._visible = param1;
            return;
        }// end function

        public function set messages(param1:ArrayCollection) : void
        {
            var _loc_2:* = this.messages;
            if (_loc_2 !== param1)
            {
                this._462094004messages = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "messages", _loc_2, param1));
            }
            return;
        }// end function

        public function set label(param1:String) : void
        {
            this._label = param1;
            return;
        }// end function

        public function addMessage(param1:MessageVO) : void
        {
            this._messages.addItem(param1);
            return;
        }// end function

        public function get sortingIndex() : int
        {
            return this._sortingIndex;
        }// end function

        public function addEventListener(param1:String, param2:Function, param3:Boolean = false, param4:int = 0, param5:Boolean = false) : void
        {
            this._bindingEventDispatcher.addEventListener(param1, param2, param3, param4, param5);
            return;
        }// end function

        public function addRoom(param1:String) : void
        {
            this._rooms.addItem(param1);
            return;
        }// end function

        public function get label() : String
        {
            return this._label;
        }// end function

        private function set _794652428newMessages(param1:Boolean) : void
        {
            this._newMessages = param1;
            if (!this._newMessages)
            {
                this.important = false;
            }
            return;
        }// end function

        public function getRoomCount() : int
        {
            return this._rooms.length;
        }// end function

    }
}
