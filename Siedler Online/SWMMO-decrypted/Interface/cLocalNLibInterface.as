package Interface
{
    import nLib.*;

    public class cLocalNLibInterface extends cNLibInterface
    {
        private var mGeneralInterface:cGeneralInterface;

        public function cLocalNLibInterface(param1:cGeneralInterface)
        {
            this.mGeneralInterface = param1;
            return;
        }// end function

        override public function UpdatePositions() : void
        {
            if (this.mGeneralInterface.mCurrentPlayerZone != null)
            {
                this.mGeneralInterface.mCurrentPlayerZone.UpdatePositions();
            }
            this.mGeneralInterface.mCurrentPlayerZone.SetAllRescaleDirtyFlags();
            return;
        }// end function

        override public function ZoomHasChanged() : void
        {
            this.mGeneralInterface.ZoomHasChanged();
            return;
        }// end function

        override public function CacheBackgroundScroll() : void
        {
            if (this.mGeneralInterface.mCurrentPlayerZone != null)
            {
                this.mGeneralInterface.mCurrentPlayerZone.CacheBackgroundScroll();
            }
            return;
        }// end function

    }
}
