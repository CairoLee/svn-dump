package nLib
{

    public class cUbiRandom extends Object
    {
        private var mSeed:int;

        public function cUbiRandom(param1:int)
        {
            this.mSeed = param1;
            return;
        }// end function

        public function SetSeed(param1:int) : void
        {
            this.mSeed = param1;
            return;
        }// end function

        public function GetRandomInt(param1:int) : int
        {
            if (param1 <= 0)
            {
                return 0;
            }
            var _loc_3:String = this;
            var _loc_4:* = this.mSeed + 1;
            _loc_3.mSeed = _loc_4;
            var _loc_2:* = this.mSeed % param1;
            return _loc_2;
        }// end function

        public function GetSeed() : int
        {
            return this.mSeed;
        }// end function

    }
}
