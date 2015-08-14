package com.bluebyte.bluefire.api.model.vo
{

    public class PresenceUpdatedVO extends Object
    {
        private var _online:Boolean;
        private var _name:String;

        public function PresenceUpdatedVO(param1:String, param2:Boolean)
        {
            this._name = param1;
            this._online = param2;
            return;
        }// end function

        public function get online() : Boolean
        {
            return this._online;
        }// end function

        public function set name(param1:String) : void
        {
            this._name = param1;
            return;
        }// end function

        public function get name() : String
        {
            return this._name;
        }// end function

        public function set online(param1:Boolean) : void
        {
            this._online = param1;
            return;
        }// end function

    }
}
