package Interface
{
    import GO.*;
    import __AS3__.vec.*;

    public class cEditorInterface extends cGeneralInterface
    {
        private var mDragMode:Boolean;
        public var mCurrentBuildingOwnerShip:int;
        private const BORDER_REFRESH_DELAY:Number = 1;
        private var mCurrentBrushSize:int;
        public const ACTIVATE_TIMER_THREAD:Boolean = false;
        private var mRefreshDelay:Number;
        private var mDraggedBuilding:cBuilding;
        private var mBrushSizePosTable_vector:Vector.<int>;
        public var mComputeTimer:int = 0;
        private var mDragModeStartPos:int;

        public function cEditorInterface()
        {
            this.mBrushSizePosTable_vector = new Vector.<int>;
            return;
        }// end function

    }
}
