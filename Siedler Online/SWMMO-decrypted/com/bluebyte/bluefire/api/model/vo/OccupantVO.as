package com.bluebyte.bluefire.api.model.vo
{

    public class OccupantVO extends Object
    {
        private var _clickable:Boolean;
        private var _name:String;
        private var _id:int;

        public function OccupantVO()
        {
            return;
        }// end function

        public function get clickable() : Boolean
        {
            return this._clickable;
        }// end function

        public function set clickable(param1:Boolean) : void
        {
            this._clickable = param1;
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

        public function get id() : int
        {
            return this._id;
        }// end function

        public function set id(param1:int) : void
        {
            this._id = param1;
            return;
        }// end function

    }
}
