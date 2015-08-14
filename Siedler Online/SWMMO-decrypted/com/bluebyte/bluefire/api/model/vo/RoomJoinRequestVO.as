package com.bluebyte.bluefire.api.model.vo
{

    public class RoomJoinRequestVO extends Object
    {
        private var _useForOnlineStatus:Boolean;
        private var _name:String;

        public function RoomJoinRequestVO(param1:String, param2:Boolean = false)
        {
            this._name = param1;
            this._useForOnlineStatus = param2;
            return;
        }// end function

        public function get useForOnlineStatus() : Boolean
        {
            return this._useForOnlineStatus;
        }// end function

        public function get name() : String
        {
            return this._name;
        }// end function

        public function set name(param1:String) : void
        {
            this._name = param1;
            return;
        }// end function

        public function set useForOnlineStatus(param1:Boolean) : void
        {
            this._useForOnlineStatus = param1;
            return;
        }// end function

    }
}
