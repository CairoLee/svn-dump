package GOSets
{

    public class cGOSetListControllerPercentage extends cGOSetListController
    {
        private var mMaximumAmount:Number;

        public function cGOSetListControllerPercentage(param1:Number)
        {
            this.mMaximumAmount = param1;
            return;
        }// end function

        override protected function CalculateListItem() : void
        {
            var _loc_3:cGOSetListItem = null;
            var _loc_1:* = mValue / this.mMaximumAmount * 100;
            var _loc_2:cGOSetListItem = null;
            for each (_loc_3 in mGOSetList.mGOSetListItem_vector)
            {
                
                if (_loc_2 == null)
                {
                    _loc_2 = _loc_3;
                }
                if (_loc_3.mValue > _loc_1)
                {
                    mGOSetList.SetCurrentRenderedItem(_loc_2);
                    return;
                }
                _loc_2 = _loc_3;
            }
            mGOSetList.SetCurrentRenderedItem(_loc_2);
            return;
        }// end function

    }
}
