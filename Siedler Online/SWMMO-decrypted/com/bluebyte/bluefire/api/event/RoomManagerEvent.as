package com.bluebyte.bluefire.api.event
{
    import flash.events.*;

    public class RoomManagerEvent extends Event
    {
        public var data:Object;
        public static const ALL_ROOMS_JOINED:String = "AllRoomsJoined";

        public function RoomManagerEvent(param1:String, param2:Boolean = false, param3:Boolean = false)
        {
            super(param1, param2, param3);
            return;
        }// end function

        override public function clone() : Event
        {
            var _loc_1:* = new RoomManagerEvent(this.type, this.bubbles, this.cancelable);
            _loc_1.data = this.data;
            return _loc_1;
        }// end function

    }
}
