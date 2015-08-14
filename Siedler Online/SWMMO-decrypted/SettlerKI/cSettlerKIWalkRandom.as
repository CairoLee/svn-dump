package SettlerKI
{
    import GO.*;

    public class cSettlerKIWalkRandom extends cSettlerKI
    {
        private var mDirectionAngle:Number;

        public function cSettlerKIWalkRandom(param1:cSettler)
        {
            super(param1);
            this.mDirectionAngle = Math.random();
            return;
        }// end function

        override public function Compute() : void
        {
            var _loc_1:Number = NaN;
            mSettler.Animate();
            mNewDirection = mNewDirection - 0.1;
            if (mNewDirection < 0)
            {
                mNewDirection = 10.25;
                _loc_1 = Math.random();
                if (_loc_1 > 0.666)
                {
                    this.mDirectionAngle = gCalculations.AddAngle(this.mDirectionAngle, 0.125 / 4);
                }
                else if (_loc_1 > 0.333)
                {
                    this.mDirectionAngle = gCalculations.AddAngle(this.mDirectionAngle, -0.125 / 4);
                }
                mDirection = gCalculations.TransFormPoint(this.mDirectionAngle, 1);
            }
            super.BounceBackFromBoarder();
            super.SetSubTypeFromDirection();
            return;
        }// end function

    }
}
