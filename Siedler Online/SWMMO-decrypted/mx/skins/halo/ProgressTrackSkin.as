package mx.skins.halo
{
    import mx.skins.*;
    import mx.styles.*;
    import mx.utils.*;

    public class ProgressTrackSkin extends Border
    {
        static const VERSION:String = "3.5.0.12683";

        public function ProgressTrackSkin()
        {
            return;
        }// end function

        override public function get measuredWidth() : Number
        {
            return 200;
        }// end function

        override public function get measuredHeight() : Number
        {
            return 6;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            super.updateDisplayList(param1, param2);
            var _loc_3:* = getStyle("borderColor");
            var _loc_4:* = getStyle("trackColors") as Array;
            StyleManager.getColorNames(_loc_4);
            var _loc_5:* = ColorUtil.adjustBrightness2(_loc_3, -30);
            graphics.clear();
            drawRoundRect(0, 0, param1, param2, 0, [_loc_5, _loc_3], 1, verticalGradientMatrix(0, 0, param1, param2));
            drawRoundRect(1, 1, param1 - 2, param2 - 2, 0, _loc_4, 1, verticalGradientMatrix(1, 1, param1 - 2, param2 - 2));
            return;
        }// end function

    }
}
