package com.bluebyte.bluefire.api.model.vo
{

    public class PlayerVO extends Object
    {
        private var _id:int;
        private var _name:String;
        private var _password:String;

        public function PlayerVO()
        {
            return;
        }// end function

        public function get id() : int
        {
            return this._id;
        }// end function

        public function set password(param1:String) : void
        {
            this._password = param1;
            return;
        }// end function

        public function get password() : String
        {
            return this._password;
        }// end function

        public function get name() : String
        {
            return this._name;
        }// end function

        public function set id(param1:int) : void
        {
            this._id = param1;
            return;
        }// end function

        public function set name(param1:String) : void
        {
            this._name = param1;
            return;
        }// end function

    }
}
