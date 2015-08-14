package GOSets
{
    import nLib.*;

    public class cGOSetListController extends Object
    {
        protected var mValue:Number;
        protected var mGOSetList:cGOSetList;

        public function cGOSetListController()
        {
            return;
        }// end function

        public function GetValue() : Number
        {
            return this.mValue;
        }// end function

        public function SetGOSetList(param1:cGOSetList) : void
        {
            this.mGOSetList = param1;
            return;
        }// end function

        protected function CalculateListItem() : void
        {
            gMisc.Assert(false, "Not implemented!");
            return;
        }// end function

        public function SetValue(param1:Number) : void
        {
            this.mValue = param1;
            this.CalculateListItem();
            return;
        }// end function

    }
}
