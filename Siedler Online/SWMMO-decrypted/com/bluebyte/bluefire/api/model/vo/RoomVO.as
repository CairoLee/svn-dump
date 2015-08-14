package com.bluebyte.bluefire.api.model.vo
{
    import mx.collections.*;

    public class RoomVO extends Object
    {
        private var _occupants:ArrayCollection;
        private var _name:String;

        public function RoomVO()
        {
            this._occupants = new ArrayCollection();
            return;
        }// end function

        public function removeOccupant(param1:String) : void
        {
            var _loc_2:int = 0;
            while (_loc_2 < this._occupants.length)
            {
                
                if (this._occupants[_loc_2].name == param1)
                {
                    this._occupants.removeItemAt(_loc_2);
                    return;
                }
                _loc_2++;
            }
            return;
        }// end function

        public function addOccupant(param1:RoomOccupantVO) : void
        {
            this._occupants.addItem(param1);
            return;
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

    }
}
