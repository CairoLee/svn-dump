package GOSets
{

    public class cGOSetListControllerStatic extends cGOSetListController
    {

        public function cGOSetListControllerStatic()
        {
            return;
        }// end function

        override protected function CalculateListItem() : void
        {
            var _loc_1:cGOSetListItem = null;
            for each (_loc_1 in mGOSetList.mGOSetListItem_vector)
            {
                
                if (_loc_1.mValue == mValue)
                {
                    mGOSetList.SetCurrentRenderedItem(_loc_1);
                    return;
                }
            }
            mGOSetList.SetCurrentRenderedItem(mGOSetList.mGOSetListItem_vector[0]);
            return;
        }// end function

    }
}
