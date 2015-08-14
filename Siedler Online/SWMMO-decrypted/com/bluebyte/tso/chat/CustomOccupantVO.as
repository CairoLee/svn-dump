package com.bluebyte.tso.chat
{
    import com.bluebyte.bluefire.api.model.vo.*;

    public class CustomOccupantVO extends OccupantVO
    {
        private var _tag:String;

        public function CustomOccupantVO(param1:OccupantVO)
        {
            this.clickable = param1.clickable;
            this.id = param1.id;
            this.name = param1.name;
            return;
        }// end function

        public function get tag() : String
        {
            return this._tag;
        }// end function

        public function set tag(param1:String) : void
        {
            this._tag = param1;
            return;
        }// end function

    }
}
