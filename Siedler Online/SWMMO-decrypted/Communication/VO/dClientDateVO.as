package Communication.VO
{
    import mx.collections.*;

    public class dClientDateVO extends Object
    {
        public var mRefreshQuestList_vector:ArrayCollection;
        public var hoursTilNextDailyLoginDay:int;
        public var orginalServerDate:Number;
        public var fakeServerDate:Number;
        public var currentTimeOffsetDailyLogin:int;

        public function dClientDateVO()
        {
            this.mRefreshQuestList_vector = new ArrayCollection();
            return;
        }// end function

    }
}
