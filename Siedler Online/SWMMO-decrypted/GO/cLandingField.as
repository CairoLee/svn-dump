package GO
{
    import Communication.VO.*;

    public class cLandingField extends Object
    {
        public var mGrid:int;
        public var mId:int;

        public function cLandingField()
        {
            return;
        }// end function

        public function CreateVO() : dLandingFieldVO
        {
            var _loc_1:* = new dLandingFieldVO();
            _loc_1.grid = this.mGrid;
            _loc_1.id = this.mId;
            return _loc_1;
        }// end function

        public function toString() : String
        {
            return "<LandingField mGrid=\'" + this.mGrid + "\' />";
        }// end function

    }
}
