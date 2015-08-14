package com.bluebyte.bluefire.api.model.vo
{
    import com.bluebyte.bluefire.api.extensions.*;

    public class MessageVO extends Object
    {
        private var _text:String;
        private var _moderator:Boolean;
        private var _receiver:OccupantVO;
        private var _ownname:Boolean;
        private var _sender:OccupantVO;
        private var _important:Boolean;
        private var _groupMessage:Boolean;
        private var _clickable:Boolean;
        private var _time:Date;
        private var _extensions:Object;
        private var _room:String;

        public function MessageVO()
        {
            this._extensions = {};
            return;
        }// end function

        public function set receiver(param1:OccupantVO) : void
        {
            this._receiver = param1;
            return;
        }// end function

        public function set important(param1:Boolean) : void
        {
            this._important = param1;
            return;
        }// end function

        public function set ownname(param1:Boolean) : void
        {
            this._ownname = param1;
            return;
        }// end function

        public function get groupMessage() : Boolean
        {
            return this._groupMessage;
        }// end function

        public function getExtension(param1:String) : IMessageExtension
        {
            var name:* = param1;
            return this.getAllExtensions().filter(function (param1:IMessageExtension, param2:int, param3:Array) : Boolean
            {
                return name == null;
            }// end function
            )[0];
        }// end function

        public function set moderator(param1:Boolean) : void
        {
            this._moderator = param1;
            return;
        }// end function

        public function set clickable(param1:Boolean) : void
        {
            this._clickable = param1;
            return;
        }// end function

        public function get clickable() : Boolean
        {
            return this._clickable;
        }// end function

        public function set groupMessage(param1:Boolean) : void
        {
            this._groupMessage = param1;
            return;
        }// end function

        public function get ownname() : Boolean
        {
            return this._ownname;
        }// end function

        public function set text(param1:String) : void
        {
            this._text = param1;
            return;
        }// end function

        public function removeExtension(param1:IMessageExtension) : Boolean
        {
            var _loc_3:String = null;
            var _loc_2:* = this._extensions[param1.getNS()];
            for (_loc_3 in _loc_2)
            {
                
                if (_loc_2[_loc_3] === param1)
                {
                    _loc_2[_loc_3].remove();
                    _loc_2.splice(parseInt(_loc_3), 1);
                    return true;
                }
            }
            return false;
        }// end function

        public function get moderator() : Boolean
        {
            return this._moderator;
        }// end function

        public function addExtension(param1:IMessageExtension) : IMessageExtension
        {
            if (this._extensions[param1.getNS()] == null)
            {
                this._extensions[param1.getNS()] = [];
            }
            this._extensions[param1.getNS()].push(param1);
            return param1;
        }// end function

        public function set time(param1:Date) : void
        {
            this._time = param1;
            return;
        }// end function

        public function getAllExtensionsByNS(param1:String) : Array
        {
            return this._extensions[param1];
        }// end function

        public function get time() : Date
        {
            return this._time;
        }// end function

        public function get important() : Boolean
        {
            return this._important;
        }// end function

        public function get text() : String
        {
            return this._text;
        }// end function

        public function getAllExtensions() : Array
        {
            var _loc_2:String = null;
            var _loc_1:Array = [];
            for (_loc_2 in this._extensions)
            {
                
                _loc_1 = _loc_1.concat(this._extensions[_loc_2]);
            }
            return _loc_1;
        }// end function

        public function get receiver() : OccupantVO
        {
            return this._receiver;
        }// end function

        public function removeAllExtensions(param1:String) : void
        {
            var _loc_2:String = null;
            for (_loc_2 in this._extensions[param1])
            {
                
                this.removeExtension(this._extensions[param1][_loc_2]);
            }
            this._extensions[param1] = [];
            return;
        }// end function

        public function get sender() : OccupantVO
        {
            return this._sender;
        }// end function

        public function set room(param1:String) : void
        {
            this._room = param1;
            return;
        }// end function

        public function set sender(param1:OccupantVO) : void
        {
            this._sender = param1;
            return;
        }// end function

        public function get room() : String
        {
            return this._room;
        }// end function

    }
}
