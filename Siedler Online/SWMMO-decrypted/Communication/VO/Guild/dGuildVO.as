package Communication.VO.Guild
{
    import flash.events.*;
    import mx.collections.*;
    import mx.events.*;

    public class dGuildVO extends Object implements IEventDispatcher
    {
        private var _3357586motd:String;
        private var _1855820473bannerID:int;
        private var _3373707name:String;
        private var _107332log:ArrayCollection;
        private var _3530753size:int;
        private var _3355id:int;
        private var _bindingEventDispatcher:EventDispatcher;
        private var _150469524cacheTimeStamp:Number;
        private var _844081029maxSize:int;
        private var _1872501475playerPermissions:dGuildPlayerPermissionVO;
        private var _209571183foundTime:Number;
        private var _114586tag:String;
        private var _1724546052description:String;
        private var _108280263ranks:ArrayCollection;
        private var _948881689members:ArrayCollection;

        public function dGuildVO()
        {
            this._bindingEventDispatcher = new EventDispatcher(IEventDispatcher(this));
            return;
        }// end function

        public function get size() : int
        {
            return this._3530753size;
        }// end function

        public function get maxSize() : int
        {
            return this._844081029maxSize;
        }// end function

        public function willTrigger(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.willTrigger(param1);
        }// end function

        public function set size(param1:int) : void
        {
            var _loc_2:* = this._3530753size;
            if (_loc_2 !== param1)
            {
                this._3530753size = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "size", _loc_2, param1));
            }
            return;
        }// end function

        public function set maxSize(param1:int) : void
        {
            var _loc_2:* = this._844081029maxSize;
            if (_loc_2 !== param1)
            {
                this._844081029maxSize = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "maxSize", _loc_2, param1));
            }
            return;
        }// end function

        public function get name() : String
        {
            return this._3373707name;
        }// end function

        public function set log(param1:ArrayCollection) : void
        {
            var _loc_2:* = this._107332log;
            if (_loc_2 !== param1)
            {
                this._107332log = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "log", _loc_2, param1));
            }
            return;
        }// end function

        public function get motd() : String
        {
            return this._3357586motd;
        }// end function

        public function get cacheTimeStamp() : Number
        {
            return this._150469524cacheTimeStamp;
        }// end function

        public function set name(param1:String) : void
        {
            var _loc_2:* = this._3373707name;
            if (_loc_2 !== param1)
            {
                this._3373707name = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "name", _loc_2, param1));
            }
            return;
        }// end function

        public function get members() : ArrayCollection
        {
            return this._948881689members;
        }// end function

        public function get tag() : String
        {
            return this._114586tag;
        }// end function

        public function get id() : int
        {
            return this._3355id;
        }// end function

        public function set bannerID(param1:int) : void
        {
            var _loc_2:* = this._1855820473bannerID;
            if (_loc_2 !== param1)
            {
                this._1855820473bannerID = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "bannerID", _loc_2, param1));
            }
            return;
        }// end function

        public function set motd(param1:String) : void
        {
            var _loc_2:* = this._3357586motd;
            if (_loc_2 !== param1)
            {
                this._3357586motd = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "motd", _loc_2, param1));
            }
            return;
        }// end function

        public function set ranks(param1:ArrayCollection) : void
        {
            var _loc_2:* = this._108280263ranks;
            if (_loc_2 !== param1)
            {
                this._108280263ranks = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "ranks", _loc_2, param1));
            }
            return;
        }// end function

        public function set cacheTimeStamp(param1:Number) : void
        {
            var _loc_2:* = this._150469524cacheTimeStamp;
            if (_loc_2 !== param1)
            {
                this._150469524cacheTimeStamp = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "cacheTimeStamp", _loc_2, param1));
            }
            return;
        }// end function

        public function set members(param1:ArrayCollection) : void
        {
            var _loc_2:* = this._948881689members;
            if (_loc_2 !== param1)
            {
                this._948881689members = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "members", _loc_2, param1));
            }
            return;
        }// end function

        public function set tag(param1:String) : void
        {
            var _loc_2:* = this._114586tag;
            if (_loc_2 !== param1)
            {
                this._114586tag = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "tag", _loc_2, param1));
            }
            return;
        }// end function

        public function set id(param1:int) : void
        {
            var _loc_2:* = this._3355id;
            if (_loc_2 !== param1)
            {
                this._3355id = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "id", _loc_2, param1));
            }
            return;
        }// end function

        public function dispatchEvent(event:Event) : Boolean
        {
            return this._bindingEventDispatcher.dispatchEvent(event);
        }// end function

        public function get log() : ArrayCollection
        {
            return this._107332log;
        }// end function

        public function get ranks() : ArrayCollection
        {
            return this._108280263ranks;
        }// end function

        public function removeEventListener(param1:String, param2:Function, param3:Boolean = false) : void
        {
            this._bindingEventDispatcher.removeEventListener(param1, param2, param3);
            return;
        }// end function

        public function set playerPermissions(param1:dGuildPlayerPermissionVO) : void
        {
            var _loc_2:* = this._1872501475playerPermissions;
            if (_loc_2 !== param1)
            {
                this._1872501475playerPermissions = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "playerPermissions", _loc_2, param1));
            }
            return;
        }// end function

        public function get bannerID() : int
        {
            return this._1855820473bannerID;
        }// end function

        public function addEventListener(param1:String, param2:Function, param3:Boolean = false, param4:int = 0, param5:Boolean = false) : void
        {
            this._bindingEventDispatcher.addEventListener(param1, param2, param3, param4, param5);
            return;
        }// end function

        public function set foundTime(param1:Number) : void
        {
            var _loc_2:* = this._209571183foundTime;
            if (_loc_2 !== param1)
            {
                this._209571183foundTime = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "foundTime", _loc_2, param1));
            }
            return;
        }// end function

        public function get playerPermissions() : dGuildPlayerPermissionVO
        {
            return this._1872501475playerPermissions;
        }// end function

        public function get foundTime() : Number
        {
            return this._209571183foundTime;
        }// end function

        public function set description(param1:String) : void
        {
            var _loc_2:* = this._1724546052description;
            if (_loc_2 !== param1)
            {
                this._1724546052description = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "description", _loc_2, param1));
            }
            return;
        }// end function

        public function hasEventListener(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.hasEventListener(param1);
        }// end function

        public function get description() : String
        {
            return this._1724546052description;
        }// end function

    }
}
