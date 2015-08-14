package Communication.VO
{
    import mx.collections.*;

    public class dPathVO extends Object
    {
        public var mPath:ArrayCollection;

        public function dPathVO()
        {
            this.mPath = new ArrayCollection();
            return;
        }// end function

        public function toString() : String
        {
            return gCalculations.createIntListString("dPathVO", this.mPath);
        }// end function

    }
}
