package mx.skins.halo
{
    import mx.skins.*;
    import mx.styles.*;
    import mx.utils.*;

    public class ProgressBarSkin extends Border
    {
        static const VERSION:String = "3.5.0.12683";

        public function ProgressBarSkin()
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
            var _loc_3:* = getStyle("barColor");
            var _loc_4:* = StyleManager.isValidStyleValue(_loc_3) ? (_loc_3) : (getStyle("themeColor"));
            var _loc_5:* = ColorUtil.adjustBrightness2(_loc_4, 40);
            var _loc_6:Array = [ColorUtil.adjustBrightness2(_loc_4, 40), _loc_4];
            graphics.clear();
            drawRoundRect(0, 0, param1, param2, 0, _loc_6, 0.5, verticalGradientMatrix(0, 0, param1 - 2, param2 - 2));
            drawRoundRect(1, 1, param1 - 2, param2 - 2, 0, _loc_6, 1, verticalGradientMatrix(0, 0, param1 - 2, param2 - 2));
            return;
        }// end function

    }
}
