package SettlerKI
{
    import GO.*;
    import __AS3__.vec.*;
    import nLib.*;

    public class cSettlerKIWalkOnStreets extends cSettlerKI
    {
        private var mTempIntPoint:cPosInt;
        private var mLastDirection:int;
        private static var m4DirectionPrefereLastDirectionsFirst_list:Vector.<int> = cSettlerKIWalkOnStreets.Vector.<int>([0, 1, 3, 2, 1, 2, 0, 3, 2, 3, 1, 0, 3, 0, 2, 1, 0, 3, 1, 2, 1, 0, 2, 3, 2, 1, 3, 0, 3, 2, 0, 1, 3, 1, 0, 2, 0, 2, 1, 3, 1, 3, 2, 0, 2, 0, 3, 1, 3, 0, 1, 2, 0, 1, 2, 3, 1, 2, 3, 0, 2, 3, 0, 1, 1, 3, 0, 2, 2, 0, 1, 3, 3, 1, 2, 0, 0, 2, 3, 1, 1, 0, 3, 2, 2, 1, 0, 3, 3, 2, 1, 0, 0, 3, 2, 1]);

        public function cSettlerKIWalkOnStreets(param1:cSettler)
        {
            this.mTempIntPoint = new cPosInt();
            super(param1);
            this.mLastDirection = 0;
            return;
        }// end function

        override public function Compute() : void
        {
            return;
        }// end function

    }
}
