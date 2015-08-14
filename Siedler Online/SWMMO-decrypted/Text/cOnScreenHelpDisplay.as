package Text
{
    import Interface.*;

    public class cOnScreenHelpDisplay extends Object
    {
        private var mGeneralInterface:cGeneralInterface;

        public function cOnScreenHelpDisplay(param1:cGeneralInterface)
        {
            this.mGeneralInterface = param1;
            return;
        }// end function

        public function CreateFPSText_string() : String
        {
            return "FPS: " + Math.round(this.mGeneralInterface.mCalculateTicks.GetFps() * 10) / 10;
        }// end function

        public function CreatePlayerMapInfoText_string() : String
        {
            var _loc_1:* = "CursorEditMode: " + this.mGeneralInterface.mCurrentCursor.GetEditMode() + " " + "Shadows: " + this.mGeneralInterface.mRenderBuildingShadows + "\n";
            _loc_1 = _loc_1 + "\n";
            _loc_1 = _loc_1 + ("Cursor pixelX,pixelY,grid: " + this.mGeneralInterface.mCurrentCursor.GetCursorXPixelPos() + "," + this.mGeneralInterface.mCurrentCursor.GetCursorYPixelPos() + "," + this.mGeneralInterface.mCurrentCursor.GetGridPosition());
            return _loc_1;
        }// end function

    }
}
