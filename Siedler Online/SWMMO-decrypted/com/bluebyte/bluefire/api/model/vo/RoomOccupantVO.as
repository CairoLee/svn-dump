package com.bluebyte.bluefire.api.model.vo
{

    public class RoomOccupantVO extends Object
    {
        private var _name:String;

        public function RoomOccupantVO()
        {
            return;
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

    }
}
