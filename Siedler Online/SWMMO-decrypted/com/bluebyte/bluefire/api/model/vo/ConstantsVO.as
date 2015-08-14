package com.bluebyte.bluefire.api.model.vo
{

    public class ConstantsVO extends Object
    {
        private var _roomGroupSeperator:String;

        public function ConstantsVO()
        {
            return;
        }// end function

        public function set ROOM_GROUP_SEPERATOR(param1:String) : void
        {
            this._roomGroupSeperator = param1;
            return;
        }// end function

        public function get ROOM_GROUP_SEPERATOR() : String
        {
            return this._roomGroupSeperator;
        }// end function

    }
}
