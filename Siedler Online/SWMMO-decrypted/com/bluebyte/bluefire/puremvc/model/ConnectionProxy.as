package com.bluebyte.bluefire.puremvc.model
{
    import __AS3__.vec.*;
    import com.bluebyte.bluefire.api.model.vo.*;
    import com.bluebyte.bluefire.puremvc.*;
    import flash.events.*;
    import mx.collections.*;
    import mx.events.*;
    import org.puremvc.as3.multicore.interfaces.*;
    import org.puremvc.as3.multicore.patterns.proxy.*;

    public class ConnectionProxy extends Proxy implements IProxy, IEventDispatcher
    {
        private var _player:PlayerVO;
        private var _whispers:ArrayCollection;
        private var _status:int;
        private var _activeChannel:String;
        private var _messages:Vector.<MessageVO>;
        private var _channels:ArrayCollection;
        private var _bindingEventDispatcher:EventDispatcher;
        private var _constants:ConstantsVO;
        private var _server:ServerVO;
        private var _rooms:ArrayCollection;
        public static var VERSION:String = "";
        public static const NAME:String = "ConnectionProxy";

        public function ConnectionProxy()
        {
            this._constants = new ConstantsVO();
            this._messages = new Vector.<MessageVO>;
            this._rooms = new ArrayCollection();
            this._channels = new ArrayCollection();
            this._whispers = new ArrayCollection();
            this._bindingEventDispatcher = new EventDispatcher(IEventDispatcher(this));
            super(NAME);
            return;
        }// end function

        public function set server(param1:ServerVO) : void
        {
            this._server = param1;
            return;
        }// end function

        public function willTrigger(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.willTrigger(param1);
        }// end function

        private function set _892481550status(param1:int) : void
        {
            this._status = param1;
            return;
        }// end function

        public function isJoiningInProgress() : Boolean
        {
            return false;
        }// end function

        public function addRoom(param1:RoomVO) : void
        {
            this._rooms.addItem(param1);
            this.refreshChannels();
            return;
        }// end function

        public function set channels(param1:ArrayCollection) : void
        {
            var _loc_2:* = this.channels;
            if (_loc_2 !== param1)
            {
                this._1432626128channels = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "channels", _loc_2, param1));
            }
            return;
        }// end function

        private function addWhisper(param1:String) : ChannelVO
        {
            var _loc_2:* = new ChannelVO();
            _loc_2.name = param1;
            _loc_2.addRoom(param1);
            _loc_2.visible = true;
            this._whispers.addItem(_loc_2);
            sendNotification(BlueFireFacade.ADD_WHISPER, _loc_2);
            return _loc_2;
        }// end function

        public function addMessage(param1:MessageVO) : void
        {
            var _loc_2:ChannelVO = null;
            var _loc_3:Boolean = false;
            var _loc_4:ChannelVO = null;
            var _loc_5:ChannelVO = null;
            var _loc_6:ChannelVO = null;
            if (param1.groupMessage)
            {
                for each (_loc_2 in this._channels)
                {
                    
                    if (_loc_2.hasRoom(param1.room))
                    {
                        _loc_2.addMessage(param1);
                    }
                }
            }
            else
            {
                for each (_loc_4 in this._whispers)
                {
                    
                    if (_loc_4.name.toLowerCase() == param1.room.toLowerCase())
                    {
                        _loc_4.addMessage(param1);
                        _loc_3 = true;
                        break;
                    }
                }
                if (!_loc_3)
                {
                    _loc_6 = this.addWhisper(param1.room);
                    _loc_6.addMessage(param1);
                }
                for each (_loc_5 in this._channels)
                {
                    
                    if (_loc_5.hasRoom("whisper"))
                    {
                        _loc_5.addMessage(param1);
                    }
                }
            }
            return;
        }// end function

        public function addChannel(param1:ChannelVO) : void
        {
            this._channels.addItem(param1);
            return;
        }// end function

        public function get whispers() : ArrayCollection
        {
            return this._whispers;
        }// end function

        public function get CONSTANTS() : ConstantsVO
        {
            return this._constants;
        }// end function

        public function dispatchEvent(event:Event) : Boolean
        {
            return this._bindingEventDispatcher.dispatchEvent(event);
        }// end function

        public function set player(param1:PlayerVO) : void
        {
            this._player = param1;
            return;
        }// end function

        public function get server() : ServerVO
        {
            return this._server;
        }// end function

        public function removeEventListener(param1:String, param2:Function, param3:Boolean = false) : void
        {
            this._bindingEventDispatcher.removeEventListener(param1, param2, param3);
            return;
        }// end function

        private function refreshChannels() : void
        {
            var _loc_1:RoomVO = null;
            var _loc_2:ChannelVO = null;
            for each (_loc_1 in this._rooms)
            {
                
                for each (_loc_2 in this._channels)
                {
                    
                    if (_loc_2.hasRoom(_loc_1.name))
                    {
                        _loc_2.visible = true;
                    }
                }
            }
            return;
        }// end function

        public function getWhisper(param1:String) : ChannelVO
        {
            var _loc_2:ChannelVO = null;
            for each (_loc_2 in this._whispers)
            {
                
                if (_loc_2.name.toLowerCase() == param1.toLowerCase())
                {
                    return _loc_2;
                }
            }
            return this.addWhisper(param1);
        }// end function

        public function getChannel(param1:String) : ChannelVO
        {
            var _loc_2:ChannelVO = null;
            for each (_loc_2 in this._channels)
            {
                
                if (_loc_2.name == param1)
                {
                    return _loc_2;
                }
            }
            return null;
        }// end function

        public function getRoom(param1:String) : RoomVO
        {
            var _loc_2:int = 0;
            while (_loc_2 < this._rooms.length)
            {
                
                if (this._rooms[_loc_2].name == param1)
                {
                    return this._rooms[_loc_2];
                }
                _loc_2++;
            }
            return null;
        }// end function

        public function addEventListener(param1:String, param2:Function, param3:Boolean = false, param4:int = 0, param5:Boolean = false) : void
        {
            this._bindingEventDispatcher.addEventListener(param1, param2, param3, param4, param5);
            return;
        }// end function

        public function get channels() : ArrayCollection
        {
            return this._channels;
        }// end function

        private function set _1432626128channels(param1:ArrayCollection) : void
        {
            this._channels = param1;
            return;
        }// end function

        public function removeWhisper(param1:String) : void
        {
            var _loc_2:* = this.getWhisper(param1);
            this.whispers.removeItemAt(this.whispers.getItemIndex(_loc_2));
            sendNotification(BlueFireFacade.REMOVE_WHISPER, _loc_2);
            return;
        }// end function

        public function removeChannel(param1:String) : void
        {
            this._channels.removeItemAt(this._channels.getItemIndex(this.getChannel(param1)));
            return;
        }// end function

        public function get player() : PlayerVO
        {
            return this._player;
        }// end function

        public function set status(param1:int) : void
        {
            var _loc_2:* = this.status;
            if (_loc_2 !== param1)
            {
                this._892481550status = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "status", _loc_2, param1));
            }
            return;
        }// end function

        private function set _2132162255whispers(param1:ArrayCollection) : void
        {
            this._whispers = param1;
            return;
        }// end function

        public function set whispers(param1:ArrayCollection) : void
        {
            var _loc_2:* = this.whispers;
            if (_loc_2 !== param1)
            {
                this._2132162255whispers = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "whispers", _loc_2, param1));
            }
            return;
        }// end function

        public function set CONSTANTS(param1:ConstantsVO) : void
        {
            this._constants = param1;
            return;
        }// end function

        public function set rooms(param1:ArrayCollection) : void
        {
            this._rooms = param1;
            return;
        }// end function

        public function get status() : int
        {
            return this._status;
        }// end function

        public function hasEventListener(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.hasEventListener(param1);
        }// end function

        public function get rooms() : ArrayCollection
        {
            return this._rooms;
        }// end function

        public function removeRoom(param1:String) : void
        {
            var _loc_2:int = 0;
            while (_loc_2 < this._rooms.length)
            {
                
                if (this._rooms[_loc_2].name == param1)
                {
                    this._rooms.removeItemAt(_loc_2);
                    return;
                }
                _loc_2++;
            }
            return;
        }// end function

    }
}
