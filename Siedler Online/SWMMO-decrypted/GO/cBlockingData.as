package GO
{
    import nLib.*;

    public class cBlockingData extends Object
    {
        private var yPixelOffset:int;
        private var xPixelOffset:int;
        private var blockingType:int;
        public static const BLOCK_TYPE_ALLOW_NOTHING:int = 1;
        public static const BLOCK_TYPE_ALLOW_STREETS:int = 2;
        public static const BLOCK_TYPE_ALLOW_ALL:int = 0;

        public function cBlockingData(param1:cXML)
        {
            this.xPixelOffset = int(param1.GetAttributeFloatingPoint("x") * 100);
            this.yPixelOffset = int(param1.GetAttributeFloatingPoint("y") * 100);
            this.blockingType = param1.GetAttributeInt("blockingType");
            return;
        }// end function

        public function getBlockingType() : int
        {
            return this.blockingType;
        }// end function

        public function getXPixelOffset() : int
        {
            return this.xPixelOffset;
        }// end function

        public function getYPixelOffset() : int
        {
            return this.yPixelOffset;
        }// end function

    }
}
