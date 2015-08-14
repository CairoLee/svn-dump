package Communication.VO
{
    import mx.collections.*;

    public class dDataTrackingVO extends Object
    {
        public var dataTracking:ArrayCollection;
        public var amount:int;

        public function dDataTrackingVO()
        {
            this.dataTracking = new ArrayCollection();
            return;
        }// end function

        public function toString() : String
        {
            var _loc_2:dDataIntStringVO = null;
            var _loc_1:String = "";
            if (this.dataTracking.length > 0)
            {
                _loc_1 = _loc_1 + (" <dDataTrackingVO amount=\'" + this.amount + "\'>\n");
                _loc_1 = _loc_1 + "  <dDataIntStringArray>\n";
                for each (_loc_2 in this.dataTracking)
                {
                    
                    _loc_1 = _loc_1 + ("  " + _loc_2 + "\n");
                }
                _loc_1 = _loc_1 + "  </dDataIntStringArray>\n";
                _loc_1 = _loc_1 + " </dDataTrackingVO>";
            }
            else
            {
                _loc_1 = "<dDataTrackingVO amount=\'" + this.amount + "\'/>";
            }
            return _loc_1;
        }// end function

    }
}
