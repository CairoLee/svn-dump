package GO
{
    import nLib.*;

    public class cWatchData extends Object
    {
        private var yPixelOffset:int;
        private var xPixelOffset:int;

        public function cWatchData(param1:cXML)
        {
            this.xPixelOffset = int(param1.GetAttributeFloatingPoint("x") * 100);
            this.yPixelOffset = int(param1.GetAttributeFloatingPoint("y") * 100);
            return;
        }// end function

        public function getYPixelOffset() : int
        {
            return this.yPixelOffset;
        }// end function

        public function getXPixelOffset() : int
        {
            return this.xPixelOffset;
        }// end function

        public function toString() : String
        {
            return "<WatchData " + this.xPixelOffset + "/" + this.yPixelOffset + " >";
        }// end function

    }
}
