package com.bluebyte.bluefire.api.model.vo
{

    public class RoomPresenceUpdatedVO extends PresenceUpdatedVO
    {
        private var _room:String;

        public function RoomPresenceUpdatedVO(param1:String, param2:String, param3:Boolean)
        {
            super(param1, param3);
            this._room = param2;
            return;
        }// end function

        public function get room() : String
        {
            return this._room;
        }// end function

        public function set room(param1:String) : void
        {
            this._room = param1;
            return;
        }// end function

    }
}
