package mx.skins.halo
{
    import flash.display.*;
    import mx.skins.*;
    import mx.styles.*;
    import mx.utils.*;

    public class ProgressIndeterminateSkin extends Border
    {
        static const VERSION:String = "3.5.0.12683";

        public function ProgressIndeterminateSkin()
        {
            return;
        }// end function

        override public function get measuredWidth() : Number
        {
            return 195;
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
            var _loc_5:* = ColorUtil.adjustBrightness2(_loc_4, 60);
            var _loc_6:* = getStyle("indeterminateMoveInterval");
            if (isNaN(_loc_6) || _loc_6 == 0)
            {
                _loc_6 = 28;
            }
            var _loc_7:* = graphics;
            graphics.clear();
            var _loc_8:int = 0;
            while (_loc_8 < param1)
            {
                
                _loc_7.beginFill(_loc_5, 0.8);
                _loc_7.moveTo(_loc_8, 1);
                _loc_7.lineTo(Math.min(_loc_8 + 14, param1), 1);
                _loc_7.lineTo(Math.min(_loc_8 + 10, param1), (param2 - 1));
                _loc_7.lineTo(Math.max(_loc_8 - 4, 0), (param2 - 1));
                _loc_7.lineTo(_loc_8, 1);
                _loc_7.endFill();
                _loc_8 = _loc_8 + _loc_6;
            }
            return;
        }// end function

    }
}
